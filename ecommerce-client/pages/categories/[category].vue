
<template>
    <div class="container py-5">
      <h2 class="mb-4">{{ route.params.category }} Kategorisindeki Ürünler</h2>
      <div class="row g-4">
        <ProductCard
          v-for="product in categoryProducts"
          :key="product.id"
          :product="product"
          class="col-md-3"
        />
      </div>
    </div>
  </template>
  
  <script setup>
  import { useRoute } from 'vue-router'
  import { useProductStore } from '@/stores/product'
  import ProductCard from '@/components/ProductCard.vue'
  import { onMounted } from 'vue'
  import categories from '@/constants/category'
  
  const route = useRoute()
  const productStore = useProductStore()
  //kategoriye göre ürün detay getirme urlden param değeri alınıyor
  onMounted(() => {
    const selected = categories.find(cat => cat.label === route.params.category)
    if (selected) {
      productStore.fetchProductsByCategory(selected.value)
    }
  })
  
  const categoryProducts = computed(() => productStore.categoryProducts)
  </script>
  