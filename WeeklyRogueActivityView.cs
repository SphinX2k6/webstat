using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D43 RID: 11587
public class WeeklyRogueActivityView : UiViewBase
{
	// Token: 0x06017606 RID: 95750 RVA: 0x0067B8F2 File Offset: 0x00679AF2
	[NullableContext(1)]
	public WeeklyRogueActivityView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06017607 RID: 95751 RVA: 0x0067B8FC File Offset: 0x00679AFC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText))
		};
	}

	// Token: 0x06017608 RID: 95752 RVA: 0x0067B9B0 File Offset: 0x00679BB0
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueActivityView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueActivityView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017609 RID: 95753 RVA: 0x0067B9F4 File Offset: 0x00679BF4
	protected override void OnStart()
	{
		WeeklyRogueModel instance = ModelBase<WeeklyRogueModel>.Instance;
		object openParam = this.OpenParam;
		bool isOpenedViewByWorld;
		if (openParam is EWeeklyRogueOpenWay)
		{
			EWeeklyRogueOpenWay eweeklyRogueOpenWay = (EWeeklyRogueOpenWay)openParam;
			isOpenedViewByWorld = (eweeklyRogueOpenWay == EWeeklyRogueOpenWay.World);
		}
		else
		{
			isOpenedViewByWorld = false;
		}
		instance.IsOpenedViewByWorld = isOpenedViewByWorld;
		RogueWeeklyCycle value = this.ActivityBaseData.GetCycleConfig().Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.BuffDesc, value.BuffDescParam());
		this.ActivityBaseData.SaveFirstCheckRedDotState();
	}

	// Token: 0x0601760A RID: 95754 RVA: 0x0067BA67 File Offset: 0x00679C67
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
	}

	// Token: 0x0601760B RID: 95755 RVA: 0x0067BA85 File Offset: 0x00679C85
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
	}

	// Token: 0x0601760C RID: 95756 RVA: 0x0067BAA4 File Offset: 0x00679CA4
	private void OnCycleRefresh()
	{
		Action value = delegate()
		{
			base.CloseMe(null);
		};
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeeklyRogueCycleRefresh);
		confirmBoxDataNew.FunctionMap.Add(1, value);
		confirmBoxDataNew.FunctionMap.Add(0, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601760D RID: 95757 RVA: 0x0067BAEF File Offset: 0x00679CEF
	protected override void OnBeforeShow()
	{
		if (this.CycleId != this.ActivityBaseData.CycleId)
		{
			this.OnCycleRefresh();
		}
		this.RefreshButton();
	}

	// Token: 0x0601760E RID: 95758 RVA: 0x0067BB10 File Offset: 0x00679D10
	private void RefreshButton()
	{
		if (ModelBase<WeeklyRogueModel>.Instance.HasLastInfo())
		{
			this.ConfirmButton.SetLocalTextNew("WeRougeHomePageButtonTextContinue", Array.Empty<object>());
			return;
		}
		this.ConfirmButton.SetLocalTextNew("WeRougeHomePageButtonTextStart", Array.Empty<object>());
	}

	// Token: 0x0601760F RID: 95759 RVA: 0x0067BB4C File Offset: 0x00679D4C
	private void OnBtnConfirmClick(int _)
	{
		if (ModelBase<WeeklyRogueModel>.Instance.HasLastInfo())
		{
			RogueWeeklyLastInfo lastInstInfo = this.ActivityBaseData.LastInstInfo;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoguelikeEnter);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				lastInstInfo.CurLayer.ToString(),
				lastInstInfo.MaxLayer.ToString()
			});
			Action value = delegate()
			{
				if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
					return;
				}
				ControllerBase<WeeklyRogueController>.Instance.RogueWeeklyStartRequest(new List<int>());
			};
			Action value2 = delegate()
			{
				ControllerBase<WeeklyRogueController>.Instance.InstanceSettleRequest(delegate(bool success)
				{
					if (success)
					{
						this.RefreshButton();
					}
				});
			};
			confirmBoxDataNew.FunctionMap.Add(1, value2);
			confirmBoxDataNew.FunctionMap.Add(2, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueRoleSelectView, null, delegate(bool success, int viewId)
		{
			if (success && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WeeklyRogueActivityView))
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.WeeklyRogueActivityView);
				if (viewByName == null)
				{
					return;
				}
				viewByName.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x06017610 RID: 95760 RVA: 0x0067BC3C File Offset: 0x00679E3C
	private void OnBtnHelpBtn()
	{
		RogueWeeklyCycle? cycleConfig = this.ActivityBaseData.GetCycleConfig();
		ControllerBase<HelpController>.Instance.OpenHelpById(cycleConfig.Value.HelpId);
	}

	// Token: 0x0400B377 RID: 45943
	[Nullable(1)]
	protected WeeklyRogueData ActivityBaseData;

	// Token: 0x0400B378 RID: 45944
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400B379 RID: 45945
	[Nullable(2)]
	private ButtonItem ConfirmButton;

	// Token: 0x0400B37A RID: 45946
	private int CycleId;

	// Token: 0x02009009 RID: 36873
	private enum EWeeklyRogueActivityViewDefine
	{
		// Token: 0x0403053E RID: 197950
		CaptionItem,
		// Token: 0x0403053F RID: 197951
		TxtTitle,
		// Token: 0x04030540 RID: 197952
		TxtSubTitle,
		// Token: 0x04030541 RID: 197953
		TxtBuffDescription,
		// Token: 0x04030542 RID: 197954
		BtnConfirm,
		// Token: 0x04030543 RID: 197955
		TextureBg,
		// Token: 0x04030544 RID: 197956
		TxtDesc
	}
}
