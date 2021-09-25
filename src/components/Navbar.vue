<template>
  <nav>
      <ul class="nav-links" :class="{'visible': showBars, 'hide':!showBars}">
          <slot ></slot>
      </ul>
  </nav>
</template>

<script>
export default {
    name: 'Navbar',
    props:{
        showBars: Boolean
    },
    

}
</script>

<style scoped>

.nav-links{
    display: flex;
}

@media screen and (max-width: 768px){
   
    nav .nav-links{
        align-items: center;
        float: none;
        position: fixed;
        z-index: 9;
        left: 0;
        right: 0;
        top: 90px;
        bottom: 0;
        width: auto;
        height: auto;
        flex-direction: column;
        background-color: rgba(0, 0, 0, 0.9);
        overflow: hidden;
        transition: all .6s ease-in-out
        
    }

    .visible{
        opacity: 1;
    }

    .hide{
        opacity: 0;
    }
    
}

</style>