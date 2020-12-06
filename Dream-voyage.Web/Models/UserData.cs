using Dream_voyage.BusinessLogic;
using Dream_voyage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dream_voyage.Web.Models
{
    public class UserData
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string ImageFilePath { get; set; }
        public IList<Tour> Tours { get; set; }

        public UserData()
        {
            this.Tours = new List<Tour>();
        }
        public UserData GetUserData(int userId)
        {
            // Пользователь в БД
            DVUser user = new DVUser();
            // Фотография пользователя
            DVUserData dVUserData = new DVUserData();
            // Список туров в БД
            List<Tour> userTours = new List<Tour>();
            // Тур
            Tour tour = new Tour();
            // Тур конкретного пользователя
            UserTour userTour = new UserTour();

            UserData userData = new UserData();

            using (UserContext db = new UserContext())
            {
                // Найти пользователя по логину в БД
                user = db.DVUsers.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    userData.UserId = userId;
                    // Найти все сохраненные пользователем туры, если таковые имеются
                    foreach (UserTour t in db.UserTours)
                    {
                        if (t.UserId == userId)
                        {
                            // Найти тур по ID в БД
                            tour = db.Tours.FirstOrDefault(u => u.TourId == t.TourId);
                            if (tour != null)
                            {
                                // Добавить тур в модель для данных пользователя
                                userData.Tours.Add(tour);
                            }
                        }
                    }
                    // Получить фотографию пользователя
                    dVUserData = db.DVUserDatas.FirstOrDefault(u => u.UserId == userId);
                }   
            }
            if (dVUserData != null)
            {
                userData.ImageFilePath = dVUserData.ImageFile;
            }

            userData.Username = user.Username;

            return userData;
        }
    }
}