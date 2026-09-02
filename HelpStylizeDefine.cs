using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001EBF RID: 7871
public class HelpStylizeDefine : IStaticVariableResetter
{
	// Token: 0x0600E89E RID: 59550 RVA: 0x003EE744 File Offset: 0x003EC944
	static HelpStylizeDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(HelpStylizeDefine.CreateStaticDefaultValue), new Action(HelpStylizeDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600E89F RID: 59551 RVA: 0x003EE764 File Offset: 0x003EC964
	public static void CreateStaticDefaultValue()
	{
		HelpStylizeDefine.helpPopUpViewStylizeMap = new Dictionary<EHelpStylizeType, EUiViewName>
		{
			{
				EHelpStylizeType.None,
				EUiViewName.HelpView
			},
			{
				EHelpStylizeType.FloroRanch,
				EUiViewName.FloroRanchHelpView
			},
			{
				EHelpStylizeType.Pinball,
				EUiViewName.PinballMainHelpView
			}
		};
		HelpStylizeDefine.helpStylizeType2PopFrameType = new Dictionary<EHelpStylizeType, EUiBehaviourPopType?>
		{
			{
				EHelpStylizeType.None,
				null
			},
			{
				EHelpStylizeType.FloroRanch,
				null
			},
			{
				EHelpStylizeType.Pinball,
				null
			}
		};
	}

	// Token: 0x0600E8A0 RID: 59552 RVA: 0x003EE7D9 File Offset: 0x003EC9D9
	public static void ResetStaticDefaultValue()
	{
		HelpStylizeDefine.helpPopUpViewStylizeMap = null;
		HelpStylizeDefine.helpStylizeType2PopFrameType = null;
	}

	// Token: 0x04007012 RID: 28690
	[Nullable(1)]
	public static Dictionary<EHelpStylizeType, EUiViewName> helpPopUpViewStylizeMap;

	// Token: 0x04007013 RID: 28691
	[Nullable(1)]
	public static Dictionary<EHelpStylizeType, EUiBehaviourPopType?> helpStylizeType2PopFrameType;
}
