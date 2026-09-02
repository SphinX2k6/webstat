using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x0200300D RID: 12301
[NullableContext(1)]
[Nullable(0)]
public class BaseGravityComponent : EntityComponent
{
	// Token: 0x06019129 RID: 102697 RVA: 0x0071FE28 File Offset: 0x0071E028
	protected override bool OnStart()
	{
		this.MoveComp = base.Entity.GetComponent<BaseMoveComponent>();
		if (this.MoveComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.YZ, "[BaseGravityComponent] BaseMoveComponent not found", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.InitGravityDirect();
		return true;
	}

	// Token: 0x0601912A RID: 102698 RVA: 0x0071FE70 File Offset: 0x0071E070
	protected override bool OnEnd()
	{
		this.GravitySlots.Clear();
		this.ActivePriority = null;
		return true;
	}

	// Token: 0x0601912B RID: 102699 RVA: 0x0071FE8C File Offset: 0x0071E08C
	protected void InitGravityDirect()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		Aki.Protocol.Vector initGravityDirection = component.GetInitGravityDirection();
		if (initGravityDirection != null)
		{
			this.SetDefaultGravityDirect(global::Vector.Create(initGravityDirection));
		}
	}

	// Token: 0x0601912C RID: 102700 RVA: 0x0071FEBF File Offset: 0x0071E0BF
	public void SetDefaultGravityDirect(IVector v)
	{
		this.DefaultGravityDirect.Set(v.X, v.Y, v.Z);
		if (this.ActivePriority == null)
		{
			this.ApplyGravityToMoveComp(this.DefaultGravityDirect, true, -1f, true);
		}
	}

	// Token: 0x0601912D RID: 102701 RVA: 0x0071FF00 File Offset: 0x0071E100
	public void SetGravityByPriority(int priority, IVector direction, bool clearGround = true, float overrideSmoothTime = -1f, bool withoutRotate = false)
	{
		BaseGravityComponent.GravitySlot gravitySlot;
		if (!this.GravitySlots.TryGetValue(priority, out gravitySlot))
		{
			gravitySlot = new BaseGravityComponent.GravitySlot();
			this.GravitySlots[priority] = gravitySlot;
		}
		gravitySlot.Direction.Set(direction.X, direction.Y, direction.Z);
		gravitySlot.Active = true;
		this.EvaluateAndApply(clearGround, overrideSmoothTime, withoutRotate);
	}

	// Token: 0x0601912E RID: 102702 RVA: 0x0071FF60 File Offset: 0x0071E160
	public void StopGravityByPriority(int priority, bool clearGround = true, float overrideSmoothTime = -1f, bool withoutRotate = false)
	{
		BaseGravityComponent.GravitySlot gravitySlot;
		if (!this.GravitySlots.TryGetValue(priority, out gravitySlot) || !gravitySlot.Active)
		{
			return;
		}
		gravitySlot.Active = false;
		this.EvaluateAndApply(clearGround, overrideSmoothTime, withoutRotate);
	}

	// Token: 0x0601912F RID: 102703 RVA: 0x0071FF97 File Offset: 0x0071E197
	public global::Vector GetDefaultGravityDirect()
	{
		return this.DefaultGravityDirect;
	}

	// Token: 0x06019130 RID: 102704 RVA: 0x0071FFA0 File Offset: 0x0071E1A0
	public global::Vector GetActiveGravityDirect()
	{
		BaseGravityComponent.GravitySlot gravitySlot;
		if (this.ActivePriority != null && this.GravitySlots.TryGetValue(this.ActivePriority.Value, out gravitySlot) && gravitySlot.Active)
		{
			return gravitySlot.Direction;
		}
		return this.DefaultGravityDirect;
	}

	// Token: 0x06019131 RID: 102705 RVA: 0x0071FFE9 File Offset: 0x0071E1E9
	public int? GetActivePriority()
	{
		return this.ActivePriority;
	}

	// Token: 0x06019132 RID: 102706 RVA: 0x0071FFF4 File Offset: 0x0071E1F4
	public bool IsPriorityActive(int priority)
	{
		BaseGravityComponent.GravitySlot gravitySlot;
		return this.GravitySlots.TryGetValue(priority, out gravitySlot) && gravitySlot.Active;
	}

	// Token: 0x06019133 RID: 102707 RVA: 0x0072001C File Offset: 0x0071E21C
	private void EvaluateAndApply(bool clearGround, float overrideSmoothTime, bool withoutRotate)
	{
		int? num = null;
		foreach (KeyValuePair<int, BaseGravityComponent.GravitySlot> keyValuePair in this.GravitySlots)
		{
			int num2;
			BaseGravityComponent.GravitySlot gravitySlot;
			keyValuePair.Deconstruct(out num2, out gravitySlot);
			int num3 = num2;
			if (gravitySlot.Active)
			{
				if (num != null)
				{
					int num4 = num3;
					int? num5 = num;
					if (!(num4 > num5.GetValueOrDefault() & num5 != null))
					{
						continue;
					}
				}
				num = new int?(num3);
			}
		}
		this.ActivePriority = num;
		if (num != null)
		{
			BaseGravityComponent.GravitySlot gravitySlot2 = this.GravitySlots[num.Value];
			this.ApplyGravityToMoveComp(gravitySlot2.Direction, clearGround, overrideSmoothTime, withoutRotate);
			return;
		}
		this.ApplyGravityToMoveComp(this.DefaultGravityDirect, clearGround, overrideSmoothTime, withoutRotate);
	}

	// Token: 0x06019134 RID: 102708 RVA: 0x007200F4 File Offset: 0x0071E2F4
	protected virtual void ApplyGravityToMoveComp(global::Vector direction, bool clearGround = true, float overrideSmoothTime = -1f, bool withoutRotate = false)
	{
		if (this.MoveComp == null)
		{
			return;
		}
		if (withoutRotate || this.HasForbidRotateTag())
		{
			this.MoveComp.SetGravityDirectWithoutRotateByNumber(direction.X, direction.Y, direction.Z);
			return;
		}
		this.MoveComp.SetGravityDirectByNumber(direction.X, direction.Y, direction.Z, clearGround, overrideSmoothTime);
	}

	// Token: 0x06019135 RID: 102709 RVA: 0x00720154 File Offset: 0x0071E354
	private bool HasForbidRotateTag()
	{
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component == null)
		{
			return false;
		}
		foreach (int tagId in BaseGravityComponent.ForbidRotateTagIds)
		{
			if (component.HasTag(tagId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06019136 RID: 102710 RVA: 0x00720198 File Offset: 0x0071E398
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseGravityComponent baseGravityComponent = (BaseGravityComponent)componentTemplate;
		if (base.CanResetComponentProperty("GravitySlots") && baseGravityComponent.GravitySlots != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, BaseGravityComponent.GravitySlot>>(this.GravitySlots), "GravitySlots"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DefaultGravityDirect") && baseGravityComponent.DefaultGravityDirect != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.DefaultGravityDirect), "DefaultGravityDirect"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ActivePriority"))
		{
			this.ActivePriority = baseGravityComponent.ActivePriority;
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (baseGravityComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C461 RID: 50273
	[StaticVariableRuleIgnore]
	private static readonly int[] ForbidRotateTagIds = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.摩托"]
	};

	// Token: 0x0400C462 RID: 50274
	private readonly Dictionary<int, BaseGravityComponent.GravitySlot> GravitySlots = new Dictionary<int, BaseGravityComponent.GravitySlot>();

	// Token: 0x0400C463 RID: 50275
	private readonly global::Vector DefaultGravityDirect = global::Vector.Create(0.0, 0.0, -1.0);

	// Token: 0x0400C464 RID: 50276
	private int? ActivePriority;

	// Token: 0x0400C465 RID: 50277
	[Nullable(2)]
	protected BaseMoveComponent MoveComp;

	// Token: 0x0200935B RID: 37723
	[NullableContext(0)]
	private class GravitySlot
	{
		// Token: 0x040310B6 RID: 200886
		public bool Active;

		// Token: 0x040310B7 RID: 200887
		[Nullable(1)]
		public readonly global::Vector Direction = global::Vector.Create();
	}
}
