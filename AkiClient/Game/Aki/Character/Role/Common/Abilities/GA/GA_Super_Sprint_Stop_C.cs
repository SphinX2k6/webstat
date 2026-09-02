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
	// Token: 0x020040CC RID: 16588
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Stop.GA_Super_Sprint_Stop_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Super_Sprint_Stop_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B622 RID: 177698 RVA: 0x00A7A357 File Offset: 0x00A78557
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Stop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Stop.GA_Super_Sprint_Stop_C");
			}
			return GA_Super_Sprint_Stop_C._ClassPtr;
		}

		// Token: 0x0602B623 RID: 177699 RVA: 0x00A7A37C File Offset: 0x00A7857C
		public GA_Super_Sprint_Stop_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Stop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B624 RID: 177700 RVA: 0x00A7A3A4 File Offset: 0x00A785A4
		[NullableContext(1)]
		public GA_Super_Sprint_Stop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Stop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071A4 RID: 29092
		// (get) Token: 0x0602B625 RID: 177701 RVA: 0x00A7A3D8 File Offset: 0x00A785D8
		// (set) Token: 0x0602B626 RID: 177702 RVA: 0x00A7A411 File Offset: 0x00A78611
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Stop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Stop_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B627 RID: 177703 RVA: 0x00A7A432 File Offset: 0x00A78632
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81F9A9D532()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__OnTick_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr, null);
		}

		// Token: 0x0602B628 RID: 177704 RVA: 0x00A7A446 File Offset: 0x00A78646
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81F9A9D532()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__OnCancelled_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr, null);
		}

		// Token: 0x0602B629 RID: 177705 RVA: 0x00A7A45A File Offset: 0x00A7865A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81F9A9D532()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__OnInterrupted_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr, null);
		}

		// Token: 0x0602B62A RID: 177706 RVA: 0x00A7A46E File Offset: 0x00A7866E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81F9A9D532()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__OnBlendOut_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr, null);
		}

		// Token: 0x0602B62B RID: 177707 RVA: 0x00A7A482 File Offset: 0x00A78682
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81F9A9D532()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__OnCompleted_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr, null);
		}

		// Token: 0x0602B62C RID: 177708 RVA: 0x00A7A496 File Offset: 0x00A78696
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B62D RID: 177709 RVA: 0x00A7A4AA File Offset: 0x00A786AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B62E RID: 177710 RVA: 0x00A7A4C0 File Offset: 0x00A786C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Stop_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Stop_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Stop_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Stop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B62F RID: 177711 RVA: 0x00A7A508 File Offset: 0x00A78708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Stop_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Stop_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Stop_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Stop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B630 RID: 177712 RVA: 0x00A7A550 File Offset: 0x00A78750
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Stop(int EntryPoint)
		{
			GA_Super_Sprint_Stop_C.__ExecuteUbergraph_GA_Super_Sprint_Stop_FunctionParams* ptr = stackalloc GA_Super_Sprint_Stop_C.__ExecuteUbergraph_GA_Super_Sprint_Stop_FunctionParams[(UIntPtr)767] + 15L / (long)sizeof(GA_Super_Sprint_Stop_C.__ExecuteUbergraph_GA_Super_Sprint_Stop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Stop_C.__ExecuteUbergraph_GA_Super_Sprint_Stop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Stop_C.__ExecuteUbergraph_GA_Super_Sprint_Stop_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B631 RID: 177713 RVA: 0x00A7A59A File Offset: 0x00A7879A
		protected GA_Super_Sprint_Stop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C9F RID: 97439
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Stop.GA_Super_Sprint_Stop_C";

		// Token: 0x04017CA0 RID: 97440
		private static IntPtr _ClassPtr;

		// Token: 0x04017CA1 RID: 97441
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017CA2 RID: 97442
		internal new static int __PropertyOffset_0;

		// Token: 0x04017CA3 RID: 97443
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017CA4 RID: 97444
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr;

		// Token: 0x04017CA5 RID: 97445
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr;

		// Token: 0x04017CA6 RID: 97446
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr;

		// Token: 0x04017CA7 RID: 97447
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr;

		// Token: 0x04017CA8 RID: 97448
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81F9A9D532_NativeFunctionPtr;

		// Token: 0x04017CA9 RID: 97449
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017CAA RID: 97450
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017CAB RID: 97451
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Stop_NativeFunctionPtr;

		// Token: 0x0200A39D RID: 41885
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403317A RID: 209274
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A39E RID: 41886
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 752)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Stop_FunctionParams
		{
			// Token: 0x0403317B RID: 209275
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
