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
	// Token: 0x020040CA RID: 16586
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_Yanxu.GA_Super_Sprint_Start_Yanxu_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1493)]
	public class GA_Super_Sprint_Start_Yanxu_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B5E4 RID: 177636 RVA: 0x00A79AEF File Offset: 0x00A77CEF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_Yanxu_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_Yanxu.GA_Super_Sprint_Start_Yanxu_C");
			}
			return GA_Super_Sprint_Start_Yanxu_C._ClassPtr;
		}

		// Token: 0x0602B5E5 RID: 177637 RVA: 0x00A79B14 File Offset: 0x00A77D14
		public GA_Super_Sprint_Start_Yanxu_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_Yanxu_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B5E6 RID: 177638 RVA: 0x00A79B3C File Offset: 0x00A77D3C
		[NullableContext(1)]
		public GA_Super_Sprint_Start_Yanxu_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_Yanxu_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007198 RID: 29080
		// (get) Token: 0x0602B5E7 RID: 177639 RVA: 0x00A79B70 File Offset: 0x00A77D70
		// (set) Token: 0x0602B5E8 RID: 177640 RVA: 0x00A79BA9 File Offset: 0x00A77DA9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007199 RID: 29081
		// (get) Token: 0x0602B5E9 RID: 177641 RVA: 0x00A79BCA File Offset: 0x00A77DCA
		// (set) Token: 0x0602B5EA RID: 177642 RVA: 0x00A79BDA File Offset: 0x00A77DDA
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700719A RID: 29082
		// (get) Token: 0x0602B5EB RID: 177643 RVA: 0x00A79BEB File Offset: 0x00A77DEB
		// (set) Token: 0x0602B5EC RID: 177644 RVA: 0x00A79BFB File Offset: 0x00A77DFB
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700719B RID: 29083
		// (get) Token: 0x0602B5ED RID: 177645 RVA: 0x00A79C0C File Offset: 0x00A77E0C
		// (set) Token: 0x0602B5EE RID: 177646 RVA: 0x00A79C1C File Offset: 0x00A77E1C
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700719C RID: 29084
		// (get) Token: 0x0602B5EF RID: 177647 RVA: 0x00A79C2D File Offset: 0x00A77E2D
		// (set) Token: 0x0602B5F0 RID: 177648 RVA: 0x00A79C3D File Offset: 0x00A77E3D
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700719D RID: 29085
		// (get) Token: 0x0602B5F1 RID: 177649 RVA: 0x00A79C4E File Offset: 0x00A77E4E
		// (set) Token: 0x0602B5F2 RID: 177650 RVA: 0x00A79C5E File Offset: 0x00A77E5E
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B5F3 RID: 177651 RVA: 0x00A79C70 File Offset: 0x00A77E70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3E81CDA5C(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3E81CDA5C_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3E81CDA5C_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3E81CDA5C_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3E81CDA5C_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3E81CDA5C_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5F4 RID: 177652 RVA: 0x00A79CBC File Offset: 0x00A77EBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3270BFAB2(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3270BFAB2_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3270BFAB2_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3270BFAB2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3270BFAB2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3270BFAB2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5F5 RID: 177653 RVA: 0x00A79D08 File Offset: 0x00A77F08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3C3480ED0(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3C3480ED0_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3C3480ED0_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3C3480ED0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3C3480ED0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__Added_21071CB943CD992BF8EFD6A3C3480ED0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5F6 RID: 177654 RVA: 0x00A79D54 File Offset: 0x00A77F54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3812CE0EAD7(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_C.__Removed_DB9F64004F8908FEAD99D3812CE0EAD7_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__Removed_DB9F64004F8908FEAD99D3812CE0EAD7_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__Removed_DB9F64004F8908FEAD99D3812CE0EAD7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__Removed_DB9F64004F8908FEAD99D3812CE0EAD7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__Removed_DB9F64004F8908FEAD99D3812CE0EAD7_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5F7 RID: 177655 RVA: 0x00A79D9F File Offset: 0x00A77F9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_F80496E9471CC89D5179909DCE37EA84()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__OnFinish_F80496E9471CC89D5179909DCE37EA84_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5F8 RID: 177656 RVA: 0x00A79DB3 File Offset: 0x00A77FB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81DB6405D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__OnTick_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5F9 RID: 177657 RVA: 0x00A79DC7 File Offset: 0x00A77FC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81DB6405D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__OnCancelled_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5FA RID: 177658 RVA: 0x00A79DDB File Offset: 0x00A77FDB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81DB6405D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__OnInterrupted_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5FB RID: 177659 RVA: 0x00A79DEF File Offset: 0x00A77FEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81DB6405D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__OnBlendOut_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5FC RID: 177660 RVA: 0x00A79E03 File Offset: 0x00A78003
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81DB6405D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__OnCompleted_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5FD RID: 177661 RVA: 0x00A79E17 File Offset: 0x00A78017
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5FE RID: 177662 RVA: 0x00A79E2B File Offset: 0x00A7802B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B5FF RID: 177663 RVA: 0x00A79E40 File Offset: 0x00A78040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B600 RID: 177664 RVA: 0x00A79E88 File Offset: 0x00A78088
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B601 RID: 177665 RVA: 0x00A79ED0 File Offset: 0x00A780D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu(int EntryPoint)
		{
			GA_Super_Sprint_Start_Yanxu_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_FunctionParams[(UIntPtr)1711] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B602 RID: 177666 RVA: 0x00A79F1A File Offset: 0x00A7811A
		protected GA_Super_Sprint_Start_Yanxu_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C71 RID: 97393
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_Yanxu.GA_Super_Sprint_Start_Yanxu_C";

		// Token: 0x04017C72 RID: 97394
		private static IntPtr _ClassPtr;

		// Token: 0x04017C73 RID: 97395
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C74 RID: 97396
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C75 RID: 97397
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C76 RID: 97398
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C77 RID: 97399
		internal new static int __PropertyOffset_2;

		// Token: 0x04017C78 RID: 97400
		internal new static int __PropertyOffset_3;

		// Token: 0x04017C79 RID: 97401
		internal static int __PropertyOffset_4;

		// Token: 0x04017C7A RID: 97402
		internal static int __PropertyOffset_5;

		// Token: 0x04017C7B RID: 97403
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3E81CDA5C_NativeFunctionPtr;

		// Token: 0x04017C7C RID: 97404
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3270BFAB2_NativeFunctionPtr;

		// Token: 0x04017C7D RID: 97405
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3C3480ED0_NativeFunctionPtr;

		// Token: 0x04017C7E RID: 97406
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3812CE0EAD7_NativeFunctionPtr;

		// Token: 0x04017C7F RID: 97407
		private static IntPtr __OnFinish_F80496E9471CC89D5179909DCE37EA84_NativeFunctionPtr;

		// Token: 0x04017C80 RID: 97408
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr;

		// Token: 0x04017C81 RID: 97409
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr;

		// Token: 0x04017C82 RID: 97410
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr;

		// Token: 0x04017C83 RID: 97411
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr;

		// Token: 0x04017C84 RID: 97412
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81DB6405D5_NativeFunctionPtr;

		// Token: 0x04017C85 RID: 97413
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C86 RID: 97414
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C87 RID: 97415
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_NativeFunctionPtr;

		// Token: 0x0200A391 RID: 41873
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3E81CDA5C_FunctionParams
		{
			// Token: 0x0403316E RID: 209262
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A392 RID: 41874
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3270BFAB2_FunctionParams
		{
			// Token: 0x0403316F RID: 209263
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A393 RID: 41875
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3C3480ED0_FunctionParams
		{
			// Token: 0x04033170 RID: 209264
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A394 RID: 41876
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3812CE0EAD7_FunctionParams
		{
			// Token: 0x04033171 RID: 209265
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A395 RID: 41877
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033172 RID: 209266
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A396 RID: 41878
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1696)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_FunctionParams
		{
			// Token: 0x04033173 RID: 209267
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
