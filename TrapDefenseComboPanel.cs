using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D9B RID: 7579
public class TrapDefenseComboPanel : BattleChildViewPanel
{
	// Token: 0x0600DF6C RID: 57196 RVA: 0x003C1E3C File Offset: 0x003C003C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600DF6D RID: 57197 RVA: 0x003C1E98 File Offset: 0x003C0098
	protected override void OnStart()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
		this.ComboNumSequence = new UiSequencePlayer(base.GetItem(2));
		this.DurationTime = (float)ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseComboDuration();
		this.AdvancedPerformanceThreshold = (float)ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseComboAdvancedPerformanceThreshold();
	}

	// Token: 0x0600DF6E RID: 57198 RVA: 0x003C1EEA File Offset: 0x003C00EA
	protected override void OnBeforeShow()
	{
		this.Sequence.PlaySequencePurely("Start", false, false);
	}

	// Token: 0x0600DF6F RID: 57199 RVA: 0x003C1F00 File Offset: 0x003C0100
	protected override UniTask OnBeforeHideAsync()
	{
		TrapDefenseComboPanel.<OnBeforeHideAsync>d__9 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<TrapDefenseComboPanel.<OnBeforeHideAsync>d__9>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DF70 RID: 57200 RVA: 0x003C1F43 File Offset: 0x003C0143
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
		this.ComboNumSequence.Clear();
	}

	// Token: 0x0600DF71 RID: 57201 RVA: 0x003C1F5B File Offset: 0x003C015B
	protected override bool OnCheckBattleChildViewPanelShowCondition()
	{
		return this.RemainTime > 0f;
	}

	// Token: 0x0600DF72 RID: 57202 RVA: 0x003C1F6A File Offset: 0x003C016A
	public override void OnTickBattleChildViewPanel(float delta)
	{
		if (this.RemainTime <= 0f)
		{
			return;
		}
		this.RemainTime -= delta;
		if (this.RemainTime <= 0f)
		{
			base.HideBattleChildViewPanel();
		}
	}

	// Token: 0x0600DF73 RID: 57203 RVA: 0x003C1F9C File Offset: 0x003C019C
	public void RefreshComboNum(int comboNum)
	{
		base.GetArtText(0).SetText(comboNum.ToString());
		this.ComboNumSequence.PlaySequencePurely("Up", false, false);
		base.GetItem(1).SetUIActive((float)comboNum >= this.AdvancedPerformanceThreshold);
		this.RemainTime = this.DurationTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		base.ShowBattleChildViewPanel();
	}

	// Token: 0x0600DF74 RID: 57204 RVA: 0x003C2005 File Offset: 0x003C0205
	public void HideComboPanel()
	{
		if (this.RemainTime > 0f)
		{
			this.RemainTime = 0f;
			base.HideBattleChildViewPanel();
		}
	}

	// Token: 0x04006B68 RID: 27496
	protected float DurationTime;

	// Token: 0x04006B69 RID: 27497
	protected float RemainTime;

	// Token: 0x04006B6A RID: 27498
	protected float AdvancedPerformanceThreshold;

	// Token: 0x04006B6B RID: 27499
	[Nullable(1)]
	protected UiSequencePlayer Sequence;

	// Token: 0x04006B6C RID: 27500
	[Nullable(1)]
	protected UiSequencePlayer ComboNumSequence;

	// Token: 0x02008134 RID: 33076
	private static class EComponentDefine
	{
		// Token: 0x0402BEAB RID: 179883
		public const int ComboNum = 0;

		// Token: 0x0402BEAC RID: 179884
		public const int AdvancedPerformance = 1;

		// Token: 0x0402BEAD RID: 179885
		public const int ComboItem = 2;
	}
}
