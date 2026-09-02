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
	// Token: 0x02003F93 RID: 16275
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle.BP_Motor_BaseVehicle_C")]
	[UnrealStructLayout(2256, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2256)]
	public class BP_Motor_BaseVehicle_C : BP_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028C8D RID: 167053 RVA: 0x00A167B8 File Offset: 0x00A149B8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle.BP_Motor_BaseVehicle_C");
			}
			return BP_Motor_BaseVehicle_C._ClassPtr;
		}

		// Token: 0x06028C8E RID: 167054 RVA: 0x00A167DC File Offset: 0x00A149DC
		public BP_Motor_BaseVehicle_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028C8F RID: 167055 RVA: 0x00A16804 File Offset: 0x00A14A04
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006419 RID: 25625
		// (get) Token: 0x06028C90 RID: 167056 RVA: 0x00A16838 File Offset: 0x00A14A38
		// (set) Token: 0x06028C91 RID: 167057 RVA: 0x00A16871 File Offset: 0x00A14A71
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700641A RID: 25626
		// (get) Token: 0x06028C92 RID: 167058 RVA: 0x00A16892 File Offset: 0x00A14A92
		// (set) Token: 0x06028C93 RID: 167059 RVA: 0x00A168A6 File Offset: 0x00A14AA6
		public unsafe BP_MotorObjTrailActor_C BP_MotorObjTrailActor2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MotorObjTrailActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700641B RID: 25627
		// (get) Token: 0x06028C94 RID: 167060 RVA: 0x00A168BB File Offset: 0x00A14ABB
		// (set) Token: 0x06028C95 RID: 167061 RVA: 0x00A168CF File Offset: 0x00A14ACF
		public unsafe BP_MotorObjTrailActor_C BP_MotorObjTrailActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MotorObjTrailActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700641C RID: 25628
		// (get) Token: 0x06028C96 RID: 167062 RVA: 0x00A168E4 File Offset: 0x00A14AE4
		// (set) Token: 0x06028C97 RID: 167063 RVA: 0x00A168F8 File Offset: 0x00A14AF8
		public unsafe USkeletalMeshComponent OtherCase5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700641D RID: 25629
		// (get) Token: 0x06028C98 RID: 167064 RVA: 0x00A1690D File Offset: 0x00A14B0D
		// (set) Token: 0x06028C99 RID: 167065 RVA: 0x00A16921 File Offset: 0x00A14B21
		public unsafe USkeletalMeshComponent OtherCase4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700641E RID: 25630
		// (get) Token: 0x06028C9A RID: 167066 RVA: 0x00A16936 File Offset: 0x00A14B36
		// (set) Token: 0x06028C9B RID: 167067 RVA: 0x00A1694A File Offset: 0x00A14B4A
		public unsafe USphereComponent SphereForInteraction2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700641F RID: 25631
		// (get) Token: 0x06028C9C RID: 167068 RVA: 0x00A1695F File Offset: 0x00A14B5F
		// (set) Token: 0x06028C9D RID: 167069 RVA: 0x00A16973 File Offset: 0x00A14B73
		public unsafe USphereComponent SphereForInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17006420 RID: 25632
		// (get) Token: 0x06028C9E RID: 167070 RVA: 0x00A16988 File Offset: 0x00A14B88
		// (set) Token: 0x06028C9F RID: 167071 RVA: 0x00A1699C File Offset: 0x00A14B9C
		public unsafe UCapsuleComponent CapsuleForTriggerAndBlock
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17006421 RID: 25633
		// (get) Token: 0x06028CA0 RID: 167072 RVA: 0x00A169B1 File Offset: 0x00A14BB1
		// (set) Token: 0x06028CA1 RID: 167073 RVA: 0x00A169C5 File Offset: 0x00A14BC5
		public unsafe UCapsuleComponent CapsuleForDither
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17006422 RID: 25634
		// (get) Token: 0x06028CA2 RID: 167074 RVA: 0x00A169DA File Offset: 0x00A14BDA
		// (set) Token: 0x06028CA3 RID: 167075 RVA: 0x00A169EE File Offset: 0x00A14BEE
		public unsafe USkeletalMeshComponent OtherCase3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17006423 RID: 25635
		// (get) Token: 0x06028CA4 RID: 167076 RVA: 0x00A16A03 File Offset: 0x00A14C03
		// (set) Token: 0x06028CA5 RID: 167077 RVA: 0x00A16A17 File Offset: 0x00A14C17
		public unsafe USkeletalMeshComponent OtherCase2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17006424 RID: 25636
		// (get) Token: 0x06028CA6 RID: 167078 RVA: 0x00A16A2C File Offset: 0x00A14C2C
		// (set) Token: 0x06028CA7 RID: 167079 RVA: 0x00A16A40 File Offset: 0x00A14C40
		public unsafe USkeletalMeshComponent OtherCase1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17006425 RID: 25637
		// (get) Token: 0x06028CA8 RID: 167080 RVA: 0x00A16A55 File Offset: 0x00A14C55
		// (set) Token: 0x06028CA9 RID: 167081 RVA: 0x00A16A69 File Offset: 0x00A14C69
		public unsafe UCapsuleComponent CapsuleForPhotograph
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17006426 RID: 25638
		// (get) Token: 0x06028CAA RID: 167082 RVA: 0x00A16A7E File Offset: 0x00A14C7E
		// (set) Token: 0x06028CAB RID: 167083 RVA: 0x00A16A92 File Offset: 0x00A14C92
		public unsafe UDataTable 技能表_用于加载_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17006427 RID: 25639
		// (get) Token: 0x06028CAC RID: 167084 RVA: 0x00A16AA7 File Offset: 0x00A14CA7
		// (set) Token: 0x06028CAD RID: 167085 RVA: 0x00A16AB7 File Offset: 0x00A14CB7
		public unsafe float 虚化碰撞NPC半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006428 RID: 25640
		// (get) Token: 0x06028CAE RID: 167086 RVA: 0x00A16AC8 File Offset: 0x00A14CC8
		// (set) Token: 0x06028CAF RID: 167087 RVA: 0x00A16ADC File Offset: 0x00A14CDC
		public unsafe UCurveFloat 深度虚化值曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x06028CB0 RID: 167088 RVA: 0x00A16AF1 File Offset: 0x00A14CF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 解锁最高速度()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__解锁最高速度_NativeFunctionPtr, null);
		}

		// Token: 0x06028CB1 RID: 167089 RVA: 0x00A16B05 File Offset: 0x00A14D05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 打开关闭Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__打开关闭Debug_NativeFunctionPtr, null);
		}

		// Token: 0x06028CB2 RID: 167090 RVA: 0x00A16B19 File Offset: 0x00A14D19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 解锁二段跳_蓄力跳_新退场技()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__解锁二段跳_蓄力跳_新退场技_NativeFunctionPtr, null);
		}

		// Token: 0x06028CB3 RID: 167091 RVA: 0x00A16B2D File Offset: 0x00A14D2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 刷新配置()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__刷新配置_NativeFunctionPtr, null);
		}

		// Token: 0x06028CB4 RID: 167092 RVA: 0x00A16B44 File Offset: 0x00A14D44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetConfigDataNameTagMap(ref TMap<FName, FGameplayTag> Result)
		{
			BP_Motor_BaseVehicle_C.__GetConfigDataNameTagMap_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_C.__GetConfigDataNameTagMap_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_Motor_BaseVehicle_C.__GetConfigDataNameTagMap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FGameplayTag> tmap = Result;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->Result);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FGameplayTag> tmap2 = Result;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->Result);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Motor_BaseVehicle_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028CB5 RID: 167093 RVA: 0x00A16BC0 File Offset: 0x00A14DC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetConfigDataByKeyName(FName Name, ref SMotorConfigs Result)
		{
			BP_Motor_BaseVehicle_C.__GetConfigDataByKeyName_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_C.__GetConfigDataByKeyName_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_Motor_BaseVehicle_C.__GetConfigDataByKeyName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			if (Result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorConfigs.StaticStruct(), &ptr->Result, Result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr);
			if (Result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorConfigs.StaticStruct(), Result.NativePtr, &ptr->Result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Motor_BaseVehicle_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028CB6 RID: 167094 RVA: 0x00A16C64 File Offset: 0x00A14E64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Motor_BaseVehicle_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Motor_BaseVehicle_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028CB7 RID: 167095 RVA: 0x00A16CAC File Offset: 0x00A14EAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Motor_BaseVehicle_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Motor_BaseVehicle_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028CB8 RID: 167096 RVA: 0x00A16CF3 File Offset: 0x00A14EF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028CB9 RID: 167097 RVA: 0x00A16D07 File Offset: 0x00A14F07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028CBA RID: 167098 RVA: 0x00A16D1C File Offset: 0x00A14F1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Motor_BaseVehicle(int EntryPoint)
		{
			BP_Motor_BaseVehicle_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Motor_BaseVehicle_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028CBB RID: 167099 RVA: 0x00A16D63 File Offset: 0x00A14F63
		protected BP_Motor_BaseVehicle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040158E3 RID: 88291
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle.BP_Motor_BaseVehicle_C";

		// Token: 0x040158E4 RID: 88292
		private static IntPtr _ClassPtr;

		// Token: 0x040158E5 RID: 88293
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040158E6 RID: 88294
		internal static int __PropertyOffset_0;

		// Token: 0x040158E7 RID: 88295
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040158E8 RID: 88296
		internal static int __PropertyOffset_1;

		// Token: 0x040158E9 RID: 88297
		internal static int __PropertyOffset_2;

		// Token: 0x040158EA RID: 88298
		internal static int __PropertyOffset_3;

		// Token: 0x040158EB RID: 88299
		internal static int __PropertyOffset_4;

		// Token: 0x040158EC RID: 88300
		internal static int __PropertyOffset_5;

		// Token: 0x040158ED RID: 88301
		internal static int __PropertyOffset_6;

		// Token: 0x040158EE RID: 88302
		internal static int __PropertyOffset_7;

		// Token: 0x040158EF RID: 88303
		internal static int __PropertyOffset_8;

		// Token: 0x040158F0 RID: 88304
		internal static int __PropertyOffset_9;

		// Token: 0x040158F1 RID: 88305
		internal static int __PropertyOffset_10;

		// Token: 0x040158F2 RID: 88306
		internal static int __PropertyOffset_11;

		// Token: 0x040158F3 RID: 88307
		internal static int __PropertyOffset_12;

		// Token: 0x040158F4 RID: 88308
		internal static int __PropertyOffset_13;

		// Token: 0x040158F5 RID: 88309
		internal static int __PropertyOffset_14;

		// Token: 0x040158F6 RID: 88310
		internal static int __PropertyOffset_15;

		// Token: 0x040158F7 RID: 88311
		private static IntPtr __解锁最高速度_NativeFunctionPtr;

		// Token: 0x040158F8 RID: 88312
		private static IntPtr __打开关闭Debug_NativeFunctionPtr;

		// Token: 0x040158F9 RID: 88313
		private static IntPtr __解锁二段跳_蓄力跳_新退场技_NativeFunctionPtr;

		// Token: 0x040158FA RID: 88314
		private static IntPtr __刷新配置_NativeFunctionPtr;

		// Token: 0x040158FB RID: 88315
		private static IntPtr __GetConfigDataNameTagMap_NativeFunctionPtr;

		// Token: 0x040158FC RID: 88316
		private static IntPtr __GetConfigDataByKeyName_NativeFunctionPtr;

		// Token: 0x040158FD RID: 88317
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040158FE RID: 88318
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040158FF RID: 88319
		private static IntPtr __ExecuteUbergraph_BP_Motor_BaseVehicle_NativeFunctionPtr;

		// Token: 0x0200A143 RID: 41283
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __GetConfigDataNameTagMap_FunctionParams
		{
			// Token: 0x04032E78 RID: 208504
			[FieldOffset(0)]
			public byte Result;
		}

		// Token: 0x0200A144 RID: 41284
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __GetConfigDataByKeyName_FunctionParams
		{
			// Token: 0x04032E79 RID: 208505
			[FieldOffset(0)]
			public FName Name;

			// Token: 0x04032E7A RID: 208506
			[FieldOffset(16)]
			public byte Result;
		}

		// Token: 0x0200A145 RID: 41285
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E7B RID: 208507
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A146 RID: 41286
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_Motor_BaseVehicle_FunctionParams
		{
			// Token: 0x04032E7C RID: 208508
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
