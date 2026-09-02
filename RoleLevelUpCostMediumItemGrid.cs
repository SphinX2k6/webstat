using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x0200288B RID: 10379
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleLevelUpCostMediumItemGrid : LoopScrollMediumItemGrid<ISelectedData>
{
	// Token: 0x060148C9 RID: 84169 RVA: 0x005B2AA8 File Offset: 0x005B0CA8
	protected override void OnRefresh(ISelectedData data, bool isSelected, int gridIndex)
	{
		int selectedCount = data.SelectedCount;
		int count = data.Count;
		string text;
		if (data.Count != 0)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(selectedCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			text = "0";
		}
		string bottomText = text;
		PropMediumItemGrid parameters = new PropMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.ItemId),
			ReduceButtonInfo = new LongPressButton
			{
				IsVisible = new bool?(selectedCount > 0),
				LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
			},
			BottomText = bottomText
		};
		base.Apply<PropMediumItemGrid>(parameters);
	}

	// Token: 0x060148CA RID: 84170 RVA: 0x005B2B51 File Offset: 0x005B0D51
	public UUIItem GetUiItemForGuide()
	{
		UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
		return ((itemGridExtendToggle != null) ? itemGridExtendToggle.GetOwner().GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem;
	}
}
