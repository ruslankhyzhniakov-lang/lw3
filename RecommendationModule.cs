using System.Collections.Generic;
using System.Globalization;

namespace LW3.Recommendation
{
    public class Restaurant
    {
        public string Name;
        public string CuisineType;
        public double Rating;
    }

    public class RecommendationModule
    {
        public double CalculateRecommendationScore(double averageRating, bool likedCuisine, decimal price, int reviewCount)
        {
            double score = averageRating * 2;
            if (likedCuisine)
            {
                score = score + 3;
            }
            else
            {
                score = score + 1;
            }

            if (price > 20)
            {
                score = score - 1;
            }
            if (price < 10)
            {
                score = score + 1;
            }

            if (reviewCount == 0)
            {
                score = score - 2;
            }

            return score;
        }

        public string GetRestaurantInfo(string name, string cuisineType, string address, double rating, double averageReview, string mostExpensiveDish)
        {
            return name + " (" + cuisineType + ") at " + address + ". Rating " + rating.ToString(CultureInfo.InvariantCulture) + ". Average review " + averageReview.ToString(CultureInfo.InvariantCulture) + ". Most expensive dish " + mostExpensiveDish + ".";
        }

        public List<Restaurant> SearchRestaurants(List<Restaurant> knownRestaurants, string cuisineType, double minRating)
        {
            List<Restaurant> result = new List<Restaurant>();
            if (knownRestaurants == null)
            {
                return result;
            }

            for (int i = 0; i < knownRestaurants.Count; i++)
            {
                Restaurant restaurant = knownRestaurants[i];
                if (restaurant != null && restaurant.CuisineType == cuisineType && restaurant.Rating >= minRating)
                {
                    result.Add(restaurant);
                }
            }

            return result;
        }
    }
}

