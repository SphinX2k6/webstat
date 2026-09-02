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
	// Token: 0x0200408F RID: 16527
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult_Passive.GA_Interaction_Catapult_Passive_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Interaction_Catapult_Passive_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B003 RID: 176131 RVA: 0x00A6CD9B File Offset: 0x00A6AF9B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Catapult_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult_Passive.GA_Interaction_Catapult_Passive_C");
			}
			return GA_Interaction_Catapult_Passive_C._ClassPtr;
		}

		// Token: 0x0602B004 RID: 176132 RVA: 0x00A6CDC0 File Offset: 0x00A6AFC0
		public GA_Interaction_Catapult_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Catapult_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B005 RID: 176133 RVA: 0x00A6CDE8 File Offset: 0x00A6AFE8
		[NullableContext(1)]
		public GA_Interaction_Catapult_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Catapult_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700706F RID: 28783
		// (get) Token: 0x0602B006 RID: 176134 RVA: 0x00A6CE1C File Offset: 0x00A6B01C
		// (set) Token: 0x0602B007 RID: 176135 RVA: 0x00A6CE55 File Offset: 0x00A6B055
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Catapult_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Catapult_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B008 RID: 176136 RVA: 0x00A6CE76 File Offset: 0x00A6B076
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B009 RID: 176137 RVA: 0x00A6CE8A File Offset: 0x00A6B08A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B00A RID: 176138 RVA: 0x00A6CEA0 File Offset: 0x00A6B0A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B00B RID: 176139 RVA: 0x00A6CEE8 File Offset: 0x00A6B0E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B00C RID: 176140 RVA: 0x00A6CF30 File Offset: 0x00A6B130
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Catapult_Passive(int EntryPoint)
		{
			GA_Interaction_Catapult_Passive_C.__ExecuteUbergraph_GA_Interaction_Catapult_Passive_FunctionParams* ptr = stackalloc GA_Interaction_Catapult_Passive_C.__ExecuteUbergraph_GA_Interaction_Catapult_Passive_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Interaction_Catapult_Passive_C.__ExecuteUbergraph_GA_Interaction_Catapult_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Catapult_Passive_C.__ExecuteUbergraph_GA_Interaction_Catapult_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Catapult_Passive_C.__ExecuteUbergraph_GA_Interaction_Catapult_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B00D RID: 176141 RVA: 0x00A6CF77 File Offset: 0x00A6B177
		protected GA_Interaction_Catapult_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017819 RID: 96281
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Catapult_Passive.GA_Interaction_Catapult_Passive_C";

		// Token: 0x0401781A RID: 96282
		private static IntPtr _ClassPtr;

		// Token: 0x0401781B RID: 96283
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401781C RID: 96284
		internal new static int __PropertyOffset_0;

		// Token: 0x0401781D RID: 96285
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401781E RID: 96286
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401781F RID: 96287
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017820 RID: 96288
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Catapult_Passive_NativeFunctionPtr;

		// Token: 0x0200A2BC RID: 41660
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033076 RID: 209014
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2BD RID: 41661
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Catapult_Passive_FunctionParams
		{
			// Token: 0x04033077 RID: 209015
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
