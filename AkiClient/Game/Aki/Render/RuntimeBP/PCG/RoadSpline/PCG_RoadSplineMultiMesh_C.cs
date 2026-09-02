using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline.Structure;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B98 RID: 15256
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSplineMultiMesh.PCG_RoadSplineMultiMesh_C")]
	[UnrealStructLayout(1184, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1180)]
	public class PCG_RoadSplineMultiMesh_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021D7E RID: 138622 RVA: 0x009554E2 File Offset: 0x009536E2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PCG_RoadSplineMultiMesh_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSplineMultiMesh.PCG_RoadSplineMultiMesh_C");
			}
			return PCG_RoadSplineMultiMesh_C._ClassPtr;
		}

		// Token: 0x06021D7F RID: 138623 RVA: 0x00955508 File Offset: 0x00953708
		public PCG_RoadSplineMultiMesh_C() : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSplineMultiMesh_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021D80 RID: 138624 RVA: 0x00955530 File Offset: 0x00953730
		public PCG_RoadSplineMultiMesh_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSplineMultiMesh_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D4E RID: 15694
		// (get) Token: 0x06021D81 RID: 138625 RVA: 0x00955563 File Offset: 0x00953763
		// (set) Token: 0x06021D82 RID: 138626 RVA: 0x00955577 File Offset: 0x00953777
		[Nullable(2)]
		public unsafe USplineComponent Spline
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSplineMultiMesh_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSplineMultiMesh_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003D4F RID: 15695
		// (get) Token: 0x06021D83 RID: 138627 RVA: 0x0095558C File Offset: 0x0095378C
		// (set) Token: 0x06021D84 RID: 138628 RVA: 0x009555A0 File Offset: 0x009537A0
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSplineMultiMesh_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSplineMultiMesh_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D50 RID: 15696
		// (get) Token: 0x06021D85 RID: 138629 RVA: 0x009555B5 File Offset: 0x009537B5
		// (set) Token: 0x06021D86 RID: 138630 RVA: 0x009555C5 File Offset: 0x009537C5
		public unsafe bool 启用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D51 RID: 15697
		// (get) Token: 0x06021D87 RID: 138631 RVA: 0x009555D6 File Offset: 0x009537D6
		// (set) Token: 0x06021D88 RID: 138632 RVA: 0x009555E6 File Offset: 0x009537E6
		public unsafe float 吸附偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003D52 RID: 15698
		// (get) Token: 0x06021D89 RID: 138633 RVA: 0x009555F8 File Offset: 0x009537F8
		// (set) Token: 0x06021D8A RID: 138634 RVA: 0x00955631 File Offset: 0x00953831
		public FCollisionProfileName 添加碰撞_测试_
		{
			get
			{
				base.FastCheckIsValid();
				FCollisionProfileName result;
				if ((result = this._添加碰撞_测试_) == null)
				{
					result = (this._添加碰撞_测试_ = new FCollisionProfileName(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCollisionProfileName.StaticStruct(), base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D53 RID: 15699
		// (get) Token: 0x06021D8B RID: 138635 RVA: 0x00955652 File Offset: 0x00953852
		// (set) Token: 0x06021D8C RID: 138636 RVA: 0x00955662 File Offset: 0x00953862
		public unsafe bool 开启自定义深度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D54 RID: 15700
		// (get) Token: 0x06021D8D RID: 138637 RVA: 0x00955674 File Offset: 0x00953874
		// (set) Token: 0x06021D8E RID: 138638 RVA: 0x009556AD File Offset: 0x009538AD
		public TArray<SPCG_RoadPropertyBasedMultiMesh> 模型列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPCG_RoadPropertyBasedMultiMesh> result;
				if ((result = this._模型列表) == null)
				{
					result = (this._模型列表 = new TArray<SPCG_RoadPropertyBasedMultiMesh>(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.模型列表.CopyAssign(value);
			}
		}

		// Token: 0x17003D55 RID: 15701
		// (get) Token: 0x06021D8F RID: 138639 RVA: 0x009556BB File Offset: 0x009538BB
		// (set) Token: 0x06021D90 RID: 138640 RVA: 0x009556CB File Offset: 0x009538CB
		public unsafe float Spline_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003D56 RID: 15702
		// (get) Token: 0x06021D91 RID: 138641 RVA: 0x009556DC File Offset: 0x009538DC
		// (set) Token: 0x06021D92 RID: 138642 RVA: 0x00955715 File Offset: 0x00953915
		public TMap<UMaterialInterface, SPCG_RoadSplineDecalProperity> 贴花列表
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UMaterialInterface, SPCG_RoadSplineDecalProperity> result;
				if ((result = this._贴花列表) == null)
				{
					result = (this._贴花列表 = new TMap<UMaterialInterface, SPCG_RoadSplineDecalProperity>(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.贴花列表.CopyAssign(value);
			}
		}

		// Token: 0x17003D57 RID: 15703
		// (get) Token: 0x06021D93 RID: 138643 RVA: 0x00955723 File Offset: 0x00953923
		// (set) Token: 0x06021D94 RID: 138644 RVA: 0x00955733 File Offset: 0x00953933
		public unsafe bool VertexCompress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D58 RID: 15704
		// (get) Token: 0x06021D95 RID: 138645 RVA: 0x00955744 File Offset: 0x00953944
		// (set) Token: 0x06021D96 RID: 138646 RVA: 0x00955754 File Offset: 0x00953954
		public unsafe bool 低内存设备禁用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D59 RID: 15705
		// (get) Token: 0x06021D97 RID: 138647 RVA: 0x00955765 File Offset: 0x00953965
		// (set) Token: 0x06021D98 RID: 138648 RVA: 0x00955775 File Offset: 0x00953975
		public unsafe int 基于分段数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003D5A RID: 15706
		// (get) Token: 0x06021D99 RID: 138649 RVA: 0x00955786 File Offset: 0x00953986
		// (set) Token: 0x06021D9A RID: 138650 RVA: 0x00955796 File Offset: 0x00953996
		public unsafe float 基于分段长度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSplineMultiMesh_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x06021D9B RID: 138651 RVA: 0x009557A7 File Offset: 0x009539A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 生成贴花()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__生成贴花_NativeFunctionPtr, null);
		}

		// Token: 0x06021D9C RID: 138652 RVA: 0x009557BC File Offset: 0x009539BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRoadMesh(ref UStaticMesh 基础模型)
		{
			PCG_RoadSplineMultiMesh_C.__GetRoadMesh_FunctionParams* ptr = stackalloc PCG_RoadSplineMultiMesh_C.__GetRoadMesh_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(PCG_RoadSplineMultiMesh_C.__GetRoadMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSplineMultiMesh_C.__GetRoadMesh_NativeFunctionPtr, (void*)ptr, 1);
			ref PCG_RoadSplineMultiMesh_C.__GetRoadMesh_FunctionParams ptr2 = ref *ptr;
			UStaticMesh ustaticMesh = 基础模型;
			ptr2.基础模型 = ((ustaticMesh != null) ? ustaticMesh.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__GetRoadMesh_NativeFunctionPtr, (void*)ptr);
			基础模型 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UStaticMesh>(ptr->基础模型);
		}

		// Token: 0x06021D9D RID: 138653 RVA: 0x00955820 File Offset: 0x00953A20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 向下吸附到地形()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__向下吸附到地形_NativeFunctionPtr, null);
		}

		// Token: 0x06021D9E RID: 138654 RVA: 0x00955834 File Offset: 0x00953A34
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMeshNum(SPCG_RoadPropertyBasedMultiMesh Property, ref int Count, ref float StepDistance)
		{
			PCG_RoadSplineMultiMesh_C.__GetMeshNum_FunctionParams* ptr = stackalloc PCG_RoadSplineMultiMesh_C.__GetMeshNum_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(PCG_RoadSplineMultiMesh_C.__GetMeshNum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSplineMultiMesh_C.__GetMeshNum_NativeFunctionPtr, (void*)ptr, 1);
			if (Property != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCG_RoadPropertyBasedMultiMesh.StaticStruct(), &ptr->Property, Property.NativePtr, 1, false);
			}
			ptr->Count = Count;
			ptr->StepDistance = StepDistance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__GetMeshNum_NativeFunctionPtr, (void*)ptr);
			Count = ptr->Count;
			StepDistance = ptr->StepDistance;
		}

		// Token: 0x06021D9F RID: 138655 RVA: 0x009558B8 File Offset: 0x00953AB8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GenerateSplineMesh(SPCG_RoadPropertyBasedMultiMesh Property)
		{
			PCG_RoadSplineMultiMesh_C.__GenerateSplineMesh_FunctionParams* ptr = stackalloc PCG_RoadSplineMultiMesh_C.__GenerateSplineMesh_FunctionParams[(UIntPtr)559] + 15L / (long)sizeof(PCG_RoadSplineMultiMesh_C.__GenerateSplineMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSplineMultiMesh_C.__GenerateSplineMesh_NativeFunctionPtr, (void*)ptr, 1);
			if (Property != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCG_RoadPropertyBasedMultiMesh.StaticStruct(), &ptr->Property, Property.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__GenerateSplineMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021DA0 RID: 138656 RVA: 0x0095591C File Offset: 0x00953B1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021DA1 RID: 138657 RVA: 0x00955930 File Offset: 0x00953B30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PCG_RoadSplineMultiMesh_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021DA2 RID: 138658 RVA: 0x00955945 File Offset: 0x00953B45
		protected PCG_RoadSplineMultiMesh_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401114E RID: 69966
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSplineMultiMesh.PCG_RoadSplineMultiMesh_C";

		// Token: 0x0401114F RID: 69967
		private static IntPtr _ClassPtr;

		// Token: 0x04011150 RID: 69968
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011151 RID: 69969
		internal static int __PropertyOffset_0;

		// Token: 0x04011152 RID: 69970
		internal static int __PropertyOffset_1;

		// Token: 0x04011153 RID: 69971
		internal static int __PropertyOffset_2;

		// Token: 0x04011154 RID: 69972
		internal static int __PropertyOffset_3;

		// Token: 0x04011155 RID: 69973
		internal static int __PropertyOffset_4;

		// Token: 0x04011156 RID: 69974
		[Nullable(2)]
		private FCollisionProfileName _添加碰撞_测试_;

		// Token: 0x04011157 RID: 69975
		internal static int __PropertyOffset_5;

		// Token: 0x04011158 RID: 69976
		internal static int __PropertyOffset_6;

		// Token: 0x04011159 RID: 69977
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPCG_RoadPropertyBasedMultiMesh> _模型列表;

		// Token: 0x0401115A RID: 69978
		internal static int __PropertyOffset_7;

		// Token: 0x0401115B RID: 69979
		internal static int __PropertyOffset_8;

		// Token: 0x0401115C RID: 69980
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<UMaterialInterface, SPCG_RoadSplineDecalProperity> _贴花列表;

		// Token: 0x0401115D RID: 69981
		internal static int __PropertyOffset_9;

		// Token: 0x0401115E RID: 69982
		internal static int __PropertyOffset_10;

		// Token: 0x0401115F RID: 69983
		internal static int __PropertyOffset_11;

		// Token: 0x04011160 RID: 69984
		internal static int __PropertyOffset_12;

		// Token: 0x04011161 RID: 69985
		private static IntPtr __生成贴花_NativeFunctionPtr;

		// Token: 0x04011162 RID: 69986
		private static IntPtr __GetRoadMesh_NativeFunctionPtr;

		// Token: 0x04011163 RID: 69987
		private static IntPtr __向下吸附到地形_NativeFunctionPtr;

		// Token: 0x04011164 RID: 69988
		private static IntPtr __GetMeshNum_NativeFunctionPtr;

		// Token: 0x04011165 RID: 69989
		private static IntPtr __GenerateSplineMesh_NativeFunctionPtr;

		// Token: 0x04011166 RID: 69990
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x02009B63 RID: 39779
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __GetRoadMesh_FunctionParams
		{
			// Token: 0x04032352 RID: 205650
			[FieldOffset(0)]
			public IntPtr 基础模型;
		}

		// Token: 0x02009B64 RID: 39780
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __GetMeshNum_FunctionParams
		{
			// Token: 0x04032353 RID: 205651
			[FieldOffset(0)]
			public byte Property;

			// Token: 0x04032354 RID: 205652
			[FieldOffset(40)]
			public int Count;

			// Token: 0x04032355 RID: 205653
			[FieldOffset(44)]
			public float StepDistance;
		}

		// Token: 0x02009B65 RID: 39781
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 544)]
		protected ref struct __GenerateSplineMesh_FunctionParams
		{
			// Token: 0x04032356 RID: 205654
			[FieldOffset(0)]
			public byte Property;
		}
	}
}
