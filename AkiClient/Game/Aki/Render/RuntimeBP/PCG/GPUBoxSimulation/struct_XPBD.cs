using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C2D RID: 15405
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_XPBD.struct_XPBD")]
	[UnrealStructLayout(92, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 92)]
	public class struct_XPBD : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06023453 RID: 144467 RVA: 0x0097D798 File Offset: 0x0097B998
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (struct_XPBD._ScriptStructPtr != 0) ? struct_XPBD._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_XPBD.struct_XPBD", ref struct_XPBD._ScriptStructPtr);
		}

		// Token: 0x17004574 RID: 17780
		// (get) Token: 0x06023454 RID: 144468 RVA: 0x0097D7BC File Offset: 0x0097B9BC
		// (set) Token: 0x06023455 RID: 144469 RVA: 0x0097D7CC File Offset: 0x0097B9CC
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004575 RID: 17781
		// (get) Token: 0x06023456 RID: 144470 RVA: 0x0097D7DD File Offset: 0x0097B9DD
		// (set) Token: 0x06023457 RID: 144471 RVA: 0x0097D7F1 File Offset: 0x0097B9F1
		public unsafe FVector Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004576 RID: 17782
		// (get) Token: 0x06023458 RID: 144472 RVA: 0x0097D806 File Offset: 0x0097BA06
		// (set) Token: 0x06023459 RID: 144473 RVA: 0x0097D816 File Offset: 0x0097BA16
		public unsafe int neighbour1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004577 RID: 17783
		// (get) Token: 0x0602345A RID: 144474 RVA: 0x0097D827 File Offset: 0x0097BA27
		// (set) Token: 0x0602345B RID: 144475 RVA: 0x0097D837 File Offset: 0x0097BA37
		public unsafe int neighbour2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004578 RID: 17784
		// (get) Token: 0x0602345C RID: 144476 RVA: 0x0097D848 File Offset: 0x0097BA48
		// (set) Token: 0x0602345D RID: 144477 RVA: 0x0097D858 File Offset: 0x0097BA58
		public unsafe int neighbour3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004579 RID: 17785
		// (get) Token: 0x0602345E RID: 144478 RVA: 0x0097D869 File Offset: 0x0097BA69
		// (set) Token: 0x0602345F RID: 144479 RVA: 0x0097D879 File Offset: 0x0097BA79
		public unsafe int neighbour4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700457A RID: 17786
		// (get) Token: 0x06023460 RID: 144480 RVA: 0x0097D88A File Offset: 0x0097BA8A
		// (set) Token: 0x06023461 RID: 144481 RVA: 0x0097D89A File Offset: 0x0097BA9A
		public unsafe int neighbour5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700457B RID: 17787
		// (get) Token: 0x06023462 RID: 144482 RVA: 0x0097D8AB File Offset: 0x0097BAAB
		// (set) Token: 0x06023463 RID: 144483 RVA: 0x0097D8BB File Offset: 0x0097BABB
		public unsafe int neighbour6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700457C RID: 17788
		// (get) Token: 0x06023464 RID: 144484 RVA: 0x0097D8CC File Offset: 0x0097BACC
		// (set) Token: 0x06023465 RID: 144485 RVA: 0x0097D8DC File Offset: 0x0097BADC
		public unsafe float dis1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700457D RID: 17789
		// (get) Token: 0x06023466 RID: 144486 RVA: 0x0097D8ED File Offset: 0x0097BAED
		// (set) Token: 0x06023467 RID: 144487 RVA: 0x0097D8FD File Offset: 0x0097BAFD
		public unsafe float dis2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700457E RID: 17790
		// (get) Token: 0x06023468 RID: 144488 RVA: 0x0097D90E File Offset: 0x0097BB0E
		// (set) Token: 0x06023469 RID: 144489 RVA: 0x0097D91E File Offset: 0x0097BB1E
		public unsafe float dis3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700457F RID: 17791
		// (get) Token: 0x0602346A RID: 144490 RVA: 0x0097D92F File Offset: 0x0097BB2F
		// (set) Token: 0x0602346B RID: 144491 RVA: 0x0097D93F File Offset: 0x0097BB3F
		public unsafe float dis4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004580 RID: 17792
		// (get) Token: 0x0602346C RID: 144492 RVA: 0x0097D950 File Offset: 0x0097BB50
		// (set) Token: 0x0602346D RID: 144493 RVA: 0x0097D960 File Offset: 0x0097BB60
		public unsafe float dis5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004581 RID: 17793
		// (get) Token: 0x0602346E RID: 144494 RVA: 0x0097D971 File Offset: 0x0097BB71
		// (set) Token: 0x0602346F RID: 144495 RVA: 0x0097D981 File Offset: 0x0097BB81
		public unsafe float dis6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004582 RID: 17794
		// (get) Token: 0x06023470 RID: 144496 RVA: 0x0097D992 File Offset: 0x0097BB92
		// (set) Token: 0x06023471 RID: 144497 RVA: 0x0097D9A6 File Offset: 0x0097BBA6
		public unsafe FVector N
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004583 RID: 17795
		// (get) Token: 0x06023472 RID: 144498 RVA: 0x0097D9BB File Offset: 0x0097BBBB
		// (set) Token: 0x06023473 RID: 144499 RVA: 0x0097D9CB File Offset: 0x0097BBCB
		public unsafe int neighbour7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004584 RID: 17796
		// (get) Token: 0x06023474 RID: 144500 RVA: 0x0097D9DC File Offset: 0x0097BBDC
		// (set) Token: 0x06023475 RID: 144501 RVA: 0x0097D9EC File Offset: 0x0097BBEC
		public unsafe int neighbour8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004585 RID: 17797
		// (get) Token: 0x06023476 RID: 144502 RVA: 0x0097D9FD File Offset: 0x0097BBFD
		// (set) Token: 0x06023477 RID: 144503 RVA: 0x0097DA0D File Offset: 0x0097BC0D
		public unsafe float dis7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004586 RID: 17798
		// (get) Token: 0x06023478 RID: 144504 RVA: 0x0097DA1E File Offset: 0x0097BC1E
		// (set) Token: 0x06023479 RID: 144505 RVA: 0x0097DA2E File Offset: 0x0097BC2E
		public unsafe float dis8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_XPBD.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x0602347A RID: 144506 RVA: 0x0097DA3F File Offset: 0x0097BC3F
		public struct_XPBD()
		{
		}

		// Token: 0x0602347B RID: 144507 RVA: 0x0097DA48 File Offset: 0x0097BC48
		public struct_XPBD(int Index, FVector Pos, int neighbour1, int neighbour2, int neighbour3, int neighbour4, int neighbour5, int neighbour6, float dis1, float dis2, float dis3, float dis4, float dis5, float dis6, FVector N, int neighbour7, int neighbour8, float dis7, float dis8)
		{
			this.Index = Index;
			this.Pos = Pos;
			this.neighbour1 = neighbour1;
			this.neighbour2 = neighbour2;
			this.neighbour3 = neighbour3;
			this.neighbour4 = neighbour4;
			this.neighbour5 = neighbour5;
			this.neighbour6 = neighbour6;
			this.dis1 = dis1;
			this.dis2 = dis2;
			this.dis3 = dis3;
			this.dis4 = dis4;
			this.dis5 = dis5;
			this.dis6 = dis6;
			this.N = N;
			this.neighbour7 = neighbour7;
			this.neighbour8 = neighbour8;
			this.dis7 = dis7;
			this.dis8 = dis8;
		}

		// Token: 0x0602347C RID: 144508 RVA: 0x0097DAF0 File Offset: 0x0097BCF0
		protected override IntPtr GetUStructPtr()
		{
			return struct_XPBD.StaticStruct();
		}

		// Token: 0x0602347D RID: 144509 RVA: 0x0097DAFC File Offset: 0x0097BCFC
		[NullableContext(2)]
		public struct_XPBD(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602347E RID: 144510 RVA: 0x0097DB06 File Offset: 0x0097BD06
		public struct_XPBD(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602347F RID: 144511 RVA: 0x0097DB11 File Offset: 0x0097BD11
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new struct_XPBD(Pointer, false, true);
		}

		// Token: 0x06023480 RID: 144512 RVA: 0x0097DB1B File Offset: 0x0097BD1B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new struct_XPBD(Pointer, MemoryOwner);
		}

		// Token: 0x04011F0F RID: 73487
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_XPBD.struct_XPBD";

		// Token: 0x04011F10 RID: 73488
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011F11 RID: 73489
		internal static int __PropertyOffset_0;

		// Token: 0x04011F12 RID: 73490
		internal static int __PropertyOffset_1;

		// Token: 0x04011F13 RID: 73491
		internal static int __PropertyOffset_2;

		// Token: 0x04011F14 RID: 73492
		internal static int __PropertyOffset_3;

		// Token: 0x04011F15 RID: 73493
		internal static int __PropertyOffset_4;

		// Token: 0x04011F16 RID: 73494
		internal static int __PropertyOffset_5;

		// Token: 0x04011F17 RID: 73495
		internal static int __PropertyOffset_6;

		// Token: 0x04011F18 RID: 73496
		internal static int __PropertyOffset_7;

		// Token: 0x04011F19 RID: 73497
		internal static int __PropertyOffset_8;

		// Token: 0x04011F1A RID: 73498
		internal static int __PropertyOffset_9;

		// Token: 0x04011F1B RID: 73499
		internal static int __PropertyOffset_10;

		// Token: 0x04011F1C RID: 73500
		internal static int __PropertyOffset_11;

		// Token: 0x04011F1D RID: 73501
		internal static int __PropertyOffset_12;

		// Token: 0x04011F1E RID: 73502
		internal static int __PropertyOffset_13;

		// Token: 0x04011F1F RID: 73503
		internal static int __PropertyOffset_14;

		// Token: 0x04011F20 RID: 73504
		internal static int __PropertyOffset_15;

		// Token: 0x04011F21 RID: 73505
		internal static int __PropertyOffset_16;

		// Token: 0x04011F22 RID: 73506
		internal static int __PropertyOffset_17;

		// Token: 0x04011F23 RID: 73507
		internal static int __PropertyOffset_18;
	}
}
