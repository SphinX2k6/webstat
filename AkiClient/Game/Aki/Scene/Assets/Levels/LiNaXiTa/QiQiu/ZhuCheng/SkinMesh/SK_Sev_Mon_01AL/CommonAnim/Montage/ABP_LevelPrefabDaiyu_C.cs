using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.Assets.Levels.LiNaXiTa.QiQiu.ZhuCheng.SkinMesh.SK_Sev_Mon_01AL.CommonAnim.Montage
{
	// Token: 0x020039F3 RID: 14835
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/Levels/LiNaXiTa/QiQiu/ZhuCheng/SkinMesh/SK_Sev_Mon_01AL/CommonAnim/Montage/ABP_LevelPrefabDaiyu.ABP_LevelPrefabDaiyu_C")]
	[UnrealStructLayout(4544, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4532)]
	public class ABP_LevelPrefabDaiyu_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E22F RID: 123439 RVA: 0x008ED053 File Offset: 0x008EB253
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_LevelPrefabDaiyu_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Scene/Assets/Levels/LiNaXiTa/QiQiu/ZhuCheng/SkinMesh/SK_Sev_Mon_01AL/CommonAnim/Montage/ABP_LevelPrefabDaiyu.ABP_LevelPrefabDaiyu_C");
			}
			return ABP_LevelPrefabDaiyu_C._ClassPtr;
		}

		// Token: 0x0601E230 RID: 123440 RVA: 0x008ED078 File Offset: 0x008EB278
		public ABP_LevelPrefabDaiyu_C() : this(BuiltinUtils.AllocNativeUObject(ABP_LevelPrefabDaiyu_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E231 RID: 123441 RVA: 0x008ED0A0 File Offset: 0x008EB2A0
		public ABP_LevelPrefabDaiyu_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_LevelPrefabDaiyu_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170028A4 RID: 10404
		// (get) Token: 0x0601E232 RID: 123442 RVA: 0x008ED0D4 File Offset: 0x008EB2D4
		// (set) Token: 0x0601E233 RID: 123443 RVA: 0x008ED10D File Offset: 0x008EB30D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028A5 RID: 10405
		// (get) Token: 0x0601E234 RID: 123444 RVA: 0x008ED130 File Offset: 0x008EB330
		// (set) Token: 0x0601E235 RID: 123445 RVA: 0x008ED169 File Offset: 0x008EB369
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028A6 RID: 10406
		// (get) Token: 0x0601E236 RID: 123446 RVA: 0x008ED18C File Offset: 0x008EB38C
		// (set) Token: 0x0601E237 RID: 123447 RVA: 0x008ED1C5 File Offset: 0x008EB3C5
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028A7 RID: 10407
		// (get) Token: 0x0601E238 RID: 123448 RVA: 0x008ED1E8 File Offset: 0x008EB3E8
		// (set) Token: 0x0601E239 RID: 123449 RVA: 0x008ED221 File Offset: 0x008EB421
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028A8 RID: 10408
		// (get) Token: 0x0601E23A RID: 123450 RVA: 0x008ED244 File Offset: 0x008EB444
		// (set) Token: 0x0601E23B RID: 123451 RVA: 0x008ED27D File Offset: 0x008EB47D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028A9 RID: 10409
		// (get) Token: 0x0601E23C RID: 123452 RVA: 0x008ED2A0 File Offset: 0x008EB4A0
		// (set) Token: 0x0601E23D RID: 123453 RVA: 0x008ED2D9 File Offset: 0x008EB4D9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028AA RID: 10410
		// (get) Token: 0x0601E23E RID: 123454 RVA: 0x008ED2FC File Offset: 0x008EB4FC
		// (set) Token: 0x0601E23F RID: 123455 RVA: 0x008ED335 File Offset: 0x008EB535
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028AB RID: 10411
		// (get) Token: 0x0601E240 RID: 123456 RVA: 0x008ED358 File Offset: 0x008EB558
		// (set) Token: 0x0601E241 RID: 123457 RVA: 0x008ED391 File Offset: 0x008EB591
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028AC RID: 10412
		// (get) Token: 0x0601E242 RID: 123458 RVA: 0x008ED3B4 File Offset: 0x008EB5B4
		// (set) Token: 0x0601E243 RID: 123459 RVA: 0x008ED3ED File Offset: 0x008EB5ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028AD RID: 10413
		// (get) Token: 0x0601E244 RID: 123460 RVA: 0x008ED410 File Offset: 0x008EB610
		// (set) Token: 0x0601E245 RID: 123461 RVA: 0x008ED449 File Offset: 0x008EB649
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028AE RID: 10414
		// (get) Token: 0x0601E246 RID: 123462 RVA: 0x008ED46C File Offset: 0x008EB66C
		// (set) Token: 0x0601E247 RID: 123463 RVA: 0x008ED4A5 File Offset: 0x008EB6A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028AF RID: 10415
		// (get) Token: 0x0601E248 RID: 123464 RVA: 0x008ED4C8 File Offset: 0x008EB6C8
		// (set) Token: 0x0601E249 RID: 123465 RVA: 0x008ED501 File Offset: 0x008EB701
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B0 RID: 10416
		// (get) Token: 0x0601E24A RID: 123466 RVA: 0x008ED524 File Offset: 0x008EB724
		// (set) Token: 0x0601E24B RID: 123467 RVA: 0x008ED55D File Offset: 0x008EB75D
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B1 RID: 10417
		// (get) Token: 0x0601E24C RID: 123468 RVA: 0x008ED580 File Offset: 0x008EB780
		// (set) Token: 0x0601E24D RID: 123469 RVA: 0x008ED5B9 File Offset: 0x008EB7B9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B2 RID: 10418
		// (get) Token: 0x0601E24E RID: 123470 RVA: 0x008ED5DC File Offset: 0x008EB7DC
		// (set) Token: 0x0601E24F RID: 123471 RVA: 0x008ED615 File Offset: 0x008EB815
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B3 RID: 10419
		// (get) Token: 0x0601E250 RID: 123472 RVA: 0x008ED638 File Offset: 0x008EB838
		// (set) Token: 0x0601E251 RID: 123473 RVA: 0x008ED671 File Offset: 0x008EB871
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B4 RID: 10420
		// (get) Token: 0x0601E252 RID: 123474 RVA: 0x008ED694 File Offset: 0x008EB894
		// (set) Token: 0x0601E253 RID: 123475 RVA: 0x008ED6CD File Offset: 0x008EB8CD
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B5 RID: 10421
		// (get) Token: 0x0601E254 RID: 123476 RVA: 0x008ED6F0 File Offset: 0x008EB8F0
		// (set) Token: 0x0601E255 RID: 123477 RVA: 0x008ED729 File Offset: 0x008EB929
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170028B6 RID: 10422
		// (get) Token: 0x0601E256 RID: 123478 RVA: 0x008ED74A File Offset: 0x008EB94A
		// (set) Token: 0x0601E257 RID: 123479 RVA: 0x008ED75E File Offset: 0x008EB95E
		public unsafe string State
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_18)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_18)), value);
			}
		}

		// Token: 0x170028B7 RID: 10423
		// (get) Token: 0x0601E258 RID: 123480 RVA: 0x008ED773 File Offset: 0x008EB973
		// (set) Token: 0x0601E259 RID: 123481 RVA: 0x008ED783 File Offset: 0x008EB983
		public unsafe float PlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_LevelPrefabDaiyu_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x0601E25A RID: 123482 RVA: 0x008ED794 File Offset: 0x008EB994
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_LevelPrefabDaiyu_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_LevelPrefabDaiyu_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_LevelPrefabDaiyu_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_LevelPrefabDaiyu_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0601E25B RID: 123483 RVA: 0x008ED81C File Offset: 0x008EBA1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPlayRate(float playRate)
		{
			ABP_LevelPrefabDaiyu_C.__SetPlayRate_FunctionParams* ptr = stackalloc ABP_LevelPrefabDaiyu_C.__SetPlayRate_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_LevelPrefabDaiyu_C.__SetPlayRate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_LevelPrefabDaiyu_C.__SetPlayRate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->playRate = playRate;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__SetPlayRate_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E25C RID: 123484 RVA: 0x008ED864 File Offset: 0x008EBA64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetState(string NewParam)
		{
			ABP_LevelPrefabDaiyu_C.__SetState_FunctionParams* ptr = stackalloc ABP_LevelPrefabDaiyu_C.__SetState_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABP_LevelPrefabDaiyu_C.__SetState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_LevelPrefabDaiyu_C.__SetState_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->NewParam), NewParam);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__SetState_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(ABP_LevelPrefabDaiyu_C.__SetState_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E25D RID: 123485 RVA: 0x008ED8C1 File Offset: 0x008EBAC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_27735FDA4D4138537AC82A984F1FAD3D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_27735FDA4D4138537AC82A984F1FAD3D_NativeFunctionPtr, null);
		}

		// Token: 0x0601E25E RID: 123486 RVA: 0x008ED8D5 File Offset: 0x008EBAD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_0C09A7CC478518A81FF643A82589842B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_0C09A7CC478518A81FF643A82589842B_NativeFunctionPtr, null);
		}

		// Token: 0x0601E25F RID: 123487 RVA: 0x008ED8E9 File Offset: 0x008EBAE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_43BF012E42F76C96BA1F58A3BBF963C0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_43BF012E42F76C96BA1F58A3BBF963C0_NativeFunctionPtr, null);
		}

		// Token: 0x0601E260 RID: 123488 RVA: 0x008ED8FD File Offset: 0x008EBAFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_E4AA41CD46142E3F7C526C961E2827E4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_E4AA41CD46142E3F7C526C961E2827E4_NativeFunctionPtr, null);
		}

		// Token: 0x0601E261 RID: 123489 RVA: 0x008ED911 File Offset: 0x008EBB11
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_99E1DEEE4C2AD6699AF315B499EA11F8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_99E1DEEE4C2AD6699AF315B499EA11F8_NativeFunctionPtr, null);
		}

		// Token: 0x0601E262 RID: 123490 RVA: 0x008ED925 File Offset: 0x008EBB25
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_832F124B46C8009E74F026B6FAD140F0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_832F124B46C8009E74F026B6FAD140F0_NativeFunctionPtr, null);
		}

		// Token: 0x0601E263 RID: 123491 RVA: 0x008ED93C File Offset: 0x008EBB3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_LevelPrefabDaiyu(int EntryPoint)
		{
			ABP_LevelPrefabDaiyu_C.__ExecuteUbergraph_ABP_LevelPrefabDaiyu_FunctionParams* ptr = stackalloc ABP_LevelPrefabDaiyu_C.__ExecuteUbergraph_ABP_LevelPrefabDaiyu_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(ABP_LevelPrefabDaiyu_C.__ExecuteUbergraph_ABP_LevelPrefabDaiyu_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_LevelPrefabDaiyu_C.__ExecuteUbergraph_ABP_LevelPrefabDaiyu_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_LevelPrefabDaiyu_C.__ExecuteUbergraph_ABP_LevelPrefabDaiyu_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E264 RID: 123492 RVA: 0x008ED983 File Offset: 0x008EBB83
		protected ABP_LevelPrefabDaiyu_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400ECC3 RID: 60611
		public new const string __ObjectPath = "/Game/Aki/Scene/Assets/Levels/LiNaXiTa/QiQiu/ZhuCheng/SkinMesh/SK_Sev_Mon_01AL/CommonAnim/Montage/ABP_LevelPrefabDaiyu.ABP_LevelPrefabDaiyu_C";

		// Token: 0x0400ECC4 RID: 60612
		private static IntPtr _ClassPtr;

		// Token: 0x0400ECC5 RID: 60613
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400ECC6 RID: 60614
		internal static int __PropertyOffset_0;

		// Token: 0x0400ECC7 RID: 60615
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400ECC8 RID: 60616
		internal static int __PropertyOffset_1;

		// Token: 0x0400ECC9 RID: 60617
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x0400ECCA RID: 60618
		internal static int __PropertyOffset_2;

		// Token: 0x0400ECCB RID: 60619
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x0400ECCC RID: 60620
		internal static int __PropertyOffset_3;

		// Token: 0x0400ECCD RID: 60621
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x0400ECCE RID: 60622
		internal static int __PropertyOffset_4;

		// Token: 0x0400ECCF RID: 60623
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x0400ECD0 RID: 60624
		internal static int __PropertyOffset_5;

		// Token: 0x0400ECD1 RID: 60625
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0400ECD2 RID: 60626
		internal static int __PropertyOffset_6;

		// Token: 0x0400ECD3 RID: 60627
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x0400ECD4 RID: 60628
		internal static int __PropertyOffset_7;

		// Token: 0x0400ECD5 RID: 60629
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0400ECD6 RID: 60630
		internal static int __PropertyOffset_8;

		// Token: 0x0400ECD7 RID: 60631
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0400ECD8 RID: 60632
		internal static int __PropertyOffset_9;

		// Token: 0x0400ECD9 RID: 60633
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x0400ECDA RID: 60634
		internal static int __PropertyOffset_10;

		// Token: 0x0400ECDB RID: 60635
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x0400ECDC RID: 60636
		internal static int __PropertyOffset_11;

		// Token: 0x0400ECDD RID: 60637
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0400ECDE RID: 60638
		internal static int __PropertyOffset_12;

		// Token: 0x0400ECDF RID: 60639
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0400ECE0 RID: 60640
		internal static int __PropertyOffset_13;

		// Token: 0x0400ECE1 RID: 60641
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0400ECE2 RID: 60642
		internal static int __PropertyOffset_14;

		// Token: 0x0400ECE3 RID: 60643
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x0400ECE4 RID: 60644
		internal static int __PropertyOffset_15;

		// Token: 0x0400ECE5 RID: 60645
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x0400ECE6 RID: 60646
		internal static int __PropertyOffset_16;

		// Token: 0x0400ECE7 RID: 60647
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0400ECE8 RID: 60648
		internal static int __PropertyOffset_17;

		// Token: 0x0400ECE9 RID: 60649
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0400ECEA RID: 60650
		internal static int __PropertyOffset_18;

		// Token: 0x0400ECEB RID: 60651
		internal static int __PropertyOffset_19;

		// Token: 0x0400ECEC RID: 60652
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0400ECED RID: 60653
		private static IntPtr __SetPlayRate_NativeFunctionPtr;

		// Token: 0x0400ECEE RID: 60654
		private static IntPtr __SetState_NativeFunctionPtr;

		// Token: 0x0400ECEF RID: 60655
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_27735FDA4D4138537AC82A984F1FAD3D_NativeFunctionPtr;

		// Token: 0x0400ECF0 RID: 60656
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_0C09A7CC478518A81FF643A82589842B_NativeFunctionPtr;

		// Token: 0x0400ECF1 RID: 60657
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_43BF012E42F76C96BA1F58A3BBF963C0_NativeFunctionPtr;

		// Token: 0x0400ECF2 RID: 60658
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_E4AA41CD46142E3F7C526C961E2827E4_NativeFunctionPtr;

		// Token: 0x0400ECF3 RID: 60659
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_99E1DEEE4C2AD6699AF315B499EA11F8_NativeFunctionPtr;

		// Token: 0x0400ECF4 RID: 60660
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_LevelPrefabDaiyu_AnimGraphNode_TransitionResult_832F124B46C8009E74F026B6FAD140F0_NativeFunctionPtr;

		// Token: 0x0400ECF5 RID: 60661
		private static IntPtr __ExecuteUbergraph_ABP_LevelPrefabDaiyu_NativeFunctionPtr;

		// Token: 0x0200976E RID: 38766
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04031D19 RID: 204057
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200976F RID: 38767
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetPlayRate_FunctionParams
		{
			// Token: 0x04031D1A RID: 204058
			[FieldOffset(0)]
			public float playRate;
		}

		// Token: 0x02009770 RID: 38768
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SetState_FunctionParams
		{
			// Token: 0x04031D1B RID: 204059
			[FieldOffset(0)]
			public FString NewParam;
		}

		// Token: 0x02009771 RID: 38769
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __ExecuteUbergraph_ABP_LevelPrefabDaiyu_FunctionParams
		{
			// Token: 0x04031D1C RID: 204060
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
