using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD4 RID: 19668
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ENavigationGroupName : IEquatable<ENavigationGroupName>
	{
		// Token: 0x060332D4 RID: 209620 RVA: 0x00CCFD7B File Offset: 0x00CCDF7B
		private ENavigationGroupName(string value)
		{
			this._value = value;
		}

		// Token: 0x060332D5 RID: 209621 RVA: 0x00CCFD84 File Offset: 0x00CCDF84
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x060332D6 RID: 209622 RVA: 0x00CCFD8C File Offset: 0x00CCDF8C
		public bool Equals(ENavigationGroupName other)
		{
			return this._value == other._value;
		}

		// Token: 0x060332D7 RID: 209623 RVA: 0x00CCFDA0 File Offset: 0x00CCDFA0
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is ENavigationGroupName)
			{
				ENavigationGroupName other = (ENavigationGroupName)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060332D8 RID: 209624 RVA: 0x00CCFDC5 File Offset: 0x00CCDFC5
		public override int GetHashCode()
		{
			string value = this._value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x060332D9 RID: 209625 RVA: 0x00CCFDD8 File Offset: 0x00CCDFD8
		public static bool operator ==(ENavigationGroupName left, ENavigationGroupName right)
		{
			return left.Equals(right);
		}

		// Token: 0x060332DA RID: 209626 RVA: 0x00CCFDE2 File Offset: 0x00CCDFE2
		public static bool operator !=(ENavigationGroupName left, ENavigationGroupName right)
		{
			return !left.Equals(right);
		}

		// Token: 0x060332DB RID: 209627 RVA: 0x00CCFDEF File Offset: 0x00CCDFEF
		public static implicit operator string(ENavigationGroupName id)
		{
			return id.ToString();
		}

		// Token: 0x0401DB99 RID: 121753
		private readonly string _value;

		// Token: 0x0401DB9A RID: 121754
		public static readonly ENavigationGroupName NewSoundDetectItemGroup = new ENavigationGroupName("Group3");
	}
}
