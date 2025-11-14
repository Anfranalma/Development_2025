# Add your code here
def analyse_smoker(smoker_status):
  if smoker_status==1:
    print("To lower your cost, you should consider quitting smoking.")
  else:
    print("Smoking is not an issue for")

def analyse_bmi(bmi_value):
  if bmi_value > 30:
    print("Your BMI is in the obese range. To lower your cost, you should significantly lower your BMI.")
  elif bmi_value >= 25 and bmi_value <= 30:
    print("Your BMI is in the overweight range. To lower your cost, you should lower your BMI.")
  elif bmi_value >= 18.5 and bmi_value < 25:
    print("Your BMI is in a healthy range.")
  elif bmi_value < 18.5:
    print("Your BMI is in the underweight range. Increasing your BMI will not help lower your cost, but it will help improve your health.")
# Function to estimate insurance cost:
def estimate_insurance_cost(name, age, sex, bmi, num_of_children, smoker):
  try:
    estimated_cost = 250*age - 128*sex + 370*bmi + 425*num_of_children + 24000*smoker - 12500
    print(name + "'s Estimated Insurance Cost: " + str(estimated_cost) + " dollars.")
    analyse_smoker(smoker)
    analyse_bmi(bmi)
    if sex in int(range(0,1)):
      return estimated_cost
    else:
      return "Error"
  except TypeError:
    print("A TypeError Ocurred!")
 
# Estimate Keanu's insurance cost
keanu_insurance_cost = estimate_insurance_cost(name = 'Keanu', age = 29, sex = 3, bmi = 26.2, num_of_children = 3, smoker = 1)

mysql_insurance_cost = estimate_insurance_cost(name = "Angel", age = 39, sex =1 , bmi = 28, num_of_children = 0, smoker =1)