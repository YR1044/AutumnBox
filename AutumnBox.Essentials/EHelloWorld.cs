﻿using AutumnBox.OpenFramework.Extension;
using AutumnBox.OpenFramework.Extension.Leaf;
using AutumnBox.OpenFramework.Extension.Leaf.Attributes;
using AutumnBox.OpenFramework.Open.LKit;

namespace AutumnBox.Essentials
{
    [ExtName("Example Extension")]
    [ExtDeveloperMode]
    [ExtAuth("zsh2401")]
    class EHelloWorld : LeafExtensionBase
    {
        [LMain]
        public void EntryPoint(ILeafUI ui)
        {
            using (ui)
            {
                ui.Title = this.GetName();
                ui.Icon = this.GetIconBytes();
                ui.Show();
                ui.WriteLine("Hello world!");
                ui.Finish();
            }
        }
    }
}
