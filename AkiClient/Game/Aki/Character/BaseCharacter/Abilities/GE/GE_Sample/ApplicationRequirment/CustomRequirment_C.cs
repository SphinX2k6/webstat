using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample.ApplicationRequirment
{
	// Token: 0x02004342 RID: 17218
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/ApplicationRequirment/CustomRequirment.CustomRequirment_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class CustomRequirment_C : UGameplayEffectCustomApplicationRequirement, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA74 RID: 186996 RVA: 0x00AC5D34 File Offset: 0x00AC3F34
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CustomRequirment_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/ApplicationRequirment/CustomRequirment.CustomRequirment_C");
			}
			return CustomRequirment_C._ClassPtr;
		}

		// Token: 0x0602DA75 RID: 186997 RVA: 0x00AC5D58 File Offset: 0x00AC3F58
		public CustomRequirment_C() : this(BuiltinUtils.AllocNativeUObject(CustomRequirment_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA76 RID: 186998 RVA: 0x00AC5D80 File Offset: 0x00AC3F80
		[NullableContext(1)]
		public CustomRequirment_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CustomRequirment_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA77 RID: 186999 RVA: 0x00AC5DB4 File Offset: 0x00AC3FB4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool CanApplyGameplayEffect(UGameplayEffect GameplayEffect, in FGameplayEffectSpec Spec, UAbilitySystemComponent ASC)
		{
			CustomRequirment_C.__CanApplyGameplayEffect_FunctionParams* ptr = stackalloc CustomRequirment_C.__CanApplyGameplayEffect_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(CustomRequirment_C.__CanApplyGameplayEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(CustomRequirment_C.__CanApplyGameplayEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayEffect = ((GameplayEffect != null) ? GameplayEffect.NativePtr : IntPtr.Zero);
			if (Spec != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEffectSpec.StaticStruct(), &ptr->Spec, Spec.NativePtr, 1, false);
			}
			ptr->ASC = ((ASC != null) ? ASC.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, CustomRequirment_C.__CanApplyGameplayEffect_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(CustomRequirment_C.__CanApplyGameplayEffect_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DA78 RID: 187000 RVA: 0x00AC5E60 File Offset: 0x00AC4060
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool CanApplyGameplayEffect_Implementation(UGameplayEffect GameplayEffect, in FGameplayEffectSpec Spec, UAbilitySystemComponent ASC)
		{
			CustomRequirment_C.__CanApplyGameplayEffect_FunctionParams* ptr = stackalloc CustomRequirment_C.__CanApplyGameplayEffect_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(CustomRequirment_C.__CanApplyGameplayEffect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(CustomRequirment_C.__CanApplyGameplayEffect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayEffect = ((GameplayEffect != null) ? GameplayEffect.NativePtr : IntPtr.Zero);
			if (Spec != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEffectSpec.StaticStruct(), &ptr->Spec, Spec.NativePtr, 1, false);
			}
			ptr->ASC = ((ASC != null) ? ASC.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, CustomRequirment_C.__CanApplyGameplayEffect_NativeFunctionPtr, (void*)ptr, 0);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(CustomRequirment_C.__CanApplyGameplayEffect_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602DA79 RID: 187001 RVA: 0x00AC5F0A File Offset: 0x00AC410A
		protected CustomRequirment_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BE1 RID: 105441
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/ApplicationRequirment/CustomRequirment.CustomRequirment_C";

		// Token: 0x04019BE2 RID: 105442
		private static IntPtr _ClassPtr;

		// Token: 0x04019BE3 RID: 105443
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019BE4 RID: 105444
		private static IntPtr __CanApplyGameplayEffect_NativeFunctionPtr;

		// Token: 0x0200A532 RID: 42290
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected new ref struct __CanApplyGameplayEffect_FunctionParams
		{
			// Token: 0x040333EB RID: 209899
			[FieldOffset(0)]
			public IntPtr GameplayEffect;

			// Token: 0x040333EC RID: 209900
			[FieldOffset(8)]
			public byte Spec;

			// Token: 0x040333ED RID: 209901
			[FieldOffset(696)]
			public IntPtr ASC;

			// Token: 0x040333EE RID: 209902
			[FieldOffset(704)]
			public bool __Result;
		}
	}
}
