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
	// Token: 0x020040C0 RID: 16576
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_End_New.GA_Super_Sprint_End_New_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1489)]
	public class GA_Super_Sprint_End_New_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B4E6 RID: 177382 RVA: 0x00A776C3 File Offset: 0x00A758C3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Super_Sprint_End_New_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_End_New.GA_Super_Sprint_End_New_C");
			}
			return GA_Super_Sprint_End_New_C._ClassPtr;
		}

		// Token: 0x0602B4E7 RID: 177383 RVA: 0x00A776E8 File Offset: 0x00A758E8
		public GA_Super_Sprint_End_New_C() : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_End_New_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B4E8 RID: 177384 RVA: 0x00A77710 File Offset: 0x00A75910
		[NullableContext(1)]
		public GA_Super_Sprint_End_New_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Super_Sprint_End_New_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700716E RID: 29038
		// (get) Token: 0x0602B4E9 RID: 177385 RVA: 0x00A77744 File Offset: 0x00A75944
		// (set) Token: 0x0602B4EA RID: 177386 RVA: 0x00A7777D File Offset: 0x00A7597D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)GA_Super_Sprint_End_New_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)GA_Super_Sprint_End_New_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700716F RID: 29039
		// (get) Token: 0x0602B4EB RID: 177387 RVA: 0x00A7779E File Offset: 0x00A7599E
		// (set) Token: 0x0602B4EC RID: 177388 RVA: 0x00A777AE File Offset: 0x00A759AE
		public unsafe bool 是否被打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GA_Super_Sprint_End_New_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)GA_Super_Sprint_End_New_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B4ED RID: 177389 RVA: 0x00A777BF File Offset: 0x00A759BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTick_5D118C384AE61F1C80292E818DF7D4CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__OnTick_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4EE RID: 177390 RVA: 0x00A777D3 File Offset: 0x00A759D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCancelled_5D118C384AE61F1C80292E818DF7D4CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__OnCancelled_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4EF RID: 177391 RVA: 0x00A777E7 File Offset: 0x00A759E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInterrupted_5D118C384AE61F1C80292E818DF7D4CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__OnInterrupted_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4F0 RID: 177392 RVA: 0x00A777FB File Offset: 0x00A759FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnBlendOut_5D118C384AE61F1C80292E818DF7D4CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__OnBlendOut_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4F1 RID: 177393 RVA: 0x00A7780F File Offset: 0x00A75A0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnCompleted_5D118C384AE61F1C80292E818DF7D4CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__OnCompleted_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4F2 RID: 177394 RVA: 0x00A77823 File Offset: 0x00A75A23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void K2_ActivateAbility()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__K2_ActivateAbility_NativeFunctionPtr, null);
		}

		// Token: 0x0602B4F3 RID: 177395 RVA: 0x00A77837 File Offset: 0x00A75A37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void K2_ActivateAbility_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__K2_ActivateAbility_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602B4F4 RID: 177396 RVA: 0x00A7784C File Offset: 0x00A75A4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void K2_OnEndAbility(bool bWasCancelled)
		{
			GA_Super_Sprint_End_New_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_End_New_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_End_New_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_End_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B4F5 RID: 177397 RVA: 0x00A77894 File Offset: 0x00A75A94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void K2_OnEndAbility_Implementation(bool bWasCancelled)
		{
			GA_Super_Sprint_End_New_C.__K2_OnEndAbility_FunctionParams* ptr = stackalloc GA_Super_Sprint_End_New_C.__K2_OnEndAbility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(GA_Super_Sprint_End_New_C.__K2_OnEndAbility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_End_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bWasCancelled = bWasCancelled;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__K2_OnEndAbility_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4F6 RID: 177398 RVA: 0x00A778DC File Offset: 0x00A75ADC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_GA_Super_Sprint_End_New(int EntryPoint)
		{
			GA_Super_Sprint_End_New_C.__ExecuteUbergraph_GA_Super_Sprint_End_New_FunctionParams* ptr = stackalloc GA_Super_Sprint_End_New_C.__ExecuteUbergraph_GA_Super_Sprint_End_New_FunctionParams[(UIntPtr)847] + 15L / (long)sizeof(GA_Super_Sprint_End_New_C.__ExecuteUbergraph_GA_Super_Sprint_End_New_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(GA_Super_Sprint_End_New_C.__ExecuteUbergraph_GA_Super_Sprint_End_New_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, GA_Super_Sprint_End_New_C.__ExecuteUbergraph_GA_Super_Sprint_End_New_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B4F7 RID: 177399 RVA: 0x00A77926 File Offset: 0x00A75B26
		protected GA_Super_Sprint_End_New_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017BB0 RID: 97200
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Super_Sprint_End_New.GA_Super_Sprint_End_New_C";

		// Token: 0x04017BB1 RID: 97201
		private static IntPtr _ClassPtr;

		// Token: 0x04017BB2 RID: 97202
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017BB3 RID: 97203
		internal new static int __PropertyOffset_0;

		// Token: 0x04017BB4 RID: 97204
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017BB5 RID: 97205
		internal new static int __PropertyOffset_1;

		// Token: 0x04017BB6 RID: 97206
		private static IntPtr __OnTick_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr;

		// Token: 0x04017BB7 RID: 97207
		private static IntPtr __OnCancelled_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr;

		// Token: 0x04017BB8 RID: 97208
		private static IntPtr __OnInterrupted_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr;

		// Token: 0x04017BB9 RID: 97209
		private static IntPtr __OnBlendOut_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr;

		// Token: 0x04017BBA RID: 97210
		private static IntPtr __OnCompleted_5D118C384AE61F1C80292E818DF7D4CF_NativeFunctionPtr;

		// Token: 0x04017BBB RID: 97211
		private static IntPtr __K2_ActivateAbility_NativeFunctionPtr;

		// Token: 0x04017BBC RID: 97212
		private static IntPtr __K2_OnEndAbility_NativeFunctionPtr;

		// Token: 0x04017BBD RID: 97213
		private static IntPtr __ExecuteUbergraph_GA_Super_Sprint_End_New_NativeFunctionPtr;

		// Token: 0x0200A35E RID: 41822
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __K2_OnEndAbility_FunctionParams
		{
			// Token: 0x0403313B RID: 209211
			[FieldOffset(0)]
			public bool bWasCancelled;
		}

		// Token: 0x0200A35F RID: 41823
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 832)]
		protected ref struct __ExecuteUbergraph_GA_Super_Sprint_End_New_FunctionParams
		{
			// Token: 0x0403313C RID: 209212
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
