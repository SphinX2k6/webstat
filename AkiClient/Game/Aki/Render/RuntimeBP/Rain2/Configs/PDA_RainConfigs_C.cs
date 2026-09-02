using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2.Configs
{
	// Token: 0x02003B40 RID: 15168
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfigs.PDA_RainConfigs_C")]
	[UnrealStructLayout(392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 392)]
	public class PDA_RainConfigs_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020DAC RID: 134572 RVA: 0x00938BAC File Offset: 0x00936DAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_RainConfigs_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfigs.PDA_RainConfigs_C");
			}
			return PDA_RainConfigs_C._ClassPtr;
		}

		// Token: 0x06020DAD RID: 134573 RVA: 0x00938BD0 File Offset: 0x00936DD0
		public PDA_RainConfigs_C() : this(BuiltinUtils.AllocNativeUObject(PDA_RainConfigs_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020DAE RID: 134574 RVA: 0x00938BF8 File Offset: 0x00936DF8
		public PDA_RainConfigs_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_RainConfigs_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170037A0 RID: 14240
		// (get) Token: 0x06020DAF RID: 134575 RVA: 0x00938C2B File Offset: 0x00936E2B
		// (set) Token: 0x06020DB0 RID: 134576 RVA: 0x00938C3F File Offset: 0x00936E3F
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonReverse_C RainConfig_CommonReverse_Lively
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170037A1 RID: 14241
		// (get) Token: 0x06020DB1 RID: 134577 RVA: 0x00938C54 File Offset: 0x00936E54
		// (set) Token: 0x06020DB2 RID: 134578 RVA: 0x00938C68 File Offset: 0x00936E68
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonReverse_C RainConfig_CommonReverse_Stable
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170037A2 RID: 14242
		// (get) Token: 0x06020DB3 RID: 134579 RVA: 0x00938C7D File Offset: 0x00936E7D
		// (set) Token: 0x06020DB4 RID: 134580 RVA: 0x00938C91 File Offset: 0x00936E91
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonReverse_C RainConfig_CommonReverse_Fast
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170037A3 RID: 14243
		// (get) Token: 0x06020DB5 RID: 134581 RVA: 0x00938CA6 File Offset: 0x00936EA6
		// (set) Token: 0x06020DB6 RID: 134582 RVA: 0x00938CBA File Offset: 0x00936EBA
		[Nullable(2)]
		public unsafe PDA_RainConfig_CommonReverse_C RainConfig_CommonReverse_UrgentTurn
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_RainConfig_CommonReverse_C>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_RainConfigs_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170037A4 RID: 14244
		// (get) Token: 0x06020DB7 RID: 134583 RVA: 0x00938CD0 File Offset: 0x00936ED0
		// (set) Token: 0x06020DB8 RID: 134584 RVA: 0x00938D09 File Offset: 0x00936F09
		public SWorldRainComb SnowConfig_CommonDrop
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._SnowConfig_CommonDrop) == null)
				{
					result = (this._SnowConfig_CommonDrop = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037A5 RID: 14245
		// (get) Token: 0x06020DB9 RID: 134585 RVA: 0x00938D2C File Offset: 0x00936F2C
		// (set) Token: 0x06020DBA RID: 134586 RVA: 0x00938D65 File Offset: 0x00936F65
		public SWorldRainComb RainConfig_CommonDrop_1
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._RainConfig_CommonDrop_1) == null)
				{
					result = (this._RainConfig_CommonDrop_1 = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037A6 RID: 14246
		// (get) Token: 0x06020DBB RID: 134587 RVA: 0x00938D88 File Offset: 0x00936F88
		// (set) Token: 0x06020DBC RID: 134588 RVA: 0x00938DC1 File Offset: 0x00936FC1
		public SWorldRainComb SnowConfig_JinkuBoss
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._SnowConfig_JinkuBoss) == null)
				{
					result = (this._SnowConfig_JinkuBoss = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037A7 RID: 14247
		// (get) Token: 0x06020DBD RID: 134589 RVA: 0x00938DE4 File Offset: 0x00936FE4
		// (set) Token: 0x06020DBE RID: 134590 RVA: 0x00938E1D File Offset: 0x0093701D
		public SWorldRainComb RainConfig_BlackWave
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._RainConfig_BlackWave) == null)
				{
					result = (this._RainConfig_BlackWave = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037A8 RID: 14248
		// (get) Token: 0x06020DBF RID: 134591 RVA: 0x00938E40 File Offset: 0x00937040
		// (set) Token: 0x06020DC0 RID: 134592 RVA: 0x00938E79 File Offset: 0x00937079
		public SWorldRainComb SnowConfig_SnowStorm
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._SnowConfig_SnowStorm) == null)
				{
					result = (this._SnowConfig_SnowStorm = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037A9 RID: 14249
		// (get) Token: 0x06020DC1 RID: 134593 RVA: 0x00938E9C File Offset: 0x0093709C
		// (set) Token: 0x06020DC2 RID: 134594 RVA: 0x00938ED5 File Offset: 0x009370D5
		public SWorldRainComb RainConfig_StormRain
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._RainConfig_StormRain) == null)
				{
					result = (this._RainConfig_StormRain = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170037AA RID: 14250
		// (get) Token: 0x06020DC3 RID: 134595 RVA: 0x00938EF8 File Offset: 0x009370F8
		// (set) Token: 0x06020DC4 RID: 134596 RVA: 0x00938F31 File Offset: 0x00937131
		public SWorldRainComb RainConfig_CyberRain
		{
			get
			{
				base.FastCheckIsValid();
				SWorldRainComb result;
				if ((result = this._RainConfig_CyberRain) == null)
				{
					result = (this._RainConfig_CyberRain = new SWorldRainComb(base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWorldRainComb.StaticStruct(), base.NativePtr + (IntPtr)PDA_RainConfigs_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06020DC5 RID: 134597 RVA: 0x00938F52 File Offset: 0x00937152
		protected PDA_RainConfigs_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401079D RID: 67485
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/Configs/PDA_RainConfigs.PDA_RainConfigs_C";

		// Token: 0x0401079E RID: 67486
		private static IntPtr _ClassPtr;

		// Token: 0x0401079F RID: 67487
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040107A0 RID: 67488
		internal static int __PropertyOffset_0;

		// Token: 0x040107A1 RID: 67489
		internal static int __PropertyOffset_1;

		// Token: 0x040107A2 RID: 67490
		internal static int __PropertyOffset_2;

		// Token: 0x040107A3 RID: 67491
		internal static int __PropertyOffset_3;

		// Token: 0x040107A4 RID: 67492
		internal static int __PropertyOffset_4;

		// Token: 0x040107A5 RID: 67493
		[Nullable(2)]
		private SWorldRainComb _SnowConfig_CommonDrop;

		// Token: 0x040107A6 RID: 67494
		internal static int __PropertyOffset_5;

		// Token: 0x040107A7 RID: 67495
		[Nullable(2)]
		private SWorldRainComb _RainConfig_CommonDrop_1;

		// Token: 0x040107A8 RID: 67496
		internal static int __PropertyOffset_6;

		// Token: 0x040107A9 RID: 67497
		[Nullable(2)]
		private SWorldRainComb _SnowConfig_JinkuBoss;

		// Token: 0x040107AA RID: 67498
		internal static int __PropertyOffset_7;

		// Token: 0x040107AB RID: 67499
		[Nullable(2)]
		private SWorldRainComb _RainConfig_BlackWave;

		// Token: 0x040107AC RID: 67500
		internal static int __PropertyOffset_8;

		// Token: 0x040107AD RID: 67501
		[Nullable(2)]
		private SWorldRainComb _SnowConfig_SnowStorm;

		// Token: 0x040107AE RID: 67502
		internal static int __PropertyOffset_9;

		// Token: 0x040107AF RID: 67503
		[Nullable(2)]
		private SWorldRainComb _RainConfig_StormRain;

		// Token: 0x040107B0 RID: 67504
		internal static int __PropertyOffset_10;

		// Token: 0x040107B1 RID: 67505
		[Nullable(2)]
		private SWorldRainComb _RainConfig_CyberRain;
	}
}
