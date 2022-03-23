select
	DB_ID() as [db_id],
	DB_NAME() as [db_name],
	SC.[schema_id] as [schema_id],
	SC.name as [schema_name],
	O.[object_id],
	O.name as [object_name],
	'[' + @@SERVERNAME + '].[' + DB_NAME() + '].[' + SC.name + '].[' + O.name + ']' as object_name_full,
	O.type,
	O.type_desc,
	case (len(SN.base_object_name) - len(replace(SN.base_object_name, '].[', ''))) / 3
		when 3 then base_object_name
		else '[' + @@SERVERNAME + '].' + base_object_name
	end as base_object_name_full

from [sys].[objects] O
inner join [sys].[schemas] SC on SC.[schema_id] = O.[schema_id]
left join [sys].[synonyms] SN on SN.[object_id] = O.[object_id]