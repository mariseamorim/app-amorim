<template>
	<div id="app">
		<h1>Cadastrar Animal</h1>
		<div class="conteudo">
			<form class="painel" v-if="!enviado">
				<div class="cabecalho">Formulário</div>
				<Rotulo nome="Nome" >
					<input type="text" v-model="animal.nome">
				</Rotulo>
				<Rotulo nome="Data Nascimento">
					<input type="date" v-model="animal.datanascimento">
				</Rotulo>
				<Rotulo nome="Nome da Mãe">
					<input type="text" v-model="animal.nomemae">
				</Rotulo>
                <Rotulo nome="IGT">
					<input type="text" v-model="animal.igt">
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
	name: 'app',
	components: { Rotulo },
	data(){
		return{
			mensagem: '',
			caracteristicas: [],
			produto: 'web',
			prioridade: 1,
			prioridades:[
				{codigo: 1 , nome: 'Baixa'},
				{codigo: 2, nome: 'Moderada'},
				{codigo: 3, nome: 'Alta'}
			],
			animal:{
				nome: '',
				datanascimento: null,
				nomemae: null,
                gti: null
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

#app {
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

#app form button {
	float: right;
	margin: 10px 0px;
	padding: 10px 20px;
	font-size: 1.4rem;
	border-radius: 5px;
	color: #FFF;
	background-color: #2196F3;
}

#app h1 {
	font-weight: 200;
	margin: 20px;
	padding: 0;
}

.mr-4 {
	margin-right: 40px;
}
</style>
