CREATE DATABASE dbgraacc
-- Cria o usuario
create user admin with encrypted password 'admin';
-- Da a grant para o banco de dados 
grant all privileges on database dbgraacc to admin;

--connectionString
User ID=admin;Password=admin;Host=172.31.3.253;Port=5432;Database=dbgraacc ;
Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;