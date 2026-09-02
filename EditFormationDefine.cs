using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B43 RID: 6979
[NullableContext(1)]
[Nullable(0)]
public static class EditFormationDefine
{
	// Token: 0x0600C9C7 RID: 51655 RVA: 0x00359C64 File Offset: 0x00357E64
	// Note: this type is marked as 'beforefieldinit'.
	static EditFormationDefine()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		dictionary[1] = "EditSceneFormationRole1";
		dictionary[2] = "EditSceneFormationRole2";
		dictionary[3] = "EditSceneFormationRole3";
		EditFormationDefine.formationPositionToCameraRecord = dictionary;
	}

	// Token: 0x04006089 RID: 24713
	public const int EDITE_FORAMTION_MAX_NUM = 3;

	// Token: 0x0400608A RID: 24714
	public const int MAX_FORMATION_ID = 10;

	// Token: 0x0400608B RID: 24715
	public const string SELF_ONLINE_INDEX = "SP_Online{0}PIcon_Self";

	// Token: 0x0400608C RID: 24716
	public const string OTHER_ONLINE_INDEX = "SP_Online{0}PIcon";

	// Token: 0x0400608D RID: 24717
	public const int EXIT_SKILL_TYPE = 11;

	// Token: 0x0400608E RID: 24718
	public const int FRAGILE_SKILL_TYPE = 12;

	// Token: 0x0400608F RID: 24719
	public const int DELAY_SHOW_LOADING = 500;

	// Token: 0x04006090 RID: 24720
	public const int AUTO_CLOSE_EDIT_FORMATION = 30000;

	// Token: 0x04006091 RID: 24721
	public const int FORMATION_DRAG_START_SHOW_TIME = 250;

	// Token: 0x04006092 RID: 24722
	public const int FORMATION_DRAG_START_MOVE_TIME = 750;

	// Token: 0x04006093 RID: 24723
	[StaticVariableRuleIgnore]
	public static readonly string[] FORMATION_SPRITES = new string[]
	{
		"SP_TeamNum01",
		"SP_TeamNum02",
		"SP_TeamNum03",
		"SP_TeamNum04",
		"SP_TeamNum05",
		"SP_TeamNum06",
		"SP_TeamNum07",
		"SP_TeamNum08",
		"SP_TeamNum09",
		"SP_TeamNum10"
	};

	// Token: 0x04006094 RID: 24724
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<int, string> formationPositionToCameraRecord;
}
