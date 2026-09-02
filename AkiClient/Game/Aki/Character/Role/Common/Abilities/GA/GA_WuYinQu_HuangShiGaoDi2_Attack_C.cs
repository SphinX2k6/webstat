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
	// Token: 0x020040D1 RID: 16593
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi2_Attack.GA_WuYinQu_HuangShiGaoDi2_Attack_C")]
	[UnrealStructLayout(1512, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1512)]
	public class GA_WuYinQu_HuangShiGaoDi2_Attack_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B66B RID: 177771 RVA: 0x00A7AE10 File Offset: 0x00A79010
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_HuangShiGaoDi2_Attack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi2_Attack.GA_WuYinQu_HuangShiGaoDi2_Attack_C");
			}
			return GA_WuYinQu_HuangShiGaoDi2_Attack_C._ClassPtr;
		}

		// Token: 0x0602B66C RID: 177772 RVA: 0x00A7AE34 File Offset: 0x00A79034
		public GA_WuYinQu_HuangShiGaoDi2_Attack_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuangShiGaoDi2_Attack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B66D RID: 177773 RVA: 0x00A7AE5C File Offset: 0x00A7905C
		public GA_WuYinQu_HuangShiGaoDi2_Attack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuangShiGaoDi2_Attack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071AE RID: 29102
		// (get) Token: 0x0602B66E RID: 177774 RVA: 0x00A7AE90 File Offset: 0x00A79090
		// (set) Token: 0x0602B66F RID: 177775 RVA: 0x00A7AEC9 File Offset: 0x00A790C9
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2_Attack_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2_Attack_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071AF RID: 29103
		// (get) Token: 0x0602B670 RID: 177776 RVA: 0x00A7AEEA File Offset: 0x00A790EA
		// (set) Token: 0x0602B671 RID: 177777 RVA: 0x00A7AEFA File Offset: 0x00A790FA
		public unsafe int 落雷次数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2_Attack_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2_Attack_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071B0 RID: 29104
		// (get) Token: 0x0602B672 RID: 177778 RVA: 0x00A7AF0B File Offset: 0x00A7910B
		// (set) Token: 0x0602B673 RID: 177779 RVA: 0x00A7AF1F File Offset: 0x00A7911F
		public unsafe string 子弹_ID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GA_WuYinQu_HuangShiGaoDi2_Attack_C.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GA_WuYinQu_HuangShiGaoDi2_Attack_C.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x0602B674 RID: 177780 RVA: 0x00A7AF34 File Offset: 0x00A79134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi2_Attack_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B675 RID: 177781 RVA: 0x00A7AF48 File Offset: 0x00A79148
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi2_Attack_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B676 RID: 177782 RVA: 0x00A7AF60 File Offset: 0x00A79160
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack(int EntryPoint)
		{
			GA_WuYinQu_HuangShiGaoDi2_Attack_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_FunctionParams* ptr = stackalloc GA_WuYinQu_HuangShiGaoDi2_Attack_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(GA_WuYinQu_HuangShiGaoDi2_Attack_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuangShiGaoDi2_Attack_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi2_Attack_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B677 RID: 177783 RVA: 0x00A7AFAA File Offset: 0x00A791AA
		protected GA_WuYinQu_HuangShiGaoDi2_Attack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CD8 RID: 97496
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi2_Attack.GA_WuYinQu_HuangShiGaoDi2_Attack_C";

		// Token: 0x04017CD9 RID: 97497
		private static IntPtr _ClassPtr;

		// Token: 0x04017CDA RID: 97498
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CDB RID: 97499
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CDC RID: 97500
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CDD RID: 97501
		internal new static int __PropertyOffset_1;

		// Token: 0x04017CDE RID: 97502
		internal new static int __PropertyOffset_2;

		// Token: 0x04017CDF RID: 97503
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CE0 RID: 97504
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_NativeFunctionPtr;

		// Token: 0x0200A3A6 RID: 41894
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2_Attack_FunctionParams
		{
			// Token: 0x04033183 RID: 209283
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
