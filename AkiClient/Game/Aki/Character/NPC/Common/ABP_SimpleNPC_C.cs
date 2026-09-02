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
	// Token: 0x020040EA RID: 16618
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/ABP_SimpleNPC.ABP_SimpleNPC_C")]
	[UnrealStructLayout(8016, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 8016)]
	public class ABP_SimpleNPC_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_Animation_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602BFBE RID: 180158 RVA: 0x00A9091B File Offset: 0x00A8EB1B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_SimpleNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/ABP_SimpleNPC.ABP_SimpleNPC_C");
			}
			return ABP_SimpleNPC_C._ClassPtr;
		}

		// Token: 0x0602BFBF RID: 180159 RVA: 0x00A90940 File Offset: 0x00A8EB40
		public ABP_SimpleNPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_SimpleNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BFC0 RID: 180160 RVA: 0x00A90968 File Offset: 0x00A8EB68
		public ABP_SimpleNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_SimpleNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007573 RID: 30067
		// (get) Token: 0x0602BFC1 RID: 180161 RVA: 0x00A9099C File Offset: 0x00A8EB9C
		// (set) Token: 0x0602BFC2 RID: 180162 RVA: 0x00A909D5 File Offset: 0x00A8EBD5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007574 RID: 30068
		// (get) Token: 0x0602BFC3 RID: 180163 RVA: 0x00A909F8 File Offset: 0x00A8EBF8
		// (set) Token: 0x0602BFC4 RID: 180164 RVA: 0x00A90A31 File Offset: 0x00A8EC31
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007575 RID: 30069
		// (get) Token: 0x0602BFC5 RID: 180165 RVA: 0x00A90A54 File Offset: 0x00A8EC54
		// (set) Token: 0x0602BFC6 RID: 180166 RVA: 0x00A90A8D File Offset: 0x00A8EC8D
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007576 RID: 30070
		// (get) Token: 0x0602BFC7 RID: 180167 RVA: 0x00A90AB0 File Offset: 0x00A8ECB0
		// (set) Token: 0x0602BFC8 RID: 180168 RVA: 0x00A90AE9 File Offset: 0x00A8ECE9
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007577 RID: 30071
		// (get) Token: 0x0602BFC9 RID: 180169 RVA: 0x00A90B0C File Offset: 0x00A8ED0C
		// (set) Token: 0x0602BFCA RID: 180170 RVA: 0x00A90B45 File Offset: 0x00A8ED45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007578 RID: 30072
		// (get) Token: 0x0602BFCB RID: 180171 RVA: 0x00A90B68 File Offset: 0x00A8ED68
		// (set) Token: 0x0602BFCC RID: 180172 RVA: 0x00A90BA1 File Offset: 0x00A8EDA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007579 RID: 30073
		// (get) Token: 0x0602BFCD RID: 180173 RVA: 0x00A90BC4 File Offset: 0x00A8EDC4
		// (set) Token: 0x0602BFCE RID: 180174 RVA: 0x00A90BFD File Offset: 0x00A8EDFD
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700757A RID: 30074
		// (get) Token: 0x0602BFCF RID: 180175 RVA: 0x00A90C20 File Offset: 0x00A8EE20
		// (set) Token: 0x0602BFD0 RID: 180176 RVA: 0x00A90C59 File Offset: 0x00A8EE59
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700757B RID: 30075
		// (get) Token: 0x0602BFD1 RID: 180177 RVA: 0x00A90C7C File Offset: 0x00A8EE7C
		// (set) Token: 0x0602BFD2 RID: 180178 RVA: 0x00A90CB5 File Offset: 0x00A8EEB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700757C RID: 30076
		// (get) Token: 0x0602BFD3 RID: 180179 RVA: 0x00A90CD8 File Offset: 0x00A8EED8
		// (set) Token: 0x0602BFD4 RID: 180180 RVA: 0x00A90D11 File Offset: 0x00A8EF11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700757D RID: 30077
		// (get) Token: 0x0602BFD5 RID: 180181 RVA: 0x00A90D34 File Offset: 0x00A8EF34
		// (set) Token: 0x0602BFD6 RID: 180182 RVA: 0x00A90D6D File Offset: 0x00A8EF6D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700757E RID: 30078
		// (get) Token: 0x0602BFD7 RID: 180183 RVA: 0x00A90D90 File Offset: 0x00A8EF90
		// (set) Token: 0x0602BFD8 RID: 180184 RVA: 0x00A90DC9 File Offset: 0x00A8EFC9
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700757F RID: 30079
		// (get) Token: 0x0602BFD9 RID: 180185 RVA: 0x00A90DEC File Offset: 0x00A8EFEC
		// (set) Token: 0x0602BFDA RID: 180186 RVA: 0x00A90E25 File Offset: 0x00A8F025
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007580 RID: 30080
		// (get) Token: 0x0602BFDB RID: 180187 RVA: 0x00A90E48 File Offset: 0x00A8F048
		// (set) Token: 0x0602BFDC RID: 180188 RVA: 0x00A90E81 File Offset: 0x00A8F081
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007581 RID: 30081
		// (get) Token: 0x0602BFDD RID: 180189 RVA: 0x00A90EA4 File Offset: 0x00A8F0A4
		// (set) Token: 0x0602BFDE RID: 180190 RVA: 0x00A90EDD File Offset: 0x00A8F0DD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007582 RID: 30082
		// (get) Token: 0x0602BFDF RID: 180191 RVA: 0x00A90F00 File Offset: 0x00A8F100
		// (set) Token: 0x0602BFE0 RID: 180192 RVA: 0x00A90F39 File Offset: 0x00A8F139
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007583 RID: 30083
		// (get) Token: 0x0602BFE1 RID: 180193 RVA: 0x00A90F5C File Offset: 0x00A8F15C
		// (set) Token: 0x0602BFE2 RID: 180194 RVA: 0x00A90F95 File Offset: 0x00A8F195
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007584 RID: 30084
		// (get) Token: 0x0602BFE3 RID: 180195 RVA: 0x00A90FB8 File Offset: 0x00A8F1B8
		// (set) Token: 0x0602BFE4 RID: 180196 RVA: 0x00A90FF1 File Offset: 0x00A8F1F1
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007585 RID: 30085
		// (get) Token: 0x0602BFE5 RID: 180197 RVA: 0x00A91014 File Offset: 0x00A8F214
		// (set) Token: 0x0602BFE6 RID: 180198 RVA: 0x00A9104D File Offset: 0x00A8F24D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007586 RID: 30086
		// (get) Token: 0x0602BFE7 RID: 180199 RVA: 0x00A91070 File Offset: 0x00A8F270
		// (set) Token: 0x0602BFE8 RID: 180200 RVA: 0x00A910A9 File Offset: 0x00A8F2A9
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007587 RID: 30087
		// (get) Token: 0x0602BFE9 RID: 180201 RVA: 0x00A910CC File Offset: 0x00A8F2CC
		// (set) Token: 0x0602BFEA RID: 180202 RVA: 0x00A91105 File Offset: 0x00A8F305
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007588 RID: 30088
		// (get) Token: 0x0602BFEB RID: 180203 RVA: 0x00A91128 File Offset: 0x00A8F328
		// (set) Token: 0x0602BFEC RID: 180204 RVA: 0x00A91161 File Offset: 0x00A8F361
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007589 RID: 30089
		// (get) Token: 0x0602BFED RID: 180205 RVA: 0x00A91184 File Offset: 0x00A8F384
		// (set) Token: 0x0602BFEE RID: 180206 RVA: 0x00A911BD File Offset: 0x00A8F3BD
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_1) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_1 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700758A RID: 30090
		// (get) Token: 0x0602BFEF RID: 180207 RVA: 0x00A911E0 File Offset: 0x00A8F3E0
		// (set) Token: 0x0602BFF0 RID: 180208 RVA: 0x00A91219 File Offset: 0x00A8F419
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700758B RID: 30091
		// (get) Token: 0x0602BFF1 RID: 180209 RVA: 0x00A9123C File Offset: 0x00A8F43C
		// (set) Token: 0x0602BFF2 RID: 180210 RVA: 0x00A91275 File Offset: 0x00A8F475
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700758C RID: 30092
		// (get) Token: 0x0602BFF3 RID: 180211 RVA: 0x00A91298 File Offset: 0x00A8F498
		// (set) Token: 0x0602BFF4 RID: 180212 RVA: 0x00A912D1 File Offset: 0x00A8F4D1
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700758D RID: 30093
		// (get) Token: 0x0602BFF5 RID: 180213 RVA: 0x00A912F4 File Offset: 0x00A8F4F4
		// (set) Token: 0x0602BFF6 RID: 180214 RVA: 0x00A9132D File Offset: 0x00A8F52D
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700758E RID: 30094
		// (get) Token: 0x0602BFF7 RID: 180215 RVA: 0x00A91350 File Offset: 0x00A8F550
		// (set) Token: 0x0602BFF8 RID: 180216 RVA: 0x00A91389 File Offset: 0x00A8F589
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700758F RID: 30095
		// (get) Token: 0x0602BFF9 RID: 180217 RVA: 0x00A913AC File Offset: 0x00A8F5AC
		// (set) Token: 0x0602BFFA RID: 180218 RVA: 0x00A913E5 File Offset: 0x00A8F5E5
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007590 RID: 30096
		// (get) Token: 0x0602BFFB RID: 180219 RVA: 0x00A91408 File Offset: 0x00A8F608
		// (set) Token: 0x0602BFFC RID: 180220 RVA: 0x00A91441 File Offset: 0x00A8F641
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007591 RID: 30097
		// (get) Token: 0x0602BFFD RID: 180221 RVA: 0x00A91464 File Offset: 0x00A8F664
		// (set) Token: 0x0602BFFE RID: 180222 RVA: 0x00A9149D File Offset: 0x00A8F69D
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007592 RID: 30098
		// (get) Token: 0x0602BFFF RID: 180223 RVA: 0x00A914C0 File Offset: 0x00A8F6C0
		// (set) Token: 0x0602C000 RID: 180224 RVA: 0x00A914F9 File Offset: 0x00A8F6F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007593 RID: 30099
		// (get) Token: 0x0602C001 RID: 180225 RVA: 0x00A9151C File Offset: 0x00A8F71C
		// (set) Token: 0x0602C002 RID: 180226 RVA: 0x00A91555 File Offset: 0x00A8F755
		public FAnimNode_TextureFace AnimGraphNode_TextureFace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TextureFace result;
				if ((result = this._AnimGraphNode_TextureFace) == null)
				{
					result = (this._AnimGraphNode_TextureFace = new FAnimNode_TextureFace(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TextureFace.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007594 RID: 30100
		// (get) Token: 0x0602C003 RID: 180227 RVA: 0x00A91576 File Offset: 0x00A8F776
		// (set) Token: 0x0602C004 RID: 180228 RVA: 0x00A9158A File Offset: 0x00A8F78A
		[Nullable(2)]
		public unsafe BP_BaseNPC_C 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BaseNPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_C.__PropertyOffset_33);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x17007595 RID: 30101
		// (get) Token: 0x0602C005 RID: 180229 RVA: 0x00A9159F File Offset: 0x00A8F79F
		// (set) Token: 0x0602C006 RID: 180230 RVA: 0x00A915AF File Offset: 0x00A8F7AF
		public unsafe bool ifPlayIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007596 RID: 30102
		// (get) Token: 0x0602C007 RID: 180231 RVA: 0x00A915C0 File Offset: 0x00A8F7C0
		// (set) Token: 0x0602C008 RID: 180232 RVA: 0x00A915F9 File Offset: 0x00A8F7F9
		public TArray<UAnimMontage> IdleMontageArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimMontage> result;
				if ((result = this._IdleMontageArray) == null)
				{
					result = (this._IdleMontageArray = new TArray<UAnimMontage>(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				this.IdleMontageArray.CopyAssign(value);
			}
		}

		// Token: 0x17007597 RID: 30103
		// (get) Token: 0x0602C009 RID: 180233 RVA: 0x00A91607 File Offset: 0x00A8F807
		// (set) Token: 0x0602C00A RID: 180234 RVA: 0x00A9161B File Offset: 0x00A8F81B
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_C.__PropertyOffset_36);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_C.__PropertyOffset_36, value);
			}
		}

		// Token: 0x17007598 RID: 30104
		// (get) Token: 0x0602C00B RID: 180235 RVA: 0x00A91630 File Offset: 0x00A8F830
		// (set) Token: 0x0602C00C RID: 180236 RVA: 0x00A91644 File Offset: 0x00A8F844
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17007599 RID: 30105
		// (get) Token: 0x0602C00D RID: 180237 RVA: 0x00A91659 File Offset: 0x00A8F859
		// (set) Token: 0x0602C00E RID: 180238 RVA: 0x00A91669 File Offset: 0x00A8F869
		public unsafe bool IsBeingImpacted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700759A RID: 30106
		// (get) Token: 0x0602C00F RID: 180239 RVA: 0x00A9167A File Offset: 0x00A8F87A
		// (set) Token: 0x0602C010 RID: 180240 RVA: 0x00A9168A File Offset: 0x00A8F88A
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_39));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_39) = (byte)value;
			}
		}

		// Token: 0x1700759B RID: 30107
		// (get) Token: 0x0602C011 RID: 180241 RVA: 0x00A9169B File Offset: 0x00A8F89B
		// (set) Token: 0x0602C012 RID: 180242 RVA: 0x00A916AB File Offset: 0x00A8F8AB
		public unsafe int NpcEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x1700759C RID: 30108
		// (get) Token: 0x0602C013 RID: 180243 RVA: 0x00A916BC File Offset: 0x00A8F8BC
		// (set) Token: 0x0602C014 RID: 180244 RVA: 0x00A916CC File Offset: 0x00A8F8CC
		public unsafe float CollisionDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x1700759D RID: 30109
		// (get) Token: 0x0602C015 RID: 180245 RVA: 0x00A916DD File Offset: 0x00A8F8DD
		// (set) Token: 0x0602C016 RID: 180246 RVA: 0x00A916ED File Offset: 0x00A8F8ED
		public unsafe float CollisionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x1700759E RID: 30110
		// (get) Token: 0x0602C017 RID: 180247 RVA: 0x00A916FE File Offset: 0x00A8F8FE
		// (set) Token: 0x0602C018 RID: 180248 RVA: 0x00A9170E File Offset: 0x00A8F90E
		public unsafe bool IsBeingAttacked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700759F RID: 30111
		// (get) Token: 0x0602C019 RID: 180249 RVA: 0x00A9171F File Offset: 0x00A8F91F
		// (set) Token: 0x0602C01A RID: 180250 RVA: 0x00A9172F File Offset: 0x00A8F92F
		public unsafe float ExpresionAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170075A0 RID: 30112
		// (get) Token: 0x0602C01B RID: 180251 RVA: 0x00A91740 File Offset: 0x00A8F940
		// (set) Token: 0x0602C01C RID: 180252 RVA: 0x00A91750 File Offset: 0x00A8F950
		public unsafe float RandomEpresionEndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170075A1 RID: 30113
		// (get) Token: 0x0602C01D RID: 180253 RVA: 0x00A91761 File Offset: 0x00A8F961
		// (set) Token: 0x0602C01E RID: 180254 RVA: 0x00A91771 File Offset: 0x00A8F971
		public unsafe float 眨眼动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170075A2 RID: 30114
		// (get) Token: 0x0602C01F RID: 180255 RVA: 0x00A91782 File Offset: 0x00A8F982
		// (set) Token: 0x0602C020 RID: 180256 RVA: 0x00A91792 File Offset: 0x00A8F992
		public unsafe float 此轮眨眼动画总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170075A3 RID: 30115
		// (get) Token: 0x0602C021 RID: 180257 RVA: 0x00A917A3 File Offset: 0x00A8F9A3
		// (set) Token: 0x0602C022 RID: 180258 RVA: 0x00A917B3 File Offset: 0x00A8F9B3
		public unsafe bool 眨眼中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075A4 RID: 30116
		// (get) Token: 0x0602C023 RID: 180259 RVA: 0x00A917C4 File Offset: 0x00A8F9C4
		// (set) Token: 0x0602C024 RID: 180260 RVA: 0x00A917D4 File Offset: 0x00A8F9D4
		public unsafe bool 状态_地区运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075A5 RID: 30117
		// (get) Token: 0x0602C025 RID: 180261 RVA: 0x00A917E5 File Offset: 0x00A8F9E5
		// (set) Token: 0x0602C026 RID: 180262 RVA: 0x00A917F5 File Offset: 0x00A8F9F5
		public unsafe bool EnableTurnMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075A6 RID: 30118
		// (get) Token: 0x0602C027 RID: 180263 RVA: 0x00A91806 File Offset: 0x00A8FA06
		// (set) Token: 0x0602C028 RID: 180264 RVA: 0x00A91816 File Offset: 0x00A8FA16
		public unsafe float TurnYawRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_51);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_C.__PropertyOffset_51) = value;
			}
		}

		// Token: 0x0602C029 RID: 180265 RVA: 0x00A91828 File Offset: 0x00A8FA28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceJumpPressed(ref float Speed)
		{
			ABP_SimpleNPC_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x0602C02A RID: 180266 RVA: 0x00A91878 File Offset: 0x00A8FA78
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_SimpleNPC_C.__基础层_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_SimpleNPC_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C02B RID: 180267 RVA: 0x00A91900 File Offset: 0x00A8FB00
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_SimpleNPC_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_SimpleNPC_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C02C RID: 180268 RVA: 0x00A91987 File Offset: 0x00A8FB87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新眨眼()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__更新眨眼_NativeFunctionPtr, null);
		}

		// Token: 0x0602C02D RID: 180269 RVA: 0x00A9199B File Offset: 0x00A8FB9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__更新角色碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602C02E RID: 180270 RVA: 0x00A919AF File Offset: 0x00A8FBAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602C02F RID: 180271 RVA: 0x00A919C3 File Offset: 0x00A8FBC3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x0602C030 RID: 180272 RVA: 0x00A919D8 File Offset: 0x00A8FBD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceSimulateJump(float Speed)
		{
			ABP_SimpleNPC_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C031 RID: 180273 RVA: 0x00A91A20 File Offset: 0x00A8FC20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceFixHookDirect(FVector Offset)
		{
			ABP_SimpleNPC_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C032 RID: 180274 RVA: 0x00A91A68 File Offset: 0x00A8FC68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceManipulateInteractDirection(float 角度)
		{
			ABP_SimpleNPC_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C033 RID: 180275 RVA: 0x00A91AB0 File Offset: 0x00A8FCB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceControlPoint(FVector Offset)
		{
			ABP_SimpleNPC_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C034 RID: 180276 RVA: 0x00A91AF8 File Offset: 0x00A8FCF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCompleted_D6858A004FA1AB8DDEB894A2775AA567(FName NotifyName)
		{
			ABP_SimpleNPC_C.__OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C035 RID: 180277 RVA: 0x00A91B40 File Offset: 0x00A8FD40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567(FName NotifyName)
		{
			ABP_SimpleNPC_C.__OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C036 RID: 180278 RVA: 0x00A91B88 File Offset: 0x00A8FD88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567(FName NotifyName)
		{
			ABP_SimpleNPC_C.__OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C037 RID: 180279 RVA: 0x00A91BD0 File Offset: 0x00A8FDD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567(FName NotifyName)
		{
			ABP_SimpleNPC_C.__OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C038 RID: 180280 RVA: 0x00A91C18 File Offset: 0x00A8FE18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567(FName NotifyName)
		{
			ABP_SimpleNPC_C.__OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_C.__OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C039 RID: 180281 RVA: 0x00A91C5E File Offset: 0x00A8FE5E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_AnimGraphNode_TextureFace_6304FB5245A848CBC89E3BB3A0C53C84()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_AnimGraphNode_TextureFace_6304FB5245A848CBC89E3BB3A0C53C84_NativeFunctionPtr, null);
		}

		// Token: 0x0602C03A RID: 180282 RVA: 0x00A91C72 File Offset: 0x00A8FE72
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_AnimGraphNode_TransitionResult_A3DDDAF84E59A352959207BE6856CD09()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_AnimGraphNode_TransitionResult_A3DDDAF84E59A352959207BE6856CD09_NativeFunctionPtr, null);
		}

		// Token: 0x0602C03B RID: 180283 RVA: 0x00A91C86 File Offset: 0x00A8FE86
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C03C RID: 180284 RVA: 0x00A91C9A File Offset: 0x00A8FE9A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C03D RID: 180285 RVA: 0x00A91CB0 File Offset: 0x00A8FEB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_SimpleNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C03E RID: 180286 RVA: 0x00A91CF8 File Offset: 0x00A8FEF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_SimpleNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C03F RID: 180287 RVA: 0x00A91D3F File Offset: 0x00A8FF3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_PlayMontage()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__AnimNotify_PlayMontage_NativeFunctionPtr, null);
		}

		// Token: 0x0602C040 RID: 180288 RVA: 0x00A91D53 File Offset: 0x00A8FF53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C041 RID: 180289 RVA: 0x00A91D67 File Offset: 0x00A8FF67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C042 RID: 180290 RVA: 0x00A91D7C File Offset: 0x00A8FF7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnCollisionAnimBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__AnimNotify_OnCollisionAnimBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602C043 RID: 180291 RVA: 0x00A91D90 File Offset: 0x00A8FF90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnCollisionAnimEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_C.__AnimNotify_OnCollisionAnimEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C044 RID: 180292 RVA: 0x00A91DA4 File Offset: 0x00A8FFA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_SimpleNPC(int EntryPoint)
		{
			ABP_SimpleNPC_C.__ExecuteUbergraph_ABP_SimpleNPC_FunctionParams* ptr = stackalloc ABP_SimpleNPC_C.__ExecuteUbergraph_ABP_SimpleNPC_FunctionParams[(UIntPtr)439] + 15L / (long)sizeof(ABP_SimpleNPC_C.__ExecuteUbergraph_ABP_SimpleNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_C.__ExecuteUbergraph_ABP_SimpleNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_C.__ExecuteUbergraph_ABP_SimpleNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C045 RID: 180293 RVA: 0x00A91DEE File Offset: 0x00A8FFEE
		protected ABP_SimpleNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040184B8 RID: 99512
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/ABP_SimpleNPC.ABP_SimpleNPC_C";

		// Token: 0x040184B9 RID: 99513
		private static IntPtr _ClassPtr;

		// Token: 0x040184BA RID: 99514
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040184BB RID: 99515
		internal static int __PropertyOffset_0;

		// Token: 0x040184BC RID: 99516
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040184BD RID: 99517
		internal static int __PropertyOffset_1;

		// Token: 0x040184BE RID: 99518
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x040184BF RID: 99519
		internal static int __PropertyOffset_2;

		// Token: 0x040184C0 RID: 99520
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x040184C1 RID: 99521
		internal static int __PropertyOffset_3;

		// Token: 0x040184C2 RID: 99522
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x040184C3 RID: 99523
		internal static int __PropertyOffset_4;

		// Token: 0x040184C4 RID: 99524
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x040184C5 RID: 99525
		internal static int __PropertyOffset_5;

		// Token: 0x040184C6 RID: 99526
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x040184C7 RID: 99527
		internal static int __PropertyOffset_6;

		// Token: 0x040184C8 RID: 99528
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x040184C9 RID: 99529
		internal static int __PropertyOffset_7;

		// Token: 0x040184CA RID: 99530
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x040184CB RID: 99531
		internal static int __PropertyOffset_8;

		// Token: 0x040184CC RID: 99532
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x040184CD RID: 99533
		internal static int __PropertyOffset_9;

		// Token: 0x040184CE RID: 99534
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x040184CF RID: 99535
		internal static int __PropertyOffset_10;

		// Token: 0x040184D0 RID: 99536
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x040184D1 RID: 99537
		internal static int __PropertyOffset_11;

		// Token: 0x040184D2 RID: 99538
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x040184D3 RID: 99539
		internal static int __PropertyOffset_12;

		// Token: 0x040184D4 RID: 99540
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x040184D5 RID: 99541
		internal static int __PropertyOffset_13;

		// Token: 0x040184D6 RID: 99542
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x040184D7 RID: 99543
		internal static int __PropertyOffset_14;

		// Token: 0x040184D8 RID: 99544
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x040184D9 RID: 99545
		internal static int __PropertyOffset_15;

		// Token: 0x040184DA RID: 99546
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x040184DB RID: 99547
		internal static int __PropertyOffset_16;

		// Token: 0x040184DC RID: 99548
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x040184DD RID: 99549
		internal static int __PropertyOffset_17;

		// Token: 0x040184DE RID: 99550
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x040184DF RID: 99551
		internal static int __PropertyOffset_18;

		// Token: 0x040184E0 RID: 99552
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x040184E1 RID: 99553
		internal static int __PropertyOffset_19;

		// Token: 0x040184E2 RID: 99554
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x040184E3 RID: 99555
		internal static int __PropertyOffset_20;

		// Token: 0x040184E4 RID: 99556
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x040184E5 RID: 99557
		internal static int __PropertyOffset_21;

		// Token: 0x040184E6 RID: 99558
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x040184E7 RID: 99559
		internal static int __PropertyOffset_22;

		// Token: 0x040184E8 RID: 99560
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_1;

		// Token: 0x040184E9 RID: 99561
		internal static int __PropertyOffset_23;

		// Token: 0x040184EA RID: 99562
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x040184EB RID: 99563
		internal static int __PropertyOffset_24;

		// Token: 0x040184EC RID: 99564
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x040184ED RID: 99565
		internal static int __PropertyOffset_25;

		// Token: 0x040184EE RID: 99566
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040184EF RID: 99567
		internal static int __PropertyOffset_26;

		// Token: 0x040184F0 RID: 99568
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x040184F1 RID: 99569
		internal static int __PropertyOffset_27;

		// Token: 0x040184F2 RID: 99570
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x040184F3 RID: 99571
		internal static int __PropertyOffset_28;

		// Token: 0x040184F4 RID: 99572
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x040184F5 RID: 99573
		internal static int __PropertyOffset_29;

		// Token: 0x040184F6 RID: 99574
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x040184F7 RID: 99575
		internal static int __PropertyOffset_30;

		// Token: 0x040184F8 RID: 99576
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x040184F9 RID: 99577
		internal static int __PropertyOffset_31;

		// Token: 0x040184FA RID: 99578
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x040184FB RID: 99579
		internal static int __PropertyOffset_32;

		// Token: 0x040184FC RID: 99580
		[Nullable(2)]
		private FAnimNode_TextureFace _AnimGraphNode_TextureFace;

		// Token: 0x040184FD RID: 99581
		internal static int __PropertyOffset_33;

		// Token: 0x040184FE RID: 99582
		internal static int __PropertyOffset_34;

		// Token: 0x040184FF RID: 99583
		internal static int __PropertyOffset_35;

		// Token: 0x04018500 RID: 99584
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimMontage> _IdleMontageArray;

		// Token: 0x04018501 RID: 99585
		internal static int __PropertyOffset_36;

		// Token: 0x04018502 RID: 99586
		internal static int __PropertyOffset_37;

		// Token: 0x04018503 RID: 99587
		internal static int __PropertyOffset_38;

		// Token: 0x04018504 RID: 99588
		internal static int __PropertyOffset_39;

		// Token: 0x04018505 RID: 99589
		internal static int __PropertyOffset_40;

		// Token: 0x04018506 RID: 99590
		internal static int __PropertyOffset_41;

		// Token: 0x04018507 RID: 99591
		internal static int __PropertyOffset_42;

		// Token: 0x04018508 RID: 99592
		internal static int __PropertyOffset_43;

		// Token: 0x04018509 RID: 99593
		internal static int __PropertyOffset_44;

		// Token: 0x0401850A RID: 99594
		internal static int __PropertyOffset_45;

		// Token: 0x0401850B RID: 99595
		internal static int __PropertyOffset_46;

		// Token: 0x0401850C RID: 99596
		internal static int __PropertyOffset_47;

		// Token: 0x0401850D RID: 99597
		internal static int __PropertyOffset_48;

		// Token: 0x0401850E RID: 99598
		internal static int __PropertyOffset_49;

		// Token: 0x0401850F RID: 99599
		internal static int __PropertyOffset_50;

		// Token: 0x04018510 RID: 99600
		internal static int __PropertyOffset_51;

		// Token: 0x04018511 RID: 99601
		private static IntPtr __InterfaceJumpPressed_NativeFunctionPtr;

		// Token: 0x04018512 RID: 99602
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018513 RID: 99603
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018514 RID: 99604
		private static IntPtr __更新眨眼_NativeFunctionPtr;

		// Token: 0x04018515 RID: 99605
		private static IntPtr __更新角色碰撞_NativeFunctionPtr;

		// Token: 0x04018516 RID: 99606
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x04018517 RID: 99607
		private static IntPtr __ClimbDash_NativeFunctionPtr;

		// Token: 0x04018518 RID: 99608
		private static IntPtr __InterfaceSimulateJump_NativeFunctionPtr;

		// Token: 0x04018519 RID: 99609
		private static IntPtr __InterfaceFixHookDirect_NativeFunctionPtr;

		// Token: 0x0401851A RID: 99610
		private static IntPtr __InterfaceManipulateInteractDirection_NativeFunctionPtr;

		// Token: 0x0401851B RID: 99611
		private static IntPtr __InterfaceControlPoint_NativeFunctionPtr;

		// Token: 0x0401851C RID: 99612
		private static IntPtr __OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr;

		// Token: 0x0401851D RID: 99613
		private static IntPtr __OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr;

		// Token: 0x0401851E RID: 99614
		private static IntPtr __OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr;

		// Token: 0x0401851F RID: 99615
		private static IntPtr __OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr;

		// Token: 0x04018520 RID: 99616
		private static IntPtr __OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_NativeFunctionPtr;

		// Token: 0x04018521 RID: 99617
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_AnimGraphNode_TextureFace_6304FB5245A848CBC89E3BB3A0C53C84_NativeFunctionPtr;

		// Token: 0x04018522 RID: 99618
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_AnimGraphNode_TransitionResult_A3DDDAF84E59A352959207BE6856CD09_NativeFunctionPtr;

		// Token: 0x04018523 RID: 99619
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018524 RID: 99620
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018525 RID: 99621
		private static IntPtr __AnimNotify_PlayMontage_NativeFunctionPtr;

		// Token: 0x04018526 RID: 99622
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x04018527 RID: 99623
		private static IntPtr __AnimNotify_OnCollisionAnimBegin_NativeFunctionPtr;

		// Token: 0x04018528 RID: 99624
		private static IntPtr __AnimNotify_OnCollisionAnimEnd_NativeFunctionPtr;

		// Token: 0x04018529 RID: 99625
		private static IntPtr __ExecuteUbergraph_ABP_SimpleNPC_NativeFunctionPtr;

		// Token: 0x0200A3FF RID: 41983
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x040331EE RID: 209390
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A400 RID: 41984
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x040331EF RID: 209391
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A401 RID: 41985
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x040331F0 RID: 209392
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A402 RID: 41986
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x040331F1 RID: 209393
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A403 RID: 41987
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x040331F2 RID: 209394
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A404 RID: 41988
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x040331F3 RID: 209395
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A405 RID: 41989
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x040331F4 RID: 209396
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A406 RID: 41990
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnCompleted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams
		{
			// Token: 0x040331F5 RID: 209397
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A407 RID: 41991
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnBlendOut_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams
		{
			// Token: 0x040331F6 RID: 209398
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A408 RID: 41992
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnInterrupted_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams
		{
			// Token: 0x040331F7 RID: 209399
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A409 RID: 41993
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyBegin_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams
		{
			// Token: 0x040331F8 RID: 209400
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A40A RID: 41994
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyEnd_D6858A004FA1AB8DDEB894A2775AA567_FunctionParams
		{
			// Token: 0x040331F9 RID: 209401
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A40B RID: 41995
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x040331FA RID: 209402
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A40C RID: 41996
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 424)]
		protected ref struct __ExecuteUbergraph_ABP_SimpleNPC_FunctionParams
		{
			// Token: 0x040331FB RID: 209403
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
