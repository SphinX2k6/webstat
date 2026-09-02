using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUClothSimulation
{
	// Token: 0x02003C19 RID: 15385
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_Horizontal.BP_PhysicCloth_Horizontal_C")]
	[UnrealStructLayout(1152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1152)]
	public class BP_PhysicCloth_Horizontal_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060230A0 RID: 143520 RVA: 0x00976C70 File Offset: 0x00974E70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicCloth_Horizontal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_Horizontal.BP_PhysicCloth_Horizontal_C");
			}
			return BP_PhysicCloth_Horizontal_C._ClassPtr;
		}

		// Token: 0x060230A1 RID: 143521 RVA: 0x00976C94 File Offset: 0x00974E94
		public BP_PhysicCloth_Horizontal_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicCloth_Horizontal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060230A2 RID: 143522 RVA: 0x00976CBC File Offset: 0x00974EBC
		[NullableContext(1)]
		public BP_PhysicCloth_Horizontal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicCloth_Horizontal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004417 RID: 17431
		// (get) Token: 0x060230A3 RID: 143523 RVA: 0x00976CF0 File Offset: 0x00974EF0
		// (set) Token: 0x060230A4 RID: 143524 RVA: 0x00976D29 File Offset: 0x00974F29
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004418 RID: 17432
		// (get) Token: 0x060230A5 RID: 143525 RVA: 0x00976D4A File Offset: 0x00974F4A
		// (set) Token: 0x060230A6 RID: 143526 RVA: 0x00976D5E File Offset: 0x00974F5E
		public unsafe UStaticMeshComponent coll
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004419 RID: 17433
		// (get) Token: 0x060230A7 RID: 143527 RVA: 0x00976D73 File Offset: 0x00974F73
		// (set) Token: 0x060230A8 RID: 143528 RVA: 0x00976D87 File Offset: 0x00974F87
		public unsafe UStaticMeshComponent CollsionCube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700441A RID: 17434
		// (get) Token: 0x060230A9 RID: 143529 RVA: 0x00976D9C File Offset: 0x00974F9C
		// (set) Token: 0x060230AA RID: 143530 RVA: 0x00976DB0 File Offset: 0x00974FB0
		public unsafe UChildActorComponent ChildActor3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700441B RID: 17435
		// (get) Token: 0x060230AB RID: 143531 RVA: 0x00976DC5 File Offset: 0x00974FC5
		// (set) Token: 0x060230AC RID: 143532 RVA: 0x00976DD9 File Offset: 0x00974FD9
		public unsafe UChildActorComponent ChildActor2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700441C RID: 17436
		// (get) Token: 0x060230AD RID: 143533 RVA: 0x00976DEE File Offset: 0x00974FEE
		// (set) Token: 0x060230AE RID: 143534 RVA: 0x00976E02 File Offset: 0x00975002
		public unsafe UChildActorComponent ChildActor1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700441D RID: 17437
		// (get) Token: 0x060230AF RID: 143535 RVA: 0x00976E17 File Offset: 0x00975017
		// (set) Token: 0x060230B0 RID: 143536 RVA: 0x00976E2B File Offset: 0x0097502B
		public unsafe UChildActorComponent ChildActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700441E RID: 17438
		// (get) Token: 0x060230B1 RID: 143537 RVA: 0x00976E40 File Offset: 0x00975040
		// (set) Token: 0x060230B2 RID: 143538 RVA: 0x00976E54 File Offset: 0x00975054
		public unsafe UNiagaraComponent NS_cloth_horizontal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700441F RID: 17439
		// (get) Token: 0x060230B3 RID: 143539 RVA: 0x00976E69 File Offset: 0x00975069
		// (set) Token: 0x060230B4 RID: 143540 RVA: 0x00976E7D File Offset: 0x0097507D
		public unsafe UStaticMeshComponent SM_Tab_Clo_01AH
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004420 RID: 17440
		// (get) Token: 0x060230B5 RID: 143541 RVA: 0x00976E92 File Offset: 0x00975092
		// (set) Token: 0x060230B6 RID: 143542 RVA: 0x00976EA6 File Offset: 0x009750A6
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004421 RID: 17441
		// (get) Token: 0x060230B7 RID: 143543 RVA: 0x00976EBB File Offset: 0x009750BB
		// (set) Token: 0x060230B8 RID: 143544 RVA: 0x00976ECF File Offset: 0x009750CF
		public unsafe UMaterialInterface Static_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004422 RID: 17442
		// (get) Token: 0x060230B9 RID: 143545 RVA: 0x00976EE4 File Offset: 0x009750E4
		// (set) Token: 0x060230BA RID: 143546 RVA: 0x00976EF8 File Offset: 0x009750F8
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004423 RID: 17443
		// (get) Token: 0x060230BB RID: 143547 RVA: 0x00976F0D File Offset: 0x0097510D
		// (set) Token: 0x060230BC RID: 143548 RVA: 0x00976F1D File Offset: 0x0097511D
		public unsafe int XCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004424 RID: 17444
		// (get) Token: 0x060230BD RID: 143549 RVA: 0x00976F2E File Offset: 0x0097512E
		// (set) Token: 0x060230BE RID: 143550 RVA: 0x00976F3E File Offset: 0x0097513E
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004425 RID: 17445
		// (get) Token: 0x060230BF RID: 143551 RVA: 0x00976F4F File Offset: 0x0097514F
		// (set) Token: 0x060230C0 RID: 143552 RVA: 0x00976F5F File Offset: 0x0097515F
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_Horizontal_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004426 RID: 17446
		// (get) Token: 0x060230C1 RID: 143553 RVA: 0x00976F70 File Offset: 0x00975170
		// (set) Token: 0x060230C2 RID: 143554 RVA: 0x00976F84 File Offset: 0x00975184
		public unsafe UMaterialInstanceDynamic dynamic_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_Horizontal_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x060230C3 RID: 143555 RVA: 0x00976F99 File Offset: 0x00975199
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Niagara_Input()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__Niagara_Input_NativeFunctionPtr, null);
		}

		// Token: 0x060230C4 RID: 143556 RVA: 0x00976FAD File Offset: 0x009751AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Bending_Points()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__Bending_Points_NativeFunctionPtr, null);
		}

		// Token: 0x060230C5 RID: 143557 RVA: 0x00976FC1 File Offset: 0x009751C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Input_Parameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__Input_Parameters_NativeFunctionPtr, null);
		}

		// Token: 0x060230C6 RID: 143558 RVA: 0x00976FD5 File Offset: 0x009751D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060230C7 RID: 143559 RVA: 0x00976FE9 File Offset: 0x009751E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060230C8 RID: 143560 RVA: 0x00976FFE File Offset: 0x009751FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060230C9 RID: 143561 RVA: 0x00977012 File Offset: 0x00975212
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060230CA RID: 143562 RVA: 0x00977028 File Offset: 0x00975228
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PhysicCloth_Horizontal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicCloth_Horizontal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicCloth_Horizontal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_Horizontal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060230CB RID: 143563 RVA: 0x00977070 File Offset: 0x00975270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PhysicCloth_Horizontal_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicCloth_Horizontal_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicCloth_Horizontal_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_Horizontal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060230CC RID: 143564 RVA: 0x009770B8 File Offset: 0x009752B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicCloth_Horizontal(int EntryPoint)
		{
			BP_PhysicCloth_Horizontal_C.__ExecuteUbergraph_BP_PhysicCloth_Horizontal_FunctionParams* ptr = stackalloc BP_PhysicCloth_Horizontal_C.__ExecuteUbergraph_BP_PhysicCloth_Horizontal_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicCloth_Horizontal_C.__ExecuteUbergraph_BP_PhysicCloth_Horizontal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_Horizontal_C.__ExecuteUbergraph_BP_PhysicCloth_Horizontal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_Horizontal_C.__ExecuteUbergraph_BP_PhysicCloth_Horizontal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060230CD RID: 143565 RVA: 0x009770FF File Offset: 0x009752FF
		protected BP_PhysicCloth_Horizontal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011CF2 RID: 72946
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_Horizontal.BP_PhysicCloth_Horizontal_C";

		// Token: 0x04011CF3 RID: 72947
		private static IntPtr _ClassPtr;

		// Token: 0x04011CF4 RID: 72948
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011CF5 RID: 72949
		internal static int __PropertyOffset_0;

		// Token: 0x04011CF6 RID: 72950
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011CF7 RID: 72951
		internal static int __PropertyOffset_1;

		// Token: 0x04011CF8 RID: 72952
		internal static int __PropertyOffset_2;

		// Token: 0x04011CF9 RID: 72953
		internal static int __PropertyOffset_3;

		// Token: 0x04011CFA RID: 72954
		internal static int __PropertyOffset_4;

		// Token: 0x04011CFB RID: 72955
		internal static int __PropertyOffset_5;

		// Token: 0x04011CFC RID: 72956
		internal static int __PropertyOffset_6;

		// Token: 0x04011CFD RID: 72957
		internal static int __PropertyOffset_7;

		// Token: 0x04011CFE RID: 72958
		internal static int __PropertyOffset_8;

		// Token: 0x04011CFF RID: 72959
		internal static int __PropertyOffset_9;

		// Token: 0x04011D00 RID: 72960
		internal static int __PropertyOffset_10;

		// Token: 0x04011D01 RID: 72961
		internal static int __PropertyOffset_11;

		// Token: 0x04011D02 RID: 72962
		internal static int __PropertyOffset_12;

		// Token: 0x04011D03 RID: 72963
		internal static int __PropertyOffset_13;

		// Token: 0x04011D04 RID: 72964
		internal static int __PropertyOffset_14;

		// Token: 0x04011D05 RID: 72965
		internal static int __PropertyOffset_15;

		// Token: 0x04011D06 RID: 72966
		private static IntPtr __Niagara_Input_NativeFunctionPtr;

		// Token: 0x04011D07 RID: 72967
		private static IntPtr __Bending_Points_NativeFunctionPtr;

		// Token: 0x04011D08 RID: 72968
		private static IntPtr __Input_Parameters_NativeFunctionPtr;

		// Token: 0x04011D09 RID: 72969
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011D0A RID: 72970
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011D0B RID: 72971
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011D0C RID: 72972
		private static IntPtr __ExecuteUbergraph_BP_PhysicCloth_Horizontal_NativeFunctionPtr;

		// Token: 0x02009C79 RID: 40057
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032567 RID: 206183
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C7A RID: 40058
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PhysicCloth_Horizontal_FunctionParams
		{
			// Token: 0x04032568 RID: 206184
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
