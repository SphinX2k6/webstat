using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E11 RID: 19985
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopBottomInfoItem : UiPanelBase
	{
		// Token: 0x06033ADD RID: 211677 RVA: 0x00CEA1FC File Offset: 0x00CE83FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033ADE RID: 211678 RVA: 0x00CEA2C8 File Offset: 0x00CE84C8
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopBottomInfoItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopBottomInfoItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033ADF RID: 211679 RVA: 0x00CEA30B File Offset: 0x00CE850B
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetExtendToggle(0).RootUIComp);
			this.BindEvent();
		}

		// Token: 0x06033AE0 RID: 211680 RVA: 0x00CEA32F File Offset: 0x00CE852F
		protected override void OnBeforeDestroy()
		{
			this.UnbindEvent();
		}

		// Token: 0x06033AE1 RID: 211681 RVA: 0x00CEA337 File Offset: 0x00CE8537
		protected void BindEvent()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		}

		// Token: 0x06033AE2 RID: 211682 RVA: 0x00CEA356 File Offset: 0x00CE8556
		protected void UnbindEvent()
		{
			base.GetExtendToggle(0).CanExecuteChange.Unbind();
		}

		// Token: 0x06033AE3 RID: 211683 RVA: 0x00CEA36C File Offset: 0x00CE856C
		public void Refresh(TrapDefenseBuildingSlotData data)
		{
			this.SlotData = data;
			TrapDefenseBuildingDevelopItemData slotData = data.GetSlotData();
			this.DragItem.Refresh(slotData);
			this.DragItem.SetUiActive(true);
			base.GetSprite(2).SetUIActive(slotData == null);
			bool uiactive = data.GetSlotData() != null && data.GetSlotData().GetLockInBattle();
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> dragLogic = this.DragLogic;
			if (dragLogic == null)
			{
				return;
			}
			dragLogic.Refresh(slotData);
		}

		// Token: 0x06033AE4 RID: 211684 RVA: 0x00CEA3FD File Offset: 0x00CE85FD
		private bool CanExecuteChange()
		{
			return false;
		}

		// Token: 0x06033AE5 RID: 211685 RVA: 0x00CEA400 File Offset: 0x00CE8600
		public void OnClickedItem()
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb(this.SlotData);
			}
		}

		// Token: 0x06033AE6 RID: 211686 RVA: 0x00CEA41C File Offset: 0x00CE861C
		public void SetSelected(bool isSelected)
		{
			EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x06033AE7 RID: 211687 RVA: 0x00CEA446 File Offset: 0x00CE8646
		public UUIDraggableComponent GetDragComp()
		{
			return this.DragItem.GetDraggableComp();
		}

		// Token: 0x06033AE8 RID: 211688 RVA: 0x00CEA454 File Offset: 0x00CE8654
		public void ResetPosition()
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			TrapDefenseBuildingSlotData slotData = this.SlotData;
			TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData = (slotData != null) ? slotData.GetSlotData() : null;
			bool uiactive = trapDefenseBuildingDevelopItemData != null && trapDefenseBuildingDevelopItemData.GetLockInBattle();
			base.GetItem(4).SetUIActive(uiactive);
			base.GetSprite(2).SetUIActive(this.SlotData.GetSlotData() == null);
			this.DragItem.OnEndDrag();
			if (this.IsOverlaying)
			{
				this.IsOverlaying = false;
				this.LevelSequencePlayer.StopPlayingSequence(false, true);
				this.LevelSequencePlayer.PlaySequencePurely("Normal", false, false, null, null, false);
			}
		}

		// Token: 0x06033AE9 RID: 211689 RVA: 0x00CEA500 File Offset: 0x00CE8700
		public void OnItemOverlay(int _)
		{
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("HighLight", false, null, false);
			this.IsOverlaying = true;
		}

		// Token: 0x06033AEA RID: 211690 RVA: 0x00CEA53C File Offset: 0x00CE873C
		public void OnItemUnOverlay(int _)
		{
			this.IsOverlaying = false;
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("Normal", false, null, false);
		}

		// Token: 0x06033AEB RID: 211691 RVA: 0x00CEA578 File Offset: 0x00CE8778
		public void OnScrollToScrollViewEvent(int _)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			base.GetSprite(2).SetUIActive(false);
		}

		// Token: 0x06033AEC RID: 211692 RVA: 0x00CEA59A File Offset: 0x00CE879A
		public void OnRemoveFromScrollViewEvent(int _)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			base.GetSprite(2).SetUIActive(true);
		}

		// Token: 0x06033AED RID: 211693 RVA: 0x00CEA5BC File Offset: 0x00CE87BC
		public void OnDragBegin(int _)
		{
			base.GetSprite(2).SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
			this.DragItem.OnStartDrag();
		}

		// Token: 0x06033AEE RID: 211694 RVA: 0x00CEA5E4 File Offset: 0x00CE87E4
		public void OnDragEnd(int _)
		{
			TrapDefenseBuildingDevelopItemData slotData = this.SlotData.GetSlotData();
			this.DragItem.OnEndDrag();
			base.GetSprite(2).SetUIActive(slotData == null);
		}

		// Token: 0x06033AEF RID: 211695 RVA: 0x00CEA618 File Offset: 0x00CE8818
		public void SetDragLogic(CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> logic)
		{
			this.DragLogic = logic;
			CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> dragLogic = this.DragLogic;
			TrapDefenseBuildingSlotData slotData = this.SlotData;
			dragLogic.Refresh((slotData != null) ? slotData.GetSlotData() : null);
		}

		// Token: 0x0401DEDC RID: 122588
		protected TrapDefenseBuildingDevelopBottomDragItem DragItem;

		// Token: 0x0401DEDD RID: 122589
		protected TrapDefenseBuildingSlotData SlotData;

		// Token: 0x0401DEDE RID: 122590
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401DEDF RID: 122591
		public Action<TrapDefenseBuildingSlotData> OnClickCb;

		// Token: 0x0401DEE0 RID: 122592
		public Func<TrapDefenseBuildingSlotData, bool> CanExecuteChangeCb;

		// Token: 0x0401DEE1 RID: 122593
		private bool IsOverlaying;

		// Token: 0x0401DEE2 RID: 122594
		protected CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> DragLogic;

		// Token: 0x0200AD86 RID: 44422
		[NullableContext(0)]
		private class EDefine
		{
			// Token: 0x04035E3C RID: 220732
			public const int Toggle = 0;

			// Token: 0x04035E3D RID: 220733
			public const int PanelMove = 1;

			// Token: 0x04035E3E RID: 220734
			public const int SpriteEmpty = 2;

			// Token: 0x04035E3F RID: 220735
			public const int DragItem = 3;

			// Token: 0x04035E40 RID: 220736
			public const int PanelLockState = 4;
		}
	}
}
