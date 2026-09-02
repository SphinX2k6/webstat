using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02003218 RID: 12824
[NullableContext(1)]
[Nullable(0)]
public class CharacterBasePlatform : BasePlatform
{
	// Token: 0x0601AA65 RID: 109157 RVA: 0x007ECA68 File Offset: 0x007EAC68
	public CharacterBasePlatform(EntityHandle entityHandle) : base(entityHandle)
	{
		this.IsDeltaBaseSpeedNeedZ = false;
		BP_BasePlatform_C basePlatform = entityHandle.Entity.GetComponent<CharacterActorComponent>().Actor.BasePlatform;
		if (basePlatform != null && basePlatform.IsValid())
		{
			this.LeaveSphereCenter = new FVectorDouble?(UKismetMathLibrary.Conv_VectorToVectorDouble(basePlatform.LeaveSphereCenter));
			this.LeaveSphereRadiusSq = (double)(basePlatform.LeaveSphereRadius * basePlatform.LeaveSphereRadius);
		}
	}

	// Token: 0x0601AA66 RID: 109158 RVA: 0x007ECADC File Offset: 0x007EACDC
	public override FTransformDouble? GetTransform()
	{
		if (!this.EntityHandle.Valid)
		{
			return null;
		}
		CharacterActorComponent component = this.EntityHandle.Entity.GetComponent<CharacterActorComponent>();
		BP_BasePlatform_C basePlatform = component.Actor.BasePlatform;
		if (basePlatform == null || !basePlatform.IsValid())
		{
			return null;
		}
		return new FTransformDouble?(component.Actor.Mesh.D_GetSocketTransform(basePlatform.RootComponent.AttachSocketName, ERelativeTransformSpace.RTS_World));
	}

	// Token: 0x0601AA67 RID: 109159 RVA: 0x007ECB5C File Offset: 0x007EAD5C
	public override bool CheckLeave(Entity entity, Vector location)
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			return true;
		}
		FTransformDouble ftransformDouble = this.GetTransform() ?? new FTransformDouble();
		FVectorDouble fvectorDouble = UKismetMathLibrary.D_TransformLocation(ftransformDouble, this.LeaveSphereCenter ?? new FVectorDouble());
		this.CacheLocation.DeepCopy(fvectorDouble);
		return Vector.DistSquared(location, this.CacheLocation) > this.LeaveSphereRadiusSq;
	}

	// Token: 0x0400D7CF RID: 55247
	public FVectorDouble? LeaveSphereCenter;

	// Token: 0x0400D7D0 RID: 55248
	public double LeaveSphereRadiusSq;

	// Token: 0x0400D7D1 RID: 55249
	protected readonly Vector CacheLocation = Vector.Create();
}
