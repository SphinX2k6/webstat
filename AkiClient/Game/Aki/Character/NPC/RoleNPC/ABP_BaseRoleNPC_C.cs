using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.AI.AIFunctionCommon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.RoleNPC
{
	// Token: 0x020040DD RID: 16605
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/RoleNPC/ABP_BaseRoleNPC.ABP_BaseRoleNPC_C")]
	[UnrealStructLayout(54992, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 54988)]
	public class ABP_BaseRoleNPC_C : UKuroAnimInstanceChar, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B7B3 RID: 178099 RVA: 0x00A7DCD3 File Offset: 0x00A7BED3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRoleNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/RoleNPC/ABP_BaseRoleNPC.ABP_BaseRoleNPC_C");
			}
			return ABP_BaseRoleNPC_C._ClassPtr;
		}

		// Token: 0x0602B7B4 RID: 178100 RVA: 0x00A7DCF8 File Offset: 0x00A7BEF8
		public ABP_BaseRoleNPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRoleNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B7B5 RID: 178101 RVA: 0x00A7DD20 File Offset: 0x00A7BF20
		public ABP_BaseRoleNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRoleNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700721D RID: 29213
		// (get) Token: 0x0602B7B6 RID: 178102 RVA: 0x00A7DD54 File Offset: 0x00A7BF54
		// (set) Token: 0x0602B7B7 RID: 178103 RVA: 0x00A7DD8D File Offset: 0x00A7BF8D
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700721E RID: 29214
		// (get) Token: 0x0602B7B8 RID: 178104 RVA: 0x00A7DDB0 File Offset: 0x00A7BFB0
		// (set) Token: 0x0602B7B9 RID: 178105 RVA: 0x00A7DDE9 File Offset: 0x00A7BFE9
		public FAnimNode_Root AnimGraphNode_Root_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_5) == null)
				{
					result = (this._AnimGraphNode_Root_5 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700721F RID: 29215
		// (get) Token: 0x0602B7BA RID: 178106 RVA: 0x00A7DE0C File Offset: 0x00A7C00C
		// (set) Token: 0x0602B7BB RID: 178107 RVA: 0x00A7DE45 File Offset: 0x00A7C045
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_7) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_7 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007220 RID: 29216
		// (get) Token: 0x0602B7BC RID: 178108 RVA: 0x00A7DE68 File Offset: 0x00A7C068
		// (set) Token: 0x0602B7BD RID: 178109 RVA: 0x00A7DEA1 File Offset: 0x00A7C0A1
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_6) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_6 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007221 RID: 29217
		// (get) Token: 0x0602B7BE RID: 178110 RVA: 0x00A7DEC4 File Offset: 0x00A7C0C4
		// (set) Token: 0x0602B7BF RID: 178111 RVA: 0x00A7DEFD File Offset: 0x00A7C0FD
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_5) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_5 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007222 RID: 29218
		// (get) Token: 0x0602B7C0 RID: 178112 RVA: 0x00A7DF20 File Offset: 0x00A7C120
		// (set) Token: 0x0602B7C1 RID: 178113 RVA: 0x00A7DF59 File Offset: 0x00A7C159
		public FAnimNode_AdditiveBoneBlend AnimGraphNode_AdditiveBoneBlend_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_AdditiveBoneBlend result;
				if ((result = this._AnimGraphNode_AdditiveBoneBlend_3) == null)
				{
					result = (this._AnimGraphNode_AdditiveBoneBlend_3 = new FAnimNode_AdditiveBoneBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_AdditiveBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007223 RID: 29219
		// (get) Token: 0x0602B7C2 RID: 178114 RVA: 0x00A7DF7C File Offset: 0x00A7C17C
		// (set) Token: 0x0602B7C3 RID: 178115 RVA: 0x00A7DFB5 File Offset: 0x00A7C1B5
		public FAnimNode_Root AnimGraphNode_Root_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_4) == null)
				{
					result = (this._AnimGraphNode_Root_4 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007224 RID: 29220
		// (get) Token: 0x0602B7C4 RID: 178116 RVA: 0x00A7DFD8 File Offset: 0x00A7C1D8
		// (set) Token: 0x0602B7C5 RID: 178117 RVA: 0x00A7E011 File Offset: 0x00A7C211
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_53) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_53 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007225 RID: 29221
		// (get) Token: 0x0602B7C6 RID: 178118 RVA: 0x00A7E034 File Offset: 0x00A7C234
		// (set) Token: 0x0602B7C7 RID: 178119 RVA: 0x00A7E06D File Offset: 0x00A7C26D
		public FAnimNode_Root AnimGraphNode_Root_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_3) == null)
				{
					result = (this._AnimGraphNode_Root_3 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007226 RID: 29222
		// (get) Token: 0x0602B7C8 RID: 178120 RVA: 0x00A7E090 File Offset: 0x00A7C290
		// (set) Token: 0x0602B7C9 RID: 178121 RVA: 0x00A7E0C9 File Offset: 0x00A7C2C9
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_6) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_6 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007227 RID: 29223
		// (get) Token: 0x0602B7CA RID: 178122 RVA: 0x00A7E0EC File Offset: 0x00A7C2EC
		// (set) Token: 0x0602B7CB RID: 178123 RVA: 0x00A7E125 File Offset: 0x00A7C325
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_5) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_5 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007228 RID: 29224
		// (get) Token: 0x0602B7CC RID: 178124 RVA: 0x00A7E148 File Offset: 0x00A7C348
		// (set) Token: 0x0602B7CD RID: 178125 RVA: 0x00A7E181 File Offset: 0x00A7C381
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_4) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_4 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007229 RID: 29225
		// (get) Token: 0x0602B7CE RID: 178126 RVA: 0x00A7E1A4 File Offset: 0x00A7C3A4
		// (set) Token: 0x0602B7CF RID: 178127 RVA: 0x00A7E1DD File Offset: 0x00A7C3DD
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_4) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_4 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700722A RID: 29226
		// (get) Token: 0x0602B7D0 RID: 178128 RVA: 0x00A7E200 File Offset: 0x00A7C400
		// (set) Token: 0x0602B7D1 RID: 178129 RVA: 0x00A7E239 File Offset: 0x00A7C439
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_3) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_3 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700722B RID: 29227
		// (get) Token: 0x0602B7D2 RID: 178130 RVA: 0x00A7E25C File Offset: 0x00A7C45C
		// (set) Token: 0x0602B7D3 RID: 178131 RVA: 0x00A7E295 File Offset: 0x00A7C495
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_2) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_2 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700722C RID: 29228
		// (get) Token: 0x0602B7D4 RID: 178132 RVA: 0x00A7E2B8 File Offset: 0x00A7C4B8
		// (set) Token: 0x0602B7D5 RID: 178133 RVA: 0x00A7E2F1 File Offset: 0x00A7C4F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_120
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_120) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_120 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700722D RID: 29229
		// (get) Token: 0x0602B7D6 RID: 178134 RVA: 0x00A7E314 File Offset: 0x00A7C514
		// (set) Token: 0x0602B7D7 RID: 178135 RVA: 0x00A7E34D File Offset: 0x00A7C54D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_119
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_119) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_119 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700722E RID: 29230
		// (get) Token: 0x0602B7D8 RID: 178136 RVA: 0x00A7E370 File Offset: 0x00A7C570
		// (set) Token: 0x0602B7D9 RID: 178137 RVA: 0x00A7E3A9 File Offset: 0x00A7C5A9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_18) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_18 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700722F RID: 29231
		// (get) Token: 0x0602B7DA RID: 178138 RVA: 0x00A7E3CC File Offset: 0x00A7C5CC
		// (set) Token: 0x0602B7DB RID: 178139 RVA: 0x00A7E405 File Offset: 0x00A7C605
		public FAnimNode_StateResult AnimGraphNode_StateResult_76
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_76) == null)
				{
					result = (this._AnimGraphNode_StateResult_76 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007230 RID: 29232
		// (get) Token: 0x0602B7DC RID: 178140 RVA: 0x00A7E428 File Offset: 0x00A7C628
		// (set) Token: 0x0602B7DD RID: 178141 RVA: 0x00A7E461 File Offset: 0x00A7C661
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_4) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_4 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007231 RID: 29233
		// (get) Token: 0x0602B7DE RID: 178142 RVA: 0x00A7E484 File Offset: 0x00A7C684
		// (set) Token: 0x0602B7DF RID: 178143 RVA: 0x00A7E4BD File Offset: 0x00A7C6BD
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_17) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_17 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007232 RID: 29234
		// (get) Token: 0x0602B7E0 RID: 178144 RVA: 0x00A7E4E0 File Offset: 0x00A7C6E0
		// (set) Token: 0x0602B7E1 RID: 178145 RVA: 0x00A7E519 File Offset: 0x00A7C719
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_16) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_16 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007233 RID: 29235
		// (get) Token: 0x0602B7E2 RID: 178146 RVA: 0x00A7E53C File Offset: 0x00A7C73C
		// (set) Token: 0x0602B7E3 RID: 178147 RVA: 0x00A7E575 File Offset: 0x00A7C775
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_15) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_15 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007234 RID: 29236
		// (get) Token: 0x0602B7E4 RID: 178148 RVA: 0x00A7E598 File Offset: 0x00A7C798
		// (set) Token: 0x0602B7E5 RID: 178149 RVA: 0x00A7E5D1 File Offset: 0x00A7C7D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_75
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_75) == null)
				{
					result = (this._AnimGraphNode_StateResult_75 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007235 RID: 29237
		// (get) Token: 0x0602B7E6 RID: 178150 RVA: 0x00A7E5F4 File Offset: 0x00A7C7F4
		// (set) Token: 0x0602B7E7 RID: 178151 RVA: 0x00A7E62D File Offset: 0x00A7C82D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_20) == null)
				{
					result = (this._AnimGraphNode_StateMachine_20 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007236 RID: 29238
		// (get) Token: 0x0602B7E8 RID: 178152 RVA: 0x00A7E650 File Offset: 0x00A7C850
		// (set) Token: 0x0602B7E9 RID: 178153 RVA: 0x00A7E689 File Offset: 0x00A7C889
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007237 RID: 29239
		// (get) Token: 0x0602B7EA RID: 178154 RVA: 0x00A7E6AC File Offset: 0x00A7C8AC
		// (set) Token: 0x0602B7EB RID: 178155 RVA: 0x00A7E6E5 File Offset: 0x00A7C8E5
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_3) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_3 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007238 RID: 29240
		// (get) Token: 0x0602B7EC RID: 178156 RVA: 0x00A7E708 File Offset: 0x00A7C908
		// (set) Token: 0x0602B7ED RID: 178157 RVA: 0x00A7E741 File Offset: 0x00A7C941
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_1) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_1 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007239 RID: 29241
		// (get) Token: 0x0602B7EE RID: 178158 RVA: 0x00A7E764 File Offset: 0x00A7C964
		// (set) Token: 0x0602B7EF RID: 178159 RVA: 0x00A7E79D File Offset: 0x00A7C99D
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_2) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_2 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700723A RID: 29242
		// (get) Token: 0x0602B7F0 RID: 178160 RVA: 0x00A7E7C0 File Offset: 0x00A7C9C0
		// (set) Token: 0x0602B7F1 RID: 178161 RVA: 0x00A7E7F9 File Offset: 0x00A7C9F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_118
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_118) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_118 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700723B RID: 29243
		// (get) Token: 0x0602B7F2 RID: 178162 RVA: 0x00A7E81C File Offset: 0x00A7CA1C
		// (set) Token: 0x0602B7F3 RID: 178163 RVA: 0x00A7E855 File Offset: 0x00A7CA55
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_117
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_117) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_117 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700723C RID: 29244
		// (get) Token: 0x0602B7F4 RID: 178164 RVA: 0x00A7E878 File Offset: 0x00A7CA78
		// (set) Token: 0x0602B7F5 RID: 178165 RVA: 0x00A7E8B1 File Offset: 0x00A7CAB1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_116
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_116) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_116 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700723D RID: 29245
		// (get) Token: 0x0602B7F6 RID: 178166 RVA: 0x00A7E8D4 File Offset: 0x00A7CAD4
		// (set) Token: 0x0602B7F7 RID: 178167 RVA: 0x00A7E90D File Offset: 0x00A7CB0D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_115
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_115) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_115 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700723E RID: 29246
		// (get) Token: 0x0602B7F8 RID: 178168 RVA: 0x00A7E930 File Offset: 0x00A7CB30
		// (set) Token: 0x0602B7F9 RID: 178169 RVA: 0x00A7E969 File Offset: 0x00A7CB69
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_114
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_114) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_114 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700723F RID: 29247
		// (get) Token: 0x0602B7FA RID: 178170 RVA: 0x00A7E98C File Offset: 0x00A7CB8C
		// (set) Token: 0x0602B7FB RID: 178171 RVA: 0x00A7E9C5 File Offset: 0x00A7CBC5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_113
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_113) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_113 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007240 RID: 29248
		// (get) Token: 0x0602B7FC RID: 178172 RVA: 0x00A7E9E8 File Offset: 0x00A7CBE8
		// (set) Token: 0x0602B7FD RID: 178173 RVA: 0x00A7EA21 File Offset: 0x00A7CC21
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_112
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_112) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_112 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007241 RID: 29249
		// (get) Token: 0x0602B7FE RID: 178174 RVA: 0x00A7EA44 File Offset: 0x00A7CC44
		// (set) Token: 0x0602B7FF RID: 178175 RVA: 0x00A7EA7D File Offset: 0x00A7CC7D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_111
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_111) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_111 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007242 RID: 29250
		// (get) Token: 0x0602B800 RID: 178176 RVA: 0x00A7EAA0 File Offset: 0x00A7CCA0
		// (set) Token: 0x0602B801 RID: 178177 RVA: 0x00A7EAD9 File Offset: 0x00A7CCD9
		public FAnimNode_AdditiveBoneBlend AnimGraphNode_AdditiveBoneBlend_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_AdditiveBoneBlend result;
				if ((result = this._AnimGraphNode_AdditiveBoneBlend_2) == null)
				{
					result = (this._AnimGraphNode_AdditiveBoneBlend_2 = new FAnimNode_AdditiveBoneBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_AdditiveBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007243 RID: 29251
		// (get) Token: 0x0602B802 RID: 178178 RVA: 0x00A7EAFC File Offset: 0x00A7CCFC
		// (set) Token: 0x0602B803 RID: 178179 RVA: 0x00A7EB35 File Offset: 0x00A7CD35
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_14) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_14 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007244 RID: 29252
		// (get) Token: 0x0602B804 RID: 178180 RVA: 0x00A7EB58 File Offset: 0x00A7CD58
		// (set) Token: 0x0602B805 RID: 178181 RVA: 0x00A7EB91 File Offset: 0x00A7CD91
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_13) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_13 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007245 RID: 29253
		// (get) Token: 0x0602B806 RID: 178182 RVA: 0x00A7EBB4 File Offset: 0x00A7CDB4
		// (set) Token: 0x0602B807 RID: 178183 RVA: 0x00A7EBED File Offset: 0x00A7CDED
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_12) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_12 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007246 RID: 29254
		// (get) Token: 0x0602B808 RID: 178184 RVA: 0x00A7EC10 File Offset: 0x00A7CE10
		// (set) Token: 0x0602B809 RID: 178185 RVA: 0x00A7EC49 File Offset: 0x00A7CE49
		public FAnimNode_StateResult AnimGraphNode_StateResult_74
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_74) == null)
				{
					result = (this._AnimGraphNode_StateResult_74 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007247 RID: 29255
		// (get) Token: 0x0602B80A RID: 178186 RVA: 0x00A7EC6C File Offset: 0x00A7CE6C
		// (set) Token: 0x0602B80B RID: 178187 RVA: 0x00A7ECA5 File Offset: 0x00A7CEA5
		public FAnimNode_AdditiveBoneBlend AnimGraphNode_AdditiveBoneBlend_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_AdditiveBoneBlend result;
				if ((result = this._AnimGraphNode_AdditiveBoneBlend_1) == null)
				{
					result = (this._AnimGraphNode_AdditiveBoneBlend_1 = new FAnimNode_AdditiveBoneBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_AdditiveBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007248 RID: 29256
		// (get) Token: 0x0602B80C RID: 178188 RVA: 0x00A7ECC8 File Offset: 0x00A7CEC8
		// (set) Token: 0x0602B80D RID: 178189 RVA: 0x00A7ED01 File Offset: 0x00A7CF01
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_11) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_11 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007249 RID: 29257
		// (get) Token: 0x0602B80E RID: 178190 RVA: 0x00A7ED24 File Offset: 0x00A7CF24
		// (set) Token: 0x0602B80F RID: 178191 RVA: 0x00A7ED5D File Offset: 0x00A7CF5D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_10) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_10 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700724A RID: 29258
		// (get) Token: 0x0602B810 RID: 178192 RVA: 0x00A7ED80 File Offset: 0x00A7CF80
		// (set) Token: 0x0602B811 RID: 178193 RVA: 0x00A7EDB9 File Offset: 0x00A7CFB9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_9) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_9 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700724B RID: 29259
		// (get) Token: 0x0602B812 RID: 178194 RVA: 0x00A7EDDC File Offset: 0x00A7CFDC
		// (set) Token: 0x0602B813 RID: 178195 RVA: 0x00A7EE15 File Offset: 0x00A7D015
		public FAnimNode_StateResult AnimGraphNode_StateResult_73
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_73) == null)
				{
					result = (this._AnimGraphNode_StateResult_73 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700724C RID: 29260
		// (get) Token: 0x0602B814 RID: 178196 RVA: 0x00A7EE38 File Offset: 0x00A7D038
		// (set) Token: 0x0602B815 RID: 178197 RVA: 0x00A7EE71 File Offset: 0x00A7D071
		public FAnimNode_AdditiveBoneBlend AnimGraphNode_AdditiveBoneBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_AdditiveBoneBlend result;
				if ((result = this._AnimGraphNode_AdditiveBoneBlend) == null)
				{
					result = (this._AnimGraphNode_AdditiveBoneBlend = new FAnimNode_AdditiveBoneBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_AdditiveBoneBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700724D RID: 29261
		// (get) Token: 0x0602B816 RID: 178198 RVA: 0x00A7EE94 File Offset: 0x00A7D094
		// (set) Token: 0x0602B817 RID: 178199 RVA: 0x00A7EECD File Offset: 0x00A7D0CD
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_8) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_8 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700724E RID: 29262
		// (get) Token: 0x0602B818 RID: 178200 RVA: 0x00A7EEF0 File Offset: 0x00A7D0F0
		// (set) Token: 0x0602B819 RID: 178201 RVA: 0x00A7EF29 File Offset: 0x00A7D129
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_7) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_7 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700724F RID: 29263
		// (get) Token: 0x0602B81A RID: 178202 RVA: 0x00A7EF4C File Offset: 0x00A7D14C
		// (set) Token: 0x0602B81B RID: 178203 RVA: 0x00A7EF85 File Offset: 0x00A7D185
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_6) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_6 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007250 RID: 29264
		// (get) Token: 0x0602B81C RID: 178204 RVA: 0x00A7EFA8 File Offset: 0x00A7D1A8
		// (set) Token: 0x0602B81D RID: 178205 RVA: 0x00A7EFE1 File Offset: 0x00A7D1E1
		public FAnimNode_StateResult AnimGraphNode_StateResult_72
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_72) == null)
				{
					result = (this._AnimGraphNode_StateResult_72 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007251 RID: 29265
		// (get) Token: 0x0602B81E RID: 178206 RVA: 0x00A7F004 File Offset: 0x00A7D204
		// (set) Token: 0x0602B81F RID: 178207 RVA: 0x00A7F03D File Offset: 0x00A7D23D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_110
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_110) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_110 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007252 RID: 29266
		// (get) Token: 0x0602B820 RID: 178208 RVA: 0x00A7F060 File Offset: 0x00A7D260
		// (set) Token: 0x0602B821 RID: 178209 RVA: 0x00A7F099 File Offset: 0x00A7D299
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_5) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_5 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007253 RID: 29267
		// (get) Token: 0x0602B822 RID: 178210 RVA: 0x00A7F0BC File Offset: 0x00A7D2BC
		// (set) Token: 0x0602B823 RID: 178211 RVA: 0x00A7F0F5 File Offset: 0x00A7D2F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_71
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_71) == null)
				{
					result = (this._AnimGraphNode_StateResult_71 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007254 RID: 29268
		// (get) Token: 0x0602B824 RID: 178212 RVA: 0x00A7F118 File Offset: 0x00A7D318
		// (set) Token: 0x0602B825 RID: 178213 RVA: 0x00A7F151 File Offset: 0x00A7D351
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_19) == null)
				{
					result = (this._AnimGraphNode_StateMachine_19 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007255 RID: 29269
		// (get) Token: 0x0602B826 RID: 178214 RVA: 0x00A7F174 File Offset: 0x00A7D374
		// (set) Token: 0x0602B827 RID: 178215 RVA: 0x00A7F1AD File Offset: 0x00A7D3AD
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007256 RID: 29270
		// (get) Token: 0x0602B828 RID: 178216 RVA: 0x00A7F1D0 File Offset: 0x00A7D3D0
		// (set) Token: 0x0602B829 RID: 178217 RVA: 0x00A7F209 File Offset: 0x00A7D409
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_109
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_109) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_109 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007257 RID: 29271
		// (get) Token: 0x0602B82A RID: 178218 RVA: 0x00A7F22C File Offset: 0x00A7D42C
		// (set) Token: 0x0602B82B RID: 178219 RVA: 0x00A7F265 File Offset: 0x00A7D465
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_108
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_108) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_108 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007258 RID: 29272
		// (get) Token: 0x0602B82C RID: 178220 RVA: 0x00A7F288 File Offset: 0x00A7D488
		// (set) Token: 0x0602B82D RID: 178221 RVA: 0x00A7F2C1 File Offset: 0x00A7D4C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_107
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_107) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_107 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007259 RID: 29273
		// (get) Token: 0x0602B82E RID: 178222 RVA: 0x00A7F2E4 File Offset: 0x00A7D4E4
		// (set) Token: 0x0602B82F RID: 178223 RVA: 0x00A7F31D File Offset: 0x00A7D51D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_106
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_106) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_106 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700725A RID: 29274
		// (get) Token: 0x0602B830 RID: 178224 RVA: 0x00A7F340 File Offset: 0x00A7D540
		// (set) Token: 0x0602B831 RID: 178225 RVA: 0x00A7F379 File Offset: 0x00A7D579
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_105
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_105) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_105 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700725B RID: 29275
		// (get) Token: 0x0602B832 RID: 178226 RVA: 0x00A7F39C File Offset: 0x00A7D59C
		// (set) Token: 0x0602B833 RID: 178227 RVA: 0x00A7F3D5 File Offset: 0x00A7D5D5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_52) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_52 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700725C RID: 29276
		// (get) Token: 0x0602B834 RID: 178228 RVA: 0x00A7F3F8 File Offset: 0x00A7D5F8
		// (set) Token: 0x0602B835 RID: 178229 RVA: 0x00A7F431 File Offset: 0x00A7D631
		public FAnimNode_StateResult AnimGraphNode_StateResult_70
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_70) == null)
				{
					result = (this._AnimGraphNode_StateResult_70 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700725D RID: 29277
		// (get) Token: 0x0602B836 RID: 178230 RVA: 0x00A7F454 File Offset: 0x00A7D654
		// (set) Token: 0x0602B837 RID: 178231 RVA: 0x00A7F48D File Offset: 0x00A7D68D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_104
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_104) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_104 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700725E RID: 29278
		// (get) Token: 0x0602B838 RID: 178232 RVA: 0x00A7F4B0 File Offset: 0x00A7D6B0
		// (set) Token: 0x0602B839 RID: 178233 RVA: 0x00A7F4E9 File Offset: 0x00A7D6E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_103
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_103) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_103 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700725F RID: 29279
		// (get) Token: 0x0602B83A RID: 178234 RVA: 0x00A7F50C File Offset: 0x00A7D70C
		// (set) Token: 0x0602B83B RID: 178235 RVA: 0x00A7F545 File Offset: 0x00A7D745
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_102
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_102) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_102 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007260 RID: 29280
		// (get) Token: 0x0602B83C RID: 178236 RVA: 0x00A7F568 File Offset: 0x00A7D768
		// (set) Token: 0x0602B83D RID: 178237 RVA: 0x00A7F5A1 File Offset: 0x00A7D7A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_101
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_101) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_101 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007261 RID: 29281
		// (get) Token: 0x0602B83E RID: 178238 RVA: 0x00A7F5C4 File Offset: 0x00A7D7C4
		// (set) Token: 0x0602B83F RID: 178239 RVA: 0x00A7F5FD File Offset: 0x00A7D7FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_100
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_100) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_100 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007262 RID: 29282
		// (get) Token: 0x0602B840 RID: 178240 RVA: 0x00A7F620 File Offset: 0x00A7D820
		// (set) Token: 0x0602B841 RID: 178241 RVA: 0x00A7F659 File Offset: 0x00A7D859
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_99
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_99) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_99 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007263 RID: 29283
		// (get) Token: 0x0602B842 RID: 178242 RVA: 0x00A7F67C File Offset: 0x00A7D87C
		// (set) Token: 0x0602B843 RID: 178243 RVA: 0x00A7F6B5 File Offset: 0x00A7D8B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_98
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_98) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_98 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007264 RID: 29284
		// (get) Token: 0x0602B844 RID: 178244 RVA: 0x00A7F6D8 File Offset: 0x00A7D8D8
		// (set) Token: 0x0602B845 RID: 178245 RVA: 0x00A7F711 File Offset: 0x00A7D911
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_97
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_97) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_97 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007265 RID: 29285
		// (get) Token: 0x0602B846 RID: 178246 RVA: 0x00A7F734 File Offset: 0x00A7D934
		// (set) Token: 0x0602B847 RID: 178247 RVA: 0x00A7F76D File Offset: 0x00A7D96D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_3) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_3 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007266 RID: 29286
		// (get) Token: 0x0602B848 RID: 178248 RVA: 0x00A7F790 File Offset: 0x00A7D990
		// (set) Token: 0x0602B849 RID: 178249 RVA: 0x00A7F7C9 File Offset: 0x00A7D9C9
		public FAnimNode_StateResult AnimGraphNode_StateResult_69
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_69) == null)
				{
					result = (this._AnimGraphNode_StateResult_69 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007267 RID: 29287
		// (get) Token: 0x0602B84A RID: 178250 RVA: 0x00A7F7EC File Offset: 0x00A7D9EC
		// (set) Token: 0x0602B84B RID: 178251 RVA: 0x00A7F825 File Offset: 0x00A7DA25
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_51) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_51 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007268 RID: 29288
		// (get) Token: 0x0602B84C RID: 178252 RVA: 0x00A7F848 File Offset: 0x00A7DA48
		// (set) Token: 0x0602B84D RID: 178253 RVA: 0x00A7F881 File Offset: 0x00A7DA81
		public FAnimNode_StateResult AnimGraphNode_StateResult_68
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_68) == null)
				{
					result = (this._AnimGraphNode_StateResult_68 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007269 RID: 29289
		// (get) Token: 0x0602B84E RID: 178254 RVA: 0x00A7F8A4 File Offset: 0x00A7DAA4
		// (set) Token: 0x0602B84F RID: 178255 RVA: 0x00A7F8DD File Offset: 0x00A7DADD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_18) == null)
				{
					result = (this._AnimGraphNode_StateMachine_18 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700726A RID: 29290
		// (get) Token: 0x0602B850 RID: 178256 RVA: 0x00A7F900 File Offset: 0x00A7DB00
		// (set) Token: 0x0602B851 RID: 178257 RVA: 0x00A7F939 File Offset: 0x00A7DB39
		public FAnimNode_StateResult AnimGraphNode_StateResult_67
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_67) == null)
				{
					result = (this._AnimGraphNode_StateResult_67 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700726B RID: 29291
		// (get) Token: 0x0602B852 RID: 178258 RVA: 0x00A7F95C File Offset: 0x00A7DB5C
		// (set) Token: 0x0602B853 RID: 178259 RVA: 0x00A7F995 File Offset: 0x00A7DB95
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_96
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_96) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_96 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700726C RID: 29292
		// (get) Token: 0x0602B854 RID: 178260 RVA: 0x00A7F9B8 File Offset: 0x00A7DBB8
		// (set) Token: 0x0602B855 RID: 178261 RVA: 0x00A7F9F1 File Offset: 0x00A7DBF1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_95
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_95) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_95 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700726D RID: 29293
		// (get) Token: 0x0602B856 RID: 178262 RVA: 0x00A7FA14 File Offset: 0x00A7DC14
		// (set) Token: 0x0602B857 RID: 178263 RVA: 0x00A7FA4D File Offset: 0x00A7DC4D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_2) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_2 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700726E RID: 29294
		// (get) Token: 0x0602B858 RID: 178264 RVA: 0x00A7FA70 File Offset: 0x00A7DC70
		// (set) Token: 0x0602B859 RID: 178265 RVA: 0x00A7FAA9 File Offset: 0x00A7DCA9
		public FAnimNode_StateResult AnimGraphNode_StateResult_66
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_66) == null)
				{
					result = (this._AnimGraphNode_StateResult_66 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700726F RID: 29295
		// (get) Token: 0x0602B85A RID: 178266 RVA: 0x00A7FACC File Offset: 0x00A7DCCC
		// (set) Token: 0x0602B85B RID: 178267 RVA: 0x00A7FB05 File Offset: 0x00A7DD05
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_50) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_50 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007270 RID: 29296
		// (get) Token: 0x0602B85C RID: 178268 RVA: 0x00A7FB28 File Offset: 0x00A7DD28
		// (set) Token: 0x0602B85D RID: 178269 RVA: 0x00A7FB61 File Offset: 0x00A7DD61
		public FAnimNode_StateResult AnimGraphNode_StateResult_65
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_65) == null)
				{
					result = (this._AnimGraphNode_StateResult_65 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007271 RID: 29297
		// (get) Token: 0x0602B85E RID: 178270 RVA: 0x00A7FB84 File Offset: 0x00A7DD84
		// (set) Token: 0x0602B85F RID: 178271 RVA: 0x00A7FBBD File Offset: 0x00A7DDBD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_17) == null)
				{
					result = (this._AnimGraphNode_StateMachine_17 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007272 RID: 29298
		// (get) Token: 0x0602B860 RID: 178272 RVA: 0x00A7FBE0 File Offset: 0x00A7DDE0
		// (set) Token: 0x0602B861 RID: 178273 RVA: 0x00A7FC19 File Offset: 0x00A7DE19
		public FAnimNode_StateResult AnimGraphNode_StateResult_64
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_64) == null)
				{
					result = (this._AnimGraphNode_StateResult_64 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007273 RID: 29299
		// (get) Token: 0x0602B862 RID: 178274 RVA: 0x00A7FC3C File Offset: 0x00A7DE3C
		// (set) Token: 0x0602B863 RID: 178275 RVA: 0x00A7FC75 File Offset: 0x00A7DE75
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_49) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_49 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007274 RID: 29300
		// (get) Token: 0x0602B864 RID: 178276 RVA: 0x00A7FC98 File Offset: 0x00A7DE98
		// (set) Token: 0x0602B865 RID: 178277 RVA: 0x00A7FCD1 File Offset: 0x00A7DED1
		public FAnimNode_StateResult AnimGraphNode_StateResult_63
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_63) == null)
				{
					result = (this._AnimGraphNode_StateResult_63 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007275 RID: 29301
		// (get) Token: 0x0602B866 RID: 178278 RVA: 0x00A7FCF4 File Offset: 0x00A7DEF4
		// (set) Token: 0x0602B867 RID: 178279 RVA: 0x00A7FD2D File Offset: 0x00A7DF2D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_94
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_94) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_94 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007276 RID: 29302
		// (get) Token: 0x0602B868 RID: 178280 RVA: 0x00A7FD50 File Offset: 0x00A7DF50
		// (set) Token: 0x0602B869 RID: 178281 RVA: 0x00A7FD89 File Offset: 0x00A7DF89
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_16) == null)
				{
					result = (this._AnimGraphNode_StateMachine_16 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007277 RID: 29303
		// (get) Token: 0x0602B86A RID: 178282 RVA: 0x00A7FDAC File Offset: 0x00A7DFAC
		// (set) Token: 0x0602B86B RID: 178283 RVA: 0x00A7FDE5 File Offset: 0x00A7DFE5
		public FAnimNode_StateResult AnimGraphNode_StateResult_62
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_62) == null)
				{
					result = (this._AnimGraphNode_StateResult_62 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007278 RID: 29304
		// (get) Token: 0x0602B86C RID: 178284 RVA: 0x00A7FE08 File Offset: 0x00A7E008
		// (set) Token: 0x0602B86D RID: 178285 RVA: 0x00A7FE41 File Offset: 0x00A7E041
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_15) == null)
				{
					result = (this._AnimGraphNode_StateMachine_15 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007279 RID: 29305
		// (get) Token: 0x0602B86E RID: 178286 RVA: 0x00A7FE64 File Offset: 0x00A7E064
		// (set) Token: 0x0602B86F RID: 178287 RVA: 0x00A7FE9D File Offset: 0x00A7E09D
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700727A RID: 29306
		// (get) Token: 0x0602B870 RID: 178288 RVA: 0x00A7FEC0 File Offset: 0x00A7E0C0
		// (set) Token: 0x0602B871 RID: 178289 RVA: 0x00A7FEF9 File Offset: 0x00A7E0F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_48) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_48 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700727B RID: 29307
		// (get) Token: 0x0602B872 RID: 178290 RVA: 0x00A7FF1C File Offset: 0x00A7E11C
		// (set) Token: 0x0602B873 RID: 178291 RVA: 0x00A7FF55 File Offset: 0x00A7E155
		public FAnimNode_StateResult AnimGraphNode_StateResult_61
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_61) == null)
				{
					result = (this._AnimGraphNode_StateResult_61 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700727C RID: 29308
		// (get) Token: 0x0602B874 RID: 178292 RVA: 0x00A7FF78 File Offset: 0x00A7E178
		// (set) Token: 0x0602B875 RID: 178293 RVA: 0x00A7FFB1 File Offset: 0x00A7E1B1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_14) == null)
				{
					result = (this._AnimGraphNode_StateMachine_14 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700727D RID: 29309
		// (get) Token: 0x0602B876 RID: 178294 RVA: 0x00A7FFD4 File Offset: 0x00A7E1D4
		// (set) Token: 0x0602B877 RID: 178295 RVA: 0x00A8000D File Offset: 0x00A7E20D
		public FAnimNode_Slot AnimGraphNode_Slot_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_5) == null)
				{
					result = (this._AnimGraphNode_Slot_5 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700727E RID: 29310
		// (get) Token: 0x0602B878 RID: 178296 RVA: 0x00A80030 File Offset: 0x00A7E230
		// (set) Token: 0x0602B879 RID: 178297 RVA: 0x00A80069 File Offset: 0x00A7E269
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700727F RID: 29311
		// (get) Token: 0x0602B87A RID: 178298 RVA: 0x00A8008C File Offset: 0x00A7E28C
		// (set) Token: 0x0602B87B RID: 178299 RVA: 0x00A800C5 File Offset: 0x00A7E2C5
		public FAnimNode_Slot AnimGraphNode_Slot_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_4) == null)
				{
					result = (this._AnimGraphNode_Slot_4 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007280 RID: 29312
		// (get) Token: 0x0602B87C RID: 178300 RVA: 0x00A800E8 File Offset: 0x00A7E2E8
		// (set) Token: 0x0602B87D RID: 178301 RVA: 0x00A80121 File Offset: 0x00A7E321
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace_2) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace_2 = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007281 RID: 29313
		// (get) Token: 0x0602B87E RID: 178302 RVA: 0x00A80144 File Offset: 0x00A7E344
		// (set) Token: 0x0602B87F RID: 178303 RVA: 0x00A8017D File Offset: 0x00A7E37D
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace_2) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace_2 = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007282 RID: 29314
		// (get) Token: 0x0602B880 RID: 178304 RVA: 0x00A801A0 File Offset: 0x00A7E3A0
		// (set) Token: 0x0602B881 RID: 178305 RVA: 0x00A801D9 File Offset: 0x00A7E3D9
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007283 RID: 29315
		// (get) Token: 0x0602B882 RID: 178306 RVA: 0x00A801FC File Offset: 0x00A7E3FC
		// (set) Token: 0x0602B883 RID: 178307 RVA: 0x00A80235 File Offset: 0x00A7E435
		public FAnimNode_KuroHumanIK AnimGraphNode_KuroHumanIK
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_KuroHumanIK result;
				if ((result = this._AnimGraphNode_KuroHumanIK) == null)
				{
					result = (this._AnimGraphNode_KuroHumanIK = new FAnimNode_KuroHumanIK(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_KuroHumanIK.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007284 RID: 29316
		// (get) Token: 0x0602B884 RID: 178308 RVA: 0x00A80258 File Offset: 0x00A7E458
		// (set) Token: 0x0602B885 RID: 178309 RVA: 0x00A80291 File Offset: 0x00A7E491
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves_2) == null)
				{
					result = (this._AnimGraphNode_CombineCurves_2 = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007285 RID: 29317
		// (get) Token: 0x0602B886 RID: 178310 RVA: 0x00A802B4 File Offset: 0x00A7E4B4
		// (set) Token: 0x0602B887 RID: 178311 RVA: 0x00A802ED File Offset: 0x00A7E4ED
		public FAnimNode_RotationOffsetBlendSpace AnimGraphNode_RotationOffsetBlendSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RotationOffsetBlendSpace result;
				if ((result = this._AnimGraphNode_RotationOffsetBlendSpace) == null)
				{
					result = (this._AnimGraphNode_RotationOffsetBlendSpace = new FAnimNode_RotationOffsetBlendSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RotationOffsetBlendSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007286 RID: 29318
		// (get) Token: 0x0602B888 RID: 178312 RVA: 0x00A80310 File Offset: 0x00A7E510
		// (set) Token: 0x0602B889 RID: 178313 RVA: 0x00A80349 File Offset: 0x00A7E549
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_47) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_47 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007287 RID: 29319
		// (get) Token: 0x0602B88A RID: 178314 RVA: 0x00A8036C File Offset: 0x00A7E56C
		// (set) Token: 0x0602B88B RID: 178315 RVA: 0x00A803A5 File Offset: 0x00A7E5A5
		public FAnimNode_Slot AnimGraphNode_Slot_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_3) == null)
				{
					result = (this._AnimGraphNode_Slot_3 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007288 RID: 29320
		// (get) Token: 0x0602B88C RID: 178316 RVA: 0x00A803C8 File Offset: 0x00A7E5C8
		// (set) Token: 0x0602B88D RID: 178317 RVA: 0x00A80401 File Offset: 0x00A7E601
		public FAnimNode_Slot AnimGraphNode_Slot_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_2) == null)
				{
					result = (this._AnimGraphNode_Slot_2 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007289 RID: 29321
		// (get) Token: 0x0602B88E RID: 178318 RVA: 0x00A80424 File Offset: 0x00A7E624
		// (set) Token: 0x0602B88F RID: 178319 RVA: 0x00A8045D File Offset: 0x00A7E65D
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves_1) == null)
				{
					result = (this._AnimGraphNode_CombineCurves_1 = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700728A RID: 29322
		// (get) Token: 0x0602B890 RID: 178320 RVA: 0x00A80480 File Offset: 0x00A7E680
		// (set) Token: 0x0602B891 RID: 178321 RVA: 0x00A804B9 File Offset: 0x00A7E6B9
		public FAnimNode_Slot AnimGraphNode_Slot_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot_1) == null)
				{
					result = (this._AnimGraphNode_Slot_1 = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700728B RID: 29323
		// (get) Token: 0x0602B892 RID: 178322 RVA: 0x00A804DC File Offset: 0x00A7E6DC
		// (set) Token: 0x0602B893 RID: 178323 RVA: 0x00A80515 File Offset: 0x00A7E715
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace_1) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace_1 = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700728C RID: 29324
		// (get) Token: 0x0602B894 RID: 178324 RVA: 0x00A80538 File Offset: 0x00A7E738
		// (set) Token: 0x0602B895 RID: 178325 RVA: 0x00A80571 File Offset: 0x00A7E771
		public FAnimNode_RBF AnimGraphNode_RBF
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_RBF result;
				if ((result = this._AnimGraphNode_RBF) == null)
				{
					result = (this._AnimGraphNode_RBF = new FAnimNode_RBF(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_RBF.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700728D RID: 29325
		// (get) Token: 0x0602B896 RID: 178326 RVA: 0x00A80594 File Offset: 0x00A7E794
		// (set) Token: 0x0602B897 RID: 178327 RVA: 0x00A805CD File Offset: 0x00A7E7CD
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace_1) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace_1 = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700728E RID: 29326
		// (get) Token: 0x0602B898 RID: 178328 RVA: 0x00A805F0 File Offset: 0x00A7E7F0
		// (set) Token: 0x0602B899 RID: 178329 RVA: 0x00A80629 File Offset: 0x00A7E829
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool_2) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool_2 = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700728F RID: 29327
		// (get) Token: 0x0602B89A RID: 178330 RVA: 0x00A8064C File Offset: 0x00A7E84C
		// (set) Token: 0x0602B89B RID: 178331 RVA: 0x00A80685 File Offset: 0x00A7E885
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_3) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_3 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007290 RID: 29328
		// (get) Token: 0x0602B89C RID: 178332 RVA: 0x00A806A8 File Offset: 0x00A7E8A8
		// (set) Token: 0x0602B89D RID: 178333 RVA: 0x00A806E1 File Offset: 0x00A7E8E1
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_115, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_115, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007291 RID: 29329
		// (get) Token: 0x0602B89E RID: 178334 RVA: 0x00A80704 File Offset: 0x00A7E904
		// (set) Token: 0x0602B89F RID: 178335 RVA: 0x00A8073D File Offset: 0x00A7E93D
		public FAnimNode_TwoWayBlend AnimGraphNode_TwoWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TwoWayBlend result;
				if ((result = this._AnimGraphNode_TwoWayBlend) == null)
				{
					result = (this._AnimGraphNode_TwoWayBlend = new FAnimNode_TwoWayBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_116, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TwoWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_116, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007292 RID: 29330
		// (get) Token: 0x0602B8A0 RID: 178336 RVA: 0x00A80760 File Offset: 0x00A7E960
		// (set) Token: 0x0602B8A1 RID: 178337 RVA: 0x00A80799 File Offset: 0x00A7E999
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_46) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_46 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_117, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_117, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007293 RID: 29331
		// (get) Token: 0x0602B8A2 RID: 178338 RVA: 0x00A807BC File Offset: 0x00A7E9BC
		// (set) Token: 0x0602B8A3 RID: 178339 RVA: 0x00A807F5 File Offset: 0x00A7E9F5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_45) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_45 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_118, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007294 RID: 29332
		// (get) Token: 0x0602B8A4 RID: 178340 RVA: 0x00A80818 File Offset: 0x00A7EA18
		// (set) Token: 0x0602B8A5 RID: 178341 RVA: 0x00A80851 File Offset: 0x00A7EA51
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_119, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_119, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007295 RID: 29333
		// (get) Token: 0x0602B8A6 RID: 178342 RVA: 0x00A80874 File Offset: 0x00A7EA74
		// (set) Token: 0x0602B8A7 RID: 178343 RVA: 0x00A808AD File Offset: 0x00A7EAAD
		public FAnimNode_StateResult AnimGraphNode_StateResult_60
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_60) == null)
				{
					result = (this._AnimGraphNode_StateResult_60 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_120, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_120, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007296 RID: 29334
		// (get) Token: 0x0602B8A8 RID: 178344 RVA: 0x00A808D0 File Offset: 0x00A7EAD0
		// (set) Token: 0x0602B8A9 RID: 178345 RVA: 0x00A80909 File Offset: 0x00A7EB09
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_13) == null)
				{
					result = (this._AnimGraphNode_StateMachine_13 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_121, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_121, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007297 RID: 29335
		// (get) Token: 0x0602B8AA RID: 178346 RVA: 0x00A8092C File Offset: 0x00A7EB2C
		// (set) Token: 0x0602B8AB RID: 178347 RVA: 0x00A80965 File Offset: 0x00A7EB65
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_93
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_93) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_93 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_122, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_122, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007298 RID: 29336
		// (get) Token: 0x0602B8AC RID: 178348 RVA: 0x00A80988 File Offset: 0x00A7EB88
		// (set) Token: 0x0602B8AD RID: 178349 RVA: 0x00A809C1 File Offset: 0x00A7EBC1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_92
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_92) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_92 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_123, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_123, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007299 RID: 29337
		// (get) Token: 0x0602B8AE RID: 178350 RVA: 0x00A809E4 File Offset: 0x00A7EBE4
		// (set) Token: 0x0602B8AF RID: 178351 RVA: 0x00A80A1D File Offset: 0x00A7EC1D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_91
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_91) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_91 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_124, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_124, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700729A RID: 29338
		// (get) Token: 0x0602B8B0 RID: 178352 RVA: 0x00A80A40 File Offset: 0x00A7EC40
		// (set) Token: 0x0602B8B1 RID: 178353 RVA: 0x00A80A79 File Offset: 0x00A7EC79
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_90
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_90) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_90 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_125, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_125, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700729B RID: 29339
		// (get) Token: 0x0602B8B2 RID: 178354 RVA: 0x00A80A9C File Offset: 0x00A7EC9C
		// (set) Token: 0x0602B8B3 RID: 178355 RVA: 0x00A80AD5 File Offset: 0x00A7ECD5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_89
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_89) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_89 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_126, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_126, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700729C RID: 29340
		// (get) Token: 0x0602B8B4 RID: 178356 RVA: 0x00A80AF8 File Offset: 0x00A7ECF8
		// (set) Token: 0x0602B8B5 RID: 178357 RVA: 0x00A80B31 File Offset: 0x00A7ED31
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_88
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_88) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_88 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_127, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_127, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700729D RID: 29341
		// (get) Token: 0x0602B8B6 RID: 178358 RVA: 0x00A80B54 File Offset: 0x00A7ED54
		// (set) Token: 0x0602B8B7 RID: 178359 RVA: 0x00A80B8D File Offset: 0x00A7ED8D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_87
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_87) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_87 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_128, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700729E RID: 29342
		// (get) Token: 0x0602B8B8 RID: 178360 RVA: 0x00A80BB0 File Offset: 0x00A7EDB0
		// (set) Token: 0x0602B8B9 RID: 178361 RVA: 0x00A80BE9 File Offset: 0x00A7EDE9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_86
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_86) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_86 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_129, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_129, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700729F RID: 29343
		// (get) Token: 0x0602B8BA RID: 178362 RVA: 0x00A80C0C File Offset: 0x00A7EE0C
		// (set) Token: 0x0602B8BB RID: 178363 RVA: 0x00A80C45 File Offset: 0x00A7EE45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_85
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_85) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_85 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_130, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_130, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A0 RID: 29344
		// (get) Token: 0x0602B8BC RID: 178364 RVA: 0x00A80C68 File Offset: 0x00A7EE68
		// (set) Token: 0x0602B8BD RID: 178365 RVA: 0x00A80CA1 File Offset: 0x00A7EEA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_84
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_84) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_84 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_131, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_131, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A1 RID: 29345
		// (get) Token: 0x0602B8BE RID: 178366 RVA: 0x00A80CC4 File Offset: 0x00A7EEC4
		// (set) Token: 0x0602B8BF RID: 178367 RVA: 0x00A80CFD File Offset: 0x00A7EEFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_83
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_83) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_83 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_132, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_132, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A2 RID: 29346
		// (get) Token: 0x0602B8C0 RID: 178368 RVA: 0x00A80D20 File Offset: 0x00A7EF20
		// (set) Token: 0x0602B8C1 RID: 178369 RVA: 0x00A80D59 File Offset: 0x00A7EF59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_82
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_82) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_82 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_133, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_133, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A3 RID: 29347
		// (get) Token: 0x0602B8C2 RID: 178370 RVA: 0x00A80D7C File Offset: 0x00A7EF7C
		// (set) Token: 0x0602B8C3 RID: 178371 RVA: 0x00A80DB5 File Offset: 0x00A7EFB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_81
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_81) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_81 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_134, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_134, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A4 RID: 29348
		// (get) Token: 0x0602B8C4 RID: 178372 RVA: 0x00A80DD8 File Offset: 0x00A7EFD8
		// (set) Token: 0x0602B8C5 RID: 178373 RVA: 0x00A80E11 File Offset: 0x00A7F011
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_80
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_80) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_80 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_135, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_135, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A5 RID: 29349
		// (get) Token: 0x0602B8C6 RID: 178374 RVA: 0x00A80E34 File Offset: 0x00A7F034
		// (set) Token: 0x0602B8C7 RID: 178375 RVA: 0x00A80E6D File Offset: 0x00A7F06D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_79
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_79) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_79 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_136, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_136, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A6 RID: 29350
		// (get) Token: 0x0602B8C8 RID: 178376 RVA: 0x00A80E90 File Offset: 0x00A7F090
		// (set) Token: 0x0602B8C9 RID: 178377 RVA: 0x00A80EC9 File Offset: 0x00A7F0C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_78
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_78) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_78 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_137, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_137, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A7 RID: 29351
		// (get) Token: 0x0602B8CA RID: 178378 RVA: 0x00A80EEC File Offset: 0x00A7F0EC
		// (set) Token: 0x0602B8CB RID: 178379 RVA: 0x00A80F25 File Offset: 0x00A7F125
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_77
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_77) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_77 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_138, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_138, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A8 RID: 29352
		// (get) Token: 0x0602B8CC RID: 178380 RVA: 0x00A80F48 File Offset: 0x00A7F148
		// (set) Token: 0x0602B8CD RID: 178381 RVA: 0x00A80F81 File Offset: 0x00A7F181
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_76
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_76) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_76 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_139, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_139, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072A9 RID: 29353
		// (get) Token: 0x0602B8CE RID: 178382 RVA: 0x00A80FA4 File Offset: 0x00A7F1A4
		// (set) Token: 0x0602B8CF RID: 178383 RVA: 0x00A80FDD File Offset: 0x00A7F1DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_75
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_75) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_75 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_140, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_140, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072AA RID: 29354
		// (get) Token: 0x0602B8D0 RID: 178384 RVA: 0x00A81000 File Offset: 0x00A7F200
		// (set) Token: 0x0602B8D1 RID: 178385 RVA: 0x00A81039 File Offset: 0x00A7F239
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_74
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_74) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_74 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_141, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_141, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072AB RID: 29355
		// (get) Token: 0x0602B8D2 RID: 178386 RVA: 0x00A8105C File Offset: 0x00A7F25C
		// (set) Token: 0x0602B8D3 RID: 178387 RVA: 0x00A81095 File Offset: 0x00A7F295
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_73
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_73) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_73 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_142, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_142, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072AC RID: 29356
		// (get) Token: 0x0602B8D4 RID: 178388 RVA: 0x00A810B8 File Offset: 0x00A7F2B8
		// (set) Token: 0x0602B8D5 RID: 178389 RVA: 0x00A810F1 File Offset: 0x00A7F2F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_72
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_72) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_72 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_143, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_143, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072AD RID: 29357
		// (get) Token: 0x0602B8D6 RID: 178390 RVA: 0x00A81114 File Offset: 0x00A7F314
		// (set) Token: 0x0602B8D7 RID: 178391 RVA: 0x00A8114D File Offset: 0x00A7F34D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_71
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_71) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_71 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_144, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_144, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072AE RID: 29358
		// (get) Token: 0x0602B8D8 RID: 178392 RVA: 0x00A81170 File Offset: 0x00A7F370
		// (set) Token: 0x0602B8D9 RID: 178393 RVA: 0x00A811A9 File Offset: 0x00A7F3A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_70
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_70) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_70 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_145, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_145, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072AF RID: 29359
		// (get) Token: 0x0602B8DA RID: 178394 RVA: 0x00A811CC File Offset: 0x00A7F3CC
		// (set) Token: 0x0602B8DB RID: 178395 RVA: 0x00A81205 File Offset: 0x00A7F405
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_69
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_69) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_69 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_146, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_146, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B0 RID: 29360
		// (get) Token: 0x0602B8DC RID: 178396 RVA: 0x00A81228 File Offset: 0x00A7F428
		// (set) Token: 0x0602B8DD RID: 178397 RVA: 0x00A81261 File Offset: 0x00A7F461
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_68
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_68) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_68 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_147, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_147, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B1 RID: 29361
		// (get) Token: 0x0602B8DE RID: 178398 RVA: 0x00A81284 File Offset: 0x00A7F484
		// (set) Token: 0x0602B8DF RID: 178399 RVA: 0x00A812BD File Offset: 0x00A7F4BD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_67
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_67) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_67 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_148, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_148, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B2 RID: 29362
		// (get) Token: 0x0602B8E0 RID: 178400 RVA: 0x00A812E0 File Offset: 0x00A7F4E0
		// (set) Token: 0x0602B8E1 RID: 178401 RVA: 0x00A81319 File Offset: 0x00A7F519
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_66
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_66) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_66 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_149, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_149, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B3 RID: 29363
		// (get) Token: 0x0602B8E2 RID: 178402 RVA: 0x00A8133C File Offset: 0x00A7F53C
		// (set) Token: 0x0602B8E3 RID: 178403 RVA: 0x00A81375 File Offset: 0x00A7F575
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_65
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_65) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_65 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_150, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_150, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B4 RID: 29364
		// (get) Token: 0x0602B8E4 RID: 178404 RVA: 0x00A81398 File Offset: 0x00A7F598
		// (set) Token: 0x0602B8E5 RID: 178405 RVA: 0x00A813D1 File Offset: 0x00A7F5D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_64
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_64) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_64 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_151, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_151, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B5 RID: 29365
		// (get) Token: 0x0602B8E6 RID: 178406 RVA: 0x00A813F4 File Offset: 0x00A7F5F4
		// (set) Token: 0x0602B8E7 RID: 178407 RVA: 0x00A8142D File Offset: 0x00A7F62D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_63
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_63) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_63 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_152, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_152, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B6 RID: 29366
		// (get) Token: 0x0602B8E8 RID: 178408 RVA: 0x00A81450 File Offset: 0x00A7F650
		// (set) Token: 0x0602B8E9 RID: 178409 RVA: 0x00A81489 File Offset: 0x00A7F689
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_62
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_62) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_62 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_153, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_153, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B7 RID: 29367
		// (get) Token: 0x0602B8EA RID: 178410 RVA: 0x00A814AC File Offset: 0x00A7F6AC
		// (set) Token: 0x0602B8EB RID: 178411 RVA: 0x00A814E5 File Offset: 0x00A7F6E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_61
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_61) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_61 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_154, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_154, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B8 RID: 29368
		// (get) Token: 0x0602B8EC RID: 178412 RVA: 0x00A81508 File Offset: 0x00A7F708
		// (set) Token: 0x0602B8ED RID: 178413 RVA: 0x00A81541 File Offset: 0x00A7F741
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_44) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_44 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_155, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_155, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072B9 RID: 29369
		// (get) Token: 0x0602B8EE RID: 178414 RVA: 0x00A81564 File Offset: 0x00A7F764
		// (set) Token: 0x0602B8EF RID: 178415 RVA: 0x00A8159D File Offset: 0x00A7F79D
		public FAnimNode_StateResult AnimGraphNode_StateResult_59
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_59) == null)
				{
					result = (this._AnimGraphNode_StateResult_59 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_156, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_156, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072BA RID: 29370
		// (get) Token: 0x0602B8F0 RID: 178416 RVA: 0x00A815C0 File Offset: 0x00A7F7C0
		// (set) Token: 0x0602B8F1 RID: 178417 RVA: 0x00A815F9 File Offset: 0x00A7F7F9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_43) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_43 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_157, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_157, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072BB RID: 29371
		// (get) Token: 0x0602B8F2 RID: 178418 RVA: 0x00A8161C File Offset: 0x00A7F81C
		// (set) Token: 0x0602B8F3 RID: 178419 RVA: 0x00A81655 File Offset: 0x00A7F855
		public FAnimNode_StateResult AnimGraphNode_StateResult_58
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_58) == null)
				{
					result = (this._AnimGraphNode_StateResult_58 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_158, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_158, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072BC RID: 29372
		// (get) Token: 0x0602B8F4 RID: 178420 RVA: 0x00A81678 File Offset: 0x00A7F878
		// (set) Token: 0x0602B8F5 RID: 178421 RVA: 0x00A816B1 File Offset: 0x00A7F8B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_60
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_60) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_60 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_159, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_159, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072BD RID: 29373
		// (get) Token: 0x0602B8F6 RID: 178422 RVA: 0x00A816D4 File Offset: 0x00A7F8D4
		// (set) Token: 0x0602B8F7 RID: 178423 RVA: 0x00A8170D File Offset: 0x00A7F90D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_42) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_42 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_160, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_160, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072BE RID: 29374
		// (get) Token: 0x0602B8F8 RID: 178424 RVA: 0x00A81730 File Offset: 0x00A7F930
		// (set) Token: 0x0602B8F9 RID: 178425 RVA: 0x00A81769 File Offset: 0x00A7F969
		public FAnimNode_StateResult AnimGraphNode_StateResult_57
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_57) == null)
				{
					result = (this._AnimGraphNode_StateResult_57 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_161, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_161, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072BF RID: 29375
		// (get) Token: 0x0602B8FA RID: 178426 RVA: 0x00A8178C File Offset: 0x00A7F98C
		// (set) Token: 0x0602B8FB RID: 178427 RVA: 0x00A817C5 File Offset: 0x00A7F9C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_59
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_59) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_59 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_162, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_162, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C0 RID: 29376
		// (get) Token: 0x0602B8FC RID: 178428 RVA: 0x00A817E8 File Offset: 0x00A7F9E8
		// (set) Token: 0x0602B8FD RID: 178429 RVA: 0x00A81821 File Offset: 0x00A7FA21
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_58
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_58) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_58 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_163, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_163, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C1 RID: 29377
		// (get) Token: 0x0602B8FE RID: 178430 RVA: 0x00A81844 File Offset: 0x00A7FA44
		// (set) Token: 0x0602B8FF RID: 178431 RVA: 0x00A8187D File Offset: 0x00A7FA7D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_57
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_57) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_57 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_164, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_164, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C2 RID: 29378
		// (get) Token: 0x0602B900 RID: 178432 RVA: 0x00A818A0 File Offset: 0x00A7FAA0
		// (set) Token: 0x0602B901 RID: 178433 RVA: 0x00A818D9 File Offset: 0x00A7FAD9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_56
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_56) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_56 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_165, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_165, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C3 RID: 29379
		// (get) Token: 0x0602B902 RID: 178434 RVA: 0x00A818FC File Offset: 0x00A7FAFC
		// (set) Token: 0x0602B903 RID: 178435 RVA: 0x00A81935 File Offset: 0x00A7FB35
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_55
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_55) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_55 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_166, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_166, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C4 RID: 29380
		// (get) Token: 0x0602B904 RID: 178436 RVA: 0x00A81958 File Offset: 0x00A7FB58
		// (set) Token: 0x0602B905 RID: 178437 RVA: 0x00A81991 File Offset: 0x00A7FB91
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_54
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_54) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_54 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_167, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_167, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C5 RID: 29381
		// (get) Token: 0x0602B906 RID: 178438 RVA: 0x00A819B4 File Offset: 0x00A7FBB4
		// (set) Token: 0x0602B907 RID: 178439 RVA: 0x00A819ED File Offset: 0x00A7FBED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_53) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_53 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_168, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_168, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C6 RID: 29382
		// (get) Token: 0x0602B908 RID: 178440 RVA: 0x00A81A10 File Offset: 0x00A7FC10
		// (set) Token: 0x0602B909 RID: 178441 RVA: 0x00A81A49 File Offset: 0x00A7FC49
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_52) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_52 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_169, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_169, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C7 RID: 29383
		// (get) Token: 0x0602B90A RID: 178442 RVA: 0x00A81A6C File Offset: 0x00A7FC6C
		// (set) Token: 0x0602B90B RID: 178443 RVA: 0x00A81AA5 File Offset: 0x00A7FCA5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_51) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_51 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_170, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_170, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C8 RID: 29384
		// (get) Token: 0x0602B90C RID: 178444 RVA: 0x00A81AC8 File Offset: 0x00A7FCC8
		// (set) Token: 0x0602B90D RID: 178445 RVA: 0x00A81B01 File Offset: 0x00A7FD01
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_50) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_50 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_171, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_171, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072C9 RID: 29385
		// (get) Token: 0x0602B90E RID: 178446 RVA: 0x00A81B24 File Offset: 0x00A7FD24
		// (set) Token: 0x0602B90F RID: 178447 RVA: 0x00A81B5D File Offset: 0x00A7FD5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_49) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_49 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_172, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_172, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072CA RID: 29386
		// (get) Token: 0x0602B910 RID: 178448 RVA: 0x00A81B80 File Offset: 0x00A7FD80
		// (set) Token: 0x0602B911 RID: 178449 RVA: 0x00A81BB9 File Offset: 0x00A7FDB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_48) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_48 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_173, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_173, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072CB RID: 29387
		// (get) Token: 0x0602B912 RID: 178450 RVA: 0x00A81BDC File Offset: 0x00A7FDDC
		// (set) Token: 0x0602B913 RID: 178451 RVA: 0x00A81C15 File Offset: 0x00A7FE15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_47) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_47 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_174, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_174, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072CC RID: 29388
		// (get) Token: 0x0602B914 RID: 178452 RVA: 0x00A81C38 File Offset: 0x00A7FE38
		// (set) Token: 0x0602B915 RID: 178453 RVA: 0x00A81C71 File Offset: 0x00A7FE71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_46) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_46 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_175, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_175, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072CD RID: 29389
		// (get) Token: 0x0602B916 RID: 178454 RVA: 0x00A81C94 File Offset: 0x00A7FE94
		// (set) Token: 0x0602B917 RID: 178455 RVA: 0x00A81CCD File Offset: 0x00A7FECD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_45) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_45 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_176, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_176, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072CE RID: 29390
		// (get) Token: 0x0602B918 RID: 178456 RVA: 0x00A81CF0 File Offset: 0x00A7FEF0
		// (set) Token: 0x0602B919 RID: 178457 RVA: 0x00A81D29 File Offset: 0x00A7FF29
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_44) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_44 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_177, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_177, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072CF RID: 29391
		// (get) Token: 0x0602B91A RID: 178458 RVA: 0x00A81D4C File Offset: 0x00A7FF4C
		// (set) Token: 0x0602B91B RID: 178459 RVA: 0x00A81D85 File Offset: 0x00A7FF85
		public FAnimNode_StateResult AnimGraphNode_StateResult_56
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_56) == null)
				{
					result = (this._AnimGraphNode_StateResult_56 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_178, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_178, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D0 RID: 29392
		// (get) Token: 0x0602B91C RID: 178460 RVA: 0x00A81DA8 File Offset: 0x00A7FFA8
		// (set) Token: 0x0602B91D RID: 178461 RVA: 0x00A81DE1 File Offset: 0x00A7FFE1
		public FAnimNode_StateResult AnimGraphNode_StateResult_55
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_55) == null)
				{
					result = (this._AnimGraphNode_StateResult_55 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_179, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_179, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D1 RID: 29393
		// (get) Token: 0x0602B91E RID: 178462 RVA: 0x00A81E04 File Offset: 0x00A80004
		// (set) Token: 0x0602B91F RID: 178463 RVA: 0x00A81E3D File Offset: 0x00A8003D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_43) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_43 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_180, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_180, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D2 RID: 29394
		// (get) Token: 0x0602B920 RID: 178464 RVA: 0x00A81E60 File Offset: 0x00A80060
		// (set) Token: 0x0602B921 RID: 178465 RVA: 0x00A81E99 File Offset: 0x00A80099
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_41) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_41 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_181, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_181, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D3 RID: 29395
		// (get) Token: 0x0602B922 RID: 178466 RVA: 0x00A81EBC File Offset: 0x00A800BC
		// (set) Token: 0x0602B923 RID: 178467 RVA: 0x00A81EF5 File Offset: 0x00A800F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_54
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_54) == null)
				{
					result = (this._AnimGraphNode_StateResult_54 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_182, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_182, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D4 RID: 29396
		// (get) Token: 0x0602B924 RID: 178468 RVA: 0x00A81F18 File Offset: 0x00A80118
		// (set) Token: 0x0602B925 RID: 178469 RVA: 0x00A81F51 File Offset: 0x00A80151
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_40) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_40 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_183, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_183, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D5 RID: 29397
		// (get) Token: 0x0602B926 RID: 178470 RVA: 0x00A81F74 File Offset: 0x00A80174
		// (set) Token: 0x0602B927 RID: 178471 RVA: 0x00A81FAD File Offset: 0x00A801AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_53) == null)
				{
					result = (this._AnimGraphNode_StateResult_53 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_184, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_184, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D6 RID: 29398
		// (get) Token: 0x0602B928 RID: 178472 RVA: 0x00A81FD0 File Offset: 0x00A801D0
		// (set) Token: 0x0602B929 RID: 178473 RVA: 0x00A82009 File Offset: 0x00A80209
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_39) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_39 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_185, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_185, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D7 RID: 29399
		// (get) Token: 0x0602B92A RID: 178474 RVA: 0x00A8202C File Offset: 0x00A8022C
		// (set) Token: 0x0602B92B RID: 178475 RVA: 0x00A82065 File Offset: 0x00A80265
		public FAnimNode_StateResult AnimGraphNode_StateResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_52) == null)
				{
					result = (this._AnimGraphNode_StateResult_52 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_186, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_186, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D8 RID: 29400
		// (get) Token: 0x0602B92C RID: 178476 RVA: 0x00A82088 File Offset: 0x00A80288
		// (set) Token: 0x0602B92D RID: 178477 RVA: 0x00A820C1 File Offset: 0x00A802C1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_38) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_38 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_187, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_187, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072D9 RID: 29401
		// (get) Token: 0x0602B92E RID: 178478 RVA: 0x00A820E4 File Offset: 0x00A802E4
		// (set) Token: 0x0602B92F RID: 178479 RVA: 0x00A8211D File Offset: 0x00A8031D
		public FAnimNode_StateResult AnimGraphNode_StateResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_51) == null)
				{
					result = (this._AnimGraphNode_StateResult_51 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_188, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_188, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072DA RID: 29402
		// (get) Token: 0x0602B930 RID: 178480 RVA: 0x00A82140 File Offset: 0x00A80340
		// (set) Token: 0x0602B931 RID: 178481 RVA: 0x00A82179 File Offset: 0x00A80379
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_42) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_42 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_189, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_189, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072DB RID: 29403
		// (get) Token: 0x0602B932 RID: 178482 RVA: 0x00A8219C File Offset: 0x00A8039C
		// (set) Token: 0x0602B933 RID: 178483 RVA: 0x00A821D5 File Offset: 0x00A803D5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_41) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_41 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_190, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_190, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072DC RID: 29404
		// (get) Token: 0x0602B934 RID: 178484 RVA: 0x00A821F8 File Offset: 0x00A803F8
		// (set) Token: 0x0602B935 RID: 178485 RVA: 0x00A82231 File Offset: 0x00A80431
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_37) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_37 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_191, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_191, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072DD RID: 29405
		// (get) Token: 0x0602B936 RID: 178486 RVA: 0x00A82254 File Offset: 0x00A80454
		// (set) Token: 0x0602B937 RID: 178487 RVA: 0x00A8228D File Offset: 0x00A8048D
		public FAnimNode_StateResult AnimGraphNode_StateResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_50) == null)
				{
					result = (this._AnimGraphNode_StateResult_50 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_192, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_192, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072DE RID: 29406
		// (get) Token: 0x0602B938 RID: 178488 RVA: 0x00A822B0 File Offset: 0x00A804B0
		// (set) Token: 0x0602B939 RID: 178489 RVA: 0x00A822E9 File Offset: 0x00A804E9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_36) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_36 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_193, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_193, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072DF RID: 29407
		// (get) Token: 0x0602B93A RID: 178490 RVA: 0x00A8230C File Offset: 0x00A8050C
		// (set) Token: 0x0602B93B RID: 178491 RVA: 0x00A82345 File Offset: 0x00A80545
		public FAnimNode_StateResult AnimGraphNode_StateResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_49) == null)
				{
					result = (this._AnimGraphNode_StateResult_49 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_194, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_194, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E0 RID: 29408
		// (get) Token: 0x0602B93C RID: 178492 RVA: 0x00A82368 File Offset: 0x00A80568
		// (set) Token: 0x0602B93D RID: 178493 RVA: 0x00A823A1 File Offset: 0x00A805A1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_12) == null)
				{
					result = (this._AnimGraphNode_StateMachine_12 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_195, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_195, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E1 RID: 29409
		// (get) Token: 0x0602B93E RID: 178494 RVA: 0x00A823C4 File Offset: 0x00A805C4
		// (set) Token: 0x0602B93F RID: 178495 RVA: 0x00A823FD File Offset: 0x00A805FD
		public FAnimNode_StateResult AnimGraphNode_StateResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_48) == null)
				{
					result = (this._AnimGraphNode_StateResult_48 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_196, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_196, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E2 RID: 29410
		// (get) Token: 0x0602B940 RID: 178496 RVA: 0x00A82420 File Offset: 0x00A80620
		// (set) Token: 0x0602B941 RID: 178497 RVA: 0x00A82459 File Offset: 0x00A80659
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_40) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_40 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_197, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_197, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E3 RID: 29411
		// (get) Token: 0x0602B942 RID: 178498 RVA: 0x00A8247C File Offset: 0x00A8067C
		// (set) Token: 0x0602B943 RID: 178499 RVA: 0x00A824B5 File Offset: 0x00A806B5
		public FAnimNode_StateResult AnimGraphNode_StateResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_47) == null)
				{
					result = (this._AnimGraphNode_StateResult_47 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_198, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_198, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E4 RID: 29412
		// (get) Token: 0x0602B944 RID: 178500 RVA: 0x00A824D8 File Offset: 0x00A806D8
		// (set) Token: 0x0602B945 RID: 178501 RVA: 0x00A82511 File Offset: 0x00A80711
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_39) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_39 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_199, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_199, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E5 RID: 29413
		// (get) Token: 0x0602B946 RID: 178502 RVA: 0x00A82534 File Offset: 0x00A80734
		// (set) Token: 0x0602B947 RID: 178503 RVA: 0x00A8256D File Offset: 0x00A8076D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_35) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_35 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_200, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_200, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E6 RID: 29414
		// (get) Token: 0x0602B948 RID: 178504 RVA: 0x00A82590 File Offset: 0x00A80790
		// (set) Token: 0x0602B949 RID: 178505 RVA: 0x00A825C9 File Offset: 0x00A807C9
		public FAnimNode_StateResult AnimGraphNode_StateResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_46) == null)
				{
					result = (this._AnimGraphNode_StateResult_46 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_201, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_201, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E7 RID: 29415
		// (get) Token: 0x0602B94A RID: 178506 RVA: 0x00A825EC File Offset: 0x00A807EC
		// (set) Token: 0x0602B94B RID: 178507 RVA: 0x00A82625 File Offset: 0x00A80825
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_202, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_202, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E8 RID: 29416
		// (get) Token: 0x0602B94C RID: 178508 RVA: 0x00A82648 File Offset: 0x00A80848
		// (set) Token: 0x0602B94D RID: 178509 RVA: 0x00A82681 File Offset: 0x00A80881
		public FAnimNode_StateResult AnimGraphNode_StateResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_45) == null)
				{
					result = (this._AnimGraphNode_StateResult_45 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_203, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_203, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072E9 RID: 29417
		// (get) Token: 0x0602B94E RID: 178510 RVA: 0x00A826A4 File Offset: 0x00A808A4
		// (set) Token: 0x0602B94F RID: 178511 RVA: 0x00A826DD File Offset: 0x00A808DD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_11) == null)
				{
					result = (this._AnimGraphNode_StateMachine_11 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_204, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_204, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072EA RID: 29418
		// (get) Token: 0x0602B950 RID: 178512 RVA: 0x00A82700 File Offset: 0x00A80900
		// (set) Token: 0x0602B951 RID: 178513 RVA: 0x00A82739 File Offset: 0x00A80939
		public FAnimNode_StateResult AnimGraphNode_StateResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_44) == null)
				{
					result = (this._AnimGraphNode_StateResult_44 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_205, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_205, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072EB RID: 29419
		// (get) Token: 0x0602B952 RID: 178514 RVA: 0x00A8275C File Offset: 0x00A8095C
		// (set) Token: 0x0602B953 RID: 178515 RVA: 0x00A82795 File Offset: 0x00A80995
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_34) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_34 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_206, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_206, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072EC RID: 29420
		// (get) Token: 0x0602B954 RID: 178516 RVA: 0x00A827B8 File Offset: 0x00A809B8
		// (set) Token: 0x0602B955 RID: 178517 RVA: 0x00A827F1 File Offset: 0x00A809F1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_33) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_33 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_207, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_207, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072ED RID: 29421
		// (get) Token: 0x0602B956 RID: 178518 RVA: 0x00A82814 File Offset: 0x00A80A14
		// (set) Token: 0x0602B957 RID: 178519 RVA: 0x00A8284D File Offset: 0x00A80A4D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_32) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_32 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_208, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_208, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072EE RID: 29422
		// (get) Token: 0x0602B958 RID: 178520 RVA: 0x00A82870 File Offset: 0x00A80A70
		// (set) Token: 0x0602B959 RID: 178521 RVA: 0x00A828A9 File Offset: 0x00A80AA9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_31) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_31 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_209, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_209, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072EF RID: 29423
		// (get) Token: 0x0602B95A RID: 178522 RVA: 0x00A828CC File Offset: 0x00A80ACC
		// (set) Token: 0x0602B95B RID: 178523 RVA: 0x00A82905 File Offset: 0x00A80B05
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_2) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_2 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_210, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_210, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F0 RID: 29424
		// (get) Token: 0x0602B95C RID: 178524 RVA: 0x00A82928 File Offset: 0x00A80B28
		// (set) Token: 0x0602B95D RID: 178525 RVA: 0x00A82961 File Offset: 0x00A80B61
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_4) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_4 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_211, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_211, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F1 RID: 29425
		// (get) Token: 0x0602B95E RID: 178526 RVA: 0x00A82984 File Offset: 0x00A80B84
		// (set) Token: 0x0602B95F RID: 178527 RVA: 0x00A829BD File Offset: 0x00A80BBD
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_3) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_3 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_212, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_212, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F2 RID: 29426
		// (get) Token: 0x0602B960 RID: 178528 RVA: 0x00A829E0 File Offset: 0x00A80BE0
		// (set) Token: 0x0602B961 RID: 178529 RVA: 0x00A82A19 File Offset: 0x00A80C19
		public FAnimNode_StateResult AnimGraphNode_StateResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_43) == null)
				{
					result = (this._AnimGraphNode_StateResult_43 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_213, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_213, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F3 RID: 29427
		// (get) Token: 0x0602B962 RID: 178530 RVA: 0x00A82A3C File Offset: 0x00A80C3C
		// (set) Token: 0x0602B963 RID: 178531 RVA: 0x00A82A75 File Offset: 0x00A80C75
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_30) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_30 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_214, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_214, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F4 RID: 29428
		// (get) Token: 0x0602B964 RID: 178532 RVA: 0x00A82A98 File Offset: 0x00A80C98
		// (set) Token: 0x0602B965 RID: 178533 RVA: 0x00A82AD1 File Offset: 0x00A80CD1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_29) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_29 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_215, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_215, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F5 RID: 29429
		// (get) Token: 0x0602B966 RID: 178534 RVA: 0x00A82AF4 File Offset: 0x00A80CF4
		// (set) Token: 0x0602B967 RID: 178535 RVA: 0x00A82B2D File Offset: 0x00A80D2D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_28) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_28 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_216, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_216, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F6 RID: 29430
		// (get) Token: 0x0602B968 RID: 178536 RVA: 0x00A82B50 File Offset: 0x00A80D50
		// (set) Token: 0x0602B969 RID: 178537 RVA: 0x00A82B89 File Offset: 0x00A80D89
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_27) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_27 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_217, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_217, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F7 RID: 29431
		// (get) Token: 0x0602B96A RID: 178538 RVA: 0x00A82BAC File Offset: 0x00A80DAC
		// (set) Token: 0x0602B96B RID: 178539 RVA: 0x00A82BE5 File Offset: 0x00A80DE5
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive_1) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive_1 = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_218, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_218, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F8 RID: 29432
		// (get) Token: 0x0602B96C RID: 178540 RVA: 0x00A82C08 File Offset: 0x00A80E08
		// (set) Token: 0x0602B96D RID: 178541 RVA: 0x00A82C41 File Offset: 0x00A80E41
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_3) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_3 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_219, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_219, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072F9 RID: 29433
		// (get) Token: 0x0602B96E RID: 178542 RVA: 0x00A82C64 File Offset: 0x00A80E64
		// (set) Token: 0x0602B96F RID: 178543 RVA: 0x00A82C9D File Offset: 0x00A80E9D
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_2) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_2 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_220, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_220, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072FA RID: 29434
		// (get) Token: 0x0602B970 RID: 178544 RVA: 0x00A82CC0 File Offset: 0x00A80EC0
		// (set) Token: 0x0602B971 RID: 178545 RVA: 0x00A82CF9 File Offset: 0x00A80EF9
		public FAnimNode_StateResult AnimGraphNode_StateResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_42) == null)
				{
					result = (this._AnimGraphNode_StateResult_42 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_221, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_221, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072FB RID: 29435
		// (get) Token: 0x0602B972 RID: 178546 RVA: 0x00A82D1C File Offset: 0x00A80F1C
		// (set) Token: 0x0602B973 RID: 178547 RVA: 0x00A82D55 File Offset: 0x00A80F55
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_2) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_2 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_222, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_222, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072FC RID: 29436
		// (get) Token: 0x0602B974 RID: 178548 RVA: 0x00A82D78 File Offset: 0x00A80F78
		// (set) Token: 0x0602B975 RID: 178549 RVA: 0x00A82DB1 File Offset: 0x00A80FB1
		public FAnimNode_StateResult AnimGraphNode_StateResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_41) == null)
				{
					result = (this._AnimGraphNode_StateResult_41 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_223, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_223, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072FD RID: 29437
		// (get) Token: 0x0602B976 RID: 178550 RVA: 0x00A82DD4 File Offset: 0x00A80FD4
		// (set) Token: 0x0602B977 RID: 178551 RVA: 0x00A82E0D File Offset: 0x00A8100D
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_1 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_224, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_224, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072FE RID: 29438
		// (get) Token: 0x0602B978 RID: 178552 RVA: 0x00A82E30 File Offset: 0x00A81030
		// (set) Token: 0x0602B979 RID: 178553 RVA: 0x00A82E69 File Offset: 0x00A81069
		public FAnimNode_StateResult AnimGraphNode_StateResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_40) == null)
				{
					result = (this._AnimGraphNode_StateResult_40 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_225, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_225, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170072FF RID: 29439
		// (get) Token: 0x0602B97A RID: 178554 RVA: 0x00A82E8C File Offset: 0x00A8108C
		// (set) Token: 0x0602B97B RID: 178555 RVA: 0x00A82EC5 File Offset: 0x00A810C5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_10) == null)
				{
					result = (this._AnimGraphNode_StateMachine_10 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_226, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_226, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007300 RID: 29440
		// (get) Token: 0x0602B97C RID: 178556 RVA: 0x00A82EE8 File Offset: 0x00A810E8
		// (set) Token: 0x0602B97D RID: 178557 RVA: 0x00A82F21 File Offset: 0x00A81121
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_1 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_227, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_227, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007301 RID: 29441
		// (get) Token: 0x0602B97E RID: 178558 RVA: 0x00A82F44 File Offset: 0x00A81144
		// (set) Token: 0x0602B97F RID: 178559 RVA: 0x00A82F7D File Offset: 0x00A8117D
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool_1) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool_1 = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_228, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_228, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007302 RID: 29442
		// (get) Token: 0x0602B980 RID: 178560 RVA: 0x00A82FA0 File Offset: 0x00A811A0
		// (set) Token: 0x0602B981 RID: 178561 RVA: 0x00A82FD9 File Offset: 0x00A811D9
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_229, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_229, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007303 RID: 29443
		// (get) Token: 0x0602B982 RID: 178562 RVA: 0x00A82FFC File Offset: 0x00A811FC
		// (set) Token: 0x0602B983 RID: 178563 RVA: 0x00A83035 File Offset: 0x00A81235
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves) == null)
				{
					result = (this._AnimGraphNode_CombineCurves = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_230, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_230, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007304 RID: 29444
		// (get) Token: 0x0602B984 RID: 178564 RVA: 0x00A83058 File Offset: 0x00A81258
		// (set) Token: 0x0602B985 RID: 178565 RVA: 0x00A83091 File Offset: 0x00A81291
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_231, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_231, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007305 RID: 29445
		// (get) Token: 0x0602B986 RID: 178566 RVA: 0x00A830B4 File Offset: 0x00A812B4
		// (set) Token: 0x0602B987 RID: 178567 RVA: 0x00A830ED File Offset: 0x00A812ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_38) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_38 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_232, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_232, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007306 RID: 29446
		// (get) Token: 0x0602B988 RID: 178568 RVA: 0x00A83110 File Offset: 0x00A81310
		// (set) Token: 0x0602B989 RID: 178569 RVA: 0x00A83149 File Offset: 0x00A81349
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_37) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_37 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_233, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_233, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007307 RID: 29447
		// (get) Token: 0x0602B98A RID: 178570 RVA: 0x00A8316C File Offset: 0x00A8136C
		// (set) Token: 0x0602B98B RID: 178571 RVA: 0x00A831A5 File Offset: 0x00A813A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_36) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_36 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_234, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_234, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007308 RID: 29448
		// (get) Token: 0x0602B98C RID: 178572 RVA: 0x00A831C8 File Offset: 0x00A813C8
		// (set) Token: 0x0602B98D RID: 178573 RVA: 0x00A83201 File Offset: 0x00A81401
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_35) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_35 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_235, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_235, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007309 RID: 29449
		// (get) Token: 0x0602B98E RID: 178574 RVA: 0x00A83224 File Offset: 0x00A81424
		// (set) Token: 0x0602B98F RID: 178575 RVA: 0x00A8325D File Offset: 0x00A8145D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_34) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_34 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_236, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_236, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700730A RID: 29450
		// (get) Token: 0x0602B990 RID: 178576 RVA: 0x00A83280 File Offset: 0x00A81480
		// (set) Token: 0x0602B991 RID: 178577 RVA: 0x00A832B9 File Offset: 0x00A814B9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_237, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_237, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700730B RID: 29451
		// (get) Token: 0x0602B992 RID: 178578 RVA: 0x00A832DC File Offset: 0x00A814DC
		// (set) Token: 0x0602B993 RID: 178579 RVA: 0x00A83315 File Offset: 0x00A81515
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_238, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_238, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700730C RID: 29452
		// (get) Token: 0x0602B994 RID: 178580 RVA: 0x00A83338 File Offset: 0x00A81538
		// (set) Token: 0x0602B995 RID: 178581 RVA: 0x00A83371 File Offset: 0x00A81571
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_239, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_239, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700730D RID: 29453
		// (get) Token: 0x0602B996 RID: 178582 RVA: 0x00A83394 File Offset: 0x00A81594
		// (set) Token: 0x0602B997 RID: 178583 RVA: 0x00A833CD File Offset: 0x00A815CD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_240, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_240, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700730E RID: 29454
		// (get) Token: 0x0602B998 RID: 178584 RVA: 0x00A833F0 File Offset: 0x00A815F0
		// (set) Token: 0x0602B999 RID: 178585 RVA: 0x00A83429 File Offset: 0x00A81629
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_241, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_241, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700730F RID: 29455
		// (get) Token: 0x0602B99A RID: 178586 RVA: 0x00A8344C File Offset: 0x00A8164C
		// (set) Token: 0x0602B99B RID: 178587 RVA: 0x00A83485 File Offset: 0x00A81685
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_242, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_242, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007310 RID: 29456
		// (get) Token: 0x0602B99C RID: 178588 RVA: 0x00A834A8 File Offset: 0x00A816A8
		// (set) Token: 0x0602B99D RID: 178589 RVA: 0x00A834E1 File Offset: 0x00A816E1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_243, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_243, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007311 RID: 29457
		// (get) Token: 0x0602B99E RID: 178590 RVA: 0x00A83504 File Offset: 0x00A81704
		// (set) Token: 0x0602B99F RID: 178591 RVA: 0x00A8353D File Offset: 0x00A8173D
		public FAnimNode_StateResult AnimGraphNode_StateResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_39) == null)
				{
					result = (this._AnimGraphNode_StateResult_39 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_244, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_244, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007312 RID: 29458
		// (get) Token: 0x0602B9A0 RID: 178592 RVA: 0x00A83560 File Offset: 0x00A81760
		// (set) Token: 0x0602B9A1 RID: 178593 RVA: 0x00A83599 File Offset: 0x00A81799
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_26) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_26 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_245, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_245, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007313 RID: 29459
		// (get) Token: 0x0602B9A2 RID: 178594 RVA: 0x00A835BC File Offset: 0x00A817BC
		// (set) Token: 0x0602B9A3 RID: 178595 RVA: 0x00A835F5 File Offset: 0x00A817F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_38) == null)
				{
					result = (this._AnimGraphNode_StateResult_38 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_246, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_246, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007314 RID: 29460
		// (get) Token: 0x0602B9A4 RID: 178596 RVA: 0x00A83618 File Offset: 0x00A81818
		// (set) Token: 0x0602B9A5 RID: 178597 RVA: 0x00A83651 File Offset: 0x00A81851
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_25) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_25 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_247, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_247, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007315 RID: 29461
		// (get) Token: 0x0602B9A6 RID: 178598 RVA: 0x00A83674 File Offset: 0x00A81874
		// (set) Token: 0x0602B9A7 RID: 178599 RVA: 0x00A836AD File Offset: 0x00A818AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_37) == null)
				{
					result = (this._AnimGraphNode_StateResult_37 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_248, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_248, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007316 RID: 29462
		// (get) Token: 0x0602B9A8 RID: 178600 RVA: 0x00A836D0 File Offset: 0x00A818D0
		// (set) Token: 0x0602B9A9 RID: 178601 RVA: 0x00A83709 File Offset: 0x00A81909
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_24) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_24 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_249, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_249, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007317 RID: 29463
		// (get) Token: 0x0602B9AA RID: 178602 RVA: 0x00A8372C File Offset: 0x00A8192C
		// (set) Token: 0x0602B9AB RID: 178603 RVA: 0x00A83765 File Offset: 0x00A81965
		public FAnimNode_StateResult AnimGraphNode_StateResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_36) == null)
				{
					result = (this._AnimGraphNode_StateResult_36 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_250, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_250, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007318 RID: 29464
		// (get) Token: 0x0602B9AC RID: 178604 RVA: 0x00A83788 File Offset: 0x00A81988
		// (set) Token: 0x0602B9AD RID: 178605 RVA: 0x00A837C1 File Offset: 0x00A819C1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_9) == null)
				{
					result = (this._AnimGraphNode_StateMachine_9 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_251, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_251, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007319 RID: 29465
		// (get) Token: 0x0602B9AE RID: 178606 RVA: 0x00A837E4 File Offset: 0x00A819E4
		// (set) Token: 0x0602B9AF RID: 178607 RVA: 0x00A8381D File Offset: 0x00A81A1D
		public FAnimNode_StateResult AnimGraphNode_StateResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_35) == null)
				{
					result = (this._AnimGraphNode_StateResult_35 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_252, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_252, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700731A RID: 29466
		// (get) Token: 0x0602B9B0 RID: 178608 RVA: 0x00A83840 File Offset: 0x00A81A40
		// (set) Token: 0x0602B9B1 RID: 178609 RVA: 0x00A83879 File Offset: 0x00A81A79
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_253, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_253, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700731B RID: 29467
		// (get) Token: 0x0602B9B2 RID: 178610 RVA: 0x00A8389C File Offset: 0x00A81A9C
		// (set) Token: 0x0602B9B3 RID: 178611 RVA: 0x00A838D5 File Offset: 0x00A81AD5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_254, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_254, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700731C RID: 29468
		// (get) Token: 0x0602B9B4 RID: 178612 RVA: 0x00A838F8 File Offset: 0x00A81AF8
		// (set) Token: 0x0602B9B5 RID: 178613 RVA: 0x00A83931 File Offset: 0x00A81B31
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_255, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_255, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700731D RID: 29469
		// (get) Token: 0x0602B9B6 RID: 178614 RVA: 0x00A83954 File Offset: 0x00A81B54
		// (set) Token: 0x0602B9B7 RID: 178615 RVA: 0x00A8398D File Offset: 0x00A81B8D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_256, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_256, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700731E RID: 29470
		// (get) Token: 0x0602B9B8 RID: 178616 RVA: 0x00A839B0 File Offset: 0x00A81BB0
		// (set) Token: 0x0602B9B9 RID: 178617 RVA: 0x00A839E9 File Offset: 0x00A81BE9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_257, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_257, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700731F RID: 29471
		// (get) Token: 0x0602B9BA RID: 178618 RVA: 0x00A83A0C File Offset: 0x00A81C0C
		// (set) Token: 0x0602B9BB RID: 178619 RVA: 0x00A83A45 File Offset: 0x00A81C45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_258, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_258, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007320 RID: 29472
		// (get) Token: 0x0602B9BC RID: 178620 RVA: 0x00A83A68 File Offset: 0x00A81C68
		// (set) Token: 0x0602B9BD RID: 178621 RVA: 0x00A83AA1 File Offset: 0x00A81CA1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_23) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_23 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_259, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_259, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007321 RID: 29473
		// (get) Token: 0x0602B9BE RID: 178622 RVA: 0x00A83AC4 File Offset: 0x00A81CC4
		// (set) Token: 0x0602B9BF RID: 178623 RVA: 0x00A83AFD File Offset: 0x00A81CFD
		public FAnimNode_StateResult AnimGraphNode_StateResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_34) == null)
				{
					result = (this._AnimGraphNode_StateResult_34 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_260, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_260, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007322 RID: 29474
		// (get) Token: 0x0602B9C0 RID: 178624 RVA: 0x00A83B20 File Offset: 0x00A81D20
		// (set) Token: 0x0602B9C1 RID: 178625 RVA: 0x00A83B59 File Offset: 0x00A81D59
		public FAnimNode_StateResult AnimGraphNode_StateResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_33) == null)
				{
					result = (this._AnimGraphNode_StateResult_33 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_261, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_261, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007323 RID: 29475
		// (get) Token: 0x0602B9C2 RID: 178626 RVA: 0x00A83B7C File Offset: 0x00A81D7C
		// (set) Token: 0x0602B9C3 RID: 178627 RVA: 0x00A83BB5 File Offset: 0x00A81DB5
		public FAnimNode_StateResult AnimGraphNode_StateResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_32) == null)
				{
					result = (this._AnimGraphNode_StateResult_32 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_262, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_262, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007324 RID: 29476
		// (get) Token: 0x0602B9C4 RID: 178628 RVA: 0x00A83BD8 File Offset: 0x00A81DD8
		// (set) Token: 0x0602B9C5 RID: 178629 RVA: 0x00A83C11 File Offset: 0x00A81E11
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_22) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_22 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_263, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_263, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007325 RID: 29477
		// (get) Token: 0x0602B9C6 RID: 178630 RVA: 0x00A83C34 File Offset: 0x00A81E34
		// (set) Token: 0x0602B9C7 RID: 178631 RVA: 0x00A83C6D File Offset: 0x00A81E6D
		public FAnimNode_StateResult AnimGraphNode_StateResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_31) == null)
				{
					result = (this._AnimGraphNode_StateResult_31 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_264, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_264, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007326 RID: 29478
		// (get) Token: 0x0602B9C8 RID: 178632 RVA: 0x00A83C90 File Offset: 0x00A81E90
		// (set) Token: 0x0602B9C9 RID: 178633 RVA: 0x00A83CC9 File Offset: 0x00A81EC9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_21) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_21 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_265, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_265, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007327 RID: 29479
		// (get) Token: 0x0602B9CA RID: 178634 RVA: 0x00A83CEC File Offset: 0x00A81EEC
		// (set) Token: 0x0602B9CB RID: 178635 RVA: 0x00A83D25 File Offset: 0x00A81F25
		public FAnimNode_StateResult AnimGraphNode_StateResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_30) == null)
				{
					result = (this._AnimGraphNode_StateResult_30 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_266, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_266, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007328 RID: 29480
		// (get) Token: 0x0602B9CC RID: 178636 RVA: 0x00A83D48 File Offset: 0x00A81F48
		// (set) Token: 0x0602B9CD RID: 178637 RVA: 0x00A83D81 File Offset: 0x00A81F81
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_20) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_20 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_267, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_267, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007329 RID: 29481
		// (get) Token: 0x0602B9CE RID: 178638 RVA: 0x00A83DA4 File Offset: 0x00A81FA4
		// (set) Token: 0x0602B9CF RID: 178639 RVA: 0x00A83DDD File Offset: 0x00A81FDD
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_268, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_268, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700732A RID: 29482
		// (get) Token: 0x0602B9D0 RID: 178640 RVA: 0x00A83E00 File Offset: 0x00A82000
		// (set) Token: 0x0602B9D1 RID: 178641 RVA: 0x00A83E39 File Offset: 0x00A82039
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_19) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_19 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_269, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_269, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700732B RID: 29483
		// (get) Token: 0x0602B9D2 RID: 178642 RVA: 0x00A83E5C File Offset: 0x00A8205C
		// (set) Token: 0x0602B9D3 RID: 178643 RVA: 0x00A83E95 File Offset: 0x00A82095
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_270, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_270, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700732C RID: 29484
		// (get) Token: 0x0602B9D4 RID: 178644 RVA: 0x00A83EB8 File Offset: 0x00A820B8
		// (set) Token: 0x0602B9D5 RID: 178645 RVA: 0x00A83EF1 File Offset: 0x00A820F1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_8) == null)
				{
					result = (this._AnimGraphNode_StateMachine_8 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_271, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_271, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700732D RID: 29485
		// (get) Token: 0x0602B9D6 RID: 178646 RVA: 0x00A83F14 File Offset: 0x00A82114
		// (set) Token: 0x0602B9D7 RID: 178647 RVA: 0x00A83F4D File Offset: 0x00A8214D
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_272, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_272, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700732E RID: 29486
		// (get) Token: 0x0602B9D8 RID: 178648 RVA: 0x00A83F70 File Offset: 0x00A82170
		// (set) Token: 0x0602B9D9 RID: 178649 RVA: 0x00A83FA9 File Offset: 0x00A821A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_18) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_18 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_273, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_273, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700732F RID: 29487
		// (get) Token: 0x0602B9DA RID: 178650 RVA: 0x00A83FCC File Offset: 0x00A821CC
		// (set) Token: 0x0602B9DB RID: 178651 RVA: 0x00A84005 File Offset: 0x00A82205
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_274, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_274, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007330 RID: 29488
		// (get) Token: 0x0602B9DC RID: 178652 RVA: 0x00A84028 File Offset: 0x00A82228
		// (set) Token: 0x0602B9DD RID: 178653 RVA: 0x00A84061 File Offset: 0x00A82261
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_7) == null)
				{
					result = (this._AnimGraphNode_StateMachine_7 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_275, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_275, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007331 RID: 29489
		// (get) Token: 0x0602B9DE RID: 178654 RVA: 0x00A84084 File Offset: 0x00A82284
		// (set) Token: 0x0602B9DF RID: 178655 RVA: 0x00A840BD File Offset: 0x00A822BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_276, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_276, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007332 RID: 29490
		// (get) Token: 0x0602B9E0 RID: 178656 RVA: 0x00A840E0 File Offset: 0x00A822E0
		// (set) Token: 0x0602B9E1 RID: 178657 RVA: 0x00A84119 File Offset: 0x00A82319
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_277, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_277, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007333 RID: 29491
		// (get) Token: 0x0602B9E2 RID: 178658 RVA: 0x00A8413C File Offset: 0x00A8233C
		// (set) Token: 0x0602B9E3 RID: 178659 RVA: 0x00A84175 File Offset: 0x00A82375
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_278, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_278, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007334 RID: 29492
		// (get) Token: 0x0602B9E4 RID: 178660 RVA: 0x00A84198 File Offset: 0x00A82398
		// (set) Token: 0x0602B9E5 RID: 178661 RVA: 0x00A841D1 File Offset: 0x00A823D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_279, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_279, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007335 RID: 29493
		// (get) Token: 0x0602B9E6 RID: 178662 RVA: 0x00A841F4 File Offset: 0x00A823F4
		// (set) Token: 0x0602B9E7 RID: 178663 RVA: 0x00A8422D File Offset: 0x00A8242D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_280, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_280, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007336 RID: 29494
		// (get) Token: 0x0602B9E8 RID: 178664 RVA: 0x00A84250 File Offset: 0x00A82450
		// (set) Token: 0x0602B9E9 RID: 178665 RVA: 0x00A84289 File Offset: 0x00A82489
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_281, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_281, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007337 RID: 29495
		// (get) Token: 0x0602B9EA RID: 178666 RVA: 0x00A842AC File Offset: 0x00A824AC
		// (set) Token: 0x0602B9EB RID: 178667 RVA: 0x00A842E5 File Offset: 0x00A824E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_282, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_282, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007338 RID: 29496
		// (get) Token: 0x0602B9EC RID: 178668 RVA: 0x00A84308 File Offset: 0x00A82508
		// (set) Token: 0x0602B9ED RID: 178669 RVA: 0x00A84341 File Offset: 0x00A82541
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_283, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_283, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007339 RID: 29497
		// (get) Token: 0x0602B9EE RID: 178670 RVA: 0x00A84364 File Offset: 0x00A82564
		// (set) Token: 0x0602B9EF RID: 178671 RVA: 0x00A8439D File Offset: 0x00A8259D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_17) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_17 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_284, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_284, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700733A RID: 29498
		// (get) Token: 0x0602B9F0 RID: 178672 RVA: 0x00A843C0 File Offset: 0x00A825C0
		// (set) Token: 0x0602B9F1 RID: 178673 RVA: 0x00A843F9 File Offset: 0x00A825F9
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_285, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_285, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700733B RID: 29499
		// (get) Token: 0x0602B9F2 RID: 178674 RVA: 0x00A8441C File Offset: 0x00A8261C
		// (set) Token: 0x0602B9F3 RID: 178675 RVA: 0x00A84455 File Offset: 0x00A82655
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_16) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_16 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_286, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_286, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700733C RID: 29500
		// (get) Token: 0x0602B9F4 RID: 178676 RVA: 0x00A84478 File Offset: 0x00A82678
		// (set) Token: 0x0602B9F5 RID: 178677 RVA: 0x00A844B1 File Offset: 0x00A826B1
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_287, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_287, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700733D RID: 29501
		// (get) Token: 0x0602B9F6 RID: 178678 RVA: 0x00A844D4 File Offset: 0x00A826D4
		// (set) Token: 0x0602B9F7 RID: 178679 RVA: 0x00A8450D File Offset: 0x00A8270D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_15) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_15 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_288, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_288, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700733E RID: 29502
		// (get) Token: 0x0602B9F8 RID: 178680 RVA: 0x00A84530 File Offset: 0x00A82730
		// (set) Token: 0x0602B9F9 RID: 178681 RVA: 0x00A84569 File Offset: 0x00A82769
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_289, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_289, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700733F RID: 29503
		// (get) Token: 0x0602B9FA RID: 178682 RVA: 0x00A8458C File Offset: 0x00A8278C
		// (set) Token: 0x0602B9FB RID: 178683 RVA: 0x00A845C5 File Offset: 0x00A827C5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_6) == null)
				{
					result = (this._AnimGraphNode_StateMachine_6 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_290, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_290, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007340 RID: 29504
		// (get) Token: 0x0602B9FC RID: 178684 RVA: 0x00A845E8 File Offset: 0x00A827E8
		// (set) Token: 0x0602B9FD RID: 178685 RVA: 0x00A84621 File Offset: 0x00A82821
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_291, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_291, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007341 RID: 29505
		// (get) Token: 0x0602B9FE RID: 178686 RVA: 0x00A84644 File Offset: 0x00A82844
		// (set) Token: 0x0602B9FF RID: 178687 RVA: 0x00A8467D File Offset: 0x00A8287D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_292, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_292, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007342 RID: 29506
		// (get) Token: 0x0602BA00 RID: 178688 RVA: 0x00A846A0 File Offset: 0x00A828A0
		// (set) Token: 0x0602BA01 RID: 178689 RVA: 0x00A846D9 File Offset: 0x00A828D9
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_293, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_293, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007343 RID: 29507
		// (get) Token: 0x0602BA02 RID: 178690 RVA: 0x00A846FC File Offset: 0x00A828FC
		// (set) Token: 0x0602BA03 RID: 178691 RVA: 0x00A84735 File Offset: 0x00A82935
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_294, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_294, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007344 RID: 29508
		// (get) Token: 0x0602BA04 RID: 178692 RVA: 0x00A84758 File Offset: 0x00A82958
		// (set) Token: 0x0602BA05 RID: 178693 RVA: 0x00A84791 File Offset: 0x00A82991
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_295, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_295, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007345 RID: 29509
		// (get) Token: 0x0602BA06 RID: 178694 RVA: 0x00A847B4 File Offset: 0x00A829B4
		// (set) Token: 0x0602BA07 RID: 178695 RVA: 0x00A847ED File Offset: 0x00A829ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_296, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_296, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007346 RID: 29510
		// (get) Token: 0x0602BA08 RID: 178696 RVA: 0x00A84810 File Offset: 0x00A82A10
		// (set) Token: 0x0602BA09 RID: 178697 RVA: 0x00A84849 File Offset: 0x00A82A49
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_5) == null)
				{
					result = (this._AnimGraphNode_StateMachine_5 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_297, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_297, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007347 RID: 29511
		// (get) Token: 0x0602BA0A RID: 178698 RVA: 0x00A8486C File Offset: 0x00A82A6C
		// (set) Token: 0x0602BA0B RID: 178699 RVA: 0x00A848A5 File Offset: 0x00A82AA5
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_298, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_298, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007348 RID: 29512
		// (get) Token: 0x0602BA0C RID: 178700 RVA: 0x00A848C8 File Offset: 0x00A82AC8
		// (set) Token: 0x0602BA0D RID: 178701 RVA: 0x00A84901 File Offset: 0x00A82B01
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_299, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_299, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007349 RID: 29513
		// (get) Token: 0x0602BA0E RID: 178702 RVA: 0x00A84924 File Offset: 0x00A82B24
		// (set) Token: 0x0602BA0F RID: 178703 RVA: 0x00A8495D File Offset: 0x00A82B5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_300, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_300, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700734A RID: 29514
		// (get) Token: 0x0602BA10 RID: 178704 RVA: 0x00A84980 File Offset: 0x00A82B80
		// (set) Token: 0x0602BA11 RID: 178705 RVA: 0x00A849B9 File Offset: 0x00A82BB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_301, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_301, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700734B RID: 29515
		// (get) Token: 0x0602BA12 RID: 178706 RVA: 0x00A849DC File Offset: 0x00A82BDC
		// (set) Token: 0x0602BA13 RID: 178707 RVA: 0x00A84A15 File Offset: 0x00A82C15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_302, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_302, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700734C RID: 29516
		// (get) Token: 0x0602BA14 RID: 178708 RVA: 0x00A84A38 File Offset: 0x00A82C38
		// (set) Token: 0x0602BA15 RID: 178709 RVA: 0x00A84A71 File Offset: 0x00A82C71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_303, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_303, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700734D RID: 29517
		// (get) Token: 0x0602BA16 RID: 178710 RVA: 0x00A84A94 File Offset: 0x00A82C94
		// (set) Token: 0x0602BA17 RID: 178711 RVA: 0x00A84ACD File Offset: 0x00A82CCD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_304, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_304, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700734E RID: 29518
		// (get) Token: 0x0602BA18 RID: 178712 RVA: 0x00A84AF0 File Offset: 0x00A82CF0
		// (set) Token: 0x0602BA19 RID: 178713 RVA: 0x00A84B29 File Offset: 0x00A82D29
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_305, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_305, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700734F RID: 29519
		// (get) Token: 0x0602BA1A RID: 178714 RVA: 0x00A84B4C File Offset: 0x00A82D4C
		// (set) Token: 0x0602BA1B RID: 178715 RVA: 0x00A84B85 File Offset: 0x00A82D85
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_306, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_306, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007350 RID: 29520
		// (get) Token: 0x0602BA1C RID: 178716 RVA: 0x00A84BA8 File Offset: 0x00A82DA8
		// (set) Token: 0x0602BA1D RID: 178717 RVA: 0x00A84BE1 File Offset: 0x00A82DE1
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_307, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_307, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007351 RID: 29521
		// (get) Token: 0x0602BA1E RID: 178718 RVA: 0x00A84C04 File Offset: 0x00A82E04
		// (set) Token: 0x0602BA1F RID: 178719 RVA: 0x00A84C3D File Offset: 0x00A82E3D
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_308, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_308, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007352 RID: 29522
		// (get) Token: 0x0602BA20 RID: 178720 RVA: 0x00A84C60 File Offset: 0x00A82E60
		// (set) Token: 0x0602BA21 RID: 178721 RVA: 0x00A84C99 File Offset: 0x00A82E99
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_309, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_309, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007353 RID: 29523
		// (get) Token: 0x0602BA22 RID: 178722 RVA: 0x00A84CBC File Offset: 0x00A82EBC
		// (set) Token: 0x0602BA23 RID: 178723 RVA: 0x00A84CF5 File Offset: 0x00A82EF5
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_310, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_310, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007354 RID: 29524
		// (get) Token: 0x0602BA24 RID: 178724 RVA: 0x00A84D18 File Offset: 0x00A82F18
		// (set) Token: 0x0602BA25 RID: 178725 RVA: 0x00A84D51 File Offset: 0x00A82F51
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_311, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_311, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007355 RID: 29525
		// (get) Token: 0x0602BA26 RID: 178726 RVA: 0x00A84D74 File Offset: 0x00A82F74
		// (set) Token: 0x0602BA27 RID: 178727 RVA: 0x00A84DAD File Offset: 0x00A82FAD
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_312, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_312, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007356 RID: 29526
		// (get) Token: 0x0602BA28 RID: 178728 RVA: 0x00A84DD0 File Offset: 0x00A82FD0
		// (set) Token: 0x0602BA29 RID: 178729 RVA: 0x00A84E09 File Offset: 0x00A83009
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_313, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_313, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007357 RID: 29527
		// (get) Token: 0x0602BA2A RID: 178730 RVA: 0x00A84E2C File Offset: 0x00A8302C
		// (set) Token: 0x0602BA2B RID: 178731 RVA: 0x00A84E65 File Offset: 0x00A83065
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_314, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_314, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007358 RID: 29528
		// (get) Token: 0x0602BA2C RID: 178732 RVA: 0x00A84E88 File Offset: 0x00A83088
		// (set) Token: 0x0602BA2D RID: 178733 RVA: 0x00A84EC1 File Offset: 0x00A830C1
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_315, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_315, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007359 RID: 29529
		// (get) Token: 0x0602BA2E RID: 178734 RVA: 0x00A84EE4 File Offset: 0x00A830E4
		// (set) Token: 0x0602BA2F RID: 178735 RVA: 0x00A84F1D File Offset: 0x00A8311D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_316, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_316, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700735A RID: 29530
		// (get) Token: 0x0602BA30 RID: 178736 RVA: 0x00A84F40 File Offset: 0x00A83140
		// (set) Token: 0x0602BA31 RID: 178737 RVA: 0x00A84F79 File Offset: 0x00A83179
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_317, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_317, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700735B RID: 29531
		// (get) Token: 0x0602BA32 RID: 178738 RVA: 0x00A84F9C File Offset: 0x00A8319C
		// (set) Token: 0x0602BA33 RID: 178739 RVA: 0x00A84FD5 File Offset: 0x00A831D5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_318, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_318, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700735C RID: 29532
		// (get) Token: 0x0602BA34 RID: 178740 RVA: 0x00A84FF8 File Offset: 0x00A831F8
		// (set) Token: 0x0602BA35 RID: 178741 RVA: 0x00A85031 File Offset: 0x00A83231
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_319, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_319, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700735D RID: 29533
		// (get) Token: 0x0602BA36 RID: 178742 RVA: 0x00A85054 File Offset: 0x00A83254
		// (set) Token: 0x0602BA37 RID: 178743 RVA: 0x00A8508D File Offset: 0x00A8328D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_320, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_320, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700735E RID: 29534
		// (get) Token: 0x0602BA38 RID: 178744 RVA: 0x00A850B0 File Offset: 0x00A832B0
		// (set) Token: 0x0602BA39 RID: 178745 RVA: 0x00A850E9 File Offset: 0x00A832E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_321, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_321, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700735F RID: 29535
		// (get) Token: 0x0602BA3A RID: 178746 RVA: 0x00A8510C File Offset: 0x00A8330C
		// (set) Token: 0x0602BA3B RID: 178747 RVA: 0x00A85145 File Offset: 0x00A83345
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_322, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_322, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007360 RID: 29536
		// (get) Token: 0x0602BA3C RID: 178748 RVA: 0x00A85168 File Offset: 0x00A83368
		// (set) Token: 0x0602BA3D RID: 178749 RVA: 0x00A851A1 File Offset: 0x00A833A1
		public FAnimNode_ExtraFollowAnims AnimGraphNode_ExtraFollowAnims
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ExtraFollowAnims result;
				if ((result = this._AnimGraphNode_ExtraFollowAnims) == null)
				{
					result = (this._AnimGraphNode_ExtraFollowAnims = new FAnimNode_ExtraFollowAnims(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_323, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ExtraFollowAnims.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_323, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007361 RID: 29537
		// (get) Token: 0x0602BA3E RID: 178750 RVA: 0x00A851C4 File Offset: 0x00A833C4
		// (set) Token: 0x0602BA3F RID: 178751 RVA: 0x00A851FD File Offset: 0x00A833FD
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_324, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_324, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007362 RID: 29538
		// (get) Token: 0x0602BA40 RID: 178752 RVA: 0x00A85220 File Offset: 0x00A83420
		// (set) Token: 0x0602BA41 RID: 178753 RVA: 0x00A85259 File Offset: 0x00A83459
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_325, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_325, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007363 RID: 29539
		// (get) Token: 0x0602BA42 RID: 178754 RVA: 0x00A8527C File Offset: 0x00A8347C
		// (set) Token: 0x0602BA43 RID: 178755 RVA: 0x00A852B5 File Offset: 0x00A834B5
		public FAnimNode_ModifyBone AnimGraphNode_ModifyBone
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ModifyBone result;
				if ((result = this._AnimGraphNode_ModifyBone) == null)
				{
					result = (this._AnimGraphNode_ModifyBone = new FAnimNode_ModifyBone(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_326, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ModifyBone.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_326, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007364 RID: 29540
		// (get) Token: 0x0602BA44 RID: 178756 RVA: 0x00A852D8 File Offset: 0x00A834D8
		// (set) Token: 0x0602BA45 RID: 178757 RVA: 0x00A85311 File Offset: 0x00A83511
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_327, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_327, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007365 RID: 29541
		// (get) Token: 0x0602BA46 RID: 178758 RVA: 0x00A85334 File Offset: 0x00A83534
		// (set) Token: 0x0602BA47 RID: 178759 RVA: 0x00A8536D File Offset: 0x00A8356D
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_328, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_328, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007366 RID: 29542
		// (get) Token: 0x0602BA48 RID: 178760 RVA: 0x00A85390 File Offset: 0x00A83590
		// (set) Token: 0x0602BA49 RID: 178761 RVA: 0x00A853C9 File Offset: 0x00A835C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_329, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_329, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007367 RID: 29543
		// (get) Token: 0x0602BA4A RID: 178762 RVA: 0x00A853EC File Offset: 0x00A835EC
		// (set) Token: 0x0602BA4B RID: 178763 RVA: 0x00A85425 File Offset: 0x00A83625
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_330, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_330, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007368 RID: 29544
		// (get) Token: 0x0602BA4C RID: 178764 RVA: 0x00A85448 File Offset: 0x00A83648
		// (set) Token: 0x0602BA4D RID: 178765 RVA: 0x00A85481 File Offset: 0x00A83681
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_331, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_331, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007369 RID: 29545
		// (get) Token: 0x0602BA4E RID: 178766 RVA: 0x00A854A4 File Offset: 0x00A836A4
		// (set) Token: 0x0602BA4F RID: 178767 RVA: 0x00A854DD File Offset: 0x00A836DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_332, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_332, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700736A RID: 29546
		// (get) Token: 0x0602BA50 RID: 178768 RVA: 0x00A85500 File Offset: 0x00A83700
		// (set) Token: 0x0602BA51 RID: 178769 RVA: 0x00A85539 File Offset: 0x00A83739
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_333, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_333, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700736B RID: 29547
		// (get) Token: 0x0602BA52 RID: 178770 RVA: 0x00A8555C File Offset: 0x00A8375C
		// (set) Token: 0x0602BA53 RID: 178771 RVA: 0x00A85595 File Offset: 0x00A83795
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_334, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_334, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700736C RID: 29548
		// (get) Token: 0x0602BA54 RID: 178772 RVA: 0x00A855B8 File Offset: 0x00A837B8
		// (set) Token: 0x0602BA55 RID: 178773 RVA: 0x00A855F1 File Offset: 0x00A837F1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_335, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_335, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700736D RID: 29549
		// (get) Token: 0x0602BA56 RID: 178774 RVA: 0x00A85614 File Offset: 0x00A83814
		// (set) Token: 0x0602BA57 RID: 178775 RVA: 0x00A8564D File Offset: 0x00A8384D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_336, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_336, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700736E RID: 29550
		// (get) Token: 0x0602BA58 RID: 178776 RVA: 0x00A85670 File Offset: 0x00A83870
		// (set) Token: 0x0602BA59 RID: 178777 RVA: 0x00A856A9 File Offset: 0x00A838A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_337, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_337, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700736F RID: 29551
		// (get) Token: 0x0602BA5A RID: 178778 RVA: 0x00A856CC File Offset: 0x00A838CC
		// (set) Token: 0x0602BA5B RID: 178779 RVA: 0x00A85705 File Offset: 0x00A83905
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_338, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_338, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007370 RID: 29552
		// (get) Token: 0x0602BA5C RID: 178780 RVA: 0x00A85728 File Offset: 0x00A83928
		// (set) Token: 0x0602BA5D RID: 178781 RVA: 0x00A85761 File Offset: 0x00A83961
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend_1) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend_1 = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_339, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_339, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007371 RID: 29553
		// (get) Token: 0x0602BA5E RID: 178782 RVA: 0x00A85784 File Offset: 0x00A83984
		// (set) Token: 0x0602BA5F RID: 178783 RVA: 0x00A857BD File Offset: 0x00A839BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_340, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_340, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007372 RID: 29554
		// (get) Token: 0x0602BA60 RID: 178784 RVA: 0x00A857E0 File Offset: 0x00A839E0
		// (set) Token: 0x0602BA61 RID: 178785 RVA: 0x00A85819 File Offset: 0x00A83A19
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_341, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_341, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007373 RID: 29555
		// (get) Token: 0x0602BA62 RID: 178786 RVA: 0x00A8583C File Offset: 0x00A83A3C
		// (set) Token: 0x0602BA63 RID: 178787 RVA: 0x00A85875 File Offset: 0x00A83A75
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_342, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_342, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007374 RID: 29556
		// (get) Token: 0x0602BA64 RID: 178788 RVA: 0x00A85898 File Offset: 0x00A83A98
		// (set) Token: 0x0602BA65 RID: 178789 RVA: 0x00A858D1 File Offset: 0x00A83AD1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_343, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_343, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007375 RID: 29557
		// (get) Token: 0x0602BA66 RID: 178790 RVA: 0x00A858F4 File Offset: 0x00A83AF4
		// (set) Token: 0x0602BA67 RID: 178791 RVA: 0x00A8592D File Offset: 0x00A83B2D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_344, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_344, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007376 RID: 29558
		// (get) Token: 0x0602BA68 RID: 178792 RVA: 0x00A85950 File Offset: 0x00A83B50
		// (set) Token: 0x0602BA69 RID: 178793 RVA: 0x00A85989 File Offset: 0x00A83B89
		public FAnimNode_MultiWayBlend AnimGraphNode_MultiWayBlend
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_MultiWayBlend result;
				if ((result = this._AnimGraphNode_MultiWayBlend) == null)
				{
					result = (this._AnimGraphNode_MultiWayBlend = new FAnimNode_MultiWayBlend(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_345, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_MultiWayBlend.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_345, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007377 RID: 29559
		// (get) Token: 0x0602BA6A RID: 178794 RVA: 0x00A859AC File Offset: 0x00A83BAC
		// (set) Token: 0x0602BA6B RID: 178795 RVA: 0x00A859E5 File Offset: 0x00A83BE5
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_346, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_346, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007378 RID: 29560
		// (get) Token: 0x0602BA6C RID: 178796 RVA: 0x00A85A08 File Offset: 0x00A83C08
		// (set) Token: 0x0602BA6D RID: 178797 RVA: 0x00A85A41 File Offset: 0x00A83C41
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_347, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_347, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007379 RID: 29561
		// (get) Token: 0x0602BA6E RID: 178798 RVA: 0x00A85A64 File Offset: 0x00A83C64
		// (set) Token: 0x0602BA6F RID: 178799 RVA: 0x00A85A9D File Offset: 0x00A83C9D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_348, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_348, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700737A RID: 29562
		// (get) Token: 0x0602BA70 RID: 178800 RVA: 0x00A85AC0 File Offset: 0x00A83CC0
		// (set) Token: 0x0602BA71 RID: 178801 RVA: 0x00A85AF9 File Offset: 0x00A83CF9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_349, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_349, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700737B RID: 29563
		// (get) Token: 0x0602BA72 RID: 178802 RVA: 0x00A85B1C File Offset: 0x00A83D1C
		// (set) Token: 0x0602BA73 RID: 178803 RVA: 0x00A85B55 File Offset: 0x00A83D55
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_350, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_350, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700737C RID: 29564
		// (get) Token: 0x0602BA74 RID: 178804 RVA: 0x00A85B78 File Offset: 0x00A83D78
		// (set) Token: 0x0602BA75 RID: 178805 RVA: 0x00A85BB1 File Offset: 0x00A83DB1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_351, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_351, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700737D RID: 29565
		// (get) Token: 0x0602BA76 RID: 178806 RVA: 0x00A85BD4 File Offset: 0x00A83DD4
		// (set) Token: 0x0602BA77 RID: 178807 RVA: 0x00A85C0D File Offset: 0x00A83E0D
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_352, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_352, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700737E RID: 29566
		// (get) Token: 0x0602BA78 RID: 178808 RVA: 0x00A85C30 File Offset: 0x00A83E30
		// (set) Token: 0x0602BA79 RID: 178809 RVA: 0x00A85C69 File Offset: 0x00A83E69
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_353, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_353, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700737F RID: 29567
		// (get) Token: 0x0602BA7A RID: 178810 RVA: 0x00A85C8C File Offset: 0x00A83E8C
		// (set) Token: 0x0602BA7B RID: 178811 RVA: 0x00A85CC5 File Offset: 0x00A83EC5
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_354, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_354, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007380 RID: 29568
		// (get) Token: 0x0602BA7C RID: 178812 RVA: 0x00A85CE8 File Offset: 0x00A83EE8
		// (set) Token: 0x0602BA7D RID: 178813 RVA: 0x00A85D21 File Offset: 0x00A83F21
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_355, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_355, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007381 RID: 29569
		// (get) Token: 0x0602BA7E RID: 178814 RVA: 0x00A85D44 File Offset: 0x00A83F44
		// (set) Token: 0x0602BA7F RID: 178815 RVA: 0x00A85D7D File Offset: 0x00A83F7D
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_356, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_356, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007382 RID: 29570
		// (get) Token: 0x0602BA80 RID: 178816 RVA: 0x00A85DA0 File Offset: 0x00A83FA0
		// (set) Token: 0x0602BA81 RID: 178817 RVA: 0x00A85DD9 File Offset: 0x00A83FD9
		public FAnimNode_CurveFix AnimGraphNode_CurveFix
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CurveFix result;
				if ((result = this._AnimGraphNode_CurveFix) == null)
				{
					result = (this._AnimGraphNode_CurveFix = new FAnimNode_CurveFix(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_357, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CurveFix.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_357, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007383 RID: 29571
		// (get) Token: 0x0602BA82 RID: 178818 RVA: 0x00A85DFC File Offset: 0x00A83FFC
		// (set) Token: 0x0602BA83 RID: 178819 RVA: 0x00A85E35 File Offset: 0x00A84035
		public FAnimNode_KuroCacheBones AnimGraphNode_KuroCacheBones
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_KuroCacheBones result;
				if ((result = this._AnimGraphNode_KuroCacheBones) == null)
				{
					result = (this._AnimGraphNode_KuroCacheBones = new FAnimNode_KuroCacheBones(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_358, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_KuroCacheBones.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_358, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007384 RID: 29572
		// (get) Token: 0x0602BA84 RID: 178820 RVA: 0x00A85E58 File Offset: 0x00A84058
		// (set) Token: 0x0602BA85 RID: 178821 RVA: 0x00A85E91 File Offset: 0x00A84091
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_3) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_3 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_359, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_359, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007385 RID: 29573
		// (get) Token: 0x0602BA86 RID: 178822 RVA: 0x00A85EB4 File Offset: 0x00A840B4
		// (set) Token: 0x0602BA87 RID: 178823 RVA: 0x00A85EED File Offset: 0x00A840ED
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_2) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_2 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_360, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_360, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007386 RID: 29574
		// (get) Token: 0x0602BA88 RID: 178824 RVA: 0x00A85F10 File Offset: 0x00A84110
		// (set) Token: 0x0602BA89 RID: 178825 RVA: 0x00A85F49 File Offset: 0x00A84149
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_361, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_361, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007387 RID: 29575
		// (get) Token: 0x0602BA8A RID: 178826 RVA: 0x00A85F6C File Offset: 0x00A8416C
		// (set) Token: 0x0602BA8B RID: 178827 RVA: 0x00A85FA5 File Offset: 0x00A841A5
		public FAnimNode_BlendListByBool AnimGraphNode_BlendListByBool
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendListByBool result;
				if ((result = this._AnimGraphNode_BlendListByBool) == null)
				{
					result = (this._AnimGraphNode_BlendListByBool = new FAnimNode_BlendListByBool(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_362, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendListByBool.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_362, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007388 RID: 29576
		// (get) Token: 0x0602BA8C RID: 178828 RVA: 0x00A85FC8 File Offset: 0x00A841C8
		// (set) Token: 0x0602BA8D RID: 178829 RVA: 0x00A86001 File Offset: 0x00A84201
		public FAnimNode_PoseSnapshot AnimGraphNode_PoseSnapshot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_PoseSnapshot result;
				if ((result = this._AnimGraphNode_PoseSnapshot) == null)
				{
					result = (this._AnimGraphNode_PoseSnapshot = new FAnimNode_PoseSnapshot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_363, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_PoseSnapshot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_363, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007389 RID: 29577
		// (get) Token: 0x0602BA8E RID: 178830 RVA: 0x00A86024 File Offset: 0x00A84224
		// (set) Token: 0x0602BA8F RID: 178831 RVA: 0x00A8605D File Offset: 0x00A8425D
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_364, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_364, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700738A RID: 29578
		// (get) Token: 0x0602BA90 RID: 178832 RVA: 0x00A8607E File Offset: 0x00A8427E
		// (set) Token: 0x0602BA91 RID: 178833 RVA: 0x00A86092 File Offset: 0x00A84292
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_365);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_365, value);
			}
		}

		// Token: 0x1700738B RID: 29579
		// (get) Token: 0x0602BA92 RID: 178834 RVA: 0x00A860A7 File Offset: 0x00A842A7
		// (set) Token: 0x0602BA93 RID: 178835 RVA: 0x00A860B7 File Offset: 0x00A842B7
		public unsafe float DeltaTimeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_366);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_366) = value;
			}
		}

		// Token: 0x1700738C RID: 29580
		// (get) Token: 0x0602BA94 RID: 178836 RVA: 0x00A860C8 File Offset: 0x00A842C8
		// (set) Token: 0x0602BA95 RID: 178837 RVA: 0x00A860DC File Offset: 0x00A842DC
		public unsafe FVector 速度向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_367);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_367) = value;
			}
		}

		// Token: 0x1700738D RID: 29581
		// (get) Token: 0x0602BA96 RID: 178838 RVA: 0x00A860F1 File Offset: 0x00A842F1
		// (set) Token: 0x0602BA97 RID: 178839 RVA: 0x00A86105 File Offset: 0x00A84305
		public unsafe FVector 加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_368);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_368) = value;
			}
		}

		// Token: 0x1700738E RID: 29582
		// (get) Token: 0x0602BA98 RID: 178840 RVA: 0x00A8611A File Offset: 0x00A8431A
		// (set) Token: 0x0602BA99 RID: 178841 RVA: 0x00A8612E File Offset: 0x00A8432E
		public unsafe FVector 移动输入向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_369);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_369) = value;
			}
		}

		// Token: 0x1700738F RID: 29583
		// (get) Token: 0x0602BA9A RID: 178842 RVA: 0x00A86143 File Offset: 0x00A84343
		// (set) Token: 0x0602BA9B RID: 178843 RVA: 0x00A86153 File Offset: 0x00A84353
		public unsafe bool 是否正在移动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_370) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_370) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007390 RID: 29584
		// (get) Token: 0x0602BA9C RID: 178844 RVA: 0x00A86164 File Offset: 0x00A84364
		// (set) Token: 0x0602BA9D RID: 178845 RVA: 0x00A86174 File Offset: 0x00A84374
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_371) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_371) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007391 RID: 29585
		// (get) Token: 0x0602BA9E RID: 178846 RVA: 0x00A86185 File Offset: 0x00A84385
		// (set) Token: 0x0602BA9F RID: 178847 RVA: 0x00A86195 File Offset: 0x00A84395
		public unsafe float 速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_372);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_372) = value;
			}
		}

		// Token: 0x17007392 RID: 29586
		// (get) Token: 0x0602BAA0 RID: 178848 RVA: 0x00A861A6 File Offset: 0x00A843A6
		// (set) Token: 0x0602BAA1 RID: 178849 RVA: 0x00A861BA File Offset: 0x00A843BA
		public unsafe FRotator 瞄准旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_373);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_373) = value;
			}
		}

		// Token: 0x17007393 RID: 29587
		// (get) Token: 0x0602BAA2 RID: 178850 RVA: 0x00A861CF File Offset: 0x00A843CF
		// (set) Token: 0x0602BAA3 RID: 178851 RVA: 0x00A861DF File Offset: 0x00A843DF
		public unsafe bool 是否将要移动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_374) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_374) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007394 RID: 29588
		// (get) Token: 0x0602BAA4 RID: 178852 RVA: 0x00A861F0 File Offset: 0x00A843F0
		// (set) Token: 0x0602BAA5 RID: 178853 RVA: 0x00A86200 File Offset: 0x00A84400
		public unsafe bool 正在旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_375) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_375) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007395 RID: 29589
		// (get) Token: 0x0602BAA6 RID: 178854 RVA: 0x00A86211 File Offset: 0x00A84411
		// (set) Token: 0x0602BAA7 RID: 178855 RVA: 0x00A86221 File Offset: 0x00A84421
		public unsafe float 旋转速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_376);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_376) = value;
			}
		}

		// Token: 0x17007396 RID: 29590
		// (get) Token: 0x0602BAA8 RID: 178856 RVA: 0x00A86232 File Offset: 0x00A84432
		// (set) Token: 0x0602BAA9 RID: 178857 RVA: 0x00A86242 File Offset: 0x00A84442
		public unsafe float 旋转混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_377);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_377) = value;
			}
		}

		// Token: 0x17007397 RID: 29591
		// (get) Token: 0x0602BAAA RID: 178858 RVA: 0x00A86253 File Offset: 0x00A84453
		// (set) Token: 0x0602BAAB RID: 178859 RVA: 0x00A86267 File Offset: 0x00A84467
		public unsafe FVeloctiyBlend 速度混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_378);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_378) = value;
			}
		}

		// Token: 0x17007398 RID: 29592
		// (get) Token: 0x0602BAAC RID: 178860 RVA: 0x00A8627C File Offset: 0x00A8447C
		// (set) Token: 0x0602BAAD RID: 178861 RVA: 0x00A86290 File Offset: 0x00A84490
		public unsafe FVector 相对加速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_379);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_379) = value;
			}
		}

		// Token: 0x17007399 RID: 29593
		// (get) Token: 0x0602BAAE RID: 178862 RVA: 0x00A862A8 File Offset: 0x00A844A8
		// (set) Token: 0x0602BAAF RID: 178863 RVA: 0x00A862E1 File Offset: 0x00A844E1
		public FLeanAmount 倾斜量
		{
			get
			{
				base.FastCheckIsValid();
				FLeanAmount result;
				if ((result = this._倾斜量) == null)
				{
					result = (this._倾斜量 = new FLeanAmount(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_380, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FLeanAmount.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_380, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700739A RID: 29594
		// (get) Token: 0x0602BAB0 RID: 178864 RVA: 0x00A86302 File Offset: 0x00A84502
		// (set) Token: 0x0602BAB1 RID: 178865 RVA: 0x00A86312 File Offset: 0x00A84512
		public unsafe float 地上倾斜量平滑速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_381);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_381) = value;
			}
		}

		// Token: 0x1700739B RID: 29595
		// (get) Token: 0x0602BAB2 RID: 178866 RVA: 0x00A86323 File Offset: 0x00A84523
		// (set) Token: 0x0602BAB3 RID: 178867 RVA: 0x00A86337 File Offset: 0x00A84537
		[Nullable(0)]
		public unsafe TEnumAsByte<EMovementDirection> 移动方向
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_382);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_382) = value;
			}
		}

		// Token: 0x1700739C RID: 29596
		// (get) Token: 0x0602BAB4 RID: 178868 RVA: 0x00A8634C File Offset: 0x00A8454C
		// (set) Token: 0x0602BAB5 RID: 178869 RVA: 0x00A8635C File Offset: 0x00A8455C
		public unsafe float 站立播放速率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_383);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_383) = value;
			}
		}

		// Token: 0x1700739D RID: 29597
		// (get) Token: 0x0602BAB6 RID: 178870 RVA: 0x00A8636D File Offset: 0x00A8456D
		// (set) Token: 0x0602BAB7 RID: 178871 RVA: 0x00A8637D File Offset: 0x00A8457D
		public unsafe float 走跑混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_384);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_384) = value;
			}
		}

		// Token: 0x1700739E RID: 29598
		// (get) Token: 0x0602BAB8 RID: 178872 RVA: 0x00A8638E File Offset: 0x00A8458E
		// (set) Token: 0x0602BAB9 RID: 178873 RVA: 0x00A863A2 File Offset: 0x00A845A2
		[Nullable(2)]
		public unsafe UCurveFloat 站立走步幅混合曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_385);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_385, value);
			}
		}

		// Token: 0x1700739F RID: 29599
		// (get) Token: 0x0602BABA RID: 178874 RVA: 0x00A863B7 File Offset: 0x00A845B7
		// (set) Token: 0x0602BABB RID: 178875 RVA: 0x00A863CB File Offset: 0x00A845CB
		[Nullable(2)]
		public unsafe UCurveFloat 站立跑步幅混合曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_386);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_386, value);
			}
		}

		// Token: 0x170073A0 RID: 29600
		// (get) Token: 0x0602BABC RID: 178876 RVA: 0x00A863E0 File Offset: 0x00A845E0
		// (set) Token: 0x0602BABD RID: 178877 RVA: 0x00A863F0 File Offset: 0x00A845F0
		public unsafe float 步幅混合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_387);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_387) = value;
			}
		}

		// Token: 0x170073A1 RID: 29601
		// (get) Token: 0x0602BABE RID: 178878 RVA: 0x00A86401 File Offset: 0x00A84601
		// (set) Token: 0x0602BABF RID: 178879 RVA: 0x00A86411 File Offset: 0x00A84611
		public unsafe float 动画行走速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_388);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_388) = value;
			}
		}

		// Token: 0x170073A2 RID: 29602
		// (get) Token: 0x0602BAC0 RID: 178880 RVA: 0x00A86422 File Offset: 0x00A84622
		// (set) Token: 0x0602BAC1 RID: 178881 RVA: 0x00A86432 File Offset: 0x00A84632
		public unsafe float 动画跑步速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_389);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_389) = value;
			}
		}

		// Token: 0x170073A3 RID: 29603
		// (get) Token: 0x0602BAC2 RID: 178882 RVA: 0x00A86443 File Offset: 0x00A84643
		// (set) Token: 0x0602BAC3 RID: 178883 RVA: 0x00A86453 File Offset: 0x00A84653
		public unsafe float 动画疾跑速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_390);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_390) = value;
			}
		}

		// Token: 0x170073A4 RID: 29604
		// (get) Token: 0x0602BAC4 RID: 178884 RVA: 0x00A86464 File Offset: 0x00A84664
		// (set) Token: 0x0602BAC5 RID: 178885 RVA: 0x00A86478 File Offset: 0x00A84678
		[Nullable(2)]
		public unsafe UCurveFloat RelativeSpeedBlendCurve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_391);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_391, value);
			}
		}

		// Token: 0x170073A5 RID: 29605
		// (get) Token: 0x0602BAC6 RID: 178886 RVA: 0x00A8648D File Offset: 0x00A8468D
		// (set) Token: 0x0602BAC7 RID: 178887 RVA: 0x00A864A1 File Offset: 0x00A846A1
		public unsafe FVector 整体偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_392);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_392) = value;
			}
		}

		// Token: 0x170073A6 RID: 29606
		// (get) Token: 0x0602BAC8 RID: 178888 RVA: 0x00A864B6 File Offset: 0x00A846B6
		// (set) Token: 0x0602BAC9 RID: 178889 RVA: 0x00A864CA File Offset: 0x00A846CA
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_393);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_393, value);
			}
		}

		// Token: 0x170073A7 RID: 29607
		// (get) Token: 0x0602BACA RID: 178890 RVA: 0x00A864DF File Offset: 0x00A846DF
		// (set) Token: 0x0602BACB RID: 178891 RVA: 0x00A864F3 File Offset: 0x00A846F3
		public unsafe FVector 整体偏移_实际使用_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_394);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_394) = value;
			}
		}

		// Token: 0x170073A8 RID: 29608
		// (get) Token: 0x0602BACC RID: 178892 RVA: 0x00A86508 File Offset: 0x00A84708
		// (set) Token: 0x0602BACD RID: 178893 RVA: 0x00A8651C File Offset: 0x00A8471C
		public unsafe FVector 上一帧模型位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_395);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_395) = value;
			}
		}

		// Token: 0x170073A9 RID: 29609
		// (get) Token: 0x0602BACE RID: 178894 RVA: 0x00A86531 File Offset: 0x00A84731
		// (set) Token: 0x0602BACF RID: 178895 RVA: 0x00A86541 File Offset: 0x00A84741
		public unsafe bool IsAutonomousProxy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_396) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_396) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073AA RID: 29610
		// (get) Token: 0x0602BAD0 RID: 178896 RVA: 0x00A86552 File Offset: 0x00A84752
		// (set) Token: 0x0602BAD1 RID: 178897 RVA: 0x00A86562 File Offset: 0x00A84762
		public unsafe float 瞄准面向
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_397);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_397) = value;
			}
		}

		// Token: 0x170073AB RID: 29611
		// (get) Token: 0x0602BAD2 RID: 178898 RVA: 0x00A86573 File Offset: 0x00A84773
		// (set) Token: 0x0602BAD3 RID: 178899 RVA: 0x00A86583 File Offset: 0x00A84783
		public unsafe float 瞄准仰角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_398);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_398) = value;
			}
		}

		// Token: 0x170073AC RID: 29612
		// (get) Token: 0x0602BAD4 RID: 178900 RVA: 0x00A86594 File Offset: 0x00A84794
		// (set) Token: 0x0602BAD5 RID: 178901 RVA: 0x00A865A4 File Offset: 0x00A847A4
		public unsafe float 当前坡度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_399);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_399) = value;
			}
		}

		// Token: 0x170073AD RID: 29613
		// (get) Token: 0x0602BAD6 RID: 178902 RVA: 0x00A865B5 File Offset: 0x00A847B5
		// (set) Token: 0x0602BAD7 RID: 178903 RVA: 0x00A865C5 File Offset: 0x00A847C5
		public unsafe float 视线修正Alpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_400);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_400) = value;
			}
		}

		// Token: 0x170073AE RID: 29614
		// (get) Token: 0x0602BAD8 RID: 178904 RVA: 0x00A865D6 File Offset: 0x00A847D6
		// (set) Token: 0x0602BAD9 RID: 178905 RVA: 0x00A865EA File Offset: 0x00A847EA
		public unsafe FVector 看向位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_401);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_401) = value;
			}
		}

		// Token: 0x170073AF RID: 29615
		// (get) Token: 0x0602BADA RID: 178906 RVA: 0x00A865FF File Offset: 0x00A847FF
		// (set) Token: 0x0602BADB RID: 178907 RVA: 0x00A8660F File Offset: 0x00A8480F
		public unsafe float CachePercent_LR
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_402);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_402) = value;
			}
		}

		// Token: 0x170073B0 RID: 29616
		// (get) Token: 0x0602BADC RID: 178908 RVA: 0x00A86620 File Offset: 0x00A84820
		// (set) Token: 0x0602BADD RID: 178909 RVA: 0x00A86630 File Offset: 0x00A84830
		public unsafe float CachePercent_FB
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_403);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_403) = value;
			}
		}

		// Token: 0x170073B1 RID: 29617
		// (get) Token: 0x0602BADE RID: 178910 RVA: 0x00A86641 File Offset: 0x00A84841
		// (set) Token: 0x0602BADF RID: 178911 RVA: 0x00A86655 File Offset: 0x00A84855
		public unsafe FVector 角色向前向量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_404);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_404) = value;
			}
		}

		// Token: 0x170073B2 RID: 29618
		// (get) Token: 0x0602BAE0 RID: 178912 RVA: 0x00A8666A File Offset: 0x00A8486A
		// (set) Token: 0x0602BAE1 RID: 178913 RVA: 0x00A8667E File Offset: 0x00A8487E
		public unsafe FVector 外部方向输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_405);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_405) = value;
			}
		}

		// Token: 0x170073B3 RID: 29619
		// (get) Token: 0x0602BAE2 RID: 178914 RVA: 0x00A86693 File Offset: 0x00A84893
		// (set) Token: 0x0602BAE3 RID: 178915 RVA: 0x00A866A3 File Offset: 0x00A848A3
		public unsafe bool 是否需要原地转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_406) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_406) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073B4 RID: 29620
		// (get) Token: 0x0602BAE4 RID: 178916 RVA: 0x00A866B4 File Offset: 0x00A848B4
		// (set) Token: 0x0602BAE5 RID: 178917 RVA: 0x00A866C4 File Offset: 0x00A848C4
		public unsafe bool 右转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_407) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_407) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073B5 RID: 29621
		// (get) Token: 0x0602BAE6 RID: 178918 RVA: 0x00A866D5 File Offset: 0x00A848D5
		// (set) Token: 0x0602BAE7 RID: 178919 RVA: 0x00A866E5 File Offset: 0x00A848E5
		public unsafe bool 状态_跑停
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_408) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_408) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073B6 RID: 29622
		// (get) Token: 0x0602BAE8 RID: 178920 RVA: 0x00A866F6 File Offset: 0x00A848F6
		// (set) Token: 0x0602BAE9 RID: 178921 RVA: 0x00A86706 File Offset: 0x00A84906
		public unsafe bool 状态_跑停_RunStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_409) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_409) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073B7 RID: 29623
		// (get) Token: 0x0602BAEA RID: 178922 RVA: 0x00A86717 File Offset: 0x00A84917
		// (set) Token: 0x0602BAEB RID: 178923 RVA: 0x00A86727 File Offset: 0x00A84927
		public unsafe bool 状态_跑停_SprintStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_410) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_410) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073B8 RID: 29624
		// (get) Token: 0x0602BAEC RID: 178924 RVA: 0x00A86738 File Offset: 0x00A84938
		// (set) Token: 0x0602BAED RID: 178925 RVA: 0x00A86748 File Offset: 0x00A84948
		public unsafe bool 状态_跑停_WalkStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_411) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_411) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073B9 RID: 29625
		// (get) Token: 0x0602BAEE RID: 178926 RVA: 0x00A86759 File Offset: 0x00A84959
		// (set) Token: 0x0602BAEF RID: 178927 RVA: 0x00A86769 File Offset: 0x00A84969
		public unsafe bool 状态_地面_Sprint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_412) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_412) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073BA RID: 29626
		// (get) Token: 0x0602BAF0 RID: 178928 RVA: 0x00A8677A File Offset: 0x00A8497A
		// (set) Token: 0x0602BAF1 RID: 178929 RVA: 0x00A8678A File Offset: 0x00A8498A
		public unsafe bool 状态_地面_Walk
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_413) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_413) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073BB RID: 29627
		// (get) Token: 0x0602BAF2 RID: 178930 RVA: 0x00A8679B File Offset: 0x00A8499B
		// (set) Token: 0x0602BAF3 RID: 178931 RVA: 0x00A867AB File Offset: 0x00A849AB
		public unsafe bool 状态_地面_Run
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_414) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_414) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073BC RID: 29628
		// (get) Token: 0x0602BAF4 RID: 178932 RVA: 0x00A867BC File Offset: 0x00A849BC
		// (set) Token: 0x0602BAF5 RID: 178933 RVA: 0x00A867CC File Offset: 0x00A849CC
		public unsafe bool 状态_牵手_牵手中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_415) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_415) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073BD RID: 29629
		// (get) Token: 0x0602BAF6 RID: 178934 RVA: 0x00A867DD File Offset: 0x00A849DD
		// (set) Token: 0x0602BAF7 RID: 178935 RVA: 0x00A867ED File Offset: 0x00A849ED
		public unsafe bool 状态_牵手_被牵手中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_416) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_416) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073BE RID: 29630
		// (get) Token: 0x0602BAF8 RID: 178936 RVA: 0x00A867FE File Offset: 0x00A849FE
		// (set) Token: 0x0602BAF9 RID: 178937 RVA: 0x00A8680E File Offset: 0x00A84A0E
		public unsafe bool 状态_牵手_范围内
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_417) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_417) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073BF RID: 29631
		// (get) Token: 0x0602BAFA RID: 178938 RVA: 0x00A8681F File Offset: 0x00A84A1F
		// (set) Token: 0x0602BAFB RID: 178939 RVA: 0x00A8682F File Offset: 0x00A84A2F
		public unsafe bool 状态_牵手_接受邀请中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_418) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_418) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073C0 RID: 29632
		// (get) Token: 0x0602BAFC RID: 178940 RVA: 0x00A86840 File Offset: 0x00A84A40
		// (set) Token: 0x0602BAFD RID: 178941 RVA: 0x00A86854 File Offset: 0x00A84A54
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharState> CharMoveState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_419);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_419) = value;
			}
		}

		// Token: 0x170073C1 RID: 29633
		// (get) Token: 0x0602BAFE RID: 178942 RVA: 0x00A86869 File Offset: 0x00A84A69
		// (set) Token: 0x0602BAFF RID: 178943 RVA: 0x00A86879 File Offset: 0x00A84A79
		public unsafe float ExpresionAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_420);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_420) = value;
			}
		}

		// Token: 0x170073C2 RID: 29634
		// (get) Token: 0x0602BB00 RID: 178944 RVA: 0x00A8688A File Offset: 0x00A84A8A
		// (set) Token: 0x0602BB01 RID: 178945 RVA: 0x00A8689A File Offset: 0x00A84A9A
		public unsafe float RandomEpresionEndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_421);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_421) = value;
			}
		}

		// Token: 0x170073C3 RID: 29635
		// (get) Token: 0x0602BB02 RID: 178946 RVA: 0x00A868AB File Offset: 0x00A84AAB
		// (set) Token: 0x0602BB03 RID: 178947 RVA: 0x00A868BB File Offset: 0x00A84ABB
		public unsafe float 眨眼动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_422);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_422) = value;
			}
		}

		// Token: 0x170073C4 RID: 29636
		// (get) Token: 0x0602BB04 RID: 178948 RVA: 0x00A868CC File Offset: 0x00A84ACC
		// (set) Token: 0x0602BB05 RID: 178949 RVA: 0x00A868DC File Offset: 0x00A84ADC
		public unsafe float 此轮眨眼动画总时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_423);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_423) = value;
			}
		}

		// Token: 0x170073C5 RID: 29637
		// (get) Token: 0x0602BB06 RID: 178950 RVA: 0x00A868ED File Offset: 0x00A84AED
		// (set) Token: 0x0602BB07 RID: 178951 RVA: 0x00A86901 File Offset: 0x00A84B01
		public unsafe FRotator 角色旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_424);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_424) = value;
			}
		}

		// Token: 0x170073C6 RID: 29638
		// (get) Token: 0x0602BB08 RID: 178952 RVA: 0x00A86916 File Offset: 0x00A84B16
		// (set) Token: 0x0602BB09 RID: 178953 RVA: 0x00A86926 File Offset: 0x00A84B26
		public unsafe float 原地旋转偏差角
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_425);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_425) = value;
			}
		}

		// Token: 0x170073C7 RID: 29639
		// (get) Token: 0x0602BB0A RID: 178954 RVA: 0x00A86937 File Offset: 0x00A84B37
		// (set) Token: 0x0602BB0B RID: 178955 RVA: 0x00A86947 File Offset: 0x00A84B47
		public unsafe bool 移动时是否有阻挡
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_426) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_426) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073C8 RID: 29640
		// (get) Token: 0x0602BB0C RID: 178956 RVA: 0x00A86958 File Offset: 0x00A84B58
		// (set) Token: 0x0602BB0D RID: 178957 RVA: 0x00A86968 File Offset: 0x00A84B68
		public unsafe float TimeSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_427);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_427) = value;
			}
		}

		// Token: 0x170073C9 RID: 29641
		// (get) Token: 0x0602BB0E RID: 178958 RVA: 0x00A86979 File Offset: 0x00A84B79
		// (set) Token: 0x0602BB0F RID: 178959 RVA: 0x00A86989 File Offset: 0x00A84B89
		public unsafe float InSequenceAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_428);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_428) = value;
			}
		}

		// Token: 0x170073CA RID: 29642
		// (get) Token: 0x0602BB10 RID: 178960 RVA: 0x00A8699A File Offset: 0x00A84B9A
		// (set) Token: 0x0602BB11 RID: 178961 RVA: 0x00A869AE File Offset: 0x00A84BAE
		public unsafe FVector 缓存角色位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_429);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_429) = value;
			}
		}

		// Token: 0x170073CB RID: 29643
		// (get) Token: 0x0602BB12 RID: 178962 RVA: 0x00A869C3 File Offset: 0x00A84BC3
		// (set) Token: 0x0602BB13 RID: 178963 RVA: 0x00A869D7 File Offset: 0x00A84BD7
		[Nullable(2)]
		public unsafe UCurveFloat AngelToStepLength
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_430);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_430, value);
			}
		}

		// Token: 0x170073CC RID: 29644
		// (get) Token: 0x0602BB14 RID: 178964 RVA: 0x00A869EC File Offset: 0x00A84BEC
		// (set) Token: 0x0602BB15 RID: 178965 RVA: 0x00A86A00 File Offset: 0x00A84C00
		[Nullable(2)]
		public unsafe UCurveFloat Angle_to_Step_Frequency
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_431);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_431, value);
			}
		}

		// Token: 0x170073CD RID: 29645
		// (get) Token: 0x0602BB16 RID: 178966 RVA: 0x00A86A15 File Offset: 0x00A84C15
		// (set) Token: 0x0602BB17 RID: 178967 RVA: 0x00A86A29 File Offset: 0x00A84C29
		public unsafe FRotator 综合旋转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_432);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_432) = value;
			}
		}

		// Token: 0x170073CE RID: 29646
		// (get) Token: 0x0602BB18 RID: 178968 RVA: 0x00A86A3E File Offset: 0x00A84C3E
		// (set) Token: 0x0602BB19 RID: 178969 RVA: 0x00A86A52 File Offset: 0x00A84C52
		public unsafe FVector 上一帧位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_433);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_433) = value;
			}
		}

		// Token: 0x170073CF RID: 29647
		// (get) Token: 0x0602BB1A RID: 178970 RVA: 0x00A86A67 File Offset: 0x00A84C67
		// (set) Token: 0x0602BB1B RID: 178971 RVA: 0x00A86A77 File Offset: 0x00A84C77
		public unsafe float 角色位移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_434);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_434) = value;
			}
		}

		// Token: 0x170073D0 RID: 29648
		// (get) Token: 0x0602BB1C RID: 178972 RVA: 0x00A86A88 File Offset: 0x00A84C88
		// (set) Token: 0x0602BB1D RID: 178973 RVA: 0x00A86A98 File Offset: 0x00A84C98
		public unsafe bool 眨眼中
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_435) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_435) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073D1 RID: 29649
		// (get) Token: 0x0602BB1E RID: 178974 RVA: 0x00A86AA9 File Offset: 0x00A84CA9
		// (set) Token: 0x0602BB1F RID: 178975 RVA: 0x00A86AB9 File Offset: 0x00A84CB9
		public unsafe int 身高
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_436);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_436) = value;
			}
		}

		// Token: 0x170073D2 RID: 29650
		// (get) Token: 0x0602BB20 RID: 178976 RVA: 0x00A86ACA File Offset: 0x00A84CCA
		// (set) Token: 0x0602BB21 RID: 178977 RVA: 0x00A86ADA File Offset: 0x00A84CDA
		public unsafe bool bComponentStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_437) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_437) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073D3 RID: 29651
		// (get) Token: 0x0602BB22 RID: 178978 RVA: 0x00A86AEB File Offset: 0x00A84CEB
		// (set) Token: 0x0602BB23 RID: 178979 RVA: 0x00A86AFF File Offset: 0x00A84CFF
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharParentMoveState> CharPositionState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_438);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_438) = value;
			}
		}

		// Token: 0x170073D4 RID: 29652
		// (get) Token: 0x0602BB24 RID: 178980 RVA: 0x00A86B14 File Offset: 0x00A84D14
		// (set) Token: 0x0602BB25 RID: 178981 RVA: 0x00A86B28 File Offset: 0x00A84D28
		[Nullable(0)]
		public unsafe TEnumAsByte<ECharViewDirectionState> CharCameraState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_439);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_439) = value;
			}
		}

		// Token: 0x170073D5 RID: 29653
		// (get) Token: 0x0602BB26 RID: 178982 RVA: 0x00A86B3D File Offset: 0x00A84D3D
		// (set) Token: 0x0602BB27 RID: 178983 RVA: 0x00A86B51 File Offset: 0x00A84D51
		[Nullable(0)]
		public unsafe TEnumAsByte<ESwim> 泳态
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_440);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_440) = value;
			}
		}

		// Token: 0x170073D6 RID: 29654
		// (get) Token: 0x0602BB28 RID: 178984 RVA: 0x00A86B66 File Offset: 0x00A84D66
		// (set) Token: 0x0602BB29 RID: 178985 RVA: 0x00A86B7A File Offset: 0x00A84D7A
		[Nullable(2)]
		public unsafe BP_ABPLogicParams_C Ts逻辑变量集
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_ABPLogicParams_C>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_441);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRoleNPC_C.__PropertyOffset_441, value);
			}
		}

		// Token: 0x170073D7 RID: 29655
		// (get) Token: 0x0602BB2A RID: 178986 RVA: 0x00A86B8F File Offset: 0x00A84D8F
		// (set) Token: 0x0602BB2B RID: 178987 RVA: 0x00A86B9F File Offset: 0x00A84D9F
		public unsafe bool 不进行_IK_Lerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_442) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_442) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073D8 RID: 29656
		// (get) Token: 0x0602BB2C RID: 178988 RVA: 0x00A86BB0 File Offset: 0x00A84DB0
		// (set) Token: 0x0602BB2D RID: 178989 RVA: 0x00A86BC0 File Offset: 0x00A84DC0
		public unsafe KuroHumanIKMode IK模式
		{
			get
			{
				return (KuroHumanIKMode)(*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_443));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_443) = (byte)value;
			}
		}

		// Token: 0x170073D9 RID: 29657
		// (get) Token: 0x0602BB2E RID: 178990 RVA: 0x00A86BD1 File Offset: 0x00A84DD1
		// (set) Token: 0x0602BB2F RID: 178991 RVA: 0x00A86BE1 File Offset: 0x00A84DE1
		public unsafe bool 使用混合空间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_444) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_444) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073DA RID: 29658
		// (get) Token: 0x0602BB30 RID: 178992 RVA: 0x00A86BF2 File Offset: 0x00A84DF2
		// (set) Token: 0x0602BB31 RID: 178993 RVA: 0x00A86C06 File Offset: 0x00A84E06
		public unsafe FVector2D 看向角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_445);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_445) = value;
			}
		}

		// Token: 0x170073DB RID: 29659
		// (get) Token: 0x0602BB32 RID: 178994 RVA: 0x00A86C1B File Offset: 0x00A84E1B
		// (set) Token: 0x0602BB33 RID: 178995 RVA: 0x00A86C2F File Offset: 0x00A84E2F
		public unsafe FVector4 VehicleCollisionMix
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_446);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_446) = value;
			}
		}

		// Token: 0x170073DC RID: 29660
		// (get) Token: 0x0602BB34 RID: 178996 RVA: 0x00A86C44 File Offset: 0x00A84E44
		// (set) Token: 0x0602BB35 RID: 178997 RVA: 0x00A86C54 File Offset: 0x00A84E54
		public unsafe bool IsVehicleImpact
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_447) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_447) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073DD RID: 29661
		// (get) Token: 0x0602BB36 RID: 178998 RVA: 0x00A86C65 File Offset: 0x00A84E65
		// (set) Token: 0x0602BB37 RID: 178999 RVA: 0x00A86C79 File Offset: 0x00A84E79
		public unsafe FRotator VehicleSeatRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_448);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_448) = value;
			}
		}

		// Token: 0x170073DE RID: 29662
		// (get) Token: 0x0602BB38 RID: 179000 RVA: 0x00A86C8E File Offset: 0x00A84E8E
		// (set) Token: 0x0602BB39 RID: 179001 RVA: 0x00A86C9E File Offset: 0x00A84E9E
		public unsafe float VehicleCollisionAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_449);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_449) = value;
			}
		}

		// Token: 0x170073DF RID: 29663
		// (get) Token: 0x0602BB3A RID: 179002 RVA: 0x00A86CAF File Offset: 0x00A84EAF
		// (set) Token: 0x0602BB3B RID: 179003 RVA: 0x00A86CBF File Offset: 0x00A84EBF
		public unsafe float VehicleCollisionStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_450);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_450) = value;
			}
		}

		// Token: 0x170073E0 RID: 29664
		// (get) Token: 0x0602BB3C RID: 179004 RVA: 0x00A86CD0 File Offset: 0x00A84ED0
		// (set) Token: 0x0602BB3D RID: 179005 RVA: 0x00A86CE0 File Offset: 0x00A84EE0
		public unsafe float VehicleCollisionAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_451);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_451) = value;
			}
		}

		// Token: 0x170073E1 RID: 29665
		// (get) Token: 0x0602BB3E RID: 179006 RVA: 0x00A86CF1 File Offset: 0x00A84EF1
		// (set) Token: 0x0602BB3F RID: 179007 RVA: 0x00A86D01 File Offset: 0x00A84F01
		public unsafe bool SuddenMoveTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_452) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_452) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073E2 RID: 29666
		// (get) Token: 0x0602BB40 RID: 179008 RVA: 0x00A86D12 File Offset: 0x00A84F12
		// (set) Token: 0x0602BB41 RID: 179009 RVA: 0x00A86D26 File Offset: 0x00A84F26
		public unsafe FVector4 VehicleSuddenMoveMix
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_453);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_453) = value;
			}
		}

		// Token: 0x170073E3 RID: 29667
		// (get) Token: 0x0602BB42 RID: 179010 RVA: 0x00A86D3B File Offset: 0x00A84F3B
		// (set) Token: 0x0602BB43 RID: 179011 RVA: 0x00A86D4B File Offset: 0x00A84F4B
		public unsafe float CurForwardSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_454);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_454) = value;
			}
		}

		// Token: 0x170073E4 RID: 29668
		// (get) Token: 0x0602BB44 RID: 179012 RVA: 0x00A86D5C File Offset: 0x00A84F5C
		// (set) Token: 0x0602BB45 RID: 179013 RVA: 0x00A86D6C File Offset: 0x00A84F6C
		public unsafe float LastForwardSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_455);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_455) = value;
			}
		}

		// Token: 0x170073E5 RID: 29669
		// (get) Token: 0x0602BB46 RID: 179014 RVA: 0x00A86D7D File Offset: 0x00A84F7D
		// (set) Token: 0x0602BB47 RID: 179015 RVA: 0x00A86D8D File Offset: 0x00A84F8D
		public unsafe float CurSeatRoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_456);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_456) = value;
			}
		}

		// Token: 0x170073E6 RID: 29670
		// (get) Token: 0x0602BB48 RID: 179016 RVA: 0x00A86D9E File Offset: 0x00A84F9E
		// (set) Token: 0x0602BB49 RID: 179017 RVA: 0x00A86DAE File Offset: 0x00A84FAE
		public unsafe float SuddenMoveCd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_457);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_457) = value;
			}
		}

		// Token: 0x170073E7 RID: 29671
		// (get) Token: 0x0602BB4A RID: 179018 RVA: 0x00A86DBF File Offset: 0x00A84FBF
		// (set) Token: 0x0602BB4B RID: 179019 RVA: 0x00A86DCF File Offset: 0x00A84FCF
		public unsafe bool SuddenStopTrigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_458) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_458) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073E8 RID: 29672
		// (get) Token: 0x0602BB4C RID: 179020 RVA: 0x00A86DE0 File Offset: 0x00A84FE0
		// (set) Token: 0x0602BB4D RID: 179021 RVA: 0x00A86DF0 File Offset: 0x00A84FF0
		public unsafe float LastSeatRoll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_459);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_459) = value;
			}
		}

		// Token: 0x170073E9 RID: 29673
		// (get) Token: 0x0602BB4E RID: 179022 RVA: 0x00A86E01 File Offset: 0x00A85001
		// (set) Token: 0x0602BB4F RID: 179023 RVA: 0x00A86E11 File Offset: 0x00A85011
		public unsafe bool EnableSwitchPose
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_460) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_460) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073EA RID: 29674
		// (get) Token: 0x0602BB50 RID: 179024 RVA: 0x00A86E24 File Offset: 0x00A85024
		// (set) Token: 0x0602BB51 RID: 179025 RVA: 0x00A86E5D File Offset: 0x00A8505D
		public FPoseSnapshot CachePose
		{
			get
			{
				base.FastCheckIsValid();
				FPoseSnapshot result;
				if ((result = this._CachePose) == null)
				{
					result = (this._CachePose = new FPoseSnapshot(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_461, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseSnapshot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_461, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170073EB RID: 29675
		// (get) Token: 0x0602BB52 RID: 179026 RVA: 0x00A86E7E File Offset: 0x00A8507E
		// (set) Token: 0x0602BB53 RID: 179027 RVA: 0x00A86E8E File Offset: 0x00A8508E
		public unsafe float SwitchPoseTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_462);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_462) = value;
			}
		}

		// Token: 0x170073EC RID: 29676
		// (get) Token: 0x0602BB54 RID: 179028 RVA: 0x00A86E9F File Offset: 0x00A8509F
		// (set) Token: 0x0602BB55 RID: 179029 RVA: 0x00A86EAF File Offset: 0x00A850AF
		public unsafe bool IsInPlotBlend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_463) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_463) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073ED RID: 29677
		// (get) Token: 0x0602BB56 RID: 179030 RVA: 0x00A86EC0 File Offset: 0x00A850C0
		// (set) Token: 0x0602BB57 RID: 179031 RVA: 0x00A86ED0 File Offset: 0x00A850D0
		public unsafe bool 状态_叠加层_手臂叠加层左手
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_464) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_464) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073EE RID: 29678
		// (get) Token: 0x0602BB58 RID: 179032 RVA: 0x00A86EE1 File Offset: 0x00A850E1
		// (set) Token: 0x0602BB59 RID: 179033 RVA: 0x00A86EF1 File Offset: 0x00A850F1
		public unsafe bool 状态_叠加层_手臂叠加层右手
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_465) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_465) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073EF RID: 29679
		// (get) Token: 0x0602BB5A RID: 179034 RVA: 0x00A86F02 File Offset: 0x00A85102
		// (set) Token: 0x0602BB5B RID: 179035 RVA: 0x00A86F12 File Offset: 0x00A85112
		public unsafe bool 状态_叠加层_下半身通用融合
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_466) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_466) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073F0 RID: 29680
		// (get) Token: 0x0602BB5C RID: 179036 RVA: 0x00A86F23 File Offset: 0x00A85123
		// (set) Token: 0x0602BB5D RID: 179037 RVA: 0x00A86F33 File Offset: 0x00A85133
		public unsafe float 站立叠加倾斜量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_467);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_467) = value;
			}
		}

		// Token: 0x170073F1 RID: 29681
		// (get) Token: 0x0602BB5E RID: 179038 RVA: 0x00A86F44 File Offset: 0x00A85144
		// (set) Token: 0x0602BB5F RID: 179039 RVA: 0x00A86F54 File Offset: 0x00A85154
		public unsafe bool 是否待机表演
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_468) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_468) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073F2 RID: 29682
		// (get) Token: 0x0602BB60 RID: 179040 RVA: 0x00A86F65 File Offset: 0x00A85165
		// (set) Token: 0x0602BB61 RID: 179041 RVA: 0x00A86F75 File Offset: 0x00A85175
		public unsafe float 待机表演间隔
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_469);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_469) = value;
			}
		}

		// Token: 0x170073F3 RID: 29683
		// (get) Token: 0x0602BB62 RID: 179042 RVA: 0x00A86F86 File Offset: 0x00A85186
		// (set) Token: 0x0602BB63 RID: 179043 RVA: 0x00A86F96 File Offset: 0x00A85196
		public unsafe float 当前待机表演计时
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_470);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_470) = value;
			}
		}

		// Token: 0x170073F4 RID: 29684
		// (get) Token: 0x0602BB64 RID: 179044 RVA: 0x00A86FA7 File Offset: 0x00A851A7
		// (set) Token: 0x0602BB65 RID: 179045 RVA: 0x00A86FB7 File Offset: 0x00A851B7
		public unsafe bool 禁用眨眼
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_471) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_471) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073F5 RID: 29685
		// (get) Token: 0x0602BB66 RID: 179046 RVA: 0x00A86FC8 File Offset: 0x00A851C8
		// (set) Token: 0x0602BB67 RID: 179047 RVA: 0x00A86FD8 File Offset: 0x00A851D8
		public unsafe bool 状态_乘坐载具
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_472) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_472) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073F6 RID: 29686
		// (get) Token: 0x0602BB68 RID: 179048 RVA: 0x00A86FE9 File Offset: 0x00A851E9
		// (set) Token: 0x0602BB69 RID: 179049 RVA: 0x00A86FF9 File Offset: 0x00A851F9
		public unsafe bool 状态_地区运动模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_473) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_473) = (value ? 1 : 0);
			}
		}

		// Token: 0x170073F7 RID: 29687
		// (get) Token: 0x0602BB6A RID: 179050 RVA: 0x00A8700A File Offset: 0x00A8520A
		// (set) Token: 0x0602BB6B RID: 179051 RVA: 0x00A8701A File Offset: 0x00A8521A
		public unsafe bool 眨眼曲线覆盖蒙太奇
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_474) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRoleNPC_C.__PropertyOffset_474) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602BB6C RID: 179052 RVA: 0x00A8702C File Offset: 0x00A8522C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 骨骼混合叠加层(FPoseLink BaseLayer, FPoseLink OverlayLayer, FPoseLink BasePose, ref FPoseLink 骨骼混合叠加层)
		{
			ABP_BaseRoleNPC_C.__骨骼混合叠加层_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__骨骼混合叠加层_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__骨骼混合叠加层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__骨骼混合叠加层_NativeFunctionPtr, (void*)ptr, 1);
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
			if (骨骼混合叠加层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->骨骼混合叠加层, 骨骼混合叠加层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__骨骼混合叠加层_NativeFunctionPtr, (void*)ptr);
			if (骨骼混合叠加层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 骨骼混合叠加层.NativePtr, &ptr->骨骼混合叠加层, 1, false);
			}
		}

		// Token: 0x0602BB6D RID: 179053 RVA: 0x00A87120 File Offset: 0x00A85320
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础姿势层(ref FPoseLink 基础姿势层)
		{
			ABP_BaseRoleNPC_C.__基础姿势层_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__基础姿势层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__基础姿势层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__基础姿势层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础姿势层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础姿势层, 基础姿势层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__基础姿势层_NativeFunctionPtr, (void*)ptr);
			if (基础姿势层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础姿势层.NativePtr, &ptr->基础姿势层, 1, false);
			}
		}

		// Token: 0x0602BB6E RID: 179054 RVA: 0x00A871A8 File Offset: 0x00A853A8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 混合层(FPoseLink 基础层输入, FPoseLink 叠加层输入, FPoseLink 姿势层输入, FPoseLink 手臂叠加层输入, ref FPoseLink 混合层)
		{
			ABP_BaseRoleNPC_C.__混合层_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__混合层_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__混合层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__混合层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层输入, 基础层输入.NativePtr, 1, false);
			}
			if (叠加层输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->叠加层输入, 叠加层输入.NativePtr, 1, false);
			}
			if (姿势层输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->姿势层输入, 姿势层输入.NativePtr, 1, false);
			}
			if (手臂叠加层输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->手臂叠加层输入, 手臂叠加层输入.NativePtr, 1, false);
			}
			if (混合层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->混合层, 混合层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__混合层_NativeFunctionPtr, (void*)ptr);
			if (混合层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 混合层.NativePtr, &ptr->混合层, 1, false);
			}
		}

		// Token: 0x0602BB6F RID: 179055 RVA: 0x00A872C0 File Offset: 0x00A854C0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 手臂叠加层(ref FPoseLink 手臂叠加层)
		{
			ABP_BaseRoleNPC_C.__手臂叠加层_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__手臂叠加层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__手臂叠加层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__手臂叠加层_NativeFunctionPtr, (void*)ptr, 1);
			if (手臂叠加层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->手臂叠加层, 手臂叠加层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__手臂叠加层_NativeFunctionPtr, (void*)ptr);
			if (手臂叠加层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 手臂叠加层.NativePtr, &ptr->手臂叠加层, 1, false);
			}
		}

		// Token: 0x0602BB70 RID: 179056 RVA: 0x00A87348 File Offset: 0x00A85548
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 叠加层(ref FPoseLink 叠加层)
		{
			ABP_BaseRoleNPC_C.__叠加层_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__叠加层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__叠加层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__叠加层_NativeFunctionPtr, (void*)ptr, 1);
			if (叠加层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->叠加层, 叠加层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__叠加层_NativeFunctionPtr, (void*)ptr);
			if (叠加层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 叠加层.NativePtr, &ptr->叠加层, 1, false);
			}
		}

		// Token: 0x0602BB71 RID: 179057 RVA: 0x00A873D0 File Offset: 0x00A855D0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(FPoseLink 地区运动模式, ref FPoseLink AnimGraph)
		{
			ABP_BaseRoleNPC_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__AnimGraph_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (地区运动模式 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->地区运动模式, 地区运动模式.NativePtr, 1, false);
			}
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602BB72 RID: 179058 RVA: 0x00A87479 File Offset: 0x00A85679
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 重置坐下待机计时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__重置坐下待机计时_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB73 RID: 179059 RVA: 0x00A8748D File Offset: 0x00A8568D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新坐下待机计时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新坐下待机计时_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB74 RID: 179060 RVA: 0x00A874A1 File Offset: 0x00A856A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新牵手组件参数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新牵手组件参数_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB75 RID: 179061 RVA: 0x00A874B5 File Offset: 0x00A856B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新载具信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新载具信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB76 RID: 179062 RVA: 0x00A874C9 File Offset: 0x00A856C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 初始化身高()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__初始化身高_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB77 RID: 179063 RVA: 0x00A874DD File Offset: 0x00A856DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 组件参数动画蓝图初始化绑定()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__组件参数动画蓝图初始化绑定_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB78 RID: 179064 RVA: 0x00A874F1 File Offset: 0x00A856F1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 绑定组件参数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__绑定组件参数_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB79 RID: 179065 RVA: 0x00A87505 File Offset: 0x00A85705
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新移动信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新移动信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB7A RID: 179066 RVA: 0x00A87519 File Offset: 0x00A85719
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新角色信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB7B RID: 179067 RVA: 0x00A8752D File Offset: 0x00A8572D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新状态参数信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新状态参数信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB7C RID: 179068 RVA: 0x00A87541 File Offset: 0x00A85741
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 切换地面移动模式时高度补差()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__切换地面移动模式时高度补差_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB7D RID: 179069 RVA: 0x00A87555 File Offset: 0x00A85755
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新上传()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新上传_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB7E RID: 179070 RVA: 0x00A87569 File Offset: 0x00A85769
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新时间参数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新时间参数_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB7F RID: 179071 RVA: 0x00A8757D File Offset: 0x00A8577D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新网络参数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新网络参数_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB80 RID: 179072 RVA: 0x00A87591 File Offset: 0x00A85791
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新动画组件参数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新动画组件参数_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB81 RID: 179073 RVA: 0x00A875A5 File Offset: 0x00A857A5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新移动组件参数()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新移动组件参数_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB82 RID: 179074 RVA: 0x00A875B9 File Offset: 0x00A857B9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新随机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新随机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB83 RID: 179075 RVA: 0x00A875CD File Offset: 0x00A857CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色状态()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新角色状态_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB84 RID: 179076 RVA: 0x00A875E4 File Offset: 0x00A857E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 设置头部转向状态(SightLockMode SightMode)
		{
			ABP_BaseRoleNPC_C.__设置头部转向状态_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__设置头部转向状态_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__设置头部转向状态_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__设置头部转向状态_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SightMode = SightMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__设置头部转向状态_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BB85 RID: 179077 RVA: 0x00A8762C File Offset: 0x00A8582C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 更新头部转向(FRotator NewParam)
		{
			ABP_BaseRoleNPC_C.__更新头部转向_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__更新头部转向_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__更新头部转向_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__更新头部转向_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新头部转向_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BB86 RID: 179078 RVA: 0x00A87672 File Offset: 0x00A85872
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新_IK信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新_IK信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB87 RID: 179079 RVA: 0x00A87686 File Offset: 0x00A85886
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 原地旋转检查()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__原地旋转检查_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB88 RID: 179080 RVA: 0x00A8769A File Offset: 0x00A8589A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新旋转信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__更新旋转信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB89 RID: 179081 RVA: 0x00A876B0 File Offset: 0x00A858B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool 是否需要移动()
		{
			ABP_BaseRoleNPC_C.__是否需要移动_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__是否需要移动_FunctionParams[(UIntPtr)21] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__是否需要移动_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__是否需要移动_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__是否需要移动_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602BB8A RID: 179082 RVA: 0x00A876F5 File Offset: 0x00A858F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_CombineCurves_F94882F047B8D7B2DE316584D85149DC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_CombineCurves_F94882F047B8D7B2DE316584D85149DC_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB8B RID: 179083 RVA: 0x00A87709 File Offset: 0x00A85909
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_KuroHumanIK_36C2723F47E5A6C9D004AD9A68AF8A17()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_KuroHumanIK_36C2723F47E5A6C9D004AD9A68AF8A17_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB8C RID: 179084 RVA: 0x00A8771D File Offset: 0x00A8591D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_CD59EF85450C5E805240D0AB9FA6E193()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_CD59EF85450C5E805240D0AB9FA6E193_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB8D RID: 179085 RVA: 0x00A87731 File Offset: 0x00A85931
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_ModifyBone_C72417F6464CF93BF15FC48FDC7E74B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_ModifyBone_C72417F6464CF93BF15FC48FDC7E74B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB8E RID: 179086 RVA: 0x00A87745 File Offset: 0x00A85945
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5B3B900E406A6EB56D45A8A150CD5027()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5B3B900E406A6EB56D45A8A150CD5027_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB8F RID: 179087 RVA: 0x00A87759 File Offset: 0x00A85959
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5954DF6E4B9A0F4F9E0523BF3975F430()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5954DF6E4B9A0F4F9E0523BF3975F430_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB90 RID: 179088 RVA: 0x00A8776D File Offset: 0x00A8596D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DA26BB2149B5458E6256DDB8143551A1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DA26BB2149B5458E6256DDB8143551A1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB91 RID: 179089 RVA: 0x00A87781 File Offset: 0x00A85981
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_069EFF67460F37CC488676941034E815()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_069EFF67460F37CC488676941034E815_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB92 RID: 179090 RVA: 0x00A87795 File Offset: 0x00A85995
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F8058196497AAA5DB641909311715DA6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F8058196497AAA5DB641909311715DA6_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB93 RID: 179091 RVA: 0x00A877A9 File Offset: 0x00A859A9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1C6C34AA46A75FA720D8248F4DE31465()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1C6C34AA46A75FA720D8248F4DE31465_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB94 RID: 179092 RVA: 0x00A877BD File Offset: 0x00A859BD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_CEBF3EEB48DDC734B83B0F8D7C582AB8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_CEBF3EEB48DDC734B83B0F8D7C582AB8_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB95 RID: 179093 RVA: 0x00A877D1 File Offset: 0x00A859D1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_7C4FF4B7436662A2B942DB8E199F221C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_7C4FF4B7436662A2B942DB8E199F221C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB96 RID: 179094 RVA: 0x00A877E5 File Offset: 0x00A859E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1572860A4CBB2FFF06DB6EA8C7AF26B3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1572860A4CBB2FFF06DB6EA8C7AF26B3_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB97 RID: 179095 RVA: 0x00A877F9 File Offset: 0x00A859F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_C9493C78438BBBD610CA87AD5B4AC657()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_C9493C78438BBBD610CA87AD5B4AC657_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB98 RID: 179096 RVA: 0x00A8780D File Offset: 0x00A85A0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_E83224AE4CDCB128E3182A994C0D096A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_E83224AE4CDCB128E3182A994C0D096A_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB99 RID: 179097 RVA: 0x00A87821 File Offset: 0x00A85A21
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_CC2FCFA4422744F114529A914835B6A5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_CC2FCFA4422744F114529A914835B6A5_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB9A RID: 179098 RVA: 0x00A87835 File Offset: 0x00A85A35
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9B55296240E25E52F5434CA6BFD9193F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9B55296240E25E52F5434CA6BFD9193F_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB9B RID: 179099 RVA: 0x00A87849 File Offset: 0x00A85A49
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DD513280456121261D6AA19B601191C3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DD513280456121261D6AA19B601191C3_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB9C RID: 179100 RVA: 0x00A8785D File Offset: 0x00A85A5D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_78935DD844C357BDD04257A52439863E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_78935DD844C357BDD04257A52439863E_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB9D RID: 179101 RVA: 0x00A87871 File Offset: 0x00A85A71
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_8ADD185445C00222746678BD3BD7CAEB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_8ADD185445C00222746678BD3BD7CAEB_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB9E RID: 179102 RVA: 0x00A87885 File Offset: 0x00A85A85
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_91B1DB8946BB1ADB7AAD01969592843C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_91B1DB8946BB1ADB7AAD01969592843C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BB9F RID: 179103 RVA: 0x00A87899 File Offset: 0x00A85A99
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_7456759B4F157297FDA7CB98916A19A7()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_7456759B4F157297FDA7CB98916A19A7_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA0 RID: 179104 RVA: 0x00A878AD File Offset: 0x00A85AAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_C8B97CBD41731C7B6E3C6C81CD0C4078()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_C8B97CBD41731C7B6E3C6C81CD0C4078_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA1 RID: 179105 RVA: 0x00A878C1 File Offset: 0x00A85AC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3203045A42D499B946683D9545476404()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3203045A42D499B946683D9545476404_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA2 RID: 179106 RVA: 0x00A878D5 File Offset: 0x00A85AD5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_2F16FC824EC60FFD922634B397D4F99F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_2F16FC824EC60FFD922634B397D4F99F_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA3 RID: 179107 RVA: 0x00A878E9 File Offset: 0x00A85AE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_26985D1543AE8B7E8FB6809AE5FDD7D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_26985D1543AE8B7E8FB6809AE5FDD7D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA4 RID: 179108 RVA: 0x00A878FD File Offset: 0x00A85AFD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_54372384432A58CEB93EE88069166697()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_54372384432A58CEB93EE88069166697_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA5 RID: 179109 RVA: 0x00A87911 File Offset: 0x00A85B11
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_302400AC4759384B598B33BC6D6EEB3E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_302400AC4759384B598B33BC6D6EEB3E_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA6 RID: 179110 RVA: 0x00A87925 File Offset: 0x00A85B25
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_B49A9B634942643B9C81F68BEDE85116()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_B49A9B634942643B9C81F68BEDE85116_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA7 RID: 179111 RVA: 0x00A87939 File Offset: 0x00A85B39
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_6BBA62AF4C7DD7415CB6AA8A185674E1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_6BBA62AF4C7DD7415CB6AA8A185674E1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA8 RID: 179112 RVA: 0x00A8794D File Offset: 0x00A85B4D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_A4A23A2F45EDAE623B07F3ABD0621315()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_A4A23A2F45EDAE623B07F3ABD0621315_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBA9 RID: 179113 RVA: 0x00A87961 File Offset: 0x00A85B61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9EEB9D994327ED66473204A523C67921()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9EEB9D994327ED66473204A523C67921_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBAA RID: 179114 RVA: 0x00A87975 File Offset: 0x00A85B75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_34726529440463E15F0244939A7F18B5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_34726529440463E15F0244939A7F18B5_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBAB RID: 179115 RVA: 0x00A87989 File Offset: 0x00A85B89
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_23664840422729DF8D8A68B2DDD8DBDC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_23664840422729DF8D8A68B2DDD8DBDC_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBAC RID: 179116 RVA: 0x00A8799D File Offset: 0x00A85B9D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BEEE3BFE494E3CEB5727B3854D1404D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BEEE3BFE494E3CEB5727B3854D1404D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBAD RID: 179117 RVA: 0x00A879B1 File Offset: 0x00A85BB1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F872E4934C5985382E8C969E69266422()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F872E4934C5985382E8C969E69266422_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBAE RID: 179118 RVA: 0x00A879C5 File Offset: 0x00A85BC5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3FBACAF34017F5002FD261897498FDB9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3FBACAF34017F5002FD261897498FDB9_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBAF RID: 179119 RVA: 0x00A879D9 File Offset: 0x00A85BD9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_946C1FB64468DEB2922F3DB47CA0F108()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_946C1FB64468DEB2922F3DB47CA0F108_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB0 RID: 179120 RVA: 0x00A879ED File Offset: 0x00A85BED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_4C84D2A14F534CE2478E7FA4196612A8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_4C84D2A14F534CE2478E7FA4196612A8_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB1 RID: 179121 RVA: 0x00A87A01 File Offset: 0x00A85C01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BB0F9EE5494DF8709F1B6EAD85AB61B6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BB0F9EE5494DF8709F1B6EAD85AB61B6_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB2 RID: 179122 RVA: 0x00A87A15 File Offset: 0x00A85C15
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F811B7054E27C606851206B15100569C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F811B7054E27C606851206B15100569C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB3 RID: 179123 RVA: 0x00A87A29 File Offset: 0x00A85C29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_0BFF18DF40B3D7DAE87832B09238CB8C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_0BFF18DF40B3D7DAE87832B09238CB8C_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB4 RID: 179124 RVA: 0x00A87A3D File Offset: 0x00A85C3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1EBE3AB24D1188D2CA1DD28F1DACFE80()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1EBE3AB24D1188D2CA1DD28F1DACFE80_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB5 RID: 179125 RVA: 0x00A87A51 File Offset: 0x00A85C51
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BB0A26E7433EB47953A74BB9150A949B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BB0A26E7433EB47953A74BB9150A949B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB6 RID: 179126 RVA: 0x00A87A65 File Offset: 0x00A85C65
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F1EE968D4C35EBE8858ADCA296615B8B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F1EE968D4C35EBE8858ADCA296615B8B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB7 RID: 179127 RVA: 0x00A87A79 File Offset: 0x00A85C79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9F27C0544AD432DD916ECCAD79037483()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9F27C0544AD432DD916ECCAD79037483_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB8 RID: 179128 RVA: 0x00A87A8D File Offset: 0x00A85C8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F57C68684C60238886A3D9B21095676D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F57C68684C60238886A3D9B21095676D_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBB9 RID: 179129 RVA: 0x00A87AA1 File Offset: 0x00A85CA1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_8A9A74574D3EFAD95B682B9762D628A4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_8A9A74574D3EFAD95B682B9762D628A4_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBBA RID: 179130 RVA: 0x00A87AB5 File Offset: 0x00A85CB5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_15F4BF374115C55BAF6DE084E8329BAD()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_15F4BF374115C55BAF6DE084E8329BAD_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBBB RID: 179131 RVA: 0x00A87AC9 File Offset: 0x00A85CC9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_697CCA5F461EB64F0A5995B7AB953813()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_697CCA5F461EB64F0A5995B7AB953813_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBBC RID: 179132 RVA: 0x00A87ADD File Offset: 0x00A85CDD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3FB54B9D43E2572F934764B89525DBA6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3FB54B9D43E2572F934764B89525DBA6_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBBD RID: 179133 RVA: 0x00A87AF1 File Offset: 0x00A85CF1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_482074B940ABF6ECD1CD999E796EA34E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_482074B940ABF6ECD1CD999E796EA34E_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBBE RID: 179134 RVA: 0x00A87B05 File Offset: 0x00A85D05
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_41429680472D043A4766F2B4A3547DF9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_41429680472D043A4766F2B4A3547DF9_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBBF RID: 179135 RVA: 0x00A87B19 File Offset: 0x00A85D19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DACFF3464D3F9AB8436B12A8C3BC8B5F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DACFF3464D3F9AB8436B12A8C3BC8B5F_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC0 RID: 179136 RVA: 0x00A87B2D File Offset: 0x00A85D2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_72DFAFBE41537440C4759AB2D3F29556()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_72DFAFBE41537440C4759AB2D3F29556_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC1 RID: 179137 RVA: 0x00A87B41 File Offset: 0x00A85D41
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5CB65EF244800BD2D7264B96580C906B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5CB65EF244800BD2D7264B96580C906B_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC2 RID: 179138 RVA: 0x00A87B55 File Offset: 0x00A85D55
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_25D5D6714880F255FC261BBF86F6D527()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_25D5D6714880F255FC261BBF86F6D527_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC3 RID: 179139 RVA: 0x00A87B69 File Offset: 0x00A85D69
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_75CC77F6411E288DF118E4A64360A8A1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_75CC77F6411E288DF118E4A64360A8A1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC4 RID: 179140 RVA: 0x00A87B7D File Offset: 0x00A85D7D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_2BA72E324A2C3755C78022B557F6A491()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_2BA72E324A2C3755C78022B557F6A491_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC5 RID: 179141 RVA: 0x00A87B91 File Offset: 0x00A85D91
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_54C0791143921BB0C2145DB52A2D1E7D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_54C0791143921BB0C2145DB52A2D1E7D_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC6 RID: 179142 RVA: 0x00A87BA5 File Offset: 0x00A85DA5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_37283ACE4757CBE458A8DCACAC8384FA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_37283ACE4757CBE458A8DCACAC8384FA_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC7 RID: 179143 RVA: 0x00A87BB9 File Offset: 0x00A85DB9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_71EC0ADC497DCA9F71FA849635BAA6FF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_71EC0ADC497DCA9F71FA849635BAA6FF_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC8 RID: 179144 RVA: 0x00A87BCD File Offset: 0x00A85DCD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_12D5B63A43BEA91A69FF3D9E09D44913()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_12D5B63A43BEA91A69FF3D9E09D44913_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBC9 RID: 179145 RVA: 0x00A87BE1 File Offset: 0x00A85DE1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_D7667F094E190371575D33A294CA0593()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_D7667F094E190371575D33A294CA0593_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBCA RID: 179146 RVA: 0x00A87BF5 File Offset: 0x00A85DF5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_69A8D4C04D59E6FF9F2193AEC85AFDF1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_69A8D4C04D59E6FF9F2193AEC85AFDF1_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBCB RID: 179147 RVA: 0x00A87C09 File Offset: 0x00A85E09
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F5F225C54097ECBAB698808B968544C3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F5F225C54097ECBAB698808B968544C3_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBCC RID: 179148 RVA: 0x00A87C1D File Offset: 0x00A85E1D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_B6EF5A894136BA7E1B3EDC80AE42D783()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_B6EF5A894136BA7E1B3EDC80AE42D783_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBCD RID: 179149 RVA: 0x00A87C31 File Offset: 0x00A85E31
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_D40DD943485C763F153AF3BA5BAB8DF9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_D40DD943485C763F153AF3BA5BAB8DF9_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBCE RID: 179150 RVA: 0x00A87C45 File Offset: 0x00A85E45
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_F499CF534A6986E698D36BA4DB203A54()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_F499CF534A6986E698D36BA4DB203A54_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBCF RID: 179151 RVA: 0x00A87C59 File Offset: 0x00A85E59
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_8708BB834451E3EB4E59C3A2DD8C8D31()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_8708BB834451E3EB4E59C3A2DD8C8D31_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD0 RID: 179152 RVA: 0x00A87C6D File Offset: 0x00A85E6D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_972D5BA748C486E5C3BA5E84EBB7FFCC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_972D5BA748C486E5C3BA5E84EBB7FFCC_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD1 RID: 179153 RVA: 0x00A87C81 File Offset: 0x00A85E81
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F9F80FF54FEAA113BD02F8B37CEB0812()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F9F80FF54FEAA113BD02F8B37CEB0812_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD2 RID: 179154 RVA: 0x00A87C95 File Offset: 0x00A85E95
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BC40A3A64A41A5541B6E4E9CC2DCD252()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BC40A3A64A41A5541B6E4E9CC2DCD252_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD3 RID: 179155 RVA: 0x00A87CA9 File Offset: 0x00A85EA9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_EB879569483DECB6FA7ECDBC9C8E85C9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_EB879569483DECB6FA7ECDBC9C8E85C9_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD4 RID: 179156 RVA: 0x00A87CBD File Offset: 0x00A85EBD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_A08277E44F1E71B8099434BDCD7E22E3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_A08277E44F1E71B8099434BDCD7E22E3_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD5 RID: 179157 RVA: 0x00A87CD1 File Offset: 0x00A85ED1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DE70BB2449E575DC49A5BD9387AF8914()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DE70BB2449E575DC49A5BD9387AF8914_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD6 RID: 179158 RVA: 0x00A87CE5 File Offset: 0x00A85EE5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_FC5D00D046374EFAE6D4FF8757A2EC55()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_FC5D00D046374EFAE6D4FF8757A2EC55_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD7 RID: 179159 RVA: 0x00A87CF9 File Offset: 0x00A85EF9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_62D69E7C4011BA6C967747B0331309B3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_62D69E7C4011BA6C967747B0331309B3_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD8 RID: 179160 RVA: 0x00A87D0D File Offset: 0x00A85F0D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_35BF23864F2ECEFB8A627AA88F45D9DE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_35BF23864F2ECEFB8A627AA88F45D9DE_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBD9 RID: 179161 RVA: 0x00A87D24 File Offset: 0x00A85F24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BBDA RID: 179162 RVA: 0x00A87D6C File Offset: 0x00A85F6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BBDB RID: 179163 RVA: 0x00A87DB3 File Offset: 0x00A85FB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBDC RID: 179164 RVA: 0x00A87DC7 File Offset: 0x00A85FC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BBDD RID: 179165 RVA: 0x00A87DDC File Offset: 0x00A85FDC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 播放动画(SDynamicMontageParams 播放动画)
		{
			ABP_BaseRoleNPC_C.__播放动画_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__播放动画_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__播放动画_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__播放动画_NativeFunctionPtr, (void*)ptr, 1);
			if (播放动画 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SDynamicMontageParams.StaticStruct(), &ptr->播放动画, 播放动画.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__播放动画_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BBDE RID: 179166 RVA: 0x00A87E3D File Offset: 0x00A8603D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_停止动画()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimNotify_停止动画_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBDF RID: 179167 RVA: 0x00A87E51 File Offset: 0x00A86051
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnComponentStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__OnComponentStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE0 RID: 179168 RVA: 0x00A87E65 File Offset: 0x00A86065
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnComponentStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__OnComponentStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602BBE1 RID: 179169 RVA: 0x00A87E7C File Offset: 0x00A8607C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MovementChanged(ACharacter Character, EMovementMode PrevMovementMode, byte PreviousCustomMode)
		{
			ABP_BaseRoleNPC_C.__MovementChanged_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__MovementChanged_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__MovementChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__MovementChanged_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Character = ((Character != null) ? Character.NativePtr : IntPtr.Zero);
			ptr->PrevMovementMode = PrevMovementMode;
			ptr->PreviousCustomMode = PreviousCustomMode;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__MovementChanged_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602BBE2 RID: 179170 RVA: 0x00A87EE4 File Offset: 0x00A860E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PlotBlendIn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__PlotBlendIn_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE3 RID: 179171 RVA: 0x00A87EF8 File Offset: 0x00A860F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NoExpose()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__NoExpose_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE4 RID: 179172 RVA: 0x00A87F0C File Offset: 0x00A8610C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_结束坐下()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimNotify_结束坐下_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE5 RID: 179173 RVA: 0x00A87F20 File Offset: 0x00A86120
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入坐下待机()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimNotify_进入坐下待机_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE6 RID: 179174 RVA: 0x00A87F34 File Offset: 0x00A86134
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeftStartSwing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimNotify_LeftStartSwing_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE7 RID: 179175 RVA: 0x00A87F48 File Offset: 0x00A86148
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeftEndSwing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimNotify_LeftEndSwing_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE8 RID: 179176 RVA: 0x00A87F5C File Offset: 0x00A8615C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_LeftLoopSwing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__AnimNotify_LeftLoopSwing_NativeFunctionPtr, null);
		}

		// Token: 0x0602BBE9 RID: 179177 RVA: 0x00A87F70 File Offset: 0x00A86170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRoleNPC(int EntryPoint)
		{
			ABP_BaseRoleNPC_C.__ExecuteUbergraph_ABP_BaseRoleNPC_FunctionParams* ptr = stackalloc ABP_BaseRoleNPC_C.__ExecuteUbergraph_ABP_BaseRoleNPC_FunctionParams[(UIntPtr)2879] + 15L / (long)sizeof(ABP_BaseRoleNPC_C.__ExecuteUbergraph_ABP_BaseRoleNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRoleNPC_C.__ExecuteUbergraph_ABP_BaseRoleNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRoleNPC_C.__ExecuteUbergraph_ABP_BaseRoleNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602BBEA RID: 179178 RVA: 0x00A87FBA File Offset: 0x00A861BA
		protected ABP_BaseRoleNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017DDB RID: 97755
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/RoleNPC/ABP_BaseRoleNPC.ABP_BaseRoleNPC_C";

		// Token: 0x04017DDC RID: 97756
		private static IntPtr _ClassPtr;

		// Token: 0x04017DDD RID: 97757
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017DDE RID: 97758
		internal static int __PropertyOffset_0;

		// Token: 0x04017DDF RID: 97759
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017DE0 RID: 97760
		internal static int __PropertyOffset_1;

		// Token: 0x04017DE1 RID: 97761
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_5;

		// Token: 0x04017DE2 RID: 97762
		internal static int __PropertyOffset_2;

		// Token: 0x04017DE3 RID: 97763
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_7;

		// Token: 0x04017DE4 RID: 97764
		internal static int __PropertyOffset_3;

		// Token: 0x04017DE5 RID: 97765
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_6;

		// Token: 0x04017DE6 RID: 97766
		internal static int __PropertyOffset_4;

		// Token: 0x04017DE7 RID: 97767
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_5;

		// Token: 0x04017DE8 RID: 97768
		internal static int __PropertyOffset_5;

		// Token: 0x04017DE9 RID: 97769
		[Nullable(2)]
		private FAnimNode_AdditiveBoneBlend _AnimGraphNode_AdditiveBoneBlend_3;

		// Token: 0x04017DEA RID: 97770
		internal static int __PropertyOffset_6;

		// Token: 0x04017DEB RID: 97771
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_4;

		// Token: 0x04017DEC RID: 97772
		internal static int __PropertyOffset_7;

		// Token: 0x04017DED RID: 97773
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_53;

		// Token: 0x04017DEE RID: 97774
		internal static int __PropertyOffset_8;

		// Token: 0x04017DEF RID: 97775
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_3;

		// Token: 0x04017DF0 RID: 97776
		internal static int __PropertyOffset_9;

		// Token: 0x04017DF1 RID: 97777
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_6;

		// Token: 0x04017DF2 RID: 97778
		internal static int __PropertyOffset_10;

		// Token: 0x04017DF3 RID: 97779
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_5;

		// Token: 0x04017DF4 RID: 97780
		internal static int __PropertyOffset_11;

		// Token: 0x04017DF5 RID: 97781
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_4;

		// Token: 0x04017DF6 RID: 97782
		internal static int __PropertyOffset_12;

		// Token: 0x04017DF7 RID: 97783
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_4;

		// Token: 0x04017DF8 RID: 97784
		internal static int __PropertyOffset_13;

		// Token: 0x04017DF9 RID: 97785
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_3;

		// Token: 0x04017DFA RID: 97786
		internal static int __PropertyOffset_14;

		// Token: 0x04017DFB RID: 97787
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_2;

		// Token: 0x04017DFC RID: 97788
		internal static int __PropertyOffset_15;

		// Token: 0x04017DFD RID: 97789
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_120;

		// Token: 0x04017DFE RID: 97790
		internal static int __PropertyOffset_16;

		// Token: 0x04017DFF RID: 97791
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_119;

		// Token: 0x04017E00 RID: 97792
		internal static int __PropertyOffset_17;

		// Token: 0x04017E01 RID: 97793
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_18;

		// Token: 0x04017E02 RID: 97794
		internal static int __PropertyOffset_18;

		// Token: 0x04017E03 RID: 97795
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_76;

		// Token: 0x04017E04 RID: 97796
		internal static int __PropertyOffset_19;

		// Token: 0x04017E05 RID: 97797
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_4;

		// Token: 0x04017E06 RID: 97798
		internal static int __PropertyOffset_20;

		// Token: 0x04017E07 RID: 97799
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_17;

		// Token: 0x04017E08 RID: 97800
		internal static int __PropertyOffset_21;

		// Token: 0x04017E09 RID: 97801
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_16;

		// Token: 0x04017E0A RID: 97802
		internal static int __PropertyOffset_22;

		// Token: 0x04017E0B RID: 97803
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_15;

		// Token: 0x04017E0C RID: 97804
		internal static int __PropertyOffset_23;

		// Token: 0x04017E0D RID: 97805
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_75;

		// Token: 0x04017E0E RID: 97806
		internal static int __PropertyOffset_24;

		// Token: 0x04017E0F RID: 97807
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_20;

		// Token: 0x04017E10 RID: 97808
		internal static int __PropertyOffset_25;

		// Token: 0x04017E11 RID: 97809
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04017E12 RID: 97810
		internal static int __PropertyOffset_26;

		// Token: 0x04017E13 RID: 97811
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_3;

		// Token: 0x04017E14 RID: 97812
		internal static int __PropertyOffset_27;

		// Token: 0x04017E15 RID: 97813
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_1;

		// Token: 0x04017E16 RID: 97814
		internal static int __PropertyOffset_28;

		// Token: 0x04017E17 RID: 97815
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_2;

		// Token: 0x04017E18 RID: 97816
		internal static int __PropertyOffset_29;

		// Token: 0x04017E19 RID: 97817
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_118;

		// Token: 0x04017E1A RID: 97818
		internal static int __PropertyOffset_30;

		// Token: 0x04017E1B RID: 97819
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_117;

		// Token: 0x04017E1C RID: 97820
		internal static int __PropertyOffset_31;

		// Token: 0x04017E1D RID: 97821
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_116;

		// Token: 0x04017E1E RID: 97822
		internal static int __PropertyOffset_32;

		// Token: 0x04017E1F RID: 97823
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_115;

		// Token: 0x04017E20 RID: 97824
		internal static int __PropertyOffset_33;

		// Token: 0x04017E21 RID: 97825
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_114;

		// Token: 0x04017E22 RID: 97826
		internal static int __PropertyOffset_34;

		// Token: 0x04017E23 RID: 97827
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_113;

		// Token: 0x04017E24 RID: 97828
		internal static int __PropertyOffset_35;

		// Token: 0x04017E25 RID: 97829
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_112;

		// Token: 0x04017E26 RID: 97830
		internal static int __PropertyOffset_36;

		// Token: 0x04017E27 RID: 97831
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_111;

		// Token: 0x04017E28 RID: 97832
		internal static int __PropertyOffset_37;

		// Token: 0x04017E29 RID: 97833
		[Nullable(2)]
		private FAnimNode_AdditiveBoneBlend _AnimGraphNode_AdditiveBoneBlend_2;

		// Token: 0x04017E2A RID: 97834
		internal static int __PropertyOffset_38;

		// Token: 0x04017E2B RID: 97835
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_14;

		// Token: 0x04017E2C RID: 97836
		internal static int __PropertyOffset_39;

		// Token: 0x04017E2D RID: 97837
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_13;

		// Token: 0x04017E2E RID: 97838
		internal static int __PropertyOffset_40;

		// Token: 0x04017E2F RID: 97839
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_12;

		// Token: 0x04017E30 RID: 97840
		internal static int __PropertyOffset_41;

		// Token: 0x04017E31 RID: 97841
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_74;

		// Token: 0x04017E32 RID: 97842
		internal static int __PropertyOffset_42;

		// Token: 0x04017E33 RID: 97843
		[Nullable(2)]
		private FAnimNode_AdditiveBoneBlend _AnimGraphNode_AdditiveBoneBlend_1;

		// Token: 0x04017E34 RID: 97844
		internal static int __PropertyOffset_43;

		// Token: 0x04017E35 RID: 97845
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_11;

		// Token: 0x04017E36 RID: 97846
		internal static int __PropertyOffset_44;

		// Token: 0x04017E37 RID: 97847
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_10;

		// Token: 0x04017E38 RID: 97848
		internal static int __PropertyOffset_45;

		// Token: 0x04017E39 RID: 97849
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_9;

		// Token: 0x04017E3A RID: 97850
		internal static int __PropertyOffset_46;

		// Token: 0x04017E3B RID: 97851
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_73;

		// Token: 0x04017E3C RID: 97852
		internal static int __PropertyOffset_47;

		// Token: 0x04017E3D RID: 97853
		[Nullable(2)]
		private FAnimNode_AdditiveBoneBlend _AnimGraphNode_AdditiveBoneBlend;

		// Token: 0x04017E3E RID: 97854
		internal static int __PropertyOffset_48;

		// Token: 0x04017E3F RID: 97855
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_8;

		// Token: 0x04017E40 RID: 97856
		internal static int __PropertyOffset_49;

		// Token: 0x04017E41 RID: 97857
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_7;

		// Token: 0x04017E42 RID: 97858
		internal static int __PropertyOffset_50;

		// Token: 0x04017E43 RID: 97859
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_6;

		// Token: 0x04017E44 RID: 97860
		internal static int __PropertyOffset_51;

		// Token: 0x04017E45 RID: 97861
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_72;

		// Token: 0x04017E46 RID: 97862
		internal static int __PropertyOffset_52;

		// Token: 0x04017E47 RID: 97863
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_110;

		// Token: 0x04017E48 RID: 97864
		internal static int __PropertyOffset_53;

		// Token: 0x04017E49 RID: 97865
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_5;

		// Token: 0x04017E4A RID: 97866
		internal static int __PropertyOffset_54;

		// Token: 0x04017E4B RID: 97867
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_71;

		// Token: 0x04017E4C RID: 97868
		internal static int __PropertyOffset_55;

		// Token: 0x04017E4D RID: 97869
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_19;

		// Token: 0x04017E4E RID: 97870
		internal static int __PropertyOffset_56;

		// Token: 0x04017E4F RID: 97871
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x04017E50 RID: 97872
		internal static int __PropertyOffset_57;

		// Token: 0x04017E51 RID: 97873
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_109;

		// Token: 0x04017E52 RID: 97874
		internal static int __PropertyOffset_58;

		// Token: 0x04017E53 RID: 97875
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_108;

		// Token: 0x04017E54 RID: 97876
		internal static int __PropertyOffset_59;

		// Token: 0x04017E55 RID: 97877
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_107;

		// Token: 0x04017E56 RID: 97878
		internal static int __PropertyOffset_60;

		// Token: 0x04017E57 RID: 97879
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_106;

		// Token: 0x04017E58 RID: 97880
		internal static int __PropertyOffset_61;

		// Token: 0x04017E59 RID: 97881
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_105;

		// Token: 0x04017E5A RID: 97882
		internal static int __PropertyOffset_62;

		// Token: 0x04017E5B RID: 97883
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_52;

		// Token: 0x04017E5C RID: 97884
		internal static int __PropertyOffset_63;

		// Token: 0x04017E5D RID: 97885
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_70;

		// Token: 0x04017E5E RID: 97886
		internal static int __PropertyOffset_64;

		// Token: 0x04017E5F RID: 97887
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_104;

		// Token: 0x04017E60 RID: 97888
		internal static int __PropertyOffset_65;

		// Token: 0x04017E61 RID: 97889
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_103;

		// Token: 0x04017E62 RID: 97890
		internal static int __PropertyOffset_66;

		// Token: 0x04017E63 RID: 97891
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_102;

		// Token: 0x04017E64 RID: 97892
		internal static int __PropertyOffset_67;

		// Token: 0x04017E65 RID: 97893
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_101;

		// Token: 0x04017E66 RID: 97894
		internal static int __PropertyOffset_68;

		// Token: 0x04017E67 RID: 97895
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_100;

		// Token: 0x04017E68 RID: 97896
		internal static int __PropertyOffset_69;

		// Token: 0x04017E69 RID: 97897
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_99;

		// Token: 0x04017E6A RID: 97898
		internal static int __PropertyOffset_70;

		// Token: 0x04017E6B RID: 97899
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_98;

		// Token: 0x04017E6C RID: 97900
		internal static int __PropertyOffset_71;

		// Token: 0x04017E6D RID: 97901
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_97;

		// Token: 0x04017E6E RID: 97902
		internal static int __PropertyOffset_72;

		// Token: 0x04017E6F RID: 97903
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_3;

		// Token: 0x04017E70 RID: 97904
		internal static int __PropertyOffset_73;

		// Token: 0x04017E71 RID: 97905
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_69;

		// Token: 0x04017E72 RID: 97906
		internal static int __PropertyOffset_74;

		// Token: 0x04017E73 RID: 97907
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_51;

		// Token: 0x04017E74 RID: 97908
		internal static int __PropertyOffset_75;

		// Token: 0x04017E75 RID: 97909
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_68;

		// Token: 0x04017E76 RID: 97910
		internal static int __PropertyOffset_76;

		// Token: 0x04017E77 RID: 97911
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_18;

		// Token: 0x04017E78 RID: 97912
		internal static int __PropertyOffset_77;

		// Token: 0x04017E79 RID: 97913
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_67;

		// Token: 0x04017E7A RID: 97914
		internal static int __PropertyOffset_78;

		// Token: 0x04017E7B RID: 97915
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_96;

		// Token: 0x04017E7C RID: 97916
		internal static int __PropertyOffset_79;

		// Token: 0x04017E7D RID: 97917
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_95;

		// Token: 0x04017E7E RID: 97918
		internal static int __PropertyOffset_80;

		// Token: 0x04017E7F RID: 97919
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_2;

		// Token: 0x04017E80 RID: 97920
		internal static int __PropertyOffset_81;

		// Token: 0x04017E81 RID: 97921
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_66;

		// Token: 0x04017E82 RID: 97922
		internal static int __PropertyOffset_82;

		// Token: 0x04017E83 RID: 97923
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_50;

		// Token: 0x04017E84 RID: 97924
		internal static int __PropertyOffset_83;

		// Token: 0x04017E85 RID: 97925
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_65;

		// Token: 0x04017E86 RID: 97926
		internal static int __PropertyOffset_84;

		// Token: 0x04017E87 RID: 97927
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_17;

		// Token: 0x04017E88 RID: 97928
		internal static int __PropertyOffset_85;

		// Token: 0x04017E89 RID: 97929
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_64;

		// Token: 0x04017E8A RID: 97930
		internal static int __PropertyOffset_86;

		// Token: 0x04017E8B RID: 97931
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_49;

		// Token: 0x04017E8C RID: 97932
		internal static int __PropertyOffset_87;

		// Token: 0x04017E8D RID: 97933
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_63;

		// Token: 0x04017E8E RID: 97934
		internal static int __PropertyOffset_88;

		// Token: 0x04017E8F RID: 97935
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_94;

		// Token: 0x04017E90 RID: 97936
		internal static int __PropertyOffset_89;

		// Token: 0x04017E91 RID: 97937
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_16;

		// Token: 0x04017E92 RID: 97938
		internal static int __PropertyOffset_90;

		// Token: 0x04017E93 RID: 97939
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_62;

		// Token: 0x04017E94 RID: 97940
		internal static int __PropertyOffset_91;

		// Token: 0x04017E95 RID: 97941
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_15;

		// Token: 0x04017E96 RID: 97942
		internal static int __PropertyOffset_92;

		// Token: 0x04017E97 RID: 97943
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04017E98 RID: 97944
		internal static int __PropertyOffset_93;

		// Token: 0x04017E99 RID: 97945
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_48;

		// Token: 0x04017E9A RID: 97946
		internal static int __PropertyOffset_94;

		// Token: 0x04017E9B RID: 97947
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_61;

		// Token: 0x04017E9C RID: 97948
		internal static int __PropertyOffset_95;

		// Token: 0x04017E9D RID: 97949
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_14;

		// Token: 0x04017E9E RID: 97950
		internal static int __PropertyOffset_96;

		// Token: 0x04017E9F RID: 97951
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_5;

		// Token: 0x04017EA0 RID: 97952
		internal static int __PropertyOffset_97;

		// Token: 0x04017EA1 RID: 97953
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04017EA2 RID: 97954
		internal static int __PropertyOffset_98;

		// Token: 0x04017EA3 RID: 97955
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_4;

		// Token: 0x04017EA4 RID: 97956
		internal static int __PropertyOffset_99;

		// Token: 0x04017EA5 RID: 97957
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace_2;

		// Token: 0x04017EA6 RID: 97958
		internal static int __PropertyOffset_100;

		// Token: 0x04017EA7 RID: 97959
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace_2;

		// Token: 0x04017EA8 RID: 97960
		internal static int __PropertyOffset_101;

		// Token: 0x04017EA9 RID: 97961
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x04017EAA RID: 97962
		internal static int __PropertyOffset_102;

		// Token: 0x04017EAB RID: 97963
		[Nullable(2)]
		private FAnimNode_KuroHumanIK _AnimGraphNode_KuroHumanIK;

		// Token: 0x04017EAC RID: 97964
		internal static int __PropertyOffset_103;

		// Token: 0x04017EAD RID: 97965
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves_2;

		// Token: 0x04017EAE RID: 97966
		internal static int __PropertyOffset_104;

		// Token: 0x04017EAF RID: 97967
		[Nullable(2)]
		private FAnimNode_RotationOffsetBlendSpace _AnimGraphNode_RotationOffsetBlendSpace;

		// Token: 0x04017EB0 RID: 97968
		internal static int __PropertyOffset_105;

		// Token: 0x04017EB1 RID: 97969
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_47;

		// Token: 0x04017EB2 RID: 97970
		internal static int __PropertyOffset_106;

		// Token: 0x04017EB3 RID: 97971
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_3;

		// Token: 0x04017EB4 RID: 97972
		internal static int __PropertyOffset_107;

		// Token: 0x04017EB5 RID: 97973
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_2;

		// Token: 0x04017EB6 RID: 97974
		internal static int __PropertyOffset_108;

		// Token: 0x04017EB7 RID: 97975
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves_1;

		// Token: 0x04017EB8 RID: 97976
		internal static int __PropertyOffset_109;

		// Token: 0x04017EB9 RID: 97977
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot_1;

		// Token: 0x04017EBA RID: 97978
		internal static int __PropertyOffset_110;

		// Token: 0x04017EBB RID: 97979
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace_1;

		// Token: 0x04017EBC RID: 97980
		internal static int __PropertyOffset_111;

		// Token: 0x04017EBD RID: 97981
		[Nullable(2)]
		private FAnimNode_RBF _AnimGraphNode_RBF;

		// Token: 0x04017EBE RID: 97982
		internal static int __PropertyOffset_112;

		// Token: 0x04017EBF RID: 97983
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace_1;

		// Token: 0x04017EC0 RID: 97984
		internal static int __PropertyOffset_113;

		// Token: 0x04017EC1 RID: 97985
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool_2;

		// Token: 0x04017EC2 RID: 97986
		internal static int __PropertyOffset_114;

		// Token: 0x04017EC3 RID: 97987
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_3;

		// Token: 0x04017EC4 RID: 97988
		internal static int __PropertyOffset_115;

		// Token: 0x04017EC5 RID: 97989
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x04017EC6 RID: 97990
		internal static int __PropertyOffset_116;

		// Token: 0x04017EC7 RID: 97991
		[Nullable(2)]
		private FAnimNode_TwoWayBlend _AnimGraphNode_TwoWayBlend;

		// Token: 0x04017EC8 RID: 97992
		internal static int __PropertyOffset_117;

		// Token: 0x04017EC9 RID: 97993
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_46;

		// Token: 0x04017ECA RID: 97994
		internal static int __PropertyOffset_118;

		// Token: 0x04017ECB RID: 97995
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_45;

		// Token: 0x04017ECC RID: 97996
		internal static int __PropertyOffset_119;

		// Token: 0x04017ECD RID: 97997
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04017ECE RID: 97998
		internal static int __PropertyOffset_120;

		// Token: 0x04017ECF RID: 97999
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_60;

		// Token: 0x04017ED0 RID: 98000
		internal static int __PropertyOffset_121;

		// Token: 0x04017ED1 RID: 98001
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_13;

		// Token: 0x04017ED2 RID: 98002
		internal static int __PropertyOffset_122;

		// Token: 0x04017ED3 RID: 98003
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_93;

		// Token: 0x04017ED4 RID: 98004
		internal static int __PropertyOffset_123;

		// Token: 0x04017ED5 RID: 98005
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_92;

		// Token: 0x04017ED6 RID: 98006
		internal static int __PropertyOffset_124;

		// Token: 0x04017ED7 RID: 98007
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_91;

		// Token: 0x04017ED8 RID: 98008
		internal static int __PropertyOffset_125;

		// Token: 0x04017ED9 RID: 98009
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_90;

		// Token: 0x04017EDA RID: 98010
		internal static int __PropertyOffset_126;

		// Token: 0x04017EDB RID: 98011
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_89;

		// Token: 0x04017EDC RID: 98012
		internal static int __PropertyOffset_127;

		// Token: 0x04017EDD RID: 98013
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_88;

		// Token: 0x04017EDE RID: 98014
		internal static int __PropertyOffset_128;

		// Token: 0x04017EDF RID: 98015
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_87;

		// Token: 0x04017EE0 RID: 98016
		internal static int __PropertyOffset_129;

		// Token: 0x04017EE1 RID: 98017
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_86;

		// Token: 0x04017EE2 RID: 98018
		internal static int __PropertyOffset_130;

		// Token: 0x04017EE3 RID: 98019
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_85;

		// Token: 0x04017EE4 RID: 98020
		internal static int __PropertyOffset_131;

		// Token: 0x04017EE5 RID: 98021
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_84;

		// Token: 0x04017EE6 RID: 98022
		internal static int __PropertyOffset_132;

		// Token: 0x04017EE7 RID: 98023
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_83;

		// Token: 0x04017EE8 RID: 98024
		internal static int __PropertyOffset_133;

		// Token: 0x04017EE9 RID: 98025
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_82;

		// Token: 0x04017EEA RID: 98026
		internal static int __PropertyOffset_134;

		// Token: 0x04017EEB RID: 98027
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_81;

		// Token: 0x04017EEC RID: 98028
		internal static int __PropertyOffset_135;

		// Token: 0x04017EED RID: 98029
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_80;

		// Token: 0x04017EEE RID: 98030
		internal static int __PropertyOffset_136;

		// Token: 0x04017EEF RID: 98031
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_79;

		// Token: 0x04017EF0 RID: 98032
		internal static int __PropertyOffset_137;

		// Token: 0x04017EF1 RID: 98033
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_78;

		// Token: 0x04017EF2 RID: 98034
		internal static int __PropertyOffset_138;

		// Token: 0x04017EF3 RID: 98035
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_77;

		// Token: 0x04017EF4 RID: 98036
		internal static int __PropertyOffset_139;

		// Token: 0x04017EF5 RID: 98037
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_76;

		// Token: 0x04017EF6 RID: 98038
		internal static int __PropertyOffset_140;

		// Token: 0x04017EF7 RID: 98039
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_75;

		// Token: 0x04017EF8 RID: 98040
		internal static int __PropertyOffset_141;

		// Token: 0x04017EF9 RID: 98041
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_74;

		// Token: 0x04017EFA RID: 98042
		internal static int __PropertyOffset_142;

		// Token: 0x04017EFB RID: 98043
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_73;

		// Token: 0x04017EFC RID: 98044
		internal static int __PropertyOffset_143;

		// Token: 0x04017EFD RID: 98045
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_72;

		// Token: 0x04017EFE RID: 98046
		internal static int __PropertyOffset_144;

		// Token: 0x04017EFF RID: 98047
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_71;

		// Token: 0x04017F00 RID: 98048
		internal static int __PropertyOffset_145;

		// Token: 0x04017F01 RID: 98049
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_70;

		// Token: 0x04017F02 RID: 98050
		internal static int __PropertyOffset_146;

		// Token: 0x04017F03 RID: 98051
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_69;

		// Token: 0x04017F04 RID: 98052
		internal static int __PropertyOffset_147;

		// Token: 0x04017F05 RID: 98053
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_68;

		// Token: 0x04017F06 RID: 98054
		internal static int __PropertyOffset_148;

		// Token: 0x04017F07 RID: 98055
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_67;

		// Token: 0x04017F08 RID: 98056
		internal static int __PropertyOffset_149;

		// Token: 0x04017F09 RID: 98057
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_66;

		// Token: 0x04017F0A RID: 98058
		internal static int __PropertyOffset_150;

		// Token: 0x04017F0B RID: 98059
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_65;

		// Token: 0x04017F0C RID: 98060
		internal static int __PropertyOffset_151;

		// Token: 0x04017F0D RID: 98061
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_64;

		// Token: 0x04017F0E RID: 98062
		internal static int __PropertyOffset_152;

		// Token: 0x04017F0F RID: 98063
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_63;

		// Token: 0x04017F10 RID: 98064
		internal static int __PropertyOffset_153;

		// Token: 0x04017F11 RID: 98065
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_62;

		// Token: 0x04017F12 RID: 98066
		internal static int __PropertyOffset_154;

		// Token: 0x04017F13 RID: 98067
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_61;

		// Token: 0x04017F14 RID: 98068
		internal static int __PropertyOffset_155;

		// Token: 0x04017F15 RID: 98069
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_44;

		// Token: 0x04017F16 RID: 98070
		internal static int __PropertyOffset_156;

		// Token: 0x04017F17 RID: 98071
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_59;

		// Token: 0x04017F18 RID: 98072
		internal static int __PropertyOffset_157;

		// Token: 0x04017F19 RID: 98073
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_43;

		// Token: 0x04017F1A RID: 98074
		internal static int __PropertyOffset_158;

		// Token: 0x04017F1B RID: 98075
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_58;

		// Token: 0x04017F1C RID: 98076
		internal static int __PropertyOffset_159;

		// Token: 0x04017F1D RID: 98077
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_60;

		// Token: 0x04017F1E RID: 98078
		internal static int __PropertyOffset_160;

		// Token: 0x04017F1F RID: 98079
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_42;

		// Token: 0x04017F20 RID: 98080
		internal static int __PropertyOffset_161;

		// Token: 0x04017F21 RID: 98081
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_57;

		// Token: 0x04017F22 RID: 98082
		internal static int __PropertyOffset_162;

		// Token: 0x04017F23 RID: 98083
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_59;

		// Token: 0x04017F24 RID: 98084
		internal static int __PropertyOffset_163;

		// Token: 0x04017F25 RID: 98085
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_58;

		// Token: 0x04017F26 RID: 98086
		internal static int __PropertyOffset_164;

		// Token: 0x04017F27 RID: 98087
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_57;

		// Token: 0x04017F28 RID: 98088
		internal static int __PropertyOffset_165;

		// Token: 0x04017F29 RID: 98089
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_56;

		// Token: 0x04017F2A RID: 98090
		internal static int __PropertyOffset_166;

		// Token: 0x04017F2B RID: 98091
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_55;

		// Token: 0x04017F2C RID: 98092
		internal static int __PropertyOffset_167;

		// Token: 0x04017F2D RID: 98093
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_54;

		// Token: 0x04017F2E RID: 98094
		internal static int __PropertyOffset_168;

		// Token: 0x04017F2F RID: 98095
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_53;

		// Token: 0x04017F30 RID: 98096
		internal static int __PropertyOffset_169;

		// Token: 0x04017F31 RID: 98097
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_52;

		// Token: 0x04017F32 RID: 98098
		internal static int __PropertyOffset_170;

		// Token: 0x04017F33 RID: 98099
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_51;

		// Token: 0x04017F34 RID: 98100
		internal static int __PropertyOffset_171;

		// Token: 0x04017F35 RID: 98101
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_50;

		// Token: 0x04017F36 RID: 98102
		internal static int __PropertyOffset_172;

		// Token: 0x04017F37 RID: 98103
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_49;

		// Token: 0x04017F38 RID: 98104
		internal static int __PropertyOffset_173;

		// Token: 0x04017F39 RID: 98105
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_48;

		// Token: 0x04017F3A RID: 98106
		internal static int __PropertyOffset_174;

		// Token: 0x04017F3B RID: 98107
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_47;

		// Token: 0x04017F3C RID: 98108
		internal static int __PropertyOffset_175;

		// Token: 0x04017F3D RID: 98109
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_46;

		// Token: 0x04017F3E RID: 98110
		internal static int __PropertyOffset_176;

		// Token: 0x04017F3F RID: 98111
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_45;

		// Token: 0x04017F40 RID: 98112
		internal static int __PropertyOffset_177;

		// Token: 0x04017F41 RID: 98113
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_44;

		// Token: 0x04017F42 RID: 98114
		internal static int __PropertyOffset_178;

		// Token: 0x04017F43 RID: 98115
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_56;

		// Token: 0x04017F44 RID: 98116
		internal static int __PropertyOffset_179;

		// Token: 0x04017F45 RID: 98117
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_55;

		// Token: 0x04017F46 RID: 98118
		internal static int __PropertyOffset_180;

		// Token: 0x04017F47 RID: 98119
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_43;

		// Token: 0x04017F48 RID: 98120
		internal static int __PropertyOffset_181;

		// Token: 0x04017F49 RID: 98121
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_41;

		// Token: 0x04017F4A RID: 98122
		internal static int __PropertyOffset_182;

		// Token: 0x04017F4B RID: 98123
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_54;

		// Token: 0x04017F4C RID: 98124
		internal static int __PropertyOffset_183;

		// Token: 0x04017F4D RID: 98125
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_40;

		// Token: 0x04017F4E RID: 98126
		internal static int __PropertyOffset_184;

		// Token: 0x04017F4F RID: 98127
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_53;

		// Token: 0x04017F50 RID: 98128
		internal static int __PropertyOffset_185;

		// Token: 0x04017F51 RID: 98129
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_39;

		// Token: 0x04017F52 RID: 98130
		internal static int __PropertyOffset_186;

		// Token: 0x04017F53 RID: 98131
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_52;

		// Token: 0x04017F54 RID: 98132
		internal static int __PropertyOffset_187;

		// Token: 0x04017F55 RID: 98133
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_38;

		// Token: 0x04017F56 RID: 98134
		internal static int __PropertyOffset_188;

		// Token: 0x04017F57 RID: 98135
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_51;

		// Token: 0x04017F58 RID: 98136
		internal static int __PropertyOffset_189;

		// Token: 0x04017F59 RID: 98137
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_42;

		// Token: 0x04017F5A RID: 98138
		internal static int __PropertyOffset_190;

		// Token: 0x04017F5B RID: 98139
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_41;

		// Token: 0x04017F5C RID: 98140
		internal static int __PropertyOffset_191;

		// Token: 0x04017F5D RID: 98141
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_37;

		// Token: 0x04017F5E RID: 98142
		internal static int __PropertyOffset_192;

		// Token: 0x04017F5F RID: 98143
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_50;

		// Token: 0x04017F60 RID: 98144
		internal static int __PropertyOffset_193;

		// Token: 0x04017F61 RID: 98145
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_36;

		// Token: 0x04017F62 RID: 98146
		internal static int __PropertyOffset_194;

		// Token: 0x04017F63 RID: 98147
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_49;

		// Token: 0x04017F64 RID: 98148
		internal static int __PropertyOffset_195;

		// Token: 0x04017F65 RID: 98149
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_12;

		// Token: 0x04017F66 RID: 98150
		internal static int __PropertyOffset_196;

		// Token: 0x04017F67 RID: 98151
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_48;

		// Token: 0x04017F68 RID: 98152
		internal static int __PropertyOffset_197;

		// Token: 0x04017F69 RID: 98153
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_40;

		// Token: 0x04017F6A RID: 98154
		internal static int __PropertyOffset_198;

		// Token: 0x04017F6B RID: 98155
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_47;

		// Token: 0x04017F6C RID: 98156
		internal static int __PropertyOffset_199;

		// Token: 0x04017F6D RID: 98157
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_39;

		// Token: 0x04017F6E RID: 98158
		internal static int __PropertyOffset_200;

		// Token: 0x04017F6F RID: 98159
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_35;

		// Token: 0x04017F70 RID: 98160
		internal static int __PropertyOffset_201;

		// Token: 0x04017F71 RID: 98161
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_46;

		// Token: 0x04017F72 RID: 98162
		internal static int __PropertyOffset_202;

		// Token: 0x04017F73 RID: 98163
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator;

		// Token: 0x04017F74 RID: 98164
		internal static int __PropertyOffset_203;

		// Token: 0x04017F75 RID: 98165
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_45;

		// Token: 0x04017F76 RID: 98166
		internal static int __PropertyOffset_204;

		// Token: 0x04017F77 RID: 98167
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_11;

		// Token: 0x04017F78 RID: 98168
		internal static int __PropertyOffset_205;

		// Token: 0x04017F79 RID: 98169
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_44;

		// Token: 0x04017F7A RID: 98170
		internal static int __PropertyOffset_206;

		// Token: 0x04017F7B RID: 98171
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_34;

		// Token: 0x04017F7C RID: 98172
		internal static int __PropertyOffset_207;

		// Token: 0x04017F7D RID: 98173
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_33;

		// Token: 0x04017F7E RID: 98174
		internal static int __PropertyOffset_208;

		// Token: 0x04017F7F RID: 98175
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_32;

		// Token: 0x04017F80 RID: 98176
		internal static int __PropertyOffset_209;

		// Token: 0x04017F81 RID: 98177
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_31;

		// Token: 0x04017F82 RID: 98178
		internal static int __PropertyOffset_210;

		// Token: 0x04017F83 RID: 98179
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_2;

		// Token: 0x04017F84 RID: 98180
		internal static int __PropertyOffset_211;

		// Token: 0x04017F85 RID: 98181
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_4;

		// Token: 0x04017F86 RID: 98182
		internal static int __PropertyOffset_212;

		// Token: 0x04017F87 RID: 98183
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_3;

		// Token: 0x04017F88 RID: 98184
		internal static int __PropertyOffset_213;

		// Token: 0x04017F89 RID: 98185
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_43;

		// Token: 0x04017F8A RID: 98186
		internal static int __PropertyOffset_214;

		// Token: 0x04017F8B RID: 98187
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_30;

		// Token: 0x04017F8C RID: 98188
		internal static int __PropertyOffset_215;

		// Token: 0x04017F8D RID: 98189
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_29;

		// Token: 0x04017F8E RID: 98190
		internal static int __PropertyOffset_216;

		// Token: 0x04017F8F RID: 98191
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_28;

		// Token: 0x04017F90 RID: 98192
		internal static int __PropertyOffset_217;

		// Token: 0x04017F91 RID: 98193
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_27;

		// Token: 0x04017F92 RID: 98194
		internal static int __PropertyOffset_218;

		// Token: 0x04017F93 RID: 98195
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive_1;

		// Token: 0x04017F94 RID: 98196
		internal static int __PropertyOffset_219;

		// Token: 0x04017F95 RID: 98197
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_3;

		// Token: 0x04017F96 RID: 98198
		internal static int __PropertyOffset_220;

		// Token: 0x04017F97 RID: 98199
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_2;

		// Token: 0x04017F98 RID: 98200
		internal static int __PropertyOffset_221;

		// Token: 0x04017F99 RID: 98201
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_42;

		// Token: 0x04017F9A RID: 98202
		internal static int __PropertyOffset_222;

		// Token: 0x04017F9B RID: 98203
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_2;

		// Token: 0x04017F9C RID: 98204
		internal static int __PropertyOffset_223;

		// Token: 0x04017F9D RID: 98205
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_41;

		// Token: 0x04017F9E RID: 98206
		internal static int __PropertyOffset_224;

		// Token: 0x04017F9F RID: 98207
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_1;

		// Token: 0x04017FA0 RID: 98208
		internal static int __PropertyOffset_225;

		// Token: 0x04017FA1 RID: 98209
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_40;

		// Token: 0x04017FA2 RID: 98210
		internal static int __PropertyOffset_226;

		// Token: 0x04017FA3 RID: 98211
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_10;

		// Token: 0x04017FA4 RID: 98212
		internal static int __PropertyOffset_227;

		// Token: 0x04017FA5 RID: 98213
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_1;

		// Token: 0x04017FA6 RID: 98214
		internal static int __PropertyOffset_228;

		// Token: 0x04017FA7 RID: 98215
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool_1;

		// Token: 0x04017FA8 RID: 98216
		internal static int __PropertyOffset_229;

		// Token: 0x04017FA9 RID: 98217
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04017FAA RID: 98218
		internal static int __PropertyOffset_230;

		// Token: 0x04017FAB RID: 98219
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves;

		// Token: 0x04017FAC RID: 98220
		internal static int __PropertyOffset_231;

		// Token: 0x04017FAD RID: 98221
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04017FAE RID: 98222
		internal static int __PropertyOffset_232;

		// Token: 0x04017FAF RID: 98223
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_38;

		// Token: 0x04017FB0 RID: 98224
		internal static int __PropertyOffset_233;

		// Token: 0x04017FB1 RID: 98225
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_37;

		// Token: 0x04017FB2 RID: 98226
		internal static int __PropertyOffset_234;

		// Token: 0x04017FB3 RID: 98227
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_36;

		// Token: 0x04017FB4 RID: 98228
		internal static int __PropertyOffset_235;

		// Token: 0x04017FB5 RID: 98229
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_35;

		// Token: 0x04017FB6 RID: 98230
		internal static int __PropertyOffset_236;

		// Token: 0x04017FB7 RID: 98231
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_34;

		// Token: 0x04017FB8 RID: 98232
		internal static int __PropertyOffset_237;

		// Token: 0x04017FB9 RID: 98233
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x04017FBA RID: 98234
		internal static int __PropertyOffset_238;

		// Token: 0x04017FBB RID: 98235
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x04017FBC RID: 98236
		internal static int __PropertyOffset_239;

		// Token: 0x04017FBD RID: 98237
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x04017FBE RID: 98238
		internal static int __PropertyOffset_240;

		// Token: 0x04017FBF RID: 98239
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x04017FC0 RID: 98240
		internal static int __PropertyOffset_241;

		// Token: 0x04017FC1 RID: 98241
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x04017FC2 RID: 98242
		internal static int __PropertyOffset_242;

		// Token: 0x04017FC3 RID: 98243
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x04017FC4 RID: 98244
		internal static int __PropertyOffset_243;

		// Token: 0x04017FC5 RID: 98245
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x04017FC6 RID: 98246
		internal static int __PropertyOffset_244;

		// Token: 0x04017FC7 RID: 98247
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_39;

		// Token: 0x04017FC8 RID: 98248
		internal static int __PropertyOffset_245;

		// Token: 0x04017FC9 RID: 98249
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_26;

		// Token: 0x04017FCA RID: 98250
		internal static int __PropertyOffset_246;

		// Token: 0x04017FCB RID: 98251
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_38;

		// Token: 0x04017FCC RID: 98252
		internal static int __PropertyOffset_247;

		// Token: 0x04017FCD RID: 98253
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_25;

		// Token: 0x04017FCE RID: 98254
		internal static int __PropertyOffset_248;

		// Token: 0x04017FCF RID: 98255
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_37;

		// Token: 0x04017FD0 RID: 98256
		internal static int __PropertyOffset_249;

		// Token: 0x04017FD1 RID: 98257
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_24;

		// Token: 0x04017FD2 RID: 98258
		internal static int __PropertyOffset_250;

		// Token: 0x04017FD3 RID: 98259
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_36;

		// Token: 0x04017FD4 RID: 98260
		internal static int __PropertyOffset_251;

		// Token: 0x04017FD5 RID: 98261
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_9;

		// Token: 0x04017FD6 RID: 98262
		internal static int __PropertyOffset_252;

		// Token: 0x04017FD7 RID: 98263
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_35;

		// Token: 0x04017FD8 RID: 98264
		internal static int __PropertyOffset_253;

		// Token: 0x04017FD9 RID: 98265
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x04017FDA RID: 98266
		internal static int __PropertyOffset_254;

		// Token: 0x04017FDB RID: 98267
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x04017FDC RID: 98268
		internal static int __PropertyOffset_255;

		// Token: 0x04017FDD RID: 98269
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x04017FDE RID: 98270
		internal static int __PropertyOffset_256;

		// Token: 0x04017FDF RID: 98271
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x04017FE0 RID: 98272
		internal static int __PropertyOffset_257;

		// Token: 0x04017FE1 RID: 98273
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x04017FE2 RID: 98274
		internal static int __PropertyOffset_258;

		// Token: 0x04017FE3 RID: 98275
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x04017FE4 RID: 98276
		internal static int __PropertyOffset_259;

		// Token: 0x04017FE5 RID: 98277
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_23;

		// Token: 0x04017FE6 RID: 98278
		internal static int __PropertyOffset_260;

		// Token: 0x04017FE7 RID: 98279
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_34;

		// Token: 0x04017FE8 RID: 98280
		internal static int __PropertyOffset_261;

		// Token: 0x04017FE9 RID: 98281
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_33;

		// Token: 0x04017FEA RID: 98282
		internal static int __PropertyOffset_262;

		// Token: 0x04017FEB RID: 98283
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_32;

		// Token: 0x04017FEC RID: 98284
		internal static int __PropertyOffset_263;

		// Token: 0x04017FED RID: 98285
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_22;

		// Token: 0x04017FEE RID: 98286
		internal static int __PropertyOffset_264;

		// Token: 0x04017FEF RID: 98287
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_31;

		// Token: 0x04017FF0 RID: 98288
		internal static int __PropertyOffset_265;

		// Token: 0x04017FF1 RID: 98289
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_21;

		// Token: 0x04017FF2 RID: 98290
		internal static int __PropertyOffset_266;

		// Token: 0x04017FF3 RID: 98291
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_30;

		// Token: 0x04017FF4 RID: 98292
		internal static int __PropertyOffset_267;

		// Token: 0x04017FF5 RID: 98293
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_20;

		// Token: 0x04017FF6 RID: 98294
		internal static int __PropertyOffset_268;

		// Token: 0x04017FF7 RID: 98295
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x04017FF8 RID: 98296
		internal static int __PropertyOffset_269;

		// Token: 0x04017FF9 RID: 98297
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_19;

		// Token: 0x04017FFA RID: 98298
		internal static int __PropertyOffset_270;

		// Token: 0x04017FFB RID: 98299
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x04017FFC RID: 98300
		internal static int __PropertyOffset_271;

		// Token: 0x04017FFD RID: 98301
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_8;

		// Token: 0x04017FFE RID: 98302
		internal static int __PropertyOffset_272;

		// Token: 0x04017FFF RID: 98303
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x04018000 RID: 98304
		internal static int __PropertyOffset_273;

		// Token: 0x04018001 RID: 98305
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_18;

		// Token: 0x04018002 RID: 98306
		internal static int __PropertyOffset_274;

		// Token: 0x04018003 RID: 98307
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x04018004 RID: 98308
		internal static int __PropertyOffset_275;

		// Token: 0x04018005 RID: 98309
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_7;

		// Token: 0x04018006 RID: 98310
		internal static int __PropertyOffset_276;

		// Token: 0x04018007 RID: 98311
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x04018008 RID: 98312
		internal static int __PropertyOffset_277;

		// Token: 0x04018009 RID: 98313
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x0401800A RID: 98314
		internal static int __PropertyOffset_278;

		// Token: 0x0401800B RID: 98315
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x0401800C RID: 98316
		internal static int __PropertyOffset_279;

		// Token: 0x0401800D RID: 98317
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x0401800E RID: 98318
		internal static int __PropertyOffset_280;

		// Token: 0x0401800F RID: 98319
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x04018010 RID: 98320
		internal static int __PropertyOffset_281;

		// Token: 0x04018011 RID: 98321
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04018012 RID: 98322
		internal static int __PropertyOffset_282;

		// Token: 0x04018013 RID: 98323
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04018014 RID: 98324
		internal static int __PropertyOffset_283;

		// Token: 0x04018015 RID: 98325
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04018016 RID: 98326
		internal static int __PropertyOffset_284;

		// Token: 0x04018017 RID: 98327
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_17;

		// Token: 0x04018018 RID: 98328
		internal static int __PropertyOffset_285;

		// Token: 0x04018019 RID: 98329
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x0401801A RID: 98330
		internal static int __PropertyOffset_286;

		// Token: 0x0401801B RID: 98331
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_16;

		// Token: 0x0401801C RID: 98332
		internal static int __PropertyOffset_287;

		// Token: 0x0401801D RID: 98333
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x0401801E RID: 98334
		internal static int __PropertyOffset_288;

		// Token: 0x0401801F RID: 98335
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_15;

		// Token: 0x04018020 RID: 98336
		internal static int __PropertyOffset_289;

		// Token: 0x04018021 RID: 98337
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x04018022 RID: 98338
		internal static int __PropertyOffset_290;

		// Token: 0x04018023 RID: 98339
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_6;

		// Token: 0x04018024 RID: 98340
		internal static int __PropertyOffset_291;

		// Token: 0x04018025 RID: 98341
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x04018026 RID: 98342
		internal static int __PropertyOffset_292;

		// Token: 0x04018027 RID: 98343
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x04018028 RID: 98344
		internal static int __PropertyOffset_293;

		// Token: 0x04018029 RID: 98345
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x0401802A RID: 98346
		internal static int __PropertyOffset_294;

		// Token: 0x0401802B RID: 98347
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x0401802C RID: 98348
		internal static int __PropertyOffset_295;

		// Token: 0x0401802D RID: 98349
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x0401802E RID: 98350
		internal static int __PropertyOffset_296;

		// Token: 0x0401802F RID: 98351
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x04018030 RID: 98352
		internal static int __PropertyOffset_297;

		// Token: 0x04018031 RID: 98353
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_5;

		// Token: 0x04018032 RID: 98354
		internal static int __PropertyOffset_298;

		// Token: 0x04018033 RID: 98355
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x04018034 RID: 98356
		internal static int __PropertyOffset_299;

		// Token: 0x04018035 RID: 98357
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x04018036 RID: 98358
		internal static int __PropertyOffset_300;

		// Token: 0x04018037 RID: 98359
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x04018038 RID: 98360
		internal static int __PropertyOffset_301;

		// Token: 0x04018039 RID: 98361
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x0401803A RID: 98362
		internal static int __PropertyOffset_302;

		// Token: 0x0401803B RID: 98363
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x0401803C RID: 98364
		internal static int __PropertyOffset_303;

		// Token: 0x0401803D RID: 98365
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x0401803E RID: 98366
		internal static int __PropertyOffset_304;

		// Token: 0x0401803F RID: 98367
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04018040 RID: 98368
		internal static int __PropertyOffset_305;

		// Token: 0x04018041 RID: 98369
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x04018042 RID: 98370
		internal static int __PropertyOffset_306;

		// Token: 0x04018043 RID: 98371
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x04018044 RID: 98372
		internal static int __PropertyOffset_307;

		// Token: 0x04018045 RID: 98373
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04018046 RID: 98374
		internal static int __PropertyOffset_308;

		// Token: 0x04018047 RID: 98375
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x04018048 RID: 98376
		internal static int __PropertyOffset_309;

		// Token: 0x04018049 RID: 98377
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x0401804A RID: 98378
		internal static int __PropertyOffset_310;

		// Token: 0x0401804B RID: 98379
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x0401804C RID: 98380
		internal static int __PropertyOffset_311;

		// Token: 0x0401804D RID: 98381
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x0401804E RID: 98382
		internal static int __PropertyOffset_312;

		// Token: 0x0401804F RID: 98383
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04018050 RID: 98384
		internal static int __PropertyOffset_313;

		// Token: 0x04018051 RID: 98385
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04018052 RID: 98386
		internal static int __PropertyOffset_314;

		// Token: 0x04018053 RID: 98387
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04018054 RID: 98388
		internal static int __PropertyOffset_315;

		// Token: 0x04018055 RID: 98389
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04018056 RID: 98390
		internal static int __PropertyOffset_316;

		// Token: 0x04018057 RID: 98391
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x04018058 RID: 98392
		internal static int __PropertyOffset_317;

		// Token: 0x04018059 RID: 98393
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x0401805A RID: 98394
		internal static int __PropertyOffset_318;

		// Token: 0x0401805B RID: 98395
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x0401805C RID: 98396
		internal static int __PropertyOffset_319;

		// Token: 0x0401805D RID: 98397
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x0401805E RID: 98398
		internal static int __PropertyOffset_320;

		// Token: 0x0401805F RID: 98399
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04018060 RID: 98400
		internal static int __PropertyOffset_321;

		// Token: 0x04018061 RID: 98401
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04018062 RID: 98402
		internal static int __PropertyOffset_322;

		// Token: 0x04018063 RID: 98403
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04018064 RID: 98404
		internal static int __PropertyOffset_323;

		// Token: 0x04018065 RID: 98405
		[Nullable(2)]
		private FAnimNode_ExtraFollowAnims _AnimGraphNode_ExtraFollowAnims;

		// Token: 0x04018066 RID: 98406
		internal static int __PropertyOffset_324;

		// Token: 0x04018067 RID: 98407
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04018068 RID: 98408
		internal static int __PropertyOffset_325;

		// Token: 0x04018069 RID: 98409
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x0401806A RID: 98410
		internal static int __PropertyOffset_326;

		// Token: 0x0401806B RID: 98411
		[Nullable(2)]
		private FAnimNode_ModifyBone _AnimGraphNode_ModifyBone;

		// Token: 0x0401806C RID: 98412
		internal static int __PropertyOffset_327;

		// Token: 0x0401806D RID: 98413
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x0401806E RID: 98414
		internal static int __PropertyOffset_328;

		// Token: 0x0401806F RID: 98415
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x04018070 RID: 98416
		internal static int __PropertyOffset_329;

		// Token: 0x04018071 RID: 98417
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04018072 RID: 98418
		internal static int __PropertyOffset_330;

		// Token: 0x04018073 RID: 98419
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04018074 RID: 98420
		internal static int __PropertyOffset_331;

		// Token: 0x04018075 RID: 98421
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04018076 RID: 98422
		internal static int __PropertyOffset_332;

		// Token: 0x04018077 RID: 98423
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04018078 RID: 98424
		internal static int __PropertyOffset_333;

		// Token: 0x04018079 RID: 98425
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0401807A RID: 98426
		internal static int __PropertyOffset_334;

		// Token: 0x0401807B RID: 98427
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0401807C RID: 98428
		internal static int __PropertyOffset_335;

		// Token: 0x0401807D RID: 98429
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x0401807E RID: 98430
		internal static int __PropertyOffset_336;

		// Token: 0x0401807F RID: 98431
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04018080 RID: 98432
		internal static int __PropertyOffset_337;

		// Token: 0x04018081 RID: 98433
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04018082 RID: 98434
		internal static int __PropertyOffset_338;

		// Token: 0x04018083 RID: 98435
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04018084 RID: 98436
		internal static int __PropertyOffset_339;

		// Token: 0x04018085 RID: 98437
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend_1;

		// Token: 0x04018086 RID: 98438
		internal static int __PropertyOffset_340;

		// Token: 0x04018087 RID: 98439
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04018088 RID: 98440
		internal static int __PropertyOffset_341;

		// Token: 0x04018089 RID: 98441
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x0401808A RID: 98442
		internal static int __PropertyOffset_342;

		// Token: 0x0401808B RID: 98443
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x0401808C RID: 98444
		internal static int __PropertyOffset_343;

		// Token: 0x0401808D RID: 98445
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401808E RID: 98446
		internal static int __PropertyOffset_344;

		// Token: 0x0401808F RID: 98447
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04018090 RID: 98448
		internal static int __PropertyOffset_345;

		// Token: 0x04018091 RID: 98449
		[Nullable(2)]
		private FAnimNode_MultiWayBlend _AnimGraphNode_MultiWayBlend;

		// Token: 0x04018092 RID: 98450
		internal static int __PropertyOffset_346;

		// Token: 0x04018093 RID: 98451
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04018094 RID: 98452
		internal static int __PropertyOffset_347;

		// Token: 0x04018095 RID: 98453
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04018096 RID: 98454
		internal static int __PropertyOffset_348;

		// Token: 0x04018097 RID: 98455
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04018098 RID: 98456
		internal static int __PropertyOffset_349;

		// Token: 0x04018099 RID: 98457
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x0401809A RID: 98458
		internal static int __PropertyOffset_350;

		// Token: 0x0401809B RID: 98459
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0401809C RID: 98460
		internal static int __PropertyOffset_351;

		// Token: 0x0401809D RID: 98461
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x0401809E RID: 98462
		internal static int __PropertyOffset_352;

		// Token: 0x0401809F RID: 98463
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x040180A0 RID: 98464
		internal static int __PropertyOffset_353;

		// Token: 0x040180A1 RID: 98465
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose;

		// Token: 0x040180A2 RID: 98466
		internal static int __PropertyOffset_354;

		// Token: 0x040180A3 RID: 98467
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x040180A4 RID: 98468
		internal static int __PropertyOffset_355;

		// Token: 0x040180A5 RID: 98469
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x040180A6 RID: 98470
		internal static int __PropertyOffset_356;

		// Token: 0x040180A7 RID: 98471
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose;

		// Token: 0x040180A8 RID: 98472
		internal static int __PropertyOffset_357;

		// Token: 0x040180A9 RID: 98473
		[Nullable(2)]
		private FAnimNode_CurveFix _AnimGraphNode_CurveFix;

		// Token: 0x040180AA RID: 98474
		internal static int __PropertyOffset_358;

		// Token: 0x040180AB RID: 98475
		[Nullable(2)]
		private FAnimNode_KuroCacheBones _AnimGraphNode_KuroCacheBones;

		// Token: 0x040180AC RID: 98476
		internal static int __PropertyOffset_359;

		// Token: 0x040180AD RID: 98477
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_3;

		// Token: 0x040180AE RID: 98478
		internal static int __PropertyOffset_360;

		// Token: 0x040180AF RID: 98479
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_2;

		// Token: 0x040180B0 RID: 98480
		internal static int __PropertyOffset_361;

		// Token: 0x040180B1 RID: 98481
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x040180B2 RID: 98482
		internal static int __PropertyOffset_362;

		// Token: 0x040180B3 RID: 98483
		[Nullable(2)]
		private FAnimNode_BlendListByBool _AnimGraphNode_BlendListByBool;

		// Token: 0x040180B4 RID: 98484
		internal static int __PropertyOffset_363;

		// Token: 0x040180B5 RID: 98485
		[Nullable(2)]
		private FAnimNode_PoseSnapshot _AnimGraphNode_PoseSnapshot;

		// Token: 0x040180B6 RID: 98486
		internal static int __PropertyOffset_364;

		// Token: 0x040180B7 RID: 98487
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x040180B8 RID: 98488
		internal static int __PropertyOffset_365;

		// Token: 0x040180B9 RID: 98489
		internal static int __PropertyOffset_366;

		// Token: 0x040180BA RID: 98490
		internal static int __PropertyOffset_367;

		// Token: 0x040180BB RID: 98491
		internal static int __PropertyOffset_368;

		// Token: 0x040180BC RID: 98492
		internal static int __PropertyOffset_369;

		// Token: 0x040180BD RID: 98493
		internal static int __PropertyOffset_370;

		// Token: 0x040180BE RID: 98494
		internal static int __PropertyOffset_371;

		// Token: 0x040180BF RID: 98495
		internal static int __PropertyOffset_372;

		// Token: 0x040180C0 RID: 98496
		internal static int __PropertyOffset_373;

		// Token: 0x040180C1 RID: 98497
		internal static int __PropertyOffset_374;

		// Token: 0x040180C2 RID: 98498
		internal static int __PropertyOffset_375;

		// Token: 0x040180C3 RID: 98499
		internal static int __PropertyOffset_376;

		// Token: 0x040180C4 RID: 98500
		internal static int __PropertyOffset_377;

		// Token: 0x040180C5 RID: 98501
		internal static int __PropertyOffset_378;

		// Token: 0x040180C6 RID: 98502
		internal static int __PropertyOffset_379;

		// Token: 0x040180C7 RID: 98503
		internal static int __PropertyOffset_380;

		// Token: 0x040180C8 RID: 98504
		[Nullable(2)]
		private FLeanAmount _倾斜量;

		// Token: 0x040180C9 RID: 98505
		internal static int __PropertyOffset_381;

		// Token: 0x040180CA RID: 98506
		internal static int __PropertyOffset_382;

		// Token: 0x040180CB RID: 98507
		internal static int __PropertyOffset_383;

		// Token: 0x040180CC RID: 98508
		internal static int __PropertyOffset_384;

		// Token: 0x040180CD RID: 98509
		internal static int __PropertyOffset_385;

		// Token: 0x040180CE RID: 98510
		internal static int __PropertyOffset_386;

		// Token: 0x040180CF RID: 98511
		internal static int __PropertyOffset_387;

		// Token: 0x040180D0 RID: 98512
		internal static int __PropertyOffset_388;

		// Token: 0x040180D1 RID: 98513
		internal static int __PropertyOffset_389;

		// Token: 0x040180D2 RID: 98514
		internal static int __PropertyOffset_390;

		// Token: 0x040180D3 RID: 98515
		internal static int __PropertyOffset_391;

		// Token: 0x040180D4 RID: 98516
		internal static int __PropertyOffset_392;

		// Token: 0x040180D5 RID: 98517
		internal static int __PropertyOffset_393;

		// Token: 0x040180D6 RID: 98518
		internal static int __PropertyOffset_394;

		// Token: 0x040180D7 RID: 98519
		internal static int __PropertyOffset_395;

		// Token: 0x040180D8 RID: 98520
		internal static int __PropertyOffset_396;

		// Token: 0x040180D9 RID: 98521
		internal static int __PropertyOffset_397;

		// Token: 0x040180DA RID: 98522
		internal static int __PropertyOffset_398;

		// Token: 0x040180DB RID: 98523
		internal static int __PropertyOffset_399;

		// Token: 0x040180DC RID: 98524
		internal static int __PropertyOffset_400;

		// Token: 0x040180DD RID: 98525
		internal static int __PropertyOffset_401;

		// Token: 0x040180DE RID: 98526
		internal static int __PropertyOffset_402;

		// Token: 0x040180DF RID: 98527
		internal static int __PropertyOffset_403;

		// Token: 0x040180E0 RID: 98528
		internal static int __PropertyOffset_404;

		// Token: 0x040180E1 RID: 98529
		internal static int __PropertyOffset_405;

		// Token: 0x040180E2 RID: 98530
		internal static int __PropertyOffset_406;

		// Token: 0x040180E3 RID: 98531
		internal static int __PropertyOffset_407;

		// Token: 0x040180E4 RID: 98532
		internal static int __PropertyOffset_408;

		// Token: 0x040180E5 RID: 98533
		internal static int __PropertyOffset_409;

		// Token: 0x040180E6 RID: 98534
		internal static int __PropertyOffset_410;

		// Token: 0x040180E7 RID: 98535
		internal static int __PropertyOffset_411;

		// Token: 0x040180E8 RID: 98536
		internal static int __PropertyOffset_412;

		// Token: 0x040180E9 RID: 98537
		internal static int __PropertyOffset_413;

		// Token: 0x040180EA RID: 98538
		internal static int __PropertyOffset_414;

		// Token: 0x040180EB RID: 98539
		internal static int __PropertyOffset_415;

		// Token: 0x040180EC RID: 98540
		internal static int __PropertyOffset_416;

		// Token: 0x040180ED RID: 98541
		internal static int __PropertyOffset_417;

		// Token: 0x040180EE RID: 98542
		internal static int __PropertyOffset_418;

		// Token: 0x040180EF RID: 98543
		internal static int __PropertyOffset_419;

		// Token: 0x040180F0 RID: 98544
		internal static int __PropertyOffset_420;

		// Token: 0x040180F1 RID: 98545
		internal static int __PropertyOffset_421;

		// Token: 0x040180F2 RID: 98546
		internal static int __PropertyOffset_422;

		// Token: 0x040180F3 RID: 98547
		internal static int __PropertyOffset_423;

		// Token: 0x040180F4 RID: 98548
		internal static int __PropertyOffset_424;

		// Token: 0x040180F5 RID: 98549
		internal static int __PropertyOffset_425;

		// Token: 0x040180F6 RID: 98550
		internal static int __PropertyOffset_426;

		// Token: 0x040180F7 RID: 98551
		internal static int __PropertyOffset_427;

		// Token: 0x040180F8 RID: 98552
		internal static int __PropertyOffset_428;

		// Token: 0x040180F9 RID: 98553
		internal static int __PropertyOffset_429;

		// Token: 0x040180FA RID: 98554
		internal static int __PropertyOffset_430;

		// Token: 0x040180FB RID: 98555
		internal static int __PropertyOffset_431;

		// Token: 0x040180FC RID: 98556
		internal static int __PropertyOffset_432;

		// Token: 0x040180FD RID: 98557
		internal static int __PropertyOffset_433;

		// Token: 0x040180FE RID: 98558
		internal static int __PropertyOffset_434;

		// Token: 0x040180FF RID: 98559
		internal static int __PropertyOffset_435;

		// Token: 0x04018100 RID: 98560
		internal static int __PropertyOffset_436;

		// Token: 0x04018101 RID: 98561
		internal static int __PropertyOffset_437;

		// Token: 0x04018102 RID: 98562
		internal static int __PropertyOffset_438;

		// Token: 0x04018103 RID: 98563
		internal static int __PropertyOffset_439;

		// Token: 0x04018104 RID: 98564
		internal static int __PropertyOffset_440;

		// Token: 0x04018105 RID: 98565
		internal static int __PropertyOffset_441;

		// Token: 0x04018106 RID: 98566
		internal static int __PropertyOffset_442;

		// Token: 0x04018107 RID: 98567
		internal static int __PropertyOffset_443;

		// Token: 0x04018108 RID: 98568
		internal static int __PropertyOffset_444;

		// Token: 0x04018109 RID: 98569
		internal static int __PropertyOffset_445;

		// Token: 0x0401810A RID: 98570
		internal static int __PropertyOffset_446;

		// Token: 0x0401810B RID: 98571
		internal static int __PropertyOffset_447;

		// Token: 0x0401810C RID: 98572
		internal static int __PropertyOffset_448;

		// Token: 0x0401810D RID: 98573
		internal static int __PropertyOffset_449;

		// Token: 0x0401810E RID: 98574
		internal static int __PropertyOffset_450;

		// Token: 0x0401810F RID: 98575
		internal static int __PropertyOffset_451;

		// Token: 0x04018110 RID: 98576
		internal static int __PropertyOffset_452;

		// Token: 0x04018111 RID: 98577
		internal static int __PropertyOffset_453;

		// Token: 0x04018112 RID: 98578
		internal static int __PropertyOffset_454;

		// Token: 0x04018113 RID: 98579
		internal static int __PropertyOffset_455;

		// Token: 0x04018114 RID: 98580
		internal static int __PropertyOffset_456;

		// Token: 0x04018115 RID: 98581
		internal static int __PropertyOffset_457;

		// Token: 0x04018116 RID: 98582
		internal static int __PropertyOffset_458;

		// Token: 0x04018117 RID: 98583
		internal static int __PropertyOffset_459;

		// Token: 0x04018118 RID: 98584
		internal static int __PropertyOffset_460;

		// Token: 0x04018119 RID: 98585
		internal static int __PropertyOffset_461;

		// Token: 0x0401811A RID: 98586
		[Nullable(2)]
		private FPoseSnapshot _CachePose;

		// Token: 0x0401811B RID: 98587
		internal static int __PropertyOffset_462;

		// Token: 0x0401811C RID: 98588
		internal static int __PropertyOffset_463;

		// Token: 0x0401811D RID: 98589
		internal static int __PropertyOffset_464;

		// Token: 0x0401811E RID: 98590
		internal static int __PropertyOffset_465;

		// Token: 0x0401811F RID: 98591
		internal static int __PropertyOffset_466;

		// Token: 0x04018120 RID: 98592
		internal static int __PropertyOffset_467;

		// Token: 0x04018121 RID: 98593
		internal static int __PropertyOffset_468;

		// Token: 0x04018122 RID: 98594
		internal static int __PropertyOffset_469;

		// Token: 0x04018123 RID: 98595
		internal static int __PropertyOffset_470;

		// Token: 0x04018124 RID: 98596
		internal static int __PropertyOffset_471;

		// Token: 0x04018125 RID: 98597
		internal static int __PropertyOffset_472;

		// Token: 0x04018126 RID: 98598
		internal static int __PropertyOffset_473;

		// Token: 0x04018127 RID: 98599
		internal static int __PropertyOffset_474;

		// Token: 0x04018128 RID: 98600
		private static IntPtr __骨骼混合叠加层_NativeFunctionPtr;

		// Token: 0x04018129 RID: 98601
		private static IntPtr __基础姿势层_NativeFunctionPtr;

		// Token: 0x0401812A RID: 98602
		private static IntPtr __混合层_NativeFunctionPtr;

		// Token: 0x0401812B RID: 98603
		private static IntPtr __手臂叠加层_NativeFunctionPtr;

		// Token: 0x0401812C RID: 98604
		private static IntPtr __叠加层_NativeFunctionPtr;

		// Token: 0x0401812D RID: 98605
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401812E RID: 98606
		private static IntPtr __重置坐下待机计时_NativeFunctionPtr;

		// Token: 0x0401812F RID: 98607
		private static IntPtr __更新坐下待机计时_NativeFunctionPtr;

		// Token: 0x04018130 RID: 98608
		private static IntPtr __更新牵手组件参数_NativeFunctionPtr;

		// Token: 0x04018131 RID: 98609
		private static IntPtr __更新载具信息_NativeFunctionPtr;

		// Token: 0x04018132 RID: 98610
		private static IntPtr __初始化身高_NativeFunctionPtr;

		// Token: 0x04018133 RID: 98611
		private static IntPtr __组件参数动画蓝图初始化绑定_NativeFunctionPtr;

		// Token: 0x04018134 RID: 98612
		private static IntPtr __绑定组件参数_NativeFunctionPtr;

		// Token: 0x04018135 RID: 98613
		private static IntPtr __更新移动信息_NativeFunctionPtr;

		// Token: 0x04018136 RID: 98614
		private static IntPtr __更新角色信息_NativeFunctionPtr;

		// Token: 0x04018137 RID: 98615
		private static IntPtr __更新状态参数信息_NativeFunctionPtr;

		// Token: 0x04018138 RID: 98616
		private static IntPtr __切换地面移动模式时高度补差_NativeFunctionPtr;

		// Token: 0x04018139 RID: 98617
		private static IntPtr __更新上传_NativeFunctionPtr;

		// Token: 0x0401813A RID: 98618
		private static IntPtr __更新时间参数_NativeFunctionPtr;

		// Token: 0x0401813B RID: 98619
		private static IntPtr __更新网络参数_NativeFunctionPtr;

		// Token: 0x0401813C RID: 98620
		private static IntPtr __更新动画组件参数_NativeFunctionPtr;

		// Token: 0x0401813D RID: 98621
		private static IntPtr __更新移动组件参数_NativeFunctionPtr;

		// Token: 0x0401813E RID: 98622
		private static IntPtr __更新随机表演_NativeFunctionPtr;

		// Token: 0x0401813F RID: 98623
		private static IntPtr __更新角色状态_NativeFunctionPtr;

		// Token: 0x04018140 RID: 98624
		private static IntPtr __设置头部转向状态_NativeFunctionPtr;

		// Token: 0x04018141 RID: 98625
		private static IntPtr __更新头部转向_NativeFunctionPtr;

		// Token: 0x04018142 RID: 98626
		private static IntPtr __更新_IK信息_NativeFunctionPtr;

		// Token: 0x04018143 RID: 98627
		private static IntPtr __原地旋转检查_NativeFunctionPtr;

		// Token: 0x04018144 RID: 98628
		private static IntPtr __更新旋转信息_NativeFunctionPtr;

		// Token: 0x04018145 RID: 98629
		private static IntPtr __是否需要移动_NativeFunctionPtr;

		// Token: 0x04018146 RID: 98630
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_CombineCurves_F94882F047B8D7B2DE316584D85149DC_NativeFunctionPtr;

		// Token: 0x04018147 RID: 98631
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_KuroHumanIK_36C2723F47E5A6C9D004AD9A68AF8A17_NativeFunctionPtr;

		// Token: 0x04018148 RID: 98632
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_CD59EF85450C5E805240D0AB9FA6E193_NativeFunctionPtr;

		// Token: 0x04018149 RID: 98633
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_ModifyBone_C72417F6464CF93BF15FC48FDC7E74B4_NativeFunctionPtr;

		// Token: 0x0401814A RID: 98634
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5B3B900E406A6EB56D45A8A150CD5027_NativeFunctionPtr;

		// Token: 0x0401814B RID: 98635
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5954DF6E4B9A0F4F9E0523BF3975F430_NativeFunctionPtr;

		// Token: 0x0401814C RID: 98636
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DA26BB2149B5458E6256DDB8143551A1_NativeFunctionPtr;

		// Token: 0x0401814D RID: 98637
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_069EFF67460F37CC488676941034E815_NativeFunctionPtr;

		// Token: 0x0401814E RID: 98638
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F8058196497AAA5DB641909311715DA6_NativeFunctionPtr;

		// Token: 0x0401814F RID: 98639
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1C6C34AA46A75FA720D8248F4DE31465_NativeFunctionPtr;

		// Token: 0x04018150 RID: 98640
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_CEBF3EEB48DDC734B83B0F8D7C582AB8_NativeFunctionPtr;

		// Token: 0x04018151 RID: 98641
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_7C4FF4B7436662A2B942DB8E199F221C_NativeFunctionPtr;

		// Token: 0x04018152 RID: 98642
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1572860A4CBB2FFF06DB6EA8C7AF26B3_NativeFunctionPtr;

		// Token: 0x04018153 RID: 98643
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_C9493C78438BBBD610CA87AD5B4AC657_NativeFunctionPtr;

		// Token: 0x04018154 RID: 98644
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_E83224AE4CDCB128E3182A994C0D096A_NativeFunctionPtr;

		// Token: 0x04018155 RID: 98645
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_CC2FCFA4422744F114529A914835B6A5_NativeFunctionPtr;

		// Token: 0x04018156 RID: 98646
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9B55296240E25E52F5434CA6BFD9193F_NativeFunctionPtr;

		// Token: 0x04018157 RID: 98647
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DD513280456121261D6AA19B601191C3_NativeFunctionPtr;

		// Token: 0x04018158 RID: 98648
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_78935DD844C357BDD04257A52439863E_NativeFunctionPtr;

		// Token: 0x04018159 RID: 98649
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_8ADD185445C00222746678BD3BD7CAEB_NativeFunctionPtr;

		// Token: 0x0401815A RID: 98650
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_91B1DB8946BB1ADB7AAD01969592843C_NativeFunctionPtr;

		// Token: 0x0401815B RID: 98651
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_7456759B4F157297FDA7CB98916A19A7_NativeFunctionPtr;

		// Token: 0x0401815C RID: 98652
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_C8B97CBD41731C7B6E3C6C81CD0C4078_NativeFunctionPtr;

		// Token: 0x0401815D RID: 98653
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3203045A42D499B946683D9545476404_NativeFunctionPtr;

		// Token: 0x0401815E RID: 98654
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_2F16FC824EC60FFD922634B397D4F99F_NativeFunctionPtr;

		// Token: 0x0401815F RID: 98655
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_26985D1543AE8B7E8FB6809AE5FDD7D5_NativeFunctionPtr;

		// Token: 0x04018160 RID: 98656
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_54372384432A58CEB93EE88069166697_NativeFunctionPtr;

		// Token: 0x04018161 RID: 98657
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_302400AC4759384B598B33BC6D6EEB3E_NativeFunctionPtr;

		// Token: 0x04018162 RID: 98658
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_B49A9B634942643B9C81F68BEDE85116_NativeFunctionPtr;

		// Token: 0x04018163 RID: 98659
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_6BBA62AF4C7DD7415CB6AA8A185674E1_NativeFunctionPtr;

		// Token: 0x04018164 RID: 98660
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_A4A23A2F45EDAE623B07F3ABD0621315_NativeFunctionPtr;

		// Token: 0x04018165 RID: 98661
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9EEB9D994327ED66473204A523C67921_NativeFunctionPtr;

		// Token: 0x04018166 RID: 98662
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_34726529440463E15F0244939A7F18B5_NativeFunctionPtr;

		// Token: 0x04018167 RID: 98663
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_23664840422729DF8D8A68B2DDD8DBDC_NativeFunctionPtr;

		// Token: 0x04018168 RID: 98664
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BEEE3BFE494E3CEB5727B3854D1404D5_NativeFunctionPtr;

		// Token: 0x04018169 RID: 98665
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F872E4934C5985382E8C969E69266422_NativeFunctionPtr;

		// Token: 0x0401816A RID: 98666
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3FBACAF34017F5002FD261897498FDB9_NativeFunctionPtr;

		// Token: 0x0401816B RID: 98667
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_946C1FB64468DEB2922F3DB47CA0F108_NativeFunctionPtr;

		// Token: 0x0401816C RID: 98668
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_4C84D2A14F534CE2478E7FA4196612A8_NativeFunctionPtr;

		// Token: 0x0401816D RID: 98669
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BB0F9EE5494DF8709F1B6EAD85AB61B6_NativeFunctionPtr;

		// Token: 0x0401816E RID: 98670
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F811B7054E27C606851206B15100569C_NativeFunctionPtr;

		// Token: 0x0401816F RID: 98671
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_0BFF18DF40B3D7DAE87832B09238CB8C_NativeFunctionPtr;

		// Token: 0x04018170 RID: 98672
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_1EBE3AB24D1188D2CA1DD28F1DACFE80_NativeFunctionPtr;

		// Token: 0x04018171 RID: 98673
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BB0A26E7433EB47953A74BB9150A949B_NativeFunctionPtr;

		// Token: 0x04018172 RID: 98674
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F1EE968D4C35EBE8858ADCA296615B8B_NativeFunctionPtr;

		// Token: 0x04018173 RID: 98675
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_9F27C0544AD432DD916ECCAD79037483_NativeFunctionPtr;

		// Token: 0x04018174 RID: 98676
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F57C68684C60238886A3D9B21095676D_NativeFunctionPtr;

		// Token: 0x04018175 RID: 98677
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_8A9A74574D3EFAD95B682B9762D628A4_NativeFunctionPtr;

		// Token: 0x04018176 RID: 98678
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_15F4BF374115C55BAF6DE084E8329BAD_NativeFunctionPtr;

		// Token: 0x04018177 RID: 98679
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_697CCA5F461EB64F0A5995B7AB953813_NativeFunctionPtr;

		// Token: 0x04018178 RID: 98680
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_3FB54B9D43E2572F934764B89525DBA6_NativeFunctionPtr;

		// Token: 0x04018179 RID: 98681
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_482074B940ABF6ECD1CD999E796EA34E_NativeFunctionPtr;

		// Token: 0x0401817A RID: 98682
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_41429680472D043A4766F2B4A3547DF9_NativeFunctionPtr;

		// Token: 0x0401817B RID: 98683
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DACFF3464D3F9AB8436B12A8C3BC8B5F_NativeFunctionPtr;

		// Token: 0x0401817C RID: 98684
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_72DFAFBE41537440C4759AB2D3F29556_NativeFunctionPtr;

		// Token: 0x0401817D RID: 98685
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_5CB65EF244800BD2D7264B96580C906B_NativeFunctionPtr;

		// Token: 0x0401817E RID: 98686
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_25D5D6714880F255FC261BBF86F6D527_NativeFunctionPtr;

		// Token: 0x0401817F RID: 98687
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_75CC77F6411E288DF118E4A64360A8A1_NativeFunctionPtr;

		// Token: 0x04018180 RID: 98688
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_2BA72E324A2C3755C78022B557F6A491_NativeFunctionPtr;

		// Token: 0x04018181 RID: 98689
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_54C0791143921BB0C2145DB52A2D1E7D_NativeFunctionPtr;

		// Token: 0x04018182 RID: 98690
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_37283ACE4757CBE458A8DCACAC8384FA_NativeFunctionPtr;

		// Token: 0x04018183 RID: 98691
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_71EC0ADC497DCA9F71FA849635BAA6FF_NativeFunctionPtr;

		// Token: 0x04018184 RID: 98692
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_12D5B63A43BEA91A69FF3D9E09D44913_NativeFunctionPtr;

		// Token: 0x04018185 RID: 98693
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_D7667F094E190371575D33A294CA0593_NativeFunctionPtr;

		// Token: 0x04018186 RID: 98694
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_69A8D4C04D59E6FF9F2193AEC85AFDF1_NativeFunctionPtr;

		// Token: 0x04018187 RID: 98695
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F5F225C54097ECBAB698808B968544C3_NativeFunctionPtr;

		// Token: 0x04018188 RID: 98696
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_B6EF5A894136BA7E1B3EDC80AE42D783_NativeFunctionPtr;

		// Token: 0x04018189 RID: 98697
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_D40DD943485C763F153AF3BA5BAB8DF9_NativeFunctionPtr;

		// Token: 0x0401818A RID: 98698
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_F499CF534A6986E698D36BA4DB203A54_NativeFunctionPtr;

		// Token: 0x0401818B RID: 98699
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_8708BB834451E3EB4E59C3A2DD8C8D31_NativeFunctionPtr;

		// Token: 0x0401818C RID: 98700
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_AdditiveBoneBlend_972D5BA748C486E5C3BA5E84EBB7FFCC_NativeFunctionPtr;

		// Token: 0x0401818D RID: 98701
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_F9F80FF54FEAA113BD02F8B37CEB0812_NativeFunctionPtr;

		// Token: 0x0401818E RID: 98702
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_BC40A3A64A41A5541B6E4E9CC2DCD252_NativeFunctionPtr;

		// Token: 0x0401818F RID: 98703
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_EB879569483DECB6FA7ECDBC9C8E85C9_NativeFunctionPtr;

		// Token: 0x04018190 RID: 98704
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_A08277E44F1E71B8099434BDCD7E22E3_NativeFunctionPtr;

		// Token: 0x04018191 RID: 98705
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_DE70BB2449E575DC49A5BD9387AF8914_NativeFunctionPtr;

		// Token: 0x04018192 RID: 98706
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_FC5D00D046374EFAE6D4FF8757A2EC55_NativeFunctionPtr;

		// Token: 0x04018193 RID: 98707
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_62D69E7C4011BA6C967747B0331309B3_NativeFunctionPtr;

		// Token: 0x04018194 RID: 98708
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRoleNPC_AnimGraphNode_TransitionResult_35BF23864F2ECEFB8A627AA88F45D9DE_NativeFunctionPtr;

		// Token: 0x04018195 RID: 98709
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018196 RID: 98710
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018197 RID: 98711
		private static IntPtr __播放动画_NativeFunctionPtr;

		// Token: 0x04018198 RID: 98712
		private static IntPtr __AnimNotify_停止动画_NativeFunctionPtr;

		// Token: 0x04018199 RID: 98713
		private static IntPtr __OnComponentStart_NativeFunctionPtr;

		// Token: 0x0401819A RID: 98714
		private static IntPtr __MovementChanged_NativeFunctionPtr;

		// Token: 0x0401819B RID: 98715
		private static IntPtr __PlotBlendIn_NativeFunctionPtr;

		// Token: 0x0401819C RID: 98716
		private static IntPtr __NoExpose_NativeFunctionPtr;

		// Token: 0x0401819D RID: 98717
		private static IntPtr __AnimNotify_结束坐下_NativeFunctionPtr;

		// Token: 0x0401819E RID: 98718
		private static IntPtr __AnimNotify_进入坐下待机_NativeFunctionPtr;

		// Token: 0x0401819F RID: 98719
		private static IntPtr __AnimNotify_LeftStartSwing_NativeFunctionPtr;

		// Token: 0x040181A0 RID: 98720
		private static IntPtr __AnimNotify_LeftEndSwing_NativeFunctionPtr;

		// Token: 0x040181A1 RID: 98721
		private static IntPtr __AnimNotify_LeftLoopSwing_NativeFunctionPtr;

		// Token: 0x040181A2 RID: 98722
		private static IntPtr __ExecuteUbergraph_ABP_BaseRoleNPC_NativeFunctionPtr;

		// Token: 0x0200A3BF RID: 41919
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __骨骼混合叠加层_FunctionParams
		{
			// Token: 0x0403319F RID: 209311
			[FieldOffset(0)]
			public byte BaseLayer;

			// Token: 0x040331A0 RID: 209312
			[FieldOffset(24)]
			public byte OverlayLayer;

			// Token: 0x040331A1 RID: 209313
			[FieldOffset(48)]
			public byte BasePose;

			// Token: 0x040331A2 RID: 209314
			[FieldOffset(72)]
			public byte 骨骼混合叠加层;
		}

		// Token: 0x0200A3C0 RID: 41920
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础姿势层_FunctionParams
		{
			// Token: 0x040331A3 RID: 209315
			[FieldOffset(0)]
			public byte 基础姿势层;
		}

		// Token: 0x0200A3C1 RID: 41921
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __混合层_FunctionParams
		{
			// Token: 0x040331A4 RID: 209316
			[FieldOffset(0)]
			public byte 基础层输入;

			// Token: 0x040331A5 RID: 209317
			[FieldOffset(24)]
			public byte 叠加层输入;

			// Token: 0x040331A6 RID: 209318
			[FieldOffset(48)]
			public byte 姿势层输入;

			// Token: 0x040331A7 RID: 209319
			[FieldOffset(72)]
			public byte 手臂叠加层输入;

			// Token: 0x040331A8 RID: 209320
			[FieldOffset(96)]
			public byte 混合层;
		}

		// Token: 0x0200A3C2 RID: 41922
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __手臂叠加层_FunctionParams
		{
			// Token: 0x040331A9 RID: 209321
			[FieldOffset(0)]
			public byte 手臂叠加层;
		}

		// Token: 0x0200A3C3 RID: 41923
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __叠加层_FunctionParams
		{
			// Token: 0x040331AA RID: 209322
			[FieldOffset(0)]
			public byte 叠加层;
		}

		// Token: 0x0200A3C4 RID: 41924
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x040331AB RID: 209323
			[FieldOffset(0)]
			public byte 地区运动模式;

			// Token: 0x040331AC RID: 209324
			[FieldOffset(24)]
			public byte AnimGraph;
		}

		// Token: 0x0200A3C5 RID: 41925
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __设置头部转向状态_FunctionParams
		{
			// Token: 0x040331AD RID: 209325
			[FieldOffset(0)]
			public SightLockMode SightMode;
		}

		// Token: 0x0200A3C6 RID: 41926
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __更新头部转向_FunctionParams
		{
			// Token: 0x040331AE RID: 209326
			[FieldOffset(0)]
			public FRotator NewParam;
		}

		// Token: 0x0200A3C7 RID: 41927
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 6)]
		protected ref struct __是否需要移动_FunctionParams
		{
			// Token: 0x040331AF RID: 209327
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x0200A3C8 RID: 41928
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x040331B0 RID: 209328
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A3C9 RID: 41929
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __播放动画_FunctionParams
		{
			// Token: 0x040331B1 RID: 209329
			[FieldOffset(0)]
			public byte 播放动画;
		}

		// Token: 0x0200A3CA RID: 41930
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __MovementChanged_FunctionParams
		{
			// Token: 0x040331B2 RID: 209330
			[FieldOffset(0)]
			public IntPtr Character;

			// Token: 0x040331B3 RID: 209331
			[FieldOffset(8)]
			public TEnumAsByte<EMovementMode> PrevMovementMode;

			// Token: 0x040331B4 RID: 209332
			[FieldOffset(9)]
			public byte PreviousCustomMode;
		}

		// Token: 0x0200A3CB RID: 41931
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2864)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRoleNPC_FunctionParams
		{
			// Token: 0x040331B5 RID: 209333
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
