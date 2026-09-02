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
	// Token: 0x020040AE RID: 16558
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_B.GA_Role_Move_B_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Role_Move_B_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B2CD RID: 176845 RVA: 0x00A72BAF File Offset: 0x00A70DAF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Role_Move_B_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_B.GA_Role_Move_B_C");
			}
			return GA_Role_Move_B_C._ClassPtr;
		}

		// Token: 0x0602B2CE RID: 176846 RVA: 0x00A72BD4 File Offset: 0x00A70DD4
		public GA_Role_Move_B_C() : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_B_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B2CF RID: 176847 RVA: 0x00A72BFC File Offset: 0x00A70DFC
		[NullableContext(1)]
		public GA_Role_Move_B_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Role_Move_B_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170070FC RID: 28924
		// (get) Token: 0x0602B2D0 RID: 176848 RVA: 0x00A72C30 File Offset: 0x00A70E30
		// (set) Token: 0x0602B2D1 RID: 176849 RVA: 0x00A72C69 File Offset: 0x00A70E69
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Role_Move_B_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Role_Move_B_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B2D2 RID: 176850 RVA: 0x00A72C8C File Offset: 0x00A70E8C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_CanActivateAbility(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_B_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(GA_Role_Move_B_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_B_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B2D3 RID: 176851 RVA: 0x00A72D50 File Offset: 0x00A70F50
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override bool K2_CanActivateAbility_Implementation(FGameplayAbilityActorInfo ActorInfo, ref FGameplayTagContainer RelevantTags)
		{
			GA_Role_Move_B_C.__K2_CanActivateAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_C.__K2_CanActivateAbility_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(GA_Role_Move_B_C.__K2_CanActivateAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			if (ActorInfo != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAbilityActorInfo.StaticStruct(), &ptr->ActorInfo, ActorInfo.NativePtr, 1, false);
			}
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), &ptr->RelevantTags, RelevantTags.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 0);
			if (RelevantTags != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), RelevantTags.NativePtr, &ptr->RelevantTags, 1, false);
			}
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(GA_Role_Move_B_C.__K2_CanActivateAbility_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x0602B2D4 RID: 176852 RVA: 0x00A72E14 File Offset: 0x00A71014
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81AEFEF802()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__OnTick_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2D5 RID: 176853 RVA: 0x00A72E28 File Offset: 0x00A71028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81AEFEF802()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__OnCancelled_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2D6 RID: 176854 RVA: 0x00A72E3C File Offset: 0x00A7103C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81AEFEF802()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__OnInterrupted_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2D7 RID: 176855 RVA: 0x00A72E50 File Offset: 0x00A71050
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81AEFEF802()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__OnBlendOut_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2D8 RID: 176856 RVA: 0x00A72E64 File Offset: 0x00A71064
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81AEFEF802()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__OnCompleted_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2D9 RID: 176857 RVA: 0x00A72E78 File Offset: 0x00A71078
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B2DA RID: 176858 RVA: 0x00A72E8C File Offset: 0x00A7108C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B2DB RID: 176859 RVA: 0x00A72EA4 File Offset: 0x00A710A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Role_Move_B_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_B_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Role_Move_B_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B2DC RID: 176860 RVA: 0x00A72EEC File Offset: 0x00A710EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Role_Move_B_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Role_Move_B_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Role_Move_B_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2DD RID: 176861 RVA: 0x00A72F34 File Offset: 0x00A71134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Role_Move_B(int EntryPoint)
		{
			GA_Role_Move_B_C.__ExecuteUbergraph_GA_Role_Move_B_FunctionParams* ptr = stackalloc GA_Role_Move_B_C.__ExecuteUbergraph_GA_Role_Move_B_FunctionParams[(UIntPtr)775] + 15L / (long)sizeof(GA_Role_Move_B_C.__ExecuteUbergraph_GA_Role_Move_B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Role_Move_B_C.__ExecuteUbergraph_GA_Role_Move_B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Role_Move_B_C.__ExecuteUbergraph_GA_Role_Move_B_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B2DE RID: 176862 RVA: 0x00A72F7E File Offset: 0x00A7117E
		protected GA_Role_Move_B_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017A2B RID: 96811
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Role_Move_B.GA_Role_Move_B_C";

		// Token: 0x04017A2C RID: 96812
		private static IntPtr _ClassPtr;

		// Token: 0x04017A2D RID: 96813
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017A2E RID: 96814
		internal new static int __PropertyOffset_0;

		// Token: 0x04017A2F RID: 96815
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017A30 RID: 96816
		private static IntPtr __K2_CanActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A31 RID: 96817
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr;

		// Token: 0x04017A32 RID: 96818
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr;

		// Token: 0x04017A33 RID: 96819
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr;

		// Token: 0x04017A34 RID: 96820
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr;

		// Token: 0x04017A35 RID: 96821
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81AEFEF802_NativeFunctionPtr;

		// Token: 0x04017A36 RID: 96822
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017A37 RID: 96823
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017A38 RID: 96824
		private static IntPtr __ExecuteUbergraph_GA_Role_Move_B_NativeFunctionPtr;

		// Token: 0x0200A30F RID: 41743
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected new ref struct __K2_CanActivateAbility_FunctionParams
		{
			// Token: 0x040330DC RID: 209116
			[FieldOffset(0)]
			public byte ActorInfo;

			// Token: 0x040330DD RID: 209117
			[FieldOffset(80)]
			public byte RelevantTags;

			// Token: 0x040330DE RID: 209118
			[FieldOffset(112)]
			public bool __Result;
		}

		// Token: 0x0200A310 RID: 41744
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x040330DF RID: 209119
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A311 RID: 41745
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 760)]
		protected ref struct __ExecuteUbergraph_GA_Role_Move_B_FunctionParams
		{
			// Token: 0x040330E0 RID: 209120
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
