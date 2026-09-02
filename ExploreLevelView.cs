using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ExploreLevel;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B65 RID: 7013
[NullableContext(1)]
[Nullable(0)]
public class ExploreLevelView : UiTickViewBase
{
	// Token: 0x0600CB23 RID: 52003 RVA: 0x00362C64 File Offset: 0x00360E64
	public ExploreLevelView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CB24 RID: 52004 RVA: 0x00362C70 File Offset: 0x00360E70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickRewardPreviewButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickCloseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CB25 RID: 52005 RVA: 0x00362EF0 File Offset: 0x003610F0
	protected override UniTask OnBeforeStartAsync()
	{
		ExploreLevelView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ExploreLevelView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CB26 RID: 52006 RVA: 0x00362F34 File Offset: 0x00361134
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollView<CommonItemSmallItemGrid>(base.GetScrollViewWithScrollbar(5), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemSmallItemGrid>(this.OnCreateRewardItemGrid), null);
		this.ExploreLevelItemScrollView = new LoopScrollView<ExploreLevelItem, CountryExploreScoreData>(base.GetLoopScrollViewComponent(8), base.GetItem(9).GetOwner() as AUIBaseActor, new Func<ExploreLevelItem>(this.OnCreateExploreLevelItem), false);
		this.RefreshScoreDisplay();
		this.RefreshScoreProgress();
		this.RefreshExploreLevelItemScrollView();
	}

	// Token: 0x0600CB27 RID: 52007 RVA: 0x00362FA4 File Offset: 0x003611A4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnExploreScoreRewardResponse, new Action(this.OnExploreScoreRewardResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCountryExploreScoreInfoResponse, new Action(this.OnCountryExploreScoreInfoResponse));
		Singleton<EventSystem>.Instance.Add(EEventName.OnExploreLevelNotify, new Action(this.OnExploreLevelNotify));
		Singleton<EventSystem>.Instance.Add(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Add(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600CB28 RID: 52008 RVA: 0x00363038 File Offset: 0x00361238
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnExploreScoreRewardResponse, new Action(this.OnExploreScoreRewardResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCountryExploreScoreInfoResponse, new Action(this.OnCountryExploreScoreInfoResponse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnExploreLevelNotify, new Action(this.OnExploreLevelNotify));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0600CB29 RID: 52009 RVA: 0x003630CA File Offset: 0x003612CA
	protected override void OnBeforeDestroy()
	{
		GenericScrollView<CommonItemSmallItemGrid> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView != null)
		{
			rewardScrollView.ClearChildren();
		}
		this.RewardScrollView = null;
		LoopScrollView<ExploreLevelItem, CountryExploreScoreData> exploreLevelItemScrollView = this.ExploreLevelItemScrollView;
		if (exploreLevelItemScrollView != null)
		{
			exploreLevelItemScrollView.ClearGridProxies();
		}
		this.ExploreLevelItemScrollView = null;
		this.CountryExploreLevelData = null;
	}

	// Token: 0x0600CB2A RID: 52010 RVA: 0x00363103 File Offset: 0x00361303
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreLevelView, null);
	}

	// Token: 0x0600CB2B RID: 52011 RVA: 0x00363115 File Offset: 0x00361315
	private void OnExploreScoreRewardResponse()
	{
	}

	// Token: 0x0600CB2C RID: 52012 RVA: 0x00363118 File Offset: 0x00361318
	private void OnCountryExploreScoreInfoResponse()
	{
		this.RefreshExploreLevelItemScrollView();
		int exploreScore = this.CountryExploreLevelData.GetExploreScore();
		int maxExploreScore = this.CurrentExploreLevelRewardData.GetMaxExploreScore();
		if (maxExploreScore < 0)
		{
			this.RefreshScoreProgress();
			return;
		}
		this.PlayProgressBar(this.CurrentExploreScore, this.CurrentMaxExploreScore, exploreScore, maxExploreScore);
	}

	// Token: 0x0600CB2D RID: 52013 RVA: 0x00363164 File Offset: 0x00361364
	protected override void OnTick(float delta)
	{
		if (!this.IsProgressBarPlaying)
		{
			return;
		}
		if (this.IsPausePlayProgressBar)
		{
			return;
		}
		if (this.AnimationTargetExploreScore < this.AnimationCurrentExploreScore)
		{
			float num = Singleton<MathUtils>.Instance.Lerp((float)this.AnimationCurrentExploreScore, (float)this.AnimationCurrentMaxExploreScore, this.AnimationCurrentAnimationTime / 300f);
			this.SetExploreScoreDisplay((int)num, this.AnimationCurrentMaxExploreScore);
			if (num >= (float)this.AnimationCurrentMaxExploreScore)
			{
				this.PlayProgressBar(0, this.AnimationTargetMaxExploreScore, this.AnimationTargetExploreScore, this.AnimationTargetMaxExploreScore);
			}
			this.AnimationCurrentAnimationTime += delta;
			return;
		}
		float num2 = Singleton<MathUtils>.Instance.Lerp((float)this.AnimationCurrentExploreScore, (float)this.AnimationTargetExploreScore, this.AnimationCurrentAnimationTime / 300f);
		this.SetExploreScoreDisplay((int)num2, this.AnimationTargetMaxExploreScore);
		if (this.AnimationCurrentAnimationTime >= 300f)
		{
			this.RefreshScoreDisplay();
			this.RefreshScoreProgress();
			this.StopProgressBar();
			return;
		}
		this.AnimationCurrentAnimationTime += delta;
	}

	// Token: 0x0600CB2E RID: 52014 RVA: 0x00363257 File Offset: 0x00361457
	private void PlayProgressBar(int exploreScore, int maxExploreScore, int targetExploreScore, int targetMaxExploreScore)
	{
		this.AnimationCurrentExploreScore = exploreScore;
		this.AnimationCurrentMaxExploreScore = maxExploreScore;
		this.AnimationTargetExploreScore = targetExploreScore;
		this.AnimationTargetMaxExploreScore = targetMaxExploreScore;
		this.AnimationCurrentAnimationTime = 0f;
		this.IsProgressBarPlaying = true;
	}

	// Token: 0x0600CB2F RID: 52015 RVA: 0x00363288 File Offset: 0x00361488
	private void SetPausePlayProgressBar(bool bPause)
	{
		this.IsPausePlayProgressBar = bPause;
	}

	// Token: 0x0600CB30 RID: 52016 RVA: 0x00363291 File Offset: 0x00361491
	private void StopProgressBar()
	{
		this.IsProgressBarPlaying = false;
		this.AnimationCurrentAnimationTime = 0f;
	}

	// Token: 0x0600CB31 RID: 52017 RVA: 0x003632A8 File Offset: 0x003614A8
	private void ActivateGetExpNiagara()
	{
		UUINiagara uiNiagara = base.GetUiNiagara(14);
		if (uiNiagara.IsUIActiveSelf())
		{
			uiNiagara.ActivateSystem(true);
			return;
		}
		uiNiagara.SetUIActive(true);
	}

	// Token: 0x0600CB32 RID: 52018 RVA: 0x003632D8 File Offset: 0x003614D8
	private void OnExploreLevelNotify()
	{
		this.CountryExploreLevelData = ModelBase<ExploreLevelModel>.Instance.GetCurrentCountryExploreLevelData();
		this.CurrentExploreLevelRewardData = this.CountryExploreLevelData.GetCurrentExploreLevelRewardData();
		int exploreScore = this.CountryExploreLevelData.GetExploreScore();
		int maxExploreScore = this.CurrentExploreLevelRewardData.GetMaxExploreScore();
		if (maxExploreScore < 0)
		{
			this.RefreshScoreProgress();
			return;
		}
		this.PlayProgressBar(this.CurrentExploreScore, this.CurrentMaxExploreScore, exploreScore, maxExploreScore);
	}

	// Token: 0x0600CB33 RID: 52019 RVA: 0x0036333D File Offset: 0x0036153D
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.ExploreLevelRewardView)
		{
			return;
		}
		this.SetPausePlayProgressBar(true);
	}

	// Token: 0x0600CB34 RID: 52020 RVA: 0x00363354 File Offset: 0x00361554
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName != EUiViewName.ExploreLevelRewardView)
		{
			return;
		}
		this.SetPausePlayProgressBar(false);
	}

	// Token: 0x0600CB35 RID: 52021 RVA: 0x0036336C File Offset: 0x0036156C
	private ILayoutItem<CommonItemSmallItemGrid> OnCreateRewardItemGrid(object rawData, UUIItem uiItem, int index)
	{
		ValueTuple<int, int> valueTuple = (ValueTuple<int, int>)rawData;
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.Initialize(uiItem.GetOwner());
		commonItemSmallItemGrid.RefreshByConfigId(valueTuple.Item1, new int?(valueTuple.Item2), null, false, false);
		return new LayoutItem<CommonItemSmallItemGrid>
		{
			Key = index,
			Value = commonItemSmallItemGrid
		};
	}

	// Token: 0x0600CB36 RID: 52022 RVA: 0x003633C4 File Offset: 0x003615C4
	private ExploreLevelItem OnCreateExploreLevelItem()
	{
		ExploreLevelItem exploreLevelItem = new ExploreLevelItem();
		exploreLevelItem.BindOnClickedReceiveButton(new Action<CountryExploreScoreData>(this.OnClickedReceiveButton));
		return exploreLevelItem;
	}

	// Token: 0x0600CB37 RID: 52023 RVA: 0x003633E0 File Offset: 0x003615E0
	private void OnClickedReceiveButton(CountryExploreScoreData countryExploreScoreData)
	{
		ExploreLevelView.<>c__DisplayClass35_0 CS$<>8__locals1 = new ExploreLevelView.<>c__DisplayClass35_0();
		CS$<>8__locals1.countryExploreScoreData = countryExploreScoreData;
		CS$<>8__locals1.<>4__this = this;
		List<CountryExploreScoreData> visibleExploreScoreDataList = this.CountryExploreLevelData.GetVisibleExploreScoreDataList();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (CountryExploreScoreData countryExploreScoreData2 in visibleExploreScoreDataList)
		{
			if (countryExploreScoreData2.CanReceive())
			{
				dictionary[countryExploreScoreData2.AreaId] = countryExploreScoreData2.Progress;
			}
		}
		ControllerBase<ExploreLevelController>.Instance.MultiExploreScoreRewardRequest(dictionary);
		ControllerBase<ExploreLevelController>.Instance.CountryExploreScoreInfoRequest(CS$<>8__locals1.countryExploreScoreData.CountryId, new Action(CS$<>8__locals1.<OnClickedReceiveButton>g__OnCountryExploreScoreInfoResponse|0));
	}

	// Token: 0x0600CB38 RID: 52024 RVA: 0x00363494 File Offset: 0x00361694
	private void OnClickRewardPreviewButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ExploreLevelPreviewView, this.CountryExploreLevelData, delegate(bool success, int viewId)
		{
			if (!success)
			{
				return;
			}
			base.AddChildViewById(viewId);
		});
	}

	// Token: 0x0600CB39 RID: 52025 RVA: 0x003634B7 File Offset: 0x003616B7
	private void RefreshScoreDisplay()
	{
		this.RefreshLevelText();
		this.RefreshScoreTexture();
		this.RefreshRewardScrollView();
	}

	// Token: 0x0600CB3A RID: 52026 RVA: 0x003634CC File Offset: 0x003616CC
	private void RefreshLevelText()
	{
		string scoreNameId = this.CurrentExploreLevelRewardData.GetScoreNameId();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), scoreNameId, Array.Empty<object>());
	}

	// Token: 0x0600CB3B RID: 52027 RVA: 0x00363500 File Offset: 0x00361700
	private void RefreshScoreTexture()
	{
		string scoreTexturePath = this.CurrentExploreLevelRewardData.GetScoreTexturePath();
		UUITexture texture = base.GetTexture(1);
		base.SetTextureByPath(scoreTexturePath, texture, null, null);
	}

	// Token: 0x0600CB3C RID: 52028 RVA: 0x00363534 File Offset: 0x00361734
	private void RefreshScoreProgress()
	{
		int maxExploreScore = this.CurrentExploreLevelRewardData.GetMaxExploreScore();
		if (maxExploreScore <= 0)
		{
			base.GetItem(11).SetUIActive(false);
			return;
		}
		int exploreScore = this.CountryExploreLevelData.GetExploreScore();
		this.SetExploreScoreDisplay(exploreScore, maxExploreScore);
		base.SetTextureByPath(ModelBase<ExploreLevelModel>.Instance.ExploreScoreItemTexturePath, base.GetTexture(3), null, null);
		base.GetItem(11).SetUIActive(true);
	}

	// Token: 0x0600CB3D RID: 52029 RVA: 0x003635A4 File Offset: 0x003617A4
	private void SetExploreScoreDisplay(int exploreScore, int maxExploreScore)
	{
		int num = Math.Min(maxExploreScore, exploreScore);
		base.GetSprite(2).SetFillAmount((float)num / (float)maxExploreScore);
		UUIText text = base.GetText(4);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(maxExploreScore);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600CB3E RID: 52030 RVA: 0x00363608 File Offset: 0x00361808
	private void RefreshRewardScrollView()
	{
		CountryExploreLevelRewardData exploreLevelRewardData = this.CountryExploreLevelData.GetExploreLevelRewardData(this.CurrentExploreLevelRewardData.GetExploreLevel() + 1);
		if (exploreLevelRewardData == null)
		{
			GenericScrollView<CommonItemSmallItemGrid> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView != null)
			{
				rewardScrollView.ClearChildren();
			}
			GenericScrollView<CommonItemSmallItemGrid> rewardScrollView2 = this.RewardScrollView;
			if (rewardScrollView2 != null)
			{
				rewardScrollView2.SetActive(false);
			}
			base.GetItem(13).SetUIActive(true);
			return;
		}
		Dictionary<int, int> dropItemNumMap = exploreLevelRewardData.GetDropItemNumMap();
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		if (dropItemNumMap != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dropItemNumMap)
			{
				list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
			}
		}
		GenericScrollView<CommonItemSmallItemGrid> rewardScrollView3 = this.RewardScrollView;
		if (rewardScrollView3 != null)
		{
			rewardScrollView3.RefreshByData<ValueTuple<int, int>>(list, null);
		}
		base.GetItem(13).SetUIActive(false);
	}

	// Token: 0x0600CB3F RID: 52031 RVA: 0x003636F4 File Offset: 0x003618F4
	private void RefreshExploreLevelItemScrollView()
	{
		List<CountryExploreScoreData> visibleExploreScoreDataList = this.CountryExploreLevelData.GetVisibleExploreScoreDataList();
		visibleExploreScoreDataList.Sort(delegate(CountryExploreScoreData a, CountryExploreScoreData b)
		{
			int num = (a.GetIsReceived() > false) ? 1 : 0;
			int num2 = (b.GetIsReceived() > false) ? 1 : 0;
			if (num != num2)
			{
				return num.CompareTo(num2);
			}
			int num3 = a.CanReceive() ? -1 : 0;
			int num4 = b.CanReceive() ? -1 : 0;
			if (num3 != num4)
			{
				return num3.CompareTo(num4);
			}
			if (a.AreaId != b.AreaId)
			{
				return a.AreaId.CompareTo(b.AreaId);
			}
			if (a.Progress != b.Progress)
			{
				return a.Progress.CompareTo(b.Progress);
			}
			return 0;
		});
		LoopScrollView<ExploreLevelItem, CountryExploreScoreData> exploreLevelItemScrollView = this.ExploreLevelItemScrollView;
		if (exploreLevelItemScrollView == null)
		{
			return;
		}
		exploreLevelItemScrollView.ReloadData(visibleExploreScoreDataList, false);
	}

	// Token: 0x04006120 RID: 24864
	private const int PLAY_PROGRESS_BAR_TIME = 300;

	// Token: 0x04006121 RID: 24865
	[Nullable(2)]
	private CountryExploreLevelData CountryExploreLevelData;

	// Token: 0x04006122 RID: 24866
	[Nullable(2)]
	private CountryExploreLevelRewardData CurrentExploreLevelRewardData;

	// Token: 0x04006123 RID: 24867
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<CommonItemSmallItemGrid> RewardScrollView;

	// Token: 0x04006124 RID: 24868
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ExploreLevelItem, CountryExploreScoreData> ExploreLevelItemScrollView;

	// Token: 0x04006125 RID: 24869
	private int CurrentExploreScore;

	// Token: 0x04006126 RID: 24870
	private int CurrentMaxExploreScore;

	// Token: 0x04006127 RID: 24871
	private int AnimationCurrentExploreScore;

	// Token: 0x04006128 RID: 24872
	private int AnimationCurrentMaxExploreScore;

	// Token: 0x04006129 RID: 24873
	private int AnimationTargetExploreScore;

	// Token: 0x0400612A RID: 24874
	private int AnimationTargetMaxExploreScore;

	// Token: 0x0400612B RID: 24875
	private float AnimationCurrentAnimationTime;

	// Token: 0x0400612C RID: 24876
	private bool IsProgressBarPlaying;

	// Token: 0x0400612D RID: 24877
	private bool IsPausePlayProgressBar;

	// Token: 0x02007E52 RID: 32338
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B08C RID: 176268
		CountryNameText,
		// Token: 0x0402B08D RID: 176269
		ScoreTexture,
		// Token: 0x0402B08E RID: 176270
		ScoreProgressBarSprite,
		// Token: 0x0402B08F RID: 176271
		ScoreItemTexture,
		// Token: 0x0402B090 RID: 176272
		ScoreCostText,
		// Token: 0x0402B091 RID: 176273
		ScoreRewardScrollViewWithScrollBar,
		// Token: 0x0402B092 RID: 176274
		RewardPreviewButton,
		// Token: 0x0402B093 RID: 176275
		ExploreProgressText,
		// Token: 0x0402B094 RID: 176276
		ScoreItemLoopScrollView,
		// Token: 0x0402B095 RID: 176277
		SourceExploreLevelItem,
		// Token: 0x0402B096 RID: 176278
		CloseButton,
		// Token: 0x0402B097 RID: 176279
		ExpItem,
		// Token: 0x0402B098 RID: 176280
		LevelText,
		// Token: 0x0402B099 RID: 176281
		DoneItem,
		// Token: 0x0402B09A RID: 176282
		GetExpNiagara
	}
}
