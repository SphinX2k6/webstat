using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C2E RID: 15406
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/S_boxColSetupParams.S_boxColSetupParams")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 125)]
	public class S_boxColSetupParams : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06023481 RID: 144513 RVA: 0x0097DB24 File Offset: 0x0097BD24
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_boxColSetupParams._ScriptStructPtr != 0) ? S_boxColSetupParams._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/S_boxColSetupParams.S_boxColSetupParams", ref S_boxColSetupParams._ScriptStructPtr);
		}

		// Token: 0x17004587 RID: 17799
		// (get) Token: 0x06023482 RID: 144514 RVA: 0x0097DB48 File Offset: 0x0097BD48
		// (set) Token: 0x06023483 RID: 144515 RVA: 0x0097DB5C File Offset: 0x0097BD5C
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + S_boxColSetupParams.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_boxColSetupParams.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004588 RID: 17800
		// (get) Token: 0x06023484 RID: 144516 RVA: 0x0097DB71 File Offset: 0x0097BD71
		// (set) Token: 0x06023485 RID: 144517 RVA: 0x0097DB85 File Offset: 0x0097BD85
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + S_boxColSetupParams.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_boxColSetupParams.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004589 RID: 17801
		// (get) Token: 0x06023486 RID: 144518 RVA: 0x0097DB9A File Offset: 0x0097BD9A
		// (set) Token: 0x06023487 RID: 144519 RVA: 0x0097DBAA File Offset: 0x0097BDAA
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700458A RID: 17802
		// (get) Token: 0x06023488 RID: 144520 RVA: 0x0097DBBB File Offset: 0x0097BDBB
		// (set) Token: 0x06023489 RID: 144521 RVA: 0x0097DBCB File Offset: 0x0097BDCB
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700458B RID: 17803
		// (get) Token: 0x0602348A RID: 144522 RVA: 0x0097DBDC File Offset: 0x0097BDDC
		// (set) Token: 0x0602348B RID: 144523 RVA: 0x0097DBEC File Offset: 0x0097BDEC
		public unsafe float DisStiffness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700458C RID: 17804
		// (get) Token: 0x0602348C RID: 144524 RVA: 0x0097DBFD File Offset: 0x0097BDFD
		// (set) Token: 0x0602348D RID: 144525 RVA: 0x0097DC0D File Offset: 0x0097BE0D
		public unsafe bool RevertOrNot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700458D RID: 17805
		// (get) Token: 0x0602348E RID: 144526 RVA: 0x0097DC1E File Offset: 0x0097BE1E
		// (set) Token: 0x0602348F RID: 144527 RVA: 0x0097DC2E File Offset: 0x0097BE2E
		public unsafe float CollisionR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700458E RID: 17806
		// (get) Token: 0x06023490 RID: 144528 RVA: 0x0097DC3F File Offset: 0x0097BE3F
		// (set) Token: 0x06023491 RID: 144529 RVA: 0x0097DC4F File Offset: 0x0097BE4F
		public unsafe float MoveableDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700458F RID: 17807
		// (get) Token: 0x06023492 RID: 144530 RVA: 0x0097DC60 File Offset: 0x0097BE60
		// (set) Token: 0x06023493 RID: 144531 RVA: 0x0097DC70 File Offset: 0x0097BE70
		public unsafe bool EnableCPURead
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004590 RID: 17808
		// (get) Token: 0x06023494 RID: 144532 RVA: 0x0097DC81 File Offset: 0x0097BE81
		// (set) Token: 0x06023495 RID: 144533 RVA: 0x0097DC91 File Offset: 0x0097BE91
		public unsafe float SpringK
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17004591 RID: 17809
		// (get) Token: 0x06023496 RID: 144534 RVA: 0x0097DCA2 File Offset: 0x0097BEA2
		// (set) Token: 0x06023497 RID: 144535 RVA: 0x0097DCB2 File Offset: 0x0097BEB2
		public unsafe float SpringC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004592 RID: 17810
		// (get) Token: 0x06023498 RID: 144536 RVA: 0x0097DCC3 File Offset: 0x0097BEC3
		// (set) Token: 0x06023499 RID: 144537 RVA: 0x0097DCD3 File Offset: 0x0097BED3
		public unsafe float pushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004593 RID: 17811
		// (get) Token: 0x0602349A RID: 144538 RVA: 0x0097DCE4 File Offset: 0x0097BEE4
		// (set) Token: 0x0602349B RID: 144539 RVA: 0x0097DCF4 File Offset: 0x0097BEF4
		public unsafe bool NeedDistanceConsOrNot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004594 RID: 17812
		// (get) Token: 0x0602349C RID: 144540 RVA: 0x0097DD05 File Offset: 0x0097BF05
		// (set) Token: 0x0602349D RID: 144541 RVA: 0x0097DD15 File Offset: 0x0097BF15
		public unsafe bool SimulationPhysicOrNot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004595 RID: 17813
		// (get) Token: 0x0602349E RID: 144542 RVA: 0x0097DD26 File Offset: 0x0097BF26
		// (set) Token: 0x0602349F RID: 144543 RVA: 0x0097DD36 File Offset: 0x0097BF36
		public unsafe float Attackstrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004596 RID: 17814
		// (get) Token: 0x060234A0 RID: 144544 RVA: 0x0097DD47 File Offset: 0x0097BF47
		// (set) Token: 0x060234A1 RID: 144545 RVA: 0x0097DD57 File Offset: 0x0097BF57
		public unsafe float MeshMass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004597 RID: 17815
		// (get) Token: 0x060234A2 RID: 144546 RVA: 0x0097DD68 File Offset: 0x0097BF68
		// (set) Token: 0x060234A3 RID: 144547 RVA: 0x0097DD78 File Offset: 0x0097BF78
		public unsafe bool MaterialSlot1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004598 RID: 17816
		// (get) Token: 0x060234A4 RID: 144548 RVA: 0x0097DD89 File Offset: 0x0097BF89
		// (set) Token: 0x060234A5 RID: 144549 RVA: 0x0097DD9D File Offset: 0x0097BF9D
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + S_boxColSetupParams.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_boxColSetupParams.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004599 RID: 17817
		// (get) Token: 0x060234A6 RID: 144550 RVA: 0x0097DDB2 File Offset: 0x0097BFB2
		// (set) Token: 0x060234A7 RID: 144551 RVA: 0x0097DDC2 File Offset: 0x0097BFC2
		public unsafe int lockXYZ_0_do_nothing__1_lock_x___2_lock_y___3_lock_z_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x1700459A RID: 17818
		// (get) Token: 0x060234A8 RID: 144552 RVA: 0x0097DDD3 File Offset: 0x0097BFD3
		// (set) Token: 0x060234A9 RID: 144553 RVA: 0x0097DDE7 File Offset: 0x0097BFE7
		public unsafe FVector gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x1700459B RID: 17819
		// (get) Token: 0x060234AA RID: 144554 RVA: 0x0097DDFC File Offset: 0x0097BFFC
		// (set) Token: 0x060234AB RID: 144555 RVA: 0x0097DE0C File Offset: 0x0097C00C
		public unsafe bool ReadDAINBeginPlay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700459C RID: 17820
		// (get) Token: 0x060234AC RID: 144556 RVA: 0x0097DE20 File Offset: 0x0097C020
		// (set) Token: 0x060234AD RID: 144557 RVA: 0x0097DE63 File Offset: 0x0097C063
		[Nullable(1)]
		public TArray<FKuroCSUnifiedCollider_genericCloth> CollisionArr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FKuroCSUnifiedCollider_genericCloth> result;
				if ((result = this._CollisionArr) == null)
				{
					result = (this._CollisionArr = new TArray<FKuroCSUnifiedCollider_genericCloth>(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_21, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CollisionArr.CopyAssign(value);
			}
		}

		// Token: 0x1700459D RID: 17821
		// (get) Token: 0x060234AE RID: 144558 RVA: 0x0097DE71 File Offset: 0x0097C071
		// (set) Token: 0x060234AF RID: 144559 RVA: 0x0097DE81 File Offset: 0x0097C081
		public unsafe int subCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x1700459E RID: 17822
		// (get) Token: 0x060234B0 RID: 144560 RVA: 0x0097DE92 File Offset: 0x0097C092
		// (set) Token: 0x060234B1 RID: 144561 RVA: 0x0097DEA2 File Offset: 0x0097C0A2
		public unsafe bool ForcePlayerCol
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_boxColSetupParams.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x060234B2 RID: 144562 RVA: 0x0097DEB3 File Offset: 0x0097C0B3
		public S_boxColSetupParams()
		{
		}

		// Token: 0x060234B3 RID: 144563 RVA: 0x0097DEBC File Offset: 0x0097C0BC
		[NullableContext(1)]
		public S_boxColSetupParams(UMaterialInstance InputMat, UDataTable DT, bool _2DRT, int XCount_0, float DisStiffness, bool RevertOrNot, float CollisionR, float MoveableDis, bool EnableCPURead, float SpringK, float SpringC, float pushStrength, bool NeedDistanceConsOrNot, bool SimulationPhysicOrNot, float Attackstrength, float MeshMass, bool MaterialSlot1, UMaterialInstance InputMat1, int lockXYZ_0_do_nothing__1_lock_x___2_lock_y___3_lock_z_, FVector gravity, bool ReadDAINBeginPlay, TArray<FKuroCSUnifiedCollider_genericCloth> CollisionArr, int subCount_0, bool ForcePlayerCol)
		{
			this.InputMat = InputMat;
			this.DT = DT;
			this._2DRT = _2DRT;
			this.XCount_0 = XCount_0;
			this.DisStiffness = DisStiffness;
			this.RevertOrNot = RevertOrNot;
			this.CollisionR = CollisionR;
			this.MoveableDis = MoveableDis;
			this.EnableCPURead = EnableCPURead;
			this.SpringK = SpringK;
			this.SpringC = SpringC;
			this.pushStrength = pushStrength;
			this.NeedDistanceConsOrNot = NeedDistanceConsOrNot;
			this.SimulationPhysicOrNot = SimulationPhysicOrNot;
			this.Attackstrength = Attackstrength;
			this.MeshMass = MeshMass;
			this.MaterialSlot1 = MaterialSlot1;
			this.InputMat1 = InputMat1;
			this.lockXYZ_0_do_nothing__1_lock_x___2_lock_y___3_lock_z_ = lockXYZ_0_do_nothing__1_lock_x___2_lock_y___3_lock_z_;
			this.gravity = gravity;
			this.ReadDAINBeginPlay = ReadDAINBeginPlay;
			this.CollisionArr = CollisionArr;
			this.subCount_0 = subCount_0;
			this.ForcePlayerCol = ForcePlayerCol;
		}

		// Token: 0x060234B4 RID: 144564 RVA: 0x0097DF8C File Offset: 0x0097C18C
		protected override IntPtr GetUStructPtr()
		{
			return S_boxColSetupParams.StaticStruct();
		}

		// Token: 0x060234B5 RID: 144565 RVA: 0x0097DF98 File Offset: 0x0097C198
		public S_boxColSetupParams(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060234B6 RID: 144566 RVA: 0x0097DFA2 File Offset: 0x0097C1A2
		public S_boxColSetupParams(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060234B7 RID: 144567 RVA: 0x0097DFAD File Offset: 0x0097C1AD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_boxColSetupParams(Pointer, false, true);
		}

		// Token: 0x060234B8 RID: 144568 RVA: 0x0097DFB7 File Offset: 0x0097C1B7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_boxColSetupParams(Pointer, MemoryOwner);
		}

		// Token: 0x04011F24 RID: 73508
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/S_boxColSetupParams.S_boxColSetupParams";

		// Token: 0x04011F25 RID: 73509
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011F26 RID: 73510
		internal static int __PropertyOffset_0;

		// Token: 0x04011F27 RID: 73511
		internal static int __PropertyOffset_1;

		// Token: 0x04011F28 RID: 73512
		internal static int __PropertyOffset_2;

		// Token: 0x04011F29 RID: 73513
		internal static int __PropertyOffset_3;

		// Token: 0x04011F2A RID: 73514
		internal static int __PropertyOffset_4;

		// Token: 0x04011F2B RID: 73515
		internal static int __PropertyOffset_5;

		// Token: 0x04011F2C RID: 73516
		internal static int __PropertyOffset_6;

		// Token: 0x04011F2D RID: 73517
		internal static int __PropertyOffset_7;

		// Token: 0x04011F2E RID: 73518
		internal static int __PropertyOffset_8;

		// Token: 0x04011F2F RID: 73519
		internal static int __PropertyOffset_9;

		// Token: 0x04011F30 RID: 73520
		internal static int __PropertyOffset_10;

		// Token: 0x04011F31 RID: 73521
		internal static int __PropertyOffset_11;

		// Token: 0x04011F32 RID: 73522
		internal static int __PropertyOffset_12;

		// Token: 0x04011F33 RID: 73523
		internal static int __PropertyOffset_13;

		// Token: 0x04011F34 RID: 73524
		internal static int __PropertyOffset_14;

		// Token: 0x04011F35 RID: 73525
		internal static int __PropertyOffset_15;

		// Token: 0x04011F36 RID: 73526
		internal static int __PropertyOffset_16;

		// Token: 0x04011F37 RID: 73527
		internal static int __PropertyOffset_17;

		// Token: 0x04011F38 RID: 73528
		internal static int __PropertyOffset_18;

		// Token: 0x04011F39 RID: 73529
		internal static int __PropertyOffset_19;

		// Token: 0x04011F3A RID: 73530
		internal static int __PropertyOffset_20;

		// Token: 0x04011F3B RID: 73531
		internal static int __PropertyOffset_21;

		// Token: 0x04011F3C RID: 73532
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKuroCSUnifiedCollider_genericCloth> _CollisionArr;

		// Token: 0x04011F3D RID: 73533
		internal static int __PropertyOffset_22;

		// Token: 0x04011F3E RID: 73534
		internal static int __PropertyOffset_23;
	}
}
