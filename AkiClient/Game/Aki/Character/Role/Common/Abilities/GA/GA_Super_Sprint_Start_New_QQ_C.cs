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
	// Token: 0x020040C9 RID: 16585
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_QQ.GA_Super_Sprint_Start_New_QQ_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1493)]
	public class GA_Super_Sprint_Start_New_QQ_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B5C5 RID: 177605 RVA: 0x00A796BB File Offset: 0x00A778BB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_New_QQ_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_QQ.GA_Super_Sprint_Start_New_QQ_C");
			}
			return GA_Super_Sprint_Start_New_QQ_C._ClassPtr;
		}

		// Token: 0x0602B5C6 RID: 177606 RVA: 0x00A796E0 File Offset: 0x00A778E0
		public GA_Super_Sprint_Start_New_QQ_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_QQ_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B5C7 RID: 177607 RVA: 0x00A79708 File Offset: 0x00A77908
		[NullableContext(1)]
		public GA_Super_Sprint_Start_New_QQ_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_QQ_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007192 RID: 29074
		// (get) Token: 0x0602B5C8 RID: 177608 RVA: 0x00A7973C File Offset: 0x00A7793C
		// (set) Token: 0x0602B5C9 RID: 177609 RVA: 0x00A79775 File Offset: 0x00A77975
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007193 RID: 29075
		// (get) Token: 0x0602B5CA RID: 177610 RVA: 0x00A79796 File Offset: 0x00A77996
		// (set) Token: 0x0602B5CB RID: 177611 RVA: 0x00A797A6 File Offset: 0x00A779A6
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007194 RID: 29076
		// (get) Token: 0x0602B5CC RID: 177612 RVA: 0x00A797B7 File Offset: 0x00A779B7
		// (set) Token: 0x0602B5CD RID: 177613 RVA: 0x00A797C7 File Offset: 0x00A779C7
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007195 RID: 29077
		// (get) Token: 0x0602B5CE RID: 177614 RVA: 0x00A797D8 File Offset: 0x00A779D8
		// (set) Token: 0x0602B5CF RID: 177615 RVA: 0x00A797E8 File Offset: 0x00A779E8
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007196 RID: 29078
		// (get) Token: 0x0602B5D0 RID: 177616 RVA: 0x00A797F9 File Offset: 0x00A779F9
		// (set) Token: 0x0602B5D1 RID: 177617 RVA: 0x00A79809 File Offset: 0x00A77A09
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007197 RID: 29079
		// (get) Token: 0x0602B5D2 RID: 177618 RVA: 0x00A7981A File Offset: 0x00A77A1A
		// (set) Token: 0x0602B5D3 RID: 177619 RVA: 0x00A7982A File Offset: 0x00A77A2A
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_QQ_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B5D4 RID: 177620 RVA: 0x00A7983C File Offset: 0x00A77A3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3C5F9A4E0(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A3C5F9A4E0_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A3C5F9A4E0_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A3C5F9A4E0_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A3C5F9A4E0_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A3C5F9A4E0_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5D5 RID: 177621 RVA: 0x00A79888 File Offset: 0x00A77A88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A350CE11F9(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A350CE11F9_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A350CE11F9_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A350CE11F9_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A350CE11F9_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A350CE11F9_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5D6 RID: 177622 RVA: 0x00A798D4 File Offset: 0x00A77AD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A339B4D4E7(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A339B4D4E7_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A339B4D4E7_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A339B4D4E7_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A339B4D4E7_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__Added_21071CB943CD992BF8EFD6A339B4D4E7_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5D7 RID: 177623 RVA: 0x00A79920 File Offset: 0x00A77B20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D38179C57504(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_QQ_C.__Removed_DB9F64004F8908FEAD99D38179C57504_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__Removed_DB9F64004F8908FEAD99D38179C57504_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__Removed_DB9F64004F8908FEAD99D38179C57504_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__Removed_DB9F64004F8908FEAD99D38179C57504_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__Removed_DB9F64004F8908FEAD99D38179C57504_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5D8 RID: 177624 RVA: 0x00A7996B File Offset: 0x00A77B6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_511E700845ECF2F3F9E523B6D6B2EE6C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__OnFinish_511E700845ECF2F3F9E523B6D6B2EE6C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5D9 RID: 177625 RVA: 0x00A7997F File Offset: 0x00A77B7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81BC0ADAC0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__OnTick_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5DA RID: 177626 RVA: 0x00A79993 File Offset: 0x00A77B93
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81BC0ADAC0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__OnCancelled_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5DB RID: 177627 RVA: 0x00A799A7 File Offset: 0x00A77BA7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81BC0ADAC0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__OnInterrupted_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5DC RID: 177628 RVA: 0x00A799BB File Offset: 0x00A77BBB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81BC0ADAC0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__OnBlendOut_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5DD RID: 177629 RVA: 0x00A799CF File Offset: 0x00A77BCF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81BC0ADAC0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__OnCompleted_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5DE RID: 177630 RVA: 0x00A799E3 File Offset: 0x00A77BE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5DF RID: 177631 RVA: 0x00A799F7 File Offset: 0x00A77BF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B5E0 RID: 177632 RVA: 0x00A79A0C File Offset: 0x00A77C0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5E1 RID: 177633 RVA: 0x00A79A54 File Offset: 0x00A77C54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B5E2 RID: 177634 RVA: 0x00A79A9C File Offset: 0x00A77C9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ(int EntryPoint)
		{
			GA_Super_Sprint_Start_New_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_FunctionParams[(UIntPtr)1759] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B5E3 RID: 177635 RVA: 0x00A79AE6 File Offset: 0x00A77CE6
		protected GA_Super_Sprint_Start_New_QQ_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C5A RID: 97370
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_QQ.GA_Super_Sprint_Start_New_QQ_C";

		// Token: 0x04017C5B RID: 97371
		private static IntPtr _ClassPtr;

		// Token: 0x04017C5C RID: 97372
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C5D RID: 97373
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C5E RID: 97374
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C5F RID: 97375
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C60 RID: 97376
		internal new static int __PropertyOffset_2;

		// Token: 0x04017C61 RID: 97377
		internal new static int __PropertyOffset_3;

		// Token: 0x04017C62 RID: 97378
		internal static int __PropertyOffset_4;

		// Token: 0x04017C63 RID: 97379
		internal static int __PropertyOffset_5;

		// Token: 0x04017C64 RID: 97380
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3C5F9A4E0_NativeFunctionPtr;

		// Token: 0x04017C65 RID: 97381
		private static IntPtr __Added_21071CB943CD992BF8EFD6A350CE11F9_NativeFunctionPtr;

		// Token: 0x04017C66 RID: 97382
		private static IntPtr __Added_21071CB943CD992BF8EFD6A339B4D4E7_NativeFunctionPtr;

		// Token: 0x04017C67 RID: 97383
		private static IntPtr __Removed_DB9F64004F8908FEAD99D38179C57504_NativeFunctionPtr;

		// Token: 0x04017C68 RID: 97384
		private static IntPtr __OnFinish_511E700845ECF2F3F9E523B6D6B2EE6C_NativeFunctionPtr;

		// Token: 0x04017C69 RID: 97385
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr;

		// Token: 0x04017C6A RID: 97386
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr;

		// Token: 0x04017C6B RID: 97387
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr;

		// Token: 0x04017C6C RID: 97388
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr;

		// Token: 0x04017C6D RID: 97389
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81BC0ADAC0_NativeFunctionPtr;

		// Token: 0x04017C6E RID: 97390
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C6F RID: 97391
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C70 RID: 97392
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_NativeFunctionPtr;

		// Token: 0x0200A38B RID: 41867
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3C5F9A4E0_FunctionParams
		{
			// Token: 0x04033168 RID: 209256
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A38C RID: 41868
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A350CE11F9_FunctionParams
		{
			// Token: 0x04033169 RID: 209257
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A38D RID: 41869
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A339B4D4E7_FunctionParams
		{
			// Token: 0x0403316A RID: 209258
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A38E RID: 41870
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D38179C57504_FunctionParams
		{
			// Token: 0x0403316B RID: 209259
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A38F RID: 41871
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403316C RID: 209260
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A390 RID: 41872
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1744)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_New_QQ_FunctionParams
		{
			// Token: 0x0403316D RID: 209261
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
