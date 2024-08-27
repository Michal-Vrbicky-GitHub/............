# -*- coding: utf-8 -*-

#pip install imagemagick
#pip install matplotlib
"""
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation

# Definujeme velikost bažiny
width, height = 10, 10

# Vytvoříme mřížku bažiny
swamp = np.zeros((height, width))

# Náhodně přidáme ostny do mřížky
np.random.seed(0)
spike_positions = np.random.choice([0, 1], size=(height, width), p=[0.8, 0.2])

# Funkce pro aktualizaci animace
def update(frame):
    plt.clf()
    new_spike_positions = (np.random.rand(height, width) < 0.2).astype(int)
    plt.imshow(new_spike_positions, cmap='Greens', interpolation='nearest')
    plt.title('Bažina s pulzujícími ostny')
    plt.axis('off')

# Vytvoření animace
fig = plt.figure()
ani = animation.FuncAnimation(fig, update, frames=20, repeat=True)
plt.show()
""""""
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation

# Definujeme velikost bažiny
width, height = 10, 10

# Funkce pro aktualizaci animace
def update(frame):
    plt.clf()
    new_spike_positions = (np.random.rand(height, width) < 0.2).astype(int)
    plt.imshow(new_spike_positions, cmap='Greens', interpolation='nearest')
    plt.title('Bažina s pulzujícími ostny')
    plt.axis('off')

# Vytvoření animace
fig = plt.figure()
ani = animation.FuncAnimation(fig, update, frames=20, repeat=True)

# Uložit animaci jako GIF
ani.save('pulsating_spikes_swamp.gif', writer='imagemagick')
plt.show()
"""
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation

# Definujeme velikost bažiny
width, height = 20, 20

# Funkce pro aktualizaci animace
def update(frame):
    plt.clf()
    # Generujeme základní bažinu s různými odstíny zelené
    swamp = np.random.rand(height, width) * 0.4 + 0.1  # Základní bažina
    # Přidáme pulzující ostny
    spikes = (np.random.rand(height, width) < 0.2).astype(float)
    spikes_pulse = np.sin(frame / 5) * 0.5 + 0.5  # Pulzující efekt
    swamp += spikes * spikes_pulse
    plt.imshow(swamp, cmap='Greens', interpolation='nearest')
    plt.title('Autentičtější bažina s pulzujícími ostny')
    plt.axis('off')

# Vytvoření animace
fig = plt.figure()
ani = animation.FuncAnimation(fig, update, frames=100, repeat=True)

# Uložit animaci jako GIF
ani.save('authentic_pulsating_spikes_swamp.gif', writer='pillow')
plt.show()
