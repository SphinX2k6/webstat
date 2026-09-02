using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data
{
	// Token: 0x02003A67 RID: 14951
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/EffectScreenPlayData.EffectScreenPlayData_C")]
	[UnrealStructLayout(376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 369)]
	public class EffectScreenPlayData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F293 RID: 127635 RVA: 0x00909BD4 File Offset: 0x00907DD4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (EffectScreenPlayData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/EffectScreenPlayData.EffectScreenPlayData_C");
			}
			return EffectScreenPlayData_C._ClassPtr;
		}

		// Token: 0x0601F294 RID: 127636 RVA: 0x00909BF8 File Offset: 0x00907DF8
		public EffectScreenPlayData_C() : this(BuiltinUtils.AllocNativeUObject(EffectScreenPlayData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F295 RID: 127637 RVA: 0x00909C20 File Offset: 0x00907E20
		public EffectScreenPlayData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectScreenPlayData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E5F RID: 11871
		// (get) Token: 0x0601F296 RID: 127638 RVA: 0x00909C53 File Offset: 0x00907E53
		// (set) Token: 0x0601F297 RID: 127639 RVA: 0x00909C63 File Offset: 0x00907E63
		public unsafe float Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17002E60 RID: 11872
		// (get) Token: 0x0601F298 RID: 127640 RVA: 0x00909C74 File Offset: 0x00907E74
		// (set) Token: 0x0601F299 RID: 127641 RVA: 0x00909C84 File Offset: 0x00907E84
		public unsafe float Loop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17002E61 RID: 11873
		// (get) Token: 0x0601F29A RID: 127642 RVA: 0x00909C95 File Offset: 0x00907E95
		// (set) Token: 0x0601F29B RID: 127643 RVA: 0x00909CA5 File Offset: 0x00907EA5
		public unsafe float End
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002E62 RID: 11874
		// (get) Token: 0x0601F29C RID: 127644 RVA: 0x00909CB6 File Offset: 0x00907EB6
		// (set) Token: 0x0601F29D RID: 127645 RVA: 0x00909CCA File Offset: 0x00907ECA
		[Nullable(0)]
		public unsafe TEnumAsByte<E_SE_PlayOrder> PlayOrderType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002E63 RID: 11875
		// (get) Token: 0x0601F29E RID: 127646 RVA: 0x00909CDF File Offset: 0x00907EDF
		// (set) Token: 0x0601F29F RID: 127647 RVA: 0x00909CF3 File Offset: 0x00907EF3
		[Nullable(2)]
		public unsafe UPrefabAsset LGUIPrefab
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrefabAsset>(base.NativePtr / (IntPtr)sizeof(void*) + EffectScreenPlayData_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + EffectScreenPlayData_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002E64 RID: 11876
		// (get) Token: 0x0601F2A0 RID: 127648 RVA: 0x00909D08 File Offset: 0x00907F08
		// (set) Token: 0x0601F2A1 RID: 127649 RVA: 0x00909D18 File Offset: 0x00907F18
		public unsafe bool bStopByCall
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E65 RID: 11877
		// (get) Token: 0x0601F2A2 RID: 127650 RVA: 0x00909D29 File Offset: 0x00907F29
		// (set) Token: 0x0601F2A3 RID: 127651 RVA: 0x00909D39 File Offset: 0x00907F39
		public unsafe bool bNormalizeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E66 RID: 11878
		// (get) Token: 0x0601F2A4 RID: 127652 RVA: 0x00909D4A File Offset: 0x00907F4A
		// (set) Token: 0x0601F2A5 RID: 127653 RVA: 0x00909D5A File Offset: 0x00907F5A
		public unsafe int Order
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002E67 RID: 11879
		// (get) Token: 0x0601F2A6 RID: 127654 RVA: 0x00909D6B File Offset: 0x00907F6B
		// (set) Token: 0x0601F2A7 RID: 127655 RVA: 0x00909D7B File Offset: 0x00907F7B
		public unsafe float fadeSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002E68 RID: 11880
		// (get) Token: 0x0601F2A8 RID: 127656 RVA: 0x00909D8C File Offset: 0x00907F8C
		// (set) Token: 0x0601F2A9 RID: 127657 RVA: 0x00909D9C File Offset: 0x00907F9C
		public unsafe bool OverrideFadeOutSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E69 RID: 11881
		// (get) Token: 0x0601F2AA RID: 127658 RVA: 0x00909DAD File Offset: 0x00907FAD
		// (set) Token: 0x0601F2AB RID: 127659 RVA: 0x00909DBD File Offset: 0x00907FBD
		public unsafe float fadeOutSpeedOverride
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17002E6A RID: 11882
		// (get) Token: 0x0601F2AC RID: 127660 RVA: 0x00909DCE File Offset: 0x00907FCE
		// (set) Token: 0x0601F2AD RID: 127661 RVA: 0x00909DDE File Offset: 0x00907FDE
		public unsafe bool bUsedForSequence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E6B RID: 11883
		// (get) Token: 0x0601F2AE RID: 127662 RVA: 0x00909DEF File Offset: 0x00907FEF
		// (set) Token: 0x0601F2AF RID: 127663 RVA: 0x00909E03 File Offset: 0x00908003
		[Nullable(0)]
		public unsafe TEnumAsByte<E_SE_RootType> RootType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_12);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17002E6C RID: 11884
		// (get) Token: 0x0601F2B0 RID: 127664 RVA: 0x00909E18 File Offset: 0x00908018
		// (set) Token: 0x0601F2B1 RID: 127665 RVA: 0x00909E28 File Offset: 0x00908028
		public unsafe bool bAutoDestroy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E6D RID: 11885
		// (get) Token: 0x0601F2B2 RID: 127666 RVA: 0x00909E39 File Offset: 0x00908039
		// (set) Token: 0x0601F2B3 RID: 127667 RVA: 0x00909E49 File Offset: 0x00908049
		public unsafe bool bUseAudio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002E6E RID: 11886
		// (get) Token: 0x0601F2B4 RID: 127668 RVA: 0x00909E5A File Offset: 0x0090805A
		// (set) Token: 0x0601F2B5 RID: 127669 RVA: 0x00909E6E File Offset: 0x0090806E
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEvent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + EffectScreenPlayData_C.__PropertyOffset_15);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + EffectScreenPlayData_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17002E6F RID: 11887
		// (get) Token: 0x0601F2B6 RID: 127670 RVA: 0x00909E83 File Offset: 0x00908083
		// (set) Token: 0x0601F2B7 RID: 127671 RVA: 0x00909E97 File Offset: 0x00908097
		[Nullable(2)]
		public unsafe UAkAudioEvent AudioEventEnd
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + EffectScreenPlayData_C.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + EffectScreenPlayData_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17002E70 RID: 11888
		// (get) Token: 0x0601F2B8 RID: 127672 RVA: 0x00909EAC File Offset: 0x009080AC
		// (set) Token: 0x0601F2B9 RID: 127673 RVA: 0x00909EBC File Offset: 0x009080BC
		public unsafe float AudioEventEndDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17002E71 RID: 11889
		// (get) Token: 0x0601F2BA RID: 127674 RVA: 0x00909ECD File Offset: 0x009080CD
		// (set) Token: 0x0601F2BB RID: 127675 RVA: 0x00909EE1 File Offset: 0x009080E1
		public unsafe string ConsoleCommandOnBegin
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)EffectScreenPlayData_C.__PropertyOffset_18)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)EffectScreenPlayData_C.__PropertyOffset_18)), value);
			}
		}

		// Token: 0x17002E72 RID: 11890
		// (get) Token: 0x0601F2BC RID: 127676 RVA: 0x00909EF6 File Offset: 0x009080F6
		// (set) Token: 0x0601F2BD RID: 127677 RVA: 0x00909F0A File Offset: 0x0090810A
		public unsafe string ConsoleCommandOnEnd
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)EffectScreenPlayData_C.__PropertyOffset_19)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)EffectScreenPlayData_C.__PropertyOffset_19)), value);
			}
		}

		// Token: 0x17002E73 RID: 11891
		// (get) Token: 0x0601F2BE RID: 127678 RVA: 0x00909F20 File Offset: 0x00908120
		// (set) Token: 0x0601F2BF RID: 127679 RVA: 0x00909F59 File Offset: 0x00908159
		public TMap<string, FKuroCurveLinearColor> LinearColorParameter
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FKuroCurveLinearColor> result;
				if ((result = this._LinearColorParameter) == null)
				{
					result = (this._LinearColorParameter = new TMap<string, FKuroCurveLinearColor>(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				this.LinearColorParameter.CopyAssign(value);
			}
		}

		// Token: 0x17002E74 RID: 11892
		// (get) Token: 0x0601F2C0 RID: 127680 RVA: 0x00909F68 File Offset: 0x00908168
		// (set) Token: 0x0601F2C1 RID: 127681 RVA: 0x00909FA1 File Offset: 0x009081A1
		public TMap<string, FKuroCurveFloat> FloatParameter
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FKuroCurveFloat> result;
				if ((result = this._FloatParameter) == null)
				{
					result = (this._FloatParameter = new TMap<string, FKuroCurveFloat>(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				this.FloatParameter.CopyAssign(value);
			}
		}

		// Token: 0x17002E75 RID: 11893
		// (get) Token: 0x0601F2C2 RID: 127682 RVA: 0x00909FAF File Offset: 0x009081AF
		// (set) Token: 0x0601F2C3 RID: 127683 RVA: 0x00909FBF File Offset: 0x009081BF
		public unsafe float EffectTweenSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17002E76 RID: 11894
		// (get) Token: 0x0601F2C4 RID: 127684 RVA: 0x00909FD0 File Offset: 0x009081D0
		// (set) Token: 0x0601F2C5 RID: 127685 RVA: 0x0090A009 File Offset: 0x00908209
		public TArray<SScreenEffectExtraState> ExtraStates
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SScreenEffectExtraState> result;
				if ((result = this._ExtraStates) == null)
				{
					result = (this._ExtraStates = new TArray<SScreenEffectExtraState>(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				this.ExtraStates.CopyAssign(value);
			}
		}

		// Token: 0x17002E77 RID: 11895
		// (get) Token: 0x0601F2C6 RID: 127686 RVA: 0x0090A017 File Offset: 0x00908217
		// (set) Token: 0x0601F2C7 RID: 127687 RVA: 0x0090A027 File Offset: 0x00908227
		public unsafe bool bStartLoopEndByCurve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EffectScreenPlayData_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601F2C8 RID: 127688 RVA: 0x0090A038 File Offset: 0x00908238
		protected EffectScreenPlayData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F708 RID: 63240
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Data/EffectScreenPlayData.EffectScreenPlayData_C";

		// Token: 0x0400F709 RID: 63241
		private static IntPtr _ClassPtr;

		// Token: 0x0400F70A RID: 63242
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F70B RID: 63243
		internal static int __PropertyOffset_0;

		// Token: 0x0400F70C RID: 63244
		internal static int __PropertyOffset_1;

		// Token: 0x0400F70D RID: 63245
		internal static int __PropertyOffset_2;

		// Token: 0x0400F70E RID: 63246
		internal static int __PropertyOffset_3;

		// Token: 0x0400F70F RID: 63247
		internal static int __PropertyOffset_4;

		// Token: 0x0400F710 RID: 63248
		internal static int __PropertyOffset_5;

		// Token: 0x0400F711 RID: 63249
		internal static int __PropertyOffset_6;

		// Token: 0x0400F712 RID: 63250
		internal static int __PropertyOffset_7;

		// Token: 0x0400F713 RID: 63251
		internal static int __PropertyOffset_8;

		// Token: 0x0400F714 RID: 63252
		internal static int __PropertyOffset_9;

		// Token: 0x0400F715 RID: 63253
		internal static int __PropertyOffset_10;

		// Token: 0x0400F716 RID: 63254
		internal static int __PropertyOffset_11;

		// Token: 0x0400F717 RID: 63255
		internal static int __PropertyOffset_12;

		// Token: 0x0400F718 RID: 63256
		internal static int __PropertyOffset_13;

		// Token: 0x0400F719 RID: 63257
		internal static int __PropertyOffset_14;

		// Token: 0x0400F71A RID: 63258
		internal static int __PropertyOffset_15;

		// Token: 0x0400F71B RID: 63259
		internal static int __PropertyOffset_16;

		// Token: 0x0400F71C RID: 63260
		internal static int __PropertyOffset_17;

		// Token: 0x0400F71D RID: 63261
		internal static int __PropertyOffset_18;

		// Token: 0x0400F71E RID: 63262
		internal static int __PropertyOffset_19;

		// Token: 0x0400F71F RID: 63263
		internal static int __PropertyOffset_20;

		// Token: 0x0400F720 RID: 63264
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, FKuroCurveLinearColor> _LinearColorParameter;

		// Token: 0x0400F721 RID: 63265
		internal static int __PropertyOffset_21;

		// Token: 0x0400F722 RID: 63266
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, FKuroCurveFloat> _FloatParameter;

		// Token: 0x0400F723 RID: 63267
		internal static int __PropertyOffset_22;

		// Token: 0x0400F724 RID: 63268
		internal static int __PropertyOffset_23;

		// Token: 0x0400F725 RID: 63269
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SScreenEffectExtraState> _ExtraStates;

		// Token: 0x0400F726 RID: 63270
		internal static int __PropertyOffset_24;
	}
}
