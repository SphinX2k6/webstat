using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E61 RID: 20065
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopMainView : UiViewBase
	{
		// Token: 0x06033D9C RID: 212380 RVA: 0x00CF7A0C File Offset: 0x00CF5C0C
		public TrapDefenseBuildingDevelopMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033D9D RID: 212381 RVA: 0x00CF7A64 File Offset: 0x00CF5C64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickReset));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D9E RID: 212382 RVA: 0x00CF7C14 File Offset: 0x00CF5E14
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopMainView.<OnBeforeStartAsync>d__35 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopMainView.<OnBeforeStartAsync>d__35>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D9F RID: 212383 RVA: 0x00CF7C58 File Offset: 0x00CF5E58
		protected override void OnStart()
		{
			this.ScrollView = new GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData>(base.GetScrollViewWithScrollbar(1), new Func<TrapDefenseBuildingDevelopTypeItem>(this.CreateItemGrid), null, false, null);
			this.CreateTabListData();
			this.LongPressTime = (float)ConfigBase<TrapDefenseConfig>.Instance.GetScrollerPressTime();
			this.ScrollerMoveDistance = (float)ConfigBase<TrapDefenseConfig>.Instance.GetScrollerMoveDistance();
			this.BeforeLongPressTime = (float)ConfigBase<TrapDefenseConfig>.Instance.GetBeforeScrollerLongPressTime();
			bool uiactive = !this.IsInDungeon && ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetCanAllReset();
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive);
			}
			if (this.IsInDungeon)
			{
				this.BottomDragLogic = this.BottomItem.InitBottomDragLogic();
				this.BottomItemList = this.BottomItem.InitBottomDragItem();
				for (int i = 0; i < this.BottomDragLogic.Count; i++)
				{
					CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic = this.BottomDragLogic[i];
					TrapDefenseBuildingDevelopBottomInfoItem @object = this.BottomItemList[i];
					commonDragItemLogic.SetOnDragAnimationStartFunction(new Action<int>(@object.OnDragBegin));
					commonDragItemLogic.SetOnDragAnimationEndFunction(new Action<int>(@object.OnDragEnd));
					commonDragItemLogic.SetOnOverlayCallBack(new Action<int>(@object.OnItemOverlay));
					commonDragItemLogic.SetOnUnOverlayCallBack(new Action<int>(@object.OnItemUnOverlay));
					commonDragItemLogic.SetMoveToScrollViewCallBack(new Action<int>(@object.OnScrollToScrollViewEvent));
					commonDragItemLogic.SetRemoveFromScrollViewCallBack(new Action<int>(@object.OnRemoveFromScrollViewEvent));
				}
				foreach (CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic2 in this.BottomDragLogic)
				{
					commonDragItemLogic2.SetOnClickCallBack(new Action<int>(this.OnClickAndRefreshView));
					commonDragItemLogic2.SetOnClickFailCallBack(new Action<int>(this.OnClickFail));
					commonDragItemLogic2.SetDragCheckItem(this.BottomDragLogic);
					commonDragItemLogic2.SetDragSuccessCallBack(new Action<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopDragDataItem, bool>(this.OnDragEndCallBack));
					commonDragItemLogic2.SetPointerDownCallBack(new Action<int>(this.OnStartDragCallBack));
					commonDragItemLogic2.SetOnBeginDragCall(new Action<int>(this.OnBeginDrag));
					commonDragItemLogic2.SetEndDragWhenOnScrollViewCallBack(new Action<int, TrapDefenseBuildingDevelopItemData>(this.OnMoveToScrollViewDragEndCallBack));
				}
				CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> dragLogic = this.DragLogic;
				if (dragLogic != null)
				{
					dragLogic.SetDragCheckItem(this.BottomDragLogic);
				}
				ITrapDefenseDevelopOpenParam trapDefenseDevelopOpenParam = this.OpenParam as ITrapDefenseDevelopOpenParam;
				if (ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData()[trapDefenseDevelopOpenParam.SelectedIndex].GetSlotData() == null)
				{
					this.SetCurrentSelectBottomIndex(trapDefenseDevelopOpenParam.SelectedIndex);
				}
				else
				{
					TrapDefenseBuildingSlotData firstEmptySlot = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetFirstEmptySlot();
					this.SetCurrentSelectBottomIndex((firstEmptySlot == null) ? trapDefenseDevelopOpenParam.SelectedIndex : firstEmptySlot.GetIndex());
				}
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TrapDefenseBuildingDevelopMainViewStart, this.IsInDungeon);
		}

		// Token: 0x06033DA0 RID: 212384 RVA: 0x00CF7F1C File Offset: 0x00CF611C
		protected override void OnAfterShow()
		{
			foreach (CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic in this.BottomDragLogic)
			{
				commonDragItemLogic.SetScrollViewItem(base.GetScrollViewWithScrollbar(1).RootUIComp);
			}
		}

		// Token: 0x06033DA1 RID: 212385 RVA: 0x00CF7F80 File Offset: 0x00CF6180
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingDevelopSelectUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnClickItem));
			Singleton<EventSystem>.Instance.Add<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingBottomSelectUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnBottomClick));
			Singleton<EventSystem>.Instance.Add<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingPreviewSelectUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnPreviewClick));
			Singleton<EventSystem>.Instance.Add<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseOnDevelopUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnDevelopResetAll, new Action(this.OnResetAll));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnSlotUpdate, new Action(this.OnUpdateSlot));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseLevelUpPointUpdate, new Action(this.RefreshCurrency));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnBranchUpdate, new Action(this.OnOrganNetUpdate));
		}

		// Token: 0x06033DA2 RID: 212386 RVA: 0x00CF8070 File Offset: 0x00CF6270
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingDevelopSelectUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnClickItem));
			Singleton<EventSystem>.Instance.Remove<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingBottomSelectUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnBottomClick));
			Singleton<EventSystem>.Instance.Remove<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseBuildingPreviewSelectUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnPreviewClick));
			Singleton<EventSystem>.Instance.Remove<TrapDefenseBuildingDevelopItemData>(EEventName.TrapDefenseOnDevelopUpdate, new Action<TrapDefenseBuildingDevelopItemData>(this.OnDataUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnDevelopResetAll, new Action(this.OnResetAll));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnSlotUpdate, new Action(this.OnUpdateSlot));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseLevelUpPointUpdate, new Action(this.RefreshCurrency));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnBranchUpdate, new Action(this.OnOrganNetUpdate));
		}

		// Token: 0x06033DA3 RID: 212387 RVA: 0x00CF815D File Offset: 0x00CF635D
		protected override void OnBeforeShow()
		{
			this.RefreshCurrency();
			this.RefreshTabListAsync();
		}

		// Token: 0x06033DA4 RID: 212388 RVA: 0x00CF816C File Offset: 0x00CF636C
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.SetCurRecommendLevel(null);
			this.ClearDragClickTick();
			this.ClearCheckPointerUpTick();
			this.TabComponent = null;
			this.DetailInfo = null;
			this.BottomItem = null;
			if (this.IsInDungeon)
			{
				ControllerBase<TrapDefenseController>.Instance.RefreshTrapDefenseMainView();
			}
		}

		// Token: 0x06033DA5 RID: 212389 RVA: 0x00CF81BC File Offset: 0x00CF63BC
		protected void InitTabComponent()
		{
			this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData)), new Action(this.OnCloseClicked), false);
			this.LastClickTime = 0.0;
			this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
			this.TabComponent.SetHelpButtonShowState(true);
			this.TabComponent.SetHelpButtonCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(403);
			});
		}

		// Token: 0x06033DA6 RID: 212390 RVA: 0x00CF8270 File Offset: 0x00CF6470
		protected UniTask InitDragItem()
		{
			TrapDefenseBuildingDevelopMainView.<InitDragItem>d__43 <InitDragItem>d__;
			<InitDragItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDragItem>d__.<>4__this = this;
			<InitDragItem>d__.<>1__state = -1;
			<InitDragItem>d__.<>t__builder.Start<TrapDefenseBuildingDevelopMainView.<InitDragItem>d__43>(ref <InitDragItem>d__);
			return <InitDragItem>d__.<>t__builder.Task;
		}

		// Token: 0x06033DA7 RID: 212391 RVA: 0x00CF82B4 File Offset: 0x00CF64B4
		private void OnGridPointerDown(TrapDefenseBuildingDevelopTypeGridItem item, TrapDefenseBuildingDevelopItemData data)
		{
			if (!this.IsInDungeon)
			{
				return;
			}
			this.ClearDragClickTick();
			this.PressTime = 0f;
			this.FillPressTime = 0f;
			this.CheckState = true;
			this.CurrentPressItem = item;
			FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
			this.OnPressPositionX = worldPointInPlane.X;
			this.OnPressPositionY = worldPointInPlane.Z;
			this.AfterLongPressState = false;
			this.DragItem.UpdateItem(data);
			this.DragLogic.Refresh(data);
			this.SetPressItemShowState(true);
			this.SetPressItemAlpha(0f);
			this.SetBarAmount(0f);
			this.DragClickTick = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnDragTick), "TrapDefenseDevelopDragTick", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x06033DA8 RID: 212392 RVA: 0x00CF8384 File Offset: 0x00CF6584
		private void OnGridPointerUp(TrapDefenseBuildingDevelopTypeGridItem item, TrapDefenseBuildingDevelopItemData data)
		{
			if (!this.IsInDungeon)
			{
				return;
			}
			this.ClearDragClickTick();
			base.GetScrollViewWithScrollbar(1).SetEnable(true);
			CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> dragLogic = this.DragLogic;
			if (dragLogic != null)
			{
				dragLogic.ClearStayingItem();
			}
			this.DragItem.SetUiActive(false);
			this.SetPressItemShowState(false);
			this.CurrentDragIndex = 999;
			if (item == null && data == null)
			{
				this.ResetPosition(true);
			}
		}

		// Token: 0x06033DA9 RID: 212393 RVA: 0x00CF83EC File Offset: 0x00CF65EC
		private void RefreshLongPressItemPosition()
		{
			FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
			Vector2D vector2D = Vector2D.Create((double)pointerEventDataPosition.Value.X, (double)pointerEventDataPosition.Value.Y);
			Vector2D vector2D2 = vector2D;
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
			float num = ConfigBase<TrapDefenseConfig>.Instance.GetScrollerOffsetX() * (float)ConfigBase<TrapDefenseConfig>.Instance.GetScrollerOffsetXDir();
			float num2 = ConfigBase<TrapDefenseConfig>.Instance.GetScrollerOffsetY() * (float)ConfigBase<TrapDefenseConfig>.Instance.GetScrollerOffsetYDir();
			double num3 = vector2D.X + (double)num;
			double num4 = vector2D.Y + (double)num2;
			UUIItem item = base.GetItem(7);
			FVector fvector = new FVector((float)num3, (float)num4, 0f);
			item.SetLGUISpaceAbsolutePosition(fvector);
		}

		// Token: 0x06033DAA RID: 212394 RVA: 0x00CF84B3 File Offset: 0x00CF66B3
		private void ClearDragClickTick()
		{
			if (this.DragClickTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.DragClickTick);
				this.DragClickTick = -1;
			}
		}

		// Token: 0x06033DAB RID: 212395 RVA: 0x00CF84D6 File Offset: 0x00CF66D6
		private void SetPressItemShowState(bool isShow)
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isShow);
		}

		// Token: 0x06033DAC RID: 212396 RVA: 0x00CF84EA File Offset: 0x00CF66EA
		private void SetPressItemAlpha(float alpha)
		{
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetAlpha(alpha);
			}
			this.LongPressItemAlpha = alpha;
		}

		// Token: 0x06033DAD RID: 212397 RVA: 0x00CF8506 File Offset: 0x00CF6706
		private void SetBarAmount(float value)
		{
			UUISprite sprite = base.GetSprite(9);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(value);
		}

		// Token: 0x06033DAE RID: 212398 RVA: 0x00CF851C File Offset: 0x00CF671C
		private void OnDragTick(float _)
		{
			if (!this.IsInDungeon)
			{
				this.ClearDragClickTick();
				return;
			}
			this.PressTime += Singleton<Time>.Instance.DeltaTime;
			if (this.AfterLongPressState)
			{
				this.DragLogic.TickCheckDrag();
			}
			if (!this.CheckState)
			{
				return;
			}
			if (this.PressTime > this.BeforeLongPressTime && this.LongPressItemAlpha == 0f)
			{
				this.RefreshLongPressItemPosition();
				this.SetPressItemAlpha(1f);
				this.FillPressTime = 0f;
			}
			if (this.LongPressItemAlpha > 0f)
			{
				this.FillPressTime += Singleton<Time>.Instance.DeltaTime;
			}
			if (this.CurrentPressItem != null)
			{
				FVector worldPointInPlane = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false).GetWorldPointInPlane();
				float value = this.OnPressPositionX - worldPointInPlane.X;
				float value2 = this.OnPressPositionY - worldPointInPlane.Z;
				if (Math.Abs(value) + Math.Abs(value2) > this.ScrollerMoveDistance)
				{
					this.SetPressItemShowState(false);
					this.CheckState = false;
				}
			}
			if (this.FillPressTime > this.LongPressTime)
			{
				base.GetScrollViewWithScrollbar(1).SetEnable(false);
				this.SetPressItemShowState(false);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_tafang_switch_mecha_drag");
				this.CheckState = false;
				this.AfterLongPressState = true;
				this.DragItem.SetUiActive(true);
				this.DragLogic.StartDragState();
				this.DragLogic.SetItemToPointerPosition();
				this.OnStartDragCallBack(0);
				this.DragLogic.SetDragItemHierarchyMax();
				this.CheckPointerUpTick = Singleton<TickSystem>.Instance.Add(new Action<float>(this.CheckPointerItemMove), "TrapDefenseDevelopDragTick", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
				return;
			}
			this.SetBarAmount(this.FillPressTime / this.LongPressTime);
		}

		// Token: 0x06033DAF RID: 212399 RVA: 0x00CF86D4 File Offset: 0x00CF68D4
		private void CheckPointerItemMove(float _)
		{
			bool flag = Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(0);
			bool flag2 = Singleton<LguiEventSystemManager>.Instance.IsNowTriggerPressed(0);
			TrapDefenseBuildingDevelopDragDataItem stayingItem = this.DragLogic.GetStayingItem();
			if (!flag && !flag2)
			{
				if (stayingItem == null)
				{
					this.OnGridPointerUp(null, null);
				}
				else
				{
					this.OnDragEndCallBack(this.DragLogic.GetItem(), this.DragLogic.GetStayingItem(), false);
					this.OnGridPointerUp(null, null);
				}
				this.ClearCheckPointerUpTick();
			}
		}

		// Token: 0x06033DB0 RID: 212400 RVA: 0x00CF8741 File Offset: 0x00CF6941
		private void ClearCheckPointerUpTick()
		{
			if (this.CheckPointerUpTick != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.CheckPointerUpTick);
				this.CheckPointerUpTick = -1;
			}
		}

		// Token: 0x06033DB1 RID: 212401 RVA: 0x00CF8764 File Offset: 0x00CF6964
		protected void OnBeginDrag(int index)
		{
			foreach (CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic in this.BottomDragLogic)
			{
				commonDragItemLogic.StartDragState();
			}
			foreach (CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic2 in this.BottomDragLogic)
			{
				if (ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckIfCurrentDragIndex(commonDragItemLogic2.GetCurrentIndex()))
				{
					commonDragItemLogic2.SetDragItemHierarchyMax();
				}
			}
			this.BottomDragLogic[index].SetItemToPointerPosition();
			this.CurrentDragIndex = index;
		}

		// Token: 0x06033DB2 RID: 212402 RVA: 0x00CF8824 File Offset: 0x00CF6A24
		protected void OnDragEndCallBack(TrapDefenseBuildingDevelopDragDataItem self, TrapDefenseBuildingDevelopDragDataItem target, bool _)
		{
			if (target == null)
			{
				this.ResetPosition(true);
				return;
			}
			int currentIndex = target.GetCurrentIndex();
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_tafang_switch_mecha_equip");
			if (self.GetCurrentIndex() == -1)
			{
				UUIItem item = base.GetItem(6);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				this.ResetPosition(true);
				List<TrapDefenseBuildingSlotData> slotData = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData();
				if (self.GetCurrentData() == slotData[currentIndex].GetSlotData())
				{
					return;
				}
			}
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.EquipOrgan(currentIndex, self.GetCurrentData()).ContinueWith(delegate()
			{
				this.ResetPosition(true);
				UUIItem item2 = base.GetItem(6);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
			});
		}

		// Token: 0x06033DB3 RID: 212403 RVA: 0x00CF88C4 File Offset: 0x00CF6AC4
		private void OnMoveToScrollViewDragEndCallBack(int index, TrapDefenseBuildingDevelopItemData data)
		{
			this.PressTime = 0f;
			this.CurrentDragIndex = 999;
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.EquipOrgan(index, data).ContinueWith(delegate()
			{
				this.ResetPosition(true);
				this.BottomItemList[index].ResetPosition();
			});
		}

		// Token: 0x06033DB4 RID: 212404 RVA: 0x00CF8938 File Offset: 0x00CF6B38
		protected void OnStartDragCallBack(int _)
		{
			base.GetItem(6).SetUIActive(true);
			foreach (CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic in this.BottomDragLogic)
			{
				commonDragItemLogic.StartClickCheckTimer();
			}
		}

		// Token: 0x06033DB5 RID: 212405 RVA: 0x00CF8998 File Offset: 0x00CF6B98
		protected void OnClickAndRefreshView(int index)
		{
			base.GetItem(6).SetUIActive(false);
			if (this.CurrentSelectedBottomIndex != index)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_tafang_switch_mecha_click");
			}
			this.SetCurrentSelectBottomIndex(index);
		}

		// Token: 0x06033DB6 RID: 212406 RVA: 0x00CF89C8 File Offset: 0x00CF6BC8
		private void SetCurrentSelectBottomIndex(int index)
		{
			if (this.CurrentSelectedBottomIndex == index)
			{
				return;
			}
			this.CurrentSelectedBottomIndex = index;
			this.BottomItemList[this.CurrentSelectedBottomIndex].OnClickedItem();
			for (int i = 0; i < this.BottomItemList.Count; i++)
			{
				this.BottomItemList[i].SetSelected(this.CurrentSelectedBottomIndex == i);
			}
		}

		// Token: 0x06033DB7 RID: 212407 RVA: 0x00CF8A2C File Offset: 0x00CF6C2C
		protected void OnClickFail(int index)
		{
			this.ResetPosition(true);
		}

		// Token: 0x06033DB8 RID: 212408 RVA: 0x00CF8A38 File Offset: 0x00CF6C38
		private void ResetPosition(bool playBackToStartPositionAnimation = true)
		{
			foreach (CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> commonDragItemLogic in this.BottomDragLogic)
			{
				commonDragItemLogic.ResetPosition();
				commonDragItemLogic.SetActive(true);
			}
			foreach (TrapDefenseBuildingDevelopBottomInfoItem trapDefenseBuildingDevelopBottomInfoItem in this.BottomItemList)
			{
				trapDefenseBuildingDevelopBottomInfoItem.ResetPosition();
			}
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x06033DB9 RID: 212409 RVA: 0x00CF8AE0 File Offset: 0x00CF6CE0
		protected void UpdateDetail(TrapDefenseBuildingDevelopItemData data, bool needAnim = true)
		{
			if (needAnim)
			{
				base.PlaySequence("Switch", null, false);
			}
			this.DetailInfo.UpdateDetail(data);
		}

		// Token: 0x06033DBA RID: 212410 RVA: 0x00CF8B00 File Offset: 0x00CF6D00
		private void RefreshCurrency()
		{
			TrapDefenseBaseConfig? activityConfig = ConfigBase<TrapDefenseConfig>.Instance.GetActivityConfig();
			if (activityConfig == null || this.IsInDungeon)
			{
				return;
			}
			int techPointItem = activityConfig.Value.TechPointItem;
			int remainPoints = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.RemainPoints;
			CommonCurrencyItem costBtn = this.CostBtn;
			if (costBtn == null)
			{
				return;
			}
			costBtn.RefreshTemp(techPointItem, remainPoints.ToString());
		}

		// Token: 0x06033DBB RID: 212411 RVA: 0x00CF8B62 File Offset: 0x00CF6D62
		private void OnOrganNetUpdate()
		{
			this.UpdateDetail(this.CurSelectedData, true);
		}

		// Token: 0x06033DBC RID: 212412 RVA: 0x00CF8B71 File Offset: 0x00CF6D71
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033DBD RID: 212413 RVA: 0x00CF8B7C File Offset: 0x00CF6D7C
		protected bool CanToggleChange(int index, bool? _)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return true;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
			if (this.LastClickTime != 0.0)
			{
				double num = Singleton<Time>.Instance.Now - this.LastClickTime;
				int? num2 = intConfig;
				double? num3 = (num2 != null) ? new double?((double)num2.GetValueOrDefault()) : null;
				if (!(num >= num3.GetValueOrDefault() & num3 != null))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06033DBE RID: 212414 RVA: 0x00CF8C01 File Offset: 0x00CF6E01
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06033DBF RID: 212415 RVA: 0x00CF8C08 File Offset: 0x00CF6E08
		private void ToggleCallBack(int index)
		{
			this.LastClickTime = Singleton<Time>.Instance.Now;
			this.CurSelectIndex = index;
			List<TrapDefenseBuildingTypeData> dataList = this.DataListMap[(ETrapDefenseBuildingDevelopTab)index];
			foreach (TrapDefenseBuildingTypeData trapDefenseBuildingTypeData in this.DataListMap[ETrapDefenseBuildingDevelopTab.All])
			{
				trapDefenseBuildingTypeData.CurSelectedData = null;
				if (trapDefenseBuildingTypeData.TempSelectedData != null)
				{
					this.CurSelectedData = trapDefenseBuildingTypeData.TempSelectedData;
					trapDefenseBuildingTypeData.TempSelectedData = null;
				}
			}
			if (this.CurSelectedData != null)
			{
				bool flag = false;
				foreach (TrapDefenseBuildingTypeData trapDefenseBuildingTypeData2 in dataList)
				{
					if (trapDefenseBuildingTypeData2.GetDataList().Contains(this.CurSelectedData))
					{
						trapDefenseBuildingTypeData2.CurSelectedData = this.CurSelectedData;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.CurSelectedData = null;
				}
			}
			if (this.CurSelectedData == null && this.IsInDungeon)
			{
				TrapDefenseBuildingDevelopItemData trapDefenseBuildingDevelopItemData = this.BottomItem.CheckCurSlotEmpty();
				if (trapDefenseBuildingDevelopItemData != null)
				{
					foreach (TrapDefenseBuildingTypeData trapDefenseBuildingTypeData3 in dataList)
					{
						if (trapDefenseBuildingTypeData3.GetDataList().Contains(trapDefenseBuildingDevelopItemData))
						{
							trapDefenseBuildingTypeData3.CurSelectedData = trapDefenseBuildingDevelopItemData;
							this.SetCurSelectedData(trapDefenseBuildingDevelopItemData);
						}
					}
				}
			}
			if (this.CurSelectedData == null)
			{
				TrapDefenseBuildingDevelopItemData curSelectedData = dataList[0].GetDataList()[0];
				this.SetCurSelectedData(curSelectedData);
			}
			GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.RefreshByData(dataList, delegate
				{
					TrapDefenseBuildingDevelopTypeItem selectedTab = null;
					List<TrapDefenseBuildingDevelopTypeItem> scrollItemList = this.ScrollView.GetScrollItemList();
					for (int i = 0; i < scrollItemList.Count; i++)
					{
						TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem = scrollItemList[i];
						TrapDefenseBuildingTypeData trapDefenseBuildingTypeData4 = dataList[i];
						trapDefenseBuildingDevelopTypeItem.SetInitSelect();
						trapDefenseBuildingDevelopTypeItem.SetScrollParent(null);
						if (trapDefenseBuildingTypeData4.CurSelectedData != null)
						{
							selectedTab = trapDefenseBuildingDevelopTypeItem;
						}
					}
					if (selectedTab != null)
					{
						if (!selectedTab.GetChildRefreshed())
						{
							selectedTab.SetScrollParent(this.GetScrollViewWithScrollbar(1));
							return;
						}
						TTimerAction <>9__2;
						TimerSystem.Instance.Next(delegate(float _)
						{
							TimerSystemInstance instance = TimerSystem.Instance;
							TTimerAction action;
							if ((action = <>9__2) == null)
							{
								action = (<>9__2 = delegate(float _)
								{
									FVector2D fvector2D = new FVector2D();
									this.GetScrollViewWithScrollbar(1).ScrollToTop(ref fvector2D, selectedTab.GetRootItem(), false);
								});
							}
							instance.Next(action, null, null);
						}, null, null);
					}
				}, true);
			}
			this.UpdateDetail(this.CurSelectedData, true);
		}

		// Token: 0x06033DC0 RID: 212416 RVA: 0x00CF8E00 File Offset: 0x00CF7000
		private CommonTabData GetCommonData(int index)
		{
			ITrapDefenseBuildingDevelopTabData trapDefenseBuildingDevelopTabData = this.TabDataList[index];
			return new CommonTabData(trapDefenseBuildingDevelopTabData.Icon, new CommonTabTitleData(trapDefenseBuildingDevelopTabData.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x06033DC1 RID: 212417 RVA: 0x00CF8E38 File Offset: 0x00CF7038
		private void OnClickItem(TrapDefenseBuildingDevelopItemData data)
		{
			List<TrapDefenseBuildingDevelopTypeItem> scrollItemList = this.ScrollView.GetScrollItemList();
			this.SetCurSelectedData(data);
			foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem in scrollItemList)
			{
				trapDefenseBuildingDevelopTypeItem.CheckSelectedIsInTypeItem(data);
			}
			this.UpdateDetail(data, true);
			if (this.IsInDungeon)
			{
				this.BottomItem.SetMenuSelectedData(data);
			}
		}

		// Token: 0x06033DC2 RID: 212418 RVA: 0x00CF8EB4 File Offset: 0x00CF70B4
		private void OnBottomClick(TrapDefenseBuildingDevelopItemData data)
		{
			List<TrapDefenseBuildingDevelopTypeItem> scrollItemList = this.ScrollView.GetScrollItemList();
			this.SetCurSelectedData(null);
			bool flag = false;
			foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem in scrollItemList)
			{
				if (trapDefenseBuildingDevelopTypeItem.CheckBottomItemIsInTypeItem(data))
				{
					flag = true;
					FVector2D fvector2D = new FVector2D();
					base.GetScrollViewWithScrollbar(1).ScrollToTop(ref fvector2D, trapDefenseBuildingDevelopTypeItem.GetRootItem(), false);
					this.SetCurSelectedData(data);
				}
			}
			this.BottomItem.SetMenuSelectedData(data);
			if (flag)
			{
				this.UpdateDetail(data, true);
				return;
			}
			this.SetCurSelectedData(data);
			TabComponentWithCaptionItem<CommonTabItem> tabComponent = this.TabComponent;
			if (tabComponent == null)
			{
				return;
			}
			tabComponent.SelectToggleByIndex(0, true);
		}

		// Token: 0x06033DC3 RID: 212419 RVA: 0x00CF8F70 File Offset: 0x00CF7170
		private void OnPreviewClick(TrapDefenseBuildingDevelopItemData data)
		{
			List<TrapDefenseBuildingDevelopTypeItem> scrollItemList = this.ScrollView.GetScrollItemList();
			this.SetCurSelectedData(null);
			foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem in scrollItemList)
			{
				if (trapDefenseBuildingDevelopTypeItem.CheckBottomItemIsInTypeItem(data))
				{
					FVector2D fvector2D = new FVector2D();
					base.GetScrollViewWithScrollbar(1).ScrollToTop(ref fvector2D, trapDefenseBuildingDevelopTypeItem.GetRootItem(), false);
					this.SetCurSelectedData(data);
					break;
				}
			}
			this.UpdateDetail(data, false);
		}

		// Token: 0x06033DC4 RID: 212420 RVA: 0x00CF9000 File Offset: 0x00CF7200
		private void OnDataUpdate(TrapDefenseBuildingDevelopItemData data)
		{
			List<TrapDefenseBuildingTypeData> data2 = this.DataListMap[(ETrapDefenseBuildingDevelopTab)this.CurSelectIndex];
			this.SetCurSelectedData(data);
			GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.RefreshByData(data2, delegate
				{
					foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem in this.ScrollView.GetScrollItemList())
					{
						trapDefenseBuildingDevelopTypeItem.SetInitSelect();
					}
				}, true);
			}
			bool uiactive = !this.IsInDungeon && ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetCanAllReset();
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive);
			}
			this.UpdateDetail(data, true);
		}

		// Token: 0x06033DC5 RID: 212421 RVA: 0x00CF9088 File Offset: 0x00CF7288
		private void OnResetAll()
		{
			List<TrapDefenseBuildingTypeData> data = this.DataListMap[(ETrapDefenseBuildingDevelopTab)this.CurSelectIndex];
			GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> scrollView = this.ScrollView;
			if (scrollView != null)
			{
				scrollView.RefreshByData(data, delegate
				{
					foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem in this.ScrollView.GetScrollItemList())
					{
						trapDefenseBuildingDevelopTypeItem.SetInitSelect();
					}
				}, true);
			}
			this.UpdateDetail(this.CurSelectedData, true);
			bool uiactive = !this.IsInDungeon && ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetCanAllReset();
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(uiactive);
		}

		// Token: 0x06033DC6 RID: 212422 RVA: 0x00CF9110 File Offset: 0x00CF7310
		private void OnUpdateSlot()
		{
			this.BottomItem.UpdateSlot();
			foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem in this.ScrollView.GetScrollItemList())
			{
				trapDefenseBuildingDevelopTypeItem.UpdateEquipped();
			}
			TrapDefenseBuildingSlotData firstEmptySlot = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetFirstEmptySlot();
			if (firstEmptySlot != null)
			{
				this.SetCurrentSelectBottomIndex(firstEmptySlot.GetIndex());
			}
			this.BottomItem.UpdateEquipTxt();
		}

		// Token: 0x06033DC7 RID: 212423 RVA: 0x00CF919C File Offset: 0x00CF739C
		private TrapDefenseBuildingDevelopTypeItem CreateItemGrid()
		{
			return new TrapDefenseBuildingDevelopTypeItem
			{
				OnPointerDownCb = new Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData>(this.OnGridPointerDown),
				OnPointerUpCb = new Action<TrapDefenseBuildingDevelopTypeGridItem, TrapDefenseBuildingDevelopItemData>(this.OnGridPointerUp)
			};
		}

		// Token: 0x06033DC8 RID: 212424 RVA: 0x00CF91C8 File Offset: 0x00CF73C8
		private void OnClickReset()
		{
			if (this.IsInDungeon)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TrapDefenseOrganResetAll);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseDevelopReset();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06033DC9 RID: 212425 RVA: 0x00CF9220 File Offset: 0x00CF7420
		private UniTask RefreshTabListAsync()
		{
			TrapDefenseBuildingDevelopMainView.<RefreshTabListAsync>d__78 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopMainView.<RefreshTabListAsync>d__78>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033DCA RID: 212426 RVA: 0x00CF9264 File Offset: 0x00CF7464
		private List<CommonTabItemData> GetTabItemData(List<ITrapDefenseBuildingDevelopTabData> tabData)
		{
			int count = tabData.Count;
			List<CommonTabItemData> list = this.TabComponent.CreateTabItemDataByLength(count);
			if (!this.IsInDungeon)
			{
				for (int i = 0; i < count; i++)
				{
					ITrapDefenseBuildingDevelopTabData trapDefenseBuildingDevelopTabData = tabData[i];
					if (trapDefenseBuildingDevelopTabData != null)
					{
						list[i].RedDotName = trapDefenseBuildingDevelopTabData.RedDot;
						list[i].NeedUnBindAllRedDot = false;
					}
				}
			}
			return list;
		}

		// Token: 0x06033DCB RID: 212427 RVA: 0x00CF92C4 File Offset: 0x00CF74C4
		private void CreateTabListData()
		{
			List<List<TrapDefenseBuildingDevelopItemData>> haveList = ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetHaveList();
			List<TrapDefenseBuildingTypeData> list = new List<TrapDefenseBuildingTypeData>();
			TrapDefenseBuildingTypeData trapDefenseBuildingTypeData = TrapDefenseBuildingTypeData.Create(ETrapDefenseMachineType.Auxiliary, this.IsInDungeon, haveList[0], null);
			if (trapDefenseBuildingTypeData != null)
			{
				list.Add(trapDefenseBuildingTypeData);
			}
			List<TrapDefenseBuildingTypeData> list2 = new List<TrapDefenseBuildingTypeData>();
			TrapDefenseBuildingTypeData trapDefenseBuildingTypeData2 = TrapDefenseBuildingTypeData.Create(ETrapDefenseMachineType.Building, this.IsInDungeon, haveList[1], new ETrapDefensePlacementType?(ETrapDefensePlacementType.Floor));
			if (trapDefenseBuildingTypeData2 != null)
			{
				list2.Add(trapDefenseBuildingTypeData2);
			}
			TrapDefenseBuildingTypeData trapDefenseBuildingTypeData3 = TrapDefenseBuildingTypeData.Create(ETrapDefenseMachineType.Building, this.IsInDungeon, haveList[2], new ETrapDefensePlacementType?(ETrapDefensePlacementType.Wall));
			if (trapDefenseBuildingTypeData3 != null)
			{
				list2.Add(trapDefenseBuildingTypeData3);
			}
			TrapDefenseBuildingTypeData trapDefenseBuildingTypeData4 = TrapDefenseBuildingTypeData.Create(ETrapDefenseMachineType.Building, this.IsInDungeon, haveList[4], new ETrapDefensePlacementType?(ETrapDefensePlacementType.Ceil));
			if (trapDefenseBuildingTypeData4 != null)
			{
				list2.Add(trapDefenseBuildingTypeData4);
			}
			List<TrapDefenseBuildingTypeData> list3 = new List<TrapDefenseBuildingTypeData>();
			list3.AddRange(list2);
			list3.AddRange(list);
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.SetDevelopTab(list3);
			this.DataListMap[ETrapDefenseBuildingDevelopTab.All] = list3;
			this.DataListMap[ETrapDefenseBuildingDevelopTab.Auxiliary] = list;
			this.DataListMap[ETrapDefenseBuildingDevelopTab.Building] = list2;
		}

		// Token: 0x06033DCC RID: 212428 RVA: 0x00CF93DC File Offset: 0x00CF75DC
		private void SetCurSelectedData(TrapDefenseBuildingDevelopItemData data)
		{
			this.CurSelectedData = data;
			foreach (TrapDefenseBuildingTypeData trapDefenseBuildingTypeData in this.DataListMap[ETrapDefenseBuildingDevelopTab.All])
			{
				if (data == null)
				{
					trapDefenseBuildingTypeData.CurSelectedData = null;
				}
				else
				{
					trapDefenseBuildingTypeData.CurSelectedData = (trapDefenseBuildingTypeData.GetDataList().Contains(data) ? data : null);
				}
			}
		}

		// Token: 0x06033DCD RID: 212429 RVA: 0x00CF945C File Offset: 0x00CF765C
		private TrapDefenseBuildingDevelopDragDataItem CreateDragDataItem()
		{
			return new TrapDefenseBuildingDevelopDragDataItem();
		}

		// Token: 0x06033DCE RID: 212430 RVA: 0x00CF9464 File Offset: 0x00CF7664
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "MachineGrid")
			{
				if (configParams.Length < 3)
				{
					return null;
				}
				int index;
				if (!int.TryParse(configParams[1], out index))
				{
					return null;
				}
				GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> scrollView = this.ScrollView;
				TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem = (scrollView != null) ? scrollView.GetScrollItemByIndex(index) : null;
				if (trapDefenseBuildingDevelopTypeItem != null)
				{
					UUIItem rootItem = trapDefenseBuildingDevelopTypeItem.GetRootItem();
					GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> scrollView2 = this.ScrollView;
					if (scrollView2 != null)
					{
						scrollView2.LateScrollTo(rootItem, null, false);
					}
					return trapDefenseBuildingDevelopTypeItem.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
			}
			if (a == "FirstLevelTwoGrid")
			{
				foreach (TrapDefenseBuildingDevelopTypeItem trapDefenseBuildingDevelopTypeItem2 in this.ScrollView.GetScrollItemList())
				{
					UUIItem[] guideUiItemAndUiItemForShowEx = trapDefenseBuildingDevelopTypeItem2.GetGuideUiItemAndUiItemForShowEx(configParams);
					if (guideUiItemAndUiItemForShowEx != null)
					{
						GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> scrollView3 = this.ScrollView;
						if (scrollView3 != null)
						{
							scrollView3.LateScrollTo(trapDefenseBuildingDevelopTypeItem2.GetRootItem(), null, false);
						}
						return guideUiItemAndUiItemForShowEx;
					}
				}
			}
			return null;
		}

		// Token: 0x0401DFDA RID: 122842
		internal const int INVALID_INDEX = 999;

		// Token: 0x0401DFDB RID: 122843
		internal const int HELP_ID = 403;

		// Token: 0x0401DFDC RID: 122844
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x0401DFDD RID: 122845
		private CommonCurrencyItem CostBtn;

		// Token: 0x0401DFDE RID: 122846
		protected GenericScrollViewNew<TrapDefenseBuildingDevelopTypeItem, TrapDefenseBuildingTypeData> ScrollView;

		// Token: 0x0401DFDF RID: 122847
		protected TrapDefenseBuildingDevelopBottomItem BottomItem;

		// Token: 0x0401DFE0 RID: 122848
		private double LastClickTime;

		// Token: 0x0401DFE1 RID: 122849
		protected bool IsInDungeon;

		// Token: 0x0401DFE2 RID: 122850
		private int CurSelectIndex;

		// Token: 0x0401DFE3 RID: 122851
		private TrapDefenseBuildingDevelopItemData CurSelectedData;

		// Token: 0x0401DFE4 RID: 122852
		protected List<ITrapDefenseBuildingDevelopTabData> TabDataList = new List<ITrapDefenseBuildingDevelopTabData>();

		// Token: 0x0401DFE5 RID: 122853
		protected Dictionary<ETrapDefenseBuildingDevelopTab, List<TrapDefenseBuildingTypeData>> DataListMap = new Dictionary<ETrapDefenseBuildingDevelopTab, List<TrapDefenseBuildingTypeData>>();

		// Token: 0x0401DFE6 RID: 122854
		protected TrapDefenseBuildingDevelopDetailItem DetailInfo;

		// Token: 0x0401DFE7 RID: 122855
		private float PressTime;

		// Token: 0x0401DFE8 RID: 122856
		private float FillPressTime;

		// Token: 0x0401DFE9 RID: 122857
		private bool CheckState;

		// Token: 0x0401DFEA RID: 122858
		private bool AfterLongPressState;

		// Token: 0x0401DFEB RID: 122859
		private float OnPressPositionX;

		// Token: 0x0401DFEC RID: 122860
		private float OnPressPositionY;

		// Token: 0x0401DFED RID: 122861
		private float LongPressItemAlpha;

		// Token: 0x0401DFEE RID: 122862
		private int DragClickTick = -1;

		// Token: 0x0401DFEF RID: 122863
		private int CheckPointerUpTick = -1;

		// Token: 0x0401DFF0 RID: 122864
		private float LongPressTime;

		// Token: 0x0401DFF1 RID: 122865
		private float BeforeLongPressTime;

		// Token: 0x0401DFF2 RID: 122866
		private float ScrollerMoveDistance;

		// Token: 0x0401DFF3 RID: 122867
		protected TrapDefenseBuildingDevelopNormalDragItem DragItem;

		// Token: 0x0401DFF4 RID: 122868
		protected List<TrapDefenseBuildingDevelopBottomInfoItem> BottomItemList = new List<TrapDefenseBuildingDevelopBottomInfoItem>();

		// Token: 0x0401DFF5 RID: 122869
		private CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData> DragLogic;

		// Token: 0x0401DFF6 RID: 122870
		private List<CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData>> BottomDragLogic = new List<CommonDragItemLogic<TrapDefenseBuildingDevelopDragDataItem, TrapDefenseBuildingDevelopItemData>>();

		// Token: 0x0401DFF7 RID: 122871
		private TrapDefenseBuildingDevelopTypeGridItem CurrentPressItem;

		// Token: 0x0401DFF8 RID: 122872
		protected int CurrentDragIndex = -1;

		// Token: 0x0401DFF9 RID: 122873
		protected int CurrentSelectedBottomIndex;

		// Token: 0x0200AE0D RID: 44557
		[NullableContext(0)]
		internal class EChildComponentType
		{
			// Token: 0x040360DE RID: 221406
			public const int CaptionItem = 0;

			// Token: 0x040360DF RID: 221407
			public const int ItemScroll = 1;

			// Token: 0x040360E0 RID: 221408
			public const int PanelBuffItemGrid = 2;

			// Token: 0x040360E1 RID: 221409
			public const int BtnResetAll = 3;

			// Token: 0x040360E2 RID: 221410
			public const int PanelContentLayout = 4;

			// Token: 0x040360E3 RID: 221411
			public const int PanelBottomLayout = 5;

			// Token: 0x040360E4 RID: 221412
			public const int PanelDrag = 6;

			// Token: 0x040360E5 RID: 221413
			public const int PanelLongPress = 7;

			// Token: 0x040360E6 RID: 221414
			public const int PanelDragItem = 8;

			// Token: 0x040360E7 RID: 221415
			public const int SpriteBar = 9;
		}
	}
}
