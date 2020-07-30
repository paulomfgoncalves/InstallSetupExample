
echo ROLLBACK APP

pushd "%~dp0"
echo %~dp0

rem C:\Applics\Cockpit\HAL\server\apache-karaf-4.2.7\bin\karaf stop
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

rem sc delete "HAL"
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

rem taskkill /f /fi "SERVICES eq HAL"
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

rem rd /s /q /f "C:\Applics\Cockpit\HAL\"
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

rem DEL /F /Q /S C:\Directory\*.*
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

:endOk
EXIT /b 0

:endError
Exit /B %ERRORLEVEL%