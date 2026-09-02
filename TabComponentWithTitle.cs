using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A62 RID: 6754
[NullableContext(1)]
[Nullable(0)]
public class TabComponentWithTitle<[Nullable(0)] TTabItem> : UiPanelBase where TTabItem : CommonTabItemBase
{
	// Token: 0x0600C13B RID: 49467 RVA: 0x0032EB1E File Offset: 0x0032CD1E
	public TabComponentWithTitle(UUIItem uiItem, CommonTabComponentData<TTabItem> data)
	{
		this.TabComponentData = data;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600C13C RID: 49468 RVA: 0x0032EB3C File Offset: 0x0032CD3C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C13D RID: 49469 RVA: 0x0032EBA8 File Offset: 0x0032CDA8
	protected override void OnStart()
	{
		this.ScrollView = base.GetScrollViewWithScrollbar(1);
		this.TabComponent = new TabComponent<TTabItem>(this.ScrollView.Content.Get().GetUIItem(), new Func<UUIItem, int?, TTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), null);
		this.TabTitle = new CommonTabTitle(base.GetItem(0));
	}

	// Token: 0x0600C13E RID: 49470 RVA: 0x0032EC10 File Offset: 0x0032CE10
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.TabTitle != null)
		{
			this.TabTitle.Destroy(null);
			this.TabTitle = null;
		}
	}

	// Token: 0x0600C13F RID: 49471 RVA: 0x0032EC48 File Offset: 0x0032CE48
	private void ToggleCallBack(int index)
	{
		CommonTabData commonTabData = this.TabComponentData.GetCommonData(index);
		if (commonTabData != null)
		{
			this.TabTitle.UpdateIcon(commonTabData.GetSmallIcon());
			this.TabTitle.UpdateTitle(commonTabData.GetTitleData());
		}
		this.TabComponentData.ToggleCallBack(index);
	}

	// Token: 0x0600C140 RID: 49472 RVA: 0x0032EC9D File Offset: 0x0032CE9D
	private TTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return this.TabComponentData.ProxyCreate(uiItem, new int?(index.GetValueOrDefault()));
	}

	// Token: 0x0600C141 RID: 49473 RVA: 0x0032ECBC File Offset: 0x0032CEBC
	[NullableContext(2)]
	public void RefreshTabItem(int length, Action callBack = null)
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
		this.TabComponent.RefreshTabItem(list, callBack);
	}

	// Token: 0x0600C142 RID: 49474 RVA: 0x0032ED14 File Offset: 0x0032CF14
	public UniTask RefreshTabItemAsync(int length)
	{
		TabComponentWithTitle<TTabItem>.<RefreshTabItemAsync>d__12 <RefreshTabItemAsync>d__;
		<RefreshTabItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemAsync>d__.<>4__this = this;
		<RefreshTabItemAsync>d__.length = length;
		<RefreshTabItemAsync>d__.<>1__state = -1;
		<RefreshTabItemAsync>d__.<>t__builder.Start<TabComponentWithTitle<TTabItem>.<RefreshTabItemAsync>d__12>(ref <RefreshTabItemAsync>d__);
		return <RefreshTabItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C143 RID: 49475 RVA: 0x0032ED60 File Offset: 0x0032CF60
	public UniTask RefreshTabItemByDataAsync(List<CommonTabItemData> array)
	{
		TabComponentWithTitle<TTabItem>.<RefreshTabItemByDataAsync>d__13 <RefreshTabItemByDataAsync>d__;
		<RefreshTabItemByDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemByDataAsync>d__.<>4__this = this;
		<RefreshTabItemByDataAsync>d__.array = array;
		<RefreshTabItemByDataAsync>d__.<>1__state = -1;
		<RefreshTabItemByDataAsync>d__.<>t__builder.Start<TabComponentWithTitle<TTabItem>.<RefreshTabItemByDataAsync>d__13>(ref <RefreshTabItemByDataAsync>d__);
		return <RefreshTabItemByDataAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C144 RID: 49476 RVA: 0x0032EDAB File Offset: 0x0032CFAB
	public void SelectToggleByIndex(int index, bool bIgnored = false)
	{
		this.TabComponent.SelectToggleByIndex(index, bIgnored, true);
	}

	// Token: 0x0600C145 RID: 49477 RVA: 0x0032EDBB File Offset: 0x0032CFBB
	public int GetSelectedIndex()
	{
		return this.TabComponent.GetSelectedIndex();
	}

	// Token: 0x0600C146 RID: 49478 RVA: 0x0032EDC8 File Offset: 0x0032CFC8
	public void ScrollToToggleByIndex(int index)
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

	// Token: 0x0600C147 RID: 49479 RVA: 0x0032EE10 File Offset: 0x0032D010
	[NullableContext(2)]
	public TTabItem GetTabItemByIndex(int index)
	{
		return this.TabComponent.GetTabItemByIndex(index);
	}

	// Token: 0x0600C148 RID: 49480 RVA: 0x0032EE1E File Offset: 0x0032D01E
	public Dictionary<int, TTabItem> GetTabItemMap()
	{
		return this.TabComponent.GetTabItemMap();
	}

	// Token: 0x0600C149 RID: 49481 RVA: 0x0032EE2B File Offset: 0x0032D02B
	[NullableContext(2)]
	public CommonTabData GetTabComponentData(int index)
	{
		return this.TabComponentData.GetCommonData(index);
	}

	// Token: 0x0600C14A RID: 49482 RVA: 0x0032EE3E File Offset: 0x0032D03E
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public TabComponent<TTabItem> GetTabComponent()
	{
		return this.TabComponent;
	}

	// Token: 0x0600C14B RID: 49483 RVA: 0x0032EE48 File Offset: 0x0032D048
	public void SetCanChange(Func<int, bool> callback)
	{
		this.TabComponent.SetCanChange((int index, bool? forceSwitch) => callback(index));
	}

	// Token: 0x04005A7F RID: 23167
	[Nullable(2)]
	protected CommonTabTitle TabTitle;

	// Token: 0x04005A80 RID: 23168
	private readonly CommonTabComponentData<TTabItem> TabComponentData;

	// Token: 0x04005A81 RID: 23169
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<TTabItem> TabComponent;

	// Token: 0x04005A82 RID: 23170
	[Nullable(2)]
	private UUIScrollViewWithScrollbarComponent ScrollView;

	// Token: 0x02007D19 RID: 32025
	[NullableContext(0)]
	private class ETabComponentWithTitle
	{
		// Token: 0x0402AA6E RID: 174702
		public const int Title = 0;

		// Token: 0x0402AA6F RID: 174703
		public const int ScrollView = 1;
	}
}
