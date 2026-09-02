using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUClothSimulation
{
	// Token: 0x02003C18 RID: 15384
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicBridgeChain.BP_PhysicBridgeChain_C")]
	[UnrealStructLayout(1176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1176)]
	public class BP_PhysicBridgeChain_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023071 RID: 143473 RVA: 0x009767C4 File Offset: 0x009749C4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicBridgeChain_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicBridgeChain.BP_PhysicBridgeChain_C");
			}
			return BP_PhysicBridgeChain_C._ClassPtr;
		}

		// Token: 0x06023072 RID: 143474 RVA: 0x009767E8 File Offset: 0x009749E8
		public BP_PhysicBridgeChain_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicBridgeChain_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023073 RID: 143475 RVA: 0x00976810 File Offset: 0x00974A10
		[NullableContext(1)]
		public BP_PhysicBridgeChain_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicBridgeChain_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004406 RID: 17414
		// (get) Token: 0x06023074 RID: 143476 RVA: 0x00976844 File Offset: 0x00974A44
		// (set) Token: 0x06023075 RID: 143477 RVA: 0x0097687D File Offset: 0x00974A7D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004407 RID: 17415
		// (get) Token: 0x06023076 RID: 143478 RVA: 0x0097689E File Offset: 0x00974A9E
		// (set) Token: 0x06023077 RID: 143479 RVA: 0x009768B2 File Offset: 0x00974AB2
		public unsafe UStaticMeshComponent SM_Com2_Bri_11EM_scale_bound_version
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004408 RID: 17416
		// (get) Token: 0x06023078 RID: 143480 RVA: 0x009768C7 File Offset: 0x00974AC7
		// (set) Token: 0x06023079 RID: 143481 RVA: 0x009768DB File Offset: 0x00974ADB
		public unsafe UChildActorComponent ChildActor3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004409 RID: 17417
		// (get) Token: 0x0602307A RID: 143482 RVA: 0x009768F0 File Offset: 0x00974AF0
		// (set) Token: 0x0602307B RID: 143483 RVA: 0x00976904 File Offset: 0x00974B04
		public unsafe UChildActorComponent ChildActor2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700440A RID: 17418
		// (get) Token: 0x0602307C RID: 143484 RVA: 0x00976919 File Offset: 0x00974B19
		// (set) Token: 0x0602307D RID: 143485 RVA: 0x0097692D File Offset: 0x00974B2D
		public unsafe UChildActorComponent ChildActor1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700440B RID: 17419
		// (get) Token: 0x0602307E RID: 143486 RVA: 0x00976942 File Offset: 0x00974B42
		// (set) Token: 0x0602307F RID: 143487 RVA: 0x00976956 File Offset: 0x00974B56
		public unsafe UChildActorComponent ChildActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700440C RID: 17420
		// (get) Token: 0x06023080 RID: 143488 RVA: 0x0097696B File Offset: 0x00974B6B
		// (set) Token: 0x06023081 RID: 143489 RVA: 0x0097697F File Offset: 0x00974B7F
		public unsafe UNiagaraComponent NS_BridgeChain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700440D RID: 17421
		// (get) Token: 0x06023082 RID: 143490 RVA: 0x00976994 File Offset: 0x00974B94
		// (set) Token: 0x06023083 RID: 143491 RVA: 0x009769A8 File Offset: 0x00974BA8
		public unsafe UMaterialInterface Static_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700440E RID: 17422
		// (get) Token: 0x06023084 RID: 143492 RVA: 0x009769BD File Offset: 0x00974BBD
		// (set) Token: 0x06023085 RID: 143493 RVA: 0x009769D1 File Offset: 0x00974BD1
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700440F RID: 17423
		// (get) Token: 0x06023086 RID: 143494 RVA: 0x009769E6 File Offset: 0x00974BE6
		// (set) Token: 0x06023087 RID: 143495 RVA: 0x009769F6 File Offset: 0x00974BF6
		public unsafe int XCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004410 RID: 17424
		// (get) Token: 0x06023088 RID: 143496 RVA: 0x00976A07 File Offset: 0x00974C07
		// (set) Token: 0x06023089 RID: 143497 RVA: 0x00976A17 File Offset: 0x00974C17
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004411 RID: 17425
		// (get) Token: 0x0602308A RID: 143498 RVA: 0x00976A28 File Offset: 0x00974C28
		// (set) Token: 0x0602308B RID: 143499 RVA: 0x00976A38 File Offset: 0x00974C38
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004412 RID: 17426
		// (get) Token: 0x0602308C RID: 143500 RVA: 0x00976A49 File Offset: 0x00974C49
		// (set) Token: 0x0602308D RID: 143501 RVA: 0x00976A5D File Offset: 0x00974C5D
		public unsafe FVector v11
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004413 RID: 17427
		// (get) Token: 0x0602308E RID: 143502 RVA: 0x00976A72 File Offset: 0x00974C72
		// (set) Token: 0x0602308F RID: 143503 RVA: 0x00976A86 File Offset: 0x00974C86
		public unsafe FVector v12
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004414 RID: 17428
		// (get) Token: 0x06023090 RID: 143504 RVA: 0x00976A9B File Offset: 0x00974C9B
		// (set) Token: 0x06023091 RID: 143505 RVA: 0x00976AAF File Offset: 0x00974CAF
		public unsafe FVector v21
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004415 RID: 17429
		// (get) Token: 0x06023092 RID: 143506 RVA: 0x00976AC4 File Offset: 0x00974CC4
		// (set) Token: 0x06023093 RID: 143507 RVA: 0x00976AD8 File Offset: 0x00974CD8
		public unsafe FVector v22
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicBridgeChain_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004416 RID: 17430
		// (get) Token: 0x06023094 RID: 143508 RVA: 0x00976AED File Offset: 0x00974CED
		// (set) Token: 0x06023095 RID: 143509 RVA: 0x00976B01 File Offset: 0x00974D01
		public unsafe UMaterialInstanceDynamic DMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicBridgeChain_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x06023096 RID: 143510 RVA: 0x00976B16 File Offset: 0x00974D16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void niagara_Input()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__niagara_Input_NativeFunctionPtr, null);
		}

		// Token: 0x06023097 RID: 143511 RVA: 0x00976B2A File Offset: 0x00974D2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Bending_Points_from_Outside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__Bending_Points_from_Outside_NativeFunctionPtr, null);
		}

		// Token: 0x06023098 RID: 143512 RVA: 0x00976B3E File Offset: 0x00974D3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Bending_Points()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__Bending_Points_NativeFunctionPtr, null);
		}

		// Token: 0x06023099 RID: 143513 RVA: 0x00976B52 File Offset: 0x00974D52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Input_Parameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__Input_Parameters_NativeFunctionPtr, null);
		}

		// Token: 0x0602309A RID: 143514 RVA: 0x00976B68 File Offset: 0x00974D68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PhysicBridgeChain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicBridgeChain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicBridgeChain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicBridgeChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602309B RID: 143515 RVA: 0x00976BB0 File Offset: 0x00974DB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PhysicBridgeChain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicBridgeChain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicBridgeChain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicBridgeChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602309C RID: 143516 RVA: 0x00976BF7 File Offset: 0x00974DF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602309D RID: 143517 RVA: 0x00976C0B File Offset: 0x00974E0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602309E RID: 143518 RVA: 0x00976C20 File Offset: 0x00974E20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicBridgeChain(int EntryPoint)
		{
			BP_PhysicBridgeChain_C.__ExecuteUbergraph_BP_PhysicBridgeChain_FunctionParams* ptr = stackalloc BP_PhysicBridgeChain_C.__ExecuteUbergraph_BP_PhysicBridgeChain_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicBridgeChain_C.__ExecuteUbergraph_BP_PhysicBridgeChain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicBridgeChain_C.__ExecuteUbergraph_BP_PhysicBridgeChain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicBridgeChain_C.__ExecuteUbergraph_BP_PhysicBridgeChain_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602309F RID: 143519 RVA: 0x00976C67 File Offset: 0x00974E67
		protected BP_PhysicBridgeChain_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011CD6 RID: 72918
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicBridgeChain.BP_PhysicBridgeChain_C";

		// Token: 0x04011CD7 RID: 72919
		private static IntPtr _ClassPtr;

		// Token: 0x04011CD8 RID: 72920
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011CD9 RID: 72921
		internal static int __PropertyOffset_0;

		// Token: 0x04011CDA RID: 72922
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011CDB RID: 72923
		internal static int __PropertyOffset_1;

		// Token: 0x04011CDC RID: 72924
		internal static int __PropertyOffset_2;

		// Token: 0x04011CDD RID: 72925
		internal static int __PropertyOffset_3;

		// Token: 0x04011CDE RID: 72926
		internal static int __PropertyOffset_4;

		// Token: 0x04011CDF RID: 72927
		internal static int __PropertyOffset_5;

		// Token: 0x04011CE0 RID: 72928
		internal static int __PropertyOffset_6;

		// Token: 0x04011CE1 RID: 72929
		internal static int __PropertyOffset_7;

		// Token: 0x04011CE2 RID: 72930
		internal static int __PropertyOffset_8;

		// Token: 0x04011CE3 RID: 72931
		internal static int __PropertyOffset_9;

		// Token: 0x04011CE4 RID: 72932
		internal static int __PropertyOffset_10;

		// Token: 0x04011CE5 RID: 72933
		internal static int __PropertyOffset_11;

		// Token: 0x04011CE6 RID: 72934
		internal static int __PropertyOffset_12;

		// Token: 0x04011CE7 RID: 72935
		internal static int __PropertyOffset_13;

		// Token: 0x04011CE8 RID: 72936
		internal static int __PropertyOffset_14;

		// Token: 0x04011CE9 RID: 72937
		internal static int __PropertyOffset_15;

		// Token: 0x04011CEA RID: 72938
		internal static int __PropertyOffset_16;

		// Token: 0x04011CEB RID: 72939
		private static IntPtr __niagara_Input_NativeFunctionPtr;

		// Token: 0x04011CEC RID: 72940
		private static IntPtr __Bending_Points_from_Outside_NativeFunctionPtr;

		// Token: 0x04011CED RID: 72941
		private static IntPtr __Bending_Points_NativeFunctionPtr;

		// Token: 0x04011CEE RID: 72942
		private static IntPtr __Input_Parameters_NativeFunctionPtr;

		// Token: 0x04011CEF RID: 72943
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011CF0 RID: 72944
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011CF1 RID: 72945
		private static IntPtr __ExecuteUbergraph_BP_PhysicBridgeChain_NativeFunctionPtr;

		// Token: 0x02009C77 RID: 40055
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032565 RID: 206181
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C78 RID: 40056
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_PhysicBridgeChain_FunctionParams
		{
			// Token: 0x04032566 RID: 206182
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
