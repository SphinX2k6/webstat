using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020032B2 RID: 12978
public class CommonAssetElement : AssetElement
{
	// Token: 0x0601B349 RID: 111433 RVA: 0x0082CC27 File Offset: 0x0082AE27
	[NullableContext(2)]
	public CommonAssetElement(EntityAssetElement entityAssetElement) : base(entityAssetElement)
	{
	}

	// Token: 0x0601B34A RID: 111434 RVA: 0x0082CC30 File Offset: 0x0082AE30
	[NullableContext(1)]
	public override bool AddObject(string path, UObject @object)
	{
		if (!base.AddObject(path, @object))
		{
			return false;
		}
		this.AssetForIndexMap[path] = ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.CommonAssets.Num();
		ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.AddCommonAsset(@object);
		return true;
	}

	// Token: 0x0601B34B RID: 111435 RVA: 0x0082CC70 File Offset: 0x0082AE70
	public override void PrintDebugInfo()
	{
		TArray<UObject> commonAssets = ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.CommonAssets;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
		defaultInterpolatedStringHandler.AppendLiteral("\n预加载的公共资源列表如下(数量:");
		defaultInterpolatedStringHandler.AppendFormatted<int>(commonAssets.Num());
		defaultInterpolatedStringHandler.AppendLiteral("):\n");
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (KeyValuePair<string, int> keyValuePair in this.AssetForIndexMap)
		{
			dictionary[keyValuePair.Value] = keyValuePair.Key;
		}
		for (int i = 0; i < commonAssets.Num(); i++)
		{
			UObject uobject = commonAssets.Get(i);
			string valueOrDefault = dictionary.GetValueOrDefault(i);
			string str = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 4);
			defaultInterpolatedStringHandler.AppendLiteral("    索引:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(i);
			defaultInterpolatedStringHandler.AppendLiteral(", Path:");
			defaultInterpolatedStringHandler.AppendFormatted(valueOrDefault);
			defaultInterpolatedStringHandler.AppendLiteral(", IsValid:");
			defaultInterpolatedStringHandler.AppendFormatted<bool?>((uobject != null) ? new bool?(uobject.IsValid()) : null);
			defaultInterpolatedStringHandler.AppendLiteral(", Name:");
			defaultInterpolatedStringHandler.AppendFormatted((uobject != null && uobject.IsValid()) ? uobject.GetName() : null);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			text = str + defaultInterpolatedStringHandler.ToStringAndClear();
		}
	}

	// Token: 0x0601B34C RID: 111436 RVA: 0x0082CDF8 File Offset: 0x0082AFF8
	public override void Clear()
	{
		ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.ClearCommonAsset();
		base.Clear();
	}
}
