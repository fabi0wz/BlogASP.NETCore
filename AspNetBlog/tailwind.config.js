/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [],
  purge: {
    enabeld: true,
      content: ["./Views/**/*.cshtml",
                "./Areas/**/*.cshtml"
      ],
  },
  daisyui: {
    themes: ["business", "lofi"],
  },
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
}

