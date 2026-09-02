using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Tuanzi
{
	// Token: 0x020040DB RID: 16603
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Tuanzi/ABP_TuanziNPC.ABP_TuanziNPC_C")]
	[UnrealStructLayout(8496, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 8483)]
	public class ABP_TuanziNPC_C : UAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602B6E6 RID: 177894 RVA: 0x00A7C016 File Offset: 0x00A7A216
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_TuanziNPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Tuanzi/ABP_TuanziNPC.ABP_TuanziNPC_C");
			}
			return ABP_TuanziNPC_C._ClassPtr;
		}

		// Token: 0x0602B6E7 RID: 177895 RVA: 0x00A7C03C File Offset: 0x00A7A23C
		public ABP_TuanziNPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_TuanziNPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602B6E8 RID: 177896 RVA: 0x00A7C064 File Offset: 0x00A7A264
		public ABP_TuanziNPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_TuanziNPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170071C7 RID: 29127
		// (get) Token: 0x0602B6E9 RID: 177897 RVA: 0x00A7C098 File Offset: 0x00A7A298
		// (set) Token: 0x0602B6EA RID: 177898 RVA: 0x00A7C0D1 File Offset: 0x00A7A2D1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071C8 RID: 29128
		// (get) Token: 0x0602B6EB RID: 177899 RVA: 0x00A7C0F4 File Offset: 0x00A7A2F4
		// (set) Token: 0x0602B6EC RID: 177900 RVA: 0x00A7C12D File Offset: 0x00A7A32D
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071C9 RID: 29129
		// (get) Token: 0x0602B6ED RID: 177901 RVA: 0x00A7C150 File Offset: 0x00A7A350
		// (set) Token: 0x0602B6EE RID: 177902 RVA: 0x00A7C189 File Offset: 0x00A7A389
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071CA RID: 29130
		// (get) Token: 0x0602B6EF RID: 177903 RVA: 0x00A7C1AC File Offset: 0x00A7A3AC
		// (set) Token: 0x0602B6F0 RID: 177904 RVA: 0x00A7C1E5 File Offset: 0x00A7A3E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071CB RID: 29131
		// (get) Token: 0x0602B6F1 RID: 177905 RVA: 0x00A7C208 File Offset: 0x00A7A408
		// (set) Token: 0x0602B6F2 RID: 177906 RVA: 0x00A7C241 File Offset: 0x00A7A441
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071CC RID: 29132
		// (get) Token: 0x0602B6F3 RID: 177907 RVA: 0x00A7C264 File Offset: 0x00A7A464
		// (set) Token: 0x0602B6F4 RID: 177908 RVA: 0x00A7C29D File Offset: 0x00A7A49D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071CD RID: 29133
		// (get) Token: 0x0602B6F5 RID: 177909 RVA: 0x00A7C2C0 File Offset: 0x00A7A4C0
		// (set) Token: 0x0602B6F6 RID: 177910 RVA: 0x00A7C2F9 File Offset: 0x00A7A4F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071CE RID: 29134
		// (get) Token: 0x0602B6F7 RID: 177911 RVA: 0x00A7C31C File Offset: 0x00A7A51C
		// (set) Token: 0x0602B6F8 RID: 177912 RVA: 0x00A7C355 File Offset: 0x00A7A555
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071CF RID: 29135
		// (get) Token: 0x0602B6F9 RID: 177913 RVA: 0x00A7C378 File Offset: 0x00A7A578
		// (set) Token: 0x0602B6FA RID: 177914 RVA: 0x00A7C3B1 File Offset: 0x00A7A5B1
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer_1) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer_1 = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D0 RID: 29136
		// (get) Token: 0x0602B6FB RID: 177915 RVA: 0x00A7C3D4 File Offset: 0x00A7A5D4
		// (set) Token: 0x0602B6FC RID: 177916 RVA: 0x00A7C40D File Offset: 0x00A7A60D
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D1 RID: 29137
		// (get) Token: 0x0602B6FD RID: 177917 RVA: 0x00A7C430 File Offset: 0x00A7A630
		// (set) Token: 0x0602B6FE RID: 177918 RVA: 0x00A7C469 File Offset: 0x00A7A669
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D2 RID: 29138
		// (get) Token: 0x0602B6FF RID: 177919 RVA: 0x00A7C48C File Offset: 0x00A7A68C
		// (set) Token: 0x0602B700 RID: 177920 RVA: 0x00A7C4C5 File Offset: 0x00A7A6C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D3 RID: 29139
		// (get) Token: 0x0602B701 RID: 177921 RVA: 0x00A7C4E8 File Offset: 0x00A7A6E8
		// (set) Token: 0x0602B702 RID: 177922 RVA: 0x00A7C521 File Offset: 0x00A7A721
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D4 RID: 29140
		// (get) Token: 0x0602B703 RID: 177923 RVA: 0x00A7C544 File Offset: 0x00A7A744
		// (set) Token: 0x0602B704 RID: 177924 RVA: 0x00A7C57D File Offset: 0x00A7A77D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D5 RID: 29141
		// (get) Token: 0x0602B705 RID: 177925 RVA: 0x00A7C5A0 File Offset: 0x00A7A7A0
		// (set) Token: 0x0602B706 RID: 177926 RVA: 0x00A7C5D9 File Offset: 0x00A7A7D9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D6 RID: 29142
		// (get) Token: 0x0602B707 RID: 177927 RVA: 0x00A7C5FC File Offset: 0x00A7A7FC
		// (set) Token: 0x0602B708 RID: 177928 RVA: 0x00A7C635 File Offset: 0x00A7A835
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D7 RID: 29143
		// (get) Token: 0x0602B709 RID: 177929 RVA: 0x00A7C658 File Offset: 0x00A7A858
		// (set) Token: 0x0602B70A RID: 177930 RVA: 0x00A7C691 File Offset: 0x00A7A891
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D8 RID: 29144
		// (get) Token: 0x0602B70B RID: 177931 RVA: 0x00A7C6B4 File Offset: 0x00A7A8B4
		// (set) Token: 0x0602B70C RID: 177932 RVA: 0x00A7C6ED File Offset: 0x00A7A8ED
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071D9 RID: 29145
		// (get) Token: 0x0602B70D RID: 177933 RVA: 0x00A7C710 File Offset: 0x00A7A910
		// (set) Token: 0x0602B70E RID: 177934 RVA: 0x00A7C749 File Offset: 0x00A7A949
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071DA RID: 29146
		// (get) Token: 0x0602B70F RID: 177935 RVA: 0x00A7C76C File Offset: 0x00A7A96C
		// (set) Token: 0x0602B710 RID: 177936 RVA: 0x00A7C7A5 File Offset: 0x00A7A9A5
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071DB RID: 29147
		// (get) Token: 0x0602B711 RID: 177937 RVA: 0x00A7C7C8 File Offset: 0x00A7A9C8
		// (set) Token: 0x0602B712 RID: 177938 RVA: 0x00A7C801 File Offset: 0x00A7AA01
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071DC RID: 29148
		// (get) Token: 0x0602B713 RID: 177939 RVA: 0x00A7C824 File Offset: 0x00A7AA24
		// (set) Token: 0x0602B714 RID: 177940 RVA: 0x00A7C85D File Offset: 0x00A7AA5D
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071DD RID: 29149
		// (get) Token: 0x0602B715 RID: 177941 RVA: 0x00A7C880 File Offset: 0x00A7AA80
		// (set) Token: 0x0602B716 RID: 177942 RVA: 0x00A7C8B9 File Offset: 0x00A7AAB9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071DE RID: 29150
		// (get) Token: 0x0602B717 RID: 177943 RVA: 0x00A7C8DC File Offset: 0x00A7AADC
		// (set) Token: 0x0602B718 RID: 177944 RVA: 0x00A7C915 File Offset: 0x00A7AB15
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071DF RID: 29151
		// (get) Token: 0x0602B719 RID: 177945 RVA: 0x00A7C938 File Offset: 0x00A7AB38
		// (set) Token: 0x0602B71A RID: 177946 RVA: 0x00A7C971 File Offset: 0x00A7AB71
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E0 RID: 29152
		// (get) Token: 0x0602B71B RID: 177947 RVA: 0x00A7C994 File Offset: 0x00A7AB94
		// (set) Token: 0x0602B71C RID: 177948 RVA: 0x00A7C9CD File Offset: 0x00A7ABCD
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E1 RID: 29153
		// (get) Token: 0x0602B71D RID: 177949 RVA: 0x00A7C9F0 File Offset: 0x00A7ABF0
		// (set) Token: 0x0602B71E RID: 177950 RVA: 0x00A7CA29 File Offset: 0x00A7AC29
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E2 RID: 29154
		// (get) Token: 0x0602B71F RID: 177951 RVA: 0x00A7CA4C File Offset: 0x00A7AC4C
		// (set) Token: 0x0602B720 RID: 177952 RVA: 0x00A7CA85 File Offset: 0x00A7AC85
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E3 RID: 29155
		// (get) Token: 0x0602B721 RID: 177953 RVA: 0x00A7CAA8 File Offset: 0x00A7ACA8
		// (set) Token: 0x0602B722 RID: 177954 RVA: 0x00A7CAE1 File Offset: 0x00A7ACE1
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E4 RID: 29156
		// (get) Token: 0x0602B723 RID: 177955 RVA: 0x00A7CB04 File Offset: 0x00A7AD04
		// (set) Token: 0x0602B724 RID: 177956 RVA: 0x00A7CB3D File Offset: 0x00A7AD3D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E5 RID: 29157
		// (get) Token: 0x0602B725 RID: 177957 RVA: 0x00A7CB60 File Offset: 0x00A7AD60
		// (set) Token: 0x0602B726 RID: 177958 RVA: 0x00A7CB99 File Offset: 0x00A7AD99
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E6 RID: 29158
		// (get) Token: 0x0602B727 RID: 177959 RVA: 0x00A7CBBC File Offset: 0x00A7ADBC
		// (set) Token: 0x0602B728 RID: 177960 RVA: 0x00A7CBF5 File Offset: 0x00A7ADF5
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E7 RID: 29159
		// (get) Token: 0x0602B729 RID: 177961 RVA: 0x00A7CC18 File Offset: 0x00A7AE18
		// (set) Token: 0x0602B72A RID: 177962 RVA: 0x00A7CC51 File Offset: 0x00A7AE51
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E8 RID: 29160
		// (get) Token: 0x0602B72B RID: 177963 RVA: 0x00A7CC74 File Offset: 0x00A7AE74
		// (set) Token: 0x0602B72C RID: 177964 RVA: 0x00A7CCAD File Offset: 0x00A7AEAD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071E9 RID: 29161
		// (get) Token: 0x0602B72D RID: 177965 RVA: 0x00A7CCD0 File Offset: 0x00A7AED0
		// (set) Token: 0x0602B72E RID: 177966 RVA: 0x00A7CD09 File Offset: 0x00A7AF09
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071EA RID: 29162
		// (get) Token: 0x0602B72F RID: 177967 RVA: 0x00A7CD2C File Offset: 0x00A7AF2C
		// (set) Token: 0x0602B730 RID: 177968 RVA: 0x00A7CD65 File Offset: 0x00A7AF65
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071EB RID: 29163
		// (get) Token: 0x0602B731 RID: 177969 RVA: 0x00A7CD88 File Offset: 0x00A7AF88
		// (set) Token: 0x0602B732 RID: 177970 RVA: 0x00A7CDC1 File Offset: 0x00A7AFC1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071EC RID: 29164
		// (get) Token: 0x0602B733 RID: 177971 RVA: 0x00A7CDE4 File Offset: 0x00A7AFE4
		// (set) Token: 0x0602B734 RID: 177972 RVA: 0x00A7CE1D File Offset: 0x00A7B01D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071ED RID: 29165
		// (get) Token: 0x0602B735 RID: 177973 RVA: 0x00A7CE40 File Offset: 0x00A7B040
		// (set) Token: 0x0602B736 RID: 177974 RVA: 0x00A7CE79 File Offset: 0x00A7B079
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071EE RID: 29166
		// (get) Token: 0x0602B737 RID: 177975 RVA: 0x00A7CE9C File Offset: 0x00A7B09C
		// (set) Token: 0x0602B738 RID: 177976 RVA: 0x00A7CED5 File Offset: 0x00A7B0D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071EF RID: 29167
		// (get) Token: 0x0602B739 RID: 177977 RVA: 0x00A7CEF8 File Offset: 0x00A7B0F8
		// (set) Token: 0x0602B73A RID: 177978 RVA: 0x00A7CF31 File Offset: 0x00A7B131
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F0 RID: 29168
		// (get) Token: 0x0602B73B RID: 177979 RVA: 0x00A7CF54 File Offset: 0x00A7B154
		// (set) Token: 0x0602B73C RID: 177980 RVA: 0x00A7CF8D File Offset: 0x00A7B18D
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F1 RID: 29169
		// (get) Token: 0x0602B73D RID: 177981 RVA: 0x00A7CFB0 File Offset: 0x00A7B1B0
		// (set) Token: 0x0602B73E RID: 177982 RVA: 0x00A7CFE9 File Offset: 0x00A7B1E9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F2 RID: 29170
		// (get) Token: 0x0602B73F RID: 177983 RVA: 0x00A7D00C File Offset: 0x00A7B20C
		// (set) Token: 0x0602B740 RID: 177984 RVA: 0x00A7D045 File Offset: 0x00A7B245
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F3 RID: 29171
		// (get) Token: 0x0602B741 RID: 177985 RVA: 0x00A7D068 File Offset: 0x00A7B268
		// (set) Token: 0x0602B742 RID: 177986 RVA: 0x00A7D0A1 File Offset: 0x00A7B2A1
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F4 RID: 29172
		// (get) Token: 0x0602B743 RID: 177987 RVA: 0x00A7D0C4 File Offset: 0x00A7B2C4
		// (set) Token: 0x0602B744 RID: 177988 RVA: 0x00A7D0FD File Offset: 0x00A7B2FD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F5 RID: 29173
		// (get) Token: 0x0602B745 RID: 177989 RVA: 0x00A7D120 File Offset: 0x00A7B320
		// (set) Token: 0x0602B746 RID: 177990 RVA: 0x00A7D159 File Offset: 0x00A7B359
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F6 RID: 29174
		// (get) Token: 0x0602B747 RID: 177991 RVA: 0x00A7D17C File Offset: 0x00A7B37C
		// (set) Token: 0x0602B748 RID: 177992 RVA: 0x00A7D1B5 File Offset: 0x00A7B3B5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F7 RID: 29175
		// (get) Token: 0x0602B749 RID: 177993 RVA: 0x00A7D1D8 File Offset: 0x00A7B3D8
		// (set) Token: 0x0602B74A RID: 177994 RVA: 0x00A7D211 File Offset: 0x00A7B411
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F8 RID: 29176
		// (get) Token: 0x0602B74B RID: 177995 RVA: 0x00A7D234 File Offset: 0x00A7B434
		// (set) Token: 0x0602B74C RID: 177996 RVA: 0x00A7D26D File Offset: 0x00A7B46D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071F9 RID: 29177
		// (get) Token: 0x0602B74D RID: 177997 RVA: 0x00A7D290 File Offset: 0x00A7B490
		// (set) Token: 0x0602B74E RID: 177998 RVA: 0x00A7D2C9 File Offset: 0x00A7B4C9
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071FA RID: 29178
		// (get) Token: 0x0602B74F RID: 177999 RVA: 0x00A7D2EC File Offset: 0x00A7B4EC
		// (set) Token: 0x0602B750 RID: 178000 RVA: 0x00A7D325 File Offset: 0x00A7B525
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071FB RID: 29179
		// (get) Token: 0x0602B751 RID: 178001 RVA: 0x00A7D348 File Offset: 0x00A7B548
		// (set) Token: 0x0602B752 RID: 178002 RVA: 0x00A7D381 File Offset: 0x00A7B581
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170071FC RID: 29180
		// (get) Token: 0x0602B753 RID: 178003 RVA: 0x00A7D3A2 File Offset: 0x00A7B5A2
		// (set) Token: 0x0602B754 RID: 178004 RVA: 0x00A7D3B2 File Offset: 0x00A7B5B2
		public unsafe float JumpHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x170071FD RID: 29181
		// (get) Token: 0x0602B755 RID: 178005 RVA: 0x00A7D3C3 File Offset: 0x00A7B5C3
		// (set) Token: 0x0602B756 RID: 178006 RVA: 0x00A7D3D3 File Offset: 0x00A7B5D3
		public unsafe float JumpDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_54);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_54) = value;
			}
		}

		// Token: 0x170071FE RID: 29182
		// (get) Token: 0x0602B757 RID: 178007 RVA: 0x00A7D3E4 File Offset: 0x00A7B5E4
		// (set) Token: 0x0602B758 RID: 178008 RVA: 0x00A7D3F8 File Offset: 0x00A7B5F8
		[Nullable(0)]
		public unsafe TEnumAsByte<EDangoState> CurrentState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_55);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_55) = value;
			}
		}

		// Token: 0x170071FF RID: 29183
		// (get) Token: 0x0602B759 RID: 178009 RVA: 0x00A7D40D File Offset: 0x00A7B60D
		// (set) Token: 0x0602B75A RID: 178010 RVA: 0x00A7D41D File Offset: 0x00A7B61D
		public unsafe bool IsBeginStandbyPerform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_56) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_56) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007200 RID: 29184
		// (get) Token: 0x0602B75B RID: 178011 RVA: 0x00A7D42E File Offset: 0x00A7B62E
		// (set) Token: 0x0602B75C RID: 178012 RVA: 0x00A7D43E File Offset: 0x00A7B63E
		public unsafe int StandbyPerformIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x17007201 RID: 29185
		// (get) Token: 0x0602B75D RID: 178013 RVA: 0x00A7D44F File Offset: 0x00A7B64F
		// (set) Token: 0x0602B75E RID: 178014 RVA: 0x00A7D463 File Offset: 0x00A7B663
		[Nullable(0)]
		public unsafe TEnumAsByte<EDangoActionPerformType> ActionPerformType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_58);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_58) = value;
			}
		}

		// Token: 0x17007202 RID: 29186
		// (get) Token: 0x0602B75F RID: 178015 RVA: 0x00A7D478 File Offset: 0x00A7B678
		// (set) Token: 0x0602B760 RID: 178016 RVA: 0x00A7D488 File Offset: 0x00A7B688
		public unsafe bool IsJumpForward
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_59) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_59) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007203 RID: 29187
		// (get) Token: 0x0602B761 RID: 178017 RVA: 0x00A7D499 File Offset: 0x00A7B699
		// (set) Token: 0x0602B762 RID: 178018 RVA: 0x00A7D4A9 File Offset: 0x00A7B6A9
		public unsafe bool bForceReturnToStand
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_60) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_TuanziNPC_C.__PropertyOffset_60) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602B763 RID: 178019 RVA: 0x00A7D4BC File Offset: 0x00A7B6BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_TuanziNPC_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_TuanziNPC_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_TuanziNPC_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_TuanziNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602B764 RID: 178020 RVA: 0x00A7D544 File Offset: 0x00A7B744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void StartJumpBackwardWithParams(float JumpHeight, float JumpDistance)
		{
			ABP_TuanziNPC_C.__StartJumpBackwardWithParams_FunctionParams* ptr = stackalloc ABP_TuanziNPC_C.__StartJumpBackwardWithParams_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_TuanziNPC_C.__StartJumpBackwardWithParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_TuanziNPC_C.__StartJumpBackwardWithParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->JumpHeight = JumpHeight;
			ptr->JumpDistance = JumpDistance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__StartJumpBackwardWithParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B765 RID: 178021 RVA: 0x00A7D591 File Offset: 0x00A7B791
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReturnStand()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__ReturnStand_NativeFunctionPtr, null);
		}

		// Token: 0x0602B766 RID: 178022 RVA: 0x00A7D5A8 File Offset: 0x00A7B7A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void StartActionPerform(EDangoActionPerformType ActionPerformType)
		{
			ABP_TuanziNPC_C.__StartActionPerform_FunctionParams* ptr = stackalloc ABP_TuanziNPC_C.__StartActionPerform_FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(ABP_TuanziNPC_C.__StartActionPerform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_TuanziNPC_C.__StartActionPerform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ActionPerformType = ActionPerformType;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__StartActionPerform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B767 RID: 178023 RVA: 0x00A7D5F4 File Offset: 0x00A7B7F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void StartStandPerform(int StandbyPerformIndex)
		{
			ABP_TuanziNPC_C.__StartStandPerform_FunctionParams* ptr = stackalloc ABP_TuanziNPC_C.__StartStandPerform_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(ABP_TuanziNPC_C.__StartStandPerform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_TuanziNPC_C.__StartStandPerform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->StandbyPerformIndex = StandbyPerformIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__StartStandPerform_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B768 RID: 178024 RVA: 0x00A7D63C File Offset: 0x00A7B83C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void StartJumpWithParams(float JumpHeight, float JumpDistance)
		{
			ABP_TuanziNPC_C.__StartJumpWithParams_FunctionParams* ptr = stackalloc ABP_TuanziNPC_C.__StartJumpWithParams_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_TuanziNPC_C.__StartJumpWithParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_TuanziNPC_C.__StartJumpWithParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->JumpHeight = JumpHeight;
			ptr->JumpDistance = JumpDistance;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__StartJumpWithParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602B769 RID: 178025 RVA: 0x00A7D689 File Offset: 0x00A7B889
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_188C7285479D9BB3785B6DAC5091568B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_188C7285479D9BB3785B6DAC5091568B_NativeFunctionPtr, null);
		}

		// Token: 0x0602B76A RID: 178026 RVA: 0x00A7D69D File Offset: 0x00A7B89D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_0BEB6B24419138953B61C2A8AB85BA66()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_0BEB6B24419138953B61C2A8AB85BA66_NativeFunctionPtr, null);
		}

		// Token: 0x0602B76B RID: 178027 RVA: 0x00A7D6B1 File Offset: 0x00A7B8B1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_2920ED2A440CA8F6E53428AD01A924B3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_2920ED2A440CA8F6E53428AD01A924B3_NativeFunctionPtr, null);
		}

		// Token: 0x0602B76C RID: 178028 RVA: 0x00A7D6C5 File Offset: 0x00A7B8C5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_3D6F71D2455013442B5C118CEE0E3DD0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_3D6F71D2455013442B5C118CEE0E3DD0_NativeFunctionPtr, null);
		}

		// Token: 0x0602B76D RID: 178029 RVA: 0x00A7D6D9 File Offset: 0x00A7B8D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_5A410B24466BF91103BB4C9CE8230F1C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_5A410B24466BF91103BB4C9CE8230F1C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B76E RID: 178030 RVA: 0x00A7D6ED File Offset: 0x00A7B8ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_888AD5434F155117414A12AEDB68A107()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_888AD5434F155117414A12AEDB68A107_NativeFunctionPtr, null);
		}

		// Token: 0x0602B76F RID: 178031 RVA: 0x00A7D701 File Offset: 0x00A7B901
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_CF5E4B6F4CE93F28CA1D248CF3035AB8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_CF5E4B6F4CE93F28CA1D248CF3035AB8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B770 RID: 178032 RVA: 0x00A7D715 File Offset: 0x00A7B915
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_9DF711924C4513F022CF069D22C29764()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_9DF711924C4513F022CF069D22C29764_NativeFunctionPtr, null);
		}

		// Token: 0x0602B771 RID: 178033 RVA: 0x00A7D729 File Offset: 0x00A7B929
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_AD26B72E4225BB033C5F8182BD977A12()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_AD26B72E4225BB033C5F8182BD977A12_NativeFunctionPtr, null);
		}

		// Token: 0x0602B772 RID: 178034 RVA: 0x00A7D73D File Offset: 0x00A7B93D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_2A2F14D04F8147316ADE098A7F2EE764()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_2A2F14D04F8147316ADE098A7F2EE764_NativeFunctionPtr, null);
		}

		// Token: 0x0602B773 RID: 178035 RVA: 0x00A7D751 File Offset: 0x00A7B951
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_DC6865914650CCDB672BF7AE6545F4F8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_DC6865914650CCDB672BF7AE6545F4F8_NativeFunctionPtr, null);
		}

		// Token: 0x0602B774 RID: 178036 RVA: 0x00A7D765 File Offset: 0x00A7B965
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_9053EEF848DC0656DADD2B9FA736A622()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_9053EEF848DC0656DADD2B9FA736A622_NativeFunctionPtr, null);
		}

		// Token: 0x0602B775 RID: 178037 RVA: 0x00A7D779 File Offset: 0x00A7B979
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_ACA38FCD4269FC97143C75A45C2F2CAE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_ACA38FCD4269FC97143C75A45C2F2CAE_NativeFunctionPtr, null);
		}

		// Token: 0x0602B776 RID: 178038 RVA: 0x00A7D78D File Offset: 0x00A7B98D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_4F85DBF34A4FCFB1A151FD8F2949C67C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_4F85DBF34A4FCFB1A151FD8F2949C67C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B777 RID: 178039 RVA: 0x00A7D7A1 File Offset: 0x00A7B9A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_6E2AB8ED44C63C0C89BA52A99A54B476()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_6E2AB8ED44C63C0C89BA52A99A54B476_NativeFunctionPtr, null);
		}

		// Token: 0x0602B778 RID: 178040 RVA: 0x00A7D7B5 File Offset: 0x00A7B9B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_5179572040A31BDEEF83148F170F0F1C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_5179572040A31BDEEF83148F170F0F1C_NativeFunctionPtr, null);
		}

		// Token: 0x0602B779 RID: 178041 RVA: 0x00A7D7C9 File Offset: 0x00A7B9C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnStand()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__AnimNotify_OnStand_NativeFunctionPtr, null);
		}

		// Token: 0x0602B77A RID: 178042 RVA: 0x00A7D7DD File Offset: 0x00A7B9DD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_OnStandPerform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_TuanziNPC_C.__AnimNotify_OnStandPerform_NativeFunctionPtr, null);
		}

		// Token: 0x0602B77B RID: 178043 RVA: 0x00A7D7F4 File Offset: 0x00A7B9F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_TuanziNPC(int EntryPoint)
		{
			ABP_TuanziNPC_C.__ExecuteUbergraph_ABP_TuanziNPC_FunctionParams* ptr = stackalloc ABP_TuanziNPC_C.__ExecuteUbergraph_ABP_TuanziNPC_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(ABP_TuanziNPC_C.__ExecuteUbergraph_ABP_TuanziNPC_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_TuanziNPC_C.__ExecuteUbergraph_ABP_TuanziNPC_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_TuanziNPC_C.__ExecuteUbergraph_ABP_TuanziNPC_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602B77C RID: 178044 RVA: 0x00A7D83B File Offset: 0x00A7BA3B
		protected ABP_TuanziNPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017D2E RID: 97582
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Tuanzi/ABP_TuanziNPC.ABP_TuanziNPC_C";

		// Token: 0x04017D2F RID: 97583
		private static IntPtr _ClassPtr;

		// Token: 0x04017D30 RID: 97584
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017D31 RID: 97585
		internal static int __PropertyOffset_0;

		// Token: 0x04017D32 RID: 97586
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04017D33 RID: 97587
		internal static int __PropertyOffset_1;

		// Token: 0x04017D34 RID: 97588
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04017D35 RID: 97589
		internal static int __PropertyOffset_2;

		// Token: 0x04017D36 RID: 97590
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04017D37 RID: 97591
		internal static int __PropertyOffset_3;

		// Token: 0x04017D38 RID: 97592
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04017D39 RID: 97593
		internal static int __PropertyOffset_4;

		// Token: 0x04017D3A RID: 97594
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04017D3B RID: 97595
		internal static int __PropertyOffset_5;

		// Token: 0x04017D3C RID: 97596
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x04017D3D RID: 97597
		internal static int __PropertyOffset_6;

		// Token: 0x04017D3E RID: 97598
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x04017D3F RID: 97599
		internal static int __PropertyOffset_7;

		// Token: 0x04017D40 RID: 97600
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x04017D41 RID: 97601
		internal static int __PropertyOffset_8;

		// Token: 0x04017D42 RID: 97602
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer_1;

		// Token: 0x04017D43 RID: 97603
		internal static int __PropertyOffset_9;

		// Token: 0x04017D44 RID: 97604
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x04017D45 RID: 97605
		internal static int __PropertyOffset_10;

		// Token: 0x04017D46 RID: 97606
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04017D47 RID: 97607
		internal static int __PropertyOffset_11;

		// Token: 0x04017D48 RID: 97608
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04017D49 RID: 97609
		internal static int __PropertyOffset_12;

		// Token: 0x04017D4A RID: 97610
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04017D4B RID: 97611
		internal static int __PropertyOffset_13;

		// Token: 0x04017D4C RID: 97612
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04017D4D RID: 97613
		internal static int __PropertyOffset_14;

		// Token: 0x04017D4E RID: 97614
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04017D4F RID: 97615
		internal static int __PropertyOffset_15;

		// Token: 0x04017D50 RID: 97616
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04017D51 RID: 97617
		internal static int __PropertyOffset_16;

		// Token: 0x04017D52 RID: 97618
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04017D53 RID: 97619
		internal static int __PropertyOffset_17;

		// Token: 0x04017D54 RID: 97620
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04017D55 RID: 97621
		internal static int __PropertyOffset_18;

		// Token: 0x04017D56 RID: 97622
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04017D57 RID: 97623
		internal static int __PropertyOffset_19;

		// Token: 0x04017D58 RID: 97624
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x04017D59 RID: 97625
		internal static int __PropertyOffset_20;

		// Token: 0x04017D5A RID: 97626
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04017D5B RID: 97627
		internal static int __PropertyOffset_21;

		// Token: 0x04017D5C RID: 97628
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x04017D5D RID: 97629
		internal static int __PropertyOffset_22;

		// Token: 0x04017D5E RID: 97630
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04017D5F RID: 97631
		internal static int __PropertyOffset_23;

		// Token: 0x04017D60 RID: 97632
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04017D61 RID: 97633
		internal static int __PropertyOffset_24;

		// Token: 0x04017D62 RID: 97634
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04017D63 RID: 97635
		internal static int __PropertyOffset_25;

		// Token: 0x04017D64 RID: 97636
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04017D65 RID: 97637
		internal static int __PropertyOffset_26;

		// Token: 0x04017D66 RID: 97638
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04017D67 RID: 97639
		internal static int __PropertyOffset_27;

		// Token: 0x04017D68 RID: 97640
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x04017D69 RID: 97641
		internal static int __PropertyOffset_28;

		// Token: 0x04017D6A RID: 97642
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04017D6B RID: 97643
		internal static int __PropertyOffset_29;

		// Token: 0x04017D6C RID: 97644
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x04017D6D RID: 97645
		internal static int __PropertyOffset_30;

		// Token: 0x04017D6E RID: 97646
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04017D6F RID: 97647
		internal static int __PropertyOffset_31;

		// Token: 0x04017D70 RID: 97648
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04017D71 RID: 97649
		internal static int __PropertyOffset_32;

		// Token: 0x04017D72 RID: 97650
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04017D73 RID: 97651
		internal static int __PropertyOffset_33;

		// Token: 0x04017D74 RID: 97652
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04017D75 RID: 97653
		internal static int __PropertyOffset_34;

		// Token: 0x04017D76 RID: 97654
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04017D77 RID: 97655
		internal static int __PropertyOffset_35;

		// Token: 0x04017D78 RID: 97656
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04017D79 RID: 97657
		internal static int __PropertyOffset_36;

		// Token: 0x04017D7A RID: 97658
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04017D7B RID: 97659
		internal static int __PropertyOffset_37;

		// Token: 0x04017D7C RID: 97660
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04017D7D RID: 97661
		internal static int __PropertyOffset_38;

		// Token: 0x04017D7E RID: 97662
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04017D7F RID: 97663
		internal static int __PropertyOffset_39;

		// Token: 0x04017D80 RID: 97664
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x04017D81 RID: 97665
		internal static int __PropertyOffset_40;

		// Token: 0x04017D82 RID: 97666
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04017D83 RID: 97667
		internal static int __PropertyOffset_41;

		// Token: 0x04017D84 RID: 97668
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04017D85 RID: 97669
		internal static int __PropertyOffset_42;

		// Token: 0x04017D86 RID: 97670
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04017D87 RID: 97671
		internal static int __PropertyOffset_43;

		// Token: 0x04017D88 RID: 97672
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04017D89 RID: 97673
		internal static int __PropertyOffset_44;

		// Token: 0x04017D8A RID: 97674
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04017D8B RID: 97675
		internal static int __PropertyOffset_45;

		// Token: 0x04017D8C RID: 97676
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04017D8D RID: 97677
		internal static int __PropertyOffset_46;

		// Token: 0x04017D8E RID: 97678
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04017D8F RID: 97679
		internal static int __PropertyOffset_47;

		// Token: 0x04017D90 RID: 97680
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04017D91 RID: 97681
		internal static int __PropertyOffset_48;

		// Token: 0x04017D92 RID: 97682
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04017D93 RID: 97683
		internal static int __PropertyOffset_49;

		// Token: 0x04017D94 RID: 97684
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04017D95 RID: 97685
		internal static int __PropertyOffset_50;

		// Token: 0x04017D96 RID: 97686
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04017D97 RID: 97687
		internal static int __PropertyOffset_51;

		// Token: 0x04017D98 RID: 97688
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04017D99 RID: 97689
		internal static int __PropertyOffset_52;

		// Token: 0x04017D9A RID: 97690
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04017D9B RID: 97691
		internal static int __PropertyOffset_53;

		// Token: 0x04017D9C RID: 97692
		internal static int __PropertyOffset_54;

		// Token: 0x04017D9D RID: 97693
		internal static int __PropertyOffset_55;

		// Token: 0x04017D9E RID: 97694
		internal static int __PropertyOffset_56;

		// Token: 0x04017D9F RID: 97695
		internal static int __PropertyOffset_57;

		// Token: 0x04017DA0 RID: 97696
		internal static int __PropertyOffset_58;

		// Token: 0x04017DA1 RID: 97697
		internal static int __PropertyOffset_59;

		// Token: 0x04017DA2 RID: 97698
		internal static int __PropertyOffset_60;

		// Token: 0x04017DA3 RID: 97699
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04017DA4 RID: 97700
		private static IntPtr __StartJumpBackwardWithParams_NativeFunctionPtr;

		// Token: 0x04017DA5 RID: 97701
		private static IntPtr __ReturnStand_NativeFunctionPtr;

		// Token: 0x04017DA6 RID: 97702
		private static IntPtr __StartActionPerform_NativeFunctionPtr;

		// Token: 0x04017DA7 RID: 97703
		private static IntPtr __StartStandPerform_NativeFunctionPtr;

		// Token: 0x04017DA8 RID: 97704
		private static IntPtr __StartJumpWithParams_NativeFunctionPtr;

		// Token: 0x04017DA9 RID: 97705
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_188C7285479D9BB3785B6DAC5091568B_NativeFunctionPtr;

		// Token: 0x04017DAA RID: 97706
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_0BEB6B24419138953B61C2A8AB85BA66_NativeFunctionPtr;

		// Token: 0x04017DAB RID: 97707
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_2920ED2A440CA8F6E53428AD01A924B3_NativeFunctionPtr;

		// Token: 0x04017DAC RID: 97708
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_3D6F71D2455013442B5C118CEE0E3DD0_NativeFunctionPtr;

		// Token: 0x04017DAD RID: 97709
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_5A410B24466BF91103BB4C9CE8230F1C_NativeFunctionPtr;

		// Token: 0x04017DAE RID: 97710
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_888AD5434F155117414A12AEDB68A107_NativeFunctionPtr;

		// Token: 0x04017DAF RID: 97711
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_CF5E4B6F4CE93F28CA1D248CF3035AB8_NativeFunctionPtr;

		// Token: 0x04017DB0 RID: 97712
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_9DF711924C4513F022CF069D22C29764_NativeFunctionPtr;

		// Token: 0x04017DB1 RID: 97713
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_AD26B72E4225BB033C5F8182BD977A12_NativeFunctionPtr;

		// Token: 0x04017DB2 RID: 97714
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_2A2F14D04F8147316ADE098A7F2EE764_NativeFunctionPtr;

		// Token: 0x04017DB3 RID: 97715
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_DC6865914650CCDB672BF7AE6545F4F8_NativeFunctionPtr;

		// Token: 0x04017DB4 RID: 97716
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_9053EEF848DC0656DADD2B9FA736A622_NativeFunctionPtr;

		// Token: 0x04017DB5 RID: 97717
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_ACA38FCD4269FC97143C75A45C2F2CAE_NativeFunctionPtr;

		// Token: 0x04017DB6 RID: 97718
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_4F85DBF34A4FCFB1A151FD8F2949C67C_NativeFunctionPtr;

		// Token: 0x04017DB7 RID: 97719
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_6E2AB8ED44C63C0C89BA52A99A54B476_NativeFunctionPtr;

		// Token: 0x04017DB8 RID: 97720
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_TuanziNPC_AnimGraphNode_TransitionResult_5179572040A31BDEEF83148F170F0F1C_NativeFunctionPtr;

		// Token: 0x04017DB9 RID: 97721
		private static IntPtr __AnimNotify_OnStand_NativeFunctionPtr;

		// Token: 0x04017DBA RID: 97722
		private static IntPtr __AnimNotify_OnStandPerform_NativeFunctionPtr;

		// Token: 0x04017DBB RID: 97723
		private static IntPtr __ExecuteUbergraph_ABP_TuanziNPC_NativeFunctionPtr;

		// Token: 0x0200A3B9 RID: 41913
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033197 RID: 209303
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A3BA RID: 41914
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __StartJumpBackwardWithParams_FunctionParams
		{
			// Token: 0x04033198 RID: 209304
			[FieldOffset(0)]
			public float JumpHeight;

			// Token: 0x04033199 RID: 209305
			[FieldOffset(4)]
			public float JumpDistance;
		}

		// Token: 0x0200A3BB RID: 41915
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __StartActionPerform_FunctionParams
		{
			// Token: 0x0403319A RID: 209306
			[FieldOffset(0)]
			public TEnumAsByte<EDangoActionPerformType> ActionPerformType;
		}

		// Token: 0x0200A3BC RID: 41916
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __StartStandPerform_FunctionParams
		{
			// Token: 0x0403319B RID: 209307
			[FieldOffset(0)]
			public int StandbyPerformIndex;
		}

		// Token: 0x0200A3BD RID: 41917
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __StartJumpWithParams_FunctionParams
		{
			// Token: 0x0403319C RID: 209308
			[FieldOffset(0)]
			public float JumpHeight;

			// Token: 0x0403319D RID: 209309
			[FieldOffset(4)]
			public float JumpDistance;
		}

		// Token: 0x0200A3BE RID: 41918
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_ABP_TuanziNPC_FunctionParams
		{
			// Token: 0x0403319E RID: 209310
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
