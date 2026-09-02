using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Interaction.Struct
{
	// Token: 0x02003E8A RID: 16010
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 44)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Struct/SKuroInteractionConfigExport.SKuroInteractionConfigExport")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 48)]
	public struct SKuroInteractionConfigExport : IEqualityOperators<SKuroInteractionConfigExport, SKuroInteractionConfigExport, bool>, IEquatable<SKuroInteractionConfigExport>, IUnrealScriptStruct
	{
		// Token: 0x06027A9A RID: 162458 RVA: 0x009F7674 File Offset: 0x009F5874
		public SKuroInteractionConfigExport(long InteractionID, int StepID, long ConditionGroupID, long EventGroupID, byte OptionLimitType, int OptionLimitTimes, float OptionLimitDuration)
		{
			this.InteractionID = InteractionID;
			this.StepID = StepID;
			this.ConditionGroupID = ConditionGroupID;
			this.EventGroupID = EventGroupID;
			this.OptionLimitType = OptionLimitType;
			this.OptionLimitTimes = OptionLimitTimes;
			this.OptionLimitDuration = OptionLimitDuration;
		}

		// Token: 0x06027A9B RID: 162459 RVA: 0x009F76AC File Offset: 0x009F58AC
		public static bool operator ==(SKuroInteractionConfigExport left, SKuroInteractionConfigExport right)
		{
			return left.InteractionID == right.InteractionID && left.StepID == right.StepID && left.ConditionGroupID == right.ConditionGroupID && left.EventGroupID == right.EventGroupID && left.OptionLimitType == right.OptionLimitType && left.OptionLimitTimes == right.OptionLimitTimes && left.OptionLimitDuration == right.OptionLimitDuration;
		}

		// Token: 0x06027A9C RID: 162460 RVA: 0x009F771D File Offset: 0x009F591D
		public static bool operator !=(SKuroInteractionConfigExport left, SKuroInteractionConfigExport right)
		{
			return !(left == right);
		}

		// Token: 0x06027A9D RID: 162461 RVA: 0x009F7729 File Offset: 0x009F5929
		public bool Equals(SKuroInteractionConfigExport other)
		{
			return this == other;
		}

		// Token: 0x06027A9E RID: 162462 RVA: 0x009F7738 File Offset: 0x009F5938
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SKuroInteractionConfigExport)
			{
				SKuroInteractionConfigExport other = (SKuroInteractionConfigExport)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027A9F RID: 162463 RVA: 0x009F775D File Offset: 0x009F595D
		public override int GetHashCode()
		{
			return HashCode.Combine<long, int, long, long, byte, int, float>(this.InteractionID, this.StepID, this.ConditionGroupID, this.EventGroupID, this.OptionLimitType, this.OptionLimitTimes, this.OptionLimitDuration);
		}

		// Token: 0x06027AA0 RID: 162464 RVA: 0x009F778E File Offset: 0x009F598E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SKuroInteractionConfigExport._ScriptStructPtr != 0) ? SKuroInteractionConfigExport._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Interaction/Struct/SKuroInteractionConfigExport.SKuroInteractionConfigExport", ref SKuroInteractionConfigExport._ScriptStructPtr);
		}

		// Token: 0x04014CC4 RID: 85188
		[FieldOffset(0)]
		public long InteractionID;

		// Token: 0x04014CC5 RID: 85189
		[FieldOffset(8)]
		public int StepID;

		// Token: 0x04014CC6 RID: 85190
		[FieldOffset(16)]
		public long ConditionGroupID;

		// Token: 0x04014CC7 RID: 85191
		[FieldOffset(24)]
		public long EventGroupID;

		// Token: 0x04014CC8 RID: 85192
		[FieldOffset(32)]
		public byte OptionLimitType;

		// Token: 0x04014CC9 RID: 85193
		[FieldOffset(36)]
		public int OptionLimitTimes;

		// Token: 0x04014CCA RID: 85194
		[FieldOffset(40)]
		public float OptionLimitDuration;

		// Token: 0x04014CCB RID: 85195
		public const string __ObjectPath = "/Game/Aki/Data/Interaction/Struct/SKuroInteractionConfigExport.SKuroInteractionConfigExport";

		// Token: 0x04014CCC RID: 85196
		private static IntPtr _ScriptStructPtr;
	}
}
