using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C2C RID: 15404
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_genCloth_33.struct_genCloth_33")]
	[UnrealStructLayout(168, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 168)]
	public class struct_genCloth_33 : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602340B RID: 144395 RVA: 0x0097D1E0 File Offset: 0x0097B3E0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (struct_genCloth_33._ScriptStructPtr != 0) ? struct_genCloth_33._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_genCloth_33.struct_genCloth_33", ref struct_genCloth_33._ScriptStructPtr);
		}

		// Token: 0x17004554 RID: 17748
		// (get) Token: 0x0602340C RID: 144396 RVA: 0x0097D204 File Offset: 0x0097B404
		// (set) Token: 0x0602340D RID: 144397 RVA: 0x0097D214 File Offset: 0x0097B414
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004555 RID: 17749
		// (get) Token: 0x0602340E RID: 144398 RVA: 0x0097D225 File Offset: 0x0097B425
		// (set) Token: 0x0602340F RID: 144399 RVA: 0x0097D239 File Offset: 0x0097B439
		public unsafe FVector Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17004556 RID: 17750
		// (get) Token: 0x06023410 RID: 144400 RVA: 0x0097D24E File Offset: 0x0097B44E
		// (set) Token: 0x06023411 RID: 144401 RVA: 0x0097D25E File Offset: 0x0097B45E
		public unsafe int neighbour1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004557 RID: 17751
		// (get) Token: 0x06023412 RID: 144402 RVA: 0x0097D26F File Offset: 0x0097B46F
		// (set) Token: 0x06023413 RID: 144403 RVA: 0x0097D27F File Offset: 0x0097B47F
		public unsafe int neighbour2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17004558 RID: 17752
		// (get) Token: 0x06023414 RID: 144404 RVA: 0x0097D290 File Offset: 0x0097B490
		// (set) Token: 0x06023415 RID: 144405 RVA: 0x0097D2A0 File Offset: 0x0097B4A0
		public unsafe int neighbour3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004559 RID: 17753
		// (get) Token: 0x06023416 RID: 144406 RVA: 0x0097D2B1 File Offset: 0x0097B4B1
		// (set) Token: 0x06023417 RID: 144407 RVA: 0x0097D2C1 File Offset: 0x0097B4C1
		public unsafe int neighbour4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700455A RID: 17754
		// (get) Token: 0x06023418 RID: 144408 RVA: 0x0097D2D2 File Offset: 0x0097B4D2
		// (set) Token: 0x06023419 RID: 144409 RVA: 0x0097D2E2 File Offset: 0x0097B4E2
		public unsafe int neighbour5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700455B RID: 17755
		// (get) Token: 0x0602341A RID: 144410 RVA: 0x0097D2F3 File Offset: 0x0097B4F3
		// (set) Token: 0x0602341B RID: 144411 RVA: 0x0097D303 File Offset: 0x0097B503
		public unsafe int neighbour6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700455C RID: 17756
		// (get) Token: 0x0602341C RID: 144412 RVA: 0x0097D314 File Offset: 0x0097B514
		// (set) Token: 0x0602341D RID: 144413 RVA: 0x0097D324 File Offset: 0x0097B524
		public unsafe int neighbour7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700455D RID: 17757
		// (get) Token: 0x0602341E RID: 144414 RVA: 0x0097D335 File Offset: 0x0097B535
		// (set) Token: 0x0602341F RID: 144415 RVA: 0x0097D345 File Offset: 0x0097B545
		public unsafe int neighbour8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700455E RID: 17758
		// (get) Token: 0x06023420 RID: 144416 RVA: 0x0097D356 File Offset: 0x0097B556
		// (set) Token: 0x06023421 RID: 144417 RVA: 0x0097D366 File Offset: 0x0097B566
		public unsafe float dis1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700455F RID: 17759
		// (get) Token: 0x06023422 RID: 144418 RVA: 0x0097D377 File Offset: 0x0097B577
		// (set) Token: 0x06023423 RID: 144419 RVA: 0x0097D387 File Offset: 0x0097B587
		public unsafe float dis2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004560 RID: 17760
		// (get) Token: 0x06023424 RID: 144420 RVA: 0x0097D398 File Offset: 0x0097B598
		// (set) Token: 0x06023425 RID: 144421 RVA: 0x0097D3A8 File Offset: 0x0097B5A8
		public unsafe float dis3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004561 RID: 17761
		// (get) Token: 0x06023426 RID: 144422 RVA: 0x0097D3B9 File Offset: 0x0097B5B9
		// (set) Token: 0x06023427 RID: 144423 RVA: 0x0097D3C9 File Offset: 0x0097B5C9
		public unsafe float dis4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004562 RID: 17762
		// (get) Token: 0x06023428 RID: 144424 RVA: 0x0097D3DA File Offset: 0x0097B5DA
		// (set) Token: 0x06023429 RID: 144425 RVA: 0x0097D3EA File Offset: 0x0097B5EA
		public unsafe float dis5
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004563 RID: 17763
		// (get) Token: 0x0602342A RID: 144426 RVA: 0x0097D3FB File Offset: 0x0097B5FB
		// (set) Token: 0x0602342B RID: 144427 RVA: 0x0097D40B File Offset: 0x0097B60B
		public unsafe float dis6
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004564 RID: 17764
		// (get) Token: 0x0602342C RID: 144428 RVA: 0x0097D41C File Offset: 0x0097B61C
		// (set) Token: 0x0602342D RID: 144429 RVA: 0x0097D42C File Offset: 0x0097B62C
		public unsafe float dis7
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004565 RID: 17765
		// (get) Token: 0x0602342E RID: 144430 RVA: 0x0097D43D File Offset: 0x0097B63D
		// (set) Token: 0x0602342F RID: 144431 RVA: 0x0097D44D File Offset: 0x0097B64D
		public unsafe float dis8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004566 RID: 17766
		// (get) Token: 0x06023430 RID: 144432 RVA: 0x0097D45E File Offset: 0x0097B65E
		// (set) Token: 0x06023431 RID: 144433 RVA: 0x0097D46E File Offset: 0x0097B66E
		public unsafe int isPinned
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17004567 RID: 17767
		// (get) Token: 0x06023432 RID: 144434 RVA: 0x0097D47F File Offset: 0x0097B67F
		// (set) Token: 0x06023433 RID: 144435 RVA: 0x0097D48F File Offset: 0x0097B68F
		public unsafe float bending_rest_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004568 RID: 17768
		// (get) Token: 0x06023434 RID: 144436 RVA: 0x0097D4A0 File Offset: 0x0097B6A0
		// (set) Token: 0x06023435 RID: 144437 RVA: 0x0097D4B0 File Offset: 0x0097B6B0
		public unsafe float bending_rest_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17004569 RID: 17769
		// (get) Token: 0x06023436 RID: 144438 RVA: 0x0097D4C1 File Offset: 0x0097B6C1
		// (set) Token: 0x06023437 RID: 144439 RVA: 0x0097D4D1 File Offset: 0x0097B6D1
		public unsafe float bending_rest_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x1700456A RID: 17770
		// (get) Token: 0x06023438 RID: 144440 RVA: 0x0097D4E2 File Offset: 0x0097B6E2
		// (set) Token: 0x06023439 RID: 144441 RVA: 0x0097D4F2 File Offset: 0x0097B6F2
		public unsafe float bending_rest_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700456B RID: 17771
		// (get) Token: 0x0602343A RID: 144442 RVA: 0x0097D503 File Offset: 0x0097B703
		// (set) Token: 0x0602343B RID: 144443 RVA: 0x0097D513 File Offset: 0x0097B713
		public unsafe int bending_self_idx_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x1700456C RID: 17772
		// (get) Token: 0x0602343C RID: 144444 RVA: 0x0097D524 File Offset: 0x0097B724
		// (set) Token: 0x0602343D RID: 144445 RVA: 0x0097D534 File Offset: 0x0097B734
		public unsafe int bending_self_idx_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x1700456D RID: 17773
		// (get) Token: 0x0602343E RID: 144446 RVA: 0x0097D545 File Offset: 0x0097B745
		// (set) Token: 0x0602343F RID: 144447 RVA: 0x0097D555 File Offset: 0x0097B755
		public unsafe int bending_self_idx_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x1700456E RID: 17774
		// (get) Token: 0x06023440 RID: 144448 RVA: 0x0097D566 File Offset: 0x0097B766
		// (set) Token: 0x06023441 RID: 144449 RVA: 0x0097D576 File Offset: 0x0097B776
		public unsafe int bending_self_idx_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x1700456F RID: 17775
		// (get) Token: 0x06023442 RID: 144450 RVA: 0x0097D587 File Offset: 0x0097B787
		// (set) Token: 0x06023443 RID: 144451 RVA: 0x0097D59B File Offset: 0x0097B79B
		public unsafe FVector bending_nbs_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17004570 RID: 17776
		// (get) Token: 0x06023444 RID: 144452 RVA: 0x0097D5B0 File Offset: 0x0097B7B0
		// (set) Token: 0x06023445 RID: 144453 RVA: 0x0097D5C4 File Offset: 0x0097B7C4
		public unsafe FVector bending_nbs_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17004571 RID: 17777
		// (get) Token: 0x06023446 RID: 144454 RVA: 0x0097D5D9 File Offset: 0x0097B7D9
		// (set) Token: 0x06023447 RID: 144455 RVA: 0x0097D5ED File Offset: 0x0097B7ED
		public unsafe FVector bending_nbs_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17004572 RID: 17778
		// (get) Token: 0x06023448 RID: 144456 RVA: 0x0097D602 File Offset: 0x0097B802
		// (set) Token: 0x06023449 RID: 144457 RVA: 0x0097D616 File Offset: 0x0097B816
		public unsafe FVector bending_nbs_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x17004573 RID: 17779
		// (get) Token: 0x0602344A RID: 144458 RVA: 0x0097D62B File Offset: 0x0097B82B
		// (set) Token: 0x0602344B RID: 144459 RVA: 0x0097D63B File Offset: 0x0097B83B
		public unsafe int deadNode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)struct_genCloth_33.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x0602344C RID: 144460 RVA: 0x0097D64C File Offset: 0x0097B84C
		public struct_genCloth_33()
		{
		}

		// Token: 0x0602344D RID: 144461 RVA: 0x0097D654 File Offset: 0x0097B854
		public struct_genCloth_33(int Index, FVector Pos, int neighbour1, int neighbour2, int neighbour3, int neighbour4, int neighbour5, int neighbour6, int neighbour7, int neighbour8, float dis1, float dis2, float dis3, float dis4, float dis5, float dis6, float dis7, float dis8, int isPinned, float bending_rest_0, float bending_rest_1, float bending_rest_2, float bending_rest_3, int bending_self_idx_0, int bending_self_idx_1, int bending_self_idx_2, int bending_self_idx_3, FVector bending_nbs_0, FVector bending_nbs_1, FVector bending_nbs_2, FVector bending_nbs_3, int deadNode)
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
			this.isPinned = isPinned;
			this.bending_rest_0 = bending_rest_0;
			this.bending_rest_1 = bending_rest_1;
			this.bending_rest_2 = bending_rest_2;
			this.bending_rest_3 = bending_rest_3;
			this.bending_self_idx_0 = bending_self_idx_0;
			this.bending_self_idx_1 = bending_self_idx_1;
			this.bending_self_idx_2 = bending_self_idx_2;
			this.bending_self_idx_3 = bending_self_idx_3;
			this.bending_nbs_0 = bending_nbs_0;
			this.bending_nbs_1 = bending_nbs_1;
			this.bending_nbs_2 = bending_nbs_2;
			this.bending_nbs_3 = bending_nbs_3;
			this.deadNode = deadNode;
		}

		// Token: 0x0602344E RID: 144462 RVA: 0x0097D764 File Offset: 0x0097B964
		protected override IntPtr GetUStructPtr()
		{
			return struct_genCloth_33.StaticStruct();
		}

		// Token: 0x0602344F RID: 144463 RVA: 0x0097D770 File Offset: 0x0097B970
		[NullableContext(2)]
		public struct_genCloth_33(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06023450 RID: 144464 RVA: 0x0097D77A File Offset: 0x0097B97A
		public struct_genCloth_33(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06023451 RID: 144465 RVA: 0x0097D785 File Offset: 0x0097B985
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new struct_genCloth_33(Pointer, false, true);
		}

		// Token: 0x06023452 RID: 144466 RVA: 0x0097D78F File Offset: 0x0097B98F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new struct_genCloth_33(Pointer, MemoryOwner);
		}

		// Token: 0x04011EED RID: 73453
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/struct_genCloth_33.struct_genCloth_33";

		// Token: 0x04011EEE RID: 73454
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011EEF RID: 73455
		internal static int __PropertyOffset_0;

		// Token: 0x04011EF0 RID: 73456
		internal static int __PropertyOffset_1;

		// Token: 0x04011EF1 RID: 73457
		internal static int __PropertyOffset_2;

		// Token: 0x04011EF2 RID: 73458
		internal static int __PropertyOffset_3;

		// Token: 0x04011EF3 RID: 73459
		internal static int __PropertyOffset_4;

		// Token: 0x04011EF4 RID: 73460
		internal static int __PropertyOffset_5;

		// Token: 0x04011EF5 RID: 73461
		internal static int __PropertyOffset_6;

		// Token: 0x04011EF6 RID: 73462
		internal static int __PropertyOffset_7;

		// Token: 0x04011EF7 RID: 73463
		internal static int __PropertyOffset_8;

		// Token: 0x04011EF8 RID: 73464
		internal static int __PropertyOffset_9;

		// Token: 0x04011EF9 RID: 73465
		internal static int __PropertyOffset_10;

		// Token: 0x04011EFA RID: 73466
		internal static int __PropertyOffset_11;

		// Token: 0x04011EFB RID: 73467
		internal static int __PropertyOffset_12;

		// Token: 0x04011EFC RID: 73468
		internal static int __PropertyOffset_13;

		// Token: 0x04011EFD RID: 73469
		internal static int __PropertyOffset_14;

		// Token: 0x04011EFE RID: 73470
		internal static int __PropertyOffset_15;

		// Token: 0x04011EFF RID: 73471
		internal static int __PropertyOffset_16;

		// Token: 0x04011F00 RID: 73472
		internal static int __PropertyOffset_17;

		// Token: 0x04011F01 RID: 73473
		internal static int __PropertyOffset_18;

		// Token: 0x04011F02 RID: 73474
		internal static int __PropertyOffset_19;

		// Token: 0x04011F03 RID: 73475
		internal static int __PropertyOffset_20;

		// Token: 0x04011F04 RID: 73476
		internal static int __PropertyOffset_21;

		// Token: 0x04011F05 RID: 73477
		internal static int __PropertyOffset_22;

		// Token: 0x04011F06 RID: 73478
		internal static int __PropertyOffset_23;

		// Token: 0x04011F07 RID: 73479
		internal static int __PropertyOffset_24;

		// Token: 0x04011F08 RID: 73480
		internal static int __PropertyOffset_25;

		// Token: 0x04011F09 RID: 73481
		internal static int __PropertyOffset_26;

		// Token: 0x04011F0A RID: 73482
		internal static int __PropertyOffset_27;

		// Token: 0x04011F0B RID: 73483
		internal static int __PropertyOffset_28;

		// Token: 0x04011F0C RID: 73484
		internal static int __PropertyOffset_29;

		// Token: 0x04011F0D RID: 73485
		internal static int __PropertyOffset_30;

		// Token: 0x04011F0E RID: 73486
		internal static int __PropertyOffset_31;
	}
}
