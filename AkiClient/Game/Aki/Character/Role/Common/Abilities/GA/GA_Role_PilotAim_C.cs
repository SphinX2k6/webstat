using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x020040B3 RID: 16563
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotAim.GA_Role_PilotAim_C")]
	[UnrealStructLayout(1584, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1584)]
	public class GA_Role_PilotAim_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B33A RID: 176954 RVA: 0x00A7412F File Offset: 0x00A7232F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_PilotAim_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotAim.GA_Role_PilotAim_C");
			}
			return GA_Role_PilotAim_C._ClassPtr;
		}

		// Token: 0x0602B33B RID: 176955 RVA: 0x00A74154 File Offset: 0x00A72354
		public GA_Role_PilotAim_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotAim_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B33C RID: 176956 RVA: 0x00A7417C File Offset: 0x00A7237C
		[NullableContext(1)]
		public GA_Role_PilotAim_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_PilotAim_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007107 RID: 28935
		// (get) Token: 0x0602B33D RID: 176957 RVA: 0x00A741B0 File Offset: 0x00A723B0
		// (set) Token: 0x0602B33E RID: 176958 RVA: 0x00A741E9 File Offset: 0x00A723E9
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007108 RID: 28936
		// (get) Token: 0x0602B33F RID: 176959 RVA: 0x00A7420A File Offset: 0x00A7240A
		// (set) Token: 0x0602B340 RID: 176960 RVA: 0x00A7421E File Offset: 0x00A7241E
		public unsafe TsBaseCharacter 施法者_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007109 RID: 28937
		// (get) Token: 0x0602B341 RID: 176961 RVA: 0x00A74233 File Offset: 0x00A72433
		// (set) Token: 0x0602B342 RID: 176962 RVA: 0x00A74247 File Offset: 0x00A72447
		public unsafe USkeletalMeshComponent PilotSkeletal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700710A RID: 28938
		// (get) Token: 0x0602B343 RID: 176963 RVA: 0x00A7425C File Offset: 0x00A7245C
		// (set) Token: 0x0602B344 RID: 176964 RVA: 0x00A7426C File Offset: 0x00A7246C
		public unsafe bool IsThrow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700710B RID: 28939
		// (get) Token: 0x0602B345 RID: 176965 RVA: 0x00A7427D File Offset: 0x00A7247D
		// (set) Token: 0x0602B346 RID: 176966 RVA: 0x00A7428D File Offset: 0x00A7248D
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700710C RID: 28940
		// (get) Token: 0x0602B347 RID: 176967 RVA: 0x00A7429E File Offset: 0x00A7249E
		// (set) Token: 0x0602B348 RID: 176968 RVA: 0x00A742AE File Offset: 0x00A724AE
		public unsafe int 终点特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700710D RID: 28941
		// (get) Token: 0x0602B349 RID: 176969 RVA: 0x00A742BF File Offset: 0x00A724BF
		// (set) Token: 0x0602B34A RID: 176970 RVA: 0x00A742D3 File Offset: 0x00A724D3
		public unsafe UGameplayTask_WaitDelay tickTask
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UGameplayTask_WaitDelay>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700710E RID: 28942
		// (get) Token: 0x0602B34B RID: 176971 RVA: 0x00A742E8 File Offset: 0x00A724E8
		// (set) Token: 0x0602B34C RID: 176972 RVA: 0x00A742FC File Offset: 0x00A724FC
		public unsafe FVector LaunchVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700710F RID: 28943
		// (get) Token: 0x0602B34D RID: 176973 RVA: 0x00A74311 File Offset: 0x00A72511
		// (set) Token: 0x0602B34E RID: 176974 RVA: 0x00A74325 File Offset: 0x00A72525
		public unsafe FVectorDouble CurrentActivePoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Role_PilotAim_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007110 RID: 28944
		// (get) Token: 0x0602B34F RID: 176975 RVA: 0x00A7433A File Offset: 0x00A7253A
		// (set) Token: 0x0602B350 RID: 176976 RVA: 0x00A7434E File Offset: 0x00A7254E
		public unsafe AActor TargetPointEffect
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17007111 RID: 28945
		// (get) Token: 0x0602B351 RID: 176977 RVA: 0x00A74363 File Offset: 0x00A72563
		// (set) Token: 0x0602B352 RID: 176978 RVA: 0x00A74377 File Offset: 0x00A72577
		public unsafe AActor HookLockPoint
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_PilotAim_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x0602B353 RID: 176979 RVA: 0x00A7438C File Offset: 0x00A7258C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void RemoveTags(ref TArray<FGameplayTag> TagsArray)
		{
			GA_Role_PilotAim_C.__RemoveTags_FunctionParams* ptr = stackalloc GA_Role_PilotAim_C.__RemoveTags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Role_PilotAim_C.__RemoveTags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_C.__RemoveTags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = TagsArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TagsArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__RemoveTags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = TagsArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->TagsArray);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotAim_C.__RemoveTags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B354 RID: 176980 RVA: 0x00A74404 File Offset: 0x00A72604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Tick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__Tick_NativeFunctionPtr, null);
		}

		// Token: 0x0602B355 RID: 176981 RVA: 0x00A74418 File Offset: 0x00A72618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onEndAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__onEndAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B356 RID: 176982 RVA: 0x00A7442C File Offset: 0x00A7262C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void onBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__onBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602B357 RID: 176983 RVA: 0x00A74440 File Offset: 0x00A72640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AimStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__AimStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602B358 RID: 176984 RVA: 0x00A74454 File Offset: 0x00A72654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88B8D48972(FGameplayEventData Payload)
		{
			GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD88B8D48972_FunctionParams* ptr = stackalloc GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD88B8D48972_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD88B8D48972_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD88B8D48972_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD88B8D48972_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD88B8D48972_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B359 RID: 176985 RVA: 0x00A744CC File Offset: 0x00A726CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD884EA1D0C2(FGameplayEventData Payload)
		{
			GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD884EA1D0C2_FunctionParams* ptr = stackalloc GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD884EA1D0C2_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD884EA1D0C2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD884EA1D0C2_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD884EA1D0C2_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Role_PilotAim_C.__EventReceived_18B59F5945020DB23C42FD884EA1D0C2_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B35A RID: 176986 RVA: 0x00A74541 File Offset: 0x00A72741
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8144699D25()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__OnTick_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr, null);
		}

		// Token: 0x0602B35B RID: 176987 RVA: 0x00A74555 File Offset: 0x00A72755
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8144699D25()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__OnCancelled_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr, null);
		}

		// Token: 0x0602B35C RID: 176988 RVA: 0x00A74569 File Offset: 0x00A72769
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8144699D25()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__OnInterrupted_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr, null);
		}

		// Token: 0x0602B35D RID: 176989 RVA: 0x00A7457D File Offset: 0x00A7277D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8144699D25()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__OnBlendOut_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr, null);
		}

		// Token: 0x0602B35E RID: 176990 RVA: 0x00A74591 File Offset: 0x00A72791
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8144699D25()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__OnCompleted_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr, null);
		}

		// Token: 0x0602B35F RID: 176991 RVA: 0x00A745A5 File Offset: 0x00A727A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_958341B04E4B696F06B9C19308490A2D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__OnFinish_958341B04E4B696F06B9C19308490A2D_NativeFunctionPtr, null);
		}

		// Token: 0x0602B360 RID: 176992 RVA: 0x00A745B9 File Offset: 0x00A727B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B361 RID: 176993 RVA: 0x00A745CD File Offset: 0x00A727CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotAim_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B362 RID: 176994 RVA: 0x00A745E4 File Offset: 0x00A727E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_PilotAim_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotAim_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotAim_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B363 RID: 176995 RVA: 0x00A7462C File Offset: 0x00A7282C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_PilotAim_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_PilotAim_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_PilotAim_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotAim_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B364 RID: 176996 RVA: 0x00A74673 File Offset: 0x00A72873
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlayMontage()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_PilotAim_C.__PlayMontage_NativeFunctionPtr, null);
		}

		// Token: 0x0602B365 RID: 176997 RVA: 0x00A74688 File Offset: 0x00A72888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_PilotAim(int EntryPoint)
		{
			GA_Role_PilotAim_C.__ExecuteUbergraph_GA_Role_PilotAim_FunctionParams* ptr = stackalloc GA_Role_PilotAim_C.__ExecuteUbergraph_GA_Role_PilotAim_FunctionParams[(UIntPtr)1871] + 15L / (long)sizeof(GA_Role_PilotAim_C.__ExecuteUbergraph_GA_Role_PilotAim_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_PilotAim_C.__ExecuteUbergraph_GA_Role_PilotAim_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_PilotAim_C.__ExecuteUbergraph_GA_Role_PilotAim_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B366 RID: 176998 RVA: 0x00A746D2 File Offset: 0x00A728D2
		protected GA_Role_PilotAim_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A7F RID: 96895
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_PilotAim.GA_Role_PilotAim_C";

		// Token: 0x04017A80 RID: 96896
		private static IntPtr _ClassPtr;

		// Token: 0x04017A81 RID: 96897
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A82 RID: 96898
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A83 RID: 96899
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A84 RID: 96900
		internal new static int __PropertyOffset_1;

		// Token: 0x04017A85 RID: 96901
		internal new static int __PropertyOffset_2;

		// Token: 0x04017A86 RID: 96902
		internal new static int __PropertyOffset_3;

		// Token: 0x04017A87 RID: 96903
		internal static int __PropertyOffset_4;

		// Token: 0x04017A88 RID: 96904
		internal static int __PropertyOffset_5;

		// Token: 0x04017A89 RID: 96905
		internal static int __PropertyOffset_6;

		// Token: 0x04017A8A RID: 96906
		internal static int __PropertyOffset_7;

		// Token: 0x04017A8B RID: 96907
		internal static int __PropertyOffset_8;

		// Token: 0x04017A8C RID: 96908
		internal static int __PropertyOffset_9;

		// Token: 0x04017A8D RID: 96909
		internal static int __PropertyOffset_10;

		// Token: 0x04017A8E RID: 96910
		private static IntPtr __RemoveTags_NativeFunctionPtr;

		// Token: 0x04017A8F RID: 96911
		private static IntPtr __Tick_NativeFunctionPtr;

		// Token: 0x04017A90 RID: 96912
		private static IntPtr __onEndAbility_NativeFunctionPtr;

		// Token: 0x04017A91 RID: 96913
		private static IntPtr __onBegin_NativeFunctionPtr;

		// Token: 0x04017A92 RID: 96914
		private static IntPtr __AimStart_NativeFunctionPtr;

		// Token: 0x04017A93 RID: 96915
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88B8D48972_NativeFunctionPtr;

		// Token: 0x04017A94 RID: 96916
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD884EA1D0C2_NativeFunctionPtr;

		// Token: 0x04017A95 RID: 96917
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr;

		// Token: 0x04017A96 RID: 96918
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr;

		// Token: 0x04017A97 RID: 96919
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr;

		// Token: 0x04017A98 RID: 96920
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr;

		// Token: 0x04017A99 RID: 96921
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8144699D25_NativeFunctionPtr;

		// Token: 0x04017A9A RID: 96922
		private static IntPtr __OnFinish_958341B04E4B696F06B9C19308490A2D_NativeFunctionPtr;

		// Token: 0x04017A9B RID: 96923
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A9C RID: 96924
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A9D RID: 96925
		private static IntPtr __PlayMontage_NativeFunctionPtr;

		// Token: 0x04017A9E RID: 96926
		private static IntPtr __ExecuteUbergraph_GA_Role_PilotAim_NativeFunctionPtr;

		// Token: 0x0200A327 RID: 41767
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __RemoveTags_FunctionParams
		{
			// Token: 0x040330FC RID: 209148
			[FieldOffset(0)]
			public byte TagsArray;
		}

		// Token: 0x0200A328 RID: 41768
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88B8D48972_FunctionParams
		{
			// Token: 0x040330FD RID: 209149
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A329 RID: 41769
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD884EA1D0C2_FunctionParams
		{
			// Token: 0x040330FE RID: 209150
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A32A RID: 41770
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330FF RID: 209151
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A32B RID: 41771
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1856)]
		protected ref struct __ExecuteUbergraph_GA_Role_PilotAim_FunctionParams
		{
			// Token: 0x04033100 RID: 209152
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
