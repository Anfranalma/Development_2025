names = ["Mohamed", "Sara", "Xia", "Paul", "Valentina", "Jide", "Aaron", "Emily", "Nikita", "Paul"]
insurance_costs = [13262.0, 4816.0, 6839.0, 5054.0, 14724.0, 5360.0, 7640.0, 6072.0, 2750.0, 12064.0]

# Add your code here
names.append("Priscila")
insurance_costs.append(8320.0)
medical_records= list(zip(names,insurance_costs))

print(medical_records)
num_medical_records=len(medical_records)
print("There are " +str(num_medical_records)+" medical records.")
first_medical_record=medical_records[0]
print("Here is the first medical record: "+str(first_medical_record))
def takesecond(lst):
  return lst[1]
medical_records_sorted=sorted(medical_records, key=takesecond)
print("Here are the medical records sorted by insurance costs: " +str(medical_records_sorted))
cheapest_three = medical_records_sorted[:3]
print("Here are the three cheapes insurance costs in our medical records: "+str(cheapest_three))
pricest_three = medical_records_sorted[-3:]
print("Here are the three cheapes insurance costs in our medical records: "+str(pricest_three))
ocurrences_paul = names.count("Paul")
print("There are " +str(ocurrences_paul)+" individuals with the name Paul in our medical recores.")
def takefirst(lst):
  return lst[0]
medical_records_sorted_by_name = sorted(medical_records, key=takefirst)
print(medical_records_sorted_by_name)
middle_five_records=medical_records_sorted_by_name[3:8]
print(middle_five_records)

