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
	// Token: 0x02003B9A RID: 15258
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline_DiffeEnd.PCG_RoadSpline_DiffeEnd_C")]
	[UnrealStructLayout(1208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1202)]
	public class PCG_RoadSpline_DiffeEnd_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021DF2 RID: 138738 RVA: 0x0095615B File Offset: 0x0095435B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PCG_RoadSpline_DiffeEnd_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline_DiffeEnd.PCG_RoadSpline_DiffeEnd_C");
			}
			return PCG_RoadSpline_DiffeEnd_C._ClassPtr;
		}

		// Token: 0x06021DF3 RID: 138739 RVA: 0x00956180 File Offset: 0x00954380
		public PCG_RoadSpline_DiffeEnd_C() : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSpline_DiffeEnd_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021DF4 RID: 138740 RVA: 0x009561A8 File Offset: 0x009543A8
		[NullableContext(1)]
		public PCG_RoadSpline_DiffeEnd_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSpline_DiffeEnd_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D7A RID: 15738
		// (get) Token: 0x06021DF5 RID: 138741 RVA: 0x009561DB File Offset: 0x009543DB
		// (set) Token: 0x06021DF6 RID: 138742 RVA: 0x009561EF File Offset: 0x009543EF
		public unsafe UStaticMeshComponent StaticMesh1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003D7B RID: 15739
		// (get) Token: 0x06021DF7 RID: 138743 RVA: 0x00956204 File Offset: 0x00954404
		// (set) Token: 0x06021DF8 RID: 138744 RVA: 0x00956218 File Offset: 0x00954418
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D7C RID: 15740
		// (get) Token: 0x06021DF9 RID: 138745 RVA: 0x0095622D File Offset: 0x0095442D
		// (set) Token: 0x06021DFA RID: 138746 RVA: 0x00956241 File Offset: 0x00954441
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D7D RID: 15741
		// (get) Token: 0x06021DFB RID: 138747 RVA: 0x00956256 File Offset: 0x00954456
		// (set) Token: 0x06021DFC RID: 138748 RVA: 0x0095626A File Offset: 0x0095446A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003D7E RID: 15742
		// (get) Token: 0x06021DFD RID: 138749 RVA: 0x0095627F File Offset: 0x0095447F
		// (set) Token: 0x06021DFE RID: 138750 RVA: 0x0095628F File Offset: 0x0095448F
		public unsafe float 吸附偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003D7F RID: 15743
		// (get) Token: 0x06021DFF RID: 138751 RVA: 0x009562A0 File Offset: 0x009544A0
		// (set) Token: 0x06021E00 RID: 138752 RVA: 0x009562B0 File Offset: 0x009544B0
		public unsafe bool 启用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D80 RID: 15744
		// (get) Token: 0x06021E01 RID: 138753 RVA: 0x009562C1 File Offset: 0x009544C1
		// (set) Token: 0x06021E02 RID: 138754 RVA: 0x009562D5 File Offset: 0x009544D5
		public unsafe AActor SplineActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003D81 RID: 15745
		// (get) Token: 0x06021E03 RID: 138755 RVA: 0x009562EC File Offset: 0x009544EC
		// (set) Token: 0x06021E04 RID: 138756 RVA: 0x00956325 File Offset: 0x00954525
		[Nullable(1)]
		public FCollisionProfileName 添加碰撞__测试_
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FCollisionProfileName result;
				if ((result = this._添加碰撞__测试_) == null)
				{
					result = (this._添加碰撞__测试_ = new FCollisionProfileName(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FCollisionProfileName.StaticStruct(), base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D82 RID: 15746
		// (get) Token: 0x06021E05 RID: 138757 RVA: 0x00956346 File Offset: 0x00954546
		// (set) Token: 0x06021E06 RID: 138758 RVA: 0x0095635A File Offset: 0x0095455A
		public unsafe FVector UpDirection__测试_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003D83 RID: 15747
		// (get) Token: 0x06021E07 RID: 138759 RVA: 0x0095636F File Offset: 0x0095456F
		// (set) Token: 0x06021E08 RID: 138760 RVA: 0x0095637F File Offset: 0x0095457F
		public unsafe bool 开启自定义深度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D84 RID: 15748
		// (get) Token: 0x06021E09 RID: 138761 RVA: 0x00956390 File Offset: 0x00954590
		// (set) Token: 0x06021E0A RID: 138762 RVA: 0x009563C9 File Offset: 0x009545C9
		[Nullable(1)]
		public SPCG_RoadPropertyBased 属性列表
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SPCG_RoadPropertyBased result;
				if ((result = this._属性列表) == null)
				{
					result = (this._属性列表 = new SPCG_RoadPropertyBased(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCG_RoadPropertyBased.StaticStruct(), base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003D85 RID: 15749
		// (get) Token: 0x06021E0B RID: 138763 RVA: 0x009563EC File Offset: 0x009545EC
		// (set) Token: 0x06021E0C RID: 138764 RVA: 0x00956425 File Offset: 0x00954625
		[Nullable(1)]
		public TArray<UStaticMesh> 封口模型
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._封口模型) == null)
				{
					result = (this._封口模型 = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.封口模型.CopyAssign(value);
			}
		}

		// Token: 0x17003D86 RID: 15750
		// (get) Token: 0x06021E0D RID: 138765 RVA: 0x00956433 File Offset: 0x00954633
		// (set) Token: 0x06021E0E RID: 138766 RVA: 0x00956447 File Offset: 0x00954647
		public unsafe FVector 封口偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003D87 RID: 15751
		// (get) Token: 0x06021E0F RID: 138767 RVA: 0x0095645C File Offset: 0x0095465C
		// (set) Token: 0x06021E10 RID: 138768 RVA: 0x0095646C File Offset: 0x0095466C
		public unsafe float 封口旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003D88 RID: 15752
		// (get) Token: 0x06021E11 RID: 138769 RVA: 0x0095647D File Offset: 0x0095467D
		// (set) Token: 0x06021E12 RID: 138770 RVA: 0x0095648D File Offset: 0x0095468D
		public unsafe bool VertexCompress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D89 RID: 15753
		// (get) Token: 0x06021E13 RID: 138771 RVA: 0x0095649E File Offset: 0x0095469E
		// (set) Token: 0x06021E14 RID: 138772 RVA: 0x009564AE File Offset: 0x009546AE
		public unsafe bool 低内存设备禁用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_DiffeEnd_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021E15 RID: 138773 RVA: 0x009564C0 File Offset: 0x009546C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRoadWidth(bool IgnoreScale, ref float Width)
		{
			PCG_RoadSpline_DiffeEnd_C.__GetRoadWidth_FunctionParams* ptr = stackalloc PCG_RoadSpline_DiffeEnd_C.__GetRoadWidth_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(PCG_RoadSpline_DiffeEnd_C.__GetRoadWidth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_DiffeEnd_C.__GetRoadWidth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IgnoreScale = IgnoreScale;
			ptr->Width = Width;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__GetRoadWidth_NativeFunctionPtr, (void*)ptr);
			Width = ptr->Width;
		}

		// Token: 0x06021E16 RID: 138774 RVA: 0x00956518 File Offset: 0x00954718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetRoadMesh(ref UStaticMesh 基础模型)
		{
			PCG_RoadSpline_DiffeEnd_C.__GetRoadMesh_FunctionParams* ptr = stackalloc PCG_RoadSpline_DiffeEnd_C.__GetRoadMesh_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(PCG_RoadSpline_DiffeEnd_C.__GetRoadMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_DiffeEnd_C.__GetRoadMesh_NativeFunctionPtr, (void*)ptr, 1);
			ref PCG_RoadSpline_DiffeEnd_C.__GetRoadMesh_FunctionParams ptr2 = ref *ptr;
			UStaticMesh ustaticMesh = 基础模型;
			ptr2.基础模型 = ((ustaticMesh != null) ? ustaticMesh.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__GetRoadMesh_NativeFunctionPtr, (void*)ptr);
			基础模型 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UStaticMesh>(ptr->基础模型);
		}

		// Token: 0x06021E17 RID: 138775 RVA: 0x0095657C File Offset: 0x0095477C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CopyToSplineActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__CopyToSplineActor_NativeFunctionPtr, null);
		}

		// Token: 0x06021E18 RID: 138776 RVA: 0x00956590 File Offset: 0x00954790
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CopySplineActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__CopySplineActor_NativeFunctionPtr, null);
		}

		// Token: 0x06021E19 RID: 138777 RVA: 0x009565A4 File Offset: 0x009547A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 向下吸附到地形()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__向下吸附到地形_NativeFunctionPtr, null);
		}

		// Token: 0x06021E1A RID: 138778 RVA: 0x009565B8 File Offset: 0x009547B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateEndCaps()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__GenerateEndCaps_NativeFunctionPtr, null);
		}

		// Token: 0x06021E1B RID: 138779 RVA: 0x009565CC File Offset: 0x009547CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GenerateMesh(bool ByPoint)
		{
			PCG_RoadSpline_DiffeEnd_C.__GenerateMesh_FunctionParams* ptr = stackalloc PCG_RoadSpline_DiffeEnd_C.__GenerateMesh_FunctionParams[(UIntPtr)911] + 15L / (long)sizeof(PCG_RoadSpline_DiffeEnd_C.__GenerateMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(PCG_RoadSpline_DiffeEnd_C.__GenerateMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ByPoint = ByPoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__GenerateMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021E1C RID: 138780 RVA: 0x00956615 File Offset: 0x00954815
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021E1D RID: 138781 RVA: 0x00956629 File Offset: 0x00954829
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PCG_RoadSpline_DiffeEnd_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021E1E RID: 138782 RVA: 0x0095663E File Offset: 0x0095483E
		protected PCG_RoadSpline_DiffeEnd_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011197 RID: 70039
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline_DiffeEnd.PCG_RoadSpline_DiffeEnd_C";

		// Token: 0x04011198 RID: 70040
		private static IntPtr _ClassPtr;

		// Token: 0x04011199 RID: 70041
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401119A RID: 70042
		internal static int __PropertyOffset_0;

		// Token: 0x0401119B RID: 70043
		internal static int __PropertyOffset_1;

		// Token: 0x0401119C RID: 70044
		internal static int __PropertyOffset_2;

		// Token: 0x0401119D RID: 70045
		internal static int __PropertyOffset_3;

		// Token: 0x0401119E RID: 70046
		internal static int __PropertyOffset_4;

		// Token: 0x0401119F RID: 70047
		internal static int __PropertyOffset_5;

		// Token: 0x040111A0 RID: 70048
		internal static int __PropertyOffset_6;

		// Token: 0x040111A1 RID: 70049
		internal static int __PropertyOffset_7;

		// Token: 0x040111A2 RID: 70050
		private FCollisionProfileName _添加碰撞__测试_;

		// Token: 0x040111A3 RID: 70051
		internal static int __PropertyOffset_8;

		// Token: 0x040111A4 RID: 70052
		internal static int __PropertyOffset_9;

		// Token: 0x040111A5 RID: 70053
		internal static int __PropertyOffset_10;

		// Token: 0x040111A6 RID: 70054
		private SPCG_RoadPropertyBased _属性列表;

		// Token: 0x040111A7 RID: 70055
		internal static int __PropertyOffset_11;

		// Token: 0x040111A8 RID: 70056
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _封口模型;

		// Token: 0x040111A9 RID: 70057
		internal static int __PropertyOffset_12;

		// Token: 0x040111AA RID: 70058
		internal static int __PropertyOffset_13;

		// Token: 0x040111AB RID: 70059
		internal static int __PropertyOffset_14;

		// Token: 0x040111AC RID: 70060
		internal static int __PropertyOffset_15;

		// Token: 0x040111AD RID: 70061
		private static IntPtr __GetRoadWidth_NativeFunctionPtr;

		// Token: 0x040111AE RID: 70062
		private static IntPtr __GetRoadMesh_NativeFunctionPtr;

		// Token: 0x040111AF RID: 70063
		private static IntPtr __CopyToSplineActor_NativeFunctionPtr;

		// Token: 0x040111B0 RID: 70064
		private static IntPtr __CopySplineActor_NativeFunctionPtr;

		// Token: 0x040111B1 RID: 70065
		private static IntPtr __向下吸附到地形_NativeFunctionPtr;

		// Token: 0x040111B2 RID: 70066
		private static IntPtr __GenerateEndCaps_NativeFunctionPtr;

		// Token: 0x040111B3 RID: 70067
		private static IntPtr __GenerateMesh_NativeFunctionPtr;

		// Token: 0x040111B4 RID: 70068
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x02009B6B RID: 39787
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __GetRoadWidth_FunctionParams
		{
			// Token: 0x0403235D RID: 205661
			[FieldOffset(0)]
			public bool IgnoreScale;

			// Token: 0x0403235E RID: 205662
			[FieldOffset(4)]
			public float Width;
		}

		// Token: 0x02009B6C RID: 39788
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetRoadMesh_FunctionParams
		{
			// Token: 0x0403235F RID: 205663
			[FieldOffset(0)]
			public IntPtr 基础模型;
		}

		// Token: 0x02009B6D RID: 39789
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 896)]
		protected ref struct __GenerateMesh_FunctionParams
		{
			// Token: 0x04032360 RID: 205664
			[FieldOffset(0)]
			public bool ByPoint;
		}
	}
}
