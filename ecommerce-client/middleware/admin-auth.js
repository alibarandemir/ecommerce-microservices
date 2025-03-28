export default defineNuxtRouteMiddleware((to, from) => {
  // protected route sağlar
  if (import.meta.client) {
    const token = localStorage.getItem('token')

    if (!token) {
      return navigateTo('/admin')
    }
  }
})
