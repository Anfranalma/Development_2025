const groceries = (array) => {
    let newArray = array.map(str => str.item);
    
    if (newArray.length < 2){
      return newArray.join('');
    } else if (newArray.length === 2){
      return newArray.join(' and ');
    } else {
      newArray.splice(newArray.length - 1, 0, 'and');
      return newArray.slice(0, newArray.length -2).join(', ') + ' ' + newArray.slice(newArray.length - 2, newArray.length).join(' ') ;
    }
  }
  
  console.log(groceries([{item: 'Bread'}, {item: 'Butter'}, {item: 'Brocoli'}, {item: 'Spinach'}, {item: 'Salt'}, {item: 'Eggs'}, {item: 'Kale'}] ));