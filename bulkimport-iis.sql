
/*
   Bulk Import IIS Log files. 
   Change the path to the log file location.
*/

DROP TABLE #files
GO
CREATE TABLE #files (name varchar(200) NULL, sql varchar(7000) NULL)
GO

INSERT #files(name) EXEC master..xp_cmdshell 'dir /b C:\Temp\*.log'

UPDATE #files
SET   sql  = 'BULK INSERT [dbo].[IISLog] FROM ''C:\TEMP\W3SVC1\' + name + ''' WITH (' +
             'FIELDTERMINATOR = '' '', ' +
             'ROWTERMINATOR = ''0x0A'')'

DECLARE @sql varchar(8000)

DECLARE cur CURSOR STATIC LOCAL FOR
   SELECT sql FROM #files

OPEN cur

WHILE 1 = 1
BEGIN
   FETCH cur INTO @sql
   IF @@fetch_status <> 0
      BREAK

   EXEC(@sql)
END

DEALLOCATE cur             


