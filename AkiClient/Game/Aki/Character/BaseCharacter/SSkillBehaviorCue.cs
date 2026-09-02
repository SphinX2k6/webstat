using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200427B RID: 17019
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 9)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehaviorCue.SSkillBehaviorCue")]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 16)]
	public struct SSkillBehaviorCue : IEqualityOperators<SSkillBehaviorCue, SSkillBehaviorCue, bool>, IEquatable<SSkillBehaviorCue>, IUnrealScriptStruct
	{
		// Token: 0x0602D2D8 RID: 185048 RVA: 0x00AB9494 File Offset: 0x00AB7694
		public SSkillBehaviorCue(long CueId, bool Stop)
		{
			this.CueId = CueId;
			this.Stop = Stop;
		}

		// Token: 0x0602D2D9 RID: 185049 RVA: 0x00AB94A4 File Offset: 0x00AB76A4
		public static bool operator ==(SSkillBehaviorCue left, SSkillBehaviorCue right)
		{
			return left.CueId == right.CueId && left.Stop == right.Stop;
		}

		// Token: 0x0602D2DA RID: 185050 RVA: 0x00AB94C4 File Offset: 0x00AB76C4
		public static bool operator !=(SSkillBehaviorCue left, SSkillBehaviorCue right)
		{
			return !(left == right);
		}

		// Token: 0x0602D2DB RID: 185051 RVA: 0x00AB94D0 File Offset: 0x00AB76D0
		public bool Equals(SSkillBehaviorCue other)
		{
			return this == other;
		}

		// Token: 0x0602D2DC RID: 185052 RVA: 0x00AB94E0 File Offset: 0x00AB76E0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SSkillBehaviorCue)
			{
				SSkillBehaviorCue other = (SSkillBehaviorCue)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602D2DD RID: 185053 RVA: 0x00AB9505 File Offset: 0x00AB7705
		public override int GetHashCode()
		{
			return HashCode.Combine<long, bool>(this.CueId, this.Stop);
		}

		// Token: 0x0602D2DE RID: 185054 RVA: 0x00AB9518 File Offset: 0x00AB7718
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehaviorCue._ScriptStructPtr != 0) ? SSkillBehaviorCue._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehaviorCue.SSkillBehaviorCue", ref SSkillBehaviorCue._ScriptStructPtr);
		}

		// Token: 0x0401953D RID: 103741
		[FieldOffset(0)]
		public long CueId;

		// Token: 0x0401953E RID: 103742
		[FieldOffset(8)]
		public bool Stop;

		// Token: 0x0401953F RID: 103743
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehaviorCue.SSkillBehaviorCue";

		// Token: 0x04019540 RID: 103744
		private static IntPtr _ScriptStructPtr;
	}
}
