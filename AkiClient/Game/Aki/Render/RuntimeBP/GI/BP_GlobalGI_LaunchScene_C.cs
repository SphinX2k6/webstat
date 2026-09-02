using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.UI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C95 RID: 15509
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI_LaunchScene.BP_GlobalGI_LaunchScene_C")]
	[UnrealStructLayout(16688, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 16680)]
	public class BP_GlobalGI_LaunchScene_C : AKuroGlobalGI, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602451D RID: 148765 RVA: 0x0099A694 File Offset: 0x00998894
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GlobalGI_LaunchScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI_LaunchScene.BP_GlobalGI_LaunchScene_C");
			}
			return BP_GlobalGI_LaunchScene_C._ClassPtr;
		}

		// Token: 0x0602451E RID: 148766 RVA: 0x0099A6B8 File Offset: 0x009988B8
		public BP_GlobalGI_LaunchScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGI_LaunchScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602451F RID: 148767 RVA: 0x0099A6E0 File Offset: 0x009988E0
		[NullableContext(1)]
		public BP_GlobalGI_LaunchScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGI_LaunchScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004B5B RID: 19291
		// (get) Token: 0x06024520 RID: 148768 RVA: 0x0099A714 File Offset: 0x00998914
		// (set) Token: 0x06024521 RID: 148769 RVA: 0x0099A74D File Offset: 0x0099894D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004B5C RID: 19292
		// (get) Token: 0x06024522 RID: 148770 RVA: 0x0099A76E File Offset: 0x0099896E
		// (set) Token: 0x06024523 RID: 148771 RVA: 0x0099A782 File Offset: 0x00998982
		public unsafe USceneRayTracingGICaptureComponentCube SceneRayTracingGICaptureComponentCube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneRayTracingGICaptureComponentCube>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004B5D RID: 19293
		// (get) Token: 0x06024524 RID: 148772 RVA: 0x0099A797 File Offset: 0x00998997
		// (set) Token: 0x06024525 RID: 148773 RVA: 0x0099A7AB File Offset: 0x009989AB
		public unsafe UChildActorComponent KuroVolumeCloudGlobal1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004B5E RID: 19294
		// (get) Token: 0x06024526 RID: 148774 RVA: 0x0099A7C0 File Offset: 0x009989C0
		// (set) Token: 0x06024527 RID: 148775 RVA: 0x0099A7D4 File Offset: 0x009989D4
		public unsafe UKuroPostProcessComponent LUTPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004B5F RID: 19295
		// (get) Token: 0x06024528 RID: 148776 RVA: 0x0099A7E9 File Offset: 0x009989E9
		// (set) Token: 0x06024529 RID: 148777 RVA: 0x0099A7FD File Offset: 0x009989FD
		public unsafe UStaticMeshComponent Skybox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004B60 RID: 19296
		// (get) Token: 0x0602452A RID: 148778 RVA: 0x0099A812 File Offset: 0x00998A12
		// (set) Token: 0x0602452B RID: 148779 RVA: 0x0099A826 File Offset: 0x00998A26
		public unsafe UKuroPostProcessComponent GlobalUiKuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004B61 RID: 19297
		// (get) Token: 0x0602452C RID: 148780 RVA: 0x0099A83B File Offset: 0x00998A3B
		// (set) Token: 0x0602452D RID: 148781 RVA: 0x0099A84F File Offset: 0x00998A4F
		public unsafe UPostProcessComponent GlobalPostProcessVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004B62 RID: 19298
		// (get) Token: 0x0602452E RID: 148782 RVA: 0x0099A864 File Offset: 0x00998A64
		// (set) Token: 0x0602452F RID: 148783 RVA: 0x0099A878 File Offset: 0x00998A78
		public unsafe UDirectionalLightComponent SceneLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004B63 RID: 19299
		// (get) Token: 0x06024530 RID: 148784 RVA: 0x0099A88D File Offset: 0x00998A8D
		// (set) Token: 0x06024531 RID: 148785 RVA: 0x0099A8A1 File Offset: 0x00998AA1
		public unsafe UDirectionalLightComponent AtmoMoonLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004B64 RID: 19300
		// (get) Token: 0x06024532 RID: 148786 RVA: 0x0099A8B6 File Offset: 0x00998AB6
		// (set) Token: 0x06024533 RID: 148787 RVA: 0x0099A8CA File Offset: 0x00998ACA
		public unsafe UDirectionalLightComponent AtmoSunLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004B65 RID: 19301
		// (get) Token: 0x06024534 RID: 148788 RVA: 0x0099A8DF File Offset: 0x00998ADF
		// (set) Token: 0x06024535 RID: 148789 RVA: 0x0099A8F3 File Offset: 0x00998AF3
		public unsafe USkyLightComponent SkyLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004B66 RID: 19302
		// (get) Token: 0x06024536 RID: 148790 RVA: 0x0099A908 File Offset: 0x00998B08
		// (set) Token: 0x06024537 RID: 148791 RVA: 0x0099A91C File Offset: 0x00998B1C
		public unsafe UExponentialHeightFogComponent HeightFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UExponentialHeightFogComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004B67 RID: 19303
		// (get) Token: 0x06024538 RID: 148792 RVA: 0x0099A931 File Offset: 0x00998B31
		// (set) Token: 0x06024539 RID: 148793 RVA: 0x0099A945 File Offset: 0x00998B45
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004B68 RID: 19304
		// (get) Token: 0x0602453A RID: 148794 RVA: 0x0099A95A File Offset: 0x00998B5A
		// (set) Token: 0x0602453B RID: 148795 RVA: 0x0099A96A File Offset: 0x00998B6A
		public unsafe float CharacterLightHorizontal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004B69 RID: 19305
		// (get) Token: 0x0602453C RID: 148796 RVA: 0x0099A97B File Offset: 0x00998B7B
		// (set) Token: 0x0602453D RID: 148797 RVA: 0x0099A98B File Offset: 0x00998B8B
		public unsafe float CurrTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004B6A RID: 19306
		// (get) Token: 0x0602453E RID: 148798 RVA: 0x0099A99C File Offset: 0x00998B9C
		// (set) Token: 0x0602453F RID: 148799 RVA: 0x0099A9AC File Offset: 0x00998BAC
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004B6B RID: 19307
		// (get) Token: 0x06024540 RID: 148800 RVA: 0x0099A9BD File Offset: 0x00998BBD
		// (set) Token: 0x06024541 RID: 148801 RVA: 0x0099A9CD File Offset: 0x00998BCD
		public unsafe bool EnableTODCycle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B6C RID: 19308
		// (get) Token: 0x06024542 RID: 148802 RVA: 0x0099A9DE File Offset: 0x00998BDE
		// (set) Token: 0x06024543 RID: 148803 RVA: 0x0099A9EE File Offset: 0x00998BEE
		public unsafe bool PauseTOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B6D RID: 19309
		// (get) Token: 0x06024544 RID: 148804 RVA: 0x0099A9FF File Offset: 0x00998BFF
		// (set) Token: 0x06024545 RID: 148805 RVA: 0x0099AA0F File Offset: 0x00998C0F
		public unsafe bool 编辑器下更新
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B6E RID: 19310
		// (get) Token: 0x06024546 RID: 148806 RVA: 0x0099AA20 File Offset: 0x00998C20
		// (set) Token: 0x06024547 RID: 148807 RVA: 0x0099AA30 File Offset: 0x00998C30
		public unsafe float TODCycleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004B6F RID: 19311
		// (get) Token: 0x06024548 RID: 148808 RVA: 0x0099AA41 File Offset: 0x00998C41
		// (set) Token: 0x06024549 RID: 148809 RVA: 0x0099AA55 File Offset: 0x00998C55
		public unsafe FRotator AtmosphereSunRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004B70 RID: 19312
		// (get) Token: 0x0602454A RID: 148810 RVA: 0x0099AA6A File Offset: 0x00998C6A
		// (set) Token: 0x0602454B RID: 148811 RVA: 0x0099AA7E File Offset: 0x00998C7E
		public unsafe FRotator SenenDirLightRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004B71 RID: 19313
		// (get) Token: 0x0602454C RID: 148812 RVA: 0x0099AA93 File Offset: 0x00998C93
		// (set) Token: 0x0602454D RID: 148813 RVA: 0x0099AAA3 File Offset: 0x00998CA3
		public unsafe float BP_SunHorizonAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004B72 RID: 19314
		// (get) Token: 0x0602454E RID: 148814 RVA: 0x0099AAB4 File Offset: 0x00998CB4
		// (set) Token: 0x0602454F RID: 148815 RVA: 0x0099AAC4 File Offset: 0x00998CC4
		public unsafe float BP_SunVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004B73 RID: 19315
		// (get) Token: 0x06024550 RID: 148816 RVA: 0x0099AAD5 File Offset: 0x00998CD5
		// (set) Token: 0x06024551 RID: 148817 RVA: 0x0099AAE5 File Offset: 0x00998CE5
		public unsafe float MainLightHorizonAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004B74 RID: 19316
		// (get) Token: 0x06024552 RID: 148818 RVA: 0x0099AAF6 File Offset: 0x00998CF6
		// (set) Token: 0x06024553 RID: 148819 RVA: 0x0099AB06 File Offset: 0x00998D06
		public unsafe float MainLightVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004B75 RID: 19317
		// (get) Token: 0x06024554 RID: 148820 RVA: 0x0099AB17 File Offset: 0x00998D17
		// (set) Token: 0x06024555 RID: 148821 RVA: 0x0099AB27 File Offset: 0x00998D27
		public unsafe float MainLightAngleLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004B76 RID: 19318
		// (get) Token: 0x06024556 RID: 148822 RVA: 0x0099AB38 File Offset: 0x00998D38
		// (set) Token: 0x06024557 RID: 148823 RVA: 0x0099AB48 File Offset: 0x00998D48
		public unsafe bool IsGIEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B77 RID: 19319
		// (get) Token: 0x06024558 RID: 148824 RVA: 0x0099AB59 File Offset: 0x00998D59
		// (set) Token: 0x06024559 RID: 148825 RVA: 0x0099AB69 File Offset: 0x00998D69
		public unsafe bool 使用随机的昼夜循环天气组
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B78 RID: 19320
		// (get) Token: 0x0602455A RID: 148826 RVA: 0x0099AB7A File Offset: 0x00998D7A
		// (set) Token: 0x0602455B RID: 148827 RVA: 0x0099AB8A File Offset: 0x00998D8A
		public unsafe int 当前的天气组索引值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004B79 RID: 19321
		// (get) Token: 0x0602455C RID: 148828 RVA: 0x0099AB9B File Offset: 0x00998D9B
		// (set) Token: 0x0602455D RID: 148829 RVA: 0x0099ABAF File Offset: 0x00998DAF
		public unsafe FLinearColor 太阳颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004B7A RID: 19322
		// (get) Token: 0x0602455E RID: 148830 RVA: 0x0099ABC4 File Offset: 0x00998DC4
		// (set) Token: 0x0602455F RID: 148831 RVA: 0x0099ABFD File Offset: 0x00998DFD
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
					result = (this._SunLightExistTime = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_31, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SunLightExistTime.CopyAssign(value);
			}
		}

		// Token: 0x17004B7B RID: 19323
		// (get) Token: 0x06024560 RID: 148832 RVA: 0x0099AC0C File Offset: 0x00998E0C
		// (set) Token: 0x06024561 RID: 148833 RVA: 0x0099AC45 File Offset: 0x00998E45
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
					result = (this._MoonLightExistTime = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_32, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MoonLightExistTime.CopyAssign(value);
			}
		}

		// Token: 0x17004B7C RID: 19324
		// (get) Token: 0x06024562 RID: 148834 RVA: 0x0099AC53 File Offset: 0x00998E53
		// (set) Token: 0x06024563 RID: 148835 RVA: 0x0099AC63 File Offset: 0x00998E63
		public unsafe bool 运行时自动开始循环
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B7D RID: 19325
		// (get) Token: 0x06024564 RID: 148836 RVA: 0x0099AC74 File Offset: 0x00998E74
		// (set) Token: 0x06024565 RID: 148837 RVA: 0x0099AC84 File Offset: 0x00998E84
		public unsafe bool UISceneRendering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B7E RID: 19326
		// (get) Token: 0x06024566 RID: 148838 RVA: 0x0099AC95 File Offset: 0x00998E95
		// (set) Token: 0x06024567 RID: 148839 RVA: 0x0099ACA9 File Offset: 0x00998EA9
		public unsafe PDA_GIUIData_C UIData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_GIUIData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_35);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_35, value);
			}
		}

		// Token: 0x17004B7F RID: 19327
		// (get) Token: 0x06024568 RID: 148840 RVA: 0x0099ACBE File Offset: 0x00998EBE
		// (set) Token: 0x06024569 RID: 148841 RVA: 0x0099ACCE File Offset: 0x00998ECE
		public unsafe bool DEBUG_UI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B80 RID: 19328
		// (get) Token: 0x0602456A RID: 148842 RVA: 0x0099ACDF File Offset: 0x00998EDF
		// (set) Token: 0x0602456B RID: 148843 RVA: 0x0099ACEF File Offset: 0x00998EEF
		public unsafe bool IsRootGI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B81 RID: 19329
		// (get) Token: 0x0602456C RID: 148844 RVA: 0x0099AD00 File Offset: 0x00998F00
		// (set) Token: 0x0602456D RID: 148845 RVA: 0x0099AD10 File Offset: 0x00998F10
		public unsafe bool IsEditorUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B82 RID: 19330
		// (get) Token: 0x0602456E RID: 148846 RVA: 0x0099AD21 File Offset: 0x00998F21
		// (set) Token: 0x0602456F RID: 148847 RVA: 0x0099AD31 File Offset: 0x00998F31
		public unsafe bool 更新角色光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B83 RID: 19331
		// (get) Token: 0x06024570 RID: 148848 RVA: 0x0099AD42 File Offset: 0x00998F42
		// (set) Token: 0x06024571 RID: 148849 RVA: 0x0099AD52 File Offset: 0x00998F52
		public unsafe bool 根据光源方向自动更新角色光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B84 RID: 19332
		// (get) Token: 0x06024572 RID: 148850 RVA: 0x0099AD63 File Offset: 0x00998F63
		// (set) Token: 0x06024573 RID: 148851 RVA: 0x0099AD73 File Offset: 0x00998F73
		public unsafe bool DEBUG_使用角色预览方向光
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B85 RID: 19333
		// (get) Token: 0x06024574 RID: 148852 RVA: 0x0099AD84 File Offset: 0x00998F84
		// (set) Token: 0x06024575 RID: 148853 RVA: 0x0099AD94 File Offset: 0x00998F94
		public unsafe float DEBUG_角色预览方向光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004B86 RID: 19334
		// (get) Token: 0x06024576 RID: 148854 RVA: 0x0099ADA5 File Offset: 0x00998FA5
		// (set) Token: 0x06024577 RID: 148855 RVA: 0x0099ADB5 File Offset: 0x00998FB5
		public unsafe int TotalDaysElapsed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17004B87 RID: 19335
		// (get) Token: 0x06024578 RID: 148856 RVA: 0x0099ADC6 File Offset: 0x00998FC6
		// (set) Token: 0x06024579 RID: 148857 RVA: 0x0099ADD6 File Offset: 0x00998FD6
		public unsafe float MoonFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17004B88 RID: 19336
		// (get) Token: 0x0602457A RID: 148858 RVA: 0x0099ADE7 File Offset: 0x00998FE7
		// (set) Token: 0x0602457B RID: 148859 RVA: 0x0099ADFB File Offset: 0x00998FFB
		public unsafe FVector2D MoonVisibleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17004B89 RID: 19337
		// (get) Token: 0x0602457C RID: 148860 RVA: 0x0099AE10 File Offset: 0x00999010
		// (set) Token: 0x0602457D RID: 148861 RVA: 0x0099AE20 File Offset: 0x00999020
		public unsafe bool 关闭雾效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B8A RID: 19338
		// (get) Token: 0x0602457E RID: 148862 RVA: 0x0099AE31 File Offset: 0x00999031
		// (set) Token: 0x0602457F RID: 148863 RVA: 0x0099AE41 File Offset: 0x00999041
		public unsafe bool RuntimeTimeEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B8B RID: 19339
		// (get) Token: 0x06024580 RID: 148864 RVA: 0x0099AE52 File Offset: 0x00999052
		// (set) Token: 0x06024581 RID: 148865 RVA: 0x0099AE62 File Offset: 0x00999062
		public unsafe float MainLightTickSecond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17004B8C RID: 19340
		// (get) Token: 0x06024582 RID: 148866 RVA: 0x0099AE73 File Offset: 0x00999073
		// (set) Token: 0x06024583 RID: 148867 RVA: 0x0099AE83 File Offset: 0x00999083
		public unsafe float MainLightTickCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17004B8D RID: 19341
		// (get) Token: 0x06024584 RID: 148868 RVA: 0x0099AE94 File Offset: 0x00999094
		// (set) Token: 0x06024585 RID: 148869 RVA: 0x0099AEA4 File Offset: 0x009990A4
		public unsafe bool ForceUpdateMainLightDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B8E RID: 19342
		// (get) Token: 0x06024586 RID: 148870 RVA: 0x0099AEB5 File Offset: 0x009990B5
		// (set) Token: 0x06024587 RID: 148871 RVA: 0x0099AEC5 File Offset: 0x009990C5
		public unsafe float WindDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17004B8F RID: 19343
		// (get) Token: 0x06024588 RID: 148872 RVA: 0x0099AED6 File Offset: 0x009990D6
		// (set) Token: 0x06024589 RID: 148873 RVA: 0x0099AEE6 File Offset: 0x009990E6
		public unsafe bool 使用临时雾效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_52) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_52) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B90 RID: 19344
		// (get) Token: 0x0602458A RID: 148874 RVA: 0x0099AEF7 File Offset: 0x009990F7
		// (set) Token: 0x0602458B RID: 148875 RVA: 0x0099AF07 File Offset: 0x00999107
		public unsafe bool 开启集群特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004B91 RID: 19345
		// (get) Token: 0x0602458C RID: 148876 RVA: 0x0099AF18 File Offset: 0x00999118
		// (set) Token: 0x0602458D RID: 148877 RVA: 0x0099AF2C File Offset: 0x0099912C
		public unsafe UMaterialInstance TempFogMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17004B92 RID: 19346
		// (get) Token: 0x0602458E RID: 148878 RVA: 0x0099AF41 File Offset: 0x00999141
		// (set) Token: 0x0602458F RID: 148879 RVA: 0x0099AF55 File Offset: 0x00999155
		public unsafe UMaterialInstanceDynamic TempFogDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_55);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x17004B93 RID: 19347
		// (get) Token: 0x06024590 RID: 148880 RVA: 0x0099AF6A File Offset: 0x0099916A
		// (set) Token: 0x06024591 RID: 148881 RVA: 0x0099AF7E File Offset: 0x0099917E
		public unsafe UMaterialInstanceDynamic SkyboxDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_56);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_56, value);
			}
		}

		// Token: 0x17004B94 RID: 19348
		// (get) Token: 0x06024592 RID: 148882 RVA: 0x0099AF93 File Offset: 0x00999193
		// (set) Token: 0x06024593 RID: 148883 RVA: 0x0099AFA7 File Offset: 0x009991A7
		public unsafe UMaterialInstance SkyboxMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_57);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_57, value);
			}
		}

		// Token: 0x17004B95 RID: 19349
		// (get) Token: 0x06024594 RID: 148884 RVA: 0x0099AFBC File Offset: 0x009991BC
		// (set) Token: 0x06024595 RID: 148885 RVA: 0x0099AFD0 File Offset: 0x009991D0
		public unsafe FLinearColor SunDiscColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17004B96 RID: 19350
		// (get) Token: 0x06024596 RID: 148886 RVA: 0x0099AFE5 File Offset: 0x009991E5
		// (set) Token: 0x06024597 RID: 148887 RVA: 0x0099AFF9 File Offset: 0x009991F9
		public unsafe FLinearColor SunScatterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x17004B97 RID: 19351
		// (get) Token: 0x06024598 RID: 148888 RVA: 0x0099B00E File Offset: 0x0099920E
		// (set) Token: 0x06024599 RID: 148889 RVA: 0x0099B01E File Offset: 0x0099921E
		public unsafe float SunSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17004B98 RID: 19352
		// (get) Token: 0x0602459A RID: 148890 RVA: 0x0099B02F File Offset: 0x0099922F
		// (set) Token: 0x0602459B RID: 148891 RVA: 0x0099B043 File Offset: 0x00999243
		public unsafe FLinearColor MoonDiscColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17004B99 RID: 19353
		// (get) Token: 0x0602459C RID: 148892 RVA: 0x0099B058 File Offset: 0x00999258
		// (set) Token: 0x0602459D RID: 148893 RVA: 0x0099B06C File Offset: 0x0099926C
		public unsafe FLinearColor MoonScatterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x17004B9A RID: 19354
		// (get) Token: 0x0602459E RID: 148894 RVA: 0x0099B081 File Offset: 0x00999281
		// (set) Token: 0x0602459F RID: 148895 RVA: 0x0099B091 File Offset: 0x00999291
		public unsafe float MoonSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_63);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_63) = value;
			}
		}

		// Token: 0x17004B9B RID: 19355
		// (get) Token: 0x060245A0 RID: 148896 RVA: 0x0099B0A2 File Offset: 0x009992A2
		// (set) Token: 0x060245A1 RID: 148897 RVA: 0x0099B0B6 File Offset: 0x009992B6
		public unsafe FLinearColor HorizonColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17004B9C RID: 19356
		// (get) Token: 0x060245A2 RID: 148898 RVA: 0x0099B0CB File Offset: 0x009992CB
		// (set) Token: 0x060245A3 RID: 148899 RVA: 0x0099B0DB File Offset: 0x009992DB
		public unsafe float HorizonFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17004B9D RID: 19357
		// (get) Token: 0x060245A4 RID: 148900 RVA: 0x0099B0EC File Offset: 0x009992EC
		// (set) Token: 0x060245A5 RID: 148901 RVA: 0x0099B100 File Offset: 0x00999300
		public unsafe FLinearColor ZenithColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17004B9E RID: 19358
		// (get) Token: 0x060245A6 RID: 148902 RVA: 0x0099B115 File Offset: 0x00999315
		// (set) Token: 0x060245A7 RID: 148903 RVA: 0x0099B125 File Offset: 0x00999325
		public unsafe float ExtremWeatherWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17004B9F RID: 19359
		// (get) Token: 0x060245A8 RID: 148904 RVA: 0x0099B136 File Offset: 0x00999336
		// (set) Token: 0x060245A9 RID: 148905 RVA: 0x0099B14A File Offset: 0x0099934A
		public unsafe FLinearColor ST_TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17004BA0 RID: 19360
		// (get) Token: 0x060245AA RID: 148906 RVA: 0x0099B15F File Offset: 0x0099935F
		// (set) Token: 0x060245AB RID: 148907 RVA: 0x0099B173 File Offset: 0x00999373
		public unsafe FLinearColor ST_DomeColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17004BA1 RID: 19361
		// (get) Token: 0x060245AC RID: 148908 RVA: 0x0099B188 File Offset: 0x00999388
		// (set) Token: 0x060245AD RID: 148909 RVA: 0x0099B198 File Offset: 0x00999398
		public unsafe float ST_TopWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17004BA2 RID: 19362
		// (get) Token: 0x060245AE RID: 148910 RVA: 0x0099B1A9 File Offset: 0x009993A9
		// (set) Token: 0x060245AF RID: 148911 RVA: 0x0099B1BD File Offset: 0x009993BD
		public unsafe UCurveFloat CharMainLightCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_71);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_71, value);
			}
		}

		// Token: 0x17004BA3 RID: 19363
		// (get) Token: 0x060245B0 RID: 148912 RVA: 0x0099B1D2 File Offset: 0x009993D2
		// (set) Token: 0x060245B1 RID: 148913 RVA: 0x0099B1E6 File Offset: 0x009993E6
		public unsafe UCurveFloat CharSkyLightCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_72);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_72, value);
			}
		}

		// Token: 0x17004BA4 RID: 19364
		// (get) Token: 0x060245B2 RID: 148914 RVA: 0x0099B1FB File Offset: 0x009993FB
		// (set) Token: 0x060245B3 RID: 148915 RVA: 0x0099B20B File Offset: 0x0099940B
		public unsafe bool UseCharCustomLighting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_73) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_73) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BA5 RID: 19365
		// (get) Token: 0x060245B4 RID: 148916 RVA: 0x0099B21C File Offset: 0x0099941C
		// (set) Token: 0x060245B5 RID: 148917 RVA: 0x0099B230 File Offset: 0x00999430
		public unsafe FLinearColor CharAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x17004BA6 RID: 19366
		// (get) Token: 0x060245B6 RID: 148918 RVA: 0x0099B245 File Offset: 0x00999445
		// (set) Token: 0x060245B7 RID: 148919 RVA: 0x0099B259 File Offset: 0x00999459
		public unsafe FLinearColor CharSkinAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17004BA7 RID: 19367
		// (get) Token: 0x060245B8 RID: 148920 RVA: 0x0099B26E File Offset: 0x0099946E
		// (set) Token: 0x060245B9 RID: 148921 RVA: 0x0099B282 File Offset: 0x00999482
		public unsafe UCurveFloat CharShadowCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_76);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_76, value);
			}
		}

		// Token: 0x17004BA8 RID: 19368
		// (get) Token: 0x060245BA RID: 148922 RVA: 0x0099B297 File Offset: 0x00999497
		// (set) Token: 0x060245BB RID: 148923 RVA: 0x0099B2AB File Offset: 0x009994AB
		public unsafe UMaterialInstance LightFunctionMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_77);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_77, value);
			}
		}

		// Token: 0x17004BA9 RID: 19369
		// (get) Token: 0x060245BC RID: 148924 RVA: 0x0099B2C0 File Offset: 0x009994C0
		// (set) Token: 0x060245BD RID: 148925 RVA: 0x0099B2D0 File Offset: 0x009994D0
		public unsafe float LightFunctionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x17004BAA RID: 19370
		// (get) Token: 0x060245BE RID: 148926 RVA: 0x0099B2E1 File Offset: 0x009994E1
		// (set) Token: 0x060245BF RID: 148927 RVA: 0x0099B2F5 File Offset: 0x009994F5
		public unsafe UMaterialInstanceDynamic LightFunctionDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_79);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_79, value);
			}
		}

		// Token: 0x17004BAB RID: 19371
		// (get) Token: 0x060245C0 RID: 148928 RVA: 0x0099B30A File Offset: 0x0099950A
		// (set) Token: 0x060245C1 RID: 148929 RVA: 0x0099B31A File Offset: 0x0099951A
		public unsafe bool DEBUG开启无音区特殊地表
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_80) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_80) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BAC RID: 19372
		// (get) Token: 0x060245C2 RID: 148930 RVA: 0x0099B32B File Offset: 0x0099952B
		// (set) Token: 0x060245C3 RID: 148931 RVA: 0x0099B33F File Offset: 0x0099953F
		public unsafe UMaterialInstance LensFlareMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_81);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_81, value);
			}
		}

		// Token: 0x17004BAD RID: 19373
		// (get) Token: 0x060245C4 RID: 148932 RVA: 0x0099B354 File Offset: 0x00999554
		// (set) Token: 0x060245C5 RID: 148933 RVA: 0x0099B368 File Offset: 0x00999568
		public unsafe UMaterialInstanceDynamic LensFlareDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_82);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_82, value);
			}
		}

		// Token: 0x17004BAE RID: 19374
		// (get) Token: 0x060245C6 RID: 148934 RVA: 0x0099B37D File Offset: 0x0099957D
		// (set) Token: 0x060245C7 RID: 148935 RVA: 0x0099B391 File Offset: 0x00999591
		public unsafe FLinearColor Nadir_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x17004BAF RID: 19375
		// (get) Token: 0x060245C8 RID: 148936 RVA: 0x0099B3A6 File Offset: 0x009995A6
		// (set) Token: 0x060245C9 RID: 148937 RVA: 0x0099B3B6 File Offset: 0x009995B6
		public unsafe float Nadir_Falloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17004BB0 RID: 19376
		// (get) Token: 0x060245CA RID: 148938 RVA: 0x0099B3C7 File Offset: 0x009995C7
		// (set) Token: 0x060245CB RID: 148939 RVA: 0x0099B3D7 File Offset: 0x009995D7
		public unsafe float Sun_Scatter_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17004BB1 RID: 19377
		// (get) Token: 0x060245CC RID: 148940 RVA: 0x0099B3E8 File Offset: 0x009995E8
		// (set) Token: 0x060245CD RID: 148941 RVA: 0x0099B3F8 File Offset: 0x009995F8
		public unsafe float Moon_Scatter_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_86);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_86) = value;
			}
		}

		// Token: 0x17004BB2 RID: 19378
		// (get) Token: 0x060245CE RID: 148942 RVA: 0x0099B409 File Offset: 0x00999609
		// (set) Token: 0x060245CF RID: 148943 RVA: 0x0099B419 File Offset: 0x00999619
		public unsafe float MainDirectionLightUpdateThreshold_Mobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_87);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x17004BB3 RID: 19379
		// (get) Token: 0x060245D0 RID: 148944 RVA: 0x0099B42A File Offset: 0x0099962A
		// (set) Token: 0x060245D1 RID: 148945 RVA: 0x0099B43A File Offset: 0x0099963A
		public unsafe float MainDirectionLightUpdateThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_88);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_88) = value;
			}
		}

		// Token: 0x17004BB4 RID: 19380
		// (get) Token: 0x060245D2 RID: 148946 RVA: 0x0099B44B File Offset: 0x0099964B
		// (set) Token: 0x060245D3 RID: 148947 RVA: 0x0099B45F File Offset: 0x0099965F
		public unsafe FVector GlobalWindDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x17004BB5 RID: 19381
		// (get) Token: 0x060245D4 RID: 148948 RVA: 0x0099B474 File Offset: 0x00999674
		// (set) Token: 0x060245D5 RID: 148949 RVA: 0x0099B488 File Offset: 0x00999688
		public unsafe FVector GlobalWindRightDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_90);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x17004BB6 RID: 19382
		// (get) Token: 0x060245D6 RID: 148950 RVA: 0x0099B49D File Offset: 0x0099969D
		// (set) Token: 0x060245D7 RID: 148951 RVA: 0x0099B4AD File Offset: 0x009996AD
		public unsafe float DEBUG无音区特殊地表强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_91);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_91) = value;
			}
		}

		// Token: 0x17004BB7 RID: 19383
		// (get) Token: 0x060245D8 RID: 148952 RVA: 0x0099B4BE File Offset: 0x009996BE
		// (set) Token: 0x060245D9 RID: 148953 RVA: 0x0099B4D2 File Offset: 0x009996D2
		public unsafe FLinearColor Character_Rim_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x17004BB8 RID: 19384
		// (get) Token: 0x060245DA RID: 148954 RVA: 0x0099B4E7 File Offset: 0x009996E7
		// (set) Token: 0x060245DB RID: 148955 RVA: 0x0099B4F7 File Offset: 0x009996F7
		public unsafe float RealTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x17004BB9 RID: 19385
		// (get) Token: 0x060245DC RID: 148956 RVA: 0x0099B508 File Offset: 0x00999708
		// (set) Token: 0x060245DD RID: 148957 RVA: 0x0099B51C File Offset: 0x0099971C
		public unsafe FRotator SunRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17004BBA RID: 19386
		// (get) Token: 0x060245DE RID: 148958 RVA: 0x0099B531 File Offset: 0x00999731
		// (set) Token: 0x060245DF RID: 148959 RVA: 0x0099B541 File Offset: 0x00999741
		public unsafe float DEBUG_角色预览方向光垂直方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x17004BBB RID: 19387
		// (get) Token: 0x060245E0 RID: 148960 RVA: 0x0099B552 File Offset: 0x00999752
		// (set) Token: 0x060245E1 RID: 148961 RVA: 0x0099B562 File Offset: 0x00999762
		public unsafe float UIWorldZOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17004BBC RID: 19388
		// (get) Token: 0x060245E2 RID: 148962 RVA: 0x0099B573 File Offset: 0x00999773
		// (set) Token: 0x060245E3 RID: 148963 RVA: 0x0099B583 File Offset: 0x00999783
		public unsafe bool UINeedLerpData
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_97) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_97) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BBD RID: 19389
		// (get) Token: 0x060245E4 RID: 148964 RVA: 0x0099B594 File Offset: 0x00999794
		// (set) Token: 0x060245E5 RID: 148965 RVA: 0x0099B5A4 File Offset: 0x009997A4
		public unsafe bool CanSpawnEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_98) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_98) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BBE RID: 19390
		// (get) Token: 0x060245E6 RID: 148966 RVA: 0x0099B5B5 File Offset: 0x009997B5
		// (set) Token: 0x060245E7 RID: 148967 RVA: 0x0099B5C5 File Offset: 0x009997C5
		public unsafe bool 编辑器下关闭LensFlare
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_99) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_99) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BBF RID: 19391
		// (get) Token: 0x060245E8 RID: 148968 RVA: 0x0099B5D6 File Offset: 0x009997D6
		// (set) Token: 0x060245E9 RID: 148969 RVA: 0x0099B5EA File Offset: 0x009997EA
		public unsafe UKuroGlobalColorMapComponent KuroGlobalColorMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGlobalColorMapComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_100);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_100, value);
			}
		}

		// Token: 0x17004BC0 RID: 19392
		// (get) Token: 0x060245EA RID: 148970 RVA: 0x0099B5FF File Offset: 0x009997FF
		// (set) Token: 0x060245EB RID: 148971 RVA: 0x0099B613 File Offset: 0x00999813
		public unsafe UKuroGlobalHeightMapComponent KuroGlobalHeightMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroGlobalHeightMapComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_101);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_101, value);
			}
		}

		// Token: 0x17004BC1 RID: 19393
		// (get) Token: 0x060245EC RID: 148972 RVA: 0x0099B628 File Offset: 0x00999828
		// (set) Token: 0x060245ED RID: 148973 RVA: 0x0099B638 File Offset: 0x00999838
		public unsafe bool IsComponentsEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_102) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_102) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BC2 RID: 19394
		// (get) Token: 0x060245EE RID: 148974 RVA: 0x0099B649 File Offset: 0x00999849
		// (set) Token: 0x060245EF RID: 148975 RVA: 0x0099B659 File Offset: 0x00999859
		public unsafe float DefaultSkyLightShadowSupplement
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17004BC3 RID: 19395
		// (get) Token: 0x060245F0 RID: 148976 RVA: 0x0099B66A File Offset: 0x0099986A
		// (set) Token: 0x060245F1 RID: 148977 RVA: 0x0099B67A File Offset: 0x0099987A
		public unsafe float DefaultSkyLightReflectionAddIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17004BC4 RID: 19396
		// (get) Token: 0x060245F2 RID: 148978 RVA: 0x0099B68B File Offset: 0x0099988B
		// (set) Token: 0x060245F3 RID: 148979 RVA: 0x0099B69F File Offset: 0x0099989F
		public unsafe UChildActorComponent RainOverrider
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_105);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_105, value);
			}
		}

		// Token: 0x17004BC5 RID: 19397
		// (get) Token: 0x060245F4 RID: 148980 RVA: 0x0099B6B4 File Offset: 0x009998B4
		// (set) Token: 0x060245F5 RID: 148981 RVA: 0x0099B6C8 File Offset: 0x009998C8
		public unsafe BP_Clouds_C DynamicCloudsActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_Clouds_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_106);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_106, value);
			}
		}

		// Token: 0x17004BC6 RID: 19398
		// (get) Token: 0x060245F6 RID: 148982 RVA: 0x0099B6DD File Offset: 0x009998DD
		// (set) Token: 0x060245F7 RID: 148983 RVA: 0x0099B6ED File Offset: 0x009998ED
		public unsafe float Clouds_Change_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_107);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_107) = value;
			}
		}

		// Token: 0x17004BC7 RID: 19399
		// (get) Token: 0x060245F8 RID: 148984 RVA: 0x0099B6FE File Offset: 0x009998FE
		// (set) Token: 0x060245F9 RID: 148985 RVA: 0x0099B712 File Offset: 0x00999912
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroDynamicCloudType> LocalDynamicCloudsType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_108);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_108) = value;
			}
		}

		// Token: 0x17004BC8 RID: 19400
		// (get) Token: 0x060245FA RID: 148986 RVA: 0x0099B727 File Offset: 0x00999927
		// (set) Token: 0x060245FB RID: 148987 RVA: 0x0099B737 File Offset: 0x00999937
		public unsafe float Clouds_Change_CD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_109);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_109) = value;
			}
		}

		// Token: 0x17004BC9 RID: 19401
		// (get) Token: 0x060245FC RID: 148988 RVA: 0x0099B748 File Offset: 0x00999948
		// (set) Token: 0x060245FD RID: 148989 RVA: 0x0099B758 File Offset: 0x00999958
		public unsafe bool Is_Editor_Update
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_110) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_110) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BCA RID: 19402
		// (get) Token: 0x060245FE RID: 148990 RVA: 0x0099B769 File Offset: 0x00999969
		// (set) Token: 0x060245FF RID: 148991 RVA: 0x0099B779 File Offset: 0x00999979
		public unsafe bool 启用时间参数写入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_111) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_111) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BCB RID: 19403
		// (get) Token: 0x06024600 RID: 148992 RVA: 0x0099B78A File Offset: 0x0099998A
		// (set) Token: 0x06024601 RID: 148993 RVA: 0x0099B79E File Offset: 0x0099999E
		public unsafe UTexture InitLightFunctionMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_112);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_112, value);
			}
		}

		// Token: 0x17004BCC RID: 19404
		// (get) Token: 0x06024602 RID: 148994 RVA: 0x0099B7B3 File Offset: 0x009999B3
		// (set) Token: 0x06024603 RID: 148995 RVA: 0x0099B7C7 File Offset: 0x009999C7
		public unsafe UMaterialInstance StarsMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_113);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_113, value);
			}
		}

		// Token: 0x17004BCD RID: 19405
		// (get) Token: 0x06024604 RID: 148996 RVA: 0x0099B7DC File Offset: 0x009999DC
		// (set) Token: 0x06024605 RID: 148997 RVA: 0x0099B7F0 File Offset: 0x009999F0
		public unsafe UStaticMeshComponent SM_Stars
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_114);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_114, value);
			}
		}

		// Token: 0x17004BCE RID: 19406
		// (get) Token: 0x06024606 RID: 148998 RVA: 0x0099B805 File Offset: 0x00999A05
		// (set) Token: 0x06024607 RID: 148999 RVA: 0x0099B819 File Offset: 0x00999A19
		public unsafe UMaterialInstance MilkyWayMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_115);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_115, value);
			}
		}

		// Token: 0x17004BCF RID: 19407
		// (get) Token: 0x06024608 RID: 149000 RVA: 0x0099B82E File Offset: 0x00999A2E
		// (set) Token: 0x06024609 RID: 149001 RVA: 0x0099B842 File Offset: 0x00999A42
		public unsafe UStaticMeshComponent SM_MilkyWay
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_116);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_116, value);
			}
		}

		// Token: 0x17004BD0 RID: 19408
		// (get) Token: 0x0602460A RID: 149002 RVA: 0x0099B857 File Offset: 0x00999A57
		// (set) Token: 0x0602460B RID: 149003 RVA: 0x0099B86B File Offset: 0x00999A6B
		public unsafe UStaticMeshComponent CloudOcean
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_117);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_LaunchScene_C.__PropertyOffset_117, value);
			}
		}

		// Token: 0x17004BD1 RID: 19409
		// (get) Token: 0x0602460C RID: 149004 RVA: 0x0099B880 File Offset: 0x00999A80
		// (set) Token: 0x0602460D RID: 149005 RVA: 0x0099B8B9 File Offset: 0x00999AB9
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
					result = (this._FogTImeControl = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_118, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_GlobalGI_LaunchScene_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602460E RID: 149006 RVA: 0x0099B8DA File Offset: 0x00999ADA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Dynamic_Clouds()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Update_Dynamic_Clouds_NativeFunctionPtr, null);
		}

		// Token: 0x0602460F RID: 149007 RVA: 0x0099B8EE File Offset: 0x00999AEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Big_World()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Update_Big_World_NativeFunctionPtr, null);
		}

		// Token: 0x06024610 RID: 149008 RVA: 0x0099B902 File Offset: 0x00999B02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void On_Global_GITick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__On_Global_GITick_NativeFunctionPtr, null);
		}

		// Token: 0x06024611 RID: 149009 RVA: 0x0099B916 File Offset: 0x00999B16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateEditor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateEditor_NativeFunctionPtr, null);
		}

		// Token: 0x06024612 RID: 149010 RVA: 0x0099B92C File Offset: 0x00999B2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloudCard(ref FKuroCloudCardSetting CloudCardSetting)
		{
			BP_GlobalGI_LaunchScene_C.__UpdateCloudCard_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__UpdateCloudCard_FunctionParams[(UIntPtr)179] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__UpdateCloudCard_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__UpdateCloudCard_NativeFunctionPtr, (void*)ptr, 1);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCloudCardSetting.StaticStruct(), &ptr->CloudCardSetting, CloudCardSetting.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateCloudCard_NativeFunctionPtr, (void*)ptr);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCloudCardSetting.StaticStruct(), CloudCardSetting.NativePtr, &ptr->CloudCardSetting, 1, false);
			}
		}

		// Token: 0x06024613 RID: 149011 RVA: 0x0099B9B8 File Offset: 0x00999BB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTODCharacterLighting(FLinearColor mainLight, float mainLightIntensity, FLinearColor skyLight, float skyLightIntensity, ref FLinearColor FrontSideLight, ref FLinearColor BackSideLight)
		{
			BP_GlobalGI_LaunchScene_C.__GetTODCharacterLighting_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__GetTODCharacterLighting_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__GetTODCharacterLighting_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__GetTODCharacterLighting_NativeFunctionPtr, (void*)ptr, 1);
			ptr->mainLight = mainLight;
			ptr->mainLightIntensity = mainLightIntensity;
			ptr->skyLight = skyLight;
			ptr->skyLightIntensity = skyLightIntensity;
			ptr->FrontSideLight = FrontSideLight;
			ptr->BackSideLight = BackSideLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__GetTODCharacterLighting_NativeFunctionPtr, (void*)ptr);
			FrontSideLight = ptr->FrontSideLight;
			BackSideLight = ptr->BackSideLight;
		}

		// Token: 0x06024614 RID: 149012 RVA: 0x0099BA4C File Offset: 0x00999C4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FLinearColor Clamp_Luminance(FLinearColor InColor, float Min, float Max)
		{
			BP_GlobalGI_LaunchScene_C.__Clamp_Luminance_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Clamp_Luminance_FunctionParams[(UIntPtr)123] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Clamp_Luminance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Clamp_Luminance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InColor = InColor;
			ptr->Min = Min;
			ptr->Max = Max;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Clamp_Luminance_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06024615 RID: 149013 RVA: 0x0099BAA8 File Offset: 0x00999CA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector EulerToForward(float Pitch, float Yaw)
		{
			BP_GlobalGI_LaunchScene_C.__EulerToForward_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__EulerToForward_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__EulerToForward_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__EulerToForward_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Pitch = Pitch;
			ptr->Yaw = Yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__EulerToForward_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06024616 RID: 149014 RVA: 0x0099BAFC File Offset: 0x00999CFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSkyboxDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_LaunchScene_C.__GetSkyboxDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__GetSkyboxDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__GetSkyboxDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__GetSkyboxDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_LaunchScene_C.__GetSkyboxDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__GetSkyboxDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x06024617 RID: 149015 RVA: 0x0099BB60 File Offset: 0x00999D60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMisc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateMisc_NativeFunctionPtr, null);
		}

		// Token: 0x06024618 RID: 149016 RVA: 0x0099BB74 File Offset: 0x00999D74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTrulyTime(ref float CurTime)
		{
			BP_GlobalGI_LaunchScene_C.__GetTrulyTime_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__GetTrulyTime_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__GetTrulyTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__GetTrulyTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurTime = CurTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__GetTrulyTime_NativeFunctionPtr, (void*)ptr);
			CurTime = ptr->CurTime;
		}

		// Token: 0x06024619 RID: 149017 RVA: 0x0099BBC3 File Offset: 0x00999DC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 申时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__申时_NativeFunctionPtr, null);
		}

		// Token: 0x0602461A RID: 149018 RVA: 0x0099BBD7 File Offset: 0x00999DD7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 下午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__下午_NativeFunctionPtr, null);
		}

		// Token: 0x0602461B RID: 149019 RVA: 0x0099BBEB File Offset: 0x00999DEB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 上午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__上午_NativeFunctionPtr, null);
		}

		// Token: 0x0602461C RID: 149020 RVA: 0x0099BBFF File Offset: 0x00999DFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 辰时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__辰时_NativeFunctionPtr, null);
		}

		// Token: 0x0602461D RID: 149021 RVA: 0x0099BC13 File Offset: 0x00999E13
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDayNightDataLayer()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateDayNightDataLayer_NativeFunctionPtr, null);
		}

		// Token: 0x0602461E RID: 149022 RVA: 0x0099BC27 File Offset: 0x00999E27
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x0602461F RID: 149023 RVA: 0x0099BC3B File Offset: 0x00999E3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 夜晚到清晨()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__夜晚到清晨_NativeFunctionPtr, null);
		}

		// Token: 0x06024620 RID: 149024 RVA: 0x0099BC4F File Offset: 0x00999E4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 黄昏到夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__黄昏到夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024621 RID: 149025 RVA: 0x0099BC63 File Offset: 0x00999E63
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 黄昏()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__黄昏_NativeFunctionPtr, null);
		}

		// Token: 0x06024622 RID: 149026 RVA: 0x0099BC77 File Offset: 0x00999E77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 中午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__中午_NativeFunctionPtr, null);
		}

		// Token: 0x06024623 RID: 149027 RVA: 0x0099BC8B File Offset: 0x00999E8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 清晨()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__清晨_NativeFunctionPtr, null);
		}

		// Token: 0x06024624 RID: 149028 RVA: 0x0099BC9F File Offset: 0x00999E9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetSkyDomeActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__GetSkyDomeActor_NativeFunctionPtr, null);
		}

		// Token: 0x06024625 RID: 149029 RVA: 0x0099BCB4 File Offset: 0x00999EB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Total_TOD_Time_Elapsed(ref float Time)
		{
			BP_GlobalGI_LaunchScene_C.__Get_Total_TOD_Time_Elapsed_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Get_Total_TOD_Time_Elapsed_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Get_Total_TOD_Time_Elapsed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Get_Total_TOD_Time_Elapsed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Get_Total_TOD_Time_Elapsed_NativeFunctionPtr, (void*)ptr);
			Time = ptr->Time;
		}

		// Token: 0x06024626 RID: 149030 RVA: 0x0099BD03 File Offset: 0x00999F03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkyDome()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateSkyDome_NativeFunctionPtr, null);
		}

		// Token: 0x06024627 RID: 149031 RVA: 0x0099BD17 File Offset: 0x00999F17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__InitGI_NativeFunctionPtr, null);
		}

		// Token: 0x06024628 RID: 149032 RVA: 0x0099BD2C File Offset: 0x00999F2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_All_Components_States(bool IsEnable)
		{
			BP_GlobalGI_LaunchScene_C.__Set_All_Components_States_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Set_All_Components_States_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Set_All_Components_States_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Set_All_Components_States_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEnable = IsEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Set_All_Components_States_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024629 RID: 149033 RVA: 0x0099BD74 File Offset: 0x00999F74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetUIComponentsVisibility(bool IsVisible)
		{
			BP_GlobalGI_LaunchScene_C.__SetUIComponentsVisibility_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__SetUIComponentsVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__SetUIComponentsVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__SetUIComponentsVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsVisible = IsVisible;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__SetUIComponentsVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602462A RID: 149034 RVA: 0x0099BDBC File Offset: 0x00999FBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLightDirectionFromVH(float Vertical, float Horizontal, ref FRotator Result)
		{
			BP_GlobalGI_LaunchScene_C.__GetLightDirectionFromVH_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__GetLightDirectionFromVH_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__GetLightDirectionFromVH_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__GetLightDirectionFromVH_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vertical = Vertical;
			ptr->Horizontal = Horizontal;
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__GetLightDirectionFromVH_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602462B RID: 149035 RVA: 0x0099BE21 File Offset: 0x0099A021
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Main_Light_Direction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Update_Main_Light_Direction_NativeFunctionPtr, null);
		}

		// Token: 0x0602462C RID: 149036 RVA: 0x0099BE35 File Offset: 0x0099A035
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMainLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateMainLight_NativeFunctionPtr, null);
		}

		// Token: 0x0602462D RID: 149037 RVA: 0x0099BE49 File Offset: 0x0099A049
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateTime_NativeFunctionPtr, null);
		}

		// Token: 0x0602462E RID: 149038 RVA: 0x0099BE60 File Offset: 0x0099A060
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetViewLocation(ref FVector WorldPosition, ref bool Suc)
		{
			BP_GlobalGI_LaunchScene_C.__GetViewLocation_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__GetViewLocation_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__GetViewLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__GetViewLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->WorldPosition = WorldPosition;
			ptr->Suc = Suc;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__GetViewLocation_NativeFunctionPtr, (void*)ptr);
			WorldPosition = ptr->WorldPosition;
			Suc = ptr->Suc;
		}

		// Token: 0x0602462F RID: 149039 RVA: 0x0099BEC7 File Offset: 0x0099A0C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitFeature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__InitFeature_NativeFunctionPtr, null);
		}

		// Token: 0x06024630 RID: 149040 RVA: 0x0099BEDC File Offset: 0x0099A0DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalulateLightDirectionWithLimit(float V, float H, float Time, ref FRotator NewParam)
		{
			BP_GlobalGI_LaunchScene_C.__CalulateLightDirectionWithLimit_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__CalulateLightDirectionWithLimit_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__CalulateLightDirectionWithLimit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__CalulateLightDirectionWithLimit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V = V;
			ptr->H = H;
			ptr->Time = Time;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__CalulateLightDirectionWithLimit_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06024631 RID: 149041 RVA: 0x0099BF50 File Offset: 0x0099A150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateLightDirection(float Vertical, float Horizontal, float Time, ref FRotator NewParam)
		{
			BP_GlobalGI_LaunchScene_C.__CalculateLightDirection_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__CalculateLightDirection_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__CalculateLightDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__CalculateLightDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vertical = Vertical;
			ptr->Horizontal = Horizontal;
			ptr->Time = Time;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__CalculateLightDirection_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06024632 RID: 149042 RVA: 0x0099BFC0 File Offset: 0x0099A1C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Scene_Light_Rotator(ref FRotator SunLight, ref FRotator NightLight)
		{
			BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Rotator_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Rotator_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Rotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Rotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SunLight = SunLight;
			ptr->NightLight = NightLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Rotator_NativeFunctionPtr, (void*)ptr);
			SunLight = ptr->SunLight;
			NightLight = ptr->NightLight;
		}

		// Token: 0x06024633 RID: 149043 RVA: 0x0099C030 File Offset: 0x0099A230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Scene_Light_Direction(ref FVector LightDir)
		{
			BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Direction_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Direction_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Direction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Direction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LightDir = LightDir;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Get_Scene_Light_Direction_NativeFunctionPtr, (void*)ptr);
			LightDir = ptr->LightDir;
		}

		// Token: 0x06024634 RID: 149044 RVA: 0x0099C087 File Offset: 0x0099A287
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGICompoemnt()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__InitGICompoemnt_NativeFunctionPtr, null);
		}

		// Token: 0x06024635 RID: 149045 RVA: 0x0099C09C File Offset: 0x0099A29C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Light_Rotator(ref FRotator SunLight, ref FRotator NightLight)
		{
			BP_GlobalGI_LaunchScene_C.__Get_Light_Rotator_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Get_Light_Rotator_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Get_Light_Rotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Get_Light_Rotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SunLight = SunLight;
			ptr->NightLight = NightLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Get_Light_Rotator_NativeFunctionPtr, (void*)ptr);
			SunLight = ptr->SunLight;
			NightLight = ptr->NightLight;
		}

		// Token: 0x06024636 RID: 149046 RVA: 0x0099C10C File Offset: 0x0099A30C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Light_Direction(ref FVector SunLight, ref FVector NightLight)
		{
			BP_GlobalGI_LaunchScene_C.__Get_Light_Direction_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Get_Light_Direction_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Get_Light_Direction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Get_Light_Direction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SunLight = SunLight;
			ptr->NightLight = NightLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Get_Light_Direction_NativeFunctionPtr, (void*)ptr);
			SunLight = ptr->SunLight;
			NightLight = ptr->NightLight;
		}

		// Token: 0x06024637 RID: 149047 RVA: 0x0099C17B File Offset: 0x0099A37B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMaterials()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__InitMaterials_NativeFunctionPtr, null);
		}

		// Token: 0x06024638 RID: 149048 RVA: 0x0099C190 File Offset: 0x0099A390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Is_Day(ref bool Result)
		{
			BP_GlobalGI_LaunchScene_C.__Is_Day_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__Is_Day_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__Is_Day_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__Is_Day_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Is_Day_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x06024639 RID: 149049 RVA: 0x0099C1DF File Offset: 0x0099A3DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Env()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Update_Env_NativeFunctionPtr, null);
		}

		// Token: 0x0602463A RID: 149050 RVA: 0x0099C1F3 File Offset: 0x0099A3F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Fog()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__Update_Fog_NativeFunctionPtr, null);
		}

		// Token: 0x0602463B RID: 149051 RVA: 0x0099C208 File Offset: 0x0099A408
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateGIData(bool SkipLerpData)
		{
			BP_GlobalGI_LaunchScene_C.__UpdateGIData_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__UpdateGIData_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__UpdateGIData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__UpdateGIData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SkipLerpData = SkipLerpData;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UpdateGIData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602463C RID: 149052 RVA: 0x0099C24E File Offset: 0x0099A44E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602463D RID: 149053 RVA: 0x0099C262 File Offset: 0x0099A462
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602463E RID: 149054 RVA: 0x0099C278 File Offset: 0x0099A478
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroTickEditor(float DeltaTime)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602463F RID: 149055 RVA: 0x0099C2C0 File Offset: 0x0099A4C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroTickEditor_Implementation(float DeltaTime)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024640 RID: 149056 RVA: 0x0099C308 File Offset: 0x0099A508
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroTick(float DeltaTime)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroTick_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024641 RID: 149057 RVA: 0x0099C350 File Offset: 0x0099A550
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroTick_Implementation(float DeltaTime)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroTick_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024642 RID: 149058 RVA: 0x0099C397 File Offset: 0x0099A597
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024643 RID: 149059 RVA: 0x0099C3AB File Offset: 0x0099A5AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024644 RID: 149060 RVA: 0x0099C3C0 File Offset: 0x0099A5C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroSetRuntimeTime(float CurrentTime)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentTime = CurrentTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024645 RID: 149061 RVA: 0x0099C408 File Offset: 0x0099A608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroSetRuntimeTime_Implementation(float CurrentTime)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentTime = CurrentTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024646 RID: 149062 RVA: 0x0099C450 File Offset: 0x0099A650
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroStartUiScene(string InName, [Nullable(2)] ULevel InUILevel)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->InName), InName);
			ptr->InUILevel = ((InUILevel != null) ? InUILevel.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024647 RID: 149063 RVA: 0x0099C4C4 File Offset: 0x0099A6C4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroStartUiScene_Implementation(string InName, [Nullable(2)] ULevel InUILevel)
		{
			BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->InName), InName);
			ptr->InUILevel = ((InUILevel != null) ? InUILevel.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 0);
			UnrealReflectionUtils.DestroyStruct(BP_GlobalGI_LaunchScene_C.__OnKuroStartUiScene_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024648 RID: 149064 RVA: 0x0099C538 File Offset: 0x0099A738
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroEndUiScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroEndUiScene_NativeFunctionPtr, null);
		}

		// Token: 0x06024649 RID: 149065 RVA: 0x0099C54C File Offset: 0x0099A74C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroEndUiScene_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__OnKuroEndUiScene_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602464A RID: 149066 RVA: 0x0099C564 File Offset: 0x0099A764
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GlobalGI_LaunchScene(int EntryPoint)
		{
			BP_GlobalGI_LaunchScene_C.__ExecuteUbergraph_BP_GlobalGI_LaunchScene_FunctionParams* ptr = stackalloc BP_GlobalGI_LaunchScene_C.__ExecuteUbergraph_BP_GlobalGI_LaunchScene_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_GlobalGI_LaunchScene_C.__ExecuteUbergraph_BP_GlobalGI_LaunchScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_LaunchScene_C.__ExecuteUbergraph_BP_GlobalGI_LaunchScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_LaunchScene_C.__ExecuteUbergraph_BP_GlobalGI_LaunchScene_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602464B RID: 149067 RVA: 0x0099C5AB File Offset: 0x0099A7AB
		protected BP_GlobalGI_LaunchScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012976 RID: 76150
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI_LaunchScene.BP_GlobalGI_LaunchScene_C";

		// Token: 0x04012977 RID: 76151
		private static IntPtr _ClassPtr;

		// Token: 0x04012978 RID: 76152
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012979 RID: 76153
		internal static int __PropertyOffset_0;

		// Token: 0x0401297A RID: 76154
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401297B RID: 76155
		internal static int __PropertyOffset_1;

		// Token: 0x0401297C RID: 76156
		internal static int __PropertyOffset_2;

		// Token: 0x0401297D RID: 76157
		internal static int __PropertyOffset_3;

		// Token: 0x0401297E RID: 76158
		internal static int __PropertyOffset_4;

		// Token: 0x0401297F RID: 76159
		internal static int __PropertyOffset_5;

		// Token: 0x04012980 RID: 76160
		internal static int __PropertyOffset_6;

		// Token: 0x04012981 RID: 76161
		internal static int __PropertyOffset_7;

		// Token: 0x04012982 RID: 76162
		internal static int __PropertyOffset_8;

		// Token: 0x04012983 RID: 76163
		internal static int __PropertyOffset_9;

		// Token: 0x04012984 RID: 76164
		internal static int __PropertyOffset_10;

		// Token: 0x04012985 RID: 76165
		internal static int __PropertyOffset_11;

		// Token: 0x04012986 RID: 76166
		internal static int __PropertyOffset_12;

		// Token: 0x04012987 RID: 76167
		internal static int __PropertyOffset_13;

		// Token: 0x04012988 RID: 76168
		internal static int __PropertyOffset_14;

		// Token: 0x04012989 RID: 76169
		internal static int __PropertyOffset_15;

		// Token: 0x0401298A RID: 76170
		internal static int __PropertyOffset_16;

		// Token: 0x0401298B RID: 76171
		internal static int __PropertyOffset_17;

		// Token: 0x0401298C RID: 76172
		internal static int __PropertyOffset_18;

		// Token: 0x0401298D RID: 76173
		internal static int __PropertyOffset_19;

		// Token: 0x0401298E RID: 76174
		internal static int __PropertyOffset_20;

		// Token: 0x0401298F RID: 76175
		internal static int __PropertyOffset_21;

		// Token: 0x04012990 RID: 76176
		internal static int __PropertyOffset_22;

		// Token: 0x04012991 RID: 76177
		internal static int __PropertyOffset_23;

		// Token: 0x04012992 RID: 76178
		internal static int __PropertyOffset_24;

		// Token: 0x04012993 RID: 76179
		internal static int __PropertyOffset_25;

		// Token: 0x04012994 RID: 76180
		internal static int __PropertyOffset_26;

		// Token: 0x04012995 RID: 76181
		internal static int __PropertyOffset_27;

		// Token: 0x04012996 RID: 76182
		internal static int __PropertyOffset_28;

		// Token: 0x04012997 RID: 76183
		internal static int __PropertyOffset_29;

		// Token: 0x04012998 RID: 76184
		internal static int __PropertyOffset_30;

		// Token: 0x04012999 RID: 76185
		internal static int __PropertyOffset_31;

		// Token: 0x0401299A RID: 76186
		private TArray<FVector2D> _SunLightExistTime;

		// Token: 0x0401299B RID: 76187
		internal static int __PropertyOffset_32;

		// Token: 0x0401299C RID: 76188
		private TArray<FVector2D> _MoonLightExistTime;

		// Token: 0x0401299D RID: 76189
		internal static int __PropertyOffset_33;

		// Token: 0x0401299E RID: 76190
		internal static int __PropertyOffset_34;

		// Token: 0x0401299F RID: 76191
		internal static int __PropertyOffset_35;

		// Token: 0x040129A0 RID: 76192
		internal static int __PropertyOffset_36;

		// Token: 0x040129A1 RID: 76193
		internal static int __PropertyOffset_37;

		// Token: 0x040129A2 RID: 76194
		internal static int __PropertyOffset_38;

		// Token: 0x040129A3 RID: 76195
		internal static int __PropertyOffset_39;

		// Token: 0x040129A4 RID: 76196
		internal static int __PropertyOffset_40;

		// Token: 0x040129A5 RID: 76197
		internal static int __PropertyOffset_41;

		// Token: 0x040129A6 RID: 76198
		internal static int __PropertyOffset_42;

		// Token: 0x040129A7 RID: 76199
		internal static int __PropertyOffset_43;

		// Token: 0x040129A8 RID: 76200
		internal static int __PropertyOffset_44;

		// Token: 0x040129A9 RID: 76201
		internal static int __PropertyOffset_45;

		// Token: 0x040129AA RID: 76202
		internal static int __PropertyOffset_46;

		// Token: 0x040129AB RID: 76203
		internal static int __PropertyOffset_47;

		// Token: 0x040129AC RID: 76204
		internal static int __PropertyOffset_48;

		// Token: 0x040129AD RID: 76205
		internal static int __PropertyOffset_49;

		// Token: 0x040129AE RID: 76206
		internal static int __PropertyOffset_50;

		// Token: 0x040129AF RID: 76207
		internal static int __PropertyOffset_51;

		// Token: 0x040129B0 RID: 76208
		internal static int __PropertyOffset_52;

		// Token: 0x040129B1 RID: 76209
		internal static int __PropertyOffset_53;

		// Token: 0x040129B2 RID: 76210
		internal static int __PropertyOffset_54;

		// Token: 0x040129B3 RID: 76211
		internal static int __PropertyOffset_55;

		// Token: 0x040129B4 RID: 76212
		internal static int __PropertyOffset_56;

		// Token: 0x040129B5 RID: 76213
		internal static int __PropertyOffset_57;

		// Token: 0x040129B6 RID: 76214
		internal static int __PropertyOffset_58;

		// Token: 0x040129B7 RID: 76215
		internal static int __PropertyOffset_59;

		// Token: 0x040129B8 RID: 76216
		internal static int __PropertyOffset_60;

		// Token: 0x040129B9 RID: 76217
		internal static int __PropertyOffset_61;

		// Token: 0x040129BA RID: 76218
		internal static int __PropertyOffset_62;

		// Token: 0x040129BB RID: 76219
		internal static int __PropertyOffset_63;

		// Token: 0x040129BC RID: 76220
		internal static int __PropertyOffset_64;

		// Token: 0x040129BD RID: 76221
		internal static int __PropertyOffset_65;

		// Token: 0x040129BE RID: 76222
		internal static int __PropertyOffset_66;

		// Token: 0x040129BF RID: 76223
		internal static int __PropertyOffset_67;

		// Token: 0x040129C0 RID: 76224
		internal static int __PropertyOffset_68;

		// Token: 0x040129C1 RID: 76225
		internal static int __PropertyOffset_69;

		// Token: 0x040129C2 RID: 76226
		internal static int __PropertyOffset_70;

		// Token: 0x040129C3 RID: 76227
		internal static int __PropertyOffset_71;

		// Token: 0x040129C4 RID: 76228
		internal static int __PropertyOffset_72;

		// Token: 0x040129C5 RID: 76229
		internal static int __PropertyOffset_73;

		// Token: 0x040129C6 RID: 76230
		internal static int __PropertyOffset_74;

		// Token: 0x040129C7 RID: 76231
		internal static int __PropertyOffset_75;

		// Token: 0x040129C8 RID: 76232
		internal static int __PropertyOffset_76;

		// Token: 0x040129C9 RID: 76233
		internal static int __PropertyOffset_77;

		// Token: 0x040129CA RID: 76234
		internal static int __PropertyOffset_78;

		// Token: 0x040129CB RID: 76235
		internal static int __PropertyOffset_79;

		// Token: 0x040129CC RID: 76236
		internal static int __PropertyOffset_80;

		// Token: 0x040129CD RID: 76237
		internal static int __PropertyOffset_81;

		// Token: 0x040129CE RID: 76238
		internal static int __PropertyOffset_82;

		// Token: 0x040129CF RID: 76239
		internal static int __PropertyOffset_83;

		// Token: 0x040129D0 RID: 76240
		internal static int __PropertyOffset_84;

		// Token: 0x040129D1 RID: 76241
		internal static int __PropertyOffset_85;

		// Token: 0x040129D2 RID: 76242
		internal static int __PropertyOffset_86;

		// Token: 0x040129D3 RID: 76243
		internal static int __PropertyOffset_87;

		// Token: 0x040129D4 RID: 76244
		internal static int __PropertyOffset_88;

		// Token: 0x040129D5 RID: 76245
		internal static int __PropertyOffset_89;

		// Token: 0x040129D6 RID: 76246
		internal static int __PropertyOffset_90;

		// Token: 0x040129D7 RID: 76247
		internal static int __PropertyOffset_91;

		// Token: 0x040129D8 RID: 76248
		internal static int __PropertyOffset_92;

		// Token: 0x040129D9 RID: 76249
		internal static int __PropertyOffset_93;

		// Token: 0x040129DA RID: 76250
		internal static int __PropertyOffset_94;

		// Token: 0x040129DB RID: 76251
		internal static int __PropertyOffset_95;

		// Token: 0x040129DC RID: 76252
		internal static int __PropertyOffset_96;

		// Token: 0x040129DD RID: 76253
		internal static int __PropertyOffset_97;

		// Token: 0x040129DE RID: 76254
		internal static int __PropertyOffset_98;

		// Token: 0x040129DF RID: 76255
		internal static int __PropertyOffset_99;

		// Token: 0x040129E0 RID: 76256
		internal static int __PropertyOffset_100;

		// Token: 0x040129E1 RID: 76257
		internal static int __PropertyOffset_101;

		// Token: 0x040129E2 RID: 76258
		internal static int __PropertyOffset_102;

		// Token: 0x040129E3 RID: 76259
		internal static int __PropertyOffset_103;

		// Token: 0x040129E4 RID: 76260
		internal static int __PropertyOffset_104;

		// Token: 0x040129E5 RID: 76261
		internal static int __PropertyOffset_105;

		// Token: 0x040129E6 RID: 76262
		internal static int __PropertyOffset_106;

		// Token: 0x040129E7 RID: 76263
		internal static int __PropertyOffset_107;

		// Token: 0x040129E8 RID: 76264
		internal static int __PropertyOffset_108;

		// Token: 0x040129E9 RID: 76265
		internal static int __PropertyOffset_109;

		// Token: 0x040129EA RID: 76266
		internal static int __PropertyOffset_110;

		// Token: 0x040129EB RID: 76267
		internal static int __PropertyOffset_111;

		// Token: 0x040129EC RID: 76268
		internal static int __PropertyOffset_112;

		// Token: 0x040129ED RID: 76269
		internal static int __PropertyOffset_113;

		// Token: 0x040129EE RID: 76270
		internal static int __PropertyOffset_114;

		// Token: 0x040129EF RID: 76271
		internal static int __PropertyOffset_115;

		// Token: 0x040129F0 RID: 76272
		internal static int __PropertyOffset_116;

		// Token: 0x040129F1 RID: 76273
		internal static int __PropertyOffset_117;

		// Token: 0x040129F2 RID: 76274
		internal static int __PropertyOffset_118;

		// Token: 0x040129F3 RID: 76275
		private FKuroCurveFloat _FogTImeControl;

		// Token: 0x040129F4 RID: 76276
		private static IntPtr __Update_Dynamic_Clouds_NativeFunctionPtr;

		// Token: 0x040129F5 RID: 76277
		private static IntPtr __Update_Big_World_NativeFunctionPtr;

		// Token: 0x040129F6 RID: 76278
		private static IntPtr __On_Global_GITick_NativeFunctionPtr;

		// Token: 0x040129F7 RID: 76279
		private static IntPtr __UpdateEditor_NativeFunctionPtr;

		// Token: 0x040129F8 RID: 76280
		private static IntPtr __UpdateCloudCard_NativeFunctionPtr;

		// Token: 0x040129F9 RID: 76281
		private static IntPtr __GetTODCharacterLighting_NativeFunctionPtr;

		// Token: 0x040129FA RID: 76282
		private static IntPtr __Clamp_Luminance_NativeFunctionPtr;

		// Token: 0x040129FB RID: 76283
		private static IntPtr __EulerToForward_NativeFunctionPtr;

		// Token: 0x040129FC RID: 76284
		private static IntPtr __GetSkyboxDMI_NativeFunctionPtr;

		// Token: 0x040129FD RID: 76285
		private static IntPtr __UpdateMisc_NativeFunctionPtr;

		// Token: 0x040129FE RID: 76286
		private static IntPtr __GetTrulyTime_NativeFunctionPtr;

		// Token: 0x040129FF RID: 76287
		private static IntPtr __申时_NativeFunctionPtr;

		// Token: 0x04012A00 RID: 76288
		private static IntPtr __下午_NativeFunctionPtr;

		// Token: 0x04012A01 RID: 76289
		private static IntPtr __上午_NativeFunctionPtr;

		// Token: 0x04012A02 RID: 76290
		private static IntPtr __辰时_NativeFunctionPtr;

		// Token: 0x04012A03 RID: 76291
		private static IntPtr __UpdateDayNightDataLayer_NativeFunctionPtr;

		// Token: 0x04012A04 RID: 76292
		private static IntPtr __夜晚_NativeFunctionPtr;

		// Token: 0x04012A05 RID: 76293
		private static IntPtr __夜晚到清晨_NativeFunctionPtr;

		// Token: 0x04012A06 RID: 76294
		private static IntPtr __黄昏到夜晚_NativeFunctionPtr;

		// Token: 0x04012A07 RID: 76295
		private static IntPtr __黄昏_NativeFunctionPtr;

		// Token: 0x04012A08 RID: 76296
		private static IntPtr __中午_NativeFunctionPtr;

		// Token: 0x04012A09 RID: 76297
		private static IntPtr __清晨_NativeFunctionPtr;

		// Token: 0x04012A0A RID: 76298
		private static IntPtr __GetSkyDomeActor_NativeFunctionPtr;

		// Token: 0x04012A0B RID: 76299
		private static IntPtr __Get_Total_TOD_Time_Elapsed_NativeFunctionPtr;

		// Token: 0x04012A0C RID: 76300
		private static IntPtr __UpdateSkyDome_NativeFunctionPtr;

		// Token: 0x04012A0D RID: 76301
		private static IntPtr __InitGI_NativeFunctionPtr;

		// Token: 0x04012A0E RID: 76302
		private static IntPtr __Set_All_Components_States_NativeFunctionPtr;

		// Token: 0x04012A0F RID: 76303
		private static IntPtr __SetUIComponentsVisibility_NativeFunctionPtr;

		// Token: 0x04012A10 RID: 76304
		private static IntPtr __GetLightDirectionFromVH_NativeFunctionPtr;

		// Token: 0x04012A11 RID: 76305
		private static IntPtr __Update_Main_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012A12 RID: 76306
		private static IntPtr __UpdateMainLight_NativeFunctionPtr;

		// Token: 0x04012A13 RID: 76307
		private static IntPtr __UpdateTime_NativeFunctionPtr;

		// Token: 0x04012A14 RID: 76308
		private static IntPtr __GetViewLocation_NativeFunctionPtr;

		// Token: 0x04012A15 RID: 76309
		private static IntPtr __InitFeature_NativeFunctionPtr;

		// Token: 0x04012A16 RID: 76310
		private static IntPtr __CalulateLightDirectionWithLimit_NativeFunctionPtr;

		// Token: 0x04012A17 RID: 76311
		private static IntPtr __CalculateLightDirection_NativeFunctionPtr;

		// Token: 0x04012A18 RID: 76312
		private static IntPtr __Get_Scene_Light_Rotator_NativeFunctionPtr;

		// Token: 0x04012A19 RID: 76313
		private static IntPtr __Get_Scene_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012A1A RID: 76314
		private static IntPtr __InitGICompoemnt_NativeFunctionPtr;

		// Token: 0x04012A1B RID: 76315
		private static IntPtr __Get_Light_Rotator_NativeFunctionPtr;

		// Token: 0x04012A1C RID: 76316
		private static IntPtr __Get_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012A1D RID: 76317
		private static IntPtr __InitMaterials_NativeFunctionPtr;

		// Token: 0x04012A1E RID: 76318
		private static IntPtr __Is_Day_NativeFunctionPtr;

		// Token: 0x04012A1F RID: 76319
		private static IntPtr __Update_Env_NativeFunctionPtr;

		// Token: 0x04012A20 RID: 76320
		private static IntPtr __Update_Fog_NativeFunctionPtr;

		// Token: 0x04012A21 RID: 76321
		private static IntPtr __UpdateGIData_NativeFunctionPtr;

		// Token: 0x04012A22 RID: 76322
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012A23 RID: 76323
		private static IntPtr __OnKuroTickEditor_NativeFunctionPtr;

		// Token: 0x04012A24 RID: 76324
		private static IntPtr __OnKuroTick_NativeFunctionPtr;

		// Token: 0x04012A25 RID: 76325
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012A26 RID: 76326
		private static IntPtr __OnKuroSetRuntimeTime_NativeFunctionPtr;

		// Token: 0x04012A27 RID: 76327
		private static IntPtr __OnKuroStartUiScene_NativeFunctionPtr;

		// Token: 0x04012A28 RID: 76328
		private static IntPtr __OnKuroEndUiScene_NativeFunctionPtr;

		// Token: 0x04012A29 RID: 76329
		private static IntPtr __ExecuteUbergraph_BP_GlobalGI_LaunchScene_NativeFunctionPtr;

		// Token: 0x02009DBB RID: 40379
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 164)]
		protected ref struct __UpdateCloudCard_FunctionParams
		{
			// Token: 0x040327CA RID: 206794
			[FieldOffset(0)]
			public byte CloudCardSetting;
		}

		// Token: 0x02009DBC RID: 40380
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __GetTODCharacterLighting_FunctionParams
		{
			// Token: 0x040327CB RID: 206795
			[FieldOffset(0)]
			public FLinearColor mainLight;

			// Token: 0x040327CC RID: 206796
			[FieldOffset(16)]
			public float mainLightIntensity;

			// Token: 0x040327CD RID: 206797
			[FieldOffset(20)]
			public FLinearColor skyLight;

			// Token: 0x040327CE RID: 206798
			[FieldOffset(36)]
			public float skyLightIntensity;

			// Token: 0x040327CF RID: 206799
			[FieldOffset(40)]
			public FLinearColor FrontSideLight;

			// Token: 0x040327D0 RID: 206800
			[FieldOffset(56)]
			public FLinearColor BackSideLight;
		}

		// Token: 0x02009DBD RID: 40381
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 108)]
		protected ref struct __Clamp_Luminance_FunctionParams
		{
			// Token: 0x040327D1 RID: 206801
			[FieldOffset(0)]
			public FLinearColor InColor;

			// Token: 0x040327D2 RID: 206802
			[FieldOffset(16)]
			public float Min;

			// Token: 0x040327D3 RID: 206803
			[FieldOffset(20)]
			public float Max;

			// Token: 0x040327D4 RID: 206804
			[FieldOffset(24)]
			public FLinearColor __Result;
		}

		// Token: 0x02009DBE RID: 40382
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __EulerToForward_FunctionParams
		{
			// Token: 0x040327D5 RID: 206805
			[FieldOffset(0)]
			public float Pitch;

			// Token: 0x040327D6 RID: 206806
			[FieldOffset(4)]
			public float Yaw;

			// Token: 0x040327D7 RID: 206807
			[FieldOffset(8)]
			public FVector __Result;
		}

		// Token: 0x02009DBF RID: 40383
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSkyboxDMI_FunctionParams
		{
			// Token: 0x040327D8 RID: 206808
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DC0 RID: 40384
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetTrulyTime_FunctionParams
		{
			// Token: 0x040327D9 RID: 206809
			[FieldOffset(0)]
			public float CurTime;
		}

		// Token: 0x02009DC1 RID: 40385
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __Get_Total_TOD_Time_Elapsed_FunctionParams
		{
			// Token: 0x040327DA RID: 206810
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009DC2 RID: 40386
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __Set_All_Components_States_FunctionParams
		{
			// Token: 0x040327DB RID: 206811
			[FieldOffset(0)]
			public bool IsEnable;
		}

		// Token: 0x02009DC3 RID: 40387
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetUIComponentsVisibility_FunctionParams
		{
			// Token: 0x040327DC RID: 206812
			[FieldOffset(0)]
			public bool IsVisible;
		}

		// Token: 0x02009DC4 RID: 40388
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetLightDirectionFromVH_FunctionParams
		{
			// Token: 0x040327DD RID: 206813
			[FieldOffset(0)]
			public float Vertical;

			// Token: 0x040327DE RID: 206814
			[FieldOffset(4)]
			public float Horizontal;

			// Token: 0x040327DF RID: 206815
			[FieldOffset(8)]
			public FRotator Result;
		}

		// Token: 0x02009DC5 RID: 40389
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetViewLocation_FunctionParams
		{
			// Token: 0x040327E0 RID: 206816
			[FieldOffset(0)]
			public FVector WorldPosition;

			// Token: 0x040327E1 RID: 206817
			[FieldOffset(12)]
			public bool Suc;
		}

		// Token: 0x02009DC6 RID: 40390
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __CalulateLightDirectionWithLimit_FunctionParams
		{
			// Token: 0x040327E2 RID: 206818
			[FieldOffset(0)]
			public float V;

			// Token: 0x040327E3 RID: 206819
			[FieldOffset(4)]
			public float H;

			// Token: 0x040327E4 RID: 206820
			[FieldOffset(8)]
			public float Time;

			// Token: 0x040327E5 RID: 206821
			[FieldOffset(12)]
			public FRotator NewParam;
		}

		// Token: 0x02009DC7 RID: 40391
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __CalculateLightDirection_FunctionParams
		{
			// Token: 0x040327E6 RID: 206822
			[FieldOffset(0)]
			public float Vertical;

			// Token: 0x040327E7 RID: 206823
			[FieldOffset(4)]
			public float Horizontal;

			// Token: 0x040327E8 RID: 206824
			[FieldOffset(8)]
			public float Time;

			// Token: 0x040327E9 RID: 206825
			[FieldOffset(12)]
			public FRotator NewParam;
		}

		// Token: 0x02009DC8 RID: 40392
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Get_Scene_Light_Rotator_FunctionParams
		{
			// Token: 0x040327EA RID: 206826
			[FieldOffset(0)]
			public FRotator SunLight;

			// Token: 0x040327EB RID: 206827
			[FieldOffset(12)]
			public FRotator NightLight;
		}

		// Token: 0x02009DC9 RID: 40393
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Get_Scene_Light_Direction_FunctionParams
		{
			// Token: 0x040327EC RID: 206828
			[FieldOffset(0)]
			public FVector LightDir;
		}

		// Token: 0x02009DCA RID: 40394
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __Get_Light_Rotator_FunctionParams
		{
			// Token: 0x040327ED RID: 206829
			[FieldOffset(0)]
			public FRotator SunLight;

			// Token: 0x040327EE RID: 206830
			[FieldOffset(12)]
			public FRotator NightLight;
		}

		// Token: 0x02009DCB RID: 40395
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __Get_Light_Direction_FunctionParams
		{
			// Token: 0x040327EF RID: 206831
			[FieldOffset(0)]
			public FVector SunLight;

			// Token: 0x040327F0 RID: 206832
			[FieldOffset(12)]
			public FVector NightLight;
		}

		// Token: 0x02009DCC RID: 40396
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Is_Day_FunctionParams
		{
			// Token: 0x040327F1 RID: 206833
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x02009DCD RID: 40397
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UpdateGIData_FunctionParams
		{
			// Token: 0x040327F2 RID: 206834
			[FieldOffset(0)]
			public bool SkipLerpData;
		}

		// Token: 0x02009DCE RID: 40398
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroTickEditor_FunctionParams
		{
			// Token: 0x040327F3 RID: 206835
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DCF RID: 40399
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroTick_FunctionParams
		{
			// Token: 0x040327F4 RID: 206836
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DD0 RID: 40400
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroSetRuntimeTime_FunctionParams
		{
			// Token: 0x040327F5 RID: 206837
			[FieldOffset(0)]
			public float CurrentTime;
		}

		// Token: 0x02009DD1 RID: 40401
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __OnKuroStartUiScene_FunctionParams
		{
			// Token: 0x040327F6 RID: 206838
			[FieldOffset(0)]
			public FString InName;

			// Token: 0x040327F7 RID: 206839
			[FieldOffset(16)]
			public IntPtr InUILevel;
		}

		// Token: 0x02009DD2 RID: 40402
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_GlobalGI_LaunchScene_FunctionParams
		{
			// Token: 0x040327F8 RID: 206840
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
