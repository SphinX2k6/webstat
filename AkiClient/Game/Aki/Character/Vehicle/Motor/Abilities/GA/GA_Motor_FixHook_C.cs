using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FCD RID: 16333
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook.GA_Motor_FixHook_C")]
	[UnrealStructLayout(1664, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1656)]
	public class GA_Motor_FixHook_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029035 RID: 167989 RVA: 0x00A1E61F File Offset: 0x00A1C81F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_FixHook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook.GA_Motor_FixHook_C");
			}
			return GA_Motor_FixHook_C._ClassPtr;
		}

		// Token: 0x06029036 RID: 167990 RVA: 0x00A1E644 File Offset: 0x00A1C844
		public GA_Motor_FixHook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FixHook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029037 RID: 167991 RVA: 0x00A1E66C File Offset: 0x00A1C86C
		[NullableContext(1)]
		public GA_Motor_FixHook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FixHook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006510 RID: 25872
		// (get) Token: 0x06029038 RID: 167992 RVA: 0x00A1E6A0 File Offset: 0x00A1C8A0
		// (set) Token: 0x06029039 RID: 167993 RVA: 0x00A1E6D9 File Offset: 0x00A1C8D9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006511 RID: 25873
		// (get) Token: 0x0602903A RID: 167994 RVA: 0x00A1E6FA File Offset: 0x00A1C8FA
		// (set) Token: 0x0602903B RID: 167995 RVA: 0x00A1E70E File Offset: 0x00A1C90E
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006512 RID: 25874
		// (get) Token: 0x0602903C RID: 167996 RVA: 0x00A1E723 File Offset: 0x00A1C923
		// (set) Token: 0x0602903D RID: 167997 RVA: 0x00A1E733 File Offset: 0x00A1C933
		public unsafe int 驾驶员EntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006513 RID: 25875
		// (get) Token: 0x0602903E RID: 167998 RVA: 0x00A1E744 File Offset: 0x00A1C944
		// (set) Token: 0x0602903F RID: 167999 RVA: 0x00A1E758 File Offset: 0x00A1C958
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006514 RID: 25876
		// (get) Token: 0x06029040 RID: 168000 RVA: 0x00A1E76D File Offset: 0x00A1C96D
		// (set) Token: 0x06029041 RID: 168001 RVA: 0x00A1E781 File Offset: 0x00A1C981
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006515 RID: 25877
		// (get) Token: 0x06029042 RID: 168002 RVA: 0x00A1E796 File Offset: 0x00A1C996
		// (set) Token: 0x06029043 RID: 168003 RVA: 0x00A1E7AA File Offset: 0x00A1C9AA
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006516 RID: 25878
		// (get) Token: 0x06029044 RID: 168004 RVA: 0x00A1E7BF File Offset: 0x00A1C9BF
		// (set) Token: 0x06029045 RID: 168005 RVA: 0x00A1E7D3 File Offset: 0x00A1C9D3
		public unsafe FVector 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006517 RID: 25879
		// (get) Token: 0x06029046 RID: 168006 RVA: 0x00A1E7E8 File Offset: 0x00A1C9E8
		// (set) Token: 0x06029047 RID: 168007 RVA: 0x00A1E7F8 File Offset: 0x00A1C9F8
		public unsafe float 牵引速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17006518 RID: 25880
		// (get) Token: 0x06029048 RID: 168008 RVA: 0x00A1E809 File Offset: 0x00A1CA09
		// (set) Token: 0x06029049 RID: 168009 RVA: 0x00A1E819 File Offset: 0x00A1CA19
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006519 RID: 25881
		// (get) Token: 0x0602904A RID: 168010 RVA: 0x00A1E82A File Offset: 0x00A1CA2A
		// (set) Token: 0x0602904B RID: 168011 RVA: 0x00A1E83E File Offset: 0x00A1CA3E
		public unsafe UKuroVehicleMovementComponent VehicleMovementComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVehicleMovementComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700651A RID: 25882
		// (get) Token: 0x0602904C RID: 168012 RVA: 0x00A1E853 File Offset: 0x00A1CA53
		// (set) Token: 0x0602904D RID: 168013 RVA: 0x00A1E863 File Offset: 0x00A1CA63
		public unsafe float Speed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700651B RID: 25883
		// (get) Token: 0x0602904E RID: 168014 RVA: 0x00A1E874 File Offset: 0x00A1CA74
		// (set) Token: 0x0602904F RID: 168015 RVA: 0x00A1E888 File Offset: 0x00A1CA88
		public unsafe UCurveFloat SpeedCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700651C RID: 25884
		// (get) Token: 0x06029050 RID: 168016 RVA: 0x00A1E89D File Offset: 0x00A1CA9D
		// (set) Token: 0x06029051 RID: 168017 RVA: 0x00A1E8B1 File Offset: 0x00A1CAB1
		public unsafe FQuat Target_Quat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700651D RID: 25885
		// (get) Token: 0x06029052 RID: 168018 RVA: 0x00A1E8C6 File Offset: 0x00A1CAC6
		// (set) Token: 0x06029053 RID: 168019 RVA: 0x00A1E8DA File Offset: 0x00A1CADA
		public unsafe UCurveFloat QuatCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700651E RID: 25886
		// (get) Token: 0x06029054 RID: 168020 RVA: 0x00A1E8EF File Offset: 0x00A1CAEF
		// (set) Token: 0x06029055 RID: 168021 RVA: 0x00A1E8FF File Offset: 0x00A1CAFF
		public unsafe float StartDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700651F RID: 25887
		// (get) Token: 0x06029056 RID: 168022 RVA: 0x00A1E910 File Offset: 0x00A1CB10
		// (set) Token: 0x06029057 RID: 168023 RVA: 0x00A1E920 File Offset: 0x00A1CB20
		public unsafe float LastAlphaOnDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006520 RID: 25888
		// (get) Token: 0x06029058 RID: 168024 RVA: 0x00A1E931 File Offset: 0x00A1CB31
		// (set) Token: 0x06029059 RID: 168025 RVA: 0x00A1E941 File Offset: 0x00A1CB41
		public unsafe bool Need_Quat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006521 RID: 25889
		// (get) Token: 0x0602905A RID: 168026 RVA: 0x00A1E952 File Offset: 0x00A1CB52
		// (set) Token: 0x0602905B RID: 168027 RVA: 0x00A1E962 File Offset: 0x00A1CB62
		public unsafe float TimeAtSpeedCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x0602905C RID: 168028 RVA: 0x00A1E973 File Offset: 0x00A1CB73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__FixHookEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602905D RID: 168029 RVA: 0x00A1E988 File Offset: 0x00A1CB88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FixHookTick(bool LocationChange)
		{
			GA_Motor_FixHook_C.__FixHookTick_FunctionParams* ptr = stackalloc GA_Motor_FixHook_C.__FixHookTick_FunctionParams[(UIntPtr)511] + 15L / (long)sizeof(GA_Motor_FixHook_C.__FixHookTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_C.__FixHookTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LocationChange = LocationChange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__FixHookTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602905E RID: 168030 RVA: 0x00A1E9D1 File Offset: 0x00A1CBD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602905F RID: 168031 RVA: 0x00A1E9E8 File Offset: 0x00A1CBE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88D397D2A5(FGameplayEventData Payload)
		{
			GA_Motor_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D397D2A5_FunctionParams* ptr = stackalloc GA_Motor_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D397D2A5_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Motor_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D397D2A5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D397D2A5_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D397D2A5_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Motor_FixHook_C.__EventReceived_18B59F5945020DB23C42FD88D397D2A5_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06029060 RID: 168032 RVA: 0x00A1EA5D File Offset: 0x00A1CC5D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_EA3C560F46E3B3A5CE0B368596110C6B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__OnFinish_EA3C560F46E3B3A5CE0B368596110C6B_NativeFunctionPtr, null);
		}

		// Token: 0x06029061 RID: 168033 RVA: 0x00A1EA71 File Offset: 0x00A1CC71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_EA3C560F46E3B3A5CE0B368596110C6B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__OnTick_EA3C560F46E3B3A5CE0B368596110C6B_NativeFunctionPtr, null);
		}

		// Token: 0x06029062 RID: 168034 RVA: 0x00A1EA85 File Offset: 0x00A1CC85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029063 RID: 168035 RVA: 0x00A1EA99 File Offset: 0x00A1CC99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029064 RID: 168036 RVA: 0x00A1EAB0 File Offset: 0x00A1CCB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_FixHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FixHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FixHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029065 RID: 168037 RVA: 0x00A1EAF8 File Offset: 0x00A1CCF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_FixHook_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FixHook_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FixHook_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029066 RID: 168038 RVA: 0x00A1EB40 File Offset: 0x00A1CD40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_FixHook(int EntryPoint)
		{
			GA_Motor_FixHook_C.__ExecuteUbergraph_GA_Motor_FixHook_FunctionParams* ptr = stackalloc GA_Motor_FixHook_C.__ExecuteUbergraph_GA_Motor_FixHook_FunctionParams[(UIntPtr)623] + 15L / (long)sizeof(GA_Motor_FixHook_C.__ExecuteUbergraph_GA_Motor_FixHook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_C.__ExecuteUbergraph_GA_Motor_FixHook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_C.__ExecuteUbergraph_GA_Motor_FixHook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029067 RID: 168039 RVA: 0x00A1EB8A File Offset: 0x00A1CD8A
		protected GA_Motor_FixHook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B6A RID: 88938
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook.GA_Motor_FixHook_C";

		// Token: 0x04015B6B RID: 88939
		private static IntPtr _ClassPtr;

		// Token: 0x04015B6C RID: 88940
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B6D RID: 88941
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B6E RID: 88942
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B6F RID: 88943
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B70 RID: 88944
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B71 RID: 88945
		internal new static int __PropertyOffset_3;

		// Token: 0x04015B72 RID: 88946
		internal static int __PropertyOffset_4;

		// Token: 0x04015B73 RID: 88947
		internal static int __PropertyOffset_5;

		// Token: 0x04015B74 RID: 88948
		internal static int __PropertyOffset_6;

		// Token: 0x04015B75 RID: 88949
		internal static int __PropertyOffset_7;

		// Token: 0x04015B76 RID: 88950
		internal static int __PropertyOffset_8;

		// Token: 0x04015B77 RID: 88951
		internal static int __PropertyOffset_9;

		// Token: 0x04015B78 RID: 88952
		internal static int __PropertyOffset_10;

		// Token: 0x04015B79 RID: 88953
		internal static int __PropertyOffset_11;

		// Token: 0x04015B7A RID: 88954
		internal static int __PropertyOffset_12;

		// Token: 0x04015B7B RID: 88955
		internal static int __PropertyOffset_13;

		// Token: 0x04015B7C RID: 88956
		internal static int __PropertyOffset_14;

		// Token: 0x04015B7D RID: 88957
		internal static int __PropertyOffset_15;

		// Token: 0x04015B7E RID: 88958
		internal static int __PropertyOffset_16;

		// Token: 0x04015B7F RID: 88959
		internal static int __PropertyOffset_17;

		// Token: 0x04015B80 RID: 88960
		private static IntPtr __FixHookEnd_NativeFunctionPtr;

		// Token: 0x04015B81 RID: 88961
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x04015B82 RID: 88962
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04015B83 RID: 88963
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88D397D2A5_NativeFunctionPtr;

		// Token: 0x04015B84 RID: 88964
		private static IntPtr __OnFinish_EA3C560F46E3B3A5CE0B368596110C6B_NativeFunctionPtr;

		// Token: 0x04015B85 RID: 88965
		private static IntPtr __OnTick_EA3C560F46E3B3A5CE0B368596110C6B_NativeFunctionPtr;

		// Token: 0x04015B86 RID: 88966
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B87 RID: 88967
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015B88 RID: 88968
		private static IntPtr __ExecuteUbergraph_GA_Motor_FixHook_NativeFunctionPtr;

		// Token: 0x0200A1A5 RID: 41381
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 496)]
		protected ref struct __FixHookTick_FunctionParams
		{
			// Token: 0x04032EFD RID: 208637
			[FieldOffset(0)]
			public bool LocationChange;
		}

		// Token: 0x0200A1A6 RID: 41382
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88D397D2A5_FunctionParams
		{
			// Token: 0x04032EFE RID: 208638
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A1A7 RID: 41383
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032EFF RID: 208639
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1A8 RID: 41384
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 608)]
		protected ref struct __ExecuteUbergraph_GA_Motor_FixHook_FunctionParams
		{
			// Token: 0x04032F00 RID: 208640
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
