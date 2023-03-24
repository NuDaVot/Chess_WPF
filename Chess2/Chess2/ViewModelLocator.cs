namespace Chess2
{
    internal class ViewModelLocator
    {
		private static ServiceProvider? _provider;
		public static IConfiguration? _configuration;
		public static void Init()
		{
			//var builder = new ConfigurationBuilder()
			//.SetBasePath(Directory.GetCurrentDirectory())
			//.AddJsonFile("appsettings.json");
			//_configuration = builder.Build(); // БД

			var services = new ServiceCollection();

			#region ViewModel

			services.AddTransient<MainWindowViewModel>();
			services.AddTransient<MenuAViewModel>();
			services.AddTransient<MenuViewModel>();// Модели страниц
			services.AddTransient<ProfileSetViewModel>();
			services.AddTransient<ProfileViewModel>();
			services.AddTransient<SearchViewModel>();
			services.AddTransient<SignInViewModel>();
			services.AddTransient<SignUpViewModel>();

			#endregion

			#region Connection

			//services.AddDbContext<TradeContext>(options =>
			//{
			//	var conn = _configuration.GetConnectionString("LocalConnection");
			//	options.UseMySql(conn, ServerVersion.AutoDetect(conn));
			//}, ServiceLifetime.Singleton); // Подключение к БД

			#endregion

			#region Services

			services.AddSingleton<PageService>();
			//services.AddSingleton<UserService>();
			//services.AddSingleton<ProductService>();

			#endregion

			_provider = services.BuildServiceProvider();

		}
		public MainWindowViewModel? MainWindowViewModel => _provider?.GetRequiredService<MainWindowViewModel>();
		public MenuViewModel? MenuViewModel => _provider?.GetRequiredService<MenuViewModel>();
		public MenuAViewModel? MenuAViewModel => _provider?.GetRequiredService<MenuAViewModel>();
		public ProfileSetViewModel? ProfileSetViewModel => _provider?.GetRequiredService<ProfileSetViewModel>();
		public ProfileViewModel? ProfileAViewModel => _provider?.GetRequiredService<ProfileViewModel>();
		public SearchViewModel? SearchViewModel => _provider?.GetRequiredService<SearchViewModel>();
		public SignInViewModel? SignInViewModel => _provider?.GetRequiredService<SignInViewModel>();
		public SignUpViewModel? SignUpViewModel => _provider?.GetRequiredService<SignUpViewModel>();
	}
}
