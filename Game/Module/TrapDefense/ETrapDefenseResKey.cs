using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DBD RID: 19901
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ETrapDefenseResKey : IEquatable<ETrapDefenseResKey>
	{
		// Token: 0x060338B8 RID: 211128 RVA: 0x00CE456F File Offset: 0x00CE276F
		private ETrapDefenseResKey(string value)
		{
			this._Value = value;
		}

		// Token: 0x060338B9 RID: 211129 RVA: 0x00CE4578 File Offset: 0x00CE2778
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x060338BA RID: 211130 RVA: 0x00CE4580 File Offset: 0x00CE2780
		public bool Equals(ETrapDefenseResKey other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x060338BB RID: 211131 RVA: 0x00CE4594 File Offset: 0x00CE2794
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is ETrapDefenseResKey)
			{
				ETrapDefenseResKey other = (ETrapDefenseResKey)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060338BC RID: 211132 RVA: 0x00CE45B9 File Offset: 0x00CE27B9
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x060338BD RID: 211133 RVA: 0x00CE45CC File Offset: 0x00CE27CC
		public static bool operator ==(ETrapDefenseResKey left, ETrapDefenseResKey right)
		{
			return left.Equals(right);
		}

		// Token: 0x060338BE RID: 211134 RVA: 0x00CE45D6 File Offset: 0x00CE27D6
		public static bool operator !=(ETrapDefenseResKey left, ETrapDefenseResKey right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401DD9F RID: 122271
		private readonly string _Value;

		// Token: 0x0401DDA0 RID: 122272
		public static readonly ETrapDefenseResKey BdProgressArrowQualityPurple = new ETrapDefenseResKey("SP_ArrowPurple");

		// Token: 0x0401DDA1 RID: 122273
		public static readonly ETrapDefenseResKey BdProgressArrowQualityGold = new ETrapDefenseResKey("SP_ArrowGold");

		// Token: 0x0401DDA2 RID: 122274
		public static readonly ETrapDefenseResKey MonsterTagUnStateIcon = new ETrapDefenseResKey("MonsterTagUnStateIcon");

		// Token: 0x0401DDA3 RID: 122275
		public static readonly ETrapDefenseResKey LevelTargetHp = new ETrapDefenseResKey("TrapDefenseLevelTargetHp");

		// Token: 0x0401DDA4 RID: 122276
		public static readonly ETrapDefenseResKey LevelTargetWave = new ETrapDefenseResKey("TrapDefenseLevelTargetWave");
	}
}
