using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.FurnaceCore_FireDiff
{
	// Token: 0x02003B81 RID: 15233
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/FurnaceCore_FireDiff/BP_FurnaceCore_FireDiff.BP_FurnaceCore_FireDiff_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class BP_FurnaceCore_FireDiff_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021A3A RID: 137786 RVA: 0x0094EC7B File Offset: 0x0094CE7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FurnaceCore_FireDiff_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/FurnaceCore_FireDiff/BP_FurnaceCore_FireDiff.BP_FurnaceCore_FireDiff_C");
			}
			return BP_FurnaceCore_FireDiff_C._ClassPtr;
		}

		// Token: 0x06021A3B RID: 137787 RVA: 0x0094ECA0 File Offset: 0x0094CEA0
		public BP_FurnaceCore_FireDiff_C() : this(BuiltinUtils.AllocNativeUObject(BP_FurnaceCore_FireDiff_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021A3C RID: 137788 RVA: 0x0094ECC8 File Offset: 0x0094CEC8
		[NullableContext(1)]
		public BP_FurnaceCore_FireDiff_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FurnaceCore_FireDiff_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003C3A RID: 15418
		// (get) Token: 0x06021A3D RID: 137789 RVA: 0x0094ECFC File Offset: 0x0094CEFC
		// (set) Token: 0x06021A3E RID: 137790 RVA: 0x0094ED35 File Offset: 0x0094CF35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003C3B RID: 15419
		// (get) Token: 0x06021A3F RID: 137791 RVA: 0x0094ED56 File Offset: 0x0094CF56
		// (set) Token: 0x06021A40 RID: 137792 RVA: 0x0094ED6A File Offset: 0x0094CF6A
		public unsafe UNiagaraComponent NS_LightningFire_ES3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003C3C RID: 15420
		// (get) Token: 0x06021A41 RID: 137793 RVA: 0x0094ED7F File Offset: 0x0094CF7F
		// (set) Token: 0x06021A42 RID: 137794 RVA: 0x0094ED93 File Offset: 0x0094CF93
		public unsafe UStaticMeshComponent SM_LightningFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003C3D RID: 15421
		// (get) Token: 0x06021A43 RID: 137795 RVA: 0x0094EDA8 File Offset: 0x0094CFA8
		// (set) Token: 0x06021A44 RID: 137796 RVA: 0x0094EDBC File Offset: 0x0094CFBC
		public unsafe USphereComponent DetectionCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003C3E RID: 15422
		// (get) Token: 0x06021A45 RID: 137797 RVA: 0x0094EDD1 File Offset: 0x0094CFD1
		// (set) Token: 0x06021A46 RID: 137798 RVA: 0x0094EDE5 File Offset: 0x0094CFE5
		public unsafe UNiagaraComponent Niagara_Tree
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003C3F RID: 15423
		// (get) Token: 0x06021A47 RID: 137799 RVA: 0x0094EDFA File Offset: 0x0094CFFA
		// (set) Token: 0x06021A48 RID: 137800 RVA: 0x0094EE0E File Offset: 0x0094D00E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003C40 RID: 15424
		// (get) Token: 0x06021A49 RID: 137801 RVA: 0x0094EE23 File Offset: 0x0094D023
		// (set) Token: 0x06021A4A RID: 137802 RVA: 0x0094EE37 File Offset: 0x0094D037
		public unsafe UBoxComponent PostProcessBoundView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003C41 RID: 15425
		// (get) Token: 0x06021A4B RID: 137803 RVA: 0x0094EE4C File Offset: 0x0094D04C
		// (set) Token: 0x06021A4C RID: 137804 RVA: 0x0094EE60 File Offset: 0x0094D060
		public unsafe UTextRenderComponent FireBurnt
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003C42 RID: 15426
		// (get) Token: 0x06021A4D RID: 137805 RVA: 0x0094EE75 File Offset: 0x0094D075
		// (set) Token: 0x06021A4E RID: 137806 RVA: 0x0094EE89 File Offset: 0x0094D089
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003C43 RID: 15427
		// (get) Token: 0x06021A4F RID: 137807 RVA: 0x0094EE9E File Offset: 0x0094D09E
		// (set) Token: 0x06021A50 RID: 137808 RVA: 0x0094EEB2 File Offset: 0x0094D0B2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003C44 RID: 15428
		// (get) Token: 0x06021A51 RID: 137809 RVA: 0x0094EEC7 File Offset: 0x0094D0C7
		// (set) Token: 0x06021A52 RID: 137810 RVA: 0x0094EED7 File Offset: 0x0094D0D7
		public unsafe float SpreadTimeLinear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003C45 RID: 15429
		// (get) Token: 0x06021A53 RID: 137811 RVA: 0x0094EEE8 File Offset: 0x0094D0E8
		// (set) Token: 0x06021A54 RID: 137812 RVA: 0x0094EEF8 File Offset: 0x0094D0F8
		public unsafe bool StartPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C46 RID: 15430
		// (get) Token: 0x06021A55 RID: 137813 RVA: 0x0094EF09 File Offset: 0x0094D109
		// (set) Token: 0x06021A56 RID: 137814 RVA: 0x0094EF1D File Offset: 0x0094D11D
		public unsafe FLinearColor FireColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003C47 RID: 15431
		// (get) Token: 0x06021A57 RID: 137815 RVA: 0x0094EF32 File Offset: 0x0094D132
		// (set) Token: 0x06021A58 RID: 137816 RVA: 0x0094EF42 File Offset: 0x0094D142
		public unsafe float SpreadSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003C48 RID: 15432
		// (get) Token: 0x06021A59 RID: 137817 RVA: 0x0094EF53 File Offset: 0x0094D153
		// (set) Token: 0x06021A5A RID: 137818 RVA: 0x0094EF63 File Offset: 0x0094D163
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003C49 RID: 15433
		// (get) Token: 0x06021A5B RID: 137819 RVA: 0x0094EF74 File Offset: 0x0094D174
		// (set) Token: 0x06021A5C RID: 137820 RVA: 0x0094EF84 File Offset: 0x0094D184
		public unsafe float BoundSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003C4A RID: 15434
		// (get) Token: 0x06021A5D RID: 137821 RVA: 0x0094EF95 File Offset: 0x0094D195
		// (set) Token: 0x06021A5E RID: 137822 RVA: 0x0094EFA5 File Offset: 0x0094D1A5
		public unsafe float Is_Play
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003C4B RID: 15435
		// (get) Token: 0x06021A5F RID: 137823 RVA: 0x0094EFB6 File Offset: 0x0094D1B6
		// (set) Token: 0x06021A60 RID: 137824 RVA: 0x0094EFCB File Offset: 0x0094D1CB
		[Nullable(1)]
		public TSoftObjectPtr<AKuroGlobalGI> GlobalGI
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroGlobalGI>(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_17, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_17, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17003C4C RID: 15436
		// (get) Token: 0x06021A61 RID: 137825 RVA: 0x0094EFF0 File Offset: 0x0094D1F0
		// (set) Token: 0x06021A62 RID: 137826 RVA: 0x0094F005 File Offset: 0x0094D205
		[Nullable(1)]
		public TSoftObjectPtr<AKuroGlobalGI> GlobalGI_Temp
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroGlobalGI>(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_18, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17003C4D RID: 15437
		// (get) Token: 0x06021A63 RID: 137827 RVA: 0x0094F02A File Offset: 0x0094D22A
		// (set) Token: 0x06021A64 RID: 137828 RVA: 0x0094F03A File Offset: 0x0094D23A
		public unsafe float Probability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003C4E RID: 15438
		// (get) Token: 0x06021A65 RID: 137829 RVA: 0x0094F04B File Offset: 0x0094D24B
		// (set) Token: 0x06021A66 RID: 137830 RVA: 0x0094F05B File Offset: 0x0094D25B
		public unsafe float DeltaScond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003C4F RID: 15439
		// (get) Token: 0x06021A67 RID: 137831 RVA: 0x0094F06C File Offset: 0x0094D26C
		// (set) Token: 0x06021A68 RID: 137832 RVA: 0x0094F07C File Offset: 0x0094D27C
		public unsafe float TriggerDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003C50 RID: 15440
		// (get) Token: 0x06021A69 RID: 137833 RVA: 0x0094F08D File Offset: 0x0094D28D
		// (set) Token: 0x06021A6A RID: 137834 RVA: 0x0094F0A1 File Offset: 0x0094D2A1
		public unsafe FVectorDouble NiagaraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003C51 RID: 15441
		// (get) Token: 0x06021A6B RID: 137835 RVA: 0x0094F0B6 File Offset: 0x0094D2B6
		// (set) Token: 0x06021A6C RID: 137836 RVA: 0x0094F0C6 File Offset: 0x0094D2C6
		public unsafe float TakeEffectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003C52 RID: 15442
		// (get) Token: 0x06021A6D RID: 137837 RVA: 0x0094F0D7 File Offset: 0x0094D2D7
		// (set) Token: 0x06021A6E RID: 137838 RVA: 0x0094F0E7 File Offset: 0x0094D2E7
		public unsafe bool bPlayerIsTriggerZone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C53 RID: 15443
		// (get) Token: 0x06021A6F RID: 137839 RVA: 0x0094F0F8 File Offset: 0x0094D2F8
		// (set) Token: 0x06021A70 RID: 137840 RVA: 0x0094F108 File Offset: 0x0094D308
		public unsafe bool DeBug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C54 RID: 15444
		// (get) Token: 0x06021A71 RID: 137841 RVA: 0x0094F119 File Offset: 0x0094D319
		// (set) Token: 0x06021A72 RID: 137842 RVA: 0x0094F129 File Offset: 0x0094D329
		public unsafe float TreeFireSpriteSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17003C55 RID: 15445
		// (get) Token: 0x06021A73 RID: 137843 RVA: 0x0094F13A File Offset: 0x0094D33A
		// (set) Token: 0x06021A74 RID: 137844 RVA: 0x0094F14E File Offset: 0x0094D34E
		public unsafe UKuroWeatherDataAsset WeatherDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x17003C56 RID: 15446
		// (get) Token: 0x06021A75 RID: 137845 RVA: 0x0094F163 File Offset: 0x0094D363
		// (set) Token: 0x06021A76 RID: 137846 RVA: 0x0094F173 File Offset: 0x0094D373
		public unsafe float PostProcessRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17003C57 RID: 15447
		// (get) Token: 0x06021A77 RID: 137847 RVA: 0x0094F184 File Offset: 0x0094D384
		// (set) Token: 0x06021A78 RID: 137848 RVA: 0x0094F194 File Offset: 0x0094D394
		public unsafe float Post_BlendRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17003C58 RID: 15448
		// (get) Token: 0x06021A79 RID: 137849 RVA: 0x0094F1A5 File Offset: 0x0094D3A5
		// (set) Token: 0x06021A7A RID: 137850 RVA: 0x0094F1B5 File Offset: 0x0094D3B5
		public unsafe float Post_Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17003C59 RID: 15449
		// (get) Token: 0x06021A7B RID: 137851 RVA: 0x0094F1C6 File Offset: 0x0094D3C6
		// (set) Token: 0x06021A7C RID: 137852 RVA: 0x0094F1DA File Offset: 0x0094D3DA
		public unsafe AStaticMeshActor FoliageStaticMeshActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x17003C5A RID: 15450
		// (get) Token: 0x06021A7D RID: 137853 RVA: 0x0094F1EF File Offset: 0x0094D3EF
		// (set) Token: 0x06021A7E RID: 137854 RVA: 0x0094F1FF File Offset: 0x0094D3FF
		public unsafe bool View_Probability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C5B RID: 15451
		// (get) Token: 0x06021A7F RID: 137855 RVA: 0x0094F210 File Offset: 0x0094D410
		// (set) Token: 0x06021A80 RID: 137856 RVA: 0x0094F220 File Offset: 0x0094D420
		public unsafe bool bIsOnCooldown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C5C RID: 15452
		// (get) Token: 0x06021A81 RID: 137857 RVA: 0x0094F231 File Offset: 0x0094D431
		// (set) Token: 0x06021A82 RID: 137858 RVA: 0x0094F241 File Offset: 0x0094D441
		public unsafe float CooldoownTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17003C5D RID: 15453
		// (get) Token: 0x06021A83 RID: 137859 RVA: 0x0094F252 File Offset: 0x0094D452
		// (set) Token: 0x06021A84 RID: 137860 RVA: 0x0094F262 File Offset: 0x0094D462
		public unsafe bool TriggerCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C5E RID: 15454
		// (get) Token: 0x06021A85 RID: 137861 RVA: 0x0094F273 File Offset: 0x0094D473
		// (set) Token: 0x06021A86 RID: 137862 RVA: 0x0094F283 File Offset: 0x0094D483
		public unsafe bool Is_ES3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FurnaceCore_FireDiff_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003C5F RID: 15455
		// (get) Token: 0x06021A87 RID: 137863 RVA: 0x0094F294 File Offset: 0x0094D494
		// (set) Token: 0x06021A88 RID: 137864 RVA: 0x0094F2A8 File Offset: 0x0094D4A8
		public unsafe UAkAudioEvent AudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FurnaceCore_FireDiff_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x06021A89 RID: 137865 RVA: 0x0094F2BD File Offset: 0x0094D4BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__Set_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x06021A8A RID: 137866 RVA: 0x0094F2D1 File Offset: 0x0094D4D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetPostProcessVolume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__SetPostProcessVolume_NativeFunctionPtr, null);
		}

		// Token: 0x06021A8B RID: 137867 RVA: 0x0094F2E8 File Offset: 0x0094D4E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ContorlParameter(bool NewParam)
		{
			BP_FurnaceCore_FireDiff_C.__ContorlParameter_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__ContorlParameter_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__ContorlParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__ContorlParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ContorlParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A8C RID: 137868 RVA: 0x0094F331 File Offset: 0x0094D531
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_InitialParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__Set_InitialParameter_NativeFunctionPtr, null);
		}

		// Token: 0x06021A8D RID: 137869 RVA: 0x0094F345 File Offset: 0x0094D545
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Tick_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__Set_Tick_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x06021A8E RID: 137870 RVA: 0x0094F359 File Offset: 0x0094D559
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugPlayEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__DebugPlayEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06021A8F RID: 137871 RVA: 0x0094F36D File Offset: 0x0094D56D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021A90 RID: 137872 RVA: 0x0094F381 File Offset: 0x0094D581
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021A91 RID: 137873 RVA: 0x0094F398 File Offset: 0x0094D598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FurnaceCore_FireDiff_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A92 RID: 137874 RVA: 0x0094F3E0 File Offset: 0x0094D5E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FurnaceCore_FireDiff_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021A93 RID: 137875 RVA: 0x0094F427 File Offset: 0x0094D627
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021A94 RID: 137876 RVA: 0x0094F43B File Offset: 0x0094D63B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021A95 RID: 137877 RVA: 0x0094F450 File Offset: 0x0094D650
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetCooldownEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ResetCooldownEvent_NativeFunctionPtr, null);
		}

		// Token: 0x06021A96 RID: 137878 RVA: 0x0094F464 File Offset: 0x0094D664
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A97 RID: 137879 RVA: 0x0094F520 File Offset: 0x0094D720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A98 RID: 137880 RVA: 0x0094F5AC File Offset: 0x0094D7AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FurnaceCore_FireDiff_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021A99 RID: 137881 RVA: 0x0094F5F4 File Offset: 0x0094D7F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FurnaceCore_FireDiff_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021A9A RID: 137882 RVA: 0x0094F63C File Offset: 0x0094D83C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FurnaceCore_FireDiff(int EntryPoint)
		{
			BP_FurnaceCore_FireDiff_C.__ExecuteUbergraph_BP_FurnaceCore_FireDiff_FunctionParams* ptr = stackalloc BP_FurnaceCore_FireDiff_C.__ExecuteUbergraph_BP_FurnaceCore_FireDiff_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_FurnaceCore_FireDiff_C.__ExecuteUbergraph_BP_FurnaceCore_FireDiff_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FurnaceCore_FireDiff_C.__ExecuteUbergraph_BP_FurnaceCore_FireDiff_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FurnaceCore_FireDiff_C.__ExecuteUbergraph_BP_FurnaceCore_FireDiff_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021A9B RID: 137883 RVA: 0x0094F686 File Offset: 0x0094D886
		protected BP_FurnaceCore_FireDiff_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010F42 RID: 69442
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/FurnaceCore_FireDiff/BP_FurnaceCore_FireDiff.BP_FurnaceCore_FireDiff_C";

		// Token: 0x04010F43 RID: 69443
		private static IntPtr _ClassPtr;

		// Token: 0x04010F44 RID: 69444
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010F45 RID: 69445
		internal static int __PropertyOffset_0;

		// Token: 0x04010F46 RID: 69446
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010F47 RID: 69447
		internal static int __PropertyOffset_1;

		// Token: 0x04010F48 RID: 69448
		internal static int __PropertyOffset_2;

		// Token: 0x04010F49 RID: 69449
		internal static int __PropertyOffset_3;

		// Token: 0x04010F4A RID: 69450
		internal static int __PropertyOffset_4;

		// Token: 0x04010F4B RID: 69451
		internal static int __PropertyOffset_5;

		// Token: 0x04010F4C RID: 69452
		internal static int __PropertyOffset_6;

		// Token: 0x04010F4D RID: 69453
		internal static int __PropertyOffset_7;

		// Token: 0x04010F4E RID: 69454
		internal static int __PropertyOffset_8;

		// Token: 0x04010F4F RID: 69455
		internal static int __PropertyOffset_9;

		// Token: 0x04010F50 RID: 69456
		internal static int __PropertyOffset_10;

		// Token: 0x04010F51 RID: 69457
		internal static int __PropertyOffset_11;

		// Token: 0x04010F52 RID: 69458
		internal static int __PropertyOffset_12;

		// Token: 0x04010F53 RID: 69459
		internal static int __PropertyOffset_13;

		// Token: 0x04010F54 RID: 69460
		internal static int __PropertyOffset_14;

		// Token: 0x04010F55 RID: 69461
		internal static int __PropertyOffset_15;

		// Token: 0x04010F56 RID: 69462
		internal static int __PropertyOffset_16;

		// Token: 0x04010F57 RID: 69463
		internal static int __PropertyOffset_17;

		// Token: 0x04010F58 RID: 69464
		internal static int __PropertyOffset_18;

		// Token: 0x04010F59 RID: 69465
		internal static int __PropertyOffset_19;

		// Token: 0x04010F5A RID: 69466
		internal static int __PropertyOffset_20;

		// Token: 0x04010F5B RID: 69467
		internal static int __PropertyOffset_21;

		// Token: 0x04010F5C RID: 69468
		internal static int __PropertyOffset_22;

		// Token: 0x04010F5D RID: 69469
		internal static int __PropertyOffset_23;

		// Token: 0x04010F5E RID: 69470
		internal static int __PropertyOffset_24;

		// Token: 0x04010F5F RID: 69471
		internal static int __PropertyOffset_25;

		// Token: 0x04010F60 RID: 69472
		internal static int __PropertyOffset_26;

		// Token: 0x04010F61 RID: 69473
		internal static int __PropertyOffset_27;

		// Token: 0x04010F62 RID: 69474
		internal static int __PropertyOffset_28;

		// Token: 0x04010F63 RID: 69475
		internal static int __PropertyOffset_29;

		// Token: 0x04010F64 RID: 69476
		internal static int __PropertyOffset_30;

		// Token: 0x04010F65 RID: 69477
		internal static int __PropertyOffset_31;

		// Token: 0x04010F66 RID: 69478
		internal static int __PropertyOffset_32;

		// Token: 0x04010F67 RID: 69479
		internal static int __PropertyOffset_33;

		// Token: 0x04010F68 RID: 69480
		internal static int __PropertyOffset_34;

		// Token: 0x04010F69 RID: 69481
		internal static int __PropertyOffset_35;

		// Token: 0x04010F6A RID: 69482
		internal static int __PropertyOffset_36;

		// Token: 0x04010F6B RID: 69483
		internal static int __PropertyOffset_37;

		// Token: 0x04010F6C RID: 69484
		private static IntPtr __Set_ES3_NativeFunctionPtr;

		// Token: 0x04010F6D RID: 69485
		private static IntPtr __SetPostProcessVolume_NativeFunctionPtr;

		// Token: 0x04010F6E RID: 69486
		private static IntPtr __ContorlParameter_NativeFunctionPtr;

		// Token: 0x04010F6F RID: 69487
		private static IntPtr __Set_InitialParameter_NativeFunctionPtr;

		// Token: 0x04010F70 RID: 69488
		private static IntPtr __Set_Tick_Parameter_NativeFunctionPtr;

		// Token: 0x04010F71 RID: 69489
		private static IntPtr __DebugPlayEffect_NativeFunctionPtr;

		// Token: 0x04010F72 RID: 69490
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010F73 RID: 69491
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010F74 RID: 69492
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010F75 RID: 69493
		private static IntPtr __ResetCooldownEvent_NativeFunctionPtr;

		// Token: 0x04010F76 RID: 69494
		private static IntPtr __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010F77 RID: 69495
		private static IntPtr __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010F78 RID: 69496
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010F79 RID: 69497
		private static IntPtr __ExecuteUbergraph_BP_FurnaceCore_FireDiff_NativeFunctionPtr;

		// Token: 0x02009B0D RID: 39693
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __ContorlParameter_FunctionParams
		{
			// Token: 0x040322B5 RID: 205493
			[FieldOffset(0)]
			public bool NewParam;
		}

		// Token: 0x02009B0E RID: 39694
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322B6 RID: 205494
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B0F RID: 39695
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322B7 RID: 205495
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322B8 RID: 205496
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322B9 RID: 205497
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322BA RID: 205498
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040322BB RID: 205499
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040322BC RID: 205500
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B10 RID: 39696
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322BD RID: 205501
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322BE RID: 205502
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322BF RID: 205503
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322C0 RID: 205504
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B11 RID: 39697
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040322C1 RID: 205505
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B12 RID: 39698
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __ExecuteUbergraph_BP_FurnaceCore_FireDiff_FunctionParams
		{
			// Token: 0x040322C2 RID: 205506
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
