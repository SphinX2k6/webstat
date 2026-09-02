using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020015E2 RID: 5602
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityTrapDefenseController : ActivityControllerBase<ActivityTrapDefenseController>
{
	// Token: 0x06009DA8 RID: 40360 RVA: 0x00294235 File Offset: 0x00292435
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009DA9 RID: 40361 RVA: 0x00294238 File Offset: 0x00292438
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x06009DAA RID: 40362 RVA: 0x00294256 File Offset: 0x00292456
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x06009DAB RID: 40363 RVA: 0x00294274 File Offset: 0x00292474
	private void OnWorldDone()
	{
		if (ModelBase<TrapDefenseModel>.Instance.NeedOpenActivityMainView)
		{
			this.AddMainViewSplashTask();
		}
	}

	// Token: 0x06009DAC RID: 40364 RVA: 0x00294288 File Offset: 0x00292488
	private void AddMainViewSplashTask()
	{
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseMainView, null, null);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
	}

	// Token: 0x06009DAD RID: 40365 RVA: 0x002942C8 File Offset: 0x002924C8
	[NullableContext(0)]
	protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		ActivityTrapDefenseController.<OnOpenSubView>d__6 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.viewName = viewName;
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<ActivityTrapDefenseController.<OnOpenSubView>d__6>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x06009DAE RID: 40366 RVA: 0x0029430B File Offset: 0x0029250B
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009DAF RID: 40367 RVA: 0x0029430D File Offset: 0x0029250D
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_TowerDefenseActivityMain";
	}

	// Token: 0x06009DB0 RID: 40368 RVA: 0x00294314 File Offset: 0x00292514
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewTrapDefense();
	}

	// Token: 0x06009DB1 RID: 40369 RVA: 0x0029431B File Offset: 0x0029251B
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.Data = new ActivityTrapDefenseData();
		return this.Data;
	}

	// Token: 0x06009DB2 RID: 40370 RVA: 0x00294330 File Offset: 0x00292530
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TrapDefenseChallengeUpdateNotify>(ENotifyMessageId.TrapDefenseChallengeUpdateNotify, delegate(TrapDefenseChallengeUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoChallengeUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseRewardUpdateNotify>(ENotifyMessageId.TrapDefenseRewardUpdateNotify, delegate(TrapDefenseRewardUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoRewardUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseSpecialRewardUpdateNotify>(ENotifyMessageId.TrapDefenseSpecialRewardUpdateNotify, delegate(TrapDefenseSpecialRewardUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoSpecialRewardUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseTechUpdateNotify>(ENotifyMessageId.TrapDefenseTechUpdateNotify, delegate(TrapDefenseTechUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoTechUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseBdUpdateNotify>(ENotifyMessageId.TrapDefenseBdUpdateNotify, delegate(TrapDefenseBdUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoBdUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseBdGroupUnlockNotify>(ENotifyMessageId.TrapDefenseBdGroupUnlockNotify, delegate(TrapDefenseBdGroupUnlockNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoBdBuffUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseTechPointUpdateNotify>(ENotifyMessageId.TrapDefenseTechPointUpdateNotify, delegate(TrapDefenseTechPointUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoTechPointUpdateNotify(response);
		});
	}

	// Token: 0x06009DB3 RID: 40371 RVA: 0x00294488 File Offset: 0x00292688
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseChallengeUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseRewardUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseSpecialRewardUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseTechUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseBdUpdateNotify);
	}

	// Token: 0x06009DB4 RID: 40372 RVA: 0x002944E8 File Offset: 0x002926E8
	public void RefreshActivityRedDot()
	{
		ActivityTrapDefenseData data = this.Data;
		int? num = (data != null) ? new int?(data.Id) : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, num.Value);
			}
		}
	}

	// Token: 0x06009DB5 RID: 40373 RVA: 0x0029454D File Offset: 0x0029274D
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseActivityUnlockView, null, null);
	}

	// Token: 0x04004899 RID: 18585
	[Nullable(2)]
	public ActivityTrapDefenseData Data;
}
