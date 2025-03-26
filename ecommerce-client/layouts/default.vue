<template>
  <div class="layout-wrapper d-flex flex-column min-vh-100">
    <Navbar />
    <main class="flex-grow-1">
      <slot />
    </main>
    <Footer />
  </div>
</template>

<script setup>
import Navbar from '@/components/Navbar.vue'
import Footer from '@/components/Footer.vue'
import { useCartStore } from '@/stores/cart'
import { onMounted } from 'vue'

const cartStore = useCartStore()

onMounted(() => {
  cartStore.loadCartFromStorage()
})
</script>
