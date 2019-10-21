create database tarefas
use tarefas

create table registros_tarefas(
	id_tarefa int identity(1,1) primary key not null,
	nome_tarefa varchar(50),
	descricao_tarefa varchar(100),
	data_tarefa DateTime
);

insert into registros_tarefas(nome_tarefa, descricao_tarefa, data_tarefa) values ('Limpar a casa', 'Passar pano na casa', '2019-22-10'), 
('Limpar o carro', 'Deixar o carro brilhando', '2019-21-10')