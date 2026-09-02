using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.Data.TOD;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.Skybox
{
	// Token: 0x02003CAD RID: 15533
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C")]
	[UnrealStructLayout(2680, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2676)]
	public class BP_SkyDome_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024A29 RID: 150057 RVA: 0x009A374C File Offset: 0x009A194C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SkyDome_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C");
			}
			return BP_SkyDome_C._ClassPtr;
		}

		// Token: 0x06024A2A RID: 150058 RVA: 0x009A3770 File Offset: 0x009A1970
		public BP_SkyDome_C() : this(BuiltinUtils.AllocNativeUObject(BP_SkyDome_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024A2B RID: 150059 RVA: 0x009A3798 File Offset: 0x009A1998
		[NullableContext(1)]
		public BP_SkyDome_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SkyDome_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004D15 RID: 19733
		// (get) Token: 0x06024A2C RID: 150060 RVA: 0x009A37CC File Offset: 0x009A19CC
		// (set) Token: 0x06024A2D RID: 150061 RVA: 0x009A3805 File Offset: 0x009A1A05
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D16 RID: 19734
		// (get) Token: 0x06024A2E RID: 150062 RVA: 0x009A3826 File Offset: 0x009A1A26
		// (set) Token: 0x06024A2F RID: 150063 RVA: 0x009A383A File Offset: 0x009A1A3A
		public unsafe UStaticMeshComponent Dummy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004D17 RID: 19735
		// (get) Token: 0x06024A30 RID: 150064 RVA: 0x009A384F File Offset: 0x009A1A4F
		// (set) Token: 0x06024A31 RID: 150065 RVA: 0x009A3863 File Offset: 0x009A1A63
		public unsafe UStaticMeshComponent SkyMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004D18 RID: 19736
		// (get) Token: 0x06024A32 RID: 150066 RVA: 0x009A3878 File Offset: 0x009A1A78
		// (set) Token: 0x06024A33 RID: 150067 RVA: 0x009A388C File Offset: 0x009A1A8C
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004D19 RID: 19737
		// (get) Token: 0x06024A34 RID: 150068 RVA: 0x009A38A1 File Offset: 0x009A1AA1
		// (set) Token: 0x06024A35 RID: 150069 RVA: 0x009A38B1 File Offset: 0x009A1AB1
		public unsafe float TimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004D1A RID: 19738
		// (get) Token: 0x06024A36 RID: 150070 RVA: 0x009A38C2 File Offset: 0x009A1AC2
		// (set) Token: 0x06024A37 RID: 150071 RVA: 0x009A38D2 File Offset: 0x009A1AD2
		public unsafe float TimeChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004D1B RID: 19739
		// (get) Token: 0x06024A38 RID: 150072 RVA: 0x009A38E3 File Offset: 0x009A1AE3
		// (set) Token: 0x06024A39 RID: 150073 RVA: 0x009A38F3 File Offset: 0x009A1AF3
		public unsafe float TimeCycleDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004D1C RID: 19740
		// (get) Token: 0x06024A3A RID: 150074 RVA: 0x009A3904 File Offset: 0x009A1B04
		// (set) Token: 0x06024A3B RID: 150075 RVA: 0x009A3914 File Offset: 0x009A1B14
		public unsafe bool UseTimeOfDayCurves
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D1D RID: 19741
		// (get) Token: 0x06024A3C RID: 150076 RVA: 0x009A3928 File Offset: 0x009A1B28
		// (set) Token: 0x06024A3D RID: 150077 RVA: 0x009A3961 File Offset: 0x009A1B61
		[Nullable(1)]
		public TimeOfDayCurves TimeOfDayCurves
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TimeOfDayCurves result;
				if ((result = this._TimeOfDayCurves) == null)
				{
					result = (this._TimeOfDayCurves = new TimeOfDayCurves(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(TimeOfDayCurves.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D1E RID: 19742
		// (get) Token: 0x06024A3E RID: 150078 RVA: 0x009A3984 File Offset: 0x009A1B84
		// (set) Token: 0x06024A3F RID: 150079 RVA: 0x009A39BD File Offset: 0x009A1BBD
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TArray<TSubclassOf<WeatherPreset_C>> WeatherPresetList
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TSubclassOf<WeatherPreset_C>> result;
				if ((result = this._WeatherPresetList) == null)
				{
					result = (this._WeatherPresetList = new TArray<TSubclassOf<WeatherPreset_C>>(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.WeatherPresetList.CopyAssign(value);
			}
		}

		// Token: 0x17004D1F RID: 19743
		// (get) Token: 0x06024A40 RID: 150080 RVA: 0x009A39CB File Offset: 0x009A1BCB
		// (set) Token: 0x06024A41 RID: 150081 RVA: 0x009A39DB File Offset: 0x009A1BDB
		public unsafe int SelectedWeatherPreset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004D20 RID: 19744
		// (get) Token: 0x06024A42 RID: 150082 RVA: 0x009A39EC File Offset: 0x009A1BEC
		// (set) Token: 0x06024A43 RID: 150083 RVA: 0x009A3A00 File Offset: 0x009A1C00
		[Nullable(0)]
		public unsafe TEnumAsByte<PresetSelection> WeatherChangeMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004D21 RID: 19745
		// (get) Token: 0x06024A44 RID: 150084 RVA: 0x009A3A15 File Offset: 0x009A1C15
		// (set) Token: 0x06024A45 RID: 150085 RVA: 0x009A3A25 File Offset: 0x009A1C25
		public unsafe float WeatherChangeDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004D22 RID: 19746
		// (get) Token: 0x06024A46 RID: 150086 RVA: 0x009A3A36 File Offset: 0x009A1C36
		// (set) Token: 0x06024A47 RID: 150087 RVA: 0x009A3A4A File Offset: 0x009A1C4A
		[Nullable(0)]
		public unsafe TEnumAsByte<EEasingFunc> WeatherChangeTransition
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004D23 RID: 19747
		// (get) Token: 0x06024A48 RID: 150088 RVA: 0x009A3A5F File Offset: 0x009A1C5F
		// (set) Token: 0x06024A49 RID: 150089 RVA: 0x009A3A6F File Offset: 0x009A1C6F
		public unsafe float WeatherChangeAfterTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004D24 RID: 19748
		// (get) Token: 0x06024A4A RID: 150090 RVA: 0x009A3A80 File Offset: 0x009A1C80
		// (set) Token: 0x06024A4B RID: 150091 RVA: 0x009A3AB9 File Offset: 0x009A1CB9
		[Nullable(1)]
		public TimeOfDayData TimeOfDaySettings
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TimeOfDayData result;
				if ((result = this._TimeOfDaySettings) == null)
				{
					result = (this._TimeOfDaySettings = new TimeOfDayData(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_15, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(TimeOfDayData.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D25 RID: 19749
		// (get) Token: 0x06024A4C RID: 150092 RVA: 0x009A3ADC File Offset: 0x009A1CDC
		// (set) Token: 0x06024A4D RID: 150093 RVA: 0x009A3B15 File Offset: 0x009A1D15
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TArray<TSubclassOf<TimeOfDayPreset_C>> TimeOfDayPresetList
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TSubclassOf<TimeOfDayPreset_C>> result;
				if ((result = this._TimeOfDayPresetList) == null)
				{
					result = (this._TimeOfDayPresetList = new TArray<TSubclassOf<TimeOfDayPreset_C>>(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.TimeOfDayPresetList.CopyAssign(value);
			}
		}

		// Token: 0x17004D26 RID: 19750
		// (get) Token: 0x06024A4E RID: 150094 RVA: 0x009A3B24 File Offset: 0x009A1D24
		// (set) Token: 0x06024A4F RID: 150095 RVA: 0x009A3B5D File Offset: 0x009A1D5D
		[Nullable(1)]
		public PresetChangeInfo TimeOfDayPresetChange
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				PresetChangeInfo result;
				if ((result = this._TimeOfDayPresetChange) == null)
				{
					result = (this._TimeOfDayPresetChange = new PresetChangeInfo(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(PresetChangeInfo.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D27 RID: 19751
		// (get) Token: 0x06024A50 RID: 150096 RVA: 0x009A3B7E File Offset: 0x009A1D7E
		// (set) Token: 0x06024A51 RID: 150097 RVA: 0x009A3B92 File Offset: 0x009A1D92
		public unsafe FRotator MoonDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004D28 RID: 19752
		// (get) Token: 0x06024A52 RID: 150098 RVA: 0x009A3BA7 File Offset: 0x009A1DA7
		// (set) Token: 0x06024A53 RID: 150099 RVA: 0x009A3BB7 File Offset: 0x009A1DB7
		public unsafe float SunHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004D29 RID: 19753
		// (get) Token: 0x06024A54 RID: 150100 RVA: 0x009A3BC8 File Offset: 0x009A1DC8
		// (set) Token: 0x06024A55 RID: 150101 RVA: 0x009A3C01 File Offset: 0x009A1E01
		[Nullable(1)]
		public WeatherData WeatherSettings
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				WeatherData result;
				if ((result = this._WeatherSettings) == null)
				{
					result = (this._WeatherSettings = new WeatherData(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(WeatherData.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D2A RID: 19754
		// (get) Token: 0x06024A56 RID: 150102 RVA: 0x009A3C22 File Offset: 0x009A1E22
		// (set) Token: 0x06024A57 RID: 150103 RVA: 0x009A3C36 File Offset: 0x009A1E36
		public unsafe UMaterialInstanceDynamic SkyMaterialInst
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004D2B RID: 19755
		// (get) Token: 0x06024A58 RID: 150104 RVA: 0x009A3C4B File Offset: 0x009A1E4B
		// (set) Token: 0x06024A59 RID: 150105 RVA: 0x009A3C5F File Offset: 0x009A1E5F
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<WeatherPreset_C> WeatherPresetTarget
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_22);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004D2C RID: 19756
		// (get) Token: 0x06024A5A RID: 150106 RVA: 0x009A3C74 File Offset: 0x009A1E74
		// (set) Token: 0x06024A5B RID: 150107 RVA: 0x009A3C84 File Offset: 0x009A1E84
		public unsafe float WeatherPresetInterp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004D2D RID: 19757
		// (get) Token: 0x06024A5C RID: 150108 RVA: 0x009A3C95 File Offset: 0x009A1E95
		// (set) Token: 0x06024A5D RID: 150109 RVA: 0x009A3CA9 File Offset: 0x009A1EA9
		public unsafe UMaterialInstanceConstant SkyMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_24);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_24, value);
			}
		}

		// Token: 0x17004D2E RID: 19758
		// (get) Token: 0x06024A5E RID: 150110 RVA: 0x009A3CBE File Offset: 0x009A1EBE
		// (set) Token: 0x06024A5F RID: 150111 RVA: 0x009A3CD2 File Offset: 0x009A1ED2
		public unsafe UMaterialInstanceConstant SkyMaterialNight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004D2F RID: 19759
		// (get) Token: 0x06024A60 RID: 150112 RVA: 0x009A3CE7 File Offset: 0x009A1EE7
		// (set) Token: 0x06024A61 RID: 150113 RVA: 0x009A3CFB File Offset: 0x009A1EFB
		public unsafe ADirectionalLight SunLightSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_26);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_26, value);
			}
		}

		// Token: 0x17004D30 RID: 19760
		// (get) Token: 0x06024A62 RID: 150114 RVA: 0x009A3D10 File Offset: 0x009A1F10
		// (set) Token: 0x06024A63 RID: 150115 RVA: 0x009A3D24 File Offset: 0x009A1F24
		public unsafe ADirectionalLight MoonLightSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17004D31 RID: 19761
		// (get) Token: 0x06024A64 RID: 150116 RVA: 0x009A3D39 File Offset: 0x009A1F39
		// (set) Token: 0x06024A65 RID: 150117 RVA: 0x009A3D4D File Offset: 0x009A1F4D
		public unsafe AExponentialHeightFog HeightFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AExponentialHeightFog>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004D32 RID: 19762
		// (get) Token: 0x06024A66 RID: 150118 RVA: 0x009A3D62 File Offset: 0x009A1F62
		// (set) Token: 0x06024A67 RID: 150119 RVA: 0x009A3D76 File Offset: 0x009A1F76
		public unsafe ASkyLight SkyLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASkyLight>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x17004D33 RID: 19763
		// (get) Token: 0x06024A68 RID: 150120 RVA: 0x009A3D8B File Offset: 0x009A1F8B
		// (set) Token: 0x06024A69 RID: 150121 RVA: 0x009A3D9B File Offset: 0x009A1F9B
		public unsafe float SkyLightRecaptureDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004D34 RID: 19764
		// (get) Token: 0x06024A6A RID: 150122 RVA: 0x009A3DAC File Offset: 0x009A1FAC
		// (set) Token: 0x06024A6B RID: 150123 RVA: 0x009A3DE5 File Offset: 0x009A1FE5
		[Nullable(1)]
		public TArray<UTextureCube> SkyLightStaticCubemaps
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UTextureCube> result;
				if ((result = this._SkyLightStaticCubemaps) == null)
				{
					result = (this._SkyLightStaticCubemaps = new TArray<UTextureCube>(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_31, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SkyLightStaticCubemaps.CopyAssign(value);
			}
		}

		// Token: 0x17004D35 RID: 19765
		// (get) Token: 0x06024A6C RID: 150124 RVA: 0x009A3DF3 File Offset: 0x009A1FF3
		// (set) Token: 0x06024A6D RID: 150125 RVA: 0x009A3E03 File Offset: 0x009A2003
		public unsafe bool SkyLightCubemapsTimeDriven
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D36 RID: 19766
		// (get) Token: 0x06024A6E RID: 150126 RVA: 0x009A3E14 File Offset: 0x009A2014
		// (set) Token: 0x06024A6F RID: 150127 RVA: 0x009A3E24 File Offset: 0x009A2024
		public unsafe float Saturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004D37 RID: 19767
		// (get) Token: 0x06024A70 RID: 150128 RVA: 0x009A3E35 File Offset: 0x009A2035
		// (set) Token: 0x06024A71 RID: 150129 RVA: 0x009A3E45 File Offset: 0x009A2045
		public unsafe float CloudsBloom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004D38 RID: 19768
		// (get) Token: 0x06024A72 RID: 150130 RVA: 0x009A3E56 File Offset: 0x009A2056
		// (set) Token: 0x06024A73 RID: 150131 RVA: 0x009A3E66 File Offset: 0x009A2066
		public unsafe float CloudsFluffy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17004D39 RID: 19769
		// (get) Token: 0x06024A74 RID: 150132 RVA: 0x009A3E77 File Offset: 0x009A2077
		// (set) Token: 0x06024A75 RID: 150133 RVA: 0x009A3E87 File Offset: 0x009A2087
		public unsafe float UVHorizonRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17004D3A RID: 19770
		// (get) Token: 0x06024A76 RID: 150134 RVA: 0x009A3E98 File Offset: 0x009A2098
		// (set) Token: 0x06024A77 RID: 150135 RVA: 0x009A3EA8 File Offset: 0x009A20A8
		public unsafe float UVHorizonMapping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004D3B RID: 19771
		// (get) Token: 0x06024A78 RID: 150136 RVA: 0x009A3EB9 File Offset: 0x009A20B9
		// (set) Token: 0x06024A79 RID: 150137 RVA: 0x009A3EC9 File Offset: 0x009A20C9
		public unsafe float UVScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004D3C RID: 19772
		// (get) Token: 0x06024A7A RID: 150138 RVA: 0x009A3EDA File Offset: 0x009A20DA
		// (set) Token: 0x06024A7B RID: 150139 RVA: 0x009A3EEA File Offset: 0x009A20EA
		public unsafe float FogDirectionalInScattering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004D3D RID: 19773
		// (get) Token: 0x06024A7C RID: 150140 RVA: 0x009A3EFB File Offset: 0x009A20FB
		// (set) Token: 0x06024A7D RID: 150141 RVA: 0x009A3F0B File Offset: 0x009A210B
		public unsafe float FogDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17004D3E RID: 19774
		// (get) Token: 0x06024A7E RID: 150142 RVA: 0x009A3F1C File Offset: 0x009A211C
		// (set) Token: 0x06024A7F RID: 150143 RVA: 0x009A3F2C File Offset: 0x009A212C
		public unsafe float HorizonTilt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17004D3F RID: 19775
		// (get) Token: 0x06024A80 RID: 150144 RVA: 0x009A3F3D File Offset: 0x009A213D
		// (set) Token: 0x06024A81 RID: 150145 RVA: 0x009A3F51 File Offset: 0x009A2151
		public unsafe FLinearColor UVBaseLayerPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004D40 RID: 19776
		// (get) Token: 0x06024A82 RID: 150146 RVA: 0x009A3F66 File Offset: 0x009A2166
		// (set) Token: 0x06024A83 RID: 150147 RVA: 0x009A3F7A File Offset: 0x009A217A
		public unsafe FLinearColor UVBaseLayerSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17004D41 RID: 19777
		// (get) Token: 0x06024A84 RID: 150148 RVA: 0x009A3F8F File Offset: 0x009A218F
		// (set) Token: 0x06024A85 RID: 150149 RVA: 0x009A3FA3 File Offset: 0x009A21A3
		public unsafe FLinearColor UVSecondLayerSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17004D42 RID: 19778
		// (get) Token: 0x06024A86 RID: 150150 RVA: 0x009A3FB8 File Offset: 0x009A21B8
		// (set) Token: 0x06024A87 RID: 150151 RVA: 0x009A3FCC File Offset: 0x009A21CC
		public unsafe FLinearColor UVSecondLayerPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17004D43 RID: 19779
		// (get) Token: 0x06024A88 RID: 150152 RVA: 0x009A3FE1 File Offset: 0x009A21E1
		// (set) Token: 0x06024A89 RID: 150153 RVA: 0x009A3FF5 File Offset: 0x009A21F5
		public unsafe UTexture CloudsLayer1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_46);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17004D44 RID: 19780
		// (get) Token: 0x06024A8A RID: 150154 RVA: 0x009A400A File Offset: 0x009A220A
		// (set) Token: 0x06024A8B RID: 150155 RVA: 0x009A401E File Offset: 0x009A221E
		public unsafe UTexture CloudsLayer2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_47);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x17004D45 RID: 19781
		// (get) Token: 0x06024A8C RID: 150156 RVA: 0x009A4033 File Offset: 0x009A2233
		// (set) Token: 0x06024A8D RID: 150157 RVA: 0x009A4047 File Offset: 0x009A2247
		public unsafe FVector2D WindForce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17004D46 RID: 19782
		// (get) Token: 0x06024A8E RID: 150158 RVA: 0x009A405C File Offset: 0x009A225C
		// (set) Token: 0x06024A8F RID: 150159 RVA: 0x009A406C File Offset: 0x009A226C
		public unsafe float SunRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17004D47 RID: 19783
		// (get) Token: 0x06024A90 RID: 150160 RVA: 0x009A407D File Offset: 0x009A227D
		// (set) Token: 0x06024A91 RID: 150161 RVA: 0x009A408D File Offset: 0x009A228D
		public unsafe float SunShine
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17004D48 RID: 19784
		// (get) Token: 0x06024A92 RID: 150162 RVA: 0x009A409E File Offset: 0x009A229E
		// (set) Token: 0x06024A93 RID: 150163 RVA: 0x009A40AE File Offset: 0x009A22AE
		public unsafe float SunSaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17004D49 RID: 19785
		// (get) Token: 0x06024A94 RID: 150164 RVA: 0x009A40BF File Offset: 0x009A22BF
		// (set) Token: 0x06024A95 RID: 150165 RVA: 0x009A40CF File Offset: 0x009A22CF
		public unsafe float SunMaxAltitude
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17004D4A RID: 19786
		// (get) Token: 0x06024A96 RID: 150166 RVA: 0x009A40E0 File Offset: 0x009A22E0
		// (set) Token: 0x06024A97 RID: 150167 RVA: 0x009A40F0 File Offset: 0x009A22F0
		public unsafe float SunAzimuth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17004D4B RID: 19787
		// (get) Token: 0x06024A98 RID: 150168 RVA: 0x009A4101 File Offset: 0x009A2301
		// (set) Token: 0x06024A99 RID: 150169 RVA: 0x009A4111 File Offset: 0x009A2311
		public unsafe float SunVisibleDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17004D4C RID: 19788
		// (get) Token: 0x06024A9A RID: 150170 RVA: 0x009A4122 File Offset: 0x009A2322
		// (set) Token: 0x06024A9B RID: 150171 RVA: 0x009A4132 File Offset: 0x009A2332
		public unsafe bool SunDirectionTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D4D RID: 19789
		// (get) Token: 0x06024A9C RID: 150172 RVA: 0x009A4143 File Offset: 0x009A2343
		// (set) Token: 0x06024A9D RID: 150173 RVA: 0x009A4157 File Offset: 0x009A2357
		public unsafe FRotator SunDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17004D4E RID: 19790
		// (get) Token: 0x06024A9E RID: 150174 RVA: 0x009A416C File Offset: 0x009A236C
		// (set) Token: 0x06024A9F RID: 150175 RVA: 0x009A417C File Offset: 0x009A237C
		public unsafe float StarsBrightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17004D4F RID: 19791
		// (get) Token: 0x06024AA0 RID: 150176 RVA: 0x009A418D File Offset: 0x009A238D
		// (set) Token: 0x06024AA1 RID: 150177 RVA: 0x009A41A1 File Offset: 0x009A23A1
		public unsafe UTexture MoonTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_58);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_58, value);
			}
		}

		// Token: 0x17004D50 RID: 19792
		// (get) Token: 0x06024AA2 RID: 150178 RVA: 0x009A41B6 File Offset: 0x009A23B6
		// (set) Token: 0x06024AA3 RID: 150179 RVA: 0x009A41C6 File Offset: 0x009A23C6
		public unsafe float MoonBightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x17004D51 RID: 19793
		// (get) Token: 0x06024AA4 RID: 150180 RVA: 0x009A41D7 File Offset: 0x009A23D7
		// (set) Token: 0x06024AA5 RID: 150181 RVA: 0x009A41E7 File Offset: 0x009A23E7
		public unsafe float MoonRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17004D52 RID: 19794
		// (get) Token: 0x06024AA6 RID: 150182 RVA: 0x009A41F8 File Offset: 0x009A23F8
		// (set) Token: 0x06024AA7 RID: 150183 RVA: 0x009A4208 File Offset: 0x009A2408
		public unsafe float MoonClouds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17004D53 RID: 19795
		// (get) Token: 0x06024AA8 RID: 150184 RVA: 0x009A4219 File Offset: 0x009A2419
		// (set) Token: 0x06024AA9 RID: 150185 RVA: 0x009A4229 File Offset: 0x009A2429
		public unsafe float MoonShine
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x17004D54 RID: 19796
		// (get) Token: 0x06024AAA RID: 150186 RVA: 0x009A423A File Offset: 0x009A243A
		// (set) Token: 0x06024AAB RID: 150187 RVA: 0x009A424A File Offset: 0x009A244A
		public unsafe float MoonRoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x17004D55 RID: 19797
		// (get) Token: 0x06024AAC RID: 150188 RVA: 0x009A425B File Offset: 0x009A245B
		// (set) Token: 0x06024AAD RID: 150189 RVA: 0x009A426B File Offset: 0x009A246B
		public unsafe float MoonVisibleDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17004D56 RID: 19798
		// (get) Token: 0x06024AAE RID: 150190 RVA: 0x009A427C File Offset: 0x009A247C
		// (set) Token: 0x06024AAF RID: 150191 RVA: 0x009A428C File Offset: 0x009A248C
		public unsafe bool MoonSyncedToSun
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_65) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_65) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D57 RID: 19799
		// (get) Token: 0x06024AB0 RID: 150192 RVA: 0x009A429D File Offset: 0x009A249D
		// (set) Token: 0x06024AB1 RID: 150193 RVA: 0x009A42B1 File Offset: 0x009A24B1
		public unsafe FRotator MoonRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17004D58 RID: 19800
		// (get) Token: 0x06024AB2 RID: 150194 RVA: 0x009A42C8 File Offset: 0x009A24C8
		// (set) Token: 0x06024AB3 RID: 150195 RVA: 0x009A4301 File Offset: 0x009A2501
		[Nullable(1)]
		public WeatherData WeatherFrom
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				WeatherData result;
				if ((result = this._WeatherFrom) == null)
				{
					result = (this._WeatherFrom = new WeatherData(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_67, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(WeatherData.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D59 RID: 19801
		// (get) Token: 0x06024AB4 RID: 150196 RVA: 0x009A4324 File Offset: 0x009A2524
		// (set) Token: 0x06024AB5 RID: 150197 RVA: 0x009A435D File Offset: 0x009A255D
		[Nullable(1)]
		public WeatherData WeatherTo
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				WeatherData result;
				if ((result = this._WeatherTo) == null)
				{
					result = (this._WeatherTo = new WeatherData(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_68, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(WeatherData.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D5A RID: 19802
		// (get) Token: 0x06024AB6 RID: 150198 RVA: 0x009A437E File Offset: 0x009A257E
		// (set) Token: 0x06024AB7 RID: 150199 RVA: 0x009A4392 File Offset: 0x009A2592
		public unsafe FRotator MoonChangeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17004D5B RID: 19803
		// (get) Token: 0x06024AB8 RID: 150200 RVA: 0x009A43A7 File Offset: 0x009A25A7
		// (set) Token: 0x06024AB9 RID: 150201 RVA: 0x009A43B7 File Offset: 0x009A25B7
		public unsafe float WorldRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17004D5C RID: 19804
		// (get) Token: 0x06024ABA RID: 150202 RVA: 0x009A43C8 File Offset: 0x009A25C8
		// (set) Token: 0x06024ABB RID: 150203 RVA: 0x009A43D8 File Offset: 0x009A25D8
		public unsafe float WorldRotationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17004D5D RID: 19805
		// (get) Token: 0x06024ABC RID: 150204 RVA: 0x009A43E9 File Offset: 0x009A25E9
		// (set) Token: 0x06024ABD RID: 150205 RVA: 0x009A43FD File Offset: 0x009A25FD
		public unsafe UTexture WorldLayerTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_72);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_72, value);
			}
		}

		// Token: 0x17004D5E RID: 19806
		// (get) Token: 0x06024ABE RID: 150206 RVA: 0x009A4412 File Offset: 0x009A2612
		// (set) Token: 0x06024ABF RID: 150207 RVA: 0x009A4422 File Offset: 0x009A2622
		public unsafe float WorldLayerFog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x17004D5F RID: 19807
		// (get) Token: 0x06024AC0 RID: 150208 RVA: 0x009A4433 File Offset: 0x009A2633
		// (set) Token: 0x06024AC1 RID: 150209 RVA: 0x009A4443 File Offset: 0x009A2643
		public unsafe float WorldLayerDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x17004D60 RID: 19808
		// (get) Token: 0x06024AC2 RID: 150210 RVA: 0x009A4454 File Offset: 0x009A2654
		// (set) Token: 0x06024AC3 RID: 150211 RVA: 0x009A4468 File Offset: 0x009A2668
		public unsafe FLinearColor WorldLayerColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17004D61 RID: 19809
		// (get) Token: 0x06024AC4 RID: 150212 RVA: 0x009A447D File Offset: 0x009A267D
		// (set) Token: 0x06024AC5 RID: 150213 RVA: 0x009A448D File Offset: 0x009A268D
		public unsafe float SkyLightRecaptureTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17004D62 RID: 19810
		// (get) Token: 0x06024AC6 RID: 150214 RVA: 0x009A449E File Offset: 0x009A269E
		// (set) Token: 0x06024AC7 RID: 150215 RVA: 0x009A44AE File Offset: 0x009A26AE
		public unsafe float TimeOfDayFrom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17004D63 RID: 19811
		// (get) Token: 0x06024AC8 RID: 150216 RVA: 0x009A44BF File Offset: 0x009A26BF
		// (set) Token: 0x06024AC9 RID: 150217 RVA: 0x009A44CF File Offset: 0x009A26CF
		public unsafe float TimeOfDayTo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x17004D64 RID: 19812
		// (get) Token: 0x06024ACA RID: 150218 RVA: 0x009A44E0 File Offset: 0x009A26E0
		// (set) Token: 0x06024ACB RID: 150219 RVA: 0x009A44F0 File Offset: 0x009A26F0
		public unsafe float TimeOfDayTransitionDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_79);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_79) = value;
			}
		}

		// Token: 0x17004D65 RID: 19813
		// (get) Token: 0x06024ACC RID: 150220 RVA: 0x009A4501 File Offset: 0x009A2701
		// (set) Token: 0x06024ACD RID: 150221 RVA: 0x009A4515 File Offset: 0x009A2715
		[Nullable(0)]
		public unsafe TEnumAsByte<EEasingFunc> TimeOfDayTransition
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_80);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_80) = value;
			}
		}

		// Token: 0x17004D66 RID: 19814
		// (get) Token: 0x06024ACE RID: 150222 RVA: 0x009A452A File Offset: 0x009A272A
		// (set) Token: 0x06024ACF RID: 150223 RVA: 0x009A453A File Offset: 0x009A273A
		public unsafe float TimeOfDayInterp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_81);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x17004D67 RID: 19815
		// (get) Token: 0x06024AD0 RID: 150224 RVA: 0x009A454B File Offset: 0x009A274B
		// (set) Token: 0x06024AD1 RID: 150225 RVA: 0x009A455F File Offset: 0x009A275F
		public unsafe UMaterialInstanceConstant GroundShadowMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_82);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_82, value);
			}
		}

		// Token: 0x17004D68 RID: 19816
		// (get) Token: 0x06024AD2 RID: 150226 RVA: 0x009A4574 File Offset: 0x009A2774
		// (set) Token: 0x06024AD3 RID: 150227 RVA: 0x009A4588 File Offset: 0x009A2788
		public unsafe UMaterialInstanceDynamic GroundShadowMaterialInst
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_83);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkyDome_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17004D69 RID: 19817
		// (get) Token: 0x06024AD4 RID: 150228 RVA: 0x009A459D File Offset: 0x009A279D
		// (set) Token: 0x06024AD5 RID: 150229 RVA: 0x009A45AD File Offset: 0x009A27AD
		public unsafe float GroundShadowScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17004D6A RID: 19818
		// (get) Token: 0x06024AD6 RID: 150230 RVA: 0x009A45BE File Offset: 0x009A27BE
		// (set) Token: 0x06024AD7 RID: 150231 RVA: 0x009A45CE File Offset: 0x009A27CE
		public unsafe float GroundShadowSoft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17004D6B RID: 19819
		// (get) Token: 0x06024AD8 RID: 150232 RVA: 0x009A45DF File Offset: 0x009A27DF
		// (set) Token: 0x06024AD9 RID: 150233 RVA: 0x009A45EF File Offset: 0x009A27EF
		public unsafe int Version
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_86);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_86) = value;
			}
		}

		// Token: 0x17004D6C RID: 19820
		// (get) Token: 0x06024ADA RID: 150234 RVA: 0x009A4600 File Offset: 0x009A2800
		// (set) Token: 0x06024ADB RID: 150235 RVA: 0x009A4639 File Offset: 0x009A2839
		[Nullable(1)]
		public TimeOfDayData TimeOfDayDataFrom
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TimeOfDayData result;
				if ((result = this._TimeOfDayDataFrom) == null)
				{
					result = (this._TimeOfDayDataFrom = new TimeOfDayData(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_87, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(TimeOfDayData.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D6D RID: 19821
		// (get) Token: 0x06024ADC RID: 150236 RVA: 0x009A465C File Offset: 0x009A285C
		// (set) Token: 0x06024ADD RID: 150237 RVA: 0x009A4695 File Offset: 0x009A2895
		[Nullable(1)]
		public TimeOfDayData TimeOfDayDataTo
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TimeOfDayData result;
				if ((result = this._TimeOfDayDataTo) == null)
				{
					result = (this._TimeOfDayDataTo = new TimeOfDayData(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_88, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(TimeOfDayData.StaticStruct(), base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004D6E RID: 19822
		// (get) Token: 0x06024ADE RID: 150238 RVA: 0x009A46B6 File Offset: 0x009A28B6
		// (set) Token: 0x06024ADF RID: 150239 RVA: 0x009A46C6 File Offset: 0x009A28C6
		public unsafe float TimeOfDayPresetInterp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x17004D6F RID: 19823
		// (get) Token: 0x06024AE0 RID: 150240 RVA: 0x009A46D7 File Offset: 0x009A28D7
		// (set) Token: 0x06024AE1 RID: 150241 RVA: 0x009A46EB File Offset: 0x009A28EB
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<TimeOfDayPreset_C> TimeOfDayPresetTarget
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_90);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x17004D70 RID: 19824
		// (get) Token: 0x06024AE2 RID: 150242 RVA: 0x009A4700 File Offset: 0x009A2900
		// (set) Token: 0x06024AE3 RID: 150243 RVA: 0x009A4710 File Offset: 0x009A2910
		public unsafe float SkyLightIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_91);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_91) = value;
			}
		}

		// Token: 0x17004D71 RID: 19825
		// (get) Token: 0x06024AE4 RID: 150244 RVA: 0x009A4721 File Offset: 0x009A2921
		// (set) Token: 0x06024AE5 RID: 150245 RVA: 0x009A4731 File Offset: 0x009A2931
		public unsafe float SkyLightLightning
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x17004D72 RID: 19826
		// (get) Token: 0x06024AE6 RID: 150246 RVA: 0x009A4742 File Offset: 0x009A2942
		// (set) Token: 0x06024AE7 RID: 150247 RVA: 0x009A4752 File Offset: 0x009A2952
		public unsafe bool UseWorldSpaceRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_93) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_93) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D73 RID: 19827
		// (get) Token: 0x06024AE8 RID: 150248 RVA: 0x009A4763 File Offset: 0x009A2963
		// (set) Token: 0x06024AE9 RID: 150249 RVA: 0x009A4773 File Offset: 0x009A2973
		public unsafe int DaysPassedBy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17004D74 RID: 19828
		// (get) Token: 0x06024AEA RID: 150250 RVA: 0x009A4784 File Offset: 0x009A2984
		// (set) Token: 0x06024AEB RID: 150251 RVA: 0x009A47BD File Offset: 0x009A29BD
		[Nullable(1)]
		public OnWeatherPresetChanged OnWeatherPresetChanged
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnWeatherPresetChanged result;
				if ((result = this._OnWeatherPresetChanged) == null)
				{
					result = (this._OnWeatherPresetChanged = new OnWeatherPresetChanged(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_95, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_95, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17004D75 RID: 19829
		// (get) Token: 0x06024AEC RID: 150252 RVA: 0x009A47E0 File Offset: 0x009A29E0
		// (set) Token: 0x06024AED RID: 150253 RVA: 0x009A4819 File Offset: 0x009A2A19
		[Nullable(1)]
		public OnTimeOfDayPresetChanged OnTimeOfDayPresetChanged
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnTimeOfDayPresetChanged result;
				if ((result = this._OnTimeOfDayPresetChanged) == null)
				{
					result = (this._OnTimeOfDayPresetChanged = new OnTimeOfDayPresetChanged(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_96, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_96, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17004D76 RID: 19830
		// (get) Token: 0x06024AEE RID: 150254 RVA: 0x009A483C File Offset: 0x009A2A3C
		// (set) Token: 0x06024AEF RID: 150255 RVA: 0x009A4875 File Offset: 0x009A2A75
		[Nullable(1)]
		public OnHourPassedBy OnHourPassedBy
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnHourPassedBy result;
				if ((result = this._OnHourPassedBy) == null)
				{
					result = (this._OnHourPassedBy = new OnHourPassedBy(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_97, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_97, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17004D77 RID: 19831
		// (get) Token: 0x06024AF0 RID: 150256 RVA: 0x009A4898 File Offset: 0x009A2A98
		// (set) Token: 0x06024AF1 RID: 150257 RVA: 0x009A48D1 File Offset: 0x009A2AD1
		[Nullable(1)]
		public OnDayPassedBy OnDayPassedBy
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				OnDayPassedBy result;
				if ((result = this._OnDayPassedBy) == null)
				{
					result = (this._OnDayPassedBy = new OnDayPassedBy(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_98, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_98, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17004D78 RID: 19832
		// (get) Token: 0x06024AF2 RID: 150258 RVA: 0x009A48F2 File Offset: 0x009A2AF2
		// (set) Token: 0x06024AF3 RID: 150259 RVA: 0x009A4902 File Offset: 0x009A2B02
		public unsafe float MoonLightLightning
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_99);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_99) = value;
			}
		}

		// Token: 0x17004D79 RID: 19833
		// (get) Token: 0x06024AF4 RID: 150260 RVA: 0x009A4913 File Offset: 0x009A2B13
		// (set) Token: 0x06024AF5 RID: 150261 RVA: 0x009A4923 File Offset: 0x009A2B23
		public unsafe float ColorScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17004D7A RID: 19834
		// (get) Token: 0x06024AF6 RID: 150262 RVA: 0x009A4934 File Offset: 0x009A2B34
		// (set) Token: 0x06024AF7 RID: 150263 RVA: 0x009A4944 File Offset: 0x009A2B44
		public unsafe int EngineVersion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17004D7B RID: 19835
		// (get) Token: 0x06024AF8 RID: 150264 RVA: 0x009A4955 File Offset: 0x009A2B55
		// (set) Token: 0x06024AF9 RID: 150265 RVA: 0x009A4965 File Offset: 0x009A2B65
		public unsafe float Curr_Time_Of_Day
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17004D7C RID: 19836
		// (get) Token: 0x06024AFA RID: 150266 RVA: 0x009A4976 File Offset: 0x009A2B76
		// (set) Token: 0x06024AFB RID: 150267 RVA: 0x009A4986 File Offset: 0x009A2B86
		public unsafe float BlueSaturation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17004D7D RID: 19837
		// (get) Token: 0x06024AFC RID: 150268 RVA: 0x009A4997 File Offset: 0x009A2B97
		// (set) Token: 0x06024AFD RID: 150269 RVA: 0x009A49A7 File Offset: 0x009A2BA7
		public unsafe float SkyShineScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17004D7E RID: 19838
		// (get) Token: 0x06024AFE RID: 150270 RVA: 0x009A49B8 File Offset: 0x009A2BB8
		// (set) Token: 0x06024AFF RID: 150271 RVA: 0x009A49C8 File Offset: 0x009A2BC8
		public unsafe float Total_TODTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_105);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_105) = value;
			}
		}

		// Token: 0x17004D7F RID: 19839
		// (get) Token: 0x06024B00 RID: 150272 RVA: 0x009A49D9 File Offset: 0x009A2BD9
		// (set) Token: 0x06024B01 RID: 150273 RVA: 0x009A49E9 File Offset: 0x009A2BE9
		public unsafe bool CloudsMoveWithTOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_106) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_106) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D80 RID: 19840
		// (get) Token: 0x06024B02 RID: 150274 RVA: 0x009A49FA File Offset: 0x009A2BFA
		// (set) Token: 0x06024B03 RID: 150275 RVA: 0x009A4A0A File Offset: 0x009A2C0A
		public unsafe float CloudsTODTimeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_107);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_107) = value;
			}
		}

		// Token: 0x17004D81 RID: 19841
		// (get) Token: 0x06024B04 RID: 150276 RVA: 0x009A4A1B File Offset: 0x009A2C1B
		// (set) Token: 0x06024B05 RID: 150277 RVA: 0x009A4A2B File Offset: 0x009A2C2B
		public unsafe float Layer1Phase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_108);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_108) = value;
			}
		}

		// Token: 0x17004D82 RID: 19842
		// (get) Token: 0x06024B06 RID: 150278 RVA: 0x009A4A3C File Offset: 0x009A2C3C
		// (set) Token: 0x06024B07 RID: 150279 RVA: 0x009A4A4C File Offset: 0x009A2C4C
		public unsafe float Layer2Phase
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_109);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_109) = value;
			}
		}

		// Token: 0x17004D83 RID: 19843
		// (get) Token: 0x06024B08 RID: 150280 RVA: 0x009A4A5D File Offset: 0x009A2C5D
		// (set) Token: 0x06024B09 RID: 150281 RVA: 0x009A4A6D File Offset: 0x009A2C6D
		public unsafe float MoonFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_110);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_110) = value;
			}
		}

		// Token: 0x17004D84 RID: 19844
		// (get) Token: 0x06024B0A RID: 150282 RVA: 0x009A4A7E File Offset: 0x009A2C7E
		// (set) Token: 0x06024B0B RID: 150283 RVA: 0x009A4A8E File Offset: 0x009A2C8E
		public unsafe float CloudsBlendScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_111);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_111) = value;
			}
		}

		// Token: 0x17004D85 RID: 19845
		// (get) Token: 0x06024B0C RID: 150284 RVA: 0x009A4A9F File Offset: 0x009A2C9F
		// (set) Token: 0x06024B0D RID: 150285 RVA: 0x009A4AAF File Offset: 0x009A2CAF
		public unsafe float SunHardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_112);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_112) = value;
			}
		}

		// Token: 0x17004D86 RID: 19846
		// (get) Token: 0x06024B0E RID: 150286 RVA: 0x009A4AC0 File Offset: 0x009A2CC0
		// (set) Token: 0x06024B0F RID: 150287 RVA: 0x009A4AD0 File Offset: 0x009A2CD0
		public unsafe float SkyLowerFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_113);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_113) = value;
			}
		}

		// Token: 0x17004D87 RID: 19847
		// (get) Token: 0x06024B10 RID: 150288 RVA: 0x009A4AE1 File Offset: 0x009A2CE1
		// (set) Token: 0x06024B11 RID: 150289 RVA: 0x009A4AF1 File Offset: 0x009A2CF1
		public unsafe float EclipseLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_114);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_114) = value;
			}
		}

		// Token: 0x17004D88 RID: 19848
		// (get) Token: 0x06024B12 RID: 150290 RVA: 0x009A4B02 File Offset: 0x009A2D02
		// (set) Token: 0x06024B13 RID: 150291 RVA: 0x009A4B12 File Offset: 0x009A2D12
		public unsafe float EclipseOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_115);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_115) = value;
			}
		}

		// Token: 0x17004D89 RID: 19849
		// (get) Token: 0x06024B14 RID: 150292 RVA: 0x009A4B23 File Offset: 0x009A2D23
		// (set) Token: 0x06024B15 RID: 150293 RVA: 0x009A4B33 File Offset: 0x009A2D33
		public unsafe float EclipseAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x17004D8A RID: 19850
		// (get) Token: 0x06024B16 RID: 150294 RVA: 0x009A4B44 File Offset: 0x009A2D44
		// (set) Token: 0x06024B17 RID: 150295 RVA: 0x009A4B54 File Offset: 0x009A2D54
		public unsafe float EclipseHardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_117);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_117) = value;
			}
		}

		// Token: 0x17004D8B RID: 19851
		// (get) Token: 0x06024B18 RID: 150296 RVA: 0x009A4B65 File Offset: 0x009A2D65
		// (set) Token: 0x06024B19 RID: 150297 RVA: 0x009A4B75 File Offset: 0x009A2D75
		public unsafe bool bUseNightMtl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_118) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_118) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004D8C RID: 19852
		// (get) Token: 0x06024B1A RID: 150298 RVA: 0x009A4B86 File Offset: 0x009A2D86
		// (set) Token: 0x06024B1B RID: 150299 RVA: 0x009A4B96 File Offset: 0x009A2D96
		public unsafe float UseFlowmapSkybox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_119);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkyDome_C.__PropertyOffset_119) = value;
			}
		}

		// Token: 0x06024B1C RID: 150300 RVA: 0x009A4BA8 File Offset: 0x009A2DA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SkyDome(int EntryPoint)
		{
			BP_SkyDome_C.__ExecuteUbergraph_BP_SkyDome_FunctionParams* ptr = stackalloc BP_SkyDome_C.__ExecuteUbergraph_BP_SkyDome_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SkyDome_C.__ExecuteUbergraph_BP_SkyDome_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SkyDome_C.__ExecuteUbergraph_BP_SkyDome_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SkyDome_C.__ExecuteUbergraph_BP_SkyDome_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024B1D RID: 150301 RVA: 0x009A4BEF File Offset: 0x009A2DEF
		protected BP_SkyDome_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C93 RID: 76947
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/Skybox/BP_SkyDome.BP_SkyDome_C";

		// Token: 0x04012C94 RID: 76948
		private static IntPtr _ClassPtr;

		// Token: 0x04012C95 RID: 76949
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C96 RID: 76950
		public static IntPtr __OnDayPassedBy__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C97 RID: 76951
		public static IntPtr __OnHourPassedBy__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C98 RID: 76952
		public static IntPtr __OnTimeOfDayPresetChanged__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C99 RID: 76953
		public static IntPtr __OnWeatherPresetChanged__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012C9A RID: 76954
		internal static int __PropertyOffset_0;

		// Token: 0x04012C9B RID: 76955
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012C9C RID: 76956
		internal static int __PropertyOffset_1;

		// Token: 0x04012C9D RID: 76957
		internal static int __PropertyOffset_2;

		// Token: 0x04012C9E RID: 76958
		internal static int __PropertyOffset_3;

		// Token: 0x04012C9F RID: 76959
		internal static int __PropertyOffset_4;

		// Token: 0x04012CA0 RID: 76960
		internal static int __PropertyOffset_5;

		// Token: 0x04012CA1 RID: 76961
		internal static int __PropertyOffset_6;

		// Token: 0x04012CA2 RID: 76962
		internal static int __PropertyOffset_7;

		// Token: 0x04012CA3 RID: 76963
		internal static int __PropertyOffset_8;

		// Token: 0x04012CA4 RID: 76964
		private TimeOfDayCurves _TimeOfDayCurves;

		// Token: 0x04012CA5 RID: 76965
		internal static int __PropertyOffset_9;

		// Token: 0x04012CA6 RID: 76966
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TArray<TSubclassOf<WeatherPreset_C>> _WeatherPresetList;

		// Token: 0x04012CA7 RID: 76967
		internal static int __PropertyOffset_10;

		// Token: 0x04012CA8 RID: 76968
		internal static int __PropertyOffset_11;

		// Token: 0x04012CA9 RID: 76969
		internal static int __PropertyOffset_12;

		// Token: 0x04012CAA RID: 76970
		internal static int __PropertyOffset_13;

		// Token: 0x04012CAB RID: 76971
		internal static int __PropertyOffset_14;

		// Token: 0x04012CAC RID: 76972
		internal static int __PropertyOffset_15;

		// Token: 0x04012CAD RID: 76973
		private TimeOfDayData _TimeOfDaySettings;

		// Token: 0x04012CAE RID: 76974
		internal static int __PropertyOffset_16;

		// Token: 0x04012CAF RID: 76975
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TArray<TSubclassOf<TimeOfDayPreset_C>> _TimeOfDayPresetList;

		// Token: 0x04012CB0 RID: 76976
		internal static int __PropertyOffset_17;

		// Token: 0x04012CB1 RID: 76977
		private PresetChangeInfo _TimeOfDayPresetChange;

		// Token: 0x04012CB2 RID: 76978
		internal static int __PropertyOffset_18;

		// Token: 0x04012CB3 RID: 76979
		internal static int __PropertyOffset_19;

		// Token: 0x04012CB4 RID: 76980
		internal static int __PropertyOffset_20;

		// Token: 0x04012CB5 RID: 76981
		private WeatherData _WeatherSettings;

		// Token: 0x04012CB6 RID: 76982
		internal static int __PropertyOffset_21;

		// Token: 0x04012CB7 RID: 76983
		internal static int __PropertyOffset_22;

		// Token: 0x04012CB8 RID: 76984
		internal static int __PropertyOffset_23;

		// Token: 0x04012CB9 RID: 76985
		internal static int __PropertyOffset_24;

		// Token: 0x04012CBA RID: 76986
		internal static int __PropertyOffset_25;

		// Token: 0x04012CBB RID: 76987
		internal static int __PropertyOffset_26;

		// Token: 0x04012CBC RID: 76988
		internal static int __PropertyOffset_27;

		// Token: 0x04012CBD RID: 76989
		internal static int __PropertyOffset_28;

		// Token: 0x04012CBE RID: 76990
		internal static int __PropertyOffset_29;

		// Token: 0x04012CBF RID: 76991
		internal static int __PropertyOffset_30;

		// Token: 0x04012CC0 RID: 76992
		internal static int __PropertyOffset_31;

		// Token: 0x04012CC1 RID: 76993
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UTextureCube> _SkyLightStaticCubemaps;

		// Token: 0x04012CC2 RID: 76994
		internal static int __PropertyOffset_32;

		// Token: 0x04012CC3 RID: 76995
		internal static int __PropertyOffset_33;

		// Token: 0x04012CC4 RID: 76996
		internal static int __PropertyOffset_34;

		// Token: 0x04012CC5 RID: 76997
		internal static int __PropertyOffset_35;

		// Token: 0x04012CC6 RID: 76998
		internal static int __PropertyOffset_36;

		// Token: 0x04012CC7 RID: 76999
		internal static int __PropertyOffset_37;

		// Token: 0x04012CC8 RID: 77000
		internal static int __PropertyOffset_38;

		// Token: 0x04012CC9 RID: 77001
		internal static int __PropertyOffset_39;

		// Token: 0x04012CCA RID: 77002
		internal static int __PropertyOffset_40;

		// Token: 0x04012CCB RID: 77003
		internal static int __PropertyOffset_41;

		// Token: 0x04012CCC RID: 77004
		internal static int __PropertyOffset_42;

		// Token: 0x04012CCD RID: 77005
		internal static int __PropertyOffset_43;

		// Token: 0x04012CCE RID: 77006
		internal static int __PropertyOffset_44;

		// Token: 0x04012CCF RID: 77007
		internal static int __PropertyOffset_45;

		// Token: 0x04012CD0 RID: 77008
		internal static int __PropertyOffset_46;

		// Token: 0x04012CD1 RID: 77009
		internal static int __PropertyOffset_47;

		// Token: 0x04012CD2 RID: 77010
		internal static int __PropertyOffset_48;

		// Token: 0x04012CD3 RID: 77011
		internal static int __PropertyOffset_49;

		// Token: 0x04012CD4 RID: 77012
		internal static int __PropertyOffset_50;

		// Token: 0x04012CD5 RID: 77013
		internal static int __PropertyOffset_51;

		// Token: 0x04012CD6 RID: 77014
		internal static int __PropertyOffset_52;

		// Token: 0x04012CD7 RID: 77015
		internal static int __PropertyOffset_53;

		// Token: 0x04012CD8 RID: 77016
		internal static int __PropertyOffset_54;

		// Token: 0x04012CD9 RID: 77017
		internal static int __PropertyOffset_55;

		// Token: 0x04012CDA RID: 77018
		internal static int __PropertyOffset_56;

		// Token: 0x04012CDB RID: 77019
		internal static int __PropertyOffset_57;

		// Token: 0x04012CDC RID: 77020
		internal static int __PropertyOffset_58;

		// Token: 0x04012CDD RID: 77021
		internal static int __PropertyOffset_59;

		// Token: 0x04012CDE RID: 77022
		internal static int __PropertyOffset_60;

		// Token: 0x04012CDF RID: 77023
		internal static int __PropertyOffset_61;

		// Token: 0x04012CE0 RID: 77024
		internal static int __PropertyOffset_62;

		// Token: 0x04012CE1 RID: 77025
		internal static int __PropertyOffset_63;

		// Token: 0x04012CE2 RID: 77026
		internal static int __PropertyOffset_64;

		// Token: 0x04012CE3 RID: 77027
		internal static int __PropertyOffset_65;

		// Token: 0x04012CE4 RID: 77028
		internal static int __PropertyOffset_66;

		// Token: 0x04012CE5 RID: 77029
		internal static int __PropertyOffset_67;

		// Token: 0x04012CE6 RID: 77030
		private WeatherData _WeatherFrom;

		// Token: 0x04012CE7 RID: 77031
		internal static int __PropertyOffset_68;

		// Token: 0x04012CE8 RID: 77032
		private WeatherData _WeatherTo;

		// Token: 0x04012CE9 RID: 77033
		internal static int __PropertyOffset_69;

		// Token: 0x04012CEA RID: 77034
		internal static int __PropertyOffset_70;

		// Token: 0x04012CEB RID: 77035
		internal static int __PropertyOffset_71;

		// Token: 0x04012CEC RID: 77036
		internal static int __PropertyOffset_72;

		// Token: 0x04012CED RID: 77037
		internal static int __PropertyOffset_73;

		// Token: 0x04012CEE RID: 77038
		internal static int __PropertyOffset_74;

		// Token: 0x04012CEF RID: 77039
		internal static int __PropertyOffset_75;

		// Token: 0x04012CF0 RID: 77040
		internal static int __PropertyOffset_76;

		// Token: 0x04012CF1 RID: 77041
		internal static int __PropertyOffset_77;

		// Token: 0x04012CF2 RID: 77042
		internal static int __PropertyOffset_78;

		// Token: 0x04012CF3 RID: 77043
		internal static int __PropertyOffset_79;

		// Token: 0x04012CF4 RID: 77044
		internal static int __PropertyOffset_80;

		// Token: 0x04012CF5 RID: 77045
		internal static int __PropertyOffset_81;

		// Token: 0x04012CF6 RID: 77046
		internal static int __PropertyOffset_82;

		// Token: 0x04012CF7 RID: 77047
		internal static int __PropertyOffset_83;

		// Token: 0x04012CF8 RID: 77048
		internal static int __PropertyOffset_84;

		// Token: 0x04012CF9 RID: 77049
		internal static int __PropertyOffset_85;

		// Token: 0x04012CFA RID: 77050
		internal static int __PropertyOffset_86;

		// Token: 0x04012CFB RID: 77051
		internal static int __PropertyOffset_87;

		// Token: 0x04012CFC RID: 77052
		private TimeOfDayData _TimeOfDayDataFrom;

		// Token: 0x04012CFD RID: 77053
		internal static int __PropertyOffset_88;

		// Token: 0x04012CFE RID: 77054
		private TimeOfDayData _TimeOfDayDataTo;

		// Token: 0x04012CFF RID: 77055
		internal static int __PropertyOffset_89;

		// Token: 0x04012D00 RID: 77056
		internal static int __PropertyOffset_90;

		// Token: 0x04012D01 RID: 77057
		internal static int __PropertyOffset_91;

		// Token: 0x04012D02 RID: 77058
		internal static int __PropertyOffset_92;

		// Token: 0x04012D03 RID: 77059
		internal static int __PropertyOffset_93;

		// Token: 0x04012D04 RID: 77060
		internal static int __PropertyOffset_94;

		// Token: 0x04012D05 RID: 77061
		internal static int __PropertyOffset_95;

		// Token: 0x04012D06 RID: 77062
		private OnWeatherPresetChanged _OnWeatherPresetChanged;

		// Token: 0x04012D07 RID: 77063
		internal static int __PropertyOffset_96;

		// Token: 0x04012D08 RID: 77064
		private OnTimeOfDayPresetChanged _OnTimeOfDayPresetChanged;

		// Token: 0x04012D09 RID: 77065
		internal static int __PropertyOffset_97;

		// Token: 0x04012D0A RID: 77066
		private OnHourPassedBy _OnHourPassedBy;

		// Token: 0x04012D0B RID: 77067
		internal static int __PropertyOffset_98;

		// Token: 0x04012D0C RID: 77068
		private OnDayPassedBy _OnDayPassedBy;

		// Token: 0x04012D0D RID: 77069
		internal static int __PropertyOffset_99;

		// Token: 0x04012D0E RID: 77070
		internal static int __PropertyOffset_100;

		// Token: 0x04012D0F RID: 77071
		internal static int __PropertyOffset_101;

		// Token: 0x04012D10 RID: 77072
		internal static int __PropertyOffset_102;

		// Token: 0x04012D11 RID: 77073
		internal static int __PropertyOffset_103;

		// Token: 0x04012D12 RID: 77074
		internal static int __PropertyOffset_104;

		// Token: 0x04012D13 RID: 77075
		internal static int __PropertyOffset_105;

		// Token: 0x04012D14 RID: 77076
		internal static int __PropertyOffset_106;

		// Token: 0x04012D15 RID: 77077
		internal static int __PropertyOffset_107;

		// Token: 0x04012D16 RID: 77078
		internal static int __PropertyOffset_108;

		// Token: 0x04012D17 RID: 77079
		internal static int __PropertyOffset_109;

		// Token: 0x04012D18 RID: 77080
		internal static int __PropertyOffset_110;

		// Token: 0x04012D19 RID: 77081
		internal static int __PropertyOffset_111;

		// Token: 0x04012D1A RID: 77082
		internal static int __PropertyOffset_112;

		// Token: 0x04012D1B RID: 77083
		internal static int __PropertyOffset_113;

		// Token: 0x04012D1C RID: 77084
		internal static int __PropertyOffset_114;

		// Token: 0x04012D1D RID: 77085
		internal static int __PropertyOffset_115;

		// Token: 0x04012D1E RID: 77086
		internal static int __PropertyOffset_116;

		// Token: 0x04012D1F RID: 77087
		internal static int __PropertyOffset_117;

		// Token: 0x04012D20 RID: 77088
		internal static int __PropertyOffset_118;

		// Token: 0x04012D21 RID: 77089
		internal static int __PropertyOffset_119;

		// Token: 0x04012D22 RID: 77090
		private static IntPtr __ExecuteUbergraph_BP_SkyDome_NativeFunctionPtr;

		// Token: 0x02009E2B RID: 40491
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_SkyDome_FunctionParams
		{
			// Token: 0x0403287E RID: 206974
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
