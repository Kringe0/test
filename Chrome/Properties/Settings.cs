// Decompiled with JetBrains decompiler
// Type: Chrome.Properties.Settings
// Assembly: วีรชนรัน, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD37BE47-05E9-40BA-9DC6-0FE501AB2AB8
// Assembly location: C:\HeroicRanEpisode7\วีรชนรัน.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Chrome.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}
