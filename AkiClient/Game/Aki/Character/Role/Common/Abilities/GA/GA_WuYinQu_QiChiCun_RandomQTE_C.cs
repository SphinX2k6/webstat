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
	// Token: 0x020040D5 RID: 16597
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_QiChiCun_RandomQTE.GA_WuYinQu_QiChiCun_RandomQTE_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_WuYinQu_QiChiCun_RandomQTE_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B6A5 RID: 177829 RVA: 0x00A7B5CB File Offset: 0x00A797CB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_QiChiCun_RandomQTE_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_QiChiCun_RandomQTE.GA_WuYinQu_QiChiCun_RandomQTE_C");
			}
			return GA_WuYinQu_QiChiCun_RandomQTE_C._ClassPtr;
		}

		// Token: 0x0602B6A6 RID: 177830 RVA: 0x00A7B5F0 File Offset: 0x00A797F0
		public GA_WuYinQu_QiChiCun_RandomQTE_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_QiChiCun_RandomQTE_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B6A7 RID: 177831 RVA: 0x00A7B618 File Offset: 0x00A79818
		public GA_WuYinQu_QiChiCun_RandomQTE_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_QiChiCun_RandomQTE_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071BB RID: 29115
		// (get) Token: 0x0602B6A8 RID: 177832 RVA: 0x00A7B64C File Offset: 0x00A7984C
		// (set) Token: 0x0602B6A9 RID: 177833 RVA: 0x00A7B685 File Offset: 0x00A79885
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_QiChiCun_RandomQTE_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_QiChiCun_RandomQTE_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071BC RID: 29116
		// (get) Token: 0x0602B6AA RID: 177834 RVA: 0x00A7B6A6 File Offset: 0x00A798A6
		// (set) Token: 0x0602B6AB RID: 177835 RVA: 0x00A7B6B6 File Offset: 0x00A798B6
		public unsafe float 随机左右
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_QiChiCun_RandomQTE_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_QiChiCun_RandomQTE_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071BD RID: 29117
		// (get) Token: 0x0602B6AC RID: 177836 RVA: 0x00A7B6C7 File Offset: 0x00A798C7
		// (set) Token: 0x0602B6AD RID: 177837 RVA: 0x00A7B6D7 File Offset: 0x00A798D7
		public unsafe float 随机上下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_QiChiCun_RandomQTE_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_QiChiCun_RandomQTE_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B6AE RID: 177838 RVA: 0x00A7B6E8 File Offset: 0x00A798E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_QiChiCun_RandomQTE_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B6AF RID: 177839 RVA: 0x00A7B6FC File Offset: 0x00A798FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_QiChiCun_RandomQTE_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B6B0 RID: 177840 RVA: 0x00A7B714 File Offset: 0x00A79914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE(int EntryPoint)
		{
			GA_WuYinQu_QiChiCun_RandomQTE_C.__ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_FunctionParams* ptr = stackalloc GA_WuYinQu_QiChiCun_RandomQTE_C.__ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(GA_WuYinQu_QiChiCun_RandomQTE_C.__ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_QiChiCun_RandomQTE_C.__ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_QiChiCun_RandomQTE_C.__ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B6B1 RID: 177841 RVA: 0x00A7B75E File Offset: 0x00A7995E
		protected GA_WuYinQu_QiChiCun_RandomQTE_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CFF RID: 97535
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_QiChiCun_RandomQTE.GA_WuYinQu_QiChiCun_RandomQTE_C";

		// Token: 0x04017D00 RID: 97536
		private static IntPtr _ClassPtr;

		// Token: 0x04017D01 RID: 97537
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017D02 RID: 97538
		internal new static int __PropertyOffset_0;

		// Token: 0x04017D03 RID: 97539
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017D04 RID: 97540
		internal new static int __PropertyOffset_1;

		// Token: 0x04017D05 RID: 97541
		internal new static int __PropertyOffset_2;

		// Token: 0x04017D06 RID: 97542
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017D07 RID: 97543
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_NativeFunctionPtr;

		// Token: 0x0200A3AC RID: 41900
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_QiChiCun_RandomQTE_FunctionParams
		{
			// Token: 0x04033189 RID: 209289
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
