<template>
  <div>
    <!-- Hero Alanı -->
    <section class="hero bg-light p-5 text-center rounded shadow mb-5">
      <h1 class="display-5 fw-bold hero-title">
        En Yeni <span class="highlight">Ürünler</span>, En Uygun
        <span class="highlight">Fiyatlarla!</span>
      </h1>
      <p class="lead">
        E-ticaret sitemize hoş geldiniz. En popüler ürünleri hemen keşfedin.
      </p>
      <NuxtLink to="/products" class="btn btn-dark btn-lg mt-3"
        >Ürünleri Gör</NuxtLink
      >
    </section>

    <!-- Popüler Kategoriler (Şimdilik tüm ürünler çekiliyor) -->
    <section class="popular-categories mb-5">
      <div class="container">
        <h2 class="mb-4">Popüler Kategoriler</h2>
        <div class="row justify-content-center g-4">
          <div
            v-for="cat in categories"
            :key="cat.value"
            class="col-6 col-sm-4 col-md-3 col-lg-2 text-center"
          >
            <div class="p-3 border rounded shadow-sm h-100 hover-shadow">
              <Icon :name="cat.icon" style="font-size: 2rem" />
              <p class="mt-2">{{ cat.label }}</p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Yeni Ürünler -->
    <section class="mb-5">
      <div class="container">
      <h2 class="mb-4">Yeni Eklenen Ürünler</h2>
      <Swiper
        :slides-per-view="4"
        :space-between="30"
        :navigation="true"
        :modules="[Navigation]"
        class="mySwiper"
      >
        <SwiperSlide v-for="product in products" :key="product.id">
          <ProductCard :product="product" />
        </SwiperSlide>
      </Swiper>
    </div>
    </section>
  
  </div>
</template>

<script setup>
import { Swiper, SwiperSlide } from "swiper/vue";
import "swiper/css";
import "swiper/css/navigation";
import { Navigation } from "swiper/modules";
import ProductCard from "@/components/ProductCard.vue";
import categories from "../constants/category";
import { useProductStore } from "@/stores/product";
import { computed, onMounted } from "vue";

const productStore = useProductStore();
const products = computed(() => productStore.allProducts);
//sayfa render edildiğinde çağrılan action
onMounted(() => {
  if (productStore.allProducts.length === 0) {
    productStore.fetchProducts();
  }
});
</script>

<style>
.hover-shadow:hover {
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
  transition: 0.3s;
}
.swiper-button-next::after,
.swiper-button-prev::after {
  color: #000 !important;
  font-size: 25px;
}
.highlight {
  color: var(--color-yellow);
  font-weight: 700;
  position: relative;
}

.highlight::after {
  content: "";
  position: absolute;
  left: 0;
  bottom: 0;
  height: 4px;
  width: 100%;
  background-color: var(--color-yellow);
  opacity: 0.4;
  z-index: -1;
  transition: all 0.3s ease;
}
.highlight:hover::after {
  opacity: 0.4;
  height: 8px;
}
</style>
