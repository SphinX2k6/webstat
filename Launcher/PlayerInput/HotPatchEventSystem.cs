using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;
using CSharpScript.Launcher.InputDevice;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.PlayerInput
{
	// Token: 0x02004544 RID: 17732
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotPatchEventSystem : Singleton<HotPatchEventSystem>
	{
		// Token: 0x0602EAD9 RID: 191193 RVA: 0x00B0F5DC File Offset: 0x00B0D7DC
		private void InitStandaloneInputModule()
		{
			this.StandaloneInputModule = (this.EventSystem.GetComponentByClass(ULGUI_StandaloneInputModule.StaticClass()) as ULGUI_StandaloneInputModule);
			FLGUIPointerInputChange_DynamicDelegate flguipointerInputChange_DynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPointerInputChange_DynamicDelegate>(new Action<ELGUIPointerInputType>(this.ChangeController));
			this.HandleWrapper = this.StandaloneInputModule.RegisterInputChangeEvent(flguipointerInputChange_DynamicDelegate);
		}

		// Token: 0x0602EADA RID: 191194 RVA: 0x00B0F62E File Offset: 0x00B0D82E
		private void DestroyStandaloneInputModule()
		{
			this.StandaloneInputModule.UnregisterInputChangeEvent(this.HandleWrapper);
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<ELGUIPointerInputType>(this.ChangeController));
			this.HandleWrapper = null;
		}

		// Token: 0x0602EADB RID: 191195 RVA: 0x00B0F659 File Offset: 0x00B0D859
		private void InitCurrentInputModule()
		{
			if (Singleton<InputDevice>.Instance.IsInTouch())
			{
				this.CurrentInputModule = this.TouchInputModule;
			}
			else
			{
				this.CurrentInputModule = this.StandaloneInputModule;
				this.SetWindowCursorStyle();
			}
			this.CurrentInputModule.Activate(false);
		}

		// Token: 0x0602EADC RID: 191196 RVA: 0x00B0F694 File Offset: 0x00B0D894
		private void SetWindowCursorStyle()
		{
			FVector2D hotSpot = new FVector2D(0f, 0f);
			UObject worldContext = this.WorldContext;
			FName cursorName;
			FName cursorName2;
			FName cursorName3;
			if (UKuroStaticLibrary.IsEditor(worldContext))
			{
				cursorName = new FName("Aki/UI/Module/Cursor/SourceResource/CursorNor");
				cursorName2 = new FName("Aki/UI/Module/Cursor/SourceResource/CursorHi");
				cursorName3 = new FName("Aki/UI/Module/Cursor/SourceResource/CursorPre");
			}
			else
			{
				cursorName = new FName("Aki/Cursor/CursorNor");
				cursorName2 = new FName("Aki/Cursor/CursorHi");
				cursorName3 = new FName("Aki/Cursor/CursorPre");
			}
			UWidgetBlueprintLibrary.SetHardwareCursor(worldContext, EMouseCursor.Default, cursorName, hotSpot);
			UWidgetBlueprintLibrary.SetHardwareCursor(worldContext, EMouseCursor.CursorEnter, cursorName2, hotSpot);
			UWidgetBlueprintLibrary.SetHardwareCursor(worldContext, EMouseCursor.CursorPress, cursorName3, hotSpot);
		}

		// Token: 0x0602EADD RID: 191197 RVA: 0x00B0F72C File Offset: 0x00B0D92C
		private void RegisterInput()
		{
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("UI左键点击", new TInputAction(this.OnPressActionCallback));
			Singleton<HotPatchInputManager>.Instance.RegisterOnTouchAction(new TTouchAction(this.OnTouchActionCallback));
			Singleton<HotPatchInputManager>.Instance.RegisterOnTouchMovedAction(new TTouchMovedAction(this.OnTouchMovedActionCallback));
		}

		// Token: 0x0602EADE RID: 191198 RVA: 0x00B0F780 File Offset: 0x00B0D980
		private void UnRegisterInput()
		{
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("UI左键点击", new TInputAction(this.OnPressActionCallback));
			Singleton<HotPatchInputManager>.Instance.UnRegisterOnTouchAction();
			Singleton<HotPatchInputManager>.Instance.UnRegisterOnTouchMovedAction();
		}

		// Token: 0x0602EADF RID: 191199 RVA: 0x00B0F7B1 File Offset: 0x00B0D9B1
		[NullableContext(1)]
		private void OnPressActionCallback(bool bPress, string type)
		{
			this.StandaloneInputModule.InputTrigger(bPress, EMouseButtonType.Left);
		}

		// Token: 0x0602EAE0 RID: 191200 RVA: 0x00B0F7C0 File Offset: 0x00B0D9C0
		private void OnTouchActionCallback(bool inTouchPress, int inTouchId, FVector inTouchPointPosition)
		{
			this.TouchInputModule.InputTouchTrigger(inTouchPress, inTouchId, inTouchPointPosition);
		}

		// Token: 0x0602EAE1 RID: 191201 RVA: 0x00B0F7D1 File Offset: 0x00B0D9D1
		private void OnTouchMovedActionCallback(int inTouchId, FVector inTouchPointPosition)
		{
			this.TouchInputModule.InputTouchMoved(inTouchId, inTouchPointPosition);
		}

		// Token: 0x0602EAE2 RID: 191202 RVA: 0x00B0F7E1 File Offset: 0x00B0D9E1
		private void InputChangeDelegate(CSharpScript.Launcher.InputDevice.EInputControllerType _, CSharpScript.Launcher.InputDevice.EInputControllerType __)
		{
			if (Singleton<InputDevice>.Instance.IsInTouch())
			{
				this.CurrentInputModule = this.TouchInputModule;
			}
			else
			{
				this.CurrentInputModule = this.StandaloneInputModule;
			}
			this.CurrentInputModule.Activate(false);
		}

		// Token: 0x0602EAE3 RID: 191203 RVA: 0x00B0F815 File Offset: 0x00B0DA15
		private void ChangeController(ELGUIPointerInputType type)
		{
			if (type == ELGUIPointerInputType.Pointer)
			{
				this.InputType = ELGUIPointerInputType.Pointer;
				Singleton<InputDevice>.Instance.SwitchInputControllerTypeByMouseMove();
			}
		}

		// Token: 0x0602EAE4 RID: 191204 RVA: 0x00B0F82C File Offset: 0x00B0DA2C
		[NullableContext(1)]
		public UniTask InitRuntimeEventSystemActor(UObject worldContext)
		{
			HotPatchEventSystem.<InitRuntimeEventSystemActor>d__19 <InitRuntimeEventSystemActor>d__;
			<InitRuntimeEventSystemActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRuntimeEventSystemActor>d__.<>4__this = this;
			<InitRuntimeEventSystemActor>d__.worldContext = worldContext;
			<InitRuntimeEventSystemActor>d__.<>1__state = -1;
			<InitRuntimeEventSystemActor>d__.<>t__builder.Start<HotPatchEventSystem.<InitRuntimeEventSystemActor>d__19>(ref <InitRuntimeEventSystemActor>d__);
			return <InitRuntimeEventSystemActor>d__.<>t__builder.Task;
		}

		// Token: 0x0602EAE5 RID: 191205 RVA: 0x00B0F878 File Offset: 0x00B0DA78
		[NullableContext(1)]
		public bool SimulationPointerDownUp(UUIItem uiItem, bool isPress)
		{
			if (LauncherSdk.Get().GetSdkFocusState())
			{
				return false;
			}
			if (this.CurrentInputModule == this.StandaloneInputModule)
			{
				ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
				int pointerID = 999;
				FVector2D? fvector2D = null;
				return standaloneInputModule.SimulationPointerDownUp(pointerID, uiItem, isPress, fvector2D);
			}
			return false;
		}

		// Token: 0x0602EAE6 RID: 191206 RVA: 0x00B0F8BE File Offset: 0x00B0DABE
		public void SwitchToNavigationInputType()
		{
			if (this.CurrentInputModule == null)
			{
				return;
			}
			if (this.InputType == ELGUIPointerInputType.Navigation)
			{
				return;
			}
			this.InputType = ELGUIPointerInputType.Navigation;
			this.CurrentInputModule.SwitchToNavigationInputType();
		}

		// Token: 0x0602EAE7 RID: 191207 RVA: 0x00B0F8E8 File Offset: 0x00B0DAE8
		public void Destroy()
		{
			Singleton<InputDevice>.Instance.UnRegisterInputChangeDelegate(new Action<CSharpScript.Launcher.InputDevice.EInputControllerType, CSharpScript.Launcher.InputDevice.EInputControllerType>(this.InputChangeDelegate));
			this.DestroyStandaloneInputModule();
			this.UnRegisterInput();
			if (this.EventSystem != null)
			{
				this.EventSystem.PreDestroy();
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.EventSystem, true);
				UKismetSystemLibrary.CollectGarbage();
				this.EventSystem = null;
			}
			this.CurrentInputModule = null;
			this.TouchInputModule = null;
			this.WorldContext = null;
		}

		// Token: 0x0401A822 RID: 108578
		private const int GAMEPAD_ID = 999;

		// Token: 0x0401A823 RID: 108579
		private ALGUIEventSystemActor EventSystem;

		// Token: 0x0401A824 RID: 108580
		private UObject WorldContext;

		// Token: 0x0401A825 RID: 108581
		private ULGUI_PointerInputModule CurrentInputModule;

		// Token: 0x0401A826 RID: 108582
		private ULGUI_StandaloneInputModule StandaloneInputModule;

		// Token: 0x0401A827 RID: 108583
		private ULGUI_TouchInputModule TouchInputModule;

		// Token: 0x0401A828 RID: 108584
		private FLGUIDelegateHandleWrapper HandleWrapper;

		// Token: 0x0401A829 RID: 108585
		private ELGUIPointerInputType InputType = ELGUIPointerInputType.None;
	}
}
