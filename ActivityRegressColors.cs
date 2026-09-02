using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200151F RID: 5407
public class ActivityRegressColors : IStaticVariableResetter
{
	// Token: 0x0600972D RID: 38701 RVA: 0x00278E14 File Offset: 0x00277014
	static ActivityRegressColors()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityRegressColors.CreateStaticDefaultValue), new Action(ActivityRegressColors.ResetStaticDefaultValue));
	}

	// Token: 0x0600972E RID: 38702 RVA: 0x00278E33 File Offset: 0x00277033
	public static void CreateStaticDefaultValue()
	{
		ActivityRegressColors.RegressYellowColor = new FColor?(FColor.FromHex("8D784C"));
		ActivityRegressColors.RegressBlueColor = new FColor?(FColor.FromHex("476188"));
	}

	// Token: 0x0600972F RID: 38703 RVA: 0x00278E5D File Offset: 0x0027705D
	public static void ResetStaticDefaultValue()
	{
		ActivityRegressColors.RegressYellowColor = null;
		ActivityRegressColors.RegressBlueColor = null;
	}

	// Token: 0x0400462D RID: 17965
	[Nullable(1)]
	private const string YELLOW_COLOR = "8D784C";

	// Token: 0x0400462E RID: 17966
	public static FColor? RegressYellowColor;

	// Token: 0x0400462F RID: 17967
	[Nullable(1)]
	private const string BLUE_COLOR = "476188";

	// Token: 0x04004630 RID: 17968
	public static FColor? RegressBlueColor;
}
