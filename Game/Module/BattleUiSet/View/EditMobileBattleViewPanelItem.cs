using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUiSet.View
{
	// Token: 0x0200613E RID: 24894
	[NullableContext(2)]
	[Nullable(0)]
	public class EditMobileBattleViewPanelItem : UiPanelBase
	{
		// Token: 0x0603EDF4 RID: 257524 RVA: 0x0101C4A8 File Offset: 0x0101A6A8
		protected override void OnStart()
		{
			PanelItemParams panelItemParams = this.OpenParam as PanelItemParams;
			if (panelItemParams == null)
			{
				throw new InvalidCastException();
			}
			this.Initialize(panelItemParams.PanelItemData, panelItemParams.PanelItem, panelItemParams.BattleViewBaseActor);
		}

		// Token: 0x0603EDF5 RID: 257525 RVA: 0x0101C4E4 File Offset: 0x0101A6E4
		[NullableContext(1)]
		private void Initialize(BattleUiSetPanelItemData panelItemData, UUIItem panelItem, AUIBaseActor battleViewBaseActor)
		{
			this.PanelItemData = panelItemData;
			this.PanelItem = panelItem;
			this.BattleViewBaseActor = battleViewBaseActor;
			this.Draggable = (this.RootActor.GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
			this.Button = (this.RootActor.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent);
			this.ExtendToggle = (this.RootActor.GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle);
			this.AddEvents();
			if (this.PanelItemData != null)
			{
				this.Refresh();
			}
		}

		// Token: 0x0603EDF6 RID: 257526 RVA: 0x0101C57A File Offset: 0x0101A77A
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
			this.PanelItemData = null;
			this.Draggable = null;
			this.Button = null;
			this.ExtendToggle = null;
			this.BattleViewBaseActor = null;
			this.PanelItem = null;
		}

		// Token: 0x0603EDF7 RID: 257527 RVA: 0x0101C5AC File Offset: 0x0101A7AC
		private void AddEvents()
		{
			if (this.Draggable != null)
			{
				this.Draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDrag));
				this.Draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
				this.Draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
			}
			if (this.Button != null)
			{
				this.Button.OnPointDownCallBack.Bind(new Action(this.OnButtonPress));
				this.Button.OnPointUpCallBack.Bind(new Action(this.OnButtonRelease));
			}
			if (this.ExtendToggle != null)
			{
				this.ExtendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnExtendToggleStateChanged));
				this.ExtendToggle.CanExecuteChange.Bind(new Func<bool>(this.OnCheckCanExecuteChange));
			}
		}

		// Token: 0x0603EDF8 RID: 257528 RVA: 0x0101C698 File Offset: 0x0101A898
		private void RemoveEvents()
		{
			if (this.Draggable != null)
			{
				this.Draggable.OnPointerDragCallBack.Unbind();
			}
			if (this.Button != null)
			{
				this.Button.OnPointDownCallBack.Unbind();
				this.Button.OnPointUpCallBack.Unbind();
			}
			if (this.ExtendToggle != null)
			{
				this.ExtendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnExtendToggleStateChanged));
				this.ExtendToggle.CanExecuteChange.Unbind();
			}
		}

		// Token: 0x0603EDF9 RID: 257529 RVA: 0x0101C71C File Offset: 0x0101A91C
		private void OnDrag(ULGUIPointerEventData eventData)
		{
			if (this.PanelItemData == null)
			{
				return;
			}
			if (this.LocalOffsetVector == null)
			{
				return;
			}
			if (ModelBase<BattleUiSetModel>.Instance.GetTouchFingerDataCount() >= 2)
			{
				return;
			}
			FVector localPointInPlane = eventData.GetLocalPointInPlane();
			FVectorDouble fvectorDouble = (eventData.dragComponent.GetOwner() as AUIBaseActor).D_GetActorScale3D();
			double num = (double)(localPointInPlane.X - this.LocalOffsetVector.Value.X) * fvectorDouble.X;
			double num2 = (double)(localPointInPlane.Y - this.LocalOffsetVector.Value.Y) * fvectorDouble.Z;
			if (num == 0.0 && num2 == 0.0)
			{
				return;
			}
			FVectorDouble fvectorDouble2 = new FVectorDouble(num, num2, 0.0);
			this.ResultLocation = this.ResultLocation + fvectorDouble2;
			this.SetRelativeLocation(this.ResultLocation);
			this.LocalOffsetVector = new FVector?(localPointInPlane);
		}

		// Token: 0x0603EDFA RID: 257530 RVA: 0x0101C804 File Offset: 0x0101AA04
		public void RefreshRelativeLocation()
		{
			FVectorDouble relativeLocation = this.GetRelativeLocation();
			this.SetRelativeLocation(relativeLocation);
		}

		// Token: 0x0603EDFB RID: 257531 RVA: 0x0101C820 File Offset: 0x0101AA20
		public void SetRelativeLocation(in FVectorDouble relativeLocation)
		{
			FVectorDouble fvectorDouble = this.ClampBound(relativeLocation);
			this.ResultLocation = fvectorDouble;
			this.PanelItemData.EditOffsetX = this.RootItem.GetAnchorOffsetX();
			this.PanelItemData.EditOffsetY = this.RootItem.GetAnchorOffsetY();
			FHitResult fhitResult = null;
			this.RootItem.D_K2_SetRelativeLocation(fvectorDouble, false, ref fhitResult, false);
		}

		// Token: 0x0603EDFC RID: 257532 RVA: 0x0101C87F File Offset: 0x0101AA7F
		public FVectorDouble GetRelativeLocation()
		{
			return this.ResultLocation;
		}

		// Token: 0x0603EDFD RID: 257533 RVA: 0x0101C887 File Offset: 0x0101AA87
		public void OnSave()
		{
			if (this.PanelItemData == null)
			{
				return;
			}
			this.PanelItemData.EditOffsetX = this.RootItem.GetAnchorOffsetX();
			this.PanelItemData.EditOffsetY = this.RootItem.GetAnchorOffsetY();
		}

		// Token: 0x0603EDFE RID: 257534 RVA: 0x0101C8C0 File Offset: 0x0101AAC0
		private FVectorDouble ClampBound(FVectorDouble relativeLocation)
		{
			double x = this.RootActor.D_GetActorScale3D().X;
			FVector2D pivot = this.RootItem.GetPivot();
			float y = pivot.Y;
			float x2 = pivot.X;
			UUIItem uiitem = this.BattleViewBaseActor.GetUIItem();
			float width = uiitem.Width;
			float height = uiitem.Height;
			float num = width / 2f;
			float num2 = height / 2f;
			double num3 = (double)this.RootItem.Width * x;
			double num4 = (double)this.RootItem.Height * x;
			double min = (double)(-(double)num) + num3 * (double)x2;
			double max = (double)num - num3 * (double)(1f - x2);
			double min2 = (double)(-(double)num2) + num4 * (double)y;
			double max2 = (double)num2 - num4 * (double)(1f - y);
			relativeLocation.X = MathCommon.Clamp(relativeLocation.X, min, max);
			relativeLocation.Y = MathCommon.Clamp(relativeLocation.Y, min2, max2);
			return relativeLocation;
		}

		// Token: 0x0603EDFF RID: 257535 RVA: 0x0101C9A0 File Offset: 0x0101ABA0
		private void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (this.PanelItemData == null)
			{
				return;
			}
			if (!this.PanelItemData.CanEdit)
			{
				return;
			}
			this.LocalOffsetVector = new FVector?(eventData.GetLocalPointInPlane());
			FVector relativeLocation = this.RootItem.RelativeLocation;
			this.ResultLocation = new FVectorDouble(ref relativeLocation);
			ModelBase<BattleUiSetModel>.Instance.SetPanelItemSelected(this.PanelItemData);
		}

		// Token: 0x0603EE00 RID: 257536 RVA: 0x0101C9FE File Offset: 0x0101ABFE
		private void OnDragEnded(ULGUIPointerEventData ulguiPointerEventData)
		{
			this.LocalOffsetVector = null;
		}

		// Token: 0x0603EE01 RID: 257537 RVA: 0x0101CA0C File Offset: 0x0101AC0C
		private void OnButtonPress()
		{
			if (this.PanelItemData == null)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotEdit", Array.Empty<object>());
				return;
			}
			if (!this.PanelItemData.CanEdit)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotEdit", Array.Empty<object>());
				return;
			}
			this.LocalOffsetVector = null;
			ModelBase<BattleUiSetModel>.Instance.SetPanelItemSelected(this.PanelItemData);
		}

		// Token: 0x0603EE02 RID: 257538 RVA: 0x0101CA74 File Offset: 0x0101AC74
		private void OnButtonRelease()
		{
			this.LocalOffsetVector = null;
		}

		// Token: 0x0603EE03 RID: 257539 RVA: 0x0101CA82 File Offset: 0x0101AC82
		private void OnExtendToggleStateChanged(EToggleState state)
		{
			if (this.PanelItemData == null)
			{
				return;
			}
			if (!this.PanelItemData.CanEdit)
			{
				return;
			}
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			ModelBase<BattleUiSetModel>.Instance.SetPanelItemSelected(this.PanelItemData);
		}

		// Token: 0x0603EE04 RID: 257540 RVA: 0x0101CAB0 File Offset: 0x0101ACB0
		private bool OnCheckCanExecuteChange()
		{
			if (this.PanelItemData == null)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotEdit", Array.Empty<object>());
				return false;
			}
			if (!this.PanelItemData.CanEdit)
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotEdit", Array.Empty<object>());
				return false;
			}
			BattleUiSetPanelItemData selectedPanelItemData = ModelBase<BattleUiSetModel>.Instance.SelectedPanelItemData;
			return selectedPanelItemData == null || selectedPanelItemData.ConfigId != this.PanelItemData.ConfigId;
		}

		// Token: 0x0603EE05 RID: 257541 RVA: 0x0101CB24 File Offset: 0x0101AD24
		public void Refresh()
		{
			if (this.PanelItemData == null)
			{
				return;
			}
			float size = this.PanelItemData.Size;
			this.RootItem.SetUIItemScale(new FVector(size));
			this.RootItem.SetAnchorOffsetX(this.PanelItemData.OffsetX);
			this.RootItem.SetAnchorOffsetY(this.PanelItemData.OffsetY);
			this.RootItem.SetUIItemAlpha(this.PanelItemData.Alpha);
			this.RootItem.SetHierarchyIndex(this.PanelItemData.HierarchyIndex);
			FVector relativeLocation = this.RootItem.RelativeLocation;
			this.ResultLocation = new FVectorDouble(ref relativeLocation);
		}

		// Token: 0x0603EE06 RID: 257542 RVA: 0x0101CBC8 File Offset: 0x0101ADC8
		public void Reset()
		{
			if (this.PanelItemData == null)
			{
				return;
			}
			float sourceSize = this.PanelItemData.SourceSize;
			this.RootItem.SetUIItemScale(new FVector(sourceSize));
			this.RootItem.SetAnchorOffsetX(this.PanelItemData.SourceOffsetX);
			this.RootItem.SetAnchorOffsetY(this.PanelItemData.SourceOffsetY);
			this.RootItem.SetUIItemAlpha(this.PanelItemData.SourceAlpha);
			this.RootItem.SetHierarchyIndex(this.PanelItemData.SourceHierarchyIndex);
			FVector relativeLocation = this.RootItem.RelativeLocation;
			this.ResultLocation = new FVectorDouble(ref relativeLocation);
		}

		// Token: 0x0603EE07 RID: 257543 RVA: 0x0101CC6C File Offset: 0x0101AE6C
		public void SetSelected(bool bSelected)
		{
			if (this.ExtendToggle == null)
			{
				return;
			}
			if (bSelected)
			{
				this.ExtendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603EE08 RID: 257544 RVA: 0x0101CC9B File Offset: 0x0101AE9B
		public void ApplyTopIndex()
		{
			base.GetRootItem().SetHierarchyIndex(30);
		}

		// Token: 0x04023473 RID: 144499
		public BattleUiSetPanelItemData PanelItemData;

		// Token: 0x04023474 RID: 144500
		private AUIBaseActor BattleViewBaseActor;

		// Token: 0x04023475 RID: 144501
		protected UUIItem PanelItem;

		// Token: 0x04023476 RID: 144502
		private FVectorDouble ResultLocation;

		// Token: 0x04023477 RID: 144503
		private FVector? LocalOffsetVector;

		// Token: 0x04023478 RID: 144504
		private UUIDraggableComponent Draggable;

		// Token: 0x04023479 RID: 144505
		private UUIButtonComponent Button;

		// Token: 0x0402347A RID: 144506
		private UUIExtendToggle ExtendToggle;
	}
}
