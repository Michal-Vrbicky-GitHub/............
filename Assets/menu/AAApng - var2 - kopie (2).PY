from PIL import Image, ImageDraw, ImageFont, ImageFilter

def create_text_with_glow(font_path, text, image_width, image_height, text_height_percentage, x_percentage, y_percentage, output_path):
    try:
        # Create a blank image with transparent background
        image = Image.new("RGBA", (image_width, image_height), (255, 255, 255, 0))
        draw = ImageDraw.Draw(image)

        # Calculate text size
        text_height = int(image_height * (text_height_percentage / 100))

        # Load a font
        font = ImageFont.truetype(font_path, text_height)

        # Calculate text position based on percentages from the top-left corner
        x = int(image_width * (x_percentage / 100))
        y = int(image_height * (y_percentage / 100))

        # Create the orange text image
        text_image = Image.new("RGBA", (image_width, image_height), (255, 255, 255, 0))
        draw_text = ImageDraw.Draw(text_image)
        draw_text.text((x, y), text, font=font, fill=(255, 165, 0, 255))  # Oranžová barva

        # Create the glow effect
        glow = text_image.copy()
        for i in range(10):  # Increase the range for a stronger glow
            glow = glow.filter(ImageFilter.GaussianBlur(5))

        # Composite the images
        combined = Image.alpha_composite(image, glow)
        combined = Image.alpha_composite(combined, text_image)

        # Save the new image
        combined.save(output_path, "PNG")
        print(f"Image saved at {output_path}")

    except Exception as e:
        print(f"An error occurred: {e}")

# Example usage
font_path = "good times rg.otf"  # Path to the custom TTF font (change this to the actual path)
text = "Tuto"
image_width = 1616  # Width of the output image
image_height = 910  # Height of the output image
text_height_percentage = 11  # Text height as 10% of the image height
x_percentage = 3.8  # Text position at 50% (center) of the image width
y_percentage = 69  # Text position at 50% (center) of the image height
output_path = "txt2.png"

# Example usagegvuo

create_text_with_glow(font_path, text, image_width, image_height, text_height_percentage, x_percentage, y_percentage, output_path)
