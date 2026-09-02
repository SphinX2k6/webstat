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
	// Token: 0x02003B50 RID: 15184
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_3_5_CaptureDepth.BP_WaterSimulation_3_5_CaptureDepth_C")]
	[UnrealStructLayout(1760, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1760)]
	public class BP_WaterSimulation_3_5_CaptureDepth_C : AKuroBPActor, IUnrealUObject, IUnrealObject, INiagaraParticleCallbackHandler, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0602101B RID: 135195 RVA: 0x0093D313 File Offset: 0x0093B513
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WaterSimulation_3_5_CaptureDepth_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_3_5_CaptureDepth.BP_WaterSimulation_3_5_CaptureDepth_C");
			}
			return BP_WaterSimulation_3_5_CaptureDepth_C._ClassPtr;
		}

		// Token: 0x0602101C RID: 135196 RVA: 0x0093D337 File Offset: 0x0093B537
		int INiagaraParticleCallbackHandler.InterfaceOffset()
		{
			return BP_WaterSimulation_3_5_CaptureDepth_C.__InterfaceOffset_INiagaraParticleCallbackHandler;
		}

		// Token: 0x0602101D RID: 135197 RVA: 0x0093D340 File Offset: 0x0093B540
		public BP_WaterSimulation_3_5_CaptureDepth_C() : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_3_5_CaptureDepth_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602101E RID: 135198 RVA: 0x0093D368 File Offset: 0x0093B568
		[NullableContext(1)]
		public BP_WaterSimulation_3_5_CaptureDepth_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WaterSimulation_3_5_CaptureDepth_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003886 RID: 14470
		// (get) Token: 0x0602101F RID: 135199 RVA: 0x0093D39C File Offset: 0x0093B59C
		// (set) Token: 0x06021020 RID: 135200 RVA: 0x0093D3D5 File Offset: 0x0093B5D5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003887 RID: 14471
		// (get) Token: 0x06021021 RID: 135201 RVA: 0x0093D3F6 File Offset: 0x0093B5F6
		// (set) Token: 0x06021022 RID: 135202 RVA: 0x0093D40A File Offset: 0x0093B60A
		public unsafe UKuroCustomCaptureVolume KuroCustomCaptureVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCustomCaptureVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003888 RID: 14472
		// (get) Token: 0x06021023 RID: 135203 RVA: 0x0093D41F File Offset: 0x0093B61F
		// (set) Token: 0x06021024 RID: 135204 RVA: 0x0093D433 File Offset: 0x0093B633
		public unsafe UStaticMeshComponent WaterRender_Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003889 RID: 14473
		// (get) Token: 0x06021025 RID: 135205 RVA: 0x0093D448 File Offset: 0x0093B648
		// (set) Token: 0x06021026 RID: 135206 RVA: 0x0093D45C File Offset: 0x0093B65C
		public unsafe UBoxComponent WaterInteraction_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700388A RID: 14474
		// (get) Token: 0x06021027 RID: 135207 RVA: 0x0093D471 File Offset: 0x0093B671
		// (set) Token: 0x06021028 RID: 135208 RVA: 0x0093D485 File Offset: 0x0093B685
		public unsafe UStaticMeshComponent WaterInteractionCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700388B RID: 14475
		// (get) Token: 0x06021029 RID: 135209 RVA: 0x0093D49A File Offset: 0x0093B69A
		// (set) Token: 0x0602102A RID: 135210 RVA: 0x0093D4AE File Offset: 0x0093B6AE
		public unsafe UStaticMeshComponent WaterSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700388C RID: 14476
		// (get) Token: 0x0602102B RID: 135211 RVA: 0x0093D4C3 File Offset: 0x0093B6C3
		// (set) Token: 0x0602102C RID: 135212 RVA: 0x0093D4D7 File Offset: 0x0093B6D7
		public unsafe UBoxComponent Sim_Volume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700388D RID: 14477
		// (get) Token: 0x0602102D RID: 135213 RVA: 0x0093D4EC File Offset: 0x0093B6EC
		// (set) Token: 0x0602102E RID: 135214 RVA: 0x0093D500 File Offset: 0x0093B700
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700388E RID: 14478
		// (get) Token: 0x0602102F RID: 135215 RVA: 0x0093D515 File Offset: 0x0093B715
		// (set) Token: 0x06021030 RID: 135216 RVA: 0x0093D525 File Offset: 0x0093B725
		public unsafe bool Sim
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700388F RID: 14479
		// (get) Token: 0x06021031 RID: 135217 RVA: 0x0093D536 File Offset: 0x0093B736
		// (set) Token: 0x06021032 RID: 135218 RVA: 0x0093D546 File Offset: 0x0093B746
		public unsafe bool SeqControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003890 RID: 14480
		// (get) Token: 0x06021033 RID: 135219 RVA: 0x0093D557 File Offset: 0x0093B757
		// (set) Token: 0x06021034 RID: 135220 RVA: 0x0093D567 File Offset: 0x0093B767
		public unsafe bool DAControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003891 RID: 14481
		// (get) Token: 0x06021035 RID: 135221 RVA: 0x0093D578 File Offset: 0x0093B778
		// (set) Token: 0x06021036 RID: 135222 RVA: 0x0093D58C File Offset: 0x0093B78C
		public unsafe FVector SimBoxOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003892 RID: 14482
		// (get) Token: 0x06021037 RID: 135223 RVA: 0x0093D5A1 File Offset: 0x0093B7A1
		// (set) Token: 0x06021038 RID: 135224 RVA: 0x0093D5B5 File Offset: 0x0093B7B5
		public unsafe FVector SimBoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003893 RID: 14483
		// (get) Token: 0x06021039 RID: 135225 RVA: 0x0093D5CA File Offset: 0x0093B7CA
		// (set) Token: 0x0602103A RID: 135226 RVA: 0x0093D5DA File Offset: 0x0093B7DA
		public unsafe int SimSize_M_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003894 RID: 14484
		// (get) Token: 0x0602103B RID: 135227 RVA: 0x0093D5EB File Offset: 0x0093B7EB
		// (set) Token: 0x0602103C RID: 135228 RVA: 0x0093D5FF File Offset: 0x0093B7FF
		public unsafe UMaterial M_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003895 RID: 14485
		// (get) Token: 0x0602103D RID: 135229 RVA: 0x0093D614 File Offset: 0x0093B814
		// (set) Token: 0x0602103E RID: 135230 RVA: 0x0093D628 File Offset: 0x0093B828
		public unsafe UMaterial M_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003896 RID: 14486
		// (get) Token: 0x0602103F RID: 135231 RVA: 0x0093D63D File Offset: 0x0093B83D
		// (set) Token: 0x06021040 RID: 135232 RVA: 0x0093D651 File Offset: 0x0093B851
		public unsafe UMaterial M_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003897 RID: 14487
		// (get) Token: 0x06021041 RID: 135233 RVA: 0x0093D666 File Offset: 0x0093B866
		// (set) Token: 0x06021042 RID: 135234 RVA: 0x0093D67A File Offset: 0x0093B87A
		public unsafe UMaterial M_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003898 RID: 14488
		// (get) Token: 0x06021043 RID: 135235 RVA: 0x0093D68F File Offset: 0x0093B88F
		// (set) Token: 0x06021044 RID: 135236 RVA: 0x0093D6A3 File Offset: 0x0093B8A3
		public unsafe UMaterial M_Water_Clear
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterial>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003899 RID: 14489
		// (get) Token: 0x06021045 RID: 135237 RVA: 0x0093D6B8 File Offset: 0x0093B8B8
		// (set) Token: 0x06021046 RID: 135238 RVA: 0x0093D6CC File Offset: 0x0093B8CC
		public unsafe UMaterialInstanceDynamic MI_Velocity
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700389A RID: 14490
		// (get) Token: 0x06021047 RID: 135239 RVA: 0x0093D6E1 File Offset: 0x0093B8E1
		// (set) Token: 0x06021048 RID: 135240 RVA: 0x0093D6F5 File Offset: 0x0093B8F5
		public unsafe UMaterialInstanceDynamic MI_Height
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x1700389B RID: 14491
		// (get) Token: 0x06021049 RID: 135241 RVA: 0x0093D70A File Offset: 0x0093B90A
		// (set) Token: 0x0602104A RID: 135242 RVA: 0x0093D71E File Offset: 0x0093B91E
		public unsafe UMaterialInstanceDynamic MI_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x1700389C RID: 14492
		// (get) Token: 0x0602104B RID: 135243 RVA: 0x0093D733 File Offset: 0x0093B933
		// (set) Token: 0x0602104C RID: 135244 RVA: 0x0093D747 File Offset: 0x0093B947
		public unsafe UMaterialInstanceDynamic MI_PreView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x1700389D RID: 14493
		// (get) Token: 0x0602104D RID: 135245 RVA: 0x0093D75C File Offset: 0x0093B95C
		// (set) Token: 0x0602104E RID: 135246 RVA: 0x0093D770 File Offset: 0x0093B970
		public unsafe UTextureRenderTarget2D RT_HeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x1700389E RID: 14494
		// (get) Token: 0x0602104F RID: 135247 RVA: 0x0093D785 File Offset: 0x0093B985
		// (set) Token: 0x06021050 RID: 135248 RVA: 0x0093D799 File Offset: 0x0093B999
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x1700389F RID: 14495
		// (get) Token: 0x06021051 RID: 135249 RVA: 0x0093D7AE File Offset: 0x0093B9AE
		// (set) Token: 0x06021052 RID: 135250 RVA: 0x0093D7C2 File Offset: 0x0093B9C2
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Temp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x170038A0 RID: 14496
		// (get) Token: 0x06021053 RID: 135251 RVA: 0x0093D7D7 File Offset: 0x0093B9D7
		// (set) Token: 0x06021054 RID: 135252 RVA: 0x0093D7EB File Offset: 0x0093B9EB
		public unsafe UTextureRenderTarget2D RT_Water_VelocityHeightFoam_Blur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x170038A1 RID: 14497
		// (get) Token: 0x06021055 RID: 135253 RVA: 0x0093D800 File Offset: 0x0093BA00
		// (set) Token: 0x06021056 RID: 135254 RVA: 0x0093D814 File Offset: 0x0093BA14
		public unsafe UStaticMeshComponent RenderActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170038A2 RID: 14498
		// (get) Token: 0x06021057 RID: 135255 RVA: 0x0093D829 File Offset: 0x0093BA29
		// (set) Token: 0x06021058 RID: 135256 RVA: 0x0093D83D File Offset: 0x0093BA3D
		public unsafe UMaterialInterface M_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x170038A3 RID: 14499
		// (get) Token: 0x06021059 RID: 135257 RVA: 0x0093D852 File Offset: 0x0093BA52
		// (set) Token: 0x0602105A RID: 135258 RVA: 0x0093D866 File Offset: 0x0093BA66
		public unsafe UMaterialInstanceDynamic MI_Water_Render
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x170038A4 RID: 14500
		// (get) Token: 0x0602105B RID: 135259 RVA: 0x0093D87B File Offset: 0x0093BA7B
		// (set) Token: 0x0602105C RID: 135260 RVA: 0x0093D88B File Offset: 0x0093BA8B
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170038A5 RID: 14501
		// (get) Token: 0x0602105D RID: 135261 RVA: 0x0093D89C File Offset: 0x0093BA9C
		// (set) Token: 0x0602105E RID: 135262 RVA: 0x0093D8AC File Offset: 0x0093BAAC
		public unsafe float DurationTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170038A6 RID: 14502
		// (get) Token: 0x0602105F RID: 135263 RVA: 0x0093D8BD File Offset: 0x0093BABD
		// (set) Token: 0x06021060 RID: 135264 RVA: 0x0093D8D1 File Offset: 0x0093BAD1
		public unsafe FLinearColor WaterSuorcePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170038A7 RID: 14503
		// (get) Token: 0x06021061 RID: 135265 RVA: 0x0093D8E6 File Offset: 0x0093BAE6
		// (set) Token: 0x06021062 RID: 135266 RVA: 0x0093D8FA File Offset: 0x0093BAFA
		public unsafe FLinearColor WaterSuorcePos1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170038A8 RID: 14504
		// (get) Token: 0x06021063 RID: 135267 RVA: 0x0093D90F File Offset: 0x0093BB0F
		// (set) Token: 0x06021064 RID: 135268 RVA: 0x0093D91F File Offset: 0x0093BB1F
		public unsafe float WaterActorHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170038A9 RID: 14505
		// (get) Token: 0x06021065 RID: 135269 RVA: 0x0093D930 File Offset: 0x0093BB30
		// (set) Token: 0x06021066 RID: 135270 RVA: 0x0093D940 File Offset: 0x0093BB40
		public unsafe float PlayerWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x170038AA RID: 14506
		// (get) Token: 0x06021067 RID: 135271 RVA: 0x0093D951 File Offset: 0x0093BB51
		// (set) Token: 0x06021068 RID: 135272 RVA: 0x0093D961 File Offset: 0x0093BB61
		public unsafe float CameraWaterHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170038AB RID: 14507
		// (get) Token: 0x06021069 RID: 135273 RVA: 0x0093D972 File Offset: 0x0093BB72
		// (set) Token: 0x0602106A RID: 135274 RVA: 0x0093D986 File Offset: 0x0093BB86
		public unsafe FVector PlayerWaterNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170038AC RID: 14508
		// (get) Token: 0x0602106B RID: 135275 RVA: 0x0093D99B File Offset: 0x0093BB9B
		// (set) Token: 0x0602106C RID: 135276 RVA: 0x0093D9AB File Offset: 0x0093BBAB
		public unsafe float PlayerWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170038AD RID: 14509
		// (get) Token: 0x0602106D RID: 135277 RVA: 0x0093D9BC File Offset: 0x0093BBBC
		// (set) Token: 0x0602106E RID: 135278 RVA: 0x0093D9CC File Offset: 0x0093BBCC
		public unsafe float CameraWaterVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x170038AE RID: 14510
		// (get) Token: 0x0602106F RID: 135279 RVA: 0x0093D9DD File Offset: 0x0093BBDD
		// (set) Token: 0x06021070 RID: 135280 RVA: 0x0093D9F1 File Offset: 0x0093BBF1
		public unsafe FVector CameraWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170038AF RID: 14511
		// (get) Token: 0x06021071 RID: 135281 RVA: 0x0093DA06 File Offset: 0x0093BC06
		// (set) Token: 0x06021072 RID: 135282 RVA: 0x0093DA1A File Offset: 0x0093BC1A
		public unsafe FVector PlayerWaterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170038B0 RID: 14512
		// (get) Token: 0x06021073 RID: 135283 RVA: 0x0093DA2F File Offset: 0x0093BC2F
		// (set) Token: 0x06021074 RID: 135284 RVA: 0x0093DA3F File Offset: 0x0093BC3F
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170038B1 RID: 14513
		// (get) Token: 0x06021075 RID: 135285 RVA: 0x0093DA50 File Offset: 0x0093BC50
		// (set) Token: 0x06021076 RID: 135286 RVA: 0x0093DA60 File Offset: 0x0093BC60
		public unsafe float AccelerationClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x170038B2 RID: 14514
		// (get) Token: 0x06021077 RID: 135287 RVA: 0x0093DA71 File Offset: 0x0093BC71
		// (set) Token: 0x06021078 RID: 135288 RVA: 0x0093DA81 File Offset: 0x0093BC81
		public unsafe float Friction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170038B3 RID: 14515
		// (get) Token: 0x06021079 RID: 135289 RVA: 0x0093DA92 File Offset: 0x0093BC92
		// (set) Token: 0x0602107A RID: 135290 RVA: 0x0093DAA2 File Offset: 0x0093BCA2
		public unsafe float Damping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170038B4 RID: 14516
		// (get) Token: 0x0602107B RID: 135291 RVA: 0x0093DAB3 File Offset: 0x0093BCB3
		// (set) Token: 0x0602107C RID: 135292 RVA: 0x0093DAC3 File Offset: 0x0093BCC3
		public unsafe float VelocityClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170038B5 RID: 14517
		// (get) Token: 0x0602107D RID: 135293 RVA: 0x0093DAD4 File Offset: 0x0093BCD4
		// (set) Token: 0x0602107E RID: 135294 RVA: 0x0093DAE4 File Offset: 0x0093BCE4
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170038B6 RID: 14518
		// (get) Token: 0x0602107F RID: 135295 RVA: 0x0093DAF5 File Offset: 0x0093BCF5
		// (set) Token: 0x06021080 RID: 135296 RVA: 0x0093DB05 File Offset: 0x0093BD05
		public unsafe int LoopNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x170038B7 RID: 14519
		// (get) Token: 0x06021081 RID: 135297 RVA: 0x0093DB16 File Offset: 0x0093BD16
		// (set) Token: 0x06021082 RID: 135298 RVA: 0x0093DB2A File Offset: 0x0093BD2A
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x170038B8 RID: 14520
		// (get) Token: 0x06021083 RID: 135299 RVA: 0x0093DB3F File Offset: 0x0093BD3F
		// (set) Token: 0x06021084 RID: 135300 RVA: 0x0093DB53 File Offset: 0x0093BD53
		public unsafe BP_HeightmapReadback_C BP_HeightmapReadback
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_HeightmapReadback_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x170038B9 RID: 14521
		// (get) Token: 0x06021085 RID: 135301 RVA: 0x0093DB68 File Offset: 0x0093BD68
		// (set) Token: 0x06021086 RID: 135302 RVA: 0x0093DB78 File Offset: 0x0093BD78
		public unsafe int Readback_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x170038BA RID: 14522
		// (get) Token: 0x06021087 RID: 135303 RVA: 0x0093DB89 File Offset: 0x0093BD89
		// (set) Token: 0x06021088 RID: 135304 RVA: 0x0093DB99 File Offset: 0x0093BD99
		public unsafe int Readback_Y
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x170038BB RID: 14523
		// (get) Token: 0x06021089 RID: 135305 RVA: 0x0093DBAA File Offset: 0x0093BDAA
		// (set) Token: 0x0602108A RID: 135306 RVA: 0x0093DBBA File Offset: 0x0093BDBA
		public unsafe float Readback_Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x170038BC RID: 14524
		// (get) Token: 0x0602108B RID: 135307 RVA: 0x0093DBCB File Offset: 0x0093BDCB
		// (set) Token: 0x0602108C RID: 135308 RVA: 0x0093DBDF File Offset: 0x0093BDDF
		public unsafe FVector4 CaptureRangeMax_Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x170038BD RID: 14525
		// (get) Token: 0x0602108D RID: 135309 RVA: 0x0093DBF4 File Offset: 0x0093BDF4
		// (set) Token: 0x0602108E RID: 135310 RVA: 0x0093DC04 File Offset: 0x0093BE04
		public unsafe bool DynamicWaterFlow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038BE RID: 14526
		// (get) Token: 0x0602108F RID: 135311 RVA: 0x0093DC15 File Offset: 0x0093BE15
		// (set) Token: 0x06021090 RID: 135312 RVA: 0x0093DC25 File Offset: 0x0093BE25
		public unsafe bool OverlapVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038BF RID: 14527
		// (get) Token: 0x06021091 RID: 135313 RVA: 0x0093DC36 File Offset: 0x0093BE36
		// (set) Token: 0x06021092 RID: 135314 RVA: 0x0093DC46 File Offset: 0x0093BE46
		public unsafe bool Is_Simulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_57) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_57) = (value ? 1 : 0);
			}
		}

		// Token: 0x170038C0 RID: 14528
		// (get) Token: 0x06021093 RID: 135315 RVA: 0x0093DC57 File Offset: 0x0093BE57
		// (set) Token: 0x06021094 RID: 135316 RVA: 0x0093DC67 File Offset: 0x0093BE67
		public unsafe float CameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x170038C1 RID: 14529
		// (get) Token: 0x06021095 RID: 135317 RVA: 0x0093DC78 File Offset: 0x0093BE78
		// (set) Token: 0x06021096 RID: 135318 RVA: 0x0093DCB1 File Offset: 0x0093BEB1
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
					result = (this._Hidden_Actors = new TArray<AActor>(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_59, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Hidden_Actors.CopyAssign(value);
			}
		}

		// Token: 0x170038C2 RID: 14530
		// (get) Token: 0x06021097 RID: 135319 RVA: 0x0093DCBF File Offset: 0x0093BEBF
		// (set) Token: 0x06021098 RID: 135320 RVA: 0x0093DCCF File Offset: 0x0093BECF
		public unsafe int TextureSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x170038C3 RID: 14531
		// (get) Token: 0x06021099 RID: 135321 RVA: 0x0093DCE0 File Offset: 0x0093BEE0
		// (set) Token: 0x0602109A RID: 135322 RVA: 0x0093DCF4 File Offset: 0x0093BEF4
		[Nullable(1)]
		public unsafe string SavePath
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_61)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_WaterSimulation_3_5_CaptureDepth_C.__PropertyOffset_61)), value);
			}
		}

		// Token: 0x0602109B RID: 135323 RVA: 0x0093DD09 File Offset: 0x0093BF09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SaveCaptureDepthMap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__SaveCaptureDepthMap_NativeFunctionPtr, null);
		}

		// Token: 0x0602109C RID: 135324 RVA: 0x0093DD1D File Offset: 0x0093BF1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReStartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReStartSim_NativeFunctionPtr, null);
		}

		// Token: 0x0602109D RID: 135325 RVA: 0x0093DD34 File Offset: 0x0093BF34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HideRenderWaterMesh(bool HideRenderWater)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__HideRenderWaterMesh_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__HideRenderWaterMesh_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__HideRenderWaterMesh_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HideRenderWater = HideRenderWater;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__HideRenderWaterMesh_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602109E RID: 135326 RVA: 0x0093DD7A File Offset: 0x0093BF7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalcHeightmap()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__CalcHeightmap_NativeFunctionPtr, null);
		}

		// Token: 0x0602109F RID: 135327 RVA: 0x0093DD8E File Offset: 0x0093BF8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMPCParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__SetMPCParameters_NativeFunctionPtr, null);
		}

		// Token: 0x060210A0 RID: 135328 RVA: 0x0093DDA2 File Offset: 0x0093BFA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__StopSim_NativeFunctionPtr, null);
		}

		// Token: 0x060210A1 RID: 135329 RVA: 0x0093DDB6 File Offset: 0x0093BFB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSim()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__StartSim_NativeFunctionPtr, null);
		}

		// Token: 0x060210A2 RID: 135330 RVA: 0x0093DDCA File Offset: 0x0093BFCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearWater()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ClearWater_NativeFunctionPtr, null);
		}

		// Token: 0x060210A3 RID: 135331 RVA: 0x0093DDE0 File Offset: 0x0093BFE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialParameter(UMaterialInterface Material, UTexture VelocityHeightFoam, ref UMaterialInstanceDynamic MaterialInstance)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__SetMaterialParameter_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__SetMaterialParameter_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__SetMaterialParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			ptr->VelocityHeightFoam = ((VelocityHeightFoam != null) ? VelocityHeightFoam.NativePtr : IntPtr.Zero);
			ref BP_WaterSimulation_3_5_CaptureDepth_C.__SetMaterialParameter_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MaterialInstance;
			ptr2.MaterialInstance = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__SetMaterialParameter_NativeFunctionPtr, (void*)ptr);
			MaterialInstance = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MaterialInstance);
		}

		// Token: 0x060210A4 RID: 135332 RVA: 0x0093DE70 File Offset: 0x0093C070
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060210A5 RID: 135333 RVA: 0x0093DE84 File Offset: 0x0093C084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060210A6 RID: 135334 RVA: 0x0093DE9C File Offset: 0x0093C09C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060210A7 RID: 135335 RVA: 0x0093DF58 File Offset: 0x0093C158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060210A8 RID: 135336 RVA: 0x0093DFE4 File Offset: 0x0093C1E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060210A9 RID: 135337 RVA: 0x0093E0A0 File Offset: 0x0093C2A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060210AA RID: 135338 RVA: 0x0093E129 File Offset: 0x0093C329
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060210AB RID: 135339 RVA: 0x0093E140 File Offset: 0x0093C340
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060210AC RID: 135340 RVA: 0x0093E188 File Offset: 0x0093C388
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060210AD RID: 135341 RVA: 0x0093E1CF File Offset: 0x0093C3CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060210AE RID: 135342 RVA: 0x0093E1E3 File Offset: 0x0093C3E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060210AF RID: 135343 RVA: 0x0093E1F8 File Offset: 0x0093C3F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReceiveParticleData([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060210B0 RID: 135344 RVA: 0x0093E288 File Offset: 0x0093C488
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveParticleData_Implementation([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FBasicParticleData> Data, UNiagaraSystem NiagaraSystem)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
			object obj = Data;
			if (obj != null)
			{
				obj.MoveTo(&ptr->Data);
			}
			ptr->NiagaraSystem = ((NiagaraSystem != null) ? NiagaraSystem.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 0);
			object obj2 = Data;
			if (obj2 != null)
			{
				obj2.MoveAssign(&ptr->Data);
			}
			UnrealReflectionUtils.DestroyStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ReceiveParticleData_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x060210B1 RID: 135345 RVA: 0x0093E318 File Offset: 0x0093C518
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth(int EntryPoint)
		{
			BP_WaterSimulation_3_5_CaptureDepth_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_FunctionParams* ptr = stackalloc BP_WaterSimulation_3_5_CaptureDepth_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_FunctionParams[(UIntPtr)599] + 15L / (long)sizeof(BP_WaterSimulation_3_5_CaptureDepth_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WaterSimulation_3_5_CaptureDepth_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WaterSimulation_3_5_CaptureDepth_C.__ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060210B2 RID: 135346 RVA: 0x0093E362 File Offset: 0x0093C562
		protected BP_WaterSimulation_3_5_CaptureDepth_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401092C RID: 67884
		internal static int __InterfaceOffset_INiagaraParticleCallbackHandler;

		// Token: 0x0401092D RID: 67885
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/WaterSim/BP/BP_WaterSimulation_3_5_CaptureDepth.BP_WaterSimulation_3_5_CaptureDepth_C";

		// Token: 0x0401092E RID: 67886
		private static IntPtr _ClassPtr;

		// Token: 0x0401092F RID: 67887
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010930 RID: 67888
		internal static int __PropertyOffset_0;

		// Token: 0x04010931 RID: 67889
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010932 RID: 67890
		internal static int __PropertyOffset_1;

		// Token: 0x04010933 RID: 67891
		internal static int __PropertyOffset_2;

		// Token: 0x04010934 RID: 67892
		internal static int __PropertyOffset_3;

		// Token: 0x04010935 RID: 67893
		internal static int __PropertyOffset_4;

		// Token: 0x04010936 RID: 67894
		internal static int __PropertyOffset_5;

		// Token: 0x04010937 RID: 67895
		internal static int __PropertyOffset_6;

		// Token: 0x04010938 RID: 67896
		internal static int __PropertyOffset_7;

		// Token: 0x04010939 RID: 67897
		internal static int __PropertyOffset_8;

		// Token: 0x0401093A RID: 67898
		internal static int __PropertyOffset_9;

		// Token: 0x0401093B RID: 67899
		internal static int __PropertyOffset_10;

		// Token: 0x0401093C RID: 67900
		internal static int __PropertyOffset_11;

		// Token: 0x0401093D RID: 67901
		internal static int __PropertyOffset_12;

		// Token: 0x0401093E RID: 67902
		internal static int __PropertyOffset_13;

		// Token: 0x0401093F RID: 67903
		internal static int __PropertyOffset_14;

		// Token: 0x04010940 RID: 67904
		internal static int __PropertyOffset_15;

		// Token: 0x04010941 RID: 67905
		internal static int __PropertyOffset_16;

		// Token: 0x04010942 RID: 67906
		internal static int __PropertyOffset_17;

		// Token: 0x04010943 RID: 67907
		internal static int __PropertyOffset_18;

		// Token: 0x04010944 RID: 67908
		internal static int __PropertyOffset_19;

		// Token: 0x04010945 RID: 67909
		internal static int __PropertyOffset_20;

		// Token: 0x04010946 RID: 67910
		internal static int __PropertyOffset_21;

		// Token: 0x04010947 RID: 67911
		internal static int __PropertyOffset_22;

		// Token: 0x04010948 RID: 67912
		internal static int __PropertyOffset_23;

		// Token: 0x04010949 RID: 67913
		internal static int __PropertyOffset_24;

		// Token: 0x0401094A RID: 67914
		internal static int __PropertyOffset_25;

		// Token: 0x0401094B RID: 67915
		internal static int __PropertyOffset_26;

		// Token: 0x0401094C RID: 67916
		internal static int __PropertyOffset_27;

		// Token: 0x0401094D RID: 67917
		internal static int __PropertyOffset_28;

		// Token: 0x0401094E RID: 67918
		internal static int __PropertyOffset_29;

		// Token: 0x0401094F RID: 67919
		internal static int __PropertyOffset_30;

		// Token: 0x04010950 RID: 67920
		internal static int __PropertyOffset_31;

		// Token: 0x04010951 RID: 67921
		internal static int __PropertyOffset_32;

		// Token: 0x04010952 RID: 67922
		internal static int __PropertyOffset_33;

		// Token: 0x04010953 RID: 67923
		internal static int __PropertyOffset_34;

		// Token: 0x04010954 RID: 67924
		internal static int __PropertyOffset_35;

		// Token: 0x04010955 RID: 67925
		internal static int __PropertyOffset_36;

		// Token: 0x04010956 RID: 67926
		internal static int __PropertyOffset_37;

		// Token: 0x04010957 RID: 67927
		internal static int __PropertyOffset_38;

		// Token: 0x04010958 RID: 67928
		internal static int __PropertyOffset_39;

		// Token: 0x04010959 RID: 67929
		internal static int __PropertyOffset_40;

		// Token: 0x0401095A RID: 67930
		internal static int __PropertyOffset_41;

		// Token: 0x0401095B RID: 67931
		internal static int __PropertyOffset_42;

		// Token: 0x0401095C RID: 67932
		internal static int __PropertyOffset_43;

		// Token: 0x0401095D RID: 67933
		internal static int __PropertyOffset_44;

		// Token: 0x0401095E RID: 67934
		internal static int __PropertyOffset_45;

		// Token: 0x0401095F RID: 67935
		internal static int __PropertyOffset_46;

		// Token: 0x04010960 RID: 67936
		internal static int __PropertyOffset_47;

		// Token: 0x04010961 RID: 67937
		internal static int __PropertyOffset_48;

		// Token: 0x04010962 RID: 67938
		internal static int __PropertyOffset_49;

		// Token: 0x04010963 RID: 67939
		internal static int __PropertyOffset_50;

		// Token: 0x04010964 RID: 67940
		internal static int __PropertyOffset_51;

		// Token: 0x04010965 RID: 67941
		internal static int __PropertyOffset_52;

		// Token: 0x04010966 RID: 67942
		internal static int __PropertyOffset_53;

		// Token: 0x04010967 RID: 67943
		internal static int __PropertyOffset_54;

		// Token: 0x04010968 RID: 67944
		internal static int __PropertyOffset_55;

		// Token: 0x04010969 RID: 67945
		internal static int __PropertyOffset_56;

		// Token: 0x0401096A RID: 67946
		internal static int __PropertyOffset_57;

		// Token: 0x0401096B RID: 67947
		internal static int __PropertyOffset_58;

		// Token: 0x0401096C RID: 67948
		internal static int __PropertyOffset_59;

		// Token: 0x0401096D RID: 67949
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Hidden_Actors;

		// Token: 0x0401096E RID: 67950
		internal static int __PropertyOffset_60;

		// Token: 0x0401096F RID: 67951
		internal static int __PropertyOffset_61;

		// Token: 0x04010970 RID: 67952
		private static IntPtr __SaveCaptureDepthMap_NativeFunctionPtr;

		// Token: 0x04010971 RID: 67953
		private static IntPtr __ReStartSim_NativeFunctionPtr;

		// Token: 0x04010972 RID: 67954
		private static IntPtr __HideRenderWaterMesh_NativeFunctionPtr;

		// Token: 0x04010973 RID: 67955
		private static IntPtr __CalcHeightmap_NativeFunctionPtr;

		// Token: 0x04010974 RID: 67956
		private static IntPtr __SetMPCParameters_NativeFunctionPtr;

		// Token: 0x04010975 RID: 67957
		private static IntPtr __StopSim_NativeFunctionPtr;

		// Token: 0x04010976 RID: 67958
		private static IntPtr __StartSim_NativeFunctionPtr;

		// Token: 0x04010977 RID: 67959
		private static IntPtr __ClearWater_NativeFunctionPtr;

		// Token: 0x04010978 RID: 67960
		private static IntPtr __SetMaterialParameter_NativeFunctionPtr;

		// Token: 0x04010979 RID: 67961
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401097A RID: 67962
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401097B RID: 67963
		private static IntPtr __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401097C RID: 67964
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401097D RID: 67965
		private static IntPtr __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401097E RID: 67966
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401097F RID: 67967
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010980 RID: 67968
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010981 RID: 67969
		private static IntPtr __ReceiveParticleData_NativeFunctionPtr;

		// Token: 0x04010982 RID: 67970
		private static IntPtr __ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_NativeFunctionPtr;

		// Token: 0x02009A62 RID: 39522
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __HideRenderWaterMesh_FunctionParams
		{
			// Token: 0x04032178 RID: 205176
			[FieldOffset(0)]
			public bool HideRenderWater;
		}

		// Token: 0x02009A63 RID: 39523
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __SetMaterialParameter_FunctionParams
		{
			// Token: 0x04032179 RID: 205177
			[FieldOffset(0)]
			public IntPtr Material;

			// Token: 0x0403217A RID: 205178
			[FieldOffset(8)]
			public IntPtr VelocityHeightFoam;

			// Token: 0x0403217B RID: 205179
			[FieldOffset(16)]
			public IntPtr MaterialInstance;
		}

		// Token: 0x02009A64 RID: 39524
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403217C RID: 205180
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403217D RID: 205181
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403217E RID: 205182
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403217F RID: 205183
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032180 RID: 205184
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032181 RID: 205185
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A65 RID: 39525
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_Sim_Volume_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032182 RID: 205186
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032183 RID: 205187
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032184 RID: 205188
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032185 RID: 205189
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A66 RID: 39526
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_2_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032186 RID: 205190
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032187 RID: 205191
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032188 RID: 205192
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032189 RID: 205193
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403218A RID: 205194
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403218B RID: 205195
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A67 RID: 39527
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_WaterSimulation_WaterInteraction_Volume_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403218C RID: 205196
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403218D RID: 205197
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403218E RID: 205198
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403218F RID: 205199
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A68 RID: 39528
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032190 RID: 205200
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A69 RID: 39529
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ReceiveParticleData_FunctionParams
		{
			// Token: 0x04032191 RID: 205201
			[FieldOffset(0)]
			public byte Data;

			// Token: 0x04032192 RID: 205202
			[FieldOffset(16)]
			public IntPtr NiagaraSystem;
		}

		// Token: 0x02009A6A RID: 39530
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 584)]
		protected ref struct __ExecuteUbergraph_BP_WaterSimulation_3_5_CaptureDepth_FunctionParams
		{
			// Token: 0x04032193 RID: 205203
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
