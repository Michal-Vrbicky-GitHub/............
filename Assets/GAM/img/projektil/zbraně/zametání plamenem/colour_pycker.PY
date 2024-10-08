import webcolors

def closest_color(requested_color):
    min_colors = {}
    # Rozšířený seznam barev podle standardu CSS3
    css3_colors = {
        '#000000': 'black', '#000080': 'navy', '#00008b': 'darkblue', '#0000cd': 'mediumblue', '#0000ff': 'blue',
        '#006400': 'darkgreen', '#008000': 'green', '#008080': 'teal', '#008b8b': 'darkcyan', '#00bfff': 'deepskyblue',
        '#00ced1': 'darkturquoise', '#00fa9a': 'mediumspringgreen', '#00ff00': 'lime', '#00ff7f': 'springgreen', 
        '#00ffff': 'aqua', '#191970': 'midnightblue', '#1e90ff': 'dodgerblue', '#20b2aa': 'lightseagreen',
        '#228b22': 'forestgreen', '#2e8b57': 'seagreen', '#2f4f4f': 'darkslategray', '#32cd32': 'limegreen',
        '#3cb371': 'mediumseagreen', '#40e0d0': 'turquoise', '#4169e1': 'royalblue', '#4682b4': 'steelblue',
        '#483d8b': 'darkslateblue', '#48d1cc': 'mediumturquoise', '#4b0082': 'indigo', '#556b2f': 'darkolivegreen',
        '#5f9ea0': 'cadetblue', '#6495ed': 'cornflowerblue', '#663399': 'rebeccapurple', '#66cdaa': 'mediumaquamarine',
        '#696969': 'dimgray', '#6a5acd': 'slateblue', '#6b8e23': 'olivedrab', '#708090': 'slategray',
        '#778899': 'lightslategray', '#7b68ee': 'mediumslateblue', '#7cfc00': 'lawngreen', '#7fff00': 'chartreuse',
        '#7fffd4': 'aquamarine', '#800000': 'maroon', '#800080': 'purple', '#808000': 'olive', '#808080': 'gray',
        '#87ceeb': 'skyblue', '#87cefa': 'lightskyblue', '#8a2be2': 'blueviolet', '#8b0000': 'darkred', 
        '#8b008b': 'darkmagenta', '#8b4513': 'saddlebrown', '#8fbc8f': 'darkseagreen', '#90ee90': 'lightgreen',
        '#9370db': 'mediumpurple', '#9400d3': 'darkviolet', '#98fb98': 'palegreen', '#9932cc': 'darkorchid',
        '#9acd32': 'yellowgreen', '#a0522d': 'sienna', '#a52a2a': 'brown', '#a9a9a9': 'darkgray', '#add8e6': 'lightblue',
        '#adff2f': 'greenyellow', '#afeeee': 'paleturquoise', '#b0c4de': 'lightsteelblue', '#b0e0e6': 'powderblue',
        '#b22222': 'firebrick', '#b8860b': 'darkgoldenrod', '#ba55d3': 'mediumorchid', '#bc8f8f': 'rosybrown',
        '#bdb76b': 'darkkhaki', '#c0c0c0': 'silver', '#c71585': 'mediumvioletred', '#cd5c5c': 'indianred',
        '#cd853f': 'peru', '#d2691e': 'chocolate', '#d2b48c': 'tan', '#d3d3d3': 'lightgray', '#d8bfd8': 'thistle',
        '#da70d6': 'orchid', '#daa520': 'goldenrod', '#db7093': 'palevioletred', '#dc143c': 'crimson', 
        '#dcdcdc': 'gainsboro', '#dda0dd': 'plum', '#deb887': 'burlywood', '#e0ffff': 'lightcyan', '#e6e6fa': 'lavender',
        '#e9967a': 'darksalmon', '#ee82ee': 'violet', '#eee8aa': 'palegoldenrod', '#f08080': 'lightcoral',
        '#f0e68c': 'khaki', '#f0f8ff': 'aliceblue', '#f0fff0': 'honeydew', '#f0ffff': 'azure', '#f4a460': 'sandybrown',
        '#f5deb3': 'wheat', '#f5f5dc': 'beige', '#f5f5f5': 'whitesmoke', '#f5fffa': 'mintcream', '#f8f8ff': 'ghostwhite',
        '#fa8072': 'salmon', '#faebd7': 'antiquewhite', '#faf0e6': 'linen', '#fafad2': 'lightgoldenrodyellow', 
        '#fdf5e6': 'oldlace', '#ff0000': 'red', '#ff1493': 'deeppink', '#ff4500': 'orangered', '#ff6347': 'tomato',
        '#ff69b4': 'hotpink', '#ff7f50': 'coral', '#ff8c00': 'darkorange', '#ffa07a': 'lightsalmon', '#ffa500': 'orange',
        '#ffb6c1': 'lightpink', '#ffc0cb': 'pink', '#ffd700': 'gold', '#ffdab9': 'peachpuff', '#ffdead': 'navajowhite',
        '#ffe4b5': 'moccasin', '#ffe4c4': 'bisque', '#ffe4e1': 'mistyrose', '#ffebcd': 'blanchedalmond', '#ffefd5': 'papayawhip',
        '#fff0f5': 'lavenderblush', '#fff5ee': 'seashell', '#fff8dc': 'cornsilk', '#fffacd': 'lemonchiffon', '#fffaf0': 'floralwhite',
        '#fffafa': 'snow', '#ffff00': 'yellow', '#ffffe0': 'lightyellow', '#fffff0': 'ivory', '#ffffff': 'white'
    }
    for hex_value, name in css3_colors.items():
        r_c, g_c, b_c = webcolors.hex_to_rgb(hex_value)
        rd = (r_c - requested_color[0]) ** 2
        gd = (g_c - requested_color[1]) ** 2
        bd = (b_c - requested_color[2]) ** 2
        min_colors[(rd + gd + bd)] = name
    return min_colors[min(min_colors.keys())]

def get_color_name_from_hex(hex_code):
    rgb_tuple = webcolors.hex_to_rgb('#' + hex_code)
    try:
        color_name = webcolors.rgb_to_name(rgb_tuple)
    except ValueError:
        color_name = closest_color(rgb_tuple)
    return color_name

while True:
    hex_code = input("Zadej hex barvy bez #: ").strip()
    color_name = get_color_name_from_hex(hex_code)
    print(f"Kolorka #{hex_code} je ynglyš {color_name}.")
    #//time.sleep()
    print("""❌ 🚮Copy
╱╱╱╱╱╱╱╭╮╱╱╭╮
╱╱╱╱╱╱╱┃┃╱╱┃┃
╭━━┳━┳━╯┣━━┫┃
┃╭╮┃╭┫╭╮┃┃━┫┃
┃╰╯┃┃┃╰╯┃┃━┫╰╮
┃╭━┻╯╰━━┻━━┻━╯
┃┃
╰╯↻Copy
██████╗░██████╗░██████╗░███████╗██╗░░░░░
██╔══██╗██╔══██╗██╔══██╗██╔════╝██║░░░░░
██████╔╝██████╔╝██║░░██║█████╗░░██║░░░░░
██╔═══╝░██╔══██╗██║░░██║██╔══╝░░██║░░░░░
██║░░░░░██║░░██║██████╔╝███████╗███████╗
╚═╝░░░░░╚═╝░░╚═╝╚═════╝░╚══════╝╚══════╝↻Copy
█▀█ █▀█ █▀▄ █▀▀ █░░
█▀▀ █▀▄ █▄▀ ██▄ █▄▄↻★ LikeCopy
╋╋╋╋╋╋╋┏┓╋╋┏┓
╋╋╋╋╋╋╋┃┃╋╋┃┃
┏━━┳━┳━┛┣━━┫┃
┃┏┓┃┏┫┏┓┃┃━┫┃
┃┗┛┃┃┃┗┛┃┃━┫┗┓
┃┏━┻┛┗━━┻━━┻━┛
┃┃
┗┛↻★ LikeCopy
───────╔╗──╔╗
───────║║──║║
╔══╦═╦═╝╠══╣║
║╔╗║╔╣╔╗║║═╣║
║╚╝║║║╚╝║║═╣╚╗
║╔═╩╝╚══╩══╩═╝
║║
╚╝↻★ LikeCopy
╱╱╱╱╱╭╮
╭━┳┳┳╯┣━┳╮
┃╋┃╭┫╋┃┻┫╰╮
┃╭┻╯╰━┻━┻━╯
╰╯↻★ LikeCopy
╋╋╋╋╋┏┓
┏━┳┳┳┛┣━┳┓
┃╋┃┏┫╋┃┻┫┗┓
┃┏┻┛┗━┻━┻━┛
┗┛↻★ LikeCopy
─────╔╗
╔═╦╦╦╝╠═╦╗
║╬║╔╣╬║╩╣╚╗
║╔╩╝╚═╩═╩═╝
╚╝↻★ LikeCopy
▛ 🆁 ◗ █☰ ▙▄ ↻★ LikeCopy
█▄─▄▄─█▄─▄▄▀█▄─▄▄▀█▄─▄▄─█▄─▄███
██─▄▄▄██─▄─▄██─██─██─▄█▀██─██▀█
▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀↻★ LikeCopy
███████████████████████████████
█▄─▄▄─█▄─▄▄▀█▄─▄▄▀█▄─▄▄─█▄─▄███
██─▄▄▄██─▄─▄██─██─██─▄█▀██─██▀█
▀▄▄▄▀▀▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▄▄▄▀▄▄▄▄▄▀↻★ LikeCopy
────────────────────────────────────────────────────────────────────────────────
─██████████████─████████████████───████████████───██████████████─██████─────────
─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░░░░░░░████─██░░░░░░░░░░██─██░░██─────────
─██░░██████░░██─██░░████████░░██───██░░████░░░░██─██░░██████████─██░░██─────────
─██░░██──██░░██─██░░██────██░░██───██░░██──██░░██─██░░██─────────██░░██─────────
─██░░██████░░██─██░░████████░░██───██░░██──██░░██─██░░██████████─██░░██─────────
─██░░░░░░░░░░██─██░░░░░░░░░░░░██───██░░██──██░░██─██░░░░░░░░░░██─██░░██─────────
─██░░██████████─██░░██████░░████───██░░██──██░░██─██░░██████████─██░░██─────────
─██░░██─────────██░░██──██░░██─────██░░██──██░░██─██░░██─────────██░░██─────────
─██░░██─────────██░░██──██░░██████─██░░████░░░░██─██░░██████████─██░░██████████─
─██░░██─────────██░░██──██░░░░░░██─██░░░░░░░░████─██░░░░░░░░░░██─██░░░░░░░░░░██─
─██████─────────██████──██████████─████████████───██████████████─██████████████─
────────────────────────────────────────────────────────────────────────────────↻★ LikeCopy
████████████████████████████████████████████████████████████████████████████████
█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░███░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░█████████
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████
█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░█████████
█░░▄▀░░██░░▄▀░░█░░▄▀░░████░░▄▀░░███░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░█████████
█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░█████████
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████
█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░░░███░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░█████████
█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀░░█████████░░▄▀░░█████████
█░░▄▀░░█████████░░▄▀░░██░░▄▀░░░░░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░░░█
█░░▄▀░░█████████░░▄▀░░██░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█
█░░░░░░█████████░░░░░░██░░░░░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█
████████████████████████████████████████████████████████████████████████████████↻★ LikeCopy
█▀▀█ █▀▀█ █▀▀▄ █▀▀ █── 
█──█ █▄▄▀ █──█ █▀▀ █── 
█▀▀▀ ▀─▀▀ ▀▀▀─ ▀▀▀ ▀▀▀↻★ LikeCopy
█▀▀█ █▀▀█ █▀▀▄ █▀▀ █░░ 
█░░█ █▄▄▀ █░░█ █▀▀ █░░ 
█▀▀▀ ▀░▀▀ ▀▀▀░ ▀▀▀ ▀▀▀↻★ LikeCopy
🄿🅁🄳🄴🄻★ LikeCopy
🅿🆁🅳🅴🅻★ LikeCopy
🅟🅡🅓🅔🅛★ LikeCopy
ⓟⓡⓓⓔⓛ★ LikeCopy
🇵​​​​​🇷​​​​​🇩​​​​​🇪​​​​​🇱​​​​​★ LikeCopy
ᴘʀᴅᴇʟ★ LikeCopy
рⷬrͬdͩeͤl+★ LikeCopy
ᵖʳᵈᵉˡ★ LikeCopy
𝕡𝕣𝕕𝕖𝕝★ LikeCopy
ʅǝpɹd★ LikeCopy
p̶r̶d̶e̶l̶+ l̶i̶n̶e̶★ LikeCopy
p̘̟͜r̟̻͖d̡̙̘e̢͖͖l̪̘̝+ m̪̙͇u͕̪̪d͔͜★ LikeCopy
p͒̈́̿r̐̀̚d͌̐e͒̈́͠l͛͒͐+ m̿͒̒u͆̕d͌̾★ LikeCopy
p̵̺͙̘͒͑͘r̴̢̘͚͑͒͘d̴̻͓͖͑͌͒e̵͔͎͎̽͐l̵͇̻̺̒͊͝+ m̵͍̺̼̽́͠u̸͎̦͑̐̕͜d̸͇̻͐͑̈́͜★ LikeCopy
p̷r̷d̷e̷l̷+ l̷i̷n̷e̷s̷★ LikeCopy
p̲r̲d̲e̲l̲+ l̲i̲n̲e̲★ LikeCopy
p⃨r⃨d⃨e⃨l⃨+★ LikeCopy
p̳r̳d̳e̳l̳+★ LikeCopy
p̅r̅d̅e̅l̅+ l̅i̅n̅e̅★ LikeCopy
𝗉𝗋𝖽𝖾𝗅★ LikeCopy
𝘱𝘳𝘥𝘦𝘭★ LikeCopy
𝑝𝑟𝑑𝑒𝑙★ LikeCopy
𝙥𝙧𝙙𝙚𝙡★ LikeCopy
𝒑𝒓𝒅𝒆𝒍★ LikeCopy
𝐩𝐫𝐝𝐞𝐥★ LikeCopy
𝗽𝗿𝗱𝗲𝗹★ LikeCopy
𝚙𝚛𝚍𝚎𝚕★ LikeCopy
𝔭𝔯𝔡𝔢𝔩★ LikeCopy
𝖕𝖗𝖉𝖊𝖑★ LikeCopy
𝓅𝓇𝒹ℯ𝓁★ LikeCopy
𝓹𝓻𝓭𝓮𝓵★ LikeCopy
ⲣꞅⲇⲉ𝓵★ LikeCopy
ｐｒｄｅｌ★ LikeCopy
尸尺ᗪ🝗㇄★ LikeCopy
ρɾԃҽɬ★ LikeCopy
ᕈᖇᖱ∈𝘭★ LikeCopy
ₚᵣdₑₗ""")
    print(f"Kolorka #{hex_code} je ynglyš {color_name}.")