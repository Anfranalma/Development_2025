medical_data = \
"""Marina Allison   ,27   ,   31.1 , 
#7010.0   ;Markus Valdez   ,   30, 
22.4,   #4050.0 ;Connie Ballard ,43 
,   25.3 , #12060.0 ;Darnell Weber   
,   35   , 20.6   , #7500.0;
Sylvie Charles   ,22, 22.1 
,#3022.0   ;   Vinay Padilla,24,   
26.9 ,#4620.0 ;Meredith Santiago, 51   , 
29.3 ,#16330.0;   Andre Mccarty, 
19,22.7 , #2900.0 ; 
Lorena Hodson ,65, 33.1 , #19370.0; 
Isaac Vu ,34, 24.8,   #7045.0"""

# Add your code here
#print(medical_data)
updated_medical_data = medical_data.replace('#','$')
#print(updated_medical_data)
num_records =0
for item in updated_medical_data:
  if item=='$':
    num_records+=1

print("There are "+str(num_records)+" medical records in the data.")

medical_data_split = updated_medical_data.split(";")
#print(medical_data_split)
medical_records=[]
for item in medical_data_split:
  medical_records.append(item.split(','))

#print(medical_records)
medical_records_clean = []
for item in medical_records:
  record_clean = []
  for this in item:
    record_clean.append(this.strip())
  medical_records_clean.append(record_clean)

print(medical_records_clean)

for record in medical_records_clean:
  record[0]=record[0].upper()
  print(record[0])

names =[]
ages =[]
bmis =[]
insurance_costs =[]
for item in medical_records_clean:
  names.append(item[0])
  ages.append(item[1])
  bmis.append(item[2])
  insurance_costs.append(item[3])

print(names)
print(ages)
print(bmis)
print(insurance_costs)

total_bmi=0
for item in bmis:
  total_bmi=total_bmi+float(item)

average_bmi = total_bmi / len(bmis)

print("Average BMI: "+str(round(average_bmi,1)))
insurance_costs_clean=[]
for item in insurance_costs:
  insurance_costs_clean.append(item.replace('$',''))

print(insurance_costs_clean)

average_insurance_cost =0
total_insurance_cost =0
for item in insurance_costs_clean:
  total_insurance_cost+=float(item)

print(total_insurance_cost)
averange_insuarence_cost = total_insurance_cost / len(insurance_costs_clean)
print(averange_insuarence_cost)

new_result = list(zip(names,ages,bmis,insurance_costs))
message = ""
for item in new_result:
  print(item[0] +" is " + item[1] + " years old with a BMI of " + item[2] + " and a insuarance cost of " + item[3])


