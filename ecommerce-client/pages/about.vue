<template>
    <div class="container py-5">
      <div class="row align-items-center">
        <div class="col-md-4 text-center">
          <img
            src="/assets/images/profile.jpeg"
            alt="Profil Fotoğrafı"
            class="img-fluid rounded-circle shadow"
            width="200"
          />
        </div>
        <div class="col-md-8">
          <h2 class="fw-bold mb-3">Merhaba, ben Ali Baran Demir 👋</h2>
          <p>
            Ege Üniversitesinde Bilgisayar mühendisliği 4. sınıf öğrencisiyim.
            Full-stack developer olarak kariyerime odaklanıyorum. Frontend tarafında
            özellikle <strong>Next.js</strong> ve <strong>React</strong> ile projeler
            geliştiriyorum. Backend kısmında ise
            <strong>.NET Core</strong> ve <strong>Java Spring</strong> ile REST API’ler yazdım.
            Bu teknolojilerle ilgili projelerim mevcut.
          </p>
          <p>
            Bu e-ticaret projesini Definex ve Coderspace önderliğinde düzenlenen .NET Bootcamp için hazırladım.
          </p>
          <div class="mt-4">
            <a
              href="https://github.com/alibarandemir"
              class="btn btn-dark me-2"
              target="_blank"
              rel="noopener"
            >
              <Icon name="mdi:github" class="me-1" /> GitHub
            </a>
            <a
              href="https://www.linkedin.com/in/ali-baran-demir-55b0181b4/"
              class="btn btn-outline-primary me-2"
              target="_blank"
              rel="noopener"
            >
              <Icon name="mdi:linkedin" class="me-1" /> LinkedIn
            </a>
            <a
              href="https://medium.com/@alibarandemir798"
              class="btn btn-outline-secondary me-2"
              target="_blank"
            >
              <Icon name="mdi:medium" class="me-1" /> Medium
            </a>
            <a
              href="mailto:alibarandemir798@gmail.com"
              class="btn btn-outline-secondary"
            >
              <Icon name="mdi:email" class="me-1" /> Mail Gönder
            </a>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <style scoped>
  h2 {
    color: var(--color-black);
  }
  
  /* strong sarı renk */
  :deep(strong) {
    color: var(--color-yellow);
  }
  </style>
  