using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Sequence.SeqSubtitle
{
	// Token: 0x020043A0 RID: 17312
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(24, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 24)]
	[UnrealObjectPath("/Game/Aki/Sequence/SeqSubtitle/SSubtitleSettings.SSubtitleSettings")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct SSubtitleSettings : IEqualityOperators<SSubtitleSettings, SSubtitleSettings, bool>, IEquatable<SSubtitleSettings>, IUnrealScriptStruct
	{
		// Token: 0x0602DF9B RID: 188315 RVA: 0x00AD32B7 File Offset: 0x00AD14B7
		public SSubtitleSettings(float Duration, float FadeInSpeed, float FadeOutSpeed, FName SubtitleID)
		{
			this.Duration = Duration;
			this.FadeInSpeed = FadeInSpeed;
			this.FadeOutSpeed = FadeOutSpeed;
			this.SubtitleID = SubtitleID;
		}

		// Token: 0x0602DF9C RID: 188316 RVA: 0x00AD32D6 File Offset: 0x00AD14D6
		public static bool operator ==(SSubtitleSettings left, SSubtitleSettings right)
		{
			return left.Duration == right.Duration && left.FadeInSpeed == right.FadeInSpeed && left.FadeOutSpeed == right.FadeOutSpeed && left.SubtitleID == right.SubtitleID;
		}

		// Token: 0x0602DF9D RID: 188317 RVA: 0x00AD3315 File Offset: 0x00AD1515
		public static bool operator !=(SSubtitleSettings left, SSubtitleSettings right)
		{
			return !(left == right);
		}

		// Token: 0x0602DF9E RID: 188318 RVA: 0x00AD3321 File Offset: 0x00AD1521
		public bool Equals(SSubtitleSettings other)
		{
			return this == other;
		}

		// Token: 0x0602DF9F RID: 188319 RVA: 0x00AD3330 File Offset: 0x00AD1530
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SSubtitleSettings)
			{
				SSubtitleSettings other = (SSubtitleSettings)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0602DFA0 RID: 188320 RVA: 0x00AD3355 File Offset: 0x00AD1555
		public override int GetHashCode()
		{
			return HashCode.Combine<float, float, float, FName>(this.Duration, this.FadeInSpeed, this.FadeOutSpeed, this.SubtitleID);
		}

		// Token: 0x0602DFA1 RID: 188321 RVA: 0x00AD3374 File Offset: 0x00AD1574
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSubtitleSettings._ScriptStructPtr != 0) ? SSubtitleSettings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Sequence/SeqSubtitle/SSubtitleSettings.SSubtitleSettings", ref SSubtitleSettings._ScriptStructPtr);
		}

		// Token: 0x04019FB5 RID: 106421
		[FieldOffset(0)]
		public float Duration;

		// Token: 0x04019FB6 RID: 106422
		[FieldOffset(4)]
		public float FadeInSpeed;

		// Token: 0x04019FB7 RID: 106423
		[FieldOffset(8)]
		public float FadeOutSpeed;

		// Token: 0x04019FB8 RID: 106424
		[FieldOffset(12)]
		public FName SubtitleID;

		// Token: 0x04019FB9 RID: 106425
		public const string __ObjectPath = "/Game/Aki/Sequence/SeqSubtitle/SSubtitleSettings.SSubtitleSettings";

		// Token: 0x04019FBA RID: 106426
		private static IntPtr _ScriptStructPtr;
	}
}
