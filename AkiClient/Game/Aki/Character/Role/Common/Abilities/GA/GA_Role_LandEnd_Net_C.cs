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
	// Token: 0x020040AD RID: 16557
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_LandEnd_Net.GA_Role_LandEnd_Net_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_LandEnd_Net_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B2BA RID: 176826 RVA: 0x00A728B7 File Offset: 0x00A70AB7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_LandEnd_Net_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_LandEnd_Net.GA_Role_LandEnd_Net_C");
			}
			return GA_Role_LandEnd_Net_C._ClassPtr;
		}

		// Token: 0x0602B2BB RID: 176827 RVA: 0x00A728DC File Offset: 0x00A70ADC
		public GA_Role_LandEnd_Net_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_LandEnd_Net_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B2BC RID: 176828 RVA: 0x00A72904 File Offset: 0x00A70B04
		[NullableContext(1)]
		public GA_Role_LandEnd_Net_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_LandEnd_Net_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070FB RID: 28923
		// (get) Token: 0x0602B2BD RID: 176829 RVA: 0x00A72938 File Offset: 0x00A70B38
		// (set) Token: 0x0602B2BE RID: 176830 RVA: 0x00A72971 File Offset: 0x00A70B71
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_LandEnd_Net_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_LandEnd_Net_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B2BF RID: 176831 RVA: 0x00A72992 File Offset: 0x00A70B92
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8120D6F4B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__OnTick_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2C0 RID: 176832 RVA: 0x00A729A6 File Offset: 0x00A70BA6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8120D6F4B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__OnCancelled_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2C1 RID: 176833 RVA: 0x00A729BA File Offset: 0x00A70BBA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8120D6F4B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__OnInterrupted_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2C2 RID: 176834 RVA: 0x00A729CE File Offset: 0x00A70BCE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8120D6F4B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__OnBlendOut_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2C3 RID: 176835 RVA: 0x00A729E2 File Offset: 0x00A70BE2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8120D6F4B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__OnCompleted_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2C4 RID: 176836 RVA: 0x00A729F8 File Offset: 0x00A70BF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_B7E505E3445443CA4C27F38B7FAAFD98(in FGameplayTag Tag)
		{
			GA_Role_LandEnd_Net_C.__Added_B7E505E3445443CA4C27F38B7FAAFD98_FunctionParams* ptr = stackalloc GA_Role_LandEnd_Net_C.__Added_B7E505E3445443CA4C27F38B7FAAFD98_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_LandEnd_Net_C.__Added_B7E505E3445443CA4C27F38B7FAAFD98_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_Net_C.__Added_B7E505E3445443CA4C27F38B7FAAFD98_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__Added_B7E505E3445443CA4C27F38B7FAAFD98_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2C5 RID: 176837 RVA: 0x00A72A44 File Offset: 0x00A70C44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_CF97F8BF4298CF4D3C76EB9D81A391D8(in FGameplayTag Tag)
		{
			GA_Role_LandEnd_Net_C.__Added_CF97F8BF4298CF4D3C76EB9D81A391D8_FunctionParams* ptr = stackalloc GA_Role_LandEnd_Net_C.__Added_CF97F8BF4298CF4D3C76EB9D81A391D8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_LandEnd_Net_C.__Added_CF97F8BF4298CF4D3C76EB9D81A391D8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_Net_C.__Added_CF97F8BF4298CF4D3C76EB9D81A391D8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__Added_CF97F8BF4298CF4D3C76EB9D81A391D8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2C6 RID: 176838 RVA: 0x00A72A8F File Offset: 0x00A70C8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_60C8757C4F274DFA6A15BFB2BBC51946()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__OnFinish_60C8757C4F274DFA6A15BFB2BBC51946_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2C7 RID: 176839 RVA: 0x00A72AA4 File Offset: 0x00A70CA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_LandEnd_Net_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_LandEnd_Net_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_LandEnd_Net_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2C8 RID: 176840 RVA: 0x00A72AEC File Offset: 0x00A70CEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_LandEnd_Net_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_LandEnd_Net_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_LandEnd_Net_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2C9 RID: 176841 RVA: 0x00A72B33 File Offset: 0x00A70D33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2CA RID: 176842 RVA: 0x00A72B47 File Offset: 0x00A70D47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B2CB RID: 176843 RVA: 0x00A72B5C File Offset: 0x00A70D5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_LandEnd_Net(int EntryPoint)
		{
			GA_Role_LandEnd_Net_C.__ExecuteUbergraph_GA_Role_LandEnd_Net_FunctionParams* ptr = stackalloc GA_Role_LandEnd_Net_C.__ExecuteUbergraph_GA_Role_LandEnd_Net_FunctionParams[(UIntPtr)1223] + 15L / (long)sizeof(GA_Role_LandEnd_Net_C.__ExecuteUbergraph_GA_Role_LandEnd_Net_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_LandEnd_Net_C.__ExecuteUbergraph_GA_Role_LandEnd_Net_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_LandEnd_Net_C.__ExecuteUbergraph_GA_Role_LandEnd_Net_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2CC RID: 176844 RVA: 0x00A72BA6 File Offset: 0x00A70DA6
		protected GA_Role_LandEnd_Net_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A1B RID: 96795
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_LandEnd_Net.GA_Role_LandEnd_Net_C";

		// Token: 0x04017A1C RID: 96796
		private static IntPtr _ClassPtr;

		// Token: 0x04017A1D RID: 96797
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A1E RID: 96798
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A1F RID: 96799
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A20 RID: 96800
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr;

		// Token: 0x04017A21 RID: 96801
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr;

		// Token: 0x04017A22 RID: 96802
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr;

		// Token: 0x04017A23 RID: 96803
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr;

		// Token: 0x04017A24 RID: 96804
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8120D6F4B4_NativeFunctionPtr;

		// Token: 0x04017A25 RID: 96805
		private static IntPtr __Added_B7E505E3445443CA4C27F38B7FAAFD98_NativeFunctionPtr;

		// Token: 0x04017A26 RID: 96806
		private static IntPtr __Added_CF97F8BF4298CF4D3C76EB9D81A391D8_NativeFunctionPtr;

		// Token: 0x04017A27 RID: 96807
		private static IntPtr __OnFinish_60C8757C4F274DFA6A15BFB2BBC51946_NativeFunctionPtr;

		// Token: 0x04017A28 RID: 96808
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A29 RID: 96809
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A2A RID: 96810
		private static IntPtr __ExecuteUbergraph_GA_Role_LandEnd_Net_NativeFunctionPtr;

		// Token: 0x0200A30B RID: 41739
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_B7E505E3445443CA4C27F38B7FAAFD98_FunctionParams
		{
			// Token: 0x040330D8 RID: 209112
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A30C RID: 41740
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_CF97F8BF4298CF4D3C76EB9D81A391D8_FunctionParams
		{
			// Token: 0x040330D9 RID: 209113
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A30D RID: 41741
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330DA RID: 209114
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A30E RID: 41742
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1208)]
		protected ref struct __ExecuteUbergraph_GA_Role_LandEnd_Net_FunctionParams
		{
			// Token: 0x040330DB RID: 209115
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
