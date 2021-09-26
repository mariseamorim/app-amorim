<template>
  <div>
    <i :class="icon"></i>
    <!-- <a class="nav-link" :href="url">
      <slot></slot>
    </a> -->
    <router-link @click.native="$emit('hide-dropdown', false)" class="nav-link" :to="url">
      <slot></slot>
    </router-link>
  </div>
</template>

<script>
export default {
  name: 'NavLink',
  props: {
    icon: String,
    url: String
  },
  methods:{
    hello(){
      console.log("Hello")
    }
  }


}
</script>

<style scoped>

.nav-link{
  color: #fff;
  margin: 8px;
  cursor: pointer;
  font-size: 16px;
  transition: all 0.5s ease-in;
  padding: 0px;
}

.nav-link:hover{
  color: #4361ee;
}

@media screen and (max-width: 768px){
    
}


</style>