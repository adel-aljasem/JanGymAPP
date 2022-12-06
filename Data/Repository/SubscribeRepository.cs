using Blazored.Toast.Services;
using JanGym.Pages;
using Microsoft.EntityFrameworkCore;

namespace JanGym.Data.Repository
{
    public class SubscribeRepository
    {
        public ApplicationDbContext ApplicationDb { get; set; }
        public IToastService toastService { get; set; }


        public SubscribeRepository(ApplicationDbContext applicationDb, IToastService toastService)
        {
            ApplicationDb = applicationDb;
            this.toastService = toastService;
        }


        public IEnumerable<SubscribeModel> GetAllTraineeSubscribs()
        {
            return ApplicationDb.SubscribeModel.ToList();

        }


        public SubscribeModel GetById(int id)
        {

            return ApplicationDb.SubscribeModel.Find(id);
        }


        public void AddSubscribe(SubscribeModel subscribeModel)
        {
            try
            {
                ApplicationDb.SubscribeModel.Add(subscribeModel);
                ApplicationDb.SaveChanges();
                toastService.ShowSuccess("تم اضافة الاشتراك بنجاح");
            }
            catch (Exception e)
            {
                toastService.ShowError("يوجد خطأ " + e.Message);

            }
        }

        public bool CheckIfSubsribeIsActiveById(int id)
        {
            var subscribe = ApplicationDb.SubscribeModel.Find(id);

            if(subscribe != null)
            {
                if (SubscribeTimeInFuture(subscribe.DateEnd))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;

        }

        public void Delete(int id)
        {
            try
            {
                var sub = ApplicationDb.SubscribeModel.Find(id);

                ApplicationDb.SubscribeModel.Remove(sub);
                ApplicationDb.SaveChanges();
                toastService.ShowSuccess("تم الحذف بنجاح");

            }
            catch (Exception e)
            {


                toastService.ShowError("يوجد خطأ");

            }
        }

        public void Update(int id)
        {
            try
            {
                var sub = ApplicationDb.SubscribeModel.Find(id);
                if (sub != null)
                {
                    ApplicationDb.SubscribeModel.Update(sub);
                    ApplicationDb.SaveChanges();
                    toastService.ShowSuccess("تم الحفظ بنجاح");
                }
            }
            catch (Exception e)
            {
                toastService.ShowError("يوجد خطأ");

            }

        }



        public bool CheckIfSubscbiveIsActive(List<SubscribeModel> subscribeModel, out SubscribeModel sub)
        {
            sub = new SubscribeModel();


            if (subscribeModel != null)
            {

                if (subscribeModel.Count >= 1)
                {
                    sub = subscribeModel.OrderByDescending(x => x.DateEnd).First();
                }
            }



            if (SubscribeTimeInFuture(sub.DateEnd))
            {

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool SubscribeTimeInFuture(DateTime first)
        {
            var time = DateTime.Now.CompareTo(first);
            if (time < 0 || time == 0)



            {
                return true;
            }
            else
            {
                return false;

            }
        }


    }
}
