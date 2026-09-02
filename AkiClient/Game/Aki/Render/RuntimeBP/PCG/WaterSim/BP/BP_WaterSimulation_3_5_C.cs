using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterSim.BP
{
	// Token: 0x02003B4F RID: 15183
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_3_5.BP_WaterSimulation_3_5_C")]
	[UnrealStructLayout(1712, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1704)]
	public class BP_WaterSimulation_3_5_C : AKuroBPActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06020F8C RID: 135052 RVA: 0x0093C38C File Offset: 0x0093A58C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSimulation_3_5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_3_5.BP_WaterSimulation_3_5_C");
			}
			return BP_WaterSimulation_3_5_C._ClassPtr;
		}

		// Token: 0x06020F8D RID: 135053 RVA: 0x0093C3B0 File Offset: 0x0093A5B0
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_WaterSimulation_3_5_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x06020F8E RID: 135054 RVA: 0x0093C3B8 File Offset: 0x0093A5B8
		public BP_WaterSimulation_3_5_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_3_5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020F8F RID: 135055 RVA: 0x0093C3E0 File Offset: 0x0093A5E0
		[NullableContext(1)]
		public BP_WaterSimulation_3_5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_3_5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700384C RID: 14412
		// (get) Token: 0x06020F90 RID: 135056 RVA: 0x0093C414 File Offset: 0x0093A614
		// (set) Token: 0x06020F91 RID: 135057 RVA: 0x0093C44D File Offset: 0x0093A64D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700384D RID: 14413
		// (get) Token: 0x06020F92 RID: 135058 RVA: 0x0093C46E File Offset: 0x0093A66E
		// (set) Token: 0x06020F93 RID: 135059 RVA: 0x0093C482 File Offset: 0x0093A682
		public unsafe UBoxComponent WaterInteraction_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700384E RID: 14414
		// (get) Token: 0x06020F94 RID: 135060 RVA: 0x0093C497 File Offset: 0x0093A697
		// (set) Token: 0x06020F95 RID: 135061 RVA: 0x0093C4AB File Offset: 0x0093A6AB
		public unsafe UStaticMeshComponent WaterInteractionCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700384F RID: 14415
		// (get) Token: 0x06020F96 RID: 135062 RVA: 0x0093C4C0 File Offset: 0x0093A6C0
		// (set) Token: 0x06020F97 RID: 135063 RVA: 0x0093C4D4 File Offset: 0x0093A6D4
		public unsafe UStaticMeshComponent WaterSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003850 RID: 14416
		// (get) Token: 0x06020F98 RID: 135064 RVA: 0x0093C4E9 File Offset: 0x0093A6E9
		// (set) Token: 0x06020F99 RID: 135065 RVA: 0x0093C4FD File Offset: 0x0093A6FD
		public unsafe UStaticMeshComponent PreView_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003851 RID: 14417
		// (get) Token: 0x06020F9A RID: 135066 RVA: 0x0093C512 File Offset: 0x0093A712
		// (set) Token: 0x06020F9B RID: 135067 RVA: 0x0093C526 File Offset: 0x0093A726
		public unsafe UBoxComponent Sim_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003852 RID: 14418
		// (get) Token: 0x06020F9C RID: 135068 RVA: 0x0093C53B File Offset: 0x0093A73B
		// (set) Token: 0x06020F9D RID: 135069 RVA: 0x0093C54F File Offset: 0x0093A74F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003853 RID: 14419
		// (get) Token: 0x06020F9E RID: 135070 RVA: 0x0093C564 File Offset: 0x0093A764
		// (set) Token: 0x06020F9F RID: 135071 RVA: 0x0093C574 File Offset: 0x0093A774
		public unsafe bool Sim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003854 RID: 14420
		// (get) Token: 0x06020FA0 RID: 135072 RVA: 0x0093C585 File Offset: 0x0093A785
		// (set) Token: 0x06020FA1 RID: 135073 RVA: 0x0093C595 File Offset: 0x0093A795
		public unsafe bool SeqControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003855 RID: 14421
		// (get) Token: 0x06020FA2 RID: 135074 RVA: 0x0093C5A6 File Offset: 0x0093A7A6
		// (set) Token: 0x06020FA3 RID: 135075 RVA: 0x0093C5B6 File Offset: 0x0093A7B6
		public unsafe bool DAControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003856 RID: 14422
		// (get) Token: 0x06020FA4 RID: 135076 RVA: 0x0093C5C7 File Offset: 0x0093A7C7
		// (set) Token: 0x06020FA5 RID: 135077 RVA: 0x0093C5DB File Offset: 0x0093A7DB
		public unsafe FVector SimBoxOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003857 RID: 14423
		// (get) Token: 0x06020FA6 RID: 135078 RVA: 0x0093C5F0 File Offset: 0x0093A7F0
		// (set) Token: 0x06020FA7 RID: 135079 RVA: 0x0093C604 File Offset: 0x0093A804
		public unsafe FVector SimBoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003858 RID: 14424
		// (get) Token: 0x06020FA8 RID: 135080 RVA: 0x0093C619 File Offset: 0x0093A819
		// (set) Token: 0x06020FA9 RID: 135081 RVA: 0x0093C629 File Offset: 0x0093A829
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003859 RID: 14425
		// (get) Token: 0x06020FAA RID: 135082 RVA: 0x0093C63A File Offset: 0x0093A83A
		// (set) Token: 0x06020FAB RID: 135083 RVA: 0x0093C64E File Offset: 0x0093A84E
		public unsafe UMaterial M_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700385A RID: 14426
		// (get) Token: 0x06020FAC RID: 135084 RVA: 0x0093C663 File Offset: 0x0093A863
		// (set) Token: 0x06020FAD RID: 135085 RVA: 0x0093C677 File Offset: 0x0093A877
		public unsafe UMaterial M_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700385B RID: 14427
		// (get) Token: 0x06020FAE RID: 135086 RVA: 0x0093C68C File Offset: 0x0093A88C
		// (set) Token: 0x06020FAF RID: 135087 RVA: 0x0093C6A0 File Offset: 0x0093A8A0
		public unsafe UMaterial M_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700385C RID: 14428
		// (get) Token: 0x06020FB0 RID: 135088 RVA: 0x0093C6B5 File Offset: 0x0093A8B5
		// (set) Token: 0x06020FB1 RID: 135089 RVA: 0x0093C6C9 File Offset: 0x0093A8C9
		public unsafe UMaterial M_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700385D RID: 14429
		// (get) Token: 0x06020FB2 RID: 135090 RVA: 0x0093C6DE File Offset: 0x0093A8DE
		// (set) Token: 0x06020FB3 RID: 135091 RVA: 0x0093C6F2 File Offset: 0x0093A8F2
		public unsafe UMaterial M_Water_Clear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700385E RID: 14430
		// (get) Token: 0x06020FB4 RID: 135092 RVA: 0x0093C707 File Offset: 0x0093A907
		// (set) Token: 0x06020FB5 RID: 135093 RVA: 0x0093C71B File Offset: 0x0093A91B
		public unsafe UMaterialInstanceDynamic MI_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700385F RID: 14431
		// (get) Token: 0x06020FB6 RID: 135094 RVA: 0x0093C730 File Offset: 0x0093A930
		// (set) Token: 0x06020FB7 RID: 135095 RVA: 0x0093C744 File Offset: 0x0093A944
		public unsafe UMaterialInstanceDynamic MI_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003860 RID: 14432
		// (get) Token: 0x06020FB8 RID: 135096 RVA: 0x0093C759 File Offset: 0x0093A959
		// (set) Token: 0x06020FB9 RID: 135097 RVA: 0x0093C76D File Offset: 0x0093A96D
		public unsafe UMaterialInstanceDynamic MI_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003861 RID: 14433
		// (get) Token: 0x06020FBA RID: 135098 RVA: 0x0093C782 File Offset: 0x0093A982
		// (set) Token: 0x06020FBB RID: 135099 RVA: 0x0093C796 File Offset: 0x0093A996
		public unsafe UMaterialInstanceDynamic MI_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003862 RID: 14434
		// (get) Token: 0x06020FBC RID: 135100 RVA: 0x0093C7AB File Offset: 0x0093A9AB
		// (set) Token: 0x06020FBD RID: 135101 RVA: 0x0093C7BF File Offset: 0x0093A9BF
		public unsafe UTexture RT_HeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003863 RID: 14435
		// (get) Token: 0x06020FBE RID: 135102 RVA: 0x0093C7D4 File Offset: 0x0093A9D4
		// (set) Token: 0x06020FBF RID: 135103 RVA: 0x0093C7E8 File Offset: 0x0093A9E8
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003864 RID: 14436
		// (get) Token: 0x06020FC0 RID: 135104 RVA: 0x0093C7FD File Offset: 0x0093A9FD
		// (set) Token: 0x06020FC1 RID: 135105 RVA: 0x0093C811 File Offset: 0x0093AA11
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Temp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17003865 RID: 14437
		// (get) Token: 0x06020FC2 RID: 135106 RVA: 0x0093C826 File Offset: 0x0093AA26
		// (set) Token: 0x06020FC3 RID: 135107 RVA: 0x0093C83A File Offset: 0x0093AA3A
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17003866 RID: 14438
		// (get) Token: 0x06020FC4 RID: 135108 RVA: 0x0093C84F File Offset: 0x0093AA4F
		// (set) Token: 0x06020FC5 RID: 135109 RVA: 0x0093C863 File Offset: 0x0093AA63
		public unsafe UStaticMeshComponent RenderActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17003867 RID: 14439
		// (get) Token: 0x06020FC6 RID: 135110 RVA: 0x0093C878 File Offset: 0x0093AA78
		// (set) Token: 0x06020FC7 RID: 135111 RVA: 0x0093C88C File Offset: 0x0093AA8C
		public unsafe UMaterialInterface M_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003868 RID: 14440
		// (get) Token: 0x06020FC8 RID: 135112 RVA: 0x0093C8A1 File Offset: 0x0093AAA1
		// (set) Token: 0x06020FC9 RID: 135113 RVA: 0x0093C8B5 File Offset: 0x0093AAB5
		public unsafe UMaterialInstanceDynamic MI_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17003869 RID: 14441
		// (get) Token: 0x06020FCA RID: 135114 RVA: 0x0093C8CA File Offset: 0x0093AACA
		// (set) Token: 0x06020FCB RID: 135115 RVA: 0x0093C8DA File Offset: 0x0093AADA
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700386A RID: 14442
		// (get) Token: 0x06020FCC RID: 135116 RVA: 0x0093C8EB File Offset: 0x0093AAEB
		// (set) Token: 0x06020FCD RID: 135117 RVA: 0x0093C8FB File Offset: 0x0093AAFB
		public unsafe float DurationTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700386B RID: 14443
		// (get) Token: 0x06020FCE RID: 135118 RVA: 0x0093C90C File Offset: 0x0093AB0C
		// (set) Token: 0x06020FCF RID: 135119 RVA: 0x0093C920 File Offset: 0x0093AB20
		public unsafe FLinearColor WaterSuorcePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700386C RID: 14444
		// (get) Token: 0x06020FD0 RID: 135120 RVA: 0x0093C935 File Offset: 0x0093AB35
		// (set) Token: 0x06020FD1 RID: 135121 RVA: 0x0093C949 File Offset: 0x0093AB49
		public unsafe FLinearColor WaterSuorcePos1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700386D RID: 14445
		// (get) Token: 0x06020FD2 RID: 135122 RVA: 0x0093C95E File Offset: 0x0093AB5E
		// (set) Token: 0x06020FD3 RID: 135123 RVA: 0x0093C96E File Offset: 0x0093AB6E
		public unsafe float WaterActorHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700386E RID: 14446
		// (get) Token: 0x06020FD4 RID: 135124 RVA: 0x0093C97F File Offset: 0x0093AB7F
		// (set) Token: 0x06020FD5 RID: 135125 RVA: 0x0093C98F File Offset: 0x0093AB8F
		public unsafe float PlayerWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700386F RID: 14447
		// (get) Token: 0x06020FD6 RID: 135126 RVA: 0x0093C9A0 File Offset: 0x0093ABA0
		// (set) Token: 0x06020FD7 RID: 135127 RVA: 0x0093C9B0 File Offset: 0x0093ABB0
		public unsafe float CameraWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17003870 RID: 14448
		// (get) Token: 0x06020FD8 RID: 135128 RVA: 0x0093C9C1 File Offset: 0x0093ABC1
		// (set) Token: 0x06020FD9 RID: 135129 RVA: 0x0093C9D5 File Offset: 0x0093ABD5
		public unsafe FVector PlayerWaterNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003871 RID: 14449
		// (get) Token: 0x06020FDA RID: 135130 RVA: 0x0093C9EA File Offset: 0x0093ABEA
		// (set) Token: 0x06020FDB RID: 135131 RVA: 0x0093C9FA File Offset: 0x0093ABFA
		public unsafe float PlayerWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17003872 RID: 14450
		// (get) Token: 0x06020FDC RID: 135132 RVA: 0x0093CA0B File Offset: 0x0093AC0B
		// (set) Token: 0x06020FDD RID: 135133 RVA: 0x0093CA1B File Offset: 0x0093AC1B
		public unsafe float CameraWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003873 RID: 14451
		// (get) Token: 0x06020FDE RID: 135134 RVA: 0x0093CA2C File Offset: 0x0093AC2C
		// (set) Token: 0x06020FDF RID: 135135 RVA: 0x0093CA40 File Offset: 0x0093AC40
		public unsafe FVector CameraWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003874 RID: 14452
		// (get) Token: 0x06020FE0 RID: 135136 RVA: 0x0093CA55 File Offset: 0x0093AC55
		// (set) Token: 0x06020FE1 RID: 135137 RVA: 0x0093CA69 File Offset: 0x0093AC69
		public unsafe FVector PlayerWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003875 RID: 14453
		// (get) Token: 0x06020FE2 RID: 135138 RVA: 0x0093CA7E File Offset: 0x0093AC7E
		// (set) Token: 0x06020FE3 RID: 135139 RVA: 0x0093CA8E File Offset: 0x0093AC8E
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17003876 RID: 14454
		// (get) Token: 0x06020FE4 RID: 135140 RVA: 0x0093CA9F File Offset: 0x0093AC9F
		// (set) Token: 0x06020FE5 RID: 135141 RVA: 0x0093CAAF File Offset: 0x0093ACAF
		public unsafe float AccelerationClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17003877 RID: 14455
		// (get) Token: 0x06020FE6 RID: 135142 RVA: 0x0093CAC0 File Offset: 0x0093ACC0
		// (set) Token: 0x06020FE7 RID: 135143 RVA: 0x0093CAD0 File Offset: 0x0093ACD0
		public unsafe float Friction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003878 RID: 14456
		// (get) Token: 0x06020FE8 RID: 135144 RVA: 0x0093CAE1 File Offset: 0x0093ACE1
		// (set) Token: 0x06020FE9 RID: 135145 RVA: 0x0093CAF1 File Offset: 0x0093ACF1
		public unsafe float Damping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17003879 RID: 14457
		// (get) Token: 0x06020FEA RID: 135146 RVA: 0x0093CB02 File Offset: 0x0093AD02
		// (set) Token: 0x06020FEB RID: 135147 RVA: 0x0093CB12 File Offset: 0x0093AD12
		public unsafe float VelocityClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700387A RID: 14458
		// (get) Token: 0x06020FEC RID: 135148 RVA: 0x0093CB23 File Offset: 0x0093AD23
		// (set) Token: 0x06020FED RID: 135149 RVA: 0x0093CB33 File Offset: 0x0093AD33
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700387B RID: 14459
		// (get) Token: 0x06020FEE RID: 135150 RVA: 0x0093CB44 File Offset: 0x0093AD44
		// (set) Token: 0x06020FEF RID: 135151 RVA: 0x0093CB54 File Offset: 0x0093AD54
		public unsafe int LoopNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x1700387C RID: 14460
		// (get) Token: 0x06020FF0 RID: 135152 RVA: 0x0093CB65 File Offset: 0x0093AD65
		// (set) Token: 0x06020FF1 RID: 135153 RVA: 0x0093CB79 File Offset: 0x0093AD79
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x1700387D RID: 14461
		// (get) Token: 0x06020FF2 RID: 135154 RVA: 0x0093CB8E File Offset: 0x0093AD8E
		// (set) Token: 0x06020FF3 RID: 135155 RVA: 0x0093CBA2 File Offset: 0x0093ADA2
		public unsafe BP_HeightmapReadback_C BP_HeightmapReadback
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_HeightmapReadback_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x1700387E RID: 14462
		// (get) Token: 0x06020FF4 RID: 135156 RVA: 0x0093CBB7 File Offset: 0x0093ADB7
		// (set) Token: 0x06020FF5 RID: 135157 RVA: 0x0093CBC7 File Offset: 0x0093ADC7
		public unsafe int Readback_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x1700387F RID: 14463
		// (get) Token: 0x06020FF6 RID: 135158 RVA: 0x0093CBD8 File Offset: 0x0093ADD8
		// (set) Token: 0x06020FF7 RID: 135159 RVA: 0x0093CBE8 File Offset: 0x0093ADE8
		public unsafe int Readback_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17003880 RID: 14464
		// (get) Token: 0x06020FF8 RID: 135160 RVA: 0x0093CBF9 File Offset: 0x0093ADF9
		// (set) Token: 0x06020FF9 RID: 135161 RVA: 0x0093CC09 File Offset: 0x0093AE09
		public unsafe float Readback_Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17003881 RID: 14465
		// (get) Token: 0x06020FFA RID: 135162 RVA: 0x0093CC1A File Offset: 0x0093AE1A
		// (set) Token: 0x06020FFB RID: 135163 RVA: 0x0093CC2E File Offset: 0x0093AE2E
		public unsafe FVector4 CaptureRangeMax_Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17003882 RID: 14466
		// (get) Token: 0x06020FFC RID: 135164 RVA: 0x0093CC43 File Offset: 0x0093AE43
		// (set) Token: 0x06020FFD RID: 135165 RVA: 0x0093CC53 File Offset: 0x0093AE53
		public unsafe bool DynamicWaterFlow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003883 RID: 14467
		// (get) Token: 0x06020FFE RID: 135166 RVA: 0x0093CC64 File Offset: 0x0093AE64
		// (set) Token: 0x06020FFF RID: 135167 RVA: 0x0093CC74 File Offset: 0x0093AE74
		public unsafe bool OverlapVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003884 RID: 14468
		// (get) Token: 0x06021000 RID: 135168 RVA: 0x0093CC85 File Offset: 0x0093AE85
		// (set) Token: 0x06021001 RID: 135169 RVA: 0x0093CC95 File Offset: 0x0093AE95
		public unsafe bool Is_Simulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003885 RID: 14469
		// (get) Token: 0x06021002 RID: 135170 RVA: 0x0093CCA6 File Offset: 0x0093AEA6
		// (set) Token: 0x06021003 RID: 135171 RVA: 0x0093CCB6 File Offset: 0x0093AEB6
		public unsafe float CameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x06021004 RID: 135172 RVA: 0x0093CCC7 File Offset: 0x0093AEC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReStartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReStartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06021005 RID: 135173 RVA: 0x0093CCDC File Offset: 0x0093AEDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HideRenderWaterMesh(bool HideRenderWater)
		{
			BP_WaterSimulation_3_5_C.__HideRenderWaterMesh_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__HideRenderWaterMesh_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__HideRenderWaterMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HideRenderWater = HideRenderWater;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021006 RID: 135174 RVA: 0x0093CD22 File Offset: 0x0093AF22
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalcHeightmap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__CalcHeightmap_NativeFunctionPtr, null);
		}

		// Token: 0x06021007 RID: 135175 RVA: 0x0093CD36 File Offset: 0x0093AF36
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPCParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__SetMPCParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06021008 RID: 135176 RVA: 0x0093CD4A File Offset: 0x0093AF4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06021009 RID: 135177 RVA: 0x0093CD5E File Offset: 0x0093AF5E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x0602100A RID: 135178 RVA: 0x0093CD72 File Offset: 0x0093AF72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearWater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ClearWater_NativeFunctionPtr, null);
		}

		// Token: 0x0602100B RID: 135179 RVA: 0x0093CD88 File Offset: 0x0093AF88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialParameter(UMaterialInterface Material, UTexture VelocityHeightFoam, ref UMaterialInstanceDynamic MaterialInstance)
		{
			BP_WaterSimulation_3_5_C.__SetMaterialParameter_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__SetMaterialParameter_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__SetMaterialParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ptr->VelocityHeightFoam = ((VelocityHeightFoam != null) ? VelocityHeightFoam.NativePtr : IntPtr.Zero);
			ref BP_WaterSimulation_3_5_C.__SetMaterialParameter_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MaterialInstance;
			ptr2.MaterialInstance = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr);
			MaterialInstance = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MaterialInstance);
		}

		// Token: 0x0602100C RID: 135180 RVA: 0x0093CE18 File Offset: 0x0093B018
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602100D RID: 135181 RVA: 0x0093CE2C File Offset: 0x0093B02C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602100E RID: 135182 RVA: 0x0093CE44 File Offset: 0x0093B044
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_3_5_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_3_5_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602100F RID: 135183 RVA: 0x0093CED4 File Offset: 0x0093B0D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_3_5_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_3_5_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06021010 RID: 135184 RVA: 0x0093CF63 File Offset: 0x0093B163
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021011 RID: 135185 RVA: 0x0093CF77 File Offset: 0x0093B177
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021012 RID: 135186 RVA: 0x0093CF8C File Offset: 0x0093B18C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterSimulation_3_5_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021013 RID: 135187 RVA: 0x0093CFD4 File Offset: 0x0093B1D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterSimulation_3_5_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021014 RID: 135188 RVA: 0x0093D01B File Offset: 0x0093B21B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021015 RID: 135189 RVA: 0x0093D030 File Offset: 0x0093B230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021016 RID: 135190 RVA: 0x0093D0EC File Offset: 0x0093B2EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021017 RID: 135191 RVA: 0x0093D178 File Offset: 0x0093B378
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021018 RID: 135192 RVA: 0x0093D234 File Offset: 0x0093B434
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021019 RID: 135193 RVA: 0x0093D2C0 File Offset: 0x0093B4C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterSimulation_3_5(int EntryPoint)
		{
			BP_WaterSimulation_3_5_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_FunctionParams[(UIntPtr)887] + 15L / (long)sizeof(BP_WaterSimulation_3_5_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602101A RID: 135194 RVA: 0x0093D30A File Offset: 0x0093B50A
		protected BP_WaterSimulation_3_5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040108DB RID: 67803
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x040108DC RID: 67804
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_3_5.BP_WaterSimulation_3_5_C";

		// Token: 0x040108DD RID: 67805
		private static IntPtr _ClassPtr;

		// Token: 0x040108DE RID: 67806
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040108DF RID: 67807
		internal static int __PropertyOffset_0;

		// Token: 0x040108E0 RID: 67808
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040108E1 RID: 67809
		internal static int __PropertyOffset_1;

		// Token: 0x040108E2 RID: 67810
		internal static int __PropertyOffset_2;

		// Token: 0x040108E3 RID: 67811
		internal static int __PropertyOffset_3;

		// Token: 0x040108E4 RID: 67812
		internal static int __PropertyOffset_4;

		// Token: 0x040108E5 RID: 67813
		internal static int __PropertyOffset_5;

		// Token: 0x040108E6 RID: 67814
		internal static int __PropertyOffset_6;

		// Token: 0x040108E7 RID: 67815
		internal static int __PropertyOffset_7;

		// Token: 0x040108E8 RID: 67816
		internal static int __PropertyOffset_8;

		// Token: 0x040108E9 RID: 67817
		internal static int __PropertyOffset_9;

		// Token: 0x040108EA RID: 67818
		internal static int __PropertyOffset_10;

		// Token: 0x040108EB RID: 67819
		internal static int __PropertyOffset_11;

		// Token: 0x040108EC RID: 67820
		internal static int __PropertyOffset_12;

		// Token: 0x040108ED RID: 67821
		internal static int __PropertyOffset_13;

		// Token: 0x040108EE RID: 67822
		internal static int __PropertyOffset_14;

		// Token: 0x040108EF RID: 67823
		internal static int __PropertyOffset_15;

		// Token: 0x040108F0 RID: 67824
		internal static int __PropertyOffset_16;

		// Token: 0x040108F1 RID: 67825
		internal static int __PropertyOffset_17;

		// Token: 0x040108F2 RID: 67826
		internal static int __PropertyOffset_18;

		// Token: 0x040108F3 RID: 67827
		internal static int __PropertyOffset_19;

		// Token: 0x040108F4 RID: 67828
		internal static int __PropertyOffset_20;

		// Token: 0x040108F5 RID: 67829
		internal static int __PropertyOffset_21;

		// Token: 0x040108F6 RID: 67830
		internal static int __PropertyOffset_22;

		// Token: 0x040108F7 RID: 67831
		internal static int __PropertyOffset_23;

		// Token: 0x040108F8 RID: 67832
		internal static int __PropertyOffset_24;

		// Token: 0x040108F9 RID: 67833
		internal static int __PropertyOffset_25;

		// Token: 0x040108FA RID: 67834
		internal static int __PropertyOffset_26;

		// Token: 0x040108FB RID: 67835
		internal static int __PropertyOffset_27;

		// Token: 0x040108FC RID: 67836
		internal static int __PropertyOffset_28;

		// Token: 0x040108FD RID: 67837
		internal static int __PropertyOffset_29;

		// Token: 0x040108FE RID: 67838
		internal static int __PropertyOffset_30;

		// Token: 0x040108FF RID: 67839
		internal static int __PropertyOffset_31;

		// Token: 0x04010900 RID: 67840
		internal static int __PropertyOffset_32;

		// Token: 0x04010901 RID: 67841
		internal static int __PropertyOffset_33;

		// Token: 0x04010902 RID: 67842
		internal static int __PropertyOffset_34;

		// Token: 0x04010903 RID: 67843
		internal static int __PropertyOffset_35;

		// Token: 0x04010904 RID: 67844
		internal static int __PropertyOffset_36;

		// Token: 0x04010905 RID: 67845
		internal static int __PropertyOffset_37;

		// Token: 0x04010906 RID: 67846
		internal static int __PropertyOffset_38;

		// Token: 0x04010907 RID: 67847
		internal static int __PropertyOffset_39;

		// Token: 0x04010908 RID: 67848
		internal static int __PropertyOffset_40;

		// Token: 0x04010909 RID: 67849
		internal static int __PropertyOffset_41;

		// Token: 0x0401090A RID: 67850
		internal static int __PropertyOffset_42;

		// Token: 0x0401090B RID: 67851
		internal static int __PropertyOffset_43;

		// Token: 0x0401090C RID: 67852
		internal static int __PropertyOffset_44;

		// Token: 0x0401090D RID: 67853
		internal static int __PropertyOffset_45;

		// Token: 0x0401090E RID: 67854
		internal static int __PropertyOffset_46;

		// Token: 0x0401090F RID: 67855
		internal static int __PropertyOffset_47;

		// Token: 0x04010910 RID: 67856
		internal static int __PropertyOffset_48;

		// Token: 0x04010911 RID: 67857
		internal static int __PropertyOffset_49;

		// Token: 0x04010912 RID: 67858
		internal static int __PropertyOffset_50;

		// Token: 0x04010913 RID: 67859
		internal static int __PropertyOffset_51;

		// Token: 0x04010914 RID: 67860
		internal static int __PropertyOffset_52;

		// Token: 0x04010915 RID: 67861
		internal static int __PropertyOffset_53;

		// Token: 0x04010916 RID: 67862
		internal static int __PropertyOffset_54;

		// Token: 0x04010917 RID: 67863
		internal static int __PropertyOffset_55;

		// Token: 0x04010918 RID: 67864
		internal static int __PropertyOffset_56;

		// Token: 0x04010919 RID: 67865
		internal static int __PropertyOffset_57;

		// Token: 0x0401091A RID: 67866
		private static IntPtr __ReStartSim_NativeFunctionPtr;

		// Token: 0x0401091B RID: 67867
		private static IntPtr __HideRenderWaterMesh_NativeFunctionPtr;

		// Token: 0x0401091C RID: 67868
		private static IntPtr __CalcHeightmap_NativeFunctionPtr;

		// Token: 0x0401091D RID: 67869
		private static IntPtr __SetMPCParameters_NativeFunctionPtr;

		// Token: 0x0401091E RID: 67870
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x0401091F RID: 67871
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04010920 RID: 67872
		private static IntPtr __ClearWater_NativeFunctionPtr;

		// Token: 0x04010921 RID: 67873
		private static IntPtr __SetMaterialParameter_NativeFunctionPtr;

		// Token: 0x04010922 RID: 67874
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010923 RID: 67875
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x04010924 RID: 67876
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010925 RID: 67877
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010926 RID: 67878
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010927 RID: 67879
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010928 RID: 67880
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010929 RID: 67881
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401092A RID: 67882
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401092B RID: 67883
		private static IntPtr __ExecuteUbergraph_BP_WaterSimulation_3_5_NativeFunctionPtr;

		// Token: 0x02009A59 RID: 39513
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __HideRenderWaterMesh_FunctionParams
		{
			// Token: 0x0403215C RID: 205148
			[FieldOffset(0)]
			public bool HideRenderWater;
		}

		// Token: 0x02009A5A RID: 39514
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __SetMaterialParameter_FunctionParams
		{
			// Token: 0x0403215D RID: 205149
			[FieldOffset(0)]
			public IntPtr Material;

			// Token: 0x0403215E RID: 205150
			[FieldOffset(8)]
			public IntPtr VelocityHeightFoam;

			// Token: 0x0403215F RID: 205151
			[FieldOffset(16)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009A5B RID: 39515
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x04032160 RID: 205152
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04032161 RID: 205153
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x02009A5C RID: 39516
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032162 RID: 205154
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A5D RID: 39517
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032163 RID: 205155
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032164 RID: 205156
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032165 RID: 205157
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032166 RID: 205158
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032167 RID: 205159
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032168 RID: 205160
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A5E RID: 39518
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032169 RID: 205161
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403216A RID: 205162
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403216B RID: 205163
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403216C RID: 205164
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A5F RID: 39519
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403216D RID: 205165
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403216E RID: 205166
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403216F RID: 205167
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032170 RID: 205168
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032171 RID: 205169
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032172 RID: 205170
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A60 RID: 39520
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032173 RID: 205171
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032174 RID: 205172
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032175 RID: 205173
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032176 RID: 205174
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A61 RID: 39521
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 872)]
		protected ref struct __ExecuteUbergraph_BP_WaterSimulation_3_5_FunctionParams
		{
			// Token: 0x04032177 RID: 205175
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
