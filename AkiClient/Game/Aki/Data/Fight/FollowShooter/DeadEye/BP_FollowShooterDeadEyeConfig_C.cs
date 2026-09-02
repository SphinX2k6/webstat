using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.FollowShooter.DeadEye
{
	// Token: 0x02003EE0 RID: 16096
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/FollowShooter/DeadEye/BP_FollowShooterDeadEyeConfig.BP_FollowShooterDeadEyeConfig_C")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 164)]
	public class BP_FollowShooterDeadEyeConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602816B RID: 164203 RVA: 0x00A02244 File Offset: 0x00A00444
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FollowShooterDeadEyeConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/FollowShooter/DeadEye/BP_FollowShooterDeadEyeConfig.BP_FollowShooterDeadEyeConfig_C");
			}
			return BP_FollowShooterDeadEyeConfig_C._ClassPtr;
		}

		// Token: 0x0602816C RID: 164204 RVA: 0x00A02268 File Offset: 0x00A00468
		public BP_FollowShooterDeadEyeConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FollowShooterDeadEyeConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602816D RID: 164205 RVA: 0x00A02290 File Offset: 0x00A00490
		public BP_FollowShooterDeadEyeConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FollowShooterDeadEyeConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700607E RID: 24702
		// (get) Token: 0x0602816E RID: 164206 RVA: 0x00A022C4 File Offset: 0x00A004C4
		// (set) Token: 0x0602816F RID: 164207 RVA: 0x00A022FD File Offset: 0x00A004FD
		public TMap<FName, SDeadEyeConfig> DeadEyeConfig
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SDeadEyeConfig> result;
				if ((result = this._DeadEyeConfig) == null)
				{
					result = (this._DeadEyeConfig = new TMap<FName, SDeadEyeConfig>(base.NativePtr + (IntPtr)BP_FollowShooterDeadEyeConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.DeadEyeConfig.CopyAssign(value);
			}
		}

		// Token: 0x1700607F RID: 24703
		// (get) Token: 0x06028170 RID: 164208 RVA: 0x00A0230B File Offset: 0x00A0050B
		// (set) Token: 0x06028171 RID: 164209 RVA: 0x00A0231B File Offset: 0x00A0051B
		public unsafe float FinishDelayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FollowShooterDeadEyeConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FollowShooterDeadEyeConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x06028172 RID: 164210 RVA: 0x00A0232C File Offset: 0x00A0052C
		protected BP_FollowShooterDeadEyeConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040150C1 RID: 86209
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/FollowShooter/DeadEye/BP_FollowShooterDeadEyeConfig.BP_FollowShooterDeadEyeConfig_C";

		// Token: 0x040150C2 RID: 86210
		private static IntPtr _ClassPtr;

		// Token: 0x040150C3 RID: 86211
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040150C4 RID: 86212
		internal static int __PropertyOffset_0;

		// Token: 0x040150C5 RID: 86213
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SDeadEyeConfig> _DeadEyeConfig;

		// Token: 0x040150C6 RID: 86214
		internal static int __PropertyOffset_1;
	}
}
