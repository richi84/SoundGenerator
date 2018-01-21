using SoundGenerator.Compose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;

namespace WebService
{
    public class Service : IRestAPI
    {
        int lastID=0;
        List<BuilderTask> taskList = new List<BuilderTask>();
        public String FilePath { set; get; }

        public int Build(SongOption songOption)
        {
            AllowCORS();

            lastID++;
            BuilderTask task = new BuilderTask() { ID = lastID, FilePath = FilePath };
            task.Build(songOption);
            taskList.Add(task);
            return task.ID;
        }

        public double State(String idStr)
        {
            AllowCORS();

            int id = 0;
            int.TryParse(idStr, out id);
            if (id == 0) return 0;
            BuilderTask task = taskList.FirstOrDefault(entry => entry.ID == id);
            if (task == null) return 0;
            return task.GetProgressState();
        }

        private void AllowCORS()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
