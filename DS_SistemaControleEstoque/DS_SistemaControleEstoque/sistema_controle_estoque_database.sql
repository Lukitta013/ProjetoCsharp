drop database if exists briet_sitema_controle_estoque;
create database briet_sitema_controle_estoque;

use briet_sitema_controle_estoque;

create table tb_login (
	log_usuario varchar(25) primary key,
    log_senha varchar(8) not null,
    log_nome varchar(30) not null,
    log_ult_atualizacao timestamp not nulL
);

insert into tb_login (log_usuario, log_senha, log_nome, log_ult_atualizacao)
values ('rafael', '123456', 'Rafael Briet', current_timestamp);

create table tb_produto (
	prod_codigo varchar(5) primary key,
    prod_descricao varchar(30) not null,
    prod_qtd_estoque decimal(5,2) not null,
    prod_estoque_min decimal(5,2) not null,
    prod_unidade char(2) not null,
    prod_locacao varchar(3) not null,
    prod_preco_custo decimal(6,2) not null,
    prod_margem_lucro decimal(4,2) not null,
    prod_ultima_atualizacao timestamp default current_timestamp on update current_timestamp
);

insert into tb_produto (prod_codigo, prod_descricao, prod_qtd_estoque, prod_estoque_min, prod_unidade, prod_locacao, prod_preco_custo, prod_margem_lucro)
values ("100", "Molho de Tomate", 100.0, 20.0, "UN", "B1", 0.95, 35.0);

INSERT INTO tb_produto (prod_codigo, prod_descricao, prod_qtd_estoque, prod_estoque_min, prod_unidade, prod_locacao, prod_preco_custo, prod_margem_lucro)
VALUES ("101", "Arroz 5kg", 50.0, 15.0, "UN", "A1", 26.20, 20.0);

INSERT INTO tb_produto (prod_codigo, prod_descricao, prod_qtd_estoque, prod_estoque_min, prod_unidade, prod_locacao, prod_preco_custo, prod_margem_lucro)
VALUES ("102", "Feijão 1kg", 5.0, 10.0, "UN", "A2", 6.23, 20.0);

create table tb_cliente (
	cli_rg varchar(15) primary key,
	cli_nome varchar(30) not null,
	cli_endereco varchar(40) not null,
	cli_cidade Varchar(20) not null,     
	cli_uf char(2) not null,
	cli_fone varchar(11) not null,
	cli_ult_Atualizacao timestamp default current_timestamp on update current_timestamp
);

create table tb_movimentacao (
    mov_id int primary key not null auto_increment,
    mov_tipo varchar(16) not null,
    mov_data_movimentacao datetime default current_timestamp,
    mov_log_usuario varchar(25) not null,
    mov_cli_rg varchar(15),
    foreign key (mov_log_usuario) references tb_login(log_usuario),
    foreign key (mov_cli_rg) references tb_cliente(cli_rg)
);

create table tb_movimentacao_saida (
    mov_saida_id int primary key not null auto_increment,
    mov_saida_quantidade int not null,
    mov_saida_valor_unitario decimal(6,2) not null,
    mov_id int not null,
    prod_id varchar(5) not null,
    foreign key (mov_id) references tb_movimentacao(mov_id),
    foreign key (prod_id) references tb_produto(prod_codigo)
);

create table tb_movimentacao_entrada (
    mov_entrada_id int primary key not null auto_increment,
    mov_entrada_quantidade int not null,
    mov_entrada_preco_custo decimal(6,2) not null,
    mov_id int not null,
    prod_id varchar(5) not null,
    foreign key (mov_id) references tb_movimentacao(mov_id),
    foreign key (prod_id) references tb_produto(prod_codigo)
);