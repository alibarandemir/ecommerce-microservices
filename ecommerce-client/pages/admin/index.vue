<template>
    <div class="d-flex justify-content-center align-items-center min-vh-100 bg-light">
      <div class="w-100" style="max-width: 400px;">
        <h3 class="text-center mb-4">Admin Giriş</h3>
        <form @submit.prevent="login">
          <div class="mb-3">
            <label for="username" class="form-label">Kullanıcı Adı</label>
            <input v-model="username" type="text" id="username" class="form-control" required />
          </div>
          <div class="mb-3">
            <label for="password" class="form-label">Şifre</label>
            <input v-model="password" type="password" id="password" class="form-control" required />
          </div>
          <button type="submit" class="btn btn-dark w-100">Giriş Yap</button>
        </form>
        <p v-if="error" class="text-danger mt-3">{{ error }}</p>
      </div>
    </div>
  </template>
  
  
  <script setup>
  definePageMeta({
  layout: 'admin'
})
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useStore } from 'vuex' // ✅ Buradan import
import { useAdminStore } from '../../stores/admin'

const store = useAdminStore()// ✅ sadece setup içinde çağırılır
const username = ref('')
const password = ref('')
const error = ref('')
const router = useRouter()
const login = async () => {
  try {
    await store.login(username.value, password.value)
    router.push('/admin/dashboard')
    useNuxtApp().$toast.success('Giriş başarılı!')
  } catch (err) {
    error.value = err.message
    useNuxtApp().$toast.error(err.message || 'Giriş başarısız')
  }
}


  </script>
