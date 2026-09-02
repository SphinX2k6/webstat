using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.CloudTraceTail;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud
{
	// Token: 0x02003BE9 RID: 15337
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/BP_KuroTraceCloud.BP_KuroTraceCloud_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_KuroTraceCloud_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022847 RID: 141383 RVA: 0x0096782B File Offset: 0x00965A2B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroTraceCloud_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/BP_KuroTraceCloud.BP_KuroTraceCloud_C");
			}
			return BP_KuroTraceCloud_C._ClassPtr;
		}

		// Token: 0x06022848 RID: 141384 RVA: 0x00967850 File Offset: 0x00965A50
		public BP_KuroTraceCloud_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroTraceCloud_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022849 RID: 141385 RVA: 0x00967878 File Offset: 0x00965A78
		[NullableContext(1)]
		public BP_KuroTraceCloud_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroTraceCloud_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700413F RID: 16703
		// (get) Token: 0x0602284A RID: 141386 RVA: 0x009678AC File Offset: 0x00965AAC
		// (set) Token: 0x0602284B RID: 141387 RVA: 0x009678E5 File Offset: 0x00965AE5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004140 RID: 16704
		// (get) Token: 0x0602284C RID: 141388 RVA: 0x00967906 File Offset: 0x00965B06
		// (set) Token: 0x0602284D RID: 141389 RVA: 0x0096791A File Offset: 0x00965B1A
		public unsafe BPC_VolumeCloudTrail_C BPC_VolumeCloudTrail
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BPC_VolumeCloudTrail_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004141 RID: 16705
		// (get) Token: 0x0602284E RID: 141390 RVA: 0x0096792F File Offset: 0x00965B2F
		// (set) Token: 0x0602284F RID: 141391 RVA: 0x00967943 File Offset: 0x00965B43
		public unsafe USceneComponent FadeRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004142 RID: 16706
		// (get) Token: 0x06022850 RID: 141392 RVA: 0x00967958 File Offset: 0x00965B58
		// (set) Token: 0x06022851 RID: 141393 RVA: 0x0096796C File Offset: 0x00965B6C
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004143 RID: 16707
		// (get) Token: 0x06022852 RID: 141394 RVA: 0x00967981 File Offset: 0x00965B81
		// (set) Token: 0x06022853 RID: 141395 RVA: 0x00967995 File Offset: 0x00965B95
		public unsafe USceneComponent CloudRange
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004144 RID: 16708
		// (get) Token: 0x06022854 RID: 141396 RVA: 0x009679AA File Offset: 0x00965BAA
		// (set) Token: 0x06022855 RID: 141397 RVA: 0x009679BE File Offset: 0x00965BBE
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17004145 RID: 16709
		// (get) Token: 0x06022856 RID: 141398 RVA: 0x009679D3 File Offset: 0x00965BD3
		// (set) Token: 0x06022857 RID: 141399 RVA: 0x009679E3 File Offset: 0x00965BE3
		public unsafe float CloudLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004146 RID: 16710
		// (get) Token: 0x06022858 RID: 141400 RVA: 0x009679F4 File Offset: 0x00965BF4
		// (set) Token: 0x06022859 RID: 141401 RVA: 0x00967A04 File Offset: 0x00965C04
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004147 RID: 16711
		// (get) Token: 0x0602285A RID: 141402 RVA: 0x00967A18 File Offset: 0x00965C18
		// (set) Token: 0x0602285B RID: 141403 RVA: 0x00967A51 File Offset: 0x00965C51
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
					result = (this._Data = new TArray<SD_KuroTraceCloudData>(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_8, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x17004148 RID: 16712
		// (get) Token: 0x0602285C RID: 141404 RVA: 0x00967A60 File Offset: 0x00965C60
		// (set) Token: 0x0602285D RID: 141405 RVA: 0x00967A99 File Offset: 0x00965C99
		[Nullable(1)]
		public SD_KuroTraceCloudData LerpData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SD_KuroTraceCloudData result;
				if ((result = this._LerpData) == null)
				{
					result = (this._LerpData = new SD_KuroTraceCloudData(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SD_KuroTraceCloudData.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004149 RID: 16713
		// (get) Token: 0x0602285E RID: 141406 RVA: 0x00967ABA File Offset: 0x00965CBA
		// (set) Token: 0x0602285F RID: 141407 RVA: 0x00967ACA File Offset: 0x00965CCA
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700414A RID: 16714
		// (get) Token: 0x06022860 RID: 141408 RVA: 0x00967ADB File Offset: 0x00965CDB
		// (set) Token: 0x06022861 RID: 141409 RVA: 0x00967AEF File Offset: 0x00965CEF
		public unsafe UMaterialInstanceConstant HighCloudMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x1700414B RID: 16715
		// (get) Token: 0x06022862 RID: 141410 RVA: 0x00967B04 File Offset: 0x00965D04
		// (set) Token: 0x06022863 RID: 141411 RVA: 0x00967B14 File Offset: 0x00965D14
		public unsafe float FadeHeightPercentage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700414C RID: 16716
		// (get) Token: 0x06022864 RID: 141412 RVA: 0x00967B25 File Offset: 0x00965D25
		// (set) Token: 0x06022865 RID: 141413 RVA: 0x00967B35 File Offset: 0x00965D35
		public unsafe bool bDrawFadeBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700414D RID: 16717
		// (get) Token: 0x06022866 RID: 141414 RVA: 0x00967B46 File Offset: 0x00965D46
		// (set) Token: 0x06022867 RID: 141415 RVA: 0x00967B5A File Offset: 0x00965D5A
		public unsafe UMaterialInstanceConstant PlaneMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x1700414E RID: 16718
		// (get) Token: 0x06022868 RID: 141416 RVA: 0x00967B6F File Offset: 0x00965D6F
		// (set) Token: 0x06022869 RID: 141417 RVA: 0x00967B83 File Offset: 0x00965D83
		public unsafe AActor boundActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x1700414F RID: 16719
		// (get) Token: 0x0602286A RID: 141418 RVA: 0x00967B98 File Offset: 0x00965D98
		// (set) Token: 0x0602286B RID: 141419 RVA: 0x00967BAC File Offset: 0x00965DAC
		public unsafe AStaticMeshActor bottomPlane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17004150 RID: 16720
		// (get) Token: 0x0602286C RID: 141420 RVA: 0x00967BC1 File Offset: 0x00965DC1
		// (set) Token: 0x0602286D RID: 141421 RVA: 0x00967BD5 File Offset: 0x00965DD5
		public unsafe FLinearColor LocalLightPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004151 RID: 16721
		// (get) Token: 0x0602286E RID: 141422 RVA: 0x00967BEA File Offset: 0x00965DEA
		// (set) Token: 0x0602286F RID: 141423 RVA: 0x00967BFE File Offset: 0x00965DFE
		public unsafe FLinearColor LocalLightPos2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004152 RID: 16722
		// (get) Token: 0x06022870 RID: 141424 RVA: 0x00967C13 File Offset: 0x00965E13
		// (set) Token: 0x06022871 RID: 141425 RVA: 0x00967C27 File Offset: 0x00965E27
		public unsafe FLinearColor LocalLightPos3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004153 RID: 16723
		// (get) Token: 0x06022872 RID: 141426 RVA: 0x00967C3C File Offset: 0x00965E3C
		// (set) Token: 0x06022873 RID: 141427 RVA: 0x00967C50 File Offset: 0x00965E50
		public unsafe FLinearColor LocalLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004154 RID: 16724
		// (get) Token: 0x06022874 RID: 141428 RVA: 0x00967C65 File Offset: 0x00965E65
		// (set) Token: 0x06022875 RID: 141429 RVA: 0x00967C79 File Offset: 0x00965E79
		public unsafe FLinearColor LocalLightColor2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004155 RID: 16725
		// (get) Token: 0x06022876 RID: 141430 RVA: 0x00967C8E File Offset: 0x00965E8E
		// (set) Token: 0x06022877 RID: 141431 RVA: 0x00967CA2 File Offset: 0x00965EA2
		public unsafe FLinearColor LocalLightColor3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17004156 RID: 16726
		// (get) Token: 0x06022878 RID: 141432 RVA: 0x00967CB7 File Offset: 0x00965EB7
		// (set) Token: 0x06022879 RID: 141433 RVA: 0x00967CCB File Offset: 0x00965ECB
		public unsafe FLinearColor TempLightColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004157 RID: 16727
		// (get) Token: 0x0602287A RID: 141434 RVA: 0x00967CE0 File Offset: 0x00965EE0
		// (set) Token: 0x0602287B RID: 141435 RVA: 0x00967CF4 File Offset: 0x00965EF4
		public unsafe FLinearColor TempLightColor2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004158 RID: 16728
		// (get) Token: 0x0602287C RID: 141436 RVA: 0x00967D09 File Offset: 0x00965F09
		// (set) Token: 0x0602287D RID: 141437 RVA: 0x00967D1D File Offset: 0x00965F1D
		public unsafe FLinearColor TempLightColor3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004159 RID: 16729
		// (get) Token: 0x0602287E RID: 141438 RVA: 0x00967D32 File Offset: 0x00965F32
		// (set) Token: 0x0602287F RID: 141439 RVA: 0x00967D42 File Offset: 0x00965F42
		public unsafe float LightAttenuationC1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700415A RID: 16730
		// (get) Token: 0x06022880 RID: 141440 RVA: 0x00967D53 File Offset: 0x00965F53
		// (set) Token: 0x06022881 RID: 141441 RVA: 0x00967D63 File Offset: 0x00965F63
		public unsafe float LightAttenuationC2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x1700415B RID: 16731
		// (get) Token: 0x06022882 RID: 141442 RVA: 0x00967D74 File Offset: 0x00965F74
		// (set) Token: 0x06022883 RID: 141443 RVA: 0x00967D88 File Offset: 0x00965F88
		public unsafe AActor lightPosProxy
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x1700415C RID: 16732
		// (get) Token: 0x06022884 RID: 141444 RVA: 0x00967D9D File Offset: 0x00965F9D
		// (set) Token: 0x06022885 RID: 141445 RVA: 0x00967DB1 File Offset: 0x00965FB1
		public unsafe AActor lightPosProxy2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x1700415D RID: 16733
		// (get) Token: 0x06022886 RID: 141446 RVA: 0x00967DC6 File Offset: 0x00965FC6
		// (set) Token: 0x06022887 RID: 141447 RVA: 0x00967DDA File Offset: 0x00965FDA
		public unsafe AActor lightPosProxy3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_30);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_30, value);
			}
		}

		// Token: 0x1700415E RID: 16734
		// (get) Token: 0x06022888 RID: 141448 RVA: 0x00967DEF File Offset: 0x00965FEF
		// (set) Token: 0x06022889 RID: 141449 RVA: 0x00967E03 File Offset: 0x00966003
		public unsafe FVector RadialMaskPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700415F RID: 16735
		// (get) Token: 0x0602288A RID: 141450 RVA: 0x00967E18 File Offset: 0x00966018
		// (set) Token: 0x0602288B RID: 141451 RVA: 0x00967E28 File Offset: 0x00966028
		public unsafe float RadialMaskRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17004160 RID: 16736
		// (get) Token: 0x0602288C RID: 141452 RVA: 0x00967E39 File Offset: 0x00966039
		// (set) Token: 0x0602288D RID: 141453 RVA: 0x00967E4D File Offset: 0x0096604D
		public unsafe FVector FadeBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17004161 RID: 16737
		// (get) Token: 0x0602288E RID: 141454 RVA: 0x00967E62 File Offset: 0x00966062
		// (set) Token: 0x0602288F RID: 141455 RVA: 0x00967E72 File Offset: 0x00966072
		public unsafe BP_EWorldType NewVar_0
		{
			get
			{
				return (BP_EWorldType)(*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_34));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_34) = (byte)value;
			}
		}

		// Token: 0x17004162 RID: 16738
		// (get) Token: 0x06022890 RID: 141456 RVA: 0x00967E83 File Offset: 0x00966083
		// (set) Token: 0x06022891 RID: 141457 RVA: 0x00967E93 File Offset: 0x00966093
		public unsafe BP_EWorldType Editor_Type_0
		{
			get
			{
				return (BP_EWorldType)(*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_35));
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_35) = (byte)value;
			}
		}

		// Token: 0x17004163 RID: 16739
		// (get) Token: 0x06022892 RID: 141458 RVA: 0x00967EA4 File Offset: 0x009660A4
		// (set) Token: 0x06022893 RID: 141459 RVA: 0x00967EB4 File Offset: 0x009660B4
		public unsafe float Dist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17004164 RID: 16740
		// (get) Token: 0x06022894 RID: 141460 RVA: 0x00967EC5 File Offset: 0x009660C5
		// (set) Token: 0x06022895 RID: 141461 RVA: 0x00967ED5 File Offset: 0x009660D5
		public unsafe float FadeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004165 RID: 16741
		// (get) Token: 0x06022896 RID: 141462 RVA: 0x00967EE6 File Offset: 0x009660E6
		// (set) Token: 0x06022897 RID: 141463 RVA: 0x00967EF6 File Offset: 0x009660F6
		public unsafe float MinAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17004166 RID: 16742
		// (get) Token: 0x06022898 RID: 141464 RVA: 0x00967F07 File Offset: 0x00966107
		// (set) Token: 0x06022899 RID: 141465 RVA: 0x00967F17 File Offset: 0x00966117
		public unsafe int NowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroTraceCloud_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17004167 RID: 16743
		// (get) Token: 0x0602289A RID: 141466 RVA: 0x00967F28 File Offset: 0x00966128
		// (set) Token: 0x0602289B RID: 141467 RVA: 0x00967F3C File Offset: 0x0096613C
		public unsafe UMaterialInstanceConstant HighCloudMaterial_SuperHigh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_40);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroTraceCloud_C.__PropertyOffset_40, value);
			}
		}

		// Token: 0x0602289C RID: 141468 RVA: 0x00967F54 File Offset: 0x00966154
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitCloud(UMaterialInterface Material)
		{
			BP_KuroTraceCloud_C.__InitCloud_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__InitCloud_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__InitCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__InitCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__InitCloud_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602289D RID: 141469 RVA: 0x00967FAC File Offset: 0x009661AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DistanceFromBox(FVector P, FVector Box, ref float dist)
		{
			BP_KuroTraceCloud_C.__DistanceFromBox_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__DistanceFromBox_FunctionParams[(UIntPtr)107] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__DistanceFromBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__DistanceFromBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->P = P;
			ptr->Box = Box;
			ptr->dist = dist;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__DistanceFromBox_NativeFunctionPtr, (void*)ptr);
			dist = ptr->dist;
		}

		// Token: 0x0602289E RID: 141470 RVA: 0x0096800C File Offset: 0x0096620C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShowCloud(bool bNewVisibility)
		{
			BP_KuroTraceCloud_C.__ShowCloud_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__ShowCloud_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__ShowCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__ShowCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bNewVisibility = bNewVisibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ShowCloud_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602289F RID: 141471 RVA: 0x00968052 File Offset: 0x00966252
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Cloud_Fade()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__Update_Cloud_Fade_NativeFunctionPtr, null);
		}

		// Token: 0x060228A0 RID: 141472 RVA: 0x00968068 File Offset: 0x00966268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLerpGIData(float Time, ref SD_KuroTraceCloudData LerpData)
		{
			BP_KuroTraceCloud_C.__GetLerpGIData_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__GetLerpGIData_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__GetLerpGIData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__GetLerpGIData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			if (LerpData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SD_KuroTraceCloudData.StaticStruct(), &ptr->LerpData, LerpData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__GetLerpGIData_NativeFunctionPtr, (void*)ptr);
			if (LerpData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SD_KuroTraceCloudData.StaticStruct(), LerpData.NativePtr, &ptr->LerpData, 1, false);
			}
		}

		// Token: 0x060228A1 RID: 141473 RVA: 0x009680FC File Offset: 0x009662FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloudLighting(UMaterialInstanceDynamic Material)
		{
			BP_KuroTraceCloud_C.__UpdateCloudLighting_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__UpdateCloudLighting_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__UpdateCloudLighting_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__UpdateCloudLighting_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Material = ((Material != null) ? Material.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__UpdateCloudLighting_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060228A2 RID: 141474 RVA: 0x00968154 File Offset: 0x00966354
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCloudTransform(UStaticMeshComponent CloudCube)
		{
			BP_KuroTraceCloud_C.__UpdateCloudTransform_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__UpdateCloudTransform_FunctionParams[(UIntPtr)431] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__UpdateCloudTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__UpdateCloudTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CloudCube = ((CloudCube != null) ? CloudCube.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__UpdateCloudTransform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060228A3 RID: 141475 RVA: 0x009681AC File Offset: 0x009663AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060228A4 RID: 141476 RVA: 0x009681C0 File Offset: 0x009663C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTraceCloud_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060228A5 RID: 141477 RVA: 0x009681D8 File Offset: 0x009663D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroTraceCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060228A6 RID: 141478 RVA: 0x00968220 File Offset: 0x00966420
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroTraceCloud_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060228A7 RID: 141479 RVA: 0x00968267 File Offset: 0x00966467
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060228A8 RID: 141480 RVA: 0x0096827B File Offset: 0x0096647B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060228A9 RID: 141481 RVA: 0x0096828F File Offset: 0x0096648F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060228AA RID: 141482 RVA: 0x009682A4 File Offset: 0x009664A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x060228AB RID: 141483 RVA: 0x009682B8 File Offset: 0x009664B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroTraceCloud_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060228AC RID: 141484 RVA: 0x00968304 File Offset: 0x00966504
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroTraceCloud_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060228AD RID: 141485 RVA: 0x00968350 File Offset: 0x00966550
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroTraceCloud(int EntryPoint)
		{
			BP_KuroTraceCloud_C.__ExecuteUbergraph_BP_KuroTraceCloud_FunctionParams* ptr = stackalloc BP_KuroTraceCloud_C.__ExecuteUbergraph_BP_KuroTraceCloud_FunctionParams[(UIntPtr)575] + 15L / (long)sizeof(BP_KuroTraceCloud_C.__ExecuteUbergraph_BP_KuroTraceCloud_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroTraceCloud_C.__ExecuteUbergraph_BP_KuroTraceCloud_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroTraceCloud_C.__ExecuteUbergraph_BP_KuroTraceCloud_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060228AE RID: 141486 RVA: 0x0096839A File Offset: 0x0096659A
		protected BP_KuroTraceCloud_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040117B1 RID: 71601
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/BP_KuroTraceCloud.BP_KuroTraceCloud_C";

		// Token: 0x040117B2 RID: 71602
		private static IntPtr _ClassPtr;

		// Token: 0x040117B3 RID: 71603
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040117B4 RID: 71604
		internal static int __PropertyOffset_0;

		// Token: 0x040117B5 RID: 71605
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040117B6 RID: 71606
		internal static int __PropertyOffset_1;

		// Token: 0x040117B7 RID: 71607
		internal static int __PropertyOffset_2;

		// Token: 0x040117B8 RID: 71608
		internal static int __PropertyOffset_3;

		// Token: 0x040117B9 RID: 71609
		internal static int __PropertyOffset_4;

		// Token: 0x040117BA RID: 71610
		internal static int __PropertyOffset_5;

		// Token: 0x040117BB RID: 71611
		internal static int __PropertyOffset_6;

		// Token: 0x040117BC RID: 71612
		internal static int __PropertyOffset_7;

		// Token: 0x040117BD RID: 71613
		internal static int __PropertyOffset_8;

		// Token: 0x040117BE RID: 71614
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SD_KuroTraceCloudData> _Data;

		// Token: 0x040117BF RID: 71615
		internal static int __PropertyOffset_9;

		// Token: 0x040117C0 RID: 71616
		private SD_KuroTraceCloudData _LerpData;

		// Token: 0x040117C1 RID: 71617
		internal static int __PropertyOffset_10;

		// Token: 0x040117C2 RID: 71618
		internal static int __PropertyOffset_11;

		// Token: 0x040117C3 RID: 71619
		internal static int __PropertyOffset_12;

		// Token: 0x040117C4 RID: 71620
		internal static int __PropertyOffset_13;

		// Token: 0x040117C5 RID: 71621
		internal static int __PropertyOffset_14;

		// Token: 0x040117C6 RID: 71622
		internal static int __PropertyOffset_15;

		// Token: 0x040117C7 RID: 71623
		internal static int __PropertyOffset_16;

		// Token: 0x040117C8 RID: 71624
		internal static int __PropertyOffset_17;

		// Token: 0x040117C9 RID: 71625
		internal static int __PropertyOffset_18;

		// Token: 0x040117CA RID: 71626
		internal static int __PropertyOffset_19;

		// Token: 0x040117CB RID: 71627
		internal static int __PropertyOffset_20;

		// Token: 0x040117CC RID: 71628
		internal static int __PropertyOffset_21;

		// Token: 0x040117CD RID: 71629
		internal static int __PropertyOffset_22;

		// Token: 0x040117CE RID: 71630
		internal static int __PropertyOffset_23;

		// Token: 0x040117CF RID: 71631
		internal static int __PropertyOffset_24;

		// Token: 0x040117D0 RID: 71632
		internal static int __PropertyOffset_25;

		// Token: 0x040117D1 RID: 71633
		internal static int __PropertyOffset_26;

		// Token: 0x040117D2 RID: 71634
		internal static int __PropertyOffset_27;

		// Token: 0x040117D3 RID: 71635
		internal static int __PropertyOffset_28;

		// Token: 0x040117D4 RID: 71636
		internal static int __PropertyOffset_29;

		// Token: 0x040117D5 RID: 71637
		internal static int __PropertyOffset_30;

		// Token: 0x040117D6 RID: 71638
		internal static int __PropertyOffset_31;

		// Token: 0x040117D7 RID: 71639
		internal static int __PropertyOffset_32;

		// Token: 0x040117D8 RID: 71640
		internal static int __PropertyOffset_33;

		// Token: 0x040117D9 RID: 71641
		internal static int __PropertyOffset_34;

		// Token: 0x040117DA RID: 71642
		internal static int __PropertyOffset_35;

		// Token: 0x040117DB RID: 71643
		internal static int __PropertyOffset_36;

		// Token: 0x040117DC RID: 71644
		internal static int __PropertyOffset_37;

		// Token: 0x040117DD RID: 71645
		internal static int __PropertyOffset_38;

		// Token: 0x040117DE RID: 71646
		internal static int __PropertyOffset_39;

		// Token: 0x040117DF RID: 71647
		internal static int __PropertyOffset_40;

		// Token: 0x040117E0 RID: 71648
		private static IntPtr __InitCloud_NativeFunctionPtr;

		// Token: 0x040117E1 RID: 71649
		private static IntPtr __DistanceFromBox_NativeFunctionPtr;

		// Token: 0x040117E2 RID: 71650
		private static IntPtr __ShowCloud_NativeFunctionPtr;

		// Token: 0x040117E3 RID: 71651
		private static IntPtr __Update_Cloud_Fade_NativeFunctionPtr;

		// Token: 0x040117E4 RID: 71652
		private static IntPtr __GetLerpGIData_NativeFunctionPtr;

		// Token: 0x040117E5 RID: 71653
		private static IntPtr __UpdateCloudLighting_NativeFunctionPtr;

		// Token: 0x040117E6 RID: 71654
		private static IntPtr __UpdateCloudTransform_NativeFunctionPtr;

		// Token: 0x040117E7 RID: 71655
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040117E8 RID: 71656
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040117E9 RID: 71657
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040117EA RID: 71658
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040117EB RID: 71659
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x040117EC RID: 71660
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040117ED RID: 71661
		private static IntPtr __ExecuteUbergraph_BP_KuroTraceCloud_NativeFunctionPtr;

		// Token: 0x02009BE9 RID: 39913
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __InitCloud_FunctionParams
		{
			// Token: 0x0403243F RID: 205887
			[FieldOffset(0)]
			public IntPtr Material;
		}

		// Token: 0x02009BEA RID: 39914
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 92)]
		protected ref struct __DistanceFromBox_FunctionParams
		{
			// Token: 0x04032440 RID: 205888
			[FieldOffset(0)]
			public FVector P;

			// Token: 0x04032441 RID: 205889
			[FieldOffset(12)]
			public FVector Box;

			// Token: 0x04032442 RID: 205890
			[FieldOffset(24)]
			public float dist;
		}

		// Token: 0x02009BEB RID: 39915
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ShowCloud_FunctionParams
		{
			// Token: 0x04032443 RID: 205891
			[FieldOffset(0)]
			public bool bNewVisibility;
		}

		// Token: 0x02009BEC RID: 39916
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __GetLerpGIData_FunctionParams
		{
			// Token: 0x04032444 RID: 205892
			[FieldOffset(0)]
			public float Time;

			// Token: 0x04032445 RID: 205893
			[FieldOffset(4)]
			public byte LerpData;
		}

		// Token: 0x02009BED RID: 39917
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __UpdateCloudLighting_FunctionParams
		{
			// Token: 0x04032446 RID: 205894
			[FieldOffset(0)]
			public IntPtr Material;
		}

		// Token: 0x02009BEE RID: 39918
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 416)]
		protected ref struct __UpdateCloudTransform_FunctionParams
		{
			// Token: 0x04032447 RID: 205895
			[FieldOffset(0)]
			public IntPtr CloudCube;
		}

		// Token: 0x02009BEF RID: 39919
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032448 RID: 205896
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BF0 RID: 39920
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032449 RID: 205897
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009BF1 RID: 39921
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 560)]
		protected ref struct __ExecuteUbergraph_BP_KuroTraceCloud_FunctionParams
		{
			// Token: 0x0403244A RID: 205898
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
