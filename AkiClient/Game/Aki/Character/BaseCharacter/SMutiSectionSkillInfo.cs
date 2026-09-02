using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004273 RID: 17011
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 17)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMutiSectionSkillInfo.SMutiSectionSkillInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct SMutiSectionSkillInfo : IEqualityOperators<SMutiSectionSkillInfo, SMutiSectionSkillInfo, bool>, IEquatable<SMutiSectionSkillInfo>, IUnrealScriptStruct
	{
		// Token: 0x0602D1F1 RID: 184817 RVA: 0x00AB7EB4 File Offset: 0x00AB60B4
		public SMutiSectionSkillInfo(float StartTime, float StopTime, int SectionRemaining, int SectionCount, bool IsReset)
		{
			this.StartTime = StartTime;
			this.StopTime = StopTime;
			this.SectionRemaining = SectionRemaining;
			this.SectionCount = SectionCount;
			this.IsReset = IsReset;
		}

		// Token: 0x0602D1F2 RID: 184818 RVA: 0x00AB7EDC File Offset: 0x00AB60DC
		public static bool operator ==(SMutiSectionSkillInfo left, SMutiSectionSkillInfo right)
		{
			return left.StartTime == right.StartTime && left.StopTime == right.StopTime && left.SectionRemaining == right.SectionRemaining && left.SectionCount == right.SectionCount && left.IsReset == right.IsReset;
		}

		// Token: 0x0602D1F3 RID: 184819 RVA: 0x00AB7F31 File Offset: 0x00AB6131
		public static bool operator !=(SMutiSectionSkillInfo left, SMutiSectionSkillInfo right)
		{
			return !(left == right);
		}

		// Token: 0x0602D1F4 RID: 184820 RVA: 0x00AB7F3D File Offset: 0x00AB613D
		public bool Equals(SMutiSectionSkillInfo other)
		{
			return this == other;
		}

		// Token: 0x0602D1F5 RID: 184821 RVA: 0x00AB7F4C File Offset: 0x00AB614C
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SMutiSectionSkillInfo)
			{
				SMutiSectionSkillInfo other = (SMutiSectionSkillInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D1F6 RID: 184822 RVA: 0x00AB7F71 File Offset: 0x00AB6171
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, int, int, bool>(this.StartTime, this.StopTime, this.SectionRemaining, this.SectionCount, this.IsReset);
		}

		// Token: 0x0602D1F7 RID: 184823 RVA: 0x00AB7F96 File Offset: 0x00AB6196
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMutiSectionSkillInfo._ScriptStructPtr != 0) ? SMutiSectionSkillInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMutiSectionSkillInfo.SMutiSectionSkillInfo", ref SMutiSectionSkillInfo._ScriptStructPtr);
		}

		// Token: 0x040194C7 RID: 103623
		[FieldOffset(0)]
		public float StartTime;

		// Token: 0x040194C8 RID: 103624
		[FieldOffset(4)]
		public float StopTime;

		// Token: 0x040194C9 RID: 103625
		[FieldOffset(8)]
		public int SectionRemaining;

		// Token: 0x040194CA RID: 103626
		[FieldOffset(12)]
		public int SectionCount;

		// Token: 0x040194CB RID: 103627
		[FieldOffset(16)]
		public bool IsReset;

		// Token: 0x040194CC RID: 103628
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMutiSectionSkillInfo.SMutiSectionSkillInfo";

		// Token: 0x040194CD RID: 103629
		private static IntPtr _ScriptStructPtr;
	}
}
