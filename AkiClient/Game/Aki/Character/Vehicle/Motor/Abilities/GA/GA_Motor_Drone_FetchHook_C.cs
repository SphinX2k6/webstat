using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Fight.FollowShooter.DeadEye;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FC8 RID: 16328
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FetchHook.GA_Motor_Drone_FetchHook_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1540)]
	public class GA_Motor_Drone_FetchHook_C : GA_Motor_DroneBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028FE4 RID: 167908 RVA: 0x00A1D8CC File Offset: 0x00A1BACC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Drone_FetchHook_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FetchHook.GA_Motor_Drone_FetchHook_C");
			}
			return GA_Motor_Drone_FetchHook_C._ClassPtr;
		}

		// Token: 0x06028FE5 RID: 167909 RVA: 0x00A1D8F0 File Offset: 0x00A1BAF0
		public GA_Motor_Drone_FetchHook_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_FetchHook_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028FE6 RID: 167910 RVA: 0x00A1D918 File Offset: 0x00A1BB18
		[NullableContext(1)]
		public GA_Motor_Drone_FetchHook_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Drone_FetchHook_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006503 RID: 25859
		// (get) Token: 0x06028FE7 RID: 167911 RVA: 0x00A1D94C File Offset: 0x00A1BB4C
		// (set) Token: 0x06028FE8 RID: 167912 RVA: 0x00A1D985 File Offset: 0x00A1BB85
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Drone_FetchHook_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Drone_FetchHook_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006504 RID: 25860
		// (get) Token: 0x06028FE9 RID: 167913 RVA: 0x00A1D9A6 File Offset: 0x00A1BBA6
		// (set) Token: 0x06028FEA RID: 167914 RVA: 0x00A1D9BA File Offset: 0x00A1BBBA
		[Nullable(2)]
		public unsafe BP_FollowShooterDeadEyeConfig_C DeadEyeConfig
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_FollowShooterDeadEyeConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Drone_FetchHook_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Drone_FetchHook_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006505 RID: 25861
		// (get) Token: 0x06028FEB RID: 167915 RVA: 0x00A1D9CF File Offset: 0x00A1BBCF
		// (set) Token: 0x06028FEC RID: 167916 RVA: 0x00A1D9DF File Offset: 0x00A1BBDF
		public unsafe int Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Drone_FetchHook_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Drone_FetchHook_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x06028FED RID: 167917 RVA: 0x00A1D9F0 File Offset: 0x00A1BBF0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F(USceneComponent AimPivot)
		{
			GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FEE RID: 167918 RVA: 0x00A1DA48 File Offset: 0x00A1BC48
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F(USceneComponent AimPivot, FVector TargetLocation)
		{
			GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			ptr->TargetLocation = TargetLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FEF RID: 167919 RVA: 0x00A1DAA4 File Offset: 0x00A1BCA4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A(USceneComponent AimPivot)
		{
			GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FF0 RID: 167920 RVA: 0x00A1DAFC File Offset: 0x00A1BCFC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A(USceneComponent AimPivot, FVector TargetLocation)
		{
			GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			ptr->TargetLocation = TargetLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FF1 RID: 167921 RVA: 0x00A1DB58 File Offset: 0x00A1BD58
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF(USceneComponent AimPivot)
		{
			GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FF2 RID: 167922 RVA: 0x00A1DBB0 File Offset: 0x00A1BDB0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF(USceneComponent AimPivot, FVector TargetLocation)
		{
			GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			ptr->TargetLocation = TargetLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FF3 RID: 167923 RVA: 0x00A1DC0C File Offset: 0x00A1BE0C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775(USceneComponent AimPivot)
		{
			GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FF4 RID: 167924 RVA: 0x00A1DC64 File Offset: 0x00A1BE64
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775(USceneComponent AimPivot, FVector TargetLocation)
		{
			GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_NativeFunctionPtr, (void*)ptr, 1);
			ptr->AimPivot = ((AimPivot != null) ? AimPivot.NativePtr : IntPtr.Zero);
			ptr->TargetLocation = TargetLocation;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028FF5 RID: 167925 RVA: 0x00A1DCC0 File Offset: 0x00A1BEC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06028FF6 RID: 167926 RVA: 0x00A1DCD4 File Offset: 0x00A1BED4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028FF7 RID: 167927 RVA: 0x00A1DCEC File Offset: 0x00A1BEEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Drone_FetchHook(int EntryPoint)
		{
			GA_Motor_Drone_FetchHook_C.__ExecuteUbergraph_GA_Motor_Drone_FetchHook_FunctionParams* ptr = stackalloc GA_Motor_Drone_FetchHook_C.__ExecuteUbergraph_GA_Motor_Drone_FetchHook_FunctionParams[(UIntPtr)1471] + 15L / (long)sizeof(GA_Motor_Drone_FetchHook_C.__ExecuteUbergraph_GA_Motor_Drone_FetchHook_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Drone_FetchHook_C.__ExecuteUbergraph_GA_Motor_Drone_FetchHook_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Drone_FetchHook_C.__ExecuteUbergraph_GA_Motor_Drone_FetchHook_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028FF8 RID: 167928 RVA: 0x00A1DD36 File Offset: 0x00A1BF36
		protected GA_Motor_Drone_FetchHook_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015B2E RID: 88878
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Drone_FetchHook.GA_Motor_Drone_FetchHook_C";

		// Token: 0x04015B2F RID: 88879
		private static IntPtr _ClassPtr;

		// Token: 0x04015B30 RID: 88880
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015B31 RID: 88881
		internal new static int __PropertyOffset_0;

		// Token: 0x04015B32 RID: 88882
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015B33 RID: 88883
		internal new static int __PropertyOffset_1;

		// Token: 0x04015B34 RID: 88884
		internal new static int __PropertyOffset_2;

		// Token: 0x04015B35 RID: 88885
		private static IntPtr __OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_NativeFunctionPtr;

		// Token: 0x04015B36 RID: 88886
		private static IntPtr __OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_NativeFunctionPtr;

		// Token: 0x04015B37 RID: 88887
		private static IntPtr __OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_NativeFunctionPtr;

		// Token: 0x04015B38 RID: 88888
		private static IntPtr __OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_NativeFunctionPtr;

		// Token: 0x04015B39 RID: 88889
		private static IntPtr __OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_NativeFunctionPtr;

		// Token: 0x04015B3A RID: 88890
		private static IntPtr __OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_NativeFunctionPtr;

		// Token: 0x04015B3B RID: 88891
		private static IntPtr __OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_NativeFunctionPtr;

		// Token: 0x04015B3C RID: 88892
		private static IntPtr __OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_NativeFunctionPtr;

		// Token: 0x04015B3D RID: 88893
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015B3E RID: 88894
		private static IntPtr __ExecuteUbergraph_GA_Motor_Drone_FetchHook_NativeFunctionPtr;

		// Token: 0x0200A194 RID: 41364
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnSequenceFinished_D3BEE19E4FC298531A14328D25806F3F_FunctionParams
		{
			// Token: 0x04032EE8 RID: 208616
			[FieldOffset(0)]
			public IntPtr AimPivot;
		}

		// Token: 0x0200A195 RID: 41365
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnShootStepFired_D3BEE19E4FC298531A14328D25806F3F_FunctionParams
		{
			// Token: 0x04032EE9 RID: 208617
			[FieldOffset(0)]
			public IntPtr AimPivot;

			// Token: 0x04032EEA RID: 208618
			[FieldOffset(8)]
			public FVector TargetLocation;
		}

		// Token: 0x0200A196 RID: 41366
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnSequenceFinished_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams
		{
			// Token: 0x04032EEB RID: 208619
			[FieldOffset(0)]
			public IntPtr AimPivot;
		}

		// Token: 0x0200A197 RID: 41367
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnShootStepFired_D3BEE19E4FC298531A14328D7FD4119A_FunctionParams
		{
			// Token: 0x04032EEC RID: 208620
			[FieldOffset(0)]
			public IntPtr AimPivot;

			// Token: 0x04032EED RID: 208621
			[FieldOffset(8)]
			public FVector TargetLocation;
		}

		// Token: 0x0200A198 RID: 41368
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnSequenceFinished_D3BEE19E4FC298531A14328D74F690BF_FunctionParams
		{
			// Token: 0x04032EEE RID: 208622
			[FieldOffset(0)]
			public IntPtr AimPivot;
		}

		// Token: 0x0200A199 RID: 41369
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnShootStepFired_D3BEE19E4FC298531A14328D74F690BF_FunctionParams
		{
			// Token: 0x04032EEF RID: 208623
			[FieldOffset(0)]
			public IntPtr AimPivot;

			// Token: 0x04032EF0 RID: 208624
			[FieldOffset(8)]
			public FVector TargetLocation;
		}

		// Token: 0x0200A19A RID: 41370
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __OnSequenceFinished_D3BEE19E4FC298531A14328DF0F60775_FunctionParams
		{
			// Token: 0x04032EF1 RID: 208625
			[FieldOffset(0)]
			public IntPtr AimPivot;
		}

		// Token: 0x0200A19B RID: 41371
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __OnShootStepFired_D3BEE19E4FC298531A14328DF0F60775_FunctionParams
		{
			// Token: 0x04032EF2 RID: 208626
			[FieldOffset(0)]
			public IntPtr AimPivot;

			// Token: 0x04032EF3 RID: 208627
			[FieldOffset(8)]
			public FVector TargetLocation;
		}

		// Token: 0x0200A19C RID: 41372
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1456)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Drone_FetchHook_FunctionParams
		{
			// Token: 0x04032EF4 RID: 208628
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
