from countryinfo import CountryInfo
country = CountryInfo(input("Enter Country Name: "))

information = {
    "Country": country.name(),
    "Capital": country.capital(),
    "Population": country.population(),
    "Area (in square kilometers)": country.area(),
    "Region" : country.region(),
    "Subregion" : country.subregion(),
    "Demonym" :country.demonym(),
    "Currency": country.currencies(),
    "Language": country.languages(),
    "Borders": country.borders()
}

for country in information.items():
    print(f"{country[0]}: {country[1]}")