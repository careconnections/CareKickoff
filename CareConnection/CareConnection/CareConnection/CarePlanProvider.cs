using CareConnection.Core.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CareConnection.Core
{
    public class CarePlanProvider
    {
        private List<CarePlan> _carePlans;
        private CarePlanProvider()
        {
            GetCarePlanList();
        }

        private static CarePlanProvider instance = null;
        public static CarePlanProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarePlanProvider();
                }
                return instance;
            }
        }

        #region private methods
        private void GetCarePlanList()
        {
            string carePlanFileName = "DataFiles.careplans.json";

            var assembly = typeof(CarePlanProvider).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{carePlanFileName}");

            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                _carePlans = JsonConvert.DeserializeObject<List<CarePlan>>(json);
            }
        }
        #endregion

        #region public methods
        public CarePlan GetCarePlanByClient(Clients client)
        {
            CarePlan carePlanForClient = null;

            foreach (CarePlan carePlan in _carePlans)
            {
                if (carePlan.ClientId == client.NativeID)
                {
                    carePlanForClient = carePlan;
                    break;
                }
            }

            return carePlanForClient;
        }

        public Goal GetGoalForCarePlan(CarePlan carePlan, int? carePlanGoalId)
        {
            Goal carePlanGoal = null;
            foreach (Goal goal in carePlan.Goals)
            {
                if (goal.GoalId == carePlanGoalId)
                {
                    carePlanGoal = goal;
                    break;
                }
            }
            return carePlanGoal;
        }
        #endregion
    }
}