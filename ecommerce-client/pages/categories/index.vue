<template>
    <div class="container py-5">
      <h2 class="mb-4 text-center">Kategoriler</h2>
      <div class="row g-4 justify-content-center">
        <div
          v-for="cat in categories"
          :key="cat.value"
          class="col-md-2 text-center"
        >
          <NuxtLink
            :to="`/categories/${cat.label}`"
            class="p-3 border rounded shadow-sm d-block hover-shadow"
            style="color: black;"
          >
            <Icon :name="cat.icon" style="font-size: 2rem; color: var(--color-yellow);" />
            <p class="mt-2">{{ cat.label }}</p>
          </NuxtLink>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import categories from '@/constants/category'
  </script>
  
  <style scoped>
  .hover-shadow:hover {
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
    transition: 0.3s;
  }
  </style>
  