using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004678 RID: 18040
	[NullableContext(2)]
	[Nullable(0)]
	public class Partial<T>
	{
		// Token: 0x0602F05F RID: 192607 RVA: 0x00B24613 File Offset: 0x00B22813
		public Partial(T value)
		{
			this.Value = value;
		}

		// Token: 0x0602F060 RID: 192608 RVA: 0x00B24624 File Offset: 0x00B22824
		public U GetValue<U>([Nullable(1)] Func<T, U> selector)
		{
			if (this.Value == null)
			{
				return default(U);
			}
			return selector(this.Value);
		}

		// Token: 0x0401AC7C RID: 109692
		private readonly T Value;
	}
}
