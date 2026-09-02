using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006674 RID: 26228
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMowingBuffIntroduceQualityBackground : IEquatable<EMowingBuffIntroduceQualityBackground>
	{
		// Token: 0x06041832 RID: 268338 RVA: 0x010D0A69 File Offset: 0x010CEC69
		private EMowingBuffIntroduceQualityBackground(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041833 RID: 268339 RVA: 0x010D0A72 File Offset: 0x010CEC72
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041834 RID: 268340 RVA: 0x010D0A7A File Offset: 0x010CEC7A
		public bool Equals(EMowingBuffIntroduceQualityBackground other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041835 RID: 268341 RVA: 0x010D0A90 File Offset: 0x010CEC90
		public override bool Equals(object obj)
		{
			if (obj is EMowingBuffIntroduceQualityBackground)
			{
				EMowingBuffIntroduceQualityBackground other = (EMowingBuffIntroduceQualityBackground)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041836 RID: 268342 RVA: 0x010D0AB5 File Offset: 0x010CECB5
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041837 RID: 268343 RVA: 0x010D0AC8 File Offset: 0x010CECC8
		public static bool operator ==(EMowingBuffIntroduceQualityBackground left, EMowingBuffIntroduceQualityBackground right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041838 RID: 268344 RVA: 0x010D0AD2 File Offset: 0x010CECD2
		public static bool operator !=(EMowingBuffIntroduceQualityBackground left, EMowingBuffIntroduceQualityBackground right)
		{
			return !left.Equals(right);
		}

		// Token: 0x040249CA RID: 149962
		private readonly string _Value;

		// Token: 0x040249CB RID: 149963
		public static readonly EMowingBuffIntroduceQualityBackground Gold = new EMowingBuffIntroduceQualityBackground("T_MowingQualityGold");

		// Token: 0x040249CC RID: 149964
		public static readonly EMowingBuffIntroduceQualityBackground Purple = new EMowingBuffIntroduceQualityBackground("T_MowingQualityPurple");

		// Token: 0x040249CD RID: 149965
		public static readonly EMowingBuffIntroduceQualityBackground Blue = new EMowingBuffIntroduceQualityBackground("T_MowingQualityBlue");
	}
}
