using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Fight.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ECD RID: 16077
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 13)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SFollowShooterEnablePriorityInfo.SFollowShooterEnablePriorityInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 16)]
	public struct SFollowShooterEnablePriorityInfo : IEqualityOperators<SFollowShooterEnablePriorityInfo, SFollowShooterEnablePriorityInfo, bool>, IEquatable<SFollowShooterEnablePriorityInfo>, IUnrealScriptStruct
	{
		// Token: 0x06027F49 RID: 163657 RVA: 0x009FEF2C File Offset: 0x009FD12C
		public SFollowShooterEnablePriorityInfo(TEnumAsByte<BPEEnableFollowShooter> EnableType, int EnterSkillId, int ExitSkillId, bool EnterSkillReentrant)
		{
			this.EnableType = EnableType;
			this.EnterSkillId = EnterSkillId;
			this.ExitSkillId = ExitSkillId;
			this.EnterSkillReentrant = EnterSkillReentrant;
		}

		// Token: 0x06027F4A RID: 163658 RVA: 0x009FEF4C File Offset: 0x009FD14C
		public static bool operator ==(SFollowShooterEnablePriorityInfo left, SFollowShooterEnablePriorityInfo right)
		{
			return left.EnableType == right.EnableType && left.EnterSkillId == right.EnterSkillId && left.ExitSkillId == right.ExitSkillId && left.EnterSkillReentrant == right.EnterSkillReentrant;
		}

		// Token: 0x06027F4B RID: 163659 RVA: 0x009FEF98 File Offset: 0x009FD198
		public static bool operator !=(SFollowShooterEnablePriorityInfo left, SFollowShooterEnablePriorityInfo right)
		{
			return !(left == right);
		}

		// Token: 0x06027F4C RID: 163660 RVA: 0x009FEFA4 File Offset: 0x009FD1A4
		public bool Equals(SFollowShooterEnablePriorityInfo other)
		{
			return this == other;
		}

		// Token: 0x06027F4D RID: 163661 RVA: 0x009FEFB4 File Offset: 0x009FD1B4
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SFollowShooterEnablePriorityInfo)
			{
				SFollowShooterEnablePriorityInfo other = (SFollowShooterEnablePriorityInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027F4E RID: 163662 RVA: 0x009FEFD9 File Offset: 0x009FD1D9
		public override int GetHashCode()
		{
			return HashCode.Combine<TEnumAsByte<BPEEnableFollowShooter>, int, int, bool>(this.EnableType, this.EnterSkillId, this.ExitSkillId, this.EnterSkillReentrant);
		}

		// Token: 0x06027F4F RID: 163663 RVA: 0x009FEFF8 File Offset: 0x009FD1F8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFollowShooterEnablePriorityInfo._ScriptStructPtr != 0) ? SFollowShooterEnablePriorityInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SFollowShooterEnablePriorityInfo.SFollowShooterEnablePriorityInfo", ref SFollowShooterEnablePriorityInfo._ScriptStructPtr);
		}

		// Token: 0x04014FA2 RID: 85922
		[FieldOffset(0)]
		public TEnumAsByte<BPEEnableFollowShooter> EnableType;

		// Token: 0x04014FA3 RID: 85923
		[FieldOffset(4)]
		public int EnterSkillId;

		// Token: 0x04014FA4 RID: 85924
		[FieldOffset(8)]
		public int ExitSkillId;

		// Token: 0x04014FA5 RID: 85925
		[FieldOffset(12)]
		public bool EnterSkillReentrant;

		// Token: 0x04014FA6 RID: 85926
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SFollowShooterEnablePriorityInfo.SFollowShooterEnablePriorityInfo";

		// Token: 0x04014FA7 RID: 85927
		private static IntPtr _ScriptStructPtr;
	}
}
