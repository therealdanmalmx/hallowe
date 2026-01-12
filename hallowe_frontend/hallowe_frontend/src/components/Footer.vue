<template>
  <footer class="border-t-2 border-orange-500 overflow-hidden">
    <div class="max-w-full mx-auto px-4 py-12 z-10">
      <!-- Main footer content -->
      <div class="grid grid-cols-1 md:grid-cols-4 gap-8">
        <!-- Brand section -->
        <div class="md:col-span-1">
          <h1 class="text-2xl font-bold text-orange-500 mb-2" style="text-shadow: 0 0 10px rgba(249, 115, 22, 0.5)">
            HALLOWE
          </h1>
          <p class="text-orange-400 text-sm mb-4">Trick or Treat...</p>
        </div>

        <!-- Quick Links -->
        <div>
          <h3 class="text-orange-400 font-bold mb-4 uppercase tracking-wider">Quick Links</h3>
          <ul class="space-y-2">
            <li>
              <a href="/" class="text-slate-400 hover:text-orange-400 transition-colors text-sm">
                Hem
              </a>
            </li>
            <li>
              <a href="/map" class="text-slate-400 hover:text-orange-400 transition-colors text-sm">
                Map
              </a>
            </li>
            <li>
              <a href="/search" class="text-slate-400 hover:text-orange-400 transition-colors text-sm">
                Lista
              </a>
            </li>
          </ul>
        </div>

        <!-- Company -->
        <div>
          <h3 class="text-orange-400 font-bold mb-4 uppercase tracking-wider">Company</h3>
          <ul class="space-y-2">
            <li>
              <a href="#" class="text-slate-400 hover:text-orange-400 transition-colors text-sm">
                Hur det fungerar
              </a>
            </li>
            <li>
              <a href="#" class="text-slate-400 hover:text-orange-400 transition-colors text-sm">
                Kontakt
              </a>
            </li>
          </ul>
        </div>
      </div>
        <div class="text-center md:text-right">
          <p class="text-slate-500 text-sm">
            &copy; {{ new Date().getFullYear()}} HALLOWE. All rights reserved.
          </p>
          <p class="text-slate-600 text-xs mt-1">
            Made with 🎃 and spooky magic
          </p>
        </div>
    </div>

  </footer>
</template>