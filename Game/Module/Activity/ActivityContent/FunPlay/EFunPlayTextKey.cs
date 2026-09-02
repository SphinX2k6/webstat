using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006773 RID: 26483
	[NullableContext(1)]
	[Nullable(0)]
	internal struct EFunPlayTextKey : IEquatable<EFunPlayTextKey>
	{
		// Token: 0x06042043 RID: 270403 RVA: 0x010F0088 File Offset: 0x010EE288
		private EFunPlayTextKey(string value)
		{
			this._Value = value;
		}

		// Token: 0x06042044 RID: 270404 RVA: 0x010F0091 File Offset: 0x010EE291
		public override string ToString()
		{
			return this._Value;
		}

		// Token: 0x06042045 RID: 270405 RVA: 0x010F0099 File Offset: 0x010EE299
		public bool Equals(EFunPlayTextKey other)
		{
			return this._Value == other._Value;
		}

		// Token: 0x06042046 RID: 270406 RVA: 0x010F00AC File Offset: 0x010EE2AC
		public override bool Equals(object obj)
		{
			if (obj is EFunPlayTextKey)
			{
				EFunPlayTextKey other = (EFunPlayTextKey)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x06042047 RID: 270407 RVA: 0x010F00D1 File Offset: 0x010EE2D1
		public override int GetHashCode()
		{
			string value = this._Value;
			if (value == null)
			{
				return 0;
			}
			return value.GetHashCode();
		}

		// Token: 0x06042048 RID: 270408 RVA: 0x010F00E4 File Offset: 0x010EE2E4
		public static bool operator ==(EFunPlayTextKey left, EFunPlayTextKey right)
		{
			return left.Equals(right);
		}

		// Token: 0x06042049 RID: 270409 RVA: 0x010F00EE File Offset: 0x010EE2EE
		public static bool operator !=(EFunPlayTextKey left, EFunPlayTextKey right)
		{
			return !left.Equals(right);
		}

		// Token: 0x04024D07 RID: 150791
		private readonly string _Value;

		// Token: 0x04024D08 RID: 150792
		public static readonly EFunPlayTextKey GotoMain = new EFunPlayTextKey("PrefabTextItem_708485707_Text");

		// Token: 0x04024D09 RID: 150793
		public static readonly EFunPlayTextKey NoComment = new EFunPlayTextKey("Activity_105900001_Lock");

		// Token: 0x04024D0A RID: 150794
		public static readonly EFunPlayTextKey UnlockTxt = new EFunPlayTextKey("Activity_105900001_Locktime");
	}
}
