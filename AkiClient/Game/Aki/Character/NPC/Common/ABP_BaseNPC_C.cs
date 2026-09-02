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
	// Token: 0x020040E7 RID: 16615
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/ABP_BaseNPC.ABP_BaseNPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_BaseNPC_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_Animation_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602BCB7 RID: 179383 RVA: 0x00A892F4 File Offset: 0x00A874F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Common/ABP_BaseNPC.ABP_BaseNPC_C");
			}
			return ABP_BaseNPC_C._ClassPtr;
		}

		// Token: 0x0602BCB8 RID: 179384 RVA: 0x00A89318 File Offset: 0x00A87518
		public ABP_BaseNPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602BCB9 RID: 179385 RVA: 0x00A89340 File Offset: 0x00A87540
		public ABP_BaseNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700743B RID: 29755
		// (get) Token: 0x0602BCBA RID: 179386 RVA: 0x00A89374 File Offset: 0x00A87574
		// (set) Token: 0x0602BCBB RID: 179387 RVA: 0x00A893AD File Offset: 0x00A875AD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700743C RID: 29756
		// (get) Token: 0x0602BCBC RID: 179388 RVA: 0x00A893D0 File Offset: 0x00A875D0
		// (set) Token: 0x0602BCBD RID: 179389 RVA: 0x00A89409 File Offset: 0x00A87609
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700743D RID: 29757
		// (get) Token: 0x0602BCBE RID: 179390 RVA: 0x00A8942C File Offset: 0x00A8762C
		// (set) Token: 0x0602BCBF RID: 179391 RVA: 0x00A89465 File Offset: 0x00A87665
		public FAnimNode_Slot AnimGraphNode_Slot_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_5) == null)
				{
					result = (this._AnimGraphNode_Slot_5 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700743E RID: 29758
		// (get) Token: 0x0602BCC0 RID: 179392 RVA: 0x00A89488 File Offset: 0x00A87688
		// (set) Token: 0x0602BCC1 RID: 179393 RVA: 0x00A894C1 File Offset: 0x00A876C1
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700743F RID: 29759
		// (get) Token: 0x0602BCC2 RID: 179394 RVA: 0x00A894E4 File Offset: 0x00A876E4
		// (set) Token: 0x0602BCC3 RID: 179395 RVA: 0x00A8951D File Offset: 0x00A8771D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007440 RID: 29760
		// (get) Token: 0x0602BCC4 RID: 179396 RVA: 0x00A89540 File Offset: 0x00A87740
		// (set) Token: 0x0602BCC5 RID: 179397 RVA: 0x00A89579 File Offset: 0x00A87779
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007441 RID: 29761
		// (get) Token: 0x0602BCC6 RID: 179398 RVA: 0x00A8959C File Offset: 0x00A8779C
		// (set) Token: 0x0602BCC7 RID: 179399 RVA: 0x00A895D5 File Offset: 0x00A877D5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007442 RID: 29762
		// (get) Token: 0x0602BCC8 RID: 179400 RVA: 0x00A895F8 File Offset: 0x00A877F8
		// (set) Token: 0x0602BCC9 RID: 179401 RVA: 0x00A89631 File Offset: 0x00A87831
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007443 RID: 29763
		// (get) Token: 0x0602BCCA RID: 179402 RVA: 0x00A89654 File Offset: 0x00A87854
		// (set) Token: 0x0602BCCB RID: 179403 RVA: 0x00A8968D File Offset: 0x00A8788D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007444 RID: 29764
		// (get) Token: 0x0602BCCC RID: 179404 RVA: 0x00A896B0 File Offset: 0x00A878B0
		// (set) Token: 0x0602BCCD RID: 179405 RVA: 0x00A896E9 File Offset: 0x00A878E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007445 RID: 29765
		// (get) Token: 0x0602BCCE RID: 179406 RVA: 0x00A8970C File Offset: 0x00A8790C
		// (set) Token: 0x0602BCCF RID: 179407 RVA: 0x00A89745 File Offset: 0x00A87945
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007446 RID: 29766
		// (get) Token: 0x0602BCD0 RID: 179408 RVA: 0x00A89768 File Offset: 0x00A87968
		// (set) Token: 0x0602BCD1 RID: 179409 RVA: 0x00A897A1 File Offset: 0x00A879A1
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007447 RID: 29767
		// (get) Token: 0x0602BCD2 RID: 179410 RVA: 0x00A897C4 File Offset: 0x00A879C4
		// (set) Token: 0x0602BCD3 RID: 179411 RVA: 0x00A897FD File Offset: 0x00A879FD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007448 RID: 29768
		// (get) Token: 0x0602BCD4 RID: 179412 RVA: 0x00A89820 File Offset: 0x00A87A20
		// (set) Token: 0x0602BCD5 RID: 179413 RVA: 0x00A89859 File Offset: 0x00A87A59
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007449 RID: 29769
		// (get) Token: 0x0602BCD6 RID: 179414 RVA: 0x00A8987C File Offset: 0x00A87A7C
		// (set) Token: 0x0602BCD7 RID: 179415 RVA: 0x00A898B5 File Offset: 0x00A87AB5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700744A RID: 29770
		// (get) Token: 0x0602BCD8 RID: 179416 RVA: 0x00A898D8 File Offset: 0x00A87AD8
		// (set) Token: 0x0602BCD9 RID: 179417 RVA: 0x00A89911 File Offset: 0x00A87B11
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700744B RID: 29771
		// (get) Token: 0x0602BCDA RID: 179418 RVA: 0x00A89934 File Offset: 0x00A87B34
		// (set) Token: 0x0602BCDB RID: 179419 RVA: 0x00A8996D File Offset: 0x00A87B6D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_2) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_2 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700744C RID: 29772
		// (get) Token: 0x0602BCDC RID: 179420 RVA: 0x00A89990 File Offset: 0x00A87B90
		// (set) Token: 0x0602BCDD RID: 179421 RVA: 0x00A899C9 File Offset: 0x00A87BC9
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700744D RID: 29773
		// (get) Token: 0x0602BCDE RID: 179422 RVA: 0x00A899EC File Offset: 0x00A87BEC
		// (set) Token: 0x0602BCDF RID: 179423 RVA: 0x00A89A25 File Offset: 0x00A87C25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700744E RID: 29774
		// (get) Token: 0x0602BCE0 RID: 179424 RVA: 0x00A89A48 File Offset: 0x00A87C48
		// (set) Token: 0x0602BCE1 RID: 179425 RVA: 0x00A89A81 File Offset: 0x00A87C81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700744F RID: 29775
		// (get) Token: 0x0602BCE2 RID: 179426 RVA: 0x00A89AA4 File Offset: 0x00A87CA4
		// (set) Token: 0x0602BCE3 RID: 179427 RVA: 0x00A89ADD File Offset: 0x00A87CDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007450 RID: 29776
		// (get) Token: 0x0602BCE4 RID: 179428 RVA: 0x00A89B00 File Offset: 0x00A87D00
		// (set) Token: 0x0602BCE5 RID: 179429 RVA: 0x00A89B39 File Offset: 0x00A87D39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007451 RID: 29777
		// (get) Token: 0x0602BCE6 RID: 179430 RVA: 0x00A89B5C File Offset: 0x00A87D5C
		// (set) Token: 0x0602BCE7 RID: 179431 RVA: 0x00A89B95 File Offset: 0x00A87D95
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007452 RID: 29778
		// (get) Token: 0x0602BCE8 RID: 179432 RVA: 0x00A89BB8 File Offset: 0x00A87DB8
		// (set) Token: 0x0602BCE9 RID: 179433 RVA: 0x00A89BF1 File Offset: 0x00A87DF1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007453 RID: 29779
		// (get) Token: 0x0602BCEA RID: 179434 RVA: 0x00A89C14 File Offset: 0x00A87E14
		// (set) Token: 0x0602BCEB RID: 179435 RVA: 0x00A89C4D File Offset: 0x00A87E4D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007454 RID: 29780
		// (get) Token: 0x0602BCEC RID: 179436 RVA: 0x00A89C70 File Offset: 0x00A87E70
		// (set) Token: 0x0602BCED RID: 179437 RVA: 0x00A89CA9 File Offset: 0x00A87EA9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007455 RID: 29781
		// (get) Token: 0x0602BCEE RID: 179438 RVA: 0x00A89CCC File Offset: 0x00A87ECC
		// (set) Token: 0x0602BCEF RID: 179439 RVA: 0x00A89D05 File Offset: 0x00A87F05
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007456 RID: 29782
		// (get) Token: 0x0602BCF0 RID: 179440 RVA: 0x00A89D28 File Offset: 0x00A87F28
		// (set) Token: 0x0602BCF1 RID: 179441 RVA: 0x00A89D61 File Offset: 0x00A87F61
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007457 RID: 29783
		// (get) Token: 0x0602BCF2 RID: 179442 RVA: 0x00A89D84 File Offset: 0x00A87F84
		// (set) Token: 0x0602BCF3 RID: 179443 RVA: 0x00A89DBD File Offset: 0x00A87FBD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007458 RID: 29784
		// (get) Token: 0x0602BCF4 RID: 179444 RVA: 0x00A89DE0 File Offset: 0x00A87FE0
		// (set) Token: 0x0602BCF5 RID: 179445 RVA: 0x00A89E19 File Offset: 0x00A88019
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007459 RID: 29785
		// (get) Token: 0x0602BCF6 RID: 179446 RVA: 0x00A89E3C File Offset: 0x00A8803C
		// (set) Token: 0x0602BCF7 RID: 179447 RVA: 0x00A89E75 File Offset: 0x00A88075
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700745A RID: 29786
		// (get) Token: 0x0602BCF8 RID: 179448 RVA: 0x00A89E98 File Offset: 0x00A88098
		// (set) Token: 0x0602BCF9 RID: 179449 RVA: 0x00A89ED1 File Offset: 0x00A880D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700745B RID: 29787
		// (get) Token: 0x0602BCFA RID: 179450 RVA: 0x00A89EF4 File Offset: 0x00A880F4
		// (set) Token: 0x0602BCFB RID: 179451 RVA: 0x00A89F2D File Offset: 0x00A8812D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700745C RID: 29788
		// (get) Token: 0x0602BCFC RID: 179452 RVA: 0x00A89F50 File Offset: 0x00A88150
		// (set) Token: 0x0602BCFD RID: 179453 RVA: 0x00A89F89 File Offset: 0x00A88189
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700745D RID: 29789
		// (get) Token: 0x0602BCFE RID: 179454 RVA: 0x00A89FAC File Offset: 0x00A881AC
		// (set) Token: 0x0602BCFF RID: 179455 RVA: 0x00A89FE5 File Offset: 0x00A881E5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700745E RID: 29790
		// (get) Token: 0x0602BD00 RID: 179456 RVA: 0x00A8A008 File Offset: 0x00A88208
		// (set) Token: 0x0602BD01 RID: 179457 RVA: 0x00A8A041 File Offset: 0x00A88241
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700745F RID: 29791
		// (get) Token: 0x0602BD02 RID: 179458 RVA: 0x00A8A064 File Offset: 0x00A88264
		// (set) Token: 0x0602BD03 RID: 179459 RVA: 0x00A8A09D File Offset: 0x00A8829D
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool_1) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool_1 = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007460 RID: 29792
		// (get) Token: 0x0602BD04 RID: 179460 RVA: 0x00A8A0C0 File Offset: 0x00A882C0
		// (set) Token: 0x0602BD05 RID: 179461 RVA: 0x00A8A0F9 File Offset: 0x00A882F9
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007461 RID: 29793
		// (get) Token: 0x0602BD06 RID: 179462 RVA: 0x00A8A11C File Offset: 0x00A8831C
		// (set) Token: 0x0602BD07 RID: 179463 RVA: 0x00A8A155 File Offset: 0x00A88355
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007462 RID: 29794
		// (get) Token: 0x0602BD08 RID: 179464 RVA: 0x00A8A178 File Offset: 0x00A88378
		// (set) Token: 0x0602BD09 RID: 179465 RVA: 0x00A8A1B1 File Offset: 0x00A883B1
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007463 RID: 29795
		// (get) Token: 0x0602BD0A RID: 179466 RVA: 0x00A8A1D4 File Offset: 0x00A883D4
		// (set) Token: 0x0602BD0B RID: 179467 RVA: 0x00A8A20D File Offset: 0x00A8840D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007464 RID: 29796
		// (get) Token: 0x0602BD0C RID: 179468 RVA: 0x00A8A230 File Offset: 0x00A88430
		// (set) Token: 0x0602BD0D RID: 179469 RVA: 0x00A8A269 File Offset: 0x00A88469
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007465 RID: 29797
		// (get) Token: 0x0602BD0E RID: 179470 RVA: 0x00A8A28C File Offset: 0x00A8848C
		// (set) Token: 0x0602BD0F RID: 179471 RVA: 0x00A8A2C5 File Offset: 0x00A884C5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007466 RID: 29798
		// (get) Token: 0x0602BD10 RID: 179472 RVA: 0x00A8A2E8 File Offset: 0x00A884E8
		// (set) Token: 0x0602BD11 RID: 179473 RVA: 0x00A8A321 File Offset: 0x00A88521
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007467 RID: 29799
		// (get) Token: 0x0602BD12 RID: 179474 RVA: 0x00A8A344 File Offset: 0x00A88544
		// (set) Token: 0x0602BD13 RID: 179475 RVA: 0x00A8A37D File Offset: 0x00A8857D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007468 RID: 29800
		// (get) Token: 0x0602BD14 RID: 179476 RVA: 0x00A8A3A0 File Offset: 0x00A885A0
		// (set) Token: 0x0602BD15 RID: 179477 RVA: 0x00A8A3D9 File Offset: 0x00A885D9
		public FAnimNode_Slot AnimGraphNode_Slot_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_4) == null)
				{
					result = (this._AnimGraphNode_Slot_4 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007469 RID: 29801
		// (get) Token: 0x0602BD16 RID: 179478 RVA: 0x00A8A3FC File Offset: 0x00A885FC
		// (set) Token: 0x0602BD17 RID: 179479 RVA: 0x00A8A435 File Offset: 0x00A88635
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_1) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_1 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700746A RID: 29802
		// (get) Token: 0x0602BD18 RID: 179480 RVA: 0x00A8A458 File Offset: 0x00A88658
		// (set) Token: 0x0602BD19 RID: 179481 RVA: 0x00A8A491 File Offset: 0x00A88691
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700746B RID: 29803
		// (get) Token: 0x0602BD1A RID: 179482 RVA: 0x00A8A4B4 File Offset: 0x00A886B4
		// (set) Token: 0x0602BD1B RID: 179483 RVA: 0x00A8A4ED File Offset: 0x00A886ED
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700746C RID: 29804
		// (get) Token: 0x0602BD1C RID: 179484 RVA: 0x00A8A510 File Offset: 0x00A88710
		// (set) Token: 0x0602BD1D RID: 179485 RVA: 0x00A8A549 File Offset: 0x00A88749
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700746D RID: 29805
		// (get) Token: 0x0602BD1E RID: 179486 RVA: 0x00A8A56C File Offset: 0x00A8876C
		// (set) Token: 0x0602BD1F RID: 179487 RVA: 0x00A8A5A5 File Offset: 0x00A887A5
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700746E RID: 29806
		// (get) Token: 0x0602BD20 RID: 179488 RVA: 0x00A8A5C8 File Offset: 0x00A887C8
		// (set) Token: 0x0602BD21 RID: 179489 RVA: 0x00A8A601 File Offset: 0x00A88801
		public FAnimNode_SlotWithAlpha AnimGraphNode_SlotWithAlpha
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SlotWithAlpha result;
				if ((result = this._AnimGraphNode_SlotWithAlpha) == null)
				{
					result = (this._AnimGraphNode_SlotWithAlpha = new FAnimNode_SlotWithAlpha(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SlotWithAlpha.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700746F RID: 29807
		// (get) Token: 0x0602BD22 RID: 179490 RVA: 0x00A8A624 File Offset: 0x00A88824
		// (set) Token: 0x0602BD23 RID: 179491 RVA: 0x00A8A65D File Offset: 0x00A8885D
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007470 RID: 29808
		// (get) Token: 0x0602BD24 RID: 179492 RVA: 0x00A8A680 File Offset: 0x00A88880
		// (set) Token: 0x0602BD25 RID: 179493 RVA: 0x00A8A6B9 File Offset: 0x00A888B9
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007471 RID: 29809
		// (get) Token: 0x0602BD26 RID: 179494 RVA: 0x00A8A6DC File Offset: 0x00A888DC
		// (set) Token: 0x0602BD27 RID: 179495 RVA: 0x00A8A715 File Offset: 0x00A88915
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007472 RID: 29810
		// (get) Token: 0x0602BD28 RID: 179496 RVA: 0x00A8A738 File Offset: 0x00A88938
		// (set) Token: 0x0602BD29 RID: 179497 RVA: 0x00A8A771 File Offset: 0x00A88971
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007473 RID: 29811
		// (get) Token: 0x0602BD2A RID: 179498 RVA: 0x00A8A794 File Offset: 0x00A88994
		// (set) Token: 0x0602BD2B RID: 179499 RVA: 0x00A8A7CD File Offset: 0x00A889CD
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007474 RID: 29812
		// (get) Token: 0x0602BD2C RID: 179500 RVA: 0x00A8A7F0 File Offset: 0x00A889F0
		// (set) Token: 0x0602BD2D RID: 179501 RVA: 0x00A8A829 File Offset: 0x00A88A29
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007475 RID: 29813
		// (get) Token: 0x0602BD2E RID: 179502 RVA: 0x00A8A84C File Offset: 0x00A88A4C
		// (set) Token: 0x0602BD2F RID: 179503 RVA: 0x00A8A885 File Offset: 0x00A88A85
		public FAnimNode_RBF AnimGraphNode_RBF
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RBF result;
				if ((result = this._AnimGraphNode_RBF) == null)
				{
					result = (this._AnimGraphNode_RBF = new FAnimNode_RBF(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RBF.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007476 RID: 29814
		// (get) Token: 0x0602BD30 RID: 179504 RVA: 0x00A8A8A8 File Offset: 0x00A88AA8
		// (set) Token: 0x0602BD31 RID: 179505 RVA: 0x00A8A8E1 File Offset: 0x00A88AE1
		public FAnimNode_LinkedAnimGraph AnimGraphNode_LinkedAnimGraph
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimGraph result;
				if ((result = this._AnimGraphNode_LinkedAnimGraph) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimGraph = new FAnimNode_LinkedAnimGraph(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimGraph.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007477 RID: 29815
		// (get) Token: 0x0602BD32 RID: 179506 RVA: 0x00A8A904 File Offset: 0x00A88B04
		// (set) Token: 0x0602BD33 RID: 179507 RVA: 0x00A8A93D File Offset: 0x00A88B3D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007478 RID: 29816
		// (get) Token: 0x0602BD34 RID: 179508 RVA: 0x00A8A960 File Offset: 0x00A88B60
		// (set) Token: 0x0602BD35 RID: 179509 RVA: 0x00A8A999 File Offset: 0x00A88B99
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007479 RID: 29817
		// (get) Token: 0x0602BD36 RID: 179510 RVA: 0x00A8A9BC File Offset: 0x00A88BBC
		// (set) Token: 0x0602BD37 RID: 179511 RVA: 0x00A8A9F5 File Offset: 0x00A88BF5
		public FAnimNode_TextureFace AnimGraphNode_TextureFace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TextureFace result;
				if ((result = this._AnimGraphNode_TextureFace) == null)
				{
					result = (this._AnimGraphNode_TextureFace = new FAnimNode_TextureFace(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TextureFace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700747A RID: 29818
		// (get) Token: 0x0602BD38 RID: 179512 RVA: 0x00A8AA18 File Offset: 0x00A88C18
		// (set) Token: 0x0602BD39 RID: 179513 RVA: 0x00A8AA51 File Offset: 0x00A88C51
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700747B RID: 29819
		// (get) Token: 0x0602BD3A RID: 179514 RVA: 0x00A8AA74 File Offset: 0x00A88C74
		// (set) Token: 0x0602BD3B RID: 179515 RVA: 0x00A8AAAD File Offset: 0x00A88CAD
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves_1) == null)
				{
					result = (this._AnimGraphNode_CombineCurves_1 = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700747C RID: 29820
		// (get) Token: 0x0602BD3C RID: 179516 RVA: 0x00A8AAD0 File Offset: 0x00A88CD0
		// (set) Token: 0x0602BD3D RID: 179517 RVA: 0x00A8AB09 File Offset: 0x00A88D09
		public FAnimNode_ModifyBone AnimGraphNode_ModifyBone
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ModifyBone result;
				if ((result = this._AnimGraphNode_ModifyBone) == null)
				{
					result = (this._AnimGraphNode_ModifyBone = new FAnimNode_ModifyBone(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ModifyBone.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700747D RID: 29821
		// (get) Token: 0x0602BD3E RID: 179518 RVA: 0x00A8AB2C File Offset: 0x00A88D2C
		// (set) Token: 0x0602BD3F RID: 179519 RVA: 0x00A8AB65 File Offset: 0x00A88D65
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves) == null)
				{
					result = (this._AnimGraphNode_CombineCurves = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700747E RID: 29822
		// (get) Token: 0x0602BD40 RID: 179520 RVA: 0x00A8AB86 File Offset: 0x00A88D86
		// (set) Token: 0x0602BD41 RID: 179521 RVA: 0x00A8AB9A File Offset: 0x00A88D9A
		[Nullable(2)]
		public unsafe BP_BaseNPC_C 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_BaseNPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseNPC_C.__PropertyOffset_67);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseNPC_C.__PropertyOffset_67, value);
			}
		}

		// Token: 0x1700747F RID: 29823
		// (get) Token: 0x0602BD42 RID: 179522 RVA: 0x00A8ABAF File Offset: 0x00A88DAF
		// (set) Token: 0x0602BD43 RID: 179523 RVA: 0x00A8ABC3 File Offset: 0x00A88DC3
		public unsafe FVector 移动输入向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x17007480 RID: 29824
		// (get) Token: 0x0602BD44 RID: 179524 RVA: 0x00A8ABD8 File Offset: 0x00A88DD8
		// (set) Token: 0x0602BD45 RID: 179525 RVA: 0x00A8ABE8 File Offset: 0x00A88DE8
		public unsafe float 速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x17007481 RID: 29825
		// (get) Token: 0x0602BD46 RID: 179526 RVA: 0x00A8ABF9 File Offset: 0x00A88DF9
		// (set) Token: 0x0602BD47 RID: 179527 RVA: 0x00A8AC09 File Offset: 0x00A88E09
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_70) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_70) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007482 RID: 29826
		// (get) Token: 0x0602BD48 RID: 179528 RVA: 0x00A8AC1A File Offset: 0x00A88E1A
		// (set) Token: 0x0602BD49 RID: 179529 RVA: 0x00A8AC2A File Offset: 0x00A88E2A
		public unsafe bool ifPlayIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_71) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_71) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007483 RID: 29827
		// (get) Token: 0x0602BD4A RID: 179530 RVA: 0x00A8AC3C File Offset: 0x00A88E3C
		// (set) Token: 0x0602BD4B RID: 179531 RVA: 0x00A8AC75 File Offset: 0x00A88E75
		public TArray<UAnimMontage> IdleMontageArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimMontage> result;
				if ((result = this._IdleMontageArray) == null)
				{
					result = (this._IdleMontageArray = new TArray<UAnimMontage>(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				this.IdleMontageArray.CopyAssign(value);
			}
		}

		// Token: 0x17007484 RID: 29828
		// (get) Token: 0x0602BD4C RID: 179532 RVA: 0x00A8AC83 File Offset: 0x00A88E83
		// (set) Token: 0x0602BD4D RID: 179533 RVA: 0x00A8AC97 File Offset: 0x00A88E97
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseNPC_C.__PropertyOffset_73);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseNPC_C.__PropertyOffset_73, value);
			}
		}

		// Token: 0x17007485 RID: 29829
		// (get) Token: 0x0602BD4E RID: 179534 RVA: 0x00A8ACAC File Offset: 0x00A88EAC
		// (set) Token: 0x0602BD4F RID: 179535 RVA: 0x00A8ACBC File Offset: 0x00A88EBC
		public unsafe bool 是否原地转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_74) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_74) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007486 RID: 29830
		// (get) Token: 0x0602BD50 RID: 179536 RVA: 0x00A8ACCD File Offset: 0x00A88ECD
		// (set) Token: 0x0602BD51 RID: 179537 RVA: 0x00A8ACDD File Offset: 0x00A88EDD
		public unsafe float 旋转角度差值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x17007487 RID: 29831
		// (get) Token: 0x0602BD52 RID: 179538 RVA: 0x00A8ACEE File Offset: 0x00A88EEE
		// (set) Token: 0x0602BD53 RID: 179539 RVA: 0x00A8ACFE File Offset: 0x00A88EFE
		public unsafe float 上一次旋转角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x17007488 RID: 29832
		// (get) Token: 0x0602BD54 RID: 179540 RVA: 0x00A8AD0F File Offset: 0x00A88F0F
		// (set) Token: 0x0602BD55 RID: 179541 RVA: 0x00A8AD23 File Offset: 0x00A88F23
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x17007489 RID: 29833
		// (get) Token: 0x0602BD56 RID: 179542 RVA: 0x00A8AD38 File Offset: 0x00A88F38
		// (set) Token: 0x0602BD57 RID: 179543 RVA: 0x00A8AD48 File Offset: 0x00A88F48
		public unsafe float HeadBaseYawBuffer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_78);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_78) = value;
			}
		}

		// Token: 0x1700748A RID: 29834
		// (get) Token: 0x0602BD58 RID: 179544 RVA: 0x00A8AD59 File Offset: 0x00A88F59
		// (set) Token: 0x0602BD59 RID: 179545 RVA: 0x00A8AD69 File Offset: 0x00A88F69
		public unsafe bool IsBeingImpacted
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_79) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_79) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700748B RID: 29835
		// (get) Token: 0x0602BD5A RID: 179546 RVA: 0x00A8AD7A File Offset: 0x00A88F7A
		// (set) Token: 0x0602BD5B RID: 179547 RVA: 0x00A8AD8A File Offset: 0x00A88F8A
		public unsafe bool IsBeingAttacked
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_80) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_80) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700748C RID: 29836
		// (get) Token: 0x0602BD5C RID: 179548 RVA: 0x00A8AD9B File Offset: 0x00A88F9B
		// (set) Token: 0x0602BD5D RID: 179549 RVA: 0x00A8ADAB File Offset: 0x00A88FAB
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_81));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_81) = (byte)value;
			}
		}

		// Token: 0x1700748D RID: 29837
		// (get) Token: 0x0602BD5E RID: 179550 RVA: 0x00A8ADBC File Offset: 0x00A88FBC
		// (set) Token: 0x0602BD5F RID: 179551 RVA: 0x00A8ADCC File Offset: 0x00A88FCC
		public unsafe float 走跑混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_82);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_82) = value;
			}
		}

		// Token: 0x1700748E RID: 29838
		// (get) Token: 0x0602BD60 RID: 179552 RVA: 0x00A8ADDD File Offset: 0x00A88FDD
		// (set) Token: 0x0602BD61 RID: 179553 RVA: 0x00A8ADED File Offset: 0x00A88FED
		public unsafe bool IsTurnLeft
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_83) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_83) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700748F RID: 29839
		// (get) Token: 0x0602BD62 RID: 179554 RVA: 0x00A8ADFE File Offset: 0x00A88FFE
		// (set) Token: 0x0602BD63 RID: 179555 RVA: 0x00A8AE12 File Offset: 0x00A89012
		public unsafe FRotator 角色旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x17007490 RID: 29840
		// (get) Token: 0x0602BD64 RID: 179556 RVA: 0x00A8AE27 File Offset: 0x00A89027
		// (set) Token: 0x0602BD65 RID: 179557 RVA: 0x00A8AE37 File Offset: 0x00A89037
		public unsafe int NpcEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17007491 RID: 29841
		// (get) Token: 0x0602BD66 RID: 179558 RVA: 0x00A8AE48 File Offset: 0x00A89048
		// (set) Token: 0x0602BD67 RID: 179559 RVA: 0x00A8AE58 File Offset: 0x00A89058
		public unsafe float CollisionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_86);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_86) = value;
			}
		}

		// Token: 0x17007492 RID: 29842
		// (get) Token: 0x0602BD68 RID: 179560 RVA: 0x00A8AE69 File Offset: 0x00A89069
		// (set) Token: 0x0602BD69 RID: 179561 RVA: 0x00A8AE79 File Offset: 0x00A89079
		public unsafe float CollisionDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_87);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x17007493 RID: 29843
		// (get) Token: 0x0602BD6A RID: 179562 RVA: 0x00A8AE8A File Offset: 0x00A8908A
		// (set) Token: 0x0602BD6B RID: 179563 RVA: 0x00A8AE9A File Offset: 0x00A8909A
		public unsafe float RandomEpresionEndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_88);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_88) = value;
			}
		}

		// Token: 0x17007494 RID: 29844
		// (get) Token: 0x0602BD6C RID: 179564 RVA: 0x00A8AEAB File Offset: 0x00A890AB
		// (set) Token: 0x0602BD6D RID: 179565 RVA: 0x00A8AEBB File Offset: 0x00A890BB
		public unsafe float 眨眼动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x17007495 RID: 29845
		// (get) Token: 0x0602BD6E RID: 179566 RVA: 0x00A8AECC File Offset: 0x00A890CC
		// (set) Token: 0x0602BD6F RID: 179567 RVA: 0x00A8AEDC File Offset: 0x00A890DC
		public unsafe float 此轮眨眼动画总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_90);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x17007496 RID: 29846
		// (get) Token: 0x0602BD70 RID: 179568 RVA: 0x00A8AEED File Offset: 0x00A890ED
		// (set) Token: 0x0602BD71 RID: 179569 RVA: 0x00A8AEFD File Offset: 0x00A890FD
		public unsafe float ExpresionAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_91);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_91) = value;
			}
		}

		// Token: 0x17007497 RID: 29847
		// (get) Token: 0x0602BD72 RID: 179570 RVA: 0x00A8AF0E File Offset: 0x00A8910E
		// (set) Token: 0x0602BD73 RID: 179571 RVA: 0x00A8AF1E File Offset: 0x00A8911E
		public unsafe bool 眨眼中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_92) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_92) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007498 RID: 29848
		// (get) Token: 0x0602BD74 RID: 179572 RVA: 0x00A8AF2F File Offset: 0x00A8912F
		// (set) Token: 0x0602BD75 RID: 179573 RVA: 0x00A8AF3F File Offset: 0x00A8913F
		public unsafe bool Cache原地转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_93) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_93) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007499 RID: 29849
		// (get) Token: 0x0602BD76 RID: 179574 RVA: 0x00A8AF50 File Offset: 0x00A89150
		// (set) Token: 0x0602BD77 RID: 179575 RVA: 0x00A8AF89 File Offset: 0x00A89189
		public TArray<FName> 口型曲线
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._口型曲线) == null)
				{
					result = (this._口型曲线 = new TArray<FName>(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				this.口型曲线.CopyAssign(value);
			}
		}

		// Token: 0x1700749A RID: 29850
		// (get) Token: 0x0602BD78 RID: 179576 RVA: 0x00A8AF97 File Offset: 0x00A89197
		// (set) Token: 0x0602BD79 RID: 179577 RVA: 0x00A8AFA7 File Offset: 0x00A891A7
		public unsafe bool 状态_地区运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_95) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_95) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700749B RID: 29851
		// (get) Token: 0x0602BD7A RID: 179578 RVA: 0x00A8AFB8 File Offset: 0x00A891B8
		// (set) Token: 0x0602BD7B RID: 179579 RVA: 0x00A8AFC8 File Offset: 0x00A891C8
		public unsafe bool 状态_地区运动模式_临时
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_96) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_96) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700749C RID: 29852
		// (get) Token: 0x0602BD7C RID: 179580 RVA: 0x00A8AFD9 File Offset: 0x00A891D9
		// (set) Token: 0x0602BD7D RID: 179581 RVA: 0x00A8AFE9 File Offset: 0x00A891E9
		public unsafe float TurnYawRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x1700749D RID: 29853
		// (get) Token: 0x0602BD7E RID: 179582 RVA: 0x00A8AFFA File Offset: 0x00A891FA
		// (set) Token: 0x0602BD7F RID: 179583 RVA: 0x00A8B00A File Offset: 0x00A8920A
		public unsafe bool IsEnableTurnMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_98) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseNPC_C.__PropertyOffset_98) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602BD80 RID: 179584 RVA: 0x00A8B01C File Offset: 0x00A8921C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceJumpPressed(ref float Speed)
		{
			ABP_BaseNPC_C.__InterfaceJumpPressed_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__InterfaceJumpPressed_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseNPC_C.__InterfaceJumpPressed_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__InterfaceJumpPressed_NativeFunctionPtr, (void*)ptr);
			Speed = ptr->Speed;
		}

		// Token: 0x0602BD81 RID: 179585 RVA: 0x00A8B06C File Offset: 0x00A8926C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(FPoseLink 地区运动状态, ref FPoseLink 基础层)
		{
			ABP_BaseNPC_C.__基础层_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__基础层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseNPC_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (地区运动状态 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->地区运动状态, 地区运动状态.NativePtr, 1, false);
			}
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602BD82 RID: 179586 RVA: 0x00A8B118 File Offset: 0x00A89318
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseNPC_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseNPC_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602BD83 RID: 179587 RVA: 0x00A8B19F File Offset: 0x00A8939F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__初始化Tag_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD84 RID: 179588 RVA: 0x00A8B1B3 File Offset: 0x00A893B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新眨眼()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__更新眨眼_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD85 RID: 179589 RVA: 0x00A8B1C8 File Offset: 0x00A893C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HasInputRotate(ref bool Output_Get)
		{
			ABP_BaseNPC_C.__HasInputRotate_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__HasInputRotate_FunctionParams[(UIntPtr)91] + 15L / (long)sizeof(ABP_BaseNPC_C.__HasInputRotate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__HasInputRotate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Output_Get = Output_Get;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__HasInputRotate_NativeFunctionPtr, (void*)ptr);
			Output_Get = ptr->Output_Get;
		}

		// Token: 0x0602BD86 RID: 179590 RVA: 0x00A8B218 File Offset: 0x00A89418
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 是否AI驱动(ref bool Result)
		{
			ABP_BaseNPC_C.__是否AI驱动_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__是否AI驱动_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(ABP_BaseNPC_C.__是否AI驱动_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__是否AI驱动_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__是否AI驱动_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
		}

		// Token: 0x0602BD87 RID: 179591 RVA: 0x00A8B267 File Offset: 0x00A89467
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色转身()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__更新角色转身_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD88 RID: 179592 RVA: 0x00A8B27B File Offset: 0x00A8947B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__更新角色移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD89 RID: 179593 RVA: 0x00A8B28F File Offset: 0x00A8948F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色碰撞()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__更新角色碰撞_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD8A RID: 179594 RVA: 0x00A8B2A3 File Offset: 0x00A894A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD8B RID: 179595 RVA: 0x00A8B2B7 File Offset: 0x00A894B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__更新角色信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD8C RID: 179596 RVA: 0x00A8B2CC File Offset: 0x00A894CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceControlPoint(FVector Offset)
		{
			ABP_BaseNPC_C.__InterfaceControlPoint_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__InterfaceControlPoint_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__InterfaceControlPoint_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__InterfaceControlPoint_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD8D RID: 179597 RVA: 0x00A8B314 File Offset: 0x00A89514
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceManipulateInteractDirection(float 角度)
		{
			ABP_BaseNPC_C.__InterfaceManipulateInteractDirection_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__InterfaceManipulateInteractDirection_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseNPC_C.__InterfaceManipulateInteractDirection_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr, 1);
			ptr->角度 = 角度;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__InterfaceManipulateInteractDirection_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD8E RID: 179598 RVA: 0x00A8B35C File Offset: 0x00A8955C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceFixHookDirect(FVector Offset)
		{
			ABP_BaseNPC_C.__InterfaceFixHookDirect_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__InterfaceFixHookDirect_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__InterfaceFixHookDirect_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Offset = Offset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__InterfaceFixHookDirect_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD8F RID: 179599 RVA: 0x00A8B3A4 File Offset: 0x00A895A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InterfaceSimulateJump(float Speed)
		{
			ABP_BaseNPC_C.__InterfaceSimulateJump_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__InterfaceSimulateJump_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseNPC_C.__InterfaceSimulateJump_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Speed = Speed;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__InterfaceSimulateJump_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD90 RID: 179600 RVA: 0x00A8B3EA File Offset: 0x00A895EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClimbDash()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__ClimbDash_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD91 RID: 179601 RVA: 0x00A8B400 File Offset: 0x00A89600
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCompleted_712E5DC7440577B25761868E65201677(FName NotifyName)
		{
			ABP_BaseNPC_C.__OnCompleted_712E5DC7440577B25761868E65201677_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__OnCompleted_712E5DC7440577B25761868E65201677_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__OnCompleted_712E5DC7440577B25761868E65201677_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__OnCompleted_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__OnCompleted_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD92 RID: 179602 RVA: 0x00A8B448 File Offset: 0x00A89648
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBlendOut_712E5DC7440577B25761868E65201677(FName NotifyName)
		{
			ABP_BaseNPC_C.__OnBlendOut_712E5DC7440577B25761868E65201677_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__OnBlendOut_712E5DC7440577B25761868E65201677_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__OnBlendOut_712E5DC7440577B25761868E65201677_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__OnBlendOut_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__OnBlendOut_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD93 RID: 179603 RVA: 0x00A8B490 File Offset: 0x00A89690
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnInterrupted_712E5DC7440577B25761868E65201677(FName NotifyName)
		{
			ABP_BaseNPC_C.__OnInterrupted_712E5DC7440577B25761868E65201677_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__OnInterrupted_712E5DC7440577B25761868E65201677_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__OnInterrupted_712E5DC7440577B25761868E65201677_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__OnInterrupted_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__OnInterrupted_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD94 RID: 179604 RVA: 0x00A8B4D8 File Offset: 0x00A896D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyBegin_712E5DC7440577B25761868E65201677(FName NotifyName)
		{
			ABP_BaseNPC_C.__OnNotifyBegin_712E5DC7440577B25761868E65201677_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__OnNotifyBegin_712E5DC7440577B25761868E65201677_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__OnNotifyBegin_712E5DC7440577B25761868E65201677_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__OnNotifyBegin_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__OnNotifyBegin_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD95 RID: 179605 RVA: 0x00A8B520 File Offset: 0x00A89720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyEnd_712E5DC7440577B25761868E65201677(FName NotifyName)
		{
			ABP_BaseNPC_C.__OnNotifyEnd_712E5DC7440577B25761868E65201677_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__OnNotifyEnd_712E5DC7440577B25761868E65201677_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseNPC_C.__OnNotifyEnd_712E5DC7440577B25761868E65201677_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__OnNotifyEnd_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__OnNotifyEnd_712E5DC7440577B25761868E65201677_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BD96 RID: 179606 RVA: 0x00A8B566 File Offset: 0x00A89766
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_ModifyBone_A4AC35054E490E2C2EB4D6B2722428F1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_ModifyBone_A4AC35054E490E2C2EB4D6B2722428F1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD97 RID: 179607 RVA: 0x00A8B57A File Offset: 0x00A8977A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TextureFace_C2CE9AB24BDEE4700DCED0ADCBA33FA8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TextureFace_C2CE9AB24BDEE4700DCED0ADCBA33FA8_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD98 RID: 179608 RVA: 0x00A8B58E File Offset: 0x00A8978E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_SlotWithAlpha_5F1873EE4BEB77F46CCF40A404E37026()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_SlotWithAlpha_5F1873EE4BEB77F46CCF40A404E37026_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD99 RID: 179609 RVA: 0x00A8B5A2 File Offset: 0x00A897A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_BlendListByBool_20DF88D44DE40206AEFAB89575A6C9A5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_BlendListByBool_20DF88D44DE40206AEFAB89575A6C9A5_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD9A RID: 179610 RVA: 0x00A8B5B6 File Offset: 0x00A897B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_C0B8FDED431127A2A5FDC1A72CAE78C2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_C0B8FDED431127A2A5FDC1A72CAE78C2_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD9B RID: 179611 RVA: 0x00A8B5CA File Offset: 0x00A897CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_0965F59C484C38E57DB2959A3E4DB3D7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_0965F59C484C38E57DB2959A3E4DB3D7_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD9C RID: 179612 RVA: 0x00A8B5DE File Offset: 0x00A897DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_6917C8F64FE3C0CDC8A3E6A7ED7D503C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_6917C8F64FE3C0CDC8A3E6A7ED7D503C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD9D RID: 179613 RVA: 0x00A8B5F2 File Offset: 0x00A897F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_2178FF404602F078D81CDF8AB475F43F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_2178FF404602F078D81CDF8AB475F43F_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD9E RID: 179614 RVA: 0x00A8B606 File Offset: 0x00A89806
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_489651114DF56F56400B5085D579A175()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_489651114DF56F56400B5085D579A175_NativeFunctionPtr, null);
		}

		// Token: 0x0602BD9F RID: 179615 RVA: 0x00A8B61A File Offset: 0x00A8981A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_FDBBD5E7477AD7967C489DA71407AA47()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_FDBBD5E7477AD7967C489DA71407AA47_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA0 RID: 179616 RVA: 0x00A8B62E File Offset: 0x00A8982E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_29ED077D4A98A4CA0111C685D4416D03()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_29ED077D4A98A4CA0111C685D4416D03_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA1 RID: 179617 RVA: 0x00A8B642 File Offset: 0x00A89842
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_9C70E8254D0EAC25ED9262AE4741EA01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_9C70E8254D0EAC25ED9262AE4741EA01_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA2 RID: 179618 RVA: 0x00A8B656 File Offset: 0x00A89856
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_2C6793D9468B9D59C335F9B7E06CA14C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_2C6793D9468B9D59C335F9B7E06CA14C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA3 RID: 179619 RVA: 0x00A8B66A File Offset: 0x00A8986A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA4 RID: 179620 RVA: 0x00A8B67E File Offset: 0x00A8987E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BDA5 RID: 179621 RVA: 0x00A8B694 File Offset: 0x00A89894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BDA6 RID: 179622 RVA: 0x00A8B6DC File Offset: 0x00A898DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BDA7 RID: 179623 RVA: 0x00A8B723 File Offset: 0x00A89923
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_PlayMontage()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__AnimNotify_PlayMontage_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA8 RID: 179624 RVA: 0x00A8B737 File Offset: 0x00A89937
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDA9 RID: 179625 RVA: 0x00A8B74B File Offset: 0x00A8994B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseNPC_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BDAA RID: 179626 RVA: 0x00A8B760 File Offset: 0x00A89960
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnCollisionAnimEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__AnimNotify_OnCollisionAnimEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDAB RID: 179627 RVA: 0x00A8B774 File Offset: 0x00A89974
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnCollisionAnimBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__AnimNotify_OnCollisionAnimBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDAC RID: 179628 RVA: 0x00A8B788 File Offset: 0x00A89988
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnHitAnimBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__AnimNotify_OnHitAnimBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDAD RID: 179629 RVA: 0x00A8B79C File Offset: 0x00A8999C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnHitAnimEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseNPC_C.__AnimNotify_OnHitAnimEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602BDAE RID: 179630 RVA: 0x00A8B7B0 File Offset: 0x00A899B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseNPC(int EntryPoint)
		{
			ABP_BaseNPC_C.__ExecuteUbergraph_ABP_BaseNPC_FunctionParams* ptr = stackalloc ABP_BaseNPC_C.__ExecuteUbergraph_ABP_BaseNPC_FunctionParams[(UIntPtr)503] + 15L / (long)sizeof(ABP_BaseNPC_C.__ExecuteUbergraph_ABP_BaseNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseNPC_C.__ExecuteUbergraph_ABP_BaseNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseNPC_C.__ExecuteUbergraph_ABP_BaseNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BDAF RID: 179631 RVA: 0x00A8B7FA File Offset: 0x00A899FA
		protected ABP_BaseNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401820B RID: 98827
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Common/ABP_BaseNPC.ABP_BaseNPC_C";

		// Token: 0x0401820C RID: 98828
		private static IntPtr _ClassPtr;

		// Token: 0x0401820D RID: 98829
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401820E RID: 98830
		internal static int __PropertyOffset_0;

		// Token: 0x0401820F RID: 98831
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018210 RID: 98832
		internal static int __PropertyOffset_1;

		// Token: 0x04018211 RID: 98833
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018212 RID: 98834
		internal static int __PropertyOffset_2;

		// Token: 0x04018213 RID: 98835
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_5;

		// Token: 0x04018214 RID: 98836
		internal static int __PropertyOffset_3;

		// Token: 0x04018215 RID: 98837
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018216 RID: 98838
		internal static int __PropertyOffset_4;

		// Token: 0x04018217 RID: 98839
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x04018218 RID: 98840
		internal static int __PropertyOffset_5;

		// Token: 0x04018219 RID: 98841
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x0401821A RID: 98842
		internal static int __PropertyOffset_6;

		// Token: 0x0401821B RID: 98843
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x0401821C RID: 98844
		internal static int __PropertyOffset_7;

		// Token: 0x0401821D RID: 98845
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x0401821E RID: 98846
		internal static int __PropertyOffset_8;

		// Token: 0x0401821F RID: 98847
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04018220 RID: 98848
		internal static int __PropertyOffset_9;

		// Token: 0x04018221 RID: 98849
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04018222 RID: 98850
		internal static int __PropertyOffset_10;

		// Token: 0x04018223 RID: 98851
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04018224 RID: 98852
		internal static int __PropertyOffset_11;

		// Token: 0x04018225 RID: 98853
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04018226 RID: 98854
		internal static int __PropertyOffset_12;

		// Token: 0x04018227 RID: 98855
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04018228 RID: 98856
		internal static int __PropertyOffset_13;

		// Token: 0x04018229 RID: 98857
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x0401822A RID: 98858
		internal static int __PropertyOffset_14;

		// Token: 0x0401822B RID: 98859
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x0401822C RID: 98860
		internal static int __PropertyOffset_15;

		// Token: 0x0401822D RID: 98861
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x0401822E RID: 98862
		internal static int __PropertyOffset_16;

		// Token: 0x0401822F RID: 98863
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_2;

		// Token: 0x04018230 RID: 98864
		internal static int __PropertyOffset_17;

		// Token: 0x04018231 RID: 98865
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04018232 RID: 98866
		internal static int __PropertyOffset_18;

		// Token: 0x04018233 RID: 98867
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04018234 RID: 98868
		internal static int __PropertyOffset_19;

		// Token: 0x04018235 RID: 98869
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04018236 RID: 98870
		internal static int __PropertyOffset_20;

		// Token: 0x04018237 RID: 98871
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04018238 RID: 98872
		internal static int __PropertyOffset_21;

		// Token: 0x04018239 RID: 98873
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x0401823A RID: 98874
		internal static int __PropertyOffset_22;

		// Token: 0x0401823B RID: 98875
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0401823C RID: 98876
		internal static int __PropertyOffset_23;

		// Token: 0x0401823D RID: 98877
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x0401823E RID: 98878
		internal static int __PropertyOffset_24;

		// Token: 0x0401823F RID: 98879
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018240 RID: 98880
		internal static int __PropertyOffset_25;

		// Token: 0x04018241 RID: 98881
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018242 RID: 98882
		internal static int __PropertyOffset_26;

		// Token: 0x04018243 RID: 98883
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04018244 RID: 98884
		internal static int __PropertyOffset_27;

		// Token: 0x04018245 RID: 98885
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04018246 RID: 98886
		internal static int __PropertyOffset_28;

		// Token: 0x04018247 RID: 98887
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04018248 RID: 98888
		internal static int __PropertyOffset_29;

		// Token: 0x04018249 RID: 98889
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401824A RID: 98890
		internal static int __PropertyOffset_30;

		// Token: 0x0401824B RID: 98891
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401824C RID: 98892
		internal static int __PropertyOffset_31;

		// Token: 0x0401824D RID: 98893
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x0401824E RID: 98894
		internal static int __PropertyOffset_32;

		// Token: 0x0401824F RID: 98895
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04018250 RID: 98896
		internal static int __PropertyOffset_33;

		// Token: 0x04018251 RID: 98897
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04018252 RID: 98898
		internal static int __PropertyOffset_34;

		// Token: 0x04018253 RID: 98899
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04018254 RID: 98900
		internal static int __PropertyOffset_35;

		// Token: 0x04018255 RID: 98901
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04018256 RID: 98902
		internal static int __PropertyOffset_36;

		// Token: 0x04018257 RID: 98903
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool_1;

		// Token: 0x04018258 RID: 98904
		internal static int __PropertyOffset_37;

		// Token: 0x04018259 RID: 98905
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x0401825A RID: 98906
		internal static int __PropertyOffset_38;

		// Token: 0x0401825B RID: 98907
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x0401825C RID: 98908
		internal static int __PropertyOffset_39;

		// Token: 0x0401825D RID: 98909
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0401825E RID: 98910
		internal static int __PropertyOffset_40;

		// Token: 0x0401825F RID: 98911
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04018260 RID: 98912
		internal static int __PropertyOffset_41;

		// Token: 0x04018261 RID: 98913
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018262 RID: 98914
		internal static int __PropertyOffset_42;

		// Token: 0x04018263 RID: 98915
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04018264 RID: 98916
		internal static int __PropertyOffset_43;

		// Token: 0x04018265 RID: 98917
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018266 RID: 98918
		internal static int __PropertyOffset_44;

		// Token: 0x04018267 RID: 98919
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018268 RID: 98920
		internal static int __PropertyOffset_45;

		// Token: 0x04018269 RID: 98921
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_4;

		// Token: 0x0401826A RID: 98922
		internal static int __PropertyOffset_46;

		// Token: 0x0401826B RID: 98923
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_1;

		// Token: 0x0401826C RID: 98924
		internal static int __PropertyOffset_47;

		// Token: 0x0401826D RID: 98925
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x0401826E RID: 98926
		internal static int __PropertyOffset_48;

		// Token: 0x0401826F RID: 98927
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x04018270 RID: 98928
		internal static int __PropertyOffset_49;

		// Token: 0x04018271 RID: 98929
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x04018272 RID: 98930
		internal static int __PropertyOffset_50;

		// Token: 0x04018273 RID: 98931
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04018274 RID: 98932
		internal static int __PropertyOffset_51;

		// Token: 0x04018275 RID: 98933
		[Nullable(2)]
		private FAnimNode_SlotWithAlpha _AnimGraphNode_SlotWithAlpha;

		// Token: 0x04018276 RID: 98934
		internal static int __PropertyOffset_52;

		// Token: 0x04018277 RID: 98935
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018278 RID: 98936
		internal static int __PropertyOffset_53;

		// Token: 0x04018279 RID: 98937
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x0401827A RID: 98938
		internal static int __PropertyOffset_54;

		// Token: 0x0401827B RID: 98939
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x0401827C RID: 98940
		internal static int __PropertyOffset_55;

		// Token: 0x0401827D RID: 98941
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x0401827E RID: 98942
		internal static int __PropertyOffset_56;

		// Token: 0x0401827F RID: 98943
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04018280 RID: 98944
		internal static int __PropertyOffset_57;

		// Token: 0x04018281 RID: 98945
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04018282 RID: 98946
		internal static int __PropertyOffset_58;

		// Token: 0x04018283 RID: 98947
		[Nullable(2)]
		private FAnimNode_RBF _AnimGraphNode_RBF;

		// Token: 0x04018284 RID: 98948
		internal static int __PropertyOffset_59;

		// Token: 0x04018285 RID: 98949
		[Nullable(2)]
		private FAnimNode_LinkedAnimGraph _AnimGraphNode_LinkedAnimGraph;

		// Token: 0x04018286 RID: 98950
		internal static int __PropertyOffset_60;

		// Token: 0x04018287 RID: 98951
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018288 RID: 98952
		internal static int __PropertyOffset_61;

		// Token: 0x04018289 RID: 98953
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x0401828A RID: 98954
		internal static int __PropertyOffset_62;

		// Token: 0x0401828B RID: 98955
		[Nullable(2)]
		private FAnimNode_TextureFace _AnimGraphNode_TextureFace;

		// Token: 0x0401828C RID: 98956
		internal static int __PropertyOffset_63;

		// Token: 0x0401828D RID: 98957
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x0401828E RID: 98958
		internal static int __PropertyOffset_64;

		// Token: 0x0401828F RID: 98959
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves_1;

		// Token: 0x04018290 RID: 98960
		internal static int __PropertyOffset_65;

		// Token: 0x04018291 RID: 98961
		[Nullable(2)]
		private FAnimNode_ModifyBone _AnimGraphNode_ModifyBone;

		// Token: 0x04018292 RID: 98962
		internal static int __PropertyOffset_66;

		// Token: 0x04018293 RID: 98963
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves;

		// Token: 0x04018294 RID: 98964
		internal static int __PropertyOffset_67;

		// Token: 0x04018295 RID: 98965
		internal static int __PropertyOffset_68;

		// Token: 0x04018296 RID: 98966
		internal static int __PropertyOffset_69;

		// Token: 0x04018297 RID: 98967
		internal static int __PropertyOffset_70;

		// Token: 0x04018298 RID: 98968
		internal static int __PropertyOffset_71;

		// Token: 0x04018299 RID: 98969
		internal static int __PropertyOffset_72;

		// Token: 0x0401829A RID: 98970
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimMontage> _IdleMontageArray;

		// Token: 0x0401829B RID: 98971
		internal static int __PropertyOffset_73;

		// Token: 0x0401829C RID: 98972
		internal static int __PropertyOffset_74;

		// Token: 0x0401829D RID: 98973
		internal static int __PropertyOffset_75;

		// Token: 0x0401829E RID: 98974
		internal static int __PropertyOffset_76;

		// Token: 0x0401829F RID: 98975
		internal static int __PropertyOffset_77;

		// Token: 0x040182A0 RID: 98976
		internal static int __PropertyOffset_78;

		// Token: 0x040182A1 RID: 98977
		internal static int __PropertyOffset_79;

		// Token: 0x040182A2 RID: 98978
		internal static int __PropertyOffset_80;

		// Token: 0x040182A3 RID: 98979
		internal static int __PropertyOffset_81;

		// Token: 0x040182A4 RID: 98980
		internal static int __PropertyOffset_82;

		// Token: 0x040182A5 RID: 98981
		internal static int __PropertyOffset_83;

		// Token: 0x040182A6 RID: 98982
		internal static int __PropertyOffset_84;

		// Token: 0x040182A7 RID: 98983
		internal static int __PropertyOffset_85;

		// Token: 0x040182A8 RID: 98984
		internal static int __PropertyOffset_86;

		// Token: 0x040182A9 RID: 98985
		internal static int __PropertyOffset_87;

		// Token: 0x040182AA RID: 98986
		internal static int __PropertyOffset_88;

		// Token: 0x040182AB RID: 98987
		internal static int __PropertyOffset_89;

		// Token: 0x040182AC RID: 98988
		internal static int __PropertyOffset_90;

		// Token: 0x040182AD RID: 98989
		internal static int __PropertyOffset_91;

		// Token: 0x040182AE RID: 98990
		internal static int __PropertyOffset_92;

		// Token: 0x040182AF RID: 98991
		internal static int __PropertyOffset_93;

		// Token: 0x040182B0 RID: 98992
		internal static int __PropertyOffset_94;

		// Token: 0x040182B1 RID: 98993
		[Nullable(2)]
		private TArray<FName> _口型曲线;

		// Token: 0x040182B2 RID: 98994
		internal static int __PropertyOffset_95;

		// Token: 0x040182B3 RID: 98995
		internal static int __PropertyOffset_96;

		// Token: 0x040182B4 RID: 98996
		internal static int __PropertyOffset_97;

		// Token: 0x040182B5 RID: 98997
		internal static int __PropertyOffset_98;

		// Token: 0x040182B6 RID: 98998
		private static IntPtr __InterfaceJumpPressed_NativeFunctionPtr;

		// Token: 0x040182B7 RID: 98999
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x040182B8 RID: 99000
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x040182B9 RID: 99001
		private static IntPtr __初始化Tag_NativeFunctionPtr;

		// Token: 0x040182BA RID: 99002
		private static IntPtr __更新眨眼_NativeFunctionPtr;

		// Token: 0x040182BB RID: 99003
		private static IntPtr __HasInputRotate_NativeFunctionPtr;

		// Token: 0x040182BC RID: 99004
		private static IntPtr __是否AI驱动_NativeFunctionPtr;

		// Token: 0x040182BD RID: 99005
		private static IntPtr __更新角色转身_NativeFunctionPtr;

		// Token: 0x040182BE RID: 99006
		private static IntPtr __更新角色移动_NativeFunctionPtr;

		// Token: 0x040182BF RID: 99007
		private static IntPtr __更新角色碰撞_NativeFunctionPtr;

		// Token: 0x040182C0 RID: 99008
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x040182C1 RID: 99009
		private static IntPtr __更新角色信息_NativeFunctionPtr;

		// Token: 0x040182C2 RID: 99010
		private static IntPtr __InterfaceControlPoint_NativeFunctionPtr;

		// Token: 0x040182C3 RID: 99011
		private static IntPtr __InterfaceManipulateInteractDirection_NativeFunctionPtr;

		// Token: 0x040182C4 RID: 99012
		private static IntPtr __InterfaceFixHookDirect_NativeFunctionPtr;

		// Token: 0x040182C5 RID: 99013
		private static IntPtr __InterfaceSimulateJump_NativeFunctionPtr;

		// Token: 0x040182C6 RID: 99014
		private static IntPtr __ClimbDash_NativeFunctionPtr;

		// Token: 0x040182C7 RID: 99015
		private static IntPtr __OnCompleted_712E5DC7440577B25761868E65201677_NativeFunctionPtr;

		// Token: 0x040182C8 RID: 99016
		private static IntPtr __OnBlendOut_712E5DC7440577B25761868E65201677_NativeFunctionPtr;

		// Token: 0x040182C9 RID: 99017
		private static IntPtr __OnInterrupted_712E5DC7440577B25761868E65201677_NativeFunctionPtr;

		// Token: 0x040182CA RID: 99018
		private static IntPtr __OnNotifyBegin_712E5DC7440577B25761868E65201677_NativeFunctionPtr;

		// Token: 0x040182CB RID: 99019
		private static IntPtr __OnNotifyEnd_712E5DC7440577B25761868E65201677_NativeFunctionPtr;

		// Token: 0x040182CC RID: 99020
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_ModifyBone_A4AC35054E490E2C2EB4D6B2722428F1_NativeFunctionPtr;

		// Token: 0x040182CD RID: 99021
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TextureFace_C2CE9AB24BDEE4700DCED0ADCBA33FA8_NativeFunctionPtr;

		// Token: 0x040182CE RID: 99022
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_SlotWithAlpha_5F1873EE4BEB77F46CCF40A404E37026_NativeFunctionPtr;

		// Token: 0x040182CF RID: 99023
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_BlendListByBool_20DF88D44DE40206AEFAB89575A6C9A5_NativeFunctionPtr;

		// Token: 0x040182D0 RID: 99024
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_C0B8FDED431127A2A5FDC1A72CAE78C2_NativeFunctionPtr;

		// Token: 0x040182D1 RID: 99025
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_0965F59C484C38E57DB2959A3E4DB3D7_NativeFunctionPtr;

		// Token: 0x040182D2 RID: 99026
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_6917C8F64FE3C0CDC8A3E6A7ED7D503C_NativeFunctionPtr;

		// Token: 0x040182D3 RID: 99027
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_2178FF404602F078D81CDF8AB475F43F_NativeFunctionPtr;

		// Token: 0x040182D4 RID: 99028
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_489651114DF56F56400B5085D579A175_NativeFunctionPtr;

		// Token: 0x040182D5 RID: 99029
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_FDBBD5E7477AD7967C489DA71407AA47_NativeFunctionPtr;

		// Token: 0x040182D6 RID: 99030
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_29ED077D4A98A4CA0111C685D4416D03_NativeFunctionPtr;

		// Token: 0x040182D7 RID: 99031
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_9C70E8254D0EAC25ED9262AE4741EA01_NativeFunctionPtr;

		// Token: 0x040182D8 RID: 99032
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseNPC_AnimGraphNode_TransitionResult_2C6793D9468B9D59C335F9B7E06CA14C_NativeFunctionPtr;

		// Token: 0x040182D9 RID: 99033
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x040182DA RID: 99034
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040182DB RID: 99035
		private static IntPtr __AnimNotify_PlayMontage_NativeFunctionPtr;

		// Token: 0x040182DC RID: 99036
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x040182DD RID: 99037
		private static IntPtr __AnimNotify_OnCollisionAnimEnd_NativeFunctionPtr;

		// Token: 0x040182DE RID: 99038
		private static IntPtr __AnimNotify_OnCollisionAnimBegin_NativeFunctionPtr;

		// Token: 0x040182DF RID: 99039
		private static IntPtr __AnimNotify_OnHitAnimBegin_NativeFunctionPtr;

		// Token: 0x040182E0 RID: 99040
		private static IntPtr __AnimNotify_OnHitAnimEnd_NativeFunctionPtr;

		// Token: 0x040182E1 RID: 99041
		private static IntPtr __ExecuteUbergraph_ABP_BaseNPC_NativeFunctionPtr;

		// Token: 0x0200A3D4 RID: 41940
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceJumpPressed_FunctionParams
		{
			// Token: 0x040331C1 RID: 209345
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A3D5 RID: 41941
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x040331C2 RID: 209346
			[FieldOffset(0)]
			public byte 地区运动状态;

			// Token: 0x040331C3 RID: 209347
			[FieldOffset(24)]
			public byte 基础层;
		}

		// Token: 0x0200A3D6 RID: 41942
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x040331C4 RID: 209348
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A3D7 RID: 41943
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 76)]
		protected ref struct __HasInputRotate_FunctionParams
		{
			// Token: 0x040331C5 RID: 209349
			[FieldOffset(0)]
			public bool Output_Get;
		}

		// Token: 0x0200A3D8 RID: 41944
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __是否AI驱动_FunctionParams
		{
			// Token: 0x040331C6 RID: 209350
			[FieldOffset(0)]
			public bool Result;
		}

		// Token: 0x0200A3D9 RID: 41945
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceControlPoint_FunctionParams
		{
			// Token: 0x040331C7 RID: 209351
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A3DA RID: 41946
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceManipulateInteractDirection_FunctionParams
		{
			// Token: 0x040331C8 RID: 209352
			[FieldOffset(0)]
			public float 角度;
		}

		// Token: 0x0200A3DB RID: 41947
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __InterfaceFixHookDirect_FunctionParams
		{
			// Token: 0x040331C9 RID: 209353
			[FieldOffset(0)]
			public FVector Offset;
		}

		// Token: 0x0200A3DC RID: 41948
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __InterfaceSimulateJump_FunctionParams
		{
			// Token: 0x040331CA RID: 209354
			[FieldOffset(0)]
			public float Speed;
		}

		// Token: 0x0200A3DD RID: 41949
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnCompleted_712E5DC7440577B25761868E65201677_FunctionParams
		{
			// Token: 0x040331CB RID: 209355
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3DE RID: 41950
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnBlendOut_712E5DC7440577B25761868E65201677_FunctionParams
		{
			// Token: 0x040331CC RID: 209356
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3DF RID: 41951
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnInterrupted_712E5DC7440577B25761868E65201677_FunctionParams
		{
			// Token: 0x040331CD RID: 209357
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3E0 RID: 41952
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyBegin_712E5DC7440577B25761868E65201677_FunctionParams
		{
			// Token: 0x040331CE RID: 209358
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3E1 RID: 41953
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyEnd_712E5DC7440577B25761868E65201677_FunctionParams
		{
			// Token: 0x040331CF RID: 209359
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x0200A3E2 RID: 41954
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x040331D0 RID: 209360
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A3E3 RID: 41955
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 488)]
		protected ref struct __ExecuteUbergraph_ABP_BaseNPC_FunctionParams
		{
			// Token: 0x040331D1 RID: 209361
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
