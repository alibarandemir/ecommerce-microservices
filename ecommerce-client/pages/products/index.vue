<template>
    <div class="container py-5">
      <h2 class="mb-4">Ürünler</h2>
  
      <!-- Filtreleme alanı şuanlık sadece clientte yapılıyor filtreleme -->
      <div class="row g-3 mb-4">
        <div class="col-md-3">
          <select v-model="selectedCategory" class="form-select">
            <option value="">Tüm Kategoriler</option>
            <option v-for="cat in categories" :key="cat.value" :value="cat.label">
              {{ cat.label }}
            </option>
          </select>
        </div>
  
        <div class="col-md-3">
          <select v-model="priceOrder" class="form-select">
            <option value="">Sıralama</option>
            <option value="asc">Fiyat: Artan</option>
            <option value="desc">Fiyat: Azalan</option>
          </select>
        </div>
  
        <div class="col-md-2">
          <input v-model.number="minPrice" type="number" class="form-control" placeholder="Min Fiyat" />
        </div>
  
        <div class="col-md-2">
          <input v-model.number="maxPrice" type="number" class="form-control" placeholder="Max Fiyat" />
        </div>
  
        <div class="col-md-2">
          <input v-model="searchQuery" type="text" class="form-control" placeholder="Ürün adı ara..." />
        </div>
      </div>
  
      <!-- Ürünler -->
      <div class="row g-4">
        <ProductCard
          v-for="product in filteredProducts"
          :key="product.id"
          :product="product"
          class="col-md-3"
        />
      </div>
    </div>
  </template>
  
  <script setup>
import { onMounted, computed, ref } from 'vue'
import ProductCard from '@/components/ProductCard.vue'
import { useProductStore } from '@/stores/product'
import categories from '@/constants/category'

const productStore = useProductStore()

const selectedCategory = ref('')
const priceOrder = ref('')
const minPrice = ref(null)
const maxPrice = ref(null)
const searchQuery = ref('')

const filteredProducts = computed(() => {
  //spread operatörü kullanımı
  let filtered = [...productStore.allProducts]
  if (selectedCategory.value) {
    filtered = filtered.filter(p => p.category === selectedCategory.value)
  }  
  if (!isNaN(minPrice.value) && minPrice.value !== null && minPrice.value !== '') {
    filtered = filtered.filter(p => p.price >= Number(minPrice.value))
  }
  if (!isNaN(maxPrice.value) && maxPrice.value !== null && maxPrice.value !== '') {
    filtered = filtered.filter(p => p.price <= Number(maxPrice.value))
  }
  if (priceOrder.value === 'asc') {
  filtered.sort((a, b) => a.price - b.price)
} else if (priceOrder.value === 'desc') {
  filtered.sort((a, b) => b.price - a.price)
}

  return filtered
})

onMounted(() => {
  if (productStore.allProducts.length === 0) {
    productStore.fetchProducts()
  }
})
</script>

  
  <style scoped>
  select.form-select {
    min-width: 200px;
  }
  </style>
  