﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MemoApp.Models
{
    /// <summary>
    /// 메모앱(MemoApp) 관련 의존성(종속성) 주입 관련 코드만 따로 모아서 관리 
    /// </summary>
    public static class MemoAppExtensions
    {
        public static void AddDependencyInjectionContainerForMemoApp(this IServiceCollection services, IConfiguration configuration)
        {
            // MemoAppDbContext.cs Inject: New DbContext Add
            services.AddEntityFrameworkSqlServer().AddDbContext<MemoAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            // IMemoRepository.cs Inject: DI Container에 서비스(리포지토리) 등록 
            services.AddTransient<IMemoRepository, MemoRepository>();
        }
    }
}
