const menu = {
  _courses: {
    appetizers: [],
    mains: [],
    desserts: [],
  },
  get appetizers() {
      return this._courses.appetizers;
  },
  get mains() {
      return this._courses.menu;
  },
  get desserts() {
      return this._courses.desserts;
  },
  set appetizers(appetizers){
      this._courses.appetizers = appetizers;
  },
  set main(main){
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
  addDistoCourse(courseName, dishName, dishPrice){
      const dish = {
          name: dishName,
          price: dishPrice,
      };
      return this._courses[courseName].push(dish);
  },
  getRandomeDishFromCourse(courseName){
    const dish = this._courses[courseName];
    const randomIndex = Math.floor(Math.random() * dish.length);
    return dish[randomIndex];
  },
  generateRandomMeal() {
      
    const appetizer = this.getRandomeDishFromCourse('appetizers');    
    const main = this.getRandomeDishFromCourse('main');    
    const dessert = this.getRandomeDishFromCourse('desserts');
    const totalPrice = appetizers.price + main.price + desserts.price;
    return `Your meal is ${appetizer.name}, ${main.name}, and ${dessert.name}, and the total price is ${totalPrice} `;
  }
};

menu.addDistoCourse('appetizers', 'salad', 4.00);
menu.addDistoCourse('appetizers', 'wings', 4.50);
menu.addDistoCourse('appetizers', 'fries', 5.00);

menu.addDistoCourse('main', 'steak', 10.25);
menu.addDistoCourse('main', 'salmon', 7.75);
menu.addDistoCourse('main', 'tofu', 11.20);

menu.addDistoCourse('desserts', 'ice cream', 3.00);
menu.addDistoCourse('desserts', 'coffee', 3.00);
menu.addDistoCourse('desserts', 'cake', 3.25);

const meal = menu.generateRandomMeal();
console.log(meal);