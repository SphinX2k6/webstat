using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Controller;
using CSharpScript.Game.Input;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E6A RID: 3690
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Controller/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Controller/TsCharacterController.TsCharacterController_C")]
public class TsCharacterController : TsBasePlayerController, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005985 RID: 22917 RVA: 0x0010B71C File Offset: 0x0010991C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06005986 RID: 22918 RVA: 0x0010B78C File Offset: 0x0010998C
	protected override void ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
		base.ChangeRotationOnPossess = false;
		base.bShowMouseCursor = Singleton<Info>.Instance.IsInKeyBoard();
		UKuroInputFunctionLibrary.ApplyInputMode(this);
	}

	// Token: 0x06005987 RID: 22919 RVA: 0x0010B7B4 File Offset: 0x001099B4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveDestroyed()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveDestroyed"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06005988 RID: 22920 RVA: 0x0010B824 File Offset: 0x00109A24
	protected override void ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
		if (this.TsUiKeyHandle != null)
		{
			this.TsUiKeyHandle.Reset();
			this.TsUiKeyHandle = null;
		}
	}

	// Token: 0x06005989 RID: 22921 RVA: 0x0010B848 File Offset: 0x00109A48
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceivePossess(APawn PossessedPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceivePossess"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AController.__ReceivePossess_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AController.__ReceivePossess_FunctionParams*)ptr + 15L / (long)sizeof(AController.__ReceivePossess_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->PossessedPawn) = ((PossessedPawn != null) ? PossessedPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600598A RID: 22922 RVA: 0x0010B8CC File Offset: 0x00109ACC
	protected virtual void ReceivePossess_Implementation(APawn PossessedPawn)
	{
		ControllerBase<CameraController>.Instance.OnPossess(PossessedPawn, "MainCamera");
	}

	// Token: 0x0600598B RID: 22923 RVA: 0x0010B8E0 File Offset: 0x00109AE0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveUnPossess(APawn UnpossessedPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveUnPossess"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AController.__ReceiveUnPossess_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AController.__ReceiveUnPossess_FunctionParams*)ptr + 15L / (long)sizeof(AController.__ReceiveUnPossess_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->UnpossessedPawn) = ((UnpossessedPawn != null) ? UnpossessedPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600598C RID: 22924 RVA: 0x0010B964 File Offset: 0x00109B64
	protected virtual void ReceiveUnPossess_Implementation(APawn UnpossessedPawn)
	{
		ControllerBase<CameraController>.Instance.OnPossess(null, "MainCamera");
	}

	// Token: 0x0600598D RID: 22925 RVA: 0x0010B978 File Offset: 0x00109B78
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe override void OnSetupInputComponent()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnSetupInputComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0600598E RID: 22926 RVA: 0x0010B9E8 File Offset: 0x00109BE8
	protected new void OnSetupInputComponent_Implementation()
	{
		base.OnSetupInputComponent_Implementation();
		this.CursorInputVector = Vector2D.Create(0.0, 0.0);
		this.MoveInputVector = Vector2D.Create(0.0, 0.0);
	}

	// Token: 0x0600598F RID: 22927 RVA: 0x0010BA38 File Offset: 0x00109C38
	protected override void BindActionHandle()
	{
		base.BindActionHandle();
		IReadOnlyList<ActionMapping> allActionMappingConfig = ConfigBase<InputSettingsConfig>.GetOrCreateInstance().GetAllActionMappingConfig();
		if (allActionMappingConfig == null)
		{
			return;
		}
		foreach (ActionMapping actionMapping in allActionMappingConfig)
		{
			base.AddActionHandle(actionMapping.ActionName);
		}
	}

	// Token: 0x06005990 RID: 22928 RVA: 0x0010BA9C File Offset: 0x00109C9C
	protected override void BindAxisHandle()
	{
		base.BindAxisHandle();
		foreach (AxisMapping axisMapping in ConfigBase<InputSettingsConfig>.Instance.GetAllAxisMappingConfig())
		{
			this.AddAxisHandle(axisMapping.AxisName);
		}
	}

	// Token: 0x06005991 RID: 22929 RVA: 0x0010BAFC File Offset: 0x00109CFC
	protected override void BindKeyHandle()
	{
		base.BindKeyHandle();
		if (Singleton<Info>.Instance.UseFastInputCallback)
		{
			if (this.TsUiKeyHandle == null)
			{
				this.TsUiKeyHandle = new TsPureUiKeyHandle();
				this.TsUiKeyHandle.Initialize(this);
			}
			this.TsUiKeyHandle.BindKey();
			return;
		}
		FInputChord finputChord = new FInputChord(new FKey(TsCharacterController.LEFT_BARACKET_NAME), false, false, false, false);
		EInputEvent keyEvent = EInputEvent.IE_Released;
		FName fname = new FName("OnSetUiRootDeactivate");
		base.AddKeyBinding(finputChord, keyEvent, this, fname);
		FInputChord finputChord2 = new FInputChord(new FKey(TsCharacterController.RIGHT_BARACKET_NAME), false, false, false, false);
		EInputEvent keyEvent2 = EInputEvent.IE_Released;
		fname = new FName("OnSetUiRootActive");
		base.AddKeyBinding(finputChord2, keyEvent2, this, fname);
	}

	// Token: 0x06005992 RID: 22930 RVA: 0x0010BB9C File Offset: 0x00109D9C
	[NullableContext(1)]
	protected override void OnInputAxis(string axisName, float value, bool alwaysTick = false)
	{
		base.OnInputAxis(axisName, value, alwaysTick);
		if (axisName == "LookUp")
		{
			this.CursorInputVector.Y = (double)value;
		}
		if (axisName == "Turn")
		{
			this.CursorInputVector.X = (double)value;
		}
		if (axisName == "MoveForward")
		{
			this.MoveInputVector.Y = (double)value;
		}
		if (axisName == "MoveRight")
		{
			this.MoveInputVector.X = (double)value;
		}
	}

	// Token: 0x06005993 RID: 22931 RVA: 0x0010BC1C File Offset: 0x00109E1C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceivePreProcessInput(float deltaTime, bool bGamePaused)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceivePreProcessInput"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ABasePlayerController.__ReceivePreProcessInput_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ABasePlayerController.__ReceivePreProcessInput_FunctionParams*)ptr + 15L / (long)sizeof(ABasePlayerController.__ReceivePreProcessInput_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaTime = deltaTime;
			ptr2->bGamePaused = bGamePaused;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005994 RID: 22932 RVA: 0x0010BC99 File Offset: 0x00109E99
	protected virtual void ReceivePreProcessInput_Implementation(float deltaTime, bool bGamePaused)
	{
		ControllerBase<InputController>.GetOrCreateInstance().PreProcessInput(deltaTime, bGamePaused);
	}

	// Token: 0x06005995 RID: 22933 RVA: 0x0010BCA8 File Offset: 0x00109EA8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceivePostProcessInput(float deltaTime, bool bGamePaused)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceivePostProcessInput"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ABasePlayerController.__ReceivePostProcessInput_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ABasePlayerController.__ReceivePostProcessInput_FunctionParams*)ptr + 15L / (long)sizeof(ABasePlayerController.__ReceivePostProcessInput_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaTime = deltaTime;
			ptr2->bGamePaused = bGamePaused;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005996 RID: 22934 RVA: 0x0010BD25 File Offset: 0x00109F25
	protected virtual void ReceivePostProcessInput_Implementation(float deltaTime, bool bGamePaused)
	{
		ControllerBase<InputController>.Instance.PostProcessInput(deltaTime, bGamePaused);
	}

	// Token: 0x06005997 RID: 22935 RVA: 0x0010BD34 File Offset: 0x00109F34
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnSetUiRootActive()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnSetUiRootActive"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06005998 RID: 22936 RVA: 0x0010BDA4 File Offset: 0x00109FA4
	protected void OnSetUiRootActive_Implementation()
	{
		if (ModelBase<SundryModel>.Instance.CanOpenGmView)
		{
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "按下 】 键显示所有界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiLayer>.Instance.ForceShowUi();
		}
	}

	// Token: 0x06005999 RID: 22937 RVA: 0x0010BDE4 File Offset: 0x00109FE4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnSetUiRootDeactivate()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnSetUiRootDeactivate"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0600599A RID: 22938 RVA: 0x0010BE54 File Offset: 0x0010A054
	protected void OnSetUiRootDeactivate_Implementation()
	{
		if (ModelBase<SundryModel>.Instance.CanOpenGmView)
		{
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "按下 【 键隐藏所有界面", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<UiLayer>.Instance.ForceHideUi();
		}
	}

	// Token: 0x0600599B RID: 22939 RVA: 0x0010BE93 File Offset: 0x0010A093
	public Vector2D GetCursorInputVector()
	{
		return this.CursorInputVector;
	}

	// Token: 0x0600599C RID: 22940 RVA: 0x0010BE9B File Offset: 0x0010A09B
	public Vector2D GetMoveInputVector()
	{
		return this.MoveInputVector;
	}

	// Token: 0x0600599D RID: 22941 RVA: 0x0010BEA3 File Offset: 0x0010A0A3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsCharacterController._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Controller/TsCharacterController.TsCharacterController_C");
		}
		return TsCharacterController._ClassPtr;
	}

	// Token: 0x0600599E RID: 22942 RVA: 0x0010BEC8 File Offset: 0x0010A0C8
	public TsCharacterController() : this(BuiltinUtils.AllocNativeUObject(TsCharacterController.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600599F RID: 22943 RVA: 0x0010BEF0 File Offset: 0x0010A0F0
	[NullableContext(1)]
	public TsCharacterController(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060059A0 RID: 22944 RVA: 0x0010BF23 File Offset: 0x0010A123
	protected TsCharacterController(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060059A1 RID: 22945 RVA: 0x0010BF2C File Offset: 0x0010A12C
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x060059A2 RID: 22946 RVA: 0x0010BF34 File Offset: 0x0010A134
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		this.ReceiveDestroyed_Implementation();
	}

	// Token: 0x060059A3 RID: 22947 RVA: 0x0010BF3C File Offset: 0x0010A13C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceivePossess_Implementation(AController.__ReceivePossess_FunctionParams* __Params)
	{
		APawn orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->PossessedPawn);
		this.ReceivePossess_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060059A4 RID: 22948 RVA: 0x0010BF5C File Offset: 0x0010A15C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveUnPossess_Implementation(AController.__ReceiveUnPossess_FunctionParams* __Params)
	{
		APawn orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->UnpossessedPawn);
		this.ReceiveUnPossess_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x060059A5 RID: 22949 RVA: 0x0010BF7C File Offset: 0x0010A17C
	protected override void __CPPCALL_OnSetupInputComponent_Implementation()
	{
		this.OnSetupInputComponent_Implementation();
	}

	// Token: 0x060059A6 RID: 22950 RVA: 0x0010BF84 File Offset: 0x0010A184
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceivePreProcessInput_Implementation(ABasePlayerController.__ReceivePreProcessInput_FunctionParams* __Params)
	{
		this.ReceivePreProcessInput_Implementation(__Params->DeltaTime, __Params->bGamePaused);
	}

	// Token: 0x060059A7 RID: 22951 RVA: 0x0010BF98 File Offset: 0x0010A198
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceivePostProcessInput_Implementation(ABasePlayerController.__ReceivePostProcessInput_FunctionParams* __Params)
	{
		this.ReceivePostProcessInput_Implementation(__Params->DeltaTime, __Params->bGamePaused);
	}

	// Token: 0x060059A8 RID: 22952 RVA: 0x0010BFAC File Offset: 0x0010A1AC
	protected virtual void __CPPCALL_OnSetUiRootActive_Implementation()
	{
		this.OnSetUiRootActive_Implementation();
	}

	// Token: 0x060059A9 RID: 22953 RVA: 0x0010BFB4 File Offset: 0x0010A1B4
	protected virtual void __CPPCALL_OnSetUiRootDeactivate_Implementation()
	{
		this.OnSetUiRootDeactivate_Implementation();
	}

	// Token: 0x04002975 RID: 10613
	private static readonly FName LEFT_BARACKET_NAME = new FName("LeftBracket");

	// Token: 0x04002976 RID: 10614
	private static readonly FName RIGHT_BARACKET_NAME = new FName("RightBracket");

	// Token: 0x04002977 RID: 10615
	private Vector2D CursorInputVector;

	// Token: 0x04002978 RID: 10616
	private Vector2D MoveInputVector;

	// Token: 0x04002979 RID: 10617
	private TsPureUiKeyHandle TsUiKeyHandle;

	// Token: 0x0400297A RID: 10618
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Controller/TsCharacterController.TsCharacterController_C";

	// Token: 0x0400297B RID: 10619
	private static IntPtr _ClassPtr;

	// Token: 0x0400297C RID: 10620
	private static IntPtr _ClassDefaultObjectPtr;
}
