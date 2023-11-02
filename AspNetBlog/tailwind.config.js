/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [],
  purge: {
    enabeld: true,
    content: ["./Views/**/*.cshtml"],
  },
  daisyui: {
    themes: ["black", "lofi"],
  },
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
}

