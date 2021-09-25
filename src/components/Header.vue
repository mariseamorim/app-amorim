<template>
  <div class="header" >
    <slot name="logo"></slot>
    <slot name="navbar"></slot>
  </div>
</template>

<script>


export default {
    name: 'Header',
    components:{
        
    }
}
</script>

<style scoped>

.header{
    
    background-color: black;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

@media screen and (max-width: 768px){
   
 
}


</style>