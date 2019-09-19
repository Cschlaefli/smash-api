import requests
import time
import json
import pandas as pd
from bs4 import BeautifulSoup
from IPython.display import display

url_chars = 'https://ultimateframedata.com'
html = requests.get(url_chars).content
soup_chars = BeautifulSoup(html, 'html.parser')
characters = {}

char_nav = soup_chars.find(id="charList")
#print(char_nav)
for link in char_nav.find_all("a"):
	char_name = link.get("title")
	char_link = url_chars + link.get("href")
	if char_name == 'Stats':
		pass
	else:
		characters[char_name] = char_link

character_list = {}
for k,v in characters.items() :
    time.sleep(.7)
    print(k,v)
    html = requests.get(v).content
    soup = BeautifulSoup(html, 'html.parser')

    categories = {}

    for cat in soup.find_all("h2") :
        category = cat.get("id")
        categories[category] = cat.find_next_sibling("div")

    for category in categories :
        if not category == "misc" :
            temp = categories[category]
            moves = {}
            for movecont in temp.find_all("div" , class_="movecontainer") :
                move_name = movecont.find("div", class_="movename").string.strip()
                stats = {}
                for stat in movecont.find_all("div") :
                    st = stat.string
                    if st : st = st.strip()
                    if st == move_name : continue
                    elif st == "--" :
                        stats[stat.get("class")[0]] = None
                    else :
                        stats[stat.get("class")[0]] = st
                moves[move_name] = stats
            categories[category] = moves
        else :
            temp = categories[category]
            stats = {}
            for stat in temp.div.find_all("div") :
                v = stat.string.split("—")
                stats[v[0].strip()] = v[1].strip()
            categories[category] = stats

    character_list[k] = categories
with open("moveList.json", 'w') as f :
    f.write(json.dumps(character_list, indent=4))

'''
url_chars = 'https://ultimateframedata.com'
html = requests.get(url_chars).content
soup_chars = BeautifulSoup(html, 'html.parser')
characters = {}

char_nav = soup_chars.find(id="charList")
#print(char_nav)
for link in char_nav.find_all("a"):
	char_name = link.get("title")
	char_link = url_chars + link.get("href")
	if char_name == 'Stats':
		pass
	else:
		characters[char_name] = char_link

print(characters)
with open("charlist.json", 'w') as f :
    f.write(json.dumps(characters, indent=4))


url_stats = 'https://ultimateframedata.com/stats.php'
html_stats = requests.get(url_stats).content
soup_stats = BeautifulSoup(html_stats, 'html.parser')
stats = {}

attr_names = [attr.string for attr in soup_stats.find_all("h2")]
attr_indexes = {'Air Acceleration': 3, 'Air Speed': 1, 'Fall Speed': 2, 
		'Weight': 1, 'Dash and Run Speed': 2}
name_cleanup = {'Rosalina': 'Rosalina and Luma', 'Popo': 'Ice Climbers'}
#print(attr_names)
#print(list(attr_indexes.keys()))


i = 0
# loop through each table and grab only the data needed (specified in attr_indexes)
for table in soup_stats.find_all("table"):
	attribute = attr_names[i]

	if attribute in attr_indexes.keys():
		attr_idx = attr_indexes[attribute]
		headers = [th.string.strip() for th in table.find_all("th")]
		char_name_idx = headers.index('Character')

		attr_stats = {}
		for tr in table.find_all("tr"):
			# get character data for a given attribute and clean

			attrs_raw = [td.string for td in tr.find_all("td")]
			attrs = ['' if x is None else x.strip() for x in attrs_raw]

			if attrs:
				char_name = attrs[char_name_idx].strip()
				attr_stats[char_name] = attrs[char_name_idx + attr_idx]
		stats[attribute] = attr_stats
	i += 1

#stats_pandas = pd.DataFrame(stats)
#print(stats)
#print(len(stats))

chars = []
for attribute_name, char_info in stats.items():
	for name in char_info:
		if name not in chars:
			chars.append(name)

print("\nstats char names not in char list:")
for name in chars:
	if name not in list(characters.keys()):
		print(name)

print("\nchar list names not in stats list:")
for name in list(characters.keys()):
	if name not in chars:
		print(name)

data = {'Character': list(characters.keys())}
#data.merge(list(stats[]))
#print(data)
'''
