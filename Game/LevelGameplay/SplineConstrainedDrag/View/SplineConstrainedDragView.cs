using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.View
{
	// Token: 0x020069F8 RID: 27128
	[NullableContext(2)]
	[Nullable(0)]
	public class SplineConstrainedDragView : UiViewBase
	{
		// Token: 0x06043370 RID: 275312 RVA: 0x011476FF File Offset: 0x011458FF
		[NullableContext(1)]
		public SplineConstrainedDragView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043371 RID: 275313 RVA: 0x01147710 File Offset: 0x01145910
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043372 RID: 275314 RVA: 0x01147864 File Offset: 0x01145A64
		protected override void OnAddEventListener()
		{
			UUIDraggableComponent draggable = base.GetDraggable(3);
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragMoved));
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
			draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
			draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragEnded));
			draggable.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiScroll1", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiScroll2", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI键盘Q手柄LB", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI键盘E手柄RB", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左摇杆上", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左摇杆下", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左摇杆左", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左摇杆右", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			Singleton<EventSystem>.Instance.Add(EEventName.DragActorPlayConditionRecheck, new Action(this.OnHintPanelRecheck));
		}

		// Token: 0x06043373 RID: 275315 RVA: 0x011479F8 File Offset: 0x01145BF8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DragActorPlayConditionRecheck, new Action(this.OnHintPanelRecheck));
			UUIDraggableComponent draggable = base.GetDraggable(3);
			draggable.OnPointerDragCallBack.Unbind();
			draggable.OnPointerBeginDragCallBack.Unbind();
			draggable.OnPointerEndDragCallBack.Unbind();
			draggable.OnPointerDownCallBack.Unbind();
			draggable.OnPointerUpCallBack.Unbind();
			draggable.OnPointerScrollCallBack.Unbind();
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiScroll1", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiScroll2", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI键盘Q手柄LB", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI键盘E手柄RB", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左摇杆上", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左摇杆下", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左摇杆左", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左摇杆右", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
		}

		// Token: 0x06043374 RID: 275316 RVA: 0x01147B44 File Offset: 0x01145D44
		protected override UniTask OnBeforeStartAsync()
		{
			SplineConstrainedDragView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SplineConstrainedDragView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043375 RID: 275317 RVA: 0x01147B88 File Offset: 0x01145D88
		private void RefreshHintPanels()
		{
			SplineConstrainedDragModel instance = ModelBase<SplineConstrainedDragModel>.Instance;
			bool flag = Singleton<Info>.Instance.IsInGamepad();
			int draggableCount = ControllerBase<SplineConstrainedDragController>.Instance.GetDraggableCount();
			IKuroSplineConstrainedDrag activeSplineConstrainedDrag = instance.GetActiveSplineConstrainedDrag();
			EDragHintType? edragHintType = (activeSplineConstrainedDrag != null) ? activeSplineConstrainedDrag.GetDragHintType() : null;
			bool? lastHintIsGamepad = this.LastHintIsGamepad;
			bool flag2 = flag;
			if ((lastHintIsGamepad.GetValueOrDefault() == flag2 & lastHintIsGamepad != null) && this.LastHintDraggableCount == draggableCount)
			{
				EDragHintType? lastHintType = this.LastHintType;
				EDragHintType? edragHintType2 = edragHintType;
				if (lastHintType.GetValueOrDefault() == edragHintType2.GetValueOrDefault() & lastHintType != null == (edragHintType2 != null))
				{
					return;
				}
			}
			this.LastHintIsGamepad = new bool?(flag);
			this.LastHintDraggableCount = draggableCount;
			this.LastHintType = edragHintType;
			UUIItem item = base.GetItem(4);
			UUIItem item2 = base.GetItem(5);
			UUIItem item3 = base.GetItem(6);
			UUIItem item4 = base.GetItem(7);
			UUIText text = base.GetText(8);
			if (!flag)
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
				if (text != null)
				{
					text.SetUIActive(true);
				}
				return;
			}
			if (text != null)
			{
				text.SetUIActive(false);
			}
			if (item != null)
			{
				item.SetUIActive(draggableCount > 1);
			}
			if (item2 != null)
			{
				UUIItem uuiitem = item2;
				EDragHintType? edragHintType2 = edragHintType;
				EDragHintType edragHintType3 = EDragHintType.Horizontal;
				uuiitem.SetUIActive(edragHintType2.GetValueOrDefault() == edragHintType3 & edragHintType2 != null);
			}
			if (item3 != null)
			{
				item3.SetUIActive(edragHintType.GetValueOrDefault() == EDragHintType.Vertical);
			}
			if (item4 != null)
			{
				item4.SetUIActive(edragHintType.GetValueOrDefault() == EDragHintType.FourWay);
			}
		}

		// Token: 0x06043376 RID: 275318 RVA: 0x01147D0E File Offset: 0x01145F0E
		private void OnHintPanelRecheck()
		{
			this.RefreshHintPanels();
		}

		// Token: 0x06043377 RID: 275319 RVA: 0x01147D18 File Offset: 0x01145F18
		private void OnHelpButtonClick()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("DragActorPlayGuideGroupId");
			int num3;
			if (intConfig != null)
			{
				int? num = intConfig;
				int num2 = 0;
				if (num.GetValueOrDefault() > num2 & num != null)
				{
					num3 = intConfig.Value;
					goto IL_3A;
				}
			}
			num3 = 10001;
			IL_3A:
			int helpGroupId = num3;
			ControllerBase<HelpController>.Instance.OpenHelpById(helpGroupId);
		}

		// Token: 0x06043378 RID: 275320 RVA: 0x01147D6B File Offset: 0x01145F6B
		private void OnCloseButtonClick()
		{
			ControllerBase<SplineConstrainedDragController>.Instance.DisableDragActorPlay();
		}

		// Token: 0x06043379 RID: 275321 RVA: 0x01147D78 File Offset: 0x01145F78
		private void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SplineConstrainedDrag") >= 5)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[SplineConstrainedDragView] OnDragBegin";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("eventData", eventData);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ControllerBase<SplineConstrainedDragController>.Instance.OnPointerBegin(eventData.pointerPosition);
		}

		// Token: 0x0604337A RID: 275322 RVA: 0x01147DD8 File Offset: 0x01145FD8
		private void OnDragMoved(ULGUIPointerEventData eventData)
		{
			if (eventData == null || !eventData.isDragging)
			{
				return;
			}
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SplineConstrainedDrag") >= 5)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[SplineConstrainedDragView] OnDragMoved";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("eventData", eventData);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ControllerBase<SplineConstrainedDragController>.Instance.OnPointerMove(eventData.pointerPosition);
		}

		// Token: 0x0604337B RID: 275323 RVA: 0x01147E40 File Offset: 0x01146040
		private void OnDragEnded(ULGUIPointerEventData eventData)
		{
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SplineConstrainedDrag") >= 5)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[SplineConstrainedDragView] OnDragEnded";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("eventData", eventData);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ControllerBase<SplineConstrainedDragController>.Instance.OnPointerEnd();
		}

		// Token: 0x0604337C RID: 275324 RVA: 0x01147E90 File Offset: 0x01146090
		private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
		{
		}

		// Token: 0x0604337D RID: 275325 RVA: 0x01147E94 File Offset: 0x01146094
		[NullableContext(1)]
		private unsafe void OnAxis(string axisName, float value, InputIdentification identification)
		{
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SplineConstrainedDrag") >= 7)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[SplineConstrainedDragView] OnAxis";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("axisName", axisName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			ControllerBase<SplineConstrainedDragController>.Instance.OnGamepadAxis(axisName, value);
		}

		// Token: 0x0604337E RID: 275326 RVA: 0x01147F18 File Offset: 0x01146118
		[NullableContext(1)]
		private unsafe void OnInput(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification identification)
		{
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("SplineConstrainedDrag") >= 7)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[SplineConstrainedDragView] OnInput";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("actionName", actionName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("actionType", actionType);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (actionName == "UI键盘Q手柄LB")
			{
				ControllerBase<SplineConstrainedDragController>.Instance.SwitchActiveDragByStep(EGamepadSwitchStep.Previous);
				return;
			}
			if (actionName == "UI键盘E手柄RB")
			{
				ControllerBase<SplineConstrainedDragController>.Instance.SwitchActiveDragByStep(EGamepadSwitchStep.Next);
				return;
			}
			if (actionName == "UI左摇杆上")
			{
				ControllerBase<SplineConstrainedDragController>.Instance.SwitchActiveDragByDirection(EGamepadSwitchDirection.Up);
				return;
			}
			if (actionName == "UI左摇杆左")
			{
				ControllerBase<SplineConstrainedDragController>.Instance.SwitchActiveDragByDirection(EGamepadSwitchDirection.Left);
				return;
			}
			if (actionName == "UI左摇杆右")
			{
				ControllerBase<SplineConstrainedDragController>.Instance.SwitchActiveDragByDirection(EGamepadSwitchDirection.Right);
				return;
			}
			if (!(actionName == "UI左摇杆下"))
			{
				return;
			}
			ControllerBase<SplineConstrainedDragController>.Instance.SwitchActiveDragByDirection(EGamepadSwitchDirection.Down);
		}

		// Token: 0x04025795 RID: 153493
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025796 RID: 153494
		private bool? LastHintIsGamepad;

		// Token: 0x04025797 RID: 153495
		private int LastHintDraggableCount = -1;

		// Token: 0x04025798 RID: 153496
		private EDragHintType? LastHintType;

		// Token: 0x0200C96C RID: 51564
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403DF1D RID: 253725
			Caption,
			// Token: 0x0403DF1E RID: 253726
			Title,
			// Token: 0x0403DF1F RID: 253727
			Desc,
			// Token: 0x0403DF20 RID: 253728
			Draggable,
			// Token: 0x0403DF21 RID: 253729
			PanelHotKeyA,
			// Token: 0x0403DF22 RID: 253730
			PanelHotKeyB,
			// Token: 0x0403DF23 RID: 253731
			PanelHotKeyC,
			// Token: 0x0403DF24 RID: 253732
			PanelHotKeyD,
			// Token: 0x0403DF25 RID: 253733
			TxtTips
		}
	}
}
