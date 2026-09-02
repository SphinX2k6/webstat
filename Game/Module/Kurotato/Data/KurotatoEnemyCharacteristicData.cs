using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AEB RID: 23275
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoEnemyCharacteristicData
	{
		// Token: 0x170095AD RID: 38317
		// (get) Token: 0x0603ADB4 RID: 241076 RVA: 0x00EEDA6A File Offset: 0x00EEBC6A
		// (set) Token: 0x0603ADB5 RID: 241077 RVA: 0x00EEDA72 File Offset: 0x00EEBC72
		public int Id { get; set; }

		// Token: 0x170095AE RID: 38318
		// (get) Token: 0x0603ADB6 RID: 241078 RVA: 0x00EEDA7B File Offset: 0x00EEBC7B
		// (set) Token: 0x0603ADB7 RID: 241079 RVA: 0x00EEDA83 File Offset: 0x00EEBC83
		public string IconPath { get; set; } = "";

		// Token: 0x170095AF RID: 38319
		// (get) Token: 0x0603ADB8 RID: 241080 RVA: 0x00EEDA8C File Offset: 0x00EEBC8C
		// (set) Token: 0x0603ADB9 RID: 241081 RVA: 0x00EEDA94 File Offset: 0x00EEBC94
		public string Name { get; set; } = "";

		// Token: 0x170095B0 RID: 38320
		// (get) Token: 0x0603ADBA RID: 241082 RVA: 0x00EEDA9D File Offset: 0x00EEBC9D
		// (set) Token: 0x0603ADBB RID: 241083 RVA: 0x00EEDAA5 File Offset: 0x00EEBCA5
		public string Desc { get; set; } = "";

		// Token: 0x0603ADBC RID: 241084 RVA: 0x00EEDAB0 File Offset: 0x00EEBCB0
		public KurotatoEnemyCharacteristicData(int id)
		{
			this.Id = id;
			KurotatoMonsterTag? monsterTagById = ConfigBase<KurotatoConfig>.Instance.GetMonsterTagById(id);
			if (monsterTagById == null)
			{
				return;
			}
			this.IconPath = monsterTagById.Value.Icon;
			this.Name = monsterTagById.Value.Name;
			this.Desc = monsterTagById.Value.Desc;
		}
	}
}
