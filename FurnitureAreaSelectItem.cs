using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200107F RID: 4223
public class FurnitureAreaSelectItem : UiPanelBase
{
	// Token: 0x06006DE1 RID: 28129 RVA: 0x001C8578 File Offset: 0x001C6778
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnSelectedInternal))
		};
	}

	// Token: 0x06006DE2 RID: 28130 RVA: 0x001C8679 File Offset: 0x001C6879
	[NullableContext(1)]
	public void Refresh(IFurnitureAreaSelectItemData data)
	{
		this.Data = data;
		this.RefreshToggleState();
		this.RefreshProgress();
		this.RefreshRedDot();
		this.RefreshShowState();
	}

	// Token: 0x06006DE3 RID: 28131 RVA: 0x001C869A File Offset: 0x001C689A
	public void RefreshToggleState()
	{
		if (this.Data == null)
		{
			return;
		}
		base.GetExtendToggle(0).SetToggleState(this.Data.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06006DE4 RID: 28132 RVA: 0x001C86C8 File Offset: 0x001C68C8
	public void RefreshProgress()
	{
		if (this.Data == null)
		{
			return;
		}
		bool flag = this.Data.PlacedSlotCount == this.Data.MaxSlotCount;
		UUIText text = base.GetText(7);
		UUIItem uuiitem = text;
		bool bUseChangeColor = flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "DIY_RegionAtmosphere_Content_1", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.Data.PlacedSlotCount,
			this.Data.MaxSlotCount
		}));
	}

	// Token: 0x06006DE5 RID: 28133 RVA: 0x001C875B File Offset: 0x001C695B
	public void RefreshRedDot()
	{
		if (this.Data == null)
		{
			return;
		}
		base.GetItem(8).SetUIActive(this.Data.RedDotShowState);
	}

	// Token: 0x06006DE6 RID: 28134 RVA: 0x001C8780 File Offset: 0x001C6980
	public void RefreshShowState()
	{
		if (this.Data == null)
		{
			return;
		}
		base.GetItem(1).SetUIActive(!this.Data.IsUnlock);
		base.GetItem(4).SetUIActive(this.Data.IsUnlock);
		this.SetSpriteByPath(this.Data.UnlockAreaIcon, base.GetSprite(5), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), this.Data.AreaName, Array.Empty<object>());
		this.SetSpriteByPath(this.Data.LockAreaIcon, base.GetSprite(2), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.AreaName, Array.Empty<object>());
	}

	// Token: 0x06006DE7 RID: 28135 RVA: 0x001C884F File Offset: 0x001C6A4F
	private void OnSelectedInternal(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.Data == null)
		{
			return;
		}
		this.Data.OnSelected(this.Data.AreaId);
	}

	// Token: 0x0400341F RID: 13343
	[Nullable(2)]
	private IFurnitureAreaSelectItemData Data;
}
