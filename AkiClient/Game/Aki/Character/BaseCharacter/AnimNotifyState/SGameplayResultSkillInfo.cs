using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.AnimNotifyState
{
	// Token: 0x02004331 RID: 17201
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 12)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/AnimNotifyState/SGameplayResultSkillInfo.SGameplayResultSkillInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 12)]
	public struct SGameplayResultSkillInfo : IEqualityOperators<SGameplayResultSkillInfo, SGameplayResultSkillInfo, bool>, IEquatable<SGameplayResultSkillInfo>, IUnrealScriptStruct
	{
		// Token: 0x0602DA26 RID: 186918 RVA: 0x00AC52E2 File Offset: 0x00AC34E2
		public SGameplayResultSkillInfo(int SkillId, bool IsWinResult, bool IsCheckStartTimeStamp, float TimeStampDelta)
		{
			this.SkillId = SkillId;
			this.IsWinResult = IsWinResult;
			this.IsCheckStartTimeStamp = IsCheckStartTimeStamp;
			this.TimeStampDelta = TimeStampDelta;
		}

		// Token: 0x0602DA27 RID: 186919 RVA: 0x00AC5301 File Offset: 0x00AC3501
		public static bool operator ==(SGameplayResultSkillInfo left, SGameplayResultSkillInfo right)
		{
			return left.SkillId == right.SkillId && left.IsWinResult == right.IsWinResult && left.IsCheckStartTimeStamp == right.IsCheckStartTimeStamp && left.TimeStampDelta == right.TimeStampDelta;
		}

		// Token: 0x0602DA28 RID: 186920 RVA: 0x00AC533D File Offset: 0x00AC353D
		public static bool operator !=(SGameplayResultSkillInfo left, SGameplayResultSkillInfo right)
		{
			return !(left == right);
		}

		// Token: 0x0602DA29 RID: 186921 RVA: 0x00AC5349 File Offset: 0x00AC3549
		public bool Equals(SGameplayResultSkillInfo other)
		{
			return this == other;
		}

		// Token: 0x0602DA2A RID: 186922 RVA: 0x00AC5358 File Offset: 0x00AC3558
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SGameplayResultSkillInfo)
			{
				SGameplayResultSkillInfo other = (SGameplayResultSkillInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602DA2B RID: 186923 RVA: 0x00AC537D File Offset: 0x00AC357D
		public override int GetHashCode()
		{
			return HashCode.Combine<int, bool, bool, float>(this.SkillId, this.IsWinResult, this.IsCheckStartTimeStamp, this.TimeStampDelta);
		}

		// Token: 0x0602DA2C RID: 186924 RVA: 0x00AC539C File Offset: 0x00AC359C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGameplayResultSkillInfo._ScriptStructPtr != 0) ? SGameplayResultSkillInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/AnimNotifyState/SGameplayResultSkillInfo.SGameplayResultSkillInfo", ref SGameplayResultSkillInfo._ScriptStructPtr);
		}

		// Token: 0x04019BA6 RID: 105382
		[FieldOffset(0)]
		public int SkillId;

		// Token: 0x04019BA7 RID: 105383
		[FieldOffset(4)]
		public bool IsWinResult;

		// Token: 0x04019BA8 RID: 105384
		[FieldOffset(5)]
		public bool IsCheckStartTimeStamp;

		// Token: 0x04019BA9 RID: 105385
		[FieldOffset(8)]
		public float TimeStampDelta;

		// Token: 0x04019BAA RID: 105386
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/AnimNotifyState/SGameplayResultSkillInfo.SGameplayResultSkillInfo";

		// Token: 0x04019BAB RID: 105387
		private static IntPtr _ScriptStructPtr;
	}
}
