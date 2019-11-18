import requests
import time
import json
import re

with open("jwt.key", 'r') as f :
    key = json.loads(f.read())
jwt = key["token"]

response = requests.post("http://localhost:5000/api/auth/roles", json="{'username':'test','password':'testtest','code':'nice try fbi'}",headers={'Authorization': 'Bearer '+ jwt})
print(response)
print(response.headers)
print(response.text)
