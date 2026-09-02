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
	// Token: 0x020040D4 RID: 16596
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuKouSanMai_Ball.GA_WuYinQu_HuKouSanMai_Ball_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_WuYinQu_HuKouSanMai_Ball_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B694 RID: 177812 RVA: 0x00A7B377 File Offset: 0x00A79577
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_HuKouSanMai_Ball_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuKouSanMai_Ball.GA_WuYinQu_HuKouSanMai_Ball_C");
			}
			return GA_WuYinQu_HuKouSanMai_Ball_C._ClassPtr;
		}

		// Token: 0x0602B695 RID: 177813 RVA: 0x00A7B39C File Offset: 0x00A7959C
		public GA_WuYinQu_HuKouSanMai_Ball_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuKouSanMai_Ball_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B696 RID: 177814 RVA: 0x00A7B3C4 File Offset: 0x00A795C4
		public GA_WuYinQu_HuKouSanMai_Ball_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuKouSanMai_Ball_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071B7 RID: 29111
		// (get) Token: 0x0602B697 RID: 177815 RVA: 0x00A7B3F8 File Offset: 0x00A795F8
		// (set) Token: 0x0602B698 RID: 177816 RVA: 0x00A7B431 File Offset: 0x00A79631
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071B8 RID: 29112
		// (get) Token: 0x0602B699 RID: 177817 RVA: 0x00A7B452 File Offset: 0x00A79652
		// (set) Token: 0x0602B69A RID: 177818 RVA: 0x00A7B462 File Offset: 0x00A79662
		public unsafe float 随机上下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071B9 RID: 29113
		// (get) Token: 0x0602B69B RID: 177819 RVA: 0x00A7B473 File Offset: 0x00A79673
		// (set) Token: 0x0602B69C RID: 177820 RVA: 0x00A7B483 File Offset: 0x00A79683
		public unsafe float 随机左右
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170071BA RID: 29114
		// (get) Token: 0x0602B69D RID: 177821 RVA: 0x00A7B494 File Offset: 0x00A79694
		// (set) Token: 0x0602B69E RID: 177822 RVA: 0x00A7B4A8 File Offset: 0x00A796A8
		public unsafe string 子弹_ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GA_WuYinQu_HuKouSanMai_Ball_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x0602B69F RID: 177823 RVA: 0x00A7B4C0 File Offset: 0x00A796C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B6A0 RID: 177824 RVA: 0x00A7B508 File Offset: 0x00A79708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuKouSanMai_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6A1 RID: 177825 RVA: 0x00A7B54F File Offset: 0x00A7974F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_HuKouSanMai_Ball_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B6A2 RID: 177826 RVA: 0x00A7B563 File Offset: 0x00A79763
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuKouSanMai_Ball_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B6A3 RID: 177827 RVA: 0x00A7B578 File Offset: 0x00A79778
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball(int EntryPoint)
		{
			GA_WuYinQu_HuKouSanMai_Ball_C.__ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_FunctionParams* ptr = stackalloc GA_WuYinQu_HuKouSanMai_Ball_C.__ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(GA_WuYinQu_HuKouSanMai_Ball_C.__ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuKouSanMai_Ball_C.__ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuKouSanMai_Ball_C.__ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6A4 RID: 177828 RVA: 0x00A7B5C2 File Offset: 0x00A797C2
		protected GA_WuYinQu_HuKouSanMai_Ball_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CF4 RID: 97524
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuKouSanMai_Ball.GA_WuYinQu_HuKouSanMai_Ball_C";

		// Token: 0x04017CF5 RID: 97525
		private static IntPtr _ClassPtr;

		// Token: 0x04017CF6 RID: 97526
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CF7 RID: 97527
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CF8 RID: 97528
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CF9 RID: 97529
		internal new static int __PropertyOffset_1;

		// Token: 0x04017CFA RID: 97530
		internal new static int __PropertyOffset_2;

		// Token: 0x04017CFB RID: 97531
		internal new static int __PropertyOffset_3;

		// Token: 0x04017CFC RID: 97532
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017CFD RID: 97533
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CFE RID: 97534
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_NativeFunctionPtr;

		// Token: 0x0200A3AA RID: 41898
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033187 RID: 209287
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3AB RID: 41899
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_HuKouSanMai_Ball_FunctionParams
		{
			// Token: 0x04033188 RID: 209288
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
