using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001979 RID: 6521
public class ItemInteractionPanelMainTypeItem : UiPanelBase
{
	// Token: 0x0600BB79 RID: 47993 RVA: 0x0031CBF8 File Offset: 0x0031ADF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnExtendToggleStateChanged))
		};
	}

	// Token: 0x0600BB7A RID: 47994 RVA: 0x0031CC78 File Offset: 0x0031AE78
	protected override void OnStart()
	{
		this.MainTypeId = (int)this.OpenParam;
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		ItemMainType? itemMainType = (instance != null) ? instance.GetItemMainTypeConfig(this.MainTypeId) : null;
		if (itemMainType == null)
		{
			return;
		}
		this.SetSpriteByPath(itemMainType.Value.Icon, base.GetSprite(0), false, null, null);
		this.SetActive(true);
	}

	// Token: 0x0600BB7B RID: 47995 RVA: 0x0031CCEE File Offset: 0x0031AEEE
	protected override void OnBeforeDestroy()
	{
		this.OnExtendToggleStateChangedCallback = null;
	}

	// Token: 0x0600BB7C RID: 47996 RVA: 0x0031CCF7 File Offset: 0x0031AEF7
	public void SetSelected(bool bSelected)
	{
		if (bSelected)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600BB7D RID: 47997 RVA: 0x0031CD1F File Offset: 0x0031AF1F
	public void SetRedDotVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x0600BB7E RID: 47998 RVA: 0x0031CD33 File Offset: 0x0031AF33
	[NullableContext(1)]
	public void BindOnExtendToggleStateChanged(Action<int> onExtendToggleStateChanged)
	{
		this.OnExtendToggleStateChangedCallback = onExtendToggleStateChanged;
	}

	// Token: 0x0600BB7F RID: 47999 RVA: 0x0031CD3C File Offset: 0x0031AF3C
	private void OnExtendToggleStateChanged(EToggleState toggleState)
	{
		if (this.OnExtendToggleStateChangedCallback != null)
		{
			this.OnExtendToggleStateChangedCallback(this.MainTypeId);
		}
	}

	// Token: 0x0400588C RID: 22668
	public int MainTypeId;

	// Token: 0x0400588D RID: 22669
	[Nullable(2)]
	private Action<int> OnExtendToggleStateChangedCallback;

	// Token: 0x02007C8E RID: 31886
	private enum EChildType
	{
		// Token: 0x0402A88E RID: 174222
		MainTypeSprite,
		// Token: 0x0402A88F RID: 174223
		ExtendToggle,
		// Token: 0x0402A890 RID: 174224
		RedDotItem
	}
}
