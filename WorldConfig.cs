using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x020032A3 RID: 12963
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WorldConfig : ConfigBase<WorldConfig>
{
	// Token: 0x0601B2D4 RID: 111316 RVA: 0x0082B4B1 File Offset: 0x008296B1
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601B2D5 RID: 111317 RVA: 0x0082B4B4 File Offset: 0x008296B4
	public Aki.Config.LockOnConfig? GetLockOnConfig(int id)
	{
		return ConfigLockOnConfigById.GetConfig(id, true);
	}

	// Token: 0x0601B2D6 RID: 111318 RVA: 0x0082B4C0 File Offset: 0x008296C0
	public UDataTable GetRoleCommonSkillInfo()
	{
		if (this.RoleCommonDataTable == null)
		{
			this.RoleCommonDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/DT_Common_Role_SkillInfo.DT_Common_Role_SkillInfo");
			this.RoleCommonDataTableRowNames = new List<string>();
			if (this.RoleCommonDataTable != null)
			{
				DataTableUtil.GetDataTableAllRowNamesFromTable(this.RoleCommonDataTable, this.RoleCommonDataTableRowNames);
			}
		}
		return this.RoleCommonDataTable;
	}

	// Token: 0x0601B2D7 RID: 111319 RVA: 0x0082B514 File Offset: 0x00829714
	[NullableContext(1)]
	public List<string> GetRoleCommonSkillRowNames()
	{
		if (this.RoleCommonDataTableRowNames == null)
		{
			this.GetRoleCommonSkillInfo();
		}
		return this.RoleCommonDataTableRowNames;
	}

	// Token: 0x0601B2D8 RID: 111320 RVA: 0x0082B52C File Offset: 0x0082972C
	public UDataTable GetMonsterCommonSkillInfo()
	{
		if (this.MonsterCommonDataTable == null)
		{
			this.MonsterCommonDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/DT_Common_Monster_SkillInfo.DT_Common_Monster_SkillInfo");
			this.MonsterCommonDataTableRowNames = new List<string>();
			if (this.MonsterCommonDataTable != null)
			{
				DataTableUtil.GetDataTableAllRowNamesFromTable(this.MonsterCommonDataTable, this.MonsterCommonDataTableRowNames);
			}
		}
		return this.MonsterCommonDataTable;
	}

	// Token: 0x0601B2D9 RID: 111321 RVA: 0x0082B580 File Offset: 0x00829780
	[NullableContext(1)]
	public List<string> GetMonsterCommonSkillRowNames()
	{
		if (this.MonsterCommonDataTableRowNames == null)
		{
			this.GetMonsterCommonSkillInfo();
		}
		return this.MonsterCommonDataTableRowNames;
	}

	// Token: 0x0601B2DA RID: 111322 RVA: 0x0082B598 File Offset: 0x00829798
	public UDataTable GetVisionCommonSkillInfo()
	{
		if (this.VisionCommonDataTable == null)
		{
			this.VisionCommonDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/DT_Common_Vision_SkillInfo.DT_Common_Vision_SkillInfo");
			this.VisionCommonDataTableRowNames = new List<string>();
			if (this.VisionCommonDataTable != null)
			{
				DataTableUtil.GetDataTableAllRowNamesFromTable(this.VisionCommonDataTable, this.VisionCommonDataTableRowNames);
			}
		}
		return this.VisionCommonDataTable;
	}

	// Token: 0x0601B2DB RID: 111323 RVA: 0x0082B5EC File Offset: 0x008297EC
	[NullableContext(1)]
	public List<string> GetVisionCommonSkillRowNames()
	{
		if (this.VisionCommonDataTableRowNames == null)
		{
			this.GetVisionCommonSkillInfo();
		}
		return this.VisionCommonDataTableRowNames;
	}

	// Token: 0x0601B2DC RID: 111324 RVA: 0x0082B603 File Offset: 0x00829803
	public UDataTable GetCaughtDataInfo()
	{
		if (this.CaughtDataTable == null)
		{
			this.CaughtDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/DT_CaughtInfo.DT_CaughtInfo");
		}
		return this.CaughtDataTable;
	}

	// Token: 0x0601B2DD RID: 111325 RVA: 0x0082B628 File Offset: 0x00829828
	public UDataTable GetCommonBulletData()
	{
		if (this.BulletCommonDataTable == null)
		{
			this.BulletCommonDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/CDT_CommonBulletData.CDT_CommonBulletData");
		}
		return this.BulletCommonDataTable;
	}

	// Token: 0x0601B2DE RID: 111326 RVA: 0x0082B64D File Offset: 0x0082984D
	public UDataTable GetCommonHitEffectData()
	{
		if (this.HitEffectCommonDataTable == null)
		{
			this.HitEffectCommonDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/DT_CommonHitEffect.DT_CommonHitEffect");
		}
		return this.HitEffectCommonDataTable;
	}

	// Token: 0x0601B2DF RID: 111327 RVA: 0x0082B672 File Offset: 0x00829872
	[NullableContext(1)]
	[return: Nullable(2)]
	public SCharacterFightInfo GetCharacterFightInfo(string characterResourcePath)
	{
		if (this.CharacterFightInfoDataTable == null)
		{
			this.CharacterFightInfoDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/CDT_CharacterFightInfo.CDT_CharacterFightInfo");
		}
		return DataTableUtil.GetDataTableRow<SCharacterFightInfo>(this.CharacterFightInfoDataTable, characterResourcePath);
	}

	// Token: 0x0601B2E0 RID: 111328 RVA: 0x0082B69D File Offset: 0x0082989D
	public void ClearCommonSkillData()
	{
		this.RoleCommonDataTable = null;
		this.BulletCommonDataTable = null;
		this.MonsterCommonDataTable = null;
		this.VisionCommonDataTable = null;
		this.CaughtDataTable = null;
		this.CharacterFightInfoDataTable = null;
	}

	// Token: 0x0601B2E1 RID: 111329 RVA: 0x0082B6C9 File Offset: 0x008298C9
	public RoleInfo? GetRoleConfig(int roleId)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
	}

	// Token: 0x0601B2E2 RID: 111330 RVA: 0x0082B6D6 File Offset: 0x008298D6
	protected override bool OnClear()
	{
		this.ClearCommonSkillData();
		return true;
	}

	// Token: 0x0601B2E3 RID: 111331 RVA: 0x0082B6E0 File Offset: 0x008298E0
	public UDataTable GetQteTagDataTable()
	{
		if (this.QteTagDataTable == null)
		{
			this.QteTagDataTable = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>("/Game/Aki/Data/Fight/DT_QteTag.DT_QteTag");
			this.QteTagDataMap = new Dictionary<int, string>();
			if (this.QteTagDataTable != null)
			{
				List<DataTableKeyRow<SQteTag>> list = new List<DataTableKeyRow<SQteTag>>();
				DataTableUtil.GetDataTableAllRowWithKeysFromTable<SQteTag>(this.QteTagDataTable, list);
				foreach (DataTableKeyRow<SQteTag> dataTableKeyRow in list)
				{
					if (dataTableKeyRow.Key != null && !(dataTableKeyRow.Value == null))
					{
						string key = dataTableKeyRow.Key;
						SQteTag value = dataTableKeyRow.Value;
						if (value.QteTag.TagName != FName.NAME_None)
						{
							if (this.QteTagDataMap.ContainsKey(value.QteTag.TagId()))
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.Config;
								ELogAuthor author = ELogAuthor.HXY;
								string message = "DT_QteTag重复注册QTE标签";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tag", value.QteTag.TagName.ToString());
								instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							}
							else
							{
								this.QteTagDataMap.Add(value.QteTag.TagId(), key);
							}
						}
					}
				}
			}
		}
		return this.QteTagDataTable;
	}

	// Token: 0x0601B2E4 RID: 111332 RVA: 0x0082B834 File Offset: 0x00829A34
	[NullableContext(1)]
	public Dictionary<int, string> GetQteTagDataMap()
	{
		if (this.QteTagDataMap == null)
		{
			this.GetQteTagDataTable();
		}
		return this.QteTagDataMap;
	}

	// Token: 0x0400DD5C RID: 56668
	[Nullable(1)]
	private const string ROLE_COMMON_SKILLINFO_PATH = "/Game/Aki/Data/Fight/DT_Common_Role_SkillInfo.DT_Common_Role_SkillInfo";

	// Token: 0x0400DD5D RID: 56669
	[Nullable(1)]
	private const string MONSTER_COMMON_SKILLINFO_PATH = "/Game/Aki/Data/Fight/DT_Common_Monster_SkillInfo.DT_Common_Monster_SkillInfo";

	// Token: 0x0400DD5E RID: 56670
	[Nullable(1)]
	private const string VISION_COMMON_SKILLINFO_PATH = "/Game/Aki/Data/Fight/DT_Common_Vision_SkillInfo.DT_Common_Vision_SkillInfo";

	// Token: 0x0400DD5F RID: 56671
	[Nullable(1)]
	private const string COMMON_BULLET_PATH = "/Game/Aki/Data/Fight/CDT_CommonBulletData.CDT_CommonBulletData";

	// Token: 0x0400DD60 RID: 56672
	[Nullable(1)]
	private const string COMMON_HIT_EFFECT_PATH = "/Game/Aki/Data/Fight/DT_CommonHitEffect.DT_CommonHitEffect";

	// Token: 0x0400DD61 RID: 56673
	[Nullable(1)]
	private const string CAUGHT_DATA_PATH = "/Game/Aki/Data/Fight/DT_CaughtInfo.DT_CaughtInfo";

	// Token: 0x0400DD62 RID: 56674
	[Nullable(1)]
	private const string CHARACTERFIGHTINFO_DATA_PATH = "/Game/Aki/Data/Fight/CDT_CharacterFightInfo.CDT_CharacterFightInfo";

	// Token: 0x0400DD63 RID: 56675
	[Nullable(1)]
	private const string QTE_TAG_DATA_PATH = "/Game/Aki/Data/Fight/DT_QteTag.DT_QteTag";

	// Token: 0x0400DD64 RID: 56676
	private UDataTable RoleCommonDataTable;

	// Token: 0x0400DD65 RID: 56677
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> RoleCommonDataTableRowNames;

	// Token: 0x0400DD66 RID: 56678
	private UDataTable MonsterCommonDataTable;

	// Token: 0x0400DD67 RID: 56679
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> MonsterCommonDataTableRowNames;

	// Token: 0x0400DD68 RID: 56680
	private UDataTable VisionCommonDataTable;

	// Token: 0x0400DD69 RID: 56681
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> VisionCommonDataTableRowNames;

	// Token: 0x0400DD6A RID: 56682
	private UDataTable BulletCommonDataTable;

	// Token: 0x0400DD6B RID: 56683
	private UDataTable HitEffectCommonDataTable;

	// Token: 0x0400DD6C RID: 56684
	private UDataTable CaughtDataTable;

	// Token: 0x0400DD6D RID: 56685
	private UDataTable CharacterFightInfoDataTable;

	// Token: 0x0400DD6E RID: 56686
	private UDataTable QteTagDataTable;

	// Token: 0x0400DD6F RID: 56687
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, string> QteTagDataMap;
}
