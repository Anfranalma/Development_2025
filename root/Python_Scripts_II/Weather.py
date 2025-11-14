# import requests
# from bs4 import BeautifulSoup
# from win10toast import ToastNotifier

# n = ToastNotifier()

# def getdata(url):
#     r = requests.get(url)
#     return r.text

# htmldata = getdata("https://weather.com/en-IN/weather/today/l/45.50,-73.58?par=google")
# soup = BeautifulSoup(htmldata, 'html.parser')
# #print(soup.prettify())

# current_temp = soup.find_all("span", class_= "_-_-components-src-organism-CurrentConditions-CurrentConditions--tempValue--MHmYY") 
# chances_rain = soup.find_all("span", class_="_-_-component-src-organism-CurrentConditions-CurrentConditions--precipValue--2aJSf")
# temp = (str(current_temp))
# temp_rain=str(chances_rain)

# result = "Current Temp "+ temp[128:9] + " in Montreal,QC,CA" + "\n" + temp_rain[131:-14]
# n.show_toast("Weather update", result, duration=10)

import requests
from bs4 import BeautifulSoup
from win10toast import ToastNotifier

n = ToastNotifier()

def getdata(url):
    try:
        r = requests.get(url)
        r.raise_for_status()
        return r.text
    except requests.exceptions.RequestException as e:
        print(f"Error fetching data: {e}")
        return None

def parse_weather_data(htmldata):
    if htmldata is None:
        return None

    soup = BeautifulSoup(htmldata, 'html.parser')
    
    # Update the tags/classes to reflect a more stable approach (these classes might change over time)
    temp_element = soup.find("span", class_="CurrentConditions--tempValue--MHmYY")
    rain_element = soup.find("span", class_="CurrentConditions--precipValue--2aJSf")
    
    if temp_element and rain_element:
        current_temp = temp_element.text
        chances_rain = rain_element.text
        return f"Current Temperature: {current_temp} in Montreal, QC, CA\nChances of Rain: {chances_rain}"
    else:
        return "Weather data could not be retrieved."

# Get weather data from URL
htmldata = getdata("https://weather.com/en-IN/weather/today/l/45.50,-73.58")
weather_result = parse_weather_data(htmldata)

if weather_result:
    # Show the toast notification
    n.show_toast("Weather Update", weather_result, duration=10)
