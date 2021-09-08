# Copyright 2021 Filip Strajnar
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.


dotnet publish --runtime win-x64 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime win-x86 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime win-arm64 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime win-arm `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime linux-x64 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime linux-musl-x64 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime linux-arm `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime linux-arm64 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true

dotnet publish --runtime rhel-x64 `
-p:PublishSingleFile=true `
-p:PublishTrimmed=true `
-p:IncludeAllContentForSelfExtract=true `
--self-contained=true