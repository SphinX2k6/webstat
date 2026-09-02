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
	// Token: 0x02004095 RID: 16533
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_StandControl_Passive.GA_Interaction_StandControl_Passive_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Interaction_StandControl_Passive_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B059 RID: 176217 RVA: 0x00A6D8EF File Offset: 0x00A6BAEF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_StandControl_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_StandControl_Passive.GA_Interaction_StandControl_Passive_C");
			}
			return GA_Interaction_StandControl_Passive_C._ClassPtr;
		}

		// Token: 0x0602B05A RID: 176218 RVA: 0x00A6D914 File Offset: 0x00A6BB14
		public GA_Interaction_StandControl_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_StandControl_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B05B RID: 176219 RVA: 0x00A6D93C File Offset: 0x00A6BB3C
		[NullableContext(1)]
		public GA_Interaction_StandControl_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_StandControl_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007079 RID: 28793
		// (get) Token: 0x0602B05C RID: 176220 RVA: 0x00A6D970 File Offset: 0x00A6BB70
		// (set) Token: 0x0602B05D RID: 176221 RVA: 0x00A6D9A9 File Offset: 0x00A6BBA9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_StandControl_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_StandControl_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B05E RID: 176222 RVA: 0x00A6D9CA File Offset: 0x00A6BBCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B05F RID: 176223 RVA: 0x00A6D9DE File Offset: 0x00A6BBDE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_StandControl_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B060 RID: 176224 RVA: 0x00A6D9F4 File Offset: 0x00A6BBF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B061 RID: 176225 RVA: 0x00A6DA3C File Offset: 0x00A6BC3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_StandControl_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B062 RID: 176226 RVA: 0x00A6DA84 File Offset: 0x00A6BC84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_StandControl_Passive(int EntryPoint)
		{
			GA_Interaction_StandControl_Passive_C.__ExecuteUbergraph_GA_Interaction_StandControl_Passive_FunctionParams* ptr = stackalloc GA_Interaction_StandControl_Passive_C.__ExecuteUbergraph_GA_Interaction_StandControl_Passive_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Interaction_StandControl_Passive_C.__ExecuteUbergraph_GA_Interaction_StandControl_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_StandControl_Passive_C.__ExecuteUbergraph_GA_Interaction_StandControl_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_StandControl_Passive_C.__ExecuteUbergraph_GA_Interaction_StandControl_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B063 RID: 176227 RVA: 0x00A6DACB File Offset: 0x00A6BCCB
		protected GA_Interaction_StandControl_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401785D RID: 96349
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_StandControl_Passive.GA_Interaction_StandControl_Passive_C";

		// Token: 0x0401785E RID: 96350
		private static IntPtr _ClassPtr;

		// Token: 0x0401785F RID: 96351
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017860 RID: 96352
		internal new static int __PropertyOffset_0;

		// Token: 0x04017861 RID: 96353
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017862 RID: 96354
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017863 RID: 96355
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017864 RID: 96356
		private static IntPtr __ExecuteUbergraph_GA_Interaction_StandControl_Passive_NativeFunctionPtr;

		// Token: 0x0200A2C4 RID: 41668
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403307E RID: 209022
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2C5 RID: 41669
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_StandControl_Passive_FunctionParams
		{
			// Token: 0x0403307F RID: 209023
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
