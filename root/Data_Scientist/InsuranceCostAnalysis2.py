# Create calculate_insurance_cost() function below: 
def calculate_insurance_cost(age,sex,bmi,num_of_children,smoker,name="fulano"):
  estimated_cost=250*age - 128*sex + 370*bmi + 425*num_of_children + 24000*smoker - 12500
  return ['The estimated insurance cost for '  +name+ ' is ' +str(estimated_cost)+ 'dollars.',estimated_cost]

def difference_cost(name1,cost1,name2,cost2):
  difference=abs(cost1-cost2)
  print("The insurance cost difference between " +str(name1)+" and "+str(name2)+" is " +str(difference) + " dollars.")
# Initial variables for Maria 


# Estimate Maria's insurance cost
maria_insurance_cost = calculate_insurance_cost(28,0,26.2,3,0,name="Maria")

print(maria_insurance_cost)

# Initial variables for Omar
age = 35
sex = 1 
bmi = 22.2
num_of_children = 0
smoker = 1  

# Estimate Omar's insurance cost 
omar_insurance_cost = calculate_insurance_cost(35,1,22.2,0,1,name="Omar")

print(omar_insurance_cost)

mysql_insurance_cost = calculate_insurance_cost(39,1,30,0,1,name="Angel")
print(mysql_insurance_cost)

difference_cost("maria",maria_insurance_cost[1],"omar",omar_insurance_cost[1])