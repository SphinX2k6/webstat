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
	// Token: 0x020040B1 RID: 16561
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_F_Net.GA_Role_Move_F_Net_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Role_Move_F_Net_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B307 RID: 176903 RVA: 0x00A737EF File Offset: 0x00A719EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Move_F_Net_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_F_Net.GA_Role_Move_F_Net_C");
			}
			return GA_Role_Move_F_Net_C._ClassPtr;
		}

		// Token: 0x0602B308 RID: 176904 RVA: 0x00A73814 File Offset: 0x00A71A14
		public GA_Role_Move_F_Net_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_F_Net_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B309 RID: 176905 RVA: 0x00A7383C File Offset: 0x00A71A3C
		[NullableContext(1)]
		public GA_Role_Move_F_Net_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_F_Net_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007100 RID: 28928
		// (get) Token: 0x0602B30A RID: 176906 RVA: 0x00A73870 File Offset: 0x00A71A70
		// (set) Token: 0x0602B30B RID: 176907 RVA: 0x00A738A9 File Offset: 0x00A71AA9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Move_F_Net_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Move_F_Net_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007101 RID: 28929
		// (get) Token: 0x0602B30C RID: 176908 RVA: 0x00A738CA File Offset: 0x00A71ACA
		// (set) Token: 0x0602B30D RID: 176909 RVA: 0x00A738DE File Offset: 0x00A71ADE
		[Nullable(2)]
		public unsafe UBaseAbilitySystemComponent AbilitySystemComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBaseAbilitySystemComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Move_F_Net_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Move_F_Net_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B30E RID: 176910 RVA: 0x00A738F4 File Offset: 0x00A71AF4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_CanActivateAbility(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_F_Net_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_F_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B30F RID: 176911 RVA: 0x00A739B8 File Offset: 0x00A71BB8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool K2_CanActivateAbility_Implementation(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_F_Net_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 0);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_F_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B310 RID: 176912 RVA: 0x00A73A7C File Offset: 0x00A71C7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81E2803D47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__OnTick_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B311 RID: 176913 RVA: 0x00A73A90 File Offset: 0x00A71C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81E2803D47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__OnCancelled_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B312 RID: 176914 RVA: 0x00A73AA4 File Offset: 0x00A71CA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81E2803D47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__OnInterrupted_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B313 RID: 176915 RVA: 0x00A73AB8 File Offset: 0x00A71CB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81E2803D47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__OnBlendOut_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B314 RID: 176916 RVA: 0x00A73ACC File Offset: 0x00A71CCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81E2803D47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__OnCompleted_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr, null);
		}

		// Token: 0x0602B315 RID: 176917 RVA: 0x00A73AE0 File Offset: 0x00A71CE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3DAFC9936(in FGameplayTag Tag)
		{
			GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A3DAFC9936_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A3DAFC9936_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A3DAFC9936_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A3DAFC9936_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A3DAFC9936_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B316 RID: 176918 RVA: 0x00A73B2C File Offset: 0x00A71D2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A382AFCAE1(in FGameplayTag Tag)
		{
			GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A382AFCAE1_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A382AFCAE1_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A382AFCAE1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A382AFCAE1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__Added_21071CB943CD992BF8EFD6A382AFCAE1_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B317 RID: 176919 RVA: 0x00A73B77 File Offset: 0x00A71D77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B318 RID: 176920 RVA: 0x00A73B8B File Offset: 0x00A71D8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B319 RID: 176921 RVA: 0x00A73BA0 File Offset: 0x00A71DA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_Move_F_Net_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B31A RID: 176922 RVA: 0x00A73BE8 File Offset: 0x00A71DE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_Move_F_Net_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B31B RID: 176923 RVA: 0x00A73C30 File Offset: 0x00A71E30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Move_F_Net(int EntryPoint)
		{
			GA_Role_Move_F_Net_C.__ExecuteUbergraph_GA_Role_Move_F_Net_FunctionParams* ptr = stackalloc GA_Role_Move_F_Net_C.__ExecuteUbergraph_GA_Role_Move_F_Net_FunctionParams[(UIntPtr)975] + 15L / (long)sizeof(GA_Role_Move_F_Net_C.__ExecuteUbergraph_GA_Role_Move_F_Net_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_Net_C.__ExecuteUbergraph_GA_Role_Move_F_Net_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_Net_C.__ExecuteUbergraph_GA_Role_Move_F_Net_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B31C RID: 176924 RVA: 0x00A73C7A File Offset: 0x00A71E7A
		protected GA_Role_Move_F_Net_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A58 RID: 96856
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_F_Net.GA_Role_Move_F_Net_C";

		// Token: 0x04017A59 RID: 96857
		private static IntPtr _ClassPtr;

		// Token: 0x04017A5A RID: 96858
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A5B RID: 96859
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A5C RID: 96860
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A5D RID: 96861
		internal new static int __PropertyOffset_1;

		// Token: 0x04017A5E RID: 96862
		private static IntPtr __K2_CanActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A5F RID: 96863
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr;

		// Token: 0x04017A60 RID: 96864
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr;

		// Token: 0x04017A61 RID: 96865
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr;

		// Token: 0x04017A62 RID: 96866
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr;

		// Token: 0x04017A63 RID: 96867
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81E2803D47_NativeFunctionPtr;

		// Token: 0x04017A64 RID: 96868
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3DAFC9936_NativeFunctionPtr;

		// Token: 0x04017A65 RID: 96869
		private static IntPtr __Added_21071CB943CD992BF8EFD6A382AFCAE1_NativeFunctionPtr;

		// Token: 0x04017A66 RID: 96870
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A67 RID: 96871
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A68 RID: 96872
		private static IntPtr __ExecuteUbergraph_GA_Role_Move_F_Net_NativeFunctionPtr;

		// Token: 0x0200A31A RID: 41754
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected new ref struct __K2_CanActivateAbility_FunctionParams
		{
			// Token: 0x040330ED RID: 209133
			[FieldOffset(0)]
			public byte ActorInfo;

			// Token: 0x040330EE RID: 209134
			[FieldOffset(80)]
			public byte RelevantTags;

			// Token: 0x040330EF RID: 209135
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A31B RID: 41755
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3DAFC9936_FunctionParams
		{
			// Token: 0x040330F0 RID: 209136
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A31C RID: 41756
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A382AFCAE1_FunctionParams
		{
			// Token: 0x040330F1 RID: 209137
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A31D RID: 41757
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330F2 RID: 209138
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A31E RID: 41758
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 960)]
		protected ref struct __ExecuteUbergraph_GA_Role_Move_F_Net_FunctionParams
		{
			// Token: 0x040330F3 RID: 209139
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
