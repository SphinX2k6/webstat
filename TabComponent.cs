using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001A60 RID: 6752
[NullableContext(1)]
[Nullable(0)]
public class TabComponent<[Nullable(0)] TTabItem> : UiPanelBase where TTabItem : CommonTabItemBase
{
	// Token: 0x0600C0F8 RID: 49400 RVA: 0x0032E053 File Offset: 0x0032C253
	public TabComponent(UUIItem uiItem, [Nullable(new byte[]
	{
		1,
		2,
		1
	})] Func<UUIItem, int?, TTabItem> proxyCreate, Action<int> toggleCallBack, [Nullable(2)] UUIItem layoutOriginItem)
	{
		this.ProxyCreate = proxyCreate;
		this.ToggleCallBack = toggleCallBack;
		this.LayoutOriginItem = layoutOriginItem;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600C0F9 RID: 49401 RVA: 0x0032E088 File Offset: 0x0032C288
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C0FA RID: 49402 RVA: 0x0032E0D0 File Offset: 0x0032C2D0
	protected override void OnStart()
	{
		AUIBaseActor gridActor = (this.LayoutOriginItem != null) ? (this.LayoutOriginItem.GetOwner() as AUIBaseActor) : null;
		this.Layout = new GenericLayout<TTabItem, CommonTabItemData>(base.GetLayoutBase(0), new Func<TTabItem>(this.InitTabItem), gridActor, false, true);
	}

	// Token: 0x0600C0FB RID: 49403 RVA: 0x0032E11A File Offset: 0x0032C31A
	protected override void OnBeforeDestroy()
	{
		this.LayoutOriginItem = null;
	}

	// Token: 0x0600C0FC RID: 49404 RVA: 0x0032E124 File Offset: 0x0032C324
	private TTabItem InitTabItem()
	{
		TTabItem ttabItem = this.ProxyCreate(null, null);
		ttabItem.InitTabItem();
		ttabItem.SetSelectedCallBack(new Action<int>(this.ToggleEvent));
		ttabItem.SetCanExecuteChange(new Func<int, bool, bool>(this.CanExecuteChange));
		return ttabItem;
	}

	// Token: 0x0600C0FD RID: 49405 RVA: 0x0032E17F File Offset: 0x0032C37F
	private void ToggleEvent(int index)
	{
		this.SwitchLastToggle();
		this.CurrentIndex = index;
		this.ToggleCallBack(index);
	}

	// Token: 0x0600C0FE RID: 49406 RVA: 0x0032E19C File Offset: 0x0032C39C
	private void SwitchLastToggle()
	{
		if (this.CurrentIndex == -1)
		{
			return;
		}
		TTabItem layoutItemByKey = this.Layout.GetLayoutItemByKey(this.CurrentIndex);
		if (layoutItemByKey != null)
		{
			layoutItemByKey.SetForceSwitch(EToggleState.ETT_UnChecked, false);
		}
	}

	// Token: 0x0600C0FF RID: 49407 RVA: 0x0032E1DF File Offset: 0x0032C3DF
	private bool CanExecuteChange(int index, bool forceSwitch)
	{
		return (this.CurrentIndex != index || forceSwitch) && (this.CanExecuteChangeInternal == null || this.CanExecuteChangeInternal(index, new bool?(forceSwitch)));
	}

	// Token: 0x0600C100 RID: 49408 RVA: 0x0032E20C File Offset: 0x0032C40C
	public void RefreshTabItem(List<CommonTabItemData> array, [Nullable(2)] Action callBack = null)
	{
		if (this.CurrentIndex != -1)
		{
			TTabItem ttabItem = this.Layout.GetLayoutItemByIndex(this.CurrentIndex);
			if (ttabItem != null)
			{
				ttabItem.SetForceSwitch(EToggleState.ETT_UnChecked, false);
			}
		}
		this.CurrentIndex = -1;
		this.Layout.RefreshByData(array, callBack, false);
	}

	// Token: 0x0600C101 RID: 49409 RVA: 0x0032E25C File Offset: 0x0032C45C
	public UniTask RefreshTabItemAsync(List<CommonTabItemData> array, bool resetSelect = true)
	{
		TabComponent<TTabItem>.<RefreshTabItemAsync>d__16 <RefreshTabItemAsync>d__;
		<RefreshTabItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemAsync>d__.<>4__this = this;
		<RefreshTabItemAsync>d__.array = array;
		<RefreshTabItemAsync>d__.resetSelect = resetSelect;
		<RefreshTabItemAsync>d__.<>1__state = -1;
		<RefreshTabItemAsync>d__.<>t__builder.Start<TabComponent<TTabItem>.<RefreshTabItemAsync>d__16>(ref <RefreshTabItemAsync>d__);
		return <RefreshTabItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C102 RID: 49410 RVA: 0x0032E2B0 File Offset: 0x0032C4B0
	[NullableContext(2)]
	public void RefreshTabItemByLength(int length, Action callBack = null)
	{
		List<CommonTabItemData> list = new List<CommonTabItemData>();
		for (int i = 0; i < length; i++)
		{
			list.Add(new CommonTabItemData
			{
				Index = i
			});
		}
		this.RefreshTabItem(list, callBack);
	}

	// Token: 0x0600C103 RID: 49411 RVA: 0x0032E2EC File Offset: 0x0032C4EC
	public UniTask RefreshTabItemByLengthAsync(int length)
	{
		TabComponent<TTabItem>.<RefreshTabItemByLengthAsync>d__18 <RefreshTabItemByLengthAsync>d__;
		<RefreshTabItemByLengthAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabItemByLengthAsync>d__.<>4__this = this;
		<RefreshTabItemByLengthAsync>d__.length = length;
		<RefreshTabItemByLengthAsync>d__.<>1__state = -1;
		<RefreshTabItemByLengthAsync>d__.<>t__builder.Start<TabComponent<TTabItem>.<RefreshTabItemByLengthAsync>d__18>(ref <RefreshTabItemByLengthAsync>d__);
		return <RefreshTabItemByLengthAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C104 RID: 49412 RVA: 0x0032E338 File Offset: 0x0032C538
	public void ResetLastSelectTab()
	{
		TTabItem layoutItemByKey = this.Layout.GetLayoutItemByKey(this.CurrentIndex);
		if (layoutItemByKey != null)
		{
			layoutItemByKey.SetForceSwitch(EToggleState.ETT_UnChecked, false);
		}
	}

	// Token: 0x0600C105 RID: 49413 RVA: 0x0032E374 File Offset: 0x0032C574
	public void SelectToggleByIndex(int index, bool bIgnored = false, bool bFire = true)
	{
		if (bIgnored)
		{
			this.ResetSelectIndex();
		}
		if (index == this.CurrentIndex)
		{
			return;
		}
		TTabItem layoutItemByKey = this.Layout.GetLayoutItemByKey(index);
		if (layoutItemByKey != null)
		{
			layoutItemByKey.SetForceSwitch(EToggleState.ETT_Checked, bFire);
		}
	}

	// Token: 0x0600C106 RID: 49414 RVA: 0x0032E3BB File Offset: 0x0032C5BB
	public int GetSelectedIndex()
	{
		return this.CurrentIndex;
	}

	// Token: 0x0600C107 RID: 49415 RVA: 0x0032E3C3 File Offset: 0x0032C5C3
	public int TryGetSelectedIndex(int defaultValue)
	{
		if (this.CurrentIndex == -1)
		{
			return defaultValue;
		}
		return this.CurrentIndex;
	}

	// Token: 0x0600C108 RID: 49416 RVA: 0x0032E3D6 File Offset: 0x0032C5D6
	public void ResetSelectIndex()
	{
		this.ResetLastSelectTab();
		this.CurrentIndex = -1;
	}

	// Token: 0x0600C109 RID: 49417 RVA: 0x0032E3E5 File Offset: 0x0032C5E5
	[NullableContext(2)]
	public TTabItem GetTabItemByIndex(int index)
	{
		return this.Layout.GetLayoutItemByKey(index);
	}

	// Token: 0x0600C10A RID: 49418 RVA: 0x0032E3F8 File Offset: 0x0032C5F8
	public Dictionary<int, TTabItem> GetTabItemMap()
	{
		Dictionary<int, TTabItem> dictionary = new Dictionary<int, TTabItem>();
		foreach (KeyValuePair<object, TTabItem> keyValuePair in this.Layout.GetLayoutItemMap())
		{
			dictionary.Add((int)keyValuePair.Key, keyValuePair.Value);
		}
		return dictionary;
	}

	// Token: 0x0600C10B RID: 49419 RVA: 0x0032E46C File Offset: 0x0032C66C
	[return: Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public GenericLayout<TTabItem, CommonTabItemData> GetLayout()
	{
		return this.Layout;
	}

	// Token: 0x0600C10C RID: 49420 RVA: 0x0032E474 File Offset: 0x0032C674
	public void SetCanChange(Func<int, bool?, bool> callback)
	{
		this.CanExecuteChangeInternal = callback;
	}

	// Token: 0x04005A72 RID: 23154
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<TTabItem, CommonTabItemData> Layout;

	// Token: 0x04005A73 RID: 23155
	private int CurrentIndex = -1;

	// Token: 0x04005A74 RID: 23156
	[Nullable(2)]
	private UUIItem LayoutOriginItem;

	// Token: 0x04005A75 RID: 23157
	[Nullable(2)]
	private Func<int, bool?, bool> CanExecuteChangeInternal;

	// Token: 0x04005A76 RID: 23158
	[Nullable(new byte[]
	{
		1,
		2,
		1
	})]
	public readonly Func<UUIItem, int?, TTabItem> ProxyCreate;

	// Token: 0x04005A77 RID: 23159
	public readonly Action<int> ToggleCallBack;

	// Token: 0x02007D0F RID: 32015
	[NullableContext(0)]
	private class ETabComponent
	{
		// Token: 0x0402AA43 RID: 174659
		public const int Layout = 0;
	}
}
