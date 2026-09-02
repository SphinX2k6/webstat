using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A13 RID: 18963
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EViewHotKeyHandleType : IEquatable<EViewHotKeyHandleType>
	{
		// Token: 0x060318F3 RID: 202995 RVA: 0x00C5A0EE File Offset: 0x00C582EE
		private EViewHotKeyHandleType(string value)
		{
			this._Value = value;
		}

		// Token: 0x060318F4 RID: 202996 RVA: 0x00C5A0F7 File Offset: 0x00C582F7
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x060318F5 RID: 202997 RVA: 0x00C5A0FF File Offset: 0x00C582FF
		public bool Equals(EViewHotKeyHandleType other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x060318F6 RID: 202998 RVA: 0x00C5A114 File Offset: 0x00C58314
		public override bool Equals(object obj)
		{
			if (obj is EViewHotKeyHandleType)
			{
				EViewHotKeyHandleType other = (EViewHotKeyHandleType)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060318F7 RID: 202999 RVA: 0x00C5A139 File Offset: 0x00C58339
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x060318F8 RID: 203000 RVA: 0x00C5A14C File Offset: 0x00C5834C
		public static bool operator ==(EViewHotKeyHandleType left, EViewHotKeyHandleType right)
		{
			return left.Equals(right);
		}

		// Token: 0x060318F9 RID: 203001 RVA: 0x00C5A156 File Offset: 0x00C58356
		public static bool operator !=(EViewHotKeyHandleType left, EViewHotKeyHandleType right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401CDCB RID: 118219
		private readonly string _Value;

		// Token: 0x0401CDCC RID: 118220
		public static readonly EViewHotKeyHandleType ViewHotKeyHandle = new EViewHotKeyHandleType("ViewHotKeyHandle");

		// Token: 0x0401CDCD RID: 118221
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleRoulette = new EViewHotKeyHandleType("ViewHotKeyHandleRoulette");

		// Token: 0x0401CDCE RID: 118222
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleFunctionMenu = new EViewHotKeyHandleType("ViewHotKeyHandleFunctionMenu");

		// Token: 0x0401CDCF RID: 118223
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleMapView = new EViewHotKeyHandleType("ViewHotKeyHandleMapView");

		// Token: 0x0401CDD0 RID: 118224
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleRoleRootView = new EViewHotKeyHandleType("ViewHotKeyHandleRoleRootView");

		// Token: 0x0401CDD1 RID: 118225
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleTrapDefenseRoulette = new EViewHotKeyHandleType("ViewHotKeyHandleTrapDefenseRoulette");

		// Token: 0x0401CDD2 RID: 118226
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleBackpackView = new EViewHotKeyHandleType("ViewHotKeyHandleBackpackView");

		// Token: 0x0401CDD3 RID: 118227
		public static readonly EViewHotKeyHandleType ViewHotKeyHandleQuestView = new EViewHotKeyHandleType("ViewHotKeyHandleQuestView");
	}
}
