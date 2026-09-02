using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x02006747 RID: 26439
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMoonChasingGuideInBusinessMain : IEquatable<EMoonChasingGuideInBusinessMain>
	{
		// Token: 0x06041EF0 RID: 270064 RVA: 0x010EA841 File Offset: 0x010E8A41
		private EMoonChasingGuideInBusinessMain(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041EF1 RID: 270065 RVA: 0x010EA84A File Offset: 0x010E8A4A
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041EF2 RID: 270066 RVA: 0x010EA852 File Offset: 0x010E8A52
		public bool Equals(EMoonChasingGuideInBusinessMain other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041EF3 RID: 270067 RVA: 0x010EA868 File Offset: 0x010E8A68
		public override bool Equals(object obj)
		{
			if (obj is EMoonChasingGuideInBusinessMain)
			{
				EMoonChasingGuideInBusinessMain other = (EMoonChasingGuideInBusinessMain)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041EF4 RID: 270068 RVA: 0x010EA88D File Offset: 0x010E8A8D
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041EF5 RID: 270069 RVA: 0x010EA8A0 File Offset: 0x010E8AA0
		public static bool operator ==(EMoonChasingGuideInBusinessMain left, EMoonChasingGuideInBusinessMain right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041EF6 RID: 270070 RVA: 0x010EA8AA File Offset: 0x010E8AAA
		public static bool operator !=(EMoonChasingGuideInBusinessMain left, EMoonChasingGuideInBusinessMain right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024C8A RID: 150666
		private readonly string _Value;

		// Token: 0x04024C8B RID: 150667
		public static readonly EMoonChasingGuideInBusinessMain Delegation = new EMoonChasingGuideInBusinessMain("Delegation");
	}
}
