
echo COMMIT APP

pushd "%~dp0"
echo %~dp0

C:\Applics\7-zip\7z.exe x APP_64.7z -oc:\Applics\Cockpit\ -aoa
IF %ERRORLEVEL% NEQ 0 (GOTO endError)

rem C:\Applics\Cockpit\HAL\server\apache-karaf-4.2.7\bin\contrib\HAL.exe install
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

rem C:\Applics\Cockpit\HAL\server\apache-karaf-4.2.7\bin\contrib\HAL.exe start
rem IF %ERRORLEVEL% NEQ 0 (GOTO endError)

:endOk
EXIT /b 0

:endError
Exit /B %ERRORLEVEL%