using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F97 RID: 16279
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Photo.BP_Motor_BaseVehicle_Photo_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_Motor_BaseVehicle_Photo_C : BP_BaseVehicle_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028CF7 RID: 167159 RVA: 0x00A17484 File Offset: 0x00A15684
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Motor_BaseVehicle_Photo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Photo.BP_Motor_BaseVehicle_Photo_C");
			}
			return BP_Motor_BaseVehicle_Photo_C._ClassPtr;
		}

		// Token: 0x06028CF8 RID: 167160 RVA: 0x00A174A8 File Offset: 0x00A156A8
		public BP_Motor_BaseVehicle_Photo_C() : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Photo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028CF9 RID: 167161 RVA: 0x00A174D0 File Offset: 0x00A156D0
		[NullableContext(1)]
		public BP_Motor_BaseVehicle_Photo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Motor_BaseVehicle_Photo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700643B RID: 25659
		// (get) Token: 0x06028CFA RID: 167162 RVA: 0x00A17504 File Offset: 0x00A15704
		// (set) Token: 0x06028CFB RID: 167163 RVA: 0x00A1753D File Offset: 0x00A1573D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700643C RID: 25660
		// (get) Token: 0x06028CFC RID: 167164 RVA: 0x00A1755E File Offset: 0x00A1575E
		// (set) Token: 0x06028CFD RID: 167165 RVA: 0x00A17572 File Offset: 0x00A15772
		public unsafe USkeletalMeshComponent OtherCase5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700643D RID: 25661
		// (get) Token: 0x06028CFE RID: 167166 RVA: 0x00A17587 File Offset: 0x00A15787
		// (set) Token: 0x06028CFF RID: 167167 RVA: 0x00A1759B File Offset: 0x00A1579B
		public unsafe USkeletalMeshComponent OtherCase4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700643E RID: 25662
		// (get) Token: 0x06028D00 RID: 167168 RVA: 0x00A175B0 File Offset: 0x00A157B0
		// (set) Token: 0x06028D01 RID: 167169 RVA: 0x00A175C4 File Offset: 0x00A157C4
		public unsafe USphereComponent SphereForInteraction2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700643F RID: 25663
		// (get) Token: 0x06028D02 RID: 167170 RVA: 0x00A175D9 File Offset: 0x00A157D9
		// (set) Token: 0x06028D03 RID: 167171 RVA: 0x00A175ED File Offset: 0x00A157ED
		public unsafe USphereComponent SphereForInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17006440 RID: 25664
		// (get) Token: 0x06028D04 RID: 167172 RVA: 0x00A17602 File Offset: 0x00A15802
		// (set) Token: 0x06028D05 RID: 167173 RVA: 0x00A17616 File Offset: 0x00A15816
		public unsafe UCapsuleComponent CapsuleForTriggerAndBlockOtherVehicle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17006441 RID: 25665
		// (get) Token: 0x06028D06 RID: 167174 RVA: 0x00A1762B File Offset: 0x00A1582B
		// (set) Token: 0x06028D07 RID: 167175 RVA: 0x00A1763F File Offset: 0x00A1583F
		public unsafe UCapsuleComponent CapsuleForDither
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17006442 RID: 25666
		// (get) Token: 0x06028D08 RID: 167176 RVA: 0x00A17654 File Offset: 0x00A15854
		// (set) Token: 0x06028D09 RID: 167177 RVA: 0x00A17668 File Offset: 0x00A15868
		public unsafe USkeletalMeshComponent OtherCase3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17006443 RID: 25667
		// (get) Token: 0x06028D0A RID: 167178 RVA: 0x00A1767D File Offset: 0x00A1587D
		// (set) Token: 0x06028D0B RID: 167179 RVA: 0x00A17691 File Offset: 0x00A15891
		public unsafe USkeletalMeshComponent OtherCase2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17006444 RID: 25668
		// (get) Token: 0x06028D0C RID: 167180 RVA: 0x00A176A6 File Offset: 0x00A158A6
		// (set) Token: 0x06028D0D RID: 167181 RVA: 0x00A176BA File Offset: 0x00A158BA
		public unsafe USkeletalMeshComponent OtherCase1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17006445 RID: 25669
		// (get) Token: 0x06028D0E RID: 167182 RVA: 0x00A176CF File Offset: 0x00A158CF
		// (set) Token: 0x06028D0F RID: 167183 RVA: 0x00A176E3 File Offset: 0x00A158E3
		public unsafe UCapsuleComponent CapsuleForPhotograph
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17006446 RID: 25670
		// (get) Token: 0x06028D10 RID: 167184 RVA: 0x00A176F8 File Offset: 0x00A158F8
		// (set) Token: 0x06028D11 RID: 167185 RVA: 0x00A1770C File Offset: 0x00A1590C
		public unsafe UDataTable 技能表_用于加载_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17006447 RID: 25671
		// (get) Token: 0x06028D12 RID: 167186 RVA: 0x00A17721 File Offset: 0x00A15921
		// (set) Token: 0x06028D13 RID: 167187 RVA: 0x00A17731 File Offset: 0x00A15931
		public unsafe float 虚化碰撞NPC半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006448 RID: 25672
		// (get) Token: 0x06028D14 RID: 167188 RVA: 0x00A17742 File Offset: 0x00A15942
		// (set) Token: 0x06028D15 RID: 167189 RVA: 0x00A17756 File Offset: 0x00A15956
		public unsafe UCurveFloat 深度虚化值曲线
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Motor_BaseVehicle_Photo_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x06028D16 RID: 167190 RVA: 0x00A1776B File Offset: 0x00A1596B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 刷新配置()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__刷新配置_NativeFunctionPtr, null);
		}

		// Token: 0x06028D17 RID: 167191 RVA: 0x00A17780 File Offset: 0x00A15980
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetConfigDataNameTagMap(ref TMap<FName, FGameplayTag> Result)
		{
			BP_Motor_BaseVehicle_Photo_C.__GetConfigDataNameTagMap_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_Photo_C.__GetConfigDataNameTagMap_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_Motor_BaseVehicle_Photo_C.__GetConfigDataNameTagMap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_Photo_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr, 1);
			TMap<FName, FGameplayTag> tmap = Result;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->Result);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr);
			TMap<FName, FGameplayTag> tmap2 = Result;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->Result);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Motor_BaseVehicle_Photo_C.__GetConfigDataNameTagMap_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028D18 RID: 167192 RVA: 0x00A177FC File Offset: 0x00A159FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetConfigDataByKeyName(FName Name, ref SMotorConfigs Result)
		{
			BP_Motor_BaseVehicle_Photo_C.__GetConfigDataByKeyName_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_Photo_C.__GetConfigDataByKeyName_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_Motor_BaseVehicle_Photo_C.__GetConfigDataByKeyName_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_Photo_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Name = Name;
			if (Result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorConfigs.StaticStruct(), &ptr->Result, Result.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr);
			if (Result != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SMotorConfigs.StaticStruct(), Result.NativePtr, &ptr->Result, 1, false);
			}
			UnrealReflectionUtils.DestroyStruct(BP_Motor_BaseVehicle_Photo_C.__GetConfigDataByKeyName_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06028D19 RID: 167193 RVA: 0x00A1789E File Offset: 0x00A15A9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028D1A RID: 167194 RVA: 0x00A178B2 File Offset: 0x00A15AB2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028D1B RID: 167195 RVA: 0x00A178C8 File Offset: 0x00A15AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028D1C RID: 167196 RVA: 0x00A17910 File Offset: 0x00A15B10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028D1D RID: 167197 RVA: 0x00A17958 File Offset: 0x00A15B58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Motor_BaseVehicle_Photo(int EntryPoint)
		{
			BP_Motor_BaseVehicle_Photo_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_FunctionParams* ptr = stackalloc BP_Motor_BaseVehicle_Photo_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Motor_BaseVehicle_Photo_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Motor_BaseVehicle_Photo_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Motor_BaseVehicle_Photo_C.__ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028D1E RID: 167198 RVA: 0x00A1799F File Offset: 0x00A15B9F
		protected BP_Motor_BaseVehicle_Photo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015925 RID: 88357
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/BP_Motor_BaseVehicle_Photo.BP_Motor_BaseVehicle_Photo_C";

		// Token: 0x04015926 RID: 88358
		private static IntPtr _ClassPtr;

		// Token: 0x04015927 RID: 88359
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015928 RID: 88360
		internal static int __PropertyOffset_0;

		// Token: 0x04015929 RID: 88361
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401592A RID: 88362
		internal static int __PropertyOffset_1;

		// Token: 0x0401592B RID: 88363
		internal static int __PropertyOffset_2;

		// Token: 0x0401592C RID: 88364
		internal static int __PropertyOffset_3;

		// Token: 0x0401592D RID: 88365
		internal static int __PropertyOffset_4;

		// Token: 0x0401592E RID: 88366
		internal static int __PropertyOffset_5;

		// Token: 0x0401592F RID: 88367
		internal static int __PropertyOffset_6;

		// Token: 0x04015930 RID: 88368
		internal static int __PropertyOffset_7;

		// Token: 0x04015931 RID: 88369
		internal static int __PropertyOffset_8;

		// Token: 0x04015932 RID: 88370
		internal static int __PropertyOffset_9;

		// Token: 0x04015933 RID: 88371
		internal static int __PropertyOffset_10;

		// Token: 0x04015934 RID: 88372
		internal static int __PropertyOffset_11;

		// Token: 0x04015935 RID: 88373
		internal static int __PropertyOffset_12;

		// Token: 0x04015936 RID: 88374
		internal static int __PropertyOffset_13;

		// Token: 0x04015937 RID: 88375
		private static IntPtr __刷新配置_NativeFunctionPtr;

		// Token: 0x04015938 RID: 88376
		private static IntPtr __GetConfigDataNameTagMap_NativeFunctionPtr;

		// Token: 0x04015939 RID: 88377
		private static IntPtr __GetConfigDataByKeyName_NativeFunctionPtr;

		// Token: 0x0401593A RID: 88378
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401593B RID: 88379
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401593C RID: 88380
		private static IntPtr __ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_NativeFunctionPtr;

		// Token: 0x0200A14B RID: 41291
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __GetConfigDataNameTagMap_FunctionParams
		{
			// Token: 0x04032E82 RID: 208514
			[FieldOffset(0)]
			public byte Result;
		}

		// Token: 0x0200A14C RID: 41292
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __GetConfigDataByKeyName_FunctionParams
		{
			// Token: 0x04032E83 RID: 208515
			[FieldOffset(0)]
			public FName Name;

			// Token: 0x04032E84 RID: 208516
			[FieldOffset(16)]
			public byte Result;
		}

		// Token: 0x0200A14D RID: 41293
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032E85 RID: 208517
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A14E RID: 41294
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_Motor_BaseVehicle_Photo_FunctionParams
		{
			// Token: 0x04032E86 RID: 208518
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
