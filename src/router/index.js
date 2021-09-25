import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/animais',
    name: 'CadastroAnimais',
    component: () => import(/* webpackChunkName: "about" */ '../views/CadastroAnimais.vue')
  },
  {
    path: '/registros',
    name: 'Registros',
    component: () => import(/* webpackChunkName: "about" */ '../views/Registros.vue')
  },
  {
    path: '/clientes',
    name: 'CadastroClientes',
    component: () => import(/* webpackChunkName: "about" */ '../views/CadastroClientes.vue')
  },
  {
    path: '/produtos',
    name: 'CadastroClientes',
    component: () => import(/* webpackChunkName: "about" */ '../views/Produtos.vue')
  },
  {
    path: '/fornecedores',
    name: 'CadastroFornecedores',
    component: () => import(/* webpackChunkName: "about" */ '../views/Fornecedores.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
