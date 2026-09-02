using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.UI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI
{
	// Token: 0x02003C96 RID: 15510
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI_XuanJue.BP_GlobalGI_XuanJue_C")]
	[UnrealStructLayout(16512, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 16504)]
	public class BP_GlobalGI_XuanJue_C : AKuroGlobalGI, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602464C RID: 149068 RVA: 0x0099C5B4 File Offset: 0x0099A7B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GlobalGI_XuanJue_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI_XuanJue.BP_GlobalGI_XuanJue_C");
			}
			return BP_GlobalGI_XuanJue_C._ClassPtr;
		}

		// Token: 0x0602464D RID: 149069 RVA: 0x0099C5D8 File Offset: 0x0099A7D8
		public BP_GlobalGI_XuanJue_C() : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGI_XuanJue_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602464E RID: 149070 RVA: 0x0099C600 File Offset: 0x0099A800
		[NullableContext(1)]
		public BP_GlobalGI_XuanJue_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGI_XuanJue_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004BD2 RID: 19410
		// (get) Token: 0x0602464F RID: 149071 RVA: 0x0099C634 File Offset: 0x0099A834
		// (set) Token: 0x06024650 RID: 149072 RVA: 0x0099C66D File Offset: 0x0099A86D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004BD3 RID: 19411
		// (get) Token: 0x06024651 RID: 149073 RVA: 0x0099C68E File Offset: 0x0099A88E
		// (set) Token: 0x06024652 RID: 149074 RVA: 0x0099C6A2 File Offset: 0x0099A8A2
		public unsafe USceneRayTracingGICaptureComponentCube SceneRayTracingGICaptureComponentCube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneRayTracingGICaptureComponentCube>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004BD4 RID: 19412
		// (get) Token: 0x06024653 RID: 149075 RVA: 0x0099C6B7 File Offset: 0x0099A8B7
		// (set) Token: 0x06024654 RID: 149076 RVA: 0x0099C6CB File Offset: 0x0099A8CB
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004BD5 RID: 19413
		// (get) Token: 0x06024655 RID: 149077 RVA: 0x0099C6E0 File Offset: 0x0099A8E0
		// (set) Token: 0x06024656 RID: 149078 RVA: 0x0099C6F4 File Offset: 0x0099A8F4
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004BD6 RID: 19414
		// (get) Token: 0x06024657 RID: 149079 RVA: 0x0099C709 File Offset: 0x0099A909
		// (set) Token: 0x06024658 RID: 149080 RVA: 0x0099C71D File Offset: 0x0099A91D
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004BD7 RID: 19415
		// (get) Token: 0x06024659 RID: 149081 RVA: 0x0099C732 File Offset: 0x0099A932
		// (set) Token: 0x0602465A RID: 149082 RVA: 0x0099C746 File Offset: 0x0099A946
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004BD8 RID: 19416
		// (get) Token: 0x0602465B RID: 149083 RVA: 0x0099C75B File Offset: 0x0099A95B
		// (set) Token: 0x0602465C RID: 149084 RVA: 0x0099C76F File Offset: 0x0099A96F
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004BD9 RID: 19417
		// (get) Token: 0x0602465D RID: 149085 RVA: 0x0099C784 File Offset: 0x0099A984
		// (set) Token: 0x0602465E RID: 149086 RVA: 0x0099C798 File Offset: 0x0099A998
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004BDA RID: 19418
		// (get) Token: 0x0602465F RID: 149087 RVA: 0x0099C7AD File Offset: 0x0099A9AD
		// (set) Token: 0x06024660 RID: 149088 RVA: 0x0099C7C1 File Offset: 0x0099A9C1
		public unsafe UStaticMeshComponent SM_Com_Roc_01AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004BDB RID: 19419
		// (get) Token: 0x06024661 RID: 149089 RVA: 0x0099C7D6 File Offset: 0x0099A9D6
		// (set) Token: 0x06024662 RID: 149090 RVA: 0x0099C7EA File Offset: 0x0099A9EA
		public unsafe UKuroPostProcessComponent LUTPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17004BDC RID: 19420
		// (get) Token: 0x06024663 RID: 149091 RVA: 0x0099C7FF File Offset: 0x0099A9FF
		// (set) Token: 0x06024664 RID: 149092 RVA: 0x0099C813 File Offset: 0x0099AA13
		public unsafe UStaticMeshComponent SM_Aurora
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004BDD RID: 19421
		// (get) Token: 0x06024665 RID: 149093 RVA: 0x0099C828 File Offset: 0x0099AA28
		// (set) Token: 0x06024666 RID: 149094 RVA: 0x0099C83C File Offset: 0x0099AA3C
		public unsafe UStaticMeshComponent SM_Stars
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17004BDE RID: 19422
		// (get) Token: 0x06024667 RID: 149095 RVA: 0x0099C851 File Offset: 0x0099AA51
		// (set) Token: 0x06024668 RID: 149096 RVA: 0x0099C865 File Offset: 0x0099AA65
		public unsafe UStaticMeshComponent Skybox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004BDF RID: 19423
		// (get) Token: 0x06024669 RID: 149097 RVA: 0x0099C87A File Offset: 0x0099AA7A
		// (set) Token: 0x0602466A RID: 149098 RVA: 0x0099C88E File Offset: 0x0099AA8E
		public unsafe UKuroPostProcessComponent GlobalUiKuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004BE0 RID: 19424
		// (get) Token: 0x0602466B RID: 149099 RVA: 0x0099C8A3 File Offset: 0x0099AAA3
		// (set) Token: 0x0602466C RID: 149100 RVA: 0x0099C8B7 File Offset: 0x0099AAB7
		public unsafe UPostProcessComponent GlobalPostProcessVolume
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17004BE1 RID: 19425
		// (get) Token: 0x0602466D RID: 149101 RVA: 0x0099C8CC File Offset: 0x0099AACC
		// (set) Token: 0x0602466E RID: 149102 RVA: 0x0099C8E0 File Offset: 0x0099AAE0
		public unsafe UDirectionalLightComponent SceneLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17004BE2 RID: 19426
		// (get) Token: 0x0602466F RID: 149103 RVA: 0x0099C8F5 File Offset: 0x0099AAF5
		// (set) Token: 0x06024670 RID: 149104 RVA: 0x0099C909 File Offset: 0x0099AB09
		public unsafe UDirectionalLightComponent AtmoMoonLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004BE3 RID: 19427
		// (get) Token: 0x06024671 RID: 149105 RVA: 0x0099C91E File Offset: 0x0099AB1E
		// (set) Token: 0x06024672 RID: 149106 RVA: 0x0099C932 File Offset: 0x0099AB32
		public unsafe UDirectionalLightComponent AtmoSunLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004BE4 RID: 19428
		// (get) Token: 0x06024673 RID: 149107 RVA: 0x0099C947 File Offset: 0x0099AB47
		// (set) Token: 0x06024674 RID: 149108 RVA: 0x0099C95B File Offset: 0x0099AB5B
		public unsafe USkyLightComponent SkyLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkyLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17004BE5 RID: 19429
		// (get) Token: 0x06024675 RID: 149109 RVA: 0x0099C970 File Offset: 0x0099AB70
		// (set) Token: 0x06024676 RID: 149110 RVA: 0x0099C984 File Offset: 0x0099AB84
		public unsafe UExponentialHeightFogComponent HeightFog
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UExponentialHeightFogComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x17004BE6 RID: 19430
		// (get) Token: 0x06024677 RID: 149111 RVA: 0x0099C999 File Offset: 0x0099AB99
		// (set) Token: 0x06024678 RID: 149112 RVA: 0x0099C9AD File Offset: 0x0099ABAD
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17004BE7 RID: 19431
		// (get) Token: 0x06024679 RID: 149113 RVA: 0x0099C9C2 File Offset: 0x0099ABC2
		// (set) Token: 0x0602467A RID: 149114 RVA: 0x0099C9D2 File Offset: 0x0099ABD2
		public unsafe float CharacterLightHorizontal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004BE8 RID: 19432
		// (get) Token: 0x0602467B RID: 149115 RVA: 0x0099C9E3 File Offset: 0x0099ABE3
		// (set) Token: 0x0602467C RID: 149116 RVA: 0x0099C9F3 File Offset: 0x0099ABF3
		public unsafe float CurrTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004BE9 RID: 19433
		// (get) Token: 0x0602467D RID: 149117 RVA: 0x0099CA04 File Offset: 0x0099AC04
		// (set) Token: 0x0602467E RID: 149118 RVA: 0x0099CA14 File Offset: 0x0099AC14
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004BEA RID: 19434
		// (get) Token: 0x0602467F RID: 149119 RVA: 0x0099CA25 File Offset: 0x0099AC25
		// (set) Token: 0x06024680 RID: 149120 RVA: 0x0099CA35 File Offset: 0x0099AC35
		public unsafe bool EnableTODCycle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BEB RID: 19435
		// (get) Token: 0x06024681 RID: 149121 RVA: 0x0099CA46 File Offset: 0x0099AC46
		// (set) Token: 0x06024682 RID: 149122 RVA: 0x0099CA56 File Offset: 0x0099AC56
		public unsafe bool PauseTOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BEC RID: 19436
		// (get) Token: 0x06024683 RID: 149123 RVA: 0x0099CA67 File Offset: 0x0099AC67
		// (set) Token: 0x06024684 RID: 149124 RVA: 0x0099CA77 File Offset: 0x0099AC77
		public unsafe bool 编辑器下更新
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BED RID: 19437
		// (get) Token: 0x06024685 RID: 149125 RVA: 0x0099CA88 File Offset: 0x0099AC88
		// (set) Token: 0x06024686 RID: 149126 RVA: 0x0099CA98 File Offset: 0x0099AC98
		public unsafe float TODCycleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004BEE RID: 19438
		// (get) Token: 0x06024687 RID: 149127 RVA: 0x0099CAA9 File Offset: 0x0099ACA9
		// (set) Token: 0x06024688 RID: 149128 RVA: 0x0099CABD File Offset: 0x0099ACBD
		public unsafe FRotator AtmosphereSunRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004BEF RID: 19439
		// (get) Token: 0x06024689 RID: 149129 RVA: 0x0099CAD2 File Offset: 0x0099ACD2
		// (set) Token: 0x0602468A RID: 149130 RVA: 0x0099CAE6 File Offset: 0x0099ACE6
		public unsafe FRotator SenenDirLightRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004BF0 RID: 19440
		// (get) Token: 0x0602468B RID: 149131 RVA: 0x0099CAFB File Offset: 0x0099ACFB
		// (set) Token: 0x0602468C RID: 149132 RVA: 0x0099CB0B File Offset: 0x0099AD0B
		public unsafe float BP_SunHorizonAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004BF1 RID: 19441
		// (get) Token: 0x0602468D RID: 149133 RVA: 0x0099CB1C File Offset: 0x0099AD1C
		// (set) Token: 0x0602468E RID: 149134 RVA: 0x0099CB2C File Offset: 0x0099AD2C
		public unsafe float BP_SunVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17004BF2 RID: 19442
		// (get) Token: 0x0602468F RID: 149135 RVA: 0x0099CB3D File Offset: 0x0099AD3D
		// (set) Token: 0x06024690 RID: 149136 RVA: 0x0099CB4D File Offset: 0x0099AD4D
		public unsafe float MainLightHorizonAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004BF3 RID: 19443
		// (get) Token: 0x06024691 RID: 149137 RVA: 0x0099CB5E File Offset: 0x0099AD5E
		// (set) Token: 0x06024692 RID: 149138 RVA: 0x0099CB6E File Offset: 0x0099AD6E
		public unsafe float MainLightVerticalAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004BF4 RID: 19444
		// (get) Token: 0x06024693 RID: 149139 RVA: 0x0099CB7F File Offset: 0x0099AD7F
		// (set) Token: 0x06024694 RID: 149140 RVA: 0x0099CB8F File Offset: 0x0099AD8F
		public unsafe float MainLightAngleLimit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17004BF5 RID: 19445
		// (get) Token: 0x06024695 RID: 149141 RVA: 0x0099CBA0 File Offset: 0x0099ADA0
		// (set) Token: 0x06024696 RID: 149142 RVA: 0x0099CBB0 File Offset: 0x0099ADB0
		public unsafe bool IsGIEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BF6 RID: 19446
		// (get) Token: 0x06024697 RID: 149143 RVA: 0x0099CBC1 File Offset: 0x0099ADC1
		// (set) Token: 0x06024698 RID: 149144 RVA: 0x0099CBD1 File Offset: 0x0099ADD1
		public unsafe bool 使用随机的昼夜循环天气组
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BF7 RID: 19447
		// (get) Token: 0x06024699 RID: 149145 RVA: 0x0099CBE2 File Offset: 0x0099ADE2
		// (set) Token: 0x0602469A RID: 149146 RVA: 0x0099CBF2 File Offset: 0x0099ADF2
		public unsafe int 当前的天气组索引值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004BF8 RID: 19448
		// (get) Token: 0x0602469B RID: 149147 RVA: 0x0099CC03 File Offset: 0x0099AE03
		// (set) Token: 0x0602469C RID: 149148 RVA: 0x0099CC17 File Offset: 0x0099AE17
		public unsafe FLinearColor 太阳颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004BF9 RID: 19449
		// (get) Token: 0x0602469D RID: 149149 RVA: 0x0099CC2C File Offset: 0x0099AE2C
		// (set) Token: 0x0602469E RID: 149150 RVA: 0x0099CC65 File Offset: 0x0099AE65
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
					result = (this._SunLightExistTime = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_39, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SunLightExistTime.CopyAssign(value);
			}
		}

		// Token: 0x17004BFA RID: 19450
		// (get) Token: 0x0602469F RID: 149151 RVA: 0x0099CC74 File Offset: 0x0099AE74
		// (set) Token: 0x060246A0 RID: 149152 RVA: 0x0099CCAD File Offset: 0x0099AEAD
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
					result = (this._MoonLightExistTime = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_40, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.MoonLightExistTime.CopyAssign(value);
			}
		}

		// Token: 0x17004BFB RID: 19451
		// (get) Token: 0x060246A1 RID: 149153 RVA: 0x0099CCBB File Offset: 0x0099AEBB
		// (set) Token: 0x060246A2 RID: 149154 RVA: 0x0099CCCB File Offset: 0x0099AECB
		public unsafe bool 运行时自动开始循环
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BFC RID: 19452
		// (get) Token: 0x060246A3 RID: 149155 RVA: 0x0099CCDC File Offset: 0x0099AEDC
		// (set) Token: 0x060246A4 RID: 149156 RVA: 0x0099CCEC File Offset: 0x0099AEEC
		public unsafe bool UISceneRendering
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BFD RID: 19453
		// (get) Token: 0x060246A5 RID: 149157 RVA: 0x0099CCFD File Offset: 0x0099AEFD
		// (set) Token: 0x060246A6 RID: 149158 RVA: 0x0099CD11 File Offset: 0x0099AF11
		public unsafe PDA_GIUIData_C UIData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_GIUIData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_43);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_43, value);
			}
		}

		// Token: 0x17004BFE RID: 19454
		// (get) Token: 0x060246A7 RID: 149159 RVA: 0x0099CD26 File Offset: 0x0099AF26
		// (set) Token: 0x060246A8 RID: 149160 RVA: 0x0099CD36 File Offset: 0x0099AF36
		public unsafe bool DEBUG_UI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004BFF RID: 19455
		// (get) Token: 0x060246A9 RID: 149161 RVA: 0x0099CD47 File Offset: 0x0099AF47
		// (set) Token: 0x060246AA RID: 149162 RVA: 0x0099CD57 File Offset: 0x0099AF57
		public unsafe bool IsRootGI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C00 RID: 19456
		// (get) Token: 0x060246AB RID: 149163 RVA: 0x0099CD68 File Offset: 0x0099AF68
		// (set) Token: 0x060246AC RID: 149164 RVA: 0x0099CD78 File Offset: 0x0099AF78
		public unsafe bool IsEditorUpdate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C01 RID: 19457
		// (get) Token: 0x060246AD RID: 149165 RVA: 0x0099CD89 File Offset: 0x0099AF89
		// (set) Token: 0x060246AE RID: 149166 RVA: 0x0099CD99 File Offset: 0x0099AF99
		public unsafe bool 更新角色光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C02 RID: 19458
		// (get) Token: 0x060246AF RID: 149167 RVA: 0x0099CDAA File Offset: 0x0099AFAA
		// (set) Token: 0x060246B0 RID: 149168 RVA: 0x0099CDBA File Offset: 0x0099AFBA
		public unsafe bool 根据光源方向自动更新角色光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C03 RID: 19459
		// (get) Token: 0x060246B1 RID: 149169 RVA: 0x0099CDCB File Offset: 0x0099AFCB
		// (set) Token: 0x060246B2 RID: 149170 RVA: 0x0099CDDB File Offset: 0x0099AFDB
		public unsafe bool DEBUG_使用角色预览方向光
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C04 RID: 19460
		// (get) Token: 0x060246B3 RID: 149171 RVA: 0x0099CDEC File Offset: 0x0099AFEC
		// (set) Token: 0x060246B4 RID: 149172 RVA: 0x0099CDFC File Offset: 0x0099AFFC
		public unsafe float DEBUG_角色预览方向光方向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17004C05 RID: 19461
		// (get) Token: 0x060246B5 RID: 149173 RVA: 0x0099CE0D File Offset: 0x0099B00D
		// (set) Token: 0x060246B6 RID: 149174 RVA: 0x0099CE1D File Offset: 0x0099B01D
		public unsafe int TotalDaysElapsed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17004C06 RID: 19462
		// (get) Token: 0x060246B7 RID: 149175 RVA: 0x0099CE2E File Offset: 0x0099B02E
		// (set) Token: 0x060246B8 RID: 149176 RVA: 0x0099CE3E File Offset: 0x0099B03E
		public unsafe float MoonFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17004C07 RID: 19463
		// (get) Token: 0x060246B9 RID: 149177 RVA: 0x0099CE4F File Offset: 0x0099B04F
		// (set) Token: 0x060246BA RID: 149178 RVA: 0x0099CE63 File Offset: 0x0099B063
		public unsafe FVector2D MoonVisibleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17004C08 RID: 19464
		// (get) Token: 0x060246BB RID: 149179 RVA: 0x0099CE78 File Offset: 0x0099B078
		// (set) Token: 0x060246BC RID: 149180 RVA: 0x0099CE8C File Offset: 0x0099B08C
		public unsafe PDA_GIUIData_C DefaultUIData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_GIUIData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_54);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_54, value);
			}
		}

		// Token: 0x17004C09 RID: 19465
		// (get) Token: 0x060246BD RID: 149181 RVA: 0x0099CEA1 File Offset: 0x0099B0A1
		// (set) Token: 0x060246BE RID: 149182 RVA: 0x0099CEB1 File Offset: 0x0099B0B1
		public unsafe bool 关闭雾效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C0A RID: 19466
		// (get) Token: 0x060246BF RID: 149183 RVA: 0x0099CEC2 File Offset: 0x0099B0C2
		// (set) Token: 0x060246C0 RID: 149184 RVA: 0x0099CED2 File Offset: 0x0099B0D2
		public unsafe bool RuntimeTimeEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C0B RID: 19467
		// (get) Token: 0x060246C1 RID: 149185 RVA: 0x0099CEE3 File Offset: 0x0099B0E3
		// (set) Token: 0x060246C2 RID: 149186 RVA: 0x0099CEF3 File Offset: 0x0099B0F3
		public unsafe float MainLightTickSecond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17004C0C RID: 19468
		// (get) Token: 0x060246C3 RID: 149187 RVA: 0x0099CF04 File Offset: 0x0099B104
		// (set) Token: 0x060246C4 RID: 149188 RVA: 0x0099CF14 File Offset: 0x0099B114
		public unsafe float MainLightTickCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_58);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17004C0D RID: 19469
		// (get) Token: 0x060246C5 RID: 149189 RVA: 0x0099CF25 File Offset: 0x0099B125
		// (set) Token: 0x060246C6 RID: 149190 RVA: 0x0099CF35 File Offset: 0x0099B135
		public unsafe bool ForceUpdateMainLightDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C0E RID: 19470
		// (get) Token: 0x060246C7 RID: 149191 RVA: 0x0099CF46 File Offset: 0x0099B146
		// (set) Token: 0x060246C8 RID: 149192 RVA: 0x0099CF56 File Offset: 0x0099B156
		public unsafe float WindDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_60);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_60) = value;
			}
		}

		// Token: 0x17004C0F RID: 19471
		// (get) Token: 0x060246C9 RID: 149193 RVA: 0x0099CF67 File Offset: 0x0099B167
		// (set) Token: 0x060246CA RID: 149194 RVA: 0x0099CF77 File Offset: 0x0099B177
		public unsafe bool 使用临时雾效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_61) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_61) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C10 RID: 19472
		// (get) Token: 0x060246CB RID: 149195 RVA: 0x0099CF88 File Offset: 0x0099B188
		// (set) Token: 0x060246CC RID: 149196 RVA: 0x0099CF98 File Offset: 0x0099B198
		public unsafe bool 开启集群特效
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_62) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_62) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C11 RID: 19473
		// (get) Token: 0x060246CD RID: 149197 RVA: 0x0099CFA9 File Offset: 0x0099B1A9
		// (set) Token: 0x060246CE RID: 149198 RVA: 0x0099CFBD File Offset: 0x0099B1BD
		public unsafe UMaterialInstance TempFogMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_63);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_63, value);
			}
		}

		// Token: 0x17004C12 RID: 19474
		// (get) Token: 0x060246CF RID: 149199 RVA: 0x0099CFD2 File Offset: 0x0099B1D2
		// (set) Token: 0x060246D0 RID: 149200 RVA: 0x0099CFE6 File Offset: 0x0099B1E6
		public unsafe UMaterialInstanceDynamic TempFogDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_64);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x17004C13 RID: 19475
		// (get) Token: 0x060246D1 RID: 149201 RVA: 0x0099CFFB File Offset: 0x0099B1FB
		// (set) Token: 0x060246D2 RID: 149202 RVA: 0x0099D00F File Offset: 0x0099B20F
		public unsafe UMaterialInstanceDynamic SkyboxDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_65);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x17004C14 RID: 19476
		// (get) Token: 0x060246D3 RID: 149203 RVA: 0x0099D024 File Offset: 0x0099B224
		// (set) Token: 0x060246D4 RID: 149204 RVA: 0x0099D038 File Offset: 0x0099B238
		public unsafe UMaterialInstance SkyboxMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_66);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x17004C15 RID: 19477
		// (get) Token: 0x060246D5 RID: 149205 RVA: 0x0099D04D File Offset: 0x0099B24D
		// (set) Token: 0x060246D6 RID: 149206 RVA: 0x0099D061 File Offset: 0x0099B261
		public unsafe FLinearColor SunDiscColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_67);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_67) = value;
			}
		}

		// Token: 0x17004C16 RID: 19478
		// (get) Token: 0x060246D7 RID: 149207 RVA: 0x0099D076 File Offset: 0x0099B276
		// (set) Token: 0x060246D8 RID: 149208 RVA: 0x0099D08A File Offset: 0x0099B28A
		public unsafe FLinearColor SunScatterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17004C17 RID: 19479
		// (get) Token: 0x060246D9 RID: 149209 RVA: 0x0099D09F File Offset: 0x0099B29F
		// (set) Token: 0x060246DA RID: 149210 RVA: 0x0099D0AF File Offset: 0x0099B2AF
		public unsafe float SunSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17004C18 RID: 19480
		// (get) Token: 0x060246DB RID: 149211 RVA: 0x0099D0C0 File Offset: 0x0099B2C0
		// (set) Token: 0x060246DC RID: 149212 RVA: 0x0099D0D4 File Offset: 0x0099B2D4
		public unsafe FLinearColor MoonDiscColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x17004C19 RID: 19481
		// (get) Token: 0x060246DD RID: 149213 RVA: 0x0099D0E9 File Offset: 0x0099B2E9
		// (set) Token: 0x060246DE RID: 149214 RVA: 0x0099D0FD File Offset: 0x0099B2FD
		public unsafe FLinearColor MoonScatterColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x17004C1A RID: 19482
		// (get) Token: 0x060246DF RID: 149215 RVA: 0x0099D112 File Offset: 0x0099B312
		// (set) Token: 0x060246E0 RID: 149216 RVA: 0x0099D122 File Offset: 0x0099B322
		public unsafe float MoonSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x17004C1B RID: 19483
		// (get) Token: 0x060246E1 RID: 149217 RVA: 0x0099D133 File Offset: 0x0099B333
		// (set) Token: 0x060246E2 RID: 149218 RVA: 0x0099D147 File Offset: 0x0099B347
		public unsafe FLinearColor HorizonColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x17004C1C RID: 19484
		// (get) Token: 0x060246E3 RID: 149219 RVA: 0x0099D15C File Offset: 0x0099B35C
		// (set) Token: 0x060246E4 RID: 149220 RVA: 0x0099D16C File Offset: 0x0099B36C
		public unsafe float HorizonFalloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x17004C1D RID: 19485
		// (get) Token: 0x060246E5 RID: 149221 RVA: 0x0099D17D File Offset: 0x0099B37D
		// (set) Token: 0x060246E6 RID: 149222 RVA: 0x0099D191 File Offset: 0x0099B391
		public unsafe FLinearColor ZenithColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17004C1E RID: 19486
		// (get) Token: 0x060246E7 RID: 149223 RVA: 0x0099D1A6 File Offset: 0x0099B3A6
		// (set) Token: 0x060246E8 RID: 149224 RVA: 0x0099D1B6 File Offset: 0x0099B3B6
		public unsafe float ExtremWeatherWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17004C1F RID: 19487
		// (get) Token: 0x060246E9 RID: 149225 RVA: 0x0099D1C7 File Offset: 0x0099B3C7
		// (set) Token: 0x060246EA RID: 149226 RVA: 0x0099D1DB File Offset: 0x0099B3DB
		public unsafe FLinearColor ST_TopColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17004C20 RID: 19488
		// (get) Token: 0x060246EB RID: 149227 RVA: 0x0099D1F0 File Offset: 0x0099B3F0
		// (set) Token: 0x060246EC RID: 149228 RVA: 0x0099D204 File Offset: 0x0099B404
		public unsafe FLinearColor ST_DomeColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x17004C21 RID: 19489
		// (get) Token: 0x060246ED RID: 149229 RVA: 0x0099D219 File Offset: 0x0099B419
		// (set) Token: 0x060246EE RID: 149230 RVA: 0x0099D229 File Offset: 0x0099B429
		public unsafe float ST_TopWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_79);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_79) = value;
			}
		}

		// Token: 0x17004C22 RID: 19490
		// (get) Token: 0x060246EF RID: 149231 RVA: 0x0099D23A File Offset: 0x0099B43A
		// (set) Token: 0x060246F0 RID: 149232 RVA: 0x0099D24E File Offset: 0x0099B44E
		public unsafe UCurveFloat CharMainLightCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_80);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_80, value);
			}
		}

		// Token: 0x17004C23 RID: 19491
		// (get) Token: 0x060246F1 RID: 149233 RVA: 0x0099D263 File Offset: 0x0099B463
		// (set) Token: 0x060246F2 RID: 149234 RVA: 0x0099D277 File Offset: 0x0099B477
		public unsafe UCurveFloat CharSkyLightCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_81);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_81, value);
			}
		}

		// Token: 0x17004C24 RID: 19492
		// (get) Token: 0x060246F3 RID: 149235 RVA: 0x0099D28C File Offset: 0x0099B48C
		// (set) Token: 0x060246F4 RID: 149236 RVA: 0x0099D29C File Offset: 0x0099B49C
		public unsafe bool UseCharCustomLighting
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_82) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_82) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C25 RID: 19493
		// (get) Token: 0x060246F5 RID: 149237 RVA: 0x0099D2AD File Offset: 0x0099B4AD
		// (set) Token: 0x060246F6 RID: 149238 RVA: 0x0099D2C1 File Offset: 0x0099B4C1
		public unsafe FLinearColor CharAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x17004C26 RID: 19494
		// (get) Token: 0x060246F7 RID: 149239 RVA: 0x0099D2D6 File Offset: 0x0099B4D6
		// (set) Token: 0x060246F8 RID: 149240 RVA: 0x0099D2EA File Offset: 0x0099B4EA
		public unsafe FLinearColor CharSkinAmbientColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17004C27 RID: 19495
		// (get) Token: 0x060246F9 RID: 149241 RVA: 0x0099D2FF File Offset: 0x0099B4FF
		// (set) Token: 0x060246FA RID: 149242 RVA: 0x0099D313 File Offset: 0x0099B513
		public unsafe UCurveFloat CharShadowCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_85);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_85, value);
			}
		}

		// Token: 0x17004C28 RID: 19496
		// (get) Token: 0x060246FB RID: 149243 RVA: 0x0099D328 File Offset: 0x0099B528
		// (set) Token: 0x060246FC RID: 149244 RVA: 0x0099D33C File Offset: 0x0099B53C
		public unsafe UMaterialInstance LightFunctionMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_86);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_86, value);
			}
		}

		// Token: 0x17004C29 RID: 19497
		// (get) Token: 0x060246FD RID: 149245 RVA: 0x0099D351 File Offset: 0x0099B551
		// (set) Token: 0x060246FE RID: 149246 RVA: 0x0099D361 File Offset: 0x0099B561
		public unsafe float LightFunctionIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_87);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x17004C2A RID: 19498
		// (get) Token: 0x060246FF RID: 149247 RVA: 0x0099D372 File Offset: 0x0099B572
		// (set) Token: 0x06024700 RID: 149248 RVA: 0x0099D386 File Offset: 0x0099B586
		public unsafe UMaterialInstanceDynamic LightFunctionDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_88);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_88, value);
			}
		}

		// Token: 0x17004C2B RID: 19499
		// (get) Token: 0x06024701 RID: 149249 RVA: 0x0099D39B File Offset: 0x0099B59B
		// (set) Token: 0x06024702 RID: 149250 RVA: 0x0099D3AB File Offset: 0x0099B5AB
		public unsafe bool DEBUG开启无音区特殊地表
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_89) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_89) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004C2C RID: 19500
		// (get) Token: 0x06024703 RID: 149251 RVA: 0x0099D3BC File Offset: 0x0099B5BC
		// (set) Token: 0x06024704 RID: 149252 RVA: 0x0099D3D0 File Offset: 0x0099B5D0
		public unsafe UMaterialInstance LensFlareMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_90);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_90, value);
			}
		}

		// Token: 0x17004C2D RID: 19501
		// (get) Token: 0x06024705 RID: 149253 RVA: 0x0099D3E5 File Offset: 0x0099B5E5
		// (set) Token: 0x06024706 RID: 149254 RVA: 0x0099D3F9 File Offset: 0x0099B5F9
		public unsafe UMaterialInstanceDynamic LensFlareDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_91);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_91, value);
			}
		}

		// Token: 0x17004C2E RID: 19502
		// (get) Token: 0x06024707 RID: 149255 RVA: 0x0099D40E File Offset: 0x0099B60E
		// (set) Token: 0x06024708 RID: 149256 RVA: 0x0099D422 File Offset: 0x0099B622
		public unsafe FLinearColor Nadir_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x17004C2F RID: 19503
		// (get) Token: 0x06024709 RID: 149257 RVA: 0x0099D437 File Offset: 0x0099B637
		// (set) Token: 0x0602470A RID: 149258 RVA: 0x0099D447 File Offset: 0x0099B647
		public unsafe float Nadir_Falloff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x17004C30 RID: 19504
		// (get) Token: 0x0602470B RID: 149259 RVA: 0x0099D458 File Offset: 0x0099B658
		// (set) Token: 0x0602470C RID: 149260 RVA: 0x0099D468 File Offset: 0x0099B668
		public unsafe float Sun_Scatter_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17004C31 RID: 19505
		// (get) Token: 0x0602470D RID: 149261 RVA: 0x0099D479 File Offset: 0x0099B679
		// (set) Token: 0x0602470E RID: 149262 RVA: 0x0099D489 File Offset: 0x0099B689
		public unsafe float Moon_Scatter_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x17004C32 RID: 19506
		// (get) Token: 0x0602470F RID: 149263 RVA: 0x0099D49A File Offset: 0x0099B69A
		// (set) Token: 0x06024710 RID: 149264 RVA: 0x0099D4AE File Offset: 0x0099B6AE
		public unsafe UMaterialInstanceDynamic Stars_DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_96);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_96, value);
			}
		}

		// Token: 0x17004C33 RID: 19507
		// (get) Token: 0x06024711 RID: 149265 RVA: 0x0099D4C3 File Offset: 0x0099B6C3
		// (set) Token: 0x06024712 RID: 149266 RVA: 0x0099D4D7 File Offset: 0x0099B6D7
		public unsafe UMaterialInstance StarsMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_97);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_97, value);
			}
		}

		// Token: 0x17004C34 RID: 19508
		// (get) Token: 0x06024713 RID: 149267 RVA: 0x0099D4EC File Offset: 0x0099B6EC
		// (set) Token: 0x06024714 RID: 149268 RVA: 0x0099D500 File Offset: 0x0099B700
		public unsafe UMaterialInstanceDynamic AuroraDMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_98);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_98, value);
			}
		}

		// Token: 0x17004C35 RID: 19509
		// (get) Token: 0x06024715 RID: 149269 RVA: 0x0099D515 File Offset: 0x0099B715
		// (set) Token: 0x06024716 RID: 149270 RVA: 0x0099D529 File Offset: 0x0099B729
		public unsafe UMaterialInstance AuroraMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_99);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGI_XuanJue_C.__PropertyOffset_99, value);
			}
		}

		// Token: 0x17004C36 RID: 19510
		// (get) Token: 0x06024717 RID: 149271 RVA: 0x0099D53E File Offset: 0x0099B73E
		// (set) Token: 0x06024718 RID: 149272 RVA: 0x0099D54E File Offset: 0x0099B74E
		public unsafe float MainDirectionLightUpdateThreshold_Mobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17004C37 RID: 19511
		// (get) Token: 0x06024719 RID: 149273 RVA: 0x0099D55F File Offset: 0x0099B75F
		// (set) Token: 0x0602471A RID: 149274 RVA: 0x0099D56F File Offset: 0x0099B76F
		public unsafe float MainDirectionLightUpdateThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17004C38 RID: 19512
		// (get) Token: 0x0602471B RID: 149275 RVA: 0x0099D580 File Offset: 0x0099B780
		// (set) Token: 0x0602471C RID: 149276 RVA: 0x0099D594 File Offset: 0x0099B794
		public unsafe FVector GlobalWindDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17004C39 RID: 19513
		// (get) Token: 0x0602471D RID: 149277 RVA: 0x0099D5A9 File Offset: 0x0099B7A9
		// (set) Token: 0x0602471E RID: 149278 RVA: 0x0099D5BD File Offset: 0x0099B7BD
		public unsafe FVector GlobalWindRightDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17004C3A RID: 19514
		// (get) Token: 0x0602471F RID: 149279 RVA: 0x0099D5D2 File Offset: 0x0099B7D2
		// (set) Token: 0x06024720 RID: 149280 RVA: 0x0099D5E2 File Offset: 0x0099B7E2
		public unsafe float DEBUG无音区特殊地表强度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17004C3B RID: 19515
		// (get) Token: 0x06024721 RID: 149281 RVA: 0x0099D5F3 File Offset: 0x0099B7F3
		// (set) Token: 0x06024722 RID: 149282 RVA: 0x0099D607 File Offset: 0x0099B807
		public unsafe FLinearColor Character_Rim_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_105);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_105) = value;
			}
		}

		// Token: 0x17004C3C RID: 19516
		// (get) Token: 0x06024723 RID: 149283 RVA: 0x0099D61C File Offset: 0x0099B81C
		// (set) Token: 0x06024724 RID: 149284 RVA: 0x0099D62C File Offset: 0x0099B82C
		public unsafe float RealTimeOfDay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_106);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GlobalGI_XuanJue_C.__PropertyOffset_106) = value;
			}
		}

		// Token: 0x06024725 RID: 149285 RVA: 0x0099D63D File Offset: 0x0099B83D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCharacterGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateCharacterGI_NativeFunctionPtr, null);
		}

		// Token: 0x06024726 RID: 149286 RVA: 0x0099D654 File Offset: 0x0099B854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTODCharacterLighting(FLinearColor mainLight, float mainLightIntensity, FLinearColor skyLight, float skyLightIntensity, ref FLinearColor FrontSideLight, ref FLinearColor BackSideLight)
		{
			BP_GlobalGI_XuanJue_C.__GetTODCharacterLighting_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetTODCharacterLighting_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetTODCharacterLighting_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetTODCharacterLighting_NativeFunctionPtr, (void*)ptr, 1);
			ptr->mainLight = mainLight;
			ptr->mainLightIntensity = mainLightIntensity;
			ptr->skyLight = skyLight;
			ptr->skyLightIntensity = skyLightIntensity;
			ptr->FrontSideLight = FrontSideLight;
			ptr->BackSideLight = BackSideLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetTODCharacterLighting_NativeFunctionPtr, (void*)ptr);
			FrontSideLight = ptr->FrontSideLight;
			BackSideLight = ptr->BackSideLight;
		}

		// Token: 0x06024727 RID: 149287 RVA: 0x0099D6E8 File Offset: 0x0099B8E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FLinearColor Clamp_Luminance(FLinearColor InColor, float Min, float Max)
		{
			BP_GlobalGI_XuanJue_C.__Clamp_Luminance_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Clamp_Luminance_FunctionParams[(UIntPtr)123] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Clamp_Luminance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Clamp_Luminance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InColor = InColor;
			ptr->Min = Min;
			ptr->Max = Max;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Clamp_Luminance_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06024728 RID: 149288 RVA: 0x0099D744 File Offset: 0x0099B944
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector EulerToForward(float Pitch, float Yaw)
		{
			BP_GlobalGI_XuanJue_C.__EulerToForward_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__EulerToForward_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__EulerToForward_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__EulerToForward_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Pitch = Pitch;
			ptr->Yaw = Yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__EulerToForward_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06024729 RID: 149289 RVA: 0x0099D797 File Offset: 0x0099B997
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReloadRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__ReloadRain_NativeFunctionPtr, null);
		}

		// Token: 0x0602472A RID: 149290 RVA: 0x0099D7AC File Offset: 0x0099B9AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAuroraDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_XuanJue_C.__GetAuroraDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetAuroraDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetAuroraDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetAuroraDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_XuanJue_C.__GetAuroraDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetAuroraDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x0602472B RID: 149291 RVA: 0x0099D810 File Offset: 0x0099BA10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetStarsDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_XuanJue_C.__GetStarsDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetStarsDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetStarsDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetStarsDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_XuanJue_C.__GetStarsDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetStarsDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x0602472C RID: 149292 RVA: 0x0099D874 File Offset: 0x0099BA74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetSkyboxDMI(ref UMaterialInstanceDynamic DMIRet)
		{
			BP_GlobalGI_XuanJue_C.__GetSkyboxDMI_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetSkyboxDMI_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetSkyboxDMI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetSkyboxDMI_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_GlobalGI_XuanJue_C.__GetSkyboxDMI_FunctionParams ptr2 = ref *ptr;
			UMaterialInstanceDynamic umaterialInstanceDynamic = DMIRet;
			ptr2.DMIRet = ((umaterialInstanceDynamic != null) ? umaterialInstanceDynamic.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetSkyboxDMI_NativeFunctionPtr, (void*)ptr);
			DMIRet = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMaterialInstanceDynamic>(ptr->DMIRet);
		}

		// Token: 0x0602472D RID: 149293 RVA: 0x0099D8D8 File Offset: 0x0099BAD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkybox()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateSkybox_NativeFunctionPtr, null);
		}

		// Token: 0x0602472E RID: 149294 RVA: 0x0099D8EC File Offset: 0x0099BAEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMisc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateMisc_NativeFunctionPtr, null);
		}

		// Token: 0x0602472F RID: 149295 RVA: 0x0099D900 File Offset: 0x0099BB00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFlowmapSkybox()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateFlowmapSkybox_NativeFunctionPtr, null);
		}

		// Token: 0x06024730 RID: 149296 RVA: 0x0099D914 File Offset: 0x0099BB14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetTrulyTime(ref float CurTime)
		{
			BP_GlobalGI_XuanJue_C.__GetTrulyTime_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetTrulyTime_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetTrulyTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetTrulyTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurTime = CurTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetTrulyTime_NativeFunctionPtr, (void*)ptr);
			CurTime = ptr->CurTime;
		}

		// Token: 0x06024731 RID: 149297 RVA: 0x0099D963 File Offset: 0x0099BB63
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 申时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__申时_NativeFunctionPtr, null);
		}

		// Token: 0x06024732 RID: 149298 RVA: 0x0099D977 File Offset: 0x0099BB77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 下午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__下午_NativeFunctionPtr, null);
		}

		// Token: 0x06024733 RID: 149299 RVA: 0x0099D98B File Offset: 0x0099BB8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 上午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__上午_NativeFunctionPtr, null);
		}

		// Token: 0x06024734 RID: 149300 RVA: 0x0099D99F File Offset: 0x0099BB9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 辰时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__辰时_NativeFunctionPtr, null);
		}

		// Token: 0x06024735 RID: 149301 RVA: 0x0099D9B3 File Offset: 0x0099BBB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDayNightDataLayer()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateDayNightDataLayer_NativeFunctionPtr, null);
		}

		// Token: 0x06024736 RID: 149302 RVA: 0x0099D9C8 File Offset: 0x0099BBC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloudCard(ref FKuroCloudCardSetting CloudCardSetting)
		{
			BP_GlobalGI_XuanJue_C.__UpdateCloudCard_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__UpdateCloudCard_FunctionParams[(UIntPtr)179] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__UpdateCloudCard_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__UpdateCloudCard_NativeFunctionPtr, (void*)ptr, 1);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCloudCardSetting.StaticStruct(), &ptr->CloudCardSetting, CloudCardSetting.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateCloudCard_NativeFunctionPtr, (void*)ptr);
			if (CloudCardSetting != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCloudCardSetting.StaticStruct(), CloudCardSetting.NativePtr, &ptr->CloudCardSetting, 1, false);
			}
		}

		// Token: 0x06024737 RID: 149303 RVA: 0x0099DA52 File Offset: 0x0099BC52
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x06024738 RID: 149304 RVA: 0x0099DA66 File Offset: 0x0099BC66
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 夜晚到清晨()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__夜晚到清晨_NativeFunctionPtr, null);
		}

		// Token: 0x06024739 RID: 149305 RVA: 0x0099DA7A File Offset: 0x0099BC7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 黄昏到夜晚()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__黄昏到夜晚_NativeFunctionPtr, null);
		}

		// Token: 0x0602473A RID: 149306 RVA: 0x0099DA8E File Offset: 0x0099BC8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 黄昏()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__黄昏_NativeFunctionPtr, null);
		}

		// Token: 0x0602473B RID: 149307 RVA: 0x0099DAA2 File Offset: 0x0099BCA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 中午()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__中午_NativeFunctionPtr, null);
		}

		// Token: 0x0602473C RID: 149308 RVA: 0x0099DAB6 File Offset: 0x0099BCB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 清晨()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__清晨_NativeFunctionPtr, null);
		}

		// Token: 0x0602473D RID: 149309 RVA: 0x0099DACA File Offset: 0x0099BCCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLightMPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateLightMPC_NativeFunctionPtr, null);
		}

		// Token: 0x0602473E RID: 149310 RVA: 0x0099DADE File Offset: 0x0099BCDE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetSkyDomeActor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetSkyDomeActor_NativeFunctionPtr, null);
		}

		// Token: 0x0602473F RID: 149311 RVA: 0x0099DAF4 File Offset: 0x0099BCF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Total_TOD_Time_Elapsed(ref float Time)
		{
			BP_GlobalGI_XuanJue_C.__Get_Total_TOD_Time_Elapsed_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Get_Total_TOD_Time_Elapsed_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Get_Total_TOD_Time_Elapsed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Get_Total_TOD_Time_Elapsed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Get_Total_TOD_Time_Elapsed_NativeFunctionPtr, (void*)ptr);
			Time = ptr->Time;
		}

		// Token: 0x06024740 RID: 149312 RVA: 0x0099DB43 File Offset: 0x0099BD43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkyDome()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateSkyDome_NativeFunctionPtr, null);
		}

		// Token: 0x06024741 RID: 149313 RVA: 0x0099DB57 File Offset: 0x0099BD57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__InitGI_NativeFunctionPtr, null);
		}

		// Token: 0x06024742 RID: 149314 RVA: 0x0099DB6C File Offset: 0x0099BD6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_All_Components_States(bool IsEnable)
		{
			BP_GlobalGI_XuanJue_C.__Set_All_Components_States_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Set_All_Components_States_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Set_All_Components_States_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Set_All_Components_States_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsEnable = IsEnable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Set_All_Components_States_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024743 RID: 149315 RVA: 0x0099DBB4 File Offset: 0x0099BDB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetUIComponentsVisibility(bool IsVisible)
		{
			BP_GlobalGI_XuanJue_C.__SetUIComponentsVisibility_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__SetUIComponentsVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__SetUIComponentsVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__SetUIComponentsVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsVisible = IsVisible;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__SetUIComponentsVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024744 RID: 149316 RVA: 0x0099DBFA File Offset: 0x0099BDFA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void End3DUIScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__End3DUIScene_NativeFunctionPtr, null);
		}

		// Token: 0x06024745 RID: 149317 RVA: 0x0099DC10 File Offset: 0x0099BE10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Start3DUIScene(PDA_GIUIData_C UIGIData)
		{
			BP_GlobalGI_XuanJue_C.__Start3DUIScene_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Start3DUIScene_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Start3DUIScene_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Start3DUIScene_NativeFunctionPtr, (void*)ptr, 1);
			ptr->UIGIData = ((UIGIData != null) ? UIGIData.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Start3DUIScene_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024746 RID: 149318 RVA: 0x0099DC65 File Offset: 0x0099BE65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLightShaft()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateLightShaft_NativeFunctionPtr, null);
		}

		// Token: 0x06024747 RID: 149319 RVA: 0x0099DC7C File Offset: 0x0099BE7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLightDirectionFromVH(float Vertical, float Horizontal, ref FRotator Result)
		{
			BP_GlobalGI_XuanJue_C.__GetLightDirectionFromVH_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetLightDirectionFromVH_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetLightDirectionFromVH_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetLightDirectionFromVH_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vertical = Vertical;
			ptr->Horizontal = Horizontal;
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetLightDirectionFromVH_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x06024748 RID: 149320 RVA: 0x0099DCE1 File Offset: 0x0099BEE1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePostProcessVolume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdatePostProcessVolume_NativeFunctionPtr, null);
		}

		// Token: 0x06024749 RID: 149321 RVA: 0x0099DCF5 File Offset: 0x0099BEF5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLightParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateLightParameters_NativeFunctionPtr, null);
		}

		// Token: 0x0602474A RID: 149322 RVA: 0x0099DD09 File Offset: 0x0099BF09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Main_Light_Direction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Update_Main_Light_Direction_NativeFunctionPtr, null);
		}

		// Token: 0x0602474B RID: 149323 RVA: 0x0099DD1D File Offset: 0x0099BF1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMainLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateMainLight_NativeFunctionPtr, null);
		}

		// Token: 0x0602474C RID: 149324 RVA: 0x0099DD31 File Offset: 0x0099BF31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateTime_NativeFunctionPtr, null);
		}

		// Token: 0x0602474D RID: 149325 RVA: 0x0099DD48 File Offset: 0x0099BF48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetViewLocation(ref FVector WorldPosition, ref bool Suc)
		{
			BP_GlobalGI_XuanJue_C.__GetViewLocation_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__GetViewLocation_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__GetViewLocation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__GetViewLocation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->WorldPosition = WorldPosition;
			ptr->Suc = Suc;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__GetViewLocation_NativeFunctionPtr, (void*)ptr);
			WorldPosition = ptr->WorldPosition;
			Suc = ptr->Suc;
		}

		// Token: 0x0602474E RID: 149326 RVA: 0x0099DDAF File Offset: 0x0099BFAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitFeature()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__InitFeature_NativeFunctionPtr, null);
		}

		// Token: 0x0602474F RID: 149327 RVA: 0x0099DDC4 File Offset: 0x0099BFC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalulateLightDirectionWithLimit(float V, float H, float Time, ref FRotator NewParam)
		{
			BP_GlobalGI_XuanJue_C.__CalulateLightDirectionWithLimit_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__CalulateLightDirectionWithLimit_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__CalulateLightDirectionWithLimit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__CalulateLightDirectionWithLimit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->V = V;
			ptr->H = H;
			ptr->Time = Time;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__CalulateLightDirectionWithLimit_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06024750 RID: 149328 RVA: 0x0099DE38 File Offset: 0x0099C038
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CalculateLightDirection(float Vertical, float Horizontal, float Time, ref FRotator NewParam)
		{
			BP_GlobalGI_XuanJue_C.__CalculateLightDirection_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__CalculateLightDirection_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__CalculateLightDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__CalculateLightDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vertical = Vertical;
			ptr->Horizontal = Horizontal;
			ptr->Time = Time;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__CalculateLightDirection_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x06024751 RID: 149329 RVA: 0x0099DEA6 File Offset: 0x0099C0A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateAtmosphere()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateAtmosphere_NativeFunctionPtr, null);
		}

		// Token: 0x06024752 RID: 149330 RVA: 0x0099DEBA File Offset: 0x0099C0BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSkyLight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateSkyLight_NativeFunctionPtr, null);
		}

		// Token: 0x06024753 RID: 149331 RVA: 0x0099DED0 File Offset: 0x0099C0D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Scene_Light_Rotator(ref FRotator SunLight, ref FRotator NightLight)
		{
			BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Rotator_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Rotator_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Rotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Rotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SunLight = SunLight;
			ptr->NightLight = NightLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Rotator_NativeFunctionPtr, (void*)ptr);
			SunLight = ptr->SunLight;
			NightLight = ptr->NightLight;
		}

		// Token: 0x06024754 RID: 149332 RVA: 0x0099DF40 File Offset: 0x0099C140
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Scene_Light_Direction(ref FVector LightDir)
		{
			BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Direction_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Direction_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Direction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Direction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LightDir = LightDir;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Get_Scene_Light_Direction_NativeFunctionPtr, (void*)ptr);
			LightDir = ptr->LightDir;
		}

		// Token: 0x06024755 RID: 149333 RVA: 0x0099DF97 File Offset: 0x0099C197
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitGICompoemnt()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__InitGICompoemnt_NativeFunctionPtr, null);
		}

		// Token: 0x06024756 RID: 149334 RVA: 0x0099DFAC File Offset: 0x0099C1AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Light_Rotator(ref FRotator SunLight, ref FRotator NightLight)
		{
			BP_GlobalGI_XuanJue_C.__Get_Light_Rotator_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Get_Light_Rotator_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Get_Light_Rotator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Get_Light_Rotator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SunLight = SunLight;
			ptr->NightLight = NightLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Get_Light_Rotator_NativeFunctionPtr, (void*)ptr);
			SunLight = ptr->SunLight;
			NightLight = ptr->NightLight;
		}

		// Token: 0x06024757 RID: 149335 RVA: 0x0099E01C File Offset: 0x0099C21C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Light_Direction(ref FVector SunLight, ref FVector NightLight)
		{
			BP_GlobalGI_XuanJue_C.__Get_Light_Direction_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Get_Light_Direction_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Get_Light_Direction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Get_Light_Direction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SunLight = SunLight;
			ptr->NightLight = NightLight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Get_Light_Direction_NativeFunctionPtr, (void*)ptr);
			SunLight = ptr->SunLight;
			NightLight = ptr->NightLight;
		}

		// Token: 0x06024758 RID: 149336 RVA: 0x0099E08B File Offset: 0x0099C28B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitMaterials()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__InitMaterials_NativeFunctionPtr, null);
		}

		// Token: 0x06024759 RID: 149337 RVA: 0x0099E0A0 File Offset: 0x0099C2A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Is_Day(ref bool Result)
		{
			BP_GlobalGI_XuanJue_C.__Is_Day_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Is_Day_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Is_Day_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Is_Day_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Is_Day_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602475A RID: 149338 RVA: 0x0099E0EF File Offset: 0x0099C2EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateWind()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateWind_NativeFunctionPtr, null);
		}

		// Token: 0x0602475B RID: 149339 RVA: 0x0099E103 File Offset: 0x0099C303
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLensFlares()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateLensFlares_NativeFunctionPtr, null);
		}

		// Token: 0x0602475C RID: 149340 RVA: 0x0099E118 File Offset: 0x0099C318
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get2SkyboxLerpWeight(float startSetting, float EndSetting, float CurrentTime, ref float Weight)
		{
			BP_GlobalGI_XuanJue_C.__Get2SkyboxLerpWeight_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__Get2SkyboxLerpWeight_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__Get2SkyboxLerpWeight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__Get2SkyboxLerpWeight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->startSetting = startSetting;
			ptr->EndSetting = EndSetting;
			ptr->CurrentTime = CurrentTime;
			ptr->Weight = Weight;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Get2SkyboxLerpWeight_NativeFunctionPtr, (void*)ptr);
			Weight = ptr->Weight;
		}

		// Token: 0x0602475D RID: 149341 RVA: 0x0099E17E File Offset: 0x0099C37E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Env()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__Update_Env_NativeFunctionPtr, null);
		}

		// Token: 0x0602475E RID: 149342 RVA: 0x0099E192 File Offset: 0x0099C392
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFog()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateFog_NativeFunctionPtr, null);
		}

		// Token: 0x0602475F RID: 149343 RVA: 0x0099E1A6 File Offset: 0x0099C3A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateGIData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UpdateGIData_NativeFunctionPtr, null);
		}

		// Token: 0x06024760 RID: 149344 RVA: 0x0099E1BA File Offset: 0x0099C3BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024761 RID: 149345 RVA: 0x0099E1CE File Offset: 0x0099C3CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024762 RID: 149346 RVA: 0x0099E1E4 File Offset: 0x0099C3E4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroStartUI(string InName, [Nullable(2)] ULevel InUILevel)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroStartUI_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroStartUI_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroStartUI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroStartUI_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->InName), InName);
			ptr->InUILevel = ((InUILevel != null) ? InUILevel.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroStartUI_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_GlobalGI_XuanJue_C.__OnKuroStartUI_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024763 RID: 149347 RVA: 0x0099E258 File Offset: 0x0099C458
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroStartUI_Implementation(string InName, [Nullable(2)] ULevel InUILevel)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroStartUI_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroStartUI_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroStartUI_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroStartUI_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->InName), InName);
			ptr->InUILevel = ((InUILevel != null) ? InUILevel.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroStartUI_NativeFunctionPtr, (void*)ptr, 0);
			UnrealReflectionUtils.DestroyStruct(BP_GlobalGI_XuanJue_C.__OnKuroStartUI_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06024764 RID: 149348 RVA: 0x0099E2CC File Offset: 0x0099C4CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroEndUI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroEndUI_NativeFunctionPtr, null);
		}

		// Token: 0x06024765 RID: 149349 RVA: 0x0099E2E0 File Offset: 0x0099C4E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroEndUI_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroEndUI_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024766 RID: 149350 RVA: 0x0099E2F5 File Offset: 0x0099C4F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroInit_NativeFunctionPtr, null);
		}

		// Token: 0x06024767 RID: 149351 RVA: 0x0099E309 File Offset: 0x0099C509
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024768 RID: 149352 RVA: 0x0099E320 File Offset: 0x0099C520
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroTick(float DeltaTime)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroTick_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024769 RID: 149353 RVA: 0x0099E368 File Offset: 0x0099C568
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroTick_Implementation(float DeltaTime)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroTick_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602476A RID: 149354 RVA: 0x0099E3B0 File Offset: 0x0099C5B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroTickEditor(float DeltaTime)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602476B RID: 149355 RVA: 0x0099E3F8 File Offset: 0x0099C5F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroTickEditor_Implementation(float DeltaTime)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroTickEditor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602476C RID: 149356 RVA: 0x0099E43F File Offset: 0x0099C63F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602476D RID: 149357 RVA: 0x0099E453 File Offset: 0x0099C653
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602476E RID: 149358 RVA: 0x0099E468 File Offset: 0x0099C668
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnKuroRuntimeDestroy()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroRuntimeDestroy_NativeFunctionPtr, null);
		}

		// Token: 0x0602476F RID: 149359 RVA: 0x0099E47C File Offset: 0x0099C67C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnKuroRuntimeDestroy_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroRuntimeDestroy_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024770 RID: 149360 RVA: 0x0099E494 File Offset: 0x0099C694
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void OnKuroSetRuntimeTime(float CurrentTime)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentTime = CurrentTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024771 RID: 149361 RVA: 0x0099E4DC File Offset: 0x0099C6DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnKuroSetRuntimeTime_Implementation(float CurrentTime)
		{
			BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CurrentTime = CurrentTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__OnKuroSetRuntimeTime_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024772 RID: 149362 RVA: 0x0099E524 File Offset: 0x0099C724
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GlobalGI_XuanJue(int EntryPoint)
		{
			BP_GlobalGI_XuanJue_C.__ExecuteUbergraph_BP_GlobalGI_XuanJue_FunctionParams* ptr = stackalloc BP_GlobalGI_XuanJue_C.__ExecuteUbergraph_BP_GlobalGI_XuanJue_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_GlobalGI_XuanJue_C.__ExecuteUbergraph_BP_GlobalGI_XuanJue_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGI_XuanJue_C.__ExecuteUbergraph_BP_GlobalGI_XuanJue_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GlobalGI_XuanJue_C.__ExecuteUbergraph_BP_GlobalGI_XuanJue_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024773 RID: 149363 RVA: 0x0099E56B File Offset: 0x0099C76B
		protected BP_GlobalGI_XuanJue_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012A2A RID: 76330
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/BP_GlobalGI_XuanJue.BP_GlobalGI_XuanJue_C";

		// Token: 0x04012A2B RID: 76331
		private static IntPtr _ClassPtr;

		// Token: 0x04012A2C RID: 76332
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012A2D RID: 76333
		internal static int __PropertyOffset_0;

		// Token: 0x04012A2E RID: 76334
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012A2F RID: 76335
		internal static int __PropertyOffset_1;

		// Token: 0x04012A30 RID: 76336
		internal static int __PropertyOffset_2;

		// Token: 0x04012A31 RID: 76337
		internal static int __PropertyOffset_3;

		// Token: 0x04012A32 RID: 76338
		internal static int __PropertyOffset_4;

		// Token: 0x04012A33 RID: 76339
		internal static int __PropertyOffset_5;

		// Token: 0x04012A34 RID: 76340
		internal static int __PropertyOffset_6;

		// Token: 0x04012A35 RID: 76341
		internal static int __PropertyOffset_7;

		// Token: 0x04012A36 RID: 76342
		internal static int __PropertyOffset_8;

		// Token: 0x04012A37 RID: 76343
		internal static int __PropertyOffset_9;

		// Token: 0x04012A38 RID: 76344
		internal static int __PropertyOffset_10;

		// Token: 0x04012A39 RID: 76345
		internal static int __PropertyOffset_11;

		// Token: 0x04012A3A RID: 76346
		internal static int __PropertyOffset_12;

		// Token: 0x04012A3B RID: 76347
		internal static int __PropertyOffset_13;

		// Token: 0x04012A3C RID: 76348
		internal static int __PropertyOffset_14;

		// Token: 0x04012A3D RID: 76349
		internal static int __PropertyOffset_15;

		// Token: 0x04012A3E RID: 76350
		internal static int __PropertyOffset_16;

		// Token: 0x04012A3F RID: 76351
		internal static int __PropertyOffset_17;

		// Token: 0x04012A40 RID: 76352
		internal static int __PropertyOffset_18;

		// Token: 0x04012A41 RID: 76353
		internal static int __PropertyOffset_19;

		// Token: 0x04012A42 RID: 76354
		internal static int __PropertyOffset_20;

		// Token: 0x04012A43 RID: 76355
		internal static int __PropertyOffset_21;

		// Token: 0x04012A44 RID: 76356
		internal static int __PropertyOffset_22;

		// Token: 0x04012A45 RID: 76357
		internal static int __PropertyOffset_23;

		// Token: 0x04012A46 RID: 76358
		internal static int __PropertyOffset_24;

		// Token: 0x04012A47 RID: 76359
		internal static int __PropertyOffset_25;

		// Token: 0x04012A48 RID: 76360
		internal static int __PropertyOffset_26;

		// Token: 0x04012A49 RID: 76361
		internal static int __PropertyOffset_27;

		// Token: 0x04012A4A RID: 76362
		internal static int __PropertyOffset_28;

		// Token: 0x04012A4B RID: 76363
		internal static int __PropertyOffset_29;

		// Token: 0x04012A4C RID: 76364
		internal static int __PropertyOffset_30;

		// Token: 0x04012A4D RID: 76365
		internal static int __PropertyOffset_31;

		// Token: 0x04012A4E RID: 76366
		internal static int __PropertyOffset_32;

		// Token: 0x04012A4F RID: 76367
		internal static int __PropertyOffset_33;

		// Token: 0x04012A50 RID: 76368
		internal static int __PropertyOffset_34;

		// Token: 0x04012A51 RID: 76369
		internal static int __PropertyOffset_35;

		// Token: 0x04012A52 RID: 76370
		internal static int __PropertyOffset_36;

		// Token: 0x04012A53 RID: 76371
		internal static int __PropertyOffset_37;

		// Token: 0x04012A54 RID: 76372
		internal static int __PropertyOffset_38;

		// Token: 0x04012A55 RID: 76373
		internal static int __PropertyOffset_39;

		// Token: 0x04012A56 RID: 76374
		private TArray<FVector2D> _SunLightExistTime;

		// Token: 0x04012A57 RID: 76375
		internal static int __PropertyOffset_40;

		// Token: 0x04012A58 RID: 76376
		private TArray<FVector2D> _MoonLightExistTime;

		// Token: 0x04012A59 RID: 76377
		internal static int __PropertyOffset_41;

		// Token: 0x04012A5A RID: 76378
		internal static int __PropertyOffset_42;

		// Token: 0x04012A5B RID: 76379
		internal static int __PropertyOffset_43;

		// Token: 0x04012A5C RID: 76380
		internal static int __PropertyOffset_44;

		// Token: 0x04012A5D RID: 76381
		internal static int __PropertyOffset_45;

		// Token: 0x04012A5E RID: 76382
		internal static int __PropertyOffset_46;

		// Token: 0x04012A5F RID: 76383
		internal static int __PropertyOffset_47;

		// Token: 0x04012A60 RID: 76384
		internal static int __PropertyOffset_48;

		// Token: 0x04012A61 RID: 76385
		internal static int __PropertyOffset_49;

		// Token: 0x04012A62 RID: 76386
		internal static int __PropertyOffset_50;

		// Token: 0x04012A63 RID: 76387
		internal static int __PropertyOffset_51;

		// Token: 0x04012A64 RID: 76388
		internal static int __PropertyOffset_52;

		// Token: 0x04012A65 RID: 76389
		internal static int __PropertyOffset_53;

		// Token: 0x04012A66 RID: 76390
		internal static int __PropertyOffset_54;

		// Token: 0x04012A67 RID: 76391
		internal static int __PropertyOffset_55;

		// Token: 0x04012A68 RID: 76392
		internal static int __PropertyOffset_56;

		// Token: 0x04012A69 RID: 76393
		internal static int __PropertyOffset_57;

		// Token: 0x04012A6A RID: 76394
		internal static int __PropertyOffset_58;

		// Token: 0x04012A6B RID: 76395
		internal static int __PropertyOffset_59;

		// Token: 0x04012A6C RID: 76396
		internal static int __PropertyOffset_60;

		// Token: 0x04012A6D RID: 76397
		internal static int __PropertyOffset_61;

		// Token: 0x04012A6E RID: 76398
		internal static int __PropertyOffset_62;

		// Token: 0x04012A6F RID: 76399
		internal static int __PropertyOffset_63;

		// Token: 0x04012A70 RID: 76400
		internal static int __PropertyOffset_64;

		// Token: 0x04012A71 RID: 76401
		internal static int __PropertyOffset_65;

		// Token: 0x04012A72 RID: 76402
		internal static int __PropertyOffset_66;

		// Token: 0x04012A73 RID: 76403
		internal static int __PropertyOffset_67;

		// Token: 0x04012A74 RID: 76404
		internal static int __PropertyOffset_68;

		// Token: 0x04012A75 RID: 76405
		internal static int __PropertyOffset_69;

		// Token: 0x04012A76 RID: 76406
		internal static int __PropertyOffset_70;

		// Token: 0x04012A77 RID: 76407
		internal static int __PropertyOffset_71;

		// Token: 0x04012A78 RID: 76408
		internal static int __PropertyOffset_72;

		// Token: 0x04012A79 RID: 76409
		internal static int __PropertyOffset_73;

		// Token: 0x04012A7A RID: 76410
		internal static int __PropertyOffset_74;

		// Token: 0x04012A7B RID: 76411
		internal static int __PropertyOffset_75;

		// Token: 0x04012A7C RID: 76412
		internal static int __PropertyOffset_76;

		// Token: 0x04012A7D RID: 76413
		internal static int __PropertyOffset_77;

		// Token: 0x04012A7E RID: 76414
		internal static int __PropertyOffset_78;

		// Token: 0x04012A7F RID: 76415
		internal static int __PropertyOffset_79;

		// Token: 0x04012A80 RID: 76416
		internal static int __PropertyOffset_80;

		// Token: 0x04012A81 RID: 76417
		internal static int __PropertyOffset_81;

		// Token: 0x04012A82 RID: 76418
		internal static int __PropertyOffset_82;

		// Token: 0x04012A83 RID: 76419
		internal static int __PropertyOffset_83;

		// Token: 0x04012A84 RID: 76420
		internal static int __PropertyOffset_84;

		// Token: 0x04012A85 RID: 76421
		internal static int __PropertyOffset_85;

		// Token: 0x04012A86 RID: 76422
		internal static int __PropertyOffset_86;

		// Token: 0x04012A87 RID: 76423
		internal static int __PropertyOffset_87;

		// Token: 0x04012A88 RID: 76424
		internal static int __PropertyOffset_88;

		// Token: 0x04012A89 RID: 76425
		internal static int __PropertyOffset_89;

		// Token: 0x04012A8A RID: 76426
		internal static int __PropertyOffset_90;

		// Token: 0x04012A8B RID: 76427
		internal static int __PropertyOffset_91;

		// Token: 0x04012A8C RID: 76428
		internal static int __PropertyOffset_92;

		// Token: 0x04012A8D RID: 76429
		internal static int __PropertyOffset_93;

		// Token: 0x04012A8E RID: 76430
		internal static int __PropertyOffset_94;

		// Token: 0x04012A8F RID: 76431
		internal static int __PropertyOffset_95;

		// Token: 0x04012A90 RID: 76432
		internal static int __PropertyOffset_96;

		// Token: 0x04012A91 RID: 76433
		internal static int __PropertyOffset_97;

		// Token: 0x04012A92 RID: 76434
		internal static int __PropertyOffset_98;

		// Token: 0x04012A93 RID: 76435
		internal static int __PropertyOffset_99;

		// Token: 0x04012A94 RID: 76436
		internal static int __PropertyOffset_100;

		// Token: 0x04012A95 RID: 76437
		internal static int __PropertyOffset_101;

		// Token: 0x04012A96 RID: 76438
		internal static int __PropertyOffset_102;

		// Token: 0x04012A97 RID: 76439
		internal static int __PropertyOffset_103;

		// Token: 0x04012A98 RID: 76440
		internal static int __PropertyOffset_104;

		// Token: 0x04012A99 RID: 76441
		internal static int __PropertyOffset_105;

		// Token: 0x04012A9A RID: 76442
		internal static int __PropertyOffset_106;

		// Token: 0x04012A9B RID: 76443
		private static IntPtr __UpdateCharacterGI_NativeFunctionPtr;

		// Token: 0x04012A9C RID: 76444
		private static IntPtr __GetTODCharacterLighting_NativeFunctionPtr;

		// Token: 0x04012A9D RID: 76445
		private static IntPtr __Clamp_Luminance_NativeFunctionPtr;

		// Token: 0x04012A9E RID: 76446
		private static IntPtr __EulerToForward_NativeFunctionPtr;

		// Token: 0x04012A9F RID: 76447
		private static IntPtr __ReloadRain_NativeFunctionPtr;

		// Token: 0x04012AA0 RID: 76448
		private static IntPtr __GetAuroraDMI_NativeFunctionPtr;

		// Token: 0x04012AA1 RID: 76449
		private static IntPtr __GetStarsDMI_NativeFunctionPtr;

		// Token: 0x04012AA2 RID: 76450
		private static IntPtr __GetSkyboxDMI_NativeFunctionPtr;

		// Token: 0x04012AA3 RID: 76451
		private static IntPtr __UpdateSkybox_NativeFunctionPtr;

		// Token: 0x04012AA4 RID: 76452
		private static IntPtr __UpdateMisc_NativeFunctionPtr;

		// Token: 0x04012AA5 RID: 76453
		private static IntPtr __UpdateFlowmapSkybox_NativeFunctionPtr;

		// Token: 0x04012AA6 RID: 76454
		private static IntPtr __GetTrulyTime_NativeFunctionPtr;

		// Token: 0x04012AA7 RID: 76455
		private static IntPtr __申时_NativeFunctionPtr;

		// Token: 0x04012AA8 RID: 76456
		private static IntPtr __下午_NativeFunctionPtr;

		// Token: 0x04012AA9 RID: 76457
		private static IntPtr __上午_NativeFunctionPtr;

		// Token: 0x04012AAA RID: 76458
		private static IntPtr __辰时_NativeFunctionPtr;

		// Token: 0x04012AAB RID: 76459
		private static IntPtr __UpdateDayNightDataLayer_NativeFunctionPtr;

		// Token: 0x04012AAC RID: 76460
		private static IntPtr __UpdateCloudCard_NativeFunctionPtr;

		// Token: 0x04012AAD RID: 76461
		private static IntPtr __夜晚_NativeFunctionPtr;

		// Token: 0x04012AAE RID: 76462
		private static IntPtr __夜晚到清晨_NativeFunctionPtr;

		// Token: 0x04012AAF RID: 76463
		private static IntPtr __黄昏到夜晚_NativeFunctionPtr;

		// Token: 0x04012AB0 RID: 76464
		private static IntPtr __黄昏_NativeFunctionPtr;

		// Token: 0x04012AB1 RID: 76465
		private static IntPtr __中午_NativeFunctionPtr;

		// Token: 0x04012AB2 RID: 76466
		private static IntPtr __清晨_NativeFunctionPtr;

		// Token: 0x04012AB3 RID: 76467
		private static IntPtr __UpdateLightMPC_NativeFunctionPtr;

		// Token: 0x04012AB4 RID: 76468
		private static IntPtr __GetSkyDomeActor_NativeFunctionPtr;

		// Token: 0x04012AB5 RID: 76469
		private static IntPtr __Get_Total_TOD_Time_Elapsed_NativeFunctionPtr;

		// Token: 0x04012AB6 RID: 76470
		private static IntPtr __UpdateSkyDome_NativeFunctionPtr;

		// Token: 0x04012AB7 RID: 76471
		private static IntPtr __InitGI_NativeFunctionPtr;

		// Token: 0x04012AB8 RID: 76472
		private static IntPtr __Set_All_Components_States_NativeFunctionPtr;

		// Token: 0x04012AB9 RID: 76473
		private static IntPtr __SetUIComponentsVisibility_NativeFunctionPtr;

		// Token: 0x04012ABA RID: 76474
		private static IntPtr __End3DUIScene_NativeFunctionPtr;

		// Token: 0x04012ABB RID: 76475
		private static IntPtr __Start3DUIScene_NativeFunctionPtr;

		// Token: 0x04012ABC RID: 76476
		private static IntPtr __UpdateLightShaft_NativeFunctionPtr;

		// Token: 0x04012ABD RID: 76477
		private static IntPtr __GetLightDirectionFromVH_NativeFunctionPtr;

		// Token: 0x04012ABE RID: 76478
		private static IntPtr __UpdatePostProcessVolume_NativeFunctionPtr;

		// Token: 0x04012ABF RID: 76479
		private static IntPtr __UpdateLightParameters_NativeFunctionPtr;

		// Token: 0x04012AC0 RID: 76480
		private static IntPtr __Update_Main_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012AC1 RID: 76481
		private static IntPtr __UpdateMainLight_NativeFunctionPtr;

		// Token: 0x04012AC2 RID: 76482
		private static IntPtr __UpdateTime_NativeFunctionPtr;

		// Token: 0x04012AC3 RID: 76483
		private static IntPtr __GetViewLocation_NativeFunctionPtr;

		// Token: 0x04012AC4 RID: 76484
		private static IntPtr __InitFeature_NativeFunctionPtr;

		// Token: 0x04012AC5 RID: 76485
		private static IntPtr __CalulateLightDirectionWithLimit_NativeFunctionPtr;

		// Token: 0x04012AC6 RID: 76486
		private static IntPtr __CalculateLightDirection_NativeFunctionPtr;

		// Token: 0x04012AC7 RID: 76487
		private static IntPtr __UpdateAtmosphere_NativeFunctionPtr;

		// Token: 0x04012AC8 RID: 76488
		private static IntPtr __UpdateSkyLight_NativeFunctionPtr;

		// Token: 0x04012AC9 RID: 76489
		private static IntPtr __Get_Scene_Light_Rotator_NativeFunctionPtr;

		// Token: 0x04012ACA RID: 76490
		private static IntPtr __Get_Scene_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012ACB RID: 76491
		private static IntPtr __InitGICompoemnt_NativeFunctionPtr;

		// Token: 0x04012ACC RID: 76492
		private static IntPtr __Get_Light_Rotator_NativeFunctionPtr;

		// Token: 0x04012ACD RID: 76493
		private static IntPtr __Get_Light_Direction_NativeFunctionPtr;

		// Token: 0x04012ACE RID: 76494
		private static IntPtr __InitMaterials_NativeFunctionPtr;

		// Token: 0x04012ACF RID: 76495
		private static IntPtr __Is_Day_NativeFunctionPtr;

		// Token: 0x04012AD0 RID: 76496
		private static IntPtr __UpdateWind_NativeFunctionPtr;

		// Token: 0x04012AD1 RID: 76497
		private static IntPtr __UpdateLensFlares_NativeFunctionPtr;

		// Token: 0x04012AD2 RID: 76498
		private static IntPtr __Get2SkyboxLerpWeight_NativeFunctionPtr;

		// Token: 0x04012AD3 RID: 76499
		private static IntPtr __Update_Env_NativeFunctionPtr;

		// Token: 0x04012AD4 RID: 76500
		private static IntPtr __UpdateFog_NativeFunctionPtr;

		// Token: 0x04012AD5 RID: 76501
		private static IntPtr __UpdateGIData_NativeFunctionPtr;

		// Token: 0x04012AD6 RID: 76502
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012AD7 RID: 76503
		private static IntPtr __OnKuroStartUI_NativeFunctionPtr;

		// Token: 0x04012AD8 RID: 76504
		private static IntPtr __OnKuroEndUI_NativeFunctionPtr;

		// Token: 0x04012AD9 RID: 76505
		private static IntPtr __OnKuroInit_NativeFunctionPtr;

		// Token: 0x04012ADA RID: 76506
		private static IntPtr __OnKuroTick_NativeFunctionPtr;

		// Token: 0x04012ADB RID: 76507
		private static IntPtr __OnKuroTickEditor_NativeFunctionPtr;

		// Token: 0x04012ADC RID: 76508
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012ADD RID: 76509
		private static IntPtr __OnKuroRuntimeDestroy_NativeFunctionPtr;

		// Token: 0x04012ADE RID: 76510
		private static IntPtr __OnKuroSetRuntimeTime_NativeFunctionPtr;

		// Token: 0x04012ADF RID: 76511
		private static IntPtr __ExecuteUbergraph_BP_GlobalGI_XuanJue_NativeFunctionPtr;

		// Token: 0x02009DD3 RID: 40403
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __GetTODCharacterLighting_FunctionParams
		{
			// Token: 0x040327F9 RID: 206841
			[FieldOffset(0)]
			public FLinearColor mainLight;

			// Token: 0x040327FA RID: 206842
			[FieldOffset(16)]
			public float mainLightIntensity;

			// Token: 0x040327FB RID: 206843
			[FieldOffset(20)]
			public FLinearColor skyLight;

			// Token: 0x040327FC RID: 206844
			[FieldOffset(36)]
			public float skyLightIntensity;

			// Token: 0x040327FD RID: 206845
			[FieldOffset(40)]
			public FLinearColor FrontSideLight;

			// Token: 0x040327FE RID: 206846
			[FieldOffset(56)]
			public FLinearColor BackSideLight;
		}

		// Token: 0x02009DD4 RID: 40404
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 108)]
		protected ref struct __Clamp_Luminance_FunctionParams
		{
			// Token: 0x040327FF RID: 206847
			[FieldOffset(0)]
			public FLinearColor InColor;

			// Token: 0x04032800 RID: 206848
			[FieldOffset(16)]
			public float Min;

			// Token: 0x04032801 RID: 206849
			[FieldOffset(20)]
			public float Max;

			// Token: 0x04032802 RID: 206850
			[FieldOffset(24)]
			public FLinearColor __Result;
		}

		// Token: 0x02009DD5 RID: 40405
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __EulerToForward_FunctionParams
		{
			// Token: 0x04032803 RID: 206851
			[FieldOffset(0)]
			public float Pitch;

			// Token: 0x04032804 RID: 206852
			[FieldOffset(4)]
			public float Yaw;

			// Token: 0x04032805 RID: 206853
			[FieldOffset(8)]
			public FVector __Result;
		}

		// Token: 0x02009DD6 RID: 40406
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetAuroraDMI_FunctionParams
		{
			// Token: 0x04032806 RID: 206854
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DD7 RID: 40407
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetStarsDMI_FunctionParams
		{
			// Token: 0x04032807 RID: 206855
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DD8 RID: 40408
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetSkyboxDMI_FunctionParams
		{
			// Token: 0x04032808 RID: 206856
			[FieldOffset(0)]
			public IntPtr DMIRet;
		}

		// Token: 0x02009DD9 RID: 40409
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __GetTrulyTime_FunctionParams
		{
			// Token: 0x04032809 RID: 206857
			[FieldOffset(0)]
			public float CurTime;
		}

		// Token: 0x02009DDA RID: 40410
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 164)]
		protected ref struct __UpdateCloudCard_FunctionParams
		{
			// Token: 0x0403280A RID: 206858
			[FieldOffset(0)]
			public byte CloudCardSetting;
		}

		// Token: 0x02009DDB RID: 40411
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __Get_Total_TOD_Time_Elapsed_FunctionParams
		{
			// Token: 0x0403280B RID: 206859
			[FieldOffset(0)]
			public float Time;
		}

		// Token: 0x02009DDC RID: 40412
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __Set_All_Components_States_FunctionParams
		{
			// Token: 0x0403280C RID: 206860
			[FieldOffset(0)]
			public bool IsEnable;
		}

		// Token: 0x02009DDD RID: 40413
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetUIComponentsVisibility_FunctionParams
		{
			// Token: 0x0403280D RID: 206861
			[FieldOffset(0)]
			public bool IsVisible;
		}

		// Token: 0x02009DDE RID: 40414
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __Start3DUIScene_FunctionParams
		{
			// Token: 0x0403280E RID: 206862
			[FieldOffset(0)]
			public IntPtr UIGIData;
		}

		// Token: 0x02009DDF RID: 40415
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __GetLightDirectionFromVH_FunctionParams
		{
			// Token: 0x0403280F RID: 206863
			[FieldOffset(0)]
			public float Vertical;

			// Token: 0x04032810 RID: 206864
			[FieldOffset(4)]
			public float Horizontal;

			// Token: 0x04032811 RID: 206865
			[FieldOffset(8)]
			public FRotator Result;
		}

		// Token: 0x02009DE0 RID: 40416
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __GetViewLocation_FunctionParams
		{
			// Token: 0x04032812 RID: 206866
			[FieldOffset(0)]
			public FVector WorldPosition;

			// Token: 0x04032813 RID: 206867
			[FieldOffset(12)]
			public bool Suc;
		}

		// Token: 0x02009DE1 RID: 40417
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __CalulateLightDirectionWithLimit_FunctionParams
		{
			// Token: 0x04032814 RID: 206868
			[FieldOffset(0)]
			public float V;

			// Token: 0x04032815 RID: 206869
			[FieldOffset(4)]
			public float H;

			// Token: 0x04032816 RID: 206870
			[FieldOffset(8)]
			public float Time;

			// Token: 0x04032817 RID: 206871
			[FieldOffset(12)]
			public FRotator NewParam;
		}

		// Token: 0x02009DE2 RID: 40418
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __CalculateLightDirection_FunctionParams
		{
			// Token: 0x04032818 RID: 206872
			[FieldOffset(0)]
			public float Vertical;

			// Token: 0x04032819 RID: 206873
			[FieldOffset(4)]
			public float Horizontal;

			// Token: 0x0403281A RID: 206874
			[FieldOffset(8)]
			public float Time;

			// Token: 0x0403281B RID: 206875
			[FieldOffset(12)]
			public FRotator NewParam;
		}

		// Token: 0x02009DE3 RID: 40419
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Get_Scene_Light_Rotator_FunctionParams
		{
			// Token: 0x0403281C RID: 206876
			[FieldOffset(0)]
			public FRotator SunLight;

			// Token: 0x0403281D RID: 206877
			[FieldOffset(12)]
			public FRotator NightLight;
		}

		// Token: 0x02009DE4 RID: 40420
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __Get_Scene_Light_Direction_FunctionParams
		{
			// Token: 0x0403281E RID: 206878
			[FieldOffset(0)]
			public FVector LightDir;
		}

		// Token: 0x02009DE5 RID: 40421
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __Get_Light_Rotator_FunctionParams
		{
			// Token: 0x0403281F RID: 206879
			[FieldOffset(0)]
			public FRotator SunLight;

			// Token: 0x04032820 RID: 206880
			[FieldOffset(12)]
			public FRotator NightLight;
		}

		// Token: 0x02009DE6 RID: 40422
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __Get_Light_Direction_FunctionParams
		{
			// Token: 0x04032821 RID: 206881
			[FieldOffset(0)]
			public FVector SunLight;

			// Token: 0x04032822 RID: 206882
			[FieldOffset(12)]
			public FVector NightLight;
		}

		// Token: 0x02009DE7 RID: 40423
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __Is_Day_FunctionParams
		{
			// Token: 0x04032823 RID: 206883
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x02009DE8 RID: 40424
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected ref struct __Get2SkyboxLerpWeight_FunctionParams
		{
			// Token: 0x04032824 RID: 206884
			[FieldOffset(0)]
			public float startSetting;

			// Token: 0x04032825 RID: 206885
			[FieldOffset(4)]
			public float EndSetting;

			// Token: 0x04032826 RID: 206886
			[FieldOffset(8)]
			public float CurrentTime;

			// Token: 0x04032827 RID: 206887
			[FieldOffset(12)]
			public float Weight;
		}

		// Token: 0x02009DE9 RID: 40425
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __OnKuroStartUI_FunctionParams
		{
			// Token: 0x04032828 RID: 206888
			[FieldOffset(0)]
			public FString InName;

			// Token: 0x04032829 RID: 206889
			[FieldOffset(16)]
			public IntPtr InUILevel;
		}

		// Token: 0x02009DEA RID: 40426
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroTick_FunctionParams
		{
			// Token: 0x0403282A RID: 206890
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DEB RID: 40427
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroTickEditor_FunctionParams
		{
			// Token: 0x0403282B RID: 206891
			[FieldOffset(0)]
			public float DeltaTime;
		}

		// Token: 0x02009DEC RID: 40428
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __OnKuroSetRuntimeTime_FunctionParams
		{
			// Token: 0x0403282C RID: 206892
			[FieldOffset(0)]
			public float CurrentTime;
		}

		// Token: 0x02009DED RID: 40429
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_GlobalGI_XuanJue_FunctionParams
		{
			// Token: 0x0403282D RID: 206893
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
