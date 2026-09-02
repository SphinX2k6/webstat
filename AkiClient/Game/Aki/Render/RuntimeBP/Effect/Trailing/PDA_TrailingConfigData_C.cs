using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Trailing
{
	// Token: 0x02003D27 RID: 15655
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Trailing/PDA_TrailingConfigData.PDA_TrailingConfigData_C")]
	[UnrealStructLayout(360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 353)]
	public class PDA_TrailingConfigData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025DCC RID: 155084 RVA: 0x009C730C File Offset: 0x009C550C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_TrailingConfigData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Trailing/PDA_TrailingConfigData.PDA_TrailingConfigData_C");
			}
			return PDA_TrailingConfigData_C._ClassPtr;
		}

		// Token: 0x06025DCD RID: 155085 RVA: 0x009C7330 File Offset: 0x009C5530
		public PDA_TrailingConfigData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_TrailingConfigData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025DCE RID: 155086 RVA: 0x009C7358 File Offset: 0x009C5558
		public PDA_TrailingConfigData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_TrailingConfigData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700541D RID: 21533
		// (get) Token: 0x06025DCF RID: 155087 RVA: 0x009C738B File Offset: 0x009C558B
		// (set) Token: 0x06025DD0 RID: 155088 RVA: 0x009C739F File Offset: 0x009C559F
		[Nullable(0)]
		public unsafe TEnumAsByte<ETrailingAttachType> AttachType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700541E RID: 21534
		// (get) Token: 0x06025DD1 RID: 155089 RVA: 0x009C73B4 File Offset: 0x009C55B4
		// (set) Token: 0x06025DD2 RID: 155090 RVA: 0x009C73ED File Offset: 0x009C55ED
		public TArray<string> AttachLimbNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._AttachLimbNames) == null)
				{
					result = (this._AttachLimbNames = new TArray<string>(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.AttachLimbNames.CopyAssign(value);
			}
		}

		// Token: 0x1700541F RID: 21535
		// (get) Token: 0x06025DD3 RID: 155091 RVA: 0x009C73FC File Offset: 0x009C55FC
		// (set) Token: 0x06025DD4 RID: 155092 RVA: 0x009C7435 File Offset: 0x009C5635
		public TArray<FVector> RelativeLocations
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._RelativeLocations) == null)
				{
					result = (this._RelativeLocations = new TArray<FVector>(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.RelativeLocations.CopyAssign(value);
			}
		}

		// Token: 0x17005420 RID: 21536
		// (get) Token: 0x06025DD5 RID: 155093 RVA: 0x009C7443 File Offset: 0x009C5643
		// (set) Token: 0x06025DD6 RID: 155094 RVA: 0x009C7457 File Offset: 0x009C5657
		[Nullable(2)]
		public unsafe UMaterialInterface Material
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_TrailingConfigData_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_TrailingConfigData_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005421 RID: 21537
		// (get) Token: 0x06025DD7 RID: 155095 RVA: 0x009C746C File Offset: 0x009C566C
		// (set) Token: 0x06025DD8 RID: 155096 RVA: 0x009C747C File Offset: 0x009C567C
		public unsafe int MaxLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005422 RID: 21538
		// (get) Token: 0x06025DD9 RID: 155097 RVA: 0x009C748D File Offset: 0x009C568D
		// (set) Token: 0x06025DDA RID: 155098 RVA: 0x009C749D File Offset: 0x009C569D
		public unsafe int MaxInterpolateCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005423 RID: 21539
		// (get) Token: 0x06025DDB RID: 155099 RVA: 0x009C74AE File Offset: 0x009C56AE
		// (set) Token: 0x06025DDC RID: 155100 RVA: 0x009C74BE File Offset: 0x009C56BE
		public unsafe float LengthUnit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005424 RID: 21540
		// (get) Token: 0x06025DDD RID: 155101 RVA: 0x009C74CF File Offset: 0x009C56CF
		// (set) Token: 0x06025DDE RID: 155102 RVA: 0x009C74DF File Offset: 0x009C56DF
		public unsafe bool UseNormal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005425 RID: 21541
		// (get) Token: 0x06025DDF RID: 155103 RVA: 0x009C74F0 File Offset: 0x009C56F0
		// (set) Token: 0x06025DE0 RID: 155104 RVA: 0x009C7500 File Offset: 0x009C5700
		public unsafe float AirflowHoldTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005426 RID: 21542
		// (get) Token: 0x06025DE1 RID: 155105 RVA: 0x009C7511 File Offset: 0x009C5711
		// (set) Token: 0x06025DE2 RID: 155106 RVA: 0x009C7521 File Offset: 0x009C5721
		public unsafe float SmoothIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005427 RID: 21543
		// (get) Token: 0x06025DE3 RID: 155107 RVA: 0x009C7532 File Offset: 0x009C5732
		// (set) Token: 0x06025DE4 RID: 155108 RVA: 0x009C7542 File Offset: 0x009C5742
		public unsafe float UV2Scale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005428 RID: 21544
		// (get) Token: 0x06025DE5 RID: 155109 RVA: 0x009C7553 File Offset: 0x009C5753
		// (set) Token: 0x06025DE6 RID: 155110 RVA: 0x009C7563 File Offset: 0x009C5763
		public unsafe float Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005429 RID: 21545
		// (get) Token: 0x06025DE7 RID: 155111 RVA: 0x009C7574 File Offset: 0x009C5774
		// (set) Token: 0x06025DE8 RID: 155112 RVA: 0x009C7584 File Offset: 0x009C5784
		public unsafe float Loop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700542A RID: 21546
		// (get) Token: 0x06025DE9 RID: 155113 RVA: 0x009C7595 File Offset: 0x009C5795
		// (set) Token: 0x06025DEA RID: 155114 RVA: 0x009C75A5 File Offset: 0x009C57A5
		public unsafe float End
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x1700542B RID: 21547
		// (get) Token: 0x06025DEB RID: 155115 RVA: 0x009C75B8 File Offset: 0x009C57B8
		// (set) Token: 0x06025DEC RID: 155116 RVA: 0x009C75F1 File Offset: 0x009C57F1
		public TArray<SMaterialControllerFloatParameter> Time_FloatParameter
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerFloatParameter> result;
				if ((result = this._Time_FloatParameter) == null)
				{
					result = (this._Time_FloatParameter = new TArray<SMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				this.Time_FloatParameter.CopyAssign(value);
			}
		}

		// Token: 0x1700542C RID: 21548
		// (get) Token: 0x06025DED RID: 155117 RVA: 0x009C7600 File Offset: 0x009C5800
		// (set) Token: 0x06025DEE RID: 155118 RVA: 0x009C7639 File Offset: 0x009C5839
		public TArray<SMaterialControllerColorParameter> Time_ColorParameter
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerColorParameter> result;
				if ((result = this._Time_ColorParameter) == null)
				{
					result = (this._Time_ColorParameter = new TArray<SMaterialControllerColorParameter>(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				this.Time_ColorParameter.CopyAssign(value);
			}
		}

		// Token: 0x1700542D RID: 21549
		// (get) Token: 0x06025DEF RID: 155119 RVA: 0x009C7647 File Offset: 0x009C5847
		// (set) Token: 0x06025DF0 RID: 155120 RVA: 0x009C7657 File Offset: 0x009C5857
		public unsafe float MaxDensitySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x1700542E RID: 21550
		// (get) Token: 0x06025DF1 RID: 155121 RVA: 0x009C7668 File Offset: 0x009C5868
		// (set) Token: 0x06025DF2 RID: 155122 RVA: 0x009C76A1 File Offset: 0x009C58A1
		public FKuroCurveFloat AirflowDensitySpeedScale
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._AirflowDensitySpeedScale) == null)
				{
					result = (this._AirflowDensitySpeedScale = new FKuroCurveFloat(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700542F RID: 21551
		// (get) Token: 0x06025DF3 RID: 155123 RVA: 0x009C76C2 File Offset: 0x009C58C2
		// (set) Token: 0x06025DF4 RID: 155124 RVA: 0x009C76D2 File Offset: 0x009C58D2
		public unsafe bool DestroyAtOnce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_TrailingConfigData_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025DF5 RID: 155125 RVA: 0x009C76E3 File Offset: 0x009C58E3
		protected PDA_TrailingConfigData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401391F RID: 80159
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Trailing/PDA_TrailingConfigData.PDA_TrailingConfigData_C";

		// Token: 0x04013920 RID: 80160
		private static IntPtr _ClassPtr;

		// Token: 0x04013921 RID: 80161
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013922 RID: 80162
		internal static int __PropertyOffset_0;

		// Token: 0x04013923 RID: 80163
		internal static int __PropertyOffset_1;

		// Token: 0x04013924 RID: 80164
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _AttachLimbNames;

		// Token: 0x04013925 RID: 80165
		internal static int __PropertyOffset_2;

		// Token: 0x04013926 RID: 80166
		[Nullable(2)]
		private TArray<FVector> _RelativeLocations;

		// Token: 0x04013927 RID: 80167
		internal static int __PropertyOffset_3;

		// Token: 0x04013928 RID: 80168
		internal static int __PropertyOffset_4;

		// Token: 0x04013929 RID: 80169
		internal static int __PropertyOffset_5;

		// Token: 0x0401392A RID: 80170
		internal static int __PropertyOffset_6;

		// Token: 0x0401392B RID: 80171
		internal static int __PropertyOffset_7;

		// Token: 0x0401392C RID: 80172
		internal static int __PropertyOffset_8;

		// Token: 0x0401392D RID: 80173
		internal static int __PropertyOffset_9;

		// Token: 0x0401392E RID: 80174
		internal static int __PropertyOffset_10;

		// Token: 0x0401392F RID: 80175
		internal static int __PropertyOffset_11;

		// Token: 0x04013930 RID: 80176
		internal static int __PropertyOffset_12;

		// Token: 0x04013931 RID: 80177
		internal static int __PropertyOffset_13;

		// Token: 0x04013932 RID: 80178
		internal static int __PropertyOffset_14;

		// Token: 0x04013933 RID: 80179
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerFloatParameter> _Time_FloatParameter;

		// Token: 0x04013934 RID: 80180
		internal static int __PropertyOffset_15;

		// Token: 0x04013935 RID: 80181
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerColorParameter> _Time_ColorParameter;

		// Token: 0x04013936 RID: 80182
		internal static int __PropertyOffset_16;

		// Token: 0x04013937 RID: 80183
		internal static int __PropertyOffset_17;

		// Token: 0x04013938 RID: 80184
		[Nullable(2)]
		private FKuroCurveFloat _AirflowDensitySpeedScale;

		// Token: 0x04013939 RID: 80185
		internal static int __PropertyOffset_18;
	}
}
