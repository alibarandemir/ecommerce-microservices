<!-- components/admin/ProductTable.vue -->
<template>
    <div class="table-responsive">
      <table class="table table-bordered align-middle text-center">
        <thead class="table-light">
          <tr>
            <th>#</th>
            <th>Görsel</th>
            <th>Ad</th>
            <th>Fiyat</th>
            <th>Puan</th>
            <th>Kategori</th>
            <th>İşlemler</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(product, index) in products" :key="index">
            <td>{{ index + 1 }}</td>
            <td>
              <img :src="product.imageUrl" :alt="product.name" style="width: 60px; height: auto;" />
            </td>

            <td>{{ product.name }}</td>
            <td>{{ product.price }} ₺</td>
            <td>{{ product.rating }}</td>
            <td>{{ product.category }}</td>
            <td>
              <button class="btn btn-sm btn-outline-danger" @click="$emit('delete', product.id)">
                Sil
              </button>
            </td>
          </tr>
          <tr v-if="products.length === 0">
            <td colspan="6" class="text-muted">Henüz ürün eklenmedi.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </template>
  
  <script setup>
  defineProps({
    products: {
      type: Array,
      required: true
    }
  })
  </script>
  