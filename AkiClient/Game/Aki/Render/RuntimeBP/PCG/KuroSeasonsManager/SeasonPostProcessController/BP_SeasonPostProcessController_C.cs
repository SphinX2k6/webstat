using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroSeasonsManager.SeasonPostProcessController
{
	// Token: 0x02003BE7 RID: 15335
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/SeasonPostProcessController/BP_SeasonPostProcessController.BP_SeasonPostProcessController_C")]
	[UnrealStructLayout(1952, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1952)]
	public class BP_SeasonPostProcessController_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060227B5 RID: 141237 RVA: 0x00966A74 File Offset: 0x00964C74
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SeasonPostProcessController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/SeasonPostProcessController/BP_SeasonPostProcessController.BP_SeasonPostProcessController_C");
			}
			return BP_SeasonPostProcessController_C._ClassPtr;
		}

		// Token: 0x060227B6 RID: 141238 RVA: 0x00966A98 File Offset: 0x00964C98
		public BP_SeasonPostProcessController_C() : this(BuiltinUtils.AllocNativeUObject(BP_SeasonPostProcessController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060227B7 RID: 141239 RVA: 0x00966AC0 File Offset: 0x00964CC0
		[NullableContext(1)]
		public BP_SeasonPostProcessController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SeasonPostProcessController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004101 RID: 16641
		// (get) Token: 0x060227B8 RID: 141240 RVA: 0x00966AF4 File Offset: 0x00964CF4
		// (set) Token: 0x060227B9 RID: 141241 RVA: 0x00966B2D File Offset: 0x00964D2D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004102 RID: 16642
		// (get) Token: 0x060227BA RID: 141242 RVA: 0x00966B4E File Offset: 0x00964D4E
		// (set) Token: 0x060227BB RID: 141243 RVA: 0x00966B62 File Offset: 0x00964D62
		public unsafe UKuroPostProcessComponent PPC_Autumn
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004103 RID: 16643
		// (get) Token: 0x060227BC RID: 141244 RVA: 0x00966B77 File Offset: 0x00964D77
		// (set) Token: 0x060227BD RID: 141245 RVA: 0x00966B8B File Offset: 0x00964D8B
		public unsafe UKuroPostProcessComponent PPC_Summer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004104 RID: 16644
		// (get) Token: 0x060227BE RID: 141246 RVA: 0x00966BA0 File Offset: 0x00964DA0
		// (set) Token: 0x060227BF RID: 141247 RVA: 0x00966BB4 File Offset: 0x00964DB4
		public unsafe UKuroPostProcessComponent PPC_Spring
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004105 RID: 16645
		// (get) Token: 0x060227C0 RID: 141248 RVA: 0x00966BC9 File Offset: 0x00964DC9
		// (set) Token: 0x060227C1 RID: 141249 RVA: 0x00966BDD File Offset: 0x00964DDD
		public unsafe UKuroPostProcessComponent PPC_Snow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004106 RID: 16646
		// (get) Token: 0x060227C2 RID: 141250 RVA: 0x00966BF2 File Offset: 0x00964DF2
		// (set) Token: 0x060227C3 RID: 141251 RVA: 0x00966C06 File Offset: 0x00964E06
		public unsafe UKuroPostProcessComponent PPC_Rain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004107 RID: 16647
		// (get) Token: 0x060227C4 RID: 141252 RVA: 0x00966C1B File Offset: 0x00964E1B
		// (set) Token: 0x060227C5 RID: 141253 RVA: 0x00966C2F File Offset: 0x00964E2F
		public unsafe UKuroPostProcessComponent PPC_Winter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004108 RID: 16648
		// (get) Token: 0x060227C6 RID: 141254 RVA: 0x00966C44 File Offset: 0x00964E44
		// (set) Token: 0x060227C7 RID: 141255 RVA: 0x00966C58 File Offset: 0x00964E58
		public unsafe UBoxComponent PostProcessBoundCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004109 RID: 16649
		// (get) Token: 0x060227C8 RID: 141256 RVA: 0x00966C6D File Offset: 0x00964E6D
		// (set) Token: 0x060227C9 RID: 141257 RVA: 0x00966C81 File Offset: 0x00964E81
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700410A RID: 16650
		// (get) Token: 0x060227CA RID: 141258 RVA: 0x00966C96 File Offset: 0x00964E96
		// (set) Token: 0x060227CB RID: 141259 RVA: 0x00966CA6 File Offset: 0x00964EA6
		public unsafe float NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700410B RID: 16651
		// (get) Token: 0x060227CC RID: 141260 RVA: 0x00966CB7 File Offset: 0x00964EB7
		// (set) Token: 0x060227CD RID: 141261 RVA: 0x00966CC7 File Offset: 0x00964EC7
		public unsafe bool Open_EditorViewable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700410C RID: 16652
		// (get) Token: 0x060227CE RID: 141262 RVA: 0x00966CD8 File Offset: 0x00964ED8
		// (set) Token: 0x060227CF RID: 141263 RVA: 0x00966CE8 File Offset: 0x00964EE8
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700410D RID: 16653
		// (get) Token: 0x060227D0 RID: 141264 RVA: 0x00966CF9 File Offset: 0x00964EF9
		// (set) Token: 0x060227D1 RID: 141265 RVA: 0x00966D0D File Offset: 0x00964F0D
		public unsafe UMaterialParameterCollection SeasonMPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x1700410E RID: 16654
		// (get) Token: 0x060227D2 RID: 141266 RVA: 0x00966D22 File Offset: 0x00964F22
		// (set) Token: 0x060227D3 RID: 141267 RVA: 0x00966D37 File Offset: 0x00964F37
		[Nullable(1)]
		public TSoftObjectPtr<AKuroPostProcessVolume> PPV_Spring
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_13, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_13, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700410F RID: 16655
		// (get) Token: 0x060227D4 RID: 141268 RVA: 0x00966D5C File Offset: 0x00964F5C
		// (set) Token: 0x060227D5 RID: 141269 RVA: 0x00966D71 File Offset: 0x00964F71
		[Nullable(1)]
		public TSoftObjectPtr<AKuroPostProcessVolume> PPV_Summer
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_14, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004110 RID: 16656
		// (get) Token: 0x060227D6 RID: 141270 RVA: 0x00966D96 File Offset: 0x00964F96
		// (set) Token: 0x060227D7 RID: 141271 RVA: 0x00966DAB File Offset: 0x00964FAB
		[Nullable(1)]
		public TSoftObjectPtr<AKuroPostProcessVolume> PPV_Autumn
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_15, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_15, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004111 RID: 16657
		// (get) Token: 0x060227D8 RID: 141272 RVA: 0x00966DD0 File Offset: 0x00964FD0
		// (set) Token: 0x060227D9 RID: 141273 RVA: 0x00966DE5 File Offset: 0x00964FE5
		[Nullable(1)]
		public TSoftObjectPtr<AKuroPostProcessVolume> PPV_Winter
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_16, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_16, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004112 RID: 16658
		// (get) Token: 0x060227DA RID: 141274 RVA: 0x00966E0A File Offset: 0x0096500A
		// (set) Token: 0x060227DB RID: 141275 RVA: 0x00966E1F File Offset: 0x0096501F
		[Nullable(1)]
		public TSoftObjectPtr<AKuroPostProcessVolume> PPV_Rain
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_17, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_17, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004113 RID: 16659
		// (get) Token: 0x060227DC RID: 141276 RVA: 0x00966E44 File Offset: 0x00965044
		// (set) Token: 0x060227DD RID: 141277 RVA: 0x00966E59 File Offset: 0x00965059
		[Nullable(1)]
		public TSoftObjectPtr<AKuroPostProcessVolume> PPV_Sonw
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_18, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17004114 RID: 16660
		// (get) Token: 0x060227DE RID: 141278 RVA: 0x00966E7E File Offset: 0x0096507E
		// (set) Token: 0x060227DF RID: 141279 RVA: 0x00966E92 File Offset: 0x00965092
		public unsafe UKuroWeatherDataAsset DA_Spring
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17004115 RID: 16661
		// (get) Token: 0x060227E0 RID: 141280 RVA: 0x00966EA7 File Offset: 0x009650A7
		// (set) Token: 0x060227E1 RID: 141281 RVA: 0x00966EBB File Offset: 0x009650BB
		public unsafe UKuroWeatherDataAsset DA_Summer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004116 RID: 16662
		// (get) Token: 0x060227E2 RID: 141282 RVA: 0x00966ED0 File Offset: 0x009650D0
		// (set) Token: 0x060227E3 RID: 141283 RVA: 0x00966EE4 File Offset: 0x009650E4
		public unsafe UKuroWeatherDataAsset DA_Autumn
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004117 RID: 16663
		// (get) Token: 0x060227E4 RID: 141284 RVA: 0x00966EF9 File Offset: 0x009650F9
		// (set) Token: 0x060227E5 RID: 141285 RVA: 0x00966F0D File Offset: 0x0096510D
		public unsafe UKuroWeatherDataAsset DA_Winter
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004118 RID: 16664
		// (get) Token: 0x060227E6 RID: 141286 RVA: 0x00966F22 File Offset: 0x00965122
		// (set) Token: 0x060227E7 RID: 141287 RVA: 0x00966F36 File Offset: 0x00965136
		public unsafe UKuroWeatherDataAsset DA_Rain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004119 RID: 16665
		// (get) Token: 0x060227E8 RID: 141288 RVA: 0x00966F4B File Offset: 0x0096514B
		// (set) Token: 0x060227E9 RID: 141289 RVA: 0x00966F5F File Offset: 0x0096515F
		public unsafe UKuroWeatherDataAsset DA_Snow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x1700411A RID: 16666
		// (get) Token: 0x060227EA RID: 141290 RVA: 0x00966F74 File Offset: 0x00965174
		// (set) Token: 0x060227EB RID: 141291 RVA: 0x00966F88 File Offset: 0x00965188
		public unsafe FName Parameter_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700411B RID: 16667
		// (get) Token: 0x060227EC RID: 141292 RVA: 0x00966F9D File Offset: 0x0096519D
		// (set) Token: 0x060227ED RID: 141293 RVA: 0x00966FAD File Offset: 0x009651AD
		public unsafe float SeasonTransitionTimeLine
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700411C RID: 16668
		// (get) Token: 0x060227EE RID: 141294 RVA: 0x00966FBE File Offset: 0x009651BE
		// (set) Token: 0x060227EF RID: 141295 RVA: 0x00966FD2 File Offset: 0x009651D2
		public unsafe FLinearColor SeasonWeights
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700411D RID: 16669
		// (get) Token: 0x060227F0 RID: 141296 RVA: 0x00966FE7 File Offset: 0x009651E7
		// (set) Token: 0x060227F1 RID: 141297 RVA: 0x00966FFB File Offset: 0x009651FB
		public unsafe FVector ActivationBoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x1700411E RID: 16670
		// (get) Token: 0x060227F2 RID: 141298 RVA: 0x00967010 File Offset: 0x00965210
		// (set) Token: 0x060227F3 RID: 141299 RVA: 0x00967020 File Offset: 0x00965220
		public unsafe float SeasonPPC_Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x1700411F RID: 16671
		// (get) Token: 0x060227F4 RID: 141300 RVA: 0x00967031 File Offset: 0x00965231
		// (set) Token: 0x060227F5 RID: 141301 RVA: 0x00967041 File Offset: 0x00965241
		public unsafe float WeatherPPC_Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004120 RID: 16672
		// (get) Token: 0x060227F6 RID: 141302 RVA: 0x00967052 File Offset: 0x00965252
		// (set) Token: 0x060227F7 RID: 141303 RVA: 0x00967062 File Offset: 0x00965262
		public unsafe float ExitFadeOutDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004121 RID: 16673
		// (get) Token: 0x060227F8 RID: 141304 RVA: 0x00967073 File Offset: 0x00965273
		// (set) Token: 0x060227F9 RID: 141305 RVA: 0x00967083 File Offset: 0x00965283
		public unsafe bool bIsFadingOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004122 RID: 16674
		// (get) Token: 0x060227FA RID: 141306 RVA: 0x00967094 File Offset: 0x00965294
		// (set) Token: 0x060227FB RID: 141307 RVA: 0x009670A4 File Offset: 0x009652A4
		public unsafe float FadeOutTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004123 RID: 16675
		// (get) Token: 0x060227FC RID: 141308 RVA: 0x009670B5 File Offset: 0x009652B5
		// (set) Token: 0x060227FD RID: 141309 RVA: 0x009670C5 File Offset: 0x009652C5
		public unsafe float RainChance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004124 RID: 16676
		// (get) Token: 0x060227FE RID: 141310 RVA: 0x009670D6 File Offset: 0x009652D6
		// (set) Token: 0x060227FF RID: 141311 RVA: 0x009670E6 File Offset: 0x009652E6
		public unsafe float RainMinDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17004125 RID: 16677
		// (get) Token: 0x06022800 RID: 141312 RVA: 0x009670F7 File Offset: 0x009652F7
		// (set) Token: 0x06022801 RID: 141313 RVA: 0x00967107 File Offset: 0x00965307
		public unsafe float RainMaxDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17004126 RID: 16678
		// (get) Token: 0x06022802 RID: 141314 RVA: 0x00967118 File Offset: 0x00965318
		// (set) Token: 0x06022803 RID: 141315 RVA: 0x00967128 File Offset: 0x00965328
		public unsafe float RainDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004127 RID: 16679
		// (get) Token: 0x06022804 RID: 141316 RVA: 0x00967139 File Offset: 0x00965339
		// (set) Token: 0x06022805 RID: 141317 RVA: 0x0096714D File Offset: 0x0096534D
		[Nullable(0)]
		public unsafe TEnumAsByte<E_ESeasonWeather> RainState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_38);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004128 RID: 16680
		// (get) Token: 0x06022806 RID: 141318 RVA: 0x00967162 File Offset: 0x00965362
		// (set) Token: 0x06022807 RID: 141319 RVA: 0x00967172 File Offset: 0x00965372
		public unsafe float RainTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004129 RID: 16681
		// (get) Token: 0x06022808 RID: 141320 RVA: 0x00967183 File Offset: 0x00965383
		// (set) Token: 0x06022809 RID: 141321 RVA: 0x00967193 File Offset: 0x00965393
		public unsafe float RainTargetDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x1700412A RID: 16682
		// (get) Token: 0x0602280A RID: 141322 RVA: 0x009671A4 File Offset: 0x009653A4
		// (set) Token: 0x0602280B RID: 141323 RVA: 0x009671B4 File Offset: 0x009653B4
		public unsafe float SnowChance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700412B RID: 16683
		// (get) Token: 0x0602280C RID: 141324 RVA: 0x009671C5 File Offset: 0x009653C5
		// (set) Token: 0x0602280D RID: 141325 RVA: 0x009671D5 File Offset: 0x009653D5
		public unsafe float SnowMinDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700412C RID: 16684
		// (get) Token: 0x0602280E RID: 141326 RVA: 0x009671E6 File Offset: 0x009653E6
		// (set) Token: 0x0602280F RID: 141327 RVA: 0x009671F6 File Offset: 0x009653F6
		public unsafe float SnowMaxDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x1700412D RID: 16685
		// (get) Token: 0x06022810 RID: 141328 RVA: 0x00967207 File Offset: 0x00965407
		// (set) Token: 0x06022811 RID: 141329 RVA: 0x00967217 File Offset: 0x00965417
		public unsafe float SnowDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700412E RID: 16686
		// (get) Token: 0x06022812 RID: 141330 RVA: 0x00967228 File Offset: 0x00965428
		// (set) Token: 0x06022813 RID: 141331 RVA: 0x0096723C File Offset: 0x0096543C
		[Nullable(0)]
		public unsafe TEnumAsByte<E_ESeasonWeather> SnowState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_45);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x1700412F RID: 16687
		// (get) Token: 0x06022814 RID: 141332 RVA: 0x00967251 File Offset: 0x00965451
		// (set) Token: 0x06022815 RID: 141333 RVA: 0x00967261 File Offset: 0x00965461
		public unsafe float SnowTimer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17004130 RID: 16688
		// (get) Token: 0x06022816 RID: 141334 RVA: 0x00967272 File Offset: 0x00965472
		// (set) Token: 0x06022817 RID: 141335 RVA: 0x00967282 File Offset: 0x00965482
		public unsafe float SnowTargetDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17004131 RID: 16689
		// (get) Token: 0x06022818 RID: 141336 RVA: 0x00967293 File Offset: 0x00965493
		// (set) Token: 0x06022819 RID: 141337 RVA: 0x009672A3 File Offset: 0x009654A3
		public unsafe float RainCooldownMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17004132 RID: 16690
		// (get) Token: 0x0602281A RID: 141338 RVA: 0x009672B4 File Offset: 0x009654B4
		// (set) Token: 0x0602281B RID: 141339 RVA: 0x009672C4 File Offset: 0x009654C4
		public unsafe float RainCooldownMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17004133 RID: 16691
		// (get) Token: 0x0602281C RID: 141340 RVA: 0x009672D5 File Offset: 0x009654D5
		// (set) Token: 0x0602281D RID: 141341 RVA: 0x009672E5 File Offset: 0x009654E5
		public unsafe float RainTargetCooldown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17004134 RID: 16692
		// (get) Token: 0x0602281E RID: 141342 RVA: 0x009672F6 File Offset: 0x009654F6
		// (set) Token: 0x0602281F RID: 141343 RVA: 0x00967306 File Offset: 0x00965506
		public unsafe bool bEditorPreviewRain
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004135 RID: 16693
		// (get) Token: 0x06022820 RID: 141344 RVA: 0x00967317 File Offset: 0x00965517
		// (set) Token: 0x06022821 RID: 141345 RVA: 0x00967327 File Offset: 0x00965527
		public unsafe float SnowCooldownMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17004136 RID: 16694
		// (get) Token: 0x06022822 RID: 141346 RVA: 0x00967338 File Offset: 0x00965538
		// (set) Token: 0x06022823 RID: 141347 RVA: 0x00967348 File Offset: 0x00965548
		public unsafe float SnowCooldownMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17004137 RID: 16695
		// (get) Token: 0x06022824 RID: 141348 RVA: 0x00967359 File Offset: 0x00965559
		// (set) Token: 0x06022825 RID: 141349 RVA: 0x00967369 File Offset: 0x00965569
		public unsafe float SnowTargetCooldown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17004138 RID: 16696
		// (get) Token: 0x06022826 RID: 141350 RVA: 0x0096737A File Offset: 0x0096557A
		// (set) Token: 0x06022827 RID: 141351 RVA: 0x0096738A File Offset: 0x0096558A
		public unsafe bool bEditorPreviewSnow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SeasonPostProcessController_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004139 RID: 16697
		// (get) Token: 0x06022828 RID: 141352 RVA: 0x0096739B File Offset: 0x0096559B
		// (set) Token: 0x06022829 RID: 141353 RVA: 0x009673AF File Offset: 0x009655AF
		public unsafe AKuroPostProcessVolume PPV_Spring_Final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x1700413A RID: 16698
		// (get) Token: 0x0602282A RID: 141354 RVA: 0x009673C4 File Offset: 0x009655C4
		// (set) Token: 0x0602282B RID: 141355 RVA: 0x009673D8 File Offset: 0x009655D8
		public unsafe AKuroPostProcessVolume PPV_Summer_Final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x1700413B RID: 16699
		// (get) Token: 0x0602282C RID: 141356 RVA: 0x009673ED File Offset: 0x009655ED
		// (set) Token: 0x0602282D RID: 141357 RVA: 0x00967401 File Offset: 0x00965601
		public unsafe AKuroPostProcessVolume PPV_Autumn_Final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x1700413C RID: 16700
		// (get) Token: 0x0602282E RID: 141358 RVA: 0x00967416 File Offset: 0x00965616
		// (set) Token: 0x0602282F RID: 141359 RVA: 0x0096742A File Offset: 0x0096562A
		public unsafe AKuroPostProcessVolume PPV_Winter_Final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_59);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_59, value);
			}
		}

		// Token: 0x1700413D RID: 16701
		// (get) Token: 0x06022830 RID: 141360 RVA: 0x0096743F File Offset: 0x0096563F
		// (set) Token: 0x06022831 RID: 141361 RVA: 0x00967453 File Offset: 0x00965653
		public unsafe AKuroPostProcessVolume PPV_Rain_Final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_60);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_60, value);
			}
		}

		// Token: 0x1700413E RID: 16702
		// (get) Token: 0x06022832 RID: 141362 RVA: 0x00967468 File Offset: 0x00965668
		// (set) Token: 0x06022833 RID: 141363 RVA: 0x0096747C File Offset: 0x0096567C
		public unsafe AKuroPostProcessVolume PPV_Snow_Final
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_61);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SeasonPostProcessController_C.__PropertyOffset_61, value);
			}
		}

		// Token: 0x06022834 RID: 141364 RVA: 0x00967491 File Offset: 0x00965691
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Get_WP_SeasonPostProcess()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__Get_WP_SeasonPostProcess_NativeFunctionPtr, null);
		}

		// Token: 0x06022835 RID: 141365 RVA: 0x009674A5 File Offset: 0x009656A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateWeatherSnow()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__UpdateWeatherSnow_NativeFunctionPtr, null);
		}

		// Token: 0x06022836 RID: 141366 RVA: 0x009674B9 File Offset: 0x009656B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateWeatherRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__UpdateWeatherRain_NativeFunctionPtr, null);
		}

		// Token: 0x06022837 RID: 141367 RVA: 0x009674CD File Offset: 0x009656CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFadeOut()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__UpdateFadeOut_NativeFunctionPtr, null);
		}

		// Token: 0x06022838 RID: 141368 RVA: 0x009674E1 File Offset: 0x009656E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetAllPPV()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__ResetAllPPV_NativeFunctionPtr, null);
		}

		// Token: 0x06022839 RID: 141369 RVA: 0x009674F5 File Offset: 0x009656F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSeasonPPV()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__UpdateSeasonPPV_NativeFunctionPtr, null);
		}

		// Token: 0x0602283A RID: 141370 RVA: 0x00967509 File Offset: 0x00965709
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CalcSeasonWeights()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__CalcSeasonWeights_NativeFunctionPtr, null);
		}

		// Token: 0x0602283B RID: 141371 RVA: 0x0096751D File Offset: 0x0096571D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602283C RID: 141372 RVA: 0x00967531 File Offset: 0x00965731
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602283D RID: 141373 RVA: 0x00967548 File Offset: 0x00965748
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SeasonPostProcessController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602283E RID: 141374 RVA: 0x00967590 File Offset: 0x00965790
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SeasonPostProcessController_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602283F RID: 141375 RVA: 0x009675D8 File Offset: 0x009657D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SeasonPostProcessController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022840 RID: 141376 RVA: 0x00967620 File Offset: 0x00965820
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SeasonPostProcessController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022841 RID: 141377 RVA: 0x00967667 File Offset: 0x00965867
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022842 RID: 141378 RVA: 0x0096767B File Offset: 0x0096587B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022843 RID: 141379 RVA: 0x00967690 File Offset: 0x00965890
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022844 RID: 141380 RVA: 0x0096771C File Offset: 0x0096591C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022845 RID: 141381 RVA: 0x009677D8 File Offset: 0x009659D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SeasonPostProcessController(int EntryPoint)
		{
			BP_SeasonPostProcessController_C.__ExecuteUbergraph_BP_SeasonPostProcessController_FunctionParams* ptr = stackalloc BP_SeasonPostProcessController_C.__ExecuteUbergraph_BP_SeasonPostProcessController_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_SeasonPostProcessController_C.__ExecuteUbergraph_BP_SeasonPostProcessController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SeasonPostProcessController_C.__ExecuteUbergraph_BP_SeasonPostProcessController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SeasonPostProcessController_C.__ExecuteUbergraph_BP_SeasonPostProcessController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022846 RID: 141382 RVA: 0x00967822 File Offset: 0x00965A22
		protected BP_SeasonPostProcessController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401175B RID: 71515
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/SeasonPostProcessController/BP_SeasonPostProcessController.BP_SeasonPostProcessController_C";

		// Token: 0x0401175C RID: 71516
		private static IntPtr _ClassPtr;

		// Token: 0x0401175D RID: 71517
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401175E RID: 71518
		internal static int __PropertyOffset_0;

		// Token: 0x0401175F RID: 71519
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011760 RID: 71520
		internal static int __PropertyOffset_1;

		// Token: 0x04011761 RID: 71521
		internal static int __PropertyOffset_2;

		// Token: 0x04011762 RID: 71522
		internal static int __PropertyOffset_3;

		// Token: 0x04011763 RID: 71523
		internal static int __PropertyOffset_4;

		// Token: 0x04011764 RID: 71524
		internal static int __PropertyOffset_5;

		// Token: 0x04011765 RID: 71525
		internal static int __PropertyOffset_6;

		// Token: 0x04011766 RID: 71526
		internal static int __PropertyOffset_7;

		// Token: 0x04011767 RID: 71527
		internal static int __PropertyOffset_8;

		// Token: 0x04011768 RID: 71528
		internal static int __PropertyOffset_9;

		// Token: 0x04011769 RID: 71529
		internal static int __PropertyOffset_10;

		// Token: 0x0401176A RID: 71530
		internal static int __PropertyOffset_11;

		// Token: 0x0401176B RID: 71531
		internal static int __PropertyOffset_12;

		// Token: 0x0401176C RID: 71532
		internal static int __PropertyOffset_13;

		// Token: 0x0401176D RID: 71533
		internal static int __PropertyOffset_14;

		// Token: 0x0401176E RID: 71534
		internal static int __PropertyOffset_15;

		// Token: 0x0401176F RID: 71535
		internal static int __PropertyOffset_16;

		// Token: 0x04011770 RID: 71536
		internal static int __PropertyOffset_17;

		// Token: 0x04011771 RID: 71537
		internal static int __PropertyOffset_18;

		// Token: 0x04011772 RID: 71538
		internal static int __PropertyOffset_19;

		// Token: 0x04011773 RID: 71539
		internal static int __PropertyOffset_20;

		// Token: 0x04011774 RID: 71540
		internal static int __PropertyOffset_21;

		// Token: 0x04011775 RID: 71541
		internal static int __PropertyOffset_22;

		// Token: 0x04011776 RID: 71542
		internal static int __PropertyOffset_23;

		// Token: 0x04011777 RID: 71543
		internal static int __PropertyOffset_24;

		// Token: 0x04011778 RID: 71544
		internal static int __PropertyOffset_25;

		// Token: 0x04011779 RID: 71545
		internal static int __PropertyOffset_26;

		// Token: 0x0401177A RID: 71546
		internal static int __PropertyOffset_27;

		// Token: 0x0401177B RID: 71547
		internal static int __PropertyOffset_28;

		// Token: 0x0401177C RID: 71548
		internal static int __PropertyOffset_29;

		// Token: 0x0401177D RID: 71549
		internal static int __PropertyOffset_30;

		// Token: 0x0401177E RID: 71550
		internal static int __PropertyOffset_31;

		// Token: 0x0401177F RID: 71551
		internal static int __PropertyOffset_32;

		// Token: 0x04011780 RID: 71552
		internal static int __PropertyOffset_33;

		// Token: 0x04011781 RID: 71553
		internal static int __PropertyOffset_34;

		// Token: 0x04011782 RID: 71554
		internal static int __PropertyOffset_35;

		// Token: 0x04011783 RID: 71555
		internal static int __PropertyOffset_36;

		// Token: 0x04011784 RID: 71556
		internal static int __PropertyOffset_37;

		// Token: 0x04011785 RID: 71557
		internal static int __PropertyOffset_38;

		// Token: 0x04011786 RID: 71558
		internal static int __PropertyOffset_39;

		// Token: 0x04011787 RID: 71559
		internal static int __PropertyOffset_40;

		// Token: 0x04011788 RID: 71560
		internal static int __PropertyOffset_41;

		// Token: 0x04011789 RID: 71561
		internal static int __PropertyOffset_42;

		// Token: 0x0401178A RID: 71562
		internal static int __PropertyOffset_43;

		// Token: 0x0401178B RID: 71563
		internal static int __PropertyOffset_44;

		// Token: 0x0401178C RID: 71564
		internal static int __PropertyOffset_45;

		// Token: 0x0401178D RID: 71565
		internal static int __PropertyOffset_46;

		// Token: 0x0401178E RID: 71566
		internal static int __PropertyOffset_47;

		// Token: 0x0401178F RID: 71567
		internal static int __PropertyOffset_48;

		// Token: 0x04011790 RID: 71568
		internal static int __PropertyOffset_49;

		// Token: 0x04011791 RID: 71569
		internal static int __PropertyOffset_50;

		// Token: 0x04011792 RID: 71570
		internal static int __PropertyOffset_51;

		// Token: 0x04011793 RID: 71571
		internal static int __PropertyOffset_52;

		// Token: 0x04011794 RID: 71572
		internal static int __PropertyOffset_53;

		// Token: 0x04011795 RID: 71573
		internal static int __PropertyOffset_54;

		// Token: 0x04011796 RID: 71574
		internal static int __PropertyOffset_55;

		// Token: 0x04011797 RID: 71575
		internal static int __PropertyOffset_56;

		// Token: 0x04011798 RID: 71576
		internal static int __PropertyOffset_57;

		// Token: 0x04011799 RID: 71577
		internal static int __PropertyOffset_58;

		// Token: 0x0401179A RID: 71578
		internal static int __PropertyOffset_59;

		// Token: 0x0401179B RID: 71579
		internal static int __PropertyOffset_60;

		// Token: 0x0401179C RID: 71580
		internal static int __PropertyOffset_61;

		// Token: 0x0401179D RID: 71581
		private static IntPtr __Get_WP_SeasonPostProcess_NativeFunctionPtr;

		// Token: 0x0401179E RID: 71582
		private static IntPtr __UpdateWeatherSnow_NativeFunctionPtr;

		// Token: 0x0401179F RID: 71583
		private static IntPtr __UpdateWeatherRain_NativeFunctionPtr;

		// Token: 0x040117A0 RID: 71584
		private static IntPtr __UpdateFadeOut_NativeFunctionPtr;

		// Token: 0x040117A1 RID: 71585
		private static IntPtr __ResetAllPPV_NativeFunctionPtr;

		// Token: 0x040117A2 RID: 71586
		private static IntPtr __UpdateSeasonPPV_NativeFunctionPtr;

		// Token: 0x040117A3 RID: 71587
		private static IntPtr __CalcSeasonWeights_NativeFunctionPtr;

		// Token: 0x040117A4 RID: 71588
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040117A5 RID: 71589
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040117A6 RID: 71590
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040117A7 RID: 71591
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040117A8 RID: 71592
		private static IntPtr __BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040117A9 RID: 71593
		private static IntPtr __BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x040117AA RID: 71594
		private static IntPtr __ExecuteUbergraph_BP_SeasonPostProcessController_NativeFunctionPtr;

		// Token: 0x02009BE4 RID: 39908
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032432 RID: 205874
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BE5 RID: 39909
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032433 RID: 205875
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BE6 RID: 39910
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032434 RID: 205876
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032435 RID: 205877
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032436 RID: 205878
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032437 RID: 205879
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009BE7 RID: 39911
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_SeasonPostProcessController_PostProcessBoundCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032438 RID: 205880
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032439 RID: 205881
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403243A RID: 205882
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403243B RID: 205883
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403243C RID: 205884
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403243D RID: 205885
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009BE8 RID: 39912
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __ExecuteUbergraph_BP_SeasonPostProcessController_FunctionParams
		{
			// Token: 0x0403243E RID: 205886
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
