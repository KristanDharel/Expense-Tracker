﻿using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using ADCourseWork.Services;

namespace ADCourseWork
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
			builder.Services.AddMauiBlazorWebView();
			builder.Services.AddSingleton<IUserService, UserService>();
			builder.Services.AddSingleton<ICashflows, CashFlowService>();
            builder.Services.AddSingleton<IDebtService, DebtService>();

            builder.Services.AddSingleton<AuthentucationStateService>();



#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
			builder.Logging.AddDebug();
			builder.Services.AddMudServices();

#endif

			return builder.Build();
		}
	}
}
