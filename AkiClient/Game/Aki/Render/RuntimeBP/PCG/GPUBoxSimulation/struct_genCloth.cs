using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C2B RID: 15403
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_genCloth.struct_genCloth")]
	[UnrealStructLayout(128, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class struct_genCloth : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060233CB RID: 144331 RVA: 0x0097CCE4 File Offset: 0x0097AEE4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (struct_genCloth._ScriptStructPtr != 0) ? struct_genCloth._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_genCloth.struct_genCloth", ref struct_genCloth._ScriptStructPtr);
		}

		// Token: 0x17004538 RID: 17720
		// (get) Token: 0x060233CC RID: 144332 RVA: 0x0097CD08 File Offset: 0x0097AF08
		// (set) Token: 0x060233CD RID: 144333 RVA: 0x0097CD18 File Offset: 0x0097AF18
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004539 RID: 17721
		// (get) Token: 0x060233CE RID: 144334 RVA: 0x0097CD29 File Offset: 0x0097AF29
		// (set) Token: 0x060233CF RID: 144335 RVA: 0x0097CD3D File Offset: 0x0097AF3D
		public unsafe FVector Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700453A RID: 17722
		// (get) Token: 0x060233D0 RID: 144336 RVA: 0x0097CD52 File Offset: 0x0097AF52
		// (set) Token: 0x060233D1 RID: 144337 RVA: 0x0097CD62 File Offset: 0x0097AF62
		public unsafe int neighbour1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700453B RID: 17723
		// (get) Token: 0x060233D2 RID: 144338 RVA: 0x0097CD73 File Offset: 0x0097AF73
		// (set) Token: 0x060233D3 RID: 144339 RVA: 0x0097CD83 File Offset: 0x0097AF83
		public unsafe int neighbour2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700453C RID: 17724
		// (get) Token: 0x060233D4 RID: 144340 RVA: 0x0097CD94 File Offset: 0x0097AF94
		// (set) Token: 0x060233D5 RID: 144341 RVA: 0x0097CDA4 File Offset: 0x0097AFA4
		public unsafe int neighbour3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700453D RID: 17725
		// (get) Token: 0x060233D6 RID: 144342 RVA: 0x0097CDB5 File Offset: 0x0097AFB5
		// (set) Token: 0x060233D7 RID: 144343 RVA: 0x0097CDC5 File Offset: 0x0097AFC5
		public unsafe int neighbour4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700453E RID: 17726
		// (get) Token: 0x060233D8 RID: 144344 RVA: 0x0097CDD6 File Offset: 0x0097AFD6
		// (set) Token: 0x060233D9 RID: 144345 RVA: 0x0097CDE6 File Offset: 0x0097AFE6
		public unsafe int neighbour5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700453F RID: 17727
		// (get) Token: 0x060233DA RID: 144346 RVA: 0x0097CDF7 File Offset: 0x0097AFF7
		// (set) Token: 0x060233DB RID: 144347 RVA: 0x0097CE07 File Offset: 0x0097B007
		public unsafe int neighbour6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004540 RID: 17728
		// (get) Token: 0x060233DC RID: 144348 RVA: 0x0097CE18 File Offset: 0x0097B018
		// (set) Token: 0x060233DD RID: 144349 RVA: 0x0097CE28 File Offset: 0x0097B028
		public unsafe int neighbour7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004541 RID: 17729
		// (get) Token: 0x060233DE RID: 144350 RVA: 0x0097CE39 File Offset: 0x0097B039
		// (set) Token: 0x060233DF RID: 144351 RVA: 0x0097CE49 File Offset: 0x0097B049
		public unsafe int neighbour8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004542 RID: 17730
		// (get) Token: 0x060233E0 RID: 144352 RVA: 0x0097CE5A File Offset: 0x0097B05A
		// (set) Token: 0x060233E1 RID: 144353 RVA: 0x0097CE6A File Offset: 0x0097B06A
		public unsafe float dis1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004543 RID: 17731
		// (get) Token: 0x060233E2 RID: 144354 RVA: 0x0097CE7B File Offset: 0x0097B07B
		// (set) Token: 0x060233E3 RID: 144355 RVA: 0x0097CE8B File Offset: 0x0097B08B
		public unsafe float dis2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004544 RID: 17732
		// (get) Token: 0x060233E4 RID: 144356 RVA: 0x0097CE9C File Offset: 0x0097B09C
		// (set) Token: 0x060233E5 RID: 144357 RVA: 0x0097CEAC File Offset: 0x0097B0AC
		public unsafe float dis3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004545 RID: 17733
		// (get) Token: 0x060233E6 RID: 144358 RVA: 0x0097CEBD File Offset: 0x0097B0BD
		// (set) Token: 0x060233E7 RID: 144359 RVA: 0x0097CECD File Offset: 0x0097B0CD
		public unsafe float dis4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004546 RID: 17734
		// (get) Token: 0x060233E8 RID: 144360 RVA: 0x0097CEDE File Offset: 0x0097B0DE
		// (set) Token: 0x060233E9 RID: 144361 RVA: 0x0097CEEE File Offset: 0x0097B0EE
		public unsafe float dis5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004547 RID: 17735
		// (get) Token: 0x060233EA RID: 144362 RVA: 0x0097CEFF File Offset: 0x0097B0FF
		// (set) Token: 0x060233EB RID: 144363 RVA: 0x0097CF0F File Offset: 0x0097B10F
		public unsafe float dis6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004548 RID: 17736
		// (get) Token: 0x060233EC RID: 144364 RVA: 0x0097CF20 File Offset: 0x0097B120
		// (set) Token: 0x060233ED RID: 144365 RVA: 0x0097CF30 File Offset: 0x0097B130
		public unsafe float dis7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004549 RID: 17737
		// (get) Token: 0x060233EE RID: 144366 RVA: 0x0097CF41 File Offset: 0x0097B141
		// (set) Token: 0x060233EF RID: 144367 RVA: 0x0097CF51 File Offset: 0x0097B151
		public unsafe float dis8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700454A RID: 17738
		// (get) Token: 0x060233F0 RID: 144368 RVA: 0x0097CF62 File Offset: 0x0097B162
		// (set) Token: 0x060233F1 RID: 144369 RVA: 0x0097CF76 File Offset: 0x0097B176
		public unsafe FVector N
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700454B RID: 17739
		// (get) Token: 0x060233F2 RID: 144370 RVA: 0x0097CF8B File Offset: 0x0097B18B
		// (set) Token: 0x060233F3 RID: 144371 RVA: 0x0097CF9B File Offset: 0x0097B19B
		public unsafe int isPinned
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700454C RID: 17740
		// (get) Token: 0x060233F4 RID: 144372 RVA: 0x0097CFAC File Offset: 0x0097B1AC
		// (set) Token: 0x060233F5 RID: 144373 RVA: 0x0097CFBC File Offset: 0x0097B1BC
		public unsafe float bend1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x1700454D RID: 17741
		// (get) Token: 0x060233F6 RID: 144374 RVA: 0x0097CFCD File Offset: 0x0097B1CD
		// (set) Token: 0x060233F7 RID: 144375 RVA: 0x0097CFDD File Offset: 0x0097B1DD
		public unsafe float bend2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700454E RID: 17742
		// (get) Token: 0x060233F8 RID: 144376 RVA: 0x0097CFEE File Offset: 0x0097B1EE
		// (set) Token: 0x060233F9 RID: 144377 RVA: 0x0097CFFE File Offset: 0x0097B1FE
		public unsafe float bend3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700454F RID: 17743
		// (get) Token: 0x060233FA RID: 144378 RVA: 0x0097D00F File Offset: 0x0097B20F
		// (set) Token: 0x060233FB RID: 144379 RVA: 0x0097D01F File Offset: 0x0097B21F
		public unsafe float bend4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17004550 RID: 17744
		// (get) Token: 0x060233FC RID: 144380 RVA: 0x0097D030 File Offset: 0x0097B230
		// (set) Token: 0x060233FD RID: 144381 RVA: 0x0097D040 File Offset: 0x0097B240
		public unsafe float bend5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17004551 RID: 17745
		// (get) Token: 0x060233FE RID: 144382 RVA: 0x0097D051 File Offset: 0x0097B251
		// (set) Token: 0x060233FF RID: 144383 RVA: 0x0097D061 File Offset: 0x0097B261
		public unsafe float bend6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17004552 RID: 17746
		// (get) Token: 0x06023400 RID: 144384 RVA: 0x0097D072 File Offset: 0x0097B272
		// (set) Token: 0x06023401 RID: 144385 RVA: 0x0097D082 File Offset: 0x0097B282
		public unsafe float bend7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17004553 RID: 17747
		// (get) Token: 0x06023402 RID: 144386 RVA: 0x0097D093 File Offset: 0x0097B293
		// (set) Token: 0x06023403 RID: 144387 RVA: 0x0097D0A3 File Offset: 0x0097B2A3
		public unsafe float bend8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x06023404 RID: 144388 RVA: 0x0097D0B4 File Offset: 0x0097B2B4
		public struct_genCloth()
		{
		}

		// Token: 0x06023405 RID: 144389 RVA: 0x0097D0BC File Offset: 0x0097B2BC
		public struct_genCloth(int Index, FVector Pos, int neighbour1, int neighbour2, int neighbour3, int neighbour4, int neighbour5, int neighbour6, int neighbour7, int neighbour8, float dis1, float dis2, float dis3, float dis4, float dis5, float dis6, float dis7, float dis8, FVector N, int isPinned, float bend1, float bend2, float bend3, float bend4, float bend5, float bend6, float bend7, float bend8)
		{
			this.Index = Index;
			this.Pos = Pos;
			this.neighbour1 = neighbour1;
			this.neighbour2 = neighbour2;
			this.neighbour3 = neighbour3;
			this.neighbour4 = neighbour4;
			this.neighbour5 = neighbour5;
			this.neighbour6 = neighbour6;
			this.neighbour7 = neighbour7;
			this.neighbour8 = neighbour8;
			this.dis1 = dis1;
			this.dis2 = dis2;
			this.dis3 = dis3;
			this.dis4 = dis4;
			this.dis5 = dis5;
			this.dis6 = dis6;
			this.dis7 = dis7;
			this.dis8 = dis8;
			this.N = N;
			this.isPinned = isPinned;
			this.bend1 = bend1;
			this.bend2 = bend2;
			this.bend3 = bend3;
			this.bend4 = bend4;
			this.bend5 = bend5;
			this.bend6 = bend6;
			this.bend7 = bend7;
			this.bend8 = bend8;
		}

		// Token: 0x06023406 RID: 144390 RVA: 0x0097D1AC File Offset: 0x0097B3AC
		protected override IntPtr GetUStructPtr()
		{
			return struct_genCloth.StaticStruct();
		}

		// Token: 0x06023407 RID: 144391 RVA: 0x0097D1B8 File Offset: 0x0097B3B8
		[NullableContext(2)]
		public struct_genCloth(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06023408 RID: 144392 RVA: 0x0097D1C2 File Offset: 0x0097B3C2
		public struct_genCloth(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06023409 RID: 144393 RVA: 0x0097D1CD File Offset: 0x0097B3CD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new struct_genCloth(Pointer, false, true);
		}

		// Token: 0x0602340A RID: 144394 RVA: 0x0097D1D7 File Offset: 0x0097B3D7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new struct_genCloth(Pointer, MemoryOwner);
		}

		// Token: 0x04011ECF RID: 73423
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_genCloth.struct_genCloth";

		// Token: 0x04011ED0 RID: 73424
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011ED1 RID: 73425
		internal static int __PropertyOffset_0;

		// Token: 0x04011ED2 RID: 73426
		internal static int __PropertyOffset_1;

		// Token: 0x04011ED3 RID: 73427
		internal static int __PropertyOffset_2;

		// Token: 0x04011ED4 RID: 73428
		internal static int __PropertyOffset_3;

		// Token: 0x04011ED5 RID: 73429
		internal static int __PropertyOffset_4;

		// Token: 0x04011ED6 RID: 73430
		internal static int __PropertyOffset_5;

		// Token: 0x04011ED7 RID: 73431
		internal static int __PropertyOffset_6;

		// Token: 0x04011ED8 RID: 73432
		internal static int __PropertyOffset_7;

		// Token: 0x04011ED9 RID: 73433
		internal static int __PropertyOffset_8;

		// Token: 0x04011EDA RID: 73434
		internal static int __PropertyOffset_9;

		// Token: 0x04011EDB RID: 73435
		internal static int __PropertyOffset_10;

		// Token: 0x04011EDC RID: 73436
		internal static int __PropertyOffset_11;

		// Token: 0x04011EDD RID: 73437
		internal static int __PropertyOffset_12;

		// Token: 0x04011EDE RID: 73438
		internal static int __PropertyOffset_13;

		// Token: 0x04011EDF RID: 73439
		internal static int __PropertyOffset_14;

		// Token: 0x04011EE0 RID: 73440
		internal static int __PropertyOffset_15;

		// Token: 0x04011EE1 RID: 73441
		internal static int __PropertyOffset_16;

		// Token: 0x04011EE2 RID: 73442
		internal static int __PropertyOffset_17;

		// Token: 0x04011EE3 RID: 73443
		internal static int __PropertyOffset_18;

		// Token: 0x04011EE4 RID: 73444
		internal static int __PropertyOffset_19;

		// Token: 0x04011EE5 RID: 73445
		internal static int __PropertyOffset_20;

		// Token: 0x04011EE6 RID: 73446
		internal static int __PropertyOffset_21;

		// Token: 0x04011EE7 RID: 73447
		internal static int __PropertyOffset_22;

		// Token: 0x04011EE8 RID: 73448
		internal static int __PropertyOffset_23;

		// Token: 0x04011EE9 RID: 73449
		internal static int __PropertyOffset_24;

		// Token: 0x04011EEA RID: 73450
		internal static int __PropertyOffset_25;

		// Token: 0x04011EEB RID: 73451
		internal static int __PropertyOffset_26;

		// Token: 0x04011EEC RID: 73452
		internal static int __PropertyOffset_27;
	}
}
