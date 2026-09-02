using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BF9 RID: 11257
public class TowerMonsterItem : GridProxyAbstract<int>
{
	// Token: 0x06016765 RID: 92005 RVA: 0x0063D958 File Offset: 0x0063BB58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016766 RID: 92006 RVA: 0x0063DA03 File Offset: 0x0063BC03
	protected override void OnStart()
	{
		this.ElementLayout = new GenericLayout<TowerElementItem, int>(base.GetHorizontalLayout(3), new Func<TowerElementItem>(this.CreateElementItem), null, false, true);
	}

	// Token: 0x06016767 RID: 92007 RVA: 0x0063DA28 File Offset: 0x0063BC28
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(data);
		base.SetTextureByPath(monsterIcon, base.GetTexture(2), null, null);
		int[] source = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(data).Value.ElementIdArray();
		GenericLayout<TowerElementItem, int> elementLayout = this.ElementLayout;
		if (elementLayout != null)
		{
			elementLayout.RefreshByData(source.ToList<int>(), null, false);
		}
		string monsterName = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterName(data);
		base.GetText(0).SetText(monsterName, true);
		int instanceId = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(ModelBase<TowerModel>.Instance.CurrentSelectFloor).Value.InstanceId;
		int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(recommendLevel));
	}

	// Token: 0x06016768 RID: 92008 RVA: 0x0063DB0C File Offset: 0x0063BD0C
	public void SetLevelText(int level)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_InstanceDungeonRecommendLevel_Text", new <>z__ReadOnlySingleElementList<object>(level));
	}

	// Token: 0x06016769 RID: 92009 RVA: 0x0063DB2F File Offset: 0x0063BD2F
	[NullableContext(1)]
	private TowerElementItem CreateElementItem()
	{
		return new TowerElementItem();
	}

	// Token: 0x0400ADE1 RID: 44513
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerElementItem, int> ElementLayout;

	// Token: 0x02008EF0 RID: 36592
	private enum EChildType
	{
		// Token: 0x0403004A RID: 196682
		NameText,
		// Token: 0x0403004B RID: 196683
		LevelText,
		// Token: 0x0403004C RID: 196684
		MonsterTexture,
		// Token: 0x0403004D RID: 196685
		ElementLayout
	}
}
