using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062BB RID: 25275
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisBoardPanel : UiPanelBase
	{
		// Token: 0x0603F9A7 RID: 260519 RVA: 0x0104C8D3 File Offset: 0x0104AAD3
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0603F9A8 RID: 260520 RVA: 0x0104C90C File Offset: 0x0104AB0C
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisBoardPanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisBoardPanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9A9 RID: 260521 RVA: 0x0104C950 File Offset: 0x0104AB50
		[NullableContext(2)]
		public void RefreshView(TetrisBoardData data, bool isInit, bool isTakeBack = false)
		{
			if (data == null)
			{
				return;
			}
			this.CurrentBoardData = data;
			TetrisCellData[][] cells = data.Cells;
			bool flag = isInit || isTakeBack;
			if (flag)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_cube_efx_up");
			}
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					TetrisBoardGridPanel itemView;
					if (this.ListItems.TryGetValue(TetrisUtils.GenPosKey(i, j), out itemView))
					{
						TetrisCellData tetrisCellData = cells[i][j];
						if (tetrisCellData.IsOccupied)
						{
							itemView.Refresh(tetrisCellData);
							if (flag)
							{
								itemView.HideGrid();
								float num = 3.5f;
								float num2 = 3.5f;
								float num3 = Math.Abs((float)i - num) + Math.Abs((float)j - num2);
								TetrisCellData capturedCellData = tetrisCellData;
								TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
								{
									itemView.Refresh(capturedCellData);
									itemView.PlayAnim("Start", null);
								}, (float)((int)(50f * num3)), null, null, true, 1f);
							}
						}
						else
						{
							int item = TetrisUtils.GenPosKey(i, j);
							if (!this.RemovingPositions.Contains(item))
							{
								itemView.HideGrid();
							}
						}
					}
				}
			}
		}

		// Token: 0x0603F9AA RID: 260522 RVA: 0x0104CA80 File Offset: 0x0104AC80
		public void PlayLoseRefreshAnimation(TetrisBoardData data, TTimerAction onComplete)
		{
			this.CurrentBoardData = data;
			TetrisCellData[][] cells = data.Cells;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					TetrisBoardGridPanel tetrisBoardGridPanel;
					if (this.ListItems.TryGetValue(TetrisUtils.GenPosKey(i, j), out tetrisBoardGridPanel) && tetrisBoardGridPanel != null)
					{
						tetrisBoardGridPanel.RefreshWithColorId(tetrisBoardGridPanel.ColorId);
					}
				}
			}
			int num = 0;
			for (int k = 0; k < 8; k++)
			{
				for (int l = 0; l < 8; l++)
				{
					int key = TetrisUtils.GenPosKey(k, l);
					TetrisBoardGridPanel itemView;
					if (this.ListItems.TryGetValue(key, out itemView))
					{
						int num2 = (k + l + 1) * 25;
						if (num2 > num)
						{
							num = num2;
						}
						TetrisCellData cellData = cells[k][l];
						TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
						{
							TetrisBoardGridPanel itemView;
							itemView.RefreshWithColorId(cellData.ColorId);
							itemView = itemView;
							if (itemView == null)
							{
								return;
							}
							itemView.PlayAnim("Start", null);
						}, (float)num2, null, null, true, 1f);
					}
				}
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_cube_efx_stone");
			if (onComplete != null)
			{
				int num3 = 700;
				TimerSystem.GameplayTimeInstance.Delay(onComplete, (float)(num + num3), null, null, true, 1f);
			}
		}

		// Token: 0x0603F9AB RID: 260523 RVA: 0x0104CBA4 File Offset: 0x0104ADA4
		[NullableContext(2)]
		public void PlayPlaceAnimation([TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int>> positions, TTimerAction onComplete = null)
		{
			foreach (ValueTuple<int, int> valueTuple in positions)
			{
				int key = TetrisUtils.GenPosKey(valueTuple.Item1, valueTuple.Item2);
				TetrisBoardGridPanel tetrisBoardGridPanel;
				if (this.ListItems.TryGetValue(key, out tetrisBoardGridPanel))
				{
					tetrisBoardGridPanel.PlayAnim("Up", null);
				}
			}
			if (onComplete != null)
			{
				int num = 500;
				TimerSystem.GameplayTimeInstance.Delay(onComplete, (float)num, null, null, true, 1f);
			}
		}

		// Token: 0x0603F9AC RID: 260524 RVA: 0x0104CC3C File Offset: 0x0104AE3C
		public void PlayRemoveAnimation([TupleElementNames(new string[]
		{
			"Row",
			"Column",
			"ColorId"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int, int>> positions, [TupleElementNames(new string[]
		{
			"Row",
			"Column",
			"ColorId"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int, int>> sealChangePositions, List<int> clearedRows, List<int> clearedCols, [Nullable(2)] TTimerAction onComplete = null)
		{
			TetrisBoardPanel.<>c__DisplayClass9_0 CS$<>8__locals1 = new TetrisBoardPanel.<>c__DisplayClass9_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.rowSet = new HashSet<int>(clearedRows);
			CS$<>8__locals1.colSet = new HashSet<int>(clearedCols);
			CS$<>8__locals1.maxDelay = 0;
			foreach (ValueTuple<int, int, int> pos in positions)
			{
				CS$<>8__locals1.<PlayRemoveAnimation>g__playOne|0(pos, false);
			}
			foreach (ValueTuple<int, int, int> pos2 in sealChangePositions)
			{
				CS$<>8__locals1.<PlayRemoveAnimation>g__playOne|0(pos2, true);
			}
			if (onComplete != null)
			{
				int num = 1000;
				TimerSystem.GameplayTimeInstance.Delay(onComplete, (float)(CS$<>8__locals1.maxDelay + num), null, null, true, 1f);
			}
		}

		// Token: 0x0603F9AD RID: 260525 RVA: 0x0104CD20 File Offset: 0x0104AF20
		[NullableContext(2)]
		public void PlayCleanAnimation(TTimerAction onComplete = null)
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int key = TetrisUtils.GenPosKey(i, j);
					TetrisBoardGridPanel itemView;
					if (this.ListItems.TryGetValue(key, out itemView))
					{
						int num2 = (i + j + 1) * 25;
						if (num2 > num)
						{
							num = num2;
						}
						TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
						{
							itemView.HideGrid();
							itemView.PlayAnim("Clean", null);
						}, (float)num2, null, null, true, 1f);
					}
				}
			}
			if (onComplete != null)
			{
				int num3 = 700;
				TimerSystem.GameplayTimeInstance.Delay(onComplete, (float)(num + num3), null, null, true, 1f);
			}
		}

		// Token: 0x0603F9AE RID: 260526 RVA: 0x0104CDC4 File Offset: 0x0104AFC4
		[NullableContext(2)]
		public void ShowDragHighlight([TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int>> positions, int colorId, List<int> clearAbleRows = null, List<int> clearAbleCols = null)
		{
			if (clearAbleRows == null)
			{
				clearAbleRows = new List<int>();
			}
			if (clearAbleCols == null)
			{
				clearAbleCols = new List<int>();
			}
			foreach (ValueTuple<int, int> valueTuple in positions)
			{
				int num = TetrisUtils.GenPosKey(valueTuple.Item1, valueTuple.Item2);
				TetrisBoardGridPanel tetrisBoardGridPanel;
				if (this.ListItems.TryGetValue(num, out tetrisBoardGridPanel))
				{
					this.DragHighlightedPositions.Add(num);
					tetrisBoardGridPanel.ShowDragFrame(colorId);
				}
			}
			HashSet<int> hashSet = new HashSet<int>(clearAbleRows);
			HashSet<int> hashSet2 = new HashSet<int>(clearAbleCols);
			foreach (KeyValuePair<int, TetrisBoardGridPanel> keyValuePair in this.ListItems)
			{
				TetrisBoardGridPanel value = keyValuePair.Value;
				bool flag = hashSet.Contains(value.Row);
				bool flag2 = hashSet2.Contains(value.Column);
				value.SetMaskItemActive(flag || flag2);
			}
		}

		// Token: 0x0603F9AF RID: 260527 RVA: 0x0104CEDC File Offset: 0x0104B0DC
		public void ClearDragHighlight()
		{
			foreach (int key in this.DragHighlightedPositions)
			{
				TetrisBoardGridPanel tetrisBoardGridPanel;
				if (this.ListItems.TryGetValue(key, out tetrisBoardGridPanel))
				{
					tetrisBoardGridPanel.HideDragFrame();
					TetrisCellData cellData = this.GetCellData(tetrisBoardGridPanel.Row, tetrisBoardGridPanel.Column);
					if (cellData != null && cellData.IsOccupied)
					{
						tetrisBoardGridPanel.Refresh(cellData);
					}
					else
					{
						tetrisBoardGridPanel.HideGrid();
					}
				}
			}
			this.DragHighlightedPositions.Clear();
			foreach (KeyValuePair<int, TetrisBoardGridPanel> keyValuePair in this.ListItems)
			{
				keyValuePair.Value.SetMaskItemActive(false);
			}
		}

		// Token: 0x0603F9B0 RID: 260528 RVA: 0x0104CFC0 File Offset: 0x0104B1C0
		[NullableContext(2)]
		private TetrisCellData GetCellData(int row, int column)
		{
			if (this.CurrentBoardData == null)
			{
				return null;
			}
			return this.CurrentBoardData.Cells[row][column];
		}

		// Token: 0x0603F9B1 RID: 260529 RVA: 0x0104CFDC File Offset: 0x0104B1DC
		[NullableContext(2)]
		public TetrisBoardGridPanel GetGridPanel(int row, int column)
		{
			TetrisBoardGridPanel result;
			if (this.ListItems.TryGetValue(TetrisUtils.GenPosKey(row, column), out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0603F9B2 RID: 260530 RVA: 0x0104D004 File Offset: 0x0104B204
		private UniTask CreateShape(UUIItem itemTemplate, UUIItem list, [TupleElementNames(new string[]
		{
			"R",
			"C"
		})] [Nullable(0)] ValueTuple<int, int> offset)
		{
			TetrisBoardPanel.<CreateShape>d__15 <CreateShape>d__;
			<CreateShape>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateShape>d__.<>4__this = this;
			<CreateShape>d__.itemTemplate = itemTemplate;
			<CreateShape>d__.list = list;
			<CreateShape>d__.offset = offset;
			<CreateShape>d__.<>1__state = -1;
			<CreateShape>d__.<>t__builder.Start<TetrisBoardPanel.<CreateShape>d__15>(ref <CreateShape>d__);
			return <CreateShape>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9B3 RID: 260531 RVA: 0x0104D060 File Offset: 0x0104B260
		private UniTask CreateItemTemplate(UUIItem item, TetrisBoardGridPanel itemView)
		{
			TetrisBoardPanel.<CreateItemTemplate>d__16 <CreateItemTemplate>d__;
			<CreateItemTemplate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateItemTemplate>d__.<>4__this = this;
			<CreateItemTemplate>d__.item = item;
			<CreateItemTemplate>d__.itemView = itemView;
			<CreateItemTemplate>d__.<>1__state = -1;
			<CreateItemTemplate>d__.<>t__builder.Start<TetrisBoardPanel.<CreateItemTemplate>d__16>(ref <CreateItemTemplate>d__);
			return <CreateItemTemplate>d__.<>t__builder.Task;
		}

		// Token: 0x0603F9B4 RID: 260532 RVA: 0x0104D0B3 File Offset: 0x0104B2B3
		protected override void OnBeforeDestroy()
		{
			this.ListItems.Clear();
		}

		// Token: 0x04023B22 RID: 146210
		private readonly Dictionary<int, TetrisBoardGridPanel> ListItems = new Dictionary<int, TetrisBoardGridPanel>();

		// Token: 0x04023B23 RID: 146211
		private readonly HashSet<int> DragHighlightedPositions = new HashSet<int>();

		// Token: 0x04023B24 RID: 146212
		private readonly HashSet<int> RemovingPositions = new HashSet<int>();

		// Token: 0x04023B25 RID: 146213
		[Nullable(2)]
		private TetrisBoardData CurrentBoardData;
	}
}
