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
	// Token: 0x020040AF RID: 16559
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_B_Net.GA_Role_Move_B_Net_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_Move_B_Net_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B2DF RID: 176863 RVA: 0x00A72F87 File Offset: 0x00A71187
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Move_B_Net_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_B_Net.GA_Role_Move_B_Net_C");
			}
			return GA_Role_Move_B_Net_C._ClassPtr;
		}

		// Token: 0x0602B2E0 RID: 176864 RVA: 0x00A72FAC File Offset: 0x00A711AC
		public GA_Role_Move_B_Net_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_B_Net_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B2E1 RID: 176865 RVA: 0x00A72FD4 File Offset: 0x00A711D4
		[NullableContext(1)]
		public GA_Role_Move_B_Net_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_B_Net_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070FD RID: 28925
		// (get) Token: 0x0602B2E2 RID: 176866 RVA: 0x00A73008 File Offset: 0x00A71208
		// (set) Token: 0x0602B2E3 RID: 176867 RVA: 0x00A73041 File Offset: 0x00A71241
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Move_B_Net_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Move_B_Net_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B2E4 RID: 176868 RVA: 0x00A73064 File Offset: 0x00A71264
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_CanActivateAbility(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_B_Net_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_Net_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(GA_Role_Move_B_Net_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_B_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B2E5 RID: 176869 RVA: 0x00A73128 File Offset: 0x00A71328
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool K2_CanActivateAbility_Implementation(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_B_Net_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_Net_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(GA_Role_Move_B_Net_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 0);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_B_Net_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B2E6 RID: 176870 RVA: 0x00A731EC File Offset: 0x00A713EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81A7B032EA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__OnTick_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2E7 RID: 176871 RVA: 0x00A73200 File Offset: 0x00A71400
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81A7B032EA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__OnCancelled_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2E8 RID: 176872 RVA: 0x00A73214 File Offset: 0x00A71414
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81A7B032EA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__OnInterrupted_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2E9 RID: 176873 RVA: 0x00A73228 File Offset: 0x00A71428
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81A7B032EA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__OnBlendOut_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2EA RID: 176874 RVA: 0x00A7323C File Offset: 0x00A7143C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81A7B032EA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__OnCompleted_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2EB RID: 176875 RVA: 0x00A73250 File Offset: 0x00A71450
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A308FB4881(in FGameplayTag Tag)
		{
			GA_Role_Move_B_Net_C.__Added_21071CB943CD992BF8EFD6A308FB4881_FunctionParams* ptr = stackalloc GA_Role_Move_B_Net_C.__Added_21071CB943CD992BF8EFD6A308FB4881_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Role_Move_B_Net_C.__Added_21071CB943CD992BF8EFD6A308FB4881_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_Net_C.__Added_21071CB943CD992BF8EFD6A308FB4881_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__Added_21071CB943CD992BF8EFD6A308FB4881_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2EC RID: 176876 RVA: 0x00A7329B File Offset: 0x00A7149B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2ED RID: 176877 RVA: 0x00A732AF File Offset: 0x00A714AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B2EE RID: 176878 RVA: 0x00A732C4 File Offset: 0x00A714C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_Move_B_Net_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_Net_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_B_Net_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2EF RID: 176879 RVA: 0x00A7330C File Offset: 0x00A7150C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_Move_B_Net_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_Net_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_B_Net_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2F0 RID: 176880 RVA: 0x00A73354 File Offset: 0x00A71554
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Move_B_Net(int EntryPoint)
		{
			GA_Role_Move_B_Net_C.__ExecuteUbergraph_GA_Role_Move_B_Net_FunctionParams* ptr = stackalloc GA_Role_Move_B_Net_C.__ExecuteUbergraph_GA_Role_Move_B_Net_FunctionParams[(UIntPtr)871] + 15L / (long)sizeof(GA_Role_Move_B_Net_C.__ExecuteUbergraph_GA_Role_Move_B_Net_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_Net_C.__ExecuteUbergraph_GA_Role_Move_B_Net_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_Net_C.__ExecuteUbergraph_GA_Role_Move_B_Net_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2F1 RID: 176881 RVA: 0x00A7339E File Offset: 0x00A7159E
		protected GA_Role_Move_B_Net_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A39 RID: 96825
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_B_Net.GA_Role_Move_B_Net_C";

		// Token: 0x04017A3A RID: 96826
		private static IntPtr _ClassPtr;

		// Token: 0x04017A3B RID: 96827
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A3C RID: 96828
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A3D RID: 96829
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A3E RID: 96830
		private static IntPtr __K2_CanActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A3F RID: 96831
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr;

		// Token: 0x04017A40 RID: 96832
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr;

		// Token: 0x04017A41 RID: 96833
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr;

		// Token: 0x04017A42 RID: 96834
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr;

		// Token: 0x04017A43 RID: 96835
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81A7B032EA_NativeFunctionPtr;

		// Token: 0x04017A44 RID: 96836
		private static IntPtr __Added_21071CB943CD992BF8EFD6A308FB4881_NativeFunctionPtr;

		// Token: 0x04017A45 RID: 96837
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A46 RID: 96838
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A47 RID: 96839
		private static IntPtr __ExecuteUbergraph_GA_Role_Move_B_Net_NativeFunctionPtr;

		// Token: 0x0200A312 RID: 41746
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected new ref struct __K2_CanActivateAbility_FunctionParams
		{
			// Token: 0x040330E1 RID: 209121
			[FieldOffset(0)]
			public byte ActorInfo;

			// Token: 0x040330E2 RID: 209122
			[FieldOffset(80)]
			public byte RelevantTags;

			// Token: 0x040330E3 RID: 209123
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A313 RID: 41747
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A308FB4881_FunctionParams
		{
			// Token: 0x040330E4 RID: 209124
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A314 RID: 41748
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330E5 RID: 209125
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A315 RID: 41749
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 856)]
		protected ref struct __ExecuteUbergraph_GA_Role_Move_B_Net_FunctionParams
		{
			// Token: 0x040330E6 RID: 209126
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
