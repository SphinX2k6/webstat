using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FF8 RID: 28664
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EKeyboardPrimaryLangId : IEquatable<EKeyboardPrimaryLangId>
	{
		// Token: 0x060455ED RID: 284141 RVA: 0x01222478 File Offset: 0x01220678
		private EKeyboardPrimaryLangId(string value)
		{
			this._value = value;
		}

		// Token: 0x060455EE RID: 284142 RVA: 0x01222481 File Offset: 0x01220681
		public bool Equals(EKeyboardPrimaryLangId other)
		{
			return this._value == other._value;
		}

		// Token: 0x060455EF RID: 284143 RVA: 0x01222494 File Offset: 0x01220694
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is EKeyboardPrimaryLangId)
			{
				EKeyboardPrimaryLangId other = (EKeyboardPrimaryLangId)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060455F0 RID: 284144 RVA: 0x012224B9 File Offset: 0x012206B9
		public override int GetHashCode()
		{
			if (this._value == null)
			{
				return 0;
			}
			return this._value.GetHashCode();
		}

		// Token: 0x060455F1 RID: 284145 RVA: 0x012224D0 File Offset: 0x012206D0
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x060455F2 RID: 284146 RVA: 0x012224D8 File Offset: 0x012206D8
		public static implicit operator string(EKeyboardPrimaryLangId id)
		{
			return id.ToString();
		}

		// Token: 0x060455F3 RID: 284147 RVA: 0x012224E7 File Offset: 0x012206E7
		public static explicit operator EKeyboardPrimaryLangId(string value)
		{
			return new EKeyboardPrimaryLangId(value);
		}

		// Token: 0x060455F4 RID: 284148 RVA: 0x012224EF File Offset: 0x012206EF
		public static bool operator ==(EKeyboardPrimaryLangId left, EKeyboardPrimaryLangId right)
		{
			return left.Equals(right);
		}

		// Token: 0x060455F5 RID: 284149 RVA: 0x012224F9 File Offset: 0x012206F9
		public static bool operator !=(EKeyboardPrimaryLangId left, EKeyboardPrimaryLangId right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04026C86 RID: 158854
		private readonly string _value;

		// Token: 0x04026C87 RID: 158855
		public static readonly EKeyboardPrimaryLangId Default = new EKeyboardPrimaryLangId("Default");

		// Token: 0x04026C88 RID: 158856
		public static readonly EKeyboardPrimaryLangId French = new EKeyboardPrimaryLangId("French");

		// Token: 0x04026C89 RID: 158857
		public static readonly EKeyboardPrimaryLangId German = new EKeyboardPrimaryLangId("German");

		// Token: 0x04026C8A RID: 158858
		public static readonly EKeyboardPrimaryLangId Italian = new EKeyboardPrimaryLangId("Italian");

		// Token: 0x04026C8B RID: 158859
		public static readonly EKeyboardPrimaryLangId Spanish = new EKeyboardPrimaryLangId("Spanish");

		// Token: 0x04026C8C RID: 158860
		public static readonly EKeyboardPrimaryLangId Swedish = new EKeyboardPrimaryLangId("Swedish");

		// Token: 0x04026C8D RID: 158861
		public static readonly EKeyboardPrimaryLangId Japanese = new EKeyboardPrimaryLangId("Japanese");

		// Token: 0x04026C8E RID: 158862
		public static readonly EKeyboardPrimaryLangId Russian = new EKeyboardPrimaryLangId("Russian");

		// Token: 0x04026C8F RID: 158863
		public static readonly EKeyboardPrimaryLangId Thai = new EKeyboardPrimaryLangId("Thai");
	}
}
