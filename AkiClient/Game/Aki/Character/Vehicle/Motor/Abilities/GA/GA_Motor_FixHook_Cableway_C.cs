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
	// Token: 0x02003FCE RID: 16334
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook_Cableway.GA_Motor_FixHook_Cableway_C")]
	[UnrealStructLayout(1680, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1668)]
	public class GA_Motor_FixHook_Cableway_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029068 RID: 168040 RVA: 0x00A1EB93 File Offset: 0x00A1CD93
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_FixHook_Cableway_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook_Cableway.GA_Motor_FixHook_Cableway_C");
			}
			return GA_Motor_FixHook_Cableway_C._ClassPtr;
		}

		// Token: 0x06029069 RID: 168041 RVA: 0x00A1EBB8 File Offset: 0x00A1CDB8
		public GA_Motor_FixHook_Cableway_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FixHook_Cableway_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602906A RID: 168042 RVA: 0x00A1EBE0 File Offset: 0x00A1CDE0
		[NullableContext(1)]
		public GA_Motor_FixHook_Cableway_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FixHook_Cableway_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006522 RID: 25890
		// (get) Token: 0x0602906B RID: 168043 RVA: 0x00A1EC14 File Offset: 0x00A1CE14
		// (set) Token: 0x0602906C RID: 168044 RVA: 0x00A1EC4D File Offset: 0x00A1CE4D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006523 RID: 25891
		// (get) Token: 0x0602906D RID: 168045 RVA: 0x00A1EC6E File Offset: 0x00A1CE6E
		// (set) Token: 0x0602906E RID: 168046 RVA: 0x00A1EC82 File Offset: 0x00A1CE82
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006524 RID: 25892
		// (get) Token: 0x0602906F RID: 168047 RVA: 0x00A1EC97 File Offset: 0x00A1CE97
		// (set) Token: 0x06029070 RID: 168048 RVA: 0x00A1ECA7 File Offset: 0x00A1CEA7
		public unsafe int 驾驶员EntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006525 RID: 25893
		// (get) Token: 0x06029071 RID: 168049 RVA: 0x00A1ECB8 File Offset: 0x00A1CEB8
		// (set) Token: 0x06029072 RID: 168050 RVA: 0x00A1ECCC File Offset: 0x00A1CECC
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006526 RID: 25894
		// (get) Token: 0x06029073 RID: 168051 RVA: 0x00A1ECE1 File Offset: 0x00A1CEE1
		// (set) Token: 0x06029074 RID: 168052 RVA: 0x00A1ECF5 File Offset: 0x00A1CEF5
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006527 RID: 25895
		// (get) Token: 0x06029075 RID: 168053 RVA: 0x00A1ED0A File Offset: 0x00A1CF0A
		// (set) Token: 0x06029076 RID: 168054 RVA: 0x00A1ED1E File Offset: 0x00A1CF1E
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006528 RID: 25896
		// (get) Token: 0x06029077 RID: 168055 RVA: 0x00A1ED33 File Offset: 0x00A1CF33
		// (set) Token: 0x06029078 RID: 168056 RVA: 0x00A1ED47 File Offset: 0x00A1CF47
		public unsafe FVector 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006529 RID: 25897
		// (get) Token: 0x06029079 RID: 168057 RVA: 0x00A1ED5C File Offset: 0x00A1CF5C
		// (set) Token: 0x0602907A RID: 168058 RVA: 0x00A1ED6C File Offset: 0x00A1CF6C
		public unsafe float 牵引速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700652A RID: 25898
		// (get) Token: 0x0602907B RID: 168059 RVA: 0x00A1ED7D File Offset: 0x00A1CF7D
		// (set) Token: 0x0602907C RID: 168060 RVA: 0x00A1ED8D File Offset: 0x00A1CF8D
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700652B RID: 25899
		// (get) Token: 0x0602907D RID: 168061 RVA: 0x00A1ED9E File Offset: 0x00A1CF9E
		// (set) Token: 0x0602907E RID: 168062 RVA: 0x00A1EDB2 File Offset: 0x00A1CFB2
		public unsafe UKuroVehicleMovementComponent VehicleMovementComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVehicleMovementComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700652C RID: 25900
		// (get) Token: 0x0602907F RID: 168063 RVA: 0x00A1EDC7 File Offset: 0x00A1CFC7
		// (set) Token: 0x06029080 RID: 168064 RVA: 0x00A1EDD7 File Offset: 0x00A1CFD7
		public unsafe float Speed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700652D RID: 25901
		// (get) Token: 0x06029081 RID: 168065 RVA: 0x00A1EDE8 File Offset: 0x00A1CFE8
		// (set) Token: 0x06029082 RID: 168066 RVA: 0x00A1EDFC File Offset: 0x00A1CFFC
		public unsafe UCurveFloat SpeedCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700652E RID: 25902
		// (get) Token: 0x06029083 RID: 168067 RVA: 0x00A1EE11 File Offset: 0x00A1D011
		// (set) Token: 0x06029084 RID: 168068 RVA: 0x00A1EE25 File Offset: 0x00A1D025
		public unsafe FQuat Target_Quat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700652F RID: 25903
		// (get) Token: 0x06029085 RID: 168069 RVA: 0x00A1EE3A File Offset: 0x00A1D03A
		// (set) Token: 0x06029086 RID: 168070 RVA: 0x00A1EE4E File Offset: 0x00A1D04E
		public unsafe UCurveFloat QuatCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Cableway_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17006530 RID: 25904
		// (get) Token: 0x06029087 RID: 168071 RVA: 0x00A1EE63 File Offset: 0x00A1D063
		// (set) Token: 0x06029088 RID: 168072 RVA: 0x00A1EE73 File Offset: 0x00A1D073
		public unsafe float StartDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006531 RID: 25905
		// (get) Token: 0x06029089 RID: 168073 RVA: 0x00A1EE84 File Offset: 0x00A1D084
		// (set) Token: 0x0602908A RID: 168074 RVA: 0x00A1EE94 File Offset: 0x00A1D094
		public unsafe float LastAlphaOnDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006532 RID: 25906
		// (get) Token: 0x0602908B RID: 168075 RVA: 0x00A1EEA5 File Offset: 0x00A1D0A5
		// (set) Token: 0x0602908C RID: 168076 RVA: 0x00A1EEB5 File Offset: 0x00A1D0B5
		public unsafe bool Need_Quat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006533 RID: 25907
		// (get) Token: 0x0602908D RID: 168077 RVA: 0x00A1EEC6 File Offset: 0x00A1D0C6
		// (set) Token: 0x0602908E RID: 168078 RVA: 0x00A1EED6 File Offset: 0x00A1D0D6
		public unsafe float TimeAtSpeedCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006534 RID: 25908
		// (get) Token: 0x0602908F RID: 168079 RVA: 0x00A1EEE7 File Offset: 0x00A1D0E7
		// (set) Token: 0x06029090 RID: 168080 RVA: 0x00A1EEF7 File Offset: 0x00A1D0F7
		public unsafe bool IsStartGetOff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006535 RID: 25909
		// (get) Token: 0x06029091 RID: 168081 RVA: 0x00A1EF08 File Offset: 0x00A1D108
		// (set) Token: 0x06029092 RID: 168082 RVA: 0x00A1EF18 File Offset: 0x00A1D118
		public unsafe int 钩锁Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17006536 RID: 25910
		// (get) Token: 0x06029093 RID: 168083 RVA: 0x00A1EF29 File Offset: 0x00A1D129
		// (set) Token: 0x06029094 RID: 168084 RVA: 0x00A1EF39 File Offset: 0x00A1D139
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Cableway_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x06029095 RID: 168085 RVA: 0x00A1EF4C File Offset: 0x00A1D14C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Init(ref bool InitSuccess)
		{
			GA_Motor_FixHook_Cableway_C.__Init_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Cableway_C.__Init_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Motor_FixHook_Cableway_C.__Init_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Cableway_C.__Init_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InitSuccess = InitSuccess;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__Init_NativeFunctionPtr, (void*)ptr);
			InitSuccess = ptr->InitSuccess;
		}

		// Token: 0x06029096 RID: 168086 RVA: 0x00A1EF9B File Offset: 0x00A1D19B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__FixHookEnd_NativeFunctionPtr, null);
		}

		// Token: 0x06029097 RID: 168087 RVA: 0x00A1EFB0 File Offset: 0x00A1D1B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FixHookTick(bool LocationChange)
		{
			GA_Motor_FixHook_Cableway_C.__FixHookTick_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Cableway_C.__FixHookTick_FunctionParams[(UIntPtr)543] + 15L / (long)sizeof(GA_Motor_FixHook_Cableway_C.__FixHookTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Cableway_C.__FixHookTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LocationChange = LocationChange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__FixHookTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029098 RID: 168088 RVA: 0x00A1EFF9 File Offset: 0x00A1D1F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x06029099 RID: 168089 RVA: 0x00A1F010 File Offset: 0x00A1D210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88B63A122A(FGameplayEventData Payload)
		{
			GA_Motor_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD88B63A122A_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD88B63A122A_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Motor_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD88B63A122A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD88B63A122A_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD88B63A122A_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Motor_FixHook_Cableway_C.__EventReceived_18B59F5945020DB23C42FD88B63A122A_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602909A RID: 168090 RVA: 0x00A1F085 File Offset: 0x00A1D285
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B4EBDC293()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnTick_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr, null);
		}

		// Token: 0x0602909B RID: 168091 RVA: 0x00A1F099 File Offset: 0x00A1D299
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B4EBDC293()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr, null);
		}

		// Token: 0x0602909C RID: 168092 RVA: 0x00A1F0AD File Offset: 0x00A1D2AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B4EBDC293()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr, null);
		}

		// Token: 0x0602909D RID: 168093 RVA: 0x00A1F0C1 File Offset: 0x00A1D2C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B4EBDC293()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr, null);
		}

		// Token: 0x0602909E RID: 168094 RVA: 0x00A1F0D5 File Offset: 0x00A1D2D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B4EBDC293()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr, null);
		}

		// Token: 0x0602909F RID: 168095 RVA: 0x00A1F0E9 File Offset: 0x00A1D2E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_4936A46849866951391520A2998AAD52()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnFinish_4936A46849866951391520A2998AAD52_NativeFunctionPtr, null);
		}

		// Token: 0x060290A0 RID: 168096 RVA: 0x00A1F0FD File Offset: 0x00A1D2FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_4936A46849866951391520A2998AAD52()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__OnTick_4936A46849866951391520A2998AAD52_NativeFunctionPtr, null);
		}

		// Token: 0x060290A1 RID: 168097 RVA: 0x00A1F111 File Offset: 0x00A1D311
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060290A2 RID: 168098 RVA: 0x00A1F125 File Offset: 0x00A1D325
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060290A3 RID: 168099 RVA: 0x00A1F13C File Offset: 0x00A1D33C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290A4 RID: 168100 RVA: 0x00A1F184 File Offset: 0x00A1D384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060290A5 RID: 168101 RVA: 0x00A1F1CB File Offset: 0x00A1D3CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Get_Off()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__Get_Off_NativeFunctionPtr, null);
		}

		// Token: 0x060290A6 RID: 168102 RVA: 0x00A1F1E0 File Offset: 0x00A1D3E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_FixHook_Cableway(int EntryPoint)
		{
			GA_Motor_FixHook_Cableway_C.__ExecuteUbergraph_GA_Motor_FixHook_Cableway_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Cableway_C.__ExecuteUbergraph_GA_Motor_FixHook_Cableway_FunctionParams[(UIntPtr)1095] + 15L / (long)sizeof(GA_Motor_FixHook_Cableway_C.__ExecuteUbergraph_GA_Motor_FixHook_Cableway_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Cableway_C.__ExecuteUbergraph_GA_Motor_FixHook_Cableway_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_Cableway_C.__ExecuteUbergraph_GA_Motor_FixHook_Cableway_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060290A7 RID: 168103 RVA: 0x00A1F22A File Offset: 0x00A1D42A
		protected GA_Motor_FixHook_Cableway_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B89 RID: 88969
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook_Cableway.GA_Motor_FixHook_Cableway_C";

		// Token: 0x04015B8A RID: 88970
		private static IntPtr _ClassPtr;

		// Token: 0x04015B8B RID: 88971
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B8C RID: 88972
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B8D RID: 88973
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B8E RID: 88974
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B8F RID: 88975
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B90 RID: 88976
		internal new static int __PropertyOffset_3;

		// Token: 0x04015B91 RID: 88977
		internal static int __PropertyOffset_4;

		// Token: 0x04015B92 RID: 88978
		internal static int __PropertyOffset_5;

		// Token: 0x04015B93 RID: 88979
		internal static int __PropertyOffset_6;

		// Token: 0x04015B94 RID: 88980
		internal static int __PropertyOffset_7;

		// Token: 0x04015B95 RID: 88981
		internal static int __PropertyOffset_8;

		// Token: 0x04015B96 RID: 88982
		internal static int __PropertyOffset_9;

		// Token: 0x04015B97 RID: 88983
		internal static int __PropertyOffset_10;

		// Token: 0x04015B98 RID: 88984
		internal static int __PropertyOffset_11;

		// Token: 0x04015B99 RID: 88985
		internal static int __PropertyOffset_12;

		// Token: 0x04015B9A RID: 88986
		internal static int __PropertyOffset_13;

		// Token: 0x04015B9B RID: 88987
		internal static int __PropertyOffset_14;

		// Token: 0x04015B9C RID: 88988
		internal static int __PropertyOffset_15;

		// Token: 0x04015B9D RID: 88989
		internal static int __PropertyOffset_16;

		// Token: 0x04015B9E RID: 88990
		internal static int __PropertyOffset_17;

		// Token: 0x04015B9F RID: 88991
		internal static int __PropertyOffset_18;

		// Token: 0x04015BA0 RID: 88992
		internal static int __PropertyOffset_19;

		// Token: 0x04015BA1 RID: 88993
		internal static int __PropertyOffset_20;

		// Token: 0x04015BA2 RID: 88994
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04015BA3 RID: 88995
		private static IntPtr __FixHookEnd_NativeFunctionPtr;

		// Token: 0x04015BA4 RID: 88996
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x04015BA5 RID: 88997
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04015BA6 RID: 88998
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88B63A122A_NativeFunctionPtr;

		// Token: 0x04015BA7 RID: 88999
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr;

		// Token: 0x04015BA8 RID: 89000
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr;

		// Token: 0x04015BA9 RID: 89001
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr;

		// Token: 0x04015BAA RID: 89002
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr;

		// Token: 0x04015BAB RID: 89003
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B4EBDC293_NativeFunctionPtr;

		// Token: 0x04015BAC RID: 89004
		private static IntPtr __OnFinish_4936A46849866951391520A2998AAD52_NativeFunctionPtr;

		// Token: 0x04015BAD RID: 89005
		private static IntPtr __OnTick_4936A46849866951391520A2998AAD52_NativeFunctionPtr;

		// Token: 0x04015BAE RID: 89006
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015BAF RID: 89007
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015BB0 RID: 89008
		private static IntPtr __Get_Off_NativeFunctionPtr;

		// Token: 0x04015BB1 RID: 89009
		private static IntPtr __ExecuteUbergraph_GA_Motor_FixHook_Cableway_NativeFunctionPtr;

		// Token: 0x0200A1A9 RID: 41385
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __Init_FunctionParams
		{
			// Token: 0x04032F01 RID: 208641
			[FieldOffset(0)]
			public bool InitSuccess;
		}

		// Token: 0x0200A1AA RID: 41386
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 528)]
		protected ref struct __FixHookTick_FunctionParams
		{
			// Token: 0x04032F02 RID: 208642
			[FieldOffset(0)]
			public bool LocationChange;
		}

		// Token: 0x0200A1AB RID: 41387
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88B63A122A_FunctionParams
		{
			// Token: 0x04032F03 RID: 208643
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A1AC RID: 41388
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F04 RID: 208644
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1AD RID: 41389
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1080)]
		protected ref struct __ExecuteUbergraph_GA_Motor_FixHook_Cableway_FunctionParams
		{
			// Token: 0x04032F05 RID: 208645
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
