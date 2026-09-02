using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020025B7 RID: 9655
[NullableContext(2)]
[Nullable(0)]
public class PhotoTargetCandidate
{
	// Token: 0x06012D71 RID: 77169 RVA: 0x00534F68 File Offset: 0x00533168
	private PhotoTargetCandidate(EntityHandle entity, AActor actor)
	{
		this.Entity = entity;
		this.Actor = actor;
	}

	// Token: 0x06012D72 RID: 77170 RVA: 0x00534F80 File Offset: 0x00533180
	public Vector GetPosition()
	{
		if (this.Entity != null)
		{
			WorldEntity entity = this.Entity.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent == null)
			{
				return null;
			}
			return baseActorComponent.ActorLocationProxy;
		}
		else
		{
			if (this.Actor != null)
			{
				FVectorDouble fvectorDouble = this.Actor.D_K2_GetActorLocation();
				return Vector.Create(fvectorDouble.X, fvectorDouble.Y, fvectorDouble.Z);
			}
			return null;
		}
	}

	// Token: 0x06012D73 RID: 77171 RVA: 0x00534FE8 File Offset: 0x005331E8
	public int? GetPbDataId()
	{
		EntityHandle entity = this.Entity;
		if (entity == null)
		{
			return null;
		}
		return new int?(entity.PbDataId);
	}

	// Token: 0x06012D74 RID: 77172 RVA: 0x00535013 File Offset: 0x00533213
	public AActor GetActor()
	{
		if (this.Entity == null)
		{
			return this.Actor;
		}
		WorldEntity entity = this.Entity.Entity;
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null)
		{
			return null;
		}
		return baseActorComponent.Owner;
	}

	// Token: 0x06012D75 RID: 77173 RVA: 0x00535046 File Offset: 0x00533246
	[NullableContext(1)]
	public static PhotoTargetCandidate CreateFromEntity(EntityHandle handle)
	{
		return new PhotoTargetCandidate(handle, null);
	}

	// Token: 0x06012D76 RID: 77174 RVA: 0x0053504F File Offset: 0x0053324F
	[NullableContext(1)]
	public static PhotoTargetCandidate CreateFromActor(AActor actor)
	{
		return new PhotoTargetCandidate(null, actor);
	}

	// Token: 0x04009348 RID: 37704
	private readonly EntityHandle Entity;

	// Token: 0x04009349 RID: 37705
	private readonly AActor Actor;
}
