using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF9 RID: 15609
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_Utilities.NinjaLive_Utilities_C")]
	[UnrealStructLayout(1152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1148)]
	public class NinjaLive_Utilities_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025920 RID: 153888 RVA: 0x009BDA33 File Offset: 0x009BBC33
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLive_Utilities_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_Utilities.NinjaLive_Utilities_C");
			}
			return NinjaLive_Utilities_C._ClassPtr;
		}

		// Token: 0x06025921 RID: 153889 RVA: 0x009BDA58 File Offset: 0x009BBC58
		public NinjaLive_Utilities_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLive_Utilities_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025922 RID: 153890 RVA: 0x009BDA80 File Offset: 0x009BBC80
		[NullableContext(1)]
		public NinjaLive_Utilities_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLive_Utilities_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170052A3 RID: 21155
		// (get) Token: 0x06025923 RID: 153891 RVA: 0x009BDAB4 File Offset: 0x009BBCB4
		// (set) Token: 0x06025924 RID: 153892 RVA: 0x009BDAED File Offset: 0x009BBCED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170052A4 RID: 21156
		// (get) Token: 0x06025925 RID: 153893 RVA: 0x009BDB0E File Offset: 0x009BBD0E
		// (set) Token: 0x06025926 RID: 153894 RVA: 0x009BDB22 File Offset: 0x009BBD22
		public unsafe UMaterialBillboardComponent EditorIcon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_Utilities_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_Utilities_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170052A5 RID: 21157
		// (get) Token: 0x06025927 RID: 153895 RVA: 0x009BDB37 File Offset: 0x009BBD37
		// (set) Token: 0x06025928 RID: 153896 RVA: 0x009BDB4B File Offset: 0x009BBD4B
		public unsafe USceneComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_Utilities_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_Utilities_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170052A6 RID: 21158
		// (get) Token: 0x06025929 RID: 153897 RVA: 0x009BDB60 File Offset: 0x009BBD60
		// (set) Token: 0x0602592A RID: 153898 RVA: 0x009BDB70 File Offset: 0x009BBD70
		public unsafe bool DisableBlueprint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052A7 RID: 21159
		// (get) Token: 0x0602592B RID: 153899 RVA: 0x009BDB81 File Offset: 0x009BBD81
		// (set) Token: 0x0602592C RID: 153900 RVA: 0x009BDB91 File Offset: 0x009BBD91
		public unsafe bool OverrideEditor120_FPS_Limit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052A8 RID: 21160
		// (get) Token: 0x0602592D RID: 153901 RVA: 0x009BDBA2 File Offset: 0x009BBDA2
		// (set) Token: 0x0602592E RID: 153902 RVA: 0x009BDBB2 File Offset: 0x009BBDB2
		public unsafe int MaxEditorFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170052A9 RID: 21161
		// (get) Token: 0x0602592F RID: 153903 RVA: 0x009BDBC3 File Offset: 0x009BBDC3
		// (set) Token: 0x06025930 RID: 153904 RVA: 0x009BDBD3 File Offset: 0x009BBDD3
		public unsafe bool CameraAndCursorSmoothing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052AA RID: 21162
		// (get) Token: 0x06025931 RID: 153905 RVA: 0x009BDBE4 File Offset: 0x009BBDE4
		// (set) Token: 0x06025932 RID: 153906 RVA: 0x009BDBF4 File Offset: 0x009BBDF4
		public unsafe int MaxCameraMoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170052AB RID: 21163
		// (get) Token: 0x06025933 RID: 153907 RVA: 0x009BDC05 File Offset: 0x009BBE05
		// (set) Token: 0x06025934 RID: 153908 RVA: 0x009BDC15 File Offset: 0x009BBE15
		public unsafe bool PossessNearestPawn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052AC RID: 21164
		// (get) Token: 0x06025935 RID: 153909 RVA: 0x009BDC28 File Offset: 0x009BBE28
		// (set) Token: 0x06025936 RID: 153910 RVA: 0x009BDC61 File Offset: 0x009BBE61
		[Nullable(1)]
		public TArray<int> TempArray1
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._TempArray1) == null)
				{
					result = (this._TempArray1 = new TArray<int>(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TempArray1.CopyAssign(value);
			}
		}

		// Token: 0x170052AD RID: 21165
		// (get) Token: 0x06025937 RID: 153911 RVA: 0x009BDC70 File Offset: 0x009BBE70
		// (set) Token: 0x06025938 RID: 153912 RVA: 0x009BDCA9 File Offset: 0x009BBEA9
		[Nullable(1)]
		public TArray<APawn> TempArray2
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<APawn> result;
				if ((result = this._TempArray2) == null)
				{
					result = (this._TempArray2 = new TArray<APawn>(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TempArray2.CopyAssign(value);
			}
		}

		// Token: 0x170052AE RID: 21166
		// (get) Token: 0x06025939 RID: 153913 RVA: 0x009BDCB7 File Offset: 0x009BBEB7
		// (set) Token: 0x0602593A RID: 153914 RVA: 0x009BDCC7 File Offset: 0x009BBEC7
		public unsafe bool ShowMouseCursor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170052AF RID: 21167
		// (get) Token: 0x0602593B RID: 153915 RVA: 0x009BDCD8 File Offset: 0x009BBED8
		// (set) Token: 0x0602593C RID: 153916 RVA: 0x009BDCEC File Offset: 0x009BBEEC
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<UUserWidget> WidgetToRotateDirectionalLight
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_12);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170052B0 RID: 21168
		// (get) Token: 0x0602593D RID: 153917 RVA: 0x009BDD01 File Offset: 0x009BBF01
		// (set) Token: 0x0602593E RID: 153918 RVA: 0x009BDD15 File Offset: 0x009BBF15
		public unsafe ADirectionalLight WidgetTargetDirectionalLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_Utilities_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLive_Utilities_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170052B1 RID: 21169
		// (get) Token: 0x0602593F RID: 153919 RVA: 0x009BDD2A File Offset: 0x009BBF2A
		// (set) Token: 0x06025940 RID: 153920 RVA: 0x009BDD3A File Offset: 0x009BBF3A
		public unsafe int AntialiasingQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170052B2 RID: 21170
		// (get) Token: 0x06025941 RID: 153921 RVA: 0x009BDD4B File Offset: 0x009BBF4B
		// (set) Token: 0x06025942 RID: 153922 RVA: 0x009BDD5B File Offset: 0x009BBF5B
		public unsafe int DepthOfFieldQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170052B3 RID: 21171
		// (get) Token: 0x06025943 RID: 153923 RVA: 0x009BDD6C File Offset: 0x009BBF6C
		// (set) Token: 0x06025944 RID: 153924 RVA: 0x009BDD7C File Offset: 0x009BBF7C
		public unsafe int MotionBlurQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLive_Utilities_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x06025945 RID: 153925 RVA: 0x009BDD8D File Offset: 0x009BBF8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06025946 RID: 153926 RVA: 0x009BDDA1 File Offset: 0x009BBFA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_Utilities_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025947 RID: 153927 RVA: 0x009BDDB8 File Offset: 0x009BBFB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025948 RID: 153928 RVA: 0x009BDE2C File Offset: 0x009BC02C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025949 RID: 153929 RVA: 0x009BDEA0 File Offset: 0x009BC0A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602594A RID: 153930 RVA: 0x009BDF14 File Offset: 0x009BC114
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602594B RID: 153931 RVA: 0x009BDF88 File Offset: 0x009BC188
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602594C RID: 153932 RVA: 0x009BDFFC File Offset: 0x009BC1FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602594D RID: 153933 RVA: 0x009BE070 File Offset: 0x009BC270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Add_K2Node_InputKeyEvent_1(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_Add_K2Node_InputKeyEvent_1_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_Add_K2Node_InputKeyEvent_1_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_Add_K2Node_InputKeyEvent_1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_Add_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_Add_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_Add_K2Node_InputKeyEvent_1_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602594E RID: 153934 RVA: 0x009BE0E4 File Offset: 0x009BC2E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InpActEvt_Subtract_K2Node_InputKeyEvent_0(FKey Key)
		{
			NinjaLive_Utilities_C.__InpActEvt_Subtract_K2Node_InputKeyEvent_0_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__InpActEvt_Subtract_K2Node_InputKeyEvent_0_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLive_Utilities_C.__InpActEvt_Subtract_K2Node_InputKeyEvent_0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__InpActEvt_Subtract_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
			if (Key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->Key, Key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__InpActEvt_Subtract_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLive_Utilities_C.__InpActEvt_Subtract_K2Node_InputKeyEvent_0_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602594F RID: 153935 RVA: 0x009BE156 File Offset: 0x009BC356
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLive_Utilities_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025950 RID: 153936 RVA: 0x009BE16A File Offset: 0x009BC36A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_Utilities_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025951 RID: 153937 RVA: 0x009BE180 File Offset: 0x009BC380
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLive_Utilities(int EntryPoint)
		{
			NinjaLive_Utilities_C.__ExecuteUbergraph_NinjaLive_Utilities_FunctionParams* ptr = stackalloc NinjaLive_Utilities_C.__ExecuteUbergraph_NinjaLive_Utilities_FunctionParams[(UIntPtr)1055] + 15L / (long)sizeof(NinjaLive_Utilities_C.__ExecuteUbergraph_NinjaLive_Utilities_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLive_Utilities_C.__ExecuteUbergraph_NinjaLive_Utilities_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLive_Utilities_C.__ExecuteUbergraph_NinjaLive_Utilities_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025952 RID: 153938 RVA: 0x009BE1CA File Offset: 0x009BC3CA
		protected NinjaLive_Utilities_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401361B RID: 79387
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLive_Utilities.NinjaLive_Utilities_C";

		// Token: 0x0401361C RID: 79388
		private static IntPtr _ClassPtr;

		// Token: 0x0401361D RID: 79389
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401361E RID: 79390
		internal static int __PropertyOffset_0;

		// Token: 0x0401361F RID: 79391
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013620 RID: 79392
		internal static int __PropertyOffset_1;

		// Token: 0x04013621 RID: 79393
		internal static int __PropertyOffset_2;

		// Token: 0x04013622 RID: 79394
		internal static int __PropertyOffset_3;

		// Token: 0x04013623 RID: 79395
		internal static int __PropertyOffset_4;

		// Token: 0x04013624 RID: 79396
		internal static int __PropertyOffset_5;

		// Token: 0x04013625 RID: 79397
		internal static int __PropertyOffset_6;

		// Token: 0x04013626 RID: 79398
		internal static int __PropertyOffset_7;

		// Token: 0x04013627 RID: 79399
		internal static int __PropertyOffset_8;

		// Token: 0x04013628 RID: 79400
		internal static int __PropertyOffset_9;

		// Token: 0x04013629 RID: 79401
		private TArray<int> _TempArray1;

		// Token: 0x0401362A RID: 79402
		internal static int __PropertyOffset_10;

		// Token: 0x0401362B RID: 79403
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<APawn> _TempArray2;

		// Token: 0x0401362C RID: 79404
		internal static int __PropertyOffset_11;

		// Token: 0x0401362D RID: 79405
		internal static int __PropertyOffset_12;

		// Token: 0x0401362E RID: 79406
		internal static int __PropertyOffset_13;

		// Token: 0x0401362F RID: 79407
		internal static int __PropertyOffset_14;

		// Token: 0x04013630 RID: 79408
		internal static int __PropertyOffset_15;

		// Token: 0x04013631 RID: 79409
		internal static int __PropertyOffset_16;

		// Token: 0x04013632 RID: 79410
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013633 RID: 79411
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_NativeFunctionPtr;

		// Token: 0x04013634 RID: 79412
		private static IntPtr __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_NativeFunctionPtr;

		// Token: 0x04013635 RID: 79413
		private static IntPtr __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_NativeFunctionPtr;

		// Token: 0x04013636 RID: 79414
		private static IntPtr __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_NativeFunctionPtr;

		// Token: 0x04013637 RID: 79415
		private static IntPtr __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_NativeFunctionPtr;

		// Token: 0x04013638 RID: 79416
		private static IntPtr __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_NativeFunctionPtr;

		// Token: 0x04013639 RID: 79417
		private static IntPtr __InpActEvt_Add_K2Node_InputKeyEvent_1_NativeFunctionPtr;

		// Token: 0x0401363A RID: 79418
		private static IntPtr __InpActEvt_Subtract_K2Node_InputKeyEvent_0_NativeFunctionPtr;

		// Token: 0x0401363B RID: 79419
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401363C RID: 79420
		private static IntPtr __ExecuteUbergraph_NinjaLive_Utilities_NativeFunctionPtr;

		// Token: 0x02009F2A RID: 40746
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_7_FunctionParams
		{
			// Token: 0x04032A5B RID: 207451
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F2B RID: 40747
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_LeftMouseButton_K2Node_InputKeyEvent_6_FunctionParams
		{
			// Token: 0x04032A5C RID: 207452
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F2C RID: 40748
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_5_FunctionParams
		{
			// Token: 0x04032A5D RID: 207453
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F2D RID: 40749
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_RightMouseButton_K2Node_InputKeyEvent_4_FunctionParams
		{
			// Token: 0x04032A5E RID: 207454
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F2E RID: 40750
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_3_FunctionParams
		{
			// Token: 0x04032A5F RID: 207455
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F2F RID: 40751
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_MiddleMouseButton_K2Node_InputKeyEvent_2_FunctionParams
		{
			// Token: 0x04032A60 RID: 207456
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F30 RID: 40752
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Add_K2Node_InputKeyEvent_1_FunctionParams
		{
			// Token: 0x04032A61 RID: 207457
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F31 RID: 40753
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __InpActEvt_Subtract_K2Node_InputKeyEvent_0_FunctionParams
		{
			// Token: 0x04032A62 RID: 207458
			[FieldOffset(0)]
			public byte Key;
		}

		// Token: 0x02009F32 RID: 40754
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1040)]
		protected ref struct __ExecuteUbergraph_NinjaLive_Utilities_FunctionParams
		{
			// Token: 0x04032A63 RID: 207459
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
