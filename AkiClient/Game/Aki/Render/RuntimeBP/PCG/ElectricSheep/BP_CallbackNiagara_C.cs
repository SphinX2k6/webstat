using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.ElectricSheep
{
	// Token: 0x02003C34 RID: 15412
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/ElectricSheep/BP_CallbackNiagara.BP_CallbackNiagara_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1480)]
	public class BP_CallbackNiagara_C : AKuroBPActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06023518 RID: 144664 RVA: 0x0097EA60 File Offset: 0x0097CC60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CallbackNiagara_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/ElectricSheep/BP_CallbackNiagara.BP_CallbackNiagara_C");
			}
			return BP_CallbackNiagara_C._ClassPtr;
		}

		// Token: 0x06023519 RID: 144665 RVA: 0x0097EA84 File Offset: 0x0097CC84
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_CallbackNiagara_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x0602351A RID: 144666 RVA: 0x0097EA8C File Offset: 0x0097CC8C
		public BP_CallbackNiagara_C() : this(BuiltinUtils.AllocNativeUObject(BP_CallbackNiagara_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602351B RID: 144667 RVA: 0x0097EAB4 File Offset: 0x0097CCB4
		[NullableContext(1)]
		public BP_CallbackNiagara_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CallbackNiagara_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045BA RID: 17850
		// (get) Token: 0x0602351C RID: 144668 RVA: 0x0097EAE8 File Offset: 0x0097CCE8
		// (set) Token: 0x0602351D RID: 144669 RVA: 0x0097EB21 File Offset: 0x0097CD21
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045BB RID: 17851
		// (get) Token: 0x0602351E RID: 144670 RVA: 0x0097EB42 File Offset: 0x0097CD42
		// (set) Token: 0x0602351F RID: 144671 RVA: 0x0097EB56 File Offset: 0x0097CD56
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045BC RID: 17852
		// (get) Token: 0x06023520 RID: 144672 RVA: 0x0097EB6B File Offset: 0x0097CD6B
		// (set) Token: 0x06023521 RID: 144673 RVA: 0x0097EB7F File Offset: 0x0097CD7F
		public unsafe UStaticMeshComponent TemplateMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045BD RID: 17853
		// (get) Token: 0x06023522 RID: 144674 RVA: 0x0097EB94 File Offset: 0x0097CD94
		// (set) Token: 0x06023523 RID: 144675 RVA: 0x0097EBA8 File Offset: 0x0097CDA8
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170045BE RID: 17854
		// (get) Token: 0x06023524 RID: 144676 RVA: 0x0097EBBD File Offset: 0x0097CDBD
		// (set) Token: 0x06023525 RID: 144677 RVA: 0x0097EBD1 File Offset: 0x0097CDD1
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170045BF RID: 17855
		// (get) Token: 0x06023526 RID: 144678 RVA: 0x0097EBE6 File Offset: 0x0097CDE6
		// (set) Token: 0x06023527 RID: 144679 RVA: 0x0097EBFA File Offset: 0x0097CDFA
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170045C0 RID: 17856
		// (get) Token: 0x06023528 RID: 144680 RVA: 0x0097EC0F File Offset: 0x0097CE0F
		// (set) Token: 0x06023529 RID: 144681 RVA: 0x0097EC23 File Offset: 0x0097CE23
		public unsafe FVector PitchMinMax_YawRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170045C1 RID: 17857
		// (get) Token: 0x0602352A RID: 144682 RVA: 0x0097EC38 File Offset: 0x0097CE38
		// (set) Token: 0x0602352B RID: 144683 RVA: 0x0097EC48 File Offset: 0x0097CE48
		public unsafe float Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170045C2 RID: 17858
		// (get) Token: 0x0602352C RID: 144684 RVA: 0x0097EC59 File Offset: 0x0097CE59
		// (set) Token: 0x0602352D RID: 144685 RVA: 0x0097EC69 File Offset: 0x0097CE69
		public unsafe float Size_Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170045C3 RID: 17859
		// (get) Token: 0x0602352E RID: 144686 RVA: 0x0097EC7A File Offset: 0x0097CE7A
		// (set) Token: 0x0602352F RID: 144687 RVA: 0x0097EC8A File Offset: 0x0097CE8A
		public unsafe float Size_Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170045C4 RID: 17860
		// (get) Token: 0x06023530 RID: 144688 RVA: 0x0097EC9B File Offset: 0x0097CE9B
		// (set) Token: 0x06023531 RID: 144689 RVA: 0x0097ECAB File Offset: 0x0097CEAB
		public unsafe int SpawnCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170045C5 RID: 17861
		// (get) Token: 0x06023532 RID: 144690 RVA: 0x0097ECBC File Offset: 0x0097CEBC
		// (set) Token: 0x06023533 RID: 144691 RVA: 0x0097ECCC File Offset: 0x0097CECC
		public unsafe float SpawnDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170045C6 RID: 17862
		// (get) Token: 0x06023534 RID: 144692 RVA: 0x0097ECDD File Offset: 0x0097CEDD
		// (set) Token: 0x06023535 RID: 144693 RVA: 0x0097ECED File Offset: 0x0097CEED
		public unsafe float SpawnRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170045C7 RID: 17863
		// (get) Token: 0x06023536 RID: 144694 RVA: 0x0097ECFE File Offset: 0x0097CEFE
		// (set) Token: 0x06023537 RID: 144695 RVA: 0x0097ED0E File Offset: 0x0097CF0E
		public unsafe float SpeedWiggle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170045C8 RID: 17864
		// (get) Token: 0x06023538 RID: 144696 RVA: 0x0097ED1F File Offset: 0x0097CF1F
		// (set) Token: 0x06023539 RID: 144697 RVA: 0x0097ED2F File Offset: 0x0097CF2F
		public unsafe float SplineSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170045C9 RID: 17865
		// (get) Token: 0x0602353A RID: 144698 RVA: 0x0097ED40 File Offset: 0x0097CF40
		// (set) Token: 0x0602353B RID: 144699 RVA: 0x0097ED79 File Offset: 0x0097CF79
		[Nullable(1)]
		public TArray<UStaticMeshComponent> CollisionComponentReferences
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._CollisionComponentReferences) == null)
				{
					result = (this._CollisionComponentReferences = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CollisionComponentReferences.CopyAssign(value);
			}
		}

		// Token: 0x170045CA RID: 17866
		// (get) Token: 0x0602353C RID: 144700 RVA: 0x0097ED87 File Offset: 0x0097CF87
		// (set) Token: 0x0602353D RID: 144701 RVA: 0x0097ED97 File Offset: 0x0097CF97
		public unsafe bool IsSetExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170045CB RID: 17867
		// (get) Token: 0x0602353E RID: 144702 RVA: 0x0097EDA8 File Offset: 0x0097CFA8
		// (set) Token: 0x0602353F RID: 144703 RVA: 0x0097EDE1 File Offset: 0x0097CFE1
		[Nullable(1)]
		public TArray<UStaticMeshComponent> NewVar_0
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._NewVar_0) == null)
				{
					result = (this._NewVar_0 = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.NewVar_0.CopyAssign(value);
			}
		}

		// Token: 0x170045CC RID: 17868
		// (get) Token: 0x06023540 RID: 144704 RVA: 0x0097EDEF File Offset: 0x0097CFEF
		// (set) Token: 0x06023541 RID: 144705 RVA: 0x0097EDFF File Offset: 0x0097CFFF
		public unsafe float time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170045CD RID: 17869
		// (get) Token: 0x06023542 RID: 144706 RVA: 0x0097EE10 File Offset: 0x0097D010
		// (set) Token: 0x06023543 RID: 144707 RVA: 0x0097EE24 File Offset: 0x0097D024
		public unsafe FBoxSphereBounds Bounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CallbackNiagara_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170045CE RID: 17870
		// (get) Token: 0x06023544 RID: 144708 RVA: 0x0097EE39 File Offset: 0x0097D039
		// (set) Token: 0x06023545 RID: 144709 RVA: 0x0097EE4D File Offset: 0x0097D04D
		public unsafe USceneComponent Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CallbackNiagara_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x06023546 RID: 144710 RVA: 0x0097EE62 File Offset: 0x0097D062
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetNiagaraParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__SetNiagaraParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06023547 RID: 144711 RVA: 0x0097EE76 File Offset: 0x0097D076
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023548 RID: 144712 RVA: 0x0097EE8A File Offset: 0x0097D08A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CallbackNiagara_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023549 RID: 144713 RVA: 0x0097EE9F File Offset: 0x0097D09F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602354A RID: 144714 RVA: 0x0097EEB3 File Offset: 0x0097D0B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CallbackNiagara_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602354B RID: 144715 RVA: 0x0097EEC8 File Offset: 0x0097D0C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CallbackNiagara_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CallbackNiagara_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602354C RID: 144716 RVA: 0x0097EF10 File Offset: 0x0097D110
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CallbackNiagara_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CallbackNiagara_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CallbackNiagara_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602354D RID: 144717 RVA: 0x0097EF58 File Offset: 0x0097D158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_CallbackNiagara_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_CallbackNiagara_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_CallbackNiagara_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602354E RID: 144718 RVA: 0x0097EFE8 File Offset: 0x0097D1E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_CallbackNiagara_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_CallbackNiagara_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CallbackNiagara_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_CallbackNiagara_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602354F RID: 144719 RVA: 0x0097F078 File Offset: 0x0097D278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023550 RID: 144720 RVA: 0x0097F134 File Offset: 0x0097D334
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CallbackNiagara_C.__BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023551 RID: 144721 RVA: 0x0097F1C0 File Offset: 0x0097D3C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CallbackNiagara(int EntryPoint)
		{
			BP_CallbackNiagara_C.__ExecuteUbergraph_BP_CallbackNiagara_FunctionParams* ptr = stackalloc BP_CallbackNiagara_C.__ExecuteUbergraph_BP_CallbackNiagara_FunctionParams[(UIntPtr)575] + 15L / (long)sizeof(BP_CallbackNiagara_C.__ExecuteUbergraph_BP_CallbackNiagara_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CallbackNiagara_C.__ExecuteUbergraph_BP_CallbackNiagara_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CallbackNiagara_C.__ExecuteUbergraph_BP_CallbackNiagara_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023552 RID: 144722 RVA: 0x0097F20A File Offset: 0x0097D40A
		protected BP_CallbackNiagara_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F7B RID: 73595
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x04011F7C RID: 73596
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/ElectricSheep/BP_CallbackNiagara.BP_CallbackNiagara_C";

		// Token: 0x04011F7D RID: 73597
		private static IntPtr _ClassPtr;

		// Token: 0x04011F7E RID: 73598
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011F7F RID: 73599
		internal static int __PropertyOffset_0;

		// Token: 0x04011F80 RID: 73600
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011F81 RID: 73601
		internal static int __PropertyOffset_1;

		// Token: 0x04011F82 RID: 73602
		internal static int __PropertyOffset_2;

		// Token: 0x04011F83 RID: 73603
		internal static int __PropertyOffset_3;

		// Token: 0x04011F84 RID: 73604
		internal static int __PropertyOffset_4;

		// Token: 0x04011F85 RID: 73605
		internal static int __PropertyOffset_5;

		// Token: 0x04011F86 RID: 73606
		internal static int __PropertyOffset_6;

		// Token: 0x04011F87 RID: 73607
		internal static int __PropertyOffset_7;

		// Token: 0x04011F88 RID: 73608
		internal static int __PropertyOffset_8;

		// Token: 0x04011F89 RID: 73609
		internal static int __PropertyOffset_9;

		// Token: 0x04011F8A RID: 73610
		internal static int __PropertyOffset_10;

		// Token: 0x04011F8B RID: 73611
		internal static int __PropertyOffset_11;

		// Token: 0x04011F8C RID: 73612
		internal static int __PropertyOffset_12;

		// Token: 0x04011F8D RID: 73613
		internal static int __PropertyOffset_13;

		// Token: 0x04011F8E RID: 73614
		internal static int __PropertyOffset_14;

		// Token: 0x04011F8F RID: 73615
		internal static int __PropertyOffset_15;

		// Token: 0x04011F90 RID: 73616
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _CollisionComponentReferences;

		// Token: 0x04011F91 RID: 73617
		internal static int __PropertyOffset_16;

		// Token: 0x04011F92 RID: 73618
		internal static int __PropertyOffset_17;

		// Token: 0x04011F93 RID: 73619
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _NewVar_0;

		// Token: 0x04011F94 RID: 73620
		internal static int __PropertyOffset_18;

		// Token: 0x04011F95 RID: 73621
		internal static int __PropertyOffset_19;

		// Token: 0x04011F96 RID: 73622
		internal static int __PropertyOffset_20;

		// Token: 0x04011F97 RID: 73623
		private static IntPtr __SetNiagaraParameters_NativeFunctionPtr;

		// Token: 0x04011F98 RID: 73624
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011F99 RID: 73625
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011F9A RID: 73626
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011F9B RID: 73627
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x04011F9C RID: 73628
		private static IntPtr __BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011F9D RID: 73629
		private static IntPtr __BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011F9E RID: 73630
		private static IntPtr __ExecuteUbergraph_BP_CallbackNiagara_NativeFunctionPtr;

		// Token: 0x02009CBE RID: 40126
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032620 RID: 206368
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CBF RID: 40127
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x04032621 RID: 206369
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04032622 RID: 206370
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x02009CC0 RID: 40128
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032623 RID: 206371
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032624 RID: 206372
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032625 RID: 206373
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032626 RID: 206374
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032627 RID: 206375
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032628 RID: 206376
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CC1 RID: 40129
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CallbackNiagara_Box_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032629 RID: 206377
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403262A RID: 206378
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403262B RID: 206379
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403262C RID: 206380
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CC2 RID: 40130
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 560)]
		protected ref struct __ExecuteUbergraph_BP_CallbackNiagara_FunctionParams
		{
			// Token: 0x0403262D RID: 206381
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
