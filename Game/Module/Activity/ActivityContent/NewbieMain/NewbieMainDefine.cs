using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x02006645 RID: 26181
	public static class NewbieMainDefine
	{
		// Token: 0x04024904 RID: 149764
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<ENewbieMainTabType, IReadOnlyList<string>> NewbieMainBgTextureResourceMap = new Dictionary<ENewbieMainTabType, IReadOnlyList<string>>
		{
			{
				ENewbieMainTabType.Main,
				new string[]
				{
					"T_MissionMainNor",
					"T_MissionMainHold",
					"T_MissionMainPress",
					"T_MissionMainDisable"
				}
			},
			{
				ENewbieMainTabType.Role,
				new string[]
				{
					"T_MissionCompanionNor",
					"T_MissionCompanionHold",
					"T_MissionCompanionPress",
					"T_MissionCompanionDisable"
				}
			}
		};
	}
}
