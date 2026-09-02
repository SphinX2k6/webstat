using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light.Performance
{
	// Token: 0x02003AAF RID: 15023
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_MobileHideLight.BP_MobileHideLight_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_MobileHideLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602002A RID: 131114 RVA: 0x0091FBCC File Offset: 0x0091DDCC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MobileHideLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_MobileHideLight.BP_MobileHideLight_C");
			}
			return BP_MobileHideLight_C._ClassPtr;
		}

		// Token: 0x0602002B RID: 131115 RVA: 0x0091FBF0 File Offset: 0x0091DDF0
		public BP_MobileHideLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_MobileHideLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602002C RID: 131116 RVA: 0x0091FC18 File Offset: 0x0091DE18
		[NullableContext(1)]
		public BP_MobileHideLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MobileHideLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003376 RID: 13174
		// (get) Token: 0x0602002D RID: 131117 RVA: 0x0091FC4C File Offset: 0x0091DE4C
		// (set) Token: 0x0602002E RID: 131118 RVA: 0x0091FC85 File Offset: 0x0091DE85
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MobileHideLight_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MobileHideLight_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003377 RID: 13175
		// (get) Token: 0x0602002F RID: 131119 RVA: 0x0091FCA6 File Offset: 0x0091DEA6
		// (set) Token: 0x06020030 RID: 131120 RVA: 0x0091FCBA File Offset: 0x0091DEBA
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MobileHideLight_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MobileHideLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020031 RID: 131121 RVA: 0x0091FCCF File Offset: 0x0091DECF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MobileHideLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020032 RID: 131122 RVA: 0x0091FCE3 File Offset: 0x0091DEE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileHideLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020033 RID: 131123 RVA: 0x0091FCF8 File Offset: 0x0091DEF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MobileHideLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MobileHideLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MobileHideLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileHideLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MobileHideLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020034 RID: 131124 RVA: 0x0091FD40 File Offset: 0x0091DF40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MobileHideLight_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MobileHideLight_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MobileHideLight_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileHideLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileHideLight_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020035 RID: 131125 RVA: 0x0091FD88 File Offset: 0x0091DF88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_MobileHideLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MobileHideLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MobileHideLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileHideLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MobileHideLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020036 RID: 131126 RVA: 0x0091FDD0 File Offset: 0x0091DFD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_MobileHideLight_C.__EditorTick_FunctionParams* ptr = stackalloc BP_MobileHideLight_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MobileHideLight_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileHideLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileHideLight_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020037 RID: 131127 RVA: 0x0091FE18 File Offset: 0x0091E018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MobileHideLight(int EntryPoint)
		{
			BP_MobileHideLight_C.__ExecuteUbergraph_BP_MobileHideLight_FunctionParams* ptr = stackalloc BP_MobileHideLight_C.__ExecuteUbergraph_BP_MobileHideLight_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_MobileHideLight_C.__ExecuteUbergraph_BP_MobileHideLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MobileHideLight_C.__ExecuteUbergraph_BP_MobileHideLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MobileHideLight_C.__ExecuteUbergraph_BP_MobileHideLight_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020038 RID: 131128 RVA: 0x0091FE62 File Offset: 0x0091E062
		protected BP_MobileHideLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF0E RID: 65294
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/Performance/BP_MobileHideLight.BP_MobileHideLight_C";

		// Token: 0x0400FF0F RID: 65295
		private static IntPtr _ClassPtr;

		// Token: 0x0400FF10 RID: 65296
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FF11 RID: 65297
		internal static int __PropertyOffset_0;

		// Token: 0x0400FF12 RID: 65298
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400FF13 RID: 65299
		internal static int __PropertyOffset_1;

		// Token: 0x0400FF14 RID: 65300
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400FF15 RID: 65301
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400FF16 RID: 65302
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400FF17 RID: 65303
		private static IntPtr __ExecuteUbergraph_BP_MobileHideLight_NativeFunctionPtr;

		// Token: 0x02009946 RID: 39238
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031FA5 RID: 204709
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009947 RID: 39239
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031FA6 RID: 204710
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009948 RID: 39240
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_MobileHideLight_FunctionParams
		{
			// Token: 0x04031FA7 RID: 204711
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
