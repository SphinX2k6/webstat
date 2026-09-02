using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.Lensflare;
using AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.VolumetricConeLight;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Diy.HeadLight.Common.Component
{
	// Token: 0x02003FA4 RID: 16292
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Component/BP_MotorExtraComponent.BP_MotorExtraComponent_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 88)]
	public class BP_MotorExtraComponent_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028E5B RID: 167515 RVA: 0x00A19C44 File Offset: 0x00A17E44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MotorExtraComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Component/BP_MotorExtraComponent.BP_MotorExtraComponent_C");
			}
			return BP_MotorExtraComponent_C._ClassPtr;
		}

		// Token: 0x06028E5C RID: 167516 RVA: 0x00A19C68 File Offset: 0x00A17E68
		public BP_MotorExtraComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_MotorExtraComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028E5D RID: 167517 RVA: 0x00A19C90 File Offset: 0x00A17E90
		[NullableContext(1)]
		public BP_MotorExtraComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MotorExtraComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064BF RID: 25791
		// (get) Token: 0x06028E5E RID: 167518 RVA: 0x00A19CC3 File Offset: 0x00A17EC3
		// (set) Token: 0x06028E5F RID: 167519 RVA: 0x00A19CD7 File Offset: 0x00A17ED7
		public unsafe UKuroMaterialControllerComponent MaterialControllerComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMaterialControllerComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170064C0 RID: 25792
		// (get) Token: 0x06028E60 RID: 167520 RVA: 0x00A19CEC File Offset: 0x00A17EEC
		// (set) Token: 0x06028E61 RID: 167521 RVA: 0x00A19D00 File Offset: 0x00A17F00
		public unsafe AActor MotorActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170064C1 RID: 25793
		// (get) Token: 0x06028E62 RID: 167522 RVA: 0x00A19D15 File Offset: 0x00A17F15
		// (set) Token: 0x06028E63 RID: 167523 RVA: 0x00A19D29 File Offset: 0x00A17F29
		public unsafe ADecalActor DecalActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADecalActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170064C2 RID: 25794
		// (get) Token: 0x06028E64 RID: 167524 RVA: 0x00A19D3E File Offset: 0x00A17F3E
		// (set) Token: 0x06028E65 RID: 167525 RVA: 0x00A19D52 File Offset: 0x00A17F52
		public unsafe BP_SceneLensflare_Motor_C LensflareActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneLensflare_Motor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170064C3 RID: 25795
		// (get) Token: 0x06028E66 RID: 167526 RVA: 0x00A19D67 File Offset: 0x00A17F67
		// (set) Token: 0x06028E67 RID: 167527 RVA: 0x00A19D7B File Offset: 0x00A17F7B
		public unsafe BP_VolumetricConeLightShaft_InMotor_C VolumeLightActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_VolumetricConeLightShaft_InMotor_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorExtraComponent_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06028E68 RID: 167528 RVA: 0x00A19D90 File Offset: 0x00A17F90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisplayAllMotorExtraComponent_Func()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__DisplayAllMotorExtraComponent_Func_NativeFunctionPtr, null);
		}

		// Token: 0x06028E69 RID: 167529 RVA: 0x00A19DA4 File Offset: 0x00A17FA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void HiddenAllMotorExtraComponent_Func()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__HiddenAllMotorExtraComponent_Func_NativeFunctionPtr, null);
		}

		// Token: 0x06028E6A RID: 167530 RVA: 0x00A19DB8 File Offset: 0x00A17FB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveAllMotorExtraComponent_Func()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__RemoveAllMotorExtraComponent_Func_NativeFunctionPtr, null);
		}

		// Token: 0x06028E6B RID: 167531 RVA: 0x00A19DCC File Offset: 0x00A17FCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AddAllMotorExtraComponent_Func(UObject MotorSetupDA, AActor MotorActor)
		{
			BP_MotorExtraComponent_C.__AddAllMotorExtraComponent_Func_FunctionParams* ptr = stackalloc BP_MotorExtraComponent_C.__AddAllMotorExtraComponent_Func_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_MotorExtraComponent_C.__AddAllMotorExtraComponent_Func_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorExtraComponent_C.__AddAllMotorExtraComponent_Func_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MotorSetupDA = ((MotorSetupDA != null) ? MotorSetupDA.NativePtr : IntPtr.Zero);
			ptr->MotorActor = ((MotorActor != null) ? MotorActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__AddAllMotorExtraComponent_Func_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E6C RID: 167532 RVA: 0x00A19E38 File Offset: 0x00A18038
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupVolumeLight_Func(PD_MotorExtraComponentData_C MotorSetupDA, AActor MotorActor, USkeletalMeshComponent MotorSkeletalMeshActor)
		{
			BP_MotorExtraComponent_C.__SetupVolumeLight_Func_FunctionParams* ptr = stackalloc BP_MotorExtraComponent_C.__SetupVolumeLight_Func_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(BP_MotorExtraComponent_C.__SetupVolumeLight_Func_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorExtraComponent_C.__SetupVolumeLight_Func_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MotorSetupDA = ((MotorSetupDA != null) ? MotorSetupDA.NativePtr : IntPtr.Zero);
			ptr->MotorActor = ((MotorActor != null) ? MotorActor.NativePtr : IntPtr.Zero);
			ptr->MotorSkeletalMeshActor = ((MotorSkeletalMeshActor != null) ? MotorSkeletalMeshActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__SetupVolumeLight_Func_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E6D RID: 167533 RVA: 0x00A19EBC File Offset: 0x00A180BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupSceneLensflare_Func(PD_MotorExtraComponentData_C MotorSetupDA, AActor MotorActor, USkeletalMeshComponent MotorSkeletalMeshActor)
		{
			BP_MotorExtraComponent_C.__SetupSceneLensflare_Func_FunctionParams* ptr = stackalloc BP_MotorExtraComponent_C.__SetupSceneLensflare_Func_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(BP_MotorExtraComponent_C.__SetupSceneLensflare_Func_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorExtraComponent_C.__SetupSceneLensflare_Func_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MotorSetupDA = ((MotorSetupDA != null) ? MotorSetupDA.NativePtr : IntPtr.Zero);
			ptr->MotorActor = ((MotorActor != null) ? MotorActor.NativePtr : IntPtr.Zero);
			ptr->MotorSkeletalMeshActor = ((MotorSkeletalMeshActor != null) ? MotorSkeletalMeshActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__SetupSceneLensflare_Func_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E6E RID: 167534 RVA: 0x00A19F40 File Offset: 0x00A18140
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetupAoDecal_Func(PD_MotorExtraComponentData_C MotorSetupDA, AActor MotorActor, USkeletalMeshComponent MotorSkeletalMeshActor)
		{
			BP_MotorExtraComponent_C.__SetupAoDecal_Func_FunctionParams* ptr = stackalloc BP_MotorExtraComponent_C.__SetupAoDecal_Func_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(BP_MotorExtraComponent_C.__SetupAoDecal_Func_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorExtraComponent_C.__SetupAoDecal_Func_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MotorSetupDA = ((MotorSetupDA != null) ? MotorSetupDA.NativePtr : IntPtr.Zero);
			ptr->MotorActor = ((MotorActor != null) ? MotorActor.NativePtr : IntPtr.Zero);
			ptr->MotorSkeletalMeshActor = ((MotorSkeletalMeshActor != null) ? MotorSkeletalMeshActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorExtraComponent_C.__SetupAoDecal_Func_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028E6F RID: 167535 RVA: 0x00A19FC4 File Offset: 0x00A181C4
		protected BP_MotorExtraComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040159FC RID: 88572
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Diy/HeadLight/Common/Component/BP_MotorExtraComponent.BP_MotorExtraComponent_C";

		// Token: 0x040159FD RID: 88573
		private static IntPtr _ClassPtr;

		// Token: 0x040159FE RID: 88574
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040159FF RID: 88575
		internal static int __PropertyOffset_0;

		// Token: 0x04015A00 RID: 88576
		internal static int __PropertyOffset_1;

		// Token: 0x04015A01 RID: 88577
		internal static int __PropertyOffset_2;

		// Token: 0x04015A02 RID: 88578
		internal static int __PropertyOffset_3;

		// Token: 0x04015A03 RID: 88579
		internal static int __PropertyOffset_4;

		// Token: 0x04015A04 RID: 88580
		private static IntPtr __DisplayAllMotorExtraComponent_Func_NativeFunctionPtr;

		// Token: 0x04015A05 RID: 88581
		private static IntPtr __HiddenAllMotorExtraComponent_Func_NativeFunctionPtr;

		// Token: 0x04015A06 RID: 88582
		private static IntPtr __RemoveAllMotorExtraComponent_Func_NativeFunctionPtr;

		// Token: 0x04015A07 RID: 88583
		private static IntPtr __AddAllMotorExtraComponent_Func_NativeFunctionPtr;

		// Token: 0x04015A08 RID: 88584
		private static IntPtr __SetupVolumeLight_Func_NativeFunctionPtr;

		// Token: 0x04015A09 RID: 88585
		private static IntPtr __SetupSceneLensflare_Func_NativeFunctionPtr;

		// Token: 0x04015A0A RID: 88586
		private static IntPtr __SetupAoDecal_Func_NativeFunctionPtr;

		// Token: 0x0200A15D RID: 41309
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __AddAllMotorExtraComponent_Func_FunctionParams
		{
			// Token: 0x04032E96 RID: 208534
			[FieldOffset(0)]
			public IntPtr MotorSetupDA;

			// Token: 0x04032E97 RID: 208535
			[FieldOffset(8)]
			public IntPtr MotorActor;
		}

		// Token: 0x0200A15E RID: 41310
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __SetupVolumeLight_Func_FunctionParams
		{
			// Token: 0x04032E98 RID: 208536
			[FieldOffset(0)]
			public IntPtr MotorSetupDA;

			// Token: 0x04032E99 RID: 208537
			[FieldOffset(8)]
			public IntPtr MotorActor;

			// Token: 0x04032E9A RID: 208538
			[FieldOffset(16)]
			public IntPtr MotorSkeletalMeshActor;
		}

		// Token: 0x0200A15F RID: 41311
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __SetupSceneLensflare_Func_FunctionParams
		{
			// Token: 0x04032E9B RID: 208539
			[FieldOffset(0)]
			public IntPtr MotorSetupDA;

			// Token: 0x04032E9C RID: 208540
			[FieldOffset(8)]
			public IntPtr MotorActor;

			// Token: 0x04032E9D RID: 208541
			[FieldOffset(16)]
			public IntPtr MotorSkeletalMeshActor;
		}

		// Token: 0x0200A160 RID: 41312
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __SetupAoDecal_Func_FunctionParams
		{
			// Token: 0x04032E9E RID: 208542
			[FieldOffset(0)]
			public IntPtr MotorSetupDA;

			// Token: 0x04032E9F RID: 208543
			[FieldOffset(8)]
			public IntPtr MotorActor;

			// Token: 0x04032EA0 RID: 208544
			[FieldOffset(16)]
			public IntPtr MotorSkeletalMeshActor;
		}
	}
}
