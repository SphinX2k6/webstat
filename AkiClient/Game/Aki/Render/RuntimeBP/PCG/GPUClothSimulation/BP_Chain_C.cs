using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUClothSimulation
{
	// Token: 0x02003C17 RID: 15383
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_Chain.BP_Chain_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1104)]
	public class BP_Chain_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602304D RID: 143437 RVA: 0x009763FF File Offset: 0x009745FF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Chain_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_Chain.BP_Chain_C");
			}
			return BP_Chain_C._ClassPtr;
		}

		// Token: 0x0602304E RID: 143438 RVA: 0x00976424 File Offset: 0x00974624
		public BP_Chain_C() : this(BuiltinUtils.AllocNativeUObject(BP_Chain_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602304F RID: 143439 RVA: 0x0097644C File Offset: 0x0097464C
		[NullableContext(1)]
		public BP_Chain_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Chain_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043FB RID: 17403
		// (get) Token: 0x06023050 RID: 143440 RVA: 0x00976480 File Offset: 0x00974680
		// (set) Token: 0x06023051 RID: 143441 RVA: 0x009764B9 File Offset: 0x009746B9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170043FC RID: 17404
		// (get) Token: 0x06023052 RID: 143442 RVA: 0x009764DA File Offset: 0x009746DA
		// (set) Token: 0x06023053 RID: 143443 RVA: 0x009764EE File Offset: 0x009746EE
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170043FD RID: 17405
		// (get) Token: 0x06023054 RID: 143444 RVA: 0x00976503 File Offset: 0x00974703
		// (set) Token: 0x06023055 RID: 143445 RVA: 0x00976517 File Offset: 0x00974717
		public unsafe UStaticMeshComponent SM_Tab_Clo_03AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170043FE RID: 17406
		// (get) Token: 0x06023056 RID: 143446 RVA: 0x0097652C File Offset: 0x0097472C
		// (set) Token: 0x06023057 RID: 143447 RVA: 0x00976540 File Offset: 0x00974740
		public unsafe UNiagaraComponent NS_chain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170043FF RID: 17407
		// (get) Token: 0x06023058 RID: 143448 RVA: 0x00976555 File Offset: 0x00974755
		// (set) Token: 0x06023059 RID: 143449 RVA: 0x00976569 File Offset: 0x00974769
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004400 RID: 17408
		// (get) Token: 0x0602305A RID: 143450 RVA: 0x0097657E File Offset: 0x0097477E
		// (set) Token: 0x0602305B RID: 143451 RVA: 0x00976592 File Offset: 0x00974792
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004401 RID: 17409
		// (get) Token: 0x0602305C RID: 143452 RVA: 0x009765A7 File Offset: 0x009747A7
		// (set) Token: 0x0602305D RID: 143453 RVA: 0x009765B7 File Offset: 0x009747B7
		public unsafe int XCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004402 RID: 17410
		// (get) Token: 0x0602305E RID: 143454 RVA: 0x009765C8 File Offset: 0x009747C8
		// (set) Token: 0x0602305F RID: 143455 RVA: 0x009765D8 File Offset: 0x009747D8
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004403 RID: 17411
		// (get) Token: 0x06023060 RID: 143456 RVA: 0x009765E9 File Offset: 0x009747E9
		// (set) Token: 0x06023061 RID: 143457 RVA: 0x009765FD File Offset: 0x009747FD
		public unsafe UMaterialInstanceDynamic Mat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Chain_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004404 RID: 17412
		// (get) Token: 0x06023062 RID: 143458 RVA: 0x00976612 File Offset: 0x00974812
		// (set) Token: 0x06023063 RID: 143459 RVA: 0x00976622 File Offset: 0x00974822
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004405 RID: 17413
		// (get) Token: 0x06023064 RID: 143460 RVA: 0x00976633 File Offset: 0x00974833
		// (set) Token: 0x06023065 RID: 143461 RVA: 0x00976643 File Offset: 0x00974843
		public unsafe float LinkDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Chain_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06023066 RID: 143462 RVA: 0x00976654 File Offset: 0x00974854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Chain_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06023067 RID: 143463 RVA: 0x00976668 File Offset: 0x00974868
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void initMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Chain_C.__initMats_NativeFunctionPtr, null);
		}

		// Token: 0x06023068 RID: 143464 RVA: 0x0097667C File Offset: 0x0097487C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void initRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Chain_C.__initRT_NativeFunctionPtr, null);
		}

		// Token: 0x06023069 RID: 143465 RVA: 0x00976690 File Offset: 0x00974890
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Chain_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602306A RID: 143466 RVA: 0x009766A4 File Offset: 0x009748A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Chain_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602306B RID: 143467 RVA: 0x009766B9 File Offset: 0x009748B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Chain_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602306C RID: 143468 RVA: 0x009766CD File Offset: 0x009748CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Chain_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602306D RID: 143469 RVA: 0x009766E4 File Offset: 0x009748E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Chain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Chain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Chain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Chain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Chain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602306E RID: 143470 RVA: 0x0097672C File Offset: 0x0097492C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Chain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Chain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Chain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Chain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Chain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602306F RID: 143471 RVA: 0x00976774 File Offset: 0x00974974
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Chain(int EntryPoint)
		{
			BP_Chain_C.__ExecuteUbergraph_BP_Chain_FunctionParams* ptr = stackalloc BP_Chain_C.__ExecuteUbergraph_BP_Chain_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Chain_C.__ExecuteUbergraph_BP_Chain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Chain_C.__ExecuteUbergraph_BP_Chain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Chain_C.__ExecuteUbergraph_BP_Chain_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023070 RID: 143472 RVA: 0x009767BB File Offset: 0x009749BB
		protected BP_Chain_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011CC0 RID: 72896
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUClothSimulation/BP_Chain.BP_Chain_C";

		// Token: 0x04011CC1 RID: 72897
		private static IntPtr _ClassPtr;

		// Token: 0x04011CC2 RID: 72898
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011CC3 RID: 72899
		internal static int __PropertyOffset_0;

		// Token: 0x04011CC4 RID: 72900
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011CC5 RID: 72901
		internal static int __PropertyOffset_1;

		// Token: 0x04011CC6 RID: 72902
		internal static int __PropertyOffset_2;

		// Token: 0x04011CC7 RID: 72903
		internal static int __PropertyOffset_3;

		// Token: 0x04011CC8 RID: 72904
		internal static int __PropertyOffset_4;

		// Token: 0x04011CC9 RID: 72905
		internal static int __PropertyOffset_5;

		// Token: 0x04011CCA RID: 72906
		internal static int __PropertyOffset_6;

		// Token: 0x04011CCB RID: 72907
		internal static int __PropertyOffset_7;

		// Token: 0x04011CCC RID: 72908
		internal static int __PropertyOffset_8;

		// Token: 0x04011CCD RID: 72909
		internal static int __PropertyOffset_9;

		// Token: 0x04011CCE RID: 72910
		internal static int __PropertyOffset_10;

		// Token: 0x04011CCF RID: 72911
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04011CD0 RID: 72912
		private static IntPtr __initMats_NativeFunctionPtr;

		// Token: 0x04011CD1 RID: 72913
		private static IntPtr __initRT_NativeFunctionPtr;

		// Token: 0x04011CD2 RID: 72914
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011CD3 RID: 72915
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011CD4 RID: 72916
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011CD5 RID: 72917
		private static IntPtr __ExecuteUbergraph_BP_Chain_NativeFunctionPtr;

		// Token: 0x02009C75 RID: 40053
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032563 RID: 206179
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C76 RID: 40054
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Chain_FunctionParams
		{
			// Token: 0x04032564 RID: 206180
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
