using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace UnderwaterBot
{
    public class Command
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        private readonly IConfigurationRoot _config;
        private readonly IServiceProvider _services;

        public Command(
            DiscordSocketClient client,
            CommandService commands,
            IConfigurationRoot config,
            IServiceProvider services)
        {
            _client = client;
            _commands = commands;
            _config = config;
            _services = services;

            _client.MessageReceived += HandleCommandASync;
        }

        private async Task<Task> HandleCommandASync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);

            // Checks if message is from a user
            if (message.Author.IsBot)
                return Task.CompletedTask;
            int argPos = 0;

            // Set prefix here
            if (message.HasStringPrefix(";F ", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);

                // Writes error to console
                if (!result.IsSuccess)

                    Console.WriteLine(result.ErrorReason);
            }

            return Task.CompletedTask;
        }
    }
}
