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
	// Token: 0x020040C3 RID: 16579
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Loop_New.GA_Super_Sprint_Loop_New_C")]
	[UnrealStructLayout(1504, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1499)]
	public class GA_Super_Sprint_Loop_New_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B527 RID: 177447 RVA: 0x00A7808B File Offset: 0x00A7628B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Loop_New_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Loop_New.GA_Super_Sprint_Loop_New_C");
			}
			return GA_Super_Sprint_Loop_New_C._ClassPtr;
		}

		// Token: 0x0602B528 RID: 177448 RVA: 0x00A780B0 File Offset: 0x00A762B0
		public GA_Super_Sprint_Loop_New_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Loop_New_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B529 RID: 177449 RVA: 0x00A780D8 File Offset: 0x00A762D8
		[NullableContext(1)]
		public GA_Super_Sprint_Loop_New_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Loop_New_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007176 RID: 29046
		// (get) Token: 0x0602B52A RID: 177450 RVA: 0x00A7810C File Offset: 0x00A7630C
		// (set) Token: 0x0602B52B RID: 177451 RVA: 0x00A78145 File Offset: 0x00A76345
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007177 RID: 29047
		// (get) Token: 0x0602B52C RID: 177452 RVA: 0x00A78166 File Offset: 0x00A76366
		// (set) Token: 0x0602B52D RID: 177453 RVA: 0x00A78176 File Offset: 0x00A76376
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007178 RID: 29048
		// (get) Token: 0x0602B52E RID: 177454 RVA: 0x00A78187 File Offset: 0x00A76387
		// (set) Token: 0x0602B52F RID: 177455 RVA: 0x00A78197 File Offset: 0x00A76397
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007179 RID: 29049
		// (get) Token: 0x0602B530 RID: 177456 RVA: 0x00A781A8 File Offset: 0x00A763A8
		// (set) Token: 0x0602B531 RID: 177457 RVA: 0x00A781B8 File Offset: 0x00A763B8
		public unsafe float Block_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700717A RID: 29050
		// (get) Token: 0x0602B532 RID: 177458 RVA: 0x00A781C9 File Offset: 0x00A763C9
		// (set) Token: 0x0602B533 RID: 177459 RVA: 0x00A781D9 File Offset: 0x00A763D9
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700717B RID: 29051
		// (get) Token: 0x0602B534 RID: 177460 RVA: 0x00A781EA File Offset: 0x00A763EA
		// (set) Token: 0x0602B535 RID: 177461 RVA: 0x00A781FA File Offset: 0x00A763FA
		public unsafe bool 是否结束技能了
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700717C RID: 29052
		// (get) Token: 0x0602B536 RID: 177462 RVA: 0x00A7820B File Offset: 0x00A7640B
		// (set) Token: 0x0602B537 RID: 177463 RVA: 0x00A7821B File Offset: 0x00A7641B
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_New_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B538 RID: 177464 RVA: 0x00A7822C File Offset: 0x00A7642C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3812D7418C1(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_New_C.__Removed_DB9F64004F8908FEAD99D3812D7418C1_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__Removed_DB9F64004F8908FEAD99D3812D7418C1_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__Removed_DB9F64004F8908FEAD99D3812D7418C1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__Removed_DB9F64004F8908FEAD99D3812D7418C1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__Removed_DB9F64004F8908FEAD99D3812D7418C1_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B539 RID: 177465 RVA: 0x00A78278 File Offset: 0x00A76478
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3660641A9(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3660641A9_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3660641A9_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3660641A9_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3660641A9_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3660641A9_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B53A RID: 177466 RVA: 0x00A782C4 File Offset: 0x00A764C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3351F4890(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3351F4890_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3351F4890_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3351F4890_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3351F4890_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3351F4890_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B53B RID: 177467 RVA: 0x00A78310 File Offset: 0x00A76510
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3E39B5E03(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3E39B5E03_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3E39B5E03_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3E39B5E03_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3E39B5E03_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__Added_21071CB943CD992BF8EFD6A3E39B5E03_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B53C RID: 177468 RVA: 0x00A7835B File Offset: 0x00A7655B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_97D0EE2E47EAF7034F36A28B119A294B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__OnFinish_97D0EE2E47EAF7034F36A28B119A294B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B53D RID: 177469 RVA: 0x00A7836F File Offset: 0x00A7656F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8100791CD4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__OnTick_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B53E RID: 177470 RVA: 0x00A78383 File Offset: 0x00A76583
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8100791CD4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__OnCancelled_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B53F RID: 177471 RVA: 0x00A78397 File Offset: 0x00A76597
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8100791CD4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__OnInterrupted_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B540 RID: 177472 RVA: 0x00A783AB File Offset: 0x00A765AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8100791CD4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__OnBlendOut_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B541 RID: 177473 RVA: 0x00A783BF File Offset: 0x00A765BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8100791CD4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__OnCompleted_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr, null);
		}

		// Token: 0x0602B542 RID: 177474 RVA: 0x00A783D3 File Offset: 0x00A765D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B543 RID: 177475 RVA: 0x00A783E7 File Offset: 0x00A765E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B544 RID: 177476 RVA: 0x00A783FC File Offset: 0x00A765FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B545 RID: 177477 RVA: 0x00A78444 File Offset: 0x00A76644
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B546 RID: 177478 RVA: 0x00A7848C File Offset: 0x00A7668C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Loop_New(int EntryPoint)
		{
			GA_Super_Sprint_Loop_New_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_New_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_New_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_New_FunctionParams[(UIntPtr)1231] + 15L / (long)sizeof(GA_Super_Sprint_Loop_New_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_New_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_New_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_New_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Loop_New_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_New_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B547 RID: 177479 RVA: 0x00A784D6 File Offset: 0x00A766D6
		protected GA_Super_Sprint_Loop_New_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017BE3 RID: 97251
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Loop_New.GA_Super_Sprint_Loop_New_C";

		// Token: 0x04017BE4 RID: 97252
		private static IntPtr _ClassPtr;

		// Token: 0x04017BE5 RID: 97253
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017BE6 RID: 97254
		internal new static int __PropertyOffset_0;

		// Token: 0x04017BE7 RID: 97255
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017BE8 RID: 97256
		internal new static int __PropertyOffset_1;

		// Token: 0x04017BE9 RID: 97257
		internal new static int __PropertyOffset_2;

		// Token: 0x04017BEA RID: 97258
		internal new static int __PropertyOffset_3;

		// Token: 0x04017BEB RID: 97259
		internal static int __PropertyOffset_4;

		// Token: 0x04017BEC RID: 97260
		internal static int __PropertyOffset_5;

		// Token: 0x04017BED RID: 97261
		internal static int __PropertyOffset_6;

		// Token: 0x04017BEE RID: 97262
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3812D7418C1_NativeFunctionPtr;

		// Token: 0x04017BEF RID: 97263
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3660641A9_NativeFunctionPtr;

		// Token: 0x04017BF0 RID: 97264
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3351F4890_NativeFunctionPtr;

		// Token: 0x04017BF1 RID: 97265
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3E39B5E03_NativeFunctionPtr;

		// Token: 0x04017BF2 RID: 97266
		private static IntPtr __OnFinish_97D0EE2E47EAF7034F36A28B119A294B_NativeFunctionPtr;

		// Token: 0x04017BF3 RID: 97267
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr;

		// Token: 0x04017BF4 RID: 97268
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr;

		// Token: 0x04017BF5 RID: 97269
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr;

		// Token: 0x04017BF6 RID: 97270
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr;

		// Token: 0x04017BF7 RID: 97271
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8100791CD4_NativeFunctionPtr;

		// Token: 0x04017BF8 RID: 97272
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017BF9 RID: 97273
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017BFA RID: 97274
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Loop_New_NativeFunctionPtr;

		// Token: 0x0200A36B RID: 41835
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3812D7418C1_FunctionParams
		{
			// Token: 0x04033148 RID: 209224
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A36C RID: 41836
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3660641A9_FunctionParams
		{
			// Token: 0x04033149 RID: 209225
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A36D RID: 41837
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3351F4890_FunctionParams
		{
			// Token: 0x0403314A RID: 209226
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A36E RID: 41838
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3E39B5E03_FunctionParams
		{
			// Token: 0x0403314B RID: 209227
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A36F RID: 41839
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403314C RID: 209228
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A370 RID: 41840
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1216)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Loop_New_FunctionParams
		{
			// Token: 0x0403314D RID: 209229
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
