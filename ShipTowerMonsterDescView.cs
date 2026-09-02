using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029C0 RID: 10688
[NullableContext(2)]
[Nullable(0)]
public class ShipTowerMonsterDescView : UiViewBase
{
	// Token: 0x0601550A RID: 87306 RVA: 0x005E84CF File Offset: 0x005E66CF
	[NullableContext(1)]
	public ShipTowerMonsterDescView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601550B RID: 87307 RVA: 0x005E84D8 File Offset: 0x005E66D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0601550C RID: 87308 RVA: 0x005E8548 File Offset: 0x005E6748
	private void InitDataParam()
	{
	}

	// Token: 0x0601550D RID: 87309 RVA: 0x005E854C File Offset: 0x005E674C
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerMonsterDescView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerMonsterDescView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601550E RID: 87310 RVA: 0x005E8590 File Offset: 0x005E6790
	private void TeamTabFinish()
	{
		if (this.TabComponent == null)
		{
			return;
		}
		Dictionary<int, ShipTowerTeamTabItem> tabItemMap = this.TabComponent.GetTabItemMap();
		ShipTowerMonsterDescViewParams shipTowerMonsterDescViewParams = this.OpenParam as ShipTowerMonsterDescViewParams;
		List<ShipTowerTeamData> list;
		if (shipTowerMonsterDescViewParams == null)
		{
			list = null;
		}
		else
		{
			ShipTowerStageData stageData = shipTowerMonsterDescViewParams.StageData;
			list = ((stageData != null) ? stageData.TeamDataList : null);
		}
		List<ShipTowerTeamData> list2 = list ?? new List<ShipTowerTeamData>();
		foreach (KeyValuePair<int, ShipTowerTeamTabItem> keyValuePair in tabItemMap)
		{
			int key = keyValuePair.Key;
			ShipTowerTeamTabItem value = keyValuePair.Value;
			if (key < list2.Count)
			{
				value.UpdateName(list2[key].AreaName);
			}
		}
		int num = -1;
		int? num2 = (shipTowerMonsterDescViewParams != null) ? shipTowerMonsterDescViewParams.InstId : null;
		for (int i = 0; i < list2.Count; i++)
		{
			int instId = list2[i].InstId;
			int? num3 = num2;
			if (instId == num3.GetValueOrDefault() & num3 != null)
			{
				num = i;
				break;
			}
		}
		int index = (num >= 0) ? num : 0;
		this.TabComponent.SelectToggleByIndex(index, true, true);
	}

	// Token: 0x0601550F RID: 87311 RVA: 0x005E86B8 File Offset: 0x005E68B8
	protected override void OnBeforeShow()
	{
		this.TeamTabFinish();
	}

	// Token: 0x06015510 RID: 87312 RVA: 0x005E86C0 File Offset: 0x005E68C0
	[NullableContext(1)]
	private ShipTowerTeamTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new ShipTowerTeamTabItem();
	}

	// Token: 0x06015511 RID: 87313 RVA: 0x005E86C8 File Offset: 0x005E68C8
	private void ToggleTwoTabCallBack(int index)
	{
		this.CurSelectTabIndex = index;
		ShipTowerMonsterDescViewParams shipTowerMonsterDescViewParams = this.OpenParam as ShipTowerMonsterDescViewParams;
		List<ShipTowerTeamData> list;
		if (shipTowerMonsterDescViewParams == null)
		{
			list = null;
		}
		else
		{
			ShipTowerStageData stageData = shipTowerMonsterDescViewParams.StageData;
			list = ((stageData != null) ? stageData.TeamDataList : null);
		}
		List<ShipTowerTeamData> list2 = list;
		ShipTowerTeamData shipTowerTeamData = null;
		if (list2 != null && this.CurSelectTabIndex >= 0 && this.CurSelectTabIndex < list2.Count)
		{
			shipTowerTeamData = list2[this.CurSelectTabIndex];
		}
		if (shipTowerTeamData != null)
		{
			this.UpdateTeamInfo(shipTowerTeamData);
		}
	}

	// Token: 0x06015512 RID: 87314 RVA: 0x005E8734 File Offset: 0x005E6934
	[NullableContext(1)]
	private void UpdateTeamInfo(ShipTowerTeamData data)
	{
		ShipTowerMonsterWordItem infoAttrPanel = this.InfoAttrPanel;
		if (infoAttrPanel != null)
		{
			infoAttrPanel.UpdateData(data.GetInfoAttr());
		}
		ShipTowerMonsterWordItemData infoWord = data.GetInfoWord();
		if (infoWord != null)
		{
			ShipTowerMonsterWordItem infoWordPanel = this.InfoWordPanel;
			if (infoWordPanel != null)
			{
				infoWordPanel.UpdateData(infoWord);
			}
		}
		ShipTowerMonsterWordItem infoWordPanel2 = this.InfoWordPanel;
		if (infoWordPanel2 != null)
		{
			infoWordPanel2.SetActive(infoWord != null);
		}
		ShipTowerMonsterListItem monsterListPanel = this.MonsterListPanel;
		if (monsterListPanel == null)
		{
			return;
		}
		monsterListPanel.UpdateData(data.GetMonsterListItemData());
	}

	// Token: 0x0400A443 RID: 42051
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<ShipTowerTeamTabItem> TabComponent;

	// Token: 0x0400A444 RID: 42052
	private int CurSelectTabIndex;

	// Token: 0x0400A445 RID: 42053
	private ShipTowerMonsterWordItem InfoAttrPanel;

	// Token: 0x0400A446 RID: 42054
	private ShipTowerMonsterWordItem InfoWordPanel;

	// Token: 0x0400A447 RID: 42055
	private ShipTowerMonsterListItem MonsterListPanel;

	// Token: 0x0400A448 RID: 42056
	private UUIItem ItemAttr;

	// Token: 0x0400A449 RID: 42057
	private UUIItem ItemMonster;

	// Token: 0x02008D17 RID: 36119
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F75C RID: 194396
		public const int ItemRoot = 0;

		// Token: 0x0402F75D RID: 194397
		public const int ItemAttr = 1;

		// Token: 0x0402F75E RID: 194398
		public const int ItemMonster = 2;

		// Token: 0x0402F75F RID: 194399
		public const int ItemTabComponent = 3;
	}
}
