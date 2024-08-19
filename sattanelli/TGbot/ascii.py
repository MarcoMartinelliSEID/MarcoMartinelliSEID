from PIL import Image

ASCII_CHARS = ' .|-_^+|",&#'

def scale_image(image, new_width=100):
    (original_width, original_height) = image.size
    aspect_ratio = original_height/float(original_width)
    new_height = int(aspect_ratio * new_width * 0.55)
    new_image = image.resize((new_width, new_height))
    return new_image

def convert_to_grayscale(image):
    return image.convert('L')

def map_pixels_to_ascii(image, range_width=25):
    pixels = image.getdata()
    ascii_str = ''
    for pixel_value in pixels:
        ascii_str += ASCII_CHARS[pixel_value//range_width]
    return ascii_str

def convert_to_ascii(image_path, new_width=100):
    try:
        image = Image.open(image_path)
    except Exception as e:
        print(e)
        return

    image = scale_image(image, new_width)
    image = convert_to_grayscale(image)
    ascii_str = map_pixels_to_ascii(image)

    img_width = image.width
    ascii_str_len = len(ascii_str)
    ascii_img = ''

    for i in range(0, ascii_str_len, img_width):
        ascii_img += ascii_str[i:i+img_width] + '\n'

    output_path = image_path.split(".")[0] + "_ascii_art.txt"
    with open(output_path, 'w') as f:
        f.write(ascii_img)
    print("Immagine convertita in ASCII art e salvata come", output_path)

# Esempio di utilizzo
image_path = r"C:\Users\marti\Pictures\1.jpg"
output_path = r"C:\Users\marti\Pictures"
new_width = 50  # Larghezza desiderata dell'immagine ASCII

convert_to_ascii(image_path, new_width)
