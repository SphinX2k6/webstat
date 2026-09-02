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
	// Token: 0x02003FD9 RID: 16345
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Kite.GA_Motor_Kite_C")]
	[UnrealStructLayout(1520, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1520)]
	public class GA_Motor_Kite_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060291B1 RID: 168369 RVA: 0x00A2157F File Offset: 0x00A1F77F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Kite_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Kite.GA_Motor_Kite_C");
			}
			return GA_Motor_Kite_C._ClassPtr;
		}

		// Token: 0x060291B2 RID: 168370 RVA: 0x00A215A4 File Offset: 0x00A1F7A4
		public GA_Motor_Kite_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Kite_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060291B3 RID: 168371 RVA: 0x00A215CC File Offset: 0x00A1F7CC
		[NullableContext(1)]
		public GA_Motor_Kite_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Kite_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006563 RID: 25955
		// (get) Token: 0x060291B4 RID: 168372 RVA: 0x00A21600 File Offset: 0x00A1F800
		// (set) Token: 0x060291B5 RID: 168373 RVA: 0x00A21639 File Offset: 0x00A1F839
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006564 RID: 25956
		// (get) Token: 0x060291B6 RID: 168374 RVA: 0x00A2165A File Offset: 0x00A1F85A
		// (set) Token: 0x060291B7 RID: 168375 RVA: 0x00A2166E File Offset: 0x00A1F86E
		public unsafe AActor 被控物
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Kite_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Kite_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006565 RID: 25957
		// (get) Token: 0x060291B8 RID: 168376 RVA: 0x00A21683 File Offset: 0x00A1F883
		// (set) Token: 0x060291B9 RID: 168377 RVA: 0x00A21697 File Offset: 0x00A1F897
		public unsafe TsBaseVehicle 施法载具
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseVehicle>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Kite_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Kite_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17006566 RID: 25958
		// (get) Token: 0x060291BA RID: 168378 RVA: 0x00A216AC File Offset: 0x00A1F8AC
		// (set) Token: 0x060291BB RID: 168379 RVA: 0x00A216BC File Offset: 0x00A1F8BC
		public unsafe int 驾驶员EntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006567 RID: 25959
		// (get) Token: 0x060291BC RID: 168380 RVA: 0x00A216CD File Offset: 0x00A1F8CD
		// (set) Token: 0x060291BD RID: 168381 RVA: 0x00A216DD File Offset: 0x00A1F8DD
		public unsafe int 钩锁Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006568 RID: 25960
		// (get) Token: 0x060291BE RID: 168382 RVA: 0x00A216EE File Offset: 0x00A1F8EE
		// (set) Token: 0x060291BF RID: 168383 RVA: 0x00A216FE File Offset: 0x00A1F8FE
		public unsafe bool IsStartGetOff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006569 RID: 25961
		// (get) Token: 0x060291C0 RID: 168384 RVA: 0x00A2170F File Offset: 0x00A1F90F
		// (set) Token: 0x060291C1 RID: 168385 RVA: 0x00A2171F File Offset: 0x00A1F91F
		public unsafe int 载具EntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Kite_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x060291C2 RID: 168386 RVA: 0x00A21730 File Offset: 0x00A1F930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InterruptHookSkill()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__InterruptHookSkill_NativeFunctionPtr, null);
		}

		// Token: 0x060291C3 RID: 168387 RVA: 0x00A21744 File Offset: 0x00A1F944
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Init(ref bool InitSuccess)
		{
			GA_Motor_Kite_C.__Init_FunctionParams* ptr = stackalloc GA_Motor_Kite_C.__Init_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(GA_Motor_Kite_C.__Init_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Kite_C.__Init_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InitSuccess = InitSuccess;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__Init_NativeFunctionPtr, (void*)ptr);
			InitSuccess = ptr->InitSuccess;
		}

		// Token: 0x060291C4 RID: 168388 RVA: 0x00A21793 File Offset: 0x00A1F993
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BC6114B3E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__OnTick_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr, null);
		}

		// Token: 0x060291C5 RID: 168389 RVA: 0x00A217A7 File Offset: 0x00A1F9A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BC6114B3E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr, null);
		}

		// Token: 0x060291C6 RID: 168390 RVA: 0x00A217BB File Offset: 0x00A1F9BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BC6114B3E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr, null);
		}

		// Token: 0x060291C7 RID: 168391 RVA: 0x00A217CF File Offset: 0x00A1F9CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BC6114B3E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr, null);
		}

		// Token: 0x060291C8 RID: 168392 RVA: 0x00A217E3 File Offset: 0x00A1F9E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BC6114B3E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr, null);
		}

		// Token: 0x060291C9 RID: 168393 RVA: 0x00A217F7 File Offset: 0x00A1F9F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060291CA RID: 168394 RVA: 0x00A2180B File Offset: 0x00A1FA0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Kite_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060291CB RID: 168395 RVA: 0x00A21820 File Offset: 0x00A1FA20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Kite_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Kite_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Kite_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060291CC RID: 168396 RVA: 0x00A21868 File Offset: 0x00A1FA68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Kite_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Kite_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Kite_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Kite_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060291CD RID: 168397 RVA: 0x00A218B0 File Offset: 0x00A1FAB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Kite(int EntryPoint)
		{
			GA_Motor_Kite_C.__ExecuteUbergraph_GA_Motor_Kite_FunctionParams* ptr = stackalloc GA_Motor_Kite_C.__ExecuteUbergraph_GA_Motor_Kite_FunctionParams[(UIntPtr)391] + 15L / (long)sizeof(GA_Motor_Kite_C.__ExecuteUbergraph_GA_Motor_Kite_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Kite_C.__ExecuteUbergraph_GA_Motor_Kite_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Kite_C.__ExecuteUbergraph_GA_Motor_Kite_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060291CE RID: 168398 RVA: 0x00A218FA File Offset: 0x00A1FAFA
		protected GA_Motor_Kite_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C7E RID: 89214
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Kite.GA_Motor_Kite_C";

		// Token: 0x04015C7F RID: 89215
		private static IntPtr _ClassPtr;

		// Token: 0x04015C80 RID: 89216
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C81 RID: 89217
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C82 RID: 89218
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C83 RID: 89219
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C84 RID: 89220
		internal new static int __PropertyOffset_2;

		// Token: 0x04015C85 RID: 89221
		internal new static int __PropertyOffset_3;

		// Token: 0x04015C86 RID: 89222
		internal static int __PropertyOffset_4;

		// Token: 0x04015C87 RID: 89223
		internal static int __PropertyOffset_5;

		// Token: 0x04015C88 RID: 89224
		internal static int __PropertyOffset_6;

		// Token: 0x04015C89 RID: 89225
		private static IntPtr __InterruptHookSkill_NativeFunctionPtr;

		// Token: 0x04015C8A RID: 89226
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x04015C8B RID: 89227
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr;

		// Token: 0x04015C8C RID: 89228
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr;

		// Token: 0x04015C8D RID: 89229
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr;

		// Token: 0x04015C8E RID: 89230
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr;

		// Token: 0x04015C8F RID: 89231
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BC6114B3E_NativeFunctionPtr;

		// Token: 0x04015C90 RID: 89232
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015C91 RID: 89233
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015C92 RID: 89234
		private static IntPtr __ExecuteUbergraph_GA_Motor_Kite_NativeFunctionPtr;

		// Token: 0x0200A1D1 RID: 41425
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Init_FunctionParams
		{
			// Token: 0x04032F2E RID: 208686
			[FieldOffset(0)]
			public bool InitSuccess;
		}

		// Token: 0x0200A1D2 RID: 41426
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F2F RID: 208687
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1D3 RID: 41427
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 376)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Kite_FunctionParams
		{
			// Token: 0x04032F30 RID: 208688
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
