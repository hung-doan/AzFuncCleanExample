# To generate report
# We need to: dotnet tool install -g dotnet-reportgenerator-globaltool 


try {
    $testResultDir = "TestResults";
    $testReportDir = "CoverageReports";

    if (Test-Path -Path $testResultDir) {
        Remove-Item -Recurse -Force $testResultDir
    }
    if (Test-Path -Path $testReportDir) {
        Remove-Item -Recurse -Force $testReportDir
    }
    
    # Run the test
    dotnet test "..\Src\AzFuncCleanExample.sln" `
        --collect:"XPlat Code Coverage" `
        --results-directory $testResultDir `
        --filter FullyQualifiedName~.UnitTest `
        /p:CoverletOutputFormat=cobertura
    
    # Generate report
    reportgenerator "-reports:TestResults\*\coverage.cobertura.xml" "-targetdir:${testReportDir}" -reporttypes:Html
} catch {
    throw
}
