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
	// Token: 0x02004076 RID: 16502
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Bounce_XA.GA_Bounce_XA_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1489)]
	public class GA_Bounce_XA_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AE21 RID: 175649 RVA: 0x00A687F3 File Offset: 0x00A669F3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Bounce_XA_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Bounce_XA.GA_Bounce_XA_C");
			}
			return GA_Bounce_XA_C._ClassPtr;
		}

		// Token: 0x0602AE22 RID: 175650 RVA: 0x00A68818 File Offset: 0x00A66A18
		public GA_Bounce_XA_C() : this(BuiltinUtils.AllocNativeUObject(GA_Bounce_XA_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AE23 RID: 175651 RVA: 0x00A68840 File Offset: 0x00A66A40
		[NullableContext(1)]
		public GA_Bounce_XA_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Bounce_XA_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007018 RID: 28696
		// (get) Token: 0x0602AE24 RID: 175652 RVA: 0x00A68874 File Offset: 0x00A66A74
		// (set) Token: 0x0602AE25 RID: 175653 RVA: 0x00A688AD File Offset: 0x00A66AAD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Bounce_XA_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Bounce_XA_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007019 RID: 28697
		// (get) Token: 0x0602AE26 RID: 175654 RVA: 0x00A688CE File Offset: 0x00A66ACE
		// (set) Token: 0x0602AE27 RID: 175655 RVA: 0x00A688E2 File Offset: 0x00A66AE2
		public unsafe TEnumAsByte<EMovementMode> 运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Bounce_XA_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Bounce_XA_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602AE28 RID: 175656 RVA: 0x00A688F7 File Offset: 0x00A66AF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E818422C823()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__OnTick_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE29 RID: 175657 RVA: 0x00A6890B File Offset: 0x00A66B0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E818422C823()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__OnCancelled_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE2A RID: 175658 RVA: 0x00A6891F File Offset: 0x00A66B1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E818422C823()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__OnInterrupted_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE2B RID: 175659 RVA: 0x00A68933 File Offset: 0x00A66B33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E818422C823()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__OnBlendOut_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE2C RID: 175660 RVA: 0x00A68947 File Offset: 0x00A66B47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E818422C823()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__OnCompleted_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE2D RID: 175661 RVA: 0x00A6895B File Offset: 0x00A66B5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AE2E RID: 175662 RVA: 0x00A6896F File Offset: 0x00A66B6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Bounce_XA_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AE2F RID: 175663 RVA: 0x00A68984 File Offset: 0x00A66B84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Bounce_XA_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Bounce_XA_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Bounce_XA_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Bounce_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Bounce_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AE30 RID: 175664 RVA: 0x00A689CC File Offset: 0x00A66BCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Bounce_XA_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Bounce_XA_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Bounce_XA_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Bounce_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Bounce_XA_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE31 RID: 175665 RVA: 0x00A68A14 File Offset: 0x00A66C14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Bounce_XA(int EntryPoint)
		{
			GA_Bounce_XA_C.__ExecuteUbergraph_GA_Bounce_XA_FunctionParams* ptr = stackalloc GA_Bounce_XA_C.__ExecuteUbergraph_GA_Bounce_XA_FunctionParams[(UIntPtr)855] + 15L / (long)sizeof(GA_Bounce_XA_C.__ExecuteUbergraph_GA_Bounce_XA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Bounce_XA_C.__ExecuteUbergraph_GA_Bounce_XA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Bounce_XA_C.__ExecuteUbergraph_GA_Bounce_XA_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AE32 RID: 175666 RVA: 0x00A68A5E File Offset: 0x00A66C5E
		protected GA_Bounce_XA_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040176B4 RID: 95924
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Bounce_XA.GA_Bounce_XA_C";

		// Token: 0x040176B5 RID: 95925
		private static IntPtr _ClassPtr;

		// Token: 0x040176B6 RID: 95926
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040176B7 RID: 95927
		internal new static int __PropertyOffset_0;

		// Token: 0x040176B8 RID: 95928
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040176B9 RID: 95929
		internal new static int __PropertyOffset_1;

		// Token: 0x040176BA RID: 95930
		private static IntPtr __OnTick_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr;

		// Token: 0x040176BB RID: 95931
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr;

		// Token: 0x040176BC RID: 95932
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr;

		// Token: 0x040176BD RID: 95933
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr;

		// Token: 0x040176BE RID: 95934
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E818422C823_NativeFunctionPtr;

		// Token: 0x040176BF RID: 95935
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040176C0 RID: 95936
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040176C1 RID: 95937
		private static IntPtr __ExecuteUbergraph_GA_Bounce_XA_NativeFunctionPtr;

		// Token: 0x0200A272 RID: 41586
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033020 RID: 208928
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A273 RID: 41587
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 840)]
		protected ref struct __ExecuteUbergraph_GA_Bounce_XA_FunctionParams
		{
			// Token: 0x04033021 RID: 208929
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
