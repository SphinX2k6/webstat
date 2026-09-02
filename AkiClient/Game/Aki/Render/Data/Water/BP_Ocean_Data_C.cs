using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.Data.Water
{
	// Token: 0x02003DA7 RID: 15783
	[UnrealObjectPath("/Game/Aki/Render/Data/Water/BP_Ocean_Data.BP_Ocean_Data_C")]
	[UnrealStructLayout(336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 336)]
	public class BP_Ocean_Data_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026A0F RID: 158223 RVA: 0x009DDA36 File Offset: 0x009DBC36
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Ocean_Data_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/Data/Water/BP_Ocean_Data.BP_Ocean_Data_C");
			}
			return BP_Ocean_Data_C._ClassPtr;
		}

		// Token: 0x06026A10 RID: 158224 RVA: 0x009DDA5C File Offset: 0x009DBC5C
		public BP_Ocean_Data_C() : this(BuiltinUtils.AllocNativeUObject(BP_Ocean_Data_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026A11 RID: 158225 RVA: 0x009DDA84 File Offset: 0x009DBC84
		[NullableContext(1)]
		public BP_Ocean_Data_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Ocean_Data_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005868 RID: 22632
		// (get) Token: 0x06026A12 RID: 158226 RVA: 0x009DDAB7 File Offset: 0x009DBCB7
		// (set) Token: 0x06026A13 RID: 158227 RVA: 0x009DDACB File Offset: 0x009DBCCB
		public unsafe FLinearColor FlickerColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005869 RID: 22633
		// (get) Token: 0x06026A14 RID: 158228 RVA: 0x009DDAE0 File Offset: 0x009DBCE0
		// (set) Token: 0x06026A15 RID: 158229 RVA: 0x009DDAF4 File Offset: 0x009DBCF4
		public unsafe FLinearColor HightLightFlickerColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700586A RID: 22634
		// (get) Token: 0x06026A16 RID: 158230 RVA: 0x009DDB09 File Offset: 0x009DBD09
		// (set) Token: 0x06026A17 RID: 158231 RVA: 0x009DDB19 File Offset: 0x009DBD19
		public unsafe float FlickerDepth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700586B RID: 22635
		// (get) Token: 0x06026A18 RID: 158232 RVA: 0x009DDB2A File Offset: 0x009DBD2A
		// (set) Token: 0x06026A19 RID: 158233 RVA: 0x009DDB3A File Offset: 0x009DBD3A
		public unsafe float FlowmapFlickerScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700586C RID: 22636
		// (get) Token: 0x06026A1A RID: 158234 RVA: 0x009DDB4B File Offset: 0x009DBD4B
		// (set) Token: 0x06026A1B RID: 158235 RVA: 0x009DDB5F File Offset: 0x009DBD5F
		public unsafe FLinearColor FoamColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700586D RID: 22637
		// (get) Token: 0x06026A1C RID: 158236 RVA: 0x009DDB74 File Offset: 0x009DBD74
		// (set) Token: 0x06026A1D RID: 158237 RVA: 0x009DDB84 File Offset: 0x009DBD84
		public unsafe float FlowmapFoamScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700586E RID: 22638
		// (get) Token: 0x06026A1E RID: 158238 RVA: 0x009DDB95 File Offset: 0x009DBD95
		// (set) Token: 0x06026A1F RID: 158239 RVA: 0x009DDBA5 File Offset: 0x009DBDA5
		public unsafe float FoamNormalFlatten
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700586F RID: 22639
		// (get) Token: 0x06026A20 RID: 158240 RVA: 0x009DDBB6 File Offset: 0x009DBDB6
		// (set) Token: 0x06026A21 RID: 158241 RVA: 0x009DDBCA File Offset: 0x009DBDCA
		public unsafe FLinearColor FoamEmissiveColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005870 RID: 22640
		// (get) Token: 0x06026A22 RID: 158242 RVA: 0x009DDBDF File Offset: 0x009DBDDF
		// (set) Token: 0x06026A23 RID: 158243 RVA: 0x009DDBEF File Offset: 0x009DBDEF
		public unsafe float WaveProfileAnimationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005871 RID: 22641
		// (get) Token: 0x06026A24 RID: 158244 RVA: 0x009DDC00 File Offset: 0x009DBE00
		// (set) Token: 0x06026A25 RID: 158245 RVA: 0x009DDC10 File Offset: 0x009DBE10
		public unsafe float WaveProfileDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005872 RID: 22642
		// (get) Token: 0x06026A26 RID: 158246 RVA: 0x009DDC21 File Offset: 0x009DBE21
		// (set) Token: 0x06026A27 RID: 158247 RVA: 0x009DDC31 File Offset: 0x009DBE31
		public unsafe float WaveProfileSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005873 RID: 22643
		// (get) Token: 0x06026A28 RID: 158248 RVA: 0x009DDC42 File Offset: 0x009DBE42
		// (set) Token: 0x06026A29 RID: 158249 RVA: 0x009DDC52 File Offset: 0x009DBE52
		public unsafe float WaveProfileWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005874 RID: 22644
		// (get) Token: 0x06026A2A RID: 158250 RVA: 0x009DDC63 File Offset: 0x009DBE63
		// (set) Token: 0x06026A2B RID: 158251 RVA: 0x009DDC77 File Offset: 0x009DBE77
		public unsafe FLinearColor FluxWaveProfileDecode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17005875 RID: 22645
		// (get) Token: 0x06026A2C RID: 158252 RVA: 0x009DDC8C File Offset: 0x009DBE8C
		// (set) Token: 0x06026A2D RID: 158253 RVA: 0x009DDCA0 File Offset: 0x009DBEA0
		public unsafe FLinearColor ScatteringColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005876 RID: 22646
		// (get) Token: 0x06026A2E RID: 158254 RVA: 0x009DDCB5 File Offset: 0x009DBEB5
		// (set) Token: 0x06026A2F RID: 158255 RVA: 0x009DDCC9 File Offset: 0x009DBEC9
		public unsafe FLinearColor ScatteringShoreline
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005877 RID: 22647
		// (get) Token: 0x06026A30 RID: 158256 RVA: 0x009DDCDE File Offset: 0x009DBEDE
		// (set) Token: 0x06026A31 RID: 158257 RVA: 0x009DDCF2 File Offset: 0x009DBEF2
		public unsafe FLinearColor ScatteringFoam
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005878 RID: 22648
		// (get) Token: 0x06026A32 RID: 158258 RVA: 0x009DDD07 File Offset: 0x009DBF07
		// (set) Token: 0x06026A33 RID: 158259 RVA: 0x009DDD1B File Offset: 0x009DBF1B
		public unsafe FLinearColor ScatteringInside
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17005879 RID: 22649
		// (get) Token: 0x06026A34 RID: 158260 RVA: 0x009DDD30 File Offset: 0x009DBF30
		// (set) Token: 0x06026A35 RID: 158261 RVA: 0x009DDD44 File Offset: 0x009DBF44
		public unsafe FLinearColor AbsorptionColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700587A RID: 22650
		// (get) Token: 0x06026A36 RID: 158262 RVA: 0x009DDD59 File Offset: 0x009DBF59
		// (set) Token: 0x06026A37 RID: 158263 RVA: 0x009DDD6D File Offset: 0x009DBF6D
		public unsafe FLinearColor AbsorptionColorInside
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700587B RID: 22651
		// (get) Token: 0x06026A38 RID: 158264 RVA: 0x009DDD82 File Offset: 0x009DBF82
		// (set) Token: 0x06026A39 RID: 158265 RVA: 0x009DDD92 File Offset: 0x009DBF92
		public unsafe float Anisotropy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700587C RID: 22652
		// (get) Token: 0x06026A3A RID: 158266 RVA: 0x009DDDA3 File Offset: 0x009DBFA3
		// (set) Token: 0x06026A3B RID: 158267 RVA: 0x009DDDB7 File Offset: 0x009DBFB7
		public unsafe FLinearColor ColorScaleBehindWater
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700587D RID: 22653
		// (get) Token: 0x06026A3C RID: 158268 RVA: 0x009DDDCC File Offset: 0x009DBFCC
		// (set) Token: 0x06026A3D RID: 158269 RVA: 0x009DDDE0 File Offset: 0x009DBFE0
		public unsafe FLinearColor WaterColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700587E RID: 22654
		// (get) Token: 0x06026A3E RID: 158270 RVA: 0x009DDDF5 File Offset: 0x009DBFF5
		// (set) Token: 0x06026A3F RID: 158271 RVA: 0x009DDE05 File Offset: 0x009DC005
		public unsafe float CausticBrightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700587F RID: 22655
		// (get) Token: 0x06026A40 RID: 158272 RVA: 0x009DDE16 File Offset: 0x009DC016
		// (set) Token: 0x06026A41 RID: 158273 RVA: 0x009DDE26 File Offset: 0x009DC026
		public unsafe float VelocityScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17005880 RID: 22656
		// (get) Token: 0x06026A42 RID: 158274 RVA: 0x009DDE37 File Offset: 0x009DC037
		// (set) Token: 0x06026A43 RID: 158275 RVA: 0x009DDE47 File Offset: 0x009DC047
		public unsafe float VelocityPow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Ocean_Data_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x06026A44 RID: 158276 RVA: 0x009DDE58 File Offset: 0x009DC058
		protected BP_Ocean_Data_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401418C RID: 82316
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/Data/Water/BP_Ocean_Data.BP_Ocean_Data_C";

		// Token: 0x0401418D RID: 82317
		private static IntPtr _ClassPtr;

		// Token: 0x0401418E RID: 82318
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401418F RID: 82319
		internal static int __PropertyOffset_0;

		// Token: 0x04014190 RID: 82320
		internal static int __PropertyOffset_1;

		// Token: 0x04014191 RID: 82321
		internal static int __PropertyOffset_2;

		// Token: 0x04014192 RID: 82322
		internal static int __PropertyOffset_3;

		// Token: 0x04014193 RID: 82323
		internal static int __PropertyOffset_4;

		// Token: 0x04014194 RID: 82324
		internal static int __PropertyOffset_5;

		// Token: 0x04014195 RID: 82325
		internal static int __PropertyOffset_6;

		// Token: 0x04014196 RID: 82326
		internal static int __PropertyOffset_7;

		// Token: 0x04014197 RID: 82327
		internal static int __PropertyOffset_8;

		// Token: 0x04014198 RID: 82328
		internal static int __PropertyOffset_9;

		// Token: 0x04014199 RID: 82329
		internal static int __PropertyOffset_10;

		// Token: 0x0401419A RID: 82330
		internal static int __PropertyOffset_11;

		// Token: 0x0401419B RID: 82331
		internal static int __PropertyOffset_12;

		// Token: 0x0401419C RID: 82332
		internal static int __PropertyOffset_13;

		// Token: 0x0401419D RID: 82333
		internal static int __PropertyOffset_14;

		// Token: 0x0401419E RID: 82334
		internal static int __PropertyOffset_15;

		// Token: 0x0401419F RID: 82335
		internal static int __PropertyOffset_16;

		// Token: 0x040141A0 RID: 82336
		internal static int __PropertyOffset_17;

		// Token: 0x040141A1 RID: 82337
		internal static int __PropertyOffset_18;

		// Token: 0x040141A2 RID: 82338
		internal static int __PropertyOffset_19;

		// Token: 0x040141A3 RID: 82339
		internal static int __PropertyOffset_20;

		// Token: 0x040141A4 RID: 82340
		internal static int __PropertyOffset_21;

		// Token: 0x040141A5 RID: 82341
		internal static int __PropertyOffset_22;

		// Token: 0x040141A6 RID: 82342
		internal static int __PropertyOffset_23;

		// Token: 0x040141A7 RID: 82343
		internal static int __PropertyOffset_24;
	}
}
