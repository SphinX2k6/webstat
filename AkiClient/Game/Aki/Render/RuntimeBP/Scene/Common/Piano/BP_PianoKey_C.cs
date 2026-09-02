using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.Piano
{
	// Token: 0x02003AE4 RID: 15076
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoKey.BP_PianoKey_C")]
	[UnrealStructLayout(1256, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1253)]
	public class BP_PianoKey_C : AActor, IUnrealUObject, IUnrealObject, IBulletHitActorInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06020544 RID: 132420 RVA: 0x00928D03 File Offset: 0x00926F03
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PianoKey_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoKey.BP_PianoKey_C");
			}
			return BP_PianoKey_C._ClassPtr;
		}

		// Token: 0x06020545 RID: 132421 RVA: 0x00928D27 File Offset: 0x00926F27
		int IBulletHitActorInterface.InterfaceOffset()
		{
			return BP_PianoKey_C.__InterfaceOffset_IBulletHitActorInterface;
		}

		// Token: 0x06020546 RID: 132422 RVA: 0x00928D30 File Offset: 0x00926F30
		public BP_PianoKey_C() : this(BuiltinUtils.AllocNativeUObject(BP_PianoKey_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020547 RID: 132423 RVA: 0x00928D58 File Offset: 0x00926F58
		[NullableContext(1)]
		public BP_PianoKey_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PianoKey_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003512 RID: 13586
		// (get) Token: 0x06020548 RID: 132424 RVA: 0x00928D8C File Offset: 0x00926F8C
		// (set) Token: 0x06020549 RID: 132425 RVA: 0x00928DC5 File Offset: 0x00926FC5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003513 RID: 13587
		// (get) Token: 0x0602054A RID: 132426 RVA: 0x00928DE6 File Offset: 0x00926FE6
		// (set) Token: 0x0602054B RID: 132427 RVA: 0x00928DFA File Offset: 0x00926FFA
		public unsafe USceneComponent Effect_Slot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003514 RID: 13588
		// (get) Token: 0x0602054C RID: 132428 RVA: 0x00928E0F File Offset: 0x0092700F
		// (set) Token: 0x0602054D RID: 132429 RVA: 0x00928E23 File Offset: 0x00927023
		public unsafe UBoxComponent BoxCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003515 RID: 13589
		// (get) Token: 0x0602054E RID: 132430 RVA: 0x00928E38 File Offset: 0x00927038
		// (set) Token: 0x0602054F RID: 132431 RVA: 0x00928E4C File Offset: 0x0092704C
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003516 RID: 13590
		// (get) Token: 0x06020550 RID: 132432 RVA: 0x00928E61 File Offset: 0x00927061
		// (set) Token: 0x06020551 RID: 132433 RVA: 0x00928E75 File Offset: 0x00927075
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003517 RID: 13591
		// (get) Token: 0x06020552 RID: 132434 RVA: 0x00928E8A File Offset: 0x0092708A
		// (set) Token: 0x06020553 RID: 132435 RVA: 0x00928E9E File Offset: 0x0092709E
		public unsafe FLinearColor PressKey_Material_Emission_Color_9732C74A4AA26579682CB0A93FCAF28C
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003518 RID: 13592
		// (get) Token: 0x06020554 RID: 132436 RVA: 0x00928EB3 File Offset: 0x009270B3
		// (set) Token: 0x06020555 RID: 132437 RVA: 0x00928EC7 File Offset: 0x009270C7
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> PressKey_Material__Direction_9732C74A4AA26579682CB0A93FCAF28C
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003519 RID: 13593
		// (get) Token: 0x06020556 RID: 132438 RVA: 0x00928EDC File Offset: 0x009270DC
		// (set) Token: 0x06020557 RID: 132439 RVA: 0x00928EF0 File Offset: 0x009270F0
		public unsafe UTimelineComponent PressKey_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700351A RID: 13594
		// (get) Token: 0x06020558 RID: 132440 RVA: 0x00928F05 File Offset: 0x00927105
		// (set) Token: 0x06020559 RID: 132441 RVA: 0x00928F15 File Offset: 0x00927115
		public unsafe float PressKey_Animation_PressAlpha_6091365E42EA7766A18EF8A4A338DA23
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700351B RID: 13595
		// (get) Token: 0x0602055A RID: 132442 RVA: 0x00928F26 File Offset: 0x00927126
		// (set) Token: 0x0602055B RID: 132443 RVA: 0x00928F3A File Offset: 0x0092713A
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> PressKey_Animation__Direction_6091365E42EA7766A18EF8A4A338DA23
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700351C RID: 13596
		// (get) Token: 0x0602055C RID: 132444 RVA: 0x00928F4F File Offset: 0x0092714F
		// (set) Token: 0x0602055D RID: 132445 RVA: 0x00928F63 File Offset: 0x00927163
		public unsafe UTimelineComponent PressKey_Animation
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700351D RID: 13597
		// (get) Token: 0x0602055E RID: 132446 RVA: 0x00928F78 File Offset: 0x00927178
		// (set) Token: 0x0602055F RID: 132447 RVA: 0x00928F8C File Offset: 0x0092718C
		[Nullable(0)]
		public unsafe TEnumAsByte<PianoKeyEnum> PianoKeyTyoe
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700351E RID: 13598
		// (get) Token: 0x06020560 RID: 132448 RVA: 0x00928FA4 File Offset: 0x009271A4
		// (set) Token: 0x06020561 RID: 132449 RVA: 0x00928FDD File Offset: 0x009271DD
		[Nullable(1)]
		public EventDispatcher EventDispatcher
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				EventDispatcher result;
				if ((result = this._EventDispatcher) == null)
				{
					result = (this._EventDispatcher = new EventDispatcher(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_12, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_12, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700351F RID: 13599
		// (get) Token: 0x06020562 RID: 132450 RVA: 0x00928FFE File Offset: 0x009271FE
		// (set) Token: 0x06020563 RID: 132451 RVA: 0x0092900E File Offset: 0x0092720E
		public unsafe bool IsPressed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003520 RID: 13600
		// (get) Token: 0x06020564 RID: 132452 RVA: 0x0092901F File Offset: 0x0092721F
		// (set) Token: 0x06020565 RID: 132453 RVA: 0x00929033 File Offset: 0x00927233
		public unsafe UStaticMesh KeyMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003521 RID: 13601
		// (get) Token: 0x06020566 RID: 132454 RVA: 0x00929048 File Offset: 0x00927248
		// (set) Token: 0x06020567 RID: 132455 RVA: 0x0092905C File Offset: 0x0092725C
		public unsafe FVector CollisionExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003522 RID: 13602
		// (get) Token: 0x06020568 RID: 132456 RVA: 0x00929071 File Offset: 0x00927271
		// (set) Token: 0x06020569 RID: 132457 RVA: 0x00929085 File Offset: 0x00927285
		public unsafe FVector CollisionLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003523 RID: 13603
		// (get) Token: 0x0602056A RID: 132458 RVA: 0x0092909A File Offset: 0x0092729A
		// (set) Token: 0x0602056B RID: 132459 RVA: 0x009290AE File Offset: 0x009272AE
		public unsafe FRotator CollisionRotator
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17003524 RID: 13604
		// (get) Token: 0x0602056C RID: 132460 RVA: 0x009290C3 File Offset: 0x009272C3
		// (set) Token: 0x0602056D RID: 132461 RVA: 0x009290D3 File Offset: 0x009272D3
		public unsafe bool IsPressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003525 RID: 13605
		// (get) Token: 0x0602056E RID: 132462 RVA: 0x009290E4 File Offset: 0x009272E4
		// (set) Token: 0x0602056F RID: 132463 RVA: 0x009290F8 File Offset: 0x009272F8
		public unsafe FRotator CurrentRotator
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003526 RID: 13606
		// (get) Token: 0x06020570 RID: 132464 RVA: 0x0092910D File Offset: 0x0092730D
		// (set) Token: 0x06020571 RID: 132465 RVA: 0x00929121 File Offset: 0x00927321
		public unsafe UObject PressedEffectDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PianoKey_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003527 RID: 13607
		// (get) Token: 0x06020572 RID: 132466 RVA: 0x00929138 File Offset: 0x00927338
		// (set) Token: 0x06020573 RID: 132467 RVA: 0x00929171 File Offset: 0x00927371
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> MaterialInstanceArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._MaterialInstanceArray) == null)
				{
					result = (this._MaterialInstanceArray = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_21, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MaterialInstanceArray.CopyAssign(value);
			}
		}

		// Token: 0x17003528 RID: 13608
		// (get) Token: 0x06020574 RID: 132468 RVA: 0x0092917F File Offset: 0x0092737F
		// (set) Token: 0x06020575 RID: 132469 RVA: 0x00929193 File Offset: 0x00927393
		public unsafe FVector EffectSlotLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003529 RID: 13609
		// (get) Token: 0x06020576 RID: 132470 RVA: 0x009291A8 File Offset: 0x009273A8
		// (set) Token: 0x06020577 RID: 132471 RVA: 0x009291B8 File Offset: 0x009273B8
		public unsafe bool PressByBullet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PianoKey_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020578 RID: 132472 RVA: 0x009291C9 File Offset: 0x009273C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Tick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__Tick_NativeFunctionPtr, null);
		}

		// Token: 0x06020579 RID: 132473 RVA: 0x009291DD File Offset: 0x009273DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602057A RID: 132474 RVA: 0x009291F1 File Offset: 0x009273F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PianoKey_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602057B RID: 132475 RVA: 0x00929206 File Offset: 0x00927406
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PressKey_Animation__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__PressKey_Animation__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602057C RID: 132476 RVA: 0x0092921A File Offset: 0x0092741A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PressKey_Animation__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__PressKey_Animation__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602057D RID: 132477 RVA: 0x0092922E File Offset: 0x0092742E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PressKey_Material__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__PressKey_Material__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602057E RID: 132478 RVA: 0x00929242 File Offset: 0x00927442
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PressKey_Material__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__PressKey_Material__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602057F RID: 132479 RVA: 0x00929256 File Offset: 0x00927456
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020580 RID: 132480 RVA: 0x0092926A File Offset: 0x0092746A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PianoKey_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020581 RID: 132481 RVA: 0x00929280 File Offset: 0x00927480
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020582 RID: 132482 RVA: 0x0092933C File Offset: 0x0092753C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020583 RID: 132483 RVA: 0x009293C5 File Offset: 0x009275C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x06020584 RID: 132484 RVA: 0x009293DC File Offset: 0x009275DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBulletHit(int BulletEntityId, in FVectorDouble HitPoint)
		{
			BP_PianoKey_C.__OnBulletHit_FunctionParams* ptr = stackalloc BP_PianoKey_C.__OnBulletHit_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_PianoKey_C.__OnBulletHit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PianoKey_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletEntityId = BulletEntityId;
			ptr->HitPoint = HitPoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PianoKey_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020585 RID: 132485 RVA: 0x00929430 File Offset: 0x00927630
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnBulletHit_Implementation(int BulletEntityId, in FVectorDouble HitPoint)
		{
			BP_PianoKey_C.__OnBulletHit_FunctionParams* ptr = stackalloc BP_PianoKey_C.__OnBulletHit_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_PianoKey_C.__OnBulletHit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PianoKey_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletEntityId = BulletEntityId;
			ptr->HitPoint = HitPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PianoKey_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020586 RID: 132486 RVA: 0x00929484 File Offset: 0x00927684
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PianoKey(int EntryPoint)
		{
			BP_PianoKey_C.__ExecuteUbergraph_BP_PianoKey_FunctionParams* ptr = stackalloc BP_PianoKey_C.__ExecuteUbergraph_BP_PianoKey_FunctionParams[(UIntPtr)607] + 15L / (long)sizeof(BP_PianoKey_C.__ExecuteUbergraph_BP_PianoKey_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PianoKey_C.__ExecuteUbergraph_BP_PianoKey_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PianoKey_C.__ExecuteUbergraph_BP_PianoKey_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020587 RID: 132487 RVA: 0x009294CE File Offset: 0x009276CE
		protected BP_PianoKey_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010228 RID: 66088
		internal static int __InterfaceOffset_IBulletHitActorInterface;

		// Token: 0x04010229 RID: 66089
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/Piano/BP_PianoKey.BP_PianoKey_C";

		// Token: 0x0401022A RID: 66090
		private static IntPtr _ClassPtr;

		// Token: 0x0401022B RID: 66091
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401022C RID: 66092
		public static IntPtr __EventDispatcher__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401022D RID: 66093
		internal static int __PropertyOffset_0;

		// Token: 0x0401022E RID: 66094
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401022F RID: 66095
		internal static int __PropertyOffset_1;

		// Token: 0x04010230 RID: 66096
		internal static int __PropertyOffset_2;

		// Token: 0x04010231 RID: 66097
		internal static int __PropertyOffset_3;

		// Token: 0x04010232 RID: 66098
		internal static int __PropertyOffset_4;

		// Token: 0x04010233 RID: 66099
		internal static int __PropertyOffset_5;

		// Token: 0x04010234 RID: 66100
		internal static int __PropertyOffset_6;

		// Token: 0x04010235 RID: 66101
		internal static int __PropertyOffset_7;

		// Token: 0x04010236 RID: 66102
		internal static int __PropertyOffset_8;

		// Token: 0x04010237 RID: 66103
		internal static int __PropertyOffset_9;

		// Token: 0x04010238 RID: 66104
		internal static int __PropertyOffset_10;

		// Token: 0x04010239 RID: 66105
		internal static int __PropertyOffset_11;

		// Token: 0x0401023A RID: 66106
		internal static int __PropertyOffset_12;

		// Token: 0x0401023B RID: 66107
		private EventDispatcher _EventDispatcher;

		// Token: 0x0401023C RID: 66108
		internal static int __PropertyOffset_13;

		// Token: 0x0401023D RID: 66109
		internal static int __PropertyOffset_14;

		// Token: 0x0401023E RID: 66110
		internal static int __PropertyOffset_15;

		// Token: 0x0401023F RID: 66111
		internal static int __PropertyOffset_16;

		// Token: 0x04010240 RID: 66112
		internal static int __PropertyOffset_17;

		// Token: 0x04010241 RID: 66113
		internal static int __PropertyOffset_18;

		// Token: 0x04010242 RID: 66114
		internal static int __PropertyOffset_19;

		// Token: 0x04010243 RID: 66115
		internal static int __PropertyOffset_20;

		// Token: 0x04010244 RID: 66116
		internal static int __PropertyOffset_21;

		// Token: 0x04010245 RID: 66117
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _MaterialInstanceArray;

		// Token: 0x04010246 RID: 66118
		internal static int __PropertyOffset_22;

		// Token: 0x04010247 RID: 66119
		internal static int __PropertyOffset_23;

		// Token: 0x04010248 RID: 66120
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04010249 RID: 66121
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401024A RID: 66122
		private static IntPtr __PressKey_Animation__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401024B RID: 66123
		private static IntPtr __PressKey_Animation__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401024C RID: 66124
		private static IntPtr __PressKey_Material__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401024D RID: 66125
		private static IntPtr __PressKey_Material__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401024E RID: 66126
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401024F RID: 66127
		private static IntPtr __BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010250 RID: 66128
		private static IntPtr __BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010251 RID: 66129
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010252 RID: 66130
		private static IntPtr __OnBulletHit_NativeFunctionPtr;

		// Token: 0x04010253 RID: 66131
		private static IntPtr __ExecuteUbergraph_BP_PianoKey_NativeFunctionPtr;

		// Token: 0x02009996 RID: 39318
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403201D RID: 204829
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403201E RID: 204830
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403201F RID: 204831
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032020 RID: 204832
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032021 RID: 204833
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032022 RID: 204834
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009997 RID: 39319
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_PianoKeyBase_BoxCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032023 RID: 204835
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032024 RID: 204836
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032025 RID: 204837
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032026 RID: 204838
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009998 RID: 39320
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnBulletHit_FunctionParams
		{
			// Token: 0x04032027 RID: 204839
			[FieldOffset(0)]
			public int BulletEntityId;

			// Token: 0x04032028 RID: 204840
			[FieldOffset(8)]
			public FVectorDouble HitPoint;
		}

		// Token: 0x02009999 RID: 39321
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 592)]
		protected ref struct __ExecuteUbergraph_BP_PianoKey_FunctionParams
		{
			// Token: 0x04032029 RID: 204841
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
