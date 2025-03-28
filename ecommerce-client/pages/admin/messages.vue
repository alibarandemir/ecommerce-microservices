<template>
    <div class="container py-5">
      <h2 class="mb-4">📨 Gelen Mesajlar</h2>
  
      <div class="border rounded p-3 mb-3 bg-light" style="height: 300px; overflow-y: auto;">
        <div
          v-for="(msg, index) in chat.messages"
          :key="index"
          class="mb-2"
        >
          <strong>{{ msg.sender }}:</strong> {{ msg.content }}
        </div>
      </div>
  
      <form @submit.prevent="sendReply" class="d-flex gap-2">
        <input
          v-model="reply"
          class="form-control"
          placeholder="Yanıt yazın..."
        />
        <button class="btn btn-primary">Gönder</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { useChatStore } from '@/stores/chat'
  import { onMounted, ref } from 'vue'
  
  definePageMeta({
    middleware: 'admin-auth',
    layout: 'admin'
  })
  
  const chat = useChatStore()
  const reply = ref('')
  
  onMounted(() => {
    if (!chat.connected) {
      // Admin olarak bağlanma
      chat.connect("AdminPanelUser", true)
    }
  })
  
  const sendReply = async () => {
  if (reply.value.trim()) {
    await chat.connection.invoke('SendMessageFromAdmin', reply.value)
    //input alanı boşaltma
    reply.value = ''
  }
}
  </script>
  