using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200254C RID: 9548
public class VisionDefine : IStaticVariableResetter
{
	// Token: 0x0601294A RID: 76106 RVA: 0x0051E481 File Offset: 0x0051C681
	static VisionDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(VisionDefine.CreateStaticDefaultValue), new Action(VisionDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0601294B RID: 76107 RVA: 0x0051E4A0 File Offset: 0x0051C6A0
	public static void CreateStaticDefaultValue()
	{
		VisionDefine.tabViewWithLock = new HashSet<string>
		{
			EUiTabViewName.VisionIdentifyView.ToString(),
			EUiTabViewName.VisionRefineTabView.ToString()
		};
	}

	// Token: 0x0601294C RID: 76108 RVA: 0x0051E4DA File Offset: 0x0051C6DA
	public static void ResetStaticDefaultValue()
	{
		VisionDefine.tabViewWithLock = null;
	}

	// Token: 0x040090C4 RID: 37060
	public const int VISIONRAREGOLD = 3;

	// Token: 0x040090C5 RID: 37061
	public const int VISIONRAREPURPLE = 2;

	// Token: 0x040090C6 RID: 37062
	public const int VISIONRAREBLUE = 1;

	// Token: 0x040090C7 RID: 37063
	public const int CANNOTLEVELSUBQUALITY = 2;

	// Token: 0x040090C8 RID: 37064
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static HashSet<string> tabViewWithLock;
}
