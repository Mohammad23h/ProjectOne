using ProjectOne.Core.Interfaces;
using ProjectOne.Core.Models;
using ProjectOne.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Author> Authors { get; private set; }
        public IBaseRepository<Book> Books { get; private set; }

        public IBaseRepository<WorkoutProgram> WorkoutPrograms { get; private set; }

        public IBaseRepository<Exercise> Exercises { get; private set; }

        public IBaseRepository<Program_Exercise> Program_Exercises { get; private set; }

        public IBaseRepository<TrainingSession> TrainingSessions { get; private set; }

        public IBaseRepository<Nutrition> Nutritions { get; private set; }

        public IBaseRepository<TrainingNutrition> TrainingNutritions { get; private set; }

        public IBaseRepository<FeedBack> FeedBacks { get; private set; }

        public IBaseRepository<ProfileInfo> ProfileInfos { get; private set; }

        public IBaseRepository<Setting> Settings { get; private set; }

        public IBaseRepository<Injurie> Injuries { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Authors = new BaseRepository<Author>(_context);
            Books = new BaseRepository<Book>(_context);
            WorkoutPrograms = new BaseRepository<WorkoutProgram>(_context);
            Exercises = new BaseRepository<Exercise>(_context);
            Program_Exercises = new BaseRepository<Program_Exercise>(_context);
            TrainingSessions = new BaseRepository<TrainingSession>(_context);
            Nutritions = new BaseRepository<Nutrition>(_context);
            TrainingNutritions = new BaseRepository<TrainingNutrition>(_context);
            FeedBacks = new BaseRepository<FeedBack>(_context);
            ProfileInfos = new BaseRepository<ProfileInfo>(_context);
            Settings = new BaseRepository<Setting>(_context);
            Injuries = new BaseRepository<Injurie>(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
    
}
