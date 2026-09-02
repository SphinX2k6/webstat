using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Utils;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010A9 RID: 4265
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FurnitureSlotScrollItem : GridProxyAbstract<FurnitureSlotScrollItemData>
{
	// Token: 0x06006F2C RID: 28460 RVA: 0x001CEB40 File Offset: 0x001CCD40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItemToggle))
		};
	}

	// Token: 0x06006F2D RID: 28461 RVA: 0x001CEBFF File Offset: 0x001CCDFF
	[NullableContext(1)]
	public override void Refresh(FurnitureSlotScrollItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshItemToggle();
		this.RefreshRedDot();
		this.RefreshLine();
		this.RefreshTagIndex();
		this.RefreshIcon();
	}

	// Token: 0x06006F2E RID: 28462 RVA: 0x001CEC26 File Offset: 0x001CCE26
	public void RefreshItemToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		FurnitureSlotScrollItemData data = this.Data;
		extendToggle.SetToggleState((data != null && data.IsSelected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06006F2F RID: 28463 RVA: 0x001CEC50 File Offset: 0x001CCE50
	public void RefreshRedDot()
	{
		UUIItem item = base.GetItem(2);
		FurnitureSlotScrollItemData data = this.Data;
		item.SetUIActive(data != null && data.RedDotShowState);
	}

	// Token: 0x06006F30 RID: 28464 RVA: 0x001CEC70 File Offset: 0x001CCE70
	public void RefreshLine()
	{
		UUIItem item = base.GetItem(5);
		FurnitureSlotScrollItemData data = this.Data;
		item.SetUIActive(data != null && data.LineShowState);
	}

	// Token: 0x06006F31 RID: 28465 RVA: 0x001CEC90 File Offset: 0x001CCE90
	public void RefreshTagIndex()
	{
		FurnitureSlotScrollItemData data = this.Data;
		bool flag = data != null && data.ShowTagIndex;
		base.GetItem(3).SetUIActive(flag);
		if (flag)
		{
			FurnitureSlotScrollItemData data2 = this.Data;
			string newText = RomanNumeralUtils.ConvertToRoman((data2 != null) ? data2.TagIndex : 0);
			base.GetText(4).SetText(newText, true);
		}
	}

	// Token: 0x06006F32 RID: 28466 RVA: 0x001CECE8 File Offset: 0x001CCEE8
	public void RefreshIcon()
	{
		FurnitureConfig instance = ConfigBase<FurnitureConfig>.Instance;
		FurnitureSlotScrollItemData data = this.Data;
		FurnitureDiyTag? furnitureTagConfig = instance.GetFurnitureTagConfig((data != null) ? data.TagId : 0);
		if (furnitureTagConfig == null)
		{
			return;
		}
		FurnitureSlotScrollItemData data2 = this.Data;
		string path = (((data2 != null) ? data2.PlacedFurnitureId : 0) > 0) ? furnitureTagConfig.Value.OccupiedIcon : furnitureTagConfig.Value.EmptyIcon;
		this.SetSpriteByPath(path, base.GetSprite(1), false, null, null);
	}

	// Token: 0x06006F33 RID: 28467 RVA: 0x001CED6B File Offset: 0x001CCF6B
	private void OnClickItemToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onItemSelected = this.OnItemSelected;
			if (onItemSelected == null)
			{
				return;
			}
			onItemSelected(base.GridIndex);
		}
	}

	// Token: 0x04003535 RID: 13621
	private FurnitureSlotScrollItemData Data;

	// Token: 0x04003536 RID: 13622
	public Action<int> OnItemSelected;
}
