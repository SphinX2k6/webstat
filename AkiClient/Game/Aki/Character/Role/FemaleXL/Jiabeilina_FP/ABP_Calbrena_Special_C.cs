using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.FemaleXL.Jiabeilina_FP
{
	// Token: 0x02003FEF RID: 16367
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/FemaleXL/Jiabeilina_FP/ABP_Calbrena_Special.ABP_Calbrena_Special_C")]
	[UnrealStructLayout(44368, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 44364)]
	public class ABP_Calbrena_Special_C : UKuroAnimInstanceRole, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602939C RID: 168860 RVA: 0x00A2543B File Offset: 0x00A2363B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Calbrena_Special_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/FemaleXL/Jiabeilina_FP/ABP_Calbrena_Special.ABP_Calbrena_Special_C");
			}
			return ABP_Calbrena_Special_C._ClassPtr;
		}

		// Token: 0x0602939D RID: 168861 RVA: 0x00A25460 File Offset: 0x00A23660
		public ABP_Calbrena_Special_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Calbrena_Special_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602939E RID: 168862 RVA: 0x00A25488 File Offset: 0x00A23688
		public ABP_Calbrena_Special_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Calbrena_Special_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170065AC RID: 26028
		// (get) Token: 0x0602939F RID: 168863 RVA: 0x00A254BC File Offset: 0x00A236BC
		// (set) Token: 0x060293A0 RID: 168864 RVA: 0x00A254F5 File Offset: 0x00A236F5
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065AD RID: 26029
		// (get) Token: 0x060293A1 RID: 168865 RVA: 0x00A25518 File Offset: 0x00A23718
		// (set) Token: 0x060293A2 RID: 168866 RVA: 0x00A25551 File Offset: 0x00A23751
		public FAnimNode_Root AnimGraphNode_Root_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_5) == null)
				{
					result = (this._AnimGraphNode_Root_5 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065AE RID: 26030
		// (get) Token: 0x060293A3 RID: 168867 RVA: 0x00A25574 File Offset: 0x00A23774
		// (set) Token: 0x060293A4 RID: 168868 RVA: 0x00A255AD File Offset: 0x00A237AD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_33) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_33 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065AF RID: 26031
		// (get) Token: 0x060293A5 RID: 168869 RVA: 0x00A255D0 File Offset: 0x00A237D0
		// (set) Token: 0x060293A6 RID: 168870 RVA: 0x00A25609 File Offset: 0x00A23809
		public FAnimNode_Root AnimGraphNode_Root_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_4) == null)
				{
					result = (this._AnimGraphNode_Root_4 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B0 RID: 26032
		// (get) Token: 0x060293A7 RID: 168871 RVA: 0x00A2562C File Offset: 0x00A2382C
		// (set) Token: 0x060293A8 RID: 168872 RVA: 0x00A25665 File Offset: 0x00A23865
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_32) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_32 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B1 RID: 26033
		// (get) Token: 0x060293A9 RID: 168873 RVA: 0x00A25688 File Offset: 0x00A23888
		// (set) Token: 0x060293AA RID: 168874 RVA: 0x00A256C1 File Offset: 0x00A238C1
		public FAnimNode_StateResult AnimGraphNode_StateResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_51) == null)
				{
					result = (this._AnimGraphNode_StateResult_51 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B2 RID: 26034
		// (get) Token: 0x060293AB RID: 168875 RVA: 0x00A256E4 File Offset: 0x00A238E4
		// (set) Token: 0x060293AC RID: 168876 RVA: 0x00A2571D File Offset: 0x00A2391D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_11) == null)
				{
					result = (this._AnimGraphNode_StateMachine_11 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B3 RID: 26035
		// (get) Token: 0x060293AD RID: 168877 RVA: 0x00A25740 File Offset: 0x00A23940
		// (set) Token: 0x060293AE RID: 168878 RVA: 0x00A25779 File Offset: 0x00A23979
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B4 RID: 26036
		// (get) Token: 0x060293AF RID: 168879 RVA: 0x00A2579C File Offset: 0x00A2399C
		// (set) Token: 0x060293B0 RID: 168880 RVA: 0x00A257D5 File Offset: 0x00A239D5
		public FAnimNode_Root AnimGraphNode_Root_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_3) == null)
				{
					result = (this._AnimGraphNode_Root_3 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B5 RID: 26037
		// (get) Token: 0x060293B1 RID: 168881 RVA: 0x00A257F8 File Offset: 0x00A239F8
		// (set) Token: 0x060293B2 RID: 168882 RVA: 0x00A25831 File Offset: 0x00A23A31
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_9) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_9 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B6 RID: 26038
		// (get) Token: 0x060293B3 RID: 168883 RVA: 0x00A25854 File Offset: 0x00A23A54
		// (set) Token: 0x060293B4 RID: 168884 RVA: 0x00A2588D File Offset: 0x00A23A8D
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_8) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_8 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B7 RID: 26039
		// (get) Token: 0x060293B5 RID: 168885 RVA: 0x00A258B0 File Offset: 0x00A23AB0
		// (set) Token: 0x060293B6 RID: 168886 RVA: 0x00A258E9 File Offset: 0x00A23AE9
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_7) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_7 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B8 RID: 26040
		// (get) Token: 0x060293B7 RID: 168887 RVA: 0x00A2590C File Offset: 0x00A23B0C
		// (set) Token: 0x060293B8 RID: 168888 RVA: 0x00A25945 File Offset: 0x00A23B45
		public FAnimNode_AdditiveBoneBlend AnimGraphNode_AdditiveBoneBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_AdditiveBoneBlend result;
				if ((result = this._AnimGraphNode_AdditiveBoneBlend) == null)
				{
					result = (this._AnimGraphNode_AdditiveBoneBlend = new FAnimNode_AdditiveBoneBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_AdditiveBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065B9 RID: 26041
		// (get) Token: 0x060293B9 RID: 168889 RVA: 0x00A25968 File Offset: 0x00A23B68
		// (set) Token: 0x060293BA RID: 168890 RVA: 0x00A259A1 File Offset: 0x00A23BA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_122
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_122) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_122 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065BA RID: 26042
		// (get) Token: 0x060293BB RID: 168891 RVA: 0x00A259C4 File Offset: 0x00A23BC4
		// (set) Token: 0x060293BC RID: 168892 RVA: 0x00A259FD File Offset: 0x00A23BFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_121
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_121) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_121 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065BB RID: 26043
		// (get) Token: 0x060293BD RID: 168893 RVA: 0x00A25A20 File Offset: 0x00A23C20
		// (set) Token: 0x060293BE RID: 168894 RVA: 0x00A25A59 File Offset: 0x00A23C59
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_36) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_36 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065BC RID: 26044
		// (get) Token: 0x060293BF RID: 168895 RVA: 0x00A25A7C File Offset: 0x00A23C7C
		// (set) Token: 0x060293C0 RID: 168896 RVA: 0x00A25AB5 File Offset: 0x00A23CB5
		public FAnimNode_StateResult AnimGraphNode_StateResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_50) == null)
				{
					result = (this._AnimGraphNode_StateResult_50 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065BD RID: 26045
		// (get) Token: 0x060293C1 RID: 168897 RVA: 0x00A25AD8 File Offset: 0x00A23CD8
		// (set) Token: 0x060293C2 RID: 168898 RVA: 0x00A25B11 File Offset: 0x00A23D11
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_35) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_35 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065BE RID: 26046
		// (get) Token: 0x060293C3 RID: 168899 RVA: 0x00A25B34 File Offset: 0x00A23D34
		// (set) Token: 0x060293C4 RID: 168900 RVA: 0x00A25B6D File Offset: 0x00A23D6D
		public FAnimNode_StateResult AnimGraphNode_StateResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_49) == null)
				{
					result = (this._AnimGraphNode_StateResult_49 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065BF RID: 26047
		// (get) Token: 0x060293C5 RID: 168901 RVA: 0x00A25B90 File Offset: 0x00A23D90
		// (set) Token: 0x060293C6 RID: 168902 RVA: 0x00A25BC9 File Offset: 0x00A23DC9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_10) == null)
				{
					result = (this._AnimGraphNode_StateMachine_10 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C0 RID: 26048
		// (get) Token: 0x060293C7 RID: 168903 RVA: 0x00A25BEC File Offset: 0x00A23DEC
		// (set) Token: 0x060293C8 RID: 168904 RVA: 0x00A25C25 File Offset: 0x00A23E25
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_13) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_13 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C1 RID: 26049
		// (get) Token: 0x060293C9 RID: 168905 RVA: 0x00A25C48 File Offset: 0x00A23E48
		// (set) Token: 0x060293CA RID: 168906 RVA: 0x00A25C81 File Offset: 0x00A23E81
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_12) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_12 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C2 RID: 26050
		// (get) Token: 0x060293CB RID: 168907 RVA: 0x00A25CA4 File Offset: 0x00A23EA4
		// (set) Token: 0x060293CC RID: 168908 RVA: 0x00A25CDD File Offset: 0x00A23EDD
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_11) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_11 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C3 RID: 26051
		// (get) Token: 0x060293CD RID: 168909 RVA: 0x00A25D00 File Offset: 0x00A23F00
		// (set) Token: 0x060293CE RID: 168910 RVA: 0x00A25D39 File Offset: 0x00A23F39
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_34) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_34 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C4 RID: 26052
		// (get) Token: 0x060293CF RID: 168911 RVA: 0x00A25D5C File Offset: 0x00A23F5C
		// (set) Token: 0x060293D0 RID: 168912 RVA: 0x00A25D95 File Offset: 0x00A23F95
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_33) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_33 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C5 RID: 26053
		// (get) Token: 0x060293D1 RID: 168913 RVA: 0x00A25DB8 File Offset: 0x00A23FB8
		// (set) Token: 0x060293D2 RID: 168914 RVA: 0x00A25DF1 File Offset: 0x00A23FF1
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_32) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_32 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C6 RID: 26054
		// (get) Token: 0x060293D3 RID: 168915 RVA: 0x00A25E14 File Offset: 0x00A24014
		// (set) Token: 0x060293D4 RID: 168916 RVA: 0x00A25E4D File Offset: 0x00A2404D
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_10) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_10 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C7 RID: 26055
		// (get) Token: 0x060293D5 RID: 168917 RVA: 0x00A25E70 File Offset: 0x00A24070
		// (set) Token: 0x060293D6 RID: 168918 RVA: 0x00A25EA9 File Offset: 0x00A240A9
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C8 RID: 26056
		// (get) Token: 0x060293D7 RID: 168919 RVA: 0x00A25ECC File Offset: 0x00A240CC
		// (set) Token: 0x060293D8 RID: 168920 RVA: 0x00A25F05 File Offset: 0x00A24105
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_120
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_120) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_120 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065C9 RID: 26057
		// (get) Token: 0x060293D9 RID: 168921 RVA: 0x00A25F28 File Offset: 0x00A24128
		// (set) Token: 0x060293DA RID: 168922 RVA: 0x00A25F61 File Offset: 0x00A24161
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_119
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_119) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_119 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065CA RID: 26058
		// (get) Token: 0x060293DB RID: 168923 RVA: 0x00A25F84 File Offset: 0x00A24184
		// (set) Token: 0x060293DC RID: 168924 RVA: 0x00A25FBD File Offset: 0x00A241BD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_118
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_118) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_118 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065CB RID: 26059
		// (get) Token: 0x060293DD RID: 168925 RVA: 0x00A25FE0 File Offset: 0x00A241E0
		// (set) Token: 0x060293DE RID: 168926 RVA: 0x00A26019 File Offset: 0x00A24219
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_117
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_117) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_117 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065CC RID: 26060
		// (get) Token: 0x060293DF RID: 168927 RVA: 0x00A2603C File Offset: 0x00A2423C
		// (set) Token: 0x060293E0 RID: 168928 RVA: 0x00A26075 File Offset: 0x00A24275
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_116
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_116) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_116 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065CD RID: 26061
		// (get) Token: 0x060293E1 RID: 168929 RVA: 0x00A26098 File Offset: 0x00A24298
		// (set) Token: 0x060293E2 RID: 168930 RVA: 0x00A260D1 File Offset: 0x00A242D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_115
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_115) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_115 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065CE RID: 26062
		// (get) Token: 0x060293E3 RID: 168931 RVA: 0x00A260F4 File Offset: 0x00A242F4
		// (set) Token: 0x060293E4 RID: 168932 RVA: 0x00A2612D File Offset: 0x00A2432D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_114
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_114) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_114 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065CF RID: 26063
		// (get) Token: 0x060293E5 RID: 168933 RVA: 0x00A26150 File Offset: 0x00A24350
		// (set) Token: 0x060293E6 RID: 168934 RVA: 0x00A26189 File Offset: 0x00A24389
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_31) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_31 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D0 RID: 26064
		// (get) Token: 0x060293E7 RID: 168935 RVA: 0x00A261AC File Offset: 0x00A243AC
		// (set) Token: 0x060293E8 RID: 168936 RVA: 0x00A261E5 File Offset: 0x00A243E5
		public FAnimNode_StateResult AnimGraphNode_StateResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_48) == null)
				{
					result = (this._AnimGraphNode_StateResult_48 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D1 RID: 26065
		// (get) Token: 0x060293E9 RID: 168937 RVA: 0x00A26208 File Offset: 0x00A24408
		// (set) Token: 0x060293EA RID: 168938 RVA: 0x00A26241 File Offset: 0x00A24441
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_113
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_113) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_113 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D2 RID: 26066
		// (get) Token: 0x060293EB RID: 168939 RVA: 0x00A26264 File Offset: 0x00A24464
		// (set) Token: 0x060293EC RID: 168940 RVA: 0x00A2629D File Offset: 0x00A2449D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_112
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_112) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_112 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D3 RID: 26067
		// (get) Token: 0x060293ED RID: 168941 RVA: 0x00A262C0 File Offset: 0x00A244C0
		// (set) Token: 0x060293EE RID: 168942 RVA: 0x00A262F9 File Offset: 0x00A244F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_111
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_111) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_111 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D4 RID: 26068
		// (get) Token: 0x060293EF RID: 168943 RVA: 0x00A2631C File Offset: 0x00A2451C
		// (set) Token: 0x060293F0 RID: 168944 RVA: 0x00A26355 File Offset: 0x00A24555
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_110
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_110) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_110 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D5 RID: 26069
		// (get) Token: 0x060293F1 RID: 168945 RVA: 0x00A26378 File Offset: 0x00A24578
		// (set) Token: 0x060293F2 RID: 168946 RVA: 0x00A263B1 File Offset: 0x00A245B1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_30) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_30 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D6 RID: 26070
		// (get) Token: 0x060293F3 RID: 168947 RVA: 0x00A263D4 File Offset: 0x00A245D4
		// (set) Token: 0x060293F4 RID: 168948 RVA: 0x00A2640D File Offset: 0x00A2460D
		public FAnimNode_StateResult AnimGraphNode_StateResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_47) == null)
				{
					result = (this._AnimGraphNode_StateResult_47 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D7 RID: 26071
		// (get) Token: 0x060293F5 RID: 168949 RVA: 0x00A26430 File Offset: 0x00A24630
		// (set) Token: 0x060293F6 RID: 168950 RVA: 0x00A26469 File Offset: 0x00A24669
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_29) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_29 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D8 RID: 26072
		// (get) Token: 0x060293F7 RID: 168951 RVA: 0x00A2648C File Offset: 0x00A2468C
		// (set) Token: 0x060293F8 RID: 168952 RVA: 0x00A264C5 File Offset: 0x00A246C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_46) == null)
				{
					result = (this._AnimGraphNode_StateResult_46 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065D9 RID: 26073
		// (get) Token: 0x060293F9 RID: 168953 RVA: 0x00A264E8 File Offset: 0x00A246E8
		// (set) Token: 0x060293FA RID: 168954 RVA: 0x00A26521 File Offset: 0x00A24721
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_28) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_28 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065DA RID: 26074
		// (get) Token: 0x060293FB RID: 168955 RVA: 0x00A26544 File Offset: 0x00A24744
		// (set) Token: 0x060293FC RID: 168956 RVA: 0x00A2657D File Offset: 0x00A2477D
		public FAnimNode_StateResult AnimGraphNode_StateResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_45) == null)
				{
					result = (this._AnimGraphNode_StateResult_45 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065DB RID: 26075
		// (get) Token: 0x060293FD RID: 168957 RVA: 0x00A265A0 File Offset: 0x00A247A0
		// (set) Token: 0x060293FE RID: 168958 RVA: 0x00A265D9 File Offset: 0x00A247D9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_27) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_27 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065DC RID: 26076
		// (get) Token: 0x060293FF RID: 168959 RVA: 0x00A265FC File Offset: 0x00A247FC
		// (set) Token: 0x06029400 RID: 168960 RVA: 0x00A26635 File Offset: 0x00A24835
		public FAnimNode_StateResult AnimGraphNode_StateResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_44) == null)
				{
					result = (this._AnimGraphNode_StateResult_44 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065DD RID: 26077
		// (get) Token: 0x06029401 RID: 168961 RVA: 0x00A26658 File Offset: 0x00A24858
		// (set) Token: 0x06029402 RID: 168962 RVA: 0x00A26691 File Offset: 0x00A24891
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_9) == null)
				{
					result = (this._AnimGraphNode_StateMachine_9 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065DE RID: 26078
		// (get) Token: 0x06029403 RID: 168963 RVA: 0x00A266B4 File Offset: 0x00A248B4
		// (set) Token: 0x06029404 RID: 168964 RVA: 0x00A266ED File Offset: 0x00A248ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_43) == null)
				{
					result = (this._AnimGraphNode_StateResult_43 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065DF RID: 26079
		// (get) Token: 0x06029405 RID: 168965 RVA: 0x00A26710 File Offset: 0x00A24910
		// (set) Token: 0x06029406 RID: 168966 RVA: 0x00A26749 File Offset: 0x00A24949
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_109
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_109) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_109 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E0 RID: 26080
		// (get) Token: 0x06029407 RID: 168967 RVA: 0x00A2676C File Offset: 0x00A2496C
		// (set) Token: 0x06029408 RID: 168968 RVA: 0x00A267A5 File Offset: 0x00A249A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_108
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_108) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_108 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E1 RID: 26081
		// (get) Token: 0x06029409 RID: 168969 RVA: 0x00A267C8 File Offset: 0x00A249C8
		// (set) Token: 0x0602940A RID: 168970 RVA: 0x00A26801 File Offset: 0x00A24A01
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_107
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_107) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_107 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E2 RID: 26082
		// (get) Token: 0x0602940B RID: 168971 RVA: 0x00A26824 File Offset: 0x00A24A24
		// (set) Token: 0x0602940C RID: 168972 RVA: 0x00A2685D File Offset: 0x00A24A5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_106
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_106) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_106 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E3 RID: 26083
		// (get) Token: 0x0602940D RID: 168973 RVA: 0x00A26880 File Offset: 0x00A24A80
		// (set) Token: 0x0602940E RID: 168974 RVA: 0x00A268B9 File Offset: 0x00A24AB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_105
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_105) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_105 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E4 RID: 26084
		// (get) Token: 0x0602940F RID: 168975 RVA: 0x00A268DC File Offset: 0x00A24ADC
		// (set) Token: 0x06029410 RID: 168976 RVA: 0x00A26915 File Offset: 0x00A24B15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_104
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_104) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_104 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E5 RID: 26085
		// (get) Token: 0x06029411 RID: 168977 RVA: 0x00A26938 File Offset: 0x00A24B38
		// (set) Token: 0x06029412 RID: 168978 RVA: 0x00A26971 File Offset: 0x00A24B71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_103
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_103) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_103 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E6 RID: 26086
		// (get) Token: 0x06029413 RID: 168979 RVA: 0x00A26994 File Offset: 0x00A24B94
		// (set) Token: 0x06029414 RID: 168980 RVA: 0x00A269CD File Offset: 0x00A24BCD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_102
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_102) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_102 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E7 RID: 26087
		// (get) Token: 0x06029415 RID: 168981 RVA: 0x00A269F0 File Offset: 0x00A24BF0
		// (set) Token: 0x06029416 RID: 168982 RVA: 0x00A26A29 File Offset: 0x00A24C29
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_101
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_101) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_101 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E8 RID: 26088
		// (get) Token: 0x06029417 RID: 168983 RVA: 0x00A26A4C File Offset: 0x00A24C4C
		// (set) Token: 0x06029418 RID: 168984 RVA: 0x00A26A85 File Offset: 0x00A24C85
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_100
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_100) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_100 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065E9 RID: 26089
		// (get) Token: 0x06029419 RID: 168985 RVA: 0x00A26AA8 File Offset: 0x00A24CA8
		// (set) Token: 0x0602941A RID: 168986 RVA: 0x00A26AE1 File Offset: 0x00A24CE1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_99
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_99) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_99 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065EA RID: 26090
		// (get) Token: 0x0602941B RID: 168987 RVA: 0x00A26B04 File Offset: 0x00A24D04
		// (set) Token: 0x0602941C RID: 168988 RVA: 0x00A26B3D File Offset: 0x00A24D3D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_98
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_98) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_98 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065EB RID: 26091
		// (get) Token: 0x0602941D RID: 168989 RVA: 0x00A26B60 File Offset: 0x00A24D60
		// (set) Token: 0x0602941E RID: 168990 RVA: 0x00A26B99 File Offset: 0x00A24D99
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_97
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_97) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_97 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065EC RID: 26092
		// (get) Token: 0x0602941F RID: 168991 RVA: 0x00A26BBC File Offset: 0x00A24DBC
		// (set) Token: 0x06029420 RID: 168992 RVA: 0x00A26BF5 File Offset: 0x00A24DF5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_96
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_96) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_96 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065ED RID: 26093
		// (get) Token: 0x06029421 RID: 168993 RVA: 0x00A26C18 File Offset: 0x00A24E18
		// (set) Token: 0x06029422 RID: 168994 RVA: 0x00A26C51 File Offset: 0x00A24E51
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_95
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_95) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_95 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065EE RID: 26094
		// (get) Token: 0x06029423 RID: 168995 RVA: 0x00A26C74 File Offset: 0x00A24E74
		// (set) Token: 0x06029424 RID: 168996 RVA: 0x00A26CAD File Offset: 0x00A24EAD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_94
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_94) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_94 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065EF RID: 26095
		// (get) Token: 0x06029425 RID: 168997 RVA: 0x00A26CD0 File Offset: 0x00A24ED0
		// (set) Token: 0x06029426 RID: 168998 RVA: 0x00A26D09 File Offset: 0x00A24F09
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_93
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_93) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_93 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F0 RID: 26096
		// (get) Token: 0x06029427 RID: 168999 RVA: 0x00A26D2C File Offset: 0x00A24F2C
		// (set) Token: 0x06029428 RID: 169000 RVA: 0x00A26D65 File Offset: 0x00A24F65
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_92
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_92) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_92 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F1 RID: 26097
		// (get) Token: 0x06029429 RID: 169001 RVA: 0x00A26D88 File Offset: 0x00A24F88
		// (set) Token: 0x0602942A RID: 169002 RVA: 0x00A26DC1 File Offset: 0x00A24FC1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_91
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_91) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_91 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F2 RID: 26098
		// (get) Token: 0x0602942B RID: 169003 RVA: 0x00A26DE4 File Offset: 0x00A24FE4
		// (set) Token: 0x0602942C RID: 169004 RVA: 0x00A26E1D File Offset: 0x00A2501D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_90
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_90) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_90 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F3 RID: 26099
		// (get) Token: 0x0602942D RID: 169005 RVA: 0x00A26E40 File Offset: 0x00A25040
		// (set) Token: 0x0602942E RID: 169006 RVA: 0x00A26E79 File Offset: 0x00A25079
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_89
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_89) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_89 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F4 RID: 26100
		// (get) Token: 0x0602942F RID: 169007 RVA: 0x00A26E9C File Offset: 0x00A2509C
		// (set) Token: 0x06029430 RID: 169008 RVA: 0x00A26ED5 File Offset: 0x00A250D5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_26) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_26 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F5 RID: 26101
		// (get) Token: 0x06029431 RID: 169009 RVA: 0x00A26EF8 File Offset: 0x00A250F8
		// (set) Token: 0x06029432 RID: 169010 RVA: 0x00A26F31 File Offset: 0x00A25131
		public FAnimNode_StateResult AnimGraphNode_StateResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_42) == null)
				{
					result = (this._AnimGraphNode_StateResult_42 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F6 RID: 26102
		// (get) Token: 0x06029433 RID: 169011 RVA: 0x00A26F54 File Offset: 0x00A25154
		// (set) Token: 0x06029434 RID: 169012 RVA: 0x00A26F8D File Offset: 0x00A2518D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_25) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_25 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F7 RID: 26103
		// (get) Token: 0x06029435 RID: 169013 RVA: 0x00A26FB0 File Offset: 0x00A251B0
		// (set) Token: 0x06029436 RID: 169014 RVA: 0x00A26FE9 File Offset: 0x00A251E9
		public FAnimNode_StateResult AnimGraphNode_StateResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_41) == null)
				{
					result = (this._AnimGraphNode_StateResult_41 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F8 RID: 26104
		// (get) Token: 0x06029437 RID: 169015 RVA: 0x00A2700C File Offset: 0x00A2520C
		// (set) Token: 0x06029438 RID: 169016 RVA: 0x00A27045 File Offset: 0x00A25245
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_13) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_13 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065F9 RID: 26105
		// (get) Token: 0x06029439 RID: 169017 RVA: 0x00A27068 File Offset: 0x00A25268
		// (set) Token: 0x0602943A RID: 169018 RVA: 0x00A270A1 File Offset: 0x00A252A1
		public FAnimNode_StateResult AnimGraphNode_StateResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_40) == null)
				{
					result = (this._AnimGraphNode_StateResult_40 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065FA RID: 26106
		// (get) Token: 0x0602943B RID: 169019 RVA: 0x00A270C4 File Offset: 0x00A252C4
		// (set) Token: 0x0602943C RID: 169020 RVA: 0x00A270FD File Offset: 0x00A252FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_88
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_88) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_88 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065FB RID: 26107
		// (get) Token: 0x0602943D RID: 169021 RVA: 0x00A27120 File Offset: 0x00A25320
		// (set) Token: 0x0602943E RID: 169022 RVA: 0x00A27159 File Offset: 0x00A25359
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_87
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_87) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_87 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065FC RID: 26108
		// (get) Token: 0x0602943F RID: 169023 RVA: 0x00A2717C File Offset: 0x00A2537C
		// (set) Token: 0x06029440 RID: 169024 RVA: 0x00A271B5 File Offset: 0x00A253B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_86
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_86) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_86 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065FD RID: 26109
		// (get) Token: 0x06029441 RID: 169025 RVA: 0x00A271D8 File Offset: 0x00A253D8
		// (set) Token: 0x06029442 RID: 169026 RVA: 0x00A27211 File Offset: 0x00A25411
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_85
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_85) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_85 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065FE RID: 26110
		// (get) Token: 0x06029443 RID: 169027 RVA: 0x00A27234 File Offset: 0x00A25434
		// (set) Token: 0x06029444 RID: 169028 RVA: 0x00A2726D File Offset: 0x00A2546D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_84
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_84) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_84 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170065FF RID: 26111
		// (get) Token: 0x06029445 RID: 169029 RVA: 0x00A27290 File Offset: 0x00A25490
		// (set) Token: 0x06029446 RID: 169030 RVA: 0x00A272C9 File Offset: 0x00A254C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_83
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_83) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_83 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006600 RID: 26112
		// (get) Token: 0x06029447 RID: 169031 RVA: 0x00A272EC File Offset: 0x00A254EC
		// (set) Token: 0x06029448 RID: 169032 RVA: 0x00A27325 File Offset: 0x00A25525
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_24) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_24 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006601 RID: 26113
		// (get) Token: 0x06029449 RID: 169033 RVA: 0x00A27348 File Offset: 0x00A25548
		// (set) Token: 0x0602944A RID: 169034 RVA: 0x00A27381 File Offset: 0x00A25581
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_12) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_12 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006602 RID: 26114
		// (get) Token: 0x0602944B RID: 169035 RVA: 0x00A273A4 File Offset: 0x00A255A4
		// (set) Token: 0x0602944C RID: 169036 RVA: 0x00A273DD File Offset: 0x00A255DD
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_5) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_5 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006603 RID: 26115
		// (get) Token: 0x0602944D RID: 169037 RVA: 0x00A27400 File Offset: 0x00A25600
		// (set) Token: 0x0602944E RID: 169038 RVA: 0x00A27439 File Offset: 0x00A25639
		public FAnimNode_StateResult AnimGraphNode_StateResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_39) == null)
				{
					result = (this._AnimGraphNode_StateResult_39 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006604 RID: 26116
		// (get) Token: 0x0602944F RID: 169039 RVA: 0x00A2745C File Offset: 0x00A2565C
		// (set) Token: 0x06029450 RID: 169040 RVA: 0x00A27495 File Offset: 0x00A25695
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_11) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_11 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006605 RID: 26117
		// (get) Token: 0x06029451 RID: 169041 RVA: 0x00A274B8 File Offset: 0x00A256B8
		// (set) Token: 0x06029452 RID: 169042 RVA: 0x00A274F1 File Offset: 0x00A256F1
		public FAnimNode_StateResult AnimGraphNode_StateResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_38) == null)
				{
					result = (this._AnimGraphNode_StateResult_38 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006606 RID: 26118
		// (get) Token: 0x06029453 RID: 169043 RVA: 0x00A27514 File Offset: 0x00A25714
		// (set) Token: 0x06029454 RID: 169044 RVA: 0x00A2754D File Offset: 0x00A2574D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_23) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_23 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006607 RID: 26119
		// (get) Token: 0x06029455 RID: 169045 RVA: 0x00A27570 File Offset: 0x00A25770
		// (set) Token: 0x06029456 RID: 169046 RVA: 0x00A275A9 File Offset: 0x00A257A9
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_10) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_10 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006608 RID: 26120
		// (get) Token: 0x06029457 RID: 169047 RVA: 0x00A275CC File Offset: 0x00A257CC
		// (set) Token: 0x06029458 RID: 169048 RVA: 0x00A27605 File Offset: 0x00A25805
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_4) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_4 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006609 RID: 26121
		// (get) Token: 0x06029459 RID: 169049 RVA: 0x00A27628 File Offset: 0x00A25828
		// (set) Token: 0x0602945A RID: 169050 RVA: 0x00A27661 File Offset: 0x00A25861
		public FAnimNode_StateResult AnimGraphNode_StateResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_37) == null)
				{
					result = (this._AnimGraphNode_StateResult_37 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700660A RID: 26122
		// (get) Token: 0x0602945B RID: 169051 RVA: 0x00A27684 File Offset: 0x00A25884
		// (set) Token: 0x0602945C RID: 169052 RVA: 0x00A276BD File Offset: 0x00A258BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_36) == null)
				{
					result = (this._AnimGraphNode_StateResult_36 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700660B RID: 26123
		// (get) Token: 0x0602945D RID: 169053 RVA: 0x00A276E0 File Offset: 0x00A258E0
		// (set) Token: 0x0602945E RID: 169054 RVA: 0x00A27719 File Offset: 0x00A25919
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_8) == null)
				{
					result = (this._AnimGraphNode_StateMachine_8 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700660C RID: 26124
		// (get) Token: 0x0602945F RID: 169055 RVA: 0x00A2773C File Offset: 0x00A2593C
		// (set) Token: 0x06029460 RID: 169056 RVA: 0x00A27775 File Offset: 0x00A25975
		public FAnimNode_StateResult AnimGraphNode_StateResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_35) == null)
				{
					result = (this._AnimGraphNode_StateResult_35 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700660D RID: 26125
		// (get) Token: 0x06029461 RID: 169057 RVA: 0x00A27798 File Offset: 0x00A25998
		// (set) Token: 0x06029462 RID: 169058 RVA: 0x00A277D1 File Offset: 0x00A259D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_82
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_82) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_82 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700660E RID: 26126
		// (get) Token: 0x06029463 RID: 169059 RVA: 0x00A277F4 File Offset: 0x00A259F4
		// (set) Token: 0x06029464 RID: 169060 RVA: 0x00A2782D File Offset: 0x00A25A2D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_22) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_22 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700660F RID: 26127
		// (get) Token: 0x06029465 RID: 169061 RVA: 0x00A27850 File Offset: 0x00A25A50
		// (set) Token: 0x06029466 RID: 169062 RVA: 0x00A27889 File Offset: 0x00A25A89
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_3) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_3 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006610 RID: 26128
		// (get) Token: 0x06029467 RID: 169063 RVA: 0x00A278AC File Offset: 0x00A25AAC
		// (set) Token: 0x06029468 RID: 169064 RVA: 0x00A278E5 File Offset: 0x00A25AE5
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_9) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_9 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006611 RID: 26129
		// (get) Token: 0x06029469 RID: 169065 RVA: 0x00A27908 File Offset: 0x00A25B08
		// (set) Token: 0x0602946A RID: 169066 RVA: 0x00A27941 File Offset: 0x00A25B41
		public FAnimNode_StateResult AnimGraphNode_StateResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_34) == null)
				{
					result = (this._AnimGraphNode_StateResult_34 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006612 RID: 26130
		// (get) Token: 0x0602946B RID: 169067 RVA: 0x00A27964 File Offset: 0x00A25B64
		// (set) Token: 0x0602946C RID: 169068 RVA: 0x00A2799D File Offset: 0x00A25B9D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_81
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_81) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_81 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006613 RID: 26131
		// (get) Token: 0x0602946D RID: 169069 RVA: 0x00A279C0 File Offset: 0x00A25BC0
		// (set) Token: 0x0602946E RID: 169070 RVA: 0x00A279F9 File Offset: 0x00A25BF9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_80
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_80) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_80 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006614 RID: 26132
		// (get) Token: 0x0602946F RID: 169071 RVA: 0x00A27A1C File Offset: 0x00A25C1C
		// (set) Token: 0x06029470 RID: 169072 RVA: 0x00A27A55 File Offset: 0x00A25C55
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_79
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_79) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_79 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006615 RID: 26133
		// (get) Token: 0x06029471 RID: 169073 RVA: 0x00A27A78 File Offset: 0x00A25C78
		// (set) Token: 0x06029472 RID: 169074 RVA: 0x00A27AB1 File Offset: 0x00A25CB1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_78
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_78) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_78 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006616 RID: 26134
		// (get) Token: 0x06029473 RID: 169075 RVA: 0x00A27AD4 File Offset: 0x00A25CD4
		// (set) Token: 0x06029474 RID: 169076 RVA: 0x00A27B0D File Offset: 0x00A25D0D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_77
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_77) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_77 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006617 RID: 26135
		// (get) Token: 0x06029475 RID: 169077 RVA: 0x00A27B30 File Offset: 0x00A25D30
		// (set) Token: 0x06029476 RID: 169078 RVA: 0x00A27B69 File Offset: 0x00A25D69
		public FAnimNode_StateResult AnimGraphNode_StateResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_33) == null)
				{
					result = (this._AnimGraphNode_StateResult_33 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006618 RID: 26136
		// (get) Token: 0x06029477 RID: 169079 RVA: 0x00A27B8C File Offset: 0x00A25D8C
		// (set) Token: 0x06029478 RID: 169080 RVA: 0x00A27BC5 File Offset: 0x00A25DC5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_21) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_21 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006619 RID: 26137
		// (get) Token: 0x06029479 RID: 169081 RVA: 0x00A27BE8 File Offset: 0x00A25DE8
		// (set) Token: 0x0602947A RID: 169082 RVA: 0x00A27C21 File Offset: 0x00A25E21
		public FAnimNode_StateResult AnimGraphNode_StateResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_32) == null)
				{
					result = (this._AnimGraphNode_StateResult_32 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700661A RID: 26138
		// (get) Token: 0x0602947B RID: 169083 RVA: 0x00A27C44 File Offset: 0x00A25E44
		// (set) Token: 0x0602947C RID: 169084 RVA: 0x00A27C7D File Offset: 0x00A25E7D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_8) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_8 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700661B RID: 26139
		// (get) Token: 0x0602947D RID: 169085 RVA: 0x00A27CA0 File Offset: 0x00A25EA0
		// (set) Token: 0x0602947E RID: 169086 RVA: 0x00A27CD9 File Offset: 0x00A25ED9
		public FAnimNode_StateResult AnimGraphNode_StateResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_31) == null)
				{
					result = (this._AnimGraphNode_StateResult_31 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700661C RID: 26140
		// (get) Token: 0x0602947F RID: 169087 RVA: 0x00A27CFC File Offset: 0x00A25EFC
		// (set) Token: 0x06029480 RID: 169088 RVA: 0x00A27D35 File Offset: 0x00A25F35
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_7) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_7 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700661D RID: 26141
		// (get) Token: 0x06029481 RID: 169089 RVA: 0x00A27D58 File Offset: 0x00A25F58
		// (set) Token: 0x06029482 RID: 169090 RVA: 0x00A27D91 File Offset: 0x00A25F91
		public FAnimNode_StateResult AnimGraphNode_StateResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_30) == null)
				{
					result = (this._AnimGraphNode_StateResult_30 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700661E RID: 26142
		// (get) Token: 0x06029483 RID: 169091 RVA: 0x00A27DB4 File Offset: 0x00A25FB4
		// (set) Token: 0x06029484 RID: 169092 RVA: 0x00A27DED File Offset: 0x00A25FED
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_20) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_20 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700661F RID: 26143
		// (get) Token: 0x06029485 RID: 169093 RVA: 0x00A27E10 File Offset: 0x00A26010
		// (set) Token: 0x06029486 RID: 169094 RVA: 0x00A27E49 File Offset: 0x00A26049
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_115, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_115, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006620 RID: 26144
		// (get) Token: 0x06029487 RID: 169095 RVA: 0x00A27E6C File Offset: 0x00A2606C
		// (set) Token: 0x06029488 RID: 169096 RVA: 0x00A27EA5 File Offset: 0x00A260A5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_7) == null)
				{
					result = (this._AnimGraphNode_StateMachine_7 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_116, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_116, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006621 RID: 26145
		// (get) Token: 0x06029489 RID: 169097 RVA: 0x00A27EC8 File Offset: 0x00A260C8
		// (set) Token: 0x0602948A RID: 169098 RVA: 0x00A27F01 File Offset: 0x00A26101
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_117, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_117, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006622 RID: 26146
		// (get) Token: 0x0602948B RID: 169099 RVA: 0x00A27F24 File Offset: 0x00A26124
		// (set) Token: 0x0602948C RID: 169100 RVA: 0x00A27F5D File Offset: 0x00A2615D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_31) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_31 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_118, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006623 RID: 26147
		// (get) Token: 0x0602948D RID: 169101 RVA: 0x00A27F80 File Offset: 0x00A26180
		// (set) Token: 0x0602948E RID: 169102 RVA: 0x00A27FB9 File Offset: 0x00A261B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_119, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_119, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006624 RID: 26148
		// (get) Token: 0x0602948F RID: 169103 RVA: 0x00A27FDC File Offset: 0x00A261DC
		// (set) Token: 0x06029490 RID: 169104 RVA: 0x00A28015 File Offset: 0x00A26215
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_6) == null)
				{
					result = (this._AnimGraphNode_StateMachine_6 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_120, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_120, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006625 RID: 26149
		// (get) Token: 0x06029491 RID: 169105 RVA: 0x00A28038 File Offset: 0x00A26238
		// (set) Token: 0x06029492 RID: 169106 RVA: 0x00A28071 File Offset: 0x00A26271
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_121, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_121, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006626 RID: 26150
		// (get) Token: 0x06029493 RID: 169107 RVA: 0x00A28094 File Offset: 0x00A26294
		// (set) Token: 0x06029494 RID: 169108 RVA: 0x00A280CD File Offset: 0x00A262CD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_5) == null)
				{
					result = (this._AnimGraphNode_StateMachine_5 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_122, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_122, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006627 RID: 26151
		// (get) Token: 0x06029495 RID: 169109 RVA: 0x00A280F0 File Offset: 0x00A262F0
		// (set) Token: 0x06029496 RID: 169110 RVA: 0x00A28129 File Offset: 0x00A26329
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_19) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_19 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_123, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_123, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006628 RID: 26152
		// (get) Token: 0x06029497 RID: 169111 RVA: 0x00A2814C File Offset: 0x00A2634C
		// (set) Token: 0x06029498 RID: 169112 RVA: 0x00A28185 File Offset: 0x00A26385
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_4) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_4 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_124, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_124, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006629 RID: 26153
		// (get) Token: 0x06029499 RID: 169113 RVA: 0x00A281A8 File Offset: 0x00A263A8
		// (set) Token: 0x0602949A RID: 169114 RVA: 0x00A281E1 File Offset: 0x00A263E1
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_2) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_2 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_125, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_125, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700662A RID: 26154
		// (get) Token: 0x0602949B RID: 169115 RVA: 0x00A28204 File Offset: 0x00A26404
		// (set) Token: 0x0602949C RID: 169116 RVA: 0x00A2823D File Offset: 0x00A2643D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_6) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_6 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_126, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_126, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700662B RID: 26155
		// (get) Token: 0x0602949D RID: 169117 RVA: 0x00A28260 File Offset: 0x00A26460
		// (set) Token: 0x0602949E RID: 169118 RVA: 0x00A28299 File Offset: 0x00A26499
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_5) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_5 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_127, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_127, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700662C RID: 26156
		// (get) Token: 0x0602949F RID: 169119 RVA: 0x00A282BC File Offset: 0x00A264BC
		// (set) Token: 0x060294A0 RID: 169120 RVA: 0x00A282F5 File Offset: 0x00A264F5
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_4) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_4 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_128, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700662D RID: 26157
		// (get) Token: 0x060294A1 RID: 169121 RVA: 0x00A28318 File Offset: 0x00A26518
		// (set) Token: 0x060294A2 RID: 169122 RVA: 0x00A28351 File Offset: 0x00A26551
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_3) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_3 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_129, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_129, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700662E RID: 26158
		// (get) Token: 0x060294A3 RID: 169123 RVA: 0x00A28374 File Offset: 0x00A26574
		// (set) Token: 0x060294A4 RID: 169124 RVA: 0x00A283AD File Offset: 0x00A265AD
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_2) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_2 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_130, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_130, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700662F RID: 26159
		// (get) Token: 0x060294A5 RID: 169125 RVA: 0x00A283D0 File Offset: 0x00A265D0
		// (set) Token: 0x060294A6 RID: 169126 RVA: 0x00A28409 File Offset: 0x00A26609
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_131, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_131, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006630 RID: 26160
		// (get) Token: 0x060294A7 RID: 169127 RVA: 0x00A2842C File Offset: 0x00A2662C
		// (set) Token: 0x060294A8 RID: 169128 RVA: 0x00A28465 File Offset: 0x00A26665
		public FAnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TwoWayBlend result;
				if ((result = this._AnimGraphNode_TwoWayBlend_1) == null)
				{
					result = (this._AnimGraphNode_TwoWayBlend_1 = new FAnimNode_TwoWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_132, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TwoWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_132, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006631 RID: 26161
		// (get) Token: 0x060294A9 RID: 169129 RVA: 0x00A28488 File Offset: 0x00A26688
		// (set) Token: 0x060294AA RID: 169130 RVA: 0x00A284C1 File Offset: 0x00A266C1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_18) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_18 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_133, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_133, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006632 RID: 26162
		// (get) Token: 0x060294AB RID: 169131 RVA: 0x00A284E4 File Offset: 0x00A266E4
		// (set) Token: 0x060294AC RID: 169132 RVA: 0x00A2851D File Offset: 0x00A2671D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_134, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_134, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006633 RID: 26163
		// (get) Token: 0x060294AD RID: 169133 RVA: 0x00A28540 File Offset: 0x00A26740
		// (set) Token: 0x060294AE RID: 169134 RVA: 0x00A28579 File Offset: 0x00A26779
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_135, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_135, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006634 RID: 26164
		// (get) Token: 0x060294AF RID: 169135 RVA: 0x00A2859C File Offset: 0x00A2679C
		// (set) Token: 0x060294B0 RID: 169136 RVA: 0x00A285D5 File Offset: 0x00A267D5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_136, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_136, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006635 RID: 26165
		// (get) Token: 0x060294B1 RID: 169137 RVA: 0x00A285F8 File Offset: 0x00A267F8
		// (set) Token: 0x060294B2 RID: 169138 RVA: 0x00A28631 File Offset: 0x00A26831
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_76
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_76) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_76 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_137, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_137, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006636 RID: 26166
		// (get) Token: 0x060294B3 RID: 169139 RVA: 0x00A28654 File Offset: 0x00A26854
		// (set) Token: 0x060294B4 RID: 169140 RVA: 0x00A2868D File Offset: 0x00A2688D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_75
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_75) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_75 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_138, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_138, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006637 RID: 26167
		// (get) Token: 0x060294B5 RID: 169141 RVA: 0x00A286B0 File Offset: 0x00A268B0
		// (set) Token: 0x060294B6 RID: 169142 RVA: 0x00A286E9 File Offset: 0x00A268E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_74
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_74) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_74 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_139, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_139, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006638 RID: 26168
		// (get) Token: 0x060294B7 RID: 169143 RVA: 0x00A2870C File Offset: 0x00A2690C
		// (set) Token: 0x060294B8 RID: 169144 RVA: 0x00A28745 File Offset: 0x00A26945
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_73
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_73) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_73 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_140, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_140, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006639 RID: 26169
		// (get) Token: 0x060294B9 RID: 169145 RVA: 0x00A28768 File Offset: 0x00A26968
		// (set) Token: 0x060294BA RID: 169146 RVA: 0x00A287A1 File Offset: 0x00A269A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_72
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_72) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_72 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_141, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_141, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700663A RID: 26170
		// (get) Token: 0x060294BB RID: 169147 RVA: 0x00A287C4 File Offset: 0x00A269C4
		// (set) Token: 0x060294BC RID: 169148 RVA: 0x00A287FD File Offset: 0x00A269FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_71
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_71) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_71 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_142, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_142, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700663B RID: 26171
		// (get) Token: 0x060294BD RID: 169149 RVA: 0x00A28820 File Offset: 0x00A26A20
		// (set) Token: 0x060294BE RID: 169150 RVA: 0x00A28859 File Offset: 0x00A26A59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_70
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_70) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_70 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_143, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_143, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700663C RID: 26172
		// (get) Token: 0x060294BF RID: 169151 RVA: 0x00A2887C File Offset: 0x00A26A7C
		// (set) Token: 0x060294C0 RID: 169152 RVA: 0x00A288B5 File Offset: 0x00A26AB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_69
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_69) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_69 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_144, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_144, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700663D RID: 26173
		// (get) Token: 0x060294C1 RID: 169153 RVA: 0x00A288D8 File Offset: 0x00A26AD8
		// (set) Token: 0x060294C2 RID: 169154 RVA: 0x00A28911 File Offset: 0x00A26B11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_68
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_68) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_68 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_145, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_145, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700663E RID: 26174
		// (get) Token: 0x060294C3 RID: 169155 RVA: 0x00A28934 File Offset: 0x00A26B34
		// (set) Token: 0x060294C4 RID: 169156 RVA: 0x00A2896D File Offset: 0x00A26B6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_67
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_67) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_67 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_146, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_146, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700663F RID: 26175
		// (get) Token: 0x060294C5 RID: 169157 RVA: 0x00A28990 File Offset: 0x00A26B90
		// (set) Token: 0x060294C6 RID: 169158 RVA: 0x00A289C9 File Offset: 0x00A26BC9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_66
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_66) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_66 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_147, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_147, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006640 RID: 26176
		// (get) Token: 0x060294C7 RID: 169159 RVA: 0x00A289EC File Offset: 0x00A26BEC
		// (set) Token: 0x060294C8 RID: 169160 RVA: 0x00A28A25 File Offset: 0x00A26C25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_65
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_65) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_65 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_148, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_148, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006641 RID: 26177
		// (get) Token: 0x060294C9 RID: 169161 RVA: 0x00A28A48 File Offset: 0x00A26C48
		// (set) Token: 0x060294CA RID: 169162 RVA: 0x00A28A81 File Offset: 0x00A26C81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_64
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_64) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_64 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_149, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_149, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006642 RID: 26178
		// (get) Token: 0x060294CB RID: 169163 RVA: 0x00A28AA4 File Offset: 0x00A26CA4
		// (set) Token: 0x060294CC RID: 169164 RVA: 0x00A28ADD File Offset: 0x00A26CDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_63
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_63) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_63 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_150, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_150, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006643 RID: 26179
		// (get) Token: 0x060294CD RID: 169165 RVA: 0x00A28B00 File Offset: 0x00A26D00
		// (set) Token: 0x060294CE RID: 169166 RVA: 0x00A28B39 File Offset: 0x00A26D39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_62
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_62) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_62 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_151, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_151, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006644 RID: 26180
		// (get) Token: 0x060294CF RID: 169167 RVA: 0x00A28B5C File Offset: 0x00A26D5C
		// (set) Token: 0x060294D0 RID: 169168 RVA: 0x00A28B95 File Offset: 0x00A26D95
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_61
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_61) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_61 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_152, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_152, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006645 RID: 26181
		// (get) Token: 0x060294D1 RID: 169169 RVA: 0x00A28BB8 File Offset: 0x00A26DB8
		// (set) Token: 0x060294D2 RID: 169170 RVA: 0x00A28BF1 File Offset: 0x00A26DF1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_60
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_60) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_60 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_153, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_153, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006646 RID: 26182
		// (get) Token: 0x060294D3 RID: 169171 RVA: 0x00A28C14 File Offset: 0x00A26E14
		// (set) Token: 0x060294D4 RID: 169172 RVA: 0x00A28C4D File Offset: 0x00A26E4D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_59
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_59) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_59 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_154, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_154, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006647 RID: 26183
		// (get) Token: 0x060294D5 RID: 169173 RVA: 0x00A28C70 File Offset: 0x00A26E70
		// (set) Token: 0x060294D6 RID: 169174 RVA: 0x00A28CA9 File Offset: 0x00A26EA9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_58
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_58) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_58 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_155, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_155, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006648 RID: 26184
		// (get) Token: 0x060294D7 RID: 169175 RVA: 0x00A28CCC File Offset: 0x00A26ECC
		// (set) Token: 0x060294D8 RID: 169176 RVA: 0x00A28D05 File Offset: 0x00A26F05
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_57
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_57) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_57 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_156, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_156, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006649 RID: 26185
		// (get) Token: 0x060294D9 RID: 169177 RVA: 0x00A28D28 File Offset: 0x00A26F28
		// (set) Token: 0x060294DA RID: 169178 RVA: 0x00A28D61 File Offset: 0x00A26F61
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_56
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_56) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_56 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_157, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_157, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700664A RID: 26186
		// (get) Token: 0x060294DB RID: 169179 RVA: 0x00A28D84 File Offset: 0x00A26F84
		// (set) Token: 0x060294DC RID: 169180 RVA: 0x00A28DBD File Offset: 0x00A26FBD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_55
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_55) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_55 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_158, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_158, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700664B RID: 26187
		// (get) Token: 0x060294DD RID: 169181 RVA: 0x00A28DE0 File Offset: 0x00A26FE0
		// (set) Token: 0x060294DE RID: 169182 RVA: 0x00A28E19 File Offset: 0x00A27019
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_54
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_54) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_54 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_159, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_159, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700664C RID: 26188
		// (get) Token: 0x060294DF RID: 169183 RVA: 0x00A28E3C File Offset: 0x00A2703C
		// (set) Token: 0x060294E0 RID: 169184 RVA: 0x00A28E75 File Offset: 0x00A27075
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_53) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_53 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_160, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_160, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700664D RID: 26189
		// (get) Token: 0x060294E1 RID: 169185 RVA: 0x00A28E98 File Offset: 0x00A27098
		// (set) Token: 0x060294E2 RID: 169186 RVA: 0x00A28ED1 File Offset: 0x00A270D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_52) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_52 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_161, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_161, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700664E RID: 26190
		// (get) Token: 0x060294E3 RID: 169187 RVA: 0x00A28EF4 File Offset: 0x00A270F4
		// (set) Token: 0x060294E4 RID: 169188 RVA: 0x00A28F2D File Offset: 0x00A2712D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_51) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_51 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_162, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_162, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700664F RID: 26191
		// (get) Token: 0x060294E5 RID: 169189 RVA: 0x00A28F50 File Offset: 0x00A27150
		// (set) Token: 0x060294E6 RID: 169190 RVA: 0x00A28F89 File Offset: 0x00A27189
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_50) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_50 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_163, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_163, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006650 RID: 26192
		// (get) Token: 0x060294E7 RID: 169191 RVA: 0x00A28FAC File Offset: 0x00A271AC
		// (set) Token: 0x060294E8 RID: 169192 RVA: 0x00A28FE5 File Offset: 0x00A271E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_49) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_49 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_164, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_164, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006651 RID: 26193
		// (get) Token: 0x060294E9 RID: 169193 RVA: 0x00A29008 File Offset: 0x00A27208
		// (set) Token: 0x060294EA RID: 169194 RVA: 0x00A29041 File Offset: 0x00A27241
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_48) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_48 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_165, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_165, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006652 RID: 26194
		// (get) Token: 0x060294EB RID: 169195 RVA: 0x00A29064 File Offset: 0x00A27264
		// (set) Token: 0x060294EC RID: 169196 RVA: 0x00A2909D File Offset: 0x00A2729D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_47) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_47 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_166, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_166, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006653 RID: 26195
		// (get) Token: 0x060294ED RID: 169197 RVA: 0x00A290C0 File Offset: 0x00A272C0
		// (set) Token: 0x060294EE RID: 169198 RVA: 0x00A290F9 File Offset: 0x00A272F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_46) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_46 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_167, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_167, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006654 RID: 26196
		// (get) Token: 0x060294EF RID: 169199 RVA: 0x00A2911C File Offset: 0x00A2731C
		// (set) Token: 0x060294F0 RID: 169200 RVA: 0x00A29155 File Offset: 0x00A27355
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_45) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_45 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_168, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_168, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006655 RID: 26197
		// (get) Token: 0x060294F1 RID: 169201 RVA: 0x00A29178 File Offset: 0x00A27378
		// (set) Token: 0x060294F2 RID: 169202 RVA: 0x00A291B1 File Offset: 0x00A273B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_44) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_44 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_169, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_169, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006656 RID: 26198
		// (get) Token: 0x060294F3 RID: 169203 RVA: 0x00A291D4 File Offset: 0x00A273D4
		// (set) Token: 0x060294F4 RID: 169204 RVA: 0x00A2920D File Offset: 0x00A2740D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_17) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_17 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_170, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_170, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006657 RID: 26199
		// (get) Token: 0x060294F5 RID: 169205 RVA: 0x00A29230 File Offset: 0x00A27430
		// (set) Token: 0x060294F6 RID: 169206 RVA: 0x00A29269 File Offset: 0x00A27469
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_171, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_171, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006658 RID: 26200
		// (get) Token: 0x060294F7 RID: 169207 RVA: 0x00A2928C File Offset: 0x00A2748C
		// (set) Token: 0x060294F8 RID: 169208 RVA: 0x00A292C5 File Offset: 0x00A274C5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_16) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_16 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_172, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_172, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006659 RID: 26201
		// (get) Token: 0x060294F9 RID: 169209 RVA: 0x00A292E8 File Offset: 0x00A274E8
		// (set) Token: 0x060294FA RID: 169210 RVA: 0x00A29321 File Offset: 0x00A27521
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_173, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_173, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700665A RID: 26202
		// (get) Token: 0x060294FB RID: 169211 RVA: 0x00A29344 File Offset: 0x00A27544
		// (set) Token: 0x060294FC RID: 169212 RVA: 0x00A2937D File Offset: 0x00A2757D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_43) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_43 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_174, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_174, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700665B RID: 26203
		// (get) Token: 0x060294FD RID: 169213 RVA: 0x00A293A0 File Offset: 0x00A275A0
		// (set) Token: 0x060294FE RID: 169214 RVA: 0x00A293D9 File Offset: 0x00A275D9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_15) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_15 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_175, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_175, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700665C RID: 26204
		// (get) Token: 0x060294FF RID: 169215 RVA: 0x00A293FC File Offset: 0x00A275FC
		// (set) Token: 0x06029500 RID: 169216 RVA: 0x00A29435 File Offset: 0x00A27635
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_176, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_176, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700665D RID: 26205
		// (get) Token: 0x06029501 RID: 169217 RVA: 0x00A29458 File Offset: 0x00A27658
		// (set) Token: 0x06029502 RID: 169218 RVA: 0x00A29491 File Offset: 0x00A27691
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_42) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_42 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_177, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_177, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700665E RID: 26206
		// (get) Token: 0x06029503 RID: 169219 RVA: 0x00A294B4 File Offset: 0x00A276B4
		// (set) Token: 0x06029504 RID: 169220 RVA: 0x00A294ED File Offset: 0x00A276ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_41) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_41 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_178, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_178, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700665F RID: 26207
		// (get) Token: 0x06029505 RID: 169221 RVA: 0x00A29510 File Offset: 0x00A27710
		// (set) Token: 0x06029506 RID: 169222 RVA: 0x00A29549 File Offset: 0x00A27749
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_40) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_40 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_179, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_179, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006660 RID: 26208
		// (get) Token: 0x06029507 RID: 169223 RVA: 0x00A2956C File Offset: 0x00A2776C
		// (set) Token: 0x06029508 RID: 169224 RVA: 0x00A295A5 File Offset: 0x00A277A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_39) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_39 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_180, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_180, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006661 RID: 26209
		// (get) Token: 0x06029509 RID: 169225 RVA: 0x00A295C8 File Offset: 0x00A277C8
		// (set) Token: 0x0602950A RID: 169226 RVA: 0x00A29601 File Offset: 0x00A27801
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_38) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_38 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_181, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_181, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006662 RID: 26210
		// (get) Token: 0x0602950B RID: 169227 RVA: 0x00A29624 File Offset: 0x00A27824
		// (set) Token: 0x0602950C RID: 169228 RVA: 0x00A2965D File Offset: 0x00A2785D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_37) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_37 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_182, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_182, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006663 RID: 26211
		// (get) Token: 0x0602950D RID: 169229 RVA: 0x00A29680 File Offset: 0x00A27880
		// (set) Token: 0x0602950E RID: 169230 RVA: 0x00A296B9 File Offset: 0x00A278B9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_36) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_36 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_183, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_183, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006664 RID: 26212
		// (get) Token: 0x0602950F RID: 169231 RVA: 0x00A296DC File Offset: 0x00A278DC
		// (set) Token: 0x06029510 RID: 169232 RVA: 0x00A29715 File Offset: 0x00A27915
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_35) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_35 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_184, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_184, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006665 RID: 26213
		// (get) Token: 0x06029511 RID: 169233 RVA: 0x00A29738 File Offset: 0x00A27938
		// (set) Token: 0x06029512 RID: 169234 RVA: 0x00A29771 File Offset: 0x00A27971
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_34) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_34 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_185, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_185, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006666 RID: 26214
		// (get) Token: 0x06029513 RID: 169235 RVA: 0x00A29794 File Offset: 0x00A27994
		// (set) Token: 0x06029514 RID: 169236 RVA: 0x00A297CD File Offset: 0x00A279CD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_186, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_186, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006667 RID: 26215
		// (get) Token: 0x06029515 RID: 169237 RVA: 0x00A297F0 File Offset: 0x00A279F0
		// (set) Token: 0x06029516 RID: 169238 RVA: 0x00A29829 File Offset: 0x00A27A29
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_187, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_187, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006668 RID: 26216
		// (get) Token: 0x06029517 RID: 169239 RVA: 0x00A2984C File Offset: 0x00A27A4C
		// (set) Token: 0x06029518 RID: 169240 RVA: 0x00A29885 File Offset: 0x00A27A85
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_188, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_188, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006669 RID: 26217
		// (get) Token: 0x06029519 RID: 169241 RVA: 0x00A298A8 File Offset: 0x00A27AA8
		// (set) Token: 0x0602951A RID: 169242 RVA: 0x00A298E1 File Offset: 0x00A27AE1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_189, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_189, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700666A RID: 26218
		// (get) Token: 0x0602951B RID: 169243 RVA: 0x00A29904 File Offset: 0x00A27B04
		// (set) Token: 0x0602951C RID: 169244 RVA: 0x00A2993D File Offset: 0x00A27B3D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_190, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_190, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700666B RID: 26219
		// (get) Token: 0x0602951D RID: 169245 RVA: 0x00A29960 File Offset: 0x00A27B60
		// (set) Token: 0x0602951E RID: 169246 RVA: 0x00A29999 File Offset: 0x00A27B99
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_191, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_191, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700666C RID: 26220
		// (get) Token: 0x0602951F RID: 169247 RVA: 0x00A299BC File Offset: 0x00A27BBC
		// (set) Token: 0x06029520 RID: 169248 RVA: 0x00A299F5 File Offset: 0x00A27BF5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_192, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_192, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700666D RID: 26221
		// (get) Token: 0x06029521 RID: 169249 RVA: 0x00A29A18 File Offset: 0x00A27C18
		// (set) Token: 0x06029522 RID: 169250 RVA: 0x00A29A51 File Offset: 0x00A27C51
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_193, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_193, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700666E RID: 26222
		// (get) Token: 0x06029523 RID: 169251 RVA: 0x00A29A74 File Offset: 0x00A27C74
		// (set) Token: 0x06029524 RID: 169252 RVA: 0x00A29AAD File Offset: 0x00A27CAD
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_194, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_194, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700666F RID: 26223
		// (get) Token: 0x06029525 RID: 169253 RVA: 0x00A29AD0 File Offset: 0x00A27CD0
		// (set) Token: 0x06029526 RID: 169254 RVA: 0x00A29B09 File Offset: 0x00A27D09
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_195, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_195, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006670 RID: 26224
		// (get) Token: 0x06029527 RID: 169255 RVA: 0x00A29B2C File Offset: 0x00A27D2C
		// (set) Token: 0x06029528 RID: 169256 RVA: 0x00A29B65 File Offset: 0x00A27D65
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_196, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_196, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006671 RID: 26225
		// (get) Token: 0x06029529 RID: 169257 RVA: 0x00A29B88 File Offset: 0x00A27D88
		// (set) Token: 0x0602952A RID: 169258 RVA: 0x00A29BC1 File Offset: 0x00A27DC1
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_197, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_197, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006672 RID: 26226
		// (get) Token: 0x0602952B RID: 169259 RVA: 0x00A29BE4 File Offset: 0x00A27DE4
		// (set) Token: 0x0602952C RID: 169260 RVA: 0x00A29C1D File Offset: 0x00A27E1D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_198, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_198, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006673 RID: 26227
		// (get) Token: 0x0602952D RID: 169261 RVA: 0x00A29C40 File Offset: 0x00A27E40
		// (set) Token: 0x0602952E RID: 169262 RVA: 0x00A29C79 File Offset: 0x00A27E79
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_199, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_199, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006674 RID: 26228
		// (get) Token: 0x0602952F RID: 169263 RVA: 0x00A29C9C File Offset: 0x00A27E9C
		// (set) Token: 0x06029530 RID: 169264 RVA: 0x00A29CD5 File Offset: 0x00A27ED5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_200, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_200, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006675 RID: 26229
		// (get) Token: 0x06029531 RID: 169265 RVA: 0x00A29CF8 File Offset: 0x00A27EF8
		// (set) Token: 0x06029532 RID: 169266 RVA: 0x00A29D31 File Offset: 0x00A27F31
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_201, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_201, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006676 RID: 26230
		// (get) Token: 0x06029533 RID: 169267 RVA: 0x00A29D54 File Offset: 0x00A27F54
		// (set) Token: 0x06029534 RID: 169268 RVA: 0x00A29D8D File Offset: 0x00A27F8D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_202, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_202, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006677 RID: 26231
		// (get) Token: 0x06029535 RID: 169269 RVA: 0x00A29DB0 File Offset: 0x00A27FB0
		// (set) Token: 0x06029536 RID: 169270 RVA: 0x00A29DE9 File Offset: 0x00A27FE9
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_203, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_203, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006678 RID: 26232
		// (get) Token: 0x06029537 RID: 169271 RVA: 0x00A29E0C File Offset: 0x00A2800C
		// (set) Token: 0x06029538 RID: 169272 RVA: 0x00A29E45 File Offset: 0x00A28045
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_204, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_204, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006679 RID: 26233
		// (get) Token: 0x06029539 RID: 169273 RVA: 0x00A29E68 File Offset: 0x00A28068
		// (set) Token: 0x0602953A RID: 169274 RVA: 0x00A29EA1 File Offset: 0x00A280A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_205, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_205, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700667A RID: 26234
		// (get) Token: 0x0602953B RID: 169275 RVA: 0x00A29EC4 File Offset: 0x00A280C4
		// (set) Token: 0x0602953C RID: 169276 RVA: 0x00A29EFD File Offset: 0x00A280FD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_206, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_206, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700667B RID: 26235
		// (get) Token: 0x0602953D RID: 169277 RVA: 0x00A29F20 File Offset: 0x00A28120
		// (set) Token: 0x0602953E RID: 169278 RVA: 0x00A29F59 File Offset: 0x00A28159
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_207, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_207, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700667C RID: 26236
		// (get) Token: 0x0602953F RID: 169279 RVA: 0x00A29F7C File Offset: 0x00A2817C
		// (set) Token: 0x06029540 RID: 169280 RVA: 0x00A29FB5 File Offset: 0x00A281B5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_208, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_208, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700667D RID: 26237
		// (get) Token: 0x06029541 RID: 169281 RVA: 0x00A29FD8 File Offset: 0x00A281D8
		// (set) Token: 0x06029542 RID: 169282 RVA: 0x00A2A011 File Offset: 0x00A28211
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_209, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_209, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700667E RID: 26238
		// (get) Token: 0x06029543 RID: 169283 RVA: 0x00A2A034 File Offset: 0x00A28234
		// (set) Token: 0x06029544 RID: 169284 RVA: 0x00A2A06D File Offset: 0x00A2826D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_210, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_210, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700667F RID: 26239
		// (get) Token: 0x06029545 RID: 169285 RVA: 0x00A2A090 File Offset: 0x00A28290
		// (set) Token: 0x06029546 RID: 169286 RVA: 0x00A2A0C9 File Offset: 0x00A282C9
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_211, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_211, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006680 RID: 26240
		// (get) Token: 0x06029547 RID: 169287 RVA: 0x00A2A0EC File Offset: 0x00A282EC
		// (set) Token: 0x06029548 RID: 169288 RVA: 0x00A2A125 File Offset: 0x00A28325
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_212, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_212, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006681 RID: 26241
		// (get) Token: 0x06029549 RID: 169289 RVA: 0x00A2A148 File Offset: 0x00A28348
		// (set) Token: 0x0602954A RID: 169290 RVA: 0x00A2A181 File Offset: 0x00A28381
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_213, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_213, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006682 RID: 26242
		// (get) Token: 0x0602954B RID: 169291 RVA: 0x00A2A1A4 File Offset: 0x00A283A4
		// (set) Token: 0x0602954C RID: 169292 RVA: 0x00A2A1DD File Offset: 0x00A283DD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_214, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_214, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006683 RID: 26243
		// (get) Token: 0x0602954D RID: 169293 RVA: 0x00A2A200 File Offset: 0x00A28400
		// (set) Token: 0x0602954E RID: 169294 RVA: 0x00A2A239 File Offset: 0x00A28439
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_215, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_215, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006684 RID: 26244
		// (get) Token: 0x0602954F RID: 169295 RVA: 0x00A2A25C File Offset: 0x00A2845C
		// (set) Token: 0x06029550 RID: 169296 RVA: 0x00A2A295 File Offset: 0x00A28495
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_216, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_216, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006685 RID: 26245
		// (get) Token: 0x06029551 RID: 169297 RVA: 0x00A2A2B8 File Offset: 0x00A284B8
		// (set) Token: 0x06029552 RID: 169298 RVA: 0x00A2A2F1 File Offset: 0x00A284F1
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_217, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_217, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006686 RID: 26246
		// (get) Token: 0x06029553 RID: 169299 RVA: 0x00A2A314 File Offset: 0x00A28514
		// (set) Token: 0x06029554 RID: 169300 RVA: 0x00A2A34D File Offset: 0x00A2854D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_218, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_218, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006687 RID: 26247
		// (get) Token: 0x06029555 RID: 169301 RVA: 0x00A2A370 File Offset: 0x00A28570
		// (set) Token: 0x06029556 RID: 169302 RVA: 0x00A2A3A9 File Offset: 0x00A285A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_219, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_219, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006688 RID: 26248
		// (get) Token: 0x06029557 RID: 169303 RVA: 0x00A2A3CC File Offset: 0x00A285CC
		// (set) Token: 0x06029558 RID: 169304 RVA: 0x00A2A405 File Offset: 0x00A28605
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_220, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_220, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006689 RID: 26249
		// (get) Token: 0x06029559 RID: 169305 RVA: 0x00A2A428 File Offset: 0x00A28628
		// (set) Token: 0x0602955A RID: 169306 RVA: 0x00A2A461 File Offset: 0x00A28661
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_221, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_221, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700668A RID: 26250
		// (get) Token: 0x0602955B RID: 169307 RVA: 0x00A2A484 File Offset: 0x00A28684
		// (set) Token: 0x0602955C RID: 169308 RVA: 0x00A2A4BD File Offset: 0x00A286BD
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_1) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_1 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_222, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_222, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700668B RID: 26251
		// (get) Token: 0x0602955D RID: 169309 RVA: 0x00A2A4E0 File Offset: 0x00A286E0
		// (set) Token: 0x0602955E RID: 169310 RVA: 0x00A2A519 File Offset: 0x00A28719
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_30) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_30 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_223, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_223, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700668C RID: 26252
		// (get) Token: 0x0602955F RID: 169311 RVA: 0x00A2A53C File Offset: 0x00A2873C
		// (set) Token: 0x06029560 RID: 169312 RVA: 0x00A2A575 File Offset: 0x00A28775
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_7) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_7 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_224, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_224, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700668D RID: 26253
		// (get) Token: 0x06029561 RID: 169313 RVA: 0x00A2A598 File Offset: 0x00A28798
		// (set) Token: 0x06029562 RID: 169314 RVA: 0x00A2A5D1 File Offset: 0x00A287D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_225, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_225, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700668E RID: 26254
		// (get) Token: 0x06029563 RID: 169315 RVA: 0x00A2A5F4 File Offset: 0x00A287F4
		// (set) Token: 0x06029564 RID: 169316 RVA: 0x00A2A62D File Offset: 0x00A2882D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_226, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_226, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700668F RID: 26255
		// (get) Token: 0x06029565 RID: 169317 RVA: 0x00A2A650 File Offset: 0x00A28850
		// (set) Token: 0x06029566 RID: 169318 RVA: 0x00A2A689 File Offset: 0x00A28889
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_227, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_227, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006690 RID: 26256
		// (get) Token: 0x06029567 RID: 169319 RVA: 0x00A2A6AC File Offset: 0x00A288AC
		// (set) Token: 0x06029568 RID: 169320 RVA: 0x00A2A6E5 File Offset: 0x00A288E5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_228, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_228, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006691 RID: 26257
		// (get) Token: 0x06029569 RID: 169321 RVA: 0x00A2A708 File Offset: 0x00A28908
		// (set) Token: 0x0602956A RID: 169322 RVA: 0x00A2A741 File Offset: 0x00A28941
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_229, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_229, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006692 RID: 26258
		// (get) Token: 0x0602956B RID: 169323 RVA: 0x00A2A764 File Offset: 0x00A28964
		// (set) Token: 0x0602956C RID: 169324 RVA: 0x00A2A79D File Offset: 0x00A2899D
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_230, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_230, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006693 RID: 26259
		// (get) Token: 0x0602956D RID: 169325 RVA: 0x00A2A7C0 File Offset: 0x00A289C0
		// (set) Token: 0x0602956E RID: 169326 RVA: 0x00A2A7F9 File Offset: 0x00A289F9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_29) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_29 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_231, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_231, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006694 RID: 26260
		// (get) Token: 0x0602956F RID: 169327 RVA: 0x00A2A81C File Offset: 0x00A28A1C
		// (set) Token: 0x06029570 RID: 169328 RVA: 0x00A2A855 File Offset: 0x00A28A55
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_6) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_6 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_232, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_232, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006695 RID: 26261
		// (get) Token: 0x06029571 RID: 169329 RVA: 0x00A2A878 File Offset: 0x00A28A78
		// (set) Token: 0x06029572 RID: 169330 RVA: 0x00A2A8B1 File Offset: 0x00A28AB1
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_233, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_233, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006696 RID: 26262
		// (get) Token: 0x06029573 RID: 169331 RVA: 0x00A2A8D4 File Offset: 0x00A28AD4
		// (set) Token: 0x06029574 RID: 169332 RVA: 0x00A2A90D File Offset: 0x00A28B0D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_28) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_28 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_234, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_234, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006697 RID: 26263
		// (get) Token: 0x06029575 RID: 169333 RVA: 0x00A2A930 File Offset: 0x00A28B30
		// (set) Token: 0x06029576 RID: 169334 RVA: 0x00A2A969 File Offset: 0x00A28B69
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_235, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_235, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006698 RID: 26264
		// (get) Token: 0x06029577 RID: 169335 RVA: 0x00A2A98C File Offset: 0x00A28B8C
		// (set) Token: 0x06029578 RID: 169336 RVA: 0x00A2A9C5 File Offset: 0x00A28BC5
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_27) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_27 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_236, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_236, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006699 RID: 26265
		// (get) Token: 0x06029579 RID: 169337 RVA: 0x00A2A9E8 File Offset: 0x00A28BE8
		// (set) Token: 0x0602957A RID: 169338 RVA: 0x00A2AA21 File Offset: 0x00A28C21
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_237, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_237, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700669A RID: 26266
		// (get) Token: 0x0602957B RID: 169339 RVA: 0x00A2AA44 File Offset: 0x00A28C44
		// (set) Token: 0x0602957C RID: 169340 RVA: 0x00A2AA7D File Offset: 0x00A28C7D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_238, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_238, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700669B RID: 26267
		// (get) Token: 0x0602957D RID: 169341 RVA: 0x00A2AAA0 File Offset: 0x00A28CA0
		// (set) Token: 0x0602957E RID: 169342 RVA: 0x00A2AAD9 File Offset: 0x00A28CD9
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_9) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_9 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_239, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_239, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700669C RID: 26268
		// (get) Token: 0x0602957F RID: 169343 RVA: 0x00A2AAFC File Offset: 0x00A28CFC
		// (set) Token: 0x06029580 RID: 169344 RVA: 0x00A2AB35 File Offset: 0x00A28D35
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_8) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_8 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_240, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_240, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700669D RID: 26269
		// (get) Token: 0x06029581 RID: 169345 RVA: 0x00A2AB58 File Offset: 0x00A28D58
		// (set) Token: 0x06029582 RID: 169346 RVA: 0x00A2AB91 File Offset: 0x00A28D91
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_241, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_241, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700669E RID: 26270
		// (get) Token: 0x06029583 RID: 169347 RVA: 0x00A2ABB4 File Offset: 0x00A28DB4
		// (set) Token: 0x06029584 RID: 169348 RVA: 0x00A2ABED File Offset: 0x00A28DED
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_242, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_242, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700669F RID: 26271
		// (get) Token: 0x06029585 RID: 169349 RVA: 0x00A2AC10 File Offset: 0x00A28E10
		// (set) Token: 0x06029586 RID: 169350 RVA: 0x00A2AC49 File Offset: 0x00A28E49
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_6) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_6 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_243, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_243, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A0 RID: 26272
		// (get) Token: 0x06029587 RID: 169351 RVA: 0x00A2AC6C File Offset: 0x00A28E6C
		// (set) Token: 0x06029588 RID: 169352 RVA: 0x00A2ACA5 File Offset: 0x00A28EA5
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_5) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_5 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_244, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_244, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A1 RID: 26273
		// (get) Token: 0x06029589 RID: 169353 RVA: 0x00A2ACC8 File Offset: 0x00A28EC8
		// (set) Token: 0x0602958A RID: 169354 RVA: 0x00A2AD01 File Offset: 0x00A28F01
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_4) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_4 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_245, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_245, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A2 RID: 26274
		// (get) Token: 0x0602958B RID: 169355 RVA: 0x00A2AD24 File Offset: 0x00A28F24
		// (set) Token: 0x0602958C RID: 169356 RVA: 0x00A2AD5D File Offset: 0x00A28F5D
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_3) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_3 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_246, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_246, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A3 RID: 26275
		// (get) Token: 0x0602958D RID: 169357 RVA: 0x00A2AD80 File Offset: 0x00A28F80
		// (set) Token: 0x0602958E RID: 169358 RVA: 0x00A2ADB9 File Offset: 0x00A28FB9
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_2) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_2 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_247, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_247, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A4 RID: 26276
		// (get) Token: 0x0602958F RID: 169359 RVA: 0x00A2ADDC File Offset: 0x00A28FDC
		// (set) Token: 0x06029590 RID: 169360 RVA: 0x00A2AE15 File Offset: 0x00A29015
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_1) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_1 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_248, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_248, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A5 RID: 26277
		// (get) Token: 0x06029591 RID: 169361 RVA: 0x00A2AE38 File Offset: 0x00A29038
		// (set) Token: 0x06029592 RID: 169362 RVA: 0x00A2AE71 File Offset: 0x00A29071
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_249, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_249, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A6 RID: 26278
		// (get) Token: 0x06029593 RID: 169363 RVA: 0x00A2AE94 File Offset: 0x00A29094
		// (set) Token: 0x06029594 RID: 169364 RVA: 0x00A2AECD File Offset: 0x00A290CD
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_7) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_7 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_250, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_250, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A7 RID: 26279
		// (get) Token: 0x06029595 RID: 169365 RVA: 0x00A2AEF0 File Offset: 0x00A290F0
		// (set) Token: 0x06029596 RID: 169366 RVA: 0x00A2AF29 File Offset: 0x00A29129
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_6) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_6 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_251, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_251, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A8 RID: 26280
		// (get) Token: 0x06029597 RID: 169367 RVA: 0x00A2AF4C File Offset: 0x00A2914C
		// (set) Token: 0x06029598 RID: 169368 RVA: 0x00A2AF85 File Offset: 0x00A29185
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_5) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_5 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_252, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_252, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066A9 RID: 26281
		// (get) Token: 0x06029599 RID: 169369 RVA: 0x00A2AFA8 File Offset: 0x00A291A8
		// (set) Token: 0x0602959A RID: 169370 RVA: 0x00A2AFE1 File Offset: 0x00A291E1
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_4) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_4 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_253, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_253, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066AA RID: 26282
		// (get) Token: 0x0602959B RID: 169371 RVA: 0x00A2B004 File Offset: 0x00A29204
		// (set) Token: 0x0602959C RID: 169372 RVA: 0x00A2B03D File Offset: 0x00A2923D
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_3) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_3 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_254, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_254, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066AB RID: 26283
		// (get) Token: 0x0602959D RID: 169373 RVA: 0x00A2B060 File Offset: 0x00A29260
		// (set) Token: 0x0602959E RID: 169374 RVA: 0x00A2B099 File Offset: 0x00A29299
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_2) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_2 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_255, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_255, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066AC RID: 26284
		// (get) Token: 0x0602959F RID: 169375 RVA: 0x00A2B0BC File Offset: 0x00A292BC
		// (set) Token: 0x060295A0 RID: 169376 RVA: 0x00A2B0F5 File Offset: 0x00A292F5
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_26) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_26 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_256, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_256, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066AD RID: 26285
		// (get) Token: 0x060295A1 RID: 169377 RVA: 0x00A2B118 File Offset: 0x00A29318
		// (set) Token: 0x060295A2 RID: 169378 RVA: 0x00A2B151 File Offset: 0x00A29351
		public FAnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TwoWayBlend result;
				if ((result = this._AnimGraphNode_TwoWayBlend) == null)
				{
					result = (this._AnimGraphNode_TwoWayBlend = new FAnimNode_TwoWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_257, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TwoWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_257, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066AE RID: 26286
		// (get) Token: 0x060295A3 RID: 169379 RVA: 0x00A2B174 File Offset: 0x00A29374
		// (set) Token: 0x060295A4 RID: 169380 RVA: 0x00A2B1AD File Offset: 0x00A293AD
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_258, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_258, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066AF RID: 26287
		// (get) Token: 0x060295A5 RID: 169381 RVA: 0x00A2B1D0 File Offset: 0x00A293D0
		// (set) Token: 0x060295A6 RID: 169382 RVA: 0x00A2B209 File Offset: 0x00A29409
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_1 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_259, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_259, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B0 RID: 26288
		// (get) Token: 0x060295A7 RID: 169383 RVA: 0x00A2B22C File Offset: 0x00A2942C
		// (set) Token: 0x060295A8 RID: 169384 RVA: 0x00A2B265 File Offset: 0x00A29465
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_260, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_260, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B1 RID: 26289
		// (get) Token: 0x060295A9 RID: 169385 RVA: 0x00A2B288 File Offset: 0x00A29488
		// (set) Token: 0x060295AA RID: 169386 RVA: 0x00A2B2C1 File Offset: 0x00A294C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_261, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_261, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B2 RID: 26290
		// (get) Token: 0x060295AB RID: 169387 RVA: 0x00A2B2E4 File Offset: 0x00A294E4
		// (set) Token: 0x060295AC RID: 169388 RVA: 0x00A2B31D File Offset: 0x00A2951D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_262, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_262, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B3 RID: 26291
		// (get) Token: 0x060295AD RID: 169389 RVA: 0x00A2B340 File Offset: 0x00A29540
		// (set) Token: 0x060295AE RID: 169390 RVA: 0x00A2B379 File Offset: 0x00A29579
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_263, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_263, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B4 RID: 26292
		// (get) Token: 0x060295AF RID: 169391 RVA: 0x00A2B39C File Offset: 0x00A2959C
		// (set) Token: 0x060295B0 RID: 169392 RVA: 0x00A2B3D5 File Offset: 0x00A295D5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_264, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_264, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B5 RID: 26293
		// (get) Token: 0x060295B1 RID: 169393 RVA: 0x00A2B3F8 File Offset: 0x00A295F8
		// (set) Token: 0x060295B2 RID: 169394 RVA: 0x00A2B431 File Offset: 0x00A29631
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_265, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_265, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B6 RID: 26294
		// (get) Token: 0x060295B3 RID: 169395 RVA: 0x00A2B454 File Offset: 0x00A29654
		// (set) Token: 0x060295B4 RID: 169396 RVA: 0x00A2B48D File Offset: 0x00A2968D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_266, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_266, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B7 RID: 26295
		// (get) Token: 0x060295B5 RID: 169397 RVA: 0x00A2B4B0 File Offset: 0x00A296B0
		// (set) Token: 0x060295B6 RID: 169398 RVA: 0x00A2B4E9 File Offset: 0x00A296E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_267, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_267, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B8 RID: 26296
		// (get) Token: 0x060295B7 RID: 169399 RVA: 0x00A2B50C File Offset: 0x00A2970C
		// (set) Token: 0x060295B8 RID: 169400 RVA: 0x00A2B545 File Offset: 0x00A29745
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_268, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_268, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066B9 RID: 26297
		// (get) Token: 0x060295B9 RID: 169401 RVA: 0x00A2B568 File Offset: 0x00A29768
		// (set) Token: 0x060295BA RID: 169402 RVA: 0x00A2B5A1 File Offset: 0x00A297A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_269, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_269, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066BA RID: 26298
		// (get) Token: 0x060295BB RID: 169403 RVA: 0x00A2B5C4 File Offset: 0x00A297C4
		// (set) Token: 0x060295BC RID: 169404 RVA: 0x00A2B5FD File Offset: 0x00A297FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_270, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_270, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066BB RID: 26299
		// (get) Token: 0x060295BD RID: 169405 RVA: 0x00A2B620 File Offset: 0x00A29820
		// (set) Token: 0x060295BE RID: 169406 RVA: 0x00A2B659 File Offset: 0x00A29859
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_271, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_271, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066BC RID: 26300
		// (get) Token: 0x060295BF RID: 169407 RVA: 0x00A2B67C File Offset: 0x00A2987C
		// (set) Token: 0x060295C0 RID: 169408 RVA: 0x00A2B6B5 File Offset: 0x00A298B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_272, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_272, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066BD RID: 26301
		// (get) Token: 0x060295C1 RID: 169409 RVA: 0x00A2B6D8 File Offset: 0x00A298D8
		// (set) Token: 0x060295C2 RID: 169410 RVA: 0x00A2B711 File Offset: 0x00A29911
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_273, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_273, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066BE RID: 26302
		// (get) Token: 0x060295C3 RID: 169411 RVA: 0x00A2B734 File Offset: 0x00A29934
		// (set) Token: 0x060295C4 RID: 169412 RVA: 0x00A2B76D File Offset: 0x00A2996D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_274, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_274, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066BF RID: 26303
		// (get) Token: 0x060295C5 RID: 169413 RVA: 0x00A2B790 File Offset: 0x00A29990
		// (set) Token: 0x060295C6 RID: 169414 RVA: 0x00A2B7C9 File Offset: 0x00A299C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_275, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_275, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C0 RID: 26304
		// (get) Token: 0x060295C7 RID: 169415 RVA: 0x00A2B7EC File Offset: 0x00A299EC
		// (set) Token: 0x060295C8 RID: 169416 RVA: 0x00A2B825 File Offset: 0x00A29A25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_276, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_276, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C1 RID: 26305
		// (get) Token: 0x060295C9 RID: 169417 RVA: 0x00A2B848 File Offset: 0x00A29A48
		// (set) Token: 0x060295CA RID: 169418 RVA: 0x00A2B881 File Offset: 0x00A29A81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_277, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_277, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C2 RID: 26306
		// (get) Token: 0x060295CB RID: 169419 RVA: 0x00A2B8A4 File Offset: 0x00A29AA4
		// (set) Token: 0x060295CC RID: 169420 RVA: 0x00A2B8DD File Offset: 0x00A29ADD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_278, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_278, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C3 RID: 26307
		// (get) Token: 0x060295CD RID: 169421 RVA: 0x00A2B900 File Offset: 0x00A29B00
		// (set) Token: 0x060295CE RID: 169422 RVA: 0x00A2B939 File Offset: 0x00A29B39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_279, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_279, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C4 RID: 26308
		// (get) Token: 0x060295CF RID: 169423 RVA: 0x00A2B95C File Offset: 0x00A29B5C
		// (set) Token: 0x060295D0 RID: 169424 RVA: 0x00A2B995 File Offset: 0x00A29B95
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_280, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_280, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C5 RID: 26309
		// (get) Token: 0x060295D1 RID: 169425 RVA: 0x00A2B9B8 File Offset: 0x00A29BB8
		// (set) Token: 0x060295D2 RID: 169426 RVA: 0x00A2B9F1 File Offset: 0x00A29BF1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_281, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_281, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C6 RID: 26310
		// (get) Token: 0x060295D3 RID: 169427 RVA: 0x00A2BA14 File Offset: 0x00A29C14
		// (set) Token: 0x060295D4 RID: 169428 RVA: 0x00A2BA4D File Offset: 0x00A29C4D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_282, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_282, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C7 RID: 26311
		// (get) Token: 0x060295D5 RID: 169429 RVA: 0x00A2BA70 File Offset: 0x00A29C70
		// (set) Token: 0x060295D6 RID: 169430 RVA: 0x00A2BAA9 File Offset: 0x00A29CA9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_25) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_25 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_283, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_283, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C8 RID: 26312
		// (get) Token: 0x060295D7 RID: 169431 RVA: 0x00A2BACC File Offset: 0x00A29CCC
		// (set) Token: 0x060295D8 RID: 169432 RVA: 0x00A2BB05 File Offset: 0x00A29D05
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_5) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_5 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_284, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_284, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066C9 RID: 26313
		// (get) Token: 0x060295D9 RID: 169433 RVA: 0x00A2BB28 File Offset: 0x00A29D28
		// (set) Token: 0x060295DA RID: 169434 RVA: 0x00A2BB61 File Offset: 0x00A29D61
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_24) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_24 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_285, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_285, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066CA RID: 26314
		// (get) Token: 0x060295DB RID: 169435 RVA: 0x00A2BB84 File Offset: 0x00A29D84
		// (set) Token: 0x060295DC RID: 169436 RVA: 0x00A2BBBD File Offset: 0x00A29DBD
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_23) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_23 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_286, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_286, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066CB RID: 26315
		// (get) Token: 0x060295DD RID: 169437 RVA: 0x00A2BBE0 File Offset: 0x00A29DE0
		// (set) Token: 0x060295DE RID: 169438 RVA: 0x00A2BC19 File Offset: 0x00A29E19
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_22) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_22 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_287, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_287, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066CC RID: 26316
		// (get) Token: 0x060295DF RID: 169439 RVA: 0x00A2BC3C File Offset: 0x00A29E3C
		// (set) Token: 0x060295E0 RID: 169440 RVA: 0x00A2BC75 File Offset: 0x00A29E75
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_288, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_288, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066CD RID: 26317
		// (get) Token: 0x060295E1 RID: 169441 RVA: 0x00A2BC98 File Offset: 0x00A29E98
		// (set) Token: 0x060295E2 RID: 169442 RVA: 0x00A2BCD1 File Offset: 0x00A29ED1
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_21) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_21 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_289, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_289, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066CE RID: 26318
		// (get) Token: 0x060295E3 RID: 169443 RVA: 0x00A2BCF4 File Offset: 0x00A29EF4
		// (set) Token: 0x060295E4 RID: 169444 RVA: 0x00A2BD2D File Offset: 0x00A29F2D
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_4) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_4 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_290, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_290, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066CF RID: 26319
		// (get) Token: 0x060295E5 RID: 169445 RVA: 0x00A2BD50 File Offset: 0x00A29F50
		// (set) Token: 0x060295E6 RID: 169446 RVA: 0x00A2BD89 File Offset: 0x00A29F89
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_20) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_20 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_291, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_291, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D0 RID: 26320
		// (get) Token: 0x060295E7 RID: 169447 RVA: 0x00A2BDAC File Offset: 0x00A29FAC
		// (set) Token: 0x060295E8 RID: 169448 RVA: 0x00A2BDE5 File Offset: 0x00A29FE5
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_19) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_19 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_292, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_292, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D1 RID: 26321
		// (get) Token: 0x060295E9 RID: 169449 RVA: 0x00A2BE08 File Offset: 0x00A2A008
		// (set) Token: 0x060295EA RID: 169450 RVA: 0x00A2BE41 File Offset: 0x00A2A041
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_18) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_18 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_293, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_293, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D2 RID: 26322
		// (get) Token: 0x060295EB RID: 169451 RVA: 0x00A2BE64 File Offset: 0x00A2A064
		// (set) Token: 0x060295EC RID: 169452 RVA: 0x00A2BE9D File Offset: 0x00A2A09D
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_294, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_294, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D3 RID: 26323
		// (get) Token: 0x060295ED RID: 169453 RVA: 0x00A2BEC0 File Offset: 0x00A2A0C0
		// (set) Token: 0x060295EE RID: 169454 RVA: 0x00A2BEF9 File Offset: 0x00A2A0F9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_17) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_17 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_295, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_295, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D4 RID: 26324
		// (get) Token: 0x060295EF RID: 169455 RVA: 0x00A2BF1C File Offset: 0x00A2A11C
		// (set) Token: 0x060295F0 RID: 169456 RVA: 0x00A2BF55 File Offset: 0x00A2A155
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_16) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_16 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_296, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_296, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D5 RID: 26325
		// (get) Token: 0x060295F1 RID: 169457 RVA: 0x00A2BF78 File Offset: 0x00A2A178
		// (set) Token: 0x060295F2 RID: 169458 RVA: 0x00A2BFB1 File Offset: 0x00A2A1B1
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_3) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_3 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_297, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_297, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D6 RID: 26326
		// (get) Token: 0x060295F3 RID: 169459 RVA: 0x00A2BFD4 File Offset: 0x00A2A1D4
		// (set) Token: 0x060295F4 RID: 169460 RVA: 0x00A2C00D File Offset: 0x00A2A20D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_15) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_15 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_298, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_298, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D7 RID: 26327
		// (get) Token: 0x060295F5 RID: 169461 RVA: 0x00A2C030 File Offset: 0x00A2A230
		// (set) Token: 0x060295F6 RID: 169462 RVA: 0x00A2C069 File Offset: 0x00A2A269
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_14) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_14 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_299, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_299, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D8 RID: 26328
		// (get) Token: 0x060295F7 RID: 169463 RVA: 0x00A2C08C File Offset: 0x00A2A28C
		// (set) Token: 0x060295F8 RID: 169464 RVA: 0x00A2C0C5 File Offset: 0x00A2A2C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_300, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_300, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066D9 RID: 26329
		// (get) Token: 0x060295F9 RID: 169465 RVA: 0x00A2C0E8 File Offset: 0x00A2A2E8
		// (set) Token: 0x060295FA RID: 169466 RVA: 0x00A2C121 File Offset: 0x00A2A321
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_13) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_13 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_301, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_301, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066DA RID: 26330
		// (get) Token: 0x060295FB RID: 169467 RVA: 0x00A2C144 File Offset: 0x00A2A344
		// (set) Token: 0x060295FC RID: 169468 RVA: 0x00A2C17D File Offset: 0x00A2A37D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_12) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_12 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_302, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_302, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066DB RID: 26331
		// (get) Token: 0x060295FD RID: 169469 RVA: 0x00A2C1A0 File Offset: 0x00A2A3A0
		// (set) Token: 0x060295FE RID: 169470 RVA: 0x00A2C1D9 File Offset: 0x00A2A3D9
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_2) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_2 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_303, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_303, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066DC RID: 26332
		// (get) Token: 0x060295FF RID: 169471 RVA: 0x00A2C1FC File Offset: 0x00A2A3FC
		// (set) Token: 0x06029600 RID: 169472 RVA: 0x00A2C235 File Offset: 0x00A2A435
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_11) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_11 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_304, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_304, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066DD RID: 26333
		// (get) Token: 0x06029601 RID: 169473 RVA: 0x00A2C258 File Offset: 0x00A2A458
		// (set) Token: 0x06029602 RID: 169474 RVA: 0x00A2C291 File Offset: 0x00A2A491
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_10) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_10 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_305, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_305, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066DE RID: 26334
		// (get) Token: 0x06029603 RID: 169475 RVA: 0x00A2C2B4 File Offset: 0x00A2A4B4
		// (set) Token: 0x06029604 RID: 169476 RVA: 0x00A2C2ED File Offset: 0x00A2A4ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_306, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_306, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066DF RID: 26335
		// (get) Token: 0x06029605 RID: 169477 RVA: 0x00A2C310 File Offset: 0x00A2A510
		// (set) Token: 0x06029606 RID: 169478 RVA: 0x00A2C349 File Offset: 0x00A2A549
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_9) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_9 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_307, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_307, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E0 RID: 26336
		// (get) Token: 0x06029607 RID: 169479 RVA: 0x00A2C36C File Offset: 0x00A2A56C
		// (set) Token: 0x06029608 RID: 169480 RVA: 0x00A2C3A5 File Offset: 0x00A2A5A5
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_8) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_8 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_308, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_308, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E1 RID: 26337
		// (get) Token: 0x06029609 RID: 169481 RVA: 0x00A2C3C8 File Offset: 0x00A2A5C8
		// (set) Token: 0x0602960A RID: 169482 RVA: 0x00A2C401 File Offset: 0x00A2A601
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_1) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_1 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_309, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_309, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E2 RID: 26338
		// (get) Token: 0x0602960B RID: 169483 RVA: 0x00A2C424 File Offset: 0x00A2A624
		// (set) Token: 0x0602960C RID: 169484 RVA: 0x00A2C45D File Offset: 0x00A2A65D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_7) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_7 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_310, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_310, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E3 RID: 26339
		// (get) Token: 0x0602960D RID: 169485 RVA: 0x00A2C480 File Offset: 0x00A2A680
		// (set) Token: 0x0602960E RID: 169486 RVA: 0x00A2C4B9 File Offset: 0x00A2A6B9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_6) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_6 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_311, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_311, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E4 RID: 26340
		// (get) Token: 0x0602960F RID: 169487 RVA: 0x00A2C4DC File Offset: 0x00A2A6DC
		// (set) Token: 0x06029610 RID: 169488 RVA: 0x00A2C515 File Offset: 0x00A2A715
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_312, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_312, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E5 RID: 26341
		// (get) Token: 0x06029611 RID: 169489 RVA: 0x00A2C538 File Offset: 0x00A2A738
		// (set) Token: 0x06029612 RID: 169490 RVA: 0x00A2C571 File Offset: 0x00A2A771
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_313, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_313, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E6 RID: 26342
		// (get) Token: 0x06029613 RID: 169491 RVA: 0x00A2C594 File Offset: 0x00A2A794
		// (set) Token: 0x06029614 RID: 169492 RVA: 0x00A2C5CD File Offset: 0x00A2A7CD
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_5) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_5 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_314, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_314, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E7 RID: 26343
		// (get) Token: 0x06029615 RID: 169493 RVA: 0x00A2C5F0 File Offset: 0x00A2A7F0
		// (set) Token: 0x06029616 RID: 169494 RVA: 0x00A2C629 File Offset: 0x00A2A829
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_4) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_4 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_315, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_315, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E8 RID: 26344
		// (get) Token: 0x06029617 RID: 169495 RVA: 0x00A2C64C File Offset: 0x00A2A84C
		// (set) Token: 0x06029618 RID: 169496 RVA: 0x00A2C685 File Offset: 0x00A2A885
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_3) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_3 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_316, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_316, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066E9 RID: 26345
		// (get) Token: 0x06029619 RID: 169497 RVA: 0x00A2C6A8 File Offset: 0x00A2A8A8
		// (set) Token: 0x0602961A RID: 169498 RVA: 0x00A2C6E1 File Offset: 0x00A2A8E1
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_2) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_2 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_317, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_317, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066EA RID: 26346
		// (get) Token: 0x0602961B RID: 169499 RVA: 0x00A2C704 File Offset: 0x00A2A904
		// (set) Token: 0x0602961C RID: 169500 RVA: 0x00A2C73D File Offset: 0x00A2A93D
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_318, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_318, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066EB RID: 26347
		// (get) Token: 0x0602961D RID: 169501 RVA: 0x00A2C760 File Offset: 0x00A2A960
		// (set) Token: 0x0602961E RID: 169502 RVA: 0x00A2C799 File Offset: 0x00A2A999
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_319, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_319, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066EC RID: 26348
		// (get) Token: 0x0602961F RID: 169503 RVA: 0x00A2C7BC File Offset: 0x00A2A9BC
		// (set) Token: 0x06029620 RID: 169504 RVA: 0x00A2C7F5 File Offset: 0x00A2A9F5
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_320, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_320, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066ED RID: 26349
		// (get) Token: 0x06029621 RID: 169505 RVA: 0x00A2C818 File Offset: 0x00A2AA18
		// (set) Token: 0x06029622 RID: 169506 RVA: 0x00A2C851 File Offset: 0x00A2AA51
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_1 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_321, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_321, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066EE RID: 26350
		// (get) Token: 0x06029623 RID: 169507 RVA: 0x00A2C874 File Offset: 0x00A2AA74
		// (set) Token: 0x06029624 RID: 169508 RVA: 0x00A2C8AD File Offset: 0x00A2AAAD
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_322, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_322, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066EF RID: 26351
		// (get) Token: 0x06029625 RID: 169509 RVA: 0x00A2C8D0 File Offset: 0x00A2AAD0
		// (set) Token: 0x06029626 RID: 169510 RVA: 0x00A2C909 File Offset: 0x00A2AB09
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_323, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_323, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066F0 RID: 26352
		// (get) Token: 0x06029627 RID: 169511 RVA: 0x00A2C92C File Offset: 0x00A2AB2C
		// (set) Token: 0x06029628 RID: 169512 RVA: 0x00A2C965 File Offset: 0x00A2AB65
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_3) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_3 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_324, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_324, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066F1 RID: 26353
		// (get) Token: 0x06029629 RID: 169513 RVA: 0x00A2C988 File Offset: 0x00A2AB88
		// (set) Token: 0x0602962A RID: 169514 RVA: 0x00A2C9C1 File Offset: 0x00A2ABC1
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_2) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_2 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_325, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_325, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066F2 RID: 26354
		// (get) Token: 0x0602962B RID: 169515 RVA: 0x00A2C9E4 File Offset: 0x00A2ABE4
		// (set) Token: 0x0602962C RID: 169516 RVA: 0x00A2CA1D File Offset: 0x00A2AC1D
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_326, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_326, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066F3 RID: 26355
		// (get) Token: 0x0602962D RID: 169517 RVA: 0x00A2CA40 File Offset: 0x00A2AC40
		// (set) Token: 0x0602962E RID: 169518 RVA: 0x00A2CA79 File Offset: 0x00A2AC79
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_327, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_327, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170066F4 RID: 26356
		// (get) Token: 0x0602962F RID: 169519 RVA: 0x00A2CA9A File Offset: 0x00A2AC9A
		// (set) Token: 0x06029630 RID: 169520 RVA: 0x00A2CAAE File Offset: 0x00A2ACAE
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_Calbrena_Special_C.__PropertyOffset_328);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_Calbrena_Special_C.__PropertyOffset_328, value);
			}
		}

		// Token: 0x170066F5 RID: 26357
		// (get) Token: 0x06029631 RID: 169521 RVA: 0x00A2CAC3 File Offset: 0x00A2ACC3
		// (set) Token: 0x06029632 RID: 169522 RVA: 0x00A2CAD3 File Offset: 0x00A2ACD3
		public unsafe bool 状态_样条跑墙
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_329) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_329) = (value ? 1 : 0);
			}
		}

		// Token: 0x170066F6 RID: 26358
		// (get) Token: 0x06029633 RID: 169523 RVA: 0x00A2CAE4 File Offset: 0x00A2ACE4
		// (set) Token: 0x06029634 RID: 169524 RVA: 0x00A2CAF4 File Offset: 0x00A2ACF4
		public unsafe bool 状态_飞雷神移动中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_330) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_330) = (value ? 1 : 0);
			}
		}

		// Token: 0x170066F7 RID: 26359
		// (get) Token: 0x06029635 RID: 169525 RVA: 0x00A2CB05 File Offset: 0x00A2AD05
		// (set) Token: 0x06029636 RID: 169526 RVA: 0x00A2CB19 File Offset: 0x00A2AD19
		public unsafe FVeloctiyBlend VelocityBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_331);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Calbrena_Special_C.__PropertyOffset_331) = value;
			}
		}

		// Token: 0x06029637 RID: 169527 RVA: 0x00A2CB30 File Offset: 0x00A2AD30
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础姿势层(ref FPoseLink 基础姿势层)
		{
			ABP_Calbrena_Special_C.__基础姿势层_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__基础姿势层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__基础姿势层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__基础姿势层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础姿势层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础姿势层, 基础姿势层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__基础姿势层_NativeFunctionPtr, (void*)ptr);
			if (基础姿势层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础姿势层.NativePtr, &ptr->基础姿势层, 1, false);
			}
		}

		// Token: 0x06029638 RID: 169528 RVA: 0x00A2CBB8 File Offset: 0x00A2ADB8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 叠加动作层(ref FPoseLink 叠加动作层)
		{
			ABP_Calbrena_Special_C.__叠加动作层_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__叠加动作层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__叠加动作层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__叠加动作层_NativeFunctionPtr, (void*)ptr, 1);
			if (叠加动作层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->叠加动作层, 叠加动作层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__叠加动作层_NativeFunctionPtr, (void*)ptr);
			if (叠加动作层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 叠加动作层.NativePtr, &ptr->叠加动作层, 1, false);
			}
		}

		// Token: 0x06029639 RID: 169529 RVA: 0x00A2CC40 File Offset: 0x00A2AE40
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 混合层(FPoseLink BaseLayer, FPoseLink OverlayLayer, FPoseLink BasePose, ref FPoseLink 混合层)
		{
			ABP_Calbrena_Special_C.__混合层_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__混合层_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__混合层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__混合层_NativeFunctionPtr, (void*)ptr, 1);
			if (BaseLayer != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->BaseLayer, BaseLayer.NativePtr, 1, false);
			}
			if (OverlayLayer != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->OverlayLayer, OverlayLayer.NativePtr, 1, false);
			}
			if (BasePose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->BasePose, BasePose.NativePtr, 1, false);
			}
			if (混合层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->混合层, 混合层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__混合层_NativeFunctionPtr, (void*)ptr);
			if (混合层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 混合层.NativePtr, &ptr->混合层, 1, false);
			}
		}

		// Token: 0x0602963A RID: 169530 RVA: 0x00A2CD34 File Offset: 0x00A2AF34
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_Calbrena_Special_C.__基础层_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602963B RID: 169531 RVA: 0x00A2CDBC File Offset: 0x00A2AFBC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 地面站立循环混合层(FPoseLink 前, FPoseLink 后, FPoseLink 左前, FPoseLink 左后, FPoseLink 右前, FPoseLink 右后, FPoseLink 冲刺, ref FPoseLink 地面站立循环混合层)
		{
			ABP_Calbrena_Special_C.__地面站立循环混合层_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__地面站立循环混合层_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__地面站立循环混合层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__地面站立循环混合层_NativeFunctionPtr, (void*)ptr, 1);
			if (前 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->前, 前.NativePtr, 1, false);
			}
			if (后 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->后, 后.NativePtr, 1, false);
			}
			if (左前 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->左前, 左前.NativePtr, 1, false);
			}
			if (左后 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->左后, 左后.NativePtr, 1, false);
			}
			if (右前 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->右前, 右前.NativePtr, 1, false);
			}
			if (右后 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->右后, 右后.NativePtr, 1, false);
			}
			if (冲刺 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->冲刺, 冲刺.NativePtr, 1, false);
			}
			if (地面站立循环混合层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->地面站立循环混合层, 地面站立循环混合层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__地面站立循环混合层_NativeFunctionPtr, (void*)ptr);
			if (地面站立循环混合层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 地面站立循环混合层.NativePtr, &ptr->地面站立循环混合层, 1, false);
			}
		}

		// Token: 0x0602963C RID: 169532 RVA: 0x00A2CF40 File Offset: 0x00A2B140
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_Calbrena_Special_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602963D RID: 169533 RVA: 0x00A2CFC7 File Offset: 0x00A2B1C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__初始化Tag_NativeFunctionPtr, null);
		}

		// Token: 0x0602963E RID: 169534 RVA: 0x00A2CFDB File Offset: 0x00A2B1DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AD363E854A39DE16287F9F9FF855C859()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AD363E854A39DE16287F9F9FF855C859_NativeFunctionPtr, null);
		}

		// Token: 0x0602963F RID: 169535 RVA: 0x00A2CFEF File Offset: 0x00A2B1EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_27F568B44918B0F888763B8E94204F21()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_27F568B44918B0F888763B8E94204F21_NativeFunctionPtr, null);
		}

		// Token: 0x06029640 RID: 169536 RVA: 0x00A2D003 File Offset: 0x00A2B203
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_21F1E1A4450B10D159C2BDBC501F09D9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_21F1E1A4450B10D159C2BDBC501F09D9_NativeFunctionPtr, null);
		}

		// Token: 0x06029641 RID: 169537 RVA: 0x00A2D017 File Offset: 0x00A2B217
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_E6E4271B494C142FA5D45B86259B44FE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_E6E4271B494C142FA5D45B86259B44FE_NativeFunctionPtr, null);
		}

		// Token: 0x06029642 RID: 169538 RVA: 0x00A2D02B File Offset: 0x00A2B22B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9A1C8A1B4FE077E976584490DF0B6A69()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9A1C8A1B4FE077E976584490DF0B6A69_NativeFunctionPtr, null);
		}

		// Token: 0x06029643 RID: 169539 RVA: 0x00A2D03F File Offset: 0x00A2B23F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_220048E64C60B47E210251BD1E2D0F0D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_220048E64C60B47E210251BD1E2D0F0D_NativeFunctionPtr, null);
		}

		// Token: 0x06029644 RID: 169540 RVA: 0x00A2D053 File Offset: 0x00A2B253
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_60FBB29642807596050B429F3A663122()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_60FBB29642807596050B429F3A663122_NativeFunctionPtr, null);
		}

		// Token: 0x06029645 RID: 169541 RVA: 0x00A2D067 File Offset: 0x00A2B267
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B57EEE8044D4374A57C2B9A788EC0244()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B57EEE8044D4374A57C2B9A788EC0244_NativeFunctionPtr, null);
		}

		// Token: 0x06029646 RID: 169542 RVA: 0x00A2D07B File Offset: 0x00A2B27B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9DA288A048BD924028C0F4B063D85066()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9DA288A048BD924028C0F4B063D85066_NativeFunctionPtr, null);
		}

		// Token: 0x06029647 RID: 169543 RVA: 0x00A2D08F File Offset: 0x00A2B28F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_DA26F01A4AD5E62862EFAC875EA34622()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_DA26F01A4AD5E62862EFAC875EA34622_NativeFunctionPtr, null);
		}

		// Token: 0x06029648 RID: 169544 RVA: 0x00A2D0A3 File Offset: 0x00A2B2A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A27103154537F02D4F5FB591054CD4F2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A27103154537F02D4F5FB591054CD4F2_NativeFunctionPtr, null);
		}

		// Token: 0x06029649 RID: 169545 RVA: 0x00A2D0B7 File Offset: 0x00A2B2B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AAF70D3F42C2316773D52F8A3C2B61A2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AAF70D3F42C2316773D52F8A3C2B61A2_NativeFunctionPtr, null);
		}

		// Token: 0x0602964A RID: 169546 RVA: 0x00A2D0CB File Offset: 0x00A2B2CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_BEA7D57D44AC85A8BD5AB586BDF748F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_BEA7D57D44AC85A8BD5AB586BDF748F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602964B RID: 169547 RVA: 0x00A2D0DF File Offset: 0x00A2B2DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AFB576D64E5BD0A39613B2BA6C6E9EC2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AFB576D64E5BD0A39613B2BA6C6E9EC2_NativeFunctionPtr, null);
		}

		// Token: 0x0602964C RID: 169548 RVA: 0x00A2D0F3 File Offset: 0x00A2B2F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_410DE10A4CFBE7F24448D7924DAC6886()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_410DE10A4CFBE7F24448D7924DAC6886_NativeFunctionPtr, null);
		}

		// Token: 0x0602964D RID: 169549 RVA: 0x00A2D107 File Offset: 0x00A2B307
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7D787FA7435D0F49320F8D96D0176147()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7D787FA7435D0F49320F8D96D0176147_NativeFunctionPtr, null);
		}

		// Token: 0x0602964E RID: 169550 RVA: 0x00A2D11B File Offset: 0x00A2B31B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A1D765AA46F134CE4FD4B2AC68BA8199()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A1D765AA46F134CE4FD4B2AC68BA8199_NativeFunctionPtr, null);
		}

		// Token: 0x0602964F RID: 169551 RVA: 0x00A2D12F File Offset: 0x00A2B32F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9F0E6E844C78400D64B5CAA0737DCB34()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9F0E6E844C78400D64B5CAA0737DCB34_NativeFunctionPtr, null);
		}

		// Token: 0x06029650 RID: 169552 RVA: 0x00A2D143 File Offset: 0x00A2B343
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6256CF234775832C0CE4B6BCC3BEC312()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6256CF234775832C0CE4B6BCC3BEC312_NativeFunctionPtr, null);
		}

		// Token: 0x06029651 RID: 169553 RVA: 0x00A2D157 File Offset: 0x00A2B357
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A20228084683E70DA873158B410F792B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A20228084683E70DA873158B410F792B_NativeFunctionPtr, null);
		}

		// Token: 0x06029652 RID: 169554 RVA: 0x00A2D16B File Offset: 0x00A2B36B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B92843C645CBCCDFCD5AE1A41C1ABDA2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B92843C645CBCCDFCD5AE1A41C1ABDA2_NativeFunctionPtr, null);
		}

		// Token: 0x06029653 RID: 169555 RVA: 0x00A2D17F File Offset: 0x00A2B37F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_37F7D28E4E4423EE25C5F399EDC85CEF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_37F7D28E4E4423EE25C5F399EDC85CEF_NativeFunctionPtr, null);
		}

		// Token: 0x06029654 RID: 169556 RVA: 0x00A2D193 File Offset: 0x00A2B393
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4851DD91403E7425F091B8A03E58074F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4851DD91403E7425F091B8A03E58074F_NativeFunctionPtr, null);
		}

		// Token: 0x06029655 RID: 169557 RVA: 0x00A2D1A7 File Offset: 0x00A2B3A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_625ABCC541D177C6393C36A15A625F4F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_625ABCC541D177C6393C36A15A625F4F_NativeFunctionPtr, null);
		}

		// Token: 0x06029656 RID: 169558 RVA: 0x00A2D1BB File Offset: 0x00A2B3BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B91FF85F46C2D12C6FD65DAB08F73423()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B91FF85F46C2D12C6FD65DAB08F73423_NativeFunctionPtr, null);
		}

		// Token: 0x06029657 RID: 169559 RVA: 0x00A2D1CF File Offset: 0x00A2B3CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_896BC1C3414F01186D1D50885BF09885()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_896BC1C3414F01186D1D50885BF09885_NativeFunctionPtr, null);
		}

		// Token: 0x06029658 RID: 169560 RVA: 0x00A2D1E3 File Offset: 0x00A2B3E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4A04C912416E67FADC0D12989760CF35()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4A04C912416E67FADC0D12989760CF35_NativeFunctionPtr, null);
		}

		// Token: 0x06029659 RID: 169561 RVA: 0x00A2D1F7 File Offset: 0x00A2B3F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2F257E26449919182BA48C820C43E2C7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2F257E26449919182BA48C820C43E2C7_NativeFunctionPtr, null);
		}

		// Token: 0x0602965A RID: 169562 RVA: 0x00A2D20B File Offset: 0x00A2B40B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_01E7C8E84B7B4BDF9DCFE6BF76494BC7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_01E7C8E84B7B4BDF9DCFE6BF76494BC7_NativeFunctionPtr, null);
		}

		// Token: 0x0602965B RID: 169563 RVA: 0x00A2D21F File Offset: 0x00A2B41F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9CBE3E1B428BBF7B923FF4BACCABDDB4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9CBE3E1B428BBF7B923FF4BACCABDDB4_NativeFunctionPtr, null);
		}

		// Token: 0x0602965C RID: 169564 RVA: 0x00A2D233 File Offset: 0x00A2B433
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_932A9075429DD81B7228D993557391CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_932A9075429DD81B7228D993557391CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602965D RID: 169565 RVA: 0x00A2D247 File Offset: 0x00A2B447
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_60D8D0CF4DDC91A5502D2796FAF8FAD2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_60D8D0CF4DDC91A5502D2796FAF8FAD2_NativeFunctionPtr, null);
		}

		// Token: 0x0602965E RID: 169566 RVA: 0x00A2D25B File Offset: 0x00A2B45B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_21CEE1754B86B6285B63AAB33FC2DA2B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_21CEE1754B86B6285B63AAB33FC2DA2B_NativeFunctionPtr, null);
		}

		// Token: 0x0602965F RID: 169567 RVA: 0x00A2D26F File Offset: 0x00A2B46F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_DBB968454053CF0770E40EB298E940BD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_DBB968454053CF0770E40EB298E940BD_NativeFunctionPtr, null);
		}

		// Token: 0x06029660 RID: 169568 RVA: 0x00A2D283 File Offset: 0x00A2B483
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7B8EADB94F1E638F51B74F925B6981B6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7B8EADB94F1E638F51B74F925B6981B6_NativeFunctionPtr, null);
		}

		// Token: 0x06029661 RID: 169569 RVA: 0x00A2D297 File Offset: 0x00A2B497
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_38F816CA4806E22E805384B9654A43FB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_38F816CA4806E22E805384B9654A43FB_NativeFunctionPtr, null);
		}

		// Token: 0x06029662 RID: 169570 RVA: 0x00A2D2AB File Offset: 0x00A2B4AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2A3EF5F64A25167A4C02719C660675E5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2A3EF5F64A25167A4C02719C660675E5_NativeFunctionPtr, null);
		}

		// Token: 0x06029663 RID: 169571 RVA: 0x00A2D2BF File Offset: 0x00A2B4BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_35D84E8A479A5A096BBD919A37845E9C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_35D84E8A479A5A096BBD919A37845E9C_NativeFunctionPtr, null);
		}

		// Token: 0x06029664 RID: 169572 RVA: 0x00A2D2D3 File Offset: 0x00A2B4D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_97E08F73466496665F816584BB4A9D03()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_97E08F73466496665F816584BB4A9D03_NativeFunctionPtr, null);
		}

		// Token: 0x06029665 RID: 169573 RVA: 0x00A2D2E7 File Offset: 0x00A2B4E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A16B4587474299B76A2A83957F2D7418()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A16B4587474299B76A2A83957F2D7418_NativeFunctionPtr, null);
		}

		// Token: 0x06029666 RID: 169574 RVA: 0x00A2D2FB File Offset: 0x00A2B4FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_16D9A3E046A6D5C51769D190AEBD2D0C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_16D9A3E046A6D5C51769D190AEBD2D0C_NativeFunctionPtr, null);
		}

		// Token: 0x06029667 RID: 169575 RVA: 0x00A2D30F File Offset: 0x00A2B50F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4434EBB843818E112B0F96AAF6418EB2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4434EBB843818E112B0F96AAF6418EB2_NativeFunctionPtr, null);
		}

		// Token: 0x06029668 RID: 169576 RVA: 0x00A2D323 File Offset: 0x00A2B523
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6253594B45AA2AAA2E6ED78872EF0326()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6253594B45AA2AAA2E6ED78872EF0326_NativeFunctionPtr, null);
		}

		// Token: 0x06029669 RID: 169577 RVA: 0x00A2D337 File Offset: 0x00A2B537
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_19367FDE4281669DB5553D99E8B23F7A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_19367FDE4281669DB5553D99E8B23F7A_NativeFunctionPtr, null);
		}

		// Token: 0x0602966A RID: 169578 RVA: 0x00A2D34B File Offset: 0x00A2B54B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_297451FB4C08C9BAB720F4A461A597BF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_297451FB4C08C9BAB720F4A461A597BF_NativeFunctionPtr, null);
		}

		// Token: 0x0602966B RID: 169579 RVA: 0x00A2D35F File Offset: 0x00A2B55F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_181E99E64741868324755DBE23E64937()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_181E99E64741868324755DBE23E64937_NativeFunctionPtr, null);
		}

		// Token: 0x0602966C RID: 169580 RVA: 0x00A2D373 File Offset: 0x00A2B573
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_EB8F6E934FDAED5E949FE78AC51AF5AF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_EB8F6E934FDAED5E949FE78AC51AF5AF_NativeFunctionPtr, null);
		}

		// Token: 0x0602966D RID: 169581 RVA: 0x00A2D387 File Offset: 0x00A2B587
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_62990C1D4B68B1AD42BC07A152DE5E12()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_62990C1D4B68B1AD42BC07A152DE5E12_NativeFunctionPtr, null);
		}

		// Token: 0x0602966E RID: 169582 RVA: 0x00A2D39B File Offset: 0x00A2B59B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_59E6208D4A9A26D5735C6CB9613D3495()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_59E6208D4A9A26D5735C6CB9613D3495_NativeFunctionPtr, null);
		}

		// Token: 0x0602966F RID: 169583 RVA: 0x00A2D3AF File Offset: 0x00A2B5AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2D9CDBF348FB2AC10029DDA1CCB497A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2D9CDBF348FB2AC10029DDA1CCB497A7_NativeFunctionPtr, null);
		}

		// Token: 0x06029670 RID: 169584 RVA: 0x00A2D3C3 File Offset: 0x00A2B5C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2206F9EE49E34930D4B40FA69C21D605()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2206F9EE49E34930D4B40FA69C21D605_NativeFunctionPtr, null);
		}

		// Token: 0x06029671 RID: 169585 RVA: 0x00A2D3D7 File Offset: 0x00A2B5D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3EFDF07D4FD050E5EB594180CDB697E9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3EFDF07D4FD050E5EB594180CDB697E9_NativeFunctionPtr, null);
		}

		// Token: 0x06029672 RID: 169586 RVA: 0x00A2D3EB File Offset: 0x00A2B5EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_BEABB8B74A8AF50AC323A58492A284FA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_BEABB8B74A8AF50AC323A58492A284FA_NativeFunctionPtr, null);
		}

		// Token: 0x06029673 RID: 169587 RVA: 0x00A2D3FF File Offset: 0x00A2B5FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4011E1F74B95B177D00682ABCCEE49F6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4011E1F74B95B177D00682ABCCEE49F6_NativeFunctionPtr, null);
		}

		// Token: 0x06029674 RID: 169588 RVA: 0x00A2D413 File Offset: 0x00A2B613
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_02C602CB47D1E8619F13428F7F1DA261()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_02C602CB47D1E8619F13428F7F1DA261_NativeFunctionPtr, null);
		}

		// Token: 0x06029675 RID: 169589 RVA: 0x00A2D427 File Offset: 0x00A2B627
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_72F3A2BB4F4A556E7B24B8A5184A37E6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_72F3A2BB4F4A556E7B24B8A5184A37E6_NativeFunctionPtr, null);
		}

		// Token: 0x06029676 RID: 169590 RVA: 0x00A2D43B File Offset: 0x00A2B63B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_79EBF4C84DD2551BF3CB46AE68F7DD88()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_79EBF4C84DD2551BF3CB46AE68F7DD88_NativeFunctionPtr, null);
		}

		// Token: 0x06029677 RID: 169591 RVA: 0x00A2D44F File Offset: 0x00A2B64F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3771CB0C4EAD2AFD136042AE037B79EB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3771CB0C4EAD2AFD136042AE037B79EB_NativeFunctionPtr, null);
		}

		// Token: 0x06029678 RID: 169592 RVA: 0x00A2D463 File Offset: 0x00A2B663
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_FA7F519243AFD284C3211484957D57B9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_FA7F519243AFD284C3211484957D57B9_NativeFunctionPtr, null);
		}

		// Token: 0x06029679 RID: 169593 RVA: 0x00A2D477 File Offset: 0x00A2B677
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_BlendSpacePlayer_2073722D4A06F16CB6109BA33AC20BB6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_BlendSpacePlayer_2073722D4A06F16CB6109BA33AC20BB6_NativeFunctionPtr, null);
		}

		// Token: 0x0602967A RID: 169594 RVA: 0x00A2D48B File Offset: 0x00A2B68B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_0993A9D24512A908213680B985A6C83A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_0993A9D24512A908213680B985A6C83A_NativeFunctionPtr, null);
		}

		// Token: 0x0602967B RID: 169595 RVA: 0x00A2D49F File Offset: 0x00A2B69F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AA76503044E5351E69C68EB9A653AA54()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AA76503044E5351E69C68EB9A653AA54_NativeFunctionPtr, null);
		}

		// Token: 0x0602967C RID: 169596 RVA: 0x00A2D4B3 File Offset: 0x00A2B6B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6BBE26EC4B40D6825092F9B1D0E4DB67()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6BBE26EC4B40D6825092F9B1D0E4DB67_NativeFunctionPtr, null);
		}

		// Token: 0x0602967D RID: 169597 RVA: 0x00A2D4C7 File Offset: 0x00A2B6C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_8013F6F9413EF6908532A78B82D29676()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_8013F6F9413EF6908532A78B82D29676_NativeFunctionPtr, null);
		}

		// Token: 0x0602967E RID: 169598 RVA: 0x00A2D4DB File Offset: 0x00A2B6DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_31D2714540C263C0D17219B6A1DF0FA4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_31D2714540C263C0D17219B6A1DF0FA4_NativeFunctionPtr, null);
		}

		// Token: 0x0602967F RID: 169599 RVA: 0x00A2D4EF File Offset: 0x00A2B6EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_FE63B7434CEB89D7670BD7975C13F0E4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_FE63B7434CEB89D7670BD7975C13F0E4_NativeFunctionPtr, null);
		}

		// Token: 0x06029680 RID: 169600 RVA: 0x00A2D503 File Offset: 0x00A2B703
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7FC7E3A6406282492037229EE657036C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7FC7E3A6406282492037229EE657036C_NativeFunctionPtr, null);
		}

		// Token: 0x06029681 RID: 169601 RVA: 0x00A2D517 File Offset: 0x00A2B717
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AE68771C4D6376E69B71FEB86B8E368B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AE68771C4D6376E69B71FEB86B8E368B_NativeFunctionPtr, null);
		}

		// Token: 0x06029682 RID: 169602 RVA: 0x00A2D52B File Offset: 0x00A2B72B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_EE2ADAA744E2F1446AB0C48A939DC017()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_EE2ADAA744E2F1446AB0C48A939DC017_NativeFunctionPtr, null);
		}

		// Token: 0x06029683 RID: 169603 RVA: 0x00A2D53F File Offset: 0x00A2B73F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A72D3CD24316C81A325B60B20E2D8864()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A72D3CD24316C81A325B60B20E2D8864_NativeFunctionPtr, null);
		}

		// Token: 0x06029684 RID: 169604 RVA: 0x00A2D553 File Offset: 0x00A2B753
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B0C896AF480D856136EE68A07CEA20EF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B0C896AF480D856136EE68A07CEA20EF_NativeFunctionPtr, null);
		}

		// Token: 0x06029685 RID: 169605 RVA: 0x00A2D567 File Offset: 0x00A2B767
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3536A38A43AFC465EF869DB2F37E9EA5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3536A38A43AFC465EF869DB2F37E9EA5_NativeFunctionPtr, null);
		}

		// Token: 0x06029686 RID: 169606 RVA: 0x00A2D57B File Offset: 0x00A2B77B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9DC369304BF3B690BE7DBD8F912F9059()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9DC369304BF3B690BE7DBD8F912F9059_NativeFunctionPtr, null);
		}

		// Token: 0x06029687 RID: 169607 RVA: 0x00A2D58F File Offset: 0x00A2B78F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_D9897C694F1DAA0A0BDC6C8F2BAC0BE9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_D9897C694F1DAA0A0BDC6C8F2BAC0BE9_NativeFunctionPtr, null);
		}

		// Token: 0x06029688 RID: 169608 RVA: 0x00A2D5A3 File Offset: 0x00A2B7A3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7A77CC8C4A2B3C82B5CDD688DDE5006A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7A77CC8C4A2B3C82B5CDD688DDE5006A_NativeFunctionPtr, null);
		}

		// Token: 0x06029689 RID: 169609 RVA: 0x00A2D5B7 File Offset: 0x00A2B7B7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_748564454E64C3AD361415877CB0D61A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_748564454E64C3AD361415877CB0D61A_NativeFunctionPtr, null);
		}

		// Token: 0x0602968A RID: 169610 RVA: 0x00A2D5CB File Offset: 0x00A2B7CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_12AA937643B103D033CB0199C6C961D9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_12AA937643B103D033CB0199C6C961D9_NativeFunctionPtr, null);
		}

		// Token: 0x0602968B RID: 169611 RVA: 0x00A2D5DF File Offset: 0x00A2B7DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_03FDD14F4C073AAE19180E932B7DB3F7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_03FDD14F4C073AAE19180E932B7DB3F7_NativeFunctionPtr, null);
		}

		// Token: 0x0602968C RID: 169612 RVA: 0x00A2D5F3 File Offset: 0x00A2B7F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_CEEF249D457C8A62425DEA93676DC486()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_CEEF249D457C8A62425DEA93676DC486_NativeFunctionPtr, null);
		}

		// Token: 0x0602968D RID: 169613 RVA: 0x00A2D607 File Offset: 0x00A2B807
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B1B89D7544E981DDAA93A1A66B0DD3FE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B1B89D7544E981DDAA93A1A66B0DD3FE_NativeFunctionPtr, null);
		}

		// Token: 0x0602968E RID: 169614 RVA: 0x00A2D61C File Offset: 0x00A2B81C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602968F RID: 169615 RVA: 0x00A2D664 File Offset: 0x00A2B864
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Calbrena_Special_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029690 RID: 169616 RVA: 0x00A2D6AB File Offset: 0x00A2B8AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x06029691 RID: 169617 RVA: 0x00A2D6BF File Offset: 0x00A2B8BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Calbrena_Special_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029692 RID: 169618 RVA: 0x00A2D6D4 File Offset: 0x00A2B8D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x06029693 RID: 169619 RVA: 0x00A2D6E8 File Offset: 0x00A2B8E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Calbrena_Special_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06029694 RID: 169620 RVA: 0x00A2D6FD File Offset: 0x00A2B8FD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_退出攀爬()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__AnimNotify_退出攀爬_NativeFunctionPtr, null);
		}

		// Token: 0x06029695 RID: 169621 RVA: 0x00A2D711 File Offset: 0x00A2B911
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_ExitFlyingFeather()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Calbrena_Special_C.__AnimNotify_ExitFlyingFeather_NativeFunctionPtr, null);
		}

		// Token: 0x06029696 RID: 169622 RVA: 0x00A2D728 File Offset: 0x00A2B928
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Calbrena_Special(int EntryPoint)
		{
			ABP_Calbrena_Special_C.__ExecuteUbergraph_ABP_Calbrena_Special_FunctionParams* ptr = stackalloc ABP_Calbrena_Special_C.__ExecuteUbergraph_ABP_Calbrena_Special_FunctionParams[(UIntPtr)2463] + 15L / (long)sizeof(ABP_Calbrena_Special_C.__ExecuteUbergraph_ABP_Calbrena_Special_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Calbrena_Special_C.__ExecuteUbergraph_ABP_Calbrena_Special_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Calbrena_Special_C.__ExecuteUbergraph_ABP_Calbrena_Special_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06029697 RID: 169623 RVA: 0x00A2D772 File Offset: 0x00A2B972
		protected ABP_Calbrena_Special_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015DFC RID: 89596
		public new const string __ObjectPath = "/Game/Aki/Character/Role/FemaleXL/Jiabeilina_FP/ABP_Calbrena_Special.ABP_Calbrena_Special_C";

		// Token: 0x04015DFD RID: 89597
		private static IntPtr _ClassPtr;

		// Token: 0x04015DFE RID: 89598
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015DFF RID: 89599
		internal static int __PropertyOffset_0;

		// Token: 0x04015E00 RID: 89600
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015E01 RID: 89601
		internal static int __PropertyOffset_1;

		// Token: 0x04015E02 RID: 89602
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_5;

		// Token: 0x04015E03 RID: 89603
		internal static int __PropertyOffset_2;

		// Token: 0x04015E04 RID: 89604
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_33;

		// Token: 0x04015E05 RID: 89605
		internal static int __PropertyOffset_3;

		// Token: 0x04015E06 RID: 89606
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_4;

		// Token: 0x04015E07 RID: 89607
		internal static int __PropertyOffset_4;

		// Token: 0x04015E08 RID: 89608
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_32;

		// Token: 0x04015E09 RID: 89609
		internal static int __PropertyOffset_5;

		// Token: 0x04015E0A RID: 89610
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_51;

		// Token: 0x04015E0B RID: 89611
		internal static int __PropertyOffset_6;

		// Token: 0x04015E0C RID: 89612
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_11;

		// Token: 0x04015E0D RID: 89613
		internal static int __PropertyOffset_7;

		// Token: 0x04015E0E RID: 89614
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04015E0F RID: 89615
		internal static int __PropertyOffset_8;

		// Token: 0x04015E10 RID: 89616
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_3;

		// Token: 0x04015E11 RID: 89617
		internal static int __PropertyOffset_9;

		// Token: 0x04015E12 RID: 89618
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_9;

		// Token: 0x04015E13 RID: 89619
		internal static int __PropertyOffset_10;

		// Token: 0x04015E14 RID: 89620
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_8;

		// Token: 0x04015E15 RID: 89621
		internal static int __PropertyOffset_11;

		// Token: 0x04015E16 RID: 89622
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_7;

		// Token: 0x04015E17 RID: 89623
		internal static int __PropertyOffset_12;

		// Token: 0x04015E18 RID: 89624
		[Nullable(2)]
		private FAnimNode_AdditiveBoneBlend _AnimGraphNode_AdditiveBoneBlend;

		// Token: 0x04015E19 RID: 89625
		internal static int __PropertyOffset_13;

		// Token: 0x04015E1A RID: 89626
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_122;

		// Token: 0x04015E1B RID: 89627
		internal static int __PropertyOffset_14;

		// Token: 0x04015E1C RID: 89628
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_121;

		// Token: 0x04015E1D RID: 89629
		internal static int __PropertyOffset_15;

		// Token: 0x04015E1E RID: 89630
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_36;

		// Token: 0x04015E1F RID: 89631
		internal static int __PropertyOffset_16;

		// Token: 0x04015E20 RID: 89632
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_50;

		// Token: 0x04015E21 RID: 89633
		internal static int __PropertyOffset_17;

		// Token: 0x04015E22 RID: 89634
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_35;

		// Token: 0x04015E23 RID: 89635
		internal static int __PropertyOffset_18;

		// Token: 0x04015E24 RID: 89636
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_49;

		// Token: 0x04015E25 RID: 89637
		internal static int __PropertyOffset_19;

		// Token: 0x04015E26 RID: 89638
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_10;

		// Token: 0x04015E27 RID: 89639
		internal static int __PropertyOffset_20;

		// Token: 0x04015E28 RID: 89640
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_13;

		// Token: 0x04015E29 RID: 89641
		internal static int __PropertyOffset_21;

		// Token: 0x04015E2A RID: 89642
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_12;

		// Token: 0x04015E2B RID: 89643
		internal static int __PropertyOffset_22;

		// Token: 0x04015E2C RID: 89644
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_11;

		// Token: 0x04015E2D RID: 89645
		internal static int __PropertyOffset_23;

		// Token: 0x04015E2E RID: 89646
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_34;

		// Token: 0x04015E2F RID: 89647
		internal static int __PropertyOffset_24;

		// Token: 0x04015E30 RID: 89648
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_33;

		// Token: 0x04015E31 RID: 89649
		internal static int __PropertyOffset_25;

		// Token: 0x04015E32 RID: 89650
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_32;

		// Token: 0x04015E33 RID: 89651
		internal static int __PropertyOffset_26;

		// Token: 0x04015E34 RID: 89652
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_10;

		// Token: 0x04015E35 RID: 89653
		internal static int __PropertyOffset_27;

		// Token: 0x04015E36 RID: 89654
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x04015E37 RID: 89655
		internal static int __PropertyOffset_28;

		// Token: 0x04015E38 RID: 89656
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_120;

		// Token: 0x04015E39 RID: 89657
		internal static int __PropertyOffset_29;

		// Token: 0x04015E3A RID: 89658
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_119;

		// Token: 0x04015E3B RID: 89659
		internal static int __PropertyOffset_30;

		// Token: 0x04015E3C RID: 89660
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_118;

		// Token: 0x04015E3D RID: 89661
		internal static int __PropertyOffset_31;

		// Token: 0x04015E3E RID: 89662
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_117;

		// Token: 0x04015E3F RID: 89663
		internal static int __PropertyOffset_32;

		// Token: 0x04015E40 RID: 89664
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_116;

		// Token: 0x04015E41 RID: 89665
		internal static int __PropertyOffset_33;

		// Token: 0x04015E42 RID: 89666
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_115;

		// Token: 0x04015E43 RID: 89667
		internal static int __PropertyOffset_34;

		// Token: 0x04015E44 RID: 89668
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_114;

		// Token: 0x04015E45 RID: 89669
		internal static int __PropertyOffset_35;

		// Token: 0x04015E46 RID: 89670
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_31;

		// Token: 0x04015E47 RID: 89671
		internal static int __PropertyOffset_36;

		// Token: 0x04015E48 RID: 89672
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_48;

		// Token: 0x04015E49 RID: 89673
		internal static int __PropertyOffset_37;

		// Token: 0x04015E4A RID: 89674
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_113;

		// Token: 0x04015E4B RID: 89675
		internal static int __PropertyOffset_38;

		// Token: 0x04015E4C RID: 89676
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_112;

		// Token: 0x04015E4D RID: 89677
		internal static int __PropertyOffset_39;

		// Token: 0x04015E4E RID: 89678
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_111;

		// Token: 0x04015E4F RID: 89679
		internal static int __PropertyOffset_40;

		// Token: 0x04015E50 RID: 89680
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_110;

		// Token: 0x04015E51 RID: 89681
		internal static int __PropertyOffset_41;

		// Token: 0x04015E52 RID: 89682
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_30;

		// Token: 0x04015E53 RID: 89683
		internal static int __PropertyOffset_42;

		// Token: 0x04015E54 RID: 89684
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_47;

		// Token: 0x04015E55 RID: 89685
		internal static int __PropertyOffset_43;

		// Token: 0x04015E56 RID: 89686
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_29;

		// Token: 0x04015E57 RID: 89687
		internal static int __PropertyOffset_44;

		// Token: 0x04015E58 RID: 89688
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_46;

		// Token: 0x04015E59 RID: 89689
		internal static int __PropertyOffset_45;

		// Token: 0x04015E5A RID: 89690
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_28;

		// Token: 0x04015E5B RID: 89691
		internal static int __PropertyOffset_46;

		// Token: 0x04015E5C RID: 89692
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_45;

		// Token: 0x04015E5D RID: 89693
		internal static int __PropertyOffset_47;

		// Token: 0x04015E5E RID: 89694
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_27;

		// Token: 0x04015E5F RID: 89695
		internal static int __PropertyOffset_48;

		// Token: 0x04015E60 RID: 89696
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_44;

		// Token: 0x04015E61 RID: 89697
		internal static int __PropertyOffset_49;

		// Token: 0x04015E62 RID: 89698
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_9;

		// Token: 0x04015E63 RID: 89699
		internal static int __PropertyOffset_50;

		// Token: 0x04015E64 RID: 89700
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_43;

		// Token: 0x04015E65 RID: 89701
		internal static int __PropertyOffset_51;

		// Token: 0x04015E66 RID: 89702
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_109;

		// Token: 0x04015E67 RID: 89703
		internal static int __PropertyOffset_52;

		// Token: 0x04015E68 RID: 89704
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_108;

		// Token: 0x04015E69 RID: 89705
		internal static int __PropertyOffset_53;

		// Token: 0x04015E6A RID: 89706
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_107;

		// Token: 0x04015E6B RID: 89707
		internal static int __PropertyOffset_54;

		// Token: 0x04015E6C RID: 89708
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_106;

		// Token: 0x04015E6D RID: 89709
		internal static int __PropertyOffset_55;

		// Token: 0x04015E6E RID: 89710
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_105;

		// Token: 0x04015E6F RID: 89711
		internal static int __PropertyOffset_56;

		// Token: 0x04015E70 RID: 89712
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_104;

		// Token: 0x04015E71 RID: 89713
		internal static int __PropertyOffset_57;

		// Token: 0x04015E72 RID: 89714
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_103;

		// Token: 0x04015E73 RID: 89715
		internal static int __PropertyOffset_58;

		// Token: 0x04015E74 RID: 89716
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_102;

		// Token: 0x04015E75 RID: 89717
		internal static int __PropertyOffset_59;

		// Token: 0x04015E76 RID: 89718
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_101;

		// Token: 0x04015E77 RID: 89719
		internal static int __PropertyOffset_60;

		// Token: 0x04015E78 RID: 89720
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_100;

		// Token: 0x04015E79 RID: 89721
		internal static int __PropertyOffset_61;

		// Token: 0x04015E7A RID: 89722
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_99;

		// Token: 0x04015E7B RID: 89723
		internal static int __PropertyOffset_62;

		// Token: 0x04015E7C RID: 89724
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_98;

		// Token: 0x04015E7D RID: 89725
		internal static int __PropertyOffset_63;

		// Token: 0x04015E7E RID: 89726
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_97;

		// Token: 0x04015E7F RID: 89727
		internal static int __PropertyOffset_64;

		// Token: 0x04015E80 RID: 89728
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_96;

		// Token: 0x04015E81 RID: 89729
		internal static int __PropertyOffset_65;

		// Token: 0x04015E82 RID: 89730
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_95;

		// Token: 0x04015E83 RID: 89731
		internal static int __PropertyOffset_66;

		// Token: 0x04015E84 RID: 89732
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_94;

		// Token: 0x04015E85 RID: 89733
		internal static int __PropertyOffset_67;

		// Token: 0x04015E86 RID: 89734
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_93;

		// Token: 0x04015E87 RID: 89735
		internal static int __PropertyOffset_68;

		// Token: 0x04015E88 RID: 89736
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_92;

		// Token: 0x04015E89 RID: 89737
		internal static int __PropertyOffset_69;

		// Token: 0x04015E8A RID: 89738
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_91;

		// Token: 0x04015E8B RID: 89739
		internal static int __PropertyOffset_70;

		// Token: 0x04015E8C RID: 89740
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_90;

		// Token: 0x04015E8D RID: 89741
		internal static int __PropertyOffset_71;

		// Token: 0x04015E8E RID: 89742
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_89;

		// Token: 0x04015E8F RID: 89743
		internal static int __PropertyOffset_72;

		// Token: 0x04015E90 RID: 89744
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_26;

		// Token: 0x04015E91 RID: 89745
		internal static int __PropertyOffset_73;

		// Token: 0x04015E92 RID: 89746
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_42;

		// Token: 0x04015E93 RID: 89747
		internal static int __PropertyOffset_74;

		// Token: 0x04015E94 RID: 89748
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_25;

		// Token: 0x04015E95 RID: 89749
		internal static int __PropertyOffset_75;

		// Token: 0x04015E96 RID: 89750
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_41;

		// Token: 0x04015E97 RID: 89751
		internal static int __PropertyOffset_76;

		// Token: 0x04015E98 RID: 89752
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_13;

		// Token: 0x04015E99 RID: 89753
		internal static int __PropertyOffset_77;

		// Token: 0x04015E9A RID: 89754
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_40;

		// Token: 0x04015E9B RID: 89755
		internal static int __PropertyOffset_78;

		// Token: 0x04015E9C RID: 89756
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_88;

		// Token: 0x04015E9D RID: 89757
		internal static int __PropertyOffset_79;

		// Token: 0x04015E9E RID: 89758
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_87;

		// Token: 0x04015E9F RID: 89759
		internal static int __PropertyOffset_80;

		// Token: 0x04015EA0 RID: 89760
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_86;

		// Token: 0x04015EA1 RID: 89761
		internal static int __PropertyOffset_81;

		// Token: 0x04015EA2 RID: 89762
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_85;

		// Token: 0x04015EA3 RID: 89763
		internal static int __PropertyOffset_82;

		// Token: 0x04015EA4 RID: 89764
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_84;

		// Token: 0x04015EA5 RID: 89765
		internal static int __PropertyOffset_83;

		// Token: 0x04015EA6 RID: 89766
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_83;

		// Token: 0x04015EA7 RID: 89767
		internal static int __PropertyOffset_84;

		// Token: 0x04015EA8 RID: 89768
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_24;

		// Token: 0x04015EA9 RID: 89769
		internal static int __PropertyOffset_85;

		// Token: 0x04015EAA RID: 89770
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_12;

		// Token: 0x04015EAB RID: 89771
		internal static int __PropertyOffset_86;

		// Token: 0x04015EAC RID: 89772
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_5;

		// Token: 0x04015EAD RID: 89773
		internal static int __PropertyOffset_87;

		// Token: 0x04015EAE RID: 89774
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_39;

		// Token: 0x04015EAF RID: 89775
		internal static int __PropertyOffset_88;

		// Token: 0x04015EB0 RID: 89776
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_11;

		// Token: 0x04015EB1 RID: 89777
		internal static int __PropertyOffset_89;

		// Token: 0x04015EB2 RID: 89778
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_38;

		// Token: 0x04015EB3 RID: 89779
		internal static int __PropertyOffset_90;

		// Token: 0x04015EB4 RID: 89780
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_23;

		// Token: 0x04015EB5 RID: 89781
		internal static int __PropertyOffset_91;

		// Token: 0x04015EB6 RID: 89782
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_10;

		// Token: 0x04015EB7 RID: 89783
		internal static int __PropertyOffset_92;

		// Token: 0x04015EB8 RID: 89784
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_4;

		// Token: 0x04015EB9 RID: 89785
		internal static int __PropertyOffset_93;

		// Token: 0x04015EBA RID: 89786
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_37;

		// Token: 0x04015EBB RID: 89787
		internal static int __PropertyOffset_94;

		// Token: 0x04015EBC RID: 89788
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_36;

		// Token: 0x04015EBD RID: 89789
		internal static int __PropertyOffset_95;

		// Token: 0x04015EBE RID: 89790
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_8;

		// Token: 0x04015EBF RID: 89791
		internal static int __PropertyOffset_96;

		// Token: 0x04015EC0 RID: 89792
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_35;

		// Token: 0x04015EC1 RID: 89793
		internal static int __PropertyOffset_97;

		// Token: 0x04015EC2 RID: 89794
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_82;

		// Token: 0x04015EC3 RID: 89795
		internal static int __PropertyOffset_98;

		// Token: 0x04015EC4 RID: 89796
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_22;

		// Token: 0x04015EC5 RID: 89797
		internal static int __PropertyOffset_99;

		// Token: 0x04015EC6 RID: 89798
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_3;

		// Token: 0x04015EC7 RID: 89799
		internal static int __PropertyOffset_100;

		// Token: 0x04015EC8 RID: 89800
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_9;

		// Token: 0x04015EC9 RID: 89801
		internal static int __PropertyOffset_101;

		// Token: 0x04015ECA RID: 89802
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_34;

		// Token: 0x04015ECB RID: 89803
		internal static int __PropertyOffset_102;

		// Token: 0x04015ECC RID: 89804
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_81;

		// Token: 0x04015ECD RID: 89805
		internal static int __PropertyOffset_103;

		// Token: 0x04015ECE RID: 89806
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_80;

		// Token: 0x04015ECF RID: 89807
		internal static int __PropertyOffset_104;

		// Token: 0x04015ED0 RID: 89808
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_79;

		// Token: 0x04015ED1 RID: 89809
		internal static int __PropertyOffset_105;

		// Token: 0x04015ED2 RID: 89810
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_78;

		// Token: 0x04015ED3 RID: 89811
		internal static int __PropertyOffset_106;

		// Token: 0x04015ED4 RID: 89812
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_77;

		// Token: 0x04015ED5 RID: 89813
		internal static int __PropertyOffset_107;

		// Token: 0x04015ED6 RID: 89814
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_33;

		// Token: 0x04015ED7 RID: 89815
		internal static int __PropertyOffset_108;

		// Token: 0x04015ED8 RID: 89816
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_21;

		// Token: 0x04015ED9 RID: 89817
		internal static int __PropertyOffset_109;

		// Token: 0x04015EDA RID: 89818
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_32;

		// Token: 0x04015EDB RID: 89819
		internal static int __PropertyOffset_110;

		// Token: 0x04015EDC RID: 89820
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_8;

		// Token: 0x04015EDD RID: 89821
		internal static int __PropertyOffset_111;

		// Token: 0x04015EDE RID: 89822
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_31;

		// Token: 0x04015EDF RID: 89823
		internal static int __PropertyOffset_112;

		// Token: 0x04015EE0 RID: 89824
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_7;

		// Token: 0x04015EE1 RID: 89825
		internal static int __PropertyOffset_113;

		// Token: 0x04015EE2 RID: 89826
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_30;

		// Token: 0x04015EE3 RID: 89827
		internal static int __PropertyOffset_114;

		// Token: 0x04015EE4 RID: 89828
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_20;

		// Token: 0x04015EE5 RID: 89829
		internal static int __PropertyOffset_115;

		// Token: 0x04015EE6 RID: 89830
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x04015EE7 RID: 89831
		internal static int __PropertyOffset_116;

		// Token: 0x04015EE8 RID: 89832
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_7;

		// Token: 0x04015EE9 RID: 89833
		internal static int __PropertyOffset_117;

		// Token: 0x04015EEA RID: 89834
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x04015EEB RID: 89835
		internal static int __PropertyOffset_118;

		// Token: 0x04015EEC RID: 89836
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_31;

		// Token: 0x04015EED RID: 89837
		internal static int __PropertyOffset_119;

		// Token: 0x04015EEE RID: 89838
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x04015EEF RID: 89839
		internal static int __PropertyOffset_120;

		// Token: 0x04015EF0 RID: 89840
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_6;

		// Token: 0x04015EF1 RID: 89841
		internal static int __PropertyOffset_121;

		// Token: 0x04015EF2 RID: 89842
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x04015EF3 RID: 89843
		internal static int __PropertyOffset_122;

		// Token: 0x04015EF4 RID: 89844
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_5;

		// Token: 0x04015EF5 RID: 89845
		internal static int __PropertyOffset_123;

		// Token: 0x04015EF6 RID: 89846
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_19;

		// Token: 0x04015EF7 RID: 89847
		internal static int __PropertyOffset_124;

		// Token: 0x04015EF8 RID: 89848
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_4;

		// Token: 0x04015EF9 RID: 89849
		internal static int __PropertyOffset_125;

		// Token: 0x04015EFA RID: 89850
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_2;

		// Token: 0x04015EFB RID: 89851
		internal static int __PropertyOffset_126;

		// Token: 0x04015EFC RID: 89852
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_6;

		// Token: 0x04015EFD RID: 89853
		internal static int __PropertyOffset_127;

		// Token: 0x04015EFE RID: 89854
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_5;

		// Token: 0x04015EFF RID: 89855
		internal static int __PropertyOffset_128;

		// Token: 0x04015F00 RID: 89856
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_4;

		// Token: 0x04015F01 RID: 89857
		internal static int __PropertyOffset_129;

		// Token: 0x04015F02 RID: 89858
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_3;

		// Token: 0x04015F03 RID: 89859
		internal static int __PropertyOffset_130;

		// Token: 0x04015F04 RID: 89860
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_2;

		// Token: 0x04015F05 RID: 89861
		internal static int __PropertyOffset_131;

		// Token: 0x04015F06 RID: 89862
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x04015F07 RID: 89863
		internal static int __PropertyOffset_132;

		// Token: 0x04015F08 RID: 89864
		[Nullable(2)]
		private FAnimNode_TwoWayBlend _AnimGraphNode_TwoWayBlend_1;

		// Token: 0x04015F09 RID: 89865
		internal static int __PropertyOffset_133;

		// Token: 0x04015F0A RID: 89866
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_18;

		// Token: 0x04015F0B RID: 89867
		internal static int __PropertyOffset_134;

		// Token: 0x04015F0C RID: 89868
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04015F0D RID: 89869
		internal static int __PropertyOffset_135;

		// Token: 0x04015F0E RID: 89870
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x04015F0F RID: 89871
		internal static int __PropertyOffset_136;

		// Token: 0x04015F10 RID: 89872
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x04015F11 RID: 89873
		internal static int __PropertyOffset_137;

		// Token: 0x04015F12 RID: 89874
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_76;

		// Token: 0x04015F13 RID: 89875
		internal static int __PropertyOffset_138;

		// Token: 0x04015F14 RID: 89876
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_75;

		// Token: 0x04015F15 RID: 89877
		internal static int __PropertyOffset_139;

		// Token: 0x04015F16 RID: 89878
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_74;

		// Token: 0x04015F17 RID: 89879
		internal static int __PropertyOffset_140;

		// Token: 0x04015F18 RID: 89880
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_73;

		// Token: 0x04015F19 RID: 89881
		internal static int __PropertyOffset_141;

		// Token: 0x04015F1A RID: 89882
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_72;

		// Token: 0x04015F1B RID: 89883
		internal static int __PropertyOffset_142;

		// Token: 0x04015F1C RID: 89884
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_71;

		// Token: 0x04015F1D RID: 89885
		internal static int __PropertyOffset_143;

		// Token: 0x04015F1E RID: 89886
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_70;

		// Token: 0x04015F1F RID: 89887
		internal static int __PropertyOffset_144;

		// Token: 0x04015F20 RID: 89888
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_69;

		// Token: 0x04015F21 RID: 89889
		internal static int __PropertyOffset_145;

		// Token: 0x04015F22 RID: 89890
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_68;

		// Token: 0x04015F23 RID: 89891
		internal static int __PropertyOffset_146;

		// Token: 0x04015F24 RID: 89892
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_67;

		// Token: 0x04015F25 RID: 89893
		internal static int __PropertyOffset_147;

		// Token: 0x04015F26 RID: 89894
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_66;

		// Token: 0x04015F27 RID: 89895
		internal static int __PropertyOffset_148;

		// Token: 0x04015F28 RID: 89896
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_65;

		// Token: 0x04015F29 RID: 89897
		internal static int __PropertyOffset_149;

		// Token: 0x04015F2A RID: 89898
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_64;

		// Token: 0x04015F2B RID: 89899
		internal static int __PropertyOffset_150;

		// Token: 0x04015F2C RID: 89900
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_63;

		// Token: 0x04015F2D RID: 89901
		internal static int __PropertyOffset_151;

		// Token: 0x04015F2E RID: 89902
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_62;

		// Token: 0x04015F2F RID: 89903
		internal static int __PropertyOffset_152;

		// Token: 0x04015F30 RID: 89904
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_61;

		// Token: 0x04015F31 RID: 89905
		internal static int __PropertyOffset_153;

		// Token: 0x04015F32 RID: 89906
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_60;

		// Token: 0x04015F33 RID: 89907
		internal static int __PropertyOffset_154;

		// Token: 0x04015F34 RID: 89908
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_59;

		// Token: 0x04015F35 RID: 89909
		internal static int __PropertyOffset_155;

		// Token: 0x04015F36 RID: 89910
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_58;

		// Token: 0x04015F37 RID: 89911
		internal static int __PropertyOffset_156;

		// Token: 0x04015F38 RID: 89912
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_57;

		// Token: 0x04015F39 RID: 89913
		internal static int __PropertyOffset_157;

		// Token: 0x04015F3A RID: 89914
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_56;

		// Token: 0x04015F3B RID: 89915
		internal static int __PropertyOffset_158;

		// Token: 0x04015F3C RID: 89916
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_55;

		// Token: 0x04015F3D RID: 89917
		internal static int __PropertyOffset_159;

		// Token: 0x04015F3E RID: 89918
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_54;

		// Token: 0x04015F3F RID: 89919
		internal static int __PropertyOffset_160;

		// Token: 0x04015F40 RID: 89920
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_53;

		// Token: 0x04015F41 RID: 89921
		internal static int __PropertyOffset_161;

		// Token: 0x04015F42 RID: 89922
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_52;

		// Token: 0x04015F43 RID: 89923
		internal static int __PropertyOffset_162;

		// Token: 0x04015F44 RID: 89924
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_51;

		// Token: 0x04015F45 RID: 89925
		internal static int __PropertyOffset_163;

		// Token: 0x04015F46 RID: 89926
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_50;

		// Token: 0x04015F47 RID: 89927
		internal static int __PropertyOffset_164;

		// Token: 0x04015F48 RID: 89928
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_49;

		// Token: 0x04015F49 RID: 89929
		internal static int __PropertyOffset_165;

		// Token: 0x04015F4A RID: 89930
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_48;

		// Token: 0x04015F4B RID: 89931
		internal static int __PropertyOffset_166;

		// Token: 0x04015F4C RID: 89932
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_47;

		// Token: 0x04015F4D RID: 89933
		internal static int __PropertyOffset_167;

		// Token: 0x04015F4E RID: 89934
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_46;

		// Token: 0x04015F4F RID: 89935
		internal static int __PropertyOffset_168;

		// Token: 0x04015F50 RID: 89936
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_45;

		// Token: 0x04015F51 RID: 89937
		internal static int __PropertyOffset_169;

		// Token: 0x04015F52 RID: 89938
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_44;

		// Token: 0x04015F53 RID: 89939
		internal static int __PropertyOffset_170;

		// Token: 0x04015F54 RID: 89940
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_17;

		// Token: 0x04015F55 RID: 89941
		internal static int __PropertyOffset_171;

		// Token: 0x04015F56 RID: 89942
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x04015F57 RID: 89943
		internal static int __PropertyOffset_172;

		// Token: 0x04015F58 RID: 89944
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_16;

		// Token: 0x04015F59 RID: 89945
		internal static int __PropertyOffset_173;

		// Token: 0x04015F5A RID: 89946
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x04015F5B RID: 89947
		internal static int __PropertyOffset_174;

		// Token: 0x04015F5C RID: 89948
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_43;

		// Token: 0x04015F5D RID: 89949
		internal static int __PropertyOffset_175;

		// Token: 0x04015F5E RID: 89950
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_15;

		// Token: 0x04015F5F RID: 89951
		internal static int __PropertyOffset_176;

		// Token: 0x04015F60 RID: 89952
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x04015F61 RID: 89953
		internal static int __PropertyOffset_177;

		// Token: 0x04015F62 RID: 89954
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_42;

		// Token: 0x04015F63 RID: 89955
		internal static int __PropertyOffset_178;

		// Token: 0x04015F64 RID: 89956
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_41;

		// Token: 0x04015F65 RID: 89957
		internal static int __PropertyOffset_179;

		// Token: 0x04015F66 RID: 89958
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_40;

		// Token: 0x04015F67 RID: 89959
		internal static int __PropertyOffset_180;

		// Token: 0x04015F68 RID: 89960
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_39;

		// Token: 0x04015F69 RID: 89961
		internal static int __PropertyOffset_181;

		// Token: 0x04015F6A RID: 89962
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_38;

		// Token: 0x04015F6B RID: 89963
		internal static int __PropertyOffset_182;

		// Token: 0x04015F6C RID: 89964
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_37;

		// Token: 0x04015F6D RID: 89965
		internal static int __PropertyOffset_183;

		// Token: 0x04015F6E RID: 89966
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_36;

		// Token: 0x04015F6F RID: 89967
		internal static int __PropertyOffset_184;

		// Token: 0x04015F70 RID: 89968
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_35;

		// Token: 0x04015F71 RID: 89969
		internal static int __PropertyOffset_185;

		// Token: 0x04015F72 RID: 89970
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_34;

		// Token: 0x04015F73 RID: 89971
		internal static int __PropertyOffset_186;

		// Token: 0x04015F74 RID: 89972
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x04015F75 RID: 89973
		internal static int __PropertyOffset_187;

		// Token: 0x04015F76 RID: 89974
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x04015F77 RID: 89975
		internal static int __PropertyOffset_188;

		// Token: 0x04015F78 RID: 89976
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x04015F79 RID: 89977
		internal static int __PropertyOffset_189;

		// Token: 0x04015F7A RID: 89978
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x04015F7B RID: 89979
		internal static int __PropertyOffset_190;

		// Token: 0x04015F7C RID: 89980
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x04015F7D RID: 89981
		internal static int __PropertyOffset_191;

		// Token: 0x04015F7E RID: 89982
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x04015F7F RID: 89983
		internal static int __PropertyOffset_192;

		// Token: 0x04015F80 RID: 89984
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x04015F81 RID: 89985
		internal static int __PropertyOffset_193;

		// Token: 0x04015F82 RID: 89986
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x04015F83 RID: 89987
		internal static int __PropertyOffset_194;

		// Token: 0x04015F84 RID: 89988
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x04015F85 RID: 89989
		internal static int __PropertyOffset_195;

		// Token: 0x04015F86 RID: 89990
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x04015F87 RID: 89991
		internal static int __PropertyOffset_196;

		// Token: 0x04015F88 RID: 89992
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x04015F89 RID: 89993
		internal static int __PropertyOffset_197;

		// Token: 0x04015F8A RID: 89994
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x04015F8B RID: 89995
		internal static int __PropertyOffset_198;

		// Token: 0x04015F8C RID: 89996
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x04015F8D RID: 89997
		internal static int __PropertyOffset_199;

		// Token: 0x04015F8E RID: 89998
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x04015F8F RID: 89999
		internal static int __PropertyOffset_200;

		// Token: 0x04015F90 RID: 90000
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x04015F91 RID: 90001
		internal static int __PropertyOffset_201;

		// Token: 0x04015F92 RID: 90002
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x04015F93 RID: 90003
		internal static int __PropertyOffset_202;

		// Token: 0x04015F94 RID: 90004
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x04015F95 RID: 90005
		internal static int __PropertyOffset_203;

		// Token: 0x04015F96 RID: 90006
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x04015F97 RID: 90007
		internal static int __PropertyOffset_204;

		// Token: 0x04015F98 RID: 90008
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x04015F99 RID: 90009
		internal static int __PropertyOffset_205;

		// Token: 0x04015F9A RID: 90010
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x04015F9B RID: 90011
		internal static int __PropertyOffset_206;

		// Token: 0x04015F9C RID: 90012
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x04015F9D RID: 90013
		internal static int __PropertyOffset_207;

		// Token: 0x04015F9E RID: 90014
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04015F9F RID: 90015
		internal static int __PropertyOffset_208;

		// Token: 0x04015FA0 RID: 90016
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04015FA1 RID: 90017
		internal static int __PropertyOffset_209;

		// Token: 0x04015FA2 RID: 90018
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x04015FA3 RID: 90019
		internal static int __PropertyOffset_210;

		// Token: 0x04015FA4 RID: 90020
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04015FA5 RID: 90021
		internal static int __PropertyOffset_211;

		// Token: 0x04015FA6 RID: 90022
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x04015FA7 RID: 90023
		internal static int __PropertyOffset_212;

		// Token: 0x04015FA8 RID: 90024
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x04015FA9 RID: 90025
		internal static int __PropertyOffset_213;

		// Token: 0x04015FAA RID: 90026
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04015FAB RID: 90027
		internal static int __PropertyOffset_214;

		// Token: 0x04015FAC RID: 90028
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04015FAD RID: 90029
		internal static int __PropertyOffset_215;

		// Token: 0x04015FAE RID: 90030
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04015FAF RID: 90031
		internal static int __PropertyOffset_216;

		// Token: 0x04015FB0 RID: 90032
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04015FB1 RID: 90033
		internal static int __PropertyOffset_217;

		// Token: 0x04015FB2 RID: 90034
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04015FB3 RID: 90035
		internal static int __PropertyOffset_218;

		// Token: 0x04015FB4 RID: 90036
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04015FB5 RID: 90037
		internal static int __PropertyOffset_219;

		// Token: 0x04015FB6 RID: 90038
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04015FB7 RID: 90039
		internal static int __PropertyOffset_220;

		// Token: 0x04015FB8 RID: 90040
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04015FB9 RID: 90041
		internal static int __PropertyOffset_221;

		// Token: 0x04015FBA RID: 90042
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04015FBB RID: 90043
		internal static int __PropertyOffset_222;

		// Token: 0x04015FBC RID: 90044
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_1;

		// Token: 0x04015FBD RID: 90045
		internal static int __PropertyOffset_223;

		// Token: 0x04015FBE RID: 90046
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_30;

		// Token: 0x04015FBF RID: 90047
		internal static int __PropertyOffset_224;

		// Token: 0x04015FC0 RID: 90048
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_7;

		// Token: 0x04015FC1 RID: 90049
		internal static int __PropertyOffset_225;

		// Token: 0x04015FC2 RID: 90050
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04015FC3 RID: 90051
		internal static int __PropertyOffset_226;

		// Token: 0x04015FC4 RID: 90052
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04015FC5 RID: 90053
		internal static int __PropertyOffset_227;

		// Token: 0x04015FC6 RID: 90054
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04015FC7 RID: 90055
		internal static int __PropertyOffset_228;

		// Token: 0x04015FC8 RID: 90056
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04015FC9 RID: 90057
		internal static int __PropertyOffset_229;

		// Token: 0x04015FCA RID: 90058
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04015FCB RID: 90059
		internal static int __PropertyOffset_230;

		// Token: 0x04015FCC RID: 90060
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x04015FCD RID: 90061
		internal static int __PropertyOffset_231;

		// Token: 0x04015FCE RID: 90062
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_29;

		// Token: 0x04015FCF RID: 90063
		internal static int __PropertyOffset_232;

		// Token: 0x04015FD0 RID: 90064
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_6;

		// Token: 0x04015FD1 RID: 90065
		internal static int __PropertyOffset_233;

		// Token: 0x04015FD2 RID: 90066
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04015FD3 RID: 90067
		internal static int __PropertyOffset_234;

		// Token: 0x04015FD4 RID: 90068
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_28;

		// Token: 0x04015FD5 RID: 90069
		internal static int __PropertyOffset_235;

		// Token: 0x04015FD6 RID: 90070
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04015FD7 RID: 90071
		internal static int __PropertyOffset_236;

		// Token: 0x04015FD8 RID: 90072
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_27;

		// Token: 0x04015FD9 RID: 90073
		internal static int __PropertyOffset_237;

		// Token: 0x04015FDA RID: 90074
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04015FDB RID: 90075
		internal static int __PropertyOffset_238;

		// Token: 0x04015FDC RID: 90076
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04015FDD RID: 90077
		internal static int __PropertyOffset_239;

		// Token: 0x04015FDE RID: 90078
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_9;

		// Token: 0x04015FDF RID: 90079
		internal static int __PropertyOffset_240;

		// Token: 0x04015FE0 RID: 90080
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_8;

		// Token: 0x04015FE1 RID: 90081
		internal static int __PropertyOffset_241;

		// Token: 0x04015FE2 RID: 90082
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04015FE3 RID: 90083
		internal static int __PropertyOffset_242;

		// Token: 0x04015FE4 RID: 90084
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04015FE5 RID: 90085
		internal static int __PropertyOffset_243;

		// Token: 0x04015FE6 RID: 90086
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_6;

		// Token: 0x04015FE7 RID: 90087
		internal static int __PropertyOffset_244;

		// Token: 0x04015FE8 RID: 90088
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_5;

		// Token: 0x04015FE9 RID: 90089
		internal static int __PropertyOffset_245;

		// Token: 0x04015FEA RID: 90090
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_4;

		// Token: 0x04015FEB RID: 90091
		internal static int __PropertyOffset_246;

		// Token: 0x04015FEC RID: 90092
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_3;

		// Token: 0x04015FED RID: 90093
		internal static int __PropertyOffset_247;

		// Token: 0x04015FEE RID: 90094
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_2;

		// Token: 0x04015FEF RID: 90095
		internal static int __PropertyOffset_248;

		// Token: 0x04015FF0 RID: 90096
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_1;

		// Token: 0x04015FF1 RID: 90097
		internal static int __PropertyOffset_249;

		// Token: 0x04015FF2 RID: 90098
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04015FF3 RID: 90099
		internal static int __PropertyOffset_250;

		// Token: 0x04015FF4 RID: 90100
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_7;

		// Token: 0x04015FF5 RID: 90101
		internal static int __PropertyOffset_251;

		// Token: 0x04015FF6 RID: 90102
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_6;

		// Token: 0x04015FF7 RID: 90103
		internal static int __PropertyOffset_252;

		// Token: 0x04015FF8 RID: 90104
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_5;

		// Token: 0x04015FF9 RID: 90105
		internal static int __PropertyOffset_253;

		// Token: 0x04015FFA RID: 90106
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_4;

		// Token: 0x04015FFB RID: 90107
		internal static int __PropertyOffset_254;

		// Token: 0x04015FFC RID: 90108
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_3;

		// Token: 0x04015FFD RID: 90109
		internal static int __PropertyOffset_255;

		// Token: 0x04015FFE RID: 90110
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_2;

		// Token: 0x04015FFF RID: 90111
		internal static int __PropertyOffset_256;

		// Token: 0x04016000 RID: 90112
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_26;

		// Token: 0x04016001 RID: 90113
		internal static int __PropertyOffset_257;

		// Token: 0x04016002 RID: 90114
		[Nullable(2)]
		private FAnimNode_TwoWayBlend _AnimGraphNode_TwoWayBlend;

		// Token: 0x04016003 RID: 90115
		internal static int __PropertyOffset_258;

		// Token: 0x04016004 RID: 90116
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x04016005 RID: 90117
		internal static int __PropertyOffset_259;

		// Token: 0x04016006 RID: 90118
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_1;

		// Token: 0x04016007 RID: 90119
		internal static int __PropertyOffset_260;

		// Token: 0x04016008 RID: 90120
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x04016009 RID: 90121
		internal static int __PropertyOffset_261;

		// Token: 0x0401600A RID: 90122
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x0401600B RID: 90123
		internal static int __PropertyOffset_262;

		// Token: 0x0401600C RID: 90124
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x0401600D RID: 90125
		internal static int __PropertyOffset_263;

		// Token: 0x0401600E RID: 90126
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x0401600F RID: 90127
		internal static int __PropertyOffset_264;

		// Token: 0x04016010 RID: 90128
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x04016011 RID: 90129
		internal static int __PropertyOffset_265;

		// Token: 0x04016012 RID: 90130
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04016013 RID: 90131
		internal static int __PropertyOffset_266;

		// Token: 0x04016014 RID: 90132
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04016015 RID: 90133
		internal static int __PropertyOffset_267;

		// Token: 0x04016016 RID: 90134
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04016017 RID: 90135
		internal static int __PropertyOffset_268;

		// Token: 0x04016018 RID: 90136
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04016019 RID: 90137
		internal static int __PropertyOffset_269;

		// Token: 0x0401601A RID: 90138
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x0401601B RID: 90139
		internal static int __PropertyOffset_270;

		// Token: 0x0401601C RID: 90140
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x0401601D RID: 90141
		internal static int __PropertyOffset_271;

		// Token: 0x0401601E RID: 90142
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x0401601F RID: 90143
		internal static int __PropertyOffset_272;

		// Token: 0x04016020 RID: 90144
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04016021 RID: 90145
		internal static int __PropertyOffset_273;

		// Token: 0x04016022 RID: 90146
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04016023 RID: 90147
		internal static int __PropertyOffset_274;

		// Token: 0x04016024 RID: 90148
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04016025 RID: 90149
		internal static int __PropertyOffset_275;

		// Token: 0x04016026 RID: 90150
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04016027 RID: 90151
		internal static int __PropertyOffset_276;

		// Token: 0x04016028 RID: 90152
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04016029 RID: 90153
		internal static int __PropertyOffset_277;

		// Token: 0x0401602A RID: 90154
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x0401602B RID: 90155
		internal static int __PropertyOffset_278;

		// Token: 0x0401602C RID: 90156
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x0401602D RID: 90157
		internal static int __PropertyOffset_279;

		// Token: 0x0401602E RID: 90158
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0401602F RID: 90159
		internal static int __PropertyOffset_280;

		// Token: 0x04016030 RID: 90160
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04016031 RID: 90161
		internal static int __PropertyOffset_281;

		// Token: 0x04016032 RID: 90162
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04016033 RID: 90163
		internal static int __PropertyOffset_282;

		// Token: 0x04016034 RID: 90164
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04016035 RID: 90165
		internal static int __PropertyOffset_283;

		// Token: 0x04016036 RID: 90166
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_25;

		// Token: 0x04016037 RID: 90167
		internal static int __PropertyOffset_284;

		// Token: 0x04016038 RID: 90168
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_5;

		// Token: 0x04016039 RID: 90169
		internal static int __PropertyOffset_285;

		// Token: 0x0401603A RID: 90170
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_24;

		// Token: 0x0401603B RID: 90171
		internal static int __PropertyOffset_286;

		// Token: 0x0401603C RID: 90172
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_23;

		// Token: 0x0401603D RID: 90173
		internal static int __PropertyOffset_287;

		// Token: 0x0401603E RID: 90174
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_22;

		// Token: 0x0401603F RID: 90175
		internal static int __PropertyOffset_288;

		// Token: 0x04016040 RID: 90176
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04016041 RID: 90177
		internal static int __PropertyOffset_289;

		// Token: 0x04016042 RID: 90178
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_21;

		// Token: 0x04016043 RID: 90179
		internal static int __PropertyOffset_290;

		// Token: 0x04016044 RID: 90180
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_4;

		// Token: 0x04016045 RID: 90181
		internal static int __PropertyOffset_291;

		// Token: 0x04016046 RID: 90182
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_20;

		// Token: 0x04016047 RID: 90183
		internal static int __PropertyOffset_292;

		// Token: 0x04016048 RID: 90184
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_19;

		// Token: 0x04016049 RID: 90185
		internal static int __PropertyOffset_293;

		// Token: 0x0401604A RID: 90186
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_18;

		// Token: 0x0401604B RID: 90187
		internal static int __PropertyOffset_294;

		// Token: 0x0401604C RID: 90188
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x0401604D RID: 90189
		internal static int __PropertyOffset_295;

		// Token: 0x0401604E RID: 90190
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_17;

		// Token: 0x0401604F RID: 90191
		internal static int __PropertyOffset_296;

		// Token: 0x04016050 RID: 90192
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_16;

		// Token: 0x04016051 RID: 90193
		internal static int __PropertyOffset_297;

		// Token: 0x04016052 RID: 90194
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_3;

		// Token: 0x04016053 RID: 90195
		internal static int __PropertyOffset_298;

		// Token: 0x04016054 RID: 90196
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_15;

		// Token: 0x04016055 RID: 90197
		internal static int __PropertyOffset_299;

		// Token: 0x04016056 RID: 90198
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_14;

		// Token: 0x04016057 RID: 90199
		internal static int __PropertyOffset_300;

		// Token: 0x04016058 RID: 90200
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04016059 RID: 90201
		internal static int __PropertyOffset_301;

		// Token: 0x0401605A RID: 90202
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_13;

		// Token: 0x0401605B RID: 90203
		internal static int __PropertyOffset_302;

		// Token: 0x0401605C RID: 90204
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_12;

		// Token: 0x0401605D RID: 90205
		internal static int __PropertyOffset_303;

		// Token: 0x0401605E RID: 90206
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_2;

		// Token: 0x0401605F RID: 90207
		internal static int __PropertyOffset_304;

		// Token: 0x04016060 RID: 90208
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_11;

		// Token: 0x04016061 RID: 90209
		internal static int __PropertyOffset_305;

		// Token: 0x04016062 RID: 90210
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_10;

		// Token: 0x04016063 RID: 90211
		internal static int __PropertyOffset_306;

		// Token: 0x04016064 RID: 90212
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04016065 RID: 90213
		internal static int __PropertyOffset_307;

		// Token: 0x04016066 RID: 90214
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_9;

		// Token: 0x04016067 RID: 90215
		internal static int __PropertyOffset_308;

		// Token: 0x04016068 RID: 90216
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_8;

		// Token: 0x04016069 RID: 90217
		internal static int __PropertyOffset_309;

		// Token: 0x0401606A RID: 90218
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_1;

		// Token: 0x0401606B RID: 90219
		internal static int __PropertyOffset_310;

		// Token: 0x0401606C RID: 90220
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_7;

		// Token: 0x0401606D RID: 90221
		internal static int __PropertyOffset_311;

		// Token: 0x0401606E RID: 90222
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_6;

		// Token: 0x0401606F RID: 90223
		internal static int __PropertyOffset_312;

		// Token: 0x04016070 RID: 90224
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04016071 RID: 90225
		internal static int __PropertyOffset_313;

		// Token: 0x04016072 RID: 90226
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend;

		// Token: 0x04016073 RID: 90227
		internal static int __PropertyOffset_314;

		// Token: 0x04016074 RID: 90228
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_5;

		// Token: 0x04016075 RID: 90229
		internal static int __PropertyOffset_315;

		// Token: 0x04016076 RID: 90230
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_4;

		// Token: 0x04016077 RID: 90231
		internal static int __PropertyOffset_316;

		// Token: 0x04016078 RID: 90232
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_3;

		// Token: 0x04016079 RID: 90233
		internal static int __PropertyOffset_317;

		// Token: 0x0401607A RID: 90234
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_2;

		// Token: 0x0401607B RID: 90235
		internal static int __PropertyOffset_318;

		// Token: 0x0401607C RID: 90236
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0401607D RID: 90237
		internal static int __PropertyOffset_319;

		// Token: 0x0401607E RID: 90238
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401607F RID: 90239
		internal static int __PropertyOffset_320;

		// Token: 0x04016080 RID: 90240
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose;

		// Token: 0x04016081 RID: 90241
		internal static int __PropertyOffset_321;

		// Token: 0x04016082 RID: 90242
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_1;

		// Token: 0x04016083 RID: 90243
		internal static int __PropertyOffset_322;

		// Token: 0x04016084 RID: 90244
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose;

		// Token: 0x04016085 RID: 90245
		internal static int __PropertyOffset_323;

		// Token: 0x04016086 RID: 90246
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04016087 RID: 90247
		internal static int __PropertyOffset_324;

		// Token: 0x04016088 RID: 90248
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_3;

		// Token: 0x04016089 RID: 90249
		internal static int __PropertyOffset_325;

		// Token: 0x0401608A RID: 90250
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_2;

		// Token: 0x0401608B RID: 90251
		internal static int __PropertyOffset_326;

		// Token: 0x0401608C RID: 90252
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x0401608D RID: 90253
		internal static int __PropertyOffset_327;

		// Token: 0x0401608E RID: 90254
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x0401608F RID: 90255
		internal static int __PropertyOffset_328;

		// Token: 0x04016090 RID: 90256
		internal static int __PropertyOffset_329;

		// Token: 0x04016091 RID: 90257
		internal static int __PropertyOffset_330;

		// Token: 0x04016092 RID: 90258
		internal static int __PropertyOffset_331;

		// Token: 0x04016093 RID: 90259
		private static IntPtr __基础姿势层_NativeFunctionPtr;

		// Token: 0x04016094 RID: 90260
		private static IntPtr __叠加动作层_NativeFunctionPtr;

		// Token: 0x04016095 RID: 90261
		private static IntPtr __混合层_NativeFunctionPtr;

		// Token: 0x04016096 RID: 90262
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04016097 RID: 90263
		private static IntPtr __地面站立循环混合层_NativeFunctionPtr;

		// Token: 0x04016098 RID: 90264
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04016099 RID: 90265
		private static IntPtr __初始化Tag_NativeFunctionPtr;

		// Token: 0x0401609A RID: 90266
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AD363E854A39DE16287F9F9FF855C859_NativeFunctionPtr;

		// Token: 0x0401609B RID: 90267
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_27F568B44918B0F888763B8E94204F21_NativeFunctionPtr;

		// Token: 0x0401609C RID: 90268
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_21F1E1A4450B10D159C2BDBC501F09D9_NativeFunctionPtr;

		// Token: 0x0401609D RID: 90269
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_E6E4271B494C142FA5D45B86259B44FE_NativeFunctionPtr;

		// Token: 0x0401609E RID: 90270
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9A1C8A1B4FE077E976584490DF0B6A69_NativeFunctionPtr;

		// Token: 0x0401609F RID: 90271
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_220048E64C60B47E210251BD1E2D0F0D_NativeFunctionPtr;

		// Token: 0x040160A0 RID: 90272
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_60FBB29642807596050B429F3A663122_NativeFunctionPtr;

		// Token: 0x040160A1 RID: 90273
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B57EEE8044D4374A57C2B9A788EC0244_NativeFunctionPtr;

		// Token: 0x040160A2 RID: 90274
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9DA288A048BD924028C0F4B063D85066_NativeFunctionPtr;

		// Token: 0x040160A3 RID: 90275
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_DA26F01A4AD5E62862EFAC875EA34622_NativeFunctionPtr;

		// Token: 0x040160A4 RID: 90276
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A27103154537F02D4F5FB591054CD4F2_NativeFunctionPtr;

		// Token: 0x040160A5 RID: 90277
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AAF70D3F42C2316773D52F8A3C2B61A2_NativeFunctionPtr;

		// Token: 0x040160A6 RID: 90278
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_BEA7D57D44AC85A8BD5AB586BDF748F3_NativeFunctionPtr;

		// Token: 0x040160A7 RID: 90279
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AFB576D64E5BD0A39613B2BA6C6E9EC2_NativeFunctionPtr;

		// Token: 0x040160A8 RID: 90280
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_410DE10A4CFBE7F24448D7924DAC6886_NativeFunctionPtr;

		// Token: 0x040160A9 RID: 90281
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7D787FA7435D0F49320F8D96D0176147_NativeFunctionPtr;

		// Token: 0x040160AA RID: 90282
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A1D765AA46F134CE4FD4B2AC68BA8199_NativeFunctionPtr;

		// Token: 0x040160AB RID: 90283
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9F0E6E844C78400D64B5CAA0737DCB34_NativeFunctionPtr;

		// Token: 0x040160AC RID: 90284
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6256CF234775832C0CE4B6BCC3BEC312_NativeFunctionPtr;

		// Token: 0x040160AD RID: 90285
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A20228084683E70DA873158B410F792B_NativeFunctionPtr;

		// Token: 0x040160AE RID: 90286
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B92843C645CBCCDFCD5AE1A41C1ABDA2_NativeFunctionPtr;

		// Token: 0x040160AF RID: 90287
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_37F7D28E4E4423EE25C5F399EDC85CEF_NativeFunctionPtr;

		// Token: 0x040160B0 RID: 90288
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4851DD91403E7425F091B8A03E58074F_NativeFunctionPtr;

		// Token: 0x040160B1 RID: 90289
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_625ABCC541D177C6393C36A15A625F4F_NativeFunctionPtr;

		// Token: 0x040160B2 RID: 90290
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B91FF85F46C2D12C6FD65DAB08F73423_NativeFunctionPtr;

		// Token: 0x040160B3 RID: 90291
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_896BC1C3414F01186D1D50885BF09885_NativeFunctionPtr;

		// Token: 0x040160B4 RID: 90292
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4A04C912416E67FADC0D12989760CF35_NativeFunctionPtr;

		// Token: 0x040160B5 RID: 90293
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2F257E26449919182BA48C820C43E2C7_NativeFunctionPtr;

		// Token: 0x040160B6 RID: 90294
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_01E7C8E84B7B4BDF9DCFE6BF76494BC7_NativeFunctionPtr;

		// Token: 0x040160B7 RID: 90295
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9CBE3E1B428BBF7B923FF4BACCABDDB4_NativeFunctionPtr;

		// Token: 0x040160B8 RID: 90296
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_932A9075429DD81B7228D993557391CF_NativeFunctionPtr;

		// Token: 0x040160B9 RID: 90297
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_60D8D0CF4DDC91A5502D2796FAF8FAD2_NativeFunctionPtr;

		// Token: 0x040160BA RID: 90298
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_21CEE1754B86B6285B63AAB33FC2DA2B_NativeFunctionPtr;

		// Token: 0x040160BB RID: 90299
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_DBB968454053CF0770E40EB298E940BD_NativeFunctionPtr;

		// Token: 0x040160BC RID: 90300
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7B8EADB94F1E638F51B74F925B6981B6_NativeFunctionPtr;

		// Token: 0x040160BD RID: 90301
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_38F816CA4806E22E805384B9654A43FB_NativeFunctionPtr;

		// Token: 0x040160BE RID: 90302
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2A3EF5F64A25167A4C02719C660675E5_NativeFunctionPtr;

		// Token: 0x040160BF RID: 90303
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_35D84E8A479A5A096BBD919A37845E9C_NativeFunctionPtr;

		// Token: 0x040160C0 RID: 90304
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_97E08F73466496665F816584BB4A9D03_NativeFunctionPtr;

		// Token: 0x040160C1 RID: 90305
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A16B4587474299B76A2A83957F2D7418_NativeFunctionPtr;

		// Token: 0x040160C2 RID: 90306
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_16D9A3E046A6D5C51769D190AEBD2D0C_NativeFunctionPtr;

		// Token: 0x040160C3 RID: 90307
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4434EBB843818E112B0F96AAF6418EB2_NativeFunctionPtr;

		// Token: 0x040160C4 RID: 90308
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6253594B45AA2AAA2E6ED78872EF0326_NativeFunctionPtr;

		// Token: 0x040160C5 RID: 90309
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_19367FDE4281669DB5553D99E8B23F7A_NativeFunctionPtr;

		// Token: 0x040160C6 RID: 90310
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_297451FB4C08C9BAB720F4A461A597BF_NativeFunctionPtr;

		// Token: 0x040160C7 RID: 90311
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_181E99E64741868324755DBE23E64937_NativeFunctionPtr;

		// Token: 0x040160C8 RID: 90312
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_EB8F6E934FDAED5E949FE78AC51AF5AF_NativeFunctionPtr;

		// Token: 0x040160C9 RID: 90313
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_62990C1D4B68B1AD42BC07A152DE5E12_NativeFunctionPtr;

		// Token: 0x040160CA RID: 90314
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_59E6208D4A9A26D5735C6CB9613D3495_NativeFunctionPtr;

		// Token: 0x040160CB RID: 90315
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2D9CDBF348FB2AC10029DDA1CCB497A7_NativeFunctionPtr;

		// Token: 0x040160CC RID: 90316
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_2206F9EE49E34930D4B40FA69C21D605_NativeFunctionPtr;

		// Token: 0x040160CD RID: 90317
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3EFDF07D4FD050E5EB594180CDB697E9_NativeFunctionPtr;

		// Token: 0x040160CE RID: 90318
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_BEABB8B74A8AF50AC323A58492A284FA_NativeFunctionPtr;

		// Token: 0x040160CF RID: 90319
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_4011E1F74B95B177D00682ABCCEE49F6_NativeFunctionPtr;

		// Token: 0x040160D0 RID: 90320
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_02C602CB47D1E8619F13428F7F1DA261_NativeFunctionPtr;

		// Token: 0x040160D1 RID: 90321
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_72F3A2BB4F4A556E7B24B8A5184A37E6_NativeFunctionPtr;

		// Token: 0x040160D2 RID: 90322
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_79EBF4C84DD2551BF3CB46AE68F7DD88_NativeFunctionPtr;

		// Token: 0x040160D3 RID: 90323
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3771CB0C4EAD2AFD136042AE037B79EB_NativeFunctionPtr;

		// Token: 0x040160D4 RID: 90324
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_FA7F519243AFD284C3211484957D57B9_NativeFunctionPtr;

		// Token: 0x040160D5 RID: 90325
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_BlendSpacePlayer_2073722D4A06F16CB6109BA33AC20BB6_NativeFunctionPtr;

		// Token: 0x040160D6 RID: 90326
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_0993A9D24512A908213680B985A6C83A_NativeFunctionPtr;

		// Token: 0x040160D7 RID: 90327
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AA76503044E5351E69C68EB9A653AA54_NativeFunctionPtr;

		// Token: 0x040160D8 RID: 90328
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_6BBE26EC4B40D6825092F9B1D0E4DB67_NativeFunctionPtr;

		// Token: 0x040160D9 RID: 90329
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_8013F6F9413EF6908532A78B82D29676_NativeFunctionPtr;

		// Token: 0x040160DA RID: 90330
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_31D2714540C263C0D17219B6A1DF0FA4_NativeFunctionPtr;

		// Token: 0x040160DB RID: 90331
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_FE63B7434CEB89D7670BD7975C13F0E4_NativeFunctionPtr;

		// Token: 0x040160DC RID: 90332
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7FC7E3A6406282492037229EE657036C_NativeFunctionPtr;

		// Token: 0x040160DD RID: 90333
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_AE68771C4D6376E69B71FEB86B8E368B_NativeFunctionPtr;

		// Token: 0x040160DE RID: 90334
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_EE2ADAA744E2F1446AB0C48A939DC017_NativeFunctionPtr;

		// Token: 0x040160DF RID: 90335
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_A72D3CD24316C81A325B60B20E2D8864_NativeFunctionPtr;

		// Token: 0x040160E0 RID: 90336
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B0C896AF480D856136EE68A07CEA20EF_NativeFunctionPtr;

		// Token: 0x040160E1 RID: 90337
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_3536A38A43AFC465EF869DB2F37E9EA5_NativeFunctionPtr;

		// Token: 0x040160E2 RID: 90338
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_9DC369304BF3B690BE7DBD8F912F9059_NativeFunctionPtr;

		// Token: 0x040160E3 RID: 90339
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_D9897C694F1DAA0A0BDC6C8F2BAC0BE9_NativeFunctionPtr;

		// Token: 0x040160E4 RID: 90340
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_7A77CC8C4A2B3C82B5CDD688DDE5006A_NativeFunctionPtr;

		// Token: 0x040160E5 RID: 90341
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_748564454E64C3AD361415877CB0D61A_NativeFunctionPtr;

		// Token: 0x040160E6 RID: 90342
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_12AA937643B103D033CB0199C6C961D9_NativeFunctionPtr;

		// Token: 0x040160E7 RID: 90343
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_03FDD14F4C073AAE19180E932B7DB3F7_NativeFunctionPtr;

		// Token: 0x040160E8 RID: 90344
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_CEEF249D457C8A62425DEA93676DC486_NativeFunctionPtr;

		// Token: 0x040160E9 RID: 90345
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Calbrena_Special_AnimGraphNode_TransitionResult_B1B89D7544E981DDAA93A1A66B0DD3FE_NativeFunctionPtr;

		// Token: 0x040160EA RID: 90346
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040160EB RID: 90347
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x040160EC RID: 90348
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x040160ED RID: 90349
		private static IntPtr __AnimNotify_退出攀爬_NativeFunctionPtr;

		// Token: 0x040160EE RID: 90350
		private static IntPtr __AnimNotify_ExitFlyingFeather_NativeFunctionPtr;

		// Token: 0x040160EF RID: 90351
		private static IntPtr __ExecuteUbergraph_ABP_Calbrena_Special_NativeFunctionPtr;

		// Token: 0x0200A201 RID: 41473
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础姿势层_FunctionParams
		{
			// Token: 0x04032F5E RID: 208734
			[FieldOffset(0)]
			public byte 基础姿势层;
		}

		// Token: 0x0200A202 RID: 41474
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __叠加动作层_FunctionParams
		{
			// Token: 0x04032F5F RID: 208735
			[FieldOffset(0)]
			public byte 叠加动作层;
		}

		// Token: 0x0200A203 RID: 41475
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __混合层_FunctionParams
		{
			// Token: 0x04032F60 RID: 208736
			[FieldOffset(0)]
			public byte BaseLayer;

			// Token: 0x04032F61 RID: 208737
			[FieldOffset(24)]
			public byte OverlayLayer;

			// Token: 0x04032F62 RID: 208738
			[FieldOffset(48)]
			public byte BasePose;

			// Token: 0x04032F63 RID: 208739
			[FieldOffset(72)]
			public byte 混合层;
		}

		// Token: 0x0200A204 RID: 41476
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x04032F64 RID: 208740
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A205 RID: 41477
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __地面站立循环混合层_FunctionParams
		{
			// Token: 0x04032F65 RID: 208741
			[FieldOffset(0)]
			public byte 前;

			// Token: 0x04032F66 RID: 208742
			[FieldOffset(24)]
			public byte 后;

			// Token: 0x04032F67 RID: 208743
			[FieldOffset(48)]
			public byte 左前;

			// Token: 0x04032F68 RID: 208744
			[FieldOffset(72)]
			public byte 左后;

			// Token: 0x04032F69 RID: 208745
			[FieldOffset(96)]
			public byte 右前;

			// Token: 0x04032F6A RID: 208746
			[FieldOffset(120)]
			public byte 右后;

			// Token: 0x04032F6B RID: 208747
			[FieldOffset(144)]
			public byte 冲刺;

			// Token: 0x04032F6C RID: 208748
			[FieldOffset(168)]
			public byte 地面站立循环混合层;
		}

		// Token: 0x0200A206 RID: 41478
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032F6D RID: 208749
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A207 RID: 41479
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032F6E RID: 208750
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A208 RID: 41480
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2448)]
		protected ref struct __ExecuteUbergraph_ABP_Calbrena_Special_FunctionParams
		{
			// Token: 0x04032F6F RID: 208751
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
