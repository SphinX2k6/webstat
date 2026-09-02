using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.Manager.Structures
{
	// Token: 0x020043B2 RID: 17330
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/Structures/SSeqJumpWithOption.SSeqJumpWithOption")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SSeqJumpWithOption : IEqualityOperators<SSeqJumpWithOption, SSeqJumpWithOption, bool>, IEquatable<SSeqJumpWithOption>, IUnrealScriptStruct
	{
		// Token: 0x0602E1A4 RID: 188836 RVA: 0x00AD6C88 File Offset: 0x00AD4E88
		public SSeqJumpWithOption(int OptionIndex, FName SeqNodeID)
		{
			this.OptionIndex = OptionIndex;
			this.SeqNodeID = SeqNodeID;
		}

		// Token: 0x0602E1A5 RID: 188837 RVA: 0x00AD6C98 File Offset: 0x00AD4E98
		public static bool operator ==(SSeqJumpWithOption left, SSeqJumpWithOption right)
		{
			return left.OptionIndex == right.OptionIndex && left.SeqNodeID == right.SeqNodeID;
		}

		// Token: 0x0602E1A6 RID: 188838 RVA: 0x00AD6CBB File Offset: 0x00AD4EBB
		public static bool operator !=(SSeqJumpWithOption left, SSeqJumpWithOption right)
		{
			return !(left == right);
		}

		// Token: 0x0602E1A7 RID: 188839 RVA: 0x00AD6CC7 File Offset: 0x00AD4EC7
		public bool Equals(SSeqJumpWithOption other)
		{
			return this == other;
		}

		// Token: 0x0602E1A8 RID: 188840 RVA: 0x00AD6CD8 File Offset: 0x00AD4ED8
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SSeqJumpWithOption)
			{
				SSeqJumpWithOption other = (SSeqJumpWithOption)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602E1A9 RID: 188841 RVA: 0x00AD6CFD File Offset: 0x00AD4EFD
		public override int GetHashCode()
		{
			return HashCode.Combine<int, FName>(this.OptionIndex, this.SeqNodeID);
		}

		// Token: 0x0602E1AA RID: 188842 RVA: 0x00AD6D10 File Offset: 0x00AD4F10
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSeqJumpWithOption._ScriptStructPtr != 0) ? SSeqJumpWithOption._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/Manager/Structures/SSeqJumpWithOption.SSeqJumpWithOption", ref SSeqJumpWithOption._ScriptStructPtr);
		}

		// Token: 0x0401A0F4 RID: 106740
		[FieldOffset(0)]
		public int OptionIndex;

		// Token: 0x0401A0F5 RID: 106741
		[FieldOffset(4)]
		public FName SeqNodeID;

		// Token: 0x0401A0F6 RID: 106742
		public const string __ObjectPath = "/Game/Aki/Sequence/Manager/Structures/SSeqJumpWithOption.SSeqJumpWithOption";

		// Token: 0x0401A0F7 RID: 106743
		private static IntPtr _ScriptStructPtr;
	}
}
