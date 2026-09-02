using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DF7 RID: 24055
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ECookMechanismState : IEquatable<ECookMechanismState>
	{
		// Token: 0x0603C85E RID: 247902 RVA: 0x00F5F46E File Offset: 0x00F5D66E
		private ECookMechanismState(string value)
		{
			this._Value = value;
		}

		// Token: 0x0603C85F RID: 247903 RVA: 0x00F5F477 File Offset: 0x00F5D677
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x0603C860 RID: 247904 RVA: 0x00F5F47F File Offset: 0x00F5D67F
		public bool Equals(ECookMechanismState other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0603C861 RID: 247905 RVA: 0x00F5F494 File Offset: 0x00F5D694
		public override bool Equals(object obj)
		{
			if (obj is ECookMechanismState)
			{
				ECookMechanismState other = (ECookMechanismState)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0603C862 RID: 247906 RVA: 0x00F5F4B9 File Offset: 0x00F5D6B9
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0603C863 RID: 247907 RVA: 0x00F5F4CC File Offset: 0x00F5D6CC
		public static bool operator ==(ECookMechanismState left, ECookMechanismState right)
		{
			return left.Equals(right);
		}

		// Token: 0x0603C864 RID: 247908 RVA: 0x00F5F4D6 File Offset: 0x00F5D6D6
		public static bool operator !=(ECookMechanismState left, ECookMechanismState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0402207F RID: 139391
		private readonly string _Value;

		// Token: 0x04022080 RID: 139392
		public static readonly ECookMechanismState CookDone = new ECookMechanismState("finishcook");

		// Token: 0x04022081 RID: 139393
		public static readonly ECookMechanismState CloseUi = new ECookMechanismState("endcook");

		// Token: 0x04022082 RID: 139394
		public static readonly ECookMechanismState EnterUi = new ECookMechanismState("opencook");
	}
}
