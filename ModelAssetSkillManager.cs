using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using UnrealEngine;

// Token: 0x020032B8 RID: 12984
[NullableContext(1)]
[Nullable(0)]
public class ModelAssetSkillManager : IStaticVariableResetter
{
	// Token: 0x0601B376 RID: 111478 RVA: 0x0082D972 File Offset: 0x0082BB72
	static ModelAssetSkillManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ModelAssetSkillManager.CreateStaticDefaultValue), new Action(ModelAssetSkillManager.ResetStaticDefaultValue));
	}

	// Token: 0x0601B377 RID: 111479 RVA: 0x0082D991 File Offset: 0x0082BB91
	public ModelAssetSkillManager(ModelAssetElement modelAssetElement)
	{
		this.ModelAssetElement = modelAssetElement;
	}

	// Token: 0x0601B378 RID: 111480 RVA: 0x0082D9AC File Offset: 0x0082BBAC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public OneOf<PreloadSkillSaveData, EntitySkillPreload>? GetEntitySkillPreload(int skillId)
	{
		if (this.SkillPreloadMap == null)
		{
			this.SkillPreloadMap = new Dictionary<int, OneOf<PreloadSkillSaveData, EntitySkillPreload>>();
			string blueprintClassPath = this.ModelAssetElement.BlueprintClassPath;
			if (!string.IsNullOrEmpty(blueprintClassPath))
			{
				OneOf<List<PreloadSkillSaveData>, IReadOnlyList<EntitySkillPreload>>? skillPreloadData = ModelBase<PreloadModelNew>.Instance.GetSkillPreloadData(blueprintClassPath);
				if (skillPreloadData != null)
				{
					if (skillPreloadData.Value.IsT1)
					{
						using (List<PreloadSkillSaveData>.Enumerator enumerator = skillPreloadData.Value.AsT1.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								PreloadSkillSaveData preloadSkillSaveData = enumerator.Current;
								this.SkillPreloadMap[preloadSkillSaveData.SkillId] = preloadSkillSaveData;
							}
							goto IL_10A;
						}
					}
					if (skillPreloadData.Value.IsT2)
					{
						foreach (EntitySkillPreload value in skillPreloadData.Value.AsT2)
						{
							this.SkillPreloadMap[value.SkillId] = value;
						}
					}
				}
			}
		}
		IL_10A:
		return this.SkillPreloadMap.GetValueOrNull(skillId);
	}

	// Token: 0x17002515 RID: 9493
	// (get) Token: 0x0601B379 RID: 111481 RVA: 0x0082DAEC File Offset: 0x0082BCEC
	private static Stat AddSkillStat1
	{
		get
		{
			return ModelAssetSkillManager._addSkillStat1;
		}
	}

	// Token: 0x0601B37A RID: 111482 RVA: 0x0082DAF4 File Offset: 0x0082BCF4
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
			if (this.ModelAssetElement.IsDestroy)
			{
				return;
			}
			this.HoldAssetObject.AddEntityAsset(skillId, @object);
		};
		return true;
	}

	// Token: 0x0601B37B RID: 111483 RVA: 0x0082DB9B File Offset: 0x0082BD9B
	public void Clear()
	{
		Dictionary<int, OneOf<PreloadSkillSaveData, EntitySkillPreload>> skillPreloadMap = this.SkillPreloadMap;
		if (skillPreloadMap != null)
		{
			skillPreloadMap.Clear();
		}
		this.SkillAssetMap.Clear();
		UHoldPreloadObject holdAssetObject = this.HoldAssetObject;
		if (holdAssetObject == null)
		{
			return;
		}
		holdAssetObject.Clear();
	}

	// Token: 0x0601B37C RID: 111484 RVA: 0x0082DBC9 File Offset: 0x0082BDC9
	public static void CreateStaticDefaultValue()
	{
		ModelAssetSkillManager._addSkillStat1 = Stat.Create("Preload.AddSkill.NewObject", "", "");
	}

	// Token: 0x0601B37D RID: 111485 RVA: 0x0082DBE4 File Offset: 0x0082BDE4
	public static void ResetStaticDefaultValue()
	{
		ModelAssetSkillManager._addSkillStat1 = null;
	}

	// Token: 0x0400DDD1 RID: 56785
	public readonly ModelAssetElement ModelAssetElement;

	// Token: 0x0400DDD2 RID: 56786
	[Nullable(new byte[]
	{
		2,
		0,
		1
	})]
	private Dictionary<int, OneOf<PreloadSkillSaveData, EntitySkillPreload>> SkillPreloadMap;

	// Token: 0x0400DDD3 RID: 56787
	public Dictionary<int, AssetElement> SkillAssetMap = new Dictionary<int, AssetElement>();

	// Token: 0x0400DDD4 RID: 56788
	[Nullable(2)]
	private UHoldPreloadObject HoldAssetObject;

	// Token: 0x0400DDD5 RID: 56789
	[Nullable(2)]
	private static Stat _addSkillStat1;
}
