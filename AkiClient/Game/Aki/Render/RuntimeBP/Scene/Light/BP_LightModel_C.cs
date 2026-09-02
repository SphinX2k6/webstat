using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003A8E RID: 14990
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightModel.BP_LightModel_C")]
	[UnrealStructLayout(1320, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1320)]
	public class BP_LightModel_C : AActor, IUnrealUObject, IUnrealObject, IInterface_KuroLightBP, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601F816 RID: 129046 RVA: 0x009133B4 File Offset: 0x009115B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightModel_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightModel.BP_LightModel_C");
			}
			return BP_LightModel_C._ClassPtr;
		}

		// Token: 0x0601F817 RID: 129047 RVA: 0x009133D8 File Offset: 0x009115D8
		int IInterface_KuroLightBP.InterfaceOffset()
		{
			return BP_LightModel_C.__InterfaceOffset_IInterface_KuroLightBP;
		}

		// Token: 0x0601F818 RID: 129048 RVA: 0x009133E0 File Offset: 0x009115E0
		public BP_LightModel_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightModel_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F819 RID: 129049 RVA: 0x00913408 File Offset: 0x00911608
		[NullableContext(1)]
		public BP_LightModel_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightModel_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003057 RID: 12375
		// (get) Token: 0x0601F81A RID: 129050 RVA: 0x0091343B File Offset: 0x0091163B
		// (set) Token: 0x0601F81B RID: 129051 RVA: 0x0091344F File Offset: 0x0091164F
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightModel_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightModel_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003058 RID: 12376
		// (get) Token: 0x0601F81C RID: 129052 RVA: 0x00913464 File Offset: 0x00911664
		// (set) Token: 0x0601F81D RID: 129053 RVA: 0x00913478 File Offset: 0x00911678
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightModel_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightModel_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003059 RID: 12377
		// (get) Token: 0x0601F81E RID: 129054 RVA: 0x0091348D File Offset: 0x0091168D
		// (set) Token: 0x0601F81F RID: 129055 RVA: 0x009134A1 File Offset: 0x009116A1
		public unsafe UStaticMesh LightModel
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightModel_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightModel_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700305A RID: 12378
		// (get) Token: 0x0601F820 RID: 129056 RVA: 0x009134B6 File Offset: 0x009116B6
		// (set) Token: 0x0601F821 RID: 129057 RVA: 0x009134CA File Offset: 0x009116CA
		public unsafe FLinearColor EmissionDayColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700305B RID: 12379
		// (get) Token: 0x0601F822 RID: 129058 RVA: 0x009134DF File Offset: 0x009116DF
		// (set) Token: 0x0601F823 RID: 129059 RVA: 0x009134F3 File Offset: 0x009116F3
		public unsafe FLinearColor EmissionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700305C RID: 12380
		// (get) Token: 0x0601F824 RID: 129060 RVA: 0x00913508 File Offset: 0x00911708
		// (set) Token: 0x0601F825 RID: 129061 RVA: 0x00913518 File Offset: 0x00911718
		public unsafe bool UseWholeDayEmission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700305D RID: 12381
		// (get) Token: 0x0601F826 RID: 129062 RVA: 0x00913529 File Offset: 0x00911729
		// (set) Token: 0x0601F827 RID: 129063 RVA: 0x00913539 File Offset: 0x00911739
		public unsafe bool UseMaterial_LOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700305E RID: 12382
		// (get) Token: 0x0601F828 RID: 129064 RVA: 0x0091354A File Offset: 0x0091174A
		// (set) Token: 0x0601F829 RID: 129065 RVA: 0x0091355A File Offset: 0x0091175A
		public unsafe bool UseFrenel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700305F RID: 12383
		// (get) Token: 0x0601F82A RID: 129066 RVA: 0x0091356B File Offset: 0x0091176B
		// (set) Token: 0x0601F82B RID: 129067 RVA: 0x0091357B File Offset: 0x0091177B
		public unsafe float Frenel_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003060 RID: 12384
		// (get) Token: 0x0601F82C RID: 129068 RVA: 0x0091358C File Offset: 0x0091178C
		// (set) Token: 0x0601F82D RID: 129069 RVA: 0x009135A0 File Offset: 0x009117A0
		public unsafe FLinearColor Frenel_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003061 RID: 12385
		// (get) Token: 0x0601F82E RID: 129070 RVA: 0x009135B5 File Offset: 0x009117B5
		// (set) Token: 0x0601F82F RID: 129071 RVA: 0x009135C9 File Offset: 0x009117C9
		public unsafe FName Frenel_Intensity_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003062 RID: 12386
		// (get) Token: 0x0601F830 RID: 129072 RVA: 0x009135DE File Offset: 0x009117DE
		// (set) Token: 0x0601F831 RID: 129073 RVA: 0x009135F2 File Offset: 0x009117F2
		public unsafe FName Frenel_Color_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003063 RID: 12387
		// (get) Token: 0x0601F832 RID: 129074 RVA: 0x00913607 File Offset: 0x00911807
		// (set) Token: 0x0601F833 RID: 129075 RVA: 0x00913617 File Offset: 0x00911817
		public unsafe float BrightLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003064 RID: 12388
		// (get) Token: 0x0601F834 RID: 129076 RVA: 0x00913628 File Offset: 0x00911828
		// (set) Token: 0x0601F835 RID: 129077 RVA: 0x00913638 File Offset: 0x00911838
		public unsafe float FlickerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003065 RID: 12389
		// (get) Token: 0x0601F836 RID: 129078 RVA: 0x00913649 File Offset: 0x00911849
		// (set) Token: 0x0601F837 RID: 129079 RVA: 0x00913659 File Offset: 0x00911859
		public unsafe float MinimumBright
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003066 RID: 12390
		// (get) Token: 0x0601F838 RID: 129080 RVA: 0x0091366A File Offset: 0x0091186A
		// (set) Token: 0x0601F839 RID: 129081 RVA: 0x0091367A File Offset: 0x0091187A
		public unsafe float ViewTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003067 RID: 12391
		// (get) Token: 0x0601F83A RID: 129082 RVA: 0x0091368C File Offset: 0x0091188C
		// (set) Token: 0x0601F83B RID: 129083 RVA: 0x009136C5 File Offset: 0x009118C5
		[Nullable(1)]
		public TMap<FName, float> CustomScale
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._CustomScale) == null)
				{
					result = (this._CustomScale = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomScale.CopyAssign(value);
			}
		}

		// Token: 0x17003068 RID: 12392
		// (get) Token: 0x0601F83C RID: 129084 RVA: 0x009136D4 File Offset: 0x009118D4
		// (set) Token: 0x0601F83D RID: 129085 RVA: 0x0091370D File Offset: 0x0091190D
		[Nullable(1)]
		public TMap<FName, FLinearColor> CustomColor
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._CustomColor) == null)
				{
					result = (this._CustomColor = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomColor.CopyAssign(value);
			}
		}

		// Token: 0x17003069 RID: 12393
		// (get) Token: 0x0601F83E RID: 129086 RVA: 0x0091371C File Offset: 0x0091191C
		// (set) Token: 0x0601F83F RID: 129087 RVA: 0x00913755 File Offset: 0x00911955
		[Nullable(1)]
		public TArray<UMaterialInterface> CustomOverrideMaterials
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._CustomOverrideMaterials) == null)
				{
					result = (this._CustomOverrideMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_LightModel_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomOverrideMaterials.CopyAssign(value);
			}
		}

		// Token: 0x0601F840 RID: 129088 RVA: 0x00913764 File Offset: 0x00911964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetPlacementSortOrder()
		{
			BP_LightModel_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_LightModel_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightModel_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightModel_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightModel_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601F841 RID: 129089 RVA: 0x009137AC File Offset: 0x009119AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual int GetPlacementSortOrder_Implementation()
		{
			BP_LightModel_C.__GetPlacementSortOrder_FunctionParams* ptr = stackalloc BP_LightModel_C.__GetPlacementSortOrder_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightModel_C.__GetPlacementSortOrder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightModel_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightModel_C.__GetPlacementSortOrder_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601F842 RID: 129090 RVA: 0x009137F4 File Offset: 0x009119F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Custom_Parameter(UMaterialInstanceDynamic MaterialIns)
		{
			BP_LightModel_C.__Custom_Parameter_FunctionParams* ptr = stackalloc BP_LightModel_C.__Custom_Parameter_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_LightModel_C.__Custom_Parameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightModel_C.__Custom_Parameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MaterialIns = ((MaterialIns != null) ? MaterialIns.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightModel_C.__Custom_Parameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F843 RID: 129091 RVA: 0x0091384C File Offset: 0x00911A4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightModel_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F844 RID: 129092 RVA: 0x00913860 File Offset: 0x00911A60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightModel_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F845 RID: 129093 RVA: 0x00913875 File Offset: 0x00911A75
		protected BP_LightModel_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FA6E RID: 64110
		internal static int __InterfaceOffset_IInterface_KuroLightBP;

		// Token: 0x0400FA6F RID: 64111
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/BP_LightModel.BP_LightModel_C";

		// Token: 0x0400FA70 RID: 64112
		private static IntPtr _ClassPtr;

		// Token: 0x0400FA71 RID: 64113
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FA72 RID: 64114
		internal static int __PropertyOffset_0;

		// Token: 0x0400FA73 RID: 64115
		internal static int __PropertyOffset_1;

		// Token: 0x0400FA74 RID: 64116
		internal static int __PropertyOffset_2;

		// Token: 0x0400FA75 RID: 64117
		internal static int __PropertyOffset_3;

		// Token: 0x0400FA76 RID: 64118
		internal static int __PropertyOffset_4;

		// Token: 0x0400FA77 RID: 64119
		internal static int __PropertyOffset_5;

		// Token: 0x0400FA78 RID: 64120
		internal static int __PropertyOffset_6;

		// Token: 0x0400FA79 RID: 64121
		internal static int __PropertyOffset_7;

		// Token: 0x0400FA7A RID: 64122
		internal static int __PropertyOffset_8;

		// Token: 0x0400FA7B RID: 64123
		internal static int __PropertyOffset_9;

		// Token: 0x0400FA7C RID: 64124
		internal static int __PropertyOffset_10;

		// Token: 0x0400FA7D RID: 64125
		internal static int __PropertyOffset_11;

		// Token: 0x0400FA7E RID: 64126
		internal static int __PropertyOffset_12;

		// Token: 0x0400FA7F RID: 64127
		internal static int __PropertyOffset_13;

		// Token: 0x0400FA80 RID: 64128
		internal static int __PropertyOffset_14;

		// Token: 0x0400FA81 RID: 64129
		internal static int __PropertyOffset_15;

		// Token: 0x0400FA82 RID: 64130
		internal static int __PropertyOffset_16;

		// Token: 0x0400FA83 RID: 64131
		private TMap<FName, float> _CustomScale;

		// Token: 0x0400FA84 RID: 64132
		internal static int __PropertyOffset_17;

		// Token: 0x0400FA85 RID: 64133
		private TMap<FName, FLinearColor> _CustomColor;

		// Token: 0x0400FA86 RID: 64134
		internal static int __PropertyOffset_18;

		// Token: 0x0400FA87 RID: 64135
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _CustomOverrideMaterials;

		// Token: 0x0400FA88 RID: 64136
		private static IntPtr __GetPlacementSortOrder_NativeFunctionPtr;

		// Token: 0x0400FA89 RID: 64137
		private static IntPtr __Custom_Parameter_NativeFunctionPtr;

		// Token: 0x0400FA8A RID: 64138
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x020098E9 RID: 39145
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetPlacementSortOrder_FunctionParams
		{
			// Token: 0x04031F46 RID: 204614
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x020098EA RID: 39146
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __Custom_Parameter_FunctionParams
		{
			// Token: 0x04031F47 RID: 204615
			[FieldOffset(0)]
			public IntPtr MaterialIns;
		}
	}
}
