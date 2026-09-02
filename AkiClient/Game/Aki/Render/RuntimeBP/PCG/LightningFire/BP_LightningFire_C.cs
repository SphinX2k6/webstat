using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightningFire
{
	// Token: 0x02003BE4 RID: 15332
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightningFire/BP_LightningFire.BP_LightningFire_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class BP_LightningFire_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060226F3 RID: 141043 RVA: 0x0096570C File Offset: 0x0096390C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightningFire_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/LightningFire/BP_LightningFire.BP_LightningFire_C");
			}
			return BP_LightningFire_C._ClassPtr;
		}

		// Token: 0x060226F4 RID: 141044 RVA: 0x00965730 File Offset: 0x00963930
		public BP_LightningFire_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightningFire_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060226F5 RID: 141045 RVA: 0x00965758 File Offset: 0x00963958
		[NullableContext(1)]
		public BP_LightningFire_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightningFire_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170040B7 RID: 16567
		// (get) Token: 0x060226F6 RID: 141046 RVA: 0x0096578C File Offset: 0x0096398C
		// (set) Token: 0x060226F7 RID: 141047 RVA: 0x009657C5 File Offset: 0x009639C5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170040B8 RID: 16568
		// (get) Token: 0x060226F8 RID: 141048 RVA: 0x009657E6 File Offset: 0x009639E6
		// (set) Token: 0x060226F9 RID: 141049 RVA: 0x009657FA File Offset: 0x009639FA
		public unsafe UNiagaraComponent NS_LightningFire_ES3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170040B9 RID: 16569
		// (get) Token: 0x060226FA RID: 141050 RVA: 0x0096580F File Offset: 0x00963A0F
		// (set) Token: 0x060226FB RID: 141051 RVA: 0x00965823 File Offset: 0x00963A23
		public unsafe UStaticMeshComponent SM_LightningFire
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170040BA RID: 16570
		// (get) Token: 0x060226FC RID: 141052 RVA: 0x00965838 File Offset: 0x00963A38
		// (set) Token: 0x060226FD RID: 141053 RVA: 0x0096584C File Offset: 0x00963A4C
		public unsafe USphereComponent DetectionCollision
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170040BB RID: 16571
		// (get) Token: 0x060226FE RID: 141054 RVA: 0x00965861 File Offset: 0x00963A61
		// (set) Token: 0x060226FF RID: 141055 RVA: 0x00965875 File Offset: 0x00963A75
		public unsafe UNiagaraComponent Niagara_Tree
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170040BC RID: 16572
		// (get) Token: 0x06022700 RID: 141056 RVA: 0x0096588A File Offset: 0x00963A8A
		// (set) Token: 0x06022701 RID: 141057 RVA: 0x0096589E File Offset: 0x00963A9E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170040BD RID: 16573
		// (get) Token: 0x06022702 RID: 141058 RVA: 0x009658B3 File Offset: 0x00963AB3
		// (set) Token: 0x06022703 RID: 141059 RVA: 0x009658C7 File Offset: 0x00963AC7
		public unsafe UBoxComponent PostProcessBoundView
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170040BE RID: 16574
		// (get) Token: 0x06022704 RID: 141060 RVA: 0x009658DC File Offset: 0x00963ADC
		// (set) Token: 0x06022705 RID: 141061 RVA: 0x009658F0 File Offset: 0x00963AF0
		public unsafe UTextRenderComponent FireBurnt
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170040BF RID: 16575
		// (get) Token: 0x06022706 RID: 141062 RVA: 0x00965905 File Offset: 0x00963B05
		// (set) Token: 0x06022707 RID: 141063 RVA: 0x00965919 File Offset: 0x00963B19
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170040C0 RID: 16576
		// (get) Token: 0x06022708 RID: 141064 RVA: 0x0096592E File Offset: 0x00963B2E
		// (set) Token: 0x06022709 RID: 141065 RVA: 0x00965942 File Offset: 0x00963B42
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170040C1 RID: 16577
		// (get) Token: 0x0602270A RID: 141066 RVA: 0x00965957 File Offset: 0x00963B57
		// (set) Token: 0x0602270B RID: 141067 RVA: 0x00965967 File Offset: 0x00963B67
		public unsafe float SpreadTimeLinear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170040C2 RID: 16578
		// (get) Token: 0x0602270C RID: 141068 RVA: 0x00965978 File Offset: 0x00963B78
		// (set) Token: 0x0602270D RID: 141069 RVA: 0x00965988 File Offset: 0x00963B88
		public unsafe bool StartPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040C3 RID: 16579
		// (get) Token: 0x0602270E RID: 141070 RVA: 0x00965999 File Offset: 0x00963B99
		// (set) Token: 0x0602270F RID: 141071 RVA: 0x009659AD File Offset: 0x00963BAD
		public unsafe FLinearColor FireColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170040C4 RID: 16580
		// (get) Token: 0x06022710 RID: 141072 RVA: 0x009659C2 File Offset: 0x00963BC2
		// (set) Token: 0x06022711 RID: 141073 RVA: 0x009659D2 File Offset: 0x00963BD2
		public unsafe float SpreadSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170040C5 RID: 16581
		// (get) Token: 0x06022712 RID: 141074 RVA: 0x009659E3 File Offset: 0x00963BE3
		// (set) Token: 0x06022713 RID: 141075 RVA: 0x009659F3 File Offset: 0x00963BF3
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170040C6 RID: 16582
		// (get) Token: 0x06022714 RID: 141076 RVA: 0x00965A04 File Offset: 0x00963C04
		// (set) Token: 0x06022715 RID: 141077 RVA: 0x00965A14 File Offset: 0x00963C14
		public unsafe float BoundSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170040C7 RID: 16583
		// (get) Token: 0x06022716 RID: 141078 RVA: 0x00965A25 File Offset: 0x00963C25
		// (set) Token: 0x06022717 RID: 141079 RVA: 0x00965A35 File Offset: 0x00963C35
		public unsafe float Is_Play
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170040C8 RID: 16584
		// (get) Token: 0x06022718 RID: 141080 RVA: 0x00965A46 File Offset: 0x00963C46
		// (set) Token: 0x06022719 RID: 141081 RVA: 0x00965A5B File Offset: 0x00963C5B
		[Nullable(1)]
		public TSoftObjectPtr<AKuroGlobalGI> GlobalGI
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroGlobalGI>(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_17, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_17, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170040C9 RID: 16585
		// (get) Token: 0x0602271A RID: 141082 RVA: 0x00965A80 File Offset: 0x00963C80
		// (set) Token: 0x0602271B RID: 141083 RVA: 0x00965A95 File Offset: 0x00963C95
		[Nullable(1)]
		public TSoftObjectPtr<AKuroGlobalGI> GlobalGI_Temp
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<AKuroGlobalGI>(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_18, this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_18, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170040CA RID: 16586
		// (get) Token: 0x0602271C RID: 141084 RVA: 0x00965ABA File Offset: 0x00963CBA
		// (set) Token: 0x0602271D RID: 141085 RVA: 0x00965ACA File Offset: 0x00963CCA
		public unsafe float Probability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170040CB RID: 16587
		// (get) Token: 0x0602271E RID: 141086 RVA: 0x00965ADB File Offset: 0x00963CDB
		// (set) Token: 0x0602271F RID: 141087 RVA: 0x00965AEB File Offset: 0x00963CEB
		public unsafe float DeltaScond
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170040CC RID: 16588
		// (get) Token: 0x06022720 RID: 141088 RVA: 0x00965AFC File Offset: 0x00963CFC
		// (set) Token: 0x06022721 RID: 141089 RVA: 0x00965B0C File Offset: 0x00963D0C
		public unsafe float TriggerDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170040CD RID: 16589
		// (get) Token: 0x06022722 RID: 141090 RVA: 0x00965B1D File Offset: 0x00963D1D
		// (set) Token: 0x06022723 RID: 141091 RVA: 0x00965B31 File Offset: 0x00963D31
		public unsafe FVectorDouble NiagaraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170040CE RID: 16590
		// (get) Token: 0x06022724 RID: 141092 RVA: 0x00965B46 File Offset: 0x00963D46
		// (set) Token: 0x06022725 RID: 141093 RVA: 0x00965B56 File Offset: 0x00963D56
		public unsafe float TakeEffectDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170040CF RID: 16591
		// (get) Token: 0x06022726 RID: 141094 RVA: 0x00965B67 File Offset: 0x00963D67
		// (set) Token: 0x06022727 RID: 141095 RVA: 0x00965B77 File Offset: 0x00963D77
		public unsafe bool bPlayerIsTriggerZone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040D0 RID: 16592
		// (get) Token: 0x06022728 RID: 141096 RVA: 0x00965B88 File Offset: 0x00963D88
		// (set) Token: 0x06022729 RID: 141097 RVA: 0x00965B98 File Offset: 0x00963D98
		public unsafe bool DeBug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040D1 RID: 16593
		// (get) Token: 0x0602272A RID: 141098 RVA: 0x00965BA9 File Offset: 0x00963DA9
		// (set) Token: 0x0602272B RID: 141099 RVA: 0x00965BB9 File Offset: 0x00963DB9
		public unsafe float TreeFireSpriteSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170040D2 RID: 16594
		// (get) Token: 0x0602272C RID: 141100 RVA: 0x00965BCA File Offset: 0x00963DCA
		// (set) Token: 0x0602272D RID: 141101 RVA: 0x00965BDE File Offset: 0x00963DDE
		public unsafe UKuroWeatherDataAsset WeatherDataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroWeatherDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_27);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_27, value);
			}
		}

		// Token: 0x170040D3 RID: 16595
		// (get) Token: 0x0602272E RID: 141102 RVA: 0x00965BF3 File Offset: 0x00963DF3
		// (set) Token: 0x0602272F RID: 141103 RVA: 0x00965C03 File Offset: 0x00963E03
		public unsafe float PostProcessRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170040D4 RID: 16596
		// (get) Token: 0x06022730 RID: 141104 RVA: 0x00965C14 File Offset: 0x00963E14
		// (set) Token: 0x06022731 RID: 141105 RVA: 0x00965C24 File Offset: 0x00963E24
		public unsafe float Post_BlendRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170040D5 RID: 16597
		// (get) Token: 0x06022732 RID: 141106 RVA: 0x00965C35 File Offset: 0x00963E35
		// (set) Token: 0x06022733 RID: 141107 RVA: 0x00965C45 File Offset: 0x00963E45
		public unsafe float Post_Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170040D6 RID: 16598
		// (get) Token: 0x06022734 RID: 141108 RVA: 0x00965C56 File Offset: 0x00963E56
		// (set) Token: 0x06022735 RID: 141109 RVA: 0x00965C6A File Offset: 0x00963E6A
		public unsafe AStaticMeshActor FoliageStaticMeshActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AStaticMeshActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_31);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_31, value);
			}
		}

		// Token: 0x170040D7 RID: 16599
		// (get) Token: 0x06022736 RID: 141110 RVA: 0x00965C7F File Offset: 0x00963E7F
		// (set) Token: 0x06022737 RID: 141111 RVA: 0x00965C8F File Offset: 0x00963E8F
		public unsafe bool View_Probability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040D8 RID: 16600
		// (get) Token: 0x06022738 RID: 141112 RVA: 0x00965CA0 File Offset: 0x00963EA0
		// (set) Token: 0x06022739 RID: 141113 RVA: 0x00965CB0 File Offset: 0x00963EB0
		public unsafe bool bIsOnCooldown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040D9 RID: 16601
		// (get) Token: 0x0602273A RID: 141114 RVA: 0x00965CC1 File Offset: 0x00963EC1
		// (set) Token: 0x0602273B RID: 141115 RVA: 0x00965CD1 File Offset: 0x00963ED1
		public unsafe float CooldoownTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x170040DA RID: 16602
		// (get) Token: 0x0602273C RID: 141116 RVA: 0x00965CE2 File Offset: 0x00963EE2
		// (set) Token: 0x0602273D RID: 141117 RVA: 0x00965CF2 File Offset: 0x00963EF2
		public unsafe bool TriggerCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040DB RID: 16603
		// (get) Token: 0x0602273E RID: 141118 RVA: 0x00965D03 File Offset: 0x00963F03
		// (set) Token: 0x0602273F RID: 141119 RVA: 0x00965D13 File Offset: 0x00963F13
		public unsafe bool Is_ES3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_36) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningFire_C.__PropertyOffset_36) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040DC RID: 16604
		// (get) Token: 0x06022740 RID: 141120 RVA: 0x00965D24 File Offset: 0x00963F24
		// (set) Token: 0x06022741 RID: 141121 RVA: 0x00965D38 File Offset: 0x00963F38
		public unsafe UAkAudioEvent AudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_37);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningFire_C.__PropertyOffset_37, value);
			}
		}

		// Token: 0x06022742 RID: 141122 RVA: 0x00965D4D File Offset: 0x00963F4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__Set_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x06022743 RID: 141123 RVA: 0x00965D61 File Offset: 0x00963F61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetPostProcessVolume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__SetPostProcessVolume_NativeFunctionPtr, null);
		}

		// Token: 0x06022744 RID: 141124 RVA: 0x00965D78 File Offset: 0x00963F78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ContorlParameter(bool NewParam)
		{
			BP_LightningFire_C.__ContorlParameter_FunctionParams* ptr = stackalloc BP_LightningFire_C.__ContorlParameter_FunctionParams[(UIntPtr)263] + 15L / (long)sizeof(BP_LightningFire_C.__ContorlParameter_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__ContorlParameter_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__ContorlParameter_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022745 RID: 141125 RVA: 0x00965DC1 File Offset: 0x00963FC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_InitialParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__Set_InitialParameter_NativeFunctionPtr, null);
		}

		// Token: 0x06022746 RID: 141126 RVA: 0x00965DD5 File Offset: 0x00963FD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Tick_Parameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__Set_Tick_Parameter_NativeFunctionPtr, null);
		}

		// Token: 0x06022747 RID: 141127 RVA: 0x00965DE9 File Offset: 0x00963FE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugPlayEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__DebugPlayEffect_NativeFunctionPtr, null);
		}

		// Token: 0x06022748 RID: 141128 RVA: 0x00965DFD File Offset: 0x00963FFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022749 RID: 141129 RVA: 0x00965E11 File Offset: 0x00964011
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningFire_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602274A RID: 141130 RVA: 0x00965E28 File Offset: 0x00964028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LightningFire_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightningFire_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightningFire_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602274B RID: 141131 RVA: 0x00965E70 File Offset: 0x00964070
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LightningFire_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightningFire_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightningFire_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningFire_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602274C RID: 141132 RVA: 0x00965EB7 File Offset: 0x009640B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602274D RID: 141133 RVA: 0x00965ECB File Offset: 0x009640CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningFire_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602274E RID: 141134 RVA: 0x00965EE0 File Offset: 0x009640E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetCooldownEvent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__ResetCooldownEvent_NativeFunctionPtr, null);
		}

		// Token: 0x0602274F RID: 141135 RVA: 0x00965EF4 File Offset: 0x009640F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022750 RID: 141136 RVA: 0x00965FB0 File Offset: 0x009641B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022751 RID: 141137 RVA: 0x0096603C File Offset: 0x0096423C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LightningFire_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LightningFire_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightningFire_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningFire_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022752 RID: 141138 RVA: 0x00966084 File Offset: 0x00964284
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LightningFire_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LightningFire_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightningFire_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningFire_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022753 RID: 141139 RVA: 0x009660CC File Offset: 0x009642CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LightningFire(int EntryPoint)
		{
			BP_LightningFire_C.__ExecuteUbergraph_BP_LightningFire_FunctionParams* ptr = stackalloc BP_LightningFire_C.__ExecuteUbergraph_BP_LightningFire_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_LightningFire_C.__ExecuteUbergraph_BP_LightningFire_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningFire_C.__ExecuteUbergraph_BP_LightningFire_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningFire_C.__ExecuteUbergraph_BP_LightningFire_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022754 RID: 141140 RVA: 0x00966116 File Offset: 0x00964316
		protected BP_LightningFire_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040116ED RID: 71405
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightningFire/BP_LightningFire.BP_LightningFire_C";

		// Token: 0x040116EE RID: 71406
		private static IntPtr _ClassPtr;

		// Token: 0x040116EF RID: 71407
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040116F0 RID: 71408
		internal static int __PropertyOffset_0;

		// Token: 0x040116F1 RID: 71409
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040116F2 RID: 71410
		internal static int __PropertyOffset_1;

		// Token: 0x040116F3 RID: 71411
		internal static int __PropertyOffset_2;

		// Token: 0x040116F4 RID: 71412
		internal static int __PropertyOffset_3;

		// Token: 0x040116F5 RID: 71413
		internal static int __PropertyOffset_4;

		// Token: 0x040116F6 RID: 71414
		internal static int __PropertyOffset_5;

		// Token: 0x040116F7 RID: 71415
		internal static int __PropertyOffset_6;

		// Token: 0x040116F8 RID: 71416
		internal static int __PropertyOffset_7;

		// Token: 0x040116F9 RID: 71417
		internal static int __PropertyOffset_8;

		// Token: 0x040116FA RID: 71418
		internal static int __PropertyOffset_9;

		// Token: 0x040116FB RID: 71419
		internal static int __PropertyOffset_10;

		// Token: 0x040116FC RID: 71420
		internal static int __PropertyOffset_11;

		// Token: 0x040116FD RID: 71421
		internal static int __PropertyOffset_12;

		// Token: 0x040116FE RID: 71422
		internal static int __PropertyOffset_13;

		// Token: 0x040116FF RID: 71423
		internal static int __PropertyOffset_14;

		// Token: 0x04011700 RID: 71424
		internal static int __PropertyOffset_15;

		// Token: 0x04011701 RID: 71425
		internal static int __PropertyOffset_16;

		// Token: 0x04011702 RID: 71426
		internal static int __PropertyOffset_17;

		// Token: 0x04011703 RID: 71427
		internal static int __PropertyOffset_18;

		// Token: 0x04011704 RID: 71428
		internal static int __PropertyOffset_19;

		// Token: 0x04011705 RID: 71429
		internal static int __PropertyOffset_20;

		// Token: 0x04011706 RID: 71430
		internal static int __PropertyOffset_21;

		// Token: 0x04011707 RID: 71431
		internal static int __PropertyOffset_22;

		// Token: 0x04011708 RID: 71432
		internal static int __PropertyOffset_23;

		// Token: 0x04011709 RID: 71433
		internal static int __PropertyOffset_24;

		// Token: 0x0401170A RID: 71434
		internal static int __PropertyOffset_25;

		// Token: 0x0401170B RID: 71435
		internal static int __PropertyOffset_26;

		// Token: 0x0401170C RID: 71436
		internal static int __PropertyOffset_27;

		// Token: 0x0401170D RID: 71437
		internal static int __PropertyOffset_28;

		// Token: 0x0401170E RID: 71438
		internal static int __PropertyOffset_29;

		// Token: 0x0401170F RID: 71439
		internal static int __PropertyOffset_30;

		// Token: 0x04011710 RID: 71440
		internal static int __PropertyOffset_31;

		// Token: 0x04011711 RID: 71441
		internal static int __PropertyOffset_32;

		// Token: 0x04011712 RID: 71442
		internal static int __PropertyOffset_33;

		// Token: 0x04011713 RID: 71443
		internal static int __PropertyOffset_34;

		// Token: 0x04011714 RID: 71444
		internal static int __PropertyOffset_35;

		// Token: 0x04011715 RID: 71445
		internal static int __PropertyOffset_36;

		// Token: 0x04011716 RID: 71446
		internal static int __PropertyOffset_37;

		// Token: 0x04011717 RID: 71447
		private static IntPtr __Set_ES3_NativeFunctionPtr;

		// Token: 0x04011718 RID: 71448
		private static IntPtr __SetPostProcessVolume_NativeFunctionPtr;

		// Token: 0x04011719 RID: 71449
		private static IntPtr __ContorlParameter_NativeFunctionPtr;

		// Token: 0x0401171A RID: 71450
		private static IntPtr __Set_InitialParameter_NativeFunctionPtr;

		// Token: 0x0401171B RID: 71451
		private static IntPtr __Set_Tick_Parameter_NativeFunctionPtr;

		// Token: 0x0401171C RID: 71452
		private static IntPtr __DebugPlayEffect_NativeFunctionPtr;

		// Token: 0x0401171D RID: 71453
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401171E RID: 71454
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401171F RID: 71455
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011720 RID: 71456
		private static IntPtr __ResetCooldownEvent_NativeFunctionPtr;

		// Token: 0x04011721 RID: 71457
		private static IntPtr __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011722 RID: 71458
		private static IntPtr __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011723 RID: 71459
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04011724 RID: 71460
		private static IntPtr __ExecuteUbergraph_BP_LightningFire_NativeFunctionPtr;

		// Token: 0x02009BD9 RID: 39897
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 248)]
		protected ref struct __ContorlParameter_FunctionParams
		{
			// Token: 0x0403241F RID: 205855
			[FieldOffset(0)]
			public bool NewParam;
		}

		// Token: 0x02009BDA RID: 39898
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032420 RID: 205856
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BDB RID: 39899
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032421 RID: 205857
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032422 RID: 205858
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032423 RID: 205859
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032424 RID: 205860
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032425 RID: 205861
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032426 RID: 205862
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009BDC RID: 39900
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_LightningFire_DetectionCollision_K2Node_ComponentBoundEvent_2_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032427 RID: 205863
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032428 RID: 205864
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032429 RID: 205865
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403242A RID: 205866
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009BDD RID: 39901
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403242B RID: 205867
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BDE RID: 39902
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __ExecuteUbergraph_BP_LightningFire_FunctionParams
		{
			// Token: 0x0403242C RID: 205868
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
