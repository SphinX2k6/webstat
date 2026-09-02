using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.PlaneYinyou.BP
{
	// Token: 0x02003E78 RID: 15992
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/PlaneYinyou/BP/ABP_Plane.ABP_Plane_C")]
	[UnrealStructLayout(6512, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 6512)]
	public class ABP_Plane_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060278DB RID: 162011 RVA: 0x009F45F1 File Offset: 0x009F27F1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_Plane_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/PlaneYinyou/BP/ABP_Plane.ABP_Plane_C");
			}
			return ABP_Plane_C._ClassPtr;
		}

		// Token: 0x060278DC RID: 162012 RVA: 0x009F4618 File Offset: 0x009F2818
		public ABP_Plane_C() : this(BuiltinUtils.AllocNativeUObject(ABP_Plane_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060278DD RID: 162013 RVA: 0x009F4640 File Offset: 0x009F2840
		public ABP_Plane_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_Plane_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D7C RID: 23932
		// (get) Token: 0x060278DE RID: 162014 RVA: 0x009F4674 File Offset: 0x009F2874
		// (set) Token: 0x060278DF RID: 162015 RVA: 0x009F46AD File Offset: 0x009F28AD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D7D RID: 23933
		// (get) Token: 0x060278E0 RID: 162016 RVA: 0x009F46D0 File Offset: 0x009F28D0
		// (set) Token: 0x060278E1 RID: 162017 RVA: 0x009F4709 File Offset: 0x009F2909
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D7E RID: 23934
		// (get) Token: 0x060278E2 RID: 162018 RVA: 0x009F472C File Offset: 0x009F292C
		// (set) Token: 0x060278E3 RID: 162019 RVA: 0x009F4765 File Offset: 0x009F2965
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D7F RID: 23935
		// (get) Token: 0x060278E4 RID: 162020 RVA: 0x009F4788 File Offset: 0x009F2988
		// (set) Token: 0x060278E5 RID: 162021 RVA: 0x009F47C1 File Offset: 0x009F29C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D80 RID: 23936
		// (get) Token: 0x060278E6 RID: 162022 RVA: 0x009F47E4 File Offset: 0x009F29E4
		// (set) Token: 0x060278E7 RID: 162023 RVA: 0x009F481D File Offset: 0x009F2A1D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D81 RID: 23937
		// (get) Token: 0x060278E8 RID: 162024 RVA: 0x009F4840 File Offset: 0x009F2A40
		// (set) Token: 0x060278E9 RID: 162025 RVA: 0x009F4879 File Offset: 0x009F2A79
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D82 RID: 23938
		// (get) Token: 0x060278EA RID: 162026 RVA: 0x009F489C File Offset: 0x009F2A9C
		// (set) Token: 0x060278EB RID: 162027 RVA: 0x009F48D5 File Offset: 0x009F2AD5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D83 RID: 23939
		// (get) Token: 0x060278EC RID: 162028 RVA: 0x009F48F8 File Offset: 0x009F2AF8
		// (set) Token: 0x060278ED RID: 162029 RVA: 0x009F4931 File Offset: 0x009F2B31
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D84 RID: 23940
		// (get) Token: 0x060278EE RID: 162030 RVA: 0x009F4954 File Offset: 0x009F2B54
		// (set) Token: 0x060278EF RID: 162031 RVA: 0x009F498D File Offset: 0x009F2B8D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D85 RID: 23941
		// (get) Token: 0x060278F0 RID: 162032 RVA: 0x009F49B0 File Offset: 0x009F2BB0
		// (set) Token: 0x060278F1 RID: 162033 RVA: 0x009F49E9 File Offset: 0x009F2BE9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D86 RID: 23942
		// (get) Token: 0x060278F2 RID: 162034 RVA: 0x009F4A0C File Offset: 0x009F2C0C
		// (set) Token: 0x060278F3 RID: 162035 RVA: 0x009F4A45 File Offset: 0x009F2C45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D87 RID: 23943
		// (get) Token: 0x060278F4 RID: 162036 RVA: 0x009F4A68 File Offset: 0x009F2C68
		// (set) Token: 0x060278F5 RID: 162037 RVA: 0x009F4AA1 File Offset: 0x009F2CA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D88 RID: 23944
		// (get) Token: 0x060278F6 RID: 162038 RVA: 0x009F4AC4 File Offset: 0x009F2CC4
		// (set) Token: 0x060278F7 RID: 162039 RVA: 0x009F4AFD File Offset: 0x009F2CFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D89 RID: 23945
		// (get) Token: 0x060278F8 RID: 162040 RVA: 0x009F4B20 File Offset: 0x009F2D20
		// (set) Token: 0x060278F9 RID: 162041 RVA: 0x009F4B59 File Offset: 0x009F2D59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D8A RID: 23946
		// (get) Token: 0x060278FA RID: 162042 RVA: 0x009F4B7C File Offset: 0x009F2D7C
		// (set) Token: 0x060278FB RID: 162043 RVA: 0x009F4BB5 File Offset: 0x009F2DB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D8B RID: 23947
		// (get) Token: 0x060278FC RID: 162044 RVA: 0x009F4BD8 File Offset: 0x009F2DD8
		// (set) Token: 0x060278FD RID: 162045 RVA: 0x009F4C11 File Offset: 0x009F2E11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D8C RID: 23948
		// (get) Token: 0x060278FE RID: 162046 RVA: 0x009F4C34 File Offset: 0x009F2E34
		// (set) Token: 0x060278FF RID: 162047 RVA: 0x009F4C6D File Offset: 0x009F2E6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D8D RID: 23949
		// (get) Token: 0x06027900 RID: 162048 RVA: 0x009F4C90 File Offset: 0x009F2E90
		// (set) Token: 0x06027901 RID: 162049 RVA: 0x009F4CC9 File Offset: 0x009F2EC9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D8E RID: 23950
		// (get) Token: 0x06027902 RID: 162050 RVA: 0x009F4CEC File Offset: 0x009F2EEC
		// (set) Token: 0x06027903 RID: 162051 RVA: 0x009F4D25 File Offset: 0x009F2F25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D8F RID: 23951
		// (get) Token: 0x06027904 RID: 162052 RVA: 0x009F4D48 File Offset: 0x009F2F48
		// (set) Token: 0x06027905 RID: 162053 RVA: 0x009F4D81 File Offset: 0x009F2F81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D90 RID: 23952
		// (get) Token: 0x06027906 RID: 162054 RVA: 0x009F4DA4 File Offset: 0x009F2FA4
		// (set) Token: 0x06027907 RID: 162055 RVA: 0x009F4DDD File Offset: 0x009F2FDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D91 RID: 23953
		// (get) Token: 0x06027908 RID: 162056 RVA: 0x009F4E00 File Offset: 0x009F3000
		// (set) Token: 0x06027909 RID: 162057 RVA: 0x009F4E39 File Offset: 0x009F3039
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D92 RID: 23954
		// (get) Token: 0x0602790A RID: 162058 RVA: 0x009F4E5C File Offset: 0x009F305C
		// (set) Token: 0x0602790B RID: 162059 RVA: 0x009F4E95 File Offset: 0x009F3095
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D93 RID: 23955
		// (get) Token: 0x0602790C RID: 162060 RVA: 0x009F4EB8 File Offset: 0x009F30B8
		// (set) Token: 0x0602790D RID: 162061 RVA: 0x009F4EF1 File Offset: 0x009F30F1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D94 RID: 23956
		// (get) Token: 0x0602790E RID: 162062 RVA: 0x009F4F14 File Offset: 0x009F3114
		// (set) Token: 0x0602790F RID: 162063 RVA: 0x009F4F4D File Offset: 0x009F314D
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D95 RID: 23957
		// (get) Token: 0x06027910 RID: 162064 RVA: 0x009F4F70 File Offset: 0x009F3170
		// (set) Token: 0x06027911 RID: 162065 RVA: 0x009F4FA9 File Offset: 0x009F31A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D96 RID: 23958
		// (get) Token: 0x06027912 RID: 162066 RVA: 0x009F4FCC File Offset: 0x009F31CC
		// (set) Token: 0x06027913 RID: 162067 RVA: 0x009F5005 File Offset: 0x009F3205
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D97 RID: 23959
		// (get) Token: 0x06027914 RID: 162068 RVA: 0x009F5028 File Offset: 0x009F3228
		// (set) Token: 0x06027915 RID: 162069 RVA: 0x009F5061 File Offset: 0x009F3261
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D98 RID: 23960
		// (get) Token: 0x06027916 RID: 162070 RVA: 0x009F5084 File Offset: 0x009F3284
		// (set) Token: 0x06027917 RID: 162071 RVA: 0x009F50BD File Offset: 0x009F32BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D99 RID: 23961
		// (get) Token: 0x06027918 RID: 162072 RVA: 0x009F50E0 File Offset: 0x009F32E0
		// (set) Token: 0x06027919 RID: 162073 RVA: 0x009F5119 File Offset: 0x009F3319
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D9A RID: 23962
		// (get) Token: 0x0602791A RID: 162074 RVA: 0x009F513C File Offset: 0x009F333C
		// (set) Token: 0x0602791B RID: 162075 RVA: 0x009F5175 File Offset: 0x009F3375
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D9B RID: 23963
		// (get) Token: 0x0602791C RID: 162076 RVA: 0x009F5198 File Offset: 0x009F3398
		// (set) Token: 0x0602791D RID: 162077 RVA: 0x009F51D1 File Offset: 0x009F33D1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D9C RID: 23964
		// (get) Token: 0x0602791E RID: 162078 RVA: 0x009F51F4 File Offset: 0x009F33F4
		// (set) Token: 0x0602791F RID: 162079 RVA: 0x009F522D File Offset: 0x009F342D
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D9D RID: 23965
		// (get) Token: 0x06027920 RID: 162080 RVA: 0x009F5250 File Offset: 0x009F3450
		// (set) Token: 0x06027921 RID: 162081 RVA: 0x009F5289 File Offset: 0x009F3489
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D9E RID: 23966
		// (get) Token: 0x06027922 RID: 162082 RVA: 0x009F52AC File Offset: 0x009F34AC
		// (set) Token: 0x06027923 RID: 162083 RVA: 0x009F52E5 File Offset: 0x009F34E5
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005D9F RID: 23967
		// (get) Token: 0x06027924 RID: 162084 RVA: 0x009F5308 File Offset: 0x009F3508
		// (set) Token: 0x06027925 RID: 162085 RVA: 0x009F5341 File Offset: 0x009F3541
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA0 RID: 23968
		// (get) Token: 0x06027926 RID: 162086 RVA: 0x009F5364 File Offset: 0x009F3564
		// (set) Token: 0x06027927 RID: 162087 RVA: 0x009F539D File Offset: 0x009F359D
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA1 RID: 23969
		// (get) Token: 0x06027928 RID: 162088 RVA: 0x009F53C0 File Offset: 0x009F35C0
		// (set) Token: 0x06027929 RID: 162089 RVA: 0x009F53F9 File Offset: 0x009F35F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA2 RID: 23970
		// (get) Token: 0x0602792A RID: 162090 RVA: 0x009F541C File Offset: 0x009F361C
		// (set) Token: 0x0602792B RID: 162091 RVA: 0x009F5455 File Offset: 0x009F3655
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA3 RID: 23971
		// (get) Token: 0x0602792C RID: 162092 RVA: 0x009F5478 File Offset: 0x009F3678
		// (set) Token: 0x0602792D RID: 162093 RVA: 0x009F54B1 File Offset: 0x009F36B1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA4 RID: 23972
		// (get) Token: 0x0602792E RID: 162094 RVA: 0x009F54D4 File Offset: 0x009F36D4
		// (set) Token: 0x0602792F RID: 162095 RVA: 0x009F550D File Offset: 0x009F370D
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA5 RID: 23973
		// (get) Token: 0x06027930 RID: 162096 RVA: 0x009F5530 File Offset: 0x009F3730
		// (set) Token: 0x06027931 RID: 162097 RVA: 0x009F5569 File Offset: 0x009F3769
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA6 RID: 23974
		// (get) Token: 0x06027932 RID: 162098 RVA: 0x009F558C File Offset: 0x009F378C
		// (set) Token: 0x06027933 RID: 162099 RVA: 0x009F55C5 File Offset: 0x009F37C5
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA7 RID: 23975
		// (get) Token: 0x06027934 RID: 162100 RVA: 0x009F55E8 File Offset: 0x009F37E8
		// (set) Token: 0x06027935 RID: 162101 RVA: 0x009F5621 File Offset: 0x009F3821
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005DA8 RID: 23976
		// (get) Token: 0x06027936 RID: 162102 RVA: 0x009F5642 File Offset: 0x009F3842
		// (set) Token: 0x06027937 RID: 162103 RVA: 0x009F5652 File Offset: 0x009F3852
		public unsafe bool InputRollL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DA9 RID: 23977
		// (get) Token: 0x06027938 RID: 162104 RVA: 0x009F5663 File Offset: 0x009F3863
		// (set) Token: 0x06027939 RID: 162105 RVA: 0x009F5673 File Offset: 0x009F3873
		public unsafe float Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17005DAA RID: 23978
		// (get) Token: 0x0602793A RID: 162106 RVA: 0x009F5684 File Offset: 0x009F3884
		// (set) Token: 0x0602793B RID: 162107 RVA: 0x009F5694 File Offset: 0x009F3894
		public unsafe bool InputRollR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_46) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_46) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DAB RID: 23979
		// (get) Token: 0x0602793C RID: 162108 RVA: 0x009F56A5 File Offset: 0x009F38A5
		// (set) Token: 0x0602793D RID: 162109 RVA: 0x009F56B5 File Offset: 0x009F38B5
		public unsafe float Horzontal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x17005DAC RID: 23980
		// (get) Token: 0x0602793E RID: 162110 RVA: 0x009F56C6 File Offset: 0x009F38C6
		// (set) Token: 0x0602793F RID: 162111 RVA: 0x009F56D6 File Offset: 0x009F38D6
		public unsafe float Jump_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17005DAD RID: 23981
		// (get) Token: 0x06027940 RID: 162112 RVA: 0x009F56E7 File Offset: 0x009F38E7
		// (set) Token: 0x06027941 RID: 162113 RVA: 0x009F56F7 File Offset: 0x009F38F7
		public unsafe bool InputJump
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_49) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_49) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DAE RID: 23982
		// (get) Token: 0x06027942 RID: 162114 RVA: 0x009F5708 File Offset: 0x009F3908
		// (set) Token: 0x06027943 RID: 162115 RVA: 0x009F5718 File Offset: 0x009F3918
		public unsafe bool InputRollL3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DAF RID: 23983
		// (get) Token: 0x06027944 RID: 162116 RVA: 0x009F5729 File Offset: 0x009F3929
		// (set) Token: 0x06027945 RID: 162117 RVA: 0x009F5739 File Offset: 0x009F3939
		public unsafe bool InputRollR3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_51) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_51) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DB0 RID: 23984
		// (get) Token: 0x06027946 RID: 162118 RVA: 0x009F574A File Offset: 0x009F394A
		// (set) Token: 0x06027947 RID: 162119 RVA: 0x009F575A File Offset: 0x009F395A
		public unsafe float BlendTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_52);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_52) = value;
			}
		}

		// Token: 0x17005DB1 RID: 23985
		// (get) Token: 0x06027948 RID: 162120 RVA: 0x009F576B File Offset: 0x009F396B
		// (set) Token: 0x06027949 RID: 162121 RVA: 0x009F577B File Offset: 0x009F397B
		public unsafe bool InputSwingL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_53) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_53) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DB2 RID: 23986
		// (get) Token: 0x0602794A RID: 162122 RVA: 0x009F578C File Offset: 0x009F398C
		// (set) Token: 0x0602794B RID: 162123 RVA: 0x009F579C File Offset: 0x009F399C
		public unsafe bool InputSwingR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DB3 RID: 23987
		// (get) Token: 0x0602794C RID: 162124 RVA: 0x009F57AD File Offset: 0x009F39AD
		// (set) Token: 0x0602794D RID: 162125 RVA: 0x009F57BD File Offset: 0x009F39BD
		public unsafe bool InputMoveL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_55) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_55) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005DB4 RID: 23988
		// (get) Token: 0x0602794E RID: 162126 RVA: 0x009F57CE File Offset: 0x009F39CE
		// (set) Token: 0x0602794F RID: 162127 RVA: 0x009F57DE File Offset: 0x009F39DE
		public unsafe bool InputMoveR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_Plane_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027950 RID: 162128 RVA: 0x009F57F0 File Offset: 0x009F39F0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_Plane_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_Plane_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_Plane_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Plane_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x06027951 RID: 162129 RVA: 0x009F5877 File Offset: 0x009F3A77
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_C491800044967B3863A3149F54B370B6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_C491800044967B3863A3149F54B370B6_NativeFunctionPtr, null);
		}

		// Token: 0x06027952 RID: 162130 RVA: 0x009F588B File Offset: 0x009F3A8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_02CE6CA3473604270A3E1B8B8271ABC7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_02CE6CA3473604270A3E1B8B8271ABC7_NativeFunctionPtr, null);
		}

		// Token: 0x06027953 RID: 162131 RVA: 0x009F589F File Offset: 0x009F3A9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_DDBFCBC347DD454B62ED81B5FBA6F2CA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_DDBFCBC347DD454B62ED81B5FBA6F2CA_NativeFunctionPtr, null);
		}

		// Token: 0x06027954 RID: 162132 RVA: 0x009F58B3 File Offset: 0x009F3AB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_A55DBF2F47622061FAE27FB9D90A8EF9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_A55DBF2F47622061FAE27FB9D90A8EF9_NativeFunctionPtr, null);
		}

		// Token: 0x06027955 RID: 162133 RVA: 0x009F58C7 File Offset: 0x009F3AC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_6A8E0CC94881457BFF7CC793E169843D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_6A8E0CC94881457BFF7CC793E169843D_NativeFunctionPtr, null);
		}

		// Token: 0x06027956 RID: 162134 RVA: 0x009F58DB File Offset: 0x009F3ADB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_500EEFB54CF06FD93DA2E2B5ADEB4026()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_500EEFB54CF06FD93DA2E2B5ADEB4026_NativeFunctionPtr, null);
		}

		// Token: 0x06027957 RID: 162135 RVA: 0x009F58EF File Offset: 0x009F3AEF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_ABBC99E84007975BB2AD938AD15127D3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_ABBC99E84007975BB2AD938AD15127D3_NativeFunctionPtr, null);
		}

		// Token: 0x06027958 RID: 162136 RVA: 0x009F5903 File Offset: 0x009F3B03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_4BCB6085408731D2CE0C049076BB28B7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_4BCB6085408731D2CE0C049076BB28B7_NativeFunctionPtr, null);
		}

		// Token: 0x06027959 RID: 162137 RVA: 0x009F5918 File Offset: 0x009F3B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_Plane_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_Plane_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Plane_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Plane_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_Plane_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602795A RID: 162138 RVA: 0x009F5960 File Offset: 0x009F3B60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_Plane_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_Plane_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_Plane_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Plane_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Plane_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602795B RID: 162139 RVA: 0x009F59A8 File Offset: 0x009F3BA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_Plane(int EntryPoint)
		{
			ABP_Plane_C.__ExecuteUbergraph_ABP_Plane_FunctionParams* ptr = stackalloc ABP_Plane_C.__ExecuteUbergraph_ABP_Plane_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(ABP_Plane_C.__ExecuteUbergraph_ABP_Plane_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_Plane_C.__ExecuteUbergraph_ABP_Plane_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_Plane_C.__ExecuteUbergraph_ABP_Plane_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602795C RID: 162140 RVA: 0x009F59EF File Offset: 0x009F3BEF
		protected ABP_Plane_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B8D RID: 84877
		public new const string __ObjectPath = "/Game/Aki/Data/Level/PlaneYinyou/BP/ABP_Plane.ABP_Plane_C";

		// Token: 0x04014B8E RID: 84878
		private static IntPtr _ClassPtr;

		// Token: 0x04014B8F RID: 84879
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B90 RID: 84880
		internal static int __PropertyOffset_0;

		// Token: 0x04014B91 RID: 84881
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014B92 RID: 84882
		internal static int __PropertyOffset_1;

		// Token: 0x04014B93 RID: 84883
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04014B94 RID: 84884
		internal static int __PropertyOffset_2;

		// Token: 0x04014B95 RID: 84885
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04014B96 RID: 84886
		internal static int __PropertyOffset_3;

		// Token: 0x04014B97 RID: 84887
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x04014B98 RID: 84888
		internal static int __PropertyOffset_4;

		// Token: 0x04014B99 RID: 84889
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x04014B9A RID: 84890
		internal static int __PropertyOffset_5;

		// Token: 0x04014B9B RID: 84891
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04014B9C RID: 84892
		internal static int __PropertyOffset_6;

		// Token: 0x04014B9D RID: 84893
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04014B9E RID: 84894
		internal static int __PropertyOffset_7;

		// Token: 0x04014B9F RID: 84895
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04014BA0 RID: 84896
		internal static int __PropertyOffset_8;

		// Token: 0x04014BA1 RID: 84897
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04014BA2 RID: 84898
		internal static int __PropertyOffset_9;

		// Token: 0x04014BA3 RID: 84899
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x04014BA4 RID: 84900
		internal static int __PropertyOffset_10;

		// Token: 0x04014BA5 RID: 84901
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x04014BA6 RID: 84902
		internal static int __PropertyOffset_11;

		// Token: 0x04014BA7 RID: 84903
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x04014BA8 RID: 84904
		internal static int __PropertyOffset_12;

		// Token: 0x04014BA9 RID: 84905
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04014BAA RID: 84906
		internal static int __PropertyOffset_13;

		// Token: 0x04014BAB RID: 84907
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04014BAC RID: 84908
		internal static int __PropertyOffset_14;

		// Token: 0x04014BAD RID: 84909
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04014BAE RID: 84910
		internal static int __PropertyOffset_15;

		// Token: 0x04014BAF RID: 84911
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04014BB0 RID: 84912
		internal static int __PropertyOffset_16;

		// Token: 0x04014BB1 RID: 84913
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04014BB2 RID: 84914
		internal static int __PropertyOffset_17;

		// Token: 0x04014BB3 RID: 84915
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04014BB4 RID: 84916
		internal static int __PropertyOffset_18;

		// Token: 0x04014BB5 RID: 84917
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04014BB6 RID: 84918
		internal static int __PropertyOffset_19;

		// Token: 0x04014BB7 RID: 84919
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04014BB8 RID: 84920
		internal static int __PropertyOffset_20;

		// Token: 0x04014BB9 RID: 84921
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04014BBA RID: 84922
		internal static int __PropertyOffset_21;

		// Token: 0x04014BBB RID: 84923
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04014BBC RID: 84924
		internal static int __PropertyOffset_22;

		// Token: 0x04014BBD RID: 84925
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04014BBE RID: 84926
		internal static int __PropertyOffset_23;

		// Token: 0x04014BBF RID: 84927
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04014BC0 RID: 84928
		internal static int __PropertyOffset_24;

		// Token: 0x04014BC1 RID: 84929
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04014BC2 RID: 84930
		internal static int __PropertyOffset_25;

		// Token: 0x04014BC3 RID: 84931
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04014BC4 RID: 84932
		internal static int __PropertyOffset_26;

		// Token: 0x04014BC5 RID: 84933
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04014BC6 RID: 84934
		internal static int __PropertyOffset_27;

		// Token: 0x04014BC7 RID: 84935
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04014BC8 RID: 84936
		internal static int __PropertyOffset_28;

		// Token: 0x04014BC9 RID: 84937
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04014BCA RID: 84938
		internal static int __PropertyOffset_29;

		// Token: 0x04014BCB RID: 84939
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04014BCC RID: 84940
		internal static int __PropertyOffset_30;

		// Token: 0x04014BCD RID: 84941
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04014BCE RID: 84942
		internal static int __PropertyOffset_31;

		// Token: 0x04014BCF RID: 84943
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04014BD0 RID: 84944
		internal static int __PropertyOffset_32;

		// Token: 0x04014BD1 RID: 84945
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04014BD2 RID: 84946
		internal static int __PropertyOffset_33;

		// Token: 0x04014BD3 RID: 84947
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04014BD4 RID: 84948
		internal static int __PropertyOffset_34;

		// Token: 0x04014BD5 RID: 84949
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04014BD6 RID: 84950
		internal static int __PropertyOffset_35;

		// Token: 0x04014BD7 RID: 84951
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x04014BD8 RID: 84952
		internal static int __PropertyOffset_36;

		// Token: 0x04014BD9 RID: 84953
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04014BDA RID: 84954
		internal static int __PropertyOffset_37;

		// Token: 0x04014BDB RID: 84955
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04014BDC RID: 84956
		internal static int __PropertyOffset_38;

		// Token: 0x04014BDD RID: 84957
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04014BDE RID: 84958
		internal static int __PropertyOffset_39;

		// Token: 0x04014BDF RID: 84959
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04014BE0 RID: 84960
		internal static int __PropertyOffset_40;

		// Token: 0x04014BE1 RID: 84961
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04014BE2 RID: 84962
		internal static int __PropertyOffset_41;

		// Token: 0x04014BE3 RID: 84963
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04014BE4 RID: 84964
		internal static int __PropertyOffset_42;

		// Token: 0x04014BE5 RID: 84965
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04014BE6 RID: 84966
		internal static int __PropertyOffset_43;

		// Token: 0x04014BE7 RID: 84967
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04014BE8 RID: 84968
		internal static int __PropertyOffset_44;

		// Token: 0x04014BE9 RID: 84969
		internal static int __PropertyOffset_45;

		// Token: 0x04014BEA RID: 84970
		internal static int __PropertyOffset_46;

		// Token: 0x04014BEB RID: 84971
		internal static int __PropertyOffset_47;

		// Token: 0x04014BEC RID: 84972
		internal static int __PropertyOffset_48;

		// Token: 0x04014BED RID: 84973
		internal static int __PropertyOffset_49;

		// Token: 0x04014BEE RID: 84974
		internal static int __PropertyOffset_50;

		// Token: 0x04014BEF RID: 84975
		internal static int __PropertyOffset_51;

		// Token: 0x04014BF0 RID: 84976
		internal static int __PropertyOffset_52;

		// Token: 0x04014BF1 RID: 84977
		internal static int __PropertyOffset_53;

		// Token: 0x04014BF2 RID: 84978
		internal static int __PropertyOffset_54;

		// Token: 0x04014BF3 RID: 84979
		internal static int __PropertyOffset_55;

		// Token: 0x04014BF4 RID: 84980
		internal static int __PropertyOffset_56;

		// Token: 0x04014BF5 RID: 84981
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04014BF6 RID: 84982
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_C491800044967B3863A3149F54B370B6_NativeFunctionPtr;

		// Token: 0x04014BF7 RID: 84983
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_02CE6CA3473604270A3E1B8B8271ABC7_NativeFunctionPtr;

		// Token: 0x04014BF8 RID: 84984
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_DDBFCBC347DD454B62ED81B5FBA6F2CA_NativeFunctionPtr;

		// Token: 0x04014BF9 RID: 84985
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_A55DBF2F47622061FAE27FB9D90A8EF9_NativeFunctionPtr;

		// Token: 0x04014BFA RID: 84986
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_6A8E0CC94881457BFF7CC793E169843D_NativeFunctionPtr;

		// Token: 0x04014BFB RID: 84987
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_500EEFB54CF06FD93DA2E2B5ADEB4026_NativeFunctionPtr;

		// Token: 0x04014BFC RID: 84988
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_ABBC99E84007975BB2AD938AD15127D3_NativeFunctionPtr;

		// Token: 0x04014BFD RID: 84989
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_Plane_AnimGraphNode_TransitionResult_4BCB6085408731D2CE0C049076BB28B7_NativeFunctionPtr;

		// Token: 0x04014BFE RID: 84990
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04014BFF RID: 84991
		private static IntPtr __ExecuteUbergraph_ABP_Plane_NativeFunctionPtr;

		// Token: 0x0200A0D6 RID: 41174
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032D8B RID: 208267
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A0D7 RID: 41175
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04032D8C RID: 208268
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A0D8 RID: 41176
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_ABP_Plane_FunctionParams
		{
			// Token: 0x04032D8D RID: 208269
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
