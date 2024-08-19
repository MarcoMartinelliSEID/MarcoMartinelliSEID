from PIL import Image

def convert_to_pixel_art(image_path, pixel_size):
    image_path = r"C:\Users\marti\Pictures\2.jpg"
    output_path = r"C:\Users\marti\Pictures"
    image = Image.open(image_path)

    # Ridimensiona l'immagine in base alle dimensioni dei pixel desiderate
    width, height = image.size
    new_width = width // pixel_size
    new_height = height // pixel_size
    image = image.resize((new_width, new_height))

    # Riduci la palette dei colori per ottenere l'effetto pixel art
    image = image.quantize(colors=256)

    # Ridimensiona l'immagine alla dimensione originale
    image = image.resize((width, height), resample=Image.NEAREST)

    # Salva l'immagine convertita
    output_path = image_path.split(".")[0] + "_pixel_art.png"
    image.save(output_path)
    print("Immagine convertita in pixel art e salvata come", output_path)

# Esempio di utilizzo
image_path = r"path_all_immagine.jpg" # Inserisci il percorso dell'immagine da convertire (con il prefisso 'r')
pixel_size = 10  # Dimensione dei pixel desiderata

convert_to_pixel_art(image_path, pixel_size)
