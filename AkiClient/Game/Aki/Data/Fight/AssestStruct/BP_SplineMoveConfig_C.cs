using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.AssestStruct
{
	// Token: 0x02003EEE RID: 16110
	[UnrealObjectPath("/Game/Aki/Data/Fight/AssestStruct/BP_SplineMoveConfig.BP_SplineMoveConfig_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 104)]
	public class BP_SplineMoveConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060281BB RID: 164283 RVA: 0x00A0284C File Offset: 0x00A00A4C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineMoveConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Fight/AssestStruct/BP_SplineMoveConfig.BP_SplineMoveConfig_C");
			}
			return BP_SplineMoveConfig_C._ClassPtr;
		}

		// Token: 0x060281BC RID: 164284 RVA: 0x00A02870 File Offset: 0x00A00A70
		public BP_SplineMoveConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineMoveConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060281BD RID: 164285 RVA: 0x00A02898 File Offset: 0x00A00A98
		[NullableContext(1)]
		public BP_SplineMoveConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineMoveConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700608A RID: 24714
		// (get) Token: 0x060281BE RID: 164286 RVA: 0x00A028CB File Offset: 0x00A00ACB
		// (set) Token: 0x060281BF RID: 164287 RVA: 0x00A028DB File Offset: 0x00A00ADB
		public unsafe float TurnRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700608B RID: 24715
		// (get) Token: 0x060281C0 RID: 164288 RVA: 0x00A028EC File Offset: 0x00A00AEC
		// (set) Token: 0x060281C1 RID: 164289 RVA: 0x00A028FC File Offset: 0x00A00AFC
		public unsafe float AirControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700608C RID: 24716
		// (get) Token: 0x060281C2 RID: 164290 RVA: 0x00A0290D File Offset: 0x00A00B0D
		// (set) Token: 0x060281C3 RID: 164291 RVA: 0x00A0291D File Offset: 0x00A00B1D
		public unsafe float JumpHeightRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700608D RID: 24717
		// (get) Token: 0x060281C4 RID: 164292 RVA: 0x00A0292E File Offset: 0x00A00B2E
		// (set) Token: 0x060281C5 RID: 164293 RVA: 0x00A0293E File Offset: 0x00A00B3E
		public unsafe float JumpTimeScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700608E RID: 24718
		// (get) Token: 0x060281C6 RID: 164294 RVA: 0x00A0294F File Offset: 0x00A00B4F
		// (set) Token: 0x060281C7 RID: 164295 RVA: 0x00A0295F File Offset: 0x00A00B5F
		public unsafe float MaxFlySpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700608F RID: 24719
		// (get) Token: 0x060281C8 RID: 164296 RVA: 0x00A02970 File Offset: 0x00A00B70
		// (set) Token: 0x060281C9 RID: 164297 RVA: 0x00A02980 File Offset: 0x00A00B80
		public unsafe float AnsAccel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineMoveConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x060281CA RID: 164298 RVA: 0x00A02991 File Offset: 0x00A00B91
		protected BP_SplineMoveConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040150FF RID: 86271
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Fight/AssestStruct/BP_SplineMoveConfig.BP_SplineMoveConfig_C";

		// Token: 0x04015100 RID: 86272
		private static IntPtr _ClassPtr;

		// Token: 0x04015101 RID: 86273
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015102 RID: 86274
		internal static int __PropertyOffset_0;

		// Token: 0x04015103 RID: 86275
		internal static int __PropertyOffset_1;

		// Token: 0x04015104 RID: 86276
		internal static int __PropertyOffset_2;

		// Token: 0x04015105 RID: 86277
		internal static int __PropertyOffset_3;

		// Token: 0x04015106 RID: 86278
		internal static int __PropertyOffset_4;

		// Token: 0x04015107 RID: 86279
		internal static int __PropertyOffset_5;
	}
}
