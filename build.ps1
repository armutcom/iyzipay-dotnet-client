dotnet --info

echo The installed .NET Core SDKs are:
dir $env:ProgramFiles"\dotnet\sdk" | findstr /l "."

dotnet restore Armut.Iyzipay.sln

dotnet build ./Iyzipay.Tests/Armut.Iyzipay.Tests.csproj -c Release