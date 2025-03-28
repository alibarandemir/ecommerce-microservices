<template>
  <div class="chat-container">
    <div
      v-if="!isOpen"
      class="chat-icon"
      @click="toggleChat"
    >
      💬
    </div>
    <div v-else class="chat-box">
      <div class="chat-header">
        <span>Sohbet</span>
        <button class="close-btn" @click="toggleChat">×</button>
      </div>

      <div class="chat-messages">
        <div
          v-for="(msg, index) in chat.messages"
          :key="index"
          class="chat-message"
        >
          <strong>{{ msg.sender }}:</strong> {{ msg.content }}
        </div>
      </div>

      <form @submit.prevent="handleSend" class="chat-form">
        <input
          v-model="message"
          class="chat-input"
          placeholder="Mesaj yaz..."
        />
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useChatStore } from '@/stores/chat'

const chat = useChatStore()
const message = ref('')
const isOpen = ref(false)

const toggleChat = () => {
  isOpen.value = !isOpen.value
}

onMounted(() => {
  if (!chat.connected) {
    const anon = `user_${Math.floor(Math.random() * 10000)}`
    chat.connect(anon)
  }
})

const handleSend = () => {
  if (message.value.trim()) {
    chat.sendMessage(message.value)
    message.value = ''
  }
}
</script>

<style scoped>
.chat-container {
  position: fixed;
  bottom: 20px;
  right: 20px;
  z-index: 9999;
}
.chat-icon {
  width: 60px;
  height: 60px;
  background-color: #2563eb;
  color: white;
  border-radius: 50%;
  font-size: 28px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
}

.chat-box {
  width: 320px;
  background-color: white;
  border-radius: 12px;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.3);
  padding: 10px;
}
.chat-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-weight: bold;
  margin-bottom: 10px;
}

.close-btn {
  background: none;
  border: none;
  font-size: 22px;
  cursor: pointer;
}
.chat-messages {
  max-height: 200px;
  overflow-y: auto;
  padding: 5px;
  border: 1px solid #eee;
  border-radius: 6px;
  margin-bottom: 10px;
}

.chat-message {
  margin-bottom: 6px;
}
.chat-form {
  display: flex;
}

.chat-input {
  flex: 1;
  padding: 8px;
  border-radius: 6px;
  border: 1px solid #ccc;
}
</style>
