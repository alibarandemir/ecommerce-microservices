<template>
  <div class="card h-100 shadow-sm border-0">
    <!-- Görsel kapsayıcı -->
    <div class="image-wrapper">
      <img
        :src="product.imageUrl"
        :alt="product.name"
        class="card-img-top product-image"
      />
    </div>

    <div class="card-body d-flex flex-column">
      <h5 class="card-title">{{ product.name }}</h5>
      <p class="card-text text-muted mb-1">
        <Icon :name="categoryIcon" class="me-1" />{{ categoryLabel }}
      </p>
      <p class="fw-bold mb-2">{{ product.price }} ₺</p>
      <div class="mt-auto">
        <NuxtLink :to="`/products/${product.id}`" class="btn btn-outline-dark w-100">Detay</NuxtLink>
      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  product: {
    type: Object,
    required: true
  }
})

import categories from '@/constants/category.js'

const matchedCategory = categories.find(c => c.label === props.product.category)
const categoryLabel = matchedCategory?.label || 'Kategori yok'
const categoryIcon = matchedCategory?.icon || ''
</script>

<style scoped>
.image-wrapper {
  height: 200px;
  display: flex;
  align-items: center;
  justify-content: center;
  overflow: hidden;
  background-color: #f9f9f9;
}

.product-image {
  max-height: 100%;
  max-width: 100%;
  object-fit: contain;
}
</style>
