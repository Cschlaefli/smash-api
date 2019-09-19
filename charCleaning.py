import requests
import time
import json
import re



characters = {}
with open("moveList.json", 'r') as f :
    characters = json.loads(f.read())

char_out = []

for char,info in characters.items():
    move_out = {}
    move_out["_id"] = char
    for cat, moves in info.items() :
        if cat == "misc" :
            stats = {}
            for k,v in moves.items() :
                st = v
                if k == "Fall Speed / Fast Fall Speed":
                    st = st.split("/")
                    stats["fall_speed"] = st[0].strip()
                    stats["fast_fall"] = st[1].strip()
                else :
                    key = re.sub(r'\([^)]*\)', '', k).strip()
                    key = key.lower().replace(" " , "_")
                    stats[key] = re.sub(r'[a-z]|(\([^)]*\))', '', v).strip()

            move_out["stats"] = stats
        else :
            for k,v in moves.items() :
                move_out[k] = v
                v["type"] = cat
                for key, text in v.items() :
                    if text :
                        t = text.strip().replace(u"\u2014", "-").replace(u"\u2019", "'").replace(u"\u2013", "-")
                        if u"\u00af\\_(\u30c4)_/\u00af" == t : t = None
                        v[key] = t
    char_out.append(move_out)

with open("cleanedMoves.json", 'w') as f :
    f.write(json.dumps(char_out, indent=4))



