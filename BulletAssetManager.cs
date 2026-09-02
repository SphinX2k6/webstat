using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020032B4 RID: 12980
[NullableContext(1)]
[Nullable(0)]
public class BulletAssetManager
{
	// Token: 0x0601B35A RID: 111450 RVA: 0x0082D397 File Offset: 0x0082B597
	public BulletAssetManager(FightAssetManager fightAssetManager)
	{
		this.FightAssetManager = fightAssetManager;
	}

	// Token: 0x0601B35B RID: 111451 RVA: 0x0082D3D0 File Offset: 0x0082B5D0
	[NullableContext(2)]
	public bool AddBullet(long bulletId, AssetElement assetElement)
	{
		BulletAssetManager.<>c__DisplayClass7_0 CS$<>8__locals1 = new BulletAssetManager.<>c__DisplayClass7_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.HoldAssetObject == null)
		{
			this.HoldAssetObject = new UHoldPreloadObject(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
		}
		if (this.BulletMapping.ContainsKey(bulletId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[预加载] 重复添加子弹";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BulletId", bulletId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (assetElement == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.World;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[预加载] assetElement无效，添加子弹失败";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("bulletId", bulletId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		BulletAssetManager.<>c__DisplayClass7_0 CS$<>8__locals2 = CS$<>8__locals1;
		int num = this.Key + 1;
		this.Key = num;
		CS$<>8__locals2.newKey = num;
		this.BulletMapping[bulletId] = CS$<>8__locals1.newKey;
		this.IndexMapping[CS$<>8__locals1.newKey] = bulletId;
		this.BulletAssetMap[CS$<>8__locals1.newKey] = assetElement;
		assetElement.AddObjectCallback = delegate(UObject @object, string path)
		{
			ELoadResultType eloadResultType = ELoadResultType.None;
			if (CS$<>8__locals1.<>4__this.FightAssetManager.EntityAssetElement.IsT1)
			{
				eloadResultType = CS$<>8__locals1.<>4__this.FightAssetManager.EntityAssetElement.AsT1.LoadState;
			}
			else if (CS$<>8__locals1.<>4__this.FightAssetManager.EntityAssetElement.IsT2)
			{
				eloadResultType = CS$<>8__locals1.<>4__this.FightAssetManager.EntityAssetElement.AsT2.LoadState;
			}
			if (eloadResultType == ELoadResultType.Destroy)
			{
				return;
			}
			CS$<>8__locals1.<>4__this.HoldAssetObject.AddEntityAsset(CS$<>8__locals1.newKey, @object);
		};
		return true;
	}

	// Token: 0x0601B35C RID: 111452 RVA: 0x0082D4D0 File Offset: 0x0082B6D0
	[NullableContext(2)]
	public AssetElement GetBullet(long bulletId)
	{
		int key;
		if (!this.BulletMapping.TryGetValue(bulletId, out key))
		{
			return null;
		}
		return this.BulletAssetMap.GetValueOrDefault(key);
	}

	// Token: 0x0601B35D RID: 111453 RVA: 0x0082D4FC File Offset: 0x0082B6FC
	public bool RemoveBullet(long bulletId)
	{
		int num;
		if (!this.BulletMapping.TryGetValue(bulletId, out num))
		{
			return false;
		}
		AssetElement assetElement;
		if (this.BulletAssetMap.TryGetValue(num, out assetElement))
		{
			assetElement.SetPromiseResult(ELoadResultType.Destroy);
		}
		this.IndexMapping.Remove(num);
		this.BulletMapping.Remove(bulletId);
		this.BulletAssetMap.Remove(num);
		UHoldPreloadObject holdAssetObject = this.HoldAssetObject;
		if (holdAssetObject != null)
		{
			holdAssetObject.RemoveEntityAssets(num);
		}
		return true;
	}

	// Token: 0x0601B35E RID: 111454 RVA: 0x0082D574 File Offset: 0x0082B774
	public void Clear()
	{
		foreach (KeyValuePair<int, AssetElement> keyValuePair in this.BulletAssetMap)
		{
			keyValuePair.Value.SetPromiseResult(ELoadResultType.Destroy);
		}
		this.Key = -1;
		this.BulletMapping.Clear();
		this.IndexMapping.Clear();
		this.BulletAssetMap.Clear();
		UHoldPreloadObject holdAssetObject = this.HoldAssetObject;
		if (holdAssetObject == null)
		{
			return;
		}
		holdAssetObject.Clear();
	}

	// Token: 0x0400DDB7 RID: 56759
	public readonly FightAssetManager FightAssetManager;

	// Token: 0x0400DDB8 RID: 56760
	public Dictionary<long, int> BulletMapping = new Dictionary<long, int>();

	// Token: 0x0400DDB9 RID: 56761
	public Dictionary<int, long> IndexMapping = new Dictionary<int, long>();

	// Token: 0x0400DDBA RID: 56762
	public Dictionary<int, AssetElement> BulletAssetMap = new Dictionary<int, AssetElement>();

	// Token: 0x0400DDBB RID: 56763
	[Nullable(2)]
	private UHoldPreloadObject HoldAssetObject;

	// Token: 0x0400DDBC RID: 56764
	private int Key = -1;
}
