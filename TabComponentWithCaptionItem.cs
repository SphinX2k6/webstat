using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A61 RID: 6753
[NullableContext(1)]
[Nullable(0)]
public class TabComponentWithCaptionItem<[Nullable(0)] TTabItem> : UiPanelBase where TTabItem : CommonTabItemBase
{
	// Token: 0x0600C10D RID: 49421 RVA: 0x0032E47D File Offset: 0x0032C67D
	public TabComponentWithCaptionItem(UUIItem uiItem, CommonTabComponentData<TTabItem> data, Action closeCallBack, bool bAsync = false)
	{
		this.TabComponentData = data;
		this.OnCloseCallBack = closeCallBack;
		if (!bAsync)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}
	}

	// Token: 0x17000FD9 RID: 4057
	// (get) Token: 0x0600C10E RID: 49422 RVA: 0x0032E4AB File Offset: 0x0032C6AB
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TabComponent<TTabItem> TabComponent
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.TabComponentInternal;
		}
	}

	// Token: 0x0600C10F RID: 49423 RVA: 0x0032E4B4 File Offset: 0x0032C6B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C110 RID: 49424 RVA: 0x0032E540 File Offset: 0x0032C740
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(this.OnCloseCallBack);
		this.ScrollView = base.GetScrollViewWithScrollbar(1);
		this.TabComponentInternal = new TabComponent<TTabItem>(this.ScrollView.Content.Get().GetUIItem(), new Func<UUIItem, int?, TTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), null);
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600C111 RID: 49425 RVA: 0x0032E5CA File Offset: 0x0032C7CA
	private TTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return this.TabComponentData.ProxyCreate(uiItem, new int?(index.GetValueOrDefault()));
	}

	// Token: 0x0600C112 RID: 49426 RVA: 0x0032E5EC File Offset: 0x0032C7EC
	private void ToggleCallBack(int index)
	{
		CommonTabData commonTabData = this.TabComponentData.GetCommonData(index);
		if (commonTabData != null && this.NeedCaptionSwitchWithToggle)
		{
			this.CaptionItem.SetTitleByTitleData(commonTabData.GetTitleData());
			this.CaptionItem.SetTitleIcon(commonTabData.GetSmallIcon());
		}
		this.TabComponentData.ToggleCallBack(index);
	}

	// Token: 0x0600C113 RID: 49427 RVA: 0x0032E649 File Offset: 0x0032C849
	public void SetCloseCallBack(Action callBack)
	{
		this.OnCloseCallBack = callBack;
	}

	// Token: 0x0600C114 RID: 49428 RVA: 0x0032E652 File Offset: 0x0032C852
	public void RefreshTabItem(List<CommonTabItemData> dataArray, [Nullable(2)] Action callBack = null)
	{
		this.TabComponent.RefreshTabItem(dataArray, callBack);
	}

	// Token: 0x0600C115 RID: 49429 RVA: 0x0032E664 File Offset: 0x0032C864
	public UniTask RefreshTabItemAsync(List<CommonTabItemData> array, bool resetSelect = true)
	{
		TabComponentWithCaptionItem<TTabItem>.<RefreshTabItemAsync>d__17 <RefreshTabItemAsync>d__;
		<RefreshTabItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemAsync>d__.<>4__this = this;
		<RefreshTabItemAsync>d__.array = array;
		<RefreshTabItemAsync>d__.resetSelect = resetSelect;
		<RefreshTabItemAsync>d__.<>1__state = -1;
		<RefreshTabItemAsync>d__.<>t__builder.Start<TabComponentWithCaptionItem<TTabItem>.<RefreshTabItemAsync>d__17>(ref <RefreshTabItemAsync>d__);
		return <RefreshTabItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C116 RID: 49430 RVA: 0x0032E6B8 File Offset: 0x0032C8B8
	[NullableContext(2)]
	public void RefreshTabItemByLength(int length, Action callBack = null)
	{
		List<CommonTabItemData> dataArray = this.CreateTabItemDataByLength(length);
		this.RefreshTabItem(dataArray, callBack);
	}

	// Token: 0x0600C117 RID: 49431 RVA: 0x0032E6D8 File Offset: 0x0032C8D8
	public UniTask RefreshTabItemByLengthAsync(int length)
	{
		TabComponentWithCaptionItem<TTabItem>.<RefreshTabItemByLengthAsync>d__19 <RefreshTabItemByLengthAsync>d__;
		<RefreshTabItemByLengthAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemByLengthAsync>d__.<>4__this = this;
		<RefreshTabItemByLengthAsync>d__.length = length;
		<RefreshTabItemByLengthAsync>d__.<>1__state = -1;
		<RefreshTabItemByLengthAsync>d__.<>t__builder.Start<TabComponentWithCaptionItem<TTabItem>.<RefreshTabItemByLengthAsync>d__19>(ref <RefreshTabItemByLengthAsync>d__);
		return <RefreshTabItemByLengthAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C118 RID: 49432 RVA: 0x0032E724 File Offset: 0x0032C924
	public UniTask CreatePopupToggleTab(Action<EToggleState> callback)
	{
		TabComponentWithCaptionItem<TTabItem>.<CreatePopupToggleTab>d__20 <CreatePopupToggleTab>d__;
		<CreatePopupToggleTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePopupToggleTab>d__.<>4__this = this;
		<CreatePopupToggleTab>d__.callback = callback;
		<CreatePopupToggleTab>d__.<>1__state = -1;
		<CreatePopupToggleTab>d__.<>t__builder.Start<TabComponentWithCaptionItem<TTabItem>.<CreatePopupToggleTab>d__20>(ref <CreatePopupToggleTab>d__);
		return <CreatePopupToggleTab>d__.<>t__builder.Task;
	}

	// Token: 0x0600C119 RID: 49433 RVA: 0x0032E76F File Offset: 0x0032C96F
	public EToggleState GetCaptionToggleState()
	{
		return this.CaptionItem.GetToggleState();
	}

	// Token: 0x0600C11A RID: 49434 RVA: 0x0032E77C File Offset: 0x0032C97C
	public void SetPopupToggleName(string name)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetToggleName(name);
	}

	// Token: 0x0600C11B RID: 49435 RVA: 0x0032E78F File Offset: 0x0032C98F
	public void SetPopupToggleVisible(bool visible)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetToggleVisible(visible);
	}

	// Token: 0x0600C11C RID: 49436 RVA: 0x0032E7A4 File Offset: 0x0032C9A4
	public List<CommonTabItemData> CreateTabItemDataByLength(int length)
	{
		List<CommonTabItemData> list = new List<CommonTabItemData>();
		for (int i = 0; i < length; i++)
		{
			list.Add(new CommonTabItemData
			{
				Index = i,
				Data = this.TabComponentData.GetCommonData(i)
			});
		}
		return list;
	}

	// Token: 0x0600C11D RID: 49437 RVA: 0x0032E7EF File Offset: 0x0032C9EF
	public void SelectToggleByIndex(int index, bool bIgnored = false)
	{
		this.TabComponent.SelectToggleByIndex(index, bIgnored, true);
	}

	// Token: 0x0600C11E RID: 49438 RVA: 0x0032E800 File Offset: 0x0032CA00
	public void ShowItem()
	{
		this.SequencePlayer.PlayLevelSequenceByName("Start", true, null, false);
	}

	// Token: 0x0600C11F RID: 49439 RVA: 0x0032E828 File Offset: 0x0032CA28
	public UniTask ShowItemAsync()
	{
		TabComponentWithCaptionItem<TTabItem>.<ShowItemAsync>d__27 <ShowItemAsync>d__;
		<ShowItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowItemAsync>d__.<>4__this = this;
		<ShowItemAsync>d__.<>1__state = -1;
		<ShowItemAsync>d__.<>t__builder.Start<TabComponentWithCaptionItem<TTabItem>.<ShowItemAsync>d__27>(ref <ShowItemAsync>d__);
		return <ShowItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C120 RID: 49440 RVA: 0x0032E86C File Offset: 0x0032CA6C
	public void HideItem()
	{
		this.SequencePlayer.PlayLevelSequenceByName("Close", true, null, false);
	}

	// Token: 0x0600C121 RID: 49441 RVA: 0x0032E894 File Offset: 0x0032CA94
	public int GetSelectedIndex()
	{
		return this.TabComponent.GetSelectedIndex();
	}

	// Token: 0x0600C122 RID: 49442 RVA: 0x0032E8A4 File Offset: 0x0032CAA4
	public void ScrollToToggleByIndex(int index)
	{
		TTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.ScrollView.ScrollTo(tabItemByIndex.GetRootItem(), false);
	}

	// Token: 0x0600C123 RID: 49443 RVA: 0x0032E8D8 File Offset: 0x0032CAD8
	public void LateScrollToToggleByIndex(int index)
	{
		TTabItem tabItem = this.TabComponent.GetTabItemByIndex(index);
		TTimerAction <>9__1;
		this.ScrollView.OnLateUpdate.Bind(delegate(float _)
		{
			TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
			TTimerAction action;
			if ((action = <>9__1) == null)
			{
				action = (<>9__1 = delegate(float __)
				{
					this.ScrollView.ScrollTo(tabItem.GetRootItem(), false);
				});
			}
			gameplayTimeInstance.Next(action, null, null);
			this.ScrollView.OnLateUpdate.Unbind();
		});
	}

	// Token: 0x0600C124 RID: 49444 RVA: 0x0032E920 File Offset: 0x0032CB20
	[NullableContext(2)]
	public TTabItem GetTabItemByIndex(int index)
	{
		return this.TabComponent.GetTabItemByIndex(index);
	}

	// Token: 0x0600C125 RID: 49445 RVA: 0x0032E92E File Offset: 0x0032CB2E
	public Dictionary<int, TTabItem> GetTabItemMap()
	{
		return this.TabComponent.GetTabItemMap();
	}

	// Token: 0x0600C126 RID: 49446 RVA: 0x0032E93B File Offset: 0x0032CB3B
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TabComponent<TTabItem> GetTabComponent()
	{
		return this.TabComponent;
	}

	// Token: 0x0600C127 RID: 49447 RVA: 0x0032E943 File Offset: 0x0032CB43
	public void SetCanChange(Func<int, bool?, bool> callback)
	{
		this.TabComponent.SetCanChange(callback);
	}

	// Token: 0x0600C128 RID: 49448 RVA: 0x0032E951 File Offset: 0x0032CB51
	public void SetTabRootActive(bool active)
	{
		base.GetItem(2).SetUIActive(active);
	}

	// Token: 0x0600C129 RID: 49449 RVA: 0x0032E960 File Offset: 0x0032CB60
	public void SetRootActive(bool active)
	{
		base.GetItem(2).SetUIActive(active);
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetUiActive(active);
	}

	// Token: 0x0600C12A RID: 49450 RVA: 0x0032E980 File Offset: 0x0032CB80
	public UniTask SetCurrencyItemList(List<int> itemIdList)
	{
		TabComponentWithCaptionItem<TTabItem>.<SetCurrencyItemList>d__38 <SetCurrencyItemList>d__;
		<SetCurrencyItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetCurrencyItemList>d__.<>4__this = this;
		<SetCurrencyItemList>d__.itemIdList = itemIdList;
		<SetCurrencyItemList>d__.<>1__state = -1;
		<SetCurrencyItemList>d__.<>t__builder.Start<TabComponentWithCaptionItem<TTabItem>.<SetCurrencyItemList>d__38>(ref <SetCurrencyItemList>d__);
		return <SetCurrencyItemList>d__.<>t__builder.Task;
	}

	// Token: 0x0600C12B RID: 49451 RVA: 0x0032E9CB File Offset: 0x0032CBCB
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<CommonCurrencyItem> GetCurrencyItemList()
	{
		return this.CaptionItem.GetCurrencyItemList();
	}

	// Token: 0x0600C12C RID: 49452 RVA: 0x0032E9D8 File Offset: 0x0032CBD8
	public void SetHelpButtonShowState(bool state)
	{
		this.CaptionItem.SetHelpBtnActive(state);
	}

	// Token: 0x0600C12D RID: 49453 RVA: 0x0032E9E6 File Offset: 0x0032CBE6
	public void SetHelpButtonCallBack(Action call)
	{
		this.CaptionItem.SetHelpCallBack(call);
	}

	// Token: 0x0600C12E RID: 49454 RVA: 0x0032E9F4 File Offset: 0x0032CBF4
	public void SetCloseBtnRaycast(bool state)
	{
		this.CaptionItem.SetCloseBtnRaycast(state);
	}

	// Token: 0x0600C12F RID: 49455 RVA: 0x0032EA02 File Offset: 0x0032CC02
	public void SetCloseBtnShowState(bool state)
	{
		this.CaptionItem.SetCloseBtnShowState(state);
	}

	// Token: 0x0600C130 RID: 49456 RVA: 0x0032EA10 File Offset: 0x0032CC10
	public void SetHomeBtnShowState(bool state)
	{
		this.CaptionItem.SetHomeBtnShowState(state);
	}

	// Token: 0x0600C131 RID: 49457 RVA: 0x0032EA20 File Offset: 0x0032CC20
	public void SetTabComponentShowState(bool state)
	{
		this.ScrollView.RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x0600C132 RID: 49458 RVA: 0x0032EA46 File Offset: 0x0032CC46
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponentInternal != null)
		{
			this.TabComponentInternal.Destroy(null);
			this.TabComponentInternal = null;
		}
		if (this.CaptionItem != null)
		{
			this.CaptionItem.Destroy(null);
			this.CaptionItem = null;
		}
	}

	// Token: 0x0600C133 RID: 49459 RVA: 0x0032EA7E File Offset: 0x0032CC7E
	public void SetTitle(string title)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetTitle(title);
	}

	// Token: 0x0600C134 RID: 49460 RVA: 0x0032EA94 File Offset: 0x0032CC94
	public void SetTitleByTextIdAndArgNew(string textId, params string[] args)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetTitleByTextIdAndArgNew(textId, args);
	}

	// Token: 0x0600C135 RID: 49461 RVA: 0x0032EAB5 File Offset: 0x0032CCB5
	public void SetTitleIcon(string iconPath)
	{
		this.CaptionItem.SetTitleIcon(iconPath);
	}

	// Token: 0x0600C136 RID: 49462 RVA: 0x0032EAC3 File Offset: 0x0032CCC3
	public void SetTitleIconVisible(bool state)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SetTitleIconVisible(state);
	}

	// Token: 0x0600C137 RID: 49463 RVA: 0x0032EAD6 File Offset: 0x0032CCD6
	[NullableContext(2)]
	public UUIItem GetCostContent()
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return null;
		}
		return captionItem.GetCostContent();
	}

	// Token: 0x0600C138 RID: 49464 RVA: 0x0032EAE9 File Offset: 0x0032CCE9
	[NullableContext(2)]
	public UUIScrollViewWithScrollbarComponent GetScrollView()
	{
		return this.ScrollView;
	}

	// Token: 0x0600C139 RID: 49465 RVA: 0x0032EAF4 File Offset: 0x0032CCF4
	public void SetScrollViewVisible(bool state)
	{
		base.GetScrollViewWithScrollbar(1).RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x0600C13A RID: 49466 RVA: 0x0032EB1B File Offset: 0x0032CD1B
	protected override bool DestroyOverride()
	{
		return true;
	}

	// Token: 0x04005A78 RID: 23160
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04005A79 RID: 23161
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private readonly CommonTabComponentData<TTabItem> TabComponentData;

	// Token: 0x04005A7A RID: 23162
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<TTabItem> TabComponentInternal;

	// Token: 0x04005A7B RID: 23163
	[Nullable(2)]
	private UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x04005A7C RID: 23164
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04005A7D RID: 23165
	[Nullable(2)]
	private Action OnCloseCallBack;

	// Token: 0x04005A7E RID: 23166
	public bool NeedCaptionSwitchWithToggle = true;

	// Token: 0x02007D12 RID: 32018
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402AA4F RID: 174671
		public const int CaptionItem = 0;

		// Token: 0x0402AA50 RID: 174672
		public const int ScrollView = 1;

		// Token: 0x0402AA51 RID: 174673
		public const int TabRootNode = 2;
	}
}
