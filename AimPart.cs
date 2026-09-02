using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;

// Token: 0x02003216 RID: 12822
[NullableContext(1)]
[Nullable(0)]
public class AimPart
{
	// Token: 0x0601AA58 RID: 109144 RVA: 0x007EC5E5 File Offset: 0x007EA7E5
	public AimPart(BaseActorComponent ownerBase)
	{
		this.OwnerBase = ownerBase;
	}

	// Token: 0x0601AA59 RID: 109145 RVA: 0x007EC620 File Offset: 0x007EA820
	public void Init(SAimPart config)
	{
		this.OwnerCharacter = (this.OwnerBase as CharacterActorComponent);
		this.BoneNameString = config.BoneName;
		Vector offset = this.Offset;
		FVector offset2 = config.Offset;
		FVectorDouble fvectorDouble = offset2;
		offset.DeepCopy(fvectorDouble);
		this.IgnoreCollisionBoneName = config.忽略的骨骼碰撞;
		this.BoneName = new FName(this.BoneNameString);
		this.RadiusIn = config.RadiusIn;
		this.RadiusOut = config.RadiusOut;
		this.RadiusOutOnStart = config.RadiusOutOnStart;
		this.MobileCorrect = config.MobileCorrect;
		this.GamePadCorrect = config.GamePadCorrect;
	}

	// Token: 0x0601AA5A RID: 109146 RVA: 0x007EC6C0 File Offset: 0x007EA8C0
	public void InitSceneItem(IAimPart config)
	{
		this.SceneItemHit = this.OwnerBase.Entity.GetComponent<SceneItemHitComponent>();
		this.BoneNameString = (config.BoneName ?? "");
		this.Offset.X = (double)config.Offset.X.GetValueOrDefault();
		this.Offset.Y = (double)config.Offset.Y.GetValueOrDefault();
		this.Offset.Z = (double)config.Offset.Z.GetValueOrDefault();
		this.BoneName = new FName(this.BoneNameString);
		this.RadiusIn = (float)config.RadiusIn;
		this.RadiusOut = (float)config.RadiusOut;
		this.RadiusOutOnStart = (float)config.RadiusOutOnStart;
		this.MobileCorrect = config.MobileCorrect;
		this.GamePadCorrect = config.GamePadCorrect;
	}

	// Token: 0x0601AA5B RID: 109147 RVA: 0x007EC7A8 File Offset: 0x007EA9A8
	public float GetRadius(bool onStart)
	{
		float num = onStart ? this.RadiusOutOnStart : this.RadiusOut;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			num *= this.GamePadCorrect;
		}
		else if (Singleton<Info>.Instance.IsInTouch())
		{
			num *= this.MobileCorrect;
		}
		return num;
	}

	// Token: 0x0601AA5C RID: 109148 RVA: 0x007EC7F4 File Offset: 0x007EA9F4
	public bool GetAimPointLocation(Vector @out)
	{
		if (this.OwnerCharacter != null)
		{
			Transform tmpTrans = AimPart.TmpTrans;
			FTransformDouble ftransformDouble = this.OwnerCharacter.Actor.Mesh.D_GetSocketTransform(this.BoneName, ERelativeTransformSpace.RTS_World);
			tmpTrans.FromUeTransform(ftransformDouble);
		}
		else
		{
			if (this.SceneItemHit == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(this.BoneNameString))
			{
				AActor owner = this.OwnerBase.Owner;
				if (owner == null)
				{
					return false;
				}
				Transform tmpTrans2 = AimPart.TmpTrans;
				FTransformDouble ftransformDouble = owner.D_GetTransform();
				tmpTrans2.FromUeTransform(ftransformDouble);
			}
			else
			{
				SceneItemActorComponent sceneItemActorComponent = this.OwnerBase as SceneItemActorComponent;
				AActor aactor = (sceneItemActorComponent != null) ? sceneItemActorComponent.GetActorInSceneInteraction(this.BoneNameString) : null;
				if (aactor == null)
				{
					aactor = this.OwnerBase.Owner;
					if (aactor == null)
					{
						return false;
					}
				}
				Transform tmpTrans3 = AimPart.TmpTrans;
				FTransformDouble ftransformDouble = aactor.D_GetTransform();
				tmpTrans3.FromUeTransform(ftransformDouble);
			}
		}
		AimPart.TmpTrans.TransformPosition(this.Offset, @out);
		return true;
	}

	// Token: 0x0400D7BF RID: 55231
	[StaticVariableRuleIgnore]
	private static readonly Transform TmpTrans = Transform.Create();

	// Token: 0x0400D7C0 RID: 55232
	public FName BoneName = FNameUtil.NONE;

	// Token: 0x0400D7C1 RID: 55233
	public string BoneNameString = "";

	// Token: 0x0400D7C2 RID: 55234
	public Vector Offset = Vector.Create();

	// Token: 0x0400D7C3 RID: 55235
	public float RadiusIn;

	// Token: 0x0400D7C4 RID: 55236
	public float RadiusOut;

	// Token: 0x0400D7C5 RID: 55237
	public float RadiusOutOnStart;

	// Token: 0x0400D7C6 RID: 55238
	public float MobileCorrect;

	// Token: 0x0400D7C7 RID: 55239
	public float GamePadCorrect;

	// Token: 0x0400D7C8 RID: 55240
	public string IgnoreCollisionBoneName = "";

	// Token: 0x0400D7C9 RID: 55241
	[Nullable(2)]
	public CharacterActorComponent OwnerCharacter;

	// Token: 0x0400D7CA RID: 55242
	[Nullable(2)]
	public SceneItemHitComponent SceneItemHit;

	// Token: 0x0400D7CB RID: 55243
	public readonly BaseActorComponent OwnerBase;
}
