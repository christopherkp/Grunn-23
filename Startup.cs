using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnderwaterBot.DAL;
using UnderwaterBot.Services;
using UnderWaterBot;

namespace UnderwaterBot
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }


        public Startup(string[] args)
        {
            var builder = new ConfigurationBuilder()        
                .SetBasePath(AppContext.BaseDirectory);    
            Configuration = builder.Build();                
        }

        public static async Task RunAsync(string[] args)
        {
            var startup = new Startup(args);
            await startup.RunAsync();
        }

        public async Task RunAsync()
        {
            var services = new ServiceCollection();            
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();    
            provider.GetRequiredService<Command>();     
            provider.GetRequiredService<Logging>();
            await provider.GetRequiredService<Essentials>().StartAsync();       
            await Task.Delay(-1);                               
        }

        private void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IFishRepository, FishRepository>();
           
            services.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {                                       
                LogLevel = LogSeverity.Verbose,     
                MessageCacheSize = 1000             
            }))
            .AddSingleton(new CommandService(new CommandServiceConfig
            {                                       
                DefaultRunMode = RunMode.Async,     
            }))
            .AddSingleton<Command>()         
            .AddSingleton<Essentials>()
            .AddSingleton<FishContext>()
            .AddSingleton<Logging>()                                
            .AddSingleton(Configuration);        
        }
    }
}