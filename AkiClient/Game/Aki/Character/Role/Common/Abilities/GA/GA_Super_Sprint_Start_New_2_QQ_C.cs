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
	// Token: 0x020040C7 RID: 16583
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_2_QQ.GA_Super_Sprint_Start_New_2_QQ_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1493)]
	public class GA_Super_Sprint_Start_New_2_QQ_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B587 RID: 177543 RVA: 0x00A78E53 File Offset: 0x00A77053
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Start_New_2_QQ_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_2_QQ.GA_Super_Sprint_Start_New_2_QQ_C");
			}
			return GA_Super_Sprint_Start_New_2_QQ_C._ClassPtr;
		}

		// Token: 0x0602B588 RID: 177544 RVA: 0x00A78E78 File Offset: 0x00A77078
		public GA_Super_Sprint_Start_New_2_QQ_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_2_QQ_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B589 RID: 177545 RVA: 0x00A78EA0 File Offset: 0x00A770A0
		[NullableContext(1)]
		public GA_Super_Sprint_Start_New_2_QQ_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Start_New_2_QQ_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007186 RID: 29062
		// (get) Token: 0x0602B58A RID: 177546 RVA: 0x00A78ED4 File Offset: 0x00A770D4
		// (set) Token: 0x0602B58B RID: 177547 RVA: 0x00A78F0D File Offset: 0x00A7710D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007187 RID: 29063
		// (get) Token: 0x0602B58C RID: 177548 RVA: 0x00A78F2E File Offset: 0x00A7712E
		// (set) Token: 0x0602B58D RID: 177549 RVA: 0x00A78F3E File Offset: 0x00A7713E
		public unsafe bool 刷新当前子弹跑
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007188 RID: 29064
		// (get) Token: 0x0602B58E RID: 177550 RVA: 0x00A78F4F File Offset: 0x00A7714F
		// (set) Token: 0x0602B58F RID: 177551 RVA: 0x00A78F5F File Offset: 0x00A7715F
		public unsafe bool 需要中断特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007189 RID: 29065
		// (get) Token: 0x0602B590 RID: 177552 RVA: 0x00A78F70 File Offset: 0x00A77170
		// (set) Token: 0x0602B591 RID: 177553 RVA: 0x00A78F80 File Offset: 0x00A77180
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700718A RID: 29066
		// (get) Token: 0x0602B592 RID: 177554 RVA: 0x00A78F91 File Offset: 0x00A77191
		// (set) Token: 0x0602B593 RID: 177555 RVA: 0x00A78FA1 File Offset: 0x00A771A1
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700718B RID: 29067
		// (get) Token: 0x0602B594 RID: 177556 RVA: 0x00A78FB2 File Offset: 0x00A771B2
		// (set) Token: 0x0602B595 RID: 177557 RVA: 0x00A78FC2 File Offset: 0x00A771C2
		public unsafe bool 是否结束技能
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Start_New_2_QQ_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B596 RID: 177558 RVA: 0x00A78FD4 File Offset: 0x00A771D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3D9A2EB78(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3D9A2EB78_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3D9A2EB78_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3D9A2EB78_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3D9A2EB78_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3D9A2EB78_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B597 RID: 177559 RVA: 0x00A79020 File Offset: 0x00A77220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3788C0011(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3788C0011_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3788C0011_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3788C0011_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3788C0011_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3788C0011_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B598 RID: 177560 RVA: 0x00A7906C File Offset: 0x00A7726C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3F74324C2(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3F74324C2_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3F74324C2_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3F74324C2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3F74324C2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__Added_21071CB943CD992BF8EFD6A3F74324C2_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B599 RID: 177561 RVA: 0x00A790B8 File Offset: 0x00A772B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D3814D063E56(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__Removed_DB9F64004F8908FEAD99D3814D063E56_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__Removed_DB9F64004F8908FEAD99D3814D063E56_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__Removed_DB9F64004F8908FEAD99D3814D063E56_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__Removed_DB9F64004F8908FEAD99D3814D063E56_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__Removed_DB9F64004F8908FEAD99D3814D063E56_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B59A RID: 177562 RVA: 0x00A79103 File Offset: 0x00A77303
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnFinish_5FE9619447779BD7B2D25B9196C55F40()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__OnFinish_5FE9619447779BD7B2D25B9196C55F40_NativeFunctionPtr, null);
		}

		// Token: 0x0602B59B RID: 177563 RVA: 0x00A79117 File Offset: 0x00A77317
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81F7FD97D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__OnTick_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B59C RID: 177564 RVA: 0x00A7912B File Offset: 0x00A7732B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81F7FD97D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__OnCancelled_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B59D RID: 177565 RVA: 0x00A7913F File Offset: 0x00A7733F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81F7FD97D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__OnInterrupted_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B59E RID: 177566 RVA: 0x00A79153 File Offset: 0x00A77353
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81F7FD97D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__OnBlendOut_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B59F RID: 177567 RVA: 0x00A79167 File Offset: 0x00A77367
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81F7FD97D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__OnCompleted_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5A0 RID: 177568 RVA: 0x00A7917B File Offset: 0x00A7737B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B5A1 RID: 177569 RVA: 0x00A7918F File Offset: 0x00A7738F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B5A2 RID: 177570 RVA: 0x00A791A4 File Offset: 0x00A773A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B5A3 RID: 177571 RVA: 0x00A791EC File Offset: 0x00A773EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B5A4 RID: 177572 RVA: 0x00A79234 File Offset: 0x00A77434
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ(int EntryPoint)
		{
			GA_Super_Sprint_Start_New_2_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_FunctionParams* ptr = stackalloc GA_Super_Sprint_Start_New_2_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_FunctionParams[(UIntPtr)1743] + 15L / (long)sizeof(GA_Super_Sprint_Start_New_2_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Start_New_2_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Start_New_2_QQ_C.__ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B5A5 RID: 177573 RVA: 0x00A7927E File Offset: 0x00A7747E
		protected GA_Super_Sprint_Start_New_2_QQ_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017C2C RID: 97324
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Start_New_2_QQ.GA_Super_Sprint_Start_New_2_QQ_C";

		// Token: 0x04017C2D RID: 97325
		private static IntPtr _ClassPtr;

		// Token: 0x04017C2E RID: 97326
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017C2F RID: 97327
		internal new static int __PropertyOffset_0;

		// Token: 0x04017C30 RID: 97328
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017C31 RID: 97329
		internal new static int __PropertyOffset_1;

		// Token: 0x04017C32 RID: 97330
		internal new static int __PropertyOffset_2;

		// Token: 0x04017C33 RID: 97331
		internal new static int __PropertyOffset_3;

		// Token: 0x04017C34 RID: 97332
		internal static int __PropertyOffset_4;

		// Token: 0x04017C35 RID: 97333
		internal static int __PropertyOffset_5;

		// Token: 0x04017C36 RID: 97334
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3D9A2EB78_NativeFunctionPtr;

		// Token: 0x04017C37 RID: 97335
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3788C0011_NativeFunctionPtr;

		// Token: 0x04017C38 RID: 97336
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3F74324C2_NativeFunctionPtr;

		// Token: 0x04017C39 RID: 97337
		private static IntPtr __Removed_DB9F64004F8908FEAD99D3814D063E56_NativeFunctionPtr;

		// Token: 0x04017C3A RID: 97338
		private static IntPtr __OnFinish_5FE9619447779BD7B2D25B9196C55F40_NativeFunctionPtr;

		// Token: 0x04017C3B RID: 97339
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr;

		// Token: 0x04017C3C RID: 97340
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr;

		// Token: 0x04017C3D RID: 97341
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr;

		// Token: 0x04017C3E RID: 97342
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr;

		// Token: 0x04017C3F RID: 97343
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81F7FD97D5_NativeFunctionPtr;

		// Token: 0x04017C40 RID: 97344
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017C41 RID: 97345
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017C42 RID: 97346
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_NativeFunctionPtr;

		// Token: 0x0200A37F RID: 41855
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3D9A2EB78_FunctionParams
		{
			// Token: 0x0403315C RID: 209244
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A380 RID: 41856
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3788C0011_FunctionParams
		{
			// Token: 0x0403315D RID: 209245
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A381 RID: 41857
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3F74324C2_FunctionParams
		{
			// Token: 0x0403315E RID: 209246
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A382 RID: 41858
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D3814D063E56_FunctionParams
		{
			// Token: 0x0403315F RID: 209247
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A383 RID: 41859
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033160 RID: 209248
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A384 RID: 41860
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1728)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Start_New_2_QQ_FunctionParams
		{
			// Token: 0x04033161 RID: 209249
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
