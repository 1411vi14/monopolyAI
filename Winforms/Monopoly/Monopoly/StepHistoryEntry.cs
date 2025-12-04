using System.Collections.Generic;

namespace Monopoly
{
    public class StepHistoryEntry
    {
        public List<string> Entries { get;private set; } = new List<string>();

        public StepHistoryEntry()
        {

        }

        public void AddEntry(string entry)
        { 
            Entries.Add(entry);
        }

        public override string ToString()
        {
            string text = "";

            foreach (string entry in Entries)
            {
                if (text != "")
                    text += "\n";

                text += entry;
            }

            return text;
        }

    }
}
