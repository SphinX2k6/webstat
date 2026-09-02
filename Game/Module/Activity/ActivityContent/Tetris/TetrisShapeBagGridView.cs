using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062DD RID: 25309
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		2
	})]
	public class TetrisShapeBagGridView : GridProxyAbstract<BlockInstance>
	{
		// Token: 0x0603FA7D RID: 260733 RVA: 0x01051F22 File Offset: 0x01050122
		[NullableContext(1)]
		public void SetPoolManager(IGridPoolManager manager)
		{
			this.PoolManager = manager;
			if (this.Shape != null)
			{
				this.Shape.SetPoolManager(manager);
			}
		}

		// Token: 0x0603FA7E RID: 260734 RVA: 0x01051F40 File Offset: 0x01050140
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603FA7F RID: 260735 RVA: 0x01051F9C File Offset: 0x0105019C
		protected override UniTask OnBeforeStartAsync()
		{
			TetrisShapeBagGridView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TetrisShapeBagGridView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FA80 RID: 260736 RVA: 0x01051FE0 File Offset: 0x010501E0
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.OnPointerBeginDragCallBack.Bind((ULGUIPointerEventData eventData) => this.OnBeginDrag(eventData, false));
			}
			UUIButtonComponent button2 = base.GetButton(0);
			if (button2 != null)
			{
				button2.OnPointerDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnDrag));
			}
			UUIButtonComponent button3 = base.GetButton(0);
			if (button3 != null)
			{
				button3.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnEndDrag));
			}
			UUIButtonComponent button4 = base.GetButton(0);
			if (button4 != null)
			{
				button4.OnPointDownCallBack.Bind(new Action(this.OnPointerDown));
			}
			UUIButtonComponent button5 = base.GetButton(0);
			if (button5 != null)
			{
				button5.OnPointUpCallBack.Bind(new Action(this.OnPointerUp));
			}
			UUIButtonComponent button6 = base.GetButton(0);
			if (button6 != null)
			{
				button6.OnPointCancelCallBack.Bind(new Action(this.OnPointerUp));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnMotorMusicSortDragCancel, new Action(this.OnTetrisShapeBagGridViewDragCancel));
			this.ViewSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603FA81 RID: 260737 RVA: 0x010520EC File Offset: 0x010502EC
		public void PlayRefreshAnimation()
		{
			this.ViewSequencePlayer.PlayLevelSequenceByName("Refresh", false, null, false);
		}

		// Token: 0x0603FA82 RID: 260738 RVA: 0x01052114 File Offset: 0x01050314
		public override void Refresh(BlockInstance data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.Index = gridIndex;
			this.Shape.RefreshView(data);
			this.UpdateDragEnabled();
		}

		// Token: 0x0603FA83 RID: 260739 RVA: 0x01052138 File Offset: 0x01050338
		private void UpdateDragEnabled()
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.RootUIComp.Get().SetRaycastTarget(this.Data != null);
			}
		}

		// Token: 0x0603FA84 RID: 260740 RVA: 0x0105216C File Offset: 0x0105036C
		public void SetInteractAble(bool interactAble)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.RootUIComp.Get().SetRaycastTarget(interactAble && this.Data != null);
			}
		}

		// Token: 0x0603FA85 RID: 260741 RVA: 0x010521A6 File Offset: 0x010503A6
		private bool CanDrag()
		{
			return this.Data != null;
		}

		// Token: 0x0603FA86 RID: 260742 RVA: 0x010521B4 File Offset: 0x010503B4
		private bool OnBeginDrag(ULGUIPointerEventData eventData, bool isInit = false)
		{
			if (!this.CanDrag())
			{
				return false;
			}
			if (this.IsGamePadDragging && !isInit)
			{
				return true;
			}
			this.IsEndDragHandled = false;
			TetrisShapePanel shape = this.Shape;
			if (shape != null)
			{
				shape.SetUiActive(false);
			}
			return this.OnViewBeginDrag != null && this.OnViewBeginDrag(eventData, this.Data);
		}

		// Token: 0x0603FA87 RID: 260743 RVA: 0x0105220D File Offset: 0x0105040D
		private bool OnDrag(ULGUIPointerEventData eventData)
		{
			return this.OnViewDrag != null && this.OnViewDrag(eventData);
		}

		// Token: 0x0603FA88 RID: 260744 RVA: 0x01052228 File Offset: 0x01050428
		private bool OnEndDrag(ULGUIPointerEventData eventData)
		{
			if (this.IsEndDragHandled)
			{
				return false;
			}
			this.IsEndDragHandled = true;
			TetrisShapePanel shape = this.Shape;
			if (shape != null)
			{
				shape.SetUiActive(true);
			}
			ULGUIPointerEventData arg = this.IsCancelDragPending ? null : eventData;
			this.IsCancelDragPending = false;
			return this.OnViewEndDrag != null && this.OnViewEndDrag(arg, this.Index, this.Data);
		}

		// Token: 0x0603FA89 RID: 260745 RVA: 0x01052290 File Offset: 0x01050490
		private void OnPointerDown()
		{
			if (this.IsGamePadDragging)
			{
				this.IsGamePadDragging = false;
				TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
				if (tetrisPlayView != null)
				{
					tetrisPlayView.ShowCloseBtn();
				}
				ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
				this.OnEndDrag(pointerEventData);
				return;
			}
			this.IsGamePadDragging = ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging();
			if (this.IsGamePadDragging)
			{
				ULGUIPointerEventData pointerEventData2 = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
				TetrisPlayView tetrisPlayView2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
				if (tetrisPlayView2 != null)
				{
					tetrisPlayView2.HideCloseBtn();
				}
				this.OnBeginDrag(pointerEventData2, true);
				this.OnDrag(pointerEventData2);
			}
		}

		// Token: 0x0603FA8A RID: 260746 RVA: 0x01052334 File Offset: 0x01050534
		private void OnPointerUp()
		{
			if (!this.IsGamePadDragging)
			{
				return;
			}
			this.IsGamePadDragging = false;
			TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
			if (tetrisPlayView != null)
			{
				tetrisPlayView.ShowCloseBtn();
			}
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
			this.OnEndDrag(pointerEventData);
		}

		// Token: 0x0603FA8B RID: 260747 RVA: 0x01052384 File Offset: 0x01050584
		private void OnTetrisShapeBagGridViewDragCancel()
		{
			if (this.IsGamePadDragging)
			{
				this.IsGamePadDragging = false;
				this.IsCancelDragPending = true;
				TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
				if (tetrisPlayView != null)
				{
					tetrisPlayView.ShowCloseBtn();
				}
				ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
				this.OnEndDrag(pointerEventData);
			}
		}

		// Token: 0x0603FA8C RID: 260748 RVA: 0x010523DA File Offset: 0x010505DA
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer viewSequencePlayer = this.ViewSequencePlayer;
			if (viewSequencePlayer != null)
			{
				viewSequencePlayer.Clear();
			}
			this.ViewSequencePlayer = null;
			this.IsGamePadDragging = false;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMotorMusicSortDragCancel, new Action(this.OnTetrisShapeBagGridViewDragCancel));
		}

		// Token: 0x04023BE4 RID: 146404
		private TetrisShapePanel Shape;

		// Token: 0x04023BE5 RID: 146405
		private BlockInstance Data;

		// Token: 0x04023BE6 RID: 146406
		private int Index = -1;

		// Token: 0x04023BE7 RID: 146407
		private IGridPoolManager PoolManager;

		// Token: 0x04023BE8 RID: 146408
		private LevelSequencePlayer ViewSequencePlayer;

		// Token: 0x04023BE9 RID: 146409
		private bool IsGamePadDragging;

		// Token: 0x04023BEA RID: 146410
		private bool IsCancelDragPending;

		// Token: 0x04023BEB RID: 146411
		private bool IsEndDragHandled;

		// Token: 0x04023BEC RID: 146412
		public Func<ULGUIPointerEventData, BlockInstance, bool> OnViewBeginDrag;

		// Token: 0x04023BED RID: 146413
		public Func<ULGUIPointerEventData, bool> OnViewDrag;

		// Token: 0x04023BEE RID: 146414
		public Func<ULGUIPointerEventData, int, BlockInstance, bool> OnViewEndDrag;
	}
}
