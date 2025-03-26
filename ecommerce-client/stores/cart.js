import { defineStore } from 'pinia'

export const useCartStore = defineStore('cart', {
  state: () => ({
    cart: []
  }),

  actions: {
    addToCart(product, quantity = 1) {
      const existing = this.cart.find(p => p.id === product.id)
      if (existing) {
        existing.quantity += quantity
      } else {
        this.cart.push({ ...product, quantity })
      }
      this.saveCartToStorage()
    },

    removeFromCart(id) {
      this.cart = this.cart.filter(p => p.id !== id)
      this.saveCartToStorage()
    },

    clearCart() {
      this.cart = []
      this.saveCartToStorage()
    },

    saveCartToStorage() {
      localStorage.setItem('cart', JSON.stringify(this.cart))
    },

    loadCartFromStorage() {
      const stored = localStorage.getItem('cart')
      if (stored) {
        this.cart = JSON.parse(stored)
      }
    }
  },

  getters: {
    cartItems: (state) => state.cart,
    cartTotal: (state) =>
      state.cart.reduce((total, item) => total + item.price * item.quantity, 0),
    cartCount: (state) =>
      state.cart.reduce((sum, item) => sum + item.quantity, 0),
  }
})
