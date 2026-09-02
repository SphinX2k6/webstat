using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.CarPaint.BluePrints
{
	// Token: 0x02003C38 RID: 15416
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BP_CarOpenDoor.BP_CarOpenDoor_C")]
	[UnrealStructLayout(1792, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1784)]
	public class BP_CarOpenDoor_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060235C5 RID: 144837 RVA: 0x0097FE02 File Offset: 0x0097E002
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CarOpenDoor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BP_CarOpenDoor.BP_CarOpenDoor_C");
			}
			return BP_CarOpenDoor_C._ClassPtr;
		}

		// Token: 0x060235C6 RID: 144838 RVA: 0x0097FE28 File Offset: 0x0097E028
		public BP_CarOpenDoor_C() : this(BuiltinUtils.AllocNativeUObject(BP_CarOpenDoor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060235C7 RID: 144839 RVA: 0x0097FE50 File Offset: 0x0097E050
		[NullableContext(1)]
		public BP_CarOpenDoor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CarOpenDoor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045FA RID: 17914
		// (get) Token: 0x060235C8 RID: 144840 RVA: 0x0097FE84 File Offset: 0x0097E084
		// (set) Token: 0x060235C9 RID: 144841 RVA: 0x0097FEBD File Offset: 0x0097E0BD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170045FB RID: 17915
		// (get) Token: 0x060235CA RID: 144842 RVA: 0x0097FEDE File Offset: 0x0097E0DE
		// (set) Token: 0x060235CB RID: 144843 RVA: 0x0097FEF2 File Offset: 0x0097E0F2
		public unsafe UBoxComponent BoxTrigger
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045FC RID: 17916
		// (get) Token: 0x060235CC RID: 144844 RVA: 0x0097FF07 File Offset: 0x0097E107
		// (set) Token: 0x060235CD RID: 144845 RVA: 0x0097FF1B File Offset: 0x0097E11B
		public unsafe UStaticMeshComponent SM_Cyb_Car_01GM1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045FD RID: 17917
		// (get) Token: 0x060235CE RID: 144846 RVA: 0x0097FF30 File Offset: 0x0097E130
		// (set) Token: 0x060235CF RID: 144847 RVA: 0x0097FF44 File Offset: 0x0097E144
		public unsafe UStaticMeshComponent SM_Cyb_Car_01GM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170045FE RID: 17918
		// (get) Token: 0x060235D0 RID: 144848 RVA: 0x0097FF59 File Offset: 0x0097E159
		// (set) Token: 0x060235D1 RID: 144849 RVA: 0x0097FF6D File Offset: 0x0097E16D
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170045FF RID: 17919
		// (get) Token: 0x060235D2 RID: 144850 RVA: 0x0097FF82 File Offset: 0x0097E182
		// (set) Token: 0x060235D3 RID: 144851 RVA: 0x0097FF92 File Offset: 0x0097E192
		public unsafe float Timeline_7_NewTrack_0_F4056B3E4301EE392C91AFB153752861
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004600 RID: 17920
		// (get) Token: 0x060235D4 RID: 144852 RVA: 0x0097FFA3 File Offset: 0x0097E1A3
		// (set) Token: 0x060235D5 RID: 144853 RVA: 0x0097FFB7 File Offset: 0x0097E1B7
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_7__Direction_F4056B3E4301EE392C91AFB153752861
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17004601 RID: 17921
		// (get) Token: 0x060235D6 RID: 144854 RVA: 0x0097FFCC File Offset: 0x0097E1CC
		// (set) Token: 0x060235D7 RID: 144855 RVA: 0x0097FFE0 File Offset: 0x0097E1E0
		public unsafe UTimelineComponent Timeline_7
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004602 RID: 17922
		// (get) Token: 0x060235D8 RID: 144856 RVA: 0x0097FFF5 File Offset: 0x0097E1F5
		// (set) Token: 0x060235D9 RID: 144857 RVA: 0x00980005 File Offset: 0x0097E205
		public unsafe float Timeline_6_NewTrack_0_A57150204F6656C36D403FAB7B19B78D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004603 RID: 17923
		// (get) Token: 0x060235DA RID: 144858 RVA: 0x00980016 File Offset: 0x0097E216
		// (set) Token: 0x060235DB RID: 144859 RVA: 0x0098002A File Offset: 0x0097E22A
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_6__Direction_A57150204F6656C36D403FAB7B19B78D
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004604 RID: 17924
		// (get) Token: 0x060235DC RID: 144860 RVA: 0x0098003F File Offset: 0x0097E23F
		// (set) Token: 0x060235DD RID: 144861 RVA: 0x00980053 File Offset: 0x0097E253
		public unsafe UTimelineComponent Timeline_6
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17004605 RID: 17925
		// (get) Token: 0x060235DE RID: 144862 RVA: 0x00980068 File Offset: 0x0097E268
		// (set) Token: 0x060235DF RID: 144863 RVA: 0x00980078 File Offset: 0x0097E278
		public unsafe float Timeline_3_NewTrack_0_BB403BFA400E5ED28E1FA39630A859EC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004606 RID: 17926
		// (get) Token: 0x060235E0 RID: 144864 RVA: 0x00980089 File Offset: 0x0097E289
		// (set) Token: 0x060235E1 RID: 144865 RVA: 0x0098009D File Offset: 0x0097E29D
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_3__Direction_BB403BFA400E5ED28E1FA39630A859EC
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_12);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004607 RID: 17927
		// (get) Token: 0x060235E2 RID: 144866 RVA: 0x009800B2 File Offset: 0x0097E2B2
		// (set) Token: 0x060235E3 RID: 144867 RVA: 0x009800C6 File Offset: 0x0097E2C6
		public unsafe UTimelineComponent Timeline_3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004608 RID: 17928
		// (get) Token: 0x060235E4 RID: 144868 RVA: 0x009800DB File Offset: 0x0097E2DB
		// (set) Token: 0x060235E5 RID: 144869 RVA: 0x009800EB File Offset: 0x0097E2EB
		public unsafe float Timeline_2_NewTrack_0_D264918943903987D00F289189FE3468
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004609 RID: 17929
		// (get) Token: 0x060235E6 RID: 144870 RVA: 0x009800FC File Offset: 0x0097E2FC
		// (set) Token: 0x060235E7 RID: 144871 RVA: 0x00980110 File Offset: 0x0097E310
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_2__Direction_D264918943903987D00F289189FE3468
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x1700460A RID: 17930
		// (get) Token: 0x060235E8 RID: 144872 RVA: 0x00980125 File Offset: 0x0097E325
		// (set) Token: 0x060235E9 RID: 144873 RVA: 0x00980139 File Offset: 0x0097E339
		public unsafe UTimelineComponent Timeline_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700460B RID: 17931
		// (get) Token: 0x060235EA RID: 144874 RVA: 0x0098014E File Offset: 0x0097E34E
		// (set) Token: 0x060235EB RID: 144875 RVA: 0x0098015E File Offset: 0x0097E35E
		public unsafe float Timeline_5_NewTrack_0_9976DCE14A7B78504561969515E1A371
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700460C RID: 17932
		// (get) Token: 0x060235EC RID: 144876 RVA: 0x0098016F File Offset: 0x0097E36F
		// (set) Token: 0x060235ED RID: 144877 RVA: 0x00980183 File Offset: 0x0097E383
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_5__Direction_9976DCE14A7B78504561969515E1A371
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_18);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700460D RID: 17933
		// (get) Token: 0x060235EE RID: 144878 RVA: 0x00980198 File Offset: 0x0097E398
		// (set) Token: 0x060235EF RID: 144879 RVA: 0x009801AC File Offset: 0x0097E3AC
		public unsafe UTimelineComponent Timeline_5
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700460E RID: 17934
		// (get) Token: 0x060235F0 RID: 144880 RVA: 0x009801C1 File Offset: 0x0097E3C1
		// (set) Token: 0x060235F1 RID: 144881 RVA: 0x009801D1 File Offset: 0x0097E3D1
		public unsafe float Timeline_1_NewTrack_0_284631E04DD31FBE074F85B56DA633C5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700460F RID: 17935
		// (get) Token: 0x060235F2 RID: 144882 RVA: 0x009801E2 File Offset: 0x0097E3E2
		// (set) Token: 0x060235F3 RID: 144883 RVA: 0x009801F6 File Offset: 0x0097E3F6
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_1__Direction_284631E04DD31FBE074F85B56DA633C5
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_21);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17004610 RID: 17936
		// (get) Token: 0x060235F4 RID: 144884 RVA: 0x0098020B File Offset: 0x0097E40B
		// (set) Token: 0x060235F5 RID: 144885 RVA: 0x0098021F File Offset: 0x0097E41F
		public unsafe UTimelineComponent Timeline_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x17004611 RID: 17937
		// (get) Token: 0x060235F6 RID: 144886 RVA: 0x00980234 File Offset: 0x0097E434
		// (set) Token: 0x060235F7 RID: 144887 RVA: 0x00980244 File Offset: 0x0097E444
		public unsafe float Timeline_4_NewTrack_0_8AB12E704B35847EE58200AEC43A5F02
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004612 RID: 17938
		// (get) Token: 0x060235F8 RID: 144888 RVA: 0x00980255 File Offset: 0x0097E455
		// (set) Token: 0x060235F9 RID: 144889 RVA: 0x00980269 File Offset: 0x0097E469
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_4__Direction_8AB12E704B35847EE58200AEC43A5F02
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_24);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004613 RID: 17939
		// (get) Token: 0x060235FA RID: 144890 RVA: 0x0098027E File Offset: 0x0097E47E
		// (set) Token: 0x060235FB RID: 144891 RVA: 0x00980292 File Offset: 0x0097E492
		public unsafe UTimelineComponent Timeline_4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_25);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_25, value);
			}
		}

		// Token: 0x17004614 RID: 17940
		// (get) Token: 0x060235FC RID: 144892 RVA: 0x009802A7 File Offset: 0x0097E4A7
		// (set) Token: 0x060235FD RID: 144893 RVA: 0x009802B7 File Offset: 0x0097E4B7
		public unsafe float Timeline_0_NewTrack_0_A3641E244AB652293D0D3A8D2BE1FD52
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004615 RID: 17941
		// (get) Token: 0x060235FE RID: 144894 RVA: 0x009802C8 File Offset: 0x0097E4C8
		// (set) Token: 0x060235FF RID: 144895 RVA: 0x009802DC File Offset: 0x0097E4DC
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_A3641E244AB652293D0D3A8D2BE1FD52
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_27);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004616 RID: 17942
		// (get) Token: 0x06023600 RID: 144896 RVA: 0x009802F1 File Offset: 0x0097E4F1
		// (set) Token: 0x06023601 RID: 144897 RVA: 0x00980305 File Offset: 0x0097E505
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_28);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_28, value);
			}
		}

		// Token: 0x17004617 RID: 17943
		// (get) Token: 0x06023602 RID: 144898 RVA: 0x0098031A File Offset: 0x0097E51A
		// (set) Token: 0x06023603 RID: 144899 RVA: 0x0098032E File Offset: 0x0097E52E
		public unsafe FTransform LeftTrans1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004618 RID: 17944
		// (get) Token: 0x06023604 RID: 144900 RVA: 0x00980343 File Offset: 0x0097E543
		// (set) Token: 0x06023605 RID: 144901 RVA: 0x00980357 File Offset: 0x0097E557
		public unsafe FTransform LeftTrans2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004619 RID: 17945
		// (get) Token: 0x06023606 RID: 144902 RVA: 0x0098036C File Offset: 0x0097E56C
		// (set) Token: 0x06023607 RID: 144903 RVA: 0x00980380 File Offset: 0x0097E580
		public unsafe FTransform LeftTrans3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x1700461A RID: 17946
		// (get) Token: 0x06023608 RID: 144904 RVA: 0x00980395 File Offset: 0x0097E595
		// (set) Token: 0x06023609 RID: 144905 RVA: 0x009803A9 File Offset: 0x0097E5A9
		public unsafe FTransform RightTrans1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x1700461B RID: 17947
		// (get) Token: 0x0602360A RID: 144906 RVA: 0x009803BE File Offset: 0x0097E5BE
		// (set) Token: 0x0602360B RID: 144907 RVA: 0x009803D2 File Offset: 0x0097E5D2
		public unsafe FTransform RightTrans2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x1700461C RID: 17948
		// (get) Token: 0x0602360C RID: 144908 RVA: 0x009803E7 File Offset: 0x0097E5E7
		// (set) Token: 0x0602360D RID: 144909 RVA: 0x009803FB File Offset: 0x0097E5FB
		public unsafe FTransform RightTrans3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x1700461D RID: 17949
		// (get) Token: 0x0602360E RID: 144910 RVA: 0x00980410 File Offset: 0x0097E610
		// (set) Token: 0x0602360F RID: 144911 RVA: 0x00980420 File Offset: 0x0097E620
		public unsafe bool bIsTrans
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700461E RID: 17950
		// (get) Token: 0x06023610 RID: 144912 RVA: 0x00980431 File Offset: 0x0097E631
		// (set) Token: 0x06023611 RID: 144913 RVA: 0x00980441 File Offset: 0x0097E641
		public unsafe bool bIsOpen
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CarOpenDoor_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700461F RID: 17951
		// (get) Token: 0x06023612 RID: 144914 RVA: 0x00980452 File Offset: 0x0097E652
		// (set) Token: 0x06023613 RID: 144915 RVA: 0x00980466 File Offset: 0x0097E666
		public unsafe UAkAudioEvent CloseDoorSound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x17004620 RID: 17952
		// (get) Token: 0x06023614 RID: 144916 RVA: 0x0098047B File Offset: 0x0097E67B
		// (set) Token: 0x06023615 RID: 144917 RVA: 0x0098048F File Offset: 0x0097E68F
		public unsafe UAkAudioEvent OpenDoorSound
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_38);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CarOpenDoor_C.__PropertyOffset_38, value);
			}
		}

		// Token: 0x06023616 RID: 144918 RVA: 0x009804A4 File Offset: 0x0097E6A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023617 RID: 144919 RVA: 0x009804B8 File Offset: 0x0097E6B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023618 RID: 144920 RVA: 0x009804CC File Offset: 0x0097E6CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_4__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_4__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023619 RID: 144921 RVA: 0x009804E0 File Offset: 0x0097E6E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_4__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_4__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602361A RID: 144922 RVA: 0x009804F4 File Offset: 0x0097E6F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_1__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_1__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602361B RID: 144923 RVA: 0x00980508 File Offset: 0x0097E708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_1__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_1__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602361C RID: 144924 RVA: 0x0098051C File Offset: 0x0097E71C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_5__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_5__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602361D RID: 144925 RVA: 0x00980530 File Offset: 0x0097E730
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_5__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_5__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602361E RID: 144926 RVA: 0x00980544 File Offset: 0x0097E744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_2__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_2__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602361F RID: 144927 RVA: 0x00980558 File Offset: 0x0097E758
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_2__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_2__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023620 RID: 144928 RVA: 0x0098056C File Offset: 0x0097E76C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_3__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_3__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023621 RID: 144929 RVA: 0x00980580 File Offset: 0x0097E780
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_3__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_3__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023622 RID: 144930 RVA: 0x00980594 File Offset: 0x0097E794
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_6__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_6__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023623 RID: 144931 RVA: 0x009805A8 File Offset: 0x0097E7A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_6__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_6__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023624 RID: 144932 RVA: 0x009805BC File Offset: 0x0097E7BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_7__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_7__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023625 RID: 144933 RVA: 0x009805D0 File Offset: 0x0097E7D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_7__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Timeline_7__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06023626 RID: 144934 RVA: 0x009805E4 File Offset: 0x0097E7E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_53A13A9545B3414C4D4E72B710224B40(int PlayingID)
		{
			BP_CarOpenDoor_C.__Completed_53A13A9545B3414C4D4E72B710224B40_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__Completed_53A13A9545B3414C4D4E72B710224B40_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarOpenDoor_C.__Completed_53A13A9545B3414C4D4E72B710224B40_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__Completed_53A13A9545B3414C4D4E72B710224B40_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Completed_53A13A9545B3414C4D4E72B710224B40_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023627 RID: 144935 RVA: 0x0098062C File Offset: 0x0097E82C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_5553A0C94D655F5940A628A1D52F7D2F(int PlayingID)
		{
			BP_CarOpenDoor_C.__Completed_5553A0C94D655F5940A628A1D52F7D2F_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__Completed_5553A0C94D655F5940A628A1D52F7D2F_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarOpenDoor_C.__Completed_5553A0C94D655F5940A628A1D52F7D2F_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__Completed_5553A0C94D655F5940A628A1D52F7D2F_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__Completed_5553A0C94D655F5940A628A1D52F7D2F_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023628 RID: 144936 RVA: 0x00980674 File Offset: 0x0097E874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CarOpenDoor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarOpenDoor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023629 RID: 144937 RVA: 0x009806BC File Offset: 0x0097E8BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CarOpenDoor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CarOpenDoor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarOpenDoor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602362A RID: 144938 RVA: 0x00980704 File Offset: 0x0097E904
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_CarOpenDoor_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_CarOpenDoor_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602362B RID: 144939 RVA: 0x009807C0 File Offset: 0x0097E9C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_CarOpenDoor_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_CarOpenDoor_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602362C RID: 144940 RVA: 0x00980849 File Offset: 0x0097EA49
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ChangeDoor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CarOpenDoor_C.__ChangeDoor_NativeFunctionPtr, null);
		}

		// Token: 0x0602362D RID: 144941 RVA: 0x00980860 File Offset: 0x0097EA60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CarOpenDoor(int EntryPoint)
		{
			BP_CarOpenDoor_C.__ExecuteUbergraph_BP_CarOpenDoor_FunctionParams* ptr = stackalloc BP_CarOpenDoor_C.__ExecuteUbergraph_BP_CarOpenDoor_FunctionParams[(UIntPtr)2143] + 15L / (long)sizeof(BP_CarOpenDoor_C.__ExecuteUbergraph_BP_CarOpenDoor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CarOpenDoor_C.__ExecuteUbergraph_BP_CarOpenDoor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CarOpenDoor_C.__ExecuteUbergraph_BP_CarOpenDoor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602362E RID: 144942 RVA: 0x009808AA File Offset: 0x0097EAAA
		protected BP_CarOpenDoor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011FE3 RID: 73699
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/CarPaint/BluePrints/BP_CarOpenDoor.BP_CarOpenDoor_C";

		// Token: 0x04011FE4 RID: 73700
		private static IntPtr _ClassPtr;

		// Token: 0x04011FE5 RID: 73701
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011FE6 RID: 73702
		internal static int __PropertyOffset_0;

		// Token: 0x04011FE7 RID: 73703
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011FE8 RID: 73704
		internal static int __PropertyOffset_1;

		// Token: 0x04011FE9 RID: 73705
		internal static int __PropertyOffset_2;

		// Token: 0x04011FEA RID: 73706
		internal static int __PropertyOffset_3;

		// Token: 0x04011FEB RID: 73707
		internal static int __PropertyOffset_4;

		// Token: 0x04011FEC RID: 73708
		internal static int __PropertyOffset_5;

		// Token: 0x04011FED RID: 73709
		internal static int __PropertyOffset_6;

		// Token: 0x04011FEE RID: 73710
		internal static int __PropertyOffset_7;

		// Token: 0x04011FEF RID: 73711
		internal static int __PropertyOffset_8;

		// Token: 0x04011FF0 RID: 73712
		internal static int __PropertyOffset_9;

		// Token: 0x04011FF1 RID: 73713
		internal static int __PropertyOffset_10;

		// Token: 0x04011FF2 RID: 73714
		internal static int __PropertyOffset_11;

		// Token: 0x04011FF3 RID: 73715
		internal static int __PropertyOffset_12;

		// Token: 0x04011FF4 RID: 73716
		internal static int __PropertyOffset_13;

		// Token: 0x04011FF5 RID: 73717
		internal static int __PropertyOffset_14;

		// Token: 0x04011FF6 RID: 73718
		internal static int __PropertyOffset_15;

		// Token: 0x04011FF7 RID: 73719
		internal static int __PropertyOffset_16;

		// Token: 0x04011FF8 RID: 73720
		internal static int __PropertyOffset_17;

		// Token: 0x04011FF9 RID: 73721
		internal static int __PropertyOffset_18;

		// Token: 0x04011FFA RID: 73722
		internal static int __PropertyOffset_19;

		// Token: 0x04011FFB RID: 73723
		internal static int __PropertyOffset_20;

		// Token: 0x04011FFC RID: 73724
		internal static int __PropertyOffset_21;

		// Token: 0x04011FFD RID: 73725
		internal static int __PropertyOffset_22;

		// Token: 0x04011FFE RID: 73726
		internal static int __PropertyOffset_23;

		// Token: 0x04011FFF RID: 73727
		internal static int __PropertyOffset_24;

		// Token: 0x04012000 RID: 73728
		internal static int __PropertyOffset_25;

		// Token: 0x04012001 RID: 73729
		internal static int __PropertyOffset_26;

		// Token: 0x04012002 RID: 73730
		internal static int __PropertyOffset_27;

		// Token: 0x04012003 RID: 73731
		internal static int __PropertyOffset_28;

		// Token: 0x04012004 RID: 73732
		internal static int __PropertyOffset_29;

		// Token: 0x04012005 RID: 73733
		internal static int __PropertyOffset_30;

		// Token: 0x04012006 RID: 73734
		internal static int __PropertyOffset_31;

		// Token: 0x04012007 RID: 73735
		internal static int __PropertyOffset_32;

		// Token: 0x04012008 RID: 73736
		internal static int __PropertyOffset_33;

		// Token: 0x04012009 RID: 73737
		internal static int __PropertyOffset_34;

		// Token: 0x0401200A RID: 73738
		internal static int __PropertyOffset_35;

		// Token: 0x0401200B RID: 73739
		internal static int __PropertyOffset_36;

		// Token: 0x0401200C RID: 73740
		internal static int __PropertyOffset_37;

		// Token: 0x0401200D RID: 73741
		internal static int __PropertyOffset_38;

		// Token: 0x0401200E RID: 73742
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401200F RID: 73743
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04012010 RID: 73744
		private static IntPtr __Timeline_4__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04012011 RID: 73745
		private static IntPtr __Timeline_4__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04012012 RID: 73746
		private static IntPtr __Timeline_1__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04012013 RID: 73747
		private static IntPtr __Timeline_1__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04012014 RID: 73748
		private static IntPtr __Timeline_5__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04012015 RID: 73749
		private static IntPtr __Timeline_5__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04012016 RID: 73750
		private static IntPtr __Timeline_2__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04012017 RID: 73751
		private static IntPtr __Timeline_2__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04012018 RID: 73752
		private static IntPtr __Timeline_3__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04012019 RID: 73753
		private static IntPtr __Timeline_3__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401201A RID: 73754
		private static IntPtr __Timeline_6__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401201B RID: 73755
		private static IntPtr __Timeline_6__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401201C RID: 73756
		private static IntPtr __Timeline_7__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0401201D RID: 73757
		private static IntPtr __Timeline_7__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0401201E RID: 73758
		private static IntPtr __Completed_53A13A9545B3414C4D4E72B710224B40_NativeFunctionPtr;

		// Token: 0x0401201F RID: 73759
		private static IntPtr __Completed_5553A0C94D655F5940A628A1D52F7D2F_NativeFunctionPtr;

		// Token: 0x04012020 RID: 73760
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012021 RID: 73761
		private static IntPtr __BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012022 RID: 73762
		private static IntPtr __BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04012023 RID: 73763
		private static IntPtr __ChangeDoor_NativeFunctionPtr;

		// Token: 0x04012024 RID: 73764
		private static IntPtr __ExecuteUbergraph_BP_CarOpenDoor_NativeFunctionPtr;

		// Token: 0x02009CCA RID: 40138
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_53A13A9545B3414C4D4E72B710224B40_FunctionParams
		{
			// Token: 0x04032635 RID: 206389
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009CCB RID: 40139
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_5553A0C94D655F5940A628A1D52F7D2F_FunctionParams
		{
			// Token: 0x04032636 RID: 206390
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009CCC RID: 40140
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032637 RID: 206391
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CCD RID: 40141
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_ActorEffect_Trigger_BoxTrigger_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032638 RID: 206392
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032639 RID: 206393
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403263A RID: 206394
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403263B RID: 206395
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403263C RID: 206396
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403263D RID: 206397
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009CCE RID: 40142
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_CarOpenDoor_BoxTrigger_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403263E RID: 206398
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403263F RID: 206399
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032640 RID: 206400
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032641 RID: 206401
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009CCF RID: 40143
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2128)]
		protected ref struct __ExecuteUbergraph_BP_CarOpenDoor_FunctionParams
		{
			// Token: 0x04032642 RID: 206402
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
