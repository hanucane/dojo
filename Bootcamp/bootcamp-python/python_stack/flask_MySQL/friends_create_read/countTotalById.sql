SELECT COUNT(clients_id), b.first_name  
FROM leads a
LEFT JOIN clients b ON b.id = a.clients_id
GROUP BY clients_id;