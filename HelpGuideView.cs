using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001EC1 RID: 7873
[NullableContext(1)]
[Nullable(0)]
public class HelpGuideView : UiViewBase
{
	// Token: 0x0600E8A9 RID: 59561 RVA: 0x003EE9AD File Offset: 0x003ECBAD
	public HelpGuideView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E8AA RID: 59562 RVA: 0x003EE9C4 File Offset: 0x003ECBC4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnCloseClick)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnCloseClick)),
			new ValueTuple<int, Delegate>(7, new Action(this.PrePage)),
			new ValueTuple<int, Delegate>(8, new Action(this.NextPage))
		};
	}

	// Token: 0x0600E8AB RID: 59563 RVA: 0x003EEB98 File Offset: 0x003ECD98
	private void OnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E8AC RID: 59564 RVA: 0x003EEBA4 File Offset: 0x003ECDA4
	private void PrePage()
	{
		if (this.MoveTween == null && this.NowPage > 0)
		{
			UUIItem rootItem = this.CurrentShowPanel.GetRootItem();
			FVector relativeLocation = rootItem.RelativeLocation;
			UUIItem item = base.GetItem(12);
			item.SetUIRelativeLocation(new FVector(-item.Width, item.RelativeLocation.Y, item.RelativeLocation.Z));
			this.SwitchPanelAnim();
			this.LastShowPanel.GetRootItem().SetUIRelativeLocation(new FVector(rootItem.Width, relativeLocation.Y, relativeLocation.Z));
			this.RefreshView(this.NowPage - 1);
			this.MoveTween = ULTweenBPLibrary.LocalPositionXTo(item, 0f, 0.3f, 0f, LTweenEase.InOutCubic);
			this.MoveTween.OnCompleteCallBack.Bind(delegate()
			{
				this.MoveTween = null;
			});
		}
	}

	// Token: 0x0600E8AD RID: 59565 RVA: 0x003EEC80 File Offset: 0x003ECE80
	private void NextPage()
	{
		if (this.MoveTween == null && this.NowPage < this.PageArray.Count - 1)
		{
			UUIItem rootItem = this.CurrentShowPanel.GetRootItem();
			FVector relativeLocation = rootItem.RelativeLocation;
			UUIItem item = base.GetItem(12);
			item.SetUIRelativeLocation(new FVector(item.Width, item.RelativeLocation.Y, item.RelativeLocation.Z));
			this.SwitchPanelAnim();
			this.LastShowPanel.GetRootItem().SetUIRelativeLocation(new FVector(-rootItem.Width, relativeLocation.Y, relativeLocation.Z));
			this.RefreshView(this.NowPage + 1);
			this.MoveTween = ULTweenBPLibrary.LocalPositionXTo(item, 0f, 0.3f, 0f, LTweenEase.InOutCubic);
			this.MoveTween.OnCompleteCallBack.Bind(delegate()
			{
				this.MoveTween = null;
			});
		}
	}

	// Token: 0x0600E8AE RID: 59566 RVA: 0x003EED67 File Offset: 0x003ECF67
	protected override void OnBeforeDestroy()
	{
		if (this.PageDotLayout != null)
		{
			this.PageDotLayout.ClearChildren();
			this.PageDotLayout = null;
		}
		if (this.MoveTween != null)
		{
			this.MoveTween.Kill(false);
			this.MoveTween = null;
		}
	}

	// Token: 0x0600E8AF RID: 59567 RVA: 0x003EEDA0 File Offset: 0x003ECFA0
	private ILayoutItem<TutorialPageItem> InitDetail(object data, UUIItem uiItem, int index)
	{
		TutorialPageItem tutorialPageItem = new TutorialPageItem(uiItem);
		tutorialPageItem.Init();
		tutorialPageItem.UpdateShow(false);
		return new LayoutItem<TutorialPageItem>
		{
			Key = index,
			Value = tutorialPageItem
		};
	}

	// Token: 0x0600E8B0 RID: 59568 RVA: 0x003EEDDB File Offset: 0x003ECFDB
	private void SwitchPanelAnim()
	{
		this.LastShowPanel.SetUiActive(true);
		this.CurrentShowPanel.PlayAnime(true);
		this.LastShowPanel.PlayAnime(false);
	}

	// Token: 0x0600E8B1 RID: 59569 RVA: 0x003EEE04 File Offset: 0x003ED004
	protected override UniTask OnBeforeStartAsync()
	{
		HelpGuideView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HelpGuideView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E8B2 RID: 59570 RVA: 0x003EEE48 File Offset: 0x003ED048
	protected override void OnStart()
	{
		this.RefreshView(0);
		base.GetItem(14).SetUIActive(false);
		base.GetButton(13).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600E8B3 RID: 59571 RVA: 0x003EEE88 File Offset: 0x003ED088
	protected override void OnBeforeShow()
	{
		this.UiViewSequence.PlaySequence("StartAtOnce", false, null);
		base.GetItem(10).SetUIActive(true);
		base.GetItem(11).SetUIActive(true);
		base.GetItem(9).SetUIActive(false);
	}

	// Token: 0x0600E8B4 RID: 59572 RVA: 0x003EEEDC File Offset: 0x003ED0DC
	private void RefreshView(int index)
	{
		if (this.PageArray.Count > 1)
		{
			this.PageDotLayout.GetLayoutItemByIndex(this.NowPage).UpdateShow(false);
			this.PageDotLayout.GetLayoutItemByIndex(index).UpdateShow(true);
			base.GetButton(7).SetSelfInteractive(index > 0);
			base.GetButton(8).SetSelfInteractive(index < this.PageArray.Count - 1);
			if (this.LastShowPanel != null)
			{
				HelpText value = this.PageArray[this.NowPage];
				this.LastShowPanel.RefreshPage(new HelpText?(value));
			}
		}
		this.NowPage = index;
		HelpText value2 = this.PageArray[this.NowPage];
		this.CurrentShowPanel.RefreshPage(new HelpText?(value2));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value2.Title, Array.Empty<object>());
	}

	// Token: 0x04007015 RID: 28693
	private const float TWEEN_TIME = 0.3f;

	// Token: 0x04007016 RID: 28694
	protected int HelpGroupId;

	// Token: 0x04007017 RID: 28695
	private IReadOnlyList<HelpText> PageArray = new List<HelpText>();

	// Token: 0x04007018 RID: 28696
	private int NowPage;

	// Token: 0x04007019 RID: 28697
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TutorialPageItem> PageDotLayout;

	// Token: 0x0400701A RID: 28698
	[Nullable(2)]
	private HelpGuidePage CurrentShowPanel;

	// Token: 0x0400701B RID: 28699
	[Nullable(2)]
	private HelpGuidePage LastShowPanel;

	// Token: 0x0400701C RID: 28700
	[Nullable(2)]
	private ULTweener MoveTween;

	// Token: 0x02008203 RID: 33283
	[NullableContext(0)]
	public enum ETutorialsPopupComponents
	{
		// Token: 0x0402C19B RID: 180635
		SprIcon,
		// Token: 0x0402C19C RID: 180636
		TxtTitle,
		// Token: 0x0402C19D RID: 180637
		BtnBack,
		// Token: 0x0402C19E RID: 180638
		PnlMid,
		// Token: 0x0402C19F RID: 180639
		PnlBottom,
		// Token: 0x0402C1A0 RID: 180640
		PnlPages,
		// Token: 0x0402C1A1 RID: 180641
		UiItemPagesDot,
		// Token: 0x0402C1A2 RID: 180642
		BtnArrowL,
		// Token: 0x0402C1A3 RID: 180643
		BtnArrowR,
		// Token: 0x0402C1A4 RID: 180644
		UiItemTutorialsTps,
		// Token: 0x0402C1A5 RID: 180645
		UiItemLayerBg,
		// Token: 0x0402C1A6 RID: 180646
		UiItemLayerUi,
		// Token: 0x0402C1A7 RID: 180647
		PageParent,
		// Token: 0x0402C1A8 RID: 180648
		BtnBg,
		// Token: 0x0402C1A9 RID: 180649
		TipReadAll
	}
}
