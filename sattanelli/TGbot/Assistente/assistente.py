from telegram import Update
from telegram.ext import ApplicationBuilder, CommandHandler, ContextTypes, MessageHandler, filters
from telegram import ReplyKeyboardMarkup, ReplyKeyboardRemove, Update, ForceReply
import datetime
import random
from GameMatch import GameMatch
import logging
import time

token = "5856690695:AAFCu79afxUTsFe8eaRIq86gcLb3_21MwfQ"
paypal_link = "https://www.paypal.me/mmarco93"
iban1 = "IT89N0306953740100000001568"
iban2 = "IT53H0329601601000067307746"
tournament_status = False
players = []
max_players = 8
bracket = []

userID1 = 833945482 #myself
userID2 = 462946171 #rei
userID3 = 1489012142 #sara
userID = None

# Enable logging
logging.basicConfig(
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s",
    level=logging.INFO
)
logger = logging.getLogger(__name__)

async def start(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    user = update.effective_user
    await update.message.reply_html(
        rf"CIAOOOOOOO {user.mention_html()}! Per iniziare, digita /help :)",
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
    await update.message.reply_text("COMANDI:\n\n/start ---> Inizia la navigazione\n/help ---> Lista dei comandi\n/version ---> Versione del BOT\n\n/paypal ---> paypal address\n/iban ---> Iban adrreses\n/play ---> partecipa ad una partita (funziona solo se un torneo è attivo)\n/chat ---> richiesta di chat con Marco")
    await context.bot.send_message(chat_id=userID1, text="HELP: " + username_text)

async def version(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    await update.message.reply_text("BOT Version:\nV1.3\n\n\nContatta il mio creatore: t.me/warmcloth")

async def paypal(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    await update.message.reply_text(paypal_link)

async def iban(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    await update.message.reply_text("Conto principale:\n" + iban1 + "\n\nConto secondario:\n" + iban2)

async def start_tournament(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    global tournament_status
    tournament_status = True
    await update.message.reply_text("Tournament mode: Online")

async def stop_tournament(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    global tournament_status
    tournament_status = False
    await update.message.reply_text("Tournament mode: Offline")

async def status_tournament(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    t = ""
    for player in players:
        t += player
        t += "\n"
    await update.message.reply_text("Tournament status: " + str(tournament_status) + "\nPlayers number: " + str(len(players)) + "\nPlayers:\n" + t)

async def play(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    chat_id = update.message.chat_id
    username = update.message.from_user.username
    if(len(players) < max_players and tournament_status):
        players.append(username + "#" + str(chat_id))
        print("player number "+ str(len(players)) + "/" + str(max_players))
        if(len(players) == max_players):
            build_bracket()
        await update.message.reply_text("You are the player number "+ str(len(players)) + "/" + str(max_players))
    elif(tournament_status):
        await update.message.reply_text("this game is full, wait the next one")
    else:
        await update.message.reply_text("Tournament system is offline")

def build_bracket():
    global players, bracket
    dates = gen_dates(max_players//2, 2)
    random.shuffle(players)
    bracket = [None] * int(max_players//2)
    for i in range(len(bracket)):
        bracket[i] = GameMatch(players[i*2], players[i*2+1], i, dates[i])
    for match in bracket:
        match.print()

def gen_dates(len, delta):
    today = datetime.date.today()
    delta = datetime.timedelta(days=delta)
    dates = []
    for i in range(len):
        date = today + delta * (i +1)
        dates.append(date)
    return dates

async def echo(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    if(update.message.chat_id == userID1):
        await context.bot.send_message(text=(update.effective_user.first_name + ":\n" + update.message.text), chat_id=userID)
    elif(update.message.chat_id == userID):
        await context.bot.send_message(text=(update.effective_user.first_name + ":\n" + update.message.text), chat_id=userID1)
    else:
        await context.bot.send_message(text="/help per la lista dei comandi\n/chat per richiedere di parlare con Marco", chat_id=update.message.chat_id)

async def setuser(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    global userID
    userID = int(context.args[0])
    await update.message.reply_text("User " + str(userID) + " setted")
    await context.bot.send_message(text="chat avviata", chat_id=userID)

async def chat(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    await context.bot.send_message(text=(update.effective_user.first_name + "#" + str(update.message.chat_id) + ": vuole chattare"), chat_id=userID1)

async def mmlr(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    for i in range(0, 5000):
        print("\u2764\ufe0f")
        time.sleep(2)
        await context.bot.send_message(text="\u2764\ufe0f", chat_id=userID1)
        time.sleep(2)
        await context.bot.send_message(text="\u2764\ufe0f", chat_id=1155637834)

async def hello(update: Update, context: ContextTypes.DEFAULT_TYPE) -> None:
    await update.message.reply_text(f'Hello {update.effective_user.first_name}')

bot = ApplicationBuilder().token(token).build()
bot.add_handler(CommandHandler("start", start))
bot.add_handler(CommandHandler("help", help))
bot.add_handler(CommandHandler("version", version))
bot.add_handler(CommandHandler("paypal", paypal))
bot.add_handler(CommandHandler("iban", iban))
bot.add_handler(CommandHandler("start_tournament", start_tournament))
bot.add_handler(CommandHandler("stop_tournament", stop_tournament))
bot.add_handler(CommandHandler("status_tournament", status_tournament))
bot.add_handler(CommandHandler("play", play))
bot.add_handler(CommandHandler("setuser", setuser))
bot.add_handler(CommandHandler("chat", chat))
bot.add_handler(CommandHandler("MMLR", mmlr))

bot.add_handler(MessageHandler(filters.TEXT & ~filters.COMMAND, echo))

bot.run_polling()
