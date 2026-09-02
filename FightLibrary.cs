using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.UI.Framework;
using UnrealEngine;

// Token: 0x02002E2E RID: 11822
public class FightLibrary
{
	// Token: 0x06017F72 RID: 98162 RVA: 0x006B69EC File Offset: 0x006B4BEC
	public static void Init()
	{
		TArray<SCamp> tarray = DataTableUtil_C.LoadAllCampConfigs(GlobalData.GameInstance);
		CampUtils.Camp.Clear();
		for (int i = 0; i < tarray.Num(); i++)
		{
			SCamp scamp = tarray.Get(i);
			List<ERelation> list = new List<ERelation>();
			CampUtils.Camp.Add(list);
			for (int j = 0; j < scamp.Value.Num(); j++)
			{
				int num = scamp.Value.Get(j);
				list.Add((num == 0) ? ERelation.Enemy : ((num == 1) ? ERelation.Friend : ERelation.None));
			}
		}
	}

	// Token: 0x06017F73 RID: 98163 RVA: 0x006B6A78 File Offset: 0x006B4C78
	[NullableContext(2)]
	public static SHitMapping GetHitMapConfig(int mapId)
	{
		bool flag = false;
		SHitMapping result = new SHitMapping();
		DataTableUtil_C.LoadHitMapConfig(mapId, GlobalData.GameInstance, ref result, ref flag);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.YZ;
			string message = "找不到受击映射配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("selfCamp:", mapId.ToString());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}
}
