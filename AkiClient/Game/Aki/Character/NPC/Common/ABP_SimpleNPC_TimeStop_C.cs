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
	// Token: 0x020040EB RID: 16619
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/ABP_SimpleNPC_TimeStop.ABP_SimpleNPC_TimeStop_C")]
	[UnrealStructLayout(7600, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 7592)]
	public class ABP_SimpleNPC_TimeStop_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_Animation_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602C046 RID: 180294 RVA: 0x00A91DF7 File Offset: 0x00A8FFF7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_SimpleNPC_TimeStop_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/ABP_SimpleNPC_TimeStop.ABP_SimpleNPC_TimeStop_C");
			}
			return ABP_SimpleNPC_TimeStop_C._ClassPtr;
		}

		// Token: 0x0602C047 RID: 180295 RVA: 0x00A91E1C File Offset: 0x00A9001C
		public ABP_SimpleNPC_TimeStop_C() : this(BuiltinUtils.AllocNativeUObject(ABP_SimpleNPC_TimeStop_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C048 RID: 180296 RVA: 0x00A91E44 File Offset: 0x00A90044
		public ABP_SimpleNPC_TimeStop_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_SimpleNPC_TimeStop_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170075A7 RID: 30119
		// (get) Token: 0x0602C049 RID: 180297 RVA: 0x00A91E78 File Offset: 0x00A90078
		// (set) Token: 0x0602C04A RID: 180298 RVA: 0x00A91EB1 File Offset: 0x00A900B1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075A8 RID: 30120
		// (get) Token: 0x0602C04B RID: 180299 RVA: 0x00A91ED4 File Offset: 0x00A900D4
		// (set) Token: 0x0602C04C RID: 180300 RVA: 0x00A91F0D File Offset: 0x00A9010D
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075A9 RID: 30121
		// (get) Token: 0x0602C04D RID: 180301 RVA: 0x00A91F30 File Offset: 0x00A90130
		// (set) Token: 0x0602C04E RID: 180302 RVA: 0x00A91F69 File Offset: 0x00A90169
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075AA RID: 30122
		// (get) Token: 0x0602C04F RID: 180303 RVA: 0x00A91F8C File Offset: 0x00A9018C
		// (set) Token: 0x0602C050 RID: 180304 RVA: 0x00A91FC5 File Offset: 0x00A901C5
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075AB RID: 30123
		// (get) Token: 0x0602C051 RID: 180305 RVA: 0x00A91FE8 File Offset: 0x00A901E8
		// (set) Token: 0x0602C052 RID: 180306 RVA: 0x00A92021 File Offset: 0x00A90221
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075AC RID: 30124
		// (get) Token: 0x0602C053 RID: 180307 RVA: 0x00A92044 File Offset: 0x00A90244
		// (set) Token: 0x0602C054 RID: 180308 RVA: 0x00A9207D File Offset: 0x00A9027D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075AD RID: 30125
		// (get) Token: 0x0602C055 RID: 180309 RVA: 0x00A920A0 File Offset: 0x00A902A0
		// (set) Token: 0x0602C056 RID: 180310 RVA: 0x00A920D9 File Offset: 0x00A902D9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075AE RID: 30126
		// (get) Token: 0x0602C057 RID: 180311 RVA: 0x00A920FC File Offset: 0x00A902FC
		// (set) Token: 0x0602C058 RID: 180312 RVA: 0x00A92135 File Offset: 0x00A90335
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075AF RID: 30127
		// (get) Token: 0x0602C059 RID: 180313 RVA: 0x00A92158 File Offset: 0x00A90358
		// (set) Token: 0x0602C05A RID: 180314 RVA: 0x00A92191 File Offset: 0x00A90391
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B0 RID: 30128
		// (get) Token: 0x0602C05B RID: 180315 RVA: 0x00A921B4 File Offset: 0x00A903B4
		// (set) Token: 0x0602C05C RID: 180316 RVA: 0x00A921ED File Offset: 0x00A903ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B1 RID: 30129
		// (get) Token: 0x0602C05D RID: 180317 RVA: 0x00A92210 File Offset: 0x00A90410
		// (set) Token: 0x0602C05E RID: 180318 RVA: 0x00A92249 File Offset: 0x00A90449
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B2 RID: 30130
		// (get) Token: 0x0602C05F RID: 180319 RVA: 0x00A9226C File Offset: 0x00A9046C
		// (set) Token: 0x0602C060 RID: 180320 RVA: 0x00A922A5 File Offset: 0x00A904A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B3 RID: 30131
		// (get) Token: 0x0602C061 RID: 180321 RVA: 0x00A922C8 File Offset: 0x00A904C8
		// (set) Token: 0x0602C062 RID: 180322 RVA: 0x00A92301 File Offset: 0x00A90501
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B4 RID: 30132
		// (get) Token: 0x0602C063 RID: 180323 RVA: 0x00A92324 File Offset: 0x00A90524
		// (set) Token: 0x0602C064 RID: 180324 RVA: 0x00A9235D File Offset: 0x00A9055D
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B5 RID: 30133
		// (get) Token: 0x0602C065 RID: 180325 RVA: 0x00A92380 File Offset: 0x00A90580
		// (set) Token: 0x0602C066 RID: 180326 RVA: 0x00A923B9 File Offset: 0x00A905B9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B6 RID: 30134
		// (get) Token: 0x0602C067 RID: 180327 RVA: 0x00A923DC File Offset: 0x00A905DC
		// (set) Token: 0x0602C068 RID: 180328 RVA: 0x00A92415 File Offset: 0x00A90615
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B7 RID: 30135
		// (get) Token: 0x0602C069 RID: 180329 RVA: 0x00A92438 File Offset: 0x00A90638
		// (set) Token: 0x0602C06A RID: 180330 RVA: 0x00A92471 File Offset: 0x00A90671
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B8 RID: 30136
		// (get) Token: 0x0602C06B RID: 180331 RVA: 0x00A92494 File Offset: 0x00A90694
		// (set) Token: 0x0602C06C RID: 180332 RVA: 0x00A924CD File Offset: 0x00A906CD
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075B9 RID: 30137
		// (get) Token: 0x0602C06D RID: 180333 RVA: 0x00A924F0 File Offset: 0x00A906F0
		// (set) Token: 0x0602C06E RID: 180334 RVA: 0x00A92529 File Offset: 0x00A90729
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_1) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_1 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075BA RID: 30138
		// (get) Token: 0x0602C06F RID: 180335 RVA: 0x00A9254C File Offset: 0x00A9074C
		// (set) Token: 0x0602C070 RID: 180336 RVA: 0x00A92585 File Offset: 0x00A90785
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075BB RID: 30139
		// (get) Token: 0x0602C071 RID: 180337 RVA: 0x00A925A8 File Offset: 0x00A907A8
		// (set) Token: 0x0602C072 RID: 180338 RVA: 0x00A925E1 File Offset: 0x00A907E1
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075BC RID: 30140
		// (get) Token: 0x0602C073 RID: 180339 RVA: 0x00A92604 File Offset: 0x00A90804
		// (set) Token: 0x0602C074 RID: 180340 RVA: 0x00A9263D File Offset: 0x00A9083D
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075BD RID: 30141
		// (get) Token: 0x0602C075 RID: 180341 RVA: 0x00A92660 File Offset: 0x00A90860
		// (set) Token: 0x0602C076 RID: 180342 RVA: 0x00A92699 File Offset: 0x00A90899
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075BE RID: 30142
		// (get) Token: 0x0602C077 RID: 180343 RVA: 0x00A926BC File Offset: 0x00A908BC
		// (set) Token: 0x0602C078 RID: 180344 RVA: 0x00A926F5 File Offset: 0x00A908F5
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075BF RID: 30143
		// (get) Token: 0x0602C079 RID: 180345 RVA: 0x00A92718 File Offset: 0x00A90918
		// (set) Token: 0x0602C07A RID: 180346 RVA: 0x00A92751 File Offset: 0x00A90951
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075C0 RID: 30144
		// (get) Token: 0x0602C07B RID: 180347 RVA: 0x00A92774 File Offset: 0x00A90974
		// (set) Token: 0x0602C07C RID: 180348 RVA: 0x00A927AD File Offset: 0x00A909AD
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075C1 RID: 30145
		// (get) Token: 0x0602C07D RID: 180349 RVA: 0x00A927D0 File Offset: 0x00A909D0
		// (set) Token: 0x0602C07E RID: 180350 RVA: 0x00A92809 File Offset: 0x00A90A09
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075C2 RID: 30146
		// (get) Token: 0x0602C07F RID: 180351 RVA: 0x00A9282C File Offset: 0x00A90A2C
		// (set) Token: 0x0602C080 RID: 180352 RVA: 0x00A92865 File Offset: 0x00A90A65
		public FAnimNode_TextureFace AnimGraphNode_TextureFace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TextureFace result;
				if ((result = this._AnimGraphNode_TextureFace) == null)
				{
					result = (this._AnimGraphNode_TextureFace = new FAnimNode_TextureFace(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TextureFace.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075C3 RID: 30147
		// (get) Token: 0x0602C081 RID: 180353 RVA: 0x00A92888 File Offset: 0x00A90A88
		// (set) Token: 0x0602C082 RID: 180354 RVA: 0x00A928C1 File Offset: 0x00A90AC1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075C4 RID: 30148
		// (get) Token: 0x0602C083 RID: 180355 RVA: 0x00A928E2 File Offset: 0x00A90AE2
		// (set) Token: 0x0602C084 RID: 180356 RVA: 0x00A928F6 File Offset: 0x00A90AF6
		[Nullable(2)]
		public unsafe BP_BaseNPC_C 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BaseNPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_TimeStop_C.__PropertyOffset_29);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_TimeStop_C.__PropertyOffset_29, value);
			}
		}

		// Token: 0x170075C5 RID: 30149
		// (get) Token: 0x0602C085 RID: 180357 RVA: 0x00A9290B File Offset: 0x00A90B0B
		// (set) Token: 0x0602C086 RID: 180358 RVA: 0x00A9291B File Offset: 0x00A90B1B
		public unsafe bool ifPlayIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075C6 RID: 30150
		// (get) Token: 0x0602C087 RID: 180359 RVA: 0x00A9292C File Offset: 0x00A90B2C
		// (set) Token: 0x0602C088 RID: 180360 RVA: 0x00A92965 File Offset: 0x00A90B65
		public TArray<UAnimMontage> IdleMontageArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimMontage> result;
				if ((result = this._IdleMontageArray) == null)
				{
					result = (this._IdleMontageArray = new TArray<UAnimMontage>(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				this.IdleMontageArray.CopyAssign(value);
			}
		}

		// Token: 0x170075C7 RID: 30151
		// (get) Token: 0x0602C089 RID: 180361 RVA: 0x00A92973 File Offset: 0x00A90B73
		// (set) Token: 0x0602C08A RID: 180362 RVA: 0x00A92987 File Offset: 0x00A90B87
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_TimeStop_C.__PropertyOffset_32);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_SimpleNPC_TimeStop_C.__PropertyOffset_32, value);
			}
		}

		// Token: 0x170075C8 RID: 30152
		// (get) Token: 0x0602C08B RID: 180363 RVA: 0x00A9299C File Offset: 0x00A90B9C
		// (set) Token: 0x0602C08C RID: 180364 RVA: 0x00A929B0 File Offset: 0x00A90BB0
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170075C9 RID: 30153
		// (get) Token: 0x0602C08D RID: 180365 RVA: 0x00A929C5 File Offset: 0x00A90BC5
		// (set) Token: 0x0602C08E RID: 180366 RVA: 0x00A929D5 File Offset: 0x00A90BD5
		public unsafe bool IsBeingImpacted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075CA RID: 30154
		// (get) Token: 0x0602C08F RID: 180367 RVA: 0x00A929E6 File Offset: 0x00A90BE6
		// (set) Token: 0x0602C090 RID: 180368 RVA: 0x00A929F6 File Offset: 0x00A90BF6
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_35));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_35) = (byte)value;
			}
		}

		// Token: 0x170075CB RID: 30155
		// (get) Token: 0x0602C091 RID: 180369 RVA: 0x00A92A07 File Offset: 0x00A90C07
		// (set) Token: 0x0602C092 RID: 180370 RVA: 0x00A92A17 File Offset: 0x00A90C17
		public unsafe int NpcEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170075CC RID: 30156
		// (get) Token: 0x0602C093 RID: 180371 RVA: 0x00A92A28 File Offset: 0x00A90C28
		// (set) Token: 0x0602C094 RID: 180372 RVA: 0x00A92A38 File Offset: 0x00A90C38
		public unsafe float CollisionDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170075CD RID: 30157
		// (get) Token: 0x0602C095 RID: 180373 RVA: 0x00A92A49 File Offset: 0x00A90C49
		// (set) Token: 0x0602C096 RID: 180374 RVA: 0x00A92A59 File Offset: 0x00A90C59
		public unsafe float CollisionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170075CE RID: 30158
		// (get) Token: 0x0602C097 RID: 180375 RVA: 0x00A92A6A File Offset: 0x00A90C6A
		// (set) Token: 0x0602C098 RID: 180376 RVA: 0x00A92A7A File Offset: 0x00A90C7A
		public unsafe bool IsBeingAttacked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_39) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_39) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075CF RID: 30159
		// (get) Token: 0x0602C099 RID: 180377 RVA: 0x00A92A8B File Offset: 0x00A90C8B
		// (set) Token: 0x0602C09A RID: 180378 RVA: 0x00A92A9B File Offset: 0x00A90C9B
		public unsafe float ExpresionAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170075D0 RID: 30160
		// (get) Token: 0x0602C09B RID: 180379 RVA: 0x00A92AAC File Offset: 0x00A90CAC
		// (set) Token: 0x0602C09C RID: 180380 RVA: 0x00A92ABC File Offset: 0x00A90CBC
		public unsafe float RandomEpresionEndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170075D1 RID: 30161
		// (get) Token: 0x0602C09D RID: 180381 RVA: 0x00A92ACD File Offset: 0x00A90CCD
		// (set) Token: 0x0602C09E RID: 180382 RVA: 0x00A92ADD File Offset: 0x00A90CDD
		public unsafe float 眨眼动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170075D2 RID: 30162
		// (get) Token: 0x0602C09F RID: 180383 RVA: 0x00A92AEE File Offset: 0x00A90CEE
		// (set) Token: 0x0602C0A0 RID: 180384 RVA: 0x00A92AFE File Offset: 0x00A90CFE
		public unsafe float 此轮眨眼动画总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_43);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_43) = value;
			}
		}

		// Token: 0x170075D3 RID: 30163
		// (get) Token: 0x0602C0A1 RID: 180385 RVA: 0x00A92B0F File Offset: 0x00A90D0F
		// (set) Token: 0x0602C0A2 RID: 180386 RVA: 0x00A92B1F File Offset: 0x00A90D1F
		public unsafe bool 眨眼中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075D4 RID: 30164
		// (get) Token: 0x0602C0A3 RID: 180387 RVA: 0x00A92B30 File Offset: 0x00A90D30
		// (set) Token: 0x0602C0A4 RID: 180388 RVA: 0x00A92B40 File Offset: 0x00A90D40
		public unsafe bool 状态_地区运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_45) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_45) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075D5 RID: 30165
		// (get) Token: 0x0602C0A5 RID: 180389 RVA: 0x00A92B51 File Offset: 0x00A90D51
		// (set) Token: 0x0602C0A6 RID: 180390 RVA: 0x00A92B61 File Offset: 0x00A90D61
		public unsafe bool EnableTurnMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x170075D6 RID: 30166
		// (get) Token: 0x0602C0A7 RID: 180391 RVA: 0x00A92B72 File Offset: 0x00A90D72
		// (set) Token: 0x0602C0A8 RID: 180392 RVA: 0x00A92B82 File Offset: 0x00A90D82
		public unsafe float TurnYawRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_SimpleNPC_TimeStop_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x0602C0A9 RID: 180393 RVA: 0x00A92B94 File Offset: 0x00A90D94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceJumpPressed(ref float Speed)
		{
			ABP_SimpleNPC_TimeStop_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x0602C0AA RID: 180394 RVA: 0x00A92BE4 File Offset: 0x00A90DE4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_SimpleNPC_TimeStop_C.__基础层_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C0AB RID: 180395 RVA: 0x00A92C6C File Offset: 0x00A90E6C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_SimpleNPC_TimeStop_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C0AC RID: 180396 RVA: 0x00A92CF3 File Offset: 0x00A90EF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新眨眼()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__更新眨眼_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0AD RID: 180397 RVA: 0x00A92D07 File Offset: 0x00A90F07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__更新角色碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0AE RID: 180398 RVA: 0x00A92D1B File Offset: 0x00A90F1B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0AF RID: 180399 RVA: 0x00A92D30 File Offset: 0x00A90F30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceControlPoint(FVector Offset)
		{
			ABP_SimpleNPC_TimeStop_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0B0 RID: 180400 RVA: 0x00A92D78 File Offset: 0x00A90F78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceManipulateInteractDirection(float 角度)
		{
			ABP_SimpleNPC_TimeStop_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0B1 RID: 180401 RVA: 0x00A92DC0 File Offset: 0x00A90FC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceFixHookDirect(FVector Offset)
		{
			ABP_SimpleNPC_TimeStop_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0B2 RID: 180402 RVA: 0x00A92E08 File Offset: 0x00A91008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceSimulateJump(float Speed)
		{
			ABP_SimpleNPC_TimeStop_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0B3 RID: 180403 RVA: 0x00A92E4E File Offset: 0x00A9104E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0B4 RID: 180404 RVA: 0x00A92E62 File Offset: 0x00A91062
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_TimeStop_AnimGraphNode_TextureFace_985B8F5F431DC97AE142CC89BC87AE5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_TimeStop_AnimGraphNode_TextureFace_985B8F5F431DC97AE142CC89BC87AE5B_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0B5 RID: 180405 RVA: 0x00A92E76 File Offset: 0x00A91076
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0B6 RID: 180406 RVA: 0x00A92E8A File Offset: 0x00A9108A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C0B7 RID: 180407 RVA: 0x00A92EA0 File Offset: 0x00A910A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C0B8 RID: 180408 RVA: 0x00A92EE8 File Offset: 0x00A910E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C0B9 RID: 180409 RVA: 0x00A92F2F File Offset: 0x00A9112F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0BA RID: 180410 RVA: 0x00A92F43 File Offset: 0x00A91143
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C0BB RID: 180411 RVA: 0x00A92F58 File Offset: 0x00A91158
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_SimpleNPC_TimeStop(int EntryPoint)
		{
			ABP_SimpleNPC_TimeStop_C.__ExecuteUbergraph_ABP_SimpleNPC_TimeStop_FunctionParams* ptr = stackalloc ABP_SimpleNPC_TimeStop_C.__ExecuteUbergraph_ABP_SimpleNPC_TimeStop_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(ABP_SimpleNPC_TimeStop_C.__ExecuteUbergraph_ABP_SimpleNPC_TimeStop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_SimpleNPC_TimeStop_C.__ExecuteUbergraph_ABP_SimpleNPC_TimeStop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_SimpleNPC_TimeStop_C.__ExecuteUbergraph_ABP_SimpleNPC_TimeStop_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C0BC RID: 180412 RVA: 0x00A92F9F File Offset: 0x00A9119F
		protected ABP_SimpleNPC_TimeStop_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401852A RID: 99626
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/ABP_SimpleNPC_TimeStop.ABP_SimpleNPC_TimeStop_C";

		// Token: 0x0401852B RID: 99627
		private static IntPtr _ClassPtr;

		// Token: 0x0401852C RID: 99628
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401852D RID: 99629
		internal static int __PropertyOffset_0;

		// Token: 0x0401852E RID: 99630
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401852F RID: 99631
		internal static int __PropertyOffset_1;

		// Token: 0x04018530 RID: 99632
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018531 RID: 99633
		internal static int __PropertyOffset_2;

		// Token: 0x04018532 RID: 99634
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x04018533 RID: 99635
		internal static int __PropertyOffset_3;

		// Token: 0x04018534 RID: 99636
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018535 RID: 99637
		internal static int __PropertyOffset_4;

		// Token: 0x04018536 RID: 99638
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018537 RID: 99639
		internal static int __PropertyOffset_5;

		// Token: 0x04018538 RID: 99640
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018539 RID: 99641
		internal static int __PropertyOffset_6;

		// Token: 0x0401853A RID: 99642
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401853B RID: 99643
		internal static int __PropertyOffset_7;

		// Token: 0x0401853C RID: 99644
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x0401853D RID: 99645
		internal static int __PropertyOffset_8;

		// Token: 0x0401853E RID: 99646
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0401853F RID: 99647
		internal static int __PropertyOffset_9;

		// Token: 0x04018540 RID: 99648
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04018541 RID: 99649
		internal static int __PropertyOffset_10;

		// Token: 0x04018542 RID: 99650
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04018543 RID: 99651
		internal static int __PropertyOffset_11;

		// Token: 0x04018544 RID: 99652
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04018545 RID: 99653
		internal static int __PropertyOffset_12;

		// Token: 0x04018546 RID: 99654
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04018547 RID: 99655
		internal static int __PropertyOffset_13;

		// Token: 0x04018548 RID: 99656
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018549 RID: 99657
		internal static int __PropertyOffset_14;

		// Token: 0x0401854A RID: 99658
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x0401854B RID: 99659
		internal static int __PropertyOffset_15;

		// Token: 0x0401854C RID: 99660
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0401854D RID: 99661
		internal static int __PropertyOffset_16;

		// Token: 0x0401854E RID: 99662
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401854F RID: 99663
		internal static int __PropertyOffset_17;

		// Token: 0x04018550 RID: 99664
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04018551 RID: 99665
		internal static int __PropertyOffset_18;

		// Token: 0x04018552 RID: 99666
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_1;

		// Token: 0x04018553 RID: 99667
		internal static int __PropertyOffset_19;

		// Token: 0x04018554 RID: 99668
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04018555 RID: 99669
		internal static int __PropertyOffset_20;

		// Token: 0x04018556 RID: 99670
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x04018557 RID: 99671
		internal static int __PropertyOffset_21;

		// Token: 0x04018558 RID: 99672
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018559 RID: 99673
		internal static int __PropertyOffset_22;

		// Token: 0x0401855A RID: 99674
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x0401855B RID: 99675
		internal static int __PropertyOffset_23;

		// Token: 0x0401855C RID: 99676
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x0401855D RID: 99677
		internal static int __PropertyOffset_24;

		// Token: 0x0401855E RID: 99678
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x0401855F RID: 99679
		internal static int __PropertyOffset_25;

		// Token: 0x04018560 RID: 99680
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04018561 RID: 99681
		internal static int __PropertyOffset_26;

		// Token: 0x04018562 RID: 99682
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04018563 RID: 99683
		internal static int __PropertyOffset_27;

		// Token: 0x04018564 RID: 99684
		[Nullable(2)]
		private FAnimNode_TextureFace _AnimGraphNode_TextureFace;

		// Token: 0x04018565 RID: 99685
		internal static int __PropertyOffset_28;

		// Token: 0x04018566 RID: 99686
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018567 RID: 99687
		internal static int __PropertyOffset_29;

		// Token: 0x04018568 RID: 99688
		internal static int __PropertyOffset_30;

		// Token: 0x04018569 RID: 99689
		internal static int __PropertyOffset_31;

		// Token: 0x0401856A RID: 99690
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimMontage> _IdleMontageArray;

		// Token: 0x0401856B RID: 99691
		internal static int __PropertyOffset_32;

		// Token: 0x0401856C RID: 99692
		internal static int __PropertyOffset_33;

		// Token: 0x0401856D RID: 99693
		internal static int __PropertyOffset_34;

		// Token: 0x0401856E RID: 99694
		internal static int __PropertyOffset_35;

		// Token: 0x0401856F RID: 99695
		internal static int __PropertyOffset_36;

		// Token: 0x04018570 RID: 99696
		internal static int __PropertyOffset_37;

		// Token: 0x04018571 RID: 99697
		internal static int __PropertyOffset_38;

		// Token: 0x04018572 RID: 99698
		internal static int __PropertyOffset_39;

		// Token: 0x04018573 RID: 99699
		internal static int __PropertyOffset_40;

		// Token: 0x04018574 RID: 99700
		internal static int __PropertyOffset_41;

		// Token: 0x04018575 RID: 99701
		internal static int __PropertyOffset_42;

		// Token: 0x04018576 RID: 99702
		internal static int __PropertyOffset_43;

		// Token: 0x04018577 RID: 99703
		internal static int __PropertyOffset_44;

		// Token: 0x04018578 RID: 99704
		internal static int __PropertyOffset_45;

		// Token: 0x04018579 RID: 99705
		internal static int __PropertyOffset_46;

		// Token: 0x0401857A RID: 99706
		internal static int __PropertyOffset_47;

		// Token: 0x0401857B RID: 99707
		private static IntPtr __InterfaceJumpPressed_NativeFunctionPtr;

		// Token: 0x0401857C RID: 99708
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x0401857D RID: 99709
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401857E RID: 99710
		private static IntPtr __更新眨眼_NativeFunctionPtr;

		// Token: 0x0401857F RID: 99711
		private static IntPtr __更新角色碰撞_NativeFunctionPtr;

		// Token: 0x04018580 RID: 99712
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x04018581 RID: 99713
		private static IntPtr __InterfaceControlPoint_NativeFunctionPtr;

		// Token: 0x04018582 RID: 99714
		private static IntPtr __InterfaceManipulateInteractDirection_NativeFunctionPtr;

		// Token: 0x04018583 RID: 99715
		private static IntPtr __InterfaceFixHookDirect_NativeFunctionPtr;

		// Token: 0x04018584 RID: 99716
		private static IntPtr __InterfaceSimulateJump_NativeFunctionPtr;

		// Token: 0x04018585 RID: 99717
		private static IntPtr __ClimbDash_NativeFunctionPtr;

		// Token: 0x04018586 RID: 99718
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_SimpleNPC_TimeStop_AnimGraphNode_TextureFace_985B8F5F431DC97AE142CC89BC87AE5B_NativeFunctionPtr;

		// Token: 0x04018587 RID: 99719
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018588 RID: 99720
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018589 RID: 99721
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x0401858A RID: 99722
		private static IntPtr __ExecuteUbergraph_ABP_SimpleNPC_TimeStop_NativeFunctionPtr;

		// Token: 0x0200A40D RID: 41997
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x040331FC RID: 209404
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A40E RID: 41998
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x040331FD RID: 209405
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A40F RID: 41999
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x040331FE RID: 209406
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A410 RID: 42000
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x040331FF RID: 209407
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A411 RID: 42001
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x04033200 RID: 209408
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A412 RID: 42002
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x04033201 RID: 209409
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A413 RID: 42003
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x04033202 RID: 209410
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A414 RID: 42004
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04033203 RID: 209411
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A415 RID: 42005
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_ABP_SimpleNPC_TimeStop_FunctionParams
		{
			// Token: 0x04033204 RID: 209412
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
