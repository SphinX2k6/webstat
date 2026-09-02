using System;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x02004531 RID: 17713
	public class CheckConditions
	{
		// Token: 0x0602EA55 RID: 191061 RVA: 0x00B0CCCC File Offset: 0x00B0AECC
		public void ExpectChange(int num)
		{
			int num2 = 1 << num;
			if ((this.Expect & num2) > 0)
			{
				return;
			}
			this.Expect += 1 << num;
		}

		// Token: 0x0602EA56 RID: 191062 RVA: 0x00B0CD00 File Offset: 0x00B0AF00
		public void ValueChange(int num)
		{
			int num2 = 1 << num;
			if ((this.Value & num2) > 0)
			{
				return;
			}
			this.Value += 1 << num;
		}

		// Token: 0x0602EA57 RID: 191063 RVA: 0x00B0CD33 File Offset: 0x00B0AF33
		public bool Meet()
		{
			return this.Expect == this.Value;
		}

		// Token: 0x0401A7D6 RID: 108502
		private int Expect;

		// Token: 0x0401A7D7 RID: 108503
		private int Value;
	}
}
