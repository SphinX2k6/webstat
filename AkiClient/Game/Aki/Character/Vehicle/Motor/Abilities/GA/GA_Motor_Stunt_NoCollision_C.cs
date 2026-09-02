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
	// Token: 0x02003FE9 RID: 16361
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_NoCollision.GA_Motor_Stunt_NoCollision_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Stunt_NoCollision_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06029316 RID: 168726 RVA: 0x00A2437B File Offset: 0x00A2257B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Stunt_NoCollision_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_NoCollision.GA_Motor_Stunt_NoCollision_C");
			}
			return GA_Motor_Stunt_NoCollision_C._ClassPtr;
		}

		// Token: 0x06029317 RID: 168727 RVA: 0x00A243A0 File Offset: 0x00A225A0
		public GA_Motor_Stunt_NoCollision_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_NoCollision_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06029318 RID: 168728 RVA: 0x00A243C8 File Offset: 0x00A225C8
		public GA_Motor_Stunt_NoCollision_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_NoCollision_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006597 RID: 26007
		// (get) Token: 0x06029319 RID: 168729 RVA: 0x00A243FC File Offset: 0x00A225FC
		// (set) Token: 0x0602931A RID: 168730 RVA: 0x00A24435 File Offset: 0x00A22635
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Stunt_NoCollision_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_NoCollision_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006598 RID: 26008
		// (get) Token: 0x0602931B RID: 168731 RVA: 0x00A24456 File Offset: 0x00A22656
		// (set) Token: 0x0602931C RID: 168732 RVA: 0x00A2446A File Offset: 0x00A2266A
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_NoCollision_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_NoCollision_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006599 RID: 26009
		// (get) Token: 0x0602931D RID: 168733 RVA: 0x00A24480 File Offset: 0x00A22680
		// (set) Token: 0x0602931E RID: 168734 RVA: 0x00A244B9 File Offset: 0x00A226B9
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_Stunt_NoCollision_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_NoCollision_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602931F RID: 168735 RVA: 0x00A244DA File Offset: 0x00A226DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B4491F765()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__OnTick_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr, null);
		}

		// Token: 0x06029320 RID: 168736 RVA: 0x00A244EE File Offset: 0x00A226EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B4491F765()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr, null);
		}

		// Token: 0x06029321 RID: 168737 RVA: 0x00A24502 File Offset: 0x00A22702
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B4491F765()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr, null);
		}

		// Token: 0x06029322 RID: 168738 RVA: 0x00A24516 File Offset: 0x00A22716
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B4491F765()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr, null);
		}

		// Token: 0x06029323 RID: 168739 RVA: 0x00A2452A File Offset: 0x00A2272A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B4491F765()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr, null);
		}

		// Token: 0x06029324 RID: 168740 RVA: 0x00A2453E File Offset: 0x00A2273E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029325 RID: 168741 RVA: 0x00A24552 File Offset: 0x00A22752
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029326 RID: 168742 RVA: 0x00A24568 File Offset: 0x00A22768
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029327 RID: 168743 RVA: 0x00A245B0 File Offset: 0x00A227B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029328 RID: 168744 RVA: 0x00A245F8 File Offset: 0x00A227F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Stunt_NoCollision(int EntryPoint)
		{
			GA_Motor_Stunt_NoCollision_C.__ExecuteUbergraph_GA_Motor_Stunt_NoCollision_FunctionParams* ptr = stackalloc GA_Motor_Stunt_NoCollision_C.__ExecuteUbergraph_GA_Motor_Stunt_NoCollision_FunctionParams[(UIntPtr)359] + 15L / (long)sizeof(GA_Motor_Stunt_NoCollision_C.__ExecuteUbergraph_GA_Motor_Stunt_NoCollision_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_NoCollision_C.__ExecuteUbergraph_GA_Motor_Stunt_NoCollision_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_NoCollision_C.__ExecuteUbergraph_GA_Motor_Stunt_NoCollision_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029329 RID: 168745 RVA: 0x00A24642 File Offset: 0x00A22842
		protected GA_Motor_Stunt_NoCollision_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D94 RID: 89492
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_NoCollision.GA_Motor_Stunt_NoCollision_C";

		// Token: 0x04015D95 RID: 89493
		private static IntPtr _ClassPtr;

		// Token: 0x04015D96 RID: 89494
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D97 RID: 89495
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D98 RID: 89496
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D99 RID: 89497
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D9A RID: 89498
		internal new static int __PropertyOffset_2;

		// Token: 0x04015D9B RID: 89499
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015D9C RID: 89500
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr;

		// Token: 0x04015D9D RID: 89501
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr;

		// Token: 0x04015D9E RID: 89502
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr;

		// Token: 0x04015D9F RID: 89503
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr;

		// Token: 0x04015DA0 RID: 89504
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B4491F765_NativeFunctionPtr;

		// Token: 0x04015DA1 RID: 89505
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015DA2 RID: 89506
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015DA3 RID: 89507
		private static IntPtr __ExecuteUbergraph_GA_Motor_Stunt_NoCollision_NativeFunctionPtr;

		// Token: 0x0200A1F6 RID: 41462
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F53 RID: 208723
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1F7 RID: 41463
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 344)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Stunt_NoCollision_FunctionParams
		{
			// Token: 0x04032F54 RID: 208724
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
