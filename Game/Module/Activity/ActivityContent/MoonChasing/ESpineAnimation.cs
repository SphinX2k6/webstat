using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing
{
	// Token: 0x0200673D RID: 26429
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ESpineAnimation : IEquatable<ESpineAnimation>
	{
		// Token: 0x06041EBD RID: 270013 RVA: 0x010EA6B8 File Offset: 0x010E88B8
		private ESpineAnimation(string value)
		{
			this._Value = value;
		}

		// Token: 0x06041EBE RID: 270014 RVA: 0x010EA6C1 File Offset: 0x010E88C1
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06041EBF RID: 270015 RVA: 0x010EA6C9 File Offset: 0x010E88C9
		public bool Equals(ESpineAnimation other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06041EC0 RID: 270016 RVA: 0x010EA6DC File Offset: 0x010E88DC
		public override bool Equals(object obj)
		{
			if (obj is ESpineAnimation)
			{
				ESpineAnimation other = (ESpineAnimation)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06041EC1 RID: 270017 RVA: 0x010EA701 File Offset: 0x010E8901
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06041EC2 RID: 270018 RVA: 0x010EA714 File Offset: 0x010E8914
		public static bool operator ==(ESpineAnimation left, ESpineAnimation right)
		{
			return left.Equals(right);
		}

		// Token: 0x06041EC3 RID: 270019 RVA: 0x010EA71E File Offset: 0x010E891E
		public static bool operator !=(ESpineAnimation left, ESpineAnimation right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024C70 RID: 150640
		private readonly string _Value;

		// Token: 0x04024C71 RID: 150641
		public static readonly ESpineAnimation Idle = new ESpineAnimation("idle");

		// Token: 0x04024C72 RID: 150642
		public static readonly ESpineAnimation Success = new ESpineAnimation("happy");

		// Token: 0x04024C73 RID: 150643
		public static readonly ESpineAnimation Fail = new ESpineAnimation("fail");

		// Token: 0x04024C74 RID: 150644
		public static readonly ESpineAnimation Working = new ESpineAnimation("working");
	}
}
