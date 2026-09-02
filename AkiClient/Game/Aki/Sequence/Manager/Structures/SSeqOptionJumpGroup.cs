using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.Manager.Structures
{
	// Token: 0x020043B3 RID: 17331
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/Structures/SSeqOptionJumpGroup.SSeqOptionJumpGroup")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SSeqOptionJumpGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E1AB RID: 188843 RVA: 0x00AD6D34 File Offset: 0x00AD4F34
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSeqOptionJumpGroup._ScriptStructPtr != 0) ? SSeqOptionJumpGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/Structures/SSeqOptionJumpGroup.SSeqOptionJumpGroup", ref SSeqOptionJumpGroup._ScriptStructPtr);
		}

		// Token: 0x17007F05 RID: 32517
		// (get) Token: 0x0602E1AC RID: 188844 RVA: 0x00AD6D58 File Offset: 0x00AD4F58
		// (set) Token: 0x0602E1AD RID: 188845 RVA: 0x00AD6D6C File Offset: 0x00AD4F6C
		public unsafe FName SubtitleID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSeqOptionJumpGroup.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSeqOptionJumpGroup.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007F06 RID: 32518
		// (get) Token: 0x0602E1AE RID: 188846 RVA: 0x00AD6D84 File Offset: 0x00AD4F84
		// (set) Token: 0x0602E1AF RID: 188847 RVA: 0x00AD6DC7 File Offset: 0x00AD4FC7
		public TArray<SSeqJumpWithOption> JumpGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSeqJumpWithOption> result;
				if ((result = this._JumpGroup) == null)
				{
					result = (this._JumpGroup = new TArray<SSeqJumpWithOption>(base.NativePtr + (IntPtr)SSeqOptionJumpGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.JumpGroup.CopyAssign(value);
			}
		}

		// Token: 0x0602E1B0 RID: 188848 RVA: 0x00AD6DD5 File Offset: 0x00AD4FD5
		public SSeqOptionJumpGroup()
		{
		}

		// Token: 0x0602E1B1 RID: 188849 RVA: 0x00AD6DDD File Offset: 0x00AD4FDD
		public SSeqOptionJumpGroup(FName SubtitleID, TArray<SSeqJumpWithOption> JumpGroup)
		{
			this.SubtitleID = SubtitleID;
			this.JumpGroup = JumpGroup;
		}

		// Token: 0x0602E1B2 RID: 188850 RVA: 0x00AD6DF3 File Offset: 0x00AD4FF3
		protected override IntPtr GetUStructPtr()
		{
			return SSeqOptionJumpGroup.StaticStruct();
		}

		// Token: 0x0602E1B3 RID: 188851 RVA: 0x00AD6DFF File Offset: 0x00AD4FFF
		[NullableContext(2)]
		public SSeqOptionJumpGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E1B4 RID: 188852 RVA: 0x00AD6E09 File Offset: 0x00AD5009
		public SSeqOptionJumpGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E1B5 RID: 188853 RVA: 0x00AD6E14 File Offset: 0x00AD5014
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSeqOptionJumpGroup(Pointer, false, true);
		}

		// Token: 0x0602E1B6 RID: 188854 RVA: 0x00AD6E1E File Offset: 0x00AD501E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSeqOptionJumpGroup(Pointer, MemoryOwner);
		}

		// Token: 0x0401A0F8 RID: 106744
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/Structures/SSeqOptionJumpGroup.SSeqOptionJumpGroup";

		// Token: 0x0401A0F9 RID: 106745
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A0FA RID: 106746
		internal static int __PropertyOffset_0;

		// Token: 0x0401A0FB RID: 106747
		internal static int __PropertyOffset_1;

		// Token: 0x0401A0FC RID: 106748
		[Nullable(2)]
		private TArray<SSeqJumpWithOption> _JumpGroup;
	}
}
