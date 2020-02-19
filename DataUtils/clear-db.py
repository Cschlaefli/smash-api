import requests
import time
import json
import re

with open("jwt.key", 'r') as f :
    key = json.loads(f.read())
jwt = key["token"]

for x in range(87, 999) :
    response = requests.delete("http://localhost:5500/api/character/"+str(x),headers={'Authorization': 'Bearer '+ jwt})
    print(response)
    print(response.headers)
    print(response.text)
    if not response.ok :
        break
