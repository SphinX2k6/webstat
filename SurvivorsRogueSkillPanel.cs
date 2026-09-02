using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.SkillButtonUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D88 RID: 7560
public class SurvivorsRogueSkillPanel : BattleChildViewPanel
{
	// Token: 0x0600DEB1 RID: 57009 RVA: 0x003BECA8 File Offset: 0x003BCEA8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600DEB2 RID: 57010 RVA: 0x003BECE4 File Offset: 0x003BCEE4
	public override UniTask InitializeAsync()
	{
		SurvivorsRogueSkillPanel.<InitializeAsync>d__4 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<SurvivorsRogueSkillPanel.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DEB3 RID: 57011 RVA: 0x003BED27 File Offset: 0x003BCF27
	protected override void OnStart()
	{
		ModelBase<SurvivorsRogueModel>.Instance.BattleData.InitBattleSkillData();
		this.RefreshAllBattleSkillItems();
	}

	// Token: 0x0600DEB4 RID: 57012 RVA: 0x003BED3E File Offset: 0x003BCF3E
	private void RefreshAllBattleSkillItems()
	{
		this.RefreshActiveSkillItem();
		this.RefreshDodgeSkillItem();
	}

	// Token: 0x0600DEB5 RID: 57013 RVA: 0x003BED4C File Offset: 0x003BCF4C
	private void RefreshActiveSkillItem()
	{
		this.ActiveSkillItem.Refresh(ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetBattleSkillData("技能1"));
	}

	// Token: 0x0600DEB6 RID: 57014 RVA: 0x003BED6D File Offset: 0x003BCF6D
	private void RefreshDodgeSkillItem()
	{
		this.DodgeSkillItem.Refresh(ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetBattleSkillData("闪避"));
	}

	// Token: 0x0600DEB7 RID: 57015 RVA: 0x003BED8E File Offset: 0x003BCF8E
	protected override void OnShowBattleChildViewPanel(bool first)
	{
		this.ActiveSkillItem.RefreshSkillCoolDownOnShow();
	}

	// Token: 0x0600DEB8 RID: 57016 RVA: 0x003BED9B File Offset: 0x003BCF9B
	protected override void OnHideBattleChildViewPanel()
	{
		this.ActiveSkillItem.TryReleaseButton();
		this.DodgeSkillItem.TryReleaseButton();
	}

	// Token: 0x0600DEB9 RID: 57017 RVA: 0x003BEDB3 File Offset: 0x003BCFB3
	public override void OnTickBattleChildViewPanel(float delta)
	{
		if (!this.Visible)
		{
			return;
		}
		this.ActiveSkillItem.Tick(delta);
		this.DodgeSkillItem.Tick(delta);
	}

	// Token: 0x0600DEBA RID: 57018 RVA: 0x003BEDD8 File Offset: 0x003BCFD8
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Add(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
	}

	// Token: 0x0600DEBB RID: 57019 RVA: 0x003BEE38 File Offset: 0x003BD038
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
	}

	// Token: 0x0600DEBC RID: 57020 RVA: 0x003BEE96 File Offset: 0x003BD096
	private void OnChangedTimeScale()
	{
		this.ActiveSkillItem.RefreshTimeDilation();
		this.DodgeSkillItem.RefreshTimeDilation();
	}

	// Token: 0x0600DEBD RID: 57021 RVA: 0x003BEEAE File Offset: 0x003BD0AE
	private void OnPauseGame(int flag)
	{
		this.ActiveSkillItem.PauseGame(flag);
		this.DodgeSkillItem.PauseGame(flag);
	}

	// Token: 0x0600DEBE RID: 57022 RVA: 0x003BEEC8 File Offset: 0x003BD0C8
	private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
	{
		if (buttonType == ESkillButtonType.技能1)
		{
			this.ActiveSkillItem.RefreshSkillCoolDown();
			return;
		}
		if (buttonType == ESkillButtonType.闪避)
		{
			this.DodgeSkillItem.RefreshSkillCoolDown();
		}
	}

	// Token: 0x04006B1C RID: 27420
	[Nullable(2)]
	protected BattleSkillItem ActiveSkillItem;

	// Token: 0x04006B1D RID: 27421
	[Nullable(2)]
	protected BattleSkillItem DodgeSkillItem;

	// Token: 0x02008112 RID: 33042
	private static class EComponentDefine
	{
		// Token: 0x0402BE1E RID: 179742
		public const int Skill = 0;

		// Token: 0x0402BE1F RID: 179743
		public const int Dodge = 1;
	}
}
