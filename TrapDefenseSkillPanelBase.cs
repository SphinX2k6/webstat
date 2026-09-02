using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Module.TrapDefense;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001DA3 RID: 7587
[NullableContext(1)]
[Nullable(0)]
public abstract class TrapDefenseSkillPanelBase : BattleChildViewPanel
{
	// Token: 0x0600DFDB RID: 57307 RVA: 0x003C3B61 File Offset: 0x003C1D61
	protected override void OnStart()
	{
		this.RefreshAllBattleSkillItems();
		this.OnChildStart();
	}

	// Token: 0x0600DFDC RID: 57308 RVA: 0x003C3B70 File Offset: 0x003C1D70
	protected override void OnAfterShow()
	{
		foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
		{
			battleSkillItem.RefreshEnable(true);
		}
	}

	// Token: 0x0600DFDD RID: 57309 RVA: 0x003C3BC4 File Offset: 0x003C1DC4
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
		{
			battleSkillItem.RefreshSkillCoolDownOnShow();
		}
	}

	// Token: 0x0600DFDE RID: 57310 RVA: 0x003C3C14 File Offset: 0x003C1E14
	protected override void OnHideBattleChildViewPanel()
	{
		foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
		{
			if (battleSkillItem.IsShowOrShowing)
			{
				battleSkillItem.TryReleaseButton();
			}
		}
	}

	// Token: 0x0600DFDF RID: 57311 RVA: 0x003C3C70 File Offset: 0x003C1E70
	public override void OnTickBattleChildViewPanel(float delta)
	{
		if (!this.Visible)
		{
			return;
		}
		foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
		{
			battleSkillItem.Tick(delta);
		}
	}

	// Token: 0x0600DFE0 RID: 57312 RVA: 0x003C3CCC File Offset: 0x003C1ECC
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Add(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
		Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
	}

	// Token: 0x0600DFE1 RID: 57313 RVA: 0x003C3D48 File Offset: 0x003C1F48
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonSkillIdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonSkillIdRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonCdRefresh, new Action<ESkillButtonType>(this.OnSkillButtonCdRefresh));
	}

	// Token: 0x0600DFE2 RID: 57314 RVA: 0x003C3DC4 File Offset: 0x003C1FC4
	private void OnChangedTimeScale()
	{
		foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
		{
			battleSkillItem.RefreshTimeDilation();
		}
	}

	// Token: 0x0600DFE3 RID: 57315 RVA: 0x003C3E14 File Offset: 0x003C2014
	private void OnPauseGame(int flag)
	{
		foreach (BattleSkillItem battleSkillItem in this.BattleSkillItemList)
		{
			battleSkillItem.PauseGame(flag);
		}
	}

	// Token: 0x0600DFE4 RID: 57316 RVA: 0x003C3E68 File Offset: 0x003C2068
	private void OnSkillButtonSkillIdRefresh(ESkillButtonType buttonType)
	{
		this.RefreshSkillItemByButtonType(buttonType);
	}

	// Token: 0x0600DFE5 RID: 57317 RVA: 0x003C3E71 File Offset: 0x003C2071
	private void OnSkillButtonCdRefresh(ESkillButtonType buttonType)
	{
		this.RefreshSkillItemByButtonType(buttonType);
	}

	// Token: 0x0600DFE6 RID: 57318 RVA: 0x003C3E7C File Offset: 0x003C207C
	private void RefreshAllBattleSkillItems()
	{
		string[] actionNameList = this.GetActionNameList();
		for (int i = 0; i < actionNameList.Length; i++)
		{
			string actionName = actionNameList[i];
			BattleSkillItem battleSkillItem = this.BattleSkillItemList[i];
			TrapDefenseBattleSkillData skillData = ModelBase<TrapDefenseModel>.Instance.BattleData.GetSkillData(actionName);
			battleSkillItem.Refresh(skillData);
			this.DataMap[i] = skillData;
		}
	}

	// Token: 0x0600DFE7 RID: 57319 RVA: 0x003C3ED4 File Offset: 0x003C20D4
	private void RefreshSkillItemByButtonType(ESkillButtonType buttonType)
	{
		string[] actionNameList = this.GetActionNameList();
		foreach (TrapDefenseBattleSkillData trapDefenseBattleSkillData in this.DataMap.Values)
		{
			if (trapDefenseBattleSkillData.GetButtonType() == buttonType)
			{
				int num = Array.IndexOf<string>(actionNameList, trapDefenseBattleSkillData.GetActionName());
				if (num >= 0)
				{
					this.BattleSkillItemList[num].Refresh(trapDefenseBattleSkillData);
				}
			}
		}
	}

	// Token: 0x0600DFE8 RID: 57320 RVA: 0x003C3F58 File Offset: 0x003C2158
	[return: Dynamic(new bool[]
	{
		false,
		true
	})]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	protected UniTask<dynamic> NewBattleSkillItem(AActor rootActor, int inputIndex, bool useExplore)
	{
		TrapDefenseSkillPanelBase.<NewBattleSkillItem>d__15 <NewBattleSkillItem>d__;
		<NewBattleSkillItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<object>.Create();
		<NewBattleSkillItem>d__.<>4__this = this;
		<NewBattleSkillItem>d__.rootActor = rootActor;
		<NewBattleSkillItem>d__.inputIndex = inputIndex;
		<NewBattleSkillItem>d__.useExplore = useExplore;
		<NewBattleSkillItem>d__.<>1__state = -1;
		<NewBattleSkillItem>d__.<>t__builder.Start<TrapDefenseSkillPanelBase.<NewBattleSkillItem>d__15>(ref <NewBattleSkillItem>d__);
		return <NewBattleSkillItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600DFE9 RID: 57321
	protected abstract string[] GetActionNameList();

	// Token: 0x0600DFEA RID: 57322 RVA: 0x003C3FB3 File Offset: 0x003C21B3
	protected virtual void OnChildStart()
	{
	}

	// Token: 0x04006B83 RID: 27523
	protected readonly List<BattleSkillItem> BattleSkillItemList = new List<BattleSkillItem>();

	// Token: 0x04006B84 RID: 27524
	protected Dictionary<int, TrapDefenseBattleSkillData> DataMap = new Dictionary<int, TrapDefenseBattleSkillData>();
}
