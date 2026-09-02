using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002BD9 RID: 11225
[NullableContext(1)]
[Nullable(0)]
public class TowerData : IStaticVariableResetter
{
	// Token: 0x0601668E RID: 91790 RVA: 0x0063924C File Offset: 0x0063744C
	static TowerData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TowerData.CreateStaticDefaultValue), new Action(TowerData.ResetStaticDefaultValue));
	}

	// Token: 0x0601668F RID: 91791 RVA: 0x0063926C File Offset: 0x0063746C
	public static void CreateStaticDefaultValue()
	{
		TowerData.highColor = new FColor?(FColor.FromHex("FFE361"));
		TowerData.lowColor = new FColor?(FColor.FromHex("FFBD77"));
		TowerData.noneColor = new FColor?(FColor.FromHex("B11515"));
		TowerData.redColor = new FColor?(FColor.FromHex("E2524C"));
	}

	// Token: 0x06016690 RID: 91792 RVA: 0x006392C9 File Offset: 0x006374C9
	public static void ResetStaticDefaultValue()
	{
		TowerData.highColor = null;
		TowerData.lowColor = null;
		TowerData.noneColor = null;
		TowerData.redColor = null;
	}

	// Token: 0x0400AD59 RID: 44377
	public const int LOW_RISK_DIFFICULTY = 1;

	// Token: 0x0400AD5A RID: 44378
	public const int HIGH_RISK_DIFFICULTY = 2;

	// Token: 0x0400AD5B RID: 44379
	public const int VARIATION_RISK_DIFFICULTY = 3;

	// Token: 0x0400AD5C RID: 44380
	public const int OVERLOCK_RISK_DIFFICULTY = 4;

	// Token: 0x0400AD5D RID: 44381
	public const string HIGH_COLOR = "FFE361";

	// Token: 0x0400AD5E RID: 44382
	public const string LOW_COLOR = "FFBD77";

	// Token: 0x0400AD5F RID: 44383
	public const string NONE_COLOR = "B11515";

	// Token: 0x0400AD60 RID: 44384
	public const string RED_COLOR = "E2524C";

	// Token: 0x0400AD61 RID: 44385
	public static FColor? highColor;

	// Token: 0x0400AD62 RID: 44386
	public static FColor? lowColor;

	// Token: 0x0400AD63 RID: 44387
	public static FColor? noneColor;

	// Token: 0x0400AD64 RID: 44388
	public static FColor? redColor;

	// Token: 0x0400AD65 RID: 44389
	public const int HIGH_COST = 4;

	// Token: 0x0400AD66 RID: 44390
	public const int TOWER_TEAM_MAX_NUMBER = 3;
}
