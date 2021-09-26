<template>
	<div id="prod">
		<h1>Cadastrar Produtos</h1>
		<div class="conteudo">
			<form class="painel" v-if="!enviado">
				<div class="cabecalho">Formulário</div>
				<Rotulo nome="Produto" >
					<input type="text" v-model="produto.nome">
				</Rotulo>
				<Rotulo nome="Quantidade">
					<input type="text" v-model="produto.quantidade">
				</Rotulo>
                <Rotulo nome="Valor Unitario">
					<input type="number" v-model="produto.valorunitario">
				</Rotulo>
				<Rotulo nome="Quantidade Mensal">
					<input type="text" v-model="produto.quantidademensal">
				</Rotulo>
				<Rotulo nome="Valor Total">
					<input type="text" v-model="produto.valortotal">
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
	name: 'prod',
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
			produto:{
				nome: '',
				quantidade: null,
				valorunitario: null,
                quantidademensal: null,
				valortotal: null,

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

#prod {
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

#prod form button {
	float: right;
	margin: 10px 0px;
	padding: 10px 20px;
	font-size: 1.4rem;
	border-radius: 5px;
	color: #FFF;
	background-color: #2196F3;
}

#prod h1 {
	font-weight: 200;
	margin: 20px;
	padding: 0;
}

.mr-4 {
	margin-right: 40px;
}
</style>
