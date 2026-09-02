using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform
{
	// Token: 0x02006AB0 RID: 27312
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritBasePerform
	{
		// Token: 0x0604387C RID: 276604 RVA: 0x01168E32 File Offset: 0x01167032
		public SunSpiritBasePerform(SunSpiritData sunSpiritData)
		{
			this.SunSpiritData = sunSpiritData;
		}

		// Token: 0x0604387D RID: 276605 RVA: 0x01168E41 File Offset: 0x01167041
		public bool Init()
		{
			return this.OnInit();
		}

		// Token: 0x0604387E RID: 276606 RVA: 0x01168E49 File Offset: 0x01167049
		protected virtual bool OnInit()
		{
			return true;
		}

		// Token: 0x0604387F RID: 276607 RVA: 0x01168E4C File Offset: 0x0116704C
		public void Destroy()
		{
			this.OnDestroy();
		}

		// Token: 0x06043880 RID: 276608 RVA: 0x01168E54 File Offset: 0x01167054
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x04025BA7 RID: 154535
		protected SunSpiritData SunSpiritData;
	}
}
