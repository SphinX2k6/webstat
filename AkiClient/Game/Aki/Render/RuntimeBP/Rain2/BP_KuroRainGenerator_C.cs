using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B37 RID: 15159
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_KuroRainGenerator.BP_KuroRainGenerator_C")]
	[UnrealStructLayout(1560, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1553)]
	public class BP_KuroRainGenerator_C : AKuroRainActorV2, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020BB1 RID: 134065 RVA: 0x0093561B File Offset: 0x0093381B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroRainGenerator_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_KuroRainGenerator.BP_KuroRainGenerator_C");
			}
			return BP_KuroRainGenerator_C._ClassPtr;
		}

		// Token: 0x06020BB2 RID: 134066 RVA: 0x00935640 File Offset: 0x00933840
		public BP_KuroRainGenerator_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroRainGenerator_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020BB3 RID: 134067 RVA: 0x00935668 File Offset: 0x00933868
		[NullableContext(1)]
		public BP_KuroRainGenerator_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroRainGenerator_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036F0 RID: 14064
		// (get) Token: 0x06020BB4 RID: 134068 RVA: 0x0093569C File Offset: 0x0093389C
		// (set) Token: 0x06020BB5 RID: 134069 RVA: 0x009356D5 File Offset: 0x009338D5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036F1 RID: 14065
		// (get) Token: 0x06020BB6 RID: 134070 RVA: 0x009356F6 File Offset: 0x009338F6
		// (set) Token: 0x06020BB7 RID: 134071 RVA: 0x0093570A File Offset: 0x0093390A
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_CyberRain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036F2 RID: 14066
		// (get) Token: 0x06020BB8 RID: 134072 RVA: 0x0093571F File Offset: 0x0093391F
		// (set) Token: 0x06020BB9 RID: 134073 RVA: 0x00935733 File Offset: 0x00933933
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_StormRain
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036F3 RID: 14067
		// (get) Token: 0x06020BBA RID: 134074 RVA: 0x00935748 File Offset: 0x00933948
		// (set) Token: 0x06020BBB RID: 134075 RVA: 0x0093575C File Offset: 0x0093395C
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_SnowStorm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170036F4 RID: 14068
		// (get) Token: 0x06020BBC RID: 134076 RVA: 0x00935771 File Offset: 0x00933971
		// (set) Token: 0x06020BBD RID: 134077 RVA: 0x00935785 File Offset: 0x00933985
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_BlackWave
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170036F5 RID: 14069
		// (get) Token: 0x06020BBE RID: 134078 RVA: 0x0093579A File Offset: 0x0093399A
		// (set) Token: 0x06020BBF RID: 134079 RVA: 0x009357AE File Offset: 0x009339AE
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_Snow_JinkuBoss
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170036F6 RID: 14070
		// (get) Token: 0x06020BC0 RID: 134080 RVA: 0x009357C3 File Offset: 0x009339C3
		// (set) Token: 0x06020BC1 RID: 134081 RVA: 0x009357D7 File Offset: 0x009339D7
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_RainCommonDrop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170036F7 RID: 14071
		// (get) Token: 0x06020BC2 RID: 134082 RVA: 0x009357EC File Offset: 0x009339EC
		// (set) Token: 0x06020BC3 RID: 134083 RVA: 0x00935800 File Offset: 0x00933A00
		public unsafe BP_WorldRainComponent_Common_C BP_WorldRainComponent_Snow_CommonDrop
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WorldRainComponent_Common_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170036F8 RID: 14072
		// (get) Token: 0x06020BC4 RID: 134084 RVA: 0x00935815 File Offset: 0x00933A15
		// (set) Token: 0x06020BC5 RID: 134085 RVA: 0x00935829 File Offset: 0x00933A29
		public unsafe UNiagaraComponent Niagara_CommonReverse_UrgentTurn
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170036F9 RID: 14073
		// (get) Token: 0x06020BC6 RID: 134086 RVA: 0x0093583E File Offset: 0x00933A3E
		// (set) Token: 0x06020BC7 RID: 134087 RVA: 0x00935852 File Offset: 0x00933A52
		public unsafe BP_RainComponent_CommonReverse_C BP_RainComponent_CommonReverse_UrgentTurn
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RainComponent_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170036FA RID: 14074
		// (get) Token: 0x06020BC8 RID: 134088 RVA: 0x00935867 File Offset: 0x00933A67
		// (set) Token: 0x06020BC9 RID: 134089 RVA: 0x0093587B File Offset: 0x00933A7B
		public unsafe UNiagaraComponent Niagara_CommonReverse_Fast
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170036FB RID: 14075
		// (get) Token: 0x06020BCA RID: 134090 RVA: 0x00935890 File Offset: 0x00933A90
		// (set) Token: 0x06020BCB RID: 134091 RVA: 0x009358A4 File Offset: 0x00933AA4
		public unsafe BP_RainComponent_CommonReverse_C BP_RainComponent_CommonReverse_Fast
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RainComponent_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x170036FC RID: 14076
		// (get) Token: 0x06020BCC RID: 134092 RVA: 0x009358B9 File Offset: 0x00933AB9
		// (set) Token: 0x06020BCD RID: 134093 RVA: 0x009358CD File Offset: 0x00933ACD
		public unsafe UNiagaraComponent Niagara_CommonReverse_Stable
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170036FD RID: 14077
		// (get) Token: 0x06020BCE RID: 134094 RVA: 0x009358E2 File Offset: 0x00933AE2
		// (set) Token: 0x06020BCF RID: 134095 RVA: 0x009358F6 File Offset: 0x00933AF6
		public unsafe UNiagaraComponent Niagara_CommonReverse_Lively
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x170036FE RID: 14078
		// (get) Token: 0x06020BD0 RID: 134096 RVA: 0x0093590B File Offset: 0x00933B0B
		// (set) Token: 0x06020BD1 RID: 134097 RVA: 0x0093591F File Offset: 0x00933B1F
		public unsafe BP_RainComponent_CommonReverse_C BP_RainComponent_CommonReverse_Stable
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RainComponent_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x170036FF RID: 14079
		// (get) Token: 0x06020BD2 RID: 134098 RVA: 0x00935934 File Offset: 0x00933B34
		// (set) Token: 0x06020BD3 RID: 134099 RVA: 0x00935948 File Offset: 0x00933B48
		public unsafe BP_RainComponent_CommonReverse_C BP_RainComponent_CommonReverse_Lively
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_RainComponent_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003700 RID: 14080
		// (get) Token: 0x06020BD4 RID: 134100 RVA: 0x0093595D File Offset: 0x00933B5D
		// (set) Token: 0x06020BD5 RID: 134101 RVA: 0x00935971 File Offset: 0x00933B71
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003701 RID: 14081
		// (get) Token: 0x06020BD6 RID: 134102 RVA: 0x00935986 File Offset: 0x00933B86
		// (set) Token: 0x06020BD7 RID: 134103 RVA: 0x0093599A File Offset: 0x00933B9A
		public unsafe AActor Handle
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003702 RID: 14082
		// (get) Token: 0x06020BD8 RID: 134104 RVA: 0x009359AF File Offset: 0x00933BAF
		// (set) Token: 0x06020BD9 RID: 134105 RVA: 0x009359C3 File Offset: 0x00933BC3
		public unsafe PDA_RainConfigs_C Configs
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfigs_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17003703 RID: 14083
		// (get) Token: 0x06020BDA RID: 134106 RVA: 0x009359D8 File Offset: 0x00933BD8
		// (set) Token: 0x06020BDB RID: 134107 RVA: 0x009359E8 File Offset: 0x00933BE8
		public unsafe float TeleportDistanceToRestart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17003704 RID: 14084
		// (get) Token: 0x06020BDC RID: 134108 RVA: 0x009359F9 File Offset: 0x00933BF9
		// (set) Token: 0x06020BDD RID: 134109 RVA: 0x00935A0D File Offset: 0x00933C0D
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroRainType> CachedRainType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_20);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003705 RID: 14085
		// (get) Token: 0x06020BDE RID: 134110 RVA: 0x00935A22 File Offset: 0x00933C22
		// (set) Token: 0x06020BDF RID: 134111 RVA: 0x00935A36 File Offset: 0x00933C36
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroRainType> CurrentRainType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_21);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17003706 RID: 14086
		// (get) Token: 0x06020BE0 RID: 134112 RVA: 0x00935A4B File Offset: 0x00933C4B
		// (set) Token: 0x06020BE1 RID: 134113 RVA: 0x00935A5B File Offset: 0x00933C5B
		public unsafe float RainDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17003707 RID: 14087
		// (get) Token: 0x06020BE2 RID: 134114 RVA: 0x00935A6C File Offset: 0x00933C6C
		// (set) Token: 0x06020BE3 RID: 134115 RVA: 0x00935A80 File Offset: 0x00933C80
		public unsafe FVector Wind
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17003708 RID: 14088
		// (get) Token: 0x06020BE4 RID: 134116 RVA: 0x00935A95 File Offset: 0x00933C95
		// (set) Token: 0x06020BE5 RID: 134117 RVA: 0x00935AA5 File Offset: 0x00933CA5
		public unsafe float RainFogDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17003709 RID: 14089
		// (get) Token: 0x06020BE6 RID: 134118 RVA: 0x00935AB6 File Offset: 0x00933CB6
		// (set) Token: 0x06020BE7 RID: 134119 RVA: 0x00935ACA File Offset: 0x00933CCA
		public unsafe FVectorDouble CameraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700370A RID: 14090
		// (get) Token: 0x06020BE8 RID: 134120 RVA: 0x00935ADF File Offset: 0x00933CDF
		// (set) Token: 0x06020BE9 RID: 134121 RVA: 0x00935AF3 File Offset: 0x00933CF3
		public unsafe FVector Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700370B RID: 14091
		// (get) Token: 0x06020BEA RID: 134122 RVA: 0x00935B08 File Offset: 0x00933D08
		// (set) Token: 0x06020BEB RID: 134123 RVA: 0x00935B18 File Offset: 0x00933D18
		public unsafe bool IsEnabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700370C RID: 14092
		// (get) Token: 0x06020BEC RID: 134124 RVA: 0x00935B29 File Offset: 0x00933D29
		// (set) Token: 0x06020BED RID: 134125 RVA: 0x00935B39 File Offset: 0x00933D39
		public unsafe bool bRainAffectPointLight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700370D RID: 14093
		// (get) Token: 0x06020BEE RID: 134126 RVA: 0x00935B4A File Offset: 0x00933D4A
		// (set) Token: 0x06020BEF RID: 134127 RVA: 0x00935B5E File Offset: 0x00933D5E
		public unsafe UTODLightManagerSubsystem TODLightSubsystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTODLightManagerSubsystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_29);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroRainGenerator_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x1700370E RID: 14094
		// (get) Token: 0x06020BF0 RID: 134128 RVA: 0x00935B73 File Offset: 0x00933D73
		// (set) Token: 0x06020BF1 RID: 134129 RVA: 0x00935B87 File Offset: 0x00933D87
		[Nullable(0)]
		public unsafe TEnumAsByte<EKuroRainType> SustainRainType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_30);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroRainGenerator_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x06020BF2 RID: 134130 RVA: 0x00935B9C File Offset: 0x00933D9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void StartWorldRain(ref SWorldRainComb Config, BP_WorldRainComponent_Common_C Comp)
		{
			BP_KuroRainGenerator_C.__StartWorldRain_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__StartWorldRain_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__StartWorldRain_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__StartWorldRain_NativeFunctionPtr, (void*)ptr, 1);
			if (Config != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), &ptr->Config, Config.NativePtr, 1, false);
			}
			ptr->Comp = ((Comp != null) ? Comp.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartWorldRain_NativeFunctionPtr, (void*)ptr);
			if (Config != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), Config.NativePtr, &ptr->Config, 1, false);
			}
		}

		// Token: 0x06020BF3 RID: 134131 RVA: 0x00935C39 File Offset: 0x00933E39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateMPC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UpdateMPC_NativeFunctionPtr, null);
		}

		// Token: 0x06020BF4 RID: 134132 RVA: 0x00935C4D File Offset: 0x00933E4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopAll()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StopAll_NativeFunctionPtr, null);
		}

		// Token: 0x06020BF5 RID: 134133 RVA: 0x00935C61 File Offset: 0x00933E61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_CyberRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_CyberRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020BF6 RID: 134134 RVA: 0x00935C75 File Offset: 0x00933E75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_StormRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_StormRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020BF7 RID: 134135 RVA: 0x00935C89 File Offset: 0x00933E89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSnow_SnowStorm()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartSnow_SnowStorm_NativeFunctionPtr, null);
		}

		// Token: 0x06020BF8 RID: 134136 RVA: 0x00935C9D File Offset: 0x00933E9D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_BlackWave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_BlackWave_NativeFunctionPtr, null);
		}

		// Token: 0x06020BF9 RID: 134137 RVA: 0x00935CB1 File Offset: 0x00933EB1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSnow_Jinku_Boss()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartSnow_Jinku_Boss_NativeFunctionPtr, null);
		}

		// Token: 0x06020BFA RID: 134138 RVA: 0x00935CC5 File Offset: 0x00933EC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartSnow_CommonDrop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartSnow_CommonDrop_NativeFunctionPtr, null);
		}

		// Token: 0x06020BFB RID: 134139 RVA: 0x00935CD9 File Offset: 0x00933ED9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_CommonReverse_UrgentTurn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_CommonReverse_UrgentTurn_NativeFunctionPtr, null);
		}

		// Token: 0x06020BFC RID: 134140 RVA: 0x00935CED File Offset: 0x00933EED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_CommonReverse_Fast()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_CommonReverse_Fast_NativeFunctionPtr, null);
		}

		// Token: 0x06020BFD RID: 134141 RVA: 0x00935D01 File Offset: 0x00933F01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateRainGlobalParams()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UpdateRainGlobalParams_NativeFunctionPtr, null);
		}

		// Token: 0x06020BFE RID: 134142 RVA: 0x00935D15 File Offset: 0x00933F15
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_CommonReverse_Stable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_CommonReverse_Stable_NativeFunctionPtr, null);
		}

		// Token: 0x06020BFF RID: 134143 RVA: 0x00935D29 File Offset: 0x00933F29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCameraInfos()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UpdateCameraInfos_NativeFunctionPtr, null);
		}

		// Token: 0x06020C00 RID: 134144 RVA: 0x00935D3D File Offset: 0x00933F3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_CommonReverse_Lively()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_CommonReverse_Lively_NativeFunctionPtr, null);
		}

		// Token: 0x06020C01 RID: 134145 RVA: 0x00935D51 File Offset: 0x00933F51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartRain_CommonDrop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__StartRain_CommonDrop_NativeFunctionPtr, null);
		}

		// Token: 0x06020C02 RID: 134146 RVA: 0x00935D65 File Offset: 0x00933F65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DeactivateAll()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__DeactivateAll_NativeFunctionPtr, null);
		}

		// Token: 0x06020C03 RID: 134147 RVA: 0x00935D79 File Offset: 0x00933F79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RefreshDeactivateStat()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__RefreshDeactivateStat_NativeFunctionPtr, null);
		}

		// Token: 0x06020C04 RID: 134148 RVA: 0x00935D8D File Offset: 0x00933F8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PrintSpeed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__PrintSpeed_NativeFunctionPtr, null);
		}

		// Token: 0x06020C05 RID: 134149 RVA: 0x00935DA1 File Offset: 0x00933FA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020C06 RID: 134150 RVA: 0x00935DB5 File Offset: 0x00933FB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020C07 RID: 134151 RVA: 0x00935DCC File Offset: 0x00933FCC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_KuroRainGenerator_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C08 RID: 134152 RVA: 0x00935E14 File Offset: 0x00934014
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_KuroRainGenerator_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C09 RID: 134153 RVA: 0x00935E5B File Offset: 0x0093405B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void EnableRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__EnableRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C0A RID: 134154 RVA: 0x00935E6F File Offset: 0x0093406F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void EnableRain_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__EnableRain_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020C0B RID: 134155 RVA: 0x00935E84 File Offset: 0x00934084
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void DisableRain()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__DisableRain_NativeFunctionPtr, null);
		}

		// Token: 0x06020C0C RID: 134156 RVA: 0x00935E98 File Offset: 0x00934098
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void DisableRain_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__DisableRain_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020C0D RID: 134157 RVA: 0x00935EAD File Offset: 0x009340AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020C0E RID: 134158 RVA: 0x00935EC1 File Offset: 0x009340C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020C0F RID: 134159 RVA: 0x00935ED8 File Offset: 0x009340D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroRainGenerator_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C10 RID: 134160 RVA: 0x00935F24 File Offset: 0x00934124
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroRainGenerator_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C11 RID: 134161 RVA: 0x00935F70 File Offset: 0x00934170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void UpdatePlayingRainComponent(UKuroRainComponent RainComponent)
		{
			BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RainComponent = ((RainComponent != null) ? RainComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C12 RID: 134162 RVA: 0x00935FC8 File Offset: 0x009341C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void UpdatePlayingRainComponent_Implementation(UKuroRainComponent RainComponent)
		{
			BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RainComponent = ((RainComponent != null) ? RainComponent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__UpdatePlayingRainComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C13 RID: 134163 RVA: 0x00936020 File Offset: 0x00934220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroRainGenerator_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020C14 RID: 134164 RVA: 0x00936068 File Offset: 0x00934268
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroRainGenerator_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C15 RID: 134165 RVA: 0x009360B0 File Offset: 0x009342B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroRainGenerator(int EntryPoint)
		{
			BP_KuroRainGenerator_C.__ExecuteUbergraph_BP_KuroRainGenerator_FunctionParams* ptr = stackalloc BP_KuroRainGenerator_C.__ExecuteUbergraph_BP_KuroRainGenerator_FunctionParams[(UIntPtr)591] + 15L / (long)sizeof(BP_KuroRainGenerator_C.__ExecuteUbergraph_BP_KuroRainGenerator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroRainGenerator_C.__ExecuteUbergraph_BP_KuroRainGenerator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroRainGenerator_C.__ExecuteUbergraph_BP_KuroRainGenerator_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020C16 RID: 134166 RVA: 0x009360FA File Offset: 0x009342FA
		protected BP_KuroRainGenerator_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401066E RID: 67182
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_KuroRainGenerator.BP_KuroRainGenerator_C";

		// Token: 0x0401066F RID: 67183
		private static IntPtr _ClassPtr;

		// Token: 0x04010670 RID: 67184
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010671 RID: 67185
		internal static int __PropertyOffset_0;

		// Token: 0x04010672 RID: 67186
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010673 RID: 67187
		internal static int __PropertyOffset_1;

		// Token: 0x04010674 RID: 67188
		internal static int __PropertyOffset_2;

		// Token: 0x04010675 RID: 67189
		internal static int __PropertyOffset_3;

		// Token: 0x04010676 RID: 67190
		internal static int __PropertyOffset_4;

		// Token: 0x04010677 RID: 67191
		internal static int __PropertyOffset_5;

		// Token: 0x04010678 RID: 67192
		internal static int __PropertyOffset_6;

		// Token: 0x04010679 RID: 67193
		internal static int __PropertyOffset_7;

		// Token: 0x0401067A RID: 67194
		internal static int __PropertyOffset_8;

		// Token: 0x0401067B RID: 67195
		internal static int __PropertyOffset_9;

		// Token: 0x0401067C RID: 67196
		internal static int __PropertyOffset_10;

		// Token: 0x0401067D RID: 67197
		internal static int __PropertyOffset_11;

		// Token: 0x0401067E RID: 67198
		internal static int __PropertyOffset_12;

		// Token: 0x0401067F RID: 67199
		internal static int __PropertyOffset_13;

		// Token: 0x04010680 RID: 67200
		internal static int __PropertyOffset_14;

		// Token: 0x04010681 RID: 67201
		internal static int __PropertyOffset_15;

		// Token: 0x04010682 RID: 67202
		internal static int __PropertyOffset_16;

		// Token: 0x04010683 RID: 67203
		internal static int __PropertyOffset_17;

		// Token: 0x04010684 RID: 67204
		internal static int __PropertyOffset_18;

		// Token: 0x04010685 RID: 67205
		internal static int __PropertyOffset_19;

		// Token: 0x04010686 RID: 67206
		internal static int __PropertyOffset_20;

		// Token: 0x04010687 RID: 67207
		internal static int __PropertyOffset_21;

		// Token: 0x04010688 RID: 67208
		internal static int __PropertyOffset_22;

		// Token: 0x04010689 RID: 67209
		internal static int __PropertyOffset_23;

		// Token: 0x0401068A RID: 67210
		internal static int __PropertyOffset_24;

		// Token: 0x0401068B RID: 67211
		internal static int __PropertyOffset_25;

		// Token: 0x0401068C RID: 67212
		internal static int __PropertyOffset_26;

		// Token: 0x0401068D RID: 67213
		internal static int __PropertyOffset_27;

		// Token: 0x0401068E RID: 67214
		internal static int __PropertyOffset_28;

		// Token: 0x0401068F RID: 67215
		internal static int __PropertyOffset_29;

		// Token: 0x04010690 RID: 67216
		internal static int __PropertyOffset_30;

		// Token: 0x04010691 RID: 67217
		private static IntPtr __StartWorldRain_NativeFunctionPtr;

		// Token: 0x04010692 RID: 67218
		private static IntPtr __UpdateMPC_NativeFunctionPtr;

		// Token: 0x04010693 RID: 67219
		private static IntPtr __StopAll_NativeFunctionPtr;

		// Token: 0x04010694 RID: 67220
		private static IntPtr __StartRain_CyberRain_NativeFunctionPtr;

		// Token: 0x04010695 RID: 67221
		private static IntPtr __StartRain_StormRain_NativeFunctionPtr;

		// Token: 0x04010696 RID: 67222
		private static IntPtr __StartSnow_SnowStorm_NativeFunctionPtr;

		// Token: 0x04010697 RID: 67223
		private static IntPtr __StartRain_BlackWave_NativeFunctionPtr;

		// Token: 0x04010698 RID: 67224
		private static IntPtr __StartSnow_Jinku_Boss_NativeFunctionPtr;

		// Token: 0x04010699 RID: 67225
		private static IntPtr __StartSnow_CommonDrop_NativeFunctionPtr;

		// Token: 0x0401069A RID: 67226
		private static IntPtr __StartRain_CommonReverse_UrgentTurn_NativeFunctionPtr;

		// Token: 0x0401069B RID: 67227
		private static IntPtr __StartRain_CommonReverse_Fast_NativeFunctionPtr;

		// Token: 0x0401069C RID: 67228
		private static IntPtr __UpdateRainGlobalParams_NativeFunctionPtr;

		// Token: 0x0401069D RID: 67229
		private static IntPtr __StartRain_CommonReverse_Stable_NativeFunctionPtr;

		// Token: 0x0401069E RID: 67230
		private static IntPtr __UpdateCameraInfos_NativeFunctionPtr;

		// Token: 0x0401069F RID: 67231
		private static IntPtr __StartRain_CommonReverse_Lively_NativeFunctionPtr;

		// Token: 0x040106A0 RID: 67232
		private static IntPtr __StartRain_CommonDrop_NativeFunctionPtr;

		// Token: 0x040106A1 RID: 67233
		private static IntPtr __DeactivateAll_NativeFunctionPtr;

		// Token: 0x040106A2 RID: 67234
		private static IntPtr __RefreshDeactivateStat_NativeFunctionPtr;

		// Token: 0x040106A3 RID: 67235
		private static IntPtr __PrintSpeed_NativeFunctionPtr;

		// Token: 0x040106A4 RID: 67236
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040106A5 RID: 67237
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040106A6 RID: 67238
		private static IntPtr __EnableRain_NativeFunctionPtr;

		// Token: 0x040106A7 RID: 67239
		private static IntPtr __DisableRain_NativeFunctionPtr;

		// Token: 0x040106A8 RID: 67240
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040106A9 RID: 67241
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x040106AA RID: 67242
		private static IntPtr __UpdatePlayingRainComponent_NativeFunctionPtr;

		// Token: 0x040106AB RID: 67243
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040106AC RID: 67244
		private static IntPtr __ExecuteUbergraph_BP_KuroRainGenerator_NativeFunctionPtr;

		// Token: 0x02009A21 RID: 39457
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __StartWorldRain_FunctionParams
		{
			// Token: 0x04032117 RID: 205079
			[FieldOffset(0)]
			public byte Config;

			// Token: 0x04032118 RID: 205080
			[FieldOffset(40)]
			public IntPtr Comp;
		}

		// Token: 0x02009A22 RID: 39458
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032119 RID: 205081
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A23 RID: 39459
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403211A RID: 205082
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A24 RID: 39460
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __UpdatePlayingRainComponent_FunctionParams
		{
			// Token: 0x0403211B RID: 205083
			[FieldOffset(0)]
			public IntPtr RainComponent;
		}

		// Token: 0x02009A25 RID: 39461
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403211C RID: 205084
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A26 RID: 39462
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 576)]
		protected ref struct __ExecuteUbergraph_BP_KuroRainGenerator_FunctionParams
		{
			// Token: 0x0403211D RID: 205085
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
