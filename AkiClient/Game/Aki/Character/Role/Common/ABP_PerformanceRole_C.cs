using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.DT;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common
{
	// Token: 0x02003FFA RID: 16378
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C")]
	[UnrealStructLayout(30688, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 30677)]
	public class ABP_PerformanceRole_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A584 RID: 173444 RVA: 0x00A5494C File Offset: 0x00A52B4C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_PerformanceRole_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C");
			}
			return ABP_PerformanceRole_C._ClassPtr;
		}

		// Token: 0x0602A585 RID: 173445 RVA: 0x00A54970 File Offset: 0x00A52B70
		public ABP_PerformanceRole_C() : this(BuiltinUtils.AllocNativeUObject(ABP_PerformanceRole_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A586 RID: 173446 RVA: 0x00A54998 File Offset: 0x00A52B98
		public ABP_PerformanceRole_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_PerformanceRole_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006D4E RID: 27982
		// (get) Token: 0x0602A587 RID: 173447 RVA: 0x00A549CC File Offset: 0x00A52BCC
		// (set) Token: 0x0602A588 RID: 173448 RVA: 0x00A54A05 File Offset: 0x00A52C05
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D4F RID: 27983
		// (get) Token: 0x0602A589 RID: 173449 RVA: 0x00A54A28 File Offset: 0x00A52C28
		// (set) Token: 0x0602A58A RID: 173450 RVA: 0x00A54A61 File Offset: 0x00A52C61
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D50 RID: 27984
		// (get) Token: 0x0602A58B RID: 173451 RVA: 0x00A54A84 File Offset: 0x00A52C84
		// (set) Token: 0x0602A58C RID: 173452 RVA: 0x00A54ABD File Offset: 0x00A52CBD
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D51 RID: 27985
		// (get) Token: 0x0602A58D RID: 173453 RVA: 0x00A54AE0 File Offset: 0x00A52CE0
		// (set) Token: 0x0602A58E RID: 173454 RVA: 0x00A54B19 File Offset: 0x00A52D19
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D52 RID: 27986
		// (get) Token: 0x0602A58F RID: 173455 RVA: 0x00A54B3C File Offset: 0x00A52D3C
		// (set) Token: 0x0602A590 RID: 173456 RVA: 0x00A54B75 File Offset: 0x00A52D75
		public FAnimNode_RBF AnimGraphNode_RBF
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RBF result;
				if ((result = this._AnimGraphNode_RBF) == null)
				{
					result = (this._AnimGraphNode_RBF = new FAnimNode_RBF(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RBF.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D53 RID: 27987
		// (get) Token: 0x0602A591 RID: 173457 RVA: 0x00A54B98 File Offset: 0x00A52D98
		// (set) Token: 0x0602A592 RID: 173458 RVA: 0x00A54BD1 File Offset: 0x00A52DD1
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D54 RID: 27988
		// (get) Token: 0x0602A593 RID: 173459 RVA: 0x00A54BF4 File Offset: 0x00A52DF4
		// (set) Token: 0x0602A594 RID: 173460 RVA: 0x00A54C2D File Offset: 0x00A52E2D
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D55 RID: 27989
		// (get) Token: 0x0602A595 RID: 173461 RVA: 0x00A54C50 File Offset: 0x00A52E50
		// (set) Token: 0x0602A596 RID: 173462 RVA: 0x00A54C89 File Offset: 0x00A52E89
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_113
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_113) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_113 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D56 RID: 27990
		// (get) Token: 0x0602A597 RID: 173463 RVA: 0x00A54CAC File Offset: 0x00A52EAC
		// (set) Token: 0x0602A598 RID: 173464 RVA: 0x00A54CE5 File Offset: 0x00A52EE5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_112
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_112) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_112 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D57 RID: 27991
		// (get) Token: 0x0602A599 RID: 173465 RVA: 0x00A54D08 File Offset: 0x00A52F08
		// (set) Token: 0x0602A59A RID: 173466 RVA: 0x00A54D41 File Offset: 0x00A52F41
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_111
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_111) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_111 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D58 RID: 27992
		// (get) Token: 0x0602A59B RID: 173467 RVA: 0x00A54D64 File Offset: 0x00A52F64
		// (set) Token: 0x0602A59C RID: 173468 RVA: 0x00A54D9D File Offset: 0x00A52F9D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_110
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_110) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_110 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D59 RID: 27993
		// (get) Token: 0x0602A59D RID: 173469 RVA: 0x00A54DC0 File Offset: 0x00A52FC0
		// (set) Token: 0x0602A59E RID: 173470 RVA: 0x00A54DF9 File Offset: 0x00A52FF9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_109
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_109) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_109 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D5A RID: 27994
		// (get) Token: 0x0602A59F RID: 173471 RVA: 0x00A54E1C File Offset: 0x00A5301C
		// (set) Token: 0x0602A5A0 RID: 173472 RVA: 0x00A54E55 File Offset: 0x00A53055
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_108
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_108) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_108 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D5B RID: 27995
		// (get) Token: 0x0602A5A1 RID: 173473 RVA: 0x00A54E78 File Offset: 0x00A53078
		// (set) Token: 0x0602A5A2 RID: 173474 RVA: 0x00A54EB1 File Offset: 0x00A530B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_107
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_107) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_107 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D5C RID: 27996
		// (get) Token: 0x0602A5A3 RID: 173475 RVA: 0x00A54ED4 File Offset: 0x00A530D4
		// (set) Token: 0x0602A5A4 RID: 173476 RVA: 0x00A54F0D File Offset: 0x00A5310D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_106
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_106) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_106 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D5D RID: 27997
		// (get) Token: 0x0602A5A5 RID: 173477 RVA: 0x00A54F30 File Offset: 0x00A53130
		// (set) Token: 0x0602A5A6 RID: 173478 RVA: 0x00A54F69 File Offset: 0x00A53169
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_105
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_105) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_105 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D5E RID: 27998
		// (get) Token: 0x0602A5A7 RID: 173479 RVA: 0x00A54F8C File Offset: 0x00A5318C
		// (set) Token: 0x0602A5A8 RID: 173480 RVA: 0x00A54FC5 File Offset: 0x00A531C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_104
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_104) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_104 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D5F RID: 27999
		// (get) Token: 0x0602A5A9 RID: 173481 RVA: 0x00A54FE8 File Offset: 0x00A531E8
		// (set) Token: 0x0602A5AA RID: 173482 RVA: 0x00A55021 File Offset: 0x00A53221
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_103
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_103) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_103 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D60 RID: 28000
		// (get) Token: 0x0602A5AB RID: 173483 RVA: 0x00A55044 File Offset: 0x00A53244
		// (set) Token: 0x0602A5AC RID: 173484 RVA: 0x00A5507D File Offset: 0x00A5327D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_102
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_102) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_102 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D61 RID: 28001
		// (get) Token: 0x0602A5AD RID: 173485 RVA: 0x00A550A0 File Offset: 0x00A532A0
		// (set) Token: 0x0602A5AE RID: 173486 RVA: 0x00A550D9 File Offset: 0x00A532D9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_101
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_101) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_101 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D62 RID: 28002
		// (get) Token: 0x0602A5AF RID: 173487 RVA: 0x00A550FC File Offset: 0x00A532FC
		// (set) Token: 0x0602A5B0 RID: 173488 RVA: 0x00A55135 File Offset: 0x00A53335
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_100
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_100) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_100 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D63 RID: 28003
		// (get) Token: 0x0602A5B1 RID: 173489 RVA: 0x00A55158 File Offset: 0x00A53358
		// (set) Token: 0x0602A5B2 RID: 173490 RVA: 0x00A55191 File Offset: 0x00A53391
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_99
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_99) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_99 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D64 RID: 28004
		// (get) Token: 0x0602A5B3 RID: 173491 RVA: 0x00A551B4 File Offset: 0x00A533B4
		// (set) Token: 0x0602A5B4 RID: 173492 RVA: 0x00A551ED File Offset: 0x00A533ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_98
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_98) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_98 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D65 RID: 28005
		// (get) Token: 0x0602A5B5 RID: 173493 RVA: 0x00A55210 File Offset: 0x00A53410
		// (set) Token: 0x0602A5B6 RID: 173494 RVA: 0x00A55249 File Offset: 0x00A53449
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_97
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_97) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_97 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D66 RID: 28006
		// (get) Token: 0x0602A5B7 RID: 173495 RVA: 0x00A5526C File Offset: 0x00A5346C
		// (set) Token: 0x0602A5B8 RID: 173496 RVA: 0x00A552A5 File Offset: 0x00A534A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_96
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_96) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_96 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D67 RID: 28007
		// (get) Token: 0x0602A5B9 RID: 173497 RVA: 0x00A552C8 File Offset: 0x00A534C8
		// (set) Token: 0x0602A5BA RID: 173498 RVA: 0x00A55301 File Offset: 0x00A53501
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_95
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_95) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_95 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D68 RID: 28008
		// (get) Token: 0x0602A5BB RID: 173499 RVA: 0x00A55324 File Offset: 0x00A53524
		// (set) Token: 0x0602A5BC RID: 173500 RVA: 0x00A5535D File Offset: 0x00A5355D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_94
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_94) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_94 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D69 RID: 28009
		// (get) Token: 0x0602A5BD RID: 173501 RVA: 0x00A55380 File Offset: 0x00A53580
		// (set) Token: 0x0602A5BE RID: 173502 RVA: 0x00A553B9 File Offset: 0x00A535B9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_93
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_93) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_93 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D6A RID: 28010
		// (get) Token: 0x0602A5BF RID: 173503 RVA: 0x00A553DC File Offset: 0x00A535DC
		// (set) Token: 0x0602A5C0 RID: 173504 RVA: 0x00A55415 File Offset: 0x00A53615
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_92
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_92) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_92 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D6B RID: 28011
		// (get) Token: 0x0602A5C1 RID: 173505 RVA: 0x00A55438 File Offset: 0x00A53638
		// (set) Token: 0x0602A5C2 RID: 173506 RVA: 0x00A55471 File Offset: 0x00A53671
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_91
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_91) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_91 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D6C RID: 28012
		// (get) Token: 0x0602A5C3 RID: 173507 RVA: 0x00A55494 File Offset: 0x00A53694
		// (set) Token: 0x0602A5C4 RID: 173508 RVA: 0x00A554CD File Offset: 0x00A536CD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_90
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_90) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_90 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D6D RID: 28013
		// (get) Token: 0x0602A5C5 RID: 173509 RVA: 0x00A554F0 File Offset: 0x00A536F0
		// (set) Token: 0x0602A5C6 RID: 173510 RVA: 0x00A55529 File Offset: 0x00A53729
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_89
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_89) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_89 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D6E RID: 28014
		// (get) Token: 0x0602A5C7 RID: 173511 RVA: 0x00A5554C File Offset: 0x00A5374C
		// (set) Token: 0x0602A5C8 RID: 173512 RVA: 0x00A55585 File Offset: 0x00A53785
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_88
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_88) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_88 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D6F RID: 28015
		// (get) Token: 0x0602A5C9 RID: 173513 RVA: 0x00A555A8 File Offset: 0x00A537A8
		// (set) Token: 0x0602A5CA RID: 173514 RVA: 0x00A555E1 File Offset: 0x00A537E1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_87
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_87) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_87 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D70 RID: 28016
		// (get) Token: 0x0602A5CB RID: 173515 RVA: 0x00A55604 File Offset: 0x00A53804
		// (set) Token: 0x0602A5CC RID: 173516 RVA: 0x00A5563D File Offset: 0x00A5383D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_86
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_86) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_86 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D71 RID: 28017
		// (get) Token: 0x0602A5CD RID: 173517 RVA: 0x00A55660 File Offset: 0x00A53860
		// (set) Token: 0x0602A5CE RID: 173518 RVA: 0x00A55699 File Offset: 0x00A53899
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_85
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_85) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_85 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D72 RID: 28018
		// (get) Token: 0x0602A5CF RID: 173519 RVA: 0x00A556BC File Offset: 0x00A538BC
		// (set) Token: 0x0602A5D0 RID: 173520 RVA: 0x00A556F5 File Offset: 0x00A538F5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_84
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_84) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_84 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D73 RID: 28019
		// (get) Token: 0x0602A5D1 RID: 173521 RVA: 0x00A55718 File Offset: 0x00A53918
		// (set) Token: 0x0602A5D2 RID: 173522 RVA: 0x00A55751 File Offset: 0x00A53951
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_83
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_83) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_83 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D74 RID: 28020
		// (get) Token: 0x0602A5D3 RID: 173523 RVA: 0x00A55774 File Offset: 0x00A53974
		// (set) Token: 0x0602A5D4 RID: 173524 RVA: 0x00A557AD File Offset: 0x00A539AD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_82
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_82) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_82 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D75 RID: 28021
		// (get) Token: 0x0602A5D5 RID: 173525 RVA: 0x00A557D0 File Offset: 0x00A539D0
		// (set) Token: 0x0602A5D6 RID: 173526 RVA: 0x00A55809 File Offset: 0x00A53A09
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_81
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_81) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_81 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D76 RID: 28022
		// (get) Token: 0x0602A5D7 RID: 173527 RVA: 0x00A5582C File Offset: 0x00A53A2C
		// (set) Token: 0x0602A5D8 RID: 173528 RVA: 0x00A55865 File Offset: 0x00A53A65
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_80
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_80) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_80 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D77 RID: 28023
		// (get) Token: 0x0602A5D9 RID: 173529 RVA: 0x00A55888 File Offset: 0x00A53A88
		// (set) Token: 0x0602A5DA RID: 173530 RVA: 0x00A558C1 File Offset: 0x00A53AC1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_79
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_79) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_79 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D78 RID: 28024
		// (get) Token: 0x0602A5DB RID: 173531 RVA: 0x00A558E4 File Offset: 0x00A53AE4
		// (set) Token: 0x0602A5DC RID: 173532 RVA: 0x00A5591D File Offset: 0x00A53B1D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_78
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_78) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_78 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D79 RID: 28025
		// (get) Token: 0x0602A5DD RID: 173533 RVA: 0x00A55940 File Offset: 0x00A53B40
		// (set) Token: 0x0602A5DE RID: 173534 RVA: 0x00A55979 File Offset: 0x00A53B79
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_77
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_77) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_77 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D7A RID: 28026
		// (get) Token: 0x0602A5DF RID: 173535 RVA: 0x00A5599C File Offset: 0x00A53B9C
		// (set) Token: 0x0602A5E0 RID: 173536 RVA: 0x00A559D5 File Offset: 0x00A53BD5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_76
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_76) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_76 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D7B RID: 28027
		// (get) Token: 0x0602A5E1 RID: 173537 RVA: 0x00A559F8 File Offset: 0x00A53BF8
		// (set) Token: 0x0602A5E2 RID: 173538 RVA: 0x00A55A31 File Offset: 0x00A53C31
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_75
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_75) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_75 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D7C RID: 28028
		// (get) Token: 0x0602A5E3 RID: 173539 RVA: 0x00A55A54 File Offset: 0x00A53C54
		// (set) Token: 0x0602A5E4 RID: 173540 RVA: 0x00A55A8D File Offset: 0x00A53C8D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_74
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_74) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_74 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D7D RID: 28029
		// (get) Token: 0x0602A5E5 RID: 173541 RVA: 0x00A55AB0 File Offset: 0x00A53CB0
		// (set) Token: 0x0602A5E6 RID: 173542 RVA: 0x00A55AE9 File Offset: 0x00A53CE9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_73
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_73) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_73 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D7E RID: 28030
		// (get) Token: 0x0602A5E7 RID: 173543 RVA: 0x00A55B0C File Offset: 0x00A53D0C
		// (set) Token: 0x0602A5E8 RID: 173544 RVA: 0x00A55B45 File Offset: 0x00A53D45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_72
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_72) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_72 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D7F RID: 28031
		// (get) Token: 0x0602A5E9 RID: 173545 RVA: 0x00A55B68 File Offset: 0x00A53D68
		// (set) Token: 0x0602A5EA RID: 173546 RVA: 0x00A55BA1 File Offset: 0x00A53DA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_71
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_71) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_71 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D80 RID: 28032
		// (get) Token: 0x0602A5EB RID: 173547 RVA: 0x00A55BC4 File Offset: 0x00A53DC4
		// (set) Token: 0x0602A5EC RID: 173548 RVA: 0x00A55BFD File Offset: 0x00A53DFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_70
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_70) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_70 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D81 RID: 28033
		// (get) Token: 0x0602A5ED RID: 173549 RVA: 0x00A55C20 File Offset: 0x00A53E20
		// (set) Token: 0x0602A5EE RID: 173550 RVA: 0x00A55C59 File Offset: 0x00A53E59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_69
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_69) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_69 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D82 RID: 28034
		// (get) Token: 0x0602A5EF RID: 173551 RVA: 0x00A55C7C File Offset: 0x00A53E7C
		// (set) Token: 0x0602A5F0 RID: 173552 RVA: 0x00A55CB5 File Offset: 0x00A53EB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_68
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_68) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_68 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D83 RID: 28035
		// (get) Token: 0x0602A5F1 RID: 173553 RVA: 0x00A55CD8 File Offset: 0x00A53ED8
		// (set) Token: 0x0602A5F2 RID: 173554 RVA: 0x00A55D11 File Offset: 0x00A53F11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_67
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_67) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_67 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D84 RID: 28036
		// (get) Token: 0x0602A5F3 RID: 173555 RVA: 0x00A55D34 File Offset: 0x00A53F34
		// (set) Token: 0x0602A5F4 RID: 173556 RVA: 0x00A55D6D File Offset: 0x00A53F6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_66
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_66) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_66 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D85 RID: 28037
		// (get) Token: 0x0602A5F5 RID: 173557 RVA: 0x00A55D90 File Offset: 0x00A53F90
		// (set) Token: 0x0602A5F6 RID: 173558 RVA: 0x00A55DC9 File Offset: 0x00A53FC9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_65
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_65) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_65 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D86 RID: 28038
		// (get) Token: 0x0602A5F7 RID: 173559 RVA: 0x00A55DEC File Offset: 0x00A53FEC
		// (set) Token: 0x0602A5F8 RID: 173560 RVA: 0x00A55E25 File Offset: 0x00A54025
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_64
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_64) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_64 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D87 RID: 28039
		// (get) Token: 0x0602A5F9 RID: 173561 RVA: 0x00A55E48 File Offset: 0x00A54048
		// (set) Token: 0x0602A5FA RID: 173562 RVA: 0x00A55E81 File Offset: 0x00A54081
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_63
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_63) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_63 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D88 RID: 28040
		// (get) Token: 0x0602A5FB RID: 173563 RVA: 0x00A55EA4 File Offset: 0x00A540A4
		// (set) Token: 0x0602A5FC RID: 173564 RVA: 0x00A55EDD File Offset: 0x00A540DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_62
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_62) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_62 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D89 RID: 28041
		// (get) Token: 0x0602A5FD RID: 173565 RVA: 0x00A55F00 File Offset: 0x00A54100
		// (set) Token: 0x0602A5FE RID: 173566 RVA: 0x00A55F39 File Offset: 0x00A54139
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_61
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_61) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_61 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D8A RID: 28042
		// (get) Token: 0x0602A5FF RID: 173567 RVA: 0x00A55F5C File Offset: 0x00A5415C
		// (set) Token: 0x0602A600 RID: 173568 RVA: 0x00A55F95 File Offset: 0x00A54195
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_60
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_60) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_60 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D8B RID: 28043
		// (get) Token: 0x0602A601 RID: 173569 RVA: 0x00A55FB8 File Offset: 0x00A541B8
		// (set) Token: 0x0602A602 RID: 173570 RVA: 0x00A55FF1 File Offset: 0x00A541F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_59
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_59) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_59 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D8C RID: 28044
		// (get) Token: 0x0602A603 RID: 173571 RVA: 0x00A56014 File Offset: 0x00A54214
		// (set) Token: 0x0602A604 RID: 173572 RVA: 0x00A5604D File Offset: 0x00A5424D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_58
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_58) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_58 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D8D RID: 28045
		// (get) Token: 0x0602A605 RID: 173573 RVA: 0x00A56070 File Offset: 0x00A54270
		// (set) Token: 0x0602A606 RID: 173574 RVA: 0x00A560A9 File Offset: 0x00A542A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_34) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_34 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D8E RID: 28046
		// (get) Token: 0x0602A607 RID: 173575 RVA: 0x00A560CC File Offset: 0x00A542CC
		// (set) Token: 0x0602A608 RID: 173576 RVA: 0x00A56105 File Offset: 0x00A54305
		public FAnimNode_StateResult AnimGraphNode_StateResult_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_53) == null)
				{
					result = (this._AnimGraphNode_StateResult_53 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D8F RID: 28047
		// (get) Token: 0x0602A609 RID: 173577 RVA: 0x00A56128 File Offset: 0x00A54328
		// (set) Token: 0x0602A60A RID: 173578 RVA: 0x00A56161 File Offset: 0x00A54361
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_33) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_33 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D90 RID: 28048
		// (get) Token: 0x0602A60B RID: 173579 RVA: 0x00A56184 File Offset: 0x00A54384
		// (set) Token: 0x0602A60C RID: 173580 RVA: 0x00A561BD File Offset: 0x00A543BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_52) == null)
				{
					result = (this._AnimGraphNode_StateResult_52 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D91 RID: 28049
		// (get) Token: 0x0602A60D RID: 173581 RVA: 0x00A561E0 File Offset: 0x00A543E0
		// (set) Token: 0x0602A60E RID: 173582 RVA: 0x00A56219 File Offset: 0x00A54419
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_57
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_57) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_57 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D92 RID: 28050
		// (get) Token: 0x0602A60F RID: 173583 RVA: 0x00A5623C File Offset: 0x00A5443C
		// (set) Token: 0x0602A610 RID: 173584 RVA: 0x00A56275 File Offset: 0x00A54475
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_32) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_32 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D93 RID: 28051
		// (get) Token: 0x0602A611 RID: 173585 RVA: 0x00A56298 File Offset: 0x00A54498
		// (set) Token: 0x0602A612 RID: 173586 RVA: 0x00A562D1 File Offset: 0x00A544D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_51) == null)
				{
					result = (this._AnimGraphNode_StateResult_51 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D94 RID: 28052
		// (get) Token: 0x0602A613 RID: 173587 RVA: 0x00A562F4 File Offset: 0x00A544F4
		// (set) Token: 0x0602A614 RID: 173588 RVA: 0x00A5632D File Offset: 0x00A5452D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_56
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_56) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_56 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D95 RID: 28053
		// (get) Token: 0x0602A615 RID: 173589 RVA: 0x00A56350 File Offset: 0x00A54550
		// (set) Token: 0x0602A616 RID: 173590 RVA: 0x00A56389 File Offset: 0x00A54589
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_55
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_55) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_55 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D96 RID: 28054
		// (get) Token: 0x0602A617 RID: 173591 RVA: 0x00A563AC File Offset: 0x00A545AC
		// (set) Token: 0x0602A618 RID: 173592 RVA: 0x00A563E5 File Offset: 0x00A545E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_54
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_54) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_54 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D97 RID: 28055
		// (get) Token: 0x0602A619 RID: 173593 RVA: 0x00A56408 File Offset: 0x00A54608
		// (set) Token: 0x0602A61A RID: 173594 RVA: 0x00A56441 File Offset: 0x00A54641
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_13) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_13 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D98 RID: 28056
		// (get) Token: 0x0602A61B RID: 173595 RVA: 0x00A56464 File Offset: 0x00A54664
		// (set) Token: 0x0602A61C RID: 173596 RVA: 0x00A5649D File Offset: 0x00A5469D
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_12) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_12 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D99 RID: 28057
		// (get) Token: 0x0602A61D RID: 173597 RVA: 0x00A564C0 File Offset: 0x00A546C0
		// (set) Token: 0x0602A61E RID: 173598 RVA: 0x00A564F9 File Offset: 0x00A546F9
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D9A RID: 28058
		// (get) Token: 0x0602A61F RID: 173599 RVA: 0x00A5651C File Offset: 0x00A5471C
		// (set) Token: 0x0602A620 RID: 173600 RVA: 0x00A56555 File Offset: 0x00A54755
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_53) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_53 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D9B RID: 28059
		// (get) Token: 0x0602A621 RID: 173601 RVA: 0x00A56578 File Offset: 0x00A54778
		// (set) Token: 0x0602A622 RID: 173602 RVA: 0x00A565B1 File Offset: 0x00A547B1
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_5) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_5 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D9C RID: 28060
		// (get) Token: 0x0602A623 RID: 173603 RVA: 0x00A565D4 File Offset: 0x00A547D4
		// (set) Token: 0x0602A624 RID: 173604 RVA: 0x00A5660D File Offset: 0x00A5480D
		public FAnimNode_StateResult AnimGraphNode_StateResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_50) == null)
				{
					result = (this._AnimGraphNode_StateResult_50 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D9D RID: 28061
		// (get) Token: 0x0602A625 RID: 173605 RVA: 0x00A56630 File Offset: 0x00A54830
		// (set) Token: 0x0602A626 RID: 173606 RVA: 0x00A56669 File Offset: 0x00A54869
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_31) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_31 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D9E RID: 28062
		// (get) Token: 0x0602A627 RID: 173607 RVA: 0x00A5668C File Offset: 0x00A5488C
		// (set) Token: 0x0602A628 RID: 173608 RVA: 0x00A566C5 File Offset: 0x00A548C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_49) == null)
				{
					result = (this._AnimGraphNode_StateResult_49 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006D9F RID: 28063
		// (get) Token: 0x0602A629 RID: 173609 RVA: 0x00A566E8 File Offset: 0x00A548E8
		// (set) Token: 0x0602A62A RID: 173610 RVA: 0x00A56721 File Offset: 0x00A54921
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_30) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_30 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA0 RID: 28064
		// (get) Token: 0x0602A62B RID: 173611 RVA: 0x00A56744 File Offset: 0x00A54944
		// (set) Token: 0x0602A62C RID: 173612 RVA: 0x00A5677D File Offset: 0x00A5497D
		public FAnimNode_StateResult AnimGraphNode_StateResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_48) == null)
				{
					result = (this._AnimGraphNode_StateResult_48 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA1 RID: 28065
		// (get) Token: 0x0602A62D RID: 173613 RVA: 0x00A567A0 File Offset: 0x00A549A0
		// (set) Token: 0x0602A62E RID: 173614 RVA: 0x00A567D9 File Offset: 0x00A549D9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_11) == null)
				{
					result = (this._AnimGraphNode_StateMachine_11 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA2 RID: 28066
		// (get) Token: 0x0602A62F RID: 173615 RVA: 0x00A567FC File Offset: 0x00A549FC
		// (set) Token: 0x0602A630 RID: 173616 RVA: 0x00A56835 File Offset: 0x00A54A35
		public FAnimNode_StateResult AnimGraphNode_StateResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_47) == null)
				{
					result = (this._AnimGraphNode_StateResult_47 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA3 RID: 28067
		// (get) Token: 0x0602A631 RID: 173617 RVA: 0x00A56858 File Offset: 0x00A54A58
		// (set) Token: 0x0602A632 RID: 173618 RVA: 0x00A56891 File Offset: 0x00A54A91
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_52) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_52 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA4 RID: 28068
		// (get) Token: 0x0602A633 RID: 173619 RVA: 0x00A568B4 File Offset: 0x00A54AB4
		// (set) Token: 0x0602A634 RID: 173620 RVA: 0x00A568ED File Offset: 0x00A54AED
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_29) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_29 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA5 RID: 28069
		// (get) Token: 0x0602A635 RID: 173621 RVA: 0x00A56910 File Offset: 0x00A54B10
		// (set) Token: 0x0602A636 RID: 173622 RVA: 0x00A56949 File Offset: 0x00A54B49
		public FAnimNode_StateResult AnimGraphNode_StateResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_46) == null)
				{
					result = (this._AnimGraphNode_StateResult_46 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA6 RID: 28070
		// (get) Token: 0x0602A637 RID: 173623 RVA: 0x00A5696C File Offset: 0x00A54B6C
		// (set) Token: 0x0602A638 RID: 173624 RVA: 0x00A569A5 File Offset: 0x00A54BA5
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA7 RID: 28071
		// (get) Token: 0x0602A639 RID: 173625 RVA: 0x00A569C8 File Offset: 0x00A54BC8
		// (set) Token: 0x0602A63A RID: 173626 RVA: 0x00A56A01 File Offset: 0x00A54C01
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_28) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_28 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA8 RID: 28072
		// (get) Token: 0x0602A63B RID: 173627 RVA: 0x00A56A24 File Offset: 0x00A54C24
		// (set) Token: 0x0602A63C RID: 173628 RVA: 0x00A56A5D File Offset: 0x00A54C5D
		public FAnimNode_StateResult AnimGraphNode_StateResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_45) == null)
				{
					result = (this._AnimGraphNode_StateResult_45 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DA9 RID: 28073
		// (get) Token: 0x0602A63D RID: 173629 RVA: 0x00A56A80 File Offset: 0x00A54C80
		// (set) Token: 0x0602A63E RID: 173630 RVA: 0x00A56AB9 File Offset: 0x00A54CB9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_10) == null)
				{
					result = (this._AnimGraphNode_StateMachine_10 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DAA RID: 28074
		// (get) Token: 0x0602A63F RID: 173631 RVA: 0x00A56ADC File Offset: 0x00A54CDC
		// (set) Token: 0x0602A640 RID: 173632 RVA: 0x00A56B15 File Offset: 0x00A54D15
		public FAnimNode_StateResult AnimGraphNode_StateResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_44) == null)
				{
					result = (this._AnimGraphNode_StateResult_44 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DAB RID: 28075
		// (get) Token: 0x0602A641 RID: 173633 RVA: 0x00A56B38 File Offset: 0x00A54D38
		// (set) Token: 0x0602A642 RID: 173634 RVA: 0x00A56B71 File Offset: 0x00A54D71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_51) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_51 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DAC RID: 28076
		// (get) Token: 0x0602A643 RID: 173635 RVA: 0x00A56B94 File Offset: 0x00A54D94
		// (set) Token: 0x0602A644 RID: 173636 RVA: 0x00A56BCD File Offset: 0x00A54DCD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_27) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_27 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DAD RID: 28077
		// (get) Token: 0x0602A645 RID: 173637 RVA: 0x00A56BF0 File Offset: 0x00A54DF0
		// (set) Token: 0x0602A646 RID: 173638 RVA: 0x00A56C29 File Offset: 0x00A54E29
		public FAnimNode_StateResult AnimGraphNode_StateResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_43) == null)
				{
					result = (this._AnimGraphNode_StateResult_43 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DAE RID: 28078
		// (get) Token: 0x0602A647 RID: 173639 RVA: 0x00A56C4C File Offset: 0x00A54E4C
		// (set) Token: 0x0602A648 RID: 173640 RVA: 0x00A56C85 File Offset: 0x00A54E85
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DAF RID: 28079
		// (get) Token: 0x0602A649 RID: 173641 RVA: 0x00A56CA8 File Offset: 0x00A54EA8
		// (set) Token: 0x0602A64A RID: 173642 RVA: 0x00A56CE1 File Offset: 0x00A54EE1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_26) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_26 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB0 RID: 28080
		// (get) Token: 0x0602A64B RID: 173643 RVA: 0x00A56D04 File Offset: 0x00A54F04
		// (set) Token: 0x0602A64C RID: 173644 RVA: 0x00A56D3D File Offset: 0x00A54F3D
		public FAnimNode_StateResult AnimGraphNode_StateResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_42) == null)
				{
					result = (this._AnimGraphNode_StateResult_42 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB1 RID: 28081
		// (get) Token: 0x0602A64D RID: 173645 RVA: 0x00A56D60 File Offset: 0x00A54F60
		// (set) Token: 0x0602A64E RID: 173646 RVA: 0x00A56D99 File Offset: 0x00A54F99
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_9) == null)
				{
					result = (this._AnimGraphNode_StateMachine_9 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB2 RID: 28082
		// (get) Token: 0x0602A64F RID: 173647 RVA: 0x00A56DBC File Offset: 0x00A54FBC
		// (set) Token: 0x0602A650 RID: 173648 RVA: 0x00A56DF5 File Offset: 0x00A54FF5
		public FAnimNode_StateResult AnimGraphNode_StateResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_41) == null)
				{
					result = (this._AnimGraphNode_StateResult_41 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB3 RID: 28083
		// (get) Token: 0x0602A651 RID: 173649 RVA: 0x00A56E18 File Offset: 0x00A55018
		// (set) Token: 0x0602A652 RID: 173650 RVA: 0x00A56E51 File Offset: 0x00A55051
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_50) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_50 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB4 RID: 28084
		// (get) Token: 0x0602A653 RID: 173651 RVA: 0x00A56E74 File Offset: 0x00A55074
		// (set) Token: 0x0602A654 RID: 173652 RVA: 0x00A56EAD File Offset: 0x00A550AD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_25) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_25 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB5 RID: 28085
		// (get) Token: 0x0602A655 RID: 173653 RVA: 0x00A56ED0 File Offset: 0x00A550D0
		// (set) Token: 0x0602A656 RID: 173654 RVA: 0x00A56F09 File Offset: 0x00A55109
		public FAnimNode_StateResult AnimGraphNode_StateResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_40) == null)
				{
					result = (this._AnimGraphNode_StateResult_40 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB6 RID: 28086
		// (get) Token: 0x0602A657 RID: 173655 RVA: 0x00A56F2C File Offset: 0x00A5512C
		// (set) Token: 0x0602A658 RID: 173656 RVA: 0x00A56F65 File Offset: 0x00A55165
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_49) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_49 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB7 RID: 28087
		// (get) Token: 0x0602A659 RID: 173657 RVA: 0x00A56F88 File Offset: 0x00A55188
		// (set) Token: 0x0602A65A RID: 173658 RVA: 0x00A56FC1 File Offset: 0x00A551C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_48) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_48 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB8 RID: 28088
		// (get) Token: 0x0602A65B RID: 173659 RVA: 0x00A56FE4 File Offset: 0x00A551E4
		// (set) Token: 0x0602A65C RID: 173660 RVA: 0x00A5701D File Offset: 0x00A5521D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_47) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_47 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DB9 RID: 28089
		// (get) Token: 0x0602A65D RID: 173661 RVA: 0x00A57040 File Offset: 0x00A55240
		// (set) Token: 0x0602A65E RID: 173662 RVA: 0x00A57079 File Offset: 0x00A55279
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_46) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_46 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DBA RID: 28090
		// (get) Token: 0x0602A65F RID: 173663 RVA: 0x00A5709C File Offset: 0x00A5529C
		// (set) Token: 0x0602A660 RID: 173664 RVA: 0x00A570D5 File Offset: 0x00A552D5
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_11) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_11 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DBB RID: 28091
		// (get) Token: 0x0602A661 RID: 173665 RVA: 0x00A570F8 File Offset: 0x00A552F8
		// (set) Token: 0x0602A662 RID: 173666 RVA: 0x00A57131 File Offset: 0x00A55331
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_10) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_10 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DBC RID: 28092
		// (get) Token: 0x0602A663 RID: 173667 RVA: 0x00A57154 File Offset: 0x00A55354
		// (set) Token: 0x0602A664 RID: 173668 RVA: 0x00A5718D File Offset: 0x00A5538D
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DBD RID: 28093
		// (get) Token: 0x0602A665 RID: 173669 RVA: 0x00A571B0 File Offset: 0x00A553B0
		// (set) Token: 0x0602A666 RID: 173670 RVA: 0x00A571E9 File Offset: 0x00A553E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_45) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_45 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DBE RID: 28094
		// (get) Token: 0x0602A667 RID: 173671 RVA: 0x00A5720C File Offset: 0x00A5540C
		// (set) Token: 0x0602A668 RID: 173672 RVA: 0x00A57245 File Offset: 0x00A55445
		public FAnimNode_StateResult AnimGraphNode_StateResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_39) == null)
				{
					result = (this._AnimGraphNode_StateResult_39 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DBF RID: 28095
		// (get) Token: 0x0602A669 RID: 173673 RVA: 0x00A57268 File Offset: 0x00A55468
		// (set) Token: 0x0602A66A RID: 173674 RVA: 0x00A572A1 File Offset: 0x00A554A1
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC0 RID: 28096
		// (get) Token: 0x0602A66B RID: 173675 RVA: 0x00A572C4 File Offset: 0x00A554C4
		// (set) Token: 0x0602A66C RID: 173676 RVA: 0x00A572FD File Offset: 0x00A554FD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_24) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_24 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC1 RID: 28097
		// (get) Token: 0x0602A66D RID: 173677 RVA: 0x00A57320 File Offset: 0x00A55520
		// (set) Token: 0x0602A66E RID: 173678 RVA: 0x00A57359 File Offset: 0x00A55559
		public FAnimNode_StateResult AnimGraphNode_StateResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_38) == null)
				{
					result = (this._AnimGraphNode_StateResult_38 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_115, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_115, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC2 RID: 28098
		// (get) Token: 0x0602A66F RID: 173679 RVA: 0x00A5737C File Offset: 0x00A5557C
		// (set) Token: 0x0602A670 RID: 173680 RVA: 0x00A573B5 File Offset: 0x00A555B5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_23) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_23 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_116, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_116, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC3 RID: 28099
		// (get) Token: 0x0602A671 RID: 173681 RVA: 0x00A573D8 File Offset: 0x00A555D8
		// (set) Token: 0x0602A672 RID: 173682 RVA: 0x00A57411 File Offset: 0x00A55611
		public FAnimNode_StateResult AnimGraphNode_StateResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_37) == null)
				{
					result = (this._AnimGraphNode_StateResult_37 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_117, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_117, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC4 RID: 28100
		// (get) Token: 0x0602A673 RID: 173683 RVA: 0x00A57434 File Offset: 0x00A55634
		// (set) Token: 0x0602A674 RID: 173684 RVA: 0x00A5746D File Offset: 0x00A5566D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_8) == null)
				{
					result = (this._AnimGraphNode_StateMachine_8 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_118, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC5 RID: 28101
		// (get) Token: 0x0602A675 RID: 173685 RVA: 0x00A57490 File Offset: 0x00A55690
		// (set) Token: 0x0602A676 RID: 173686 RVA: 0x00A574C9 File Offset: 0x00A556C9
		public FAnimNode_StateResult AnimGraphNode_StateResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_36) == null)
				{
					result = (this._AnimGraphNode_StateResult_36 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_119, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_119, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC6 RID: 28102
		// (get) Token: 0x0602A677 RID: 173687 RVA: 0x00A574EC File Offset: 0x00A556EC
		// (set) Token: 0x0602A678 RID: 173688 RVA: 0x00A57525 File Offset: 0x00A55725
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_22) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_22 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_120, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_120, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC7 RID: 28103
		// (get) Token: 0x0602A679 RID: 173689 RVA: 0x00A57548 File Offset: 0x00A55748
		// (set) Token: 0x0602A67A RID: 173690 RVA: 0x00A57581 File Offset: 0x00A55781
		public FAnimNode_StateResult AnimGraphNode_StateResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_35) == null)
				{
					result = (this._AnimGraphNode_StateResult_35 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_121, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_121, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC8 RID: 28104
		// (get) Token: 0x0602A67B RID: 173691 RVA: 0x00A575A4 File Offset: 0x00A557A4
		// (set) Token: 0x0602A67C RID: 173692 RVA: 0x00A575DD File Offset: 0x00A557DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_44) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_44 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_122, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_122, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DC9 RID: 28105
		// (get) Token: 0x0602A67D RID: 173693 RVA: 0x00A57600 File Offset: 0x00A55800
		// (set) Token: 0x0602A67E RID: 173694 RVA: 0x00A57639 File Offset: 0x00A55839
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_43) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_43 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_123, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_123, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DCA RID: 28106
		// (get) Token: 0x0602A67F RID: 173695 RVA: 0x00A5765C File Offset: 0x00A5585C
		// (set) Token: 0x0602A680 RID: 173696 RVA: 0x00A57695 File Offset: 0x00A55895
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_42) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_42 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_124, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_124, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DCB RID: 28107
		// (get) Token: 0x0602A681 RID: 173697 RVA: 0x00A576B8 File Offset: 0x00A558B8
		// (set) Token: 0x0602A682 RID: 173698 RVA: 0x00A576F1 File Offset: 0x00A558F1
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_9) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_9 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_125, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_125, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DCC RID: 28108
		// (get) Token: 0x0602A683 RID: 173699 RVA: 0x00A57714 File Offset: 0x00A55914
		// (set) Token: 0x0602A684 RID: 173700 RVA: 0x00A5774D File Offset: 0x00A5594D
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_8) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_8 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_126, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_126, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DCD RID: 28109
		// (get) Token: 0x0602A685 RID: 173701 RVA: 0x00A57770 File Offset: 0x00A55970
		// (set) Token: 0x0602A686 RID: 173702 RVA: 0x00A577A9 File Offset: 0x00A559A9
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_127, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_127, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DCE RID: 28110
		// (get) Token: 0x0602A687 RID: 173703 RVA: 0x00A577CC File Offset: 0x00A559CC
		// (set) Token: 0x0602A688 RID: 173704 RVA: 0x00A57805 File Offset: 0x00A55A05
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_41) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_41 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_128, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DCF RID: 28111
		// (get) Token: 0x0602A689 RID: 173705 RVA: 0x00A57828 File Offset: 0x00A55A28
		// (set) Token: 0x0602A68A RID: 173706 RVA: 0x00A57861 File Offset: 0x00A55A61
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_4) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_4 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_129, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_129, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD0 RID: 28112
		// (get) Token: 0x0602A68B RID: 173707 RVA: 0x00A57884 File Offset: 0x00A55A84
		// (set) Token: 0x0602A68C RID: 173708 RVA: 0x00A578BD File Offset: 0x00A55ABD
		public FAnimNode_StateResult AnimGraphNode_StateResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_34) == null)
				{
					result = (this._AnimGraphNode_StateResult_34 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_130, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_130, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD1 RID: 28113
		// (get) Token: 0x0602A68D RID: 173709 RVA: 0x00A578E0 File Offset: 0x00A55AE0
		// (set) Token: 0x0602A68E RID: 173710 RVA: 0x00A57919 File Offset: 0x00A55B19
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_21) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_21 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_131, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_131, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD2 RID: 28114
		// (get) Token: 0x0602A68F RID: 173711 RVA: 0x00A5793C File Offset: 0x00A55B3C
		// (set) Token: 0x0602A690 RID: 173712 RVA: 0x00A57975 File Offset: 0x00A55B75
		public FAnimNode_StateResult AnimGraphNode_StateResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_33) == null)
				{
					result = (this._AnimGraphNode_StateResult_33 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_132, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_132, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD3 RID: 28115
		// (get) Token: 0x0602A691 RID: 173713 RVA: 0x00A57998 File Offset: 0x00A55B98
		// (set) Token: 0x0602A692 RID: 173714 RVA: 0x00A579D1 File Offset: 0x00A55BD1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_20) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_20 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_133, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_133, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD4 RID: 28116
		// (get) Token: 0x0602A693 RID: 173715 RVA: 0x00A579F4 File Offset: 0x00A55BF4
		// (set) Token: 0x0602A694 RID: 173716 RVA: 0x00A57A2D File Offset: 0x00A55C2D
		public FAnimNode_StateResult AnimGraphNode_StateResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_32) == null)
				{
					result = (this._AnimGraphNode_StateResult_32 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_134, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_134, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD5 RID: 28117
		// (get) Token: 0x0602A695 RID: 173717 RVA: 0x00A57A50 File Offset: 0x00A55C50
		// (set) Token: 0x0602A696 RID: 173718 RVA: 0x00A57A89 File Offset: 0x00A55C89
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_7) == null)
				{
					result = (this._AnimGraphNode_StateMachine_7 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_135, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_135, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD6 RID: 28118
		// (get) Token: 0x0602A697 RID: 173719 RVA: 0x00A57AAC File Offset: 0x00A55CAC
		// (set) Token: 0x0602A698 RID: 173720 RVA: 0x00A57AE5 File Offset: 0x00A55CE5
		public FAnimNode_StateResult AnimGraphNode_StateResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_31) == null)
				{
					result = (this._AnimGraphNode_StateResult_31 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_136, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_136, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD7 RID: 28119
		// (get) Token: 0x0602A699 RID: 173721 RVA: 0x00A57B08 File Offset: 0x00A55D08
		// (set) Token: 0x0602A69A RID: 173722 RVA: 0x00A57B41 File Offset: 0x00A55D41
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_40) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_40 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_137, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_137, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD8 RID: 28120
		// (get) Token: 0x0602A69B RID: 173723 RVA: 0x00A57B64 File Offset: 0x00A55D64
		// (set) Token: 0x0602A69C RID: 173724 RVA: 0x00A57B9D File Offset: 0x00A55D9D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_39) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_39 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_138, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_138, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DD9 RID: 28121
		// (get) Token: 0x0602A69D RID: 173725 RVA: 0x00A57BC0 File Offset: 0x00A55DC0
		// (set) Token: 0x0602A69E RID: 173726 RVA: 0x00A57BF9 File Offset: 0x00A55DF9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_38) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_38 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_139, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_139, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DDA RID: 28122
		// (get) Token: 0x0602A69F RID: 173727 RVA: 0x00A57C1C File Offset: 0x00A55E1C
		// (set) Token: 0x0602A6A0 RID: 173728 RVA: 0x00A57C55 File Offset: 0x00A55E55
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_37) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_37 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_140, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_140, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DDB RID: 28123
		// (get) Token: 0x0602A6A1 RID: 173729 RVA: 0x00A57C78 File Offset: 0x00A55E78
		// (set) Token: 0x0602A6A2 RID: 173730 RVA: 0x00A57CB1 File Offset: 0x00A55EB1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_36) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_36 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_141, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_141, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DDC RID: 28124
		// (get) Token: 0x0602A6A3 RID: 173731 RVA: 0x00A57CD4 File Offset: 0x00A55ED4
		// (set) Token: 0x0602A6A4 RID: 173732 RVA: 0x00A57D0D File Offset: 0x00A55F0D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_35) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_35 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_142, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_142, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DDD RID: 28125
		// (get) Token: 0x0602A6A5 RID: 173733 RVA: 0x00A57D30 File Offset: 0x00A55F30
		// (set) Token: 0x0602A6A6 RID: 173734 RVA: 0x00A57D69 File Offset: 0x00A55F69
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_34) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_34 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_143, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_143, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DDE RID: 28126
		// (get) Token: 0x0602A6A7 RID: 173735 RVA: 0x00A57D8C File Offset: 0x00A55F8C
		// (set) Token: 0x0602A6A8 RID: 173736 RVA: 0x00A57DC5 File Offset: 0x00A55FC5
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_7) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_7 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_144, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_144, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DDF RID: 28127
		// (get) Token: 0x0602A6A9 RID: 173737 RVA: 0x00A57DE8 File Offset: 0x00A55FE8
		// (set) Token: 0x0602A6AA RID: 173738 RVA: 0x00A57E21 File Offset: 0x00A56021
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_6) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_6 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_145, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_145, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE0 RID: 28128
		// (get) Token: 0x0602A6AB RID: 173739 RVA: 0x00A57E44 File Offset: 0x00A56044
		// (set) Token: 0x0602A6AC RID: 173740 RVA: 0x00A57E7D File Offset: 0x00A5607D
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_146, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_146, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE1 RID: 28129
		// (get) Token: 0x0602A6AD RID: 173741 RVA: 0x00A57EA0 File Offset: 0x00A560A0
		// (set) Token: 0x0602A6AE RID: 173742 RVA: 0x00A57ED9 File Offset: 0x00A560D9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_147, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_147, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE2 RID: 28130
		// (get) Token: 0x0602A6AF RID: 173743 RVA: 0x00A57EFC File Offset: 0x00A560FC
		// (set) Token: 0x0602A6B0 RID: 173744 RVA: 0x00A57F35 File Offset: 0x00A56135
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_148, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_148, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE3 RID: 28131
		// (get) Token: 0x0602A6B1 RID: 173745 RVA: 0x00A57F58 File Offset: 0x00A56158
		// (set) Token: 0x0602A6B2 RID: 173746 RVA: 0x00A57F91 File Offset: 0x00A56191
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_3) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_3 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_149, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_149, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE4 RID: 28132
		// (get) Token: 0x0602A6B3 RID: 173747 RVA: 0x00A57FB4 File Offset: 0x00A561B4
		// (set) Token: 0x0602A6B4 RID: 173748 RVA: 0x00A57FED File Offset: 0x00A561ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_30) == null)
				{
					result = (this._AnimGraphNode_StateResult_30 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_150, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_150, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE5 RID: 28133
		// (get) Token: 0x0602A6B5 RID: 173749 RVA: 0x00A58010 File Offset: 0x00A56210
		// (set) Token: 0x0602A6B6 RID: 173750 RVA: 0x00A58049 File Offset: 0x00A56249
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_19) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_19 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_151, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_151, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE6 RID: 28134
		// (get) Token: 0x0602A6B7 RID: 173751 RVA: 0x00A5806C File Offset: 0x00A5626C
		// (set) Token: 0x0602A6B8 RID: 173752 RVA: 0x00A580A5 File Offset: 0x00A562A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_152, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_152, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE7 RID: 28135
		// (get) Token: 0x0602A6B9 RID: 173753 RVA: 0x00A580C8 File Offset: 0x00A562C8
		// (set) Token: 0x0602A6BA RID: 173754 RVA: 0x00A58101 File Offset: 0x00A56301
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_18) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_18 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_153, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_153, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE8 RID: 28136
		// (get) Token: 0x0602A6BB RID: 173755 RVA: 0x00A58124 File Offset: 0x00A56324
		// (set) Token: 0x0602A6BC RID: 173756 RVA: 0x00A5815D File Offset: 0x00A5635D
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_154, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_154, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DE9 RID: 28137
		// (get) Token: 0x0602A6BD RID: 173757 RVA: 0x00A58180 File Offset: 0x00A56380
		// (set) Token: 0x0602A6BE RID: 173758 RVA: 0x00A581B9 File Offset: 0x00A563B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_155, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_155, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DEA RID: 28138
		// (get) Token: 0x0602A6BF RID: 173759 RVA: 0x00A581DC File Offset: 0x00A563DC
		// (set) Token: 0x0602A6C0 RID: 173760 RVA: 0x00A58215 File Offset: 0x00A56415
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_156, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_156, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DEB RID: 28139
		// (get) Token: 0x0602A6C1 RID: 173761 RVA: 0x00A58238 File Offset: 0x00A56438
		// (set) Token: 0x0602A6C2 RID: 173762 RVA: 0x00A58271 File Offset: 0x00A56471
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_6) == null)
				{
					result = (this._AnimGraphNode_StateMachine_6 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_157, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_157, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DEC RID: 28140
		// (get) Token: 0x0602A6C3 RID: 173763 RVA: 0x00A58294 File Offset: 0x00A56494
		// (set) Token: 0x0602A6C4 RID: 173764 RVA: 0x00A582CD File Offset: 0x00A564CD
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_158, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_158, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DED RID: 28141
		// (get) Token: 0x0602A6C5 RID: 173765 RVA: 0x00A582F0 File Offset: 0x00A564F0
		// (set) Token: 0x0602A6C6 RID: 173766 RVA: 0x00A58329 File Offset: 0x00A56529
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_159, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_159, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DEE RID: 28142
		// (get) Token: 0x0602A6C7 RID: 173767 RVA: 0x00A5834C File Offset: 0x00A5654C
		// (set) Token: 0x0602A6C8 RID: 173768 RVA: 0x00A58385 File Offset: 0x00A56585
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_17) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_17 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_160, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_160, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DEF RID: 28143
		// (get) Token: 0x0602A6C9 RID: 173769 RVA: 0x00A583A8 File Offset: 0x00A565A8
		// (set) Token: 0x0602A6CA RID: 173770 RVA: 0x00A583E1 File Offset: 0x00A565E1
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_161, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_161, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF0 RID: 28144
		// (get) Token: 0x0602A6CB RID: 173771 RVA: 0x00A58404 File Offset: 0x00A56604
		// (set) Token: 0x0602A6CC RID: 173772 RVA: 0x00A5843D File Offset: 0x00A5663D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_162, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_162, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF1 RID: 28145
		// (get) Token: 0x0602A6CD RID: 173773 RVA: 0x00A58460 File Offset: 0x00A56660
		// (set) Token: 0x0602A6CE RID: 173774 RVA: 0x00A58499 File Offset: 0x00A56699
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_163, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_163, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF2 RID: 28146
		// (get) Token: 0x0602A6CF RID: 173775 RVA: 0x00A584BC File Offset: 0x00A566BC
		// (set) Token: 0x0602A6D0 RID: 173776 RVA: 0x00A584F5 File Offset: 0x00A566F5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_164, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_164, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF3 RID: 28147
		// (get) Token: 0x0602A6D1 RID: 173777 RVA: 0x00A58518 File Offset: 0x00A56718
		// (set) Token: 0x0602A6D2 RID: 173778 RVA: 0x00A58551 File Offset: 0x00A56751
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_5) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_5 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_165, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_165, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF4 RID: 28148
		// (get) Token: 0x0602A6D3 RID: 173779 RVA: 0x00A58574 File Offset: 0x00A56774
		// (set) Token: 0x0602A6D4 RID: 173780 RVA: 0x00A585AD File Offset: 0x00A567AD
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_4) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_4 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_166, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_166, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF5 RID: 28149
		// (get) Token: 0x0602A6D5 RID: 173781 RVA: 0x00A585D0 File Offset: 0x00A567D0
		// (set) Token: 0x0602A6D6 RID: 173782 RVA: 0x00A58609 File Offset: 0x00A56809
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_167, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_167, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF6 RID: 28150
		// (get) Token: 0x0602A6D7 RID: 173783 RVA: 0x00A5862C File Offset: 0x00A5682C
		// (set) Token: 0x0602A6D8 RID: 173784 RVA: 0x00A58665 File Offset: 0x00A56865
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_168, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_168, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF7 RID: 28151
		// (get) Token: 0x0602A6D9 RID: 173785 RVA: 0x00A58688 File Offset: 0x00A56888
		// (set) Token: 0x0602A6DA RID: 173786 RVA: 0x00A586C1 File Offset: 0x00A568C1
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_2) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_2 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_169, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_169, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF8 RID: 28152
		// (get) Token: 0x0602A6DB RID: 173787 RVA: 0x00A586E4 File Offset: 0x00A568E4
		// (set) Token: 0x0602A6DC RID: 173788 RVA: 0x00A5871D File Offset: 0x00A5691D
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_170, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_170, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DF9 RID: 28153
		// (get) Token: 0x0602A6DD RID: 173789 RVA: 0x00A58740 File Offset: 0x00A56940
		// (set) Token: 0x0602A6DE RID: 173790 RVA: 0x00A58779 File Offset: 0x00A56979
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_16) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_16 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_171, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_171, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DFA RID: 28154
		// (get) Token: 0x0602A6DF RID: 173791 RVA: 0x00A5879C File Offset: 0x00A5699C
		// (set) Token: 0x0602A6E0 RID: 173792 RVA: 0x00A587D5 File Offset: 0x00A569D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_172, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_172, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DFB RID: 28155
		// (get) Token: 0x0602A6E1 RID: 173793 RVA: 0x00A587F8 File Offset: 0x00A569F8
		// (set) Token: 0x0602A6E2 RID: 173794 RVA: 0x00A58831 File Offset: 0x00A56A31
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_15) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_15 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_173, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_173, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DFC RID: 28156
		// (get) Token: 0x0602A6E3 RID: 173795 RVA: 0x00A58854 File Offset: 0x00A56A54
		// (set) Token: 0x0602A6E4 RID: 173796 RVA: 0x00A5888D File Offset: 0x00A56A8D
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_174, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_174, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DFD RID: 28157
		// (get) Token: 0x0602A6E5 RID: 173797 RVA: 0x00A588B0 File Offset: 0x00A56AB0
		// (set) Token: 0x0602A6E6 RID: 173798 RVA: 0x00A588E9 File Offset: 0x00A56AE9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_5) == null)
				{
					result = (this._AnimGraphNode_StateMachine_5 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_175, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_175, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DFE RID: 28158
		// (get) Token: 0x0602A6E7 RID: 173799 RVA: 0x00A5890C File Offset: 0x00A56B0C
		// (set) Token: 0x0602A6E8 RID: 173800 RVA: 0x00A58945 File Offset: 0x00A56B45
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_176, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_176, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006DFF RID: 28159
		// (get) Token: 0x0602A6E9 RID: 173801 RVA: 0x00A58968 File Offset: 0x00A56B68
		// (set) Token: 0x0602A6EA RID: 173802 RVA: 0x00A589A1 File Offset: 0x00A56BA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_177, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_177, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E00 RID: 28160
		// (get) Token: 0x0602A6EB RID: 173803 RVA: 0x00A589C4 File Offset: 0x00A56BC4
		// (set) Token: 0x0602A6EC RID: 173804 RVA: 0x00A589FD File Offset: 0x00A56BFD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_178, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_178, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E01 RID: 28161
		// (get) Token: 0x0602A6ED RID: 173805 RVA: 0x00A58A20 File Offset: 0x00A56C20
		// (set) Token: 0x0602A6EE RID: 173806 RVA: 0x00A58A59 File Offset: 0x00A56C59
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_179, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_179, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E02 RID: 28162
		// (get) Token: 0x0602A6EF RID: 173807 RVA: 0x00A58A7C File Offset: 0x00A56C7C
		// (set) Token: 0x0602A6F0 RID: 173808 RVA: 0x00A58AB5 File Offset: 0x00A56CB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_180, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_180, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E03 RID: 28163
		// (get) Token: 0x0602A6F1 RID: 173809 RVA: 0x00A58AD8 File Offset: 0x00A56CD8
		// (set) Token: 0x0602A6F2 RID: 173810 RVA: 0x00A58B11 File Offset: 0x00A56D11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_181, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_181, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E04 RID: 28164
		// (get) Token: 0x0602A6F3 RID: 173811 RVA: 0x00A58B34 File Offset: 0x00A56D34
		// (set) Token: 0x0602A6F4 RID: 173812 RVA: 0x00A58B6D File Offset: 0x00A56D6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_182, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_182, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E05 RID: 28165
		// (get) Token: 0x0602A6F5 RID: 173813 RVA: 0x00A58B90 File Offset: 0x00A56D90
		// (set) Token: 0x0602A6F6 RID: 173814 RVA: 0x00A58BC9 File Offset: 0x00A56DC9
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_3) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_3 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_183, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_183, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E06 RID: 28166
		// (get) Token: 0x0602A6F7 RID: 173815 RVA: 0x00A58BEC File Offset: 0x00A56DEC
		// (set) Token: 0x0602A6F8 RID: 173816 RVA: 0x00A58C25 File Offset: 0x00A56E25
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_2) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_2 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_184, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_184, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E07 RID: 28167
		// (get) Token: 0x0602A6F9 RID: 173817 RVA: 0x00A58C48 File Offset: 0x00A56E48
		// (set) Token: 0x0602A6FA RID: 173818 RVA: 0x00A58C81 File Offset: 0x00A56E81
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_185, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_185, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E08 RID: 28168
		// (get) Token: 0x0602A6FB RID: 173819 RVA: 0x00A58CA4 File Offset: 0x00A56EA4
		// (set) Token: 0x0602A6FC RID: 173820 RVA: 0x00A58CDD File Offset: 0x00A56EDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_186, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_186, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E09 RID: 28169
		// (get) Token: 0x0602A6FD RID: 173821 RVA: 0x00A58D00 File Offset: 0x00A56F00
		// (set) Token: 0x0602A6FE RID: 173822 RVA: 0x00A58D39 File Offset: 0x00A56F39
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_1) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_1 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_187, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_187, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E0A RID: 28170
		// (get) Token: 0x0602A6FF RID: 173823 RVA: 0x00A58D5C File Offset: 0x00A56F5C
		// (set) Token: 0x0602A700 RID: 173824 RVA: 0x00A58D95 File Offset: 0x00A56F95
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_188, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_188, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E0B RID: 28171
		// (get) Token: 0x0602A701 RID: 173825 RVA: 0x00A58DB8 File Offset: 0x00A56FB8
		// (set) Token: 0x0602A702 RID: 173826 RVA: 0x00A58DF1 File Offset: 0x00A56FF1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_189, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_189, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E0C RID: 28172
		// (get) Token: 0x0602A703 RID: 173827 RVA: 0x00A58E14 File Offset: 0x00A57014
		// (set) Token: 0x0602A704 RID: 173828 RVA: 0x00A58E4D File Offset: 0x00A5704D
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_190, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_190, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E0D RID: 28173
		// (get) Token: 0x0602A705 RID: 173829 RVA: 0x00A58E70 File Offset: 0x00A57070
		// (set) Token: 0x0602A706 RID: 173830 RVA: 0x00A58EA9 File Offset: 0x00A570A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_191, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_191, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E0E RID: 28174
		// (get) Token: 0x0602A707 RID: 173831 RVA: 0x00A58ECC File Offset: 0x00A570CC
		// (set) Token: 0x0602A708 RID: 173832 RVA: 0x00A58F05 File Offset: 0x00A57105
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_192, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_192, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E0F RID: 28175
		// (get) Token: 0x0602A709 RID: 173833 RVA: 0x00A58F28 File Offset: 0x00A57128
		// (set) Token: 0x0602A70A RID: 173834 RVA: 0x00A58F61 File Offset: 0x00A57161
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_193, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_193, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E10 RID: 28176
		// (get) Token: 0x0602A70B RID: 173835 RVA: 0x00A58F84 File Offset: 0x00A57184
		// (set) Token: 0x0602A70C RID: 173836 RVA: 0x00A58FBD File Offset: 0x00A571BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_194, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_194, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E11 RID: 28177
		// (get) Token: 0x0602A70D RID: 173837 RVA: 0x00A58FE0 File Offset: 0x00A571E0
		// (set) Token: 0x0602A70E RID: 173838 RVA: 0x00A59019 File Offset: 0x00A57219
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_195, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_195, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E12 RID: 28178
		// (get) Token: 0x0602A70F RID: 173839 RVA: 0x00A5903C File Offset: 0x00A5723C
		// (set) Token: 0x0602A710 RID: 173840 RVA: 0x00A59075 File Offset: 0x00A57275
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_196, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_196, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E13 RID: 28179
		// (get) Token: 0x0602A711 RID: 173841 RVA: 0x00A59098 File Offset: 0x00A57298
		// (set) Token: 0x0602A712 RID: 173842 RVA: 0x00A590D1 File Offset: 0x00A572D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_197, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_197, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E14 RID: 28180
		// (get) Token: 0x0602A713 RID: 173843 RVA: 0x00A590F4 File Offset: 0x00A572F4
		// (set) Token: 0x0602A714 RID: 173844 RVA: 0x00A5912D File Offset: 0x00A5732D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_198, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_198, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E15 RID: 28181
		// (get) Token: 0x0602A715 RID: 173845 RVA: 0x00A59150 File Offset: 0x00A57350
		// (set) Token: 0x0602A716 RID: 173846 RVA: 0x00A59189 File Offset: 0x00A57389
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_199, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_199, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E16 RID: 28182
		// (get) Token: 0x0602A717 RID: 173847 RVA: 0x00A591AC File Offset: 0x00A573AC
		// (set) Token: 0x0602A718 RID: 173848 RVA: 0x00A591E5 File Offset: 0x00A573E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_200, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_200, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E17 RID: 28183
		// (get) Token: 0x0602A719 RID: 173849 RVA: 0x00A59208 File Offset: 0x00A57408
		// (set) Token: 0x0602A71A RID: 173850 RVA: 0x00A59241 File Offset: 0x00A57441
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator_1) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator_1 = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_201, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_201, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E18 RID: 28184
		// (get) Token: 0x0602A71B RID: 173851 RVA: 0x00A59264 File Offset: 0x00A57464
		// (set) Token: 0x0602A71C RID: 173852 RVA: 0x00A5929D File Offset: 0x00A5749D
		public FAnimNode_TransitionPoseEvaluator AnimGraphNode_TransitionPoseEvaluator
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionPoseEvaluator result;
				if ((result = this._AnimGraphNode_TransitionPoseEvaluator) == null)
				{
					result = (this._AnimGraphNode_TransitionPoseEvaluator = new FAnimNode_TransitionPoseEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_202, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionPoseEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_202, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E19 RID: 28185
		// (get) Token: 0x0602A71D RID: 173853 RVA: 0x00A592C0 File Offset: 0x00A574C0
		// (set) Token: 0x0602A71E RID: 173854 RVA: 0x00A592F9 File Offset: 0x00A574F9
		public FAnimNode_StateResult AnimGraphNode_CustomTransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_CustomTransitionResult) == null)
				{
					result = (this._AnimGraphNode_CustomTransitionResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_203, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_203, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E1A RID: 28186
		// (get) Token: 0x0602A71F RID: 173855 RVA: 0x00A5931C File Offset: 0x00A5751C
		// (set) Token: 0x0602A720 RID: 173856 RVA: 0x00A59355 File Offset: 0x00A57555
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_204, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_204, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E1B RID: 28187
		// (get) Token: 0x0602A721 RID: 173857 RVA: 0x00A59378 File Offset: 0x00A57578
		// (set) Token: 0x0602A722 RID: 173858 RVA: 0x00A593B1 File Offset: 0x00A575B1
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_205, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_205, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E1C RID: 28188
		// (get) Token: 0x0602A723 RID: 173859 RVA: 0x00A593D4 File Offset: 0x00A575D4
		// (set) Token: 0x0602A724 RID: 173860 RVA: 0x00A5940D File Offset: 0x00A5760D
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_206, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_206, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E1D RID: 28189
		// (get) Token: 0x0602A725 RID: 173861 RVA: 0x00A59430 File Offset: 0x00A57630
		// (set) Token: 0x0602A726 RID: 173862 RVA: 0x00A59469 File Offset: 0x00A57669
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_207, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_207, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E1E RID: 28190
		// (get) Token: 0x0602A727 RID: 173863 RVA: 0x00A5948C File Offset: 0x00A5768C
		// (set) Token: 0x0602A728 RID: 173864 RVA: 0x00A594C5 File Offset: 0x00A576C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_208, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_208, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E1F RID: 28191
		// (get) Token: 0x0602A729 RID: 173865 RVA: 0x00A594E8 File Offset: 0x00A576E8
		// (set) Token: 0x0602A72A RID: 173866 RVA: 0x00A59521 File Offset: 0x00A57721
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_209, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_209, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E20 RID: 28192
		// (get) Token: 0x0602A72B RID: 173867 RVA: 0x00A59544 File Offset: 0x00A57744
		// (set) Token: 0x0602A72C RID: 173868 RVA: 0x00A5957D File Offset: 0x00A5777D
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_210, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_210, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E21 RID: 28193
		// (get) Token: 0x0602A72D RID: 173869 RVA: 0x00A595A0 File Offset: 0x00A577A0
		// (set) Token: 0x0602A72E RID: 173870 RVA: 0x00A595D9 File Offset: 0x00A577D9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_211, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_211, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E22 RID: 28194
		// (get) Token: 0x0602A72F RID: 173871 RVA: 0x00A595FC File Offset: 0x00A577FC
		// (set) Token: 0x0602A730 RID: 173872 RVA: 0x00A59635 File Offset: 0x00A57835
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_212, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_212, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E23 RID: 28195
		// (get) Token: 0x0602A731 RID: 173873 RVA: 0x00A59658 File Offset: 0x00A57858
		// (set) Token: 0x0602A732 RID: 173874 RVA: 0x00A59691 File Offset: 0x00A57891
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_213, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_213, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E24 RID: 28196
		// (get) Token: 0x0602A733 RID: 173875 RVA: 0x00A596B4 File Offset: 0x00A578B4
		// (set) Token: 0x0602A734 RID: 173876 RVA: 0x00A596ED File Offset: 0x00A578ED
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_214, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_214, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E25 RID: 28197
		// (get) Token: 0x0602A735 RID: 173877 RVA: 0x00A59710 File Offset: 0x00A57910
		// (set) Token: 0x0602A736 RID: 173878 RVA: 0x00A59749 File Offset: 0x00A57949
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_215, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_215, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E26 RID: 28198
		// (get) Token: 0x0602A737 RID: 173879 RVA: 0x00A5976C File Offset: 0x00A5796C
		// (set) Token: 0x0602A738 RID: 173880 RVA: 0x00A597A5 File Offset: 0x00A579A5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_216, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_216, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E27 RID: 28199
		// (get) Token: 0x0602A739 RID: 173881 RVA: 0x00A597C8 File Offset: 0x00A579C8
		// (set) Token: 0x0602A73A RID: 173882 RVA: 0x00A59801 File Offset: 0x00A57A01
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_217, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_217, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E28 RID: 28200
		// (get) Token: 0x0602A73B RID: 173883 RVA: 0x00A59824 File Offset: 0x00A57A24
		// (set) Token: 0x0602A73C RID: 173884 RVA: 0x00A5985D File Offset: 0x00A57A5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_218, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_218, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E29 RID: 28201
		// (get) Token: 0x0602A73D RID: 173885 RVA: 0x00A59880 File Offset: 0x00A57A80
		// (set) Token: 0x0602A73E RID: 173886 RVA: 0x00A598B9 File Offset: 0x00A57AB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_219, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_219, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E2A RID: 28202
		// (get) Token: 0x0602A73F RID: 173887 RVA: 0x00A598DC File Offset: 0x00A57ADC
		// (set) Token: 0x0602A740 RID: 173888 RVA: 0x00A59915 File Offset: 0x00A57B15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_220, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_220, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E2B RID: 28203
		// (get) Token: 0x0602A741 RID: 173889 RVA: 0x00A59938 File Offset: 0x00A57B38
		// (set) Token: 0x0602A742 RID: 173890 RVA: 0x00A59971 File Offset: 0x00A57B71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_221, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_221, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E2C RID: 28204
		// (get) Token: 0x0602A743 RID: 173891 RVA: 0x00A59994 File Offset: 0x00A57B94
		// (set) Token: 0x0602A744 RID: 173892 RVA: 0x00A599CD File Offset: 0x00A57BCD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_222, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_222, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E2D RID: 28205
		// (get) Token: 0x0602A745 RID: 173893 RVA: 0x00A599F0 File Offset: 0x00A57BF0
		// (set) Token: 0x0602A746 RID: 173894 RVA: 0x00A59A29 File Offset: 0x00A57C29
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_223, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_223, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E2E RID: 28206
		// (get) Token: 0x0602A747 RID: 173895 RVA: 0x00A59A4C File Offset: 0x00A57C4C
		// (set) Token: 0x0602A748 RID: 173896 RVA: 0x00A59A85 File Offset: 0x00A57C85
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_224, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_224, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E2F RID: 28207
		// (get) Token: 0x0602A749 RID: 173897 RVA: 0x00A59AA8 File Offset: 0x00A57CA8
		// (set) Token: 0x0602A74A RID: 173898 RVA: 0x00A59AE1 File Offset: 0x00A57CE1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_225, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_225, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E30 RID: 28208
		// (get) Token: 0x0602A74B RID: 173899 RVA: 0x00A59B04 File Offset: 0x00A57D04
		// (set) Token: 0x0602A74C RID: 173900 RVA: 0x00A59B3D File Offset: 0x00A57D3D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_226, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_226, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E31 RID: 28209
		// (get) Token: 0x0602A74D RID: 173901 RVA: 0x00A59B60 File Offset: 0x00A57D60
		// (set) Token: 0x0602A74E RID: 173902 RVA: 0x00A59B99 File Offset: 0x00A57D99
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_227, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_227, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E32 RID: 28210
		// (get) Token: 0x0602A74F RID: 173903 RVA: 0x00A59BBC File Offset: 0x00A57DBC
		// (set) Token: 0x0602A750 RID: 173904 RVA: 0x00A59BF5 File Offset: 0x00A57DF5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_228, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_228, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E33 RID: 28211
		// (get) Token: 0x0602A751 RID: 173905 RVA: 0x00A59C18 File Offset: 0x00A57E18
		// (set) Token: 0x0602A752 RID: 173906 RVA: 0x00A59C51 File Offset: 0x00A57E51
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_229, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_229, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E34 RID: 28212
		// (get) Token: 0x0602A753 RID: 173907 RVA: 0x00A59C74 File Offset: 0x00A57E74
		// (set) Token: 0x0602A754 RID: 173908 RVA: 0x00A59CAD File Offset: 0x00A57EAD
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_230, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_230, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E35 RID: 28213
		// (get) Token: 0x0602A755 RID: 173909 RVA: 0x00A59CD0 File Offset: 0x00A57ED0
		// (set) Token: 0x0602A756 RID: 173910 RVA: 0x00A59D09 File Offset: 0x00A57F09
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_231, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_231, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E36 RID: 28214
		// (get) Token: 0x0602A757 RID: 173911 RVA: 0x00A59D2C File Offset: 0x00A57F2C
		// (set) Token: 0x0602A758 RID: 173912 RVA: 0x00A59D65 File Offset: 0x00A57F65
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_232, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_232, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E37 RID: 28215
		// (get) Token: 0x0602A759 RID: 173913 RVA: 0x00A59D88 File Offset: 0x00A57F88
		// (set) Token: 0x0602A75A RID: 173914 RVA: 0x00A59DC1 File Offset: 0x00A57FC1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_233, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_233, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E38 RID: 28216
		// (get) Token: 0x0602A75B RID: 173915 RVA: 0x00A59DE4 File Offset: 0x00A57FE4
		// (set) Token: 0x0602A75C RID: 173916 RVA: 0x00A59E1D File Offset: 0x00A5801D
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_234, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_234, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E39 RID: 28217
		// (get) Token: 0x0602A75D RID: 173917 RVA: 0x00A59E40 File Offset: 0x00A58040
		// (set) Token: 0x0602A75E RID: 173918 RVA: 0x00A59E79 File Offset: 0x00A58079
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_235, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_235, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E3A RID: 28218
		// (get) Token: 0x0602A75F RID: 173919 RVA: 0x00A59E9C File Offset: 0x00A5809C
		// (set) Token: 0x0602A760 RID: 173920 RVA: 0x00A59ED5 File Offset: 0x00A580D5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_236, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_236, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E3B RID: 28219
		// (get) Token: 0x0602A761 RID: 173921 RVA: 0x00A59EF8 File Offset: 0x00A580F8
		// (set) Token: 0x0602A762 RID: 173922 RVA: 0x00A59F31 File Offset: 0x00A58131
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_237, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_237, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E3C RID: 28220
		// (get) Token: 0x0602A763 RID: 173923 RVA: 0x00A59F54 File Offset: 0x00A58154
		// (set) Token: 0x0602A764 RID: 173924 RVA: 0x00A59F8D File Offset: 0x00A5818D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_238, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_238, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E3D RID: 28221
		// (get) Token: 0x0602A765 RID: 173925 RVA: 0x00A59FB0 File Offset: 0x00A581B0
		// (set) Token: 0x0602A766 RID: 173926 RVA: 0x00A59FE9 File Offset: 0x00A581E9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_239, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_239, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E3E RID: 28222
		// (get) Token: 0x0602A767 RID: 173927 RVA: 0x00A5A00C File Offset: 0x00A5820C
		// (set) Token: 0x0602A768 RID: 173928 RVA: 0x00A5A045 File Offset: 0x00A58245
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_240, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_240, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E3F RID: 28223
		// (get) Token: 0x0602A769 RID: 173929 RVA: 0x00A5A068 File Offset: 0x00A58268
		// (set) Token: 0x0602A76A RID: 173930 RVA: 0x00A5A0A1 File Offset: 0x00A582A1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_241, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_241, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E40 RID: 28224
		// (get) Token: 0x0602A76B RID: 173931 RVA: 0x00A5A0C4 File Offset: 0x00A582C4
		// (set) Token: 0x0602A76C RID: 173932 RVA: 0x00A5A0FD File Offset: 0x00A582FD
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_242, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_242, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E41 RID: 28225
		// (get) Token: 0x0602A76D RID: 173933 RVA: 0x00A5A120 File Offset: 0x00A58320
		// (set) Token: 0x0602A76E RID: 173934 RVA: 0x00A5A159 File Offset: 0x00A58359
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_243, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_243, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E42 RID: 28226
		// (get) Token: 0x0602A76F RID: 173935 RVA: 0x00A5A17C File Offset: 0x00A5837C
		// (set) Token: 0x0602A770 RID: 173936 RVA: 0x00A5A1B5 File Offset: 0x00A583B5
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_244, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_244, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E43 RID: 28227
		// (get) Token: 0x0602A771 RID: 173937 RVA: 0x00A5A1D8 File Offset: 0x00A583D8
		// (set) Token: 0x0602A772 RID: 173938 RVA: 0x00A5A211 File Offset: 0x00A58411
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_245, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_245, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E44 RID: 28228
		// (get) Token: 0x0602A773 RID: 173939 RVA: 0x00A5A234 File Offset: 0x00A58434
		// (set) Token: 0x0602A774 RID: 173940 RVA: 0x00A5A26D File Offset: 0x00A5846D
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_246, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_246, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E45 RID: 28229
		// (get) Token: 0x0602A775 RID: 173941 RVA: 0x00A5A290 File Offset: 0x00A58490
		// (set) Token: 0x0602A776 RID: 173942 RVA: 0x00A5A2C9 File Offset: 0x00A584C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_247, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_247, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E46 RID: 28230
		// (get) Token: 0x0602A777 RID: 173943 RVA: 0x00A5A2EC File Offset: 0x00A584EC
		// (set) Token: 0x0602A778 RID: 173944 RVA: 0x00A5A325 File Offset: 0x00A58525
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_248, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_248, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E47 RID: 28231
		// (get) Token: 0x0602A779 RID: 173945 RVA: 0x00A5A348 File Offset: 0x00A58548
		// (set) Token: 0x0602A77A RID: 173946 RVA: 0x00A5A381 File Offset: 0x00A58581
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_249, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_249, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E48 RID: 28232
		// (get) Token: 0x0602A77B RID: 173947 RVA: 0x00A5A3A4 File Offset: 0x00A585A4
		// (set) Token: 0x0602A77C RID: 173948 RVA: 0x00A5A3DD File Offset: 0x00A585DD
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_250, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_250, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E49 RID: 28233
		// (get) Token: 0x0602A77D RID: 173949 RVA: 0x00A5A400 File Offset: 0x00A58600
		// (set) Token: 0x0602A77E RID: 173950 RVA: 0x00A5A439 File Offset: 0x00A58639
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_251, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_251, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E4A RID: 28234
		// (get) Token: 0x0602A77F RID: 173951 RVA: 0x00A5A45C File Offset: 0x00A5865C
		// (set) Token: 0x0602A780 RID: 173952 RVA: 0x00A5A495 File Offset: 0x00A58695
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_252, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_252, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E4B RID: 28235
		// (get) Token: 0x0602A781 RID: 173953 RVA: 0x00A5A4B8 File Offset: 0x00A586B8
		// (set) Token: 0x0602A782 RID: 173954 RVA: 0x00A5A4F1 File Offset: 0x00A586F1
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves) == null)
				{
					result = (this._AnimGraphNode_CombineCurves = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_253, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_253, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E4C RID: 28236
		// (get) Token: 0x0602A783 RID: 173955 RVA: 0x00A5A514 File Offset: 0x00A58714
		// (set) Token: 0x0602A784 RID: 173956 RVA: 0x00A5A54D File Offset: 0x00A5874D
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_254, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_254, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E4D RID: 28237
		// (get) Token: 0x0602A785 RID: 173957 RVA: 0x00A5A570 File Offset: 0x00A58770
		// (set) Token: 0x0602A786 RID: 173958 RVA: 0x00A5A5A9 File Offset: 0x00A587A9
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_255, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_255, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E4E RID: 28238
		// (get) Token: 0x0602A787 RID: 173959 RVA: 0x00A5A5CC File Offset: 0x00A587CC
		// (set) Token: 0x0602A788 RID: 173960 RVA: 0x00A5A605 File Offset: 0x00A58805
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_256, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_256, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E4F RID: 28239
		// (get) Token: 0x0602A789 RID: 173961 RVA: 0x00A5A626 File Offset: 0x00A58826
		// (set) Token: 0x0602A78A RID: 173962 RVA: 0x00A5A63A File Offset: 0x00A5883A
		[Nullable(0)]
		public unsafe TEnumAsByte<EPerformanceRoleState> StateInternal
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_257);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_257) = value;
			}
		}

		// Token: 0x17006E50 RID: 28240
		// (get) Token: 0x0602A78B RID: 173963 RVA: 0x00A5A64F File Offset: 0x00A5884F
		// (set) Token: 0x0602A78C RID: 173964 RVA: 0x00A5A65F File Offset: 0x00A5885F
		public unsafe bool reLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_258) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_258) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E51 RID: 28241
		// (get) Token: 0x0602A78D RID: 173965 RVA: 0x00A5A670 File Offset: 0x00A58870
		// (set) Token: 0x0602A78E RID: 173966 RVA: 0x00A5A680 File Offset: 0x00A58880
		public unsafe bool bForceChange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_259) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_259) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E52 RID: 28242
		// (get) Token: 0x0602A78F RID: 173967 RVA: 0x00A5A691 File Offset: 0x00A58891
		// (set) Token: 0x0602A790 RID: 173968 RVA: 0x00A5A6A1 File Offset: 0x00A588A1
		public unsafe float Delta_Time_X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_260);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_260) = value;
			}
		}

		// Token: 0x17006E53 RID: 28243
		// (get) Token: 0x0602A791 RID: 173969 RVA: 0x00A5A6B2 File Offset: 0x00A588B2
		// (set) Token: 0x0602A792 RID: 173970 RVA: 0x00A5A6C2 File Offset: 0x00A588C2
		public unsafe float HeadAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_261);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_261) = value;
			}
		}

		// Token: 0x17006E54 RID: 28244
		// (get) Token: 0x0602A793 RID: 173971 RVA: 0x00A5A6D4 File Offset: 0x00A588D4
		// (set) Token: 0x0602A794 RID: 173972 RVA: 0x00A5A70D File Offset: 0x00A5890D
		public OnEffectBegin OnEffectBegin
		{
			get
			{
				base.FastCheckIsValid();
				OnEffectBegin result;
				if ((result = this._OnEffectBegin) == null)
				{
					result = (this._OnEffectBegin = new OnEffectBegin(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_262, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_262, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006E55 RID: 28245
		// (get) Token: 0x0602A795 RID: 173973 RVA: 0x00A5A730 File Offset: 0x00A58930
		// (set) Token: 0x0602A796 RID: 173974 RVA: 0x00A5A769 File Offset: 0x00A58969
		public OnEffectEnd OnEffectEnd
		{
			get
			{
				base.FastCheckIsValid();
				OnEffectEnd result;
				if ((result = this._OnEffectEnd) == null)
				{
					result = (this._OnEffectEnd = new OnEffectEnd(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_263, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_263, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17006E56 RID: 28246
		// (get) Token: 0x0602A797 RID: 173975 RVA: 0x00A5A78A File Offset: 0x00A5898A
		// (set) Token: 0x0602A798 RID: 173976 RVA: 0x00A5A79A File Offset: 0x00A5899A
		public unsafe float PerformDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_264);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_264) = value;
			}
		}

		// Token: 0x17006E57 RID: 28247
		// (get) Token: 0x0602A799 RID: 173977 RVA: 0x00A5A7AB File Offset: 0x00A589AB
		// (set) Token: 0x0602A79A RID: 173978 RVA: 0x00A5A7BB File Offset: 0x00A589BB
		public unsafe float CurPerformTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_265);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_265) = value;
			}
		}

		// Token: 0x17006E58 RID: 28248
		// (get) Token: 0x0602A79B RID: 173979 RVA: 0x00A5A7CC File Offset: 0x00A589CC
		// (set) Token: 0x0602A79C RID: 173980 RVA: 0x00A5A7DC File Offset: 0x00A589DC
		public unsafe bool bForceChange_Perform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_266) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_266) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E59 RID: 28249
		// (get) Token: 0x0602A79D RID: 173981 RVA: 0x00A5A7ED File Offset: 0x00A589ED
		// (set) Token: 0x0602A79E RID: 173982 RVA: 0x00A5A801 File Offset: 0x00A58A01
		public unsafe FVector2D CacheViewportSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_267);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_267) = value;
			}
		}

		// Token: 0x17006E5A RID: 28250
		// (get) Token: 0x0602A79F RID: 173983 RVA: 0x00A5A816 File Offset: 0x00A58A16
		// (set) Token: 0x0602A7A0 RID: 173984 RVA: 0x00A5A82A File Offset: 0x00A58A2A
		public unsafe FVector LookAtWorld_Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_268);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_268) = value;
			}
		}

		// Token: 0x17006E5B RID: 28251
		// (get) Token: 0x0602A7A1 RID: 173985 RVA: 0x00A5A83F File Offset: 0x00A58A3F
		// (set) Token: 0x0602A7A2 RID: 173986 RVA: 0x00A5A853 File Offset: 0x00A58A53
		[Nullable(2)]
		public unsafe USkeletalMeshComponent Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PerformanceRole_C.__PropertyOffset_269);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PerformanceRole_C.__PropertyOffset_269, value);
			}
		}

		// Token: 0x17006E5C RID: 28252
		// (get) Token: 0x0602A7A3 RID: 173987 RVA: 0x00A5A868 File Offset: 0x00A58A68
		// (set) Token: 0x0602A7A4 RID: 173988 RVA: 0x00A5A87C File Offset: 0x00A58A7C
		public unsafe FVector LookAtDirection
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_270);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_270) = value;
			}
		}

		// Token: 0x17006E5D RID: 28253
		// (get) Token: 0x0602A7A5 RID: 173989 RVA: 0x00A5A891 File Offset: 0x00A58A91
		// (set) Token: 0x0602A7A6 RID: 173990 RVA: 0x00A5A8A1 File Offset: 0x00A58AA1
		public unsafe bool IsCreateRoleState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_271) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_271) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E5E RID: 28254
		// (get) Token: 0x0602A7A7 RID: 173991 RVA: 0x00A5A8B2 File Offset: 0x00A58AB2
		// (set) Token: 0x0602A7A8 RID: 173992 RVA: 0x00A5A8C6 File Offset: 0x00A58AC6
		public unsafe FVector CreateRoleStartLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_272);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_272) = value;
			}
		}

		// Token: 0x17006E5F RID: 28255
		// (get) Token: 0x0602A7A9 RID: 173993 RVA: 0x00A5A8DB File Offset: 0x00A58ADB
		// (set) Token: 0x0602A7AA RID: 173994 RVA: 0x00A5A8EF File Offset: 0x00A58AEF
		public unsafe FVector CreateRoleEndLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_273);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_273) = value;
			}
		}

		// Token: 0x17006E60 RID: 28256
		// (get) Token: 0x0602A7AB RID: 173995 RVA: 0x00A5A904 File Offset: 0x00A58B04
		// (set) Token: 0x0602A7AC RID: 173996 RVA: 0x00A5A914 File Offset: 0x00A58B14
		public unsafe float CreateRoleMoveAllTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_274);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_274) = value;
			}
		}

		// Token: 0x17006E61 RID: 28257
		// (get) Token: 0x0602A7AD RID: 173997 RVA: 0x00A5A925 File Offset: 0x00A58B25
		// (set) Token: 0x0602A7AE RID: 173998 RVA: 0x00A5A939 File Offset: 0x00A58B39
		[Nullable(2)]
		public unsafe TsUiSceneRoleActor Actor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsUiSceneRoleActor>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PerformanceRole_C.__PropertyOffset_275);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_PerformanceRole_C.__PropertyOffset_275, value);
			}
		}

		// Token: 0x17006E62 RID: 28258
		// (get) Token: 0x0602A7AF RID: 173999 RVA: 0x00A5A94E File Offset: 0x00A58B4E
		// (set) Token: 0x0602A7B0 RID: 174000 RVA: 0x00A5A95E File Offset: 0x00A58B5E
		public unsafe float CreateRoleMoveCurrentTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_276);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_276) = value;
			}
		}

		// Token: 0x17006E63 RID: 28259
		// (get) Token: 0x0602A7B1 RID: 174001 RVA: 0x00A5A96F File Offset: 0x00A58B6F
		// (set) Token: 0x0602A7B2 RID: 174002 RVA: 0x00A5A983 File Offset: 0x00A58B83
		public unsafe FRotator CreateRoleStartRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_277);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_277) = value;
			}
		}

		// Token: 0x17006E64 RID: 28260
		// (get) Token: 0x0602A7B3 RID: 174003 RVA: 0x00A5A998 File Offset: 0x00A58B98
		// (set) Token: 0x0602A7B4 RID: 174004 RVA: 0x00A5A9AC File Offset: 0x00A58BAC
		public unsafe FVector CreateRoleEndLocationOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_278);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_278) = value;
			}
		}

		// Token: 0x17006E65 RID: 28261
		// (get) Token: 0x0602A7B5 RID: 174005 RVA: 0x00A5A9C1 File Offset: 0x00A58BC1
		// (set) Token: 0x0602A7B6 RID: 174006 RVA: 0x00A5A9D5 File Offset: 0x00A58BD5
		public unsafe FRotator CreateRoleEndRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_279);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_279) = value;
			}
		}

		// Token: 0x17006E66 RID: 28262
		// (get) Token: 0x0602A7B7 RID: 174007 RVA: 0x00A5A9EA File Offset: 0x00A58BEA
		// (set) Token: 0x0602A7B8 RID: 174008 RVA: 0x00A5A9FE File Offset: 0x00A58BFE
		public unsafe FRotator CreateRoleEndRotationOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_280);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_280) = value;
			}
		}

		// Token: 0x17006E67 RID: 28263
		// (get) Token: 0x0602A7B9 RID: 174009 RVA: 0x00A5AA13 File Offset: 0x00A58C13
		// (set) Token: 0x0602A7BA RID: 174010 RVA: 0x00A5AA23 File Offset: 0x00A58C23
		public unsafe float CreateRoleMovePlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_281);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_281) = value;
			}
		}

		// Token: 0x17006E68 RID: 28264
		// (get) Token: 0x0602A7BB RID: 174011 RVA: 0x00A5AA34 File Offset: 0x00A58C34
		// (set) Token: 0x0602A7BC RID: 174012 RVA: 0x00A5AA44 File Offset: 0x00A58C44
		public unsafe bool HasInitCreateRoleInfo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_282) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_282) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E69 RID: 28265
		// (get) Token: 0x0602A7BD RID: 174013 RVA: 0x00A5AA55 File Offset: 0x00A58C55
		// (set) Token: 0x0602A7BE RID: 174014 RVA: 0x00A5AA65 File Offset: 0x00A58C65
		public unsafe bool isLooping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_283) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_283) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E6A RID: 28266
		// (get) Token: 0x0602A7BF RID: 174015 RVA: 0x00A5AA76 File Offset: 0x00A58C76
		// (set) Token: 0x0602A7C0 RID: 174016 RVA: 0x00A5AA86 File Offset: 0x00A58C86
		public unsafe bool bInitCreateRoleInfo
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_284) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_284) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E6B RID: 28267
		// (get) Token: 0x0602A7C1 RID: 174017 RVA: 0x00A5AA97 File Offset: 0x00A58C97
		// (set) Token: 0x0602A7C2 RID: 174018 RVA: 0x00A5AAA7 File Offset: 0x00A58CA7
		public unsafe bool InSkillRotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_285) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_285) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E6C RID: 28268
		// (get) Token: 0x0602A7C3 RID: 174019 RVA: 0x00A5AAB8 File Offset: 0x00A58CB8
		// (set) Token: 0x0602A7C4 RID: 174020 RVA: 0x00A5AAC8 File Offset: 0x00A58CC8
		public unsafe bool InSkillEndRotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_286) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_286) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E6D RID: 28269
		// (get) Token: 0x0602A7C5 RID: 174021 RVA: 0x00A5AAD9 File Offset: 0x00A58CD9
		// (set) Token: 0x0602A7C6 RID: 174022 RVA: 0x00A5AAE9 File Offset: 0x00A58CE9
		public unsafe bool TempRotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_287) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_287) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E6E RID: 28270
		// (get) Token: 0x0602A7C7 RID: 174023 RVA: 0x00A5AAFC File Offset: 0x00A58CFC
		// (set) Token: 0x0602A7C8 RID: 174024 RVA: 0x00A5AB35 File Offset: 0x00A58D35
		public SPerformanceRoleInfo PerformanceRoleInfo
		{
			get
			{
				base.FastCheckIsValid();
				SPerformanceRoleInfo result;
				if ((result = this._PerformanceRoleInfo) == null)
				{
					result = (this._PerformanceRoleInfo = new SPerformanceRoleInfo(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_288, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPerformanceRoleInfo.StaticStruct(), base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_288, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E6F RID: 28271
		// (get) Token: 0x0602A7C9 RID: 174025 RVA: 0x00A5AB56 File Offset: 0x00A58D56
		// (set) Token: 0x0602A7CA RID: 174026 RVA: 0x00A5AB66 File Offset: 0x00A58D66
		public unsafe float BlinkAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_289);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_289) = value;
			}
		}

		// Token: 0x17006E70 RID: 28272
		// (get) Token: 0x0602A7CB RID: 174027 RVA: 0x00A5AB77 File Offset: 0x00A58D77
		// (set) Token: 0x0602A7CC RID: 174028 RVA: 0x00A5AB87 File Offset: 0x00A58D87
		public unsafe bool InBlinking
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_290) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_290) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E71 RID: 28273
		// (get) Token: 0x0602A7CD RID: 174029 RVA: 0x00A5AB98 File Offset: 0x00A58D98
		// (set) Token: 0x0602A7CE RID: 174030 RVA: 0x00A5ABA8 File Offset: 0x00A58DA8
		public unsafe float BlinkEndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_291);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_291) = value;
			}
		}

		// Token: 0x17006E72 RID: 28274
		// (get) Token: 0x0602A7CF RID: 174031 RVA: 0x00A5ABB9 File Offset: 0x00A58DB9
		// (set) Token: 0x0602A7D0 RID: 174032 RVA: 0x00A5ABC9 File Offset: 0x00A58DC9
		public unsafe float 眨眼动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_292);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_292) = value;
			}
		}

		// Token: 0x17006E73 RID: 28275
		// (get) Token: 0x0602A7D1 RID: 174033 RVA: 0x00A5ABDA File Offset: 0x00A58DDA
		// (set) Token: 0x0602A7D2 RID: 174034 RVA: 0x00A5ABEA File Offset: 0x00A58DEA
		public unsafe float 此轮眨眼动画总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_293);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_293) = value;
			}
		}

		// Token: 0x17006E74 RID: 28276
		// (get) Token: 0x0602A7D3 RID: 174035 RVA: 0x00A5ABFC File Offset: 0x00A58DFC
		// (set) Token: 0x0602A7D4 RID: 174036 RVA: 0x00A5AC35 File Offset: 0x00A58E35
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EPerformanceRoleState>> SameStateArray01
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EPerformanceRoleState>> result;
				if ((result = this._SameStateArray01) == null)
				{
					result = (this._SameStateArray01 = new TArray<TEnumAsByte<EPerformanceRoleState>>(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_294, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.SameStateArray01.CopyAssign(value);
			}
		}

		// Token: 0x17006E75 RID: 28277
		// (get) Token: 0x0602A7D5 RID: 174037 RVA: 0x00A5AC43 File Offset: 0x00A58E43
		// (set) Token: 0x0602A7D6 RID: 174038 RVA: 0x00A5AC53 File Offset: 0x00A58E53
		public unsafe bool False
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_295) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_295) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E76 RID: 28278
		// (get) Token: 0x0602A7D7 RID: 174039 RVA: 0x00A5AC64 File Offset: 0x00A58E64
		// (set) Token: 0x0602A7D8 RID: 174040 RVA: 0x00A5AC74 File Offset: 0x00A58E74
		public unsafe bool DirectEnterLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_296) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_296) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E77 RID: 28279
		// (get) Token: 0x0602A7D9 RID: 174041 RVA: 0x00A5AC85 File Offset: 0x00A58E85
		// (set) Token: 0x0602A7DA RID: 174042 RVA: 0x00A5AC99 File Offset: 0x00A58E99
		[Nullable(0)]
		public unsafe TEnumAsByte<EPerformanceRoleState> CurrentState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_297);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_297) = value;
			}
		}

		// Token: 0x17006E78 RID: 28280
		// (get) Token: 0x0602A7DB RID: 174043 RVA: 0x00A5ACAE File Offset: 0x00A58EAE
		// (set) Token: 0x0602A7DC RID: 174044 RVA: 0x00A5ACBE File Offset: 0x00A58EBE
		public unsafe bool reLoopFromLoopToStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_298) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_298) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006E79 RID: 28281
		// (get) Token: 0x0602A7DD RID: 174045 RVA: 0x00A5ACCF File Offset: 0x00A58ECF
		// (set) Token: 0x0602A7DE RID: 174046 RVA: 0x00A5ACDF File Offset: 0x00A58EDF
		public unsafe bool bForceEnterLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_299) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_PerformanceRole_C.__PropertyOffset_299) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602A7DF RID: 174047 RVA: 0x00A5ACF0 File Offset: 0x00A58EF0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PostProcessPose(FPoseLink InPose, ref FPoseLink PostProcessPose)
		{
			ABP_PerformanceRole_C.__PostProcessPose_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__PostProcessPose_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_PerformanceRole_C.__PostProcessPose_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__PostProcessPose_NativeFunctionPtr, (void*)ptr, 1);
			if (InPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->InPose, InPose.NativePtr, 1, false);
			}
			if (PostProcessPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->PostProcessPose, PostProcessPose.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__PostProcessPose_NativeFunctionPtr, (void*)ptr);
			if (PostProcessPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), PostProcessPose.NativePtr, &ptr->PostProcessPose, 1, false);
			}
		}

		// Token: 0x0602A7E0 RID: 174048 RVA: 0x00A5AD9C File Offset: 0x00A58F9C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BasePose(ref FPoseLink BasePose)
		{
			ABP_PerformanceRole_C.__BasePose_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__BasePose_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_PerformanceRole_C.__BasePose_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__BasePose_NativeFunctionPtr, (void*)ptr, 1);
			if (BasePose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->BasePose, BasePose.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__BasePose_NativeFunctionPtr, (void*)ptr);
			if (BasePose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), BasePose.NativePtr, &ptr->BasePose, 1, false);
			}
		}

		// Token: 0x0602A7E1 RID: 174049 RVA: 0x00A5AE24 File Offset: 0x00A59024
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_PerformanceRole_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_PerformanceRole_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602A7E2 RID: 174050 RVA: 0x00A5AEAB File Offset: 0x00A590AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TryForceEnterLoop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__TryForceEnterLoop_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7E3 RID: 174051 RVA: 0x00A5AEC0 File Offset: 0x00A590C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Set_Current_State(EPerformanceRoleState state)
		{
			ABP_PerformanceRole_C.__Set_Current_State_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__Set_Current_State_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ABP_PerformanceRole_C.__Set_Current_State_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__Set_Current_State_NativeFunctionPtr, (void*)ptr, 1);
			ptr->state = state;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__Set_Current_State_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A7E4 RID: 174052 RVA: 0x00A5AF0C File Offset: 0x00A5910C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool Is_Same_State(EPerformanceRoleState NewState, in EPerformanceRoleState StateInternal)
		{
			ABP_PerformanceRole_C.__Is_Same_State_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__Is_Same_State_FunctionParams[(UIntPtr)21] + 15L / (long)sizeof(ABP_PerformanceRole_C.__Is_Same_State_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__Is_Same_State_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewState = NewState;
			ptr->StateInternal = (EPerformanceRoleState)StateInternal;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__Is_Same_State_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602A7E5 RID: 174053 RVA: 0x00A5AF6A File Offset: 0x00A5916A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateBlinkInfo()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__UpdateBlinkInfo_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7E6 RID: 174054 RVA: 0x00A5AF7E File Offset: 0x00A5917E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SkillRotate()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__SkillRotate_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7E7 RID: 174055 RVA: 0x00A5AF94 File Offset: 0x00A59194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetIsLooping(ref bool isLooping)
		{
			ABP_PerformanceRole_C.__GetIsLooping_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__GetIsLooping_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ABP_PerformanceRole_C.__GetIsLooping_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__GetIsLooping_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isLooping = isLooping;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__GetIsLooping_NativeFunctionPtr, (void*)ptr);
			isLooping = ptr->isLooping;
		}

		// Token: 0x0602A7E8 RID: 174056 RVA: 0x00A5AFE3 File Offset: 0x00A591E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearCreateRoleState()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__ClearCreateRoleState_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7E9 RID: 174057 RVA: 0x00A5AFF7 File Offset: 0x00A591F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCreateRoleLocation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__UpdateCreateRoleLocation_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7EA RID: 174058 RVA: 0x00A5B00C File Offset: 0x00A5920C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DebugLine(FVector LineStart, FVector LineEnd, FLinearColor LineColor)
		{
			ABP_PerformanceRole_C.__DebugLine_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__DebugLine_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(ABP_PerformanceRole_C.__DebugLine_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__DebugLine_NativeFunctionPtr, (void*)ptr, 1);
			ptr->LineStart = LineStart;
			ptr->LineEnd = LineEnd;
			ptr->LineColor = LineColor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__DebugLine_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A7EB RID: 174059 RVA: 0x00A5B060 File Offset: 0x00A59260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateLookAtRotation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__UpdateLookAtRotation_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7EC RID: 174060 RVA: 0x00A5B074 File Offset: 0x00A59274
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePerfromTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__UpdatePerfromTime_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7ED RID: 174061 RVA: 0x00A5B088 File Offset: 0x00A59288
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPerformDelay(float PerformTime)
		{
			ABP_PerformanceRole_C.__SetPerformDelay_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__SetPerformDelay_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PerformanceRole_C.__SetPerformDelay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__SetPerformDelay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PerformTime = PerformTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__SetPerformDelay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A7EE RID: 174062 RVA: 0x00A5B0D0 File Offset: 0x00A592D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SyncAnimInstance(ABP_PerformanceRole_C SourceAnimInstance)
		{
			ABP_PerformanceRole_C.__SyncAnimInstance_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__SyncAnimInstance_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABP_PerformanceRole_C.__SyncAnimInstance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__SyncAnimInstance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SourceAnimInstance = ((SourceAnimInstance != null) ? SourceAnimInstance.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__SyncAnimInstance_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A7EF RID: 174063 RVA: 0x00A5B125 File Offset: 0x00A59325
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateHeadRotator()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__UpdateHeadRotator_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F0 RID: 174064 RVA: 0x00A5B13C File Offset: 0x00A5933C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual float GetHeadApha()
		{
			ABP_PerformanceRole_C.__GetHeadApha_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__GetHeadApha_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_PerformanceRole_C.__GetHeadApha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__GetHeadApha_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__GetHeadApha_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602A7F1 RID: 174065 RVA: 0x00A5B184 File Offset: 0x00A59384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetState(EPerformanceRoleState State, bool reLoop, bool reLoopFromLoopToStart, bool WaitLaseStateEnd)
		{
			ABP_PerformanceRole_C.__SetState_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__SetState_FunctionParams[(UIntPtr)29] + 15L / (long)sizeof(ABP_PerformanceRole_C.__SetState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__SetState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->State = State;
			ptr->reLoop = reLoop;
			ptr->reLoopFromLoopToStart = reLoopFromLoopToStart;
			ptr->WaitLaseStateEnd = WaitLaseStateEnd;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__SetState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A7F2 RID: 174066 RVA: 0x00A5B1E5 File Offset: 0x00A593E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7A87E8194AFB02D1564F408592A3BAE7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7A87E8194AFB02D1564F408592A3BAE7_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F3 RID: 174067 RVA: 0x00A5B1F9 File Offset: 0x00A593F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_C60CCB8046FAB6F0C07D51B6B238E4BA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_C60CCB8046FAB6F0C07D51B6B238E4BA_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F4 RID: 174068 RVA: 0x00A5B20D File Offset: 0x00A5940D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_1076956541FC74BF7A3047BF3518CA89()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_1076956541FC74BF7A3047BF3518CA89_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F5 RID: 174069 RVA: 0x00A5B221 File Offset: 0x00A59421
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_83C90D9A461EF15044A8378A68A6F1E7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_83C90D9A461EF15044A8378A68A6F1E7_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F6 RID: 174070 RVA: 0x00A5B235 File Offset: 0x00A59435
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_0F4FD3374213D4A81960F6A629673AFD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_0F4FD3374213D4A81960F6A629673AFD_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F7 RID: 174071 RVA: 0x00A5B249 File Offset: 0x00A59449
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_52B4B2CB407931033523C9A14696E52E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_52B4B2CB407931033523C9A14696E52E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F8 RID: 174072 RVA: 0x00A5B25D File Offset: 0x00A5945D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_CC733D604E95BE7D9DFA349B1A5B704D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_CC733D604E95BE7D9DFA349B1A5B704D_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7F9 RID: 174073 RVA: 0x00A5B271 File Offset: 0x00A59471
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_73AE160147ADB36045B8D9A31DC6AF15()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_73AE160147ADB36045B8D9A31DC6AF15_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7FA RID: 174074 RVA: 0x00A5B285 File Offset: 0x00A59485
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_4AEEB993432FEF9CF04A43AFC809B4FC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_4AEEB993432FEF9CF04A43AFC809B4FC_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7FB RID: 174075 RVA: 0x00A5B299 File Offset: 0x00A59499
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_DB55A1AE4A9423A5C47525A74E58BEB7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_DB55A1AE4A9423A5C47525A74E58BEB7_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7FC RID: 174076 RVA: 0x00A5B2AD File Offset: 0x00A594AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_A0B917284B95FD2DCEAED29BE0D5525E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_A0B917284B95FD2DCEAED29BE0D5525E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7FD RID: 174077 RVA: 0x00A5B2C1 File Offset: 0x00A594C1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2FC853114BF83C19B08BFA8A8E704810()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2FC853114BF83C19B08BFA8A8E704810_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7FE RID: 174078 RVA: 0x00A5B2D5 File Offset: 0x00A594D5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3DADD4CD489C57336548428E9B1B930E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3DADD4CD489C57336548428E9B1B930E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A7FF RID: 174079 RVA: 0x00A5B2E9 File Offset: 0x00A594E9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_EF7B72AA40DDC31C385F22A6D2312B57()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_EF7B72AA40DDC31C385F22A6D2312B57_NativeFunctionPtr, null);
		}

		// Token: 0x0602A800 RID: 174080 RVA: 0x00A5B2FD File Offset: 0x00A594FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_5D88DA9A4E6CB0EE56C4F48CD32B926A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_5D88DA9A4E6CB0EE56C4F48CD32B926A_NativeFunctionPtr, null);
		}

		// Token: 0x0602A801 RID: 174081 RVA: 0x00A5B311 File Offset: 0x00A59511
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D841EEBF4C3AAEE4FA4E22A41EEED9B6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D841EEBF4C3AAEE4FA4E22A41EEED9B6_NativeFunctionPtr, null);
		}

		// Token: 0x0602A802 RID: 174082 RVA: 0x00A5B325 File Offset: 0x00A59525
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_5BC208AA421FCBC084C7A7B465D64E0E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_5BC208AA421FCBC084C7A7B465D64E0E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A803 RID: 174083 RVA: 0x00A5B339 File Offset: 0x00A59539
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_04D89DC14225578F83587E82FEB8F549()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_04D89DC14225578F83587E82FEB8F549_NativeFunctionPtr, null);
		}

		// Token: 0x0602A804 RID: 174084 RVA: 0x00A5B34D File Offset: 0x00A5954D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9B9A0DA843AEF6FCA8E554BC94E139A1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9B9A0DA843AEF6FCA8E554BC94E139A1_NativeFunctionPtr, null);
		}

		// Token: 0x0602A805 RID: 174085 RVA: 0x00A5B361 File Offset: 0x00A59561
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9DF1923C49FACD33DB7996B4F88AA35F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9DF1923C49FACD33DB7996B4F88AA35F_NativeFunctionPtr, null);
		}

		// Token: 0x0602A806 RID: 174086 RVA: 0x00A5B375 File Offset: 0x00A59575
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D4C08C6346453FFFCC8A24BBA1C4CA70()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D4C08C6346453FFFCC8A24BBA1C4CA70_NativeFunctionPtr, null);
		}

		// Token: 0x0602A807 RID: 174087 RVA: 0x00A5B389 File Offset: 0x00A59589
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_942EF62C4B629FF8B62DE58BA4978BE1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_942EF62C4B629FF8B62DE58BA4978BE1_NativeFunctionPtr, null);
		}

		// Token: 0x0602A808 RID: 174088 RVA: 0x00A5B39D File Offset: 0x00A5959D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_56C6ACAC4E6FDEC24A16658E3730D394()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_56C6ACAC4E6FDEC24A16658E3730D394_NativeFunctionPtr, null);
		}

		// Token: 0x0602A809 RID: 174089 RVA: 0x00A5B3B1 File Offset: 0x00A595B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_30B0B6454BB641F81FA89F95CA2E7A79()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_30B0B6454BB641F81FA89F95CA2E7A79_NativeFunctionPtr, null);
		}

		// Token: 0x0602A80A RID: 174090 RVA: 0x00A5B3C5 File Offset: 0x00A595C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_481747314088EF8A503B2B82F47812FC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_481747314088EF8A503B2B82F47812FC_NativeFunctionPtr, null);
		}

		// Token: 0x0602A80B RID: 174091 RVA: 0x00A5B3D9 File Offset: 0x00A595D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3FE8E3C646A416753DEE2AA221F25FA6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3FE8E3C646A416753DEE2AA221F25FA6_NativeFunctionPtr, null);
		}

		// Token: 0x0602A80C RID: 174092 RVA: 0x00A5B3ED File Offset: 0x00A595ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_24C99C61467D0205D123EC9AF5E06C23()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_24C99C61467D0205D123EC9AF5E06C23_NativeFunctionPtr, null);
		}

		// Token: 0x0602A80D RID: 174093 RVA: 0x00A5B401 File Offset: 0x00A59601
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_C03E217044F8BF62D9BDACB1542C2794()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_C03E217044F8BF62D9BDACB1542C2794_NativeFunctionPtr, null);
		}

		// Token: 0x0602A80E RID: 174094 RVA: 0x00A5B415 File Offset: 0x00A59615
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_FAF7A35C48527E1EA6A4AAB20EA2F436()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_FAF7A35C48527E1EA6A4AAB20EA2F436_NativeFunctionPtr, null);
		}

		// Token: 0x0602A80F RID: 174095 RVA: 0x00A5B429 File Offset: 0x00A59629
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3D8EDC0949A468E4288C94B5166CDF2E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3D8EDC0949A468E4288C94B5166CDF2E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A810 RID: 174096 RVA: 0x00A5B43D File Offset: 0x00A5963D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_0EDB639B401750A5D4E478B1823AE6FC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_0EDB639B401750A5D4E478B1823AE6FC_NativeFunctionPtr, null);
		}

		// Token: 0x0602A811 RID: 174097 RVA: 0x00A5B451 File Offset: 0x00A59651
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7EAEA40441EE79176E27DFA6B4F9FFC5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7EAEA40441EE79176E27DFA6B4F9FFC5_NativeFunctionPtr, null);
		}

		// Token: 0x0602A812 RID: 174098 RVA: 0x00A5B465 File Offset: 0x00A59665
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_B16644EE4359CE65D1A16BA8DE0E6A01()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_B16644EE4359CE65D1A16BA8DE0E6A01_NativeFunctionPtr, null);
		}

		// Token: 0x0602A813 RID: 174099 RVA: 0x00A5B479 File Offset: 0x00A59679
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2A9BD4814CE11A56D9F8B5AD28BCDB54()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2A9BD4814CE11A56D9F8B5AD28BCDB54_NativeFunctionPtr, null);
		}

		// Token: 0x0602A814 RID: 174100 RVA: 0x00A5B48D File Offset: 0x00A5968D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7331EF0C4FCC8260EC07C4B64D3B1D31()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7331EF0C4FCC8260EC07C4B64D3B1D31_NativeFunctionPtr, null);
		}

		// Token: 0x0602A815 RID: 174101 RVA: 0x00A5B4A1 File Offset: 0x00A596A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_B66CA673436FECF98D604D97A2B6C06A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_B66CA673436FECF98D604D97A2B6C06A_NativeFunctionPtr, null);
		}

		// Token: 0x0602A816 RID: 174102 RVA: 0x00A5B4B5 File Offset: 0x00A596B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_252C9B604DA355A186FC139923D59B56()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_252C9B604DA355A186FC139923D59B56_NativeFunctionPtr, null);
		}

		// Token: 0x0602A817 RID: 174103 RVA: 0x00A5B4C9 File Offset: 0x00A596C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_DEAF3D294066272ACE060C9862C527BD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_DEAF3D294066272ACE060C9862C527BD_NativeFunctionPtr, null);
		}

		// Token: 0x0602A818 RID: 174104 RVA: 0x00A5B4DD File Offset: 0x00A596DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_FA89A36640926C129757FAA49AF6A81A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_FA89A36640926C129757FAA49AF6A81A_NativeFunctionPtr, null);
		}

		// Token: 0x0602A819 RID: 174105 RVA: 0x00A5B4F1 File Offset: 0x00A596F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3921814044F2A49574F5B4B48102EC67()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3921814044F2A49574F5B4B48102EC67_NativeFunctionPtr, null);
		}

		// Token: 0x0602A81A RID: 174106 RVA: 0x00A5B505 File Offset: 0x00A59705
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_87A017DC465C0B783BDB8793686B2399()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_87A017DC465C0B783BDB8793686B2399_NativeFunctionPtr, null);
		}

		// Token: 0x0602A81B RID: 174107 RVA: 0x00A5B519 File Offset: 0x00A59719
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_81008DE54870516BAB6E5E90973EF5C6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_81008DE54870516BAB6E5E90973EF5C6_NativeFunctionPtr, null);
		}

		// Token: 0x0602A81C RID: 174108 RVA: 0x00A5B52D File Offset: 0x00A5972D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BC16130F44311D0DCB5B3590AECBE007()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BC16130F44311D0DCB5B3590AECBE007_NativeFunctionPtr, null);
		}

		// Token: 0x0602A81D RID: 174109 RVA: 0x00A5B541 File Offset: 0x00A59741
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3BAA36394ACE885F5D49E6B207A23E6C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3BAA36394ACE885F5D49E6B207A23E6C_NativeFunctionPtr, null);
		}

		// Token: 0x0602A81E RID: 174110 RVA: 0x00A5B555 File Offset: 0x00A59755
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7B44C6194963AAC6D793758E0821AA37()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7B44C6194963AAC6D793758E0821AA37_NativeFunctionPtr, null);
		}

		// Token: 0x0602A81F RID: 174111 RVA: 0x00A5B569 File Offset: 0x00A59769
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3A2D0019410882106E3D5AA8D6F2C19E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3A2D0019410882106E3D5AA8D6F2C19E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A820 RID: 174112 RVA: 0x00A5B57D File Offset: 0x00A5977D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3544AA1645E0CF5C1B631BBF34548087()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3544AA1645E0CF5C1B631BBF34548087_NativeFunctionPtr, null);
		}

		// Token: 0x0602A821 RID: 174113 RVA: 0x00A5B591 File Offset: 0x00A59791
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_A59B1C3E413B4FF0E0A40C8A4E1608A4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_A59B1C3E413B4FF0E0A40C8A4E1608A4_NativeFunctionPtr, null);
		}

		// Token: 0x0602A822 RID: 174114 RVA: 0x00A5B5A5 File Offset: 0x00A597A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9C35D5CF4052F823573EDCA339C5BC95()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9C35D5CF4052F823573EDCA339C5BC95_NativeFunctionPtr, null);
		}

		// Token: 0x0602A823 RID: 174115 RVA: 0x00A5B5B9 File Offset: 0x00A597B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_05AA19EC4BA5688F5DC376ABA8F556E9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_05AA19EC4BA5688F5DC376ABA8F556E9_NativeFunctionPtr, null);
		}

		// Token: 0x0602A824 RID: 174116 RVA: 0x00A5B5CD File Offset: 0x00A597CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BB9DF0D54320499047A5319654D5DC2E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BB9DF0D54320499047A5319654D5DC2E_NativeFunctionPtr, null);
		}

		// Token: 0x0602A825 RID: 174117 RVA: 0x00A5B5E1 File Offset: 0x00A597E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2C2EF99049E4EE2383BBD8B2786A4567()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2C2EF99049E4EE2383BBD8B2786A4567_NativeFunctionPtr, null);
		}

		// Token: 0x0602A826 RID: 174118 RVA: 0x00A5B5F5 File Offset: 0x00A597F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_E88CAB8D428F886DE51EB5A9BE372770()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_E88CAB8D428F886DE51EB5A9BE372770_NativeFunctionPtr, null);
		}

		// Token: 0x0602A827 RID: 174119 RVA: 0x00A5B609 File Offset: 0x00A59809
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_41DFE03F48C3833355C616B28AAF5009()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_41DFE03F48C3833355C616B28AAF5009_NativeFunctionPtr, null);
		}

		// Token: 0x0602A828 RID: 174120 RVA: 0x00A5B61D File Offset: 0x00A5981D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2964307E48D5040F742A49B35F13F408()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2964307E48D5040F742A49B35F13F408_NativeFunctionPtr, null);
		}

		// Token: 0x0602A829 RID: 174121 RVA: 0x00A5B631 File Offset: 0x00A59831
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D7436D7443A480F5FAF15A882087F30F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D7436D7443A480F5FAF15A882087F30F_NativeFunctionPtr, null);
		}

		// Token: 0x0602A82A RID: 174122 RVA: 0x00A5B648 File Offset: 0x00A59848
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_PerformanceRole_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PerformanceRole_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602A82B RID: 174123 RVA: 0x00A5B690 File Offset: 0x00A59890
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_PerformanceRole_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_PerformanceRole_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PerformanceRole_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A82C RID: 174124 RVA: 0x00A5B6D7 File Offset: 0x00A598D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterCommonNotify()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterCommonNotify_NativeFunctionPtr, null);
		}

		// Token: 0x0602A82D RID: 174125 RVA: 0x00A5B6EB File Offset: 0x00A598EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeaveOneLoopAction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_LeaveOneLoopAction_NativeFunctionPtr, null);
		}

		// Token: 0x0602A82E RID: 174126 RVA: 0x00A5B6FF File Offset: 0x00A598FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterPerformIdle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterPerformIdle_NativeFunctionPtr, null);
		}

		// Token: 0x0602A82F RID: 174127 RVA: 0x00A5B713 File Offset: 0x00A59913
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602A830 RID: 174128 RVA: 0x00A5B727 File Offset: 0x00A59927
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PerformanceRole_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602A831 RID: 174129 RVA: 0x00A5B73C File Offset: 0x00A5993C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_83BA3C6F46EB8037E9C60BB9BDA31608()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_83BA3C6F46EB8037E9C60BB9BDA31608_NativeFunctionPtr, null);
		}

		// Token: 0x0602A832 RID: 174130 RVA: 0x00A5B750 File Offset: 0x00A59950
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_F6F9F8DC40D588C967DF2B9A41C97C25()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_F6F9F8DC40D588C967DF2B9A41C97C25_NativeFunctionPtr, null);
		}

		// Token: 0x0602A833 RID: 174131 RVA: 0x00A5B764 File Offset: 0x00A59964
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BC9EBC4944D2E109BC5CAA94C70EB8BC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BC9EBC4944D2E109BC5CAA94C70EB8BC_NativeFunctionPtr, null);
		}

		// Token: 0x0602A834 RID: 174132 RVA: 0x00A5B778 File Offset: 0x00A59978
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterLoop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterLoop_NativeFunctionPtr, null);
		}

		// Token: 0x0602A835 RID: 174133 RVA: 0x00A5B78C File Offset: 0x00A5998C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeaveLoop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_LeaveLoop_NativeFunctionPtr, null);
		}

		// Token: 0x0602A836 RID: 174134 RVA: 0x00A5B7A0 File Offset: 0x00A599A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_SkillEndBegin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_SkillEndBegin_NativeFunctionPtr, null);
		}

		// Token: 0x0602A837 RID: 174135 RVA: 0x00A5B7B4 File Offset: 0x00A599B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_1B4EAA5848C16EDBEFB00FB24D38B27F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_1B4EAA5848C16EDBEFB00FB24D38B27F_NativeFunctionPtr, null);
		}

		// Token: 0x0602A838 RID: 174136 RVA: 0x00A5B7C8 File Offset: 0x00A599C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_ED21A98E48FA85555EA0D4A7C2A13D4F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_ED21A98E48FA85555EA0D4A7C2A13D4F_NativeFunctionPtr, null);
		}

		// Token: 0x0602A839 RID: 174137 RVA: 0x00A5B7DC File Offset: 0x00A599DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterSkill()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterSkill_NativeFunctionPtr, null);
		}

		// Token: 0x0602A83A RID: 174138 RVA: 0x00A5B7F0 File Offset: 0x00A599F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterAttribute()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterAttribute_NativeFunctionPtr, null);
		}

		// Token: 0x0602A83B RID: 174139 RVA: 0x00A5B804 File Offset: 0x00A59A04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterRoleBreach()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterRoleBreach_NativeFunctionPtr, null);
		}

		// Token: 0x0602A83C RID: 174140 RVA: 0x00A5B818 File Offset: 0x00A59A18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterResonce()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterResonce_NativeFunctionPtr, null);
		}

		// Token: 0x0602A83D RID: 174141 RVA: 0x00A5B82C File Offset: 0x00A59A2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterRoleElementStand()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterRoleElementStand_NativeFunctionPtr, null);
		}

		// Token: 0x0602A83E RID: 174142 RVA: 0x00A5B840 File Offset: 0x00A59A40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterRoleElement()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterRoleElement_NativeFunctionPtr, null);
		}

		// Token: 0x0602A83F RID: 174143 RVA: 0x00A5B854 File Offset: 0x00A59A54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterChip()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterChip_NativeFunctionPtr, null);
		}

		// Token: 0x0602A840 RID: 174144 RVA: 0x00A5B868 File Offset: 0x00A59A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterWeapon()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterWeapon_NativeFunctionPtr, null);
		}

		// Token: 0x0602A841 RID: 174145 RVA: 0x00A5B87C File Offset: 0x00A59A7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterIdle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterIdle_NativeFunctionPtr, null);
		}

		// Token: 0x0602A842 RID: 174146 RVA: 0x00A5B890 File Offset: 0x00A59A90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterDocumentAction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterDocumentAction_NativeFunctionPtr, null);
		}

		// Token: 0x0602A843 RID: 174147 RVA: 0x00A5B8A4 File Offset: 0x00A59AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterDocumentVoice()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterDocumentVoice_NativeFunctionPtr, null);
		}

		// Token: 0x0602A844 RID: 174148 RVA: 0x00A5B8B8 File Offset: 0x00A59AB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_EnterDocument()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_EnterDocument_NativeFunctionPtr, null);
		}

		// Token: 0x0602A845 RID: 174149 RVA: 0x00A5B8CC File Offset: 0x00A59ACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeaveCommonNotify()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_PerformanceRole_C.__AnimNotify_LeaveCommonNotify_NativeFunctionPtr, null);
		}

		// Token: 0x0602A846 RID: 174150 RVA: 0x00A5B8E0 File Offset: 0x00A59AE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_PerformanceRole(int EntryPoint)
		{
			ABP_PerformanceRole_C.__ExecuteUbergraph_ABP_PerformanceRole_FunctionParams* ptr = stackalloc ABP_PerformanceRole_C.__ExecuteUbergraph_ABP_PerformanceRole_FunctionParams[(UIntPtr)279] + 15L / (long)sizeof(ABP_PerformanceRole_C.__ExecuteUbergraph_ABP_PerformanceRole_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_PerformanceRole_C.__ExecuteUbergraph_ABP_PerformanceRole_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_PerformanceRole_C.__ExecuteUbergraph_ABP_PerformanceRole_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602A847 RID: 174151 RVA: 0x00A5B92A File Offset: 0x00A59B2A
		protected ABP_PerformanceRole_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04016F51 RID: 94033
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C";

		// Token: 0x04016F52 RID: 94034
		private static IntPtr _ClassPtr;

		// Token: 0x04016F53 RID: 94035
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04016F54 RID: 94036
		public static IntPtr __OnEffectEnd__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04016F55 RID: 94037
		public static IntPtr __OnEffectBegin__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04016F56 RID: 94038
		internal static int __PropertyOffset_0;

		// Token: 0x04016F57 RID: 94039
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04016F58 RID: 94040
		internal static int __PropertyOffset_1;

		// Token: 0x04016F59 RID: 94041
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04016F5A RID: 94042
		internal static int __PropertyOffset_2;

		// Token: 0x04016F5B RID: 94043
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04016F5C RID: 94044
		internal static int __PropertyOffset_3;

		// Token: 0x04016F5D RID: 94045
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04016F5E RID: 94046
		internal static int __PropertyOffset_4;

		// Token: 0x04016F5F RID: 94047
		[Nullable(2)]
		private FAnimNode_RBF _AnimGraphNode_RBF;

		// Token: 0x04016F60 RID: 94048
		internal static int __PropertyOffset_5;

		// Token: 0x04016F61 RID: 94049
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x04016F62 RID: 94050
		internal static int __PropertyOffset_6;

		// Token: 0x04016F63 RID: 94051
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04016F64 RID: 94052
		internal static int __PropertyOffset_7;

		// Token: 0x04016F65 RID: 94053
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_113;

		// Token: 0x04016F66 RID: 94054
		internal static int __PropertyOffset_8;

		// Token: 0x04016F67 RID: 94055
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_112;

		// Token: 0x04016F68 RID: 94056
		internal static int __PropertyOffset_9;

		// Token: 0x04016F69 RID: 94057
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_111;

		// Token: 0x04016F6A RID: 94058
		internal static int __PropertyOffset_10;

		// Token: 0x04016F6B RID: 94059
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_110;

		// Token: 0x04016F6C RID: 94060
		internal static int __PropertyOffset_11;

		// Token: 0x04016F6D RID: 94061
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_109;

		// Token: 0x04016F6E RID: 94062
		internal static int __PropertyOffset_12;

		// Token: 0x04016F6F RID: 94063
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_108;

		// Token: 0x04016F70 RID: 94064
		internal static int __PropertyOffset_13;

		// Token: 0x04016F71 RID: 94065
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_107;

		// Token: 0x04016F72 RID: 94066
		internal static int __PropertyOffset_14;

		// Token: 0x04016F73 RID: 94067
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_106;

		// Token: 0x04016F74 RID: 94068
		internal static int __PropertyOffset_15;

		// Token: 0x04016F75 RID: 94069
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_105;

		// Token: 0x04016F76 RID: 94070
		internal static int __PropertyOffset_16;

		// Token: 0x04016F77 RID: 94071
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_104;

		// Token: 0x04016F78 RID: 94072
		internal static int __PropertyOffset_17;

		// Token: 0x04016F79 RID: 94073
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_103;

		// Token: 0x04016F7A RID: 94074
		internal static int __PropertyOffset_18;

		// Token: 0x04016F7B RID: 94075
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_102;

		// Token: 0x04016F7C RID: 94076
		internal static int __PropertyOffset_19;

		// Token: 0x04016F7D RID: 94077
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_101;

		// Token: 0x04016F7E RID: 94078
		internal static int __PropertyOffset_20;

		// Token: 0x04016F7F RID: 94079
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_100;

		// Token: 0x04016F80 RID: 94080
		internal static int __PropertyOffset_21;

		// Token: 0x04016F81 RID: 94081
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_99;

		// Token: 0x04016F82 RID: 94082
		internal static int __PropertyOffset_22;

		// Token: 0x04016F83 RID: 94083
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_98;

		// Token: 0x04016F84 RID: 94084
		internal static int __PropertyOffset_23;

		// Token: 0x04016F85 RID: 94085
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_97;

		// Token: 0x04016F86 RID: 94086
		internal static int __PropertyOffset_24;

		// Token: 0x04016F87 RID: 94087
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_96;

		// Token: 0x04016F88 RID: 94088
		internal static int __PropertyOffset_25;

		// Token: 0x04016F89 RID: 94089
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_95;

		// Token: 0x04016F8A RID: 94090
		internal static int __PropertyOffset_26;

		// Token: 0x04016F8B RID: 94091
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_94;

		// Token: 0x04016F8C RID: 94092
		internal static int __PropertyOffset_27;

		// Token: 0x04016F8D RID: 94093
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_93;

		// Token: 0x04016F8E RID: 94094
		internal static int __PropertyOffset_28;

		// Token: 0x04016F8F RID: 94095
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_92;

		// Token: 0x04016F90 RID: 94096
		internal static int __PropertyOffset_29;

		// Token: 0x04016F91 RID: 94097
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_91;

		// Token: 0x04016F92 RID: 94098
		internal static int __PropertyOffset_30;

		// Token: 0x04016F93 RID: 94099
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_90;

		// Token: 0x04016F94 RID: 94100
		internal static int __PropertyOffset_31;

		// Token: 0x04016F95 RID: 94101
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_89;

		// Token: 0x04016F96 RID: 94102
		internal static int __PropertyOffset_32;

		// Token: 0x04016F97 RID: 94103
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_88;

		// Token: 0x04016F98 RID: 94104
		internal static int __PropertyOffset_33;

		// Token: 0x04016F99 RID: 94105
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_87;

		// Token: 0x04016F9A RID: 94106
		internal static int __PropertyOffset_34;

		// Token: 0x04016F9B RID: 94107
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_86;

		// Token: 0x04016F9C RID: 94108
		internal static int __PropertyOffset_35;

		// Token: 0x04016F9D RID: 94109
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_85;

		// Token: 0x04016F9E RID: 94110
		internal static int __PropertyOffset_36;

		// Token: 0x04016F9F RID: 94111
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_84;

		// Token: 0x04016FA0 RID: 94112
		internal static int __PropertyOffset_37;

		// Token: 0x04016FA1 RID: 94113
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_83;

		// Token: 0x04016FA2 RID: 94114
		internal static int __PropertyOffset_38;

		// Token: 0x04016FA3 RID: 94115
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_82;

		// Token: 0x04016FA4 RID: 94116
		internal static int __PropertyOffset_39;

		// Token: 0x04016FA5 RID: 94117
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_81;

		// Token: 0x04016FA6 RID: 94118
		internal static int __PropertyOffset_40;

		// Token: 0x04016FA7 RID: 94119
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_80;

		// Token: 0x04016FA8 RID: 94120
		internal static int __PropertyOffset_41;

		// Token: 0x04016FA9 RID: 94121
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_79;

		// Token: 0x04016FAA RID: 94122
		internal static int __PropertyOffset_42;

		// Token: 0x04016FAB RID: 94123
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_78;

		// Token: 0x04016FAC RID: 94124
		internal static int __PropertyOffset_43;

		// Token: 0x04016FAD RID: 94125
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_77;

		// Token: 0x04016FAE RID: 94126
		internal static int __PropertyOffset_44;

		// Token: 0x04016FAF RID: 94127
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_76;

		// Token: 0x04016FB0 RID: 94128
		internal static int __PropertyOffset_45;

		// Token: 0x04016FB1 RID: 94129
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_75;

		// Token: 0x04016FB2 RID: 94130
		internal static int __PropertyOffset_46;

		// Token: 0x04016FB3 RID: 94131
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_74;

		// Token: 0x04016FB4 RID: 94132
		internal static int __PropertyOffset_47;

		// Token: 0x04016FB5 RID: 94133
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_73;

		// Token: 0x04016FB6 RID: 94134
		internal static int __PropertyOffset_48;

		// Token: 0x04016FB7 RID: 94135
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_72;

		// Token: 0x04016FB8 RID: 94136
		internal static int __PropertyOffset_49;

		// Token: 0x04016FB9 RID: 94137
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_71;

		// Token: 0x04016FBA RID: 94138
		internal static int __PropertyOffset_50;

		// Token: 0x04016FBB RID: 94139
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_70;

		// Token: 0x04016FBC RID: 94140
		internal static int __PropertyOffset_51;

		// Token: 0x04016FBD RID: 94141
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_69;

		// Token: 0x04016FBE RID: 94142
		internal static int __PropertyOffset_52;

		// Token: 0x04016FBF RID: 94143
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_68;

		// Token: 0x04016FC0 RID: 94144
		internal static int __PropertyOffset_53;

		// Token: 0x04016FC1 RID: 94145
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_67;

		// Token: 0x04016FC2 RID: 94146
		internal static int __PropertyOffset_54;

		// Token: 0x04016FC3 RID: 94147
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_66;

		// Token: 0x04016FC4 RID: 94148
		internal static int __PropertyOffset_55;

		// Token: 0x04016FC5 RID: 94149
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_65;

		// Token: 0x04016FC6 RID: 94150
		internal static int __PropertyOffset_56;

		// Token: 0x04016FC7 RID: 94151
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_64;

		// Token: 0x04016FC8 RID: 94152
		internal static int __PropertyOffset_57;

		// Token: 0x04016FC9 RID: 94153
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_63;

		// Token: 0x04016FCA RID: 94154
		internal static int __PropertyOffset_58;

		// Token: 0x04016FCB RID: 94155
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_62;

		// Token: 0x04016FCC RID: 94156
		internal static int __PropertyOffset_59;

		// Token: 0x04016FCD RID: 94157
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_61;

		// Token: 0x04016FCE RID: 94158
		internal static int __PropertyOffset_60;

		// Token: 0x04016FCF RID: 94159
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_60;

		// Token: 0x04016FD0 RID: 94160
		internal static int __PropertyOffset_61;

		// Token: 0x04016FD1 RID: 94161
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_59;

		// Token: 0x04016FD2 RID: 94162
		internal static int __PropertyOffset_62;

		// Token: 0x04016FD3 RID: 94163
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_58;

		// Token: 0x04016FD4 RID: 94164
		internal static int __PropertyOffset_63;

		// Token: 0x04016FD5 RID: 94165
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_34;

		// Token: 0x04016FD6 RID: 94166
		internal static int __PropertyOffset_64;

		// Token: 0x04016FD7 RID: 94167
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_53;

		// Token: 0x04016FD8 RID: 94168
		internal static int __PropertyOffset_65;

		// Token: 0x04016FD9 RID: 94169
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_33;

		// Token: 0x04016FDA RID: 94170
		internal static int __PropertyOffset_66;

		// Token: 0x04016FDB RID: 94171
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_52;

		// Token: 0x04016FDC RID: 94172
		internal static int __PropertyOffset_67;

		// Token: 0x04016FDD RID: 94173
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_57;

		// Token: 0x04016FDE RID: 94174
		internal static int __PropertyOffset_68;

		// Token: 0x04016FDF RID: 94175
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_32;

		// Token: 0x04016FE0 RID: 94176
		internal static int __PropertyOffset_69;

		// Token: 0x04016FE1 RID: 94177
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_51;

		// Token: 0x04016FE2 RID: 94178
		internal static int __PropertyOffset_70;

		// Token: 0x04016FE3 RID: 94179
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_56;

		// Token: 0x04016FE4 RID: 94180
		internal static int __PropertyOffset_71;

		// Token: 0x04016FE5 RID: 94181
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_55;

		// Token: 0x04016FE6 RID: 94182
		internal static int __PropertyOffset_72;

		// Token: 0x04016FE7 RID: 94183
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_54;

		// Token: 0x04016FE8 RID: 94184
		internal static int __PropertyOffset_73;

		// Token: 0x04016FE9 RID: 94185
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_13;

		// Token: 0x04016FEA RID: 94186
		internal static int __PropertyOffset_74;

		// Token: 0x04016FEB RID: 94187
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_12;

		// Token: 0x04016FEC RID: 94188
		internal static int __PropertyOffset_75;

		// Token: 0x04016FED RID: 94189
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult_6;

		// Token: 0x04016FEE RID: 94190
		internal static int __PropertyOffset_76;

		// Token: 0x04016FEF RID: 94191
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_53;

		// Token: 0x04016FF0 RID: 94192
		internal static int __PropertyOffset_77;

		// Token: 0x04016FF1 RID: 94193
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_5;

		// Token: 0x04016FF2 RID: 94194
		internal static int __PropertyOffset_78;

		// Token: 0x04016FF3 RID: 94195
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_50;

		// Token: 0x04016FF4 RID: 94196
		internal static int __PropertyOffset_79;

		// Token: 0x04016FF5 RID: 94197
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_31;

		// Token: 0x04016FF6 RID: 94198
		internal static int __PropertyOffset_80;

		// Token: 0x04016FF7 RID: 94199
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_49;

		// Token: 0x04016FF8 RID: 94200
		internal static int __PropertyOffset_81;

		// Token: 0x04016FF9 RID: 94201
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_30;

		// Token: 0x04016FFA RID: 94202
		internal static int __PropertyOffset_82;

		// Token: 0x04016FFB RID: 94203
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_48;

		// Token: 0x04016FFC RID: 94204
		internal static int __PropertyOffset_83;

		// Token: 0x04016FFD RID: 94205
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_11;

		// Token: 0x04016FFE RID: 94206
		internal static int __PropertyOffset_84;

		// Token: 0x04016FFF RID: 94207
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_47;

		// Token: 0x04017000 RID: 94208
		internal static int __PropertyOffset_85;

		// Token: 0x04017001 RID: 94209
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_52;

		// Token: 0x04017002 RID: 94210
		internal static int __PropertyOffset_86;

		// Token: 0x04017003 RID: 94211
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_29;

		// Token: 0x04017004 RID: 94212
		internal static int __PropertyOffset_87;

		// Token: 0x04017005 RID: 94213
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_46;

		// Token: 0x04017006 RID: 94214
		internal static int __PropertyOffset_88;

		// Token: 0x04017007 RID: 94215
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04017008 RID: 94216
		internal static int __PropertyOffset_89;

		// Token: 0x04017009 RID: 94217
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_28;

		// Token: 0x0401700A RID: 94218
		internal static int __PropertyOffset_90;

		// Token: 0x0401700B RID: 94219
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_45;

		// Token: 0x0401700C RID: 94220
		internal static int __PropertyOffset_91;

		// Token: 0x0401700D RID: 94221
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_10;

		// Token: 0x0401700E RID: 94222
		internal static int __PropertyOffset_92;

		// Token: 0x0401700F RID: 94223
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_44;

		// Token: 0x04017010 RID: 94224
		internal static int __PropertyOffset_93;

		// Token: 0x04017011 RID: 94225
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_51;

		// Token: 0x04017012 RID: 94226
		internal static int __PropertyOffset_94;

		// Token: 0x04017013 RID: 94227
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_27;

		// Token: 0x04017014 RID: 94228
		internal static int __PropertyOffset_95;

		// Token: 0x04017015 RID: 94229
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_43;

		// Token: 0x04017016 RID: 94230
		internal static int __PropertyOffset_96;

		// Token: 0x04017017 RID: 94231
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04017018 RID: 94232
		internal static int __PropertyOffset_97;

		// Token: 0x04017019 RID: 94233
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_26;

		// Token: 0x0401701A RID: 94234
		internal static int __PropertyOffset_98;

		// Token: 0x0401701B RID: 94235
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_42;

		// Token: 0x0401701C RID: 94236
		internal static int __PropertyOffset_99;

		// Token: 0x0401701D RID: 94237
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_9;

		// Token: 0x0401701E RID: 94238
		internal static int __PropertyOffset_100;

		// Token: 0x0401701F RID: 94239
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_41;

		// Token: 0x04017020 RID: 94240
		internal static int __PropertyOffset_101;

		// Token: 0x04017021 RID: 94241
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_50;

		// Token: 0x04017022 RID: 94242
		internal static int __PropertyOffset_102;

		// Token: 0x04017023 RID: 94243
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_25;

		// Token: 0x04017024 RID: 94244
		internal static int __PropertyOffset_103;

		// Token: 0x04017025 RID: 94245
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_40;

		// Token: 0x04017026 RID: 94246
		internal static int __PropertyOffset_104;

		// Token: 0x04017027 RID: 94247
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_49;

		// Token: 0x04017028 RID: 94248
		internal static int __PropertyOffset_105;

		// Token: 0x04017029 RID: 94249
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_48;

		// Token: 0x0401702A RID: 94250
		internal static int __PropertyOffset_106;

		// Token: 0x0401702B RID: 94251
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_47;

		// Token: 0x0401702C RID: 94252
		internal static int __PropertyOffset_107;

		// Token: 0x0401702D RID: 94253
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_46;

		// Token: 0x0401702E RID: 94254
		internal static int __PropertyOffset_108;

		// Token: 0x0401702F RID: 94255
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_11;

		// Token: 0x04017030 RID: 94256
		internal static int __PropertyOffset_109;

		// Token: 0x04017031 RID: 94257
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_10;

		// Token: 0x04017032 RID: 94258
		internal static int __PropertyOffset_110;

		// Token: 0x04017033 RID: 94259
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult_5;

		// Token: 0x04017034 RID: 94260
		internal static int __PropertyOffset_111;

		// Token: 0x04017035 RID: 94261
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_45;

		// Token: 0x04017036 RID: 94262
		internal static int __PropertyOffset_112;

		// Token: 0x04017037 RID: 94263
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_39;

		// Token: 0x04017038 RID: 94264
		internal static int __PropertyOffset_113;

		// Token: 0x04017039 RID: 94265
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x0401703A RID: 94266
		internal static int __PropertyOffset_114;

		// Token: 0x0401703B RID: 94267
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_24;

		// Token: 0x0401703C RID: 94268
		internal static int __PropertyOffset_115;

		// Token: 0x0401703D RID: 94269
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_38;

		// Token: 0x0401703E RID: 94270
		internal static int __PropertyOffset_116;

		// Token: 0x0401703F RID: 94271
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_23;

		// Token: 0x04017040 RID: 94272
		internal static int __PropertyOffset_117;

		// Token: 0x04017041 RID: 94273
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_37;

		// Token: 0x04017042 RID: 94274
		internal static int __PropertyOffset_118;

		// Token: 0x04017043 RID: 94275
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_8;

		// Token: 0x04017044 RID: 94276
		internal static int __PropertyOffset_119;

		// Token: 0x04017045 RID: 94277
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_36;

		// Token: 0x04017046 RID: 94278
		internal static int __PropertyOffset_120;

		// Token: 0x04017047 RID: 94279
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_22;

		// Token: 0x04017048 RID: 94280
		internal static int __PropertyOffset_121;

		// Token: 0x04017049 RID: 94281
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_35;

		// Token: 0x0401704A RID: 94282
		internal static int __PropertyOffset_122;

		// Token: 0x0401704B RID: 94283
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_44;

		// Token: 0x0401704C RID: 94284
		internal static int __PropertyOffset_123;

		// Token: 0x0401704D RID: 94285
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_43;

		// Token: 0x0401704E RID: 94286
		internal static int __PropertyOffset_124;

		// Token: 0x0401704F RID: 94287
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_42;

		// Token: 0x04017050 RID: 94288
		internal static int __PropertyOffset_125;

		// Token: 0x04017051 RID: 94289
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_9;

		// Token: 0x04017052 RID: 94290
		internal static int __PropertyOffset_126;

		// Token: 0x04017053 RID: 94291
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_8;

		// Token: 0x04017054 RID: 94292
		internal static int __PropertyOffset_127;

		// Token: 0x04017055 RID: 94293
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult_4;

		// Token: 0x04017056 RID: 94294
		internal static int __PropertyOffset_128;

		// Token: 0x04017057 RID: 94295
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_41;

		// Token: 0x04017058 RID: 94296
		internal static int __PropertyOffset_129;

		// Token: 0x04017059 RID: 94297
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_4;

		// Token: 0x0401705A RID: 94298
		internal static int __PropertyOffset_130;

		// Token: 0x0401705B RID: 94299
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_34;

		// Token: 0x0401705C RID: 94300
		internal static int __PropertyOffset_131;

		// Token: 0x0401705D RID: 94301
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_21;

		// Token: 0x0401705E RID: 94302
		internal static int __PropertyOffset_132;

		// Token: 0x0401705F RID: 94303
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_33;

		// Token: 0x04017060 RID: 94304
		internal static int __PropertyOffset_133;

		// Token: 0x04017061 RID: 94305
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_20;

		// Token: 0x04017062 RID: 94306
		internal static int __PropertyOffset_134;

		// Token: 0x04017063 RID: 94307
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_32;

		// Token: 0x04017064 RID: 94308
		internal static int __PropertyOffset_135;

		// Token: 0x04017065 RID: 94309
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_7;

		// Token: 0x04017066 RID: 94310
		internal static int __PropertyOffset_136;

		// Token: 0x04017067 RID: 94311
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_31;

		// Token: 0x04017068 RID: 94312
		internal static int __PropertyOffset_137;

		// Token: 0x04017069 RID: 94313
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_40;

		// Token: 0x0401706A RID: 94314
		internal static int __PropertyOffset_138;

		// Token: 0x0401706B RID: 94315
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_39;

		// Token: 0x0401706C RID: 94316
		internal static int __PropertyOffset_139;

		// Token: 0x0401706D RID: 94317
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_38;

		// Token: 0x0401706E RID: 94318
		internal static int __PropertyOffset_140;

		// Token: 0x0401706F RID: 94319
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_37;

		// Token: 0x04017070 RID: 94320
		internal static int __PropertyOffset_141;

		// Token: 0x04017071 RID: 94321
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_36;

		// Token: 0x04017072 RID: 94322
		internal static int __PropertyOffset_142;

		// Token: 0x04017073 RID: 94323
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_35;

		// Token: 0x04017074 RID: 94324
		internal static int __PropertyOffset_143;

		// Token: 0x04017075 RID: 94325
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_34;

		// Token: 0x04017076 RID: 94326
		internal static int __PropertyOffset_144;

		// Token: 0x04017077 RID: 94327
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_7;

		// Token: 0x04017078 RID: 94328
		internal static int __PropertyOffset_145;

		// Token: 0x04017079 RID: 94329
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_6;

		// Token: 0x0401707A RID: 94330
		internal static int __PropertyOffset_146;

		// Token: 0x0401707B RID: 94331
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult_3;

		// Token: 0x0401707C RID: 94332
		internal static int __PropertyOffset_147;

		// Token: 0x0401707D RID: 94333
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x0401707E RID: 94334
		internal static int __PropertyOffset_148;

		// Token: 0x0401707F RID: 94335
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x04017080 RID: 94336
		internal static int __PropertyOffset_149;

		// Token: 0x04017081 RID: 94337
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_3;

		// Token: 0x04017082 RID: 94338
		internal static int __PropertyOffset_150;

		// Token: 0x04017083 RID: 94339
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_30;

		// Token: 0x04017084 RID: 94340
		internal static int __PropertyOffset_151;

		// Token: 0x04017085 RID: 94341
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_19;

		// Token: 0x04017086 RID: 94342
		internal static int __PropertyOffset_152;

		// Token: 0x04017087 RID: 94343
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x04017088 RID: 94344
		internal static int __PropertyOffset_153;

		// Token: 0x04017089 RID: 94345
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_18;

		// Token: 0x0401708A RID: 94346
		internal static int __PropertyOffset_154;

		// Token: 0x0401708B RID: 94347
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x0401708C RID: 94348
		internal static int __PropertyOffset_155;

		// Token: 0x0401708D RID: 94349
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x0401708E RID: 94350
		internal static int __PropertyOffset_156;

		// Token: 0x0401708F RID: 94351
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x04017090 RID: 94352
		internal static int __PropertyOffset_157;

		// Token: 0x04017091 RID: 94353
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_6;

		// Token: 0x04017092 RID: 94354
		internal static int __PropertyOffset_158;

		// Token: 0x04017093 RID: 94355
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x04017094 RID: 94356
		internal static int __PropertyOffset_159;

		// Token: 0x04017095 RID: 94357
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x04017096 RID: 94358
		internal static int __PropertyOffset_160;

		// Token: 0x04017097 RID: 94359
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_17;

		// Token: 0x04017098 RID: 94360
		internal static int __PropertyOffset_161;

		// Token: 0x04017099 RID: 94361
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x0401709A RID: 94362
		internal static int __PropertyOffset_162;

		// Token: 0x0401709B RID: 94363
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x0401709C RID: 94364
		internal static int __PropertyOffset_163;

		// Token: 0x0401709D RID: 94365
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x0401709E RID: 94366
		internal static int __PropertyOffset_164;

		// Token: 0x0401709F RID: 94367
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x040170A0 RID: 94368
		internal static int __PropertyOffset_165;

		// Token: 0x040170A1 RID: 94369
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_5;

		// Token: 0x040170A2 RID: 94370
		internal static int __PropertyOffset_166;

		// Token: 0x040170A3 RID: 94371
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_4;

		// Token: 0x040170A4 RID: 94372
		internal static int __PropertyOffset_167;

		// Token: 0x040170A5 RID: 94373
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult_2;

		// Token: 0x040170A6 RID: 94374
		internal static int __PropertyOffset_168;

		// Token: 0x040170A7 RID: 94375
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x040170A8 RID: 94376
		internal static int __PropertyOffset_169;

		// Token: 0x040170A9 RID: 94377
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_2;

		// Token: 0x040170AA RID: 94378
		internal static int __PropertyOffset_170;

		// Token: 0x040170AB RID: 94379
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x040170AC RID: 94380
		internal static int __PropertyOffset_171;

		// Token: 0x040170AD RID: 94381
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_16;

		// Token: 0x040170AE RID: 94382
		internal static int __PropertyOffset_172;

		// Token: 0x040170AF RID: 94383
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x040170B0 RID: 94384
		internal static int __PropertyOffset_173;

		// Token: 0x040170B1 RID: 94385
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_15;

		// Token: 0x040170B2 RID: 94386
		internal static int __PropertyOffset_174;

		// Token: 0x040170B3 RID: 94387
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x040170B4 RID: 94388
		internal static int __PropertyOffset_175;

		// Token: 0x040170B5 RID: 94389
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_5;

		// Token: 0x040170B6 RID: 94390
		internal static int __PropertyOffset_176;

		// Token: 0x040170B7 RID: 94391
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x040170B8 RID: 94392
		internal static int __PropertyOffset_177;

		// Token: 0x040170B9 RID: 94393
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x040170BA RID: 94394
		internal static int __PropertyOffset_178;

		// Token: 0x040170BB RID: 94395
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x040170BC RID: 94396
		internal static int __PropertyOffset_179;

		// Token: 0x040170BD RID: 94397
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x040170BE RID: 94398
		internal static int __PropertyOffset_180;

		// Token: 0x040170BF RID: 94399
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x040170C0 RID: 94400
		internal static int __PropertyOffset_181;

		// Token: 0x040170C1 RID: 94401
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x040170C2 RID: 94402
		internal static int __PropertyOffset_182;

		// Token: 0x040170C3 RID: 94403
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x040170C4 RID: 94404
		internal static int __PropertyOffset_183;

		// Token: 0x040170C5 RID: 94405
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_3;

		// Token: 0x040170C6 RID: 94406
		internal static int __PropertyOffset_184;

		// Token: 0x040170C7 RID: 94407
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_2;

		// Token: 0x040170C8 RID: 94408
		internal static int __PropertyOffset_185;

		// Token: 0x040170C9 RID: 94409
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult_1;

		// Token: 0x040170CA RID: 94410
		internal static int __PropertyOffset_186;

		// Token: 0x040170CB RID: 94411
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x040170CC RID: 94412
		internal static int __PropertyOffset_187;

		// Token: 0x040170CD RID: 94413
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_1;

		// Token: 0x040170CE RID: 94414
		internal static int __PropertyOffset_188;

		// Token: 0x040170CF RID: 94415
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x040170D0 RID: 94416
		internal static int __PropertyOffset_189;

		// Token: 0x040170D1 RID: 94417
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x040170D2 RID: 94418
		internal static int __PropertyOffset_190;

		// Token: 0x040170D3 RID: 94419
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x040170D4 RID: 94420
		internal static int __PropertyOffset_191;

		// Token: 0x040170D5 RID: 94421
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x040170D6 RID: 94422
		internal static int __PropertyOffset_192;

		// Token: 0x040170D7 RID: 94423
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x040170D8 RID: 94424
		internal static int __PropertyOffset_193;

		// Token: 0x040170D9 RID: 94425
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x040170DA RID: 94426
		internal static int __PropertyOffset_194;

		// Token: 0x040170DB RID: 94427
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x040170DC RID: 94428
		internal static int __PropertyOffset_195;

		// Token: 0x040170DD RID: 94429
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x040170DE RID: 94430
		internal static int __PropertyOffset_196;

		// Token: 0x040170DF RID: 94431
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x040170E0 RID: 94432
		internal static int __PropertyOffset_197;

		// Token: 0x040170E1 RID: 94433
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x040170E2 RID: 94434
		internal static int __PropertyOffset_198;

		// Token: 0x040170E3 RID: 94435
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x040170E4 RID: 94436
		internal static int __PropertyOffset_199;

		// Token: 0x040170E5 RID: 94437
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x040170E6 RID: 94438
		internal static int __PropertyOffset_200;

		// Token: 0x040170E7 RID: 94439
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x040170E8 RID: 94440
		internal static int __PropertyOffset_201;

		// Token: 0x040170E9 RID: 94441
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator_1;

		// Token: 0x040170EA RID: 94442
		internal static int __PropertyOffset_202;

		// Token: 0x040170EB RID: 94443
		[Nullable(2)]
		private FAnimNode_TransitionPoseEvaluator _AnimGraphNode_TransitionPoseEvaluator;

		// Token: 0x040170EC RID: 94444
		internal static int __PropertyOffset_203;

		// Token: 0x040170ED RID: 94445
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_CustomTransitionResult;

		// Token: 0x040170EE RID: 94446
		internal static int __PropertyOffset_204;

		// Token: 0x040170EF RID: 94447
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x040170F0 RID: 94448
		internal static int __PropertyOffset_205;

		// Token: 0x040170F1 RID: 94449
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator;

		// Token: 0x040170F2 RID: 94450
		internal static int __PropertyOffset_206;

		// Token: 0x040170F3 RID: 94451
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x040170F4 RID: 94452
		internal static int __PropertyOffset_207;

		// Token: 0x040170F5 RID: 94453
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x040170F6 RID: 94454
		internal static int __PropertyOffset_208;

		// Token: 0x040170F7 RID: 94455
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x040170F8 RID: 94456
		internal static int __PropertyOffset_209;

		// Token: 0x040170F9 RID: 94457
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x040170FA RID: 94458
		internal static int __PropertyOffset_210;

		// Token: 0x040170FB RID: 94459
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x040170FC RID: 94460
		internal static int __PropertyOffset_211;

		// Token: 0x040170FD RID: 94461
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x040170FE RID: 94462
		internal static int __PropertyOffset_212;

		// Token: 0x040170FF RID: 94463
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04017100 RID: 94464
		internal static int __PropertyOffset_213;

		// Token: 0x04017101 RID: 94465
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04017102 RID: 94466
		internal static int __PropertyOffset_214;

		// Token: 0x04017103 RID: 94467
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04017104 RID: 94468
		internal static int __PropertyOffset_215;

		// Token: 0x04017105 RID: 94469
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04017106 RID: 94470
		internal static int __PropertyOffset_216;

		// Token: 0x04017107 RID: 94471
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04017108 RID: 94472
		internal static int __PropertyOffset_217;

		// Token: 0x04017109 RID: 94473
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x0401710A RID: 94474
		internal static int __PropertyOffset_218;

		// Token: 0x0401710B RID: 94475
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x0401710C RID: 94476
		internal static int __PropertyOffset_219;

		// Token: 0x0401710D RID: 94477
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x0401710E RID: 94478
		internal static int __PropertyOffset_220;

		// Token: 0x0401710F RID: 94479
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x04017110 RID: 94480
		internal static int __PropertyOffset_221;

		// Token: 0x04017111 RID: 94481
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x04017112 RID: 94482
		internal static int __PropertyOffset_222;

		// Token: 0x04017113 RID: 94483
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04017114 RID: 94484
		internal static int __PropertyOffset_223;

		// Token: 0x04017115 RID: 94485
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04017116 RID: 94486
		internal static int __PropertyOffset_224;

		// Token: 0x04017117 RID: 94487
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04017118 RID: 94488
		internal static int __PropertyOffset_225;

		// Token: 0x04017119 RID: 94489
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x0401711A RID: 94490
		internal static int __PropertyOffset_226;

		// Token: 0x0401711B RID: 94491
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x0401711C RID: 94492
		internal static int __PropertyOffset_227;

		// Token: 0x0401711D RID: 94493
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x0401711E RID: 94494
		internal static int __PropertyOffset_228;

		// Token: 0x0401711F RID: 94495
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04017120 RID: 94496
		internal static int __PropertyOffset_229;

		// Token: 0x04017121 RID: 94497
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04017122 RID: 94498
		internal static int __PropertyOffset_230;

		// Token: 0x04017123 RID: 94499
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04017124 RID: 94500
		internal static int __PropertyOffset_231;

		// Token: 0x04017125 RID: 94501
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04017126 RID: 94502
		internal static int __PropertyOffset_232;

		// Token: 0x04017127 RID: 94503
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04017128 RID: 94504
		internal static int __PropertyOffset_233;

		// Token: 0x04017129 RID: 94505
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x0401712A RID: 94506
		internal static int __PropertyOffset_234;

		// Token: 0x0401712B RID: 94507
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401712C RID: 94508
		internal static int __PropertyOffset_235;

		// Token: 0x0401712D RID: 94509
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0401712E RID: 94510
		internal static int __PropertyOffset_236;

		// Token: 0x0401712F RID: 94511
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04017130 RID: 94512
		internal static int __PropertyOffset_237;

		// Token: 0x04017131 RID: 94513
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04017132 RID: 94514
		internal static int __PropertyOffset_238;

		// Token: 0x04017133 RID: 94515
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04017134 RID: 94516
		internal static int __PropertyOffset_239;

		// Token: 0x04017135 RID: 94517
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04017136 RID: 94518
		internal static int __PropertyOffset_240;

		// Token: 0x04017137 RID: 94519
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04017138 RID: 94520
		internal static int __PropertyOffset_241;

		// Token: 0x04017139 RID: 94521
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401713A RID: 94522
		internal static int __PropertyOffset_242;

		// Token: 0x0401713B RID: 94523
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x0401713C RID: 94524
		internal static int __PropertyOffset_243;

		// Token: 0x0401713D RID: 94525
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0401713E RID: 94526
		internal static int __PropertyOffset_244;

		// Token: 0x0401713F RID: 94527
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04017140 RID: 94528
		internal static int __PropertyOffset_245;

		// Token: 0x04017141 RID: 94529
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04017142 RID: 94530
		internal static int __PropertyOffset_246;

		// Token: 0x04017143 RID: 94531
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x04017144 RID: 94532
		internal static int __PropertyOffset_247;

		// Token: 0x04017145 RID: 94533
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04017146 RID: 94534
		internal static int __PropertyOffset_248;

		// Token: 0x04017147 RID: 94535
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04017148 RID: 94536
		internal static int __PropertyOffset_249;

		// Token: 0x04017149 RID: 94537
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x0401714A RID: 94538
		internal static int __PropertyOffset_250;

		// Token: 0x0401714B RID: 94539
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x0401714C RID: 94540
		internal static int __PropertyOffset_251;

		// Token: 0x0401714D RID: 94541
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0401714E RID: 94542
		internal static int __PropertyOffset_252;

		// Token: 0x0401714F RID: 94543
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04017150 RID: 94544
		internal static int __PropertyOffset_253;

		// Token: 0x04017151 RID: 94545
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves;

		// Token: 0x04017152 RID: 94546
		internal static int __PropertyOffset_254;

		// Token: 0x04017153 RID: 94547
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04017154 RID: 94548
		internal static int __PropertyOffset_255;

		// Token: 0x04017155 RID: 94549
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x04017156 RID: 94550
		internal static int __PropertyOffset_256;

		// Token: 0x04017157 RID: 94551
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04017158 RID: 94552
		internal static int __PropertyOffset_257;

		// Token: 0x04017159 RID: 94553
		internal static int __PropertyOffset_258;

		// Token: 0x0401715A RID: 94554
		internal static int __PropertyOffset_259;

		// Token: 0x0401715B RID: 94555
		internal static int __PropertyOffset_260;

		// Token: 0x0401715C RID: 94556
		internal static int __PropertyOffset_261;

		// Token: 0x0401715D RID: 94557
		internal static int __PropertyOffset_262;

		// Token: 0x0401715E RID: 94558
		[Nullable(2)]
		private OnEffectBegin _OnEffectBegin;

		// Token: 0x0401715F RID: 94559
		internal static int __PropertyOffset_263;

		// Token: 0x04017160 RID: 94560
		[Nullable(2)]
		private OnEffectEnd _OnEffectEnd;

		// Token: 0x04017161 RID: 94561
		internal static int __PropertyOffset_264;

		// Token: 0x04017162 RID: 94562
		internal static int __PropertyOffset_265;

		// Token: 0x04017163 RID: 94563
		internal static int __PropertyOffset_266;

		// Token: 0x04017164 RID: 94564
		internal static int __PropertyOffset_267;

		// Token: 0x04017165 RID: 94565
		internal static int __PropertyOffset_268;

		// Token: 0x04017166 RID: 94566
		internal static int __PropertyOffset_269;

		// Token: 0x04017167 RID: 94567
		internal static int __PropertyOffset_270;

		// Token: 0x04017168 RID: 94568
		internal static int __PropertyOffset_271;

		// Token: 0x04017169 RID: 94569
		internal static int __PropertyOffset_272;

		// Token: 0x0401716A RID: 94570
		internal static int __PropertyOffset_273;

		// Token: 0x0401716B RID: 94571
		internal static int __PropertyOffset_274;

		// Token: 0x0401716C RID: 94572
		internal static int __PropertyOffset_275;

		// Token: 0x0401716D RID: 94573
		internal static int __PropertyOffset_276;

		// Token: 0x0401716E RID: 94574
		internal static int __PropertyOffset_277;

		// Token: 0x0401716F RID: 94575
		internal static int __PropertyOffset_278;

		// Token: 0x04017170 RID: 94576
		internal static int __PropertyOffset_279;

		// Token: 0x04017171 RID: 94577
		internal static int __PropertyOffset_280;

		// Token: 0x04017172 RID: 94578
		internal static int __PropertyOffset_281;

		// Token: 0x04017173 RID: 94579
		internal static int __PropertyOffset_282;

		// Token: 0x04017174 RID: 94580
		internal static int __PropertyOffset_283;

		// Token: 0x04017175 RID: 94581
		internal static int __PropertyOffset_284;

		// Token: 0x04017176 RID: 94582
		internal static int __PropertyOffset_285;

		// Token: 0x04017177 RID: 94583
		internal static int __PropertyOffset_286;

		// Token: 0x04017178 RID: 94584
		internal static int __PropertyOffset_287;

		// Token: 0x04017179 RID: 94585
		internal static int __PropertyOffset_288;

		// Token: 0x0401717A RID: 94586
		[Nullable(2)]
		private SPerformanceRoleInfo _PerformanceRoleInfo;

		// Token: 0x0401717B RID: 94587
		internal static int __PropertyOffset_289;

		// Token: 0x0401717C RID: 94588
		internal static int __PropertyOffset_290;

		// Token: 0x0401717D RID: 94589
		internal static int __PropertyOffset_291;

		// Token: 0x0401717E RID: 94590
		internal static int __PropertyOffset_292;

		// Token: 0x0401717F RID: 94591
		internal static int __PropertyOffset_293;

		// Token: 0x04017180 RID: 94592
		internal static int __PropertyOffset_294;

		// Token: 0x04017181 RID: 94593
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EPerformanceRoleState>> _SameStateArray01;

		// Token: 0x04017182 RID: 94594
		internal static int __PropertyOffset_295;

		// Token: 0x04017183 RID: 94595
		internal static int __PropertyOffset_296;

		// Token: 0x04017184 RID: 94596
		internal static int __PropertyOffset_297;

		// Token: 0x04017185 RID: 94597
		internal static int __PropertyOffset_298;

		// Token: 0x04017186 RID: 94598
		internal static int __PropertyOffset_299;

		// Token: 0x04017187 RID: 94599
		private static IntPtr __PostProcessPose_NativeFunctionPtr;

		// Token: 0x04017188 RID: 94600
		private static IntPtr __BasePose_NativeFunctionPtr;

		// Token: 0x04017189 RID: 94601
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401718A RID: 94602
		private static IntPtr __TryForceEnterLoop_NativeFunctionPtr;

		// Token: 0x0401718B RID: 94603
		private static IntPtr __Set_Current_State_NativeFunctionPtr;

		// Token: 0x0401718C RID: 94604
		private static IntPtr __Is_Same_State_NativeFunctionPtr;

		// Token: 0x0401718D RID: 94605
		private static IntPtr __UpdateBlinkInfo_NativeFunctionPtr;

		// Token: 0x0401718E RID: 94606
		private static IntPtr __SkillRotate_NativeFunctionPtr;

		// Token: 0x0401718F RID: 94607
		private static IntPtr __GetIsLooping_NativeFunctionPtr;

		// Token: 0x04017190 RID: 94608
		private static IntPtr __ClearCreateRoleState_NativeFunctionPtr;

		// Token: 0x04017191 RID: 94609
		private static IntPtr __UpdateCreateRoleLocation_NativeFunctionPtr;

		// Token: 0x04017192 RID: 94610
		private static IntPtr __DebugLine_NativeFunctionPtr;

		// Token: 0x04017193 RID: 94611
		private static IntPtr __UpdateLookAtRotation_NativeFunctionPtr;

		// Token: 0x04017194 RID: 94612
		private static IntPtr __UpdatePerfromTime_NativeFunctionPtr;

		// Token: 0x04017195 RID: 94613
		private static IntPtr __SetPerformDelay_NativeFunctionPtr;

		// Token: 0x04017196 RID: 94614
		private static IntPtr __SyncAnimInstance_NativeFunctionPtr;

		// Token: 0x04017197 RID: 94615
		private static IntPtr __UpdateHeadRotator_NativeFunctionPtr;

		// Token: 0x04017198 RID: 94616
		private static IntPtr __GetHeadApha_NativeFunctionPtr;

		// Token: 0x04017199 RID: 94617
		private static IntPtr __SetState_NativeFunctionPtr;

		// Token: 0x0401719A RID: 94618
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7A87E8194AFB02D1564F408592A3BAE7_NativeFunctionPtr;

		// Token: 0x0401719B RID: 94619
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_C60CCB8046FAB6F0C07D51B6B238E4BA_NativeFunctionPtr;

		// Token: 0x0401719C RID: 94620
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_1076956541FC74BF7A3047BF3518CA89_NativeFunctionPtr;

		// Token: 0x0401719D RID: 94621
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_83C90D9A461EF15044A8378A68A6F1E7_NativeFunctionPtr;

		// Token: 0x0401719E RID: 94622
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_0F4FD3374213D4A81960F6A629673AFD_NativeFunctionPtr;

		// Token: 0x0401719F RID: 94623
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_52B4B2CB407931033523C9A14696E52E_NativeFunctionPtr;

		// Token: 0x040171A0 RID: 94624
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_CC733D604E95BE7D9DFA349B1A5B704D_NativeFunctionPtr;

		// Token: 0x040171A1 RID: 94625
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_73AE160147ADB36045B8D9A31DC6AF15_NativeFunctionPtr;

		// Token: 0x040171A2 RID: 94626
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_4AEEB993432FEF9CF04A43AFC809B4FC_NativeFunctionPtr;

		// Token: 0x040171A3 RID: 94627
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_DB55A1AE4A9423A5C47525A74E58BEB7_NativeFunctionPtr;

		// Token: 0x040171A4 RID: 94628
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_A0B917284B95FD2DCEAED29BE0D5525E_NativeFunctionPtr;

		// Token: 0x040171A5 RID: 94629
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2FC853114BF83C19B08BFA8A8E704810_NativeFunctionPtr;

		// Token: 0x040171A6 RID: 94630
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3DADD4CD489C57336548428E9B1B930E_NativeFunctionPtr;

		// Token: 0x040171A7 RID: 94631
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_EF7B72AA40DDC31C385F22A6D2312B57_NativeFunctionPtr;

		// Token: 0x040171A8 RID: 94632
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_5D88DA9A4E6CB0EE56C4F48CD32B926A_NativeFunctionPtr;

		// Token: 0x040171A9 RID: 94633
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D841EEBF4C3AAEE4FA4E22A41EEED9B6_NativeFunctionPtr;

		// Token: 0x040171AA RID: 94634
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_5BC208AA421FCBC084C7A7B465D64E0E_NativeFunctionPtr;

		// Token: 0x040171AB RID: 94635
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_04D89DC14225578F83587E82FEB8F549_NativeFunctionPtr;

		// Token: 0x040171AC RID: 94636
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9B9A0DA843AEF6FCA8E554BC94E139A1_NativeFunctionPtr;

		// Token: 0x040171AD RID: 94637
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9DF1923C49FACD33DB7996B4F88AA35F_NativeFunctionPtr;

		// Token: 0x040171AE RID: 94638
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D4C08C6346453FFFCC8A24BBA1C4CA70_NativeFunctionPtr;

		// Token: 0x040171AF RID: 94639
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_942EF62C4B629FF8B62DE58BA4978BE1_NativeFunctionPtr;

		// Token: 0x040171B0 RID: 94640
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_56C6ACAC4E6FDEC24A16658E3730D394_NativeFunctionPtr;

		// Token: 0x040171B1 RID: 94641
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_30B0B6454BB641F81FA89F95CA2E7A79_NativeFunctionPtr;

		// Token: 0x040171B2 RID: 94642
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_481747314088EF8A503B2B82F47812FC_NativeFunctionPtr;

		// Token: 0x040171B3 RID: 94643
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3FE8E3C646A416753DEE2AA221F25FA6_NativeFunctionPtr;

		// Token: 0x040171B4 RID: 94644
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_24C99C61467D0205D123EC9AF5E06C23_NativeFunctionPtr;

		// Token: 0x040171B5 RID: 94645
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_C03E217044F8BF62D9BDACB1542C2794_NativeFunctionPtr;

		// Token: 0x040171B6 RID: 94646
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_FAF7A35C48527E1EA6A4AAB20EA2F436_NativeFunctionPtr;

		// Token: 0x040171B7 RID: 94647
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3D8EDC0949A468E4288C94B5166CDF2E_NativeFunctionPtr;

		// Token: 0x040171B8 RID: 94648
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_0EDB639B401750A5D4E478B1823AE6FC_NativeFunctionPtr;

		// Token: 0x040171B9 RID: 94649
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7EAEA40441EE79176E27DFA6B4F9FFC5_NativeFunctionPtr;

		// Token: 0x040171BA RID: 94650
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_B16644EE4359CE65D1A16BA8DE0E6A01_NativeFunctionPtr;

		// Token: 0x040171BB RID: 94651
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2A9BD4814CE11A56D9F8B5AD28BCDB54_NativeFunctionPtr;

		// Token: 0x040171BC RID: 94652
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7331EF0C4FCC8260EC07C4B64D3B1D31_NativeFunctionPtr;

		// Token: 0x040171BD RID: 94653
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_B66CA673436FECF98D604D97A2B6C06A_NativeFunctionPtr;

		// Token: 0x040171BE RID: 94654
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_252C9B604DA355A186FC139923D59B56_NativeFunctionPtr;

		// Token: 0x040171BF RID: 94655
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_DEAF3D294066272ACE060C9862C527BD_NativeFunctionPtr;

		// Token: 0x040171C0 RID: 94656
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_FA89A36640926C129757FAA49AF6A81A_NativeFunctionPtr;

		// Token: 0x040171C1 RID: 94657
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3921814044F2A49574F5B4B48102EC67_NativeFunctionPtr;

		// Token: 0x040171C2 RID: 94658
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_87A017DC465C0B783BDB8793686B2399_NativeFunctionPtr;

		// Token: 0x040171C3 RID: 94659
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_81008DE54870516BAB6E5E90973EF5C6_NativeFunctionPtr;

		// Token: 0x040171C4 RID: 94660
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BC16130F44311D0DCB5B3590AECBE007_NativeFunctionPtr;

		// Token: 0x040171C5 RID: 94661
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3BAA36394ACE885F5D49E6B207A23E6C_NativeFunctionPtr;

		// Token: 0x040171C6 RID: 94662
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_7B44C6194963AAC6D793758E0821AA37_NativeFunctionPtr;

		// Token: 0x040171C7 RID: 94663
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3A2D0019410882106E3D5AA8D6F2C19E_NativeFunctionPtr;

		// Token: 0x040171C8 RID: 94664
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_3544AA1645E0CF5C1B631BBF34548087_NativeFunctionPtr;

		// Token: 0x040171C9 RID: 94665
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_A59B1C3E413B4FF0E0A40C8A4E1608A4_NativeFunctionPtr;

		// Token: 0x040171CA RID: 94666
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_9C35D5CF4052F823573EDCA339C5BC95_NativeFunctionPtr;

		// Token: 0x040171CB RID: 94667
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_05AA19EC4BA5688F5DC376ABA8F556E9_NativeFunctionPtr;

		// Token: 0x040171CC RID: 94668
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BB9DF0D54320499047A5319654D5DC2E_NativeFunctionPtr;

		// Token: 0x040171CD RID: 94669
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2C2EF99049E4EE2383BBD8B2786A4567_NativeFunctionPtr;

		// Token: 0x040171CE RID: 94670
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_E88CAB8D428F886DE51EB5A9BE372770_NativeFunctionPtr;

		// Token: 0x040171CF RID: 94671
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_41DFE03F48C3833355C616B28AAF5009_NativeFunctionPtr;

		// Token: 0x040171D0 RID: 94672
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_2964307E48D5040F742A49B35F13F408_NativeFunctionPtr;

		// Token: 0x040171D1 RID: 94673
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_D7436D7443A480F5FAF15A882087F30F_NativeFunctionPtr;

		// Token: 0x040171D2 RID: 94674
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040171D3 RID: 94675
		private static IntPtr __AnimNotify_EnterCommonNotify_NativeFunctionPtr;

		// Token: 0x040171D4 RID: 94676
		private static IntPtr __AnimNotify_LeaveOneLoopAction_NativeFunctionPtr;

		// Token: 0x040171D5 RID: 94677
		private static IntPtr __AnimNotify_EnterPerformIdle_NativeFunctionPtr;

		// Token: 0x040171D6 RID: 94678
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x040171D7 RID: 94679
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_83BA3C6F46EB8037E9C60BB9BDA31608_NativeFunctionPtr;

		// Token: 0x040171D8 RID: 94680
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_F6F9F8DC40D588C967DF2B9A41C97C25_NativeFunctionPtr;

		// Token: 0x040171D9 RID: 94681
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_BC9EBC4944D2E109BC5CAA94C70EB8BC_NativeFunctionPtr;

		// Token: 0x040171DA RID: 94682
		private static IntPtr __AnimNotify_EnterLoop_NativeFunctionPtr;

		// Token: 0x040171DB RID: 94683
		private static IntPtr __AnimNotify_LeaveLoop_NativeFunctionPtr;

		// Token: 0x040171DC RID: 94684
		private static IntPtr __AnimNotify_SkillEndBegin_NativeFunctionPtr;

		// Token: 0x040171DD RID: 94685
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_1B4EAA5848C16EDBEFB00FB24D38B27F_NativeFunctionPtr;

		// Token: 0x040171DE RID: 94686
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_PerformanceRole_AnimGraphNode_TransitionResult_ED21A98E48FA85555EA0D4A7C2A13D4F_NativeFunctionPtr;

		// Token: 0x040171DF RID: 94687
		private static IntPtr __AnimNotify_EnterSkill_NativeFunctionPtr;

		// Token: 0x040171E0 RID: 94688
		private static IntPtr __AnimNotify_EnterAttribute_NativeFunctionPtr;

		// Token: 0x040171E1 RID: 94689
		private static IntPtr __AnimNotify_EnterRoleBreach_NativeFunctionPtr;

		// Token: 0x040171E2 RID: 94690
		private static IntPtr __AnimNotify_EnterResonce_NativeFunctionPtr;

		// Token: 0x040171E3 RID: 94691
		private static IntPtr __AnimNotify_EnterRoleElementStand_NativeFunctionPtr;

		// Token: 0x040171E4 RID: 94692
		private static IntPtr __AnimNotify_EnterRoleElement_NativeFunctionPtr;

		// Token: 0x040171E5 RID: 94693
		private static IntPtr __AnimNotify_EnterChip_NativeFunctionPtr;

		// Token: 0x040171E6 RID: 94694
		private static IntPtr __AnimNotify_EnterWeapon_NativeFunctionPtr;

		// Token: 0x040171E7 RID: 94695
		private static IntPtr __AnimNotify_EnterIdle_NativeFunctionPtr;

		// Token: 0x040171E8 RID: 94696
		private static IntPtr __AnimNotify_EnterDocumentAction_NativeFunctionPtr;

		// Token: 0x040171E9 RID: 94697
		private static IntPtr __AnimNotify_EnterDocumentVoice_NativeFunctionPtr;

		// Token: 0x040171EA RID: 94698
		private static IntPtr __AnimNotify_EnterDocument_NativeFunctionPtr;

		// Token: 0x040171EB RID: 94699
		private static IntPtr __AnimNotify_LeaveCommonNotify_NativeFunctionPtr;

		// Token: 0x040171EC RID: 94700
		private static IntPtr __ExecuteUbergraph_ABP_PerformanceRole_NativeFunctionPtr;

		// Token: 0x0200A241 RID: 41537
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __PostProcessPose_FunctionParams
		{
			// Token: 0x04032FE1 RID: 208865
			[FieldOffset(0)]
			public byte InPose;

			// Token: 0x04032FE2 RID: 208866
			[FieldOffset(24)]
			public byte PostProcessPose;
		}

		// Token: 0x0200A242 RID: 41538
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __BasePose_FunctionParams
		{
			// Token: 0x04032FE3 RID: 208867
			[FieldOffset(0)]
			public byte BasePose;
		}

		// Token: 0x0200A243 RID: 41539
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032FE4 RID: 208868
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A244 RID: 41540
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __Set_Current_State_FunctionParams
		{
			// Token: 0x04032FE5 RID: 208869
			[FieldOffset(0)]
			public TEnumAsByte<EPerformanceRoleState> state;
		}

		// Token: 0x0200A245 RID: 41541
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 6)]
		protected ref struct __Is_Same_State_FunctionParams
		{
			// Token: 0x04032FE6 RID: 208870
			[FieldOffset(0)]
			public TEnumAsByte<EPerformanceRoleState> NewState;

			// Token: 0x04032FE7 RID: 208871
			[FieldOffset(1)]
			public TEnumAsByte<EPerformanceRoleState> StateInternal;

			// Token: 0x04032FE8 RID: 208872
			[FieldOffset(2)]
			public bool __Result;
		}

		// Token: 0x0200A246 RID: 41542
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __GetIsLooping_FunctionParams
		{
			// Token: 0x04032FE9 RID: 208873
			[FieldOffset(0)]
			public bool isLooping;
		}

		// Token: 0x0200A247 RID: 41543
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __DebugLine_FunctionParams
		{
			// Token: 0x04032FEA RID: 208874
			[FieldOffset(0)]
			public FVector LineStart;

			// Token: 0x04032FEB RID: 208875
			[FieldOffset(12)]
			public FVector LineEnd;

			// Token: 0x04032FEC RID: 208876
			[FieldOffset(24)]
			public FLinearColor LineColor;
		}

		// Token: 0x0200A248 RID: 41544
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetPerformDelay_FunctionParams
		{
			// Token: 0x04032FED RID: 208877
			[FieldOffset(0)]
			public float PerformTime;
		}

		// Token: 0x0200A249 RID: 41545
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __SyncAnimInstance_FunctionParams
		{
			// Token: 0x04032FEE RID: 208878
			[FieldOffset(0)]
			public IntPtr SourceAnimInstance;
		}

		// Token: 0x0200A24A RID: 41546
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetHeadApha_FunctionParams
		{
			// Token: 0x04032FEF RID: 208879
			[FieldOffset(0)]
			public float __Result;
		}

		// Token: 0x0200A24B RID: 41547
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 14)]
		protected ref struct __SetState_FunctionParams
		{
			// Token: 0x04032FF0 RID: 208880
			[FieldOffset(0)]
			public TEnumAsByte<EPerformanceRoleState> State;

			// Token: 0x04032FF1 RID: 208881
			[FieldOffset(1)]
			public bool reLoop;

			// Token: 0x04032FF2 RID: 208882
			[FieldOffset(2)]
			public bool reLoopFromLoopToStart;

			// Token: 0x04032FF3 RID: 208883
			[FieldOffset(3)]
			public bool WaitLaseStateEnd;
		}

		// Token: 0x0200A24C RID: 41548
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032FF4 RID: 208884
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A24D RID: 41549
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		protected ref struct __ExecuteUbergraph_ABP_PerformanceRole_FunctionParams
		{
			// Token: 0x04032FF5 RID: 208885
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
