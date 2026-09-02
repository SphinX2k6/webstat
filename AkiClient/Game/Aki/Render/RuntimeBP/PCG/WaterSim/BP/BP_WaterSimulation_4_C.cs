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
	// Token: 0x02003B51 RID: 15185
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_4.BP_WaterSimulation_4_C")]
	[UnrealStructLayout(1760, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1760)]
	public class BP_WaterSimulation_4_C : AKuroBPActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x060210B3 RID: 135347 RVA: 0x0093E36B File Offset: 0x0093C56B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSimulation_4_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_4.BP_WaterSimulation_4_C");
			}
			return BP_WaterSimulation_4_C._ClassPtr;
		}

		// Token: 0x060210B4 RID: 135348 RVA: 0x0093E38F File Offset: 0x0093C58F
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_WaterSimulation_4_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x060210B5 RID: 135349 RVA: 0x0093E398 File Offset: 0x0093C598
		public BP_WaterSimulation_4_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_4_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060210B6 RID: 135350 RVA: 0x0093E3C0 File Offset: 0x0093C5C0
		[NullableContext(1)]
		public BP_WaterSimulation_4_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_4_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170038C4 RID: 14532
		// (get) Token: 0x060210B7 RID: 135351 RVA: 0x0093E3F4 File Offset: 0x0093C5F4
		// (set) Token: 0x060210B8 RID: 135352 RVA: 0x0093E42D File Offset: 0x0093C62D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170038C5 RID: 14533
		// (get) Token: 0x060210B9 RID: 135353 RVA: 0x0093E44E File Offset: 0x0093C64E
		// (set) Token: 0x060210BA RID: 135354 RVA: 0x0093E462 File Offset: 0x0093C662
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170038C6 RID: 14534
		// (get) Token: 0x060210BB RID: 135355 RVA: 0x0093E477 File Offset: 0x0093C677
		// (set) Token: 0x060210BC RID: 135356 RVA: 0x0093E48B File Offset: 0x0093C68B
		public unsafe UBoxComponent WaterInteraction_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170038C7 RID: 14535
		// (get) Token: 0x060210BD RID: 135357 RVA: 0x0093E4A0 File Offset: 0x0093C6A0
		// (set) Token: 0x060210BE RID: 135358 RVA: 0x0093E4B4 File Offset: 0x0093C6B4
		public unsafe UStaticMeshComponent WaterInteractionCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170038C8 RID: 14536
		// (get) Token: 0x060210BF RID: 135359 RVA: 0x0093E4C9 File Offset: 0x0093C6C9
		// (set) Token: 0x060210C0 RID: 135360 RVA: 0x0093E4DD File Offset: 0x0093C6DD
		public unsafe UStaticMeshComponent WaterSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170038C9 RID: 14537
		// (get) Token: 0x060210C1 RID: 135361 RVA: 0x0093E4F2 File Offset: 0x0093C6F2
		// (set) Token: 0x060210C2 RID: 135362 RVA: 0x0093E506 File Offset: 0x0093C706
		public unsafe UStaticMeshComponent PreView_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170038CA RID: 14538
		// (get) Token: 0x060210C3 RID: 135363 RVA: 0x0093E51B File Offset: 0x0093C71B
		// (set) Token: 0x060210C4 RID: 135364 RVA: 0x0093E52F File Offset: 0x0093C72F
		public unsafe UBoxComponent Sim_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170038CB RID: 14539
		// (get) Token: 0x060210C5 RID: 135365 RVA: 0x0093E544 File Offset: 0x0093C744
		// (set) Token: 0x060210C6 RID: 135366 RVA: 0x0093E558 File Offset: 0x0093C758
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170038CC RID: 14540
		// (get) Token: 0x060210C7 RID: 135367 RVA: 0x0093E56D File Offset: 0x0093C76D
		// (set) Token: 0x060210C8 RID: 135368 RVA: 0x0093E57D File Offset: 0x0093C77D
		public unsafe bool Sim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038CD RID: 14541
		// (get) Token: 0x060210C9 RID: 135369 RVA: 0x0093E58E File Offset: 0x0093C78E
		// (set) Token: 0x060210CA RID: 135370 RVA: 0x0093E59E File Offset: 0x0093C79E
		public unsafe bool SeqControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038CE RID: 14542
		// (get) Token: 0x060210CB RID: 135371 RVA: 0x0093E5AF File Offset: 0x0093C7AF
		// (set) Token: 0x060210CC RID: 135372 RVA: 0x0093E5BF File Offset: 0x0093C7BF
		public unsafe bool DAControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038CF RID: 14543
		// (get) Token: 0x060210CD RID: 135373 RVA: 0x0093E5D0 File Offset: 0x0093C7D0
		// (set) Token: 0x060210CE RID: 135374 RVA: 0x0093E5E4 File Offset: 0x0093C7E4
		public unsafe FVector SimBoxOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170038D0 RID: 14544
		// (get) Token: 0x060210CF RID: 135375 RVA: 0x0093E5F9 File Offset: 0x0093C7F9
		// (set) Token: 0x060210D0 RID: 135376 RVA: 0x0093E60D File Offset: 0x0093C80D
		public unsafe FVector SimBoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170038D1 RID: 14545
		// (get) Token: 0x060210D1 RID: 135377 RVA: 0x0093E622 File Offset: 0x0093C822
		// (set) Token: 0x060210D2 RID: 135378 RVA: 0x0093E632 File Offset: 0x0093C832
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170038D2 RID: 14546
		// (get) Token: 0x060210D3 RID: 135379 RVA: 0x0093E643 File Offset: 0x0093C843
		// (set) Token: 0x060210D4 RID: 135380 RVA: 0x0093E657 File Offset: 0x0093C857
		public unsafe UMaterial M_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170038D3 RID: 14547
		// (get) Token: 0x060210D5 RID: 135381 RVA: 0x0093E66C File Offset: 0x0093C86C
		// (set) Token: 0x060210D6 RID: 135382 RVA: 0x0093E680 File Offset: 0x0093C880
		public unsafe UMaterial M_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x170038D4 RID: 14548
		// (get) Token: 0x060210D7 RID: 135383 RVA: 0x0093E695 File Offset: 0x0093C895
		// (set) Token: 0x060210D8 RID: 135384 RVA: 0x0093E6A9 File Offset: 0x0093C8A9
		public unsafe UMaterial M_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170038D5 RID: 14549
		// (get) Token: 0x060210D9 RID: 135385 RVA: 0x0093E6BE File Offset: 0x0093C8BE
		// (set) Token: 0x060210DA RID: 135386 RVA: 0x0093E6D2 File Offset: 0x0093C8D2
		public unsafe UMaterial M_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170038D6 RID: 14550
		// (get) Token: 0x060210DB RID: 135387 RVA: 0x0093E6E7 File Offset: 0x0093C8E7
		// (set) Token: 0x060210DC RID: 135388 RVA: 0x0093E6FB File Offset: 0x0093C8FB
		public unsafe UMaterial M_Water_Clear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170038D7 RID: 14551
		// (get) Token: 0x060210DD RID: 135389 RVA: 0x0093E710 File Offset: 0x0093C910
		// (set) Token: 0x060210DE RID: 135390 RVA: 0x0093E724 File Offset: 0x0093C924
		public unsafe UMaterialInstanceDynamic MI_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x170038D8 RID: 14552
		// (get) Token: 0x060210DF RID: 135391 RVA: 0x0093E739 File Offset: 0x0093C939
		// (set) Token: 0x060210E0 RID: 135392 RVA: 0x0093E74D File Offset: 0x0093C94D
		public unsafe UMaterialInstanceDynamic MI_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170038D9 RID: 14553
		// (get) Token: 0x060210E1 RID: 135393 RVA: 0x0093E762 File Offset: 0x0093C962
		// (set) Token: 0x060210E2 RID: 135394 RVA: 0x0093E776 File Offset: 0x0093C976
		public unsafe UMaterialInstanceDynamic MI_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x170038DA RID: 14554
		// (get) Token: 0x060210E3 RID: 135395 RVA: 0x0093E78B File Offset: 0x0093C98B
		// (set) Token: 0x060210E4 RID: 135396 RVA: 0x0093E79F File Offset: 0x0093C99F
		public unsafe UMaterialInstanceDynamic MI_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170038DB RID: 14555
		// (get) Token: 0x060210E5 RID: 135397 RVA: 0x0093E7B4 File Offset: 0x0093C9B4
		// (set) Token: 0x060210E6 RID: 135398 RVA: 0x0093E7C8 File Offset: 0x0093C9C8
		public unsafe UTextureRenderTarget2D RT_HeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x170038DC RID: 14556
		// (get) Token: 0x060210E7 RID: 135399 RVA: 0x0093E7DD File Offset: 0x0093C9DD
		// (set) Token: 0x060210E8 RID: 135400 RVA: 0x0093E7F1 File Offset: 0x0093C9F1
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x170038DD RID: 14557
		// (get) Token: 0x060210E9 RID: 135401 RVA: 0x0093E806 File Offset: 0x0093CA06
		// (set) Token: 0x060210EA RID: 135402 RVA: 0x0093E81A File Offset: 0x0093CA1A
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Temp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170038DE RID: 14558
		// (get) Token: 0x060210EB RID: 135403 RVA: 0x0093E82F File Offset: 0x0093CA2F
		// (set) Token: 0x060210EC RID: 135404 RVA: 0x0093E843 File Offset: 0x0093CA43
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x170038DF RID: 14559
		// (get) Token: 0x060210ED RID: 135405 RVA: 0x0093E858 File Offset: 0x0093CA58
		// (set) Token: 0x060210EE RID: 135406 RVA: 0x0093E86C File Offset: 0x0093CA6C
		public unsafe UStaticMeshComponent RenderActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170038E0 RID: 14560
		// (get) Token: 0x060210EF RID: 135407 RVA: 0x0093E881 File Offset: 0x0093CA81
		// (set) Token: 0x060210F0 RID: 135408 RVA: 0x0093E895 File Offset: 0x0093CA95
		public unsafe UMaterialInterface M_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170038E1 RID: 14561
		// (get) Token: 0x060210F1 RID: 135409 RVA: 0x0093E8AA File Offset: 0x0093CAAA
		// (set) Token: 0x060210F2 RID: 135410 RVA: 0x0093E8BE File Offset: 0x0093CABE
		public unsafe UMaterialInstanceDynamic MI_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x170038E2 RID: 14562
		// (get) Token: 0x060210F3 RID: 135411 RVA: 0x0093E8D3 File Offset: 0x0093CAD3
		// (set) Token: 0x060210F4 RID: 135412 RVA: 0x0093E8E3 File Offset: 0x0093CAE3
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170038E3 RID: 14563
		// (get) Token: 0x060210F5 RID: 135413 RVA: 0x0093E8F4 File Offset: 0x0093CAF4
		// (set) Token: 0x060210F6 RID: 135414 RVA: 0x0093E904 File Offset: 0x0093CB04
		public unsafe float DurationTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170038E4 RID: 14564
		// (get) Token: 0x060210F7 RID: 135415 RVA: 0x0093E915 File Offset: 0x0093CB15
		// (set) Token: 0x060210F8 RID: 135416 RVA: 0x0093E929 File Offset: 0x0093CB29
		public unsafe FLinearColor WaterSuorcePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170038E5 RID: 14565
		// (get) Token: 0x060210F9 RID: 135417 RVA: 0x0093E93E File Offset: 0x0093CB3E
		// (set) Token: 0x060210FA RID: 135418 RVA: 0x0093E952 File Offset: 0x0093CB52
		public unsafe FLinearColor WaterSuorcePos1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170038E6 RID: 14566
		// (get) Token: 0x060210FB RID: 135419 RVA: 0x0093E967 File Offset: 0x0093CB67
		// (set) Token: 0x060210FC RID: 135420 RVA: 0x0093E977 File Offset: 0x0093CB77
		public unsafe float WaterActorHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170038E7 RID: 14567
		// (get) Token: 0x060210FD RID: 135421 RVA: 0x0093E988 File Offset: 0x0093CB88
		// (set) Token: 0x060210FE RID: 135422 RVA: 0x0093E998 File Offset: 0x0093CB98
		public unsafe float PlayerWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x170038E8 RID: 14568
		// (get) Token: 0x060210FF RID: 135423 RVA: 0x0093E9A9 File Offset: 0x0093CBA9
		// (set) Token: 0x06021100 RID: 135424 RVA: 0x0093E9B9 File Offset: 0x0093CBB9
		public unsafe float CameraWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170038E9 RID: 14569
		// (get) Token: 0x06021101 RID: 135425 RVA: 0x0093E9CA File Offset: 0x0093CBCA
		// (set) Token: 0x06021102 RID: 135426 RVA: 0x0093E9DE File Offset: 0x0093CBDE
		public unsafe FVector PlayerWaterNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170038EA RID: 14570
		// (get) Token: 0x06021103 RID: 135427 RVA: 0x0093E9F3 File Offset: 0x0093CBF3
		// (set) Token: 0x06021104 RID: 135428 RVA: 0x0093EA03 File Offset: 0x0093CC03
		public unsafe float PlayerWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170038EB RID: 14571
		// (get) Token: 0x06021105 RID: 135429 RVA: 0x0093EA14 File Offset: 0x0093CC14
		// (set) Token: 0x06021106 RID: 135430 RVA: 0x0093EA24 File Offset: 0x0093CC24
		public unsafe float CameraWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x170038EC RID: 14572
		// (get) Token: 0x06021107 RID: 135431 RVA: 0x0093EA35 File Offset: 0x0093CC35
		// (set) Token: 0x06021108 RID: 135432 RVA: 0x0093EA49 File Offset: 0x0093CC49
		public unsafe FVector CameraWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170038ED RID: 14573
		// (get) Token: 0x06021109 RID: 135433 RVA: 0x0093EA5E File Offset: 0x0093CC5E
		// (set) Token: 0x0602110A RID: 135434 RVA: 0x0093EA72 File Offset: 0x0093CC72
		public unsafe FVector PlayerWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170038EE RID: 14574
		// (get) Token: 0x0602110B RID: 135435 RVA: 0x0093EA87 File Offset: 0x0093CC87
		// (set) Token: 0x0602110C RID: 135436 RVA: 0x0093EA97 File Offset: 0x0093CC97
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170038EF RID: 14575
		// (get) Token: 0x0602110D RID: 135437 RVA: 0x0093EAA8 File Offset: 0x0093CCA8
		// (set) Token: 0x0602110E RID: 135438 RVA: 0x0093EAB8 File Offset: 0x0093CCB8
		public unsafe float AccelerationClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x170038F0 RID: 14576
		// (get) Token: 0x0602110F RID: 135439 RVA: 0x0093EAC9 File Offset: 0x0093CCC9
		// (set) Token: 0x06021110 RID: 135440 RVA: 0x0093EAD9 File Offset: 0x0093CCD9
		public unsafe float Friction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170038F1 RID: 14577
		// (get) Token: 0x06021111 RID: 135441 RVA: 0x0093EAEA File Offset: 0x0093CCEA
		// (set) Token: 0x06021112 RID: 135442 RVA: 0x0093EAFA File Offset: 0x0093CCFA
		public unsafe float Damping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170038F2 RID: 14578
		// (get) Token: 0x06021113 RID: 135443 RVA: 0x0093EB0B File Offset: 0x0093CD0B
		// (set) Token: 0x06021114 RID: 135444 RVA: 0x0093EB1B File Offset: 0x0093CD1B
		public unsafe float VelocityClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170038F3 RID: 14579
		// (get) Token: 0x06021115 RID: 135445 RVA: 0x0093EB2C File Offset: 0x0093CD2C
		// (set) Token: 0x06021116 RID: 135446 RVA: 0x0093EB3C File Offset: 0x0093CD3C
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170038F4 RID: 14580
		// (get) Token: 0x06021117 RID: 135447 RVA: 0x0093EB4D File Offset: 0x0093CD4D
		// (set) Token: 0x06021118 RID: 135448 RVA: 0x0093EB5D File Offset: 0x0093CD5D
		public unsafe int LoopNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x170038F5 RID: 14581
		// (get) Token: 0x06021119 RID: 135449 RVA: 0x0093EB6E File Offset: 0x0093CD6E
		// (set) Token: 0x0602111A RID: 135450 RVA: 0x0093EB82 File Offset: 0x0093CD82
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x170038F6 RID: 14582
		// (get) Token: 0x0602111B RID: 135451 RVA: 0x0093EB97 File Offset: 0x0093CD97
		// (set) Token: 0x0602111C RID: 135452 RVA: 0x0093EBAB File Offset: 0x0093CDAB
		public unsafe BP_HeightmapReadback_C BP_HeightmapReadback
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_HeightmapReadback_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_4_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x170038F7 RID: 14583
		// (get) Token: 0x0602111D RID: 135453 RVA: 0x0093EBC0 File Offset: 0x0093CDC0
		// (set) Token: 0x0602111E RID: 135454 RVA: 0x0093EBD0 File Offset: 0x0093CDD0
		public unsafe int Readback_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x170038F8 RID: 14584
		// (get) Token: 0x0602111F RID: 135455 RVA: 0x0093EBE1 File Offset: 0x0093CDE1
		// (set) Token: 0x06021120 RID: 135456 RVA: 0x0093EBF1 File Offset: 0x0093CDF1
		public unsafe int Readback_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x170038F9 RID: 14585
		// (get) Token: 0x06021121 RID: 135457 RVA: 0x0093EC02 File Offset: 0x0093CE02
		// (set) Token: 0x06021122 RID: 135458 RVA: 0x0093EC12 File Offset: 0x0093CE12
		public unsafe float Readback_Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x170038FA RID: 14586
		// (get) Token: 0x06021123 RID: 135459 RVA: 0x0093EC23 File Offset: 0x0093CE23
		// (set) Token: 0x06021124 RID: 135460 RVA: 0x0093EC37 File Offset: 0x0093CE37
		public unsafe FVector4 CaptureRangeMax_Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x170038FB RID: 14587
		// (get) Token: 0x06021125 RID: 135461 RVA: 0x0093EC4C File Offset: 0x0093CE4C
		// (set) Token: 0x06021126 RID: 135462 RVA: 0x0093EC5C File Offset: 0x0093CE5C
		public unsafe bool DynamicWaterFlow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038FC RID: 14588
		// (get) Token: 0x06021127 RID: 135463 RVA: 0x0093EC6D File Offset: 0x0093CE6D
		// (set) Token: 0x06021128 RID: 135464 RVA: 0x0093EC7D File Offset: 0x0093CE7D
		public unsafe bool OverlapVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038FD RID: 14589
		// (get) Token: 0x06021129 RID: 135465 RVA: 0x0093EC8E File Offset: 0x0093CE8E
		// (set) Token: 0x0602112A RID: 135466 RVA: 0x0093EC9E File Offset: 0x0093CE9E
		public unsafe bool Is_Simulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_57) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_57) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038FE RID: 14590
		// (get) Token: 0x0602112B RID: 135467 RVA: 0x0093ECAF File Offset: 0x0093CEAF
		// (set) Token: 0x0602112C RID: 135468 RVA: 0x0093ECBF File Offset: 0x0093CEBF
		public unsafe float CameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x170038FF RID: 14591
		// (get) Token: 0x0602112D RID: 135469 RVA: 0x0093ECD0 File Offset: 0x0093CED0
		// (set) Token: 0x0602112E RID: 135470 RVA: 0x0093ED09 File Offset: 0x0093CF09
		[Nullable(1)]
		public TArray<AActor> Hidden_Actors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Hidden_Actors) == null)
				{
					result = (this._Hidden_Actors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_59, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Hidden_Actors.CopyAssign(value);
			}
		}

		// Token: 0x17003900 RID: 14592
		// (get) Token: 0x0602112F RID: 135471 RVA: 0x0093ED17 File Offset: 0x0093CF17
		// (set) Token: 0x06021130 RID: 135472 RVA: 0x0093ED2B File Offset: 0x0093CF2B
		public unsafe FVector WaterSourcePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17003901 RID: 14593
		// (get) Token: 0x06021131 RID: 135473 RVA: 0x0093ED40 File Offset: 0x0093CF40
		// (set) Token: 0x06021132 RID: 135474 RVA: 0x0093ED50 File Offset: 0x0093CF50
		public unsafe float WaterSourceYield
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17003902 RID: 14594
		// (get) Token: 0x06021133 RID: 135475 RVA: 0x0093ED61 File Offset: 0x0093CF61
		// (set) Token: 0x06021134 RID: 135476 RVA: 0x0093ED71 File Offset: 0x0093CF71
		public unsafe float WaterSouceSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x17003903 RID: 14595
		// (get) Token: 0x06021135 RID: 135477 RVA: 0x0093ED82 File Offset: 0x0093CF82
		// (set) Token: 0x06021136 RID: 135478 RVA: 0x0093ED92 File Offset: 0x0093CF92
		public unsafe int PixelForSimSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_4_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x06021137 RID: 135479 RVA: 0x0093EDA3 File Offset: 0x0093CFA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReStartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReStartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06021138 RID: 135480 RVA: 0x0093EDB8 File Offset: 0x0093CFB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HideRenderWaterMesh(bool HideRenderWater)
		{
			BP_WaterSimulation_4_C.__HideRenderWaterMesh_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__HideRenderWaterMesh_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__HideRenderWaterMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HideRenderWater = HideRenderWater;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021139 RID: 135481 RVA: 0x0093EDFE File Offset: 0x0093CFFE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalcHeightmap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__CalcHeightmap_NativeFunctionPtr, null);
		}

		// Token: 0x0602113A RID: 135482 RVA: 0x0093EE12 File Offset: 0x0093D012
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPCParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__SetMPCParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0602113B RID: 135483 RVA: 0x0093EE26 File Offset: 0x0093D026
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x0602113C RID: 135484 RVA: 0x0093EE3A File Offset: 0x0093D03A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x0602113D RID: 135485 RVA: 0x0093EE4E File Offset: 0x0093D04E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearWater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ClearWater_NativeFunctionPtr, null);
		}

		// Token: 0x0602113E RID: 135486 RVA: 0x0093EE64 File Offset: 0x0093D064
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialParameter(UMaterialInterface Material, UTexture VelocityHeightFoam, ref UMaterialInstanceDynamic MaterialInstance)
		{
			BP_WaterSimulation_4_C.__SetMaterialParameter_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__SetMaterialParameter_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__SetMaterialParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ptr->VelocityHeightFoam = ((VelocityHeightFoam != null) ? VelocityHeightFoam.NativePtr : IntPtr.Zero);
			ref BP_WaterSimulation_4_C.__SetMaterialParameter_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MaterialInstance;
			ptr2.MaterialInstance = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr);
			MaterialInstance = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MaterialInstance);
		}

		// Token: 0x0602113F RID: 135487 RVA: 0x0093EEF4 File Offset: 0x0093D0F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021140 RID: 135488 RVA: 0x0093EF08 File Offset: 0x0093D108
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_4_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021141 RID: 135489 RVA: 0x0093EF20 File Offset: 0x0093D120
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_4_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_4_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06021142 RID: 135490 RVA: 0x0093EFB0 File Offset: 0x0093D1B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_4_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_4_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06021143 RID: 135491 RVA: 0x0093F03F File Offset: 0x0093D23F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021144 RID: 135492 RVA: 0x0093F053 File Offset: 0x0093D253
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021145 RID: 135493 RVA: 0x0093F068 File Offset: 0x0093D268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterSimulation_4_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021146 RID: 135494 RVA: 0x0093F0B0 File Offset: 0x0093D2B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterSimulation_4_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021147 RID: 135495 RVA: 0x0093F0F7 File Offset: 0x0093D2F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06021148 RID: 135496 RVA: 0x0093F10C File Offset: 0x0093D30C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021149 RID: 135497 RVA: 0x0093F1C8 File Offset: 0x0093D3C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602114A RID: 135498 RVA: 0x0093F254 File Offset: 0x0093D454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602114B RID: 135499 RVA: 0x0093F310 File Offset: 0x0093D510
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_4_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602114C RID: 135500 RVA: 0x0093F39C File Offset: 0x0093D59C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterSimulation_4(int EntryPoint)
		{
			BP_WaterSimulation_4_C.__ExecuteUbergraph_BP_WaterSimulation_4_FunctionParams* ptr = stackalloc BP_WaterSimulation_4_C.__ExecuteUbergraph_BP_WaterSimulation_4_FunctionParams[(UIntPtr)887] + 15L / (long)sizeof(BP_WaterSimulation_4_C.__ExecuteUbergraph_BP_WaterSimulation_4_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_4_C.__ExecuteUbergraph_BP_WaterSimulation_4_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_4_C.__ExecuteUbergraph_BP_WaterSimulation_4_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602114D RID: 135501 RVA: 0x0093F3E6 File Offset: 0x0093D5E6
		protected BP_WaterSimulation_4_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010983 RID: 67971
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x04010984 RID: 67972
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_4.BP_WaterSimulation_4_C";

		// Token: 0x04010985 RID: 67973
		private static IntPtr _ClassPtr;

		// Token: 0x04010986 RID: 67974
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010987 RID: 67975
		internal static int __PropertyOffset_0;

		// Token: 0x04010988 RID: 67976
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010989 RID: 67977
		internal static int __PropertyOffset_1;

		// Token: 0x0401098A RID: 67978
		internal static int __PropertyOffset_2;

		// Token: 0x0401098B RID: 67979
		internal static int __PropertyOffset_3;

		// Token: 0x0401098C RID: 67980
		internal static int __PropertyOffset_4;

		// Token: 0x0401098D RID: 67981
		internal static int __PropertyOffset_5;

		// Token: 0x0401098E RID: 67982
		internal static int __PropertyOffset_6;

		// Token: 0x0401098F RID: 67983
		internal static int __PropertyOffset_7;

		// Token: 0x04010990 RID: 67984
		internal static int __PropertyOffset_8;

		// Token: 0x04010991 RID: 67985
		internal static int __PropertyOffset_9;

		// Token: 0x04010992 RID: 67986
		internal static int __PropertyOffset_10;

		// Token: 0x04010993 RID: 67987
		internal static int __PropertyOffset_11;

		// Token: 0x04010994 RID: 67988
		internal static int __PropertyOffset_12;

		// Token: 0x04010995 RID: 67989
		internal static int __PropertyOffset_13;

		// Token: 0x04010996 RID: 67990
		internal static int __PropertyOffset_14;

		// Token: 0x04010997 RID: 67991
		internal static int __PropertyOffset_15;

		// Token: 0x04010998 RID: 67992
		internal static int __PropertyOffset_16;

		// Token: 0x04010999 RID: 67993
		internal static int __PropertyOffset_17;

		// Token: 0x0401099A RID: 67994
		internal static int __PropertyOffset_18;

		// Token: 0x0401099B RID: 67995
		internal static int __PropertyOffset_19;

		// Token: 0x0401099C RID: 67996
		internal static int __PropertyOffset_20;

		// Token: 0x0401099D RID: 67997
		internal static int __PropertyOffset_21;

		// Token: 0x0401099E RID: 67998
		internal static int __PropertyOffset_22;

		// Token: 0x0401099F RID: 67999
		internal static int __PropertyOffset_23;

		// Token: 0x040109A0 RID: 68000
		internal static int __PropertyOffset_24;

		// Token: 0x040109A1 RID: 68001
		internal static int __PropertyOffset_25;

		// Token: 0x040109A2 RID: 68002
		internal static int __PropertyOffset_26;

		// Token: 0x040109A3 RID: 68003
		internal static int __PropertyOffset_27;

		// Token: 0x040109A4 RID: 68004
		internal static int __PropertyOffset_28;

		// Token: 0x040109A5 RID: 68005
		internal static int __PropertyOffset_29;

		// Token: 0x040109A6 RID: 68006
		internal static int __PropertyOffset_30;

		// Token: 0x040109A7 RID: 68007
		internal static int __PropertyOffset_31;

		// Token: 0x040109A8 RID: 68008
		internal static int __PropertyOffset_32;

		// Token: 0x040109A9 RID: 68009
		internal static int __PropertyOffset_33;

		// Token: 0x040109AA RID: 68010
		internal static int __PropertyOffset_34;

		// Token: 0x040109AB RID: 68011
		internal static int __PropertyOffset_35;

		// Token: 0x040109AC RID: 68012
		internal static int __PropertyOffset_36;

		// Token: 0x040109AD RID: 68013
		internal static int __PropertyOffset_37;

		// Token: 0x040109AE RID: 68014
		internal static int __PropertyOffset_38;

		// Token: 0x040109AF RID: 68015
		internal static int __PropertyOffset_39;

		// Token: 0x040109B0 RID: 68016
		internal static int __PropertyOffset_40;

		// Token: 0x040109B1 RID: 68017
		internal static int __PropertyOffset_41;

		// Token: 0x040109B2 RID: 68018
		internal static int __PropertyOffset_42;

		// Token: 0x040109B3 RID: 68019
		internal static int __PropertyOffset_43;

		// Token: 0x040109B4 RID: 68020
		internal static int __PropertyOffset_44;

		// Token: 0x040109B5 RID: 68021
		internal static int __PropertyOffset_45;

		// Token: 0x040109B6 RID: 68022
		internal static int __PropertyOffset_46;

		// Token: 0x040109B7 RID: 68023
		internal static int __PropertyOffset_47;

		// Token: 0x040109B8 RID: 68024
		internal static int __PropertyOffset_48;

		// Token: 0x040109B9 RID: 68025
		internal static int __PropertyOffset_49;

		// Token: 0x040109BA RID: 68026
		internal static int __PropertyOffset_50;

		// Token: 0x040109BB RID: 68027
		internal static int __PropertyOffset_51;

		// Token: 0x040109BC RID: 68028
		internal static int __PropertyOffset_52;

		// Token: 0x040109BD RID: 68029
		internal static int __PropertyOffset_53;

		// Token: 0x040109BE RID: 68030
		internal static int __PropertyOffset_54;

		// Token: 0x040109BF RID: 68031
		internal static int __PropertyOffset_55;

		// Token: 0x040109C0 RID: 68032
		internal static int __PropertyOffset_56;

		// Token: 0x040109C1 RID: 68033
		internal static int __PropertyOffset_57;

		// Token: 0x040109C2 RID: 68034
		internal static int __PropertyOffset_58;

		// Token: 0x040109C3 RID: 68035
		internal static int __PropertyOffset_59;

		// Token: 0x040109C4 RID: 68036
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Hidden_Actors;

		// Token: 0x040109C5 RID: 68037
		internal static int __PropertyOffset_60;

		// Token: 0x040109C6 RID: 68038
		internal static int __PropertyOffset_61;

		// Token: 0x040109C7 RID: 68039
		internal static int __PropertyOffset_62;

		// Token: 0x040109C8 RID: 68040
		internal static int __PropertyOffset_63;

		// Token: 0x040109C9 RID: 68041
		private static IntPtr __ReStartSim_NativeFunctionPtr;

		// Token: 0x040109CA RID: 68042
		private static IntPtr __HideRenderWaterMesh_NativeFunctionPtr;

		// Token: 0x040109CB RID: 68043
		private static IntPtr __CalcHeightmap_NativeFunctionPtr;

		// Token: 0x040109CC RID: 68044
		private static IntPtr __SetMPCParameters_NativeFunctionPtr;

		// Token: 0x040109CD RID: 68045
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x040109CE RID: 68046
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x040109CF RID: 68047
		private static IntPtr __ClearWater_NativeFunctionPtr;

		// Token: 0x040109D0 RID: 68048
		private static IntPtr __SetMaterialParameter_NativeFunctionPtr;

		// Token: 0x040109D1 RID: 68049
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040109D2 RID: 68050
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x040109D3 RID: 68051
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040109D4 RID: 68052
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040109D5 RID: 68053
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040109D6 RID: 68054
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040109D7 RID: 68055
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040109D8 RID: 68056
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040109D9 RID: 68057
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040109DA RID: 68058
		private static IntPtr __ExecuteUbergraph_BP_WaterSimulation_4_NativeFunctionPtr;

		// Token: 0x02009A6B RID: 39531
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __HideRenderWaterMesh_FunctionParams
		{
			// Token: 0x04032194 RID: 205204
			[FieldOffset(0)]
			public bool HideRenderWater;
		}

		// Token: 0x02009A6C RID: 39532
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetMaterialParameter_FunctionParams
		{
			// Token: 0x04032195 RID: 205205
			[FieldOffset(0)]
			public IntPtr Material;

			// Token: 0x04032196 RID: 205206
			[FieldOffset(8)]
			public IntPtr VelocityHeightFoam;

			// Token: 0x04032197 RID: 205207
			[FieldOffset(16)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009A6D RID: 39533
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x04032198 RID: 205208
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04032199 RID: 205209
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x02009A6E RID: 39534
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403219A RID: 205210
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A6F RID: 39535
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403219B RID: 205211
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403219C RID: 205212
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403219D RID: 205213
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403219E RID: 205214
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403219F RID: 205215
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040321A0 RID: 205216
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A70 RID: 39536
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321A1 RID: 205217
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321A2 RID: 205218
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321A3 RID: 205219
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321A4 RID: 205220
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A71 RID: 39537
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321A5 RID: 205221
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321A6 RID: 205222
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321A7 RID: 205223
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321A8 RID: 205224
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040321A9 RID: 205225
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040321AA RID: 205226
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A72 RID: 39538
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321AB RID: 205227
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321AC RID: 205228
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321AD RID: 205229
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321AE RID: 205230
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A73 RID: 39539
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 872)]
		protected ref struct __ExecuteUbergraph_BP_WaterSimulation_4_FunctionParams
		{
			// Token: 0x040321AF RID: 205231
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
