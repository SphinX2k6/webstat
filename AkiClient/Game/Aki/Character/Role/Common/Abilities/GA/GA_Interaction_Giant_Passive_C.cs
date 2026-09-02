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
	// Token: 0x02004092 RID: 16530
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Giant_Passive.GA_Interaction_Giant_Passive_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Interaction_Giant_Passive_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B02E RID: 176174 RVA: 0x00A6D347 File Offset: 0x00A6B547
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Giant_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Giant_Passive.GA_Interaction_Giant_Passive_C");
			}
			return GA_Interaction_Giant_Passive_C._ClassPtr;
		}

		// Token: 0x0602B02F RID: 176175 RVA: 0x00A6D36C File Offset: 0x00A6B56C
		public GA_Interaction_Giant_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Giant_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B030 RID: 176176 RVA: 0x00A6D394 File Offset: 0x00A6B594
		[NullableContext(1)]
		public GA_Interaction_Giant_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Giant_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007074 RID: 28788
		// (get) Token: 0x0602B031 RID: 176177 RVA: 0x00A6D3C8 File Offset: 0x00A6B5C8
		// (set) Token: 0x0602B032 RID: 176178 RVA: 0x00A6D401 File Offset: 0x00A6B601
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Giant_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Giant_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B033 RID: 176179 RVA: 0x00A6D422 File Offset: 0x00A6B622
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B034 RID: 176180 RVA: 0x00A6D436 File Offset: 0x00A6B636
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Giant_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B035 RID: 176181 RVA: 0x00A6D44C File Offset: 0x00A6B64C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B036 RID: 176182 RVA: 0x00A6D494 File Offset: 0x00A6B694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Giant_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B037 RID: 176183 RVA: 0x00A6D4DC File Offset: 0x00A6B6DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Giant_Passive(int EntryPoint)
		{
			GA_Interaction_Giant_Passive_C.__ExecuteUbergraph_GA_Interaction_Giant_Passive_FunctionParams* ptr = stackalloc GA_Interaction_Giant_Passive_C.__ExecuteUbergraph_GA_Interaction_Giant_Passive_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Interaction_Giant_Passive_C.__ExecuteUbergraph_GA_Interaction_Giant_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Giant_Passive_C.__ExecuteUbergraph_GA_Interaction_Giant_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Giant_Passive_C.__ExecuteUbergraph_GA_Interaction_Giant_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B038 RID: 176184 RVA: 0x00A6D523 File Offset: 0x00A6B723
		protected GA_Interaction_Giant_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401783B RID: 96315
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Giant_Passive.GA_Interaction_Giant_Passive_C";

		// Token: 0x0401783C RID: 96316
		private static IntPtr _ClassPtr;

		// Token: 0x0401783D RID: 96317
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401783E RID: 96318
		internal new static int __PropertyOffset_0;

		// Token: 0x0401783F RID: 96319
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017840 RID: 96320
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017841 RID: 96321
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017842 RID: 96322
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Giant_Passive_NativeFunctionPtr;

		// Token: 0x0200A2C0 RID: 41664
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403307A RID: 209018
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2C1 RID: 41665
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Giant_Passive_FunctionParams
		{
			// Token: 0x0403307B RID: 209019
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
