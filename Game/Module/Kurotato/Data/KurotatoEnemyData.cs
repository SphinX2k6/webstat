using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;

namespace CSharpScript.Game.Module.Kurotato.Data
{
	// Token: 0x02005AEF RID: 23279
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoEnemyData
	{
		// Token: 0x170095B7 RID: 38327
		// (get) Token: 0x0603ADCD RID: 241101 RVA: 0x00EEE034 File Offset: 0x00EEC234
		// (set) Token: 0x0603ADCE RID: 241102 RVA: 0x00EEE03C File Offset: 0x00EEC23C
		public int MonsterId { get; set; }

		// Token: 0x170095B8 RID: 38328
		// (get) Token: 0x0603ADCF RID: 241103 RVA: 0x00EEE045 File Offset: 0x00EEC245
		// (set) Token: 0x0603ADD0 RID: 241104 RVA: 0x00EEE04D File Offset: 0x00EEC24D
		public int CountNum { get; set; } = 1;

		// Token: 0x170095B9 RID: 38329
		// (get) Token: 0x0603ADD1 RID: 241105 RVA: 0x00EEE056 File Offset: 0x00EEC256
		// (set) Token: 0x0603ADD2 RID: 241106 RVA: 0x00EEE05E File Offset: 0x00EEC25E
		public string Name { get; set; } = "";

		// Token: 0x170095BA RID: 38330
		// (get) Token: 0x0603ADD3 RID: 241107 RVA: 0x00EEE067 File Offset: 0x00EEC267
		// (set) Token: 0x0603ADD4 RID: 241108 RVA: 0x00EEE06F File Offset: 0x00EEC26F
		public string Desc { get; set; } = "";

		// Token: 0x170095BB RID: 38331
		// (get) Token: 0x0603ADD5 RID: 241109 RVA: 0x00EEE078 File Offset: 0x00EEC278
		// (set) Token: 0x0603ADD6 RID: 241110 RVA: 0x00EEE080 File Offset: 0x00EEC280
		public string IconPath { get; set; } = "";

		// Token: 0x170095BC RID: 38332
		// (get) Token: 0x0603ADD7 RID: 241111 RVA: 0x00EEE089 File Offset: 0x00EEC289
		// (set) Token: 0x0603ADD8 RID: 241112 RVA: 0x00EEE091 File Offset: 0x00EEC291
		public int RiskType { get; set; }

		// Token: 0x170095BD RID: 38333
		// (get) Token: 0x0603ADD9 RID: 241113 RVA: 0x00EEE09A File Offset: 0x00EEC29A
		// (set) Token: 0x0603ADDA RID: 241114 RVA: 0x00EEE0A2 File Offset: 0x00EEC2A2
		public int BodyType { get; set; }

		// Token: 0x170095BE RID: 38334
		// (get) Token: 0x0603ADDB RID: 241115 RVA: 0x00EEE0AB File Offset: 0x00EEC2AB
		// (set) Token: 0x0603ADDC RID: 241116 RVA: 0x00EEE0B3 File Offset: 0x00EEC2B3
		public KurotatoMonsterRisk? RiskTypeConfig { get; set; }

		// Token: 0x170095BF RID: 38335
		// (get) Token: 0x0603ADDD RID: 241117 RVA: 0x00EEE0BC File Offset: 0x00EEC2BC
		// (set) Token: 0x0603ADDE RID: 241118 RVA: 0x00EEE0C4 File Offset: 0x00EEC2C4
		public KurotatoMonsterBody? BodyTypeConfig { get; set; }

		// Token: 0x170095C0 RID: 38336
		// (get) Token: 0x0603ADDF RID: 241119 RVA: 0x00EEE0CD File Offset: 0x00EEC2CD
		// (set) Token: 0x0603ADE0 RID: 241120 RVA: 0x00EEE0D5 File Offset: 0x00EEC2D5
		public List<KurotatoEnemyBasePropertyData> BasePropertyDataList { get; set; } = new List<KurotatoEnemyBasePropertyData>();

		// Token: 0x170095C1 RID: 38337
		// (get) Token: 0x0603ADE1 RID: 241121 RVA: 0x00EEE0DE File Offset: 0x00EEC2DE
		// (set) Token: 0x0603ADE2 RID: 241122 RVA: 0x00EEE0E6 File Offset: 0x00EEC2E6
		public List<KurotatoEnemyCharacteristicData> CharacteristicDataList { get; set; } = new List<KurotatoEnemyCharacteristicData>();

		// Token: 0x0603ADE3 RID: 241123 RVA: 0x00EEE0F0 File Offset: 0x00EEC2F0
		public KurotatoEnemyData(int monsterId, int countNum = 1)
		{
			this.MonsterId = monsterId;
			this.CountNum = countNum;
			KurotatoMonster? monsterConfigById = ConfigBase<KurotatoConfig>.Instance.GetMonsterConfigById(monsterId);
			KurotatoMonsterType? monsterTypeById = ConfigBase<KurotatoConfig>.Instance.GetMonsterTypeById(monsterId);
			if (monsterConfigById == null || monsterTypeById == null)
			{
				return;
			}
			this.Name = monsterConfigById.Value.Name;
			this.Desc = monsterConfigById.Value.Desc;
			this.IconPath = monsterTypeById.Value.Icon;
			this.RiskType = monsterTypeById.Value.RiskType;
			this.BodyType = monsterTypeById.Value.BodyType;
			this.RiskTypeConfig = ConfigBase<KurotatoConfig>.Instance.GetMonsterRiskConfig(this.RiskType);
			this.BodyTypeConfig = ConfigBase<KurotatoConfig>.Instance.GetBodyTypeConfig(this.BodyType);
			KSCBaseProperty? baseProperty = ConfigBase<KurotatoConfig>.Instance.GetBaseProperty(monsterConfigById.Value.BasicProperty);
			if (baseProperty != null)
			{
				int lifeMax = baseProperty.Value.LifeMax;
				int moveSpeed = baseProperty.Value.MoveSpeed;
				int atk = baseProperty.Value.Atk;
				if (lifeMax > 0)
				{
					this.BasePropertyDataList.Add(new KurotatoEnemyBasePropertyData(EKurotatoEnemyAttrType.LifeMax, lifeMax));
				}
				if (moveSpeed > 0)
				{
					this.BasePropertyDataList.Add(new KurotatoEnemyBasePropertyData(EKurotatoEnemyAttrType.MoveSpeed, moveSpeed));
				}
				if (atk > 0)
				{
					this.BasePropertyDataList.Add(new KurotatoEnemyBasePropertyData(EKurotatoEnemyAttrType.Attack, atk));
				}
			}
			int tagLength = monsterConfigById.Value.TagLength;
			for (int i = 0; i < tagLength; i++)
			{
				int id = monsterConfigById.Value.Tag(i);
				this.CharacteristicDataList.Add(new KurotatoEnemyCharacteristicData(id));
			}
		}

		// Token: 0x0603ADE4 RID: 241124 RVA: 0x00EEE300 File Offset: 0x00EEC500
		public string GetQualityPathGrid()
		{
			return this.RiskTypeConfig.Value.GridQualityPath;
		}

		// Token: 0x0603ADE5 RID: 241125 RVA: 0x00EEE324 File Offset: 0x00EEC524
		public List<string> GetGridTagPathList()
		{
			KurotatoMonster? monsterConfigById = ConfigBase<KurotatoConfig>.Instance.GetMonsterConfigById(this.MonsterId);
			if (monsterConfigById == null)
			{
				return new List<string>();
			}
			int tagLength = monsterConfigById.Value.TagLength;
			List<string> list = new List<string>();
			for (int i = 0; i < tagLength; i++)
			{
				int tagId = monsterConfigById.Value.Tag(i);
				KurotatoMonsterTag? monsterTagById = ConfigBase<KurotatoConfig>.Instance.GetMonsterTagById(tagId);
				string text = ((monsterTagById != null) ? monsterTagById.GetValueOrDefault().Icon : null) ?? "";
				if (text != "")
				{
					list.Add(text);
				}
			}
			if (list.Count == 0)
			{
				UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
				string item = ((instance != null) ? instance.GetResourcePath(ETrapDefenseResKey.MonsterTagUnStateIcon.ToString()) : null) ?? "";
				return new List<string>
				{
					item
				};
			}
			return list;
		}

		// Token: 0x0603ADE6 RID: 241126 RVA: 0x00EEE418 File Offset: 0x00EEC618
		public string GetRiskTypeText()
		{
			if (this.RiskTypeConfig == null)
			{
				return "";
			}
			return this.RiskTypeConfig.Value.Name;
		}

		// Token: 0x0603ADE7 RID: 241127 RVA: 0x00EEE454 File Offset: 0x00EEC654
		public string GetBodyTypeText()
		{
			if (this.BodyTypeConfig == null)
			{
				return "";
			}
			return this.BodyTypeConfig.Value.Name;
		}
	}
}
