using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A46 RID: 14918
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/BP_StateMachineEffectBase.BP_StateMachineEffectBase_C")]
	[UnrealStructLayout(2400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2400)]
	public class BP_StateMachineEffectBase_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EE33 RID: 126515 RVA: 0x0090120C File Offset: 0x008FF40C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StateMachineEffectBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/StateMachineEffect/BP_StateMachineEffectBase.BP_StateMachineEffectBase_C");
			}
			return BP_StateMachineEffectBase_C._ClassPtr;
		}

		// Token: 0x0601EE34 RID: 126516 RVA: 0x00901230 File Offset: 0x008FF430
		public BP_StateMachineEffectBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_StateMachineEffectBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EE35 RID: 126517 RVA: 0x00901258 File Offset: 0x008FF458
		public BP_StateMachineEffectBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StateMachineEffectBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D01 RID: 11521
		// (get) Token: 0x0601EE36 RID: 126518 RVA: 0x0090128C File Offset: 0x008FF48C
		// (set) Token: 0x0601EE37 RID: 126519 RVA: 0x009012C5 File Offset: 0x008FF4C5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D02 RID: 11522
		// (get) Token: 0x0601EE38 RID: 126520 RVA: 0x009012E6 File Offset: 0x008FF4E6
		// (set) Token: 0x0601EE39 RID: 126521 RVA: 0x009012FA File Offset: 0x008FF4FA
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StateMachineEffectBase_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StateMachineEffectBase_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002D03 RID: 11523
		// (get) Token: 0x0601EE3A RID: 126522 RVA: 0x0090130F File Offset: 0x008FF50F
		// (set) Token: 0x0601EE3B RID: 126523 RVA: 0x0090131F File Offset: 0x008FF51F
		public unsafe bool IsEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D04 RID: 11524
		// (get) Token: 0x0601EE3C RID: 126524 RVA: 0x00901330 File Offset: 0x008FF530
		// (set) Token: 0x0601EE3D RID: 126525 RVA: 0x00901344 File Offset: 0x008FF544
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectState> CurrentState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002D05 RID: 11525
		// (get) Token: 0x0601EE3E RID: 126526 RVA: 0x00901359 File Offset: 0x008FF559
		// (set) Token: 0x0601EE3F RID: 126527 RVA: 0x00901369 File Offset: 0x008FF569
		public unsafe bool IsInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D06 RID: 11526
		// (get) Token: 0x0601EE40 RID: 126528 RVA: 0x0090137A File Offset: 0x008FF57A
		// (set) Token: 0x0601EE41 RID: 126529 RVA: 0x0090138E File Offset: 0x008FF58E
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectState> TargetState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002D07 RID: 11527
		// (get) Token: 0x0601EE42 RID: 126530 RVA: 0x009013A3 File Offset: 0x008FF5A3
		// (set) Token: 0x0601EE43 RID: 126531 RVA: 0x009013B3 File Offset: 0x008FF5B3
		public unsafe bool IsInTransition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D08 RID: 11528
		// (get) Token: 0x0601EE44 RID: 126532 RVA: 0x009013C4 File Offset: 0x008FF5C4
		// (set) Token: 0x0601EE45 RID: 126533 RVA: 0x009013D8 File Offset: 0x008FF5D8
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectState> TransitionTargetState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_7);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002D09 RID: 11529
		// (get) Token: 0x0601EE46 RID: 126534 RVA: 0x009013ED File Offset: 0x008FF5ED
		// (set) Token: 0x0601EE47 RID: 126535 RVA: 0x009013FD File Offset: 0x008FF5FD
		public unsafe float TransitionCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002D0A RID: 11530
		// (get) Token: 0x0601EE48 RID: 126536 RVA: 0x0090140E File Offset: 0x008FF60E
		// (set) Token: 0x0601EE49 RID: 126537 RVA: 0x0090141E File Offset: 0x008FF61E
		public unsafe float TransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002D0B RID: 11531
		// (get) Token: 0x0601EE4A RID: 126538 RVA: 0x00901430 File Offset: 0x008FF630
		// (set) Token: 0x0601EE4B RID: 126539 RVA: 0x00901469 File Offset: 0x008FF669
		public TMap<FName, float> TransitionFloatStartMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._TransitionFloatStartMap) == null)
				{
					result = (this._TransitionFloatStartMap = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.TransitionFloatStartMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D0C RID: 11532
		// (get) Token: 0x0601EE4C RID: 126540 RVA: 0x00901478 File Offset: 0x008FF678
		// (set) Token: 0x0601EE4D RID: 126541 RVA: 0x009014B1 File Offset: 0x008FF6B1
		public TMap<FName, float> TransitionFloatEndMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._TransitionFloatEndMap) == null)
				{
					result = (this._TransitionFloatEndMap = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				this.TransitionFloatEndMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D0D RID: 11533
		// (get) Token: 0x0601EE4E RID: 126542 RVA: 0x009014C0 File Offset: 0x008FF6C0
		// (set) Token: 0x0601EE4F RID: 126543 RVA: 0x009014F9 File Offset: 0x008FF6F9
		public TMap<FName, FLinearColor> TransitionLinearColorStartMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._TransitionLinearColorStartMap) == null)
				{
					result = (this._TransitionLinearColorStartMap = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.TransitionLinearColorStartMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D0E RID: 11534
		// (get) Token: 0x0601EE50 RID: 126544 RVA: 0x00901508 File Offset: 0x008FF708
		// (set) Token: 0x0601EE51 RID: 126545 RVA: 0x00901541 File Offset: 0x008FF741
		public TMap<FName, FLinearColor> TransitionLinearColorEndMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._TransitionLinearColorEndMap) == null)
				{
					result = (this._TransitionLinearColorEndMap = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.TransitionLinearColorEndMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D0F RID: 11535
		// (get) Token: 0x0601EE52 RID: 126546 RVA: 0x0090154F File Offset: 0x008FF74F
		// (set) Token: 0x0601EE53 RID: 126547 RVA: 0x0090155F File Offset: 0x008FF75F
		public unsafe bool IsInState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D10 RID: 11536
		// (get) Token: 0x0601EE54 RID: 126548 RVA: 0x00901570 File Offset: 0x008FF770
		// (set) Token: 0x0601EE55 RID: 126549 RVA: 0x00901580 File Offset: 0x008FF780
		public unsafe bool IsStatePreLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D11 RID: 11537
		// (get) Token: 0x0601EE56 RID: 126550 RVA: 0x00901591 File Offset: 0x008FF791
		// (set) Token: 0x0601EE57 RID: 126551 RVA: 0x009015A1 File Offset: 0x008FF7A1
		public unsafe float StateCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002D12 RID: 11538
		// (get) Token: 0x0601EE58 RID: 126552 RVA: 0x009015B2 File Offset: 0x008FF7B2
		// (set) Token: 0x0601EE59 RID: 126553 RVA: 0x009015C6 File Offset: 0x008FF7C6
		[Nullable(2)]
		public unsafe PD_StateMachineEffect_C Data
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_StateMachineEffect_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StateMachineEffectBase_C.__PropertyOffset_17);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StateMachineEffectBase_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17002D13 RID: 11539
		// (get) Token: 0x0601EE5A RID: 126554 RVA: 0x009015DC File Offset: 0x008FF7DC
		// (set) Token: 0x0601EE5B RID: 126555 RVA: 0x00901615 File Offset: 0x008FF815
		public TArray<UStaticMeshComponent> StaticMeshComponents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._StaticMeshComponents) == null)
				{
					result = (this._StaticMeshComponents = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				this.StaticMeshComponents.CopyAssign(value);
			}
		}

		// Token: 0x17002D14 RID: 11540
		// (get) Token: 0x0601EE5C RID: 126556 RVA: 0x00901624 File Offset: 0x008FF824
		// (set) Token: 0x0601EE5D RID: 126557 RVA: 0x0090165D File Offset: 0x008FF85D
		public TArray<UMaterialInstanceDynamic> StaticMeshDMIs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._StaticMeshDMIs) == null)
				{
					result = (this._StaticMeshDMIs = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.StaticMeshDMIs.CopyAssign(value);
			}
		}

		// Token: 0x17002D15 RID: 11541
		// (get) Token: 0x0601EE5E RID: 126558 RVA: 0x0090166C File Offset: 0x008FF86C
		// (set) Token: 0x0601EE5F RID: 126559 RVA: 0x009016A5 File Offset: 0x008FF8A5
		public SEffectStateInfo CurrentStateInfo
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateInfo result;
				if ((result = this._CurrentStateInfo) == null)
				{
					result = (this._CurrentStateInfo = new SEffectStateInfo(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateInfo.StaticStruct(), base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D16 RID: 11542
		// (get) Token: 0x0601EE60 RID: 126560 RVA: 0x009016C6 File Offset: 0x008FF8C6
		// (set) Token: 0x0601EE61 RID: 126561 RVA: 0x009016D6 File Offset: 0x008FF8D6
		public unsafe bool IsFirstTickInfo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D17 RID: 11543
		// (get) Token: 0x0601EE62 RID: 126562 RVA: 0x009016E8 File Offset: 0x008FF8E8
		// (set) Token: 0x0601EE63 RID: 126563 RVA: 0x00901721 File Offset: 0x008FF921
		public TMap<FName, float> CurrentFloatMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._CurrentFloatMap) == null)
				{
					result = (this._CurrentFloatMap = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				this.CurrentFloatMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D18 RID: 11544
		// (get) Token: 0x0601EE64 RID: 126564 RVA: 0x00901730 File Offset: 0x008FF930
		// (set) Token: 0x0601EE65 RID: 126565 RVA: 0x00901769 File Offset: 0x008FF969
		public TMap<FName, FLinearColor> CurrentLinearColorMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._CurrentLinearColorMap) == null)
				{
					result = (this._CurrentLinearColorMap = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				this.CurrentLinearColorMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D19 RID: 11545
		// (get) Token: 0x0601EE66 RID: 126566 RVA: 0x00901777 File Offset: 0x008FF977
		// (set) Token: 0x0601EE67 RID: 126567 RVA: 0x0090178B File Offset: 0x008FF98B
		[Nullable(0)]
		public unsafe TEnumAsByte<EEffectState> InitState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_24);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002D1A RID: 11546
		// (get) Token: 0x0601EE68 RID: 126568 RVA: 0x009017A0 File Offset: 0x008FF9A0
		// (set) Token: 0x0601EE69 RID: 126569 RVA: 0x009017D9 File Offset: 0x008FF9D9
		public TArray<UNiagaraComponent> NiagaraComponents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UNiagaraComponent> result;
				if ((result = this._NiagaraComponents) == null)
				{
					result = (this._NiagaraComponents = new TArray<UNiagaraComponent>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				this.NiagaraComponents.CopyAssign(value);
			}
		}

		// Token: 0x17002D1B RID: 11547
		// (get) Token: 0x0601EE6A RID: 126570 RVA: 0x009017E8 File Offset: 0x008FF9E8
		// (set) Token: 0x0601EE6B RID: 126571 RVA: 0x00901821 File Offset: 0x008FFA21
		public TMap<int, STransitionFloatIndexGroup> TransitionIndexFloatEndMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, STransitionFloatIndexGroup> result;
				if ((result = this._TransitionIndexFloatEndMap) == null)
				{
					result = (this._TransitionIndexFloatEndMap = new TMap<int, STransitionFloatIndexGroup>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				this.TransitionIndexFloatEndMap.CopyAssign(value);
			}
		}

		// Token: 0x17002D1C RID: 11548
		// (get) Token: 0x0601EE6C RID: 126572 RVA: 0x00901830 File Offset: 0x008FFA30
		// (set) Token: 0x0601EE6D RID: 126573 RVA: 0x00901869 File Offset: 0x008FFA69
		public TMap<int, STransitionLinearColorIndexGroup> TransitionIndexLinearColorEndMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, STransitionLinearColorIndexGroup> result;
				if ((result = this._TransitionIndexLinearColorEndMap) == null)
				{
					result = (this._TransitionIndexLinearColorEndMap = new TMap<int, STransitionLinearColorIndexGroup>(base.NativePtr + (IntPtr)BP_StateMachineEffectBase_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				this.TransitionIndexLinearColorEndMap.CopyAssign(value);
			}
		}

		// Token: 0x0601EE6E RID: 126574 RVA: 0x00901878 File Offset: 0x008FFA78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetState(EEffectState TargetState)
		{
			BP_StateMachineEffectBase_C.__SetState_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__SetState_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__SetState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__SetState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TargetState = TargetState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__SetState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE6F RID: 126575 RVA: 0x009018C3 File Offset: 0x008FFAC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG重初始化()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__DEBUG重初始化_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE70 RID: 126576 RVA: 0x009018D7 File Offset: 0x008FFAD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG进入状态5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__DEBUG进入状态5_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE71 RID: 126577 RVA: 0x009018EB File Offset: 0x008FFAEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG进入状态4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__DEBUG进入状态4_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE72 RID: 126578 RVA: 0x009018FF File Offset: 0x008FFAFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG进入状态3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__DEBUG进入状态3_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE73 RID: 126579 RVA: 0x00901913 File Offset: 0x008FFB13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG进入状态2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__DEBUG进入状态2_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE74 RID: 126580 RVA: 0x00901927 File Offset: 0x008FFB27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DEBUG进入状态1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__DEBUG进入状态1_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE75 RID: 126581 RVA: 0x0090193C File Offset: 0x008FFB3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CreateTransitionState(EEffectState TargetState)
		{
			BP_StateMachineEffectBase_C.__CreateTransitionState_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__CreateTransitionState_FunctionParams[(UIntPtr)4135] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__CreateTransitionState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__CreateTransitionState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TargetState = TargetState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__CreateTransitionState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE76 RID: 126582 RVA: 0x0090198C File Offset: 0x008FFB8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParameters(FName Name, bool IsFloat, float FloatValue, bool IsLinearColor, FLinearColor LinearColorValue, int Index)
		{
			BP_StateMachineEffectBase_C.__UpdateParameters_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__UpdateParameters_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__UpdateParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__UpdateParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			ptr->IsFloat = IsFloat;
			ptr->FloatValue = FloatValue;
			ptr->IsLinearColor = IsLinearColor;
			ptr->LinearColorValue = LinearColorValue;
			ptr->Index = Index;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__UpdateParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE77 RID: 126583 RVA: 0x009019FB File Offset: 0x008FFBFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLoopState()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__UpdateLoopState_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE78 RID: 126584 RVA: 0x00901A0F File Offset: 0x008FFC0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePreLoopState()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__UpdatePreLoopState_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE79 RID: 126585 RVA: 0x00901A23 File Offset: 0x008FFC23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Transition_State()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__Update_Transition_State_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE7A RID: 126586 RVA: 0x00901A37 File Offset: 0x008FFC37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE7B RID: 126587 RVA: 0x00901A4C File Offset: 0x008FFC4C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayEffectState(PD_StateMachineEffect_C InputData, EEffectState TargetState)
		{
			BP_StateMachineEffectBase_C.__PlayEffectState_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__PlayEffectState_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__PlayEffectState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__PlayEffectState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InputData = ((InputData != null) ? InputData.NativePtr : IntPtr.Zero);
			ptr->TargetState = TargetState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__PlayEffectState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE7C RID: 126588 RVA: 0x00901AAD File Offset: 0x008FFCAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Tick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__Tick_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE7D RID: 126589 RVA: 0x00901AC4 File Offset: 0x008FFCC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Init(EEffectState TargetState)
		{
			BP_StateMachineEffectBase_C.__Init_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__Init_FunctionParams[(UIntPtr)927] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__Init_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__Init_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TargetState = TargetState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__Init_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE7E RID: 126590 RVA: 0x00901B12 File Offset: 0x008FFD12
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE7F RID: 126591 RVA: 0x00901B26 File Offset: 0x008FFD26
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE80 RID: 126592 RVA: 0x00901B3C File Offset: 0x008FFD3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_StateMachineEffectBase_C.__EditorTick_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE81 RID: 126593 RVA: 0x00901B84 File Offset: 0x008FFD84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_StateMachineEffectBase_C.__EditorTick_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EE82 RID: 126594 RVA: 0x00901BCB File Offset: 0x008FFDCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EditorInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__EditorInit_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE83 RID: 126595 RVA: 0x00901BDF File Offset: 0x008FFDDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EditorInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__EditorInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE84 RID: 126596 RVA: 0x00901BF4 File Offset: 0x008FFDF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_StateMachineEffectBase_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EE85 RID: 126597 RVA: 0x00901C3C File Offset: 0x008FFE3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_StateMachineEffectBase_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EE86 RID: 126598 RVA: 0x00901C83 File Offset: 0x008FFE83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EE87 RID: 126599 RVA: 0x00901C97 File Offset: 0x008FFE97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EE88 RID: 126600 RVA: 0x00901CAC File Offset: 0x008FFEAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_StateMachineEffectBase(int EntryPoint)
		{
			BP_StateMachineEffectBase_C.__ExecuteUbergraph_BP_StateMachineEffectBase_FunctionParams* ptr = stackalloc BP_StateMachineEffectBase_C.__ExecuteUbergraph_BP_StateMachineEffectBase_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_StateMachineEffectBase_C.__ExecuteUbergraph_BP_StateMachineEffectBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_StateMachineEffectBase_C.__ExecuteUbergraph_BP_StateMachineEffectBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_StateMachineEffectBase_C.__ExecuteUbergraph_BP_StateMachineEffectBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EE89 RID: 126601 RVA: 0x00901CF3 File Offset: 0x008FFEF3
		protected BP_StateMachineEffectBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F42C RID: 62508
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/BP_StateMachineEffectBase.BP_StateMachineEffectBase_C";

		// Token: 0x0400F42D RID: 62509
		private static IntPtr _ClassPtr;

		// Token: 0x0400F42E RID: 62510
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F42F RID: 62511
		internal static int __PropertyOffset_0;

		// Token: 0x0400F430 RID: 62512
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F431 RID: 62513
		internal static int __PropertyOffset_1;

		// Token: 0x0400F432 RID: 62514
		internal static int __PropertyOffset_2;

		// Token: 0x0400F433 RID: 62515
		internal static int __PropertyOffset_3;

		// Token: 0x0400F434 RID: 62516
		internal static int __PropertyOffset_4;

		// Token: 0x0400F435 RID: 62517
		internal static int __PropertyOffset_5;

		// Token: 0x0400F436 RID: 62518
		internal static int __PropertyOffset_6;

		// Token: 0x0400F437 RID: 62519
		internal static int __PropertyOffset_7;

		// Token: 0x0400F438 RID: 62520
		internal static int __PropertyOffset_8;

		// Token: 0x0400F439 RID: 62521
		internal static int __PropertyOffset_9;

		// Token: 0x0400F43A RID: 62522
		internal static int __PropertyOffset_10;

		// Token: 0x0400F43B RID: 62523
		[Nullable(2)]
		private TMap<FName, float> _TransitionFloatStartMap;

		// Token: 0x0400F43C RID: 62524
		internal static int __PropertyOffset_11;

		// Token: 0x0400F43D RID: 62525
		[Nullable(2)]
		private TMap<FName, float> _TransitionFloatEndMap;

		// Token: 0x0400F43E RID: 62526
		internal static int __PropertyOffset_12;

		// Token: 0x0400F43F RID: 62527
		[Nullable(2)]
		private TMap<FName, FLinearColor> _TransitionLinearColorStartMap;

		// Token: 0x0400F440 RID: 62528
		internal static int __PropertyOffset_13;

		// Token: 0x0400F441 RID: 62529
		[Nullable(2)]
		private TMap<FName, FLinearColor> _TransitionLinearColorEndMap;

		// Token: 0x0400F442 RID: 62530
		internal static int __PropertyOffset_14;

		// Token: 0x0400F443 RID: 62531
		internal static int __PropertyOffset_15;

		// Token: 0x0400F444 RID: 62532
		internal static int __PropertyOffset_16;

		// Token: 0x0400F445 RID: 62533
		internal static int __PropertyOffset_17;

		// Token: 0x0400F446 RID: 62534
		internal static int __PropertyOffset_18;

		// Token: 0x0400F447 RID: 62535
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _StaticMeshComponents;

		// Token: 0x0400F448 RID: 62536
		internal static int __PropertyOffset_19;

		// Token: 0x0400F449 RID: 62537
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _StaticMeshDMIs;

		// Token: 0x0400F44A RID: 62538
		internal static int __PropertyOffset_20;

		// Token: 0x0400F44B RID: 62539
		[Nullable(2)]
		private SEffectStateInfo _CurrentStateInfo;

		// Token: 0x0400F44C RID: 62540
		internal static int __PropertyOffset_21;

		// Token: 0x0400F44D RID: 62541
		internal static int __PropertyOffset_22;

		// Token: 0x0400F44E RID: 62542
		[Nullable(2)]
		private TMap<FName, float> _CurrentFloatMap;

		// Token: 0x0400F44F RID: 62543
		internal static int __PropertyOffset_23;

		// Token: 0x0400F450 RID: 62544
		[Nullable(2)]
		private TMap<FName, FLinearColor> _CurrentLinearColorMap;

		// Token: 0x0400F451 RID: 62545
		internal static int __PropertyOffset_24;

		// Token: 0x0400F452 RID: 62546
		internal static int __PropertyOffset_25;

		// Token: 0x0400F453 RID: 62547
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNiagaraComponent> _NiagaraComponents;

		// Token: 0x0400F454 RID: 62548
		internal static int __PropertyOffset_26;

		// Token: 0x0400F455 RID: 62549
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, STransitionFloatIndexGroup> _TransitionIndexFloatEndMap;

		// Token: 0x0400F456 RID: 62550
		internal static int __PropertyOffset_27;

		// Token: 0x0400F457 RID: 62551
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, STransitionLinearColorIndexGroup> _TransitionIndexLinearColorEndMap;

		// Token: 0x0400F458 RID: 62552
		private static IntPtr __SetState_NativeFunctionPtr;

		// Token: 0x0400F459 RID: 62553
		private static IntPtr __DEBUG重初始化_NativeFunctionPtr;

		// Token: 0x0400F45A RID: 62554
		private static IntPtr __DEBUG进入状态5_NativeFunctionPtr;

		// Token: 0x0400F45B RID: 62555
		private static IntPtr __DEBUG进入状态4_NativeFunctionPtr;

		// Token: 0x0400F45C RID: 62556
		private static IntPtr __DEBUG进入状态3_NativeFunctionPtr;

		// Token: 0x0400F45D RID: 62557
		private static IntPtr __DEBUG进入状态2_NativeFunctionPtr;

		// Token: 0x0400F45E RID: 62558
		private static IntPtr __DEBUG进入状态1_NativeFunctionPtr;

		// Token: 0x0400F45F RID: 62559
		private static IntPtr __CreateTransitionState_NativeFunctionPtr;

		// Token: 0x0400F460 RID: 62560
		private static IntPtr __UpdateParameters_NativeFunctionPtr;

		// Token: 0x0400F461 RID: 62561
		private static IntPtr __UpdateLoopState_NativeFunctionPtr;

		// Token: 0x0400F462 RID: 62562
		private static IntPtr __UpdatePreLoopState_NativeFunctionPtr;

		// Token: 0x0400F463 RID: 62563
		private static IntPtr __Update_Transition_State_NativeFunctionPtr;

		// Token: 0x0400F464 RID: 62564
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x0400F465 RID: 62565
		private static IntPtr __PlayEffectState_NativeFunctionPtr;

		// Token: 0x0400F466 RID: 62566
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x0400F467 RID: 62567
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0400F468 RID: 62568
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F469 RID: 62569
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F46A RID: 62570
		private static IntPtr __EditorInit_NativeFunctionPtr;

		// Token: 0x0400F46B RID: 62571
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F46C RID: 62572
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F46D RID: 62573
		private static IntPtr __ExecuteUbergraph_BP_StateMachineEffectBase_NativeFunctionPtr;

		// Token: 0x02009817 RID: 38935
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetState_FunctionParams
		{
			// Token: 0x04031E2F RID: 204335
			[FieldOffset(0)]
			public TEnumAsByte<EEffectState> TargetState;
		}

		// Token: 0x02009818 RID: 38936
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4120)]
		protected ref struct __CreateTransitionState_FunctionParams
		{
			// Token: 0x04031E30 RID: 204336
			[FieldOffset(0)]
			public TEnumAsByte<EEffectState> TargetState;
		}

		// Token: 0x02009819 RID: 38937
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __UpdateParameters_FunctionParams
		{
			// Token: 0x04031E31 RID: 204337
			[FieldOffset(0)]
			public FName Name;

			// Token: 0x04031E32 RID: 204338
			[FieldOffset(12)]
			public bool IsFloat;

			// Token: 0x04031E33 RID: 204339
			[FieldOffset(16)]
			public float FloatValue;

			// Token: 0x04031E34 RID: 204340
			[FieldOffset(20)]
			public bool IsLinearColor;

			// Token: 0x04031E35 RID: 204341
			[FieldOffset(24)]
			public FLinearColor LinearColorValue;

			// Token: 0x04031E36 RID: 204342
			[FieldOffset(40)]
			public int Index;
		}

		// Token: 0x0200981A RID: 38938
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __PlayEffectState_FunctionParams
		{
			// Token: 0x04031E37 RID: 204343
			[FieldOffset(0)]
			public IntPtr InputData;

			// Token: 0x04031E38 RID: 204344
			[FieldOffset(8)]
			public TEnumAsByte<EEffectState> TargetState;
		}

		// Token: 0x0200981B RID: 38939
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 912)]
		protected ref struct __Init_FunctionParams
		{
			// Token: 0x04031E39 RID: 204345
			[FieldOffset(0)]
			public TEnumAsByte<EEffectState> TargetState;
		}

		// Token: 0x0200981C RID: 38940
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E3A RID: 204346
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200981D RID: 38941
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E3B RID: 204347
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200981E RID: 38942
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_StateMachineEffectBase_FunctionParams
		{
			// Token: 0x04031E3C RID: 204348
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
