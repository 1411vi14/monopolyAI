using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Controller
    {
        public Game Game { get;private set; }
        private bool HasToStop { get; set; } = false;

        public Controller(Setting setting)
        {
            try
            {
				Game = new Game(setting);
            }
            catch (Exception ex)
            {
                Viewer.ShowError(ex.Message);
                return;
            }

            Viewer.ClearDataTable();
            Viewer.UpdateView(Game);
        }

        public bool NextStep()
        {
			Game.Status = Game.Stati.Running;
            if (!Game.NextStep())
            {
                Viewer.ShowError(Game.Error);
				Game.Status = Game.Stati.Standby;
                return false;
            }

            Viewer.UpdateView(Game);
			Game.Status = Game.Stati.Standby;
            return true;
        }

        public bool StartAutoRun(bool watching)
        {
            if (Game.Status is not Game.Stati.Standby)
                return false;
			Game.Status = Game.Stati.Running;
			Task.Run(() => TaskAutoRun(watching));
            return true;
        }

        private Task TaskAutoRun(bool watching)
        {
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
            return Task.CompletedTask;
        }

        public bool StopAutoRun()
        {
            HasToStop = true;
			Game.Status = Game.Stati.Standby;
			return true;
        }

    }
}