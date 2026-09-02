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
	// Token: 0x020040B0 RID: 16560
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_F.GA_Role_Move_F_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Role_Move_F_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B2F2 RID: 176882 RVA: 0x00A733A7 File Offset: 0x00A715A7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Move_F_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_F.GA_Role_Move_F_C");
			}
			return GA_Role_Move_F_C._ClassPtr;
		}

		// Token: 0x0602B2F3 RID: 176883 RVA: 0x00A733CC File Offset: 0x00A715CC
		public GA_Role_Move_F_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_F_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B2F4 RID: 176884 RVA: 0x00A733F4 File Offset: 0x00A715F4
		[NullableContext(1)]
		public GA_Role_Move_F_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_F_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070FE RID: 28926
		// (get) Token: 0x0602B2F5 RID: 176885 RVA: 0x00A73428 File Offset: 0x00A71628
		// (set) Token: 0x0602B2F6 RID: 176886 RVA: 0x00A73461 File Offset: 0x00A71661
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Move_F_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Move_F_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170070FF RID: 28927
		// (get) Token: 0x0602B2F7 RID: 176887 RVA: 0x00A73482 File Offset: 0x00A71682
		// (set) Token: 0x0602B2F8 RID: 176888 RVA: 0x00A73496 File Offset: 0x00A71696
		[Nullable(2)]
		public unsafe UBaseAbilitySystemComponent AbilitySystemComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBaseAbilitySystemComponent>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Move_F_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Role_Move_F_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602B2F9 RID: 176889 RVA: 0x00A734AC File Offset: 0x00A716AC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_CanActivateAbility(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_F_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Role_Move_F_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_F_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B2FA RID: 176890 RVA: 0x00A73570 File Offset: 0x00A71770
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool K2_CanActivateAbility_Implementation(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_F_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(GA_Role_Move_F_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 0);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_F_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B2FB RID: 176891 RVA: 0x00A73634 File Offset: 0x00A71834
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81CC27EAD8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__OnTick_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2FC RID: 176892 RVA: 0x00A73648 File Offset: 0x00A71848
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81CC27EAD8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__OnCancelled_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2FD RID: 176893 RVA: 0x00A7365C File Offset: 0x00A7185C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81CC27EAD8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__OnInterrupted_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2FE RID: 176894 RVA: 0x00A73670 File Offset: 0x00A71870
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81CC27EAD8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__OnBlendOut_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2FF RID: 176895 RVA: 0x00A73684 File Offset: 0x00A71884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81CC27EAD8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__OnCompleted_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B300 RID: 176896 RVA: 0x00A73698 File Offset: 0x00A71898
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_8AA179764AE301668C90EDB6D5BAFF54(in FGameplayTag Tag)
		{
			GA_Role_Move_F_C.__Added_8AA179764AE301668C90EDB6D5BAFF54_FunctionParams* ptr = stackalloc GA_Role_Move_F_C.__Added_8AA179764AE301668C90EDB6D5BAFF54_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_Move_F_C.__Added_8AA179764AE301668C90EDB6D5BAFF54_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_C.__Added_8AA179764AE301668C90EDB6D5BAFF54_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__Added_8AA179764AE301668C90EDB6D5BAFF54_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B301 RID: 176897 RVA: 0x00A736E3 File Offset: 0x00A718E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B302 RID: 176898 RVA: 0x00A736F7 File Offset: 0x00A718F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B303 RID: 176899 RVA: 0x00A7370C File Offset: 0x00A7190C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_Move_F_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_F_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B304 RID: 176900 RVA: 0x00A73754 File Offset: 0x00A71954
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_Move_F_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_F_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_F_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B305 RID: 176901 RVA: 0x00A7379C File Offset: 0x00A7199C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Move_F(int EntryPoint)
		{
			GA_Role_Move_F_C.__ExecuteUbergraph_GA_Role_Move_F_FunctionParams* ptr = stackalloc GA_Role_Move_F_C.__ExecuteUbergraph_GA_Role_Move_F_FunctionParams[(UIntPtr)895] + 15L / (long)sizeof(GA_Role_Move_F_C.__ExecuteUbergraph_GA_Role_Move_F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_F_C.__ExecuteUbergraph_GA_Role_Move_F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_F_C.__ExecuteUbergraph_GA_Role_Move_F_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B306 RID: 176902 RVA: 0x00A737E6 File Offset: 0x00A719E6
		protected GA_Role_Move_F_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A48 RID: 96840
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_F.GA_Role_Move_F_C";

		// Token: 0x04017A49 RID: 96841
		private static IntPtr _ClassPtr;

		// Token: 0x04017A4A RID: 96842
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A4B RID: 96843
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A4C RID: 96844
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A4D RID: 96845
		internal new static int __PropertyOffset_1;

		// Token: 0x04017A4E RID: 96846
		private static IntPtr __K2_CanActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A4F RID: 96847
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr;

		// Token: 0x04017A50 RID: 96848
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr;

		// Token: 0x04017A51 RID: 96849
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr;

		// Token: 0x04017A52 RID: 96850
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr;

		// Token: 0x04017A53 RID: 96851
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81CC27EAD8_NativeFunctionPtr;

		// Token: 0x04017A54 RID: 96852
		private static IntPtr __Added_8AA179764AE301668C90EDB6D5BAFF54_NativeFunctionPtr;

		// Token: 0x04017A55 RID: 96853
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A56 RID: 96854
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A57 RID: 96855
		private static IntPtr __ExecuteUbergraph_GA_Role_Move_F_NativeFunctionPtr;

		// Token: 0x0200A316 RID: 41750
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected new ref struct __K2_CanActivateAbility_FunctionParams
		{
			// Token: 0x040330E7 RID: 209127
			[FieldOffset(0)]
			public byte ActorInfo;

			// Token: 0x040330E8 RID: 209128
			[FieldOffset(80)]
			public byte RelevantTags;

			// Token: 0x040330E9 RID: 209129
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A317 RID: 41751
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_8AA179764AE301668C90EDB6D5BAFF54_FunctionParams
		{
			// Token: 0x040330EA RID: 209130
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A318 RID: 41752
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330EB RID: 209131
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A319 RID: 41753
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 880)]
		protected ref struct __ExecuteUbergraph_GA_Role_Move_F_FunctionParams
		{
			// Token: 0x040330EC RID: 209132
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
