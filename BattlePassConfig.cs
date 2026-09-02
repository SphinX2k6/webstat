using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002375 RID: 9077
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BattlePassConfig : ConfigBase<BattlePassConfig>
{
	// Token: 0x060115F4 RID: 71156 RVA: 0x004C92E8 File Offset: 0x004C74E8
	public IReadOnlyList<BattlePassReward> GetAllRewardData(int battlePassId)
	{
		return ConfigBattlePassRewardByBattlePassId.GetConfigList(battlePassId, true);
	}

	// Token: 0x060115F5 RID: 71157 RVA: 0x004C92F4 File Offset: 0x004C74F4
	public BattlePass? GetBattlePassData(int battlePassId)
	{
		BattlePass? config = ConfigBattlePassById.GetConfig(battlePassId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "获取战令配置错误，BattlePass表格里没有这个id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("battlePassId", battlePassId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new BattlePass?(config.Value);
	}

	// Token: 0x060115F6 RID: 71158 RVA: 0x004C9354 File Offset: 0x004C7554
	public BattlePassTask? GetBattlePassTask(int taskId)
	{
		BattlePassTask? config = ConfigBattlePassTaskByTaskId.GetConfig(taskId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "获取战令配置错误，BattlePassTask表格里没有这个id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", taskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060115F7 RID: 71159 RVA: 0x004C93A8 File Offset: 0x004C75A8
	public BattlePassUnlockPop? GetBattlePassUnlock(int typeId)
	{
		BattlePassUnlockPop? config = ConfigBattlePassUnlockPopByBattlePassTypeId.GetConfig(typeId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.JT;
			string message = "获取战令配置错误，BattlePassTask表格里没有这个id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("taskId", typeId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060115F8 RID: 71160 RVA: 0x004C93FC File Offset: 0x004C75FC
	public void GetBattlePassUnlockReward(EBattlePassUnlockType type, List<TItem> outList)
	{
		outList.Clear();
		BattlePassUnlockPop? config = ConfigBattlePassUnlockPopByBattlePassTypeId.GetConfig((int)type, true);
		if (config != null)
		{
			using (Dictionary<int, int>.Enumerator enumerator = config.Value.UnlockReward().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
					outList.Add(item);
				}
				return;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Temp;
		ELogAuthor author = ELogAuthor.JT;
		string message = "BattlePassUnlockPop里没有该type";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}
}
