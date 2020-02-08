using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace StalkerBot
{
    public partial class StalkerBot
    {
        async void stalker_guitar(TelegramBotClient Bot, Telegram.Bot.Types.ChatId ChatId)
        {
            string folder = path + "/res/shoc/";

            await Bot.SendPhotoAsync(ChatId, new InputFileStream(File.OpenRead(folder + "stalker_novice_" + R.Next(1, 6).ToString() + ".png")).Content);
            await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_" + R.Next(1, 4).ToString() + "/novice/intro_music_" + R.Next(1, 6).ToString() + ".ogg")).Content);
            await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/fire/guitar_" + R.Next(1, 12).ToString() + ".ogg")).Content);
        }

        async void stalker_joke(TelegramBotClient Bot, Telegram.Bot.Types.ChatId ChatId)
        {
            string folder = path + "/res/shoc/";

            await Bot.SendPhotoAsync(ChatId, new InputFileStream(File.OpenRead(folder + "stalker_novice_" + R.Next(1, 6).ToString() + ".png")).Content);

            switch (R.Next(1, 4))
            {
                case 1:
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_1/novice/intro_joke_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_1/novice/joke_" + R.Next(1, 14).ToString() + ".ogg")).Content);
                    break;

                case 2:
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_2/novice/intro_joke_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_2/novice/joke_" + R.Next(1, 16).ToString() + ".ogg")).Content);
                    break;

                case 3:
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_3/novice/intro_joke_" + R.Next(1, 6).ToString() + ".ogg")).Content);
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_3/novice/joke_" + R.Next(1, 14).ToString() + ".ogg")).Content);
                    break;
            }
        }

        async void stalker_phrase(TelegramBotClient Bot, Telegram.Bot.Types.ChatId ChatId)
        {
            string folder = path + "/res/shoc/";

            await Bot.SendPhotoAsync(ChatId, new InputFileStream(File.OpenRead(folder + "stalker_novice_" + R.Next(1, 6).ToString() + ".png")).Content);

            switch (R.Next(1, 4))
            {
                case 1:
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_1/novice/idle_" + R.Next(1, 40).ToString() + ".ogg")).Content);
                    break;

                case 2:
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_2/novice/idle_" + R.Next(1, 39).ToString() + ".ogg")).Content);
                    break;

                case 3:
                    await Bot.SendVoiceAsync(ChatId, new InputFileStream(File.OpenRead(folder + "/stalker_3/novice/idle_" + R.Next(1, 40).ToString() + ".ogg")).Content);
                    break;
            }
        }
    }
}