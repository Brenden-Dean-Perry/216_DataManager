Select
	E.Name [Entity],
	UA.Name [UnderlyingAsset],
	C.Name [Contract],
	S.Id SecurityId,
	S.Ticker,
	D.ActiveState, 
	Aty.Name AssetType,
	JT.Name DataImportJobType, 
	DS.Name DataSource,
	OT.Name DataImportOccuranceType,
	D.LastRunDateTime,
	D.PriceUpdatesNeeded,
	Case
	When Convert(date, LastRunDateTime) >= Convert(date, getdate() AT TIME ZONE 'UTC' AT TIME ZONE 'Pacific Standard Time') Then 'OK'
	Else 'Not Run'
	End [Status]
From DataImportJob D
Left Join [Security] S on S.Id = D.SecurityId
Left Join [Contract] C on C.Id = S.ContractId
Left Join [UnderlyingAsset] UA on UA.Id = C.UnderlyingAssetId
Left Join [Entity] E on E.Id = UA.EntityId
Left Join [DataImportJobType] JT on JT.Id = D.DataImportJobTypeId
Left Join [DataSource] DS on DS.Id = JT.DataSourceId
Left Join AssetType ATy on ATy.Id = UA.AssetTypeId
Left Join DataImportOccuranceType OT on OT.Id = D.DataImportOccuranceTypeId

