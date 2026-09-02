using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C7F RID: 15487
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_Haequebus_EndAttach.BP_Haequebus_EndAttach_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_Haequebus_EndAttach_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024016 RID: 147478 RVA: 0x00992107 File Offset: 0x00990307
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Haequebus_EndAttach_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_Haequebus_EndAttach.BP_Haequebus_EndAttach_C");
			}
			return BP_Haequebus_EndAttach_C._ClassPtr;
		}

		// Token: 0x06024017 RID: 147479 RVA: 0x0099212C File Offset: 0x0099032C
		public BP_Haequebus_EndAttach_C() : this(BuiltinUtils.AllocNativeUObject(BP_Haequebus_EndAttach_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024018 RID: 147480 RVA: 0x00992154 File Offset: 0x00990354
		[NullableContext(1)]
		public BP_Haequebus_EndAttach_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Haequebus_EndAttach_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700497C RID: 18812
		// (get) Token: 0x06024019 RID: 147481 RVA: 0x00992188 File Offset: 0x00990388
		// (set) Token: 0x0602401A RID: 147482 RVA: 0x009921C1 File Offset: 0x009903C1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Haequebus_EndAttach_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Haequebus_EndAttach_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700497D RID: 18813
		// (get) Token: 0x0602401B RID: 147483 RVA: 0x009921E2 File Offset: 0x009903E2
		// (set) Token: 0x0602401C RID: 147484 RVA: 0x009921F6 File Offset: 0x009903F6
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Haequebus_EndAttach_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Haequebus_EndAttach_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602401D RID: 147485 RVA: 0x0099220C File Offset: 0x0099040C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Haequebus_EndAttach_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Haequebus_EndAttach_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Haequebus_EndAttach_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Haequebus_EndAttach_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Haequebus_EndAttach_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602401E RID: 147486 RVA: 0x00992254 File Offset: 0x00990454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Haequebus_EndAttach_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Haequebus_EndAttach_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Haequebus_EndAttach_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Haequebus_EndAttach_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Haequebus_EndAttach_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602401F RID: 147487 RVA: 0x0099229C File Offset: 0x0099049C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Haequebus_EndAttach_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Haequebus_EndAttach_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Haequebus_EndAttach_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Haequebus_EndAttach_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Haequebus_EndAttach_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024020 RID: 147488 RVA: 0x009922E4 File Offset: 0x009904E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Haequebus_EndAttach_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Haequebus_EndAttach_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Haequebus_EndAttach_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Haequebus_EndAttach_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Haequebus_EndAttach_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024021 RID: 147489 RVA: 0x0099232C File Offset: 0x0099052C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Haequebus_EndAttach(int EntryPoint)
		{
			BP_Haequebus_EndAttach_C.__ExecuteUbergraph_BP_Haequebus_EndAttach_FunctionParams* ptr = stackalloc BP_Haequebus_EndAttach_C.__ExecuteUbergraph_BP_Haequebus_EndAttach_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_Haequebus_EndAttach_C.__ExecuteUbergraph_BP_Haequebus_EndAttach_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Haequebus_EndAttach_C.__ExecuteUbergraph_BP_Haequebus_EndAttach_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Haequebus_EndAttach_C.__ExecuteUbergraph_BP_Haequebus_EndAttach_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024022 RID: 147490 RVA: 0x00992373 File Offset: 0x00990573
		protected BP_Haequebus_EndAttach_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012669 RID: 75369
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_Haequebus_EndAttach.BP_Haequebus_EndAttach_C";

		// Token: 0x0401266A RID: 75370
		private static IntPtr _ClassPtr;

		// Token: 0x0401266B RID: 75371
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401266C RID: 75372
		internal static int __PropertyOffset_0;

		// Token: 0x0401266D RID: 75373
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401266E RID: 75374
		internal static int __PropertyOffset_1;

		// Token: 0x0401266F RID: 75375
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012670 RID: 75376
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012671 RID: 75377
		private static IntPtr __ExecuteUbergraph_BP_Haequebus_EndAttach_NativeFunctionPtr;

		// Token: 0x02009D76 RID: 40310
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403276B RID: 206699
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D77 RID: 40311
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403276C RID: 206700
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D78 RID: 40312
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_Haequebus_EndAttach_FunctionParams
		{
			// Token: 0x0403276D RID: 206701
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
