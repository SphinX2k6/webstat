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
	// Token: 0x020040E8 RID: 16616
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/ABP_MultiStateNPC.ABP_MultiStateNPC_C")]
	[UnrealStructLayout(19312, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 19312)]
	public class ABP_MultiStateNPC_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_Animation_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602BDB0 RID: 179632 RVA: 0x00A8B803 File Offset: 0x00A89A03
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_MultiStateNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/ABP_MultiStateNPC.ABP_MultiStateNPC_C");
			}
			return ABP_MultiStateNPC_C._ClassPtr;
		}

		// Token: 0x0602BDB1 RID: 179633 RVA: 0x00A8B828 File Offset: 0x00A89A28
		public ABP_MultiStateNPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_MultiStateNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BDB2 RID: 179634 RVA: 0x00A8B850 File Offset: 0x00A89A50
		public ABP_MultiStateNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_MultiStateNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700749E RID: 29854
		// (get) Token: 0x0602BDB3 RID: 179635 RVA: 0x00A8B884 File Offset: 0x00A89A84
		// (set) Token: 0x0602BDB4 RID: 179636 RVA: 0x00A8B8BD File Offset: 0x00A89ABD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700749F RID: 29855
		// (get) Token: 0x0602BDB5 RID: 179637 RVA: 0x00A8B8E0 File Offset: 0x00A89AE0
		// (set) Token: 0x0602BDB6 RID: 179638 RVA: 0x00A8B919 File Offset: 0x00A89B19
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A0 RID: 29856
		// (get) Token: 0x0602BDB7 RID: 179639 RVA: 0x00A8B93C File Offset: 0x00A89B3C
		// (set) Token: 0x0602BDB8 RID: 179640 RVA: 0x00A8B975 File Offset: 0x00A89B75
		public FAnimNode_Slot AnimGraphNode_Slot_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_6) == null)
				{
					result = (this._AnimGraphNode_Slot_6 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A1 RID: 29857
		// (get) Token: 0x0602BDB9 RID: 179641 RVA: 0x00A8B998 File Offset: 0x00A89B98
		// (set) Token: 0x0602BDBA RID: 179642 RVA: 0x00A8B9D1 File Offset: 0x00A89BD1
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A2 RID: 29858
		// (get) Token: 0x0602BDBB RID: 179643 RVA: 0x00A8B9F4 File Offset: 0x00A89BF4
		// (set) Token: 0x0602BDBC RID: 179644 RVA: 0x00A8BA2D File Offset: 0x00A89C2D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A3 RID: 29859
		// (get) Token: 0x0602BDBD RID: 179645 RVA: 0x00A8BA50 File Offset: 0x00A89C50
		// (set) Token: 0x0602BDBE RID: 179646 RVA: 0x00A8BA89 File Offset: 0x00A89C89
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A4 RID: 29860
		// (get) Token: 0x0602BDBF RID: 179647 RVA: 0x00A8BAAC File Offset: 0x00A89CAC
		// (set) Token: 0x0602BDC0 RID: 179648 RVA: 0x00A8BAE5 File Offset: 0x00A89CE5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A5 RID: 29861
		// (get) Token: 0x0602BDC1 RID: 179649 RVA: 0x00A8BB08 File Offset: 0x00A89D08
		// (set) Token: 0x0602BDC2 RID: 179650 RVA: 0x00A8BB41 File Offset: 0x00A89D41
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A6 RID: 29862
		// (get) Token: 0x0602BDC3 RID: 179651 RVA: 0x00A8BB64 File Offset: 0x00A89D64
		// (set) Token: 0x0602BDC4 RID: 179652 RVA: 0x00A8BB9D File Offset: 0x00A89D9D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A7 RID: 29863
		// (get) Token: 0x0602BDC5 RID: 179653 RVA: 0x00A8BBC0 File Offset: 0x00A89DC0
		// (set) Token: 0x0602BDC6 RID: 179654 RVA: 0x00A8BBF9 File Offset: 0x00A89DF9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A8 RID: 29864
		// (get) Token: 0x0602BDC7 RID: 179655 RVA: 0x00A8BC1C File Offset: 0x00A89E1C
		// (set) Token: 0x0602BDC8 RID: 179656 RVA: 0x00A8BC55 File Offset: 0x00A89E55
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074A9 RID: 29865
		// (get) Token: 0x0602BDC9 RID: 179657 RVA: 0x00A8BC78 File Offset: 0x00A89E78
		// (set) Token: 0x0602BDCA RID: 179658 RVA: 0x00A8BCB1 File Offset: 0x00A89EB1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074AA RID: 29866
		// (get) Token: 0x0602BDCB RID: 179659 RVA: 0x00A8BCD4 File Offset: 0x00A89ED4
		// (set) Token: 0x0602BDCC RID: 179660 RVA: 0x00A8BD0D File Offset: 0x00A89F0D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074AB RID: 29867
		// (get) Token: 0x0602BDCD RID: 179661 RVA: 0x00A8BD30 File Offset: 0x00A89F30
		// (set) Token: 0x0602BDCE RID: 179662 RVA: 0x00A8BD69 File Offset: 0x00A89F69
		public FAnimNode_StateResult AnimGraphNode_StateResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_35) == null)
				{
					result = (this._AnimGraphNode_StateResult_35 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074AC RID: 29868
		// (get) Token: 0x0602BDCF RID: 179663 RVA: 0x00A8BD8C File Offset: 0x00A89F8C
		// (set) Token: 0x0602BDD0 RID: 179664 RVA: 0x00A8BDC5 File Offset: 0x00A89FC5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074AD RID: 29869
		// (get) Token: 0x0602BDD1 RID: 179665 RVA: 0x00A8BDE8 File Offset: 0x00A89FE8
		// (set) Token: 0x0602BDD2 RID: 179666 RVA: 0x00A8BE21 File Offset: 0x00A8A021
		public FAnimNode_StateResult AnimGraphNode_StateResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_34) == null)
				{
					result = (this._AnimGraphNode_StateResult_34 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074AE RID: 29870
		// (get) Token: 0x0602BDD3 RID: 179667 RVA: 0x00A8BE44 File Offset: 0x00A8A044
		// (set) Token: 0x0602BDD4 RID: 179668 RVA: 0x00A8BE7D File Offset: 0x00A8A07D
		public FAnimNode_StateResult AnimGraphNode_StateResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_33) == null)
				{
					result = (this._AnimGraphNode_StateResult_33 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074AF RID: 29871
		// (get) Token: 0x0602BDD5 RID: 179669 RVA: 0x00A8BEA0 File Offset: 0x00A8A0A0
		// (set) Token: 0x0602BDD6 RID: 179670 RVA: 0x00A8BED9 File Offset: 0x00A8A0D9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_10) == null)
				{
					result = (this._AnimGraphNode_StateMachine_10 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B0 RID: 29872
		// (get) Token: 0x0602BDD7 RID: 179671 RVA: 0x00A8BEFC File Offset: 0x00A8A0FC
		// (set) Token: 0x0602BDD8 RID: 179672 RVA: 0x00A8BF35 File Offset: 0x00A8A135
		public FAnimNode_StateResult AnimGraphNode_StateResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_32) == null)
				{
					result = (this._AnimGraphNode_StateResult_32 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B1 RID: 29873
		// (get) Token: 0x0602BDD9 RID: 179673 RVA: 0x00A8BF58 File Offset: 0x00A8A158
		// (set) Token: 0x0602BDDA RID: 179674 RVA: 0x00A8BF91 File Offset: 0x00A8A191
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B2 RID: 29874
		// (get) Token: 0x0602BDDB RID: 179675 RVA: 0x00A8BFB4 File Offset: 0x00A8A1B4
		// (set) Token: 0x0602BDDC RID: 179676 RVA: 0x00A8BFED File Offset: 0x00A8A1ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B3 RID: 29875
		// (get) Token: 0x0602BDDD RID: 179677 RVA: 0x00A8C010 File Offset: 0x00A8A210
		// (set) Token: 0x0602BDDE RID: 179678 RVA: 0x00A8C049 File Offset: 0x00A8A249
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B4 RID: 29876
		// (get) Token: 0x0602BDDF RID: 179679 RVA: 0x00A8C06C File Offset: 0x00A8A26C
		// (set) Token: 0x0602BDE0 RID: 179680 RVA: 0x00A8C0A5 File Offset: 0x00A8A2A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_31) == null)
				{
					result = (this._AnimGraphNode_StateResult_31 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B5 RID: 29877
		// (get) Token: 0x0602BDE1 RID: 179681 RVA: 0x00A8C0C8 File Offset: 0x00A8A2C8
		// (set) Token: 0x0602BDE2 RID: 179682 RVA: 0x00A8C101 File Offset: 0x00A8A301
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B6 RID: 29878
		// (get) Token: 0x0602BDE3 RID: 179683 RVA: 0x00A8C124 File Offset: 0x00A8A324
		// (set) Token: 0x0602BDE4 RID: 179684 RVA: 0x00A8C15D File Offset: 0x00A8A35D
		public FAnimNode_StateResult AnimGraphNode_StateResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_30) == null)
				{
					result = (this._AnimGraphNode_StateResult_30 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B7 RID: 29879
		// (get) Token: 0x0602BDE5 RID: 179685 RVA: 0x00A8C180 File Offset: 0x00A8A380
		// (set) Token: 0x0602BDE6 RID: 179686 RVA: 0x00A8C1B9 File Offset: 0x00A8A3B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B8 RID: 29880
		// (get) Token: 0x0602BDE7 RID: 179687 RVA: 0x00A8C1DC File Offset: 0x00A8A3DC
		// (set) Token: 0x0602BDE8 RID: 179688 RVA: 0x00A8C215 File Offset: 0x00A8A415
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_9) == null)
				{
					result = (this._AnimGraphNode_StateMachine_9 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074B9 RID: 29881
		// (get) Token: 0x0602BDE9 RID: 179689 RVA: 0x00A8C238 File Offset: 0x00A8A438
		// (set) Token: 0x0602BDEA RID: 179690 RVA: 0x00A8C271 File Offset: 0x00A8A471
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074BA RID: 29882
		// (get) Token: 0x0602BDEB RID: 179691 RVA: 0x00A8C294 File Offset: 0x00A8A494
		// (set) Token: 0x0602BDEC RID: 179692 RVA: 0x00A8C2CD File Offset: 0x00A8A4CD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074BB RID: 29883
		// (get) Token: 0x0602BDED RID: 179693 RVA: 0x00A8C2F0 File Offset: 0x00A8A4F0
		// (set) Token: 0x0602BDEE RID: 179694 RVA: 0x00A8C329 File Offset: 0x00A8A529
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074BC RID: 29884
		// (get) Token: 0x0602BDEF RID: 179695 RVA: 0x00A8C34C File Offset: 0x00A8A54C
		// (set) Token: 0x0602BDF0 RID: 179696 RVA: 0x00A8C385 File Offset: 0x00A8A585
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074BD RID: 29885
		// (get) Token: 0x0602BDF1 RID: 179697 RVA: 0x00A8C3A8 File Offset: 0x00A8A5A8
		// (set) Token: 0x0602BDF2 RID: 179698 RVA: 0x00A8C3E1 File Offset: 0x00A8A5E1
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074BE RID: 29886
		// (get) Token: 0x0602BDF3 RID: 179699 RVA: 0x00A8C404 File Offset: 0x00A8A604
		// (set) Token: 0x0602BDF4 RID: 179700 RVA: 0x00A8C43D File Offset: 0x00A8A63D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074BF RID: 29887
		// (get) Token: 0x0602BDF5 RID: 179701 RVA: 0x00A8C460 File Offset: 0x00A8A660
		// (set) Token: 0x0602BDF6 RID: 179702 RVA: 0x00A8C499 File Offset: 0x00A8A699
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C0 RID: 29888
		// (get) Token: 0x0602BDF7 RID: 179703 RVA: 0x00A8C4BC File Offset: 0x00A8A6BC
		// (set) Token: 0x0602BDF8 RID: 179704 RVA: 0x00A8C4F5 File Offset: 0x00A8A6F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C1 RID: 29889
		// (get) Token: 0x0602BDF9 RID: 179705 RVA: 0x00A8C518 File Offset: 0x00A8A718
		// (set) Token: 0x0602BDFA RID: 179706 RVA: 0x00A8C551 File Offset: 0x00A8A751
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_8) == null)
				{
					result = (this._AnimGraphNode_StateMachine_8 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C2 RID: 29890
		// (get) Token: 0x0602BDFB RID: 179707 RVA: 0x00A8C574 File Offset: 0x00A8A774
		// (set) Token: 0x0602BDFC RID: 179708 RVA: 0x00A8C5AD File Offset: 0x00A8A7AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C3 RID: 29891
		// (get) Token: 0x0602BDFD RID: 179709 RVA: 0x00A8C5D0 File Offset: 0x00A8A7D0
		// (set) Token: 0x0602BDFE RID: 179710 RVA: 0x00A8C609 File Offset: 0x00A8A809
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C4 RID: 29892
		// (get) Token: 0x0602BDFF RID: 179711 RVA: 0x00A8C62C File Offset: 0x00A8A82C
		// (set) Token: 0x0602BE00 RID: 179712 RVA: 0x00A8C665 File Offset: 0x00A8A865
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C5 RID: 29893
		// (get) Token: 0x0602BE01 RID: 179713 RVA: 0x00A8C688 File Offset: 0x00A8A888
		// (set) Token: 0x0602BE02 RID: 179714 RVA: 0x00A8C6C1 File Offset: 0x00A8A8C1
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_3) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_3 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C6 RID: 29894
		// (get) Token: 0x0602BE03 RID: 179715 RVA: 0x00A8C6E4 File Offset: 0x00A8A8E4
		// (set) Token: 0x0602BE04 RID: 179716 RVA: 0x00A8C71D File Offset: 0x00A8A91D
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C7 RID: 29895
		// (get) Token: 0x0602BE05 RID: 179717 RVA: 0x00A8C740 File Offset: 0x00A8A940
		// (set) Token: 0x0602BE06 RID: 179718 RVA: 0x00A8C779 File Offset: 0x00A8A979
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_2) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_2 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C8 RID: 29896
		// (get) Token: 0x0602BE07 RID: 179719 RVA: 0x00A8C79C File Offset: 0x00A8A99C
		// (set) Token: 0x0602BE08 RID: 179720 RVA: 0x00A8C7D5 File Offset: 0x00A8A9D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074C9 RID: 29897
		// (get) Token: 0x0602BE09 RID: 179721 RVA: 0x00A8C7F8 File Offset: 0x00A8A9F8
		// (set) Token: 0x0602BE0A RID: 179722 RVA: 0x00A8C831 File Offset: 0x00A8AA31
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074CA RID: 29898
		// (get) Token: 0x0602BE0B RID: 179723 RVA: 0x00A8C854 File Offset: 0x00A8AA54
		// (set) Token: 0x0602BE0C RID: 179724 RVA: 0x00A8C88D File Offset: 0x00A8AA8D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_7) == null)
				{
					result = (this._AnimGraphNode_StateMachine_7 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074CB RID: 29899
		// (get) Token: 0x0602BE0D RID: 179725 RVA: 0x00A8C8B0 File Offset: 0x00A8AAB0
		// (set) Token: 0x0602BE0E RID: 179726 RVA: 0x00A8C8E9 File Offset: 0x00A8AAE9
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074CC RID: 29900
		// (get) Token: 0x0602BE0F RID: 179727 RVA: 0x00A8C90C File Offset: 0x00A8AB0C
		// (set) Token: 0x0602BE10 RID: 179728 RVA: 0x00A8C945 File Offset: 0x00A8AB45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074CD RID: 29901
		// (get) Token: 0x0602BE11 RID: 179729 RVA: 0x00A8C968 File Offset: 0x00A8AB68
		// (set) Token: 0x0602BE12 RID: 179730 RVA: 0x00A8C9A1 File Offset: 0x00A8ABA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074CE RID: 29902
		// (get) Token: 0x0602BE13 RID: 179731 RVA: 0x00A8C9C4 File Offset: 0x00A8ABC4
		// (set) Token: 0x0602BE14 RID: 179732 RVA: 0x00A8C9FD File Offset: 0x00A8ABFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074CF RID: 29903
		// (get) Token: 0x0602BE15 RID: 179733 RVA: 0x00A8CA20 File Offset: 0x00A8AC20
		// (set) Token: 0x0602BE16 RID: 179734 RVA: 0x00A8CA59 File Offset: 0x00A8AC59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D0 RID: 29904
		// (get) Token: 0x0602BE17 RID: 179735 RVA: 0x00A8CA7C File Offset: 0x00A8AC7C
		// (set) Token: 0x0602BE18 RID: 179736 RVA: 0x00A8CAB5 File Offset: 0x00A8ACB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D1 RID: 29905
		// (get) Token: 0x0602BE19 RID: 179737 RVA: 0x00A8CAD8 File Offset: 0x00A8ACD8
		// (set) Token: 0x0602BE1A RID: 179738 RVA: 0x00A8CB11 File Offset: 0x00A8AD11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D2 RID: 29906
		// (get) Token: 0x0602BE1B RID: 179739 RVA: 0x00A8CB34 File Offset: 0x00A8AD34
		// (set) Token: 0x0602BE1C RID: 179740 RVA: 0x00A8CB6D File Offset: 0x00A8AD6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D3 RID: 29907
		// (get) Token: 0x0602BE1D RID: 179741 RVA: 0x00A8CB90 File Offset: 0x00A8AD90
		// (set) Token: 0x0602BE1E RID: 179742 RVA: 0x00A8CBC9 File Offset: 0x00A8ADC9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D4 RID: 29908
		// (get) Token: 0x0602BE1F RID: 179743 RVA: 0x00A8CBEC File Offset: 0x00A8ADEC
		// (set) Token: 0x0602BE20 RID: 179744 RVA: 0x00A8CC25 File Offset: 0x00A8AE25
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D5 RID: 29909
		// (get) Token: 0x0602BE21 RID: 179745 RVA: 0x00A8CC48 File Offset: 0x00A8AE48
		// (set) Token: 0x0602BE22 RID: 179746 RVA: 0x00A8CC81 File Offset: 0x00A8AE81
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D6 RID: 29910
		// (get) Token: 0x0602BE23 RID: 179747 RVA: 0x00A8CCA4 File Offset: 0x00A8AEA4
		// (set) Token: 0x0602BE24 RID: 179748 RVA: 0x00A8CCDD File Offset: 0x00A8AEDD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D7 RID: 29911
		// (get) Token: 0x0602BE25 RID: 179749 RVA: 0x00A8CD00 File Offset: 0x00A8AF00
		// (set) Token: 0x0602BE26 RID: 179750 RVA: 0x00A8CD39 File Offset: 0x00A8AF39
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D8 RID: 29912
		// (get) Token: 0x0602BE27 RID: 179751 RVA: 0x00A8CD5C File Offset: 0x00A8AF5C
		// (set) Token: 0x0602BE28 RID: 179752 RVA: 0x00A8CD95 File Offset: 0x00A8AF95
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074D9 RID: 29913
		// (get) Token: 0x0602BE29 RID: 179753 RVA: 0x00A8CDB8 File Offset: 0x00A8AFB8
		// (set) Token: 0x0602BE2A RID: 179754 RVA: 0x00A8CDF1 File Offset: 0x00A8AFF1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_6) == null)
				{
					result = (this._AnimGraphNode_StateMachine_6 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074DA RID: 29914
		// (get) Token: 0x0602BE2B RID: 179755 RVA: 0x00A8CE14 File Offset: 0x00A8B014
		// (set) Token: 0x0602BE2C RID: 179756 RVA: 0x00A8CE4D File Offset: 0x00A8B04D
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074DB RID: 29915
		// (get) Token: 0x0602BE2D RID: 179757 RVA: 0x00A8CE70 File Offset: 0x00A8B070
		// (set) Token: 0x0602BE2E RID: 179758 RVA: 0x00A8CEA9 File Offset: 0x00A8B0A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074DC RID: 29916
		// (get) Token: 0x0602BE2F RID: 179759 RVA: 0x00A8CECC File Offset: 0x00A8B0CC
		// (set) Token: 0x0602BE30 RID: 179760 RVA: 0x00A8CF05 File Offset: 0x00A8B105
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074DD RID: 29917
		// (get) Token: 0x0602BE31 RID: 179761 RVA: 0x00A8CF28 File Offset: 0x00A8B128
		// (set) Token: 0x0602BE32 RID: 179762 RVA: 0x00A8CF61 File Offset: 0x00A8B161
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074DE RID: 29918
		// (get) Token: 0x0602BE33 RID: 179763 RVA: 0x00A8CF84 File Offset: 0x00A8B184
		// (set) Token: 0x0602BE34 RID: 179764 RVA: 0x00A8CFBD File Offset: 0x00A8B1BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074DF RID: 29919
		// (get) Token: 0x0602BE35 RID: 179765 RVA: 0x00A8CFE0 File Offset: 0x00A8B1E0
		// (set) Token: 0x0602BE36 RID: 179766 RVA: 0x00A8D019 File Offset: 0x00A8B219
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E0 RID: 29920
		// (get) Token: 0x0602BE37 RID: 179767 RVA: 0x00A8D03C File Offset: 0x00A8B23C
		// (set) Token: 0x0602BE38 RID: 179768 RVA: 0x00A8D075 File Offset: 0x00A8B275
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E1 RID: 29921
		// (get) Token: 0x0602BE39 RID: 179769 RVA: 0x00A8D098 File Offset: 0x00A8B298
		// (set) Token: 0x0602BE3A RID: 179770 RVA: 0x00A8D0D1 File Offset: 0x00A8B2D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E2 RID: 29922
		// (get) Token: 0x0602BE3B RID: 179771 RVA: 0x00A8D0F4 File Offset: 0x00A8B2F4
		// (set) Token: 0x0602BE3C RID: 179772 RVA: 0x00A8D12D File Offset: 0x00A8B32D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_5) == null)
				{
					result = (this._AnimGraphNode_StateMachine_5 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E3 RID: 29923
		// (get) Token: 0x0602BE3D RID: 179773 RVA: 0x00A8D150 File Offset: 0x00A8B350
		// (set) Token: 0x0602BE3E RID: 179774 RVA: 0x00A8D189 File Offset: 0x00A8B389
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E4 RID: 29924
		// (get) Token: 0x0602BE3F RID: 179775 RVA: 0x00A8D1AC File Offset: 0x00A8B3AC
		// (set) Token: 0x0602BE40 RID: 179776 RVA: 0x00A8D1E5 File Offset: 0x00A8B3E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E5 RID: 29925
		// (get) Token: 0x0602BE41 RID: 179777 RVA: 0x00A8D208 File Offset: 0x00A8B408
		// (set) Token: 0x0602BE42 RID: 179778 RVA: 0x00A8D241 File Offset: 0x00A8B441
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E6 RID: 29926
		// (get) Token: 0x0602BE43 RID: 179779 RVA: 0x00A8D264 File Offset: 0x00A8B464
		// (set) Token: 0x0602BE44 RID: 179780 RVA: 0x00A8D29D File Offset: 0x00A8B49D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E7 RID: 29927
		// (get) Token: 0x0602BE45 RID: 179781 RVA: 0x00A8D2C0 File Offset: 0x00A8B4C0
		// (set) Token: 0x0602BE46 RID: 179782 RVA: 0x00A8D2F9 File Offset: 0x00A8B4F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E8 RID: 29928
		// (get) Token: 0x0602BE47 RID: 179783 RVA: 0x00A8D31C File Offset: 0x00A8B51C
		// (set) Token: 0x0602BE48 RID: 179784 RVA: 0x00A8D355 File Offset: 0x00A8B555
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074E9 RID: 29929
		// (get) Token: 0x0602BE49 RID: 179785 RVA: 0x00A8D378 File Offset: 0x00A8B578
		// (set) Token: 0x0602BE4A RID: 179786 RVA: 0x00A8D3B1 File Offset: 0x00A8B5B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074EA RID: 29930
		// (get) Token: 0x0602BE4B RID: 179787 RVA: 0x00A8D3D4 File Offset: 0x00A8B5D4
		// (set) Token: 0x0602BE4C RID: 179788 RVA: 0x00A8D40D File Offset: 0x00A8B60D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074EB RID: 29931
		// (get) Token: 0x0602BE4D RID: 179789 RVA: 0x00A8D430 File Offset: 0x00A8B630
		// (set) Token: 0x0602BE4E RID: 179790 RVA: 0x00A8D469 File Offset: 0x00A8B669
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074EC RID: 29932
		// (get) Token: 0x0602BE4F RID: 179791 RVA: 0x00A8D48C File Offset: 0x00A8B68C
		// (set) Token: 0x0602BE50 RID: 179792 RVA: 0x00A8D4C5 File Offset: 0x00A8B6C5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074ED RID: 29933
		// (get) Token: 0x0602BE51 RID: 179793 RVA: 0x00A8D4E8 File Offset: 0x00A8B6E8
		// (set) Token: 0x0602BE52 RID: 179794 RVA: 0x00A8D521 File Offset: 0x00A8B721
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074EE RID: 29934
		// (get) Token: 0x0602BE53 RID: 179795 RVA: 0x00A8D544 File Offset: 0x00A8B744
		// (set) Token: 0x0602BE54 RID: 179796 RVA: 0x00A8D57D File Offset: 0x00A8B77D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074EF RID: 29935
		// (get) Token: 0x0602BE55 RID: 179797 RVA: 0x00A8D5A0 File Offset: 0x00A8B7A0
		// (set) Token: 0x0602BE56 RID: 179798 RVA: 0x00A8D5D9 File Offset: 0x00A8B7D9
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F0 RID: 29936
		// (get) Token: 0x0602BE57 RID: 179799 RVA: 0x00A8D5FC File Offset: 0x00A8B7FC
		// (set) Token: 0x0602BE58 RID: 179800 RVA: 0x00A8D635 File Offset: 0x00A8B835
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F1 RID: 29937
		// (get) Token: 0x0602BE59 RID: 179801 RVA: 0x00A8D658 File Offset: 0x00A8B858
		// (set) Token: 0x0602BE5A RID: 179802 RVA: 0x00A8D691 File Offset: 0x00A8B891
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F2 RID: 29938
		// (get) Token: 0x0602BE5B RID: 179803 RVA: 0x00A8D6B4 File Offset: 0x00A8B8B4
		// (set) Token: 0x0602BE5C RID: 179804 RVA: 0x00A8D6ED File Offset: 0x00A8B8ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F3 RID: 29939
		// (get) Token: 0x0602BE5D RID: 179805 RVA: 0x00A8D710 File Offset: 0x00A8B910
		// (set) Token: 0x0602BE5E RID: 179806 RVA: 0x00A8D749 File Offset: 0x00A8B949
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F4 RID: 29940
		// (get) Token: 0x0602BE5F RID: 179807 RVA: 0x00A8D76C File Offset: 0x00A8B96C
		// (set) Token: 0x0602BE60 RID: 179808 RVA: 0x00A8D7A5 File Offset: 0x00A8B9A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F5 RID: 29941
		// (get) Token: 0x0602BE61 RID: 179809 RVA: 0x00A8D7C8 File Offset: 0x00A8B9C8
		// (set) Token: 0x0602BE62 RID: 179810 RVA: 0x00A8D801 File Offset: 0x00A8BA01
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F6 RID: 29942
		// (get) Token: 0x0602BE63 RID: 179811 RVA: 0x00A8D824 File Offset: 0x00A8BA24
		// (set) Token: 0x0602BE64 RID: 179812 RVA: 0x00A8D85D File Offset: 0x00A8BA5D
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F7 RID: 29943
		// (get) Token: 0x0602BE65 RID: 179813 RVA: 0x00A8D880 File Offset: 0x00A8BA80
		// (set) Token: 0x0602BE66 RID: 179814 RVA: 0x00A8D8B9 File Offset: 0x00A8BAB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F8 RID: 29944
		// (get) Token: 0x0602BE67 RID: 179815 RVA: 0x00A8D8DC File Offset: 0x00A8BADC
		// (set) Token: 0x0602BE68 RID: 179816 RVA: 0x00A8D915 File Offset: 0x00A8BB15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074F9 RID: 29945
		// (get) Token: 0x0602BE69 RID: 179817 RVA: 0x00A8D938 File Offset: 0x00A8BB38
		// (set) Token: 0x0602BE6A RID: 179818 RVA: 0x00A8D971 File Offset: 0x00A8BB71
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074FA RID: 29946
		// (get) Token: 0x0602BE6B RID: 179819 RVA: 0x00A8D994 File Offset: 0x00A8BB94
		// (set) Token: 0x0602BE6C RID: 179820 RVA: 0x00A8D9CD File Offset: 0x00A8BBCD
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074FB RID: 29947
		// (get) Token: 0x0602BE6D RID: 179821 RVA: 0x00A8D9F0 File Offset: 0x00A8BBF0
		// (set) Token: 0x0602BE6E RID: 179822 RVA: 0x00A8DA29 File Offset: 0x00A8BC29
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074FC RID: 29948
		// (get) Token: 0x0602BE6F RID: 179823 RVA: 0x00A8DA4C File Offset: 0x00A8BC4C
		// (set) Token: 0x0602BE70 RID: 179824 RVA: 0x00A8DA85 File Offset: 0x00A8BC85
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074FD RID: 29949
		// (get) Token: 0x0602BE71 RID: 179825 RVA: 0x00A8DAA8 File Offset: 0x00A8BCA8
		// (set) Token: 0x0602BE72 RID: 179826 RVA: 0x00A8DAE1 File Offset: 0x00A8BCE1
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074FE RID: 29950
		// (get) Token: 0x0602BE73 RID: 179827 RVA: 0x00A8DB04 File Offset: 0x00A8BD04
		// (set) Token: 0x0602BE74 RID: 179828 RVA: 0x00A8DB3D File Offset: 0x00A8BD3D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170074FF RID: 29951
		// (get) Token: 0x0602BE75 RID: 179829 RVA: 0x00A8DB60 File Offset: 0x00A8BD60
		// (set) Token: 0x0602BE76 RID: 179830 RVA: 0x00A8DB99 File Offset: 0x00A8BD99
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007500 RID: 29952
		// (get) Token: 0x0602BE77 RID: 179831 RVA: 0x00A8DBBC File Offset: 0x00A8BDBC
		// (set) Token: 0x0602BE78 RID: 179832 RVA: 0x00A8DBF5 File Offset: 0x00A8BDF5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007501 RID: 29953
		// (get) Token: 0x0602BE79 RID: 179833 RVA: 0x00A8DC18 File Offset: 0x00A8BE18
		// (set) Token: 0x0602BE7A RID: 179834 RVA: 0x00A8DC51 File Offset: 0x00A8BE51
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007502 RID: 29954
		// (get) Token: 0x0602BE7B RID: 179835 RVA: 0x00A8DC74 File Offset: 0x00A8BE74
		// (set) Token: 0x0602BE7C RID: 179836 RVA: 0x00A8DCAD File Offset: 0x00A8BEAD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007503 RID: 29955
		// (get) Token: 0x0602BE7D RID: 179837 RVA: 0x00A8DCD0 File Offset: 0x00A8BED0
		// (set) Token: 0x0602BE7E RID: 179838 RVA: 0x00A8DD09 File Offset: 0x00A8BF09
		public FAnimNode_Slot AnimGraphNode_Slot_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_5) == null)
				{
					result = (this._AnimGraphNode_Slot_5 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007504 RID: 29956
		// (get) Token: 0x0602BE7F RID: 179839 RVA: 0x00A8DD2C File Offset: 0x00A8BF2C
		// (set) Token: 0x0602BE80 RID: 179840 RVA: 0x00A8DD65 File Offset: 0x00A8BF65
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_1) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_1 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007505 RID: 29957
		// (get) Token: 0x0602BE81 RID: 179841 RVA: 0x00A8DD88 File Offset: 0x00A8BF88
		// (set) Token: 0x0602BE82 RID: 179842 RVA: 0x00A8DDC1 File Offset: 0x00A8BFC1
		public FAnimNode_Slot AnimGraphNode_Slot_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_4) == null)
				{
					result = (this._AnimGraphNode_Slot_4 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007506 RID: 29958
		// (get) Token: 0x0602BE83 RID: 179843 RVA: 0x00A8DDE4 File Offset: 0x00A8BFE4
		// (set) Token: 0x0602BE84 RID: 179844 RVA: 0x00A8DE1D File Offset: 0x00A8C01D
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007507 RID: 29959
		// (get) Token: 0x0602BE85 RID: 179845 RVA: 0x00A8DE40 File Offset: 0x00A8C040
		// (set) Token: 0x0602BE86 RID: 179846 RVA: 0x00A8DE79 File Offset: 0x00A8C079
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007508 RID: 29960
		// (get) Token: 0x0602BE87 RID: 179847 RVA: 0x00A8DE9C File Offset: 0x00A8C09C
		// (set) Token: 0x0602BE88 RID: 179848 RVA: 0x00A8DED5 File Offset: 0x00A8C0D5
		public FAnimNode_KuroSlotLayeredBlend AnimGraphNode_KuroSlotLayeredBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_KuroSlotLayeredBlend result;
				if ((result = this._AnimGraphNode_KuroSlotLayeredBlend) == null)
				{
					result = (this._AnimGraphNode_KuroSlotLayeredBlend = new FAnimNode_KuroSlotLayeredBlend(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_KuroSlotLayeredBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007509 RID: 29961
		// (get) Token: 0x0602BE89 RID: 179849 RVA: 0x00A8DEF8 File Offset: 0x00A8C0F8
		// (set) Token: 0x0602BE8A RID: 179850 RVA: 0x00A8DF31 File Offset: 0x00A8C131
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700750A RID: 29962
		// (get) Token: 0x0602BE8B RID: 179851 RVA: 0x00A8DF54 File Offset: 0x00A8C154
		// (set) Token: 0x0602BE8C RID: 179852 RVA: 0x00A8DF8D File Offset: 0x00A8C18D
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700750B RID: 29963
		// (get) Token: 0x0602BE8D RID: 179853 RVA: 0x00A8DFB0 File Offset: 0x00A8C1B0
		// (set) Token: 0x0602BE8E RID: 179854 RVA: 0x00A8DFE9 File Offset: 0x00A8C1E9
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700750C RID: 29964
		// (get) Token: 0x0602BE8F RID: 179855 RVA: 0x00A8E00C File Offset: 0x00A8C20C
		// (set) Token: 0x0602BE90 RID: 179856 RVA: 0x00A8E045 File Offset: 0x00A8C245
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700750D RID: 29965
		// (get) Token: 0x0602BE91 RID: 179857 RVA: 0x00A8E068 File Offset: 0x00A8C268
		// (set) Token: 0x0602BE92 RID: 179858 RVA: 0x00A8E0A1 File Offset: 0x00A8C2A1
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700750E RID: 29966
		// (get) Token: 0x0602BE93 RID: 179859 RVA: 0x00A8E0C4 File Offset: 0x00A8C2C4
		// (set) Token: 0x0602BE94 RID: 179860 RVA: 0x00A8E0FD File Offset: 0x00A8C2FD
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700750F RID: 29967
		// (get) Token: 0x0602BE95 RID: 179861 RVA: 0x00A8E120 File Offset: 0x00A8C320
		// (set) Token: 0x0602BE96 RID: 179862 RVA: 0x00A8E159 File Offset: 0x00A8C359
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007510 RID: 29968
		// (get) Token: 0x0602BE97 RID: 179863 RVA: 0x00A8E17C File Offset: 0x00A8C37C
		// (set) Token: 0x0602BE98 RID: 179864 RVA: 0x00A8E1B5 File Offset: 0x00A8C3B5
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007511 RID: 29969
		// (get) Token: 0x0602BE99 RID: 179865 RVA: 0x00A8E1D8 File Offset: 0x00A8C3D8
		// (set) Token: 0x0602BE9A RID: 179866 RVA: 0x00A8E211 File Offset: 0x00A8C411
		public FAnimNode_RBF AnimGraphNode_RBF
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RBF result;
				if ((result = this._AnimGraphNode_RBF) == null)
				{
					result = (this._AnimGraphNode_RBF = new FAnimNode_RBF(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_115, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RBF.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_115, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007512 RID: 29970
		// (get) Token: 0x0602BE9B RID: 179867 RVA: 0x00A8E234 File Offset: 0x00A8C434
		// (set) Token: 0x0602BE9C RID: 179868 RVA: 0x00A8E26D File Offset: 0x00A8C46D
		public FAnimNode_LinkedAnimGraph AnimGraphNode_LinkedAnimGraph
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimGraph result;
				if ((result = this._AnimGraphNode_LinkedAnimGraph) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimGraph = new FAnimNode_LinkedAnimGraph(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_116, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimGraph.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_116, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007513 RID: 29971
		// (get) Token: 0x0602BE9D RID: 179869 RVA: 0x00A8E290 File Offset: 0x00A8C490
		// (set) Token: 0x0602BE9E RID: 179870 RVA: 0x00A8E2C9 File Offset: 0x00A8C4C9
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves_1) == null)
				{
					result = (this._AnimGraphNode_CombineCurves_1 = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_117, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_117, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007514 RID: 29972
		// (get) Token: 0x0602BE9F RID: 179871 RVA: 0x00A8E2EC File Offset: 0x00A8C4EC
		// (set) Token: 0x0602BEA0 RID: 179872 RVA: 0x00A8E325 File Offset: 0x00A8C525
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_118, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007515 RID: 29973
		// (get) Token: 0x0602BEA1 RID: 179873 RVA: 0x00A8E348 File Offset: 0x00A8C548
		// (set) Token: 0x0602BEA2 RID: 179874 RVA: 0x00A8E381 File Offset: 0x00A8C581
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_119, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_119, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007516 RID: 29974
		// (get) Token: 0x0602BEA3 RID: 179875 RVA: 0x00A8E3A4 File Offset: 0x00A8C5A4
		// (set) Token: 0x0602BEA4 RID: 179876 RVA: 0x00A8E3DD File Offset: 0x00A8C5DD
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves) == null)
				{
					result = (this._AnimGraphNode_CombineCurves = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_120, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_120, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007517 RID: 29975
		// (get) Token: 0x0602BEA5 RID: 179877 RVA: 0x00A8E400 File Offset: 0x00A8C600
		// (set) Token: 0x0602BEA6 RID: 179878 RVA: 0x00A8E439 File Offset: 0x00A8C639
		public FAnimNode_TextureFace AnimGraphNode_TextureFace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TextureFace result;
				if ((result = this._AnimGraphNode_TextureFace) == null)
				{
					result = (this._AnimGraphNode_TextureFace = new FAnimNode_TextureFace(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_121, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TextureFace.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_121, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007518 RID: 29976
		// (get) Token: 0x0602BEA7 RID: 179879 RVA: 0x00A8E45C File Offset: 0x00A8C65C
		// (set) Token: 0x0602BEA8 RID: 179880 RVA: 0x00A8E495 File Offset: 0x00A8C695
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_122, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_122, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007519 RID: 29977
		// (get) Token: 0x0602BEA9 RID: 179881 RVA: 0x00A8E4B6 File Offset: 0x00A8C6B6
		// (set) Token: 0x0602BEAA RID: 179882 RVA: 0x00A8E4CA File Offset: 0x00A8C6CA
		[Nullable(2)]
		public unsafe BP_BaseNPC_C 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BaseNPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MultiStateNPC_C.__PropertyOffset_123);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MultiStateNPC_C.__PropertyOffset_123, value);
			}
		}

		// Token: 0x1700751A RID: 29978
		// (get) Token: 0x0602BEAB RID: 179883 RVA: 0x00A8E4DF File Offset: 0x00A8C6DF
		// (set) Token: 0x0602BEAC RID: 179884 RVA: 0x00A8E4F3 File Offset: 0x00A8C6F3
		public unsafe FVector 移动输入向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_124);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_124) = value;
			}
		}

		// Token: 0x1700751B RID: 29979
		// (get) Token: 0x0602BEAD RID: 179885 RVA: 0x00A8E508 File Offset: 0x00A8C708
		// (set) Token: 0x0602BEAE RID: 179886 RVA: 0x00A8E518 File Offset: 0x00A8C718
		public unsafe float 速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_125);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_125) = value;
			}
		}

		// Token: 0x1700751C RID: 29980
		// (get) Token: 0x0602BEAF RID: 179887 RVA: 0x00A8E529 File Offset: 0x00A8C729
		// (set) Token: 0x0602BEB0 RID: 179888 RVA: 0x00A8E539 File Offset: 0x00A8C739
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_126) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_126) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700751D RID: 29981
		// (get) Token: 0x0602BEB1 RID: 179889 RVA: 0x00A8E54A File Offset: 0x00A8C74A
		// (set) Token: 0x0602BEB2 RID: 179890 RVA: 0x00A8E55A File Offset: 0x00A8C75A
		public unsafe bool ifPlayIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_127) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_127) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700751E RID: 29982
		// (get) Token: 0x0602BEB3 RID: 179891 RVA: 0x00A8E56C File Offset: 0x00A8C76C
		// (set) Token: 0x0602BEB4 RID: 179892 RVA: 0x00A8E5A5 File Offset: 0x00A8C7A5
		public TArray<UAnimMontage> IdleMontageArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimMontage> result;
				if ((result = this._IdleMontageArray) == null)
				{
					result = (this._IdleMontageArray = new TArray<UAnimMontage>(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				this.IdleMontageArray.CopyAssign(value);
			}
		}

		// Token: 0x1700751F RID: 29983
		// (get) Token: 0x0602BEB5 RID: 179893 RVA: 0x00A8E5B3 File Offset: 0x00A8C7B3
		// (set) Token: 0x0602BEB6 RID: 179894 RVA: 0x00A8E5C7 File Offset: 0x00A8C7C7
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MultiStateNPC_C.__PropertyOffset_129);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MultiStateNPC_C.__PropertyOffset_129, value);
			}
		}

		// Token: 0x17007520 RID: 29984
		// (get) Token: 0x0602BEB7 RID: 179895 RVA: 0x00A8E5DC File Offset: 0x00A8C7DC
		// (set) Token: 0x0602BEB8 RID: 179896 RVA: 0x00A8E5EC File Offset: 0x00A8C7EC
		public unsafe bool 是否原地转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_130) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_130) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007521 RID: 29985
		// (get) Token: 0x0602BEB9 RID: 179897 RVA: 0x00A8E5FD File Offset: 0x00A8C7FD
		// (set) Token: 0x0602BEBA RID: 179898 RVA: 0x00A8E60D File Offset: 0x00A8C80D
		public unsafe float 旋转角度差值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_131);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_131) = value;
			}
		}

		// Token: 0x17007522 RID: 29986
		// (get) Token: 0x0602BEBB RID: 179899 RVA: 0x00A8E61E File Offset: 0x00A8C81E
		// (set) Token: 0x0602BEBC RID: 179900 RVA: 0x00A8E62E File Offset: 0x00A8C82E
		public unsafe float 上一次旋转角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_132);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_132) = value;
			}
		}

		// Token: 0x17007523 RID: 29987
		// (get) Token: 0x0602BEBD RID: 179901 RVA: 0x00A8E63F File Offset: 0x00A8C83F
		// (set) Token: 0x0602BEBE RID: 179902 RVA: 0x00A8E653 File Offset: 0x00A8C853
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_133);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_133) = value;
			}
		}

		// Token: 0x17007524 RID: 29988
		// (get) Token: 0x0602BEBF RID: 179903 RVA: 0x00A8E668 File Offset: 0x00A8C868
		// (set) Token: 0x0602BEC0 RID: 179904 RVA: 0x00A8E678 File Offset: 0x00A8C878
		public unsafe bool IsBeingImpacted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_134) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_134) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007525 RID: 29989
		// (get) Token: 0x0602BEC1 RID: 179905 RVA: 0x00A8E689 File Offset: 0x00A8C889
		// (set) Token: 0x0602BEC2 RID: 179906 RVA: 0x00A8E699 File Offset: 0x00A8C899
		public unsafe bool IsBeingAttacked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_135) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_135) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007526 RID: 29990
		// (get) Token: 0x0602BEC3 RID: 179907 RVA: 0x00A8E6AA File Offset: 0x00A8C8AA
		// (set) Token: 0x0602BEC4 RID: 179908 RVA: 0x00A8E6BA File Offset: 0x00A8C8BA
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_136));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_136) = (byte)value;
			}
		}

		// Token: 0x17007527 RID: 29991
		// (get) Token: 0x0602BEC5 RID: 179909 RVA: 0x00A8E6CB File Offset: 0x00A8C8CB
		// (set) Token: 0x0602BEC6 RID: 179910 RVA: 0x00A8E6DB File Offset: 0x00A8C8DB
		public unsafe float 走跑混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_137);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_137) = value;
			}
		}

		// Token: 0x17007528 RID: 29992
		// (get) Token: 0x0602BEC7 RID: 179911 RVA: 0x00A8E6EC File Offset: 0x00A8C8EC
		// (set) Token: 0x0602BEC8 RID: 179912 RVA: 0x00A8E6FC File Offset: 0x00A8C8FC
		public unsafe bool IsTurnLeft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_138) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_138) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007529 RID: 29993
		// (get) Token: 0x0602BEC9 RID: 179913 RVA: 0x00A8E70D File Offset: 0x00A8C90D
		// (set) Token: 0x0602BECA RID: 179914 RVA: 0x00A8E721 File Offset: 0x00A8C921
		public unsafe FRotator 角色旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_139);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_139) = value;
			}
		}

		// Token: 0x1700752A RID: 29994
		// (get) Token: 0x0602BECB RID: 179915 RVA: 0x00A8E736 File Offset: 0x00A8C936
		// (set) Token: 0x0602BECC RID: 179916 RVA: 0x00A8E746 File Offset: 0x00A8C946
		public unsafe int NpcEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_140);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_140) = value;
			}
		}

		// Token: 0x1700752B RID: 29995
		// (get) Token: 0x0602BECD RID: 179917 RVA: 0x00A8E757 File Offset: 0x00A8C957
		// (set) Token: 0x0602BECE RID: 179918 RVA: 0x00A8E767 File Offset: 0x00A8C967
		public unsafe float CollisionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_141);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_141) = value;
			}
		}

		// Token: 0x1700752C RID: 29996
		// (get) Token: 0x0602BECF RID: 179919 RVA: 0x00A8E778 File Offset: 0x00A8C978
		// (set) Token: 0x0602BED0 RID: 179920 RVA: 0x00A8E788 File Offset: 0x00A8C988
		public unsafe float CollisionDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_142);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_142) = value;
			}
		}

		// Token: 0x1700752D RID: 29997
		// (get) Token: 0x0602BED1 RID: 179921 RVA: 0x00A8E799 File Offset: 0x00A8C999
		// (set) Token: 0x0602BED2 RID: 179922 RVA: 0x00A8E7A9 File Offset: 0x00A8C9A9
		public unsafe float RandomEpresionEndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_143);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_143) = value;
			}
		}

		// Token: 0x1700752E RID: 29998
		// (get) Token: 0x0602BED3 RID: 179923 RVA: 0x00A8E7BA File Offset: 0x00A8C9BA
		// (set) Token: 0x0602BED4 RID: 179924 RVA: 0x00A8E7CA File Offset: 0x00A8C9CA
		public unsafe float 眨眼动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_144);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_144) = value;
			}
		}

		// Token: 0x1700752F RID: 29999
		// (get) Token: 0x0602BED5 RID: 179925 RVA: 0x00A8E7DB File Offset: 0x00A8C9DB
		// (set) Token: 0x0602BED6 RID: 179926 RVA: 0x00A8E7EB File Offset: 0x00A8C9EB
		public unsafe float 此轮眨眼动画总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_145);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_145) = value;
			}
		}

		// Token: 0x17007530 RID: 30000
		// (get) Token: 0x0602BED7 RID: 179927 RVA: 0x00A8E7FC File Offset: 0x00A8C9FC
		// (set) Token: 0x0602BED8 RID: 179928 RVA: 0x00A8E80C File Offset: 0x00A8CA0C
		public unsafe float ExpresionAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_146);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_146) = value;
			}
		}

		// Token: 0x17007531 RID: 30001
		// (get) Token: 0x0602BED9 RID: 179929 RVA: 0x00A8E81D File Offset: 0x00A8CA1D
		// (set) Token: 0x0602BEDA RID: 179930 RVA: 0x00A8E82D File Offset: 0x00A8CA2D
		public unsafe bool 眨眼中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_147) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_147) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007532 RID: 30002
		// (get) Token: 0x0602BEDB RID: 179931 RVA: 0x00A8E83E File Offset: 0x00A8CA3E
		// (set) Token: 0x0602BEDC RID: 179932 RVA: 0x00A8E84E File Offset: 0x00A8CA4E
		public unsafe bool Cache原地转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_148) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_148) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007533 RID: 30003
		// (get) Token: 0x0602BEDD RID: 179933 RVA: 0x00A8E860 File Offset: 0x00A8CA60
		// (set) Token: 0x0602BEDE RID: 179934 RVA: 0x00A8E899 File Offset: 0x00A8CA99
		public TArray<FName> 口型曲线
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._口型曲线) == null)
				{
					result = (this._口型曲线 = new TArray<FName>(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_149, this));
				}
				return result;
			}
			set
			{
				this.口型曲线.CopyAssign(value);
			}
		}

		// Token: 0x17007534 RID: 30004
		// (get) Token: 0x0602BEDF RID: 179935 RVA: 0x00A8E8A7 File Offset: 0x00A8CAA7
		// (set) Token: 0x0602BEE0 RID: 179936 RVA: 0x00A8E8B7 File Offset: 0x00A8CAB7
		public unsafe int 当前状态
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_150);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_150) = value;
			}
		}

		// Token: 0x17007535 RID: 30005
		// (get) Token: 0x0602BEE1 RID: 179937 RVA: 0x00A8E8C8 File Offset: 0x00A8CAC8
		// (set) Token: 0x0602BEE2 RID: 179938 RVA: 0x00A8E8D8 File Offset: 0x00A8CAD8
		public unsafe bool 是否无过渡切换状态
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_151) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_151) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007536 RID: 30006
		// (get) Token: 0x0602BEE3 RID: 179939 RVA: 0x00A8E8E9 File Offset: 0x00A8CAE9
		// (set) Token: 0x0602BEE4 RID: 179940 RVA: 0x00A8E8F9 File Offset: 0x00A8CAF9
		public unsafe bool 状态_地区运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_152) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_152) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007537 RID: 30007
		// (get) Token: 0x0602BEE5 RID: 179941 RVA: 0x00A8E90A File Offset: 0x00A8CB0A
		// (set) Token: 0x0602BEE6 RID: 179942 RVA: 0x00A8E91A File Offset: 0x00A8CB1A
		public unsafe bool 状态_地区运动模式_临时
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_153) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_153) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007538 RID: 30008
		// (get) Token: 0x0602BEE7 RID: 179943 RVA: 0x00A8E92B File Offset: 0x00A8CB2B
		// (set) Token: 0x0602BEE8 RID: 179944 RVA: 0x00A8E93F File Offset: 0x00A8CB3F
		[Nullable(2)]
		public unsafe BP_ABPLogicParams_C Ts逻辑变量集
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_ABPLogicParams_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MultiStateNPC_C.__PropertyOffset_154);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MultiStateNPC_C.__PropertyOffset_154, value);
			}
		}

		// Token: 0x17007539 RID: 30009
		// (get) Token: 0x0602BEE9 RID: 179945 RVA: 0x00A8E954 File Offset: 0x00A8CB54
		// (set) Token: 0x0602BEEA RID: 179946 RVA: 0x00A8E964 File Offset: 0x00A8CB64
		public unsafe bool IsEnableTurnMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_155) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_155) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700753A RID: 30010
		// (get) Token: 0x0602BEEB RID: 179947 RVA: 0x00A8E975 File Offset: 0x00A8CB75
		// (set) Token: 0x0602BEEC RID: 179948 RVA: 0x00A8E985 File Offset: 0x00A8CB85
		public unsafe float TurnYawRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_156);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MultiStateNPC_C.__PropertyOffset_156) = value;
			}
		}

		// Token: 0x0602BEED RID: 179949 RVA: 0x00A8E998 File Offset: 0x00A8CB98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceJumpPressed(ref float Speed)
		{
			ABP_MultiStateNPC_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x0602BEEE RID: 179950 RVA: 0x00A8E9E8 File Offset: 0x00A8CBE8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(FPoseLink 地区运动状态, ref FPoseLink 基础层)
		{
			ABP_MultiStateNPC_C.__基础层_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__基础层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (地区运动状态 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->地区运动状态, 地区运动状态.NativePtr, 1, false);
			}
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602BEEF RID: 179951 RVA: 0x00A8EA94 File Offset: 0x00A8CC94
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_MultiStateNPC_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602BEF0 RID: 179952 RVA: 0x00A8EB1B File Offset: 0x00A8CD1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__初始化Tag_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF1 RID: 179953 RVA: 0x00A8EB2F File Offset: 0x00A8CD2F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色状态()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新角色状态_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF2 RID: 179954 RVA: 0x00A8EB43 File Offset: 0x00A8CD43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新眨眼()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新眨眼_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF3 RID: 179955 RVA: 0x00A8EB58 File Offset: 0x00A8CD58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasInputRotate(ref bool Output_Get)
		{
			ABP_MultiStateNPC_C.__HasInputRotate_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__HasInputRotate_FunctionParams[(UIntPtr)91] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__HasInputRotate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__HasInputRotate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Output_Get = Output_Get;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__HasInputRotate_NativeFunctionPtr, (void*)ptr);
			Output_Get = ptr->Output_Get;
		}

		// Token: 0x0602BEF4 RID: 179956 RVA: 0x00A8EBA8 File Offset: 0x00A8CDA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 是否AI驱动(ref bool Result)
		{
			ABP_MultiStateNPC_C.__是否AI驱动_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__是否AI驱动_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__是否AI驱动_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__是否AI驱动_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__是否AI驱动_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602BEF5 RID: 179957 RVA: 0x00A8EBF7 File Offset: 0x00A8CDF7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色转身()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新角色转身_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF6 RID: 179958 RVA: 0x00A8EC0B File Offset: 0x00A8CE0B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新角色移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF7 RID: 179959 RVA: 0x00A8EC1F File Offset: 0x00A8CE1F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新角色碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF8 RID: 179960 RVA: 0x00A8EC33 File Offset: 0x00A8CE33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEF9 RID: 179961 RVA: 0x00A8EC47 File Offset: 0x00A8CE47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__更新角色信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEFA RID: 179962 RVA: 0x00A8EC5C File Offset: 0x00A8CE5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceControlPoint(FVector Offset)
		{
			ABP_MultiStateNPC_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BEFB RID: 179963 RVA: 0x00A8ECA4 File Offset: 0x00A8CEA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceManipulateInteractDirection(float 角度)
		{
			ABP_MultiStateNPC_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BEFC RID: 179964 RVA: 0x00A8ECEC File Offset: 0x00A8CEEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceFixHookDirect(FVector Offset)
		{
			ABP_MultiStateNPC_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BEFD RID: 179965 RVA: 0x00A8ED34 File Offset: 0x00A8CF34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceSimulateJump(float Speed)
		{
			ABP_MultiStateNPC_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BEFE RID: 179966 RVA: 0x00A8ED7A File Offset: 0x00A8CF7A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x0602BEFF RID: 179967 RVA: 0x00A8ED8E File Offset: 0x00A8CF8E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TextureFace_47C3F22343F4E2941D0AC3929521DD7B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TextureFace_47C3F22343F4E2941D0AC3929521DD7B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF00 RID: 179968 RVA: 0x00A8EDA2 File Offset: 0x00A8CFA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_BlendListByBool_816E29AA41B99EA68ABDEA9444F51DC3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_BlendListByBool_816E29AA41B99EA68ABDEA9444F51DC3_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF01 RID: 179969 RVA: 0x00A8EDB6 File Offset: 0x00A8CFB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_FE7049014D58E276D1DAA4A7B255E004()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_FE7049014D58E276D1DAA4A7B255E004_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF02 RID: 179970 RVA: 0x00A8EDCA File Offset: 0x00A8CFCA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_BE174F4E4305A31C44EB53B8A0ACB38F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_BE174F4E4305A31C44EB53B8A0ACB38F_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF03 RID: 179971 RVA: 0x00A8EDDE File Offset: 0x00A8CFDE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_2753322D49988F73D13551BE96449CEC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_2753322D49988F73D13551BE96449CEC_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF04 RID: 179972 RVA: 0x00A8EDF2 File Offset: 0x00A8CFF2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_1BD443804CCB9B22EFA4DBA71566B6B7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_1BD443804CCB9B22EFA4DBA71566B6B7_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF05 RID: 179973 RVA: 0x00A8EE06 File Offset: 0x00A8D006
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_8698E7E3445AAA35915DC7B9FE769331()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_8698E7E3445AAA35915DC7B9FE769331_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF06 RID: 179974 RVA: 0x00A8EE1A File Offset: 0x00A8D01A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_397CD326496626151E6C38AFBFB8C7BC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_397CD326496626151E6C38AFBFB8C7BC_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF07 RID: 179975 RVA: 0x00A8EE2E File Offset: 0x00A8D02E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_6BAB1C7244A9FA3CCE76DC83A08CCED5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_6BAB1C7244A9FA3CCE76DC83A08CCED5_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF08 RID: 179976 RVA: 0x00A8EE42 File Offset: 0x00A8D042
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_CBB2E4A1476665CF32489F8488633075()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_CBB2E4A1476665CF32489F8488633075_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF09 RID: 179977 RVA: 0x00A8EE56 File Offset: 0x00A8D056
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_58B5095B4B2B5446A89319BB171C7794()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_58B5095B4B2B5446A89319BB171C7794_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF0A RID: 179978 RVA: 0x00A8EE6A File Offset: 0x00A8D06A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_210DFE6A4C2E240DE1D99AACF91F01EF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_210DFE6A4C2E240DE1D99AACF91F01EF_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF0B RID: 179979 RVA: 0x00A8EE7E File Offset: 0x00A8D07E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_4AF0EC2E474050F4A6FEEFB5B0EB514D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_4AF0EC2E474050F4A6FEEFB5B0EB514D_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF0C RID: 179980 RVA: 0x00A8EE92 File Offset: 0x00A8D092
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_7A5788C0485C309C2ECB9693EC3EB1E7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_7A5788C0485C309C2ECB9693EC3EB1E7_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF0D RID: 179981 RVA: 0x00A8EEA6 File Offset: 0x00A8D0A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_DA048FEC4A7322378EEF208E853CE59B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_DA048FEC4A7322378EEF208E853CE59B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF0E RID: 179982 RVA: 0x00A8EEBA File Offset: 0x00A8D0BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_CF817C524F33139FE79DFF871D173577()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_CF817C524F33139FE79DFF871D173577_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF0F RID: 179983 RVA: 0x00A8EECE File Offset: 0x00A8D0CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_F4F96042466926A52814119508C8224A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_F4F96042466926A52814119508C8224A_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF10 RID: 179984 RVA: 0x00A8EEE2 File Offset: 0x00A8D0E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_BD5D1A29496F8570ECA77DA2ED3219BB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_BD5D1A29496F8570ECA77DA2ED3219BB_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF11 RID: 179985 RVA: 0x00A8EEF6 File Offset: 0x00A8D0F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_7CD0B5224A979BBF8DD500B389E56FF4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_7CD0B5224A979BBF8DD500B389E56FF4_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF12 RID: 179986 RVA: 0x00A8EF0A File Offset: 0x00A8D10A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_4963A49343D067378F50F4897F39D90B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_4963A49343D067378F50F4897F39D90B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF13 RID: 179987 RVA: 0x00A8EF1E File Offset: 0x00A8D11E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_2BE5DC3A4BF210E9CCD4D9BB0BBF70FE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_2BE5DC3A4BF210E9CCD4D9BB0BBF70FE_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF14 RID: 179988 RVA: 0x00A8EF32 File Offset: 0x00A8D132
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_6574E985420FDB1130BEA6991C5D661B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_6574E985420FDB1130BEA6991C5D661B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF15 RID: 179989 RVA: 0x00A8EF46 File Offset: 0x00A8D146
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_D58127CB43F64574DF9FC4B027EE42F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_D58127CB43F64574DF9FC4B027EE42F2_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF16 RID: 179990 RVA: 0x00A8EF5A File Offset: 0x00A8D15A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_27EFD72A476E73371BEEACAE3F318B51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_27EFD72A476E73371BEEACAE3F318B51_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF17 RID: 179991 RVA: 0x00A8EF6E File Offset: 0x00A8D16E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_8ECA98314DE03091D8AEF7859D07C8D1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_8ECA98314DE03091D8AEF7859D07C8D1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF18 RID: 179992 RVA: 0x00A8EF82 File Offset: 0x00A8D182
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_1165591C4973FAFC213772A1917D020F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_1165591C4973FAFC213772A1917D020F_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF19 RID: 179993 RVA: 0x00A8EF96 File Offset: 0x00A8D196
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_DD54A29F4039E201894B5D98D07489CE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_DD54A29F4039E201894B5D98D07489CE_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF1A RID: 179994 RVA: 0x00A8EFAA File Offset: 0x00A8D1AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_79CA551742D69E3E0FD67EB0149DAC1D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_79CA551742D69E3E0FD67EB0149DAC1D_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF1B RID: 179995 RVA: 0x00A8EFBE File Offset: 0x00A8D1BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_FD997E7D42E1AD7C0BCA5E86676A938C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_FD997E7D42E1AD7C0BCA5E86676A938C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF1C RID: 179996 RVA: 0x00A8EFD2 File Offset: 0x00A8D1D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_30942B7F421866411D6649824CA5F52B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_30942B7F421866411D6649824CA5F52B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF1D RID: 179997 RVA: 0x00A8EFE6 File Offset: 0x00A8D1E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF1E RID: 179998 RVA: 0x00A8EFFA File Offset: 0x00A8D1FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MultiStateNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BF1F RID: 179999 RVA: 0x00A8F010 File Offset: 0x00A8D210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BF20 RID: 180000 RVA: 0x00A8F058 File Offset: 0x00A8D258
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MultiStateNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BF21 RID: 180001 RVA: 0x00A8F09F File Offset: 0x00A8D29F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF22 RID: 180002 RVA: 0x00A8F0B3 File Offset: 0x00A8D2B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MultiStateNPC_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BF23 RID: 180003 RVA: 0x00A8F0C8 File Offset: 0x00A8D2C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnCollisionAnimEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__AnimNotify_OnCollisionAnimEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF24 RID: 180004 RVA: 0x00A8F0DC File Offset: 0x00A8D2DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnCollisionAnimBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__AnimNotify_OnCollisionAnimBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF25 RID: 180005 RVA: 0x00A8F0F0 File Offset: 0x00A8D2F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnHitAnimBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__AnimNotify_OnHitAnimBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF26 RID: 180006 RVA: 0x00A8F104 File Offset: 0x00A8D304
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnHitAnimEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MultiStateNPC_C.__AnimNotify_OnHitAnimEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602BF27 RID: 180007 RVA: 0x00A8F118 File Offset: 0x00A8D318
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_MultiStateNPC(int EntryPoint)
		{
			ABP_MultiStateNPC_C.__ExecuteUbergraph_ABP_MultiStateNPC_FunctionParams* ptr = stackalloc ABP_MultiStateNPC_C.__ExecuteUbergraph_ABP_MultiStateNPC_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(ABP_MultiStateNPC_C.__ExecuteUbergraph_ABP_MultiStateNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MultiStateNPC_C.__ExecuteUbergraph_ABP_MultiStateNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MultiStateNPC_C.__ExecuteUbergraph_ABP_MultiStateNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BF28 RID: 180008 RVA: 0x00A8F162 File Offset: 0x00A8D362
		protected ABP_MultiStateNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040182E2 RID: 99042
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/ABP_MultiStateNPC.ABP_MultiStateNPC_C";

		// Token: 0x040182E3 RID: 99043
		private static IntPtr _ClassPtr;

		// Token: 0x040182E4 RID: 99044
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040182E5 RID: 99045
		internal static int __PropertyOffset_0;

		// Token: 0x040182E6 RID: 99046
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040182E7 RID: 99047
		internal static int __PropertyOffset_1;

		// Token: 0x040182E8 RID: 99048
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x040182E9 RID: 99049
		internal static int __PropertyOffset_2;

		// Token: 0x040182EA RID: 99050
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_6;

		// Token: 0x040182EB RID: 99051
		internal static int __PropertyOffset_3;

		// Token: 0x040182EC RID: 99052
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x040182ED RID: 99053
		internal static int __PropertyOffset_4;

		// Token: 0x040182EE RID: 99054
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x040182EF RID: 99055
		internal static int __PropertyOffset_5;

		// Token: 0x040182F0 RID: 99056
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x040182F1 RID: 99057
		internal static int __PropertyOffset_6;

		// Token: 0x040182F2 RID: 99058
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x040182F3 RID: 99059
		internal static int __PropertyOffset_7;

		// Token: 0x040182F4 RID: 99060
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x040182F5 RID: 99061
		internal static int __PropertyOffset_8;

		// Token: 0x040182F6 RID: 99062
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x040182F7 RID: 99063
		internal static int __PropertyOffset_9;

		// Token: 0x040182F8 RID: 99064
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x040182F9 RID: 99065
		internal static int __PropertyOffset_10;

		// Token: 0x040182FA RID: 99066
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x040182FB RID: 99067
		internal static int __PropertyOffset_11;

		// Token: 0x040182FC RID: 99068
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x040182FD RID: 99069
		internal static int __PropertyOffset_12;

		// Token: 0x040182FE RID: 99070
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x040182FF RID: 99071
		internal static int __PropertyOffset_13;

		// Token: 0x04018300 RID: 99072
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_35;

		// Token: 0x04018301 RID: 99073
		internal static int __PropertyOffset_14;

		// Token: 0x04018302 RID: 99074
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x04018303 RID: 99075
		internal static int __PropertyOffset_15;

		// Token: 0x04018304 RID: 99076
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_34;

		// Token: 0x04018305 RID: 99077
		internal static int __PropertyOffset_16;

		// Token: 0x04018306 RID: 99078
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_33;

		// Token: 0x04018307 RID: 99079
		internal static int __PropertyOffset_17;

		// Token: 0x04018308 RID: 99080
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_10;

		// Token: 0x04018309 RID: 99081
		internal static int __PropertyOffset_18;

		// Token: 0x0401830A RID: 99082
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_32;

		// Token: 0x0401830B RID: 99083
		internal static int __PropertyOffset_19;

		// Token: 0x0401830C RID: 99084
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x0401830D RID: 99085
		internal static int __PropertyOffset_20;

		// Token: 0x0401830E RID: 99086
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x0401830F RID: 99087
		internal static int __PropertyOffset_21;

		// Token: 0x04018310 RID: 99088
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x04018311 RID: 99089
		internal static int __PropertyOffset_22;

		// Token: 0x04018312 RID: 99090
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_31;

		// Token: 0x04018313 RID: 99091
		internal static int __PropertyOffset_23;

		// Token: 0x04018314 RID: 99092
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x04018315 RID: 99093
		internal static int __PropertyOffset_24;

		// Token: 0x04018316 RID: 99094
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_30;

		// Token: 0x04018317 RID: 99095
		internal static int __PropertyOffset_25;

		// Token: 0x04018318 RID: 99096
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x04018319 RID: 99097
		internal static int __PropertyOffset_26;

		// Token: 0x0401831A RID: 99098
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_9;

		// Token: 0x0401831B RID: 99099
		internal static int __PropertyOffset_27;

		// Token: 0x0401831C RID: 99100
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x0401831D RID: 99101
		internal static int __PropertyOffset_28;

		// Token: 0x0401831E RID: 99102
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x0401831F RID: 99103
		internal static int __PropertyOffset_29;

		// Token: 0x04018320 RID: 99104
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x04018321 RID: 99105
		internal static int __PropertyOffset_30;

		// Token: 0x04018322 RID: 99106
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x04018323 RID: 99107
		internal static int __PropertyOffset_31;

		// Token: 0x04018324 RID: 99108
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x04018325 RID: 99109
		internal static int __PropertyOffset_32;

		// Token: 0x04018326 RID: 99110
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04018327 RID: 99111
		internal static int __PropertyOffset_33;

		// Token: 0x04018328 RID: 99112
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x04018329 RID: 99113
		internal static int __PropertyOffset_34;

		// Token: 0x0401832A RID: 99114
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x0401832B RID: 99115
		internal static int __PropertyOffset_35;

		// Token: 0x0401832C RID: 99116
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_8;

		// Token: 0x0401832D RID: 99117
		internal static int __PropertyOffset_36;

		// Token: 0x0401832E RID: 99118
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x0401832F RID: 99119
		internal static int __PropertyOffset_37;

		// Token: 0x04018330 RID: 99120
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x04018331 RID: 99121
		internal static int __PropertyOffset_38;

		// Token: 0x04018332 RID: 99122
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x04018333 RID: 99123
		internal static int __PropertyOffset_39;

		// Token: 0x04018334 RID: 99124
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_3;

		// Token: 0x04018335 RID: 99125
		internal static int __PropertyOffset_40;

		// Token: 0x04018336 RID: 99126
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x04018337 RID: 99127
		internal static int __PropertyOffset_41;

		// Token: 0x04018338 RID: 99128
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_2;

		// Token: 0x04018339 RID: 99129
		internal static int __PropertyOffset_42;

		// Token: 0x0401833A RID: 99130
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x0401833B RID: 99131
		internal static int __PropertyOffset_43;

		// Token: 0x0401833C RID: 99132
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x0401833D RID: 99133
		internal static int __PropertyOffset_44;

		// Token: 0x0401833E RID: 99134
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_7;

		// Token: 0x0401833F RID: 99135
		internal static int __PropertyOffset_45;

		// Token: 0x04018340 RID: 99136
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x04018341 RID: 99137
		internal static int __PropertyOffset_46;

		// Token: 0x04018342 RID: 99138
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04018343 RID: 99139
		internal static int __PropertyOffset_47;

		// Token: 0x04018344 RID: 99140
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04018345 RID: 99141
		internal static int __PropertyOffset_48;

		// Token: 0x04018346 RID: 99142
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04018347 RID: 99143
		internal static int __PropertyOffset_49;

		// Token: 0x04018348 RID: 99144
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04018349 RID: 99145
		internal static int __PropertyOffset_50;

		// Token: 0x0401834A RID: 99146
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x0401834B RID: 99147
		internal static int __PropertyOffset_51;

		// Token: 0x0401834C RID: 99148
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x0401834D RID: 99149
		internal static int __PropertyOffset_52;

		// Token: 0x0401834E RID: 99150
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x0401834F RID: 99151
		internal static int __PropertyOffset_53;

		// Token: 0x04018350 RID: 99152
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04018351 RID: 99153
		internal static int __PropertyOffset_54;

		// Token: 0x04018352 RID: 99154
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04018353 RID: 99155
		internal static int __PropertyOffset_55;

		// Token: 0x04018354 RID: 99156
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x04018355 RID: 99157
		internal static int __PropertyOffset_56;

		// Token: 0x04018356 RID: 99158
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04018357 RID: 99159
		internal static int __PropertyOffset_57;

		// Token: 0x04018358 RID: 99160
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x04018359 RID: 99161
		internal static int __PropertyOffset_58;

		// Token: 0x0401835A RID: 99162
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x0401835B RID: 99163
		internal static int __PropertyOffset_59;

		// Token: 0x0401835C RID: 99164
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_6;

		// Token: 0x0401835D RID: 99165
		internal static int __PropertyOffset_60;

		// Token: 0x0401835E RID: 99166
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x0401835F RID: 99167
		internal static int __PropertyOffset_61;

		// Token: 0x04018360 RID: 99168
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04018361 RID: 99169
		internal static int __PropertyOffset_62;

		// Token: 0x04018362 RID: 99170
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04018363 RID: 99171
		internal static int __PropertyOffset_63;

		// Token: 0x04018364 RID: 99172
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04018365 RID: 99173
		internal static int __PropertyOffset_64;

		// Token: 0x04018366 RID: 99174
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04018367 RID: 99175
		internal static int __PropertyOffset_65;

		// Token: 0x04018368 RID: 99176
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04018369 RID: 99177
		internal static int __PropertyOffset_66;

		// Token: 0x0401836A RID: 99178
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x0401836B RID: 99179
		internal static int __PropertyOffset_67;

		// Token: 0x0401836C RID: 99180
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x0401836D RID: 99181
		internal static int __PropertyOffset_68;

		// Token: 0x0401836E RID: 99182
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_5;

		// Token: 0x0401836F RID: 99183
		internal static int __PropertyOffset_69;

		// Token: 0x04018370 RID: 99184
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04018371 RID: 99185
		internal static int __PropertyOffset_70;

		// Token: 0x04018372 RID: 99186
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04018373 RID: 99187
		internal static int __PropertyOffset_71;

		// Token: 0x04018374 RID: 99188
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04018375 RID: 99189
		internal static int __PropertyOffset_72;

		// Token: 0x04018376 RID: 99190
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04018377 RID: 99191
		internal static int __PropertyOffset_73;

		// Token: 0x04018378 RID: 99192
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04018379 RID: 99193
		internal static int __PropertyOffset_74;

		// Token: 0x0401837A RID: 99194
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0401837B RID: 99195
		internal static int __PropertyOffset_75;

		// Token: 0x0401837C RID: 99196
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x0401837D RID: 99197
		internal static int __PropertyOffset_76;

		// Token: 0x0401837E RID: 99198
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x0401837F RID: 99199
		internal static int __PropertyOffset_77;

		// Token: 0x04018380 RID: 99200
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04018381 RID: 99201
		internal static int __PropertyOffset_78;

		// Token: 0x04018382 RID: 99202
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04018383 RID: 99203
		internal static int __PropertyOffset_79;

		// Token: 0x04018384 RID: 99204
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04018385 RID: 99205
		internal static int __PropertyOffset_80;

		// Token: 0x04018386 RID: 99206
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04018387 RID: 99207
		internal static int __PropertyOffset_81;

		// Token: 0x04018388 RID: 99208
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04018389 RID: 99209
		internal static int __PropertyOffset_82;

		// Token: 0x0401838A RID: 99210
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0401838B RID: 99211
		internal static int __PropertyOffset_83;

		// Token: 0x0401838C RID: 99212
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x0401838D RID: 99213
		internal static int __PropertyOffset_84;

		// Token: 0x0401838E RID: 99214
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x0401838F RID: 99215
		internal static int __PropertyOffset_85;

		// Token: 0x04018390 RID: 99216
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x04018391 RID: 99217
		internal static int __PropertyOffset_86;

		// Token: 0x04018392 RID: 99218
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04018393 RID: 99219
		internal static int __PropertyOffset_87;

		// Token: 0x04018394 RID: 99220
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04018395 RID: 99221
		internal static int __PropertyOffset_88;

		// Token: 0x04018396 RID: 99222
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04018397 RID: 99223
		internal static int __PropertyOffset_89;

		// Token: 0x04018398 RID: 99224
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018399 RID: 99225
		internal static int __PropertyOffset_90;

		// Token: 0x0401839A RID: 99226
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0401839B RID: 99227
		internal static int __PropertyOffset_91;

		// Token: 0x0401839C RID: 99228
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x0401839D RID: 99229
		internal static int __PropertyOffset_92;

		// Token: 0x0401839E RID: 99230
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x0401839F RID: 99231
		internal static int __PropertyOffset_93;

		// Token: 0x040183A0 RID: 99232
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x040183A1 RID: 99233
		internal static int __PropertyOffset_94;

		// Token: 0x040183A2 RID: 99234
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x040183A3 RID: 99235
		internal static int __PropertyOffset_95;

		// Token: 0x040183A4 RID: 99236
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x040183A5 RID: 99237
		internal static int __PropertyOffset_96;

		// Token: 0x040183A6 RID: 99238
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x040183A7 RID: 99239
		internal static int __PropertyOffset_97;

		// Token: 0x040183A8 RID: 99240
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x040183A9 RID: 99241
		internal static int __PropertyOffset_98;

		// Token: 0x040183AA RID: 99242
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x040183AB RID: 99243
		internal static int __PropertyOffset_99;

		// Token: 0x040183AC RID: 99244
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x040183AD RID: 99245
		internal static int __PropertyOffset_100;

		// Token: 0x040183AE RID: 99246
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x040183AF RID: 99247
		internal static int __PropertyOffset_101;

		// Token: 0x040183B0 RID: 99248
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_5;

		// Token: 0x040183B1 RID: 99249
		internal static int __PropertyOffset_102;

		// Token: 0x040183B2 RID: 99250
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_1;

		// Token: 0x040183B3 RID: 99251
		internal static int __PropertyOffset_103;

		// Token: 0x040183B4 RID: 99252
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_4;

		// Token: 0x040183B5 RID: 99253
		internal static int __PropertyOffset_104;

		// Token: 0x040183B6 RID: 99254
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x040183B7 RID: 99255
		internal static int __PropertyOffset_105;

		// Token: 0x040183B8 RID: 99256
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x040183B9 RID: 99257
		internal static int __PropertyOffset_106;

		// Token: 0x040183BA RID: 99258
		[Nullable(2)]
		private FAnimNode_KuroSlotLayeredBlend _AnimGraphNode_KuroSlotLayeredBlend;

		// Token: 0x040183BB RID: 99259
		internal static int __PropertyOffset_107;

		// Token: 0x040183BC RID: 99260
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x040183BD RID: 99261
		internal static int __PropertyOffset_108;

		// Token: 0x040183BE RID: 99262
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x040183BF RID: 99263
		internal static int __PropertyOffset_109;

		// Token: 0x040183C0 RID: 99264
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040183C1 RID: 99265
		internal static int __PropertyOffset_110;

		// Token: 0x040183C2 RID: 99266
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x040183C3 RID: 99267
		internal static int __PropertyOffset_111;

		// Token: 0x040183C4 RID: 99268
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x040183C5 RID: 99269
		internal static int __PropertyOffset_112;

		// Token: 0x040183C6 RID: 99270
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x040183C7 RID: 99271
		internal static int __PropertyOffset_113;

		// Token: 0x040183C8 RID: 99272
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x040183C9 RID: 99273
		internal static int __PropertyOffset_114;

		// Token: 0x040183CA RID: 99274
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x040183CB RID: 99275
		internal static int __PropertyOffset_115;

		// Token: 0x040183CC RID: 99276
		[Nullable(2)]
		private FAnimNode_RBF _AnimGraphNode_RBF;

		// Token: 0x040183CD RID: 99277
		internal static int __PropertyOffset_116;

		// Token: 0x040183CE RID: 99278
		[Nullable(2)]
		private FAnimNode_LinkedAnimGraph _AnimGraphNode_LinkedAnimGraph;

		// Token: 0x040183CF RID: 99279
		internal static int __PropertyOffset_117;

		// Token: 0x040183D0 RID: 99280
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves_1;

		// Token: 0x040183D1 RID: 99281
		internal static int __PropertyOffset_118;

		// Token: 0x040183D2 RID: 99282
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x040183D3 RID: 99283
		internal static int __PropertyOffset_119;

		// Token: 0x040183D4 RID: 99284
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x040183D5 RID: 99285
		internal static int __PropertyOffset_120;

		// Token: 0x040183D6 RID: 99286
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves;

		// Token: 0x040183D7 RID: 99287
		internal static int __PropertyOffset_121;

		// Token: 0x040183D8 RID: 99288
		[Nullable(2)]
		private FAnimNode_TextureFace _AnimGraphNode_TextureFace;

		// Token: 0x040183D9 RID: 99289
		internal static int __PropertyOffset_122;

		// Token: 0x040183DA RID: 99290
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x040183DB RID: 99291
		internal static int __PropertyOffset_123;

		// Token: 0x040183DC RID: 99292
		internal static int __PropertyOffset_124;

		// Token: 0x040183DD RID: 99293
		internal static int __PropertyOffset_125;

		// Token: 0x040183DE RID: 99294
		internal static int __PropertyOffset_126;

		// Token: 0x040183DF RID: 99295
		internal static int __PropertyOffset_127;

		// Token: 0x040183E0 RID: 99296
		internal static int __PropertyOffset_128;

		// Token: 0x040183E1 RID: 99297
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimMontage> _IdleMontageArray;

		// Token: 0x040183E2 RID: 99298
		internal static int __PropertyOffset_129;

		// Token: 0x040183E3 RID: 99299
		internal static int __PropertyOffset_130;

		// Token: 0x040183E4 RID: 99300
		internal static int __PropertyOffset_131;

		// Token: 0x040183E5 RID: 99301
		internal static int __PropertyOffset_132;

		// Token: 0x040183E6 RID: 99302
		internal static int __PropertyOffset_133;

		// Token: 0x040183E7 RID: 99303
		internal static int __PropertyOffset_134;

		// Token: 0x040183E8 RID: 99304
		internal static int __PropertyOffset_135;

		// Token: 0x040183E9 RID: 99305
		internal static int __PropertyOffset_136;

		// Token: 0x040183EA RID: 99306
		internal static int __PropertyOffset_137;

		// Token: 0x040183EB RID: 99307
		internal static int __PropertyOffset_138;

		// Token: 0x040183EC RID: 99308
		internal static int __PropertyOffset_139;

		// Token: 0x040183ED RID: 99309
		internal static int __PropertyOffset_140;

		// Token: 0x040183EE RID: 99310
		internal static int __PropertyOffset_141;

		// Token: 0x040183EF RID: 99311
		internal static int __PropertyOffset_142;

		// Token: 0x040183F0 RID: 99312
		internal static int __PropertyOffset_143;

		// Token: 0x040183F1 RID: 99313
		internal static int __PropertyOffset_144;

		// Token: 0x040183F2 RID: 99314
		internal static int __PropertyOffset_145;

		// Token: 0x040183F3 RID: 99315
		internal static int __PropertyOffset_146;

		// Token: 0x040183F4 RID: 99316
		internal static int __PropertyOffset_147;

		// Token: 0x040183F5 RID: 99317
		internal static int __PropertyOffset_148;

		// Token: 0x040183F6 RID: 99318
		internal static int __PropertyOffset_149;

		// Token: 0x040183F7 RID: 99319
		[Nullable(2)]
		private TArray<FName> _口型曲线;

		// Token: 0x040183F8 RID: 99320
		internal static int __PropertyOffset_150;

		// Token: 0x040183F9 RID: 99321
		internal static int __PropertyOffset_151;

		// Token: 0x040183FA RID: 99322
		internal static int __PropertyOffset_152;

		// Token: 0x040183FB RID: 99323
		internal static int __PropertyOffset_153;

		// Token: 0x040183FC RID: 99324
		internal static int __PropertyOffset_154;

		// Token: 0x040183FD RID: 99325
		internal static int __PropertyOffset_155;

		// Token: 0x040183FE RID: 99326
		internal static int __PropertyOffset_156;

		// Token: 0x040183FF RID: 99327
		private static IntPtr __InterfaceJumpPressed_NativeFunctionPtr;

		// Token: 0x04018400 RID: 99328
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018401 RID: 99329
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018402 RID: 99330
		private static IntPtr __初始化Tag_NativeFunctionPtr;

		// Token: 0x04018403 RID: 99331
		private static IntPtr __更新角色状态_NativeFunctionPtr;

		// Token: 0x04018404 RID: 99332
		private static IntPtr __更新眨眼_NativeFunctionPtr;

		// Token: 0x04018405 RID: 99333
		private static IntPtr __HasInputRotate_NativeFunctionPtr;

		// Token: 0x04018406 RID: 99334
		private static IntPtr __是否AI驱动_NativeFunctionPtr;

		// Token: 0x04018407 RID: 99335
		private static IntPtr __更新角色转身_NativeFunctionPtr;

		// Token: 0x04018408 RID: 99336
		private static IntPtr __更新角色移动_NativeFunctionPtr;

		// Token: 0x04018409 RID: 99337
		private static IntPtr __更新角色碰撞_NativeFunctionPtr;

		// Token: 0x0401840A RID: 99338
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x0401840B RID: 99339
		private static IntPtr __更新角色信息_NativeFunctionPtr;

		// Token: 0x0401840C RID: 99340
		private static IntPtr __InterfaceControlPoint_NativeFunctionPtr;

		// Token: 0x0401840D RID: 99341
		private static IntPtr __InterfaceManipulateInteractDirection_NativeFunctionPtr;

		// Token: 0x0401840E RID: 99342
		private static IntPtr __InterfaceFixHookDirect_NativeFunctionPtr;

		// Token: 0x0401840F RID: 99343
		private static IntPtr __InterfaceSimulateJump_NativeFunctionPtr;

		// Token: 0x04018410 RID: 99344
		private static IntPtr __ClimbDash_NativeFunctionPtr;

		// Token: 0x04018411 RID: 99345
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TextureFace_47C3F22343F4E2941D0AC3929521DD7B_NativeFunctionPtr;

		// Token: 0x04018412 RID: 99346
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_BlendListByBool_816E29AA41B99EA68ABDEA9444F51DC3_NativeFunctionPtr;

		// Token: 0x04018413 RID: 99347
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_FE7049014D58E276D1DAA4A7B255E004_NativeFunctionPtr;

		// Token: 0x04018414 RID: 99348
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_BE174F4E4305A31C44EB53B8A0ACB38F_NativeFunctionPtr;

		// Token: 0x04018415 RID: 99349
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_2753322D49988F73D13551BE96449CEC_NativeFunctionPtr;

		// Token: 0x04018416 RID: 99350
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_1BD443804CCB9B22EFA4DBA71566B6B7_NativeFunctionPtr;

		// Token: 0x04018417 RID: 99351
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_8698E7E3445AAA35915DC7B9FE769331_NativeFunctionPtr;

		// Token: 0x04018418 RID: 99352
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_397CD326496626151E6C38AFBFB8C7BC_NativeFunctionPtr;

		// Token: 0x04018419 RID: 99353
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_6BAB1C7244A9FA3CCE76DC83A08CCED5_NativeFunctionPtr;

		// Token: 0x0401841A RID: 99354
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_CBB2E4A1476665CF32489F8488633075_NativeFunctionPtr;

		// Token: 0x0401841B RID: 99355
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_58B5095B4B2B5446A89319BB171C7794_NativeFunctionPtr;

		// Token: 0x0401841C RID: 99356
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_210DFE6A4C2E240DE1D99AACF91F01EF_NativeFunctionPtr;

		// Token: 0x0401841D RID: 99357
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_4AF0EC2E474050F4A6FEEFB5B0EB514D_NativeFunctionPtr;

		// Token: 0x0401841E RID: 99358
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_7A5788C0485C309C2ECB9693EC3EB1E7_NativeFunctionPtr;

		// Token: 0x0401841F RID: 99359
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_DA048FEC4A7322378EEF208E853CE59B_NativeFunctionPtr;

		// Token: 0x04018420 RID: 99360
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_CF817C524F33139FE79DFF871D173577_NativeFunctionPtr;

		// Token: 0x04018421 RID: 99361
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_F4F96042466926A52814119508C8224A_NativeFunctionPtr;

		// Token: 0x04018422 RID: 99362
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_BD5D1A29496F8570ECA77DA2ED3219BB_NativeFunctionPtr;

		// Token: 0x04018423 RID: 99363
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_7CD0B5224A979BBF8DD500B389E56FF4_NativeFunctionPtr;

		// Token: 0x04018424 RID: 99364
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_4963A49343D067378F50F4897F39D90B_NativeFunctionPtr;

		// Token: 0x04018425 RID: 99365
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_2BE5DC3A4BF210E9CCD4D9BB0BBF70FE_NativeFunctionPtr;

		// Token: 0x04018426 RID: 99366
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_6574E985420FDB1130BEA6991C5D661B_NativeFunctionPtr;

		// Token: 0x04018427 RID: 99367
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_D58127CB43F64574DF9FC4B027EE42F2_NativeFunctionPtr;

		// Token: 0x04018428 RID: 99368
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_27EFD72A476E73371BEEACAE3F318B51_NativeFunctionPtr;

		// Token: 0x04018429 RID: 99369
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_8ECA98314DE03091D8AEF7859D07C8D1_NativeFunctionPtr;

		// Token: 0x0401842A RID: 99370
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_1165591C4973FAFC213772A1917D020F_NativeFunctionPtr;

		// Token: 0x0401842B RID: 99371
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_DD54A29F4039E201894B5D98D07489CE_NativeFunctionPtr;

		// Token: 0x0401842C RID: 99372
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_79CA551742D69E3E0FD67EB0149DAC1D_NativeFunctionPtr;

		// Token: 0x0401842D RID: 99373
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_FD997E7D42E1AD7C0BCA5E86676A938C_NativeFunctionPtr;

		// Token: 0x0401842E RID: 99374
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MultiStateNPC_AnimGraphNode_TransitionResult_30942B7F421866411D6649824CA5F52B_NativeFunctionPtr;

		// Token: 0x0401842F RID: 99375
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018430 RID: 99376
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018431 RID: 99377
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x04018432 RID: 99378
		private static IntPtr __AnimNotify_OnCollisionAnimEnd_NativeFunctionPtr;

		// Token: 0x04018433 RID: 99379
		private static IntPtr __AnimNotify_OnCollisionAnimBegin_NativeFunctionPtr;

		// Token: 0x04018434 RID: 99380
		private static IntPtr __AnimNotify_OnHitAnimBegin_NativeFunctionPtr;

		// Token: 0x04018435 RID: 99381
		private static IntPtr __AnimNotify_OnHitAnimEnd_NativeFunctionPtr;

		// Token: 0x04018436 RID: 99382
		private static IntPtr __ExecuteUbergraph_ABP_MultiStateNPC_NativeFunctionPtr;

		// Token: 0x0200A3E4 RID: 41956
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x040331D2 RID: 209362
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A3E5 RID: 41957
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x040331D3 RID: 209363
			[FieldOffset(0)]
			public byte 地区运动状态;

			// Token: 0x040331D4 RID: 209364
			[FieldOffset(24)]
			public byte 基础层;
		}

		// Token: 0x0200A3E6 RID: 41958
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x040331D5 RID: 209365
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A3E7 RID: 41959
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 76)]
		protected ref struct __HasInputRotate_FunctionParams
		{
			// Token: 0x040331D6 RID: 209366
			[FieldOffset(0)]
			public bool Output_Get;
		}

		// Token: 0x0200A3E8 RID: 41960
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __是否AI驱动_FunctionParams
		{
			// Token: 0x040331D7 RID: 209367
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A3E9 RID: 41961
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x040331D8 RID: 209368
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A3EA RID: 41962
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x040331D9 RID: 209369
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A3EB RID: 41963
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x040331DA RID: 209370
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A3EC RID: 41964
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x040331DB RID: 209371
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A3ED RID: 41965
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x040331DC RID: 209372
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A3EE RID: 41966
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __ExecuteUbergraph_ABP_MultiStateNPC_FunctionParams
		{
			// Token: 0x040331DD RID: 209373
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
