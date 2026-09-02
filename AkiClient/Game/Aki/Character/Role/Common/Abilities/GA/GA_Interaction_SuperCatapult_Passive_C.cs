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
	// Token: 0x02004097 RID: 16535
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_SuperCatapult_Passive.GA_Interaction_SuperCatapult_Passive_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Interaction_SuperCatapult_Passive_C : Ga_Passive_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B077 RID: 176247 RVA: 0x00A6DDAF File Offset: 0x00A6BFAF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Interaction_SuperCatapult_Passive_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_SuperCatapult_Passive.GA_Interaction_SuperCatapult_Passive_C");
			}
			return GA_Interaction_SuperCatapult_Passive_C._ClassPtr;
		}

		// Token: 0x0602B078 RID: 176248 RVA: 0x00A6DDD4 File Offset: 0x00A6BFD4
		public GA_Interaction_SuperCatapult_Passive_C() : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_SuperCatapult_Passive_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B079 RID: 176249 RVA: 0x00A6DDFC File Offset: 0x00A6BFFC
		[NullableContext(1)]
		public GA_Interaction_SuperCatapult_Passive_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Interaction_SuperCatapult_Passive_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700707C RID: 28796
		// (get) Token: 0x0602B07A RID: 176250 RVA: 0x00A6DE30 File Offset: 0x00A6C030
		// (set) Token: 0x0602B07B RID: 176251 RVA: 0x00A6DE69 File Offset: 0x00A6C069
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Interaction_SuperCatapult_Passive_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Interaction_SuperCatapult_Passive_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B07C RID: 176252 RVA: 0x00A6DE8A File Offset: 0x00A6C08A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B07D RID: 176253 RVA: 0x00A6DE9E File Offset: 0x00A6C09E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_SuperCatapult_Passive_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B07E RID: 176254 RVA: 0x00A6DEB4 File Offset: 0x00A6C0B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B07F RID: 176255 RVA: 0x00A6DEFC File Offset: 0x00A6C0FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_SuperCatapult_Passive_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B080 RID: 176256 RVA: 0x00A6DF44 File Offset: 0x00A6C144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive(int EntryPoint)
		{
			GA_Interaction_SuperCatapult_Passive_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_FunctionParams* ptr = stackalloc GA_Interaction_SuperCatapult_Passive_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Interaction_SuperCatapult_Passive_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Interaction_SuperCatapult_Passive_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Interaction_SuperCatapult_Passive_C.__ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B081 RID: 176257 RVA: 0x00A6DF8B File Offset: 0x00A6C18B
		protected GA_Interaction_SuperCatapult_Passive_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017874 RID: 96372
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Interaction_SuperCatapult_Passive.GA_Interaction_SuperCatapult_Passive_C";

		// Token: 0x04017875 RID: 96373
		private static IntPtr _ClassPtr;

		// Token: 0x04017876 RID: 96374
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017877 RID: 96375
		internal new static int __PropertyOffset_0;

		// Token: 0x04017878 RID: 96376
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017879 RID: 96377
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x0401787A RID: 96378
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x0401787B RID: 96379
		private static IntPtr __ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_NativeFunctionPtr;

		// Token: 0x0200A2C9 RID: 41673
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033085 RID: 209029
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A2CA RID: 41674
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_GA_Interaction_SuperCatapult_Passive_FunctionParams
		{
			// Token: 0x04033086 RID: 209030
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
