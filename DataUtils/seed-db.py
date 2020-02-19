import requests
import time
import json
import re

characters = {}
with open("characterData.json", 'r') as f :
    characters = json.loads(f.read())
with open("jwt.key", 'r') as f :
    key = json.loads(f.read())
jwt = key["token"]

num = 0

def to_camel_case(snake_str):
    components = snake_str.split('_')
    return  ''.join(x.title() for x in components)

url = "http://localhost:5500"

for info in characters.values():
    moves = info["moves"]
    info["moves"] = [v for v in moves.values()]
    print(info)
    response = requests.post(url +"/api/character", json=info, headers={'Authorization': 'Bearer '+ jwt})
    print(response.headers)
    print(response.text)
    print(response)
    if not response.ok :
        break

