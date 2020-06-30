using System;
using System.IO;
using System.IO.Compression;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace StalkerBot
{
    public partial class StalkerBot
    {
        private TelegramBotClient bot;

        private Random R = new Random();

        private readonly string path = Path.Combine(Path.GetTempPath(), "stalkerresources");

        public void Start() => bot.StartReceiving();

        public void Stop() => bot.StopReceiving();

        public StalkerBot(string TelegramApiToken)
        {
            Directory.CreateDirectory(path);

            File.WriteAllBytes(Path.Combine(path, "res.zip"), Res.stalkerres);
            ZipFile.ExtractToDirectory(Path.Combine(path, "res.zip"), path, true);  

            bot = new TelegramBotClient(TelegramApiToken);

            bot.SetWebhookAsync("");

            bot.OnCallbackQuery += async (object updobj, CallbackQueryEventArgs cqea) =>
            {
                shoc(bot, cqea);
            };

            bot.OnInlineQuery += async (object updobj, InlineQueryEventArgs iqea) =>
            {
                inlineQuery(bot, iqea);
            };

            bot.OnMessage += async (object updobj, MessageEventArgs mea) =>
            {
                if (mea.Message.ReplyToMessage != null && mea.Message.ReplyToMessage.Type == MessageType.Text)
                    replyToMessage(bot, mea);
                else if (mea.Message.Type == MessageType.Text)
                    textMessage(bot, mea);
            };
        }
    }
}