using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x0200407B RID: 16507
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimShoot.GA_CommonMaleXL_AimShoot_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_CommonMaleXL_AimShoot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE99 RID: 175769 RVA: 0x00A69B13 File Offset: 0x00A67D13
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_CommonMaleXL_AimShoot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimShoot.GA_CommonMaleXL_AimShoot_C");
			}
			return GA_CommonMaleXL_AimShoot_C._ClassPtr;
		}

		// Token: 0x0602AE9A RID: 175770 RVA: 0x00A69B38 File Offset: 0x00A67D38
		public GA_CommonMaleXL_AimShoot_C() : this(BuiltinUtils.AllocNativeUObject(GA_CommonMaleXL_AimShoot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE9B RID: 175771 RVA: 0x00A69B60 File Offset: 0x00A67D60
		[NullableContext(1)]
		public GA_CommonMaleXL_AimShoot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_CommonMaleXL_AimShoot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700702F RID: 28719
		// (get) Token: 0x0602AE9C RID: 175772 RVA: 0x00A69B94 File Offset: 0x00A67D94
		// (set) Token: 0x0602AE9D RID: 175773 RVA: 0x00A69BCD File Offset: 0x00A67DCD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_CommonMaleXL_AimShoot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_CommonMaleXL_AimShoot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007030 RID: 28720
		// (get) Token: 0x0602AE9E RID: 175774 RVA: 0x00A69BEE File Offset: 0x00A67DEE
		// (set) Token: 0x0602AE9F RID: 175775 RVA: 0x00A69C02 File Offset: 0x00A67E02
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_CommonMaleXL_AimShoot_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_CommonMaleXL_AimShoot_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602AEA0 RID: 175776 RVA: 0x00A69C17 File Offset: 0x00A67E17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimShoot_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEA1 RID: 175777 RVA: 0x00A69C2B File Offset: 0x00A67E2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimShoot_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AEA2 RID: 175778 RVA: 0x00A69C40 File Offset: 0x00A67E40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AEA3 RID: 175779 RVA: 0x00A69C88 File Offset: 0x00A67E88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEA4 RID: 175780 RVA: 0x00A69CD0 File Offset: 0x00A67ED0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_CommonMaleXL_AimShoot(int EntryPoint)
		{
			GA_CommonMaleXL_AimShoot_C.__ExecuteUbergraph_GA_CommonMaleXL_AimShoot_FunctionParams* ptr = stackalloc GA_CommonMaleXL_AimShoot_C.__ExecuteUbergraph_GA_CommonMaleXL_AimShoot_FunctionParams[(UIntPtr)615] + 15L / (long)sizeof(GA_CommonMaleXL_AimShoot_C.__ExecuteUbergraph_GA_CommonMaleXL_AimShoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_CommonMaleXL_AimShoot_C.__ExecuteUbergraph_GA_CommonMaleXL_AimShoot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_CommonMaleXL_AimShoot_C.__ExecuteUbergraph_GA_CommonMaleXL_AimShoot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEA5 RID: 175781 RVA: 0x00A69D1A File Offset: 0x00A67F1A
		protected GA_CommonMaleXL_AimShoot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401770E RID: 96014
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_CommonMaleXL_AimShoot.GA_CommonMaleXL_AimShoot_C";

		// Token: 0x0401770F RID: 96015
		private static IntPtr _ClassPtr;

		// Token: 0x04017710 RID: 96016
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017711 RID: 96017
		internal new static int __PropertyOffset_0;

		// Token: 0x04017712 RID: 96018
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017713 RID: 96019
		internal new static int __PropertyOffset_1;

		// Token: 0x04017714 RID: 96020
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017715 RID: 96021
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017716 RID: 96022
		private static IntPtr __ExecuteUbergraph_GA_CommonMaleXL_AimShoot_NativeFunctionPtr;

		// Token: 0x0200A28E RID: 41614
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403303C RID: 208956
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A28F RID: 41615
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 600)]
		protected ref struct __ExecuteUbergraph_GA_CommonMaleXL_AimShoot_FunctionParams
		{
			// Token: 0x0403303D RID: 208957
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
