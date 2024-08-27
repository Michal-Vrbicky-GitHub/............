from PIL import Image, ImageDraw, ImageFont, ImageChops

def create_text_from_image(image_path, text, text_height_percentage, x_percentage, y_percentage, output_path):
    # Open the original image
    image = Image.open(image_path).convert("RGBA")
    image_width, image_height = image.size

    # Create a mask image for the text
    mask = Image.new("L", (image_width, image_height), 0)
    draw = ImageDraw.Draw(mask)
    
    # Calculate text size
    text_height = int(image_height * (text_height_percentage / 100))
    
    # Load a font
    font = ImageFont.truetype("arial.ttf", text_height)
    
    # Calculate text position
    x = int(image_width * (x_percentage / 100))
    y = int(image_height * (y_percentage / 100))
    
    # Add text to mask
    draw.text((x, y), text, font=font, fill=255)
    
    # Apply the mask to the image to extract text
    text_image = ImageChops.multiply(image, Image.merge("RGBA", (mask, mask, mask, mask)))
    
    # Save the new image
    text_image.save(output_path)

# Example usage
image_path = "G!.png"  # Path to the input image
text = "Sample Text"
text_height_percentage = 10  # Text height as 10% of the image height
x_percentage = 20  # Text position at 20% of the image width
y_percentage = 30  # Text position at 30% of the image height
output_path = "output_image_with_text_extracted.png"

create_text_from_image(image_path, text, text_height_percentage, x_percentage, y_percentage, output_path)
