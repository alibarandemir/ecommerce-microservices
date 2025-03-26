
<!-- components/CartDropdown.vue -->
<template>
  <div class="position-relative">
    <button class="nav-link nav-link-custom d-flex align-items-center position-relative" @click="toggleCart">
      <Icon name="ph:shopping-cart-fill" class="me-1 cart-icon" filled />
      <span v-if="cartStore.cartCount > 0" class="badge bg-warning text-dark cart-badge">
        {{ cartStore.cartCount }}
      </span>
    </button>

    <div v-if="showCart" class="cart-panel shadow">
      <h5 class="mb-3">Sepetim</h5>
      <div v-if="cartStore.cartCount === 0">Sepetiniz boş</div>
      <ul v-else class="list-group mb-3">
        <li v-for="item in cartStore.cartItems" :key="item.id" class="list-group-item d-flex justify-content-between align-items-center">
          <div>
            {{ item.name }} (x{{ item.quantity }})
          </div>
          <div>
            <span class="me-2">{{ item.price * item.quantity }} ₺</span>
            <button class="btn btn-sm btn-danger" @click="cartStore.removeFromCart(item.id)">Sil</button>
          </div>
        </li>
      </ul>
      <div class="d-flex justify-content-between align-items-center">
        <strong>Toplam: {{ cartStore.cartTotal }} ₺</strong>
        <button class="btn btn-outline-secondary btn-sm" @click="cartStore.clearCart">Sepeti Boşalt</button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useCartStore } from '@/stores/cart'

const showCart = ref(false)
const cartStore = useCartStore()

const toggleCart = () => {
  showCart.value = !showCart.value
}
</script>

<style scoped>
.cart-icon {
  font-size: 1.6rem;
  color: var(--color-yellow);
}

.cart-badge {
  position: absolute;
  top: 4px;
  right: 0;
  font-size: 0.7rem;
  padding: 2px 6px;
  border-radius: 50%;
}

.cart-panel {
  position: absolute;
  top: 100%;
  right: 0;
  background: #fff;
  width: 300px;
  padding: 1rem;
  border-radius: 0.5rem;
  z-index: 9999;
}
</style>