function plus (a, b) {
    return a + b;
}
function minus (a, b) {
    return a - b;
}
const pi = 3.14;
function op (op, a, b) {
    if (op == "plus") return a + b;
    if (op == 'minus') return a - b;
}
export { 
    plus,
    pi,
    minus as tafrigh
};
export default op;