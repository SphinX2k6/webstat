using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001DB6 RID: 7606
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GamePingController : UiControllerBase<GamePingController>
{
	// Token: 0x0600E075 RID: 57461 RVA: 0x003C58A4 File Offset: 0x003C3AA4
	protected override bool OnInit()
	{
		this.InitTimer();
		return true;
	}

	// Token: 0x0600E076 RID: 57462 RVA: 0x003C58AD File Offset: 0x003C3AAD
	protected override bool OnClear()
	{
		this.CancelTimer();
		return true;
	}

	// Token: 0x0600E077 RID: 57463 RVA: 0x003C58B6 File Offset: 0x003C3AB6
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x0600E078 RID: 57464 RVA: 0x003C58D4 File Offset: 0x003C3AD4
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
	}

	// Token: 0x0600E079 RID: 57465 RVA: 0x003C58F2 File Offset: 0x003C3AF2
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.PingView, new Func<EUiViewName, object, bool>(this.CanOpenView), "GamePingController.CanOpenView");
	}

	// Token: 0x0600E07A RID: 57466 RVA: 0x003C5914 File Offset: 0x003C3B14
	private bool CanOpenView(EUiViewName viewName, object param)
	{
		return this.CheckCanOpenView();
	}

	// Token: 0x0600E07B RID: 57467 RVA: 0x003C5924 File Offset: 0x003C3B24
	private bool CheckCanOpenView()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (instanceId == 0)
		{
			return true;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config == null || (config.Value.WorldDungeonSubType != 1 && config.Value.InstSubType != 57);
	}

	// Token: 0x0600E07C RID: 57468 RVA: 0x003C5982 File Offset: 0x003C3B82
	private void OnWorldDoneAndCloseLoading()
	{
		if (Singleton<CloudGameManager>.Instance.IsCloudGame)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PingView, null, null);
	}

	// Token: 0x0600E07D RID: 57469 RVA: 0x003C59A2 File Offset: 0x003C3BA2
	private void InitTimer()
	{
		this.GamePingTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.CheckPing), (float)this.REFRESH_PING_INTERVAL_MS, 1f, null, null, true);
	}

	// Token: 0x0600E07E RID: 57470 RVA: 0x003C59CF File Offset: 0x003C3BCF
	private void CancelTimer()
	{
		if (this.GamePingTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.GamePingTimer);
			this.GamePingTimer = null;
		}
	}

	// Token: 0x0600E07F RID: 57471 RVA: 0x003C59F4 File Offset: 0x003C3BF4
	private void CheckPing(float _)
	{
		int num = (int)Math.Ceiling((double)Singleton<NetInfo>.Instance.RttMs);
		num = Math.Min(num, this.MAX_PING_MS);
		num = Math.Max(num, this.MIN_PING_MS);
		ModelBase<GamePingModel>.Instance.CurrentPing = num;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnCheckGamePing, num);
	}

	// Token: 0x04006BB4 RID: 27572
	private int REFRESH_PING_INTERVAL_MS = 100;

	// Token: 0x04006BB5 RID: 27573
	private int MAX_PING_MS = 999;

	// Token: 0x04006BB6 RID: 27574
	private int MIN_PING_MS = 1;

	// Token: 0x04006BB7 RID: 27575
	[Nullable(2)]
	private TimerHandle GamePingTimer;
}
