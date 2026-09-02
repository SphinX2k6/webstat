using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E8D RID: 7821
[NullableContext(1)]
[Nullable(0)]
public class HandBookQuestView : UiViewBase
{
	// Token: 0x0600E722 RID: 59170 RVA: 0x003E6A49 File Offset: 0x003E4C49
	public HandBookQuestView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E723 RID: 59171 RVA: 0x003E6A60 File Offset: 0x003E4C60
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600E724 RID: 59172 RVA: 0x003E6AE8 File Offset: 0x003E4CE8
	protected override UniTask OnBeforeStartAsync()
	{
		HandBookQuestView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HandBookQuestView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E725 RID: 59173 RVA: 0x003E6B2B File Offset: 0x003E4D2B
	protected override void OnStart()
	{
		TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.SetHelpButtonShowState(false);
		}
		this.Refresh();
		this.AddEvent();
	}

	// Token: 0x0600E726 RID: 59174 RVA: 0x003E6B4B File Offset: 0x003E4D4B
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E727 RID: 59175 RVA: 0x003E6B53 File Offset: 0x003E4D53
	protected void Refresh()
	{
		this.RefreshLoopScrollView();
		this.RefreshCollectText();
	}

	// Token: 0x0600E728 RID: 59176 RVA: 0x003E6B64 File Offset: 0x003E4D64
	protected void AddEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhotoSelect, new Action<int>(this.OnPhotoSelect));
	}

	// Token: 0x0600E729 RID: 59177 RVA: 0x003E6BE4 File Offset: 0x003E4DE4
	protected void RemoveEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhotoSelect, new Action<int>(this.OnPhotoSelect));
	}

	// Token: 0x0600E72A RID: 59178 RVA: 0x003E6C64 File Offset: 0x003E4E64
	protected override void OnBeforeShow()
	{
		bool flag = true;
		foreach (HandBookQuestItem handBookQuestItem in this.HandBookItemList)
		{
			foreach (HandBookQuestChildItem handBookQuestChildItem in handBookQuestItem.GetChildItemList())
			{
				UUIExtendToggle tog = handBookQuestChildItem.GetTog();
				if (flag && handBookQuestChildItem.GetIsUnlock())
				{
					tog.SetToggleStateForce(EToggleState.ETT_Checked, false, true, false);
					flag = false;
				}
				else
				{
					tog.SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
				}
			}
		}
		this.TabComponent.SelectToggleByIndex(this.CurSelectTabIndex, false);
	}

	// Token: 0x0600E72B RID: 59179 RVA: 0x003E6D2C File Offset: 0x003E4F2C
	protected UniTask InitCommonTabTitle()
	{
		HandBookQuestView.<InitCommonTabTitle>d__19 <InitCommonTabTitle>d__;
		<InitCommonTabTitle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCommonTabTitle>d__.<>4__this = this;
		<InitCommonTabTitle>d__.<>1__state = -1;
		<InitCommonTabTitle>d__.<>t__builder.Start<HandBookQuestView.<InitCommonTabTitle>d__19>(ref <InitCommonTabTitle>d__);
		return <InitCommonTabTitle>d__.<>t__builder.Task;
	}

	// Token: 0x0600E72C RID: 59180 RVA: 0x003E6D6F File Offset: 0x003E4F6F
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600E72D RID: 59181 RVA: 0x003E6D78 File Offset: 0x003E4F78
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		this.CurSelectTabIndex = index;
		this.Refresh();
		(base.GetScrollViewWithScrollbar(1).GetContent().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController).Play("", -1, false);
	}

	// Token: 0x0600E72E RID: 59182 RVA: 0x003E6DD4 File Offset: 0x003E4FD4
	[NullableContext(2)]
	private CommonTabData GetCommonData(int index)
	{
		HandBookQuestTab handBookQuestTab = this.TabDataList[index];
		return new CommonTabData(handBookQuestTab.Icon, new CommonTabTitleData(handBookQuestTab.Name, Array.Empty<object>()), null);
	}

	// Token: 0x0600E72F RID: 59183 RVA: 0x003E6E0C File Offset: 0x003E500C
	protected bool CanToggleChange()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		if (this.LastClickTime != null)
		{
			double? num = Singleton<Time>.Instance.Now - this.LastClickTime;
			int? interval = this.Interval;
			double? num2 = (interval != null) ? new double?((double)interval.GetValueOrDefault()) : null;
			if (!(num.GetValueOrDefault() >= num2.GetValueOrDefault() & (num != null & num2 != null)))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600E730 RID: 59184 RVA: 0x003E6EC0 File Offset: 0x003E50C0
	protected void RefreshLoopScrollView()
	{
		if (this.TypeList == null)
		{
			this.TypeList = ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfigList();
		}
		List<PlotType> list = new List<PlotType>();
		int type = this.TabDataList[this.CurSelectTabIndex].Type;
		foreach (PlotType item in this.TypeList)
		{
			if (item.Type == type)
			{
				IReadOnlyList<PhotographHandBook> plotHandBookConfigByType = ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfigByType(item.Id);
				if (plotHandBookConfigByType != null)
				{
					bool flag = true;
					foreach (PhotographHandBook photographHandBook in plotHandBookConfigByType)
					{
						flag = (ModelBase<HandBookModel>.Instance.GetHandBookInfo((EHandBookTabType)item.Type, photographHandBook.Id) == null && flag);
					}
					if (!flag)
					{
						list.Add(item);
					}
				}
			}
		}
		list.Sort(new Comparison<PlotType>(this.SortIndex));
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
		if (this.GenericScroll == null)
		{
			this.GenericScroll = new GenericScrollViewNew<HandBookQuestItem, PlotType>(scrollViewWithScrollbar, new Func<HandBookQuestItem>(this.InitHandBookQuestItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, null);
		}
		if (list.Count > 0)
		{
			this.GenericScroll.SetActive(true);
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.GenericScroll.RefreshByData(list, delegate
			{
				GenericScrollViewNew<HandBookQuestItem, PlotType> genericScroll = this.GenericScroll;
				UUIItem uuiitem = (genericScroll != null) ? genericScroll.GetItemByIndex(0) : null;
				if (uuiitem != null)
				{
					GenericScrollViewNew<HandBookQuestItem, PlotType> genericScroll2 = this.GenericScroll;
					if (genericScroll2 == null)
					{
						return;
					}
					genericScroll2.ScrollTo(uuiitem, false);
				}
			}, false);
			return;
		}
		this.GenericScroll.SetActive(false);
		UUIItem item3 = base.GetItem(4);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(true);
	}

	// Token: 0x0600E731 RID: 59185 RVA: 0x003E7080 File Offset: 0x003E5280
	private HandBookQuestItem InitHandBookQuestItem()
	{
		HandBookQuestItem handBookQuestItem = new HandBookQuestItem();
		this.HandBookItemList.Add(handBookQuestItem);
		return handBookQuestItem;
	}

	// Token: 0x0600E732 RID: 59186 RVA: 0x003E70A0 File Offset: 0x003E52A0
	private int SortIndex(PlotType a, PlotType b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E733 RID: 59187 RVA: 0x003E70B1 File Offset: 0x003E52B1
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E734 RID: 59188 RVA: 0x003E70BC File Offset: 0x003E52BC
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Quest);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E735 RID: 59189 RVA: 0x003E710C File Offset: 0x003E530C
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != (EHandBookTabType)this.TabDataList[this.CurSelectTabIndex].Type)
		{
			return;
		}
		int count = this.HandBookItemList.Count;
		for (int i = 0; i < count; i++)
		{
			List<HandBookQuestChildItem> childItemList = this.HandBookItemList[i].GetChildItemList();
			int count2 = childItemList.Count;
			for (int j = 0; j < count2; j++)
			{
				HandBookQuestChildItem handBookQuestChildItem = childItemList[j];
				HandBookCommonItemData data = handBookQuestChildItem.GetData();
				if (data != null && data.ConfigId == id)
				{
					handBookQuestChildItem.SetNewState(false);
					return;
				}
			}
		}
	}

	// Token: 0x0600E736 RID: 59190 RVA: 0x003E71A4 File Offset: 0x003E53A4
	protected void OnPhotoSelect(int configId)
	{
		foreach (HandBookQuestItem handBookQuestItem in this.HandBookItemList)
		{
			foreach (HandBookQuestChildItem handBookQuestChildItem in handBookQuestItem.GetChildItemList())
			{
				handBookQuestChildItem.GetTog().SetToggleStateForce(EToggleState.ETT_UnChecked, false, true, false);
			}
		}
	}

	// Token: 0x0600E737 RID: 59191 RVA: 0x003E7238 File Offset: 0x003E5438
	protected override void OnBeforeDestroy()
	{
		this.RoleRootUiCameraHandleData = null;
		this.GenericScroll = null;
		this.TypeList = null;
		this.HandBookItemList = new List<HandBookQuestItem>();
		this.RemoveEvent();
	}

	// Token: 0x0600E738 RID: 59192 RVA: 0x003E7260 File Offset: 0x003E5460
	private void InitTabData()
	{
		this.TabDataList = ConfigBase<HandBookConfig>.Instance.GetQuestTabList();
	}

	// Token: 0x04006F86 RID: 28550
	[Nullable(2)]
	protected UiCameraHandleData RoleRootUiCameraHandleData;

	// Token: 0x04006F87 RID: 28551
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<HandBookQuestItem, PlotType> GenericScroll;

	// Token: 0x04006F88 RID: 28552
	[Nullable(2)]
	private IReadOnlyList<PlotType> TypeList;

	// Token: 0x04006F89 RID: 28553
	private List<HandBookQuestItem> HandBookItemList = new List<HandBookQuestItem>();

	// Token: 0x04006F8A RID: 28554
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x04006F8B RID: 28555
	private int CurSelectTabIndex;

	// Token: 0x04006F8C RID: 28556
	[Nullable(2)]
	private IReadOnlyList<HandBookQuestTab> TabDataList;

	// Token: 0x04006F8D RID: 28557
	private double? LastClickTime;

	// Token: 0x04006F8E RID: 28558
	private int? Interval;

	// Token: 0x020081CD RID: 33229
	[NullableContext(0)]
	private class EHandBookQuestViewDefine
	{
		// Token: 0x0402C0AA RID: 180394
		public const int TitleItem = 0;

		// Token: 0x0402C0AB RID: 180395
		public const int ScrollView = 1;

		// Token: 0x0402C0AC RID: 180396
		public const int CollectCountText = 2;

		// Token: 0x0402C0AD RID: 180397
		public const int ScrollViewItem = 3;

		// Token: 0x0402C0AE RID: 180398
		public const int EmptyItem = 4;
	}
}
