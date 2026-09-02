using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F20 RID: 16160
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/BP_AIRaceStrategy.BP_AIRaceStrategy_C")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 185)]
	public class BP_AIRaceStrategy_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028555 RID: 165205 RVA: 0x00A07E59 File Offset: 0x00A06059
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AIRaceStrategy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/BP_AIRaceStrategy.BP_AIRaceStrategy_C");
			}
			return BP_AIRaceStrategy_C._ClassPtr;
		}

		// Token: 0x06028556 RID: 165206 RVA: 0x00A07E80 File Offset: 0x00A06080
		public BP_AIRaceStrategy_C() : this(BuiltinUtils.AllocNativeUObject(BP_AIRaceStrategy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028557 RID: 165207 RVA: 0x00A07EA8 File Offset: 0x00A060A8
		public BP_AIRaceStrategy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AIRaceStrategy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170061DB RID: 25051
		// (get) Token: 0x06028558 RID: 165208 RVA: 0x00A07EDB File Offset: 0x00A060DB
		// (set) Token: 0x06028559 RID: 165209 RVA: 0x00A07EEB File Offset: 0x00A060EB
		public unsafe float DefaultSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061DC RID: 25052
		// (get) Token: 0x0602855A RID: 165210 RVA: 0x00A07EFC File Offset: 0x00A060FC
		// (set) Token: 0x0602855B RID: 165211 RVA: 0x00A07F0C File Offset: 0x00A0610C
		public unsafe float DefaultAcceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170061DD RID: 25053
		// (get) Token: 0x0602855C RID: 165212 RVA: 0x00A07F1D File Offset: 0x00A0611D
		// (set) Token: 0x0602855D RID: 165213 RVA: 0x00A07F2D File Offset: 0x00A0612D
		public unsafe float DefaultDeceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170061DE RID: 25054
		// (get) Token: 0x0602855E RID: 165214 RVA: 0x00A07F40 File Offset: 0x00A06140
		// (set) Token: 0x0602855F RID: 165215 RVA: 0x00A07F79 File Offset: 0x00A06179
		public SAiRaceStrategyCorrectionByDistance CorrectionByDistanceConfig
		{
			get
			{
				base.FastCheckIsValid();
				SAiRaceStrategyCorrectionByDistance result;
				if ((result = this._CorrectionByDistanceConfig) == null)
				{
					result = (this._CorrectionByDistanceConfig = new SAiRaceStrategyCorrectionByDistance(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiRaceStrategyCorrectionByDistance.StaticStruct(), base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170061DF RID: 25055
		// (get) Token: 0x06028560 RID: 165216 RVA: 0x00A07F9C File Offset: 0x00A0619C
		// (set) Token: 0x06028561 RID: 165217 RVA: 0x00A07FD5 File Offset: 0x00A061D5
		public SAiRaceStrategyCorrectionBySpeed CorrectionBySpeedConfig
		{
			get
			{
				base.FastCheckIsValid();
				SAiRaceStrategyCorrectionBySpeed result;
				if ((result = this._CorrectionBySpeedConfig) == null)
				{
					result = (this._CorrectionBySpeedConfig = new SAiRaceStrategyCorrectionBySpeed(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiRaceStrategyCorrectionBySpeed.StaticStruct(), base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170061E0 RID: 25056
		// (get) Token: 0x06028562 RID: 165218 RVA: 0x00A07FF8 File Offset: 0x00A061F8
		// (set) Token: 0x06028563 RID: 165219 RVA: 0x00A08031 File Offset: 0x00A06231
		public SAiRaceStrategyCorrectionByTime CorrectionByTimeConfig
		{
			get
			{
				base.FastCheckIsValid();
				SAiRaceStrategyCorrectionByTime result;
				if ((result = this._CorrectionByTimeConfig) == null)
				{
					result = (this._CorrectionByTimeConfig = new SAiRaceStrategyCorrectionByTime(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SAiRaceStrategyCorrectionByTime.StaticStruct(), base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170061E1 RID: 25057
		// (get) Token: 0x06028564 RID: 165220 RVA: 0x00A08052 File Offset: 0x00A06252
		// (set) Token: 0x06028565 RID: 165221 RVA: 0x00A08066 File Offset: 0x00A06266
		public unsafe SAiRaceStrategyMultiParamFunction CalcTargetSpeedConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIRaceStrategy_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06028566 RID: 165222 RVA: 0x00A0807B File Offset: 0x00A0627B
		protected BP_AIRaceStrategy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015363 RID: 86883
		public new const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/BP_AIRaceStrategy.BP_AIRaceStrategy_C";

		// Token: 0x04015364 RID: 86884
		private static IntPtr _ClassPtr;

		// Token: 0x04015365 RID: 86885
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015366 RID: 86886
		internal static int __PropertyOffset_0;

		// Token: 0x04015367 RID: 86887
		internal static int __PropertyOffset_1;

		// Token: 0x04015368 RID: 86888
		internal static int __PropertyOffset_2;

		// Token: 0x04015369 RID: 86889
		internal static int __PropertyOffset_3;

		// Token: 0x0401536A RID: 86890
		[Nullable(2)]
		private SAiRaceStrategyCorrectionByDistance _CorrectionByDistanceConfig;

		// Token: 0x0401536B RID: 86891
		internal static int __PropertyOffset_4;

		// Token: 0x0401536C RID: 86892
		[Nullable(2)]
		private SAiRaceStrategyCorrectionBySpeed _CorrectionBySpeedConfig;

		// Token: 0x0401536D RID: 86893
		internal static int __PropertyOffset_5;

		// Token: 0x0401536E RID: 86894
		[Nullable(2)]
		private SAiRaceStrategyCorrectionByTime _CorrectionByTimeConfig;

		// Token: 0x0401536F RID: 86895
		internal static int __PropertyOffset_6;
	}
}
