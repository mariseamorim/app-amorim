<template>
	<div id="registro">
		<h1>Ficha Animal</h1>
		<div class="conteudo">
			<div class="search" v-if="!pesquisado">
				<form class="class panel">
				<Rotulo nome="Pesquisar animal" >
					<input type="search" v-model="termoPesquisado" placeholder="Pesquise o animal por nome id ou gta">
					<button class="enviar" @click.prevent="pesquisar" style="margin:0px 0px 0px 15px">Pesquisar</button>
				</Rotulo>
				</form>
			</div>
			<form class="painel" v-if="pesquisado">	
				<div class="cabecalho">Formulário</div>
				<Rotulo nome="ID" >
					<input type="number" v-model="animal.id">
				</Rotulo>
				<Rotulo nome="Nome" >
					<input type="text" v-model="animal.nome">
				</Rotulo>
				<Rotulo nome="Nome da Mãe">
					<input type="text" v-model="animal.nomemae">
				</Rotulo>
				<Rotulo nome="Data Nascimento">
					<input id="datePicker" type="date" v-model="animal.inicioTratamento">
				</Rotulo>
				{{animal.inicioTratamento}}
					<Rotulo nome="GTA">
					<input type="text" v-model="animal.gta">
				</Rotulo>
				<Rotulo nome="Qtd de Leite dia">
					<input type="number" v-model="animal.quantidadeLeite">
				</Rotulo>
				<Rotulo nome="Data Inicio" >
					<input type="date" v-model="animal.dataInicio">
				</Rotulo>
				<Rotulo nome="Data Fim" >
					<input type="date" v-model="animal.dataFim">
				</Rotulo>
				<Rotulo nome="Tratamento" >
					<Escolha v-model="tratamento"/>
				</Rotulo>
				<div class="panel" v-if="tratamento">
					<Rotulo nome="Inicio do Tratamento" >
					<input type="date" v-model="animal.inicioTratamento">
					</Rotulo>
					<Rotulo nome="Fim do Tratamento" >
					<input type="date" v-model="animal.fimTratamento">
					</Rotulo>
					<Rotulo nome="Medicamento" >
					<input type="text" v-model="animal.medicamento">
					</Rotulo>
					<Rotulo nome="Lote" >
					<input type="text" v-model="animal.lote">
					</Rotulo>
					<Rotulo nome="Fabricante" >
					<input type="text" v-model="animal.fabricante">
					</Rotulo>
					<Rotulo nome="Campo Descrição" >
					<input type="text" v-model="animal.descricao">
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
				<button class="voltar" @click="voltar">Voltar</button>
				<button class="enviar" v-if="!enviado" @click.prevent="enviar">Salvar</button>
			</form>
		</div>
	</div>
</template>

<script>
import Rotulo from './Rotulo.vue'
import Escolha from './Escolha.vue'
import moment from 'moment'


export default {
	name: 'app',
	components: { Rotulo,Escolha  },
	data(){
		return{
			mensagensError: [],
			mensagensSucess: [],
			animal:{
				id: 0,
				nome: '',
				nomemae: null,
				dataNascimento: "26/09/2021",
                gta: null,
				quantidadeLeite: null,
				dataInicio: null,
				dataFim:null,
				possuiTratamento: false,
				inicioTratamento: null,
				fimTratamento: null,
				medicamento: '',
				lote: '',
				fabricante: '',
				descricao: '',
				baixa:0,

			},
			baixa: 1,
			baixas:[
				{codigo: 1 , nome: 'Morte'},
				{codigo: 2, nome: 'Venda'},
				{codigo: 3, nome: 'Consumo'}
			],
			tratamento:false,
			baixaAnimal:false,
			termoPesquisado : null,
			pesquisado: false,
			enviado:false,
		}
	},
	methods:{
		limpar() {
			this.animal = {},
			this.mensagensSucess = []
		},
        formattedDate(date) {
                return moment(date).format('yyyy-MM-DD');
        },
     
		enviar(){
			this.$http.post(`/v1/animal/alterar`, this.animal)
				.then((resp) => {
					this.$swal({icon: 'success',title: 'Legal!',text: `Alteração do cadastro do animal nome:${resp.data.data.nome} id:${resp.data.data.id} realizado com sucesso!`,});
					this.enviado = true;
					
					
				}).catch((e)=>{
					console.log(e)
				})
			
		},
		pesquisar(){
			var command={
				termoPesquisado: this.termoPesquisado
			}
			this.$http.post(`/v1/animal/pesquisar`, command)
				.then((res) => {
					if(!res.data.success){
						return this.mensagensError.push({
						texto: 'Animal não encontrado!',
						})
					}
					this.mensagensError = []
					this.termoPesquisado = null
					this.pesquisado = true;
					this.popular(res.data);	
					
				}).catch((e)=>{
					console.log(e)
				})
		},
		popular(resp){
			this.animal.id = resp.data.id;
			this.animal.nome = resp.data.nome;
			this.animal.gta = resp.data.gta;
			this.animal.nomemae = resp.data.nomeMae;
			if(resp.data.dateNascimento != null){
				var date = this.formattedDate(resp.data.dateNascimento)
				this.animal.dataNascimento = date;
				console.log(date)
				console.log(this.animal.dataNascimento)
			
			}
		
			this.animal.dataInicio = resp.data.dataInicio;
			this.animal.dataFim = resp.data.dataFim;
			this.baixa = resp.data.baixa;
		},
		voltar(){
			this.limpar();
			this.pesquisado = false;
			this.enviado = false;
		}
	}
}
</script>

<style>

body {
	background-color: #ECECEC;
}

#registro {
	font-family: 'Avenir', Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	text-align: center;
	color: #2c3e50;

	display: flex;
	flex-direction: column;
	overflow: auto !important;
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
.search{
	background: #FFF;
	border: 1px solid #AAA;
	border-radius: 5px;
	margin: auto;
    width: 50%;
    padding: 10px;
	margin-bottom: 25px;
}
.enviar {
	float: right;
	margin: 10px 0px;
	padding: 10px 20px;
	font-size: 1.4rem;
	border-radius: 5px;
	color: #FFF;
	background-color: #101111;
}

.voltar {
	float: left;
	margin: 10px 5px;
	padding: 10px 20px;
	font-size: 1.4rem;
	border-radius: 5px;
	color: #FFF;
	background-color: #7a8080;
}

#registro h1 {
	font-weight: 200;
	margin: 20px;
	padding: 0;
}

.mr-4 {
	margin-right: 40px;
}
</style>
