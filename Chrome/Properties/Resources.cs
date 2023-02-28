// Decompiled with JetBrains decompiler
// Type: Chrome.Properties.Resources
// Assembly: วีรชนรัน, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD37BE47-05E9-40BA-9DC6-0FE501AB2AB8
// Assembly location: C:\HeroicRanEpisode7\วีรชนรัน.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Chrome.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Chrome.Properties.Resources.resourceMan == null)
          Chrome.Properties.Resources.resourceMan = new ResourceManager("Chrome.Properties.Resources", typeof (Chrome.Properties.Resources).Assembly);
        return Chrome.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Chrome.Properties.Resources.resourceCulture;
      set => Chrome.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap fffffffffffffffff => (Bitmap) Chrome.Properties.Resources.ResourceManager.GetObject(nameof (fffffffffffffffff), Chrome.Properties.Resources.resourceCulture);
  }
}
