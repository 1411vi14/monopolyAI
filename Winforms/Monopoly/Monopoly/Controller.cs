using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Controller
    {
        public enum Stati { IsRunning, IsStandby}
        public Game Game { get;private set; }
        public Stati Status { get; private set; } = Stati.IsStandby;
        private bool HasToStop { get; set; } = false;

        public Controller()
        {
            Game game = null;
            try
            {
                game = Game.TryCreateGame();
            }
            catch (Exception ex)
            {
                Viewer.ShowError(ex.Message);
                return;
            }

            Game = game;
            Viewer.UpdateView(Game);
        }

        public bool NextStep()
        {
            Status = Stati.IsRunning;
            if (!Game.NextStep())
            {
                Viewer.ShowError(Game.Error);
                Status = Stati.IsStandby;
                return false;
            }

            Viewer.UpdateView(Game);
            Status = Stati.IsStandby;
            return true;
        }

        public bool StartAutoRun(bool watching)
        {
            if (HasToStop)
                return false;

            Task.Run(() => TaskAutoRun(watching));
            return true;
        }

        private Task TaskAutoRun(bool watching)
        {
            Status = Stati.IsRunning;
            HasToStop = false;
            while (Game.Status != Game.Stati.Finished && !HasToStop)
            {
                if (!Game.NextStep())
                    break;

                if (watching)
                {
                    Thread.Sleep(100);
                    Viewer.UpdateView(Game);
                }
            }

            Viewer.UpdateView(Game);
            Status = Stati.IsStandby;
            return Task.CompletedTask;
        }

        public bool StopAutoRun()
        {
            HasToStop = true;
            return true;
        }

    }
}