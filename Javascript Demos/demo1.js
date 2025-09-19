// //Example for Map function
// const numbers = [3, 5, 7, 8];
// console.log(numbers);
// square_numbers = numbers.map((num) => num * num);
// console.log(square_numbers);

// //reduce
// //reduce to a single value using accumulator
// const numbers = [20, 50, 60, 80];
// const sum = numbers.reduce((acc, num) => acc + num, 0);
// console.log(sum);

// //slice
// // returns a shallow copy of a protion of array
// const myarr = ["a", "b", "c", "d", "e"];
// const slicedarray = myarr.slice(1, 4);
// console.log(slicedarray);

// // Rest operators
// //collect remaining arguments into an array
// function Addnumbers(a, b, ...others) {
//   return a + b + others.reduce((sum, val) => sum + val, 0);
// }

// console.log(Addnumbers(10, 30, 30, 20, 50));

// //filter
// const numbers = [5, 10, 15, 20, 25];
// let number_above_10 = numbers.filter((num) => num > 10);
// console.log(number_above_10);

// //Array of objects
// const students = [
//   { name: "Yamuna", marks: 86 },
//   { name: "Raja", marks: 80 },
// ];

// const avg = students.reduce((sum, s) => sum + s.marks, 0) / students.length;
// console.log(avg);

// // chaining of array methods
// const result = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
//   .filter((n) => n % 2 == 0)
//   .map((n) => n * n)
//   .reduce((a, b) => a + b, 0);

// console.log(result);

// const cart = [
//   { item: "shoes", price: 4500, qty: 1 },
//   { item: "Bag", price: 3000, qty: 1 },
//   { item: "Watch", price: 14500, qty: 2 },
// ];

// const totalBill = cart.map((c) => c.price * c.qty).reduce((a, b) => a + b, 0);
// console.log("Total Bill :" + totalBill);

const products = [
  {
    id: 101,
    name: "Sneakers",
    category: "Footwear",
    price: 2499,
    stock: 12,
    tags: ["men", "running"],
  },
  {
    id: 102,
    name: "Backpack",
    category: "Bags",
    price: 1799,
    stock: 0,
    tags: ["unisex", "travel"],
  },
  {
    id: 103,
    name: "Smartwatch",
    category: "Gadgets",
    price: 6999,
    stock: 7,
    tags: ["unisex", "fitness"],
  },
  {
    id: 104,
    name: "T-Shirt",
    category: "Apparel",
    price: 799,
    stock: 34,
    tags: ["men", "casual"],
  },
  {
    id: 105,
    name: "Dress",
    category: "Apparel",
    price: 1999,
    stock: 6,
    tags: ["women", "party"],
  },
];

// 1. list the product name and its price

//2. display the products which is in stock

//3. calculate the the totalvalue of the the store

// //4. some()
// console.log(products.some((p) => p.stock === 0));
// console.log(products.every((p) => p.price > 5500));

// //sort()
// //console.log(products);
// const sorted_productsByPrice = products.sort((a, b) => a.price - b.price);
// console.log(sorted_productsByPrice);

// //slice
// const sliced_products0_2 = products.slice(0, 2);
// console.log(sliced_products0_2);
// //splice
// spliced_products1_1 = products.splice(1, 1);
// console.log(spliced_products1_1);

// //flat
// const nested = [
//   [1, 2],
//   [3, 4],
//   [4, 5],
// ];
// console.log(nested.flat());

//Object functions

console.log("Key Name from the products[0] are" + Object.keys(products[0]));
console.log("\nValues from the products[0] are " + Object.values(products[0]));
console.log(
  "\nEntries from the products[0] are " + Object.entries(products[0])
);
