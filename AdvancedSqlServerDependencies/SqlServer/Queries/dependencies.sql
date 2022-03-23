select referencing_id,
	isnull(referenced_server_name, @@SERVERNAME) as referenced_server_name,
	isnull(referenced_database_name, DB_NAME()) as referenced_database_name,
	isnull(referenced_schema_name, 'dbo') as referenced_schema_name,
	referenced_entity_name,
	referenced_id
from [sys].[sql_dependencies]

