using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C2D RID: 11309
[NullableContext(1)]
[Nullable(0)]
public class TutorialView : UiViewBase
{
	// Token: 0x06016A12 RID: 92690 RVA: 0x006478FD File Offset: 0x00645AFD
	public TutorialView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016A13 RID: 92691 RVA: 0x00647918 File Offset: 0x00645B18
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(14, new Action(this.OnClickBtnLast)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnClickBtnNext))
		};
	}

	// Token: 0x06016A14 RID: 92692 RVA: 0x00647AD4 File Offset: 0x00645CD4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotNewTutorial, new Action<int>(this.OnTutortialRedUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnTutorialUpdate, new Action(this.OnTutorialUpdate));
	}

	// Token: 0x06016A15 RID: 92693 RVA: 0x00647B0E File Offset: 0x00645D0E
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotNewTutorial, new Action<int>(this.OnTutortialRedUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTutorialUpdate, new Action(this.OnTutorialUpdate));
	}

	// Token: 0x06016A16 RID: 92694 RVA: 0x00647B48 File Offset: 0x00645D48
	private void SearchResult(string content)
	{
		ValueTuple<List<TutorialItemData>, bool> valueTuple = ModelBase<TutorialModel>.Instance.MakeSearchList(content, this.CurrentSelectType, this.ExclusiveType);
		List<TutorialItemData> item = valueTuple.Item1;
		base.GetItem(5).SetUIActive(item.Count == 0);
		if (item.Count == 0)
		{
			this.HideDetaildView();
		}
		if (!valueTuple.Item2)
		{
			ETutorialType? currentSelectType = this.CurrentSelectType;
			ETutorialType etutorialType = ETutorialType.All;
			if (!(currentSelectType.GetValueOrDefault() == etutorialType & currentSelectType != null))
			{
				this.HideDetaildView();
			}
		}
		this.ItemScrollView.RefreshByData(item.ToArray(), false, false);
	}

	// Token: 0x06016A17 RID: 92695 RVA: 0x00647BD3 File Offset: 0x00645DD3
	private void ResetSearch()
	{
		this.OnTypeToggleSelected((int)this.CurrentSelectType.Value);
		base.GetItem(4).SetUIActive(true);
	}

	// Token: 0x06016A18 RID: 92696 RVA: 0x00647BF4 File Offset: 0x00645DF4
	protected override UniTask OnBeforeStartAsync()
	{
		TutorialView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TutorialView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016A19 RID: 92697 RVA: 0x00647C38 File Offset: 0x00645E38
	protected override void OnStart()
	{
		ITutorialViewParam tutorialViewParam = this.OpenParam as ITutorialViewParam;
		this.ExclusiveType = ((tutorialViewParam != null) ? tutorialViewParam.ExclusiveType : null).GetValueOrDefault();
		ModelBase<TutorialModel>.Instance.CurrentExclusiveType = this.ExclusiveType;
		base.GetItem(3).SetUIActive(false);
		foreach (object obj in Enum.GetValues(typeof(ETutorialType)))
		{
			int num = (int)obj;
			if (!double.IsNaN((double)num))
			{
				this.TypeList.Add(num);
			}
		}
		if (this.ExclusiveType != EExclusiveTutorialType.None)
		{
			this.TypeList.Clear();
			this.TypeList.Add(0);
			Singleton<EventSystem>.Instance.Emit<ETutorialType>(EEventName.RedDotNewTutorialType, ETutorialType.All);
		}
		this.SearchComponent = new CommonSearchComponent(base.GetItem(1), new Action<string>(this.SearchResult), new Action(this.ResetSearch));
		CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.OnTypeToggleSelected), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), data, new Action(this.OnCloseClick), false);
		this.PageDotLayout = new GenericLayoutNew<TutorialPageItem>(base.GetHorizontalLayout(12), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TutorialPageItem>(this.InitDetail), base.GetItem(13));
		this.HideDetaildView();
	}

	// Token: 0x06016A1A RID: 92698 RVA: 0x00647DCC File Offset: 0x00645FCC
	private ILayoutItem<TutorialPageItem> InitDetail(object data, UUIItem UUIItem, int index)
	{
		TutorialPageItem tutorialPageItem = new TutorialPageItem(UUIItem);
		tutorialPageItem.Init();
		tutorialPageItem.UpdateShow(false);
		return new LayoutItem<TutorialPageItem>
		{
			Key = index,
			Value = tutorialPageItem
		};
	}

	// Token: 0x06016A1B RID: 92699 RVA: 0x00647E07 File Offset: 0x00646007
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem UUIItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x06016A1C RID: 92700 RVA: 0x00647E10 File Offset: 0x00646010
	private void OnTypeToggleSelected(int index)
	{
		int num = this.TypeList[index];
		this.CurrentSelectType = new ETutorialType?((ETutorialType)num);
		this.SearchComponent.ResetSearch(true);
		List<TutorialItemData> unlockedTutorialDataByType = ModelBase<TutorialModel>.Instance.GetUnlockedTutorialDataByType((ETutorialType)num, this.ExclusiveType);
		int selectItemIndex = -1;
		if (this.RefreshTargetTutorialId > -1)
		{
			selectItemIndex = unlockedTutorialDataByType.FindIndex(delegate(TutorialItemData x)
			{
				TutorialSaveData savedData = x.SavedData;
				int? num2 = (savedData != null) ? new int?(savedData.TutorialId) : null;
				int refreshTargetTutorialId = this.RefreshTargetTutorialId;
				return num2.GetValueOrDefault() == refreshTargetTutorialId & num2 != null;
			});
			this.RefreshTargetTutorialId = -1;
			if (selectItemIndex > -1)
			{
				unlockedTutorialDataByType[selectItemIndex].Selected = new bool?(true);
			}
			else
			{
				unlockedTutorialDataByType[0].Selected = new bool?(true);
			}
		}
		else if (unlockedTutorialDataByType.Count > 0)
		{
			unlockedTutorialDataByType[0].Selected = new bool?(true);
		}
		this.ItemScrollView.RefreshByData(unlockedTutorialDataByType.ToArray(), false, false);
		if (unlockedTutorialDataByType.Count == 0)
		{
			this.HideDetaildView();
		}
		else if (selectItemIndex > -1)
		{
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				DynamicScrollView<TutorialDataItem, TutorialDynItem, TutorialItemData> itemScrollView = this.ItemScrollView;
				if (itemScrollView == null)
				{
					return;
				}
				itemScrollView.ScrollToItemIndex(selectItemIndex, true, false);
			}, null, null);
		}
		base.GetItem(5).SetUIActive(unlockedTutorialDataByType.Count == 0);
		this.SearchComponent.SetActive(unlockedTutorialDataByType.Count > 0);
		this.UiViewSequence.PlaySequence("Switch", false, null);
		base.GetUIDynScrollViewComponent(2).RootUIComp.Get().SetUIActive(unlockedTutorialDataByType.Count > 0);
	}

	// Token: 0x06016A1D RID: 92701 RVA: 0x00647F8C File Offset: 0x0064618C
	public UniTask RefreshItemDetailWhenNeed(int selectItemIndex)
	{
		TutorialView.<RefreshItemDetailWhenNeed>d__24 <RefreshItemDetailWhenNeed>d__;
		<RefreshItemDetailWhenNeed>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItemDetailWhenNeed>d__.<>4__this = this;
		<RefreshItemDetailWhenNeed>d__.selectItemIndex = selectItemIndex;
		<RefreshItemDetailWhenNeed>d__.<>1__state = -1;
		<RefreshItemDetailWhenNeed>d__.<>t__builder.Start<TutorialView.<RefreshItemDetailWhenNeed>d__24>(ref <RefreshItemDetailWhenNeed>d__);
		return <RefreshItemDetailWhenNeed>d__.<>t__builder.Task;
	}

	// Token: 0x06016A1E RID: 92702 RVA: 0x00647FD7 File Offset: 0x006461D7
	private void HideDetaildView()
	{
		base.GetItem(4).SetUIActive(false);
		this.ItemData = null;
	}

	// Token: 0x06016A1F RID: 92703 RVA: 0x00647FF0 File Offset: 0x006461F0
	private CommonTabData GetCommonData(int index)
	{
		string tutorialTypeIconPath = TutorialUtils.GetTutorialTypeIconPath((ETutorialType)this.TypeList[index]);
		string tutorialTypeTxt = TutorialUtils.GetTutorialTypeTxt((ETutorialType)this.TypeList[index]);
		return new CommonTabData(tutorialTypeIconPath, new CommonTabTitleData(tutorialTypeTxt, Array.Empty<object>()), null);
	}

	// Token: 0x06016A20 RID: 92704 RVA: 0x00648034 File Offset: 0x00646234
	protected override void OnBeforeShow()
	{
		int count = this.TypeList.Count;
		List<CommonTabItemData> list = this.TabComponent.CreateTabItemDataByLength(count);
		for (int i = 0; i < count; i++)
		{
			int num = this.TypeList[i];
			if (num == 0)
			{
				list[i].RedDotName = new ERedDotName?(ERedDotName.TutorialTypeNew);
				list[i].RedDotUid = new int?(num);
			}
		}
		this.TabComponent.RefreshTabItem(list, new Action(this.AfterRefreshTabItem));
	}

	// Token: 0x06016A21 RID: 92705 RVA: 0x006480B4 File Offset: 0x006462B4
	private void AfterRefreshTabItem()
	{
		if (this.OpenParam == null)
		{
			this.TabComponent.SelectToggleByIndex(0, false);
			return;
		}
		ITutorialViewParam tutorialViewParam = this.OpenParam as ITutorialViewParam;
		int valueOrDefault = ((tutorialViewParam != null) ? tutorialViewParam.TutorialId : null).GetValueOrDefault();
		TutorialSaveData savedDataById = ModelBase<TutorialModel>.Instance.GetSavedDataById(valueOrDefault);
		if (savedDataById != null && savedDataById.TutorialData != null)
		{
			int tutorialType = savedDataById.TutorialData.Value.TutorialType;
			this.RefreshTargetTutorialId = valueOrDefault;
			this.TabComponent.SelectToggleByIndex(tutorialType, false);
			this.RefreshTargetTutorialId = -1;
			return;
		}
		this.TabComponent.SelectToggleByIndex(0, false);
	}

	// Token: 0x06016A22 RID: 92706 RVA: 0x00648164 File Offset: 0x00646364
	protected override void OnAfterHide()
	{
		this.ItemScrollView.ClearChildren();
		this.HideDetaildView();
		this.NowSelectedToggle = null;
	}

	// Token: 0x06016A23 RID: 92707 RVA: 0x00648180 File Offset: 0x00646380
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.PageDotLayout != null)
		{
			this.PageDotLayout.ClearChildren();
			this.PageDotLayout = null;
		}
		CommonSearchComponent searchComponent = this.SearchComponent;
		if (searchComponent != null)
		{
			searchComponent.Destroy(null);
		}
		DynamicScrollView<TutorialDataItem, TutorialDynItem, TutorialItemData> itemScrollView = this.ItemScrollView;
		if (itemScrollView != null)
		{
			itemScrollView.ClearChildren();
		}
		this.ItemScrollView = null;
		this.TypeList.Clear();
		if (this.IsOpenedByGuide)
		{
			GuideModel instance = ModelBase<GuideModel>.Instance;
			if (instance != null)
			{
				instance.ClipTipState();
			}
			GuideModel instance2 = ModelBase<GuideModel>.Instance;
			if (instance2 != null)
			{
				instance2.RemoveCurrentTutorialInfo();
			}
			GuideModel instance3 = ModelBase<GuideModel>.Instance;
			if (instance3 != null)
			{
				instance3.TryShowTutorial();
			}
			this.IsOpenedByGuide = false;
		}
		ControllerBase<TutorialController>.Instance.TryOpenAwardUiViewPending();
		ModelBase<TutorialModel>.Instance.CurrentExclusiveType = EExclusiveTutorialType.None;
	}

	// Token: 0x06016A24 RID: 92708 RVA: 0x0064824B File Offset: 0x0064644B
	private TutorialDataItem OnCreateTutorialItemView(TutorialItemData data, UUIItem UUIItem, int index)
	{
		TutorialDataItem tutorialDataItem = new TutorialDataItem();
		tutorialDataItem.InitData(data);
		tutorialDataItem.SetOnToggleSelected(new Action<TutorialItemData, UUIExtendToggle>(this.OnItemToggleSelected));
		return tutorialDataItem;
	}

	// Token: 0x06016A25 RID: 92709 RVA: 0x0064826C File Offset: 0x0064646C
	private void OnTutorialUpdate()
	{
		List<TutorialItemData> unlockedTutorialDataByType = ModelBase<TutorialModel>.Instance.GetUnlockedTutorialDataByType(this.CurrentSelectType.Value, this.ExclusiveType);
		for (int i = 0; i < unlockedTutorialDataByType.Count; i++)
		{
			unlockedTutorialDataByType[i].Selected = new bool?(i == 0);
		}
		this.ItemScrollView.RefreshByData(unlockedTutorialDataByType.ToArray(), false, false);
	}

	// Token: 0x06016A26 RID: 92710 RVA: 0x006482D0 File Offset: 0x006464D0
	private void OnTutortialRedUpdate(int i)
	{
		TutorialDataItem[] scrollItemItems = this.ItemScrollView.GetScrollItemItems();
		for (int j = 0; j < scrollItemItems.Length; j++)
		{
			scrollItemItems[j].RefreshRed();
		}
	}

	// Token: 0x06016A27 RID: 92711 RVA: 0x006482FF File Offset: 0x006464FF
	private void OnItemToggleSelected(TutorialItemData itemData, UUIExtendToggle toggle)
	{
		if (this.NowSelectedToggle != toggle)
		{
			UUIExtendToggle nowSelectedToggle = this.NowSelectedToggle;
			if (nowSelectedToggle != null)
			{
				nowSelectedToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.NowSelectedToggle = toggle;
		}
		base.GetItem(5).SetUIActive(false);
		this.UpdateView(itemData);
	}

	// Token: 0x06016A28 RID: 92712 RVA: 0x0064833C File Offset: 0x0064653C
	private void UpdateView(TutorialItemData itemData)
	{
		base.GetItem(4).SetUIActive(true);
		if (this.ItemData != itemData)
		{
			this.UiViewSequence.PlaySequence("SwitchPage", false, null);
		}
		if (this.ItemData != null)
		{
			this.ItemData.Selected = new bool?(false);
		}
		this.ItemData = itemData;
		this.ItemData.Selected = new bool?(true);
		this.CurrDisplayIndex = 0;
		if (this.ItemData.SavedData.HasRedDot)
		{
			ControllerBase<TutorialController>.Instance.RemoveRedDotTutorialId(this.ItemData.SavedData.TutorialId);
		}
		int[] guideTutorialPageIds = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPageIds(this.ItemData.SavedData.TutorialId);
		this.PageIds = guideTutorialPageIds.ToList<int>();
		if (guideTutorialPageIds.Length <= 1)
		{
			base.GetButton(14).RootUIComp.Get().SetUIActive(false);
			base.GetButton(15).RootUIComp.Get().SetUIActive(false);
			base.GetItem(11).SetUIActive(false);
		}
		else
		{
			base.GetButton(14).RootUIComp.Get().SetUIActive(true);
			base.GetButton(15).RootUIComp.Get().SetUIActive(true);
			base.GetItem(11).SetUIActive(true);
			this.PageDotLayout.RebuildLayoutByDataNew<int>(this.PageIds, null);
		}
		this.RefreshPageView(this.CurrDisplayIndex);
	}

	// Token: 0x06016A29 RID: 92713 RVA: 0x006484BC File Offset: 0x006466BC
	private void RefreshPageView(int index)
	{
		if (this.PageIds.Count > 1)
		{
			this.PageDotLayout.GetLayoutItemByIndex(this.CurrDisplayIndex).UpdateShow(false);
			this.PageDotLayout.GetLayoutItemByIndex(index).UpdateShow(true);
		}
		this.CurrDisplayIndex = index;
		GuideTutorialPage? guideTutorialPage = ConfigBase<GuideConfig>.Instance.GetGuideTutorialPage(this.PageIds[index]);
		if (!string.IsNullOrEmpty(guideTutorialPage.Value.Pic))
		{
			UUITexture texture = base.GetTexture(6);
			base.SetTextureByPath(guideTutorialPage.Value.Pic, texture, null, null);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), guideTutorialPage.Value.Title, Array.Empty<object>());
		if (StringUtils.IsEmpty(guideTutorialPage.Value.SubTitle))
		{
			base.GetItem(8).SetUIActive(false);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), guideTutorialPage.Value.SubTitle, Array.Empty<object>());
			base.GetItem(8).SetUIActive(true);
		}
		if (this.PageIds.Count > 1)
		{
			base.GetButton(14).SetSelfInteractive(this.CurrDisplayIndex > 0);
			base.GetButton(15).SetSelfInteractive(this.CurrDisplayIndex < this.PageIds.Count - 1);
		}
		string text = ConfigMultiTextLang.GetLocalTextNew(guideTutorialPage.Value.Content, null);
		text = text.Replace("/n", "");
		base.GetText(10).SetText(text, true);
	}

	// Token: 0x06016A2A RID: 92714 RVA: 0x00648658 File Offset: 0x00646858
	private void OnClickBtnLast()
	{
		if (this.CurrDisplayIndex > 0)
		{
			this.UiViewSequence.PlaySequence("SwitchLeft", false, null);
			this.RefreshPageView(this.CurrDisplayIndex - 1);
		}
	}

	// Token: 0x06016A2B RID: 92715 RVA: 0x00648698 File Offset: 0x00646898
	private void OnClickBtnNext()
	{
		if (this.CurrDisplayIndex < this.PageIds.Count - 1)
		{
			this.UiViewSequence.PlaySequence("SwitchRight", false, null);
			this.RefreshPageView(this.CurrDisplayIndex + 1);
		}
	}

	// Token: 0x06016A2C RID: 92716 RVA: 0x006486E2 File Offset: 0x006468E2
	private void OnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400AEA3 RID: 44707
	public bool IsOpenedByGuide;

	// Token: 0x0400AEA4 RID: 44708
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x0400AEA5 RID: 44709
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<TutorialDataItem, TutorialDynItem, TutorialItemData> ItemScrollView;

	// Token: 0x0400AEA6 RID: 44710
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TutorialPageItem> PageDotLayout;

	// Token: 0x0400AEA7 RID: 44711
	[Nullable(2)]
	private CommonSearchComponent SearchComponent;

	// Token: 0x0400AEA8 RID: 44712
	private ETutorialType? CurrentSelectType;

	// Token: 0x0400AEA9 RID: 44713
	[Nullable(2)]
	private UUIExtendToggle NowSelectedToggle;

	// Token: 0x0400AEAA RID: 44714
	private List<int> TypeList = new List<int>();

	// Token: 0x0400AEAB RID: 44715
	private int CurrDisplayIndex;

	// Token: 0x0400AEAC RID: 44716
	[Nullable(2)]
	private TutorialItemData ItemData;

	// Token: 0x0400AEAD RID: 44717
	[Nullable(2)]
	private List<int> PageIds;

	// Token: 0x0400AEAE RID: 44718
	private EExclusiveTutorialType ExclusiveType;

	// Token: 0x0400AEAF RID: 44719
	private int RefreshTargetTutorialId = -1;

	// Token: 0x02008F4F RID: 36687
	[NullableContext(0)]
	public enum ETutorialsComponents
	{
		// Token: 0x040301F7 RID: 197111
		UUIItemCaptionList,
		// Token: 0x040301F8 RID: 197112
		UUIItemInputBox,
		// Token: 0x040301F9 RID: 197113
		DynScrollView,
		// Token: 0x040301FA RID: 197114
		PnlList,
		// Token: 0x040301FB RID: 197115
		PnlRight,
		// Token: 0x040301FC RID: 197116
		UUIItemEmpty,
		// Token: 0x040301FD RID: 197117
		TexPicture,
		// Token: 0x040301FE RID: 197118
		TxtArea,
		// Token: 0x040301FF RID: 197119
		PnlOffset,
		// Token: 0x04030200 RID: 197120
		TxtSubTitle,
		// Token: 0x04030201 RID: 197121
		TxtTutorials,
		// Token: 0x04030202 RID: 197122
		PnlBottom,
		// Token: 0x04030203 RID: 197123
		PnlPages,
		// Token: 0x04030204 RID: 197124
		UUIItemPagesDot,
		// Token: 0x04030205 RID: 197125
		BtnArrowL,
		// Token: 0x04030206 RID: 197126
		BtnArrowR
	}
}
