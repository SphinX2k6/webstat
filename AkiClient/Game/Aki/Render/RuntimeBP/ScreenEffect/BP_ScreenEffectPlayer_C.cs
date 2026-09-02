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
	// Token: 0x02003A65 RID: 14949
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectPlayer.BP_ScreenEffectPlayer_C")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1161)]
	public class BP_ScreenEffectPlayer_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F207 RID: 127495 RVA: 0x00908718 File Offset: 0x00906918
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ScreenEffectPlayer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectPlayer.BP_ScreenEffectPlayer_C");
			}
			return BP_ScreenEffectPlayer_C._ClassPtr;
		}

		// Token: 0x0601F208 RID: 127496 RVA: 0x0090873C File Offset: 0x0090693C
		public BP_ScreenEffectPlayer_C() : this(BuiltinUtils.AllocNativeUObject(BP_ScreenEffectPlayer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F209 RID: 127497 RVA: 0x00908764 File Offset: 0x00906964
		[NullableContext(1)]
		public BP_ScreenEffectPlayer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ScreenEffectPlayer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E3B RID: 11835
		// (get) Token: 0x0601F20A RID: 127498 RVA: 0x00908798 File Offset: 0x00906998
		// (set) Token: 0x0601F20B RID: 127499 RVA: 0x009087D1 File Offset: 0x009069D1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E3C RID: 11836
		// (get) Token: 0x0601F20C RID: 127500 RVA: 0x009087F2 File Offset: 0x009069F2
		// (set) Token: 0x0601F20D RID: 127501 RVA: 0x00908806 File Offset: 0x00906A06
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E3D RID: 11837
		// (get) Token: 0x0601F20E RID: 127502 RVA: 0x0090881B File Offset: 0x00906A1B
		// (set) Token: 0x0601F20F RID: 127503 RVA: 0x0090882F File Offset: 0x00906A2F
		[Nullable(2)]
		public unsafe EffectScreenPlayData_C Data
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<EffectScreenPlayData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002E3E RID: 11838
		// (get) Token: 0x0601F210 RID: 127504 RVA: 0x00908844 File Offset: 0x00906A44
		// (set) Token: 0x0601F211 RID: 127505 RVA: 0x00908858 File Offset: 0x00906A58
		public unsafe TEnumAsByte<E_SE_PlayState> State
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002E3F RID: 11839
		// (get) Token: 0x0601F212 RID: 127506 RVA: 0x0090886D File Offset: 0x00906A6D
		// (set) Token: 0x0601F213 RID: 127507 RVA: 0x0090887D File Offset: 0x00906A7D
		public unsafe float TimeCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002E40 RID: 11840
		// (get) Token: 0x0601F214 RID: 127508 RVA: 0x0090888E File Offset: 0x00906A8E
		// (set) Token: 0x0601F215 RID: 127509 RVA: 0x009088A2 File Offset: 0x00906AA2
		[Nullable(2)]
		public unsafe AActor TargetActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002E41 RID: 11841
		// (get) Token: 0x0601F216 RID: 127510 RVA: 0x009088B8 File Offset: 0x00906AB8
		// (set) Token: 0x0601F217 RID: 127511 RVA: 0x009088F1 File Offset: 0x00906AF1
		[Nullable(1)]
		public TArray<UActorComponent> CachedComponents
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UActorComponent> result;
				if ((result = this._CachedComponents) == null)
				{
					result = (this._CachedComponents = new TArray<UActorComponent>(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CachedComponents.CopyAssign(value);
			}
		}

		// Token: 0x17002E42 RID: 11842
		// (get) Token: 0x0601F218 RID: 127512 RVA: 0x009088FF File Offset: 0x00906AFF
		// (set) Token: 0x0601F219 RID: 127513 RVA: 0x0090890F File Offset: 0x00906B0F
		public unsafe bool bToHide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E43 RID: 11843
		// (get) Token: 0x0601F21A RID: 127514 RVA: 0x00908920 File Offset: 0x00906B20
		// (set) Token: 0x0601F21B RID: 127515 RVA: 0x00908930 File Offset: 0x00906B30
		public unsafe float Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002E44 RID: 11844
		// (get) Token: 0x0601F21C RID: 127516 RVA: 0x00908941 File Offset: 0x00906B41
		// (set) Token: 0x0601F21D RID: 127517 RVA: 0x00908951 File Offset: 0x00906B51
		public unsafe float FadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17002E45 RID: 11845
		// (get) Token: 0x0601F21E RID: 127518 RVA: 0x00908962 File Offset: 0x00906B62
		// (set) Token: 0x0601F21F RID: 127519 RVA: 0x00908972 File Offset: 0x00906B72
		public unsafe float FadeOutSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002E46 RID: 11846
		// (get) Token: 0x0601F220 RID: 127520 RVA: 0x00908984 File Offset: 0x00906B84
		// (set) Token: 0x0601F221 RID: 127521 RVA: 0x009089BD File Offset: 0x00906BBD
		[Nullable(1)]
		public TArray<AActor> CachedUIActors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._CachedUIActors) == null)
				{
					result = (this._CachedUIActors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CachedUIActors.CopyAssign(value);
			}
		}

		// Token: 0x17002E47 RID: 11847
		// (get) Token: 0x0601F222 RID: 127522 RVA: 0x009089CB File Offset: 0x00906BCB
		// (set) Token: 0x0601F223 RID: 127523 RVA: 0x009089DB File Offset: 0x00906BDB
		public unsafe bool bVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E48 RID: 11848
		// (get) Token: 0x0601F224 RID: 127524 RVA: 0x009089EC File Offset: 0x00906BEC
		// (set) Token: 0x0601F225 RID: 127525 RVA: 0x00908A00 File Offset: 0x00906C00
		[Nullable(2)]
		public unsafe AUIContainerActor ScreenEffectRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUIContainerActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_13);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ScreenEffectPlayer_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002E49 RID: 11849
		// (get) Token: 0x0601F226 RID: 127526 RVA: 0x00908A15 File Offset: 0x00906C15
		// (set) Token: 0x0601F227 RID: 127527 RVA: 0x00908A25 File Offset: 0x00906C25
		public unsafe bool bNeedToDestroy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E4A RID: 11850
		// (get) Token: 0x0601F228 RID: 127528 RVA: 0x00908A36 File Offset: 0x00906C36
		// (set) Token: 0x0601F229 RID: 127529 RVA: 0x00908A46 File Offset: 0x00906C46
		public unsafe float CacheEnvironmentFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002E4B RID: 11851
		// (get) Token: 0x0601F22A RID: 127530 RVA: 0x00908A57 File Offset: 0x00906C57
		// (set) Token: 0x0601F22B RID: 127531 RVA: 0x00908A67 File Offset: 0x00906C67
		public unsafe float ParameterTweenProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002E4C RID: 11852
		// (get) Token: 0x0601F22C RID: 127532 RVA: 0x00908A78 File Offset: 0x00906C78
		// (set) Token: 0x0601F22D RID: 127533 RVA: 0x00908A88 File Offset: 0x00906C88
		public unsafe float ParameterTweenSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002E4D RID: 11853
		// (get) Token: 0x0601F22E RID: 127534 RVA: 0x00908A99 File Offset: 0x00906C99
		// (set) Token: 0x0601F22F RID: 127535 RVA: 0x00908AA9 File Offset: 0x00906CA9
		public unsafe float ParameterTweenTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17002E4E RID: 11854
		// (get) Token: 0x0601F230 RID: 127536 RVA: 0x00908ABA File Offset: 0x00906CBA
		// (set) Token: 0x0601F231 RID: 127537 RVA: 0x00908ACA File Offset: 0x00906CCA
		public unsafe float NiagaraFrameDeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002E4F RID: 11855
		// (get) Token: 0x0601F232 RID: 127538 RVA: 0x00908ADB File Offset: 0x00906CDB
		// (set) Token: 0x0601F233 RID: 127539 RVA: 0x00908AEB File Offset: 0x00906CEB
		public unsafe bool NiagaraFrameDeltaTimeDirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_ScreenEffectPlayer_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F234 RID: 127540 RVA: 0x00908AFC File Offset: 0x00906CFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetNiagaraFrameDeltaTime(float DeltaTime)
		{
			BP_ScreenEffectPlayer_C.__SetNiagaraFrameDeltaTime_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__SetNiagaraFrameDeltaTime_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__SetNiagaraFrameDeltaTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__SetNiagaraFrameDeltaTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__SetNiagaraFrameDeltaTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F235 RID: 127541 RVA: 0x00908B44 File Offset: 0x00906D44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AlmostEqual(float val1, float val2, ref bool isequal)
		{
			BP_ScreenEffectPlayer_C.__AlmostEqual_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__AlmostEqual_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__AlmostEqual_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__AlmostEqual_NativeFunctionPtr, (void*)ptr, 1);
			ptr->val1 = val1;
			ptr->val2 = val2;
			ptr->isequal = isequal;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__AlmostEqual_NativeFunctionPtr, (void*)ptr);
			isequal = ptr->isequal;
		}

		// Token: 0x0601F236 RID: 127542 RVA: 0x00908BA4 File Offset: 0x00906DA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetExtraState(int ExtraState)
		{
			BP_ScreenEffectPlayer_C.__SetExtraState_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__SetExtraState_FunctionParams[(UIntPtr)255] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__SetExtraState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__SetExtraState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ExtraState = ExtraState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__SetExtraState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F237 RID: 127543 RVA: 0x00908BF0 File Offset: 0x00906DF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Refresh_Addition_Parameter(float TweenProgress)
		{
			BP_ScreenEffectPlayer_C.__Refresh_Addition_Parameter_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__Refresh_Addition_Parameter_FunctionParams[(UIntPtr)911] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__Refresh_Addition_Parameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__Refresh_Addition_Parameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TweenProgress = TweenProgress;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__Refresh_Addition_Parameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F238 RID: 127544 RVA: 0x00908C3C File Offset: 0x00906E3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TweenParameterSpeed(float TweenTarget, float TweenSpeed, float TweenDeltaSecond)
		{
			BP_ScreenEffectPlayer_C.__TweenParameterSpeed_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__TweenParameterSpeed_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__TweenParameterSpeed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__TweenParameterSpeed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TweenTarget = TweenTarget;
			ptr->TweenSpeed = TweenSpeed;
			ptr->TweenDeltaSecond = TweenDeltaSecond;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__TweenParameterSpeed_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F239 RID: 127545 RVA: 0x00908C90 File Offset: 0x00906E90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BP_ScreenEffectPlayer_AutoGenFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__BP_ScreenEffectPlayer_AutoGenFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601F23A RID: 127546 RVA: 0x00908CA4 File Offset: 0x00906EA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DelayEndAudioCall()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__DelayEndAudioCall_NativeFunctionPtr, null);
		}

		// Token: 0x0601F23B RID: 127547 RVA: 0x00908CB8 File Offset: 0x00906EB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdatePlayerSEEnvironmentFactor(float EnvironmentFactor)
		{
			BP_ScreenEffectPlayer_C.__UpdatePlayerSEEnvironmentFactor_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__UpdatePlayerSEEnvironmentFactor_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__UpdatePlayerSEEnvironmentFactor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__UpdatePlayerSEEnvironmentFactor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EnvironmentFactor = EnvironmentFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__UpdatePlayerSEEnvironmentFactor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F23C RID: 127548 RVA: 0x00908D01 File Offset: 0x00906F01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Destroy_Player()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__Destroy_Player_NativeFunctionPtr, null);
		}

		// Token: 0x0601F23D RID: 127549 RVA: 0x00908D15 File Offset: 0x00906F15
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearPlayer()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ClearPlayer_NativeFunctionPtr, null);
		}

		// Token: 0x0601F23E RID: 127550 RVA: 0x00908D2C File Offset: 0x00906F2C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitPlayer(EffectScreenPlayData_C Data, AUIContainerActor ScreenEffectRoot)
		{
			BP_ScreenEffectPlayer_C.__InitPlayer_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__InitPlayer_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__InitPlayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__InitPlayer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Data = ((Data != null) ? Data.NativePtr : IntPtr.Zero);
			ptr->ScreenEffectRoot = ((ScreenEffectRoot != null) ? ScreenEffectRoot.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__InitPlayer_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F23F RID: 127551 RVA: 0x00908D97 File Offset: 0x00906F97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BeforeStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__BeforeStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601F240 RID: 127552 RVA: 0x00908DAC File Offset: 0x00906FAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Effect_Hidden(bool bToHide, bool bOverrideFadeSpeed, float OverrideFadeSpeed)
		{
			BP_ScreenEffectPlayer_C.__Set_Effect_Hidden_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__Set_Effect_Hidden_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__Set_Effect_Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__Set_Effect_Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bToHide = bToHide;
			ptr->bOverrideFadeSpeed = bOverrideFadeSpeed;
			ptr->OverrideFadeSpeed = OverrideFadeSpeed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__Set_Effect_Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F241 RID: 127553 RVA: 0x00908E00 File Offset: 0x00907000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetUIVisible(bool Visible)
		{
			BP_ScreenEffectPlayer_C.__SetUIVisible_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__SetUIVisible_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__SetUIVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__SetUIVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Visible = Visible;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__SetUIVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F242 RID: 127554 RVA: 0x00908E46 File Offset: 0x00907046
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateComponentsAlpha()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__UpdateComponentsAlpha_NativeFunctionPtr, null);
		}

		// Token: 0x0601F243 RID: 127555 RVA: 0x00908E5A File Offset: 0x0090705A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateComponents()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__UpdateComponents_NativeFunctionPtr, null);
		}

		// Token: 0x0601F244 RID: 127556 RVA: 0x00908E6E File Offset: 0x0090706E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndPlayer()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__EndPlayer_NativeFunctionPtr, null);
		}

		// Token: 0x0601F245 RID: 127557 RVA: 0x00908E82 File Offset: 0x00907082
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start_Player()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__Start_Player_NativeFunctionPtr, null);
		}

		// Token: 0x0601F246 RID: 127558 RVA: 0x00908E98 File Offset: 0x00907098
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TweenParameter(float TweenTarget)
		{
			BP_ScreenEffectPlayer_C.__TweenParameter_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__TweenParameter_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__TweenParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__TweenParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TweenTarget = TweenTarget;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__TweenParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F247 RID: 127559 RVA: 0x00908EE0 File Offset: 0x009070E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TweenParameterImmediately(float TweenTarget)
		{
			BP_ScreenEffectPlayer_C.__TweenParameterImmediately_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__TweenParameterImmediately_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__TweenParameterImmediately_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__TweenParameterImmediately_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TweenTarget = TweenTarget;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__TweenParameterImmediately_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F248 RID: 127560 RVA: 0x00908F26 File Offset: 0x00907126
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F249 RID: 127561 RVA: 0x00908F3A File Offset: 0x0090713A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F24A RID: 127562 RVA: 0x00908F4F File Offset: 0x0090714F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F24B RID: 127563 RVA: 0x00908F63 File Offset: 0x00907163
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F24C RID: 127564 RVA: 0x00908F78 File Offset: 0x00907178
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_ScreenEffectPlayer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F24D RID: 127565 RVA: 0x00908FC0 File Offset: 0x009071C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_ScreenEffectPlayer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F24E RID: 127566 RVA: 0x00909008 File Offset: 0x00907208
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_ScreenEffectPlayer_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F24F RID: 127567 RVA: 0x00909054 File Offset: 0x00907254
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_ScreenEffectPlayer_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F250 RID: 127568 RVA: 0x009090A0 File Offset: 0x009072A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ScreenEffectPlayer(int EntryPoint)
		{
			BP_ScreenEffectPlayer_C.__ExecuteUbergraph_BP_ScreenEffectPlayer_FunctionParams* ptr = stackalloc BP_ScreenEffectPlayer_C.__ExecuteUbergraph_BP_ScreenEffectPlayer_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_ScreenEffectPlayer_C.__ExecuteUbergraph_BP_ScreenEffectPlayer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ScreenEffectPlayer_C.__ExecuteUbergraph_BP_ScreenEffectPlayer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ScreenEffectPlayer_C.__ExecuteUbergraph_BP_ScreenEffectPlayer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F251 RID: 127569 RVA: 0x009090EA File Offset: 0x009072EA
		protected BP_ScreenEffectPlayer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F6A1 RID: 63137
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/BP_ScreenEffectPlayer.BP_ScreenEffectPlayer_C";

		// Token: 0x0400F6A2 RID: 63138
		private static IntPtr _ClassPtr;

		// Token: 0x0400F6A3 RID: 63139
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F6A4 RID: 63140
		internal static int __PropertyOffset_0;

		// Token: 0x0400F6A5 RID: 63141
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F6A6 RID: 63142
		internal static int __PropertyOffset_1;

		// Token: 0x0400F6A7 RID: 63143
		internal static int __PropertyOffset_2;

		// Token: 0x0400F6A8 RID: 63144
		internal static int __PropertyOffset_3;

		// Token: 0x0400F6A9 RID: 63145
		internal static int __PropertyOffset_4;

		// Token: 0x0400F6AA RID: 63146
		internal static int __PropertyOffset_5;

		// Token: 0x0400F6AB RID: 63147
		internal static int __PropertyOffset_6;

		// Token: 0x0400F6AC RID: 63148
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UActorComponent> _CachedComponents;

		// Token: 0x0400F6AD RID: 63149
		internal static int __PropertyOffset_7;

		// Token: 0x0400F6AE RID: 63150
		internal static int __PropertyOffset_8;

		// Token: 0x0400F6AF RID: 63151
		internal static int __PropertyOffset_9;

		// Token: 0x0400F6B0 RID: 63152
		internal static int __PropertyOffset_10;

		// Token: 0x0400F6B1 RID: 63153
		internal static int __PropertyOffset_11;

		// Token: 0x0400F6B2 RID: 63154
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _CachedUIActors;

		// Token: 0x0400F6B3 RID: 63155
		internal static int __PropertyOffset_12;

		// Token: 0x0400F6B4 RID: 63156
		internal static int __PropertyOffset_13;

		// Token: 0x0400F6B5 RID: 63157
		internal static int __PropertyOffset_14;

		// Token: 0x0400F6B6 RID: 63158
		internal static int __PropertyOffset_15;

		// Token: 0x0400F6B7 RID: 63159
		internal static int __PropertyOffset_16;

		// Token: 0x0400F6B8 RID: 63160
		internal static int __PropertyOffset_17;

		// Token: 0x0400F6B9 RID: 63161
		internal static int __PropertyOffset_18;

		// Token: 0x0400F6BA RID: 63162
		internal static int __PropertyOffset_19;

		// Token: 0x0400F6BB RID: 63163
		internal static int __PropertyOffset_20;

		// Token: 0x0400F6BC RID: 63164
		private static IntPtr __SetNiagaraFrameDeltaTime_NativeFunctionPtr;

		// Token: 0x0400F6BD RID: 63165
		private static IntPtr __AlmostEqual_NativeFunctionPtr;

		// Token: 0x0400F6BE RID: 63166
		private static IntPtr __SetExtraState_NativeFunctionPtr;

		// Token: 0x0400F6BF RID: 63167
		private static IntPtr __Refresh_Addition_Parameter_NativeFunctionPtr;

		// Token: 0x0400F6C0 RID: 63168
		private static IntPtr __TweenParameterSpeed_NativeFunctionPtr;

		// Token: 0x0400F6C1 RID: 63169
		private static IntPtr __BP_ScreenEffectPlayer_AutoGenFunc_NativeFunctionPtr;

		// Token: 0x0400F6C2 RID: 63170
		private static IntPtr __DelayEndAudioCall_NativeFunctionPtr;

		// Token: 0x0400F6C3 RID: 63171
		private static IntPtr __UpdatePlayerSEEnvironmentFactor_NativeFunctionPtr;

		// Token: 0x0400F6C4 RID: 63172
		private static IntPtr __Destroy_Player_NativeFunctionPtr;

		// Token: 0x0400F6C5 RID: 63173
		private static IntPtr __ClearPlayer_NativeFunctionPtr;

		// Token: 0x0400F6C6 RID: 63174
		private static IntPtr __InitPlayer_NativeFunctionPtr;

		// Token: 0x0400F6C7 RID: 63175
		private static IntPtr __BeforeStart_NativeFunctionPtr;

		// Token: 0x0400F6C8 RID: 63176
		private static IntPtr __Set_Effect_Hidden_NativeFunctionPtr;

		// Token: 0x0400F6C9 RID: 63177
		private static IntPtr __SetUIVisible_NativeFunctionPtr;

		// Token: 0x0400F6CA RID: 63178
		private static IntPtr __UpdateComponentsAlpha_NativeFunctionPtr;

		// Token: 0x0400F6CB RID: 63179
		private static IntPtr __UpdateComponents_NativeFunctionPtr;

		// Token: 0x0400F6CC RID: 63180
		private static IntPtr __EndPlayer_NativeFunctionPtr;

		// Token: 0x0400F6CD RID: 63181
		private static IntPtr __Start_Player_NativeFunctionPtr;

		// Token: 0x0400F6CE RID: 63182
		private static IntPtr __TweenParameter_NativeFunctionPtr;

		// Token: 0x0400F6CF RID: 63183
		private static IntPtr __TweenParameterImmediately_NativeFunctionPtr;

		// Token: 0x0400F6D0 RID: 63184
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F6D1 RID: 63185
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F6D2 RID: 63186
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F6D3 RID: 63187
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F6D4 RID: 63188
		private static IntPtr __ExecuteUbergraph_BP_ScreenEffectPlayer_NativeFunctionPtr;

		// Token: 0x02009864 RID: 39012
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetNiagaraFrameDeltaTime_FunctionParams
		{
			// Token: 0x04031E99 RID: 204441
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009865 RID: 39013
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AlmostEqual_FunctionParams
		{
			// Token: 0x04031E9A RID: 204442
			[FieldOffset(0)]
			public float val1;

			// Token: 0x04031E9B RID: 204443
			[FieldOffset(4)]
			public float val2;

			// Token: 0x04031E9C RID: 204444
			[FieldOffset(8)]
			public bool isequal;
		}

		// Token: 0x02009866 RID: 39014
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 240)]
		protected ref struct __SetExtraState_FunctionParams
		{
			// Token: 0x04031E9D RID: 204445
			[FieldOffset(0)]
			public int ExtraState;
		}

		// Token: 0x02009867 RID: 39015
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 896)]
		protected ref struct __Refresh_Addition_Parameter_FunctionParams
		{
			// Token: 0x04031E9E RID: 204446
			[FieldOffset(0)]
			public float TweenProgress;
		}

		// Token: 0x02009868 RID: 39016
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __TweenParameterSpeed_FunctionParams
		{
			// Token: 0x04031E9F RID: 204447
			[FieldOffset(0)]
			public float TweenTarget;

			// Token: 0x04031EA0 RID: 204448
			[FieldOffset(4)]
			public float TweenSpeed;

			// Token: 0x04031EA1 RID: 204449
			[FieldOffset(8)]
			public float TweenDeltaSecond;
		}

		// Token: 0x02009869 RID: 39017
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __UpdatePlayerSEEnvironmentFactor_FunctionParams
		{
			// Token: 0x04031EA2 RID: 204450
			[FieldOffset(0)]
			public float EnvironmentFactor;
		}

		// Token: 0x0200986A RID: 39018
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __InitPlayer_FunctionParams
		{
			// Token: 0x04031EA3 RID: 204451
			[FieldOffset(0)]
			public IntPtr Data;

			// Token: 0x04031EA4 RID: 204452
			[FieldOffset(8)]
			public IntPtr ScreenEffectRoot;
		}

		// Token: 0x0200986B RID: 39019
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __Set_Effect_Hidden_FunctionParams
		{
			// Token: 0x04031EA5 RID: 204453
			[FieldOffset(0)]
			public bool bToHide;

			// Token: 0x04031EA6 RID: 204454
			[FieldOffset(1)]
			public bool bOverrideFadeSpeed;

			// Token: 0x04031EA7 RID: 204455
			[FieldOffset(4)]
			public float OverrideFadeSpeed;
		}

		// Token: 0x0200986C RID: 39020
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __SetUIVisible_FunctionParams
		{
			// Token: 0x04031EA8 RID: 204456
			[FieldOffset(0)]
			public bool Visible;
		}

		// Token: 0x0200986D RID: 39021
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __TweenParameter_FunctionParams
		{
			// Token: 0x04031EA9 RID: 204457
			[FieldOffset(0)]
			public float TweenTarget;
		}

		// Token: 0x0200986E RID: 39022
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __TweenParameterImmediately_FunctionParams
		{
			// Token: 0x04031EAA RID: 204458
			[FieldOffset(0)]
			public float TweenTarget;
		}

		// Token: 0x0200986F RID: 39023
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031EAB RID: 204459
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009870 RID: 39024
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031EAC RID: 204460
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009871 RID: 39025
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_BP_ScreenEffectPlayer_FunctionParams
		{
			// Token: 0x04031EAD RID: 204461
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
