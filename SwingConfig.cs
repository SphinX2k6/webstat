using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.Swing;
using UnrealEngine;

// Token: 0x02002FED RID: 12269
[NullableContext(1)]
[Nullable(0)]
public class SwingConfig
{
	// Token: 0x0601900D RID: 102413 RVA: 0x00717DCC File Offset: 0x00715FCC
	[NullableContext(2)]
	public bool Init(BP_CharacterSwingConfig_C asset = null)
	{
		this.IsRole = false;
		if (asset != null)
		{
			this.SitOnModelBufferTime = asset.SitOnModelBufferTime;
			this.StandUpModelBufferTime = asset.StandUpModelBufferTime;
			this.StandUpMoveAwayDist = (float)asset.StandUpMoveAwayDist;
			this.ExitImmediately = asset.ExitImmediately;
			this.AttachSocket = asset.AttachSocket;
			this.ReferenceActor = asset.ReferenceActor;
			this.AttachRotator.Set(asset.AttachRotator.Y, asset.AttachRotator.Z, asset.AttachRotator.X);
			this.AttachLocation.Set((double)asset.AttachLocation.X, (double)asset.AttachLocation.Y, (double)asset.AttachLocation.Z);
			this.AnimMontagePath = asset.SwingAnimation.ToAssetPathName();
			return this.AnimMontagePath.Length >= 1;
		}
		return false;
	}

	// Token: 0x0601900E RID: 102414 RVA: 0x00717EB0 File Offset: 0x007160B0
	[NullableContext(2)]
	public bool InitRole(int roleId, BP_RoleSwingConfig_C asset = null)
	{
		this.IsRole = true;
		if (asset == null)
		{
			return false;
		}
		this.SitOnModelBufferTime = asset.SitOnModelBufferTime;
		this.StandUpModelBufferTime = asset.StandUpModelBufferTime;
		this.StandUpMoveAwayDist = (float)asset.StandUpMoveAwayDist;
		this.ExitImmediately = asset.ExitImmediately;
		this.AttachSocket = asset.AttachSocket;
		this.ReferenceActor = asset.ReferenceActor;
		this.AttachRotator.Set(asset.AttachRotator.Y, asset.AttachRotator.Z, asset.AttachRotator.X);
		this.AttachLocation.Set((double)asset.AttachLocation.X, (double)asset.AttachLocation.Y, (double)asset.AttachLocation.Z);
		string text = this.FindRoleMontage(roleId, asset.SwingAnimation);
		if (text == null)
		{
			return false;
		}
		this.AnimMontagePath = text;
		return true;
	}

	// Token: 0x0601900F RID: 102415 RVA: 0x00717F8C File Offset: 0x0071618C
	[NullableContext(2)]
	private string FindRoleMontage(int roleId, [Nullable(new byte[]
	{
		2,
		1
	})] TArray<SRoleSwingConfig> arr)
	{
		if (arr != null)
		{
			for (int i = 0; i < arr.Num(); i++)
			{
				if (arr.Get(i).RoleId.Contains(roleId))
				{
					return arr.Get(i).SwingMontage.ToAssetPathName();
				}
			}
		}
		return null;
	}

	// Token: 0x0400C393 RID: 50067
	public int SitOnModelBufferTime = 400;

	// Token: 0x0400C394 RID: 50068
	public int StandUpModelBufferTime = 500;

	// Token: 0x0400C395 RID: 50069
	public float StandUpMoveAwayDist = 10f;

	// Token: 0x0400C396 RID: 50070
	public string AttachSocket = "Bone_Root";

	// Token: 0x0400C397 RID: 50071
	public Rotator AttachRotator = Rotator.Create();

	// Token: 0x0400C398 RID: 50072
	public Vector AttachLocation = Vector.Create();

	// Token: 0x0400C399 RID: 50073
	public string ReferenceActor = "SkeletalMesh";

	// Token: 0x0400C39A RID: 50074
	public bool ExitImmediately;

	// Token: 0x0400C39B RID: 50075
	public string AnimMontagePath = "";

	// Token: 0x0400C39C RID: 50076
	public bool IsRole;
}
