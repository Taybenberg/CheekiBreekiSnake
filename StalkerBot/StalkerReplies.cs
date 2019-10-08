using Telegram.Bot;
using Telegram.Bot.Args;

namespace StalkerBot
{
    public partial class StalkerBot
    {
        async void replyToMessage(TelegramBotClient Bot, MessageEventArgs mea)
        {
            var message = mea.Message.ReplyToMessage;
            var reply = mea.Message;

            if (reply.Text == null)
                return;

            switch (reply.Text.ToLower())
            {
                case "анекдот":
                    stalker_joke(Bot, message.Chat.Id);
                    break;

                case "гітарна композиція":
                    stalker_guitar(Bot, message.Chat.Id);
                    break;

                case "роздуми":
                    stalker_phrase(Bot, message.Chat.Id);
                    break;
            }
        }
    }
}