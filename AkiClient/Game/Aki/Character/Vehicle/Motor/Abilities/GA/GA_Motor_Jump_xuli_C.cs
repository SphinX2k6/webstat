using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.GA
{
	// Token: 0x02003FD8 RID: 16344
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_xuli.GA_Motor_Jump_xuli_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Motor_Jump_xuli_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602919A RID: 168346 RVA: 0x00A212A7 File Offset: 0x00A1F4A7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Jump_xuli_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_xuli.GA_Motor_Jump_xuli_C");
			}
			return GA_Motor_Jump_xuli_C._ClassPtr;
		}

		// Token: 0x0602919B RID: 168347 RVA: 0x00A212CC File Offset: 0x00A1F4CC
		public GA_Motor_Jump_xuli_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_xuli_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602919C RID: 168348 RVA: 0x00A212F4 File Offset: 0x00A1F4F4
		[NullableContext(1)]
		public GA_Motor_Jump_xuli_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Jump_xuli_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006561 RID: 25953
		// (get) Token: 0x0602919D RID: 168349 RVA: 0x00A21328 File Offset: 0x00A1F528
		// (set) Token: 0x0602919E RID: 168350 RVA: 0x00A21361 File Offset: 0x00A1F561
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Jump_xuli_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Jump_xuli_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006562 RID: 25954
		// (get) Token: 0x0602919F RID: 168351 RVA: 0x00A21382 File Offset: 0x00A1F582
		// (set) Token: 0x060291A0 RID: 168352 RVA: 0x00A21396 File Offset: 0x00A1F596
		[Nullable(2)]
		public unsafe AActor 被控物
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_xuli_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Jump_xuli_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060291A1 RID: 168353 RVA: 0x00A213AB File Offset: 0x00A1F5AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BF7333244()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnTick_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr, null);
		}

		// Token: 0x060291A2 RID: 168354 RVA: 0x00A213BF File Offset: 0x00A1F5BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BF7333244()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr, null);
		}

		// Token: 0x060291A3 RID: 168355 RVA: 0x00A213D3 File Offset: 0x00A1F5D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BF7333244()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr, null);
		}

		// Token: 0x060291A4 RID: 168356 RVA: 0x00A213E7 File Offset: 0x00A1F5E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BF7333244()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr, null);
		}

		// Token: 0x060291A5 RID: 168357 RVA: 0x00A213FB File Offset: 0x00A1F5FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BF7333244()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr, null);
		}

		// Token: 0x060291A6 RID: 168358 RVA: 0x00A2140F File Offset: 0x00A1F60F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B78B0D695()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnTick_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr, null);
		}

		// Token: 0x060291A7 RID: 168359 RVA: 0x00A21423 File Offset: 0x00A1F623
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B78B0D695()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr, null);
		}

		// Token: 0x060291A8 RID: 168360 RVA: 0x00A21437 File Offset: 0x00A1F637
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B78B0D695()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr, null);
		}

		// Token: 0x060291A9 RID: 168361 RVA: 0x00A2144B File Offset: 0x00A1F64B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B78B0D695()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr, null);
		}

		// Token: 0x060291AA RID: 168362 RVA: 0x00A2145F File Offset: 0x00A1F65F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B78B0D695()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr, null);
		}

		// Token: 0x060291AB RID: 168363 RVA: 0x00A21473 File Offset: 0x00A1F673
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060291AC RID: 168364 RVA: 0x00A21487 File Offset: 0x00A1F687
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060291AD RID: 168365 RVA: 0x00A2149C File Offset: 0x00A1F69C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Jump_xuli_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_xuli_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_xuli_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_xuli_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060291AE RID: 168366 RVA: 0x00A214E4 File Offset: 0x00A1F6E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Jump_xuli_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Jump_xuli_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Jump_xuli_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_xuli_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060291AF RID: 168367 RVA: 0x00A2152C File Offset: 0x00A1F72C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Jump_xuli(int EntryPoint)
		{
			GA_Motor_Jump_xuli_C.__ExecuteUbergraph_GA_Motor_Jump_xuli_FunctionParams* ptr = stackalloc GA_Motor_Jump_xuli_C.__ExecuteUbergraph_GA_Motor_Jump_xuli_FunctionParams[(UIntPtr)823] + 15L / (long)sizeof(GA_Motor_Jump_xuli_C.__ExecuteUbergraph_GA_Motor_Jump_xuli_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Jump_xuli_C.__ExecuteUbergraph_GA_Motor_Jump_xuli_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Jump_xuli_C.__ExecuteUbergraph_GA_Motor_Jump_xuli_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060291B0 RID: 168368 RVA: 0x00A21576 File Offset: 0x00A1F776
		protected GA_Motor_Jump_xuli_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C6B RID: 89195
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Jump_xuli.GA_Motor_Jump_xuli_C";

		// Token: 0x04015C6C RID: 89196
		private static IntPtr _ClassPtr;

		// Token: 0x04015C6D RID: 89197
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C6E RID: 89198
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C6F RID: 89199
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C70 RID: 89200
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C71 RID: 89201
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr;

		// Token: 0x04015C72 RID: 89202
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr;

		// Token: 0x04015C73 RID: 89203
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr;

		// Token: 0x04015C74 RID: 89204
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr;

		// Token: 0x04015C75 RID: 89205
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BF7333244_NativeFunctionPtr;

		// Token: 0x04015C76 RID: 89206
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr;

		// Token: 0x04015C77 RID: 89207
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr;

		// Token: 0x04015C78 RID: 89208
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr;

		// Token: 0x04015C79 RID: 89209
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr;

		// Token: 0x04015C7A RID: 89210
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B78B0D695_NativeFunctionPtr;

		// Token: 0x04015C7B RID: 89211
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C7C RID: 89212
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C7D RID: 89213
		private static IntPtr __ExecuteUbergraph_GA_Motor_Jump_xuli_NativeFunctionPtr;

		// Token: 0x0200A1CF RID: 41423
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F2C RID: 208684
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1D0 RID: 41424
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 808)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Jump_xuli_FunctionParams
		{
			// Token: 0x04032F2D RID: 208685
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
