using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001151 RID: 4433
[NullableContext(1)]
[Nullable(0)]
public class ActivityRecommendColors : IStaticVariableResetter
{
	// Token: 0x060074CC RID: 29900 RVA: 0x001EA133 File Offset: 0x001E8333
	static ActivityRecommendColors()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityRecommendColors.CreateStaticDefaultValue), new Action(ActivityRecommendColors.ResetStaticDefaultValue));
	}

	// Token: 0x060074CD RID: 29901 RVA: 0x001EA152 File Offset: 0x001E8352
	public static void CreateStaticDefaultValue()
	{
		ActivityRecommendColors.RecommendYellowColor = new FColor?(FColor.FromHex("8D784C"));
		ActivityRecommendColors.RecommendBlueColor = new FColor?(FColor.FromHex("476188"));
		ActivityRecommendColors.RecommendGreenColor = new FColor?(FColor.FromHex("4A6256"));
	}

	// Token: 0x060074CE RID: 29902 RVA: 0x001EA190 File Offset: 0x001E8390
	public static void ResetStaticDefaultValue()
	{
		ActivityRecommendColors.RecommendYellowColor = null;
		ActivityRecommendColors.RecommendBlueColor = null;
		ActivityRecommendColors.RecommendGreenColor = null;
	}

	// Token: 0x04003866 RID: 14438
	private const string YELLOW_COLOR = "8D784C";

	// Token: 0x04003867 RID: 14439
	public static FColor? RecommendYellowColor;

	// Token: 0x04003868 RID: 14440
	private const string BLUE_COLOR = "476188";

	// Token: 0x04003869 RID: 14441
	public static FColor? RecommendBlueColor;

	// Token: 0x0400386A RID: 14442
	private const string GREEN_COLOR = "4A6256";

	// Token: 0x0400386B RID: 14443
	public static FColor? RecommendGreenColor;
}
