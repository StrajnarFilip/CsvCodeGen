/*
   Copyright 2021 Filip Strajnar

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using Sylvan.Data.Csv;
using System.Collections.Generic;

namespace CsvCodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Tool usage:\nCsvCodeGen <namespace> <class> <csv file path>");
                return;
            }

            var codegen_result = CodeGen(args[0], args[1], args[2]);
            System.IO.File.WriteAllText($"{args[1]}.cs", codegen_result);
        }

        static string CodeGen(string namespace_name, string class_name, string csv_path)
        {
            List<string> properties = new List<string>();
            List<string> constructing = new List<string>();

            var csv = Sylvan.Data.Csv.CsvDataReader.Create(csv_path, new CsvDataReaderOptions { HasHeaders = false });
            for (int i = 0; i < csv.FieldCount; i++)
            {
                string correct = "";
                string tmp = csv.GetString(i);
                if (!Char.IsLetter(tmp[0]) && !(tmp[0] == '_'))
                {
                    correct += "_";
                }

                foreach (var item in tmp)
                {
                    if (Char.IsLetter(item) || Char.IsNumber(item) || item == '_')
                        correct += item;
                }

                properties.Add($"public string {correct}_{i} {{ get; set; }}\n");

                constructing.Add($"{correct}_{i} = reader.GetString({i}),\n");
            }
            string GeneratedDocument = $"using System.Collections.Generic;\nusing Sylvan.Data.Csv;\nnamespace {namespace_name}\n{{\n    class {class_name}\n    {{\n";
            foreach (var property in properties)
            {
                GeneratedDocument += $"        {property}";
            }


            GeneratedDocument += @"        public static " + class_name + @" ReadRow(CsvDataReader reader)
        {
            return new " + class_name + @"
            {
";

            foreach (var part in constructing)
            {
                GeneratedDocument += $"                {part}";
            }
            GeneratedDocument += @"
            };
        }";
            GeneratedDocument += @"
        public static List<" + class_name + @"> Read(CsvDataReader reader)
        {
            List<" + class_name + @"> entireDocument = new();
            while (reader.Read())
            {
                entireDocument.Add(ReadRow(reader));
            }
            return entireDocument;
        }

        public static List<" + class_name + @"> ReadFile(string csv_path)
        {
            var csv = Sylvan.Data.Csv.CsvDataReader.Create(csv_path, new CsvDataReaderOptions { HasHeaders = true });
            return Read(csv);
        }
    }
}";

            return GeneratedDocument;
        }
    }
}
