/*
Script to create the IIS Logs table.
*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IISLog](
	[date] [datetime] NULL,
	[time] [datetime] NULL,
	[s-ip] [varchar](50) NULL,
	[cs-method] [varchar](2048) NULL,
	[cs-uri-stem] [varchar](255) NULL,
	[cs-uri-query] [varchar](2048) NULL,
	[s-port] [varchar](2048) NULL,
	[cs-username] [varchar](2048) NULL,
	[c-ip] [varchar](50) NULL,
	[cs(User-Agent)] [varchar](2048) NULL,
	[sc-status] [int] NULL,
	[sc-substatus] [int] NULL,
	[sc-win32-status] [int] NULL,
	[time-taken] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Date_Index] ON [dbo].[IISLog] 
(
	[date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [status_index] ON [dbo].[IISLog] 
(
	[sc-status] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Time_Index] ON [dbo].[IISLog] 
(
	[time] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [timetaken_index] ON [dbo].[IISLog] 
(
	[time-taken] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
