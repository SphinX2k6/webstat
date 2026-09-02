using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect
{
	// Token: 0x02003A66 RID: 14950
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectSystem.BP_ScreenEffectSystem_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1508)]
	public class BP_ScreenEffectSystem_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F252 RID: 127570 RVA: 0x009090F3 File Offset: 0x009072F3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ScreenEffectSystem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectSystem.BP_ScreenEffectSystem_C");
			}
			return BP_ScreenEffectSystem_C._ClassPtr;
		}

		// Token: 0x0601F253 RID: 127571 RVA: 0x00909118 File Offset: 0x00907318
		public BP_ScreenEffectSystem_C() : this(BuiltinUtils.AllocNativeUObject(BP_ScreenEffectSystem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F254 RID: 127572 RVA: 0x00909140 File Offset: 0x00907340
		[NullableContext(1)]
		public BP_ScreenEffectSystem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ScreenEffectSystem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E50 RID: 11856
		// (get) Token: 0x0601F255 RID: 127573 RVA: 0x00909174 File Offset: 0x00907374
		// (set) Token: 0x0601F256 RID: 127574 RVA: 0x009091AD File Offset: 0x009073AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E51 RID: 11857
		// (get) Token: 0x0601F257 RID: 127575 RVA: 0x009091CE File Offset: 0x009073CE
		// (set) Token: 0x0601F258 RID: 127576 RVA: 0x009091E2 File Offset: 0x009073E2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E52 RID: 11858
		// (get) Token: 0x0601F259 RID: 127577 RVA: 0x009091F7 File Offset: 0x009073F7
		// (set) Token: 0x0601F25A RID: 127578 RVA: 0x0090920B File Offset: 0x0090740B
		public unsafe EffectScreenPlayData_C DebugData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectScreenPlayData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002E53 RID: 11859
		// (get) Token: 0x0601F25B RID: 127579 RVA: 0x00909220 File Offset: 0x00907420
		// (set) Token: 0x0601F25C RID: 127580 RVA: 0x00909259 File Offset: 0x00907459
		[Nullable(1)]
		public TMap<EffectScreenPlayData_C, BP_ScreenEffectPlayer_C> Effects
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<EffectScreenPlayData_C, BP_ScreenEffectPlayer_C> result;
				if ((result = this._Effects) == null)
				{
					result = (this._Effects = new TMap<EffectScreenPlayData_C, BP_ScreenEffectPlayer_C>(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Effects.CopyAssign(value);
			}
		}

		// Token: 0x17002E54 RID: 11860
		// (get) Token: 0x0601F25D RID: 127581 RVA: 0x00909268 File Offset: 0x00907468
		// (set) Token: 0x0601F25E RID: 127582 RVA: 0x009092A1 File Offset: 0x009074A1
		[Nullable(1)]
		public TArray<EffectScreenPlayData_C> OrderDatas
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<EffectScreenPlayData_C> result;
				if ((result = this._OrderDatas) == null)
				{
					result = (this._OrderDatas = new TArray<EffectScreenPlayData_C>(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OrderDatas.CopyAssign(value);
			}
		}

		// Token: 0x17002E55 RID: 11861
		// (get) Token: 0x0601F25F RID: 127583 RVA: 0x009092B0 File Offset: 0x009074B0
		// (set) Token: 0x0601F260 RID: 127584 RVA: 0x009092E9 File Offset: 0x009074E9
		[Nullable(1)]
		public TArray<EffectScreenPlayData_C> IndependentDatas
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<EffectScreenPlayData_C> result;
				if ((result = this._IndependentDatas) == null)
				{
					result = (this._IndependentDatas = new TArray<EffectScreenPlayData_C>(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.IndependentDatas.CopyAssign(value);
			}
		}

		// Token: 0x17002E56 RID: 11862
		// (get) Token: 0x0601F261 RID: 127585 RVA: 0x009092F7 File Offset: 0x009074F7
		// (set) Token: 0x0601F262 RID: 127586 RVA: 0x00909307 File Offset: 0x00907507
		public unsafe bool bEvaluateOrderEffects
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E57 RID: 11863
		// (get) Token: 0x0601F263 RID: 127587 RVA: 0x00909318 File Offset: 0x00907518
		// (set) Token: 0x0601F264 RID: 127588 RVA: 0x0090932C File Offset: 0x0090752C
		public unsafe AUIContainerActor EditorScreenRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002E58 RID: 11864
		// (get) Token: 0x0601F265 RID: 127589 RVA: 0x00909341 File Offset: 0x00907541
		// (set) Token: 0x0601F266 RID: 127590 RVA: 0x00909355 File Offset: 0x00907555
		public unsafe AUIContainerActor ScreenEffectFightRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002E59 RID: 11865
		// (get) Token: 0x0601F267 RID: 127591 RVA: 0x0090936A File Offset: 0x0090756A
		// (set) Token: 0x0601F268 RID: 127592 RVA: 0x0090937E File Offset: 0x0090757E
		public unsafe AUIContainerActor ScreenEffectPlotRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002E5A RID: 11866
		// (get) Token: 0x0601F269 RID: 127593 RVA: 0x00909393 File Offset: 0x00907593
		// (set) Token: 0x0601F26A RID: 127594 RVA: 0x009093A3 File Offset: 0x009075A3
		public unsafe float EnvironmentFactorDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002E5B RID: 11867
		// (get) Token: 0x0601F26B RID: 127595 RVA: 0x009093B4 File Offset: 0x009075B4
		// (set) Token: 0x0601F26C RID: 127596 RVA: 0x009093C8 File Offset: 0x009075C8
		public unsafe AUIContainerActor ScreenEffectGeneralRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002E5C RID: 11868
		// (get) Token: 0x0601F26D RID: 127597 RVA: 0x009093DD File Offset: 0x009075DD
		// (set) Token: 0x0601F26E RID: 127598 RVA: 0x009093ED File Offset: 0x009075ED
		public unsafe int DebugExtraState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002E5D RID: 11869
		// (get) Token: 0x0601F26F RID: 127599 RVA: 0x009093FE File Offset: 0x009075FE
		// (set) Token: 0x0601F270 RID: 127600 RVA: 0x00909412 File Offset: 0x00907612
		public unsafe AUIContainerActor ScreenEffectCoverLoadingRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectSystem_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002E5E RID: 11870
		// (get) Token: 0x0601F271 RID: 127601 RVA: 0x00909427 File Offset: 0x00907627
		// (set) Token: 0x0601F272 RID: 127602 RVA: 0x00909437 File Offset: 0x00907637
		public unsafe float NiagaraFrameDeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectSystem_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x0601F273 RID: 127603 RVA: 0x00909448 File Offset: 0x00907648
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetNiagaraFrameDeltaTime(float DeltaTime)
		{
			BP_ScreenEffectSystem_C.__SetNiagaraFrameDeltaTime_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__SetNiagaraFrameDeltaTime_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__SetNiagaraFrameDeltaTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__SetNiagaraFrameDeltaTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__SetNiagaraFrameDeltaTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F274 RID: 127604 RVA: 0x0090948E File Offset: 0x0090768E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetEffectExtraStateDebug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__SetEffectExtraStateDebug_NativeFunctionPtr, null);
		}

		// Token: 0x0601F275 RID: 127605 RVA: 0x009094A4 File Offset: 0x009076A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetEffectExtraState(EffectScreenPlayData_C EffectScreenPlayData, int ExtraState)
		{
			BP_ScreenEffectSystem_C.__SetEffectExtraState_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__SetEffectExtraState_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__SetEffectExtraState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__SetEffectExtraState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EffectScreenPlayData = ((EffectScreenPlayData != null) ? EffectScreenPlayData.NativePtr : IntPtr.Zero);
			ptr->ExtraState = ExtraState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__SetEffectExtraState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F276 RID: 127606 RVA: 0x00909500 File Offset: 0x00907700
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TweenEffectParameter(EffectScreenPlayData_C EffectScreenPlayData, float targetProgress)
		{
			BP_ScreenEffectSystem_C.__TweenEffectParameter_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__TweenEffectParameter_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__TweenEffectParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__TweenEffectParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EffectScreenPlayData = ((EffectScreenPlayData != null) ? EffectScreenPlayData.NativePtr : IntPtr.Zero);
			ptr->targetProgress = targetProgress;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__TweenEffectParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F277 RID: 127607 RVA: 0x0090955C File Offset: 0x0090775C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEnvironmentFactorDebug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__UpdateEnvironmentFactorDebug_NativeFunctionPtr, null);
		}

		// Token: 0x0601F278 RID: 127608 RVA: 0x00909570 File Offset: 0x00907770
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateSEEnvironmentFactor(EffectScreenPlayData_C Data, float EnvironmentFactor)
		{
			BP_ScreenEffectSystem_C.__UpdateSEEnvironmentFactor_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__UpdateSEEnvironmentFactor_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__UpdateSEEnvironmentFactor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__UpdateSEEnvironmentFactor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->EnvironmentFactor = EnvironmentFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__UpdateSEEnvironmentFactor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F279 RID: 127609 RVA: 0x009095CC File Offset: 0x009077CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DestroyScreenEffect(EffectScreenPlayData_C Data)
		{
			BP_ScreenEffectSystem_C.__DestroyScreenEffect_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__DestroyScreenEffect_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__DestroyScreenEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__DestroyScreenEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__DestroyScreenEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F27A RID: 127610 RVA: 0x00909624 File Offset: 0x00907824
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SpawnPlayer(EffectScreenPlayData_C Data, ref BP_ScreenEffectPlayer_C OutputPlayer)
		{
			BP_ScreenEffectSystem_C.__SpawnPlayer_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__SpawnPlayer_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__SpawnPlayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__SpawnPlayer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ref BP_ScreenEffectSystem_C.__SpawnPlayer_FunctionParams ptr2 = ref *ptr;
			BP_ScreenEffectPlayer_C bp_ScreenEffectPlayer_C = OutputPlayer;
			ptr2.OutputPlayer = ((bp_ScreenEffectPlayer_C != null) ? bp_ScreenEffectPlayer_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__SpawnPlayer_NativeFunctionPtr, (void*)ptr);
			OutputPlayer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ScreenEffectPlayer_C>(ptr->OutputPlayer);
		}

		// Token: 0x0601F27B RID: 127611 RVA: 0x009096A4 File Offset: 0x009078A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetScreenEffectCoverLoadingRoot(ref AUIContainerActor ScreenEffectCoverLoadingRoot)
		{
			BP_ScreenEffectSystem_C.__GetScreenEffectCoverLoadingRoot_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__GetScreenEffectCoverLoadingRoot_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__GetScreenEffectCoverLoadingRoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__GetScreenEffectCoverLoadingRoot_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_ScreenEffectSystem_C.__GetScreenEffectCoverLoadingRoot_FunctionParams ptr2 = ref *ptr;
			AUIContainerActor auicontainerActor = ScreenEffectCoverLoadingRoot;
			ptr2.ScreenEffectCoverLoadingRoot = ((auicontainerActor != null) ? auicontainerActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__GetScreenEffectCoverLoadingRoot_NativeFunctionPtr, (void*)ptr);
			ScreenEffectCoverLoadingRoot = BuiltinUtils.GetOrCreateUObjectByNativePointer<AUIContainerActor>(ptr->ScreenEffectCoverLoadingRoot);
		}

		// Token: 0x0601F27C RID: 127612 RVA: 0x00909708 File Offset: 0x00907908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_SECoverLoadingRoot()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__Init_SECoverLoadingRoot_NativeFunctionPtr, null);
		}

		// Token: 0x0601F27D RID: 127613 RVA: 0x0090971C File Offset: 0x0090791C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetScreenEffectGeneralRoot(ref AUIContainerActor ScreenEffectGeneralRoot)
		{
			BP_ScreenEffectSystem_C.__GetScreenEffectGeneralRoot_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__GetScreenEffectGeneralRoot_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__GetScreenEffectGeneralRoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__GetScreenEffectGeneralRoot_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_ScreenEffectSystem_C.__GetScreenEffectGeneralRoot_FunctionParams ptr2 = ref *ptr;
			AUIContainerActor auicontainerActor = ScreenEffectGeneralRoot;
			ptr2.ScreenEffectGeneralRoot = ((auicontainerActor != null) ? auicontainerActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__GetScreenEffectGeneralRoot_NativeFunctionPtr, (void*)ptr);
			ScreenEffectGeneralRoot = BuiltinUtils.GetOrCreateUObjectByNativePointer<AUIContainerActor>(ptr->ScreenEffectGeneralRoot);
		}

		// Token: 0x0601F27E RID: 127614 RVA: 0x00909780 File Offset: 0x00907980
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_SEGeneralRoot()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__Init_SEGeneralRoot_NativeFunctionPtr, null);
		}

		// Token: 0x0601F27F RID: 127615 RVA: 0x00909794 File Offset: 0x00907994
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetScreenEffectPlotRoot(ref AUIContainerActor ScreenEffectPlotRoot)
		{
			BP_ScreenEffectSystem_C.__GetScreenEffectPlotRoot_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__GetScreenEffectPlotRoot_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__GetScreenEffectPlotRoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__GetScreenEffectPlotRoot_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_ScreenEffectSystem_C.__GetScreenEffectPlotRoot_FunctionParams ptr2 = ref *ptr;
			AUIContainerActor auicontainerActor = ScreenEffectPlotRoot;
			ptr2.ScreenEffectPlotRoot = ((auicontainerActor != null) ? auicontainerActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__GetScreenEffectPlotRoot_NativeFunctionPtr, (void*)ptr);
			ScreenEffectPlotRoot = BuiltinUtils.GetOrCreateUObjectByNativePointer<AUIContainerActor>(ptr->ScreenEffectPlotRoot);
		}

		// Token: 0x0601F280 RID: 127616 RVA: 0x009097F8 File Offset: 0x009079F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_SEPlotRoot()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__Init_SEPlotRoot_NativeFunctionPtr, null);
		}

		// Token: 0x0601F281 RID: 127617 RVA: 0x0090980C File Offset: 0x00907A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetScreenEffectFightRoot(ref AUIContainerActor ScreenEffectFightRoot)
		{
			BP_ScreenEffectSystem_C.__GetScreenEffectFightRoot_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__GetScreenEffectFightRoot_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__GetScreenEffectFightRoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__GetScreenEffectFightRoot_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_ScreenEffectSystem_C.__GetScreenEffectFightRoot_FunctionParams ptr2 = ref *ptr;
			AUIContainerActor auicontainerActor = ScreenEffectFightRoot;
			ptr2.ScreenEffectFightRoot = ((auicontainerActor != null) ? auicontainerActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__GetScreenEffectFightRoot_NativeFunctionPtr, (void*)ptr);
			ScreenEffectFightRoot = BuiltinUtils.GetOrCreateUObjectByNativePointer<AUIContainerActor>(ptr->ScreenEffectFightRoot);
		}

		// Token: 0x0601F282 RID: 127618 RVA: 0x00909870 File Offset: 0x00907A70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init_SEFight_Root()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__Init_SEFight_Root_NativeFunctionPtr, null);
		}

		// Token: 0x0601F283 RID: 127619 RVA: 0x00909884 File Offset: 0x00907A84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLGUIMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__UpdateLGUIMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x0601F284 RID: 127620 RVA: 0x00909898 File Offset: 0x00907A98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearSystem()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__ClearSystem_NativeFunctionPtr, null);
		}

		// Token: 0x0601F285 RID: 127621 RVA: 0x009098AC File Offset: 0x00907AAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVisibilityOfSystem(bool Visibility, bool bOverrideFadeSpeed, float OverrideFadeSpeed)
		{
			BP_ScreenEffectSystem_C.__SetVisibilityOfSystem_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__SetVisibilityOfSystem_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__SetVisibilityOfSystem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__SetVisibilityOfSystem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Visibility = Visibility;
			ptr->bOverrideFadeSpeed = bOverrideFadeSpeed;
			ptr->OverrideFadeSpeed = OverrideFadeSpeed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__SetVisibilityOfSystem_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F286 RID: 127622 RVA: 0x00909900 File Offset: 0x00907B00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndEffectDebug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__EndEffectDebug_NativeFunctionPtr, null);
		}

		// Token: 0x0601F287 RID: 127623 RVA: 0x00909914 File Offset: 0x00907B14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EndScreenEffect(EffectScreenPlayData_C Data)
		{
			BP_ScreenEffectSystem_C.__EndScreenEffect_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__EndScreenEffect_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__EndScreenEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__EndScreenEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__EndScreenEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F288 RID: 127624 RVA: 0x00909969 File Offset: 0x00907B69
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateOrderEffects()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__EvaluateOrderEffects_NativeFunctionPtr, null);
		}

		// Token: 0x0601F289 RID: 127625 RVA: 0x00909980 File Offset: 0x00907B80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayScreenEffectNoPaused(EffectScreenPlayData_C Data)
		{
			BP_ScreenEffectSystem_C.__PlayScreenEffectNoPaused_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__PlayScreenEffectNoPaused_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__PlayScreenEffectNoPaused_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__PlayScreenEffectNoPaused_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__PlayScreenEffectNoPaused_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F28A RID: 127626 RVA: 0x009099D5 File Offset: 0x00907BD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayEffectDebug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__PlayEffectDebug_NativeFunctionPtr, null);
		}

		// Token: 0x0601F28B RID: 127627 RVA: 0x009099EC File Offset: 0x00907BEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayScreenEffect(EffectScreenPlayData_C Data)
		{
			BP_ScreenEffectSystem_C.__PlayScreenEffect_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__PlayScreenEffect_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__PlayScreenEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__PlayScreenEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__PlayScreenEffect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F28C RID: 127628 RVA: 0x00909A44 File Offset: 0x00907C44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddEffect(EffectScreenPlayData_C Data, bool TickWhenPaused, ref BP_ScreenEffectPlayer_C EffectPlayer)
		{
			BP_ScreenEffectSystem_C.__AddEffect_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__AddEffect_FunctionParams[(UIntPtr)175] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__AddEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__AddEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->TickWhenPaused = TickWhenPaused;
			ref BP_ScreenEffectSystem_C.__AddEffect_FunctionParams ptr2 = ref *ptr;
			BP_ScreenEffectPlayer_C bp_ScreenEffectPlayer_C = EffectPlayer;
			ptr2.EffectPlayer = ((bp_ScreenEffectPlayer_C != null) ? bp_ScreenEffectPlayer_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__AddEffect_NativeFunctionPtr, (void*)ptr);
			EffectPlayer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ScreenEffectPlayer_C>(ptr->EffectPlayer);
		}

		// Token: 0x0601F28D RID: 127629 RVA: 0x00909AC8 File Offset: 0x00907CC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F28E RID: 127630 RVA: 0x00909ADC File Offset: 0x00907CDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F28F RID: 127631 RVA: 0x00909AF4 File Offset: 0x00907CF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ScreenEffectSystem_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F290 RID: 127632 RVA: 0x00909B3C File Offset: 0x00907D3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ScreenEffectSystem_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F291 RID: 127633 RVA: 0x00909B84 File Offset: 0x00907D84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ScreenEffectSystem(int EntryPoint)
		{
			BP_ScreenEffectSystem_C.__ExecuteUbergraph_BP_ScreenEffectSystem_FunctionParams* ptr = stackalloc BP_ScreenEffectSystem_C.__ExecuteUbergraph_BP_ScreenEffectSystem_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_ScreenEffectSystem_C.__ExecuteUbergraph_BP_ScreenEffectSystem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectSystem_C.__ExecuteUbergraph_BP_ScreenEffectSystem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectSystem_C.__ExecuteUbergraph_BP_ScreenEffectSystem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F292 RID: 127634 RVA: 0x00909BCB File Offset: 0x00907DCB
		protected BP_ScreenEffectSystem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F6D5 RID: 63189
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectSystem.BP_ScreenEffectSystem_C";

		// Token: 0x0400F6D6 RID: 63190
		private static IntPtr _ClassPtr;

		// Token: 0x0400F6D7 RID: 63191
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F6D8 RID: 63192
		internal static int __PropertyOffset_0;

		// Token: 0x0400F6D9 RID: 63193
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F6DA RID: 63194
		internal static int __PropertyOffset_1;

		// Token: 0x0400F6DB RID: 63195
		internal static int __PropertyOffset_2;

		// Token: 0x0400F6DC RID: 63196
		internal static int __PropertyOffset_3;

		// Token: 0x0400F6DD RID: 63197
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<EffectScreenPlayData_C, BP_ScreenEffectPlayer_C> _Effects;

		// Token: 0x0400F6DE RID: 63198
		internal static int __PropertyOffset_4;

		// Token: 0x0400F6DF RID: 63199
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<EffectScreenPlayData_C> _OrderDatas;

		// Token: 0x0400F6E0 RID: 63200
		internal static int __PropertyOffset_5;

		// Token: 0x0400F6E1 RID: 63201
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<EffectScreenPlayData_C> _IndependentDatas;

		// Token: 0x0400F6E2 RID: 63202
		internal static int __PropertyOffset_6;

		// Token: 0x0400F6E3 RID: 63203
		internal static int __PropertyOffset_7;

		// Token: 0x0400F6E4 RID: 63204
		internal static int __PropertyOffset_8;

		// Token: 0x0400F6E5 RID: 63205
		internal static int __PropertyOffset_9;

		// Token: 0x0400F6E6 RID: 63206
		internal static int __PropertyOffset_10;

		// Token: 0x0400F6E7 RID: 63207
		internal static int __PropertyOffset_11;

		// Token: 0x0400F6E8 RID: 63208
		internal static int __PropertyOffset_12;

		// Token: 0x0400F6E9 RID: 63209
		internal static int __PropertyOffset_13;

		// Token: 0x0400F6EA RID: 63210
		internal static int __PropertyOffset_14;

		// Token: 0x0400F6EB RID: 63211
		private static IntPtr __SetNiagaraFrameDeltaTime_NativeFunctionPtr;

		// Token: 0x0400F6EC RID: 63212
		private static IntPtr __SetEffectExtraStateDebug_NativeFunctionPtr;

		// Token: 0x0400F6ED RID: 63213
		private static IntPtr __SetEffectExtraState_NativeFunctionPtr;

		// Token: 0x0400F6EE RID: 63214
		private static IntPtr __TweenEffectParameter_NativeFunctionPtr;

		// Token: 0x0400F6EF RID: 63215
		private static IntPtr __UpdateEnvironmentFactorDebug_NativeFunctionPtr;

		// Token: 0x0400F6F0 RID: 63216
		private static IntPtr __UpdateSEEnvironmentFactor_NativeFunctionPtr;

		// Token: 0x0400F6F1 RID: 63217
		private static IntPtr __DestroyScreenEffect_NativeFunctionPtr;

		// Token: 0x0400F6F2 RID: 63218
		private static IntPtr __SpawnPlayer_NativeFunctionPtr;

		// Token: 0x0400F6F3 RID: 63219
		private static IntPtr __GetScreenEffectCoverLoadingRoot_NativeFunctionPtr;

		// Token: 0x0400F6F4 RID: 63220
		private static IntPtr __Init_SECoverLoadingRoot_NativeFunctionPtr;

		// Token: 0x0400F6F5 RID: 63221
		private static IntPtr __GetScreenEffectGeneralRoot_NativeFunctionPtr;

		// Token: 0x0400F6F6 RID: 63222
		private static IntPtr __Init_SEGeneralRoot_NativeFunctionPtr;

		// Token: 0x0400F6F7 RID: 63223
		private static IntPtr __GetScreenEffectPlotRoot_NativeFunctionPtr;

		// Token: 0x0400F6F8 RID: 63224
		private static IntPtr __Init_SEPlotRoot_NativeFunctionPtr;

		// Token: 0x0400F6F9 RID: 63225
		private static IntPtr __GetScreenEffectFightRoot_NativeFunctionPtr;

		// Token: 0x0400F6FA RID: 63226
		private static IntPtr __Init_SEFight_Root_NativeFunctionPtr;

		// Token: 0x0400F6FB RID: 63227
		private static IntPtr __UpdateLGUIMaterialParams_NativeFunctionPtr;

		// Token: 0x0400F6FC RID: 63228
		private static IntPtr __ClearSystem_NativeFunctionPtr;

		// Token: 0x0400F6FD RID: 63229
		private static IntPtr __SetVisibilityOfSystem_NativeFunctionPtr;

		// Token: 0x0400F6FE RID: 63230
		private static IntPtr __EndEffectDebug_NativeFunctionPtr;

		// Token: 0x0400F6FF RID: 63231
		private static IntPtr __EndScreenEffect_NativeFunctionPtr;

		// Token: 0x0400F700 RID: 63232
		private static IntPtr __EvaluateOrderEffects_NativeFunctionPtr;

		// Token: 0x0400F701 RID: 63233
		private static IntPtr __PlayScreenEffectNoPaused_NativeFunctionPtr;

		// Token: 0x0400F702 RID: 63234
		private static IntPtr __PlayEffectDebug_NativeFunctionPtr;

		// Token: 0x0400F703 RID: 63235
		private static IntPtr __PlayScreenEffect_NativeFunctionPtr;

		// Token: 0x0400F704 RID: 63236
		private static IntPtr __AddEffect_NativeFunctionPtr;

		// Token: 0x0400F705 RID: 63237
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F706 RID: 63238
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F707 RID: 63239
		private static IntPtr __ExecuteUbergraph_BP_ScreenEffectSystem_NativeFunctionPtr;

		// Token: 0x02009872 RID: 39026
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __SetNiagaraFrameDeltaTime_FunctionParams
		{
			// Token: 0x04031EAE RID: 204462
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009873 RID: 39027
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetEffectExtraState_FunctionParams
		{
			// Token: 0x04031EAF RID: 204463
			[FieldOffset(0)]
			public IntPtr EffectScreenPlayData;

			// Token: 0x04031EB0 RID: 204464
			[FieldOffset(8)]
			public int ExtraState;
		}

		// Token: 0x02009874 RID: 39028
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __TweenEffectParameter_FunctionParams
		{
			// Token: 0x04031EB1 RID: 204465
			[FieldOffset(0)]
			public IntPtr EffectScreenPlayData;

			// Token: 0x04031EB2 RID: 204466
			[FieldOffset(8)]
			public float targetProgress;
		}

		// Token: 0x02009875 RID: 39029
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UpdateSEEnvironmentFactor_FunctionParams
		{
			// Token: 0x04031EB3 RID: 204467
			[FieldOffset(0)]
			public IntPtr Data;

			// Token: 0x04031EB4 RID: 204468
			[FieldOffset(8)]
			public float EnvironmentFactor;
		}

		// Token: 0x02009876 RID: 39030
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __DestroyScreenEffect_FunctionParams
		{
			// Token: 0x04031EB5 RID: 204469
			[FieldOffset(0)]
			public IntPtr Data;
		}

		// Token: 0x02009877 RID: 39031
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __SpawnPlayer_FunctionParams
		{
			// Token: 0x04031EB6 RID: 204470
			[FieldOffset(0)]
			public IntPtr Data;

			// Token: 0x04031EB7 RID: 204471
			[FieldOffset(8)]
			public IntPtr OutputPlayer;
		}

		// Token: 0x02009878 RID: 39032
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetScreenEffectCoverLoadingRoot_FunctionParams
		{
			// Token: 0x04031EB8 RID: 204472
			[FieldOffset(0)]
			public IntPtr ScreenEffectCoverLoadingRoot;
		}

		// Token: 0x02009879 RID: 39033
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetScreenEffectGeneralRoot_FunctionParams
		{
			// Token: 0x04031EB9 RID: 204473
			[FieldOffset(0)]
			public IntPtr ScreenEffectGeneralRoot;
		}

		// Token: 0x0200987A RID: 39034
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetScreenEffectPlotRoot_FunctionParams
		{
			// Token: 0x04031EBA RID: 204474
			[FieldOffset(0)]
			public IntPtr ScreenEffectPlotRoot;
		}

		// Token: 0x0200987B RID: 39035
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetScreenEffectFightRoot_FunctionParams
		{
			// Token: 0x04031EBB RID: 204475
			[FieldOffset(0)]
			public IntPtr ScreenEffectFightRoot;
		}

		// Token: 0x0200987C RID: 39036
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __SetVisibilityOfSystem_FunctionParams
		{
			// Token: 0x04031EBC RID: 204476
			[FieldOffset(0)]
			public bool Visibility;

			// Token: 0x04031EBD RID: 204477
			[FieldOffset(1)]
			public bool bOverrideFadeSpeed;

			// Token: 0x04031EBE RID: 204478
			[FieldOffset(4)]
			public float OverrideFadeSpeed;
		}

		// Token: 0x0200987D RID: 39037
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __EndScreenEffect_FunctionParams
		{
			// Token: 0x04031EBF RID: 204479
			[FieldOffset(0)]
			public IntPtr Data;
		}

		// Token: 0x0200987E RID: 39038
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __PlayScreenEffectNoPaused_FunctionParams
		{
			// Token: 0x04031EC0 RID: 204480
			[FieldOffset(0)]
			public IntPtr Data;
		}

		// Token: 0x0200987F RID: 39039
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __PlayScreenEffect_FunctionParams
		{
			// Token: 0x04031EC1 RID: 204481
			[FieldOffset(0)]
			public IntPtr Data;
		}

		// Token: 0x02009880 RID: 39040
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 160)]
		protected ref struct __AddEffect_FunctionParams
		{
			// Token: 0x04031EC2 RID: 204482
			[FieldOffset(0)]
			public IntPtr Data;

			// Token: 0x04031EC3 RID: 204483
			[FieldOffset(8)]
			public bool TickWhenPaused;

			// Token: 0x04031EC4 RID: 204484
			[FieldOffset(16)]
			public IntPtr EffectPlayer;
		}

		// Token: 0x02009881 RID: 39041
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031EC5 RID: 204485
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009882 RID: 39042
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_ScreenEffectSystem_FunctionParams
		{
			// Token: 0x04031EC6 RID: 204486
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
