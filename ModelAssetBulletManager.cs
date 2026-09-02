using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020032B9 RID: 12985
[NullableContext(1)]
[Nullable(0)]
public class ModelAssetBulletManager : IStaticVariableResetter
{
	// Token: 0x0601B37E RID: 111486 RVA: 0x0082DBEC File Offset: 0x0082BDEC
	static ModelAssetBulletManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ModelAssetBulletManager.CreateStaticDefaultValue), new Action(ModelAssetBulletManager.ResetStaticDefaultValue));
	}

	// Token: 0x0601B37F RID: 111487 RVA: 0x0082DC0B File Offset: 0x0082BE0B
	public ModelAssetBulletManager(ModelAssetElement modelAssetElement)
	{
		this.ModelAssetElement = modelAssetElement;
	}

	// Token: 0x17002516 RID: 9494
	// (get) Token: 0x0601B380 RID: 111488 RVA: 0x0082DC42 File Offset: 0x0082BE42
	private static Stat AddAssetStat1
	{
		get
		{
			return ModelAssetBulletManager._addAssetStat1;
		}
	}

	// Token: 0x0601B381 RID: 111489 RVA: 0x0082DC4C File Offset: 0x0082BE4C
	public bool AddAsset(long id, AssetElement assetElement)
	{
		ModelAssetBulletManager.<>c__DisplayClass11_0 CS$<>8__locals1 = new ModelAssetBulletManager.<>c__DisplayClass11_0();
		CS$<>8__locals1.<>4__this = this;
		if (this.HoldAssetObject == null)
		{
			this.HoldAssetObject = new UHoldPreloadObject(GlobalData.GameInstance, null, EObjectFlags.RF_NoFlags);
		}
		if (this.ValueMapping.ContainsKey(id))
		{
			return false;
		}
		if (assetElement == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[预加载] assetElement无效，添加失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		ModelAssetBulletManager.<>c__DisplayClass11_0 CS$<>8__locals2 = CS$<>8__locals1;
		int num = this.Key + 1;
		this.Key = num;
		CS$<>8__locals2.newKey = num;
		this.ValueMapping[id] = CS$<>8__locals1.newKey;
		this.IndexMapping[CS$<>8__locals1.newKey] = id;
		this.AssetMap[CS$<>8__locals1.newKey] = assetElement;
		assetElement.AddObjectCallback = delegate(UObject @object, string path)
		{
			if (CS$<>8__locals1.<>4__this.ModelAssetElement.IsDestroy)
			{
				return;
			}
			CS$<>8__locals1.<>4__this.HoldAssetObject.AddEntityAsset(CS$<>8__locals1.newKey, @object);
		};
		return true;
	}

	// Token: 0x0601B382 RID: 111490 RVA: 0x0082DD20 File Offset: 0x0082BF20
	public void Clear()
	{
		this.Key = -1;
		this.ValueMapping.Clear();
		this.IndexMapping.Clear();
		this.AssetMap.Clear();
		UHoldPreloadObject holdAssetObject = this.HoldAssetObject;
		if (holdAssetObject == null)
		{
			return;
		}
		holdAssetObject.Clear();
	}

	// Token: 0x0601B383 RID: 111491 RVA: 0x0082DD5A File Offset: 0x0082BF5A
	public static void CreateStaticDefaultValue()
	{
		ModelAssetBulletManager._addAssetStat1 = Stat.Create("Preload.AddStat1.NewObject", "", "");
	}

	// Token: 0x0601B384 RID: 111492 RVA: 0x0082DD75 File Offset: 0x0082BF75
	public static void ResetStaticDefaultValue()
	{
		ModelAssetBulletManager._addAssetStat1 = null;
	}

	// Token: 0x0400DDD6 RID: 56790
	public readonly ModelAssetElement ModelAssetElement;

	// Token: 0x0400DDD7 RID: 56791
	public Dictionary<long, int> ValueMapping = new Dictionary<long, int>();

	// Token: 0x0400DDD8 RID: 56792
	public Dictionary<int, long> IndexMapping = new Dictionary<int, long>();

	// Token: 0x0400DDD9 RID: 56793
	public Dictionary<int, AssetElement> AssetMap = new Dictionary<int, AssetElement>();

	// Token: 0x0400DDDA RID: 56794
	[Nullable(2)]
	private UHoldPreloadObject HoldAssetObject;

	// Token: 0x0400DDDB RID: 56795
	private int Key = -1;

	// Token: 0x0400DDDC RID: 56796
	[Nullable(2)]
	private static Stat _addAssetStat1;
}
