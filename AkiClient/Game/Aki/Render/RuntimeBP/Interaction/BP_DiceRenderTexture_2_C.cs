using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C7B RID: 15483
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceRenderTexture_2.BP_DiceRenderTexture_2_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class BP_DiceRenderTexture_2_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023FAE RID: 147374 RVA: 0x0099160B File Offset: 0x0098F80B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DiceRenderTexture_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceRenderTexture_2.BP_DiceRenderTexture_2_C");
			}
			return BP_DiceRenderTexture_2_C._ClassPtr;
		}

		// Token: 0x06023FAF RID: 147375 RVA: 0x00991630 File Offset: 0x0098F830
		public BP_DiceRenderTexture_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DiceRenderTexture_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023FB0 RID: 147376 RVA: 0x00991658 File Offset: 0x0098F858
		[NullableContext(1)]
		public BP_DiceRenderTexture_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DiceRenderTexture_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700495C RID: 18780
		// (get) Token: 0x06023FB1 RID: 147377 RVA: 0x0099168C File Offset: 0x0098F88C
		// (set) Token: 0x06023FB2 RID: 147378 RVA: 0x009916C5 File Offset: 0x0098F8C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700495D RID: 18781
		// (get) Token: 0x06023FB3 RID: 147379 RVA: 0x009916E6 File Offset: 0x0098F8E6
		// (set) Token: 0x06023FB4 RID: 147380 RVA: 0x009916FA File Offset: 0x0098F8FA
		public unsafe UStaticMeshComponent SM_Act_Pro_101AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700495E RID: 18782
		// (get) Token: 0x06023FB5 RID: 147381 RVA: 0x0099170F File Offset: 0x0098F90F
		// (set) Token: 0x06023FB6 RID: 147382 RVA: 0x00991723 File Offset: 0x0098F923
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700495F RID: 18783
		// (get) Token: 0x06023FB7 RID: 147383 RVA: 0x00991738 File Offset: 0x0098F938
		// (set) Token: 0x06023FB8 RID: 147384 RVA: 0x0099174C File Offset: 0x0098F94C
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004960 RID: 18784
		// (get) Token: 0x06023FB9 RID: 147385 RVA: 0x00991761 File Offset: 0x0098F961
		// (set) Token: 0x06023FBA RID: 147386 RVA: 0x00991775 File Offset: 0x0098F975
		public unsafe USpringArmComponent SpringArm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USpringArmComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DiceRenderTexture_2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004961 RID: 18785
		// (get) Token: 0x06023FBB RID: 147387 RVA: 0x0099178A File Offset: 0x0098F98A
		// (set) Token: 0x06023FBC RID: 147388 RVA: 0x0099179A File Offset: 0x0098F99A
		public unsafe int Counter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004962 RID: 18786
		// (get) Token: 0x06023FBD RID: 147389 RVA: 0x009917AB File Offset: 0x0098F9AB
		// (set) Token: 0x06023FBE RID: 147390 RVA: 0x009917BB File Offset: 0x0098F9BB
		public unsafe int Capture_Max_RTSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004963 RID: 18787
		// (get) Token: 0x06023FBF RID: 147391 RVA: 0x009917CC File Offset: 0x0098F9CC
		// (set) Token: 0x06023FC0 RID: 147392 RVA: 0x009917DC File Offset: 0x0098F9DC
		public unsafe int Capture_Max_RTSize_XScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004964 RID: 18788
		// (get) Token: 0x06023FC1 RID: 147393 RVA: 0x009917ED File Offset: 0x0098F9ED
		// (set) Token: 0x06023FC2 RID: 147394 RVA: 0x009917FD File Offset: 0x0098F9FD
		public unsafe int Capture_Max_RTSize_YScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DiceRenderTexture_2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x06023FC3 RID: 147395 RVA: 0x0099180E File Offset: 0x0098FA0E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023FC4 RID: 147396 RVA: 0x00991822 File Offset: 0x0098FA22
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023FC5 RID: 147397 RVA: 0x00991838 File Offset: 0x0098FA38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_DiceRenderTexture_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DiceRenderTexture_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DiceRenderTexture_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceRenderTexture_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023FC6 RID: 147398 RVA: 0x00991880 File Offset: 0x0098FA80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_DiceRenderTexture_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_DiceRenderTexture_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_DiceRenderTexture_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceRenderTexture_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023FC7 RID: 147399 RVA: 0x009918C7 File Offset: 0x0098FAC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023FC8 RID: 147400 RVA: 0x009918DB File Offset: 0x0098FADB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023FC9 RID: 147401 RVA: 0x009918F0 File Offset: 0x0098FAF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_DiceRenderTexture_2(int EntryPoint)
		{
			BP_DiceRenderTexture_2_C.__ExecuteUbergraph_BP_DiceRenderTexture_2_FunctionParams* ptr = stackalloc BP_DiceRenderTexture_2_C.__ExecuteUbergraph_BP_DiceRenderTexture_2_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_DiceRenderTexture_2_C.__ExecuteUbergraph_BP_DiceRenderTexture_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_DiceRenderTexture_2_C.__ExecuteUbergraph_BP_DiceRenderTexture_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DiceRenderTexture_2_C.__ExecuteUbergraph_BP_DiceRenderTexture_2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023FCA RID: 147402 RVA: 0x00991937 File Offset: 0x0098FB37
		protected BP_DiceRenderTexture_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401262A RID: 75306
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_DiceRenderTexture_2.BP_DiceRenderTexture_2_C";

		// Token: 0x0401262B RID: 75307
		private static IntPtr _ClassPtr;

		// Token: 0x0401262C RID: 75308
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401262D RID: 75309
		internal static int __PropertyOffset_0;

		// Token: 0x0401262E RID: 75310
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401262F RID: 75311
		internal static int __PropertyOffset_1;

		// Token: 0x04012630 RID: 75312
		internal static int __PropertyOffset_2;

		// Token: 0x04012631 RID: 75313
		internal static int __PropertyOffset_3;

		// Token: 0x04012632 RID: 75314
		internal static int __PropertyOffset_4;

		// Token: 0x04012633 RID: 75315
		internal static int __PropertyOffset_5;

		// Token: 0x04012634 RID: 75316
		internal static int __PropertyOffset_6;

		// Token: 0x04012635 RID: 75317
		internal static int __PropertyOffset_7;

		// Token: 0x04012636 RID: 75318
		internal static int __PropertyOffset_8;

		// Token: 0x04012637 RID: 75319
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012638 RID: 75320
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012639 RID: 75321
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401263A RID: 75322
		private static IntPtr __ExecuteUbergraph_BP_DiceRenderTexture_2_NativeFunctionPtr;

		// Token: 0x02009D71 RID: 40305
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032766 RID: 206694
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D72 RID: 40306
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_DiceRenderTexture_2_FunctionParams
		{
			// Token: 0x04032767 RID: 206695
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
