using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.WaterSim.BP
{
	// Token: 0x02003B4E RID: 15182
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulationDomain.BP_WaterSimulationDomain_C")]
	[UnrealStructLayout(1632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1632)]
	public class BP_WaterSimulationDomain_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020F1C RID: 134940 RVA: 0x0093B968 File Offset: 0x00939B68
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSimulationDomain_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulationDomain.BP_WaterSimulationDomain_C");
			}
			return BP_WaterSimulationDomain_C._ClassPtr;
		}

		// Token: 0x06020F1D RID: 134941 RVA: 0x0093B98C File Offset: 0x00939B8C
		public BP_WaterSimulationDomain_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulationDomain_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020F1E RID: 134942 RVA: 0x0093B9B4 File Offset: 0x00939BB4
		[NullableContext(1)]
		public BP_WaterSimulationDomain_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulationDomain_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700381C RID: 14364
		// (get) Token: 0x06020F1F RID: 134943 RVA: 0x0093B9E8 File Offset: 0x00939BE8
		// (set) Token: 0x06020F20 RID: 134944 RVA: 0x0093BA21 File Offset: 0x00939C21
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700381D RID: 14365
		// (get) Token: 0x06020F21 RID: 134945 RVA: 0x0093BA42 File Offset: 0x00939C42
		// (set) Token: 0x06020F22 RID: 134946 RVA: 0x0093BA56 File Offset: 0x00939C56
		public unsafe UStaticMeshComponent WaterSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700381E RID: 14366
		// (get) Token: 0x06020F23 RID: 134947 RVA: 0x0093BA6B File Offset: 0x00939C6B
		// (set) Token: 0x06020F24 RID: 134948 RVA: 0x0093BA7F File Offset: 0x00939C7F
		public unsafe UStaticMeshComponent SM_Plane512x512
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700381F RID: 14367
		// (get) Token: 0x06020F25 RID: 134949 RVA: 0x0093BA94 File Offset: 0x00939C94
		// (set) Token: 0x06020F26 RID: 134950 RVA: 0x0093BAA8 File Offset: 0x00939CA8
		public unsafe UBoxComponent Sim_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003820 RID: 14368
		// (get) Token: 0x06020F27 RID: 134951 RVA: 0x0093BABD File Offset: 0x00939CBD
		// (set) Token: 0x06020F28 RID: 134952 RVA: 0x0093BAD1 File Offset: 0x00939CD1
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003821 RID: 14369
		// (get) Token: 0x06020F29 RID: 134953 RVA: 0x0093BAE6 File Offset: 0x00939CE6
		// (set) Token: 0x06020F2A RID: 134954 RVA: 0x0093BAFA File Offset: 0x00939CFA
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003822 RID: 14370
		// (get) Token: 0x06020F2B RID: 134955 RVA: 0x0093BB0F File Offset: 0x00939D0F
		// (set) Token: 0x06020F2C RID: 134956 RVA: 0x0093BB1F File Offset: 0x00939D1F
		public unsafe bool Sim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003823 RID: 14371
		// (get) Token: 0x06020F2D RID: 134957 RVA: 0x0093BB30 File Offset: 0x00939D30
		// (set) Token: 0x06020F2E RID: 134958 RVA: 0x0093BB40 File Offset: 0x00939D40
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003824 RID: 14372
		// (get) Token: 0x06020F2F RID: 134959 RVA: 0x0093BB51 File Offset: 0x00939D51
		// (set) Token: 0x06020F30 RID: 134960 RVA: 0x0093BB65 File Offset: 0x00939D65
		public unsafe UMaterial M_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003825 RID: 14373
		// (get) Token: 0x06020F31 RID: 134961 RVA: 0x0093BB7A File Offset: 0x00939D7A
		// (set) Token: 0x06020F32 RID: 134962 RVA: 0x0093BB8E File Offset: 0x00939D8E
		public unsafe UMaterial M_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003826 RID: 14374
		// (get) Token: 0x06020F33 RID: 134963 RVA: 0x0093BBA3 File Offset: 0x00939DA3
		// (set) Token: 0x06020F34 RID: 134964 RVA: 0x0093BBB7 File Offset: 0x00939DB7
		public unsafe UMaterial M_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003827 RID: 14375
		// (get) Token: 0x06020F35 RID: 134965 RVA: 0x0093BBCC File Offset: 0x00939DCC
		// (set) Token: 0x06020F36 RID: 134966 RVA: 0x0093BBE0 File Offset: 0x00939DE0
		public unsafe UMaterial M_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003828 RID: 14376
		// (get) Token: 0x06020F37 RID: 134967 RVA: 0x0093BBF5 File Offset: 0x00939DF5
		// (set) Token: 0x06020F38 RID: 134968 RVA: 0x0093BC09 File Offset: 0x00939E09
		public unsafe UMaterial M_Water_Clear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003829 RID: 14377
		// (get) Token: 0x06020F39 RID: 134969 RVA: 0x0093BC1E File Offset: 0x00939E1E
		// (set) Token: 0x06020F3A RID: 134970 RVA: 0x0093BC32 File Offset: 0x00939E32
		public unsafe UMaterialInstanceDynamic MI_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x1700382A RID: 14378
		// (get) Token: 0x06020F3B RID: 134971 RVA: 0x0093BC47 File Offset: 0x00939E47
		// (set) Token: 0x06020F3C RID: 134972 RVA: 0x0093BC5B File Offset: 0x00939E5B
		public unsafe UMaterialInstanceDynamic MI_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700382B RID: 14379
		// (get) Token: 0x06020F3D RID: 134973 RVA: 0x0093BC70 File Offset: 0x00939E70
		// (set) Token: 0x06020F3E RID: 134974 RVA: 0x0093BC84 File Offset: 0x00939E84
		public unsafe UMaterialInstanceDynamic MI_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700382C RID: 14380
		// (get) Token: 0x06020F3F RID: 134975 RVA: 0x0093BC99 File Offset: 0x00939E99
		// (set) Token: 0x06020F40 RID: 134976 RVA: 0x0093BCAD File Offset: 0x00939EAD
		public unsafe UMaterialInstanceDynamic MI_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700382D RID: 14381
		// (get) Token: 0x06020F41 RID: 134977 RVA: 0x0093BCC2 File Offset: 0x00939EC2
		// (set) Token: 0x06020F42 RID: 134978 RVA: 0x0093BCD6 File Offset: 0x00939ED6
		public unsafe UTextureRenderTarget2D RT_HeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x1700382E RID: 14382
		// (get) Token: 0x06020F43 RID: 134979 RVA: 0x0093BCEB File Offset: 0x00939EEB
		// (set) Token: 0x06020F44 RID: 134980 RVA: 0x0093BCFF File Offset: 0x00939EFF
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700382F RID: 14383
		// (get) Token: 0x06020F45 RID: 134981 RVA: 0x0093BD14 File Offset: 0x00939F14
		// (set) Token: 0x06020F46 RID: 134982 RVA: 0x0093BD28 File Offset: 0x00939F28
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Temp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17003830 RID: 14384
		// (get) Token: 0x06020F47 RID: 134983 RVA: 0x0093BD3D File Offset: 0x00939F3D
		// (set) Token: 0x06020F48 RID: 134984 RVA: 0x0093BD51 File Offset: 0x00939F51
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17003831 RID: 14385
		// (get) Token: 0x06020F49 RID: 134985 RVA: 0x0093BD66 File Offset: 0x00939F66
		// (set) Token: 0x06020F4A RID: 134986 RVA: 0x0093BD7A File Offset: 0x00939F7A
		public unsafe AStaticMeshActor RenderActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17003832 RID: 14386
		// (get) Token: 0x06020F4B RID: 134987 RVA: 0x0093BD8F File Offset: 0x00939F8F
		// (set) Token: 0x06020F4C RID: 134988 RVA: 0x0093BDA3 File Offset: 0x00939FA3
		public unsafe UMaterialInterface M_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17003833 RID: 14387
		// (get) Token: 0x06020F4D RID: 134989 RVA: 0x0093BDB8 File Offset: 0x00939FB8
		// (set) Token: 0x06020F4E RID: 134990 RVA: 0x0093BDCC File Offset: 0x00939FCC
		public unsafe UMaterialInstanceDynamic MI_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17003834 RID: 14388
		// (get) Token: 0x06020F4F RID: 134991 RVA: 0x0093BDE1 File Offset: 0x00939FE1
		// (set) Token: 0x06020F50 RID: 134992 RVA: 0x0093BDF1 File Offset: 0x00939FF1
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003835 RID: 14389
		// (get) Token: 0x06020F51 RID: 134993 RVA: 0x0093BE04 File Offset: 0x0093A004
		// (set) Token: 0x06020F52 RID: 134994 RVA: 0x0093BE3D File Offset: 0x0093A03D
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> BasicInstances
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._BasicInstances) == null)
				{
					result = (this._BasicInstances = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.BasicInstances.CopyAssign(value);
			}
		}

		// Token: 0x17003836 RID: 14390
		// (get) Token: 0x06020F53 RID: 134995 RVA: 0x0093BE4B File Offset: 0x0093A04B
		// (set) Token: 0x06020F54 RID: 134996 RVA: 0x0093BE5B File Offset: 0x0093A05B
		public unsafe float SimulationDeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003837 RID: 14391
		// (get) Token: 0x06020F55 RID: 134997 RVA: 0x0093BE6C File Offset: 0x0093A06C
		// (set) Token: 0x06020F56 RID: 134998 RVA: 0x0093BE7C File Offset: 0x0093A07C
		public unsafe float CaptureOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17003838 RID: 14392
		// (get) Token: 0x06020F57 RID: 134999 RVA: 0x0093BE8D File Offset: 0x0093A08D
		// (set) Token: 0x06020F58 RID: 135000 RVA: 0x0093BEA1 File Offset: 0x0093A0A1
		public unsafe FLinearColor WorldToSimulationUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003839 RID: 14393
		// (get) Token: 0x06020F59 RID: 135001 RVA: 0x0093BEB6 File Offset: 0x0093A0B6
		// (set) Token: 0x06020F5A RID: 135002 RVA: 0x0093BEC6 File Offset: 0x0093A0C6
		public unsafe float FoamFadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700383A RID: 14394
		// (get) Token: 0x06020F5B RID: 135003 RVA: 0x0093BED7 File Offset: 0x0093A0D7
		// (set) Token: 0x06020F5C RID: 135004 RVA: 0x0093BEE7 File Offset: 0x0093A0E7
		public unsafe float FoamShallowGenerate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x1700383B RID: 14395
		// (get) Token: 0x06020F5D RID: 135005 RVA: 0x0093BEF8 File Offset: 0x0093A0F8
		// (set) Token: 0x06020F5E RID: 135006 RVA: 0x0093BF08 File Offset: 0x0093A108
		public unsafe float FoamShallowDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700383C RID: 14396
		// (get) Token: 0x06020F5F RID: 135007 RVA: 0x0093BF19 File Offset: 0x0093A119
		// (set) Token: 0x06020F60 RID: 135008 RVA: 0x0093BF29 File Offset: 0x0093A129
		public unsafe float FoamWaveGenerate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700383D RID: 14397
		// (get) Token: 0x06020F61 RID: 135009 RVA: 0x0093BF3A File Offset: 0x0093A13A
		// (set) Token: 0x06020F62 RID: 135010 RVA: 0x0093BF4A File Offset: 0x0093A14A
		public unsafe float EvaporationHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700383E RID: 14398
		// (get) Token: 0x06020F63 RID: 135011 RVA: 0x0093BF5B File Offset: 0x0093A15B
		// (set) Token: 0x06020F64 RID: 135012 RVA: 0x0093BF6B File Offset: 0x0093A16B
		public unsafe float FluidTransportLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700383F RID: 14399
		// (get) Token: 0x06020F65 RID: 135013 RVA: 0x0093BF7C File Offset: 0x0093A17C
		// (set) Token: 0x06020F66 RID: 135014 RVA: 0x0093BF8C File Offset: 0x0093A18C
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17003840 RID: 14400
		// (get) Token: 0x06020F67 RID: 135015 RVA: 0x0093BF9D File Offset: 0x0093A19D
		// (set) Token: 0x06020F68 RID: 135016 RVA: 0x0093BFAD File Offset: 0x0093A1AD
		public unsafe float VelocityLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17003841 RID: 14401
		// (get) Token: 0x06020F69 RID: 135017 RVA: 0x0093BFBE File Offset: 0x0093A1BE
		// (set) Token: 0x06020F6A RID: 135018 RVA: 0x0093BFCE File Offset: 0x0093A1CE
		public unsafe float AreaWorldPixelSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17003842 RID: 14402
		// (get) Token: 0x06020F6B RID: 135019 RVA: 0x0093BFDF File Offset: 0x0093A1DF
		// (set) Token: 0x06020F6C RID: 135020 RVA: 0x0093BFEF File Offset: 0x0093A1EF
		public unsafe float SlopeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17003843 RID: 14403
		// (get) Token: 0x06020F6D RID: 135021 RVA: 0x0093C000 File Offset: 0x0093A200
		// (set) Token: 0x06020F6E RID: 135022 RVA: 0x0093C010 File Offset: 0x0093A210
		public unsafe float AreaWorldHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17003844 RID: 14404
		// (get) Token: 0x06020F6F RID: 135023 RVA: 0x0093C021 File Offset: 0x0093A221
		// (set) Token: 0x06020F70 RID: 135024 RVA: 0x0093C031 File Offset: 0x0093A231
		public unsafe float Friction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17003845 RID: 14405
		// (get) Token: 0x06020F71 RID: 135025 RVA: 0x0093C042 File Offset: 0x0093A242
		// (set) Token: 0x06020F72 RID: 135026 RVA: 0x0093C052 File Offset: 0x0093A252
		public unsafe float Damping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17003846 RID: 14406
		// (get) Token: 0x06020F73 RID: 135027 RVA: 0x0093C063 File Offset: 0x0093A263
		// (set) Token: 0x06020F74 RID: 135028 RVA: 0x0093C073 File Offset: 0x0093A273
		public unsafe float AccelerationLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17003847 RID: 14407
		// (get) Token: 0x06020F75 RID: 135029 RVA: 0x0093C084 File Offset: 0x0093A284
		// (set) Token: 0x06020F76 RID: 135030 RVA: 0x0093C094 File Offset: 0x0093A294
		public unsafe float OvershootingBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17003848 RID: 14408
		// (get) Token: 0x06020F77 RID: 135031 RVA: 0x0093C0A5 File Offset: 0x0093A2A5
		// (set) Token: 0x06020F78 RID: 135032 RVA: 0x0093C0B9 File Offset: 0x0093A2B9
		public unsafe UMaterialInstanceDynamic IntegrateVelocityInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_44);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_44, value);
			}
		}

		// Token: 0x17003849 RID: 14409
		// (get) Token: 0x06020F79 RID: 135033 RVA: 0x0093C0CE File Offset: 0x0093A2CE
		// (set) Token: 0x06020F7A RID: 135034 RVA: 0x0093C0E2 File Offset: 0x0093A2E2
		public unsafe UMaterialInstanceDynamic IntegrateHeightInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_45);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x1700384A RID: 14410
		// (get) Token: 0x06020F7B RID: 135035 RVA: 0x0093C0F7 File Offset: 0x0093A2F7
		// (set) Token: 0x06020F7C RID: 135036 RVA: 0x0093C107 File Offset: 0x0093A307
		public unsafe float OvershootingEdge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulationDomain_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x1700384B RID: 14411
		// (get) Token: 0x06020F7D RID: 135037 RVA: 0x0093C118 File Offset: 0x0093A318
		// (set) Token: 0x06020F7E RID: 135038 RVA: 0x0093C12C File Offset: 0x0093A32C
		public unsafe UCanvas Canvas
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCanvas>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulationDomain_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x06020F7F RID: 135039 RVA: 0x0093C144 File Offset: 0x0093A344
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateTime(float RealDeltaTime)
		{
			BP_WaterSimulationDomain_C.__UpdateTime_FunctionParams* ptr = stackalloc BP_WaterSimulationDomain_C.__UpdateTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulationDomain_C.__UpdateTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulationDomain_C.__UpdateTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RealDeltaTime = RealDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__UpdateTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020F80 RID: 135040 RVA: 0x0093C18A File Offset: 0x0093A38A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitializeParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__InitializeParameters_NativeFunctionPtr, null);
		}

		// Token: 0x06020F81 RID: 135041 RVA: 0x0093C19E File Offset: 0x0093A39E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x06020F82 RID: 135042 RVA: 0x0093C1B2 File Offset: 0x0093A3B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x06020F83 RID: 135043 RVA: 0x0093C1C6 File Offset: 0x0093A3C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearWater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__ClearWater_NativeFunctionPtr, null);
		}

		// Token: 0x06020F84 RID: 135044 RVA: 0x0093C1DC File Offset: 0x0093A3DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialParameter(UMaterialInterface Material, UTexture VelocityHeightFoam, ref UMaterialInstanceDynamic MaterialInstance)
		{
			BP_WaterSimulationDomain_C.__SetMaterialParameter_FunctionParams* ptr = stackalloc BP_WaterSimulationDomain_C.__SetMaterialParameter_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_WaterSimulationDomain_C.__SetMaterialParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulationDomain_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ptr->VelocityHeightFoam = ((VelocityHeightFoam != null) ? VelocityHeightFoam.NativePtr : IntPtr.Zero);
			ref BP_WaterSimulationDomain_C.__SetMaterialParameter_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MaterialInstance;
			ptr2.MaterialInstance = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr);
			MaterialInstance = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MaterialInstance);
		}

		// Token: 0x06020F85 RID: 135045 RVA: 0x0093C26C File Offset: 0x0093A46C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020F86 RID: 135046 RVA: 0x0093C280 File Offset: 0x0093A480
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020F87 RID: 135047 RVA: 0x0093C295 File Offset: 0x0093A495
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06020F88 RID: 135048 RVA: 0x0093C2AC File Offset: 0x0093A4AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterSimulationDomain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulationDomain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulationDomain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulationDomain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020F89 RID: 135049 RVA: 0x0093C2F4 File Offset: 0x0093A4F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterSimulationDomain_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulationDomain_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulationDomain_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulationDomain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020F8A RID: 135050 RVA: 0x0093C33C File Offset: 0x0093A53C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterSimulationDomain(int EntryPoint)
		{
			BP_WaterSimulationDomain_C.__ExecuteUbergraph_BP_WaterSimulationDomain_FunctionParams* ptr = stackalloc BP_WaterSimulationDomain_C.__ExecuteUbergraph_BP_WaterSimulationDomain_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_WaterSimulationDomain_C.__ExecuteUbergraph_BP_WaterSimulationDomain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulationDomain_C.__ExecuteUbergraph_BP_WaterSimulationDomain_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulationDomain_C.__ExecuteUbergraph_BP_WaterSimulationDomain_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020F8B RID: 135051 RVA: 0x0093C383 File Offset: 0x0093A583
		protected BP_WaterSimulationDomain_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401089C RID: 67740
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulationDomain.BP_WaterSimulationDomain_C";

		// Token: 0x0401089D RID: 67741
		private static IntPtr _ClassPtr;

		// Token: 0x0401089E RID: 67742
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401089F RID: 67743
		internal static int __PropertyOffset_0;

		// Token: 0x040108A0 RID: 67744
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040108A1 RID: 67745
		internal static int __PropertyOffset_1;

		// Token: 0x040108A2 RID: 67746
		internal static int __PropertyOffset_2;

		// Token: 0x040108A3 RID: 67747
		internal static int __PropertyOffset_3;

		// Token: 0x040108A4 RID: 67748
		internal static int __PropertyOffset_4;

		// Token: 0x040108A5 RID: 67749
		internal static int __PropertyOffset_5;

		// Token: 0x040108A6 RID: 67750
		internal static int __PropertyOffset_6;

		// Token: 0x040108A7 RID: 67751
		internal static int __PropertyOffset_7;

		// Token: 0x040108A8 RID: 67752
		internal static int __PropertyOffset_8;

		// Token: 0x040108A9 RID: 67753
		internal static int __PropertyOffset_9;

		// Token: 0x040108AA RID: 67754
		internal static int __PropertyOffset_10;

		// Token: 0x040108AB RID: 67755
		internal static int __PropertyOffset_11;

		// Token: 0x040108AC RID: 67756
		internal static int __PropertyOffset_12;

		// Token: 0x040108AD RID: 67757
		internal static int __PropertyOffset_13;

		// Token: 0x040108AE RID: 67758
		internal static int __PropertyOffset_14;

		// Token: 0x040108AF RID: 67759
		internal static int __PropertyOffset_15;

		// Token: 0x040108B0 RID: 67760
		internal static int __PropertyOffset_16;

		// Token: 0x040108B1 RID: 67761
		internal static int __PropertyOffset_17;

		// Token: 0x040108B2 RID: 67762
		internal static int __PropertyOffset_18;

		// Token: 0x040108B3 RID: 67763
		internal static int __PropertyOffset_19;

		// Token: 0x040108B4 RID: 67764
		internal static int __PropertyOffset_20;

		// Token: 0x040108B5 RID: 67765
		internal static int __PropertyOffset_21;

		// Token: 0x040108B6 RID: 67766
		internal static int __PropertyOffset_22;

		// Token: 0x040108B7 RID: 67767
		internal static int __PropertyOffset_23;

		// Token: 0x040108B8 RID: 67768
		internal static int __PropertyOffset_24;

		// Token: 0x040108B9 RID: 67769
		internal static int __PropertyOffset_25;

		// Token: 0x040108BA RID: 67770
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _BasicInstances;

		// Token: 0x040108BB RID: 67771
		internal static int __PropertyOffset_26;

		// Token: 0x040108BC RID: 67772
		internal static int __PropertyOffset_27;

		// Token: 0x040108BD RID: 67773
		internal static int __PropertyOffset_28;

		// Token: 0x040108BE RID: 67774
		internal static int __PropertyOffset_29;

		// Token: 0x040108BF RID: 67775
		internal static int __PropertyOffset_30;

		// Token: 0x040108C0 RID: 67776
		internal static int __PropertyOffset_31;

		// Token: 0x040108C1 RID: 67777
		internal static int __PropertyOffset_32;

		// Token: 0x040108C2 RID: 67778
		internal static int __PropertyOffset_33;

		// Token: 0x040108C3 RID: 67779
		internal static int __PropertyOffset_34;

		// Token: 0x040108C4 RID: 67780
		internal static int __PropertyOffset_35;

		// Token: 0x040108C5 RID: 67781
		internal static int __PropertyOffset_36;

		// Token: 0x040108C6 RID: 67782
		internal static int __PropertyOffset_37;

		// Token: 0x040108C7 RID: 67783
		internal static int __PropertyOffset_38;

		// Token: 0x040108C8 RID: 67784
		internal static int __PropertyOffset_39;

		// Token: 0x040108C9 RID: 67785
		internal static int __PropertyOffset_40;

		// Token: 0x040108CA RID: 67786
		internal static int __PropertyOffset_41;

		// Token: 0x040108CB RID: 67787
		internal static int __PropertyOffset_42;

		// Token: 0x040108CC RID: 67788
		internal static int __PropertyOffset_43;

		// Token: 0x040108CD RID: 67789
		internal static int __PropertyOffset_44;

		// Token: 0x040108CE RID: 67790
		internal static int __PropertyOffset_45;

		// Token: 0x040108CF RID: 67791
		internal static int __PropertyOffset_46;

		// Token: 0x040108D0 RID: 67792
		internal static int __PropertyOffset_47;

		// Token: 0x040108D1 RID: 67793
		private static IntPtr __UpdateTime_NativeFunctionPtr;

		// Token: 0x040108D2 RID: 67794
		private static IntPtr __InitializeParameters_NativeFunctionPtr;

		// Token: 0x040108D3 RID: 67795
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x040108D4 RID: 67796
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x040108D5 RID: 67797
		private static IntPtr __ClearWater_NativeFunctionPtr;

		// Token: 0x040108D6 RID: 67798
		private static IntPtr __SetMaterialParameter_NativeFunctionPtr;

		// Token: 0x040108D7 RID: 67799
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040108D8 RID: 67800
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040108D9 RID: 67801
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040108DA RID: 67802
		private static IntPtr __ExecuteUbergraph_BP_WaterSimulationDomain_NativeFunctionPtr;

		// Token: 0x02009A55 RID: 39509
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __UpdateTime_FunctionParams
		{
			// Token: 0x04032156 RID: 205142
			[FieldOffset(0)]
			public float RealDeltaTime;
		}

		// Token: 0x02009A56 RID: 39510
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __SetMaterialParameter_FunctionParams
		{
			// Token: 0x04032157 RID: 205143
			[FieldOffset(0)]
			public IntPtr Material;

			// Token: 0x04032158 RID: 205144
			[FieldOffset(8)]
			public IntPtr VelocityHeightFoam;

			// Token: 0x04032159 RID: 205145
			[FieldOffset(16)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009A57 RID: 39511
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403215A RID: 205146
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A58 RID: 39512
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_WaterSimulationDomain_FunctionParams
		{
			// Token: 0x0403215B RID: 205147
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
