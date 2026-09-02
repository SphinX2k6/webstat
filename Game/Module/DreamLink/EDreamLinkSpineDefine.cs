using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D9E RID: 23966
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct EDreamLinkSpineDefine : IEquatable<EDreamLinkSpineDefine>
	{
		// Token: 0x0603C586 RID: 247174 RVA: 0x00F50698 File Offset: 0x00F4E898
		private EDreamLinkSpineDefine(string value)
		{
			this._Value = value;
		}

		// Token: 0x0603C587 RID: 247175 RVA: 0x00F506A1 File Offset: 0x00F4E8A1
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x0603C588 RID: 247176 RVA: 0x00F506A9 File Offset: 0x00F4E8A9
		public bool Equals(EDreamLinkSpineDefine other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x0603C589 RID: 247177 RVA: 0x00F506BC File Offset: 0x00F4E8BC
		public override bool Equals(object obj)
		{
			if (obj is EDreamLinkSpineDefine)
			{
				EDreamLinkSpineDefine other = (EDreamLinkSpineDefine)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x0603C58A RID: 247178 RVA: 0x00F506E1 File Offset: 0x00F4E8E1
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x0603C58B RID: 247179 RVA: 0x00F506F4 File Offset: 0x00F4E8F4
		public static bool operator ==(EDreamLinkSpineDefine left, EDreamLinkSpineDefine right)
		{
			return left.Equals(right);
		}

		// Token: 0x0603C58C RID: 247180 RVA: 0x00F506FE File Offset: 0x00F4E8FE
		public static bool operator !=(EDreamLinkSpineDefine left, EDreamLinkSpineDefine right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04021EE1 RID: 138977
		private readonly string _Value;

		// Token: 0x04021EE2 RID: 138978
		public static readonly EDreamLinkSpineDefine MainFemale = new EDreamLinkSpineDefine("nvzhu");

		// Token: 0x04021EE3 RID: 138979
		public static readonly EDreamLinkSpineDefine MainMale = new EDreamLinkSpineDefine("nanzhu");

		// Token: 0x04021EE4 RID: 138980
		public static readonly EDreamLinkSpineDefine Idle = new EDreamLinkSpineDefine("idle");

		// Token: 0x04021EE5 RID: 138981
		public static readonly EDreamLinkSpineDefine Start = new EDreamLinkSpineDefine("start");
	}
}
