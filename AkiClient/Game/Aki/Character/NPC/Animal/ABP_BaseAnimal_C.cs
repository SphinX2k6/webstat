using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal
{
	// Token: 0x020040F0 RID: 16624
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/ABP_BaseAnimal.ABP_BaseAnimal_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_BaseAnimal_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_AnimalEcological_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602C0FE RID: 180478 RVA: 0x00A9397C File Offset: 0x00A91B7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/ABP_BaseAnimal.ABP_BaseAnimal_C");
			}
			return ABP_BaseAnimal_C._ClassPtr;
		}

		// Token: 0x0602C0FF RID: 180479 RVA: 0x00A939A0 File Offset: 0x00A91BA0
		public ABP_BaseAnimal_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C100 RID: 180480 RVA: 0x00A939C8 File Offset: 0x00A91BC8
		public ABP_BaseAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170075E7 RID: 30183
		// (get) Token: 0x0602C101 RID: 180481 RVA: 0x00A939FC File Offset: 0x00A91BFC
		// (set) Token: 0x0602C102 RID: 180482 RVA: 0x00A93A35 File Offset: 0x00A91C35
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075E8 RID: 30184
		// (get) Token: 0x0602C103 RID: 180483 RVA: 0x00A93A58 File Offset: 0x00A91C58
		// (set) Token: 0x0602C104 RID: 180484 RVA: 0x00A93A91 File Offset: 0x00A91C91
		public FAnimNode_Root AnimGraphNode_Root_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_3) == null)
				{
					result = (this._AnimGraphNode_Root_3 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075E9 RID: 30185
		// (get) Token: 0x0602C105 RID: 180485 RVA: 0x00A93AB4 File Offset: 0x00A91CB4
		// (set) Token: 0x0602C106 RID: 180486 RVA: 0x00A93AED File Offset: 0x00A91CED
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_1) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_1 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075EA RID: 30186
		// (get) Token: 0x0602C107 RID: 180487 RVA: 0x00A93B10 File Offset: 0x00A91D10
		// (set) Token: 0x0602C108 RID: 180488 RVA: 0x00A93B49 File Offset: 0x00A91D49
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075EB RID: 30187
		// (get) Token: 0x0602C109 RID: 180489 RVA: 0x00A93B6C File Offset: 0x00A91D6C
		// (set) Token: 0x0602C10A RID: 180490 RVA: 0x00A93BA5 File Offset: 0x00A91DA5
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075EC RID: 30188
		// (get) Token: 0x0602C10B RID: 180491 RVA: 0x00A93BC8 File Offset: 0x00A91DC8
		// (set) Token: 0x0602C10C RID: 180492 RVA: 0x00A93C01 File Offset: 0x00A91E01
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075ED RID: 30189
		// (get) Token: 0x0602C10D RID: 180493 RVA: 0x00A93C24 File Offset: 0x00A91E24
		// (set) Token: 0x0602C10E RID: 180494 RVA: 0x00A93C5D File Offset: 0x00A91E5D
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075EE RID: 30190
		// (get) Token: 0x0602C10F RID: 180495 RVA: 0x00A93C80 File Offset: 0x00A91E80
		// (set) Token: 0x0602C110 RID: 180496 RVA: 0x00A93CB9 File Offset: 0x00A91EB9
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075EF RID: 30191
		// (get) Token: 0x0602C111 RID: 180497 RVA: 0x00A93CDC File Offset: 0x00A91EDC
		// (set) Token: 0x0602C112 RID: 180498 RVA: 0x00A93D15 File Offset: 0x00A91F15
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F0 RID: 30192
		// (get) Token: 0x0602C113 RID: 180499 RVA: 0x00A93D38 File Offset: 0x00A91F38
		// (set) Token: 0x0602C114 RID: 180500 RVA: 0x00A93D71 File Offset: 0x00A91F71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_52) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_52 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F1 RID: 30193
		// (get) Token: 0x0602C115 RID: 180501 RVA: 0x00A93D94 File Offset: 0x00A91F94
		// (set) Token: 0x0602C116 RID: 180502 RVA: 0x00A93DCD File Offset: 0x00A91FCD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_51) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_51 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F2 RID: 30194
		// (get) Token: 0x0602C117 RID: 180503 RVA: 0x00A93DF0 File Offset: 0x00A91FF0
		// (set) Token: 0x0602C118 RID: 180504 RVA: 0x00A93E29 File Offset: 0x00A92029
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_50) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_50 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F3 RID: 30195
		// (get) Token: 0x0602C119 RID: 180505 RVA: 0x00A93E4C File Offset: 0x00A9204C
		// (set) Token: 0x0602C11A RID: 180506 RVA: 0x00A93E85 File Offset: 0x00A92085
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_49) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_49 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F4 RID: 30196
		// (get) Token: 0x0602C11B RID: 180507 RVA: 0x00A93EA8 File Offset: 0x00A920A8
		// (set) Token: 0x0602C11C RID: 180508 RVA: 0x00A93EE1 File Offset: 0x00A920E1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_48) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_48 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F5 RID: 30197
		// (get) Token: 0x0602C11D RID: 180509 RVA: 0x00A93F04 File Offset: 0x00A92104
		// (set) Token: 0x0602C11E RID: 180510 RVA: 0x00A93F3D File Offset: 0x00A9213D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_47) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_47 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F6 RID: 30198
		// (get) Token: 0x0602C11F RID: 180511 RVA: 0x00A93F60 File Offset: 0x00A92160
		// (set) Token: 0x0602C120 RID: 180512 RVA: 0x00A93F99 File Offset: 0x00A92199
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_46) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_46 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F7 RID: 30199
		// (get) Token: 0x0602C121 RID: 180513 RVA: 0x00A93FBC File Offset: 0x00A921BC
		// (set) Token: 0x0602C122 RID: 180514 RVA: 0x00A93FF5 File Offset: 0x00A921F5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_45) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_45 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F8 RID: 30200
		// (get) Token: 0x0602C123 RID: 180515 RVA: 0x00A94018 File Offset: 0x00A92218
		// (set) Token: 0x0602C124 RID: 180516 RVA: 0x00A94051 File Offset: 0x00A92251
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_24) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_24 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075F9 RID: 30201
		// (get) Token: 0x0602C125 RID: 180517 RVA: 0x00A94074 File Offset: 0x00A92274
		// (set) Token: 0x0602C126 RID: 180518 RVA: 0x00A940AD File Offset: 0x00A922AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_31) == null)
				{
					result = (this._AnimGraphNode_StateResult_31 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075FA RID: 30202
		// (get) Token: 0x0602C127 RID: 180519 RVA: 0x00A940D0 File Offset: 0x00A922D0
		// (set) Token: 0x0602C128 RID: 180520 RVA: 0x00A94109 File Offset: 0x00A92309
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_23) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_23 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075FB RID: 30203
		// (get) Token: 0x0602C129 RID: 180521 RVA: 0x00A9412C File Offset: 0x00A9232C
		// (set) Token: 0x0602C12A RID: 180522 RVA: 0x00A94165 File Offset: 0x00A92365
		public FAnimNode_StateResult AnimGraphNode_StateResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_30) == null)
				{
					result = (this._AnimGraphNode_StateResult_30 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075FC RID: 30204
		// (get) Token: 0x0602C12B RID: 180523 RVA: 0x00A94188 File Offset: 0x00A92388
		// (set) Token: 0x0602C12C RID: 180524 RVA: 0x00A941C1 File Offset: 0x00A923C1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_22) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_22 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075FD RID: 30205
		// (get) Token: 0x0602C12D RID: 180525 RVA: 0x00A941E4 File Offset: 0x00A923E4
		// (set) Token: 0x0602C12E RID: 180526 RVA: 0x00A9421D File Offset: 0x00A9241D
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075FE RID: 30206
		// (get) Token: 0x0602C12F RID: 180527 RVA: 0x00A94240 File Offset: 0x00A92440
		// (set) Token: 0x0602C130 RID: 180528 RVA: 0x00A94279 File Offset: 0x00A92479
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_21) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_21 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170075FF RID: 30207
		// (get) Token: 0x0602C131 RID: 180529 RVA: 0x00A9429C File Offset: 0x00A9249C
		// (set) Token: 0x0602C132 RID: 180530 RVA: 0x00A942D5 File Offset: 0x00A924D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007600 RID: 30208
		// (get) Token: 0x0602C133 RID: 180531 RVA: 0x00A942F8 File Offset: 0x00A924F8
		// (set) Token: 0x0602C134 RID: 180532 RVA: 0x00A94331 File Offset: 0x00A92531
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_20) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_20 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007601 RID: 30209
		// (get) Token: 0x0602C135 RID: 180533 RVA: 0x00A94354 File Offset: 0x00A92554
		// (set) Token: 0x0602C136 RID: 180534 RVA: 0x00A9438D File Offset: 0x00A9258D
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007602 RID: 30210
		// (get) Token: 0x0602C137 RID: 180535 RVA: 0x00A943B0 File Offset: 0x00A925B0
		// (set) Token: 0x0602C138 RID: 180536 RVA: 0x00A943E9 File Offset: 0x00A925E9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_19) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_19 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007603 RID: 30211
		// (get) Token: 0x0602C139 RID: 180537 RVA: 0x00A9440C File Offset: 0x00A9260C
		// (set) Token: 0x0602C13A RID: 180538 RVA: 0x00A94445 File Offset: 0x00A92645
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007604 RID: 30212
		// (get) Token: 0x0602C13B RID: 180539 RVA: 0x00A94468 File Offset: 0x00A92668
		// (set) Token: 0x0602C13C RID: 180540 RVA: 0x00A944A1 File Offset: 0x00A926A1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_18) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_18 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007605 RID: 30213
		// (get) Token: 0x0602C13D RID: 180541 RVA: 0x00A944C4 File Offset: 0x00A926C4
		// (set) Token: 0x0602C13E RID: 180542 RVA: 0x00A944FD File Offset: 0x00A926FD
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007606 RID: 30214
		// (get) Token: 0x0602C13F RID: 180543 RVA: 0x00A94520 File Offset: 0x00A92720
		// (set) Token: 0x0602C140 RID: 180544 RVA: 0x00A94559 File Offset: 0x00A92759
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007607 RID: 30215
		// (get) Token: 0x0602C141 RID: 180545 RVA: 0x00A9457C File Offset: 0x00A9277C
		// (set) Token: 0x0602C142 RID: 180546 RVA: 0x00A945B5 File Offset: 0x00A927B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_44) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_44 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007608 RID: 30216
		// (get) Token: 0x0602C143 RID: 180547 RVA: 0x00A945D8 File Offset: 0x00A927D8
		// (set) Token: 0x0602C144 RID: 180548 RVA: 0x00A94611 File Offset: 0x00A92811
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_43) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_43 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007609 RID: 30217
		// (get) Token: 0x0602C145 RID: 180549 RVA: 0x00A94634 File Offset: 0x00A92834
		// (set) Token: 0x0602C146 RID: 180550 RVA: 0x00A9466D File Offset: 0x00A9286D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_42) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_42 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700760A RID: 30218
		// (get) Token: 0x0602C147 RID: 180551 RVA: 0x00A94690 File Offset: 0x00A92890
		// (set) Token: 0x0602C148 RID: 180552 RVA: 0x00A946C9 File Offset: 0x00A928C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_41) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_41 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700760B RID: 30219
		// (get) Token: 0x0602C149 RID: 180553 RVA: 0x00A946EC File Offset: 0x00A928EC
		// (set) Token: 0x0602C14A RID: 180554 RVA: 0x00A94725 File Offset: 0x00A92925
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_40) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_40 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700760C RID: 30220
		// (get) Token: 0x0602C14B RID: 180555 RVA: 0x00A94748 File Offset: 0x00A92948
		// (set) Token: 0x0602C14C RID: 180556 RVA: 0x00A94781 File Offset: 0x00A92981
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_39) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_39 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700760D RID: 30221
		// (get) Token: 0x0602C14D RID: 180557 RVA: 0x00A947A4 File Offset: 0x00A929A4
		// (set) Token: 0x0602C14E RID: 180558 RVA: 0x00A947DD File Offset: 0x00A929DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_38) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_38 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700760E RID: 30222
		// (get) Token: 0x0602C14F RID: 180559 RVA: 0x00A94800 File Offset: 0x00A92A00
		// (set) Token: 0x0602C150 RID: 180560 RVA: 0x00A94839 File Offset: 0x00A92A39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_37) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_37 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700760F RID: 30223
		// (get) Token: 0x0602C151 RID: 180561 RVA: 0x00A9485C File Offset: 0x00A92A5C
		// (set) Token: 0x0602C152 RID: 180562 RVA: 0x00A94895 File Offset: 0x00A92A95
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_36) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_36 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007610 RID: 30224
		// (get) Token: 0x0602C153 RID: 180563 RVA: 0x00A948B8 File Offset: 0x00A92AB8
		// (set) Token: 0x0602C154 RID: 180564 RVA: 0x00A948F1 File Offset: 0x00A92AF1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_35) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_35 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007611 RID: 30225
		// (get) Token: 0x0602C155 RID: 180565 RVA: 0x00A94914 File Offset: 0x00A92B14
		// (set) Token: 0x0602C156 RID: 180566 RVA: 0x00A9494D File Offset: 0x00A92B4D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_34) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_34 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007612 RID: 30226
		// (get) Token: 0x0602C157 RID: 180567 RVA: 0x00A94970 File Offset: 0x00A92B70
		// (set) Token: 0x0602C158 RID: 180568 RVA: 0x00A949A9 File Offset: 0x00A92BA9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007613 RID: 30227
		// (get) Token: 0x0602C159 RID: 180569 RVA: 0x00A949CC File Offset: 0x00A92BCC
		// (set) Token: 0x0602C15A RID: 180570 RVA: 0x00A94A05 File Offset: 0x00A92C05
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007614 RID: 30228
		// (get) Token: 0x0602C15B RID: 180571 RVA: 0x00A94A28 File Offset: 0x00A92C28
		// (set) Token: 0x0602C15C RID: 180572 RVA: 0x00A94A61 File Offset: 0x00A92C61
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007615 RID: 30229
		// (get) Token: 0x0602C15D RID: 180573 RVA: 0x00A94A84 File Offset: 0x00A92C84
		// (set) Token: 0x0602C15E RID: 180574 RVA: 0x00A94ABD File Offset: 0x00A92CBD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007616 RID: 30230
		// (get) Token: 0x0602C15F RID: 180575 RVA: 0x00A94AE0 File Offset: 0x00A92CE0
		// (set) Token: 0x0602C160 RID: 180576 RVA: 0x00A94B19 File Offset: 0x00A92D19
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007617 RID: 30231
		// (get) Token: 0x0602C161 RID: 180577 RVA: 0x00A94B3C File Offset: 0x00A92D3C
		// (set) Token: 0x0602C162 RID: 180578 RVA: 0x00A94B75 File Offset: 0x00A92D75
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007618 RID: 30232
		// (get) Token: 0x0602C163 RID: 180579 RVA: 0x00A94B98 File Offset: 0x00A92D98
		// (set) Token: 0x0602C164 RID: 180580 RVA: 0x00A94BD1 File Offset: 0x00A92DD1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007619 RID: 30233
		// (get) Token: 0x0602C165 RID: 180581 RVA: 0x00A94BF4 File Offset: 0x00A92DF4
		// (set) Token: 0x0602C166 RID: 180582 RVA: 0x00A94C2D File Offset: 0x00A92E2D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700761A RID: 30234
		// (get) Token: 0x0602C167 RID: 180583 RVA: 0x00A94C50 File Offset: 0x00A92E50
		// (set) Token: 0x0602C168 RID: 180584 RVA: 0x00A94C89 File Offset: 0x00A92E89
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_17) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_17 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700761B RID: 30235
		// (get) Token: 0x0602C169 RID: 180585 RVA: 0x00A94CAC File Offset: 0x00A92EAC
		// (set) Token: 0x0602C16A RID: 180586 RVA: 0x00A94CE5 File Offset: 0x00A92EE5
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700761C RID: 30236
		// (get) Token: 0x0602C16B RID: 180587 RVA: 0x00A94D08 File Offset: 0x00A92F08
		// (set) Token: 0x0602C16C RID: 180588 RVA: 0x00A94D41 File Offset: 0x00A92F41
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_1) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_1 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700761D RID: 30237
		// (get) Token: 0x0602C16D RID: 180589 RVA: 0x00A94D64 File Offset: 0x00A92F64
		// (set) Token: 0x0602C16E RID: 180590 RVA: 0x00A94D9D File Offset: 0x00A92F9D
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700761E RID: 30238
		// (get) Token: 0x0602C16F RID: 180591 RVA: 0x00A94DC0 File Offset: 0x00A92FC0
		// (set) Token: 0x0602C170 RID: 180592 RVA: 0x00A94DF9 File Offset: 0x00A92FF9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_16) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_16 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700761F RID: 30239
		// (get) Token: 0x0602C171 RID: 180593 RVA: 0x00A94E1C File Offset: 0x00A9301C
		// (set) Token: 0x0602C172 RID: 180594 RVA: 0x00A94E55 File Offset: 0x00A93055
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007620 RID: 30240
		// (get) Token: 0x0602C173 RID: 180595 RVA: 0x00A94E78 File Offset: 0x00A93078
		// (set) Token: 0x0602C174 RID: 180596 RVA: 0x00A94EB1 File Offset: 0x00A930B1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_15) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_15 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007621 RID: 30241
		// (get) Token: 0x0602C175 RID: 180597 RVA: 0x00A94ED4 File Offset: 0x00A930D4
		// (set) Token: 0x0602C176 RID: 180598 RVA: 0x00A94F0D File Offset: 0x00A9310D
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007622 RID: 30242
		// (get) Token: 0x0602C177 RID: 180599 RVA: 0x00A94F30 File Offset: 0x00A93130
		// (set) Token: 0x0602C178 RID: 180600 RVA: 0x00A94F69 File Offset: 0x00A93169
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007623 RID: 30243
		// (get) Token: 0x0602C179 RID: 180601 RVA: 0x00A94F8C File Offset: 0x00A9318C
		// (set) Token: 0x0602C17A RID: 180602 RVA: 0x00A94FC5 File Offset: 0x00A931C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007624 RID: 30244
		// (get) Token: 0x0602C17B RID: 180603 RVA: 0x00A94FE8 File Offset: 0x00A931E8
		// (set) Token: 0x0602C17C RID: 180604 RVA: 0x00A95021 File Offset: 0x00A93221
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007625 RID: 30245
		// (get) Token: 0x0602C17D RID: 180605 RVA: 0x00A95044 File Offset: 0x00A93244
		// (set) Token: 0x0602C17E RID: 180606 RVA: 0x00A9507D File Offset: 0x00A9327D
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007626 RID: 30246
		// (get) Token: 0x0602C17F RID: 180607 RVA: 0x00A950A0 File Offset: 0x00A932A0
		// (set) Token: 0x0602C180 RID: 180608 RVA: 0x00A950D9 File Offset: 0x00A932D9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007627 RID: 30247
		// (get) Token: 0x0602C181 RID: 180609 RVA: 0x00A950FC File Offset: 0x00A932FC
		// (set) Token: 0x0602C182 RID: 180610 RVA: 0x00A95135 File Offset: 0x00A93335
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007628 RID: 30248
		// (get) Token: 0x0602C183 RID: 180611 RVA: 0x00A95158 File Offset: 0x00A93358
		// (set) Token: 0x0602C184 RID: 180612 RVA: 0x00A95191 File Offset: 0x00A93391
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007629 RID: 30249
		// (get) Token: 0x0602C185 RID: 180613 RVA: 0x00A951B4 File Offset: 0x00A933B4
		// (set) Token: 0x0602C186 RID: 180614 RVA: 0x00A951ED File Offset: 0x00A933ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700762A RID: 30250
		// (get) Token: 0x0602C187 RID: 180615 RVA: 0x00A95210 File Offset: 0x00A93410
		// (set) Token: 0x0602C188 RID: 180616 RVA: 0x00A95249 File Offset: 0x00A93449
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700762B RID: 30251
		// (get) Token: 0x0602C189 RID: 180617 RVA: 0x00A9526C File Offset: 0x00A9346C
		// (set) Token: 0x0602C18A RID: 180618 RVA: 0x00A952A5 File Offset: 0x00A934A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700762C RID: 30252
		// (get) Token: 0x0602C18B RID: 180619 RVA: 0x00A952C8 File Offset: 0x00A934C8
		// (set) Token: 0x0602C18C RID: 180620 RVA: 0x00A95301 File Offset: 0x00A93501
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700762D RID: 30253
		// (get) Token: 0x0602C18D RID: 180621 RVA: 0x00A95324 File Offset: 0x00A93524
		// (set) Token: 0x0602C18E RID: 180622 RVA: 0x00A9535D File Offset: 0x00A9355D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700762E RID: 30254
		// (get) Token: 0x0602C18F RID: 180623 RVA: 0x00A95380 File Offset: 0x00A93580
		// (set) Token: 0x0602C190 RID: 180624 RVA: 0x00A953B9 File Offset: 0x00A935B9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700762F RID: 30255
		// (get) Token: 0x0602C191 RID: 180625 RVA: 0x00A953DC File Offset: 0x00A935DC
		// (set) Token: 0x0602C192 RID: 180626 RVA: 0x00A95415 File Offset: 0x00A93615
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007630 RID: 30256
		// (get) Token: 0x0602C193 RID: 180627 RVA: 0x00A95438 File Offset: 0x00A93638
		// (set) Token: 0x0602C194 RID: 180628 RVA: 0x00A95471 File Offset: 0x00A93671
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007631 RID: 30257
		// (get) Token: 0x0602C195 RID: 180629 RVA: 0x00A95494 File Offset: 0x00A93694
		// (set) Token: 0x0602C196 RID: 180630 RVA: 0x00A954CD File Offset: 0x00A936CD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007632 RID: 30258
		// (get) Token: 0x0602C197 RID: 180631 RVA: 0x00A954F0 File Offset: 0x00A936F0
		// (set) Token: 0x0602C198 RID: 180632 RVA: 0x00A95529 File Offset: 0x00A93729
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007633 RID: 30259
		// (get) Token: 0x0602C199 RID: 180633 RVA: 0x00A9554C File Offset: 0x00A9374C
		// (set) Token: 0x0602C19A RID: 180634 RVA: 0x00A95585 File Offset: 0x00A93785
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007634 RID: 30260
		// (get) Token: 0x0602C19B RID: 180635 RVA: 0x00A955A8 File Offset: 0x00A937A8
		// (set) Token: 0x0602C19C RID: 180636 RVA: 0x00A955E1 File Offset: 0x00A937E1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007635 RID: 30261
		// (get) Token: 0x0602C19D RID: 180637 RVA: 0x00A95604 File Offset: 0x00A93804
		// (set) Token: 0x0602C19E RID: 180638 RVA: 0x00A9563D File Offset: 0x00A9383D
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007636 RID: 30262
		// (get) Token: 0x0602C19F RID: 180639 RVA: 0x00A95660 File Offset: 0x00A93860
		// (set) Token: 0x0602C1A0 RID: 180640 RVA: 0x00A95699 File Offset: 0x00A93899
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007637 RID: 30263
		// (get) Token: 0x0602C1A1 RID: 180641 RVA: 0x00A956BC File Offset: 0x00A938BC
		// (set) Token: 0x0602C1A2 RID: 180642 RVA: 0x00A956F5 File Offset: 0x00A938F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007638 RID: 30264
		// (get) Token: 0x0602C1A3 RID: 180643 RVA: 0x00A95718 File Offset: 0x00A93918
		// (set) Token: 0x0602C1A4 RID: 180644 RVA: 0x00A95751 File Offset: 0x00A93951
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007639 RID: 30265
		// (get) Token: 0x0602C1A5 RID: 180645 RVA: 0x00A95774 File Offset: 0x00A93974
		// (set) Token: 0x0602C1A6 RID: 180646 RVA: 0x00A957AD File Offset: 0x00A939AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700763A RID: 30266
		// (get) Token: 0x0602C1A7 RID: 180647 RVA: 0x00A957D0 File Offset: 0x00A939D0
		// (set) Token: 0x0602C1A8 RID: 180648 RVA: 0x00A95809 File Offset: 0x00A93A09
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700763B RID: 30267
		// (get) Token: 0x0602C1A9 RID: 180649 RVA: 0x00A9582C File Offset: 0x00A93A2C
		// (set) Token: 0x0602C1AA RID: 180650 RVA: 0x00A95865 File Offset: 0x00A93A65
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700763C RID: 30268
		// (get) Token: 0x0602C1AB RID: 180651 RVA: 0x00A95888 File Offset: 0x00A93A88
		// (set) Token: 0x0602C1AC RID: 180652 RVA: 0x00A958C1 File Offset: 0x00A93AC1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700763D RID: 30269
		// (get) Token: 0x0602C1AD RID: 180653 RVA: 0x00A958E4 File Offset: 0x00A93AE4
		// (set) Token: 0x0602C1AE RID: 180654 RVA: 0x00A9591D File Offset: 0x00A93B1D
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700763E RID: 30270
		// (get) Token: 0x0602C1AF RID: 180655 RVA: 0x00A95940 File Offset: 0x00A93B40
		// (set) Token: 0x0602C1B0 RID: 180656 RVA: 0x00A95979 File Offset: 0x00A93B79
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700763F RID: 30271
		// (get) Token: 0x0602C1B1 RID: 180657 RVA: 0x00A9599C File Offset: 0x00A93B9C
		// (set) Token: 0x0602C1B2 RID: 180658 RVA: 0x00A959D5 File Offset: 0x00A93BD5
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007640 RID: 30272
		// (get) Token: 0x0602C1B3 RID: 180659 RVA: 0x00A959F8 File Offset: 0x00A93BF8
		// (set) Token: 0x0602C1B4 RID: 180660 RVA: 0x00A95A31 File Offset: 0x00A93C31
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007641 RID: 30273
		// (get) Token: 0x0602C1B5 RID: 180661 RVA: 0x00A95A54 File Offset: 0x00A93C54
		// (set) Token: 0x0602C1B6 RID: 180662 RVA: 0x00A95A8D File Offset: 0x00A93C8D
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007642 RID: 30274
		// (get) Token: 0x0602C1B7 RID: 180663 RVA: 0x00A95AB0 File Offset: 0x00A93CB0
		// (set) Token: 0x0602C1B8 RID: 180664 RVA: 0x00A95AE9 File Offset: 0x00A93CE9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007643 RID: 30275
		// (get) Token: 0x0602C1B9 RID: 180665 RVA: 0x00A95B0C File Offset: 0x00A93D0C
		// (set) Token: 0x0602C1BA RID: 180666 RVA: 0x00A95B45 File Offset: 0x00A93D45
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007644 RID: 30276
		// (get) Token: 0x0602C1BB RID: 180667 RVA: 0x00A95B68 File Offset: 0x00A93D68
		// (set) Token: 0x0602C1BC RID: 180668 RVA: 0x00A95BA1 File Offset: 0x00A93DA1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007645 RID: 30277
		// (get) Token: 0x0602C1BD RID: 180669 RVA: 0x00A95BC4 File Offset: 0x00A93DC4
		// (set) Token: 0x0602C1BE RID: 180670 RVA: 0x00A95BFD File Offset: 0x00A93DFD
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007646 RID: 30278
		// (get) Token: 0x0602C1BF RID: 180671 RVA: 0x00A95C20 File Offset: 0x00A93E20
		// (set) Token: 0x0602C1C0 RID: 180672 RVA: 0x00A95C59 File Offset: 0x00A93E59
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007647 RID: 30279
		// (get) Token: 0x0602C1C1 RID: 180673 RVA: 0x00A95C7C File Offset: 0x00A93E7C
		// (set) Token: 0x0602C1C2 RID: 180674 RVA: 0x00A95CB5 File Offset: 0x00A93EB5
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007648 RID: 30280
		// (get) Token: 0x0602C1C3 RID: 180675 RVA: 0x00A95CD8 File Offset: 0x00A93ED8
		// (set) Token: 0x0602C1C4 RID: 180676 RVA: 0x00A95D11 File Offset: 0x00A93F11
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007649 RID: 30281
		// (get) Token: 0x0602C1C5 RID: 180677 RVA: 0x00A95D34 File Offset: 0x00A93F34
		// (set) Token: 0x0602C1C6 RID: 180678 RVA: 0x00A95D6D File Offset: 0x00A93F6D
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700764A RID: 30282
		// (get) Token: 0x0602C1C7 RID: 180679 RVA: 0x00A95D90 File Offset: 0x00A93F90
		// (set) Token: 0x0602C1C8 RID: 180680 RVA: 0x00A95DC9 File Offset: 0x00A93FC9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_1 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700764B RID: 30283
		// (get) Token: 0x0602C1C9 RID: 180681 RVA: 0x00A95DEC File Offset: 0x00A93FEC
		// (set) Token: 0x0602C1CA RID: 180682 RVA: 0x00A95E25 File Offset: 0x00A94025
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700764C RID: 30284
		// (get) Token: 0x0602C1CB RID: 180683 RVA: 0x00A95E48 File Offset: 0x00A94048
		// (set) Token: 0x0602C1CC RID: 180684 RVA: 0x00A95E81 File Offset: 0x00A94081
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700764D RID: 30285
		// (get) Token: 0x0602C1CD RID: 180685 RVA: 0x00A95EA4 File Offset: 0x00A940A4
		// (set) Token: 0x0602C1CE RID: 180686 RVA: 0x00A95EDD File Offset: 0x00A940DD
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_1 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700764E RID: 30286
		// (get) Token: 0x0602C1CF RID: 180687 RVA: 0x00A95F00 File Offset: 0x00A94100
		// (set) Token: 0x0602C1D0 RID: 180688 RVA: 0x00A95F39 File Offset: 0x00A94139
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700764F RID: 30287
		// (get) Token: 0x0602C1D1 RID: 180689 RVA: 0x00A95F5C File Offset: 0x00A9415C
		// (set) Token: 0x0602C1D2 RID: 180690 RVA: 0x00A95F95 File Offset: 0x00A94195
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007650 RID: 30288
		// (get) Token: 0x0602C1D3 RID: 180691 RVA: 0x00A95FB8 File Offset: 0x00A941B8
		// (set) Token: 0x0602C1D4 RID: 180692 RVA: 0x00A95FF1 File Offset: 0x00A941F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007651 RID: 30289
		// (get) Token: 0x0602C1D5 RID: 180693 RVA: 0x00A96014 File Offset: 0x00A94214
		// (set) Token: 0x0602C1D6 RID: 180694 RVA: 0x00A9604D File Offset: 0x00A9424D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007652 RID: 30290
		// (get) Token: 0x0602C1D7 RID: 180695 RVA: 0x00A96070 File Offset: 0x00A94270
		// (set) Token: 0x0602C1D8 RID: 180696 RVA: 0x00A960A9 File Offset: 0x00A942A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007653 RID: 30291
		// (get) Token: 0x0602C1D9 RID: 180697 RVA: 0x00A960CC File Offset: 0x00A942CC
		// (set) Token: 0x0602C1DA RID: 180698 RVA: 0x00A96105 File Offset: 0x00A94305
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007654 RID: 30292
		// (get) Token: 0x0602C1DB RID: 180699 RVA: 0x00A96128 File Offset: 0x00A94328
		// (set) Token: 0x0602C1DC RID: 180700 RVA: 0x00A96161 File Offset: 0x00A94361
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007655 RID: 30293
		// (get) Token: 0x0602C1DD RID: 180701 RVA: 0x00A96184 File Offset: 0x00A94384
		// (set) Token: 0x0602C1DE RID: 180702 RVA: 0x00A961BD File Offset: 0x00A943BD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007656 RID: 30294
		// (get) Token: 0x0602C1DF RID: 180703 RVA: 0x00A961E0 File Offset: 0x00A943E0
		// (set) Token: 0x0602C1E0 RID: 180704 RVA: 0x00A96219 File Offset: 0x00A94419
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007657 RID: 30295
		// (get) Token: 0x0602C1E1 RID: 180705 RVA: 0x00A9623C File Offset: 0x00A9443C
		// (set) Token: 0x0602C1E2 RID: 180706 RVA: 0x00A96275 File Offset: 0x00A94475
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007658 RID: 30296
		// (get) Token: 0x0602C1E3 RID: 180707 RVA: 0x00A96298 File Offset: 0x00A94498
		// (set) Token: 0x0602C1E4 RID: 180708 RVA: 0x00A962D1 File Offset: 0x00A944D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007659 RID: 30297
		// (get) Token: 0x0602C1E5 RID: 180709 RVA: 0x00A962F4 File Offset: 0x00A944F4
		// (set) Token: 0x0602C1E6 RID: 180710 RVA: 0x00A9632D File Offset: 0x00A9452D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700765A RID: 30298
		// (get) Token: 0x0602C1E7 RID: 180711 RVA: 0x00A96350 File Offset: 0x00A94550
		// (set) Token: 0x0602C1E8 RID: 180712 RVA: 0x00A96389 File Offset: 0x00A94589
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_115, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_115, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700765B RID: 30299
		// (get) Token: 0x0602C1E9 RID: 180713 RVA: 0x00A963AC File Offset: 0x00A945AC
		// (set) Token: 0x0602C1EA RID: 180714 RVA: 0x00A963E5 File Offset: 0x00A945E5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_116, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_116, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700765C RID: 30300
		// (get) Token: 0x0602C1EB RID: 180715 RVA: 0x00A96408 File Offset: 0x00A94608
		// (set) Token: 0x0602C1EC RID: 180716 RVA: 0x00A96441 File Offset: 0x00A94641
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_117, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_117, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700765D RID: 30301
		// (get) Token: 0x0602C1ED RID: 180717 RVA: 0x00A96464 File Offset: 0x00A94664
		// (set) Token: 0x0602C1EE RID: 180718 RVA: 0x00A9649D File Offset: 0x00A9469D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_118, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700765E RID: 30302
		// (get) Token: 0x0602C1EF RID: 180719 RVA: 0x00A964C0 File Offset: 0x00A946C0
		// (set) Token: 0x0602C1F0 RID: 180720 RVA: 0x00A964F9 File Offset: 0x00A946F9
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_119, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_119, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700765F RID: 30303
		// (get) Token: 0x0602C1F1 RID: 180721 RVA: 0x00A9651C File Offset: 0x00A9471C
		// (set) Token: 0x0602C1F2 RID: 180722 RVA: 0x00A96555 File Offset: 0x00A94755
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_120, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_120, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007660 RID: 30304
		// (get) Token: 0x0602C1F3 RID: 180723 RVA: 0x00A96578 File Offset: 0x00A94778
		// (set) Token: 0x0602C1F4 RID: 180724 RVA: 0x00A965B1 File Offset: 0x00A947B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_121, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_121, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007661 RID: 30305
		// (get) Token: 0x0602C1F5 RID: 180725 RVA: 0x00A965D4 File Offset: 0x00A947D4
		// (set) Token: 0x0602C1F6 RID: 180726 RVA: 0x00A9660D File Offset: 0x00A9480D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_122, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_122, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007662 RID: 30306
		// (get) Token: 0x0602C1F7 RID: 180727 RVA: 0x00A96630 File Offset: 0x00A94830
		// (set) Token: 0x0602C1F8 RID: 180728 RVA: 0x00A96669 File Offset: 0x00A94869
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_123, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_123, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007663 RID: 30307
		// (get) Token: 0x0602C1F9 RID: 180729 RVA: 0x00A9668C File Offset: 0x00A9488C
		// (set) Token: 0x0602C1FA RID: 180730 RVA: 0x00A966C5 File Offset: 0x00A948C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_124, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_124, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007664 RID: 30308
		// (get) Token: 0x0602C1FB RID: 180731 RVA: 0x00A966E8 File Offset: 0x00A948E8
		// (set) Token: 0x0602C1FC RID: 180732 RVA: 0x00A96721 File Offset: 0x00A94921
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_125, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_125, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007665 RID: 30309
		// (get) Token: 0x0602C1FD RID: 180733 RVA: 0x00A96744 File Offset: 0x00A94944
		// (set) Token: 0x0602C1FE RID: 180734 RVA: 0x00A9677D File Offset: 0x00A9497D
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_126, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_126, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007666 RID: 30310
		// (get) Token: 0x0602C1FF RID: 180735 RVA: 0x00A967A0 File Offset: 0x00A949A0
		// (set) Token: 0x0602C200 RID: 180736 RVA: 0x00A967D9 File Offset: 0x00A949D9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_127, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_127, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007667 RID: 30311
		// (get) Token: 0x0602C201 RID: 180737 RVA: 0x00A967FC File Offset: 0x00A949FC
		// (set) Token: 0x0602C202 RID: 180738 RVA: 0x00A96835 File Offset: 0x00A94A35
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_128, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007668 RID: 30312
		// (get) Token: 0x0602C203 RID: 180739 RVA: 0x00A96858 File Offset: 0x00A94A58
		// (set) Token: 0x0602C204 RID: 180740 RVA: 0x00A96891 File Offset: 0x00A94A91
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_129, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_129, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007669 RID: 30313
		// (get) Token: 0x0602C205 RID: 180741 RVA: 0x00A968B4 File Offset: 0x00A94AB4
		// (set) Token: 0x0602C206 RID: 180742 RVA: 0x00A968ED File Offset: 0x00A94AED
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_130, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_130, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700766A RID: 30314
		// (get) Token: 0x0602C207 RID: 180743 RVA: 0x00A96910 File Offset: 0x00A94B10
		// (set) Token: 0x0602C208 RID: 180744 RVA: 0x00A96949 File Offset: 0x00A94B49
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_131, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_131, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700766B RID: 30315
		// (get) Token: 0x0602C209 RID: 180745 RVA: 0x00A9696C File Offset: 0x00A94B6C
		// (set) Token: 0x0602C20A RID: 180746 RVA: 0x00A969A5 File Offset: 0x00A94BA5
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_132, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_132, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700766C RID: 30316
		// (get) Token: 0x0602C20B RID: 180747 RVA: 0x00A969C8 File Offset: 0x00A94BC8
		// (set) Token: 0x0602C20C RID: 180748 RVA: 0x00A96A01 File Offset: 0x00A94C01
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_133, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_133, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700766D RID: 30317
		// (get) Token: 0x0602C20D RID: 180749 RVA: 0x00A96A24 File Offset: 0x00A94C24
		// (set) Token: 0x0602C20E RID: 180750 RVA: 0x00A96A5D File Offset: 0x00A94C5D
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_2) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_2 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_134, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_134, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700766E RID: 30318
		// (get) Token: 0x0602C20F RID: 180751 RVA: 0x00A96A80 File Offset: 0x00A94C80
		// (set) Token: 0x0602C210 RID: 180752 RVA: 0x00A96AB9 File Offset: 0x00A94CB9
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_135, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_135, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700766F RID: 30319
		// (get) Token: 0x0602C211 RID: 180753 RVA: 0x00A96ADC File Offset: 0x00A94CDC
		// (set) Token: 0x0602C212 RID: 180754 RVA: 0x00A96B15 File Offset: 0x00A94D15
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_136, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_136, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007670 RID: 30320
		// (get) Token: 0x0602C213 RID: 180755 RVA: 0x00A96B38 File Offset: 0x00A94D38
		// (set) Token: 0x0602C214 RID: 180756 RVA: 0x00A96B71 File Offset: 0x00A94D71
		public TArray<UAnimSequence> 待机表演配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimSequence> result;
				if ((result = this._待机表演配置) == null)
				{
					result = (this._待机表演配置 = new TArray<UAnimSequence>(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_137, this));
				}
				return result;
			}
			set
			{
				this.待机表演配置.CopyAssign(value);
			}
		}

		// Token: 0x17007671 RID: 30321
		// (get) Token: 0x0602C215 RID: 180757 RVA: 0x00A96B7F File Offset: 0x00A94D7F
		// (set) Token: 0x0602C216 RID: 180758 RVA: 0x00A96B93 File Offset: 0x00A94D93
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_138);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_138, value);
			}
		}

		// Token: 0x17007672 RID: 30322
		// (get) Token: 0x0602C217 RID: 180759 RVA: 0x00A96BA8 File Offset: 0x00A94DA8
		// (set) Token: 0x0602C218 RID: 180760 RVA: 0x00A96BBC File Offset: 0x00A94DBC
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色网格体
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_139);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_139, value);
			}
		}

		// Token: 0x17007673 RID: 30323
		// (get) Token: 0x0602C219 RID: 180761 RVA: 0x00A96BD1 File Offset: 0x00A94DD1
		// (set) Token: 0x0602C21A RID: 180762 RVA: 0x00A96BE5 File Offset: 0x00A94DE5
		[Nullable(0)]
		public unsafe TEnumAsByte<EAnimalEcologicalState> 生态表现状态
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_140);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_140) = value;
			}
		}

		// Token: 0x17007674 RID: 30324
		// (get) Token: 0x0602C21B RID: 180763 RVA: 0x00A96BFA File Offset: 0x00A94DFA
		// (set) Token: 0x0602C21C RID: 180764 RVA: 0x00A96C0A File Offset: 0x00A94E0A
		public unsafe bool 状态机初始化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_141) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_141) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007675 RID: 30325
		// (get) Token: 0x0602C21D RID: 180765 RVA: 0x00A96C1B File Offset: 0x00A94E1B
		// (set) Token: 0x0602C21E RID: 180766 RVA: 0x00A96C2B File Offset: 0x00A94E2B
		public unsafe int IdleActionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_142);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_142) = value;
			}
		}

		// Token: 0x17007676 RID: 30326
		// (get) Token: 0x0602C21F RID: 180767 RVA: 0x00A96C3C File Offset: 0x00A94E3C
		// (set) Token: 0x0602C220 RID: 180768 RVA: 0x00A96C50 File Offset: 0x00A94E50
		[Nullable(2)]
		public unsafe UAnimSequence IdleAnim
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_143);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_143, value);
			}
		}

		// Token: 0x17007677 RID: 30327
		// (get) Token: 0x0602C221 RID: 180769 RVA: 0x00A96C68 File Offset: 0x00A94E68
		// (set) Token: 0x0602C222 RID: 180770 RVA: 0x00A96CA1 File Offset: 0x00A94EA1
		public TArray<UAnimSequence> 交互表演配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimSequence> result;
				if ((result = this._交互表演配置) == null)
				{
					result = (this._交互表演配置 = new TArray<UAnimSequence>(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_144, this));
				}
				return result;
			}
			set
			{
				this.交互表演配置.CopyAssign(value);
			}
		}

		// Token: 0x17007678 RID: 30328
		// (get) Token: 0x0602C223 RID: 180771 RVA: 0x00A96CAF File Offset: 0x00A94EAF
		// (set) Token: 0x0602C224 RID: 180772 RVA: 0x00A96CBF File Offset: 0x00A94EBF
		public unsafe int InteractActionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_145);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_145) = value;
			}
		}

		// Token: 0x17007679 RID: 30329
		// (get) Token: 0x0602C225 RID: 180773 RVA: 0x00A96CD0 File Offset: 0x00A94ED0
		// (set) Token: 0x0602C226 RID: 180774 RVA: 0x00A96CE4 File Offset: 0x00A94EE4
		[Nullable(2)]
		public unsafe UAnimSequence InteractAnim
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_146);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseAnimal_C.__PropertyOffset_146, value);
			}
		}

		// Token: 0x1700767A RID: 30330
		// (get) Token: 0x0602C227 RID: 180775 RVA: 0x00A96CF9 File Offset: 0x00A94EF9
		// (set) Token: 0x0602C228 RID: 180776 RVA: 0x00A96D0D File Offset: 0x00A94F0D
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_147);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_147) = value;
			}
		}

		// Token: 0x1700767B RID: 30331
		// (get) Token: 0x0602C229 RID: 180777 RVA: 0x00A96D22 File Offset: 0x00A94F22
		// (set) Token: 0x0602C22A RID: 180778 RVA: 0x00A96D32 File Offset: 0x00A94F32
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_148));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_148) = (byte)value;
			}
		}

		// Token: 0x1700767C RID: 30332
		// (get) Token: 0x0602C22B RID: 180779 RVA: 0x00A96D43 File Offset: 0x00A94F43
		// (set) Token: 0x0602C22C RID: 180780 RVA: 0x00A96D53 File Offset: 0x00A94F53
		public unsafe int WalkRunParam
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_149);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_149) = value;
			}
		}

		// Token: 0x1700767D RID: 30333
		// (get) Token: 0x0602C22D RID: 180781 RVA: 0x00A96D64 File Offset: 0x00A94F64
		// (set) Token: 0x0602C22E RID: 180782 RVA: 0x00A96D74 File Offset: 0x00A94F74
		public unsafe float 左右跑参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_150);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_150) = value;
			}
		}

		// Token: 0x1700767E RID: 30334
		// (get) Token: 0x0602C22F RID: 180783 RVA: 0x00A96D85 File Offset: 0x00A94F85
		// (set) Token: 0x0602C230 RID: 180784 RVA: 0x00A96D95 File Offset: 0x00A94F95
		public unsafe bool bHaveInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_151) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_151) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700767F RID: 30335
		// (get) Token: 0x0602C231 RID: 180785 RVA: 0x00A96DA6 File Offset: 0x00A94FA6
		// (set) Token: 0x0602C232 RID: 180786 RVA: 0x00A96DB6 File Offset: 0x00A94FB6
		public unsafe bool bIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_152) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_152) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007680 RID: 30336
		// (get) Token: 0x0602C233 RID: 180787 RVA: 0x00A96DC7 File Offset: 0x00A94FC7
		// (set) Token: 0x0602C234 RID: 180788 RVA: 0x00A96DD7 File Offset: 0x00A94FD7
		public unsafe bool 是否警觉
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_153) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_153) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007681 RID: 30337
		// (get) Token: 0x0602C235 RID: 180789 RVA: 0x00A96DE8 File Offset: 0x00A94FE8
		// (set) Token: 0x0602C236 RID: 180790 RVA: 0x00A96DF8 File Offset: 0x00A94FF8
		public unsafe bool 是否起跑转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_154) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_154) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007682 RID: 30338
		// (get) Token: 0x0602C237 RID: 180791 RVA: 0x00A96E09 File Offset: 0x00A95009
		// (set) Token: 0x0602C238 RID: 180792 RVA: 0x00A96E19 File Offset: 0x00A95019
		public unsafe bool 起跑左转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_155) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_155) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007683 RID: 30339
		// (get) Token: 0x0602C239 RID: 180793 RVA: 0x00A96E2A File Offset: 0x00A9502A
		// (set) Token: 0x0602C23A RID: 180794 RVA: 0x00A96E3A File Offset: 0x00A9503A
		public unsafe bool bInteractAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_156) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_156) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007684 RID: 30340
		// (get) Token: 0x0602C23B RID: 180795 RVA: 0x00A96E4B File Offset: 0x00A9504B
		// (set) Token: 0x0602C23C RID: 180796 RVA: 0x00A96E5B File Offset: 0x00A9505B
		public unsafe bool 受到攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_157) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_157) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007685 RID: 30341
		// (get) Token: 0x0602C23D RID: 180797 RVA: 0x00A96E6C File Offset: 0x00A9506C
		// (set) Token: 0x0602C23E RID: 180798 RVA: 0x00A96E7C File Offset: 0x00A9507C
		public unsafe bool 起飞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_158) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_158) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007686 RID: 30342
		// (get) Token: 0x0602C23F RID: 180799 RVA: 0x00A96E8D File Offset: 0x00A9508D
		// (set) Token: 0x0602C240 RID: 180800 RVA: 0x00A96E9D File Offset: 0x00A9509D
		public unsafe bool bSitDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_159) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_159) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007687 RID: 30343
		// (get) Token: 0x0602C241 RID: 180801 RVA: 0x00A96EB0 File Offset: 0x00A950B0
		// (set) Token: 0x0602C242 RID: 180802 RVA: 0x00A96EE9 File Offset: 0x00A950E9
		public TMap<FGameplayTag, UAnimSequence> 其他动作配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, UAnimSequence> result;
				if ((result = this._其他动作配置) == null)
				{
					result = (this._其他动作配置 = new TMap<FGameplayTag, UAnimSequence>(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_160, this));
				}
				return result;
			}
			set
			{
				this.其他动作配置.CopyAssign(value);
			}
		}

		// Token: 0x17007688 RID: 30344
		// (get) Token: 0x0602C243 RID: 180803 RVA: 0x00A96EF7 File Offset: 0x00A950F7
		// (set) Token: 0x0602C244 RID: 180804 RVA: 0x00A96F07 File Offset: 0x00A95107
		public unsafe float ActionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_161);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_161) = value;
			}
		}

		// Token: 0x17007689 RID: 30345
		// (get) Token: 0x0602C245 RID: 180805 RVA: 0x00A96F18 File Offset: 0x00A95118
		// (set) Token: 0x0602C246 RID: 180806 RVA: 0x00A96F51 File Offset: 0x00A95151
		public TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> 材质配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> result;
				if ((result = this._材质配置) == null)
				{
					result = (this._材质配置 = new TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>>(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_162, this));
				}
				return result;
			}
			set
			{
				this.材质配置.CopyAssign(value);
			}
		}

		// Token: 0x1700768A RID: 30346
		// (get) Token: 0x0602C247 RID: 180807 RVA: 0x00A96F60 File Offset: 0x00A95160
		// (set) Token: 0x0602C248 RID: 180808 RVA: 0x00A96F99 File Offset: 0x00A95199
		public TMap<FGameplayTag, UAnimMontage> 蒙太奇表演配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, UAnimMontage> result;
				if ((result = this._蒙太奇表演配置) == null)
				{
					result = (this._蒙太奇表演配置 = new TMap<FGameplayTag, UAnimMontage>(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_163, this));
				}
				return result;
			}
			set
			{
				this.蒙太奇表演配置.CopyAssign(value);
			}
		}

		// Token: 0x1700768B RID: 30347
		// (get) Token: 0x0602C249 RID: 180809 RVA: 0x00A96FA7 File Offset: 0x00A951A7
		// (set) Token: 0x0602C24A RID: 180810 RVA: 0x00A96FB7 File Offset: 0x00A951B7
		public unsafe bool 支持急转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_164) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_164) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700768C RID: 30348
		// (get) Token: 0x0602C24B RID: 180811 RVA: 0x00A96FC8 File Offset: 0x00A951C8
		// (set) Token: 0x0602C24C RID: 180812 RVA: 0x00A96FD8 File Offset: 0x00A951D8
		public unsafe bool 系统UI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_165) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_165) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700768D RID: 30349
		// (get) Token: 0x0602C24D RID: 180813 RVA: 0x00A96FE9 File Offset: 0x00A951E9
		// (set) Token: 0x0602C24E RID: 180814 RVA: 0x00A96FF9 File Offset: 0x00A951F9
		public unsafe bool bGetDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_166) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseAnimal_C.__PropertyOffset_166) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602C24F RID: 180815 RVA: 0x00A9700C File Offset: 0x00A9520C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurrentActionTime(ref float ActionTime)
		{
			ABP_BaseAnimal_C.__GetCurrentActionTime_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__GetCurrentActionTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseAnimal_C.__GetCurrentActionTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__GetCurrentActionTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ActionTime = ActionTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__GetCurrentActionTime_NativeFunctionPtr, (void*)ptr);
			ActionTime = ptr->ActionTime;
		}

		// Token: 0x0602C250 RID: 180816 RVA: 0x00A9705C File Offset: 0x00A9525C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 演出层(FPoseLink 状态机输入, ref FPoseLink 演出层)
		{
			ABP_BaseAnimal_C.__演出层_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__演出层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseAnimal_C.__演出层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__演出层_NativeFunctionPtr, (void*)ptr, 1);
			if (状态机输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->状态机输入, 状态机输入.NativePtr, 1, false);
			}
			if (演出层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->演出层, 演出层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__演出层_NativeFunctionPtr, (void*)ptr);
			if (演出层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 演出层.NativePtr, &ptr->演出层, 1, false);
			}
		}

		// Token: 0x0602C251 RID: 180817 RVA: 0x00A97108 File Offset: 0x00A95308
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 后处理层(FPoseLink 基础输入, ref FPoseLink 后处理层)
		{
			ABP_BaseAnimal_C.__后处理层_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__后处理层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseAnimal_C.__后处理层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__后处理层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础输入, 基础输入.NativePtr, 1, false);
			}
			if (后处理层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->后处理层, 后处理层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__后处理层_NativeFunctionPtr, (void*)ptr);
			if (后处理层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 后处理层.NativePtr, &ptr->后处理层, 1, false);
			}
		}

		// Token: 0x0602C252 RID: 180818 RVA: 0x00A971B4 File Offset: 0x00A953B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_BaseAnimal_C.__基础层_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseAnimal_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C253 RID: 180819 RVA: 0x00A9723C File Offset: 0x00A9543C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseAnimal_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseAnimal_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C254 RID: 180820 RVA: 0x00A972C3 File Offset: 0x00A954C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnSystemUIStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnSystemUIStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C255 RID: 180821 RVA: 0x00A972D8 File Offset: 0x00A954D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnFeedStart(FGameplayTag GameplayTag)
		{
			ABP_BaseAnimal_C.__OnFeedStart_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__OnFeedStart_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(ABP_BaseAnimal_C.__OnFeedStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__OnFeedStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayTag = GameplayTag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnFeedStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C256 RID: 180822 RVA: 0x00A9731E File Offset: 0x00A9551E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新移动信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__更新移动信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602C257 RID: 180823 RVA: 0x00A97332 File Offset: 0x00A95532
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 处理动作优先级()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__处理动作优先级_NativeFunctionPtr, null);
		}

		// Token: 0x0602C258 RID: 180824 RVA: 0x00A97346 File Offset: 0x00A95546
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnUnderAttackStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnUnderAttackStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C259 RID: 180825 RVA: 0x00A9735A File Offset: 0x00A9555A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTakeOffStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnTakeOffStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C25A RID: 180826 RVA: 0x00A9736E File Offset: 0x00A9556E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnAlertStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnAlertStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C25B RID: 180827 RVA: 0x00A97382 File Offset: 0x00A95582
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602C25C RID: 180828 RVA: 0x00A97396 File Offset: 0x00A95596
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInteractStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnInteractStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C25D RID: 180829 RVA: 0x00A973AA File Offset: 0x00A955AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新特殊交互表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__更新特殊交互表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602C25E RID: 180830 RVA: 0x00A973BE File Offset: 0x00A955BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新交互表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__更新交互表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602C25F RID: 180831 RVA: 0x00A973D2 File Offset: 0x00A955D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnIdleStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__OnIdleStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C260 RID: 180832 RVA: 0x00A973E6 File Offset: 0x00A955E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新待机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__更新待机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602C261 RID: 180833 RVA: 0x00A973FA File Offset: 0x00A955FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AlertEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AlertEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C262 RID: 180834 RVA: 0x00A9740E File Offset: 0x00A9560E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TakeOffEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__TakeOffEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C263 RID: 180835 RVA: 0x00A97422 File Offset: 0x00A95622
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnderAttackEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__UnderAttackEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C264 RID: 180836 RVA: 0x00A97436 File Offset: 0x00A95636
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void IdleEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__IdleEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C265 RID: 180837 RVA: 0x00A9744A File Offset: 0x00A9564A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InteractEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__InteractEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C266 RID: 180838 RVA: 0x00A9745E File Offset: 0x00A9565E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NoneStateEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__NoneStateEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C267 RID: 180839 RVA: 0x00A97472 File Offset: 0x00A95672
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_6708632043AE1764C2B1A2BC8487CAA2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_6708632043AE1764C2B1A2BC8487CAA2_NativeFunctionPtr, null);
		}

		// Token: 0x0602C268 RID: 180840 RVA: 0x00A97486 File Offset: 0x00A95686
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_E971F2414D8A609D52454EBD86A29DDE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_E971F2414D8A609D52454EBD86A29DDE_NativeFunctionPtr, null);
		}

		// Token: 0x0602C269 RID: 180841 RVA: 0x00A9749A File Offset: 0x00A9569A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_D76347B84F84143110867F87A063BC9A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_D76347B84F84143110867F87A063BC9A_NativeFunctionPtr, null);
		}

		// Token: 0x0602C26A RID: 180842 RVA: 0x00A974AE File Offset: 0x00A956AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_F2118EA4482961323A4284A5C757A6D4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_F2118EA4482961323A4284A5C757A6D4_NativeFunctionPtr, null);
		}

		// Token: 0x0602C26B RID: 180843 RVA: 0x00A974C2 File Offset: 0x00A956C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_AEAB655045E3052DFA6C2EB97F6BAEE4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_AEAB655045E3052DFA6C2EB97F6BAEE4_NativeFunctionPtr, null);
		}

		// Token: 0x0602C26C RID: 180844 RVA: 0x00A974D6 File Offset: 0x00A956D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_49945F8B4DD298D2ED4AE0B5BD3BFF51()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_49945F8B4DD298D2ED4AE0B5BD3BFF51_NativeFunctionPtr, null);
		}

		// Token: 0x0602C26D RID: 180845 RVA: 0x00A974EA File Offset: 0x00A956EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_0A62643941C9F2534B1AF99C24980E2C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_0A62643941C9F2534B1AF99C24980E2C_NativeFunctionPtr, null);
		}

		// Token: 0x0602C26E RID: 180846 RVA: 0x00A974FE File Offset: 0x00A956FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1769F6104A02243DD5C6589592A29465()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1769F6104A02243DD5C6589592A29465_NativeFunctionPtr, null);
		}

		// Token: 0x0602C26F RID: 180847 RVA: 0x00A97512 File Offset: 0x00A95712
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_416429BC4584FF707D49B1BF83556BF2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_416429BC4584FF707D49B1BF83556BF2_NativeFunctionPtr, null);
		}

		// Token: 0x0602C270 RID: 180848 RVA: 0x00A97526 File Offset: 0x00A95726
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_764CCFAC4D41871FBC3DA79A1C2573AB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_764CCFAC4D41871FBC3DA79A1C2573AB_NativeFunctionPtr, null);
		}

		// Token: 0x0602C271 RID: 180849 RVA: 0x00A9753A File Offset: 0x00A9573A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_DBE786244F0BB91CD41D8289371D7030()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_DBE786244F0BB91CD41D8289371D7030_NativeFunctionPtr, null);
		}

		// Token: 0x0602C272 RID: 180850 RVA: 0x00A9754E File Offset: 0x00A9574E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_28773EEC4DFEA3865FF9E284E7CE5F47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_28773EEC4DFEA3865FF9E284E7CE5F47_NativeFunctionPtr, null);
		}

		// Token: 0x0602C273 RID: 180851 RVA: 0x00A97562 File Offset: 0x00A95762
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_3B0855934F908EBADF5C0E905BE5EBAD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_3B0855934F908EBADF5C0E905BE5EBAD_NativeFunctionPtr, null);
		}

		// Token: 0x0602C274 RID: 180852 RVA: 0x00A97576 File Offset: 0x00A95776
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_3C432C1A4EAC4B8EEC7FAA9810D7964C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_3C432C1A4EAC4B8EEC7FAA9810D7964C_NativeFunctionPtr, null);
		}

		// Token: 0x0602C275 RID: 180853 RVA: 0x00A9758A File Offset: 0x00A9578A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_437CDAF94B84EB0EA0350A81D62C1333()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_437CDAF94B84EB0EA0350A81D62C1333_NativeFunctionPtr, null);
		}

		// Token: 0x0602C276 RID: 180854 RVA: 0x00A9759E File Offset: 0x00A9579E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_9E2813C546DB12830090D0B49CAFCF8A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_9E2813C546DB12830090D0B49CAFCF8A_NativeFunctionPtr, null);
		}

		// Token: 0x0602C277 RID: 180855 RVA: 0x00A975B2 File Offset: 0x00A957B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_00AF891944077B505E5628A5880DB881()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_00AF891944077B505E5628A5880DB881_NativeFunctionPtr, null);
		}

		// Token: 0x0602C278 RID: 180856 RVA: 0x00A975C6 File Offset: 0x00A957C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_7DF62BD6494255C57AF1CA838DF2F699()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_7DF62BD6494255C57AF1CA838DF2F699_NativeFunctionPtr, null);
		}

		// Token: 0x0602C279 RID: 180857 RVA: 0x00A975DA File Offset: 0x00A957DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1FA99C764B6E9143E9A2EBBC467023D2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1FA99C764B6E9143E9A2EBBC467023D2_NativeFunctionPtr, null);
		}

		// Token: 0x0602C27A RID: 180858 RVA: 0x00A975EE File Offset: 0x00A957EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1BFEF6B2423BB23F3A743FA37CFEFB6E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1BFEF6B2423BB23F3A743FA37CFEFB6E_NativeFunctionPtr, null);
		}

		// Token: 0x0602C27B RID: 180859 RVA: 0x00A97602 File Offset: 0x00A95802
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_9C995D5F413AB0D5EEC5B0B25BCA0B99()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_9C995D5F413AB0D5EEC5B0B25BCA0B99_NativeFunctionPtr, null);
		}

		// Token: 0x0602C27C RID: 180860 RVA: 0x00A97616 File Offset: 0x00A95816
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_8D1F93424AA669264C48C4A3AD645001()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_8D1F93424AA669264C48C4A3AD645001_NativeFunctionPtr, null);
		}

		// Token: 0x0602C27D RID: 180861 RVA: 0x00A9762A File Offset: 0x00A9582A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_274A99114D34CF70A381F6832E28301D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_274A99114D34CF70A381F6832E28301D_NativeFunctionPtr, null);
		}

		// Token: 0x0602C27E RID: 180862 RVA: 0x00A9763E File Offset: 0x00A9583E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_C4B06AF44285B268E642C280316C25BE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_C4B06AF44285B268E642C280316C25BE_NativeFunctionPtr, null);
		}

		// Token: 0x0602C27F RID: 180863 RVA: 0x00A97652 File Offset: 0x00A95852
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B7E4C2F643A351461514F3A4BB27FD57()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B7E4C2F643A351461514F3A4BB27FD57_NativeFunctionPtr, null);
		}

		// Token: 0x0602C280 RID: 180864 RVA: 0x00A97666 File Offset: 0x00A95866
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_8A402BC24A8BC234FA1647AE139FAFCA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_8A402BC24A8BC234FA1647AE139FAFCA_NativeFunctionPtr, null);
		}

		// Token: 0x0602C281 RID: 180865 RVA: 0x00A9767A File Offset: 0x00A9587A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B9970B3845ED2CF05C0CE2905CD1D9DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B9970B3845ED2CF05C0CE2905CD1D9DA_NativeFunctionPtr, null);
		}

		// Token: 0x0602C282 RID: 180866 RVA: 0x00A9768E File Offset: 0x00A9588E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_0FDD922B45E34D982F8F85B15BF4E09D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_0FDD922B45E34D982F8F85B15BF4E09D_NativeFunctionPtr, null);
		}

		// Token: 0x0602C283 RID: 180867 RVA: 0x00A976A2 File Offset: 0x00A958A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_DF17119740839C99CBDC5BB7A7ACF2FB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_DF17119740839C99CBDC5BB7A7ACF2FB_NativeFunctionPtr, null);
		}

		// Token: 0x0602C284 RID: 180868 RVA: 0x00A976B6 File Offset: 0x00A958B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_49F87C244E0713CE630B39AA9A563674()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_49F87C244E0713CE630B39AA9A563674_NativeFunctionPtr, null);
		}

		// Token: 0x0602C285 RID: 180869 RVA: 0x00A976CA File Offset: 0x00A958CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_BDCAAEE64FE7F1405D8B77AE820B11F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_BDCAAEE64FE7F1405D8B77AE820B11F2_NativeFunctionPtr, null);
		}

		// Token: 0x0602C286 RID: 180870 RVA: 0x00A976DE File Offset: 0x00A958DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_D33F159C49CF71493708D08A76E6E7CD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_D33F159C49CF71493708D08A76E6E7CD_NativeFunctionPtr, null);
		}

		// Token: 0x0602C287 RID: 180871 RVA: 0x00A976F2 File Offset: 0x00A958F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_2F01251B4B4FE9EAA39B3D9247C31675()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_2F01251B4B4FE9EAA39B3D9247C31675_NativeFunctionPtr, null);
		}

		// Token: 0x0602C288 RID: 180872 RVA: 0x00A97706 File Offset: 0x00A95906
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B5FA9C6847AB27EDF1D286A59C39E411()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B5FA9C6847AB27EDF1D286A59C39E411_NativeFunctionPtr, null);
		}

		// Token: 0x0602C289 RID: 180873 RVA: 0x00A9771A File Offset: 0x00A9591A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_E492EC01485375CFE000B0A5E11A31F8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_E492EC01485375CFE000B0A5E11A31F8_NativeFunctionPtr, null);
		}

		// Token: 0x0602C28A RID: 180874 RVA: 0x00A9772E File Offset: 0x00A9592E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_IdleActionEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AnimNotify_Animal_IdleActionEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C28B RID: 180875 RVA: 0x00A97742 File Offset: 0x00A95942
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_InteractActionEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AnimNotify_Animal_InteractActionEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C28C RID: 180876 RVA: 0x00A97756 File Offset: 0x00A95956
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_AlertEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AnimNotify_Animal_AlertEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C28D RID: 180877 RVA: 0x00A9776A File Offset: 0x00A9596A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_UnderAttackEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AnimNotify_Animal_UnderAttackEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C28E RID: 180878 RVA: 0x00A9777E File Offset: 0x00A9597E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C28F RID: 180879 RVA: 0x00A97792 File Offset: 0x00A95992
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C290 RID: 180880 RVA: 0x00A977A8 File Offset: 0x00A959A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C291 RID: 180881 RVA: 0x00A977F0 File Offset: 0x00A959F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C292 RID: 180882 RVA: 0x00A97837 File Offset: 0x00A95A37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StateMachineInitializationComplete()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__StateMachineInitializationComplete_NativeFunctionPtr, null);
		}

		// Token: 0x0602C293 RID: 180883 RVA: 0x00A9784B File Offset: 0x00A95A4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NoneStateStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__NoneStateStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C294 RID: 180884 RVA: 0x00A9785F File Offset: 0x00A95A5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InteractStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__InteractStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C295 RID: 180885 RVA: 0x00A97873 File Offset: 0x00A95A73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void IdleStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__IdleStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C296 RID: 180886 RVA: 0x00A97887 File Offset: 0x00A95A87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnderAttackStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__UnderAttackStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C297 RID: 180887 RVA: 0x00A9789B File Offset: 0x00A95A9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AlertStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__AlertStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C298 RID: 180888 RVA: 0x00A978AF File Offset: 0x00A95AAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TakeOffStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__TakeOffStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C299 RID: 180889 RVA: 0x00A978C4 File Offset: 0x00A95AC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FeedStart(FGameplayTag GameplayTag)
		{
			ABP_BaseAnimal_C.__FeedStart_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__FeedStart_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseAnimal_C.__FeedStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__FeedStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayTag = GameplayTag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__FeedStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C29A RID: 180890 RVA: 0x00A9790A File Offset: 0x00A95B0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SystemUiStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__SystemUiStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C29B RID: 180891 RVA: 0x00A9791E File Offset: 0x00A95B1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SystemUiEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseAnimal_C.__SystemUiEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C29C RID: 180892 RVA: 0x00A97934 File Offset: 0x00A95B34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseAnimal(int EntryPoint)
		{
			ABP_BaseAnimal_C.__ExecuteUbergraph_ABP_BaseAnimal_FunctionParams* ptr = stackalloc ABP_BaseAnimal_C.__ExecuteUbergraph_ABP_BaseAnimal_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(ABP_BaseAnimal_C.__ExecuteUbergraph_ABP_BaseAnimal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseAnimal_C.__ExecuteUbergraph_ABP_BaseAnimal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseAnimal_C.__ExecuteUbergraph_ABP_BaseAnimal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C29D RID: 180893 RVA: 0x00A9797E File Offset: 0x00A95B7E
		protected ABP_BaseAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040185BD RID: 99773
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/ABP_BaseAnimal.ABP_BaseAnimal_C";

		// Token: 0x040185BE RID: 99774
		private static IntPtr _ClassPtr;

		// Token: 0x040185BF RID: 99775
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040185C0 RID: 99776
		internal static int __PropertyOffset_0;

		// Token: 0x040185C1 RID: 99777
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040185C2 RID: 99778
		internal static int __PropertyOffset_1;

		// Token: 0x040185C3 RID: 99779
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_3;

		// Token: 0x040185C4 RID: 99780
		internal static int __PropertyOffset_2;

		// Token: 0x040185C5 RID: 99781
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_1;

		// Token: 0x040185C6 RID: 99782
		internal static int __PropertyOffset_3;

		// Token: 0x040185C7 RID: 99783
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x040185C8 RID: 99784
		internal static int __PropertyOffset_4;

		// Token: 0x040185C9 RID: 99785
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x040185CA RID: 99786
		internal static int __PropertyOffset_5;

		// Token: 0x040185CB RID: 99787
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x040185CC RID: 99788
		internal static int __PropertyOffset_6;

		// Token: 0x040185CD RID: 99789
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x040185CE RID: 99790
		internal static int __PropertyOffset_7;

		// Token: 0x040185CF RID: 99791
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x040185D0 RID: 99792
		internal static int __PropertyOffset_8;

		// Token: 0x040185D1 RID: 99793
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x040185D2 RID: 99794
		internal static int __PropertyOffset_9;

		// Token: 0x040185D3 RID: 99795
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_52;

		// Token: 0x040185D4 RID: 99796
		internal static int __PropertyOffset_10;

		// Token: 0x040185D5 RID: 99797
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_51;

		// Token: 0x040185D6 RID: 99798
		internal static int __PropertyOffset_11;

		// Token: 0x040185D7 RID: 99799
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_50;

		// Token: 0x040185D8 RID: 99800
		internal static int __PropertyOffset_12;

		// Token: 0x040185D9 RID: 99801
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_49;

		// Token: 0x040185DA RID: 99802
		internal static int __PropertyOffset_13;

		// Token: 0x040185DB RID: 99803
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_48;

		// Token: 0x040185DC RID: 99804
		internal static int __PropertyOffset_14;

		// Token: 0x040185DD RID: 99805
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_47;

		// Token: 0x040185DE RID: 99806
		internal static int __PropertyOffset_15;

		// Token: 0x040185DF RID: 99807
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_46;

		// Token: 0x040185E0 RID: 99808
		internal static int __PropertyOffset_16;

		// Token: 0x040185E1 RID: 99809
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_45;

		// Token: 0x040185E2 RID: 99810
		internal static int __PropertyOffset_17;

		// Token: 0x040185E3 RID: 99811
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_24;

		// Token: 0x040185E4 RID: 99812
		internal static int __PropertyOffset_18;

		// Token: 0x040185E5 RID: 99813
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_31;

		// Token: 0x040185E6 RID: 99814
		internal static int __PropertyOffset_19;

		// Token: 0x040185E7 RID: 99815
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_23;

		// Token: 0x040185E8 RID: 99816
		internal static int __PropertyOffset_20;

		// Token: 0x040185E9 RID: 99817
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_30;

		// Token: 0x040185EA RID: 99818
		internal static int __PropertyOffset_21;

		// Token: 0x040185EB RID: 99819
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_22;

		// Token: 0x040185EC RID: 99820
		internal static int __PropertyOffset_22;

		// Token: 0x040185ED RID: 99821
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x040185EE RID: 99822
		internal static int __PropertyOffset_23;

		// Token: 0x040185EF RID: 99823
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_21;

		// Token: 0x040185F0 RID: 99824
		internal static int __PropertyOffset_24;

		// Token: 0x040185F1 RID: 99825
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x040185F2 RID: 99826
		internal static int __PropertyOffset_25;

		// Token: 0x040185F3 RID: 99827
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_20;

		// Token: 0x040185F4 RID: 99828
		internal static int __PropertyOffset_26;

		// Token: 0x040185F5 RID: 99829
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x040185F6 RID: 99830
		internal static int __PropertyOffset_27;

		// Token: 0x040185F7 RID: 99831
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_19;

		// Token: 0x040185F8 RID: 99832
		internal static int __PropertyOffset_28;

		// Token: 0x040185F9 RID: 99833
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x040185FA RID: 99834
		internal static int __PropertyOffset_29;

		// Token: 0x040185FB RID: 99835
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_18;

		// Token: 0x040185FC RID: 99836
		internal static int __PropertyOffset_30;

		// Token: 0x040185FD RID: 99837
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x040185FE RID: 99838
		internal static int __PropertyOffset_31;

		// Token: 0x040185FF RID: 99839
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x04018600 RID: 99840
		internal static int __PropertyOffset_32;

		// Token: 0x04018601 RID: 99841
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_44;

		// Token: 0x04018602 RID: 99842
		internal static int __PropertyOffset_33;

		// Token: 0x04018603 RID: 99843
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_43;

		// Token: 0x04018604 RID: 99844
		internal static int __PropertyOffset_34;

		// Token: 0x04018605 RID: 99845
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_42;

		// Token: 0x04018606 RID: 99846
		internal static int __PropertyOffset_35;

		// Token: 0x04018607 RID: 99847
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_41;

		// Token: 0x04018608 RID: 99848
		internal static int __PropertyOffset_36;

		// Token: 0x04018609 RID: 99849
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_40;

		// Token: 0x0401860A RID: 99850
		internal static int __PropertyOffset_37;

		// Token: 0x0401860B RID: 99851
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_39;

		// Token: 0x0401860C RID: 99852
		internal static int __PropertyOffset_38;

		// Token: 0x0401860D RID: 99853
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_38;

		// Token: 0x0401860E RID: 99854
		internal static int __PropertyOffset_39;

		// Token: 0x0401860F RID: 99855
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_37;

		// Token: 0x04018610 RID: 99856
		internal static int __PropertyOffset_40;

		// Token: 0x04018611 RID: 99857
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_36;

		// Token: 0x04018612 RID: 99858
		internal static int __PropertyOffset_41;

		// Token: 0x04018613 RID: 99859
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_35;

		// Token: 0x04018614 RID: 99860
		internal static int __PropertyOffset_42;

		// Token: 0x04018615 RID: 99861
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_34;

		// Token: 0x04018616 RID: 99862
		internal static int __PropertyOffset_43;

		// Token: 0x04018617 RID: 99863
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x04018618 RID: 99864
		internal static int __PropertyOffset_44;

		// Token: 0x04018619 RID: 99865
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x0401861A RID: 99866
		internal static int __PropertyOffset_45;

		// Token: 0x0401861B RID: 99867
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x0401861C RID: 99868
		internal static int __PropertyOffset_46;

		// Token: 0x0401861D RID: 99869
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x0401861E RID: 99870
		internal static int __PropertyOffset_47;

		// Token: 0x0401861F RID: 99871
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x04018620 RID: 99872
		internal static int __PropertyOffset_48;

		// Token: 0x04018621 RID: 99873
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x04018622 RID: 99874
		internal static int __PropertyOffset_49;

		// Token: 0x04018623 RID: 99875
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x04018624 RID: 99876
		internal static int __PropertyOffset_50;

		// Token: 0x04018625 RID: 99877
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x04018626 RID: 99878
		internal static int __PropertyOffset_51;

		// Token: 0x04018627 RID: 99879
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_17;

		// Token: 0x04018628 RID: 99880
		internal static int __PropertyOffset_52;

		// Token: 0x04018629 RID: 99881
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x0401862A RID: 99882
		internal static int __PropertyOffset_53;

		// Token: 0x0401862B RID: 99883
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_1;

		// Token: 0x0401862C RID: 99884
		internal static int __PropertyOffset_54;

		// Token: 0x0401862D RID: 99885
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x0401862E RID: 99886
		internal static int __PropertyOffset_55;

		// Token: 0x0401862F RID: 99887
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_16;

		// Token: 0x04018630 RID: 99888
		internal static int __PropertyOffset_56;

		// Token: 0x04018631 RID: 99889
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x04018632 RID: 99890
		internal static int __PropertyOffset_57;

		// Token: 0x04018633 RID: 99891
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_15;

		// Token: 0x04018634 RID: 99892
		internal static int __PropertyOffset_58;

		// Token: 0x04018635 RID: 99893
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x04018636 RID: 99894
		internal static int __PropertyOffset_59;

		// Token: 0x04018637 RID: 99895
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x04018638 RID: 99896
		internal static int __PropertyOffset_60;

		// Token: 0x04018639 RID: 99897
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x0401863A RID: 99898
		internal static int __PropertyOffset_61;

		// Token: 0x0401863B RID: 99899
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x0401863C RID: 99900
		internal static int __PropertyOffset_62;

		// Token: 0x0401863D RID: 99901
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x0401863E RID: 99902
		internal static int __PropertyOffset_63;

		// Token: 0x0401863F RID: 99903
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x04018640 RID: 99904
		internal static int __PropertyOffset_64;

		// Token: 0x04018641 RID: 99905
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x04018642 RID: 99906
		internal static int __PropertyOffset_65;

		// Token: 0x04018643 RID: 99907
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04018644 RID: 99908
		internal static int __PropertyOffset_66;

		// Token: 0x04018645 RID: 99909
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x04018646 RID: 99910
		internal static int __PropertyOffset_67;

		// Token: 0x04018647 RID: 99911
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x04018648 RID: 99912
		internal static int __PropertyOffset_68;

		// Token: 0x04018649 RID: 99913
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x0401864A RID: 99914
		internal static int __PropertyOffset_69;

		// Token: 0x0401864B RID: 99915
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x0401864C RID: 99916
		internal static int __PropertyOffset_70;

		// Token: 0x0401864D RID: 99917
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x0401864E RID: 99918
		internal static int __PropertyOffset_71;

		// Token: 0x0401864F RID: 99919
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x04018650 RID: 99920
		internal static int __PropertyOffset_72;

		// Token: 0x04018651 RID: 99921
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x04018652 RID: 99922
		internal static int __PropertyOffset_73;

		// Token: 0x04018653 RID: 99923
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x04018654 RID: 99924
		internal static int __PropertyOffset_74;

		// Token: 0x04018655 RID: 99925
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x04018656 RID: 99926
		internal static int __PropertyOffset_75;

		// Token: 0x04018657 RID: 99927
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04018658 RID: 99928
		internal static int __PropertyOffset_76;

		// Token: 0x04018659 RID: 99929
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x0401865A RID: 99930
		internal static int __PropertyOffset_77;

		// Token: 0x0401865B RID: 99931
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x0401865C RID: 99932
		internal static int __PropertyOffset_78;

		// Token: 0x0401865D RID: 99933
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x0401865E RID: 99934
		internal static int __PropertyOffset_79;

		// Token: 0x0401865F RID: 99935
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator;

		// Token: 0x04018660 RID: 99936
		internal static int __PropertyOffset_80;

		// Token: 0x04018661 RID: 99937
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04018662 RID: 99938
		internal static int __PropertyOffset_81;

		// Token: 0x04018663 RID: 99939
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x04018664 RID: 99940
		internal static int __PropertyOffset_82;

		// Token: 0x04018665 RID: 99941
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x04018666 RID: 99942
		internal static int __PropertyOffset_83;

		// Token: 0x04018667 RID: 99943
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04018668 RID: 99944
		internal static int __PropertyOffset_84;

		// Token: 0x04018669 RID: 99945
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x0401866A RID: 99946
		internal static int __PropertyOffset_85;

		// Token: 0x0401866B RID: 99947
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x0401866C RID: 99948
		internal static int __PropertyOffset_86;

		// Token: 0x0401866D RID: 99949
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x0401866E RID: 99950
		internal static int __PropertyOffset_87;

		// Token: 0x0401866F RID: 99951
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04018670 RID: 99952
		internal static int __PropertyOffset_88;

		// Token: 0x04018671 RID: 99953
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04018672 RID: 99954
		internal static int __PropertyOffset_89;

		// Token: 0x04018673 RID: 99955
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04018674 RID: 99956
		internal static int __PropertyOffset_90;

		// Token: 0x04018675 RID: 99957
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04018676 RID: 99958
		internal static int __PropertyOffset_91;

		// Token: 0x04018677 RID: 99959
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04018678 RID: 99960
		internal static int __PropertyOffset_92;

		// Token: 0x04018679 RID: 99961
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x0401867A RID: 99962
		internal static int __PropertyOffset_93;

		// Token: 0x0401867B RID: 99963
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x0401867C RID: 99964
		internal static int __PropertyOffset_94;

		// Token: 0x0401867D RID: 99965
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x0401867E RID: 99966
		internal static int __PropertyOffset_95;

		// Token: 0x0401867F RID: 99967
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04018680 RID: 99968
		internal static int __PropertyOffset_96;

		// Token: 0x04018681 RID: 99969
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04018682 RID: 99970
		internal static int __PropertyOffset_97;

		// Token: 0x04018683 RID: 99971
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04018684 RID: 99972
		internal static int __PropertyOffset_98;

		// Token: 0x04018685 RID: 99973
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04018686 RID: 99974
		internal static int __PropertyOffset_99;

		// Token: 0x04018687 RID: 99975
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_1;

		// Token: 0x04018688 RID: 99976
		internal static int __PropertyOffset_100;

		// Token: 0x04018689 RID: 99977
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x0401868A RID: 99978
		internal static int __PropertyOffset_101;

		// Token: 0x0401868B RID: 99979
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x0401868C RID: 99980
		internal static int __PropertyOffset_102;

		// Token: 0x0401868D RID: 99981
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_1;

		// Token: 0x0401868E RID: 99982
		internal static int __PropertyOffset_103;

		// Token: 0x0401868F RID: 99983
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04018690 RID: 99984
		internal static int __PropertyOffset_104;

		// Token: 0x04018691 RID: 99985
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04018692 RID: 99986
		internal static int __PropertyOffset_105;

		// Token: 0x04018693 RID: 99987
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x04018694 RID: 99988
		internal static int __PropertyOffset_106;

		// Token: 0x04018695 RID: 99989
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x04018696 RID: 99990
		internal static int __PropertyOffset_107;

		// Token: 0x04018697 RID: 99991
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x04018698 RID: 99992
		internal static int __PropertyOffset_108;

		// Token: 0x04018699 RID: 99993
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x0401869A RID: 99994
		internal static int __PropertyOffset_109;

		// Token: 0x0401869B RID: 99995
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x0401869C RID: 99996
		internal static int __PropertyOffset_110;

		// Token: 0x0401869D RID: 99997
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x0401869E RID: 99998
		internal static int __PropertyOffset_111;

		// Token: 0x0401869F RID: 99999
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x040186A0 RID: 100000
		internal static int __PropertyOffset_112;

		// Token: 0x040186A1 RID: 100001
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x040186A2 RID: 100002
		internal static int __PropertyOffset_113;

		// Token: 0x040186A3 RID: 100003
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x040186A4 RID: 100004
		internal static int __PropertyOffset_114;

		// Token: 0x040186A5 RID: 100005
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x040186A6 RID: 100006
		internal static int __PropertyOffset_115;

		// Token: 0x040186A7 RID: 100007
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x040186A8 RID: 100008
		internal static int __PropertyOffset_116;

		// Token: 0x040186A9 RID: 100009
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x040186AA RID: 100010
		internal static int __PropertyOffset_117;

		// Token: 0x040186AB RID: 100011
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x040186AC RID: 100012
		internal static int __PropertyOffset_118;

		// Token: 0x040186AD RID: 100013
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x040186AE RID: 100014
		internal static int __PropertyOffset_119;

		// Token: 0x040186AF RID: 100015
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x040186B0 RID: 100016
		internal static int __PropertyOffset_120;

		// Token: 0x040186B1 RID: 100017
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x040186B2 RID: 100018
		internal static int __PropertyOffset_121;

		// Token: 0x040186B3 RID: 100019
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x040186B4 RID: 100020
		internal static int __PropertyOffset_122;

		// Token: 0x040186B5 RID: 100021
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x040186B6 RID: 100022
		internal static int __PropertyOffset_123;

		// Token: 0x040186B7 RID: 100023
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x040186B8 RID: 100024
		internal static int __PropertyOffset_124;

		// Token: 0x040186B9 RID: 100025
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x040186BA RID: 100026
		internal static int __PropertyOffset_125;

		// Token: 0x040186BB RID: 100027
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x040186BC RID: 100028
		internal static int __PropertyOffset_126;

		// Token: 0x040186BD RID: 100029
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x040186BE RID: 100030
		internal static int __PropertyOffset_127;

		// Token: 0x040186BF RID: 100031
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose;

		// Token: 0x040186C0 RID: 100032
		internal static int __PropertyOffset_128;

		// Token: 0x040186C1 RID: 100033
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x040186C2 RID: 100034
		internal static int __PropertyOffset_129;

		// Token: 0x040186C3 RID: 100035
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x040186C4 RID: 100036
		internal static int __PropertyOffset_130;

		// Token: 0x040186C5 RID: 100037
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose;

		// Token: 0x040186C6 RID: 100038
		internal static int __PropertyOffset_131;

		// Token: 0x040186C7 RID: 100039
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x040186C8 RID: 100040
		internal static int __PropertyOffset_132;

		// Token: 0x040186C9 RID: 100041
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x040186CA RID: 100042
		internal static int __PropertyOffset_133;

		// Token: 0x040186CB RID: 100043
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040186CC RID: 100044
		internal static int __PropertyOffset_134;

		// Token: 0x040186CD RID: 100045
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_2;

		// Token: 0x040186CE RID: 100046
		internal static int __PropertyOffset_135;

		// Token: 0x040186CF RID: 100047
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x040186D0 RID: 100048
		internal static int __PropertyOffset_136;

		// Token: 0x040186D1 RID: 100049
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x040186D2 RID: 100050
		internal static int __PropertyOffset_137;

		// Token: 0x040186D3 RID: 100051
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimSequence> _待机表演配置;

		// Token: 0x040186D4 RID: 100052
		internal static int __PropertyOffset_138;

		// Token: 0x040186D5 RID: 100053
		internal static int __PropertyOffset_139;

		// Token: 0x040186D6 RID: 100054
		internal static int __PropertyOffset_140;

		// Token: 0x040186D7 RID: 100055
		internal static int __PropertyOffset_141;

		// Token: 0x040186D8 RID: 100056
		internal static int __PropertyOffset_142;

		// Token: 0x040186D9 RID: 100057
		internal static int __PropertyOffset_143;

		// Token: 0x040186DA RID: 100058
		internal static int __PropertyOffset_144;

		// Token: 0x040186DB RID: 100059
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimSequence> _交互表演配置;

		// Token: 0x040186DC RID: 100060
		internal static int __PropertyOffset_145;

		// Token: 0x040186DD RID: 100061
		internal static int __PropertyOffset_146;

		// Token: 0x040186DE RID: 100062
		internal static int __PropertyOffset_147;

		// Token: 0x040186DF RID: 100063
		internal static int __PropertyOffset_148;

		// Token: 0x040186E0 RID: 100064
		internal static int __PropertyOffset_149;

		// Token: 0x040186E1 RID: 100065
		internal static int __PropertyOffset_150;

		// Token: 0x040186E2 RID: 100066
		internal static int __PropertyOffset_151;

		// Token: 0x040186E3 RID: 100067
		internal static int __PropertyOffset_152;

		// Token: 0x040186E4 RID: 100068
		internal static int __PropertyOffset_153;

		// Token: 0x040186E5 RID: 100069
		internal static int __PropertyOffset_154;

		// Token: 0x040186E6 RID: 100070
		internal static int __PropertyOffset_155;

		// Token: 0x040186E7 RID: 100071
		internal static int __PropertyOffset_156;

		// Token: 0x040186E8 RID: 100072
		internal static int __PropertyOffset_157;

		// Token: 0x040186E9 RID: 100073
		internal static int __PropertyOffset_158;

		// Token: 0x040186EA RID: 100074
		internal static int __PropertyOffset_159;

		// Token: 0x040186EB RID: 100075
		internal static int __PropertyOffset_160;

		// Token: 0x040186EC RID: 100076
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, UAnimSequence> _其他动作配置;

		// Token: 0x040186ED RID: 100077
		internal static int __PropertyOffset_161;

		// Token: 0x040186EE RID: 100078
		internal static int __PropertyOffset_162;

		// Token: 0x040186EF RID: 100079
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> _材质配置;

		// Token: 0x040186F0 RID: 100080
		internal static int __PropertyOffset_163;

		// Token: 0x040186F1 RID: 100081
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, UAnimMontage> _蒙太奇表演配置;

		// Token: 0x040186F2 RID: 100082
		internal static int __PropertyOffset_164;

		// Token: 0x040186F3 RID: 100083
		internal static int __PropertyOffset_165;

		// Token: 0x040186F4 RID: 100084
		internal static int __PropertyOffset_166;

		// Token: 0x040186F5 RID: 100085
		private static IntPtr __GetCurrentActionTime_NativeFunctionPtr;

		// Token: 0x040186F6 RID: 100086
		private static IntPtr __演出层_NativeFunctionPtr;

		// Token: 0x040186F7 RID: 100087
		private static IntPtr __后处理层_NativeFunctionPtr;

		// Token: 0x040186F8 RID: 100088
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x040186F9 RID: 100089
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x040186FA RID: 100090
		private static IntPtr __OnSystemUIStart_NativeFunctionPtr;

		// Token: 0x040186FB RID: 100091
		private static IntPtr __OnFeedStart_NativeFunctionPtr;

		// Token: 0x040186FC RID: 100092
		private static IntPtr __更新移动信息_NativeFunctionPtr;

		// Token: 0x040186FD RID: 100093
		private static IntPtr __处理动作优先级_NativeFunctionPtr;

		// Token: 0x040186FE RID: 100094
		private static IntPtr __OnUnderAttackStart_NativeFunctionPtr;

		// Token: 0x040186FF RID: 100095
		private static IntPtr __OnTakeOffStart_NativeFunctionPtr;

		// Token: 0x04018700 RID: 100096
		private static IntPtr __OnAlertStart_NativeFunctionPtr;

		// Token: 0x04018701 RID: 100097
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x04018702 RID: 100098
		private static IntPtr __OnInteractStart_NativeFunctionPtr;

		// Token: 0x04018703 RID: 100099
		private static IntPtr __更新特殊交互表演_NativeFunctionPtr;

		// Token: 0x04018704 RID: 100100
		private static IntPtr __更新交互表演_NativeFunctionPtr;

		// Token: 0x04018705 RID: 100101
		private static IntPtr __OnIdleStart_NativeFunctionPtr;

		// Token: 0x04018706 RID: 100102
		private static IntPtr __更新待机表演_NativeFunctionPtr;

		// Token: 0x04018707 RID: 100103
		private static IntPtr __AlertEnd_NativeFunctionPtr;

		// Token: 0x04018708 RID: 100104
		private static IntPtr __TakeOffEnd_NativeFunctionPtr;

		// Token: 0x04018709 RID: 100105
		private static IntPtr __UnderAttackEnd_NativeFunctionPtr;

		// Token: 0x0401870A RID: 100106
		private static IntPtr __IdleEnd_NativeFunctionPtr;

		// Token: 0x0401870B RID: 100107
		private static IntPtr __InteractEnd_NativeFunctionPtr;

		// Token: 0x0401870C RID: 100108
		private static IntPtr __NoneStateEnd_NativeFunctionPtr;

		// Token: 0x0401870D RID: 100109
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_6708632043AE1764C2B1A2BC8487CAA2_NativeFunctionPtr;

		// Token: 0x0401870E RID: 100110
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_E971F2414D8A609D52454EBD86A29DDE_NativeFunctionPtr;

		// Token: 0x0401870F RID: 100111
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_D76347B84F84143110867F87A063BC9A_NativeFunctionPtr;

		// Token: 0x04018710 RID: 100112
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_F2118EA4482961323A4284A5C757A6D4_NativeFunctionPtr;

		// Token: 0x04018711 RID: 100113
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_AEAB655045E3052DFA6C2EB97F6BAEE4_NativeFunctionPtr;

		// Token: 0x04018712 RID: 100114
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_49945F8B4DD298D2ED4AE0B5BD3BFF51_NativeFunctionPtr;

		// Token: 0x04018713 RID: 100115
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_0A62643941C9F2534B1AF99C24980E2C_NativeFunctionPtr;

		// Token: 0x04018714 RID: 100116
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1769F6104A02243DD5C6589592A29465_NativeFunctionPtr;

		// Token: 0x04018715 RID: 100117
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_416429BC4584FF707D49B1BF83556BF2_NativeFunctionPtr;

		// Token: 0x04018716 RID: 100118
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_764CCFAC4D41871FBC3DA79A1C2573AB_NativeFunctionPtr;

		// Token: 0x04018717 RID: 100119
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_DBE786244F0BB91CD41D8289371D7030_NativeFunctionPtr;

		// Token: 0x04018718 RID: 100120
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_28773EEC4DFEA3865FF9E284E7CE5F47_NativeFunctionPtr;

		// Token: 0x04018719 RID: 100121
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_3B0855934F908EBADF5C0E905BE5EBAD_NativeFunctionPtr;

		// Token: 0x0401871A RID: 100122
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_3C432C1A4EAC4B8EEC7FAA9810D7964C_NativeFunctionPtr;

		// Token: 0x0401871B RID: 100123
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_437CDAF94B84EB0EA0350A81D62C1333_NativeFunctionPtr;

		// Token: 0x0401871C RID: 100124
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_9E2813C546DB12830090D0B49CAFCF8A_NativeFunctionPtr;

		// Token: 0x0401871D RID: 100125
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_00AF891944077B505E5628A5880DB881_NativeFunctionPtr;

		// Token: 0x0401871E RID: 100126
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_7DF62BD6494255C57AF1CA838DF2F699_NativeFunctionPtr;

		// Token: 0x0401871F RID: 100127
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1FA99C764B6E9143E9A2EBBC467023D2_NativeFunctionPtr;

		// Token: 0x04018720 RID: 100128
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_1BFEF6B2423BB23F3A743FA37CFEFB6E_NativeFunctionPtr;

		// Token: 0x04018721 RID: 100129
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_9C995D5F413AB0D5EEC5B0B25BCA0B99_NativeFunctionPtr;

		// Token: 0x04018722 RID: 100130
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_8D1F93424AA669264C48C4A3AD645001_NativeFunctionPtr;

		// Token: 0x04018723 RID: 100131
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_274A99114D34CF70A381F6832E28301D_NativeFunctionPtr;

		// Token: 0x04018724 RID: 100132
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_C4B06AF44285B268E642C280316C25BE_NativeFunctionPtr;

		// Token: 0x04018725 RID: 100133
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B7E4C2F643A351461514F3A4BB27FD57_NativeFunctionPtr;

		// Token: 0x04018726 RID: 100134
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_8A402BC24A8BC234FA1647AE139FAFCA_NativeFunctionPtr;

		// Token: 0x04018727 RID: 100135
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B9970B3845ED2CF05C0CE2905CD1D9DA_NativeFunctionPtr;

		// Token: 0x04018728 RID: 100136
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_0FDD922B45E34D982F8F85B15BF4E09D_NativeFunctionPtr;

		// Token: 0x04018729 RID: 100137
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_DF17119740839C99CBDC5BB7A7ACF2FB_NativeFunctionPtr;

		// Token: 0x0401872A RID: 100138
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_49F87C244E0713CE630B39AA9A563674_NativeFunctionPtr;

		// Token: 0x0401872B RID: 100139
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_BDCAAEE64FE7F1405D8B77AE820B11F2_NativeFunctionPtr;

		// Token: 0x0401872C RID: 100140
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_D33F159C49CF71493708D08A76E6E7CD_NativeFunctionPtr;

		// Token: 0x0401872D RID: 100141
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_2F01251B4B4FE9EAA39B3D9247C31675_NativeFunctionPtr;

		// Token: 0x0401872E RID: 100142
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_B5FA9C6847AB27EDF1D286A59C39E411_NativeFunctionPtr;

		// Token: 0x0401872F RID: 100143
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseAnimal_AnimGraphNode_TransitionResult_E492EC01485375CFE000B0A5E11A31F8_NativeFunctionPtr;

		// Token: 0x04018730 RID: 100144
		private static IntPtr __AnimNotify_Animal_IdleActionEnd_NativeFunctionPtr;

		// Token: 0x04018731 RID: 100145
		private static IntPtr __AnimNotify_Animal_InteractActionEnd_NativeFunctionPtr;

		// Token: 0x04018732 RID: 100146
		private static IntPtr __AnimNotify_Animal_AlertEnd_NativeFunctionPtr;

		// Token: 0x04018733 RID: 100147
		private static IntPtr __AnimNotify_Animal_UnderAttackEnd_NativeFunctionPtr;

		// Token: 0x04018734 RID: 100148
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018735 RID: 100149
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018736 RID: 100150
		private static IntPtr __StateMachineInitializationComplete_NativeFunctionPtr;

		// Token: 0x04018737 RID: 100151
		private static IntPtr __NoneStateStart_NativeFunctionPtr;

		// Token: 0x04018738 RID: 100152
		private static IntPtr __InteractStart_NativeFunctionPtr;

		// Token: 0x04018739 RID: 100153
		private static IntPtr __IdleStart_NativeFunctionPtr;

		// Token: 0x0401873A RID: 100154
		private static IntPtr __UnderAttackStart_NativeFunctionPtr;

		// Token: 0x0401873B RID: 100155
		private static IntPtr __AlertStart_NativeFunctionPtr;

		// Token: 0x0401873C RID: 100156
		private static IntPtr __TakeOffStart_NativeFunctionPtr;

		// Token: 0x0401873D RID: 100157
		private static IntPtr __FeedStart_NativeFunctionPtr;

		// Token: 0x0401873E RID: 100158
		private static IntPtr __SystemUiStart_NativeFunctionPtr;

		// Token: 0x0401873F RID: 100159
		private static IntPtr __SystemUiEnd_NativeFunctionPtr;

		// Token: 0x04018740 RID: 100160
		private static IntPtr __ExecuteUbergraph_ABP_BaseAnimal_NativeFunctionPtr;

		// Token: 0x0200A422 RID: 42018
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetCurrentActionTime_FunctionParams
		{
			// Token: 0x04033219 RID: 209433
			[FieldOffset(0)]
			public float ActionTime;
		}

		// Token: 0x0200A423 RID: 42019
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __演出层_FunctionParams
		{
			// Token: 0x0403321A RID: 209434
			[FieldOffset(0)]
			public byte 状态机输入;

			// Token: 0x0403321B RID: 209435
			[FieldOffset(24)]
			public byte 演出层;
		}

		// Token: 0x0200A424 RID: 42020
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __后处理层_FunctionParams
		{
			// Token: 0x0403321C RID: 209436
			[FieldOffset(0)]
			public byte 基础输入;

			// Token: 0x0403321D RID: 209437
			[FieldOffset(24)]
			public byte 后处理层;
		}

		// Token: 0x0200A425 RID: 42021
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x0403321E RID: 209438
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A426 RID: 42022
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x0403321F RID: 209439
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A427 RID: 42023
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnFeedStart_FunctionParams
		{
			// Token: 0x04033220 RID: 209440
			[FieldOffset(0)]
			public FGameplayTag GameplayTag;
		}

		// Token: 0x0200A428 RID: 42024
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04033221 RID: 209441
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A429 RID: 42025
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __FeedStart_FunctionParams
		{
			// Token: 0x04033222 RID: 209442
			[FieldOffset(0)]
			public FGameplayTag GameplayTag;
		}

		// Token: 0x0200A42A RID: 42026
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __ExecuteUbergraph_ABP_BaseAnimal_FunctionParams
		{
			// Token: 0x04033223 RID: 209443
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
