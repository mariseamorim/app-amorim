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
    height:100%;
    overflow: hidden;
    padding: 0px
}
.header a {
  float: left;
  color: black;
  text-align: center;
  padding: 12px;
  text-decoration: none;
  font-size: 18px; 
  line-height: 25px;
  border-radius: 4px;
}

@media screen and (max-width: 768px){
     .header a {
    float: none;
    display: block;
    text-align: left;
  }
  .header-right {
    float: none;
  }
 
}


</style>