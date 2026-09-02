using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200674C RID: 26444
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EMoonChasingGuideInMain : IEquatable<EMoonChasingGuideInMain>
	{
		// Token: 0x06041F08 RID: 270088 RVA: 0x010EAA46 File Offset: 0x010E8C46
		private EMoonChasingGuideInMain(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041F09 RID: 270089 RVA: 0x010EAA4F File Offset: 0x010E8C4F
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041F0A RID: 270090 RVA: 0x010EAA57 File Offset: 0x010E8C57
		public bool Equals(EMoonChasingGuideInMain other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041F0B RID: 270091 RVA: 0x010EAA6C File Offset: 0x010E8C6C
		public override bool Equals(object obj)
		{
			if (obj is EMoonChasingGuideInMain)
			{
				EMoonChasingGuideInMain other = (EMoonChasingGuideInMain)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041F0C RID: 270092 RVA: 0x010EAA91 File Offset: 0x010E8C91
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041F0D RID: 270093 RVA: 0x010EAAA4 File Offset: 0x010E8CA4
		public static bool operator ==(EMoonChasingGuideInMain left, EMoonChasingGuideInMain right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041F0E RID: 270094 RVA: 0x010EAAAE File Offset: 0x010E8CAE
		public static bool operator !=(EMoonChasingGuideInMain left, EMoonChasingGuideInMain right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024C9E RID: 150686
		private readonly string _Value;

		// Token: 0x04024C9F RID: 150687
		public static readonly EMoonChasingGuideInMain BuildMap = new EMoonChasingGuideInMain("BuildMap");
	}
}
