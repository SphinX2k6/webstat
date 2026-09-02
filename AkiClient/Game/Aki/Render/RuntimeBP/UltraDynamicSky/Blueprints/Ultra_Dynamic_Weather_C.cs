using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints
{
	// Token: 0x02003A14 RID: 14868
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Weather.Ultra_Dynamic_Weather_C")]
	[UnrealStructLayout(2008, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2004)]
	public class Ultra_Dynamic_Weather_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E81A RID: 124954 RVA: 0x008F6E57 File Offset: 0x008F5057
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (Ultra_Dynamic_Weather_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Weather.Ultra_Dynamic_Weather_C");
			}
			return Ultra_Dynamic_Weather_C._ClassPtr;
		}

		// Token: 0x0601E81B RID: 124955 RVA: 0x008F6E7C File Offset: 0x008F507C
		public Ultra_Dynamic_Weather_C() : this(BuiltinUtils.AllocNativeUObject(Ultra_Dynamic_Weather_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E81C RID: 124956 RVA: 0x008F6EA4 File Offset: 0x008F50A4
		[NullableContext(1)]
		public Ultra_Dynamic_Weather_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(Ultra_Dynamic_Weather_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002AD6 RID: 10966
		// (get) Token: 0x0601E81D RID: 124957 RVA: 0x008F6ED8 File Offset: 0x008F50D8
		// (set) Token: 0x0601E81E RID: 124958 RVA: 0x008F6F11 File Offset: 0x008F5111
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002AD7 RID: 10967
		// (get) Token: 0x0601E81F RID: 124959 RVA: 0x008F6F32 File Offset: 0x008F5132
		// (set) Token: 0x0601E820 RID: 124960 RVA: 0x008F6F46 File Offset: 0x008F5146
		public unsafe UAudioComponent Rain_Y_minus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002AD8 RID: 10968
		// (get) Token: 0x0601E821 RID: 124961 RVA: 0x008F6F5B File Offset: 0x008F515B
		// (set) Token: 0x0601E822 RID: 124962 RVA: 0x008F6F6F File Offset: 0x008F516F
		public unsafe UAudioComponent Rain_Y_plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002AD9 RID: 10969
		// (get) Token: 0x0601E823 RID: 124963 RVA: 0x008F6F84 File Offset: 0x008F5184
		// (set) Token: 0x0601E824 RID: 124964 RVA: 0x008F6F98 File Offset: 0x008F5198
		public unsafe UAudioComponent Rain_X_minus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002ADA RID: 10970
		// (get) Token: 0x0601E825 RID: 124965 RVA: 0x008F6FAD File Offset: 0x008F51AD
		// (set) Token: 0x0601E826 RID: 124966 RVA: 0x008F6FC1 File Offset: 0x008F51C1
		public unsafe UAudioComponent Rain_X_plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002ADB RID: 10971
		// (get) Token: 0x0601E827 RID: 124967 RVA: 0x008F6FD6 File Offset: 0x008F51D6
		// (set) Token: 0x0601E828 RID: 124968 RVA: 0x008F6FEA File Offset: 0x008F51EA
		public unsafe UAudioComponent Wind_Y_minus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17002ADC RID: 10972
		// (get) Token: 0x0601E829 RID: 124969 RVA: 0x008F6FFF File Offset: 0x008F51FF
		// (set) Token: 0x0601E82A RID: 124970 RVA: 0x008F7013 File Offset: 0x008F5213
		public unsafe UAudioComponent Wind_Y_plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17002ADD RID: 10973
		// (get) Token: 0x0601E82B RID: 124971 RVA: 0x008F7028 File Offset: 0x008F5228
		// (set) Token: 0x0601E82C RID: 124972 RVA: 0x008F703C File Offset: 0x008F523C
		public unsafe UAudioComponent Wind_X_minus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17002ADE RID: 10974
		// (get) Token: 0x0601E82D RID: 124973 RVA: 0x008F7051 File Offset: 0x008F5251
		// (set) Token: 0x0601E82E RID: 124974 RVA: 0x008F7065 File Offset: 0x008F5265
		public unsafe UAudioComponent Wind_Whistling
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17002ADF RID: 10975
		// (get) Token: 0x0601E82F RID: 124975 RVA: 0x008F707A File Offset: 0x008F527A
		// (set) Token: 0x0601E830 RID: 124976 RVA: 0x008F708E File Offset: 0x008F528E
		public unsafe UAudioComponent DistantThunder_Cue
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002AE0 RID: 10976
		// (get) Token: 0x0601E831 RID: 124977 RVA: 0x008F70A3 File Offset: 0x008F52A3
		// (set) Token: 0x0601E832 RID: 124978 RVA: 0x008F70B7 File Offset: 0x008F52B7
		public unsafe UAudioComponent Wind_X_plus
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAudioComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002AE1 RID: 10977
		// (get) Token: 0x0601E833 RID: 124979 RVA: 0x008F70CC File Offset: 0x008F52CC
		// (set) Token: 0x0601E834 RID: 124980 RVA: 0x008F70E0 File Offset: 0x008F52E0
		public unsafe UNiagaraComponent Obscured_Lightning
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002AE2 RID: 10978
		// (get) Token: 0x0601E835 RID: 124981 RVA: 0x008F70F5 File Offset: 0x008F52F5
		// (set) Token: 0x0601E836 RID: 124982 RVA: 0x008F7109 File Offset: 0x008F5309
		public unsafe UDirectionalLightComponent Lightning_Light
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDirectionalLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002AE3 RID: 10979
		// (get) Token: 0x0601E837 RID: 124983 RVA: 0x008F711E File Offset: 0x008F531E
		// (set) Token: 0x0601E838 RID: 124984 RVA: 0x008F7132 File Offset: 0x008F5332
		public unsafe UBillboardComponent Root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002AE4 RID: 10980
		// (get) Token: 0x0601E839 RID: 124985 RVA: 0x008F7147 File Offset: 0x008F5347
		// (set) Token: 0x0601E83A RID: 124986 RVA: 0x008F715B File Offset: 0x008F535B
		public unsafe UNiagaraComponent Rain_and_Snow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002AE5 RID: 10981
		// (get) Token: 0x0601E83B RID: 124987 RVA: 0x008F7170 File Offset: 0x008F5370
		// (set) Token: 0x0601E83C RID: 124988 RVA: 0x008F7180 File Offset: 0x008F5380
		public unsafe float Lightning_Strength_Strength_42A3C5BF44EC76E7205FA595C4CFB5A2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17002AE6 RID: 10982
		// (get) Token: 0x0601E83D RID: 124989 RVA: 0x008F7191 File Offset: 0x008F5391
		// (set) Token: 0x0601E83E RID: 124990 RVA: 0x008F71A5 File Offset: 0x008F53A5
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Lightning_Strength__Direction_42A3C5BF44EC76E7205FA595C4CFB5A2
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_16);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17002AE7 RID: 10983
		// (get) Token: 0x0601E83F RID: 124991 RVA: 0x008F71BA File Offset: 0x008F53BA
		// (set) Token: 0x0601E840 RID: 124992 RVA: 0x008F71CE File Offset: 0x008F53CE
		public unsafe UTimelineComponent Lightning_Strength
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17002AE8 RID: 10984
		// (get) Token: 0x0601E841 RID: 124993 RVA: 0x008F71E3 File Offset: 0x008F53E3
		// (set) Token: 0x0601E842 RID: 124994 RVA: 0x008F71F7 File Offset: 0x008F53F7
		public unsafe Ultra_Dynamic_Sky_C UltraDynamicSky
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<Ultra_Dynamic_Sky_C>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17002AE9 RID: 10985
		// (get) Token: 0x0601E843 RID: 124995 RVA: 0x008F720C File Offset: 0x008F540C
		// (set) Token: 0x0601E844 RID: 124996 RVA: 0x008F7220 File Offset: 0x008F5420
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_WeatherTypes> Weather_Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_19);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17002AEA RID: 10986
		// (get) Token: 0x0601E845 RID: 124997 RVA: 0x008F7235 File Offset: 0x008F5435
		// (set) Token: 0x0601E846 RID: 124998 RVA: 0x008F7245 File Offset: 0x008F5445
		public unsafe float Weather_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17002AEB RID: 10987
		// (get) Token: 0x0601E847 RID: 124999 RVA: 0x008F7256 File Offset: 0x008F5456
		// (set) Token: 0x0601E848 RID: 125000 RVA: 0x008F7266 File Offset: 0x008F5466
		public unsafe float Cloud_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17002AEC RID: 10988
		// (get) Token: 0x0601E849 RID: 125001 RVA: 0x008F7277 File Offset: 0x008F5477
		// (set) Token: 0x0601E84A RID: 125002 RVA: 0x008F7287 File Offset: 0x008F5487
		public unsafe float Rain_or_Snow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002AED RID: 10989
		// (get) Token: 0x0601E84B RID: 125003 RVA: 0x008F7298 File Offset: 0x008F5498
		// (set) Token: 0x0601E84C RID: 125004 RVA: 0x008F72A8 File Offset: 0x008F54A8
		public unsafe float Wind_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17002AEE RID: 10990
		// (get) Token: 0x0601E84D RID: 125005 RVA: 0x008F72B9 File Offset: 0x008F54B9
		// (set) Token: 0x0601E84E RID: 125006 RVA: 0x008F72C9 File Offset: 0x008F54C9
		public unsafe float Wind_Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17002AEF RID: 10991
		// (get) Token: 0x0601E84F RID: 125007 RVA: 0x008F72DA File Offset: 0x008F54DA
		// (set) Token: 0x0601E850 RID: 125008 RVA: 0x008F72EA File Offset: 0x008F54EA
		public unsafe float Temperature_Celsius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17002AF0 RID: 10992
		// (get) Token: 0x0601E851 RID: 125009 RVA: 0x008F72FB File Offset: 0x008F54FB
		// (set) Token: 0x0601E852 RID: 125010 RVA: 0x008F730B File Offset: 0x008F550B
		public unsafe float Lerp_to_New_Settings
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17002AF1 RID: 10993
		// (get) Token: 0x0601E853 RID: 125011 RVA: 0x008F731C File Offset: 0x008F551C
		// (set) Token: 0x0601E854 RID: 125012 RVA: 0x008F732C File Offset: 0x008F552C
		public unsafe float Weather_Intensity_OLD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17002AF2 RID: 10994
		// (get) Token: 0x0601E855 RID: 125013 RVA: 0x008F733D File Offset: 0x008F553D
		// (set) Token: 0x0601E856 RID: 125014 RVA: 0x008F734D File Offset: 0x008F554D
		public unsafe float Cloud_Coverage_OLD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17002AF3 RID: 10995
		// (get) Token: 0x0601E857 RID: 125015 RVA: 0x008F735E File Offset: 0x008F555E
		// (set) Token: 0x0601E858 RID: 125016 RVA: 0x008F736E File Offset: 0x008F556E
		public unsafe float Rain_orSnow_OLD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17002AF4 RID: 10996
		// (get) Token: 0x0601E859 RID: 125017 RVA: 0x008F737F File Offset: 0x008F557F
		// (set) Token: 0x0601E85A RID: 125018 RVA: 0x008F738F File Offset: 0x008F558F
		public unsafe float Wind_Intensity_OLD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17002AF5 RID: 10997
		// (get) Token: 0x0601E85B RID: 125019 RVA: 0x008F73A0 File Offset: 0x008F55A0
		// (set) Token: 0x0601E85C RID: 125020 RVA: 0x008F73B4 File Offset: 0x008F55B4
		public unsafe FRotator Wind_Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17002AF6 RID: 10998
		// (get) Token: 0x0601E85D RID: 125021 RVA: 0x008F73C9 File Offset: 0x008F55C9
		// (set) Token: 0x0601E85E RID: 125022 RVA: 0x008F73D9 File Offset: 0x008F55D9
		public unsafe float Lerp_to_Static_Settings
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17002AF7 RID: 10999
		// (get) Token: 0x0601E85F RID: 125023 RVA: 0x008F73EA File Offset: 0x008F55EA
		// (set) Token: 0x0601E860 RID: 125024 RVA: 0x008F73FA File Offset: 0x008F55FA
		public unsafe float Current_Weather_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17002AF8 RID: 11000
		// (get) Token: 0x0601E861 RID: 125025 RVA: 0x008F740B File Offset: 0x008F560B
		// (set) Token: 0x0601E862 RID: 125026 RVA: 0x008F741B File Offset: 0x008F561B
		public unsafe float Current_Cloud_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17002AF9 RID: 11001
		// (get) Token: 0x0601E863 RID: 125027 RVA: 0x008F742C File Offset: 0x008F562C
		// (set) Token: 0x0601E864 RID: 125028 RVA: 0x008F743C File Offset: 0x008F563C
		public unsafe float Current_Rain_or_Snow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x17002AFA RID: 11002
		// (get) Token: 0x0601E865 RID: 125029 RVA: 0x008F744D File Offset: 0x008F564D
		// (set) Token: 0x0601E866 RID: 125030 RVA: 0x008F745D File Offset: 0x008F565D
		public unsafe float Current_Wind_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17002AFB RID: 11003
		// (get) Token: 0x0601E867 RID: 125031 RVA: 0x008F746E File Offset: 0x008F566E
		// (set) Token: 0x0601E868 RID: 125032 RVA: 0x008F747E File Offset: 0x008F567E
		public unsafe float Transition_In_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17002AFC RID: 11004
		// (get) Token: 0x0601E869 RID: 125033 RVA: 0x008F748F File Offset: 0x008F568F
		// (set) Token: 0x0601E86A RID: 125034 RVA: 0x008F749F File Offset: 0x008F569F
		public unsafe float Transition_Out_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x17002AFD RID: 11005
		// (get) Token: 0x0601E86B RID: 125035 RVA: 0x008F74B0 File Offset: 0x008F56B0
		// (set) Token: 0x0601E86C RID: 125036 RVA: 0x008F74C0 File Offset: 0x008F56C0
		public unsafe float Hold_Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17002AFE RID: 11006
		// (get) Token: 0x0601E86D RID: 125037 RVA: 0x008F74D1 File Offset: 0x008F56D1
		// (set) Token: 0x0601E86E RID: 125038 RVA: 0x008F74E1 File Offset: 0x008F56E1
		public unsafe bool Use_Initial_Settings
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_40) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_40) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002AFF RID: 11007
		// (get) Token: 0x0601E86F RID: 125039 RVA: 0x008F74F2 File Offset: 0x008F56F2
		// (set) Token: 0x0601E870 RID: 125040 RVA: 0x008F7502 File Offset: 0x008F5702
		public unsafe float Time_to_Hold_Initial_Settings
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17002B00 RID: 11008
		// (get) Token: 0x0601E871 RID: 125041 RVA: 0x008F7513 File Offset: 0x008F5713
		// (set) Token: 0x0601E872 RID: 125042 RVA: 0x008F7523 File Offset: 0x008F5723
		public unsafe float Time_To_Transition_from_Initial_Settings_to_Random_Variation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17002B01 RID: 11009
		// (get) Token: 0x0601E873 RID: 125043 RVA: 0x008F7534 File Offset: 0x008F5734
		// (set) Token: 0x0601E874 RID: 125044 RVA: 0x008F7544 File Offset: 0x008F5744
		public unsafe int Transition_State
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x17002B02 RID: 11010
		// (get) Token: 0x0601E875 RID: 125045 RVA: 0x008F7555 File Offset: 0x008F5755
		// (set) Token: 0x0601E876 RID: 125046 RVA: 0x008F7565 File Offset: 0x008F5765
		public unsafe float Timer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17002B03 RID: 11011
		// (get) Token: 0x0601E877 RID: 125047 RVA: 0x008F7576 File Offset: 0x008F5776
		// (set) Token: 0x0601E878 RID: 125048 RVA: 0x008F7586 File Offset: 0x008F5786
		public unsafe bool Enable_Rain_and_Snow_Particles
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B04 RID: 11012
		// (get) Token: 0x0601E879 RID: 125049 RVA: 0x008F7597 File Offset: 0x008F5797
		// (set) Token: 0x0601E87A RID: 125050 RVA: 0x008F75A7 File Offset: 0x008F57A7
		public unsafe float Max_Particle_Spawn_Rate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17002B05 RID: 11013
		// (get) Token: 0x0601E87B RID: 125051 RVA: 0x008F75B8 File Offset: 0x008F57B8
		// (set) Token: 0x0601E87C RID: 125052 RVA: 0x008F75C8 File Offset: 0x008F57C8
		public unsafe bool Particle_Collision_Enabled
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B06 RID: 11014
		// (get) Token: 0x0601E87D RID: 125053 RVA: 0x008F75D9 File Offset: 0x008F57D9
		// (set) Token: 0x0601E87E RID: 125054 RVA: 0x008F75E9 File Offset: 0x008F57E9
		public unsafe float Camera_Forward_Spawn_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17002B07 RID: 11015
		// (get) Token: 0x0601E87F RID: 125055 RVA: 0x008F75FA File Offset: 0x008F57FA
		// (set) Token: 0x0601E880 RID: 125056 RVA: 0x008F760A File Offset: 0x008F580A
		public unsafe float Ceiling_Check_Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x17002B08 RID: 11016
		// (get) Token: 0x0601E881 RID: 125057 RVA: 0x008F761B File Offset: 0x008F581B
		// (set) Token: 0x0601E882 RID: 125058 RVA: 0x008F762B File Offset: 0x008F582B
		public unsafe float Spawn_Box_Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17002B09 RID: 11017
		// (get) Token: 0x0601E883 RID: 125059 RVA: 0x008F763C File Offset: 0x008F583C
		// (set) Token: 0x0601E884 RID: 125060 RVA: 0x008F764C File Offset: 0x008F584C
		public unsafe float Max_Spawn_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x17002B0A RID: 11018
		// (get) Token: 0x0601E885 RID: 125061 RVA: 0x008F765D File Offset: 0x008F585D
		// (set) Token: 0x0601E886 RID: 125062 RVA: 0x008F766D File Offset: 0x008F586D
		public unsafe float Spawn_Distance_Distribution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17002B0B RID: 11019
		// (get) Token: 0x0601E887 RID: 125063 RVA: 0x008F767E File Offset: 0x008F587E
		// (set) Token: 0x0601E888 RID: 125064 RVA: 0x008F768E File Offset: 0x008F588E
		public unsafe float Minimum_Particle_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17002B0C RID: 11020
		// (get) Token: 0x0601E889 RID: 125065 RVA: 0x008F769F File Offset: 0x008F589F
		// (set) Token: 0x0601E88A RID: 125066 RVA: 0x008F76AF File Offset: 0x008F58AF
		public unsafe float Rain_Drops_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17002B0D RID: 11021
		// (get) Token: 0x0601E88B RID: 125067 RVA: 0x008F76C0 File Offset: 0x008F58C0
		// (set) Token: 0x0601E88C RID: 125068 RVA: 0x008F76D0 File Offset: 0x008F58D0
		public unsafe float Snow_Flakes_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x17002B0E RID: 11022
		// (get) Token: 0x0601E88D RID: 125069 RVA: 0x008F76E1 File Offset: 0x008F58E1
		// (set) Token: 0x0601E88E RID: 125070 RVA: 0x008F76F1 File Offset: 0x008F58F1
		public unsafe float Rain_Drops_Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_56);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_56) = value;
			}
		}

		// Token: 0x17002B0F RID: 11023
		// (get) Token: 0x0601E88F RID: 125071 RVA: 0x008F7702 File Offset: 0x008F5902
		// (set) Token: 0x0601E890 RID: 125072 RVA: 0x008F7712 File Offset: 0x008F5912
		public unsafe float Snow_Flakes_Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17002B10 RID: 11024
		// (get) Token: 0x0601E891 RID: 125073 RVA: 0x008F7723 File Offset: 0x008F5923
		// (set) Token: 0x0601E892 RID: 125074 RVA: 0x008F7737 File Offset: 0x008F5937
		[Nullable(0)]
		public unsafe TEnumAsByte<ECollisionChannel> Rain_or_Snow_Particle_Collision_Channel
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_58);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17002B11 RID: 11025
		// (get) Token: 0x0601E893 RID: 125075 RVA: 0x008F774C File Offset: 0x008F594C
		// (set) Token: 0x0601E894 RID: 125076 RVA: 0x008F775C File Offset: 0x008F595C
		public unsafe float Splash_Frequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x17002B12 RID: 11026
		// (get) Token: 0x0601E895 RID: 125077 RVA: 0x008F776D File Offset: 0x008F596D
		// (set) Token: 0x0601E896 RID: 125078 RVA: 0x008F777D File Offset: 0x008F597D
		public unsafe bool Snow_Flakes_Stick_to_Surfaces
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_60) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_60) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B13 RID: 11027
		// (get) Token: 0x0601E897 RID: 125079 RVA: 0x008F778E File Offset: 0x008F598E
		// (set) Token: 0x0601E898 RID: 125080 RVA: 0x008F779E File Offset: 0x008F599E
		public unsafe float Current_Snow_Percentage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_61);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_61) = value;
			}
		}

		// Token: 0x17002B14 RID: 11028
		// (get) Token: 0x0601E899 RID: 125081 RVA: 0x008F77AF File Offset: 0x008F59AF
		// (set) Token: 0x0601E89A RID: 125082 RVA: 0x008F77C3 File Offset: 0x008F59C3
		public unsafe FVector Current_Lightning_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_62);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_62) = value;
			}
		}

		// Token: 0x17002B15 RID: 11029
		// (get) Token: 0x0601E89B RID: 125083 RVA: 0x008F77D8 File Offset: 0x008F59D8
		// (set) Token: 0x0601E89C RID: 125084 RVA: 0x008F77E8 File Offset: 0x008F59E8
		public unsafe bool Spawn_Lightning_Flashes
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_63) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_63) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B16 RID: 11030
		// (get) Token: 0x0601E89D RID: 125085 RVA: 0x008F77F9 File Offset: 0x008F59F9
		// (set) Token: 0x0601E89E RID: 125086 RVA: 0x008F780D File Offset: 0x008F5A0D
		public unsafe FVector Current_Camera_Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_64);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_64) = value;
			}
		}

		// Token: 0x17002B17 RID: 11031
		// (get) Token: 0x0601E89F RID: 125087 RVA: 0x008F7822 File Offset: 0x008F5A22
		// (set) Token: 0x0601E8A0 RID: 125088 RVA: 0x008F7832 File Offset: 0x008F5A32
		public unsafe float Current_Lightning_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_65);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_65) = value;
			}
		}

		// Token: 0x17002B18 RID: 11032
		// (get) Token: 0x0601E8A1 RID: 125089 RVA: 0x008F7843 File Offset: 0x008F5A43
		// (set) Token: 0x0601E8A2 RID: 125090 RVA: 0x008F7857 File Offset: 0x008F5A57
		public unsafe FFloatRange Lightning_Flash_Interval_Random_Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_66);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_66) = value;
			}
		}

		// Token: 0x17002B19 RID: 11033
		// (get) Token: 0x0601E8A3 RID: 125091 RVA: 0x008F786C File Offset: 0x008F5A6C
		// (set) Token: 0x0601E8A4 RID: 125092 RVA: 0x008F787C File Offset: 0x008F5A7C
		public unsafe bool Lightning_Flash_Light_Source
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_67) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_67) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B1A RID: 11034
		// (get) Token: 0x0601E8A5 RID: 125093 RVA: 0x008F788D File Offset: 0x008F5A8D
		// (set) Token: 0x0601E8A6 RID: 125094 RVA: 0x008F78A1 File Offset: 0x008F5AA1
		public unsafe FLinearColor Lightning_Flash_Light_Source_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17002B1B RID: 11035
		// (get) Token: 0x0601E8A7 RID: 125095 RVA: 0x008F78B6 File Offset: 0x008F5AB6
		// (set) Token: 0x0601E8A8 RID: 125096 RVA: 0x008F78C6 File Offset: 0x008F5AC6
		public unsafe float Maximum_Lightning_Flash_Light_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17002B1C RID: 11036
		// (get) Token: 0x0601E8A9 RID: 125097 RVA: 0x008F78D7 File Offset: 0x008F5AD7
		// (set) Token: 0x0601E8AA RID: 125098 RVA: 0x008F78E7 File Offset: 0x008F5AE7
		public unsafe bool Lightning_Flashes_Cast_Shadows
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B1D RID: 11037
		// (get) Token: 0x0601E8AB RID: 125099 RVA: 0x008F78F8 File Offset: 0x008F5AF8
		// (set) Token: 0x0601E8AC RID: 125100 RVA: 0x008F7908 File Offset: 0x008F5B08
		public unsafe bool Lightning_Flashes_Cast_Light_Shaft_Bloom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_71) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_71) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B1E RID: 11038
		// (get) Token: 0x0601E8AD RID: 125101 RVA: 0x008F7919 File Offset: 0x008F5B19
		// (set) Token: 0x0601E8AE RID: 125102 RVA: 0x008F7929 File Offset: 0x008F5B29
		public unsafe float Lightning_Flash_Light_Shaft_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x17002B1F RID: 11039
		// (get) Token: 0x0601E8AF RID: 125103 RVA: 0x008F793A File Offset: 0x008F5B3A
		// (set) Token: 0x0601E8B0 RID: 125104 RVA: 0x008F794E File Offset: 0x008F5B4E
		public unsafe FFloatRange Lightning_Flash_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x17002B20 RID: 11040
		// (get) Token: 0x0601E8B1 RID: 125105 RVA: 0x008F7963 File Offset: 0x008F5B63
		// (set) Token: 0x0601E8B2 RID: 125106 RVA: 0x008F7973 File Offset: 0x008F5B73
		public unsafe bool Enable_Obscured_Lightning
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_74) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_74) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B21 RID: 11041
		// (get) Token: 0x0601E8B3 RID: 125107 RVA: 0x008F7984 File Offset: 0x008F5B84
		// (set) Token: 0x0601E8B4 RID: 125108 RVA: 0x008F7994 File Offset: 0x008F5B94
		public unsafe float Obscured_Lightning_Spawn_Interval__Rain_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17002B22 RID: 11042
		// (get) Token: 0x0601E8B5 RID: 125109 RVA: 0x008F79A5 File Offset: 0x008F5BA5
		// (set) Token: 0x0601E8B6 RID: 125110 RVA: 0x008F79B5 File Offset: 0x008F5BB5
		public unsafe float Obscured_Lightning_Spawn_Interval__Snow_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17002B23 RID: 11043
		// (get) Token: 0x0601E8B7 RID: 125111 RVA: 0x008F79C6 File Offset: 0x008F5BC6
		// (set) Token: 0x0601E8B8 RID: 125112 RVA: 0x008F79D6 File Offset: 0x008F5BD6
		public unsafe float Lightning_Flash_Height
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17002B24 RID: 11044
		// (get) Token: 0x0601E8B9 RID: 125113 RVA: 0x008F79E7 File Offset: 0x008F5BE7
		// (set) Token: 0x0601E8BA RID: 125114 RVA: 0x008F79F7 File Offset: 0x008F5BF7
		public unsafe bool Spawn_Lightning_Flashes_During_Snow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_78) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_78) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B25 RID: 11045
		// (get) Token: 0x0601E8BB RID: 125115 RVA: 0x008F7A08 File Offset: 0x008F5C08
		// (set) Token: 0x0601E8BC RID: 125116 RVA: 0x008F7A18 File Offset: 0x008F5C18
		public unsafe bool Enable_Fog_Particles
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_79) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_79) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B26 RID: 11046
		// (get) Token: 0x0601E8BD RID: 125117 RVA: 0x008F7A29 File Offset: 0x008F5C29
		// (set) Token: 0x0601E8BE RID: 125118 RVA: 0x008F7A39 File Offset: 0x008F5C39
		public unsafe float Max_Fog_Particle_Percentage__Rain_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_80);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_80) = value;
			}
		}

		// Token: 0x17002B27 RID: 11047
		// (get) Token: 0x0601E8BF RID: 125119 RVA: 0x008F7A4A File Offset: 0x008F5C4A
		// (set) Token: 0x0601E8C0 RID: 125120 RVA: 0x008F7A5A File Offset: 0x008F5C5A
		public unsafe float Max_Fog_Particle_Percentage__Snow_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_81);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x17002B28 RID: 11048
		// (get) Token: 0x0601E8C1 RID: 125121 RVA: 0x008F7A6B File Offset: 0x008F5C6B
		// (set) Token: 0x0601E8C2 RID: 125122 RVA: 0x008F7A7B File Offset: 0x008F5C7B
		public unsafe float Fog_Particle_Intensity__Rain_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_82);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x17002B29 RID: 11049
		// (get) Token: 0x0601E8C3 RID: 125123 RVA: 0x008F7A8C File Offset: 0x008F5C8C
		// (set) Token: 0x0601E8C4 RID: 125124 RVA: 0x008F7A9C File Offset: 0x008F5C9C
		public unsafe float Fog_Particle_Intensity__Snow_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x17002B2A RID: 11050
		// (get) Token: 0x0601E8C5 RID: 125125 RVA: 0x008F7AAD File Offset: 0x008F5CAD
		// (set) Token: 0x0601E8C6 RID: 125126 RVA: 0x008F7ABD File Offset: 0x008F5CBD
		public unsafe float Fog_Particles_Draw_Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17002B2B RID: 11051
		// (get) Token: 0x0601E8C7 RID: 125127 RVA: 0x008F7ACE File Offset: 0x008F5CCE
		// (set) Token: 0x0601E8C8 RID: 125128 RVA: 0x008F7AE2 File Offset: 0x008F5CE2
		public unsafe AWindDirectionalSource Wind_Directional_Source_Actor__for_SpeedTree_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AWindDirectionalSource>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_85);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_85, value);
			}
		}

		// Token: 0x17002B2C RID: 11052
		// (get) Token: 0x0601E8C9 RID: 125129 RVA: 0x008F7AF7 File Offset: 0x008F5CF7
		// (set) Token: 0x0601E8CA RID: 125130 RVA: 0x008F7B07 File Offset: 0x008F5D07
		public unsafe bool Has_Valid_Wind_Actor_Reference
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_86) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_86) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B2D RID: 11053
		// (get) Token: 0x0601E8CB RID: 125131 RVA: 0x008F7B18 File Offset: 0x008F5D18
		// (set) Token: 0x0601E8CC RID: 125132 RVA: 0x008F7B28 File Offset: 0x008F5D28
		public unsafe float Material_Wetness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_87);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x17002B2E RID: 11054
		// (get) Token: 0x0601E8CD RID: 125133 RVA: 0x008F7B39 File Offset: 0x008F5D39
		// (set) Token: 0x0601E8CE RID: 125134 RVA: 0x008F7B49 File Offset: 0x008F5D49
		public unsafe float Material_Snow_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_88);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_88) = value;
			}
		}

		// Token: 0x17002B2F RID: 11055
		// (get) Token: 0x0601E8CF RID: 125135 RVA: 0x008F7B5A File Offset: 0x008F5D5A
		// (set) Token: 0x0601E8D0 RID: 125136 RVA: 0x008F7B6A File Offset: 0x008F5D6A
		public unsafe float Current_Material_Wetness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x17002B30 RID: 11056
		// (get) Token: 0x0601E8D1 RID: 125137 RVA: 0x008F7B7B File Offset: 0x008F5D7B
		// (set) Token: 0x0601E8D2 RID: 125138 RVA: 0x008F7B8B File Offset: 0x008F5D8B
		public unsafe float Current_Material_Snow_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_90);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x17002B31 RID: 11057
		// (get) Token: 0x0601E8D3 RID: 125139 RVA: 0x008F7B9C File Offset: 0x008F5D9C
		// (set) Token: 0x0601E8D4 RID: 125140 RVA: 0x008F7BAC File Offset: 0x008F5DAC
		public unsafe bool Simulate_Changing_Material_Effects_with_Weather
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_91) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_91) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B32 RID: 11058
		// (get) Token: 0x0601E8D5 RID: 125141 RVA: 0x008F7BBD File Offset: 0x008F5DBD
		// (set) Token: 0x0601E8D6 RID: 125142 RVA: 0x008F7BCD File Offset: 0x008F5DCD
		public unsafe float Time_for_Materials_to_Get_Wet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x17002B33 RID: 11059
		// (get) Token: 0x0601E8D7 RID: 125143 RVA: 0x008F7BDE File Offset: 0x008F5DDE
		// (set) Token: 0x0601E8D8 RID: 125144 RVA: 0x008F7BEE File Offset: 0x008F5DEE
		public unsafe float Time_for_Materials_to_Dry_Out
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x17002B34 RID: 11060
		// (get) Token: 0x0601E8D9 RID: 125145 RVA: 0x008F7BFF File Offset: 0x008F5DFF
		// (set) Token: 0x0601E8DA RID: 125146 RVA: 0x008F7C0F File Offset: 0x008F5E0F
		public unsafe float Time_for_Materials_to_Gather_Snow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17002B35 RID: 11061
		// (get) Token: 0x0601E8DB RID: 125147 RVA: 0x008F7C20 File Offset: 0x008F5E20
		// (set) Token: 0x0601E8DC RID: 125148 RVA: 0x008F7C30 File Offset: 0x008F5E30
		public unsafe float Time_for_Snow_to_Melt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x17002B36 RID: 11062
		// (get) Token: 0x0601E8DD RID: 125149 RVA: 0x008F7C41 File Offset: 0x008F5E41
		// (set) Token: 0x0601E8DE RID: 125150 RVA: 0x008F7C51 File Offset: 0x008F5E51
		public unsafe float Snow_Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x17002B37 RID: 11063
		// (get) Token: 0x0601E8DF RID: 125151 RVA: 0x008F7C62 File Offset: 0x008F5E62
		// (set) Token: 0x0601E8E0 RID: 125152 RVA: 0x008F7C72 File Offset: 0x008F5E72
		public unsafe float Amount_of_Snow_to_Turn_to_Wetness_when_Melted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x17002B38 RID: 11064
		// (get) Token: 0x0601E8E1 RID: 125153 RVA: 0x008F7C83 File Offset: 0x008F5E83
		// (set) Token: 0x0601E8E2 RID: 125154 RVA: 0x008F7C93 File Offset: 0x008F5E93
		public unsafe float Random_Cloud_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_98);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_98) = value;
			}
		}

		// Token: 0x17002B39 RID: 11065
		// (get) Token: 0x0601E8E3 RID: 125155 RVA: 0x008F7CA4 File Offset: 0x008F5EA4
		// (set) Token: 0x0601E8E4 RID: 125156 RVA: 0x008F7CB4 File Offset: 0x008F5EB4
		public unsafe float Random_Weather_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_99);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_99) = value;
			}
		}

		// Token: 0x17002B3A RID: 11066
		// (get) Token: 0x0601E8E5 RID: 125157 RVA: 0x008F7CC5 File Offset: 0x008F5EC5
		// (set) Token: 0x0601E8E6 RID: 125158 RVA: 0x008F7CD5 File Offset: 0x008F5ED5
		public unsafe float Random_Wind_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17002B3B RID: 11067
		// (get) Token: 0x0601E8E7 RID: 125159 RVA: 0x008F7CE6 File Offset: 0x008F5EE6
		// (set) Token: 0x0601E8E8 RID: 125160 RVA: 0x008F7CF6 File Offset: 0x008F5EF6
		public unsafe float Random_Rain_or_Snow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17002B3C RID: 11068
		// (get) Token: 0x0601E8E9 RID: 125161 RVA: 0x008F7D07 File Offset: 0x008F5F07
		// (set) Token: 0x0601E8EA RID: 125162 RVA: 0x008F7D1B File Offset: 0x008F5F1B
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_WeatherTypes> Current_Random_Weather_Type
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_102);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17002B3D RID: 11069
		// (get) Token: 0x0601E8EB RID: 125163 RVA: 0x008F7D30 File Offset: 0x008F5F30
		// (set) Token: 0x0601E8EC RID: 125164 RVA: 0x008F7D44 File Offset: 0x008F5F44
		[Nullable(0)]
		public unsafe TEnumAsByte<UDS_Season> Season
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_103);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17002B3E RID: 11070
		// (get) Token: 0x0601E8ED RID: 125165 RVA: 0x008F7D59 File Offset: 0x008F5F59
		// (set) Token: 0x0601E8EE RID: 125166 RVA: 0x008F7D6D File Offset: 0x008F5F6D
		public unsafe FFloatRange Weather_Type_Change_Interval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17002B3F RID: 11071
		// (get) Token: 0x0601E8EF RID: 125167 RVA: 0x008F7D84 File Offset: 0x008F5F84
		// (set) Token: 0x0601E8F0 RID: 125168 RVA: 0x008F7DBD File Offset: 0x008F5FBD
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<UDS_WeatherTypes>, float> Weather_Type_Probabilities__Summer_
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<UDS_WeatherTypes>, float> result;
				if ((result = this._Weather_Type_Probabilities__Summer_) == null)
				{
					result = (this._Weather_Type_Probabilities__Summer_ = new TMap<TEnumAsByte<UDS_WeatherTypes>, float>(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_105, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Weather_Type_Probabilities__Summer_.CopyAssign(value);
			}
		}

		// Token: 0x17002B40 RID: 11072
		// (get) Token: 0x0601E8F1 RID: 125169 RVA: 0x008F7DCC File Offset: 0x008F5FCC
		// (set) Token: 0x0601E8F2 RID: 125170 RVA: 0x008F7E05 File Offset: 0x008F6005
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<UDS_WeatherTypes>, float> Weather_Type_Probabilities__Autumn_
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<UDS_WeatherTypes>, float> result;
				if ((result = this._Weather_Type_Probabilities__Autumn_) == null)
				{
					result = (this._Weather_Type_Probabilities__Autumn_ = new TMap<TEnumAsByte<UDS_WeatherTypes>, float>(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_106, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Weather_Type_Probabilities__Autumn_.CopyAssign(value);
			}
		}

		// Token: 0x17002B41 RID: 11073
		// (get) Token: 0x0601E8F3 RID: 125171 RVA: 0x008F7E14 File Offset: 0x008F6014
		// (set) Token: 0x0601E8F4 RID: 125172 RVA: 0x008F7E4D File Offset: 0x008F604D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<UDS_WeatherTypes>, float> Weather_Type_Probabilities__Winter_
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<UDS_WeatherTypes>, float> result;
				if ((result = this._Weather_Type_Probabilities__Winter_) == null)
				{
					result = (this._Weather_Type_Probabilities__Winter_ = new TMap<TEnumAsByte<UDS_WeatherTypes>, float>(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_107, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Weather_Type_Probabilities__Winter_.CopyAssign(value);
			}
		}

		// Token: 0x17002B42 RID: 11074
		// (get) Token: 0x0601E8F5 RID: 125173 RVA: 0x008F7E5C File Offset: 0x008F605C
		// (set) Token: 0x0601E8F6 RID: 125174 RVA: 0x008F7E95 File Offset: 0x008F6095
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<UDS_WeatherTypes>, float> Weather_Type_Probabilities__Spring_
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<UDS_WeatherTypes>, float> result;
				if ((result = this._Weather_Type_Probabilities__Spring_) == null)
				{
					result = (this._Weather_Type_Probabilities__Spring_ = new TMap<TEnumAsByte<UDS_WeatherTypes>, float>(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_108, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.Weather_Type_Probabilities__Spring_.CopyAssign(value);
			}
		}

		// Token: 0x17002B43 RID: 11075
		// (get) Token: 0x0601E8F7 RID: 125175 RVA: 0x008F7EA3 File Offset: 0x008F60A3
		// (set) Token: 0x0601E8F8 RID: 125176 RVA: 0x008F7EB3 File Offset: 0x008F60B3
		public unsafe bool Avoid_Extreme_Weather_Shifts
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_109) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_109) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B44 RID: 11076
		// (get) Token: 0x0601E8F9 RID: 125177 RVA: 0x008F7EC4 File Offset: 0x008F60C4
		// (set) Token: 0x0601E8FA RID: 125178 RVA: 0x008F7ED4 File Offset: 0x008F60D4
		public unsafe bool Avoid_Repeating_Weather_Types
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_110) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_110) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B45 RID: 11077
		// (get) Token: 0x0601E8FB RID: 125179 RVA: 0x008F7EE5 File Offset: 0x008F60E5
		// (set) Token: 0x0601E8FC RID: 125180 RVA: 0x008F7EF5 File Offset: 0x008F60F5
		public unsafe bool Avoid_Changing_Directly_from_Snow_to_Rain__Or_Vice_Versa_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_111) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_111) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B46 RID: 11078
		// (get) Token: 0x0601E8FD RID: 125181 RVA: 0x008F7F06 File Offset: 0x008F6106
		// (set) Token: 0x0601E8FE RID: 125182 RVA: 0x008F7F16 File Offset: 0x008F6116
		public unsafe float Cloudiness_Change_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_112);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_112) = value;
			}
		}

		// Token: 0x17002B47 RID: 11079
		// (get) Token: 0x0601E8FF RID: 125183 RVA: 0x008F7F27 File Offset: 0x008F6127
		// (set) Token: 0x0601E900 RID: 125184 RVA: 0x008F7F37 File Offset: 0x008F6137
		public unsafe float Weather_Intensity_Change_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_113);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_113) = value;
			}
		}

		// Token: 0x17002B48 RID: 11080
		// (get) Token: 0x0601E901 RID: 125185 RVA: 0x008F7F48 File Offset: 0x008F6148
		// (set) Token: 0x0601E902 RID: 125186 RVA: 0x008F7F58 File Offset: 0x008F6158
		public unsafe float RainorSnow_Change_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_114);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_114) = value;
			}
		}

		// Token: 0x17002B49 RID: 11081
		// (get) Token: 0x0601E903 RID: 125187 RVA: 0x008F7F69 File Offset: 0x008F6169
		// (set) Token: 0x0601E904 RID: 125188 RVA: 0x008F7F79 File Offset: 0x008F6179
		public unsafe float Wind_Intensity_Change_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_115);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_115) = value;
			}
		}

		// Token: 0x17002B4A RID: 11082
		// (get) Token: 0x0601E905 RID: 125189 RVA: 0x008F7F8A File Offset: 0x008F618A
		// (set) Token: 0x0601E906 RID: 125190 RVA: 0x008F7F9A File Offset: 0x008F619A
		public unsafe float Change_Speed_Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x17002B4B RID: 11083
		// (get) Token: 0x0601E907 RID: 125191 RVA: 0x008F7FAB File Offset: 0x008F61AB
		// (set) Token: 0x0601E908 RID: 125192 RVA: 0x008F7FBB File Offset: 0x008F61BB
		public unsafe bool Use_Sound_Effects
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_117) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_117) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B4C RID: 11084
		// (get) Token: 0x0601E909 RID: 125193 RVA: 0x008F7FCC File Offset: 0x008F61CC
		// (set) Token: 0x0601E90A RID: 125194 RVA: 0x008F7FDC File Offset: 0x008F61DC
		public unsafe float Rain_Volume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_118);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_118) = value;
			}
		}

		// Token: 0x17002B4D RID: 11085
		// (get) Token: 0x0601E90B RID: 125195 RVA: 0x008F7FED File Offset: 0x008F61ED
		// (set) Token: 0x0601E90C RID: 125196 RVA: 0x008F8001 File Offset: 0x008F6201
		public unsafe UCurveFloat Rain_Fade_Curve
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_119);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Ultra_Dynamic_Weather_C.__PropertyOffset_119, value);
			}
		}

		// Token: 0x17002B4E RID: 11086
		// (get) Token: 0x0601E90D RID: 125197 RVA: 0x008F8016 File Offset: 0x008F6216
		// (set) Token: 0x0601E90E RID: 125198 RVA: 0x008F8026 File Offset: 0x008F6226
		public unsafe float Distant_Thunder_Volume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_120);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_120) = value;
			}
		}

		// Token: 0x17002B4F RID: 11087
		// (get) Token: 0x0601E90F RID: 125199 RVA: 0x008F8037 File Offset: 0x008F6237
		// (set) Token: 0x0601E910 RID: 125200 RVA: 0x008F8047 File Offset: 0x008F6247
		public unsafe float Close_Thunder_Volume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_121);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_121) = value;
			}
		}

		// Token: 0x17002B50 RID: 11088
		// (get) Token: 0x0601E911 RID: 125201 RVA: 0x008F8058 File Offset: 0x008F6258
		// (set) Token: 0x0601E912 RID: 125202 RVA: 0x008F8068 File Offset: 0x008F6268
		public unsafe float Max_Cloud_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_122);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_122) = value;
			}
		}

		// Token: 0x17002B51 RID: 11089
		// (get) Token: 0x0601E913 RID: 125203 RVA: 0x008F8079 File Offset: 0x008F6279
		// (set) Token: 0x0601E914 RID: 125204 RVA: 0x008F8089 File Offset: 0x008F6289
		public unsafe float Wind_Volume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_123);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_123) = value;
			}
		}

		// Token: 0x17002B52 RID: 11090
		// (get) Token: 0x0601E915 RID: 125205 RVA: 0x008F809A File Offset: 0x008F629A
		// (set) Token: 0x0601E916 RID: 125206 RVA: 0x008F80AA File Offset: 0x008F62AA
		public unsafe float Wind_Whistling_Volume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_124);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_124) = value;
			}
		}

		// Token: 0x17002B53 RID: 11091
		// (get) Token: 0x0601E917 RID: 125207 RVA: 0x008F80BB File Offset: 0x008F62BB
		// (set) Token: 0x0601E918 RID: 125208 RVA: 0x008F80CB File Offset: 0x008F62CB
		public unsafe bool Resetting_Particle_Emitters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_125) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_125) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B54 RID: 11092
		// (get) Token: 0x0601E919 RID: 125209 RVA: 0x008F80DC File Offset: 0x008F62DC
		// (set) Token: 0x0601E91A RID: 125210 RVA: 0x008F80EC File Offset: 0x008F62EC
		public unsafe float Intended_Cloud_Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_126);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_126) = value;
			}
		}

		// Token: 0x17002B55 RID: 11093
		// (get) Token: 0x0601E91B RID: 125211 RVA: 0x008F80FD File Offset: 0x008F62FD
		// (set) Token: 0x0601E91C RID: 125212 RVA: 0x008F810D File Offset: 0x008F630D
		public unsafe float Intended_Cloud_Coverage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_127);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_127) = value;
			}
		}

		// Token: 0x17002B56 RID: 11094
		// (get) Token: 0x0601E91D RID: 125213 RVA: 0x008F811E File Offset: 0x008F631E
		// (set) Token: 0x0601E91E RID: 125214 RVA: 0x008F812E File Offset: 0x008F632E
		public unsafe float Intended_Cloud_Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_128);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_128) = value;
			}
		}

		// Token: 0x17002B57 RID: 11095
		// (get) Token: 0x0601E91F RID: 125215 RVA: 0x008F813F File Offset: 0x008F633F
		// (set) Token: 0x0601E920 RID: 125216 RVA: 0x008F814F File Offset: 0x008F634F
		public unsafe float Cloud_Speed_Multiplier
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_129);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_129) = value;
			}
		}

		// Token: 0x17002B58 RID: 11096
		// (get) Token: 0x0601E921 RID: 125217 RVA: 0x008F8160 File Offset: 0x008F6360
		// (set) Token: 0x0601E922 RID: 125218 RVA: 0x008F8170 File Offset: 0x008F6370
		public unsafe bool Runtime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_130) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_130) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B59 RID: 11097
		// (get) Token: 0x0601E923 RID: 125219 RVA: 0x008F8181 File Offset: 0x008F6381
		// (set) Token: 0x0601E924 RID: 125220 RVA: 0x008F8191 File Offset: 0x008F6391
		public unsafe float Lightning_Flash_Angle_Range
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_131);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_131) = value;
			}
		}

		// Token: 0x17002B5A RID: 11098
		// (get) Token: 0x0601E925 RID: 125221 RVA: 0x008F81A2 File Offset: 0x008F63A2
		// (set) Token: 0x0601E926 RID: 125222 RVA: 0x008F81B2 File Offset: 0x008F63B2
		public unsafe float Fog_Particle_Camera_Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_132);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Ultra_Dynamic_Weather_C.__PropertyOffset_132) = value;
			}
		}

		// Token: 0x0601E927 RID: 125223 RVA: 0x008F81C4 File Offset: 0x008F63C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Filter_Probability_Map([Nullable(new byte[]
		{
			2,
			0
		})] TMap<TEnumAsByte<UDS_WeatherTypes>, float> Probability_Map, [Nullable(new byte[]
		{
			2,
			0
		})] ref TMap<TEnumAsByte<UDS_WeatherTypes>, float> Filtered_Probability_Map)
		{
			Ultra_Dynamic_Weather_C.__Filter_Probability_Map_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__Filter_Probability_Map_FunctionParams[(UIntPtr)719] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__Filter_Probability_Map_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__Filter_Probability_Map_NativeFunctionPtr, (void*)ptr, 1);
			if (Probability_Map != null)
			{
				Probability_Map.CopyTo(&ptr->Probability_Map, default(UScriptStructStackOnlyPtr));
			}
			TMap<TEnumAsByte<UDS_WeatherTypes>, float> tmap = Filtered_Probability_Map;
			if (tmap != null)
			{
				tmap.MoveTo(&ptr->Filtered_Probability_Map);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Filter_Probability_Map_NativeFunctionPtr, (void*)ptr);
			TMap<TEnumAsByte<UDS_WeatherTypes>, float> tmap2 = Filtered_Probability_Map;
			if (tmap2 != null)
			{
				tmap2.MoveAssign(&ptr->Filtered_Probability_Map);
			}
			UnrealReflectionUtils.DestroyStruct(Ultra_Dynamic_Weather_C.__Filter_Probability_Map_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E928 RID: 125224 RVA: 0x008F8258 File Offset: 0x008F6458
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ConstructionScript_Function(bool Run_By_Counterpart)
		{
			Ultra_Dynamic_Weather_C.__ConstructionScript_Function_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__ConstructionScript_Function_FunctionParams[(UIntPtr)119] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__ConstructionScript_Function_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__ConstructionScript_Function_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Run_By_Counterpart = Run_By_Counterpart;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__ConstructionScript_Function_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E929 RID: 125225 RVA: 0x008F829E File Offset: 0x008F649E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Audio_Update()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Audio_Update_NativeFunctionPtr, null);
		}

		// Token: 0x0601E92A RID: 125226 RVA: 0x008F82B4 File Offset: 0x008F64B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Select_New_Random_Weather_Type(bool Filter_Probability_List)
		{
			Ultra_Dynamic_Weather_C.__Select_New_Random_Weather_Type_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__Select_New_Random_Weather_Type_FunctionParams[(UIntPtr)735] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__Select_New_Random_Weather_Type_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__Select_New_Random_Weather_Type_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Filter_Probability_List = Filter_Probability_List;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Select_New_Random_Weather_Type_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E92B RID: 125227 RVA: 0x008F82FD File Offset: 0x008F64FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Increment_Random_Weather()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Increment_Random_Weather_NativeFunctionPtr, null);
		}

		// Token: 0x0601E92C RID: 125228 RVA: 0x008F8311 File Offset: 0x008F6511
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Material_Effects()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Set_Material_Effects_NativeFunctionPtr, null);
		}

		// Token: 0x0601E92D RID: 125229 RVA: 0x008F8328 File Offset: 0x008F6528
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Get_Current_Weather_Type(ref UDS_WeatherTypes Current_Weather_Type)
		{
			Ultra_Dynamic_Weather_C.__Get_Current_Weather_Type_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__Get_Current_Weather_Type_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__Get_Current_Weather_Type_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__Get_Current_Weather_Type_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Current_Weather_Type = Current_Weather_Type;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Get_Current_Weather_Type_NativeFunctionPtr, (void*)ptr);
			Current_Weather_Type = ptr->Current_Weather_Type;
		}

		// Token: 0x0601E92E RID: 125230 RVA: 0x008F8381 File Offset: 0x008F6581
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Apply_Weather_Preset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Apply_Weather_Preset_NativeFunctionPtr, null);
		}

		// Token: 0x0601E92F RID: 125231 RVA: 0x008F8395 File Offset: 0x008F6595
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Print_Current_Status_To_Screen()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Print_Current_Status_To_Screen_NativeFunctionPtr, null);
		}

		// Token: 0x0601E930 RID: 125232 RVA: 0x008F83A9 File Offset: 0x008F65A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Static_Variables()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Update_Static_Variables_NativeFunctionPtr, null);
		}

		// Token: 0x0601E931 RID: 125233 RVA: 0x008F83BD File Offset: 0x008F65BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Update_Active_Variables()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Update_Active_Variables_NativeFunctionPtr, null);
		}

		// Token: 0x0601E932 RID: 125234 RVA: 0x008F83D1 File Offset: 0x008F65D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E933 RID: 125235 RVA: 0x008F83E5 File Offset: 0x008F65E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E934 RID: 125236 RVA: 0x008F83FA File Offset: 0x008F65FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Lightning_Strength__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Lightning_Strength__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601E935 RID: 125237 RVA: 0x008F840E File Offset: 0x008F660E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Lightning_Strength__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Lightning_Strength__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0601E936 RID: 125238 RVA: 0x008F8422 File Offset: 0x008F6622
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Flash_Lightning()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Flash_Lightning_NativeFunctionPtr, null);
		}

		// Token: 0x0601E937 RID: 125239 RVA: 0x008F8438 File Offset: 0x008F6638
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			Ultra_Dynamic_Weather_C.__ReceiveTick_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E938 RID: 125240 RVA: 0x008F8480 File Offset: 0x008F6680
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			Ultra_Dynamic_Weather_C.__ReceiveTick_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E939 RID: 125241 RVA: 0x008F84C7 File Offset: 0x008F66C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Force_Tick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Force_Tick_NativeFunctionPtr, null);
		}

		// Token: 0x0601E93A RID: 125242 RVA: 0x008F84DB File Offset: 0x008F66DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E93B RID: 125243 RVA: 0x008F84EF File Offset: 0x008F66EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E93C RID: 125244 RVA: 0x008F8504 File Offset: 0x008F6704
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Change_Weather_Using_Settings(float Weather_Intensity, float Cloudiness, float Wind_Intensity, float Rain___Snow, float Time_To_Transition_To_New_Settings, float Time_to_Hold_New_Settings, float Time_to_Transition_Back_to_Random_Variation, bool Reset_Particle_Emitters)
		{
			Ultra_Dynamic_Weather_C.__Change_Weather_Using_Settings_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__Change_Weather_Using_Settings_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__Change_Weather_Using_Settings_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__Change_Weather_Using_Settings_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Weather_Intensity = Weather_Intensity;
			ptr->Cloudiness = Cloudiness;
			ptr->Wind_Intensity = Wind_Intensity;
			ptr->Rain___Snow = Rain___Snow;
			ptr->Time_To_Transition_To_New_Settings = Time_To_Transition_To_New_Settings;
			ptr->Time_to_Hold_New_Settings = Time_to_Hold_New_Settings;
			ptr->Time_to_Transition_Back_to_Random_Variation = Time_to_Transition_Back_to_Random_Variation;
			ptr->Reset_Particle_Emitters = Reset_Particle_Emitters;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Change_Weather_Using_Settings_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E93D RID: 125245 RVA: 0x008F8580 File Offset: 0x008F6780
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Change_Weather_Using_Type(UDS_WeatherTypes New_Weather_Type, float Time_To_Transition_To_New_Settings, float Time_to_Hold_New_Settings, float Time_to_Transition_Back_to_Random_Variation, bool Reset_Particle_Emitters)
		{
			Ultra_Dynamic_Weather_C.__Change_Weather_Using_Type_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__Change_Weather_Using_Type_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__Change_Weather_Using_Type_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__Change_Weather_Using_Type_NativeFunctionPtr, (void*)ptr, 1);
			ptr->New_Weather_Type = New_Weather_Type;
			ptr->Time_To_Transition_To_New_Settings = Time_To_Transition_To_New_Settings;
			ptr->Time_to_Hold_New_Settings = Time_to_Hold_New_Settings;
			ptr->Time_to_Transition_Back_to_Random_Variation = Time_to_Transition_Back_to_Random_Variation;
			ptr->Reset_Particle_Emitters = Reset_Particle_Emitters;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__Change_Weather_Using_Type_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E93E RID: 125246 RVA: 0x008F85EC File Offset: 0x008F67EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_Ultra_Dynamic_Weather(int EntryPoint)
		{
			Ultra_Dynamic_Weather_C.__ExecuteUbergraph_Ultra_Dynamic_Weather_FunctionParams* ptr = stackalloc Ultra_Dynamic_Weather_C.__ExecuteUbergraph_Ultra_Dynamic_Weather_FunctionParams[(UIntPtr)1911] + 15L / (long)sizeof(Ultra_Dynamic_Weather_C.__ExecuteUbergraph_Ultra_Dynamic_Weather_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(Ultra_Dynamic_Weather_C.__ExecuteUbergraph_Ultra_Dynamic_Weather_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, Ultra_Dynamic_Weather_C.__ExecuteUbergraph_Ultra_Dynamic_Weather_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E93F RID: 125247 RVA: 0x008F8636 File Offset: 0x008F6836
		protected Ultra_Dynamic_Weather_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F043 RID: 61507
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Ultra_Dynamic_Weather.Ultra_Dynamic_Weather_C";

		// Token: 0x0400F044 RID: 61508
		private static IntPtr _ClassPtr;

		// Token: 0x0400F045 RID: 61509
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F046 RID: 61510
		internal static int __PropertyOffset_0;

		// Token: 0x0400F047 RID: 61511
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F048 RID: 61512
		internal static int __PropertyOffset_1;

		// Token: 0x0400F049 RID: 61513
		internal static int __PropertyOffset_2;

		// Token: 0x0400F04A RID: 61514
		internal static int __PropertyOffset_3;

		// Token: 0x0400F04B RID: 61515
		internal static int __PropertyOffset_4;

		// Token: 0x0400F04C RID: 61516
		internal static int __PropertyOffset_5;

		// Token: 0x0400F04D RID: 61517
		internal static int __PropertyOffset_6;

		// Token: 0x0400F04E RID: 61518
		internal static int __PropertyOffset_7;

		// Token: 0x0400F04F RID: 61519
		internal static int __PropertyOffset_8;

		// Token: 0x0400F050 RID: 61520
		internal static int __PropertyOffset_9;

		// Token: 0x0400F051 RID: 61521
		internal static int __PropertyOffset_10;

		// Token: 0x0400F052 RID: 61522
		internal static int __PropertyOffset_11;

		// Token: 0x0400F053 RID: 61523
		internal static int __PropertyOffset_12;

		// Token: 0x0400F054 RID: 61524
		internal static int __PropertyOffset_13;

		// Token: 0x0400F055 RID: 61525
		internal static int __PropertyOffset_14;

		// Token: 0x0400F056 RID: 61526
		internal static int __PropertyOffset_15;

		// Token: 0x0400F057 RID: 61527
		internal static int __PropertyOffset_16;

		// Token: 0x0400F058 RID: 61528
		internal static int __PropertyOffset_17;

		// Token: 0x0400F059 RID: 61529
		internal static int __PropertyOffset_18;

		// Token: 0x0400F05A RID: 61530
		internal static int __PropertyOffset_19;

		// Token: 0x0400F05B RID: 61531
		internal static int __PropertyOffset_20;

		// Token: 0x0400F05C RID: 61532
		internal static int __PropertyOffset_21;

		// Token: 0x0400F05D RID: 61533
		internal static int __PropertyOffset_22;

		// Token: 0x0400F05E RID: 61534
		internal static int __PropertyOffset_23;

		// Token: 0x0400F05F RID: 61535
		internal static int __PropertyOffset_24;

		// Token: 0x0400F060 RID: 61536
		internal static int __PropertyOffset_25;

		// Token: 0x0400F061 RID: 61537
		internal static int __PropertyOffset_26;

		// Token: 0x0400F062 RID: 61538
		internal static int __PropertyOffset_27;

		// Token: 0x0400F063 RID: 61539
		internal static int __PropertyOffset_28;

		// Token: 0x0400F064 RID: 61540
		internal static int __PropertyOffset_29;

		// Token: 0x0400F065 RID: 61541
		internal static int __PropertyOffset_30;

		// Token: 0x0400F066 RID: 61542
		internal static int __PropertyOffset_31;

		// Token: 0x0400F067 RID: 61543
		internal static int __PropertyOffset_32;

		// Token: 0x0400F068 RID: 61544
		internal static int __PropertyOffset_33;

		// Token: 0x0400F069 RID: 61545
		internal static int __PropertyOffset_34;

		// Token: 0x0400F06A RID: 61546
		internal static int __PropertyOffset_35;

		// Token: 0x0400F06B RID: 61547
		internal static int __PropertyOffset_36;

		// Token: 0x0400F06C RID: 61548
		internal static int __PropertyOffset_37;

		// Token: 0x0400F06D RID: 61549
		internal static int __PropertyOffset_38;

		// Token: 0x0400F06E RID: 61550
		internal static int __PropertyOffset_39;

		// Token: 0x0400F06F RID: 61551
		internal static int __PropertyOffset_40;

		// Token: 0x0400F070 RID: 61552
		internal static int __PropertyOffset_41;

		// Token: 0x0400F071 RID: 61553
		internal static int __PropertyOffset_42;

		// Token: 0x0400F072 RID: 61554
		internal static int __PropertyOffset_43;

		// Token: 0x0400F073 RID: 61555
		internal static int __PropertyOffset_44;

		// Token: 0x0400F074 RID: 61556
		internal static int __PropertyOffset_45;

		// Token: 0x0400F075 RID: 61557
		internal static int __PropertyOffset_46;

		// Token: 0x0400F076 RID: 61558
		internal static int __PropertyOffset_47;

		// Token: 0x0400F077 RID: 61559
		internal static int __PropertyOffset_48;

		// Token: 0x0400F078 RID: 61560
		internal static int __PropertyOffset_49;

		// Token: 0x0400F079 RID: 61561
		internal static int __PropertyOffset_50;

		// Token: 0x0400F07A RID: 61562
		internal static int __PropertyOffset_51;

		// Token: 0x0400F07B RID: 61563
		internal static int __PropertyOffset_52;

		// Token: 0x0400F07C RID: 61564
		internal static int __PropertyOffset_53;

		// Token: 0x0400F07D RID: 61565
		internal static int __PropertyOffset_54;

		// Token: 0x0400F07E RID: 61566
		internal static int __PropertyOffset_55;

		// Token: 0x0400F07F RID: 61567
		internal static int __PropertyOffset_56;

		// Token: 0x0400F080 RID: 61568
		internal static int __PropertyOffset_57;

		// Token: 0x0400F081 RID: 61569
		internal static int __PropertyOffset_58;

		// Token: 0x0400F082 RID: 61570
		internal static int __PropertyOffset_59;

		// Token: 0x0400F083 RID: 61571
		internal static int __PropertyOffset_60;

		// Token: 0x0400F084 RID: 61572
		internal static int __PropertyOffset_61;

		// Token: 0x0400F085 RID: 61573
		internal static int __PropertyOffset_62;

		// Token: 0x0400F086 RID: 61574
		internal static int __PropertyOffset_63;

		// Token: 0x0400F087 RID: 61575
		internal static int __PropertyOffset_64;

		// Token: 0x0400F088 RID: 61576
		internal static int __PropertyOffset_65;

		// Token: 0x0400F089 RID: 61577
		internal static int __PropertyOffset_66;

		// Token: 0x0400F08A RID: 61578
		internal static int __PropertyOffset_67;

		// Token: 0x0400F08B RID: 61579
		internal static int __PropertyOffset_68;

		// Token: 0x0400F08C RID: 61580
		internal static int __PropertyOffset_69;

		// Token: 0x0400F08D RID: 61581
		internal static int __PropertyOffset_70;

		// Token: 0x0400F08E RID: 61582
		internal static int __PropertyOffset_71;

		// Token: 0x0400F08F RID: 61583
		internal static int __PropertyOffset_72;

		// Token: 0x0400F090 RID: 61584
		internal static int __PropertyOffset_73;

		// Token: 0x0400F091 RID: 61585
		internal static int __PropertyOffset_74;

		// Token: 0x0400F092 RID: 61586
		internal static int __PropertyOffset_75;

		// Token: 0x0400F093 RID: 61587
		internal static int __PropertyOffset_76;

		// Token: 0x0400F094 RID: 61588
		internal static int __PropertyOffset_77;

		// Token: 0x0400F095 RID: 61589
		internal static int __PropertyOffset_78;

		// Token: 0x0400F096 RID: 61590
		internal static int __PropertyOffset_79;

		// Token: 0x0400F097 RID: 61591
		internal static int __PropertyOffset_80;

		// Token: 0x0400F098 RID: 61592
		internal static int __PropertyOffset_81;

		// Token: 0x0400F099 RID: 61593
		internal static int __PropertyOffset_82;

		// Token: 0x0400F09A RID: 61594
		internal static int __PropertyOffset_83;

		// Token: 0x0400F09B RID: 61595
		internal static int __PropertyOffset_84;

		// Token: 0x0400F09C RID: 61596
		internal static int __PropertyOffset_85;

		// Token: 0x0400F09D RID: 61597
		internal static int __PropertyOffset_86;

		// Token: 0x0400F09E RID: 61598
		internal static int __PropertyOffset_87;

		// Token: 0x0400F09F RID: 61599
		internal static int __PropertyOffset_88;

		// Token: 0x0400F0A0 RID: 61600
		internal static int __PropertyOffset_89;

		// Token: 0x0400F0A1 RID: 61601
		internal static int __PropertyOffset_90;

		// Token: 0x0400F0A2 RID: 61602
		internal static int __PropertyOffset_91;

		// Token: 0x0400F0A3 RID: 61603
		internal static int __PropertyOffset_92;

		// Token: 0x0400F0A4 RID: 61604
		internal static int __PropertyOffset_93;

		// Token: 0x0400F0A5 RID: 61605
		internal static int __PropertyOffset_94;

		// Token: 0x0400F0A6 RID: 61606
		internal static int __PropertyOffset_95;

		// Token: 0x0400F0A7 RID: 61607
		internal static int __PropertyOffset_96;

		// Token: 0x0400F0A8 RID: 61608
		internal static int __PropertyOffset_97;

		// Token: 0x0400F0A9 RID: 61609
		internal static int __PropertyOffset_98;

		// Token: 0x0400F0AA RID: 61610
		internal static int __PropertyOffset_99;

		// Token: 0x0400F0AB RID: 61611
		internal static int __PropertyOffset_100;

		// Token: 0x0400F0AC RID: 61612
		internal static int __PropertyOffset_101;

		// Token: 0x0400F0AD RID: 61613
		internal static int __PropertyOffset_102;

		// Token: 0x0400F0AE RID: 61614
		internal static int __PropertyOffset_103;

		// Token: 0x0400F0AF RID: 61615
		internal static int __PropertyOffset_104;

		// Token: 0x0400F0B0 RID: 61616
		internal static int __PropertyOffset_105;

		// Token: 0x0400F0B1 RID: 61617
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<UDS_WeatherTypes>, float> _Weather_Type_Probabilities__Summer_;

		// Token: 0x0400F0B2 RID: 61618
		internal static int __PropertyOffset_106;

		// Token: 0x0400F0B3 RID: 61619
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<UDS_WeatherTypes>, float> _Weather_Type_Probabilities__Autumn_;

		// Token: 0x0400F0B4 RID: 61620
		internal static int __PropertyOffset_107;

		// Token: 0x0400F0B5 RID: 61621
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<UDS_WeatherTypes>, float> _Weather_Type_Probabilities__Winter_;

		// Token: 0x0400F0B6 RID: 61622
		internal static int __PropertyOffset_108;

		// Token: 0x0400F0B7 RID: 61623
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<UDS_WeatherTypes>, float> _Weather_Type_Probabilities__Spring_;

		// Token: 0x0400F0B8 RID: 61624
		internal static int __PropertyOffset_109;

		// Token: 0x0400F0B9 RID: 61625
		internal static int __PropertyOffset_110;

		// Token: 0x0400F0BA RID: 61626
		internal static int __PropertyOffset_111;

		// Token: 0x0400F0BB RID: 61627
		internal static int __PropertyOffset_112;

		// Token: 0x0400F0BC RID: 61628
		internal static int __PropertyOffset_113;

		// Token: 0x0400F0BD RID: 61629
		internal static int __PropertyOffset_114;

		// Token: 0x0400F0BE RID: 61630
		internal static int __PropertyOffset_115;

		// Token: 0x0400F0BF RID: 61631
		internal static int __PropertyOffset_116;

		// Token: 0x0400F0C0 RID: 61632
		internal static int __PropertyOffset_117;

		// Token: 0x0400F0C1 RID: 61633
		internal static int __PropertyOffset_118;

		// Token: 0x0400F0C2 RID: 61634
		internal static int __PropertyOffset_119;

		// Token: 0x0400F0C3 RID: 61635
		internal static int __PropertyOffset_120;

		// Token: 0x0400F0C4 RID: 61636
		internal static int __PropertyOffset_121;

		// Token: 0x0400F0C5 RID: 61637
		internal static int __PropertyOffset_122;

		// Token: 0x0400F0C6 RID: 61638
		internal static int __PropertyOffset_123;

		// Token: 0x0400F0C7 RID: 61639
		internal static int __PropertyOffset_124;

		// Token: 0x0400F0C8 RID: 61640
		internal static int __PropertyOffset_125;

		// Token: 0x0400F0C9 RID: 61641
		internal static int __PropertyOffset_126;

		// Token: 0x0400F0CA RID: 61642
		internal static int __PropertyOffset_127;

		// Token: 0x0400F0CB RID: 61643
		internal static int __PropertyOffset_128;

		// Token: 0x0400F0CC RID: 61644
		internal static int __PropertyOffset_129;

		// Token: 0x0400F0CD RID: 61645
		internal static int __PropertyOffset_130;

		// Token: 0x0400F0CE RID: 61646
		internal static int __PropertyOffset_131;

		// Token: 0x0400F0CF RID: 61647
		internal static int __PropertyOffset_132;

		// Token: 0x0400F0D0 RID: 61648
		private static IntPtr __Filter_Probability_Map_NativeFunctionPtr;

		// Token: 0x0400F0D1 RID: 61649
		private static IntPtr __ConstructionScript_Function_NativeFunctionPtr;

		// Token: 0x0400F0D2 RID: 61650
		private static IntPtr __Audio_Update_NativeFunctionPtr;

		// Token: 0x0400F0D3 RID: 61651
		private static IntPtr __Select_New_Random_Weather_Type_NativeFunctionPtr;

		// Token: 0x0400F0D4 RID: 61652
		private static IntPtr __Increment_Random_Weather_NativeFunctionPtr;

		// Token: 0x0400F0D5 RID: 61653
		private static IntPtr __Set_Material_Effects_NativeFunctionPtr;

		// Token: 0x0400F0D6 RID: 61654
		private static IntPtr __Get_Current_Weather_Type_NativeFunctionPtr;

		// Token: 0x0400F0D7 RID: 61655
		private static IntPtr __Apply_Weather_Preset_NativeFunctionPtr;

		// Token: 0x0400F0D8 RID: 61656
		private static IntPtr __Print_Current_Status_To_Screen_NativeFunctionPtr;

		// Token: 0x0400F0D9 RID: 61657
		private static IntPtr __Update_Static_Variables_NativeFunctionPtr;

		// Token: 0x0400F0DA RID: 61658
		private static IntPtr __Update_Active_Variables_NativeFunctionPtr;

		// Token: 0x0400F0DB RID: 61659
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F0DC RID: 61660
		private static IntPtr __Lightning_Strength__FinishedFunc_NativeFunctionPtr;

		// Token: 0x0400F0DD RID: 61661
		private static IntPtr __Lightning_Strength__UpdateFunc_NativeFunctionPtr;

		// Token: 0x0400F0DE RID: 61662
		private static IntPtr __Flash_Lightning_NativeFunctionPtr;

		// Token: 0x0400F0DF RID: 61663
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F0E0 RID: 61664
		private static IntPtr __Force_Tick_NativeFunctionPtr;

		// Token: 0x0400F0E1 RID: 61665
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F0E2 RID: 61666
		private static IntPtr __Change_Weather_Using_Settings_NativeFunctionPtr;

		// Token: 0x0400F0E3 RID: 61667
		private static IntPtr __Change_Weather_Using_Type_NativeFunctionPtr;

		// Token: 0x0400F0E4 RID: 61668
		private static IntPtr __ExecuteUbergraph_Ultra_Dynamic_Weather_NativeFunctionPtr;

		// Token: 0x020097BA RID: 38842
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 704)]
		protected ref struct __Filter_Probability_Map_FunctionParams
		{
			// Token: 0x04031D93 RID: 204179
			[FieldOffset(0)]
			public byte Probability_Map;

			// Token: 0x04031D94 RID: 204180
			[FieldOffset(80)]
			public byte Filtered_Probability_Map;
		}

		// Token: 0x020097BB RID: 38843
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 104)]
		protected ref struct __ConstructionScript_Function_FunctionParams
		{
			// Token: 0x04031D95 RID: 204181
			[FieldOffset(0)]
			public bool Run_By_Counterpart;
		}

		// Token: 0x020097BC RID: 38844
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 720)]
		protected ref struct __Select_New_Random_Weather_Type_FunctionParams
		{
			// Token: 0x04031D96 RID: 204182
			[FieldOffset(0)]
			public bool Filter_Probability_List;
		}

		// Token: 0x020097BD RID: 38845
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected ref struct __Get_Current_Weather_Type_FunctionParams
		{
			// Token: 0x04031D97 RID: 204183
			[FieldOffset(0)]
			public TEnumAsByte<UDS_WeatherTypes> Current_Weather_Type;
		}

		// Token: 0x020097BE RID: 38846
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031D98 RID: 204184
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097BF RID: 38847
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __Change_Weather_Using_Settings_FunctionParams
		{
			// Token: 0x04031D99 RID: 204185
			[FieldOffset(0)]
			public float Weather_Intensity;

			// Token: 0x04031D9A RID: 204186
			[FieldOffset(4)]
			public float Cloudiness;

			// Token: 0x04031D9B RID: 204187
			[FieldOffset(8)]
			public float Wind_Intensity;

			// Token: 0x04031D9C RID: 204188
			[FieldOffset(12)]
			public float Rain___Snow;

			// Token: 0x04031D9D RID: 204189
			[FieldOffset(16)]
			public float Time_To_Transition_To_New_Settings;

			// Token: 0x04031D9E RID: 204190
			[FieldOffset(20)]
			public float Time_to_Hold_New_Settings;

			// Token: 0x04031D9F RID: 204191
			[FieldOffset(24)]
			public float Time_to_Transition_Back_to_Random_Variation;

			// Token: 0x04031DA0 RID: 204192
			[FieldOffset(28)]
			public bool Reset_Particle_Emitters;
		}

		// Token: 0x020097C0 RID: 38848
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __Change_Weather_Using_Type_FunctionParams
		{
			// Token: 0x04031DA1 RID: 204193
			[FieldOffset(0)]
			public TEnumAsByte<UDS_WeatherTypes> New_Weather_Type;

			// Token: 0x04031DA2 RID: 204194
			[FieldOffset(4)]
			public float Time_To_Transition_To_New_Settings;

			// Token: 0x04031DA3 RID: 204195
			[FieldOffset(8)]
			public float Time_to_Hold_New_Settings;

			// Token: 0x04031DA4 RID: 204196
			[FieldOffset(12)]
			public float Time_to_Transition_Back_to_Random_Variation;

			// Token: 0x04031DA5 RID: 204197
			[FieldOffset(16)]
			public bool Reset_Particle_Emitters;
		}

		// Token: 0x020097C1 RID: 38849
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1896)]
		protected ref struct __ExecuteUbergraph_Ultra_Dynamic_Weather_FunctionParams
		{
			// Token: 0x04031DA6 RID: 204198
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
