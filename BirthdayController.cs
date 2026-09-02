using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x020017B5 RID: 6069
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BirthdayController : UiControllerBase<BirthdayController>
{
	// Token: 0x0600AB36 RID: 43830 RVA: 0x002DC14C File Offset: 0x002DA34C
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDayZone, new Action(this.OnCrossDayZone));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TsSyncBirthdayResetState, new Action<bool>(this.TsSyncBirthdayResetState));
	}

	// Token: 0x0600AB37 RID: 43831 RVA: 0x002DC1B0 File Offset: 0x002DA3B0
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDayZone, new Action(this.OnCrossDayZone));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsSyncBirthdayResetState, new Action<bool>(this.TsSyncBirthdayResetState));
	}

	// Token: 0x0600AB38 RID: 43832 RVA: 0x002DC211 File Offset: 0x002DA411
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BirthDayInfoNotify>(ENotifyMessageId.BirthDayInfoNotify, delegate(BirthDayInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<BirthdayModel>.Instance.UpdateBirthdayInfo(notify);
		});
	}

	// Token: 0x0600AB39 RID: 43833 RVA: 0x002DC242 File Offset: 0x002DA442
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BirthDayInfoNotify);
	}

	// Token: 0x0600AB3A RID: 43834 RVA: 0x002DC254 File Offset: 0x002DA454
	public static void TrySelectBirthDayCardRoleRequest(int roleId, int year)
	{
		int? selectedRoleId = ModelBase<BirthdayModel>.Instance.GetSelectedRoleId(year);
		if (selectedRoleId != null && selectedRoleId.Value != 0)
		{
			return;
		}
		BirthDayCardRoleRequest birthDayCardRoleRequest = BirthDayCardRoleRequest.Create();
		birthDayCardRoleRequest.RoleID = roleId;
		birthDayCardRoleRequest.YearId = year;
		Singleton<Net>.Instance.Call<BirthDayCardRoleResponse>(ERequestMessageId.BirthDayCardRoleRequest, birthDayCardRoleRequest, delegate(BirthDayCardRoleResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21704, null, true, true);
				return;
			}
			ModelBase<BirthdayModel>.Instance.SetSelectedRole(roleId, year);
		}, 0);
	}

	// Token: 0x0600AB3B RID: 43835 RVA: 0x002DC2D4 File Offset: 0x002DA4D4
	public static bool TryBirthDayRewardRequest(int year)
	{
		if (ModelBase<BirthdayModel>.Instance.GetSelectedRoleId(year) != null)
		{
			return false;
		}
		BirthDayRewardRequest birthDayRewardRequest = BirthDayRewardRequest.Create();
		birthDayRewardRequest.YearId = year;
		Singleton<Net>.Instance.Call<BirthDayRewardResponse>(ERequestMessageId.BirthDayRewardRequest, birthDayRewardRequest, delegate(BirthDayRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25985, null, true, true);
				return;
			}
			ModelBase<BirthdayModel>.Instance.SetIsReceiveBirthdayReward(true);
		}, 0);
		return true;
	}

	// Token: 0x0600AB3C RID: 43836 RVA: 0x002DC338 File Offset: 0x002DA538
	public void TryOpenBirthdayView(bool isInstantly = false)
	{
		if (!ModelBase<BirthdayModel>.Instance.GetBirthdayIsReset())
		{
			return;
		}
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10084))
		{
			return;
		}
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.Birthday, ESplashScreenType.Config, delegate()
		{
			int thisBirthdayYear = ModelBase<BirthdayModel>.Instance.ThisBirthdayYear;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BirthdayRoleSelectView, new BirthdayInfo(BirthdayDefine.ETriggerType.Natural, thisBirthdayYear, null), null);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
	}

	// Token: 0x0600AB3D RID: 43837 RVA: 0x002DC398 File Offset: 0x002DA598
	public void UseBirthdayItem(int itemId)
	{
		int limitYear = ConfigBirthDayByItemId.GetConfig(itemId, true).Value.LimitYear;
		int? selectedRoleId = ModelBase<BirthdayModel>.Instance.GetSelectedRoleId(limitYear);
		if (selectedRoleId != null && selectedRoleId.Value != 0)
		{
			BirthdayRepeatEnterEvent birthdayRepeatEnterEvent = new BirthdayRepeatEnterEvent();
			birthdayRepeatEnterEvent.i_item_id = itemId;
			birthdayRepeatEnterEvent.i_trigger_type = 1;
			birthdayRepeatEnterEvent.bird_round_id = ConfigBirthDayByItemId.GetConfig(itemId, true).Value.Id;
			ControllerBase<LogReportController>.Instance.LogReport(birthdayRepeatEnterEvent);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BirthdayLetterView, new BirthdayInfo(BirthdayDefine.ETriggerType.Item, limitYear, new int?(selectedRoleId.Value)), null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BirthdayRoleSelectView, new BirthdayInfo(BirthdayDefine.ETriggerType.Item, limitYear, null), null);
	}

	// Token: 0x0600AB3E RID: 43838 RVA: 0x002DC464 File Offset: 0x002DA664
	public void OnWorldDone()
	{
		bool flag = ModelBase<BirthdayModel>.Instance.IsDuringBirthday();
		if (!ModelBase<BirthdayModel>.Instance.IsReceiveBirthdayReward && flag)
		{
			this.TryOpenBirthdayView(false);
		}
	}

	// Token: 0x0600AB3F RID: 43839 RVA: 0x002DC494 File Offset: 0x002DA694
	public void OnCrossDayZone()
	{
		bool flag = ModelBase<BirthdayModel>.Instance.IsDuringBirthday();
		if (!ModelBase<BirthdayModel>.Instance.IsReceiveBirthdayReward && flag)
		{
			this.TryOpenBirthdayView(true);
		}
	}

	// Token: 0x0600AB40 RID: 43840 RVA: 0x002DC4C4 File Offset: 0x002DA6C4
	public void TsSyncBirthdayResetState(bool isReset)
	{
		ModelBase<BirthdayModel>.Instance.SyncTsResetState(isReset);
	}
}
