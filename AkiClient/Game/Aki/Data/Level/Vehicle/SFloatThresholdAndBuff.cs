using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.Vehicle
{
	// Token: 0x02003E6B RID: 15979
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 16)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/SFloatThresholdAndBuff.SFloatThresholdAndBuff")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 16)]
	public struct SFloatThresholdAndBuff : IEqualityOperators<SFloatThresholdAndBuff, SFloatThresholdAndBuff, bool>, IEquatable<SFloatThresholdAndBuff>, IUnrealScriptStruct
	{
		// Token: 0x060277C7 RID: 161735 RVA: 0x009F2EBB File Offset: 0x009F10BB
		public SFloatThresholdAndBuff(float Threshold, long BuffId)
		{
			this.Threshold = Threshold;
			this.BuffId = BuffId;
		}

		// Token: 0x060277C8 RID: 161736 RVA: 0x009F2ECB File Offset: 0x009F10CB
		public static bool operator ==(SFloatThresholdAndBuff left, SFloatThresholdAndBuff right)
		{
			return left.Threshold == right.Threshold && left.BuffId == right.BuffId;
		}

		// Token: 0x060277C9 RID: 161737 RVA: 0x009F2EEB File Offset: 0x009F10EB
		public static bool operator !=(SFloatThresholdAndBuff left, SFloatThresholdAndBuff right)
		{
			return !(left == right);
		}

		// Token: 0x060277CA RID: 161738 RVA: 0x009F2EF7 File Offset: 0x009F10F7
		public bool Equals(SFloatThresholdAndBuff other)
		{
			return this == other;
		}

		// Token: 0x060277CB RID: 161739 RVA: 0x009F2F08 File Offset: 0x009F1108
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SFloatThresholdAndBuff)
			{
				SFloatThresholdAndBuff other = (SFloatThresholdAndBuff)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060277CC RID: 161740 RVA: 0x009F2F2D File Offset: 0x009F112D
		public override int GetHashCode()
		{
			return HashCode.Combine<float, long>(this.Threshold, this.BuffId);
		}

		// Token: 0x060277CD RID: 161741 RVA: 0x009F2F40 File Offset: 0x009F1140
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFloatThresholdAndBuff._ScriptStructPtr != 0) ? SFloatThresholdAndBuff._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/Vehicle/SFloatThresholdAndBuff.SFloatThresholdAndBuff", ref SFloatThresholdAndBuff._ScriptStructPtr);
		}

		// Token: 0x04014AF1 RID: 84721
		[FieldOffset(0)]
		public float Threshold;

		// Token: 0x04014AF2 RID: 84722
		[FieldOffset(8)]
		public long BuffId;

		// Token: 0x04014AF3 RID: 84723
		public const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/SFloatThresholdAndBuff.SFloatThresholdAndBuff";

		// Token: 0x04014AF4 RID: 84724
		private static IntPtr _ScriptStructPtr;
	}
}
