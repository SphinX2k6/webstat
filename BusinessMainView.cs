using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013B2 RID: 5042
[NullableContext(1)]
[Nullable(0)]
public class BusinessMainView : UiViewBase
{
	// Token: 0x06008B0A RID: 35594 RVA: 0x0024A06B File Offset: 0x0024826B
	public BusinessMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008B0B RID: 35595 RVA: 0x0024A08C File Offset: 0x0024828C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06008B0C RID: 35596 RVA: 0x0024A1B0 File Offset: 0x002483B0
	private UniTask InitPopularity()
	{
		BusinessMainView.<InitPopularity>d__12 <InitPopularity>d__;
		<InitPopularity>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPopularity>d__.<>4__this = this;
		<InitPopularity>d__.<>1__state = -1;
		<InitPopularity>d__.<>t__builder.Start<BusinessMainView.<InitPopularity>d__12>(ref <InitPopularity>d__);
		return <InitPopularity>d__.<>t__builder.Task;
	}

	// Token: 0x06008B0D RID: 35597 RVA: 0x0024A1F4 File Offset: 0x002483F4
	private UniTask InitCaptionItem()
	{
		BusinessMainView.<InitCaptionItem>d__13 <InitCaptionItem>d__;
		<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaptionItem>d__.<>4__this = this;
		<InitCaptionItem>d__.<>1__state = -1;
		<InitCaptionItem>d__.<>t__builder.Start<BusinessMainView.<InitCaptionItem>d__13>(ref <InitCaptionItem>d__);
		return <InitCaptionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008B0E RID: 35598 RVA: 0x0024A238 File Offset: 0x00248438
	private UniTask InitNonDetailsModule(UUIItem item)
	{
		BusinessMainView.<InitNonDetailsModule>d__14 <InitNonDetailsModule>d__;
		<InitNonDetailsModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitNonDetailsModule>d__.<>4__this = this;
		<InitNonDetailsModule>d__.item = item;
		<InitNonDetailsModule>d__.<>1__state = -1;
		<InitNonDetailsModule>d__.<>t__builder.Start<BusinessMainView.<InitNonDetailsModule>d__14>(ref <InitNonDetailsModule>d__);
		return <InitNonDetailsModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008B0F RID: 35599 RVA: 0x0024A284 File Offset: 0x00248484
	private UniTask InitSkipItem()
	{
		BusinessMainView.<InitSkipItem>d__15 <InitSkipItem>d__;
		<InitSkipItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSkipItem>d__.<>4__this = this;
		<InitSkipItem>d__.<>1__state = -1;
		<InitSkipItem>d__.<>t__builder.Start<BusinessMainView.<InitSkipItem>d__15>(ref <InitSkipItem>d__);
		return <InitSkipItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008B10 RID: 35600 RVA: 0x0024A2C8 File Offset: 0x002484C8
	private UniTask InitDelegationDetailsModule()
	{
		BusinessMainView.<InitDelegationDetailsModule>d__16 <InitDelegationDetailsModule>d__;
		<InitDelegationDetailsModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDelegationDetailsModule>d__.<>4__this = this;
		<InitDelegationDetailsModule>d__.<>1__state = -1;
		<InitDelegationDetailsModule>d__.<>t__builder.Start<BusinessMainView.<InitDelegationDetailsModule>d__16>(ref <InitDelegationDetailsModule>d__);
		return <InitDelegationDetailsModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008B11 RID: 35601 RVA: 0x0024A30C File Offset: 0x0024850C
	private void InitBtnItem()
	{
		this.BuildBtn = new ButtonItem(base.GetItem(0));
		this.BuildBtn.SetFunction(delegate(int _)
		{
			this.Vc.SkipToBuild();
		});
		this.HelperBtn = new ButtonItem(base.GetItem(1));
		this.HelperBtn.SetFunction(delegate(int _)
		{
			this.Vc.SkipToHelper();
		});
	}

	// Token: 0x06008B12 RID: 35602 RVA: 0x0024A36C File Offset: 0x0024856C
	private UniTask InitNonDetailsList()
	{
		BusinessMainView.<InitNonDetailsList>d__18 <InitNonDetailsList>d__;
		<InitNonDetailsList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitNonDetailsList>d__.<>4__this = this;
		<InitNonDetailsList>d__.<>1__state = -1;
		<InitNonDetailsList>d__.<>t__builder.Start<BusinessMainView.<InitNonDetailsList>d__18>(ref <InitNonDetailsList>d__);
		return <InitNonDetailsList>d__.<>t__builder.Task;
	}

	// Token: 0x06008B13 RID: 35603 RVA: 0x0024A3B0 File Offset: 0x002485B0
	private void RefreshNonDetailsList()
	{
		List<DelegationData> delegationDataList = ModelBase<MoonChasingBusinessModel>.Instance.GetDelegationDataList();
		for (int i = 0; i < this.NonDetailsList.Count; i++)
		{
			DelegationNonDetailsModule delegationNonDetailsModule = this.NonDetailsList[i];
			if (i < delegationDataList.Count)
			{
				delegationNonDetailsModule.Refresh(delegationDataList[i]);
			}
			else
			{
				delegationNonDetailsModule.SetActive(false);
			}
		}
	}

	// Token: 0x06008B14 RID: 35604 RVA: 0x0024A40C File Offset: 0x0024860C
	private void RefreshNonDetailsListConsume()
	{
		List<DelegationData> delegationDataList = ModelBase<MoonChasingBusinessModel>.Instance.GetDelegationDataList();
		for (int i = 0; i < this.NonDetailsList.Count; i++)
		{
			DelegationNonDetailsModule delegationNonDetailsModule = this.NonDetailsList[i];
			if (i < delegationDataList.Count)
			{
				delegationNonDetailsModule.RefreshConsume();
			}
		}
	}

	// Token: 0x06008B15 RID: 35605 RVA: 0x0024A458 File Offset: 0x00248658
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessMainView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessMainView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B16 RID: 35606 RVA: 0x0024A49C File Offset: 0x0024869C
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		BusinessMainView.<OnBeforeShowAsyncImplementImplement>d__22 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<BusinessMainView.<OnBeforeShowAsyncImplementImplement>d__22>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008B17 RID: 35607 RVA: 0x0024A4DF File Offset: 0x002486DF
	protected override void OnBeforeShow()
	{
		this.Vc.Show();
		this.RefreshRedDot();
		ControllerBase<ActivityMoonChasingController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06008B18 RID: 35608 RVA: 0x0024A4FC File Offset: 0x002486FC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OpenTipsTravelView, new Action(this.BackToMainView));
		Singleton<EventSystem>.Instance.Add(EEventName.UnlockMoonChasingData, new Action(this.UnlockMoonChasingData));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.RefreshDelegate, new Action<bool>(this.RefreshDelegate));
		Singleton<EventSystem>.Instance.Add(EEventName.BusinessInvestResult, new Action(this.RefreshDelegateConsume));
		Singleton<EventSystem>.Instance.Add(EEventName.ConditionUnlockRole, new Action(this.ConditionUnlockRole));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.CloseView));
	}

	// Token: 0x06008B19 RID: 35609 RVA: 0x0024A5B0 File Offset: 0x002487B0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenTipsTravelView, new Action(this.BackToMainView));
		Singleton<EventSystem>.Instance.Remove(EEventName.UnlockMoonChasingData, new Action(this.UnlockMoonChasingData));
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.RefreshDelegate, new Action<bool>(this.RefreshDelegate));
		Singleton<EventSystem>.Instance.Remove(EEventName.BusinessInvestResult, new Action(this.RefreshDelegateConsume));
		Singleton<EventSystem>.Instance.Remove(EEventName.ConditionUnlockRole, new Action(this.ConditionUnlockRole));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.CloseView));
	}

	// Token: 0x06008B1A RID: 35610 RVA: 0x0024A662 File Offset: 0x00248862
	protected override void OnBeforeDestroy()
	{
		ModelBase<MoonChasingBusinessModel>.Instance.SetIsInDelegate(false);
	}

	// Token: 0x06008B1B RID: 35611 RVA: 0x0024A670 File Offset: 0x00248870
	private void ConditionUnlockRole()
	{
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (!ModelBase<MoonChasingBusinessModel>.Instance.IsUnlockRoleIdEmpty())
		{
			return;
		}
		if (!this.IsRefreshFromServer)
		{
			return;
		}
		this.IsRefreshFromServer = true;
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Refresh", false, null);
	}

	// Token: 0x06008B1C RID: 35612 RVA: 0x0024A6D0 File Offset: 0x002488D0
	private void CloseView(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.MoonChasingUnlockRoleView)
		{
			if (!this.IsRefreshFromServer)
			{
				return;
			}
			this.IsRefreshFromServer = true;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequence("Refresh", false, null);
		}
	}

	// Token: 0x06008B1D RID: 35613 RVA: 0x0024A719 File Offset: 0x00248919
	private void BackToMainView()
	{
		UUIItem item = base.GetItem(11);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.Vc.BackToState(EBusinessSkipDefine.MainView);
	}

	// Token: 0x06008B1E RID: 35614 RVA: 0x0024A73B File Offset: 0x0024893B
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		if (!(configParams[0] == "Delegation".ToString()))
		{
			return null;
		}
		DelegationDetailsModule details = this.Details;
		if (details == null)
		{
			return null;
		}
		return details.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x06008B1F RID: 35615 RVA: 0x0024A76D File Offset: 0x0024896D
	private void UnlockMoonChasingData()
	{
		this.RefreshSkipItem();
	}

	// Token: 0x06008B20 RID: 35616 RVA: 0x0024A775 File Offset: 0x00248975
	private void RefreshDelegate(bool isReplace)
	{
		if (isReplace)
		{
			this.IsRefreshFromServer = true;
			this.RefreshNonDetailsList();
		}
		else
		{
			this.RefreshNonDetailsListConsume();
		}
		this.Popularity.RefreshPopularity();
	}

	// Token: 0x06008B21 RID: 35617 RVA: 0x0024A79A File Offset: 0x0024899A
	private void RefreshDelegateConsume()
	{
		this.RefreshNonDetailsListConsume();
		this.Popularity.RefreshPopularity();
	}

	// Token: 0x06008B22 RID: 35618 RVA: 0x0024A7B0 File Offset: 0x002489B0
	private UniTask ShowDelegation(int delegateId)
	{
		BusinessMainView.<ShowDelegation>d__34 <ShowDelegation>d__;
		<ShowDelegation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowDelegation>d__.<>4__this = this;
		<ShowDelegation>d__.delegateId = delegateId;
		<ShowDelegation>d__.<>1__state = -1;
		<ShowDelegation>d__.<>t__builder.Start<BusinessMainView.<ShowDelegation>d__34>(ref <ShowDelegation>d__);
		return <ShowDelegation>d__.<>t__builder.Task;
	}

	// Token: 0x06008B23 RID: 35619 RVA: 0x0024A7FC File Offset: 0x002489FC
	private void RefreshSkipItem()
	{
		MoonChasingModel instance = ModelBase<MoonChasingModel>.Instance;
		ValueTuple<EMoonChasingUnlockType, int>? valueTuple = (instance != null) ? instance.GetFirstUnlockData() : null;
		if (valueTuple == null)
		{
			this.SkipItem.SetActive(false);
			return;
		}
		this.SkipItem.SetActive(true);
		this.SkipItem.Refresh();
	}

	// Token: 0x06008B24 RID: 35620 RVA: 0x0024A850 File Offset: 0x00248A50
	public void SkipToMainView()
	{
		this.RefreshNonDetailsList();
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		this.CaptionItem.SetTitleIconByResourceId("SP_ChasingMoonIcon3").Forget();
		base.PlaySequenceAsync("SwitchOut", true, false, null).ContinueWith(delegate()
		{
			DelegationDetailsModule details = this.Details;
			if (details == null)
			{
				return;
			}
			details.SetActive(false);
		}).Forget();
	}

	// Token: 0x06008B25 RID: 35621 RVA: 0x0024A8B8 File Offset: 0x00248AB8
	public void SkipToDelegationDetails(params object[] params_)
	{
		int delegateId = (int)params_[0];
		this.ShowDelegation(delegateId).Forget();
		this.CaptionItem.SetTitleIconByResourceId("SP_ChasingMoonIcon7").Forget();
		base.PlaySequenceAsync("SwitchIn", true, false, null).ContinueWith(delegate()
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}).Forget();
	}

	// Token: 0x06008B26 RID: 35622 RVA: 0x0024A91C File Offset: 0x00248B1C
	public UniTask BeforeShowAsync(bool inMainView)
	{
		BusinessMainView.<BeforeShowAsync>d__38 <BeforeShowAsync>d__;
		<BeforeShowAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeforeShowAsync>d__.<>4__this = this;
		<BeforeShowAsync>d__.inMainView = inMainView;
		<BeforeShowAsync>d__.<>1__state = -1;
		<BeforeShowAsync>d__.<>t__builder.Start<BusinessMainView.<BeforeShowAsync>d__38>(ref <BeforeShowAsync>d__);
		return <BeforeShowAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B27 RID: 35623 RVA: 0x0024A967 File Offset: 0x00248B67
	public void Refresh()
	{
		this.RefreshSkipItem();
	}

	// Token: 0x06008B28 RID: 35624 RVA: 0x0024A96F File Offset: 0x00248B6F
	public void RefreshRedDot()
	{
		this.BuildBtn.BindRedDot(ERedDotName.MoonChasingBuilding, 0);
		this.HelperBtn.BindRedDot(ERedDotName.MoonChasingRole, 0);
	}

	// Token: 0x06008B29 RID: 35625 RVA: 0x0024A993 File Offset: 0x00248B93
	public void SwitchShowViewSequence(bool inMainView)
	{
		if (inMainView)
		{
			this.UiViewSequence.ShowSequenceName = "ShowView";
			return;
		}
		this.UiViewSequence.ShowSequenceName = "ShowView01";
	}

	// Token: 0x040040FB RID: 16635
	[Nullable(2)]
	protected DelegationDetailsModule Details;

	// Token: 0x040040FC RID: 16636
	[Nullable(2)]
	protected PopupCaptionItem CaptionItem;

	// Token: 0x040040FD RID: 16637
	private PopularityModule Popularity;

	// Token: 0x040040FE RID: 16638
	protected List<DelegationNonDetailsModule> NonDetailsList = new List<DelegationNonDetailsModule>();

	// Token: 0x040040FF RID: 16639
	protected BusinessSkipItem SkipItem;

	// Token: 0x04004100 RID: 16640
	private ButtonItem BuildBtn;

	// Token: 0x04004101 RID: 16641
	private ButtonItem HelperBtn;

	// Token: 0x04004102 RID: 16642
	private bool IsRefreshFromServer;

	// Token: 0x04004103 RID: 16643
	private readonly BusinessViewController Vc = new BusinessViewController();

	// Token: 0x0200776C RID: 30572
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040291F3 RID: 168435
		public const int BuildBtn = 0;

		// Token: 0x040291F4 RID: 168436
		public const int HelperBtn = 1;

		// Token: 0x040291F5 RID: 168437
		public const int CaptionItem = 2;

		// Token: 0x040291F6 RID: 168438
		public const int GridOne = 3;

		// Token: 0x040291F7 RID: 168439
		public const int GridTwo = 4;

		// Token: 0x040291F8 RID: 168440
		public const int GridThird = 5;

		// Token: 0x040291F9 RID: 168441
		public const int GridFour = 6;

		// Token: 0x040291FA RID: 168442
		public const int MainItem = 7;

		// Token: 0x040291FB RID: 168443
		public const int ContentItem = 8;

		// Token: 0x040291FC RID: 168444
		public const int PopularityItem = 9;

		// Token: 0x040291FD RID: 168445
		public const int SkipItem = 10;

		// Token: 0x040291FE RID: 168446
		public const int MaskItem = 11;
	}
}
