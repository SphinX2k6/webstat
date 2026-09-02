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
	// Token: 0x020040C8 RID: 16584
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New.GA_Super_Sprint_Start_New_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1493)]
	public class GA_Super_Sprint_Start_New_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B5A6 RID: 177574 RVA: 0x00A79287 File Offset: 0x00A77487
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_New_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New.GA_Super_Sprint_Start_New_C");
			}
			return GA_Super_Sprint_Start_New_C._ClassPtr;
		}

		// Token: 0x0602B5A7 RID: 177575 RVA: 0x00A792AC File Offset: 0x00A774AC
		public GA_Super_Sprint_Start_New_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B5A8 RID: 177576 RVA: 0x00A792D4 File Offset: 0x00A774D4
		[NullableContext(1)]
		public GA_Super_Sprint_Start_New_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700718C RID: 29068
		// (get) Token: 0x0602B5A9 RID: 177577 RVA: 0x00A79308 File Offset: 0x00A77508
		// (set) Token: 0x0602B5AA RID: 177578 RVA: 0x00A79341 File Offset: 0x00A77541
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700718D RID: 29069
		// (get) Token: 0x0602B5AB RID: 177579 RVA: 0x00A79362 File Offset: 0x00A77562
		// (set) Token: 0x0602B5AC RID: 177580 RVA: 0x00A79372 File Offset: 0x00A77572
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700718E RID: 29070
		// (get) Token: 0x0602B5AD RID: 177581 RVA: 0x00A79383 File Offset: 0x00A77583
		// (set) Token: 0x0602B5AE RID: 177582 RVA: 0x00A79393 File Offset: 0x00A77593
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700718F RID: 29071
		// (get) Token: 0x0602B5AF RID: 177583 RVA: 0x00A793A4 File Offset: 0x00A775A4
		// (set) Token: 0x0602B5B0 RID: 177584 RVA: 0x00A793B4 File Offset: 0x00A775B4
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007190 RID: 29072
		// (get) Token: 0x0602B5B1 RID: 177585 RVA: 0x00A793C5 File Offset: 0x00A775C5
		// (set) Token: 0x0602B5B2 RID: 177586 RVA: 0x00A793D5 File Offset: 0x00A775D5
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007191 RID: 29073
		// (get) Token: 0x0602B5B3 RID: 177587 RVA: 0x00A793E6 File Offset: 0x00A775E6
		// (set) Token: 0x0602B5B4 RID: 177588 RVA: 0x00A793F6 File Offset: 0x00A775F6
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B5B5 RID: 177589 RVA: 0x00A79408 File Offset: 0x00A77608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3ABA4E8BA(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3ABA4E8BA_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3ABA4E8BA_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3ABA4E8BA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3ABA4E8BA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3ABA4E8BA_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5B6 RID: 177590 RVA: 0x00A79454 File Offset: 0x00A77654
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A36D1729A6(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A36D1729A6_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A36D1729A6_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A36D1729A6_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A36D1729A6_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A36D1729A6_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5B7 RID: 177591 RVA: 0x00A794A0 File Offset: 0x00A776A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3D35827D4(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3D35827D4_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3D35827D4_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3D35827D4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3D35827D4_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__Added_21071CB943CD992BF8EFD6A3D35827D4_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5B8 RID: 177592 RVA: 0x00A794EC File Offset: 0x00A776EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381BBB8A764(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_C.__Removed_DB9F64004F8908FEAD99D381BBB8A764_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__Removed_DB9F64004F8908FEAD99D381BBB8A764_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__Removed_DB9F64004F8908FEAD99D381BBB8A764_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__Removed_DB9F64004F8908FEAD99D381BBB8A764_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__Removed_DB9F64004F8908FEAD99D381BBB8A764_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5B9 RID: 177593 RVA: 0x00A79537 File Offset: 0x00A77737
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_9932D03940BD5B03E1B0449BB2547021()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__OnFinish_9932D03940BD5B03E1B0449BB2547021_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5BA RID: 177594 RVA: 0x00A7954B File Offset: 0x00A7774B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E819A8C94F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__OnTick_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5BB RID: 177595 RVA: 0x00A7955F File Offset: 0x00A7775F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E819A8C94F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__OnCancelled_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5BC RID: 177596 RVA: 0x00A79573 File Offset: 0x00A77773
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E819A8C94F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__OnInterrupted_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5BD RID: 177597 RVA: 0x00A79587 File Offset: 0x00A77787
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E819A8C94F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__OnBlendOut_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5BE RID: 177598 RVA: 0x00A7959B File Offset: 0x00A7779B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E819A8C94F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__OnCompleted_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5BF RID: 177599 RVA: 0x00A795AF File Offset: 0x00A777AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5C0 RID: 177600 RVA: 0x00A795C3 File Offset: 0x00A777C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B5C1 RID: 177601 RVA: 0x00A795D8 File Offset: 0x00A777D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5C2 RID: 177602 RVA: 0x00A79620 File Offset: 0x00A77820
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B5C3 RID: 177603 RVA: 0x00A79668 File Offset: 0x00A77868
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start_New(int EntryPoint)
		{
			GA_Super_Sprint_Start_New_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_FunctionParams[(UIntPtr)1727] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B5C4 RID: 177604 RVA: 0x00A796B2 File Offset: 0x00A778B2
		protected GA_Super_Sprint_Start_New_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C43 RID: 97347
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New.GA_Super_Sprint_Start_New_C";

		// Token: 0x04017C44 RID: 97348
		private static IntPtr _ClassPtr;

		// Token: 0x04017C45 RID: 97349
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C46 RID: 97350
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C47 RID: 97351
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C48 RID: 97352
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C49 RID: 97353
		internal new static int __PropertyOffset_2;

		// Token: 0x04017C4A RID: 97354
		internal new static int __PropertyOffset_3;

		// Token: 0x04017C4B RID: 97355
		internal static int __PropertyOffset_4;

		// Token: 0x04017C4C RID: 97356
		internal static int __PropertyOffset_5;

		// Token: 0x04017C4D RID: 97357
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3ABA4E8BA_NativeFunctionPtr;

		// Token: 0x04017C4E RID: 97358
		private static IntPtr __Added_21071CB943CD992BF8EFD6A36D1729A6_NativeFunctionPtr;

		// Token: 0x04017C4F RID: 97359
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3D35827D4_NativeFunctionPtr;

		// Token: 0x04017C50 RID: 97360
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381BBB8A764_NativeFunctionPtr;

		// Token: 0x04017C51 RID: 97361
		private static IntPtr __OnFinish_9932D03940BD5B03E1B0449BB2547021_NativeFunctionPtr;

		// Token: 0x04017C52 RID: 97362
		private static IntPtr __OnTick_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr;

		// Token: 0x04017C53 RID: 97363
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr;

		// Token: 0x04017C54 RID: 97364
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr;

		// Token: 0x04017C55 RID: 97365
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr;

		// Token: 0x04017C56 RID: 97366
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E819A8C94F3_NativeFunctionPtr;

		// Token: 0x04017C57 RID: 97367
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C58 RID: 97368
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C59 RID: 97369
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_New_NativeFunctionPtr;

		// Token: 0x0200A385 RID: 41861
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3ABA4E8BA_FunctionParams
		{
			// Token: 0x04033162 RID: 209250
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A386 RID: 41862
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A36D1729A6_FunctionParams
		{
			// Token: 0x04033163 RID: 209251
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A387 RID: 41863
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3D35827D4_FunctionParams
		{
			// Token: 0x04033164 RID: 209252
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A388 RID: 41864
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381BBB8A764_FunctionParams
		{
			// Token: 0x04033165 RID: 209253
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A389 RID: 41865
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033166 RID: 209254
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A38A RID: 41866
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1712)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_New_FunctionParams
		{
			// Token: 0x04033167 RID: 209255
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
