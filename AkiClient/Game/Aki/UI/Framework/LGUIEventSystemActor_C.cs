using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Framework
{
	// Token: 0x020039B4 RID: 14772
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C")]
	[UnrealStructLayout(1144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1144)]
	public class LGUIEventSystemActor_C : ALGUIEventSystemActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DD45 RID: 122181 RVA: 0x008E316C File Offset: 0x008E136C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (LGUIEventSystemActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C");
			}
			return LGUIEventSystemActor_C._ClassPtr;
		}

		// Token: 0x0601DD46 RID: 122182 RVA: 0x008E3190 File Offset: 0x008E1390
		public LGUIEventSystemActor_C() : this(BuiltinUtils.AllocNativeUObject(LGUIEventSystemActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DD47 RID: 122183 RVA: 0x008E31B8 File Offset: 0x008E13B8
		[NullableContext(1)]
		public LGUIEventSystemActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LGUIEventSystemActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002778 RID: 10104
		// (get) Token: 0x0601DD48 RID: 122184 RVA: 0x008E31EC File Offset: 0x008E13EC
		// (set) Token: 0x0601DD49 RID: 122185 RVA: 0x008E3225 File Offset: 0x008E1425
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002779 RID: 10105
		// (get) Token: 0x0601DD4A RID: 122186 RVA: 0x008E3246 File Offset: 0x008E1446
		// (set) Token: 0x0601DD4B RID: 122187 RVA: 0x008E325A File Offset: 0x008E145A
		public unsafe ULGUI_TouchInputModule LGUI_TouchInputModule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULGUI_TouchInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700277A RID: 10106
		// (get) Token: 0x0601DD4C RID: 122188 RVA: 0x008E326F File Offset: 0x008E146F
		// (set) Token: 0x0601DD4D RID: 122189 RVA: 0x008E3283 File Offset: 0x008E1483
		public unsafe ULGUI_StandaloneInputModule LGUI_StandaloneInputModule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULGUI_StandaloneInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700277B RID: 10107
		// (get) Token: 0x0601DD4E RID: 122190 RVA: 0x008E3298 File Offset: 0x008E1498
		// (set) Token: 0x0601DD4F RID: 122191 RVA: 0x008E32AC File Offset: 0x008E14AC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700277C RID: 10108
		// (get) Token: 0x0601DD50 RID: 122192 RVA: 0x008E32C1 File Offset: 0x008E14C1
		// (set) Token: 0x0601DD51 RID: 122193 RVA: 0x008E32D5 File Offset: 0x008E14D5
		public unsafe ULGUI_PointerInputModule ValidInputModule
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULGUI_PointerInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LGUIEventSystemActor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700277D RID: 10109
		// (get) Token: 0x0601DD52 RID: 122194 RVA: 0x008E32EC File Offset: 0x008E14EC
		// (set) Token: 0x0601DD53 RID: 122195 RVA: 0x008E3325 File Offset: 0x008E1525
		[Nullable(1)]
		public OnMiddleMouseScroll OnMiddleMouseScroll
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnMiddleMouseScroll result;
				if ((result = this._OnMiddleMouseScroll) == null)
				{
					result = (this._OnMiddleMouseScroll = new OnMiddleMouseScroll(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_5, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700277E RID: 10110
		// (get) Token: 0x0601DD54 RID: 122196 RVA: 0x008E3348 File Offset: 0x008E1548
		// (set) Token: 0x0601DD55 RID: 122197 RVA: 0x008E3381 File Offset: 0x008E1581
		[Nullable(1)]
		public OnTouch OnTouch
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnTouch result;
				if ((result = this._OnTouch) == null)
				{
					result = (this._OnTouch = new OnTouch(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_6, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700277F RID: 10111
		// (get) Token: 0x0601DD56 RID: 122198 RVA: 0x008E33A4 File Offset: 0x008E15A4
		// (set) Token: 0x0601DD57 RID: 122199 RVA: 0x008E33DD File Offset: 0x008E15DD
		[Nullable(1)]
		public OnTouchMove OnTouchMove
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnTouchMove result;
				if ((result = this._OnTouchMove) == null)
				{
					result = (this._OnTouchMove = new OnTouchMove(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_7, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002780 RID: 10112
		// (get) Token: 0x0601DD58 RID: 122200 RVA: 0x008E3400 File Offset: 0x008E1600
		// (set) Token: 0x0601DD59 RID: 122201 RVA: 0x008E3439 File Offset: 0x008E1639
		[Nullable(1)]
		public OnClickKey OnClickKey
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnClickKey result;
				if ((result = this._OnClickKey) == null)
				{
					result = (this._OnClickKey = new OnClickKey(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)LGUIEventSystemActor_C.__PropertyOffset_8, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x0601DD5A RID: 122202 RVA: 0x008E345C File Offset: 0x008E165C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD5B RID: 122203 RVA: 0x008E34D0 File Offset: 0x008E16D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD5C RID: 122204 RVA: 0x008E3544 File Offset: 0x008E1744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Down_K2Node_InputKeyEvent_25(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_25_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_25_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_25_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_25_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_25_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_25_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD5D RID: 122205 RVA: 0x008E35B8 File Offset: 0x008E17B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Down_K2Node_InputKeyEvent_24(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_24_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_24_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_24_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_24_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_24_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Down_K2Node_InputKeyEvent_24_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD5E RID: 122206 RVA: 0x008E362C File Offset: 0x008E182C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Up_K2Node_InputKeyEvent_23(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_23_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_23_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_23_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_23_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_23_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_23_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD5F RID: 122207 RVA: 0x008E36A0 File Offset: 0x008E18A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Up_K2Node_InputKeyEvent_22(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_22_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_22_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_22_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_22_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_22_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Up_K2Node_InputKeyEvent_22_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD60 RID: 122208 RVA: 0x008E3714 File Offset: 0x008E1914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Right_K2Node_InputKeyEvent_21(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_21_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_21_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_21_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_21_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_21_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_21_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD61 RID: 122209 RVA: 0x008E3788 File Offset: 0x008E1988
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Right_K2Node_InputKeyEvent_20(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_20_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_20_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_20_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_20_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_20_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Right_K2Node_InputKeyEvent_20_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD62 RID: 122210 RVA: 0x008E37FC File Offset: 0x008E19FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Left_K2Node_InputKeyEvent_19(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_19_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_19_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_19_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_19_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_19_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_19_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD63 RID: 122211 RVA: 0x008E3870 File Offset: 0x008E1A70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Left_K2Node_InputKeyEvent_18(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_18_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_18_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_18_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_18_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_18_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Left_K2Node_InputKeyEvent_18_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD64 RID: 122212 RVA: 0x008E38E4 File Offset: 0x008E1AE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Enter_K2Node_InputKeyEvent_17(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_17_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_17_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_17_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_17_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_17_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_17_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD65 RID: 122213 RVA: 0x008E3958 File Offset: 0x008E1B58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Enter_K2Node_InputKeyEvent_16(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_16_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_16_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_16_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_16_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_16_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Enter_K2Node_InputKeyEvent_16_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD66 RID: 122214 RVA: 0x008E39CC File Offset: 0x008E1BCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpTchEvt_Moved(ETouchIndex FingerIndex, FVector Location)
		{
			LGUIEventSystemActor_C.__InpTchEvt_Moved_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpTchEvt_Moved_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpTchEvt_Moved_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpTchEvt_Moved_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FingerIndex = FingerIndex;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpTchEvt_Moved_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DD67 RID: 122215 RVA: 0x008E3A20 File Offset: 0x008E1C20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpTchEvt_Released(ETouchIndex FingerIndex, FVector Location)
		{
			LGUIEventSystemActor_C.__InpTchEvt_Released_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpTchEvt_Released_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpTchEvt_Released_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpTchEvt_Released_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FingerIndex = FingerIndex;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpTchEvt_Released_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DD68 RID: 122216 RVA: 0x008E3A74 File Offset: 0x008E1C74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpTchEvt_Pressed(ETouchIndex FingerIndex, FVector Location)
		{
			LGUIEventSystemActor_C.__InpTchEvt_Pressed_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpTchEvt_Pressed_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpTchEvt_Pressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpTchEvt_Pressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->FingerIndex = FingerIndex;
			ptr->Location = Location;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpTchEvt_Pressed_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DD69 RID: 122217 RVA: 0x008E3AC8 File Offset: 0x008E1CC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD6A RID: 122218 RVA: 0x008E3B3C File Offset: 0x008E1D3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD6B RID: 122219 RVA: 0x008E3BB0 File Offset: 0x008E1DB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD6C RID: 122220 RVA: 0x008E3C24 File Offset: 0x008E1E24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD6D RID: 122221 RVA: 0x008E3C98 File Offset: 0x008E1E98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD6E RID: 122222 RVA: 0x008E3D0C File Offset: 0x008E1F0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD6F RID: 122223 RVA: 0x008E3D80 File Offset: 0x008E1F80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD70 RID: 122224 RVA: 0x008E3DF4 File Offset: 0x008E1FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD71 RID: 122225 RVA: 0x008E3E68 File Offset: 0x008E2068
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD72 RID: 122226 RVA: 0x008E3EDC File Offset: 0x008E20DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD73 RID: 122227 RVA: 0x008E3F50 File Offset: 0x008E2150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD74 RID: 122228 RVA: 0x008E3FC4 File Offset: 0x008E21C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD75 RID: 122229 RVA: 0x008E4038 File Offset: 0x008E2238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD76 RID: 122230 RVA: 0x008E40AC File Offset: 0x008E22AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD77 RID: 122231 RVA: 0x008E4120 File Offset: 0x008E2320
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_AnyKey_K2Node_InputKeyEvent_1(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_1_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_1_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD78 RID: 122232 RVA: 0x008E4194 File Offset: 0x008E2394
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_AnyKey_K2Node_InputKeyEvent_0(FKey Key)
		{
			LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_0_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_0_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(LGUIEventSystemActor_C.__InpActEvt_AnyKey_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DD79 RID: 122233 RVA: 0x008E4206 File Offset: 0x008E2406
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601DD7A RID: 122234 RVA: 0x008E421A File Offset: 0x008E241A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, LGUIEventSystemActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DD7B RID: 122235 RVA: 0x008E4230 File Offset: 0x008E2430
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0(float AxisValue)
		{
			LGUIEventSystemActor_C.__InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(LGUIEventSystemActor_C.__InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AxisValue = AxisValue;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, LGUIEventSystemActor_C.__InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DD7C RID: 122236 RVA: 0x008E4278 File Offset: 0x008E2478
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_LGUIEventSystemActor(int EntryPoint)
		{
			LGUIEventSystemActor_C.__ExecuteUbergraph_LGUIEventSystemActor_FunctionParams* ptr = stackalloc LGUIEventSystemActor_C.__ExecuteUbergraph_LGUIEventSystemActor_FunctionParams[(UIntPtr)1471] + 15L / (long)sizeof(LGUIEventSystemActor_C.__ExecuteUbergraph_LGUIEventSystemActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(LGUIEventSystemActor_C.__ExecuteUbergraph_LGUIEventSystemActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, LGUIEventSystemActor_C.__ExecuteUbergraph_LGUIEventSystemActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DD7D RID: 122237 RVA: 0x008E42C2 File Offset: 0x008E24C2
		protected LGUIEventSystemActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E9A0 RID: 59808
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/UI/Framework/LGUIEventSystemActor.LGUIEventSystemActor_C";

		// Token: 0x0400E9A1 RID: 59809
		private static IntPtr _ClassPtr;

		// Token: 0x0400E9A2 RID: 59810
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E9A3 RID: 59811
		public static IntPtr __OnClickKey__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E9A4 RID: 59812
		public static IntPtr __OnTouchMove__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E9A5 RID: 59813
		public static IntPtr __OnTouch__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E9A6 RID: 59814
		public static IntPtr __OnMiddleMouseScroll__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400E9A7 RID: 59815
		internal static int __PropertyOffset_0;

		// Token: 0x0400E9A8 RID: 59816
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400E9A9 RID: 59817
		internal static int __PropertyOffset_1;

		// Token: 0x0400E9AA RID: 59818
		internal static int __PropertyOffset_2;

		// Token: 0x0400E9AB RID: 59819
		internal static int __PropertyOffset_3;

		// Token: 0x0400E9AC RID: 59820
		internal static int __PropertyOffset_4;

		// Token: 0x0400E9AD RID: 59821
		internal static int __PropertyOffset_5;

		// Token: 0x0400E9AE RID: 59822
		private OnMiddleMouseScroll _OnMiddleMouseScroll;

		// Token: 0x0400E9AF RID: 59823
		internal static int __PropertyOffset_6;

		// Token: 0x0400E9B0 RID: 59824
		private OnTouch _OnTouch;

		// Token: 0x0400E9B1 RID: 59825
		internal static int __PropertyOffset_7;

		// Token: 0x0400E9B2 RID: 59826
		private OnTouchMove _OnTouchMove;

		// Token: 0x0400E9B3 RID: 59827
		internal static int __PropertyOffset_8;

		// Token: 0x0400E9B4 RID: 59828
		private OnClickKey _OnClickKey;

		// Token: 0x0400E9B5 RID: 59829
		private static IntPtr __InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_NativeFunctionPtr;

		// Token: 0x0400E9B6 RID: 59830
		private static IntPtr __InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_NativeFunctionPtr;

		// Token: 0x0400E9B7 RID: 59831
		private static IntPtr __InpActEvt_Down_K2Node_InputKeyEvent_25_NativeFunctionPtr;

		// Token: 0x0400E9B8 RID: 59832
		private static IntPtr __InpActEvt_Down_K2Node_InputKeyEvent_24_NativeFunctionPtr;

		// Token: 0x0400E9B9 RID: 59833
		private static IntPtr __InpActEvt_Up_K2Node_InputKeyEvent_23_NativeFunctionPtr;

		// Token: 0x0400E9BA RID: 59834
		private static IntPtr __InpActEvt_Up_K2Node_InputKeyEvent_22_NativeFunctionPtr;

		// Token: 0x0400E9BB RID: 59835
		private static IntPtr __InpActEvt_Right_K2Node_InputKeyEvent_21_NativeFunctionPtr;

		// Token: 0x0400E9BC RID: 59836
		private static IntPtr __InpActEvt_Right_K2Node_InputKeyEvent_20_NativeFunctionPtr;

		// Token: 0x0400E9BD RID: 59837
		private static IntPtr __InpActEvt_Left_K2Node_InputKeyEvent_19_NativeFunctionPtr;

		// Token: 0x0400E9BE RID: 59838
		private static IntPtr __InpActEvt_Left_K2Node_InputKeyEvent_18_NativeFunctionPtr;

		// Token: 0x0400E9BF RID: 59839
		private static IntPtr __InpActEvt_Enter_K2Node_InputKeyEvent_17_NativeFunctionPtr;

		// Token: 0x0400E9C0 RID: 59840
		private static IntPtr __InpActEvt_Enter_K2Node_InputKeyEvent_16_NativeFunctionPtr;

		// Token: 0x0400E9C1 RID: 59841
		private static IntPtr __InpTchEvt_Moved_NativeFunctionPtr;

		// Token: 0x0400E9C2 RID: 59842
		private static IntPtr __InpTchEvt_Released_NativeFunctionPtr;

		// Token: 0x0400E9C3 RID: 59843
		private static IntPtr __InpTchEvt_Pressed_NativeFunctionPtr;

		// Token: 0x0400E9C4 RID: 59844
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_NativeFunctionPtr;

		// Token: 0x0400E9C5 RID: 59845
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_NativeFunctionPtr;

		// Token: 0x0400E9C6 RID: 59846
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_NativeFunctionPtr;

		// Token: 0x0400E9C7 RID: 59847
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_NativeFunctionPtr;

		// Token: 0x0400E9C8 RID: 59848
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_NativeFunctionPtr;

		// Token: 0x0400E9C9 RID: 59849
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_NativeFunctionPtr;

		// Token: 0x0400E9CA RID: 59850
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_NativeFunctionPtr;

		// Token: 0x0400E9CB RID: 59851
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_NativeFunctionPtr;

		// Token: 0x0400E9CC RID: 59852
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_NativeFunctionPtr;

		// Token: 0x0400E9CD RID: 59853
		private static IntPtr __InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_NativeFunctionPtr;

		// Token: 0x0400E9CE RID: 59854
		private static IntPtr __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr;

		// Token: 0x0400E9CF RID: 59855
		private static IntPtr __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr;

		// Token: 0x0400E9D0 RID: 59856
		private static IntPtr __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr;

		// Token: 0x0400E9D1 RID: 59857
		private static IntPtr __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr;

		// Token: 0x0400E9D2 RID: 59858
		private static IntPtr __InpActEvt_AnyKey_K2Node_InputKeyEvent_1_NativeFunctionPtr;

		// Token: 0x0400E9D3 RID: 59859
		private static IntPtr __InpActEvt_AnyKey_K2Node_InputKeyEvent_0_NativeFunctionPtr;

		// Token: 0x0400E9D4 RID: 59860
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400E9D5 RID: 59861
		private static IntPtr __InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_NativeFunctionPtr;

		// Token: 0x0400E9D6 RID: 59862
		private static IntPtr __ExecuteUbergraph_LGUIEventSystemActor_NativeFunctionPtr;

		// Token: 0x020096F8 RID: 38648
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_27_FunctionParams
		{
			// Token: 0x04031C34 RID: 203828
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096F9 RID: 38649
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_FaceButton_Bottom_K2Node_InputKeyEvent_26_FunctionParams
		{
			// Token: 0x04031C35 RID: 203829
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096FA RID: 38650
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Down_K2Node_InputKeyEvent_25_FunctionParams
		{
			// Token: 0x04031C36 RID: 203830
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096FB RID: 38651
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Down_K2Node_InputKeyEvent_24_FunctionParams
		{
			// Token: 0x04031C37 RID: 203831
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096FC RID: 38652
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Up_K2Node_InputKeyEvent_23_FunctionParams
		{
			// Token: 0x04031C38 RID: 203832
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096FD RID: 38653
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Up_K2Node_InputKeyEvent_22_FunctionParams
		{
			// Token: 0x04031C39 RID: 203833
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096FE RID: 38654
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Right_K2Node_InputKeyEvent_21_FunctionParams
		{
			// Token: 0x04031C3A RID: 203834
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x020096FF RID: 38655
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Right_K2Node_InputKeyEvent_20_FunctionParams
		{
			// Token: 0x04031C3B RID: 203835
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009700 RID: 38656
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Left_K2Node_InputKeyEvent_19_FunctionParams
		{
			// Token: 0x04031C3C RID: 203836
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009701 RID: 38657
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Left_K2Node_InputKeyEvent_18_FunctionParams
		{
			// Token: 0x04031C3D RID: 203837
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009702 RID: 38658
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Enter_K2Node_InputKeyEvent_17_FunctionParams
		{
			// Token: 0x04031C3E RID: 203838
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009703 RID: 38659
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Enter_K2Node_InputKeyEvent_16_FunctionParams
		{
			// Token: 0x04031C3F RID: 203839
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009704 RID: 38660
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __InpTchEvt_Moved_FunctionParams
		{
			// Token: 0x04031C40 RID: 203840
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> FingerIndex;

			// Token: 0x04031C41 RID: 203841
			[FieldOffset(4)]
			public FVector Location;
		}

		// Token: 0x02009705 RID: 38661
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __InpTchEvt_Released_FunctionParams
		{
			// Token: 0x04031C42 RID: 203842
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> FingerIndex;

			// Token: 0x04031C43 RID: 203843
			[FieldOffset(4)]
			public FVector Location;
		}

		// Token: 0x02009706 RID: 38662
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __InpTchEvt_Pressed_FunctionParams
		{
			// Token: 0x04031C44 RID: 203844
			[FieldOffset(0)]
			public TEnumAsByte<ETouchIndex> FingerIndex;

			// Token: 0x04031C45 RID: 203845
			[FieldOffset(4)]
			public FVector Location;
		}

		// Token: 0x02009707 RID: 38663
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_15_FunctionParams
		{
			// Token: 0x04031C46 RID: 203846
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009708 RID: 38664
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_14_FunctionParams
		{
			// Token: 0x04031C47 RID: 203847
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009709 RID: 38665
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_13_FunctionParams
		{
			// Token: 0x04031C48 RID: 203848
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200970A RID: 38666
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Left_K2Node_InputKeyEvent_12_FunctionParams
		{
			// Token: 0x04031C49 RID: 203849
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200970B RID: 38667
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_11_FunctionParams
		{
			// Token: 0x04031C4A RID: 203850
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200970C RID: 38668
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Right_K2Node_InputKeyEvent_10_FunctionParams
		{
			// Token: 0x04031C4B RID: 203851
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200970D RID: 38669
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_9_FunctionParams
		{
			// Token: 0x04031C4C RID: 203852
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200970E RID: 38670
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Up_K2Node_InputKeyEvent_8_FunctionParams
		{
			// Token: 0x04031C4D RID: 203853
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x0200970F RID: 38671
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_7_FunctionParams
		{
			// Token: 0x04031C4E RID: 203854
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009710 RID: 38672
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Gamepad_LeftStick_Down_K2Node_InputKeyEvent_6_FunctionParams
		{
			// Token: 0x04031C4F RID: 203855
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009711 RID: 38673
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams
		{
			// Token: 0x04031C50 RID: 203856
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009712 RID: 38674
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams
		{
			// Token: 0x04031C51 RID: 203857
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009713 RID: 38675
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams
		{
			// Token: 0x04031C52 RID: 203858
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009714 RID: 38676
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams
		{
			// Token: 0x04031C53 RID: 203859
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009715 RID: 38677
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_AnyKey_K2Node_InputKeyEvent_1_FunctionParams
		{
			// Token: 0x04031C54 RID: 203860
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009716 RID: 38678
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_AnyKey_K2Node_InputKeyEvent_0_FunctionParams
		{
			// Token: 0x04031C55 RID: 203861
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009717 RID: 38679
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InpAxisKeyEvt_MouseWheelAxis_K2Node_InputAxisKeyEvent_0_FunctionParams
		{
			// Token: 0x04031C56 RID: 203862
			[FieldOffset(0)]
			public float AxisValue;
		}

		// Token: 0x02009718 RID: 38680
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1456)]
		protected ref struct __ExecuteUbergraph_LGUIEventSystemActor_FunctionParams
		{
			// Token: 0x04031C57 RID: 203863
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
