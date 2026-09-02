using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004235 RID: 16949
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(4, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 4)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SAbilityLimitCountInfo.SAbilityLimitCountInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 4)]
	public struct SAbilityLimitCountInfo : IEqualityOperators<SAbilityLimitCountInfo, SAbilityLimitCountInfo, bool>, IEquatable<SAbilityLimitCountInfo>, IUnrealScriptStruct
	{
		// Token: 0x0602CD39 RID: 183609 RVA: 0x00AB0C3D File Offset: 0x00AAEE3D
		public SAbilityLimitCountInfo(int MaxCount)
		{
			this.MaxCount = MaxCount;
		}

		// Token: 0x0602CD3A RID: 183610 RVA: 0x00AB0C46 File Offset: 0x00AAEE46
		public static bool operator ==(SAbilityLimitCountInfo left, SAbilityLimitCountInfo right)
		{
			return left.MaxCount == right.MaxCount;
		}

		// Token: 0x0602CD3B RID: 183611 RVA: 0x00AB0C56 File Offset: 0x00AAEE56
		public static bool operator !=(SAbilityLimitCountInfo left, SAbilityLimitCountInfo right)
		{
			return !(left == right);
		}

		// Token: 0x0602CD3C RID: 183612 RVA: 0x00AB0C62 File Offset: 0x00AAEE62
		public bool Equals(SAbilityLimitCountInfo other)
		{
			return this == other;
		}

		// Token: 0x0602CD3D RID: 183613 RVA: 0x00AB0C70 File Offset: 0x00AAEE70
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SAbilityLimitCountInfo)
			{
				SAbilityLimitCountInfo other = (SAbilityLimitCountInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602CD3E RID: 183614 RVA: 0x00AB0C95 File Offset: 0x00AAEE95
		public override int GetHashCode()
		{
			return HashCode.Combine<int>(this.MaxCount);
		}

		// Token: 0x0602CD3F RID: 183615 RVA: 0x00AB0CA2 File Offset: 0x00AAEEA2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAbilityLimitCountInfo._ScriptStructPtr != 0) ? SAbilityLimitCountInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SAbilityLimitCountInfo.SAbilityLimitCountInfo", ref SAbilityLimitCountInfo._ScriptStructPtr);
		}

		// Token: 0x04019261 RID: 103009
		[FieldOffset(0)]
		public int MaxCount;

		// Token: 0x04019262 RID: 103010
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SAbilityLimitCountInfo.SAbilityLimitCountInfo";

		// Token: 0x04019263 RID: 103011
		private static IntPtr _ScriptStructPtr;
	}
}
