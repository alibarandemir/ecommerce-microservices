import * as signalR from '@microsoft/signalr'

export default defineNuxtPlugin(nuxtApp => {
  const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5003/chathub", {
      transport: signalR.HttpTransportType.WebSockets, // 👈 bu çok kritik
      withCredentials: true
    })
    .withAutomaticReconnect()
    .build()

  connection.on("ReceiveMessage", (user, message) => {
    console.log(`${user}: ${message}`)
    nuxtApp.$toast.success(`${user}: ${message}`)
  })

  connection.start()
    .then(() => console.log("✅ SignalR bağlantısı kuruldu"))
    .catch(err => console.error("❌ Bağlantı hatası:", err))

  nuxtApp.provide('signalR', connection)
})
