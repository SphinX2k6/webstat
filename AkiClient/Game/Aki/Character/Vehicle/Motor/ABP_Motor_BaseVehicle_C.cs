using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor
{
	// Token: 0x02003F91 RID: 16273
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/ABP_Motor_BaseVehicle.ABP_Motor_BaseVehicle_C")]
	[UnrealStructLayout(15760, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 15748)]
	public class ABP_Motor_BaseVehicle_C : UKuroAnimInstanceVehicle, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028B74 RID: 166772 RVA: 0x00A13AF8 File Offset: 0x00A11CF8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Motor_BaseVehicle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/ABP_Motor_BaseVehicle.ABP_Motor_BaseVehicle_C");
			}
			return ABP_Motor_BaseVehicle_C._ClassPtr;
		}

		// Token: 0x06028B75 RID: 166773 RVA: 0x00A13B1C File Offset: 0x00A11D1C
		public ABP_Motor_BaseVehicle_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Motor_BaseVehicle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028B76 RID: 166774 RVA: 0x00A13B44 File Offset: 0x00A11D44
		public ABP_Motor_BaseVehicle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Motor_BaseVehicle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700639E RID: 25502
		// (get) Token: 0x06028B77 RID: 166775 RVA: 0x00A13B78 File Offset: 0x00A11D78
		// (set) Token: 0x06028B78 RID: 166776 RVA: 0x00A13BB1 File Offset: 0x00A11DB1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700639F RID: 25503
		// (get) Token: 0x06028B79 RID: 166777 RVA: 0x00A13BD4 File Offset: 0x00A11DD4
		// (set) Token: 0x06028B7A RID: 166778 RVA: 0x00A13C0D File Offset: 0x00A11E0D
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A0 RID: 25504
		// (get) Token: 0x06028B7B RID: 166779 RVA: 0x00A13C30 File Offset: 0x00A11E30
		// (set) Token: 0x06028B7C RID: 166780 RVA: 0x00A13C69 File Offset: 0x00A11E69
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A1 RID: 25505
		// (get) Token: 0x06028B7D RID: 166781 RVA: 0x00A13C8C File Offset: 0x00A11E8C
		// (set) Token: 0x06028B7E RID: 166782 RVA: 0x00A13CC5 File Offset: 0x00A11EC5
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A2 RID: 25506
		// (get) Token: 0x06028B7F RID: 166783 RVA: 0x00A13CE8 File Offset: 0x00A11EE8
		// (set) Token: 0x06028B80 RID: 166784 RVA: 0x00A13D21 File Offset: 0x00A11F21
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A3 RID: 25507
		// (get) Token: 0x06028B81 RID: 166785 RVA: 0x00A13D44 File Offset: 0x00A11F44
		// (set) Token: 0x06028B82 RID: 166786 RVA: 0x00A13D7D File Offset: 0x00A11F7D
		public FAnimNode_KuroMotorIK AnimGraphNode_KuroMotorIK
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_KuroMotorIK result;
				if ((result = this._AnimGraphNode_KuroMotorIK) == null)
				{
					result = (this._AnimGraphNode_KuroMotorIK = new FAnimNode_KuroMotorIK(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_KuroMotorIK.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A4 RID: 25508
		// (get) Token: 0x06028B83 RID: 166787 RVA: 0x00A13DA0 File Offset: 0x00A11FA0
		// (set) Token: 0x06028B84 RID: 166788 RVA: 0x00A13DD9 File Offset: 0x00A11FD9
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A5 RID: 25509
		// (get) Token: 0x06028B85 RID: 166789 RVA: 0x00A13DFC File Offset: 0x00A11FFC
		// (set) Token: 0x06028B86 RID: 166790 RVA: 0x00A13E35 File Offset: 0x00A12035
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A6 RID: 25510
		// (get) Token: 0x06028B87 RID: 166791 RVA: 0x00A13E58 File Offset: 0x00A12058
		// (set) Token: 0x06028B88 RID: 166792 RVA: 0x00A13E91 File Offset: 0x00A12091
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A7 RID: 25511
		// (get) Token: 0x06028B89 RID: 166793 RVA: 0x00A13EB4 File Offset: 0x00A120B4
		// (set) Token: 0x06028B8A RID: 166794 RVA: 0x00A13EED File Offset: 0x00A120ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A8 RID: 25512
		// (get) Token: 0x06028B8B RID: 166795 RVA: 0x00A13F10 File Offset: 0x00A12110
		// (set) Token: 0x06028B8C RID: 166796 RVA: 0x00A13F49 File Offset: 0x00A12149
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063A9 RID: 25513
		// (get) Token: 0x06028B8D RID: 166797 RVA: 0x00A13F6C File Offset: 0x00A1216C
		// (set) Token: 0x06028B8E RID: 166798 RVA: 0x00A13FA5 File Offset: 0x00A121A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063AA RID: 25514
		// (get) Token: 0x06028B8F RID: 166799 RVA: 0x00A13FC8 File Offset: 0x00A121C8
		// (set) Token: 0x06028B90 RID: 166800 RVA: 0x00A14001 File Offset: 0x00A12201
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063AB RID: 25515
		// (get) Token: 0x06028B91 RID: 166801 RVA: 0x00A14024 File Offset: 0x00A12224
		// (set) Token: 0x06028B92 RID: 166802 RVA: 0x00A1405D File Offset: 0x00A1225D
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063AC RID: 25516
		// (get) Token: 0x06028B93 RID: 166803 RVA: 0x00A14080 File Offset: 0x00A12280
		// (set) Token: 0x06028B94 RID: 166804 RVA: 0x00A140B9 File Offset: 0x00A122B9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063AD RID: 25517
		// (get) Token: 0x06028B95 RID: 166805 RVA: 0x00A140DC File Offset: 0x00A122DC
		// (set) Token: 0x06028B96 RID: 166806 RVA: 0x00A14115 File Offset: 0x00A12315
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063AE RID: 25518
		// (get) Token: 0x06028B97 RID: 166807 RVA: 0x00A14138 File Offset: 0x00A12338
		// (set) Token: 0x06028B98 RID: 166808 RVA: 0x00A14171 File Offset: 0x00A12371
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063AF RID: 25519
		// (get) Token: 0x06028B99 RID: 166809 RVA: 0x00A14194 File Offset: 0x00A12394
		// (set) Token: 0x06028B9A RID: 166810 RVA: 0x00A141CD File Offset: 0x00A123CD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B0 RID: 25520
		// (get) Token: 0x06028B9B RID: 166811 RVA: 0x00A141F0 File Offset: 0x00A123F0
		// (set) Token: 0x06028B9C RID: 166812 RVA: 0x00A14229 File Offset: 0x00A12429
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B1 RID: 25521
		// (get) Token: 0x06028B9D RID: 166813 RVA: 0x00A1424C File Offset: 0x00A1244C
		// (set) Token: 0x06028B9E RID: 166814 RVA: 0x00A14285 File Offset: 0x00A12485
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B2 RID: 25522
		// (get) Token: 0x06028B9F RID: 166815 RVA: 0x00A142A8 File Offset: 0x00A124A8
		// (set) Token: 0x06028BA0 RID: 166816 RVA: 0x00A142E1 File Offset: 0x00A124E1
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B3 RID: 25523
		// (get) Token: 0x06028BA1 RID: 166817 RVA: 0x00A14304 File Offset: 0x00A12504
		// (set) Token: 0x06028BA2 RID: 166818 RVA: 0x00A1433D File Offset: 0x00A1253D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B4 RID: 25524
		// (get) Token: 0x06028BA3 RID: 166819 RVA: 0x00A14360 File Offset: 0x00A12560
		// (set) Token: 0x06028BA4 RID: 166820 RVA: 0x00A14399 File Offset: 0x00A12599
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B5 RID: 25525
		// (get) Token: 0x06028BA5 RID: 166821 RVA: 0x00A143BC File Offset: 0x00A125BC
		// (set) Token: 0x06028BA6 RID: 166822 RVA: 0x00A143F5 File Offset: 0x00A125F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B6 RID: 25526
		// (get) Token: 0x06028BA7 RID: 166823 RVA: 0x00A14418 File Offset: 0x00A12618
		// (set) Token: 0x06028BA8 RID: 166824 RVA: 0x00A14451 File Offset: 0x00A12651
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B7 RID: 25527
		// (get) Token: 0x06028BA9 RID: 166825 RVA: 0x00A14474 File Offset: 0x00A12674
		// (set) Token: 0x06028BAA RID: 166826 RVA: 0x00A144AD File Offset: 0x00A126AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B8 RID: 25528
		// (get) Token: 0x06028BAB RID: 166827 RVA: 0x00A144D0 File Offset: 0x00A126D0
		// (set) Token: 0x06028BAC RID: 166828 RVA: 0x00A14509 File Offset: 0x00A12709
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_6) == null)
				{
					result = (this._AnimGraphNode_StateMachine_6 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063B9 RID: 25529
		// (get) Token: 0x06028BAD RID: 166829 RVA: 0x00A1452C File Offset: 0x00A1272C
		// (set) Token: 0x06028BAE RID: 166830 RVA: 0x00A14565 File Offset: 0x00A12765
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063BA RID: 25530
		// (get) Token: 0x06028BAF RID: 166831 RVA: 0x00A14588 File Offset: 0x00A12788
		// (set) Token: 0x06028BB0 RID: 166832 RVA: 0x00A145C1 File Offset: 0x00A127C1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063BB RID: 25531
		// (get) Token: 0x06028BB1 RID: 166833 RVA: 0x00A145E4 File Offset: 0x00A127E4
		// (set) Token: 0x06028BB2 RID: 166834 RVA: 0x00A1461D File Offset: 0x00A1281D
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063BC RID: 25532
		// (get) Token: 0x06028BB3 RID: 166835 RVA: 0x00A14640 File Offset: 0x00A12840
		// (set) Token: 0x06028BB4 RID: 166836 RVA: 0x00A14679 File Offset: 0x00A12879
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_6) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_6 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063BD RID: 25533
		// (get) Token: 0x06028BB5 RID: 166837 RVA: 0x00A1469C File Offset: 0x00A1289C
		// (set) Token: 0x06028BB6 RID: 166838 RVA: 0x00A146D5 File Offset: 0x00A128D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063BE RID: 25534
		// (get) Token: 0x06028BB7 RID: 166839 RVA: 0x00A146F8 File Offset: 0x00A128F8
		// (set) Token: 0x06028BB8 RID: 166840 RVA: 0x00A14731 File Offset: 0x00A12931
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_5) == null)
				{
					result = (this._AnimGraphNode_StateMachine_5 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063BF RID: 25535
		// (get) Token: 0x06028BB9 RID: 166841 RVA: 0x00A14754 File Offset: 0x00A12954
		// (set) Token: 0x06028BBA RID: 166842 RVA: 0x00A1478D File Offset: 0x00A1298D
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C0 RID: 25536
		// (get) Token: 0x06028BBB RID: 166843 RVA: 0x00A147B0 File Offset: 0x00A129B0
		// (set) Token: 0x06028BBC RID: 166844 RVA: 0x00A147E9 File Offset: 0x00A129E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C1 RID: 25537
		// (get) Token: 0x06028BBD RID: 166845 RVA: 0x00A1480C File Offset: 0x00A12A0C
		// (set) Token: 0x06028BBE RID: 166846 RVA: 0x00A14845 File Offset: 0x00A12A45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C2 RID: 25538
		// (get) Token: 0x06028BBF RID: 166847 RVA: 0x00A14868 File Offset: 0x00A12A68
		// (set) Token: 0x06028BC0 RID: 166848 RVA: 0x00A148A1 File Offset: 0x00A12AA1
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C3 RID: 25539
		// (get) Token: 0x06028BC1 RID: 166849 RVA: 0x00A148C4 File Offset: 0x00A12AC4
		// (set) Token: 0x06028BC2 RID: 166850 RVA: 0x00A148FD File Offset: 0x00A12AFD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C4 RID: 25540
		// (get) Token: 0x06028BC3 RID: 166851 RVA: 0x00A14920 File Offset: 0x00A12B20
		// (set) Token: 0x06028BC4 RID: 166852 RVA: 0x00A14959 File Offset: 0x00A12B59
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C5 RID: 25541
		// (get) Token: 0x06028BC5 RID: 166853 RVA: 0x00A1497C File Offset: 0x00A12B7C
		// (set) Token: 0x06028BC6 RID: 166854 RVA: 0x00A149B5 File Offset: 0x00A12BB5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C6 RID: 25542
		// (get) Token: 0x06028BC7 RID: 166855 RVA: 0x00A149D8 File Offset: 0x00A12BD8
		// (set) Token: 0x06028BC8 RID: 166856 RVA: 0x00A14A11 File Offset: 0x00A12C11
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C7 RID: 25543
		// (get) Token: 0x06028BC9 RID: 166857 RVA: 0x00A14A34 File Offset: 0x00A12C34
		// (set) Token: 0x06028BCA RID: 166858 RVA: 0x00A14A6D File Offset: 0x00A12C6D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C8 RID: 25544
		// (get) Token: 0x06028BCB RID: 166859 RVA: 0x00A14A90 File Offset: 0x00A12C90
		// (set) Token: 0x06028BCC RID: 166860 RVA: 0x00A14AC9 File Offset: 0x00A12CC9
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063C9 RID: 25545
		// (get) Token: 0x06028BCD RID: 166861 RVA: 0x00A14AEC File Offset: 0x00A12CEC
		// (set) Token: 0x06028BCE RID: 166862 RVA: 0x00A14B25 File Offset: 0x00A12D25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063CA RID: 25546
		// (get) Token: 0x06028BCF RID: 166863 RVA: 0x00A14B48 File Offset: 0x00A12D48
		// (set) Token: 0x06028BD0 RID: 166864 RVA: 0x00A14B81 File Offset: 0x00A12D81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063CB RID: 25547
		// (get) Token: 0x06028BD1 RID: 166865 RVA: 0x00A14BA4 File Offset: 0x00A12DA4
		// (set) Token: 0x06028BD2 RID: 166866 RVA: 0x00A14BDD File Offset: 0x00A12DDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063CC RID: 25548
		// (get) Token: 0x06028BD3 RID: 166867 RVA: 0x00A14C00 File Offset: 0x00A12E00
		// (set) Token: 0x06028BD4 RID: 166868 RVA: 0x00A14C39 File Offset: 0x00A12E39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063CD RID: 25549
		// (get) Token: 0x06028BD5 RID: 166869 RVA: 0x00A14C5C File Offset: 0x00A12E5C
		// (set) Token: 0x06028BD6 RID: 166870 RVA: 0x00A14C95 File Offset: 0x00A12E95
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063CE RID: 25550
		// (get) Token: 0x06028BD7 RID: 166871 RVA: 0x00A14CB8 File Offset: 0x00A12EB8
		// (set) Token: 0x06028BD8 RID: 166872 RVA: 0x00A14CF1 File Offset: 0x00A12EF1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063CF RID: 25551
		// (get) Token: 0x06028BD9 RID: 166873 RVA: 0x00A14D14 File Offset: 0x00A12F14
		// (set) Token: 0x06028BDA RID: 166874 RVA: 0x00A14D4D File Offset: 0x00A12F4D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D0 RID: 25552
		// (get) Token: 0x06028BDB RID: 166875 RVA: 0x00A14D70 File Offset: 0x00A12F70
		// (set) Token: 0x06028BDC RID: 166876 RVA: 0x00A14DA9 File Offset: 0x00A12FA9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D1 RID: 25553
		// (get) Token: 0x06028BDD RID: 166877 RVA: 0x00A14DCC File Offset: 0x00A12FCC
		// (set) Token: 0x06028BDE RID: 166878 RVA: 0x00A14E05 File Offset: 0x00A13005
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D2 RID: 25554
		// (get) Token: 0x06028BDF RID: 166879 RVA: 0x00A14E28 File Offset: 0x00A13028
		// (set) Token: 0x06028BE0 RID: 166880 RVA: 0x00A14E61 File Offset: 0x00A13061
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D3 RID: 25555
		// (get) Token: 0x06028BE1 RID: 166881 RVA: 0x00A14E84 File Offset: 0x00A13084
		// (set) Token: 0x06028BE2 RID: 166882 RVA: 0x00A14EBD File Offset: 0x00A130BD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D4 RID: 25556
		// (get) Token: 0x06028BE3 RID: 166883 RVA: 0x00A14EE0 File Offset: 0x00A130E0
		// (set) Token: 0x06028BE4 RID: 166884 RVA: 0x00A14F19 File Offset: 0x00A13119
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D5 RID: 25557
		// (get) Token: 0x06028BE5 RID: 166885 RVA: 0x00A14F3C File Offset: 0x00A1313C
		// (set) Token: 0x06028BE6 RID: 166886 RVA: 0x00A14F75 File Offset: 0x00A13175
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D6 RID: 25558
		// (get) Token: 0x06028BE7 RID: 166887 RVA: 0x00A14F98 File Offset: 0x00A13198
		// (set) Token: 0x06028BE8 RID: 166888 RVA: 0x00A14FD1 File Offset: 0x00A131D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D7 RID: 25559
		// (get) Token: 0x06028BE9 RID: 166889 RVA: 0x00A14FF4 File Offset: 0x00A131F4
		// (set) Token: 0x06028BEA RID: 166890 RVA: 0x00A1502D File Offset: 0x00A1322D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D8 RID: 25560
		// (get) Token: 0x06028BEB RID: 166891 RVA: 0x00A15050 File Offset: 0x00A13250
		// (set) Token: 0x06028BEC RID: 166892 RVA: 0x00A15089 File Offset: 0x00A13289
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063D9 RID: 25561
		// (get) Token: 0x06028BED RID: 166893 RVA: 0x00A150AC File Offset: 0x00A132AC
		// (set) Token: 0x06028BEE RID: 166894 RVA: 0x00A150E5 File Offset: 0x00A132E5
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_5) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_5 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063DA RID: 25562
		// (get) Token: 0x06028BEF RID: 166895 RVA: 0x00A15108 File Offset: 0x00A13308
		// (set) Token: 0x06028BF0 RID: 166896 RVA: 0x00A15141 File Offset: 0x00A13341
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool_1) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool_1 = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063DB RID: 25563
		// (get) Token: 0x06028BF1 RID: 166897 RVA: 0x00A15164 File Offset: 0x00A13364
		// (set) Token: 0x06028BF2 RID: 166898 RVA: 0x00A1519D File Offset: 0x00A1339D
		public FAnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TwoWayBlend result;
				if ((result = this._AnimGraphNode_TwoWayBlend) == null)
				{
					result = (this._AnimGraphNode_TwoWayBlend = new FAnimNode_TwoWayBlend(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TwoWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063DC RID: 25564
		// (get) Token: 0x06028BF3 RID: 166899 RVA: 0x00A151C0 File Offset: 0x00A133C0
		// (set) Token: 0x06028BF4 RID: 166900 RVA: 0x00A151F9 File Offset: 0x00A133F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063DD RID: 25565
		// (get) Token: 0x06028BF5 RID: 166901 RVA: 0x00A1521C File Offset: 0x00A1341C
		// (set) Token: 0x06028BF6 RID: 166902 RVA: 0x00A15255 File Offset: 0x00A13455
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_4) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_4 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063DE RID: 25566
		// (get) Token: 0x06028BF7 RID: 166903 RVA: 0x00A15278 File Offset: 0x00A13478
		// (set) Token: 0x06028BF8 RID: 166904 RVA: 0x00A152B1 File Offset: 0x00A134B1
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063DF RID: 25567
		// (get) Token: 0x06028BF9 RID: 166905 RVA: 0x00A152D4 File Offset: 0x00A134D4
		// (set) Token: 0x06028BFA RID: 166906 RVA: 0x00A1530D File Offset: 0x00A1350D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E0 RID: 25568
		// (get) Token: 0x06028BFB RID: 166907 RVA: 0x00A15330 File Offset: 0x00A13530
		// (set) Token: 0x06028BFC RID: 166908 RVA: 0x00A15369 File Offset: 0x00A13569
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E1 RID: 25569
		// (get) Token: 0x06028BFD RID: 166909 RVA: 0x00A1538C File Offset: 0x00A1358C
		// (set) Token: 0x06028BFE RID: 166910 RVA: 0x00A153C5 File Offset: 0x00A135C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E2 RID: 25570
		// (get) Token: 0x06028BFF RID: 166911 RVA: 0x00A153E8 File Offset: 0x00A135E8
		// (set) Token: 0x06028C00 RID: 166912 RVA: 0x00A15421 File Offset: 0x00A13621
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E3 RID: 25571
		// (get) Token: 0x06028C01 RID: 166913 RVA: 0x00A15444 File Offset: 0x00A13644
		// (set) Token: 0x06028C02 RID: 166914 RVA: 0x00A1547D File Offset: 0x00A1367D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E4 RID: 25572
		// (get) Token: 0x06028C03 RID: 166915 RVA: 0x00A154A0 File Offset: 0x00A136A0
		// (set) Token: 0x06028C04 RID: 166916 RVA: 0x00A154D9 File Offset: 0x00A136D9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E5 RID: 25573
		// (get) Token: 0x06028C05 RID: 166917 RVA: 0x00A154FC File Offset: 0x00A136FC
		// (set) Token: 0x06028C06 RID: 166918 RVA: 0x00A15535 File Offset: 0x00A13735
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E6 RID: 25574
		// (get) Token: 0x06028C07 RID: 166919 RVA: 0x00A15558 File Offset: 0x00A13758
		// (set) Token: 0x06028C08 RID: 166920 RVA: 0x00A15591 File Offset: 0x00A13791
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E7 RID: 25575
		// (get) Token: 0x06028C09 RID: 166921 RVA: 0x00A155B4 File Offset: 0x00A137B4
		// (set) Token: 0x06028C0A RID: 166922 RVA: 0x00A155ED File Offset: 0x00A137ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E8 RID: 25576
		// (get) Token: 0x06028C0B RID: 166923 RVA: 0x00A15610 File Offset: 0x00A13810
		// (set) Token: 0x06028C0C RID: 166924 RVA: 0x00A15649 File Offset: 0x00A13849
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_3) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_3 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063E9 RID: 25577
		// (get) Token: 0x06028C0D RID: 166925 RVA: 0x00A1566C File Offset: 0x00A1386C
		// (set) Token: 0x06028C0E RID: 166926 RVA: 0x00A156A5 File Offset: 0x00A138A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063EA RID: 25578
		// (get) Token: 0x06028C0F RID: 166927 RVA: 0x00A156C8 File Offset: 0x00A138C8
		// (set) Token: 0x06028C10 RID: 166928 RVA: 0x00A15701 File Offset: 0x00A13901
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063EB RID: 25579
		// (get) Token: 0x06028C11 RID: 166929 RVA: 0x00A15724 File Offset: 0x00A13924
		// (set) Token: 0x06028C12 RID: 166930 RVA: 0x00A1575D File Offset: 0x00A1395D
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063EC RID: 25580
		// (get) Token: 0x06028C13 RID: 166931 RVA: 0x00A15780 File Offset: 0x00A13980
		// (set) Token: 0x06028C14 RID: 166932 RVA: 0x00A157B9 File Offset: 0x00A139B9
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_2) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_2 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063ED RID: 25581
		// (get) Token: 0x06028C15 RID: 166933 RVA: 0x00A157DC File Offset: 0x00A139DC
		// (set) Token: 0x06028C16 RID: 166934 RVA: 0x00A15815 File Offset: 0x00A13A15
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063EE RID: 25582
		// (get) Token: 0x06028C17 RID: 166935 RVA: 0x00A15838 File Offset: 0x00A13A38
		// (set) Token: 0x06028C18 RID: 166936 RVA: 0x00A15871 File Offset: 0x00A13A71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063EF RID: 25583
		// (get) Token: 0x06028C19 RID: 166937 RVA: 0x00A15894 File Offset: 0x00A13A94
		// (set) Token: 0x06028C1A RID: 166938 RVA: 0x00A158CD File Offset: 0x00A13ACD
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F0 RID: 25584
		// (get) Token: 0x06028C1B RID: 166939 RVA: 0x00A158F0 File Offset: 0x00A13AF0
		// (set) Token: 0x06028C1C RID: 166940 RVA: 0x00A15929 File Offset: 0x00A13B29
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F1 RID: 25585
		// (get) Token: 0x06028C1D RID: 166941 RVA: 0x00A1594C File Offset: 0x00A13B4C
		// (set) Token: 0x06028C1E RID: 166942 RVA: 0x00A15985 File Offset: 0x00A13B85
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F2 RID: 25586
		// (get) Token: 0x06028C1F RID: 166943 RVA: 0x00A159A8 File Offset: 0x00A13BA8
		// (set) Token: 0x06028C20 RID: 166944 RVA: 0x00A159E1 File Offset: 0x00A13BE1
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F3 RID: 25587
		// (get) Token: 0x06028C21 RID: 166945 RVA: 0x00A15A04 File Offset: 0x00A13C04
		// (set) Token: 0x06028C22 RID: 166946 RVA: 0x00A15A3D File Offset: 0x00A13C3D
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F4 RID: 25588
		// (get) Token: 0x06028C23 RID: 166947 RVA: 0x00A15A60 File Offset: 0x00A13C60
		// (set) Token: 0x06028C24 RID: 166948 RVA: 0x00A15A99 File Offset: 0x00A13C99
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F5 RID: 25589
		// (get) Token: 0x06028C25 RID: 166949 RVA: 0x00A15ABC File Offset: 0x00A13CBC
		// (set) Token: 0x06028C26 RID: 166950 RVA: 0x00A15AF5 File Offset: 0x00A13CF5
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F6 RID: 25590
		// (get) Token: 0x06028C27 RID: 166951 RVA: 0x00A15B18 File Offset: 0x00A13D18
		// (set) Token: 0x06028C28 RID: 166952 RVA: 0x00A15B51 File Offset: 0x00A13D51
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F7 RID: 25591
		// (get) Token: 0x06028C29 RID: 166953 RVA: 0x00A15B74 File Offset: 0x00A13D74
		// (set) Token: 0x06028C2A RID: 166954 RVA: 0x00A15BAD File Offset: 0x00A13DAD
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F8 RID: 25592
		// (get) Token: 0x06028C2B RID: 166955 RVA: 0x00A15BD0 File Offset: 0x00A13DD0
		// (set) Token: 0x06028C2C RID: 166956 RVA: 0x00A15C09 File Offset: 0x00A13E09
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063F9 RID: 25593
		// (get) Token: 0x06028C2D RID: 166957 RVA: 0x00A15C2C File Offset: 0x00A13E2C
		// (set) Token: 0x06028C2E RID: 166958 RVA: 0x00A15C65 File Offset: 0x00A13E65
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063FA RID: 25594
		// (get) Token: 0x06028C2F RID: 166959 RVA: 0x00A15C88 File Offset: 0x00A13E88
		// (set) Token: 0x06028C30 RID: 166960 RVA: 0x00A15CC1 File Offset: 0x00A13EC1
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063FB RID: 25595
		// (get) Token: 0x06028C31 RID: 166961 RVA: 0x00A15CE4 File Offset: 0x00A13EE4
		// (set) Token: 0x06028C32 RID: 166962 RVA: 0x00A15D1D File Offset: 0x00A13F1D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063FC RID: 25596
		// (get) Token: 0x06028C33 RID: 166963 RVA: 0x00A15D40 File Offset: 0x00A13F40
		// (set) Token: 0x06028C34 RID: 166964 RVA: 0x00A15D79 File Offset: 0x00A13F79
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063FD RID: 25597
		// (get) Token: 0x06028C35 RID: 166965 RVA: 0x00A15D9C File Offset: 0x00A13F9C
		// (set) Token: 0x06028C36 RID: 166966 RVA: 0x00A15DD5 File Offset: 0x00A13FD5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063FE RID: 25598
		// (get) Token: 0x06028C37 RID: 166967 RVA: 0x00A15DF8 File Offset: 0x00A13FF8
		// (set) Token: 0x06028C38 RID: 166968 RVA: 0x00A15E31 File Offset: 0x00A14031
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170063FF RID: 25599
		// (get) Token: 0x06028C39 RID: 166969 RVA: 0x00A15E54 File Offset: 0x00A14054
		// (set) Token: 0x06028C3A RID: 166970 RVA: 0x00A15E8D File Offset: 0x00A1408D
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006400 RID: 25600
		// (get) Token: 0x06028C3B RID: 166971 RVA: 0x00A15EB0 File Offset: 0x00A140B0
		// (set) Token: 0x06028C3C RID: 166972 RVA: 0x00A15EE9 File Offset: 0x00A140E9
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006401 RID: 25601
		// (get) Token: 0x06028C3D RID: 166973 RVA: 0x00A15F0C File Offset: 0x00A1410C
		// (set) Token: 0x06028C3E RID: 166974 RVA: 0x00A15F45 File Offset: 0x00A14145
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006402 RID: 25602
		// (get) Token: 0x06028C3F RID: 166975 RVA: 0x00A15F66 File Offset: 0x00A14166
		// (set) Token: 0x06028C40 RID: 166976 RVA: 0x00A15F7A File Offset: 0x00A1417A
		[Nullable(2)]
		public unsafe UKuroVehicleMovementComponent VehicleMove
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroVehicleMovementComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_Motor_BaseVehicle_C.__PropertyOffset_100);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_Motor_BaseVehicle_C.__PropertyOffset_100, value);
			}
		}

		// Token: 0x17006403 RID: 25603
		// (get) Token: 0x06028C41 RID: 166977 RVA: 0x00A15F8F File Offset: 0x00A1418F
		// (set) Token: 0x06028C42 RID: 166978 RVA: 0x00A15FA3 File Offset: 0x00A141A3
		public unsafe FVector2D 移动混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_101);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_101) = value;
			}
		}

		// Token: 0x17006404 RID: 25604
		// (get) Token: 0x06028C43 RID: 166979 RVA: 0x00A15FB8 File Offset: 0x00A141B8
		// (set) Token: 0x06028C44 RID: 166980 RVA: 0x00A15FC8 File Offset: 0x00A141C8
		public unsafe float 左右混合缓冲
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x17006405 RID: 25605
		// (get) Token: 0x06028C45 RID: 166981 RVA: 0x00A15FD9 File Offset: 0x00A141D9
		// (set) Token: 0x06028C46 RID: 166982 RVA: 0x00A15FE9 File Offset: 0x00A141E9
		public unsafe float 左右Mix一段缓冲
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_103);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_103) = value;
			}
		}

		// Token: 0x17006406 RID: 25606
		// (get) Token: 0x06028C47 RID: 166983 RVA: 0x00A15FFA File Offset: 0x00A141FA
		// (set) Token: 0x06028C48 RID: 166984 RVA: 0x00A1600A File Offset: 0x00A1420A
		public unsafe float 左右Mix二段缓冲
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_104);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_104) = value;
			}
		}

		// Token: 0x17006407 RID: 25607
		// (get) Token: 0x06028C49 RID: 166985 RVA: 0x00A1601B File Offset: 0x00A1421B
		// (set) Token: 0x06028C4A RID: 166986 RVA: 0x00A1602B File Offset: 0x00A1422B
		public unsafe bool 技能状态_定点钩索
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_105) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_105) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006408 RID: 25608
		// (get) Token: 0x06028C4B RID: 166987 RVA: 0x00A1603C File Offset: 0x00A1423C
		// (set) Token: 0x06028C4C RID: 166988 RVA: 0x00A16075 File Offset: 0x00A14275
		public TMap<int, FVector> Target_Locations
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, FVector> result;
				if ((result = this._Target_Locations) == null)
				{
					result = (this._Target_Locations = new TMap<int, FVector>(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				this.Target_Locations.CopyAssign(value);
			}
		}

		// Token: 0x17006409 RID: 25609
		// (get) Token: 0x06028C4D RID: 166989 RVA: 0x00A16084 File Offset: 0x00A14284
		// (set) Token: 0x06028C4E RID: 166990 RVA: 0x00A160BD File Offset: 0x00A142BD
		public TMap<int, float> Wheel_Speeds
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, float> result;
				if ((result = this._Wheel_Speeds) == null)
				{
					result = (this._Wheel_Speeds = new TMap<int, float>(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				this.Wheel_Speeds.CopyAssign(value);
			}
		}

		// Token: 0x1700640A RID: 25610
		// (get) Token: 0x06028C4F RID: 166991 RVA: 0x00A160CC File Offset: 0x00A142CC
		// (set) Token: 0x06028C50 RID: 166992 RVA: 0x00A16105 File Offset: 0x00A14305
		public TMap<int, float> Wheel_Accels
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, float> result;
				if ((result = this._Wheel_Accels) == null)
				{
					result = (this._Wheel_Accels = new TMap<int, float>(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				this.Wheel_Accels.CopyAssign(value);
			}
		}

		// Token: 0x1700640B RID: 25611
		// (get) Token: 0x06028C51 RID: 166993 RVA: 0x00A16113 File Offset: 0x00A14313
		// (set) Token: 0x06028C52 RID: 166994 RVA: 0x00A16123 File Offset: 0x00A14323
		public unsafe EMotorSubState 摩托运动状态
		{
			get
			{
				return (EMotorSubState)(*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_109));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_109) = (byte)value;
			}
		}

		// Token: 0x1700640C RID: 25612
		// (get) Token: 0x06028C53 RID: 166995 RVA: 0x00A16134 File Offset: 0x00A14334
		// (set) Token: 0x06028C54 RID: 166996 RVA: 0x00A16144 File Offset: 0x00A14344
		public unsafe bool 状态_冲刺
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_110) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_110) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700640D RID: 25613
		// (get) Token: 0x06028C55 RID: 166997 RVA: 0x00A16155 File Offset: 0x00A14355
		// (set) Token: 0x06028C56 RID: 166998 RVA: 0x00A16165 File Offset: 0x00A14365
		public unsafe bool 滑轨状态_滑轨移动中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_111) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_111) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700640E RID: 25614
		// (get) Token: 0x06028C57 RID: 166999 RVA: 0x00A16176 File Offset: 0x00A14376
		// (set) Token: 0x06028C58 RID: 167000 RVA: 0x00A16186 File Offset: 0x00A14386
		public unsafe bool 滑轨动作状态_子弹跳
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_112) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_112) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700640F RID: 25615
		// (get) Token: 0x06028C59 RID: 167001 RVA: 0x00A16197 File Offset: 0x00A14397
		// (set) Token: 0x06028C5A RID: 167002 RVA: 0x00A161A7 File Offset: 0x00A143A7
		public unsafe bool 滑轨动作状态_滑行
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_113) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_113) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006410 RID: 25616
		// (get) Token: 0x06028C5B RID: 167003 RVA: 0x00A161B8 File Offset: 0x00A143B8
		// (set) Token: 0x06028C5C RID: 167004 RVA: 0x00A161C8 File Offset: 0x00A143C8
		public unsafe bool 滑轨动作状态_翘车头
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_114) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_114) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006411 RID: 25617
		// (get) Token: 0x06028C5D RID: 167005 RVA: 0x00A161D9 File Offset: 0x00A143D9
		// (set) Token: 0x06028C5E RID: 167006 RVA: 0x00A161E9 File Offset: 0x00A143E9
		public unsafe bool 状态_地面
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_115) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_115) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006412 RID: 25618
		// (get) Token: 0x06028C5F RID: 167007 RVA: 0x00A161FA File Offset: 0x00A143FA
		// (set) Token: 0x06028C60 RID: 167008 RVA: 0x00A1620A File Offset: 0x00A1440A
		public unsafe bool 状态_漂移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_116) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_116) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006413 RID: 25619
		// (get) Token: 0x06028C61 RID: 167009 RVA: 0x00A1621B File Offset: 0x00A1441B
		// (set) Token: 0x06028C62 RID: 167010 RVA: 0x00A1622B File Offset: 0x00A1442B
		public unsafe float 下落速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_117);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_117) = value;
			}
		}

		// Token: 0x17006414 RID: 25620
		// (get) Token: 0x06028C63 RID: 167011 RVA: 0x00A1623C File Offset: 0x00A1443C
		// (set) Token: 0x06028C64 RID: 167012 RVA: 0x00A16250 File Offset: 0x00A14450
		[Nullable(2)]
		public unsafe UCurveFloat 前进速度混合映射
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_Motor_BaseVehicle_C.__PropertyOffset_118);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_Motor_BaseVehicle_C.__PropertyOffset_118, value);
			}
		}

		// Token: 0x17006415 RID: 25621
		// (get) Token: 0x06028C65 RID: 167013 RVA: 0x00A16265 File Offset: 0x00A14465
		// (set) Token: 0x06028C66 RID: 167014 RVA: 0x00A16275 File Offset: 0x00A14475
		public unsafe bool 第一人称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_119) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_119) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006416 RID: 25622
		// (get) Token: 0x06028C67 RID: 167015 RVA: 0x00A16286 File Offset: 0x00A14486
		// (set) Token: 0x06028C68 RID: 167016 RVA: 0x00A16296 File Offset: 0x00A14496
		public unsafe bool NeedSimulate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_120) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_120) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006417 RID: 25623
		// (get) Token: 0x06028C69 RID: 167017 RVA: 0x00A162A7 File Offset: 0x00A144A7
		// (set) Token: 0x06028C6A RID: 167018 RVA: 0x00A162B7 File Offset: 0x00A144B7
		public unsafe bool 状态_技能下落
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_121) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_121) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006418 RID: 25624
		// (get) Token: 0x06028C6B RID: 167019 RVA: 0x00A162C8 File Offset: 0x00A144C8
		// (set) Token: 0x06028C6C RID: 167020 RVA: 0x00A162D8 File Offset: 0x00A144D8
		public unsafe bool 状态_滑翔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_122) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Motor_BaseVehicle_C.__PropertyOffset_122) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028C6D RID: 167021 RVA: 0x00A162EC File Offset: 0x00A144EC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 后处理层(FPoseLink InPose, ref FPoseLink 后处理层)
		{
			ABP_Motor_BaseVehicle_C.__后处理层_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_C.__后处理层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_C.__后处理层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_C.__后处理层_NativeFunctionPtr, (void*)ptr, 1);
			if (InPose != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->InPose, InPose.NativePtr, 1, false);
			}
			if (后处理层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->后处理层, 后处理层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__后处理层_NativeFunctionPtr, (void*)ptr);
			if (后处理层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 后处理层.NativePtr, &ptr->后处理层, 1, false);
			}
		}

		// Token: 0x06028C6E RID: 167022 RVA: 0x00A16398 File Offset: 0x00A14598
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 主动作层(ref FPoseLink 主动作层)
		{
			ABP_Motor_BaseVehicle_C.__主动作层_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_C.__主动作层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_C.__主动作层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_C.__主动作层_NativeFunctionPtr, (void*)ptr, 1);
			if (主动作层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->主动作层, 主动作层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__主动作层_NativeFunctionPtr, (void*)ptr);
			if (主动作层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 主动作层.NativePtr, &ptr->主动作层, 1, false);
			}
		}

		// Token: 0x06028C6F RID: 167023 RVA: 0x00A16420 File Offset: 0x00A14620
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_Motor_BaseVehicle_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06028C70 RID: 167024 RVA: 0x00A164A7 File Offset: 0x00A146A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新移动占比()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__更新移动占比_NativeFunctionPtr, null);
		}

		// Token: 0x06028C71 RID: 167025 RVA: 0x00A164BB File Offset: 0x00A146BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化Tag()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__初始化Tag_NativeFunctionPtr, null);
		}

		// Token: 0x06028C72 RID: 167026 RVA: 0x00A164CF File Offset: 0x00A146CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_KuroMotorIK_5478B7584DA3D294AF722187C1E304A3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_KuroMotorIK_5478B7584DA3D294AF722187C1E304A3_NativeFunctionPtr, null);
		}

		// Token: 0x06028C73 RID: 167027 RVA: 0x00A164E3 File Offset: 0x00A146E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_067FDBE941E7420B19E183922C5008B1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_067FDBE941E7420B19E183922C5008B1_NativeFunctionPtr, null);
		}

		// Token: 0x06028C74 RID: 167028 RVA: 0x00A164F7 File Offset: 0x00A146F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_ECEF7B234C31FB76C14B91B8BD5A2E9B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_ECEF7B234C31FB76C14B91B8BD5A2E9B_NativeFunctionPtr, null);
		}

		// Token: 0x06028C75 RID: 167029 RVA: 0x00A1650B File Offset: 0x00A1470B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_323761B344BAF709E5AAD9B2375906FE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_323761B344BAF709E5AAD9B2375906FE_NativeFunctionPtr, null);
		}

		// Token: 0x06028C76 RID: 167030 RVA: 0x00A1651F File Offset: 0x00A1471F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_30778B81476BE42AA316BCA15EAE9962()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_30778B81476BE42AA316BCA15EAE9962_NativeFunctionPtr, null);
		}

		// Token: 0x06028C77 RID: 167031 RVA: 0x00A16533 File Offset: 0x00A14733
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_25D2FC73426E7885D4BD3EA561B996B3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_25D2FC73426E7885D4BD3EA561B996B3_NativeFunctionPtr, null);
		}

		// Token: 0x06028C78 RID: 167032 RVA: 0x00A16547 File Offset: 0x00A14747
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_ApplyAdditive_2AC36505459B9B79C906239A835CE6D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_ApplyAdditive_2AC36505459B9B79C906239A835CE6D5_NativeFunctionPtr, null);
		}

		// Token: 0x06028C79 RID: 167033 RVA: 0x00A1655B File Offset: 0x00A1475B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TwoWayBlend_42CEDBCC4442F197CDBCF38F629FD303()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TwoWayBlend_42CEDBCC4442F197CDBCF38F629FD303_NativeFunctionPtr, null);
		}

		// Token: 0x06028C7A RID: 167034 RVA: 0x00A1656F File Offset: 0x00A1476F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_BlendSpacePlayer_A4962EAC428E58C1B33FC085A8699A86()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_BlendSpacePlayer_A4962EAC428E58C1B33FC085A8699A86_NativeFunctionPtr, null);
		}

		// Token: 0x06028C7B RID: 167035 RVA: 0x00A16583 File Offset: 0x00A14783
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_B81CAFEC4DD5FCECBF80F7B9FD587815()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_B81CAFEC4DD5FCECBF80F7B9FD587815_NativeFunctionPtr, null);
		}

		// Token: 0x06028C7C RID: 167036 RVA: 0x00A16597 File Offset: 0x00A14797
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_46806B97455032FAA96D0CBCDA337F63()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_46806B97455032FAA96D0CBCDA337F63_NativeFunctionPtr, null);
		}

		// Token: 0x06028C7D RID: 167037 RVA: 0x00A165AB File Offset: 0x00A147AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_E4850800439E0EBDC996EDBF9A69706D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_E4850800439E0EBDC996EDBF9A69706D_NativeFunctionPtr, null);
		}

		// Token: 0x06028C7E RID: 167038 RVA: 0x00A165BF File Offset: 0x00A147BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_E8B7B16743C7145A3413E8A842F74D0E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_E8B7B16743C7145A3413E8A842F74D0E_NativeFunctionPtr, null);
		}

		// Token: 0x06028C7F RID: 167039 RVA: 0x00A165D3 File Offset: 0x00A147D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_4C2EE5424AADA5C9D39C2E9EC352DBCC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_4C2EE5424AADA5C9D39C2E9EC352DBCC_NativeFunctionPtr, null);
		}

		// Token: 0x06028C80 RID: 167040 RVA: 0x00A165E7 File Offset: 0x00A147E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_81720D174354106908AC5FAD2C9B687B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_81720D174354106908AC5FAD2C9B687B_NativeFunctionPtr, null);
		}

		// Token: 0x06028C81 RID: 167041 RVA: 0x00A165FC File Offset: 0x00A147FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028C82 RID: 167042 RVA: 0x00A16644 File Offset: 0x00A14844
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028C83 RID: 167043 RVA: 0x00A1668B File Offset: 0x00A1488B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x06028C84 RID: 167044 RVA: 0x00A1669F File Offset: 0x00A1489F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028C85 RID: 167045 RVA: 0x00A166B4 File Offset: 0x00A148B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x06028C86 RID: 167046 RVA: 0x00A166C8 File Offset: 0x00A148C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028C87 RID: 167047 RVA: 0x00A166E0 File Offset: 0x00A148E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Motor_BaseVehicle(int EntryPoint)
		{
			ABP_Motor_BaseVehicle_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_FunctionParams* ptr = stackalloc ABP_Motor_BaseVehicle_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(ABP_Motor_BaseVehicle_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Motor_BaseVehicle_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Motor_BaseVehicle_C.__ExecuteUbergraph_ABP_Motor_BaseVehicle_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028C88 RID: 167048 RVA: 0x00A16727 File Offset: 0x00A14927
		protected ABP_Motor_BaseVehicle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040157E3 RID: 88035
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/ABP_Motor_BaseVehicle.ABP_Motor_BaseVehicle_C";

		// Token: 0x040157E4 RID: 88036
		private static IntPtr _ClassPtr;

		// Token: 0x040157E5 RID: 88037
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040157E6 RID: 88038
		internal static int __PropertyOffset_0;

		// Token: 0x040157E7 RID: 88039
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040157E8 RID: 88040
		internal static int __PropertyOffset_1;

		// Token: 0x040157E9 RID: 88041
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x040157EA RID: 88042
		internal static int __PropertyOffset_2;

		// Token: 0x040157EB RID: 88043
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x040157EC RID: 88044
		internal static int __PropertyOffset_3;

		// Token: 0x040157ED RID: 88045
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x040157EE RID: 88046
		internal static int __PropertyOffset_4;

		// Token: 0x040157EF RID: 88047
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x040157F0 RID: 88048
		internal static int __PropertyOffset_5;

		// Token: 0x040157F1 RID: 88049
		[Nullable(2)]
		private FAnimNode_KuroMotorIK _AnimGraphNode_KuroMotorIK;

		// Token: 0x040157F2 RID: 88050
		internal static int __PropertyOffset_6;

		// Token: 0x040157F3 RID: 88051
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x040157F4 RID: 88052
		internal static int __PropertyOffset_7;

		// Token: 0x040157F5 RID: 88053
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x040157F6 RID: 88054
		internal static int __PropertyOffset_8;

		// Token: 0x040157F7 RID: 88055
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x040157F8 RID: 88056
		internal static int __PropertyOffset_9;

		// Token: 0x040157F9 RID: 88057
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x040157FA RID: 88058
		internal static int __PropertyOffset_10;

		// Token: 0x040157FB RID: 88059
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x040157FC RID: 88060
		internal static int __PropertyOffset_11;

		// Token: 0x040157FD RID: 88061
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x040157FE RID: 88062
		internal static int __PropertyOffset_12;

		// Token: 0x040157FF RID: 88063
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x04015800 RID: 88064
		internal static int __PropertyOffset_13;

		// Token: 0x04015801 RID: 88065
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x04015802 RID: 88066
		internal static int __PropertyOffset_14;

		// Token: 0x04015803 RID: 88067
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x04015804 RID: 88068
		internal static int __PropertyOffset_15;

		// Token: 0x04015805 RID: 88069
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x04015806 RID: 88070
		internal static int __PropertyOffset_16;

		// Token: 0x04015807 RID: 88071
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x04015808 RID: 88072
		internal static int __PropertyOffset_17;

		// Token: 0x04015809 RID: 88073
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x0401580A RID: 88074
		internal static int __PropertyOffset_18;

		// Token: 0x0401580B RID: 88075
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x0401580C RID: 88076
		internal static int __PropertyOffset_19;

		// Token: 0x0401580D RID: 88077
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x0401580E RID: 88078
		internal static int __PropertyOffset_20;

		// Token: 0x0401580F RID: 88079
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x04015810 RID: 88080
		internal static int __PropertyOffset_21;

		// Token: 0x04015811 RID: 88081
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x04015812 RID: 88082
		internal static int __PropertyOffset_22;

		// Token: 0x04015813 RID: 88083
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04015814 RID: 88084
		internal static int __PropertyOffset_23;

		// Token: 0x04015815 RID: 88085
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x04015816 RID: 88086
		internal static int __PropertyOffset_24;

		// Token: 0x04015817 RID: 88087
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04015818 RID: 88088
		internal static int __PropertyOffset_25;

		// Token: 0x04015819 RID: 88089
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x0401581A RID: 88090
		internal static int __PropertyOffset_26;

		// Token: 0x0401581B RID: 88091
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_6;

		// Token: 0x0401581C RID: 88092
		internal static int __PropertyOffset_27;

		// Token: 0x0401581D RID: 88093
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x0401581E RID: 88094
		internal static int __PropertyOffset_28;

		// Token: 0x0401581F RID: 88095
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04015820 RID: 88096
		internal static int __PropertyOffset_29;

		// Token: 0x04015821 RID: 88097
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x04015822 RID: 88098
		internal static int __PropertyOffset_30;

		// Token: 0x04015823 RID: 88099
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_6;

		// Token: 0x04015824 RID: 88100
		internal static int __PropertyOffset_31;

		// Token: 0x04015825 RID: 88101
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x04015826 RID: 88102
		internal static int __PropertyOffset_32;

		// Token: 0x04015827 RID: 88103
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_5;

		// Token: 0x04015828 RID: 88104
		internal static int __PropertyOffset_33;

		// Token: 0x04015829 RID: 88105
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x0401582A RID: 88106
		internal static int __PropertyOffset_34;

		// Token: 0x0401582B RID: 88107
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x0401582C RID: 88108
		internal static int __PropertyOffset_35;

		// Token: 0x0401582D RID: 88109
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x0401582E RID: 88110
		internal static int __PropertyOffset_36;

		// Token: 0x0401582F RID: 88111
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x04015830 RID: 88112
		internal static int __PropertyOffset_37;

		// Token: 0x04015831 RID: 88113
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04015832 RID: 88114
		internal static int __PropertyOffset_38;

		// Token: 0x04015833 RID: 88115
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04015834 RID: 88116
		internal static int __PropertyOffset_39;

		// Token: 0x04015835 RID: 88117
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04015836 RID: 88118
		internal static int __PropertyOffset_40;

		// Token: 0x04015837 RID: 88119
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x04015838 RID: 88120
		internal static int __PropertyOffset_41;

		// Token: 0x04015839 RID: 88121
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x0401583A RID: 88122
		internal static int __PropertyOffset_42;

		// Token: 0x0401583B RID: 88123
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x0401583C RID: 88124
		internal static int __PropertyOffset_43;

		// Token: 0x0401583D RID: 88125
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x0401583E RID: 88126
		internal static int __PropertyOffset_44;

		// Token: 0x0401583F RID: 88127
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x04015840 RID: 88128
		internal static int __PropertyOffset_45;

		// Token: 0x04015841 RID: 88129
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x04015842 RID: 88130
		internal static int __PropertyOffset_46;

		// Token: 0x04015843 RID: 88131
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04015844 RID: 88132
		internal static int __PropertyOffset_47;

		// Token: 0x04015845 RID: 88133
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04015846 RID: 88134
		internal static int __PropertyOffset_48;

		// Token: 0x04015847 RID: 88135
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04015848 RID: 88136
		internal static int __PropertyOffset_49;

		// Token: 0x04015849 RID: 88137
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x0401584A RID: 88138
		internal static int __PropertyOffset_50;

		// Token: 0x0401584B RID: 88139
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x0401584C RID: 88140
		internal static int __PropertyOffset_51;

		// Token: 0x0401584D RID: 88141
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x0401584E RID: 88142
		internal static int __PropertyOffset_52;

		// Token: 0x0401584F RID: 88143
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x04015850 RID: 88144
		internal static int __PropertyOffset_53;

		// Token: 0x04015851 RID: 88145
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04015852 RID: 88146
		internal static int __PropertyOffset_54;

		// Token: 0x04015853 RID: 88147
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04015854 RID: 88148
		internal static int __PropertyOffset_55;

		// Token: 0x04015855 RID: 88149
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04015856 RID: 88150
		internal static int __PropertyOffset_56;

		// Token: 0x04015857 RID: 88151
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04015858 RID: 88152
		internal static int __PropertyOffset_57;

		// Token: 0x04015859 RID: 88153
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x0401585A RID: 88154
		internal static int __PropertyOffset_58;

		// Token: 0x0401585B RID: 88155
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x0401585C RID: 88156
		internal static int __PropertyOffset_59;

		// Token: 0x0401585D RID: 88157
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_5;

		// Token: 0x0401585E RID: 88158
		internal static int __PropertyOffset_60;

		// Token: 0x0401585F RID: 88159
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool_1;

		// Token: 0x04015860 RID: 88160
		internal static int __PropertyOffset_61;

		// Token: 0x04015861 RID: 88161
		[Nullable(2)]
		private FAnimNode_TwoWayBlend _AnimGraphNode_TwoWayBlend;

		// Token: 0x04015862 RID: 88162
		internal static int __PropertyOffset_62;

		// Token: 0x04015863 RID: 88163
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04015864 RID: 88164
		internal static int __PropertyOffset_63;

		// Token: 0x04015865 RID: 88165
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_4;

		// Token: 0x04015866 RID: 88166
		internal static int __PropertyOffset_64;

		// Token: 0x04015867 RID: 88167
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04015868 RID: 88168
		internal static int __PropertyOffset_65;

		// Token: 0x04015869 RID: 88169
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x0401586A RID: 88170
		internal static int __PropertyOffset_66;

		// Token: 0x0401586B RID: 88171
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x0401586C RID: 88172
		internal static int __PropertyOffset_67;

		// Token: 0x0401586D RID: 88173
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x0401586E RID: 88174
		internal static int __PropertyOffset_68;

		// Token: 0x0401586F RID: 88175
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04015870 RID: 88176
		internal static int __PropertyOffset_69;

		// Token: 0x04015871 RID: 88177
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04015872 RID: 88178
		internal static int __PropertyOffset_70;

		// Token: 0x04015873 RID: 88179
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04015874 RID: 88180
		internal static int __PropertyOffset_71;

		// Token: 0x04015875 RID: 88181
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04015876 RID: 88182
		internal static int __PropertyOffset_72;

		// Token: 0x04015877 RID: 88183
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04015878 RID: 88184
		internal static int __PropertyOffset_73;

		// Token: 0x04015879 RID: 88185
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0401587A RID: 88186
		internal static int __PropertyOffset_74;

		// Token: 0x0401587B RID: 88187
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_3;

		// Token: 0x0401587C RID: 88188
		internal static int __PropertyOffset_75;

		// Token: 0x0401587D RID: 88189
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x0401587E RID: 88190
		internal static int __PropertyOffset_76;

		// Token: 0x0401587F RID: 88191
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04015880 RID: 88192
		internal static int __PropertyOffset_77;

		// Token: 0x04015881 RID: 88193
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04015882 RID: 88194
		internal static int __PropertyOffset_78;

		// Token: 0x04015883 RID: 88195
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_2;

		// Token: 0x04015884 RID: 88196
		internal static int __PropertyOffset_79;

		// Token: 0x04015885 RID: 88197
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04015886 RID: 88198
		internal static int __PropertyOffset_80;

		// Token: 0x04015887 RID: 88199
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04015888 RID: 88200
		internal static int __PropertyOffset_81;

		// Token: 0x04015889 RID: 88201
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x0401588A RID: 88202
		internal static int __PropertyOffset_82;

		// Token: 0x0401588B RID: 88203
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x0401588C RID: 88204
		internal static int __PropertyOffset_83;

		// Token: 0x0401588D RID: 88205
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x0401588E RID: 88206
		internal static int __PropertyOffset_84;

		// Token: 0x0401588F RID: 88207
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04015890 RID: 88208
		internal static int __PropertyOffset_85;

		// Token: 0x04015891 RID: 88209
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04015892 RID: 88210
		internal static int __PropertyOffset_86;

		// Token: 0x04015893 RID: 88211
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04015894 RID: 88212
		internal static int __PropertyOffset_87;

		// Token: 0x04015895 RID: 88213
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04015896 RID: 88214
		internal static int __PropertyOffset_88;

		// Token: 0x04015897 RID: 88215
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04015898 RID: 88216
		internal static int __PropertyOffset_89;

		// Token: 0x04015899 RID: 88217
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x0401589A RID: 88218
		internal static int __PropertyOffset_90;

		// Token: 0x0401589B RID: 88219
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x0401589C RID: 88220
		internal static int __PropertyOffset_91;

		// Token: 0x0401589D RID: 88221
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0401589E RID: 88222
		internal static int __PropertyOffset_92;

		// Token: 0x0401589F RID: 88223
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x040158A0 RID: 88224
		internal static int __PropertyOffset_93;

		// Token: 0x040158A1 RID: 88225
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x040158A2 RID: 88226
		internal static int __PropertyOffset_94;

		// Token: 0x040158A3 RID: 88227
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x040158A4 RID: 88228
		internal static int __PropertyOffset_95;

		// Token: 0x040158A5 RID: 88229
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x040158A6 RID: 88230
		internal static int __PropertyOffset_96;

		// Token: 0x040158A7 RID: 88231
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x040158A8 RID: 88232
		internal static int __PropertyOffset_97;

		// Token: 0x040158A9 RID: 88233
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040158AA RID: 88234
		internal static int __PropertyOffset_98;

		// Token: 0x040158AB RID: 88235
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x040158AC RID: 88236
		internal static int __PropertyOffset_99;

		// Token: 0x040158AD RID: 88237
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x040158AE RID: 88238
		internal static int __PropertyOffset_100;

		// Token: 0x040158AF RID: 88239
		internal static int __PropertyOffset_101;

		// Token: 0x040158B0 RID: 88240
		internal static int __PropertyOffset_102;

		// Token: 0x040158B1 RID: 88241
		internal static int __PropertyOffset_103;

		// Token: 0x040158B2 RID: 88242
		internal static int __PropertyOffset_104;

		// Token: 0x040158B3 RID: 88243
		internal static int __PropertyOffset_105;

		// Token: 0x040158B4 RID: 88244
		internal static int __PropertyOffset_106;

		// Token: 0x040158B5 RID: 88245
		[Nullable(2)]
		private TMap<int, FVector> _Target_Locations;

		// Token: 0x040158B6 RID: 88246
		internal static int __PropertyOffset_107;

		// Token: 0x040158B7 RID: 88247
		[Nullable(2)]
		private TMap<int, float> _Wheel_Speeds;

		// Token: 0x040158B8 RID: 88248
		internal static int __PropertyOffset_108;

		// Token: 0x040158B9 RID: 88249
		[Nullable(2)]
		private TMap<int, float> _Wheel_Accels;

		// Token: 0x040158BA RID: 88250
		internal static int __PropertyOffset_109;

		// Token: 0x040158BB RID: 88251
		internal static int __PropertyOffset_110;

		// Token: 0x040158BC RID: 88252
		internal static int __PropertyOffset_111;

		// Token: 0x040158BD RID: 88253
		internal static int __PropertyOffset_112;

		// Token: 0x040158BE RID: 88254
		internal static int __PropertyOffset_113;

		// Token: 0x040158BF RID: 88255
		internal static int __PropertyOffset_114;

		// Token: 0x040158C0 RID: 88256
		internal static int __PropertyOffset_115;

		// Token: 0x040158C1 RID: 88257
		internal static int __PropertyOffset_116;

		// Token: 0x040158C2 RID: 88258
		internal static int __PropertyOffset_117;

		// Token: 0x040158C3 RID: 88259
		internal static int __PropertyOffset_118;

		// Token: 0x040158C4 RID: 88260
		internal static int __PropertyOffset_119;

		// Token: 0x040158C5 RID: 88261
		internal static int __PropertyOffset_120;

		// Token: 0x040158C6 RID: 88262
		internal static int __PropertyOffset_121;

		// Token: 0x040158C7 RID: 88263
		internal static int __PropertyOffset_122;

		// Token: 0x040158C8 RID: 88264
		private static IntPtr __后处理层_NativeFunctionPtr;

		// Token: 0x040158C9 RID: 88265
		private static IntPtr __主动作层_NativeFunctionPtr;

		// Token: 0x040158CA RID: 88266
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x040158CB RID: 88267
		private static IntPtr __更新移动占比_NativeFunctionPtr;

		// Token: 0x040158CC RID: 88268
		private static IntPtr __初始化Tag_NativeFunctionPtr;

		// Token: 0x040158CD RID: 88269
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_KuroMotorIK_5478B7584DA3D294AF722187C1E304A3_NativeFunctionPtr;

		// Token: 0x040158CE RID: 88270
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_067FDBE941E7420B19E183922C5008B1_NativeFunctionPtr;

		// Token: 0x040158CF RID: 88271
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_ECEF7B234C31FB76C14B91B8BD5A2E9B_NativeFunctionPtr;

		// Token: 0x040158D0 RID: 88272
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_323761B344BAF709E5AAD9B2375906FE_NativeFunctionPtr;

		// Token: 0x040158D1 RID: 88273
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_30778B81476BE42AA316BCA15EAE9962_NativeFunctionPtr;

		// Token: 0x040158D2 RID: 88274
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_25D2FC73426E7885D4BD3EA561B996B3_NativeFunctionPtr;

		// Token: 0x040158D3 RID: 88275
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_ApplyAdditive_2AC36505459B9B79C906239A835CE6D5_NativeFunctionPtr;

		// Token: 0x040158D4 RID: 88276
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TwoWayBlend_42CEDBCC4442F197CDBCF38F629FD303_NativeFunctionPtr;

		// Token: 0x040158D5 RID: 88277
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_BlendSpacePlayer_A4962EAC428E58C1B33FC085A8699A86_NativeFunctionPtr;

		// Token: 0x040158D6 RID: 88278
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_B81CAFEC4DD5FCECBF80F7B9FD587815_NativeFunctionPtr;

		// Token: 0x040158D7 RID: 88279
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_46806B97455032FAA96D0CBCDA337F63_NativeFunctionPtr;

		// Token: 0x040158D8 RID: 88280
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_E4850800439E0EBDC996EDBF9A69706D_NativeFunctionPtr;

		// Token: 0x040158D9 RID: 88281
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_E8B7B16743C7145A3413E8A842F74D0E_NativeFunctionPtr;

		// Token: 0x040158DA RID: 88282
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_4C2EE5424AADA5C9D39C2E9EC352DBCC_NativeFunctionPtr;

		// Token: 0x040158DB RID: 88283
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Motor_BaseVehicle_AnimGraphNode_TransitionResult_81720D174354106908AC5FAD2C9B687B_NativeFunctionPtr;

		// Token: 0x040158DC RID: 88284
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040158DD RID: 88285
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x040158DE RID: 88286
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x040158DF RID: 88287
		private static IntPtr __ExecuteUbergraph_ABP_Motor_BaseVehicle_NativeFunctionPtr;

		// Token: 0x0200A13E RID: 41278
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __后处理层_FunctionParams
		{
			// Token: 0x04032E72 RID: 208498
			[FieldOffset(0)]
			public byte InPose;

			// Token: 0x04032E73 RID: 208499
			[FieldOffset(24)]
			public byte 后处理层;
		}

		// Token: 0x0200A13F RID: 41279
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __主动作层_FunctionParams
		{
			// Token: 0x04032E74 RID: 208500
			[FieldOffset(0)]
			public byte 主动作层;
		}

		// Token: 0x0200A140 RID: 41280
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032E75 RID: 208501
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A141 RID: 41281
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032E76 RID: 208502
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A142 RID: 41282
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_ABP_Motor_BaseVehicle_FunctionParams
		{
			// Token: 0x04032E77 RID: 208503
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
