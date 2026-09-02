using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002E67 RID: 11879
[NullableContext(1)]
[Nullable(0)]
public class BaseFrozenComponent : EntityComponent
{
	// Token: 0x06018672 RID: 99954 RVA: 0x006D5F15 File Offset: 0x006D4115
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.GetComponent<CharacterActorComponent>();
		this.HitComponent = base.Entity.GetComponent<CharacterHitComponent>();
		this.TimeScaleComponent = base.Entity.CheckGetComponent<PawnTimeScaleComponent>();
		this.AddListenTasks();
		return true;
	}

	// Token: 0x06018673 RID: 99955 RVA: 0x006D5F51 File Offset: 0x006D4151
	protected override bool OnEnd()
	{
		if (this.StunnedTagListenTask != null)
		{
			this.StunnedTagListenTask.EndTask();
			this.StunnedTagListenTask = null;
		}
		if (this.FrozenTagListenTask != null)
		{
			this.FrozenTagListenTask.EndTask();
			this.FrozenTagListenTask = null;
		}
		return true;
	}

	// Token: 0x06018674 RID: 99956 RVA: 0x006D5F88 File Offset: 0x006D4188
	protected override bool OnClear()
	{
		this.FrozenLockSet.Clear();
		return true;
	}

	// Token: 0x06018675 RID: 99957 RVA: 0x006D5F98 File Offset: 0x006D4198
	private void AddListenTasks()
	{
		BaseTagComponent baseTagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.StunnedTagListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["Damage.Stunned"]), new BaseTagComponent.TTagSwitchedCallback(this.StunnedTagListenTaskCallback), null);
	}

	// Token: 0x06018676 RID: 99958 RVA: 0x006D5FDE File Offset: 0x006D41DE
	private void StunnedTagListenTaskCallback(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			this.ActorComponent.Actor.StopAnimMontage(null);
		}
	}

	// Token: 0x06018677 RID: 99959 RVA: 0x006D5FF4 File Offset: 0x006D41F4
	[NullableContext(2)]
	public void AddTimeScaleByBuff(int handleId, int priority, double timeDilation, double? duration, UCurveFloat curve)
	{
		if (this.BuffTimeScaleMap.ContainsKey(handleId))
		{
			return;
		}
		if (this.HitComponent.IsImmuneTimeScaleEffect())
		{
			return;
		}
		int value = this.TimeScaleComponent.SetTimeScale(priority, (float)timeDilation, curve, (float)duration.GetValueOrDefault(10000000.0), ETimeScaleSourceType.Buff, false, false);
		this.BuffTimeScaleMap[handleId] = value;
	}

	// Token: 0x06018678 RID: 99960 RVA: 0x006D6050 File Offset: 0x006D4250
	public void RemoveTimeScaleByBuff(int handleId)
	{
		int id;
		if (this.BuffTimeScaleMap.TryGetValue(handleId, out id))
		{
			this.TimeScaleComponent.RemoveTimeScale(id);
		}
		this.BuffTimeScaleMap.Remove(handleId);
	}

	// Token: 0x06018679 RID: 99961 RVA: 0x006D6088 File Offset: 0x006D4288
	public unsafe void SetForeverTimeScale(int handleId, int priority, float timeDilation)
	{
		this.RemoveForeverTimeScale(handleId);
		float num = timeDilation + this.BaseBuffForeverTimeScale;
		if (num < 0f)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "buff额外效果83设置时间碰撞系数小于0,强制设置为0";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffHandleId", handleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("timeDilation", timeDilation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BaseBuffForeverTimeScale", this.BaseBuffForeverTimeScale);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			num = 0f;
		}
		int value = this.TimeScaleComponent.SetForeverTimeScale(ETimeScaleSourceType.Buff, num, priority, false);
		this.ForeverTimeScaleMap[handleId] = value;
	}

	// Token: 0x0601867A RID: 99962 RVA: 0x006D6158 File Offset: 0x006D4358
	public void RemoveForeverTimeScale(int handleId)
	{
		int id;
		if (this.ForeverTimeScaleMap.TryGetValue(handleId, out id))
		{
			this.TimeScaleComponent.RemoveForeverTimeScale(id, false);
			this.ForeverTimeScaleMap.Remove(handleId);
		}
	}

	// Token: 0x0601867B RID: 99963 RVA: 0x006D6190 File Offset: 0x006D4390
	public void SetBuffBaseForeverTimeScale(float baseBuffTimeScale)
	{
		if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.BaseBuffForeverTimeScale, (double)baseBuffTimeScale, null))
		{
			return;
		}
		this.BaseBuffForeverTimeScale = baseBuffTimeScale;
		if (this.BaseBuffTimeScaleHandle != 0)
		{
			this.TimeScaleComponent.RemoveForeverTimeScale(this.BaseBuffTimeScaleHandle, false);
			this.BaseBuffTimeScaleHandle = 0;
		}
		if (baseBuffTimeScale > 0f)
		{
			this.BaseBuffTimeScaleHandle = this.TimeScaleComponent.SetForeverTimeScale(ETimeScaleSourceType.Buff, baseBuffTimeScale, 0, false);
		}
	}

	// Token: 0x0601867C RID: 99964 RVA: 0x006D6201 File Offset: 0x006D4401
	public virtual bool IsFrozen()
	{
		return false;
	}

	// Token: 0x0601867D RID: 99965 RVA: 0x006D6204 File Offset: 0x006D4404
	protected virtual void SetFrozen(bool bFrozen)
	{
	}

	// Token: 0x0601867E RID: 99966 RVA: 0x006D6208 File Offset: 0x006D4408
	protected virtual void RefreshFrozen()
	{
		bool flag = this.FrozenLockSet.Count > 0;
		this.SetFrozen(flag);
		Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.CharAfterFrozenChange, flag);
	}

	// Token: 0x0601867F RID: 99967 RVA: 0x006D623F File Offset: 0x006D443F
	public void LockFrozen(string lockName)
	{
		if (this.FrozenLockSet.Contains(lockName))
		{
			return;
		}
		this.FrozenLockSet.Add(lockName);
		this.RefreshFrozen();
	}

	// Token: 0x06018680 RID: 99968 RVA: 0x006D6263 File Offset: 0x006D4463
	public void UnlockFrozen(string lockName)
	{
		if (!this.FrozenLockSet.Remove(lockName))
		{
			return;
		}
		this.RefreshFrozen();
	}

	// Token: 0x06018681 RID: 99969 RVA: 0x006D627C File Offset: 0x006D447C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseFrozenComponent baseFrozenComponent = (BaseFrozenComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (baseFrozenComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HitComponent"))
		{
			if (baseFrozenComponent.HitComponent == null)
			{
				this.HitComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterHitComponent>(this.HitComponent), "HitComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TimeScaleComponent"))
		{
			if (baseFrozenComponent.TimeScaleComponent == null)
			{
				this.TimeScaleComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComponent), "TimeScaleComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StunnedTagListenTask"))
		{
			if (baseFrozenComponent.StunnedTagListenTask == null)
			{
				this.StunnedTagListenTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.StunnedTagListenTask), "StunnedTagListenTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FrozenTagListenTask"))
		{
			if (baseFrozenComponent.FrozenTagListenTask == null)
			{
				this.FrozenTagListenTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.FrozenTagListenTask), "FrozenTagListenTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffTimeScaleMap") && baseFrozenComponent.BuffTimeScaleMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.BuffTimeScaleMap), "BuffTimeScaleMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ForeverTimeScaleMap") && baseFrozenComponent.ForeverTimeScaleMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.ForeverTimeScaleMap), "ForeverTimeScaleMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BaseBuffForeverTimeScale"))
		{
			this.BaseBuffForeverTimeScale = baseFrozenComponent.BaseBuffForeverTimeScale;
		}
		if (base.CanResetComponentProperty("BaseBuffTimeScaleHandle"))
		{
			this.BaseBuffTimeScaleHandle = baseFrozenComponent.BaseBuffTimeScaleHandle;
		}
		if (base.CanResetComponentProperty("FrozenLockSet"))
		{
			if (baseFrozenComponent.FrozenLockSet == null)
			{
				this.FrozenLockSet = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<string>(this.FrozenLockSet), "FrozenLockSet"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400BB63 RID: 47971
	[Nullable(2)]
	protected CharacterActorComponent ActorComponent;

	// Token: 0x0400BB64 RID: 47972
	[Nullable(2)]
	private CharacterHitComponent HitComponent;

	// Token: 0x0400BB65 RID: 47973
	[Nullable(2)]
	private PawnTimeScaleComponent TimeScaleComponent;

	// Token: 0x0400BB66 RID: 47974
	[Nullable(2)]
	private ITagTask StunnedTagListenTask;

	// Token: 0x0400BB67 RID: 47975
	[Nullable(2)]
	private ITagTask FrozenTagListenTask;

	// Token: 0x0400BB68 RID: 47976
	private readonly Dictionary<int, int> BuffTimeScaleMap = new Dictionary<int, int>();

	// Token: 0x0400BB69 RID: 47977
	private readonly Dictionary<int, int> ForeverTimeScaleMap = new Dictionary<int, int>();

	// Token: 0x0400BB6A RID: 47978
	private float BaseBuffForeverTimeScale;

	// Token: 0x0400BB6B RID: 47979
	private int BaseBuffTimeScaleHandle;

	// Token: 0x0400BB6C RID: 47980
	protected HashSet<string> FrozenLockSet = new HashSet<string>();
}
