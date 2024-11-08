namespace Homework15.Middleware
{
    public class BookingNotAllowed
    {
        private readonly RequestDelegate _next;
        public BookingNotAllowed(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke( HttpContext context, IConfiguration config)
        {
            var notAllowed = config.GetSection("Restrictions").GetChildren().FirstOrDefault(x => x.Key == "BookingNotAllowed");
            if (bool.Parse(notAllowed.Value))
            {
                context.Response.WriteAsync("you are not allowed to book a visit!");
                return;
            }
                await _next(context);
            
        }
    }
}
