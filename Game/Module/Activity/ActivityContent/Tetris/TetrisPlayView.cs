using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062D3 RID: 25299
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisPlayView : UiViewBase, IGridPoolManager
	{
		// Token: 0x0603FA20 RID: 260640 RVA: 0x0104F4CC File Offset: 0x0104D6CC
		public TetrisPlayView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FA21 RID: 260641 RVA: 0x0104F4EC File Offset: 0x0104D6EC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem))
			};
		}

		// Token: 0x0603FA22 RID: 260642 RVA: 0x0104F684 File Offset: 0x0104D884
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisPlayView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisPlayView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FA23 RID: 260643 RVA: 0x0104F6C7 File Offset: 0x0104D8C7
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603FA24 RID: 260644 RVA: 0x0104F6E5 File Offset: 0x0104D8E5
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603FA25 RID: 260645 RVA: 0x0104F704 File Offset: 0x0104D904
		protected override void OnStart()
		{
			this.Param = (int)this.OpenParam;
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedCloseButton));
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickHelpBtn));
			this.PoolContainer = base.GetItem(2);
			this.GenerateShapeList = new GenericLayout<TetrisShapeBagGridView, BlockInstance>(base.GetVerticalLayout(2), new Func<TetrisShapeBagGridView>(this.UpdateItem), null, false, true);
			this.GemProgressList = new GenericLayout<TetrisGemProgressGrid, ITetrisGemProgressData>(base.GetVerticalLayout(12), new Func<TetrisGemProgressGrid>(this.UpdateProgressItem), null, false, true);
			this.CellSize = new ValueTuple<float, float>?(new ValueTuple<float, float>(base.GetItem(5).GetWidth(), base.GetItem(5).GetHeight()));
			this.TetrisPlayController = new TetrisPlayController();
			this.TetrisPlayController.OnDataUpdate = new Action<bool, bool>(this.OnLogicUpdate);
			this.TetrisPlayController.OnRefillHandShapes = delegate()
			{
				foreach (TetrisShapeBagGridView tetrisShapeBagGridView in this.ShapeBagViews)
				{
					tetrisShapeBagGridView.PlayRefreshAnimation();
				}
			};
			this.TetrisPlayController.OnPlaceAnimation = new Action<List<ValueTuple<int, int>>, TTimerAction>(this.OnPlaceAnimation);
			this.TetrisPlayController.OnRemoveAnimation = new Action<List<ValueTuple<int, int, int>>, List<ValueTuple<int, int, int>>, List<int>, List<int>, bool, Action>(this.OnRemoveAnimation);
			this.TetrisPlayController.OnCleanAnimation = new Action<Action>(this.OnCleanAnimation);
			this.TetrisPlayController.OnLoseBoardAnimation = delegate(Action onComplete)
			{
				if (this.CurrentDragShape != null)
				{
					TetrisBoardPanel board = this.Board;
					if (board != null)
					{
						board.ClearDragHighlight();
					}
					this.CurrentDragShape = null;
					TetrisDragItemPanel dragItem = this.DragItem;
					if (dragItem != null)
					{
						dragItem.SetUiActive(false);
					}
				}
				this.IsAnimating = true;
				this.SetShapesInteractAble();
				TetrisBoardPanel board2 = this.Board;
				if (board2 == null)
				{
					return;
				}
				board2.PlayLoseRefreshAnimation(this.TetrisPlayController.GetGridModel(), delegate(float delta)
				{
					onComplete();
					this.IsAnimating = false;
					this.SetShapesInteractAble();
				});
			};
			this.TetrisPlayController.OnCombo = new Action<IComboData>(this.OnCombo);
			this.TetrisPlayController.InitLevel(this.Param);
			this.TetrisPlayController.RefillHandShapes();
		}

		// Token: 0x0603FA26 RID: 260646 RVA: 0x0104F8A2 File Offset: 0x0104DAA2
		[NullableContext(2)]
		private void OnPlaceAnimation([TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int>> positions, TTimerAction onComplete = null)
		{
			TetrisBoardPanel board = this.Board;
			if (board == null)
			{
				return;
			}
			board.PlayPlaceAnimation(positions, onComplete);
		}

		// Token: 0x0603FA27 RID: 260647 RVA: 0x0104F8B8 File Offset: 0x0104DAB8
		private void OnRemoveAnimation([TupleElementNames(new string[]
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
		})] List<ValueTuple<int, int, int>> sealChangePositions, List<int> clearedRows, List<int> clearedCols, bool hasCleanAnimation, [Nullable(2)] Action onComplete = null)
		{
			this.IsAnimating = true;
			this.SetShapesInteractAble();
			TTimerAction onComplete2 = delegate(float _)
			{
				TetrisComboPanel comboPanel = this.ComboPanel;
				if (comboPanel != null)
				{
					comboPanel.SetUiActive(false);
				}
				Action onComplete3 = onComplete;
				if (onComplete3 != null)
				{
					onComplete3();
				}
				if (hasCleanAnimation)
				{
					return;
				}
				this.IsAnimating = false;
				this.SetShapesInteractAble();
			};
			TetrisBoardPanel board = this.Board;
			if (board == null)
			{
				return;
			}
			board.PlayRemoveAnimation(positions, sealChangePositions, clearedRows, clearedCols, onComplete2);
		}

		// Token: 0x0603FA28 RID: 260648 RVA: 0x0104F910 File Offset: 0x0104DB10
		[NullableContext(2)]
		private void OnCleanAnimation(Action onComplete = null)
		{
			this.IsAnimating = true;
			this.SetShapesInteractAble();
			TetrisBoardPanel board = this.Board;
			if (board == null)
			{
				return;
			}
			board.PlayCleanAnimation(delegate(float _)
			{
				Action onComplete2 = onComplete;
				if (onComplete2 != null)
				{
					onComplete2();
				}
				this.IsAnimating = false;
				this.SetShapesInteractAble();
			});
		}

		// Token: 0x0603FA29 RID: 260649 RVA: 0x0104F95A File Offset: 0x0104DB5A
		private void OnCombo(IComboData data)
		{
			this.AdjustComboPanelPosition(data.ClearedRows, data.ClearedCols);
			TetrisComboPanel comboPanel = this.ComboPanel;
			if (comboPanel == null)
			{
				return;
			}
			comboPanel.Refresh(data);
		}

		// Token: 0x0603FA2A RID: 260650 RVA: 0x0104F980 File Offset: 0x0104DB80
		private void AdjustComboPanelPosition(List<int> clearedRows, List<int> clearedCols)
		{
			if (this.ComboPanel == null || this.CellSize == null)
			{
				return;
			}
			float num = 3.5f;
			float num2 = 3.5f;
			float anchorOffsetX = 0f;
			float anchorOffsetY = 0f;
			if (clearedRows.Count > 0)
			{
				List<int> list = new List<int>(clearedRows);
				list.Sort();
				float num3 = (float)list[list.Count / 2];
				anchorOffsetX = 0f;
				float num4 = -(num3 - num) * this.CellSize.Value.Item2;
				float num5 = ((float)new Random().NextDouble() - 0.5f) * 2f * this.CellSize.Value.Item2;
				anchorOffsetY = num4 + num5;
			}
			else if (clearedCols.Count > 0)
			{
				List<int> list2 = new List<int>(clearedCols);
				list2.Sort();
				float num6 = (float)list2[list2.Count / 2];
				anchorOffsetY = 0f;
				float num7 = (num6 - num2) * this.CellSize.Value.Item1;
				float num8 = ((float)new Random().NextDouble() - 0.5f) * 2f * this.CellSize.Value.Item1;
				anchorOffsetX = num7 + num8;
			}
			this.ComboPanel.GetRootItem().SetAnchorOffsetX(anchorOffsetX);
			this.ComboPanel.GetRootItem().SetAnchorOffsetY(anchorOffsetY);
		}

		// Token: 0x0603FA2B RID: 260651 RVA: 0x0104FAB4 File Offset: 0x0104DCB4
		protected override void OnBeforeShow()
		{
			TetrisPlayView.<>c__DisplayClass27_0 CS$<>8__locals1 = new TetrisPlayView.<>c__DisplayClass27_0();
			this.RefreshCount();
			if (this.TetrisPlayController.GetGameMode() != EGameMode.Infinite)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsTargetView, this.TetrisPlayController.GetCurrentTarget(), null);
			}
			CS$<>8__locals1.config = this.TetrisPlayController.GetCurrentConfig();
			TetrisPlayView.<>c__DisplayClass27_0 CS$<>8__locals2 = CS$<>8__locals1;
			int num = (CS$<>8__locals2.config != null) ? CS$<>8__locals2.config.GetValueOrDefault().FlowIdLength : 0;
			List<string> list = new List<string>();
			for (int i = 0; i < num; i++)
			{
				list.Add(CS$<>8__locals1.config.Value.FlowId(i));
			}
			bool flag = list.Count > 0;
			this.TetrisPlayController.SetUseDialogWinOnly(flag);
			if (flag)
			{
				TetrisPlayView.<>c__DisplayClass27_0 CS$<>8__locals3 = CS$<>8__locals1;
				int? num2 = (CS$<>8__locals3.config != null) ? new int?(CS$<>8__locals3.config.GetValueOrDefault().ConditionGroup) : null;
				ChatPopViewData param = new ChatPopViewData
				{
					FlowId = list,
					Condition = num2.GetValueOrDefault(),
					ParentViewId = new int?(base.GetViewId()),
					OnAllShownCallback = delegate()
					{
						int? num3 = (CS$<>8__locals1.config != null) ? new int?(CS$<>8__locals1.config.GetValueOrDefault().Id) : null;
						if (num3 == null)
						{
							return;
						}
						Singleton<EventSystem>.Instance.Emit<EArcadeGameplayType, int>(EEventName.OnArcadeGameplayFinish, EArcadeGameplayType.TetrisBoardGame, num3.Value);
						Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisPlayView, null);
					}
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ChatPopView, param, null);
			}
			this.OnLogicUpdate(true, false);
		}

		// Token: 0x0603FA2C RID: 260652 RVA: 0x0104FBFE File Offset: 0x0104DDFE
		public void RefreshEndlessLoading()
		{
			if (this.TetrisPlayController.GetGameMode() == EGameMode.Infinite)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsEndLessStartView, null, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsTargetView, this.TetrisPlayController.GetCurrentTarget(), null);
		}

		// Token: 0x0603FA2D RID: 260653 RVA: 0x0104FC3C File Offset: 0x0104DE3C
		private void RefreshCount()
		{
			Tetris? tetris;
			int? num = (this.TetrisPlayController.GetCurrentConfig() != null) ? new int?(tetris.GetValueOrDefault().BlockNum) : null;
			if (num.GetValueOrDefault() == 2)
			{
				base.GetItem(9).SetUIActive(true);
				base.GetItem(10).SetUIActive(false);
				base.GetItem(11).SetUIActive(false);
				return;
			}
			if (num.GetValueOrDefault() == 3)
			{
				base.GetItem(10).SetUIActive(true);
				base.GetItem(9).SetUIActive(false);
				base.GetItem(11).SetUIActive(false);
				return;
			}
			if (num.GetValueOrDefault() == 4)
			{
				base.GetItem(11).SetUIActive(true);
				base.GetItem(9).SetUIActive(false);
				base.GetItem(10).SetUIActive(false);
			}
		}

		// Token: 0x0603FA2E RID: 260654 RVA: 0x0104FD1C File Offset: 0x0104DF1C
		public TetrisPlayController GetTetrisPlayController()
		{
			return this.TetrisPlayController;
		}

		// Token: 0x0603FA2F RID: 260655 RVA: 0x0104FD24 File Offset: 0x0104DF24
		private void RefreshScroller([Nullable(new byte[]
		{
			1,
			2
		})] List<BlockInstance> shapes)
		{
			this.GenerateShapeList.RefreshByData(shapes, null, false);
		}

		// Token: 0x0603FA30 RID: 260656 RVA: 0x0104FD34 File Offset: 0x0104DF34
		private void RefreshBoard(TetrisBoardData gridModel, bool isInit, bool isTakeBack = false)
		{
			this.Board.RefreshView(gridModel, isInit, isTakeBack);
		}

		// Token: 0x0603FA31 RID: 260657 RVA: 0x0104FD44 File Offset: 0x0104DF44
		private void OnLogicUpdate(bool isInit = false, bool isTakeBack = false)
		{
			TetrisBoardData gridModel = this.TetrisPlayController.GetGridModel();
			List<BlockInstance> handShapes = this.TetrisPlayController.GetHandShapes();
			this.RefreshScroller(handShapes);
			this.RefreshBoard(gridModel, isInit, isTakeBack);
			if (this.TetrisPlayController.GetGameMode() == EGameMode.Score)
			{
				this.RefreshScore();
				return;
			}
			if (this.TetrisPlayController.GetGameMode() == EGameMode.GemCollection)
			{
				this.RefreshGem();
				return;
			}
			if (this.TetrisPlayController.GetGameMode() == EGameMode.Infinite)
			{
				this.RefreshInfinite();
			}
		}

		// Token: 0x0603FA32 RID: 260658 RVA: 0x0104FDB8 File Offset: 0x0104DFB8
		[NullableContext(2)]
		private bool OnBeginDrag(ULGUIPointerEventData eventData, BlockInstance shapeData)
		{
			if (eventData == null)
			{
				return false;
			}
			if (shapeData == null)
			{
				return false;
			}
			this.CurrentDragShape = shapeData;
			this.SetShapesInteractAble();
			Vector2D vector2D = Vector2D.Create();
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(eventData.pointerPosition, vector2D);
			TetrisDragItemPanel dragItem = this.DragItem;
			if (dragItem != null)
			{
				dragItem.GetRootItem().SetAnchorOffsetX((float)vector2D.X);
			}
			TetrisDragItemPanel dragItem2 = this.DragItem;
			if (dragItem2 != null)
			{
				dragItem2.GetRootItem().SetAnchorOffsetY((float)vector2D.Y);
			}
			TetrisDragItemPanel dragItem3 = this.DragItem;
			if (dragItem3 != null)
			{
				dragItem3.SetUiActive(true);
			}
			TetrisDragItemPanel dragItem4 = this.DragItem;
			if (dragItem4 != null)
			{
				dragItem4.RefreshView(shapeData);
			}
			return true;
		}

		// Token: 0x0603FA33 RID: 260659 RVA: 0x0104FE54 File Offset: 0x0104E054
		[NullableContext(2)]
		private bool OnDrag(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return false;
			}
			Vector2D vector2D = Vector2D.Create();
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(eventData.pointerPosition, vector2D);
			TetrisDragItemPanel dragItem = this.DragItem;
			if (dragItem != null)
			{
				dragItem.GetRootItem().SetAnchorOffsetX((float)vector2D.X);
			}
			TetrisDragItemPanel dragItem2 = this.DragItem;
			if (dragItem2 != null)
			{
				dragItem2.GetRootItem().SetAnchorOffsetY((float)vector2D.Y);
			}
			this.UpdateDragHighlight(vector2D);
			return true;
		}

		// Token: 0x0603FA34 RID: 260660 RVA: 0x0104FEC0 File Offset: 0x0104E0C0
		private void UpdateDragHighlight(Vector2D curDragPos)
		{
			if (this.CurrentDragShape == null)
			{
				return;
			}
			ValueTuple<int, int>? valueTuple = this.CalcBoardRawColumnByPosition(curDragPos);
			if ((valueTuple == null && this.LastDragHighlightRowColumn == null) || (valueTuple != null && this.LastDragHighlightRowColumn != null && valueTuple.Value.Item1 == this.LastDragHighlightRowColumn.Value.Item1 && valueTuple.Value.Item2 == this.LastDragHighlightRowColumn.Value.Item2))
			{
				return;
			}
			this.LastDragHighlightRowColumn = ((valueTuple != null) ? new ValueTuple<int, int>?(new ValueTuple<int, int>(valueTuple.Value.Item1, valueTuple.Value.Item2)) : null);
			TetrisBoardPanel board = this.Board;
			if (board != null)
			{
				board.ClearDragHighlight();
			}
			if (valueTuple == null)
			{
				return;
			}
			ValueTuple<int, int> valueTuple2 = Singleton<TetrisUtils>.Instance.FindAnchorOffset(this.CurrentDragShape.Offsets);
			int num = valueTuple.Value.Item1 - valueTuple2.Item1;
			int num2 = valueTuple.Value.Item2 - valueTuple2.Item2;
			if (this.TetrisPlayController.CanPlaceShape(this.CurrentDragShape.Offsets, num, num2))
			{
				List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
				foreach (ValueTuple<int, int> valueTuple3 in this.CurrentDragShape.Offsets)
				{
					list.Add(new ValueTuple<int, int>(num + valueTuple3.Item1, num2 + valueTuple3.Item2));
				}
				ValueTuple<List<int>, List<int>> clearAbleRowsAndColsIfPlace = this.TetrisPlayController.GetClearAbleRowsAndColsIfPlace(list);
				TetrisBoardPanel board2 = this.Board;
				if (board2 == null)
				{
					return;
				}
				board2.ShowDragHighlight(list, this.CurrentDragShape.ColorId, clearAbleRowsAndColsIfPlace.Item1, clearAbleRowsAndColsIfPlace.Item2);
			}
		}

		// Token: 0x0603FA35 RID: 260661 RVA: 0x010500A0 File Offset: 0x0104E2A0
		[NullableContext(2)]
		private bool OnEndDrag(ULGUIPointerEventData eventData, int index, BlockInstance shapeData)
		{
			TetrisBoardPanel board = this.Board;
			if (board != null)
			{
				board.ClearDragHighlight();
			}
			this.CurrentDragShape = null;
			this.LastDragHighlightRowColumn = null;
			this.SetShapesInteractAble();
			if (eventData == null || shapeData == null)
			{
				TetrisDragItemPanel dragItem = this.DragItem;
				if (dragItem != null)
				{
					dragItem.SetUiActive(false);
				}
				return true;
			}
			Vector2D vector2D = Vector2D.Create();
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(eventData.pointerPosition, vector2D);
			ValueTuple<int, int>? valueTuple = this.CalcBoardRawColumnByPosition(vector2D);
			TetrisDragItemPanel dragItem2 = this.DragItem;
			if (dragItem2 != null)
			{
				dragItem2.SetUiActive(false);
			}
			if (valueTuple == null)
			{
				return false;
			}
			ValueTuple<int, int> valueTuple2 = Singleton<TetrisUtils>.Instance.FindAnchorOffset(shapeData.Offsets);
			this.TetrisPlayController.OnPlayerDropShape(index, valueTuple.Value.Item1 - valueTuple2.Item1, valueTuple.Value.Item2 - valueTuple2.Item2);
			return true;
		}

		// Token: 0x0603FA36 RID: 260662 RVA: 0x01050174 File Offset: 0x0104E374
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		public ValueTuple<int, int>? CalcBoardRawColumnByPosition([Nullable(1)] Vector2D pos)
		{
			double num = (double)4f;
			float num2 = 4f;
			int num3 = (int)Math.Floor(pos.X / (double)this.CellSize.Value.Item1 + (double)num2);
			int num4 = (int)Math.Floor(num - pos.Y / (double)this.CellSize.Value.Item2);
			if (num3 < 0 || num3 >= 8 || num4 < 0 || num4 >= 8)
			{
				return null;
			}
			return new ValueTuple<int, int>?(new ValueTuple<int, int>(num4, num3));
		}

		// Token: 0x0603FA37 RID: 260663 RVA: 0x010501F8 File Offset: 0x0104E3F8
		private TetrisShapeBagGridView UpdateItem()
		{
			TetrisShapeBagGridView tetrisShapeBagGridView = new TetrisShapeBagGridView();
			tetrisShapeBagGridView.OnViewBeginDrag = new Func<ULGUIPointerEventData, BlockInstance, bool>(this.OnBeginDrag);
			tetrisShapeBagGridView.OnViewDrag = new Func<ULGUIPointerEventData, bool>(this.OnDrag);
			tetrisShapeBagGridView.OnViewEndDrag = new Func<ULGUIPointerEventData, int, BlockInstance, bool>(this.OnEndDrag);
			tetrisShapeBagGridView.SetPoolManager(this);
			this.ShapeBagViews.Add(tetrisShapeBagGridView);
			return tetrisShapeBagGridView;
		}

		// Token: 0x0603FA38 RID: 260664 RVA: 0x01050258 File Offset: 0x0104E458
		private void SetShapesInteractAble()
		{
			bool interactAble = !this.IsAnimating && this.CurrentDragShape == null;
			foreach (TetrisShapeBagGridView tetrisShapeBagGridView in this.ShapeBagViews)
			{
				tetrisShapeBagGridView.SetInteractAble(interactAble);
			}
		}

		// Token: 0x0603FA39 RID: 260665 RVA: 0x010502C0 File Offset: 0x0104E4C0
		private TetrisGemProgressGrid UpdateProgressItem()
		{
			return new TetrisGemProgressGrid();
		}

		// Token: 0x0603FA3A RID: 260666 RVA: 0x010502C8 File Offset: 0x0104E4C8
		private void RefreshInfinite()
		{
			TetrisScoreProgressPanel scoreProgressItem = this.ScoreProgressItem;
			if (scoreProgressItem != null)
			{
				scoreProgressItem.SetUiActive(true);
			}
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIText text = base.GetText(14);
			if (text != null)
			{
				text.SetText(ControllerBase<TetrisController>.Instance.GetHighestScore().ToString(), true);
			}
			this.ScoreProgressItem.RefreshInfinite(this.TetrisPlayController.GetCurrentScore());
		}

		// Token: 0x0603FA3B RID: 260667 RVA: 0x01050338 File Offset: 0x0104E538
		private void RefreshScore()
		{
			TetrisScoreProgressPanel scoreProgressItem = this.ScoreProgressItem;
			if (scoreProgressItem != null)
			{
				scoreProgressItem.SetUiActive(true);
			}
			int targetScore;
			this.TetrisPlayController.GetCurrentTarget().TryGetValue(0, out targetScore);
			this.ScoreProgressItem.Refresh(this.TetrisPlayController.GetCurrentScore(), targetScore);
		}

		// Token: 0x0603FA3C RID: 260668 RVA: 0x01050384 File Offset: 0x0104E584
		private void RefreshGem()
		{
			Dictionary<int, int> currentTarget = this.TetrisPlayController.GetCurrentTarget();
			if (currentTarget == null)
			{
				return;
			}
			List<ITetrisGemProgressData> list = new List<ITetrisGemProgressData>();
			foreach (KeyValuePair<int, int> keyValuePair in currentTarget)
			{
				list.Add(new TetrisGemProgressData
				{
					GemId = keyValuePair.Key,
					CurrentGemCount = this.TetrisPlayController.GetCurrentGem(keyValuePair.Key),
					TargetGemCount = keyValuePair.Value
				});
			}
			this.GemProgressList.RefreshByData(list, null, false);
		}

		// Token: 0x0603FA3D RID: 260669 RVA: 0x0105042C File Offset: 0x0104E62C
		private void OnClickedCloseButton()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TetrisQuitConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap.Add(1, new Action(this.<OnClickedCloseButton>g__cancelCallback|45_0));
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.<OnClickedCloseButton>g__confirmCallback|45_1));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603FA3E RID: 260670 RVA: 0x01050488 File Offset: 0x0104E688
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.TetrisPlayController.GetCurrentConfig().Value.HelpId);
		}

		// Token: 0x0603FA3F RID: 260671 RVA: 0x010504BC File Offset: 0x0104E6BC
		[return: TupleElementNames(new string[]
		{
			"Grid",
			"IsNew"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<TetrisGridPanel, bool> GetGrid(UUIItem poolContainer)
		{
			if (this.GridPool.Count > 0)
			{
				TetrisGridPanel tetrisGridPanel = this.GridPool[this.GridPool.Count - 1];
				this.GridPool.RemoveAt(this.GridPool.Count - 1);
				tetrisGridPanel.GetRootItem().K2_AttachToComponent(poolContainer, null, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
				return new ValueTuple<TetrisGridPanel, bool>(tetrisGridPanel, false);
			}
			return new ValueTuple<TetrisGridPanel, bool>(new TetrisGridPanel(0, 0), true);
		}

		// Token: 0x0603FA40 RID: 260672 RVA: 0x01050534 File Offset: 0x0104E734
		public void ReturnGrid(TetrisGridPanel grid)
		{
			grid.SetUiActive(false);
			if (this.PoolContainer != null)
			{
				UUIItem rootItem = grid.GetRootItem();
				if (rootItem != null)
				{
					rootItem.K2_AttachToComponent(this.PoolContainer, null, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
				}
			}
			this.GridPool.Add(grid);
		}

		// Token: 0x0603FA41 RID: 260673 RVA: 0x01050580 File Offset: 0x0104E780
		public void TetrisRewardClose()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisPlayView, null);
			if (TetrisUtils.IsHardLevel(this.TetrisPlayController.GetCurrentConfig().Value) || TetrisUtils.IsEggLevel(this.TetrisPlayController.GetCurrentConfig().Value))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisLevelDetailView, null);
			}
		}

		// Token: 0x0603FA42 RID: 260674 RVA: 0x010505E1 File Offset: 0x0104E7E1
		public void HideCloseBtn()
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetCloseBtnActive(false);
		}

		// Token: 0x0603FA43 RID: 260675 RVA: 0x010505F4 File Offset: 0x0104E7F4
		public void ShowCloseBtn()
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetCloseBtnActive(true);
		}

		// Token: 0x0603FA44 RID: 260676 RVA: 0x01050608 File Offset: 0x0104E808
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			if (this.TetrisPlayController != null)
			{
				this.TetrisPlayController.ClearCallBack();
			}
			foreach (TetrisGridPanel tetrisGridPanel in this.GridPool)
			{
				tetrisGridPanel.Destroy(null);
			}
			this.GridPool = new List<TetrisGridPanel>();
		}

		// Token: 0x0603FA45 RID: 260677 RVA: 0x01050680 File Offset: 0x0104E880
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			if (!TetrisUtils.IsActivityLevel(this.TetrisPlayController.GetCurrentConfig().Value))
			{
				return;
			}
			if (closeActivities.Contains(ControllerBase<ActivityTetrisController>.Instance.ActivityId))
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
			}
		}

		// Token: 0x0603FA46 RID: 260678 RVA: 0x010506C4 File Offset: 0x0104E8C4
		public void OpenLoseConfirm()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TetrisLoseConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, new Action(this.<OpenLoseConfirm>g__cancelCallback|54_0));
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.<OpenLoseConfirm>g__confirmCallback|54_1));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603FA47 RID: 260679 RVA: 0x01050718 File Offset: 0x0104E918
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			string a = configParams[0];
			if (a == "Grid")
			{
				int row = int.Parse(configParams[1]);
				int column = int.Parse(configParams[2]);
				TetrisBoardPanel board = this.Board;
				UUIItem uuiitem;
				if (board == null)
				{
					uuiitem = null;
				}
				else
				{
					TetrisBoardGridPanel gridPanel = board.GetGridPanel(row, column);
					uuiitem = ((gridPanel != null) ? gridPanel.GetRootItem() : null);
				}
				UUIItem uuiitem2 = uuiitem;
				if (uuiitem2 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem2,
					uuiitem2
				};
			}
			else
			{
				if (!(a == "Shape"))
				{
					return null;
				}
				int index = int.Parse(configParams[1]);
				GenericLayout<TetrisShapeBagGridView, BlockInstance> generateShapeList = this.GenerateShapeList;
				UUIItem uuiitem3 = (generateShapeList != null) ? generateShapeList.GetItemByIndex(index) : null;
				if (uuiitem3 == null)
				{
					return null;
				}
				return new UUIItem[]
				{
					uuiitem3,
					uuiitem3
				};
			}
		}

		// Token: 0x0603FA4A RID: 260682 RVA: 0x0105089B File Offset: 0x0104EA9B
		[CompilerGenerated]
		private void <OnClickedCloseButton>g__cancelCallback|45_0()
		{
			this.TetrisPlayController.DoResetTetris();
		}

		// Token: 0x0603FA4B RID: 260683 RVA: 0x010508A8 File Offset: 0x0104EAA8
		[CompilerGenerated]
		private void <OnClickedCloseButton>g__confirmCallback|45_1()
		{
			if (this.TetrisPlayController.GetGameMode() == EGameMode.Infinite)
			{
				ControllerBase<TetrisController>.Instance.SendCompleteRequest(this.TetrisPlayController.GenInfiniteRequestMsg(), null);
				EndLessEndOpenParam endLessEndOpenParam = new EndLessEndOpenParam();
				TetrisPlayController tetrisPlayController = this.TetrisPlayController;
				endLessEndOpenParam.Score = ((tetrisPlayController != null) ? tetrisPlayController.GetCurrentScore() : 0);
				endLessEndOpenParam.IsQuit = true;
				EndLessEndOpenParam param = endLessEndOpenParam;
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisTipsEndLessEndView, param, null);
			}
			else
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisPlayView, null);
			}
			this.TetrisPlayController.SendResultLogData(2);
		}

		// Token: 0x0603FA4C RID: 260684 RVA: 0x01050930 File Offset: 0x0104EB30
		[CompilerGenerated]
		private void <OpenLoseConfirm>g__cancelCallback|54_0()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TetrisPlayView, null);
			if (this.TetrisPlayController.GetGameMode() == EGameMode.Infinite)
			{
				ControllerBase<TetrisController>.Instance.SendCompleteRequest(this.TetrisPlayController.GenInfiniteRequestMsg(), null);
			}
			this.TetrisPlayController.SendResultLogData(0);
		}

		// Token: 0x0603FA4D RID: 260685 RVA: 0x0105097D File Offset: 0x0104EB7D
		[CompilerGenerated]
		private void <OpenLoseConfirm>g__confirmCallback|54_1()
		{
			if (this.TetrisPlayController.GetGameMode() == EGameMode.Infinite)
			{
				ControllerBase<TetrisController>.Instance.SendCompleteRequest(this.TetrisPlayController.GenInfiniteRequestMsg(), null);
			}
			this.TetrisPlayController.OnLoseReset();
		}

		// Token: 0x04023BA6 RID: 146342
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023BA7 RID: 146343
		[Nullable(new byte[]
		{
			1,
			1,
			2
		})]
		private GenericLayout<TetrisShapeBagGridView, BlockInstance> GenerateShapeList;

		// Token: 0x04023BA8 RID: 146344
		private GenericLayout<TetrisGemProgressGrid, ITetrisGemProgressData> GemProgressList;

		// Token: 0x04023BA9 RID: 146345
		[Nullable(2)]
		private TetrisDragItemPanel DragItem;

		// Token: 0x04023BAA RID: 146346
		[Nullable(2)]
		private TetrisBoardPanel Board;

		// Token: 0x04023BAB RID: 146347
		[Nullable(2)]
		private TetrisComboPanel ComboPanel;

		// Token: 0x04023BAC RID: 146348
		[TupleElementNames(new string[]
		{
			"Width",
			"Height"
		})]
		[Nullable(0)]
		private ValueTuple<float, float>? CellSize;

		// Token: 0x04023BAD RID: 146349
		[Nullable(2)]
		private TetrisScoreProgressPanel ScoreProgressItem;

		// Token: 0x04023BAE RID: 146350
		[Nullable(2)]
		private TetrisPlayController TetrisPlayController;

		// Token: 0x04023BAF RID: 146351
		private int Param;

		// Token: 0x04023BB0 RID: 146352
		[Nullable(2)]
		private BlockInstance CurrentDragShape;

		// Token: 0x04023BB1 RID: 146353
		[TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		[Nullable(0)]
		private ValueTuple<int, int>? LastDragHighlightRowColumn;

		// Token: 0x04023BB2 RID: 146354
		private bool IsAnimating;

		// Token: 0x04023BB3 RID: 146355
		private readonly List<TetrisShapeBagGridView> ShapeBagViews = new List<TetrisShapeBagGridView>();

		// Token: 0x04023BB4 RID: 146356
		private List<TetrisGridPanel> GridPool = new List<TetrisGridPanel>();

		// Token: 0x04023BB5 RID: 146357
		[Nullable(2)]
		private UUIItem PoolContainer;
	}
}
