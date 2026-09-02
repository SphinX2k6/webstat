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
	// Token: 0x020040C6 RID: 16582
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_2.GA_Super_Sprint_Start_New_2_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1493)]
	public class GA_Super_Sprint_Start_New_2_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B568 RID: 177512 RVA: 0x00A78A1F File Offset: 0x00A76C1F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_New_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_2.GA_Super_Sprint_Start_New_2_C");
			}
			return GA_Super_Sprint_Start_New_2_C._ClassPtr;
		}

		// Token: 0x0602B569 RID: 177513 RVA: 0x00A78A44 File Offset: 0x00A76C44
		public GA_Super_Sprint_Start_New_2_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B56A RID: 177514 RVA: 0x00A78A6C File Offset: 0x00A76C6C
		[NullableContext(1)]
		public GA_Super_Sprint_Start_New_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007180 RID: 29056
		// (get) Token: 0x0602B56B RID: 177515 RVA: 0x00A78AA0 File Offset: 0x00A76CA0
		// (set) Token: 0x0602B56C RID: 177516 RVA: 0x00A78AD9 File Offset: 0x00A76CD9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007181 RID: 29057
		// (get) Token: 0x0602B56D RID: 177517 RVA: 0x00A78AFA File Offset: 0x00A76CFA
		// (set) Token: 0x0602B56E RID: 177518 RVA: 0x00A78B0A File Offset: 0x00A76D0A
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007182 RID: 29058
		// (get) Token: 0x0602B56F RID: 177519 RVA: 0x00A78B1B File Offset: 0x00A76D1B
		// (set) Token: 0x0602B570 RID: 177520 RVA: 0x00A78B2B File Offset: 0x00A76D2B
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007183 RID: 29059
		// (get) Token: 0x0602B571 RID: 177521 RVA: 0x00A78B3C File Offset: 0x00A76D3C
		// (set) Token: 0x0602B572 RID: 177522 RVA: 0x00A78B4C File Offset: 0x00A76D4C
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007184 RID: 29060
		// (get) Token: 0x0602B573 RID: 177523 RVA: 0x00A78B5D File Offset: 0x00A76D5D
		// (set) Token: 0x0602B574 RID: 177524 RVA: 0x00A78B6D File Offset: 0x00A76D6D
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007185 RID: 29061
		// (get) Token: 0x0602B575 RID: 177525 RVA: 0x00A78B7E File Offset: 0x00A76D7E
		// (set) Token: 0x0602B576 RID: 177526 RVA: 0x00A78B8E File Offset: 0x00A76D8E
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B577 RID: 177527 RVA: 0x00A78BA0 File Offset: 0x00A76DA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A39F07CCF8(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A39F07CCF8_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A39F07CCF8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A39F07CCF8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A39F07CCF8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A39F07CCF8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B578 RID: 177528 RVA: 0x00A78BEC File Offset: 0x00A76DEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A30C14F14A(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A30C14F14A_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A30C14F14A_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A30C14F14A_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A30C14F14A_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A30C14F14A_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B579 RID: 177529 RVA: 0x00A78C38 File Offset: 0x00A76E38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A38B48ED17(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A38B48ED17_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A38B48ED17_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A38B48ED17_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A38B48ED17_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__Added_21071CB943CD992BF8EFD6A38B48ED17_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B57A RID: 177530 RVA: 0x00A78C84 File Offset: 0x00A76E84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38157E69CDD(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_C.__Removed_DB9F64004F8908FEAD99D38157E69CDD_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__Removed_DB9F64004F8908FEAD99D38157E69CDD_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__Removed_DB9F64004F8908FEAD99D38157E69CDD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__Removed_DB9F64004F8908FEAD99D38157E69CDD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__Removed_DB9F64004F8908FEAD99D38157E69CDD_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B57B RID: 177531 RVA: 0x00A78CCF File Offset: 0x00A76ECF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_27CE4A214AF5F4C1386490B4DC5B38BD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__OnFinish_27CE4A214AF5F4C1386490B4DC5B38BD_NativeFunctionPtr, null);
		}

		// Token: 0x0602B57C RID: 177532 RVA: 0x00A78CE3 File Offset: 0x00A76EE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81C2BEF4CE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__OnTick_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr, null);
		}

		// Token: 0x0602B57D RID: 177533 RVA: 0x00A78CF7 File Offset: 0x00A76EF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81C2BEF4CE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__OnCancelled_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr, null);
		}

		// Token: 0x0602B57E RID: 177534 RVA: 0x00A78D0B File Offset: 0x00A76F0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81C2BEF4CE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__OnInterrupted_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr, null);
		}

		// Token: 0x0602B57F RID: 177535 RVA: 0x00A78D1F File Offset: 0x00A76F1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81C2BEF4CE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__OnBlendOut_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr, null);
		}

		// Token: 0x0602B580 RID: 177536 RVA: 0x00A78D33 File Offset: 0x00A76F33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81C2BEF4CE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__OnCompleted_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr, null);
		}

		// Token: 0x0602B581 RID: 177537 RVA: 0x00A78D47 File Offset: 0x00A76F47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B582 RID: 177538 RVA: 0x00A78D5B File Offset: 0x00A76F5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B583 RID: 177539 RVA: 0x00A78D70 File Offset: 0x00A76F70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B584 RID: 177540 RVA: 0x00A78DB8 File Offset: 0x00A76FB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B585 RID: 177541 RVA: 0x00A78E00 File Offset: 0x00A77000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start_New_2(int EntryPoint)
		{
			GA_Super_Sprint_Start_New_2_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_FunctionParams[(UIntPtr)1727] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B586 RID: 177542 RVA: 0x00A78E4A File Offset: 0x00A7704A
		protected GA_Super_Sprint_Start_New_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C15 RID: 97301
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_2.GA_Super_Sprint_Start_New_2_C";

		// Token: 0x04017C16 RID: 97302
		private static IntPtr _ClassPtr;

		// Token: 0x04017C17 RID: 97303
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C18 RID: 97304
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C19 RID: 97305
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C1A RID: 97306
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C1B RID: 97307
		internal new static int __PropertyOffset_2;

		// Token: 0x04017C1C RID: 97308
		internal new static int __PropertyOffset_3;

		// Token: 0x04017C1D RID: 97309
		internal static int __PropertyOffset_4;

		// Token: 0x04017C1E RID: 97310
		internal static int __PropertyOffset_5;

		// Token: 0x04017C1F RID: 97311
		private static IntPtr __Added_21071CB943CD992BF8EFD6A39F07CCF8_NativeFunctionPtr;

		// Token: 0x04017C20 RID: 97312
		private static IntPtr __Added_21071CB943CD992BF8EFD6A30C14F14A_NativeFunctionPtr;

		// Token: 0x04017C21 RID: 97313
		private static IntPtr __Added_21071CB943CD992BF8EFD6A38B48ED17_NativeFunctionPtr;

		// Token: 0x04017C22 RID: 97314
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38157E69CDD_NativeFunctionPtr;

		// Token: 0x04017C23 RID: 97315
		private static IntPtr __OnFinish_27CE4A214AF5F4C1386490B4DC5B38BD_NativeFunctionPtr;

		// Token: 0x04017C24 RID: 97316
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr;

		// Token: 0x04017C25 RID: 97317
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr;

		// Token: 0x04017C26 RID: 97318
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr;

		// Token: 0x04017C27 RID: 97319
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr;

		// Token: 0x04017C28 RID: 97320
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81C2BEF4CE_NativeFunctionPtr;

		// Token: 0x04017C29 RID: 97321
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C2A RID: 97322
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C2B RID: 97323
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_New_2_NativeFunctionPtr;

		// Token: 0x0200A379 RID: 41849
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A39F07CCF8_FunctionParams
		{
			// Token: 0x04033156 RID: 209238
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A37A RID: 41850
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A30C14F14A_FunctionParams
		{
			// Token: 0x04033157 RID: 209239
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A37B RID: 41851
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A38B48ED17_FunctionParams
		{
			// Token: 0x04033158 RID: 209240
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A37C RID: 41852
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38157E69CDD_FunctionParams
		{
			// Token: 0x04033159 RID: 209241
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A37D RID: 41853
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403315A RID: 209242
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A37E RID: 41854
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1712)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_New_2_FunctionParams
		{
			// Token: 0x0403315B RID: 209243
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
