using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace StalkerBot
{
    public partial class StalkerBot
    {
        async void textMessage(TelegramBotClient Bot, MessageEventArgs mea)
        {
            var message = mea.Message;

            if (message.Text == null)
                return;

            var ChatId = message.Chat.Id;

            string command = message.Text.ToLower().Replace("@stalkerukrbot", "").Replace("/", "");

            switch (command)
            {
                case "start":
                    await Bot.SendTextMessageAsync(ChatId, "Вітаю! Я @StalkerUkrBot!\nНатисніть '/', щоби обрати команду.\n");// Також ви можете зіграти у гру: cheekibreekisnake.apphb.com");
                    break;

                case "stalker":
                    await Bot.SendTextMessageAsync(ChatId, "Чого сталкерського бажаєте?", replyMarkup: new ReplyKeyboardMarkup(new[] { new KeyboardButton("Анекдот"), new KeyboardButton("Гітарна композиція"), new KeyboardButton("Роздуми") }, true));
                    break;

                case "анекдот":
                    stalker_joke(Bot, ChatId);
                    break;

                case "гітарна композиція":
                    stalker_guitar(Bot, ChatId);
                    break;

                case "роздуми":
                    stalker_phrase(Bot, ChatId);
                    break;

                case "quest":
                    await Bot.SendPhotoAsync(ChatId, new Telegram.Bot.Types.InputFiles.InputFileStream(File.OpenRead(Path.Combine(path, "res", "stalker.jpg"))).Content, replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithCallbackData("Нова гра", "shocnew") }));
                    break;

                case "sendvoice":
                    await Bot.SendTextMessageAsync(ChatId, "Натисніть кнопку та оберіть чат до якого хочете надіслати фразу.", replyMarkup: new InlineKeyboardMarkup(new[] { InlineKeyboardButton.WithSwitchInlineQuery("Надіслати")}));
                    break;

                case "cheekibreeki":
                    //await Bot.SendTextMessageAsync(ChatId, "Гра тут: cheekibreekisnake.apphb.com");
                    break;
            }
        }
    }
}