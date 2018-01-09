﻿/********************************************************************************
** auth： zsh2401@163.com
** date： 2018/1/9 11:22:29
** filename: DeviceImageOperator.cs
** compiler: Visual Studio 2017
** desc： ...
*********************************************************************************/
using AutumnBox.Basic.Executer;
using AutumnBox.Basic.Util;
using System;
using System.Linq;

namespace AutumnBox.Basic.Device
{

    public sealed class DeviceImageFinder : IDisposable
    {
        private readonly Serial serial;
        public AndroidShell ShellAsSu
        {
            private get
            {
                if (_shell == null)
                {
                    _shell = new AndroidShell(serial);
                    _shell.Connect();
                    _shell.Switch2Su();
                }
                return _shell;
            }
            set
            {
                _shell = value;
            }
        }
        private AndroidShell _shell;

        public DeviceImageFinder(Serial serial)
        {
            this.serial = serial;
        }
        public static string PathOf(Serial serial, DeviceImage imageType)
        {
            using (DeviceImageFinder _o = new DeviceImageFinder(serial))
            {
                return _o.PathOf(imageType);
            }
        }
        public string PathOf(DeviceImage imageType)
        {
            return Find1(imageType) ?? Find2(imageType);
        }
        private string Find1(DeviceImage image)
        {
            var exeResult = ShellAsSu.SafetyInput("find /dev/ -name boot");
            if (exeResult.ReturnCode == (int)LinuxReturnCode.KeyHasExpired)
            {
                return null;//无法使用find命令,当场返回!
            }
            else
            {
                var result = from r in exeResult.LineAll
                             where PathIsRight(r)
                             select r;
                return result.First();
            }
        }
        private string Find2(DeviceImage image)
        {
            string maybePath1 = $"/dev/block/platform/*/by-name/{image.ToString().ToLower()}";
            string maybePath2 = $"/dev/block/platform/soc*/*/by-name/{image.ToString().ToLower()}";

            var exeResult = ShellAsSu.SafetyInput($"ls -l {maybePath1}");
            if (exeResult.IsSuccess)
            {
                return maybePath1;
            }
            exeResult = ShellAsSu.SafetyInput($"ls -l {maybePath2}");
            if (exeResult.IsSuccess)
            {
                return maybePath2;
            }
            return null;
        }

        private bool PathIsRight(string path)
        {
            return ShellAsSu.SafetyInput($"ls -l {path}").IsSuccess;
        }
        public void Dispose()
        {
            this.ShellAsSu?.Dispose();
        }
    }
}
