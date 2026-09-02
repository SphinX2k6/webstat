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
	// Token: 0x020040D0 RID: 16592
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_VisionControl.GA_VisionControl_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1492)]
	public class GA_VisionControl_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B65E RID: 177758 RVA: 0x00A7AC0B File Offset: 0x00A78E0B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_VisionControl_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_VisionControl.GA_VisionControl_C");
			}
			return GA_VisionControl_C._ClassPtr;
		}

		// Token: 0x0602B65F RID: 177759 RVA: 0x00A7AC30 File Offset: 0x00A78E30
		public GA_VisionControl_C() : this(BuiltinUtils.AllocNativeUObject(GA_VisionControl_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B660 RID: 177760 RVA: 0x00A7AC58 File Offset: 0x00A78E58
		[NullableContext(1)]
		public GA_VisionControl_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_VisionControl_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071AC RID: 29100
		// (get) Token: 0x0602B661 RID: 177761 RVA: 0x00A7AC8C File Offset: 0x00A78E8C
		// (set) Token: 0x0602B662 RID: 177762 RVA: 0x00A7ACC5 File Offset: 0x00A78EC5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_VisionControl_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_VisionControl_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071AD RID: 29101
		// (get) Token: 0x0602B663 RID: 177763 RVA: 0x00A7ACE6 File Offset: 0x00A78EE6
		// (set) Token: 0x0602B664 RID: 177764 RVA: 0x00A7ACF6 File Offset: 0x00A78EF6
		public unsafe int Count
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_VisionControl_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_VisionControl_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602B665 RID: 177765 RVA: 0x00A7AD08 File Offset: 0x00A78F08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_VisionControl_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_VisionControl_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_VisionControl_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_VisionControl_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_VisionControl_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B666 RID: 177766 RVA: 0x00A7AD50 File Offset: 0x00A78F50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_VisionControl_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_VisionControl_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_VisionControl_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_VisionControl_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_VisionControl_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B667 RID: 177767 RVA: 0x00A7AD97 File Offset: 0x00A78F97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_VisionControl_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B668 RID: 177768 RVA: 0x00A7ADAB File Offset: 0x00A78FAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_VisionControl_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B669 RID: 177769 RVA: 0x00A7ADC0 File Offset: 0x00A78FC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_VisionControl(int EntryPoint)
		{
			GA_VisionControl_C.__ExecuteUbergraph_GA_VisionControl_FunctionParams* ptr = stackalloc GA_VisionControl_C.__ExecuteUbergraph_GA_VisionControl_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_VisionControl_C.__ExecuteUbergraph_GA_VisionControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_VisionControl_C.__ExecuteUbergraph_GA_VisionControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_VisionControl_C.__ExecuteUbergraph_GA_VisionControl_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B66A RID: 177770 RVA: 0x00A7AE07 File Offset: 0x00A79007
		protected GA_VisionControl_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017CCF RID: 97487
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_VisionControl.GA_VisionControl_C";

		// Token: 0x04017CD0 RID: 97488
		private static IntPtr _ClassPtr;

		// Token: 0x04017CD1 RID: 97489
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CD2 RID: 97490
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CD3 RID: 97491
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CD4 RID: 97492
		internal new static int __PropertyOffset_1;

		// Token: 0x04017CD5 RID: 97493
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017CD6 RID: 97494
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CD7 RID: 97495
		private static IntPtr __ExecuteUbergraph_GA_VisionControl_NativeFunctionPtr;

		// Token: 0x0200A3A4 RID: 41892
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033181 RID: 209281
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A3A5 RID: 41893
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_VisionControl_FunctionParams
		{
			// Token: 0x04033182 RID: 209282
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
