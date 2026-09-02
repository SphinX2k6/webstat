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
	// Token: 0x020040BF RID: 16575
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_End.GA_Super_Sprint_End_C")]
	[UnrealStructLayout(1488, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1488)]
	public class GA_Super_Sprint_End_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B4D6 RID: 177366 RVA: 0x00A77477 File Offset: 0x00A75677
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_End_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_End.GA_Super_Sprint_End_C");
			}
			return GA_Super_Sprint_End_C._ClassPtr;
		}

		// Token: 0x0602B4D7 RID: 177367 RVA: 0x00A7749C File Offset: 0x00A7569C
		public GA_Super_Sprint_End_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_End_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B4D8 RID: 177368 RVA: 0x00A774C4 File Offset: 0x00A756C4
		[NullableContext(1)]
		public GA_Super_Sprint_End_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_End_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700716D RID: 29037
		// (get) Token: 0x0602B4D9 RID: 177369 RVA: 0x00A774F8 File Offset: 0x00A756F8
		// (set) Token: 0x0602B4DA RID: 177370 RVA: 0x00A77531 File Offset: 0x00A75731
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_End_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_End_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602B4DB RID: 177371 RVA: 0x00A77552 File Offset: 0x00A75752
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81E600A766()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__OnTick_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4DC RID: 177372 RVA: 0x00A77566 File Offset: 0x00A75766
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81E600A766()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__OnCancelled_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4DD RID: 177373 RVA: 0x00A7757A File Offset: 0x00A7577A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81E600A766()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__OnInterrupted_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4DE RID: 177374 RVA: 0x00A7758E File Offset: 0x00A7578E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81E600A766()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__OnBlendOut_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4DF RID: 177375 RVA: 0x00A775A2 File Offset: 0x00A757A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81E600A766()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__OnCompleted_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4E0 RID: 177376 RVA: 0x00A775B6 File Offset: 0x00A757B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4E1 RID: 177377 RVA: 0x00A775CA File Offset: 0x00A757CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_End_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B4E2 RID: 177378 RVA: 0x00A775E0 File Offset: 0x00A757E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4E3 RID: 177379 RVA: 0x00A77628 File Offset: 0x00A75828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_End_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_End_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_End_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_End_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4E4 RID: 177380 RVA: 0x00A77670 File Offset: 0x00A75870
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_End(int EntryPoint)
		{
			GA_Super_Sprint_End_C.__ExecuteUbergraph_GA_Super_Sprint_End_FunctionParams* ptr = stackalloc GA_Super_Sprint_End_C.__ExecuteUbergraph_GA_Super_Sprint_End_FunctionParams[(UIntPtr)807] + 15L / (long)sizeof(GA_Super_Sprint_End_C.__ExecuteUbergraph_GA_Super_Sprint_End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_End_C.__ExecuteUbergraph_GA_Super_Sprint_End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_End_C.__ExecuteUbergraph_GA_Super_Sprint_End_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4E5 RID: 177381 RVA: 0x00A776BA File Offset: 0x00A758BA
		protected GA_Super_Sprint_End_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017BA3 RID: 97187
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_End.GA_Super_Sprint_End_C";

		// Token: 0x04017BA4 RID: 97188
		private static IntPtr _ClassPtr;

		// Token: 0x04017BA5 RID: 97189
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017BA6 RID: 97190
		internal new static int __PropertyOffset_0;

		// Token: 0x04017BA7 RID: 97191
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017BA8 RID: 97192
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr;

		// Token: 0x04017BA9 RID: 97193
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr;

		// Token: 0x04017BAA RID: 97194
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr;

		// Token: 0x04017BAB RID: 97195
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr;

		// Token: 0x04017BAC RID: 97196
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81E600A766_NativeFunctionPtr;

		// Token: 0x04017BAD RID: 97197
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017BAE RID: 97198
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017BAF RID: 97199
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_End_NativeFunctionPtr;

		// Token: 0x0200A35C RID: 41820
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033139 RID: 209209
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A35D RID: 41821
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 792)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_End_FunctionParams
		{
			// Token: 0x0403313A RID: 209210
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
