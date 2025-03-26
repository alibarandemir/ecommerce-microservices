<template>
  <form @submit.prevent="handleSubmit" class="card p-4 shadow-sm">
    <h5 class="mb-3 fw-bold">Yeni Ürün Ekle</h5>

    <div class="mb-3">
      <label class="form-label">Ürün Adı</label>
      <input
        v-model="form.name"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': errors.name }"
      />
      <div v-if="errors.name" class="invalid-feedback">{{ errors.name }}</div>
    </div>

    <div class="mb-3">
      <label class="form-label">Fiyat</label>
      <input
        v-model.number="form.price"
        type="number"
        class="form-control"
        :class="{ 'is-invalid': errors.price }"
      />
      <div v-if="errors.price" class="invalid-feedback">{{ errors.price }}</div>
    </div>

    <div class="mb-3">
      <label class="form-label">Puan (0-5)</label>
      <input
        v-model.number="form.rating"
        type="number"
        min="0"
        max="5"
        class="form-control"
        :class="{ 'is-invalid': errors.rating }"
      />
      <div v-if="errors.rating" class="invalid-feedback">
        {{ errors.rating }}
      </div>
    </div>

    <div class="mb-3">
      <label class="form-label">Kategori</label>
      <select
        v-model="form.category"
        class="form-select"
        :class="{ 'is-invalid': errors.category }"
      >
        <option value="" disabled selected>Kategori Seçiniz</option>
        <option v-for="cat in categories" :key="cat.value" :value="cat.value">
          {{ cat.label }}
        </option>
      </select>
      <div v-if="errors.category" class="invalid-feedback">
        {{ errors.category }}
      </div>
    </div>

    <div class="mb-3">
      <label class="form-label">Ürün Görseli</label>
      <input type="file" @change="handleImage" class="form-control" />
    </div>

    <button type="submit" class="btn btn-success w-100">Ürünü Kaydet</button>
  </form>
</template>

<script setup>
import { reactive, ref } from "vue";
import categories from "../../constants/category";

const emit = defineEmits(["submit"]);

const props = defineProps({
  initialProduct: {
    type: Object,
    default: () => ({}),
  },
});

// Formu başlat
const form = reactive({
  name: props.initialProduct.name || "",
  price: props.initialProduct.price || null,
  rating: props.initialProduct.rating || null,
  category: props.initialProduct.category || "",
  image: props.initialProduct.image || null,
});

const errors = reactive({
  name: "",
  price: "",
  rating: "",
  category: "",
});

const handleImage = (event) => {
  form.image = event.target.files[0];
};

const validate = () => {
  let isValid = true;
  errors.name = form.name ? "" : "Ürün adı zorunludur";
  errors.price = form.price > 0 ? "" : "Fiyat pozitif bir sayı olmalı";
  errors.rating =
    form.rating >= 0 && form.rating <= 5 ? "" : "Puan 0-5 arasında olmalı";
    errors.category = form.category !== null && form.category !== "" ? "" : "Kategori boş bırakılamaz";

  for (const key in errors) {
    if (errors[key]) isValid = false;
  }
  return isValid;
};

const handleSubmit = () => {
  if (!validate()) return;

  const formData = new FormData();
  formData.append("Name", form.name);
  formData.append("Price", form.price);
  formData.append("Rating", form.rating);
  formData.append("Category", form.category);
  formData.append("Image", form.image);

  emit("submit", formData);

  // Form temizleme
  form.name = "";
  form.price = null;
  form.rating = null;
  form.category = "";
  form.image = null;
};
</script>
