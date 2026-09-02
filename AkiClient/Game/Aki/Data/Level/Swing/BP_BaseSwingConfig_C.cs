using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Swing
{
	// Token: 0x02003E6E RID: 15982
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Swing/BP_BaseSwingConfig.BP_BaseSwingConfig_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 157)]
	public class BP_BaseSwingConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060277E2 RID: 161762 RVA: 0x009F30EE File Offset: 0x009F12EE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseSwingConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Swing/BP_BaseSwingConfig.BP_BaseSwingConfig_C");
			}
			return BP_BaseSwingConfig_C._ClassPtr;
		}

		// Token: 0x060277E3 RID: 161763 RVA: 0x009F3114 File Offset: 0x009F1314
		public BP_BaseSwingConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseSwingConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060277E4 RID: 161764 RVA: 0x009F313C File Offset: 0x009F133C
		public BP_BaseSwingConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseSwingConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D17 RID: 23831
		// (get) Token: 0x060277E5 RID: 161765 RVA: 0x009F316F File Offset: 0x009F136F
		// (set) Token: 0x060277E6 RID: 161766 RVA: 0x009F3183 File Offset: 0x009F1383
		public unsafe FVector AttachLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D18 RID: 23832
		// (get) Token: 0x060277E7 RID: 161767 RVA: 0x009F3198 File Offset: 0x009F1398
		// (set) Token: 0x060277E8 RID: 161768 RVA: 0x009F31A8 File Offset: 0x009F13A8
		public unsafe int SitOnModelBufferTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005D19 RID: 23833
		// (get) Token: 0x060277E9 RID: 161769 RVA: 0x009F31B9 File Offset: 0x009F13B9
		// (set) Token: 0x060277EA RID: 161770 RVA: 0x009F31C9 File Offset: 0x009F13C9
		public unsafe int StandUpModelBufferTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005D1A RID: 23834
		// (get) Token: 0x060277EB RID: 161771 RVA: 0x009F31DA File Offset: 0x009F13DA
		// (set) Token: 0x060277EC RID: 161772 RVA: 0x009F31EE File Offset: 0x009F13EE
		public unsafe string AttachSocket
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005D1B RID: 23835
		// (get) Token: 0x060277ED RID: 161773 RVA: 0x009F3203 File Offset: 0x009F1403
		// (set) Token: 0x060277EE RID: 161774 RVA: 0x009F3217 File Offset: 0x009F1417
		public unsafe FVector AttachRotator
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005D1C RID: 23836
		// (get) Token: 0x060277EF RID: 161775 RVA: 0x009F322C File Offset: 0x009F142C
		// (set) Token: 0x060277F0 RID: 161776 RVA: 0x009F3240 File Offset: 0x009F1440
		public unsafe string ReferenceActor
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005D1D RID: 23837
		// (get) Token: 0x060277F1 RID: 161777 RVA: 0x009F3255 File Offset: 0x009F1455
		// (set) Token: 0x060277F2 RID: 161778 RVA: 0x009F3265 File Offset: 0x009F1465
		public unsafe int StandUpMoveAwayDist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005D1E RID: 23838
		// (get) Token: 0x060277F3 RID: 161779 RVA: 0x009F3276 File Offset: 0x009F1476
		// (set) Token: 0x060277F4 RID: 161780 RVA: 0x009F3286 File Offset: 0x009F1486
		public unsafe bool ExitImmediately
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseSwingConfig_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x060277F5 RID: 161781 RVA: 0x009F3297 File Offset: 0x009F1497
		protected BP_BaseSwingConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014AFE RID: 84734
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Swing/BP_BaseSwingConfig.BP_BaseSwingConfig_C";

		// Token: 0x04014AFF RID: 84735
		private static IntPtr _ClassPtr;

		// Token: 0x04014B00 RID: 84736
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B01 RID: 84737
		internal static int __PropertyOffset_0;

		// Token: 0x04014B02 RID: 84738
		internal static int __PropertyOffset_1;

		// Token: 0x04014B03 RID: 84739
		internal static int __PropertyOffset_2;

		// Token: 0x04014B04 RID: 84740
		internal static int __PropertyOffset_3;

		// Token: 0x04014B05 RID: 84741
		internal static int __PropertyOffset_4;

		// Token: 0x04014B06 RID: 84742
		internal static int __PropertyOffset_5;

		// Token: 0x04014B07 RID: 84743
		internal static int __PropertyOffset_6;

		// Token: 0x04014B08 RID: 84744
		internal static int __PropertyOffset_7;
	}
}
