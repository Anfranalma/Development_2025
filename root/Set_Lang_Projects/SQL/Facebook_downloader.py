import requests
from bs4 import BeautifulSoup
import os

url = 'https://www.facebook.com/groups/DeepNetGroup/files/files/'
response = requests.get(url)
soup = BeautifulSoup(response.text, 'html.parser')

os.makedirs('pdfs', exist_ok=True)

for link in soup.find_all('a', href=True):
    if link['href'].endswith('.pdf'):
        pdf_url = link['href']
        if not pdf_url.startswith('http'):
            pdf_url = url + pdf_url.lstrip('/')
        pdf_name = pdf_url.split('/')[-1]
        pdf_data = requests.get(pdf_url).content
        with open(f'pdfs/{pdf_name}', 'wb') as f:
            f.write(pdf_data)
        print(f'Downloaded {pdf_name}')