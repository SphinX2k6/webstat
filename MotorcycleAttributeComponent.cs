using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003299 RID: 12953
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleAttributeComponent : CharacterAttributeComponent
{
	// Token: 0x170024E2 RID: 9442
	// (get) Token: 0x0601B200 RID: 111104 RVA: 0x0082368B File Offset: 0x0082188B
	// (set) Token: 0x0601B201 RID: 111105 RVA: 0x00823693 File Offset: 0x00821893
	protected bool BeRidden
	{
		get
		{
			return this.BeRiddenInternal;
		}
		set
		{
			if (this.BeRiddenInternal == value)
			{
				return;
			}
			this.BeRiddenInternal = value;
			this.RefreshRecoverSpEnBuff();
		}
	}

	// Token: 0x170024E3 RID: 9443
	// (get) Token: 0x0601B202 RID: 111106 RVA: 0x008236AC File Offset: 0x008218AC
	// (set) Token: 0x0601B203 RID: 111107 RVA: 0x008236B4 File Offset: 0x008218B4
	protected bool TwoWheelOnGround
	{
		get
		{
			return this.TwoWheelOnGroundInternal;
		}
		set
		{
			if (value)
			{
				if (this.TwoWheelOnGroundTimer != null)
				{
					this.TwoWheelOnGroundTimer.Remove();
					this.TwoWheelOnGroundTimer = null;
				}
				this.TwoWheelOnGroundInternal = true;
				this.RefreshRecoverSpEnBuff();
				return;
			}
			if (this.TwoWheelOnGroundTimer != null)
			{
				return;
			}
			this.TwoWheelOnGroundTimer = TimerSystem.Instance.Delay(delegate(float id)
			{
				this.TwoWheelOnGroundTimer = null;
				this.TwoWheelOnGroundInternal = false;
				this.RefreshRecoverSpEnBuff();
			}, MotorcycleAttributeComponent.CANNOT_RECOVER_SP_EN_TIMER, null, null, true, 1f);
		}
	}

	// Token: 0x170024E4 RID: 9444
	// (get) Token: 0x0601B204 RID: 111108 RVA: 0x0082371F File Offset: 0x0082191F
	// (set) Token: 0x0601B205 RID: 111109 RVA: 0x00823727 File Offset: 0x00821927
	protected bool NeedRecoverSpEn
	{
		get
		{
			return this.NeedRecoverSpEnInternal;
		}
		set
		{
			if (this.NeedRecoverSpEnInternal == value)
			{
				return;
			}
			this.NeedRecoverSpEnInternal = value;
			this.RefreshRecoverSpEnBuff();
		}
	}

	// Token: 0x170024E5 RID: 9445
	// (get) Token: 0x0601B206 RID: 111110 RVA: 0x00823740 File Offset: 0x00821940
	// (set) Token: 0x0601B207 RID: 111111 RVA: 0x00823748 File Offset: 0x00821948
	protected bool BuffForRecoverSpEn
	{
		get
		{
			return this.BuffForRecoverSpEnInternal;
		}
		set
		{
			if (this.BuffForRecoverSpEnInternal == value)
			{
				return;
			}
			this.BuffForRecoverSpEnInternal = value;
			if (!value)
			{
				foreach (long buffId in (this.TagComp != null && this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.科技树.战斗相关.科技树3节点8"])) ? MotorcycleAttributeComponent.SpecialEnergyBuffIdsUpgraded : MotorcycleAttributeComponent.SpecialEnergyBuffIds)
				{
					CharacterBuffComponent buffComponent = base.BuffComponent;
					if (buffComponent != null)
					{
						buffComponent.RemoveBuff(buffId, -1, "蓄能飞跃体力", null, null, null);
					}
				}
				return;
			}
			long[] array2 = (this.TagComp != null && this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.科技树.战斗相关.科技树3节点8"])) ? MotorcycleAttributeComponent.SpecialEnergyBuffIdsUpgraded : MotorcycleAttributeComponent.SpecialEnergyBuffIds;
			CharacterBuffComponent buffComponent2 = base.BuffComponent;
			if (buffComponent2 == null)
			{
				return;
			}
			buffComponent2.AddBuff(array2[0], new AddBuffParam
			{
				InstigatorId = base.BuffComponent.CreatureDataId,
				Reason = "蓄能飞跃体力"
			});
		}
	}

	// Token: 0x170024E6 RID: 9446
	// (get) Token: 0x0601B208 RID: 111112 RVA: 0x00823848 File Offset: 0x00821A48
	// (set) Token: 0x0601B209 RID: 111113 RVA: 0x00823850 File Offset: 0x00821A50
	protected bool SpEnEmpty
	{
		get
		{
			return this.SpEnEmptyInternal;
		}
		set
		{
			if (this.SpEnEmptyInternal == value)
			{
				return;
			}
			this.SpEnEmptyInternal = value;
			if (value)
			{
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp == null)
				{
					return;
				}
				tagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用蓄力跳.能量耗尽"]));
				return;
			}
			else
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 == null)
				{
					return;
				}
				tagComp2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁用蓄力跳.能量耗尽"]));
				return;
			}
		}
	}

	// Token: 0x0601B20A RID: 111114 RVA: 0x008238BC File Offset: 0x00821ABC
	protected override bool OnStart()
	{
		bool flag = base.OnStart();
		if (!flag)
		{
			return flag;
		}
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.AddMotorListen();
		return true;
	}

	// Token: 0x0601B20B RID: 111115 RVA: 0x008238ED File Offset: 0x00821AED
	protected override bool OnEnd()
	{
		this.RemoveMotorListen();
		if (this.TwoWheelOnGroundTimer != null)
		{
			this.TwoWheelOnGroundTimer.Remove();
			this.TwoWheelOnGroundTimer = null;
		}
		return base.OnEnd();
	}

	// Token: 0x0601B20C RID: 111116 RVA: 0x00823918 File Offset: 0x00821B18
	private void AddMotorListen()
	{
		VehiclePerformComponent component = base.Entity.GetComponent<VehiclePerformComponent>();
		this.BeRidden = (((component != null) ? component.Driver : null) != null);
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
		MotorcycleMoveComponent component2 = base.Entity.GetComponent<MotorcycleMoveComponent>();
		EMotorSubState? emotorSubState = (component2 != null) ? new EMotorSubState?(component2.MotorSubState) : null;
		EMotorSubState? emotorSubState2 = emotorSubState;
		EMotorSubState emotorSubState3 = EMotorSubState.TwoWheelMoving;
		bool twoWheelOnGround;
		if (!(emotorSubState2.GetValueOrDefault() == emotorSubState3 & emotorSubState2 != null))
		{
			emotorSubState2 = emotorSubState;
			emotorSubState3 = EMotorSubState.Stop;
			twoWheelOnGround = (emotorSubState2.GetValueOrDefault() == emotorSubState3 & emotorSubState2 != null);
		}
		else
		{
			twoWheelOnGround = true;
		}
		this.TwoWheelOnGround = twoWheelOnGround;
		Singleton<EventSystem>.Instance.AddWithTarget<EMotorSubState, EMotorSubState>(base.Entity, EEventName.MotorSubStateModeChange, new Action<EMotorSubState, EMotorSubState>(this.MotorSubStateModeChanged));
		this.NeedRecoverSpEn = (base.GetCurrentValue(EAttributeType.SpecialEnergy1) < base.GetCurrentValue(EAttributeType.SpecialEnergy1Max));
		base.AddListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttr62Changed), null);
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null)
		{
			tagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁止蓄力能量恢复"], new BaseTagComponent.TTagSwitchedCallback(this.OnBanSpEnRecoverTagChanged), null);
		}
		this.RefreshRecoverSpEnBuff();
	}

	// Token: 0x0601B20D RID: 111117 RVA: 0x00823A48 File Offset: 0x00821C48
	private void RemoveMotorListen()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
		Singleton<EventSystem>.Instance.RemoveWithTarget<EMotorSubState, EMotorSubState>(base.Entity, EEventName.MotorSubStateModeChange, new Action<EMotorSubState, EMotorSubState>(this.MotorSubStateModeChanged));
		base.RemoveListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttr62Changed));
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null)
		{
			return;
		}
		tagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁止蓄力能量恢复"], new BaseTagComponent.TTagSwitchedCallback(this.OnBanSpEnRecoverTagChanged));
	}

	// Token: 0x0601B20E RID: 111118 RVA: 0x00823ADC File Offset: 0x00821CDC
	private void RefreshRecoverSpEnBuff()
	{
		this.BuffForRecoverSpEn = ((this.TagComp == null || !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["载具.摩托.功能开关.禁止蓄力能量恢复"])) && this.BeRidden && this.NeedRecoverSpEn && this.TwoWheelOnGround);
	}

	// Token: 0x0601B20F RID: 111119 RVA: 0x00823B2C File Offset: 0x00821D2C
	[NullableContext(2)]
	private void OnVehicleDriverChange(Entity oldDriver, Entity newDriver)
	{
		this.BeRidden = (newDriver != null);
	}

	// Token: 0x0601B210 RID: 111120 RVA: 0x00823B38 File Offset: 0x00821D38
	private void MotorSubStateModeChanged(EMotorSubState newState, EMotorSubState oldState)
	{
		this.TwoWheelOnGround = (newState == EMotorSubState.TwoWheelMoving || newState == EMotorSubState.Stop);
	}

	// Token: 0x0601B211 RID: 111121 RVA: 0x00823B4B File Offset: 0x00821D4B
	private void OnAttr62Changed(EAttributeType attrId, float newValue, float oldValue)
	{
		this.NeedRecoverSpEn = (newValue < base.GetCurrentValue(EAttributeType.SpecialEnergy1Max));
		this.SpEnEmpty = (newValue < 100f);
	}

	// Token: 0x0601B212 RID: 111122 RVA: 0x00823B6C File Offset: 0x00821D6C
	private void OnBanSpEnRecoverTagChanged(int tagId, bool tagExist)
	{
		this.RefreshRecoverSpEnBuff();
	}

	// Token: 0x0601B213 RID: 111123 RVA: 0x00823B74 File Offset: 0x00821D74
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MotorcycleAttributeComponent motorcycleAttributeComponent = (MotorcycleAttributeComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (motorcycleAttributeComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BeRiddenInternal"))
		{
			this.BeRiddenInternal = motorcycleAttributeComponent.BeRiddenInternal;
		}
		if (base.CanResetComponentProperty("TwoWheelOnGroundTimer"))
		{
			if (motorcycleAttributeComponent.TwoWheelOnGroundTimer == null)
			{
				this.TwoWheelOnGroundTimer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.TwoWheelOnGroundTimer), "TwoWheelOnGroundTimer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TwoWheelOnGroundInternal"))
		{
			this.TwoWheelOnGroundInternal = motorcycleAttributeComponent.TwoWheelOnGroundInternal;
		}
		if (base.CanResetComponentProperty("NeedRecoverSpEnInternal"))
		{
			this.NeedRecoverSpEnInternal = motorcycleAttributeComponent.NeedRecoverSpEnInternal;
		}
		if (base.CanResetComponentProperty("BuffForRecoverSpEnInternal"))
		{
			this.BuffForRecoverSpEnInternal = motorcycleAttributeComponent.BuffForRecoverSpEnInternal;
		}
		if (base.CanResetComponentProperty("SpEnEmptyInternal"))
		{
			this.SpEnEmptyInternal = motorcycleAttributeComponent.SpEnEmptyInternal;
		}
		return true;
	}

	// Token: 0x0400DCCB RID: 56523
	[StaticVariableRuleIgnore]
	private static readonly long[] SpecialEnergyBuffIds = new long[]
	{
		7100000056L,
		7100000057L,
		7100000058L
	};

	// Token: 0x0400DCCC RID: 56524
	[StaticVariableRuleIgnore]
	private static readonly long[] SpecialEnergyBuffIdsUpgraded = new long[]
	{
		7100000059L,
		7100000060L,
		7100000061L
	};

	// Token: 0x0400DCCD RID: 56525
	[StaticVariableRuleIgnore]
	private static float CANNOT_RECOVER_SP_EN_TIMER = 500f;

	// Token: 0x0400DCCE RID: 56526
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400DCCF RID: 56527
	private bool BeRiddenInternal;

	// Token: 0x0400DCD0 RID: 56528
	[Nullable(2)]
	private TimerHandle TwoWheelOnGroundTimer;

	// Token: 0x0400DCD1 RID: 56529
	private bool TwoWheelOnGroundInternal;

	// Token: 0x0400DCD2 RID: 56530
	private bool NeedRecoverSpEnInternal;

	// Token: 0x0400DCD3 RID: 56531
	private bool BuffForRecoverSpEnInternal;

	// Token: 0x0400DCD4 RID: 56532
	private bool SpEnEmptyInternal;
}
