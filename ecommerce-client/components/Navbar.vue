<template>
  <nav class="navbar navbar-expand-lg shadow-sm bg-white position-relative">
    
    <div class="container-fluid">
      <a class="navbar-brand text-black fw-bold" href="/">E-Commerce</a>
      <button
        class="navbar-toggler border-0"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarNav"
      >
        <span class="navbar-toggler-icon custom-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item"><a class="nav-link nav-link-custom" href="/">Ana Sayfa</a></li>
          <li class="nav-item"><a class="nav-link nav-link-custom" href="/products">Ürünler</a></li>
          <li class="nav-item"><a class="nav-link nav-link-custom" href="/categories">Kategoriler</a></li>
          <li class="nav-item"><a class="nav-link nav-link-custom" href="/about">Hakkımda</a></li>
        </ul>
      </div>
      <div class="cart-button-container ms-3">
        <Cart />
      </div>
    </div>

  </nav>
</template>
<script setup>
import { useCartStore } from '@/stores/cart'
import { ref } from 'vue'
import Cart from './Cart.vue'
import ChatBubble from './ChatBubble.vue'

const cartStore = useCartStore()
const showCart = ref(false)
</script>
<style scoped>
.cart-icon {
  font-size: 1.5rem;
  color: var(--color-yellow);
}

.cart-badge {
  position: absolute;
  top: 0;
  right: 0;
  transform: translate(50%, -50%);
  border-radius: 50%;
  padding: 0.25rem 0.45rem;
  font-size: 0.75rem;
}

.cart-panel {
  position: absolute;
  top: 100%;
  right: 10px;
  background: white;
  padding: 1rem;
  border-radius: 0.5rem;
  width: 300px;
  z-index: 999;
}
</style>
