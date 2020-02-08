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
        readonly string TelegramApiToken;

        Random R = new Random();

        readonly string path = Path.Combine(Path.GetTempPath(), "stalkerresources");

        public StalkerBot(string TelegramApiToken)
        {
            this.TelegramApiToken = TelegramApiToken;

            Directory.CreateDirectory(path);

            File.WriteAllBytes(Path.Combine(path, "res.zip"), Res.stalkerres);
            ZipFile.ExtractToDirectory(Path.Combine(path, "res.zip"), path, true);  

            var Bot = new TelegramBotClient(TelegramApiToken);

            Bot.SetWebhookAsync("");

            Bot.OnCallbackQuery += async (object updobj, CallbackQueryEventArgs cqea) =>
            {
                shoc(Bot, cqea);
            };

            Bot.OnInlineQuery += async (object updobj, InlineQueryEventArgs iqea) =>
            {
                inlineQuery(Bot, iqea);
            };

            Bot.OnMessage += async (object updobj, MessageEventArgs mea) =>
            {
                if (mea.Message.ReplyToMessage != null && mea.Message.ReplyToMessage.Type == MessageType.Text)
                    replyToMessage(Bot, mea);
                else if (mea.Message.Type == MessageType.Text)
                    textMessage(Bot, mea);
            };

            Bot.StartReceiving();
        }
    }
}