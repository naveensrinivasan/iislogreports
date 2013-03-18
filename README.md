# README #

**iislogreports** is for analyzing IIS logs using [LinqPad](https://www.linqpad.net/ "LINQPad") and using SQL Server as a store.

## Prerequisites ##
1. LINQPad
2. cygwin ( I use cygwin to run the shell script for cleaning the file. This could be substituted with anything else.)



## Setup ##
- Copy the iis logs folder to a folder.
- Copy the sed-iis.sh to root of the logs folder and run the script. The sed script removes the iis header lines starting with "#".
- Move the folder to the SQL Server. To use it in bulkimport.
- Run createtable.sql to create the logs table.
- Run the script bulkimport-iis.sql to load the log files into the table.
- Open the iislogs.linq and execute to get the reports.

### Sample report ####
![](https://dl.dropbox.com/u/19639689/images/iislogs.jpg)