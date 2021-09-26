<template>
	<div id="app">
		<h1>Ficha Animal</h1>
		<div class="conteudo">
			<form class="painel" v-if="!enviado">
				<div class="cabecalho">Formulário</div>
				<Rotulo nome="Nome" >
					<input type="text" v-model="animal.nome">
				</Rotulo>
				<Rotulo nome="ID" >
					<input type="number" v-model="animal.id">
				</Rotulo>
					<Rotulo nome="GTA">
					<input type="text" v-model="animal.gta">
				</Rotulo>
				<Rotulo nome="Nome da Mãe">
					<input type="text" v-model="animal.nomemae">
				</Rotulo>
				<Rotulo nome="Qtd de Leite dia">
					<input type="number" v-model="animal.qtdleitedia">
				</Rotulo>
				<Rotulo nome="Data Inicio" >
					<input type="date" v-model="animal.datainicio">
				</Rotulo>
				<Rotulo nome="Data Fim" >
					<input type="date" v-model="animal.datafim">
				</Rotulo>
				<Rotulo nome="Tratamento" >
					<Escolha v-model="tratamento"/>
				</Rotulo>
				<div class="panel" v-if="tratamento">
					<Rotulo nome="Inicio do Tratamento" >
					<input type="date" v-model="animal.iniciotratamento">
					</Rotulo>
					<Rotulo nome="Fim do Tratamento" >
					<input type="date" v-model="animal.fimtratamento">
					</Rotulo>
					<Rotulo nome="Medicamento" >
					<input type="text" v-model="animal.medicamento">
					</Rotulo>
					<Rotulo nome="Lote" >
					<input type="text" v-model="animal.lote">
					</Rotulo>
					<Rotulo nome="Fabricante" >
					<input type="text" v-model="animal.lote">
					</Rotulo>
					<Rotulo nome="Campo Descrisao" >
					<input type="text" v-model="animal.campodescrisao">
					</Rotulo>
				</div>
				
				<Rotulo nome="Ocorreu baixa?" >
					<Escolha v-model="baixaAnimal"/>
				</Rotulo>
				<div v-if="baixaAnimal">
					<Rotulo nome="Baixa" >
					<select name="" id="" v-model="baixa">
						<option v-for="baixa in baixas"
						:value="baixa.codigo"
						:key="baixa.codigo">{{baixa.codigo}}-{{baixa.nome}}</option>
					</select>
				</Rotulo>
				</div>
				
				<hr>
				<button @click.prevent="enviar">Enviar</button>
			</form>
			<div class="painel" v-else>
				<div class="cabecalho">Resultado</div>
				<Rotulo nome="Nome">
					<span>{{animal.nome}}</span>
				</Rotulo>
				<Rotulo nome="Data de Nascimento">
					<span>{{animal.qtdleite}}</span>
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
import Escolha from './Escolha.vue'

export default {
	name: 'app',
	components: { Rotulo,Escolha },
	data(){
		return{
			mensagem: '',
			animal:{
				nome: '',
				qtdleite: null,
				nomemae: null,
                gta: null
			},
			enviado: false,
			baixa: 1,
			baixas:[
				{codigo: 1 , nome: 'Morte'},
				{codigo: 2, nome: 'Venda'},
				{codigo: 3, nome: 'Consumo'}
			],
			tratamento:false,
			baixaAnimal:false,
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
