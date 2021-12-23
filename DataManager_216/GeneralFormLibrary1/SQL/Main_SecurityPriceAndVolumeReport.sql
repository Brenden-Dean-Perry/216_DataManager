
Select 
	E.Name Entity,
	UA.Name UnderlyingAsset,
	C.Name [Contract],
	S.Id SecurityId,
	S.Ticker,
	ATy.Name AssetType,
	SP2.MinDate_Price,
	SP1.MaxDate_Price,
	SP4.MinDate_Price_Intraday,
	SP3.MaxDate_Price_Intraday,
	SV1.MinDate_Volume,
	SV2.MaxDate_Volume,
	SV3.MinDate_Volume_Intraday,
	SV4.MaxDate_Volume_Intraday
From [Security] S
Left Join [Contract] C on S.ContractId = C.Id
Left Join [UnderlyingAsset] UA on UA.Id = C.UnderlyingAssetId
Left Join AssetType ATy on ATy.Id = UA.AssetTypeId
Left Join [Entity] E on E.Id = UA.EntityId
Left Join (Select SP.SecurityId, max(SP.[Date]) MaxDate_Price From SecurityPrice SP Group by SP.SecurityId) SP1 on SP1.SecurityId = S.Id
Left Join (Select SP.SecurityId, min(SP.[Date]) MinDate_Price From SecurityPrice SP Group by SP.SecurityId) SP2 on SP2.SecurityId = S.Id
Left Join (Select SP.SecurityId, max(SP.[DateTime]) MaxDate_Price_Intraday From SecurityPriceIntraday SP Group by SP.SecurityId) SP3 on SP3.SecurityId = S.Id
Left Join (Select SP.SecurityId, min(SP.[DateTime]) MinDate_Price_Intraday From SecurityPriceIntraday SP Group by SP.SecurityId) SP4 on SP4.SecurityId = S.Id
Left Join (Select SV.SecurityId, min(SV.[Date]) MinDate_Volume From SecurityVolume SV Group by SV.SecurityId) SV1 on SV1.SecurityId = S.Id
Left Join (Select SV.SecurityId, max(SV.[Date]) MaxDate_Volume From SecurityVolume SV Group by SV.SecurityId) SV2 on SV2.SecurityId = S.Id
Left Join (Select SV.SecurityId, min(SV.[DateTime]) MinDate_Volume_Intraday From SecurityVolumeIntraday SV Group by SV.SecurityId) SV3 on SV3.SecurityId = S.Id
Left Join (Select SV.SecurityId, max(SV.[DateTime]) MaxDate_Volume_Intraday From SecurityVolumeIntraday SV Group by SV.SecurityId) SV4 on SV4.SecurityId = S.Id