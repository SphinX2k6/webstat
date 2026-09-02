using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AEA RID: 23274
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoEnemyBasePropertyData
	{
		// Token: 0x170095AA RID: 38314
		// (get) Token: 0x0603ADAD RID: 241069 RVA: 0x00EED9B3 File Offset: 0x00EEBBB3
		// (set) Token: 0x0603ADAE RID: 241070 RVA: 0x00EED9BB File Offset: 0x00EEBBBB
		public string IconPath { get; set; } = "";

		// Token: 0x170095AB RID: 38315
		// (get) Token: 0x0603ADAF RID: 241071 RVA: 0x00EED9C4 File Offset: 0x00EEBBC4
		// (set) Token: 0x0603ADB0 RID: 241072 RVA: 0x00EED9CC File Offset: 0x00EEBBCC
		public string Name { get; set; } = "";

		// Token: 0x170095AC RID: 38316
		// (get) Token: 0x0603ADB1 RID: 241073 RVA: 0x00EED9D5 File Offset: 0x00EEBBD5
		// (set) Token: 0x0603ADB2 RID: 241074 RVA: 0x00EED9DD File Offset: 0x00EEBBDD
		public int Value { get; set; }

		// Token: 0x0603ADB3 RID: 241075 RVA: 0x00EED9E8 File Offset: 0x00EEBBE8
		public KurotatoEnemyBasePropertyData(EKurotatoEnemyAttrType attrType, int value)
		{
			KurotatoMonsterAttribute? monsterAttribute = ConfigBase<KurotatoConfig>.Instance.GetMonsterAttribute((int)attrType);
			if (monsterAttribute == null)
			{
				return;
			}
			this.IconPath = (monsterAttribute.Value.Icon ?? "");
			this.Name = (monsterAttribute.Value.Name ?? "");
			this.Value = value;
		}
	}
}
