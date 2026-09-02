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
	// Token: 0x020040D7 RID: 16599
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_YuanNiaoZe.GA_WuYinQu_YuanNiaoZe_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_WuYinQu_YuanNiaoZe_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B6C3 RID: 177859 RVA: 0x00A7B9BB File Offset: 0x00A79BBB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_YuanNiaoZe_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_YuanNiaoZe.GA_WuYinQu_YuanNiaoZe_C");
			}
			return GA_WuYinQu_YuanNiaoZe_C._ClassPtr;
		}

		// Token: 0x0602B6C4 RID: 177860 RVA: 0x00A7B9E0 File Offset: 0x00A79BE0
		public GA_WuYinQu_YuanNiaoZe_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_YuanNiaoZe_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B6C5 RID: 177861 RVA: 0x00A7BA08 File Offset: 0x00A79C08
		[NullableContext(1)]
		public GA_WuYinQu_YuanNiaoZe_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_YuanNiaoZe_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071C2 RID: 29122
		// (get) Token: 0x0602B6C6 RID: 177862 RVA: 0x00A7BA3C File Offset: 0x00A79C3C
		// (set) Token: 0x0602B6C7 RID: 177863 RVA: 0x00A7BA75 File Offset: 0x00A79C75
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_YuanNiaoZe_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_YuanNiaoZe_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071C3 RID: 29123
		// (get) Token: 0x0602B6C8 RID: 177864 RVA: 0x00A7BA96 File Offset: 0x00A79C96
		// (set) Token: 0x0602B6C9 RID: 177865 RVA: 0x00A7BAA6 File Offset: 0x00A79CA6
		public unsafe float 随机上下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_YuanNiaoZe_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_YuanNiaoZe_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071C4 RID: 29124
		// (get) Token: 0x0602B6CA RID: 177866 RVA: 0x00A7BAB7 File Offset: 0x00A79CB7
		// (set) Token: 0x0602B6CB RID: 177867 RVA: 0x00A7BAC7 File Offset: 0x00A79CC7
		public unsafe float 随机左右
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_YuanNiaoZe_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_YuanNiaoZe_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B6CC RID: 177868 RVA: 0x00A7BAD8 File Offset: 0x00A79CD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B6CD RID: 177869 RVA: 0x00A7BB20 File Offset: 0x00A79D20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_YuanNiaoZe_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6CE RID: 177870 RVA: 0x00A7BB67 File Offset: 0x00A79D67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_YuanNiaoZe_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B6CF RID: 177871 RVA: 0x00A7BB7B File Offset: 0x00A79D7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_YuanNiaoZe_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B6D0 RID: 177872 RVA: 0x00A7BB90 File Offset: 0x00A79D90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe(int EntryPoint)
		{
			GA_WuYinQu_YuanNiaoZe_C.__ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_FunctionParams* ptr = stackalloc GA_WuYinQu_YuanNiaoZe_C.__ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(GA_WuYinQu_YuanNiaoZe_C.__ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_YuanNiaoZe_C.__ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_YuanNiaoZe_C.__ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6D1 RID: 177873 RVA: 0x00A7BBDA File Offset: 0x00A79DDA
		protected GA_WuYinQu_YuanNiaoZe_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017D13 RID: 97555
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_YuanNiaoZe.GA_WuYinQu_YuanNiaoZe_C";

		// Token: 0x04017D14 RID: 97556
		private static IntPtr _ClassPtr;

		// Token: 0x04017D15 RID: 97557
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017D16 RID: 97558
		internal new static int __PropertyOffset_0;

		// Token: 0x04017D17 RID: 97559
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017D18 RID: 97560
		internal new static int __PropertyOffset_1;

		// Token: 0x04017D19 RID: 97561
		internal new static int __PropertyOffset_2;

		// Token: 0x04017D1A RID: 97562
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017D1B RID: 97563
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017D1C RID: 97564
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_NativeFunctionPtr;

		// Token: 0x0200A3AF RID: 41903
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403318C RID: 209292
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3B0 RID: 41904
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_YuanNiaoZe_FunctionParams
		{
			// Token: 0x0403318D RID: 209293
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
