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
	// Token: 0x02003FDB RID: 16347
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower.GA_Motor_Lower_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Motor_Lower_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060291EC RID: 168428 RVA: 0x00A21C1B File Offset: 0x00A1FE1B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Lower_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower.GA_Motor_Lower_C");
			}
			return GA_Motor_Lower_C._ClassPtr;
		}

		// Token: 0x060291ED RID: 168429 RVA: 0x00A21C40 File Offset: 0x00A1FE40
		public GA_Motor_Lower_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Lower_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060291EE RID: 168430 RVA: 0x00A21C68 File Offset: 0x00A1FE68
		[NullableContext(1)]
		public GA_Motor_Lower_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Lower_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700656D RID: 25965
		// (get) Token: 0x060291EF RID: 168431 RVA: 0x00A21C9C File Offset: 0x00A1FE9C
		// (set) Token: 0x060291F0 RID: 168432 RVA: 0x00A21CD5 File Offset: 0x00A1FED5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Lower_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Lower_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700656E RID: 25966
		// (get) Token: 0x060291F1 RID: 168433 RVA: 0x00A21CF6 File Offset: 0x00A1FEF6
		// (set) Token: 0x060291F2 RID: 168434 RVA: 0x00A21D06 File Offset: 0x00A1FF06
		public unsafe bool 是否主动结束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Lower_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Lower_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700656F RID: 25967
		// (get) Token: 0x060291F3 RID: 168435 RVA: 0x00A21D17 File Offset: 0x00A1FF17
		// (set) Token: 0x060291F4 RID: 168436 RVA: 0x00A21D2B File Offset: 0x00A1FF2B
		[Nullable(2)]
		public unsafe TsBaseCharacter 驾驶员
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Lower_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Lower_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060291F5 RID: 168437 RVA: 0x00A21D40 File Offset: 0x00A1FF40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B63C79509()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnTick_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr, null);
		}

		// Token: 0x060291F6 RID: 168438 RVA: 0x00A21D54 File Offset: 0x00A1FF54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B63C79509()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr, null);
		}

		// Token: 0x060291F7 RID: 168439 RVA: 0x00A21D68 File Offset: 0x00A1FF68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B63C79509()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr, null);
		}

		// Token: 0x060291F8 RID: 168440 RVA: 0x00A21D7C File Offset: 0x00A1FF7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B63C79509()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr, null);
		}

		// Token: 0x060291F9 RID: 168441 RVA: 0x00A21D90 File Offset: 0x00A1FF90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B63C79509()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr, null);
		}

		// Token: 0x060291FA RID: 168442 RVA: 0x00A21DA4 File Offset: 0x00A1FFA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B180B4D49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnTick_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr, null);
		}

		// Token: 0x060291FB RID: 168443 RVA: 0x00A21DB8 File Offset: 0x00A1FFB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B180B4D49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr, null);
		}

		// Token: 0x060291FC RID: 168444 RVA: 0x00A21DCC File Offset: 0x00A1FFCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B180B4D49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr, null);
		}

		// Token: 0x060291FD RID: 168445 RVA: 0x00A21DE0 File Offset: 0x00A1FFE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B180B4D49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr, null);
		}

		// Token: 0x060291FE RID: 168446 RVA: 0x00A21DF4 File Offset: 0x00A1FFF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B180B4D49()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr, null);
		}

		// Token: 0x060291FF RID: 168447 RVA: 0x00A21E08 File Offset: 0x00A20008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3DA4D25FB(in FGameplayTag Tag)
		{
			GA_Motor_Lower_C.__Added_21071CB943CD992BF8EFD6A3DA4D25FB_FunctionParams* ptr = stackalloc GA_Motor_Lower_C.__Added_21071CB943CD992BF8EFD6A3DA4D25FB_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_Lower_C.__Added_21071CB943CD992BF8EFD6A3DA4D25FB_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_C.__Added_21071CB943CD992BF8EFD6A3DA4D25FB_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__Added_21071CB943CD992BF8EFD6A3DA4D25FB_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06029200 RID: 168448 RVA: 0x00A21E53 File Offset: 0x00A20053
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B5BC82BB6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnTick_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr, null);
		}

		// Token: 0x06029201 RID: 168449 RVA: 0x00A21E67 File Offset: 0x00A20067
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B5BC82BB6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr, null);
		}

		// Token: 0x06029202 RID: 168450 RVA: 0x00A21E7B File Offset: 0x00A2007B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B5BC82BB6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr, null);
		}

		// Token: 0x06029203 RID: 168451 RVA: 0x00A21E8F File Offset: 0x00A2008F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B5BC82BB6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr, null);
		}

		// Token: 0x06029204 RID: 168452 RVA: 0x00A21EA3 File Offset: 0x00A200A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B5BC82BB6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr, null);
		}

		// Token: 0x06029205 RID: 168453 RVA: 0x00A21EB7 File Offset: 0x00A200B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BF18DAD51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnTick_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr, null);
		}

		// Token: 0x06029206 RID: 168454 RVA: 0x00A21ECB File Offset: 0x00A200CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BF18DAD51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr, null);
		}

		// Token: 0x06029207 RID: 168455 RVA: 0x00A21EDF File Offset: 0x00A200DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BF18DAD51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr, null);
		}

		// Token: 0x06029208 RID: 168456 RVA: 0x00A21EF3 File Offset: 0x00A200F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BF18DAD51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr, null);
		}

		// Token: 0x06029209 RID: 168457 RVA: 0x00A21F07 File Offset: 0x00A20107
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BF18DAD51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr, null);
		}

		// Token: 0x0602920A RID: 168458 RVA: 0x00A21F1B File Offset: 0x00A2011B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602920B RID: 168459 RVA: 0x00A21F2F File Offset: 0x00A2012F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602920C RID: 168460 RVA: 0x00A21F44 File Offset: 0x00A20144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Motor_Lower_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Lower_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Lower_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602920D RID: 168461 RVA: 0x00A21F8C File Offset: 0x00A2018C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Motor_Lower_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Motor_Lower_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Motor_Lower_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602920E RID: 168462 RVA: 0x00A21FD4 File Offset: 0x00A201D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Lower(int EntryPoint)
		{
			GA_Motor_Lower_C.__ExecuteUbergraph_GA_Motor_Lower_FunctionParams* ptr = stackalloc GA_Motor_Lower_C.__ExecuteUbergraph_GA_Motor_Lower_FunctionParams[(UIntPtr)1487] + 15L / (long)sizeof(GA_Motor_Lower_C.__ExecuteUbergraph_GA_Motor_Lower_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower_C.__ExecuteUbergraph_GA_Motor_Lower_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower_C.__ExecuteUbergraph_GA_Motor_Lower_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602920F RID: 168463 RVA: 0x00A2201E File Offset: 0x00A2021E
		protected GA_Motor_Lower_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015CAC RID: 89260
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower.GA_Motor_Lower_C";

		// Token: 0x04015CAD RID: 89261
		private static IntPtr _ClassPtr;

		// Token: 0x04015CAE RID: 89262
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015CAF RID: 89263
		internal new static int __PropertyOffset_0;

		// Token: 0x04015CB0 RID: 89264
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015CB1 RID: 89265
		internal new static int __PropertyOffset_1;

		// Token: 0x04015CB2 RID: 89266
		internal new static int __PropertyOffset_2;

		// Token: 0x04015CB3 RID: 89267
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr;

		// Token: 0x04015CB4 RID: 89268
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr;

		// Token: 0x04015CB5 RID: 89269
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr;

		// Token: 0x04015CB6 RID: 89270
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr;

		// Token: 0x04015CB7 RID: 89271
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B63C79509_NativeFunctionPtr;

		// Token: 0x04015CB8 RID: 89272
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr;

		// Token: 0x04015CB9 RID: 89273
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr;

		// Token: 0x04015CBA RID: 89274
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr;

		// Token: 0x04015CBB RID: 89275
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr;

		// Token: 0x04015CBC RID: 89276
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B180B4D49_NativeFunctionPtr;

		// Token: 0x04015CBD RID: 89277
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3DA4D25FB_NativeFunctionPtr;

		// Token: 0x04015CBE RID: 89278
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr;

		// Token: 0x04015CBF RID: 89279
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr;

		// Token: 0x04015CC0 RID: 89280
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr;

		// Token: 0x04015CC1 RID: 89281
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr;

		// Token: 0x04015CC2 RID: 89282
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B5BC82BB6_NativeFunctionPtr;

		// Token: 0x04015CC3 RID: 89283
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr;

		// Token: 0x04015CC4 RID: 89284
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr;

		// Token: 0x04015CC5 RID: 89285
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr;

		// Token: 0x04015CC6 RID: 89286
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr;

		// Token: 0x04015CC7 RID: 89287
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BF18DAD51_NativeFunctionPtr;

		// Token: 0x04015CC8 RID: 89288
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015CC9 RID: 89289
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04015CCA RID: 89290
		private static IntPtr __ExecuteUbergraph_GA_Motor_Lower_NativeFunctionPtr;

		// Token: 0x0200A1D6 RID: 41430
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3DA4D25FB_FunctionParams
		{
			// Token: 0x04032F33 RID: 208691
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1D7 RID: 41431
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04032F34 RID: 208692
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A1D8 RID: 41432
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1472)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Lower_FunctionParams
		{
			// Token: 0x04032F35 RID: 208693
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
