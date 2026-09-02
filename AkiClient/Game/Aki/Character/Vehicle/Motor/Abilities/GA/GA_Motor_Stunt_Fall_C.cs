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
	// Token: 0x02003FE8 RID: 16360
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_Fall.GA_Motor_Stunt_Fall_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Stunt_Fall_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029302 RID: 168706 RVA: 0x00A240AB File Offset: 0x00A222AB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Stunt_Fall_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_Fall.GA_Motor_Stunt_Fall_C");
			}
			return GA_Motor_Stunt_Fall_C._ClassPtr;
		}

		// Token: 0x06029303 RID: 168707 RVA: 0x00A240D0 File Offset: 0x00A222D0
		public GA_Motor_Stunt_Fall_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_Fall_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029304 RID: 168708 RVA: 0x00A240F8 File Offset: 0x00A222F8
		public GA_Motor_Stunt_Fall_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_Fall_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006594 RID: 26004
		// (get) Token: 0x06029305 RID: 168709 RVA: 0x00A2412C File Offset: 0x00A2232C
		// (set) Token: 0x06029306 RID: 168710 RVA: 0x00A24165 File Offset: 0x00A22365
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Stunt_Fall_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_Fall_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006595 RID: 26005
		// (get) Token: 0x06029307 RID: 168711 RVA: 0x00A24186 File Offset: 0x00A22386
		// (set) Token: 0x06029308 RID: 168712 RVA: 0x00A2419A File Offset: 0x00A2239A
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_Fall_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_Fall_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006596 RID: 26006
		// (get) Token: 0x06029309 RID: 168713 RVA: 0x00A241B0 File Offset: 0x00A223B0
		// (set) Token: 0x0602930A RID: 168714 RVA: 0x00A241E9 File Offset: 0x00A223E9
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_Stunt_Fall_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_Fall_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602930B RID: 168715 RVA: 0x00A2420A File Offset: 0x00A2240A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BE8CC028C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__OnTick_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr, null);
		}

		// Token: 0x0602930C RID: 168716 RVA: 0x00A2421E File Offset: 0x00A2241E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BE8CC028C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr, null);
		}

		// Token: 0x0602930D RID: 168717 RVA: 0x00A24232 File Offset: 0x00A22432
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BE8CC028C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr, null);
		}

		// Token: 0x0602930E RID: 168718 RVA: 0x00A24246 File Offset: 0x00A22446
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BE8CC028C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr, null);
		}

		// Token: 0x0602930F RID: 168719 RVA: 0x00A2425A File Offset: 0x00A2245A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BE8CC028C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr, null);
		}

		// Token: 0x06029310 RID: 168720 RVA: 0x00A2426E File Offset: 0x00A2246E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029311 RID: 168721 RVA: 0x00A24282 File Offset: 0x00A22482
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029312 RID: 168722 RVA: 0x00A24298 File Offset: 0x00A22498
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029313 RID: 168723 RVA: 0x00A242E0 File Offset: 0x00A224E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029314 RID: 168724 RVA: 0x00A24328 File Offset: 0x00A22528
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Stunt_Fall(int EntryPoint)
		{
			GA_Motor_Stunt_Fall_C.__ExecuteUbergraph_GA_Motor_Stunt_Fall_FunctionParams* ptr = stackalloc GA_Motor_Stunt_Fall_C.__ExecuteUbergraph_GA_Motor_Stunt_Fall_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(GA_Motor_Stunt_Fall_C.__ExecuteUbergraph_GA_Motor_Stunt_Fall_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_Fall_C.__ExecuteUbergraph_GA_Motor_Stunt_Fall_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_Fall_C.__ExecuteUbergraph_GA_Motor_Stunt_Fall_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029315 RID: 168725 RVA: 0x00A24372 File Offset: 0x00A22572
		protected GA_Motor_Stunt_Fall_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D84 RID: 89476
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_Fall.GA_Motor_Stunt_Fall_C";

		// Token: 0x04015D85 RID: 89477
		private static IntPtr _ClassPtr;

		// Token: 0x04015D86 RID: 89478
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D87 RID: 89479
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D88 RID: 89480
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D89 RID: 89481
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D8A RID: 89482
		internal new static int __PropertyOffset_2;

		// Token: 0x04015D8B RID: 89483
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015D8C RID: 89484
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr;

		// Token: 0x04015D8D RID: 89485
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr;

		// Token: 0x04015D8E RID: 89486
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr;

		// Token: 0x04015D8F RID: 89487
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr;

		// Token: 0x04015D90 RID: 89488
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BE8CC028C_NativeFunctionPtr;

		// Token: 0x04015D91 RID: 89489
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D92 RID: 89490
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D93 RID: 89491
		private static IntPtr __ExecuteUbergraph_GA_Motor_Stunt_Fall_NativeFunctionPtr;

		// Token: 0x0200A1F4 RID: 41460
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F51 RID: 208721
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1F5 RID: 41461
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Stunt_Fall_FunctionParams
		{
			// Token: 0x04032F52 RID: 208722
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
