import { defineStore } from 'pinia'
import * as signalR from '@microsoft/signalr'

export const useChatStore = defineStore('chat', {
  state: () => ({
    connection: null,
    messages: [],
    connected: false,
    anonUsername: ''
  }),

  actions: {
    //signalr bağlantı kurulumu
    async connect(anonUsername, isAdmin = false) {
      //random username üretilip öyle haberleşiliyor adminle
      this.anonUsername = anonUsername
    
      const queryString = isAdmin
        ? `admin=true`
        : `anonUsername=${anonUsername}`
    
      this.connection = new signalR.HubConnectionBuilder()
        .withUrl(`http://localhost:5003/chathub?${queryString}`, {
          transport: signalR.HttpTransportType.WebSockets,
          withCredentials: true
        })
        .withAutomaticReconnect()
        .build()
      //mesaj alındığında çalışacak fonksiyon
      this.connection.on("ReceiveMessage", (sender, content) => {
        this.messages.push({ sender, content })
      })
      //bağlantı kurulduğunda çalışacak fonksiyon
      this.connection.on("Connected", (connectionId, name) => {
        this.connected = true
        console.log(`Bağlandı: ${name} (${connectionId})`)
      })
    
      this.connection.onclose(() => {
        this.connected = false
        console.warn("SignalR bağlantısı koptu")
      })
    
      try {
        await this.connection.start()
      } catch (error) {
        console.error("Bağlantı hatası:", error)
      }
    },

    async sendMessage(message) {
      if (!this.connection || this.connection.state !== "Connected") return

      await this.connection.invoke("SendMessageToAdmin", message)
      this.messages.push({ sender: this.anonUsername, content: message })
    },
    async sendMessageFromAdmin(message) {
      if (!this.connection || this.connection.state !== "Connected") return
    
      await this.connection.invoke("SendMessageFromAdmin", message)
      this.messages.push({ sender: 'Admin', content: message })
    }
    
  }
})
