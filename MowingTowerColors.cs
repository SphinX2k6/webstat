using System;
using UnrealEngine;

// Token: 0x02001433 RID: 5171
public class MowingTowerColors : IStaticVariableResetter
{
	// Token: 0x06008FEF RID: 36847 RVA: 0x0025CBD9 File Offset: 0x0025ADD9
	static MowingTowerColors()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MowingTowerColors.CreateStaticDefaultValue), new Action(MowingTowerColors.ResetStaticDefaultValue));
	}

	// Token: 0x06008FF0 RID: 36848 RVA: 0x0025CBF8 File Offset: 0x0025ADF8
	public static void CreateStaticDefaultValue()
	{
		MowingTowerColors.bgNormalMowingTowerColor = new FColor?(FColor.FromHex("ab9559"));
		MowingTowerColors.bgLockMowingTowerColor = new FColor?(FColor.FromHex("757575"));
		MowingTowerColors.bgInfiniteMowingTowerColor = new FColor?(FColor.FromHex("e8713f"));
		MowingTowerColors.normalMowingTowerColor = new FColor?(FColor.FromHex("cfc48a"));
		MowingTowerColors.lockMowingTowerColor = new FColor?(FColor.FromHex("757575"));
		MowingTowerColors.infiniteMowingTowerColor = new FColor?(FColor.FromHex("f1ac61"));
	}

	// Token: 0x06008FF1 RID: 36849 RVA: 0x0025CC80 File Offset: 0x0025AE80
	public static void ResetStaticDefaultValue()
	{
		MowingTowerColors.bgNormalMowingTowerColor = null;
		MowingTowerColors.bgLockMowingTowerColor = null;
		MowingTowerColors.bgInfiniteMowingTowerColor = null;
		MowingTowerColors.normalMowingTowerColor = null;
		MowingTowerColors.lockMowingTowerColor = null;
		MowingTowerColors.infiniteMowingTowerColor = null;
	}

	// Token: 0x040042B9 RID: 17081
	public static FColor? bgNormalMowingTowerColor;

	// Token: 0x040042BA RID: 17082
	public static FColor? bgLockMowingTowerColor;

	// Token: 0x040042BB RID: 17083
	public static FColor? bgInfiniteMowingTowerColor;

	// Token: 0x040042BC RID: 17084
	public static FColor? normalMowingTowerColor;

	// Token: 0x040042BD RID: 17085
	public static FColor? lockMowingTowerColor;

	// Token: 0x040042BE RID: 17086
	public static FColor? infiniteMowingTowerColor;
}
