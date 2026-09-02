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
	// Token: 0x0200407C RID: 16508
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_AimShoot.GA_Common_AimShoot_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Common_AimShoot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AEA6 RID: 175782 RVA: 0x00A69D23 File Offset: 0x00A67F23
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Common_AimShoot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_AimShoot.GA_Common_AimShoot_C");
			}
			return GA_Common_AimShoot_C._ClassPtr;
		}

		// Token: 0x0602AEA7 RID: 175783 RVA: 0x00A69D48 File Offset: 0x00A67F48
		public GA_Common_AimShoot_C() : this(BuiltinUtils.AllocNativeUObject(GA_Common_AimShoot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AEA8 RID: 175784 RVA: 0x00A69D70 File Offset: 0x00A67F70
		[NullableContext(1)]
		public GA_Common_AimShoot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Common_AimShoot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007031 RID: 28721
		// (get) Token: 0x0602AEA9 RID: 175785 RVA: 0x00A69DA4 File Offset: 0x00A67FA4
		// (set) Token: 0x0602AEAA RID: 175786 RVA: 0x00A69DDD File Offset: 0x00A67FDD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Common_AimShoot_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Common_AimShoot_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007032 RID: 28722
		// (get) Token: 0x0602AEAB RID: 175787 RVA: 0x00A69DFE File Offset: 0x00A67FFE
		// (set) Token: 0x0602AEAC RID: 175788 RVA: 0x00A69E12 File Offset: 0x00A68012
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_AimShoot_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Common_AimShoot_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602AEAD RID: 175789 RVA: 0x00A69E27 File Offset: 0x00A68027
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AimShoot_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AEAE RID: 175790 RVA: 0x00A69E3B File Offset: 0x00A6803B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_AimShoot_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AEAF RID: 175791 RVA: 0x00A69E50 File Offset: 0x00A68050
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Common_AimShoot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Common_AimShoot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Common_AimShoot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Common_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AEB0 RID: 175792 RVA: 0x00A69E98 File Offset: 0x00A68098
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Common_AimShoot_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Common_AimShoot_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Common_AimShoot_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_AimShoot_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEB1 RID: 175793 RVA: 0x00A69EE0 File Offset: 0x00A680E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Common_AimShoot(int EntryPoint)
		{
			GA_Common_AimShoot_C.__ExecuteUbergraph_GA_Common_AimShoot_FunctionParams* ptr = stackalloc GA_Common_AimShoot_C.__ExecuteUbergraph_GA_Common_AimShoot_FunctionParams[(UIntPtr)615] + 15L / (long)sizeof(GA_Common_AimShoot_C.__ExecuteUbergraph_GA_Common_AimShoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Common_AimShoot_C.__ExecuteUbergraph_GA_Common_AimShoot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Common_AimShoot_C.__ExecuteUbergraph_GA_Common_AimShoot_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AEB2 RID: 175794 RVA: 0x00A69F2A File Offset: 0x00A6812A
		protected GA_Common_AimShoot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017717 RID: 96023
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Common_AimShoot.GA_Common_AimShoot_C";

		// Token: 0x04017718 RID: 96024
		private static IntPtr _ClassPtr;

		// Token: 0x04017719 RID: 96025
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401771A RID: 96026
		internal new static int __PropertyOffset_0;

		// Token: 0x0401771B RID: 96027
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401771C RID: 96028
		internal new static int __PropertyOffset_1;

		// Token: 0x0401771D RID: 96029
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401771E RID: 96030
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401771F RID: 96031
		private static IntPtr __ExecuteUbergraph_GA_Common_AimShoot_NativeFunctionPtr;

		// Token: 0x0200A290 RID: 41616
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403303E RID: 208958
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A291 RID: 41617
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 600)]
		protected ref struct __ExecuteUbergraph_GA_Common_AimShoot_FunctionParams
		{
			// Token: 0x0403303F RID: 208959
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
