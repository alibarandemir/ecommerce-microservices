<template>
  <nav class="navbar navbar-expand-lg shadow-sm bg-white">
    <div class="container-fluid">
      <a class="navbar-brand text-black fw-bold" href="/">E-Commerce</a>
      <button
        class="navbar-toggler border-0"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarNav"
        aria-controls="navbarNav"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon custom-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <a class="nav-link nav-link-custom" href="/">Ana Sayfa</a>
          </li>
          <li class="nav-item">
            <a class="nav-link nav-link-custom" href="/products">Ürünler</a>
          </li>
          <li class="nav-item">
            <a class="nav-link nav-link-custom" href="/categories">Kategoriler</a>
          </li>
          <li class="nav-item">
            <a class="nav-link nav-link-custom" href="/about">Hakkımda</a>
          </li>
          <li class="nav-item">
            <button class="nav-link nav-link-custom d-flex align-items-center" href="/cart">
              <Icon name="ph:shopping-cart-fill" class="me-1 cart-icon" filled style="fill: var(--color-yellow);"/> 
            </button>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<style scoped>
:root {
  --theme-yellow: #FFD700;
  --theme-black: #000000;
}

.nav-link-custom {
  color: var(--theme-black) !important;
  font-weight: 500;
  transition: color 0.3s ease;
}

.nav-link-custom:hover {
  color: var(--theme-yellow) !important;
}

.cart-icon {
  fill: var(--theme-yellow);
  font-size: 1.2rem;
}
:deep(.cart-icon) {
  fill: var(--theme-yellow);
  font-size: 1.6rem;
}

</style>
