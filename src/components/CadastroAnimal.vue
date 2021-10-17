<template>
	<div id="animais">
		<h1>Cadastrar Animal</h1>
		<v-alert dismissible type="success"  color="green" v-for="mensagem in mensagens"
					:key="mensagem.texto">{{ mensagem.texto }}</v-alert>
		<div class="conteudo">
			<form class="painel" >
				<div class="cabecalho">Formulário</div>
					
				<Rotulo nome="Nome" >
					<input type="text" v-model="animal.nome">
				</Rotulo>
				<Rotulo nome="Data Nascimento">
					<input type="date" v-model="animal.dataNascimento">
				</Rotulo>
				<Rotulo nome="Nome da Mãe">
					<input type="text" v-model="animal.nomeMae">
				</Rotulo>
                <Rotulo nome="GTA">
					<input type="text" v-model="animal.gta">
				</Rotulo>
				<hr>
				<button class="enviar" @click.prevent="enviar">Enviar</button>
			</form>
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
			mensagens: [],
			animal:{
				nome: '',
				dataNascimento: null,
				nomeMae: null,
                gti: null
			},
			enviado: false
		}
	},
	methods:{
		limpar() {
			this.animal = {},
			this.mensagens = []
		},
		enviar(){
			this.enviado = true;
			this.$http.post(`/v1/animal/cadastrar`, this.animal)
				.then((resp) => {
					this.limpar()
					this.$swal({icon: 'success',title: 'Legal!',text: `Cadastro do animal nome:${resp.data.data.nome} id:${resp.data.data.id} realizado com sucesso!`,});
					this.enviado = true;
					
				})
		}
	}
}
</script>

<style>

body {
	background-color: #ECECEC;
}

#animais {
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

.enviar {
	float: right;
	margin: 10px 0px;
	padding: 10px 20px;
	font-size: 1.4rem;
	border-radius: 5px;
	color: #FFF;
	background-color: #080808;
}

#animais h1 {
	font-weight: 200;
	margin: 20px;
	padding: 0;
}

.mr-4 {
	margin-right: 40px;
}
</style>
