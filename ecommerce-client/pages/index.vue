<template>
  <div>
    <!-- Hero -->
    <section class="hero bg-light p-5 text-center rounded shadow mb-5">
      <h1 class="display-5 fw-bold">En Yeni Ürünler, En Uygun Fiyatlarla!</h1>
      <p class="lead">E-ticaret sitemize hoş geldiniz. En popüler ürünleri hemen keşfedin.</p>
      <NuxtLink to="/products" class="btn btn-dark btn-lg mt-3">Ürünleri Gör</NuxtLink>
    </section>

    <!-- Popüler Kategoriler (component olarak ayırabiliriz) -->
    <section class="popular-categories mb-5">
      <h2 class="mb-4">Popüler Kategoriler</h2>
      <div class="row g-4">
        <div v-for="cat in categories" :key="cat.value" class="col-md-2 text-center">
          <div class="p-3 border rounded shadow-sm h-100 hover-shadow">
            <Icon :name="cat.icon" style="font-size: 2rem"/>
            <p class="mt-2">{{ cat.label }}</p>
          </div>
        </div>
      </div>
    </section>

    <!-- Yeni Ürünler -->
    <section>
      <h2 class="mb-4">Yeni Eklenen Ürünler</h2>
      <div class="row g-4">
        <ProductCard v-for="product in products" :key="product.id" :product="product" class="col-md-3" />
      </div>
    </section>
  </div>
</template>

<script setup>
import { onMounted, computed } from 'vue'
import ProductCard from '@/components/ProductCard.vue'
import categories from '@/constants/category'
import { useProductStore } from '@/stores/product'

const productStore = useProductStore()

// Ürünleri al
const products = computed(() => productStore.allProducts)

onMounted(() => {
  // Eğer daha önce yüklenmediyse
  if (productStore.allProducts.length === 0) {
    productStore.fetchProducts()
  }
})
</script>

<style scoped>
.hover-shadow:hover {
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
  transition: 0.3s;
}
</style>
