using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x02006748 RID: 26440
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMoonChasingGuideInDelegation : IEquatable<EMoonChasingGuideInDelegation>
	{
		// Token: 0x06041EF8 RID: 270072 RVA: 0x010EA8C8 File Offset: 0x010E8AC8
		private EMoonChasingGuideInDelegation(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041EF9 RID: 270073 RVA: 0x010EA8D1 File Offset: 0x010E8AD1
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041EFA RID: 270074 RVA: 0x010EA8D9 File Offset: 0x010E8AD9
		public bool Equals(EMoonChasingGuideInDelegation other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041EFB RID: 270075 RVA: 0x010EA8EC File Offset: 0x010E8AEC
		public override bool Equals(object obj)
		{
			if (obj is EMoonChasingGuideInDelegation)
			{
				EMoonChasingGuideInDelegation other = (EMoonChasingGuideInDelegation)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041EFC RID: 270076 RVA: 0x010EA911 File Offset: 0x010E8B11
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041EFD RID: 270077 RVA: 0x010EA924 File Offset: 0x010E8B24
		public static bool operator ==(EMoonChasingGuideInDelegation left, EMoonChasingGuideInDelegation right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041EFE RID: 270078 RVA: 0x010EA92E File Offset: 0x010E8B2E
		public static bool operator !=(EMoonChasingGuideInDelegation left, EMoonChasingGuideInDelegation right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024C8C RID: 150668
		private readonly string _Value;

		// Token: 0x04024C8D RID: 150669
		public static readonly EMoonChasingGuideInDelegation Role = new EMoonChasingGuideInDelegation("0");

		// Token: 0x04024C8E RID: 150670
		public static readonly EMoonChasingGuideInDelegation Confirm = new EMoonChasingGuideInDelegation("1");

		// Token: 0x04024C8F RID: 150671
		public static readonly EMoonChasingGuideInDelegation RoleItem = new EMoonChasingGuideInDelegation("2");

		// Token: 0x04024C90 RID: 150672
		public static readonly EMoonChasingGuideInDelegation Recommend = new EMoonChasingGuideInDelegation("3");

		// Token: 0x04024C91 RID: 150673
		public static readonly EMoonChasingGuideInDelegation TeamAttr = new EMoonChasingGuideInDelegation("4");

		// Token: 0x04024C92 RID: 150674
		public static readonly EMoonChasingGuideInDelegation EditTeam = new EMoonChasingGuideInDelegation("EditTeam");
	}
}
