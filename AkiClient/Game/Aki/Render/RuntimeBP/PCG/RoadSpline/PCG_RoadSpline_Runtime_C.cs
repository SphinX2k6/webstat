using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.RoadSpline
{
	// Token: 0x02003B9B RID: 15259
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline_Runtime.PCG_RoadSpline_Runtime_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class PCG_RoadSpline_Runtime_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021E1F RID: 138783 RVA: 0x00956647 File Offset: 0x00954847
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PCG_RoadSpline_Runtime_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline_Runtime.PCG_RoadSpline_Runtime_C");
			}
			return PCG_RoadSpline_Runtime_C._ClassPtr;
		}

		// Token: 0x06021E20 RID: 138784 RVA: 0x0095666C File Offset: 0x0095486C
		public PCG_RoadSpline_Runtime_C() : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSpline_Runtime_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021E21 RID: 138785 RVA: 0x00956694 File Offset: 0x00954894
		[NullableContext(1)]
		public PCG_RoadSpline_Runtime_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PCG_RoadSpline_Runtime_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003D8A RID: 15754
		// (get) Token: 0x06021E22 RID: 138786 RVA: 0x009566C7 File Offset: 0x009548C7
		// (set) Token: 0x06021E23 RID: 138787 RVA: 0x009566DB File Offset: 0x009548DB
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_Runtime_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_Runtime_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003D8B RID: 15755
		// (get) Token: 0x06021E24 RID: 138788 RVA: 0x009566F0 File Offset: 0x009548F0
		// (set) Token: 0x06021E25 RID: 138789 RVA: 0x00956704 File Offset: 0x00954904
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_Runtime_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_Runtime_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003D8C RID: 15756
		// (get) Token: 0x06021E26 RID: 138790 RVA: 0x00956719 File Offset: 0x00954919
		// (set) Token: 0x06021E27 RID: 138791 RVA: 0x0095672D File Offset: 0x0095492D
		public unsafe UStaticMesh 预览模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_Runtime_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_RoadSpline_Runtime_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003D8D RID: 15757
		// (get) Token: 0x06021E28 RID: 138792 RVA: 0x00956742 File Offset: 0x00954942
		// (set) Token: 0x06021E29 RID: 138793 RVA: 0x00956752 File Offset: 0x00954952
		public unsafe float 宽度缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003D8E RID: 15758
		// (get) Token: 0x06021E2A RID: 138794 RVA: 0x00956763 File Offset: 0x00954963
		// (set) Token: 0x06021E2B RID: 138795 RVA: 0x00956773 File Offset: 0x00954973
		public unsafe float 长度缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003D8F RID: 15759
		// (get) Token: 0x06021E2C RID: 138796 RVA: 0x00956784 File Offset: 0x00954984
		// (set) Token: 0x06021E2D RID: 138797 RVA: 0x00956794 File Offset: 0x00954994
		public unsafe bool 均匀分布
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003D90 RID: 15760
		// (get) Token: 0x06021E2E RID: 138798 RVA: 0x009567A5 File Offset: 0x009549A5
		// (set) Token: 0x06021E2F RID: 138799 RVA: 0x009567B5 File Offset: 0x009549B5
		public unsafe float 分布缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_RoadSpline_Runtime_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06021E30 RID: 138800 RVA: 0x009567C6 File Offset: 0x009549C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateMeshByLenght()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_Runtime_C.__GenerateMeshByLenght_NativeFunctionPtr, null);
		}

		// Token: 0x06021E31 RID: 138801 RVA: 0x009567DA File Offset: 0x009549DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GenerateMeshByPoint()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_Runtime_C.__GenerateMeshByPoint_NativeFunctionPtr, null);
		}

		// Token: 0x06021E32 RID: 138802 RVA: 0x009567EE File Offset: 0x009549EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, PCG_RoadSpline_Runtime_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021E33 RID: 138803 RVA: 0x00956802 File Offset: 0x00954A02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, PCG_RoadSpline_Runtime_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021E34 RID: 138804 RVA: 0x00956817 File Offset: 0x00954A17
		protected PCG_RoadSpline_Runtime_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040111B5 RID: 70069
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/RoadSpline/PCG_RoadSpline_Runtime.PCG_RoadSpline_Runtime_C";

		// Token: 0x040111B6 RID: 70070
		private static IntPtr _ClassPtr;

		// Token: 0x040111B7 RID: 70071
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040111B8 RID: 70072
		internal static int __PropertyOffset_0;

		// Token: 0x040111B9 RID: 70073
		internal static int __PropertyOffset_1;

		// Token: 0x040111BA RID: 70074
		internal static int __PropertyOffset_2;

		// Token: 0x040111BB RID: 70075
		internal static int __PropertyOffset_3;

		// Token: 0x040111BC RID: 70076
		internal static int __PropertyOffset_4;

		// Token: 0x040111BD RID: 70077
		internal static int __PropertyOffset_5;

		// Token: 0x040111BE RID: 70078
		internal static int __PropertyOffset_6;

		// Token: 0x040111BF RID: 70079
		private static IntPtr __GenerateMeshByLenght_NativeFunctionPtr;

		// Token: 0x040111C0 RID: 70080
		private static IntPtr __GenerateMeshByPoint_NativeFunctionPtr;

		// Token: 0x040111C1 RID: 70081
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
