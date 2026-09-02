using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DA4 RID: 28068
	public class LevelConditionGetNewItem : LevelConditionBase
	{
		// Token: 0x06044590 RID: 279952 RVA: 0x011C20AC File Offset: 0x011C02AC
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TL;
				string message = "配置错误！条件的参数不应该为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int num;
			if (!int.TryParse(inConditionInfo.GetLimitParams("ItemId"), out num) || num == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的ItemId参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.GetNewItem);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			InventoryModel instance3 = ModelBase<InventoryModel>.Instance;
			if (eventArgs != null && eventArgs.Length != 0)
			{
				AttributeItemData attributeItemData = instance3.GetAttributeItemData((int)eventArgs[0]);
				if (attributeItemData == null)
				{
					return (int)eventArgs[0] == num;
				}
				return num == attributeItemData.GetConfigId();
			}
			else
			{
				if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryCommonItem, num))
				{
					return true;
				}
				HashSet<int> newAttributeItemUniqueIdList = instance3.GetNewAttributeItemUniqueIdList();
				HashSet<int> hashSet = new HashSet<int>();
				foreach (int uniqueId in newAttributeItemUniqueIdList)
				{
					AttributeItemData attributeItemData2 = instance3.GetAttributeItemData(uniqueId);
					if (attributeItemData2 != null)
					{
						hashSet.Add(attributeItemData2.GetConfigId());
					}
				}
				return hashSet.Contains(num);
			}
		}
	}
}
