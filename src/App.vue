<template>
  <div id="app" class="app">

    <Header  >
      <template v-slot:logo>
        <h1 class="brand">Borges & Amorim</h1>

      </template>

      
      <template v-slot:navbar>
        <navbar :showBars="showBars" class="nav">
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/">Início</nav-link>
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/animais">Animais</nav-link>
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/registros">Registro</nav-link>
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/">Historico</nav-link>
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/clientes">Clientes</nav-link>
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/produtos">Produtos</nav-link>
          <nav-link @hide-dropdown="hideDropDown" class="link" url="/fornecedores">Fornecedores</nav-link>
        </navbar>

        <i @click="toggleBars" 
        class="fas bars"
        :class="{'fa-times':showBars, 'fa-bars':!showBars}"></i>

        
      </template>

      

    </Header>

    <router-view/>
  </div>
</template>

<script>
import Header from './components/Header.vue'
import Navbar from './components/Navbar.vue'
import NavLink from './components/NavLink.vue'
export default {
  name: 'App',
  components:{
    Header,
    Navbar,
    NavLink
    
  },
  data(){
    return {
      showBars: false
    }
  },
  methods:{
    toggleBars(){
      this.showBars = !this.showBars
    },
    hideDropDown(state){
      this.showBars = state
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Akaya+Telivigala&family=Montserrat&display=swap');
*{
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
body, html {height:100%;}
body{
  font-family: "Montserrat", sans-serif;
  line-height: 1.6;
  color: #333;
  height: 100% !important;
}
.v-application--wrap {
    min-height: 0vh !important;
  }
ul{
  list-style-type: none;
}

a{
  color: #333;
}
li, a, button {
  font-weight: 500;
  text-decoration: none;
}
img{
  width: 100%;
}
h1,h2{
  font-weight: 300;
  margin: 5px 0
}
.nav{
  display: flex;
}
.brand{
  color: #fff;
  font-family: 'Akaya Telivigala', cursive;
  font-size: 38px;
}
.uer{
  color: #4361ee;
}
.bars{
  color:#fff;
  font-size:26px;
  cursor: pointer;
  display: none;
}
/* Smartphones (portrait and landscape) ---------- */
@media screen and (min-width: 320px) and (max-width: 480px){
    /* styles */
    
}
/* Smartphones (portrait) ---------- */
@media screen and (max-width: 320px){
    /* styles */
}
/* Smartphones (landscape) ---------- */
@media screen and (min-width: 321px){
    /* styles */
  
}
@media screen and (max-width: 768px){
  .bars{
    display:block;
  }
    .link{
      padding: 20px 0;
    }
}
/* Tablets, iPads (portrait and landscape) ---------- */
@media screen and (min-width: 768px) and (max-width: 1024px){
    /* styles */
    
}
/* Tablets, iPads (portrait) ---------- */
@media screen and (min-width: 768px){
    /* styles */
    
  
    
}
/* Tablets, iPads (landscape) ---------- */
@media screen and (min-width: 1024px){
    /* styles */
}
/* Desktops and laptops ---------- */
@media screen and (min-width: 1224px){
    /* styles */
}
/* Large screens ---------- */
@media screen and (min-width: 1824px){
    /* styles */
}
</style>