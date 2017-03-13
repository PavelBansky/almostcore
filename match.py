import requests 

r = requests.get("https://github.com", verify=False)

print r.text
