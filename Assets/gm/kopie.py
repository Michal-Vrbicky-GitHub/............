from PIL import Image, ImageDraw, ImageSequence
import numpy as np
""":::
from PIL import Image, ImageDraw, ImageSequence
import numpy as np

# Load the image
image_path = "C:\Users\misav.DESKTOP-VFKPUAD\Downloads\plants_vs_zombies_spikeweed_in_game_accurate_hd_by_knockoffbandit_dg8ht1j-414w-2x.png"#◙mntdataplants_vs_zombies_spikeweed_in_game_accurate_hd_by_knockoffbandit_dg8ht1j-414w-2x.png
img = Image.open(image_path)

# Generate a sequence of images to simulate bubbles and a swampy effect
frames = []

# Generate bubble positions and sizes
np.random.seed(42)  # For reproducibility
bubble_positions = [np.random.randint(0, img.size[0], size=(10, 2)) for _ in range(5)]
bubble_sizes = [np.random.randint(5, 20, size=10) for _ in range(5)]

# Create the frames
for i in range(5)
    frame = img.copy()
    draw = ImageDraw.Draw(frame)
    
    for pos, size in zip(bubble_positions[i], bubble_sizes[i])
        x, y = pos
        draw.ellipse((x, y, x+size, y+size), fill=(255, 255, 255, 128))  # Draw semi-transparent bubbles
    
    frames.append(frame)

# Save frames as a GIF
gif_path = mntdataspikeweed_swamp.gif
frames[0].save(gif_path, save_all=True, append_images=frames[1], optimize=False, duration=500, loop=0)

gif_path
"""


# Load the image
image_path = r"C:\Users\misav.DESKTOP-VFKPUAD\Downloads\plants_vs_zombies_spikeweed_in_game_accurate_hd_by_knockoffbandit_dg8ht1j-414w-2x.png"
img = Image.open(image_path)

# Generate a sequence of images to simulate bubbles and a swampy effect
frames = []

# Generate bubble positions and sizes
np.random.seed(42)  # For reproducibility
bubble_positions = [np.random.randint(0, img.size[0], size=(10, 2)) for _ in range(5)]
bubble_sizes = [np.random.randint(5, 20, size=10) for _ in range(5)]

# Create the frames
for i in range(5):
    frame = img.copy()
    draw = ImageDraw.Draw(frame)
    
    for pos, size in zip(bubble_positions[i], bubble_sizes[i]):
        x, y = pos
        draw.ellipse((x, y, x+size, y+size), fill=(255, 255, 255, 128))  # Draw semi-transparent bubbles
    
    frames.append(frame)

# Save frames as a GIF
gif_path = r"D:\jako takový něco\VOŠ\2\Lrrrrrrrr\Pjů\pyčo junyty\2! AAAAA\AAAAAAAA\Assets\gm\spikeweed_swamp.gif"
frames[0].save(gif_path, save_all=True, append_images=frames[1:], optimize=False, duration=500, loop=0)

print(f"GIF saved to {gif_path}")
