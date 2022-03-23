select server_id, data_source, is_linked, product, provider
from [sys].[servers]
where provider <> 'MSOLAP'