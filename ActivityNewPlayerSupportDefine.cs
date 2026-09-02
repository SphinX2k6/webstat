using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200146A RID: 5226
public static class ActivityNewPlayerSupportDefine
{
	// Token: 0x040043B0 RID: 17328
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<int, string> RoleBgColor = new Dictionary<int, string>
	{
		{
			1205,
			"dee7df"
		},
		{
			1302,
			"c04e4f"
		},
		{
			1304,
			"2bb4c3"
		},
		{
			1505,
			"2a67de"
		},
		{
			1603,
			"cb2f16"
		}
	};

	// Token: 0x040043B1 RID: 17329
	public const int TRAIL_ROLE_HELP_ID = 465;

	// Token: 0x040043B2 RID: 17330
	public const float RECEIVED_TASK_ITEM_ALPHA = 0.6f;

	// Token: 0x040043B3 RID: 17331
	[Nullable(1)]
	public const string TRIAL_ROLE_LIST_ITEM_RESOURCE_ID = "TogRoleTrial";

	// Token: 0x040043B4 RID: 17332
	[StaticVariableRuleIgnore]
	public static readonly FColor FinishTaskTextColor = FColor.FromHex("6586c1");

	// Token: 0x040043B5 RID: 17333
	[StaticVariableRuleIgnore]
	public static readonly FColor NormalTaskTextColor = FColor.FromHex("b6e1ff");

	// Token: 0x0200786B RID: 30827
	public enum ETrialRoleStatus
	{
		// Token: 0x0402969E RID: 169630
		Locked,
		// Token: 0x0402969F RID: 169631
		Unlocked
	}
}
