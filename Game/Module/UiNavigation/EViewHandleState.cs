using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD5 RID: 19669
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EViewHandleState : IEquatable<EViewHandleState>
	{
		// Token: 0x060332DD RID: 209629 RVA: 0x00CCFE0F File Offset: 0x00CCE00F
		private EViewHandleState(string value)
		{
			this._Value = value;
		}

		// Token: 0x060332DE RID: 209630 RVA: 0x00CCFE18 File Offset: 0x00CCE018
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x060332DF RID: 209631 RVA: 0x00CCFE20 File Offset: 0x00CCE020
		public bool Equals(EViewHandleState other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x060332E0 RID: 209632 RVA: 0x00CCFE34 File Offset: 0x00CCE034
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EViewHandleState)
			{
				EViewHandleState other = (EViewHandleState)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060332E1 RID: 209633 RVA: 0x00CCFE59 File Offset: 0x00CCE059
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x060332E2 RID: 209634 RVA: 0x00CCFE6C File Offset: 0x00CCE06C
		public static bool operator ==(EViewHandleState left, EViewHandleState right)
		{
			return left.Equals(right);
		}

		// Token: 0x060332E3 RID: 209635 RVA: 0x00CCFE76 File Offset: 0x00CCE076
		public static bool operator !=(EViewHandleState left, EViewHandleState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401DB9B RID: 121755
		private readonly string _Value;

		// Token: 0x0401DB9C RID: 121756
		public static readonly EViewHandleState None = new EViewHandleState("None");

		// Token: 0x0401DB9D RID: 121757
		public static readonly EViewHandleState NonNavigation = new EViewHandleState("NonNavigation");

		// Token: 0x0401DB9E RID: 121758
		public static readonly EViewHandleState NavigateNext = new EViewHandleState("NavigateNext");

		// Token: 0x0401DB9F RID: 121759
		public static readonly EViewHandleState HasNavigation = new EViewHandleState("HasNavigation");

		// Token: 0x0401DBA0 RID: 121760
		public static readonly EViewHandleState LoopNonNavigation = new EViewHandleState("LoopNonNavigation");

		// Token: 0x0401DBA1 RID: 121761
		public static readonly EViewHandleState HasNavigationButDisActive = new EViewHandleState("HasNavigationButDisActive");
	}
}
