using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Vehicle
{
	// Token: 0x02003E68 RID: 15976
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/BP_MotorConfig.BP_MotorConfig_C")]
	[UnrealStructLayout(976, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 976)]
	public class BP_MotorConfig_C : BP_VehicleConfig_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602776F RID: 161647 RVA: 0x009F24F3 File Offset: 0x009F06F3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MotorConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Vehicle/BP_MotorConfig.BP_MotorConfig_C");
			}
			return BP_MotorConfig_C._ClassPtr;
		}

		// Token: 0x06027770 RID: 161648 RVA: 0x009F2518 File Offset: 0x009F0718
		public BP_MotorConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_MotorConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027771 RID: 161649 RVA: 0x009F2540 File Offset: 0x009F0740
		public BP_MotorConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MotorConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005CED RID: 23789
		// (get) Token: 0x06027772 RID: 161650 RVA: 0x009F2573 File Offset: 0x009F0773
		// (set) Token: 0x06027773 RID: 161651 RVA: 0x009F2587 File Offset: 0x009F0787
		[Nullable(2)]
		public unsafe UDataTable ConfigDataTable
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorConfig_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorConfig_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005CEE RID: 23790
		// (get) Token: 0x06027774 RID: 161652 RVA: 0x009F259C File Offset: 0x009F079C
		// (set) Token: 0x06027775 RID: 161653 RVA: 0x009F25D5 File Offset: 0x009F07D5
		public TArray<SFloatThresholdAndBuff> 非加速状态buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndBuff> result;
				if ((result = this._非加速状态buff) == null)
				{
					result = (this._非加速状态buff = new TArray<SFloatThresholdAndBuff>(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.非加速状态buff.CopyAssign(value);
			}
		}

		// Token: 0x17005CEF RID: 23791
		// (get) Token: 0x06027776 RID: 161654 RVA: 0x009F25E4 File Offset: 0x009F07E4
		// (set) Token: 0x06027777 RID: 161655 RVA: 0x009F261D File Offset: 0x009F081D
		public TArray<SFloatThresholdAndBuff> 加速状态buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndBuff> result;
				if ((result = this._加速状态buff) == null)
				{
					result = (this._加速状态buff = new TArray<SFloatThresholdAndBuff>(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.加速状态buff.CopyAssign(value);
			}
		}

		// Token: 0x17005CF0 RID: 23792
		// (get) Token: 0x06027778 RID: 161656 RVA: 0x009F262C File Offset: 0x009F082C
		// (set) Token: 0x06027779 RID: 161657 RVA: 0x009F2665 File Offset: 0x009F0865
		public TArray<SFloatThresholdAndBuff> 翱翔加速状态buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndBuff> result;
				if ((result = this._翱翔加速状态buff) == null)
				{
					result = (this._翱翔加速状态buff = new TArray<SFloatThresholdAndBuff>(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.翱翔加速状态buff.CopyAssign(value);
			}
		}

		// Token: 0x17005CF1 RID: 23793
		// (get) Token: 0x0602777A RID: 161658 RVA: 0x009F2673 File Offset: 0x009F0873
		// (set) Token: 0x0602777B RID: 161659 RVA: 0x009F2683 File Offset: 0x009F0883
		public unsafe long 常驻buff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005CF2 RID: 23794
		// (get) Token: 0x0602777C RID: 161660 RVA: 0x009F2694 File Offset: 0x009F0894
		// (set) Token: 0x0602777D RID: 161661 RVA: 0x009F26CD File Offset: 0x009F08CD
		public TArray<SFloatThresholdAndBuff> 时段buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SFloatThresholdAndBuff> result;
				if ((result = this._时段buff) == null)
				{
					result = (this._时段buff = new TArray<SFloatThresholdAndBuff>(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.时段buff.CopyAssign(value);
			}
		}

		// Token: 0x17005CF3 RID: 23795
		// (get) Token: 0x0602777E RID: 161662 RVA: 0x009F26DB File Offset: 0x009F08DB
		// (set) Token: 0x0602777F RID: 161663 RVA: 0x009F26EB File Offset: 0x009F08EB
		public unsafe long 漂移buff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005CF4 RID: 23796
		// (get) Token: 0x06027780 RID: 161664 RVA: 0x009F26FC File Offset: 0x009F08FC
		// (set) Token: 0x06027781 RID: 161665 RVA: 0x009F270C File Offset: 0x009F090C
		public unsafe long 倒车buff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005CF5 RID: 23797
		// (get) Token: 0x06027782 RID: 161666 RVA: 0x009F2720 File Offset: 0x009F0920
		// (set) Token: 0x06027783 RID: 161667 RVA: 0x009F2759 File Offset: 0x009F0959
		public TMap<EMotorPart, long> 撞击buff
		{
			get
			{
				base.FastCheckIsValid();
				TMap<EMotorPart, long> result;
				if ((result = this._撞击buff) == null)
				{
					result = (this._撞击buff = new TMap<EMotorPart, long>(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.撞击buff.CopyAssign(value);
			}
		}

		// Token: 0x17005CF6 RID: 23798
		// (get) Token: 0x06027784 RID: 161668 RVA: 0x009F2767 File Offset: 0x009F0967
		// (set) Token: 0x06027785 RID: 161669 RVA: 0x009F2777 File Offset: 0x009F0977
		public unsafe float 叠加速度衰减时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005CF7 RID: 23799
		// (get) Token: 0x06027786 RID: 161670 RVA: 0x009F2788 File Offset: 0x009F0988
		// (set) Token: 0x06027787 RID: 161671 RVA: 0x009F2798 File Offset: 0x009F0998
		public unsafe float 载具速度叠加比例
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005CF8 RID: 23800
		// (get) Token: 0x06027788 RID: 161672 RVA: 0x009F27A9 File Offset: 0x009F09A9
		// (set) Token: 0x06027789 RID: 161673 RVA: 0x009F27BD File Offset: 0x009F09BD
		[Nullable(2)]
		public unsafe UCurveFloat 叠加速度衰减曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorConfig_C.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MotorConfig_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17005CF9 RID: 23801
		// (get) Token: 0x0602778A RID: 161674 RVA: 0x009F27D4 File Offset: 0x009F09D4
		// (set) Token: 0x0602778B RID: 161675 RVA: 0x009F280D File Offset: 0x009F0A0D
		public TArray<long> 常驻buffs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._常驻buffs) == null)
				{
					result = (this._常驻buffs = new TArray<long>(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.常驻buffs.CopyAssign(value);
			}
		}

		// Token: 0x17005CFA RID: 23802
		// (get) Token: 0x0602778C RID: 161676 RVA: 0x009F281B File Offset: 0x009F0A1B
		// (set) Token: 0x0602778D RID: 161677 RVA: 0x009F282F File Offset: 0x009F0A2F
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_CameraShakeAndForceFeedback_C> 冲刺震屏
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_13);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005CFB RID: 23803
		// (get) Token: 0x0602778E RID: 161678 RVA: 0x009F2844 File Offset: 0x009F0A44
		// (set) Token: 0x0602778F RID: 161679 RVA: 0x009F2854 File Offset: 0x009F0A54
		public unsafe long 和小物件重合时的特效Buff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorConfig_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x06027790 RID: 161680 RVA: 0x009F2865 File Offset: 0x009F0A65
		protected BP_MotorConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014AB2 RID: 84658
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/BP_MotorConfig.BP_MotorConfig_C";

		// Token: 0x04014AB3 RID: 84659
		private static IntPtr _ClassPtr;

		// Token: 0x04014AB4 RID: 84660
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014AB5 RID: 84661
		internal new static int __PropertyOffset_0;

		// Token: 0x04014AB6 RID: 84662
		internal new static int __PropertyOffset_1;

		// Token: 0x04014AB7 RID: 84663
		[Nullable(2)]
		private TArray<SFloatThresholdAndBuff> _非加速状态buff;

		// Token: 0x04014AB8 RID: 84664
		internal new static int __PropertyOffset_2;

		// Token: 0x04014AB9 RID: 84665
		[Nullable(2)]
		private TArray<SFloatThresholdAndBuff> _加速状态buff;

		// Token: 0x04014ABA RID: 84666
		internal new static int __PropertyOffset_3;

		// Token: 0x04014ABB RID: 84667
		[Nullable(2)]
		private TArray<SFloatThresholdAndBuff> _翱翔加速状态buff;

		// Token: 0x04014ABC RID: 84668
		internal new static int __PropertyOffset_4;

		// Token: 0x04014ABD RID: 84669
		internal new static int __PropertyOffset_5;

		// Token: 0x04014ABE RID: 84670
		[Nullable(2)]
		private TArray<SFloatThresholdAndBuff> _时段buff;

		// Token: 0x04014ABF RID: 84671
		internal new static int __PropertyOffset_6;

		// Token: 0x04014AC0 RID: 84672
		internal new static int __PropertyOffset_7;

		// Token: 0x04014AC1 RID: 84673
		internal new static int __PropertyOffset_8;

		// Token: 0x04014AC2 RID: 84674
		[Nullable(2)]
		private TMap<EMotorPart, long> _撞击buff;

		// Token: 0x04014AC3 RID: 84675
		internal new static int __PropertyOffset_9;

		// Token: 0x04014AC4 RID: 84676
		internal new static int __PropertyOffset_10;

		// Token: 0x04014AC5 RID: 84677
		internal new static int __PropertyOffset_11;

		// Token: 0x04014AC6 RID: 84678
		internal new static int __PropertyOffset_12;

		// Token: 0x04014AC7 RID: 84679
		[Nullable(2)]
		private TArray<long> _常驻buffs;

		// Token: 0x04014AC8 RID: 84680
		internal new static int __PropertyOffset_13;

		// Token: 0x04014AC9 RID: 84681
		internal new static int __PropertyOffset_14;
	}
}
