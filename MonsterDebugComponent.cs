using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200317C RID: 12668
[NullableContext(1)]
[Nullable(0)]
public class MonsterDebugComponent : EntityComponent
{
	// Token: 0x0601A413 RID: 107539 RVA: 0x007B8E20 File Offset: 0x007B7020
	protected override bool OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget<int>(base.Entity, EEventName.MonsterDebug, new Action<int>(this.MonsterDebug));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(base.Entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnBeDamage));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		return true;
	}

	// Token: 0x0601A414 RID: 107540 RVA: 0x007B8E8B File Offset: 0x007B708B
	protected override void OnTick(float delta)
	{
		if (this.HasBeenHit && !this.MarkedDirty)
		{
			this.TimeCount += delta;
		}
	}

	// Token: 0x0601A415 RID: 107541 RVA: 0x007B8EAC File Offset: 0x007B70AC
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget<int>(base.Entity, EEventName.MonsterDebug, new Action<int>(this.MonsterDebug));
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(base.Entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnBeDamage));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
		this.DestroyTimer();
		return true;
	}

	// Token: 0x0601A416 RID: 107542 RVA: 0x007B8F20 File Offset: 0x007B7120
	private void MonsterDebug(int attackerEntityId)
	{
		if (this.HasBeenHit)
		{
			return;
		}
		if (!base.Entity.Active)
		{
			return;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		bool flag;
		if (instance == null)
		{
			flag = true;
		}
		else
		{
			EntityHandle getCurrentEntity = instance.GetCurrentEntity;
			int? num;
			if (getCurrentEntity == null)
			{
				num = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				num = ((entity != null) ? new int?(entity.Id) : null);
			}
			int? num2 = num;
			flag = !(num2.GetValueOrDefault() == attackerEntityId & num2 != null);
		}
		if (flag)
		{
			return;
		}
		if (this.ShouldIgnoreOwnConcomitantDebug())
		{
			return;
		}
		if (ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			this.IsInFight = true;
		}
		this.SetTimer();
		this.HasBeenHit = true;
	}

	// Token: 0x0601A417 RID: 107543 RVA: 0x007B8FC8 File Offset: 0x007B71C8
	private bool ShouldIgnoreOwnConcomitantDebug()
	{
		if (this.IsOwnConcomitantTarget != null)
		{
			return this.IsOwnConcomitantTarget.Value;
		}
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return false;
		}
		if (!component.IsConcomitantEntity)
		{
			this.IsOwnConcomitantTarget = new bool?(false);
			return this.IsOwnConcomitantTarget.Value;
		}
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		if (instance == null)
		{
			return false;
		}
		this.IsOwnConcomitantTarget = new bool?(component.GetSummonerPlayerId() == instance.GetPlayerId());
		return this.IsOwnConcomitantTarget.Value;
	}

	// Token: 0x0601A418 RID: 107544 RVA: 0x007B904E File Offset: 0x007B724E
	private void OnBeDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition)
	{
		this.HasBeenDamaged = true;
	}

	// Token: 0x0601A419 RID: 107545 RVA: 0x007B9057 File Offset: 0x007B7257
	private unsafe void SetTimer()
	{
		this.Timer = TimerSystem.FlowTimeInstance.Delay(delegate(float _)
		{
			this.DestroyTimer();
			Entity entity = base.Entity;
			uint num = (entity != null) ? entity.GameBudgetManagedToken : 0U;
			if (this.TimeCount <= 100f)
			{
				this.MarkedDirty = true;
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				Entity entity2 = base.Entity;
				string message = "怪物状态出问题了！不Tick！";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TimeCount", this.TimeCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DebugInfo", ControllerBase<LogController>.Instance.OutputDebugInfo(false));
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item = "location";
				Entity entity3 = base.Entity;
				object item2;
				if (entity3 == null)
				{
					item2 = null;
				}
				else
				{
					BaseActorComponent component = entity3.GetComponent<BaseActorComponent>();
					item2 = ((component != null) ? component.ActorLocationProxy : null);
				}
				ptr = new ValueTuple<string, object>(item, item2);
				ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
				string item3 = "centerRoleLocation";
				AActor centerRole = Singleton<GameBudgetInterfaceController>.Instance.CenterRole;
				ptr2 = new ValueTuple<string, object>(item3, (centerRole != null) ? new FVector?(centerRole.K2_GetActorLocation()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("centerOffset", Singleton<GameBudgetInterfaceController>.Instance.GetCenterOffset());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("debugStr", (num != 0U) ? UKuroGameBudgetAllocatorCSharpInterface.GetGameBudgetDebugString(num) : null);
				instance.Error(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
			if (!this.HasBeenDamaged)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
				Entity entity4 = base.Entity;
				string message2 = "怪物状态出问题了！没有伤害结算！";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("DebugInfo", ControllerBase<LogController>.Instance.OutputDebugInfo(false));
				ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
				string item4 = "location";
				Entity entity5 = base.Entity;
				object item5;
				if (entity5 == null)
				{
					item5 = null;
				}
				else
				{
					BaseActorComponent component2 = entity5.GetComponent<BaseActorComponent>();
					item5 = ((component2 != null) ? component2.ActorLocationProxy : null);
				}
				ptr3 = new ValueTuple<string, object>(item4, item5);
				ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
				string item6 = "centerRoleLocation";
				AActor centerRole2 = Singleton<GameBudgetInterfaceController>.Instance.CenterRole;
				ptr4 = new ValueTuple<string, object>(item6, (centerRole2 != null) ? new FVector?(centerRole2.K2_GetActorLocation()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("centerOffset", Singleton<GameBudgetInterfaceController>.Instance.GetCenterOffset());
				instance2.Error(flag2, entity4, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			}
			if (!this.IsInFight)
			{
				CombatLog instance3 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Skill;
				Entity entity6 = base.Entity;
				string message3 = "怪物状态出问题了！没有进入战斗状态！";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("TimeCount", this.TimeCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("DebugInfo", ControllerBase<LogController>.Instance.OutputDebugInfo(false));
				ref ValueTuple<string, object> ptr5 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2);
				string item7 = "location";
				Entity entity7 = base.Entity;
				object item8;
				if (entity7 == null)
				{
					item8 = null;
				}
				else
				{
					BaseActorComponent component3 = entity7.GetComponent<BaseActorComponent>();
					item8 = ((component3 != null) ? component3.ActorLocationProxy : null);
				}
				ptr5 = new ValueTuple<string, object>(item7, item8);
				ref ValueTuple<string, object> ptr6 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3);
				string item9 = "centerRoleLocation";
				AActor centerRole3 = Singleton<GameBudgetInterfaceController>.Instance.CenterRole;
				ptr6 = new ValueTuple<string, object>(item9, (centerRole3 != null) ? new FVector?(centerRole3.K2_GetActorLocation()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("centerOffset", Singleton<GameBudgetInterfaceController>.Instance.GetCenterOffset());
				instance3.Error(flag3, entity6, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
			}
		}, 5000f, null, null, true, 1f);
	}

	// Token: 0x0601A41A RID: 107546 RVA: 0x007B9082 File Offset: 0x007B7282
	private void DestroyTimer()
	{
		if (TimerSystem.FlowTimeInstance.Has(this.Timer))
		{
			TimerSystem.FlowTimeInstance.Remove(this.Timer);
			this.Timer = null;
		}
	}

	// Token: 0x0601A41B RID: 107547 RVA: 0x007B90AE File Offset: 0x007B72AE
	private void OnBattleStateChanged(bool inFight)
	{
		if (inFight)
		{
			this.IsInFight = true;
		}
	}

	// Token: 0x0601A41C RID: 107548 RVA: 0x007B90BC File Offset: 0x007B72BC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		MonsterDebugComponent monsterDebugComponent = (MonsterDebugComponent)componentTemplate;
		if (base.CanResetComponentProperty("TimeCount"))
		{
			this.TimeCount = monsterDebugComponent.TimeCount;
		}
		if (base.CanResetComponentProperty("HasBeenHit"))
		{
			this.HasBeenHit = monsterDebugComponent.HasBeenHit;
		}
		if (base.CanResetComponentProperty("HasBeenDamaged"))
		{
			this.HasBeenDamaged = monsterDebugComponent.HasBeenDamaged;
		}
		if (base.CanResetComponentProperty("Timer"))
		{
			if (monsterDebugComponent.Timer == null)
			{
				this.Timer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.Timer), "Timer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MarkedDirty"))
		{
			this.MarkedDirty = monsterDebugComponent.MarkedDirty;
		}
		if (base.CanResetComponentProperty("IsInFight"))
		{
			this.IsInFight = monsterDebugComponent.IsInFight;
		}
		if (base.CanResetComponentProperty("IsOwnConcomitantTarget"))
		{
			this.IsOwnConcomitantTarget = monsterDebugComponent.IsOwnConcomitantTarget;
		}
		return true;
	}

	// Token: 0x0400D365 RID: 54117
	private const float DELAY_TIME = 5000f;

	// Token: 0x0400D366 RID: 54118
	private const float CHECK_TIME = 100f;

	// Token: 0x0400D367 RID: 54119
	private float TimeCount;

	// Token: 0x0400D368 RID: 54120
	private bool HasBeenHit;

	// Token: 0x0400D369 RID: 54121
	private bool HasBeenDamaged;

	// Token: 0x0400D36A RID: 54122
	[Nullable(2)]
	private TimerHandle Timer;

	// Token: 0x0400D36B RID: 54123
	private bool MarkedDirty;

	// Token: 0x0400D36C RID: 54124
	private bool IsInFight;

	// Token: 0x0400D36D RID: 54125
	private bool? IsOwnConcomitantTarget;
}
