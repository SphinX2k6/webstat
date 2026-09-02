using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Sequence.Manager.Enum;
using AkiClient.Game.Aki.Sequence.Manager.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Sequence.Manager
{
	// Token: 0x020043AF RID: 17327
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/SSequencesNetwrokNode.SSequencesNetwrokNode")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 92)]
	public class SSequencesNetwrokNode : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E166 RID: 188774 RVA: 0x00AD675E File Offset: 0x00AD495E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSequencesNetwrokNode._ScriptStructPtr != 0) ? SSequencesNetwrokNode._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/SSequencesNetwrokNode.SSequencesNetwrokNode", ref SSequencesNetwrokNode._ScriptStructPtr);
		}

		// Token: 0x17007EF2 RID: 32498
		// (get) Token: 0x0602E167 RID: 188775 RVA: 0x00AD6782 File Offset: 0x00AD4982
		// (set) Token: 0x0602E168 RID: 188776 RVA: 0x00AD6796 File Offset: 0x00AD4996
		public unsafe FName SeqNodeID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007EF3 RID: 32499
		// (get) Token: 0x0602E169 RID: 188777 RVA: 0x00AD67AB File Offset: 0x00AD49AB
		// (set) Token: 0x0602E16A RID: 188778 RVA: 0x00AD67BF File Offset: 0x00AD49BF
		public unsafe FName PreSeqNodeID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007EF4 RID: 32500
		// (get) Token: 0x0602E16B RID: 188779 RVA: 0x00AD67D4 File Offset: 0x00AD49D4
		// (set) Token: 0x0602E16C RID: 188780 RVA: 0x00AD6817 File Offset: 0x00AD4A17
		[Nullable(1)]
		public FSoftObjectPath SeqNodeData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._SeqNodeData) == null)
				{
					result = (this._SeqNodeData = new FSoftObjectPath(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007EF5 RID: 32501
		// (get) Token: 0x0602E16D RID: 188781 RVA: 0x00AD6838 File Offset: 0x00AD4A38
		// (set) Token: 0x0602E16E RID: 188782 RVA: 0x00AD6848 File Offset: 0x00AD4A48
		public unsafe bool 是否禁止输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EF6 RID: 32502
		// (get) Token: 0x0602E16F RID: 188783 RVA: 0x00AD6859 File Offset: 0x00AD4A59
		// (set) Token: 0x0602E170 RID: 188784 RVA: 0x00AD6869 File Offset: 0x00AD4A69
		public unsafe bool 是否禁止视角控制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EF7 RID: 32503
		// (get) Token: 0x0602E171 RID: 188785 RVA: 0x00AD687A File Offset: 0x00AD4A7A
		// (set) Token: 0x0602E172 RID: 188786 RVA: 0x00AD688A File Offset: 0x00AD4A8A
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007EF8 RID: 32504
		// (get) Token: 0x0602E173 RID: 188787 RVA: 0x00AD689B File Offset: 0x00AD4A9B
		// (set) Token: 0x0602E174 RID: 188788 RVA: 0x00AD68AB File Offset: 0x00AD4AAB
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007EF9 RID: 32505
		// (get) Token: 0x0602E175 RID: 188789 RVA: 0x00AD68BC File Offset: 0x00AD4ABC
		// (set) Token: 0x0602E176 RID: 188790 RVA: 0x00AD68D0 File Offset: 0x00AD4AD0
		public unsafe TEnumAsByte<ESeqSwtichType> 跳转类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007EFA RID: 32506
		// (get) Token: 0x0602E177 RID: 188791 RVA: 0x00AD68E8 File Offset: 0x00AD4AE8
		// (set) Token: 0x0602E178 RID: 188792 RVA: 0x00AD692B File Offset: 0x00AD4B2B
		[Nullable(1)]
		public TArray<SSeqOptionJumpGroup> 选项跳转组
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SSeqOptionJumpGroup> result;
				if ((result = this._选项跳转组) == null)
				{
					result = (this._选项跳转组 = new TArray<SSeqOptionJumpGroup>(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.选项跳转组.CopyAssign(value);
			}
		}

		// Token: 0x17007EFB RID: 32507
		// (get) Token: 0x0602E179 RID: 188793 RVA: 0x00AD6939 File Offset: 0x00AD4B39
		// (set) Token: 0x0602E17A RID: 188794 RVA: 0x00AD694D File Offset: 0x00AD4B4D
		public unsafe TEnumAsByte<SeqCameraMode> 相机模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007EFC RID: 32508
		// (get) Token: 0x0602E17B RID: 188795 RVA: 0x00AD6962 File Offset: 0x00AD4B62
		// (set) Token: 0x0602E17C RID: 188796 RVA: 0x00AD6972 File Offset: 0x00AD4B72
		public unsafe bool 是否隐藏其他UI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EFD RID: 32509
		// (get) Token: 0x0602E17D RID: 188797 RVA: 0x00AD6983 File Offset: 0x00AD4B83
		// (set) Token: 0x0602E17E RID: 188798 RVA: 0x00AD6993 File Offset: 0x00AD4B93
		public unsafe bool 是否可跳过
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007EFE RID: 32510
		// (get) Token: 0x0602E17F RID: 188799 RVA: 0x00AD69A4 File Offset: 0x00AD4BA4
		// (set) Token: 0x0602E180 RID: 188800 RVA: 0x00AD69B4 File Offset: 0x00AD4BB4
		public unsafe bool 是否可交互
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSequencesNetwrokNode.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602E181 RID: 188801 RVA: 0x00AD69C5 File Offset: 0x00AD4BC5
		public SSequencesNetwrokNode()
		{
		}

		// Token: 0x0602E182 RID: 188802 RVA: 0x00AD69D0 File Offset: 0x00AD4BD0
		public SSequencesNetwrokNode(FName SeqNodeID, FName PreSeqNodeID, [Nullable(1)] FSoftObjectPath SeqNodeData, bool 是否禁止输入, bool 是否禁止视角控制, float BlendInTime, float BlendOutTime, TEnumAsByte<ESeqSwtichType> 跳转类型, [Nullable(1)] TArray<SSeqOptionJumpGroup> 选项跳转组, TEnumAsByte<SeqCameraMode> 相机模式, bool 是否隐藏其他UI, bool 是否可跳过, bool 是否可交互)
		{
			this.SeqNodeID = SeqNodeID;
			this.PreSeqNodeID = PreSeqNodeID;
			this.SeqNodeData = SeqNodeData;
			this.是否禁止输入 = 是否禁止输入;
			this.是否禁止视角控制 = 是否禁止视角控制;
			this.BlendInTime = BlendInTime;
			this.BlendOutTime = BlendOutTime;
			this.跳转类型 = 跳转类型;
			this.选项跳转组 = 选项跳转组;
			this.相机模式 = 相机模式;
			this.是否隐藏其他UI = 是否隐藏其他UI;
			this.是否可跳过 = 是否可跳过;
			this.是否可交互 = 是否可交互;
		}

		// Token: 0x0602E183 RID: 188803 RVA: 0x00AD6A48 File Offset: 0x00AD4C48
		protected override IntPtr GetUStructPtr()
		{
			return SSequencesNetwrokNode.StaticStruct();
		}

		// Token: 0x0602E184 RID: 188804 RVA: 0x00AD6A54 File Offset: 0x00AD4C54
		[NullableContext(2)]
		public SSequencesNetwrokNode(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E185 RID: 188805 RVA: 0x00AD6A5E File Offset: 0x00AD4C5E
		public SSequencesNetwrokNode(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E186 RID: 188806 RVA: 0x00AD6A69 File Offset: 0x00AD4C69
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSequencesNetwrokNode(Pointer, false, true);
		}

		// Token: 0x0602E187 RID: 188807 RVA: 0x00AD6A73 File Offset: 0x00AD4C73
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSequencesNetwrokNode(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0D8 RID: 106712
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/SSequencesNetwrokNode.SSequencesNetwrokNode";

		// Token: 0x0401A0D9 RID: 106713
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0DA RID: 106714
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0DB RID: 106715
		internal static int __PropertyOffset_1;

		// Token: 0x0401A0DC RID: 106716
		internal static int __PropertyOffset_2;

		// Token: 0x0401A0DD RID: 106717
		[Nullable(2)]
		private FSoftObjectPath _SeqNodeData;

		// Token: 0x0401A0DE RID: 106718
		internal static int __PropertyOffset_3;

		// Token: 0x0401A0DF RID: 106719
		internal static int __PropertyOffset_4;

		// Token: 0x0401A0E0 RID: 106720
		internal static int __PropertyOffset_5;

		// Token: 0x0401A0E1 RID: 106721
		internal static int __PropertyOffset_6;

		// Token: 0x0401A0E2 RID: 106722
		internal static int __PropertyOffset_7;

		// Token: 0x0401A0E3 RID: 106723
		internal static int __PropertyOffset_8;

		// Token: 0x0401A0E4 RID: 106724
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSeqOptionJumpGroup> _选项跳转组;

		// Token: 0x0401A0E5 RID: 106725
		internal static int __PropertyOffset_9;

		// Token: 0x0401A0E6 RID: 106726
		internal static int __PropertyOffset_10;

		// Token: 0x0401A0E7 RID: 106727
		internal static int __PropertyOffset_11;

		// Token: 0x0401A0E8 RID: 106728
		internal static int __PropertyOffset_12;
	}
}
