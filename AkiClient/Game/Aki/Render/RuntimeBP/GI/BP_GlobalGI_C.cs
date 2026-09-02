using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud;
using AkiClient.Game.Aki.Render.RuntimeBP.UI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C94 RID: 15508
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI.BP_GlobalGI_C")]
	[UnrealStructLayout(17008, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 17002)]
	public class BP_GlobalGI_C : AKuroGlobalGI, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024363 RID: 148323 RVA: 0x00997C28 File Offset: 0x00995E28
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GlobalGI_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI.BP_GlobalGI_C");
			}
			return BP_GlobalGI_C._ClassPtr;
		}

		// Token: 0x06024364 RID: 148324 RVA: 0x00997C4C File Offset: 0x00995E4C
		public BP_GlobalGI_C() : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGI_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024365 RID: 148325 RVA: 0x00997C74 File Offset: 0x00995E74
		[NullableContext(1)]
		public BP_GlobalGI_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGI_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004AAC RID: 19116
		// (get) Token: 0x06024366 RID: 148326 RVA: 0x00997CA8 File Offset: 0x00995EA8
		// (set) Token: 0x06024367 RID: 148327 RVA: 0x00997CE1 File Offset: 0x00995EE1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004AAD RID: 19117
		// (get) Token: 0x06024368 RID: 148328 RVA: 0x00997D02 File Offset: 0x00995F02
		// (set) Token: 0x06024369 RID: 148329 RVA: 0x00997D16 File Offset: 0x00995F16
		public unsafe UChildActorComponent KuroDynamicSky
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004AAE RID: 19118
		// (get) Token: 0x0602436A RID: 148330 RVA: 0x00997D2B File Offset: 0x00995F2B
		// (set) Token: 0x0602436B RID: 148331 RVA: 0x00997D3F File Offset: 0x00995F3F
		public unsafe UKuroPostProcessComponent ToonBaseFFTPost
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004AAF RID: 19119
		// (get) Token: 0x0602436C RID: 148332 RVA: 0x00997D54 File Offset: 0x00995F54
		// (set) Token: 0x0602436D RID: 148333 RVA: 0x00997D68 File Offset: 0x00995F68
		public unsafe USkyAtmosphereComponent SkyAtmosphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyAtmosphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004AB0 RID: 19120
		// (get) Token: 0x0602436E RID: 148334 RVA: 0x00997D7D File Offset: 0x00995F7D
		// (set) Token: 0x0602436F RID: 148335 RVA: 0x00997D91 File Offset: 0x00995F91
		public unsafe UPostProcessComponent GodRayPostVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004AB1 RID: 19121
		// (get) Token: 0x06024370 RID: 148336 RVA: 0x00997DA6 File Offset: 0x00995FA6
		// (set) Token: 0x06024371 RID: 148337 RVA: 0x00997DBA File Offset: 0x00995FBA
		public unsafe USceneRayTracingGICaptureComponentCube SceneRayTracingGICaptureComponentCube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneRayTracingGICaptureComponentCube>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004AB2 RID: 19122
		// (get) Token: 0x06024372 RID: 148338 RVA: 0x00997DCF File Offset: 0x00995FCF
		// (set) Token: 0x06024373 RID: 148339 RVA: 0x00997DE3 File Offset: 0x00995FE3
		public unsafe UChildActorComponent KuroVolumeCloudGlobal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004AB3 RID: 19123
		// (get) Token: 0x06024374 RID: 148340 RVA: 0x00997DF8 File Offset: 0x00995FF8
		// (set) Token: 0x06024375 RID: 148341 RVA: 0x00997E0C File Offset: 0x0099600C
		public unsafe UChildActorComponent RainOverrider
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004AB4 RID: 19124
		// (get) Token: 0x06024376 RID: 148342 RVA: 0x00997E21 File Offset: 0x00996021
		// (set) Token: 0x06024377 RID: 148343 RVA: 0x00997E35 File Offset: 0x00996035
		public unsafe UKuroGlobalHeightMapComponent KuroGlobalHeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGlobalHeightMapComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004AB5 RID: 19125
		// (get) Token: 0x06024378 RID: 148344 RVA: 0x00997E4A File Offset: 0x0099604A
		// (set) Token: 0x06024379 RID: 148345 RVA: 0x00997E5E File Offset: 0x0099605E
		public unsafe UStaticMeshComponent CloudOcean
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004AB6 RID: 19126
		// (get) Token: 0x0602437A RID: 148346 RVA: 0x00997E73 File Offset: 0x00996073
		// (set) Token: 0x0602437B RID: 148347 RVA: 0x00997E87 File Offset: 0x00996087
		public unsafe UKuroGlobalColorMapComponent KuroGlobalColorMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGlobalColorMapComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004AB7 RID: 19127
		// (get) Token: 0x0602437C RID: 148348 RVA: 0x00997E9C File Offset: 0x0099609C
		// (set) Token: 0x0602437D RID: 148349 RVA: 0x00997EB0 File Offset: 0x009960B0
		public unsafe UStaticMeshComponent SM_MilkyWay
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004AB8 RID: 19128
		// (get) Token: 0x0602437E RID: 148350 RVA: 0x00997EC5 File Offset: 0x009960C5
		// (set) Token: 0x0602437F RID: 148351 RVA: 0x00997ED9 File Offset: 0x009960D9
		public unsafe BP_UiSceneRenderingComponent_C BP_UiSceneRenderingComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_UiSceneRenderingComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004AB9 RID: 19129
		// (get) Token: 0x06024380 RID: 148352 RVA: 0x00997EEE File Offset: 0x009960EE
		// (set) Token: 0x06024381 RID: 148353 RVA: 0x00997F02 File Offset: 0x00996102
		public unsafe UKuroPostProcessComponent GlobalUiScenePostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004ABA RID: 19130
		// (get) Token: 0x06024382 RID: 148354 RVA: 0x00997F17 File Offset: 0x00996117
		// (set) Token: 0x06024383 RID: 148355 RVA: 0x00997F2B File Offset: 0x0099612B
		public unsafe UChildActorComponent ImposterManager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004ABB RID: 19131
		// (get) Token: 0x06024384 RID: 148356 RVA: 0x00997F40 File Offset: 0x00996140
		// (set) Token: 0x06024385 RID: 148357 RVA: 0x00997F54 File Offset: 0x00996154
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17004ABC RID: 19132
		// (get) Token: 0x06024386 RID: 148358 RVA: 0x00997F69 File Offset: 0x00996169
		// (set) Token: 0x06024387 RID: 148359 RVA: 0x00997F7D File Offset: 0x0099617D
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004ABD RID: 19133
		// (get) Token: 0x06024388 RID: 148360 RVA: 0x00997F92 File Offset: 0x00996192
		// (set) Token: 0x06024389 RID: 148361 RVA: 0x00997FA6 File Offset: 0x009961A6
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004ABE RID: 19134
		// (get) Token: 0x0602438A RID: 148362 RVA: 0x00997FBB File Offset: 0x009961BB
		// (set) Token: 0x0602438B RID: 148363 RVA: 0x00997FCF File Offset: 0x009961CF
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17004ABF RID: 19135
		// (get) Token: 0x0602438C RID: 148364 RVA: 0x00997FE4 File Offset: 0x009961E4
		// (set) Token: 0x0602438D RID: 148365 RVA: 0x00997FF8 File Offset: 0x009961F8
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17004AC0 RID: 19136
		// (get) Token: 0x0602438E RID: 148366 RVA: 0x0099800D File Offset: 0x0099620D
		// (set) Token: 0x0602438F RID: 148367 RVA: 0x00998021 File Offset: 0x00996221
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004AC1 RID: 19137
		// (get) Token: 0x06024390 RID: 148368 RVA: 0x00998036 File Offset: 0x00996236
		// (set) Token: 0x06024391 RID: 148369 RVA: 0x0099804A File Offset: 0x0099624A
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004AC2 RID: 19138
		// (get) Token: 0x06024392 RID: 148370 RVA: 0x0099805F File Offset: 0x0099625F
		// (set) Token: 0x06024393 RID: 148371 RVA: 0x00998073 File Offset: 0x00996273
		public unsafe UKuroPostProcessComponent LUTPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004AC3 RID: 19139
		// (get) Token: 0x06024394 RID: 148372 RVA: 0x00998088 File Offset: 0x00996288
		// (set) Token: 0x06024395 RID: 148373 RVA: 0x0099809C File Offset: 0x0099629C
		public unsafe UStaticMeshComponent SM_Stars
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004AC4 RID: 19140
		// (get) Token: 0x06024396 RID: 148374 RVA: 0x009980B1 File Offset: 0x009962B1
		// (set) Token: 0x06024397 RID: 148375 RVA: 0x009980C5 File Offset: 0x009962C5
		public unsafe UStaticMeshComponent Skybox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17004AC5 RID: 19141
		// (get) Token: 0x06024398 RID: 148376 RVA: 0x009980DA File Offset: 0x009962DA
		// (set) Token: 0x06024399 RID: 148377 RVA: 0x009980EE File Offset: 0x009962EE
		public unsafe UPostProcessComponent GlobalPostProcessVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004AC6 RID: 19142
		// (get) Token: 0x0602439A RID: 148378 RVA: 0x00998103 File Offset: 0x00996303
		// (set) Token: 0x0602439B RID: 148379 RVA: 0x00998117 File Offset: 0x00996317
		public unsafe UDirectionalLightComponent SceneLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17004AC7 RID: 19143
		// (get) Token: 0x0602439C RID: 148380 RVA: 0x0099812C File Offset: 0x0099632C
		// (set) Token: 0x0602439D RID: 148381 RVA: 0x00998140 File Offset: 0x00996340
		public unsafe UDirectionalLightComponent AtmoMoonLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004AC8 RID: 19144
		// (get) Token: 0x0602439E RID: 148382 RVA: 0x00998155 File Offset: 0x00996355
		// (set) Token: 0x0602439F RID: 148383 RVA: 0x00998169 File Offset: 0x00996369
		public unsafe UDirectionalLightComponent AtmoSunLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004AC9 RID: 19145
		// (get) Token: 0x060243A0 RID: 148384 RVA: 0x0099817E File Offset: 0x0099637E
		// (set) Token: 0x060243A1 RID: 148385 RVA: 0x00998192 File Offset: 0x00996392
		public unsafe USkyLightComponent SkyLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17004ACA RID: 19146
		// (get) Token: 0x060243A2 RID: 148386 RVA: 0x009981A7 File Offset: 0x009963A7
		// (set) Token: 0x060243A3 RID: 148387 RVA: 0x009981BB File Offset: 0x009963BB
		public unsafe UExponentialHeightFogComponent HeightFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UExponentialHeightFogComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x17004ACB RID: 19147
		// (get) Token: 0x060243A4 RID: 148388 RVA: 0x009981D0 File Offset: 0x009963D0
		// (set) Token: 0x060243A5 RID: 148389 RVA: 0x009981E4 File Offset: 0x009963E4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17004ACC RID: 19148
		// (get) Token: 0x060243A6 RID: 148390 RVA: 0x009981F9 File Offset: 0x009963F9
		// (set) Token: 0x060243A7 RID: 148391 RVA: 0x00998209 File Offset: 0x00996409
		public unsafe float CharacterLightHorizontal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004ACD RID: 19149
		// (get) Token: 0x060243A8 RID: 148392 RVA: 0x0099821A File Offset: 0x0099641A
		// (set) Token: 0x060243A9 RID: 148393 RVA: 0x0099822A File Offset: 0x0099642A
		public unsafe float CurrTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004ACE RID: 19150
		// (get) Token: 0x060243AA RID: 148394 RVA: 0x0099823B File Offset: 0x0099643B
		// (set) Token: 0x060243AB RID: 148395 RVA: 0x0099824B File Offset: 0x0099644B
		public unsafe bool EnableTODCycle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004ACF RID: 19151
		// (get) Token: 0x060243AC RID: 148396 RVA: 0x0099825C File Offset: 0x0099645C
		// (set) Token: 0x060243AD RID: 148397 RVA: 0x0099826C File Offset: 0x0099646C
		public unsafe bool PauseTOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AD0 RID: 19152
		// (get) Token: 0x060243AE RID: 148398 RVA: 0x0099827D File Offset: 0x0099647D
		// (set) Token: 0x060243AF RID: 148399 RVA: 0x0099828D File Offset: 0x0099648D
		public unsafe bool 编辑器下更新
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AD1 RID: 19153
		// (get) Token: 0x060243B0 RID: 148400 RVA: 0x0099829E File Offset: 0x0099649E
		// (set) Token: 0x060243B1 RID: 148401 RVA: 0x009982AE File Offset: 0x009964AE
		public unsafe float TODCycleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004AD2 RID: 19154
		// (get) Token: 0x060243B2 RID: 148402 RVA: 0x009982BF File Offset: 0x009964BF
		// (set) Token: 0x060243B3 RID: 148403 RVA: 0x009982D3 File Offset: 0x009964D3
		public unsafe FRotator SenenDirLightRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004AD3 RID: 19155
		// (get) Token: 0x060243B4 RID: 148404 RVA: 0x009982E8 File Offset: 0x009964E8
		// (set) Token: 0x060243B5 RID: 148405 RVA: 0x009982F8 File Offset: 0x009964F8
		public unsafe float MainLightAngleLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004AD4 RID: 19156
		// (get) Token: 0x060243B6 RID: 148406 RVA: 0x00998309 File Offset: 0x00996509
		// (set) Token: 0x060243B7 RID: 148407 RVA: 0x00998319 File Offset: 0x00996519
		public unsafe bool IsGIEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AD5 RID: 19157
		// (get) Token: 0x060243B8 RID: 148408 RVA: 0x0099832A File Offset: 0x0099652A
		// (set) Token: 0x060243B9 RID: 148409 RVA: 0x0099833A File Offset: 0x0099653A
		public unsafe bool 使用随机的昼夜循环天气组
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AD6 RID: 19158
		// (get) Token: 0x060243BA RID: 148410 RVA: 0x0099834B File Offset: 0x0099654B
		// (set) Token: 0x060243BB RID: 148411 RVA: 0x0099835B File Offset: 0x0099655B
		public unsafe int 当前的天气组索引值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004AD7 RID: 19159
		// (get) Token: 0x060243BC RID: 148412 RVA: 0x0099836C File Offset: 0x0099656C
		// (set) Token: 0x060243BD RID: 148413 RVA: 0x00998380 File Offset: 0x00996580
		public unsafe FLinearColor 太阳颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17004AD8 RID: 19160
		// (get) Token: 0x060243BE RID: 148414 RVA: 0x00998398 File Offset: 0x00996598
		// (set) Token: 0x060243BF RID: 148415 RVA: 0x009983D1 File Offset: 0x009965D1
		[Nullable(1)]
		public TArray<FVector2D> SunLightExistTime
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._SunLightExistTime) == null)
				{
					result = (this._SunLightExistTime = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_44, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SunLightExistTime.CopyAssign(value);
			}
		}

		// Token: 0x17004AD9 RID: 19161
		// (get) Token: 0x060243C0 RID: 148416 RVA: 0x009983E0 File Offset: 0x009965E0
		// (set) Token: 0x060243C1 RID: 148417 RVA: 0x00998419 File Offset: 0x00996619
		[Nullable(1)]
		public TArray<FVector2D> MoonLightExistTime
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._MoonLightExistTime) == null)
				{
					result = (this._MoonLightExistTime = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_45, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MoonLightExistTime.CopyAssign(value);
			}
		}

		// Token: 0x17004ADA RID: 19162
		// (get) Token: 0x060243C2 RID: 148418 RVA: 0x00998427 File Offset: 0x00996627
		// (set) Token: 0x060243C3 RID: 148419 RVA: 0x00998437 File Offset: 0x00996637
		public unsafe bool 运行时自动开始循环
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004ADB RID: 19163
		// (get) Token: 0x060243C4 RID: 148420 RVA: 0x00998448 File Offset: 0x00996648
		// (set) Token: 0x060243C5 RID: 148421 RVA: 0x00998458 File Offset: 0x00996658
		public unsafe bool UISceneRendering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004ADC RID: 19164
		// (get) Token: 0x060243C6 RID: 148422 RVA: 0x00998469 File Offset: 0x00996669
		// (set) Token: 0x060243C7 RID: 148423 RVA: 0x00998479 File Offset: 0x00996679
		public unsafe bool IsRootGI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004ADD RID: 19165
		// (get) Token: 0x060243C8 RID: 148424 RVA: 0x0099848A File Offset: 0x0099668A
		// (set) Token: 0x060243C9 RID: 148425 RVA: 0x0099849A File Offset: 0x0099669A
		public unsafe bool DEBUG_使用角色预览方向光
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004ADE RID: 19166
		// (get) Token: 0x060243CA RID: 148426 RVA: 0x009984AB File Offset: 0x009966AB
		// (set) Token: 0x060243CB RID: 148427 RVA: 0x009984BB File Offset: 0x009966BB
		public unsafe float DEBUG_角色预览方向光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17004ADF RID: 19167
		// (get) Token: 0x060243CC RID: 148428 RVA: 0x009984CC File Offset: 0x009966CC
		// (set) Token: 0x060243CD RID: 148429 RVA: 0x009984DC File Offset: 0x009966DC
		public unsafe int TotalDaysElapsed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17004AE0 RID: 19168
		// (get) Token: 0x060243CE RID: 148430 RVA: 0x009984ED File Offset: 0x009966ED
		// (set) Token: 0x060243CF RID: 148431 RVA: 0x009984FD File Offset: 0x009966FD
		public unsafe float MoonFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17004AE1 RID: 19169
		// (get) Token: 0x060243D0 RID: 148432 RVA: 0x0099850E File Offset: 0x0099670E
		// (set) Token: 0x060243D1 RID: 148433 RVA: 0x00998522 File Offset: 0x00996722
		public unsafe FVector2D MoonVisibleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17004AE2 RID: 19170
		// (get) Token: 0x060243D2 RID: 148434 RVA: 0x00998537 File Offset: 0x00996737
		// (set) Token: 0x060243D3 RID: 148435 RVA: 0x00998547 File Offset: 0x00996747
		public unsafe bool 编辑器下关闭LensFlare
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AE3 RID: 19171
		// (get) Token: 0x060243D4 RID: 148436 RVA: 0x00998558 File Offset: 0x00996758
		// (set) Token: 0x060243D5 RID: 148437 RVA: 0x00998568 File Offset: 0x00996768
		public unsafe bool 关闭雾效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AE4 RID: 19172
		// (get) Token: 0x060243D6 RID: 148438 RVA: 0x00998579 File Offset: 0x00996779
		// (set) Token: 0x060243D7 RID: 148439 RVA: 0x00998589 File Offset: 0x00996789
		public unsafe bool RuntimeTimeEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AE5 RID: 19173
		// (get) Token: 0x060243D8 RID: 148440 RVA: 0x0099859A File Offset: 0x0099679A
		// (set) Token: 0x060243D9 RID: 148441 RVA: 0x009985AA File Offset: 0x009967AA
		public unsafe float MainLightTickSecond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17004AE6 RID: 19174
		// (get) Token: 0x060243DA RID: 148442 RVA: 0x009985BB File Offset: 0x009967BB
		// (set) Token: 0x060243DB RID: 148443 RVA: 0x009985CB File Offset: 0x009967CB
		public unsafe float MainLightTickCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17004AE7 RID: 19175
		// (get) Token: 0x060243DC RID: 148444 RVA: 0x009985DC File Offset: 0x009967DC
		// (set) Token: 0x060243DD RID: 148445 RVA: 0x009985EC File Offset: 0x009967EC
		public unsafe bool ForceUpdateMainLightDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AE8 RID: 19176
		// (get) Token: 0x060243DE RID: 148446 RVA: 0x009985FD File Offset: 0x009967FD
		// (set) Token: 0x060243DF RID: 148447 RVA: 0x0099860D File Offset: 0x0099680D
		public unsafe float WindDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17004AE9 RID: 19177
		// (get) Token: 0x060243E0 RID: 148448 RVA: 0x0099861E File Offset: 0x0099681E
		// (set) Token: 0x060243E1 RID: 148449 RVA: 0x0099862E File Offset: 0x0099682E
		public unsafe bool 使用临时雾效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_61) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_61) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AEA RID: 19178
		// (get) Token: 0x060243E2 RID: 148450 RVA: 0x0099863F File Offset: 0x0099683F
		// (set) Token: 0x060243E3 RID: 148451 RVA: 0x00998653 File Offset: 0x00996853
		public unsafe UMaterialInstance TempFogMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_62);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_62, value);
			}
		}

		// Token: 0x17004AEB RID: 19179
		// (get) Token: 0x060243E4 RID: 148452 RVA: 0x00998668 File Offset: 0x00996868
		// (set) Token: 0x060243E5 RID: 148453 RVA: 0x0099867C File Offset: 0x0099687C
		public unsafe UMaterialInstanceDynamic TempFogDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17004AEC RID: 19180
		// (get) Token: 0x060243E6 RID: 148454 RVA: 0x00998691 File Offset: 0x00996891
		// (set) Token: 0x060243E7 RID: 148455 RVA: 0x009986A5 File Offset: 0x009968A5
		public unsafe UMaterialInstance SkyboxMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17004AED RID: 19181
		// (get) Token: 0x060243E8 RID: 148456 RVA: 0x009986BA File Offset: 0x009968BA
		// (set) Token: 0x060243E9 RID: 148457 RVA: 0x009986CE File Offset: 0x009968CE
		public unsafe FLinearColor SunDiscColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17004AEE RID: 19182
		// (get) Token: 0x060243EA RID: 148458 RVA: 0x009986E3 File Offset: 0x009968E3
		// (set) Token: 0x060243EB RID: 148459 RVA: 0x009986F7 File Offset: 0x009968F7
		public unsafe FLinearColor SunScatterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17004AEF RID: 19183
		// (get) Token: 0x060243EC RID: 148460 RVA: 0x0099870C File Offset: 0x0099690C
		// (set) Token: 0x060243ED RID: 148461 RVA: 0x0099871C File Offset: 0x0099691C
		public unsafe float SunSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17004AF0 RID: 19184
		// (get) Token: 0x060243EE RID: 148462 RVA: 0x0099872D File Offset: 0x0099692D
		// (set) Token: 0x060243EF RID: 148463 RVA: 0x00998741 File Offset: 0x00996941
		public unsafe FLinearColor MoonDiscColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17004AF1 RID: 19185
		// (get) Token: 0x060243F0 RID: 148464 RVA: 0x00998756 File Offset: 0x00996956
		// (set) Token: 0x060243F1 RID: 148465 RVA: 0x0099876A File Offset: 0x0099696A
		public unsafe FLinearColor MoonScatterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17004AF2 RID: 19186
		// (get) Token: 0x060243F2 RID: 148466 RVA: 0x0099877F File Offset: 0x0099697F
		// (set) Token: 0x060243F3 RID: 148467 RVA: 0x0099878F File Offset: 0x0099698F
		public unsafe float MoonSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17004AF3 RID: 19187
		// (get) Token: 0x060243F4 RID: 148468 RVA: 0x009987A0 File Offset: 0x009969A0
		// (set) Token: 0x060243F5 RID: 148469 RVA: 0x009987B4 File Offset: 0x009969B4
		public unsafe FLinearColor HorizonColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17004AF4 RID: 19188
		// (get) Token: 0x060243F6 RID: 148470 RVA: 0x009987C9 File Offset: 0x009969C9
		// (set) Token: 0x060243F7 RID: 148471 RVA: 0x009987D9 File Offset: 0x009969D9
		public unsafe float HorizonFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x17004AF5 RID: 19189
		// (get) Token: 0x060243F8 RID: 148472 RVA: 0x009987EA File Offset: 0x009969EA
		// (set) Token: 0x060243F9 RID: 148473 RVA: 0x009987FE File Offset: 0x009969FE
		public unsafe FLinearColor ZenithColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x17004AF6 RID: 19190
		// (get) Token: 0x060243FA RID: 148474 RVA: 0x00998813 File Offset: 0x00996A13
		// (set) Token: 0x060243FB RID: 148475 RVA: 0x00998823 File Offset: 0x00996A23
		public unsafe float ExtremWeatherWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x17004AF7 RID: 19191
		// (get) Token: 0x060243FC RID: 148476 RVA: 0x00998834 File Offset: 0x00996A34
		// (set) Token: 0x060243FD RID: 148477 RVA: 0x00998848 File Offset: 0x00996A48
		public unsafe FLinearColor ST_TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17004AF8 RID: 19192
		// (get) Token: 0x060243FE RID: 148478 RVA: 0x0099885D File Offset: 0x00996A5D
		// (set) Token: 0x060243FF RID: 148479 RVA: 0x00998871 File Offset: 0x00996A71
		public unsafe FLinearColor ST_DomeColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17004AF9 RID: 19193
		// (get) Token: 0x06024400 RID: 148480 RVA: 0x00998886 File Offset: 0x00996A86
		// (set) Token: 0x06024401 RID: 148481 RVA: 0x00998896 File Offset: 0x00996A96
		public unsafe float ST_TopWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17004AFA RID: 19194
		// (get) Token: 0x06024402 RID: 148482 RVA: 0x009988A7 File Offset: 0x00996AA7
		// (set) Token: 0x06024403 RID: 148483 RVA: 0x009988BB File Offset: 0x00996ABB
		public unsafe UCurveFloat CharMainLightCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_78);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_78, value);
			}
		}

		// Token: 0x17004AFB RID: 19195
		// (get) Token: 0x06024404 RID: 148484 RVA: 0x009988D0 File Offset: 0x00996AD0
		// (set) Token: 0x06024405 RID: 148485 RVA: 0x009988E4 File Offset: 0x00996AE4
		public unsafe UCurveFloat CharSkyLightCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_79);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_79, value);
			}
		}

		// Token: 0x17004AFC RID: 19196
		// (get) Token: 0x06024406 RID: 148486 RVA: 0x009988F9 File Offset: 0x00996AF9
		// (set) Token: 0x06024407 RID: 148487 RVA: 0x00998909 File Offset: 0x00996B09
		public unsafe bool UseCharCustomLighting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_80) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_80) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004AFD RID: 19197
		// (get) Token: 0x06024408 RID: 148488 RVA: 0x0099891A File Offset: 0x00996B1A
		// (set) Token: 0x06024409 RID: 148489 RVA: 0x0099892E File Offset: 0x00996B2E
		public unsafe FLinearColor CharAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_81);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x17004AFE RID: 19198
		// (get) Token: 0x0602440A RID: 148490 RVA: 0x00998943 File Offset: 0x00996B43
		// (set) Token: 0x0602440B RID: 148491 RVA: 0x00998957 File Offset: 0x00996B57
		public unsafe FLinearColor CharSkinAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_82);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x17004AFF RID: 19199
		// (get) Token: 0x0602440C RID: 148492 RVA: 0x0099896C File Offset: 0x00996B6C
		// (set) Token: 0x0602440D RID: 148493 RVA: 0x00998980 File Offset: 0x00996B80
		public unsafe UCurveFloat CharShadowCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_83);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17004B00 RID: 19200
		// (get) Token: 0x0602440E RID: 148494 RVA: 0x00998995 File Offset: 0x00996B95
		// (set) Token: 0x0602440F RID: 148495 RVA: 0x009989A9 File Offset: 0x00996BA9
		public unsafe UMaterialInstance LightFunctionMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_84);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_84, value);
			}
		}

		// Token: 0x17004B01 RID: 19201
		// (get) Token: 0x06024410 RID: 148496 RVA: 0x009989BE File Offset: 0x00996BBE
		// (set) Token: 0x06024411 RID: 148497 RVA: 0x009989CE File Offset: 0x00996BCE
		public unsafe float LightFunctionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17004B02 RID: 19202
		// (get) Token: 0x06024412 RID: 148498 RVA: 0x009989DF File Offset: 0x00996BDF
		// (set) Token: 0x06024413 RID: 148499 RVA: 0x009989F3 File Offset: 0x00996BF3
		public unsafe UMaterialInstanceDynamic LightFunctionDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_86);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_86, value);
			}
		}

		// Token: 0x17004B03 RID: 19203
		// (get) Token: 0x06024414 RID: 148500 RVA: 0x00998A08 File Offset: 0x00996C08
		// (set) Token: 0x06024415 RID: 148501 RVA: 0x00998A18 File Offset: 0x00996C18
		public unsafe bool DEBUG开启无音区特殊地表
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_87) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_87) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B04 RID: 19204
		// (get) Token: 0x06024416 RID: 148502 RVA: 0x00998A29 File Offset: 0x00996C29
		// (set) Token: 0x06024417 RID: 148503 RVA: 0x00998A3D File Offset: 0x00996C3D
		public unsafe UMaterialInstance LensFlareMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_88);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_88, value);
			}
		}

		// Token: 0x17004B05 RID: 19205
		// (get) Token: 0x06024418 RID: 148504 RVA: 0x00998A52 File Offset: 0x00996C52
		// (set) Token: 0x06024419 RID: 148505 RVA: 0x00998A66 File Offset: 0x00996C66
		public unsafe UMaterialInstanceDynamic LensFlareDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_89);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_89, value);
			}
		}

		// Token: 0x17004B06 RID: 19206
		// (get) Token: 0x0602441A RID: 148506 RVA: 0x00998A7B File Offset: 0x00996C7B
		// (set) Token: 0x0602441B RID: 148507 RVA: 0x00998A8F File Offset: 0x00996C8F
		public unsafe UMaterialInstance MobileLensFlareMI_Ghost
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_90);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_90, value);
			}
		}

		// Token: 0x17004B07 RID: 19207
		// (get) Token: 0x0602441C RID: 148508 RVA: 0x00998AA4 File Offset: 0x00996CA4
		// (set) Token: 0x0602441D RID: 148509 RVA: 0x00998AB8 File Offset: 0x00996CB8
		public unsafe FLinearColor Nadir_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_91);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_91) = value;
			}
		}

		// Token: 0x17004B08 RID: 19208
		// (get) Token: 0x0602441E RID: 148510 RVA: 0x00998ACD File Offset: 0x00996CCD
		// (set) Token: 0x0602441F RID: 148511 RVA: 0x00998ADD File Offset: 0x00996CDD
		public unsafe float Nadir_Falloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x17004B09 RID: 19209
		// (get) Token: 0x06024420 RID: 148512 RVA: 0x00998AEE File Offset: 0x00996CEE
		// (set) Token: 0x06024421 RID: 148513 RVA: 0x00998AFE File Offset: 0x00996CFE
		public unsafe float Sun_Scatter_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x17004B0A RID: 19210
		// (get) Token: 0x06024422 RID: 148514 RVA: 0x00998B0F File Offset: 0x00996D0F
		// (set) Token: 0x06024423 RID: 148515 RVA: 0x00998B1F File Offset: 0x00996D1F
		public unsafe float Moon_Scatter_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17004B0B RID: 19211
		// (get) Token: 0x06024424 RID: 148516 RVA: 0x00998B30 File Offset: 0x00996D30
		// (set) Token: 0x06024425 RID: 148517 RVA: 0x00998B44 File Offset: 0x00996D44
		public unsafe UMaterialInstance StarsMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_95);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_95, value);
			}
		}

		// Token: 0x17004B0C RID: 19212
		// (get) Token: 0x06024426 RID: 148518 RVA: 0x00998B59 File Offset: 0x00996D59
		// (set) Token: 0x06024427 RID: 148519 RVA: 0x00998B69 File Offset: 0x00996D69
		public unsafe float MainDirectionLightUpdateThreshold_Mobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17004B0D RID: 19213
		// (get) Token: 0x06024428 RID: 148520 RVA: 0x00998B7A File Offset: 0x00996D7A
		// (set) Token: 0x06024429 RID: 148521 RVA: 0x00998B8A File Offset: 0x00996D8A
		public unsafe float MainDirectionLightUpdateThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x17004B0E RID: 19214
		// (get) Token: 0x0602442A RID: 148522 RVA: 0x00998B9B File Offset: 0x00996D9B
		// (set) Token: 0x0602442B RID: 148523 RVA: 0x00998BAF File Offset: 0x00996DAF
		public unsafe FVector GlobalWindDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_98);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_98) = value;
			}
		}

		// Token: 0x17004B0F RID: 19215
		// (get) Token: 0x0602442C RID: 148524 RVA: 0x00998BC4 File Offset: 0x00996DC4
		// (set) Token: 0x0602442D RID: 148525 RVA: 0x00998BD8 File Offset: 0x00996DD8
		public unsafe FVector GlobalWindRightDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_99);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_99) = value;
			}
		}

		// Token: 0x17004B10 RID: 19216
		// (get) Token: 0x0602442E RID: 148526 RVA: 0x00998BED File Offset: 0x00996DED
		// (set) Token: 0x0602442F RID: 148527 RVA: 0x00998BFD File Offset: 0x00996DFD
		public unsafe float DEBUG无音区特殊地表强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17004B11 RID: 19217
		// (get) Token: 0x06024430 RID: 148528 RVA: 0x00998C0E File Offset: 0x00996E0E
		// (set) Token: 0x06024431 RID: 148529 RVA: 0x00998C22 File Offset: 0x00996E22
		public unsafe BP_ControlTodTime_C TodTimeController
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_ControlTodTime_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_101);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_101, value);
			}
		}

		// Token: 0x17004B12 RID: 19218
		// (get) Token: 0x06024432 RID: 148530 RVA: 0x00998C37 File Offset: 0x00996E37
		// (set) Token: 0x06024433 RID: 148531 RVA: 0x00998C47 File Offset: 0x00996E47
		public unsafe float RealTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17004B13 RID: 19219
		// (get) Token: 0x06024434 RID: 148532 RVA: 0x00998C58 File Offset: 0x00996E58
		// (set) Token: 0x06024435 RID: 148533 RVA: 0x00998C6C File Offset: 0x00996E6C
		public unsafe BP_Clouds_C DynamicCloudsActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Clouds_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_103);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_103, value);
			}
		}

		// Token: 0x17004B14 RID: 19220
		// (get) Token: 0x06024436 RID: 148534 RVA: 0x00998C81 File Offset: 0x00996E81
		// (set) Token: 0x06024437 RID: 148535 RVA: 0x00998C95 File Offset: 0x00996E95
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroDynamicCloudType> LocalDynamicCloudsType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_104);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17004B15 RID: 19221
		// (get) Token: 0x06024438 RID: 148536 RVA: 0x00998CAA File Offset: 0x00996EAA
		// (set) Token: 0x06024439 RID: 148537 RVA: 0x00998CBA File Offset: 0x00996EBA
		public unsafe float RainDensityChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_105);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_105) = value;
			}
		}

		// Token: 0x17004B16 RID: 19222
		// (get) Token: 0x0602443A RID: 148538 RVA: 0x00998CCB File Offset: 0x00996ECB
		// (set) Token: 0x0602443B RID: 148539 RVA: 0x00998CDB File Offset: 0x00996EDB
		public unsafe float RainDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_106);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_106) = value;
			}
		}

		// Token: 0x17004B17 RID: 19223
		// (get) Token: 0x0602443C RID: 148540 RVA: 0x00998CEC File Offset: 0x00996EEC
		// (set) Token: 0x0602443D RID: 148541 RVA: 0x00998CFC File Offset: 0x00996EFC
		public unsafe float SnowDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_107);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_107) = value;
			}
		}

		// Token: 0x17004B18 RID: 19224
		// (get) Token: 0x0602443E RID: 148542 RVA: 0x00998D0D File Offset: 0x00996F0D
		// (set) Token: 0x0602443F RID: 148543 RVA: 0x00998D1D File Offset: 0x00996F1D
		public unsafe float RainGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_108);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_108) = value;
			}
		}

		// Token: 0x17004B19 RID: 19225
		// (get) Token: 0x06024440 RID: 148544 RVA: 0x00998D2E File Offset: 0x00996F2E
		// (set) Token: 0x06024441 RID: 148545 RVA: 0x00998D3E File Offset: 0x00996F3E
		public unsafe float RainGravityChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_109);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_109) = value;
			}
		}

		// Token: 0x17004B1A RID: 19226
		// (get) Token: 0x06024442 RID: 148546 RVA: 0x00998D4F File Offset: 0x00996F4F
		// (set) Token: 0x06024443 RID: 148547 RVA: 0x00998D5F File Offset: 0x00996F5F
		public unsafe float RainWindPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_110);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_110) = value;
			}
		}

		// Token: 0x17004B1B RID: 19227
		// (get) Token: 0x06024444 RID: 148548 RVA: 0x00998D70 File Offset: 0x00996F70
		// (set) Token: 0x06024445 RID: 148549 RVA: 0x00998D80 File Offset: 0x00996F80
		public unsafe float RainWindPowerChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_111);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_111) = value;
			}
		}

		// Token: 0x17004B1C RID: 19228
		// (get) Token: 0x06024446 RID: 148550 RVA: 0x00998D91 File Offset: 0x00996F91
		// (set) Token: 0x06024447 RID: 148551 RVA: 0x00998DA1 File Offset: 0x00996FA1
		public unsafe bool CanSpawnEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_112) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_112) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B1D RID: 19229
		// (get) Token: 0x06024448 RID: 148552 RVA: 0x00998DB2 File Offset: 0x00996FB2
		// (set) Token: 0x06024449 RID: 148553 RVA: 0x00998DC2 File Offset: 0x00996FC2
		public unsafe float FinalSnowDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_113);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_113) = value;
			}
		}

		// Token: 0x17004B1E RID: 19230
		// (get) Token: 0x0602444A RID: 148554 RVA: 0x00998DD3 File Offset: 0x00996FD3
		// (set) Token: 0x0602444B RID: 148555 RVA: 0x00998DE3 File Offset: 0x00996FE3
		public unsafe float FinalRainDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_114);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_114) = value;
			}
		}

		// Token: 0x17004B1F RID: 19231
		// (get) Token: 0x0602444C RID: 148556 RVA: 0x00998DF4 File Offset: 0x00996FF4
		// (set) Token: 0x0602444D RID: 148557 RVA: 0x00998E04 File Offset: 0x00997004
		public unsafe float FinalRainGravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_115);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_115) = value;
			}
		}

		// Token: 0x17004B20 RID: 19232
		// (get) Token: 0x0602444E RID: 148558 RVA: 0x00998E15 File Offset: 0x00997015
		// (set) Token: 0x0602444F RID: 148559 RVA: 0x00998E25 File Offset: 0x00997025
		public unsafe float DefaultSkyLightShadowSupplement
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x17004B21 RID: 19233
		// (get) Token: 0x06024450 RID: 148560 RVA: 0x00998E36 File Offset: 0x00997036
		// (set) Token: 0x06024451 RID: 148561 RVA: 0x00998E46 File Offset: 0x00997046
		public unsafe float DefaultSkyLightReflectionAddIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_117);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_117) = value;
			}
		}

		// Token: 0x17004B22 RID: 19234
		// (get) Token: 0x06024452 RID: 148562 RVA: 0x00998E57 File Offset: 0x00997057
		// (set) Token: 0x06024453 RID: 148563 RVA: 0x00998E6B File Offset: 0x0099706B
		public unsafe UMaterialInstance MobileLensFlareMI_Halo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_118);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_118, value);
			}
		}

		// Token: 0x17004B23 RID: 19235
		// (get) Token: 0x06024454 RID: 148564 RVA: 0x00998E80 File Offset: 0x00997080
		// (set) Token: 0x06024455 RID: 148565 RVA: 0x00998E94 File Offset: 0x00997094
		public unsafe UMaterialInstanceDynamic MobileLensFlareDMI_Ghost
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_119);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_119, value);
			}
		}

		// Token: 0x17004B24 RID: 19236
		// (get) Token: 0x06024456 RID: 148566 RVA: 0x00998EA9 File Offset: 0x009970A9
		// (set) Token: 0x06024457 RID: 148567 RVA: 0x00998EBD File Offset: 0x009970BD
		public unsafe UMaterialInstanceDynamic MobileLensFlareDMI_Halo
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_120);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_120, value);
			}
		}

		// Token: 0x17004B25 RID: 19237
		// (get) Token: 0x06024458 RID: 148568 RVA: 0x00998ED2 File Offset: 0x009970D2
		// (set) Token: 0x06024459 RID: 148569 RVA: 0x00998EE6 File Offset: 0x009970E6
		public unsafe UTexture2D HeightMapTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_121);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_121, value);
			}
		}

		// Token: 0x17004B26 RID: 19238
		// (get) Token: 0x0602445A RID: 148570 RVA: 0x00998EFB File Offset: 0x009970FB
		// (set) Token: 0x0602445B RID: 148571 RVA: 0x00998F0B File Offset: 0x0099710B
		public unsafe bool HeightMapUpdated
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_122) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_122) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B27 RID: 19239
		// (get) Token: 0x0602445C RID: 148572 RVA: 0x00998F1C File Offset: 0x0099711C
		// (set) Token: 0x0602445D RID: 148573 RVA: 0x00998F30 File Offset: 0x00997130
		public unsafe FVector SunLightDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_123);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_123) = value;
			}
		}

		// Token: 0x17004B28 RID: 19240
		// (get) Token: 0x0602445E RID: 148574 RVA: 0x00998F45 File Offset: 0x00997145
		// (set) Token: 0x0602445F RID: 148575 RVA: 0x00998F55 File Offset: 0x00997155
		public unsafe bool IsComponentsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_124) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_124) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B29 RID: 19241
		// (get) Token: 0x06024460 RID: 148576 RVA: 0x00998F66 File Offset: 0x00997166
		// (set) Token: 0x06024461 RID: 148577 RVA: 0x00998F7A File Offset: 0x0099717A
		public unsafe UTexture Last_LightFunction_Map
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_125);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_125, value);
			}
		}

		// Token: 0x17004B2A RID: 19242
		// (get) Token: 0x06024462 RID: 148578 RVA: 0x00998F8F File Offset: 0x0099718F
		// (set) Token: 0x06024463 RID: 148579 RVA: 0x00998FA3 File Offset: 0x009971A3
		public unsafe UTexture InitLightFunctionMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_126);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_126, value);
			}
		}

		// Token: 0x17004B2B RID: 19243
		// (get) Token: 0x06024464 RID: 148580 RVA: 0x00998FB8 File Offset: 0x009971B8
		// (set) Token: 0x06024465 RID: 148581 RVA: 0x00998FC8 File Offset: 0x009971C8
		public unsafe float TODLightLoadingWait
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_127);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_127) = value;
			}
		}

		// Token: 0x17004B2C RID: 19244
		// (get) Token: 0x06024466 RID: 148582 RVA: 0x00998FD9 File Offset: 0x009971D9
		// (set) Token: 0x06024467 RID: 148583 RVA: 0x00998FE9 File Offset: 0x009971E9
		public unsafe float DayLightLoadingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_128);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_128) = value;
			}
		}

		// Token: 0x17004B2D RID: 19245
		// (get) Token: 0x06024468 RID: 148584 RVA: 0x00998FFA File Offset: 0x009971FA
		// (set) Token: 0x06024469 RID: 148585 RVA: 0x0099900A File Offset: 0x0099720A
		public unsafe float NightLightLoadingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_129);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_129) = value;
			}
		}

		// Token: 0x17004B2E RID: 19246
		// (get) Token: 0x0602446A RID: 148586 RVA: 0x0099901B File Offset: 0x0099721B
		// (set) Token: 0x0602446B RID: 148587 RVA: 0x0099902B File Offset: 0x0099722B
		public unsafe int ComputeLightGridSkipFrames
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_130);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_130) = value;
			}
		}

		// Token: 0x17004B2F RID: 19247
		// (get) Token: 0x0602446C RID: 148588 RVA: 0x0099903C File Offset: 0x0099723C
		// (set) Token: 0x0602446D RID: 148589 RVA: 0x00999050 File Offset: 0x00997250
		public unsafe UMaterialInstance MilkyWayMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_131);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_131, value);
			}
		}

		// Token: 0x17004B30 RID: 19248
		// (get) Token: 0x0602446E RID: 148590 RVA: 0x00999065 File Offset: 0x00997265
		// (set) Token: 0x0602446F RID: 148591 RVA: 0x00999075 File Offset: 0x00997275
		public unsafe bool 使用主角位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_132) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_132) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B31 RID: 19249
		// (get) Token: 0x06024470 RID: 148592 RVA: 0x00999086 File Offset: 0x00997286
		// (set) Token: 0x06024471 RID: 148593 RVA: 0x00999096 File Offset: 0x00997296
		public unsafe float DEBUG_角色预览方向光垂直方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_133);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_133) = value;
			}
		}

		// Token: 0x17004B32 RID: 19250
		// (get) Token: 0x06024472 RID: 148594 RVA: 0x009990A8 File Offset: 0x009972A8
		// (set) Token: 0x06024473 RID: 148595 RVA: 0x009990E1 File Offset: 0x009972E1
		[Nullable(1)]
		public CallCloudChange CallCloudChange
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				CallCloudChange result;
				if ((result = this._CallCloudChange) == null)
				{
					result = (this._CallCloudChange = new CallCloudChange(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_134, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_134, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17004B33 RID: 19251
		// (get) Token: 0x06024474 RID: 148596 RVA: 0x00999104 File Offset: 0x00997304
		// (set) Token: 0x06024475 RID: 148597 RVA: 0x0099913D File Offset: 0x0099733D
		[Nullable(1)]
		public FKuroCurveFloat FogTImeControl
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FogTImeControl) == null)
				{
					result = (this._FogTImeControl = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_135, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_135, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004B34 RID: 19252
		// (get) Token: 0x06024476 RID: 148598 RVA: 0x0099915E File Offset: 0x0099735E
		// (set) Token: 0x06024477 RID: 148599 RVA: 0x0099916E File Offset: 0x0099736E
		public unsafe bool Is_Editor_Update
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_136) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_136) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B35 RID: 19253
		// (get) Token: 0x06024478 RID: 148600 RVA: 0x0099917F File Offset: 0x0099737F
		// (set) Token: 0x06024479 RID: 148601 RVA: 0x0099918F File Offset: 0x0099738F
		public unsafe bool EnableImposterUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_137) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_137) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B36 RID: 19254
		// (get) Token: 0x0602447A RID: 148602 RVA: 0x009991A0 File Offset: 0x009973A0
		// (set) Token: 0x0602447B RID: 148603 RVA: 0x009991B0 File Offset: 0x009973B0
		public unsafe float Clouds_Change_CD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_138);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_138) = value;
			}
		}

		// Token: 0x17004B37 RID: 19255
		// (get) Token: 0x0602447C RID: 148604 RVA: 0x009991C1 File Offset: 0x009973C1
		// (set) Token: 0x0602447D RID: 148605 RVA: 0x009991D1 File Offset: 0x009973D1
		public unsafe float Clouds_Change_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_139);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_139) = value;
			}
		}

		// Token: 0x17004B38 RID: 19256
		// (get) Token: 0x0602447E RID: 148606 RVA: 0x009991E2 File Offset: 0x009973E2
		// (set) Token: 0x0602447F RID: 148607 RVA: 0x009991F2 File Offset: 0x009973F2
		public unsafe float Clouds_Change_Time_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_140);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_140) = value;
			}
		}

		// Token: 0x17004B39 RID: 19257
		// (get) Token: 0x06024480 RID: 148608 RVA: 0x00999203 File Offset: 0x00997403
		// (set) Token: 0x06024481 RID: 148609 RVA: 0x00999213 File Offset: 0x00997413
		public unsafe bool 启用时间参数写入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_141) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_141) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B3A RID: 19258
		// (get) Token: 0x06024482 RID: 148610 RVA: 0x00999224 File Offset: 0x00997424
		// (set) Token: 0x06024483 RID: 148611 RVA: 0x00999234 File Offset: 0x00997434
		public unsafe bool UINeedLerpData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_142) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_142) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B3B RID: 19259
		// (get) Token: 0x06024484 RID: 148612 RVA: 0x00999245 File Offset: 0x00997445
		// (set) Token: 0x06024485 RID: 148613 RVA: 0x00999255 File Offset: 0x00997455
		public unsafe bool bEnableLumen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_143) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_143) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B3C RID: 19260
		// (get) Token: 0x06024486 RID: 148614 RVA: 0x00999266 File Offset: 0x00997466
		// (set) Token: 0x06024487 RID: 148615 RVA: 0x0099927A File Offset: 0x0099747A
		public unsafe UMaterialInstance LightFunctionMaterial_seq
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_144);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_144, value);
			}
		}

		// Token: 0x17004B3D RID: 19261
		// (get) Token: 0x06024488 RID: 148616 RVA: 0x0099928F File Offset: 0x0099748F
		// (set) Token: 0x06024489 RID: 148617 RVA: 0x0099929F File Offset: 0x0099749F
		public unsafe bool Override_Cloud_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_145) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_145) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B3E RID: 19262
		// (get) Token: 0x0602448A RID: 148618 RVA: 0x009992B0 File Offset: 0x009974B0
		// (set) Token: 0x0602448B RID: 148619 RVA: 0x009992C0 File Offset: 0x009974C0
		public unsafe float Sequence_Cloud_Time_Control
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_146);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_146) = value;
			}
		}

		// Token: 0x17004B3F RID: 19263
		// (get) Token: 0x0602448C RID: 148620 RVA: 0x009992D1 File Offset: 0x009974D1
		// (set) Token: 0x0602448D RID: 148621 RVA: 0x009992E1 File Offset: 0x009974E1
		public unsafe float Sequence_Cloud_Time_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_147);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_147) = value;
			}
		}

		// Token: 0x17004B40 RID: 19264
		// (get) Token: 0x0602448E RID: 148622 RVA: 0x009992F2 File Offset: 0x009974F2
		// (set) Token: 0x0602448F RID: 148623 RVA: 0x00999306 File Offset: 0x00997506
		public unsafe UMaterialInstance VolumetricLightFunctionMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_148);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_148, value);
			}
		}

		// Token: 0x17004B41 RID: 19265
		// (get) Token: 0x06024490 RID: 148624 RVA: 0x0099931B File Offset: 0x0099751B
		// (set) Token: 0x06024491 RID: 148625 RVA: 0x0099932B File Offset: 0x0099752B
		public unsafe bool PerformanceLightExist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_149) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_149) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B42 RID: 19266
		// (get) Token: 0x06024492 RID: 148626 RVA: 0x0099933C File Offset: 0x0099753C
		// (set) Token: 0x06024493 RID: 148627 RVA: 0x0099934C File Offset: 0x0099754C
		public unsafe bool bEnableAutoExposure
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_150) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_150) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B43 RID: 19267
		// (get) Token: 0x06024494 RID: 148628 RVA: 0x0099935D File Offset: 0x0099755D
		// (set) Token: 0x06024495 RID: 148629 RVA: 0x0099936D File Offset: 0x0099756D
		public unsafe bool PerformanceLightExist_MP4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_151) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_151) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B44 RID: 19268
		// (get) Token: 0x06024496 RID: 148630 RVA: 0x0099937E File Offset: 0x0099757E
		// (set) Token: 0x06024497 RID: 148631 RVA: 0x0099938E File Offset: 0x0099758E
		public unsafe bool BPScreenFilter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_152) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_152) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B45 RID: 19269
		// (get) Token: 0x06024498 RID: 148632 RVA: 0x0099939F File Offset: 0x0099759F
		// (set) Token: 0x06024499 RID: 148633 RVA: 0x009993B3 File Offset: 0x009975B3
		public unsafe UMaterialInstance Star_Material_V2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_153);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_153, value);
			}
		}

		// Token: 0x17004B46 RID: 19270
		// (get) Token: 0x0602449A RID: 148634 RVA: 0x009993C8 File Offset: 0x009975C8
		// (set) Token: 0x0602449B RID: 148635 RVA: 0x009993DC File Offset: 0x009975DC
		public unsafe UKuroScreenFilterSystemData ScreenFilterAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroScreenFilterSystemData>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_154);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_154, value);
			}
		}

		// Token: 0x17004B47 RID: 19271
		// (get) Token: 0x0602449C RID: 148636 RVA: 0x009993F4 File Offset: 0x009975F4
		// (set) Token: 0x0602449D RID: 148637 RVA: 0x0099942D File Offset: 0x0099762D
		[Nullable(1)]
		public TArray<SD_KuroTraceCloudData> Data
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SD_KuroTraceCloudData> result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TArray<SD_KuroTraceCloudData>(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_155, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x17004B48 RID: 19272
		// (get) Token: 0x0602449E RID: 148638 RVA: 0x0099943B File Offset: 0x0099763B
		// (set) Token: 0x0602449F RID: 148639 RVA: 0x0099944B File Offset: 0x0099764B
		public unsafe bool bCurrentPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_156) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_156) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B49 RID: 19273
		// (get) Token: 0x060244A0 RID: 148640 RVA: 0x0099945C File Offset: 0x0099765C
		// (set) Token: 0x060244A1 RID: 148641 RVA: 0x0099946C File Offset: 0x0099766C
		public unsafe bool bSetDailyRandom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_157) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_157) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B4A RID: 19274
		// (get) Token: 0x060244A2 RID: 148642 RVA: 0x0099947D File Offset: 0x0099767D
		// (set) Token: 0x060244A3 RID: 148643 RVA: 0x00999491 File Offset: 0x00997691
		public unsafe UMaterialInstance FrozenMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_158);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_158, value);
			}
		}

		// Token: 0x17004B4B RID: 19275
		// (get) Token: 0x060244A4 RID: 148644 RVA: 0x009994A6 File Offset: 0x009976A6
		// (set) Token: 0x060244A5 RID: 148645 RVA: 0x009994BA File Offset: 0x009976BA
		public unsafe UMaterialInstanceDynamic FrozenDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_159);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_159, value);
			}
		}

		// Token: 0x17004B4C RID: 19276
		// (get) Token: 0x060244A6 RID: 148646 RVA: 0x009994CF File Offset: 0x009976CF
		// (set) Token: 0x060244A7 RID: 148647 RVA: 0x009994DF File Offset: 0x009976DF
		public unsafe float TimeTotal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_160);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_160) = value;
			}
		}

		// Token: 0x17004B4D RID: 19277
		// (get) Token: 0x060244A8 RID: 148648 RVA: 0x009994F0 File Offset: 0x009976F0
		// (set) Token: 0x060244A9 RID: 148649 RVA: 0x00999500 File Offset: 0x00997700
		public unsafe bool ChangeFrozen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_161) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_161) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B4E RID: 19278
		// (get) Token: 0x060244AA RID: 148650 RVA: 0x00999511 File Offset: 0x00997711
		// (set) Token: 0x060244AB RID: 148651 RVA: 0x00999521 File Offset: 0x00997721
		public unsafe bool Ini
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_162) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_162) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B4F RID: 19279
		// (get) Token: 0x060244AC RID: 148652 RVA: 0x00999532 File Offset: 0x00997732
		// (set) Token: 0x060244AD RID: 148653 RVA: 0x00999542 File Offset: 0x00997742
		public unsafe bool NeedDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_163) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_163) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B50 RID: 19280
		// (get) Token: 0x060244AE RID: 148654 RVA: 0x00999553 File Offset: 0x00997753
		// (set) Token: 0x060244AF RID: 148655 RVA: 0x00999567 File Offset: 0x00997767
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroRainType> CurrentRainType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_164);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_164) = value;
			}
		}

		// Token: 0x17004B51 RID: 19281
		// (get) Token: 0x060244B0 RID: 148656 RVA: 0x0099957C File Offset: 0x0099777C
		// (set) Token: 0x060244B1 RID: 148657 RVA: 0x00999590 File Offset: 0x00997790
		public unsafe BP_SeqControlClouds_C SeqCloudsController
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SeqControlClouds_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_165);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_C.__PropertyOffset_165, value);
			}
		}

		// Token: 0x17004B52 RID: 19282
		// (get) Token: 0x060244B2 RID: 148658 RVA: 0x009995A5 File Offset: 0x009977A5
		// (set) Token: 0x060244B3 RID: 148659 RVA: 0x009995B5 File Offset: 0x009977B5
		public unsafe float Change_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_166);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_166) = value;
			}
		}

		// Token: 0x17004B53 RID: 19283
		// (get) Token: 0x060244B4 RID: 148660 RVA: 0x009995C6 File Offset: 0x009977C6
		// (set) Token: 0x060244B5 RID: 148661 RVA: 0x009995D6 File Offset: 0x009977D6
		public unsafe bool CloudControlDoOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_167) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_167) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B54 RID: 19284
		// (get) Token: 0x060244B6 RID: 148662 RVA: 0x009995E7 File Offset: 0x009977E7
		// (set) Token: 0x060244B7 RID: 148663 RVA: 0x009995F7 File Offset: 0x009977F7
		public unsafe bool bRunOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_168) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_168) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B55 RID: 19285
		// (get) Token: 0x060244B8 RID: 148664 RVA: 0x00999608 File Offset: 0x00997808
		// (set) Token: 0x060244B9 RID: 148665 RVA: 0x00999618 File Offset: 0x00997818
		public unsafe bool bNeedRunCommand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_169) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_169) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B56 RID: 19286
		// (get) Token: 0x060244BA RID: 148666 RVA: 0x0099962C File Offset: 0x0099782C
		// (set) Token: 0x060244BB RID: 148667 RVA: 0x00999665 File Offset: 0x00997865
		[Nullable(1)]
		public TArray<string> CommandToolEndArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._CommandToolEndArray) == null)
				{
					result = (this._CommandToolEndArray = new TArray<string>(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_170, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CommandToolEndArray.CopyAssign(value);
			}
		}

		// Token: 0x17004B57 RID: 19287
		// (get) Token: 0x060244BC RID: 148668 RVA: 0x00999673 File Offset: 0x00997873
		// (set) Token: 0x060244BD RID: 148669 RVA: 0x00999683 File Offset: 0x00997883
		public unsafe float CloudsCD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_171);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_171) = value;
			}
		}

		// Token: 0x17004B58 RID: 19288
		// (get) Token: 0x060244BE RID: 148670 RVA: 0x00999694 File Offset: 0x00997894
		// (set) Token: 0x060244BF RID: 148671 RVA: 0x009996A4 File Offset: 0x009978A4
		public unsafe float DelayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_172);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_172) = value;
			}
		}

		// Token: 0x17004B59 RID: 19289
		// (get) Token: 0x060244C0 RID: 148672 RVA: 0x009996B5 File Offset: 0x009978B5
		// (set) Token: 0x060244C1 RID: 148673 RVA: 0x009996C5 File Offset: 0x009978C5
		public unsafe bool EnableSetSkyBlendingSkipCVar
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_173) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_173) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B5A RID: 19290
		// (get) Token: 0x060244C2 RID: 148674 RVA: 0x009996D6 File Offset: 0x009978D6
		// (set) Token: 0x060244C3 RID: 148675 RVA: 0x009996E6 File Offset: 0x009978E6
		public unsafe bool DoOnceSetSkyBlendingSkipCVar
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_174) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_C.__PropertyOffset_174) = (value ? 1 : 0);
			}
		}

		// Token: 0x060244C4 RID: 148676 RVA: 0x009996F8 File Offset: 0x009978F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TickDelayTimeSetCVar(float DeltaTime)
		{
			BP_GlobalGI_C.__TickDelayTimeSetCVar_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__TickDelayTimeSetCVar_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(BP_GlobalGI_C.__TickDelayTimeSetCVar_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__TickDelayTimeSetCVar_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__TickDelayTimeSetCVar_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060244C5 RID: 148677 RVA: 0x0099973E File Offset: 0x0099793E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateVolumeCloudGodRay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateVolumeCloudGodRay_NativeFunctionPtr, null);
		}

		// Token: 0x060244C6 RID: 148678 RVA: 0x00999752 File Offset: 0x00997952
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnGlobalGITick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnGlobalGITick_NativeFunctionPtr, null);
		}

		// Token: 0x060244C7 RID: 148679 RVA: 0x00999766 File Offset: 0x00997966
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMeshBlend()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateMeshBlend_NativeFunctionPtr, null);
		}

		// Token: 0x060244C8 RID: 148680 RVA: 0x0099977A File Offset: 0x0099797A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ToggleShowDynamicSkyPlatform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__ToggleShowDynamicSkyPlatform_NativeFunctionPtr, null);
		}

		// Token: 0x060244C9 RID: 148681 RVA: 0x0099978E File Offset: 0x0099798E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpadteVolumertricCloud()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpadteVolumertricCloud_NativeFunctionPtr, null);
		}

		// Token: 0x060244CA RID: 148682 RVA: 0x009997A2 File Offset: 0x009979A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCharacterRootPos()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateCharacterRootPos_NativeFunctionPtr, null);
		}

		// Token: 0x060244CB RID: 148683 RVA: 0x009997B6 File Offset: 0x009979B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_GIControlParamToGlobalShaderParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Set_GIControlParamToGlobalShaderParam_NativeFunctionPtr, null);
		}

		// Token: 0x060244CC RID: 148684 RVA: 0x009997CA File Offset: 0x009979CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateOriginSkyAtmosphere()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateOriginSkyAtmosphere_NativeFunctionPtr, null);
		}

		// Token: 0x060244CD RID: 148685 RVA: 0x009997DE File Offset: 0x009979DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateVolumeCloudLightWeight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateVolumeCloudLightWeight_NativeFunctionPtr, null);
		}

		// Token: 0x060244CE RID: 148686 RVA: 0x009997F2 File Offset: 0x009979F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void IsPerformanceLightExist()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__IsPerformanceLightExist_NativeFunctionPtr, null);
		}

		// Token: 0x060244CF RID: 148687 RVA: 0x00999806 File Offset: 0x00997A06
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateOcean()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateOcean_NativeFunctionPtr, null);
		}

		// Token: 0x060244D0 RID: 148688 RVA: 0x0099981A File Offset: 0x00997A1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFrozen()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateFrozen_NativeFunctionPtr, null);
		}

		// Token: 0x060244D1 RID: 148689 RVA: 0x0099982E File Offset: 0x00997A2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateEditor_NativeFunctionPtr, null);
		}

		// Token: 0x060244D2 RID: 148690 RVA: 0x00999842 File Offset: 0x00997A42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateBigWorld()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateBigWorld_NativeFunctionPtr, null);
		}

		// Token: 0x060244D3 RID: 148691 RVA: 0x00999858 File Offset: 0x00997A58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMilkWay(ref UMaterialInstanceDynamic MilkyWay_DMI, ref FKuroMilkyWaySetting CloudCardSetting)
		{
			BP_GlobalGI_C.__UpdateMilkWay_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__UpdateMilkWay_FunctionParams[(UIntPtr)343] + 15L / (long)sizeof(BP_GlobalGI_C.__UpdateMilkWay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__UpdateMilkWay_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_C.__UpdateMilkWay_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = MilkyWay_DMI;
			ptr2.MilkyWay_DMI = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroMilkyWaySetting.StaticStruct(), &ptr->CloudCardSetting, CloudCardSetting.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateMilkWay_NativeFunctionPtr, (void*)ptr);
			MilkyWay_DMI = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->MilkyWay_DMI);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroMilkyWaySetting.StaticStruct(), CloudCardSetting.NativePtr, &ptr->CloudCardSetting, 1, false);
			}
		}

		// Token: 0x060244D4 RID: 148692 RVA: 0x00999908 File Offset: 0x00997B08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMilkyWayDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_C.__GetMilkyWayDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetMilkyWayDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_C.__GetMilkyWayDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetMilkyWayDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_C.__GetMilkyWayDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetMilkyWayDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x060244D5 RID: 148693 RVA: 0x0099996C File Offset: 0x00997B6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void updateLightFunctions()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__updateLightFunctions_NativeFunctionPtr, null);
		}

		// Token: 0x060244D6 RID: 148694 RVA: 0x00999980 File Offset: 0x00997B80
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetParallaxCorrectCachedCrossFadeShadowDirection(ref FRotator NewParam)
		{
			BP_GlobalGI_C.__GetParallaxCorrectCachedCrossFadeShadowDirection_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetParallaxCorrectCachedCrossFadeShadowDirection_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_GlobalGI_C.__GetParallaxCorrectCachedCrossFadeShadowDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetParallaxCorrectCachedCrossFadeShadowDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetParallaxCorrectCachedCrossFadeShadowDirection_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x060244D7 RID: 148695 RVA: 0x009999D8 File Offset: 0x00997BD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTODCharacterLighting(FLinearColor mainLight, float mainLightIntensity, FLinearColor skyLight, float skyLightIntensity, ref FLinearColor FrontSideLight, ref FLinearColor BackSideLight)
		{
			BP_GlobalGI_C.__GetTODCharacterLighting_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetTODCharacterLighting_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_GlobalGI_C.__GetTODCharacterLighting_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetTODCharacterLighting_NativeFunctionPtr, (void*)ptr, 1);
			ptr->mainLight = mainLight;
			ptr->mainLightIntensity = mainLightIntensity;
			ptr->skyLight = skyLight;
			ptr->skyLightIntensity = skyLightIntensity;
			ptr->FrontSideLight = FrontSideLight;
			ptr->BackSideLight = BackSideLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetTODCharacterLighting_NativeFunctionPtr, (void*)ptr);
			FrontSideLight = ptr->FrontSideLight;
			BackSideLight = ptr->BackSideLight;
		}

		// Token: 0x060244D8 RID: 148696 RVA: 0x00999A6C File Offset: 0x00997C6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetParallaxCorrectCachedShadowDirection(ref FRotator NewParam)
		{
			BP_GlobalGI_C.__GetParallaxCorrectCachedShadowDirection_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetParallaxCorrectCachedShadowDirection_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_C.__GetParallaxCorrectCachedShadowDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetParallaxCorrectCachedShadowDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetParallaxCorrectCachedShadowDirection_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x060244D9 RID: 148697 RVA: 0x00999AC4 File Offset: 0x00997CC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLevelSequenceCloudControl(BP_SeqControlClouds_C SeqCloudsController)
		{
			BP_GlobalGI_C.__SetLevelSequenceCloudControl_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__SetLevelSequenceCloudControl_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GlobalGI_C.__SetLevelSequenceCloudControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__SetLevelSequenceCloudControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SeqCloudsController = ((SeqCloudsController != null) ? SeqCloudsController.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__SetLevelSequenceCloudControl_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060244DA RID: 148698 RVA: 0x00999B1C File Offset: 0x00997D1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FLinearColor Clamp_Luminance(FLinearColor InColor, float Min, float Max)
		{
			BP_GlobalGI_C.__Clamp_Luminance_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__Clamp_Luminance_FunctionParams[(UIntPtr)123] + 15L / (long)sizeof(BP_GlobalGI_C.__Clamp_Luminance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__Clamp_Luminance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InColor = InColor;
			ptr->Min = Min;
			ptr->Max = Max;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Clamp_Luminance_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060244DB RID: 148699 RVA: 0x00999B78 File Offset: 0x00997D78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector EulerToForward(float Pitch, float Yaw)
		{
			BP_GlobalGI_C.__EulerToForward_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__EulerToForward_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GlobalGI_C.__EulerToForward_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__EulerToForward_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Pitch = Pitch;
			ptr->Yaw = Yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__EulerToForward_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060244DC RID: 148700 RVA: 0x00999BCB File Offset: 0x00997DCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Dynamic_Clouds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_Dynamic_Clouds_NativeFunctionPtr, null);
		}

		// Token: 0x060244DD RID: 148701 RVA: 0x00999BE0 File Offset: 0x00997DE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLevelSequenceTimeControl(BP_ControlTodTime_C TodTimeControl)
		{
			BP_GlobalGI_C.__SetLevelSequenceTimeControl_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__SetLevelSequenceTimeControl_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GlobalGI_C.__SetLevelSequenceTimeControl_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__SetLevelSequenceTimeControl_NativeFunctionPtr, (void*)ptr, 1);
			ptr->TodTimeControl = ((TodTimeControl != null) ? TodTimeControl.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__SetLevelSequenceTimeControl_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060244DE RID: 148702 RVA: 0x00999C38 File Offset: 0x00997E38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetStarsDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_C.__GetStarsDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetStarsDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_C.__GetStarsDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetStarsDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_C.__GetStarsDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetStarsDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x060244DF RID: 148703 RVA: 0x00999C9C File Offset: 0x00997E9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateClusteredStuff()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateClusteredStuff_NativeFunctionPtr, null);
		}

		// Token: 0x060244E0 RID: 148704 RVA: 0x00999CB0 File Offset: 0x00997EB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSkyboxDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_C.__GetSkyboxDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetSkyboxDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_C.__GetSkyboxDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetSkyboxDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_C.__GetSkyboxDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetSkyboxDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x060244E1 RID: 148705 RVA: 0x00999D14 File Offset: 0x00997F14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkybox()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateSkybox_NativeFunctionPtr, null);
		}

		// Token: 0x060244E2 RID: 148706 RVA: 0x00999D28 File Offset: 0x00997F28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Misc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_Misc_NativeFunctionPtr, null);
		}

		// Token: 0x060244E3 RID: 148707 RVA: 0x00999D3C File Offset: 0x00997F3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFlowmapSkybox()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateFlowmapSkybox_NativeFunctionPtr, null);
		}

		// Token: 0x060244E4 RID: 148708 RVA: 0x00999D50 File Offset: 0x00997F50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 申时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__申时_NativeFunctionPtr, null);
		}

		// Token: 0x060244E5 RID: 148709 RVA: 0x00999D64 File Offset: 0x00997F64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 下午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__下午_NativeFunctionPtr, null);
		}

		// Token: 0x060244E6 RID: 148710 RVA: 0x00999D78 File Offset: 0x00997F78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 上午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__上午_NativeFunctionPtr, null);
		}

		// Token: 0x060244E7 RID: 148711 RVA: 0x00999D8C File Offset: 0x00997F8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 辰时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__辰时_NativeFunctionPtr, null);
		}

		// Token: 0x060244E8 RID: 148712 RVA: 0x00999DA0 File Offset: 0x00997FA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Day_Night_Data_Layer()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_Day_Night_Data_Layer_NativeFunctionPtr, null);
		}

		// Token: 0x060244E9 RID: 148713 RVA: 0x00999DB4 File Offset: 0x00997FB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloudCard(ref FKuroCloudCardSetting CloudCardSetting)
		{
			BP_GlobalGI_C.__UpdateCloudCard_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__UpdateCloudCard_FunctionParams[(UIntPtr)179] + 15L / (long)sizeof(BP_GlobalGI_C.__UpdateCloudCard_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__UpdateCloudCard_NativeFunctionPtr, (void*)ptr, 1);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCloudCardSetting.StaticStruct(), &ptr->CloudCardSetting, CloudCardSetting.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateCloudCard_NativeFunctionPtr, (void*)ptr);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCloudCardSetting.StaticStruct(), CloudCardSetting.NativePtr, &ptr->CloudCardSetting, 1, false);
			}
		}

		// Token: 0x060244EA RID: 148714 RVA: 0x00999E3E File Offset: 0x0099803E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x060244EB RID: 148715 RVA: 0x00999E52 File Offset: 0x00998052
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 夜晚到清晨()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__夜晚到清晨_NativeFunctionPtr, null);
		}

		// Token: 0x060244EC RID: 148716 RVA: 0x00999E66 File Offset: 0x00998066
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 黄昏到夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__黄昏到夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x060244ED RID: 148717 RVA: 0x00999E7A File Offset: 0x0099807A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 黄昏()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__黄昏_NativeFunctionPtr, null);
		}

		// Token: 0x060244EE RID: 148718 RVA: 0x00999E8E File Offset: 0x0099808E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 中午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__中午_NativeFunctionPtr, null);
		}

		// Token: 0x060244EF RID: 148719 RVA: 0x00999EA2 File Offset: 0x009980A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 清晨()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__清晨_NativeFunctionPtr, null);
		}

		// Token: 0x060244F0 RID: 148720 RVA: 0x00999EB6 File Offset: 0x009980B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkyDome()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateSkyDome_NativeFunctionPtr, null);
		}

		// Token: 0x060244F1 RID: 148721 RVA: 0x00999ECA File Offset: 0x009980CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__InitGI_NativeFunctionPtr, null);
		}

		// Token: 0x060244F2 RID: 148722 RVA: 0x00999EE0 File Offset: 0x009980E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_All_Components_States(bool IsEnable)
		{
			BP_GlobalGI_C.__Set_All_Components_States_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__Set_All_Components_States_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_GlobalGI_C.__Set_All_Components_States_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__Set_All_Components_States_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEnable = IsEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Set_All_Components_States_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060244F3 RID: 148723 RVA: 0x00999F26 File Offset: 0x00998126
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLightShaft()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateLightShaft_NativeFunctionPtr, null);
		}

		// Token: 0x060244F4 RID: 148724 RVA: 0x00999F3C File Offset: 0x0099813C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLightDirectionFromVH(float Vertical, float Horizontal, ref FRotator Result)
		{
			BP_GlobalGI_C.__GetLightDirectionFromVH_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetLightDirectionFromVH_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_C.__GetLightDirectionFromVH_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetLightDirectionFromVH_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vertical = Vertical;
			ptr->Horizontal = Horizontal;
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetLightDirectionFromVH_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x060244F5 RID: 148725 RVA: 0x00999FA1 File Offset: 0x009981A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePostProcessVolume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdatePostProcessVolume_NativeFunctionPtr, null);
		}

		// Token: 0x060244F6 RID: 148726 RVA: 0x00999FB5 File Offset: 0x009981B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLightParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateLightParameters_NativeFunctionPtr, null);
		}

		// Token: 0x060244F7 RID: 148727 RVA: 0x00999FC9 File Offset: 0x009981C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Light_Direction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_Light_Direction_NativeFunctionPtr, null);
		}

		// Token: 0x060244F8 RID: 148728 RVA: 0x00999FDD File Offset: 0x009981DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Main_Light()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_Main_Light_NativeFunctionPtr, null);
		}

		// Token: 0x060244F9 RID: 148729 RVA: 0x00999FF1 File Offset: 0x009981F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_UI_Env()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_UI_Env_NativeFunctionPtr, null);
		}

		// Token: 0x060244FA RID: 148730 RVA: 0x0099A005 File Offset: 0x00998205
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateTime_NativeFunctionPtr, null);
		}

		// Token: 0x060244FB RID: 148731 RVA: 0x0099A01C File Offset: 0x0099821C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetViewLocation(ref FVector WorldPosition, ref bool Suc)
		{
			BP_GlobalGI_C.__GetViewLocation_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__GetViewLocation_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GlobalGI_C.__GetViewLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__GetViewLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->WorldPosition = WorldPosition;
			ptr->Suc = Suc;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__GetViewLocation_NativeFunctionPtr, (void*)ptr);
			WorldPosition = ptr->WorldPosition;
			Suc = ptr->Suc;
		}

		// Token: 0x060244FC RID: 148732 RVA: 0x0099A083 File Offset: 0x00998283
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitFeature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__InitFeature_NativeFunctionPtr, null);
		}

		// Token: 0x060244FD RID: 148733 RVA: 0x0099A098 File Offset: 0x00998298
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateLightDirectionWithLimit(float V, float H, float Time, ref FRotator NewParam)
		{
			BP_GlobalGI_C.__CalculateLightDirectionWithLimit_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__CalculateLightDirectionWithLimit_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_GlobalGI_C.__CalculateLightDirectionWithLimit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__CalculateLightDirectionWithLimit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V = V;
			ptr->H = H;
			ptr->Time = Time;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__CalculateLightDirectionWithLimit_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x060244FE RID: 148734 RVA: 0x0099A10C File Offset: 0x0099830C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateLightDirection(float Vertical, float Horizontal, float Time, ref FRotator NewParam)
		{
			BP_GlobalGI_C.__CalculateLightDirection_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__CalculateLightDirection_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GlobalGI_C.__CalculateLightDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__CalculateLightDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vertical = Vertical;
			ptr->Horizontal = Horizontal;
			ptr->Time = Time;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__CalculateLightDirection_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x060244FF RID: 148735 RVA: 0x0099A17A File Offset: 0x0099837A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateAtmosphere()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateAtmosphere_NativeFunctionPtr, null);
		}

		// Token: 0x06024500 RID: 148736 RVA: 0x0099A18E File Offset: 0x0099838E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkyLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateSkyLight_NativeFunctionPtr, null);
		}

		// Token: 0x06024501 RID: 148737 RVA: 0x0099A1A4 File Offset: 0x009983A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Scene_Light_Direction(ref FVector LightDir)
		{
			BP_GlobalGI_C.__Get_Scene_Light_Direction_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__Get_Scene_Light_Direction_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_C.__Get_Scene_Light_Direction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__Get_Scene_Light_Direction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LightDir = LightDir;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Get_Scene_Light_Direction_NativeFunctionPtr, (void*)ptr);
			LightDir = ptr->LightDir;
		}

		// Token: 0x06024502 RID: 148738 RVA: 0x0099A1FB File Offset: 0x009983FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGICompoemnt()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__InitGICompoemnt_NativeFunctionPtr, null);
		}

		// Token: 0x06024503 RID: 148739 RVA: 0x0099A20F File Offset: 0x0099840F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMaterials()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__InitMaterials_NativeFunctionPtr, null);
		}

		// Token: 0x06024504 RID: 148740 RVA: 0x0099A223 File Offset: 0x00998423
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateWind()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateWind_NativeFunctionPtr, null);
		}

		// Token: 0x06024505 RID: 148741 RVA: 0x0099A238 File Offset: 0x00998438
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get2SkyboxLerpWeight(float startSetting, float EndSetting, float CurrentTime, ref float Weight)
		{
			BP_GlobalGI_C.__Get2SkyboxLerpWeight_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__Get2SkyboxLerpWeight_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_GlobalGI_C.__Get2SkyboxLerpWeight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__Get2SkyboxLerpWeight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->startSetting = startSetting;
			ptr->EndSetting = EndSetting;
			ptr->CurrentTime = CurrentTime;
			ptr->Weight = Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Get2SkyboxLerpWeight_NativeFunctionPtr, (void*)ptr);
			Weight = ptr->Weight;
		}

		// Token: 0x06024506 RID: 148742 RVA: 0x0099A29E File Offset: 0x0099849E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Env()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__Update_Env_NativeFunctionPtr, null);
		}

		// Token: 0x06024507 RID: 148743 RVA: 0x0099A2B2 File Offset: 0x009984B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFog()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateFog_NativeFunctionPtr, null);
		}

		// Token: 0x06024508 RID: 148744 RVA: 0x0099A2C8 File Offset: 0x009984C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateGIData(bool Skip_Lerp_Data)
		{
			BP_GlobalGI_C.__UpdateGIData_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__UpdateGIData_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_C.__UpdateGIData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__UpdateGIData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Skip_Lerp_Data = Skip_Lerp_Data;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateGIData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024509 RID: 148745 RVA: 0x0099A30E File Offset: 0x0099850E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCharacterGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UpdateCharacterGI_NativeFunctionPtr, null);
		}

		// Token: 0x0602450A RID: 148746 RVA: 0x0099A322 File Offset: 0x00998522
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602450B RID: 148747 RVA: 0x0099A336 File Offset: 0x00998536
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602450C RID: 148748 RVA: 0x0099A34C File Offset: 0x0099854C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroTick(float DeltaTime)
		{
			BP_GlobalGI_C.__OnKuroTick_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602450D RID: 148749 RVA: 0x0099A394 File Offset: 0x00998594
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroTick_Implementation(float DeltaTime)
		{
			BP_GlobalGI_C.__OnKuroTick_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602450E RID: 148750 RVA: 0x0099A3DB File Offset: 0x009985DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroInit_NativeFunctionPtr, null);
		}

		// Token: 0x0602450F RID: 148751 RVA: 0x0099A3EF File Offset: 0x009985EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024510 RID: 148752 RVA: 0x0099A404 File Offset: 0x00998604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024511 RID: 148753 RVA: 0x0099A418 File Offset: 0x00998618
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024512 RID: 148754 RVA: 0x0099A42D File Offset: 0x0099862D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroRuntimeDestroy()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroRuntimeDestroy_NativeFunctionPtr, null);
		}

		// Token: 0x06024513 RID: 148755 RVA: 0x0099A441 File Offset: 0x00998641
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroRuntimeDestroy_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroRuntimeDestroy_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024514 RID: 148756 RVA: 0x0099A458 File Offset: 0x00998658
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroSetRuntimeTime(float CurrentTime)
		{
			BP_GlobalGI_C.__OnKuroSetRuntimeTime_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroSetRuntimeTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroSetRuntimeTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentTime = CurrentTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024515 RID: 148757 RVA: 0x0099A4A0 File Offset: 0x009986A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroSetRuntimeTime_Implementation(float CurrentTime)
		{
			BP_GlobalGI_C.__OnKuroSetRuntimeTime_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroSetRuntimeTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroSetRuntimeTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentTime = CurrentTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024516 RID: 148758 RVA: 0x0099A4E8 File Offset: 0x009986E8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroStartUiScene(string InName, [Nullable(2)] ULevel InUILevel)
		{
			BP_GlobalGI_C.__OnKuroStartUiScene_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroStartUiScene_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroStartUiScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->InName), InName);
			ptr->InUILevel = ((InUILevel != null) ? InUILevel.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_GlobalGI_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024517 RID: 148759 RVA: 0x0099A55C File Offset: 0x0099875C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroStartUiScene_Implementation(string InName, [Nullable(2)] ULevel InUILevel)
		{
			BP_GlobalGI_C.__OnKuroStartUiScene_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroStartUiScene_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroStartUiScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->InName), InName);
			ptr->InUILevel = ((InUILevel != null) ? InUILevel.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 0);
			UnrealReflectionUtils.DestroyStruct(BP_GlobalGI_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024518 RID: 148760 RVA: 0x0099A5D0 File Offset: 0x009987D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroEndUiScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroEndUiScene_NativeFunctionPtr, null);
		}

		// Token: 0x06024519 RID: 148761 RVA: 0x0099A5E4 File Offset: 0x009987E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroEndUiScene_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroEndUiScene_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602451A RID: 148762 RVA: 0x0099A5FC File Offset: 0x009987FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroTickEditor(float DeltaTime)
		{
			BP_GlobalGI_C.__OnKuroTickEditor_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroTickEditor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroTickEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602451B RID: 148763 RVA: 0x0099A644 File Offset: 0x00998844
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroTickEditor_Implementation(float DeltaTime)
		{
			BP_GlobalGI_C.__OnKuroTickEditor_FunctionParams* ptr = stackalloc BP_GlobalGI_C.__OnKuroTickEditor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_C.__OnKuroTickEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602451C RID: 148764 RVA: 0x0099A68B File Offset: 0x0099888B
		protected BP_GlobalGI_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401286D RID: 75885
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI.BP_GlobalGI_C";

		// Token: 0x0401286E RID: 75886
		private static IntPtr _ClassPtr;

		// Token: 0x0401286F RID: 75887
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012870 RID: 75888
		public static IntPtr __CallCloudChange__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012871 RID: 75889
		internal static int __PropertyOffset_0;

		// Token: 0x04012872 RID: 75890
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012873 RID: 75891
		internal static int __PropertyOffset_1;

		// Token: 0x04012874 RID: 75892
		internal static int __PropertyOffset_2;

		// Token: 0x04012875 RID: 75893
		internal static int __PropertyOffset_3;

		// Token: 0x04012876 RID: 75894
		internal static int __PropertyOffset_4;

		// Token: 0x04012877 RID: 75895
		internal static int __PropertyOffset_5;

		// Token: 0x04012878 RID: 75896
		internal static int __PropertyOffset_6;

		// Token: 0x04012879 RID: 75897
		internal static int __PropertyOffset_7;

		// Token: 0x0401287A RID: 75898
		internal static int __PropertyOffset_8;

		// Token: 0x0401287B RID: 75899
		internal static int __PropertyOffset_9;

		// Token: 0x0401287C RID: 75900
		internal static int __PropertyOffset_10;

		// Token: 0x0401287D RID: 75901
		internal static int __PropertyOffset_11;

		// Token: 0x0401287E RID: 75902
		internal static int __PropertyOffset_12;

		// Token: 0x0401287F RID: 75903
		internal static int __PropertyOffset_13;

		// Token: 0x04012880 RID: 75904
		internal static int __PropertyOffset_14;

		// Token: 0x04012881 RID: 75905
		internal static int __PropertyOffset_15;

		// Token: 0x04012882 RID: 75906
		internal static int __PropertyOffset_16;

		// Token: 0x04012883 RID: 75907
		internal static int __PropertyOffset_17;

		// Token: 0x04012884 RID: 75908
		internal static int __PropertyOffset_18;

		// Token: 0x04012885 RID: 75909
		internal static int __PropertyOffset_19;

		// Token: 0x04012886 RID: 75910
		internal static int __PropertyOffset_20;

		// Token: 0x04012887 RID: 75911
		internal static int __PropertyOffset_21;

		// Token: 0x04012888 RID: 75912
		internal static int __PropertyOffset_22;

		// Token: 0x04012889 RID: 75913
		internal static int __PropertyOffset_23;

		// Token: 0x0401288A RID: 75914
		internal static int __PropertyOffset_24;

		// Token: 0x0401288B RID: 75915
		internal static int __PropertyOffset_25;

		// Token: 0x0401288C RID: 75916
		internal static int __PropertyOffset_26;

		// Token: 0x0401288D RID: 75917
		internal static int __PropertyOffset_27;

		// Token: 0x0401288E RID: 75918
		internal static int __PropertyOffset_28;

		// Token: 0x0401288F RID: 75919
		internal static int __PropertyOffset_29;

		// Token: 0x04012890 RID: 75920
		internal static int __PropertyOffset_30;

		// Token: 0x04012891 RID: 75921
		internal static int __PropertyOffset_31;

		// Token: 0x04012892 RID: 75922
		internal static int __PropertyOffset_32;

		// Token: 0x04012893 RID: 75923
		internal static int __PropertyOffset_33;

		// Token: 0x04012894 RID: 75924
		internal static int __PropertyOffset_34;

		// Token: 0x04012895 RID: 75925
		internal static int __PropertyOffset_35;

		// Token: 0x04012896 RID: 75926
		internal static int __PropertyOffset_36;

		// Token: 0x04012897 RID: 75927
		internal static int __PropertyOffset_37;

		// Token: 0x04012898 RID: 75928
		internal static int __PropertyOffset_38;

		// Token: 0x04012899 RID: 75929
		internal static int __PropertyOffset_39;

		// Token: 0x0401289A RID: 75930
		internal static int __PropertyOffset_40;

		// Token: 0x0401289B RID: 75931
		internal static int __PropertyOffset_41;

		// Token: 0x0401289C RID: 75932
		internal static int __PropertyOffset_42;

		// Token: 0x0401289D RID: 75933
		internal static int __PropertyOffset_43;

		// Token: 0x0401289E RID: 75934
		internal static int __PropertyOffset_44;

		// Token: 0x0401289F RID: 75935
		private TArray<FVector2D> _SunLightExistTime;

		// Token: 0x040128A0 RID: 75936
		internal static int __PropertyOffset_45;

		// Token: 0x040128A1 RID: 75937
		private TArray<FVector2D> _MoonLightExistTime;

		// Token: 0x040128A2 RID: 75938
		internal static int __PropertyOffset_46;

		// Token: 0x040128A3 RID: 75939
		internal static int __PropertyOffset_47;

		// Token: 0x040128A4 RID: 75940
		internal static int __PropertyOffset_48;

		// Token: 0x040128A5 RID: 75941
		internal static int __PropertyOffset_49;

		// Token: 0x040128A6 RID: 75942
		internal static int __PropertyOffset_50;

		// Token: 0x040128A7 RID: 75943
		internal static int __PropertyOffset_51;

		// Token: 0x040128A8 RID: 75944
		internal static int __PropertyOffset_52;

		// Token: 0x040128A9 RID: 75945
		internal static int __PropertyOffset_53;

		// Token: 0x040128AA RID: 75946
		internal static int __PropertyOffset_54;

		// Token: 0x040128AB RID: 75947
		internal static int __PropertyOffset_55;

		// Token: 0x040128AC RID: 75948
		internal static int __PropertyOffset_56;

		// Token: 0x040128AD RID: 75949
		internal static int __PropertyOffset_57;

		// Token: 0x040128AE RID: 75950
		internal static int __PropertyOffset_58;

		// Token: 0x040128AF RID: 75951
		internal static int __PropertyOffset_59;

		// Token: 0x040128B0 RID: 75952
		internal static int __PropertyOffset_60;

		// Token: 0x040128B1 RID: 75953
		internal static int __PropertyOffset_61;

		// Token: 0x040128B2 RID: 75954
		internal static int __PropertyOffset_62;

		// Token: 0x040128B3 RID: 75955
		internal static int __PropertyOffset_63;

		// Token: 0x040128B4 RID: 75956
		internal static int __PropertyOffset_64;

		// Token: 0x040128B5 RID: 75957
		internal static int __PropertyOffset_65;

		// Token: 0x040128B6 RID: 75958
		internal static int __PropertyOffset_66;

		// Token: 0x040128B7 RID: 75959
		internal static int __PropertyOffset_67;

		// Token: 0x040128B8 RID: 75960
		internal static int __PropertyOffset_68;

		// Token: 0x040128B9 RID: 75961
		internal static int __PropertyOffset_69;

		// Token: 0x040128BA RID: 75962
		internal static int __PropertyOffset_70;

		// Token: 0x040128BB RID: 75963
		internal static int __PropertyOffset_71;

		// Token: 0x040128BC RID: 75964
		internal static int __PropertyOffset_72;

		// Token: 0x040128BD RID: 75965
		internal static int __PropertyOffset_73;

		// Token: 0x040128BE RID: 75966
		internal static int __PropertyOffset_74;

		// Token: 0x040128BF RID: 75967
		internal static int __PropertyOffset_75;

		// Token: 0x040128C0 RID: 75968
		internal static int __PropertyOffset_76;

		// Token: 0x040128C1 RID: 75969
		internal static int __PropertyOffset_77;

		// Token: 0x040128C2 RID: 75970
		internal static int __PropertyOffset_78;

		// Token: 0x040128C3 RID: 75971
		internal static int __PropertyOffset_79;

		// Token: 0x040128C4 RID: 75972
		internal static int __PropertyOffset_80;

		// Token: 0x040128C5 RID: 75973
		internal static int __PropertyOffset_81;

		// Token: 0x040128C6 RID: 75974
		internal static int __PropertyOffset_82;

		// Token: 0x040128C7 RID: 75975
		internal static int __PropertyOffset_83;

		// Token: 0x040128C8 RID: 75976
		internal static int __PropertyOffset_84;

		// Token: 0x040128C9 RID: 75977
		internal static int __PropertyOffset_85;

		// Token: 0x040128CA RID: 75978
		internal static int __PropertyOffset_86;

		// Token: 0x040128CB RID: 75979
		internal static int __PropertyOffset_87;

		// Token: 0x040128CC RID: 75980
		internal static int __PropertyOffset_88;

		// Token: 0x040128CD RID: 75981
		internal static int __PropertyOffset_89;

		// Token: 0x040128CE RID: 75982
		internal static int __PropertyOffset_90;

		// Token: 0x040128CF RID: 75983
		internal static int __PropertyOffset_91;

		// Token: 0x040128D0 RID: 75984
		internal static int __PropertyOffset_92;

		// Token: 0x040128D1 RID: 75985
		internal static int __PropertyOffset_93;

		// Token: 0x040128D2 RID: 75986
		internal static int __PropertyOffset_94;

		// Token: 0x040128D3 RID: 75987
		internal static int __PropertyOffset_95;

		// Token: 0x040128D4 RID: 75988
		internal static int __PropertyOffset_96;

		// Token: 0x040128D5 RID: 75989
		internal static int __PropertyOffset_97;

		// Token: 0x040128D6 RID: 75990
		internal static int __PropertyOffset_98;

		// Token: 0x040128D7 RID: 75991
		internal static int __PropertyOffset_99;

		// Token: 0x040128D8 RID: 75992
		internal static int __PropertyOffset_100;

		// Token: 0x040128D9 RID: 75993
		internal static int __PropertyOffset_101;

		// Token: 0x040128DA RID: 75994
		internal static int __PropertyOffset_102;

		// Token: 0x040128DB RID: 75995
		internal static int __PropertyOffset_103;

		// Token: 0x040128DC RID: 75996
		internal static int __PropertyOffset_104;

		// Token: 0x040128DD RID: 75997
		internal static int __PropertyOffset_105;

		// Token: 0x040128DE RID: 75998
		internal static int __PropertyOffset_106;

		// Token: 0x040128DF RID: 75999
		internal static int __PropertyOffset_107;

		// Token: 0x040128E0 RID: 76000
		internal static int __PropertyOffset_108;

		// Token: 0x040128E1 RID: 76001
		internal static int __PropertyOffset_109;

		// Token: 0x040128E2 RID: 76002
		internal static int __PropertyOffset_110;

		// Token: 0x040128E3 RID: 76003
		internal static int __PropertyOffset_111;

		// Token: 0x040128E4 RID: 76004
		internal static int __PropertyOffset_112;

		// Token: 0x040128E5 RID: 76005
		internal static int __PropertyOffset_113;

		// Token: 0x040128E6 RID: 76006
		internal static int __PropertyOffset_114;

		// Token: 0x040128E7 RID: 76007
		internal static int __PropertyOffset_115;

		// Token: 0x040128E8 RID: 76008
		internal static int __PropertyOffset_116;

		// Token: 0x040128E9 RID: 76009
		internal static int __PropertyOffset_117;

		// Token: 0x040128EA RID: 76010
		internal static int __PropertyOffset_118;

		// Token: 0x040128EB RID: 76011
		internal static int __PropertyOffset_119;

		// Token: 0x040128EC RID: 76012
		internal static int __PropertyOffset_120;

		// Token: 0x040128ED RID: 76013
		internal static int __PropertyOffset_121;

		// Token: 0x040128EE RID: 76014
		internal static int __PropertyOffset_122;

		// Token: 0x040128EF RID: 76015
		internal static int __PropertyOffset_123;

		// Token: 0x040128F0 RID: 76016
		internal static int __PropertyOffset_124;

		// Token: 0x040128F1 RID: 76017
		internal static int __PropertyOffset_125;

		// Token: 0x040128F2 RID: 76018
		internal static int __PropertyOffset_126;

		// Token: 0x040128F3 RID: 76019
		internal static int __PropertyOffset_127;

		// Token: 0x040128F4 RID: 76020
		internal static int __PropertyOffset_128;

		// Token: 0x040128F5 RID: 76021
		internal static int __PropertyOffset_129;

		// Token: 0x040128F6 RID: 76022
		internal static int __PropertyOffset_130;

		// Token: 0x040128F7 RID: 76023
		internal static int __PropertyOffset_131;

		// Token: 0x040128F8 RID: 76024
		internal static int __PropertyOffset_132;

		// Token: 0x040128F9 RID: 76025
		internal static int __PropertyOffset_133;

		// Token: 0x040128FA RID: 76026
		internal static int __PropertyOffset_134;

		// Token: 0x040128FB RID: 76027
		private CallCloudChange _CallCloudChange;

		// Token: 0x040128FC RID: 76028
		internal static int __PropertyOffset_135;

		// Token: 0x040128FD RID: 76029
		private FKuroCurveFloat _FogTImeControl;

		// Token: 0x040128FE RID: 76030
		internal static int __PropertyOffset_136;

		// Token: 0x040128FF RID: 76031
		internal static int __PropertyOffset_137;

		// Token: 0x04012900 RID: 76032
		internal static int __PropertyOffset_138;

		// Token: 0x04012901 RID: 76033
		internal static int __PropertyOffset_139;

		// Token: 0x04012902 RID: 76034
		internal static int __PropertyOffset_140;

		// Token: 0x04012903 RID: 76035
		internal static int __PropertyOffset_141;

		// Token: 0x04012904 RID: 76036
		internal static int __PropertyOffset_142;

		// Token: 0x04012905 RID: 76037
		internal static int __PropertyOffset_143;

		// Token: 0x04012906 RID: 76038
		internal static int __PropertyOffset_144;

		// Token: 0x04012907 RID: 76039
		internal static int __PropertyOffset_145;

		// Token: 0x04012908 RID: 76040
		internal static int __PropertyOffset_146;

		// Token: 0x04012909 RID: 76041
		internal static int __PropertyOffset_147;

		// Token: 0x0401290A RID: 76042
		internal static int __PropertyOffset_148;

		// Token: 0x0401290B RID: 76043
		internal static int __PropertyOffset_149;

		// Token: 0x0401290C RID: 76044
		internal static int __PropertyOffset_150;

		// Token: 0x0401290D RID: 76045
		internal static int __PropertyOffset_151;

		// Token: 0x0401290E RID: 76046
		internal static int __PropertyOffset_152;

		// Token: 0x0401290F RID: 76047
		internal static int __PropertyOffset_153;

		// Token: 0x04012910 RID: 76048
		internal static int __PropertyOffset_154;

		// Token: 0x04012911 RID: 76049
		internal static int __PropertyOffset_155;

		// Token: 0x04012912 RID: 76050
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SD_KuroTraceCloudData> _Data;

		// Token: 0x04012913 RID: 76051
		internal static int __PropertyOffset_156;

		// Token: 0x04012914 RID: 76052
		internal static int __PropertyOffset_157;

		// Token: 0x04012915 RID: 76053
		internal static int __PropertyOffset_158;

		// Token: 0x04012916 RID: 76054
		internal static int __PropertyOffset_159;

		// Token: 0x04012917 RID: 76055
		internal static int __PropertyOffset_160;

		// Token: 0x04012918 RID: 76056
		internal static int __PropertyOffset_161;

		// Token: 0x04012919 RID: 76057
		internal static int __PropertyOffset_162;

		// Token: 0x0401291A RID: 76058
		internal static int __PropertyOffset_163;

		// Token: 0x0401291B RID: 76059
		internal static int __PropertyOffset_164;

		// Token: 0x0401291C RID: 76060
		internal static int __PropertyOffset_165;

		// Token: 0x0401291D RID: 76061
		internal static int __PropertyOffset_166;

		// Token: 0x0401291E RID: 76062
		internal static int __PropertyOffset_167;

		// Token: 0x0401291F RID: 76063
		internal static int __PropertyOffset_168;

		// Token: 0x04012920 RID: 76064
		internal static int __PropertyOffset_169;

		// Token: 0x04012921 RID: 76065
		internal static int __PropertyOffset_170;

		// Token: 0x04012922 RID: 76066
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _CommandToolEndArray;

		// Token: 0x04012923 RID: 76067
		internal static int __PropertyOffset_171;

		// Token: 0x04012924 RID: 76068
		internal static int __PropertyOffset_172;

		// Token: 0x04012925 RID: 76069
		internal static int __PropertyOffset_173;

		// Token: 0x04012926 RID: 76070
		internal static int __PropertyOffset_174;

		// Token: 0x04012927 RID: 76071
		private static IntPtr __TickDelayTimeSetCVar_NativeFunctionPtr;

		// Token: 0x04012928 RID: 76072
		private static IntPtr __UpdateVolumeCloudGodRay_NativeFunctionPtr;

		// Token: 0x04012929 RID: 76073
		private static IntPtr __OnGlobalGITick_NativeFunctionPtr;

		// Token: 0x0401292A RID: 76074
		private static IntPtr __UpdateMeshBlend_NativeFunctionPtr;

		// Token: 0x0401292B RID: 76075
		private static IntPtr __ToggleShowDynamicSkyPlatform_NativeFunctionPtr;

		// Token: 0x0401292C RID: 76076
		private static IntPtr __UpadteVolumertricCloud_NativeFunctionPtr;

		// Token: 0x0401292D RID: 76077
		private static IntPtr __UpdateCharacterRootPos_NativeFunctionPtr;

		// Token: 0x0401292E RID: 76078
		private static IntPtr __Set_GIControlParamToGlobalShaderParam_NativeFunctionPtr;

		// Token: 0x0401292F RID: 76079
		private static IntPtr __UpdateOriginSkyAtmosphere_NativeFunctionPtr;

		// Token: 0x04012930 RID: 76080
		private static IntPtr __UpdateVolumeCloudLightWeight_NativeFunctionPtr;

		// Token: 0x04012931 RID: 76081
		private static IntPtr __IsPerformanceLightExist_NativeFunctionPtr;

		// Token: 0x04012932 RID: 76082
		private static IntPtr __UpdateOcean_NativeFunctionPtr;

		// Token: 0x04012933 RID: 76083
		private static IntPtr __UpdateFrozen_NativeFunctionPtr;

		// Token: 0x04012934 RID: 76084
		private static IntPtr __UpdateEditor_NativeFunctionPtr;

		// Token: 0x04012935 RID: 76085
		private static IntPtr __UpdateBigWorld_NativeFunctionPtr;

		// Token: 0x04012936 RID: 76086
		private static IntPtr __UpdateMilkWay_NativeFunctionPtr;

		// Token: 0x04012937 RID: 76087
		private static IntPtr __GetMilkyWayDMI_NativeFunctionPtr;

		// Token: 0x04012938 RID: 76088
		private static IntPtr __updateLightFunctions_NativeFunctionPtr;

		// Token: 0x04012939 RID: 76089
		private static IntPtr __GetParallaxCorrectCachedCrossFadeShadowDirection_NativeFunctionPtr;

		// Token: 0x0401293A RID: 76090
		private static IntPtr __GetTODCharacterLighting_NativeFunctionPtr;

		// Token: 0x0401293B RID: 76091
		private static IntPtr __GetParallaxCorrectCachedShadowDirection_NativeFunctionPtr;

		// Token: 0x0401293C RID: 76092
		private static IntPtr __SetLevelSequenceCloudControl_NativeFunctionPtr;

		// Token: 0x0401293D RID: 76093
		private static IntPtr __Clamp_Luminance_NativeFunctionPtr;

		// Token: 0x0401293E RID: 76094
		private static IntPtr __EulerToForward_NativeFunctionPtr;

		// Token: 0x0401293F RID: 76095
		private static IntPtr __Update_Dynamic_Clouds_NativeFunctionPtr;

		// Token: 0x04012940 RID: 76096
		private static IntPtr __SetLevelSequenceTimeControl_NativeFunctionPtr;

		// Token: 0x04012941 RID: 76097
		private static IntPtr __GetStarsDMI_NativeFunctionPtr;

		// Token: 0x04012942 RID: 76098
		private static IntPtr __UpdateClusteredStuff_NativeFunctionPtr;

		// Token: 0x04012943 RID: 76099
		private static IntPtr __GetSkyboxDMI_NativeFunctionPtr;

		// Token: 0x04012944 RID: 76100
		private static IntPtr __UpdateSkybox_NativeFunctionPtr;

		// Token: 0x04012945 RID: 76101
		private static IntPtr __Update_Misc_NativeFunctionPtr;

		// Token: 0x04012946 RID: 76102
		private static IntPtr __UpdateFlowmapSkybox_NativeFunctionPtr;

		// Token: 0x04012947 RID: 76103
		private static IntPtr __申时_NativeFunctionPtr;

		// Token: 0x04012948 RID: 76104
		private static IntPtr __下午_NativeFunctionPtr;

		// Token: 0x04012949 RID: 76105
		private static IntPtr __上午_NativeFunctionPtr;

		// Token: 0x0401294A RID: 76106
		private static IntPtr __辰时_NativeFunctionPtr;

		// Token: 0x0401294B RID: 76107
		private static IntPtr __Update_Day_Night_Data_Layer_NativeFunctionPtr;

		// Token: 0x0401294C RID: 76108
		private static IntPtr __UpdateCloudCard_NativeFunctionPtr;

		// Token: 0x0401294D RID: 76109
		private static IntPtr __夜晚_NativeFunctionPtr;

		// Token: 0x0401294E RID: 76110
		private static IntPtr __夜晚到清晨_NativeFunctionPtr;

		// Token: 0x0401294F RID: 76111
		private static IntPtr __黄昏到夜晚_NativeFunctionPtr;

		// Token: 0x04012950 RID: 76112
		private static IntPtr __黄昏_NativeFunctionPtr;

		// Token: 0x04012951 RID: 76113
		private static IntPtr __中午_NativeFunctionPtr;

		// Token: 0x04012952 RID: 76114
		private static IntPtr __清晨_NativeFunctionPtr;

		// Token: 0x04012953 RID: 76115
		private static IntPtr __UpdateSkyDome_NativeFunctionPtr;

		// Token: 0x04012954 RID: 76116
		private static IntPtr __InitGI_NativeFunctionPtr;

		// Token: 0x04012955 RID: 76117
		private static IntPtr __Set_All_Components_States_NativeFunctionPtr;

		// Token: 0x04012956 RID: 76118
		private static IntPtr __UpdateLightShaft_NativeFunctionPtr;

		// Token: 0x04012957 RID: 76119
		private static IntPtr __GetLightDirectionFromVH_NativeFunctionPtr;

		// Token: 0x04012958 RID: 76120
		private static IntPtr __UpdatePostProcessVolume_NativeFunctionPtr;

		// Token: 0x04012959 RID: 76121
		private static IntPtr __UpdateLightParameters_NativeFunctionPtr;

		// Token: 0x0401295A RID: 76122
		private static IntPtr __Update_Light_Direction_NativeFunctionPtr;

		// Token: 0x0401295B RID: 76123
		private static IntPtr __Update_Main_Light_NativeFunctionPtr;

		// Token: 0x0401295C RID: 76124
		private static IntPtr __Update_UI_Env_NativeFunctionPtr;

		// Token: 0x0401295D RID: 76125
		private static IntPtr __UpdateTime_NativeFunctionPtr;

		// Token: 0x0401295E RID: 76126
		private static IntPtr __GetViewLocation_NativeFunctionPtr;

		// Token: 0x0401295F RID: 76127
		private static IntPtr __InitFeature_NativeFunctionPtr;

		// Token: 0x04012960 RID: 76128
		private static IntPtr __CalculateLightDirectionWithLimit_NativeFunctionPtr;

		// Token: 0x04012961 RID: 76129
		private static IntPtr __CalculateLightDirection_NativeFunctionPtr;

		// Token: 0x04012962 RID: 76130
		private static IntPtr __UpdateAtmosphere_NativeFunctionPtr;

		// Token: 0x04012963 RID: 76131
		private static IntPtr __UpdateSkyLight_NativeFunctionPtr;

		// Token: 0x04012964 RID: 76132
		private static IntPtr __Get_Scene_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012965 RID: 76133
		private static IntPtr __InitGICompoemnt_NativeFunctionPtr;

		// Token: 0x04012966 RID: 76134
		private static IntPtr __InitMaterials_NativeFunctionPtr;

		// Token: 0x04012967 RID: 76135
		private static IntPtr __UpdateWind_NativeFunctionPtr;

		// Token: 0x04012968 RID: 76136
		private static IntPtr __Get2SkyboxLerpWeight_NativeFunctionPtr;

		// Token: 0x04012969 RID: 76137
		private static IntPtr __Update_Env_NativeFunctionPtr;

		// Token: 0x0401296A RID: 76138
		private static IntPtr __UpdateFog_NativeFunctionPtr;

		// Token: 0x0401296B RID: 76139
		private static IntPtr __UpdateGIData_NativeFunctionPtr;

		// Token: 0x0401296C RID: 76140
		private static IntPtr __UpdateCharacterGI_NativeFunctionPtr;

		// Token: 0x0401296D RID: 76141
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401296E RID: 76142
		private static IntPtr __OnKuroTick_NativeFunctionPtr;

		// Token: 0x0401296F RID: 76143
		private static IntPtr __OnKuroInit_NativeFunctionPtr;

		// Token: 0x04012970 RID: 76144
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012971 RID: 76145
		private static IntPtr __OnKuroRuntimeDestroy_NativeFunctionPtr;

		// Token: 0x04012972 RID: 76146
		private static IntPtr __OnKuroSetRuntimeTime_NativeFunctionPtr;

		// Token: 0x04012973 RID: 76147
		private static IntPtr __OnKuroStartUiScene_NativeFunctionPtr;

		// Token: 0x04012974 RID: 76148
		private static IntPtr __OnKuroEndUiScene_NativeFunctionPtr;

		// Token: 0x04012975 RID: 76149
		private static IntPtr __OnKuroTickEditor_NativeFunctionPtr;

		// Token: 0x02009DA2 RID: 40354
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __TickDelayTimeSetCVar_FunctionParams
		{
			// Token: 0x04032799 RID: 206745
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DA3 RID: 40355
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 328)]
		protected ref struct __UpdateMilkWay_FunctionParams
		{
			// Token: 0x0403279A RID: 206746
			[FieldOffset(0)]
			public IntPtr MilkyWay_DMI;

			// Token: 0x0403279B RID: 206747
			[FieldOffset(8)]
			public byte CloudCardSetting;
		}

		// Token: 0x02009DA4 RID: 40356
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetMilkyWayDMI_FunctionParams
		{
			// Token: 0x0403279C RID: 206748
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DA5 RID: 40357
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __GetParallaxCorrectCachedCrossFadeShadowDirection_FunctionParams
		{
			// Token: 0x0403279D RID: 206749
			[FieldOffset(0)]
			public FRotator NewParam;
		}

		// Token: 0x02009DA6 RID: 40358
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __GetTODCharacterLighting_FunctionParams
		{
			// Token: 0x0403279E RID: 206750
			[FieldOffset(0)]
			public FLinearColor mainLight;

			// Token: 0x0403279F RID: 206751
			[FieldOffset(16)]
			public float mainLightIntensity;

			// Token: 0x040327A0 RID: 206752
			[FieldOffset(20)]
			public FLinearColor skyLight;

			// Token: 0x040327A1 RID: 206753
			[FieldOffset(36)]
			public float skyLightIntensity;

			// Token: 0x040327A2 RID: 206754
			[FieldOffset(40)]
			public FLinearColor FrontSideLight;

			// Token: 0x040327A3 RID: 206755
			[FieldOffset(56)]
			public FLinearColor BackSideLight;
		}

		// Token: 0x02009DA7 RID: 40359
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetParallaxCorrectCachedShadowDirection_FunctionParams
		{
			// Token: 0x040327A4 RID: 206756
			[FieldOffset(0)]
			public FRotator NewParam;
		}

		// Token: 0x02009DA8 RID: 40360
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SetLevelSequenceCloudControl_FunctionParams
		{
			// Token: 0x040327A5 RID: 206757
			[FieldOffset(0)]
			public IntPtr SeqCloudsController;
		}

		// Token: 0x02009DA9 RID: 40361
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 108)]
		protected ref struct __Clamp_Luminance_FunctionParams
		{
			// Token: 0x040327A6 RID: 206758
			[FieldOffset(0)]
			public FLinearColor InColor;

			// Token: 0x040327A7 RID: 206759
			[FieldOffset(16)]
			public float Min;

			// Token: 0x040327A8 RID: 206760
			[FieldOffset(20)]
			public float Max;

			// Token: 0x040327A9 RID: 206761
			[FieldOffset(24)]
			public FLinearColor __Result;
		}

		// Token: 0x02009DAA RID: 40362
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __EulerToForward_FunctionParams
		{
			// Token: 0x040327AA RID: 206762
			[FieldOffset(0)]
			public float Pitch;

			// Token: 0x040327AB RID: 206763
			[FieldOffset(4)]
			public float Yaw;

			// Token: 0x040327AC RID: 206764
			[FieldOffset(8)]
			public FVector __Result;
		}

		// Token: 0x02009DAB RID: 40363
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SetLevelSequenceTimeControl_FunctionParams
		{
			// Token: 0x040327AD RID: 206765
			[FieldOffset(0)]
			public IntPtr TodTimeControl;
		}

		// Token: 0x02009DAC RID: 40364
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetStarsDMI_FunctionParams
		{
			// Token: 0x040327AE RID: 206766
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DAD RID: 40365
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSkyboxDMI_FunctionParams
		{
			// Token: 0x040327AF RID: 206767
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DAE RID: 40366
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 164)]
		protected ref struct __UpdateCloudCard_FunctionParams
		{
			// Token: 0x040327B0 RID: 206768
			[FieldOffset(0)]
			public byte CloudCardSetting;
		}

		// Token: 0x02009DAF RID: 40367
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __Set_All_Components_States_FunctionParams
		{
			// Token: 0x040327B1 RID: 206769
			[FieldOffset(0)]
			public bool IsEnable;
		}

		// Token: 0x02009DB0 RID: 40368
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetLightDirectionFromVH_FunctionParams
		{
			// Token: 0x040327B2 RID: 206770
			[FieldOffset(0)]
			public float Vertical;

			// Token: 0x040327B3 RID: 206771
			[FieldOffset(4)]
			public float Horizontal;

			// Token: 0x040327B4 RID: 206772
			[FieldOffset(8)]
			public FRotator Result;
		}

		// Token: 0x02009DB1 RID: 40369
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetViewLocation_FunctionParams
		{
			// Token: 0x040327B5 RID: 206773
			[FieldOffset(0)]
			public FVector WorldPosition;

			// Token: 0x040327B6 RID: 206774
			[FieldOffset(12)]
			public bool Suc;
		}

		// Token: 0x02009DB2 RID: 40370
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __CalculateLightDirectionWithLimit_FunctionParams
		{
			// Token: 0x040327B7 RID: 206775
			[FieldOffset(0)]
			public float V;

			// Token: 0x040327B8 RID: 206776
			[FieldOffset(4)]
			public float H;

			// Token: 0x040327B9 RID: 206777
			[FieldOffset(8)]
			public float Time;

			// Token: 0x040327BA RID: 206778
			[FieldOffset(12)]
			public FRotator NewParam;
		}

		// Token: 0x02009DB3 RID: 40371
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __CalculateLightDirection_FunctionParams
		{
			// Token: 0x040327BB RID: 206779
			[FieldOffset(0)]
			public float Vertical;

			// Token: 0x040327BC RID: 206780
			[FieldOffset(4)]
			public float Horizontal;

			// Token: 0x040327BD RID: 206781
			[FieldOffset(8)]
			public float Time;

			// Token: 0x040327BE RID: 206782
			[FieldOffset(12)]
			public FRotator NewParam;
		}

		// Token: 0x02009DB4 RID: 40372
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Get_Scene_Light_Direction_FunctionParams
		{
			// Token: 0x040327BF RID: 206783
			[FieldOffset(0)]
			public FVector LightDir;
		}

		// Token: 0x02009DB5 RID: 40373
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected ref struct __Get2SkyboxLerpWeight_FunctionParams
		{
			// Token: 0x040327C0 RID: 206784
			[FieldOffset(0)]
			public float startSetting;

			// Token: 0x040327C1 RID: 206785
			[FieldOffset(4)]
			public float EndSetting;

			// Token: 0x040327C2 RID: 206786
			[FieldOffset(8)]
			public float CurrentTime;

			// Token: 0x040327C3 RID: 206787
			[FieldOffset(12)]
			public float Weight;
		}

		// Token: 0x02009DB6 RID: 40374
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UpdateGIData_FunctionParams
		{
			// Token: 0x040327C4 RID: 206788
			[FieldOffset(0)]
			public bool Skip_Lerp_Data;
		}

		// Token: 0x02009DB7 RID: 40375
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroTick_FunctionParams
		{
			// Token: 0x040327C5 RID: 206789
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DB8 RID: 40376
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroSetRuntimeTime_FunctionParams
		{
			// Token: 0x040327C6 RID: 206790
			[FieldOffset(0)]
			public float CurrentTime;
		}

		// Token: 0x02009DB9 RID: 40377
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __OnKuroStartUiScene_FunctionParams
		{
			// Token: 0x040327C7 RID: 206791
			[FieldOffset(0)]
			public FString InName;

			// Token: 0x040327C8 RID: 206792
			[FieldOffset(16)]
			public IntPtr InUILevel;
		}

		// Token: 0x02009DBA RID: 40378
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroTickEditor_FunctionParams
		{
			// Token: 0x040327C9 RID: 206793
			[FieldOffset(0)]
			public float DeltaTime;
		}
	}
}
