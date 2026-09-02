using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;

// Token: 0x02001F9E RID: 8094
public class SlowTimeHandle : HudUnitHandleBase
{
	// Token: 0x0600F331 RID: 62257 RVA: 0x00427BFF File Offset: 0x00425DFF
	protected override void OnInitialize()
	{
		base.OnInitialize();
		this.IsSlowTimeState = ModelBase<BattleUiModel>.Instance.GetRoleSpecialState(ERoleSpecialState.SlowTimeWorld);
	}

	// Token: 0x0600F332 RID: 62258 RVA: 0x00427C18 File Offset: 0x00425E18
	protected override void OnDestroyed()
	{
		this.DestroyUnit();
	}

	// Token: 0x0600F333 RID: 62259 RVA: 0x00427C20 File Offset: 0x00425E20
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<ESelfCenteredMode, float>(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.OnSwitchSelfCenteredMode));
		Singleton<EventSystem>.Instance.Add<ERoleSpecialState, bool>(EEventName.BattleUiRoleSpecialStateChanged, new Action<ERoleSpecialState, bool>(this.OnRoleSpecialStateChanged));
		ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.TimeScaleStrength, new TValueListener(this.OnStrengthChanged), null);
		ControllerBase<FormationAttributeController>.Instance.AddMaxListener(EFormationAttributeId.TimeScaleStrength, new TValueListener(this.OnStrengthChanged), null);
	}

	// Token: 0x0600F334 RID: 62260 RVA: 0x00427C98 File Offset: 0x00425E98
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<ESelfCenteredMode, float>(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.OnSwitchSelfCenteredMode));
		Singleton<EventSystem>.Instance.Remove<ERoleSpecialState, bool>(EEventName.BattleUiRoleSpecialStateChanged, new Action<ERoleSpecialState, bool>(this.OnRoleSpecialStateChanged));
		ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.TimeScaleStrength, new TValueListener(this.OnStrengthChanged));
		ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(EFormationAttributeId.TimeScaleStrength, new TValueListener(this.OnStrengthChanged));
	}

	// Token: 0x0600F335 RID: 62261 RVA: 0x00427D0D File Offset: 0x00425F0D
	private void OnSwitchSelfCenteredMode(ESelfCenteredMode selfCenteredMode, float globalTimeDilation)
	{
		this.IsInSelfCenteredMode = (selfCenteredMode == ESelfCenteredMode.Skill);
		this.RefreshUnitVisible();
	}

	// Token: 0x0600F336 RID: 62262 RVA: 0x00427D1F File Offset: 0x00425F1F
	private void OnRoleSpecialStateChanged(ERoleSpecialState state, bool enable)
	{
		if (state != ERoleSpecialState.SlowTimeWorld)
		{
			return;
		}
		this.IsSlowTimeState = enable;
		this.RefreshUnitVisible();
	}

	// Token: 0x0600F337 RID: 62263 RVA: 0x00427D34 File Offset: 0x00425F34
	private void RefreshUnitVisible()
	{
		this.NeedShow = (this.IsInSelfCenteredMode || this.IsSlowTimeState);
		if (this.NeedShow)
		{
			this.NewUnit();
			SlowTimeUnit unit = this.Unit;
			if (unit == null)
			{
				return;
			}
			unit.SetTranslucence(false);
			return;
		}
		else
		{
			this.CheckDestroyUnit();
			SlowTimeUnit unit2 = this.Unit;
			if (unit2 == null)
			{
				return;
			}
			unit2.SetTranslucence(true);
			return;
		}
	}

	// Token: 0x0600F338 RID: 62264 RVA: 0x00427D8F File Offset: 0x00425F8F
	private void OnStrengthChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
	{
		this.UpdateStrength();
	}

	// Token: 0x0600F339 RID: 62265 RVA: 0x00427D98 File Offset: 0x00425F98
	private void UpdateStrength()
	{
		float max = ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.TimeScaleStrength);
		float value = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.TimeScaleStrength);
		this.IsFull = (value >= max);
		SlowTimeUnit unit = this.Unit;
		if (unit != null)
		{
			unit.UpdateProgress(value, max);
		}
		this.CheckDestroyUnit();
	}

	// Token: 0x0600F33A RID: 62266 RVA: 0x00427DE8 File Offset: 0x00425FE8
	private void NewUnit()
	{
		if (this.Unit != null)
		{
			return;
		}
		base.NewHudUnitWithReturn<SlowTimeUnit>(typeof(SlowTimeUnit), "UiView_SlowMotionProgress", out this.Unit, true, delegate(SlowTimeUnit _)
		{
			this.UpdateStrength();
			if (!this.NeedShow)
			{
				SlowTimeUnit unit = this.Unit;
				if (unit == null)
				{
					return;
				}
				unit.SetTranslucence(true);
			}
		}, false);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiSlowTimeVisibleChanged, true);
	}

	// Token: 0x0600F33B RID: 62267 RVA: 0x00427E38 File Offset: 0x00426038
	private void CheckDestroyUnit()
	{
		if (!this.NeedShow && this.IsFull)
		{
			this.DestroyUnit();
		}
	}

	// Token: 0x0600F33C RID: 62268 RVA: 0x00427E50 File Offset: 0x00426050
	private void DestroyUnit()
	{
		if (this.Unit == null)
		{
			return;
		}
		base.DestroyHudUnit(this.Unit);
		this.Unit = null;
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiSlowTimeVisibleChanged, false);
	}

	// Token: 0x040074D4 RID: 29908
	[Nullable(2)]
	private SlowTimeUnit Unit;

	// Token: 0x040074D5 RID: 29909
	private bool IsInSelfCenteredMode;

	// Token: 0x040074D6 RID: 29910
	private bool IsSlowTimeState;

	// Token: 0x040074D7 RID: 29911
	private bool NeedShow;

	// Token: 0x040074D8 RID: 29912
	private bool IsFull;
}
