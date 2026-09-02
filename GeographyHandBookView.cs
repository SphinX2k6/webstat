using System;
using System.Collections.Generic;
using System.Linq;
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

// Token: 0x02001E49 RID: 7753
[NullableContext(1)]
[Nullable(0)]
public class GeographyHandBookView : UiViewBase
{
	// Token: 0x0600E570 RID: 58736 RVA: 0x003DF944 File Offset: 0x003DDB44
	public GeographyHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.GeographyTypeList = new List<GeographyType>();
		this.GeographyHandBookItemList = new List<GeographyHandBookItem>();
	}

	// Token: 0x0600E571 RID: 58737 RVA: 0x003DF964 File Offset: 0x003DDB64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent))
		};
	}

	// Token: 0x0600E572 RID: 58738 RVA: 0x003DF9D4 File Offset: 0x003DDBD4
	protected override void OnStart()
	{
		this.InitVerticalLayout();
	}

	// Token: 0x0600E573 RID: 58739 RVA: 0x003DF9DC File Offset: 0x003DDBDC
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E574 RID: 58740 RVA: 0x003DF9E4 File Offset: 0x003DDBE4
	protected void Refresh()
	{
		this.RefreshVerticalLayout();
		this.RefreshCollectText();
	}

	// Token: 0x0600E575 RID: 58741 RVA: 0x003DF9F4 File Offset: 0x003DDBF4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhotoSelect, new Action<int>(this.OnGeographyPhotoSelect));
	}

	// Token: 0x0600E576 RID: 58742 RVA: 0x003DFA74 File Offset: 0x003DDC74
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhotoSelect, new Action<int>(this.OnGeographyPhotoSelect));
	}

	// Token: 0x0600E577 RID: 58743 RVA: 0x003DFAF4 File Offset: 0x003DDCF4
	protected override UniTask OnBeforeStartAsync()
	{
		GeographyHandBookView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GeographyHandBookView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E578 RID: 58744 RVA: 0x003DFB37 File Offset: 0x003DDD37
	private void InitTabData()
	{
		this.TabDataList = ConfigGeographyTabTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E579 RID: 58745 RVA: 0x003DFB48 File Offset: 0x003DDD48
	private void InitSelectedTabIndex()
	{
		List<GeographyType> list = ConfigCommon.ToList<GeographyType>(ConfigBase<HandBookConfig>.Instance.GetGeographyTypeConfigList());
		if (list == null)
		{
			return;
		}
		list.Sort(new Comparison<GeographyType>(this.SortIndex));
		this.GeographyTypeList = list;
		IGeographyHandBookViewParam geographyHandBookViewParam = this.OpenParam as IGeographyHandBookViewParam;
		if (geographyHandBookViewParam != null && geographyHandBookViewParam.SelectedId > 0)
		{
			GeographyHandBook? config = ConfigBase<HandBookConfig>.Instance.GetGeographyHandBookConfig(geographyHandBookViewParam.SelectedId);
			if (config != null)
			{
				this.SelectedId = geographyHandBookViewParam.SelectedId;
				this.CurSelectTabIndex = this.TabDataList.ToList<GeographyTabType>().FindIndex((GeographyTabType tab) => tab.Id == config.Value.GeographyTabType);
			}
		}
	}

	// Token: 0x0600E57A RID: 58746 RVA: 0x003DFBF4 File Offset: 0x003DDDF4
	protected override void OnBeforeShow()
	{
		this.RefreshToggleState();
		this.TabComponent.SelectToggleByIndex(this.CurSelectTabIndex, false);
		if (this.SelectedId > 0)
		{
			GeographyHandBook? config = ConfigBase<HandBookConfig>.Instance.GetGeographyHandBookConfig(this.SelectedId);
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.TryScrollToHandBookItem(config.Value, true);
				this.SelectedId = 0;
			}, null, null);
		}
	}

	// Token: 0x0600E57B RID: 58747 RVA: 0x003DFC60 File Offset: 0x003DDE60
	private void RefreshToggleState()
	{
		bool flag = true;
		foreach (GeographyHandBookItem geographyHandBookItem in this.GenericLayout.GetLayoutItemList())
		{
			foreach (GeographyHandBookChildItem geographyHandBookChildItem in geographyHandBookItem.GetChildItemList())
			{
				UUIExtendToggle tog = geographyHandBookChildItem.GetTog();
				if (flag && geographyHandBookChildItem.GetIsUnlock())
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
	}

	// Token: 0x0600E57C RID: 58748 RVA: 0x003DFD1C File Offset: 0x003DDF1C
	protected UniTask InitCommonTabTitle()
	{
		GeographyHandBookView.<InitCommonTabTitle>d__22 <InitCommonTabTitle>d__;
		<InitCommonTabTitle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCommonTabTitle>d__.<>4__this = this;
		<InitCommonTabTitle>d__.<>1__state = -1;
		<InitCommonTabTitle>d__.<>t__builder.Start<GeographyHandBookView.<InitCommonTabTitle>d__22>(ref <InitCommonTabTitle>d__);
		return <InitCommonTabTitle>d__.<>t__builder.Task;
	}

	// Token: 0x0600E57D RID: 58749 RVA: 0x003DFD5F File Offset: 0x003DDF5F
	private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600E57E RID: 58750 RVA: 0x003DFD68 File Offset: 0x003DDF68
	[NullableContext(2)]
	private CommonTabData GetCommonData(int index)
	{
		GeographyTabType geographyTabType = this.TabDataList[index];
		return new CommonTabData(geographyTabType.Icon, new CommonTabTitleData(geographyTabType.TypeName, Array.Empty<object>()), null);
	}

	// Token: 0x0600E57F RID: 58751 RVA: 0x003DFDA0 File Offset: 0x003DDFA0
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		this.CurSelectTabIndex = index;
		this.Refresh();
	}

	// Token: 0x0600E580 RID: 58752 RVA: 0x003DFDC4 File Offset: 0x003DDFC4
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

	// Token: 0x0600E581 RID: 58753 RVA: 0x003DFE77 File Offset: 0x003DE077
	protected void InitVerticalLayout()
	{
		this.GenericLayout = new GenericLayout<GeographyHandBookItem, IGeographyHandBookItemData>(base.GetVerticalLayout(1), new Func<GeographyHandBookItem>(this.InitGeographyHandBookItem), null, false, true);
	}

	// Token: 0x0600E582 RID: 58754 RVA: 0x003DFE9C File Offset: 0x003DE09C
	protected void RefreshVerticalLayout()
	{
		List<IGeographyHandBookItemData> list = new List<IGeographyHandBookItemData>();
		GeographyTabType geographyTabType = this.TabDataList[this.CurSelectTabIndex];
		foreach (GeographyType type in this.GeographyTypeList)
		{
			IReadOnlyList<GeographyHandBook> configList = ConfigGeographyHandBookByTabTypeAndType.GetConfigList(geographyTabType.Id, type.Id, true);
			if (configList != null && configList.Count > 0)
			{
				GeographyHandBookItemData item = new GeographyHandBookItemData
				{
					TabType = this.TabDataList[this.CurSelectTabIndex],
					Type = type,
					HandBookList = (ConfigCommon.ToList<GeographyHandBook>(configList) ?? new List<GeographyHandBook>())
				};
				list.Add(item);
			}
		}
		this.GeographyHandBookItemList = new List<GeographyHandBookItem>();
		this.GenericLayout.RefreshByData(list, delegate
		{
			UUIItem itemByIndex = this.GenericLayout.GetItemByIndex(0);
			if (itemByIndex != null)
			{
				base.GetScrollViewWithScrollbar(3).ScrollTo(itemByIndex, false);
			}
			this.RefreshToggleState();
		}, false);
	}

	// Token: 0x0600E583 RID: 58755 RVA: 0x003DFF8C File Offset: 0x003DE18C
	private GeographyHandBookItem InitGeographyHandBookItem()
	{
		GeographyHandBookItem geographyHandBookItem = new GeographyHandBookItem();
		this.GeographyHandBookItemList.Add(geographyHandBookItem);
		return geographyHandBookItem;
	}

	// Token: 0x0600E584 RID: 58756 RVA: 0x003DFFAC File Offset: 0x003DE1AC
	private int SortIndex(GeographyType a, GeographyType b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E585 RID: 58757 RVA: 0x003DFFBD File Offset: 0x003DE1BD
	private int SortGeographyHandBookIndex(GeographyHandBook a, GeographyHandBook b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E586 RID: 58758 RVA: 0x003DFFCE File Offset: 0x003DE1CE
	private void OnClickCloseButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.GeographyHandBookView, null);
	}

	// Token: 0x0600E587 RID: 58759 RVA: 0x003DFFE0 File Offset: 0x003DE1E0
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Geography);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			collectProgress[0],
			collectProgress[1]
		}));
	}

	// Token: 0x0600E588 RID: 58760 RVA: 0x003E0030 File Offset: 0x003DE230
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Geography)
		{
			return;
		}
		List<GeographyHandBookItem> layoutItemList = this.GenericLayout.GetLayoutItemList();
		int count = layoutItemList.Count;
		for (int i = 0; i < count; i++)
		{
			List<GeographyHandBookChildItem> childItemList = layoutItemList[i].GetChildItemList();
			int count2 = childItemList.Count;
			for (int j = 0; j < count2; j++)
			{
				GeographyHandBookChildItem geographyHandBookChildItem = childItemList[j];
				if (((GeographyHandBook)geographyHandBookChildItem.GetData().Config).Id == id)
				{
					geographyHandBookChildItem.SetNewState(false);
					return;
				}
			}
		}
	}

	// Token: 0x0600E589 RID: 58761 RVA: 0x003E00B8 File Offset: 0x003DE2B8
	protected void OnGeographyPhotoSelect(int configId)
	{
		List<GeographyHandBook> list = ConfigCommon.ToList<GeographyHandBook>(ConfigBase<HandBookConfig>.Instance.GetAllGeographyHandBookConfig());
		if (list == null)
		{
			return;
		}
		list.Sort(new Comparison<GeographyHandBook>(this.SortGeographyHandBookIndex));
		int count = list.Count;
		GeographyHandBook? curSelectConfig = null;
		for (int i = 0; i < count; i++)
		{
			GeographyHandBook value = list[i];
			if (value.Id == configId)
			{
				curSelectConfig = new GeographyHandBook?(value);
				break;
			}
		}
		IReadOnlyList<GeographyTabType> tabDataList = this.TabDataList;
		this.CurSelectTabIndex = ((tabDataList != null) ? new int?(tabDataList.ToList<GeographyTabType>().FindIndex((GeographyTabType tab) => tab.Id == curSelectConfig.Value.GeographyTabType)) : null).GetValueOrDefault(-1);
		this.TabComponent.SelectToggleByIndex(this.CurSelectTabIndex, false);
		this.TryScrollToHandBookItem(curSelectConfig.Value, false);
	}

	// Token: 0x0600E58A RID: 58762 RVA: 0x003E019C File Offset: 0x003DE39C
	private void TryScrollToHandBookItem(GeographyHandBook itemConfig, bool toggleItem = false)
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
		List<GeographyHandBookItem> layoutItemList = this.GenericLayout.GetLayoutItemList();
		int count = layoutItemList.Count;
		for (int i = 0; i < count; i++)
		{
			List<GeographyHandBookChildItem> childItemList = layoutItemList[i].GetChildItemList();
			int count2 = childItemList.Count;
			for (int j = 0; j < count2; j++)
			{
				GeographyHandBookChildItem geographyHandBookChildItem = childItemList[j];
				GeographyHandBook geographyHandBook = (GeographyHandBook)geographyHandBookChildItem.GetData().Config;
				if (geographyHandBook.Id == itemConfig.Id && geographyHandBook.Type == itemConfig.Type)
				{
					geographyHandBookChildItem.SetToggleState(EToggleState.ETT_Checked);
					scrollViewWithScrollbar.ScrollTo(geographyHandBookChildItem.GetRootItem(), false);
					if (toggleItem)
					{
						geographyHandBookChildItem.ToggleClick();
					}
				}
				else
				{
					geographyHandBookChildItem.SetToggleState(EToggleState.ETT_UnChecked);
				}
			}
		}
	}

	// Token: 0x0600E58B RID: 58763 RVA: 0x003E0266 File Offset: 0x003DE466
	protected override void OnBeforeDestroy()
	{
		this.RoleRootUiCameraHandleData = null;
		if (this.GenericLayout != null)
		{
			this.GenericLayout.ClearChildren();
			this.GenericLayout = null;
		}
		this.GeographyTypeList = new List<GeographyType>();
		this.GeographyHandBookItemList = new List<GeographyHandBookItem>();
	}

	// Token: 0x04006E6E RID: 28270
	[Nullable(2)]
	private IReadOnlyList<GeographyTabType> TabDataList;

	// Token: 0x04006E6F RID: 28271
	private double? LastClickTime;

	// Token: 0x04006E70 RID: 28272
	private int? Interval;

	// Token: 0x04006E71 RID: 28273
	private int CurSelectTabIndex;

	// Token: 0x04006E72 RID: 28274
	private int SelectedId;

	// Token: 0x04006E73 RID: 28275
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

	// Token: 0x04006E74 RID: 28276
	[Nullable(2)]
	protected UiCameraHandleData RoleRootUiCameraHandleData;

	// Token: 0x04006E75 RID: 28277
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<GeographyHandBookItem, IGeographyHandBookItemData> GenericLayout;

	// Token: 0x04006E76 RID: 28278
	private List<GeographyType> GeographyTypeList;

	// Token: 0x04006E77 RID: 28279
	private List<GeographyHandBookItem> GeographyHandBookItemList;
}
