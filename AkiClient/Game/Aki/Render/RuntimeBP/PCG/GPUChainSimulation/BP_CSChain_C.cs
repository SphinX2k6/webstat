using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUChainSimulation
{
	// Token: 0x02003C1E RID: 15390
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/BP_CSChain.BP_CSChain_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_CSChain_C : AKuroCSChain, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023167 RID: 143719 RVA: 0x00978193 File Offset: 0x00976393
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CSChain_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/BP_CSChain.BP_CSChain_C");
			}
			return BP_CSChain_C._ClassPtr;
		}

		// Token: 0x06023168 RID: 143720 RVA: 0x009781B8 File Offset: 0x009763B8
		public BP_CSChain_C() : this(BuiltinUtils.AllocNativeUObject(BP_CSChain_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023169 RID: 143721 RVA: 0x009781E0 File Offset: 0x009763E0
		[NullableContext(1)]
		public BP_CSChain_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CSChain_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004458 RID: 17496
		// (get) Token: 0x0602316A RID: 143722 RVA: 0x00978214 File Offset: 0x00976414
		// (set) Token: 0x0602316B RID: 143723 RVA: 0x0097824D File Offset: 0x0097644D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004459 RID: 17497
		// (get) Token: 0x0602316C RID: 143724 RVA: 0x0097826E File Offset: 0x0097646E
		// (set) Token: 0x0602316D RID: 143725 RVA: 0x00978282 File Offset: 0x00976482
		public unsafe UChildActorComponent ChainEnd
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700445A RID: 17498
		// (get) Token: 0x0602316E RID: 143726 RVA: 0x00978297 File Offset: 0x00976497
		// (set) Token: 0x0602316F RID: 143727 RVA: 0x009782AB File Offset: 0x009764AB
		public unsafe UChildActorComponent ChainStart
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700445B RID: 17499
		// (get) Token: 0x06023170 RID: 143728 RVA: 0x009782C0 File Offset: 0x009764C0
		// (set) Token: 0x06023171 RID: 143729 RVA: 0x009782D4 File Offset: 0x009764D4
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700445C RID: 17500
		// (get) Token: 0x06023172 RID: 143730 RVA: 0x009782E9 File Offset: 0x009764E9
		// (set) Token: 0x06023173 RID: 143731 RVA: 0x009782FD File Offset: 0x009764FD
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700445D RID: 17501
		// (get) Token: 0x06023174 RID: 143732 RVA: 0x00978312 File Offset: 0x00976512
		// (set) Token: 0x06023175 RID: 143733 RVA: 0x00978322 File Offset: 0x00976522
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700445E RID: 17502
		// (get) Token: 0x06023176 RID: 143734 RVA: 0x00978333 File Offset: 0x00976533
		// (set) Token: 0x06023177 RID: 143735 RVA: 0x00978343 File Offset: 0x00976543
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700445F RID: 17503
		// (get) Token: 0x06023178 RID: 143736 RVA: 0x00978354 File Offset: 0x00976554
		// (set) Token: 0x06023179 RID: 143737 RVA: 0x0097838D File Offset: 0x0097658D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> Mats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._Mats) == null)
				{
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x17004460 RID: 17504
		// (get) Token: 0x0602317A RID: 143738 RVA: 0x0097839B File Offset: 0x0097659B
		// (set) Token: 0x0602317B RID: 143739 RVA: 0x009783AB File Offset: 0x009765AB
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004461 RID: 17505
		// (get) Token: 0x0602317C RID: 143740 RVA: 0x009783BC File Offset: 0x009765BC
		// (set) Token: 0x0602317D RID: 143741 RVA: 0x009783CC File Offset: 0x009765CC
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004462 RID: 17506
		// (get) Token: 0x0602317E RID: 143742 RVA: 0x009783DD File Offset: 0x009765DD
		// (set) Token: 0x0602317F RID: 143743 RVA: 0x009783ED File Offset: 0x009765ED
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004463 RID: 17507
		// (get) Token: 0x06023180 RID: 143744 RVA: 0x009783FE File Offset: 0x009765FE
		// (set) Token: 0x06023181 RID: 143745 RVA: 0x0097840E File Offset: 0x0097660E
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004464 RID: 17508
		// (get) Token: 0x06023182 RID: 143746 RVA: 0x0097841F File Offset: 0x0097661F
		// (set) Token: 0x06023183 RID: 143747 RVA: 0x00978433 File Offset: 0x00976633
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004465 RID: 17509
		// (get) Token: 0x06023184 RID: 143748 RVA: 0x00978448 File Offset: 0x00976648
		// (set) Token: 0x06023185 RID: 143749 RVA: 0x0097845C File Offset: 0x0097665C
		public unsafe FVector gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004466 RID: 17510
		// (get) Token: 0x06023186 RID: 143750 RVA: 0x00978471 File Offset: 0x00976671
		// (set) Token: 0x06023187 RID: 143751 RVA: 0x00978485 File Offset: 0x00976685
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004467 RID: 17511
		// (get) Token: 0x06023188 RID: 143752 RVA: 0x0097849A File Offset: 0x0097669A
		// (set) Token: 0x06023189 RID: 143753 RVA: 0x009784AA File Offset: 0x009766AA
		public unsafe float 弹力系数_编译器下可更改_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004468 RID: 17512
		// (get) Token: 0x0602318A RID: 143754 RVA: 0x009784BB File Offset: 0x009766BB
		// (set) Token: 0x0602318B RID: 143755 RVA: 0x009784CB File Offset: 0x009766CB
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004469 RID: 17513
		// (get) Token: 0x0602318C RID: 143756 RVA: 0x009784DC File Offset: 0x009766DC
		// (set) Token: 0x0602318D RID: 143757 RVA: 0x009784F0 File Offset: 0x009766F0
		public unsafe AStaticMeshActor SM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x0602318E RID: 143758 RVA: 0x00978505 File Offset: 0x00976705
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x0602318F RID: 143759 RVA: 0x00978519 File Offset: 0x00976719
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x06023190 RID: 143760 RVA: 0x0097852D File Offset: 0x0097672D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023191 RID: 143761 RVA: 0x00978541 File Offset: 0x00976741
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023192 RID: 143762 RVA: 0x00978556 File Offset: 0x00976756
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023193 RID: 143763 RVA: 0x0097856A File Offset: 0x0097676A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023194 RID: 143764 RVA: 0x00978580 File Offset: 0x00976780
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CSChain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CSChain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CSChain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023195 RID: 143765 RVA: 0x009785C8 File Offset: 0x009767C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CSChain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CSChain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CSChain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023196 RID: 143766 RVA: 0x0097860F File Offset: 0x0097680F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023197 RID: 143767 RVA: 0x00978624 File Offset: 0x00976824
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_CSChain_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_CSChain_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CSChain_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023198 RID: 143768 RVA: 0x00978670 File Offset: 0x00976870
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_CSChain_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_CSChain_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CSChain_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023199 RID: 143769 RVA: 0x009786BC File Offset: 0x009768BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602319A RID: 143770 RVA: 0x00978778 File Offset: 0x00976978
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602319B RID: 143771 RVA: 0x00978804 File Offset: 0x00976A04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CSChain(int EntryPoint)
		{
			BP_CSChain_C.__ExecuteUbergraph_BP_CSChain_FunctionParams* ptr = stackalloc BP_CSChain_C.__ExecuteUbergraph_BP_CSChain_FunctionParams[(UIntPtr)959] + 15L / (long)sizeof(BP_CSChain_C.__ExecuteUbergraph_BP_CSChain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain_C.__ExecuteUbergraph_BP_CSChain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain_C.__ExecuteUbergraph_BP_CSChain_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602319C RID: 143772 RVA: 0x0097884E File Offset: 0x00976A4E
		protected BP_CSChain_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D65 RID: 73061
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/BP_CSChain.BP_CSChain_C";

		// Token: 0x04011D66 RID: 73062
		private static IntPtr _ClassPtr;

		// Token: 0x04011D67 RID: 73063
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D68 RID: 73064
		internal static int __PropertyOffset_0;

		// Token: 0x04011D69 RID: 73065
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011D6A RID: 73066
		internal static int __PropertyOffset_1;

		// Token: 0x04011D6B RID: 73067
		internal static int __PropertyOffset_2;

		// Token: 0x04011D6C RID: 73068
		internal static int __PropertyOffset_3;

		// Token: 0x04011D6D RID: 73069
		internal static int __PropertyOffset_4;

		// Token: 0x04011D6E RID: 73070
		internal static int __PropertyOffset_5;

		// Token: 0x04011D6F RID: 73071
		internal static int __PropertyOffset_6;

		// Token: 0x04011D70 RID: 73072
		internal static int __PropertyOffset_7;

		// Token: 0x04011D71 RID: 73073
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011D72 RID: 73074
		internal static int __PropertyOffset_8;

		// Token: 0x04011D73 RID: 73075
		internal static int __PropertyOffset_9;

		// Token: 0x04011D74 RID: 73076
		internal static int __PropertyOffset_10;

		// Token: 0x04011D75 RID: 73077
		internal static int __PropertyOffset_11;

		// Token: 0x04011D76 RID: 73078
		internal static int __PropertyOffset_12;

		// Token: 0x04011D77 RID: 73079
		internal static int __PropertyOffset_13;

		// Token: 0x04011D78 RID: 73080
		internal static int __PropertyOffset_14;

		// Token: 0x04011D79 RID: 73081
		internal static int __PropertyOffset_15;

		// Token: 0x04011D7A RID: 73082
		internal static int __PropertyOffset_16;

		// Token: 0x04011D7B RID: 73083
		internal static int __PropertyOffset_17;

		// Token: 0x04011D7C RID: 73084
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011D7D RID: 73085
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011D7E RID: 73086
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011D7F RID: 73087
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011D80 RID: 73088
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011D81 RID: 73089
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011D82 RID: 73090
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011D83 RID: 73091
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011D84 RID: 73092
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011D85 RID: 73093
		private static IntPtr __ExecuteUbergraph_BP_CSChain_NativeFunctionPtr;

		// Token: 0x02009C84 RID: 40068
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403257A RID: 206202
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C85 RID: 40069
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403257B RID: 206203
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C86 RID: 40070
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403257C RID: 206204
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403257D RID: 206205
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403257E RID: 206206
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403257F RID: 206207
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032580 RID: 206208
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032581 RID: 206209
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C87 RID: 40071
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032582 RID: 206210
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032583 RID: 206211
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032584 RID: 206212
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032585 RID: 206213
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C88 RID: 40072
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 944)]
		protected ref struct __ExecuteUbergraph_BP_CSChain_FunctionParams
		{
			// Token: 0x04032586 RID: 206214
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
