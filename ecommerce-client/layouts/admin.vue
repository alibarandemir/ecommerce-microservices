<!-- layouts/admin.vue -->
<template>
    <div class="admin-layout">
      <slot />
    </div>
  </template>
  
  <style scoped>
  .admin-layout {
    min-height: 100vh;
    background-color: #f8f9fa; /* İsteğe bağlı arka plan */
    padding: 2rem 1rem;
  }
  </style>
  