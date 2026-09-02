using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002A56 RID: 10838
public class FlySkinDefine : IStaticVariableResetter
{
	// Token: 0x06015B46 RID: 88902 RVA: 0x00605F8D File Offset: 0x0060418D
	static FlySkinDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FlySkinDefine.CreateStaticDefaultValue), new Action(FlySkinDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06015B47 RID: 88903 RVA: 0x00605FAC File Offset: 0x006041AC
	public static void CreateStaticDefaultValue()
	{
		FlySkinDefine.FLY_SKIN_APPLY_TO_ALL_HELP_ID = new int?(243);
		FlySkinDefine.flySkinTabToType = new Dictionary<EFlySkinTab, EFlySkinType>
		{
			{
				EFlySkinTab.ParaglidingTab,
				EFlySkinType.Paragliding
			},
			{
				EFlySkinTab.SoarWingTab,
				EFlySkinType.SoarWing
			}
		};
		FlySkinDefine.DEFAULT_FLY_SKIN_CASE = "GliderSkinCase";
		FlySkinDefine.flySkinTypeToCase = new Dictionary<EFlySkinType, string>
		{
			{
				EFlySkinType.Paragliding,
				"GliderSkinCase"
			},
			{
				EFlySkinType.SoarWing,
				"SoarSkinCase"
			}
		};
	}

	// Token: 0x06015B48 RID: 88904 RVA: 0x0060600E File Offset: 0x0060420E
	public static void ResetStaticDefaultValue()
	{
		FlySkinDefine.FLY_SKIN_APPLY_TO_ALL_HELP_ID = null;
		FlySkinDefine.flySkinTabToType = null;
		FlySkinDefine.DEFAULT_FLY_SKIN_CASE = null;
		FlySkinDefine.flySkinTypeToCase = null;
	}

	// Token: 0x0400A69D RID: 42653
	public static int? FLY_SKIN_APPLY_TO_ALL_HELP_ID;

	// Token: 0x0400A69E RID: 42654
	[Nullable(2)]
	public static Dictionary<EFlySkinTab, EFlySkinType> flySkinTabToType;

	// Token: 0x0400A69F RID: 42655
	[Nullable(2)]
	public static string DEFAULT_FLY_SKIN_CASE;

	// Token: 0x0400A6A0 RID: 42656
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<EFlySkinType, string> flySkinTypeToCase;
}
