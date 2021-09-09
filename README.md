# CsvCodeGen

Get the tool on NuGet:
https://www.nuget.org/packages/CsvCodeGen/

Install with:
```
dotnet tool install --global CsvCodeGen --version 1.0.0
```

**Do not forget to add this dependency to your project:**
```
dotnet add package Sylvan.Data.Csv --version 1.1.8
```

**Perhaps also useful for string conversion:**
```
dotnet add package PStringExtensions --version 1.0.0
```
[PStringExtensions usage](https://github.com/StrajnarFilip/PString)

# Usage

```
CsvCodeGen <namespace> <class> <csv file path>
```
Example of usage:
```
CsvCodeGen Finance Receipt Transactions.csv
```
