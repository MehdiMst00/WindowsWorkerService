# Simple windows worker service using .net 6

## PowerShell command to run windows service
### Create Windows Service
```
sc.exe create ".NET6 Timer Windows Service" binpath="...\WorkerService.exe"
```
### Start Windows Service
```
sc.exe start ".NET6 Timer Windows Service"
```
### Stop Windows Service
```
sc.exe stop ".NET6 Timer Windows Service"
```
### Delete Windows Service
```
sc.exe delete ".NET6 Timer Windows Service"
```
