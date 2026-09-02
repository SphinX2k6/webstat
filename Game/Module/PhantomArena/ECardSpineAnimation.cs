using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200546F RID: 21615
	[NullableContext(1)]
	[Nullable(0)]
	public readonly struct ECardSpineAnimation : IEquatable<ECardSpineAnimation>
	{
		// Token: 0x0603717F RID: 225663 RVA: 0x00DFD6E0 File Offset: 0x00DFB8E0
		private ECardSpineAnimation(string value)
		{
			this._Value = value;
		}

		// Token: 0x06037180 RID: 225664 RVA: 0x00DFD6E9 File Offset: 0x00DFB8E9
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06037181 RID: 225665 RVA: 0x00DFD6F1 File Offset: 0x00DFB8F1
		public bool Equals(ECardSpineAnimation other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06037182 RID: 225666 RVA: 0x00DFD704 File Offset: 0x00DFB904
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is ECardSpineAnimation)
			{
				ECardSpineAnimation other = (ECardSpineAnimation)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06037183 RID: 225667 RVA: 0x00DFD729 File Offset: 0x00DFB929
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06037184 RID: 225668 RVA: 0x00DFD73C File Offset: 0x00DFB93C
		public static bool operator ==(ECardSpineAnimation left, ECardSpineAnimation right)
		{
			return left.Equals(right);
		}

		// Token: 0x06037185 RID: 225669 RVA: 0x00DFD746 File Offset: 0x00DFB946
		public static bool operator !=(ECardSpineAnimation left, ECardSpineAnimation right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0401FB11 RID: 129809
		private readonly string _Value;

		// Token: 0x0401FB12 RID: 129810
		public static readonly ECardSpineAnimation Start = new ECardSpineAnimation("start");

		// Token: 0x0401FB13 RID: 129811
		public static readonly ECardSpineAnimation Idle = new ECardSpineAnimation("idle");
	}
}
