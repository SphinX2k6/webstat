using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D37 RID: 7479
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleArrowBattleMain : BattleChildViewPanel
{
	// Token: 0x0600DC41 RID: 56385 RVA: 0x003B3420 File Offset: 0x003B1620
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnButtonStopClicked))
		};
	}

	// Token: 0x0600DC42 RID: 56386 RVA: 0x003B3538 File Offset: 0x003B1738
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleArrowBattleMain.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleArrowBattleMain.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC43 RID: 56387 RVA: 0x003B357C File Offset: 0x003B177C
	protected override void OnBeforeDestroy()
	{
		this.OnRemoveEventListener();
		UUIItem saveItem = this.SaveItem;
		if (saveItem != null)
		{
			saveItem.SetUIActive(false);
		}
		if (this.HideSaveTimer != null && TimerSystem.GameplayTimeInstance.Has(this.HideSaveTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.HideSaveTimer);
		}
	}

	// Token: 0x0600DC44 RID: 56388 RVA: 0x003B35CC File Offset: 0x003B17CC
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorArrowBossHpChange, new Action<FKSC_HeadHpContext>(this.OnMotorArrowBossHpChange));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorArrowBossCreate, new Action<string>(this.OnMotorArrowBossCreate));
		Singleton<EventSystem>.Instance.Add(EEventName.LevelGamePlayPrepareCountDownEnd, new Action(this.OnCountDownEnd));
		Singleton<EventSystem>.Instance.Add(EEventName.MotorArrowSave, new Action(this.OnSave));
	}

	// Token: 0x0600DC45 RID: 56389 RVA: 0x003B364C File Offset: 0x003B184C
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorArrowBossHpChange, new Action<FKSC_HeadHpContext>(this.OnMotorArrowBossHpChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorArrowBossCreate, new Action<string>(this.OnMotorArrowBossCreate));
		Singleton<EventSystem>.Instance.Remove(EEventName.LevelGamePlayPrepareCountDownEnd, new Action(this.OnCountDownEnd));
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorArrowSave, new Action(this.OnSave));
	}

	// Token: 0x0600DC46 RID: 56390 RVA: 0x003B36CC File Offset: 0x003B18CC
	private void OnCountDownEnd()
	{
		this.ButtonStop.RootUIComp.Get().SetUIActive(true);
		this.ScoreItem.ShowAsync().Forget<bool>();
		this.BattleProgressItem.ShowAsync().Forget<bool>();
		this.HpPlayerItem.ShowAsync().Forget<bool>();
		MotorcycleControlPanelBase motorcycleControlPanel = this.MotorcycleControlPanel;
		if (motorcycleControlPanel == null)
		{
			return;
		}
		motorcycleControlPanel.ShowBattleVisibleChildView(false);
	}

	// Token: 0x0600DC47 RID: 56391 RVA: 0x003B3734 File Offset: 0x003B1934
	[NullableContext(1)]
	private void OnMotorArrowBossHpChange(FKSC_HeadHpContext headInfo)
	{
		if (headInfo.ActionType == EKSC_HeadHpContextType.Remove)
		{
			MotorcycleArrowBossHpItem bossHpItem = this.BossHpItem;
			if (bossHpItem != null)
			{
				bossHpItem.SetActive(false);
			}
			SimpleBossStateItem bossHpItem2 = this.BossHpItem2;
			if (bossHpItem2 == null)
			{
				return;
			}
			bossHpItem2.SetActive(false);
			return;
		}
		else
		{
			MotorcycleArrowBossHpItem bossHpItem3 = this.BossHpItem;
			if (bossHpItem3 == null || !bossHpItem3.GetActive())
			{
				MotorcycleArrowBossHpItem bossHpItem4 = this.BossHpItem;
				if (bossHpItem4 != null)
				{
					bossHpItem4.SetActive(true);
				}
				SimpleBossStateItem bossHpItem5 = this.BossHpItem2;
				if (bossHpItem5 != null)
				{
					bossHpItem5.SetActive(true);
				}
				MotorcycleArrowBossHpItem bossHpItem6 = this.BossHpItem;
				if (bossHpItem6 != null)
				{
					bossHpItem6.UpdateHeadStateInfo(headInfo, false);
				}
				SimpleBossStateItem bossHpItem7 = this.BossHpItem2;
				if (bossHpItem7 != null)
				{
					bossHpItem7.RefreshBossInfo(headInfo);
				}
			}
			MotorcycleArrowBossHpItem bossHpItem8 = this.BossHpItem;
			if (bossHpItem8 != null)
			{
				bossHpItem8.UpdateHeadStateInfo(headInfo, true);
			}
			SimpleBossStateItem bossHpItem9 = this.BossHpItem2;
			if (bossHpItem9 == null)
			{
				return;
			}
			bossHpItem9.UpdateHeadStateInfo(headInfo);
			return;
		}
	}

	// Token: 0x0600DC48 RID: 56392 RVA: 0x003B37F2 File Offset: 0x003B19F2
	[NullableContext(1)]
	private void OnMotorArrowBossCreate(string bossName)
	{
		SimpleBossStateItem bossHpItem = this.BossHpItem2;
		if (bossHpItem == null)
		{
			return;
		}
		bossHpItem.SetBossName(bossName);
	}

	// Token: 0x0600DC49 RID: 56393 RVA: 0x003B3808 File Offset: 0x003B1A08
	public override void OnTickBattleChildViewPanel(float delta)
	{
		MotorcycleArrowBattleProgressItem battleProgressItem = this.BattleProgressItem;
		if (battleProgressItem != null)
		{
			battleProgressItem.OnTick(delta);
		}
		MotorcycleArrowScore scoreItem = this.ScoreItem;
		if (scoreItem != null)
		{
			scoreItem.OnTick(delta);
		}
		MotorcycleArrowHpPlayerItem hpPlayerItem = this.HpPlayerItem;
		if (hpPlayerItem != null)
		{
			hpPlayerItem.OnTick(delta);
		}
		MotorcycleControlPanelBase motorcycleControlPanel = this.MotorcycleControlPanel;
		if (motorcycleControlPanel != null)
		{
			motorcycleControlPanel.Tick(delta);
		}
		MotorcycleArrowBossHpItem bossHpItem = this.BossHpItem;
		if (bossHpItem != null && bossHpItem.GetActive())
		{
			MotorcycleArrowBossHpItem bossHpItem2 = this.BossHpItem;
			if (bossHpItem2 != null)
			{
				bossHpItem2.OnTick(delta);
			}
			SimpleBossStateItem bossHpItem3 = this.BossHpItem2;
			if (bossHpItem3 == null)
			{
				return;
			}
			bossHpItem3.OnTick(delta);
		}
	}

	// Token: 0x0600DC4A RID: 56394 RVA: 0x003B3894 File Offset: 0x003B1A94
	protected override void OnStart()
	{
	}

	// Token: 0x0600DC4B RID: 56395 RVA: 0x003B3896 File Offset: 0x003B1A96
	private void OnButtonStopClicked()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightPauseView, null, null);
	}

	// Token: 0x0600DC4C RID: 56396 RVA: 0x003B38AC File Offset: 0x003B1AAC
	private void OnSave()
	{
		if (this.HideSaveTimer != null && TimerSystem.GameplayTimeInstance.Has(this.HideSaveTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.HideSaveTimer);
		}
		UUIItem saveItem = this.SaveItem;
		if (saveItem != null)
		{
			saveItem.SetUIActive(true);
		}
		this.HideSaveTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.HideSaveTimer = null;
			UUIItem saveItem2 = this.SaveItem;
			if (saveItem2 == null)
			{
				return;
			}
			saveItem2.SetUIActive(false);
		}, (float)this.ShowSaveDuration / 1000f, null, null, true, 1f);
	}

	// Token: 0x04006962 RID: 26978
	protected MotorcycleArrowHpPlayerItem HpPlayerItem;

	// Token: 0x04006963 RID: 26979
	protected MotorcycleArrowBattleProgressItem BattleProgressItem;

	// Token: 0x04006964 RID: 26980
	protected MotorcycleArrowScore ScoreItem;

	// Token: 0x04006965 RID: 26981
	protected MotorcycleArrowBossHpItem BossHpItem;

	// Token: 0x04006966 RID: 26982
	protected SimpleBossStateItem BossHpItem2;

	// Token: 0x04006967 RID: 26983
	protected UUIItem SaveItem;

	// Token: 0x04006968 RID: 26984
	private TimerHandle HideSaveTimer;

	// Token: 0x04006969 RID: 26985
	protected UUIButtonComponent ButtonControlL;

	// Token: 0x0400696A RID: 26986
	protected UUIButtonComponent ButtonControlR;

	// Token: 0x0400696B RID: 26987
	protected UUIButtonComponent ButtonStop;

	// Token: 0x0400696C RID: 26988
	private MotorcycleControlPanelBase MotorcycleControlPanel;

	// Token: 0x0400696D RID: 26989
	private int ShowSaveDuration;

	// Token: 0x020080C9 RID: 32969
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BCDC RID: 179420
		public const int BattleProgress = 0;

		// Token: 0x0402BCDD RID: 179421
		public const int BattleHpPlayer = 1;

		// Token: 0x0402BCDE RID: 179422
		public const int Score = 2;

		// Token: 0x0402BCDF RID: 179423
		public const int Save = 3;

		// Token: 0x0402BCE0 RID: 179424
		public const int Skill = 4;

		// Token: 0x0402BCE1 RID: 179425
		public const int ButtonControlL = 5;

		// Token: 0x0402BCE2 RID: 179426
		public const int ButtonControlR = 6;

		// Token: 0x0402BCE3 RID: 179427
		public const int BossHp = 7;

		// Token: 0x0402BCE4 RID: 179428
		public const int ButtonStop = 8;

		// Token: 0x0402BCE5 RID: 179429
		public const int ButtonControlRoot = 9;
	}
}
