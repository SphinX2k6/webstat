using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020032B3 RID: 12979
[NullableContext(1)]
[Nullable(0)]
public class SkillAssetManager : IStaticVariableResetter
{
	// Token: 0x0601B34D RID: 111437 RVA: 0x0082CE0F File Offset: 0x0082B00F
	static SkillAssetManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SkillAssetManager.CreateStaticDefaultValue), new Action(SkillAssetManager.ResetStaticDefaultValue));
	}

	// Token: 0x0601B34E RID: 111438 RVA: 0x0082CE2E File Offset: 0x0082B02E
	public SkillAssetManager(FightAssetManager fightAssetManager)
	{
		this.FightAssetManager = fightAssetManager;
	}

	// Token: 0x0601B34F RID: 111439 RVA: 0x0082CE48 File Offset: 0x0082B048
	[return: Nullable(new byte[]
	{
		1,
		1,
		0,
		1
	})]
	private Dictionary<int, List<OneOf<PreloadSkillSaveData, EntitySkillPreload>>> EnsureEntitySkillPreloadMap()
	{
		if (this.EntitySkillPreloadMap == null)
		{
			this.EntitySkillPreloadMap = new Dictionary<int, List<OneOf<PreloadSkillSaveData, EntitySkillPreload>>>();
			string text = null;
			if (this.FightAssetManager.EntityAssetElement.IsT1)
			{
				text = this.FightAssetManager.EntityAssetElement.AsT1.BlueprintClassPath;
			}
			else if (this.FightAssetManager.EntityAssetElement.IsT2)
			{
				text = this.FightAssetManager.EntityAssetElement.AsT2.BlueprintClassPath;
			}
			if (!string.IsNullOrEmpty(text))
			{
				OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>? skillPreloadData = ModelBase<PreloadModelNew>.Instance.GetSkillPreloadData(text);
				if (skillPreloadData != null && skillPreloadData.GetValueOrDefault().IsT1)
				{
					using (List<PreloadSkillSaveData>.Enumerator enumerator = skillPreloadData.Value.AsT1.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							PreloadSkillSaveData preloadSkillSaveData = enumerator.Current;
							this.AddEntitySkillPreloadToMap(preloadSkillSaveData.SkillId, preloadSkillSaveData);
						}
						goto IL_155;
					}
				}
				if (skillPreloadData != null && skillPreloadData.GetValueOrDefault().IsT2)
				{
					foreach (EntitySkillPreload value in skillPreloadData.Value.AsT2)
					{
						this.AddEntitySkillPreloadToMap(value.SkillId, value);
					}
				}
			}
			IL_155:
			OneOf<EntityAssetElement, PbEntityAssetElement> entityAssetElement = this.FightAssetManager.EntityAssetElement;
			if (entityAssetElement.IsT1)
			{
				EntityAssetElement asT = entityAssetElement.AsT1;
				if (asT.HasMorphAssets && asT.MorphAssetsPaths != null)
				{
					foreach (string bpPath in asT.MorphAssetsPaths)
					{
						OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>? skillPreloadData2 = ModelBase<PreloadModelNew>.Instance.GetSkillPreloadData(bpPath);
						if (skillPreloadData2 != null && skillPreloadData2.GetValueOrDefault().IsT1)
						{
							using (List<PreloadSkillSaveData>.Enumerator enumerator = skillPreloadData2.Value.AsT1.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									PreloadSkillSaveData preloadSkillSaveData2 = enumerator.Current;
									this.AddEntitySkillPreloadToMap(preloadSkillSaveData2.SkillId, preloadSkillSaveData2);
								}
								continue;
							}
						}
						if (skillPreloadData2 != null && skillPreloadData2.GetValueOrDefault().IsT2)
						{
							foreach (EntitySkillPreload value2 in skillPreloadData2.Value.AsT2)
							{
								this.AddEntitySkillPreloadToMap(value2.SkillId, value2);
							}
						}
					}
				}
			}
		}
		return this.EntitySkillPreloadMap;
	}

	// Token: 0x0601B350 RID: 111440 RVA: 0x0082D144 File Offset: 0x0082B344
	private void AddEntitySkillPreloadToMap(int skillId, [Nullable(new byte[]
	{
		0,
		1
	})] OneOf<PreloadSkillSaveData, EntitySkillPreload> value)
	{
		List<OneOf<PreloadSkillSaveData, EntitySkillPreload>> list;
		if (!this.EntitySkillPreloadMap.TryGetValue(skillId, out list))
		{
			list = new List<OneOf<PreloadSkillSaveData, EntitySkillPreload>>();
			this.EntitySkillPreloadMap[skillId] = list;
		}
		list.Add(value);
	}

	// Token: 0x0601B351 RID: 111441 RVA: 0x0082D17B File Offset: 0x0082B37B
	[return: Nullable(new byte[]
	{
		2,
		0,
		1
	})]
	public IReadOnlyList<OneOf<PreloadSkillSaveData, EntitySkillPreload>> GetEntitySkillPreloadBucket(int skillId)
	{
		return this.EnsureEntitySkillPreloadMap().GetValueOrDefault(skillId);
	}

	// Token: 0x1700250E RID: 9486
	// (get) Token: 0x0601B352 RID: 111442 RVA: 0x0082D189 File Offset: 0x0082B389
	private static Stat AddSkillStat1
	{
		get
		{
			return SkillAssetManager._addSkillStat1;
		}
	}

	// Token: 0x0601B353 RID: 111443 RVA: 0x0082D190 File Offset: 0x0082B390
	[NullableContext(2)]
	public bool AddSkill(int skillId, AssetElement assetElement)
	{
		if (this.HoldAssetObject == null)
		{
			this.HoldAssetObject = new UHoldPreloadObject(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
		}
		this.SkillAssetMap.ContainsKey(skillId);
		if (assetElement == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[预加载] assetElement无效，添加技能失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SkillId", skillId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.SkillAssetMap[skillId] = assetElement;
		assetElement.AddObjectCallback = delegate(UObject @object, string path)
		{
			ELoadResultType eloadResultType = ELoadResultType.None;
			if (this.FightAssetManager.EntityAssetElement.IsT1)
			{
				eloadResultType = this.FightAssetManager.EntityAssetElement.AsT1.LoadState;
			}
			else if (this.FightAssetManager.EntityAssetElement.IsT2)
			{
				eloadResultType = this.FightAssetManager.EntityAssetElement.AsT2.LoadState;
			}
			if (eloadResultType == ELoadResultType.Destroy)
			{
				return;
			}
			this.HoldAssetObject.AddEntityAsset(skillId, @object);
		};
		return true;
	}

	// Token: 0x0601B354 RID: 111444 RVA: 0x0082D238 File Offset: 0x0082B438
	public bool RemoveSkill(int skillId)
	{
		AssetElement assetElement;
		if (!this.SkillAssetMap.Remove(skillId, out assetElement))
		{
			return false;
		}
		assetElement.SetPromiseResult(ELoadResultType.Destroy);
		UHoldPreloadObject holdAssetObject = this.HoldAssetObject;
		if (holdAssetObject != null)
		{
			holdAssetObject.RemoveEntityAssets(skillId);
		}
		return true;
	}

	// Token: 0x0601B355 RID: 111445 RVA: 0x0082D277 File Offset: 0x0082B477
	[NullableContext(2)]
	public AssetElement GetSkill(int skillId)
	{
		return this.SkillAssetMap.GetValueOrDefault(skillId);
	}

	// Token: 0x0601B356 RID: 111446 RVA: 0x0082D288 File Offset: 0x0082B488
	public void ResetForLoadTypeChange()
	{
		Dictionary<int, List<OneOf<PreloadSkillSaveData, EntitySkillPreload>>> entitySkillPreloadMap = this.EntitySkillPreloadMap;
		if (entitySkillPreloadMap != null)
		{
			entitySkillPreloadMap.Clear();
		}
		foreach (int skillId in new List<int>(this.SkillAssetMap.Keys))
		{
			this.RemoveSkill(skillId);
		}
	}

	// Token: 0x0601B357 RID: 111447 RVA: 0x0082D2F8 File Offset: 0x0082B4F8
	public void Clear()
	{
		foreach (KeyValuePair<int, AssetElement> keyValuePair in this.SkillAssetMap)
		{
			keyValuePair.Value.SetPromiseResult(ELoadResultType.Destroy);
		}
		this.SkillAssetMap.Clear();
		UHoldPreloadObject holdAssetObject = this.HoldAssetObject;
		if (holdAssetObject == null)
		{
			return;
		}
		holdAssetObject.Clear();
	}

	// Token: 0x0601B358 RID: 111448 RVA: 0x0082D374 File Offset: 0x0082B574
	public static void CreateStaticDefaultValue()
	{
		SkillAssetManager._addSkillStat1 = Stat.Create("Preload.AddSkill.NewObject", "", "");
	}

	// Token: 0x0601B359 RID: 111449 RVA: 0x0082D38F File Offset: 0x0082B58F
	public static void ResetStaticDefaultValue()
	{
		SkillAssetManager._addSkillStat1 = null;
	}

	// Token: 0x0400DDB2 RID: 56754
	public readonly FightAssetManager FightAssetManager;

	// Token: 0x0400DDB3 RID: 56755
	[Nullable(new byte[]
	{
		2,
		1,
		0,
		1
	})]
	private Dictionary<int, List<OneOf<PreloadSkillSaveData, EntitySkillPreload>>> EntitySkillPreloadMap;

	// Token: 0x0400DDB4 RID: 56756
	public Dictionary<int, AssetElement> SkillAssetMap = new Dictionary<int, AssetElement>();

	// Token: 0x0400DDB5 RID: 56757
	[Nullable(2)]
	private UHoldPreloadObject HoldAssetObject;

	// Token: 0x0400DDB6 RID: 56758
	[Nullable(2)]
	private static Stat _addSkillStat1;
}
