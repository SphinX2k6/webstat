using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.FlowmapActor
{
	// Token: 0x02003C33 RID: 15411
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/FlowmapActor/BP_FlowmapActor.BP_FlowmapActor_C")]
	[UnrealStructLayout(1344, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1344)]
	public class BP_FlowmapActor_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023504 RID: 144644 RVA: 0x0097E82C File Offset: 0x0097CA2C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FlowmapActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/FlowmapActor/BP_FlowmapActor.BP_FlowmapActor_C");
			}
			return BP_FlowmapActor_C._ClassPtr;
		}

		// Token: 0x06023505 RID: 144645 RVA: 0x0097E850 File Offset: 0x0097CA50
		public BP_FlowmapActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_FlowmapActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023506 RID: 144646 RVA: 0x0097E878 File Offset: 0x0097CA78
		[NullableContext(1)]
		public BP_FlowmapActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FlowmapActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045B5 RID: 17845
		// (get) Token: 0x06023507 RID: 144647 RVA: 0x0097E8AC File Offset: 0x0097CAAC
		// (set) Token: 0x06023508 RID: 144648 RVA: 0x0097E8E5 File Offset: 0x0097CAE5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FlowmapActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FlowmapActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045B6 RID: 17846
		// (get) Token: 0x06023509 RID: 144649 RVA: 0x0097E906 File Offset: 0x0097CB06
		// (set) Token: 0x0602350A RID: 144650 RVA: 0x0097E91A File Offset: 0x0097CB1A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045B7 RID: 17847
		// (get) Token: 0x0602350B RID: 144651 RVA: 0x0097E92F File Offset: 0x0097CB2F
		// (set) Token: 0x0602350C RID: 144652 RVA: 0x0097E943 File Offset: 0x0097CB43
		public unsafe UStaticMesh WaterMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045B8 RID: 17848
		// (get) Token: 0x0602350D RID: 144653 RVA: 0x0097E958 File Offset: 0x0097CB58
		// (set) Token: 0x0602350E RID: 144654 RVA: 0x0097E96C File Offset: 0x0097CB6C
		public unsafe UMaterialInterface M_SVT_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170045B9 RID: 17849
		// (get) Token: 0x0602350F RID: 144655 RVA: 0x0097E981 File Offset: 0x0097CB81
		// (set) Token: 0x06023510 RID: 144656 RVA: 0x0097E995 File Offset: 0x0097CB95
		public unsafe UMaterialInterface M_Vertex_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FlowmapActor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06023511 RID: 144657 RVA: 0x0097E9AA File Offset: 0x0097CBAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlowmapActor_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023512 RID: 144658 RVA: 0x0097E9BE File Offset: 0x0097CBBE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlowmapActor_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023513 RID: 144659 RVA: 0x0097E9D3 File Offset: 0x0097CBD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlowmapActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023514 RID: 144660 RVA: 0x0097E9E7 File Offset: 0x0097CBE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlowmapActor_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023515 RID: 144661 RVA: 0x0097E9FC File Offset: 0x0097CBFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FlowmapActor_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06023516 RID: 144662 RVA: 0x0097EA10 File Offset: 0x0097CC10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FlowmapActor(int EntryPoint)
		{
			BP_FlowmapActor_C.__ExecuteUbergraph_BP_FlowmapActor_FunctionParams* ptr = stackalloc BP_FlowmapActor_C.__ExecuteUbergraph_BP_FlowmapActor_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_FlowmapActor_C.__ExecuteUbergraph_BP_FlowmapActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FlowmapActor_C.__ExecuteUbergraph_BP_FlowmapActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FlowmapActor_C.__ExecuteUbergraph_BP_FlowmapActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023517 RID: 144663 RVA: 0x0097EA57 File Offset: 0x0097CC57
		protected BP_FlowmapActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F6E RID: 73582
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/FlowmapActor/BP_FlowmapActor.BP_FlowmapActor_C";

		// Token: 0x04011F6F RID: 73583
		private static IntPtr _ClassPtr;

		// Token: 0x04011F70 RID: 73584
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011F71 RID: 73585
		internal static int __PropertyOffset_0;

		// Token: 0x04011F72 RID: 73586
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011F73 RID: 73587
		internal static int __PropertyOffset_1;

		// Token: 0x04011F74 RID: 73588
		internal static int __PropertyOffset_2;

		// Token: 0x04011F75 RID: 73589
		internal static int __PropertyOffset_3;

		// Token: 0x04011F76 RID: 73590
		internal static int __PropertyOffset_4;

		// Token: 0x04011F77 RID: 73591
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011F78 RID: 73592
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011F79 RID: 73593
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x04011F7A RID: 73594
		private static IntPtr __ExecuteUbergraph_BP_FlowmapActor_NativeFunctionPtr;

		// Token: 0x02009CBD RID: 40125
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_FlowmapActor_FunctionParams
		{
			// Token: 0x0403261F RID: 206367
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
