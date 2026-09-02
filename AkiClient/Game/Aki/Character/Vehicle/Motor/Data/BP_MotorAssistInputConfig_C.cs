using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Data
{
	// Token: 0x02003FA8 RID: 16296
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Data/BP_MotorAssistInputConfig.BP_MotorAssistInputConfig_C")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 195)]
	public class BP_MotorAssistInputConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028E94 RID: 167572 RVA: 0x00A1A714 File Offset: 0x00A18914
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MotorAssistInputConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Data/BP_MotorAssistInputConfig.BP_MotorAssistInputConfig_C");
			}
			return BP_MotorAssistInputConfig_C._ClassPtr;
		}

		// Token: 0x06028E95 RID: 167573 RVA: 0x00A1A738 File Offset: 0x00A18938
		public BP_MotorAssistInputConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_MotorAssistInputConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028E96 RID: 167574 RVA: 0x00A1A760 File Offset: 0x00A18960
		public BP_MotorAssistInputConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MotorAssistInputConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064CD RID: 25805
		// (get) Token: 0x06028E97 RID: 167575 RVA: 0x00A1A793 File Offset: 0x00A18993
		// (set) Token: 0x06028E98 RID: 167576 RVA: 0x00A1A7A3 File Offset: 0x00A189A3
		public unsafe int HoldThrottleTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170064CE RID: 25806
		// (get) Token: 0x06028E99 RID: 167577 RVA: 0x00A1A7B4 File Offset: 0x00A189B4
		// (set) Token: 0x06028E9A RID: 167578 RVA: 0x00A1A7ED File Offset: 0x00A189ED
		public FGameplayTagContainer ForbidHoldThrottleTag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ForbidHoldThrottleTag) == null)
				{
					result = (this._ForbidHoldThrottleTag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064CF RID: 25807
		// (get) Token: 0x06028E9B RID: 167579 RVA: 0x00A1A810 File Offset: 0x00A18A10
		// (set) Token: 0x06028E9C RID: 167580 RVA: 0x00A1A849 File Offset: 0x00A18A49
		public TArray<int> HoldThrottleSkill
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._HoldThrottleSkill) == null)
				{
					result = (this._HoldThrottleSkill = new TArray<int>(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.HoldThrottleSkill.CopyAssign(value);
			}
		}

		// Token: 0x170064D0 RID: 25808
		// (get) Token: 0x06028E9D RID: 167581 RVA: 0x00A1A857 File Offset: 0x00A18A57
		// (set) Token: 0x06028E9E RID: 167582 RVA: 0x00A1A867 File Offset: 0x00A18A67
		public unsafe int NitroBoostTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170064D1 RID: 25809
		// (get) Token: 0x06028E9F RID: 167583 RVA: 0x00A1A878 File Offset: 0x00A18A78
		// (set) Token: 0x06028EA0 RID: 167584 RVA: 0x00A1A8B1 File Offset: 0x00A18AB1
		public FGameplayTagContainer ForbidNitroBoostTag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ForbidNitroBoostTag) == null)
				{
					result = (this._ForbidNitroBoostTag = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064D2 RID: 25810
		// (get) Token: 0x06028EA1 RID: 167585 RVA: 0x00A1A8D4 File Offset: 0x00A18AD4
		// (set) Token: 0x06028EA2 RID: 167586 RVA: 0x00A1A90D File Offset: 0x00A18B0D
		public TArray<int> NitroBoostSkill
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._NitroBoostSkill) == null)
				{
					result = (this._NitroBoostSkill = new TArray<int>(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.NitroBoostSkill.CopyAssign(value);
			}
		}

		// Token: 0x170064D3 RID: 25811
		// (get) Token: 0x06028EA3 RID: 167587 RVA: 0x00A1A91B File Offset: 0x00A18B1B
		// (set) Token: 0x06028EA4 RID: 167588 RVA: 0x00A1A92B File Offset: 0x00A18B2B
		public unsafe bool DebugHoldThrottle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064D4 RID: 25812
		// (get) Token: 0x06028EA5 RID: 167589 RVA: 0x00A1A93C File Offset: 0x00A18B3C
		// (set) Token: 0x06028EA6 RID: 167590 RVA: 0x00A1A94C File Offset: 0x00A18B4C
		public unsafe bool DebugNitroBoost
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064D5 RID: 25813
		// (get) Token: 0x06028EA7 RID: 167591 RVA: 0x00A1A95D File Offset: 0x00A18B5D
		// (set) Token: 0x06028EA8 RID: 167592 RVA: 0x00A1A96D File Offset: 0x00A18B6D
		public unsafe bool DebugAssistDrift
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorAssistInputConfig_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028EA9 RID: 167593 RVA: 0x00A1A97E File Offset: 0x00A18B7E
		protected BP_MotorAssistInputConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015A2C RID: 88620
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Data/BP_MotorAssistInputConfig.BP_MotorAssistInputConfig_C";

		// Token: 0x04015A2D RID: 88621
		private static IntPtr _ClassPtr;

		// Token: 0x04015A2E RID: 88622
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015A2F RID: 88623
		internal static int __PropertyOffset_0;

		// Token: 0x04015A30 RID: 88624
		internal static int __PropertyOffset_1;

		// Token: 0x04015A31 RID: 88625
		[Nullable(2)]
		private FGameplayTagContainer _ForbidHoldThrottleTag;

		// Token: 0x04015A32 RID: 88626
		internal static int __PropertyOffset_2;

		// Token: 0x04015A33 RID: 88627
		[Nullable(2)]
		private TArray<int> _HoldThrottleSkill;

		// Token: 0x04015A34 RID: 88628
		internal static int __PropertyOffset_3;

		// Token: 0x04015A35 RID: 88629
		internal static int __PropertyOffset_4;

		// Token: 0x04015A36 RID: 88630
		[Nullable(2)]
		private FGameplayTagContainer _ForbidNitroBoostTag;

		// Token: 0x04015A37 RID: 88631
		internal static int __PropertyOffset_5;

		// Token: 0x04015A38 RID: 88632
		[Nullable(2)]
		private TArray<int> _NitroBoostSkill;

		// Token: 0x04015A39 RID: 88633
		internal static int __PropertyOffset_6;

		// Token: 0x04015A3A RID: 88634
		internal static int __PropertyOffset_7;

		// Token: 0x04015A3B RID: 88635
		internal static int __PropertyOffset_8;
	}
}
