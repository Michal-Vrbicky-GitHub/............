# -*- coding: utf-8 -*-

import argparse
from PIL import Image, ImageDraw, ImageFont

def main(image_path, text, font_path, font_size, text_x, text_y, output_path):
    # Load the original image
    original_image = Image.open(image_path).convert("RGBA")
    
    # Create a transparent image with the same size as the original
    transparent_image = Image.new("RGBA", original_image.size, (0, 0, 0, 0))
    
    # Draw text on the transparent image
    draw = ImageDraw.Draw(transparent_image)
    font = ImageFont.truetype(font_path, font_size)
    draw.text((text_x, text_y), text, font=font, fill="white")
    
    # Combine the original image with the transparent text image
    final_image = Image.alpha_composite(original_image, transparent_image)
    
    # Save the final image
    final_image.save(output_path)
    print(f"Image with text overlay saved to {output_path}")

def get_user_input():
    image_path = input("Enter the path to the input image: ")
    text = input("Enter the text to draw on the image: ")
    font_path = input("Enter the path to the TTF font file: ")
    font_size = int(input("Enter the font size for the text: "))
    text_x = int(input("Enter the X coordinate for the text position: "))
    text_y = int(input("Enter the Y coordinate for the text position: "))
    output_path = input("Enter the path to save the image with text overlay: ")
    return image_path, text, font_path, font_size, text_x, text_y, output_path

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Overlay text on an image with transparency.")
    parser.add_argument("--image_path", help="Path to the input image")
    parser.add_argument("--text", help="Text to draw on the image")
    parser.add_argument("--font_path", help="Path to the TTF font file")
    parser.add_argument("--font_size", type=int, help="Font size for the text")
    parser.add_argument("--text_x", type=int, help="X coordinate for the text position")
    parser.add_argument("--text_y", type=int, help="Y coordinate for the text position")
    parser.add_argument("--output_path", help="Path to save the image with text overlay")
    
    args = parser.parse_args()
    
    if not (args.image_path and args.text and args.font_path and args.font_size and args.text_x is not None and args.text_y is not None and args.output_path):
        print("Some arguments are missing. Switching to interactive mode.")
        args.image_path, args.text, args.font_path, args.font_size, args.text_x, args.text_y, args.output_path = get_user_input()
    
    main(args.image_path, args.text, args.font_path, args.font_size, args.text_x, args.text_y, args.output_path)
