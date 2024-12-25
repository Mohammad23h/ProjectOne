using ProjectOne.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Book> Books { get; }
        IBaseRepository<WorkoutProgram> WorkoutPrograms { get; }

        IBaseRepository<Exercise> Exercises { get; }

        IBaseRepository<Program_Exercise> Program_Exercises { get; }

        IBaseRepository<TrainingSession> TrainingSessions { get; }

        IBaseRepository<Nutrition> Nutritions { get; }

        IBaseRepository<TrainingNutrition> TrainingNutritions { get; }

        IBaseRepository<FeedBack> FeedBacks { get; }

        IBaseRepository<Injurie> Injuries { get; }

        IBaseRepository<ProfileInfo> ProfileInfos { get; }

        IBaseRepository<Setting> Settings { get; }

        int Complete();
    }
}
