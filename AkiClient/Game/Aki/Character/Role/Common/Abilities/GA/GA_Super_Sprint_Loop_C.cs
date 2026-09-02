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
	// Token: 0x020040C2 RID: 16578
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Loop.GA_Super_Sprint_Loop_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1496)]
	public class GA_Super_Sprint_Loop_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B50D RID: 177421 RVA: 0x00A77C7F File Offset: 0x00A75E7F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_Loop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Loop.GA_Super_Sprint_Loop_C");
			}
			return GA_Super_Sprint_Loop_C._ClassPtr;
		}

		// Token: 0x0602B50E RID: 177422 RVA: 0x00A77CA4 File Offset: 0x00A75EA4
		public GA_Super_Sprint_Loop_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Loop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B50F RID: 177423 RVA: 0x00A77CCC File Offset: 0x00A75ECC
		[NullableContext(1)]
		public GA_Super_Sprint_Loop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_Loop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007172 RID: 29042
		// (get) Token: 0x0602B510 RID: 177424 RVA: 0x00A77D00 File Offset: 0x00A75F00
		// (set) Token: 0x0602B511 RID: 177425 RVA: 0x00A77D39 File Offset: 0x00A75F39
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007173 RID: 29043
		// (get) Token: 0x0602B512 RID: 177426 RVA: 0x00A77D5A File Offset: 0x00A75F5A
		// (set) Token: 0x0602B513 RID: 177427 RVA: 0x00A77D6A File Offset: 0x00A75F6A
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007174 RID: 29044
		// (get) Token: 0x0602B514 RID: 177428 RVA: 0x00A77D7B File Offset: 0x00A75F7B
		// (set) Token: 0x0602B515 RID: 177429 RVA: 0x00A77D8B File Offset: 0x00A75F8B
		public unsafe bool 是否空中打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007175 RID: 29045
		// (get) Token: 0x0602B516 RID: 177430 RVA: 0x00A77D9C File Offset: 0x00A75F9C
		// (set) Token: 0x0602B517 RID: 177431 RVA: 0x00A77DAC File Offset: 0x00A75FAC
		public unsafe float Block_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_Loop_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602B518 RID: 177432 RVA: 0x00A77DBD File Offset: 0x00A75FBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E81A76D2917()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__OnTick_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr, null);
		}

		// Token: 0x0602B519 RID: 177433 RVA: 0x00A77DD1 File Offset: 0x00A75FD1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E81A76D2917()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__OnCancelled_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr, null);
		}

		// Token: 0x0602B51A RID: 177434 RVA: 0x00A77DE5 File Offset: 0x00A75FE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E81A76D2917()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__OnInterrupted_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr, null);
		}

		// Token: 0x0602B51B RID: 177435 RVA: 0x00A77DF9 File Offset: 0x00A75FF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E81A76D2917()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__OnBlendOut_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr, null);
		}

		// Token: 0x0602B51C RID: 177436 RVA: 0x00A77E0D File Offset: 0x00A7600D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E81A76D2917()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__OnCompleted_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr, null);
		}

		// Token: 0x0602B51D RID: 177437 RVA: 0x00A77E24 File Offset: 0x00A76024
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Removed_DB9F64004F8908FEAD99D381321E83EA(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_C.__Removed_DB9F64004F8908FEAD99D381321E83EA_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__Removed_DB9F64004F8908FEAD99D381321E83EA_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__Removed_DB9F64004F8908FEAD99D381321E83EA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__Removed_DB9F64004F8908FEAD99D381321E83EA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__Removed_DB9F64004F8908FEAD99D381321E83EA_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B51E RID: 177438 RVA: 0x00A77E70 File Offset: 0x00A76070
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A3DA1F3AFA(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A3DA1F3AFA_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A3DA1F3AFA_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A3DA1F3AFA_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A3DA1F3AFA_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A3DA1F3AFA_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B51F RID: 177439 RVA: 0x00A77EBC File Offset: 0x00A760BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Added_21071CB943CD992BF8EFD6A347A7B2A4(in FGameplayTag Tag)
		{
			GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A347A7B2A4_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A347A7B2A4_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A347A7B2A4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A347A7B2A4_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Tag = Tag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__Added_21071CB943CD992BF8EFD6A347A7B2A4_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B520 RID: 177440 RVA: 0x00A77F08 File Offset: 0x00A76108
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void EventReceived_18B59F5945020DB23C42FD88D50560FF(FGameplayEventData Payload)
		{
			GA_Super_Sprint_Loop_C.__EventReceived_18B59F5945020DB23C42FD88D50560FF_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__EventReceived_18B59F5945020DB23C42FD88D50560FF_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__EventReceived_18B59F5945020DB23C42FD88D50560FF_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__EventReceived_18B59F5945020DB23C42FD88D50560FF_NativeFunctionPtr, (void*)ptr, 1);
			if (Payload != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayEventData.StaticStruct(), &ptr->Payload, Payload.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__EventReceived_18B59F5945020DB23C42FD88D50560FF_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(GA_Super_Sprint_Loop_C.__EventReceived_18B59F5945020DB23C42FD88D50560FF_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602B521 RID: 177441 RVA: 0x00A77F7D File Offset: 0x00A7617D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B522 RID: 177442 RVA: 0x00A77F91 File Offset: 0x00A76191
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B523 RID: 177443 RVA: 0x00A77FA8 File Offset: 0x00A761A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_Loop_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B524 RID: 177444 RVA: 0x00A77FF0 File Offset: 0x00A761F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_Loop_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B525 RID: 177445 RVA: 0x00A78038 File Offset: 0x00A76238
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_Loop(int EntryPoint)
		{
			GA_Super_Sprint_Loop_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_FunctionParams* ptr = stackalloc GA_Super_Sprint_Loop_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_FunctionParams[(UIntPtr)1623] + 15L / (long)sizeof(GA_Super_Sprint_Loop_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_Loop_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_Loop_C.__ExecuteUbergraph_GA_Super_Sprint_Loop_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B526 RID: 177446 RVA: 0x00A78082 File Offset: 0x00A76282
		protected GA_Super_Sprint_Loop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017BCF RID: 97231
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_Loop.GA_Super_Sprint_Loop_C";

		// Token: 0x04017BD0 RID: 97232
		private static IntPtr _ClassPtr;

		// Token: 0x04017BD1 RID: 97233
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017BD2 RID: 97234
		internal new static int __PropertyOffset_0;

		// Token: 0x04017BD3 RID: 97235
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017BD4 RID: 97236
		internal new static int __PropertyOffset_1;

		// Token: 0x04017BD5 RID: 97237
		internal new static int __PropertyOffset_2;

		// Token: 0x04017BD6 RID: 97238
		internal new static int __PropertyOffset_3;

		// Token: 0x04017BD7 RID: 97239
		private static IntPtr __OnTick_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr;

		// Token: 0x04017BD8 RID: 97240
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr;

		// Token: 0x04017BD9 RID: 97241
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr;

		// Token: 0x04017BDA RID: 97242
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr;

		// Token: 0x04017BDB RID: 97243
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E81A76D2917_NativeFunctionPtr;

		// Token: 0x04017BDC RID: 97244
		private static IntPtr __Removed_DB9F64004F8908FEAD99D381321E83EA_NativeFunctionPtr;

		// Token: 0x04017BDD RID: 97245
		private static IntPtr __Added_21071CB943CD992BF8EFD6A3DA1F3AFA_NativeFunctionPtr;

		// Token: 0x04017BDE RID: 97246
		private static IntPtr __Added_21071CB943CD992BF8EFD6A347A7B2A4_NativeFunctionPtr;

		// Token: 0x04017BDF RID: 97247
		private static IntPtr __EventReceived_18B59F5945020DB23C42FD88D50560FF_NativeFunctionPtr;

		// Token: 0x04017BE0 RID: 97248
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017BE1 RID: 97249
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017BE2 RID: 97250
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_Loop_NativeFunctionPtr;

		// Token: 0x0200A365 RID: 41829
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Removed_DB9F64004F8908FEAD99D381321E83EA_FunctionParams
		{
			// Token: 0x04033142 RID: 209218
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A366 RID: 41830
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A3DA1F3AFA_FunctionParams
		{
			// Token: 0x04033143 RID: 209219
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A367 RID: 41831
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Added_21071CB943CD992BF8EFD6A347A7B2A4_FunctionParams
		{
			// Token: 0x04033144 RID: 209220
			[FieldOffset(0)]
			public FGameplayTag Tag;
		}

		// Token: 0x0200A368 RID: 41832
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __EventReceived_18B59F5945020DB23C42FD88D50560FF_FunctionParams
		{
			// Token: 0x04033145 RID: 209221
			[FieldOffset(0)]
			public byte Payload;
		}

		// Token: 0x0200A369 RID: 41833
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x04033146 RID: 209222
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A36A RID: 41834
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1608)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_Loop_FunctionParams
		{
			// Token: 0x04033147 RID: 209223
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
