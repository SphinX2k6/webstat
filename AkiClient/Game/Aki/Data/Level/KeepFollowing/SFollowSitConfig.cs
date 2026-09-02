using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.KeepFollowing
{
	// Token: 0x02003E7B RID: 15995
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Data/Level/KeepFollowing/SFollowSitConfig.SFollowSitConfig")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SFollowSitConfig : IEqualityOperators<SFollowSitConfig, SFollowSitConfig, bool>, IEquatable<SFollowSitConfig>, IUnrealScriptStruct
	{
		// Token: 0x060279B1 RID: 162225 RVA: 0x009F60D0 File Offset: 0x009F42D0
		public SFollowSitConfig(bool Enable, int FindChairRadius, int ExitSitDownDistance)
		{
			this.Enable = Enable;
			this.FindChairRadius = FindChairRadius;
			this.ExitSitDownDistance = ExitSitDownDistance;
		}

		// Token: 0x060279B2 RID: 162226 RVA: 0x009F60E7 File Offset: 0x009F42E7
		public static bool operator ==(SFollowSitConfig left, SFollowSitConfig right)
		{
			return left.Enable == right.Enable && left.FindChairRadius == right.FindChairRadius && left.ExitSitDownDistance == right.ExitSitDownDistance;
		}

		// Token: 0x060279B3 RID: 162227 RVA: 0x009F6115 File Offset: 0x009F4315
		public static bool operator !=(SFollowSitConfig left, SFollowSitConfig right)
		{
			return !(left == right);
		}

		// Token: 0x060279B4 RID: 162228 RVA: 0x009F6121 File Offset: 0x009F4321
		public bool Equals(SFollowSitConfig other)
		{
			return this == other;
		}

		// Token: 0x060279B5 RID: 162229 RVA: 0x009F6130 File Offset: 0x009F4330
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SFollowSitConfig)
			{
				SFollowSitConfig other = (SFollowSitConfig)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060279B6 RID: 162230 RVA: 0x009F6155 File Offset: 0x009F4355
		public override int GetHashCode()
		{
			return HashCode.Combine<bool, int, int>(this.Enable, this.FindChairRadius, this.ExitSitDownDistance);
		}

		// Token: 0x060279B7 RID: 162231 RVA: 0x009F616E File Offset: 0x009F436E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFollowSitConfig._ScriptStructPtr != 0) ? SFollowSitConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/KeepFollowing/SFollowSitConfig.SFollowSitConfig", ref SFollowSitConfig._ScriptStructPtr);
		}

		// Token: 0x04014C30 RID: 85040
		[FieldOffset(0)]
		public bool Enable;

		// Token: 0x04014C31 RID: 85041
		[FieldOffset(4)]
		public int FindChairRadius;

		// Token: 0x04014C32 RID: 85042
		[FieldOffset(8)]
		public int ExitSitDownDistance;

		// Token: 0x04014C33 RID: 85043
		public const string __ObjectPath = "/Game/Aki/Data/Level/KeepFollowing/SFollowSitConfig.SFollowSitConfig";

		// Token: 0x04014C34 RID: 85044
		private static IntPtr _ScriptStructPtr;
	}
}
