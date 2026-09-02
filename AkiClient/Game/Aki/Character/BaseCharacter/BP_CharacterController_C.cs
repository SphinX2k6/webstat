using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C6 RID: 16838
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_CharacterController.BP_CharacterController_C")]
	[UnrealStructLayout(2360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2360)]
	public class BP_CharacterController_C : __TsCharacterController_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CC2C RID: 183340 RVA: 0x00AAEA87 File Offset: 0x00AACC87
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_CharacterController.BP_CharacterController_C");
			}
			return BP_CharacterController_C._ClassPtr;
		}

		// Token: 0x0602CC2D RID: 183341 RVA: 0x00AAEAAC File Offset: 0x00AACCAC
		public BP_CharacterController_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CC2E RID: 183342 RVA: 0x00AAEAD4 File Offset: 0x00AACCD4
		[NullableContext(1)]
		public BP_CharacterController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078E3 RID: 30947
		// (get) Token: 0x0602CC2F RID: 183343 RVA: 0x00AAEB08 File Offset: 0x00AACD08
		// (set) Token: 0x0602CC30 RID: 183344 RVA: 0x00AAEB41 File Offset: 0x00AACD41
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CharacterController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170078E4 RID: 30948
		// (get) Token: 0x0602CC31 RID: 183345 RVA: 0x00AAEB62 File Offset: 0x00AACD62
		// (set) Token: 0x0602CC32 RID: 183346 RVA: 0x00AAEB76 File Offset: 0x00AACD76
		public unsafe TsBaseCharacter 当前操作角色
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterController_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170078E5 RID: 30949
		// (get) Token: 0x0602CC33 RID: 183347 RVA: 0x00AAEB8B File Offset: 0x00AACD8B
		// (set) Token: 0x0602CC34 RID: 183348 RVA: 0x00AAEB9B File Offset: 0x00AACD9B
		public unsafe bool GmIsOpen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterController_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterController_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170078E6 RID: 30950
		// (get) Token: 0x0602CC35 RID: 183349 RVA: 0x00AAEBAC File Offset: 0x00AACDAC
		// (set) Token: 0x0602CC36 RID: 183350 RVA: 0x00AAEBC0 File Offset: 0x00AACDC0
		public unsafe BP_KuroCheatManager_C KuroCheatManager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_KuroCheatManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterController_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterController_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602CC37 RID: 183351 RVA: 0x00AAEBD8 File Offset: 0x00AACDD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveUnPossess(APawn UnpossessedPawn)
		{
			BP_CharacterController_C.__ReceiveUnPossess_FunctionParams* ptr = stackalloc BP_CharacterController_C.__ReceiveUnPossess_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CharacterController_C.__ReceiveUnPossess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__ReceiveUnPossess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->UnpossessedPawn = ((UnpossessedPawn != null) ? UnpossessedPawn.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterController_C.__ReceiveUnPossess_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CC38 RID: 183352 RVA: 0x00AAEC30 File Offset: 0x00AACE30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveUnPossess_Implementation(APawn UnpossessedPawn)
		{
			BP_CharacterController_C.__ReceiveUnPossess_FunctionParams* ptr = stackalloc BP_CharacterController_C.__ReceiveUnPossess_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CharacterController_C.__ReceiveUnPossess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__ReceiveUnPossess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->UnpossessedPawn = ((UnpossessedPawn != null) ? UnpossessedPawn.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterController_C.__ReceiveUnPossess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CC39 RID: 183353 RVA: 0x00AAEC88 File Offset: 0x00AACE88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceivePossess(APawn PossessedPawn)
		{
			BP_CharacterController_C.__ReceivePossess_FunctionParams* ptr = stackalloc BP_CharacterController_C.__ReceivePossess_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CharacterController_C.__ReceivePossess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__ReceivePossess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PossessedPawn = ((PossessedPawn != null) ? PossessedPawn.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterController_C.__ReceivePossess_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CC3A RID: 183354 RVA: 0x00AAECE0 File Offset: 0x00AACEE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceivePossess_Implementation(APawn PossessedPawn)
		{
			BP_CharacterController_C.__ReceivePossess_FunctionParams* ptr = stackalloc BP_CharacterController_C.__ReceivePossess_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_CharacterController_C.__ReceivePossess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__ReceivePossess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PossessedPawn = ((PossessedPawn != null) ? PossessedPawn.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterController_C.__ReceivePossess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CC3B RID: 183355 RVA: 0x00AAED36 File Offset: 0x00AACF36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602CC3C RID: 183356 RVA: 0x00AAED4A File Offset: 0x00AACF4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602CC3D RID: 183357 RVA: 0x00AAED60 File Offset: 0x00AACF60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnPressAnyKey(FKey key)
		{
			BP_CharacterController_C.__OnPressAnyKey_FunctionParams* ptr = stackalloc BP_CharacterController_C.__OnPressAnyKey_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CharacterController_C.__OnPressAnyKey_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__OnPressAnyKey_NativeFunctionPtr, (void*)ptr, 1);
			if (key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->key, key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterController_C.__OnPressAnyKey_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_CharacterController_C.__OnPressAnyKey_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CC3E RID: 183358 RVA: 0x00AAEDD4 File Offset: 0x00AACFD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnReleaseAnyKey(FKey key)
		{
			BP_CharacterController_C.__OnReleaseAnyKey_FunctionParams* ptr = stackalloc BP_CharacterController_C.__OnReleaseAnyKey_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CharacterController_C.__OnReleaseAnyKey_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__OnReleaseAnyKey_NativeFunctionPtr, (void*)ptr, 1);
			if (key != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->key, key.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterController_C.__OnReleaseAnyKey_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_CharacterController_C.__OnReleaseAnyKey_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CC3F RID: 183359 RVA: 0x00AAEE48 File Offset: 0x00AAD048
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CharacterController(int EntryPoint)
		{
			BP_CharacterController_C.__ExecuteUbergraph_BP_CharacterController_FunctionParams* ptr = stackalloc BP_CharacterController_C.__ExecuteUbergraph_BP_CharacterController_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_CharacterController_C.__ExecuteUbergraph_BP_CharacterController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterController_C.__ExecuteUbergraph_BP_CharacterController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterController_C.__ExecuteUbergraph_BP_CharacterController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CC40 RID: 183360 RVA: 0x00AAEE92 File Offset: 0x00AAD092
		protected BP_CharacterController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F0C RID: 102156
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_CharacterController.BP_CharacterController_C";

		// Token: 0x04018F0D RID: 102157
		private static IntPtr _ClassPtr;

		// Token: 0x04018F0E RID: 102158
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F0F RID: 102159
		internal static int __PropertyOffset_0;

		// Token: 0x04018F10 RID: 102160
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018F11 RID: 102161
		internal static int __PropertyOffset_1;

		// Token: 0x04018F12 RID: 102162
		internal static int __PropertyOffset_2;

		// Token: 0x04018F13 RID: 102163
		internal static int __PropertyOffset_3;

		// Token: 0x04018F14 RID: 102164
		private static IntPtr __ReceiveUnPossess_NativeFunctionPtr;

		// Token: 0x04018F15 RID: 102165
		private static IntPtr __ReceivePossess_NativeFunctionPtr;

		// Token: 0x04018F16 RID: 102166
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018F17 RID: 102167
		private static IntPtr __OnPressAnyKey_NativeFunctionPtr;

		// Token: 0x04018F18 RID: 102168
		private static IntPtr __OnReleaseAnyKey_NativeFunctionPtr;

		// Token: 0x04018F19 RID: 102169
		private static IntPtr __ExecuteUbergraph_BP_CharacterController_NativeFunctionPtr;

		// Token: 0x0200A517 RID: 42263
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveUnPossess_FunctionParams
		{
			// Token: 0x040333BD RID: 209853
			[FieldOffset(0)]
			public IntPtr UnpossessedPawn;
		}

		// Token: 0x0200A518 RID: 42264
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceivePossess_FunctionParams
		{
			// Token: 0x040333BE RID: 209854
			[FieldOffset(0)]
			public IntPtr PossessedPawn;
		}

		// Token: 0x0200A519 RID: 42265
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected new ref struct __OnPressAnyKey_FunctionParams
		{
			// Token: 0x040333BF RID: 209855
			[FieldOffset(0)]
			public byte key;
		}

		// Token: 0x0200A51A RID: 42266
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected new ref struct __OnReleaseAnyKey_FunctionParams
		{
			// Token: 0x040333C0 RID: 209856
			[FieldOffset(0)]
			public byte key;
		}

		// Token: 0x0200A51B RID: 42267
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_CharacterController_FunctionParams
		{
			// Token: 0x040333C1 RID: 209857
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
