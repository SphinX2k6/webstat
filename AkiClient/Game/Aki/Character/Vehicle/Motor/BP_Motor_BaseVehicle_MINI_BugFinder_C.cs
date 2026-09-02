using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Data;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F96 RID: 16278
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_MINI_BugFinder.BP_Motor_BaseVehicle_MINI_BugFinder_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_Motor_BaseVehicle_MINI_BugFinder_C : BP_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028CC8 RID: 167112 RVA: 0x00A16ED0 File Offset: 0x00A150D0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_MINI_BugFinder_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_MINI_BugFinder.BP_Motor_BaseVehicle_MINI_BugFinder_C");
			}
			return BP_Motor_BaseVehicle_MINI_BugFinder_C._ClassPtr;
		}

		// Token: 0x06028CC9 RID: 167113 RVA: 0x00A16EF4 File Offset: 0x00A150F4
		public BP_Motor_BaseVehicle_MINI_BugFinder_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_MINI_BugFinder_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028CCA RID: 167114 RVA: 0x00A16F1C File Offset: 0x00A1511C
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_MINI_BugFinder_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_MINI_BugFinder_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700642B RID: 25643
		// (get) Token: 0x06028CCB RID: 167115 RVA: 0x00A16F50 File Offset: 0x00A15150
		// (set) Token: 0x06028CCC RID: 167116 RVA: 0x00A16F89 File Offset: 0x00A15189
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700642C RID: 25644
		// (get) Token: 0x06028CCD RID: 167117 RVA: 0x00A16FAA File Offset: 0x00A151AA
		// (set) Token: 0x06028CCE RID: 167118 RVA: 0x00A16FBE File Offset: 0x00A151BE
		public unsafe BP_MotorObjTrailActor_C BP_MotorObjTrailActor2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MotorObjTrailActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700642D RID: 25645
		// (get) Token: 0x06028CCF RID: 167119 RVA: 0x00A16FD3 File Offset: 0x00A151D3
		// (set) Token: 0x06028CD0 RID: 167120 RVA: 0x00A16FE7 File Offset: 0x00A151E7
		public unsafe BP_MotorObjTrailActor_C BP_MotorObjTrailActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MotorObjTrailActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700642E RID: 25646
		// (get) Token: 0x06028CD1 RID: 167121 RVA: 0x00A16FFC File Offset: 0x00A151FC
		// (set) Token: 0x06028CD2 RID: 167122 RVA: 0x00A17010 File Offset: 0x00A15210
		public unsafe USkeletalMeshComponent OtherCase5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700642F RID: 25647
		// (get) Token: 0x06028CD3 RID: 167123 RVA: 0x00A17025 File Offset: 0x00A15225
		// (set) Token: 0x06028CD4 RID: 167124 RVA: 0x00A17039 File Offset: 0x00A15239
		public unsafe USkeletalMeshComponent OtherCase4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17006430 RID: 25648
		// (get) Token: 0x06028CD5 RID: 167125 RVA: 0x00A1704E File Offset: 0x00A1524E
		// (set) Token: 0x06028CD6 RID: 167126 RVA: 0x00A17062 File Offset: 0x00A15262
		public unsafe USphereComponent SphereForInteraction2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17006431 RID: 25649
		// (get) Token: 0x06028CD7 RID: 167127 RVA: 0x00A17077 File Offset: 0x00A15277
		// (set) Token: 0x06028CD8 RID: 167128 RVA: 0x00A1708B File Offset: 0x00A1528B
		public unsafe USphereComponent SphereForInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17006432 RID: 25650
		// (get) Token: 0x06028CD9 RID: 167129 RVA: 0x00A170A0 File Offset: 0x00A152A0
		// (set) Token: 0x06028CDA RID: 167130 RVA: 0x00A170B4 File Offset: 0x00A152B4
		public unsafe UCapsuleComponent CapsuleForTriggerAndBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17006433 RID: 25651
		// (get) Token: 0x06028CDB RID: 167131 RVA: 0x00A170C9 File Offset: 0x00A152C9
		// (set) Token: 0x06028CDC RID: 167132 RVA: 0x00A170DD File Offset: 0x00A152DD
		public unsafe UCapsuleComponent CapsuleForDither
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17006434 RID: 25652
		// (get) Token: 0x06028CDD RID: 167133 RVA: 0x00A170F2 File Offset: 0x00A152F2
		// (set) Token: 0x06028CDE RID: 167134 RVA: 0x00A17106 File Offset: 0x00A15306
		public unsafe USkeletalMeshComponent OtherCase3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17006435 RID: 25653
		// (get) Token: 0x06028CDF RID: 167135 RVA: 0x00A1711B File Offset: 0x00A1531B
		// (set) Token: 0x06028CE0 RID: 167136 RVA: 0x00A1712F File Offset: 0x00A1532F
		public unsafe USkeletalMeshComponent OtherCase2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17006436 RID: 25654
		// (get) Token: 0x06028CE1 RID: 167137 RVA: 0x00A17144 File Offset: 0x00A15344
		// (set) Token: 0x06028CE2 RID: 167138 RVA: 0x00A17158 File Offset: 0x00A15358
		public unsafe USkeletalMeshComponent OtherCase1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17006437 RID: 25655
		// (get) Token: 0x06028CE3 RID: 167139 RVA: 0x00A1716D File Offset: 0x00A1536D
		// (set) Token: 0x06028CE4 RID: 167140 RVA: 0x00A17181 File Offset: 0x00A15381
		public unsafe UCapsuleComponent CapsuleForPhotograph
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17006438 RID: 25656
		// (get) Token: 0x06028CE5 RID: 167141 RVA: 0x00A17196 File Offset: 0x00A15396
		// (set) Token: 0x06028CE6 RID: 167142 RVA: 0x00A171AA File Offset: 0x00A153AA
		public unsafe UDataTable 技能表_用于加载_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17006439 RID: 25657
		// (get) Token: 0x06028CE7 RID: 167143 RVA: 0x00A171BF File Offset: 0x00A153BF
		// (set) Token: 0x06028CE8 RID: 167144 RVA: 0x00A171CF File Offset: 0x00A153CF
		public unsafe float 虚化碰撞NPC半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700643A RID: 25658
		// (get) Token: 0x06028CE9 RID: 167145 RVA: 0x00A171E0 File Offset: 0x00A153E0
		// (set) Token: 0x06028CEA RID: 167146 RVA: 0x00A171F4 File Offset: 0x00A153F4
		public unsafe UCurveFloat 深度虚化值曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_MINI_BugFinder_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x06028CEB RID: 167147 RVA: 0x00A17209 File Offset: 0x00A15409
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 解锁最高速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__解锁最高速度_NativeFunctionPtr, null);
		}

		// Token: 0x06028CEC RID: 167148 RVA: 0x00A1721D File Offset: 0x00A1541D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 打开关闭Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__打开关闭Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06028CED RID: 167149 RVA: 0x00A17231 File Offset: 0x00A15431
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 解锁二段跳_蓄力跳_新退场技()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__解锁二段跳_蓄力跳_新退场技_NativeFunctionPtr, null);
		}

		// Token: 0x06028CEE RID: 167150 RVA: 0x00A17245 File Offset: 0x00A15445
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 刷新配置()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__刷新配置_NativeFunctionPtr, null);
		}

		// Token: 0x06028CEF RID: 167151 RVA: 0x00A1725C File Offset: 0x00A1545C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetConfigDataNameTagMap(ref TMap<FName, FGameplayTag> Result)
		{
			BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataNameTagMap_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataNameTagMap_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataNameTagMap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FGameplayTag> tmap = Result;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->Result);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FGameplayTag> tmap2 = Result;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->Result);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028CF0 RID: 167152 RVA: 0x00A172D8 File Offset: 0x00A154D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetConfigDataByKeyName(FName Name, ref SMotorConfigs Result)
		{
			BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataByKeyName_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataByKeyName_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataByKeyName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			if (Result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorConfigs.StaticStruct(), &ptr->Result, Result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr);
			if (Result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorConfigs.StaticStruct(), Result.NativePtr, &ptr->Result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028CF1 RID: 167153 RVA: 0x00A1737C File Offset: 0x00A1557C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028CF2 RID: 167154 RVA: 0x00A173C4 File Offset: 0x00A155C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028CF3 RID: 167155 RVA: 0x00A1740B File Offset: 0x00A1560B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028CF4 RID: 167156 RVA: 0x00A1741F File Offset: 0x00A1561F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028CF5 RID: 167157 RVA: 0x00A17434 File Offset: 0x00A15634
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder(int EntryPoint)
		{
			BP_Motor_BaseVehicle_MINI_BugFinder_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_MINI_BugFinder_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Motor_BaseVehicle_MINI_BugFinder_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_MINI_BugFinder_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_MINI_BugFinder_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028CF6 RID: 167158 RVA: 0x00A1747B File Offset: 0x00A1567B
		protected BP_Motor_BaseVehicle_MINI_BugFinder_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015908 RID: 88328
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_MINI_BugFinder.BP_Motor_BaseVehicle_MINI_BugFinder_C";

		// Token: 0x04015909 RID: 88329
		private static IntPtr _ClassPtr;

		// Token: 0x0401590A RID: 88330
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401590B RID: 88331
		internal static int __PropertyOffset_0;

		// Token: 0x0401590C RID: 88332
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401590D RID: 88333
		internal static int __PropertyOffset_1;

		// Token: 0x0401590E RID: 88334
		internal static int __PropertyOffset_2;

		// Token: 0x0401590F RID: 88335
		internal static int __PropertyOffset_3;

		// Token: 0x04015910 RID: 88336
		internal static int __PropertyOffset_4;

		// Token: 0x04015911 RID: 88337
		internal static int __PropertyOffset_5;

		// Token: 0x04015912 RID: 88338
		internal static int __PropertyOffset_6;

		// Token: 0x04015913 RID: 88339
		internal static int __PropertyOffset_7;

		// Token: 0x04015914 RID: 88340
		internal static int __PropertyOffset_8;

		// Token: 0x04015915 RID: 88341
		internal static int __PropertyOffset_9;

		// Token: 0x04015916 RID: 88342
		internal static int __PropertyOffset_10;

		// Token: 0x04015917 RID: 88343
		internal static int __PropertyOffset_11;

		// Token: 0x04015918 RID: 88344
		internal static int __PropertyOffset_12;

		// Token: 0x04015919 RID: 88345
		internal static int __PropertyOffset_13;

		// Token: 0x0401591A RID: 88346
		internal static int __PropertyOffset_14;

		// Token: 0x0401591B RID: 88347
		internal static int __PropertyOffset_15;

		// Token: 0x0401591C RID: 88348
		private static IntPtr __解锁最高速度_NativeFunctionPtr;

		// Token: 0x0401591D RID: 88349
		private static IntPtr __打开关闭Debug_NativeFunctionPtr;

		// Token: 0x0401591E RID: 88350
		private static IntPtr __解锁二段跳_蓄力跳_新退场技_NativeFunctionPtr;

		// Token: 0x0401591F RID: 88351
		private static IntPtr __刷新配置_NativeFunctionPtr;

		// Token: 0x04015920 RID: 88352
		private static IntPtr __GetConfigDataNameTagMap_NativeFunctionPtr;

		// Token: 0x04015921 RID: 88353
		private static IntPtr __GetConfigDataByKeyName_NativeFunctionPtr;

		// Token: 0x04015922 RID: 88354
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04015923 RID: 88355
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04015924 RID: 88356
		private static IntPtr __ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_NativeFunctionPtr;

		// Token: 0x0200A147 RID: 41287
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __GetConfigDataNameTagMap_FunctionParams
		{
			// Token: 0x04032E7D RID: 208509
			[FieldOffset(0)]
			public byte Result;
		}

		// Token: 0x0200A148 RID: 41288
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __GetConfigDataByKeyName_FunctionParams
		{
			// Token: 0x04032E7E RID: 208510
			[FieldOffset(0)]
			public FName Name;

			// Token: 0x04032E7F RID: 208511
			[FieldOffset(16)]
			public byte Result;
		}

		// Token: 0x0200A149 RID: 41289
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E80 RID: 208512
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A14A RID: 41290
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_Motor_BaseVehicle_MINI_BugFinder_FunctionParams
		{
			// Token: 0x04032E81 RID: 208513
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
