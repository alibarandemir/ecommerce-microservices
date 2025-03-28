// ürün store yapısı
import { defineStore } from 'pinia'

export const useProductStore = defineStore('product', {
  state: () => ({
    products: [],
    filteredProducts: []
  }),

  actions: {
    //tüm ürünleri çekme actionı
    async fetchProducts() {
      try {
        const res = await fetch('http://localhost:5000/products')
        const data = await res.json()
        this.products = data.data
        this.filteredProducts = data.data
      } catch (err) {
        console.error('Ürünler getirilirken hata oluştu:', err)
      }
    },
    //Kategoriye göre ürün çekme actionı
    async fetchProductsByCategory(categoryId) {
      try {
        const res = await fetch(`http://localhost:5000/products/category/${categoryId}`)
        const data = await res.json()
        this.filteredProducts = data.data
      } catch (err) {
        console.error('Kategoriye göre ürün getirilirken hata oluştu:', err)
      }
    },
    //ürün ekleme actionı
    async addProduct(formData) {
      try {
        const token = localStorage.getItem('token')

        const res = await fetch('http://localhost:5000/products', {
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
        const response = await res.json();
        const newProduct = response.data
        this.products.push(newProduct)
      } catch (err) {
        console.error('Ürün eklenirken hata:', err)
      }
    },
    //ürün silme actionı
    async deleteProduct(id) {
      try {
        const token = localStorage.getItem('token')

        const res = await fetch(`http://localhost:5000/products/${id}`, {
          method: 'DELETE',
          headers: {
            Authorization: `Bearer ${token}`
          }
        })

        if (!res.ok) {
          const errorData = await res.json()
          throw new Error(errorData.message || 'Silme işlemi başarısız')
        }
        //toast mesajını kullanma(pluginsden)
        useNuxtApp().$toast.success('Silme başarılı');
        this.products = this.products.filter(p => p.id !== id)
        this.filteredProducts = this.filteredProducts.filter(p => p.id !== id)
      } catch (err) {
        useNuxtApp().$toast.error('Silme başarısız: ' + err.message);
        console.error('Ürün silinirken hata:', err)
      }
    },

    getProductById(id) {
      return this.products.find(p => p.id === id)
    },

    async fetchProductById(id) {
      try {
        const res = await fetch(`http://localhost:5000/products/${id}`)
        const data = await res.json()
        return data.data // detay sayfasında kullanılacak
      } catch (err) {
        console.error('Ürün detayı getirilirken hata oluştu:', err)
        throw err
      }
    }
  },

  //state döndürme
  getters: {
    allProducts: (state) => state.products,
    categoryProducts: (state) => state.filteredProducts
  }
})