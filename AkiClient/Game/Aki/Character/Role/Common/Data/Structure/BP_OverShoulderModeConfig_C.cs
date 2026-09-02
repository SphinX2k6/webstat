using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004006 RID: 16390
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_OverShoulderModeConfig.BP_OverShoulderModeConfig_C")]
	[UnrealStructLayout(144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 144)]
	public class BP_OverShoulderModeConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A91F RID: 174367 RVA: 0x00A5CEEF File Offset: 0x00A5B0EF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_OverShoulderModeConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_OverShoulderModeConfig.BP_OverShoulderModeConfig_C");
			}
			return BP_OverShoulderModeConfig_C._ClassPtr;
		}

		// Token: 0x0602A920 RID: 174368 RVA: 0x00A5CF14 File Offset: 0x00A5B114
		public BP_OverShoulderModeConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_OverShoulderModeConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A921 RID: 174369 RVA: 0x00A5CF3C File Offset: 0x00A5B13C
		public BP_OverShoulderModeConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_OverShoulderModeConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006ECA RID: 28362
		// (get) Token: 0x0602A922 RID: 174370 RVA: 0x00A5CF6F File Offset: 0x00A5B16F
		// (set) Token: 0x0602A923 RID: 174371 RVA: 0x00A5CF7F File Offset: 0x00A5B17F
		public unsafe float MinTurnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006ECB RID: 28363
		// (get) Token: 0x0602A924 RID: 174372 RVA: 0x00A5CF90 File Offset: 0x00A5B190
		// (set) Token: 0x0602A925 RID: 174373 RVA: 0x00A5CFA0 File Offset: 0x00A5B1A0
		public unsafe float MaxTurnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006ECC RID: 28364
		// (get) Token: 0x0602A926 RID: 174374 RVA: 0x00A5CFB1 File Offset: 0x00A5B1B1
		// (set) Token: 0x0602A927 RID: 174375 RVA: 0x00A5CFC1 File Offset: 0x00A5B1C1
		public unsafe float LerpBeginDeg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006ECD RID: 28365
		// (get) Token: 0x0602A928 RID: 174376 RVA: 0x00A5CFD2 File Offset: 0x00A5B1D2
		// (set) Token: 0x0602A929 RID: 174377 RVA: 0x00A5CFE6 File Offset: 0x00A5B1E6
		[Nullable(2)]
		public unsafe UCurveFloat LerpCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + BP_OverShoulderModeConfig_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_OverShoulderModeConfig_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17006ECE RID: 28366
		// (get) Token: 0x0602A92A RID: 174378 RVA: 0x00A5CFFB File Offset: 0x00A5B1FB
		// (set) Token: 0x0602A92B RID: 174379 RVA: 0x00A5D00B File Offset: 0x00A5B20B
		public unsafe float LerpPow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006ECF RID: 28367
		// (get) Token: 0x0602A92C RID: 174380 RVA: 0x00A5D01C File Offset: 0x00A5B21C
		// (set) Token: 0x0602A92D RID: 174381 RVA: 0x00A5D02C File Offset: 0x00A5B22C
		public unsafe float SprintExitInputDegAbs
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17006ED0 RID: 28368
		// (get) Token: 0x0602A92E RID: 174382 RVA: 0x00A5D040 File Offset: 0x00A5B240
		// (set) Token: 0x0602A92F RID: 174383 RVA: 0x00A5D079 File Offset: 0x00A5B279
		public FGameplayTagContainer TagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._TagList) == null)
				{
					result = (this._TagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_OverShoulderModeConfig_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602A930 RID: 174384 RVA: 0x00A5D09A File Offset: 0x00A5B29A
		protected BP_OverShoulderModeConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017268 RID: 94824
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_OverShoulderModeConfig.BP_OverShoulderModeConfig_C";

		// Token: 0x04017269 RID: 94825
		private static IntPtr _ClassPtr;

		// Token: 0x0401726A RID: 94826
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401726B RID: 94827
		internal static int __PropertyOffset_0;

		// Token: 0x0401726C RID: 94828
		internal static int __PropertyOffset_1;

		// Token: 0x0401726D RID: 94829
		internal static int __PropertyOffset_2;

		// Token: 0x0401726E RID: 94830
		internal static int __PropertyOffset_3;

		// Token: 0x0401726F RID: 94831
		internal static int __PropertyOffset_4;

		// Token: 0x04017270 RID: 94832
		internal static int __PropertyOffset_5;

		// Token: 0x04017271 RID: 94833
		internal static int __PropertyOffset_6;

		// Token: 0x04017272 RID: 94834
		[Nullable(2)]
		private FGameplayTagContainer _TagList;
	}
}
