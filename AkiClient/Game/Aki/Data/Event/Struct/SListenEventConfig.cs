using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Event.Struct
{
	// Token: 0x02003EF0 RID: 16112
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(8, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 8)]
	[UnrealObjectPath("/Game/Aki/Data/Event/Struct/SListenEventConfig.SListenEventConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 8)]
	public struct SListenEventConfig : IEqualityOperators<SListenEventConfig, SListenEventConfig, bool>, IEquatable<SListenEventConfig>, IUnrealScriptStruct
	{
		// Token: 0x060281DB RID: 164315 RVA: 0x00A02B67 File Offset: 0x00A00D67
		public SListenEventConfig(int ConditionGroupID, int EventGroupID)
		{
			this.ConditionGroupID = ConditionGroupID;
			this.EventGroupID = EventGroupID;
		}

		// Token: 0x060281DC RID: 164316 RVA: 0x00A02B77 File Offset: 0x00A00D77
		public static bool operator ==(SListenEventConfig left, SListenEventConfig right)
		{
			return left.ConditionGroupID == right.ConditionGroupID && left.EventGroupID == right.EventGroupID;
		}

		// Token: 0x060281DD RID: 164317 RVA: 0x00A02B97 File Offset: 0x00A00D97
		public static bool operator !=(SListenEventConfig left, SListenEventConfig right)
		{
			return !(left == right);
		}

		// Token: 0x060281DE RID: 164318 RVA: 0x00A02BA3 File Offset: 0x00A00DA3
		public bool Equals(SListenEventConfig other)
		{
			return this == other;
		}

		// Token: 0x060281DF RID: 164319 RVA: 0x00A02BB4 File Offset: 0x00A00DB4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SListenEventConfig)
			{
				SListenEventConfig other = (SListenEventConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060281E0 RID: 164320 RVA: 0x00A02BD9 File Offset: 0x00A00DD9
		public override int GetHashCode()
		{
			return HashCode.Combine<int, int>(this.ConditionGroupID, this.EventGroupID);
		}

		// Token: 0x060281E1 RID: 164321 RVA: 0x00A02BEC File Offset: 0x00A00DEC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SListenEventConfig._ScriptStructPtr != 0) ? SListenEventConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Event/Struct/SListenEventConfig.SListenEventConfig", ref SListenEventConfig._ScriptStructPtr);
		}

		// Token: 0x04015113 RID: 86291
		[FieldOffset(0)]
		public int ConditionGroupID;

		// Token: 0x04015114 RID: 86292
		[FieldOffset(4)]
		public int EventGroupID;

		// Token: 0x04015115 RID: 86293
		public const string __ObjectPath = "/Game/Aki/Data/Event/Struct/SListenEventConfig.SListenEventConfig";

		// Token: 0x04015116 RID: 86294
		private static IntPtr _ScriptStructPtr;
	}
}
