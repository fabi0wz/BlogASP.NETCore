/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [],
  purge: {
    enabeld: true,
    content: ["./Views/**/*.cshtml"],
  },
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
}

