using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;

// Token: 0x0200301D RID: 12317
[NullableContext(1)]
[Nullable(0)]
public class LockOnPart
{
	// Token: 0x06019211 RID: 102929 RVA: 0x00726750 File Offset: 0x00724950
	public LockOnPart(FName config)
	{
		this.BoneNameString = config.ToString();
		this.BoneName = config;
		this.SoftLockValid = true;
		this.HardLockValid = true;
		this.AimPartBoneName = this.BoneNameString;
		this.EnablePartName = "";
	}

	// Token: 0x06019212 RID: 102930 RVA: 0x007267DC File Offset: 0x007249DC
	public LockOnPart(SLockOnPart config)
	{
		this.BoneNameString = config.BoneName;
		this.BoneName = new FName(this.BoneNameString);
		this.SoftLockValid = config.SoftLockValid;
		this.HardLockValid = config.HardLockValid;
		this.AimPartBoneName = config.AimPartBoneName;
		this.EnablePartName = config.EnablePartName;
	}

	// Token: 0x0400C52D RID: 50477
	public FName BoneName = FNameUtil.NONE;

	// Token: 0x0400C52E RID: 50478
	public string BoneNameString = "";

	// Token: 0x0400C52F RID: 50479
	public bool SoftLockValid = true;

	// Token: 0x0400C530 RID: 50480
	public bool HardLockValid = true;

	// Token: 0x0400C531 RID: 50481
	public string AimPartBoneName = "";

	// Token: 0x0400C532 RID: 50482
	public string EnablePartName = "";
}
