using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PSOSwitchSettingDebug
{
	// Token: 0x02003B46 RID: 15174
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/PSOManager.PSOManager_C")]
	[UnrealStructLayout(1336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1329)]
	public class PSOManager_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020E41 RID: 134721 RVA: 0x00939F8C File Offset: 0x0093818C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PSOManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/PSOManager.PSOManager_C");
			}
			return PSOManager_C._ClassPtr;
		}

		// Token: 0x06020E42 RID: 134722 RVA: 0x00939FB0 File Offset: 0x009381B0
		public PSOManager_C() : this(BuiltinUtils.AllocNativeUObject(PSOManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020E43 RID: 134723 RVA: 0x00939FD8 File Offset: 0x009381D8
		[NullableContext(1)]
		public PSOManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PSOManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037D9 RID: 14297
		// (get) Token: 0x06020E44 RID: 134724 RVA: 0x0093A00C File Offset: 0x0093820C
		// (set) Token: 0x06020E45 RID: 134725 RVA: 0x0093A045 File Offset: 0x00938245
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)PSOManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)PSOManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037DA RID: 14298
		// (get) Token: 0x06020E46 RID: 134726 RVA: 0x0093A066 File Offset: 0x00938266
		// (set) Token: 0x06020E47 RID: 134727 RVA: 0x0093A07A File Offset: 0x0093827A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PSOManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PSOManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170037DB RID: 14299
		// (get) Token: 0x06020E48 RID: 134728 RVA: 0x0093A08F File Offset: 0x0093828F
		// (set) Token: 0x06020E49 RID: 134729 RVA: 0x0093A09F File Offset: 0x0093829F
		public unsafe bool ubinstance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PSOManager_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PSOManager_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020E4A RID: 134730 RVA: 0x0093A0B0 File Offset: 0x009382B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			PSOManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc PSOManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PSOManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PSOManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PSOManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020E4B RID: 134731 RVA: 0x0093A0F8 File Offset: 0x009382F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			PSOManager_C.__ReceiveTick_FunctionParams* ptr = stackalloc PSOManager_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PSOManager_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PSOManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PSOManager_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E4C RID: 134732 RVA: 0x0093A140 File Offset: 0x00938340
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			PSOManager_C.__EditorTick_FunctionParams* ptr = stackalloc PSOManager_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PSOManager_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PSOManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PSOManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020E4D RID: 134733 RVA: 0x0093A188 File Offset: 0x00938388
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			PSOManager_C.__EditorTick_FunctionParams* ptr = stackalloc PSOManager_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(PSOManager_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PSOManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PSOManager_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E4E RID: 134734 RVA: 0x0093A1D0 File Offset: 0x009383D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_PSOManager(int EntryPoint)
		{
			PSOManager_C.__ExecuteUbergraph_PSOManager_FunctionParams* ptr = stackalloc PSOManager_C.__ExecuteUbergraph_PSOManager_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(PSOManager_C.__ExecuteUbergraph_PSOManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PSOManager_C.__ExecuteUbergraph_PSOManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PSOManager_C.__ExecuteUbergraph_PSOManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020E4F RID: 134735 RVA: 0x0093A217 File Offset: 0x00938417
		protected PSOManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010812 RID: 67602
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PSOSwitchSettingDebug/PSOManager.PSOManager_C";

		// Token: 0x04010813 RID: 67603
		private static IntPtr _ClassPtr;

		// Token: 0x04010814 RID: 67604
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010815 RID: 67605
		internal static int __PropertyOffset_0;

		// Token: 0x04010816 RID: 67606
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010817 RID: 67607
		internal static int __PropertyOffset_1;

		// Token: 0x04010818 RID: 67608
		internal static int __PropertyOffset_2;

		// Token: 0x04010819 RID: 67609
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401081A RID: 67610
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401081B RID: 67611
		private static IntPtr __ExecuteUbergraph_PSOManager_NativeFunctionPtr;

		// Token: 0x02009A43 RID: 39491
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032143 RID: 205123
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A44 RID: 39492
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032144 RID: 205124
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A45 RID: 39493
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_PSOManager_FunctionParams
		{
			// Token: 0x04032145 RID: 205125
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
