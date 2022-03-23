;with au_cte as
(
	select container_id, sum(total_pages) as total_pages
	from sys.allocation_units
	group by container_id
)
SELECT s.name AS [schema_name], o.name as table_name, sum(ddps.row_count) as row_counts, SUM(a.total_pages) * 8 AS total_space_kb
FROM sys.indexes AS i
INNER JOIN sys.objects AS o ON i.OBJECT_ID = o.OBJECT_ID
INNER JOIN sys.schemas s on s.schema_id = o.schema_id
INNER JOIN sys.dm_db_partition_stats AS ddps ON i.OBJECT_ID = ddps.OBJECT_ID
	AND i.index_id = ddps.index_id 
INNER JOIN au_cte a ON ddps.partition_id = a.container_id
WHERE i.index_id < 2  AND o.is_ms_shipped = 0 AND o.type_desc = 'USER_TABLE'
GROUP BY s.name, o.name

/*
SELECT 
    t.NAME AS table_name,
    s.Name AS [schema_name],
    p.rows AS row_counts,
    SUM(a.total_pages) * 8 AS total_space_kb, 
    SUM(a.used_pages) * 8 AS used_space_kb, 
    (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS unused_space_kb
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
LEFT OUTER JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
WHERE 
    t.is_ms_shipped = 0
GROUP BY 
    t.Name, s.Name, p.Rows
*/