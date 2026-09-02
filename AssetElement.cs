using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x020032B1 RID: 12977
[NullableContext(1)]
[Nullable(0)]
public class AssetElement
{
	// Token: 0x0601B32E RID: 111406 RVA: 0x0082C4A8 File Offset: 0x0082A6A8
	public Dictionary<string, string> SetupReplaceEffect(string replaceTablePath)
	{
		List<SReplaceEffect> dataTableAllRowFromTable = DataTableUtil.GetDataTableAllRowFromTable<SReplaceEffect>(Singleton<ResourceSystem>.Instance.Load<UDataTable>(replaceTablePath, "js_undefined"));
		if (dataTableAllRowFromTable.Count > 0)
		{
			foreach (SReplaceEffect sreplaceEffect in dataTableAllRowFromTable)
			{
				string text = sreplaceEffect.NewEffect.ToAssetPathName();
				if (!string.IsNullOrEmpty(text) && !(text == "None"))
				{
					string text2 = sreplaceEffect.OldEffect.ToAssetPathName();
					if (text.Contains("GA_"))
					{
						text += "_C";
						text2 += "_C";
					}
					this.ReplaceEffectMap[text2] = text;
				}
			}
		}
		return this.ReplaceEffectMap;
	}

	// Token: 0x0601B32F RID: 111407 RVA: 0x0082C57C File Offset: 0x0082A77C
	public Dictionary<string, string> SetupReplaceMontage(string replaceTablePath)
	{
		List<SReplaceMontage> dataTableAllRowFromTable = DataTableUtil.GetDataTableAllRowFromTable<SReplaceMontage>(Singleton<ResourceSystem>.Instance.Load<UDataTable>(replaceTablePath, "js_undefined"));
		if (dataTableAllRowFromTable.Count > 0)
		{
			foreach (SReplaceMontage sreplaceMontage in dataTableAllRowFromTable)
			{
				string text = sreplaceMontage.NewMontage.ToAssetPathName();
				if (!string.IsNullOrEmpty(text) && !(text == "None"))
				{
					this.ReplaceMontageMap[sreplaceMontage.OldMontage.ToAssetPathName()] = sreplaceMontage.NewMontage.ToAssetPathName();
				}
			}
		}
		return this.ReplaceMontageMap;
	}

	// Token: 0x0601B330 RID: 111408 RVA: 0x0082C62C File Offset: 0x0082A82C
	[NullableContext(2)]
	public AssetElement(EntityAssetElement entityAssetElement)
	{
		this.EntityAssetElement = entityAssetElement;
		bool flag;
		if (entityAssetElement == null)
		{
			flag = (null != null);
		}
		else
		{
			AssetElement mainAsset = entityAssetElement.MainAsset;
			flag = (((mainAsset != null) ? mainAsset.ReplaceEffectMap : null) != null);
		}
		if (flag)
		{
			this.ReplaceEffectMap = entityAssetElement.MainAsset.ReplaceEffectMap;
		}
		bool flag2;
		if (entityAssetElement == null)
		{
			flag2 = (null != null);
		}
		else
		{
			AssetElement mainAsset2 = entityAssetElement.MainAsset;
			flag2 = (((mainAsset2 != null) ? mainAsset2.ReplaceMontageMap : null) != null);
		}
		if (flag2)
		{
			this.ReplaceMontageMap = entityAssetElement.MainAsset.ReplaceMontageMap;
		}
	}

	// Token: 0x0601B331 RID: 111409 RVA: 0x0082C6FC File Offset: 0x0082A8FC
	[NullableContext(2)]
	public EntityAssetElement GetEntityAssetElement()
	{
		return this.EntityAssetElement;
	}

	// Token: 0x0601B332 RID: 111410 RVA: 0x0082C704 File Offset: 0x0082A904
	[NullableContext(2)]
	public void AddPromise(object promise)
	{
		if (promise == null)
		{
			return;
		}
		if (this.PromiseSet == null)
		{
			this.PromiseSet = new HashSet<object>();
		}
		this.PromiseSet.Add(promise);
	}

	// Token: 0x0601B333 RID: 111411 RVA: 0x0082C72C File Offset: 0x0082A92C
	public void SetPromiseResult(object result)
	{
		if (this.PromiseSet == null)
		{
			return;
		}
		HashSet<object> promiseSet = this.PromiseSet;
		this.PromiseSet = null;
		if (result is bool)
		{
			bool flag = (bool)result;
			using (HashSet<object>.Enumerator enumerator = promiseSet.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					GameModePromise gameModePromise = obj as GameModePromise;
					if (gameModePromise != null)
					{
						gameModePromise.SetResult(flag);
					}
					else
					{
						CustomPromise<ELoadResultType> customPromise = obj as CustomPromise<ELoadResultType>;
						if (customPromise != null)
						{
							customPromise.SetResult(flag ? ELoadResultType.Done : ELoadResultType.Destroy);
						}
					}
				}
				return;
			}
		}
		if (result is ELoadResultType)
		{
			ELoadResultType eloadResultType = (ELoadResultType)result;
			foreach (object obj2 in promiseSet)
			{
				GameModePromise gameModePromise2 = obj2 as GameModePromise;
				if (gameModePromise2 != null)
				{
					gameModePromise2.SetResult(eloadResultType == ELoadResultType.Done);
				}
				else
				{
					CustomPromise<ELoadResultType> customPromise2 = obj2 as CustomPromise<ELoadResultType>;
					if (customPromise2 != null)
					{
						customPromise2.SetResult(eloadResultType);
					}
				}
			}
		}
	}

	// Token: 0x0601B334 RID: 111412 RVA: 0x0082C844 File Offset: 0x0082AA44
	[NullableContext(2)]
	public void SetCallback(Action<bool> value)
	{
		this.Callback = value;
	}

	// Token: 0x0601B335 RID: 111413 RVA: 0x0082C84D File Offset: 0x0082AA4D
	public void ExecuteCallback()
	{
		Action<bool> callback = this.Callback;
		this.Callback = null;
		if (callback == null)
		{
			return;
		}
		callback(!this.HasError);
	}

	// Token: 0x0601B336 RID: 111414 RVA: 0x0082C870 File Offset: 0x0082AA70
	protected bool CheckPath(string asset)
	{
		if (string.IsNullOrEmpty(asset))
		{
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.LFJW, "搜集资源失败，asset=undefined或asset.length=0。", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return true;
	}

	// Token: 0x0601B337 RID: 111415 RVA: 0x0082C8A3 File Offset: 0x0082AAA3
	protected bool AddPath(string asset)
	{
		if (this.AssetPathSet.Contains(asset))
		{
			return false;
		}
		this.AssetPathSet.Add(asset);
		return true;
	}

	// Token: 0x0601B338 RID: 111416 RVA: 0x0082C8C3 File Offset: 0x0082AAC3
	public virtual bool AddObject(string path, UObject @object)
	{
		if (this.LoadedSet.Contains(path))
		{
			return false;
		}
		this.LoadedSet.Add(path);
		Action<UObject, string> addObjectCallback = this.AddObjectCallback;
		if (addObjectCallback != null)
		{
			addObjectCallback(@object, path);
		}
		return true;
	}

	// Token: 0x0601B339 RID: 111417 RVA: 0x0082C8F6 File Offset: 0x0082AAF6
	public bool AddActorClass(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		if (!this.AddPath(asset))
		{
			return false;
		}
		this.NeedLoadAssets.Add(asset);
		this.NeedLoadAssetTypes.Add(EAssetType.ActorClass);
		return true;
	}

	// Token: 0x0601B33A RID: 111418 RVA: 0x0082C928 File Offset: 0x0082AB28
	public bool AddAnimation(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		string valueOrDefault = this.ReplaceMontageMap.GetValueOrDefault(asset, asset);
		if (!this.AddPath(valueOrDefault))
		{
			return false;
		}
		this.NeedLoadAssets.Add(valueOrDefault);
		this.NeedLoadAssetTypes.Add(EAssetType.Animation);
		return true;
	}

	// Token: 0x0601B33B RID: 111419 RVA: 0x0082C974 File Offset: 0x0082AB74
	public bool AddEffect(string asset)
	{
		if (GlobalData.IsPlayInEditor && (ModelBase<GameModeModel>.Instance.MapId < 3000 || ModelBase<GameModeModel>.Instance.MapId > 4000 || ModelBase<GameModeModel>.Instance.MapId == 1))
		{
			return true;
		}
		if (!this.CheckPath(asset))
		{
			return false;
		}
		string valueOrDefault = this.ReplaceEffectMap.GetValueOrDefault(asset, asset);
		if (!this.AddPath(valueOrDefault))
		{
			return false;
		}
		this.NeedLoadAssets.Add(valueOrDefault);
		this.NeedLoadAssetTypes.Add(EAssetType.Effect);
		return true;
	}

	// Token: 0x0601B33C RID: 111420 RVA: 0x0082C9F6 File Offset: 0x0082ABF6
	public bool AddAudio(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		if (!this.AddPath(asset))
		{
			return false;
		}
		this.NeedLoadAssets.Add(asset);
		this.NeedLoadAssetTypes.Add(EAssetType.Audio);
		return true;
	}

	// Token: 0x0601B33D RID: 111421 RVA: 0x0082CA27 File Offset: 0x0082AC27
	public bool AddMesh(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		if (!this.AddPath(asset))
		{
			return false;
		}
		this.NeedLoadAssets.Add(asset);
		this.NeedLoadAssetTypes.Add(EAssetType.Mesh);
		return true;
	}

	// Token: 0x0601B33E RID: 111422 RVA: 0x0082CA58 File Offset: 0x0082AC58
	public bool AddMaterial(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		if (!this.AddPath(asset))
		{
			return false;
		}
		this.NeedLoadAssets.Add(asset);
		this.NeedLoadAssetTypes.Add(EAssetType.Material);
		return true;
	}

	// Token: 0x0601B33F RID: 111423 RVA: 0x0082CA8C File Offset: 0x0082AC8C
	public bool AddOther(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		string valueOrDefault = this.ReplaceEffectMap.GetValueOrDefault(asset, asset);
		if (!this.AddPath(valueOrDefault))
		{
			return false;
		}
		this.NeedLoadAssets.Add(valueOrDefault);
		this.NeedLoadAssetTypes.Add(EAssetType.Other);
		return true;
	}

	// Token: 0x0601B340 RID: 111424 RVA: 0x0082CAD6 File Offset: 0x0082ACD6
	public bool AddAnimationBlueprint(string asset)
	{
		if (!this.CheckPath(asset))
		{
			return false;
		}
		if (!this.AddPath(asset))
		{
			return false;
		}
		this.NeedLoadAssets.Add(asset);
		this.NeedLoadAssetTypes.Add(EAssetType.AnimationBlueprint);
		return true;
	}

	// Token: 0x0601B341 RID: 111425 RVA: 0x0082CB08 File Offset: 0x0082AD08
	public bool AddAsset(EAssetType type, string asset)
	{
		switch (type)
		{
		case EAssetType.ActorClass:
			return this.AddActorClass(asset);
		case EAssetType.Animation:
			return this.AddAnimation(asset);
		case EAssetType.Effect:
			return this.AddEffect(asset);
		case EAssetType.Audio:
			return this.AddAudio(asset);
		case EAssetType.Mesh:
			return this.AddMesh(asset);
		case EAssetType.Material:
			return this.AddMaterial(asset);
		case EAssetType.AnimationBlueprint:
			return this.AddAnimationBlueprint(asset);
		case EAssetType.Other:
			return this.AddOther(asset);
		default:
			return true;
		}
	}

	// Token: 0x0601B342 RID: 111426 RVA: 0x0082CB7E File Offset: 0x0082AD7E
	public int NeedLoadCount()
	{
		return this.NeedLoadAssets.Count;
	}

	// Token: 0x0601B343 RID: 111427 RVA: 0x0082CB8B File Offset: 0x0082AD8B
	public bool AddLoading(string path)
	{
		if (this.LoadedSet.Contains(path))
		{
			return false;
		}
		if (this.LoadingSet.Contains(path))
		{
			return false;
		}
		this.LoadingSet.Add(path);
		return true;
	}

	// Token: 0x0601B344 RID: 111428 RVA: 0x0082CBBB File Offset: 0x0082ADBB
	public bool RemoveLoading(string path)
	{
		return this.LoadingSet.Remove(path);
	}

	// Token: 0x0601B345 RID: 111429 RVA: 0x0082CBC9 File Offset: 0x0082ADC9
	public bool RemoveLoaded(string path)
	{
		return this.LoadedSet.Remove(path);
	}

	// Token: 0x0601B346 RID: 111430 RVA: 0x0082CBD7 File Offset: 0x0082ADD7
	public bool Loading()
	{
		return this.NeedLoadAssets.Count > 0 || this.LoadingSet.Count > 0;
	}

	// Token: 0x0601B347 RID: 111431 RVA: 0x0082CBF7 File Offset: 0x0082ADF7
	public virtual void Clear()
	{
		this.AssetForIndexMap.Clear();
		this.AssetPathSet.Clear();
		this.LoadedSet.Clear();
		this.LoadingSet.Clear();
	}

	// Token: 0x0601B348 RID: 111432 RVA: 0x0082CC25 File Offset: 0x0082AE25
	public virtual void PrintDebugInfo()
	{
	}

	// Token: 0x0400DDA4 RID: 56740
	[Nullable(2)]
	private readonly EntityAssetElement EntityAssetElement;

	// Token: 0x0400DDA5 RID: 56741
	protected readonly Dictionary<string, int> AssetForIndexMap = new Dictionary<string, int>();

	// Token: 0x0400DDA6 RID: 56742
	public bool HasError;

	// Token: 0x0400DDA7 RID: 56743
	public readonly HashSet<string> AssetPathSet = new HashSet<string>();

	// Token: 0x0400DDA8 RID: 56744
	public readonly List<string> NeedLoadAssets = new List<string>();

	// Token: 0x0400DDA9 RID: 56745
	public readonly List<EAssetType> NeedLoadAssetTypes = new List<EAssetType>();

	// Token: 0x0400DDAA RID: 56746
	public readonly HashSet<string> LoadingSet = new HashSet<string>();

	// Token: 0x0400DDAB RID: 56747
	public readonly HashSet<string> LoadedSet = new HashSet<string>();

	// Token: 0x0400DDAC RID: 56748
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<UObject, string> AddObjectCallback;

	// Token: 0x0400DDAD RID: 56749
	public readonly ResourceSystem.EResourceLoadPriority LoadPriority = ResourceSystem.EResourceLoadPriority.Default;

	// Token: 0x0400DDAE RID: 56750
	public Dictionary<string, string> ReplaceEffectMap = new Dictionary<string, string>();

	// Token: 0x0400DDAF RID: 56751
	public Dictionary<string, string> ReplaceMontageMap = new Dictionary<string, string>();

	// Token: 0x0400DDB0 RID: 56752
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private HashSet<object> PromiseSet;

	// Token: 0x0400DDB1 RID: 56753
	[Nullable(2)]
	private Action<bool> Callback;
}
