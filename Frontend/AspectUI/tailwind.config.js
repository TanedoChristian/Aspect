module.exports = {
    content: [
       './Pages/**/*.razor',
        './Shared/**/*.razor',
        './**/**/*.razor'
],
    theme: {
        screens: {
            mobile: "500px",
            tablet: "768px",
            desktop: "1024px",
        },
        extend: {},
    },
    plugins: [],
}