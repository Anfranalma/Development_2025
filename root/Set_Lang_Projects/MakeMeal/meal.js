const menu ={
  _courses: {
    appetizers:[],
    mains:[],
    desserts:[],
  },
  get appetizers(){
    return this._courses.appetizers;
  },
  get mains(){
    return this._courses.mains;
  },
  get desserts(){
    return this._courses.desserts;
  },
  set appetizers(appetizers){
    this._courses.appetizers=appetizers;
  },
  set mains(mains){
    this._courses.mains=mains;
  },
  set desserts(desserts){
    this._courses.desserts=desserts;
  },
  get courses(){
    return {
      appetizers: this.appetizers,
      mains: this.mains,
      desserts: this.desserts,
    };
  },
  addDishToCourse(courseName,dishName,dishPrice){
    const dish={
      name:dishName,
      price:dishPrice,
    };
    return this._courses[courseName].push(dish);
  },
  getRandomDishFromCourse(courseName){
    const dishes = this._courses[courseName];
    const randomIndex = Math.floor(Math.random() * dishes.length);
    return dishes[randomIndex];
    },
  generateRandomMeal(){
    const appetizers=this.getRandomDishFromCourse('appetizers');
    const mains=this.getRandomDishFromCourse('main');
    const desserts=this.getRandomDishFromCourse('desserts');
    const TotalPrice=appetizers.price + mains.price + desserts.price;
    return `Your Meal is ${appetizers.name}, ${mains.name} and ${desserts.name} and the total price is ${TotalPrice}`;
  },
};


menu.addDishToCourse('appetizers','salad',5.00);
menu.addDishToCourse('appetizers','nachos',5.00);
menu.addDishToCourse('appetizers','Tequila Shot',8.00);
menu.addDishToCourse('appetizers','Chirizo and Salsa',10.00);
menu.addDishToCourse('mains','Salmon',24.00);
menu.addDishToCourse('mains','Turkey Chicken',34.00);
menu.addDishToCourse('mains','Tuna Salad and Fries',30.00);
menu.addDishToCourse('mains','Soup and Chicken and Rice',40.00);
menu.addDishToCourse('desserts','Coffee and CheesCake',15.00);
menu.addDishToCourse('desserts','Vanilla IceCream',8.00);
menu.addDishToCourse('desserts','Cookies and Caramel',9.00);

const meal = menu.generateRandomMeal();
console.log(meal);