using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Qte.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.AnchorGameplay
{
	// Token: 0x02006F6C RID: 28524
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AnchorGameplayView : CommonQteViewBase<CommonQteDragContext>
	{
		// Token: 0x06045085 RID: 282757 RVA: 0x011F9B8C File Offset: 0x011F7D8C
		[NullableContext(1)]
		public AnchorGameplayView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06045086 RID: 282758 RVA: 0x011F9BE0 File Offset: 0x011F7DE0
		protected unsafe override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06045087 RID: 282759 RVA: 0x011F9C70 File Offset: 0x011F7E70
		protected override UniTask OnBeforeStartAsync()
		{
			AnchorGameplayView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AnchorGameplayView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06045088 RID: 282760 RVA: 0x011F9CB3 File Offset: 0x011F7EB3
		protected override void OnAddEventListener()
		{
			this.OnInputControllerChange(EInputControllerType.None, EInputControllerType.None);
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x06045089 RID: 282761 RVA: 0x011F9CDC File Offset: 0x011F7EDC
		private void InitDrag()
		{
			this.DraggableComponent = base.GetDraggable(0);
			this.DraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
			this.DraggableComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDrag));
			this.DraggableComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.CheckFinish));
			AActor owner = this.DraggableComponent.GetOwner();
			this.BgItem = (((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem);
		}

		// Token: 0x0604508A RID: 282762 RVA: 0x011F9D78 File Offset: 0x011F7F78
		private void InitConfig()
		{
			this.MoveDistance = ConfigCommonParamById.GetIntConfig("AnchorBtnMoveDistance").Value;
			string stringConfig = ConfigCommonParamById.GetStringConfig("AnchorMovementCurve");
			this.MoveCurve = Singleton<ResourceSystem>.Instance.Load<UCurveVector>(stringConfig, "js_undefined");
			this.DetachOffset = ConfigCommonParamById.GetIntConfig("AnchorBtnDetachOffset").Value;
			this.GamepadMovementFactor = ConfigCommonParamById.GetFloatConfig("AnchorGamepadBtnMovementFactor").Value;
			this.EndPerformTime = ConfigCommonParamById.GetIntConfig("AnchorEndAnimTime").Value;
			this.EndPerformPercentagePerMs = 1f / (float)this.EndPerformTime;
		}

		// Token: 0x0604508B RID: 282763 RVA: 0x011F9E1C File Offset: 0x011F801C
		protected override void OnStart()
		{
			base.OnStart();
			this.InitConfig();
			this.InitDrag();
			this.MoveItemBtnComp = base.GetButton(1);
			this.MoveItemBtnComp.OnPointDownCallBack.Bind(new Action(this.OnPress));
			this.MoveItemBtnComp.OnPointUpCallBack.Bind(new Action(this.OnRelease));
			AActor owner = this.MoveItemBtnComp.GetOwner();
			this.MoveItem = (((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
			this.CurPercentage = 0f;
			this.BgItem.SetUIActive(false);
		}

		// Token: 0x0604508C RID: 282764 RVA: 0x011F9EEC File Offset: 0x011F80EC
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.OnRemoveEventListener();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x0604508D RID: 282765 RVA: 0x011F9F0A File Offset: 0x011F810A
		protected override void OnHandleQteEnd()
		{
			if (this.CurPercentage != 1f)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopCurrentSequence(false, false);
				}
				this.PlayingEndPerform = true;
				this.OnFinishEndPerformCallback = delegate()
				{
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 == null)
					{
						return;
					}
					levelSequencePlayer2.PlayLevelSequenceByName("Success", false, null, false);
				};
			}
		}

		// Token: 0x0604508E RID: 282766 RVA: 0x011F9F48 File Offset: 0x011F8148
		private unsafe void OnPointerDrag(ULGUIPointerEventData eventData)
		{
			if (this.IsQteEnd || this.IsQtePause || this.MoveCurve == null || !this.ClickedBtn)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Temp;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[AnchorGameplayView] OnPointerDrag";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsQteEnd", this.IsQteEnd);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsQtePause", this.IsQtePause);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MoveCurve", this.MoveCurve);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ClickedBtn", this.ClickedBtn);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return;
			}
			FVector pointerPosition = eventData.pointerPosition;
			Vector2D vector2D = Vector2D.Create();
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, vector2D);
			float num = (float)(vector2D.Y - this.LastDragPos.Y) / (float)this.MoveDistance;
			this.CurPercentage += num * -1f;
			this.CurPercentage = Singleton<MathUtils>.Instance.Clamp(this.CurPercentage, 0f, 1f);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Temp;
			ELogAuthor author2 = ELogAuthor.CH;
			string message2 = "[AnchorGameplayView] OnPointerDrag";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("deltaPercentage", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("CurPercentage", this.CurPercentage);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			FVector vectorValue = this.MoveCurve.GetVectorValue(this.CurPercentage);
			this.MoveItem.SetUIRelativeLocation(vectorValue);
			Vector2D vector2D2 = Vector2D.Create(this.MoveItem.GetLGUISpaceAbsolutePosition());
			Vector2D vector2D3 = Vector2D.Create(vector2D);
			if (Vector2D.Distance(vector2D2, vector2D3) > (double)this.DetachOffset || this.CurPercentage == 1f)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Temp;
				ELogAuthor author3 = ELogAuthor.CH;
				string message3 = "[AnchorGameplayView] OnPointerDrag Detach";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("position", pointerPosition);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("itemPos", vector2D2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("pointerPos", vector2D3);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("Dist", Vector2D.Distance(vector2D2, vector2D3));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("DetachOffset", this.DetachOffset);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
				this.ClickedBtn = false;
				this.CheckFinish(null);
				return;
			}
			this.LastDragPos.DeepCopy(vector2D);
		}

		// Token: 0x0604508F RID: 282767 RVA: 0x011FA21C File Offset: 0x011F841C
		private void OnPointerBeginDrag(ULGUIPointerEventData eventData)
		{
			FVector pointerPosition = eventData.pointerPosition;
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, this.LastDragPos);
			Singleton<Log>.Instance.Info(ELogModule.Temp, ELogAuthor.CH, "[AnchorGameplayView] OnPointerBeginDrag", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06045090 RID: 282768 RVA: 0x011FA25C File Offset: 0x011F845C
		[NullableContext(1)]
		private void CheckFinish(ULGUIPointerEventData data)
		{
			CommonQteDragContext commonQteContext = this.CommonQteContext;
			if (commonQteContext != null && commonQteContext.State == EQteState.Success)
			{
				return;
			}
			if (this.CurPercentage != 1f)
			{
				FVector vectorValue = this.MoveCurve.GetVectorValue(0f);
				this.MoveItem.SetUIRelativeLocation(vectorValue);
				this.CurPercentage = 0f;
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Success", false, null, false);
			}
			this.CommonQteContext.QteSuccess();
		}

		// Token: 0x06045091 RID: 282769 RVA: 0x011FA2E4 File Offset: 0x011F84E4
		private void OnPress()
		{
			this.ClickedBtn = true;
			Singleton<Log>.Instance.Info(ELogModule.Temp, ELogAuthor.CH, "[AnchorGameplayView]OnPress called", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06045092 RID: 282770 RVA: 0x011FA314 File Offset: 0x011F8514
		private void OnRelease()
		{
			this.ClickedBtn = false;
			Singleton<Log>.Instance.Info(ELogModule.Temp, ELogAuthor.CH, "[AnchorGameplayView]OnRelease called", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06045093 RID: 282771 RVA: 0x011FA344 File Offset: 0x011F8544
		[NullableContext(1)]
		public override void SetQteContext(CommonQteContextBase context)
		{
			CommonQteDragContext commonQteDragContext = context as CommonQteDragContext;
			if (commonQteDragContext == null)
			{
				return;
			}
			this.QteHandle = context.HandleId;
			this.CommonQteContext = commonQteDragContext;
			InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = "UiLookUp"
			};
			InputMultiKeyItem inputKeyItem = this.InputKeyItem;
			if (inputKeyItem != null)
			{
				inputKeyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				InputMultiKeyItem inputKeyItem2 = this.InputKeyItem;
				if (inputKeyItem2 != null)
				{
					inputKeyItem2.Show(null);
				}
			}
			else
			{
				InputMultiKeyItem inputKeyItem3 = this.InputKeyItem;
				if (inputKeyItem3 != null)
				{
					inputKeyItem3.Hide(null);
				}
			}
			this.RefreshUiOffset();
			base.SetQteActive(commonQteDragContext);
			this.PlayQteStart();
		}

		// Token: 0x06045094 RID: 282772 RVA: 0x011FA3D8 File Offset: 0x011F85D8
		protected override void OnTick(float delta)
		{
			if (this.PlayingEndPerform)
			{
				this.TickEndPerform(delta);
				return;
			}
			if (!this.IsQteStart || this.IsQteEnd || this.IsQtePause)
			{
				return;
			}
			if (this.CommonQteContext == null || this.CommonQteContext.IsInvalid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CommonQte;
				ELogAuthor author = ELogAuthor.CH;
				string message = "Qte界面Context已无效, 强制关闭界面";
				string item = "State";
				CommonQteDragContext commonQteContext = this.CommonQteContext;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (commonQteContext != null) ? new EQteState?(commonQteContext.State) : null);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.HandleQteEnd();
				return;
			}
			this.CommonQteContext.UpdateTime(delta);
			CommonQteModel instance2 = ModelBase<CommonQteModel>.Instance;
			if (instance2 != null && instance2.IsRefreshMode)
			{
				this.RefreshUiOffset();
			}
		}

		// Token: 0x06045095 RID: 282773 RVA: 0x011FA49C File Offset: 0x011F869C
		private void TickEndPerform(float delta)
		{
			this.CurPercentage += delta * this.EndPerformPercentagePerMs;
			this.CurPercentage = Singleton<MathUtils>.Instance.Clamp(this.CurPercentage, 0f, 1f);
			FVector vectorValue = this.MoveCurve.GetVectorValue(this.CurPercentage);
			this.MoveItem.SetUIRelativeLocation(vectorValue);
			if (this.CurPercentage == 1f)
			{
				this.PlayingEndPerform = false;
				if (this.OnFinishEndPerformCallback != null)
				{
					this.OnFinishEndPerformCallback();
				}
			}
		}

		// Token: 0x06045096 RID: 282774 RVA: 0x011FA524 File Offset: 0x011F8724
		protected override void OnPlayQteStart()
		{
			this.BgItem.SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
		}

		// Token: 0x06045097 RID: 282775 RVA: 0x011FA560 File Offset: 0x011F8760
		[NullableContext(1)]
		private void OnSequenceEndEvent(string name)
		{
			if (!(name == "Start01"))
			{
				if (name == "Close01" || name == "Success")
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.AnchorGameplayView, null);
				}
				return;
			}
			if (this.IsQteEnd)
			{
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Tips", false, null, false);
			}
			this.IsQteStart = true;
			this.IsQteInteractive = true;
		}

		// Token: 0x06045098 RID: 282776 RVA: 0x011FA5E0 File Offset: 0x011F87E0
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.CheckFinish(null);
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.BindGamepadInput();
				InputMultiKeyItem inputKeyItem = this.InputKeyItem;
				if (inputKeyItem == null)
				{
					return;
				}
				inputKeyItem.Show(null);
				return;
			}
			else
			{
				this.UnbindGamepadInput();
				InputMultiKeyItem inputKeyItem2 = this.InputKeyItem;
				if (inputKeyItem2 == null)
				{
					return;
				}
				inputKeyItem2.Hide(null);
				return;
			}
		}

		// Token: 0x06045099 RID: 282777 RVA: 0x011FA62F File Offset: 0x011F882F
		protected override void OnRemoveEventListener()
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.UnbindGamepadInput();
			}
		}

		// Token: 0x0604509A RID: 282778 RVA: 0x011FA643 File Offset: 0x011F8843
		private void BindGamepadInput()
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiScroll1", new TInputHandle<float>(this.OnGamepadInput));
		}

		// Token: 0x0604509B RID: 282779 RVA: 0x011FA660 File Offset: 0x011F8860
		private void UnbindGamepadInput()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiScroll1", new TInputHandle<float>(this.OnGamepadInput));
		}

		// Token: 0x0604509C RID: 282780 RVA: 0x011FA680 File Offset: 0x011F8880
		[NullableContext(1)]
		private void OnGamepadInput(string axisName, float value, InputIdentification inputIdentification)
		{
			if (this.IsQteEnd || this.IsQtePause || this.MoveCurve == null)
			{
				return;
			}
			if (value <= 0f)
			{
				if (this.CurPercentage != 0f)
				{
					this.CheckFinish(null);
				}
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[AnchorGameplayView]OnGamepadInput called";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CurPercentage += value * this.GamepadMovementFactor;
			this.CurPercentage = Singleton<MathUtils>.Instance.Clamp(this.CurPercentage, 0f, 1f);
			FVector vectorValue = this.MoveCurve.GetVectorValue(this.CurPercentage);
			this.MoveItem.SetUIRelativeLocation(vectorValue);
			if (this.CurPercentage == 1f)
			{
				this.CheckFinish(null);
			}
		}

		// Token: 0x0604509D RID: 282781 RVA: 0x011FA758 File Offset: 0x011F8958
		protected override void RefreshUiOffset()
		{
			if (this.CommonQteContext != null)
			{
				SCommonQte_Drag scommonQte_Drag = this.CommonQteContext.GetUiConfig() as SCommonQte_Drag;
				if (scommonQte_Drag != null)
				{
					SCommonQteButton uiconfig = scommonQte_Drag.UIConfig;
					this.RootItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
					this.RootItem.SetAnchorOffset(uiconfig.AnchorOffset);
				}
			}
		}

		// Token: 0x0604509E RID: 282782 RVA: 0x011FA7B6 File Offset: 0x011F89B6
		protected override bool IsUseBaseAction()
		{
			return false;
		}

		// Token: 0x0402682C RID: 157740
		private UUIItem BgItem;

		// Token: 0x0402682D RID: 157741
		private UUIDraggableComponent DraggableComponent;

		// Token: 0x0402682E RID: 157742
		private UUIItem MoveItem;

		// Token: 0x0402682F RID: 157743
		private UUIButtonComponent MoveItemBtnComp;

		// Token: 0x04026830 RID: 157744
		private InputMultiKeyItem InputKeyItem;

		// Token: 0x04026831 RID: 157745
		private bool ClickedBtn;

		// Token: 0x04026832 RID: 157746
		[Nullable(1)]
		private readonly Vector2D LastDragPos = Vector2D.Create();

		// Token: 0x04026833 RID: 157747
		private float CurPercentage;

		// Token: 0x04026834 RID: 157748
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04026835 RID: 157749
		private int MoveDistance = 560;

		// Token: 0x04026836 RID: 157750
		private UCurveVector MoveCurve;

		// Token: 0x04026837 RID: 157751
		private int DetachOffset = 100;

		// Token: 0x04026838 RID: 157752
		private float GamepadMovementFactor = -0.05f;

		// Token: 0x04026839 RID: 157753
		private int EndPerformTime = 500;

		// Token: 0x0402683A RID: 157754
		private float EndPerformPercentagePerMs = -1f;

		// Token: 0x0402683B RID: 157755
		private bool PlayingEndPerform;

		// Token: 0x0402683C RID: 157756
		private Action OnFinishEndPerformCallback;

		// Token: 0x0200CC02 RID: 52226
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403E8E7 RID: 256231
			public const int DraggableArea = 0;

			// Token: 0x0403E8E8 RID: 256232
			public const int MoveItem = 1;

			// Token: 0x0403E8E9 RID: 256233
			public const int KeyItem = 2;
		}
	}
}
