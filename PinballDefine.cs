using System;
using System.Runtime.CompilerServices;

// Token: 0x0200149E RID: 5278
public class PinballDefine : IStaticVariableResetter
{
	// Token: 0x060093E2 RID: 37858 RVA: 0x0027029D File Offset: 0x0026E49D
	static PinballDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PinballDefine.CreateStaticDefaultValue), new Action(PinballDefine.ResetStaticDefaultValue));
	}

	// Token: 0x060093E3 RID: 37859 RVA: 0x002702BC File Offset: 0x0026E4BC
	public static void CreateStaticDefaultValue()
	{
		PinballDefine.pinballRankTopIconResourceKeys = new string[]
		{
			"",
			"T_RankListNo1",
			"T_RankListNo2",
			"T_RankListNo3"
		};
	}

	// Token: 0x060093E4 RID: 37860 RVA: 0x002702E9 File Offset: 0x0026E4E9
	public static void ResetStaticDefaultValue()
	{
		PinballDefine.pinballRankTopIconResourceKeys = null;
	}

	// Token: 0x04004456 RID: 17494
	[Nullable(1)]
	public const string WEAPON_CANNOT_EQUIP_ICON_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/CatapultStory/OutSide/SP_IconTitle02.SP_IconTitle02";

	// Token: 0x04004457 RID: 17495
	public const int PINBALL_ACTIVITY_CACHE_KEY3_ROLE = 0;

	// Token: 0x04004458 RID: 17496
	public const int PINBALL_ACTIVITY_CACHE_KEY2_ROLE_RED_DOT = 0;

	// Token: 0x04004459 RID: 17497
	public const int PINBALL_ROLE_MULTIPLE_LEVEL_UP_TIMES = 10;

	// Token: 0x0400445A RID: 17498
	public const int PINBALL_DEFAULT_TIPS_DURATION = 2000;

	// Token: 0x0400445B RID: 17499
	public const int PINBALL_CURRENCY_ITEM_ID = 89500002;

	// Token: 0x0400445C RID: 17500
	public const int PINBALL_FORMATION_MAX_SIZE = 3;

	// Token: 0x0400445D RID: 17501
	[Nullable(1)]
	public const string PINBALL_ITEMBASE_NUMBER_RESID = "SP_ComItemNum0";

	// Token: 0x0400445E RID: 17502
	public const int PINBALL_MAIN_LEVEL_HELP = 555;

	// Token: 0x0400445F RID: 17503
	public const int PINBALL_DAILY_LEVEL_HELP = 556;

	// Token: 0x04004460 RID: 17504
	public const int PINBALL_TOWER_LEVEL_HELP = 557;

	// Token: 0x04004461 RID: 17505
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static string[] pinballRankTopIconResourceKeys;
}
