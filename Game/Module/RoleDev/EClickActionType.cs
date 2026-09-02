using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005050 RID: 20560
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EClickActionType : IEquatable<EClickActionType>
	{
		// Token: 0x06034EE8 RID: 216808 RVA: 0x00D46A68 File Offset: 0x00D44C68
		private EClickActionType(string value)
		{
			this._Value = value;
		}

		// Token: 0x06034EE9 RID: 216809 RVA: 0x00D46A71 File Offset: 0x00D44C71
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06034EEA RID: 216810 RVA: 0x00D46A79 File Offset: 0x00D44C79
		public bool Equals(EClickActionType other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06034EEB RID: 216811 RVA: 0x00D46A8C File Offset: 0x00D44C8C
		public override bool Equals(object obj)
		{
			if (obj is EClickActionType)
			{
				EClickActionType other = (EClickActionType)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06034EEC RID: 216812 RVA: 0x00D46AB1 File Offset: 0x00D44CB1
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06034EED RID: 216813 RVA: 0x00D46AC4 File Offset: 0x00D44CC4
		public static bool operator ==(EClickActionType left, EClickActionType right)
		{
			return left.Equals(right);
		}

		// Token: 0x06034EEE RID: 216814 RVA: 0x00D46ACE File Offset: 0x00D44CCE
		public static bool operator !=(EClickActionType left, EClickActionType right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401E82C RID: 124972
		private readonly string _Value;

		// Token: 0x0401E82D RID: 124973
		public static readonly EClickActionType ItemTips = new EClickActionType("item_tips");

		// Token: 0x0401E82E RID: 124974
		public static readonly EClickActionType MonsterDetail = new EClickActionType("monster_detail");

		// Token: 0x0401E82F RID: 124975
		public static readonly EClickActionType None = new EClickActionType("none");
	}
}
