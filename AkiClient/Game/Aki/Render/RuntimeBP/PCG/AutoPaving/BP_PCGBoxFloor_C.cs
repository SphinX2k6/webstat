using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AutoPaving
{
	// Token: 0x02003C48 RID: 15432
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGBoxFloor.BP_PCGBoxFloor_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1084)]
	public class BP_PCGBoxFloor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023856 RID: 145494 RVA: 0x0098483F File Offset: 0x00982A3F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PCGBoxFloor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGBoxFloor.BP_PCGBoxFloor_C");
			}
			return BP_PCGBoxFloor_C._ClassPtr;
		}

		// Token: 0x06023857 RID: 145495 RVA: 0x00984864 File Offset: 0x00982A64
		public BP_PCGBoxFloor_C() : this(BuiltinUtils.AllocNativeUObject(BP_PCGBoxFloor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023858 RID: 145496 RVA: 0x0098488C File Offset: 0x00982A8C
		[NullableContext(1)]
		public BP_PCGBoxFloor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PCGBoxFloor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046E2 RID: 18146
		// (get) Token: 0x06023859 RID: 145497 RVA: 0x009848BF File Offset: 0x00982ABF
		// (set) Token: 0x0602385A RID: 145498 RVA: 0x009848D3 File Offset: 0x00982AD3
		public unsafe UHierarchicalInstancedStaticMeshComponent HierarchicalInstancedStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHierarchicalInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170046E3 RID: 18147
		// (get) Token: 0x0602385B RID: 145499 RVA: 0x009848E8 File Offset: 0x00982AE8
		// (set) Token: 0x0602385C RID: 145500 RVA: 0x009848FC File Offset: 0x00982AFC
		public unsafe UInstancedStaticMeshComponent InstancedStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UInstancedStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046E4 RID: 18148
		// (get) Token: 0x0602385D RID: 145501 RVA: 0x00984911 File Offset: 0x00982B11
		// (set) Token: 0x0602385E RID: 145502 RVA: 0x00984925 File Offset: 0x00982B25
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046E5 RID: 18149
		// (get) Token: 0x0602385F RID: 145503 RVA: 0x0098493A File Offset: 0x00982B3A
		// (set) Token: 0x06023860 RID: 145504 RVA: 0x0098494A File Offset: 0x00982B4A
		public unsafe float 半径
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGBoxFloor_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGBoxFloor_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170046E6 RID: 18150
		// (get) Token: 0x06023861 RID: 145505 RVA: 0x0098495B File Offset: 0x00982B5B
		// (set) Token: 0x06023862 RID: 145506 RVA: 0x0098496F File Offset: 0x00982B6F
		public unsafe UStaticMesh 模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170046E7 RID: 18151
		// (get) Token: 0x06023863 RID: 145507 RVA: 0x00984984 File Offset: 0x00982B84
		// (set) Token: 0x06023864 RID: 145508 RVA: 0x00984998 File Offset: 0x00982B98
		public unsafe UMaterialInterface 材质
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PCGBoxFloor_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170046E8 RID: 18152
		// (get) Token: 0x06023865 RID: 145509 RVA: 0x009849AD File Offset: 0x00982BAD
		// (set) Token: 0x06023866 RID: 145510 RVA: 0x009849C1 File Offset: 0x00982BC1
		public unsafe FVector 模型缩放
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PCGBoxFloor_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PCGBoxFloor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06023867 RID: 145511 RVA: 0x009849D6 File Offset: 0x00982BD6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 烘焙HISM()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGBoxFloor_C.__烘焙HISM_NativeFunctionPtr, null);
		}

		// Token: 0x06023868 RID: 145512 RVA: 0x009849EA File Offset: 0x00982BEA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 生成阵列()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PCGBoxFloor_C.__生成阵列_NativeFunctionPtr, null);
		}

		// Token: 0x06023869 RID: 145513 RVA: 0x009849FE File Offset: 0x00982BFE
		protected BP_PCGBoxFloor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012167 RID: 74087
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AutoPaving/BP_PCGBoxFloor.BP_PCGBoxFloor_C";

		// Token: 0x04012168 RID: 74088
		private static IntPtr _ClassPtr;

		// Token: 0x04012169 RID: 74089
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401216A RID: 74090
		internal static int __PropertyOffset_0;

		// Token: 0x0401216B RID: 74091
		internal static int __PropertyOffset_1;

		// Token: 0x0401216C RID: 74092
		internal static int __PropertyOffset_2;

		// Token: 0x0401216D RID: 74093
		internal static int __PropertyOffset_3;

		// Token: 0x0401216E RID: 74094
		internal static int __PropertyOffset_4;

		// Token: 0x0401216F RID: 74095
		internal static int __PropertyOffset_5;

		// Token: 0x04012170 RID: 74096
		internal static int __PropertyOffset_6;

		// Token: 0x04012171 RID: 74097
		private static IntPtr __烘焙HISM_NativeFunctionPtr;

		// Token: 0x04012172 RID: 74098
		private static IntPtr __生成阵列_NativeFunctionPtr;
	}
}
