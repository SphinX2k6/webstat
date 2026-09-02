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
	// Token: 0x02003FDA RID: 16346
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower1.GA_Motor_Lower1_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1504)]
	public class GA_Motor_Lower1_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060291CF RID: 168399 RVA: 0x00A21903 File Offset: 0x00A1FB03
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Motor_Lower1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower1.GA_Motor_Lower1_C");
			}
			return GA_Motor_Lower1_C._ClassPtr;
		}

		// Token: 0x060291D0 RID: 168400 RVA: 0x00A21928 File Offset: 0x00A1FB28
		public GA_Motor_Lower1_C() : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Lower1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060291D1 RID: 168401 RVA: 0x00A21950 File Offset: 0x00A1FB50
		[NullableContext(1)]
		public GA_Motor_Lower1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Motor_Lower1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700656A RID: 25962
		// (get) Token: 0x060291D2 RID: 168402 RVA: 0x00A21984 File Offset: 0x00A1FB84
		// (set) Token: 0x060291D3 RID: 168403 RVA: 0x00A219BD File Offset: 0x00A1FBBD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Motor_Lower1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Motor_Lower1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700656B RID: 25963
		// (get) Token: 0x060291D4 RID: 168404 RVA: 0x00A219DE File Offset: 0x00A1FBDE
		// (set) Token: 0x060291D5 RID: 168405 RVA: 0x00A219EE File Offset: 0x00A1FBEE
		public unsafe bool 是否主动结束
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Motor_Lower1_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Motor_Lower1_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700656C RID: 25964
		// (get) Token: 0x060291D6 RID: 168406 RVA: 0x00A219FF File Offset: 0x00A1FBFF
		// (set) Token: 0x060291D7 RID: 168407 RVA: 0x00A21A13 File Offset: 0x00A1FC13
		[Nullable(2)]
		public unsafe TsBaseCharacter 驾驶员
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Lower1_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GA_Motor_Lower1_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060291D8 RID: 168408 RVA: 0x00A21A28 File Offset: 0x00A1FC28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B94CC34F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnTick_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr, null);
		}

		// Token: 0x060291D9 RID: 168409 RVA: 0x00A21A3C File Offset: 0x00A1FC3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B94CC34F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr, null);
		}

		// Token: 0x060291DA RID: 168410 RVA: 0x00A21A50 File Offset: 0x00A1FC50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B94CC34F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr, null);
		}

		// Token: 0x060291DB RID: 168411 RVA: 0x00A21A64 File Offset: 0x00A1FC64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B94CC34F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr, null);
		}

		// Token: 0x060291DC RID: 168412 RVA: 0x00A21A78 File Offset: 0x00A1FC78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B94CC34F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr, null);
		}

		// Token: 0x060291DD RID: 168413 RVA: 0x00A21A8C File Offset: 0x00A1FC8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09B38B41609()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnTick_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr, null);
		}

		// Token: 0x060291DE RID: 168414 RVA: 0x00A21AA0 File Offset: 0x00A1FCA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09B38B41609()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnCancelled_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr, null);
		}

		// Token: 0x060291DF RID: 168415 RVA: 0x00A21AB4 File Offset: 0x00A1FCB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09B38B41609()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr, null);
		}

		// Token: 0x060291E0 RID: 168416 RVA: 0x00A21AC8 File Offset: 0x00A1FCC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09B38B41609()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr, null);
		}

		// Token: 0x060291E1 RID: 168417 RVA: 0x00A21ADC File Offset: 0x00A1FCDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09B38B41609()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnCompleted_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr, null);
		}

		// Token: 0x060291E2 RID: 168418 RVA: 0x00A21AF0 File Offset: 0x00A1FCF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3064A6454(in FGameplayTag Tag)
		{
			GA_Motor_Lower1_C.__Added_21071CB943CD992BF8EFD6A3064A6454_FunctionParams* ptr = stackalloc GA_Motor_Lower1_C.__Added_21071CB943CD992BF8EFD6A3064A6454_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Motor_Lower1_C.__Added_21071CB943CD992BF8EFD6A3064A6454_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower1_C.__Added_21071CB943CD992BF8EFD6A3064A6454_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__Added_21071CB943CD992BF8EFD6A3064A6454_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060291E3 RID: 168419 RVA: 0x00A21B3B File Offset: 0x00A1FD3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_CF946D5D4EFE5E5564EFF09BBCE39CA3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnTick_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr, null);
		}

		// Token: 0x060291E4 RID: 168420 RVA: 0x00A21B4F File Offset: 0x00A1FD4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_CF946D5D4EFE5E5564EFF09BBCE39CA3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnCancelled_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr, null);
		}

		// Token: 0x060291E5 RID: 168421 RVA: 0x00A21B63 File Offset: 0x00A1FD63
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_CF946D5D4EFE5E5564EFF09BBCE39CA3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnInterrupted_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr, null);
		}

		// Token: 0x060291E6 RID: 168422 RVA: 0x00A21B77 File Offset: 0x00A1FD77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_CF946D5D4EFE5E5564EFF09BBCE39CA3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnBlendOut_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr, null);
		}

		// Token: 0x060291E7 RID: 168423 RVA: 0x00A21B8B File Offset: 0x00A1FD8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_CF946D5D4EFE5E5564EFF09BBCE39CA3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__OnCompleted_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr, null);
		}

		// Token: 0x060291E8 RID: 168424 RVA: 0x00A21B9F File Offset: 0x00A1FD9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Motor_Lower1_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x060291E9 RID: 168425 RVA: 0x00A21BB3 File Offset: 0x00A1FDB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower1_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060291EA RID: 168426 RVA: 0x00A21BC8 File Offset: 0x00A1FDC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Motor_Lower1(int EntryPoint)
		{
			GA_Motor_Lower1_C.__ExecuteUbergraph_GA_Motor_Lower1_FunctionParams* ptr = stackalloc GA_Motor_Lower1_C.__ExecuteUbergraph_GA_Motor_Lower1_FunctionParams[(UIntPtr)1183] + 15L / (long)sizeof(GA_Motor_Lower1_C.__ExecuteUbergraph_GA_Motor_Lower1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Motor_Lower1_C.__ExecuteUbergraph_GA_Motor_Lower1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Motor_Lower1_C.__ExecuteUbergraph_GA_Motor_Lower1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060291EB RID: 168427 RVA: 0x00A21C12 File Offset: 0x00A1FE12
		protected GA_Motor_Lower1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015C93 RID: 89235
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/GA/GA_Motor_Lower1.GA_Motor_Lower1_C";

		// Token: 0x04015C94 RID: 89236
		private static IntPtr _ClassPtr;

		// Token: 0x04015C95 RID: 89237
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015C96 RID: 89238
		internal new static int __PropertyOffset_0;

		// Token: 0x04015C97 RID: 89239
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015C98 RID: 89240
		internal new static int __PropertyOffset_1;

		// Token: 0x04015C99 RID: 89241
		internal new static int __PropertyOffset_2;

		// Token: 0x04015C9A RID: 89242
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr;

		// Token: 0x04015C9B RID: 89243
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr;

		// Token: 0x04015C9C RID: 89244
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr;

		// Token: 0x04015C9D RID: 89245
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr;

		// Token: 0x04015C9E RID: 89246
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B94CC34F2_NativeFunctionPtr;

		// Token: 0x04015C9F RID: 89247
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr;

		// Token: 0x04015CA0 RID: 89248
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr;

		// Token: 0x04015CA1 RID: 89249
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr;

		// Token: 0x04015CA2 RID: 89250
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr;

		// Token: 0x04015CA3 RID: 89251
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09B38B41609_NativeFunctionPtr;

		// Token: 0x04015CA4 RID: 89252
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3064A6454_NativeFunctionPtr;

		// Token: 0x04015CA5 RID: 89253
		private static IntPtr __OnTick_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr;

		// Token: 0x04015CA6 RID: 89254
		private static IntPtr __OnCancelled_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr;

		// Token: 0x04015CA7 RID: 89255
		private static IntPtr __OnInterrupted_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr;

		// Token: 0x04015CA8 RID: 89256
		private static IntPtr __OnBlendOut_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr;

		// Token: 0x04015CA9 RID: 89257
		private static IntPtr __OnCompleted_CF946D5D4EFE5E5564EFF09BBCE39CA3_NativeFunctionPtr;

		// Token: 0x04015CAA RID: 89258
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04015CAB RID: 89259
		private static IntPtr __ExecuteUbergraph_GA_Motor_Lower1_NativeFunctionPtr;

		// Token: 0x0200A1D4 RID: 41428
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3064A6454_FunctionParams
		{
			// Token: 0x04032F31 RID: 208689
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A1D5 RID: 41429
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1168)]
		protected ref struct __ExecuteUbergraph_GA_Motor_Lower1_FunctionParams
		{
			// Token: 0x04032F32 RID: 208690
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
