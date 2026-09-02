using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Controller;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E69 RID: 3689
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Controller/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Controller/TsBasePlayerController.TsBasePlayerController_C")]
public class TsBasePlayerController : ABasePlayerController, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000648 RID: 1608
	// (get) Token: 0x06005928 RID: 22824 RVA: 0x00109FFA File Offset: 0x001081FA
	// (set) Token: 0x06005929 RID: 22825 RVA: 0x0010A00E File Offset: 0x0010820E
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe TSubclassOf<TsActionHandle> ActionHandleClass
	{
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		get
		{
			return *(base.NativePtr + (IntPtr)TsBasePlayerController.__PropertyOffset_ActionHandleClass);
		}
		[param: Nullable(new byte[]
		{
			0,
			1
		})]
		set
		{
			*(base.NativePtr + (IntPtr)TsBasePlayerController.__PropertyOffset_ActionHandleClass) = value;
		}
	}

	// Token: 0x17000649 RID: 1609
	// (get) Token: 0x0600592A RID: 22826 RVA: 0x0010A023 File Offset: 0x00108223
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe TSubclassOf<TsAxisHandle> AxisHandleClass
	{
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		get
		{
			return *(base.NativePtr + (IntPtr)TsBasePlayerController.__PropertyOffset_AxisHandleClass);
		}
	}

	// Token: 0x1700064A RID: 1610
	// (get) Token: 0x0600592B RID: 22827 RVA: 0x0010A038 File Offset: 0x00108238
	[UProperty(EPropertyFlags.CPF_None)]
	private TMap<string, TsActionHandle> ActionHandleMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, TsActionHandle> result;
			if ((result = this._ActionHandleMap) == null)
			{
				result = (this._ActionHandleMap = new TMap<string, TsActionHandle>(base.NativePtr + (IntPtr)TsBasePlayerController.__PropertyOffset_ActionHandleMap, this));
			}
			return result;
		}
	}

	// Token: 0x1700064B RID: 1611
	// (get) Token: 0x0600592C RID: 22828 RVA: 0x0010A074 File Offset: 0x00108274
	[UProperty(EPropertyFlags.CPF_None)]
	private TMap<string, TsAxisHandle> AxisHandleMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<string, TsAxisHandle> result;
			if ((result = this._AxisHandleMap) == null)
			{
				result = (this._AxisHandleMap = new TMap<string, TsAxisHandle>(base.NativePtr + (IntPtr)TsBasePlayerController.__PropertyOffset_AxisHandleMap, this));
			}
			return result;
		}
	}

	// Token: 0x0600592D RID: 22829 RVA: 0x0010A0B0 File Offset: 0x001082B0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveSetupInputComponent()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveSetupInputComponent"), out num);
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

	// Token: 0x0600592E RID: 22830 RVA: 0x0010A120 File Offset: 0x00108320
	protected virtual void ReceiveSetupInputComponent_Implementation()
	{
		this.InitInputHandle();
		this.AddInputBinding();
		this.OnSetupInputComponent();
	}

	// Token: 0x0600592F RID: 22831 RVA: 0x0010A134 File Offset: 0x00108334
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

	// Token: 0x06005930 RID: 22832 RVA: 0x0010A1A4 File Offset: 0x001083A4
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		this.InitInputHandle();
	}

	// Token: 0x06005931 RID: 22833 RVA: 0x0010A1AC File Offset: 0x001083AC
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

	// Token: 0x06005932 RID: 22834 RVA: 0x0010A21C File Offset: 0x0010841C
	protected virtual void ReceiveDestroyed_Implementation()
	{
		if (!ObjectUtils.IsValid(this))
		{
			return;
		}
		this.ClearInputBinding();
		if (this.PlayerInputHandle != null)
		{
			this.PlayerInputHandle.Clear();
			this.PlayerInputHandle = null;
		}
		if (this.TsKeyHandle != null)
		{
			this.TsKeyHandle.Reset();
			this.TsKeyHandle = null;
		}
		if (this.TsTouchHandle != null)
		{
			this.TsTouchHandle.Reset();
			this.TsTouchHandle = null;
		}
	}

	// Token: 0x06005933 RID: 22835 RVA: 0x0010A288 File Offset: 0x00108488
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005934 RID: 22836 RVA: 0x0010A2FE File Offset: 0x001084FE
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
		if (playerInputHandle == null)
		{
			return;
		}
		playerInputHandle.Tick(deltaSeconds);
	}

	// Token: 0x06005935 RID: 22837 RVA: 0x0010A314 File Offset: 0x00108514
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnReceivedPlayer()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnReceivedPlayer"), out num);
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

	// Token: 0x06005936 RID: 22838 RVA: 0x0010A384 File Offset: 0x00108584
	protected virtual void OnReceivedPlayer_Implementation()
	{
		UKuroInputFunctionLibrary.ResetInputMode(this);
	}

	// Token: 0x06005937 RID: 22839 RVA: 0x0010A38C File Offset: 0x0010858C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InitInputHandle()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitInputHandle"), out num);
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

	// Token: 0x06005938 RID: 22840 RVA: 0x0010A3FC File Offset: 0x001085FC
	protected void InitInputHandle_Implementation()
	{
		if (this.PlayerInputHandle != null)
		{
			return;
		}
		this.PlayerInputHandle = new PlayerInputHandle();
		this.PlayerInputHandle.Initialize();
		if (this.TsKeyHandle == null)
		{
			this.TsKeyHandle = new TsPureKeyHandle();
			this.TsKeyHandle.Initialize(this, this.PlayerInputHandle);
		}
		if (this.TsTouchHandle == null)
		{
			this.TsTouchHandle = new TsPureTouchHandle();
			this.TsTouchHandle.Initialize(this, this.PlayerInputHandle);
		}
	}

	// Token: 0x06005939 RID: 22841 RVA: 0x0010A474 File Offset: 0x00108674
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void AddInputBinding()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddInputBinding"), out num);
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

	// Token: 0x0600593A RID: 22842 RVA: 0x0010A4E4 File Offset: 0x001086E4
	protected void AddInputBinding_Implementation()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InputSettings;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "添加PlayerController绑定输入";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerController", this);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.BindActionHandle();
		this.BindAxisHandle();
		this.BindKeyHandle();
		this.BindTouchHandle();
	}

	// Token: 0x0600593B RID: 22843 RVA: 0x0010A530 File Offset: 0x00108730
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void ClearInputBinding()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ClearInputBinding"), out num);
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

	// Token: 0x0600593C RID: 22844 RVA: 0x0010A5A0 File Offset: 0x001087A0
	protected void ClearInputBinding_Implementation()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.InputSettings;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "清理PlayerController绑定输入";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayerController", this);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (Singleton<Info>.Instance.UseFastInputCallback)
		{
			UKuroInputDelegateLibrary.ClearInputBinding(this);
		}
		else
		{
			base.ClearActionBindings();
			base.ClearAxisBindings();
			base.ClearKeyBindings();
			base.ClearTouchBindings();
		}
		this.ClearActionHandle();
		this.ClearAxisHandle();
		this.OnInputActionCallback = null;
		this.OnInputAxisCallback = null;
	}

	// Token: 0x0600593D RID: 22845 RVA: 0x0010A61C File Offset: 0x0010881C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnSetupInputComponent()
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

	// Token: 0x0600593E RID: 22846 RVA: 0x0010A68C File Offset: 0x0010888C
	protected void OnSetupInputComponent_Implementation()
	{
		this.CurrentInputPosition = Vector2D.Create(0.0, 0.0);
	}

	// Token: 0x0600593F RID: 22847 RVA: 0x0010A6AB File Offset: 0x001088AB
	protected virtual void BindActionHandle()
	{
	}

	// Token: 0x06005940 RID: 22848 RVA: 0x0010A6AD File Offset: 0x001088AD
	protected virtual void BindAxisHandle()
	{
	}

	// Token: 0x06005941 RID: 22849 RVA: 0x0010A6B0 File Offset: 0x001088B0
	protected virtual void BindKeyHandle()
	{
		if (!Singleton<Info>.Instance.UseFastInputCallback)
		{
			FInputChord finputChord = new FInputChord(new FKey(FNameUtil.GetDynamicFName("AnyKey") ?? FName.NAME_None), false, false, false, false);
			EInputEvent keyEvent = EInputEvent.IE_Pressed;
			FName fname = new FName("OnPressAnyKey");
			base.AddKeyBinding(finputChord, keyEvent, this, fname);
			EInputEvent keyEvent2 = EInputEvent.IE_Released;
			fname = new FName("OnReleaseAnyKey");
			base.AddKeyBinding(finputChord, keyEvent2, this, fname);
			return;
		}
		if (this.TsKeyHandle != null)
		{
			this.TsKeyHandle.BindKey();
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.WLJ, "BindKeyHandle Failed, TsKeyHandle is null", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005942 RID: 22850 RVA: 0x0010A75C File Offset: 0x0010895C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void BindTouchHandle()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("BindTouchHandle"), out num);
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

	// Token: 0x06005943 RID: 22851 RVA: 0x0010A7CC File Offset: 0x001089CC
	protected void BindTouchHandle_Implementation()
	{
		if (!Singleton<Info>.Instance.UseFastInputCallback)
		{
			EInputEvent keyEvent = EInputEvent.IE_Pressed;
			FName fname = new FName("OnTouchBegin");
			base.AddTouchBinding(keyEvent, this, fname);
			EInputEvent keyEvent2 = EInputEvent.IE_Released;
			fname = new FName("OnTouchEnd");
			base.AddTouchBinding(keyEvent2, this, fname);
			EInputEvent keyEvent3 = EInputEvent.IE_Repeat;
			fname = new FName("OnTouchMove");
			base.AddTouchBinding(keyEvent3, this, fname);
			return;
		}
		if (this.TsTouchHandle != null)
		{
			this.TsTouchHandle.BindTouch();
			return;
		}
		Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.WLJ, "BindKeyHandle Failed, TsTouchHandle is null", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06005944 RID: 22852 RVA: 0x0010A855 File Offset: 0x00108A55
	protected virtual void OnInputAction(string actionName, bool bPress, FKey key)
	{
		ModelBase<LogReportModel>.GetOrCreateInstance().RecordOperateTime(false, "", 0.0);
		this.PlayerInputHandle.InputAction(actionName, bPress, key);
	}

	// Token: 0x06005945 RID: 22853 RVA: 0x0010A87E File Offset: 0x00108A7E
	protected virtual void OnInputAxis(string axisName, float value, bool alwaysTick = false)
	{
		ModelBase<LogReportModel>.GetOrCreateInstance().RecordOperateTime(true, axisName, (double)value);
		this.PlayerInputHandle.InputAxis(axisName, value, alwaysTick);
	}

	// Token: 0x06005946 RID: 22854 RVA: 0x0010A89C File Offset: 0x00108A9C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnTouchBegin(ETouchIndex touchIndex, FVector position)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnTouchBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__OnTouchBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__OnTouchBegin_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__OnTouchBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->touchIndex) = (byte)touchIndex;
			ptr2->position = position;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005947 RID: 22855 RVA: 0x0010A91C File Offset: 0x00108B1C
	protected void OnTouchBegin_Implementation(ETouchIndex touchIndex, FVector position)
	{
		this.PlayerInputHandle.TouchBegin(touchIndex, position);
		ModelBase<LogReportModel>.GetOrCreateInstance().RecordOperateTime(false, "", 0.0);
	}

	// Token: 0x06005948 RID: 22856 RVA: 0x0010A944 File Offset: 0x00108B44
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnTouchEnd(ETouchIndex touchIndex, FVector position)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnTouchEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__OnTouchEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__OnTouchEnd_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__OnTouchEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->touchIndex) = (byte)touchIndex;
			ptr2->position = position;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005949 RID: 22857 RVA: 0x0010A9C4 File Offset: 0x00108BC4
	protected void OnTouchEnd_Implementation(ETouchIndex touchIndex, FVector position)
	{
		this.PlayerInputHandle.TouchEnd(touchIndex, position);
	}

	// Token: 0x0600594A RID: 22858 RVA: 0x0010A9D4 File Offset: 0x00108BD4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnTouchMove(ETouchIndex touchIndex, FVector position)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnTouchMove"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__OnTouchMove_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__OnTouchMove_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__OnTouchMove_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->touchIndex) = (byte)touchIndex;
			ptr2->position = position;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600594B RID: 22859 RVA: 0x0010AA54 File Offset: 0x00108C54
	protected void OnTouchMove_Implementation(ETouchIndex touchIndex, FVector position)
	{
		this.PlayerInputHandle.TouchMove(touchIndex, position);
	}

	// Token: 0x0600594C RID: 22860 RVA: 0x0010AA64 File Offset: 0x00108C64
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnPressAnyKey(FKey key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPressAnyKey"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__OnPressAnyKey_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__OnPressAnyKey_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__OnPressAnyKey_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr2->key, (key != null) ? key.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600594D RID: 22861 RVA: 0x0010AAF3 File Offset: 0x00108CF3
	protected void OnPressAnyKey_Implementation(FKey key)
	{
		ModelBase<LogReportModel>.GetOrCreateInstance().RecordOperateTime(false, "", 0.0);
		this.PlayerInputHandle.PressAnyKey(key);
		ModelBase<PlatformModel>.GetOrCreateInstance().OnPressAnyKey(key);
	}

	// Token: 0x0600594E RID: 22862 RVA: 0x0010AB28 File Offset: 0x00108D28
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void OnReleaseAnyKey(FKey key)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnReleaseAnyKey"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__OnReleaseAnyKey_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__OnReleaseAnyKey_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__OnReleaseAnyKey_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr2->key, (key != null) ? key.NativePtr : ((IntPtr)0), 1, false);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600594F RID: 22863 RVA: 0x0010ABB7 File Offset: 0x00108DB7
	protected void OnReleaseAnyKey_Implementation(FKey key)
	{
		this.PlayerInputHandle.ReleaseAnyKey(key);
	}

	// Token: 0x06005950 RID: 22864 RVA: 0x0010ABC8 File Offset: 0x00108DC8
	protected void AddActionHandle(string actionName)
	{
		if (Singleton<Info>.Instance.UseFastInputCallback)
		{
			if (this.TsActionHandleMap == null)
			{
				this.TsActionHandleMap = new Dictionary<string, TsPureActionHandle>();
			}
			TsPureActionHandle tsPureActionHandle;
			if (!this.TsActionHandleMap.TryGetValue(actionName, out tsPureActionHandle))
			{
				tsPureActionHandle = new TsPureActionHandle();
				tsPureActionHandle.Initialize(this);
				this.TsActionHandleMap[actionName] = tsPureActionHandle;
			}
			this.OnInputActionCallback = new Action<string, bool, FKey>(this.OnInputAction);
			tsPureActionHandle.AddActionBinding(actionName, this.OnInputActionCallback);
			return;
		}
		TsActionHandle tsActionHandle = this.GetActionHandle(actionName);
		if (tsActionHandle == null)
		{
			tsActionHandle = this.NewActionHandle(actionName);
		}
		if (tsActionHandle == null)
		{
			return;
		}
		this.OnInputActionCallback = new Action<string, bool, FKey>(this.OnInputAction);
		tsActionHandle.AddActionBinding(actionName, this.OnInputActionCallback);
	}

	// Token: 0x06005951 RID: 22865 RVA: 0x0010AC78 File Offset: 0x00108E78
	[return: Nullable(2)]
	protected virtual TsActionHandle NewActionHandle(string actionName)
	{
		if (this.ActionHandleClass == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Controller;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前Controller中的ActionHandleClass不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ControllerName", this);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		TsActionHandle tsActionHandle = new TsActionHandle();
		tsActionHandle.Initialize(this);
		this.ActionHandleMap.Add(actionName, tsActionHandle);
		return tsActionHandle;
	}

	// Token: 0x06005952 RID: 22866 RVA: 0x0010ACE0 File Offset: 0x00108EE0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void RemoveActionHandle(string actionName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveActionHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__RemoveActionHandle_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__RemoveActionHandle_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__RemoveActionHandle_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->actionName), actionName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005953 RID: 22867 RVA: 0x0010AD5C File Offset: 0x00108F5C
	protected void RemoveActionHandle_Implementation(string actionName)
	{
		TsActionHandle actionHandle = this.GetActionHandle(actionName);
		if (actionHandle == null)
		{
			return;
		}
		actionHandle.Reset();
		this.ActionHandleMap.Remove(actionName);
	}

	// Token: 0x06005954 RID: 22868 RVA: 0x0010AD88 File Offset: 0x00108F88
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	[return: Nullable(2)]
	protected unsafe virtual TsActionHandle GetActionHandle(string actionName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetActionHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__GetActionHandle_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__GetActionHandle_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__GetActionHandle_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->actionName), actionName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		TsActionHandle orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsActionHandle>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x06005955 RID: 22869 RVA: 0x0010AE0F File Offset: 0x0010900F
	[return: Nullable(2)]
	protected TsActionHandle GetActionHandle_Implementation(string actionName)
	{
		TMap<string, TsActionHandle> actionHandleMap = this.ActionHandleMap;
		if (actionHandleMap == null)
		{
			return null;
		}
		return actionHandleMap.Get(actionName);
	}

	// Token: 0x06005956 RID: 22870 RVA: 0x0010AE24 File Offset: 0x00109024
	private void ClearActionHandle()
	{
		if (!Singleton<Info>.Instance.UseFastInputCallback)
		{
			foreach (TsActionHandle tsActionHandle in this.ActionHandleMap.Values)
			{
				if (tsActionHandle != null)
				{
					tsActionHandle.Reset();
				}
			}
			this.ActionHandleMap.Empty(0);
			return;
		}
		if (this.TsActionHandleMap == null)
		{
			return;
		}
		foreach (KeyValuePair<string, TsPureActionHandle> keyValuePair in this.TsActionHandleMap)
		{
			TsPureActionHandle value = keyValuePair.Value;
			if (value != null)
			{
				value.Reset();
			}
		}
		this.TsActionHandleMap.Clear();
	}

	// Token: 0x06005957 RID: 22871 RVA: 0x0010AF00 File Offset: 0x00109100
	protected virtual void AddAxisHandle(string axisName)
	{
		if (Singleton<Info>.Instance.UseFastInputCallback)
		{
			if (this.TsAxisHandleMap == null)
			{
				this.TsAxisHandleMap = new Dictionary<string, TsPureAxisHandle>();
			}
			TsPureAxisHandle tsPureAxisHandle;
			if (!this.TsAxisHandleMap.TryGetValue(axisName, out tsPureAxisHandle))
			{
				tsPureAxisHandle = new TsPureAxisHandle();
				tsPureAxisHandle.Initialize(this);
				this.TsAxisHandleMap[axisName] = tsPureAxisHandle;
			}
			this.OnInputAxisCallbackNew = new Action<string, float, bool>(this.OnInputAxis);
			tsPureAxisHandle.AddAxisBinding(axisName, this.OnInputAxisCallbackNew);
			return;
		}
		TsAxisHandle tsAxisHandle = this.GetAxisHandle(axisName);
		if (tsAxisHandle == null)
		{
			tsAxisHandle = this.NewAxisHandle(axisName);
		}
		if (tsAxisHandle == null)
		{
			return;
		}
		this.OnInputAxisCallback = delegate(string axisNameInner, float value)
		{
			this.OnInputAxis(axisNameInner, value, false);
		};
		tsAxisHandle.AddAxisBinding(axisName, this.OnInputAxisCallback);
	}

	// Token: 0x06005958 RID: 22872 RVA: 0x0010AFB0 File Offset: 0x001091B0
	[return: Nullable(2)]
	protected virtual TsAxisHandle NewAxisHandle(string axisName)
	{
		if (this.AxisHandleClass == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Controller;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "当前Controller中的AxisHandleClass不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ControllerName", this);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		TsAxisHandle tsAxisHandle = new TsAxisHandle();
		tsAxisHandle.Initialize(this);
		this.AxisHandleMap.Add(axisName, tsAxisHandle);
		return tsAxisHandle;
	}

	// Token: 0x06005959 RID: 22873 RVA: 0x0010B018 File Offset: 0x00109218
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void RemoveAxisHandle(string axisName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveAxisHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__RemoveAxisHandle_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__RemoveAxisHandle_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__RemoveAxisHandle_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->axisName), axisName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0600595A RID: 22874 RVA: 0x0010B094 File Offset: 0x00109294
	protected void RemoveAxisHandle_Implementation(string axisName)
	{
		TsAxisHandle axisHandle = this.GetAxisHandle(axisName);
		if (axisHandle == null)
		{
			return;
		}
		axisHandle.Reset();
		this.AxisHandleMap.Remove(axisName);
	}

	// Token: 0x0600595B RID: 22875 RVA: 0x0010B0C0 File Offset: 0x001092C0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	[return: Nullable(2)]
	protected unsafe virtual TsAxisHandle GetAxisHandle(string actionName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetAxisHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__GetAxisHandle_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__GetAxisHandle_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__GetAxisHandle_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->actionName), actionName);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		TsAxisHandle orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsAxisHandle>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0600595C RID: 22876 RVA: 0x0010B147 File Offset: 0x00109347
	[return: Nullable(2)]
	protected TsAxisHandle GetAxisHandle_Implementation(string actionName)
	{
		TMap<string, TsAxisHandle> axisHandleMap = this.AxisHandleMap;
		if (axisHandleMap == null)
		{
			return null;
		}
		return axisHandleMap.Get(actionName);
	}

	// Token: 0x0600595D RID: 22877 RVA: 0x0010B15C File Offset: 0x0010935C
	private void ClearAxisHandle()
	{
		if (!Singleton<Info>.Instance.UseFastInputCallback)
		{
			foreach (TsAxisHandle tsAxisHandle in this.AxisHandleMap.Values)
			{
				if (tsAxisHandle != null)
				{
					tsAxisHandle.Reset();
				}
			}
			this.AxisHandleMap.Empty(0);
			return;
		}
		if (this.TsAxisHandleMap == null)
		{
			return;
		}
		foreach (KeyValuePair<string, TsPureAxisHandle> keyValuePair in this.TsAxisHandleMap)
		{
			TsPureAxisHandle value = keyValuePair.Value;
			if (value != null)
			{
				value.Reset();
			}
		}
		this.TsAxisHandleMap.Clear();
	}

	// Token: 0x0600595E RID: 22878 RVA: 0x0010B238 File Offset: 0x00109438
	[NullableContext(2)]
	public virtual Vector2D GetInputPosition(int touchId = 0)
	{
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			return this.GetCursorPosition();
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return this.GetTouchPosition(touchId);
		}
		return null;
	}

	// Token: 0x0600595F RID: 22879 RVA: 0x0010B264 File Offset: 0x00109464
	[NullableContext(2)]
	public virtual Vector2D GetCursorPosition()
	{
		float num = 0f;
		float num2 = 0f;
		if (!base.GetMousePosition(ref num, ref num2))
		{
			return null;
		}
		this.CurrentInputPosition.X = (double)num;
		this.CurrentInputPosition.Y = (double)num2;
		return this.CurrentInputPosition;
	}

	// Token: 0x06005960 RID: 22880 RVA: 0x0010B2AC File Offset: 0x001094AC
	[NullableContext(2)]
	public virtual Vector2D GetTouchPosition(int touchId)
	{
		float num = 0f;
		float num2 = 0f;
		bool flag = false;
		base.GetInputTouchState((ETouchIndex)touchId, ref num, ref num2, ref flag);
		this.CurrentInputPosition.X = (double)num;
		this.CurrentInputPosition.Y = (double)num2;
		return this.CurrentInputPosition;
	}

	// Token: 0x06005961 RID: 22881 RVA: 0x0010B2F4 File Offset: 0x001094F4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool IsInTouch(float touchId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("IsInTouch"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__IsInTouch_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__IsInTouch_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__IsInTouch_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->touchId = touchId;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06005962 RID: 22882 RVA: 0x0010B370 File Offset: 0x00109570
	protected bool IsInTouch_Implementation(float touchId)
	{
		float num = 0f;
		float num2 = 0f;
		bool result = false;
		base.GetInputTouchState((ETouchIndex)touchId, ref num, ref num2, ref result);
		return result;
	}

	// Token: 0x06005963 RID: 22883 RVA: 0x0010B39C File Offset: 0x0010959C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetIsPrintKeyName(bool bPrintKeyName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetIsPrintKeyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsBasePlayerController.__SetIsPrintKeyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsBasePlayerController.__SetIsPrintKeyName_FunctionParams*)ptr + 15L / (long)sizeof(TsBasePlayerController.__SetIsPrintKeyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->bPrintKeyName = bPrintKeyName;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005964 RID: 22884 RVA: 0x0010B412 File Offset: 0x00109612
	protected void SetIsPrintKeyName_Implementation(bool bPrintKeyName)
	{
		this.PlayerInputHandle.IsPrintKeyName = bPrintKeyName;
	}

	// Token: 0x06005965 RID: 22885 RVA: 0x0010B420 File Offset: 0x00109620
	public virtual void SimulateTouch(ETouchIndex touchIndex, FVector position, bool isPress)
	{
		if (isPress)
		{
			this.PlayerInputHandle.TouchBegin(touchIndex, position);
			return;
		}
		this.PlayerInputHandle.TouchEnd(touchIndex, position);
	}

	// Token: 0x06005966 RID: 22886 RVA: 0x0010B440 File Offset: 0x00109640
	public virtual void SetCustomAction(string keyName, string actionName)
	{
		PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
		if (playerInputHandle == null)
		{
			return;
		}
		playerInputHandle.SetCustomAction(keyName, actionName);
	}

	// Token: 0x06005967 RID: 22887 RVA: 0x0010B454 File Offset: 0x00109654
	public virtual void ResetAllCustomAction(string keyName)
	{
		PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
		if (playerInputHandle == null)
		{
			return;
		}
		playerInputHandle.ResetAllCustomAction(keyName);
	}

	// Token: 0x06005968 RID: 22888 RVA: 0x0010B467 File Offset: 0x00109667
	public virtual void ResetCustomAction(string keyName, string actionName)
	{
		PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
		if (playerInputHandle == null)
		{
			return;
		}
		playerInputHandle.ResetCustomAction(keyName, actionName);
	}

	// Token: 0x06005969 RID: 22889 RVA: 0x0010B47B File Offset: 0x0010967B
	public virtual void SetActionEnable(string actionName, bool bEnable)
	{
		PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
		if (playerInputHandle == null)
		{
			return;
		}
		playerInputHandle.SetActionEnable(actionName, bEnable);
	}

	// Token: 0x0600596A RID: 22890 RVA: 0x0010B48F File Offset: 0x0010968F
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public virtual List<string> GetCurrentPlatformCustomActionKeyNameList(string actionName)
	{
		PlayerInputHandle playerInputHandle = this.PlayerInputHandle;
		if (playerInputHandle == null)
		{
			return null;
		}
		return playerInputHandle.GetCurrentPlatformCustomActionKeyNameList(actionName);
	}

	// Token: 0x0600596B RID: 22891 RVA: 0x0010B4A3 File Offset: 0x001096A3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBasePlayerController._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Controller/TsBasePlayerController.TsBasePlayerController_C");
		}
		return TsBasePlayerController._ClassPtr;
	}

	// Token: 0x0600596C RID: 22892 RVA: 0x0010B4C8 File Offset: 0x001096C8
	public TsBasePlayerController() : this(BuiltinUtils.AllocNativeUObject(TsBasePlayerController.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600596D RID: 22893 RVA: 0x0010B4F0 File Offset: 0x001096F0
	public TsBasePlayerController(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBasePlayerController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600596E RID: 22894 RVA: 0x0010B523 File Offset: 0x00109723
	protected TsBasePlayerController(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600596F RID: 22895 RVA: 0x0010B52C File Offset: 0x0010972C
	protected virtual void __CPPCALL_ReceiveSetupInputComponent_Implementation()
	{
		this.ReceiveSetupInputComponent_Implementation();
	}

	// Token: 0x06005970 RID: 22896 RVA: 0x0010B534 File Offset: 0x00109734
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x06005971 RID: 22897 RVA: 0x0010B53C File Offset: 0x0010973C
	protected virtual void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		this.ReceiveDestroyed_Implementation();
	}

	// Token: 0x06005972 RID: 22898 RVA: 0x0010B544 File Offset: 0x00109744
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x06005973 RID: 22899 RVA: 0x0010B552 File Offset: 0x00109752
	protected virtual void __CPPCALL_OnReceivedPlayer_Implementation()
	{
		this.OnReceivedPlayer_Implementation();
	}

	// Token: 0x06005974 RID: 22900 RVA: 0x0010B55A File Offset: 0x0010975A
	protected virtual void __CPPCALL_InitInputHandle_Implementation()
	{
		this.InitInputHandle_Implementation();
	}

	// Token: 0x06005975 RID: 22901 RVA: 0x0010B562 File Offset: 0x00109762
	protected virtual void __CPPCALL_AddInputBinding_Implementation()
	{
		this.AddInputBinding_Implementation();
	}

	// Token: 0x06005976 RID: 22902 RVA: 0x0010B56A File Offset: 0x0010976A
	protected virtual void __CPPCALL_ClearInputBinding_Implementation()
	{
		this.ClearInputBinding_Implementation();
	}

	// Token: 0x06005977 RID: 22903 RVA: 0x0010B572 File Offset: 0x00109772
	protected virtual void __CPPCALL_OnSetupInputComponent_Implementation()
	{
		this.OnSetupInputComponent_Implementation();
	}

	// Token: 0x06005978 RID: 22904 RVA: 0x0010B57A File Offset: 0x0010977A
	protected virtual void __CPPCALL_BindTouchHandle_Implementation()
	{
		this.BindTouchHandle_Implementation();
	}

	// Token: 0x06005979 RID: 22905 RVA: 0x0010B584 File Offset: 0x00109784
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnTouchBegin_Implementation(TsBasePlayerController.__OnTouchBegin_FunctionParams* __Params)
	{
		ETouchIndex touchIndex = (ETouchIndex)__Params->touchIndex;
		this.OnTouchBegin_Implementation(touchIndex, __Params->position);
	}

	// Token: 0x0600597A RID: 22906 RVA: 0x0010B5A8 File Offset: 0x001097A8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnTouchEnd_Implementation(TsBasePlayerController.__OnTouchEnd_FunctionParams* __Params)
	{
		ETouchIndex touchIndex = (ETouchIndex)__Params->touchIndex;
		this.OnTouchEnd_Implementation(touchIndex, __Params->position);
	}

	// Token: 0x0600597B RID: 22907 RVA: 0x0010B5CC File Offset: 0x001097CC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnTouchMove_Implementation(TsBasePlayerController.__OnTouchMove_FunctionParams* __Params)
	{
		ETouchIndex touchIndex = (ETouchIndex)__Params->touchIndex;
		this.OnTouchMove_Implementation(touchIndex, __Params->position);
	}

	// Token: 0x0600597C RID: 22908 RVA: 0x0010B5F0 File Offset: 0x001097F0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnPressAnyKey_Implementation(TsBasePlayerController.__OnPressAnyKey_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		this.OnPressAnyKey_Implementation(key);
	}

	// Token: 0x0600597D RID: 22909 RVA: 0x0010B614 File Offset: 0x00109814
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnReleaseAnyKey_Implementation(TsBasePlayerController.__OnReleaseAnyKey_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		this.OnReleaseAnyKey_Implementation(key);
	}

	// Token: 0x0600597E RID: 22910 RVA: 0x0010B638 File Offset: 0x00109838
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_RemoveActionHandle_Implementation(TsBasePlayerController.__RemoveActionHandle_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		this.RemoveActionHandle_Implementation(actionName);
	}

	// Token: 0x0600597F RID: 22911 RVA: 0x0010B65C File Offset: 0x0010985C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetActionHandle_Implementation(TsBasePlayerController.__GetActionHandle_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsActionHandle actionHandle_Implementation = this.GetActionHandle_Implementation(actionName);
		ptr = ((actionHandle_Implementation != null) ? actionHandle_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06005980 RID: 22912 RVA: 0x0010B694 File Offset: 0x00109894
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_RemoveAxisHandle_Implementation(TsBasePlayerController.__RemoveAxisHandle_FunctionParams* __Params)
	{
		string axisName = FString.ToString((void*)(&__Params->axisName));
		this.RemoveAxisHandle_Implementation(axisName);
	}

	// Token: 0x06005981 RID: 22913 RVA: 0x0010B6B8 File Offset: 0x001098B8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetAxisHandle_Implementation(TsBasePlayerController.__GetAxisHandle_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsAxisHandle axisHandle_Implementation = this.GetAxisHandle_Implementation(actionName);
		ptr = ((axisHandle_Implementation != null) ? axisHandle_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x06005982 RID: 22914 RVA: 0x0010B6EE File Offset: 0x001098EE
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_IsInTouch_Implementation(TsBasePlayerController.__IsInTouch_FunctionParams* __Params)
	{
		__Params->__Result = this.IsInTouch_Implementation(__Params->touchId);
	}

	// Token: 0x06005983 RID: 22915 RVA: 0x0010B702 File Offset: 0x00109902
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetIsPrintKeyName_Implementation(TsBasePlayerController.__SetIsPrintKeyName_FunctionParams* __Params)
	{
		this.SetIsPrintKeyName_Implementation(__Params->bPrintKeyName);
	}

	// Token: 0x04002963 RID: 10595
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, TsPureActionHandle> TsActionHandleMap;

	// Token: 0x04002964 RID: 10596
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, TsPureAxisHandle> TsAxisHandleMap;

	// Token: 0x04002965 RID: 10597
	[Nullable(2)]
	private Vector2D CurrentInputPosition;

	// Token: 0x04002966 RID: 10598
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<string, bool, FKey> OnInputActionCallback;

	// Token: 0x04002967 RID: 10599
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<string, float> OnInputAxisCallback;

	// Token: 0x04002968 RID: 10600
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<string, float, bool> OnInputAxisCallbackNew;

	// Token: 0x04002969 RID: 10601
	[Nullable(2)]
	private PlayerInputHandle PlayerInputHandle;

	// Token: 0x0400296A RID: 10602
	[Nullable(2)]
	private TsPureKeyHandle TsKeyHandle;

	// Token: 0x0400296B RID: 10603
	[Nullable(2)]
	private TsPureTouchHandle TsTouchHandle;

	// Token: 0x0400296C RID: 10604
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Controller/TsBasePlayerController.TsBasePlayerController_C";

	// Token: 0x0400296D RID: 10605
	private static IntPtr _ClassPtr;

	// Token: 0x0400296E RID: 10606
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400296F RID: 10607
	private static int __PropertyOffset_ActionHandleClass;

	// Token: 0x04002970 RID: 10608
	private static int __PropertyOffset_AxisHandleClass;

	// Token: 0x04002971 RID: 10609
	private static int __PropertyOffset_ActionHandleMap;

	// Token: 0x04002972 RID: 10610
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, TsActionHandle> _ActionHandleMap;

	// Token: 0x04002973 RID: 10611
	private static int __PropertyOffset_AxisHandleMap;

	// Token: 0x04002974 RID: 10612
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<string, TsAxisHandle> _AxisHandleMap;

	// Token: 0x0200729B RID: 29339
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OnTouchBegin_FunctionParams
	{
		// Token: 0x04027BF0 RID: 162800
		[FieldOffset(0)]
		public byte touchIndex;

		// Token: 0x04027BF1 RID: 162801
		[FieldOffset(4)]
		public FVector position;
	}

	// Token: 0x0200729C RID: 29340
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OnTouchEnd_FunctionParams
	{
		// Token: 0x04027BF2 RID: 162802
		[FieldOffset(0)]
		public byte touchIndex;

		// Token: 0x04027BF3 RID: 162803
		[FieldOffset(4)]
		public FVector position;
	}

	// Token: 0x0200729D RID: 29341
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OnTouchMove_FunctionParams
	{
		// Token: 0x04027BF4 RID: 162804
		[FieldOffset(0)]
		public byte touchIndex;

		// Token: 0x04027BF5 RID: 162805
		[FieldOffset(4)]
		public FVector position;
	}

	// Token: 0x0200729E RID: 29342
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OnPressAnyKey_FunctionParams
	{
		// Token: 0x04027BF6 RID: 162806
		[FieldOffset(0)]
		public byte key;
	}

	// Token: 0x0200729F RID: 29343
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __OnReleaseAnyKey_FunctionParams
	{
		// Token: 0x04027BF7 RID: 162807
		[FieldOffset(0)]
		public byte key;
	}

	// Token: 0x020072A0 RID: 29344
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RemoveActionHandle_FunctionParams
	{
		// Token: 0x04027BF8 RID: 162808
		[FieldOffset(0)]
		public FString actionName;
	}

	// Token: 0x020072A1 RID: 29345
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetActionHandle_FunctionParams
	{
		// Token: 0x04027BF9 RID: 162809
		[FieldOffset(0)]
		public FString actionName;

		// Token: 0x04027BFA RID: 162810
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020072A2 RID: 29346
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __RemoveAxisHandle_FunctionParams
	{
		// Token: 0x04027BFB RID: 162811
		[FieldOffset(0)]
		public FString axisName;
	}

	// Token: 0x020072A3 RID: 29347
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAxisHandle_FunctionParams
	{
		// Token: 0x04027BFC RID: 162812
		[FieldOffset(0)]
		public FString actionName;

		// Token: 0x04027BFD RID: 162813
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x020072A4 RID: 29348
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __IsInTouch_FunctionParams
	{
		// Token: 0x04027BFE RID: 162814
		[FieldOffset(0)]
		public float touchId;

		// Token: 0x04027BFF RID: 162815
		[FieldOffset(4)]
		public bool __Result;
	}

	// Token: 0x020072A5 RID: 29349
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetIsPrintKeyName_FunctionParams
	{
		// Token: 0x04027C00 RID: 162816
		[FieldOffset(0)]
		public bool bPrintKeyName;
	}
}
