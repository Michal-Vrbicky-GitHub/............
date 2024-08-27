from PIL import Image, ImageDraw, ImageFont, ImageChops

def create_text_from_image(image_path, font_path, text, text_height_percentage, x_percentage, y_percentage, output_path):
    # Open the original image
    image = Image.open(image_path).convert("RGBA")
    image_width, image_height = image.size

    # Create a mask image for the text
    mask = Image.new("L", (image_width, image_height), 0)
    draw = ImageDraw.Draw(mask)
    
    # Calculate text size
    text_height = int(image_height * (text_height_percentage / 100))
    
    # Load a font
    font = ImageFont.truetype(font_path, text_height)
    
    # Calculate text position
    x = int(image_width * (x_percentage / 100))
    y = int(image_height * (y_percentage / 100))
    
    # Add text to mask
    draw.text((x, y), text, font=font, fill=255)
    
    # Apply the mask to the image to extract text
    mask_rgba = Image.merge("RGBA", (mask, mask, mask, mask))
    text_image = ImageChops.multiply(image, mask_rgba)
    
    # Save the new image
    text_image.save(output_path)

# Example usage
image_path = "Runway invclr.PNG"  # Path to the input image
font_path = "Roboto-Black.ttf"  # Path to the custom TTF font
text = "Mapa 1"
text_height_percentage = 11  # Text height as 10% of the image height
x_percentage = 4  # Text position at 20% of the image width
y_percentage = 77  # Text position at 30% of the image height
output_path = "invtxt.PNG"

create_text_from_image(image_path, font_path, text, text_height_percentage, x_percentage, y_percentage, output_path)
