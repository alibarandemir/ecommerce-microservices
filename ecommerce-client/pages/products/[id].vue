<template> 
    <div class="container py-5">
      <div v-if="product" class="row">
        <div class="col-md-6">
          <img :src="product.imageUrl" :alt="product.name" class="img-fluid rounded shadow" />
        </div>
        <div class="col-md-6">
          <h2>{{ product.name }}</h2>
          <p class="text-muted">{{ product.category }}</p>
          <p class="fw-bold fs-4">{{ product.price }} ₺</p>
  
          <div class="mb-3">
            <label for="quantity" class="form-label">Adet</label>
            <input
              v-model.number="quantity"
              type="number"
              min="1"
              id="quantity"
              class="form-control"
              style="max-width: 150px;"
            />
          </div>
  
          <button class="btn btn-dark" @click="addToCart(product)">Sepete Ekle</button>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import { useRoute } from 'vue-router'
  import { onMounted, ref } from 'vue'
  import { useProductStore } from '@/stores/product'
  import { useCartStore } from '@/stores/cart'
  
  const route = useRoute()
  const productStore = useProductStore()
  const cartStore = useCartStore()
  
  const product = ref(null)
  const quantity = ref(1)
  
  onMounted(async () => {
    product.value = await productStore.fetchProductById(route.params.id)
  })
  
  const addToCart = (product) => {
    cartStore.addToCart(product, quantity.value)
    useNuxtApp().$toast.success('Ürün sepete eklendi!')
  }
  </script>
  