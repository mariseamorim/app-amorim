<template>
	<v-app>
		
    <div>
      <v-content>
			<Carousel />
		</v-content>

		<Footer />
    </div>
		
	</v-app>
	
</template>

<script>
import Carousel from '@/components/Carousel.vue'
import Footer from '@/components/Footer.vue'

export default {
	components: { Carousel, Footer }
}
</script>
<style scoped>
.v-application--wrap {
    min-height: 0vh !important;
  }
</style>