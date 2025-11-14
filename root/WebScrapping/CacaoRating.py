import seaborn
from bs4 import BeautifulSoup
import requests
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np

list=[]

webpage = requests.get("http://content.codecademy.com/courses/beautifulsoup/cacao/index.html")
soup = BeautifulSoup(webpage.content, "html.parser")
ratings=[]
ratings_data= soup.find_all(attrs={"class":"Rating"})

origins=[]
origins_data=soup.find_all(attrs={"class":"Origin"})

ratings=[]

ratings_data=soup.find_all(attrs={"class":"Rating"})

for rating in ratings_data[1:]:
  ratings.append(float(rating.string))


for origin in origins_data[1:]:
  origins.append(origin.string)
#print(origins)

plt.hist(ratings)
plt.show()

company_data=soup.select(".Company")
companies=[]
for company in company_data[1:]:
  companies.append(company.string)
print(companies)

dict={'Company':companies,'Rating':ratings}
df=pd.DataFrame.from_dict(dict)
df.head()

avg_ratings=df.groupby('Company').Rating.mean()
top_ten=avg_ratings.nlargest(10)
print(top_ten)

cocoa_data=soup.select('.CocoaPercent')
cocoa_pcts=[]
for cocoa_pct in cocoa_data[1:]:
  cocoa_pcts.append(int(float(cocoa_pct.string[:-1])))
print(cocoa_pcts)

df['CocoaPercentage']=cocoa_pcts
df.head()

plt.cla()
plt.scatter(df.CocoaPercentage, df.Rating)
z=np.polyfit(df.CocoaPercentage, df.Rating,1)
line_function = np.poly1d(z)
plt.plot(df.CocoaPercentage, line_function(df.CocoaPercentage), "r-")
plt.show()




