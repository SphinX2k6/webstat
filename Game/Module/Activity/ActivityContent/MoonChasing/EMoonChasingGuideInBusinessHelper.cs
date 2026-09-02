using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200674B RID: 26443
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMoonChasingGuideInBusinessHelper : IEquatable<EMoonChasingGuideInBusinessHelper>
	{
		// Token: 0x06041F00 RID: 270080 RVA: 0x010EA9A3 File Offset: 0x010E8BA3
		private EMoonChasingGuideInBusinessHelper(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041F01 RID: 270081 RVA: 0x010EA9AC File Offset: 0x010E8BAC
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041F02 RID: 270082 RVA: 0x010EA9B4 File Offset: 0x010E8BB4
		public bool Equals(EMoonChasingGuideInBusinessHelper other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041F03 RID: 270083 RVA: 0x010EA9C8 File Offset: 0x010E8BC8
		public override bool Equals(object obj)
		{
			if (obj is EMoonChasingGuideInBusinessHelper)
			{
				EMoonChasingGuideInBusinessHelper other = (EMoonChasingGuideInBusinessHelper)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041F04 RID: 270084 RVA: 0x010EA9ED File Offset: 0x010E8BED
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041F05 RID: 270085 RVA: 0x010EAA00 File Offset: 0x010E8C00
		public static bool operator ==(EMoonChasingGuideInBusinessHelper left, EMoonChasingGuideInBusinessHelper right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041F06 RID: 270086 RVA: 0x010EAA0A File Offset: 0x010E8C0A
		public static bool operator !=(EMoonChasingGuideInBusinessHelper left, EMoonChasingGuideInBusinessHelper right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024C9A RID: 150682
		private readonly string _Value;

		// Token: 0x04024C9B RID: 150683
		public static readonly EMoonChasingGuideInBusinessHelper Helper = new EMoonChasingGuideInBusinessHelper("Helper");

		// Token: 0x04024C9C RID: 150684
		public static readonly EMoonChasingGuideInBusinessHelper HelperFirst = new EMoonChasingGuideInBusinessHelper("HelperFirst");

		// Token: 0x04024C9D RID: 150685
		public static readonly EMoonChasingGuideInBusinessHelper Interactive = new EMoonChasingGuideInBusinessHelper("Interactive");
	}
}
