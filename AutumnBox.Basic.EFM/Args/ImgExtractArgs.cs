﻿/* =============================================================================*\
*
* Filename: ImgExtractArgs
* Description: 
*
* Version: 1.0
* Created: 2017/11/10 17:49:02 (UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using AutumnBox.Basic.Device;

namespace AutumnBox.Basic.Function.Args
{
    public class ImgExtractArgs : ModuleArgs
    {
        public string SavePath { get; set; }
        public DeviceImage ExtractImage { get; set; }
        public ImgExtractArgs(DeviceBasicInfo device, DeviceImage extractImage = DeviceImage.Recovery) : base(device)
        {
            ExtractImage = extractImage;
        }
    }
}
