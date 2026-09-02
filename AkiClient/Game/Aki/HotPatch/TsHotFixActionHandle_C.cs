using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DC0 RID: 15808
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C")]
	[UnrealStructLayout(224, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 224)]
	public class TsHotFixActionHandle_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026B4C RID: 158540 RVA: 0x009DF944 File Offset: 0x009DDB44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (TsHotFixActionHandle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C");
			}
			return TsHotFixActionHandle_C._ClassPtr;
		}

		// Token: 0x06026B4D RID: 158541 RVA: 0x009DF968 File Offset: 0x009DDB68
		public TsHotFixActionHandle_C() : this(BuiltinUtils.AllocNativeUObject(TsHotFixActionHandle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026B4E RID: 158542 RVA: 0x009DF990 File Offset: 0x009DDB90
		public TsHotFixActionHandle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHotFixActionHandle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058B7 RID: 22711
		// (get) Token: 0x06026B4F RID: 158543 RVA: 0x009DF9C3 File Offset: 0x009DDBC3
		// (set) Token: 0x06026B50 RID: 158544 RVA: 0x009DF9D7 File Offset: 0x009DDBD7
		public unsafe FName FuncName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170058B8 RID: 22712
		// (get) Token: 0x06026B51 RID: 158545 RVA: 0x009DF9EC File Offset: 0x009DDBEC
		// (set) Token: 0x06026B52 RID: 158546 RVA: 0x009DFA00 File Offset: 0x009DDC00
		[Nullable(2)]
		public unsafe UObject 目标
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + TsHotFixActionHandle_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsHotFixActionHandle_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170058B9 RID: 22713
		// (get) Token: 0x06026B53 RID: 158547 RVA: 0x009DFA15 File Offset: 0x009DDC15
		// (set) Token: 0x06026B54 RID: 158548 RVA: 0x009DFA29 File Offset: 0x009DDC29
		public unsafe string ActionName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsHotFixActionHandle_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsHotFixActionHandle_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x170058BA RID: 22714
		// (get) Token: 0x06026B55 RID: 158549 RVA: 0x009DFA3E File Offset: 0x009DDC3E
		// (set) Token: 0x06026B56 RID: 158550 RVA: 0x009DFA4E File Offset: 0x009DDC4E
		public unsafe bool bPress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170058BB RID: 22715
		// (get) Token: 0x06026B57 RID: 158551 RVA: 0x009DFA60 File Offset: 0x009DDC60
		// (set) Token: 0x06026B58 RID: 158552 RVA: 0x009DFA99 File Offset: 0x009DDC99
		public OnPressActionCallback OnPressActionCallback
		{
			get
			{
				base.FastCheckIsValid();
				OnPressActionCallback result;
				if ((result = this._OnPressActionCallback) == null)
				{
					result = (this._OnPressActionCallback = new OnPressActionCallback(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_4, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170058BC RID: 22716
		// (get) Token: 0x06026B59 RID: 158553 RVA: 0x009DFABA File Offset: 0x009DDCBA
		// (set) Token: 0x06026B5A RID: 158554 RVA: 0x009DFACE File Offset: 0x009DDCCE
		[Nullable(0)]
		public unsafe TEnumAsByte<ETouchIndex> TouchIndex
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170058BD RID: 22717
		// (get) Token: 0x06026B5B RID: 158555 RVA: 0x009DFAE3 File Offset: 0x009DDCE3
		// (set) Token: 0x06026B5C RID: 158556 RVA: 0x009DFAF7 File Offset: 0x009DDCF7
		public unsafe FVector TouchPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170058BE RID: 22718
		// (get) Token: 0x06026B5D RID: 158557 RVA: 0x009DFB0C File Offset: 0x009DDD0C
		// (set) Token: 0x06026B5E RID: 158558 RVA: 0x009DFB45 File Offset: 0x009DDD45
		public OnTouchActionCallback OnTouchActionCallback
		{
			get
			{
				base.FastCheckIsValid();
				OnTouchActionCallback result;
				if ((result = this._OnTouchActionCallback) == null)
				{
					result = (this._OnTouchActionCallback = new OnTouchActionCallback(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_7, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170058BF RID: 22719
		// (get) Token: 0x06026B5F RID: 158559 RVA: 0x009DFB68 File Offset: 0x009DDD68
		// (set) Token: 0x06026B60 RID: 158560 RVA: 0x009DFBA1 File Offset: 0x009DDDA1
		public OnTouchMovedActionCallback OnTouchMovedActionCallback
		{
			get
			{
				base.FastCheckIsValid();
				OnTouchMovedActionCallback result;
				if ((result = this._OnTouchMovedActionCallback) == null)
				{
					result = (this._OnTouchMovedActionCallback = new OnTouchMovedActionCallback(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_8, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170058C0 RID: 22720
		// (get) Token: 0x06026B61 RID: 158561 RVA: 0x009DFBC4 File Offset: 0x009DDDC4
		// (set) Token: 0x06026B62 RID: 158562 RVA: 0x009DFBFD File Offset: 0x009DDDFD
		public OnAxisCallback OnAxisCallback
		{
			get
			{
				base.FastCheckIsValid();
				OnAxisCallback result;
				if ((result = this._OnAxisCallback) == null)
				{
					result = (this._OnAxisCallback = new OnAxisCallback(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_9, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170058C1 RID: 22721
		// (get) Token: 0x06026B63 RID: 158563 RVA: 0x009DFC1E File Offset: 0x009DDE1E
		// (set) Token: 0x06026B64 RID: 158564 RVA: 0x009DFC32 File Offset: 0x009DDE32
		public unsafe string AxisName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsHotFixActionHandle_C.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsHotFixActionHandle_C.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x170058C2 RID: 22722
		// (get) Token: 0x06026B65 RID: 158565 RVA: 0x009DFC47 File Offset: 0x009DDE47
		// (set) Token: 0x06026B66 RID: 158566 RVA: 0x009DFC5B File Offset: 0x009DDE5B
		public unsafe FName Func_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170058C3 RID: 22723
		// (get) Token: 0x06026B67 RID: 158567 RVA: 0x009DFC70 File Offset: 0x009DDE70
		// (set) Token: 0x06026B68 RID: 158568 RVA: 0x009DFCA9 File Offset: 0x009DDEA9
		public OnAnyKeyPressCallback OnAnyKeyPressCallback
		{
			get
			{
				base.FastCheckIsValid();
				OnAnyKeyPressCallback result;
				if ((result = this._OnAnyKeyPressCallback) == null)
				{
					result = (this._OnAnyKeyPressCallback = new OnAnyKeyPressCallback(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)TsHotFixActionHandle_C.__PropertyOffset_12, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x06026B69 RID: 158569 RVA: 0x009DFCCC File Offset: 0x009DDECC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnAnyKeyPressAction(FKey key)
		{
			TsHotFixActionHandle_C.__OnAnyKeyPressAction_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnAnyKeyPressAction_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnAnyKeyPressAction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnAnyKeyPressAction_NativeFunctionPtr, (void*)ptr, 1);
			if (key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->key, key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnAnyKeyPressAction_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__OnAnyKeyPressAction_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B6A RID: 158570 RVA: 0x009DFD40 File Offset: 0x009DDF40
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ClearKeyBinding(APlayerController controller)
		{
			TsHotFixActionHandle_C.__ClearKeyBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__ClearKeyBinding_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(TsHotFixActionHandle_C.__ClearKeyBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__ClearKeyBinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__ClearKeyBinding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B6B RID: 158571 RVA: 0x009DFD98 File Offset: 0x009DDF98
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddAnyKeyPress(APlayerController controller, FInputChord chord)
		{
			TsHotFixActionHandle_C.__AddAnyKeyPress_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddAnyKeyPress_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddAnyKeyPress_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddAnyKeyPress_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			if (chord != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FInputChord.StaticStruct(), &ptr->chord, chord.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddAnyKeyPress_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__AddAnyKeyPress_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B6C RID: 158572 RVA: 0x009DFE20 File Offset: 0x009DE020
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ClearAxisBinding(APlayerController controller)
		{
			TsHotFixActionHandle_C.__ClearAxisBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__ClearAxisBinding_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(TsHotFixActionHandle_C.__ClearAxisBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__ClearAxisBinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__ClearAxisBinding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B6D RID: 158573 RVA: 0x009DFE78 File Offset: 0x009DE078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnAxisInput(float value)
		{
			TsHotFixActionHandle_C.__OnAxisInput_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnAxisInput_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnAxisInput_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnAxisInput_NativeFunctionPtr, (void*)ptr, 1);
			ptr->value = value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnAxisInput_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B6E RID: 158574 RVA: 0x009DFEC0 File Offset: 0x009DE0C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddAxisBinding(string axisName, [Nullable(2)] APlayerController controller)
		{
			TsHotFixActionHandle_C.__AddAxisBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddAxisBinding_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddAxisBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddAxisBinding_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->axisName), axisName);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddAxisBinding_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__AddAxisBinding_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B6F RID: 158575 RVA: 0x009DFF34 File Offset: 0x009DE134
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTouchMoveBinding(APlayerController controller)
		{
			TsHotFixActionHandle_C.__AddTouchMoveBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddTouchMoveBinding_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddTouchMoveBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddTouchMoveBinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddTouchMoveBinding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B70 RID: 158576 RVA: 0x009DFF8C File Offset: 0x009DE18C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnTouchMoveAction(ETouchIndex touchindex, FVector position)
		{
			TsHotFixActionHandle_C.__OnTouchMoveAction_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnTouchMoveAction_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnTouchMoveAction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnTouchMoveAction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->touchindex = touchindex;
			ptr->position = position;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnTouchMoveAction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B71 RID: 158577 RVA: 0x009DFFE0 File Offset: 0x009DE1E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ClearActionBinding(APlayerController controller)
		{
			TsHotFixActionHandle_C.__ClearActionBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__ClearActionBinding_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(TsHotFixActionHandle_C.__ClearActionBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__ClearActionBinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__ClearActionBinding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B72 RID: 158578 RVA: 0x009E0038 File Offset: 0x009DE238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnTouchReleaseAction(ETouchIndex touchIndex, FVector position)
		{
			TsHotFixActionHandle_C.__OnTouchReleaseAction_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnTouchReleaseAction_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnTouchReleaseAction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnTouchReleaseAction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->touchIndex = touchIndex;
			ptr->position = position;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnTouchReleaseAction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B73 RID: 158579 RVA: 0x009E008C File Offset: 0x009DE28C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnTouchPressAction(ETouchIndex touchIndex, FVector position)
		{
			TsHotFixActionHandle_C.__OnTouchPressAction_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnTouchPressAction_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnTouchPressAction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnTouchPressAction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->touchIndex = touchIndex;
			ptr->position = position;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnTouchPressAction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B74 RID: 158580 RVA: 0x009E00E0 File Offset: 0x009DE2E0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTouchReleaseBinding(APlayerController controller)
		{
			TsHotFixActionHandle_C.__AddTouchReleaseBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddTouchReleaseBinding_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddTouchReleaseBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddTouchReleaseBinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddTouchReleaseBinding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B75 RID: 158581 RVA: 0x009E0138 File Offset: 0x009DE338
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTouchPressBinding(APlayerController controller)
		{
			TsHotFixActionHandle_C.__AddTouchPressBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddTouchPressBinding_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddTouchPressBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddTouchPressBinding_NativeFunctionPtr, (void*)ptr, 1);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddTouchPressBinding_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026B76 RID: 158582 RVA: 0x009E0190 File Offset: 0x009DE390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddReleaseBinding(string actionName, [Nullable(2)] APlayerController controller)
		{
			TsHotFixActionHandle_C.__AddReleaseBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddReleaseBinding_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddReleaseBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddReleaseBinding_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->actionName), actionName);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddReleaseBinding_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__AddReleaseBinding_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B77 RID: 158583 RVA: 0x009E0204 File Offset: 0x009DE404
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddPressBinding(string actionName, [Nullable(2)] APlayerController controller)
		{
			TsHotFixActionHandle_C.__AddPressBinding_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__AddPressBinding_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(TsHotFixActionHandle_C.__AddPressBinding_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__AddPressBinding_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->actionName), actionName);
			ptr->controller = ((controller != null) ? controller.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__AddPressBinding_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__AddPressBinding_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B78 RID: 158584 RVA: 0x009E0278 File Offset: 0x009DE478
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnReleaseAction(FKey Key)
		{
			TsHotFixActionHandle_C.__OnReleaseAction_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnReleaseAction_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnReleaseAction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnReleaseAction_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnReleaseAction_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__OnReleaseAction_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B79 RID: 158585 RVA: 0x009E02EC File Offset: 0x009DE4EC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnPressAction(FKey key)
		{
			TsHotFixActionHandle_C.__OnPressAction_FunctionParams* ptr = stackalloc TsHotFixActionHandle_C.__OnPressAction_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(TsHotFixActionHandle_C.__OnPressAction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(TsHotFixActionHandle_C.__OnPressAction_NativeFunctionPtr, (void*)ptr, 1);
			if (key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->key, key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, TsHotFixActionHandle_C.__OnPressAction_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(TsHotFixActionHandle_C.__OnPressAction_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06026B7A RID: 158586 RVA: 0x009E035E File Offset: 0x009DE55E
		protected TsHotFixActionHandle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040142C8 RID: 82632
		public new const string __ObjectPath = "/Game/Aki/HotPatch/TsHotFixActionHandle.TsHotFixActionHandle_C";

		// Token: 0x040142C9 RID: 82633
		private static IntPtr _ClassPtr;

		// Token: 0x040142CA RID: 82634
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040142CB RID: 82635
		public static IntPtr __OnAnyKeyPressCallback__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040142CC RID: 82636
		public static IntPtr __OnAxisCallback__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040142CD RID: 82637
		public static IntPtr __OnTouchMovedActionCallback__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040142CE RID: 82638
		public static IntPtr __OnTouchActionCallback__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040142CF RID: 82639
		public static IntPtr __OnPressActionCallback__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040142D0 RID: 82640
		internal static int __PropertyOffset_0;

		// Token: 0x040142D1 RID: 82641
		internal static int __PropertyOffset_1;

		// Token: 0x040142D2 RID: 82642
		internal static int __PropertyOffset_2;

		// Token: 0x040142D3 RID: 82643
		internal static int __PropertyOffset_3;

		// Token: 0x040142D4 RID: 82644
		internal static int __PropertyOffset_4;

		// Token: 0x040142D5 RID: 82645
		[Nullable(2)]
		private OnPressActionCallback _OnPressActionCallback;

		// Token: 0x040142D6 RID: 82646
		internal static int __PropertyOffset_5;

		// Token: 0x040142D7 RID: 82647
		internal static int __PropertyOffset_6;

		// Token: 0x040142D8 RID: 82648
		internal static int __PropertyOffset_7;

		// Token: 0x040142D9 RID: 82649
		[Nullable(2)]
		private OnTouchActionCallback _OnTouchActionCallback;

		// Token: 0x040142DA RID: 82650
		internal static int __PropertyOffset_8;

		// Token: 0x040142DB RID: 82651
		[Nullable(2)]
		private OnTouchMovedActionCallback _OnTouchMovedActionCallback;

		// Token: 0x040142DC RID: 82652
		internal static int __PropertyOffset_9;

		// Token: 0x040142DD RID: 82653
		[Nullable(2)]
		private OnAxisCallback _OnAxisCallback;

		// Token: 0x040142DE RID: 82654
		internal static int __PropertyOffset_10;

		// Token: 0x040142DF RID: 82655
		internal static int __PropertyOffset_11;

		// Token: 0x040142E0 RID: 82656
		internal static int __PropertyOffset_12;

		// Token: 0x040142E1 RID: 82657
		[Nullable(2)]
		private OnAnyKeyPressCallback _OnAnyKeyPressCallback;

		// Token: 0x040142E2 RID: 82658
		private static IntPtr __OnAnyKeyPressAction_NativeFunctionPtr;

		// Token: 0x040142E3 RID: 82659
		private static IntPtr __ClearKeyBinding_NativeFunctionPtr;

		// Token: 0x040142E4 RID: 82660
		private static IntPtr __AddAnyKeyPress_NativeFunctionPtr;

		// Token: 0x040142E5 RID: 82661
		private static IntPtr __ClearAxisBinding_NativeFunctionPtr;

		// Token: 0x040142E6 RID: 82662
		private static IntPtr __OnAxisInput_NativeFunctionPtr;

		// Token: 0x040142E7 RID: 82663
		private static IntPtr __AddAxisBinding_NativeFunctionPtr;

		// Token: 0x040142E8 RID: 82664
		private static IntPtr __AddTouchMoveBinding_NativeFunctionPtr;

		// Token: 0x040142E9 RID: 82665
		private static IntPtr __OnTouchMoveAction_NativeFunctionPtr;

		// Token: 0x040142EA RID: 82666
		private static IntPtr __ClearActionBinding_NativeFunctionPtr;

		// Token: 0x040142EB RID: 82667
		private static IntPtr __OnTouchReleaseAction_NativeFunctionPtr;

		// Token: 0x040142EC RID: 82668
		private static IntPtr __OnTouchPressAction_NativeFunctionPtr;

		// Token: 0x040142ED RID: 82669
		private static IntPtr __AddTouchReleaseBinding_NativeFunctionPtr;

		// Token: 0x040142EE RID: 82670
		private static IntPtr __AddTouchPressBinding_NativeFunctionPtr;

		// Token: 0x040142EF RID: 82671
		private static IntPtr __AddReleaseBinding_NativeFunctionPtr;

		// Token: 0x040142F0 RID: 82672
		private static IntPtr __AddPressBinding_NativeFunctionPtr;

		// Token: 0x040142F1 RID: 82673
		private static IntPtr __OnReleaseAction_NativeFunctionPtr;

		// Token: 0x040142F2 RID: 82674
		private static IntPtr __OnPressAction_NativeFunctionPtr;

		// Token: 0x0200A0A1 RID: 41121
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnAnyKeyPressAction_FunctionParams
		{
			// Token: 0x04032D4A RID: 208202
			[FieldOffset(0)]
			public byte key;
		}

		// Token: 0x0200A0A2 RID: 41122
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ClearKeyBinding_FunctionParams
		{
			// Token: 0x04032D4B RID: 208203
			[FieldOffset(0)]
			public IntPtr controller;
		}

		// Token: 0x0200A0A3 RID: 41123
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __AddAnyKeyPress_FunctionParams
		{
			// Token: 0x04032D4C RID: 208204
			[FieldOffset(0)]
			public IntPtr controller;

			// Token: 0x04032D4D RID: 208205
			[FieldOffset(8)]
			public byte chord;
		}

		// Token: 0x0200A0A4 RID: 41124
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ClearAxisBinding_FunctionParams
		{
			// Token: 0x04032D4E RID: 208206
			[FieldOffset(0)]
			public IntPtr controller;
		}

		// Token: 0x0200A0A5 RID: 41125
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __OnAxisInput_FunctionParams
		{
			// Token: 0x04032D4F RID: 208207
			[FieldOffset(0)]
			public float value;
		}

		// Token: 0x0200A0A6 RID: 41126
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __AddAxisBinding_FunctionParams
		{
			// Token: 0x04032D50 RID: 208208
			[FieldOffset(0)]
			public FString axisName;

			// Token: 0x04032D51 RID: 208209
			[FieldOffset(16)]
			public IntPtr controller;
		}

		// Token: 0x0200A0A7 RID: 41127
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __AddTouchMoveBinding_FunctionParams
		{
			// Token: 0x04032D52 RID: 208210
			[FieldOffset(0)]
			public IntPtr controller;
		}

		// Token: 0x0200A0A8 RID: 41128
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchMoveAction_FunctionParams
		{
			// Token: 0x04032D53 RID: 208211
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> touchindex;

			// Token: 0x04032D54 RID: 208212
			[FieldOffset(4)]
			public FVector position;
		}

		// Token: 0x0200A0A9 RID: 41129
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ClearActionBinding_FunctionParams
		{
			// Token: 0x04032D55 RID: 208213
			[FieldOffset(0)]
			public IntPtr controller;
		}

		// Token: 0x0200A0AA RID: 41130
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchReleaseAction_FunctionParams
		{
			// Token: 0x04032D56 RID: 208214
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> touchIndex;

			// Token: 0x04032D57 RID: 208215
			[FieldOffset(4)]
			public FVector position;
		}

		// Token: 0x0200A0AB RID: 41131
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __OnTouchPressAction_FunctionParams
		{
			// Token: 0x04032D58 RID: 208216
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> touchIndex;

			// Token: 0x04032D59 RID: 208217
			[FieldOffset(4)]
			public FVector position;
		}

		// Token: 0x0200A0AC RID: 41132
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __AddTouchReleaseBinding_FunctionParams
		{
			// Token: 0x04032D5A RID: 208218
			[FieldOffset(0)]
			public IntPtr controller;
		}

		// Token: 0x0200A0AD RID: 41133
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __AddTouchPressBinding_FunctionParams
		{
			// Token: 0x04032D5B RID: 208219
			[FieldOffset(0)]
			public IntPtr controller;
		}

		// Token: 0x0200A0AE RID: 41134
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __AddReleaseBinding_FunctionParams
		{
			// Token: 0x04032D5C RID: 208220
			[FieldOffset(0)]
			public FString actionName;

			// Token: 0x04032D5D RID: 208221
			[FieldOffset(16)]
			public IntPtr controller;
		}

		// Token: 0x0200A0AF RID: 41135
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __AddPressBinding_FunctionParams
		{
			// Token: 0x04032D5E RID: 208222
			[FieldOffset(0)]
			public FString actionName;

			// Token: 0x04032D5F RID: 208223
			[FieldOffset(16)]
			public IntPtr controller;
		}

		// Token: 0x0200A0B0 RID: 41136
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnReleaseAction_FunctionParams
		{
			// Token: 0x04032D60 RID: 208224
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200A0B1 RID: 41137
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnPressAction_FunctionParams
		{
			// Token: 0x04032D61 RID: 208225
			[FieldOffset(0)]
			public byte key;
		}
	}
}
