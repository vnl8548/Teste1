drop table aluno
create table aluno
(
	id int primary key identity,
	nome varchar(40),
	cpf varchar(20),
	rg varchar(20),
	dataNascimento date,
	idCurso int foreign key references curso(id)
)

select * from aluno

INSERT into aluno(nome, cpf, rg, dataNascimento) VALUES ('nome','5615156', '155615','10/10/1910');
insert into curso(nome, periodo) values('biologia', '1');