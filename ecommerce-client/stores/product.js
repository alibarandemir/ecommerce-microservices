// stores/product.js
import { defineStore } from 'pinia'

export const useProductStore = defineStore('product', {
  state: () => ({
    products: []
  }),

  actions: {
    async fetchProducts() {
      try {
        const res = await fetch('https://localhost:5000/products')
        const data = await res.json()
        console.log(data)
        this.products = data.data
      } catch (err) {
        console.error('Ürünler getirilirken hata oluştu:', err)
      }
    },

    async addProduct(formData) {
      try {
        const token = localStorage.getItem('token')

        const res = await fetch('https://localhost:5000/products', {
          method: 'POST',
          headers: {
            Authorization: `Bearer ${token}`
          },
          body: formData
        })

        if (!res.ok) {
          const errorData = await res.json()
          throw new Error(errorData.message || 'Ürün eklenemedi')
        }
        const response=await res.json();
        const newProduct = response.data
        this.products.push(newProduct)
      } catch (err) {
        console.error('Ürün eklenirken hata:', err)
      }
    },

    async deleteProduct(id) {
      try {
        const token = localStorage.getItem('token')

        const res = await fetch(`https://localhost:5000/products/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${token}`
          }
        })

        if (!res.ok) {
          const errorData = await res.json()
          throw new Error(errorData.message || 'Silme işlemi başarısız')
        }
        useNuxtApp().$toast.success('Silme başarılı');

        this.products = this.products.filter(p => p.id !== id)
      } catch (err) {
        useNuxtApp().$toast.error('Silme başarısız: ' + err.message);
        console.error('Ürün silinirken hata:', err)
      }
    }
  },

  getters: {
    allProducts: (state) => state.products
  }
})
