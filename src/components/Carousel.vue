<template>
    <v-carousel >
        <v-carousel-item
            v-for="(item,i) in fotos"
            :key="i"
            :src="item.src" ></v-carousel-item>
    </v-carousel>
</template>

<script>

export default {
	data() {
		return {
			fotos: [
				{src: require('@/assets/img.jpg')},
				{src: require('@/assets/20201017_181411.jpg')},
				{src: require('@/assets/20201017_181403.jpg')},
				{src: require('@/assets/flor.jpg')},
				{src: require('@/assets/cachorro.jpg')},
				{src: require('@/assets/cachorro1.jpg')},
				{src: require('@/assets/casa.jpg')},
				{src: require('@/assets/coco.jpg')},
				{src: require('@/assets/jaca.jpg')},
				{src: require('@/assets/mang.jpg')},
				{src: require('@/assets/porco.jpg')},
				{src: require('@/assets/porco1.jpg')},
				{src: require('@/assets/portao.jpg')},
				{src: require('@/assets/portao1.jpg')},
				{src: require('@/assets/portao2.jpg')},
				{src: require('@/assets/portao3.jpg')},
				{src: require('@/assets/varanda.jpg')}


	
	
			]
		}
	}
}
</script>

<style>
.v-carousel .v-window-item {
  position: absolute;
  top: 0;
  width: 100%;
}

.v-carousel-item {
  height: auto;
}

</style>