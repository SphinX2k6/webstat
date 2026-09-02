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
	// Token: 0x020040D8 RID: 16600
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_XA.GA_XA_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1489)]
	public class GA_XA_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B6D2 RID: 177874 RVA: 0x00A7BBE3 File Offset: 0x00A79DE3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_XA_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_XA.GA_XA_C");
			}
			return GA_XA_C._ClassPtr;
		}

		// Token: 0x0602B6D3 RID: 177875 RVA: 0x00A7BC08 File Offset: 0x00A79E08
		public GA_XA_C() : this(BuiltinUtils.AllocNativeUObject(GA_XA_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B6D4 RID: 177876 RVA: 0x00A7BC30 File Offset: 0x00A79E30
		[NullableContext(1)]
		public GA_XA_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_XA_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071C5 RID: 29125
		// (get) Token: 0x0602B6D5 RID: 177877 RVA: 0x00A7BC64 File Offset: 0x00A79E64
		// (set) Token: 0x0602B6D6 RID: 177878 RVA: 0x00A7BC9D File Offset: 0x00A79E9D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_XA_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_XA_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071C6 RID: 29126
		// (get) Token: 0x0602B6D7 RID: 177879 RVA: 0x00A7BCBE File Offset: 0x00A79EBE
		// (set) Token: 0x0602B6D8 RID: 177880 RVA: 0x00A7BCD2 File Offset: 0x00A79ED2
		public unsafe TEnumAsByte<EMovementMode> 运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_XA_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_XA_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602B6D9 RID: 177881 RVA: 0x00A7BCE7 File Offset: 0x00A79EE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_XA_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B6DA RID: 177882 RVA: 0x00A7BCFB File Offset: 0x00A79EFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_XA_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B6DB RID: 177883 RVA: 0x00A7BD10 File Offset: 0x00A79F10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_XA_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_XA_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_XA_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B6DC RID: 177884 RVA: 0x00A7BD58 File Offset: 0x00A79F58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_XA_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_XA_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_XA_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6DD RID: 177885 RVA: 0x00A7BDA0 File Offset: 0x00A79FA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_XA(int EntryPoint)
		{
			GA_XA_C.__ExecuteUbergraph_GA_XA_FunctionParams* ptr = stackalloc GA_XA_C.__ExecuteUbergraph_GA_XA_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(GA_XA_C.__ExecuteUbergraph_GA_XA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_XA_C.__ExecuteUbergraph_GA_XA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_XA_C.__ExecuteUbergraph_GA_XA_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6DE RID: 177886 RVA: 0x00A7BDE7 File Offset: 0x00A79FE7
		protected GA_XA_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017D1D RID: 97565
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_XA.GA_XA_C";

		// Token: 0x04017D1E RID: 97566
		private static IntPtr _ClassPtr;

		// Token: 0x04017D1F RID: 97567
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017D20 RID: 97568
		internal new static int __PropertyOffset_0;

		// Token: 0x04017D21 RID: 97569
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017D22 RID: 97570
		internal new static int __PropertyOffset_1;

		// Token: 0x04017D23 RID: 97571
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017D24 RID: 97572
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017D25 RID: 97573
		private static IntPtr __ExecuteUbergraph_GA_XA_NativeFunctionPtr;

		// Token: 0x0200A3B1 RID: 41905
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403318E RID: 209294
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3B2 RID: 41906
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_GA_XA_FunctionParams
		{
			// Token: 0x0403318F RID: 209295
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
