using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUChainSimulation
{
	// Token: 0x02003C1D RID: 15389
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/BP_CSChain30.BP_CSChain30_C")]
	[UnrealStructLayout(1624, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1620)]
	public class BP_CSChain30_C : AKuroCSChain30, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023130 RID: 143664 RVA: 0x00977ABA File Offset: 0x00975CBA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CSChain30_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/BP_CSChain30.BP_CSChain30_C");
			}
			return BP_CSChain30_C._ClassPtr;
		}

		// Token: 0x06023131 RID: 143665 RVA: 0x00977AE0 File Offset: 0x00975CE0
		public BP_CSChain30_C() : this(BuiltinUtils.AllocNativeUObject(BP_CSChain30_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023132 RID: 143666 RVA: 0x00977B08 File Offset: 0x00975D08
		[NullableContext(1)]
		public BP_CSChain30_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CSChain30_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004446 RID: 17478
		// (get) Token: 0x06023133 RID: 143667 RVA: 0x00977B3C File Offset: 0x00975D3C
		// (set) Token: 0x06023134 RID: 143668 RVA: 0x00977B75 File Offset: 0x00975D75
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004447 RID: 17479
		// (get) Token: 0x06023135 RID: 143669 RVA: 0x00977B96 File Offset: 0x00975D96
		// (set) Token: 0x06023136 RID: 143670 RVA: 0x00977BAA File Offset: 0x00975DAA
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004448 RID: 17480
		// (get) Token: 0x06023137 RID: 143671 RVA: 0x00977BBF File Offset: 0x00975DBF
		// (set) Token: 0x06023138 RID: 143672 RVA: 0x00977BD3 File Offset: 0x00975DD3
		public unsafe UStaticMeshComponent ClothMeshXZ
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004449 RID: 17481
		// (get) Token: 0x06023139 RID: 143673 RVA: 0x00977BE8 File Offset: 0x00975DE8
		// (set) Token: 0x0602313A RID: 143674 RVA: 0x00977BFC File Offset: 0x00975DFC
		public unsafe UTextureRenderTarget2D RT_P
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700444A RID: 17482
		// (get) Token: 0x0602313B RID: 143675 RVA: 0x00977C11 File Offset: 0x00975E11
		// (set) Token: 0x0602313C RID: 143676 RVA: 0x00977C25 File Offset: 0x00975E25
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700444B RID: 17483
		// (get) Token: 0x0602313D RID: 143677 RVA: 0x00977C3A File Offset: 0x00975E3A
		// (set) Token: 0x0602313E RID: 143678 RVA: 0x00977C4A File Offset: 0x00975E4A
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700444C RID: 17484
		// (get) Token: 0x0602313F RID: 143679 RVA: 0x00977C5B File Offset: 0x00975E5B
		// (set) Token: 0x06023140 RID: 143680 RVA: 0x00977C6B File Offset: 0x00975E6B
		public unsafe float FadeOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700444D RID: 17485
		// (get) Token: 0x06023141 RID: 143681 RVA: 0x00977C7C File Offset: 0x00975E7C
		// (set) Token: 0x06023142 RID: 143682 RVA: 0x00977CB5 File Offset: 0x00975EB5
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
					result = (this._Mats = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Mats.CopyAssign(value);
			}
		}

		// Token: 0x1700444E RID: 17486
		// (get) Token: 0x06023143 RID: 143683 RVA: 0x00977CC3 File Offset: 0x00975EC3
		// (set) Token: 0x06023144 RID: 143684 RVA: 0x00977CD3 File Offset: 0x00975ED3
		public unsafe bool bInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700444F RID: 17487
		// (get) Token: 0x06023145 RID: 143685 RVA: 0x00977CE4 File Offset: 0x00975EE4
		// (set) Token: 0x06023146 RID: 143686 RVA: 0x00977CF4 File Offset: 0x00975EF4
		public unsafe bool bDrawDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004450 RID: 17488
		// (get) Token: 0x06023147 RID: 143687 RVA: 0x00977D05 File Offset: 0x00975F05
		// (set) Token: 0x06023148 RID: 143688 RVA: 0x00977D15 File Offset: 0x00975F15
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004451 RID: 17489
		// (get) Token: 0x06023149 RID: 143689 RVA: 0x00977D26 File Offset: 0x00975F26
		// (set) Token: 0x0602314A RID: 143690 RVA: 0x00977D36 File Offset: 0x00975F36
		public unsafe bool bEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004452 RID: 17490
		// (get) Token: 0x0602314B RID: 143691 RVA: 0x00977D47 File Offset: 0x00975F47
		// (set) Token: 0x0602314C RID: 143692 RVA: 0x00977D5B File Offset: 0x00975F5B
		public unsafe UChildActorComponent editorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004453 RID: 17491
		// (get) Token: 0x0602314D RID: 143693 RVA: 0x00977D70 File Offset: 0x00975F70
		// (set) Token: 0x0602314E RID: 143694 RVA: 0x00977D84 File Offset: 0x00975F84
		public unsafe UTextureRenderTarget2D RT_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004454 RID: 17492
		// (get) Token: 0x0602314F RID: 143695 RVA: 0x00977D99 File Offset: 0x00975F99
		// (set) Token: 0x06023150 RID: 143696 RVA: 0x00977DA9 File Offset: 0x00975FA9
		public unsafe float 弹力系数_0_1_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004455 RID: 17493
		// (get) Token: 0x06023151 RID: 143697 RVA: 0x00977DBA File Offset: 0x00975FBA
		// (set) Token: 0x06023152 RID: 143698 RVA: 0x00977DCA File Offset: 0x00975FCA
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004456 RID: 17494
		// (get) Token: 0x06023153 RID: 143699 RVA: 0x00977DDB File Offset: 0x00975FDB
		// (set) Token: 0x06023154 RID: 143700 RVA: 0x00977DEF File Offset: 0x00975FEF
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CSChain30_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004457 RID: 17495
		// (get) Token: 0x06023155 RID: 143701 RVA: 0x00977E04 File Offset: 0x00976004
		// (set) Token: 0x06023156 RID: 143702 RVA: 0x00977E18 File Offset: 0x00976018
		public unsafe FVector playerColPosOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CSChain30_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x06023157 RID: 143703 RVA: 0x00977E2D File Offset: 0x0097602D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void buildArr()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__buildArr_NativeFunctionPtr, null);
		}

		// Token: 0x06023158 RID: 143704 RVA: 0x00977E41 File Offset: 0x00976041
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__InitRT_NativeFunctionPtr, null);
		}

		// Token: 0x06023159 RID: 143705 RVA: 0x00977E55 File Offset: 0x00976055
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMats()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__InitMats_NativeFunctionPtr, null);
		}

		// Token: 0x0602315A RID: 143706 RVA: 0x00977E69 File Offset: 0x00976069
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602315B RID: 143707 RVA: 0x00977E7D File Offset: 0x0097607D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain30_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602315C RID: 143708 RVA: 0x00977E92 File Offset: 0x00976092
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602315D RID: 143709 RVA: 0x00977EA6 File Offset: 0x009760A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain30_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602315E RID: 143710 RVA: 0x00977EBC File Offset: 0x009760BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CSChain30_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CSChain30_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CSChain30_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602315F RID: 143711 RVA: 0x00977F04 File Offset: 0x00976104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CSChain30_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CSChain30_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CSChain30_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain30_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023160 RID: 143712 RVA: 0x00977F4B File Offset: 0x0097614B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023161 RID: 143713 RVA: 0x00977F60 File Offset: 0x00976160
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_CSChain30_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_CSChain30_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CSChain30_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023162 RID: 143714 RVA: 0x00977FAC File Offset: 0x009761AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_CSChain30_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_CSChain30_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_CSChain30_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain30_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023163 RID: 143715 RVA: 0x00977FF8 File Offset: 0x009761F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023164 RID: 143716 RVA: 0x009780B4 File Offset: 0x009762B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CSChain30_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023165 RID: 143717 RVA: 0x00978140 File Offset: 0x00976340
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CSChain30(int EntryPoint)
		{
			BP_CSChain30_C.__ExecuteUbergraph_BP_CSChain30_FunctionParams* ptr = stackalloc BP_CSChain30_C.__ExecuteUbergraph_BP_CSChain30_FunctionParams[(UIntPtr)1119] + 15L / (long)sizeof(BP_CSChain30_C.__ExecuteUbergraph_BP_CSChain30_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CSChain30_C.__ExecuteUbergraph_BP_CSChain30_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CSChain30_C.__ExecuteUbergraph_BP_CSChain30_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023166 RID: 143718 RVA: 0x0097818A File Offset: 0x0097638A
		protected BP_CSChain30_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011D43 RID: 73027
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUChainSimulation/BP_CSChain30.BP_CSChain30_C";

		// Token: 0x04011D44 RID: 73028
		private static IntPtr _ClassPtr;

		// Token: 0x04011D45 RID: 73029
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011D46 RID: 73030
		internal static int __PropertyOffset_0;

		// Token: 0x04011D47 RID: 73031
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011D48 RID: 73032
		internal static int __PropertyOffset_1;

		// Token: 0x04011D49 RID: 73033
		internal static int __PropertyOffset_2;

		// Token: 0x04011D4A RID: 73034
		internal static int __PropertyOffset_3;

		// Token: 0x04011D4B RID: 73035
		internal static int __PropertyOffset_4;

		// Token: 0x04011D4C RID: 73036
		internal static int __PropertyOffset_5;

		// Token: 0x04011D4D RID: 73037
		internal static int __PropertyOffset_6;

		// Token: 0x04011D4E RID: 73038
		internal static int __PropertyOffset_7;

		// Token: 0x04011D4F RID: 73039
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _Mats;

		// Token: 0x04011D50 RID: 73040
		internal static int __PropertyOffset_8;

		// Token: 0x04011D51 RID: 73041
		internal static int __PropertyOffset_9;

		// Token: 0x04011D52 RID: 73042
		internal static int __PropertyOffset_10;

		// Token: 0x04011D53 RID: 73043
		internal static int __PropertyOffset_11;

		// Token: 0x04011D54 RID: 73044
		internal static int __PropertyOffset_12;

		// Token: 0x04011D55 RID: 73045
		internal static int __PropertyOffset_13;

		// Token: 0x04011D56 RID: 73046
		internal static int __PropertyOffset_14;

		// Token: 0x04011D57 RID: 73047
		internal static int __PropertyOffset_15;

		// Token: 0x04011D58 RID: 73048
		internal static int __PropertyOffset_16;

		// Token: 0x04011D59 RID: 73049
		internal static int __PropertyOffset_17;

		// Token: 0x04011D5A RID: 73050
		private static IntPtr __buildArr_NativeFunctionPtr;

		// Token: 0x04011D5B RID: 73051
		private static IntPtr __InitRT_NativeFunctionPtr;

		// Token: 0x04011D5C RID: 73052
		private static IntPtr __InitMats_NativeFunctionPtr;

		// Token: 0x04011D5D RID: 73053
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011D5E RID: 73054
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011D5F RID: 73055
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011D60 RID: 73056
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011D61 RID: 73057
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011D62 RID: 73058
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011D63 RID: 73059
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011D64 RID: 73060
		private static IntPtr __ExecuteUbergraph_BP_CSChain30_NativeFunctionPtr;

		// Token: 0x02009C7F RID: 40063
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403256D RID: 206189
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C80 RID: 40064
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403256E RID: 206190
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C81 RID: 40065
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403256F RID: 206191
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032570 RID: 206192
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032571 RID: 206193
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032572 RID: 206194
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032573 RID: 206195
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032574 RID: 206196
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C82 RID: 40066
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032575 RID: 206197
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032576 RID: 206198
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032577 RID: 206199
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032578 RID: 206200
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C83 RID: 40067
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1104)]
		protected ref struct __ExecuteUbergraph_BP_CSChain30_FunctionParams
		{
			// Token: 0x04032579 RID: 206201
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
