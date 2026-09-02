using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062E0 RID: 25312
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisShapePanel : UiPanelBase
	{
		// Token: 0x0603FA91 RID: 260753 RVA: 0x01052430 File Offset: 0x01050630
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603FA92 RID: 260754 RVA: 0x01052469 File Offset: 0x01050669
		public void SetPoolManager(IGridPoolManager manager)
		{
			this.PoolManager = manager;
		}

		// Token: 0x0603FA93 RID: 260755 RVA: 0x01052474 File Offset: 0x01050674
		[NullableContext(2)]
		public void RefreshView(BlockInstance data)
		{
			this.ClearItems();
			if (data == null)
			{
				return;
			}
			UUIItem item = base.GetItem(0);
			UUIItem item2 = base.GetItem(1);
			int num = int.MaxValue;
			int num2 = int.MinValue;
			int num3 = int.MaxValue;
			int num4 = int.MinValue;
			foreach (ValueTuple<int, int> valueTuple in data.Offsets)
			{
				if (valueTuple.Item1 < num)
				{
					num = valueTuple.Item1;
				}
				if (valueTuple.Item1 > num2)
				{
					num2 = valueTuple.Item1;
				}
				if (valueTuple.Item2 < num3)
				{
					num3 = valueTuple.Item2;
				}
				if (valueTuple.Item2 > num4)
				{
					num4 = valueTuple.Item2;
				}
			}
			int num5 = num4 - num3 + 1;
			int num6 = num2 - num + 1;
			float num7 = (float)(5 - num5) / 2f - (float)num3;
			float num8 = (float)(5 - num6) / 2f - (float)num;
			for (int i = 0; i < data.Offsets.Count; i++)
			{
				ValueTuple<int, int> valueTuple2 = data.Offsets[i];
				EGemType gemType = EGemType.None;
				if (data.GemFill == EGemFillType.Full)
				{
					gemType = data.GemType;
				}
				else if (data.GemFill == EGemFillType.Single && i == data.GemOffSet)
				{
					gemType = data.GemType;
				}
				CellInstance data2 = new CellInstance
				{
					ColorId = data.ColorId,
					GemType = gemType
				};
				ValueTuple<float, float> offset = new ValueTuple<float, float>((float)valueTuple2.Item1 + num8, (float)valueTuple2.Item2 + num7);
				this.CreateShape(item, item2, offset, data2);
			}
		}

		// Token: 0x0603FA94 RID: 260756 RVA: 0x01052618 File Offset: 0x01050818
		private void CreateShape(UUIItem itemTemplate, UUIItem list, [TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(0)] ValueTuple<float, float> offset, ICellInstance data)
		{
			float width = itemTemplate.GetWidth();
			float height = itemTemplate.GetHeight();
			ValueTuple<TetrisGridPanel, bool> grid = this.PoolManager.GetGrid(list);
			TetrisGridPanel item = grid.Item1;
			bool item2 = grid.Item2;
			UUIItem uuiitem;
			if (item2)
			{
				uuiitem = Singleton<LguiUtil>.Instance.CopyItem(itemTemplate, list);
			}
			else
			{
				uuiitem = item.GetRootItem();
			}
			float anchorOffsetX = width / 2f + offset.Item2 * width;
			uuiitem.SetAnchorOffsetX(anchorOffsetX);
			float anchorOffsetY = -(height / 2f) - offset.Item1 * height;
			uuiitem.SetAnchorOffsetY(anchorOffsetY);
			if (item2)
			{
				this.CreateItemTemplate(uuiitem, item, data);
				return;
			}
			this.ListItems.Add(item);
			item.SetUiActive(true);
			item.Refresh(data);
		}

		// Token: 0x0603FA95 RID: 260757 RVA: 0x010526C4 File Offset: 0x010508C4
		private UniTask CreateItemTemplate(UUIItem item, TetrisGridPanel itemView, ICellInstance data)
		{
			TetrisShapePanel.<CreateItemTemplate>d__6 <CreateItemTemplate>d__;
			<CreateItemTemplate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItemTemplate>d__.<>4__this = this;
			<CreateItemTemplate>d__.item = item;
			<CreateItemTemplate>d__.itemView = itemView;
			<CreateItemTemplate>d__.data = data;
			<CreateItemTemplate>d__.<>1__state = -1;
			<CreateItemTemplate>d__.<>t__builder.Start<TetrisShapePanel.<CreateItemTemplate>d__6>(ref <CreateItemTemplate>d__);
			return <CreateItemTemplate>d__.<>t__builder.Task;
		}

		// Token: 0x0603FA96 RID: 260758 RVA: 0x0105271F File Offset: 0x0105091F
		public List<TetrisGridPanel> GetAllListItems()
		{
			return this.ListItems;
		}

		// Token: 0x0603FA97 RID: 260759 RVA: 0x01052728 File Offset: 0x01050928
		public void ClearItems()
		{
			foreach (TetrisGridPanel grid in this.ListItems)
			{
				this.PoolManager.ReturnGrid(grid);
			}
			this.ListItems = new List<TetrisGridPanel>();
		}

		// Token: 0x0603FA98 RID: 260760 RVA: 0x0105278C File Offset: 0x0105098C
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			foreach (TetrisGridPanel grid in this.ListItems)
			{
				this.PoolManager.ReturnGrid(grid);
			}
			this.ListItems = new List<TetrisGridPanel>();
		}

		// Token: 0x04023BF2 RID: 146418
		private List<TetrisGridPanel> ListItems = new List<TetrisGridPanel>();

		// Token: 0x04023BF3 RID: 146419
		[Nullable(2)]
		private IGridPoolManager PoolManager;
	}
}
