using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006675 RID: 26229
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMowingBuffIntroduceQualityIcon : IEquatable<EMowingBuffIntroduceQualityIcon>
	{
		// Token: 0x0604183A RID: 268346 RVA: 0x010D0B0E File Offset: 0x010CED0E
		private EMowingBuffIntroduceQualityIcon(string value)
		{
			this._Value = value;
		}

		// Token: 0x0604183B RID: 268347 RVA: 0x010D0B17 File Offset: 0x010CED17
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x0604183C RID: 268348 RVA: 0x010D0B1F File Offset: 0x010CED1F
		public bool Equals(EMowingBuffIntroduceQualityIcon other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0604183D RID: 268349 RVA: 0x010D0B34 File Offset: 0x010CED34
		public override bool Equals(object obj)
		{
			if (obj is EMowingBuffIntroduceQualityIcon)
			{
				EMowingBuffIntroduceQualityIcon other = (EMowingBuffIntroduceQualityIcon)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0604183E RID: 268350 RVA: 0x010D0B59 File Offset: 0x010CED59
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0604183F RID: 268351 RVA: 0x010D0B6C File Offset: 0x010CED6C
		public static bool operator ==(EMowingBuffIntroduceQualityIcon left, EMowingBuffIntroduceQualityIcon right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041840 RID: 268352 RVA: 0x010D0B76 File Offset: 0x010CED76
		public static bool operator !=(EMowingBuffIntroduceQualityIcon left, EMowingBuffIntroduceQualityIcon right)
		{
			return !left.Equals(right);
		}

		// Token: 0x040249CE RID: 149966
		private readonly string _Value;

		// Token: 0x040249CF RID: 149967
		public static readonly EMowingBuffIntroduceQualityIcon Gold = new EMowingBuffIntroduceQualityIcon("SP_QualityGlodA");

		// Token: 0x040249D0 RID: 149968
		public static readonly EMowingBuffIntroduceQualityIcon Purple = new EMowingBuffIntroduceQualityIcon("SP_QualityPurpleA");

		// Token: 0x040249D1 RID: 149969
		public static readonly EMowingBuffIntroduceQualityIcon Blue = new EMowingBuffIntroduceQualityIcon("SP_QualityBlueA");
	}
}
