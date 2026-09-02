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
	// Token: 0x020040D6 RID: 16598
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_YiLuoYuanXiang_Ball.GA_WuYinQu_YiLuoYuanXiang_Ball_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_WuYinQu_YiLuoYuanXiang_Ball_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B6B2 RID: 177842 RVA: 0x00A7B767 File Offset: 0x00A79967
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_YiLuoYuanXiang_Ball_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_YiLuoYuanXiang_Ball.GA_WuYinQu_YiLuoYuanXiang_Ball_C");
			}
			return GA_WuYinQu_YiLuoYuanXiang_Ball_C._ClassPtr;
		}

		// Token: 0x0602B6B3 RID: 177843 RVA: 0x00A7B78C File Offset: 0x00A7998C
		public GA_WuYinQu_YiLuoYuanXiang_Ball_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_YiLuoYuanXiang_Ball_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B6B4 RID: 177844 RVA: 0x00A7B7B4 File Offset: 0x00A799B4
		public GA_WuYinQu_YiLuoYuanXiang_Ball_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_YiLuoYuanXiang_Ball_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071BE RID: 29118
		// (get) Token: 0x0602B6B5 RID: 177845 RVA: 0x00A7B7E8 File Offset: 0x00A799E8
		// (set) Token: 0x0602B6B6 RID: 177846 RVA: 0x00A7B821 File Offset: 0x00A79A21
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071BF RID: 29119
		// (get) Token: 0x0602B6B7 RID: 177847 RVA: 0x00A7B842 File Offset: 0x00A79A42
		// (set) Token: 0x0602B6B8 RID: 177848 RVA: 0x00A7B852 File Offset: 0x00A79A52
		public unsafe float 随机上下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071C0 RID: 29120
		// (get) Token: 0x0602B6B9 RID: 177849 RVA: 0x00A7B863 File Offset: 0x00A79A63
		// (set) Token: 0x0602B6BA RID: 177850 RVA: 0x00A7B873 File Offset: 0x00A79A73
		public unsafe float 随机左右
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170071C1 RID: 29121
		// (get) Token: 0x0602B6BB RID: 177851 RVA: 0x00A7B884 File Offset: 0x00A79A84
		// (set) Token: 0x0602B6BC RID: 177852 RVA: 0x00A7B898 File Offset: 0x00A79A98
		public unsafe string 子弹_ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GA_WuYinQu_YiLuoYuanXiang_Ball_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x0602B6BD RID: 177853 RVA: 0x00A7B8B0 File Offset: 0x00A79AB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B6BE RID: 177854 RVA: 0x00A7B8F8 File Offset: 0x00A79AF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6BF RID: 177855 RVA: 0x00A7B93F File Offset: 0x00A79B3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B6C0 RID: 177856 RVA: 0x00A7B953 File Offset: 0x00A79B53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_YiLuoYuanXiang_Ball_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B6C1 RID: 177857 RVA: 0x00A7B968 File Offset: 0x00A79B68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball(int EntryPoint)
		{
			GA_WuYinQu_YiLuoYuanXiang_Ball_C.__ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_FunctionParams* ptr = stackalloc GA_WuYinQu_YiLuoYuanXiang_Ball_C.__ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_FunctionParams[(UIntPtr)399] + 15L / (long)sizeof(GA_WuYinQu_YiLuoYuanXiang_Ball_C.__ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_YiLuoYuanXiang_Ball_C.__ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_YiLuoYuanXiang_Ball_C.__ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6C2 RID: 177858 RVA: 0x00A7B9B2 File Offset: 0x00A79BB2
		protected GA_WuYinQu_YiLuoYuanXiang_Ball_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017D08 RID: 97544
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_YiLuoYuanXiang_Ball.GA_WuYinQu_YiLuoYuanXiang_Ball_C";

		// Token: 0x04017D09 RID: 97545
		private static IntPtr _ClassPtr;

		// Token: 0x04017D0A RID: 97546
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017D0B RID: 97547
		internal new static int __PropertyOffset_0;

		// Token: 0x04017D0C RID: 97548
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017D0D RID: 97549
		internal new static int __PropertyOffset_1;

		// Token: 0x04017D0E RID: 97550
		internal new static int __PropertyOffset_2;

		// Token: 0x04017D0F RID: 97551
		internal new static int __PropertyOffset_3;

		// Token: 0x04017D10 RID: 97552
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017D11 RID: 97553
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017D12 RID: 97554
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_NativeFunctionPtr;

		// Token: 0x0200A3AD RID: 41901
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403318A RID: 209290
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3AE RID: 41902
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 384)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_YiLuoYuanXiang_Ball_FunctionParams
		{
			// Token: 0x0403318B RID: 209291
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
