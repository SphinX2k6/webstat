using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002D9B RID: 11675
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BulletConfig : ConfigBase<BulletConfig>
{
	// Token: 0x060178CC RID: 96460 RVA: 0x0068CAB0 File Offset: 0x0068ACB0
	public unsafe void RemoveCacheBulletDataByEntityId(int entityId)
	{
		int num;
		if (!this.EntityMap.TryGetValue(entityId, out num))
		{
			return;
		}
		this.EntityMap.Remove(entityId);
		BulletDataCacheInfo bulletDataCacheInfo;
		if (!this.BulletDataCacheMap.TryGetValue(num, out bulletDataCacheInfo))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "删除实体时，子弹缓存里没有对应的数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("modelId", num);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		bulletDataCacheInfo.EntityCount--;
		if (bulletDataCacheInfo.EntityCount == 0)
		{
			this.BulletDataCacheMap.Remove(num);
		}
	}

	// Token: 0x060178CD RID: 96461 RVA: 0x0068CB6C File Offset: 0x0068AD6C
	public void ClearBulletDataCache()
	{
		this.BulletDataCacheMap.Clear();
		this.CommonBulletDataCache = null;
		this.EntityMap.Clear();
	}

	// Token: 0x060178CE RID: 96462 RVA: 0x0068CB8B File Offset: 0x0068AD8B
	private static bool IsPerformance(int modelId, string bulletDataName)
	{
		return modelId == 391336 && BulletConfig.PerformanceBulletId.Contains(bulletDataName);
	}

	// Token: 0x060178CF RID: 96463 RVA: 0x0068CBA4 File Offset: 0x0068ADA4
	[return: Nullable(2)]
	public unsafe BulletDataMain GetBulletData(Entity owner, string bulletDataName, bool errorEnable = true)
	{
		BaseSkillComponent component = owner.GetComponent<BaseSkillComponent>();
		int id = owner.Id;
		bool flag = true;
		int modelId;
		if (!this.EntityMap.TryGetValue(id, out modelId))
		{
			modelId = owner.CheckGetComponent<CreatureDataComponent>().GetModelId();
			flag = false;
		}
		BulletDataCacheInfo bulletDataCacheInfo = null;
		BulletDataMain result;
		if (this.BulletDataCacheMap.TryGetValue(modelId, out bulletDataCacheInfo) && bulletDataCacheInfo.BulletDataMap.TryGetValue(bulletDataName, out result))
		{
			if (!flag)
			{
				this.EntityMap[id] = modelId;
				bulletDataCacheInfo.EntityCount++;
			}
			return result;
		}
		BulletDataMain bulletDataMain = this.GetCacheCommonBulletData(bulletDataName);
		if (bulletDataMain != null)
		{
			return bulletDataMain;
		}
		UDataTable[] array = null;
		UDataTable udataTable;
		if (bulletDataCacheInfo == null)
		{
			FightDataTableSnapshot fightDataTableSnapshot = (component != null) ? component.GetFightDataTableSnapshot(EFightDataTableKind.Bullet) : null;
			udataTable = ((fightDataTableSnapshot != null) ? fightDataTableSnapshot.SelfTable : null);
			if (((fightDataTableSnapshot != null) ? fightDataTableSnapshot.ExtraTables : null) != null && fightDataTableSnapshot.ExtraTables.Count > 0)
			{
				array = new UDataTable[fightDataTableSnapshot.ExtraTables.Count];
				for (int i = 0; i < fightDataTableSnapshot.ExtraTables.Count; i++)
				{
					array[i] = fightDataTableSnapshot.ExtraTables[i];
				}
			}
		}
		else
		{
			udataTable = bulletDataCacheInfo.DataTable;
			array = bulletDataCacheInfo.DataTableExtraList;
		}
		SReBulletDataMain sreBulletDataMain = null;
		if (array != null)
		{
			UDataTable[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				sreBulletDataMain = DataTableUtil.GetDataTableRow<SReBulletDataMain>(array2[j], bulletDataName);
				if (sreBulletDataMain != null)
				{
					break;
				}
			}
		}
		if (sreBulletDataMain == null)
		{
			sreBulletDataMain = DataTableUtil.GetDataTableRow<SReBulletDataMain>(udataTable, bulletDataName);
		}
		if (sreBulletDataMain != null)
		{
			bulletDataMain = new BulletDataMain(sreBulletDataMain, bulletDataName, BulletConfig.IsPerformance(modelId, bulletDataName));
			if (!bulletDataMain.CheckValid())
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Bullet;
				Entity entity = null;
				string message = "子弹配置非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", bulletDataName);
				instance.Error(flag2, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			if (GlobalData.IsPlayInEditor)
			{
				return bulletDataMain;
			}
			if (bulletDataCacheInfo == null)
			{
				bulletDataCacheInfo = new BulletDataCacheInfo();
				bulletDataCacheInfo.DataTable = udataTable;
				bulletDataCacheInfo.DataTableExtraList = array;
				bulletDataCacheInfo.EntityCount = 0;
				this.BulletDataCacheMap[modelId] = bulletDataCacheInfo;
			}
			bulletDataCacheInfo.BulletDataMap[bulletDataName] = bulletDataMain;
			if (!flag)
			{
				this.EntityMap[id] = modelId;
				bulletDataCacheInfo.EntityCount++;
			}
			return bulletDataMain;
		}
		else
		{
			bulletDataMain = this.AddCacheCommonBulletData(bulletDataName, modelId);
			if (bulletDataMain != null)
			{
				return bulletDataMain;
			}
			if (errorEnable)
			{
				BaseActorComponent baseActorComponent = owner.CheckGetComponent<BaseActorComponent>();
				AActor aactor = (baseActorComponent != null) ? baseActorComponent.Owner : null;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.CFT;
				string message2 = "子弹数据未找到!";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("角色:", (aactor != null) ? aactor.GetName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("子弹名称:", bulletDataName);
				instance2.Error(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return null;
		}
	}

	// Token: 0x060178D0 RID: 96464 RVA: 0x0068CE64 File Offset: 0x0068B064
	[return: Nullable(2)]
	private BulletDataMain GetCacheCommonBulletData(string bulletDataName)
	{
		BulletDataCacheInfo commonBulletDataCache = this.CommonBulletDataCache;
		BulletDataMain result;
		if (commonBulletDataCache != null && commonBulletDataCache.BulletDataMap.TryGetValue(bulletDataName, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060178D1 RID: 96465 RVA: 0x0068CE90 File Offset: 0x0068B090
	[return: Nullable(2)]
	private BulletDataMain AddCacheCommonBulletData(string bulletDataName, int modelId)
	{
		BulletDataCacheInfo commonBulletDataCache = this.CommonBulletDataCache;
		if (commonBulletDataCache == null)
		{
			return null;
		}
		SReBulletDataMain dataTableRow = DataTableUtil.GetDataTableRow<SReBulletDataMain>(commonBulletDataCache.DataTable, bulletDataName);
		if (!(dataTableRow != null))
		{
			return null;
		}
		BulletDataMain bulletDataMain = new BulletDataMain(dataTableRow, bulletDataName, BulletConfig.IsPerformance(modelId, bulletDataName));
		if (!bulletDataMain.CheckValid())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Bullet;
			Entity entity = null;
			string message = "子弹配置非法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", bulletDataName);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (GlobalData.IsPlayInEditor)
		{
			return bulletDataMain;
		}
		commonBulletDataCache.BulletDataMap[bulletDataName] = bulletDataMain;
		return bulletDataMain;
	}

	// Token: 0x060178D2 RID: 96466 RVA: 0x0068CF18 File Offset: 0x0068B118
	[NullableContext(2)]
	public SHitEffect GetBulletHitData(Entity owner, FName dataName)
	{
		if (FNameUtil.IsNothing(dataName))
		{
			return null;
		}
		FName fname = dataName;
		BaseSkillComponent component = owner.GetComponent<BaseSkillComponent>();
		string rowName = fname.ToString();
		SHitEffect shitEffect = null;
		if (component != null)
		{
			shitEffect = component.GetHitEffectInfo(rowName);
		}
		if (shitEffect == null)
		{
			shitEffect = DataTableUtil.GetDataTableRow<SHitEffect>(ConfigBase<WorldConfig>.Instance.GetCommonHitEffectData(), rowName);
		}
		return shitEffect;
	}

	// Token: 0x060178D3 RID: 96467 RVA: 0x0068CF70 File Offset: 0x0068B170
	public bool PreloadCommonBulletData()
	{
		this.LoadCommonBulletDataTable();
		BulletDataCacheInfo commonBulletDataCache = this.CommonBulletDataCache;
		if (commonBulletDataCache != null)
		{
			foreach (string text in this.preloadCommonBulletRowNames)
			{
				SReBulletDataMain dataTableRow = DataTableUtil.GetDataTableRow<SReBulletDataMain>(commonBulletDataCache.DataTable, text);
				if (dataTableRow != null)
				{
					BulletDataMain bulletDataMain = new BulletDataMain(dataTableRow, text, false);
					if (bulletDataMain.CheckValid())
					{
						commonBulletDataCache.BulletDataMap[text] = bulletDataMain;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x060178D4 RID: 96468 RVA: 0x0068CFE4 File Offset: 0x0068B1E4
	private void LoadCommonBulletDataTable()
	{
		if (this.CommonBulletDataCache != null)
		{
			return;
		}
		UDataTable commonBulletData = ConfigBase<WorldConfig>.Instance.GetCommonBulletData();
		if (commonBulletData != null)
		{
			this.CommonBulletDataCache = new BulletDataCacheInfo
			{
				DataTable = commonBulletData
			};
			Singleton<Log>.Instance.Info(ELogModule.Bullet, ELogAuthor.CFT, "预加载通用子弹DT", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x060178D5 RID: 96469 RVA: 0x0068D038 File Offset: 0x0068B238
	public void PreloadBulletData(Entity owner)
	{
		bool flag;
		if (owner == null)
		{
			flag = true;
		}
		else
		{
			CreatureDataComponent component = owner.GetComponent<CreatureDataComponent>();
			flag = !((component != null) ? new bool?(component.IsRole()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		BaseSkillComponent baseSkillComponent = owner.CheckGetComponent<BaseSkillComponent>();
		int modelId = owner.CheckGetComponent<CreatureDataComponent>().GetModelId();
		FightDataTableSnapshot fightDataTableSnapshot = baseSkillComponent.GetFightDataTableSnapshot(EFightDataTableKind.Bullet);
		this.CacheBulletDataTable(fightDataTableSnapshot.SelfTable, (fightDataTableSnapshot.ExtraTables == null) ? null : new List<UDataTable>(fightDataTableSnapshot.ExtraTables), modelId, owner.Id, null);
	}

	// Token: 0x060178D6 RID: 96470 RVA: 0x0068D0BC File Offset: 0x0068B2BC
	[NullableContext(2)]
	private void CacheBulletDataTable(UDataTable table, [Nullable(new byte[]
	{
		2,
		1
	})] List<UDataTable> tableExtraList, int modelId, int entityId, [Nullable(new byte[]
	{
		2,
		1
	})] string[] customRowNames = null)
	{
		if (GlobalData.IsPlayInEditor)
		{
			return;
		}
		if (table == null)
		{
			return;
		}
		if (this.BulletDataCacheMap.ContainsKey(modelId))
		{
			return;
		}
		string[] array = customRowNames;
		if (array == null)
		{
			array = new string[0];
			List<string> list = new List<string>();
			DataTableUtil.GetDataTableAllRowNamesFromTable(table, list);
			array = list.ToArray();
		}
		BulletDataCacheInfo bulletDataCacheInfo = new BulletDataCacheInfo();
		bulletDataCacheInfo.DataTable = table;
		if (tableExtraList != null)
		{
			bulletDataCacheInfo.DataTableExtraList = new UDataTable[tableExtraList.Count];
			for (int i = 0; i < tableExtraList.Count; i++)
			{
				bulletDataCacheInfo.DataTableExtraList[i] = tableExtraList[i];
			}
		}
		if (ModelBase<CharacterModel>.Instance.IsValid(entityId))
		{
			bulletDataCacheInfo.EntityCount = 1;
			this.EntityMap[entityId] = modelId;
		}
		this.BulletDataCacheMap[modelId] = bulletDataCacheInfo;
		PreloadBulletConfig preloadBulletConfig = new PreloadBulletConfig();
		preloadBulletConfig.ModelId = modelId;
		preloadBulletConfig.DataTable = table;
		preloadBulletConfig.CurIndex = 0;
		preloadBulletConfig.RowNames = array;
		if (this.CurPreloadBulletConfig != null)
		{
			this.PreloadBulletConfigs.Add(preloadBulletConfig);
			return;
		}
		this.CurPreloadBulletConfig = preloadBulletConfig;
	}

	// Token: 0x060178D7 RID: 96471 RVA: 0x0068D1BC File Offset: 0x0068B3BC
	public unsafe void TickPreload()
	{
		if (this.CurPreloadBulletConfig == null)
		{
			return;
		}
		if (this.CurPreloadBulletConfig.RowNames.Length <= this.CurPreloadBulletConfig.CurIndex)
		{
			if (this.PreloadBulletConfigs.Count == 0)
			{
				this.CurPreloadBulletConfig = null;
				return;
			}
			this.CurPreloadBulletConfig = this.PreloadBulletConfigs[this.PreloadBulletConfigs.Count - 1];
			this.PreloadBulletConfigs.RemoveAt(this.PreloadBulletConfigs.Count - 1);
			if (this.CurPreloadBulletConfig.RowNames.Length <= this.CurPreloadBulletConfig.CurIndex)
			{
				return;
			}
		}
		BulletDataCacheInfo bulletDataCacheInfo;
		if (!this.BulletDataCacheMap.TryGetValue(this.CurPreloadBulletConfig.ModelId, out bulletDataCacheInfo))
		{
			this.CurPreloadBulletConfig.CurIndex = this.CurPreloadBulletConfig.RowNames.Length;
			return;
		}
		string text = this.CurPreloadBulletConfig.RowNames[this.CurPreloadBulletConfig.CurIndex];
		SReBulletDataMain dataTableRow = DataTableUtil.GetDataTableRow<SReBulletDataMain>(this.CurPreloadBulletConfig.DataTable, text);
		if (dataTableRow == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "子弹配置为空";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("rowName", text);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "modelId";
			PreloadBulletConfig curPreloadBulletConfig = this.CurPreloadBulletConfig;
			ptr = new ValueTuple<string, object>(item, (curPreloadBulletConfig != null) ? new int?(curPreloadBulletConfig.ModelId) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item2 = "index";
			PreloadBulletConfig curPreloadBulletConfig2 = this.CurPreloadBulletConfig;
			ptr2 = new ValueTuple<string, object>(item2, (curPreloadBulletConfig2 != null) ? new int?(curPreloadBulletConfig2.CurIndex) : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.CurPreloadBulletConfig.CurIndex++;
			return;
		}
		BulletDataMain bulletDataMain = new BulletDataMain(dataTableRow, text, BulletConfig.IsPerformance(this.CurPreloadBulletConfig.ModelId, text));
		if (!bulletDataMain.CheckValid())
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Bullet;
			Entity entity = null;
			string message2 = "子弹配置非法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("", text);
			instance2.Error(flag, entity, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CurPreloadBulletConfig.CurIndex++;
			return;
		}
		bulletDataMain.Preload();
		bulletDataCacheInfo.BulletDataMap[text] = bulletDataMain;
		this.CurPreloadBulletConfig.CurIndex++;
	}

	// Token: 0x060178D8 RID: 96472 RVA: 0x0068D403 File Offset: 0x0068B603
	public void ClearPreload()
	{
		this.CurPreloadBulletConfig = null;
		this.PreloadBulletConfigs.Clear();
	}

	// Token: 0x0400B494 RID: 46228
	private const int PerformanceModelId = 391336;

	// Token: 0x0400B495 RID: 46229
	[StaticVariableRuleIgnore]
	private static IReadOnlySet<string> PerformanceBulletId = new HashSet<string>
	{
		"80037001002",
		"80037103005",
		"80037103006",
		"80037103007",
		"80037103008",
		"80037103009",
		"80037103010",
		"80037103011",
		"80037103012",
		"80037103013",
		"80037103014",
		"80037103015",
		"80037103016",
		"80037103017",
		"80037103018",
		"80037103019",
		"80037103020",
		"80037103021",
		"80037103022",
		"80037103023",
		"80037103024",
		"80037103025",
		"80037103026",
		"80037103027",
		"80037103028",
		"80037103029",
		"80037103030",
		"80037103031",
		"80037103032",
		"80037103033",
		"80037103034",
		"80037103035",
		"80037103036",
		"80037103037",
		"80037103038",
		"80037103039",
		"80037103040",
		"80037103041",
		"80037103042",
		"80037103043",
		"80037103044",
		"80037001001",
		"80037001103"
	};

	// Token: 0x0400B496 RID: 46230
	private readonly string[] preloadCommonBulletRowNames = new string[]
	{
		"100121",
		"100122"
	};

	// Token: 0x0400B497 RID: 46231
	private readonly Stat PreloadStat = Stat.Create("BulletConfigPreload", "", "");

	// Token: 0x0400B498 RID: 46232
	private readonly Stat TickPreloadStat = Stat.Create("BulletConfigTickPreload", "", "");

	// Token: 0x0400B499 RID: 46233
	private readonly Dictionary<int, BulletDataCacheInfo> BulletDataCacheMap = new Dictionary<int, BulletDataCacheInfo>();

	// Token: 0x0400B49A RID: 46234
	[Nullable(2)]
	private BulletDataCacheInfo CommonBulletDataCache;

	// Token: 0x0400B49B RID: 46235
	private readonly Dictionary<int, int> EntityMap = new Dictionary<int, int>();

	// Token: 0x0400B49C RID: 46236
	private readonly List<PreloadBulletConfig> PreloadBulletConfigs = new List<PreloadBulletConfig>();

	// Token: 0x0400B49D RID: 46237
	[Nullable(2)]
	private PreloadBulletConfig CurPreloadBulletConfig;
}
