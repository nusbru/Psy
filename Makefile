.PHONY: all build run test clean

all: build

build:
		dotnet build "PsyApp.sln"

run:
		dotnet run --project "/home/bruno/Projects/PsyApp/src/PsyApp.UI"

test:
		dotnet test "/home/bruno/Projects/PsyApp/test/PsyApp.UI.Tests"

clean:
		dotnet clean "PsyApp.sln"
