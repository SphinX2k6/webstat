using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Fight.AssestStruct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Monster.Common
{
	// Token: 0x0200419A RID: 16794
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Monster/Common/ABP_MonsterCommon.ABP_MonsterCommon_C")]
	[UnrealStructLayout(14784, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 14776)]
	public class ABP_MonsterCommon_C : UKuroAnimInstanceMonster, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C850 RID: 182352 RVA: 0x00AA4A1C File Offset: 0x00AA2C1C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_MonsterCommon_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Monster/Common/ABP_MonsterCommon.ABP_MonsterCommon_C");
			}
			return ABP_MonsterCommon_C._ClassPtr;
		}

		// Token: 0x0602C851 RID: 182353 RVA: 0x00AA4A40 File Offset: 0x00AA2C40
		public ABP_MonsterCommon_C() : this(BuiltinUtils.AllocNativeUObject(ABP_MonsterCommon_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C852 RID: 182354 RVA: 0x00AA4A68 File Offset: 0x00AA2C68
		public ABP_MonsterCommon_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_MonsterCommon_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170077C2 RID: 30658
		// (get) Token: 0x0602C853 RID: 182355 RVA: 0x00AA4A9C File Offset: 0x00AA2C9C
		// (set) Token: 0x0602C854 RID: 182356 RVA: 0x00AA4AD5 File Offset: 0x00AA2CD5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C3 RID: 30659
		// (get) Token: 0x0602C855 RID: 182357 RVA: 0x00AA4AF8 File Offset: 0x00AA2CF8
		// (set) Token: 0x0602C856 RID: 182358 RVA: 0x00AA4B31 File Offset: 0x00AA2D31
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C4 RID: 30660
		// (get) Token: 0x0602C857 RID: 182359 RVA: 0x00AA4B54 File Offset: 0x00AA2D54
		// (set) Token: 0x0602C858 RID: 182360 RVA: 0x00AA4B8D File Offset: 0x00AA2D8D
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C5 RID: 30661
		// (get) Token: 0x0602C859 RID: 182361 RVA: 0x00AA4BB0 File Offset: 0x00AA2DB0
		// (set) Token: 0x0602C85A RID: 182362 RVA: 0x00AA4BE9 File Offset: 0x00AA2DE9
		public FAnimNode_BoneRotateToLocation AnimGraphNode_BoneRotateToLocation
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BoneRotateToLocation result;
				if ((result = this._AnimGraphNode_BoneRotateToLocation) == null)
				{
					result = (this._AnimGraphNode_BoneRotateToLocation = new FAnimNode_BoneRotateToLocation(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BoneRotateToLocation.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C6 RID: 30662
		// (get) Token: 0x0602C85B RID: 182363 RVA: 0x00AA4C0C File Offset: 0x00AA2E0C
		// (set) Token: 0x0602C85C RID: 182364 RVA: 0x00AA4C45 File Offset: 0x00AA2E45
		public FAnimNode_FeedbackAnim AnimGraphNode_FeedbackAnim
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_FeedbackAnim result;
				if ((result = this._AnimGraphNode_FeedbackAnim) == null)
				{
					result = (this._AnimGraphNode_FeedbackAnim = new FAnimNode_FeedbackAnim(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_FeedbackAnim.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C7 RID: 30663
		// (get) Token: 0x0602C85D RID: 182365 RVA: 0x00AA4C68 File Offset: 0x00AA2E68
		// (set) Token: 0x0602C85E RID: 182366 RVA: 0x00AA4CA1 File Offset: 0x00AA2EA1
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C8 RID: 30664
		// (get) Token: 0x0602C85F RID: 182367 RVA: 0x00AA4CC4 File Offset: 0x00AA2EC4
		// (set) Token: 0x0602C860 RID: 182368 RVA: 0x00AA4CFD File Offset: 0x00AA2EFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077C9 RID: 30665
		// (get) Token: 0x0602C861 RID: 182369 RVA: 0x00AA4D20 File Offset: 0x00AA2F20
		// (set) Token: 0x0602C862 RID: 182370 RVA: 0x00AA4D59 File Offset: 0x00AA2F59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077CA RID: 30666
		// (get) Token: 0x0602C863 RID: 182371 RVA: 0x00AA4D7C File Offset: 0x00AA2F7C
		// (set) Token: 0x0602C864 RID: 182372 RVA: 0x00AA4DB5 File Offset: 0x00AA2FB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077CB RID: 30667
		// (get) Token: 0x0602C865 RID: 182373 RVA: 0x00AA4DD8 File Offset: 0x00AA2FD8
		// (set) Token: 0x0602C866 RID: 182374 RVA: 0x00AA4E11 File Offset: 0x00AA3011
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077CC RID: 30668
		// (get) Token: 0x0602C867 RID: 182375 RVA: 0x00AA4E34 File Offset: 0x00AA3034
		// (set) Token: 0x0602C868 RID: 182376 RVA: 0x00AA4E6D File Offset: 0x00AA306D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077CD RID: 30669
		// (get) Token: 0x0602C869 RID: 182377 RVA: 0x00AA4E90 File Offset: 0x00AA3090
		// (set) Token: 0x0602C86A RID: 182378 RVA: 0x00AA4EC9 File Offset: 0x00AA30C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077CE RID: 30670
		// (get) Token: 0x0602C86B RID: 182379 RVA: 0x00AA4EEC File Offset: 0x00AA30EC
		// (set) Token: 0x0602C86C RID: 182380 RVA: 0x00AA4F25 File Offset: 0x00AA3125
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_3) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_3 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077CF RID: 30671
		// (get) Token: 0x0602C86D RID: 182381 RVA: 0x00AA4F48 File Offset: 0x00AA3148
		// (set) Token: 0x0602C86E RID: 182382 RVA: 0x00AA4F81 File Offset: 0x00AA3181
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D0 RID: 30672
		// (get) Token: 0x0602C86F RID: 182383 RVA: 0x00AA4FA4 File Offset: 0x00AA31A4
		// (set) Token: 0x0602C870 RID: 182384 RVA: 0x00AA4FDD File Offset: 0x00AA31DD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D1 RID: 30673
		// (get) Token: 0x0602C871 RID: 182385 RVA: 0x00AA5000 File Offset: 0x00AA3200
		// (set) Token: 0x0602C872 RID: 182386 RVA: 0x00AA5039 File Offset: 0x00AA3239
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D2 RID: 30674
		// (get) Token: 0x0602C873 RID: 182387 RVA: 0x00AA505C File Offset: 0x00AA325C
		// (set) Token: 0x0602C874 RID: 182388 RVA: 0x00AA5095 File Offset: 0x00AA3295
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_2) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_2 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D3 RID: 30675
		// (get) Token: 0x0602C875 RID: 182389 RVA: 0x00AA50B8 File Offset: 0x00AA32B8
		// (set) Token: 0x0602C876 RID: 182390 RVA: 0x00AA50F1 File Offset: 0x00AA32F1
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D4 RID: 30676
		// (get) Token: 0x0602C877 RID: 182391 RVA: 0x00AA5114 File Offset: 0x00AA3314
		// (set) Token: 0x0602C878 RID: 182392 RVA: 0x00AA514D File Offset: 0x00AA334D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D5 RID: 30677
		// (get) Token: 0x0602C879 RID: 182393 RVA: 0x00AA5170 File Offset: 0x00AA3370
		// (set) Token: 0x0602C87A RID: 182394 RVA: 0x00AA51A9 File Offset: 0x00AA33A9
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D6 RID: 30678
		// (get) Token: 0x0602C87B RID: 182395 RVA: 0x00AA51CC File Offset: 0x00AA33CC
		// (set) Token: 0x0602C87C RID: 182396 RVA: 0x00AA5205 File Offset: 0x00AA3405
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D7 RID: 30679
		// (get) Token: 0x0602C87D RID: 182397 RVA: 0x00AA5228 File Offset: 0x00AA3428
		// (set) Token: 0x0602C87E RID: 182398 RVA: 0x00AA5261 File Offset: 0x00AA3461
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D8 RID: 30680
		// (get) Token: 0x0602C87F RID: 182399 RVA: 0x00AA5284 File Offset: 0x00AA3484
		// (set) Token: 0x0602C880 RID: 182400 RVA: 0x00AA52BD File Offset: 0x00AA34BD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077D9 RID: 30681
		// (get) Token: 0x0602C881 RID: 182401 RVA: 0x00AA52E0 File Offset: 0x00AA34E0
		// (set) Token: 0x0602C882 RID: 182402 RVA: 0x00AA5319 File Offset: 0x00AA3519
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077DA RID: 30682
		// (get) Token: 0x0602C883 RID: 182403 RVA: 0x00AA533C File Offset: 0x00AA353C
		// (set) Token: 0x0602C884 RID: 182404 RVA: 0x00AA5375 File Offset: 0x00AA3575
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077DB RID: 30683
		// (get) Token: 0x0602C885 RID: 182405 RVA: 0x00AA5398 File Offset: 0x00AA3598
		// (set) Token: 0x0602C886 RID: 182406 RVA: 0x00AA53D1 File Offset: 0x00AA35D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077DC RID: 30684
		// (get) Token: 0x0602C887 RID: 182407 RVA: 0x00AA53F4 File Offset: 0x00AA35F4
		// (set) Token: 0x0602C888 RID: 182408 RVA: 0x00AA542D File Offset: 0x00AA362D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077DD RID: 30685
		// (get) Token: 0x0602C889 RID: 182409 RVA: 0x00AA5450 File Offset: 0x00AA3650
		// (set) Token: 0x0602C88A RID: 182410 RVA: 0x00AA5489 File Offset: 0x00AA3689
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077DE RID: 30686
		// (get) Token: 0x0602C88B RID: 182411 RVA: 0x00AA54AC File Offset: 0x00AA36AC
		// (set) Token: 0x0602C88C RID: 182412 RVA: 0x00AA54E5 File Offset: 0x00AA36E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077DF RID: 30687
		// (get) Token: 0x0602C88D RID: 182413 RVA: 0x00AA5508 File Offset: 0x00AA3708
		// (set) Token: 0x0602C88E RID: 182414 RVA: 0x00AA5541 File Offset: 0x00AA3741
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E0 RID: 30688
		// (get) Token: 0x0602C88F RID: 182415 RVA: 0x00AA5564 File Offset: 0x00AA3764
		// (set) Token: 0x0602C890 RID: 182416 RVA: 0x00AA559D File Offset: 0x00AA379D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E1 RID: 30689
		// (get) Token: 0x0602C891 RID: 182417 RVA: 0x00AA55C0 File Offset: 0x00AA37C0
		// (set) Token: 0x0602C892 RID: 182418 RVA: 0x00AA55F9 File Offset: 0x00AA37F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E2 RID: 30690
		// (get) Token: 0x0602C893 RID: 182419 RVA: 0x00AA561C File Offset: 0x00AA381C
		// (set) Token: 0x0602C894 RID: 182420 RVA: 0x00AA5655 File Offset: 0x00AA3855
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E3 RID: 30691
		// (get) Token: 0x0602C895 RID: 182421 RVA: 0x00AA5678 File Offset: 0x00AA3878
		// (set) Token: 0x0602C896 RID: 182422 RVA: 0x00AA56B1 File Offset: 0x00AA38B1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E4 RID: 30692
		// (get) Token: 0x0602C897 RID: 182423 RVA: 0x00AA56D4 File Offset: 0x00AA38D4
		// (set) Token: 0x0602C898 RID: 182424 RVA: 0x00AA570D File Offset: 0x00AA390D
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E5 RID: 30693
		// (get) Token: 0x0602C899 RID: 182425 RVA: 0x00AA5730 File Offset: 0x00AA3930
		// (set) Token: 0x0602C89A RID: 182426 RVA: 0x00AA5769 File Offset: 0x00AA3969
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E6 RID: 30694
		// (get) Token: 0x0602C89B RID: 182427 RVA: 0x00AA578C File Offset: 0x00AA398C
		// (set) Token: 0x0602C89C RID: 182428 RVA: 0x00AA57C5 File Offset: 0x00AA39C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E7 RID: 30695
		// (get) Token: 0x0602C89D RID: 182429 RVA: 0x00AA57E8 File Offset: 0x00AA39E8
		// (set) Token: 0x0602C89E RID: 182430 RVA: 0x00AA5821 File Offset: 0x00AA3A21
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E8 RID: 30696
		// (get) Token: 0x0602C89F RID: 182431 RVA: 0x00AA5844 File Offset: 0x00AA3A44
		// (set) Token: 0x0602C8A0 RID: 182432 RVA: 0x00AA587D File Offset: 0x00AA3A7D
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077E9 RID: 30697
		// (get) Token: 0x0602C8A1 RID: 182433 RVA: 0x00AA58A0 File Offset: 0x00AA3AA0
		// (set) Token: 0x0602C8A2 RID: 182434 RVA: 0x00AA58D9 File Offset: 0x00AA3AD9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077EA RID: 30698
		// (get) Token: 0x0602C8A3 RID: 182435 RVA: 0x00AA58FC File Offset: 0x00AA3AFC
		// (set) Token: 0x0602C8A4 RID: 182436 RVA: 0x00AA5935 File Offset: 0x00AA3B35
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077EB RID: 30699
		// (get) Token: 0x0602C8A5 RID: 182437 RVA: 0x00AA5958 File Offset: 0x00AA3B58
		// (set) Token: 0x0602C8A6 RID: 182438 RVA: 0x00AA5991 File Offset: 0x00AA3B91
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077EC RID: 30700
		// (get) Token: 0x0602C8A7 RID: 182439 RVA: 0x00AA59B4 File Offset: 0x00AA3BB4
		// (set) Token: 0x0602C8A8 RID: 182440 RVA: 0x00AA59ED File Offset: 0x00AA3BED
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077ED RID: 30701
		// (get) Token: 0x0602C8A9 RID: 182441 RVA: 0x00AA5A10 File Offset: 0x00AA3C10
		// (set) Token: 0x0602C8AA RID: 182442 RVA: 0x00AA5A49 File Offset: 0x00AA3C49
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077EE RID: 30702
		// (get) Token: 0x0602C8AB RID: 182443 RVA: 0x00AA5A6C File Offset: 0x00AA3C6C
		// (set) Token: 0x0602C8AC RID: 182444 RVA: 0x00AA5AA5 File Offset: 0x00AA3CA5
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_3) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_3 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077EF RID: 30703
		// (get) Token: 0x0602C8AD RID: 182445 RVA: 0x00AA5AC8 File Offset: 0x00AA3CC8
		// (set) Token: 0x0602C8AE RID: 182446 RVA: 0x00AA5B01 File Offset: 0x00AA3D01
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_2) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_2 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F0 RID: 30704
		// (get) Token: 0x0602C8AF RID: 182447 RVA: 0x00AA5B24 File Offset: 0x00AA3D24
		// (set) Token: 0x0602C8B0 RID: 182448 RVA: 0x00AA5B5D File Offset: 0x00AA3D5D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_1 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F1 RID: 30705
		// (get) Token: 0x0602C8B1 RID: 182449 RVA: 0x00AA5B80 File Offset: 0x00AA3D80
		// (set) Token: 0x0602C8B2 RID: 182450 RVA: 0x00AA5BB9 File Offset: 0x00AA3DB9
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F2 RID: 30706
		// (get) Token: 0x0602C8B3 RID: 182451 RVA: 0x00AA5BDC File Offset: 0x00AA3DDC
		// (set) Token: 0x0602C8B4 RID: 182452 RVA: 0x00AA5C15 File Offset: 0x00AA3E15
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F3 RID: 30707
		// (get) Token: 0x0602C8B5 RID: 182453 RVA: 0x00AA5C38 File Offset: 0x00AA3E38
		// (set) Token: 0x0602C8B6 RID: 182454 RVA: 0x00AA5C71 File Offset: 0x00AA3E71
		public FAnimNode_Feedback AnimGraphNode_Feedback
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Feedback result;
				if ((result = this._AnimGraphNode_Feedback) == null)
				{
					result = (this._AnimGraphNode_Feedback = new FAnimNode_Feedback(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Feedback.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F4 RID: 30708
		// (get) Token: 0x0602C8B7 RID: 182455 RVA: 0x00AA5C94 File Offset: 0x00AA3E94
		// (set) Token: 0x0602C8B8 RID: 182456 RVA: 0x00AA5CCD File Offset: 0x00AA3ECD
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F5 RID: 30709
		// (get) Token: 0x0602C8B9 RID: 182457 RVA: 0x00AA5CF0 File Offset: 0x00AA3EF0
		// (set) Token: 0x0602C8BA RID: 182458 RVA: 0x00AA5D29 File Offset: 0x00AA3F29
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F6 RID: 30710
		// (get) Token: 0x0602C8BB RID: 182459 RVA: 0x00AA5D4C File Offset: 0x00AA3F4C
		// (set) Token: 0x0602C8BC RID: 182460 RVA: 0x00AA5D85 File Offset: 0x00AA3F85
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F7 RID: 30711
		// (get) Token: 0x0602C8BD RID: 182461 RVA: 0x00AA5DA8 File Offset: 0x00AA3FA8
		// (set) Token: 0x0602C8BE RID: 182462 RVA: 0x00AA5DE1 File Offset: 0x00AA3FE1
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F8 RID: 30712
		// (get) Token: 0x0602C8BF RID: 182463 RVA: 0x00AA5E04 File Offset: 0x00AA4004
		// (set) Token: 0x0602C8C0 RID: 182464 RVA: 0x00AA5E3D File Offset: 0x00AA403D
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_1 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077F9 RID: 30713
		// (get) Token: 0x0602C8C1 RID: 182465 RVA: 0x00AA5E60 File Offset: 0x00AA4060
		// (set) Token: 0x0602C8C2 RID: 182466 RVA: 0x00AA5E99 File Offset: 0x00AA4099
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077FA RID: 30714
		// (get) Token: 0x0602C8C3 RID: 182467 RVA: 0x00AA5EBC File Offset: 0x00AA40BC
		// (set) Token: 0x0602C8C4 RID: 182468 RVA: 0x00AA5EF5 File Offset: 0x00AA40F5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077FB RID: 30715
		// (get) Token: 0x0602C8C5 RID: 182469 RVA: 0x00AA5F18 File Offset: 0x00AA4118
		// (set) Token: 0x0602C8C6 RID: 182470 RVA: 0x00AA5F51 File Offset: 0x00AA4151
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077FC RID: 30716
		// (get) Token: 0x0602C8C7 RID: 182471 RVA: 0x00AA5F74 File Offset: 0x00AA4174
		// (set) Token: 0x0602C8C8 RID: 182472 RVA: 0x00AA5FAD File Offset: 0x00AA41AD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077FD RID: 30717
		// (get) Token: 0x0602C8C9 RID: 182473 RVA: 0x00AA5FD0 File Offset: 0x00AA41D0
		// (set) Token: 0x0602C8CA RID: 182474 RVA: 0x00AA6009 File Offset: 0x00AA4209
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077FE RID: 30718
		// (get) Token: 0x0602C8CB RID: 182475 RVA: 0x00AA602C File Offset: 0x00AA422C
		// (set) Token: 0x0602C8CC RID: 182476 RVA: 0x00AA6065 File Offset: 0x00AA4265
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170077FF RID: 30719
		// (get) Token: 0x0602C8CD RID: 182477 RVA: 0x00AA6088 File Offset: 0x00AA4288
		// (set) Token: 0x0602C8CE RID: 182478 RVA: 0x00AA60C1 File Offset: 0x00AA42C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007800 RID: 30720
		// (get) Token: 0x0602C8CF RID: 182479 RVA: 0x00AA60E4 File Offset: 0x00AA42E4
		// (set) Token: 0x0602C8D0 RID: 182480 RVA: 0x00AA611D File Offset: 0x00AA431D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007801 RID: 30721
		// (get) Token: 0x0602C8D1 RID: 182481 RVA: 0x00AA6140 File Offset: 0x00AA4340
		// (set) Token: 0x0602C8D2 RID: 182482 RVA: 0x00AA6179 File Offset: 0x00AA4379
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007802 RID: 30722
		// (get) Token: 0x0602C8D3 RID: 182483 RVA: 0x00AA619C File Offset: 0x00AA439C
		// (set) Token: 0x0602C8D4 RID: 182484 RVA: 0x00AA61D5 File Offset: 0x00AA43D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007803 RID: 30723
		// (get) Token: 0x0602C8D5 RID: 182485 RVA: 0x00AA61F8 File Offset: 0x00AA43F8
		// (set) Token: 0x0602C8D6 RID: 182486 RVA: 0x00AA6231 File Offset: 0x00AA4431
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007804 RID: 30724
		// (get) Token: 0x0602C8D7 RID: 182487 RVA: 0x00AA6254 File Offset: 0x00AA4454
		// (set) Token: 0x0602C8D8 RID: 182488 RVA: 0x00AA628D File Offset: 0x00AA448D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007805 RID: 30725
		// (get) Token: 0x0602C8D9 RID: 182489 RVA: 0x00AA62B0 File Offset: 0x00AA44B0
		// (set) Token: 0x0602C8DA RID: 182490 RVA: 0x00AA62E9 File Offset: 0x00AA44E9
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007806 RID: 30726
		// (get) Token: 0x0602C8DB RID: 182491 RVA: 0x00AA630C File Offset: 0x00AA450C
		// (set) Token: 0x0602C8DC RID: 182492 RVA: 0x00AA6345 File Offset: 0x00AA4545
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007807 RID: 30727
		// (get) Token: 0x0602C8DD RID: 182493 RVA: 0x00AA6368 File Offset: 0x00AA4568
		// (set) Token: 0x0602C8DE RID: 182494 RVA: 0x00AA63A1 File Offset: 0x00AA45A1
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007808 RID: 30728
		// (get) Token: 0x0602C8DF RID: 182495 RVA: 0x00AA63C4 File Offset: 0x00AA45C4
		// (set) Token: 0x0602C8E0 RID: 182496 RVA: 0x00AA63FD File Offset: 0x00AA45FD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007809 RID: 30729
		// (get) Token: 0x0602C8E1 RID: 182497 RVA: 0x00AA6420 File Offset: 0x00AA4620
		// (set) Token: 0x0602C8E2 RID: 182498 RVA: 0x00AA6459 File Offset: 0x00AA4659
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700780A RID: 30730
		// (get) Token: 0x0602C8E3 RID: 182499 RVA: 0x00AA647C File Offset: 0x00AA467C
		// (set) Token: 0x0602C8E4 RID: 182500 RVA: 0x00AA64B5 File Offset: 0x00AA46B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700780B RID: 30731
		// (get) Token: 0x0602C8E5 RID: 182501 RVA: 0x00AA64D8 File Offset: 0x00AA46D8
		// (set) Token: 0x0602C8E6 RID: 182502 RVA: 0x00AA6511 File Offset: 0x00AA4711
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700780C RID: 30732
		// (get) Token: 0x0602C8E7 RID: 182503 RVA: 0x00AA6534 File Offset: 0x00AA4734
		// (set) Token: 0x0602C8E8 RID: 182504 RVA: 0x00AA656D File Offset: 0x00AA476D
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700780D RID: 30733
		// (get) Token: 0x0602C8E9 RID: 182505 RVA: 0x00AA6590 File Offset: 0x00AA4790
		// (set) Token: 0x0602C8EA RID: 182506 RVA: 0x00AA65C9 File Offset: 0x00AA47C9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700780E RID: 30734
		// (get) Token: 0x0602C8EB RID: 182507 RVA: 0x00AA65EC File Offset: 0x00AA47EC
		// (set) Token: 0x0602C8EC RID: 182508 RVA: 0x00AA6625 File Offset: 0x00AA4825
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700780F RID: 30735
		// (get) Token: 0x0602C8ED RID: 182509 RVA: 0x00AA6648 File Offset: 0x00AA4848
		// (set) Token: 0x0602C8EE RID: 182510 RVA: 0x00AA6681 File Offset: 0x00AA4881
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007810 RID: 30736
		// (get) Token: 0x0602C8EF RID: 182511 RVA: 0x00AA66A4 File Offset: 0x00AA48A4
		// (set) Token: 0x0602C8F0 RID: 182512 RVA: 0x00AA66DD File Offset: 0x00AA48DD
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007811 RID: 30737
		// (get) Token: 0x0602C8F1 RID: 182513 RVA: 0x00AA6700 File Offset: 0x00AA4900
		// (set) Token: 0x0602C8F2 RID: 182514 RVA: 0x00AA6739 File Offset: 0x00AA4939
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007812 RID: 30738
		// (get) Token: 0x0602C8F3 RID: 182515 RVA: 0x00AA675C File Offset: 0x00AA495C
		// (set) Token: 0x0602C8F4 RID: 182516 RVA: 0x00AA6795 File Offset: 0x00AA4995
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007813 RID: 30739
		// (get) Token: 0x0602C8F5 RID: 182517 RVA: 0x00AA67B6 File Offset: 0x00AA49B6
		// (set) Token: 0x0602C8F6 RID: 182518 RVA: 0x00AA67CA File Offset: 0x00AA49CA
		[Nullable(2)]
		public unsafe TsBaseCharacter As_Base_Character
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_81);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_81, value);
			}
		}

		// Token: 0x17007814 RID: 30740
		// (get) Token: 0x0602C8F7 RID: 182519 RVA: 0x00AA67E0 File Offset: 0x00AA49E0
		// (set) Token: 0x0602C8F8 RID: 182520 RVA: 0x00AA6819 File Offset: 0x00AA4A19
		public FSkeletonGroup Skeleton_Block_Info
		{
			get
			{
				base.FastCheckIsValid();
				FSkeletonGroup result;
				if ((result = this._Skeleton_Block_Info) == null)
				{
					result = (this._Skeleton_Block_Info = new FSkeletonGroup(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSkeletonGroup.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007815 RID: 30741
		// (get) Token: 0x0602C8F9 RID: 182521 RVA: 0x00AA683A File Offset: 0x00AA4A3A
		// (set) Token: 0x0602C8FA RID: 182522 RVA: 0x00AA684E File Offset: 0x00AA4A4E
		[Nullable(2)]
		public unsafe FK_Shake_AssestData_C FKShakeData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<FK_Shake_AssestData_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_83);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_83, value);
			}
		}

		// Token: 0x17007816 RID: 30742
		// (get) Token: 0x0602C8FB RID: 182523 RVA: 0x00AA6864 File Offset: 0x00AA4A64
		// (set) Token: 0x0602C8FC RID: 182524 RVA: 0x00AA689D File Offset: 0x00AA4A9D
		public NewEventDispatcher_0 NewEventDispatcher_0
		{
			get
			{
				base.FastCheckIsValid();
				NewEventDispatcher_0 result;
				if ((result = this._NewEventDispatcher_0) == null)
				{
					result = (this._NewEventDispatcher_0 = new NewEventDispatcher_0(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_84, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17007817 RID: 30743
		// (get) Token: 0x0602C8FD RID: 182525 RVA: 0x00AA68BE File Offset: 0x00AA4ABE
		// (set) Token: 0x0602C8FE RID: 182526 RVA: 0x00AA68CE File Offset: 0x00AA4ACE
		public unsafe int Increment
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_85);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_85) = value;
			}
		}

		// Token: 0x17007818 RID: 30744
		// (get) Token: 0x0602C8FF RID: 182527 RVA: 0x00AA68DF File Offset: 0x00AA4ADF
		// (set) Token: 0x0602C900 RID: 182528 RVA: 0x00AA68EF File Offset: 0x00AA4AEF
		public unsafe SightLockMode CameraMode_DEPRECATED
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_86));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_86) = (byte)value;
			}
		}

		// Token: 0x17007819 RID: 30745
		// (get) Token: 0x0602C901 RID: 182529 RVA: 0x00AA6900 File Offset: 0x00AA4B00
		// (set) Token: 0x0602C902 RID: 182530 RVA: 0x00AA6910 File Offset: 0x00AA4B10
		public unsafe float Assist_Limit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_87);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_87) = value;
			}
		}

		// Token: 0x1700781A RID: 30746
		// (get) Token: 0x0602C903 RID: 182531 RVA: 0x00AA6921 File Offset: 0x00AA4B21
		// (set) Token: 0x0602C904 RID: 182532 RVA: 0x00AA6935 File Offset: 0x00AA4B35
		public unsafe FName Sight_Bone_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_88);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_88) = value;
			}
		}

		// Token: 0x1700781B RID: 30747
		// (get) Token: 0x0602C905 RID: 182533 RVA: 0x00AA694A File Offset: 0x00AA4B4A
		// (set) Token: 0x0602C906 RID: 182534 RVA: 0x00AA695E File Offset: 0x00AA4B5E
		public unsafe FName Begin_Bone_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_89);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_89) = value;
			}
		}

		// Token: 0x1700781C RID: 30748
		// (get) Token: 0x0602C907 RID: 182535 RVA: 0x00AA6973 File Offset: 0x00AA4B73
		// (set) Token: 0x0602C908 RID: 182536 RVA: 0x00AA6987 File Offset: 0x00AA4B87
		public unsafe FName End_Bone_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_90);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_90) = value;
			}
		}

		// Token: 0x1700781D RID: 30749
		// (get) Token: 0x0602C909 RID: 182537 RVA: 0x00AA699C File Offset: 0x00AA4B9C
		// (set) Token: 0x0602C90A RID: 182538 RVA: 0x00AA69AC File Offset: 0x00AA4BAC
		public unsafe float ShakeAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_91);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_91) = value;
			}
		}

		// Token: 0x1700781E RID: 30750
		// (get) Token: 0x0602C90B RID: 182539 RVA: 0x00AA69BD File Offset: 0x00AA4BBD
		// (set) Token: 0x0602C90C RID: 182540 RVA: 0x00AA69CD File Offset: 0x00AA4BCD
		public unsafe int ShakeRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x1700781F RID: 30751
		// (get) Token: 0x0602C90D RID: 182541 RVA: 0x00AA69E0 File Offset: 0x00AA4BE0
		// (set) Token: 0x0602C90E RID: 182542 RVA: 0x00AA6A19 File Offset: 0x00AA4C19
		public TArray<PD_CharacterControllerData_C> HitMaterial
		{
			get
			{
				base.FastCheckIsValid();
				TArray<PD_CharacterControllerData_C> result;
				if ((result = this._HitMaterial) == null)
				{
					result = (this._HitMaterial = new TArray<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				this.HitMaterial.CopyAssign(value);
			}
		}

		// Token: 0x17007820 RID: 30752
		// (get) Token: 0x0602C90F RID: 182543 RVA: 0x00AA6A27 File Offset: 0x00AA4C27
		// (set) Token: 0x0602C910 RID: 182544 RVA: 0x00AA6A37 File Offset: 0x00AA4C37
		public unsafe float ToughDecreaseValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x17007821 RID: 30753
		// (get) Token: 0x0602C911 RID: 182545 RVA: 0x00AA6A48 File Offset: 0x00AA4C48
		// (set) Token: 0x0602C912 RID: 182546 RVA: 0x00AA6A81 File Offset: 0x00AA4C81
		public FGameplayTagContainer CachedTagContainer
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._CachedTagContainer) == null)
				{
					result = (this._CachedTagContainer = new FGameplayTagContainer(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007822 RID: 30754
		// (get) Token: 0x0602C913 RID: 182547 RVA: 0x00AA6AA2 File Offset: 0x00AA4CA2
		// (set) Token: 0x0602C914 RID: 182548 RVA: 0x00AA6AB2 File Offset: 0x00AA4CB2
		public unsafe bool TestFkBoolean
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_96) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_96) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007823 RID: 30755
		// (get) Token: 0x0602C915 RID: 182549 RVA: 0x00AA6AC3 File Offset: 0x00AA4CC3
		// (set) Token: 0x0602C916 RID: 182550 RVA: 0x00AA6AD7 File Offset: 0x00AA4CD7
		[Nullable(2)]
		public unsafe UCurveFloat ShakeCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_97);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_97, value);
			}
		}

		// Token: 0x17007824 RID: 30756
		// (get) Token: 0x0602C917 RID: 182551 RVA: 0x00AA6AEC File Offset: 0x00AA4CEC
		// (set) Token: 0x0602C918 RID: 182552 RVA: 0x00AA6AFC File Offset: 0x00AA4CFC
		public unsafe bool 大体型怪物
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_98) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_98) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007825 RID: 30757
		// (get) Token: 0x0602C919 RID: 182553 RVA: 0x00AA6B0D File Offset: 0x00AA4D0D
		// (set) Token: 0x0602C91A RID: 182554 RVA: 0x00AA6B21 File Offset: 0x00AA4D21
		[Nullable(2)]
		public unsafe TsBaseCharacter 仇恨当前对象
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_99);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_99, value);
			}
		}

		// Token: 0x17007826 RID: 30758
		// (get) Token: 0x0602C91B RID: 182555 RVA: 0x00AA6B36 File Offset: 0x00AA4D36
		// (set) Token: 0x0602C91C RID: 182556 RVA: 0x00AA6B4A File Offset: 0x00AA4D4A
		public unsafe FName Bone_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x17007827 RID: 30759
		// (get) Token: 0x0602C91D RID: 182557 RVA: 0x00AA6B5F File Offset: 0x00AA4D5F
		// (set) Token: 0x0602C91E RID: 182558 RVA: 0x00AA6B73 File Offset: 0x00AA4D73
		[Nullable(2)]
		public unsafe BP_ABPLogicParams_C Ts逻辑变量集
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_ABPLogicParams_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_101);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_MonsterCommon_C.__PropertyOffset_101, value);
			}
		}

		// Token: 0x17007828 RID: 30760
		// (get) Token: 0x0602C91F RID: 182559 RVA: 0x00AA6B88 File Offset: 0x00AA4D88
		// (set) Token: 0x0602C920 RID: 182560 RVA: 0x00AA6BC1 File Offset: 0x00AA4DC1
		public FBoneFeedbackAnimConfigGroup Feedback_Anim
		{
			get
			{
				base.FastCheckIsValid();
				FBoneFeedbackAnimConfigGroup result;
				if ((result = this._Feedback_Anim) == null)
				{
					result = (this._Feedback_Anim = new FBoneFeedbackAnimConfigGroup(base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FBoneFeedbackAnimConfigGroup.StaticStruct(), base.NativePtr + (IntPtr)ABP_MonsterCommon_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602C921 RID: 182561 RVA: 0x00AA6BE4 File Offset: 0x00AA4DE4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IKAndFk(FPoseLink InPose, ref FPoseLink IKAndFk)
		{
			ABP_MonsterCommon_C.__IKAndFk_FunctionParams* ptr = stackalloc ABP_MonsterCommon_C.__IKAndFk_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_MonsterCommon_C.__IKAndFk_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MonsterCommon_C.__IKAndFk_NativeFunctionPtr, (void*)ptr, 1);
			if (InPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->InPose, InPose.NativePtr, 1, false);
			}
			if (IKAndFk != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->IKAndFk, IKAndFk.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__IKAndFk_NativeFunctionPtr, (void*)ptr);
			if (IKAndFk != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), IKAndFk.NativePtr, &ptr->IKAndFk, 1, false);
			}
		}

		// Token: 0x0602C922 RID: 182562 RVA: 0x00AA6C90 File Offset: 0x00AA4E90
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_MonsterCommon_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_MonsterCommon_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_MonsterCommon_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MonsterCommon_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C923 RID: 182563 RVA: 0x00AA6D17 File Offset: 0x00AA4F17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化绑定_Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__初始化绑定_Tag_NativeFunctionPtr, null);
		}

		// Token: 0x0602C924 RID: 182564 RVA: 0x00AA6D2B File Offset: 0x00AA4F2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_7366C1E545187F21B80550B938A5DFC7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_7366C1E545187F21B80550B938A5DFC7_NativeFunctionPtr, null);
		}

		// Token: 0x0602C925 RID: 182565 RVA: 0x00AA6D3F File Offset: 0x00AA4F3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_FeedbackAnim_0D5CF2B74246127FC8669CA8AD51DA8C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_FeedbackAnim_0D5CF2B74246127FC8669CA8AD51DA8C_NativeFunctionPtr, null);
		}

		// Token: 0x0602C926 RID: 182566 RVA: 0x00AA6D53 File Offset: 0x00AA4F53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_BoneRotateToLocation_0CC2D58648A93DA1CC947D9EA2BA1910()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_BoneRotateToLocation_0CC2D58648A93DA1CC947D9EA2BA1910_NativeFunctionPtr, null);
		}

		// Token: 0x0602C927 RID: 182567 RVA: 0x00AA6D67 File Offset: 0x00AA4F67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_Feedback_51E4B51A468F1A65E6FF64A9A5F4B5CB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_Feedback_51E4B51A468F1A65E6FF64A9A5F4B5CB_NativeFunctionPtr, null);
		}

		// Token: 0x0602C928 RID: 182568 RVA: 0x00AA6D7B File Offset: 0x00AA4F7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_8FE4732440DE2B2FA8F0D19EE564E538()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_8FE4732440DE2B2FA8F0D19EE564E538_NativeFunctionPtr, null);
		}

		// Token: 0x0602C929 RID: 182569 RVA: 0x00AA6D8F File Offset: 0x00AA4F8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_148EAF7A4BDBB1686DADE7A597E0A76C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_148EAF7A4BDBB1686DADE7A597E0A76C_NativeFunctionPtr, null);
		}

		// Token: 0x0602C92A RID: 182570 RVA: 0x00AA6DA3 File Offset: 0x00AA4FA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_6AF484B4431B8C14FE283CB297B6B3EC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_6AF484B4431B8C14FE283CB297B6B3EC_NativeFunctionPtr, null);
		}

		// Token: 0x0602C92B RID: 182571 RVA: 0x00AA6DB7 File Offset: 0x00AA4FB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_1818FB2944DC831E96348689BFC2E103()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_1818FB2944DC831E96348689BFC2E103_NativeFunctionPtr, null);
		}

		// Token: 0x0602C92C RID: 182572 RVA: 0x00AA6DCB File Offset: 0x00AA4FCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_121708674083B1DE98AABE9895CD6935()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_121708674083B1DE98AABE9895CD6935_NativeFunctionPtr, null);
		}

		// Token: 0x0602C92D RID: 182573 RVA: 0x00AA6DDF File Offset: 0x00AA4FDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_CAA77B31439383A08DD9A684A49611B0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_CAA77B31439383A08DD9A684A49611B0_NativeFunctionPtr, null);
		}

		// Token: 0x0602C92E RID: 182574 RVA: 0x00AA6DF3 File Offset: 0x00AA4FF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_4CD09B1549F62595BCF402B26D20D1D3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_4CD09B1549F62595BCF402B26D20D1D3_NativeFunctionPtr, null);
		}

		// Token: 0x0602C92F RID: 182575 RVA: 0x00AA6E07 File Offset: 0x00AA5007
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_FC2F40D248658AA0187D7C8352A6275A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_FC2F40D248658AA0187D7C8352A6275A_NativeFunctionPtr, null);
		}

		// Token: 0x0602C930 RID: 182576 RVA: 0x00AA6E1B File Offset: 0x00AA501B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_941D22724432AEF11166288E517E2FBD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_941D22724432AEF11166288E517E2FBD_NativeFunctionPtr, null);
		}

		// Token: 0x0602C931 RID: 182577 RVA: 0x00AA6E2F File Offset: 0x00AA502F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_C8F75FDB4D43B0F22BC55386C196D222()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_C8F75FDB4D43B0F22BC55386C196D222_NativeFunctionPtr, null);
		}

		// Token: 0x0602C932 RID: 182578 RVA: 0x00AA6E43 File Offset: 0x00AA5043
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_85596CB24819748E20B7E98B1D415C01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_85596CB24819748E20B7E98B1D415C01_NativeFunctionPtr, null);
		}

		// Token: 0x0602C933 RID: 182579 RVA: 0x00AA6E57 File Offset: 0x00AA5057
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_8284B9304DC1D9EB88D60CB5D436515F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_8284B9304DC1D9EB88D60CB5D436515F_NativeFunctionPtr, null);
		}

		// Token: 0x0602C934 RID: 182580 RVA: 0x00AA6E6B File Offset: 0x00AA506B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_153A75684E72D893961594BC7BB4539D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_153A75684E72D893961594BC7BB4539D_NativeFunctionPtr, null);
		}

		// Token: 0x0602C935 RID: 182581 RVA: 0x00AA6E7F File Offset: 0x00AA507F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_4DEA819C457E35E72E5F48A5771FEFD9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_4DEA819C457E35E72E5F48A5771FEFD9_NativeFunctionPtr, null);
		}

		// Token: 0x0602C936 RID: 182582 RVA: 0x00AA6E93 File Offset: 0x00AA5093
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_52DA74EB4EEB034345C1CFBA9BE15A1A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_52DA74EB4EEB034345C1CFBA9BE15A1A_NativeFunctionPtr, null);
		}

		// Token: 0x0602C937 RID: 182583 RVA: 0x00AA6EA7 File Offset: 0x00AA50A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_685FFA67426C7F34E7D82C870BE2E57B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_685FFA67426C7F34E7D82C870BE2E57B_NativeFunctionPtr, null);
		}

		// Token: 0x0602C938 RID: 182584 RVA: 0x00AA6EBB File Offset: 0x00AA50BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_2DD95BC34A3508E4DF6823B128E6DE6A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_2DD95BC34A3508E4DF6823B128E6DE6A_NativeFunctionPtr, null);
		}

		// Token: 0x0602C939 RID: 182585 RVA: 0x00AA6ECF File Offset: 0x00AA50CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_D3A4A6444A7DE3555091D4A82F1D79C8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_D3A4A6444A7DE3555091D4A82F1D79C8_NativeFunctionPtr, null);
		}

		// Token: 0x0602C93A RID: 182586 RVA: 0x00AA6EE3 File Offset: 0x00AA50E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C93B RID: 182587 RVA: 0x00AA6EF7 File Offset: 0x00AA50F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MonsterCommon_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C93C RID: 182588 RVA: 0x00AA6F0C File Offset: 0x00AA510C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PlayShakeFX(int Section)
		{
			ABP_MonsterCommon_C.__PlayShakeFX_FunctionParams* ptr = stackalloc ABP_MonsterCommon_C.__PlayShakeFX_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_MonsterCommon_C.__PlayShakeFX_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MonsterCommon_C.__PlayShakeFX_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Section = Section;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__PlayShakeFX_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C93D RID: 182589 RVA: 0x00AA6F52 File Offset: 0x00AA5152
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C93E RID: 182590 RVA: 0x00AA6F66 File Offset: 0x00AA5166
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MonsterCommon_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C93F RID: 182591 RVA: 0x00AA6F7B File Offset: 0x00AA517B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TestFk()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_MonsterCommon_C.__TestFk_NativeFunctionPtr, null);
		}

		// Token: 0x0602C940 RID: 182592 RVA: 0x00AA6F90 File Offset: 0x00AA5190
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_MonsterCommon(int EntryPoint)
		{
			ABP_MonsterCommon_C.__ExecuteUbergraph_ABP_MonsterCommon_FunctionParams* ptr = stackalloc ABP_MonsterCommon_C.__ExecuteUbergraph_ABP_MonsterCommon_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(ABP_MonsterCommon_C.__ExecuteUbergraph_ABP_MonsterCommon_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_MonsterCommon_C.__ExecuteUbergraph_ABP_MonsterCommon_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_MonsterCommon_C.__ExecuteUbergraph_ABP_MonsterCommon_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C941 RID: 182593 RVA: 0x00AA6FDA File Offset: 0x00AA51DA
		protected ABP_MonsterCommon_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018BF4 RID: 101364
		public new const string __ObjectPath = "/Game/Aki/Character/Monster/Common/ABP_MonsterCommon.ABP_MonsterCommon_C";

		// Token: 0x04018BF5 RID: 101365
		private static IntPtr _ClassPtr;

		// Token: 0x04018BF6 RID: 101366
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018BF7 RID: 101367
		public static IntPtr __NewEventDispatcher_0__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04018BF8 RID: 101368
		internal static int __PropertyOffset_0;

		// Token: 0x04018BF9 RID: 101369
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018BFA RID: 101370
		internal static int __PropertyOffset_1;

		// Token: 0x04018BFB RID: 101371
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x04018BFC RID: 101372
		internal static int __PropertyOffset_2;

		// Token: 0x04018BFD RID: 101373
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04018BFE RID: 101374
		internal static int __PropertyOffset_3;

		// Token: 0x04018BFF RID: 101375
		[Nullable(2)]
		private FAnimNode_BoneRotateToLocation _AnimGraphNode_BoneRotateToLocation;

		// Token: 0x04018C00 RID: 101376
		internal static int __PropertyOffset_4;

		// Token: 0x04018C01 RID: 101377
		[Nullable(2)]
		private FAnimNode_FeedbackAnim _AnimGraphNode_FeedbackAnim;

		// Token: 0x04018C02 RID: 101378
		internal static int __PropertyOffset_5;

		// Token: 0x04018C03 RID: 101379
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018C04 RID: 101380
		internal static int __PropertyOffset_6;

		// Token: 0x04018C05 RID: 101381
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x04018C06 RID: 101382
		internal static int __PropertyOffset_7;

		// Token: 0x04018C07 RID: 101383
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x04018C08 RID: 101384
		internal static int __PropertyOffset_8;

		// Token: 0x04018C09 RID: 101385
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x04018C0A RID: 101386
		internal static int __PropertyOffset_9;

		// Token: 0x04018C0B RID: 101387
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x04018C0C RID: 101388
		internal static int __PropertyOffset_10;

		// Token: 0x04018C0D RID: 101389
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x04018C0E RID: 101390
		internal static int __PropertyOffset_11;

		// Token: 0x04018C0F RID: 101391
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x04018C10 RID: 101392
		internal static int __PropertyOffset_12;

		// Token: 0x04018C11 RID: 101393
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_3;

		// Token: 0x04018C12 RID: 101394
		internal static int __PropertyOffset_13;

		// Token: 0x04018C13 RID: 101395
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x04018C14 RID: 101396
		internal static int __PropertyOffset_14;

		// Token: 0x04018C15 RID: 101397
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x04018C16 RID: 101398
		internal static int __PropertyOffset_15;

		// Token: 0x04018C17 RID: 101399
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x04018C18 RID: 101400
		internal static int __PropertyOffset_16;

		// Token: 0x04018C19 RID: 101401
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_2;

		// Token: 0x04018C1A RID: 101402
		internal static int __PropertyOffset_17;

		// Token: 0x04018C1B RID: 101403
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04018C1C RID: 101404
		internal static int __PropertyOffset_18;

		// Token: 0x04018C1D RID: 101405
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x04018C1E RID: 101406
		internal static int __PropertyOffset_19;

		// Token: 0x04018C1F RID: 101407
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04018C20 RID: 101408
		internal static int __PropertyOffset_20;

		// Token: 0x04018C21 RID: 101409
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x04018C22 RID: 101410
		internal static int __PropertyOffset_21;

		// Token: 0x04018C23 RID: 101411
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x04018C24 RID: 101412
		internal static int __PropertyOffset_22;

		// Token: 0x04018C25 RID: 101413
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x04018C26 RID: 101414
		internal static int __PropertyOffset_23;

		// Token: 0x04018C27 RID: 101415
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04018C28 RID: 101416
		internal static int __PropertyOffset_24;

		// Token: 0x04018C29 RID: 101417
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04018C2A RID: 101418
		internal static int __PropertyOffset_25;

		// Token: 0x04018C2B RID: 101419
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04018C2C RID: 101420
		internal static int __PropertyOffset_26;

		// Token: 0x04018C2D RID: 101421
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04018C2E RID: 101422
		internal static int __PropertyOffset_27;

		// Token: 0x04018C2F RID: 101423
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x04018C30 RID: 101424
		internal static int __PropertyOffset_28;

		// Token: 0x04018C31 RID: 101425
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x04018C32 RID: 101426
		internal static int __PropertyOffset_29;

		// Token: 0x04018C33 RID: 101427
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x04018C34 RID: 101428
		internal static int __PropertyOffset_30;

		// Token: 0x04018C35 RID: 101429
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04018C36 RID: 101430
		internal static int __PropertyOffset_31;

		// Token: 0x04018C37 RID: 101431
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04018C38 RID: 101432
		internal static int __PropertyOffset_32;

		// Token: 0x04018C39 RID: 101433
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04018C3A RID: 101434
		internal static int __PropertyOffset_33;

		// Token: 0x04018C3B RID: 101435
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04018C3C RID: 101436
		internal static int __PropertyOffset_34;

		// Token: 0x04018C3D RID: 101437
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04018C3E RID: 101438
		internal static int __PropertyOffset_35;

		// Token: 0x04018C3F RID: 101439
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04018C40 RID: 101440
		internal static int __PropertyOffset_36;

		// Token: 0x04018C41 RID: 101441
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04018C42 RID: 101442
		internal static int __PropertyOffset_37;

		// Token: 0x04018C43 RID: 101443
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04018C44 RID: 101444
		internal static int __PropertyOffset_38;

		// Token: 0x04018C45 RID: 101445
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04018C46 RID: 101446
		internal static int __PropertyOffset_39;

		// Token: 0x04018C47 RID: 101447
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04018C48 RID: 101448
		internal static int __PropertyOffset_40;

		// Token: 0x04018C49 RID: 101449
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04018C4A RID: 101450
		internal static int __PropertyOffset_41;

		// Token: 0x04018C4B RID: 101451
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x04018C4C RID: 101452
		internal static int __PropertyOffset_42;

		// Token: 0x04018C4D RID: 101453
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04018C4E RID: 101454
		internal static int __PropertyOffset_43;

		// Token: 0x04018C4F RID: 101455
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04018C50 RID: 101456
		internal static int __PropertyOffset_44;

		// Token: 0x04018C51 RID: 101457
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_3;

		// Token: 0x04018C52 RID: 101458
		internal static int __PropertyOffset_45;

		// Token: 0x04018C53 RID: 101459
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_2;

		// Token: 0x04018C54 RID: 101460
		internal static int __PropertyOffset_46;

		// Token: 0x04018C55 RID: 101461
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_1;

		// Token: 0x04018C56 RID: 101462
		internal static int __PropertyOffset_47;

		// Token: 0x04018C57 RID: 101463
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04018C58 RID: 101464
		internal static int __PropertyOffset_48;

		// Token: 0x04018C59 RID: 101465
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04018C5A RID: 101466
		internal static int __PropertyOffset_49;

		// Token: 0x04018C5B RID: 101467
		[Nullable(2)]
		private FAnimNode_Feedback _AnimGraphNode_Feedback;

		// Token: 0x04018C5C RID: 101468
		internal static int __PropertyOffset_50;

		// Token: 0x04018C5D RID: 101469
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04018C5E RID: 101470
		internal static int __PropertyOffset_51;

		// Token: 0x04018C5F RID: 101471
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04018C60 RID: 101472
		internal static int __PropertyOffset_52;

		// Token: 0x04018C61 RID: 101473
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04018C62 RID: 101474
		internal static int __PropertyOffset_53;

		// Token: 0x04018C63 RID: 101475
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04018C64 RID: 101476
		internal static int __PropertyOffset_54;

		// Token: 0x04018C65 RID: 101477
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_1;

		// Token: 0x04018C66 RID: 101478
		internal static int __PropertyOffset_55;

		// Token: 0x04018C67 RID: 101479
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04018C68 RID: 101480
		internal static int __PropertyOffset_56;

		// Token: 0x04018C69 RID: 101481
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04018C6A RID: 101482
		internal static int __PropertyOffset_57;

		// Token: 0x04018C6B RID: 101483
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04018C6C RID: 101484
		internal static int __PropertyOffset_58;

		// Token: 0x04018C6D RID: 101485
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04018C6E RID: 101486
		internal static int __PropertyOffset_59;

		// Token: 0x04018C6F RID: 101487
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04018C70 RID: 101488
		internal static int __PropertyOffset_60;

		// Token: 0x04018C71 RID: 101489
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04018C72 RID: 101490
		internal static int __PropertyOffset_61;

		// Token: 0x04018C73 RID: 101491
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04018C74 RID: 101492
		internal static int __PropertyOffset_62;

		// Token: 0x04018C75 RID: 101493
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04018C76 RID: 101494
		internal static int __PropertyOffset_63;

		// Token: 0x04018C77 RID: 101495
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04018C78 RID: 101496
		internal static int __PropertyOffset_64;

		// Token: 0x04018C79 RID: 101497
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04018C7A RID: 101498
		internal static int __PropertyOffset_65;

		// Token: 0x04018C7B RID: 101499
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04018C7C RID: 101500
		internal static int __PropertyOffset_66;

		// Token: 0x04018C7D RID: 101501
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04018C7E RID: 101502
		internal static int __PropertyOffset_67;

		// Token: 0x04018C7F RID: 101503
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04018C80 RID: 101504
		internal static int __PropertyOffset_68;

		// Token: 0x04018C81 RID: 101505
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04018C82 RID: 101506
		internal static int __PropertyOffset_69;

		// Token: 0x04018C83 RID: 101507
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04018C84 RID: 101508
		internal static int __PropertyOffset_70;

		// Token: 0x04018C85 RID: 101509
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04018C86 RID: 101510
		internal static int __PropertyOffset_71;

		// Token: 0x04018C87 RID: 101511
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose;

		// Token: 0x04018C88 RID: 101512
		internal static int __PropertyOffset_72;

		// Token: 0x04018C89 RID: 101513
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018C8A RID: 101514
		internal static int __PropertyOffset_73;

		// Token: 0x04018C8B RID: 101515
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018C8C RID: 101516
		internal static int __PropertyOffset_74;

		// Token: 0x04018C8D RID: 101517
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04018C8E RID: 101518
		internal static int __PropertyOffset_75;

		// Token: 0x04018C8F RID: 101519
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018C90 RID: 101520
		internal static int __PropertyOffset_76;

		// Token: 0x04018C91 RID: 101521
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018C92 RID: 101522
		internal static int __PropertyOffset_77;

		// Token: 0x04018C93 RID: 101523
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose;

		// Token: 0x04018C94 RID: 101524
		internal static int __PropertyOffset_78;

		// Token: 0x04018C95 RID: 101525
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018C96 RID: 101526
		internal static int __PropertyOffset_79;

		// Token: 0x04018C97 RID: 101527
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018C98 RID: 101528
		internal static int __PropertyOffset_80;

		// Token: 0x04018C99 RID: 101529
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018C9A RID: 101530
		internal static int __PropertyOffset_81;

		// Token: 0x04018C9B RID: 101531
		internal static int __PropertyOffset_82;

		// Token: 0x04018C9C RID: 101532
		[Nullable(2)]
		private FSkeletonGroup _Skeleton_Block_Info;

		// Token: 0x04018C9D RID: 101533
		internal static int __PropertyOffset_83;

		// Token: 0x04018C9E RID: 101534
		internal static int __PropertyOffset_84;

		// Token: 0x04018C9F RID: 101535
		[Nullable(2)]
		private NewEventDispatcher_0 _NewEventDispatcher_0;

		// Token: 0x04018CA0 RID: 101536
		internal static int __PropertyOffset_85;

		// Token: 0x04018CA1 RID: 101537
		internal static int __PropertyOffset_86;

		// Token: 0x04018CA2 RID: 101538
		internal static int __PropertyOffset_87;

		// Token: 0x04018CA3 RID: 101539
		internal static int __PropertyOffset_88;

		// Token: 0x04018CA4 RID: 101540
		internal static int __PropertyOffset_89;

		// Token: 0x04018CA5 RID: 101541
		internal static int __PropertyOffset_90;

		// Token: 0x04018CA6 RID: 101542
		internal static int __PropertyOffset_91;

		// Token: 0x04018CA7 RID: 101543
		internal static int __PropertyOffset_92;

		// Token: 0x04018CA8 RID: 101544
		internal static int __PropertyOffset_93;

		// Token: 0x04018CA9 RID: 101545
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<PD_CharacterControllerData_C> _HitMaterial;

		// Token: 0x04018CAA RID: 101546
		internal static int __PropertyOffset_94;

		// Token: 0x04018CAB RID: 101547
		internal static int __PropertyOffset_95;

		// Token: 0x04018CAC RID: 101548
		[Nullable(2)]
		private FGameplayTagContainer _CachedTagContainer;

		// Token: 0x04018CAD RID: 101549
		internal static int __PropertyOffset_96;

		// Token: 0x04018CAE RID: 101550
		internal static int __PropertyOffset_97;

		// Token: 0x04018CAF RID: 101551
		internal static int __PropertyOffset_98;

		// Token: 0x04018CB0 RID: 101552
		internal static int __PropertyOffset_99;

		// Token: 0x04018CB1 RID: 101553
		internal static int __PropertyOffset_100;

		// Token: 0x04018CB2 RID: 101554
		internal static int __PropertyOffset_101;

		// Token: 0x04018CB3 RID: 101555
		internal static int __PropertyOffset_102;

		// Token: 0x04018CB4 RID: 101556
		[Nullable(2)]
		private FBoneFeedbackAnimConfigGroup _Feedback_Anim;

		// Token: 0x04018CB5 RID: 101557
		private static IntPtr __IKAndFk_NativeFunctionPtr;

		// Token: 0x04018CB6 RID: 101558
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018CB7 RID: 101559
		private static IntPtr __初始化绑定_Tag_NativeFunctionPtr;

		// Token: 0x04018CB8 RID: 101560
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_7366C1E545187F21B80550B938A5DFC7_NativeFunctionPtr;

		// Token: 0x04018CB9 RID: 101561
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_FeedbackAnim_0D5CF2B74246127FC8669CA8AD51DA8C_NativeFunctionPtr;

		// Token: 0x04018CBA RID: 101562
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_BoneRotateToLocation_0CC2D58648A93DA1CC947D9EA2BA1910_NativeFunctionPtr;

		// Token: 0x04018CBB RID: 101563
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_Feedback_51E4B51A468F1A65E6FF64A9A5F4B5CB_NativeFunctionPtr;

		// Token: 0x04018CBC RID: 101564
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_8FE4732440DE2B2FA8F0D19EE564E538_NativeFunctionPtr;

		// Token: 0x04018CBD RID: 101565
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_148EAF7A4BDBB1686DADE7A597E0A76C_NativeFunctionPtr;

		// Token: 0x04018CBE RID: 101566
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_6AF484B4431B8C14FE283CB297B6B3EC_NativeFunctionPtr;

		// Token: 0x04018CBF RID: 101567
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_1818FB2944DC831E96348689BFC2E103_NativeFunctionPtr;

		// Token: 0x04018CC0 RID: 101568
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_121708674083B1DE98AABE9895CD6935_NativeFunctionPtr;

		// Token: 0x04018CC1 RID: 101569
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_CAA77B31439383A08DD9A684A49611B0_NativeFunctionPtr;

		// Token: 0x04018CC2 RID: 101570
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_4CD09B1549F62595BCF402B26D20D1D3_NativeFunctionPtr;

		// Token: 0x04018CC3 RID: 101571
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_FC2F40D248658AA0187D7C8352A6275A_NativeFunctionPtr;

		// Token: 0x04018CC4 RID: 101572
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_941D22724432AEF11166288E517E2FBD_NativeFunctionPtr;

		// Token: 0x04018CC5 RID: 101573
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_C8F75FDB4D43B0F22BC55386C196D222_NativeFunctionPtr;

		// Token: 0x04018CC6 RID: 101574
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_85596CB24819748E20B7E98B1D415C01_NativeFunctionPtr;

		// Token: 0x04018CC7 RID: 101575
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_8284B9304DC1D9EB88D60CB5D436515F_NativeFunctionPtr;

		// Token: 0x04018CC8 RID: 101576
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_153A75684E72D893961594BC7BB4539D_NativeFunctionPtr;

		// Token: 0x04018CC9 RID: 101577
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_4DEA819C457E35E72E5F48A5771FEFD9_NativeFunctionPtr;

		// Token: 0x04018CCA RID: 101578
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_52DA74EB4EEB034345C1CFBA9BE15A1A_NativeFunctionPtr;

		// Token: 0x04018CCB RID: 101579
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_685FFA67426C7F34E7D82C870BE2E57B_NativeFunctionPtr;

		// Token: 0x04018CCC RID: 101580
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_2DD95BC34A3508E4DF6823B128E6DE6A_NativeFunctionPtr;

		// Token: 0x04018CCD RID: 101581
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_MonsterCommon_AnimGraphNode_TransitionResult_D3A4A6444A7DE3555091D4A82F1D79C8_NativeFunctionPtr;

		// Token: 0x04018CCE RID: 101582
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018CCF RID: 101583
		private static IntPtr __PlayShakeFX_NativeFunctionPtr;

		// Token: 0x04018CD0 RID: 101584
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x04018CD1 RID: 101585
		private static IntPtr __TestFk_NativeFunctionPtr;

		// Token: 0x04018CD2 RID: 101586
		private static IntPtr __ExecuteUbergraph_ABP_MonsterCommon_NativeFunctionPtr;

		// Token: 0x0200A45E RID: 42078
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __IKAndFk_FunctionParams
		{
			// Token: 0x04033260 RID: 209504
			[FieldOffset(0)]
			public byte InPose;

			// Token: 0x04033261 RID: 209505
			[FieldOffset(24)]
			public byte IKAndFk;
		}

		// Token: 0x0200A45F RID: 42079
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033262 RID: 209506
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A460 RID: 42080
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __PlayShakeFX_FunctionParams
		{
			// Token: 0x04033263 RID: 209507
			[FieldOffset(0)]
			public int Section;
		}

		// Token: 0x0200A461 RID: 42081
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __ExecuteUbergraph_ABP_MonsterCommon_FunctionParams
		{
			// Token: 0x04033264 RID: 209508
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
