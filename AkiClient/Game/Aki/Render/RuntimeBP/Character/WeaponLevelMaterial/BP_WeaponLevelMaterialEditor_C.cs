using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial
{
	// Token: 0x02003D5C RID: 15708
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/BP_WeaponLevelMaterialEditor.BP_WeaponLevelMaterialEditor_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1368)]
	public class BP_WeaponLevelMaterialEditor_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060262EB RID: 156395 RVA: 0x009D033F File Offset: 0x009CE53F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WeaponLevelMaterialEditor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/BP_WeaponLevelMaterialEditor.BP_WeaponLevelMaterialEditor_C");
			}
			return BP_WeaponLevelMaterialEditor_C._ClassPtr;
		}

		// Token: 0x060262EC RID: 156396 RVA: 0x009D0364 File Offset: 0x009CE564
		public BP_WeaponLevelMaterialEditor_C() : this(BuiltinUtils.AllocNativeUObject(BP_WeaponLevelMaterialEditor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060262ED RID: 156397 RVA: 0x009D038C File Offset: 0x009CE58C
		[NullableContext(1)]
		public BP_WeaponLevelMaterialEditor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WeaponLevelMaterialEditor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055E3 RID: 21987
		// (get) Token: 0x060262EE RID: 156398 RVA: 0x009D03C0 File Offset: 0x009CE5C0
		// (set) Token: 0x060262EF RID: 156399 RVA: 0x009D03F9 File Offset: 0x009CE5F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WeaponLevelMaterialEditor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WeaponLevelMaterialEditor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170055E4 RID: 21988
		// (get) Token: 0x060262F0 RID: 156400 RVA: 0x009D041A File Offset: 0x009CE61A
		// (set) Token: 0x060262F1 RID: 156401 RVA: 0x009D042E File Offset: 0x009CE62E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponLevelMaterialEditor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponLevelMaterialEditor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170055E5 RID: 21989
		// (get) Token: 0x060262F2 RID: 156402 RVA: 0x009D0443 File Offset: 0x009CE643
		// (set) Token: 0x060262F3 RID: 156403 RVA: 0x009D0457 File Offset: 0x009CE657
		public unsafe USkeletalMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponLevelMaterialEditor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponLevelMaterialEditor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170055E6 RID: 21990
		// (get) Token: 0x060262F4 RID: 156404 RVA: 0x009D046C File Offset: 0x009CE66C
		// (set) Token: 0x060262F5 RID: 156405 RVA: 0x009D047C File Offset: 0x009CE67C
		public unsafe int LevelCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WeaponLevelMaterialEditor_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WeaponLevelMaterialEditor_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170055E7 RID: 21991
		// (get) Token: 0x060262F6 RID: 156406 RVA: 0x009D0490 File Offset: 0x009CE690
		// (set) Token: 0x060262F7 RID: 156407 RVA: 0x009D04C9 File Offset: 0x009CE6C9
		[Nullable(1)]
		public TArray<USkeletalMeshComponent> Components
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMeshComponent> result;
				if ((result = this._Components) == null)
				{
					result = (this._Components = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)BP_WeaponLevelMaterialEditor_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Components.CopyAssign(value);
			}
		}

		// Token: 0x170055E8 RID: 21992
		// (get) Token: 0x060262F8 RID: 156408 RVA: 0x009D04D7 File Offset: 0x009CE6D7
		// (set) Token: 0x060262F9 RID: 156409 RVA: 0x009D04EB File Offset: 0x009CE6EB
		public unsafe PD_WeaponLevelMaterialDatas_C Data
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_WeaponLevelMaterialDatas_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponLevelMaterialEditor_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WeaponLevelMaterialEditor_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x060262FA RID: 156410 RVA: 0x009D0500 File Offset: 0x009CE700
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x060262FB RID: 156411 RVA: 0x009D0514 File Offset: 0x009CE714
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060262FC RID: 156412 RVA: 0x009D0528 File Offset: 0x009CE728
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060262FD RID: 156413 RVA: 0x009D0540 File Offset: 0x009CE740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WeaponLevelMaterialEditor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeaponLevelMaterialEditor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponLevelMaterialEditor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponLevelMaterialEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060262FE RID: 156414 RVA: 0x009D0588 File Offset: 0x009CE788
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WeaponLevelMaterialEditor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WeaponLevelMaterialEditor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponLevelMaterialEditor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponLevelMaterialEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060262FF RID: 156415 RVA: 0x009D05D0 File Offset: 0x009CE7D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_WeaponLevelMaterialEditor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WeaponLevelMaterialEditor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponLevelMaterialEditor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponLevelMaterialEditor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026300 RID: 156416 RVA: 0x009D0618 File Offset: 0x009CE818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_WeaponLevelMaterialEditor_C.__EditorTick_FunctionParams* ptr = stackalloc BP_WeaponLevelMaterialEditor_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WeaponLevelMaterialEditor_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponLevelMaterialEditor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026301 RID: 156417 RVA: 0x009D0660 File Offset: 0x009CE860
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WeaponLevelMaterialEditor(int EntryPoint)
		{
			BP_WeaponLevelMaterialEditor_C.__ExecuteUbergraph_BP_WeaponLevelMaterialEditor_FunctionParams* ptr = stackalloc BP_WeaponLevelMaterialEditor_C.__ExecuteUbergraph_BP_WeaponLevelMaterialEditor_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_WeaponLevelMaterialEditor_C.__ExecuteUbergraph_BP_WeaponLevelMaterialEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WeaponLevelMaterialEditor_C.__ExecuteUbergraph_BP_WeaponLevelMaterialEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WeaponLevelMaterialEditor_C.__ExecuteUbergraph_BP_WeaponLevelMaterialEditor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026302 RID: 156418 RVA: 0x009D06A7 File Offset: 0x009CE8A7
		protected BP_WeaponLevelMaterialEditor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C81 RID: 81025
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/BP_WeaponLevelMaterialEditor.BP_WeaponLevelMaterialEditor_C";

		// Token: 0x04013C82 RID: 81026
		private static IntPtr _ClassPtr;

		// Token: 0x04013C83 RID: 81027
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C84 RID: 81028
		internal static int __PropertyOffset_0;

		// Token: 0x04013C85 RID: 81029
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013C86 RID: 81030
		internal static int __PropertyOffset_1;

		// Token: 0x04013C87 RID: 81031
		internal static int __PropertyOffset_2;

		// Token: 0x04013C88 RID: 81032
		internal static int __PropertyOffset_3;

		// Token: 0x04013C89 RID: 81033
		internal static int __PropertyOffset_4;

		// Token: 0x04013C8A RID: 81034
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _Components;

		// Token: 0x04013C8B RID: 81035
		internal static int __PropertyOffset_5;

		// Token: 0x04013C8C RID: 81036
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x04013C8D RID: 81037
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013C8E RID: 81038
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013C8F RID: 81039
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013C90 RID: 81040
		private static IntPtr __ExecuteUbergraph_BP_WeaponLevelMaterialEditor_NativeFunctionPtr;

		// Token: 0x0200A015 RID: 40981
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BFE RID: 207870
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A016 RID: 40982
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032BFF RID: 207871
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A017 RID: 40983
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_WeaponLevelMaterialEditor_FunctionParams
		{
			// Token: 0x04032C00 RID: 207872
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
