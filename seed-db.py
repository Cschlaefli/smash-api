import requests
import time
import json
import re

characters = {}
with open("cleanedMoves.json", 'r') as f :
    characters = json.loads(f.read())
with open("jwt.key", 'r') as f :
    key = json.loads(f.read())
jwt = key["token"]

num = 0

def to_camel_case(snake_str):
    components = snake_str.split('_')
    return  ''.join(x.title() for x in components)

url = "http://localhost:5500"

for info in characters:
    num += 1
    char_post = {}
    char_post['Moves'] =  []
    for k, v in info.items() :
        if k == "_id" :
            char_post["Name"] = v
        elif k == "stats" :
            for key, value in v.items() :
                if value != "**" :
                    char_post[to_camel_case(key)] = value
        else :
            move = {}
            move["Name"] = k
            for key, value in v.items() :
                if value : move[key] = value
            char_post['Moves'].append(move)
    print(char_post)
    response = requests.post(url +"/api/character", json=char_post, headers={'Authorization': 'Bearer '+ jwt})
    print(response.headers)
    print(response.text)
    if not response.ok :
        break

