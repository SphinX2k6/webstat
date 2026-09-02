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
	// Token: 0x0200408C RID: 16524
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Bounce_Passive.GA_Interaction_Bounce_Passive_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Interaction_Bounce_Passive_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AFCD RID: 176077 RVA: 0x00A6C59B File Offset: 0x00A6A79B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_Bounce_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Bounce_Passive.GA_Interaction_Bounce_Passive_C");
			}
			return GA_Interaction_Bounce_Passive_C._ClassPtr;
		}

		// Token: 0x0602AFCE RID: 176078 RVA: 0x00A6C5C0 File Offset: 0x00A6A7C0
		public GA_Interaction_Bounce_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Bounce_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AFCF RID: 176079 RVA: 0x00A6C5E8 File Offset: 0x00A6A7E8
		[NullableContext(1)]
		public GA_Interaction_Bounce_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_Bounce_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700706A RID: 28778
		// (get) Token: 0x0602AFD0 RID: 176080 RVA: 0x00A6C61C File Offset: 0x00A6A81C
		// (set) Token: 0x0602AFD1 RID: 176081 RVA: 0x00A6C655 File Offset: 0x00A6A855
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_Bounce_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_Bounce_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602AFD2 RID: 176082 RVA: 0x00A6C676 File Offset: 0x00A6A876
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602AFD3 RID: 176083 RVA: 0x00A6C68A File Offset: 0x00A6A88A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Bounce_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AFD4 RID: 176084 RVA: 0x00A6C6A0 File Offset: 0x00A6A8A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602AFD5 RID: 176085 RVA: 0x00A6C6E8 File Offset: 0x00A6A8E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Bounce_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFD6 RID: 176086 RVA: 0x00A6C730 File Offset: 0x00A6A930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_Bounce_Passive(int EntryPoint)
		{
			GA_Interaction_Bounce_Passive_C.__ExecuteUbergraph_GA_Interaction_Bounce_Passive_FunctionParams* ptr = stackalloc GA_Interaction_Bounce_Passive_C.__ExecuteUbergraph_GA_Interaction_Bounce_Passive_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Interaction_Bounce_Passive_C.__ExecuteUbergraph_GA_Interaction_Bounce_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_Bounce_Passive_C.__ExecuteUbergraph_GA_Interaction_Bounce_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_Bounce_Passive_C.__ExecuteUbergraph_GA_Interaction_Bounce_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AFD7 RID: 176087 RVA: 0x00A6C777 File Offset: 0x00A6A977
		protected GA_Interaction_Bounce_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177EE RID: 96238
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_Bounce_Passive.GA_Interaction_Bounce_Passive_C";

		// Token: 0x040177EF RID: 96239
		private static IntPtr _ClassPtr;

		// Token: 0x040177F0 RID: 96240
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040177F1 RID: 96241
		internal new static int __PropertyOffset_0;

		// Token: 0x040177F2 RID: 96242
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040177F3 RID: 96243
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x040177F4 RID: 96244
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x040177F5 RID: 96245
		private static IntPtr __ExecuteUbergraph_GA_Interaction_Bounce_Passive_NativeFunctionPtr;

		// Token: 0x0200A2B4 RID: 41652
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403306A RID: 209002
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2B5 RID: 41653
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_Bounce_Passive_FunctionParams
		{
			// Token: 0x0403306B RID: 209003
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
