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
	// Token: 0x020040D2 RID: 16594
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi2__Environment.GA_WuYinQu_HuangShiGaoDi2__Environment_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_WuYinQu_HuangShiGaoDi2__Environment_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B678 RID: 177784 RVA: 0x00A7AFB3 File Offset: 0x00A791B3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_HuangShiGaoDi2__Environment_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi2__Environment.GA_WuYinQu_HuangShiGaoDi2__Environment_C");
			}
			return GA_WuYinQu_HuangShiGaoDi2__Environment_C._ClassPtr;
		}

		// Token: 0x0602B679 RID: 177785 RVA: 0x00A7AFD8 File Offset: 0x00A791D8
		public GA_WuYinQu_HuangShiGaoDi2__Environment_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuangShiGaoDi2__Environment_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B67A RID: 177786 RVA: 0x00A7B000 File Offset: 0x00A79200
		public GA_WuYinQu_HuangShiGaoDi2__Environment_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuangShiGaoDi2__Environment_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071B1 RID: 29105
		// (get) Token: 0x0602B67B RID: 177787 RVA: 0x00A7B034 File Offset: 0x00A79234
		// (set) Token: 0x0602B67C RID: 177788 RVA: 0x00A7B06D File Offset: 0x00A7926D
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2__Environment_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2__Environment_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071B2 RID: 29106
		// (get) Token: 0x0602B67D RID: 177789 RVA: 0x00A7B08E File Offset: 0x00A7928E
		// (set) Token: 0x0602B67E RID: 177790 RVA: 0x00A7B09E File Offset: 0x00A7929E
		public unsafe float 随机上下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2__Environment_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2__Environment_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071B3 RID: 29107
		// (get) Token: 0x0602B67F RID: 177791 RVA: 0x00A7B0AF File Offset: 0x00A792AF
		// (set) Token: 0x0602B680 RID: 177792 RVA: 0x00A7B0BF File Offset: 0x00A792BF
		public unsafe float 随机左右
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2__Environment_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi2__Environment_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B681 RID: 177793 RVA: 0x00A7B0D0 File Offset: 0x00A792D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi2__Environment_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B682 RID: 177794 RVA: 0x00A7B0E4 File Offset: 0x00A792E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi2__Environment_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B683 RID: 177795 RVA: 0x00A7B0FC File Offset: 0x00A792FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment(int EntryPoint)
		{
			GA_WuYinQu_HuangShiGaoDi2__Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_FunctionParams* ptr = stackalloc GA_WuYinQu_HuangShiGaoDi2__Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(GA_WuYinQu_HuangShiGaoDi2__Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuangShiGaoDi2__Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi2__Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B684 RID: 177796 RVA: 0x00A7B146 File Offset: 0x00A79346
		protected GA_WuYinQu_HuangShiGaoDi2__Environment_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CE1 RID: 97505
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi2__Environment.GA_WuYinQu_HuangShiGaoDi2__Environment_C";

		// Token: 0x04017CE2 RID: 97506
		private static IntPtr _ClassPtr;

		// Token: 0x04017CE3 RID: 97507
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CE4 RID: 97508
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CE5 RID: 97509
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CE6 RID: 97510
		internal new static int __PropertyOffset_1;

		// Token: 0x04017CE7 RID: 97511
		internal new static int __PropertyOffset_2;

		// Token: 0x04017CE8 RID: 97512
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CE9 RID: 97513
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_NativeFunctionPtr;

		// Token: 0x0200A3A7 RID: 41895
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi2__Environment_FunctionParams
		{
			// Token: 0x04033184 RID: 209284
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
