using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x02003217 RID: 12823
[NullableContext(1)]
[Nullable(0)]
public class BasePlatform
{
	// Token: 0x0601AA5E RID: 109150 RVA: 0x007EC8D9 File Offset: 0x007EAAD9
	public BasePlatform(EntityHandle entityHandle)
	{
		this.EntityHandle = entityHandle;
	}

	// Token: 0x0601AA5F RID: 109151 RVA: 0x007EC8E8 File Offset: 0x007EAAE8
	public virtual FTransformDouble? GetTransform()
	{
		return null;
	}

	// Token: 0x0601AA60 RID: 109152 RVA: 0x007EC900 File Offset: 0x007EAB00
	public virtual void TransformFromRelativeSpace(FVectorDouble inPosition, FRotator inRotation, ref FVectorDouble outPosition, ref FRotator outRotation)
	{
		FTransformDouble? transform = this.GetTransform();
		FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
		outPosition = UKismetMathLibrary.D_TransformLocation(ftransformDouble, inPosition);
		ftransformDouble = (transform ?? new FTransformDouble());
		outRotation = UKismetMathLibrary.D_TransformRotation(ftransformDouble, inRotation);
	}

	// Token: 0x0601AA61 RID: 109153 RVA: 0x007EC968 File Offset: 0x007EAB68
	public virtual void TransformToRelativeSpace(FVectorDouble inPosition, FRotator inRotation, ref FVectorDouble outPosition, ref FRotator outRotation)
	{
		FTransformDouble? transform = this.GetTransform();
		FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
		outPosition = UKismetMathLibrary.D_InverseTransformLocation(ftransformDouble, inPosition);
		ftransformDouble = (transform ?? new FTransformDouble());
		outRotation = UKismetMathLibrary.D_InverseTransformRotation(ftransformDouble, inRotation);
	}

	// Token: 0x0601AA62 RID: 109154 RVA: 0x007EC9CD File Offset: 0x007EABCD
	public virtual bool CheckLeave(Entity entity, global::Vector location)
	{
		return false;
	}

	// Token: 0x0601AA63 RID: 109155 RVA: 0x007EC9D0 File Offset: 0x007EABD0
	public virtual void OnCharacterEnter(Entity entity, UCharacterMovementComponent characterMovement)
	{
	}

	// Token: 0x0601AA64 RID: 109156 RVA: 0x007EC9D4 File Offset: 0x007EABD4
	protected void RequestEnterOrLeave(bool isEnter)
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CH, "[BasePlatform.RequestEnterOrLeave] EntityHandle无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		VehiclePlatformGetOnRequest vehiclePlatformGetOnRequest = VehiclePlatformGetOnRequest.Create();
		long creatureDataId = this.EntityHandle.CreatureDataId;
		vehiclePlatformGetOnRequest.EntityId = creatureDataId;
		vehiclePlatformGetOnRequest.IsGetOn = isEnter;
		Singleton<Net>.Instance.Call<VehiclePlatformGetOnResponse>(ERequestMessageId.VehiclePlatformGetOnRequest, vehiclePlatformGetOnRequest, delegate(VehiclePlatformGetOnResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x0400D7CC RID: 55244
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x0400D7CD RID: 55245
	public int CreatureDataId;

	// Token: 0x0400D7CE RID: 55246
	public bool IsDeltaBaseSpeedNeedZ;
}
