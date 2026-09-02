using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002C28 RID: 11304
[NullableContext(1)]
[Nullable(0)]
public class TutorialUtils : IStaticVariableResetter
{
	// Token: 0x060169E7 RID: 92647 RVA: 0x00646C14 File Offset: 0x00644E14
	static TutorialUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TutorialUtils.CreateStaticDefaultValue), new Action(TutorialUtils.ResetStaticDefaultValue));
	}

	// Token: 0x060169E8 RID: 92648 RVA: 0x00646C34 File Offset: 0x00644E34
	public static string AddSearchHighlight(string text)
	{
		string stringConfig = ConfigCommonParamById.GetStringConfig("TutorialSearchColor");
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
		defaultInterpolatedStringHandler.AppendLiteral("<color=");
		defaultInterpolatedStringHandler.AppendFormatted(stringConfig.ToLower());
		defaultInterpolatedStringHandler.AppendLiteral(">");
		defaultInterpolatedStringHandler.AppendFormatted(text);
		defaultInterpolatedStringHandler.AppendLiteral("</color>");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17001DC3 RID: 7619
	// (get) Token: 0x060169E9 RID: 92649 RVA: 0x00646C96 File Offset: 0x00644E96
	public static int? MaxLatestTutorial
	{
		get
		{
			return ConfigCommonParamById.GetIntConfig("MaxLatestTutorial");
		}
	}

	// Token: 0x060169EA RID: 92650 RVA: 0x00646CA4 File Offset: 0x00644EA4
	public static void CreateStaticDefaultValue()
	{
		TutorialUtils.TutorialTypeTxtMap = new Dictionary<ETutorialType, string>
		{
			{
				ETutorialType.All,
				"GuideTutorialType_0"
			},
			{
				ETutorialType.QteReaction,
				"GuideTutorialType_1"
			},
			{
				ETutorialType.Enemy,
				"GuideTutorialType_2"
			},
			{
				ETutorialType.System,
				"GuideTutorialType_3"
			},
			{
				ETutorialType.Adventure,
				"GuideTutorialType_4"
			},
			{
				ETutorialType.BuffOnEnemy,
				"GuideTutorialType_5"
			}
		};
		TutorialUtils.TutorialTypeIconMap = new Dictionary<ETutorialType, string>
		{
			{
				ETutorialType.All,
				"SP_TutorialIconAll"
			},
			{
				ETutorialType.QteReaction,
				"SP_TutorialIconQteReaction"
			},
			{
				ETutorialType.Enemy,
				"SP_TutorialIconEnemy"
			},
			{
				ETutorialType.System,
				"SP_TutorialIconSystem"
			},
			{
				ETutorialType.Adventure,
				"SP_TutorialIconAdventure"
			},
			{
				ETutorialType.BuffOnEnemy,
				"SP_TutorialIconBuff"
			}
		};
		TutorialUtils.FixedDropDropShowPlanId = 1;
	}

	// Token: 0x060169EB RID: 92651 RVA: 0x00646D5B File Offset: 0x00644F5B
	public static void ResetStaticDefaultValue()
	{
		TutorialUtils.TutorialTypeTxtMap = null;
		TutorialUtils.TutorialTypeIconMap = null;
		TutorialUtils.FixedDropDropShowPlanId = 0;
	}

	// Token: 0x060169EC RID: 92652 RVA: 0x00646D70 File Offset: 0x00644F70
	[NullableContext(2)]
	public static string GetTutorialTypeIconPath(ETutorialType type)
	{
		if (TutorialUtils.TutorialTypeIconMap.ContainsKey(type))
		{
			string resourceId = TutorialUtils.TutorialTypeIconMap[type];
			return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		}
		return null;
	}

	// Token: 0x060169ED RID: 92653 RVA: 0x00646DA3 File Offset: 0x00644FA3
	[NullableContext(2)]
	public static string GetTutorialTypeTxt(ETutorialType type)
	{
		if (TutorialUtils.TutorialTypeTxtMap.ContainsKey(type))
		{
			return TutorialUtils.TutorialTypeTxtMap[type];
		}
		return null;
	}

	// Token: 0x0400AE91 RID: 44689
	public static int FixedDropDropShowPlanId;

	// Token: 0x0400AE92 RID: 44690
	private static Dictionary<ETutorialType, string> TutorialTypeIconMap;

	// Token: 0x0400AE93 RID: 44691
	private static Dictionary<ETutorialType, string> TutorialTypeTxtMap;
}
