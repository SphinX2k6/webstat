using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B6E RID: 23406
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeliverMediumItemGrid : LoopScrollMediumItemGrid<DeliverSlotData>
	{
		// Token: 0x0603B2FA RID: 242426 RVA: 0x00EF9D98 File Offset: 0x00EF7F98
		protected override void OnRefresh(DeliverSlotData data, bool isSelected, int gridIndex)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (data.HasItem())
			{
				int needCount = data.GetNeedCount();
				int currentCount = data.GetCurrentCount();
				PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
				{
					Data = data,
					ItemConfigId = new int?(data.GetCurrentItemConfigId())
				};
				if (data.GetItemRangeList().Count > 1)
				{
					propMediumItemGrid.ReduceButtonInfo = new LongPressButton
					{
						IsVisible = new bool?(currentCount > 0),
						LongPressConfigId = new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne)
					};
				}
				if (currentCount < needCount)
				{
					propMediumItemGrid.BottomTextId = "DeliverSlotCountNotEnough";
					propMediumItemGrid.BottomTextParameter = new object[]
					{
						currentCount,
						needCount
					};
				}
				else
				{
					MediumItemGridBase mediumItemGridBase = propMediumItemGrid;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(currentCount);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(needCount);
					mediumItemGridBase.BottomText = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				base.Apply<PropMediumItemGrid>(propMediumItemGrid);
				return;
			}
			EmptyItemGrid emptyItemGrid = new EmptyItemGrid();
			emptyItemGrid.Data = data;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetCurrentCount());
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetNeedCount());
			emptyItemGrid.BottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			EmptyItemGrid parameters = emptyItemGrid;
			base.Apply<EmptyItemGrid>(parameters);
		}

		// Token: 0x0603B2FB RID: 242427 RVA: 0x00EF9ECB File Offset: 0x00EF80CB
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603B2FC RID: 242428 RVA: 0x00EF9ED5 File Offset: 0x00EF80D5
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603B2FD RID: 242429 RVA: 0x00EF9EDF File Offset: 0x00EF80DF
		protected override bool OnCanExecuteChange()
		{
			return false;
		}

		// Token: 0x0603B2FE RID: 242430 RVA: 0x00EF9EE4 File Offset: 0x00EF80E4
		protected override void OnExtendToggleClicked()
		{
			DeliverSlotData deliverSlotData = this.Data as DeliverSlotData;
			if (!deliverSlotData.HasItem())
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(deliverSlotData.GetCurrentItemConfigId(), true, null);
		}
	}
}
