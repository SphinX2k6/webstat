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
	// Token: 0x020040CB RID: 16587
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_Yanxu_QQ.GA_Super_Sprint_Start_Yanxu_QQ_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1493)]
	public class GA_Super_Sprint_Start_Yanxu_QQ_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B603 RID: 177667 RVA: 0x00A79F23 File Offset: 0x00A78123
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_Yanxu_QQ_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_Yanxu_QQ.GA_Super_Sprint_Start_Yanxu_QQ_C");
			}
			return GA_Super_Sprint_Start_Yanxu_QQ_C._ClassPtr;
		}

		// Token: 0x0602B604 RID: 177668 RVA: 0x00A79F48 File Offset: 0x00A78148
		public GA_Super_Sprint_Start_Yanxu_QQ_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_Yanxu_QQ_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B605 RID: 177669 RVA: 0x00A79F70 File Offset: 0x00A78170
		[NullableContext(1)]
		public GA_Super_Sprint_Start_Yanxu_QQ_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_Yanxu_QQ_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700719E RID: 29086
		// (get) Token: 0x0602B606 RID: 177670 RVA: 0x00A79FA4 File Offset: 0x00A781A4
		// (set) Token: 0x0602B607 RID: 177671 RVA: 0x00A79FDD File Offset: 0x00A781DD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700719F RID: 29087
		// (get) Token: 0x0602B608 RID: 177672 RVA: 0x00A79FFE File Offset: 0x00A781FE
		// (set) Token: 0x0602B609 RID: 177673 RVA: 0x00A7A00E File Offset: 0x00A7820E
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170071A0 RID: 29088
		// (get) Token: 0x0602B60A RID: 177674 RVA: 0x00A7A01F File Offset: 0x00A7821F
		// (set) Token: 0x0602B60B RID: 177675 RVA: 0x00A7A02F File Offset: 0x00A7822F
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170071A1 RID: 29089
		// (get) Token: 0x0602B60C RID: 177676 RVA: 0x00A7A040 File Offset: 0x00A78240
		// (set) Token: 0x0602B60D RID: 177677 RVA: 0x00A7A050 File Offset: 0x00A78250
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170071A2 RID: 29090
		// (get) Token: 0x0602B60E RID: 177678 RVA: 0x00A7A061 File Offset: 0x00A78261
		// (set) Token: 0x0602B60F RID: 177679 RVA: 0x00A7A071 File Offset: 0x00A78271
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170071A3 RID: 29091
		// (get) Token: 0x0602B610 RID: 177680 RVA: 0x00A7A082 File Offset: 0x00A78282
		// (set) Token: 0x0602B611 RID: 177681 RVA: 0x00A7A092 File Offset: 0x00A78292
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_Yanxu_QQ_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B612 RID: 177682 RVA: 0x00A7A0A4 File Offset: 0x00A782A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A325678CC2(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A325678CC2_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A325678CC2_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A325678CC2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A325678CC2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A325678CC2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B613 RID: 177683 RVA: 0x00A7A0F0 File Offset: 0x00A782F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A349AF4DC7(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A349AF4DC7_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A349AF4DC7_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A349AF4DC7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A349AF4DC7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A349AF4DC7_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B614 RID: 177684 RVA: 0x00A7A13C File Offset: 0x00A7833C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A344D798AD(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A344D798AD_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A344D798AD_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A344D798AD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A344D798AD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__Added_21071CB943CD992BF8EFD6A344D798AD_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B615 RID: 177685 RVA: 0x00A7A188 File Offset: 0x00A78388
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381CE1D5F8F(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__Removed_DB9F64004F8908FEAD99D381CE1D5F8F_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__Removed_DB9F64004F8908FEAD99D381CE1D5F8F_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__Removed_DB9F64004F8908FEAD99D381CE1D5F8F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__Removed_DB9F64004F8908FEAD99D381CE1D5F8F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__Removed_DB9F64004F8908FEAD99D381CE1D5F8F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B616 RID: 177686 RVA: 0x00A7A1D3 File Offset: 0x00A783D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_7FB741F8402D3695D88D6FB34C839BBC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__OnFinish_7FB741F8402D3695D88D6FB34C839BBC_NativeFunctionPtr, null);
		}

		// Token: 0x0602B617 RID: 177687 RVA: 0x00A7A1E7 File Offset: 0x00A783E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E8194D1A5B9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__OnTick_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B618 RID: 177688 RVA: 0x00A7A1FB File Offset: 0x00A783FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E8194D1A5B9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__OnCancelled_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B619 RID: 177689 RVA: 0x00A7A20F File Offset: 0x00A7840F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E8194D1A5B9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__OnInterrupted_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B61A RID: 177690 RVA: 0x00A7A223 File Offset: 0x00A78423
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E8194D1A5B9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__OnBlendOut_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B61B RID: 177691 RVA: 0x00A7A237 File Offset: 0x00A78437
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E8194D1A5B9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__OnCompleted_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr, null);
		}

		// Token: 0x0602B61C RID: 177692 RVA: 0x00A7A24B File Offset: 0x00A7844B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B61D RID: 177693 RVA: 0x00A7A25F File Offset: 0x00A7845F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B61E RID: 177694 RVA: 0x00A7A274 File Offset: 0x00A78474
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B61F RID: 177695 RVA: 0x00A7A2BC File Offset: 0x00A784BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B620 RID: 177696 RVA: 0x00A7A304 File Offset: 0x00A78504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ(int EntryPoint)
		{
			GA_Super_Sprint_Start_Yanxu_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_Yanxu_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_FunctionParams[(UIntPtr)1743] + 15L / (long)sizeof(GA_Super_Sprint_Start_Yanxu_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_Yanxu_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_Yanxu_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B621 RID: 177697 RVA: 0x00A7A34E File Offset: 0x00A7854E
		protected GA_Super_Sprint_Start_Yanxu_QQ_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C88 RID: 97416
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_Yanxu_QQ.GA_Super_Sprint_Start_Yanxu_QQ_C";

		// Token: 0x04017C89 RID: 97417
		private static IntPtr _ClassPtr;

		// Token: 0x04017C8A RID: 97418
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C8B RID: 97419
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C8C RID: 97420
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C8D RID: 97421
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C8E RID: 97422
		internal new static int __PropertyOffset_2;

		// Token: 0x04017C8F RID: 97423
		internal new static int __PropertyOffset_3;

		// Token: 0x04017C90 RID: 97424
		internal static int __PropertyOffset_4;

		// Token: 0x04017C91 RID: 97425
		internal static int __PropertyOffset_5;

		// Token: 0x04017C92 RID: 97426
		private static IntPtr __Added_21071CB943CD992BF8EFD6A325678CC2_NativeFunctionPtr;

		// Token: 0x04017C93 RID: 97427
		private static IntPtr __Added_21071CB943CD992BF8EFD6A349AF4DC7_NativeFunctionPtr;

		// Token: 0x04017C94 RID: 97428
		private static IntPtr __Added_21071CB943CD992BF8EFD6A344D798AD_NativeFunctionPtr;

		// Token: 0x04017C95 RID: 97429
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381CE1D5F8F_NativeFunctionPtr;

		// Token: 0x04017C96 RID: 97430
		private static IntPtr __OnFinish_7FB741F8402D3695D88D6FB34C839BBC_NativeFunctionPtr;

		// Token: 0x04017C97 RID: 97431
		private static IntPtr __OnTick_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr;

		// Token: 0x04017C98 RID: 97432
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr;

		// Token: 0x04017C99 RID: 97433
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr;

		// Token: 0x04017C9A RID: 97434
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr;

		// Token: 0x04017C9B RID: 97435
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E8194D1A5B9_NativeFunctionPtr;

		// Token: 0x04017C9C RID: 97436
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C9D RID: 97437
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C9E RID: 97438
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_NativeFunctionPtr;

		// Token: 0x0200A397 RID: 41879
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A325678CC2_FunctionParams
		{
			// Token: 0x04033174 RID: 209268
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A398 RID: 41880
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A349AF4DC7_FunctionParams
		{
			// Token: 0x04033175 RID: 209269
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A399 RID: 41881
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A344D798AD_FunctionParams
		{
			// Token: 0x04033176 RID: 209270
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A39A RID: 41882
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381CE1D5F8F_FunctionParams
		{
			// Token: 0x04033177 RID: 209271
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A39B RID: 41883
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033178 RID: 209272
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A39C RID: 41884
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1728)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_Yanxu_QQ_FunctionParams
		{
			// Token: 0x04033179 RID: 209273
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
