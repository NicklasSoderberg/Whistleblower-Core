﻿using System;
using API.Areas.Identity.Data;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(API.Areas.Identity.IdentityHostingStartup))]
namespace API.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = false;
                })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            });
        }
    }
}

