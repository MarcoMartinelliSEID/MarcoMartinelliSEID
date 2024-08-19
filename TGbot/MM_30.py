#5856690695:AAFCu79afxUTsFe8eaRIq86gcLb3_21MwfQ
import logging
import json
import threading
import time
import requests
import datetime
from json import dumps
from telegram import __version__ as TG_VER
try:
    from telegram import __version_info__
except ImportError:
    __version_info__ = (0, 0, 0, 0, 0)  # type: ignore[assignment]
if __version_info__ < (20, 0, 0, "alpha", 1):
    raise RuntimeError(
        f"This example is not compatible with your current PTB version {TG_VER}. To view the "
        f"{TG_VER} version of this example, "
        f"visit https://docs.python-telegram-bot.org/en/v{TG_VER}/examples.html"
    )
from telegram.ext import Application, CommandHandler, ContextTypes, MessageHandler, filters
from telegram import ReplyKeyboardMarkup, ReplyKeyboardRemove, Update, ForceReply
from telegram.ext import (
    Application,
    CommandHandler,
    ContextTypes,
    ConversationHandler,
    MessageHandler,
    filters,
    CallbackQueryHandler
)

# Enable logging
logging.basicConfig(
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s", level=logging.INFO
)
logger = logging.getLogger(__name__)

#-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

User_db = []
json1, json2 = 'usernames.json', 'usernames2.json'
GENDER, PHOTO, LOCATION, BIO = range(4)

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    user = update.effective_user
    await update.message.reply_html(
        rf"CIAOOOOOOO {user.mention_html()}! Per iniziare digita /info, per visualizzare la lista dei comandi digita /help :)",
        reply_markup=ForceReply(selective=True),
    )

async def help(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    user = update.message.from_user
    username = update.message.from_user.username
    chat_id = update.message.chat_id
    if username != None:
        username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
    else:
        username_text = user.first_name + ' | ' + str(chat_id)
    await update.message.reply_text("COMANDI:\n\n/start ---> Inizia la navigazione\n/help ---> Lista dei comandi\n/version ---> Versione del BOT\n\n/info ---> Informazioni sull'evento\n/invito ---> Visualizza e rispondi all'invito\n/mioinvito ---> Visualizza la tua risposta\n/miomessaggio ---> Visualizza il tuo messaggio\n/evento ---> Aggiornamenti\n/db ---> Lista partecipanti")
    await context.bot.send_message(chat_id=833945482, text="HELP: " + username_text)

async def version(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    await update.message.reply_text("BOT Version:\nV1.1\n\n\nContatta il mio creatore: t.me/warmcloth")

async def evento(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    user = update.message.from_user
    username = update.message.from_user.username
    chat_id = update.message.chat_id
    if username != None:
        username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
    else:
        username_text = user.first_name + ' | ' + str(chat_id)
    await update.message.reply_text("DATA: Sabato 4 Febbraio\nLUOGO: preserata ALCHIMIA, serata BOLGIA (tavolo Charizard)\nORARIO: ritrovo ore 21:30 Carrara")
    await context.bot.send_message(chat_id=833945482, text="EVENTO: " + username_text)

async def info(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    user = update.message.from_user
    username = update.message.from_user.username
    chat_id = update.message.chat_id
    if username != None:
        username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
    else:
        username_text = user.first_name + ' | ' + str(chat_id)
    await update.message.reply_text('''Se stai parlando con me significa che sei stato/a invitato/a al compleanno di quel coglione del Martinelli. Ottimo!

Ti spiego di cosa si tratta:    
Sabato sera 4 Febbraio, Marco festeggia il suo 30esimo compleanno. Prima si beve qualcosa, poi si va a ballare.
Maggiori informazioni (ad esempio luogo di ritrovo, orario e tappe della serata) sono visualizzabili digitando il comando /evento :)
Tutto ciò che devi fare è confermare la tua presenza tramite il comando:
--> /invito <---

Segui le istruzioni :)
Fallo altrimenti il coglione si offende e ti da della scimmia blaterando cose sul fatto che siamo nel 2023 ecc ecc..''')
    await context.bot.send_message(chat_id=833945482, text="INFO: " + username_text)

async def invito(update: Update, context: ContextTypes.DEFAULT_TYPE) -> int:
    reply_keyboard = [["Ci sarò 😊", "Confermo tra qualche giorno 😐", "non considerarmi 💩"]]

    await update.message.reply_text('''Ciao! ecco qua il tuo invito:
____________________________________
.     ·   +  *  .  .     ·   + 
   .  ⋆  ✧         ⋆      .  ⋆  ✧
   ˚   · .      .        * ⊹ 
  . .    .         ✺  ·  . .    
             * ⊹   .        ·  +
        *  *    .       ⋆       
Ciao amo figa, sei invitato/a al mio 30esimo compleanno!
Se non hai ancora visualizzato le informazioni sulla serata --> /info
altrimenti rispondi qua sotto <3          
.     ·   +  *  .  .     ·   + 
   .  ⋆  ✧         ⋆      .  ⋆  ✧
   ˚   · .      .        * ⊹ 
  . .    .         ✺  ·  . .    
             * ⊹   .        ·  +
        *  *    .       ⋆       
____________________________________
Se non escono le opzioni nella parte inferiore dello schermo, riprova --> /invito
        ''',
        reply_markup=ReplyKeyboardMarkup(
            reply_keyboard, one_time_keyboard=True, input_field_placeholder="CLICCARE BABY:"
        ),
    )

    return GENDER


async def gender(update: Update, context: ContextTypes.DEFAULT_TYPE) -> int:
    user = update.message.from_user
    reply = update.message.text
    chat_id = update.message.chat_id
    logger.info("Reply of %s: %s", user.first_name, update.message.text)
    username = update.message.from_user.username
    if True:
        if username != None:
            username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
        else:
            username_text = user.first_name + ' | ' + str(chat_id)
        try:
            with open(json1) as file:
                data = json.load(file)        
        except json.decoder.JSONDecodeError:
            data = {}
        a = json.loads(dumps(data))
        #print(username + " wrote.")        
        if username_text in a:
            data[username_text] = reply
        else:
            data.update({username_text:"NULL"})
            data[username_text] = reply
        with open(json1, 'w') as file:
            json.dump(data, file, indent=4)
    await update.message.reply_text(
        "Bene! Ho registrato la tua risposta:\n\n<" + update.message.text + ">\n\nSe ti va, puoi lasciare anche una messaggio per marco. Scrivilo ora altrimenti /salta",
        reply_markup=ReplyKeyboardRemove(),
    )
    await context.bot.send_message(chat_id=833945482, text="nuova risposta da parte di: " + username_text + "\n" + reply)

    return BIO


async def bio(update: Update, context: ContextTypes.DEFAULT_TYPE) -> int:
    user = update.message.from_user
    message = update.message.text
    logger.info("Message of %s: %s", user.first_name, update.message.text)
    username = update.message.from_user.username
    chat_id = update.message.chat_id
    if True:
        if username != None:
            username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
        else:
            username_text = user.first_name + ' | ' + str(chat_id)
        try:
            with open(json2) as file:
                data = json.load(file)        
        except json.decoder.JSONDecodeError:
            data = {}
        a = json.loads(dumps(data))
        #print(username + " wrote.")        
        if username_text in a:
            data[username_text] = message
        else:
            data.update({username_text:"NULL"})
            data[username_text] = message
        with open(json2, 'w') as file:
            json.dump(data, file, indent=4)
    await update.message.reply_text("Grazie! Il messaggio sarà inviato a Marco\n\nPuoi rivedere le tue risposte digitando:\n/mioinvito\n/miomessaggio")
    await context.bot.send_message(chat_id=833945482, text="nuovo messaggio da parte di: " + username_text + "\n" + message)

    return ConversationHandler.END


async def salta(update: Update, context: ContextTypes.DEFAULT_TYPE) -> int:
    user = update.message.from_user
    #logger.info("User %s canceled the conversation.", user.first_name)
    await update.message.reply_text(
        "Grazie! :)\n\nPuoi rivedere le tue risposte digitando:\n/mioinvito\n/miomessaggio", reply_markup=ReplyKeyboardRemove()
    )

    return ConversationHandler.END

async def mioinvito(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    chat_id = update.message.chat_id
    user = update.message.from_user
    username = update.message.from_user.username
    if username != None:
        username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
    else:
        username_text = user.first_name + ' | ' + str(chat_id)
    try:
        with open(json1) as file:
            data = json.load(file)        
    except json.decoder.JSONDecodeError:
        data = {}
    arr = json.loads(dumps(data))
    key = username_text
    if key in arr:
        text = key + ":\n" + str(arr[key])
        await context.bot.send_message(chat_id=chat_id, text=text)
    else:
        await context.bot.send_message(chat_id=chat_id, text="Non hai ancora risposto all'invito. Se ci sono problemi scrivi a Marco direttamente. Il suo contatto è visualizzabile digitando:\n/version")

async def miomessaggio(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    chat_id = update.message.chat_id
    user = update.message.from_user
    username = update.message.from_user.username
    if username != None:
        username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
    else:
        username_text = user.first_name + ' | ' + str(chat_id)
    try:
        with open(json2) as file:
            data = json.load(file)        
    except json.decoder.JSONDecodeError:
        data = {}
    arr = json.loads(dumps(data))
    key = username_text
    if key in arr:
        text = key + ":\n" + str(arr[key])
        await context.bot.send_message(chat_id=chat_id, text=text)
    else:
        await context.bot.send_message(chat_id=chat_id, text="Non hai lasciato alcun messaggio per marco :(")

async def db(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    chat_id = update.message.chat_id
    user = update.message.from_user
    username = update.message.from_user.username
    if username != None:
        username_text = user.first_name + ' | ' + username + ' | ' + str(chat_id)
    else:
        username_text = user.first_name + ' | ' + str(chat_id)
    try:
        with open(json1) as file:
            data = json.load(file)        
    except json.decoder.JSONDecodeError:
        data = {}
    arr = json.loads(dumps(data))
    text = ""
    for key, value in arr.items():
        text = text + key + ": " + str(value) + "\n"
    await context.bot.send_message(chat_id=chat_id, text=text)
    await context.bot.send_message(chat_id=833945482, text="DB: " + username_text)

async def db2(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    chat_id = update.message.chat_id
    try:
        with open(json2) as file:
            data = json.load(file)        
    except json.decoder.JSONDecodeError:
        data = {}
    arr = json.loads(dumps(data))
    text = ""
    for key, value in arr.items():
        text = text + key + ": " + str(value) + "\n"
    await context.bot.send_message(chat_id=chat_id, text=text)

'''def check_bot_status():
    while True:
        try:
            response = requests.get("https://api.telegram.org/bot<token>/getMe")
            if response.status_code == 200:
                print("Bot Telegram is working")
            else:
                print("Bot Telegram is not working")
        except:
            print("Bot Telegram is not working")
        time.sleep(10)'''

def main() -> None:
    application = Application.builder().token("5856690695:AAFCu79afxUTsFe8eaRIq86gcLb3_21MwfQ").build()

    application.add_handler(CommandHandler("start", start))
    application.add_handler(CommandHandler("help", help))
    application.add_handler(CommandHandler("version", version))
    application.add_handler(CommandHandler("info", info))
    application.add_handler(CommandHandler("mioinvito", mioinvito))
    application.add_handler(CommandHandler("miomessaggio", miomessaggio))
    application.add_handler(CommandHandler("evento", evento))
    application.add_handler(CommandHandler("db", db))
    application.add_handler(CommandHandler("db2", db2))
    #application.add_handler(CommandHandler("marcorexa93", sendupdate))
    #application.add_handler(MessageHandler(filters.TEXT, save_username))

    conv_handler = ConversationHandler(
        entry_points=[CommandHandler("invito", invito)],
        states={
            GENDER: [MessageHandler(filters.Regex("^(Ci sarò 😊|Confermo tra qualche giorno 😐|non considerarmi 💩)$"), gender), CommandHandler("invito", invito)],
            BIO: [MessageHandler(filters.TEXT & ~filters.COMMAND, bio)],
        },
        fallbacks=[CommandHandler("salta", salta)],
    )

    application.add_handler(conv_handler)
    #thread = threading.Thread(target=check_bot_status)
    #thread.start()
    while True:
        try:
            application.run_polling()
        except:
            time.sleep(10)

if __name__ == "__main__":
    main()