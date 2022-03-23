select
	database_id,
	name as database_name,
	state_desc,
	case when has_dbaccess(name) > 0 then cast(1 as bit) else cast(0 as bit) end as [has_db_access],
	[compatibility_level],
	collation_name,
	recovery_model_desc
from [master].[sys].[databases]