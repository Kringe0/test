// Decompiled with JetBrains decompiler
// Type: HWID_TRAINER_DEMET.Program
// Assembly: วีรชนรัน, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD37BE47-05E9-40BA-9DC6-0FE501AB2AB8
// Assembly location: C:\HeroicRanEpisode7\วีรชนรัน.exe

using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Vortex_Loader;

namespace HWID_TRAINER_DEMET
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
            Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
   // Application.Run(new updater());
    }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(args.Name);

            var path = assemblyName.Name + ".dll";
            if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false) path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);

            using (Stream stream = executingAssembly.GetManifestResourceStream(path))
            {
                if (stream == null) return null;

                var assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }
    }
}
