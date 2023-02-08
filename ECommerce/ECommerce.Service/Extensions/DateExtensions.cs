namespace ECommerce.Service.Extensions
{
    public static class DateExtensions
    {
        public static bool GetHappyHourDiscount(this DateTime currentTime)
        {
            if (currentTime.Hour == 16)
                return true;

            return false;
        }
    }
}
