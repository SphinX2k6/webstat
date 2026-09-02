using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D9E RID: 7582
public class TrapDefenseMachineTipsPanel : BattleChildViewPanel
{
	// Token: 0x0600DF8A RID: 57226 RVA: 0x003C2417 File Offset: 0x003C0617
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600DF8B RID: 57227 RVA: 0x003C2450 File Offset: 0x003C0650
	public override void InitializeTemp()
	{
		this.Sequence = new UiSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DF8C RID: 57228 RVA: 0x003C2463 File Offset: 0x003C0663
	protected override void OnBeforeDestroy()
	{
		this.Sequence.Clear();
	}

	// Token: 0x0600DF8D RID: 57229 RVA: 0x003C2470 File Offset: 0x003C0670
	protected override void OnBeforeShow()
	{
		this.Sequence.PlaySequencePurely("Start", false, false);
	}

	// Token: 0x0600DF8E RID: 57230 RVA: 0x003C2484 File Offset: 0x003C0684
	protected override UniTask OnBeforeHideAsync()
	{
		TrapDefenseMachineTipsPanel.<OnBeforeHideAsync>d__8 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<TrapDefenseMachineTipsPanel.<OnBeforeHideAsync>d__8>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DF8F RID: 57231 RVA: 0x003C24C7 File Offset: 0x003C06C7
	protected override bool OnCheckBattleChildViewPanelShowCondition()
	{
		return this.IsCanShow;
	}

	// Token: 0x0600DF90 RID: 57232 RVA: 0x003C24CF File Offset: 0x003C06CF
	private void RefreshMachineTips()
	{
		if (this.IsCanShow)
		{
			base.ShowBattleChildViewPanel();
			return;
		}
		base.HideBattleChildViewPanel();
	}

	// Token: 0x0600DF91 RID: 57233 RVA: 0x003C24E8 File Offset: 0x003C06E8
	[NullableContext(2)]
	public void SetMachineItem(TrapDefenseBuildingDevelopItemData data)
	{
		if (data == this.Data)
		{
			return;
		}
		if (data != null && data.IsBuilding)
		{
			ValueTuple<string, string[]> desc = data.GetDesc();
			string item = desc.Item1;
			string[] item2 = desc.Item2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetName(), Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), item, item2);
			TrapDefenseBuildingDevelopItemData data2 = this.Data;
			if (data2 != null && data2.IsBuilding)
			{
				this.Sequence.PlaySequencePurely("Switch", false, false);
			}
		}
		this.Data = data;
		this.RefreshMachineTips();
	}

	// Token: 0x0600DF92 RID: 57234 RVA: 0x003C257F File Offset: 0x003C077F
	public void RefreshMachineStateByRoulette(bool isVisible)
	{
		this.IsMobileRouletteVisible = isVisible;
		this.RefreshMachineTips();
	}

	// Token: 0x17001183 RID: 4483
	// (get) Token: 0x0600DF93 RID: 57235 RVA: 0x003C258E File Offset: 0x003C078E
	private bool IsCanShow
	{
		get
		{
			if (!this.IsMobileRouletteVisible)
			{
				TrapDefenseBuildingDevelopItemData data = this.Data;
				return data != null && data.IsBuilding;
			}
			return false;
		}
	}

	// Token: 0x04006B70 RID: 27504
	[Nullable(1)]
	protected UiSequencePlayer Sequence;

	// Token: 0x04006B71 RID: 27505
	[Nullable(2)]
	protected TrapDefenseBuildingDevelopItemData Data;

	// Token: 0x04006B72 RID: 27506
	protected bool IsMobileRouletteVisible;

	// Token: 0x0200813A RID: 33082
	private static class EComponentDefine
	{
		// Token: 0x0402BEC1 RID: 179905
		public const int Name = 0;

		// Token: 0x0402BEC2 RID: 179906
		public const int Desc = 1;
	}
}
