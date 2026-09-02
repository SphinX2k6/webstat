using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.RhythmGame
{
	// Token: 0x02003E9F RID: 16031
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 20)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameFeverScore.RhythmGameFeverScore")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 20)]
	public struct RhythmGameFeverScore : IEqualityOperators<RhythmGameFeverScore, RhythmGameFeverScore, bool>, IEquatable<RhythmGameFeverScore>, IUnrealScriptStruct
	{
		// Token: 0x06027C72 RID: 162930 RVA: 0x009FA49F File Offset: 0x009F869F
		public RhythmGameFeverScore(int Perfect分数, int Great分数, int Good分数, int Bad分数, int Miss分数)
		{
			this.Perfect分数 = Perfect分数;
			this.Great分数 = Great分数;
			this.Good分数 = Good分数;
			this.Bad分数 = Bad分数;
			this.Miss分数 = Miss分数;
		}

		// Token: 0x06027C73 RID: 162931 RVA: 0x009FA4C8 File Offset: 0x009F86C8
		public static bool operator ==(RhythmGameFeverScore left, RhythmGameFeverScore right)
		{
			return left.Perfect分数 == right.Perfect分数 && left.Great分数 == right.Great分数 && left.Good分数 == right.Good分数 && left.Bad分数 == right.Bad分数 && left.Miss分数 == right.Miss分数;
		}

		// Token: 0x06027C74 RID: 162932 RVA: 0x009FA51D File Offset: 0x009F871D
		public static bool operator !=(RhythmGameFeverScore left, RhythmGameFeverScore right)
		{
			return !(left == right);
		}

		// Token: 0x06027C75 RID: 162933 RVA: 0x009FA529 File Offset: 0x009F8729
		public bool Equals(RhythmGameFeverScore other)
		{
			return this == other;
		}

		// Token: 0x06027C76 RID: 162934 RVA: 0x009FA538 File Offset: 0x009F8738
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is RhythmGameFeverScore)
			{
				RhythmGameFeverScore other = (RhythmGameFeverScore)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06027C77 RID: 162935 RVA: 0x009FA55D File Offset: 0x009F875D
		public override int GetHashCode()
		{
			return HashCode.Combine<int, int, int, int, int>(this.Perfect分数, this.Great分数, this.Good分数, this.Bad分数, this.Miss分数);
		}

		// Token: 0x06027C78 RID: 162936 RVA: 0x009FA582 File Offset: 0x009F8782
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (RhythmGameFeverScore._ScriptStructPtr != 0) ? RhythmGameFeverScore._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameFeverScore.RhythmGameFeverScore", ref RhythmGameFeverScore._ScriptStructPtr);
		}

		// Token: 0x04014DEF RID: 85487
		[FieldOffset(0)]
		public int Perfect分数;

		// Token: 0x04014DF0 RID: 85488
		[FieldOffset(4)]
		public int Great分数;

		// Token: 0x04014DF1 RID: 85489
		[FieldOffset(8)]
		public int Good分数;

		// Token: 0x04014DF2 RID: 85490
		[FieldOffset(12)]
		public int Bad分数;

		// Token: 0x04014DF3 RID: 85491
		[FieldOffset(16)]
		public int Miss分数;

		// Token: 0x04014DF4 RID: 85492
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameFeverScore.RhythmGameFeverScore";

		// Token: 0x04014DF5 RID: 85493
		private static IntPtr _ScriptStructPtr;
	}
}
