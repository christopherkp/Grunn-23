using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace UnderwaterBot.Services
{

        public class Logging
        {
            private readonly DiscordSocketClient _client;
            private readonly CommandService _commands;

            public Logging(DiscordSocketClient client, CommandService commands)
            {
                _client = client;
                _commands = commands;
                _client.Log += OnLogAsync;
                _commands.Log += OnLogAsync;
            }

            private Task OnLogAsync(LogMessage msg)
            {
                string logText = $" [{msg.Severity}] {msg.Source}: {msg.Exception?.ToString() ?? msg.Message}";
                return Console.Out.WriteLineAsync(logText);     
            }
        }
    }