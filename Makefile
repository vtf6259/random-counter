.PHONY: all
all:
	dotnet publish --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true  --configuration Release