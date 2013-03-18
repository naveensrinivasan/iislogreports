IISLogs.Min (iisl => iisl.Date)
.Dump("Log Start");


IISLogs.Max (iisl => iisl.Date)
.Dump("Log End");

IISLogs.GroupBy (iisl => iisl.Date.Value.Month)
.Select (iisl =>  new {Key = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(iisl.Key), 
	Count = iisl.Count ()} )
.ToList()
.Select (iisl => new {Month = iisl.Key, Count= iisl.Count.ToString("N")})
.Dump("Requests by Month across years");


IISLogs.GroupBy (iisl => iisl.Date.Value.Year)
.Select (iisl =>  new {Key = iisl.Key, 
	Count = iisl.Count ()} )
.Dump("Requests by year");


IISLogs.GroupBy (iisl => iisl.Sc_status)
.Select (iisl =>  new {HttpCode = iisl.Key, 
	Count = iisl.Count ()} )
.Dump("Response code");

IISLogs
.Where (iisl => iisl.Sc_status == 500)
.GroupBy (iisl => iisl.Date)
.Select (iisl =>  new {HttpCode = iisl.Key.Value.ToShortDateString(), 
	Count = iisl.Count ()} )
.OrderByDescending (iisl => iisl.Count)	
.Dump("Failures by date");


IISLogs.GroupBy (iisl => iisl.Time.Value.Hour)
.Select (iisl =>  new {Hour = iisl.Key, 
	Count = iisl.Count ()} )
.Dump("Requests by the hour");


IISLogs.
	Select (iisl => iisl.Date.Value.Year)
	.Where (iisl => iisl != 2010)
	.Distinct()
	.Select (year => 
				IISLogs.Where (iisl => iisl.Date.Value.Year ==year)
					   .GroupBy (iisl => iisl.Date.Value.DayOfYear)
					   .Select (iisl =>  new {Date =  new DateTime(year,1,1).AddDays( iisl.Key - 1).ToShortDateString()
					   						  ,Count = iisl.Count ()} )
					   .OrderByDescending(item => item.Count)
					   .Take(20))
	.Dump("Top 20 busiest days by year");


IISLogs.
	Select (iisl => iisl.Date.Value.Year)
	.Distinct()
	.Select (year => 
				IISLogs.Where (iisl => iisl.Date.Value.Year ==year)
					   .GroupBy (iisl => iisl.Date.Value.Date)
					   .Select (iisl =>  new {Key =  iisl.Key
					   						  ,Count = iisl.Count ()} )
					   .OrderByDescending(item => item.Count)
					   .First ())
	.Select (year => 
		IISLogs.Where (iisl => iisl.Date.Value.Date == year.Key)
		.GroupBy (iisl => iisl.Time.Value.Hour)
		.Select (iisl =>  new {Hour= iisl.Key,Date = iisl.First ().Date.Value.ToShortDateString(),
		Count = iisl.Count ().ToString()} )
		.OrderBy (iisl => iisl.Hour))
	.Dump("Hits by the hour on the busiest day");

IISLogs.
	Select (iisl => iisl.Date.Value.Year)
	.Distinct()
	.Select (year => 
IISLogs.Where (iisl => iisl.Date.Value.Year == year)
.GroupBy (iisl => iisl.Date.Value.Month)
	.Select (iisl => new {Key =  new DateTime(year,iisl.Key,1).AddDays( iisl.Key - 1),Count = iisl.Count ()})
	)
	.ToList()
	.SelectMany (year => year)
	.Select (year => new {Date = year.Key.ToString("MMM-yyyy"), Hits = year.Count})
	.Dump("Hits by Month");
    
    
IISLogs.Where (iisl => iisl.Date.Value.Date == DateTime.Parse("2/1/2013") && iisl.Time.Value.Hour ==7 )
.Where (iisl => iisl.Time_taken > 500)
.Select (iisl => iisl.Time_taken)
.Dump("Time taken to respond on the busiest hour");


IISLogs.Where (iisl => iisl.Date.Value.Date == DateTime.Parse("2/1/2013") && iisl.Time.Value.Hour ==7 )
.Where (iisl => iisl.Time_taken > 500)
.Select (iisl => iisl.Time_taken)
.Dump("Time taken to respond on the busiest hour");

IISLogs.Where (iisl => iisl.Date.Value.Year == 2012 )
.Where (iisl => iisl.Time_taken > 500)
.GroupBy (iisl => iisl.Date.Value.DayOfYear)
.Select (iisl => new {Date =  new DateTime(2012,1,1).AddDays( iisl.Key - 1).ToShortDateString(), NumberOfRequests = iisl.Count ()})
.OrderByDescending (iisl => iisl.NumberOfRequests)
.Dump("Request that didn't meet the SLA of 500 Milliseconds for 2012");


IISLogs.Where (iisl => iisl.Date.Value.Year == 2013 )
.Where (iisl => iisl.Time_taken > 500)
.GroupBy (iisl => iisl.Date.Value.DayOfYear)
.Select (iisl => new {Date =  new DateTime(2013,1,1).AddDays( iisl.Key - 1).ToShortDateString(), NumberOfRequests = iisl.Count ()})
.OrderByDescending (iisl => iisl.NumberOfRequests)
.Dump("Request that didn't meet the SLA of 500 Milliseconds for 2013");

