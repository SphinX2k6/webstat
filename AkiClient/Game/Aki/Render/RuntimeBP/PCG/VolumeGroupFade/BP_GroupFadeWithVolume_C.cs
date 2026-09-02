using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.VolumeGroupFade
{
	// Token: 0x02003B5B RID: 15195
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_GroupFadeWithVolume.BP_GroupFadeWithVolume_C")]
	[UnrealStructLayout(2440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2437)]
	public class BP_GroupFadeWithVolume_C : AKuroBPCustomCookActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060212DC RID: 135900 RVA: 0x009421C7 File Offset: 0x009403C7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GroupFadeWithVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_GroupFadeWithVolume.BP_GroupFadeWithVolume_C");
			}
			return BP_GroupFadeWithVolume_C._ClassPtr;
		}

		// Token: 0x060212DD RID: 135901 RVA: 0x009421EC File Offset: 0x009403EC
		public BP_GroupFadeWithVolume_C() : this(BuiltinUtils.AllocNativeUObject(BP_GroupFadeWithVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060212DE RID: 135902 RVA: 0x00942214 File Offset: 0x00940414
		public BP_GroupFadeWithVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GroupFadeWithVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003993 RID: 14739
		// (get) Token: 0x060212DF RID: 135903 RVA: 0x00942248 File Offset: 0x00940448
		// (set) Token: 0x060212E0 RID: 135904 RVA: 0x00942281 File Offset: 0x00940481
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003994 RID: 14740
		// (get) Token: 0x060212E1 RID: 135905 RVA: 0x009422A2 File Offset: 0x009404A2
		// (set) Token: 0x060212E2 RID: 135906 RVA: 0x009422B6 File Offset: 0x009404B6
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroupFadeWithVolume_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroupFadeWithVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003995 RID: 14741
		// (get) Token: 0x060212E3 RID: 135907 RVA: 0x009422CC File Offset: 0x009404CC
		// (set) Token: 0x060212E4 RID: 135908 RVA: 0x00942305 File Offset: 0x00940505
		public TSet<ALight> LightList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<ALight> result;
				if ((result = this._LightList) == null)
				{
					result = (this._LightList = new TSet<ALight>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.LightList.CopyAssign(value);
			}
		}

		// Token: 0x17003996 RID: 14742
		// (get) Token: 0x060212E5 RID: 135909 RVA: 0x00942314 File Offset: 0x00940514
		// (set) Token: 0x060212E6 RID: 135910 RVA: 0x0094234D File Offset: 0x0094054D
		public TArray<float> CachedLightIntensity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedLightIntensity) == null)
				{
					result = (this._CachedLightIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.CachedLightIntensity.CopyAssign(value);
			}
		}

		// Token: 0x17003997 RID: 14743
		// (get) Token: 0x060212E7 RID: 135911 RVA: 0x0094235C File Offset: 0x0094055C
		// (set) Token: 0x060212E8 RID: 135912 RVA: 0x00942395 File Offset: 0x00940595
		public TSet<BP_VolumetricSphereLight_C> VolumeLightSphereList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_VolumetricSphereLight_C> result;
				if ((result = this._VolumeLightSphereList) == null)
				{
					result = (this._VolumeLightSphereList = new TSet<BP_VolumetricSphereLight_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.VolumeLightSphereList.CopyAssign(value);
			}
		}

		// Token: 0x17003998 RID: 14744
		// (get) Token: 0x060212E9 RID: 135913 RVA: 0x009423A4 File Offset: 0x009405A4
		// (set) Token: 0x060212EA RID: 135914 RVA: 0x009423DD File Offset: 0x009405DD
		public TArray<float> CachedVolumeLightSphere
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedVolumeLightSphere) == null)
				{
					result = (this._CachedVolumeLightSphere = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.CachedVolumeLightSphere.CopyAssign(value);
			}
		}

		// Token: 0x17003999 RID: 14745
		// (get) Token: 0x060212EB RID: 135915 RVA: 0x009423EC File Offset: 0x009405EC
		// (set) Token: 0x060212EC RID: 135916 RVA: 0x00942425 File Offset: 0x00940625
		public TSet<BP_KuroLightDecal_C> DecalLightList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_KuroLightDecal_C> result;
				if ((result = this._DecalLightList) == null)
				{
					result = (this._DecalLightList = new TSet<BP_KuroLightDecal_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.DecalLightList.CopyAssign(value);
			}
		}

		// Token: 0x1700399A RID: 14746
		// (get) Token: 0x060212ED RID: 135917 RVA: 0x00942434 File Offset: 0x00940634
		// (set) Token: 0x060212EE RID: 135918 RVA: 0x0094246D File Offset: 0x0094066D
		public TArray<float> CachedDecalLight
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedDecalLight) == null)
				{
					result = (this._CachedDecalLight = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.CachedDecalLight.CopyAssign(value);
			}
		}

		// Token: 0x1700399B RID: 14747
		// (get) Token: 0x060212EF RID: 135919 RVA: 0x0094247C File Offset: 0x0094067C
		// (set) Token: 0x060212F0 RID: 135920 RVA: 0x009424B5 File Offset: 0x009406B5
		public TSet<BP_VolumetricSphereLightSuperFar_C> VolumeLightSphereSuperFarList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_VolumetricSphereLightSuperFar_C> result;
				if ((result = this._VolumeLightSphereSuperFarList) == null)
				{
					result = (this._VolumeLightSphereSuperFarList = new TSet<BP_VolumetricSphereLightSuperFar_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.VolumeLightSphereSuperFarList.CopyAssign(value);
			}
		}

		// Token: 0x1700399C RID: 14748
		// (get) Token: 0x060212F1 RID: 135921 RVA: 0x009424C4 File Offset: 0x009406C4
		// (set) Token: 0x060212F2 RID: 135922 RVA: 0x009424FD File Offset: 0x009406FD
		public TArray<float> CachedVolumeLightSphereSuperFar
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedVolumeLightSphereSuperFar) == null)
				{
					result = (this._CachedVolumeLightSphereSuperFar = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				this.CachedVolumeLightSphereSuperFar.CopyAssign(value);
			}
		}

		// Token: 0x1700399D RID: 14749
		// (get) Token: 0x060212F3 RID: 135923 RVA: 0x0094250B File Offset: 0x0094070B
		// (set) Token: 0x060212F4 RID: 135924 RVA: 0x0094251F File Offset: 0x0094071F
		[Nullable(2)]
		public unsafe AKuroPostProcessVolume BoundVolume
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroupFadeWithVolume_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroupFadeWithVolume_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700399E RID: 14750
		// (get) Token: 0x060212F5 RID: 135925 RVA: 0x00942534 File Offset: 0x00940734
		// (set) Token: 0x060212F6 RID: 135926 RVA: 0x00942548 File Offset: 0x00940748
		[Nullable(2)]
		public unsafe BP_GlobalGI_C CachedGlobalGI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroupFadeWithVolume_C.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GroupFadeWithVolume_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700399F RID: 14751
		// (get) Token: 0x060212F7 RID: 135927 RVA: 0x0094255D File Offset: 0x0094075D
		// (set) Token: 0x060212F8 RID: 135928 RVA: 0x0094256D File Offset: 0x0094076D
		public unsafe float lastWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170039A0 RID: 14752
		// (get) Token: 0x060212F9 RID: 135929 RVA: 0x00942580 File Offset: 0x00940780
		// (set) Token: 0x060212FA RID: 135930 RVA: 0x009425B9 File Offset: 0x009407B9
		public TSet<BP_SingleCloud_C> CloudList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_SingleCloud_C> result;
				if ((result = this._CloudList) == null)
				{
					result = (this._CloudList = new TSet<BP_SingleCloud_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.CloudList.CopyAssign(value);
			}
		}

		// Token: 0x170039A1 RID: 14753
		// (get) Token: 0x060212FB RID: 135931 RVA: 0x009425C8 File Offset: 0x009407C8
		// (set) Token: 0x060212FC RID: 135932 RVA: 0x00942601 File Offset: 0x00940801
		public TArray<float> CachedCloudIntensity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedCloudIntensity) == null)
				{
					result = (this._CachedCloudIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.CachedCloudIntensity.CopyAssign(value);
			}
		}

		// Token: 0x170039A2 RID: 14754
		// (get) Token: 0x060212FD RID: 135933 RVA: 0x00942610 File Offset: 0x00940810
		// (set) Token: 0x060212FE RID: 135934 RVA: 0x00942649 File Offset: 0x00940849
		public TSet<BP_SingleCloud_Custom_C> CustomCloudList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_SingleCloud_Custom_C> result;
				if ((result = this._CustomCloudList) == null)
				{
					result = (this._CustomCloudList = new TSet<BP_SingleCloud_Custom_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.CustomCloudList.CopyAssign(value);
			}
		}

		// Token: 0x170039A3 RID: 14755
		// (get) Token: 0x060212FF RID: 135935 RVA: 0x00942658 File Offset: 0x00940858
		// (set) Token: 0x06021300 RID: 135936 RVA: 0x00942691 File Offset: 0x00940891
		public TArray<float> CachedCustomCloudIntensity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedCustomCloudIntensity) == null)
				{
					result = (this._CachedCustomCloudIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				this.CachedCustomCloudIntensity.CopyAssign(value);
			}
		}

		// Token: 0x170039A4 RID: 14756
		// (get) Token: 0x06021301 RID: 135937 RVA: 0x0094269F File Offset: 0x0094089F
		// (set) Token: 0x06021302 RID: 135938 RVA: 0x009426AF File Offset: 0x009408AF
		public unsafe bool bPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039A5 RID: 14757
		// (get) Token: 0x06021303 RID: 135939 RVA: 0x009426C0 File Offset: 0x009408C0
		// (set) Token: 0x06021304 RID: 135940 RVA: 0x009426D0 File Offset: 0x009408D0
		public unsafe bool bMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039A6 RID: 14758
		// (get) Token: 0x06021305 RID: 135941 RVA: 0x009426E4 File Offset: 0x009408E4
		// (set) Token: 0x06021306 RID: 135942 RVA: 0x0094271D File Offset: 0x0094091D
		public TSet<AKuroPostProcessVolume> FadeOutVolumes
		{
			get
			{
				base.FastCheckIsValid();
				TSet<AKuroPostProcessVolume> result;
				if ((result = this._FadeOutVolumes) == null)
				{
					result = (this._FadeOutVolumes = new TSet<AKuroPostProcessVolume>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				this.FadeOutVolumes.CopyAssign(value);
			}
		}

		// Token: 0x170039A7 RID: 14759
		// (get) Token: 0x06021307 RID: 135943 RVA: 0x0094272B File Offset: 0x0094092B
		// (set) Token: 0x06021308 RID: 135944 RVA: 0x0094273B File Offset: 0x0094093B
		public unsafe float maxFadeoutWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170039A8 RID: 14760
		// (get) Token: 0x06021309 RID: 135945 RVA: 0x0094274C File Offset: 0x0094094C
		// (set) Token: 0x0602130A RID: 135946 RVA: 0x0094275C File Offset: 0x0094095C
		public unsafe bool bCooked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039A9 RID: 14761
		// (get) Token: 0x0602130B RID: 135947 RVA: 0x00942770 File Offset: 0x00940970
		// (set) Token: 0x0602130C RID: 135948 RVA: 0x009427A9 File Offset: 0x009409A9
		public TSet<BP_SuperFarFog_C> SuperfarFogList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_SuperFarFog_C> result;
				if ((result = this._SuperfarFogList) == null)
				{
					result = (this._SuperfarFogList = new TSet<BP_SuperFarFog_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				this.SuperfarFogList.CopyAssign(value);
			}
		}

		// Token: 0x170039AA RID: 14762
		// (get) Token: 0x0602130D RID: 135949 RVA: 0x009427B8 File Offset: 0x009409B8
		// (set) Token: 0x0602130E RID: 135950 RVA: 0x009427F1 File Offset: 0x009409F1
		public TArray<float> CachedSuperFarFogOpacity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedSuperFarFogOpacity) == null)
				{
					result = (this._CachedSuperFarFogOpacity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				this.CachedSuperFarFogOpacity.CopyAssign(value);
			}
		}

		// Token: 0x170039AB RID: 14763
		// (get) Token: 0x0602130F RID: 135951 RVA: 0x00942800 File Offset: 0x00940A00
		// (set) Token: 0x06021310 RID: 135952 RVA: 0x00942839 File Offset: 0x00940A39
		public TArray<float> CachedSuperFarFogOpacity_Night
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedSuperFarFogOpacity_Night) == null)
				{
					result = (this._CachedSuperFarFogOpacity_Night = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				this.CachedSuperFarFogOpacity_Night.CopyAssign(value);
			}
		}

		// Token: 0x170039AC RID: 14764
		// (get) Token: 0x06021311 RID: 135953 RVA: 0x00942848 File Offset: 0x00940A48
		// (set) Token: 0x06021312 RID: 135954 RVA: 0x00942881 File Offset: 0x00940A81
		public TSet<BP_KuroFlickLight_C> FlickLightList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_KuroFlickLight_C> result;
				if ((result = this._FlickLightList) == null)
				{
					result = (this._FlickLightList = new TSet<BP_KuroFlickLight_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				this.FlickLightList.CopyAssign(value);
			}
		}

		// Token: 0x170039AD RID: 14765
		// (get) Token: 0x06021313 RID: 135955 RVA: 0x00942890 File Offset: 0x00940A90
		// (set) Token: 0x06021314 RID: 135956 RVA: 0x009428C9 File Offset: 0x00940AC9
		public TArray<float> CachedFlickLightIntensity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedFlickLightIntensity) == null)
				{
					result = (this._CachedFlickLightIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				this.CachedFlickLightIntensity.CopyAssign(value);
			}
		}

		// Token: 0x170039AE RID: 14766
		// (get) Token: 0x06021315 RID: 135957 RVA: 0x009428D8 File Offset: 0x00940AD8
		// (set) Token: 0x06021316 RID: 135958 RVA: 0x00942911 File Offset: 0x00940B11
		public TSet<BP_KuroLightDecal_C> LightDecalList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_KuroLightDecal_C> result;
				if ((result = this._LightDecalList) == null)
				{
					result = (this._LightDecalList = new TSet<BP_KuroLightDecal_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				this.LightDecalList.CopyAssign(value);
			}
		}

		// Token: 0x170039AF RID: 14767
		// (get) Token: 0x06021317 RID: 135959 RVA: 0x00942920 File Offset: 0x00940B20
		// (set) Token: 0x06021318 RID: 135960 RVA: 0x00942959 File Offset: 0x00940B59
		public TArray<float> CachedLightDecalIntensity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedLightDecalIntensity) == null)
				{
					result = (this._CachedLightDecalIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				this.CachedLightDecalIntensity.CopyAssign(value);
			}
		}

		// Token: 0x170039B0 RID: 14768
		// (get) Token: 0x06021319 RID: 135961 RVA: 0x00942968 File Offset: 0x00940B68
		// (set) Token: 0x0602131A RID: 135962 RVA: 0x009429A1 File Offset: 0x00940BA1
		public TSet<BP_ShadowDecal_C> ShadowDecalList
		{
			get
			{
				base.FastCheckIsValid();
				TSet<BP_ShadowDecal_C> result;
				if ((result = this._ShadowDecalList) == null)
				{
					result = (this._ShadowDecalList = new TSet<BP_ShadowDecal_C>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				this.ShadowDecalList.CopyAssign(value);
			}
		}

		// Token: 0x170039B1 RID: 14769
		// (get) Token: 0x0602131B RID: 135963 RVA: 0x009429B0 File Offset: 0x00940BB0
		// (set) Token: 0x0602131C RID: 135964 RVA: 0x009429E9 File Offset: 0x00940BE9
		public TArray<float> CachedShadowDecalIntensity
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CachedShadowDecalIntensity) == null)
				{
					result = (this._CachedShadowDecalIntensity = new TArray<float>(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				this.CachedShadowDecalIntensity.CopyAssign(value);
			}
		}

		// Token: 0x170039B2 RID: 14770
		// (get) Token: 0x0602131D RID: 135965 RVA: 0x009429F7 File Offset: 0x00940BF7
		// (set) Token: 0x0602131E RID: 135966 RVA: 0x00942A07 File Offset: 0x00940C07
		public unsafe bool bUseMPCFadeGroup
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x170039B3 RID: 14771
		// (get) Token: 0x0602131F RID: 135967 RVA: 0x00942A18 File Offset: 0x00940C18
		// (set) Token: 0x06021320 RID: 135968 RVA: 0x00942A28 File Offset: 0x00940C28
		public unsafe int MPCFadeGroup
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170039B4 RID: 14772
		// (get) Token: 0x06021321 RID: 135969 RVA: 0x00942A39 File Offset: 0x00940C39
		// (set) Token: 0x06021322 RID: 135970 RVA: 0x00942A4D File Offset: 0x00940C4D
		public unsafe FName FadeGroupName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170039B5 RID: 14773
		// (get) Token: 0x06021323 RID: 135971 RVA: 0x00942A62 File Offset: 0x00940C62
		// (set) Token: 0x06021324 RID: 135972 RVA: 0x00942A72 File Offset: 0x00940C72
		public unsafe bool bForceShow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GroupFadeWithVolume_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021325 RID: 135973 RVA: 0x00942A84 File Offset: 0x00940C84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateShadowDecal(float A)
		{
			BP_GroupFadeWithVolume_C.__UpdateShadowDecal_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateShadowDecal_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateShadowDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateShadowDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateShadowDecal_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021326 RID: 135974 RVA: 0x00942ACA File Offset: 0x00940CCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheShadowDecal()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheShadowDecal_NativeFunctionPtr, null);
		}

		// Token: 0x06021327 RID: 135975 RVA: 0x00942AE0 File Offset: 0x00940CE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateLightDecal(float A)
		{
			BP_GroupFadeWithVolume_C.__UpdateLightDecal_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateLightDecal_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateLightDecal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateLightDecal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateLightDecal_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021328 RID: 135976 RVA: 0x00942B26 File Offset: 0x00940D26
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheLightDecal()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheLightDecal_NativeFunctionPtr, null);
		}

		// Token: 0x06021329 RID: 135977 RVA: 0x00942B3C File Offset: 0x00940D3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateFlickLight(float A)
		{
			BP_GroupFadeWithVolume_C.__UpdateFlickLight_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateFlickLight_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateFlickLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateFlickLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateFlickLight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602132A RID: 135978 RVA: 0x00942B82 File Offset: 0x00940D82
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheFlickLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheFlickLight_NativeFunctionPtr, null);
		}

		// Token: 0x0602132B RID: 135979 RVA: 0x00942B96 File Offset: 0x00940D96
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MarkLightExcludeFromTOD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__MarkLightExcludeFromTOD_NativeFunctionPtr, null);
		}

		// Token: 0x0602132C RID: 135980 RVA: 0x00942BAC File Offset: 0x00940DAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float ComputeWeight()
		{
			BP_GroupFadeWithVolume_C.__ComputeWeight_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__ComputeWeight_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__ComputeWeight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__ComputeWeight_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ComputeWeight_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602132D RID: 135981 RVA: 0x00942BF4 File Offset: 0x00940DF4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CheckObjectPlatform(UObject Object, ref bool valid)
		{
			BP_GroupFadeWithVolume_C.__CheckObjectPlatform_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__CheckObjectPlatform_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__CheckObjectPlatform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__CheckObjectPlatform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Object = ((Object != null) ? Object.NativePtr : IntPtr.Zero);
			ptr->valid = valid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CheckObjectPlatform_NativeFunctionPtr, (void*)ptr);
			valid = ptr->valid;
		}

		// Token: 0x0602132E RID: 135982 RVA: 0x00942C5C File Offset: 0x00940E5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckPlatform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CheckPlatform_NativeFunctionPtr, null);
		}

		// Token: 0x0602132F RID: 135983 RVA: 0x00942C70 File Offset: 0x00940E70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateSuperFarFog(float A)
		{
			BP_GroupFadeWithVolume_C.__UpdateSuperFarFog_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateSuperFarFog_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateSuperFarFog_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateSuperFarFog_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateSuperFarFog_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021330 RID: 135984 RVA: 0x00942CB9 File Offset: 0x00940EB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheSuperFarFog()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheSuperFarFog_NativeFunctionPtr, null);
		}

		// Token: 0x06021331 RID: 135985 RVA: 0x00942CD0 File Offset: 0x00940ED0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCustomCloud(float B)
		{
			BP_GroupFadeWithVolume_C.__UpdateCustomCloud_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateCustomCloud_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateCustomCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateCustomCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->B = B;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateCustomCloud_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021332 RID: 135986 RVA: 0x00942D16 File Offset: 0x00940F16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheCustomCloud()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheCustomCloud_NativeFunctionPtr, null);
		}

		// Token: 0x06021333 RID: 135987 RVA: 0x00942D2C File Offset: 0x00940F2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloud(float B)
		{
			BP_GroupFadeWithVolume_C.__UpdateCloud_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateCloud_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->B = B;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateCloud_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021334 RID: 135988 RVA: 0x00942D72 File Offset: 0x00940F72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheCloud()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheCloud_NativeFunctionPtr, null);
		}

		// Token: 0x06021335 RID: 135989 RVA: 0x00942D88 File Offset: 0x00940F88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateVolumeLightSphereFar(float A)
		{
			BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphereFar_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphereFar_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphereFar_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphereFar_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphereFar_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021336 RID: 135990 RVA: 0x00942DCE File Offset: 0x00940FCE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheVolumeLightSphereFar()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheVolumeLightSphereFar_NativeFunctionPtr, null);
		}

		// Token: 0x06021337 RID: 135991 RVA: 0x00942DE4 File Offset: 0x00940FE4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateVolumeLightSphere(float B)
		{
			BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphere_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphere_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphere_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphere_NativeFunctionPtr, (void*)ptr, 1);
			ptr->B = B;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateVolumeLightSphere_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021338 RID: 135992 RVA: 0x00942E2A File Offset: 0x0094102A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheVolumeLightSphere()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheVolumeLightSphere_NativeFunctionPtr, null);
		}

		// Token: 0x06021339 RID: 135993 RVA: 0x00942E40 File Offset: 0x00941040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateLight(float A)
		{
			BP_GroupFadeWithVolume_C.__UpdateLight_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__UpdateLight_FunctionParams[(UIntPtr)295] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__UpdateLight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__UpdateLight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->A = A;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UpdateLight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602133A RID: 135994 RVA: 0x00942E89 File Offset: 0x00941089
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheLightInstensity()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheLightInstensity_NativeFunctionPtr, null);
		}

		// Token: 0x0602133B RID: 135995 RVA: 0x00942E9D File Offset: 0x0094109D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearInvalid()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ClearInvalid_NativeFunctionPtr, null);
		}

		// Token: 0x0602133C RID: 135996 RVA: 0x00942EB1 File Offset: 0x009410B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602133D RID: 135997 RVA: 0x00942EC5 File Offset: 0x009410C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602133E RID: 135998 RVA: 0x00942EDA File Offset: 0x009410DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602133F RID: 135999 RVA: 0x00942EEE File Offset: 0x009410EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021340 RID: 136000 RVA: 0x00942F04 File Offset: 0x00941104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GroupFadeWithVolume_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021341 RID: 136001 RVA: 0x00942F4C File Offset: 0x0094114C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GroupFadeWithVolume_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021342 RID: 136002 RVA: 0x00942F93 File Offset: 0x00941193
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CacheIntensity()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__CacheIntensity_NativeFunctionPtr, null);
		}

		// Token: 0x06021343 RID: 136003 RVA: 0x00942FA7 File Offset: 0x009411A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x06021344 RID: 136004 RVA: 0x00942FBB File Offset: 0x009411BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021345 RID: 136005 RVA: 0x00942FD0 File Offset: 0x009411D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__BeforeCookForPC_NativeFunctionPtr, null);
		}

		// Token: 0x06021346 RID: 136006 RVA: 0x00942FE4 File Offset: 0x009411E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForPC_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__BeforeCookForPC_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021347 RID: 136007 RVA: 0x00942FFC File Offset: 0x009411FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GroupFadeWithVolume(int EntryPoint)
		{
			BP_GroupFadeWithVolume_C.__ExecuteUbergraph_BP_GroupFadeWithVolume_FunctionParams* ptr = stackalloc BP_GroupFadeWithVolume_C.__ExecuteUbergraph_BP_GroupFadeWithVolume_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_GroupFadeWithVolume_C.__ExecuteUbergraph_BP_GroupFadeWithVolume_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GroupFadeWithVolume_C.__ExecuteUbergraph_BP_GroupFadeWithVolume_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GroupFadeWithVolume_C.__ExecuteUbergraph_BP_GroupFadeWithVolume_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021348 RID: 136008 RVA: 0x00943043 File Offset: 0x00941243
		protected BP_GroupFadeWithVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010ACA RID: 68298
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/VolumeGroupFade/BP_GroupFadeWithVolume.BP_GroupFadeWithVolume_C";

		// Token: 0x04010ACB RID: 68299
		private static IntPtr _ClassPtr;

		// Token: 0x04010ACC RID: 68300
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010ACD RID: 68301
		internal static int __PropertyOffset_0;

		// Token: 0x04010ACE RID: 68302
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010ACF RID: 68303
		internal static int __PropertyOffset_1;

		// Token: 0x04010AD0 RID: 68304
		internal static int __PropertyOffset_2;

		// Token: 0x04010AD1 RID: 68305
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<ALight> _LightList;

		// Token: 0x04010AD2 RID: 68306
		internal static int __PropertyOffset_3;

		// Token: 0x04010AD3 RID: 68307
		[Nullable(2)]
		private TArray<float> _CachedLightIntensity;

		// Token: 0x04010AD4 RID: 68308
		internal static int __PropertyOffset_4;

		// Token: 0x04010AD5 RID: 68309
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_VolumetricSphereLight_C> _VolumeLightSphereList;

		// Token: 0x04010AD6 RID: 68310
		internal static int __PropertyOffset_5;

		// Token: 0x04010AD7 RID: 68311
		[Nullable(2)]
		private TArray<float> _CachedVolumeLightSphere;

		// Token: 0x04010AD8 RID: 68312
		internal static int __PropertyOffset_6;

		// Token: 0x04010AD9 RID: 68313
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_KuroLightDecal_C> _DecalLightList;

		// Token: 0x04010ADA RID: 68314
		internal static int __PropertyOffset_7;

		// Token: 0x04010ADB RID: 68315
		[Nullable(2)]
		private TArray<float> _CachedDecalLight;

		// Token: 0x04010ADC RID: 68316
		internal static int __PropertyOffset_8;

		// Token: 0x04010ADD RID: 68317
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_VolumetricSphereLightSuperFar_C> _VolumeLightSphereSuperFarList;

		// Token: 0x04010ADE RID: 68318
		internal static int __PropertyOffset_9;

		// Token: 0x04010ADF RID: 68319
		[Nullable(2)]
		private TArray<float> _CachedVolumeLightSphereSuperFar;

		// Token: 0x04010AE0 RID: 68320
		internal static int __PropertyOffset_10;

		// Token: 0x04010AE1 RID: 68321
		internal static int __PropertyOffset_11;

		// Token: 0x04010AE2 RID: 68322
		internal static int __PropertyOffset_12;

		// Token: 0x04010AE3 RID: 68323
		internal static int __PropertyOffset_13;

		// Token: 0x04010AE4 RID: 68324
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_SingleCloud_C> _CloudList;

		// Token: 0x04010AE5 RID: 68325
		internal static int __PropertyOffset_14;

		// Token: 0x04010AE6 RID: 68326
		[Nullable(2)]
		private TArray<float> _CachedCloudIntensity;

		// Token: 0x04010AE7 RID: 68327
		internal static int __PropertyOffset_15;

		// Token: 0x04010AE8 RID: 68328
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_SingleCloud_Custom_C> _CustomCloudList;

		// Token: 0x04010AE9 RID: 68329
		internal static int __PropertyOffset_16;

		// Token: 0x04010AEA RID: 68330
		[Nullable(2)]
		private TArray<float> _CachedCustomCloudIntensity;

		// Token: 0x04010AEB RID: 68331
		internal static int __PropertyOffset_17;

		// Token: 0x04010AEC RID: 68332
		internal static int __PropertyOffset_18;

		// Token: 0x04010AED RID: 68333
		internal static int __PropertyOffset_19;

		// Token: 0x04010AEE RID: 68334
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<AKuroPostProcessVolume> _FadeOutVolumes;

		// Token: 0x04010AEF RID: 68335
		internal static int __PropertyOffset_20;

		// Token: 0x04010AF0 RID: 68336
		internal static int __PropertyOffset_21;

		// Token: 0x04010AF1 RID: 68337
		internal static int __PropertyOffset_22;

		// Token: 0x04010AF2 RID: 68338
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_SuperFarFog_C> _SuperfarFogList;

		// Token: 0x04010AF3 RID: 68339
		internal static int __PropertyOffset_23;

		// Token: 0x04010AF4 RID: 68340
		[Nullable(2)]
		private TArray<float> _CachedSuperFarFogOpacity;

		// Token: 0x04010AF5 RID: 68341
		internal static int __PropertyOffset_24;

		// Token: 0x04010AF6 RID: 68342
		[Nullable(2)]
		private TArray<float> _CachedSuperFarFogOpacity_Night;

		// Token: 0x04010AF7 RID: 68343
		internal static int __PropertyOffset_25;

		// Token: 0x04010AF8 RID: 68344
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_KuroFlickLight_C> _FlickLightList;

		// Token: 0x04010AF9 RID: 68345
		internal static int __PropertyOffset_26;

		// Token: 0x04010AFA RID: 68346
		[Nullable(2)]
		private TArray<float> _CachedFlickLightIntensity;

		// Token: 0x04010AFB RID: 68347
		internal static int __PropertyOffset_27;

		// Token: 0x04010AFC RID: 68348
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_KuroLightDecal_C> _LightDecalList;

		// Token: 0x04010AFD RID: 68349
		internal static int __PropertyOffset_28;

		// Token: 0x04010AFE RID: 68350
		[Nullable(2)]
		private TArray<float> _CachedLightDecalIntensity;

		// Token: 0x04010AFF RID: 68351
		internal static int __PropertyOffset_29;

		// Token: 0x04010B00 RID: 68352
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<BP_ShadowDecal_C> _ShadowDecalList;

		// Token: 0x04010B01 RID: 68353
		internal static int __PropertyOffset_30;

		// Token: 0x04010B02 RID: 68354
		[Nullable(2)]
		private TArray<float> _CachedShadowDecalIntensity;

		// Token: 0x04010B03 RID: 68355
		internal static int __PropertyOffset_31;

		// Token: 0x04010B04 RID: 68356
		internal static int __PropertyOffset_32;

		// Token: 0x04010B05 RID: 68357
		internal static int __PropertyOffset_33;

		// Token: 0x04010B06 RID: 68358
		internal static int __PropertyOffset_34;

		// Token: 0x04010B07 RID: 68359
		private static IntPtr __UpdateShadowDecal_NativeFunctionPtr;

		// Token: 0x04010B08 RID: 68360
		private static IntPtr __CacheShadowDecal_NativeFunctionPtr;

		// Token: 0x04010B09 RID: 68361
		private static IntPtr __UpdateLightDecal_NativeFunctionPtr;

		// Token: 0x04010B0A RID: 68362
		private static IntPtr __CacheLightDecal_NativeFunctionPtr;

		// Token: 0x04010B0B RID: 68363
		private static IntPtr __UpdateFlickLight_NativeFunctionPtr;

		// Token: 0x04010B0C RID: 68364
		private static IntPtr __CacheFlickLight_NativeFunctionPtr;

		// Token: 0x04010B0D RID: 68365
		private static IntPtr __MarkLightExcludeFromTOD_NativeFunctionPtr;

		// Token: 0x04010B0E RID: 68366
		private static IntPtr __ComputeWeight_NativeFunctionPtr;

		// Token: 0x04010B0F RID: 68367
		private static IntPtr __CheckObjectPlatform_NativeFunctionPtr;

		// Token: 0x04010B10 RID: 68368
		private static IntPtr __CheckPlatform_NativeFunctionPtr;

		// Token: 0x04010B11 RID: 68369
		private static IntPtr __UpdateSuperFarFog_NativeFunctionPtr;

		// Token: 0x04010B12 RID: 68370
		private static IntPtr __CacheSuperFarFog_NativeFunctionPtr;

		// Token: 0x04010B13 RID: 68371
		private static IntPtr __UpdateCustomCloud_NativeFunctionPtr;

		// Token: 0x04010B14 RID: 68372
		private static IntPtr __CacheCustomCloud_NativeFunctionPtr;

		// Token: 0x04010B15 RID: 68373
		private static IntPtr __UpdateCloud_NativeFunctionPtr;

		// Token: 0x04010B16 RID: 68374
		private static IntPtr __CacheCloud_NativeFunctionPtr;

		// Token: 0x04010B17 RID: 68375
		private static IntPtr __UpdateVolumeLightSphereFar_NativeFunctionPtr;

		// Token: 0x04010B18 RID: 68376
		private static IntPtr __CacheVolumeLightSphereFar_NativeFunctionPtr;

		// Token: 0x04010B19 RID: 68377
		private static IntPtr __UpdateVolumeLightSphere_NativeFunctionPtr;

		// Token: 0x04010B1A RID: 68378
		private static IntPtr __CacheVolumeLightSphere_NativeFunctionPtr;

		// Token: 0x04010B1B RID: 68379
		private static IntPtr __UpdateLight_NativeFunctionPtr;

		// Token: 0x04010B1C RID: 68380
		private static IntPtr __CacheLightInstensity_NativeFunctionPtr;

		// Token: 0x04010B1D RID: 68381
		private static IntPtr __ClearInvalid_NativeFunctionPtr;

		// Token: 0x04010B1E RID: 68382
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010B1F RID: 68383
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010B20 RID: 68384
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010B21 RID: 68385
		private static IntPtr __CacheIntensity_NativeFunctionPtr;

		// Token: 0x04010B22 RID: 68386
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x04010B23 RID: 68387
		private static IntPtr __BeforeCookForPC_NativeFunctionPtr;

		// Token: 0x04010B24 RID: 68388
		private static IntPtr __ExecuteUbergraph_BP_GroupFadeWithVolume_NativeFunctionPtr;

		// Token: 0x02009A90 RID: 39568
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected ref struct __UpdateShadowDecal_FunctionParams
		{
			// Token: 0x040321F4 RID: 205300
			[FieldOffset(0)]
			public float A;
		}

		// Token: 0x02009A91 RID: 39569
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __UpdateLightDecal_FunctionParams
		{
			// Token: 0x040321F5 RID: 205301
			[FieldOffset(0)]
			public float A;
		}

		// Token: 0x02009A92 RID: 39570
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __UpdateFlickLight_FunctionParams
		{
			// Token: 0x040321F6 RID: 205302
			[FieldOffset(0)]
			public float A;
		}

		// Token: 0x02009A93 RID: 39571
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ComputeWeight_FunctionParams
		{
			// Token: 0x040321F7 RID: 205303
			[FieldOffset(0)]
			public float __Result;
		}

		// Token: 0x02009A94 RID: 39572
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __CheckObjectPlatform_FunctionParams
		{
			// Token: 0x040321F8 RID: 205304
			[FieldOffset(0)]
			public IntPtr Object;

			// Token: 0x040321F9 RID: 205305
			[FieldOffset(8)]
			public bool valid;
		}

		// Token: 0x02009A95 RID: 39573
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __UpdateSuperFarFog_FunctionParams
		{
			// Token: 0x040321FA RID: 205306
			[FieldOffset(0)]
			public float A;
		}

		// Token: 0x02009A96 RID: 39574
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __UpdateCustomCloud_FunctionParams
		{
			// Token: 0x040321FB RID: 205307
			[FieldOffset(0)]
			public float B;
		}

		// Token: 0x02009A97 RID: 39575
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __UpdateCloud_FunctionParams
		{
			// Token: 0x040321FC RID: 205308
			[FieldOffset(0)]
			public float B;
		}

		// Token: 0x02009A98 RID: 39576
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __UpdateVolumeLightSphereFar_FunctionParams
		{
			// Token: 0x040321FD RID: 205309
			[FieldOffset(0)]
			public float A;
		}

		// Token: 0x02009A99 RID: 39577
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __UpdateVolumeLightSphere_FunctionParams
		{
			// Token: 0x040321FE RID: 205310
			[FieldOffset(0)]
			public float B;
		}

		// Token: 0x02009A9A RID: 39578
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 280)]
		protected ref struct __UpdateLight_FunctionParams
		{
			// Token: 0x040321FF RID: 205311
			[FieldOffset(0)]
			public float A;
		}

		// Token: 0x02009A9B RID: 39579
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032200 RID: 205312
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A9C RID: 39580
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_GroupFadeWithVolume_FunctionParams
		{
			// Token: 0x04032201 RID: 205313
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
