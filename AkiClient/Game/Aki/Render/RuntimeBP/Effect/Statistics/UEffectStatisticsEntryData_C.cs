using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Statistics
{
	// Token: 0x02003D2A RID: 15658
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Statistics/UEffectStatisticsEntryData.UEffectStatisticsEntryData_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 121)]
	public class UEffectStatisticsEntryData_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025E06 RID: 155142 RVA: 0x009C77FD File Offset: 0x009C59FD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (UEffectStatisticsEntryData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Statistics/UEffectStatisticsEntryData.UEffectStatisticsEntryData_C");
			}
			return UEffectStatisticsEntryData_C._ClassPtr;
		}

		// Token: 0x06025E07 RID: 155143 RVA: 0x009C7824 File Offset: 0x009C5A24
		public UEffectStatisticsEntryData_C() : this(BuiltinUtils.AllocNativeUObject(UEffectStatisticsEntryData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025E08 RID: 155144 RVA: 0x009C784C File Offset: 0x009C5A4C
		public UEffectStatisticsEntryData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(UEffectStatisticsEntryData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005434 RID: 21556
		// (get) Token: 0x06025E09 RID: 155145 RVA: 0x009C787F File Offset: 0x009C5A7F
		// (set) Token: 0x06025E0A RID: 155146 RVA: 0x009C7893 File Offset: 0x009C5A93
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005435 RID: 21557
		// (get) Token: 0x06025E0B RID: 155147 RVA: 0x009C78A8 File Offset: 0x009C5AA8
		// (set) Token: 0x06025E0C RID: 155148 RVA: 0x009C78B8 File Offset: 0x009C5AB8
		public unsafe float ExistingTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005436 RID: 21558
		// (get) Token: 0x06025E0D RID: 155149 RVA: 0x009C78C9 File Offset: 0x009C5AC9
		// (set) Token: 0x06025E0E RID: 155150 RVA: 0x009C78D9 File Offset: 0x009C5AD9
		public unsafe float DistanceToCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005437 RID: 21559
		// (get) Token: 0x06025E0F RID: 155151 RVA: 0x009C78EA File Offset: 0x009C5AEA
		// (set) Token: 0x06025E10 RID: 155152 RVA: 0x009C78FA File Offset: 0x009C5AFA
		public unsafe int Importance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005438 RID: 21560
		// (get) Token: 0x06025E11 RID: 155153 RVA: 0x009C790B File Offset: 0x009C5B0B
		// (set) Token: 0x06025E12 RID: 155154 RVA: 0x009C791F File Offset: 0x009C5B1F
		public unsafe string Author
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17005439 RID: 21561
		// (get) Token: 0x06025E13 RID: 155155 RVA: 0x009C7934 File Offset: 0x009C5B34
		// (set) Token: 0x06025E14 RID: 155156 RVA: 0x009C7944 File Offset: 0x009C5B44
		public unsafe int TickCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700543A RID: 21562
		// (get) Token: 0x06025E15 RID: 155157 RVA: 0x009C7955 File Offset: 0x009C5B55
		// (set) Token: 0x06025E16 RID: 155158 RVA: 0x009C7965 File Offset: 0x009C5B65
		public unsafe int CheckType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700543B RID: 21563
		// (get) Token: 0x06025E17 RID: 155159 RVA: 0x009C7976 File Offset: 0x009C5B76
		// (set) Token: 0x06025E18 RID: 155160 RVA: 0x009C7986 File Offset: 0x009C5B86
		public unsafe int FactoryType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700543C RID: 21564
		// (get) Token: 0x06025E19 RID: 155161 RVA: 0x009C7997 File Offset: 0x009C5B97
		// (set) Token: 0x06025E1A RID: 155162 RVA: 0x009C79AB File Offset: 0x009C5BAB
		public unsafe FVector Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700543D RID: 21565
		// (get) Token: 0x06025E1B RID: 155163 RVA: 0x009C79C0 File Offset: 0x009C5BC0
		// (set) Token: 0x06025E1C RID: 155164 RVA: 0x009C79D0 File Offset: 0x009C5BD0
		public unsafe bool IsPlaying
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)UEffectStatisticsEntryData_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025E1D RID: 155165 RVA: 0x009C79E1 File Offset: 0x009C5BE1
		protected UEffectStatisticsEntryData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013945 RID: 80197
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Statistics/UEffectStatisticsEntryData.UEffectStatisticsEntryData_C";

		// Token: 0x04013946 RID: 80198
		private static IntPtr _ClassPtr;

		// Token: 0x04013947 RID: 80199
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013948 RID: 80200
		internal static int __PropertyOffset_0;

		// Token: 0x04013949 RID: 80201
		internal static int __PropertyOffset_1;

		// Token: 0x0401394A RID: 80202
		internal static int __PropertyOffset_2;

		// Token: 0x0401394B RID: 80203
		internal static int __PropertyOffset_3;

		// Token: 0x0401394C RID: 80204
		internal static int __PropertyOffset_4;

		// Token: 0x0401394D RID: 80205
		internal static int __PropertyOffset_5;

		// Token: 0x0401394E RID: 80206
		internal static int __PropertyOffset_6;

		// Token: 0x0401394F RID: 80207
		internal static int __PropertyOffset_7;

		// Token: 0x04013950 RID: 80208
		internal static int __PropertyOffset_8;

		// Token: 0x04013951 RID: 80209
		internal static int __PropertyOffset_9;
	}
}
