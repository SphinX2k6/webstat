using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030BA RID: 12474
[NullableContext(1)]
[Nullable(0)]
public class LockOnDebugData
{
	// Token: 0x06019B55 RID: 105301 RVA: 0x0077B1D3 File Offset: 0x007793D3
	public LockOnDebugData(LockOnInfo info)
	{
		this.Info = info;
	}

	// Token: 0x06019B56 RID: 105302 RVA: 0x0077B1F0 File Offset: 0x007793F0
	public void DrawDebug(Entity me)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(this.Info.EntityHandle.Id);
		if (!string.IsNullOrEmpty(this.Info.SocketName))
		{
			Vector targetLocation = this.TargetLocation;
			FVectorDouble location = this.GetSkillBoneTransform(entity, this.Info.SocketName).GetLocation();
			targetLocation.DeepCopy(location);
		}
		else
		{
			this.TargetLocation.DeepCopy(entity.GetComponent<BaseActorComponent>().ActorLocationProxy);
		}
		FLinearColor? flinearColor = null;
		switch (this.ColorType)
		{
		case EColorType.Red:
			flinearColor = new FLinearColor?(LockOnDebugData.RedColor);
			break;
		case EColorType.Green:
			flinearColor = new FLinearColor?(LockOnDebugData.GreenColor);
			break;
		case EColorType.Black:
			flinearColor = new FLinearColor?(LockOnDebugData.BlackColor);
			break;
		}
		UObject world = GlobalData.World;
		BaseActorComponent component = me.GetComponent<BaseActorComponent>();
		UKismetSystemLibrary.D_DrawDebugArrow(world, (component != null) ? component.ActorLocationProxy.ToUeVector(false) : new FVectorDouble(), this.TargetLocation.ToUeVector(false), 15f, flinearColor ?? LockOnDebugData.GreenColor, 0f, 0f);
		if (!string.IsNullOrEmpty(this.ShowTip))
		{
			Vector vector = Vector.Create(this.TargetLocation.X, this.TargetLocation.Y, this.TargetLocation.Z);
			vector.Z += this.GetDebugTextOffset(entity);
			UKismetSystemLibrary.D_DrawDebugString(GlobalData.World, vector.ToUeVector(false), this.ShowTip, null, new FLinearColor?(flinearColor ?? LockOnDebugData.GreenColor), 0f);
		}
	}

	// Token: 0x06019B57 RID: 105303 RVA: 0x0077B39C File Offset: 0x0077959C
	[NullableContext(2)]
	private double GetDebugTextOffset(Entity target)
	{
		object obj;
		if (target == null)
		{
			obj = null;
		}
		else
		{
			CharacterActorComponent component = target.GetComponent<CharacterActorComponent>();
			obj = ((component != null) ? component.Actor : null);
		}
		object obj2 = obj;
		float? num;
		if (obj2 == null)
		{
			num = null;
		}
		else
		{
			UCapsuleComponent capsuleComponent = obj2.CapsuleComponent;
			num = ((capsuleComponent != null) ? new float?(capsuleComponent.GetScaledCapsuleHalfHeight()) : null);
		}
		float? num2 = num;
		float valueOrDefault = num2.GetValueOrDefault();
		if (valueOrDefault > 0f)
		{
			return (double)valueOrDefault + 50.0;
		}
		return 120.0;
	}

	// Token: 0x06019B58 RID: 105304 RVA: 0x0077B418 File Offset: 0x00779618
	private FTransformDouble GetSkillBoneTransform(Entity target, string bone)
	{
		CharacterActorComponent component = target.GetComponent<CharacterActorComponent>();
		TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
		if (tsBaseCharacter == null || !tsBaseCharacter.IsValid() || string.IsNullOrEmpty(bone))
		{
			return Singleton<MathUtils>.Instance.DefaultTransformDouble;
		}
		USkeletalMeshComponent mesh = tsBaseCharacter.Mesh;
		FName? dynamicFName = FNameUtil.GetDynamicFName(bone);
		if (mesh != null && dynamicFName != null && mesh.DoesSocketExist(dynamicFName.Value))
		{
			return mesh.D_GetSocketTransform(dynamicFName.Value, ERelativeTransformSpace.RTS_World);
		}
		return Singleton<MathUtils>.Instance.DefaultTransformDouble;
	}

	// Token: 0x0400CCC6 RID: 52422
	[Nullable(2)]
	public string ShowTip;

	// Token: 0x0400CCC7 RID: 52423
	public EColorType ColorType;

	// Token: 0x0400CCC8 RID: 52424
	private readonly Vector TargetLocation = Vector.Create();

	// Token: 0x0400CCC9 RID: 52425
	private static readonly FLinearColor RedColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x0400CCCA RID: 52426
	private static readonly FLinearColor GreenColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x0400CCCB RID: 52427
	private static readonly FLinearColor BlackColor = new FLinearColor(0f, 0f, 0f, 1f);

	// Token: 0x0400CCCC RID: 52428
	private readonly LockOnInfo Info;
}
