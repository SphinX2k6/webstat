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
	// Token: 0x02003FEA RID: 16362
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_SupperStunt.GA_Motor_SupperStunt_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class GA_Motor_SupperStunt_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602932A RID: 168746 RVA: 0x00A2464B File Offset: 0x00A2284B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_SupperStunt_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_SupperStunt.GA_Motor_SupperStunt_C");
			}
			return GA_Motor_SupperStunt_C._ClassPtr;
		}

		// Token: 0x0602932B RID: 168747 RVA: 0x00A24670 File Offset: 0x00A22870
		public GA_Motor_SupperStunt_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_SupperStunt_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602932C RID: 168748 RVA: 0x00A24698 File Offset: 0x00A22898
		public GA_Motor_SupperStunt_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_SupperStunt_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700659A RID: 26010
		// (get) Token: 0x0602932D RID: 168749 RVA: 0x00A246CC File Offset: 0x00A228CC
		// (set) Token: 0x0602932E RID: 168750 RVA: 0x00A24705 File Offset: 0x00A22905
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_SupperStunt_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_SupperStunt_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700659B RID: 26011
		// (get) Token: 0x0602932F RID: 168751 RVA: 0x00A24726 File Offset: 0x00A22926
		// (set) Token: 0x06029330 RID: 168752 RVA: 0x00A2473A File Offset: 0x00A2293A
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_SupperStunt_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_SupperStunt_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700659C RID: 26012
		// (get) Token: 0x06029331 RID: 168753 RVA: 0x00A24750 File Offset: 0x00A22950
		// (set) Token: 0x06029332 RID: 168754 RVA: 0x00A24789 File Offset: 0x00A22989
		public FMotorBoostConfig 摩托_喷射与超速配置
		{
			get
			{
				base.FastCheckIsValid();
				FMotorBoostConfig result;
				if ((result = this._摩托_喷射与超速配置) == null)
				{
					result = (this._摩托_喷射与超速配置 = new FMotorBoostConfig(base.NativePtr + (IntPtr)GA_Motor_SupperStunt_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FMotorBoostConfig.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_SupperStunt_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06029333 RID: 168755 RVA: 0x00A247AA File Offset: 0x00A229AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BA965C662()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__OnTick_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr, null);
		}

		// Token: 0x06029334 RID: 168756 RVA: 0x00A247BE File Offset: 0x00A229BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BA965C662()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr, null);
		}

		// Token: 0x06029335 RID: 168757 RVA: 0x00A247D2 File Offset: 0x00A229D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BA965C662()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr, null);
		}

		// Token: 0x06029336 RID: 168758 RVA: 0x00A247E6 File Offset: 0x00A229E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BA965C662()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr, null);
		}

		// Token: 0x06029337 RID: 168759 RVA: 0x00A247FA File Offset: 0x00A229FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BA965C662()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr, null);
		}

		// Token: 0x06029338 RID: 168760 RVA: 0x00A2480E File Offset: 0x00A22A0E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x06029339 RID: 168761 RVA: 0x00A24822 File Offset: 0x00A22A22
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602933A RID: 168762 RVA: 0x00A24838 File Offset: 0x00A22A38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_SupperStunt_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_SupperStunt_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_SupperStunt_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_SupperStunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602933B RID: 168763 RVA: 0x00A24880 File Offset: 0x00A22A80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_SupperStunt_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_SupperStunt_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_SupperStunt_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_SupperStunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602933C RID: 168764 RVA: 0x00A248C8 File Offset: 0x00A22AC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_SupperStunt(int EntryPoint)
		{
			GA_Motor_SupperStunt_C.__ExecuteUbergraph_GA_Motor_SupperStunt_FunctionParams* ptr = stackalloc GA_Motor_SupperStunt_C.__ExecuteUbergraph_GA_Motor_SupperStunt_FunctionParams[(UIntPtr)359] + 15L / (long)sizeof(GA_Motor_SupperStunt_C.__ExecuteUbergraph_GA_Motor_SupperStunt_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_SupperStunt_C.__ExecuteUbergraph_GA_Motor_SupperStunt_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_SupperStunt_C.__ExecuteUbergraph_GA_Motor_SupperStunt_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602933D RID: 168765 RVA: 0x00A24912 File Offset: 0x00A22B12
		protected GA_Motor_SupperStunt_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015DA4 RID: 89508
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_SupperStunt.GA_Motor_SupperStunt_C";

		// Token: 0x04015DA5 RID: 89509
		private static IntPtr _ClassPtr;

		// Token: 0x04015DA6 RID: 89510
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015DA7 RID: 89511
		internal new static int __PropertyOffset_0;

		// Token: 0x04015DA8 RID: 89512
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015DA9 RID: 89513
		internal new static int __PropertyOffset_1;

		// Token: 0x04015DAA RID: 89514
		internal new static int __PropertyOffset_2;

		// Token: 0x04015DAB RID: 89515
		[Nullable(2)]
		private FMotorBoostConfig _摩托_喷射与超速配置;

		// Token: 0x04015DAC RID: 89516
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr;

		// Token: 0x04015DAD RID: 89517
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr;

		// Token: 0x04015DAE RID: 89518
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr;

		// Token: 0x04015DAF RID: 89519
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr;

		// Token: 0x04015DB0 RID: 89520
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BA965C662_NativeFunctionPtr;

		// Token: 0x04015DB1 RID: 89521
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015DB2 RID: 89522
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015DB3 RID: 89523
		private static IntPtr __ExecuteUbergraph_GA_Motor_SupperStunt_NativeFunctionPtr;

		// Token: 0x0200A1F8 RID: 41464
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F55 RID: 208725
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1F9 RID: 41465
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 344)]
		protected ref struct __ExecuteUbergraph_GA_Motor_SupperStunt_FunctionParams
		{
			// Token: 0x04032F56 RID: 208726
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
