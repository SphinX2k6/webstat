using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.SkillButtonUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D38 RID: 7480
public class MotorcycleArrowSkillPanel : BattleChildViewPanel
{
	// Token: 0x0600DC50 RID: 56400 RVA: 0x003B3951 File Offset: 0x003B1B51
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600DC51 RID: 56401 RVA: 0x003B3974 File Offset: 0x003B1B74
	public override UniTask InitializeAsync()
	{
		MotorcycleArrowSkillPanel.<InitializeAsync>d__4 <InitializeAsync>d__;
		<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeAsync>d__.<>4__this = this;
		<InitializeAsync>d__.<>1__state = -1;
		<InitializeAsync>d__.<>t__builder.Start<MotorcycleArrowSkillPanel.<InitializeAsync>d__4>(ref <InitializeAsync>d__);
		return <InitializeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC52 RID: 56402 RVA: 0x003B39B7 File Offset: 0x003B1BB7
	protected override void OnShowBattleChildViewPanel(bool isFirst)
	{
		this.ActiveSkillItem.RefreshSkillCoolDownOnShow();
	}

	// Token: 0x0600DC53 RID: 56403 RVA: 0x003B39C4 File Offset: 0x003B1BC4
	protected override void OnHideBattleChildViewPanel()
	{
		this.ActiveSkillItem.TryReleaseButton();
	}

	// Token: 0x0600DC54 RID: 56404 RVA: 0x003B39D1 File Offset: 0x003B1BD1
	public override void OnTickBattleChildViewPanel(float delta)
	{
		if (!this.Visible)
		{
			return;
		}
		this.ActiveSkillItem.Tick(delta);
	}

	// Token: 0x0600DC55 RID: 56405 RVA: 0x003B39E8 File Offset: 0x003B1BE8
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Add(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Add(EEventName.OnKscPlayerCreate, new Action(this.OnKscPlayerCreate));
		Singleton<EventSystem>.Instance.Add<ESkillButtonType>(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.LevelGamePlayPrepareCountDownEnd, new Action(this.OnCountDownEnd));
	}

	// Token: 0x0600DC56 RID: 56406 RVA: 0x003B3A80 File Offset: 0x003B1C80
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnChangedTimeScale));
		Singleton<EventSystem>.Instance.Remove(EEventName.PauseGame, new Action<int>(this.OnPauseGame));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnKscPlayerCreate, new Action(this.OnKscPlayerCreate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonAttributeRefresh, new Action<ESkillButtonType>(this.OnSkillButtonAttributeRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.LevelGamePlayPrepareCountDownEnd, new Action(this.OnCountDownEnd));
	}

	// Token: 0x0600DC57 RID: 56407 RVA: 0x003B3B18 File Offset: 0x003B1D18
	private void OnCountDownEnd()
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		MotorcycleArrowBattleSkillData skillData = this.SkillData;
		MotorcycleArrowSubModel motorcycleArrowSubModel2 = motorcycleArrowSubModel;
		skillData.SetVisible(motorcycleArrowSubModel2.LevelConfig != null && motorcycleArrowSubModel2.LevelConfig.GetValueOrDefault().SkillEnable == 1);
		this.ActiveSkillItem.RefreshVisible();
	}

	// Token: 0x0600DC58 RID: 56408 RVA: 0x003B3B70 File Offset: 0x003B1D70
	private void OnSkillButtonAttributeRefresh(ESkillButtonType buttonType)
	{
		MotorcycleArrowBattleSkillData skillData = this.SkillData;
		ESkillButtonType? eskillButtonType = (skillData != null) ? new ESkillButtonType?(skillData.GetButtonType()) : null;
		if (!(buttonType == eskillButtonType.GetValueOrDefault() & eskillButtonType != null))
		{
			return;
		}
		BattleSkillItem activeSkillItem = this.ActiveSkillItem;
		bool flag = activeSkillItem != null && activeSkillItem.GetSkillButtonInteractive();
		BattleSkillItem activeSkillItem2 = this.ActiveSkillItem;
		if (activeSkillItem2 != null)
		{
			activeSkillItem2.RefreshAttribute(true);
		}
		BattleSkillItem activeSkillItem3 = this.ActiveSkillItem;
		bool flag2 = activeSkillItem3 != null && activeSkillItem3.GetSkillButtonInteractive();
		if (flag != flag2 && flag2)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "OnMotorFightChargeFull");
		}
	}

	// Token: 0x0600DC59 RID: 56409 RVA: 0x003B3C08 File Offset: 0x003B1E08
	private void OnKscPlayerCreate()
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		AKSC_Entity kscPlayerEntity = motorcycleArrowSubModel.KscPlayerEntity;
		this.SkillData = motorcycleArrowSubModel.GetMotorcycleArrowBattleSkillData();
		this.SkillData.InitAttrData(kscPlayerEntity);
		this.RefreshActiveSkillItem();
	}

	// Token: 0x0600DC5A RID: 56410 RVA: 0x003B3C4C File Offset: 0x003B1E4C
	private void RefreshActiveSkillItem()
	{
		MotorcycleArrowSubModel motorcycleArrowSubModel = (MotorcycleArrowSubModel)ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
		this.ActiveSkillItem.Refresh(motorcycleArrowSubModel.GetMotorcycleArrowBattleSkillData());
	}

	// Token: 0x0600DC5B RID: 56411 RVA: 0x003B3C7A File Offset: 0x003B1E7A
	private void OnChangedTimeScale()
	{
		this.ActiveSkillItem.RefreshTimeDilation();
	}

	// Token: 0x0600DC5C RID: 56412 RVA: 0x003B3C87 File Offset: 0x003B1E87
	private void OnPauseGame(int flag)
	{
		this.ActiveSkillItem.PauseGame(flag);
	}

	// Token: 0x0600DC5D RID: 56413 RVA: 0x003B3C95 File Offset: 0x003B1E95
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public UUIItem[] GetSkillGuideItem()
	{
		BattleSkillItem activeSkillItem = this.ActiveSkillItem;
		if (activeSkillItem == null)
		{
			return null;
		}
		return activeSkillItem.GetGuideItem();
	}

	// Token: 0x0400696E RID: 26990
	[Nullable(2)]
	protected BattleSkillItem ActiveSkillItem;

	// Token: 0x0400696F RID: 26991
	[Nullable(2)]
	protected MotorcycleArrowBattleSkillData SkillData;

	// Token: 0x020080CB RID: 32971
	private static class EComponentDefine
	{
		// Token: 0x0402BCEA RID: 179434
		public const int Skill = 0;
	}
}
