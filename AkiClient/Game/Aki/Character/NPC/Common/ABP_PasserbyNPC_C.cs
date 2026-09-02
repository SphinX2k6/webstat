using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Common
{
	// Token: 0x020040E9 RID: 16617
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/ABP_PasserbyNPC.ABP_PasserbyNPC_C")]
	[UnrealStructLayout(9248, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 9248)]
	public class ABP_PasserbyNPC_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_Animation_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602BF29 RID: 180009 RVA: 0x00A8F16B File Offset: 0x00A8D36B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_PasserbyNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/ABP_PasserbyNPC.ABP_PasserbyNPC_C");
			}
			return ABP_PasserbyNPC_C._ClassPtr;
		}

		// Token: 0x0602BF2A RID: 180010 RVA: 0x00A8F190 File Offset: 0x00A8D390
		public ABP_PasserbyNPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_PasserbyNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BF2B RID: 180011 RVA: 0x00A8F1B8 File Offset: 0x00A8D3B8
		public ABP_PasserbyNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_PasserbyNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700753B RID: 30011
		// (get) Token: 0x0602BF2C RID: 180012 RVA: 0x00A8F1EC File Offset: 0x00A8D3EC
		// (set) Token: 0x0602BF2D RID: 180013 RVA: 0x00A8F225 File Offset: 0x00A8D425
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700753C RID: 30012
		// (get) Token: 0x0602BF2E RID: 180014 RVA: 0x00A8F248 File Offset: 0x00A8D448
		// (set) Token: 0x0602BF2F RID: 180015 RVA: 0x00A8F281 File Offset: 0x00A8D481
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700753D RID: 30013
		// (get) Token: 0x0602BF30 RID: 180016 RVA: 0x00A8F2A4 File Offset: 0x00A8D4A4
		// (set) Token: 0x0602BF31 RID: 180017 RVA: 0x00A8F2DD File Offset: 0x00A8D4DD
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700753E RID: 30014
		// (get) Token: 0x0602BF32 RID: 180018 RVA: 0x00A8F300 File Offset: 0x00A8D500
		// (set) Token: 0x0602BF33 RID: 180019 RVA: 0x00A8F339 File Offset: 0x00A8D539
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700753F RID: 30015
		// (get) Token: 0x0602BF34 RID: 180020 RVA: 0x00A8F35C File Offset: 0x00A8D55C
		// (set) Token: 0x0602BF35 RID: 180021 RVA: 0x00A8F395 File Offset: 0x00A8D595
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007540 RID: 30016
		// (get) Token: 0x0602BF36 RID: 180022 RVA: 0x00A8F3B8 File Offset: 0x00A8D5B8
		// (set) Token: 0x0602BF37 RID: 180023 RVA: 0x00A8F3F1 File Offset: 0x00A8D5F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007541 RID: 30017
		// (get) Token: 0x0602BF38 RID: 180024 RVA: 0x00A8F414 File Offset: 0x00A8D614
		// (set) Token: 0x0602BF39 RID: 180025 RVA: 0x00A8F44D File Offset: 0x00A8D64D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007542 RID: 30018
		// (get) Token: 0x0602BF3A RID: 180026 RVA: 0x00A8F470 File Offset: 0x00A8D670
		// (set) Token: 0x0602BF3B RID: 180027 RVA: 0x00A8F4A9 File Offset: 0x00A8D6A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007543 RID: 30019
		// (get) Token: 0x0602BF3C RID: 180028 RVA: 0x00A8F4CC File Offset: 0x00A8D6CC
		// (set) Token: 0x0602BF3D RID: 180029 RVA: 0x00A8F505 File Offset: 0x00A8D705
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007544 RID: 30020
		// (get) Token: 0x0602BF3E RID: 180030 RVA: 0x00A8F528 File Offset: 0x00A8D728
		// (set) Token: 0x0602BF3F RID: 180031 RVA: 0x00A8F561 File Offset: 0x00A8D761
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007545 RID: 30021
		// (get) Token: 0x0602BF40 RID: 180032 RVA: 0x00A8F584 File Offset: 0x00A8D784
		// (set) Token: 0x0602BF41 RID: 180033 RVA: 0x00A8F5BD File Offset: 0x00A8D7BD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007546 RID: 30022
		// (get) Token: 0x0602BF42 RID: 180034 RVA: 0x00A8F5E0 File Offset: 0x00A8D7E0
		// (set) Token: 0x0602BF43 RID: 180035 RVA: 0x00A8F619 File Offset: 0x00A8D819
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007547 RID: 30023
		// (get) Token: 0x0602BF44 RID: 180036 RVA: 0x00A8F63C File Offset: 0x00A8D83C
		// (set) Token: 0x0602BF45 RID: 180037 RVA: 0x00A8F675 File Offset: 0x00A8D875
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007548 RID: 30024
		// (get) Token: 0x0602BF46 RID: 180038 RVA: 0x00A8F698 File Offset: 0x00A8D898
		// (set) Token: 0x0602BF47 RID: 180039 RVA: 0x00A8F6D1 File Offset: 0x00A8D8D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007549 RID: 30025
		// (get) Token: 0x0602BF48 RID: 180040 RVA: 0x00A8F6F4 File Offset: 0x00A8D8F4
		// (set) Token: 0x0602BF49 RID: 180041 RVA: 0x00A8F72D File Offset: 0x00A8D92D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700754A RID: 30026
		// (get) Token: 0x0602BF4A RID: 180042 RVA: 0x00A8F750 File Offset: 0x00A8D950
		// (set) Token: 0x0602BF4B RID: 180043 RVA: 0x00A8F789 File Offset: 0x00A8D989
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700754B RID: 30027
		// (get) Token: 0x0602BF4C RID: 180044 RVA: 0x00A8F7AC File Offset: 0x00A8D9AC
		// (set) Token: 0x0602BF4D RID: 180045 RVA: 0x00A8F7E5 File Offset: 0x00A8D9E5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700754C RID: 30028
		// (get) Token: 0x0602BF4E RID: 180046 RVA: 0x00A8F808 File Offset: 0x00A8DA08
		// (set) Token: 0x0602BF4F RID: 180047 RVA: 0x00A8F841 File Offset: 0x00A8DA41
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700754D RID: 30029
		// (get) Token: 0x0602BF50 RID: 180048 RVA: 0x00A8F864 File Offset: 0x00A8DA64
		// (set) Token: 0x0602BF51 RID: 180049 RVA: 0x00A8F89D File Offset: 0x00A8DA9D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700754E RID: 30030
		// (get) Token: 0x0602BF52 RID: 180050 RVA: 0x00A8F8C0 File Offset: 0x00A8DAC0
		// (set) Token: 0x0602BF53 RID: 180051 RVA: 0x00A8F8F9 File Offset: 0x00A8DAF9
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700754F RID: 30031
		// (get) Token: 0x0602BF54 RID: 180052 RVA: 0x00A8F91C File Offset: 0x00A8DB1C
		// (set) Token: 0x0602BF55 RID: 180053 RVA: 0x00A8F955 File Offset: 0x00A8DB55
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007550 RID: 30032
		// (get) Token: 0x0602BF56 RID: 180054 RVA: 0x00A8F978 File Offset: 0x00A8DB78
		// (set) Token: 0x0602BF57 RID: 180055 RVA: 0x00A8F9B1 File Offset: 0x00A8DBB1
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007551 RID: 30033
		// (get) Token: 0x0602BF58 RID: 180056 RVA: 0x00A8F9D4 File Offset: 0x00A8DBD4
		// (set) Token: 0x0602BF59 RID: 180057 RVA: 0x00A8FA0D File Offset: 0x00A8DC0D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007552 RID: 30034
		// (get) Token: 0x0602BF5A RID: 180058 RVA: 0x00A8FA30 File Offset: 0x00A8DC30
		// (set) Token: 0x0602BF5B RID: 180059 RVA: 0x00A8FA69 File Offset: 0x00A8DC69
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007553 RID: 30035
		// (get) Token: 0x0602BF5C RID: 180060 RVA: 0x00A8FA8C File Offset: 0x00A8DC8C
		// (set) Token: 0x0602BF5D RID: 180061 RVA: 0x00A8FAC5 File Offset: 0x00A8DCC5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007554 RID: 30036
		// (get) Token: 0x0602BF5E RID: 180062 RVA: 0x00A8FAE8 File Offset: 0x00A8DCE8
		// (set) Token: 0x0602BF5F RID: 180063 RVA: 0x00A8FB21 File Offset: 0x00A8DD21
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007555 RID: 30037
		// (get) Token: 0x0602BF60 RID: 180064 RVA: 0x00A8FB44 File Offset: 0x00A8DD44
		// (set) Token: 0x0602BF61 RID: 180065 RVA: 0x00A8FB7D File Offset: 0x00A8DD7D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007556 RID: 30038
		// (get) Token: 0x0602BF62 RID: 180066 RVA: 0x00A8FBA0 File Offset: 0x00A8DDA0
		// (set) Token: 0x0602BF63 RID: 180067 RVA: 0x00A8FBD9 File Offset: 0x00A8DDD9
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007557 RID: 30039
		// (get) Token: 0x0602BF64 RID: 180068 RVA: 0x00A8FBFC File Offset: 0x00A8DDFC
		// (set) Token: 0x0602BF65 RID: 180069 RVA: 0x00A8FC35 File Offset: 0x00A8DE35
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007558 RID: 30040
		// (get) Token: 0x0602BF66 RID: 180070 RVA: 0x00A8FC58 File Offset: 0x00A8DE58
		// (set) Token: 0x0602BF67 RID: 180071 RVA: 0x00A8FC91 File Offset: 0x00A8DE91
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007559 RID: 30041
		// (get) Token: 0x0602BF68 RID: 180072 RVA: 0x00A8FCB4 File Offset: 0x00A8DEB4
		// (set) Token: 0x0602BF69 RID: 180073 RVA: 0x00A8FCED File Offset: 0x00A8DEED
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700755A RID: 30042
		// (get) Token: 0x0602BF6A RID: 180074 RVA: 0x00A8FD10 File Offset: 0x00A8DF10
		// (set) Token: 0x0602BF6B RID: 180075 RVA: 0x00A8FD49 File Offset: 0x00A8DF49
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700755B RID: 30043
		// (get) Token: 0x0602BF6C RID: 180076 RVA: 0x00A8FD6C File Offset: 0x00A8DF6C
		// (set) Token: 0x0602BF6D RID: 180077 RVA: 0x00A8FDA5 File Offset: 0x00A8DFA5
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700755C RID: 30044
		// (get) Token: 0x0602BF6E RID: 180078 RVA: 0x00A8FDC8 File Offset: 0x00A8DFC8
		// (set) Token: 0x0602BF6F RID: 180079 RVA: 0x00A8FE01 File Offset: 0x00A8E001
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700755D RID: 30045
		// (get) Token: 0x0602BF70 RID: 180080 RVA: 0x00A8FE24 File Offset: 0x00A8E024
		// (set) Token: 0x0602BF71 RID: 180081 RVA: 0x00A8FE5D File Offset: 0x00A8E05D
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700755E RID: 30046
		// (get) Token: 0x0602BF72 RID: 180082 RVA: 0x00A8FE80 File Offset: 0x00A8E080
		// (set) Token: 0x0602BF73 RID: 180083 RVA: 0x00A8FEB9 File Offset: 0x00A8E0B9
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700755F RID: 30047
		// (get) Token: 0x0602BF74 RID: 180084 RVA: 0x00A8FEDC File Offset: 0x00A8E0DC
		// (set) Token: 0x0602BF75 RID: 180085 RVA: 0x00A8FF15 File Offset: 0x00A8E115
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007560 RID: 30048
		// (get) Token: 0x0602BF76 RID: 180086 RVA: 0x00A8FF38 File Offset: 0x00A8E138
		// (set) Token: 0x0602BF77 RID: 180087 RVA: 0x00A8FF71 File Offset: 0x00A8E171
		public FAnimNode_RBF AnimGraphNode_RBF
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RBF result;
				if ((result = this._AnimGraphNode_RBF) == null)
				{
					result = (this._AnimGraphNode_RBF = new FAnimNode_RBF(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RBF.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007561 RID: 30049
		// (get) Token: 0x0602BF78 RID: 180088 RVA: 0x00A8FF94 File Offset: 0x00A8E194
		// (set) Token: 0x0602BF79 RID: 180089 RVA: 0x00A8FFCD File Offset: 0x00A8E1CD
		public FAnimNode_KuroHumanIK AnimGraphNode_KuroHumanIK
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_KuroHumanIK result;
				if ((result = this._AnimGraphNode_KuroHumanIK) == null)
				{
					result = (this._AnimGraphNode_KuroHumanIK = new FAnimNode_KuroHumanIK(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_KuroHumanIK.StaticStruct(), base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007562 RID: 30050
		// (get) Token: 0x0602BF7A RID: 180090 RVA: 0x00A8FFEE File Offset: 0x00A8E1EE
		// (set) Token: 0x0602BF7B RID: 180091 RVA: 0x00A90002 File Offset: 0x00A8E202
		[Nullable(2)]
		public unsafe BP_BaseNPC_C 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BaseNPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PasserbyNPC_C.__PropertyOffset_39);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PasserbyNPC_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x17007563 RID: 30051
		// (get) Token: 0x0602BF7C RID: 180092 RVA: 0x00A90017 File Offset: 0x00A8E217
		// (set) Token: 0x0602BF7D RID: 180093 RVA: 0x00A9002B File Offset: 0x00A8E22B
		public unsafe FVector 移动输入向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x17007564 RID: 30052
		// (get) Token: 0x0602BF7E RID: 180094 RVA: 0x00A90040 File Offset: 0x00A8E240
		// (set) Token: 0x0602BF7F RID: 180095 RVA: 0x00A90050 File Offset: 0x00A8E250
		public unsafe float 速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x17007565 RID: 30053
		// (get) Token: 0x0602BF80 RID: 180096 RVA: 0x00A90061 File Offset: 0x00A8E261
		// (set) Token: 0x0602BF81 RID: 180097 RVA: 0x00A90071 File Offset: 0x00A8E271
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_42) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_42) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007566 RID: 30054
		// (get) Token: 0x0602BF82 RID: 180098 RVA: 0x00A90082 File Offset: 0x00A8E282
		// (set) Token: 0x0602BF83 RID: 180099 RVA: 0x00A90092 File Offset: 0x00A8E292
		public unsafe bool ifPlayIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007567 RID: 30055
		// (get) Token: 0x0602BF84 RID: 180100 RVA: 0x00A900A4 File Offset: 0x00A8E2A4
		// (set) Token: 0x0602BF85 RID: 180101 RVA: 0x00A900DD File Offset: 0x00A8E2DD
		public TArray<UAnimMontage> IdleMontageArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimMontage> result;
				if ((result = this._IdleMontageArray) == null)
				{
					result = (this._IdleMontageArray = new TArray<UAnimMontage>(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				this.IdleMontageArray.CopyAssign(value);
			}
		}

		// Token: 0x17007568 RID: 30056
		// (get) Token: 0x0602BF86 RID: 180102 RVA: 0x00A900EB File Offset: 0x00A8E2EB
		// (set) Token: 0x0602BF87 RID: 180103 RVA: 0x00A900FF File Offset: 0x00A8E2FF
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PasserbyNPC_C.__PropertyOffset_45);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PasserbyNPC_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17007569 RID: 30057
		// (get) Token: 0x0602BF88 RID: 180104 RVA: 0x00A90114 File Offset: 0x00A8E314
		// (set) Token: 0x0602BF89 RID: 180105 RVA: 0x00A90124 File Offset: 0x00A8E324
		public unsafe bool 是否原地转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700756A RID: 30058
		// (get) Token: 0x0602BF8A RID: 180106 RVA: 0x00A90135 File Offset: 0x00A8E335
		// (set) Token: 0x0602BF8B RID: 180107 RVA: 0x00A90145 File Offset: 0x00A8E345
		public unsafe float 旋转角度差值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x1700756B RID: 30059
		// (get) Token: 0x0602BF8C RID: 180108 RVA: 0x00A90156 File Offset: 0x00A8E356
		// (set) Token: 0x0602BF8D RID: 180109 RVA: 0x00A90166 File Offset: 0x00A8E366
		public unsafe float 上一次旋转角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x1700756C RID: 30060
		// (get) Token: 0x0602BF8E RID: 180110 RVA: 0x00A90177 File Offset: 0x00A8E377
		// (set) Token: 0x0602BF8F RID: 180111 RVA: 0x00A9018B File Offset: 0x00A8E38B
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_49);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_49) = value;
			}
		}

		// Token: 0x1700756D RID: 30061
		// (get) Token: 0x0602BF90 RID: 180112 RVA: 0x00A901A0 File Offset: 0x00A8E3A0
		// (set) Token: 0x0602BF91 RID: 180113 RVA: 0x00A901B0 File Offset: 0x00A8E3B0
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_50));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_50) = (byte)value;
			}
		}

		// Token: 0x1700756E RID: 30062
		// (get) Token: 0x0602BF92 RID: 180114 RVA: 0x00A901C1 File Offset: 0x00A8E3C1
		// (set) Token: 0x0602BF93 RID: 180115 RVA: 0x00A901D1 File Offset: 0x00A8E3D1
		public unsafe float 走跑混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x1700756F RID: 30063
		// (get) Token: 0x0602BF94 RID: 180116 RVA: 0x00A901E2 File Offset: 0x00A8E3E2
		// (set) Token: 0x0602BF95 RID: 180117 RVA: 0x00A901F2 File Offset: 0x00A8E3F2
		public unsafe bool IsTurnLeft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_52) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_52) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007570 RID: 30064
		// (get) Token: 0x0602BF96 RID: 180118 RVA: 0x00A90203 File Offset: 0x00A8E403
		// (set) Token: 0x0602BF97 RID: 180119 RVA: 0x00A90217 File Offset: 0x00A8E417
		public unsafe FRotator 角色旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x17007571 RID: 30065
		// (get) Token: 0x0602BF98 RID: 180120 RVA: 0x00A9022C File Offset: 0x00A8E42C
		// (set) Token: 0x0602BF99 RID: 180121 RVA: 0x00A9023C File Offset: 0x00A8E43C
		public unsafe int NpcEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x17007572 RID: 30066
		// (get) Token: 0x0602BF9A RID: 180122 RVA: 0x00A9024D File Offset: 0x00A8E44D
		// (set) Token: 0x0602BF9B RID: 180123 RVA: 0x00A9025D File Offset: 0x00A8E45D
		public unsafe float DeltaTimeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_55);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PasserbyNPC_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x0602BF9C RID: 180124 RVA: 0x00A90270 File Offset: 0x00A8E470
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceJumpPressed(ref float Speed)
		{
			ABP_PasserbyNPC_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x0602BF9D RID: 180125 RVA: 0x00A902C0 File Offset: 0x00A8E4C0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_PasserbyNPC_C.__基础层_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602BF9E RID: 180126 RVA: 0x00A90348 File Offset: 0x00A8E548
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_PasserbyNPC_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602BF9F RID: 180127 RVA: 0x00A903D0 File Offset: 0x00A8E5D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasInputRotate(ref bool Output_Get)
		{
			ABP_PasserbyNPC_C.__HasInputRotate_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__HasInputRotate_FunctionParams[(UIntPtr)91] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__HasInputRotate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__HasInputRotate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Output_Get = Output_Get;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__HasInputRotate_NativeFunctionPtr, (void*)ptr);
			Output_Get = ptr->Output_Get;
		}

		// Token: 0x0602BFA0 RID: 180128 RVA: 0x00A90420 File Offset: 0x00A8E620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 是否AI驱动(ref bool Result)
		{
			ABP_PasserbyNPC_C.__是否AI驱动_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__是否AI驱动_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__是否AI驱动_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__是否AI驱动_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__是否AI驱动_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602BFA1 RID: 180129 RVA: 0x00A9046F File Offset: 0x00A8E66F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色转身()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__更新角色转身_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFA2 RID: 180130 RVA: 0x00A90483 File Offset: 0x00A8E683
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__更新角色移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFA3 RID: 180131 RVA: 0x00A90497 File Offset: 0x00A8E697
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFA4 RID: 180132 RVA: 0x00A904AB File Offset: 0x00A8E6AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__更新角色信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFA5 RID: 180133 RVA: 0x00A904BF File Offset: 0x00A8E6BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFA6 RID: 180134 RVA: 0x00A904D4 File Offset: 0x00A8E6D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceSimulateJump(float Speed)
		{
			ABP_PasserbyNPC_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFA7 RID: 180135 RVA: 0x00A9051C File Offset: 0x00A8E71C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceFixHookDirect(FVector Offset)
		{
			ABP_PasserbyNPC_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFA8 RID: 180136 RVA: 0x00A90564 File Offset: 0x00A8E764
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceManipulateInteractDirection(float 角度)
		{
			ABP_PasserbyNPC_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFA9 RID: 180137 RVA: 0x00A905AC File Offset: 0x00A8E7AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceControlPoint(FVector Offset)
		{
			ABP_PasserbyNPC_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFAA RID: 180138 RVA: 0x00A905F4 File Offset: 0x00A8E7F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCompleted_A3A1D2D54B218959C2990CB343950233(FName NotifyName)
		{
			ABP_PasserbyNPC_C.__OnCompleted_A3A1D2D54B218959C2990CB343950233_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__OnCompleted_A3A1D2D54B218959C2990CB343950233_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__OnCompleted_A3A1D2D54B218959C2990CB343950233_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__OnCompleted_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnCompleted_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFAB RID: 180139 RVA: 0x00A9063C File Offset: 0x00A8E83C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBlendOut_A3A1D2D54B218959C2990CB343950233(FName NotifyName)
		{
			ABP_PasserbyNPC_C.__OnBlendOut_A3A1D2D54B218959C2990CB343950233_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__OnBlendOut_A3A1D2D54B218959C2990CB343950233_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__OnBlendOut_A3A1D2D54B218959C2990CB343950233_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__OnBlendOut_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnBlendOut_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFAC RID: 180140 RVA: 0x00A90684 File Offset: 0x00A8E884
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnInterrupted_A3A1D2D54B218959C2990CB343950233(FName NotifyName)
		{
			ABP_PasserbyNPC_C.__OnInterrupted_A3A1D2D54B218959C2990CB343950233_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__OnInterrupted_A3A1D2D54B218959C2990CB343950233_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__OnInterrupted_A3A1D2D54B218959C2990CB343950233_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__OnInterrupted_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnInterrupted_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFAD RID: 180141 RVA: 0x00A906CC File Offset: 0x00A8E8CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyBegin_A3A1D2D54B218959C2990CB343950233(FName NotifyName)
		{
			ABP_PasserbyNPC_C.__OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFAE RID: 180142 RVA: 0x00A90714 File Offset: 0x00A8E914
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyEnd_A3A1D2D54B218959C2990CB343950233(FName NotifyName)
		{
			ABP_PasserbyNPC_C.__OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFAF RID: 180143 RVA: 0x00A9075A File Offset: 0x00A8E95A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_KuroHumanIK_5759923140446264A60AAF8F8E69569C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_KuroHumanIK_5759923140446264A60AAF8F8E69569C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB0 RID: 180144 RVA: 0x00A9076E File Offset: 0x00A8E96E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_4AD6E0F94EC6BF6EE8A56C826C007198()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_4AD6E0F94EC6BF6EE8A56C826C007198_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB1 RID: 180145 RVA: 0x00A90782 File Offset: 0x00A8E982
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_ACD4238F4A75EB659610B7A908D1CEFA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_ACD4238F4A75EB659610B7A908D1CEFA_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB2 RID: 180146 RVA: 0x00A90796 File Offset: 0x00A8E996
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_8B2AB6FA4ADB0DD6D1591F8463E2A667()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_8B2AB6FA4ADB0DD6D1591F8463E2A667_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB3 RID: 180147 RVA: 0x00A907AA File Offset: 0x00A8E9AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_9805F6B749936A2C9F8E9889AEE038D1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_9805F6B749936A2C9F8E9889AEE038D1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB4 RID: 180148 RVA: 0x00A907BE File Offset: 0x00A8E9BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_D36D90C04928A3524B3FDD8A9E80D52E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_D36D90C04928A3524B3FDD8A9E80D52E_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB5 RID: 180149 RVA: 0x00A907D2 File Offset: 0x00A8E9D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFB6 RID: 180150 RVA: 0x00A907E6 File Offset: 0x00A8E9E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PasserbyNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BFB7 RID: 180151 RVA: 0x00A907FC File Offset: 0x00A8E9FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BFB8 RID: 180152 RVA: 0x00A90844 File Offset: 0x00A8EA44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PasserbyNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BFB9 RID: 180153 RVA: 0x00A9088B File Offset: 0x00A8EA8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_PlayMontage()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__AnimNotify_PlayMontage_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFBA RID: 180154 RVA: 0x00A9089F File Offset: 0x00A8EA9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602BFBB RID: 180155 RVA: 0x00A908B3 File Offset: 0x00A8EAB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PasserbyNPC_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BFBC RID: 180156 RVA: 0x00A908C8 File Offset: 0x00A8EAC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_PasserbyNPC(int EntryPoint)
		{
			ABP_PasserbyNPC_C.__ExecuteUbergraph_ABP_PasserbyNPC_FunctionParams* ptr = stackalloc ABP_PasserbyNPC_C.__ExecuteUbergraph_ABP_PasserbyNPC_FunctionParams[(UIntPtr)455] + 15L / (long)sizeof(ABP_PasserbyNPC_C.__ExecuteUbergraph_ABP_PasserbyNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PasserbyNPC_C.__ExecuteUbergraph_ABP_PasserbyNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PasserbyNPC_C.__ExecuteUbergraph_ABP_PasserbyNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BFBD RID: 180157 RVA: 0x00A90912 File Offset: 0x00A8EB12
		protected ABP_PasserbyNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018437 RID: 99383
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/ABP_PasserbyNPC.ABP_PasserbyNPC_C";

		// Token: 0x04018438 RID: 99384
		private static IntPtr _ClassPtr;

		// Token: 0x04018439 RID: 99385
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401843A RID: 99386
		internal static int __PropertyOffset_0;

		// Token: 0x0401843B RID: 99387
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401843C RID: 99388
		internal static int __PropertyOffset_1;

		// Token: 0x0401843D RID: 99389
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x0401843E RID: 99390
		internal static int __PropertyOffset_2;

		// Token: 0x0401843F RID: 99391
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x04018440 RID: 99392
		internal static int __PropertyOffset_3;

		// Token: 0x04018441 RID: 99393
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018442 RID: 99394
		internal static int __PropertyOffset_4;

		// Token: 0x04018443 RID: 99395
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04018444 RID: 99396
		internal static int __PropertyOffset_5;

		// Token: 0x04018445 RID: 99397
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04018446 RID: 99398
		internal static int __PropertyOffset_6;

		// Token: 0x04018447 RID: 99399
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04018448 RID: 99400
		internal static int __PropertyOffset_7;

		// Token: 0x04018449 RID: 99401
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x0401844A RID: 99402
		internal static int __PropertyOffset_8;

		// Token: 0x0401844B RID: 99403
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0401844C RID: 99404
		internal static int __PropertyOffset_9;

		// Token: 0x0401844D RID: 99405
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x0401844E RID: 99406
		internal static int __PropertyOffset_10;

		// Token: 0x0401844F RID: 99407
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018450 RID: 99408
		internal static int __PropertyOffset_11;

		// Token: 0x04018451 RID: 99409
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018452 RID: 99410
		internal static int __PropertyOffset_12;

		// Token: 0x04018453 RID: 99411
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04018454 RID: 99412
		internal static int __PropertyOffset_13;

		// Token: 0x04018455 RID: 99413
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04018456 RID: 99414
		internal static int __PropertyOffset_14;

		// Token: 0x04018457 RID: 99415
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04018458 RID: 99416
		internal static int __PropertyOffset_15;

		// Token: 0x04018459 RID: 99417
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401845A RID: 99418
		internal static int __PropertyOffset_16;

		// Token: 0x0401845B RID: 99419
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0401845C RID: 99420
		internal static int __PropertyOffset_17;

		// Token: 0x0401845D RID: 99421
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x0401845E RID: 99422
		internal static int __PropertyOffset_18;

		// Token: 0x0401845F RID: 99423
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018460 RID: 99424
		internal static int __PropertyOffset_19;

		// Token: 0x04018461 RID: 99425
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04018462 RID: 99426
		internal static int __PropertyOffset_20;

		// Token: 0x04018463 RID: 99427
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04018464 RID: 99428
		internal static int __PropertyOffset_21;

		// Token: 0x04018465 RID: 99429
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04018466 RID: 99430
		internal static int __PropertyOffset_22;

		// Token: 0x04018467 RID: 99431
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04018468 RID: 99432
		internal static int __PropertyOffset_23;

		// Token: 0x04018469 RID: 99433
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0401846A RID: 99434
		internal static int __PropertyOffset_24;

		// Token: 0x0401846B RID: 99435
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x0401846C RID: 99436
		internal static int __PropertyOffset_25;

		// Token: 0x0401846D RID: 99437
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x0401846E RID: 99438
		internal static int __PropertyOffset_26;

		// Token: 0x0401846F RID: 99439
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04018470 RID: 99440
		internal static int __PropertyOffset_27;

		// Token: 0x04018471 RID: 99441
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018472 RID: 99442
		internal static int __PropertyOffset_28;

		// Token: 0x04018473 RID: 99443
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018474 RID: 99444
		internal static int __PropertyOffset_29;

		// Token: 0x04018475 RID: 99445
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04018476 RID: 99446
		internal static int __PropertyOffset_30;

		// Token: 0x04018477 RID: 99447
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04018478 RID: 99448
		internal static int __PropertyOffset_31;

		// Token: 0x04018479 RID: 99449
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x0401847A RID: 99450
		internal static int __PropertyOffset_32;

		// Token: 0x0401847B RID: 99451
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x0401847C RID: 99452
		internal static int __PropertyOffset_33;

		// Token: 0x0401847D RID: 99453
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x0401847E RID: 99454
		internal static int __PropertyOffset_34;

		// Token: 0x0401847F RID: 99455
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x04018480 RID: 99456
		internal static int __PropertyOffset_35;

		// Token: 0x04018481 RID: 99457
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04018482 RID: 99458
		internal static int __PropertyOffset_36;

		// Token: 0x04018483 RID: 99459
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04018484 RID: 99460
		internal static int __PropertyOffset_37;

		// Token: 0x04018485 RID: 99461
		[Nullable(2)]
		private FAnimNode_RBF _AnimGraphNode_RBF;

		// Token: 0x04018486 RID: 99462
		internal static int __PropertyOffset_38;

		// Token: 0x04018487 RID: 99463
		[Nullable(2)]
		private FAnimNode_KuroHumanIK _AnimGraphNode_KuroHumanIK;

		// Token: 0x04018488 RID: 99464
		internal static int __PropertyOffset_39;

		// Token: 0x04018489 RID: 99465
		internal static int __PropertyOffset_40;

		// Token: 0x0401848A RID: 99466
		internal static int __PropertyOffset_41;

		// Token: 0x0401848B RID: 99467
		internal static int __PropertyOffset_42;

		// Token: 0x0401848C RID: 99468
		internal static int __PropertyOffset_43;

		// Token: 0x0401848D RID: 99469
		internal static int __PropertyOffset_44;

		// Token: 0x0401848E RID: 99470
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimMontage> _IdleMontageArray;

		// Token: 0x0401848F RID: 99471
		internal static int __PropertyOffset_45;

		// Token: 0x04018490 RID: 99472
		internal static int __PropertyOffset_46;

		// Token: 0x04018491 RID: 99473
		internal static int __PropertyOffset_47;

		// Token: 0x04018492 RID: 99474
		internal static int __PropertyOffset_48;

		// Token: 0x04018493 RID: 99475
		internal static int __PropertyOffset_49;

		// Token: 0x04018494 RID: 99476
		internal static int __PropertyOffset_50;

		// Token: 0x04018495 RID: 99477
		internal static int __PropertyOffset_51;

		// Token: 0x04018496 RID: 99478
		internal static int __PropertyOffset_52;

		// Token: 0x04018497 RID: 99479
		internal static int __PropertyOffset_53;

		// Token: 0x04018498 RID: 99480
		internal static int __PropertyOffset_54;

		// Token: 0x04018499 RID: 99481
		internal static int __PropertyOffset_55;

		// Token: 0x0401849A RID: 99482
		private static IntPtr __InterfaceJumpPressed_NativeFunctionPtr;

		// Token: 0x0401849B RID: 99483
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x0401849C RID: 99484
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401849D RID: 99485
		private static IntPtr __HasInputRotate_NativeFunctionPtr;

		// Token: 0x0401849E RID: 99486
		private static IntPtr __是否AI驱动_NativeFunctionPtr;

		// Token: 0x0401849F RID: 99487
		private static IntPtr __更新角色转身_NativeFunctionPtr;

		// Token: 0x040184A0 RID: 99488
		private static IntPtr __更新角色移动_NativeFunctionPtr;

		// Token: 0x040184A1 RID: 99489
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x040184A2 RID: 99490
		private static IntPtr __更新角色信息_NativeFunctionPtr;

		// Token: 0x040184A3 RID: 99491
		private static IntPtr __ClimbDash_NativeFunctionPtr;

		// Token: 0x040184A4 RID: 99492
		private static IntPtr __InterfaceSimulateJump_NativeFunctionPtr;

		// Token: 0x040184A5 RID: 99493
		private static IntPtr __InterfaceFixHookDirect_NativeFunctionPtr;

		// Token: 0x040184A6 RID: 99494
		private static IntPtr __InterfaceManipulateInteractDirection_NativeFunctionPtr;

		// Token: 0x040184A7 RID: 99495
		private static IntPtr __InterfaceControlPoint_NativeFunctionPtr;

		// Token: 0x040184A8 RID: 99496
		private static IntPtr __OnCompleted_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr;

		// Token: 0x040184A9 RID: 99497
		private static IntPtr __OnBlendOut_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr;

		// Token: 0x040184AA RID: 99498
		private static IntPtr __OnInterrupted_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr;

		// Token: 0x040184AB RID: 99499
		private static IntPtr __OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr;

		// Token: 0x040184AC RID: 99500
		private static IntPtr __OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_NativeFunctionPtr;

		// Token: 0x040184AD RID: 99501
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_KuroHumanIK_5759923140446264A60AAF8F8E69569C_NativeFunctionPtr;

		// Token: 0x040184AE RID: 99502
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_4AD6E0F94EC6BF6EE8A56C826C007198_NativeFunctionPtr;

		// Token: 0x040184AF RID: 99503
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_ACD4238F4A75EB659610B7A908D1CEFA_NativeFunctionPtr;

		// Token: 0x040184B0 RID: 99504
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_8B2AB6FA4ADB0DD6D1591F8463E2A667_NativeFunctionPtr;

		// Token: 0x040184B1 RID: 99505
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_9805F6B749936A2C9F8E9889AEE038D1_NativeFunctionPtr;

		// Token: 0x040184B2 RID: 99506
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PasserbyNPC_AnimGraphNode_TransitionResult_D36D90C04928A3524B3FDD8A9E80D52E_NativeFunctionPtr;

		// Token: 0x040184B3 RID: 99507
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x040184B4 RID: 99508
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040184B5 RID: 99509
		private static IntPtr __AnimNotify_PlayMontage_NativeFunctionPtr;

		// Token: 0x040184B6 RID: 99510
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x040184B7 RID: 99511
		private static IntPtr __ExecuteUbergraph_ABP_PasserbyNPC_NativeFunctionPtr;

		// Token: 0x0200A3EF RID: 41967
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x040331DE RID: 209374
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A3F0 RID: 41968
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x040331DF RID: 209375
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A3F1 RID: 41969
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x040331E0 RID: 209376
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A3F2 RID: 41970
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 76)]
		protected ref struct __HasInputRotate_FunctionParams
		{
			// Token: 0x040331E1 RID: 209377
			[FieldOffset(0)]
			public bool Output_Get;
		}

		// Token: 0x0200A3F3 RID: 41971
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __是否AI驱动_FunctionParams
		{
			// Token: 0x040331E2 RID: 209378
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A3F4 RID: 41972
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x040331E3 RID: 209379
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A3F5 RID: 41973
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x040331E4 RID: 209380
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A3F6 RID: 41974
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x040331E5 RID: 209381
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A3F7 RID: 41975
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x040331E6 RID: 209382
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A3F8 RID: 41976
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnCompleted_A3A1D2D54B218959C2990CB343950233_FunctionParams
		{
			// Token: 0x040331E7 RID: 209383
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3F9 RID: 41977
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnBlendOut_A3A1D2D54B218959C2990CB343950233_FunctionParams
		{
			// Token: 0x040331E8 RID: 209384
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3FA RID: 41978
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnInterrupted_A3A1D2D54B218959C2990CB343950233_FunctionParams
		{
			// Token: 0x040331E9 RID: 209385
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3FB RID: 41979
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyBegin_A3A1D2D54B218959C2990CB343950233_FunctionParams
		{
			// Token: 0x040331EA RID: 209386
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3FC RID: 41980
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyEnd_A3A1D2D54B218959C2990CB343950233_FunctionParams
		{
			// Token: 0x040331EB RID: 209387
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3FD RID: 41981
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x040331EC RID: 209388
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A3FE RID: 41982
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 440)]
		protected ref struct __ExecuteUbergraph_ABP_PasserbyNPC_FunctionParams
		{
			// Token: 0x040331ED RID: 209389
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
