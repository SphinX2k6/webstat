using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.BadSignalEffect
{
	// Token: 0x02003D98 RID: 15768
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/BadSignalEffect/PDA_BadSignalParameters.PDA_BadSignalParameters_C")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 240)]
	public class PDA_BadSignalParameters_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026873 RID: 157811 RVA: 0x009DB00F File Offset: 0x009D920F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_BadSignalParameters_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/BadSignalEffect/PDA_BadSignalParameters.PDA_BadSignalParameters_C");
			}
			return PDA_BadSignalParameters_C._ClassPtr;
		}

		// Token: 0x06026874 RID: 157812 RVA: 0x009DB034 File Offset: 0x009D9234
		public PDA_BadSignalParameters_C() : this(BuiltinUtils.AllocNativeUObject(PDA_BadSignalParameters_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026875 RID: 157813 RVA: 0x009DB05C File Offset: 0x009D925C
		[NullableContext(1)]
		public PDA_BadSignalParameters_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_BadSignalParameters_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057C8 RID: 22472
		// (get) Token: 0x06026876 RID: 157814 RVA: 0x009DB08F File Offset: 0x009D928F
		// (set) Token: 0x06026877 RID: 157815 RVA: 0x009DB09F File Offset: 0x009D929F
		public unsafe float SignalBiasStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170057C9 RID: 22473
		// (get) Token: 0x06026878 RID: 157816 RVA: 0x009DB0B0 File Offset: 0x009D92B0
		// (set) Token: 0x06026879 RID: 157817 RVA: 0x009DB0C0 File Offset: 0x009D92C0
		public unsafe float SignalBiasDirectionRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170057CA RID: 22474
		// (get) Token: 0x0602687A RID: 157818 RVA: 0x009DB0D1 File Offset: 0x009D92D1
		// (set) Token: 0x0602687B RID: 157819 RVA: 0x009DB0E1 File Offset: 0x009D92E1
		public unsafe float SignalBiasStrengthWiggle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170057CB RID: 22475
		// (get) Token: 0x0602687C RID: 157820 RVA: 0x009DB0F2 File Offset: 0x009D92F2
		// (set) Token: 0x0602687D RID: 157821 RVA: 0x009DB102 File Offset: 0x009D9302
		public unsafe float SignalBiasStrengthWiggleRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170057CC RID: 22476
		// (get) Token: 0x0602687E RID: 157822 RVA: 0x009DB113 File Offset: 0x009D9313
		// (set) Token: 0x0602687F RID: 157823 RVA: 0x009DB123 File Offset: 0x009D9323
		public unsafe float SignalBiasSubWiggle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170057CD RID: 22477
		// (get) Token: 0x06026880 RID: 157824 RVA: 0x009DB134 File Offset: 0x009D9334
		// (set) Token: 0x06026881 RID: 157825 RVA: 0x009DB144 File Offset: 0x009D9344
		public unsafe float SignalExplodeRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170057CE RID: 22478
		// (get) Token: 0x06026882 RID: 157826 RVA: 0x009DB155 File Offset: 0x009D9355
		// (set) Token: 0x06026883 RID: 157827 RVA: 0x009DB165 File Offset: 0x009D9365
		public unsafe float SignalExplodeHoldMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170057CF RID: 22479
		// (get) Token: 0x06026884 RID: 157828 RVA: 0x009DB176 File Offset: 0x009D9376
		// (set) Token: 0x06026885 RID: 157829 RVA: 0x009DB186 File Offset: 0x009D9386
		public unsafe float SignalExplodeHoldMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170057D0 RID: 22480
		// (get) Token: 0x06026886 RID: 157830 RVA: 0x009DB197 File Offset: 0x009D9397
		// (set) Token: 0x06026887 RID: 157831 RVA: 0x009DB1A7 File Offset: 0x009D93A7
		public unsafe float SignalBiasExplodeStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170057D1 RID: 22481
		// (get) Token: 0x06026888 RID: 157832 RVA: 0x009DB1B8 File Offset: 0x009D93B8
		// (set) Token: 0x06026889 RID: 157833 RVA: 0x009DB1C8 File Offset: 0x009D93C8
		public unsafe float SignalBiasExplodeSubWiggle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170057D2 RID: 22482
		// (get) Token: 0x0602688A RID: 157834 RVA: 0x009DB1D9 File Offset: 0x009D93D9
		// (set) Token: 0x0602688B RID: 157835 RVA: 0x009DB1E9 File Offset: 0x009D93E9
		public unsafe float SignalExplodeAttenuation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170057D3 RID: 22483
		// (get) Token: 0x0602688C RID: 157836 RVA: 0x009DB1FA File Offset: 0x009D93FA
		// (set) Token: 0x0602688D RID: 157837 RVA: 0x009DB20A File Offset: 0x009D940A
		public unsafe float RimRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170057D4 RID: 22484
		// (get) Token: 0x0602688E RID: 157838 RVA: 0x009DB21B File Offset: 0x009D941B
		// (set) Token: 0x0602688F RID: 157839 RVA: 0x009DB22F File Offset: 0x009D942F
		public unsafe FLinearColor RimColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170057D5 RID: 22485
		// (get) Token: 0x06026890 RID: 157840 RVA: 0x009DB244 File Offset: 0x009D9444
		// (set) Token: 0x06026891 RID: 157841 RVA: 0x009DB254 File Offset: 0x009D9454
		public unsafe float OutlineWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170057D6 RID: 22486
		// (get) Token: 0x06026892 RID: 157842 RVA: 0x009DB265 File Offset: 0x009D9465
		// (set) Token: 0x06026893 RID: 157843 RVA: 0x009DB279 File Offset: 0x009D9479
		public unsafe FLinearColor OutlineColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170057D7 RID: 22487
		// (get) Token: 0x06026894 RID: 157844 RVA: 0x009DB28E File Offset: 0x009D948E
		// (set) Token: 0x06026895 RID: 157845 RVA: 0x009DB2A2 File Offset: 0x009D94A2
		public unsafe FLinearColor MainTexColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170057D8 RID: 22488
		// (get) Token: 0x06026896 RID: 157846 RVA: 0x009DB2B7 File Offset: 0x009D94B7
		// (set) Token: 0x06026897 RID: 157847 RVA: 0x009DB2C7 File Offset: 0x009D94C7
		public unsafe float StripMaskProportionSide
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170057D9 RID: 22489
		// (get) Token: 0x06026898 RID: 157848 RVA: 0x009DB2D8 File Offset: 0x009D94D8
		// (set) Token: 0x06026899 RID: 157849 RVA: 0x009DB2E8 File Offset: 0x009D94E8
		public unsafe float StripMaskProportionCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170057DA RID: 22490
		// (get) Token: 0x0602689A RID: 157850 RVA: 0x009DB2F9 File Offset: 0x009D94F9
		// (set) Token: 0x0602689B RID: 157851 RVA: 0x009DB309 File Offset: 0x009D9509
		public unsafe float StripMaskVScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170057DB RID: 22491
		// (get) Token: 0x0602689C RID: 157852 RVA: 0x009DB31A File Offset: 0x009D951A
		// (set) Token: 0x0602689D RID: 157853 RVA: 0x009DB32A File Offset: 0x009D952A
		public unsafe float StripMaskVSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170057DC RID: 22492
		// (get) Token: 0x0602689E RID: 157854 RVA: 0x009DB33B File Offset: 0x009D953B
		// (set) Token: 0x0602689F RID: 157855 RVA: 0x009DB34F File Offset: 0x009D954F
		[Nullable(2)]
		public unsafe UTexture2D DistortionMaskTexture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_BadSignalParameters_C.__PropertyOffset_20);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_BadSignalParameters_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x170057DD RID: 22493
		// (get) Token: 0x060268A0 RID: 157856 RVA: 0x009DB364 File Offset: 0x009D9564
		// (set) Token: 0x060268A1 RID: 157857 RVA: 0x009DB374 File Offset: 0x009D9574
		public unsafe float DistortionHold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170057DE RID: 22494
		// (get) Token: 0x060268A2 RID: 157858 RVA: 0x009DB385 File Offset: 0x009D9585
		// (set) Token: 0x060268A3 RID: 157859 RVA: 0x009DB395 File Offset: 0x009D9595
		public unsafe float DistortionUScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170057DF RID: 22495
		// (get) Token: 0x060268A4 RID: 157860 RVA: 0x009DB3A6 File Offset: 0x009D95A6
		// (set) Token: 0x060268A5 RID: 157861 RVA: 0x009DB3B6 File Offset: 0x009D95B6
		public unsafe float DistortionVScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170057E0 RID: 22496
		// (get) Token: 0x060268A6 RID: 157862 RVA: 0x009DB3C7 File Offset: 0x009D95C7
		// (set) Token: 0x060268A7 RID: 157863 RVA: 0x009DB3D7 File Offset: 0x009D95D7
		public unsafe float DistortionProportion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170057E1 RID: 22497
		// (get) Token: 0x060268A8 RID: 157864 RVA: 0x009DB3E8 File Offset: 0x009D95E8
		// (set) Token: 0x060268A9 RID: 157865 RVA: 0x009DB3F8 File Offset: 0x009D95F8
		public unsafe float DistortionExplodeProportion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170057E2 RID: 22498
		// (get) Token: 0x060268AA RID: 157866 RVA: 0x009DB409 File Offset: 0x009D9609
		// (set) Token: 0x060268AB RID: 157867 RVA: 0x009DB419 File Offset: 0x009D9619
		public unsafe float WrapStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170057E3 RID: 22499
		// (get) Token: 0x060268AC RID: 157868 RVA: 0x009DB42A File Offset: 0x009D962A
		// (set) Token: 0x060268AD RID: 157869 RVA: 0x009DB43A File Offset: 0x009D963A
		public unsafe float WrapBiasSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170057E4 RID: 22500
		// (get) Token: 0x060268AE RID: 157870 RVA: 0x009DB44B File Offset: 0x009D964B
		// (set) Token: 0x060268AF RID: 157871 RVA: 0x009DB45B File Offset: 0x009D965B
		public unsafe float WrapFrequecy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_BadSignalParameters_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x060268B0 RID: 157872 RVA: 0x009DB46C File Offset: 0x009D966C
		protected PDA_BadSignalParameters_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401408D RID: 82061
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/BadSignalEffect/PDA_BadSignalParameters.PDA_BadSignalParameters_C";

		// Token: 0x0401408E RID: 82062
		private static IntPtr _ClassPtr;

		// Token: 0x0401408F RID: 82063
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014090 RID: 82064
		internal static int __PropertyOffset_0;

		// Token: 0x04014091 RID: 82065
		internal static int __PropertyOffset_1;

		// Token: 0x04014092 RID: 82066
		internal static int __PropertyOffset_2;

		// Token: 0x04014093 RID: 82067
		internal static int __PropertyOffset_3;

		// Token: 0x04014094 RID: 82068
		internal static int __PropertyOffset_4;

		// Token: 0x04014095 RID: 82069
		internal static int __PropertyOffset_5;

		// Token: 0x04014096 RID: 82070
		internal static int __PropertyOffset_6;

		// Token: 0x04014097 RID: 82071
		internal static int __PropertyOffset_7;

		// Token: 0x04014098 RID: 82072
		internal static int __PropertyOffset_8;

		// Token: 0x04014099 RID: 82073
		internal static int __PropertyOffset_9;

		// Token: 0x0401409A RID: 82074
		internal static int __PropertyOffset_10;

		// Token: 0x0401409B RID: 82075
		internal static int __PropertyOffset_11;

		// Token: 0x0401409C RID: 82076
		internal static int __PropertyOffset_12;

		// Token: 0x0401409D RID: 82077
		internal static int __PropertyOffset_13;

		// Token: 0x0401409E RID: 82078
		internal static int __PropertyOffset_14;

		// Token: 0x0401409F RID: 82079
		internal static int __PropertyOffset_15;

		// Token: 0x040140A0 RID: 82080
		internal static int __PropertyOffset_16;

		// Token: 0x040140A1 RID: 82081
		internal static int __PropertyOffset_17;

		// Token: 0x040140A2 RID: 82082
		internal static int __PropertyOffset_18;

		// Token: 0x040140A3 RID: 82083
		internal static int __PropertyOffset_19;

		// Token: 0x040140A4 RID: 82084
		internal static int __PropertyOffset_20;

		// Token: 0x040140A5 RID: 82085
		internal static int __PropertyOffset_21;

		// Token: 0x040140A6 RID: 82086
		internal static int __PropertyOffset_22;

		// Token: 0x040140A7 RID: 82087
		internal static int __PropertyOffset_23;

		// Token: 0x040140A8 RID: 82088
		internal static int __PropertyOffset_24;

		// Token: 0x040140A9 RID: 82089
		internal static int __PropertyOffset_25;

		// Token: 0x040140AA RID: 82090
		internal static int __PropertyOffset_26;

		// Token: 0x040140AB RID: 82091
		internal static int __PropertyOffset_27;

		// Token: 0x040140AC RID: 82092
		internal static int __PropertyOffset_28;
	}
}
