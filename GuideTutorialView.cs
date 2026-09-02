using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Guide.GroupInfo;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E33 RID: 7731
[NullableContext(2)]
[Nullable(0)]
public class GuideTutorialView : UiViewBase
{
	// Token: 0x0600E4CA RID: 58570 RVA: 0x003DBBC2 File Offset: 0x003D9DC2
	[NullableContext(1)]
	public GuideTutorialView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E4CB RID: 58571 RVA: 0x003DBBD4 File Offset: 0x003D9DD4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnCloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnCloseClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.PrePage));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.NextPage));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600E4CC RID: 58572 RVA: 0x003DBE98 File Offset: 0x003DA098
	private void PrePage()
	{
		if (this.MoveTween == null && this.NowPage > 0)
		{
			UUIItem rootItem = this.CurrentShowPanel.GetRootItem();
			FVector relativeLocation = rootItem.RelativeLocation;
			UUIItem item = base.GetItem(12);
			item.SetUIRelativeLocation(new FVector(-item.Width, item.RelativeLocation.Y, item.RelativeLocation.Z));
			this.InitLastPanel();
			this.LastShowPanel.GetRootItem().SetUIRelativeLocation(new FVector(rootItem.Width, relativeLocation.Y, relativeLocation.Z));
			this.RefreshView(this.NowPage - 1);
			this.MoveTween = ULTweenBPLibrary.LocalPositionXTo(item, 0f, 0.3f, 0f, LTweenEase.InOutCubic);
			this.MoveTween.OnCompleteCallBack.Bind(delegate()
			{
				this.MoveTween = null;
			});
		}
	}

	// Token: 0x0600E4CD RID: 58573 RVA: 0x003DBF74 File Offset: 0x003DA174
	private void NextPage()
	{
		if (this.MoveTween == null && this.NowPage < this.PageArray.Length - 1)
		{
			UUIItem rootItem = this.CurrentShowPanel.GetRootItem();
			FVector relativeLocation = rootItem.RelativeLocation;
			UUIItem item = base.GetItem(12);
			item.SetUIRelativeLocation(new FVector(item.Width, item.RelativeLocation.Y, item.RelativeLocation.Z));
			this.InitLastPanel();
			this.LastShowPanel.GetRootItem().SetUIRelativeLocation(new FVector(-rootItem.Width, relativeLocation.Y, relativeLocation.Z));
			this.RefreshView(this.NowPage + 1);
			this.MoveTween = ULTweenBPLibrary.LocalPositionXTo(item, 0f, 0.3f, 0f, LTweenEase.InOutCubic);
			this.MoveTween.OnCompleteCallBack.Bind(delegate()
			{
				this.MoveTween = null;
			});
		}
	}

	// Token: 0x0600E4CE RID: 58574 RVA: 0x003DC058 File Offset: 0x003DA258
	protected override void OnBeforeHide()
	{
		TutorialListInfo tutorialInfo = this.TutorialInfo;
		if (tutorialInfo == null)
		{
			return;
		}
		GuideStepInfo ownerStep = tutorialInfo.OwnerStep;
		if (ownerStep == null)
		{
			return;
		}
		GuideGroupInfo ownerGroup = ownerStep.OwnerGroup;
		if (ownerGroup == null)
		{
			return;
		}
		CustomPromise finishPromise = ownerGroup.FinishPromise;
		if (finishPromise == null)
		{
			return;
		}
		finishPromise.SetResult();
	}

	// Token: 0x0600E4CF RID: 58575 RVA: 0x003DC088 File Offset: 0x003DA288
	protected override void OnBeforeDestroy()
	{
		GenericLayoutNew<TutorialPageItem> pageDotLayout = this.PageDotLayout;
		if (pageDotLayout != null)
		{
			pageDotLayout.ClearChildren();
		}
		this.PageDotLayout = null;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		if (this.TutorialInfo != null)
		{
			ModelBase<GuideModel>.Instance.ClipTipState();
			ModelBase<GuideModel>.Instance.RemoveCurrentTutorialInfo();
			ModelBase<GuideModel>.Instance.TryShowTutorial();
		}
		ControllerBase<TutorialController>.Instance.TryOpenAwardUiViewPending();
		GuideTutorialPagePanel currentShowPanel = this.CurrentShowPanel;
		if (currentShowPanel != null)
		{
			currentShowPanel.Destroy(null);
		}
		this.CurrentShowPanel = null;
		GuideTutorialPagePanel lastShowPanel = this.LastShowPanel;
		if (lastShowPanel != null)
		{
			lastShowPanel.Destroy(null);
		}
		this.LastShowPanel = null;
		ULTweener moveTween = this.MoveTween;
		if (moveTween != null)
		{
			moveTween.Kill(false);
		}
		this.MoveTween = null;
	}

	// Token: 0x0600E4D0 RID: 58576 RVA: 0x003DC140 File Offset: 0x003DA340
	[NullableContext(1)]
	private ILayoutItem<TutorialPageItem> InitDetail(object tempData, UUIItem uiItem, int index)
	{
		int num = (int)tempData;
		TutorialPageItem tutorialPageItem = new TutorialPageItem(uiItem);
		tutorialPageItem.Init();
		tutorialPageItem.UpdateShow(false);
		return new LayoutItem<TutorialPageItem>
		{
			Key = index,
			Value = tutorialPageItem
		};
	}

	// Token: 0x0600E4D1 RID: 58577 RVA: 0x003DC184 File Offset: 0x003DA384
	[NullableContext(1)]
	private void FinishSequenceEvent(string sequenceName)
	{
		if (sequenceName == "Start".ToString())
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
			return;
		}
		if (sequenceName == "Close".ToString())
		{
			this.PlayAtOnce();
		}
	}

	// Token: 0x0600E4D2 RID: 58578 RVA: 0x003DC1D8 File Offset: 0x003DA3D8
	private void PlayTip()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", true, null, false);
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		base.GetItem(9).SetUIActive(true);
	}

	// Token: 0x0600E4D3 RID: 58579 RVA: 0x003DC22C File Offset: 0x003DA42C
	private void PlayAtOnce()
	{
		this.UiViewSequence.PlaySequence("StartAtOnce", true, null);
		base.GetItem(10).SetUIActive(true);
		base.GetItem(11).SetUIActive(true);
		base.GetItem(9).SetUIActive(false);
	}

	// Token: 0x0600E4D4 RID: 58580 RVA: 0x003DC280 File Offset: 0x003DA480
	private void InitLastPanel()
	{
		if (this.LastShowPanel == null)
		{
			UUIItem uiItem = Singleton<LguiUtil>.Instance.CopyItem(base.GetItem(3), base.GetItem(12));
			this.LastShowPanel = new GuideTutorialPagePanel();
			this.LastShowPanel.Init(uiItem);
		}
		this.CurrentShowPanel.PlayAnime(true);
		this.LastShowPanel.PlayAnime(false);
	}

	// Token: 0x0600E4D5 RID: 58581 RVA: 0x003DC2E0 File Offset: 0x003DA4E0
	protected override UniTask OnBeforeStartAsync()
	{
		GuideTutorialView.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GuideTutorialView.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E4D6 RID: 58582 RVA: 0x003DC324 File Offset: 0x003DA524
	protected override void OnStart()
	{
		this.TutorialInfo = (this.OpenParam as TutorialListInfo);
		this.PageDotLayout = new GenericLayoutNew<TutorialPageItem>(base.GetHorizontalLayout(5), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TutorialPageItem>(this.InitDetail), base.GetItem(6));
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(9));
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
		this.PageArray = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPageIds(this.TutorialInfo.GuideId);
		this.TryRemoveTutorialRedDot();
		if (this.PageArray.Length <= 1)
		{
			base.GetButton(7).RootUIComp.Get().SetUIActive(false);
			base.GetButton(8).RootUIComp.Get().SetUIActive(false);
			base.GetItem(4).SetUIActive(false);
		}
		else
		{
			base.GetButton(7).RootUIComp.Get().SetUIActive(true);
			base.GetButton(8).RootUIComp.Get().SetUIActive(true);
			base.GetItem(4).SetUIActive(true);
			this.PageDotLayout.RebuildLayoutByDataNew<int>(this.PageArray, null);
		}
		this.RequireReadAll = true;
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
		base.GetItem(14).SetUIActive(true);
		this.RefreshView(0);
	}

	// Token: 0x0600E4D7 RID: 58583 RVA: 0x003DC4AD File Offset: 0x003DA6AD
	protected override void OnBeforeShow()
	{
		if (this.TutorialInfo.TutorialTip)
		{
			this.PlayAtOnce();
			return;
		}
		this.PlayTip();
	}

	// Token: 0x0600E4D8 RID: 58584 RVA: 0x003DC4CC File Offset: 0x003DA6CC
	private void RefreshView(int index)
	{
		if (this.PageArray.Length > 1)
		{
			this.PageDotLayout.GetLayoutItemByIndex(this.NowPage).UpdateShow(false);
			this.PageDotLayout.GetLayoutItemByIndex(index).UpdateShow(true);
			base.GetButton(7).SetSelfInteractive(index > 0);
			base.GetButton(8).SetSelfInteractive(index < this.PageArray.Length - 1);
			if (this.LastShowPanel != null)
			{
				GuideTutorialPage? guideTutorialPage = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPage(this.PageArray[this.NowPage]);
				this.LastShowPanel.RefreshPage(guideTutorialPage);
			}
		}
		this.NowPage = index;
		if (this.NowPage == this.PageArray.Length - 1)
		{
			base.GetButton(2).RootUIComp.Get().SetUIActive(true);
			base.GetButton(13).RootUIComp.Get().SetUIActive(true);
			this.HasReadToEnd = true;
		}
		base.GetItem(14).SetUIActive(!this.HasReadToEnd && this.RequireReadAll);
		GuideTutorialPage? guideTutorialPage2 = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPage(this.PageArray[this.NowPage]);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), guideTutorialPage2.Value.Title, Array.Empty<object>());
		this.CurrentShowPanel.RefreshPage(guideTutorialPage2);
	}

	// Token: 0x0600E4D9 RID: 58585 RVA: 0x003DC620 File Offset: 0x003DA820
	private void TryRemoveTutorialRedDot()
	{
		TutorialSaveData savedDataById = ModelBase<TutorialModel>.Instance.GetSavedDataById(this.TutorialInfo.GuideId);
		if (savedDataById != null && savedDataById.HasRedDot)
		{
			ControllerBase<TutorialController>.Instance.RemoveRedDotTutorialId(savedDataById.TutorialId);
		}
	}

	// Token: 0x0600E4DA RID: 58586 RVA: 0x003DC65E File Offset: 0x003DA85E
	private void OnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x04006DFF RID: 28159
	private const float TWEEN_TIME = 0.3f;

	// Token: 0x04006E00 RID: 28160
	public TutorialListInfo TutorialInfo;

	// Token: 0x04006E01 RID: 28161
	public bool IsPopView = true;

	// Token: 0x04006E02 RID: 28162
	private int[] PageArray;

	// Token: 0x04006E03 RID: 28163
	private int NowPage;

	// Token: 0x04006E04 RID: 28164
	private bool HasReadToEnd;

	// Token: 0x04006E05 RID: 28165
	private bool RequireReadAll;

	// Token: 0x04006E06 RID: 28166
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TutorialPageItem> PageDotLayout;

	// Token: 0x04006E07 RID: 28167
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04006E08 RID: 28168
	private GuideTutorialPagePanel CurrentShowPanel;

	// Token: 0x04006E09 RID: 28169
	private GuideTutorialPagePanel LastShowPanel;

	// Token: 0x04006E0A RID: 28170
	private ULTweener MoveTween;

	// Token: 0x020081A5 RID: 33189
	[NullableContext(0)]
	public enum ETutorialsPopupComponents
	{
		// Token: 0x0402C01D RID: 180253
		SprIcon,
		// Token: 0x0402C01E RID: 180254
		TxtTitle,
		// Token: 0x0402C01F RID: 180255
		BtnBack,
		// Token: 0x0402C020 RID: 180256
		PnlMid,
		// Token: 0x0402C021 RID: 180257
		PnlBottom,
		// Token: 0x0402C022 RID: 180258
		PnlPages,
		// Token: 0x0402C023 RID: 180259
		UiItemPagesDot,
		// Token: 0x0402C024 RID: 180260
		BtnArrowL,
		// Token: 0x0402C025 RID: 180261
		BtnArrowR,
		// Token: 0x0402C026 RID: 180262
		UiItemTutorialsTps,
		// Token: 0x0402C027 RID: 180263
		UiItemLayerBg,
		// Token: 0x0402C028 RID: 180264
		UiItemLayerUi,
		// Token: 0x0402C029 RID: 180265
		PageParent,
		// Token: 0x0402C02A RID: 180266
		BtnBg,
		// Token: 0x0402C02B RID: 180267
		TipReadAll
	}
}
