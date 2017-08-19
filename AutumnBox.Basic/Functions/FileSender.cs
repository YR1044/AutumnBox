﻿using AutumnBox.Basic.Arg;
using AutumnBox.Basic.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutumnBox.Basic.Functions
{
    /// <summary>
    /// 文件发送器
    /// </summary>
    class FileSender : Function, ICanReturnThreadFunction
    {
        public event EventsHandlers.SimpleFinishEventHandler sendAllFinish;
        public event EventsHandlers.SimpleFinishEventHandler sendSingleFinish;
        public FileSender() : base(FunctionInitType.Adb) { }
        public FileSender(EventsHandlers.SimpleFinishEventHandler sendAllFinishHandler,
            EventsHandlers.SimpleFinishEventHandler sendSingleFinishHandler,
            IArgs args) : base(FunctionInitType.Adb)
        {
            this.sendAllFinish += sendAllFinishHandler;
            this.sendSingleFinish += sendSingleFinishHandler;
            Run(args);
        }
        public Thread Run(IArgs args)
        {
            if (sendAllFinish == null)
            {
                throw new EventNotBoundException();
            }
            mainThread = new Thread(new ParameterizedThreadStart(_Run));
            mainThread.Name = "File Sender Thread";
            mainThread.Start(args);
            return mainThread;
        }
        private void _Run(object args)
        {
            FileArgs _arg = (FileArgs)args;
            string filename;
            string[] x;
            foreach (string filepath in _arg.files)
            {
                x = filepath.Split('\\');
                filename = x[x.Length - 1];
                adb.Execute(_arg.deviceID, $"push \"{filepath}\" /sdcard/{filename}");
                sendSingleFinish?.Invoke();
            }
            sendAllFinish();
        }
    }
}
