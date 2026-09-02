using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A5F RID: 6751
[NullableContext(1)]
[Nullable(0)]
public class StaticTabComponent<[Nullable(0)] TTabItem> : UiPanelBase where TTabItem : CommonTabItemBase
{
	// Token: 0x0600C0EB RID: 49387 RVA: 0x0032DD68 File Offset: 0x0032BF68
	public StaticTabComponent(Func<UUIItem, int, TTabItem> proxyCreate, Action<int> toggleCallBack)
	{
		this.ProxyCreate = proxyCreate;
		this.ToggleCallBack = toggleCallBack;
	}

	// Token: 0x0600C0EC RID: 49388 RVA: 0x0032DD85 File Offset: 0x0032BF85
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0600C0ED RID: 49389 RVA: 0x0032DDB3 File Offset: 0x0032BFB3
	public void Init(List<UUIItem> items)
	{
		this.RegistTabItem(items);
	}

	// Token: 0x0600C0EE RID: 49390 RVA: 0x0032DDBC File Offset: 0x0032BFBC
	public void RegistTabItem(List<UUIItem> items)
	{
		this.Layout = new List<ILayoutItem<TTabItem>>();
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			UUIItem uiItem = items[i];
			ILayoutItem<TTabItem> item = this.InitTabItem(uiItem, i);
			this.Layout.Add(item);
		}
		this.CurrentIndex = 0;
	}

	// Token: 0x0600C0EF RID: 49391 RVA: 0x0032DE0C File Offset: 0x0032C00C
	protected override void OnStart()
	{
		TArray<UUIItem> attachUIChildren = base.GetItem(0).GetAttachUIChildren();
		this.Layout = new List<ILayoutItem<TTabItem>>();
		int num = attachUIChildren.Num();
		for (int i = 0; i < num; i++)
		{
			UUIItem uiItem = attachUIChildren.Get(i);
			ILayoutItem<TTabItem> item = this.InitTabItem(uiItem, i);
			this.Layout.Add(item);
		}
		this.CurrentIndex = 0;
	}

	// Token: 0x0600C0F0 RID: 49392 RVA: 0x0032DE6C File Offset: 0x0032C06C
	protected override void OnBeforeDestroy()
	{
		if (this.Layout != null)
		{
			foreach (ILayoutItem<TTabItem> layoutItem in this.Layout)
			{
				TTabItem ttabItem = layoutItem.Value;
				if (ttabItem != null)
				{
					ttabItem.Destroy(null);
				}
			}
			this.Layout.Clear();
		}
	}

	// Token: 0x0600C0F1 RID: 49393 RVA: 0x0032DEE0 File Offset: 0x0032C0E0
	private ILayoutItem<TTabItem> InitTabItem(UUIItem uiItem, int index)
	{
		TTabItem ttabItem = this.ProxyCreate(uiItem, index);
		ttabItem.GridIndex = index;
		ttabItem.InitTabItem();
		ttabItem.SetSelectedCallBack(new Action<int>(this.ToggleEvent));
		ttabItem.SetCanExecuteChange(new Func<int, bool, bool>(this.CanExecuteChange));
		return new LayoutItem<TTabItem>
		{
			Key = index,
			Value = ttabItem
		};
	}

	// Token: 0x0600C0F2 RID: 49394 RVA: 0x0032DF58 File Offset: 0x0032C158
	private void ToggleEvent(int index)
	{
		this.SwitchLastToggle();
		this.CurrentIndex = index;
		this.ToggleCallBack(index);
	}

	// Token: 0x0600C0F3 RID: 49395 RVA: 0x0032DF74 File Offset: 0x0032C174
	private void SwitchLastToggle()
	{
		if (this.CurrentIndex == -1)
		{
			return;
		}
		ILayoutItem<TTabItem> layoutItem = this.Layout[this.CurrentIndex];
		if (layoutItem != null)
		{
			layoutItem.Value.SetForceSwitch(EToggleState.ETT_UnChecked, false);
		}
	}

	// Token: 0x0600C0F4 RID: 49396 RVA: 0x0032DFB2 File Offset: 0x0032C1B2
	private bool CanExecuteChange(int index, bool forceSwitch)
	{
		return (this.CurrentIndex != index || forceSwitch) && (this.CanExecuteChangeInternal == null || this.CanExecuteChangeInternal(index));
	}

	// Token: 0x0600C0F5 RID: 49397 RVA: 0x0032DFD8 File Offset: 0x0032C1D8
	public void SelectToggleByIndex(int index, bool bIgnored = false)
	{
		if (bIgnored)
		{
			ILayoutItem<TTabItem> layoutItem = this.Layout[this.CurrentIndex];
			if (layoutItem != null)
			{
				layoutItem.Value.SetForceSwitch(EToggleState.ETT_UnChecked, false);
			}
			this.CurrentIndex = -1;
		}
		if (index == this.CurrentIndex)
		{
			return;
		}
		ILayoutItem<TTabItem> layoutItem2 = this.Layout[index];
		if (layoutItem2 != null)
		{
			layoutItem2.Value.SetForceSwitch(EToggleState.ETT_Checked, true);
		}
	}

	// Token: 0x0600C0F6 RID: 49398 RVA: 0x0032E042 File Offset: 0x0032C242
	public int GetSelectedIndex()
	{
		return this.CurrentIndex;
	}

	// Token: 0x0600C0F7 RID: 49399 RVA: 0x0032E04A File Offset: 0x0032C24A
	public void SetCanChange(Func<int, bool> callback)
	{
		this.CanExecuteChangeInternal = callback;
	}

	// Token: 0x04005A6D RID: 23149
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private List<ILayoutItem<TTabItem>> Layout;

	// Token: 0x04005A6E RID: 23150
	private int CurrentIndex = -1;

	// Token: 0x04005A6F RID: 23151
	[Nullable(2)]
	private Func<int, bool> CanExecuteChangeInternal;

	// Token: 0x04005A70 RID: 23152
	public readonly Func<UUIItem, int, TTabItem> ProxyCreate;

	// Token: 0x04005A71 RID: 23153
	public readonly Action<int> ToggleCallBack;

	// Token: 0x02007D0E RID: 32014
	[NullableContext(0)]
	private enum ETabComponent
	{
		// Token: 0x0402AA42 RID: 174658
		Layout
	}
}
