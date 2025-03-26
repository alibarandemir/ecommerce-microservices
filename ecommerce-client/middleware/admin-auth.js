export default defineNuxtRouteMiddleware((to, from) => {
  // Yalnızca client tarafında çalışmalı
  if (import.meta.client) {
    const token = localStorage.getItem('token')

    if (!token) {
      return navigateTo('/admin')
    }
  }
})
