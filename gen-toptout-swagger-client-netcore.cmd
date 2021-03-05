if not exist "./bin" mkdir "./bin"

if not exist ./bin/swagger-codegen-cli.jar (
	curl.exe --output ./bin/swagger-codegen-cli.jar --url https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/3.0.25/swagger-codegen-cli-3.0.25.jar
)

java -jar ./bin/swagger-codegen-cli.jar generate -i https://raw.githubusercontent.com/beatcracker/toptout/master/schema/openapi.yaml -l csharp -o ./src/ToptoutCli.SwaggerClient --additional-properties targetFramework=v5.0,netCoreProjectFile=true