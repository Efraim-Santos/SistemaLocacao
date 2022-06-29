using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaLocacao.API.Services;
using SistemaLocacao.Core.Notifications;
using SistemaLocacao.Domain.Command.Cliente;
using SistemaLocacao.Domain.Command.Locacao;
using SistemaLocacao.Domain.CommandHandlers.Cliente;
using SistemaLocacao.Domain.CommandHandlers.Locacao;
using SistemaLocacao.Domain.Data;
using SistemaLocacao.Domain.Entity;
using SistemaLocacao.Domain.Queries;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.CommandHandlers;
using SistemaLocacao.ImportacaoArquivo.Filmes.Domain.Commands;
using SistemaLocacao.Infra;
using SistemaLocacao.Infra.Queries;
using SistemaLocacao.Infra.Repository;

namespace SistemaLocacao.API.Configuration
{
    public static class Configurations
    {
        public static void ApíRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SistemaLocacaoContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
        }

        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<SistemaLocacaoContext>();

            //Madiator
            services.AddMediatR(typeof(Startup));

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
            
            //Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IImportacoesArquivoService, ImportacoesArquivoService>();
            services.AddScoped<IRelatoriosService, RelatoriosService>();
            services.AddScoped<IFilmeService, FilmeService>();

            //Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();

            //Commands
            services.AddScoped<IRequestHandler<AdicionarClienteCommand, ClienteEntity>, AdicionarClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarClienteCommand, ClienteEntity>, AtualizarClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverClienteCommand, bool>, RemoverClienteCommandHandler>();
            
            //Commands importacao
            services.AddScoped<IRequestHandler<ImportarFilmesCommand, bool>, ImportarFilmesCommandHandler>();

            //Commands filmes
            services.AddScoped<IRequestHandler<AdicionarFilmeCommand, bool>, AdicionarFilmeCommandHandler>();

            //Commands locacao
            services.AddScoped<IRequestHandler<AdicionarLocacaoCommand, LocacaoEntity>, AdicionarLocacaoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarLocacaoCommand, LocacaoEntity>, AtualizarLocacaoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverLocacaoCommand, bool>, RemoverLocacaoCommandHandler>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Queries
            services.AddScoped<IClienteQuerie, ClienteQuerie>();
            services.AddScoped<IFilmeQuerie, FilmeQuerie>();
            services.AddScoped<ILocacaoQuerie, LocacaoQuerie>();

        }
    }
}
