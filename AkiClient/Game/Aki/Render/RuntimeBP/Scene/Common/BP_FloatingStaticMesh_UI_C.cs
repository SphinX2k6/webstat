using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003ADA RID: 15066
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh_UI.BP_FloatingStaticMesh_UI_C")]
	[UnrealStructLayout(2640, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2632)]
	public class BP_FloatingStaticMesh_UI_C : AKuroFloatingStaticMesh, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602040B RID: 132107 RVA: 0x009269C0 File Offset: 0x00924BC0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FloatingStaticMesh_UI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh_UI.BP_FloatingStaticMesh_UI_C");
			}
			return BP_FloatingStaticMesh_UI_C._ClassPtr;
		}

		// Token: 0x0602040C RID: 132108 RVA: 0x009269E4 File Offset: 0x00924BE4
		public BP_FloatingStaticMesh_UI_C() : this(BuiltinUtils.AllocNativeUObject(BP_FloatingStaticMesh_UI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602040D RID: 132109 RVA: 0x00926A0C File Offset: 0x00924C0C
		public BP_FloatingStaticMesh_UI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FloatingStaticMesh_UI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034A7 RID: 13479
		// (get) Token: 0x0602040E RID: 132110 RVA: 0x00926A40 File Offset: 0x00924C40
		// (set) Token: 0x0602040F RID: 132111 RVA: 0x00926A79 File Offset: 0x00924C79
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034A8 RID: 13480
		// (get) Token: 0x06020410 RID: 132112 RVA: 0x00926A9A File Offset: 0x00924C9A
		// (set) Token: 0x06020411 RID: 132113 RVA: 0x00926AAE File Offset: 0x00924CAE
		[Nullable(2)]
		public unsafe UKuroVirtualAttachmentParentComponent KuroVirtualAttachmentParent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVirtualAttachmentParentComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_UI_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_UI_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170034A9 RID: 13481
		// (get) Token: 0x06020412 RID: 132114 RVA: 0x00926AC3 File Offset: 0x00924CC3
		// (set) Token: 0x06020413 RID: 132115 RVA: 0x00926AD7 File Offset: 0x00924CD7
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMeshComp
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_UI_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_UI_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170034AA RID: 13482
		// (get) Token: 0x06020414 RID: 132116 RVA: 0x00926AEC File Offset: 0x00924CEC
		// (set) Token: 0x06020415 RID: 132117 RVA: 0x00926B00 File Offset: 0x00924D00
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_UI_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FloatingStaticMesh_UI_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170034AB RID: 13483
		// (get) Token: 0x06020416 RID: 132118 RVA: 0x00926B15 File Offset: 0x00924D15
		// (set) Token: 0x06020417 RID: 132119 RVA: 0x00926B25 File Offset: 0x00924D25
		public unsafe bool 使用材质参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034AC RID: 13484
		// (get) Token: 0x06020418 RID: 132120 RVA: 0x00926B38 File Offset: 0x00924D38
		// (set) Token: 0x06020419 RID: 132121 RVA: 0x00926B71 File Offset: 0x00924D71
		public TMap<FName, float> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x170034AD RID: 13485
		// (get) Token: 0x0602041A RID: 132122 RVA: 0x00926B80 File Offset: 0x00924D80
		// (set) Token: 0x0602041B RID: 132123 RVA: 0x00926BB9 File Offset: 0x00924DB9
		public TMap<FName, FLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x170034AE RID: 13486
		// (get) Token: 0x0602041C RID: 132124 RVA: 0x00926BC7 File Offset: 0x00924DC7
		// (set) Token: 0x0602041D RID: 132125 RVA: 0x00926BDB File Offset: 0x00924DDB
		public unsafe FLinearColor EmissionDayColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170034AF RID: 13487
		// (get) Token: 0x0602041E RID: 132126 RVA: 0x00926BF0 File Offset: 0x00924DF0
		// (set) Token: 0x0602041F RID: 132127 RVA: 0x00926C04 File Offset: 0x00924E04
		public unsafe FLinearColor EmissionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170034B0 RID: 13488
		// (get) Token: 0x06020420 RID: 132128 RVA: 0x00926C19 File Offset: 0x00924E19
		// (set) Token: 0x06020421 RID: 132129 RVA: 0x00926C29 File Offset: 0x00924E29
		public unsafe bool UseWholeDayEmission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170034B1 RID: 13489
		// (get) Token: 0x06020422 RID: 132130 RVA: 0x00926C3C File Offset: 0x00924E3C
		// (set) Token: 0x06020423 RID: 132131 RVA: 0x00926C75 File Offset: 0x00924E75
		public TMap<AActor, FTransformDouble> ChildActors
		{
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FTransformDouble> result;
				if ((result = this._ChildActors) == null)
				{
					result = (this._ChildActors = new TMap<AActor, FTransformDouble>(base.NativePtr + (IntPtr)BP_FloatingStaticMesh_UI_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.ChildActors.CopyAssign(value);
			}
		}

		// Token: 0x06020424 RID: 132132 RVA: 0x00926C83 File Offset: 0x00924E83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshChildActors()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__RefreshChildActors_NativeFunctionPtr, null);
		}

		// Token: 0x06020425 RID: 132133 RVA: 0x00926C97 File Offset: 0x00924E97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMaterialParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__SetMaterialParams_NativeFunctionPtr, null);
		}

		// Token: 0x06020426 RID: 132134 RVA: 0x00926CAB File Offset: 0x00924EAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020427 RID: 132135 RVA: 0x00926CBF File Offset: 0x00924EBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020428 RID: 132136 RVA: 0x00926CD4 File Offset: 0x00924ED4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020429 RID: 132137 RVA: 0x00926CE8 File Offset: 0x00924EE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602042A RID: 132138 RVA: 0x00926D00 File Offset: 0x00924F00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FloatingStaticMesh_UI(int EntryPoint)
		{
			BP_FloatingStaticMesh_UI_C.__ExecuteUbergraph_BP_FloatingStaticMesh_UI_FunctionParams* ptr = stackalloc BP_FloatingStaticMesh_UI_C.__ExecuteUbergraph_BP_FloatingStaticMesh_UI_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_FloatingStaticMesh_UI_C.__ExecuteUbergraph_BP_FloatingStaticMesh_UI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FloatingStaticMesh_UI_C.__ExecuteUbergraph_BP_FloatingStaticMesh_UI_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FloatingStaticMesh_UI_C.__ExecuteUbergraph_BP_FloatingStaticMesh_UI_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602042B RID: 132139 RVA: 0x00926D47 File Offset: 0x00924F47
		protected BP_FloatingStaticMesh_UI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401016A RID: 65898
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_FloatingStaticMesh_UI.BP_FloatingStaticMesh_UI_C";

		// Token: 0x0401016B RID: 65899
		private static IntPtr _ClassPtr;

		// Token: 0x0401016C RID: 65900
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401016D RID: 65901
		internal static int __PropertyOffset_0;

		// Token: 0x0401016E RID: 65902
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401016F RID: 65903
		internal static int __PropertyOffset_1;

		// Token: 0x04010170 RID: 65904
		internal static int __PropertyOffset_2;

		// Token: 0x04010171 RID: 65905
		internal static int __PropertyOffset_3;

		// Token: 0x04010172 RID: 65906
		internal static int __PropertyOffset_4;

		// Token: 0x04010173 RID: 65907
		internal static int __PropertyOffset_5;

		// Token: 0x04010174 RID: 65908
		[Nullable(2)]
		private TMap<FName, float> _FloatParameters;

		// Token: 0x04010175 RID: 65909
		internal static int __PropertyOffset_6;

		// Token: 0x04010176 RID: 65910
		[Nullable(2)]
		private TMap<FName, FLinearColor> _ColorParameters;

		// Token: 0x04010177 RID: 65911
		internal static int __PropertyOffset_7;

		// Token: 0x04010178 RID: 65912
		internal static int __PropertyOffset_8;

		// Token: 0x04010179 RID: 65913
		internal static int __PropertyOffset_9;

		// Token: 0x0401017A RID: 65914
		internal static int __PropertyOffset_10;

		// Token: 0x0401017B RID: 65915
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<AActor, FTransformDouble> _ChildActors;

		// Token: 0x0401017C RID: 65916
		private static IntPtr __RefreshChildActors_NativeFunctionPtr;

		// Token: 0x0401017D RID: 65917
		private static IntPtr __SetMaterialParams_NativeFunctionPtr;

		// Token: 0x0401017E RID: 65918
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401017F RID: 65919
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010180 RID: 65920
		private static IntPtr __ExecuteUbergraph_BP_FloatingStaticMesh_UI_NativeFunctionPtr;

		// Token: 0x02009981 RID: 39297
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_FloatingStaticMesh_UI_FunctionParams
		{
			// Token: 0x04032007 RID: 204807
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
