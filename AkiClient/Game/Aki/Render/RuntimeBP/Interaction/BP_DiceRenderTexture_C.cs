using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C7C RID: 15484
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceRenderTexture.BP_DiceRenderTexture_C")]
	[UnrealStructLayout(1200, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1188)]
	public class BP_DiceRenderTexture_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023FCB RID: 147403 RVA: 0x00991940 File Offset: 0x0098FB40
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DiceRenderTexture_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceRenderTexture.BP_DiceRenderTexture_C");
			}
			return BP_DiceRenderTexture_C._ClassPtr;
		}

		// Token: 0x06023FCC RID: 147404 RVA: 0x00991964 File Offset: 0x0098FB64
		public BP_DiceRenderTexture_C() : this(BuiltinUtils.AllocNativeUObject(BP_DiceRenderTexture_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023FCD RID: 147405 RVA: 0x0099198C File Offset: 0x0098FB8C
		[NullableContext(1)]
		public BP_DiceRenderTexture_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DiceRenderTexture_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004965 RID: 18789
		// (get) Token: 0x06023FCE RID: 147406 RVA: 0x009919C0 File Offset: 0x0098FBC0
		// (set) Token: 0x06023FCF RID: 147407 RVA: 0x009919F9 File Offset: 0x0098FBF9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004966 RID: 18790
		// (get) Token: 0x06023FD0 RID: 147408 RVA: 0x00991A1A File Offset: 0x0098FC1A
		// (set) Token: 0x06023FD1 RID: 147409 RVA: 0x00991A2E File Offset: 0x0098FC2E
		public unsafe UStaticMeshComponent SM_Act_Pro_101AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004967 RID: 18791
		// (get) Token: 0x06023FD2 RID: 147410 RVA: 0x00991A43 File Offset: 0x0098FC43
		// (set) Token: 0x06023FD3 RID: 147411 RVA: 0x00991A57 File Offset: 0x0098FC57
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004968 RID: 18792
		// (get) Token: 0x06023FD4 RID: 147412 RVA: 0x00991A6C File Offset: 0x0098FC6C
		// (set) Token: 0x06023FD5 RID: 147413 RVA: 0x00991A80 File Offset: 0x0098FC80
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004969 RID: 18793
		// (get) Token: 0x06023FD6 RID: 147414 RVA: 0x00991A95 File Offset: 0x0098FC95
		// (set) Token: 0x06023FD7 RID: 147415 RVA: 0x00991AA9 File Offset: 0x0098FCA9
		public unsafe USpringArmComponent SpringArm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpringArmComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700496A RID: 18794
		// (get) Token: 0x06023FD8 RID: 147416 RVA: 0x00991ABE File Offset: 0x0098FCBE
		// (set) Token: 0x06023FD9 RID: 147417 RVA: 0x00991ACE File Offset: 0x0098FCCE
		public unsafe int Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700496B RID: 18795
		// (get) Token: 0x06023FDA RID: 147418 RVA: 0x00991ADF File Offset: 0x0098FCDF
		// (set) Token: 0x06023FDB RID: 147419 RVA: 0x00991AEF File Offset: 0x0098FCEF
		public unsafe int Capture_Max_RTSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700496C RID: 18796
		// (get) Token: 0x06023FDC RID: 147420 RVA: 0x00991B00 File Offset: 0x0098FD00
		// (set) Token: 0x06023FDD RID: 147421 RVA: 0x00991B10 File Offset: 0x0098FD10
		public unsafe int Capture_Max_RTSize_XScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700496D RID: 18797
		// (get) Token: 0x06023FDE RID: 147422 RVA: 0x00991B21 File Offset: 0x0098FD21
		// (set) Token: 0x06023FDF RID: 147423 RVA: 0x00991B31 File Offset: 0x0098FD31
		public unsafe int Capture_Max_RTSize_YScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700496E RID: 18798
		// (get) Token: 0x06023FE0 RID: 147424 RVA: 0x00991B42 File Offset: 0x0098FD42
		// (set) Token: 0x06023FE1 RID: 147425 RVA: 0x00991B56 File Offset: 0x0098FD56
		public unsafe FTransform RelativeLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700496F RID: 18799
		// (get) Token: 0x06023FE2 RID: 147426 RVA: 0x00991B6B File Offset: 0x0098FD6B
		// (set) Token: 0x06023FE3 RID: 147427 RVA: 0x00991B7F File Offset: 0x0098FD7F
		public unsafe FTransform RelativeLocation_DaFuWeng
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004970 RID: 18800
		// (get) Token: 0x06023FE4 RID: 147428 RVA: 0x00991B94 File Offset: 0x0098FD94
		// (set) Token: 0x06023FE5 RID: 147429 RVA: 0x00991BA4 File Offset: 0x0098FDA4
		public unsafe int SelectLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06023FE6 RID: 147430 RVA: 0x00991BB5 File Offset: 0x0098FDB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetTransform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_C.__SetTransform_NativeFunctionPtr, null);
		}

		// Token: 0x06023FE7 RID: 147431 RVA: 0x00991BC9 File Offset: 0x0098FDC9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023FE8 RID: 147432 RVA: 0x00991BDD File Offset: 0x0098FDDD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023FE9 RID: 147433 RVA: 0x00991BF4 File Offset: 0x0098FDF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DiceRenderTexture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DiceRenderTexture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DiceRenderTexture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceRenderTexture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023FEA RID: 147434 RVA: 0x00991C3C File Offset: 0x0098FE3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DiceRenderTexture_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DiceRenderTexture_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DiceRenderTexture_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceRenderTexture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023FEB RID: 147435 RVA: 0x00991C83 File Offset: 0x0098FE83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023FEC RID: 147436 RVA: 0x00991C97 File Offset: 0x0098FE97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023FED RID: 147437 RVA: 0x00991CAC File Offset: 0x0098FEAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DiceRenderTexture(int EntryPoint)
		{
			BP_DiceRenderTexture_C.__ExecuteUbergraph_BP_DiceRenderTexture_FunctionParams* ptr = stackalloc BP_DiceRenderTexture_C.__ExecuteUbergraph_BP_DiceRenderTexture_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_DiceRenderTexture_C.__ExecuteUbergraph_BP_DiceRenderTexture_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceRenderTexture_C.__ExecuteUbergraph_BP_DiceRenderTexture_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_C.__ExecuteUbergraph_BP_DiceRenderTexture_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023FEE RID: 147438 RVA: 0x00991CF3 File Offset: 0x0098FEF3
		protected BP_DiceRenderTexture_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401263B RID: 75323
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceRenderTexture.BP_DiceRenderTexture_C";

		// Token: 0x0401263C RID: 75324
		private static IntPtr _ClassPtr;

		// Token: 0x0401263D RID: 75325
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401263E RID: 75326
		internal static int __PropertyOffset_0;

		// Token: 0x0401263F RID: 75327
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012640 RID: 75328
		internal static int __PropertyOffset_1;

		// Token: 0x04012641 RID: 75329
		internal static int __PropertyOffset_2;

		// Token: 0x04012642 RID: 75330
		internal static int __PropertyOffset_3;

		// Token: 0x04012643 RID: 75331
		internal static int __PropertyOffset_4;

		// Token: 0x04012644 RID: 75332
		internal static int __PropertyOffset_5;

		// Token: 0x04012645 RID: 75333
		internal static int __PropertyOffset_6;

		// Token: 0x04012646 RID: 75334
		internal static int __PropertyOffset_7;

		// Token: 0x04012647 RID: 75335
		internal static int __PropertyOffset_8;

		// Token: 0x04012648 RID: 75336
		internal static int __PropertyOffset_9;

		// Token: 0x04012649 RID: 75337
		internal static int __PropertyOffset_10;

		// Token: 0x0401264A RID: 75338
		internal static int __PropertyOffset_11;

		// Token: 0x0401264B RID: 75339
		private static IntPtr __SetTransform_NativeFunctionPtr;

		// Token: 0x0401264C RID: 75340
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401264D RID: 75341
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401264E RID: 75342
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401264F RID: 75343
		private static IntPtr __ExecuteUbergraph_BP_DiceRenderTexture_NativeFunctionPtr;

		// Token: 0x02009D73 RID: 40307
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032768 RID: 206696
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D74 RID: 40308
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_DiceRenderTexture_FunctionParams
		{
			// Token: 0x04032769 RID: 206697
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
