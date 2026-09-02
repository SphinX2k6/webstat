using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroRayMarchingCloud.PostVolumeGlobal
{
	// Token: 0x02003BEB RID: 15339
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/BP_KuroVolumeCloud_Global.BP_KuroVolumeCloud_Global_C")]
	[UnrealStructLayout(1880, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1876)]
	public class BP_KuroVolumeCloud_Global_C : AKuroBPCustomCookActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060228BB RID: 141499 RVA: 0x00968463 File Offset: 0x00966663
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroVolumeCloud_Global_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/BP_KuroVolumeCloud_Global.BP_KuroVolumeCloud_Global_C");
			}
			return BP_KuroVolumeCloud_Global_C._ClassPtr;
		}

		// Token: 0x060228BC RID: 141500 RVA: 0x00968488 File Offset: 0x00966688
		public BP_KuroVolumeCloud_Global_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeCloud_Global_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060228BD RID: 141501 RVA: 0x009684B0 File Offset: 0x009666B0
		[NullableContext(1)]
		public BP_KuroVolumeCloud_Global_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroVolumeCloud_Global_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700416A RID: 16746
		// (get) Token: 0x060228BE RID: 141502 RVA: 0x009684E4 File Offset: 0x009666E4
		// (set) Token: 0x060228BF RID: 141503 RVA: 0x0096851D File Offset: 0x0096671D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700416B RID: 16747
		// (get) Token: 0x060228C0 RID: 141504 RVA: 0x0096853E File Offset: 0x0096673E
		// (set) Token: 0x060228C1 RID: 141505 RVA: 0x00968552 File Offset: 0x00966752
		public unsafe UStaticMeshComponent Cube
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700416C RID: 16748
		// (get) Token: 0x060228C2 RID: 141506 RVA: 0x00968567 File Offset: 0x00966767
		// (set) Token: 0x060228C3 RID: 141507 RVA: 0x0096857B File Offset: 0x0096677B
		public unsafe USceneComponent CloudRange
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700416D RID: 16749
		// (get) Token: 0x060228C4 RID: 141508 RVA: 0x00968590 File Offset: 0x00966790
		// (set) Token: 0x060228C5 RID: 141509 RVA: 0x009685A4 File Offset: 0x009667A4
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700416E RID: 16750
		// (get) Token: 0x060228C6 RID: 141510 RVA: 0x009685BC File Offset: 0x009667BC
		// (set) Token: 0x060228C7 RID: 141511 RVA: 0x009685F5 File Offset: 0x009667F5
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
					result = (this._Data = new TArray<SD_KuroTraceCloudData>(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x1700416F RID: 16751
		// (get) Token: 0x060228C8 RID: 141512 RVA: 0x00968604 File Offset: 0x00966804
		// (set) Token: 0x060228C9 RID: 141513 RVA: 0x0096863D File Offset: 0x0096683D
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
					result = (this._LerpData = new SD_KuroTraceCloudData(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SD_KuroTraceCloudData.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004170 RID: 16752
		// (get) Token: 0x060228CA RID: 141514 RVA: 0x0096865E File Offset: 0x0096685E
		// (set) Token: 0x060228CB RID: 141515 RVA: 0x0096866E File Offset: 0x0096686E
		public unsafe bool bEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004171 RID: 16753
		// (get) Token: 0x060228CC RID: 141516 RVA: 0x0096867F File Offset: 0x0096687F
		// (set) Token: 0x060228CD RID: 141517 RVA: 0x0096868F File Offset: 0x0096688F
		public unsafe bool bUpdateTransformAlways
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004172 RID: 16754
		// (get) Token: 0x060228CE RID: 141518 RVA: 0x009686A0 File Offset: 0x009668A0
		// (set) Token: 0x060228CF RID: 141519 RVA: 0x009686B0 File Offset: 0x009668B0
		public unsafe bool bDirty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004173 RID: 16755
		// (get) Token: 0x060228D0 RID: 141520 RVA: 0x009686C1 File Offset: 0x009668C1
		// (set) Token: 0x060228D1 RID: 141521 RVA: 0x009686D5 File Offset: 0x009668D5
		public unsafe FLinearColor BakeFlowSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004174 RID: 16756
		// (get) Token: 0x060228D2 RID: 141522 RVA: 0x009686EA File Offset: 0x009668EA
		// (set) Token: 0x060228D3 RID: 141523 RVA: 0x009686FE File Offset: 0x009668FE
		public unsafe UMaterialInterface LastMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004175 RID: 16757
		// (get) Token: 0x060228D4 RID: 141524 RVA: 0x00968713 File Offset: 0x00966913
		// (set) Token: 0x060228D5 RID: 141525 RVA: 0x00968727 File Offset: 0x00966927
		public unsafe FVectorDouble LastPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004176 RID: 16758
		// (get) Token: 0x060228D6 RID: 141526 RVA: 0x0096873C File Offset: 0x0096693C
		// (set) Token: 0x060228D7 RID: 141527 RVA: 0x00968750 File Offset: 0x00966950
		public unsafe FVectorDouble LastScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004177 RID: 16759
		// (get) Token: 0x060228D8 RID: 141528 RVA: 0x00968765 File Offset: 0x00966965
		// (set) Token: 0x060228D9 RID: 141529 RVA: 0x00968775 File Offset: 0x00966975
		public unsafe bool bLocal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004178 RID: 16760
		// (get) Token: 0x060228DA RID: 141530 RVA: 0x00968786 File Offset: 0x00966986
		// (set) Token: 0x060228DB RID: 141531 RVA: 0x0096879A File Offset: 0x0096699A
		public unsafe FLinearColor CloudSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004179 RID: 16761
		// (get) Token: 0x060228DC RID: 141532 RVA: 0x009687AF File Offset: 0x009669AF
		// (set) Token: 0x060228DD RID: 141533 RVA: 0x009687C3 File Offset: 0x009669C3
		public unsafe FLinearColor LocalSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700417A RID: 16762
		// (get) Token: 0x060228DE RID: 141534 RVA: 0x009687D8 File Offset: 0x009669D8
		// (set) Token: 0x060228DF RID: 141535 RVA: 0x009687E8 File Offset: 0x009669E8
		public unsafe int FadeGroup_0_2_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700417B RID: 16763
		// (get) Token: 0x060228E0 RID: 141536 RVA: 0x009687F9 File Offset: 0x009669F9
		// (set) Token: 0x060228E1 RID: 141537 RVA: 0x00968809 File Offset: 0x00966A09
		public unsafe float LocalOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700417C RID: 16764
		// (get) Token: 0x060228E2 RID: 141538 RVA: 0x0096881A File Offset: 0x00966A1A
		// (set) Token: 0x060228E3 RID: 141539 RVA: 0x0096882E File Offset: 0x00966A2E
		public unsafe FLinearColor ThunderColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700417D RID: 16765
		// (get) Token: 0x060228E4 RID: 141540 RVA: 0x00968843 File Offset: 0x00966A43
		// (set) Token: 0x060228E5 RID: 141541 RVA: 0x00968853 File Offset: 0x00966A53
		public unsafe float ThunderSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700417E RID: 16766
		// (get) Token: 0x060228E6 RID: 141542 RVA: 0x00968864 File Offset: 0x00966A64
		// (set) Token: 0x060228E7 RID: 141543 RVA: 0x00968874 File Offset: 0x00966A74
		public unsafe float ThunderTimeCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700417F RID: 16767
		// (get) Token: 0x060228E8 RID: 141544 RVA: 0x00968885 File Offset: 0x00966A85
		// (set) Token: 0x060228E9 RID: 141545 RVA: 0x00968899 File Offset: 0x00966A99
		public unsafe UCurveFloat ThunderCurve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_21);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_21, value);
			}
		}

		// Token: 0x17004180 RID: 16768
		// (get) Token: 0x060228EA RID: 141546 RVA: 0x009688AE File Offset: 0x00966AAE
		// (set) Token: 0x060228EB RID: 141547 RVA: 0x009688C2 File Offset: 0x00966AC2
		public unsafe UCurveFloat ThunderCurve2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004181 RID: 16769
		// (get) Token: 0x060228EC RID: 141548 RVA: 0x009688D7 File Offset: 0x00966AD7
		// (set) Token: 0x060228ED RID: 141549 RVA: 0x009688EB File Offset: 0x00966AEB
		public unsafe UCurveFloat ThunderCurve3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_23);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_23, value);
			}
		}

		// Token: 0x17004182 RID: 16770
		// (get) Token: 0x060228EE RID: 141550 RVA: 0x00968900 File Offset: 0x00966B00
		// (set) Token: 0x060228EF RID: 141551 RVA: 0x00968939 File Offset: 0x00966B39
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_24, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004183 RID: 16771
		// (get) Token: 0x060228F0 RID: 141552 RVA: 0x00968948 File Offset: 0x00966B48
		// (set) Token: 0x060228F1 RID: 141553 RVA: 0x00968981 File Offset: 0x00966B81
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_25, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004184 RID: 16772
		// (get) Token: 0x060228F2 RID: 141554 RVA: 0x00968990 File Offset: 0x00966B90
		// (set) Token: 0x060228F3 RID: 141555 RVA: 0x009689C9 File Offset: 0x00966BC9
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_26, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004185 RID: 16773
		// (get) Token: 0x060228F4 RID: 141556 RVA: 0x009689D7 File Offset: 0x00966BD7
		// (set) Token: 0x060228F5 RID: 141557 RVA: 0x009689E7 File Offset: 0x00966BE7
		public unsafe bool bUseGlobalSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004186 RID: 16774
		// (get) Token: 0x060228F6 RID: 141558 RVA: 0x009689F8 File Offset: 0x00966BF8
		// (set) Token: 0x060228F7 RID: 141559 RVA: 0x00968A08 File Offset: 0x00966C08
		public unsafe bool bEnableDistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004187 RID: 16775
		// (get) Token: 0x060228F8 RID: 141560 RVA: 0x00968A19 File Offset: 0x00966C19
		// (set) Token: 0x060228F9 RID: 141561 RVA: 0x00968A29 File Offset: 0x00966C29
		public unsafe double DistanceFadeWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004188 RID: 16776
		// (get) Token: 0x060228FA RID: 141562 RVA: 0x00968A3A File Offset: 0x00966C3A
		// (set) Token: 0x060228FB RID: 141563 RVA: 0x00968A4A File Offset: 0x00966C4A
		public unsafe double DistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004189 RID: 16777
		// (get) Token: 0x060228FC RID: 141564 RVA: 0x00968A5B File Offset: 0x00966C5B
		// (set) Token: 0x060228FD RID: 141565 RVA: 0x00968A6B File Offset: 0x00966C6B
		public unsafe int NowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700418A RID: 16778
		// (get) Token: 0x060228FE RID: 141566 RVA: 0x00968A7C File Offset: 0x00966C7C
		// (set) Token: 0x060228FF RID: 141567 RVA: 0x00968A90 File Offset: 0x00966C90
		public unsafe AStaticMeshActor LowQualityMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_32);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x1700418B RID: 16779
		// (get) Token: 0x06022900 RID: 141568 RVA: 0x00968AA5 File Offset: 0x00966CA5
		// (set) Token: 0x06022901 RID: 141569 RVA: 0x00968AB5 File Offset: 0x00966CB5
		public unsafe float CacheLocalOpacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700418C RID: 16780
		// (get) Token: 0x06022902 RID: 141570 RVA: 0x00968AC6 File Offset: 0x00966CC6
		// (set) Token: 0x06022903 RID: 141571 RVA: 0x00968AD6 File Offset: 0x00966CD6
		public unsafe bool LastNotAffectedByVRS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700418D RID: 16781
		// (get) Token: 0x06022904 RID: 141572 RVA: 0x00968AE7 File Offset: 0x00966CE7
		// (set) Token: 0x06022905 RID: 141573 RVA: 0x00968AF7 File Offset: 0x00966CF7
		public unsafe int LastQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x1700418E RID: 16782
		// (get) Token: 0x06022906 RID: 141574 RVA: 0x00968B08 File Offset: 0x00966D08
		// (set) Token: 0x06022907 RID: 141575 RVA: 0x00968B1C File Offset: 0x00966D1C
		public unsafe UMaterialParameterCollection MPC_GlobalShader
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_36);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroVolumeCloud_Global_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x1700418F RID: 16783
		// (get) Token: 0x06022908 RID: 141576 RVA: 0x00968B31 File Offset: 0x00966D31
		// (set) Token: 0x06022909 RID: 141577 RVA: 0x00968B41 File Offset: 0x00966D41
		public unsafe float VolumeCloudSpeedMulti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17004190 RID: 16784
		// (get) Token: 0x0602290A RID: 141578 RVA: 0x00968B52 File Offset: 0x00966D52
		// (set) Token: 0x0602290B RID: 141579 RVA: 0x00968B62 File Offset: 0x00966D62
		public unsafe bool bShouldTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004191 RID: 16785
		// (get) Token: 0x0602290C RID: 141580 RVA: 0x00968B73 File Offset: 0x00966D73
		// (set) Token: 0x0602290D RID: 141581 RVA: 0x00968B83 File Offset: 0x00966D83
		public unsafe bool bLocalOnlyForVRS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004192 RID: 16786
		// (get) Token: 0x0602290E RID: 141582 RVA: 0x00968B94 File Offset: 0x00966D94
		// (set) Token: 0x0602290F RID: 141583 RVA: 0x00968BA4 File Offset: 0x00966DA4
		public unsafe bool bVolumeCloudNotAffectedByVRS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004193 RID: 16787
		// (get) Token: 0x06022910 RID: 141584 RVA: 0x00968BB5 File Offset: 0x00966DB5
		// (set) Token: 0x06022911 RID: 141585 RVA: 0x00968BC5 File Offset: 0x00966DC5
		public unsafe bool bMac
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004194 RID: 16788
		// (get) Token: 0x06022912 RID: 141586 RVA: 0x00968BD6 File Offset: 0x00966DD6
		// (set) Token: 0x06022913 RID: 141587 RVA: 0x00968BEA File Offset: 0x00966DEA
		public unsafe FName FadeGroupName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17004195 RID: 16789
		// (get) Token: 0x06022914 RID: 141588 RVA: 0x00968BFF File Offset: 0x00966DFF
		// (set) Token: 0x06022915 RID: 141589 RVA: 0x00968C0F File Offset: 0x00966E0F
		public unsafe bool vrsNotChanged
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004196 RID: 16790
		// (get) Token: 0x06022916 RID: 141590 RVA: 0x00968C20 File Offset: 0x00966E20
		// (set) Token: 0x06022917 RID: 141591 RVA: 0x00968C30 File Offset: 0x00966E30
		public unsafe int VRSQualityOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroVolumeCloud_Global_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x06022918 RID: 141592 RVA: 0x00968C41 File Offset: 0x00966E41
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudShadingRateLocal()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UpdateCloudShadingRateLocal_NativeFunctionPtr, null);
		}

		// Token: 0x06022919 RID: 141593 RVA: 0x00968C55 File Offset: 0x00966E55
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudShadingRate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UpdateCloudShadingRate_NativeFunctionPtr, null);
		}

		// Token: 0x0602291A RID: 141594 RVA: 0x00968C69 File Offset: 0x00966E69
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CleanMID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__CleanMID_NativeFunctionPtr, null);
		}

		// Token: 0x0602291B RID: 141595 RVA: 0x00968C7D File Offset: 0x00966E7D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CheckNeed_Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__CheckNeed_Update_NativeFunctionPtr, null);
		}

		// Token: 0x0602291C RID: 141596 RVA: 0x00968C91 File Offset: 0x00966E91
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__Update_NativeFunctionPtr, null);
		}

		// Token: 0x0602291D RID: 141597 RVA: 0x00968CA8 File Offset: 0x00966EA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetLerpGIData(float Time, ref SD_KuroTraceCloudData LerpData)
		{
			BP_KuroVolumeCloud_Global_C.__GetLerpGIData_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Global_C.__GetLerpGIData_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_KuroVolumeCloud_Global_C.__GetLerpGIData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Global_C.__GetLerpGIData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Time = Time;
			if (LerpData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SD_KuroTraceCloudData.StaticStruct(), &ptr->LerpData, LerpData.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__GetLerpGIData_NativeFunctionPtr, (void*)ptr);
			if (LerpData != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SD_KuroTraceCloudData.StaticStruct(), LerpData.NativePtr, &ptr->LerpData, 1, false);
			}
		}

		// Token: 0x0602291E RID: 141598 RVA: 0x00968D39 File Offset: 0x00966F39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudLighting()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UpdateCloudLighting_NativeFunctionPtr, null);
		}

		// Token: 0x0602291F RID: 141599 RVA: 0x00968D4D File Offset: 0x00966F4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudTransform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UpdateCloudTransform_NativeFunctionPtr, null);
		}

		// Token: 0x06022920 RID: 141600 RVA: 0x00968D61 File Offset: 0x00966F61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022921 RID: 141601 RVA: 0x00968D75 File Offset: 0x00966F75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022922 RID: 141602 RVA: 0x00968D8A File Offset: 0x00966F8A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022923 RID: 141603 RVA: 0x00968D9E File Offset: 0x00966F9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022924 RID: 141604 RVA: 0x00968DB4 File Offset: 0x00966FB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroVolumeCloud_Global_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Global_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeCloud_Global_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Global_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022925 RID: 141605 RVA: 0x00968DFC File Offset: 0x00966FFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroVolumeCloud_Global_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Global_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroVolumeCloud_Global_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Global_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022926 RID: 141606 RVA: 0x00968E43 File Offset: 0x00967043
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x06022927 RID: 141607 RVA: 0x00968E57 File Offset: 0x00967057
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForMobile()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__BeforeCookForMobile_NativeFunctionPtr, null);
		}

		// Token: 0x06022928 RID: 141608 RVA: 0x00968E6B File Offset: 0x0096706B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForMobile_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__BeforeCookForMobile_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022929 RID: 141609 RVA: 0x00968E80 File Offset: 0x00967080
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeCookForPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__BeforeCookForPC_NativeFunctionPtr, null);
		}

		// Token: 0x0602292A RID: 141610 RVA: 0x00968E94 File Offset: 0x00967094
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void BeforeCookForPC_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__BeforeCookForPC_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602292B RID: 141611 RVA: 0x00968EA9 File Offset: 0x009670A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BeforeSave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__BeforeSave_NativeFunctionPtr, null);
		}

		// Token: 0x0602292C RID: 141612 RVA: 0x00968EBD File Offset: 0x009670BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BeforeSave_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__BeforeSave_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602292D RID: 141613 RVA: 0x00968ED2 File Offset: 0x009670D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x0602292E RID: 141614 RVA: 0x00968EE8 File Offset: 0x009670E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602292F RID: 141615 RVA: 0x00968F34 File Offset: 0x00967134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022930 RID: 141616 RVA: 0x00968F80 File Offset: 0x00967180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroVolumeCloud_Global(int EntryPoint)
		{
			BP_KuroVolumeCloud_Global_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Global_FunctionParams* ptr = stackalloc BP_KuroVolumeCloud_Global_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Global_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_KuroVolumeCloud_Global_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Global_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroVolumeCloud_Global_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Global_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroVolumeCloud_Global_C.__ExecuteUbergraph_BP_KuroVolumeCloud_Global_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022931 RID: 141617 RVA: 0x00968FCA File Offset: 0x009671CA
		protected BP_KuroVolumeCloud_Global_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040117F2 RID: 71666
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroRayMarchingCloud/PostVolumeGlobal/BP_KuroVolumeCloud_Global.BP_KuroVolumeCloud_Global_C";

		// Token: 0x040117F3 RID: 71667
		private static IntPtr _ClassPtr;

		// Token: 0x040117F4 RID: 71668
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040117F5 RID: 71669
		internal static int __PropertyOffset_0;

		// Token: 0x040117F6 RID: 71670
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040117F7 RID: 71671
		internal static int __PropertyOffset_1;

		// Token: 0x040117F8 RID: 71672
		internal static int __PropertyOffset_2;

		// Token: 0x040117F9 RID: 71673
		internal static int __PropertyOffset_3;

		// Token: 0x040117FA RID: 71674
		internal static int __PropertyOffset_4;

		// Token: 0x040117FB RID: 71675
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SD_KuroTraceCloudData> _Data;

		// Token: 0x040117FC RID: 71676
		internal static int __PropertyOffset_5;

		// Token: 0x040117FD RID: 71677
		private SD_KuroTraceCloudData _LerpData;

		// Token: 0x040117FE RID: 71678
		internal static int __PropertyOffset_6;

		// Token: 0x040117FF RID: 71679
		internal static int __PropertyOffset_7;

		// Token: 0x04011800 RID: 71680
		internal static int __PropertyOffset_8;

		// Token: 0x04011801 RID: 71681
		internal static int __PropertyOffset_9;

		// Token: 0x04011802 RID: 71682
		internal static int __PropertyOffset_10;

		// Token: 0x04011803 RID: 71683
		internal static int __PropertyOffset_11;

		// Token: 0x04011804 RID: 71684
		internal static int __PropertyOffset_12;

		// Token: 0x04011805 RID: 71685
		internal static int __PropertyOffset_13;

		// Token: 0x04011806 RID: 71686
		internal static int __PropertyOffset_14;

		// Token: 0x04011807 RID: 71687
		internal static int __PropertyOffset_15;

		// Token: 0x04011808 RID: 71688
		internal static int __PropertyOffset_16;

		// Token: 0x04011809 RID: 71689
		internal static int __PropertyOffset_17;

		// Token: 0x0401180A RID: 71690
		internal static int __PropertyOffset_18;

		// Token: 0x0401180B RID: 71691
		internal static int __PropertyOffset_19;

		// Token: 0x0401180C RID: 71692
		internal static int __PropertyOffset_20;

		// Token: 0x0401180D RID: 71693
		internal static int __PropertyOffset_21;

		// Token: 0x0401180E RID: 71694
		internal static int __PropertyOffset_22;

		// Token: 0x0401180F RID: 71695
		internal static int __PropertyOffset_23;

		// Token: 0x04011810 RID: 71696
		internal static int __PropertyOffset_24;

		// Token: 0x04011811 RID: 71697
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04011812 RID: 71698
		internal static int __PropertyOffset_25;

		// Token: 0x04011813 RID: 71699
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04011814 RID: 71700
		internal static int __PropertyOffset_26;

		// Token: 0x04011815 RID: 71701
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x04011816 RID: 71702
		internal static int __PropertyOffset_27;

		// Token: 0x04011817 RID: 71703
		internal static int __PropertyOffset_28;

		// Token: 0x04011818 RID: 71704
		internal static int __PropertyOffset_29;

		// Token: 0x04011819 RID: 71705
		internal static int __PropertyOffset_30;

		// Token: 0x0401181A RID: 71706
		internal static int __PropertyOffset_31;

		// Token: 0x0401181B RID: 71707
		internal static int __PropertyOffset_32;

		// Token: 0x0401181C RID: 71708
		internal static int __PropertyOffset_33;

		// Token: 0x0401181D RID: 71709
		internal static int __PropertyOffset_34;

		// Token: 0x0401181E RID: 71710
		internal static int __PropertyOffset_35;

		// Token: 0x0401181F RID: 71711
		internal static int __PropertyOffset_36;

		// Token: 0x04011820 RID: 71712
		internal static int __PropertyOffset_37;

		// Token: 0x04011821 RID: 71713
		internal static int __PropertyOffset_38;

		// Token: 0x04011822 RID: 71714
		internal static int __PropertyOffset_39;

		// Token: 0x04011823 RID: 71715
		internal static int __PropertyOffset_40;

		// Token: 0x04011824 RID: 71716
		internal static int __PropertyOffset_41;

		// Token: 0x04011825 RID: 71717
		internal static int __PropertyOffset_42;

		// Token: 0x04011826 RID: 71718
		internal static int __PropertyOffset_43;

		// Token: 0x04011827 RID: 71719
		internal static int __PropertyOffset_44;

		// Token: 0x04011828 RID: 71720
		private static IntPtr __UpdateCloudShadingRateLocal_NativeFunctionPtr;

		// Token: 0x04011829 RID: 71721
		private static IntPtr __UpdateCloudShadingRate_NativeFunctionPtr;

		// Token: 0x0401182A RID: 71722
		private static IntPtr __CleanMID_NativeFunctionPtr;

		// Token: 0x0401182B RID: 71723
		private static IntPtr __CheckNeed_Update_NativeFunctionPtr;

		// Token: 0x0401182C RID: 71724
		private static IntPtr __Update_NativeFunctionPtr;

		// Token: 0x0401182D RID: 71725
		private static IntPtr __GetLerpGIData_NativeFunctionPtr;

		// Token: 0x0401182E RID: 71726
		private static IntPtr __UpdateCloudLighting_NativeFunctionPtr;

		// Token: 0x0401182F RID: 71727
		private static IntPtr __UpdateCloudTransform_NativeFunctionPtr;

		// Token: 0x04011830 RID: 71728
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011831 RID: 71729
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011832 RID: 71730
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011833 RID: 71731
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011834 RID: 71732
		private static IntPtr __BeforeCookForMobile_NativeFunctionPtr;

		// Token: 0x04011835 RID: 71733
		private static IntPtr __BeforeCookForPC_NativeFunctionPtr;

		// Token: 0x04011836 RID: 71734
		private static IntPtr __BeforeSave_NativeFunctionPtr;

		// Token: 0x04011837 RID: 71735
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x04011838 RID: 71736
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011839 RID: 71737
		private static IntPtr __ExecuteUbergraph_BP_KuroVolumeCloud_Global_NativeFunctionPtr;

		// Token: 0x02009BF2 RID: 39922
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __GetLerpGIData_FunctionParams
		{
			// Token: 0x0403244B RID: 205899
			[FieldOffset(0)]
			public float Time;

			// Token: 0x0403244C RID: 205900
			[FieldOffset(4)]
			public byte LerpData;
		}

		// Token: 0x02009BF3 RID: 39923
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403244D RID: 205901
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BF4 RID: 39924
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403244E RID: 205902
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009BF5 RID: 39925
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __ExecuteUbergraph_BP_KuroVolumeCloud_Global_FunctionParams
		{
			// Token: 0x0403244F RID: 205903
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
