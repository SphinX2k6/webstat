using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.JadeMaterialEffect.BP
{
	// Token: 0x02003C73 RID: 15475
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/JadeMaterialEffect/BP/BP_ChangeMaterial.BP_ChangeMaterial_C")]
	[UnrealStructLayout(1328, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1328)]
	public class BP_ChangeMaterial_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023E8A RID: 147082 RVA: 0x0098F5A1 File Offset: 0x0098D7A1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ChangeMaterial_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/JadeMaterialEffect/BP/BP_ChangeMaterial.BP_ChangeMaterial_C");
			}
			return BP_ChangeMaterial_C._ClassPtr;
		}

		// Token: 0x06023E8B RID: 147083 RVA: 0x0098F5C8 File Offset: 0x0098D7C8
		public BP_ChangeMaterial_C() : this(BuiltinUtils.AllocNativeUObject(BP_ChangeMaterial_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023E8C RID: 147084 RVA: 0x0098F5F0 File Offset: 0x0098D7F0
		[NullableContext(1)]
		public BP_ChangeMaterial_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ChangeMaterial_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170048FC RID: 18684
		// (get) Token: 0x06023E8D RID: 147085 RVA: 0x0098F624 File Offset: 0x0098D824
		// (set) Token: 0x06023E8E RID: 147086 RVA: 0x0098F65D File Offset: 0x0098D85D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_ChangeMaterial_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_ChangeMaterial_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170048FD RID: 18685
		// (get) Token: 0x06023E8F RID: 147087 RVA: 0x0098F67E File Offset: 0x0098D87E
		// (set) Token: 0x06023E90 RID: 147088 RVA: 0x0098F692 File Offset: 0x0098D892
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChangeMaterial_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ChangeMaterial_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06023E91 RID: 147089 RVA: 0x0098F6A7 File Offset: 0x0098D8A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChangeMaterial_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023E92 RID: 147090 RVA: 0x0098F6BB File Offset: 0x0098D8BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChangeMaterial_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023E93 RID: 147091 RVA: 0x0098F6D0 File Offset: 0x0098D8D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_ChangeMaterial_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ChangeMaterial_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ChangeMaterial_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChangeMaterial_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChangeMaterial_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023E94 RID: 147092 RVA: 0x0098F718 File Offset: 0x0098D918
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_ChangeMaterial_C.__EditorTick_FunctionParams* ptr = stackalloc BP_ChangeMaterial_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_ChangeMaterial_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChangeMaterial_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChangeMaterial_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023E95 RID: 147093 RVA: 0x0098F75F File Offset: 0x0098D95F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ChangeMaterial_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023E96 RID: 147094 RVA: 0x0098F773 File Offset: 0x0098D973
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChangeMaterial_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023E97 RID: 147095 RVA: 0x0098F788 File Offset: 0x0098D988
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_ChangeMaterial(int EntryPoint)
		{
			BP_ChangeMaterial_C.__ExecuteUbergraph_BP_ChangeMaterial_FunctionParams* ptr = stackalloc BP_ChangeMaterial_C.__ExecuteUbergraph_BP_ChangeMaterial_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_ChangeMaterial_C.__ExecuteUbergraph_BP_ChangeMaterial_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ChangeMaterial_C.__ExecuteUbergraph_BP_ChangeMaterial_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_ChangeMaterial_C.__ExecuteUbergraph_BP_ChangeMaterial_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023E98 RID: 147096 RVA: 0x0098F7CF File Offset: 0x0098D9CF
		protected BP_ChangeMaterial_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012576 RID: 75126
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/JadeMaterialEffect/BP/BP_ChangeMaterial.BP_ChangeMaterial_C";

		// Token: 0x04012577 RID: 75127
		private static IntPtr _ClassPtr;

		// Token: 0x04012578 RID: 75128
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012579 RID: 75129
		internal static int __PropertyOffset_0;

		// Token: 0x0401257A RID: 75130
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401257B RID: 75131
		internal static int __PropertyOffset_1;

		// Token: 0x0401257C RID: 75132
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401257D RID: 75133
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401257E RID: 75134
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401257F RID: 75135
		private static IntPtr __ExecuteUbergraph_BP_ChangeMaterial_NativeFunctionPtr;

		// Token: 0x02009D5E RID: 40286
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032753 RID: 206675
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D5F RID: 40287
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_ChangeMaterial_FunctionParams
		{
			// Token: 0x04032754 RID: 206676
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
