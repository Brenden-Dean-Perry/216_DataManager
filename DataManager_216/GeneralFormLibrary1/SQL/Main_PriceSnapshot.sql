Select
	C.Name [Contract],
	S.Ticker, 
	SP.[Date], 
	SP4.[Value] [Close],
	SP.[Value] [Low], 
	SP2.[Value] [High],
	SP3.[Value] [PriorClose]
From SecurityPrice SP
	Left Join (Select * From SecurityPrice Where SecurityPriceTypeId = 3 ) SP2 on SP2.SecurityId = SP.SecurityId And SP.[Date] = Sp2.[Date]
	Left Join (Select * From SecurityPrice Where SecurityPriceTypeId = 1) SP4 on SP4.SecurityId = SP.SecurityId And SP.[Date] = Sp4.[Date]
	Left Join (Select * From SecurityPrice Where SecurityPriceTypeId = 1) SP3 on SP3.SecurityId = SP.SecurityId And dateadd(day,-1,SP.[Date]) = Sp3.[Date]
	Left Join [Security] S on S.Id = SP.SecurityId
	Left Join [Contract] C on C.Id = S.ContractId
Where SP.SecurityId in (43,44,45,46,2,3,4,5,6,7,8,9,10, 11,12,13,14) And SP.Date = Cast(dateadd(day,-1,getdate()) As date)
	And SP.SecurityPriceTypeId = 4;