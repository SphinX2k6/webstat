using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F30 RID: 16176
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/NPCQuestStep.NPCQuestStep")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class NPCQuestStep : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028611 RID: 165393 RVA: 0x00A08E45 File Offset: 0x00A07045
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (NPCQuestStep._ScriptStructPtr != 0) ? NPCQuestStep._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/NPCQuestStep.NPCQuestStep", ref NPCQuestStep._ScriptStructPtr);
		}

		// Token: 0x1700620B RID: 25099
		// (get) Token: 0x06028612 RID: 165394 RVA: 0x00A08E69 File Offset: 0x00A07069
		// (set) Token: 0x06028613 RID: 165395 RVA: 0x00A08E79 File Offset: 0x00A07079
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700620C RID: 25100
		// (get) Token: 0x06028614 RID: 165396 RVA: 0x00A08E8A File Offset: 0x00A0708A
		// (set) Token: 0x06028615 RID: 165397 RVA: 0x00A08E9A File Offset: 0x00A0709A
		public unsafe int QuestKey
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700620D RID: 25101
		// (get) Token: 0x06028616 RID: 165398 RVA: 0x00A08EAB File Offset: 0x00A070AB
		// (set) Token: 0x06028617 RID: 165399 RVA: 0x00A08EBB File Offset: 0x00A070BB
		public unsafe int StepId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700620E RID: 25102
		// (get) Token: 0x06028618 RID: 165400 RVA: 0x00A08ECC File Offset: 0x00A070CC
		// (set) Token: 0x06028619 RID: 165401 RVA: 0x00A08F0F File Offset: 0x00A0710F
		public TArray<int> NeedSteps
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._NeedSteps) == null)
				{
					result = (this._NeedSteps = new TArray<int>(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.NeedSteps.CopyAssign(value);
			}
		}

		// Token: 0x1700620F RID: 25103
		// (get) Token: 0x0602861A RID: 165402 RVA: 0x00A08F1D File Offset: 0x00A0711D
		// (set) Token: 0x0602861B RID: 165403 RVA: 0x00A08F2D File Offset: 0x00A0712D
		public unsafe int ProcessType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006210 RID: 25104
		// (get) Token: 0x0602861C RID: 165404 RVA: 0x00A08F3E File Offset: 0x00A0713E
		// (set) Token: 0x0602861D RID: 165405 RVA: 0x00A08F4E File Offset: 0x00A0714E
		public unsafe bool IsAutoAccept
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006211 RID: 25105
		// (get) Token: 0x0602861E RID: 165406 RVA: 0x00A08F5F File Offset: 0x00A0715F
		// (set) Token: 0x0602861F RID: 165407 RVA: 0x00A08F6F File Offset: 0x00A0716F
		public unsafe bool IsAllFinish
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006212 RID: 25106
		// (get) Token: 0x06028620 RID: 165408 RVA: 0x00A08F80 File Offset: 0x00A07180
		// (set) Token: 0x06028621 RID: 165409 RVA: 0x00A08F94 File Offset: 0x00A07194
		public unsafe string StepType
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCQuestStep.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCQuestStep.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x17006213 RID: 25107
		// (get) Token: 0x06028622 RID: 165410 RVA: 0x00A08FA9 File Offset: 0x00A071A9
		// (set) Token: 0x06028623 RID: 165411 RVA: 0x00A08FB9 File Offset: 0x00A071B9
		public unsafe int AcceptCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17006214 RID: 25108
		// (get) Token: 0x06028624 RID: 165412 RVA: 0x00A08FCA File Offset: 0x00A071CA
		// (set) Token: 0x06028625 RID: 165413 RVA: 0x00A08FDA File Offset: 0x00A071DA
		public unsafe int AcceptedAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17006215 RID: 25109
		// (get) Token: 0x06028626 RID: 165414 RVA: 0x00A08FEB File Offset: 0x00A071EB
		// (set) Token: 0x06028627 RID: 165415 RVA: 0x00A08FFB File Offset: 0x00A071FB
		public unsafe int TargetCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17006216 RID: 25110
		// (get) Token: 0x06028628 RID: 165416 RVA: 0x00A0900C File Offset: 0x00A0720C
		// (set) Token: 0x06028629 RID: 165417 RVA: 0x00A0901C File Offset: 0x00A0721C
		public unsafe int SubmitAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17006217 RID: 25111
		// (get) Token: 0x0602862A RID: 165418 RVA: 0x00A0902D File Offset: 0x00A0722D
		// (set) Token: 0x0602862B RID: 165419 RVA: 0x00A0903D File Offset: 0x00A0723D
		public unsafe int FailCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17006218 RID: 25112
		// (get) Token: 0x0602862C RID: 165420 RVA: 0x00A0904E File Offset: 0x00A0724E
		// (set) Token: 0x0602862D RID: 165421 RVA: 0x00A0905E File Offset: 0x00A0725E
		public unsafe int FailAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006219 RID: 25113
		// (get) Token: 0x0602862E RID: 165422 RVA: 0x00A0906F File Offset: 0x00A0726F
		// (set) Token: 0x0602862F RID: 165423 RVA: 0x00A0907F File Offset: 0x00A0727F
		public unsafe int RewardId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x1700621A RID: 25114
		// (get) Token: 0x06028630 RID: 165424 RVA: 0x00A09090 File Offset: 0x00A07290
		// (set) Token: 0x06028631 RID: 165425 RVA: 0x00A090D3 File Offset: 0x00A072D3
		public TArray<long> AcceptCreatureGen
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._AcceptCreatureGen) == null)
				{
					result = (this._AcceptCreatureGen = new TArray<long>(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_15, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AcceptCreatureGen.CopyAssign(value);
			}
		}

		// Token: 0x1700621B RID: 25115
		// (get) Token: 0x06028632 RID: 165426 RVA: 0x00A090E4 File Offset: 0x00A072E4
		// (set) Token: 0x06028633 RID: 165427 RVA: 0x00A09127 File Offset: 0x00A07327
		public TArray<long> FinishCreatureGen
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._FinishCreatureGen) == null)
				{
					result = (this._FinishCreatureGen = new TArray<long>(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_16, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FinishCreatureGen.CopyAssign(value);
			}
		}

		// Token: 0x1700621C RID: 25116
		// (get) Token: 0x06028634 RID: 165428 RVA: 0x00A09135 File Offset: 0x00A07335
		// (set) Token: 0x06028635 RID: 165429 RVA: 0x00A09145 File Offset: 0x00A07345
		public unsafe int SaveType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x1700621D RID: 25117
		// (get) Token: 0x06028636 RID: 165430 RVA: 0x00A09156 File Offset: 0x00A07356
		// (set) Token: 0x06028637 RID: 165431 RVA: 0x00A09166 File Offset: 0x00A07366
		public unsafe int IsSavePoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuestStep.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x06028638 RID: 165432 RVA: 0x00A09177 File Offset: 0x00A07377
		public NPCQuestStep()
		{
		}

		// Token: 0x06028639 RID: 165433 RVA: 0x00A09180 File Offset: 0x00A07380
		public NPCQuestStep(int ID, int QuestKey, int StepId, TArray<int> NeedSteps, int ProcessType, bool IsAutoAccept, bool IsAllFinish, string StepType, int AcceptCondition, int AcceptedAction, int TargetCondition, int SubmitAction, int FailCondition, int FailAction, int RewardId, TArray<long> AcceptCreatureGen, TArray<long> FinishCreatureGen, int SaveType, int IsSavePoint)
		{
			this.ID = ID;
			this.QuestKey = QuestKey;
			this.StepId = StepId;
			this.NeedSteps = NeedSteps;
			this.ProcessType = ProcessType;
			this.IsAutoAccept = IsAutoAccept;
			this.IsAllFinish = IsAllFinish;
			this.StepType = StepType;
			this.AcceptCondition = AcceptCondition;
			this.AcceptedAction = AcceptedAction;
			this.TargetCondition = TargetCondition;
			this.SubmitAction = SubmitAction;
			this.FailCondition = FailCondition;
			this.FailAction = FailAction;
			this.RewardId = RewardId;
			this.AcceptCreatureGen = AcceptCreatureGen;
			this.FinishCreatureGen = FinishCreatureGen;
			this.SaveType = SaveType;
			this.IsSavePoint = IsSavePoint;
		}

		// Token: 0x0602863A RID: 165434 RVA: 0x00A09228 File Offset: 0x00A07428
		protected override IntPtr GetUStructPtr()
		{
			return NPCQuestStep.StaticStruct();
		}

		// Token: 0x0602863B RID: 165435 RVA: 0x00A09234 File Offset: 0x00A07434
		[NullableContext(2)]
		public NPCQuestStep(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602863C RID: 165436 RVA: 0x00A0923E File Offset: 0x00A0743E
		public NPCQuestStep(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602863D RID: 165437 RVA: 0x00A09249 File Offset: 0x00A07449
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new NPCQuestStep(Pointer, false, true);
		}

		// Token: 0x0602863E RID: 165438 RVA: 0x00A09253 File Offset: 0x00A07453
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new NPCQuestStep(Pointer, MemoryOwner);
		}

		// Token: 0x040153C7 RID: 86983
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/NPCQuestStep.NPCQuestStep";

		// Token: 0x040153C8 RID: 86984
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153C9 RID: 86985
		internal static int __PropertyOffset_0;

		// Token: 0x040153CA RID: 86986
		internal static int __PropertyOffset_1;

		// Token: 0x040153CB RID: 86987
		internal static int __PropertyOffset_2;

		// Token: 0x040153CC RID: 86988
		internal static int __PropertyOffset_3;

		// Token: 0x040153CD RID: 86989
		[Nullable(2)]
		private TArray<int> _NeedSteps;

		// Token: 0x040153CE RID: 86990
		internal static int __PropertyOffset_4;

		// Token: 0x040153CF RID: 86991
		internal static int __PropertyOffset_5;

		// Token: 0x040153D0 RID: 86992
		internal static int __PropertyOffset_6;

		// Token: 0x040153D1 RID: 86993
		internal static int __PropertyOffset_7;

		// Token: 0x040153D2 RID: 86994
		internal static int __PropertyOffset_8;

		// Token: 0x040153D3 RID: 86995
		internal static int __PropertyOffset_9;

		// Token: 0x040153D4 RID: 86996
		internal static int __PropertyOffset_10;

		// Token: 0x040153D5 RID: 86997
		internal static int __PropertyOffset_11;

		// Token: 0x040153D6 RID: 86998
		internal static int __PropertyOffset_12;

		// Token: 0x040153D7 RID: 86999
		internal static int __PropertyOffset_13;

		// Token: 0x040153D8 RID: 87000
		internal static int __PropertyOffset_14;

		// Token: 0x040153D9 RID: 87001
		internal static int __PropertyOffset_15;

		// Token: 0x040153DA RID: 87002
		[Nullable(2)]
		private TArray<long> _AcceptCreatureGen;

		// Token: 0x040153DB RID: 87003
		internal static int __PropertyOffset_16;

		// Token: 0x040153DC RID: 87004
		[Nullable(2)]
		private TArray<long> _FinishCreatureGen;

		// Token: 0x040153DD RID: 87005
		internal static int __PropertyOffset_17;

		// Token: 0x040153DE RID: 87006
		internal static int __PropertyOffset_18;
	}
}
