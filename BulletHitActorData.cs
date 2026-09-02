using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E00 RID: 11776
[NullableContext(2)]
[Nullable(0)]
public class BulletHitActorData
{
	// Token: 0x1700202C RID: 8236
	// (get) Token: 0x06017C7B RID: 97403 RVA: 0x006A0DB4 File Offset: 0x0069EFB4
	public Entity Entity
	{
		get
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null)
			{
				return null;
			}
			return entityHandle.Entity;
		}
	}

	// Token: 0x06017C7C RID: 97404 RVA: 0x006A0DC7 File Offset: 0x0069EFC7
	[NullableContext(1)]
	public void AddComponent(UPrimitiveComponent comp)
	{
		if (this.Components == null)
		{
			this.Components = new List<UPrimitiveComponent>();
		}
		this.Components.Add(comp);
	}

	// Token: 0x06017C7D RID: 97405 RVA: 0x006A0DE8 File Offset: 0x0069EFE8
	public void AddHitResult(UKuroHitResult hitResult, int index)
	{
		if (this.HitResult == null)
		{
			this.HitResult = new BulletHitResult();
		}
		this.HitResult.AppendHitResult(hitResult, index);
	}

	// Token: 0x06017C7E RID: 97406 RVA: 0x006A0E0A File Offset: 0x0069F00A
	[NullableContext(1)]
	public void AddHitTempResult(BulletHitTempResult hitTempResult, string boneName)
	{
		if (this.HitResult == null)
		{
			this.HitResult = new BulletHitResult();
		}
		this.HitResult.AppendHitTempResult(hitTempResult, boneName);
	}

	// Token: 0x06017C7F RID: 97407 RVA: 0x006A0E2C File Offset: 0x0069F02C
	[NullableContext(1)]
	public bool HasComponent(UPrimitiveComponent comp)
	{
		List<UPrimitiveComponent> components = this.Components;
		return components != null && components.Contains(comp);
	}

	// Token: 0x06017C80 RID: 97408 RVA: 0x006A0E40 File Offset: 0x0069F040
	public void Clear()
	{
		this.Type = EBulletHitActorType.Ignore;
		this.EntityHandle = null;
		List<UPrimitiveComponent> components = this.Components;
		if (components != null)
		{
			components.Clear();
		}
		this.Components = null;
		this.Actor = null;
		this.IsValidHit = false;
		this.IsContinueHit = false;
		this.FromObstaclesCollision = false;
		this.Priority = 0;
		this.ValidProcessIndex = 0;
		this.HitResult = null;
		this.ConditionResult = null;
	}

	// Token: 0x0400B7F3 RID: 47091
	public EBulletHitActorType Type;

	// Token: 0x0400B7F4 RID: 47092
	public EntityHandle EntityHandle;

	// Token: 0x0400B7F5 RID: 47093
	public int BulletEntityId;

	// Token: 0x0400B7F6 RID: 47094
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<UPrimitiveComponent> Components;

	// Token: 0x0400B7F7 RID: 47095
	public AActor Actor;

	// Token: 0x0400B7F8 RID: 47096
	public bool IsValidHit;

	// Token: 0x0400B7F9 RID: 47097
	public bool IsContinueHit;

	// Token: 0x0400B7FA RID: 47098
	public bool FromObstaclesCollision;

	// Token: 0x0400B7FB RID: 47099
	public int Priority;

	// Token: 0x0400B7FC RID: 47100
	public int ValidProcessIndex;

	// Token: 0x0400B7FD RID: 47101
	public BulletHitResult HitResult;

	// Token: 0x0400B7FE RID: 47102
	public BulletConditionResult ConditionResult;
}
