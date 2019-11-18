import xlrd
import json
import xlutils
from xlutils.copy import copy
import os
import pandas as pd
from googletrans import Translator

trans = Translator()

if not os.path.exists("edited_smashdata.xlsx") :
    wb = xlrd.open_workbook("smashdata.xlsx")

    temp_wb = copy(wb)

    for page_num in range(0, len(wb.sheets())):
        page = wb.sheet_by_index(page_num)
        write_page = temp_wb.get_sheet(page_num)
        for e in page.merged_cells:
            rl,rh,cl, ch = e
            base_val = page.cell_value(rl, cl)
            for r in range(rl, rh) :
                for c in range(cl, ch) :
                    write_page.write(r,c, base_val)
    temp_wb.save("edited_smashdata.xlsx")

wb = xlrd.open_workbook("edited_smashdata.xlsx")
fighters = wb.sheet_by_index(82)
abils = wb.sheet_by_index(83)
attr = wb.sheet_by_index(84)
chars = {}



for row in range(1,fighters.nrows-1) :
    name_jp = fighters.cell_value(row, 1).replace('Mr. ', 'Mr.')
    name = fighters.cell_value(row, 2)
    chars[name_jp] = {}
    chars[name_jp]["name"] = name
    chars[name_jp]["sheet"] = fighters.cell_value(row, 13).replace('Mr. ', 'Mr.')

move_map= {
    "弱攻撃" : "Jab",
    "ダッシュ攻撃" : "Dash Attack",
    "横強" : "Forward Tilt",
    "上強" : "Up Tilt",
    "下強" : "Down Tilt",
    "横スマッシュ" : "Forward Smash",
    "上スマッシュ" : "Up Smash",
    "下スマッシュ" : "Down Smash",
    "空N" : "Neutral Air",
    "空前" : "Forward Air",
    "空後" : "Back Air",
    "空上" : "Up Air",
    "空下" : "Down Air"
}
special_map = {
    "NB" : "Neutral Special",
    "横B" : "Side Special",
    "後B" : "Back Special",
    "上B" : "Up Special",
    "下B" : "Down Special"
}
type_map = {
    "地上" : "Ground",
    "空中": "Air",
}

for name_jp, v in chars.items() :
    page = wb.sheet_by_name(v["sheet"])
    ground_start = 0
    air_start = 0
    special_start = 0
    grab_start = 0
    for x in range(page.nrows-1) :
        name = page.cell_value(x,0)
        if name == "地上攻撃" :
            ground_start = x
        if name  == "空中攻撃" :
            air_start = x
        if name == "必殺ワザ" :
            special_start = x
        if name == "つかみ・投げ" :
            grab_start = x
    #parsing grounds and arials
    moves = {}
    for x in range(ground_start, special_start):
        move_name = page.cell_value(x, 0)
        if not move_name in move_map.keys() :
            continue
        name = move_map[move_name]
        if not name in moves.keys() :
            current_move = {}
            current_move["versions"] =[]
        moves[name] = current_move
        current_move["NameJp"] = move_name
        current_move["Name"] = name
        version = {}
        version["Name"] = page.cell_value(x,1)
        version["Active"] = page.cell_value(x,2)
        version["Duration"] = page.cell_value(x,3)
        version["Base Damage"] = page.cell_value(x,4)
        if x < air_start :
            version["Shield Stun"] = page.cell_value(x,6)
            version["Comment"] = page.cell_value(x,7)
        elif x < special_start :
            version["Shield Stun"] = page.cell_value(x,7)
            version["Landing Lag"] = page.cell_value(x,8)
            version["Landing Lag Frames"] = page.cell_value(x, 9)
            version["Comment"] = page.cell_value(x, 10)
        current_move["versions"].append(version)
    name = ''
    versions = []
    for x in range(special_start, grab_start-2) :
        val = page.cell_value(x,0)
        name_line = False
        for key in special_map.keys() :
            if key in val :
                name_line = True
                name = special_map[key]
                versions = []
                moves[name] = {}
                moves[name]["versions"] = versions
                moves[name]["specialName"] = val[val.find("(")+1:val.find(")")]
                moves[name]["name"] = name
        if not name_line :
            version_name_jp = page.cell_value(x,0) + "," + page.cell_value(x,1)
            #version_name = trans.translate(version_name_jp, src='ja').text
            version = {}
            versions.append(version)
            version["Name"] = version_name_jp
            #version["Name"] = version_name
            version["Active"] = page.cell_value(x, 2)
            version["Duration"] = page.cell_value(x,3)
            version["Base Damage"] = page.cell_value(x,4)
            version["Shield Stun"] = page.cell_value(x,6)
            version["Comment"] = page.cell_value(x,7)

    v["moves"] = moves
    for key, move in moves.items() :
        print(v["name"], key + "\n", move)
    #print(f"ground_start {ground_start}, air_start {air_start}, special_start {special_start}, grab_start {grab_start} ")

for row in range(1, abils.nrows-2) :
    char = chars[abils.cell_value(row, 1)]
    char["jumps"] = abils.cell_value(row,2)
    char["crawl"] = abils.cell_value(row,3)
    if abils.cell_value(row,3) == "" :
        char["crawl"] = False
    char["wallJump"] = abils.cell_value(row,4)
    if abils.cell_value(row,4) == "" :
        char["wallJump"] = False
    char["wallCling"] = abils.cell_value(row,5)
    if abils.cell_value(row,5) == "" :
        char["wallCling"] = False
    char["zair"] = abils.cell_value(row,6)
    if abils.cell_value(row,6) == "" :
        char["zair"] = False
    char["jumpSquat"] = int(abils.cell_value(row,7))
    char["softLanding"] = int(abils.cell_value(row,8))
    char["hardLanding"] = int(abils.cell_value(row,9))
    char["fullDashFrames"] = int(abils.cell_value(row,13))
    char["ShortHop"] = abils.cell_value(row,14)
    char["FullHop"] = abils.cell_value(row,15)
    char["ShortHopFastFall"] = abils.cell_value(row,16)
    char["FullHopFastFall"] = abils.cell_value(row,17)
    char["Weight"] = int(abils.cell_value(row,19))
    char["WalkSpeed"] = abils.cell_value(row,21)
    char["RunSpeed"] = abils.cell_value(row,23)
    char["AirSpeed"] = abils.cell_value(row,25)
    char["FallSpeed"] = abils.cell_value(row,27)
    char["FastFallSpeed"] = abils.cell_value(row,29)

for row in range(1, attr.nrows-2):
    char = chars[attr.cell_value(row, 1)]
    char["initialDash"] = attr.cell_value(row, 3)
    char["acceleration"] = attr.cell_value(row, 5)
    char["friction"] = attr.cell_value(row, 7)
    char["AirAcceleration"] = attr.cell_value(row, 9)
    char["AirFriction"] = attr.cell_value(row, 11)
    char["Gravity"] = attr.cell_value(row, 13)
    char["FullHopInitialSpeed"] = attr.cell_value(row, 15)
    char["FullHopHeight"] = attr.cell_value(row, 17)
    char["ShortHopHeight"] = attr.cell_value(row, 19)
    char["DoubleJumpHeight"] = attr.cell_value(row, 21)

for k, c in chars.items() :
    print(f"key {k}")
    print(c["name"])
    print(c["initialDash"])
    print(c["moves"])

with open("characterData.json", 'w') as f :
    f.write(json.dumps(chars, indent=4))
