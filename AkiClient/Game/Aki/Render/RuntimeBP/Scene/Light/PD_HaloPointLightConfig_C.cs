using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Light
{
	// Token: 0x02003AAC RID: 15020
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Light/PD_HaloPointLightConfig.PD_HaloPointLightConfig_C")]
	[UnrealStructLayout(208, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 208)]
	public class PD_HaloPointLightConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601FFF0 RID: 131056 RVA: 0x0091F56C File Offset: 0x0091D76C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_HaloPointLightConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Light/PD_HaloPointLightConfig.PD_HaloPointLightConfig_C");
			}
			return PD_HaloPointLightConfig_C._ClassPtr;
		}

		// Token: 0x0601FFF1 RID: 131057 RVA: 0x0091F590 File Offset: 0x0091D790
		public PD_HaloPointLightConfig_C() : this(BuiltinUtils.AllocNativeUObject(PD_HaloPointLightConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601FFF2 RID: 131058 RVA: 0x0091F5B8 File Offset: 0x0091D7B8
		[NullableContext(1)]
		public PD_HaloPointLightConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_HaloPointLightConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003367 RID: 13159
		// (get) Token: 0x0601FFF3 RID: 131059 RVA: 0x0091F5EB File Offset: 0x0091D7EB
		// (set) Token: 0x0601FFF4 RID: 131060 RVA: 0x0091F5FF File Offset: 0x0091D7FF
		public unsafe FVector4 PC_Halo_Type1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17003368 RID: 13160
		// (get) Token: 0x0601FFF5 RID: 131061 RVA: 0x0091F614 File Offset: 0x0091D814
		// (set) Token: 0x0601FFF6 RID: 131062 RVA: 0x0091F628 File Offset: 0x0091D828
		public unsafe FVector4 PC_Halo_Type2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003369 RID: 13161
		// (get) Token: 0x0601FFF7 RID: 131063 RVA: 0x0091F63D File Offset: 0x0091D83D
		// (set) Token: 0x0601FFF8 RID: 131064 RVA: 0x0091F651 File Offset: 0x0091D851
		public unsafe FVector4 PC_Halo_Type3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700336A RID: 13162
		// (get) Token: 0x0601FFF9 RID: 131065 RVA: 0x0091F666 File Offset: 0x0091D866
		// (set) Token: 0x0601FFFA RID: 131066 RVA: 0x0091F67A File Offset: 0x0091D87A
		public unsafe FVector4 PC_Halo_Type4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700336B RID: 13163
		// (get) Token: 0x0601FFFB RID: 131067 RVA: 0x0091F68F File Offset: 0x0091D88F
		// (set) Token: 0x0601FFFC RID: 131068 RVA: 0x0091F6A3 File Offset: 0x0091D8A3
		public unsafe FVector4 Mobile_Halo_Type1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700336C RID: 13164
		// (get) Token: 0x0601FFFD RID: 131069 RVA: 0x0091F6B8 File Offset: 0x0091D8B8
		// (set) Token: 0x0601FFFE RID: 131070 RVA: 0x0091F6CC File Offset: 0x0091D8CC
		public unsafe FVector4 Mobile_Halo_Type2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700336D RID: 13165
		// (get) Token: 0x0601FFFF RID: 131071 RVA: 0x0091F6E1 File Offset: 0x0091D8E1
		// (set) Token: 0x06020000 RID: 131072 RVA: 0x0091F6F5 File Offset: 0x0091D8F5
		public unsafe FVector4 Mobile_Halo_Type3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700336E RID: 13166
		// (get) Token: 0x06020001 RID: 131073 RVA: 0x0091F70A File Offset: 0x0091D90A
		// (set) Token: 0x06020002 RID: 131074 RVA: 0x0091F71E File Offset: 0x0091D91E
		public unsafe FVector4 Mobile_Halo_Type4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_HaloPointLightConfig_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06020003 RID: 131075 RVA: 0x0091F733 File Offset: 0x0091D933
		protected PD_HaloPointLightConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FEE9 RID: 65257
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Light/PD_HaloPointLightConfig.PD_HaloPointLightConfig_C";

		// Token: 0x0400FEEA RID: 65258
		private static IntPtr _ClassPtr;

		// Token: 0x0400FEEB RID: 65259
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FEEC RID: 65260
		internal static int __PropertyOffset_0;

		// Token: 0x0400FEED RID: 65261
		internal static int __PropertyOffset_1;

		// Token: 0x0400FEEE RID: 65262
		internal static int __PropertyOffset_2;

		// Token: 0x0400FEEF RID: 65263
		internal static int __PropertyOffset_3;

		// Token: 0x0400FEF0 RID: 65264
		internal static int __PropertyOffset_4;

		// Token: 0x0400FEF1 RID: 65265
		internal static int __PropertyOffset_5;

		// Token: 0x0400FEF2 RID: 65266
		internal static int __PropertyOffset_6;

		// Token: 0x0400FEF3 RID: 65267
		internal static int __PropertyOffset_7;
	}
}
