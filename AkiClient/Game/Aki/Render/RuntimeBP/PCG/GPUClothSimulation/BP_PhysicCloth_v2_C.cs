using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUClothSimulation
{
	// Token: 0x02003C1B RID: 15387
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v2.BP_PhysicCloth_v2_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1432)]
	public class BP_PhysicCloth_v2_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060230F9 RID: 143609 RVA: 0x00977544 File Offset: 0x00975744
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicCloth_v2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v2.BP_PhysicCloth_v2_C");
			}
			return BP_PhysicCloth_v2_C._ClassPtr;
		}

		// Token: 0x060230FA RID: 143610 RVA: 0x00977568 File Offset: 0x00975768
		public BP_PhysicCloth_v2_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicCloth_v2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060230FB RID: 143611 RVA: 0x00977590 File Offset: 0x00975790
		[NullableContext(1)]
		public BP_PhysicCloth_v2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicCloth_v2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004436 RID: 17462
		// (get) Token: 0x060230FC RID: 143612 RVA: 0x009775C4 File Offset: 0x009757C4
		// (set) Token: 0x060230FD RID: 143613 RVA: 0x009775FD File Offset: 0x009757FD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004437 RID: 17463
		// (get) Token: 0x060230FE RID: 143614 RVA: 0x0097761E File Offset: 0x0097581E
		// (set) Token: 0x060230FF RID: 143615 RVA: 0x00977632 File Offset: 0x00975832
		public unsafe UStaticMeshComponent CollsionCube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004438 RID: 17464
		// (get) Token: 0x06023100 RID: 143616 RVA: 0x00977647 File Offset: 0x00975847
		// (set) Token: 0x06023101 RID: 143617 RVA: 0x0097765B File Offset: 0x0097585B
		public unsafe UNiagaraComponent NS_cloth
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004439 RID: 17465
		// (get) Token: 0x06023102 RID: 143618 RVA: 0x00977670 File Offset: 0x00975870
		// (set) Token: 0x06023103 RID: 143619 RVA: 0x00977684 File Offset: 0x00975884
		public unsafe UStaticMeshComponent SM_Ves_Clo_01BS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700443A RID: 17466
		// (get) Token: 0x06023104 RID: 143620 RVA: 0x00977699 File Offset: 0x00975899
		// (set) Token: 0x06023105 RID: 143621 RVA: 0x009776AD File Offset: 0x009758AD
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700443B RID: 17467
		// (get) Token: 0x06023106 RID: 143622 RVA: 0x009776C2 File Offset: 0x009758C2
		// (set) Token: 0x06023107 RID: 143623 RVA: 0x009776D6 File Offset: 0x009758D6
		public unsafe UMaterialInterface Static_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700443C RID: 17468
		// (get) Token: 0x06023108 RID: 143624 RVA: 0x009776EB File Offset: 0x009758EB
		// (set) Token: 0x06023109 RID: 143625 RVA: 0x009776FF File Offset: 0x009758FF
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700443D RID: 17469
		// (get) Token: 0x0602310A RID: 143626 RVA: 0x00977714 File Offset: 0x00975914
		// (set) Token: 0x0602310B RID: 143627 RVA: 0x00977724 File Offset: 0x00975924
		public unsafe int XCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700443E RID: 17470
		// (get) Token: 0x0602310C RID: 143628 RVA: 0x00977735 File Offset: 0x00975935
		// (set) Token: 0x0602310D RID: 143629 RVA: 0x00977745 File Offset: 0x00975945
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700443F RID: 17471
		// (get) Token: 0x0602310E RID: 143630 RVA: 0x00977756 File Offset: 0x00975956
		// (set) Token: 0x0602310F RID: 143631 RVA: 0x00977766 File Offset: 0x00975966
		public unsafe float Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004440 RID: 17472
		// (get) Token: 0x06023110 RID: 143632 RVA: 0x00977777 File Offset: 0x00975977
		// (set) Token: 0x06023111 RID: 143633 RVA: 0x00977787 File Offset: 0x00975987
		public unsafe bool EnableRestoration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004441 RID: 17473
		// (get) Token: 0x06023112 RID: 143634 RVA: 0x00977798 File Offset: 0x00975998
		// (set) Token: 0x06023113 RID: 143635 RVA: 0x009777A8 File Offset: 0x009759A8
		public unsafe float Restoration_Damp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004442 RID: 17474
		// (get) Token: 0x06023114 RID: 143636 RVA: 0x009777B9 File Offset: 0x009759B9
		// (set) Token: 0x06023115 RID: 143637 RVA: 0x009777C9 File Offset: 0x009759C9
		public unsafe float Restoration_Rigidity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004443 RID: 17475
		// (get) Token: 0x06023116 RID: 143638 RVA: 0x009777DA File Offset: 0x009759DA
		// (set) Token: 0x06023117 RID: 143639 RVA: 0x009777EA File Offset: 0x009759EA
		public unsafe bool EnableWPO
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004444 RID: 17476
		// (get) Token: 0x06023118 RID: 143640 RVA: 0x009777FC File Offset: 0x009759FC
		// (set) Token: 0x06023119 RID: 143641 RVA: 0x00977835 File Offset: 0x00975A35
		[Nullable(1)]
		public NewEventDispatcher_0 NewEventDispatcher_0
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				NewEventDispatcher_0 result;
				if ((result = this._NewEventDispatcher_0) == null)
				{
					result = (this._NewEventDispatcher_0 = new NewEventDispatcher_0(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_PhysicCloth_v2_C.__PropertyOffset_14, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17004445 RID: 17477
		// (get) Token: 0x0602311A RID: 143642 RVA: 0x00977856 File Offset: 0x00975A56
		// (set) Token: 0x0602311B RID: 143643 RVA: 0x0097786A File Offset: 0x00975A6A
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicCloth_v2_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x0602311C RID: 143644 RVA: 0x0097787F File Offset: 0x00975A7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Input_Niagara()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__Input_Niagara_NativeFunctionPtr, null);
		}

		// Token: 0x0602311D RID: 143645 RVA: 0x00977893 File Offset: 0x00975A93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Input_Parameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__Input_Parameters_NativeFunctionPtr, null);
		}

		// Token: 0x0602311E RID: 143646 RVA: 0x009778A7 File Offset: 0x00975AA7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602311F RID: 143647 RVA: 0x009778BB File Offset: 0x00975ABB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023120 RID: 143648 RVA: 0x009778D0 File Offset: 0x00975AD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PhysicCloth_v2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicCloth_v2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicCloth_v2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_v2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023121 RID: 143649 RVA: 0x00977918 File Offset: 0x00975B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PhysicCloth_v2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhysicCloth_v2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhysicCloth_v2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_v2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023122 RID: 143650 RVA: 0x0097795F File Offset: 0x00975B5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023123 RID: 143651 RVA: 0x00977973 File Offset: 0x00975B73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023124 RID: 143652 RVA: 0x00977988 File Offset: 0x00975B88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhysicCloth_v2(int EntryPoint)
		{
			BP_PhysicCloth_v2_C.__ExecuteUbergraph_BP_PhysicCloth_v2_FunctionParams* ptr = stackalloc BP_PhysicCloth_v2_C.__ExecuteUbergraph_BP_PhysicCloth_v2_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_PhysicCloth_v2_C.__ExecuteUbergraph_BP_PhysicCloth_v2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicCloth_v2_C.__ExecuteUbergraph_BP_PhysicCloth_v2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhysicCloth_v2_C.__ExecuteUbergraph_BP_PhysicCloth_v2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023125 RID: 143653 RVA: 0x009779CF File Offset: 0x00975BCF
		protected BP_PhysicCloth_v2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D26 RID: 72998
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_PhysicCloth_v2.BP_PhysicCloth_v2_C";

		// Token: 0x04011D27 RID: 72999
		private static IntPtr _ClassPtr;

		// Token: 0x04011D28 RID: 73000
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D29 RID: 73001
		public static IntPtr __NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011D2A RID: 73002
		internal static int __PropertyOffset_0;

		// Token: 0x04011D2B RID: 73003
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011D2C RID: 73004
		internal static int __PropertyOffset_1;

		// Token: 0x04011D2D RID: 73005
		internal static int __PropertyOffset_2;

		// Token: 0x04011D2E RID: 73006
		internal static int __PropertyOffset_3;

		// Token: 0x04011D2F RID: 73007
		internal static int __PropertyOffset_4;

		// Token: 0x04011D30 RID: 73008
		internal static int __PropertyOffset_5;

		// Token: 0x04011D31 RID: 73009
		internal static int __PropertyOffset_6;

		// Token: 0x04011D32 RID: 73010
		internal static int __PropertyOffset_7;

		// Token: 0x04011D33 RID: 73011
		internal static int __PropertyOffset_8;

		// Token: 0x04011D34 RID: 73012
		internal static int __PropertyOffset_9;

		// Token: 0x04011D35 RID: 73013
		internal static int __PropertyOffset_10;

		// Token: 0x04011D36 RID: 73014
		internal static int __PropertyOffset_11;

		// Token: 0x04011D37 RID: 73015
		internal static int __PropertyOffset_12;

		// Token: 0x04011D38 RID: 73016
		internal static int __PropertyOffset_13;

		// Token: 0x04011D39 RID: 73017
		internal static int __PropertyOffset_14;

		// Token: 0x04011D3A RID: 73018
		private NewEventDispatcher_0 _NewEventDispatcher_0;

		// Token: 0x04011D3B RID: 73019
		internal static int __PropertyOffset_15;

		// Token: 0x04011D3C RID: 73020
		private static IntPtr __Input_Niagara_NativeFunctionPtr;

		// Token: 0x04011D3D RID: 73021
		private static IntPtr __Input_Parameters_NativeFunctionPtr;

		// Token: 0x04011D3E RID: 73022
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011D3F RID: 73023
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011D40 RID: 73024
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011D41 RID: 73025
		private static IntPtr __ExecuteUbergraph_BP_PhysicCloth_v2_NativeFunctionPtr;

		// Token: 0x02009C7D RID: 40061
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403256B RID: 206187
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C7E RID: 40062
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_PhysicCloth_v2_FunctionParams
		{
			// Token: 0x0403256C RID: 206188
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
