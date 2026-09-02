using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020023EE RID: 9198
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GiftPackageConfig : ConfigBase<GiftPackageConfig>
{
	// Token: 0x06011CD0 RID: 72912 RVA: 0x004E56EE File Offset: 0x004E38EE
	public GiftPackage? GetGiftPackageConfig(int id)
	{
		return ConfigGiftPackageById.GetConfig(id, true);
	}

	// Token: 0x06011CD1 RID: 72913 RVA: 0x004E56F8 File Offset: 0x004E38F8
	public void GetGiftItemList(int id, List<TItem> outList)
	{
		outList.Clear();
		GiftPackage? config = ConfigGiftPackageById.GetConfig(id, true);
		if (config != null)
		{
			outList.Clear();
			using (Dictionary<int, int>.Enumerator enumerator = config.Value.Content().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					int key = keyValuePair.Key;
					int value = keyValuePair.Value;
					TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
					outList.Add(item);
				}
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Temp;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "GiftPackage里没有该id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}
}
