using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200153B RID: 5435
[NullableContext(2)]
[Nullable(0)]
public class ActivityHomePageRegressSubView : ActivitySubViewBase
{
	// Token: 0x06009865 RID: 39013 RVA: 0x0027E8C4 File Offset: 0x0027CAC4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUITexture)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUITexture)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(24, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnSignBtnClick)),
			new ValueTuple<int, Delegate>(22, new Action(this.OnSignBtnClick)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnShopBtnClick)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnQuestionBtnClick))
		};
	}

	// Token: 0x06009866 RID: 39014 RVA: 0x0027EBC8 File Offset: 0x0027CDC8
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityHomePageRegressSubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityHomePageRegressSubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009867 RID: 39015 RVA: 0x0027EC0C File Offset: 0x0027CE0C
	private IRegressGradeSignContext GetRegressNormalGradeSignContext()
	{
		return new IRegressGradeSignContext
		{
			Btn = base.GetButton(9),
			RedDotItem = base.GetItem(10),
			CurrencyTexNode = base.GetTexture(20),
			CurrencyText = base.GetText(21),
			BubbleNode = base.GetItem(26)
		};
	}

	// Token: 0x06009868 RID: 39016 RVA: 0x0027EC70 File Offset: 0x0027CE70
	private IRegressGradeSignContext GetRegressHyperGradeSignContext()
	{
		return new IRegressGradeSignContext
		{
			Btn = base.GetButton(22),
			RedDotItem = base.GetItem(25),
			CurrencyTexNode = base.GetTexture(23),
			CurrencyText = base.GetText(24),
			BubbleNode = base.GetItem(27)
		};
	}

	// Token: 0x06009869 RID: 39017 RVA: 0x0027ECD4 File Offset: 0x0027CED4
	protected override void OnStart()
	{
		ModelBase<ActivityRegressModel>.Instance.SetFirstShowChecked();
		this.ActivityDescriptionTypeA.SetContentByTextId("Activity_101800001_Desc", Array.Empty<string>());
		this.RegressQuestBtnItem.BindRedDot(ERedDotName.ActivityRecallTaskEntry);
		this.RegressSignBtnItem.BindRedDot(ERedDotName.ActivityRecallSignEntry);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressQuestionnaire, base.GetItem(14), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressShopDiscount, base.GetItem(12), null, 0);
	}

	// Token: 0x0600986A RID: 39018 RVA: 0x0027ED54 File Offset: 0x0027CF54
	protected override void OnBeforeDestroy()
	{
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressQuestionnaire, base.GetItem(14), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressShopDiscount, base.GetItem(12), 0);
		foreach (ActivityRegressEntryItemPanel activityRegressEntryItemPanel in this.ActivityRecallEntryMap.Values)
		{
			activityRegressEntryItemPanel.DestroyAsync();
		}
		this.ActivityRecallEntryMap.Clear();
		this.RegressSignBtnItem.Clear();
		this.RegressQuestBtnItem.Clear();
	}

	// Token: 0x0600986B RID: 39019 RVA: 0x0027EDFC File Offset: 0x0027CFFC
	protected override void OnRefreshView()
	{
		this.RefreshTitle();
		this.RefreshEntrance();
		this.RefreshTaskProgress();
		this.RefreshGrade();
		this.RefreshSignBubble();
		this.RefreshDiscountBubble();
	}

	// Token: 0x0600986C RID: 39020 RVA: 0x0027EE22 File Offset: 0x0027D022
	protected override void OnTimer(float gap)
	{
		this.RefreshTitle();
	}

	// Token: 0x0600986D RID: 39021 RVA: 0x0027EE2A File Offset: 0x0027D02A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
	}

	// Token: 0x0600986E RID: 39022 RVA: 0x0027EE64 File Offset: 0x0027D064
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
	}

	// Token: 0x0600986F RID: 39023 RVA: 0x0027EE9E File Offset: 0x0027D09E
	private void OnSignBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, EActivityMainSubViewType.Sign, null);
	}

	// Token: 0x06009870 RID: 39024 RVA: 0x0027EEB6 File Offset: 0x0027D0B6
	private void OnShopBtnClick()
	{
		SkipTaskManager.RunByConfigId(859201, null);
		ActivityRegressHelper.ReportRegressLog1060();
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetShopRedDotChecked();
	}

	// Token: 0x06009871 RID: 39025 RVA: 0x0027EED7 File Offset: 0x0027D0D7
	private void OnQuestionBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressQuestionnaireView, null, null);
	}

	// Token: 0x06009872 RID: 39026 RVA: 0x0027EEEA File Offset: 0x0027D0EA
	private void OnRegressQuestBtnClick(ERegressGrade grade)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressTaskMainView, EActivityRegressTaskSubViewType.MainTask, null);
	}

	// Token: 0x06009873 RID: 39027 RVA: 0x0027EF04 File Offset: 0x0027D104
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(ModelBase<ActivityRegressModel>.Instance.ActivityData);
		this.TitleComponent.SetTitleByText(ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(ModelBase<ActivityRegressModel>.Instance.ActivityData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06009874 RID: 39028 RVA: 0x0027EF80 File Offset: 0x0027D180
	private void RefreshTaskProgress()
	{
		double regressTaskProgressFloat = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskProgressFloat01();
		base.GetText(5).SetText(((int)(regressTaskProgressFloat * 100.0)).ToString() + "%", true);
		base.GetTexture(7).SetFillAmount((float)regressTaskProgressFloat);
	}

	// Token: 0x06009875 RID: 39029 RVA: 0x0027EFD8 File Offset: 0x0027D1D8
	private void RefreshGrade()
	{
		ERegressGrade grade = ModelBase<ActivityRegressModel>.Instance.Grade;
		this.RegressQuestBtnItem.Grade = grade;
		this.RegressSignBtnItem.Grade = grade;
		base.GetItem(18).SetUIActive(grade == ERegressGrade.Normal);
		base.GetItem(19).SetUIActive(grade == ERegressGrade.Hyper);
	}

	// Token: 0x06009876 RID: 39030 RVA: 0x0027F02A File Offset: 0x0027D22A
	private void RefreshEntrance()
	{
		this.RefreshSingleEntrance(EActivityRegressEntranceType.NewMainLine);
		this.RefreshSingleEntrance(EActivityRegressEntranceType.NewArea);
		this.RefreshRoleEntrance();
	}

	// Token: 0x06009877 RID: 39031 RVA: 0x0027F040 File Offset: 0x0027D240
	private void RefreshSingleEntrance(EActivityRegressEntranceType entryType)
	{
		RegressEntry? regressEntrySingleConfigByType = ConfigBase<ActivityRegressConfig>.Instance.GetRegressEntrySingleConfigByType(entryType);
		this.ActivityRecallEntryMap[entryType].RefreshData(entryType, regressEntrySingleConfigByType);
	}

	// Token: 0x06009878 RID: 39032 RVA: 0x0027F06C File Offset: 0x0027D26C
	private void RefreshRoleEntrance()
	{
		RegressEntry? config = ConfigBase<ActivityRegressConfig>.Instance.GetSortedOpenRegressEntryConfigList()[0];
		this.ActivityRecallEntryMap[EActivityRegressEntranceType.NewRole1].RefreshData(EActivityRegressEntranceType.NewRole1, config);
	}

	// Token: 0x06009879 RID: 39033 RVA: 0x0027F09D File Offset: 0x0027D29D
	private void OnActivityUpdate()
	{
		this.OnRefreshView();
	}

	// Token: 0x0600987A RID: 39034 RVA: 0x0027F0A5 File Offset: 0x0027D2A5
	private void OnInventoryUpdate(int configId, int count)
	{
		this.RefreshTaskProgress();
	}

	// Token: 0x0600987B RID: 39035 RVA: 0x0027F0B0 File Offset: 0x0027D2B0
	private void RefreshSignBubble()
	{
		bool flag = ModelBase<ActivityRegressModel>.Instance.TodayFirstShowSign();
		bool flag2 = ModelBase<ActivityRegressModel>.Instance.HasSignRewardCanClaimed();
		IRegressGradeSignContext activateContext = this.RegressSignBtnItem.GetActivateContext();
		bool flag3 = flag2 && flag;
		if (flag3)
		{
			IRegressRewardItemInfo latestSignRewardItemInfo = ModelBase<ActivityRegressModel>.Instance.GetLatestSignRewardItemInfo();
			activateContext.CurrencyText.SetText("x" + latestSignRewardItemInfo.ItemCount.ToString(), true);
		}
		this.RegressSignBtnItem.SetClaimRewardBubbleActive(flag3);
	}

	// Token: 0x0600987C RID: 39036 RVA: 0x0027F122 File Offset: 0x0027D322
	private void RefreshDiscountBubble()
	{
		base.GetItem(15).SetUIActive(false);
	}

	// Token: 0x0400468F RID: 18063
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04004690 RID: 18064
	private ActivityDescriptionTypeA ActivityDescriptionTypeA;

	// Token: 0x04004691 RID: 18065
	private RegressGradeButtonItem RegressQuestBtnItem;

	// Token: 0x04004692 RID: 18066
	private RegressGradeSignItem RegressSignBtnItem;

	// Token: 0x04004693 RID: 18067
	[Nullable(1)]
	private readonly Dictionary<EActivityRegressEntranceType, ActivityRegressEntryItemPanel> ActivityRecallEntryMap = new Dictionary<EActivityRegressEntranceType, ActivityRegressEntryItemPanel>();

	// Token: 0x020078F2 RID: 30962
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029914 RID: 170260
		public const int ActivityTitle = 0;

		// Token: 0x04029915 RID: 170261
		public const int EntranceBtn1 = 1;

		// Token: 0x04029916 RID: 170262
		public const int EntranceBtn2 = 2;

		// Token: 0x04029917 RID: 170263
		public const int EntranceBtn3 = 3;

		// Token: 0x04029918 RID: 170264
		public const int EntranceBtn4 = 4;

		// Token: 0x04029919 RID: 170265
		public const int ProgressTxt = 5;

		// Token: 0x0402991A RID: 170266
		public const int ActivityDescriptionTypeA = 6;

		// Token: 0x0402991B RID: 170267
		public const int TexBar = 7;

		// Token: 0x0402991C RID: 170268
		public const int BtnConfirmB = 8;

		// Token: 0x0402991D RID: 170269
		public const int SignBtn = 9;

		// Token: 0x0402991E RID: 170270
		public const int SignRedDot = 10;

		// Token: 0x0402991F RID: 170271
		public const int ShopBtn = 11;

		// Token: 0x04029920 RID: 170272
		public const int ShopBtnRedDot = 12;

		// Token: 0x04029921 RID: 170273
		public const int QuestionBtn = 13;

		// Token: 0x04029922 RID: 170274
		public const int QuestionBtnRedDot = 14;

		// Token: 0x04029923 RID: 170275
		public const int ShopDiscountNode = 15;

		// Token: 0x04029924 RID: 170276
		public const int ShopDiscountText = 16;

		// Token: 0x04029925 RID: 170277
		public const int HyperConfirmBtnB = 17;

		// Token: 0x04029926 RID: 170278
		public const int NormalCurrencyTexNode = 18;

		// Token: 0x04029927 RID: 170279
		public const int HyperCurrencyTexNode = 19;

		// Token: 0x04029928 RID: 170280
		public const int NormalSignCurrencyIcon = 20;

		// Token: 0x04029929 RID: 170281
		public const int NormalSignCurrencyText = 21;

		// Token: 0x0402992A RID: 170282
		public const int HyperSignBtn = 22;

		// Token: 0x0402992B RID: 170283
		public const int HyperSignCurrencyIcon = 23;

		// Token: 0x0402992C RID: 170284
		public const int HyperSignCurrencyText = 24;

		// Token: 0x0402992D RID: 170285
		public const int HyperSignRedDot = 25;

		// Token: 0x0402992E RID: 170286
		public const int NormalSignBubbleNode = 26;

		// Token: 0x0402992F RID: 170287
		public const int HyperSignBubbleNode = 27;
	}
}
