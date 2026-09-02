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
	// Token: 0x020040D3 RID: 16595
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi_Environment.GA_WuYinQu_HuangShiGaoDi_Environment_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_WuYinQu_HuangShiGaoDi_Environment_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B685 RID: 177797 RVA: 0x00A7B14F File Offset: 0x00A7934F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_WuYinQu_HuangShiGaoDi_Environment_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi_Environment.GA_WuYinQu_HuangShiGaoDi_Environment_C");
			}
			return GA_WuYinQu_HuangShiGaoDi_Environment_C._ClassPtr;
		}

		// Token: 0x0602B686 RID: 177798 RVA: 0x00A7B174 File Offset: 0x00A79374
		public GA_WuYinQu_HuangShiGaoDi_Environment_C() : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuangShiGaoDi_Environment_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B687 RID: 177799 RVA: 0x00A7B19C File Offset: 0x00A7939C
		[NullableContext(1)]
		public GA_WuYinQu_HuangShiGaoDi_Environment_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_WuYinQu_HuangShiGaoDi_Environment_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071B4 RID: 29108
		// (get) Token: 0x0602B688 RID: 177800 RVA: 0x00A7B1D0 File Offset: 0x00A793D0
		// (set) Token: 0x0602B689 RID: 177801 RVA: 0x00A7B209 File Offset: 0x00A79409
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi_Environment_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi_Environment_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071B5 RID: 29109
		// (get) Token: 0x0602B68A RID: 177802 RVA: 0x00A7B22A File Offset: 0x00A7942A
		// (set) Token: 0x0602B68B RID: 177803 RVA: 0x00A7B23A File Offset: 0x00A7943A
		public unsafe float 随机上下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi_Environment_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi_Environment_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170071B6 RID: 29110
		// (get) Token: 0x0602B68C RID: 177804 RVA: 0x00A7B24B File Offset: 0x00A7944B
		// (set) Token: 0x0602B68D RID: 177805 RVA: 0x00A7B25B File Offset: 0x00A7945B
		public unsafe float 随机左右
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi_Environment_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_WuYinQu_HuangShiGaoDi_Environment_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602B68E RID: 177806 RVA: 0x00A7B26C File Offset: 0x00A7946C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B68F RID: 177807 RVA: 0x00A7B2B4 File Offset: 0x00A794B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B690 RID: 177808 RVA: 0x00A7B2FB File Offset: 0x00A794FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B691 RID: 177809 RVA: 0x00A7B30F File Offset: 0x00A7950F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi_Environment_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B692 RID: 177810 RVA: 0x00A7B324 File Offset: 0x00A79524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment(int EntryPoint)
		{
			GA_WuYinQu_HuangShiGaoDi_Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_FunctionParams* ptr = stackalloc GA_WuYinQu_HuangShiGaoDi_Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_FunctionParams[(UIntPtr)271] + 15L / (long)sizeof(GA_WuYinQu_HuangShiGaoDi_Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_WuYinQu_HuangShiGaoDi_Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_WuYinQu_HuangShiGaoDi_Environment_C.__ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B693 RID: 177811 RVA: 0x00A7B36E File Offset: 0x00A7956E
		protected GA_WuYinQu_HuangShiGaoDi_Environment_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CEA RID: 97514
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_WuYinQu_HuangShiGaoDi_Environment.GA_WuYinQu_HuangShiGaoDi_Environment_C";

		// Token: 0x04017CEB RID: 97515
		private static IntPtr _ClassPtr;

		// Token: 0x04017CEC RID: 97516
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CED RID: 97517
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CEE RID: 97518
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CEF RID: 97519
		internal new static int __PropertyOffset_1;

		// Token: 0x04017CF0 RID: 97520
		internal new static int __PropertyOffset_2;

		// Token: 0x04017CF1 RID: 97521
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017CF2 RID: 97522
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CF3 RID: 97523
		private static IntPtr __ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_NativeFunctionPtr;

		// Token: 0x0200A3A8 RID: 41896
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033185 RID: 209285
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3A9 RID: 41897
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 256)]
		protected ref struct __ExecuteUbergraph_GA_WuYinQu_HuangShiGaoDi_Environment_FunctionParams
		{
			// Token: 0x04033186 RID: 209286
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
