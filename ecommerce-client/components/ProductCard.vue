<template>
    <div class="card h-100 shadow-sm border-0">
      <img :src="product.imageUrl" :alt="product.name" class="card-img-top" style="object-fit: cover; height: 200px" />
      <div class="card-body d-flex flex-column">
        <h5 class="card-title">{{ product.name }}</h5>
        <p class="card-text text-muted mb-1">
          <Icon :name="categoryIcon"/>{{ categoryLabel }}
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
  