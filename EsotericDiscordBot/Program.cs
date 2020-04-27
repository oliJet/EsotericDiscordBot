using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace EsotericDiscordBot 
{
	public class Program
	{
		private DiscordSocketClient _client;

		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			_client = new DiscordSocketClient();

			_client.Log += Log;
			_client.MessageReceived += MessageReceived;

			// Remember to keep token private or to read it from an 
			// external source! In this case, we are reading the token 
			// from an environment variable.
			await _client.LoginAsync(TokenType.Bot,
				Environment.GetEnvironmentVariable("DiscordToken"));
			await _client.StartAsync();


			// Block this task until the program is closed.
			await Task.Delay(-1);
		}

		private Task Log(Discord.LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}

		//TODO: Update checking username to check for specific user role such as Botdev
		private async Task MessageReceived(SocketMessage message)
		{
			if (message.Content.ToLower() == "!ping" && message.Author.Username == "crybaby claps")
			{
				await message.Channel.SendMessageAsync("Pings are working, your command handler is probably broken you scrub");
			}

			if (message.Content.ToLower() == "!ping")
			{
				await message.Channel.SendMessageAsync("Pong!");
			}

		}

	}
}
