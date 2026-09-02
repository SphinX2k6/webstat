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
	// Token: 0x02003FE7 RID: 16359
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_End.GA_Motor_Stunt_End_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_Stunt_End_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060292EE RID: 168686 RVA: 0x00A23DDB File Offset: 0x00A21FDB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Stunt_End_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_End.GA_Motor_Stunt_End_C");
			}
			return GA_Motor_Stunt_End_C._ClassPtr;
		}

		// Token: 0x060292EF RID: 168687 RVA: 0x00A23E00 File Offset: 0x00A22000
		public GA_Motor_Stunt_End_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_End_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060292F0 RID: 168688 RVA: 0x00A23E28 File Offset: 0x00A22028
		public GA_Motor_Stunt_End_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Stunt_End_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006591 RID: 26001
		// (get) Token: 0x060292F1 RID: 168689 RVA: 0x00A23E5C File Offset: 0x00A2205C
		// (set) Token: 0x060292F2 RID: 168690 RVA: 0x00A23E95 File Offset: 0x00A22095
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Stunt_End_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_End_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006592 RID: 26002
		// (get) Token: 0x060292F3 RID: 168691 RVA: 0x00A23EB6 File Offset: 0x00A220B6
		// (set) Token: 0x060292F4 RID: 168692 RVA: 0x00A23ECA File Offset: 0x00A220CA
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_End_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Stunt_End_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006593 RID: 26003
		// (get) Token: 0x060292F5 RID: 168693 RVA: 0x00A23EE0 File Offset: 0x00A220E0
		// (set) Token: 0x060292F6 RID: 168694 RVA: 0x00A23F19 File Offset: 0x00A22119
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_Stunt_End_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Stunt_End_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060292F7 RID: 168695 RVA: 0x00A23F3A File Offset: 0x00A2213A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B8C82EA3B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__OnTick_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr, null);
		}

		// Token: 0x060292F8 RID: 168696 RVA: 0x00A23F4E File Offset: 0x00A2214E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B8C82EA3B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr, null);
		}

		// Token: 0x060292F9 RID: 168697 RVA: 0x00A23F62 File Offset: 0x00A22162
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B8C82EA3B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr, null);
		}

		// Token: 0x060292FA RID: 168698 RVA: 0x00A23F76 File Offset: 0x00A22176
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B8C82EA3B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr, null);
		}

		// Token: 0x060292FB RID: 168699 RVA: 0x00A23F8A File Offset: 0x00A2218A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B8C82EA3B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr, null);
		}

		// Token: 0x060292FC RID: 168700 RVA: 0x00A23F9E File Offset: 0x00A2219E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060292FD RID: 168701 RVA: 0x00A23FB2 File Offset: 0x00A221B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060292FE RID: 168702 RVA: 0x00A23FC8 File Offset: 0x00A221C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Stunt_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060292FF RID: 168703 RVA: 0x00A24010 File Offset: 0x00A22210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Stunt_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Stunt_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Stunt_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029300 RID: 168704 RVA: 0x00A24058 File Offset: 0x00A22258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Stunt_End(int EntryPoint)
		{
			GA_Motor_Stunt_End_C.__ExecuteUbergraph_GA_Motor_Stunt_End_FunctionParams* ptr = stackalloc GA_Motor_Stunt_End_C.__ExecuteUbergraph_GA_Motor_Stunt_End_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(GA_Motor_Stunt_End_C.__ExecuteUbergraph_GA_Motor_Stunt_End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Stunt_End_C.__ExecuteUbergraph_GA_Motor_Stunt_End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Stunt_End_C.__ExecuteUbergraph_GA_Motor_Stunt_End_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029301 RID: 168705 RVA: 0x00A240A2 File Offset: 0x00A222A2
		protected GA_Motor_Stunt_End_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015D74 RID: 89460
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Stunt_End.GA_Motor_Stunt_End_C";

		// Token: 0x04015D75 RID: 89461
		private static IntPtr _ClassPtr;

		// Token: 0x04015D76 RID: 89462
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015D77 RID: 89463
		internal new static int __PropertyOffset_0;

		// Token: 0x04015D78 RID: 89464
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015D79 RID: 89465
		internal new static int __PropertyOffset_1;

		// Token: 0x04015D7A RID: 89466
		internal new static int __PropertyOffset_2;

		// Token: 0x04015D7B RID: 89467
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015D7C RID: 89468
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr;

		// Token: 0x04015D7D RID: 89469
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr;

		// Token: 0x04015D7E RID: 89470
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr;

		// Token: 0x04015D7F RID: 89471
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr;

		// Token: 0x04015D80 RID: 89472
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B8C82EA3B_NativeFunctionPtr;

		// Token: 0x04015D81 RID: 89473
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015D82 RID: 89474
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015D83 RID: 89475
		private static IntPtr __ExecuteUbergraph_GA_Motor_Stunt_End_NativeFunctionPtr;

		// Token: 0x0200A1F2 RID: 41458
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F4F RID: 208719
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1F3 RID: 41459
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Stunt_End_FunctionParams
		{
			// Token: 0x04032F50 RID: 208720
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
