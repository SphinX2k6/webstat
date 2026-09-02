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
	// Token: 0x02003FCF RID: 16335
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook_Pilot.GA_Motor_FixHook_Pilot_C")]
	[UnrealStructLayout(1680, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1672)]
	public class GA_Motor_FixHook_Pilot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060290A8 RID: 168104 RVA: 0x00A1F233 File Offset: 0x00A1D433
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_FixHook_Pilot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook_Pilot.GA_Motor_FixHook_Pilot_C");
			}
			return GA_Motor_FixHook_Pilot_C._ClassPtr;
		}

		// Token: 0x060290A9 RID: 168105 RVA: 0x00A1F258 File Offset: 0x00A1D458
		public GA_Motor_FixHook_Pilot_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FixHook_Pilot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060290AA RID: 168106 RVA: 0x00A1F280 File Offset: 0x00A1D480
		[NullableContext(1)]
		public GA_Motor_FixHook_Pilot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_FixHook_Pilot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006537 RID: 25911
		// (get) Token: 0x060290AB RID: 168107 RVA: 0x00A1F2B4 File Offset: 0x00A1D4B4
		// (set) Token: 0x060290AC RID: 168108 RVA: 0x00A1F2ED File Offset: 0x00A1D4ED
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006538 RID: 25912
		// (get) Token: 0x060290AD RID: 168109 RVA: 0x00A1F30E File Offset: 0x00A1D50E
		// (set) Token: 0x060290AE RID: 168110 RVA: 0x00A1F322 File Offset: 0x00A1D522
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006539 RID: 25913
		// (get) Token: 0x060290AF RID: 168111 RVA: 0x00A1F337 File Offset: 0x00A1D537
		// (set) Token: 0x060290B0 RID: 168112 RVA: 0x00A1F347 File Offset: 0x00A1D547
		public unsafe int 驾驶员EntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700653A RID: 25914
		// (get) Token: 0x060290B1 RID: 168113 RVA: 0x00A1F358 File Offset: 0x00A1D558
		// (set) Token: 0x060290B2 RID: 168114 RVA: 0x00A1F36C File Offset: 0x00A1D56C
		public unsafe FVectorDouble FixHookLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700653B RID: 25915
		// (get) Token: 0x060290B3 RID: 168115 RVA: 0x00A1F381 File Offset: 0x00A1D581
		// (set) Token: 0x060290B4 RID: 168116 RVA: 0x00A1F395 File Offset: 0x00A1D595
		public unsafe FVector LastDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700653C RID: 25916
		// (get) Token: 0x060290B5 RID: 168117 RVA: 0x00A1F3AA File Offset: 0x00A1D5AA
		// (set) Token: 0x060290B6 RID: 168118 RVA: 0x00A1F3BE File Offset: 0x00A1D5BE
		public unsafe FVectorDouble LastLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700653D RID: 25917
		// (get) Token: 0x060290B7 RID: 168119 RVA: 0x00A1F3D3 File Offset: 0x00A1D5D3
		// (set) Token: 0x060290B8 RID: 168120 RVA: 0x00A1F3E7 File Offset: 0x00A1D5E7
		public unsafe FVector 牵引速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700653E RID: 25918
		// (get) Token: 0x060290B9 RID: 168121 RVA: 0x00A1F3FC File Offset: 0x00A1D5FC
		// (set) Token: 0x060290BA RID: 168122 RVA: 0x00A1F40C File Offset: 0x00A1D60C
		public unsafe float BlockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700653F RID: 25919
		// (get) Token: 0x060290BB RID: 168123 RVA: 0x00A1F41D File Offset: 0x00A1D61D
		// (set) Token: 0x060290BC RID: 168124 RVA: 0x00A1F431 File Offset: 0x00A1D631
		public unsafe UKuroVehicleMovementComponent VehicleMovementComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVehicleMovementComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17006540 RID: 25920
		// (get) Token: 0x060290BD RID: 168125 RVA: 0x00A1F446 File Offset: 0x00A1D646
		// (set) Token: 0x060290BE RID: 168126 RVA: 0x00A1F456 File Offset: 0x00A1D656
		public unsafe float Speed_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006541 RID: 25921
		// (get) Token: 0x060290BF RID: 168127 RVA: 0x00A1F467 File Offset: 0x00A1D667
		// (set) Token: 0x060290C0 RID: 168128 RVA: 0x00A1F47B File Offset: 0x00A1D67B
		public unsafe UCurveFloat SpeedCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17006542 RID: 25922
		// (get) Token: 0x060290C1 RID: 168129 RVA: 0x00A1F490 File Offset: 0x00A1D690
		// (set) Token: 0x060290C2 RID: 168130 RVA: 0x00A1F4A4 File Offset: 0x00A1D6A4
		public unsafe FQuat Target_Quat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006543 RID: 25923
		// (get) Token: 0x060290C3 RID: 168131 RVA: 0x00A1F4B9 File Offset: 0x00A1D6B9
		// (set) Token: 0x060290C4 RID: 168132 RVA: 0x00A1F4CD File Offset: 0x00A1D6CD
		public unsafe UCurveFloat QuatCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_FixHook_Pilot_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17006544 RID: 25924
		// (get) Token: 0x060290C5 RID: 168133 RVA: 0x00A1F4E2 File Offset: 0x00A1D6E2
		// (set) Token: 0x060290C6 RID: 168134 RVA: 0x00A1F4F2 File Offset: 0x00A1D6F2
		public unsafe float StartDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006545 RID: 25925
		// (get) Token: 0x060290C7 RID: 168135 RVA: 0x00A1F503 File Offset: 0x00A1D703
		// (set) Token: 0x060290C8 RID: 168136 RVA: 0x00A1F513 File Offset: 0x00A1D713
		public unsafe float LastAlphaOnDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006546 RID: 25926
		// (get) Token: 0x060290C9 RID: 168137 RVA: 0x00A1F524 File Offset: 0x00A1D724
		// (set) Token: 0x060290CA RID: 168138 RVA: 0x00A1F534 File Offset: 0x00A1D734
		public unsafe float TimeAtSpeedCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17006547 RID: 25927
		// (get) Token: 0x060290CB RID: 168139 RVA: 0x00A1F545 File Offset: 0x00A1D745
		// (set) Token: 0x060290CC RID: 168140 RVA: 0x00A1F555 File Offset: 0x00A1D755
		public unsafe bool Need_Quat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006548 RID: 25928
		// (get) Token: 0x060290CD RID: 168141 RVA: 0x00A1F566 File Offset: 0x00A1D766
		// (set) Token: 0x060290CE RID: 168142 RVA: 0x00A1F576 File Offset: 0x00A1D776
		public unsafe int 变身材质handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17006549 RID: 25929
		// (get) Token: 0x060290CF RID: 168143 RVA: 0x00A1F587 File Offset: 0x00A1D787
		// (set) Token: 0x060290D0 RID: 168144 RVA: 0x00A1F597 File Offset: 0x00A1D797
		public unsafe int 变身特效Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700654A RID: 25930
		// (get) Token: 0x060290D1 RID: 168145 RVA: 0x00A1F5A8 File Offset: 0x00A1D7A8
		// (set) Token: 0x060290D2 RID: 168146 RVA: 0x00A1F5B8 File Offset: 0x00A1D7B8
		public unsafe int 变身特效2Handle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700654B RID: 25931
		// (get) Token: 0x060290D3 RID: 168147 RVA: 0x00A1F5C9 File Offset: 0x00A1D7C9
		// (set) Token: 0x060290D4 RID: 168148 RVA: 0x00A1F5D9 File Offset: 0x00A1D7D9
		public unsafe int 钩锁ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_FixHook_Pilot_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x060290D5 RID: 168149 RVA: 0x00A1F5EC File Offset: 0x00A1D7EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddTags(ref TArray<FGameplayTag> TagsArray)
		{
			GA_Motor_FixHook_Pilot_C.__AddTags_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__AddTags_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__AddTags_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__AddTags_NativeFunctionPtr, (void*)ptr, 1);
			TArray<FGameplayTag> tarray = TagsArray;
			if (tarray != null)
			{
				tarray.MoveTo(&ptr->TagsArray);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__AddTags_NativeFunctionPtr, (void*)ptr);
			TArray<FGameplayTag> tarray2 = TagsArray;
			if (tarray2 != null)
			{
				tarray2.MoveAssign(&ptr->TagsArray);
			}
			UnrealReflectionUtils.DestroyStruct(GA_Motor_FixHook_Pilot_C.__AddTags_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060290D6 RID: 168150 RVA: 0x00A1F664 File Offset: 0x00A1D864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NiagaraSetting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__NiagaraSetting_NativeFunctionPtr, null);
		}

		// Token: 0x060290D7 RID: 168151 RVA: 0x00A1F678 File Offset: 0x00A1D878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Init(ref bool InitSuccess)
		{
			GA_Motor_FixHook_Pilot_C.__Init_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__Init_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__Init_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__Init_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InitSuccess = InitSuccess;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__Init_NativeFunctionPtr, (void*)ptr);
			InitSuccess = ptr->InitSuccess;
		}

		// Token: 0x060290D8 RID: 168152 RVA: 0x00A1F6C7 File Offset: 0x00A1D8C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__FixHookEnd_NativeFunctionPtr, null);
		}

		// Token: 0x060290D9 RID: 168153 RVA: 0x00A1F6DC File Offset: 0x00A1D8DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FixHookTick(bool LocationChange)
		{
			GA_Motor_FixHook_Pilot_C.__FixHookTick_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__FixHookTick_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__FixHookTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__FixHookTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LocationChange = LocationChange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__FixHookTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290DA RID: 168154 RVA: 0x00A1F725 File Offset: 0x00A1D925
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void FixHookStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__FixHookStart_NativeFunctionPtr, null);
		}

		// Token: 0x060290DB RID: 168155 RVA: 0x00A1F73C File Offset: 0x00A1D93C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD8859A58434(FGameplayEventData Payload)
		{
			GA_Motor_FixHook_Pilot_C.__EventReceived_18B59F5945020DB23C42FD8859A58434_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__EventReceived_18B59F5945020DB23C42FD8859A58434_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__EventReceived_18B59F5945020DB23C42FD8859A58434_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__EventReceived_18B59F5945020DB23C42FD8859A58434_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__EventReceived_18B59F5945020DB23C42FD8859A58434_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Motor_FixHook_Pilot_C.__EventReceived_18B59F5945020DB23C42FD8859A58434_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060290DC RID: 168156 RVA: 0x00A1F7B1 File Offset: 0x00A1D9B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_8DAE42674B45A6FEE64E31924E97CDAD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnFinish_8DAE42674B45A6FEE64E31924E97CDAD_NativeFunctionPtr, null);
		}

		// Token: 0x060290DD RID: 168157 RVA: 0x00A1F7C5 File Offset: 0x00A1D9C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_8DAE42674B45A6FEE64E31924E97CDAD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnTick_8DAE42674B45A6FEE64E31924E97CDAD_NativeFunctionPtr, null);
		}

		// Token: 0x060290DE RID: 168158 RVA: 0x00A1F7D9 File Offset: 0x00A1D9D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_EF1403574367A068E1C9B38B9C3F2B6A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnTick_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr, null);
		}

		// Token: 0x060290DF RID: 168159 RVA: 0x00A1F7ED File Offset: 0x00A1D9ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_EF1403574367A068E1C9B38B9C3F2B6A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnCancelled_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr, null);
		}

		// Token: 0x060290E0 RID: 168160 RVA: 0x00A1F801 File Offset: 0x00A1DA01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_EF1403574367A068E1C9B38B9C3F2B6A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnInterrupted_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr, null);
		}

		// Token: 0x060290E1 RID: 168161 RVA: 0x00A1F815 File Offset: 0x00A1DA15
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_EF1403574367A068E1C9B38B9C3F2B6A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnBlendOut_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr, null);
		}

		// Token: 0x060290E2 RID: 168162 RVA: 0x00A1F829 File Offset: 0x00A1DA29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_EF1403574367A068E1C9B38B9C3F2B6A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnCompleted_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr, null);
		}

		// Token: 0x060290E3 RID: 168163 RVA: 0x00A1F83D File Offset: 0x00A1DA3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B494A439E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnTick_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr, null);
		}

		// Token: 0x060290E4 RID: 168164 RVA: 0x00A1F851 File Offset: 0x00A1DA51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B494A439E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr, null);
		}

		// Token: 0x060290E5 RID: 168165 RVA: 0x00A1F865 File Offset: 0x00A1DA65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B494A439E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr, null);
		}

		// Token: 0x060290E6 RID: 168166 RVA: 0x00A1F879 File Offset: 0x00A1DA79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B494A439E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr, null);
		}

		// Token: 0x060290E7 RID: 168167 RVA: 0x00A1F88D File Offset: 0x00A1DA8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B494A439E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr, null);
		}

		// Token: 0x060290E8 RID: 168168 RVA: 0x00A1F8A1 File Offset: 0x00A1DAA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060290E9 RID: 168169 RVA: 0x00A1F8B5 File Offset: 0x00A1DAB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060290EA RID: 168170 RVA: 0x00A1F8CC File Offset: 0x00A1DACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290EB RID: 168171 RVA: 0x00A1F914 File Offset: 0x00A1DB14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060290EC RID: 168172 RVA: 0x00A1F95C File Offset: 0x00A1DB5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayMontage4Func(UAnimMontage MontageToPlay, float Rate, bool bStopWhenAbilityEnds, float AnimRootMotionTranslationScale, float StartTimeSeconds, bool NeedTick)
		{
			GA_Motor_FixHook_Pilot_C.__PlayMontage4Func_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__PlayMontage4Func_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__PlayMontage4Func_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__PlayMontage4Func_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MontageToPlay = ((MontageToPlay != null) ? MontageToPlay.NativePtr : IntPtr.Zero);
			ptr->Rate = Rate;
			ptr->bStopWhenAbilityEnds = bStopWhenAbilityEnds;
			ptr->AnimRootMotionTranslationScale = AnimRootMotionTranslationScale;
			ptr->StartTimeSeconds = StartTimeSeconds;
			ptr->NeedTick = NeedTick;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__PlayMontage4Func_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060290ED RID: 168173 RVA: 0x00A1F9D7 File Offset: 0x00A1DBD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CE_StartEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__CE_StartEnd_NativeFunctionPtr, null);
		}

		// Token: 0x060290EE RID: 168174 RVA: 0x00A1F9EC File Offset: 0x00A1DBEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_FixHook_Pilot(int EntryPoint)
		{
			GA_Motor_FixHook_Pilot_C.__ExecuteUbergraph_GA_Motor_FixHook_Pilot_FunctionParams* ptr = stackalloc GA_Motor_FixHook_Pilot_C.__ExecuteUbergraph_GA_Motor_FixHook_Pilot_FunctionParams[(UIntPtr)1183] + 15L / (long)sizeof(GA_Motor_FixHook_Pilot_C.__ExecuteUbergraph_GA_Motor_FixHook_Pilot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_FixHook_Pilot_C.__ExecuteUbergraph_GA_Motor_FixHook_Pilot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_FixHook_Pilot_C.__ExecuteUbergraph_GA_Motor_FixHook_Pilot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060290EF RID: 168175 RVA: 0x00A1FA36 File Offset: 0x00A1DC36
		protected GA_Motor_FixHook_Pilot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015BB2 RID: 89010
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_FixHook_Pilot.GA_Motor_FixHook_Pilot_C";

		// Token: 0x04015BB3 RID: 89011
		private static IntPtr _ClassPtr;

		// Token: 0x04015BB4 RID: 89012
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015BB5 RID: 89013
		internal new static int __PropertyOffset_0;

		// Token: 0x04015BB6 RID: 89014
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015BB7 RID: 89015
		internal new static int __PropertyOffset_1;

		// Token: 0x04015BB8 RID: 89016
		internal new static int __PropertyOffset_2;

		// Token: 0x04015BB9 RID: 89017
		internal new static int __PropertyOffset_3;

		// Token: 0x04015BBA RID: 89018
		internal static int __PropertyOffset_4;

		// Token: 0x04015BBB RID: 89019
		internal static int __PropertyOffset_5;

		// Token: 0x04015BBC RID: 89020
		internal static int __PropertyOffset_6;

		// Token: 0x04015BBD RID: 89021
		internal static int __PropertyOffset_7;

		// Token: 0x04015BBE RID: 89022
		internal static int __PropertyOffset_8;

		// Token: 0x04015BBF RID: 89023
		internal static int __PropertyOffset_9;

		// Token: 0x04015BC0 RID: 89024
		internal static int __PropertyOffset_10;

		// Token: 0x04015BC1 RID: 89025
		internal static int __PropertyOffset_11;

		// Token: 0x04015BC2 RID: 89026
		internal static int __PropertyOffset_12;

		// Token: 0x04015BC3 RID: 89027
		internal static int __PropertyOffset_13;

		// Token: 0x04015BC4 RID: 89028
		internal static int __PropertyOffset_14;

		// Token: 0x04015BC5 RID: 89029
		internal static int __PropertyOffset_15;

		// Token: 0x04015BC6 RID: 89030
		internal static int __PropertyOffset_16;

		// Token: 0x04015BC7 RID: 89031
		internal static int __PropertyOffset_17;

		// Token: 0x04015BC8 RID: 89032
		internal static int __PropertyOffset_18;

		// Token: 0x04015BC9 RID: 89033
		internal static int __PropertyOffset_19;

		// Token: 0x04015BCA RID: 89034
		internal static int __PropertyOffset_20;

		// Token: 0x04015BCB RID: 89035
		private static IntPtr __AddTags_NativeFunctionPtr;

		// Token: 0x04015BCC RID: 89036
		private static IntPtr __NiagaraSetting_NativeFunctionPtr;

		// Token: 0x04015BCD RID: 89037
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04015BCE RID: 89038
		private static IntPtr __FixHookEnd_NativeFunctionPtr;

		// Token: 0x04015BCF RID: 89039
		private static IntPtr __FixHookTick_NativeFunctionPtr;

		// Token: 0x04015BD0 RID: 89040
		private static IntPtr __FixHookStart_NativeFunctionPtr;

		// Token: 0x04015BD1 RID: 89041
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD8859A58434_NativeFunctionPtr;

		// Token: 0x04015BD2 RID: 89042
		private static IntPtr __OnFinish_8DAE42674B45A6FEE64E31924E97CDAD_NativeFunctionPtr;

		// Token: 0x04015BD3 RID: 89043
		private static IntPtr __OnTick_8DAE42674B45A6FEE64E31924E97CDAD_NativeFunctionPtr;

		// Token: 0x04015BD4 RID: 89044
		private static IntPtr __OnTick_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr;

		// Token: 0x04015BD5 RID: 89045
		private static IntPtr __OnCancelled_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr;

		// Token: 0x04015BD6 RID: 89046
		private static IntPtr __OnInterrupted_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr;

		// Token: 0x04015BD7 RID: 89047
		private static IntPtr __OnBlendOut_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr;

		// Token: 0x04015BD8 RID: 89048
		private static IntPtr __OnCompleted_EF1403574367A068E1C9B38B9C3F2B6A_NativeFunctionPtr;

		// Token: 0x04015BD9 RID: 89049
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr;

		// Token: 0x04015BDA RID: 89050
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr;

		// Token: 0x04015BDB RID: 89051
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr;

		// Token: 0x04015BDC RID: 89052
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr;

		// Token: 0x04015BDD RID: 89053
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B494A439E_NativeFunctionPtr;

		// Token: 0x04015BDE RID: 89054
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015BDF RID: 89055
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015BE0 RID: 89056
		private static IntPtr __PlayMontage4Func_NativeFunctionPtr;

		// Token: 0x04015BE1 RID: 89057
		private static IntPtr __CE_StartEnd_NativeFunctionPtr;

		// Token: 0x04015BE2 RID: 89058
		private static IntPtr __ExecuteUbergraph_GA_Motor_FixHook_Pilot_NativeFunctionPtr;

		// Token: 0x0200A1AE RID: 41390
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __AddTags_FunctionParams
		{
			// Token: 0x04032F06 RID: 208646
			[FieldOffset(0)]
			public byte TagsArray;
		}

		// Token: 0x0200A1AF RID: 41391
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __Init_FunctionParams
		{
			// Token: 0x04032F07 RID: 208647
			[FieldOffset(0)]
			public bool InitSuccess;
		}

		// Token: 0x0200A1B0 RID: 41392
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __FixHookTick_FunctionParams
		{
			// Token: 0x04032F08 RID: 208648
			[FieldOffset(0)]
			public bool LocationChange;
		}

		// Token: 0x0200A1B1 RID: 41393
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD8859A58434_FunctionParams
		{
			// Token: 0x04032F09 RID: 208649
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A1B2 RID: 41394
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F0A RID: 208650
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1B3 RID: 41395
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __PlayMontage4Func_FunctionParams
		{
			// Token: 0x04032F0B RID: 208651
			[FieldOffset(0)]
			public IntPtr MontageToPlay;

			// Token: 0x04032F0C RID: 208652
			[FieldOffset(8)]
			public float Rate;

			// Token: 0x04032F0D RID: 208653
			[FieldOffset(12)]
			public bool bStopWhenAbilityEnds;

			// Token: 0x04032F0E RID: 208654
			[FieldOffset(16)]
			public float AnimRootMotionTranslationScale;

			// Token: 0x04032F0F RID: 208655
			[FieldOffset(20)]
			public float StartTimeSeconds;

			// Token: 0x04032F10 RID: 208656
			[FieldOffset(24)]
			public bool NeedTick;
		}

		// Token: 0x0200A1B4 RID: 41396
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1168)]
		protected ref struct __ExecuteUbergraph_GA_Motor_FixHook_Pilot_FunctionParams
		{
			// Token: 0x04032F11 RID: 208657
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
