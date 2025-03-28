// admin store yapısı
import { defineStore } from 'pinia'
export const useAdminStore = defineStore('admin', {
  state: () => ({
    token: null,
    isAuthenticated: false
  }),
  actions: {
    async login(username, password) {
      try {
        console.log(username)
        const response = await fetch('http://localhost:5000/auth/login', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ UserName: username, Password: password })
        })
        const data = await response.json()
        if (!response.ok) {
          throw new Error(data.message || 'Giriş başarısız')
        }

        this.token = data.data
        this.isAuthenticated = true
        localStorage.setItem('token',data.data)
      } catch (err) {
        throw err
      }
    },
    logout() {
      this.token = null
      this.isAuthenticated = false
      localStorage.removeItem('token')
    }
  }
})
