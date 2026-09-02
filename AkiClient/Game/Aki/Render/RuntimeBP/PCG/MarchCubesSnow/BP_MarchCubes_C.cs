using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow
{
	// Token: 0x02003BC3 RID: 15299
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/BP_MarchCubes.BP_MarchCubes_C")]
	[UnrealStructLayout(1440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1440)]
	public class BP_MarchCubes_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602254E RID: 140622 RVA: 0x009625A8 File Offset: 0x009607A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MarchCubes_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/BP_MarchCubes.BP_MarchCubes_C");
			}
			return BP_MarchCubes_C._ClassPtr;
		}

		// Token: 0x0602254F RID: 140623 RVA: 0x009625CC File Offset: 0x009607CC
		public BP_MarchCubes_C() : this(BuiltinUtils.AllocNativeUObject(BP_MarchCubes_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022550 RID: 140624 RVA: 0x009625F4 File Offset: 0x009607F4
		[NullableContext(1)]
		public BP_MarchCubes_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MarchCubes_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700404F RID: 16463
		// (get) Token: 0x06022551 RID: 140625 RVA: 0x00962628 File Offset: 0x00960828
		// (set) Token: 0x06022552 RID: 140626 RVA: 0x00962661 File Offset: 0x00960861
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004050 RID: 16464
		// (get) Token: 0x06022553 RID: 140627 RVA: 0x00962682 File Offset: 0x00960882
		// (set) Token: 0x06022554 RID: 140628 RVA: 0x00962696 File Offset: 0x00960896
		public unsafe UBoxComponent EnterTheAttackRange
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004051 RID: 16465
		// (get) Token: 0x06022555 RID: 140629 RVA: 0x009626AB File Offset: 0x009608AB
		// (set) Token: 0x06022556 RID: 140630 RVA: 0x009626BF File Offset: 0x009608BF
		public unsafe UBoxComponent CharaEnter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004052 RID: 16466
		// (get) Token: 0x06022557 RID: 140631 RVA: 0x009626D4 File Offset: 0x009608D4
		// (set) Token: 0x06022558 RID: 140632 RVA: 0x009626E8 File Offset: 0x009608E8
		public unsafe UMarchingCubesComponent MarchingCubes
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMarchingCubesComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004053 RID: 16467
		// (get) Token: 0x06022559 RID: 140633 RVA: 0x009626FD File Offset: 0x009608FD
		// (set) Token: 0x0602255A RID: 140634 RVA: 0x00962711 File Offset: 0x00960911
		public unsafe USceneComponent DefaultSceneRoot1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MarchCubes_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004054 RID: 16468
		// (get) Token: 0x0602255B RID: 140635 RVA: 0x00962726 File Offset: 0x00960926
		// (set) Token: 0x0602255C RID: 140636 RVA: 0x00962736 File Offset: 0x00960936
		public unsafe bool IsEnter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004055 RID: 16469
		// (get) Token: 0x0602255D RID: 140637 RVA: 0x00962747 File Offset: 0x00960947
		// (set) Token: 0x0602255E RID: 140638 RVA: 0x00962757 File Offset: 0x00960957
		public unsafe bool IsGetCharacter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004056 RID: 16470
		// (get) Token: 0x0602255F RID: 140639 RVA: 0x00962768 File Offset: 0x00960968
		// (set) Token: 0x06022560 RID: 140640 RVA: 0x00962778 File Offset: 0x00960978
		public unsafe bool bHideInLowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004057 RID: 16471
		// (get) Token: 0x06022561 RID: 140641 RVA: 0x00962789 File Offset: 0x00960989
		// (set) Token: 0x06022562 RID: 140642 RVA: 0x00962799 File Offset: 0x00960999
		public unsafe int seed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004058 RID: 16472
		// (get) Token: 0x06022563 RID: 140643 RVA: 0x009627AA File Offset: 0x009609AA
		// (set) Token: 0x06022564 RID: 140644 RVA: 0x009627BA File Offset: 0x009609BA
		public unsafe float GridCellSizeInMeters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004059 RID: 16473
		// (get) Token: 0x06022565 RID: 140645 RVA: 0x009627CB File Offset: 0x009609CB
		// (set) Token: 0x06022566 RID: 140646 RVA: 0x009627DF File Offset: 0x009609DF
		public unsafe FVectorDouble WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700405A RID: 16474
		// (get) Token: 0x06022567 RID: 140647 RVA: 0x009627F4 File Offset: 0x009609F4
		// (set) Token: 0x06022568 RID: 140648 RVA: 0x00962808 File Offset: 0x00960A08
		public unsafe FVectorDouble PreWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700405B RID: 16475
		// (get) Token: 0x06022569 RID: 140649 RVA: 0x0096281D File Offset: 0x00960A1D
		// (set) Token: 0x0602256A RID: 140650 RVA: 0x0096282D File Offset: 0x00960A2D
		public unsafe int FilterStateID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700405C RID: 16476
		// (get) Token: 0x0602256B RID: 140651 RVA: 0x0096283E File Offset: 0x00960A3E
		// (set) Token: 0x0602256C RID: 140652 RVA: 0x00962852 File Offset: 0x00960A52
		public unsafe FVectorDouble LastWeaponInteractionPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MarchCubes_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x0602256D RID: 140653 RVA: 0x00962867 File Offset: 0x00960A67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602256E RID: 140654 RVA: 0x0096287B File Offset: 0x00960A7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MarchCubes_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602256F RID: 140655 RVA: 0x00962890 File Offset: 0x00960A90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MarchCubes_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MarchCubes_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022570 RID: 140656 RVA: 0x009628D8 File Offset: 0x00960AD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MarchCubes_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MarchCubes_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MarchCubes_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022571 RID: 140657 RVA: 0x00962920 File Offset: 0x00960B20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022572 RID: 140658 RVA: 0x009629DC File Offset: 0x00960BDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022573 RID: 140659 RVA: 0x00962A65 File Offset: 0x00960C65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06022574 RID: 140660 RVA: 0x00962A7C File Offset: 0x00960C7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_MarchCubes_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_MarchCubes_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022575 RID: 140661 RVA: 0x00962AE0 File Offset: 0x00960CE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022576 RID: 140662 RVA: 0x00962B9C File Offset: 0x00960D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MarchCubes_C.__BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022577 RID: 140663 RVA: 0x00962C28 File Offset: 0x00960E28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MarchCubes(int EntryPoint)
		{
			BP_MarchCubes_C.__ExecuteUbergraph_BP_MarchCubes_FunctionParams* ptr = stackalloc BP_MarchCubes_C.__ExecuteUbergraph_BP_MarchCubes_FunctionParams[(UIntPtr)1727] + 15L / (long)sizeof(BP_MarchCubes_C.__ExecuteUbergraph_BP_MarchCubes_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MarchCubes_C.__ExecuteUbergraph_BP_MarchCubes_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MarchCubes_C.__ExecuteUbergraph_BP_MarchCubes_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022578 RID: 140664 RVA: 0x00962C72 File Offset: 0x00960E72
		protected BP_MarchCubes_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040115E5 RID: 71141
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/BP_MarchCubes.BP_MarchCubes_C";

		// Token: 0x040115E6 RID: 71142
		private static IntPtr _ClassPtr;

		// Token: 0x040115E7 RID: 71143
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040115E8 RID: 71144
		internal static int __PropertyOffset_0;

		// Token: 0x040115E9 RID: 71145
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040115EA RID: 71146
		internal static int __PropertyOffset_1;

		// Token: 0x040115EB RID: 71147
		internal static int __PropertyOffset_2;

		// Token: 0x040115EC RID: 71148
		internal static int __PropertyOffset_3;

		// Token: 0x040115ED RID: 71149
		internal static int __PropertyOffset_4;

		// Token: 0x040115EE RID: 71150
		internal static int __PropertyOffset_5;

		// Token: 0x040115EF RID: 71151
		internal static int __PropertyOffset_6;

		// Token: 0x040115F0 RID: 71152
		internal static int __PropertyOffset_7;

		// Token: 0x040115F1 RID: 71153
		internal static int __PropertyOffset_8;

		// Token: 0x040115F2 RID: 71154
		internal static int __PropertyOffset_9;

		// Token: 0x040115F3 RID: 71155
		internal static int __PropertyOffset_10;

		// Token: 0x040115F4 RID: 71156
		internal static int __PropertyOffset_11;

		// Token: 0x040115F5 RID: 71157
		internal static int __PropertyOffset_12;

		// Token: 0x040115F6 RID: 71158
		internal static int __PropertyOffset_13;

		// Token: 0x040115F7 RID: 71159
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040115F8 RID: 71160
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040115F9 RID: 71161
		private static IntPtr __BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040115FA RID: 71162
		private static IntPtr __BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040115FB RID: 71163
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x040115FC RID: 71164
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040115FD RID: 71165
		private static IntPtr __BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040115FE RID: 71166
		private static IntPtr __BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040115FF RID: 71167
		private static IntPtr __ExecuteUbergraph_BP_MarchCubes_NativeFunctionPtr;

		// Token: 0x02009BC8 RID: 39880
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323FC RID: 205820
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BC9 RID: 39881
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040323FD RID: 205821
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040323FE RID: 205822
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040323FF RID: 205823
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032400 RID: 205824
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032401 RID: 205825
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032402 RID: 205826
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009BCA RID: 39882
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__marchCubes_CharaEnter_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032403 RID: 205827
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032404 RID: 205828
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032405 RID: 205829
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032406 RID: 205830
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009BCB RID: 39883
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032407 RID: 205831
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032408 RID: 205832
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032409 RID: 205833
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009BCC RID: 39884
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403240A RID: 205834
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403240B RID: 205835
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403240C RID: 205836
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403240D RID: 205837
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403240E RID: 205838
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403240F RID: 205839
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009BCD RID: 39885
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_MarchCubes_EnterTheAttackRange_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032410 RID: 205840
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032411 RID: 205841
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032412 RID: 205842
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032413 RID: 205843
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009BCE RID: 39886
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1712)]
		protected ref struct __ExecuteUbergraph_BP_MarchCubes_FunctionParams
		{
			// Token: 0x04032414 RID: 205844
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
