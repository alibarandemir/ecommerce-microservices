<template>
    <div class="container py-5">
      <div class="d-flex justify-content-between align-items-center mb-4">
        <h2>Ürün Yönetimi</h2>
        <div class="d-flex gap-2">
          <button class="btn btn-outline-secondary" @click="logout">
            Çıkış Yap
          </button>
          <button class="btn btn-primary" @click="showModal = true">
            + Ürün Ekle
          </button>
        </div>
      </div>
  
      <!-- Modal -->
      <div
        class="modal fade show"
        tabindex="-1"
        style="display: block"
        v-if="showModal"
        @click.self="showModal = false"
      >
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Yeni Ürün Ekle</h5>
              <button
                type="button"
                class="btn-close"
                @click="showModal = false"
              ></button>
            </div>
            <div class="modal-body">
              <ProductForm @submit="handleAddProduct" />
            </div>
          </div>
        </div>
      </div>
  
      <!-- Modal arkaplan -->
      <div v-if="showModal" class="modal-backdrop fade show"></div>
  
      <!-- Daha sonra: ürün tablosu -->
      <ProductTable
        :products="productList"
        @delete="confirmDelete"
        @edit="editProduct"
      />
    </div>
  
    <!-- Silme Onay Modali -->
    <div
      class="modal fade show"
      v-if="showDeleteModal"
      @click.self="showDeleteModal = false"
      style="display: block"
    >
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title text-danger">Silme Onayı</h5>
            <button
              type="button"
              class="btn-close"
              @click="showDeleteModal = false"
            ></button>
          </div>
          <div class="modal-body">
            <p>Bu ürünü silmek istediğinizden emin misiniz?</p>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" @click="showDeleteModal = false">
              İptal
            </button>
            <button class="btn btn-danger" @click="performDelete">
              Evet, Sil
            </button>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import ProductForm from '@/components/admin/ProductForm.vue';
  import ProductTable from '@/components/admin/ProductTable.vue';
  import { useAdminStore } from '@/stores/admin';
  import { useProductStore } from '@/stores/product';
  import { useRouter } from 'vue-router';
  import { onMounted, ref, computed } from 'vue';

  definePageMeta({
  middleware: "admin-auth",
  layout: "admin",
});
  
  const productStore = useProductStore();
  const adminStore = useAdminStore();
  const router = useRouter();
  
  const showModal = ref(false);
  const showDeleteModal = ref(false);
  const selectedProduct = ref(null);
  const deleteId = ref(null);
  
  const productList = computed(() => productStore.allProducts);
  
  const handleAddProduct = async (formData) => {
    try {
      await productStore.addProduct(formData);
      showModal.value = false;
      useNuxtApp().$toast.success('Ürün başarıyla eklendi');
    } catch (error) {
      useNuxtApp().$toast.error('Bir hata oluştu: ' + error.message);
    }
  };
  
  
  
  const confirmDelete = (id) => {
    deleteId.value = id;
    showDeleteModal.value = true;
  };
  
  const performDelete = async () => {
    try {
      await productStore.deleteProduct(deleteId.value);
      
    } catch (error) {
      useNuxtApp().$toast.error('Silme başarısız: ' + error.message);
    } finally {
      showDeleteModal.value = false;
    }
  };
  
  const logout = () => {
    adminStore.logout();
    useNuxtApp().$toast.info('Çıkış yapıldı');
    router.push('/admin');
  };
  
  onMounted(() => {
    productStore.fetchProducts();
  });
  </script>
  
  <style scoped>
  .modal {
    position: fixed;
    z-index: 1055;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    overflow-y: auto;
    display: flex !important;
    align-items: center;
    justify-content: center;
    background-color: rgba(0, 0, 0, 0.5);
  }
  
  .modal-backdrop {
    display: none !important;
  }
  </style>
  