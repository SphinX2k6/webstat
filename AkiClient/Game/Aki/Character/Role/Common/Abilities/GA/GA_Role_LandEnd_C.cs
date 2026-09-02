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
	// Token: 0x020040AC RID: 16556
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_LandEnd.GA_Role_LandEnd_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_LandEnd_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B2A8 RID: 176808 RVA: 0x00A725D3 File Offset: 0x00A707D3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_LandEnd_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_LandEnd.GA_Role_LandEnd_C");
			}
			return GA_Role_LandEnd_C._ClassPtr;
		}

		// Token: 0x0602B2A9 RID: 176809 RVA: 0x00A725F8 File Offset: 0x00A707F8
		public GA_Role_LandEnd_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_LandEnd_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B2AA RID: 176810 RVA: 0x00A72620 File Offset: 0x00A70820
		[NullableContext(1)]
		public GA_Role_LandEnd_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_LandEnd_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070FA RID: 28922
		// (get) Token: 0x0602B2AB RID: 176811 RVA: 0x00A72654 File Offset: 0x00A70854
		// (set) Token: 0x0602B2AC RID: 176812 RVA: 0x00A7268D File Offset: 0x00A7088D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_LandEnd_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_LandEnd_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B2AD RID: 176813 RVA: 0x00A726AE File Offset: 0x00A708AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81A71A0E06()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__OnTick_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2AE RID: 176814 RVA: 0x00A726C2 File Offset: 0x00A708C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81A71A0E06()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__OnCancelled_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2AF RID: 176815 RVA: 0x00A726D6 File Offset: 0x00A708D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81A71A0E06()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__OnInterrupted_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2B0 RID: 176816 RVA: 0x00A726EA File Offset: 0x00A708EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81A71A0E06()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__OnBlendOut_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2B1 RID: 176817 RVA: 0x00A726FE File Offset: 0x00A708FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81A71A0E06()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__OnCompleted_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2B2 RID: 176818 RVA: 0x00A72714 File Offset: 0x00A70914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_9E901F22482A6DDEB0D80EA7BE048B55(in FGameplayTag Tag)
		{
			GA_Role_LandEnd_C.__Added_9E901F22482A6DDEB0D80EA7BE048B55_FunctionParams* ptr = stackalloc GA_Role_LandEnd_C.__Added_9E901F22482A6DDEB0D80EA7BE048B55_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_LandEnd_C.__Added_9E901F22482A6DDEB0D80EA7BE048B55_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_C.__Added_9E901F22482A6DDEB0D80EA7BE048B55_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__Added_9E901F22482A6DDEB0D80EA7BE048B55_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2B3 RID: 176819 RVA: 0x00A72760 File Offset: 0x00A70960
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_9B3A4556409D48FAB54BE1AE6B3F1479(in FGameplayTag Tag)
		{
			GA_Role_LandEnd_C.__Added_9B3A4556409D48FAB54BE1AE6B3F1479_FunctionParams* ptr = stackalloc GA_Role_LandEnd_C.__Added_9B3A4556409D48FAB54BE1AE6B3F1479_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_LandEnd_C.__Added_9B3A4556409D48FAB54BE1AE6B3F1479_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_C.__Added_9B3A4556409D48FAB54BE1AE6B3F1479_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__Added_9B3A4556409D48FAB54BE1AE6B3F1479_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2B4 RID: 176820 RVA: 0x00A727AC File Offset: 0x00A709AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_LandEnd_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_LandEnd_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_LandEnd_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2B5 RID: 176821 RVA: 0x00A727F4 File Offset: 0x00A709F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_LandEnd_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_LandEnd_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_LandEnd_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_LandEnd_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2B6 RID: 176822 RVA: 0x00A7283B File Offset: 0x00A70A3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2B7 RID: 176823 RVA: 0x00A7284F File Offset: 0x00A70A4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_LandEnd_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B2B8 RID: 176824 RVA: 0x00A72864 File Offset: 0x00A70A64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_LandEnd(int EntryPoint)
		{
			GA_Role_LandEnd_C.__ExecuteUbergraph_GA_Role_LandEnd_FunctionParams* ptr = stackalloc GA_Role_LandEnd_C.__ExecuteUbergraph_GA_Role_LandEnd_FunctionParams[(UIntPtr)983] + 15L / (long)sizeof(GA_Role_LandEnd_C.__ExecuteUbergraph_GA_Role_LandEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_C.__ExecuteUbergraph_GA_Role_LandEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_LandEnd_C.__ExecuteUbergraph_GA_Role_LandEnd_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2B9 RID: 176825 RVA: 0x00A728AE File Offset: 0x00A70AAE
		protected GA_Role_LandEnd_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A0C RID: 96780
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_LandEnd.GA_Role_LandEnd_C";

		// Token: 0x04017A0D RID: 96781
		private static IntPtr _ClassPtr;

		// Token: 0x04017A0E RID: 96782
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A0F RID: 96783
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A10 RID: 96784
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A11 RID: 96785
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr;

		// Token: 0x04017A12 RID: 96786
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr;

		// Token: 0x04017A13 RID: 96787
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr;

		// Token: 0x04017A14 RID: 96788
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr;

		// Token: 0x04017A15 RID: 96789
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81A71A0E06_NativeFunctionPtr;

		// Token: 0x04017A16 RID: 96790
		private static IntPtr __Added_9E901F22482A6DDEB0D80EA7BE048B55_NativeFunctionPtr;

		// Token: 0x04017A17 RID: 96791
		private static IntPtr __Added_9B3A4556409D48FAB54BE1AE6B3F1479_NativeFunctionPtr;

		// Token: 0x04017A18 RID: 96792
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A19 RID: 96793
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A1A RID: 96794
		private static IntPtr __ExecuteUbergraph_GA_Role_LandEnd_NativeFunctionPtr;

		// Token: 0x0200A307 RID: 41735
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_9E901F22482A6DDEB0D80EA7BE048B55_FunctionParams
		{
			// Token: 0x040330D4 RID: 209108
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A308 RID: 41736
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_9B3A4556409D48FAB54BE1AE6B3F1479_FunctionParams
		{
			// Token: 0x040330D5 RID: 209109
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A309 RID: 41737
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330D6 RID: 209110
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A30A RID: 41738
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 968)]
		protected ref struct __ExecuteUbergraph_GA_Role_LandEnd_FunctionParams
		{
			// Token: 0x040330D7 RID: 209111
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
