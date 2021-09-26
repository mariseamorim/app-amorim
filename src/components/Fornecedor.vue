<template>
	<div id="fornec">
		<h1>Cadastrar Fornecedor</h1>
		<div class="conteudo">
			<form class="painel" v-if="!enviado">
				<div class="cabecalho">Formulário</div>
				<Rotulo nome="ID" >
					<input type="text" v-model="fornecedor.id">
				</Rotulo>
				<Rotulo nome="Nome" >
					<input type="text" v-model="fornecedor.nome">
				</Rotulo>
				<Rotulo nome="Data" >
					<input type="date" v-model="fornecedor.data">
				</Rotulo>
				<Rotulo nome="Produto">
					<input type="text" v-model="fornecedor.produto">
				</Rotulo>
				<Rotulo nome="Quantidade">
					<input type="text" v-model="fornecedor.quantidade">
				</Rotulo>
                <Rotulo nome="Valor">
					<input type="text" v-model="fornecedor.valor">
				</Rotulo>
				<hr>
				<button @click.prevent="enviar">Enviar</button>
			</form>
			<div class="painel" v-else>
				<div class="cabecalho">Resultado</div>
				<Rotulo nome="Nome">
					<span>{{animal.nome}}</span>
				</Rotulo>
				<Rotulo nome="Data de Nascimento">
					<span>{{animal.datanascimento}}</span>
				</Rotulo>
				<Rotulo nome="Nome da Mãe">
					<span>{{animal.nomemae}}</span>
				</Rotulo>
			</div>
		</div>
	</div>
</template>

<script>
import Rotulo from './Rotulo.vue'


export default {
	name: 'fornec',
	components: { Rotulo },
	data(){
		return{
			mensagem: '',
			caracteristicas: [],
			prioridade: 1,
			prioridades:[
				{codigo: 1 , nome: 'Baixa'},
				{codigo: 2, nome: 'Moderada'},
				{codigo: 3, nome: 'Alta'}
			],
			fornecedor:{
				id: null,
				nome: '',
				data: null,
				produto: null,
				quantidade: null,
                valor: null
			},
			enviado: false
		}
	},
	methods:{
		enviar(){
			this.enviado = true;
		}
	}
}
</script>

<style>

body {
	background-color: #ECECEC;
}

#fornec {
	font-family: 'Avenir', Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	text-align: center;
	color: #2c3e50;

	display: flex;
	flex-direction: column;
}

.conteudo {
	display: flex;
}

.painel {
	flex: 1;
	background: #FFF;
	margin: 0px 10px;
	padding: 20px;
	border: 1px solid #AAA;
	border-radius: 5px;
}

.painel .cabecalho {
	width: 100%;
	background-color: #DDD;
	padding: 10px 0px;
	border-radius: 5px;
	font-size: 1.4rem;
}

#fornec form button {
	float: right;
	margin: 10px 0px;
	padding: 10px 20px;
	font-size: 1.4rem;
	border-radius: 5px;
	color: #FFF;
	background-color: #2196F3;
}

#fornec h1 {
	font-weight: 200;
	margin: 20px;
	padding: 0;
}

.mr-4 {
	margin-right: 40px;
}
</style>
