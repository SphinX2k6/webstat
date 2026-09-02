using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x0200303A RID: 12346
[NullableContext(1)]
[Nullable(0)]
public class CharacterFightStateComponent : EntityComponent
{
	// Token: 0x06019418 RID: 103448 RVA: 0x0073E278 File Offset: 0x0073C478
	protected override bool OnStart()
	{
		this.UnifiedComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		return true;
	}

	// Token: 0x06019419 RID: 103449 RVA: 0x0073E28C File Offset: 0x0073C48C
	public bool PreSwitchRemoteFightState(int fightState)
	{
		int state = fightState >> 8;
		int num = fightState & 255;
		bool flag = this.CheckSwitchState((ECharacterFightState)state, num, false);
		if (!flag)
		{
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.FightState, base.Entity, "预切换状态失败，" + this.TargetStateToString(state, num) + "，" + this.CurrentStateToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return flag;
	}

	// Token: 0x0601941A RID: 103450 RVA: 0x0073E2EC File Offset: 0x0073C4EC
	public int TrySwitchHitState(EHitAnim hitAnim, bool isLocal = false)
	{
		if (hitAnim == EHitAnim.被破弱)
		{
			return this.TrySwitchState(ECharacterFightState.BeBrokeWeakness, 0, isLocal);
		}
		if (hitAnim == EHitAnim.被弹反)
		{
			return this.TrySwitchState(ECharacterFightState.CounterattackBeHit, 0, isLocal);
		}
		if (isLocal && this.UnifiedComp.PositionState == ECharPositionState.Air)
		{
			return this.TrySwitchState(ECharacterFightState.BeHit, 2, isLocal);
		}
		if (hitAnim - EHitAnim.击飞 <= 1)
		{
			return this.TrySwitchState(ECharacterFightState.BeHit, 2, isLocal);
		}
		if (hitAnim != EHitAnim.压制)
		{
			return this.TrySwitchState(ECharacterFightState.BeHit, 0, isLocal);
		}
		return this.TrySwitchState(ECharacterFightState.BeHit, 1, isLocal);
	}

	// Token: 0x0601941B RID: 103451 RVA: 0x0073E35C File Offset: 0x0073C55C
	public int TrySwitchSkillState(int interruptLevel, SSkillInfo skillInfo, bool isLocal = false)
	{
		int num = interruptLevel;
		if (num > 255)
		{
			num = 255;
		}
		if (skillInfo.OverrideType == ESkillOverrideType.覆盖受击)
		{
			return this.TrySwitchState(ECharacterFightState.OverrideBeHitSkill, num, isLocal);
		}
		if (skillInfo.OverrideType == ESkillOverrideType.覆盖弹反)
		{
			return this.TrySwitchState(ECharacterFightState.OverrideCounterattackSkill, num, isLocal);
		}
		if (skillInfo.OverrideType == ESkillOverrideType.覆盖破弱)
		{
			return this.TrySwitchState(ECharacterFightState.OverrideBeBrokeWeaknessSkill, num, isLocal);
		}
		if (skillInfo.OverrideType == ESkillOverrideType.顶级)
		{
			return this.TrySwitchState(ECharacterFightState.SuperSkill, num, isLocal);
		}
		return this.TrySwitchState(ECharacterFightState.NormalSkill, num, isLocal);
	}

	// Token: 0x0601941C RID: 103452 RVA: 0x0073E3F8 File Offset: 0x0073C5F8
	public bool CheckSwitchHitState(EHitAnim hitAnim, bool isLocal = false)
	{
		if (hitAnim == EHitAnim.被破弱)
		{
			return this.CheckSwitchState(ECharacterFightState.BeBrokeWeakness, 0, isLocal);
		}
		if (hitAnim == EHitAnim.被弹反)
		{
			return this.CheckSwitchState(ECharacterFightState.CounterattackBeHit, 0, isLocal);
		}
		if (isLocal && this.UnifiedComp.PositionState == ECharPositionState.Air)
		{
			return this.CheckSwitchState(ECharacterFightState.BeHit, 2, isLocal);
		}
		if (hitAnim - EHitAnim.击飞 <= 1)
		{
			return this.CheckSwitchState(ECharacterFightState.BeHit, 2, isLocal);
		}
		if (hitAnim != EHitAnim.压制)
		{
			return this.CheckSwitchState(ECharacterFightState.BeHit, 0, isLocal);
		}
		return this.CheckSwitchState(ECharacterFightState.BeHit, 1, isLocal);
	}

	// Token: 0x0601941D RID: 103453 RVA: 0x0073E468 File Offset: 0x0073C668
	public int SwitchHitState(EHitAnim hitAnim, bool isLocal = false)
	{
		if (hitAnim == EHitAnim.被破弱)
		{
			return this.SwitchState(ECharacterFightState.BeBrokeWeakness, 0, isLocal);
		}
		if (hitAnim == EHitAnim.被弹反)
		{
			return this.SwitchState(ECharacterFightState.CounterattackBeHit, 0, isLocal);
		}
		if (isLocal && this.UnifiedComp.PositionState == ECharPositionState.Air)
		{
			return this.SwitchState(ECharacterFightState.BeHit, 2, isLocal);
		}
		if (hitAnim - EHitAnim.击飞 <= 1)
		{
			return this.SwitchState(ECharacterFightState.BeHit, 2, isLocal);
		}
		if (hitAnim != EHitAnim.压制)
		{
			return this.SwitchState(ECharacterFightState.BeHit, 0, isLocal);
		}
		return this.SwitchState(ECharacterFightState.BeHit, 1, isLocal);
	}

	// Token: 0x0601941E RID: 103454 RVA: 0x0073E4D6 File Offset: 0x0073C6D6
	public bool CheckSwitchState(ECharacterFightState state, int subStatePriority, bool isLocal = false)
	{
		if (isLocal)
		{
			return this.CheckSwitchStateInternal(this.CurrentState, this.SubStatePriority, state, subStatePriority);
		}
		return !this.WaitConfirm || !this.CheckSwitchStateInternal(state, subStatePriority, this.CurrentState, this.SubStatePriority);
	}

	// Token: 0x0601941F RID: 103455 RVA: 0x0073E511 File Offset: 0x0073C711
	private bool CheckSwitchStateInternal(ECharacterFightState curState, int curSubState, ECharacterFightState newState, int newSubState)
	{
		if (newState == curState)
		{
			return (newSubState == curSubState && (newState - ECharacterFightState.NormalSkill <= 1 || newState == ECharacterFightState.BeBrokeWeakness || newState == ECharacterFightState.SuperSkill)) || newSubState > curSubState;
		}
		return newState > curState;
	}

	// Token: 0x06019420 RID: 103456 RVA: 0x0073E540 File Offset: 0x0073C740
	public int TrySwitchState(ECharacterFightState state, int subStatePriority, bool isLocal = false)
	{
		if (this.CheckSwitchState(state, subStatePriority, isLocal))
		{
			this.SwitchState(state, subStatePriority, isLocal);
			return this.CurrentHandle;
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.FightState;
		Entity entity = base.Entity;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 3);
		defaultInterpolatedStringHandler.AppendLiteral("切换");
		defaultInterpolatedStringHandler.AppendFormatted(isLocal ? "本地" : "远端");
		defaultInterpolatedStringHandler.AppendLiteral("主状态失败，");
		defaultInterpolatedStringHandler.AppendFormatted(this.TargetStateToString((int)state, subStatePriority));
		defaultInterpolatedStringHandler.AppendLiteral("，");
		defaultInterpolatedStringHandler.AppendFormatted(this.CurrentStateToString());
		instance.Info(flag, entity, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		return 0;
	}

	// Token: 0x06019421 RID: 103457 RVA: 0x0073E5EC File Offset: 0x0073C7EC
	private int SwitchState(ECharacterFightState state, int subStatePriority, bool isLocal = false)
	{
		this.CurrentState = state;
		this.SubStatePriority = subStatePriority;
		this.IsLocal = isLocal;
		this.WaitConfirm = isLocal;
		int num = this.IncId + 1;
		this.IncId = num;
		this.CurrentHandle = num;
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.FightState, base.Entity, "切换" + (isLocal ? "本地" : "远端") + "主状态成功，" + this.CurrentStateToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		return this.CurrentHandle;
	}

	// Token: 0x06019422 RID: 103458 RVA: 0x0073E674 File Offset: 0x0073C874
	public void ConfirmState(int handle)
	{
		if (this.CurrentHandle == handle)
		{
			this.WaitConfirm = false;
			return;
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.FightState;
		Entity entity = base.Entity;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
		defaultInterpolatedStringHandler.AppendLiteral("确认状态失败[handle:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(handle);
		defaultInterpolatedStringHandler.AppendLiteral("]，当前[handle:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentHandle);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		instance.Info(flag, entity, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06019423 RID: 103459 RVA: 0x0073E6F8 File Offset: 0x0073C8F8
	public void ResetState()
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.FightState;
		Entity entity = base.Entity;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
		defaultInterpolatedStringHandler.AppendLiteral("重置主状态[handle:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentHandle);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		instance.Info(flag, entity, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		this.CurrentState = ECharacterFightState.Default;
		this.SubStatePriority = 0;
		this.IsLocal = false;
		this.WaitConfirm = false;
		this.CurrentHandle = 0;
	}

	// Token: 0x06019424 RID: 103460 RVA: 0x0073E77C File Offset: 0x0073C97C
	public void ExitState(int handle)
	{
		if (this.CurrentHandle == handle)
		{
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.FightState, base.Entity, "退出主状态，" + this.CurrentStateToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CurrentState = ECharacterFightState.Default;
			this.SubStatePriority = 0;
			this.IsLocal = false;
			this.WaitConfirm = false;
			this.CurrentHandle = 0;
			return;
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.FightState;
		Entity entity = base.Entity;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 2);
		defaultInterpolatedStringHandler.AppendLiteral("退出主状态失败，[handle:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(handle);
		defaultInterpolatedStringHandler.AppendLiteral("]，");
		defaultInterpolatedStringHandler.AppendFormatted(this.CurrentStateToString());
		instance.Info(flag, entity, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06019425 RID: 103461 RVA: 0x0073E83A File Offset: 0x0073CA3A
	public int GetFightState()
	{
		if (this.CurrentHandle == 0)
		{
			return 0;
		}
		return (int)((int)this.CurrentState << 8 | (ECharacterFightState)this.SubStatePriority);
	}

	// Token: 0x06019426 RID: 103462 RVA: 0x0073E858 File Offset: 0x0073CA58
	private string CurrentStateToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
		defaultInterpolatedStringHandler.AppendLiteral("[当前状态(");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentHandle);
		defaultInterpolatedStringHandler.AppendLiteral("):");
		defaultInterpolatedStringHandler.AppendFormatted(this.FightStateToString((int)this.CurrentState, this.SubStatePriority));
		defaultInterpolatedStringHandler.AppendLiteral("]");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06019427 RID: 103463 RVA: 0x0073E8C0 File Offset: 0x0073CAC0
	private string TargetStateToString(int state, int subState)
	{
		return "[目标状态：" + this.FightStateToString(state, subState) + "]";
	}

	// Token: 0x06019428 RID: 103464 RVA: 0x0073E8DC File Offset: 0x0073CADC
	private string FightStateToString(int state, int subState)
	{
		string result = "";
		switch (state)
		{
		case 1:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 2);
			defaultInterpolatedStringHandler.AppendLiteral("普通技能(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 2:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 2);
			defaultInterpolatedStringHandler.AppendLiteral("普通受击(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 3:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
			defaultInterpolatedStringHandler.AppendLiteral("覆盖受击技能(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 4:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
			defaultInterpolatedStringHandler.AppendLiteral("被弹反受击(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 5:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
			defaultInterpolatedStringHandler.AppendLiteral("覆盖被弹反技能(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 6:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
			defaultInterpolatedStringHandler.AppendLiteral("被破弱(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 7:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
			defaultInterpolatedStringHandler.AppendLiteral("覆盖被破弱技能(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 8:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
			defaultInterpolatedStringHandler.AppendLiteral("抓取(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 9:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 2);
			defaultInterpolatedStringHandler.AppendLiteral("特殊技能(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		case 10:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
			defaultInterpolatedStringHandler.AppendLiteral("状态机主状态(");
			defaultInterpolatedStringHandler.AppendFormatted<int>(state);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<int>(subState);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			result = defaultInterpolatedStringHandler.ToStringAndClear();
			break;
		}
		}
		return result;
	}

	// Token: 0x06019429 RID: 103465 RVA: 0x0073EC08 File Offset: 0x0073CE08
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterFightStateComponent characterFightStateComponent = (CharacterFightStateComponent)componentTemplate;
		if (base.CanResetComponentProperty("IncId"))
		{
			this.IncId = characterFightStateComponent.IncId;
		}
		if (base.CanResetComponentProperty("UnifiedComp"))
		{
			if (characterFightStateComponent.UnifiedComp == null)
			{
				this.UnifiedComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedComp), "UnifiedComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CurrentState"))
		{
			this.CurrentState = characterFightStateComponent.CurrentState;
		}
		if (base.CanResetComponentProperty("SubStatePriority"))
		{
			this.SubStatePriority = characterFightStateComponent.SubStatePriority;
		}
		if (base.CanResetComponentProperty("IsLocal"))
		{
			this.IsLocal = characterFightStateComponent.IsLocal;
		}
		if (base.CanResetComponentProperty("WaitConfirm"))
		{
			this.WaitConfirm = characterFightStateComponent.WaitConfirm;
		}
		if (base.CanResetComponentProperty("CurrentHandle"))
		{
			this.CurrentHandle = characterFightStateComponent.CurrentHandle;
		}
		return true;
	}

	// Token: 0x0400C6C9 RID: 50889
	private int IncId;

	// Token: 0x0400C6CA RID: 50890
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedComp;

	// Token: 0x0400C6CB RID: 50891
	public ECharacterFightState CurrentState;

	// Token: 0x0400C6CC RID: 50892
	public int SubStatePriority;

	// Token: 0x0400C6CD RID: 50893
	public bool IsLocal;

	// Token: 0x0400C6CE RID: 50894
	public bool WaitConfirm;

	// Token: 0x0400C6CF RID: 50895
	public int CurrentHandle;
}
